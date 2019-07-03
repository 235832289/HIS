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
    /// 期初数录入    /// </summary>
    public partial class frmInventoryRecord : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品录入信息
        /// </summary>
        internal DataTable m_dtbMedicineDetail = null;
        /// <summary>
        /// 当前筛选的记录
        /// </summary>
        internal DataView m_dtvCurrentView = null;
        /// <summary>
        /// 药品字典最小元素集信息
        /// </summary>
        private DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 是否默认批号
        /// </summary>
        internal bool m_blnIsSetDefaultBatchNumber = false;
        /// <summary>
        /// 当前仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 供应商信息
        /// </summary>
        private DataTable m_dtbVendor = null;
        /// <summary>
        /// 已在EnterKeyPress事件中作检查(检查价格时判断，避免重复)
        /// </summary>
        private bool m_blnHasKeyPressCheck = false;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// 药品中的批号,有效期录入控制
        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;
        /// <summary>
        /// 报表名称
        /// </summary>
        public string m_strReportName = string.Empty;
        #endregion

        #region 构造函数
        /// <summary>
        /// 期初数录入
        /// </summary>
        private frmInventoryRecord()
        {
            InitializeComponent();

            ((clsCtl_InventoryRecord)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
        }

        /// <summary>
        /// 期初数录入
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public frmInventoryRecord(string p_strStorageID,string p_strReportName)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_strReportName = p_strReportName;
            m_dtgvMedicineDetail.AutoGenerateColumns = false;
            m_mthSetUICannotEdit();
            m_pnlWaiting.Visible = true;
            m_cboCommitInfo.SelectedIndex = 0;

            m_dtgvMedicineDetail.ArriveLastColoumn += new com.digitalwave.controls.MedicineStoreControls.ArriveDataGridViewLastColoumn(m_dtgvMedicineDetail_ArriveLastColoumn);
            m_dtgvMedicineDetail.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(m_dtgvMedicineDetail_EnterKeyPress);
            m_bgwGetMedicineDetail.RunWorkerAsync();
        }
        #endregion

        #region 事件
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            m_lngSaveMedicineInfo(false);
        }

        private void m_cmdInsert_Click(object sender, EventArgs e)
        {
            m_mthInsertNewMedicine();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (m_dtgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            if (m_dtgvMedicineDetail.Rows[m_dtgvMedicineDetail.SelectedCells[0].RowIndex].ReadOnly)
            {
                MessageBox.Show("该行数据已审核，不能删除", "库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选定行？","库存初始化",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                m_mthDeleteSelecedMedicine();
            }
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_dtgvMedicineDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)//单价
            {
                if (m_blnHasKeyPressCheck)
                {
                    m_blnHasKeyPressCheck = false;
                    return;
                }
                bool CancelJump = false;
                ((clsCtl_InventoryRecord)objController).m_mthCheckPrice(m_dtgvMedicineDetail.CurrentCell, out CancelJump);
            }
        }

        /// <summary>
        /// 数据验证错误不作任何操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_dtgvMedicineDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_dtgvMedicineDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            #region 控件跳转
            CancelJump = false;
            m_dtgvMedicineDetail.EndEdit();
            if (CurrentCell.ColumnIndex == 0)//药品
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                m_mthShowQueryMedicineForm(strFilter);
            }
            else if (CurrentCell.ColumnIndex == 3)//检查数量
            {
                ((clsCtl_InventoryRecord)objController).m_mthCheckAmount(CurrentCell, out CancelJump);
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)//检查批号            {
                //MessageBox.Show(m_dtvCurrentView[CurrentCell.RowIndex]["lotno_int"].ToString());
                if ((CurrentCell.Value == null || string.IsNullOrEmpty(CurrentCell.Value.ToString())) && (m_dtvCurrentView[CurrentCell.RowIndex]["lotno_int"].ToString() == "1"))
                {
                    CancelJump = true;
                }

            }
            else if (CurrentCell.ColumnIndex == 6 || CurrentCell.ColumnIndex == 7 || CurrentCell.ColumnIndex == 8)//检查单价
            {
                m_blnHasKeyPressCheck = true;
                ((clsCtl_InventoryRecord)objController).m_mthCheckPrice(CurrentCell, out CancelJump);

                if (!CancelJump && CurrentCell.ColumnIndex == 6)
                {
                    m_dtvCurrentView[CurrentCell.RowIndex]["WholeSaleUnitPrice"] = m_dtvCurrentView[CurrentCell.RowIndex]["BugUnitPrice"];                    
                }
            }
            else if (CurrentCell.ColumnIndex == 9)//有效日期
            {
                DateTime dtmV = DateTime.Now;
                if (string.IsNullOrEmpty(CurrentCell.Value.ToString()))
                {
                    CurrentCell.Value = DateTime.Now.Date;
                }
                if (DateTime.TryParse(CurrentCell.Value.ToString(), out dtmV))
                {
                    if (dtmV.Date < DateTime.Now.Date)
                    {
                        CancelJump = true;
                    }
                }
                else
                {
                    CancelJump = true;
                }
            }
            else if (CurrentCell.ColumnIndex == 10)//供应商
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                m_mthShowQueryVendor(strFilter);
            } 
            #endregion
        }

        private void m_bgwGetMedicineDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            m_mthGetMedicineDetail();
            m_mthGetMedicineInfo();
            ((clsCtl_InventoryRecord)objController).m_mthGetVendor(out m_dtbVendor);
            ((clsCtl_InventoryRecord)objController).m_mthGetBatchNumberDefaultSetting(out m_blnIsSetDefaultBatchNumber);
        }

        private void m_bgwGetMedicineDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentView = new DataView(m_dtbMedicineDetail);
            m_dtgvMedicineDetail.DataSource = m_dtvCurrentView;

            if (m_dtvCurrentView != null && m_dtvCurrentView.Count == 0)
            {
                ((clsCtl_InventoryRecord)objController).m_mthInsertNewMedicine();
            }

            if (m_dtgvMedicineDetail.RowCount > 0)
            {
                m_dtgvMedicineDetail.Focus();
                m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[0, m_dtgvMedicineDetail.RowCount - 1];
                m_dtgvMedicineDetail.CurrentCell.Selected = true;
            }
            
            m_pnlWaiting.Visible = false;
            m_mthSetUICanEdit();

            m_mthSetCommitedReadOnly();

            ((clsCtl_InventoryRecord)objController).m_mthGetAllMoney();
        }

        private void m_dtgvMedicineDetail_ArriveLastColoumn()
        {
            DataView dtbSource = m_dtgvMedicineDetail.DataSource as DataView;
            if (dtbSource != null && dtbSource.Count > 0)
            {
                DataRowView drCurrent = dtbSource[m_dtgvMedicineDetail.CurrentCell.RowIndex];
                DataRow[] drArr = new DataRow[] { drCurrent.Row };

                if (!((clsCtl_InventoryRecord)objController).m_blnIsAllAvailabileVO(drArr, null))
                {
                    return;
                }

                ((clsCtl_InventoryRecord)objController).m_mthInsertNewMedicine();
            }
        }

        private void m_cmdRefresh_Click(object sender, EventArgs e)
        {
            if (((clsCtl_InventoryRecord)objController).m_blnHasUnSaveData())
            {
                DialogResult drResult = MessageBox.Show("有新添或已修改的数据未保存，刷新将会丢失这些数据，是否继续？", "库存初始化", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            m_mthRefreshMedicineDetail();
        }

        private void m_cmdCommit_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("是否进行审核？","库存初始化",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    m_mthCommitMedicineDetail();
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }                
            }            
        }

        private void m_bgwCommit_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }

            DataTable dtbSource = e.Argument as DataTable;
            if (dtbSource == null)
            {
                return;
            }

            long lngRes = ((clsCtl_InventoryRecord)objController).m_lngCommitToStorageDetail(dtbSource);
            e.Result = lngRes;
        }

        private void m_bgwCommit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_pnlWaiting.Visible = false;
            this.label14.Text = "正在获取数据，请稍候..........";

            m_mthSetUICanEdit();
            m_cmdPrint.Enabled = true;
            m_cmdClose.Enabled = true;
            groupBox1.Enabled = true;

            long lngRes = (long)e.Result;
            if (lngRes > 0)
            {
                System.Windows.Forms.MessageBox.Show("审核完成", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else if (lngRes == 0)
            {
                MessageBox.Show("没有需审核的记录", "原始库存初始化",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("审核失败", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            if (lngRes != 0)
            {
                m_mthRefreshMedicineDetail();
            }            
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_InventoryRecord)objController).m_mthPrintMedicineDetail(this.m_strReportName);
        }

        private void TextFilter_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_InventoryRecord)objController).m_mthFilter();
            m_mthSetCommitedReadOnly();
        }

        private void m_cboCommitInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_dtbMedicineDetail != null && m_dtvCurrentView != null)
            {
                ((clsCtl_InventoryRecord)objController).m_mthFilter();
                m_mthSetCommitedReadOnly();
            }
        }

        private void frmInventoryRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((clsCtl_InventoryRecord)objController).m_blnHasUnSaveData())
            {
                DialogResult drResult = MessageBox.Show("有新添或已修改的数据未保存，仍然关闭本窗体？","库存初始化",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            ((clsCtl_InventoryRecord)objController).m_mthUnCommit();
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_InventoryRecord)objController).m_mthInAccount();
        }
        
        private void m_dtgvMedicineDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dtgvMedicineDetail.Rows.Count; iRow++)
            {
                if (m_dtgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtStatus"].Value.ToString() == "已审核"
                    || m_dtgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtStatus"].Value.ToString() == "已入帐")
                {
                    m_dtgvMedicineDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    m_dtgvMedicineDetail.Rows[iRow].DefaultCellStyle.BackColor = SystemColors.Info;
                }
            }
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            if (m_dtbMedicineDetail.Rows.Count == 0)
            {
                MessageBox.Show("没有需要导出的数据","库存初始化",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            ((clsCtl_InventoryRecord)objController).m_mthExportToExcel();
        }
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_InventoryRecord();
            objController.Set_GUI_Apperance(this);
        }

        #region 插入新药品信息
        /// <summary>
        /// 插入新药品信息
        /// </summary>
        private void m_mthInsertNewMedicine()
        {
            ((clsCtl_InventoryRecord)objController).m_mthInsertNewMedicine();
        } 
        #endregion

        #region 显示药品字典查询窗体
        /// <summary>
        /// 显示药品字典查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        private void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {            
            ((clsCtl_InventoryRecord)objController).m_mthShowQueryMedicineForm(p_strSearchCon, m_dtbMedicineInfo);
        }
        #endregion

        #region 获取已录入药品信息
        /// <summary>
        /// 获取已录入药品信息
        /// </summary>
        private void m_mthGetMedicineDetail()
        {
            ((clsCtl_InventoryRecord)objController).m_lngGetMedicineDetail(m_strStorageID, out m_dtbMedicineDetail);
            if (m_dtbMedicineDetail == null || m_dtbMedicineDetail.Columns.Count == 0)
            {
                ((clsCtl_InventoryRecord)objController).m_mthInitMedicineTalbe(ref m_dtbMedicineDetail);
            }
        }
        #endregion

        #region 获取药品最小元素集信息
        /// <summary>
        /// 获取药品最小元素集信息
        /// </summary>
        private void m_mthGetMedicineInfo()
        {
            ((clsCtl_InventoryRecord)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
        }
        #endregion

        #region 删除选定的药品
        /// <summary>
        /// 删除选定的药品
        /// </summary>
        private void m_mthDeleteSelecedMedicine()
        {
            if (m_dtgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_dtgvMedicineDetail.SelectedCells[0].RowIndex;
            DataRowView drSelected = m_dtvCurrentView[intRowIndex];

            if (drSelected["SERIESID"] == DBNull.Value)//未保存进数据库的数据
            {
                if (intRowIndex == m_dtgvMedicineDetail.Rows.Count - 1 && intRowIndex - 1 >= 0)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex - 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                else if (intRowIndex + 1 < m_dtgvMedicineDetail.Rows.Count) 
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex + 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                m_dtvCurrentView.Delete(intRowIndex);
            }
            else if (((clsCtl_InventoryRecord)objController).m_lngDeleteMedicineInitial(Convert.ToInt64(drSelected["SERIESID"])) > 0)//已保存进数据库的数据
            {
                if (intRowIndex == m_dtgvMedicineDetail.Rows.Count - 1 && intRowIndex - 1 >= 0)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex - 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                else if (intRowIndex + 1 < m_dtgvMedicineDetail.Rows.Count) 
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex + 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                m_dtvCurrentView.Delete(intRowIndex);

                if (m_dtgvMedicineDetail.Rows.Count == 0)
                {
                    m_mthInsertNewMedicine();
                }
            }            
        } 
        #endregion

        #region 使界面不可编辑
        /// <summary>
        /// 使界面不可编辑
        /// </summary>
        private void m_mthSetUICannotEdit()
        {
            m_cmdSave.Enabled = false;
            m_cmdInsert.Enabled = false;
            m_cmdDelete.Enabled = false;
            m_cmdRefresh.Enabled = false;
            m_cmdCommit.Enabled = false;
            m_cmdExitAuditing.Enabled = false;
            m_cmdInAccount.Enabled = false;
        } 
        #endregion

        #region 使界面可编辑
        /// <summary>
        /// 使界面可编辑
        /// </summary>
        private void m_mthSetUICanEdit()
        {
            m_cmdSave.Enabled = true;
            m_cmdInsert.Enabled = true;
            m_cmdDelete.Enabled = true;
            m_cmdRefresh.Enabled = true;
            m_cmdCommit.Enabled = true;
            m_cmdExitAuditing.Enabled = true;
            m_cmdInAccount.Enabled = true;
        } 
        #endregion

        #region 保存药品信息
        /// <summary>
        /// 保存药品信息
        /// </summary>
        /// <param name="p_blnIsCommit">是否审核前保存</param>
        private long m_lngSaveMedicineInfo(bool p_blnIsCommit)
        {
            m_dtgvMedicineDetail.EndEdit();
            long lngRes = ((clsCtl_InventoryRecord)objController).m_lngSaveMedicineInfo(p_blnIsCommit);
            if (lngRes > 0)
            {
                ((clsCtl_InventoryRecord)objController).m_mthGetAllMoney(); 
            }
            return lngRes;
        }
        #endregion

        #region 刷新已录入药品信息
        /// <summary>
        /// 刷新已录入药品信息
        /// </summary>
        private void m_mthRefreshMedicineDetail()
        {
            m_pnlWaiting.Visible = true;

            m_txtCommitMan.Text = string.Empty;
            m_txtInputMan.Text = string.Empty;
            m_txtMedicineID.Text = string.Empty;
            m_cboCommitInfo.SelectedIndex = 0;

            m_mthSetUICannotEdit();
            m_mthGetMedicineDetail();
            m_dtvCurrentView = new DataView(m_dtbMedicineDetail);
            m_dtgvMedicineDetail.DataSource = m_dtvCurrentView;
            if (m_dtgvMedicineDetail.RowCount > 0)
            {
                m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[0, m_dtgvMedicineDetail.RowCount - 1];
            }
            m_mthSetUICanEdit();
            m_mthSetCommitedReadOnly();
            m_pnlWaiting.Visible = false;
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        private void m_mthCommitMedicineDetail()
        {
            long lngRes = m_lngSaveMedicineInfo(true);
            if (lngRes < 0)
            {
                return;
            }

            DataView dtbSource = m_dtgvMedicineDetail.DataSource as DataView;
            DataTable dtbTemp = dtbSource.Table;

            m_pnlWaiting.Visible = true;
            this.label14.Text = "正在审核，请稍候..........";

            m_mthSetUICannotEdit();
            m_cmdPrint.Enabled = false;
            m_cmdClose.Enabled = false;
            groupBox1.Enabled = false;

            if (!m_bgwCommit.IsBusy)
            {
                m_bgwCommit.RunWorkerAsync(dtbTemp);
            }
        }
        #endregion

        #region 显示代言商查询
        /// <summary>
        /// 显示代言商查询
        /// </summary>
        /// <param name="p_strFilter">查询条件</param>
        private void m_mthShowQueryVendor(string p_strFilter)
        {
            ((clsCtl_InventoryRecord)objController).m_mthShowVendor(p_strFilter, m_dtbVendor);
        } 
        #endregion



        #region 设置已审核为只读
        /// <summary>
        /// 设置已审核为只读
        /// </summary>
        private void m_mthSetCommitedReadOnly()
        {
            for (int iRow = 0; iRow < m_dtgvMedicineDetail.Rows.Count; iRow++)
            {
                if (m_dtgvMedicineDetail.Rows[iRow].Cells["m_dgvtxExamer"].Value != DBNull.Value)
                {
                    m_dtgvMedicineDetail.Rows[iRow].ReadOnly = true;
                }
            }
        } 
        #endregion

        //private void m_dtgvMedicineDetail_EnterKeyPress_1(DataGridViewCell CurrentCell, out bool CancelJump)
        //{
        //    if (CurrentCell.ColumnIndex == 5)
        //    {
        //        DataRow[] drOld = m_dtbMedicineDetail.Select("MedicineCode = '" + m_dtgvMedicineDetail.Rows[m_dtgvMedicineDetail.CurrentCell.RowIndex].Cells[0].Value + "' and BatchNumber = '" + CurrentCell.EditedFormattedValue.ToString() + "'");
        //        if (drOld != null && drOld.Length > 0)
        //        {
        //            MessageBox.Show("已选择此药，不能重复设置", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //CurrentCell.Value = "";
        //        }
        //    }
        //    CancelJump = true;
        //}

        #endregion
    }
}