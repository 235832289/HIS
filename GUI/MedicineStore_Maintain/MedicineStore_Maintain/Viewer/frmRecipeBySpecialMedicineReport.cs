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
    public partial class frmRecipeBySpecialMedicineReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 药房Id
        /// </summary>
        internal string m_strStorageid;
        internal string m_strStorageName = string.Empty;
        internal DataTable m_dtMedince = null;
        public frmRecipeBySpecialMedicineReport()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_RecipeBySpecialMedicineReport();
            objController.Set_GUI_Apperance(this);
        }

        public void m_mthShow(string p_strStorageid)
        {
            m_strStorageid = p_strStorageid;
            clsPublic.m_lngGetStorageName(true, p_strStorageid, out m_strStorageName);

            this.Text = "麻、精药品处方出库明细表(" + m_strStorageName + ")";
            this.Show();
        }

        private void frmRptInstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvMedDetail.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpSearchEndDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            ((clsCtl_RecipeBySpecialMedicineReport)this.objController).m_mthInit();
            m_cbbType.SelectedIndex = 0;
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_RecipeBySpecialMedicineReport)this.objController).m_mthSearch();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dw, true);
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            //SaveFileDialog frmSFD = new SaveFileDialog();
            //frmSFD.Filter = "Excel文件|*.xls";
            //if (frmSFD.ShowDialog() == DialogResult.OK)
            //{
            //    if (frmSFD.FileName != string.Empty)
            //        dw.SaveAs(frmSFD.FileName, Sybase.DataWindow.FileSaveAsType.Excel);
            //}
            if (this.m_dgvMedDetail.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvMedDetail);
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.dw);
        }

        private void m_dgvMedDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            string m_strStorageid = "0001";
            if (e.KeyCode == Keys.Enter)
            {
                //药品
                if (m_dtMedince == null || m_dtMedince.Rows.Count == 0)
                {
                    ((clsCtl_RecipeBySpecialMedicineReport)this.objController).m_mthGetMedBaseInfo(m_strStorageid, out m_dtMedince);
                }
                ((clsCtl_RecipeBySpecialMedicineReport)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }
    }
}