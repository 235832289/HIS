using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmRptNOCheckOutInvoice : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmRptNOCheckOutInvoice()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_InvoiceReport();
            objController.Set_GUI_Apperance(this);
        }

        private void frmRptNOCheckOutInvoice_Load(object sender, EventArgs e)
        {
            
            dataWindowControl1.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            dataWindowControl1.DataWindowObject = "d_invoice_nocheckout";
            dataWindowControl1.Modify("t_title.text = '" + ((clsCtl_InvoiceReport)objController).m_objComInfo.m_strGetHospitalTitle() + "门诊未日结汇总报表'");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_InvoiceReport)this.objController).m_intGetNOCheckOutInvoice();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.dataWindowControl1.Print(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dataWindowControl1.PrintProperties.Preview = !this.dataWindowControl1.PrintProperties.Preview;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (this.dataWindowControl1.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.dataWindowControl1.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }
    }
}