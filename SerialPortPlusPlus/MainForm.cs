using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SerialPortPlusPlus
{
    public partial class MainForm : Form
    {
        private const bool FLAG_INTERACTIVE_TERMINAL_SUPPORT = true;

        private SerialPort mSerialPort;
        private System.Timers.Timer mTimer;
        private bool isSupportInteractiveTerminal = FLAG_INTERACTIVE_TERMINAL_SUPPORT;
        private bool hasSendingText = false;

        private delegate void SetReceiveTextCallback(String text);
        private delegate void TimerTimeOutCallback();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitSerialPort();
        }

        private void InitSerialPort()
        {
            mSerialPort = new SerialPort();

            InitSerialPortControls();
            InitSerialPortComponents();

            ConfigureSerialPort();

            mSerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
        }

        private void InitSerialPortControls()
        {
            string[] portNames = SerialPort.GetPortNames();
            if (portNames == null || portNames.Length == 0)
            {
                Console.Write("[Error] InitSerialPortControls: no found available port!");
            }
            else
            {
                Array.Sort(portNames);                  // sort ports
                foreach (string portname in portNames)
                {
                    cbPortName.Items.Add(portname);
                }
                cbPortName.SelectedIndex = 0;           // COMX
            }

            string[] baudRates = {
                    "110", "300", "600", "1200",
                    "2400", "4800", "9600", "14400",
                    "19200", "38400", "56000", "57600",
                    "115200", "128000", "256000", "230400",
            };
            cbBaudRate.Items.AddRange(baudRates);
            cbBaudRate.SelectedIndex = 12;          // 115200

            string[] dataBits = { "5", "6", "7", "8" };
            cbDataBits.Items.AddRange(dataBits);
            cbDataBits.SelectedIndex = 3;           // 8
            cbDataBits.DropDownStyle = ComboBoxStyle.DropDownList;  // only allow select, no edit

            string[] stopBits = { "1", "1.5", "2" };
            cbStopBits.Items.AddRange(stopBits);
            cbStopBits.SelectedIndex = 0;           // 1
            cbStopBits.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] parities = { "None", "Odd", "Even", "Mark", "Space" };
            cbParity.Items.AddRange(parities);
            cbParity.SelectedIndex = 0;             // None
            cbParity.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] flowControls = { "None", "RTS/CTS", "XON/XOFF" };
            cbFlowControl.Items.AddRange(flowControls);
            cbFlowControl.SelectedIndex = 0;        // None
            cbFlowControl.DropDownStyle = ComboBoxStyle.DropDownList;


            btnSendText.Enabled = false;
            sslblSerialPortStatus.Text = "";

            tbSendingText.Text = "type string sending here";
            tbSendingText.ForeColor = Color.Gray;
            tbSendingText.Font = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);

            //tbReceiveText.Font = new Font("Courier New", 8, FontStyle.Bold);
            tbReceiveText.Font = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);

            string[] intervals = { "100", "200", "500", "1000", "2000", "50000" };
            cbTimerInterval.Items.AddRange(intervals);
            cbTimerInterval.SelectedIndex = 3;      // 1000 ms
        }

        private void InitSerialPortComponents()
        {
            mTimer = new System.Timers.Timer();
            mTimer.AutoReset = true;                // repeat run
            mTimer.Elapsed += new ElapsedEventHandler(timer_Timeout);
        }

        private void timer_Timeout(object sender, ElapsedEventArgs e)
        {
            try
            {
                // error: cross-thread access control cbTimerInterval
                //mTimer.Interval = (double)(Convert.ToInt32(cbTimerInterval.SelectedItem));  // ms
                //if (mTimer.Enabled)
                //{
                //btnSendText.PerformClick();
                this.Invoke(new TimerTimeOutCallback(sendTextTimer));
                //}
            }
            catch (System.Exception ex)
            {
                mTimer.Enabled = false;
                Console.Write("[Error] timer_Timeout: {0}", ex.Message);
            }
        }

        private void sendTextTimer()
        {
            mTimer.Interval = (double)(Convert.ToInt32(cbTimerInterval.SelectedItem));  // ms
            if (mTimer.Enabled)
            {
                btnSendText.PerformClick();
            }
        }

        private void ConfigureSerialPort()
        {
            mSerialPort.PortName = (string)(cbPortName.SelectedItem);
            mSerialPort.BaudRate = Convert.ToInt32(cbBaudRate.SelectedItem);
            mSerialPort.DataBits = Convert.ToInt32(cbDataBits.SelectedItem);

            switch ((string)(cbStopBits.SelectedItem))
            {
                case "1":
                    mSerialPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    mSerialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    mSerialPort.StopBits = StopBits.Two;
                    break;
                default:
                    break;
            }

            switch ((string)(cbParity.SelectedItem))
            {
                case "None":
                    mSerialPort.Parity = Parity.None;
                    break;
                case "Odd":
                    mSerialPort.Parity = Parity.Odd;
                    break;
                case "Even":
                    mSerialPort.Parity = Parity.Even;
                    break;
                case "Mark":
                    mSerialPort.Parity = Parity.Mark;
                    break;
                case "Space":
                    mSerialPort.Parity = Parity.Space;
                    break;
                default:
                    break;
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (mSerialPort == null || !mSerialPort.IsOpen)
            {
                return;
            }

            string dataString = null;
            try
            {
                if (!cbHexReceive.Checked)
                {
                    //string dataString = mSerialPort.ReadLine();
                    dataString = mSerialPort.ReadExisting();
                }
                else
                {
                    byte[] dataBytes = new byte[mSerialPort.BytesToRead];
                    mSerialPort.Read(dataBytes, 0, dataBytes.Length);
                    for (int i = 0; i < dataBytes.Length; i++)
                    {
                        dataString += dataBytes[i].ToString("X2");      // 0xFE -> "FE"
                        dataString += " ";
                    }
                    //dataString.TrimEnd();     // comment to enable separate received bytes between two times through a space
                }
            }
            catch (System.Exception ex)
            {
                Console.Write("[Error] SerialPortDataReceived: get dataString failure! {0}", ex.Message);
                dataString = "";
            }

            if (dataString != String.Empty)
            {
                this.BeginInvoke(new SetReceiveTextCallback(SetReceiveText), new object[] { dataString });
            }

            mSerialPort.DiscardInBuffer();
        }

        private void SetReceiveText(string text)        // maybe change it
        {
            // Note:
            // append text firstly, and then scroll to the end
            // its effect maybe affect by TextBox highSize, so adjust it
            if (cbReceiveNewline.Checked)
            {
                text += System.Environment.NewLine;     // '\n'
            }
            tbReceiveText.AppendText(text);

            //tbReceiveText.Focus();
            //tbReceiveText.SelectionStart = tbReceiveText.TextLength;    // Set the current caret position at the end
            //tbReceiveText.SelectionLength = 0;
            tbReceiveText.Select(tbReceiveText.TextLength, 0);          // can comment it
            tbReceiveText.ScrollToCaret();                              // Now scroll it automatically
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "Open")
            {
                try
                {
                    ConfigureSerialPort();
                    mSerialPort.Open();
                    btnOpen.Text = "Close";
                    slblSerialPort.Text = mSerialPort.PortName;
                    sslblSerialPortStatus.Text = "Opened";
                    sslblSerialPortStatus.ForeColor = Color.Green;
                    btnSendText.Enabled = true;

                    if (cbTimer.Checked)
                    {
                        mTimer.Interval = (double)(int.Parse(cbTimerInterval.Text));  // ms
                        mTimer.Enabled = true;
                        mTimer.Start();
                    }
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    Console.Write("[Error] btnOpen_Click: The port maybe has been used by other application! {0}", ex.Message);
                }
                catch (System.IO.IOException ex)
                {
                    Console.Write("[Error] btnOpen_Click: The port don't exist! {0}", ex.Message);
                }
            }
            else
            {
                try
                {
                    mSerialPort.Close();
                    btnOpen.Text = "Open";
                    slblSerialPort.Text = mSerialPort.PortName;
                    sslblSerialPortStatus.Text = "Closed";
                    sslblSerialPortStatus.ForeColor = Color.Red;
                    btnSendText.Enabled = false;

                    if (cbTimer.Checked)
                    {
                        if (mTimer.Enabled)
                        {
                            mTimer.Stop();
                            mTimer.Enabled = false;
                        }
                    }
                }
                catch (System.IO.IOException ex)
                {
                    Console.Write("[Error] btnOpen_Click: close current port failure! {0}", ex.Message);
                }
            }
        }

        // "23FE" -> {0x23 0xFE}
        public static byte[] hexStringToBytes(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString += " ";
            }

            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return returnBytes;
        }

        // {0x23 0xFE} -> "23FE"
        public static string bytesToHexString(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            if (mSerialPort == null || !mSerialPort.IsOpen)
            {
                return;
            }

            string sendStr = tbSendingText.Text.ToString();
            sendStr = sendStr.Trim();     // remove all leading and trailing whitespace
            if (String.IsNullOrEmpty(sendStr))
            {
                return;
            }

            if (!cbHexSend.Checked)
            {
                if (cbSendNewline.Checked)
                {
                    sendStr += System.Environment.NewLine;  // '\n'
                }
                mSerialPort.Write(sendStr);
            }
            else
            {
                sendStr = sendStr.ToUpper();
                sendStr = sendStr.Replace("0X", "");
                sendStr = Regex.Replace(sendStr, @"[^0-9A-F]", "");
                byte[] sendBytes = hexStringToBytes(sendStr);

                mSerialPort.Write(sendBytes, 0, sendBytes.Length);
            }
        }

        private void btnClearReceiveText_Click(object sender, EventArgs e)
        {
            tbReceiveText.Clear();
        }

        private void btnClearSendText_Click(object sender, EventArgs e)
        {
            tbSendingText.Clear();
        }

        private void cbTimer_CheckedChanged(object sender, EventArgs e)
        {
            cbTimerInterval.Enabled = true;
            if (cbTimer.Checked)
            {
                cbTimerInterval.Enabled = false;
            }

            if (mSerialPort == null || !mSerialPort.IsOpen)
            {
                return;
            }

            if (cbTimer.Checked)
            {
                if (!mTimer.Enabled)
                {
                    mTimer.Interval = (double)(Convert.ToInt32(cbTimerInterval.SelectedItem));  // ms
                    mTimer.Enabled = true;
                    mTimer.Start();
                }
            }
            else
            {
                if (mTimer.Enabled)
                {
                    mTimer.Stop();
                    mTimer.Enabled = false;
                }
            }
        }

        // interactive terminal
        private void tbReceiveText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isSupportInteractiveTerminal)
            {
                return;
            }

            if (e.KeyChar == (char)13)  // enter key  
            {
                //serialPort.Write("\r");
                //byte by = 0x0A; '\n'
                byte[] by = { 0x0A };
                //byte by = 0x0D; '\r'
                //byte[] by = {0x0D };
                // enter
                mSerialPort.Write(by, 0, by.Length);
                //serialPort.DiscardInBuffer();
                //byte by = 0x0A;
                //serialPort.BytesToWrite(by);
                //serialPort.Write("\r\n");
                //serialport.wir.Write("\r\n");
                //rtbOutgoing.Text = "";
            }
            else if (e.KeyChar == (char)3)
            {
                Console.Write("pressed ctrl + c");
                byte[] by = { 0x03 };
                mSerialPort.Write(by, 0, by.Length);
            }
            else if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                e.Handled = true;   // ignores anything else outside printable ASCII range
            }
            else
            {
                mSerialPort.Write(e.KeyChar.ToString());
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mSerialPort != null || mSerialPort.IsOpen)
            {
                mSerialPort.Close();
                mSerialPort = null;
            }
        }

        private void tbSendingText_Enter(object sender, EventArgs e)
        {
            if (!hasSendingText)
            {
                tbSendingText.Clear();
            }
            tbSendingText.ForeColor = Color.Black;
        }

        private void tbSendingText_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSendingText.Text))
            {
                hasSendingText = true;
            }
            else
            {
                if (cbHexSend.Checked)
                {
                    tbSendingText.Text = "0xAA,0x55,0xFE | AA 55 FE | AA55FE";
                }
                else
                {
                    tbSendingText.Text = "type string sending here";
                }
                tbSendingText.ForeColor = Color.Gray;
                hasSendingText = false;
            }
        }

        private void cbHexSend_CheckedChanged(object sender, EventArgs e)
        {
            if (hasSendingText)
            {
                return;
            }

            if (cbHexSend.Checked)
            {
                tbSendingText.Text = "0xAA,0x55,0xFE | AA 55 FE | AA55FE";
            }
            else
            {
                tbSendingText.Text = "type string sending here";
            }
        }
    }
}
