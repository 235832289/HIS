using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 全院(门诊、住院)实收报表UI
    /// </summary>
    public partial class frmRptAllDeptIncome : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptAllDeptIncome()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        #region 变量
        /// <summary>
        /// 报表控制类

        /// </summary>
        private clsCtl_Report objReport;       
        #endregion

        private void frmRptAllDeptIncome_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.cboType.SelectedIndex = 0;

            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            this.Show();
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteRq1.Value.ToString("yyyy-MM-dd"), this.dteRq2.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
        
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "统计全院核算单位实收数据，请稍候...");
                this.objReport.m_mthRptAllDeptIncome(BeginDate, EndDate, this.cboType.SelectedIndex + 1, this.dwRep);                
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            

            this.dwRep.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true); ;
        }       

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Title = this.objReport.HospitalName + "全院核算单位实收报表";

            this.dwRep.DataWindowObject = null;
            this.dwRep.DataWindowObject = "d_alldept_income";
            if (this.cboType.SelectedIndex == 0)
            {
                this.dwRep.Modify("t_date.text = '发票时间：'");
            }
            else
            {
                this.dwRep.Modify("t_date.text = '日结时间：'");
            }
            this.dwRep.InsertRow(0);
            this.dwRep.Modify("t_title.text = '" + Title + "'");
            this.dteRq1.Focus();
        }        
    }
}