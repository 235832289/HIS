using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCare_GL_Report;


namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmGLReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal string m_rptId;

        public frmGLReport()
        {
            InitializeComponent();
        }

        public void ShowWithParm(string p_rptId)
        {
            this.m_rptId = p_rptId;
            this.Show();
        }

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clscontrolGLReport();
            this.objController.Set_GUI_Apperance(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            iCare_GL_Report_Manage_qjf frm_report = new iCare_GL_Report_Manage_qjf(this.m_rptId, "ChaShanNew_OutPatientDocInCount", "ChaShanCheckSys_GLReporting"); 
            frm_report.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iCare_GL_Report_Manage_qjf frm_report = new iCare_GL_Report_Manage_qjf(this.m_rptId, "ChaShanNew_OutPatientInCount", "ChaShanCheckSys_GLReporting"); 
            frm_report.Show();
        }

        private void frmGLReport_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_rptId))
            {
                MessageBox.Show("报表URL为空，请从功能菜单传入报表Id号。");
            }
        }
    }
}