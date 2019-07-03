using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品盘点
    /// </summary>
    public partial class frmStorageCheck: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品盘点
        /// </summary>
        private frmStorageCheck()
        {
            InitializeComponent();
            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;

            ((clsCtl_StorageCheck)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_StorageCheck)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
        }

        /// <summary>
        /// 药品盘点
        /// </summary>
        /// <param name="p_strStroageCheck">仓库ID</param>
        public frmStorageCheck(string p_strStroageCheck)
            : this()
        {
            m_strStorageID = p_strStroageCheck;
        } 
        #endregion

        public override void CreateController()
        {
            this.objController = new clsCtl_StorageCheck();
            objController.Set_GUI_Apperance(this);
        }

        #region 事件
        private void frmStorageCheck_Load(object sender, EventArgs e)
        {
            m_dtpBeginDatePage1.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            m_dtpEndDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_cboType.SelectedIndex = 0;

            ((clsCtl_StorageCheck)this.objController).m_mthGetStorageCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthGetStorageCheck();
        }

        private void m_dgvMainInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthGetStorageCheck_detail();
        }

        private void m_cmdDeletePage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthDeleteCheckStorage();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdAddNewPage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthFrmStoDetail(0);
        }

        private void m_cmdModifyPage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthFrmStoDetail(1);
        }

        private void m_cmdCommitPage1_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthCommitStorageCheck();
        }

        private void m_cmdUnCommitPage1_Click(object sender, EventArgs e)
        {
        }

        private void m_dgvMainInfo_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthFrmStoDetail(1);
        }

        private void m_dgvSubInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
            {
                m_dgvSubInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_txtChickID_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthSetDataToUI();
        }

        private void m_cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthSetDataToUI();
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageCheck)this.objController).m_mthInAccount();
        } 
        #endregion
    }
}