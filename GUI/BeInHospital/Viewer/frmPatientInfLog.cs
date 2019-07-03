using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPatientInfLog : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmPatientInfLog()
        {
            InitializeComponent();
        }
        
        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlPatientInfLog();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 接收函数接口
        /// <summary>
        /// 
        /// </summary>
        internal string str_parmval = "0";

        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;

            this.Show();
        }
        #endregion

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_dtpBeginDate.Value.ToString("yyyy-MM-dd"), this.m_dtpEndDate.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
  
            ((clsCtlPatientInfLog)this.objController).GetPatienInfLog();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            this.m_dwLog.Print(true);
        }

        private void m_cmdReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtInPatientId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void m_txtInPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtlPatientInfLog)this.objController).DwRetrieve();
            }
        }

        private void frmPatientInfLog_Load(object sender, EventArgs e)
        {

        }
    }
}