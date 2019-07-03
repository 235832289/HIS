using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmCpStat1 : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmCpStat1()
        {
            InitializeComponent();
        }

        #region Stat
        /// <summary>
        /// Stat
        /// </summary>
        void Stat()
        {
            string month = this.dteBegin.Value.ToString("yyyy-MM");
            string BeginDate = month + "-01";
            DateTime dtm = Convert.ToDateTime(BeginDate);
            string EndDate = ((dtm.AddDays(1 - dtm.Day)).AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd");

            clsPublic.PlayAvi("findFILE.avi", "统计临床路径实施汇总信息，请稍候...");
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable dt = svc.GetCpStat1(BeginDate, EndDate);
            dwRep.SetRedrawOff();
            dwRep.Retrieve(dt);
            if (dwRep.RowCount == 0)
            {
                dwRep.InsertRow(0);
            }
            dwRep.SetRedrawOn();
            clsPublic.CloseAvi();
            this.dwRep.Refresh();
        }
        #endregion

        private void frmCpStat1_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_cp_stat1";
            this.dwRep.Reset();
            this.dwRep.InsertRow(0);
            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.Refresh();
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            this.Stat();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
