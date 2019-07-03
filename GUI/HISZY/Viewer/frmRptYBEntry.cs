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
    /// 医保明细报表UI
    /// </summary>
    public partial class frmRptYBEntry : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptYBEntry()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        #region 外部接口
         /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            this.Show();
        }
        #endregion

        #region 变量
        /// <summary>
        /// 报表控制类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();         
        #endregion

        private void frmRptYBEntry_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.cboType.SelectedIndex = 0;            
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
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            clsPublic.PlayAvi("findFILE.avi", "正在统计医保结算数据，请稍候...");
            this.objReport.m_mthRptYBEntry(BeginDate, EndDate, DeptIDArr, this.dwRep);
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
            string Title = "";
            this.dwRep.DataWindowObject = null;
            if (this.cboType.SelectedIndex == 0)
            {
                Title = this.objReport.HospitalName + "医保结算明细报表";
                this.dwRep.DataWindowObject = "d_bih_ybentry";               
            }
            else
            {
                Title = this.objReport.HospitalName + "医保结算汇总报表";
                this.dwRep.DataWindowObject = "d_bih_ybentry_sum";             
            }
            this.dwRep.InsertRow(0);
            this.dwRep.Modify("t_title.text = '" + Title + "'");
            this.dteRq1.Focus();
        }        
    }
}