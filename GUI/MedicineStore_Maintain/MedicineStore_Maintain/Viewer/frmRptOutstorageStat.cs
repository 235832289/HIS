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
    public partial class frmRptOutstorageStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmRptOutstorageStat()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_RptOutstorageStat();
            this.objController.Set_GUI_Apperance(this);
        }

        internal DataTable m_dtProduct;

        /// <summary>
        /// 是否药房使用，0否，1是
        /// </summary>
        internal bool m_blnForDrugStore = false;
        private DataTable dtTemp;

        internal string[] m_strRoomidArr;
        /// <summary>
        /// 药库使用
        /// </summary>
        public void m_mthShow(string p_strStorageid)
        {
            m_strRoomidArr = p_strStorageid.Split('*');
            this.Text = "药库出库统计";
            this.Show();
        }

        /// <summary>
        /// 药房使用
        /// </summary>
        public void m_mthShowThis(string p_strRoomid)
        {
            m_strRoomidArr = p_strRoomid.Split('*');
            ((clsCtl_RptOutstorageStat)this.objController).m_mthGetRoomid(out dtTemp);
            if (m_strRoomidArr.Length > 0)
            {
                int iRowCount = dtTemp.Rows.Count;
                DataRow dr = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    dr = dtTemp.Rows[i];
                    for (int j = 0; j < m_strRoomidArr.Length; j++)
                    {
                        if (m_strRoomidArr[j].ToString().Trim() == dr["medstoreid_chr"].ToString().Trim())
                        {
                            m_strRoomidArr[j] = dr["deptid_chr"].ToString();
                        }
                    }
                }
            }
            this.Text = "药房出库统计";
            m_blnForDrugStore = true;
            this.Show();
        }

        private void frmRptOutstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvOutstorage.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.SysDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpSearchEndDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            ((clsCtl_RptOutstorageStat)this.objController).m_mthInit();            
            ((clsCtl_RptOutstorageStat)this.objController).m_mthChooseMedType();
            DataTable dtbDept = null;
            ((clsCtl_RptOutstorageStat)objController).m_mthGetExportDept(out dtbDept);
            m_txtDept.m_mthInitDeptData(dtbDept);

            this.Text = "出库统计报表(" + txtStoreroom.Text + ")";
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStoreroom.Value))
            {
                MessageBox.Show(this, "请选择库房！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStoreroom.Focus();
                return;
            }
            ((clsCtl_RptOutstorageStat)this.objController).m_mthSearch();
        }

        private void txtStoreroom_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
            ((clsCtl_RptOutstorageStat)this.objController).m_mthChooseMedType();

            this.Text = "出库统计报表(" + txtStoreroom.Text + ")";
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dw, true);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptOutstorageStat)objController).m_mthShowMedince(m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_txtMedicineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((clsCtl_RptOutstorageStat)objController).m_mthShowMedince(m_txtMedicineCode.Text.Trim());
        }

        private void m_dtpSearchBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ((clsCtl_RptOutstorageStat)objController).m_mthShowManufacturer(this.txtProduct.Text.Trim());
            //}
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
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
            if (this.m_dgvOutstorage.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvOutstorage);
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.dw);
        }

        private void m_dgvOutstorage_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvOutstorage.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvOutstorage.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void m_dgvOutstorage_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvOutstorage.DataSource == null) return;
            DataTable dt = this.m_dgvOutstorage.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvOutstorage.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvOutstorage.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvOutstorage.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvOutstorage.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptOutstorageStat)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvOutstorage.Sort(m_dgvOutstorage.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }
    }
}