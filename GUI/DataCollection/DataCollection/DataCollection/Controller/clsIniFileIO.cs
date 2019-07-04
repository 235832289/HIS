using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.DataCollection
{
    internal class clsIniFileIO
    {
        #region API����
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string p_strSection, string p_strKey, string p_strValue, string p_strFilePath);
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string p_strSection, string p_strKey, string p_strDef, StringBuilder p_sbValue, int p_intSize, string p_strFilePath);
        #endregion

        #region ����/����
        /// <summary>
        /// INI�ļ�·��
        /// </summary>
        private static string m_strIniFilePath = System.Windows.Forms.Application.StartupPath + "\\DbConfig.ini";
        #endregion

        #region ��ȡINI�ļ�
        /// <summary>
        /// ��ȡINI�ļ�
        /// </summary>
        /// <param name="p_strSection"></param>
        /// <param name="p_strKey"></param>
        /// <param name="p_strDef"></param>
        /// <param name="p_intSize"></param>
        /// <returns></returns>
        public static string m_strReadIniFile(string p_strSection, string p_strKey)
        {
            string strValue = string.Empty;

            if (System.IO.File.Exists(m_strIniFilePath))
            {
                StringBuilder sbValue = new StringBuilder(128);
                long lngResult = GetPrivateProfileString(p_strSection, p_strKey, "", sbValue, 128, m_strIniFilePath);
                strValue = sbValue.ToString().Trim();
            }

            return strValue;
        }
        #endregion

        #region д��INI�ļ�
        /// <summary>
        /// д��INI�ļ�
        /// </summary>
        /// <param name="p_strSection"></param>
        /// <param name="p_strKey"></param>
        /// <param name="p_strValue"></param>
        public static void m_mthWriteIniFile(string p_strSection, string p_strKey, string p_strValue)
        {
            if (!System.IO.File.Exists(m_strIniFilePath))
            {
                System.IO.File.Create(m_strIniFilePath);
            }
            
            WritePrivateProfileString(p_strSection, p_strKey, p_strValue, m_strIniFilePath);
        }
        #endregion
    }
}
