using SerialPortPlusPlus.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortPlusPlus
{
    class Config
    {
        #region constant variables definition
        public const string KEY_PORT_NAME = "PortName";
        public const string KEY_BAUD_RATE = "BaudRate";
        public const string KEY_DATA_BITS = "DataBits";
        public const string KEY_STOP_BITS = "StopBits";
        public const string KEY_PARITY = "Parity";
        public const string KEY_FLOW_CONTROL = "FlowControl";
        public const string KEY_SECTION = "Default";

        public const string DEFAULT_PORT_NAME = "COM1";
        public const string DEFAULT_BAUD_RATE = "115200";
        public const string DEFAULT_DATA_BITS = "8";
        public const string DEFAULT_STOP_BITS = "1";
        public const string DEFAULT_PARITY = "None";
        public const string DEFAULT_FLOW_CONTROL = "None";

        public const string DEFAULT_FILE_NAME = "config.ini";
        #endregion


        #region static variables definition
        public static string PortName = DEFAULT_PORT_NAME;
        public static string BaudRate = DEFAULT_BAUD_RATE;
        public static string DataBits = DEFAULT_DATA_BITS;
        public static string StopBits = DEFAULT_STOP_BITS;
        public static string Parity = DEFAULT_PARITY;
        public static string FlowControl = DEFAULT_FLOW_CONTROL;

        public static string SectionName = KEY_SECTION;
        public static string FilePath = AppDomain.CurrentDomain.BaseDirectory + DEFAULT_FILE_NAME;
        #endregion


        #region load/save configs
        public static bool hasDefaultConfig(string filePath)
        {
            string checkFilePath = filePath;
            if (String.IsNullOrEmpty(filePath))
            {
                checkFilePath = AppDomain.CurrentDomain.BaseDirectory + DEFAULT_FILE_NAME;
            }

            return File.Exists(checkFilePath);
        }

        public static void LoadConfig(string filePath)
        {
            FilePath = filePath;
            // use default filename when filePath is null
            if (String.IsNullOrEmpty(filePath))
            {
                FilePath = AppDomain.CurrentDomain.BaseDirectory + DEFAULT_FILE_NAME;
            }

            GetSerialPortConfig();
        }

        public static void SaveConfig()
        {
            // add header to ini file when created firstly
            if (!File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("; Brief:  SerialPortPlusPlus configurations\n");
                sw.Write("; Email:  Shell Ever <shellever@163.com>\n");
                sw.Write("; Notice: This file be automatically generated, don't edit it manually!\n\n");
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            SetSerialPortConfig();

            IniHelper.UpdateFile(FilePath);     // update right now
        }
        #endregion


        #region get/set serial port configs
        private static void GetSerialPortConfig()
        {
            PortName = GetString(KEY_PORT_NAME, DEFAULT_PORT_NAME);
            BaudRate = GetString(KEY_BAUD_RATE, DEFAULT_BAUD_RATE);
            DataBits = GetString(KEY_DATA_BITS, DEFAULT_DATA_BITS);
            StopBits = GetString(KEY_STOP_BITS, DEFAULT_STOP_BITS);
            Parity = GetString(KEY_PARITY, DEFAULT_PARITY);
            FlowControl = GetString(KEY_FLOW_CONTROL, DEFAULT_FLOW_CONTROL);
        }

        private static void SetSerialPortConfig()
        {
            SetString(KEY_PORT_NAME, PortName);
            SetString(KEY_BAUD_RATE, BaudRate);
            SetString(KEY_DATA_BITS, DataBits);
            SetString(KEY_STOP_BITS, StopBits);
            SetString(KEY_PARITY, Parity);
            SetString(KEY_FLOW_CONTROL, FlowControl);
        }
        #endregion


        #region get/set string using specified key
        private static string GetString(string key, string defValue)
        {
            return IniHelper.GetString(SectionName, key, defValue, FilePath);
        }

        private static bool SetString(string key, string value)
        {
            return IniHelper.SetString(SectionName, key, value, FilePath);
        }
        #endregion
    }
}
