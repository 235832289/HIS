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
    public partial class frmRptGoWayStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal DataTable m_dtMedince;
        internal DataTable m_dtProduct;
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strDrugID;
        internal string m_strDrugStoreName;
        /// <summary>
        /// 药房Id对应的部门id，实际查询用此作为参数
        /// </summary>
        internal string m_strDeptID;
        /// <summary>
        /// 处方金额
        /// </summary>
        internal double m_dblSumMoney;
        /// <summary>
        /// 出库金额
        /// </summary>
        internal double m_dblOutMoney;
        /// <summary>
        /// 摆药金额
        /// </summary>
        internal double m_dblPutMoney;
        /// <summary>
        /// 小计金额
        /// </summary>
        internal double m_dblDiffMoney;
        public frmRptGoWayStat()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_RptGoWayStat();
            objController.Set_GUI_Apperance(this);
        }

        public void m_mthShow(string p_strDrugID)
        {
            this.m_strDrugID = p_strDrugID.Trim();
            ((clsCtl_RptGoWayStat)this.objController).m_lngGetStoreNameByID(m_strDrugID, out m_strDrugStoreName);

            this.Text = "处方耗用按开单科室统计表(" + m_strDrugStoreName + ")";
            ((clsCtl_RptGoWayStat)this.objController).m_lngGetDeptIDByDrugID(m_strDrugID, out m_strDeptID);
            this.Show();
        }

        private void frmRptInstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvGoWayStat.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpSearchEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");

            ((clsCtl_RptGoWayStat)this.objController).m_mthInit();
            ((clsCtl_RptGoWayStat)this.objController).m_mthFillMedType();
        }       

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {           
            ((clsCtl_RptGoWayStat)this.objController).m_mthSearch();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public clsPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
                clsPub.ChoosePrintDialog(this.dw, true);
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtMedicineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((clsCtl_RptGoWayStat)this.objController).m_mthSearch();
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            //SaveFileDialog frmSFD = new SaveFileDialog();
            //frmSFD.Filter = "Excel文件|*.xls";
            //if (frmSFD.ShowDialog() == DialogResult.OK)
            //{
            //    if (frmSFD.FileName != string.Empty)
            //        dw.SaveAs(frmSFD.FileName, Sybase.DataWindow.FileSaveAsType.Excel);
            //}
            if (this.m_dgvGoWayStat.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvGoWayStat);
            }
        }

        private void m_dgvGoWayStat_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvGoWayStat.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvGoWayStat.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void m_dgvGoWayStat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvGoWayStat.DataSource == null) return;
            DataTable dt = this.m_dgvGoWayStat.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvGoWayStat.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvGoWayStat.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvGoWayStat.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvGoWayStat.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptGoWayStat)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvGoWayStat.Sort(m_dgvGoWayStat.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }
    }
}