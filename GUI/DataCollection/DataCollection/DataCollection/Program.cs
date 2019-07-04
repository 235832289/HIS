using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
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
        /// 视频文件播放窗口
        /// </summary>
        private static frmAnimation frmAvi = null;

        #region 播放视频
        /// <summary>
        /// 播放视频
        /// </summary>
        /// <param name="AviFileName">视频AVI文件名</param>
        /// <param name="MessageInfo">提示信息</param>
        public static void PlayAvi(string AviFileName, string MessageInfo)
        {
            frmAvi = new frmAnimation(AviFileName, MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }

        /// <summary>
        /// 播放视频
        /// </summary>
        /// <param name="MessageInfo">提示信息</param>
        public static void PlayAvi(string MessageInfo)
        {
            frmAvi = new frmAnimation("findFILE.avi", MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }
        #endregion

        #region 关闭视频
        /// <summary>
        /// 关闭视频
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

        #region 移动窗体
        /// <summary>
        /// 移动窗体方法
        /// 放在MouseDown事件 by kenny
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
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

        #region 把数据库值转换成卫生局定义的标准值
        /// <summary>
        /// 把数据库值转换成卫生局定义的标准值
        /// </summary>
        /// <param name="section">配置区域</param>
        /// <param name="key">配置key</param>
        /// <param name="defaultvalue">默认值</param>
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

        #region 读取配置文件
        /// <summary>
        /// 读取配置文件
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
