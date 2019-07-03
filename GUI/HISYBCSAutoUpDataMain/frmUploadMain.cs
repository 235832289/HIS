using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.HIS;
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmUploadMain : Form
    {
        /// <summary>
        /// 逻辑控制类
        /// </summary>
        private clsCtl_YBChargeAutoUpData clsCtlAutoUpData;

        public frmUploadMain(object[] args)
        {
            InitializeComponent();
            m_arrParameters = ((string[])args);
        }

        public frmUploadMain()
        {
            InitializeComponent();
        }

        private void m_btnZyjzcfsjsc_Click(object sender, EventArgs e)
        {
            clsCtlAutoUpData = new clsCtl_YBChargeAutoUpData();
            DateTime dtmBeginTime = this.dtpTimeBegin.Value;
            DateTime dtmEndTime = this.dtpTimeEnd.Value;
            string jzjlh = txtJZJLH.Text;
            List<entityDisplay> data = new List<entityDisplay>();
            entityDisplay vo = null;
            for (; dtmBeginTime.CompareTo(dtmEndTime) <= 0; dtmBeginTime = dtmBeginTime.AddDays(1))
            {
                long lngRes = -1;
                if (string.IsNullOrEmpty(jzjlh))
                     lngRes = clsCtlAutoUpData.m_mthUpload(dtmBeginTime, dtmBeginTime);
                else
                    lngRes = clsCtlAutoUpData.m_mthUpload(dtmBeginTime, dtmBeginTime, jzjlh);
                m_mthShowMessage(lngRes);
                vo = new entityDisplay();
                vo.date = dtmBeginTime;
                if (lngRes > 0)
                    vo.state = "上传成功";
                else
                    vo.state = "上传失败";
                data.Add(vo);
                if (this.dgvUpload.DataSource != null)
                    this.dgvUpload.DataSource = new List<entityDisplay>();
                this.dgvUpload.DataSource = data;
                pgbTask.Value = 100;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int intFlash = 3;
        int intCurrentFlash = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (intCurrentFlash == intFlash)
            {
                this.Refresh();
                intCurrentFlash = 0;
            }
            else
            {
                intCurrentFlash++;
            }
        }

        private void m_mthShowMessage(long p_flag)
        {
            if (p_flag > 0)
            {
                lblCurrentInfo.Text = "上传成功!";
            }
            else
            {
                lblCurrentInfo.Text = "上传失败!";
            }
        }

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
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        #endregion

        /// <summary>
        /// Ini文件地址
        /// </summary>
        private string _IniFileName;
        /// <summary>
        /// 是否自动运行
        /// </summary>
        public bool m_blnAutoRun = false;
        /// <summary>
        /// 打开参数
        /// </summary>
        private string[] m_arrParameters;

        private void frmUploadMain_Load(object sender, EventArgs e)
        {
            _IniFileName = Application.StartupPath + "\\CSYBDataUploadSetting.ini";

            DateTime dtmNow = DateTime.Now;
            this.dtpTimeBegin.Value = dtmNow.AddDays(-1) ;
            this.dtpTimeEnd.Value = dtmNow.AddDays(-1);

            this.Show();
            if (m_arrParameters != null)
            {
                if (m_arrParameters.Length > 0)
                {

                    Application.DoEvents();
                    for (int i1 = 0; i1 < m_arrParameters.Length; i1++)
                    {
                        if (m_arrParameters[i1].Trim().ToLower() == "-a")
                        {
                            m_blnAutoRun = true;
                        }
                    }
                }
            }
            //此参数暂不使用
            StringBuilder isAutorun = new StringBuilder(128);//控制是否自动执行的参数
            GetPrivateProfileString("doInitialization", "isInitialization", "", isAutorun, 128, _IniFileName);
            if (m_blnAutoRun)
            {
                m_btnZyjzcfsjsc_Click(sender, e);//数据上传功能
                Application.Exit();
            }
        }
    }
}