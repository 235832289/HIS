using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费员日结报表UI类
    /// </summary>
    public partial class frmRptReckoningDept : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;        
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmRptReckoningDept()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptReckoningDept_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_reckoningdept_new";
            this.dwRep.InsertRow(0);
            dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院缴款日结报表'");
            dwRep.Modify("t_dyrq.text = '" + DateTime.Now.ToString("yyyy/MM/dd") + "'");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);          
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }        

        private void btnStat_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.dteBegin.Value.ToString("yyyy-MM-dd") + " 00:00:01") > Convert.ToDateTime(this.dteEnd.Value.ToString("yyyy-MM-dd") + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束结帐日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            else
            {
                clsPublic.PlayAvi("findFILE.avi", "正在统计费用数据，请稍候...");
                this.objReport.m_mthRptReckoningDept(this.dteBegin.Value.ToString("yyyy-MM-dd"), this.dteEnd.Value.ToString("yyyy-MM-dd"), this.dwRep);
                clsPublic.CloseAvi();
            }
        }              

    }
}
