using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using iCare;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// �༭��λ��Ϣ���߼����Ʋ�
	/// </summary>
	public class clsCtl_AddBed: com.digitalwave.GUI_Base.clsController_Base
	{
		#region ����
        clsDcl_BIHTransfer m_objManage = null;
        /// <summary>
        /// ������־:1-������λ,2-�޸Ĵ�λ
        /// </summary>
        int m_intFlag = 1;
        /// <summary>
        /// ��λ��
        /// </summary>
        double m_dubBedCharge;
        /// <summary>
        /// �յ���
        /// </summary>
        double m_dubAirCharge;
		#endregion 

		#region ���캯��
		public clsCtl_AddBed()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
            m_objManage = new clsDcl_BIHTransfer();
		}
		#endregion 

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInitData()
        {
            //��λ��
            clsListViewColumns_VO[] p_objLsvColumnsArr = new clsListViewColumns_VO[5]{
																 new clsListViewColumns_VO("����","itemcode_vchr",HorizontalAlignment.Left,70),
																 new clsListViewColumns_VO("ƴ����","itempycode_chr",HorizontalAlignment.Left,70),
																 new clsListViewColumns_VO("�����","itemwbcode_chr",HorizontalAlignment.Left,70),
																 new clsListViewColumns_VO("��������","itemname_vchr",HorizontalAlignment.Left,220),
                                                                 new clsListViewColumns_VO("���","itemprice_mny",HorizontalAlignment.Left,50)
															 };
            m_objViewer.m_txtBedMoney.m_mthInitListView(p_objLsvColumnsArr);
            m_objViewer.m_txtBedMoney.m_strSQL = @"SELECT t1.itemid_chr, t1.itemname_vchr, t1.itemprice_mny, t1.itempycode_chr,
       t1.itemwbcode_chr, t1.itemcode_vchr,
       TRIM (t1.itemname_vchr) || ' ' || t1.itemprice_mny
       || '(Ԫ)' AS charename
  FROM t_bse_chargeitem t1, t_bse_bih_specordercate t2
 WHERE t1.itemipinvtype_chr = t2.bedchargecate AND t1.ifstop_int = 0";
            m_objViewer.m_txtBedMoney.m_strFindFieldsArr = new string[4] { "itempycode_chr", "itemwbcode_chr", "itemname_vchr", "itemcode_vchr" };
            m_objViewer.m_txtBedMoney.m_mthGetData();

            //�յ���
            m_objViewer.m_txtAirCondistionMoney.m_mthInitListView(p_objLsvColumnsArr);
            m_objViewer.m_txtAirCondistionMoney.m_strSQL = @"SELECT t1.itemid_chr, t1.itemname_vchr, t1.itemprice_mny, t1.itempycode_chr,
       t1.itemwbcode_chr, t1.itemcode_vchr,
       TRIM (t1.itemname_vchr) || ' ' || t1.itemprice_mny
       || '(Ԫ)' AS charename
  FROM t_bse_chargeitem t1
 WHERE t1.ifstop_int = 0 AND itemname_vchr LIKE '�յ���%'";
            m_objViewer.m_txtAirCondistionMoney.m_strFindFieldsArr = new string[4] { "itempycode_chr", "itemwbcode_chr", "itemname_vchr", "itemcode_vchr" };
            m_objViewer.m_txtAirCondistionMoney.m_mthGetData();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmAddBed m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmAddBed)frmMDI_Child_Base_in;
            //test
		}
		#endregion

		#region ���洲λ��Ϣ
		/// <summary>
        /// ���洲λ��Ϣ
		/// </summary>
		public void m_AddBed()
        {
            long lngReg = 0;
            if (!IsPassInputValidate())
            {
                return;
            }
            string p_strRecordID;
            clsT_Bse_Bed_VO p_objRecord;
            ValueToVoForAddBed(out p_objRecord);
            try
            {

                if (m_intFlag == 1) //������λ
                {
                    lngReg = m_objManage.m_lngAddNewBed(out p_strRecordID, p_objRecord);
                }
                else if (m_intFlag == 2) // �޸Ĵ�λ��Ϣ
                {
                    lngReg = m_objManage.m_lngModefyBedByID(p_objRecord);
                }

                if (lngReg > 0)
                {
                    MessageBox.Show( "����ɹ���", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show( "����ʧ�ܣ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("����ʧ�ܣ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

		/// <summary>
		/// ������֤
		/// </summary>
		/// <returns></returns>
		private bool IsPassInputValidate()
        {
            //������
            if (m_objViewer.m_strAreaID.Trim() == "")
            {
                MessageBox.Show("�����Ų���Ϊ�գ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //�������
            if (m_objViewer.m_txtCODE_CHR.Text.Trim() == "")
            {
                MessageBox.Show("�������Ϊ�����", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtCODE_CHR.Focus();
                return false;
            }
            if (m_objViewer.m_txtBedMoney.Tag == null || m_objViewer.m_txtBedMoney.Text.Trim() == "")
            {
                MessageBox.Show("��λ��Ϊ��ѡ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtBedMoney.Focus();
                return false;
            }
            if (m_objViewer.m_txtAirCondistionMoney.Tag == null || m_objViewer.m_txtAirCondistionMoney.Text.Trim() == "")
            {
                MessageBox.Show("�յ���Ϊ��ѡ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtAirCondistionMoney.Focus();
                return false;
            }
            //�������Ĵ˴�λ���Ƿ����
            if (m_intFlag == 1 && m_objManage.IsExistBedByAreaIDAndCode(m_objViewer.m_strAreaID, "", m_objViewer.m_txtCODE_CHR.Text.Trim()) > 0)
            {
                MessageBox.Show("�������Ѵ��ڴ�λ��" + m_objViewer.m_txtCODE_CHR.Text.Trim() + "����", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtCODE_CHR.SelectAll();
                m_objViewer.m_txtCODE_CHR.Focus();
                return false;
            }
            return true;
        }

		/// <summary>
		/// �ؼ���ֵ��Vo  {�Ӵ�}
		/// </summary>
		/// <param name="p_objRecord"></param>
		private void ValueToVoForAddBed(out clsT_Bse_Bed_VO p_objRecord)
		{
			p_objRecord =new clsT_Bse_Bed_VO();
            p_objRecord.m_strBEDID_CHR = (string)m_objViewer.m_txtCODE_CHR.Tag;
			p_objRecord.m_strAREAID_CHR =m_objViewer.m_strAreaID;
			p_objRecord.m_strCODE_CHR =m_objViewer.m_txtCODE_CHR.Text.Trim();
			p_objRecord.m_intSTATUS_INT =m_objViewer.m_cboSTATUS_INT.SelectedIndex;
			p_objRecord.m_intSEX_INT =m_objViewer.m_cboSEX_INT.SelectedIndex+1;
			p_objRecord.m_intCATEGORY_INT =m_objViewer.m_cboCATEGORY_INT.SelectedIndex;
            if (m_objViewer.m_txtBedMoney.Text.Trim()!="" && m_objViewer.m_txtBedMoney.Tag != null)
            {
                p_objRecord.m_strCHARGEITEMID_CHR = (string)m_objViewer.m_txtBedMoney.Tag;
            }
            if (m_objViewer.m_txtAirCondistionMoney.Text.Trim() != "" && m_objViewer.m_txtAirCondistionMoney.Tag != null)
            {
                p_objRecord.m_str_AIRCHARGEITEMID_CHR = (string)m_objViewer.m_txtAirCondistionMoney.Tag;
            }
            if (m_objViewer.m_txtBedMoney.Text.Trim() != "" && m_objViewer.m_txtBedMoney.m_listView.SelectedItems.Count > 0)
            {
                m_dubBedCharge = Convert.ToDouble(m_objViewer.m_txtBedMoney.m_listView.SelectedItems[0].SubItems[5].Text);
            }
            if (m_objViewer.m_txtAirCondistionMoney.Text.Trim() != "" && m_objViewer.m_txtAirCondistionMoney.m_listView.SelectedItems.Count > 0)
            {
                m_dubAirCharge = Convert.ToDouble(m_objViewer.m_txtAirCondistionMoney.m_listView.SelectedItems[0].SubItems[5].Text);
            }

            if (m_objViewer.m_txtBedMoney.Text.Trim() == "" )
            {
                m_dubBedCharge = 0;
            }
            if (m_objViewer.m_txtAirCondistionMoney.Text.Trim() == "" )
            {
                m_dubAirCharge = 0;
            }
            p_objRecord.m_dblRATE_MNY = m_dubBedCharge;
            p_objRecord.m_dblAIRRATE_MNY = m_dubAirCharge;
		}
		#endregion

        #region ���ô�λ��Ϣ
        /// <summary>
        /// ���ô�λ��Ϣ
        /// </summary>
        /// <param name="p_bedManageVO"></param>
        public void m_mthSetBedInfo(string p_strBedID)
        {
            m_intFlag = 2;
            m_objViewer.Text = "�༭��λ";
            clsT_Bse_Bed_VO p_objBed;
            long lngRes = m_objManage.m_lngGetBedInfoByBedID(p_strBedID, out p_objBed);
            if (lngRes > 0)
            {
                m_objViewer.m_txtCODE_CHR.Tag = p_objBed.m_strBEDID_CHR;
                m_objViewer.m_strAreaID = p_objBed.m_strAREAID_CHR;
                m_objViewer.m_txtCODE_CHR.Text = p_objBed.m_strCODE_CHR;
                m_objViewer.m_cboSTATUS_INT.SelectedIndex = p_objBed.m_intSTATUS_INT;
                m_objViewer.m_txtBedMoney.Text = p_objBed.m_strBedchargeName + " " + p_objBed.m_dblRATE_MNY.ToString() + "(Ԫ)";
                m_dubBedCharge = p_objBed.m_dblRATE_MNY;
                m_objViewer.m_txtAirCondistionMoney.Text = p_objBed.m_strAirChanrgeName + " " + p_objBed.m_dblAIRRATE_MNY.ToString() + "Ԫ";
                m_dubAirCharge = p_objBed.m_dblAIRRATE_MNY;
                m_objViewer.m_cboSEX_INT.SelectedIndex = p_objBed.m_intSEX_INT-1;
                m_objViewer.m_cboCATEGORY_INT.SelectedIndex = p_objBed.m_intCATEGORY_INT;
                m_objViewer.m_txtBedMoney.Tag = p_objBed.m_strCHARGEITEMID_CHR;
                m_objViewer.m_txtAirCondistionMoney.Tag = p_objBed.m_str_AIRCHARGEITEMID_CHR;
            }
        }
        #endregion
    }
}
