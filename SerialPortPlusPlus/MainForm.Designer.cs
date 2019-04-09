namespace SerialPortPlusPlus
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.btnOtherConfig = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFlowControl = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSend = new System.Windows.Forms.GroupBox();
            this.cbTimerInterval = new System.Windows.Forms.ComboBox();
            this.lblTimerUnit = new System.Windows.Forms.Label();
            this.cbTimer = new System.Windows.Forms.CheckBox();
            this.cbHexSend = new System.Windows.Forms.CheckBox();
            this.btnClearSendText = new System.Windows.Forms.Button();
            this.btnSendText = new System.Windows.Forms.Button();
            this.tbSendingText = new System.Windows.Forms.TextBox();
            this.gbReceive = new System.Windows.Forms.GroupBox();
            this.tbReceiveText = new System.Windows.Forms.RichTextBox();
            this.btnClearReceiveText = new System.Windows.Forms.Button();
            this.cbHexReceive = new System.Windows.Forms.CheckBox();
            this.ssSerialPortStatus = new System.Windows.Forms.StatusStrip();
            this.slblSerialPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbSendNewline = new System.Windows.Forms.CheckBox();
            this.cbReceiveNewline = new System.Windows.Forms.CheckBox();
            this.gbGeneral.SuspendLayout();
            this.gbSend.SuspendLayout();
            this.gbReceive.SuspendLayout();
            this.ssSerialPortStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.btnOtherConfig);
            this.gbGeneral.Controls.Add(this.btnSave);
            this.gbGeneral.Controls.Add(this.btnOpen);
            this.gbGeneral.Controls.Add(this.cbBaudRate);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.cbFlowControl);
            this.gbGeneral.Controls.Add(this.label6);
            this.gbGeneral.Controls.Add(this.cbParity);
            this.gbGeneral.Controls.Add(this.label5);
            this.gbGeneral.Controls.Add(this.cbStopBits);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Controls.Add(this.cbDataBits);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.cbPortName);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Location = new System.Drawing.Point(10, 5);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(590, 105);
            this.gbGeneral.TabIndex = 0;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // btnOtherConfig
            // 
            this.btnOtherConfig.Location = new System.Drawing.Point(468, 73);
            this.btnOtherConfig.Name = "btnOtherConfig";
            this.btnOtherConfig.Size = new System.Drawing.Size(75, 23);
            this.btnOtherConfig.TabIndex = 2;
            this.btnOtherConfig.Text = "Other";
            this.btnOtherConfig.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(468, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(468, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(295, 20);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudRate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Baud Rate:";
            // 
            // cbFlowControl
            // 
            this.cbFlowControl.FormattingEnabled = true;
            this.cbFlowControl.Location = new System.Drawing.Point(295, 74);
            this.cbFlowControl.Name = "cbFlowControl";
            this.cbFlowControl.Size = new System.Drawing.Size(121, 21);
            this.cbFlowControl.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Flow Control:";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(73, 74);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Parity:";
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(295, 47);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cbStopBits.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stop Bits:";
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(73, 47);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cbDataBits.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data Bits:";
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(73, 20);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(121, 21);
            this.cbPortName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // gbSend
            // 
            this.gbSend.Controls.Add(this.cbTimerInterval);
            this.gbSend.Controls.Add(this.lblTimerUnit);
            this.gbSend.Controls.Add(this.cbTimer);
            this.gbSend.Controls.Add(this.cbSendNewline);
            this.gbSend.Controls.Add(this.cbHexSend);
            this.gbSend.Controls.Add(this.btnClearSendText);
            this.gbSend.Controls.Add(this.btnSendText);
            this.gbSend.Controls.Add(this.tbSendingText);
            this.gbSend.Location = new System.Drawing.Point(10, 115);
            this.gbSend.Name = "gbSend";
            this.gbSend.Size = new System.Drawing.Size(590, 70);
            this.gbSend.TabIndex = 1;
            this.gbSend.TabStop = false;
            this.gbSend.Text = "Send";
            // 
            // cbTimerInterval
            // 
            this.cbTimerInterval.FormattingEnabled = true;
            this.cbTimerInterval.Location = new System.Drawing.Point(319, 19);
            this.cbTimerInterval.Name = "cbTimerInterval";
            this.cbTimerInterval.Size = new System.Drawing.Size(71, 21);
            this.cbTimerInterval.TabIndex = 7;
            // 
            // lblTimerUnit
            // 
            this.lblTimerUnit.AutoSize = true;
            this.lblTimerUnit.Location = new System.Drawing.Point(396, 23);
            this.lblTimerUnit.Name = "lblTimerUnit";
            this.lblTimerUnit.Size = new System.Drawing.Size(20, 13);
            this.lblTimerUnit.TabIndex = 6;
            this.lblTimerUnit.Text = "ms";
            // 
            // cbTimer
            // 
            this.cbTimer.AutoSize = true;
            this.cbTimer.Location = new System.Drawing.Point(260, 21);
            this.cbTimer.Name = "cbTimer";
            this.cbTimer.Size = new System.Drawing.Size(52, 17);
            this.cbTimer.TabIndex = 4;
            this.cbTimer.Text = "Timer";
            this.cbTimer.UseVisualStyleBackColor = true;
            this.cbTimer.CheckedChanged += new System.EventHandler(this.cbTimer_CheckedChanged);
            // 
            // cbHexSend
            // 
            this.cbHexSend.AutoSize = true;
            this.cbHexSend.Location = new System.Drawing.Point(57, 21);
            this.cbHexSend.Name = "cbHexSend";
            this.cbHexSend.Size = new System.Drawing.Size(45, 17);
            this.cbHexSend.TabIndex = 2;
            this.cbHexSend.Text = "Hex";
            this.cbHexSend.UseVisualStyleBackColor = true;
            // 
            // btnClearSendText
            // 
            this.btnClearSendText.Location = new System.Drawing.Point(468, 18);
            this.btnClearSendText.Name = "btnClearSendText";
            this.btnClearSendText.Size = new System.Drawing.Size(75, 23);
            this.btnClearSendText.TabIndex = 1;
            this.btnClearSendText.Text = "Clear";
            this.btnClearSendText.UseVisualStyleBackColor = true;
            this.btnClearSendText.Click += new System.EventHandler(this.btnClearSendText_Click);
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(468, 43);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Send";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // tbSendingText
            // 
            this.tbSendingText.Location = new System.Drawing.Point(18, 44);
            this.tbSendingText.Name = "tbSendingText";
            this.tbSendingText.Size = new System.Drawing.Size(444, 20);
            this.tbSendingText.TabIndex = 0;
            // 
            // gbReceive
            // 
            this.gbReceive.Controls.Add(this.tbReceiveText);
            this.gbReceive.Controls.Add(this.btnClearReceiveText);
            this.gbReceive.Controls.Add(this.cbHexReceive);
            this.gbReceive.Controls.Add(this.cbReceiveNewline);
            this.gbReceive.Location = new System.Drawing.Point(10, 191);
            this.gbReceive.Name = "gbReceive";
            this.gbReceive.Size = new System.Drawing.Size(590, 295);
            this.gbReceive.TabIndex = 2;
            this.gbReceive.TabStop = false;
            this.gbReceive.Text = "Receive";
            // 
            // tbReceiveText
            // 
            this.tbReceiveText.Location = new System.Drawing.Point(6, 38);
            this.tbReceiveText.Name = "tbReceiveText";
            this.tbReceiveText.Size = new System.Drawing.Size(578, 257);
            this.tbReceiveText.TabIndex = 0;
            this.tbReceiveText.Text = "";
            this.tbReceiveText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReceiveText_KeyPress);
            // 
            // btnClearReceiveText
            // 
            this.btnClearReceiveText.Location = new System.Drawing.Point(468, 12);
            this.btnClearReceiveText.Name = "btnClearReceiveText";
            this.btnClearReceiveText.Size = new System.Drawing.Size(75, 23);
            this.btnClearReceiveText.TabIndex = 1;
            this.btnClearReceiveText.Text = "Clear";
            this.btnClearReceiveText.UseVisualStyleBackColor = true;
            this.btnClearReceiveText.Click += new System.EventHandler(this.btnClearReceiveText_Click);
            // 
            // cbHexReceive
            // 
            this.cbHexReceive.AutoSize = true;
            this.cbHexReceive.Location = new System.Drawing.Point(57, 15);
            this.cbHexReceive.Name = "cbHexReceive";
            this.cbHexReceive.Size = new System.Drawing.Size(45, 17);
            this.cbHexReceive.TabIndex = 2;
            this.cbHexReceive.Text = "Hex";
            this.cbHexReceive.UseVisualStyleBackColor = true;
            // 
            // ssSerialPortStatus
            // 
            this.ssSerialPortStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblSerialPortStatus});
            this.ssSerialPortStatus.Location = new System.Drawing.Point(0, 489);
            this.ssSerialPortStatus.Name = "ssSerialPortStatus";
            this.ssSerialPortStatus.Size = new System.Drawing.Size(609, 22);
            this.ssSerialPortStatus.TabIndex = 3;
            this.ssSerialPortStatus.Text = "SerialPortStatus";
            // 
            // slblSerialPortStatus
            // 
            this.slblSerialPortStatus.Name = "slblSerialPortStatus";
            this.slblSerialPortStatus.Size = new System.Drawing.Size(39, 17);
            this.slblSerialPortStatus.Text = "Ready";
            // 
            // cbSendNewline
            // 
            this.cbSendNewline.AutoSize = true;
            this.cbSendNewline.Location = new System.Drawing.Point(151, 21);
            this.cbSendNewline.Name = "cbSendNewline";
            this.cbSendNewline.Size = new System.Drawing.Size(64, 17);
            this.cbSendNewline.TabIndex = 3;
            this.cbSendNewline.Text = "Newline";
            this.cbSendNewline.UseVisualStyleBackColor = true;
            // 
            // cbReceiveNewline
            // 
            this.cbReceiveNewline.AutoSize = true;
            this.cbReceiveNewline.Location = new System.Drawing.Point(151, 15);
            this.cbReceiveNewline.Name = "cbReceiveNewline";
            this.cbReceiveNewline.Size = new System.Drawing.Size(64, 17);
            this.cbReceiveNewline.TabIndex = 3;
            this.cbReceiveNewline.Text = "Newline";
            this.cbReceiveNewline.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 511);
            this.Controls.Add(this.ssSerialPortStatus);
            this.Controls.Add(this.gbReceive);
            this.Controls.Add(this.gbSend);
            this.Controls.Add(this.gbGeneral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SerialPortPlusPlus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbSend.ResumeLayout(false);
            this.gbSend.PerformLayout();
            this.gbReceive.ResumeLayout(false);
            this.gbReceive.PerformLayout();
            this.ssSerialPortStatus.ResumeLayout(false);
            this.ssSerialPortStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFlowControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnOtherConfig;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbSend;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.TextBox tbSendingText;
        private System.Windows.Forms.Button btnClearSendText;
        private System.Windows.Forms.GroupBox gbReceive;
        private System.Windows.Forms.RichTextBox tbReceiveText;
        private System.Windows.Forms.StatusStrip ssSerialPortStatus;
        private System.Windows.Forms.ToolStripStatusLabel slblSerialPortStatus;
        private System.Windows.Forms.CheckBox cbHexSend;
        private System.Windows.Forms.Label lblTimerUnit;
        private System.Windows.Forms.CheckBox cbTimer;
        private System.Windows.Forms.Button btnClearReceiveText;
        private System.Windows.Forms.CheckBox cbHexReceive;
        private System.Windows.Forms.ComboBox cbTimerInterval;
        private System.Windows.Forms.CheckBox cbSendNewline;
        private System.Windows.Forms.CheckBox cbReceiveNewline;
    }
}

