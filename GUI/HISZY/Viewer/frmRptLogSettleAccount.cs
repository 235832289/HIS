using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出院结账日志报表
    /// </summary>
    public partial class frmRptLogSettleAccount : Form
    {
        /// <summary>
        /// 出院结账日志报表
        /// </summary>
        public frmRptLogSettleAccount()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        private void frmRptLogSettleAccount_Load(object sender, EventArgs e)
        {
            string RptTitle = "出院结账日志报表";

            this.Text = RptTitle;

            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_log_settle_account";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + RptTitle + "'");
            this.dwRep.Refresh();  
        }
        
        #region 变量
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();
        /// <summary>
        /// 报表业务类

        /// </summary>
        private clsCtl_Report objReport;        
        #endregion              

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }

        #region 调用外部参数
        /// <summary>
        /// 调用外部参数
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

            string OperCode = this.cboOperCode.Text.Trim();
            if (OperCode == "")
            {
                MessageBox.Show("请输入操作员工号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboOperCode.Focus();
                return;
            }
            else
            {
                if (OperCode.IndexOf("全部") >= 0)
                {
                    OperCode = string.Empty;
                }
            }

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在统计出院结账日志信息，请稍候...");
            this.objReport.m_lngRptLogSettleAccount(OperCode,BeginDate, EndDate, DeptIDArr, this.dwRep);
            clsPublic.CloseAvi();

            this.dwRep.Refresh();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}