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
    /// 报废出库
    /// </summary>
    public partial class frmRejectOutStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        
        /// <summary>
        /// 报表名称
        /// </summary>
        internal string m_strReportName = string.Empty;
        
        /// <summary>
        /// 出库药品信息
        /// </summary>
        internal DataTable m_dtbOutMedicine = null;
        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// 出库主表序列
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 当前记录是否已审核        /// </summary>
        internal bool m_blnHasCommit = false;
        /// <summary>
        /// 报废原因
        /// </summary>
        internal clsMS_RejectReason[] m_objReasons = null;
        /// <summary>
        /// 是否审核即入帐        /// </summary>
        internal bool m_blnIsImmAccount = false;

        /// <summary>
        /// 保存出库数量
        /// </summary>
        internal double dblNetAmount;
        #endregion

        #region 构造函数
        /// <summary>
        /// 报废出库
        /// </summary>
        public frmRejectOutStorage()
        {
            InitializeComponent();

            //zhenwei.yang修改时间
            m_dtpInComeDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpInComeDate.Tag = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            m_dgvMedicineDetail.AutoGenerateColumns = false;

            ((clsCtl_RejectOutStorage)objController).m_mthInitMedicineTalbe(ref m_dtbOutMedicine);
            ((clsCtl_RejectOutStorage)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            m_dgvMedicineDetail.DataSource = m_dtbOutMedicine;

            m_mthInitJumpControls();
        }

        /// <summary>
        /// 报废出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmRejectOutStorage(string p_strStorageID,string p_strReportName)
            : this()
        {
            m_strReportName = p_strReportName;
            m_strStorageID = p_strStorageID;
            m_bgwGetData.RunWorkerAsync();
            ((clsCtl_RejectOutStorage)objController).m_mthGetCommitFlow(out m_intCommitFolow);

            ((clsCtl_RejectOutStorage)objController).m_mthGetAllRejectReason(out m_objReasons);
            ((clsCtl_RejectOutStorage)objController).m_mthAddReasonItems(m_dgvtxtRejectReason);
        }

        /// <summary>
        /// 报废出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMain">主表内容</param>
        /// <param name="p_objDetailArr">子表内容</param>
        /// <param name="p_intSelectedRow">子表选中行索引</param>
        public frmRejectOutStorage(string p_strStorageID,string p_strReportName, clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objDetailArr, int p_intSelectedRow)
            : this(p_strStorageID, p_strReportName)
        {
            ((clsCtl_RejectOutStorage)objController).m_mthSetOutStorageToUI(p_objMain, p_objDetailArr, p_intSelectedRow);
        }
        #endregion

        #region 事件
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage)objController).m_lngSaveOutStorageInfo();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("确定删除选中出库记录？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_RejectOutStorage)objController).m_mthDeleteDetail();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage)objController).m_mthPrint();
            
        }

        private void m_cmdNextBill_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtbOutMedicine != null)
            {
                drNull = m_dtbOutMedicine.Select("availagross_int is null and realgross_int is null");//选择无用的数据
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtbOutMedicine.Rows.Remove(drTemp);
                    }
                }

                DataTable dtbNew = m_dtbOutMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtbOutMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定清空并书写下一张单?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            ((clsCtl_RejectOutStorage)objController).m_mthClear();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Enter(object sender, EventArgs e)
        {
            m_dtpInComeDate.Focus();
            m_dtpInComeDate.SelectionStart = 0;
        }

        private void m_dgvMedicineDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (m_dgvMedicineDetail.ReadOnly) return;
            
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvMedicineDetail.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                ((clsCtl_RejectOutStorage)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineInfo);
                
                CancelJump = true;
            }
            else if(CurrentCell.ColumnIndex == 6)
            {
                //bool bolAdjustrice;
                //DataGridViewRow dgr = m_dgvMedicineDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex];
                //((clsCtl_RejectOutStorage)objController).m_mthGetAdjustrice(dgr.Cells[18].Value.ToString(), dgr.Cells[4].Value.ToString(), dgr.Cells[9].Value.ToString(), out bolAdjustrice);
                //if (bolAdjustrice)
                //{
                //    dgr.Cells[6].Value = dblNetAmount;
                //    MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //
                m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells[8];
                m_dgvMedicineDetail.CurrentCell.Selected = true;
                CancelJump = true;                
            }
            else if (CurrentCell.ColumnIndex == 8)
            {
                if (CurrentCell.RowIndex < m_dgvMedicineDetail.Rows.Count - 1)
                {
                    if (m_dgvMedicineDetail.Rows[CurrentCell.RowIndex + 1].Cells["m_dgvtxtCurrentAmount"].Value == DBNull.Value)
                    {
                        m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail.Rows[CurrentCell.RowIndex + 1].Cells[1];
                        
                    }
                    else
                    {
                        m_dgvMedicineDetail.CurrentCell = m_dgvMedicineDetail.Rows[CurrentCell.RowIndex + 1].Cells["m_dgvtxtRejectAmount"];
                        
                    }
                    m_dgvMedicineDetail.CurrentCell.Selected = true;
                }
                else
                {
                    ((clsCtl_RejectOutStorage)objController).m_mthInsertNewMedicineDate();
                }
                CancelJump = true;          
            }
        }

        private void frmRejectOutStorage_Load(object sender, EventArgs e)
        {
            

            if (m_dtbOutMedicine != null && m_dtbOutMedicine.Rows.Count == 0)
            {
                ((clsCtl_RejectOutStorage)objController).m_mthInsertNewMedicineDate();
            }
        }

        private void m_cmdInsertRecord_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage)objController).m_mthInsertNewMedicineDate();
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_RejectOutStorage)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void m_dgvMedicineDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineDetail.Rows.Count; iRow++)
            {
                m_dgvMedicineDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_RejectOutStorage)objController).m_mthCountMoney();
        }

        private void m_dgvMedicineDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMedicineDetail.Rows.Count; iRow++)
            {
                m_dgvMedicineDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_RejectOutStorage)objController).m_mthCountMoney();
        }

        private void m_dgvMedicineDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {

                DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;
                cbo.DropDownStyle = ComboBoxStyle.DropDown;

                ((clsCtl_RejectOutStorage)objController).m_mthAddReasonItems(cbo);
                cbo.KeyDown += new KeyEventHandler(cboColumn_KeyDown);
                cbo.Validating += new CancelEventHandler(cboColumn_Validating);
            }
        }

        private void cboColumn_Validating(object sender, CancelEventArgs e)
        {
            DataGridViewComboBoxEditingControl cbo = sender as DataGridViewComboBoxEditingControl;

            DataGridView grid = cbo.EditingControlDataGridView;

            object value = cbo.Text;

            if (cbo.Items.IndexOf(value) == -1)
            {

                DataGridViewComboBoxColumn cboCol = grid.Columns[grid.CurrentCell.ColumnIndex] as DataGridViewComboBoxColumn;
                cbo.Items.Add(value);
                cboCol.Items.Add(value);
                grid.CurrentCell.Value = value;

            }
        }

        private void cboColumn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && e.Control)
            {
                DataGridViewComboBoxEditingControl cbo = sender as DataGridViewComboBoxEditingControl;
                cbo.DroppedDown = true;
            }
        }

        private void m_dgvMedicineDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewDataErrorContexts objDEC = e.Context;

            string strSTEx = e.Exception.StackTrace;
            string strEx = e.Exception.Message;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 控件跳转及活动背景色
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();

            objCtl.m_mthSetControlHighLight(this, Color.Moccasin);
            objCtl.m_mthSelectAllText(this);
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_RejectOutStorage();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 添加报废原因项目
        /// </summary>
        /// <param name="p_strReasonItem">报废原因</param>
        internal void m_mthAddReasonItem(string p_strReasonItem)
        {
            if (m_dgvtxtRejectReason.Items.IndexOf(p_strReasonItem) == -1)
            {
                m_dgvtxtRejectReason.Items.Add(p_strReasonItem);
            }
        }
        #endregion

        private void m_dgvMedicineDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    double.TryParse(m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString(), out dblNetAmount);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void m_dgvMedicineDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["NETAMOUNT_INT"] == DBNull.Value)
                {
                    return;
                }
                if (e.ColumnIndex == 6 && Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["NETAMOUNT_INT"]) != dblNetAmount &&
                    m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineDetail.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex];
                    ((clsCtl_RejectOutStorage)objController).m_mthGetAdjustrice(m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
                        m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        //dgr.Cells[9].Value = dblNetAmount;
                        m_dtbOutMedicine.Rows[m_dgvMedicineDetail.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                        MessageBox.Show("该药品已调价,不能修改出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_dgvMedicineDetail.Focus();
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}