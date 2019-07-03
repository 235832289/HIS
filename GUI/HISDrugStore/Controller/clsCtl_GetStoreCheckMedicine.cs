using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��ȡ�̵�ҩƷ
    /// </summary>
    public class clsCtl_GetStoreCheckMedicine : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ȫ�ֱ���
        /// <summary>
        /// ����
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmGetStoreCheckMedicine m_objViewer;
        /// <summary>
        /// ģ�������

        /// </summary>
        private clsDcl_GetStoreCheckMedicine m_objDomain = null;
        #endregion

        #region ���캯��

        /// <summary>
        /// ��ȡ�̵�ҩƷ
        /// </summary>
        public clsCtl_GetStoreCheckMedicine()
        {
            m_objDomain = new clsDcl_GetStoreCheckMedicine();
        }
        #endregion

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmGetStoreCheckMedicine)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ȡ�̵�ҩƷ
        /// <summary>
        /// ��ȡ�̵�ҩƷ
        /// </summary>
        /// <param name="p_dtbMedicine"></param>
        /// <returns></returns>
        internal long m_dtbGetMedicine(out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            p_dtbMedicine = null;

            Control ctlCurrent = null;//��ǰ���ڲ�ѯ�Ŀؼ�

            if (m_objViewer.m_rdbCheckSortNum.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtCheckSortNum1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtCheckSortNum2.Text))
                {
                    MessageBox.Show("��������������ѯ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtCheckSortNum1.Focus();
                    return -1;
                }
                ctlCurrent = m_objViewer.m_txtCheckSortNum1;
                lngRes = m_objDomain.m_lngGetMedicineBySortNum(m_objViewer.m_txtCheckSortNum1.Text, m_objViewer.m_txtCheckSortNum2.Text, m_objViewer.m_strStorageID,m_objViewer.m_blnIsHospital, out p_dtbMedicine);
            }
            else if (m_objViewer.m_rdbMedicineCode.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode2.Text))
                {
                    MessageBox.Show("��������������ѯ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtMedicineCode1.Focus();
                    return -1;
                }
                ctlCurrent = m_objViewer.m_txtMedicineCode1;
                lngRes = m_objDomain.m_lngGetMedicineByMedicineCode(m_objViewer.m_txtMedicineCode1.Text, m_objViewer.m_txtMedicineCode2.Text, m_objViewer.m_strStorageID,m_objViewer.m_blnIsHospital, out p_dtbMedicine);
            }
            else if (m_objViewer.m_rdbMedicinePreptype.Checked)
            {
                if (m_objViewer.m_cboMediciePreptype.SelectedIndex == -1 || m_objViewer.m_cboMediciePreptype.SelectedItem == null)
                {
                    MessageBox.Show("����ѡ��ҩƷ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMediciePreptype.Focus();
                    return -1;
                }

                ctlCurrent = m_objViewer.m_cboMediciePreptype;
                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
                lngRes = m_objDomain.m_lngGetMedicineByMedicinePreptype(objTypeVO.m_strMEDICINEPREPTYPE_CHR, m_objViewer.m_strStorageID, m_objViewer.m_blnIsHospital, out p_dtbMedicine);
            }
            else if (m_objViewer.m_rdbRackNum.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtRackNum1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtRackNum2.Text))
                {
                    MessageBox.Show("��������������ѯ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtRackNum1.Focus();
                    return -1;
                }
                ctlCurrent = m_objViewer.m_txtRackNum1;
                lngRes = m_objDomain.m_lngGetMedicineByMedicineRackNO(m_objViewer.m_txtRackNum1.Text, m_objViewer.m_txtRackNum2.Text, m_objViewer.m_strStorageID, m_objViewer.m_blnIsHospital, out p_dtbMedicine);
            }
            else if (m_objViewer.m_rdbSetType.Checked)
            {
                System.Collections.ArrayList arr = new System.Collections.ArrayList();
                if (m_objViewer.lsvMedType.CheckedItems.Count > 0)
                {
                    for (int i1 = 0; i1 < m_objViewer.lsvMedType.CheckedItems.Count; i1++)
                    {
                        arr.Add(this.m_objViewer.lsvMedType.CheckedItems[i1].Tag.ToString());
                    }
                    lngRes = m_objDomain.m_lngGetMedicineByMedicineType(arr, m_objViewer.m_strStorageID, m_objViewer.m_blnIsHospital, out p_dtbMedicine);
                }
                else
                {
                    MessageBox.Show("����ѡ��һ��ҩƷ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.lsvMedType.Focus();
                    return -1;
                }
            }
            else if (m_objViewer.m_rdbAll.Checked)
            {
                lngRes = m_objDomain.m_lngGetAllMedicine(m_objViewer.m_strStorageID, m_objViewer.m_blnIsHospital, out p_dtbMedicine);
            }
            else
            {
                MessageBox.Show("����ѡ��ɸѡ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (p_dtbMedicine == null || p_dtbMedicine.Rows.Count == 0)
            {
                DialogResult drResult = MessageBox.Show("δ�ҵ�����������ҩƷ��Ϣ���Ƿ����ɸѡ�����������ң�", "ҩƷ�̵�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    if (ctlCurrent != null)
                    {
                        ctlCurrent.Focus();
                    }
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            if (!m_objViewer.m_ckbIncludingZero.Checked) 
            {
                p_dtbMedicine.DefaultView.RowFilter = " realgross_int <> 0 ";
                p_dtbMedicine = p_dtbMedicine.DefaultView.ToTable();
            }
            return 1;
        }
        #endregion

        #region ��ȡ��ѯ����
        /// <summary>
        /// ��ȡ��ѯ����
        /// </summary>
        /// <param name="p_strCondition">��ѯ����</param>
        /// <returns></returns>
        internal long m_lngGetSearchCondition(out string p_strCondition)
        {
            p_strCondition = string.Empty;
            if (m_objViewer.m_rdbCheckSortNum.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtCheckSortNum1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtCheckSortNum2.Text))
                {
                    MessageBox.Show("������������ɸѡ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtCheckSortNum1.Focus();
                    return -1;
                }
                else
                {
                    p_strCondition = "checkmedicineorder_chr >= '" + m_objViewer.m_txtCheckSortNum1.Text + "' and checkmedicineorder_chr <= '" + m_objViewer.m_txtCheckSortNum2.Text + "'";
                }
            }
            else if (m_objViewer.m_rdbMedicineCode.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode2.Text))
                {
                    MessageBox.Show("������������ɸѡ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtMedicineCode1.Focus();
                    return -1;
                }
                else
                {
                    p_strCondition = "assistcode_chr >= '" + m_objViewer.m_txtMedicineCode1.Text + "' and assistcode_chr <= '" + m_objViewer.m_txtMedicineCode2.Text + "'";
                }
            }
            else if (m_objViewer.m_rdbMedicinePreptype.Checked)
            {
                if (m_objViewer.m_cboMediciePreptype.SelectedIndex == -1 || m_objViewer.m_cboMediciePreptype.SelectedItem == null)
                {
                    MessageBox.Show("����ѡ��ҩƷ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMediciePreptype.Focus();
                    return -1;
                }
                else
                {
                    com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
                    if (objTypeVO != null && !string.IsNullOrEmpty(objTypeVO.m_strMEDICINEPREPTYPE_CHR))
                    {
                        p_strCondition = "medicinepreptype_chr = " + objTypeVO.m_strMEDICINEPREPTYPE_CHR;
                    }
                }
            }
            else if (m_objViewer.m_rdbRackNum.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtRackNum1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtRackNum2.Text))
                {
                    MessageBox.Show("��������������ѯ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtRackNum1.Focus();
                    return -1;
                }
                p_strCondition = "storagerackcode_vchr >= '" + m_objViewer.m_txtRackNum1.Text + "' and storagerackcode_vchr <= '" + m_objViewer.m_txtRackNum2.Text + "'";
            }
            else if (m_objViewer.m_rdbAll.Checked)
            {
                p_strCondition = string.Empty;
            }
            else if (m_objViewer.m_rdbSetType.Checked)
            {
                if (m_objViewer.lsvMedType.CheckedItems.Count > 0)
                {
                    for (int i1 = 0; i1 < m_objViewer.lsvMedType.CheckedItems.Count; i1++)
                    {
                        p_strCondition += "medicinetypeid_chr = '" + this.m_objViewer.lsvMedType.CheckedItems[i1].Tag.ToString() + "' or ";
                    }
                    p_strCondition = p_strCondition.Remove(p_strCondition.Length - 4);
                }
                else
                {
                    MessageBox.Show("����ѡ��һ��ҩƷ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.lsvMedType.Focus();
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("����ѡ��ɸѡ����", "ҩƷ�̵�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 1;
        }
        #endregion

        #region ��ȡҩƷ�Ƽ�����
        /// <summary>
        /// ��ȡҩƷ�Ƽ�����
        /// </summary>
        internal void m_mthGetMedicinePreptype()
        {
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objMPVO = null;
            //clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            //long lngRes = objPDomain.m_lngGetMedicinePreptype(out objMPVO);
            m_objDomain.m_lngGetMedicinePreptype(m_objViewer.m_strStorageID2, out objMPVO);

            if (objMPVO != null && objMPVO.Length > 0)
            {
                m_objViewer.m_cboMediciePreptype.Items.Clear();
                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objAll = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO();
                objAll.m_intFLAGA_INT = 0;
                objAll.m_strMEDICINEPREPTYPE_CHR = string.Empty;
                objAll.m_strMEDICINEPREPTYPENAME_VCHR = "ȫ��";
                m_objViewer.m_cboMediciePreptype.Items.Add(objAll);
                m_objViewer.m_cboMediciePreptype.Items.AddRange(objMPVO);
            }

            //���ҩƷ����ListView
            com.digitalwave.iCare.ValueObject.clsMedicineType_VO[] objResultArr = null;
            m_objDomain.m_lngGetMedType(out objResultArr);
            if (objResultArr != null && objResultArr.Length > 0)
            {
                ListViewItem itemTmp = null;
                foreach (com.digitalwave.iCare.ValueObject.clsMedicineType_VO obj in objResultArr)
                {
                    itemTmp = new ListViewItem();
                    itemTmp.SubItems.Add(obj.m_strMedicineTypeName);
                    itemTmp.Tag = obj.m_strMedicineTypeID;
                    m_objViewer.lsvMedType.Items.Add(itemTmp);
                }
            }
            m_objViewer.lsvMedType.Visible = false;
        }
        #endregion
    }
}
