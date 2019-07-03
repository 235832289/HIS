using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmChargeLogBu : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 外部接口
        /// <summary>
        /// 报表类型 2 补记帐 3 确认记帐 4 确认收费 5 直接收费
        /// </summary>
        private int RptType = 0;       
        /// <summary>
        /// 外部Show
        /// </summary>
        internal string str_parmval = "";
        /// <param name="ParmVal"></param>
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            string[] str_Arr = ParmVal.Split('★');
            if (str_Arr.Length >= 1)
            {
                RptType = int.Parse(str_Arr[0]);
            }
            this.Show();
        }
        #endregion

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

        public frmChargeLogBu()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }
  


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

            clsPublic.PlayAvi("findFILE.avi", "正在统计费用信息，请稍候...");
            this.objReport.m_lngRptLogBuShou(RptType, OperCode,BeginDate, EndDate, DeptIDArr, this.dwRep);
            clsPublic.CloseAvi();

            this.dwRep.Refresh();
        }

        private void frmChargeLogBu_Load(object sender, EventArgs e)
        {
            string RptTitle = "";

            if (RptType == 2)
            {
                RptTitle = "补记账日志报表";
            }
            else if (RptType == 3)
            {
                RptTitle = "确认记帐日志报表";
            }
            else if (RptType == 4)
            {
                RptTitle = "确认收费日志报表";
            }
            else if (RptType == 5)
            {
                RptTitle = "直接收费日志报表";
            }

            this.Text = RptTitle;

            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_charge_log_bc";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + RptTitle + "'");       
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