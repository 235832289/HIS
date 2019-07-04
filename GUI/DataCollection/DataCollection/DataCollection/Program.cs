using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public class Program
    {
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new com.digitalwave.iCare.gui.DataCollection.frmUploadMain(args));
        }
    }

    public class clsPublic
    {
        /// <summary>
        /// ��Ƶ�ļ����Ŵ���
        /// </summary>
        private static frmAnimation frmAvi = null;

        #region ������Ƶ
        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <param name="AviFileName">��ƵAVI�ļ���</param>
        /// <param name="MessageInfo">��ʾ��Ϣ</param>
        public static void PlayAvi(string AviFileName, string MessageInfo)
        {
            frmAvi = new frmAnimation(AviFileName, MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }

        /// <summary>
        /// ������Ƶ
        /// </summary>
        /// <param name="MessageInfo">��ʾ��Ϣ</param>
        public static void PlayAvi(string MessageInfo)
        {
            frmAvi = new frmAnimation("findFILE.avi", MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }
        #endregion

        #region �ر���Ƶ
        /// <summary>
        /// �ر���Ƶ
        /// </summary>
        public static void CloseAvi()
        {
            if (frmAvi != null)
            {
                frmAvi.Close();
                frmAvi = null;
            }
        }
        #endregion

        #region �ƶ�����
        /// <summary>
        /// �ƶ����巽��
        /// ����MouseDown�¼� by kenny
        /// </summary>
        /// <param name="hwnd">������</param>
        public static void MoveForm(IntPtr hwnd)
        {
            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, ONEMSGNUM, 0);
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int ONEMSGNUM = 0xF017;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        #endregion

        #region �����ݿ�ֵת���������ֶ���ı�׼ֵ
        /// <summary>
        /// �����ݿ�ֵת���������ֶ���ı�׼ֵ
        /// </summary>
        /// <param name="section">��������</param>
        /// <param name="key">����key</param>
        /// <param name="defaultvalue">Ĭ��ֵ</param>
        /// <returns></returns>
        public static string m_strConvertValue(string section, string key, string defaultvalue)
        {
            string strValue = string.Empty;
            try
            {
                string m_strIniFilePath = Application.StartupPath + "\\DataUploadSetting.ini";
                StringBuilder sb = new StringBuilder(128);
                GetPrivateProfileString(section, key, defaultvalue, sb, 128, m_strIniFilePath);
                strValue = sb.ToString().Trim();
            }
            catch
            {
                strValue = defaultvalue;
            }
            return strValue;
        }
        #endregion

        #region ��ȡ�����ļ�
        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        #endregion
    }
}
