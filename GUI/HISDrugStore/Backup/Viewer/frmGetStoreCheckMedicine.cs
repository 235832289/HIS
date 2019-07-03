using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��ȡ�̵�ҩƷ
    /// </summary>
    public partial class frmGetStoreCheckMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region ����

        /// <summary>
        /// ���ҩƷ��Ϣ
        /// </summary>
        private DataTable m_dtbStorageMedicine = null;
        /// <summary>
        /// ��ȡ���ҩƷ��Ϣ
        /// </summary>
        internal DataTable m_DtbStorageMedicine
        {
            get
            {
                return m_dtbStorageMedicine;
            }
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        private string m_strSearchCondition = string.Empty;
        /// <summary>
        /// ��ȡ��ѯ����
        /// </summary>
        internal string m_StrSearchCondition
        {
            get
            {
                return m_strSearchCondition;
            }
        }
        /// <summary>
        /// �ֿ�ID(����ID)
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// �ֿ�ID�����˼���ר�ã�
        /// </summary>
        internal string m_strStorageID2 = string.Empty;
        /// <summary>
        /// �Ƿ�ֻ�ǻ�ȡ��ѯ��������ֱ�ӻ�ȡ����
        /// </summary>
        internal bool m_blnIsOnlyGetCondition = false;
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        internal bool m_blnIsHospital;
        #endregion

        /// <summary>
        /// ��ȡ�̵�ҩƷ
        /// </summary>
        private frmGetStoreCheckMedicine()
        {
            InitializeComponent();
            m_mthSetControlHighLight();
        }

        /// <summary>
        /// ��ȡ�̵�ҩƷ
        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        public frmGetStoreCheckMedicine(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
        }

        /// <summary>
        /// ��ȡ�̵�ҩƷ
        /// </summary>
        /// <param name="p_blnIsOnlyGetCondition">�Ƿ�ֻ�ǻ�ȡ��ѯ��������ֱ�ӻ�ȡ����</param>
        public frmGetStoreCheckMedicine(bool p_blnIsOnlyGetCondition)
            : this()
        {
            m_blnIsOnlyGetCondition = p_blnIsOnlyGetCondition;
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_GetStoreCheckMedicine();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// ���û�ؼ���������
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            com.digitalwave.controls.ctlHighLightFocus objHighLight = new com.digitalwave.controls.ctlHighLightFocus(Color.Moccasin);
            objHighLight.m_mthAddControlInContainer(this);
            if (this.HasChildren)
            {
                foreach (System.Windows.Forms.Control currentCtl in this.Controls)
                {
                    if (currentCtl is System.Windows.Forms.TextBoxBase)
                    {
                        currentCtl.GotFocus += new EventHandler(currentCtl_GotFocus);
                    }
                }
            }
        }
        private void currentCtl_GotFocus(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBoxBase)
                (sender as System.Windows.Forms.TextBoxBase).SelectAll();
        } 

        #region �¼�
        private void m_rdbCheckSortNum_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbCheckSortNum.Checked)
            {
                m_txtCheckSortNum1.Enabled = true;
                m_txtCheckSortNum2.Enabled = true;
                m_txtCheckSortNum1.Focus();
            }
            else
            {
                m_txtCheckSortNum1.Enabled = false;
                m_txtCheckSortNum2.Enabled = false;
                m_txtCheckSortNum1.Text = string.Empty;
                m_txtCheckSortNum2.Text = string.Empty;
            }
        }

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtMedicineCode1.Enabled = true;
                m_txtMedicineCode2.Enabled = true;
                m_txtMedicineCode1.Focus();
            }
            else
            {
                m_txtMedicineCode1.Enabled = false;
                m_txtMedicineCode2.Enabled = false;
                m_txtMedicineCode1.Text = string.Empty;
                m_txtMedicineCode2.Text = string.Empty;
            }
        }

        private void m_rdbMedicineType_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicinePreptype.Checked)
            {
                m_cboMediciePreptype.Enabled = true;
                m_cboMediciePreptype.Focus();
            }
            else
            {
                m_cboMediciePreptype.Enabled = false;
            }
        }

        private void m_rdbRackNum_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbRackNum.Checked)
            {
                m_txtRackNum1.Enabled = true;
                m_txtRackNum2.Enabled = true;
                m_txtRackNum1.Focus();
            }
            else
            {
                m_txtRackNum1.Enabled = false;
                m_txtRackNum2.Enabled = false;
                m_txtRackNum1.Text = string.Empty;
                m_txtRackNum2.Text = string.Empty;
            }
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_blnIsOnlyGetCondition)
                {
                    long lngRes = ((clsCtl_GetStoreCheckMedicine)objController).m_lngGetSearchCondition(out m_strSearchCondition);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }
                else
                {
                    long lngRes = ((clsCtl_GetStoreCheckMedicine)objController).m_dtbGetMedicine(out m_dtbStorageMedicine);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmGetStorageCheckMedicine_Load(object sender, EventArgs e)
        {
            ((clsCtl_GetStoreCheckMedicine)objController).m_mthGetMedicinePreptype();
            if (m_blnIsOnlyGetCondition) 
                m_ckbIncludingZero.Visible = false;
        }

        private void m_txtCheckSortNum1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtCheckSortNum2.Focus();
            }
        }

        private void m_txtCheckSortNum2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdOK.Focus();
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
                m_cmdOK.Focus();
            }
        }

        private void m_txtRackNum1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtRackNum2.Focus();
            }
        }

        private void m_txtRackNum2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdOK.Focus();
            }
        }
        #endregion

        private void m_rdbSetType_Enter(object sender, EventArgs e)
        {
            this.textBox1.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.lsvMedType.Visible = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl != this.lsvMedType || ActiveControl != m_ckbIncludingZero)
            { this.lsvMedType.Visible = false; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.lsvMedType.Visible == true)
                {
                    this.lsvMedType.Focus();
                    this.lsvMedType.FocusedItem.Selected = true;
                }
                else
                {
                    m_cmdOK.Focus();
                }
            }
        }

        private void lsvMedType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lsvMedType.Visible = false;
                this.textBox1.Focus();
            }
        }

        private void lsvMedType_Leave(object sender, EventArgs e)
        {
            if(ActiveControl != m_ckbIncludingZero)
                this.lsvMedType.Visible = false;
        }

        private void lsvMedType_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (this.lsvMedType.CheckedItems.Count > 0)
            {
                this.textBox1.Text = "";
                for (int i = 0; i < this.lsvMedType.CheckedItems.Count; i++)
                {
                    this.textBox1.Text += this.lsvMedType.CheckedItems[i].SubItems[1].Text + " * ";
                }
                this.textBox1.Text = this.textBox1.Text.Remove(this.textBox1.Text.Length - 3);
            }
            else
            { this.textBox1.Text = ""; }
        }

        private void m_rdbSetType_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbSetType.Checked)
            {
                this.textBox1.Enabled = true;
                this.textBox1.Focus();
            }
            else
            {
                this.textBox1.Enabled = false;
                this.textBox1.Text = string.Empty;
            }
        }
    }
}