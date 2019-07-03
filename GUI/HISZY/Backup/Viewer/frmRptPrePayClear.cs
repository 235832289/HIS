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
    /// 已清预交金明细报表UI
    /// </summary>
    public partial class frmRptPrePayClear : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptPrePayClear()
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

        private void frmRptPrePayClear_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_prepayclear";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "已清预交金明细报表'");
            this.dwRep.InsertRow(0);

            this.Cursor = Cursors.Default;
            this.dteRq1.Focus();
        }

        #region 调用外部参数
        /// <summary>
        /// 调用外部参数
        /// </summary>
        internal string str_parmval = "";
        public void m_mthShow(string parmval)
        {

            str_parmval = parmval;
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

            clsPublic.PlayAvi("findFILE.avi", "正在统计已清预交金数据，请稍候...");
            this.objReport.m_mthRptPrePayClear(BeginDate, EndDate,this.dwRep);
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
    }
}