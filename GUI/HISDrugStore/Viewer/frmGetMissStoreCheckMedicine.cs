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
    /// ���©��ҩƷ

    /// </summary>
    public partial class frmGetMissStoreCheckMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region ȫ�ֱ���
        /// <summary>
        /// ���̵�ҩƷ
        /// </summary>
        internal DataTable m_dtbHasCheckMedicine = null;
        
        /// <summary>
        /// ���̵�ҩƷ(Fixed)--��ת���ṹ
        /// </summary>
        internal DataTable m_dtbHasCheckMedicineFixed = null;
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// �ֿ��Ӧ�Ĳ���ID
        /// </summary>
        internal string m_strDeptID = string.Empty;
        /// <summary>
        /// ©��ҩƷ
        /// </summary>
        internal DataTable m_dtbMissMedicine = null;
        /// <summary>
        /// ©��ҩƷ����ϸ
        /// </summary>
        internal DataTable m_dtbMissDetail = null;
        /// <summary>
        /// ��ѡ������
        /// </summary>
        private DataRow[] m_drGetSelected = null;
        /// <summary>
        /// ��ȡ��ѡ������
        /// </summary>
        public DataRow[] m_DrGetSelected
        {
            get
            {
                return m_drGetSelected;
            }
        }
        /// <summary>
        /// ��ѡ������(δ�ϲ�)
        /// </summary>
        private DataRow[] m_drGetSelectedDetail = null;
        /// <summary>
        /// ��ȡ��ѡ������(δ�ϲ�)
        /// </summary>
        public DataRow[] m_DrGetSelectedDetail
        {
            get
            {
                return m_drGetSelectedDetail;
            }
        }
        /// <summary>
        /// �̵�ģʽ��0ΪĬ�ϣ�1Ϊ��ҽ��Ժ
        /// </summary>
        internal int m_intCheckMode = 0;
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        internal bool m_blnIsHospital;
        #endregion

        /// <summary>
        /// ���©��ҩƷ
        /// </summary>
        /// <param name="p_dtbHasCheckMedicine">���̵�ҩƷ</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        public frmGetMissStoreCheckMedicine(DataTable p_dtbHasCheckMedicine, string p_strStorageID)
        {
            InitializeComponent();

            m_dtbHasCheckMedicine = p_dtbHasCheckMedicine;
            m_strDeptID = p_strStorageID;

            m_dgvStorageDetail.AutoGenerateColumns = false;
            ((clsCtl_GetMissStoreCheckMedicine)objController).m_mthInitDataSource();
            m_dgvStorageDetail.DataSource = m_dtbMissMedicine;
        }


        public override void CreateController()
        {
            this.objController = new clsCtl_GetMissStoreCheckMedicine();
            objController.Set_GUI_Apperance(this);
        }

        #region �¼�
        private void m_cmdCheck_Click(object sender, EventArgs e)
        {
            try
            {
                clsPublic.PlayAvi("���ڼ�飬���Ժ�...");
                ((clsCtl_GetMissStoreCheckMedicine)objController).m_mthCheckMedicine();
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtMedicineCode1.Enabled = true;
                m_txtMedicineCode2.Enabled = true;
            }
            else
            {
                m_txtMedicineCode1.Text = string.Empty;
                m_txtMedicineCode2.Text = string.Empty;
                m_txtMedicineCode1.Enabled = false;
                m_txtMedicineCode2.Enabled = false;
            }
        }

        private void m_rdbMedicinePreptype_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicinePreptype.Checked)
            {
                m_cboMediciePreptype.Enabled = true;
            }
            else
            {
                m_cboMediciePreptype.Enabled = false;
            }
        }

        private void m_rdbMedicineType_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineType.Checked)
            {
                m_cboMedicineType.Enabled = true;
            }
            else
            {
                m_cboMedicineType.Enabled = false;
            }
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            m_drGetSelected = ((clsCtl_GetMissStoreCheckMedicine)objController).m_drGetSelectedRows();
            m_drGetSelectedDetail = ((clsCtl_GetMissStoreCheckMedicine)objController).m_drGetSelectedDetailRows();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmGetMissStorageCheckMedicine_Load(object sender, EventArgs e)
        {
            ((clsCtl_GetMissStoreCheckMedicine)objController).m_mthGetMedicinePreptype();
            ((clsCtl_GetMissStoreCheckMedicine)objController).m_mthGetMedicineType();
            ((clsCtl_GetMissStoreCheckMedicine)objController).m_mthFixTable(m_dtbHasCheckMedicine);
            if (m_intCheckMode == 1)
            {
                m_dgvStorageDetail.Columns["m_dgvtxtLotNO"].Visible = false;
                m_dgvStorageDetail.Columns["m_dgvtxtCallPrice"].Visible = false;
                m_dgvStorageDetail.Columns["m_dgvtxtWholeSalePrice"].Visible = false;
                m_dgvStorageDetail.Columns["m_dgvtxtInStorageID"].Visible = false;
                for (int i1 = 1; i1 < m_dgvStorageDetail.Columns.Count; i1++)
                {
                    if (m_dgvStorageDetail.Columns[i1].Visible == true)
                        m_dgvStorageDetail.Columns[i1].Width += 57;
                }
            }
        }

        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvStorageDetail.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "ȫѡ")
                {
                    m_lblSelectAll.Text = "��ѡ";
                    for (int iRow = 0; iRow < m_dgvStorageDetail.Rows.Count; iRow++)
                    {
                        m_dgvStorageDetail.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "��ѡ")
                {
                    m_lblSelectAll.Text = "ȫѡ";
                    for (int iRow = 0; iRow < m_dgvStorageDetail.Rows.Count; iRow++)
                    {
                        m_dgvStorageDetail.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        private void m_txtMedicineCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtMedicineCode2.Focus();
            }
        }

        private void m_txtMedicineCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdCheck.Focus();
            }
        }
        #endregion
    }
}