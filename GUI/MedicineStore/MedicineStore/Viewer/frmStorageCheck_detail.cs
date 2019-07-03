using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品盘点
    /// </summary>
    public partial class frmStorageCheck_detail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 主表记录
        /// </summary>
        internal clsMS_StorageCheck_VO m_objMain = null;
        /// <summary>
        /// 明细表记录        /// </summary>
        public DataTable dtbStorageCheck_detail=null;
        /// <summary>
        /// 窗体显示类型０：新制,１：修改
        /// </summary>
        public int intShowType = 0;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// 盘点主表序列号
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        #endregion

        #region 药品盘点
        /// <summary>
        /// 药品盘点
        /// </summary>
        public frmStorageCheck_detail(string p_strStorageID)
        {
            InitializeComponent();
            m_dgvDetailInfo.AutoGenerateColumns = false;
            m_txtCreator.Tag = LoginInfo.m_strEmpID;
            m_txtCreator.Text = LoginInfo.m_strEmpName;
            m_dtpCheckDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            m_strStorageID = p_strStorageID;

            m_bgwGetData.RunWorkerAsync();
        } 
        #endregion

        public override void CreateController()
        {
            this.objController = new clsCtl_StorageCheck_detail();
            objController.Set_GUI_Apperance(this);
        }

        private void frmStorageCheck_detail_Load(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck_detail)this.objController).m_mthGetCommitFlow(out m_intCommitFolow);
            ((clsCtl_StorageCheck_detail)this.objController).m_mthLoad();

        }

        private void m_dgvDetailInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_cmdGetMedicine_Click(object sender, EventArgs e)
        {
            frmGetStorageCheckMedicine frmGet = new frmGetStorageCheckMedicine(m_strStorageID);
            frmGet.ShowDialog();

            DataTable dtbSearchResult = null;
            if (frmGet.DialogResult == DialogResult.OK)
            {
                dtbSearchResult = frmGet.m_DtbStorageMedicine;

                ((clsCtl_StorageCheck_detail)this.objController).m_mthMergeDataToUI(dtbSearchResult);
            }
        }

        private void m_dgvDetailInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetailInfo.Rows.Count; iRow++)
            {
                m_dgvDetailInfo.Rows[iRow].Cells[0].Value = iRow + 1;
                if (m_dgvDetailInfo.Rows[iRow].Cells[6].Value != null && !string.IsNullOrEmpty(m_dgvDetailInfo.Rows[iRow].Cells[6].Value.ToString()))
                {
                    m_dgvDetailInfo.Rows[iRow].Cells[2].ReadOnly = true;
                }
            }
            ((clsCtl_StorageCheck_detail)this.objController).m_mthSetCheckMoney();
        }

        private void m_dgvDetailInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetailInfo.Rows.Count; iRow++)
            {
                m_dgvDetailInfo.Rows[iRow].Cells[0].Value = iRow + 1;
                if (m_dgvDetailInfo.Rows[iRow].Cells[6].Value != null && !string.IsNullOrEmpty(m_dgvDetailInfo.Rows[iRow].Cells[6].Value.ToString()))
                {
                    m_dgvDetailInfo.Rows[iRow].Cells[2].ReadOnly = true;
                }
            }
            ((clsCtl_StorageCheck_detail)this.objController).m_mthSetCheckMoney();
        }

        private void m_cmdAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                long lngRes = ((clsCtl_StorageCheck_detail)this.objController).m_lngSaveDetail();

                if (lngRes > 0)
                {
                    MessageBox.Show("保存成功", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drResult = MessageBox.Show("确定删除选定记录？", "药品盘点", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_StorageCheck_detail)this.objController).m_mthDeleteStorageCheck();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_dgvDetailInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dgvDetailInfo.CurrentCell != null && e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["CHECKGROSS_INT"].ColumnIndex)
            {
                try
                {
                    double dblTemp = 0d;
                    double dblRealGross = Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["CURRENTGROSS_INT"].Value);
                    DataRow drCurrent = ((DataRowView)m_dgvDetailInfo.Rows[e.RowIndex].DataBoundItem).Row;
                    if (double.TryParse(m_dgvDetailInfo.CurrentCell.Value.ToString(), out dblTemp))
                    {
                        if (dblTemp < 0)
                        {
                            MessageBox.Show("实际数量不能小于零","药品盘点",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            m_dgvDetailInfo.Focus();
                            drCurrent["CHECKGROSS_INT"] = dblRealGross.ToString("0.00");
                            drCurrent["CHECKRESULT_INT"] = 0;
                        }
                        else
                        {
                            drCurrent["CHECKRESULT_INT"] = (dblTemp - dblRealGross).ToString("0.00");
                        }
                        ((clsCtl_StorageCheck_detail)this.objController).m_mthSetCheckMoney();                       
                    }
                    else
                    {
                        MessageBox.Show("实际数量不能为空且只能为数字", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_dgvDetailInfo.Focus();
                        drCurrent["CHECKGROSS_INT"] = dblRealGross.ToString("0.00");
                        drCurrent["CHECKRESULT_INT"] = 0;
                        ((clsCtl_StorageCheck_detail)this.objController).m_mthSetCheckMoney();
                    }
                    drCurrent.EndEdit();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }                             
            }
        }

        private void m_dgvDetailInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strEx = e.Exception.Message;
        }

        private void m_txtCreator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_StorageCheck_detail)this.objController).m_mthSetEmpToList(m_txtCreator.Text, m_txtCreator);
            }
        }

        private void m_dgvDetailInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvDetailInfo.EndEdit();

            if (CurrentCell.ColumnIndex == 2)
            {
                string strSearch = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strSearch = CurrentCell.Value.ToString();
                }
                ((clsCtl_StorageCheck_detail)this.objController).m_mthShowQueryMedicineForm(strSearch, m_dtbMedicineInfo);
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 7)
            {
                CancelJump = true;
                try
                {
                    m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex].Cells[9];
                    m_dgvDetailInfo.CurrentCell.Selected = true;
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }                
            }
            else if (CurrentCell.ColumnIndex == 9)
            {
                CancelJump = true;
                if (CurrentCell.RowIndex < m_dgvDetailInfo.Rows.Count - 1)
                {
                    if (m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells[3].Value == DBNull.Value)
                    {
                        m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells[2];
                        m_dgvDetailInfo.CurrentCell.Selected = true;
                    }
                    else
                    {
                        m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells[7];
                        m_dgvDetailInfo.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_StorageCheck_detail)this.objController).m_mthInsertNewMedicineData();
                }
            }
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_StorageCheck_detail)this.objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
        }

        private void m_cmdInsertRecord_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck_detail)this.objController).m_mthInsertNewMedicineData();
        }

        private void frmStorageCheck_detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            //去除空行
            DataRow[] drNull = dtbStorageCheck_detail.Select("MEDICINEID_CHR is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    dtbStorageCheck_detail.Rows.Remove(dr);
                }
            }

            DataTable dtbNew = dtbStorageCheck_detail.GetChanges(DataRowState.Added);
            DataTable dtbEdit = dtbStorageCheck_detail.GetChanges(DataRowState.Modified);
            if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
            {
                DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定退出?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void m_txtLocalize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ((clsCtl_StorageCheck_detail)this.objController).m_mthLocalizeRow(m_txtLocalize.Text);
                ((clsCtl_StorageCheck_detail)this.objController).m_mthShowQueryMedicineForm_lock(m_txtLocalize.Text, m_dtbMedicineInfo);
                ((clsCtl_StorageCheck_detail)this.objController).m_mthLocalizeRow(m_txtLocalize.Text);
            }
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck_detail)this.objController).m_mthPrint(dtbStorageCheck_detail.DefaultView.ToTable());
            
        }

        private void m_cmdFilter_Click(object sender, EventArgs e)
        {
            frmGetStorageCheckMedicine frmGet = new frmGetStorageCheckMedicine(true);
            frmGet.ShowDialog();

            if (frmGet.DialogResult == DialogResult.OK)
            {
                string strFilter = frmGet.m_StrSearchCondition;
                if (dtbStorageCheck_detail != null)
                {
                    dtbStorageCheck_detail.DefaultView.RowFilter = strFilter;
                }
            }
        }

        private void m_chkOnlyShowGrossChange_CheckedChanged(object sender, EventArgs e)
        {
            
            if (dtbStorageCheck_detail != null)
            {
                string strSubcheck = "";
                if (m_chkOnlyShowGrossChange.Checked)
                {
                    strSubcheck = "CHECKRESULT_INT <> 0";
                }
                if (m_chkOnlyShowCURRENTGROSS.Checked)
                {
                    if (strSubcheck.Length > 3)
                    {
                        strSubcheck += " and " + "CURRENTGROSS_INT <> 0";
                    }
                    else
                    {
                        strSubcheck = "CURRENTGROSS_INT <> 0";
                    }
                }

                if (strSubcheck.Length > 3)
                {
                    dtbStorageCheck_detail.DefaultView.RowFilter = strSubcheck;;
                }
                else
                {
                    dtbStorageCheck_detail.DefaultView.RowFilter = string.Empty;
                }
            }            
        }

        private void m_cmdMissMedicine_Click(object sender, EventArgs e)
        {
            frmGetMissStorageCheckMedicine frmMiss = new frmGetMissStorageCheckMedicine(dtbStorageCheck_detail, m_strStorageID);
            frmMiss.ShowDialog();

            if (frmMiss.DialogResult == DialogResult.OK)
            {
                DataRow[] drSelectedMiss = frmMiss.m_DrGetSelected;
                if (drSelectedMiss == null || drSelectedMiss.Length == 0)
                {
                    return;
                }

                DataTable dtbStorageMedicine = drSelectedMiss[0].Table.Clone();
                dtbStorageMedicine.BeginLoadData();
                for (int iRow = 0; iRow < drSelectedMiss.Length; iRow++)
                {
                    dtbStorageMedicine.LoadDataRow(drSelectedMiss[iRow].ItemArray,true);
                }
                dtbStorageMedicine.EndLoadData();

                ((clsCtl_StorageCheck_detail)this.objController).m_mthMergeDataToUI(dtbStorageMedicine);
            }
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck_detail)this.objController).ExportDataGridViewToExcel(m_dgvDetailInfo);
        }

        private void m_chkOnlyShowCURRENTGROSS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_dgvDetailInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvDetailInfo.Rows[e.RowIndex];
            if (dgr.Cells[5].Value.ToString() == "UNKNOWN")
            {
                dgr.Cells[5].Value = "";
            }
        }

        private void m_txtLocalize_Enter(object sender, EventArgs e)
        {
            
        }

        private void m_txtLocalize_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtLocalize.SelectAll();
        }

   
    }
}