using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmRptOutstroageSumMoney : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmRptOutstroageSumMoney()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_RptOutstroageSumMoney();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmRptOutstroageSumMoney_Load(object sender, EventArgs e)
        {
            ((clsCtl_RptOutstroageSumMoney)this.objController).m_mthInit();
        }

        private void txtStoreroom_ItemSelectedOK(object s, EventArgs e)
        {
            ((clsCtl_RptOutstroageSumMoney)this.objController).m_mthChooseMedType(this.txtStoreroom.Value.Trim());
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptOutstroageSumMoney)this.objController).m_mthSearch();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dw, false);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog frmSFD = new SaveFileDialog();
            frmSFD.Filter = "ExcelÎÄ¼þ|*.xls";
            if (frmSFD.ShowDialog() == DialogResult.OK)
            {
                if (frmSFD.FileName != string.Empty)
                    dw.SaveAs(frmSFD.FileName, Sybase.DataWindow.FileSaveAsType.Excel);
            }
        }
    }
}