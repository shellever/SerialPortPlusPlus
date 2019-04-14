using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortPlusPlus.Helper
{
    class IniHelper
    {
        #region import kernel32.dll api
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string defValue,        // default value
            byte[] retBuffer,       // return buffer
            int size,
            string filePath
        );

        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath
        );
        #endregion

        #region ini file brief
        /*
         * config.ini
         * ; This file is AUTO Generated, DON'T EDIT IT.
         * ; non case-sensitive
         * [default]
         * PortName=COM1
         * Baudrate=115200
         * DataBits=8
         * StopBits=1
         * Parity=None
         * FlowControl=None
         * 
         */
        #endregion

        #region ini file basic operation api
        /// <summary>
        /// get string using the section and key
        /// <param name="section">section to read</param>
        /// <param name="key">key to read in section</param>
        /// <param name="defValue">default value</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>string to read</returns>
        /// </summary>
        public static string GetString(string section, string key, string defValue, string filePath)
        {
            byte[] buffer = new byte[1024 * 10];
            int size = GetPrivateProfileString(section, key, defValue, buffer, buffer.Length, filePath);
            return Encoding.Default.GetString(buffer, 0, size);
        }

        /// <summary>
        /// set string to key in the section
        /// </summary>
        /// <param name="section">section to write</param>
        /// <param name="key">key to read in section</param>
        /// <param name="value">key value</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool SetString(string section, string key, string value, string filePath)
        {
            return WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// remove section
        /// </summary>
        /// <param name="section">section to write</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool RemoveSection(string section, string filePath)
        {
            return WritePrivateProfileString(section, null, null, filePath);
        }

        /// <summary>
        /// remove key
        /// </summary>
        /// <param name="section">section to write</param>
        /// <param name="key">key to remove in section</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool RemoveKey(string section, string key, string filePath)
        {
            return WritePrivateProfileString(section, key, null, filePath);
        }

        /// <summary>
        /// update file immediately
        /// </summary>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool UpdateFile(string filePath)
        {
            return WritePrivateProfileString(null, null, null, filePath);
        }
        #endregion

        #region ini file extra operation api
        /// <summary>
        /// read keys in section
        /// </summary>
        /// <param name="section">section to read</param>
        /// <param name="keyList">key list</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool GetKeyList(string section, List<string> keyList, string filePath)
        {
            byte[] buffer = new byte[1024 * 10];
            int size = GetPrivateProfileString(section, null, null, buffer, buffer.Length, filePath);
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                if (buffer[i] == 0)
                {
                    keyList.Add(Encoding.Default.GetString(buffer, j, i - j));
                    j = i + 1;
                }
            }

            return true;
        }

        /// <summary>
        /// read sections
        /// </summary>
        /// <param name="sectionList">section list</param>
        /// <param name="filePath">ini file with complete path</param>
        /// <returns>true if success, or failure</returns>
        public static bool GetSectionList(List<string> sectionList, string filePath)
        {
            byte[] buffer = new byte[1024 * 10];
            int size = GetPrivateProfileString(null, null, null, buffer, buffer.Length, filePath);
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                if (buffer[i] == 0)     // separate
                {
                    sectionList.Add(Encoding.Default.GetString(buffer, j, i - j));
                    j = i + 1;
                }
            }

            return true;
        }
        #endregion
    }
}
