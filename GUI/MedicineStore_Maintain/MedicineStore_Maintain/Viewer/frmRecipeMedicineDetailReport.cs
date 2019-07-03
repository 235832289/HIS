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
    public partial class frmRecipeMedicineDetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private string[] strStorageArr;
        internal DataTable m_dtMedince;
        internal DataTable m_dtStorageName;
        public frmRecipeMedicineDetailReport()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_RecipeMedicineDetailReport();
            objController.Set_GUI_Apperance(this);
        }

        public void m_mthShow(string p_strStorageid)
        {
            strStorageArr = p_strStorageid.Split('*');
            this.Show();
        }

        private void frmRptInstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvMedDetail.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.SysDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpSearchEndDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthInit();
            ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthGetStorageName(out m_dtStorageName);
           
            if (m_dtStorageName.Rows.Count > 0)
            {
                if (strStorageArr != null && strStorageArr.Length > 0)
                {
                    this.m_cboStorageName.Items.Clear();

                    for (int i1 = 0; i1 < strStorageArr.Length; i1++)
                    {
                        for (int j2 = 0; j2 < m_dtStorageName.Rows.Count; j2++)
                        {
                            if (m_dtStorageName.Rows[j2]["storageid_chr"].ToString() == strStorageArr[i1].ToString())
                            {
                                this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[j2]["storagename_vchr"].ToString(), m_dtStorageName.Rows[j2]["storageid_chr"].ToString());
                            }
                        }
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboStorageName.Items.Clear();

                    this.m_cboStorageName.Item.Add("全部", "0000");

                    for (int k = 0; k < m_dtStorageName.Rows.Count; k++)
                    {
                        this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[k]["storagename_vchr"].ToString(), m_dtStorageName.Rows[k]["storageid_chr"].ToString());
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
            }            

            this.Text = "处方药品明细查询(" + m_cboStorageName.Text + ")";
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthSearch();
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

        private void m_txtMedicineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthSearch();
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtMedince == null || m_dtMedince.Rows.Count == 0)
                {
                    ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthGetMedBaseInfo(m_cboStorageName.SelectItemValue, out m_dtMedince);
                }
                ((clsCtl_RecipeMedicineDetailReport)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
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

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineCode.Text.Trim() == "")
                m_txtMedicineCode.Tag = "";
        }

        private void m_dgvMedDetail_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvMedDetail.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvMedDetail.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void m_cboStorageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "处方药品明细查询(" + m_cboStorageName.Text + ")";
        }

        private void m_dgvMedDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvMedDetail.DataSource == null) return;
            DataTable dt = this.m_dgvMedDetail.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvMedDetail.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvMedDetail.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvMedDetail.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvMedDetail.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RecipeMedicineDetailReport)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvMedDetail.Sort(m_dgvMedDetail.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }
    }
}