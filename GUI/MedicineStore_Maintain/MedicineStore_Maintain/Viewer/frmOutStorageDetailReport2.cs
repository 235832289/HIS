using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库明细报表
    /// </summary>
    public partial class frmOutStorageDetailReport2 : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 是否广医三院药库使用
        /// </summary>
        internal bool m_blnGY3Y_MS = false;
        /// <summary>
        /// 是否广医三院药房使用
        /// </summary>
        internal bool m_blnGY3Y_DS = false;
        /// <summary>
        /// 药房ID对应的部门ID
        /// </summary>
        internal string m_strDeptID = string.Empty;
        internal string m_strStorageName = string.Empty;
        /// <summary>
        /// 是否住院药房
        /// </summary>
        internal bool m_blnIsHospital;
        #endregion

        /// <summary>
        /// 出库明细报表
        /// </summary>
        public frmOutStorageDetailReport2()
        {
            InitializeComponent();

            m_dtpSearchBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            m_dtpSearchEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void m_mthShow(string p_strStorageID,string p_strReportName)
        {
            m_strStorageID = p_strStorageID;
            this.datWindow.LibraryList = clsPublic.PBLPath;
            datWindow.DataWindowObject = p_strReportName == "" ? "ms_outstoragedetail" : "ms_outstoragedetail_" + p_strReportName;
            m_bgwGetMedicine.RunWorkerAsync();

            DataTable dtbDept = null;
            ((clsCtl_OutStorageDetailReport2)objController).m_mthGetExportDept(out dtbDept);
            m_txtExportDept.m_mthInitDeptData(dtbDept);
            clsPublic.m_lngGetStorageName(false, p_strStorageID, out m_strStorageName);
           
            this.Text = "出库药品详细记录(" + m_strStorageName + ")";
            this.Show();
        }

        /// <summary>
        /// 显示窗体（广医三院药库使用）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_blnGY3Y_MS = true;
            m_chkGetIn.Visible = false;
            label4.Visible = true;
            m_cboType.Visible = true;
            m_labExportDept.Text = "领用部门";
            m_strStorageID = p_strStorageID;
            this.datWindow.LibraryList = clsPublic.PBLPath;
            datWindow.DataWindowObject = "ms_outstoragedetailreports";
            //datWindow.DataWindowObject = "ms_outstoragedetailreport";
            m_bgwGetMedicine.RunWorkerAsync();
           
            DataTable dtbDept = null;
            ((clsCtl_OutStorageDetailReport2)objController).m_mthGetExportDept(out dtbDept);
            m_txtExportDept.m_mthInitDeptData(dtbDept);
            ((clsCtl_OutStorageDetailReport2)objController).m_mthGetImpExpTypeInfo();
            clsPublic.m_lngGetStorageName(false, p_strStorageID, out m_strStorageName);
            
            this.Text = "出库药品详细记录(" + m_strStorageName + ")";
            this.Show();
        }

        /// <summary>
        /// 显示窗体（广医三院药房使用）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void m_mthShowThis(string p_strStorageID)
        {
            m_blnGY3Y_DS = true;
            m_chkGetIn.Visible = false;
            label4.Visible = true;
            m_cboType.Visible = true;
            m_labExportDept.Text = "领用部门";
            m_strStorageID = p_strStorageID;
            this.datWindow.LibraryList = clsPublic.PBLPath;
            datWindow.DataWindowObject = "ms_outstoragedetailreports";
            //datWindow.DataWindowObject = "ms_outstoragedetailreport";
            m_bgwGetMedicine.RunWorkerAsync();
            ((clsCtl_OutStorageDetailReport2)objController).m_lngGetDeptIDForStore(m_strStorageID, out m_strDeptID);
            ((clsCtl_OutStorageDetailReport2)objController).m_lngCheckIsHospital(m_strStorageID, out m_blnIsHospital);
            DataTable dtbDept = null;
            ((clsCtl_OutStorageDetailReport2)objController).m_mthGetExportDept(out dtbDept);
            m_txtExportDept.m_mthInitDeptData(dtbDept);
            ((clsCtl_OutStorageDetailReport2)objController).m_mthGetImpExpTypeInfo();
            clsPublic.m_lngGetStorageName(true, p_strStorageID, out m_strStorageName);
            
            this.Text = "出库药品详细记录(" + m_strStorageName + ")";
            this.Show();
        }


        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_OutStorageDetailReport2();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            if (m_blnGY3Y_DS)
            {
                ((clsCtl_OutStorageDetailReport2)objController).m_mthGetReportForDrugStore();
            }
            else if (m_blnGY3Y_MS)
            {
                ((clsCtl_OutStorageDetailReport2)objController).m_mthGetReportNew();
            }
            else
            {
                ((clsCtl_OutStorageDetailReport2)objController).m_mthGetReport();
            }
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPring = new clsCtl_Public();
            clsPring.ChoosePrintDialog(datWindow,true);
        }

        private void m_bgwGetMedicine_DoWork(object sender, DoWorkEventArgs e)
        {
            //((clsCtl_OutStorageDetailReport2)objController).m_mthGetMedicineInfo();
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbMedicinDict == null || m_dtbMedicinDict.Rows.Count == 0)
                {
                    ((clsCtl_OutStorageDetailReport2)objController).m_mthGetMedicineInfo();
                }
                ((clsCtl_OutStorageDetailReport2)objController).m_mthShowQueryMedicineForm(m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_txtExportDept_FocusNextControl(object sender, EventArgs e)
        {
            m_txtMedicineCode.Focus();
        }

        private void frmOutStorageDetailReport_Load(object sender, EventArgs e)
        {            
            this.m_dgvOutstorageDetail.AutoGenerateColumns = false;
            //this.m_dgvOutStorageDetailRpt.AutoGenerateColumns = false;
            //if (m_blnGY3Y_DS || m_blnGY3Y_MS)
            //{
            //    this.m_dgvOutStorageDetailRpt.Visible = false;
            //}
            m_txtExportDept.Tag = "";
            m_txtMedicineCode.Tag = "";
            ((clsCtl_OutStorageDetailReport2)this.objController).m_mthFillMedType();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            //clsPublic.ExportToExcel(datWindow);
            if (this.m_dgvOutstorageDetail.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvOutstorageDetail);
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //datWindow.PrintProperties.Preview = !datWindow.PrintProperties.Preview;
            //datWindow.PrintProperties.ShowPreviewRulers = !datWindow.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.datWindow);
        }

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtMedicineCode.Text.Trim()))
            {
                m_txtMedicineCode.Tag = "";
            }
        }

        private void m_txtExportDept_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtExportDept.Text.Trim()))
            {
                m_txtExportDept.Tag = "";
            }
        }

        private void m_dgvOutstorageDetail_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvOutstorageDetail.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvOutstorageDetail.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void m_dgvOutstorageDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvOutstorageDetail.DataSource == null) return;
            DataTable dt = this.m_dgvOutstorageDetail.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvOutstorageDetail.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvOutstorageDetail.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvOutstorageDetail.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvOutstorageDetail.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_OutStorageDetailReport2)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvOutstorageDetail.Sort(m_dgvOutstorageDetail.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }

        private void m_rbtSingle_CheckedChanged(object sender, EventArgs e)
        {
            m_txtMedicineCode.Clear();
            m_txtMedicineCode.Tag = "";
            m_txtMedicineCode.Focus();
        }
    }
}