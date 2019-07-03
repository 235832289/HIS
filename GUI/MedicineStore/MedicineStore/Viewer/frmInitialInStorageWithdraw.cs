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
    /// 内退初始化
    /// </summary>
    public partial class frmInitialInStorageWithdraw : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        public string m_strMakName;
        /// <summary>
        /// 内退药品信息
        /// </summary>
        internal DataTable m_dtbWithdrawMedicine = null;
        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// 审核流程(0,保存后由药库管理角色审核 1,保存后立即审核)
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// 出库主表序列
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 当前记录是否已审核
        /// </summary>
        internal bool m_blnHasCommit = false;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        #endregion

        /// <summary>
        /// 内退初始化
        /// </summary>
        private frmInitialInStorageWithdraw()
        {
            InitializeComponent();

            DataTable dtbDept = null;
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthGetExportDept(out dtbDept);
            m_txtWithdrawDept.m_mthInitDeptData(dtbDept);

            m_dgvInitialData.AutoGenerateColumns = false;
            m_dtpTransactDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            m_txtWithdrawDept.Focus();
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthInitMedicineTable(ref m_dtbWithdrawMedicine);
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            m_dgvInitialData.DataSource = m_dtbWithdrawMedicine;
        }

        /// <summary>
        /// 内退初始化
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmInitialInStorageWithdraw(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_bgwGetData.RunWorkerAsync();

            ((clsCtl_InitialInStorageWithdraw)objController).m_mthGetCommitFlow(out m_intCommitFolow);
        }

        /// <summary>
        /// 内退初始化
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmInitialInStorageWithdraw(string p_strStorageID, clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr)
            : this(p_strStorageID)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthSetMedicineDetailToUI(p_objISVO, p_objDetailArr);
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_InitialInStorageWithdraw();
            objController.Set_GUI_Apperance(this);
        }

        #region 事件
        private void frmInitialInStorageWithdraw_Load(object sender, EventArgs e)
        {
            if (m_dgvInitialData.Rows.Count == 0)
            {
                ((clsCtl_InitialInStorageWithdraw)objController).m_mthInsertNewMedicine();
            }            
        }

        private void m_dgvInitialData_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_dgvInitialData_EnterKeyPress(CurrentCell, out CancelJump);
        }

        private void m_txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbWithdrawMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtbWithdrawMedicine.Rows[m_dtbWithdrawMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                    {
                        m_dgvInitialData.Focus();
                        m_dgvInitialData.CurrentCell = m_dgvInitialData.Rows[m_dtbWithdrawMedicine.Rows.Count - 1].Cells[1];
                        m_dgvInitialData.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_InitialInStorageWithdraw)objController).m_mthInsertNewMedicine();
                }
            }
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_lngSaveWithDraw(m_strMakName);
        }

        private void m_cmdInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthInsertNewMedicine();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthDeleteWintdrawDetail();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
             ((clsCtl_InitialInStorageWithdraw)objController).m_mthOutStorageReport(m_strStorageID, m_strMakName);
             
        }

        private void m_cmdNextBill_Click(object sender, EventArgs e)
        {
            if (m_dtbWithdrawMedicine != null && panel1.Enabled)
            {
                DataTable dtbNew = m_dtbWithdrawMedicine.GetChanges(DataRowState.Added);
                DataTable dtbModify = m_dtbWithdrawMedicine.GetChanges(DataRowState.Modified);

                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbModify != null && dtbModify.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定清空并书写下一张单?", "内退初始化", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            ((clsCtl_InitialInStorageWithdraw)objController).m_mthClear();
            m_txtWithdrawDept.Focus();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthInitMedicineInfo(ref m_dtbMedicineDict);
        }

        private void m_txtWithdrawDept_FocusNextControl(object sender, EventArgs e)
        {
            m_txtVendor.Focus();
        }

        private void m_dgvInitialData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvInitialData.Rows.Count; iRow++)
            {
                m_dgvInitialData.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthCountMoney();
        }

        private void m_dgvInitialData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvInitialData.Rows.Count; iRow++)
            {
                m_dgvInitialData.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_InitialInStorageWithdraw)objController).m_mthCountMoney();
        }

        private void m_dgvInitialData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_InitialInStorageWithdraw)objController).m_mthShowVendor(m_txtVendor.Text);
            }
        }
        #endregion

        private void m_dgvInitialData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}