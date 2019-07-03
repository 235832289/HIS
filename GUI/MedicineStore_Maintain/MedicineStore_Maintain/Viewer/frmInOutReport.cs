using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmInOutReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 仓库名称
        /// </summary>
        internal string m_strStorageName = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 是否药房使用
        /// </summary>
        internal bool m_blnForDrugStore = false;
        /// <summary>
        /// 药房ID对应的部门ID
        /// </summary>
        internal string m_strDeptID = string.Empty;
        public frmInOutReport()
        {
            InitializeComponent();
            m_dtpBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            m_dtpEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_InOutReport();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 显示窗体(药库使用）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            clsPublic.m_lngGetStorageName(false, p_strStorageID, out m_strStorageName);
            this.m_dwcData.LibraryList = clsPublic.PBLPath;
            m_dwcData.DataWindowObject = "ms_instorageinoutreport";
            this.Show();
        }

        /// <summary>
        /// 显示窗体（药房使用）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void m_mthShowThis(string p_strStorageID)
        {
            m_blnForDrugStore = true;
            m_strStorageID = p_strStorageID;
            ((clsCtl_InOutReport)objController).m_lngGetDeptIDForStore(m_strStorageID, out m_strDeptID);
            clsPublic.m_lngGetStorageName(true, p_strStorageID, out m_strStorageName);
            this.m_dwcData.LibraryList = clsPublic.PBLPath;
            m_dwcData.DataWindowObject = "ms_instoreinoutreport";
            this.Show();
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                iCare.gui.HIS.clsPublic.PlayAvi("正在统计信息，请稍候...");
                if (m_blnForDrugStore)
                {
                    ((clsCtl_InOutReport)objController).m_mthQueryForDrugStore();
                }
                else
                {
                    ((clsCtl_InOutReport)objController).m_mthQuery();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"注意...");
            }
            finally
            {
                iCare.gui.HIS.clsPublic.CloseAvi();
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtMedicine_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtMedicine.SelectAll();
        }

        private void m_txtMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbMedicinDict == null || m_dtbMedicinDict.Rows.Count == 0)
                {
                    ((clsCtl_InOutReport)objController).m_mthGetMedicineInfo();
                }
                ((clsCtl_InOutReport)objController).m_mthShowQueryMedicineForm(m_txtMedicine.Text.Trim());
            }
        }

        private void frmInstorageDetailReport_Load(object sender, EventArgs e)
        {
            this.Text = "药品无出入库记录查询(" + m_strStorageName + ")";
            this.m_dgvInOutDetail.AutoGenerateColumns = false;
            m_txtMedicine.Tag = "";

            if (m_blnForDrugStore)
            {
                m_dgvInOutDetail.Columns["outdate"].Visible = false;
            }
            else
            {
                m_dgvInOutDetail.Columns["storageamount"].Width = 130;
                m_dgvInOutDetail.Columns["inamount"].Width = 120;
                m_dgvInOutDetail.Columns["outamount"].Width = 120;
            }

            ((clsCtl_InOutReport)this.objController).m_mthFillMedType();
            Application.DoEvents();
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            if (this.m_dgvInOutDetail.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvInOutDetail);
            }
        }
        private void m_txtMedicine_Leave(object sender, EventArgs e)
        {
            if (m_txtMedicine.Text.Trim() == string.Empty)
                m_txtMedicine.Tag = "";
        }

        private void m_txtMedicine_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicine.Text.Trim() == string.Empty)
                m_txtMedicine.Tag = "";
        }

        private void m_dgvInstorageDetail_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvInOutDetail.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvInOutDetail.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_dgvInstorageDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvInOutDetail.DataSource == null) return;
            DataTable dt = this.m_dgvInOutDetail.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvInOutDetail.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvInOutDetail.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvInOutDetail.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvInOutDetail.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_InOutReport)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvInOutDetail.Sort(m_dgvInOutDetail.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }

        private void m_rbtSingle_CheckedChanged(object sender, EventArgs e)
        {
            m_txtMedicine.Clear();
            m_txtMedicine.Tag = "";
            m_txtMedicine.Focus();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(m_dwcData, true);
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.m_dwcData);
        }
    }
}