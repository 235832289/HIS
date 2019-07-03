using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmInstorageDetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
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
        /// <summary>
        /// 是否住院药房
        /// </summary>
        internal bool m_blnIsHospital;
        public frmInstorageDetailReport()
        {
            InitializeComponent();
            m_dtpBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            m_dtpEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            this.m_dwcData.LibraryList = clsPublic.PBLPath;                       
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_InstorageDetailReport();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 显示窗体(药库使用）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            this.m_dwcData.LibraryList = clsPublic.PBLPath;
            m_dwcData.DataWindowObject = "ms_instoredetailreports";
            //m_dwcData.DataWindowObject = "ms_instoragedetailreport";
            clsPublic.m_lngGetStorageName(false, p_strStorageID, out m_strStorageName);
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
            ((clsCtl_InstorageDetailReport)objController).m_lngGetDeptIDForStore(m_strStorageID, out m_strDeptID);
            ((clsCtl_InstorageDetailReport)objController).m_lngCheckIsHospital(m_strStorageID,out m_blnIsHospital);
            this.m_dwcData.LibraryList = clsPublic.PBLPath;
            //m_dwcData.DataWindowObject = "ms_instoredetailreport";
            m_dwcData.DataWindowObject = "ms_instoredetailreports";
            clsPublic.m_lngGetStorageName(true, p_strStorageID, out m_strStorageName);
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
                    ((clsCtl_InstorageDetailReport)objController).m_mthQueryForDrugStore();
                }
                else
                {
                    ((clsCtl_InstorageDetailReport)objController).m_mthQuery();
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

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(m_dwcData, true);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InstorageDetailReport)objController).m_mthShowVendor(m_txtVendor.Text);
            }
        }

        private void m_txtVendor_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtVendor.SelectAll();
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
                    ((clsCtl_InstorageDetailReport)objController).m_mthGetMedicineInfo();
                }
                ((clsCtl_InstorageDetailReport)objController).m_mthShowQueryMedicineForm(m_txtMedicine.Text.Trim());
            }
        }

        private void frmInstorageDetailReport_Load(object sender, EventArgs e)
        {
            this.Text = "入库药品详细记录(" + m_strStorageName + ")";
            this.m_dgvInstorageDetail.AutoGenerateColumns = false;
            if (m_blnForDrugStore)
            {
                DataTable dtbDept = null;
                ((clsCtl_InstorageDetailReport)objController).m_mthGetExportDept(out dtbDept);
                m_txtReceiveDept.m_mthInitDeptData(dtbDept);
                m_txtVendor.Visible = false;
                m_txtReceiveDept.BringToFront();
                //20080827 购入价和购入金额不显示
                m_dgvInstorageDetail.Columns["callprice_int"].Visible = false;
                m_dgvInstorageDetail.Columns["callsum"].Visible = false;
            }
            else
            {
                m_txtReceiveDept.Visible = false;
                m_txtVendor.Visible = true;
                m_txtVendor.BringToFront();
            }

            m_txtVendor.Tag = "";
            m_txtMedicine.Tag = "";

            ((clsCtl_InstorageDetailReport)this.objController).m_mthFillMedType();
            ((clsCtl_InstorageDetailReport)objController).m_mthGetImpExpTypeInfo(); 
            Application.DoEvents();
            m_bgwGetMedicine.RunWorkerAsync();
        }

        private void m_bgwGetMedicine_DoWork(object sender, DoWorkEventArgs e)
        {
            //((clsCtl_InstorageDetailReport)objController).m_mthGetMedicineInfo();
        }

        private void m_txtReceiveDept_FocusNextControl(object sender, EventArgs e)
        {
            txtTypecode.Focus();
        }

        private void m_txtReceiveDept_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(m_txtReceiveDept.Text.Trim()))
            //{
            //    m_txtReceiveDept.Tag = "";
            //}
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            //clsPublic.ExportToExcel(m_dwcData);
            if (this.m_dgvInstorageDetail.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvInstorageDetail);
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //m_dwcData.PrintProperties.Preview = !m_dwcData.PrintProperties.Preview;
            //m_dwcData.PrintProperties.ShowPreviewRulers = !m_dwcData.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.m_dwcData);
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
            if (this.m_dgvInstorageDetail.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvInstorageDetail.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_dgvInstorageDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvInstorageDetail.DataSource == null) return;
            DataTable dt = this.m_dgvInstorageDetail.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvInstorageDetail.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvInstorageDetail.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvInstorageDetail.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvInstorageDetail.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_InstorageDetailReport)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvInstorageDetail.Sort(m_dgvInstorageDetail.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }

        private void m_rbtSingle_CheckedChanged(object sender, EventArgs e)
        {
            m_txtMedicine.Clear();
            m_txtMedicine.Tag = "";
            m_txtMedicine.Focus();
        }

        //private void m_txtReceiveDept_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(m_txtReceiveDept.Text.Trim()))
        //    {
        //        m_txtReceiveDept.Tag = "";
        //    }
        //}

        
    }
}