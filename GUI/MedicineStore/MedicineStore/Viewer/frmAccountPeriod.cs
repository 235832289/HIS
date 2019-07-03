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
    /// 帐务期结转

    /// </summary>
    public partial class frmAccountPeriod : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 帐务期结转数据

        /// </summary>
        internal DataTable m_dtbAccountData = null; 
        #endregion

        /// <summary>
        /// 帐务期结转

        /// </summary>
        private frmAccountPeriod()
        {
            InitializeComponent();
            m_dgvAccountData.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 帐务期结转

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmAccountPeriod(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;

            m_bgwGetData.RunWorkerAsync();
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_AccountPeriod();
            objController.Set_GUI_Apperance(this);
        }

        private void m_cmdAccount_Click(object sender, EventArgs e)
        {
            DateTime dtmBeginDate = ((clsCtl_AccountPeriod)objController).m_dtmGetBeginDate();
            if (dtmBeginDate == DateTime.MinValue)
            {
                MessageBox.Show("获取帐务期结转开始时间失败", "帐务期结转", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            frmAccount frmAcc = new frmAccount(m_strStorageID, dtmBeginDate);
            frmAcc.FormClosed += new FormClosedEventHandler(frmAcc_FormClosed);
            frmAcc.ShowDialog();
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_AccountPeriod)objController).m_mthGetAccountPeriodData();
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dgvAccountData.DataSource = m_dtbAccountData;
        }

        private void m_dgvAccountData_DoubleClick(object sender, EventArgs e)
        {
            clsMS_AccountPeriodVO objAP = ((clsCtl_AccountPeriod)objController).m_objGetAccount();
            if (objAP == null)
            {
                return;
            }

            frmAccount frmAcc = new frmAccount(m_strStorageID,objAP);
            frmAcc.FormClosed += new FormClosedEventHandler(frmAcc_FormClosed);
            frmAcc.ShowDialog();
        }

        private void frmAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAccount frmAcc = sender as frmAccount;
            if (frmAcc == null)
            {
                return;
            }

            if (!m_bgwGetData.IsBusy)
            {
                m_bgwGetData.RunWorkerAsync();
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("确认取消结转？","帐务期结转",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                ((clsCtl_AccountPeriod)objController).m_mthCancelAccount();
            }            
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_AccountPeriod)objController).m_mthPrint();
            
        }

        private void frmAccountPeriod_Load(object sender, EventArgs e)
        {

        }
    }
}