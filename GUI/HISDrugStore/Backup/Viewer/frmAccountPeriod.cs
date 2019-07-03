using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ�������ڽ�ת����
    /// </summary>
    public partial class frmAccountPeriod : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// ���캯��
        /// </summary>
        public frmAccountPeriod()
        {
            InitializeComponent();
            this.m_dgvAccountPeriod.AutoGenerateColumns = false;
        }
        /// <summary>
        /// ��д���෽��
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AccountPeriod();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// ҩ����Ӧ����id
        /// </summary>
        internal string m_strDrugStoreid;
        /// <summary>
        /// ��ǰҩ����Ϣ��Ϣ
        /// </summary>
        internal clsMedStore_VO m_objMedStoreInfo;
        /// <summary>
        /// �����ڽ�ת����
        /// </summary>
        internal DataTable m_dtbAccountData = null; 
        /// <summary>
        /// �Զ��巽��
        /// </summary>
        /// <param name="m_strMedStoreid">ҩ������id</param>
        public void m_mthShow(string m_strMedStoreid)
        {
            m_objMedStoreInfo = clsPub.m_mthGetMedStoreNameByid(m_strMedStoreid.Trim());
            if (m_objMedStoreInfo == null)
            {
                MessageBox.Show("�����ҩ��id�����ڣ�");
                return;
            }
            else
            {
                this.Text = m_objMedStoreInfo.m_strDeptName + this.Text;
                this.m_strDrugStoreid = m_objMedStoreInfo.m_strDeptid;
            }
            this.Show();
        }
        private void frmAccountPeriod_Load(object sender, EventArgs e)
        {
            this.m_dgvAccountPeriod.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_bgwGetData.RunWorkerAsync();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_AccountPeriod)objController).m_mthGetAccountPeriodData();
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_dgvAccountPeriod.DataSource = m_dtbAccountData;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!this.m_bgwGetData.IsBusy)
            {
                this.m_bgwGetData.RunWorkerAsync();
            }
        }

        private void m_btnTransfer_Click(object sender, EventArgs e)
        {
            DateTime dtmBeginDate = ((clsCtl_AccountPeriod)objController).m_dtmGetBeginDate();
            if (dtmBeginDate == DateTime.MinValue)
            {
                MessageBox.Show("��ȡ�����ڽ�ת��ʼʱ��ʧ��", "ҩ�������ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAccount frmAcc = new frmAccount(this.m_strDrugStoreid, dtmBeginDate);
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

        private void m_dgvAccountPeriod_DoubleClick(object sender, EventArgs e)
        {
            clsDS_AccountPeriodVO objAP = ((clsCtl_AccountPeriod)objController).m_objGetAccount();
            if (objAP == null)
            {
                return;
            }

            frmAccount frmAcc = new frmAccount(this.m_strDrugStoreid, objAP);
            frmAcc.FormClosed += new FormClosedEventHandler(frmAcc_FormClosed);
            frmAcc.ShowDialog();
        }

        private void m_dgvAccountPeriod_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAccountPeriod.Rows.Count; iRow++)
            {
                this.m_dgvAccountPeriod.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvAccountPeriod_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAccountPeriod.Rows.Count; iRow++)
            {
                this.m_dgvAccountPeriod.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            if (!this.m_bgwGetData.IsBusy)
            {
                this.m_bgwGetData.RunWorkerAsync();
            }
        }
    }
}