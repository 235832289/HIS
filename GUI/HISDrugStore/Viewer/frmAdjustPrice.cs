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
    /// ����ҩ��ҩƷ����
    /// </summary>
    public partial class frmAdjustPrice : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region ȫ�ֱ���
        internal string m_strMedstoreid = string.Empty;
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// ҩƷ�ֵ�
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// �����¼
        /// </summary>
        internal DataTable m_dtbAdjustMain = null;
        /// <summary>
        /// ��ϸ���¼
        /// </summary>
        internal DataTable m_dtbAdjustDetail = null;
        /// <summary>
        /// ��ǰ�û��Ƿ��й���ԱȨ��
        /// </summary>
        internal bool m_blnIsAdmin = false;
        /// <summary>
        /// �Ƿ���˼�����
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// ͬһҩƷ�Ƿ�����ŵ���
        /// </summary>
        internal bool m_blnIsDiffLotNO = false;
        /// <summary>
        /// �����Ƿ�ͬʱ����ҩƷ������۸�
        /// </summary>
        internal bool m_blnIsChangeBasePrice = false;
        #endregion
        public void m_mthSetShow(string m_strDrugStoreid)
        {
            m_strMedstoreid = m_strDrugStoreid;
            clsMedStore_VO m_objMedStoreVo = clsPub.m_mthGetMedStoreNameByid(m_strDrugStoreid);
            m_strStorageID = m_objMedStoreVo.m_strDeptid;
            this.Text += "("+m_objMedStoreVo.m_strMedStoreName+")";
            this.Show();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public frmAdjustPrice()
        {
            InitializeComponent();
            m_dtpSearchBeginDate.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd��");
            m_dtpSearchEndDate.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd��");
          
            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;
            m_cboDoseType.SelectedIndex = 0;
            ((clsCtl_Adjustment)objController).m_mthGetAdjustPriceSetting();
            if (!m_blnIsDiffLotNO)
            {
                m_dgvtxtLotNO.Visible = false;
            }
        }
        /// <summary>
        /// ҩƷ����
        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        internal frmAdjustPrice(string p_strStorageID) : this()
        {
            m_strStorageID = p_strStorageID;

            m_bgwGetData.RunWorkerAsync();
            //((clsCtl_Adjustment)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            //((clsCtl_Adjustment)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            ((clsCtl_Adjustment)objController).m_mthGetAdjustMain();
        }
        /// <summary>
        /// �������������
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_Adjustment();
            objController.Set_GUI_Apperance(this);
        } 
        private void frmAdjustPrice_Load(object sender, EventArgs e)
        {

        }
        private void m_btnNew_Click(object sender, EventArgs e)
        {
            frmAdjustPriceDetail frmAdj = new frmAdjustPriceDetail(m_strStorageID, m_dtbMedicineDict);
            frmAdj.FormClosed += new FormClosedEventHandler(frmAdj_FormClosed);
            frmAdj.ShowDialog();
        }
        private void frmAdj_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthGetAdjustMain();
        }
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnModify_Click(object sender, EventArgs e)
        {
            if (m_dgvMainInfo.CurrentCell != null && m_dgvSubInfo.Rows.Count > 0)
            {
                int intRowIndex = m_dgvMainInfo.CurrentCell.RowIndex;
                DataRow drCurrent = ((DataRowView)m_dgvMainInfo.Rows[intRowIndex].DataBoundItem).Row;
                clsDS_Adjustment_VO objMain = ((clsCtl_Adjustment)objController).m_objMain(drCurrent);

                //DataTable dtbSub = m_dgvSubInfo.DataSource as DataTable;
                clsDS_Adjustment_Detail[] objSubArr = ((clsCtl_Adjustment)objController).m_objDetail(objMain.m_lngSERIESID_INT);

                frmAdjustPriceDetail frmAdj = new frmAdjustPriceDetail(m_strStorageID, m_dtbMedicineDict, objMain, objSubArr);
                frmAdj.FormClosed += new FormClosedEventHandler(frmAdj_FormClosed);
                frmAdj.ShowDialog();
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthDeleteAdjust();
        }

        private void m_btnExam_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ((clsCtl_Adjustment)objController).m_mthCommit();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void m_btnUnExam_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ((clsCtl_Adjustment)objController).m_mthUnCommit();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_btnInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthInAccount();
        }
        private void m_dgvSubInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthGetMedicineInfo(m_strMedstoreid);
        }
    }
}