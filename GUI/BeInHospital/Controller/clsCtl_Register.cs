using System;
using System.Collections;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Xml;
using System.IO;
using com.digitalwave.iCare.middletier.HIS;
using System.Text.RegularExpressions;
using ControlLibrary;
using System.Collections.Generic;


namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��Ժ�Ǽǿ��Ʋ�
    /// </summary>
    public class clsCtl_Register : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        com.digitalwave.iCare.gui.HIS.clsDcl_Register m_objRegister = null;
        clsDcl_BedAdmin m_objBedAdmin = null;
        clsDcl_BIHTransfer m_objTran = null;
        public string m_strOperatorID;
        /// <summary>
        /// ��Ժ�Ǽ���ˮ��
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// ���˱��
        /// </summary>
        public string m_strPatientID = "";
        /// <summary>
        /// סԺ��
        /// </summary>
        public string m_strInPatientID = "";
        /// <summary>
        ///  סԺ���ۺ�
        /// </summary>
        private string m_strINPATIENTTEMPID = "";
        /// <summary>
        /// סԺ״̬	{-1=�״���Ժ;0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
        /// </summary>
        public int m_intPStatus = -1;
        /// <summary>
        /// ���ｨ��Ԥ����
        /// </summary>
        public string m_strCLINICSAYPREPAY = "";
        /// <summary>
        /// ��ʶ:1-�״���Ժ����2-�ٴ���Ժ
        /// </summary>
        private int m_intFlag = 1;
        /// <summary>
        /// �Ƿ��ȡ��סԺ��
        /// </summary>
        private bool m_blnNewInPatienID = true;
        /// <summary>
        /// ������Ժ�ǼǴ�*�ŵ����Ƿ����:0-�ɲ��� 1-������
        /// </summary>
        private int m_intNeedInput = 0;
        /// <summary>
        /// �²��˱�ʶ:1-�²���(û�в��˻�������)��Ҫ�������ϵǼ�,2-���в��˻�������,����Ҫ�������ϵǼ�
        /// </summary>
        private int m_intNewPatient = 1;
        /// <summary>
        /// ��ǰ������ݱ�ʶ:0-��ͨ 1-���� 2-ҽ�� 3-���� 4-Ӧ��������
        /// </summary>
        private int m_intPatientFlag = 0;

        //Ԥ�������־ 0 ����Ԥ����1������
        private int m_disPrepayFalg = 0;

        /// <summary>
        /// ��Ժ�Ǽ�סԺ�����ɷ�ʽ 1 �Զ� 2 �ֶ�
        /// </summary>
        private int m_disCreatNOFlag = 1;

        com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;

        #endregion

        #region ���캯��
        public clsCtl_Register()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objRegister = new com.digitalwave.iCare.gui.HIS.clsDcl_Register();
            m_objBedAdmin = new clsDcl_BedAdmin();
            m_objTran = new clsDcl_BIHTransfer();
            m_strOperatorID = "0000001";
            objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(m_strOperatorID);
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmPatientRecord m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPatientRecord)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInit()
        {
            //��ȡ����ҽ���б�
            clsColumns_VO[] columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("����","empno_chr",HorizontalAlignment.Left,50),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("����","doctorname",HorizontalAlignment.Left,80),
           };
            m_objViewer.m_txtMaindoctor.m_strSQL = @"SELECT   t1.empid_chr, t1.empno_chr, t1.pycode_chr,
                                                             t1.lastname_vchr AS doctorname
                                                        FROM t_bse_employee t1
                                                       WHERE status_int = 1 AND hasprescriptionright_chr = '1'
                                                    ORDER BY t1.empno_chr";
            m_objViewer.m_txtMaindoctor.m_mthInitListView(columArr);

            // �����б�
            columArr = new clsColumns_VO[]{
                new clsColumns_VO("���","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("��������","deptname_vchr",HorizontalAlignment.Left,130)
            };
            m_objViewer.m_txtAREAID.m_strSQL = @"SELECT   deptid_chr, deptname_vchr, pycode_chr, code_vchr
                                                    FROM t_bse_deptdesc t1
                                                   WHERE attributeid = '0000003' AND status_int = 1
                                                ORDER BY code_vchr";
            m_objViewer.m_txtAREAID.m_mthInitListView(columArr);


            //���
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("���","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("���","dictname_vchr",HorizontalAlignment.Left,60)
            };
            m_objViewer.m_txtRace.m_strSQL = @"SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                    FROM t_aid_dict a
                                                   WHERE dictid_chr != '0' AND dictkind_chr = '1'
                                                ORDER BY TO_NUMBER (dictdefinecode_vchr)";
            m_objViewer.m_txtRace.m_mthInitListView(columArr);

            //�������
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("���","paytypeno_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("�������","paytypename_vchr",HorizontalAlignment.Left,140)
            };
            m_objViewer.m_txtPaytype.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr, bihlimitrate_dec,
                                                         internalflag_int
                                                    FROM t_bse_patientpaytype
                                                   WHERE payflag_dec != 1 AND isusing_num != 0
                                                ORDER BY paytypeno_vchr";
            m_objViewer.m_txtPaytype.m_mthInitListView(columArr);

            //�������
//            columArr = new clsColumns_VO[]
//            {
//                new clsColumns_VO("���ID","paytypeid_chr",HorizontalAlignment.Left,0),
//                new clsColumns_VO("���","paytypeno_vchr",HorizontalAlignment.Left,40),
//                new clsColumns_VO("���","paytypename_vchr",HorizontalAlignment.Left,140)
//            };
//            m_objViewer.m_txtPatiemtType.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr
//                                                        FROM t_bse_patientpaytype
//                                                       WHERE payflag_dec != 1 AND isusing_num != 0
//                                                    ORDER BY paytypeno_vchr";
//            m_objViewer.m_txtPatiemtType.m_mthInitListView(columArr);

            //ְҵ
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("���","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("ְҵ","dictname_vchr",HorizontalAlignment.Left,80)
            };
            m_objViewer.m_txtOccupation.m_strSQL = @"SELECT   '0' AS dictdefinecode_vchr, '' AS wbcode_chr, '' AS pycode_chr,
                                                             '' AS dictname_vchr
                                                        FROM DUAL
                                                    UNION ALL
                                                    SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                        FROM t_aid_dict a
                                                       WHERE dictid_chr != '0' AND dictkind_chr = '9'";
            m_objViewer.m_txtOccupation.m_mthInitListView(columArr);

            //��ϵ
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("���","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("��ϵ","dictname_vchr",HorizontalAlignment.Left,60)
            };
            m_objViewer.m_txtRelation.m_strSQL = @"SELECT   '0' AS dictdefinecode_vchr, '' AS wbcode_chr, '' AS pycode_chr,
                                                             '' AS dictname_vchr
                                                        FROM DUAL
                                                    UNION ALL
                                                    SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                        FROM t_aid_dict a
                                                       WHERE dictid_chr != '0' AND dictkind_chr = '4'";
            m_objViewer.m_txtRelation.m_mthInitListView(columArr);

            //��ʼ���������������
            clsAIDDICT_VO[] objAIDDICTArr = null;
            m_objTran.m_lngGetAID_DICTArr(2, out objAIDDICTArr);
            m_objViewer.txtNationality.DataSource = objAIDDICTArr;
            m_objViewer.txtNationality.DisplayMember = "m_strGetCodeAndName";
            m_objViewer.txtNationality.ValueMember = "m_strGetDICTNAME_VCHR";

            //��ʼ�����������
            m_objTran.m_lngGetAID_DICTArr(5, out objAIDDICTArr);
            m_objViewer.cobMarried.DataSource = objAIDDICTArr;
            m_objViewer.cobMarried.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.cobMarried.DisplayMember = "m_strGetCodeAndName";

            // ���"������Դ"��  �������޸���2010\8\6
            m_objTran.m_lngGetAID_DICTArr(23, out objAIDDICTArr);
            m_objViewer.m_cboPatientSource.DataSource = objAIDDICTArr;
            m_objViewer.m_cboPatientSource.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.m_cboPatientSource.DisplayMember = "m_strGetCodeAndName";

            //��ʼ���Ա�������
            m_objTran.m_lngGetAID_DICTArr(10, out objAIDDICTArr);
            m_objViewer.cboSex.DataSource = objAIDDICTArr;
            m_objViewer.cboSex.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.cboSex.DisplayMember = "m_strGetCodeAndName";

            m_objTran.m_lngGetSetingByID("1006", out m_intNeedInput);

            m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_cboCUYCATE_INT.SelectedIndex = 0;
            m_objViewer.m_cobPrint.SelectedIndex = 0;
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            m_objViewer.cboSex.SelectedIndex = 0;
            m_objViewer.m_cboPatientSource.SelectedValue = "������";
            m_objViewer.m_txtRace.Text = "����";
            m_objViewer.txtNationality.SelectedValue = "�й�";
            m_objViewer.cobMarried.SelectedIndex = 0;
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            m_objViewer.m_cmbFindType.SelectedIndex = 0;
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            m_objViewer.m_txtAge.Text = "0��";
            m_strReadInvoiceNO();

            //��ϵͳ���ã��Ƿ���Ԥ����
            this.m_objTran.m_lngGetSetingByID("1057", out this.m_disPrepayFalg);
            if (this.m_disPrepayFalg != 1)
                this.m_disPrepayFalg = 0;

            if (this.m_disPrepayFalg == 1)
            {
                this.m_objViewer.m_txtMONEY_DEC.Enabled = false;
                this.m_objViewer.m_cboCUYCATE_INT.Enabled = false;
                this.m_objViewer.m_txtPREPAYINV_VCHR.Enabled = false;
                this.m_objViewer.m_cobPrint.Enabled = false;
            }

            //�趨��Ժ�Ǽ�סԺ�����ɷ�ʽ 1 �Զ� 2 �ֶ�
            this.m_objTran.m_lngGetSetingByID("1064", out this.m_disCreatNOFlag);
            this.m_mthInitYB();
        }
        #endregion

        #region ���˵Ǽ�
        /// <summary>
        /// ���˵Ǽ�
        /// </summary>
        public void m_mthPationRecord()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            com.digitalwave.iCare.gui.Patient.frmPatient frm = new com.digitalwave.iCare.gui.Patient.frmPatient(1, m_objViewer.txtPatientName.Text.Trim(), m_objViewer.cboSex.Text.Trim());
            frm.LoginInfo = this.m_objViewer.LoginInfo;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK || frm.DialogResult == DialogResult.Yes)
            {
                m_strPatientID = frm.m_strPatientID;
                m_mthFindPatientInfoByPatientID();
            }
            frm = null;
            m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region	���Ҳ���
        /// <summary>
        /// ���Ҳ���
        /// </summary>
        public void m_mthFindPatient()
        {
            frmCommonFind frm = new frmCommonFind();
            frm.IsBihReg = true;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                m_strPatientID = frm.PatientID;
                m_mthFindPatientInfoByPatientID();
            }
            frm = null;
        }
        #endregion

        #region ��ȡ����ת�벡����Ϣ
        /// <summary>
        /// ��ȡ����ת�벡����Ϣ
        /// </summary>
        public void m_mthGetTurnInPatienList()
        {
            DataTable m_dtbReselt;
            long lngRes = m_objRegister.m_lngGetTurnInPatienList(out m_dtbReselt);
            if (lngRes > 0)
            {
                ListViewItem tempItem;
                m_objViewer.m_lsvTurnInPation.Items.Clear();
                for (int i1 = 0; i1 < m_dtbReselt.Rows.Count; i1++)
                {
                    tempItem = new ListViewItem(m_dtbReselt.Rows[i1]["patientcardid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["inpatientid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["deptname_vchr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["patientname"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["sex_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["state_int"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["paytypename_vchr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["doctername"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["modify_dat"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["areaid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["patientid_chr"].ToString().Trim());
                    tempItem.Tag = m_dtbReselt.Rows[i1]["registerid_chr"].ToString().Trim();
                    m_objViewer.m_lsvTurnInPation.Items.Add(tempItem);
                }
            }
            m_dtbReselt.Dispose();
        }
        #endregion

        #region ����ת�벡����Ժ
        /// <summary>
        /// ����ת�벡����Ժ
        /// </summary>
        public void m_mthPatientTurnIn()
        {
            if (m_objViewer.m_lsvTurnInPation.SelectedItems.Count > 0)
            {
                DataTable p_dtbResult;
                long ret = m_objRegister.m_lngGetPatientInHospitalInfo(m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[10].Text.Trim(), 1, out p_dtbResult);
                if (ret > 0 && p_dtbResult.Rows.Count < 1)
                {
                    long lngRes = m_objRegister.m_lngPatientTurnIn(m_objViewer.m_lsvTurnInPation.SelectedItems[0].Tag.ToString().Trim(), m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[9].Text.Trim(), m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[1].Text.Trim());
                    if (lngRes > 0)
                    {
                        m_EmptyAndInitialization();
                        //QueryPatient();
                        m_objViewer.m_lsvTurnInPation.SelectedItems[0].Remove();
                        m_objViewer.tabControl1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("�ò����Ѵ�����Ժ��Ϣ!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        #endregion

        #region ɾ������ת�벡����Ϣ
        /// <summary>
        /// ɾ������ת�벡����Ϣ
        /// </summary>
        public void m_mthDelTrunInInfo()
        {

            if (m_objViewer.m_lsvTurnInPation.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("ȷ��ɾ������Ϣô��", "ɾ������ת�벡����Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string strSQL = @"DELETE      t_opr_bih_register t1
      WHERE t1.status_int = 2 AND t1.registerid_chr = '" + m_objViewer.m_lsvTurnInPation.SelectedItems[0].Tag.ToString().Trim() + "'";
                long lngResult = m_objRegister.m_lngModifyBihRegisterInfo(strSQL);
                if (lngResult > 0)
                {
                    m_objViewer.m_lsvTurnInPation.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("ɾ��ʧ�ܣ�", "ɾ������ת�벡����Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetTurnInPatienList();
                }
            }
        }
        #endregion

        #region ���

        #region ���������Ϣ
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        public void m_EmptyAndInitialization()
        {
            // ���סԺ״̬
            m_strRegisterID = "";
            m_strInPatientID = "";
            m_strPatientID = "";
            m_strINPATIENTTEMPID = "";
            m_intFlag = 1;
            m_intNewPatient = 1;
            m_objViewer.m_txtFindText.Text = "";
            m_objViewer.m_txtMONEY_DEC.Text = "";
            m_objViewer.m_cboCUYCATE_INT.SelectedIndex = 0;
            m_objViewer.m_cobPrint.SelectedIndex = 0;
            m_objViewer.m_lblPStatusName.Text = "�״���Ժ";
            m_EmptyBaseInfo();
            m_EmptyBihRegisterInfo();
            m_objViewer.txtPatientName.Focus();
        }
        #endregion

        #region ��ղ��˻�����Ϣ
        /// <summary>
        /// ��ղ��˻�����Ϣ
        /// </summary>
        public void m_EmptyBaseInfo()
        {
            //��������
            m_objViewer.txtPATIENTCARDID.Text = "";
            //ҽ�����
            m_objViewer.m_txtinsuranceid.Text = "";
            //��������
            m_objViewer.m_txtAge.Text = "0��";
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            //���֤�� 
            m_objViewer.txtIDCard.Text = "";
            //�������� 
            m_objViewer.txtPatientName.Text = "";
            //�Ա� 
            m_objViewer.cboSex.SelectedIndex = 0;
            //��ϵ�绰 
            m_objViewer.txtPhone.Text = "";
            //�Ƿ�Ա��
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            //��� 
            m_objViewer.cobMarried.SelectedIndex = 0;
            //�ƶ��绰 
            m_objViewer.txtMobile.Text = "";
            //�������� 
            m_objViewer.dtpFirstDate.Value = System.DateTime.Now;
            //��Ч״̬ {1����Ч��0����Ч��-1����ʷ}
            m_objViewer.cobStatus.Text = "";
            //��ͥסַ 
            m_objViewer.txtAddress.Text = "";
            //����
            m_objViewer.txtNationality.SelectedValue = "�й�";
            //������Դ
            m_objViewer.m_cboPatientSource.SelectedValue = "������";
            //���� 
            m_objViewer.m_txtRace.Text = "����";
            //���� 
            m_objViewer.m_txttNativeplace.Text = "";
            //ְҵ 
            m_objViewer.m_txtOccupation.Text = "";
            m_objViewer.m_txtOccupation.m_mthFindDate();
            m_objViewer.m_txtOccupation.m_listView.Visible = false;
            //��ַ�ʱ� 
            m_objViewer.txtHomepc.Text = "";
            //������ 
            m_objViewer.txtBirthPlace.Text = "";
            //��ϵ������ 
            m_objViewer.txtContactpersonFirstaName.Text = "";
            //��ϵ�˵绰 
            m_objViewer.txtContactpersonPhone.Text = "";
            //��ϵ���ʱ� 
            m_objViewer.txtContactpersonpc.Text = "";
            //����ϵ�˹�ϵ 
            m_objViewer.m_txtRelation.Text = "";
            m_objViewer.m_txtRelation.m_mthFindDate();
            m_objViewer.m_txtRelation.m_listView.Visible = false;
            //��ϵ�˵�ַ 
            m_objViewer.txtContactpersonAddress.Text = "";
            //�칫�绰 
            m_objViewer.txtOfficephone.Text = "";
            //�칫�ʱ� 
            m_objViewer.txtOfficepc.Text = "";
            //������λ 
            m_objViewer.txtEmployer.Text = "";
            //�������� 
            m_objViewer.txtEmail.Text = "";
            //�칫��ַ
            m_objViewer.txtOfficeAddress.Text = "";
            //��������
            m_objViewer.txtDeactivateDate.Text = "";
            //������Ա
            m_objViewer.txtOperatorid.Text = "";
            //��������
            m_objViewer.txtModifydate.Text = "";
            // ҽ��֤��
            m_objViewer.m_txtGOVCARD_CHR.Text = "";

            this.m_objViewer.m_txtInsuredMoney.Text = "";
            this.m_objViewer.m_txtInsuredPayTime.Text = "";
            this.m_objViewer.m_txtInsuredPayMoney.Text = "";

            this.m_objViewer.txtBirthPlace.Text = "";
            this.m_objViewer.txtResidenceplace.Text = "";
            this.m_objViewer.txtConsigneeAddr.Text = "";
        }
        #endregion

        #region ���סԺ��Ϣ
        /// <summary>
        /// ���סԺ��Ϣ
        /// </summary>
        public void m_EmptyBihRegisterInfo()
        {
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            //�Ƿ�ԤԼ
            m_objViewer.m_chkISBOOKING_INT.Checked = false;
            //סԺ��
            m_objViewer.m_txtINPATIENTID_CHR.Text = "";
            m_objViewer.m_txtINPATIENTID_CHR.Tag = "";
            //��Ժ����
            m_objViewer.m_dateInHosp.Enabled = true;
            m_objViewer.m_dateInHosp.Text = "";
            m_objViewer.m_dateInHosp.Tag = "";
            //��Ժ���ҡ���Ժ��������Ժ��
            m_objViewer.m_txtDEPTID_CHR.Text = "";
            m_objViewer.m_txtDEPTID_CHR.Tag = "";
            if (m_objViewer.m_txtAREAID.Enabled)
            {
                m_objViewer.m_txtAREAID.Text = "";
                m_objViewer.m_txtAREAID.Value = null;
                m_objViewer.m_txtAREAID.m_mthFindDate();
            }
            //��Ժ��ʽ {��������������Ժת��}
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            //���顡����Σ������������ͨ��
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            //�����ˡ�����ʱ��
            m_objViewer.m_lblOperatorName.Text = "";
            m_objViewer.m_lblOperatorName.Tag = null;
            //������� 
            m_objViewer.m_txtPaytype.Value = "";
            m_objViewer.m_txtPaytype.Text = "";
            m_objViewer.m_txtPaytype.m_mthFindDate();
            m_objViewer.m_txtLIMITRATE_MNY.Text = "";
            //������
            //m_objViewer.m_txtPatiemtType.Value = "";
            //m_objViewer.m_txtPatiemtType.Text = "";
            //m_objViewer.m_txtPatiemtType.m_mthFindDate();
            //��������
            m_mthSetPatType();
            m_objViewer.m_txtMONEY_DEC.Text = "";
            //�������ҽ��
            m_objViewer.m_txtMaindoctor.Value = null;
            m_objViewer.m_txtMaindoctor.Text = "";
            m_objViewer.m_txtMaindoctor.m_mthFindDate();
            m_objViewer.m_txtRemark.Text = "";
            // �������
            m_objViewer.m_txtMZDiagnose.Text = "";
        }
        #endregion

        #endregion

        #region ����������Ϣ

        #region ���벡�˻�����Ϣ
        #region �������֤��
        /// <summary>
        /// �������֤�Ż�ȡ���˻�����Ϣ
        /// </summary>
        public bool LoadPatientInfoByIDCARD()
        {
            //���֤��Ϊ���򷵻�
            if (m_objViewer.txtIDCard.Text.Trim() == "") return false;
            clsPatient_VO objPatientVO = new clsPatient_VO();
            long lngReg = m_objRegister.m_lngGetPatientInfoByIDCARD(m_objViewer.txtIDCard.Text.Trim(), out objPatientVO);
            if (lngReg > 0 && objPatientVO != null)
            {
                m_EmptyAndInitialization();
                VoToValueForAll(objPatientVO);
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion
        #region �����˻�����Ϣ��ֵ
        /// <summary>
        /// �����˻������ϸ�ֵ
        /// </summary>
        /// <param name="objPatientVO"></param>
        private void VoToValueForAll(clsPatient_VO objPatientVO)
        {
            string strTem = "";
            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;
            //ҽ�����
            m_objViewer.m_txtinsuranceid.Text = objPatientVO.m_strINSURANCEID_VCHR;
            //��������
            if (objPatientVO.m_strBIRTH_DAT != null && objPatientVO.m_strBIRTH_DAT.ToString() != "")
                m_objViewer.m_dtpBirthDate.Text = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT.ToString()).ToString("yyyy-MM-dd");
            //���֤�� 
            m_objViewer.txtIDCard.Text = objPatientVO.m_strIDCARD_CHR;
            //�������� 
            m_objViewer.txtPatientName.Text = objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
            //��ϵ�绰 
            m_objViewer.txtPhone.Text = objPatientVO.m_strHOMEPHONE_VCHR;
            //�Ա� 
            m_objViewer.cboSex.SelectedValue = objPatientVO.m_strSEX_CHR;
            //�������
            //m_objViewer.m_txtPatiemtType.Value = objPatientVO.m_strPAYTYPEID_CHR;
            //m_objViewer.m_txtPatiemtType.m_mthFindAndSelect(objPatientVO.m_strPAYTYPEID_CHR);
            //�Ƿ�Ա��
            m_objViewer.cboIsemployee.SelectedIndex = objPatientVO.m_intISEMPLOYEE_INT;
            //��� 
            m_objViewer.cobMarried.SelectedValue = objPatientVO.m_strMARRIED_CHR;
            //�ƶ��绰 
            m_objViewer.txtMobile.Text = objPatientVO.m_strMOBILE_CHR;
            //�������� 
            if (objPatientVO.m_strFIRSTDATE_DAT != null && objPatientVO.m_strFIRSTDATE_DAT.ToString() != "")
                m_objViewer.dtpFirstDate.Value = Convert.ToDateTime(objPatientVO.m_strFIRSTDATE_DAT.ToString());
            //��Ч״̬ {1����Ч��0����Ч��-1����ʷ}
            switch (objPatientVO.m_intSTATUS_INT)
            {
                case 1:
                    strTem = "��Ч";
                    break;
                case 0:
                    strTem = "��Ч";
                    break;
                case -1:
                    strTem = "��ʷ";
                    break;
                default:
                    strTem = "";
                    break;
            }
            m_objViewer.cobStatus.Text = strTem;
            //��ͥסַ 
            m_objViewer.txtAddress.Text = objPatientVO.m_strHOMEADDRESS_VCHR;

            //��ϸ��Ϣ
            //����
            if (objPatientVO.m_strNATIONALITY_VCHR == null || objPatientVO.m_strNATIONALITY_VCHR == "")
            {
                m_objViewer.txtNationality.SelectedValue = "�й�";
            }
            else
            {
                m_objViewer.txtNationality.SelectedValue = objPatientVO.m_strNATIONALITY_VCHR;
            }
            //���� 
            if (objPatientVO.m_strRACE_VCHR == null || objPatientVO.m_strRACE_VCHR == "")
            {
                m_objViewer.m_txtRace.Text = "����";
            }
            else
            {
                m_objViewer.m_txtRace.Text = objPatientVO.m_strRACE_VCHR;
            }
            //������Դ
            if (objPatientVO.m_strPatientSource == null || objPatientVO.m_strPatientSource == "")
            {
                m_objViewer.m_cboPatientSource.SelectedValue = "������";
            }
            else
            {
                m_objViewer.m_cboPatientSource.SelectedValue = objPatientVO.m_strPatientSource;
            }
            //���� 
            m_objViewer.m_txttNativeplace.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            //ְҵ 
            m_objViewer.m_txtOccupation.Text = objPatientVO.m_strOCCUPATION_VCHR;
            //��ַ�ʱ� 
            m_objViewer.txtHomepc.Text = objPatientVO.m_strHOMEPC_CHR;
            //������ 
            m_objViewer.txtBirthPlace.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            //��ϵ������ 
            if (objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR != "")
            {
                m_objViewer.txtContactpersonFirstaName.Text = objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR;
            }
            else
            {
                m_objViewer.txtContactpersonFirstaName.Text = m_objViewer.txtPatientName.Text;
            }
            //��ϵ�˵绰 
            m_objViewer.txtContactpersonPhone.Text = objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
            //��ϵ���ʱ� 
            m_objViewer.txtContactpersonpc.Text = objPatientVO.m_strCONTACTPERSONPC_CHR;
            //����ϵ�˹�ϵ 
            m_objViewer.m_txtRelation.Text = objPatientVO.m_strPATIENTRELATION_VCHR;
            //��ϵ�˵�ַ 
            m_objViewer.txtContactpersonAddress.Text = objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
            //�칫�绰 
            m_objViewer.txtOfficephone.Text = objPatientVO.m_strOFFICEPHONE_VCHR;
            //�칫�ʱ� 
            m_objViewer.txtOfficepc.Text = objPatientVO.m_strOFFICEPC_VCHR;
            //������λ 
            m_objViewer.txtEmployer.Text = objPatientVO.m_strEMPLOYER_VCHR;
            //�������� 
            m_objViewer.txtEmail.Text = objPatientVO.m_strEMAIL_VCHR;
            //�칫��ַ
            m_objViewer.txtOfficeAddress.Text = objPatientVO.m_strOFFICEADDRESS_VCHR;
            //��������
            m_objViewer.txtDeactivateDate.Text = objPatientVO.m_strDEACTIVATE_DAT;
            //������Ա
            m_objViewer.txtOperatorid.Text = objPatientVO.m_strOPERATORID_CHR;
            //��������
            m_objViewer.txtModifydate.Text = objPatientVO.m_strMODIFY_DAT;
            m_objViewer.m_txttNativeplace.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            m_objViewer.m_txtGOVCARD_CHR.Text = objPatientVO.m_strGOVCARD_CHR;

            this.m_objViewer.m_txtInsuredMoney.Text = objPatientVO.m_decInsuredMoney.ToString();
            this.m_objViewer.m_txtInsuredPayTime.Text = objPatientVO.m_decInsuredPayTime.ToString();
            this.m_objViewer.m_txtInsuredPayMoney.Text = objPatientVO.m_decInsuredPayMoney.ToString();

            this.m_objViewer.txtBirthPlace.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            this.m_objViewer.txtResidenceplace.Text = objPatientVO.m_strResidencePlace;
            this.m_objViewer.txtConsigneeAddr.Text = objPatientVO.ConsigneeAddr;
            objPatientVO = null;
        }
        #endregion
        #endregion

        #region ����סԺ��Ϣ
        /// <summary>
        /// ����סԺ��Ϣ[����סԺ��]
        /// </summary>
        public void LoadBihRegister()
        {
            // ��ȡסԺ�ŵ����һ��סԺ�Ǽ���ˮ��
            long lngReg = m_objRegister.m_lngGetRegisteridByInpatientID(m_strInPatientID, out m_strRegisterID);
            if (lngReg < 0)
                return;
            if (m_strRegisterID == "")
            {
                return;
            }
            m_mthGetPatientInfo(m_strRegisterID);
        }
        #endregion

        #region ������Ժ�Ǽǻ�ȡ����סԺ��Ϣ
        /// <summary>
        /// ������Ժ�Ǽǻ�ȡ����סԺ��Ϣ
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        private void m_mthGetPatientInfo(string p_strRegisterID)
        {
            //����סԺ��ˮ�� ��ѯסԺ�Ǽ�
            clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
            long lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(p_strRegisterID, out m_objItem);
            if (lngReg <= 0 || m_objItem == null)
                return;

            //���ؼ���ֵ
            m_strPatientID = m_objItem.m_strPATIENTID_CHR;
            m_objViewer.m_chkISBOOKING_INT.Checked = Convert.ToBoolean(m_objItem.m_intISBOOKING_INT);
            //��Ժ����
            m_objViewer.m_dateInHosp.Text = m_objItem.m_strINPATIENT_DAT.ToString();
            m_objViewer.m_dateInHosp.Tag = m_objItem.m_strINPATIENT_DAT.ToString();

            //��Ժ���ҡ�����������
            m_objViewer.m_txtDEPTID_CHR.Text = m_objItem.m_strDeptName;
            m_objViewer.m_txtDEPTID_CHR.Tag = m_objItem.m_strDEPTID_CHR;
            m_objViewer.m_txtAREAID.Text = m_objItem.m_strAreaName;
            m_objViewer.m_txtAREAID.Value = m_objItem.m_strAREAID_CHR;
            //��Ժ��ʽ{1=����;2=����;3=��Ժת��;4=����ת��}
            m_objViewer.m_cboTYPE_INT.SelectedIndex = m_objItem.m_intTYPE_INT - 1;
            m_objViewer.m_txtLIMITRATE_MNY.Text = m_objItem.m_dblLIMITRATE_MNY.ToString();
            //���� {1Σ��2����3��ͨ}
            m_objViewer.m_cboSTATE_INT.SelectedIndex = m_objItem.m_intSTATE_INT - 1;
            m_objViewer.m_lblOperatorName.Text = m_objRegister.m_GetEmployeeNameByID(m_objItem.m_strOPERATORID_CHR);
            //סԺ״̬	{0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
            m_intPStatus = m_objItem.m_intPSTATUS_INT;
            switch (m_objItem.m_intINPATIENTNOTYPE_INT)
            {
                case 1:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
                        break;
                    }
                case 2:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 1;
                        break;
                    }
                case 3:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 2;
                        break;
                    }
                default:
                    break;
            }
            //����ҽ��]
            this.m_objViewer.m_txtMaindoctor.Text = m_objItem.m_stroutdoctorname;
            this.m_objViewer.m_txtMaindoctor.Value = m_objItem.m_strMZDOCTOR_CHR;
            //���ｨ��Ԥ����
            m_strCLINICSAYPREPAY = m_objItem.m_strCLINICSAYPREPAY;
            this.m_objViewer.m_txtRemark.Text = m_objItem.DES_VCHR;
            if (m_objViewer.m_lblPStatusName.Text == "�״���Ժ" || m_objViewer.m_lblPStatusName.Text == "�ѳ�Ժ")
            {
                m_objViewer.m_dateInHosp.Enabled = true;
                m_objViewer.m_dateInHosp.Text = m_objBedAdmin.m_GetServTime().ToString();
            }
            else
            {
                m_objViewer.m_dateInHosp.Enabled = false;
            }
            DataTable dtbResult = null;
            DataTable dtbResult1 = null;
            m_objRegister.m_lngGetSpChargeItemIDType(out dtbResult1);
            string id1 = "";
            string id2 = "";
            if (dtbResult1.Rows.Count > 0)
            {
                id1 = dtbResult1.Rows[0]["EATDICCATE"].ToString();
                id2 = dtbResult1.Rows[0]["NURSECATE"].ToString();
            }
            if (m_intPStatus == 1 || m_intPStatus == 2)
            {
                m_objRegister.m_lngGetPatientCareInfo(m_strRegisterID, out dtbResult);
                if (dtbResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        if (dtbResult.Rows[i]["ordercateid_chr"].ToString() == id1)
                        {
                            this.m_objViewer.m_txtFoodInfo.Text = dtbResult.Rows[i]["NAME_CHR"].ToString();
                        }
                        if (dtbResult.Rows[i]["ordercateid_chr"].ToString() == id2)
                        {
                            this.m_objViewer.m_txtCareInfo.Text = dtbResult.Rows[i]["NAME_CHR"].ToString();
                        }
                    }
                }
            }
            if (m_objViewer.m_lblPStatusName.Text == "�״���Ժ" || m_objViewer.m_lblPStatusName.Text == "�ѳ�Ժ")
            {
                //��ȡ������ʷǷ����Ϣ
                string strResult = "";
                this.m_GetPatientHistoryDebtByInpatientID(m_strInPatientID.Trim(), out strResult);
                this.m_objViewer.m_txtRemark.Text = strResult;
                if (strResult != "")
                {
                    MessageBox.Show(this.m_objViewer, "ע��ò�����δ���ʼ�¼", "��ʾ!!");
                }
            }
        }
        #endregion

        #region ���벡�˵�ת��Ϣ
        /// <summary>
        /// ���벡�˵�ת��Ϣ
        /// </summary>
        public void LoadBihTransfer()
        {
            if (m_strRegisterID.Trim() == "") return;

            clsT_Opr_Bih_Transfer_VO[] objResultArr = null;
            long lngReg = 0;
            string strSQLFilter = "AND(1=0 ";
            if (m_objViewer.m_ckbInhospital.Checked)
            {
                strSQLFilter += "or a.type_int = 5";
            }
            if (m_objViewer.m_ckbOutHospital.Checked)
            {
                strSQLFilter += " or a.type_int = 6";
            }
            //			if(m_objViewer.m_ckbTraDept.Checked)
            //			{
            //				strSQLFilter+=" or a.type_int = 1";
            //			}
            if (m_objViewer.m_ckbTraBed.Checked)
            {
                strSQLFilter += " or a.type_int = 2";
            }
            if (m_objViewer.m_ckbTraDEPTAndBED.Checked)
            {
                strSQLFilter += " or a.type_int = 3";
            }
            strSQLFilter += " or 0=1)";
            if (m_objViewer.m_rdbCurrent.Checked)
            {
                //��ʾ��ǰסԺ��ת��Ϣ
                lngReg = m_objRegister.m_lngGetBinTransferByRegisterID(m_strRegisterID, strSQLFilter, out objResultArr, 0);
            }
            else
            {
                //��ʾ��ʷסԺ��ת��Ϣ
                lngReg = m_objRegister.m_lngGetBinTransferByRegisterID(m_strInPatientID, strSQLFilter, out objResultArr, 1);
            }
            if (lngReg <= 0 || objResultArr == null || objResultArr.Length == 0)
                return;

            ListViewItem lviTemp = null;

            int intTem = 0;
            m_objViewer.m_lsvBihTransfer.Items.Clear();
            for (int i1 = 0; i1 < objResultArr.Length; i1++)
            {
                //סԺ������
                try
                {
                    intTem = Convert.ToInt16(objResultArr[i1].m_strINPATIENTCOUNT_INT);
                }
                catch
                {
                    intTem = 1;
                }
                lviTemp = new ListViewItem("��" + objResultArr[i1].m_strINPATIENTCOUNT_INT + "��סԺ");
                //�������� {��תʱ��}
                lviTemp.SubItems.Add(Convert.ToDateTime(objResultArr[i1].m_strMODIFY_DAT).ToString("yyyy��MM��dd�� HHʱmm��"));
                //�������� {1ת�ơ�2������3ת��+������4��Ժ�ٻ�}
                lviTemp.SubItems.Add(objResultArr[i1].m_strTypeName);
                //ԭ���ҡ�ԭ������ԭ����
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceBedNo);
                //Ŀ����ҡ�Ŀ�겡����Ŀ�겡��
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetBedNo);
                //������
                lviTemp.SubItems.Add(objResultArr[i1].m_strOperatorName);
                //��ע
                lviTemp.SubItems.Add(objResultArr[i1].m_strDES_VCHR);
                //��Ժ�Ǽ�ID
                lviTemp.SubItems.Add(objResultArr[i1].m_strREGISTERID_CHR);
                //���� Tag����[��ˮ��]
                lviTemp.Tag = objResultArr[i1].m_strTRANSFERID_CHR;
                if (!m_objViewer.m_rdbCurrent.Checked)
                {
                    lviTemp.ForeColor = clsColor.m_ColorByInt((intTem - 1) % clsColor.Count);
                }
                m_objViewer.m_lsvBihTransfer.Items.Add(lviTemp);
            }
        }
        #endregion

        #region �����Ժ��Ϣ
        /// <summary>
        /// �����Ժ��Ϣ
        /// </summary>
        public void LoadBihLeave()
        {
            //���
            if (m_objViewer.m_txtINPATIENTID_CHR.Text.Trim() == "") return;

            clsT_Opr_Bih_Leave_VO[] objResultArr = null;
            long lngReg = m_objRegister.m_lngGetBihLeaveByInpatientID(m_objViewer.m_txtINPATIENTID_CHR.Text.Trim(), out objResultArr);
            if (lngReg <= 0 || objResultArr == null || objResultArr.Length == 0)
                return;

            ListViewItem lviTemp = null;

            int intTem = 0;
            m_objViewer.m_lsvBihLeave.Items.Clear();
            for (int i1 = 0; i1 < objResultArr.Length; i1++)
            {
                //סԺ������
                intTem = m_objRegister.m_intGetBihOrderByRegisterID(objResultArr[i1].m_strREGISTERID_CHR);
                lviTemp = new ListViewItem("��" + intTem.ToString() + "��סԺ");
                //�������� {��Ժʱ��}
                lviTemp.SubItems.Add(Convert.ToDateTime(objResultArr[i1].m_strMODIFY_DAT).ToString("yyyy��MM��dd�� HHʱmm��"));
                //����
                lviTemp.SubItems.Add(objResultArr[i1].m_strTYPE_INT);
                //��Ժ���ҡ���Ժ��������Ժ����
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutBedNo);
                //������
                lviTemp.SubItems.Add(objResultArr[i1].m_strOperatorName);
                //��ע
                lviTemp.SubItems.Add(objResultArr[i1].m_strDES_VCHR);
                //���� Tag����[��ˮ��]
                lviTemp.Tag = objResultArr[i1].m_strLEAVEID_CHR;
                lviTemp.ForeColor = clsColor.m_ColorByInt((intTem - 1) % clsColor.Count);
                m_objViewer.m_lsvBihLeave.Items.Add(lviTemp);
            }
        }
        #endregion

        #region ����Ԥ�������   ��Ϊ���÷��ô���
        //		/// <summary>
        //		/// ����Ԥ�������
        //		/// </summary>
        //		/// <param name="m_strREGISTERID">��Ժ�Ǽ���ˮ��</param>
        //		private void LoadBalanceMoney(string m_strREGISTERID)
        //		{
        ////			m_objViewer.m_txtMONEY_DEC.Text ="";
        //			double p_dblBalanceMoney =0;
        //			long lngReg =m_objRegister.m_lngGetBalanceMoneyByRegisterID(m_strREGISTERID,out p_dblBalanceMoney);
        ////			m_objViewer.m_txtMONEY_DEC.Text =p_dblBalanceMoney.ToString("0.00");
        ////			m_objViewer.m_txtMONEY_DEC.ReadOnly = true;
        ////			this.m_objViewer.m_txtPREPAYINV_VCHR.ReadOnly = true;
        //		}
        #endregion

        #region ����סԺ�Ų�ѯ������ʷǷ����Ϣ
        public void m_GetPatientHistoryDebtByInpatientID(string InPatientID, out string strResult)
        {
            strResult = "";
            string[] registeridArr;
            long lngRes = m_objRegister.m_lngGetRegisteridByInpatientID(InPatientID, out registeridArr);
            if (registeridArr.Length > 0)
            {
                string strDebt = "";
                for (int i = 0; i < registeridArr.Length; i++)
                {
                    int a = i + 1;
                    lngRes = new clsDcl_StatQuery().m_lngGetPatientDebtByRegisterID(registeridArr[i], out strDebt);
                    if (strDebt != "")
                    {
                        strResult += "��" + a.ToString() + "סԺǷ��:" + strDebt;
                    }
                }
            }
            if (strResult.Length > 200)
            {
                strResult = strResult.Substring(0, 200);
            }
        }
        #endregion

        #endregion

        #region ������Ժ�Ǽ�
        /// <summary>
        /// ������Ժ�Ǽ�
        /// </summary>
        public void m_mthSaveRegister()
        {
            if (objsystempower.isHasRight("סԺ.����ת.��Ժ"))
            {
                long lngReg = 0;
                //������֤
                if (!IsPassValidate())
                {
                    return;
                }
                clsRegisterParameterVO p_objParaVO = new clsRegisterParameterVO();
                clsPatient_VO objPatientVO;
                clsT_Opr_Bih_Register_VO objBIHVO;
                clsT_opr_bih_prepay_VO p_objPay;
                ValueToVoForBaseInfo(out objPatientVO);

                //��ѯ��ʷ��Ϣ
                if (m_intFlag == 1)
                {
                    clsPatient_VO objPatientCopy = new clsPatient_VO();
                    objPatientVO.m_mthClone(objPatientCopy);
                    frmFindPatient findPat = new frmFindPatient(ref objPatientCopy);
                    long ret = findPat.InitView();
                    if (ret > 0)
                    {
                        findPat.ShowDialog();

                        if (findPat.DialogResult == DialogResult.Cancel)
                        {
                            this.m_objViewer.txtPatientName.Focus();
                            return;
                        }
                        else if (findPat.DialogResult == DialogResult.OK)
                        {
                            objPatientVO = objPatientCopy;
                            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;

                            //m_mthFindPatientInfoByPatientID();
                            FindPatientInfoByPatientID();

                            ValueToVoForBaseInfo(out objPatientVO);
                            m_intFlag = 2;
                        }
                    }
                }

                if (!ValueToVoForBIHInfo(out objBIHVO))
                {
                    return;
                }
                if (!m_blnprepay(out p_objPay))
                {
                    return;
                }
                // ͬ�����(�ѱ�)2018-04-23
                objPatientVO.m_strPAYTYPEID_CHR = objBIHVO.m_strPAYTYPEID_CHR;
                try
                {
                    if (m_intFlag == 2)
                    {
                        if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0 && m_strInPatientID != "")
                        {
                            m_blnNewInPatienID = false;
                            objBIHVO.m_strINPATIENTID_CHR = m_strInPatientID;
                            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
                        }
                        else if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 1 && m_strINPATIENTTEMPID != "")
                        {
                            m_blnNewInPatienID = false;
                            objBIHVO.m_strINPATIENTID_CHR = m_strINPATIENTTEMPID;
                            objPatientVO.m_strINPATIENTTEMPID_VCHR = m_strINPATIENTTEMPID;
                        }
                    }

                    if (m_blnNewInPatienID)
                    {
                        CreateInpatientNo m_objfrm = new CreateInpatientNo(m_objViewer.m_cboInpatientNoType.SelectedIndex + 1);
                        m_objfrm.m_intCreatNOFlag = m_disCreatNOFlag;
                        m_objfrm.ShowDialog();
                        if (m_objfrm.DialogResult == DialogResult.OK)
                        {
                            p_objParaVO.m_intFlag = 1;
                            objBIHVO.m_strINPATIENTID_CHR = m_objfrm.m_strGetInpatientid_chr(out p_objParaVO.m_strHeardFlag, out p_objParaVO.m_intSourse);
                            if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                            {
                                objPatientVO.m_strINPATIENTID_CHR = objBIHVO.m_strINPATIENTID_CHR;
                            }
                            else
                            {
                                objPatientVO.m_strINPATIENTTEMPID_VCHR = objBIHVO.m_strINPATIENTID_CHR;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    m_objViewer.Cursor = Cursors.WaitCursor;
                    p_objParaVO.m_intIsNewPatient = m_intNewPatient;
                    lngReg = m_objTran.m_lngPatientRegister(p_objParaVO, objPatientVO, p_objPay, ref objBIHVO);
                    if (lngReg > 0)
                    {
                        #region ˳��ҽ������ͬ��
                        ArrayList PayTypeArr = clsPublic.m_mthGetYBPayID();
                        if (clsPublic.m_strGetSysparm("1000") == "003" && PayTypeArr.IndexOf(m_objViewer.m_txtPaytype.Value) != -1)
                        {
                            objBIHVO.m_strAreaName = this.m_objViewer.m_txtAREAID.Text.Trim();
                            clsCtl_Report objRep = new clsCtl_Report();
                            objRep.m_mthBihRegister_SDYB(objPatientVO, objBIHVO);
                        }
                        #endregion

                        frmInPatientIDAlert frmInPatientID = new frmInPatientIDAlert(objBIHVO.m_strINPATIENTID_CHR);
                        frmInPatientID.ShowDialog();
                        //m_EmptyAndInitialization();

                        if (this.m_disPrepayFalg == 0)
                        {
                            m_mthPrintPay(p_objPay.m_dblMONEY_DEC, objBIHVO.m_strBEDID_CHR); //�˴��Ĵ�λIDΪԤ�����¼ID
                        }

                        m_objViewer.m_strRegisterID = objBIHVO.m_strREGISTERID_CHR;
                        m_objViewer.DialogResult = DialogResult.OK;
                        //����Ƕ��ʽ�籣���õǼǴ���
                        if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
                        {
                            if (MessageBox.Show("�˲��������籣���ˣ��Ƿ�Ҫ�����籣�Ǽǣ�", "��Ժ�Ǽ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                m_mthYBPatient();
                            }
                        }
                        m_EmptyAndInitialization();

                        #region �ж�����ת��δ���Ѵ�����ʾ����
                        System.Collections.Generic.List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO = new System.Collections.Generic.List<clsRecipeNoPay_VO>();
                        lngReg = m_objTran.m_lngGetPatientRecipeNopay(objBIHVO.m_strINPATIENTID_CHR, 1, out m_lstRecipeNoPay_VO);
                        if (m_lstRecipeNoPay_VO.Count > 0)
                        {
                            frmPatientRecipeNoPay objfrmPatientRec = new frmPatientRecipeNoPay(objBIHVO.m_strINPATIENTID_CHR, 1, m_lstRecipeNoPay_VO);
                            objfrmPatientRec.ShowDialog();
                        }

                        #endregion


                    }
                    else if (lngReg == -2)
                    {
                        MessageBox.Show("סԺ���ѱ�ռ�ã�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //m_SaveInfo();
                    }
                    else if (lngReg == -3)
                    {
                        MessageBox.Show("�ò����Ѿ���Ժ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("��Ժʧ�ܣ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Trim() == "0") //������Ժ�ǼǼ�¼ʱʧ��,����סԺ�ѱ�ռ�ã�
                    {
                        if (MessageBox.Show("����ʧ�ܣ�", "��Ժ�Ǽ�", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry)
                        {
                            //m_mthSaveRegister();
                            MessageBox.Show(e.Message, "������Ժ�ǼǼ�¼ʱʧ��,�����ԣ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    m_blnNewInPatienID = true;
                    p_objParaVO = null;
                    objPatientVO = null;
                    objBIHVO = null;
                    p_objPay = null;
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "���]��Ȩ��");
            }
        }
        #endregion

        #region �ؼ���ֵ��Vo
        /// <summary>
        /// �ؼ���ֵ��Vo {������}
        /// </summary>
        /// <param name="objPatientVO">[out ����]</param>
        private void ValueToVoForIndexInfo(out clsclsPatientIdxVO objPatientVO)
        {
            objPatientVO = new clsclsPatientIdxVO();
            //���˱��
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //סԺ���
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //���֤��
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //��ͥסַ
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //�Ա�
            objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //��������
            try
            {
                objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //��������
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //��ϵ�绰
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //ҽ�����
            objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
        }
        /// <summary>
        /// �ؼ���ֵ��Vo {������Ϣ}
        /// </summary>
        /// <param name="objPatientVO">[out ����]</param>
        private void ValueToVoForBaseInfo(out clsPatient_VO objPatientVO)
        {
            objPatientVO = new clsPatient_VO();
            //���˱��
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //ҽ�����
            objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
            //��������
            try
            {
                objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //���֤�� 
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //�������� 
            objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName.Text;
            objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName.Text;
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //��ϵ�绰 
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //�Ա� 
            objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //�������
            //objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPatiemtType.Value;
            //סԺ���
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //���ۺ�
            objPatientVO.m_strINPATIENTTEMPID_VCHR = m_strINPATIENTTEMPID;
            //�Ƿ�Ա��
            objPatientVO.m_intISEMPLOYEE_INT = m_objViewer.cboIsemployee.SelectedIndex;
            //��� 
            objPatientVO.m_strMARRIED_CHR = (string)m_objViewer.cobMarried.SelectedValue;
            //�ƶ��绰 
            objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //�������� 
            objPatientVO.m_strFIRSTDATE_DAT = m_objViewer.dtpFirstDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //��Ч״̬ {1����Ч��0����Ч��-1����ʷ}
            objPatientVO.m_intSTATUS_INT = 1;
            //��ͥסַ 
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //����
            objPatientVO.m_strNATIONALITY_VCHR = (string)m_objViewer.txtNationality.SelectedValue;
            //���� 
            objPatientVO.m_strRACE_VCHR = m_objViewer.m_txtRace.Text;
            //���� 
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text;
            //ְҵ 
            objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.m_txtOccupation.Text.Trim();
            //������Դ
            objPatientVO.m_strPatientSource = (string)m_objViewer.m_cboPatientSource.SelectedValue;
            //��ַ�ʱ� 
            objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc.Text;
            //������ 
            objPatientVO.m_strBIRTHPLACE_VCHR = m_objViewer.txtBirthPlace.Text;
            //��ϵ������ 
            objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            //��ϵ�˵绰 
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone.Text;
            //��ϵ���ʱ� 
            objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //����ϵ�˹�ϵ 
            objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.m_txtRelation.Text.Trim();
            //��ϵ�˵�ַ 
            objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress.Text;
            //�칫�绰 
            objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //�칫�ʱ� 
            objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc.Text;
            //������λ 
            objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer.Text;
            //�������� 
            objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //�칫��ַ
            objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress.Text;
            //������Ա
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //��������
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text.Trim();
            objPatientVO.m_strGOVCARD_CHR = m_objViewer.m_txtGOVCARD_CHR.Text.Trim();

            if (this.m_objViewer.m_txtInsuredMoney.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredMoney = Convert.ToDecimal(this.m_objViewer.m_txtInsuredMoney.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredMoney = 0;
            }
            if (this.m_objViewer.m_txtInsuredPayTime.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredPayTime = Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayTime.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredPayTime = 0;
            }
            if (this.m_objViewer.m_txtInsuredPayMoney.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredPayMoney = Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayMoney.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredPayMoney = 0;
            }
            objPatientVO.m_strResidencePlace = this.m_objViewer.txtResidenceplace.Text.Trim();
            objPatientVO.ConsigneeAddr = this.m_objViewer.txtConsigneeAddr.Text.Trim();
        }
        /// <summary>
        /// �ؼ���ֵ��Vo {סԺ��Ϣ}
        /// </summary>
        /// <param name="objPatientVO">[out ����]</param>
        private bool ValueToVoForBIHInfo(out clsT_Opr_Bih_Register_VO objPatientVO)
        {
            objPatientVO = new clsT_Opr_Bih_Register_VO();

            //��Ժ�Ǽ���ˮ��(200409010001)
            objPatientVO.m_strREGISTERID_CHR = m_strRegisterID;
            //���ˣɣ�
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //�Ƿ�ԤԼ
            objPatientVO.m_intISBOOKING_INT = Convert.ToInt16(m_objViewer.m_chkISBOOKING_INT.Checked);
            //סԺ��
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;

            if (m_objViewer.m_dateInHosp.Value > DateTime.Now)
            {
                MessageBox.Show("��Ժ���ڲ��ܴ��ڵ�ǰϵͳʱ�䣬���޸ģ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_dateInHosp.Focus();
                return false;
            }
            else
            {
                objPatientVO.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            //��Ժ���ҡ���Ժ��������Ժ����
            objPatientVO.m_strDEPTID_CHR = "";
            objPatientVO.m_strBEDID_CHR = "";
            //if(m_objViewer.m_txtDEPTID_CHR.Tag!=null)
            //{
            //    objPatientVO.m_strDEPTID_CHR = ((string)m_objViewer.m_txtDEPTID_CHR.Tag).ToString();
            //}
            string strDeptId;
            m_objTran.GetParentIdByDeptId(m_objViewer.m_txtAREAID.Value, out strDeptId);
            objPatientVO.m_strDEPTID_CHR = strDeptId;

            objPatientVO.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            //��Ժ��ʽ {��������������Ժת��}
            objPatientVO.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT.SelectedIndex + 1;
            //��������
            if (m_objViewer.m_txtLIMITRATE_MNY.Text.Trim() == "")
            {
                objPatientVO.m_dblLIMITRATE_MNY = 0;
            }
            else
            {
                try
                {
                    objPatientVO.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY.Text.Trim());
                    if (objPatientVO.m_dblLIMITRATE_MNY < 0)
                    {
                        MessageBox.Show("�������޲���Ϊ������", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_txtLIMITRATE_MNY.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("�������޲�����Ч����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtLIMITRATE_MNY.Focus();
                    return false;
                }
            }
            //���顡����Σ������������ͨ��
            objPatientVO.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT.SelectedIndex + 1;
            //״̬����������ʷ������Ч������Ч��
            objPatientVO.m_intSTATUS_INT = 1;
            //�����ˡ�����ʱ��
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //������Ժ״̬	{0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
            objPatientVO.m_intPSTATUS_INT = 0;
            //סԺ������
            objPatientVO.m_intINPATIENTNOTYPE_INT = m_objViewer.m_cboInpatientNoType.SelectedIndex + 1;
            //����ҽ��]
            objPatientVO.m_strMZDOCTOR_CHR = m_objViewer.m_txtMaindoctor.Value;

            //����ҽ�������Ŀ���
            DataTable dt;
            long lngReg = m_objTran.GetDeptByEmpID(m_objViewer.m_txtMaindoctor.Value, out dt);
            if (lngReg > 0 && dt.Rows.Count > 0)
            {
                objPatientVO.m_strCaseDoctorDept = dt.Rows[0]["DEPTID_CHR"].ToString();
            }

            objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPaytype.Value;
            // �������
            objPatientVO.m_strMZDIAGNOSE_VCHR = m_objViewer.m_txtMZDiagnose.Text.Trim();
            //��ע
            objPatientVO.DES_VCHR = m_objViewer.m_txtRemark.Text.Trim();

            return true;
        }
        #endregion

        #region ��ת
        /// <summary>
        /// ��ת
        /// </summary>
        public void m_BihTransfer()
        {
            //��ת	{1���ճ�ԭ���Ĵ�λ��2��ռ����ת�Ĵ�λ��3�����ӵ�ת��¼��4���޸���Ժ�ǼǵĲ�����Ϣ��}
            frmBIHTransfer objfrmBIHTransfer = new frmBIHTransfer(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //��ʾ��Ϣ
            objfrmBIHTransfer.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//Դ����
            objfrmBIHTransfer.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//Դ����
            objfrmBIHTransfer.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;//��������
            //��ʼ��Ĭ��ֵ
            //			objfrmBIHTransfer.m_txtDEPTID_CHR.Text =m_objViewer.m_txtDEPTID_CHR.Text;
            //			objfrmBIHTransfer.m_txtDEPTID_CHR.Tag =(string)m_objViewer.m_txtDEPTID_CHR.Tag;
            objfrmBIHTransfer.m_txtAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;
            objfrmBIHTransfer.m_txtAREAID_CHR.Tag = (string)m_objViewer.m_txtAREAID.Tag;
            //			objfrmBIHTransfer.m_cbmTYPE.SelectedIndex =1;//ת��+����
            //			objfrmBIHTransfer.m_txtBEDID_CHR.Text =string.Empty;
            //			objfrmBIHTransfer.m_txtBEDID_CHR.Value =string.Empty;
            objfrmBIHTransfer.ShowDialog();
            //����סԺ��Ϣ[����סԺ��]
            LoadBihRegister();
            //���벡�˵�ת��Ϣ
            LoadBihTransfer();
        }
        #endregion

        #region ��Ժ�ٻ�
        /// <summary>
        /// ��Ժ�ٻ�
        /// </summary>
        public void m_BihRecall()
        {
            //��Ժ�ٻ�	{1��ɾ����Ժ��¼��2��ռ���´�λ��3������סԺ��ת��¼��4���޸���Ժ�ǼǵĲ�����Ϣ��}
            frmBIHRecall objfrmBIHRecall = new frmBIHRecall(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //��ʾ��Ϣ
            objfrmBIHRecall.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//��Ժ����
            objfrmBIHRecall.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//��Ժ����
            objfrmBIHRecall.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;//��������
            //��ʼ��Ĭ��ֵ
            objfrmBIHRecall.m_txtAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;
            objfrmBIHRecall.m_txtAREAID_CHR.Tag = (string)m_objViewer.m_txtAREAID.Tag;
            objfrmBIHRecall.ShowDialog();
            //����סԺ��Ϣ[����סԺ��]
            LoadBihRegister();
            //���벡�˵�ת��Ϣ
            LoadBihTransfer();
            //�����Ժ��Ϣ
            LoadBihLeave();
        }
        #endregion

        #region ��Ժ
        /// <summary>
        /// ��Ժ
        /// </summary>
        public void m_BihLeave()
        {
            //��Ժ	{1���ճ���λ��2������һ����Ժ��¼��}
            frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //��ʾ��Ϣ
            objfrmBIHLeave.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;	//��������
            objfrmBIHLeave.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//��Ժ����
            objfrmBIHLeave.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//��Ժ����
            objfrmBIHLeave.m_cbmPSTATUS_INT.SelectedIndex = 2;	//ʵ�ʳ�Ժ
            objfrmBIHLeave.m_cbmTYPE.SelectedIndex = 1;			//������Ժ
            objfrmBIHLeave.ShowDialog();
            //����סԺ��Ϣ[����סԺ��]
            LoadBihRegister();
            //���벡�˵�ת��Ϣ
            LoadBihTransfer();
            //�����Ժ��Ϣ
            LoadBihLeave();
        }
        #endregion

        #region ��ѯͬ������ͬʱ����������Ϣ,���û��ͬ��������������˵Ǽ�
        /// <summary>
        /// ��ѯͬ������ͬʱ����������Ϣ,���û��ͬ��������������˵Ǽ�
        /// </summary>
        public void m_mthFindPatientInfoByName()
        {
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show("������������Ϊ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtPatientName.Focus();
            }
            else
            {
                m_objViewer.Cursor = Cursors.WaitCursor;
                frmCommonFind frm = new frmCommonFind();
                frm.IsBihReg = true;
                if (frm.m_intFindByNameSexType(m_objViewer.txtPatientName.Text.Trim(), m_objViewer.cboSex.SelectedValue.ToString(), m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, false, true) > 0)
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        m_strPatientID = frm.PatientID;
                        m_mthFindPatientInfoByPatientID();
                    }
                    else
                    {
                        m_objViewer.m_dtpBirthDate.Focus();
                    }
                    frm = null;
                    m_objViewer.Cursor = Cursors.Default;
                }
                else
                {
                    m_objViewer.Cursor = Cursors.Default;
                    m_objViewer.m_dtpBirthDate.Focus();
                }
            }
        }
        #endregion

        #region Ԥ������
        /// <summary>
        /// Ԥ������
        /// </summary>
        /// <returns></returns>
        public bool m_blnprepay(out clsT_opr_bih_prepay_VO objItem)
        {
            objItem = new clsT_opr_bih_prepay_VO();
            if (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "")
            {
                objItem.m_dblMONEY_DEC = 0;
                return true;
            }
            objItem.m_dblMONEY_DEC = double.Parse(m_objViewer.m_txtMONEY_DEC.Text.Trim());
            if (objItem.m_dblMONEY_DEC == 0)
            {
                objItem.m_dblMONEY_DEC = 0;
                return true;
            }
            else if (objItem.m_dblMONEY_DEC < 0)
            {
                MessageBox.Show("Ԥ������Ϊ������", "Ԥ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (new frmPrepayAlert(m_objViewer.m_cboCUYCATE_INT.Text.Substring(2, m_objViewer.m_cboCUYCATE_INT.Text.Length - 2), CurrencyToString(objItem.m_dblMONEY_DEC)).ShowDialog() != DialogResult.OK)
            {
                m_objViewer.m_txtMONEY_DEC.Focus();
                m_objViewer.m_txtMONEY_DEC.SelectAll();
                return false;
            }

            Regex r = new Regex(clsPublic.m_strReadXML("BeInHospital", "PrepayBillNoExp", "AnyOne"));
            Match m = r.Match(m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim());
            if (!m.Success)
            {
                MessageBox.Show("��ǰԤ�����վݵı�Ź�����ȷ������ϸ��顣", "Ԥ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPREPAYINV_VCHR.Focus();
                m_objViewer.m_txtPREPAYINV_VCHR.SelectAll();
                return false;
            }

            //if (new clsBIHChargeSvc().m_lngCheckInvoiceNO(objPrincipal, m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim()) > 0)
            if (clsPublic.m_blnCheckPrepayNoIsUsed(this.m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim(), 0))
            {
                MessageBox.Show("��Ʊ���ظ���", "Ԥ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPREPAYINV_VCHR.Focus();
                m_objViewer.m_txtPREPAYINV_VCHR.SelectAll();
                return false;
            }

            objItem.m_strPREPAYINV_VCHR = m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim();
            objItem.m_strPATIENTID_CHR = m_strPatientID;
            objItem.m_strPatientName = m_objViewer.txtPatientName.Text.Trim();
            objItem.m_strREGISTERID_CHR = m_strRegisterID;
            objItem.m_intLINER_INT = 1;
            objItem.m_intPAYTYPE_INT = 1;
            objItem.m_intCUYCATE_INT = m_objViewer.m_cboCUYCATE_INT.SelectedIndex + 1;
            objItem.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            objItem.m_strPRESSNO_VCHR = m_objViewer.m_txtPREPAYINV_VCHR.Text;
            objItem.m_strAreaName = m_objViewer.m_txtAREAID.Text.Trim();
            objItem.m_strDES_VCHR = m_objViewer.m_txtRemark.Text.Trim();
            objItem.m_strCREATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID.Trim();
            objItem.m_strCREATE_DAT = System.DateTime.Now.ToString();
            objItem.m_intSTATUS_INT = 1;
            objItem.m_intISCLEAR_INT = 0;
            objItem.m_intUPTYPE_INT = 0;
            objItem.m_strPatientName = m_objViewer.txtPatientName.Text.Trim();
            objItem.m_strAreaName = m_objViewer.m_txtAREAID.Text.Trim();
            objItem.m_intBALANCEFLAG_INT = 0;
            return true;
        }
        /// <summary>
        /// ��ȡ��Ʊ��
        /// </summary>
        public void m_strReadInvoiceNO()
        {
            try
            {
                //string m_strPrepayBillNo = clsPublic.m_strReadXML("BeInHospital", "CurrPrepayBillNo", "AnyOne");
                //m_objViewer.m_txtPREPAYINV_VCHR.Text = Convert.ToString(int.Parse(m_strPrepayBillNo) + 1).PadLeft(m_strPrepayBillNo.Length,'0');

                string m_strPrepayBillNo = clsPublic.m_strGetCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, 2);
                m_objViewer.m_txtPREPAYINV_VCHR.Text = m_strPrepayBillNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ȡ��Ʊ��ʧ��");
            }
        }
        /// <summary>
        /// ���淢Ʊ��
        /// </summary>
        /// <param name="strInvoiceNO"></param>
        public void m_mthSaveInvoiceNO()
        {
            //try
            //{
            //    clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("\t���淢Ʊ��ʧ��,\n����\"" + Application.StartupPath + "\\LoginFile.xml\"�Ƿ�ֻ��!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim(), 2);
        }
        /// <summary>
        /// ��ӡԤ����
        /// </summary>
        private void m_mthPrintPay(double p_dblMoney, string p_strPrepayID)
        {
            if (p_dblMoney > 0)
            {
                m_mthSaveInvoiceNO();
                m_strReadInvoiceNO();
                if (this.m_objViewer.m_cobPrint.SelectedIndex == 0)//{0=��Ԥ��-��ӡ;1=����ӡ}
                {
                    try
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(p_strPrepayID, "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "��ӡԤ����ʧ��");
                    }
                }
            }
        }
        /// <summary>
        /// Ԥ���𽹵�����
        /// </summary>
        public void m_mthSetFocus()
        {
            if (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "" || m_objViewer.m_txtMONEY_DEC.Text.Trim() == "0")
            {
                m_objViewer.cmdSaveBihRegister.Focus();
            }
            else
            {
                try
                {
                    decimal decMoney = Convert.ToDecimal(m_objViewer.m_txtMONEY_DEC.Text.Trim());
                    if (decMoney < 0)
                    {
                        MessageBox.Show("Ԥ������Ϊ������", " Ԥ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_txtMONEY_DEC.Focus();
                    }
                    m_objViewer.m_txtMONEY_DEC.Text = decMoney.ToString("0.00");
                }
                catch
                {
                    MessageBox.Show("Ԥ��������Ч���֣�", " Ԥ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtMONEY_DEC.Focus();
                    m_objViewer.m_txtMONEY_DEC.SelectAll();
                }
            }
        }
        #endregion

        #region ������ת�������Ĵ�д
        private static string[] cstr = { "��", "Ҽ", "��", "��", "��", "��", "½", "��", "��", "��" };
        private static string[] wstr = { "��", "��", "Բ", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ" };
        /// <summary>
        /// ������ת�������Ĵ�д
        /// </summary>
        /// <param name="fltCurrency"></param>
        /// <returns></returns>
        public string CurrencyToString(double fltCurrency)
        {
            string str = fltCurrency.ToString("0.00");
            str = str.Replace(".", "");
            int len = str.Length;
            int i;
            string tmpstr, rstr;
            rstr = "";
            for (i = 1; i <= len; i++)
            {
                tmpstr = str.Substring(len - i, 1);
                rstr = string.Concat(cstr[Int32.Parse(tmpstr)] + wstr[i - 1], rstr);
            }
            rstr = rstr.Replace("ʰ��", "ʰ");
            rstr = rstr.Replace("��ʰ", "��");
            rstr = rstr.Replace("���", "��");
            rstr = rstr.Replace("��Ǫ", "��");
            rstr = rstr.Replace("����", "��");
            for (i = 1; i <= 6; i++)
                rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("����", "�|");
            rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("������", "");
            rstr = rstr.Replace("���", "");
            rstr += "��";
            rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("��Բ", "Բ");
            rstr = rstr.Replace("���", "��");
            return rstr;
        }
        #endregion

        #region ���ݲ������ƿ��Ż�סԺ�Ż�ȡ����ID
        /// <summary>
        /// ���ݲ������ƿ��Ż�סԺ�Ż�ȡ����ID
        /// </summary>
        public void m_mthGetPatientIDByCarIDOrInPatientID()
        {
            if (m_objViewer.m_txtFindText.Text.Trim() != "")
            {
                if (m_objViewer.m_cmbFindType.SelectedIndex == 0)
                {
                    m_objViewer.m_txtFindText.Text = m_objViewer.m_txtFindText.Text.Trim().PadLeft(10, '0');
                }
                try
                {
                    string p_strPatientID;
                    long lngRes = m_objTran.m_lngGetPatientIDByCarIDOrInPatientID(m_objViewer.m_cmbFindType.SelectedIndex, m_objViewer.m_txtFindText.Text.Trim(), out p_strPatientID);
                    if (lngRes > 0 && p_strPatientID != "")
                    {
                        m_strPatientID = p_strPatientID;
                        m_mthFindPatientInfoByPatientID();
                    }
                    else if (this.m_objViewer.m_cmbFindType.SelectedIndex == 2)
                    {
                        #region ���籣��ȡ����
                        if (System.IO.File.Exists(Application.StartupPath + "\\HNBridge.dll"))
                        {
                            clsDGZydj_VO m_objItem = new clsDGZydj_VO();
                            //���˻�����Ϣ
                            clsDGPaitentInfo_VO m_objPatientInfo = new clsDGPaitentInfo_VO();
                            //����������Ϣ
                            List<clsDGJxzlxx_VO> m_objJXzlxx = new List<clsDGJxzlxx_VO>();
                            //�����Ա��Ϣ
                            List<clsDGYdryxx_VO> m_objYDryxx = new List<clsDGYdryxx_VO>();
                            //תԺ��Ϣ
                            List<clsDGZyxx_VO> m_objZYxx = new List<clsDGZyxx_VO>();
                            //���סԺ��Ϣ
                            List<clsDGZjzyxx_VO> m_objZJzyxx = new List<clsDGZjzyxx_VO>();
                            m_objItem.GMSFHM = this.m_objViewer.m_txtFindText.Text.ToString().Trim();
                            m_objItem.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne"); //ҽԺ���
                            m_objItem.CBDTCQBM = "";   //need modify
                            m_objItem.CYKS = this.m_objViewer.LoginInfo.m_strEmpNo; //����Ϊ������
                            lngRes = clsYBPublic_cs.m_lngFunSP1201(m_objItem, out m_objPatientInfo, out m_objJXzlxx, out m_objYDryxx, out m_objZYxx, out m_objZJzyxx);

                            if (lngRes > 0)
                            {
                                this.m_objViewer.txtPatientName.Text = m_objPatientInfo.XM;
                                if (m_objPatientInfo.XB == "1")
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 0;
                                }
                                else if (m_objPatientInfo.XB == "2")
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 1;
                                }
                                else
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 3;
                                }
                                try
                                {
                                    m_objViewer.m_dtpBirthDate.Text = DateTime.ParseExact(m_objPatientInfo.CSNY.Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
                                    m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(DateTime.ParseExact(m_objPatientInfo.CSNY.Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToShortDateString());
                                }
                                catch
                                {
                                    m_objViewer.m_txtAge.Text = m_objPatientInfo.CSNY;
                                    int nowDate = DateTime.Now.Year - Convert.ToInt32(m_objViewer.m_txtAge.Text.Trim());
                                    string strNowDate = nowDate.ToString() + "-01-01";
                                    m_objViewer.m_dtpBirthDate.Text = strNowDate;
                                }
                                this.m_objViewer.txtIDCard.Text = this.m_objViewer.m_txtFindText.Text.ToString().Trim();
                                this.m_objViewer.txtPhone.Text = m_objPatientInfo.LXDH;
                                this.m_objViewer.txtEmployer.Text = m_objPatientInfo.ZZMC;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("�Ҳ����ò�����Ϣ��", "��ѯ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "��ѯ����");
                }
            }
        }
        #endregion

        #region ���ݲ���ID��ȡ���˻�����Ϣ
        /// <summary>
        /// ���ݲ���ID��ȡ���˻�����Ϣ
        /// </summary>
        /// <param name="p_strPatientid">����ID</param>
        /// <returns></returns>
        public void m_mthFindPatientInfoByPatientID()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "�״���Ժ";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("�ò����Ѿ���Ժ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtPatientName.Focus();
                    m_objViewer.txtPatientName.SelectAll();
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "�� " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " ����Ժ";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                }
            }
            clsPatient_VO p_objPatienVO;
            lngRes = m_objTran.m_lngFindPatientInfoByPatientID(m_strPatientID, out p_objPatienVO);
            if (lngRes > 0 && p_objPatienVO.m_strPATIENTID_CHR != "")
            {
                m_objViewer.m_lblPStatusName.Text = m_strInTimes;
                VoToValueForAll(p_objPatienVO);
                m_intNewPatient = 2;
                if (m_intNeedInput == 1)
                {
                    m_objViewer.m_dtpBirthDate.Focus();
                }
                else
                {
                    m_objViewer.m_cboTYPE_INT.Focus();
                }
            }
            else
            {
                MessageBox.Show("�Ҳ����ò�����Ϣ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ���ݲ���ID��ȡ���˻�����Ϣ(ֻ��ȡ��סԺ�ź���Ժ����)
        /// <summary>
        /// ���ݲ���ID��ȡ���˻�����Ϣ
        /// </summary>
        /// <param name="p_strPatientid">����ID</param>
        /// <returns></returns>
        public void FindPatientInfoByPatientID()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "�״���Ժ";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("�ò����Ѿ���Ժ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtPatientName.Focus();
                    m_objViewer.txtPatientName.SelectAll();
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "�� " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " ����Ժ";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }

                    m_objViewer.m_lblPStatusName.Text = m_strInTimes;
                    //VoToValueForAll(p_objPatienVO);
                    m_intNewPatient = 2;
                }
            }
        }
        #endregion

        #region ���÷�������
        /// <summary>
        /// ���÷�������
        /// </summary>
        public void m_mthSetPatType()
        {
            if (m_objViewer.m_txtPaytype.Value != null)
            {
                DataRowView drv = m_objViewer.m_txtPaytype.SelectedItem;
                m_intPatientFlag = Convert.ToInt16(drv["internalflag_int"]);
                m_objViewer.m_txtLIMITRATE_MNY.Text = drv["bihlimitrate_dec"].ToString().Trim();
                if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
                {
                    //m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = true;
                    this.m_objViewer.m_txtInsuredMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                }
                else
                {
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = false;

                    this.m_objViewer.m_txtInsuredMoney.Text = "";
                    this.m_objViewer.m_txtInsuredPayMoney.Text = "";
                    this.m_objViewer.m_txtInsuredPayTime.Text = "";

                    this.m_objViewer.m_txtInsuredMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = false;
                }
            }
        }
        #endregion

        #region ��ʽ���۳���ʱˢ����Ժ����
        /// <summary>
        /// ��ʽ���۳���ʱˢ����Ժ����
        /// </summary>
        public void m_mthFreshInTime()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "�״���Ժ";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("�ò����Ѿ���Ժ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "�� " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " ����Ժ";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                }
            }
            m_objViewer.m_lblPStatusName.Text = m_strInTimes;
        }
        #endregion

        #region ˢ��
        /// <summary>
        /// ˢ��
        /// </summary>
        public void m_mthFresh()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            m_objTran.m_lngGetSetingByID("1006", out m_intNeedInput);
            m_strReadInvoiceNO();
            if (m_strPatientID == "")
            {
                m_EmptyAndInitialization();
            }
            else
            {
                m_mthFindPatientInfoByPatientID();
            }
            m_objViewer.Cursor = Cursors.Default;
        }
        #endregion


        // �����û���������Ŀ���
        #region �����*�Ų���Ϊ�յ���
        /// <summary>
        /// �����*�Ų���Ϊ�յ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManageEmptyItem(object sender, EventArgs e)
        {
            if (sender is ControlLibrary.txtListView)
            {
                if (((ControlLibrary.txtListView)sender).m_listView.SelectedItems.Count < 1)
                {
                    MessageBox.Show("�����Ϊ�գ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            if (m_intNeedInput == 1) //������Ժ�ǼǴ�*�ŵ����Ƿ����:0-�ɲ��� 1-������
            {
                if (sender is ComboBox)
                {
                    if (((ComboBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("�����Ϊ�գ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((ComboBox)sender).Focus();
                    }
                }
                else if (sender is TextBox)
                {
                    if (((TextBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("�����Ϊ�գ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((TextBox)sender).Focus();
                    }
                }
            }
        }
        #endregion

        #region ����ҽ�����˲���Ϊ�յ���
        /// <summary>
        /// ����ҽ�����˲���Ϊ�յ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManagTinsuranceEmpty(object sender, EventArgs e)
        {
            if (m_objViewer.m_txtinsuranceid.Enabled)
            {
                if (sender is TextBox)
                {
                    if (((TextBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("ҽ�����˸����Ϊ�գ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((TextBox)sender).Focus();
                    }
                }
            }
        }
        #endregion

        #region ����ְ�����˲���Ϊ�յ���
        /// <summary>
        /// ����ְ�����˲���Ϊ�յ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManagEmployeeEmpty(object sender, EventArgs e)
        {
            if (m_objViewer.m_txtGOVCARD_CHR.Enabled)
            {
                if (m_objViewer.m_txtGOVCARD_CHR.Text.Trim() == "")
                {
                    MessageBox.Show("ְ��ҽ��֤��Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtGOVCARD_CHR.Focus();
                }
            }
        }
        #endregion

        #region ���֤���������
        /// <summary>
        /// ���֤���������
        /// </summary>
        public void m_mthManageIdentity()
        {
            if (m_intPatientFlag == 2)
            {
                if (m_objViewer.txtIDCard.Text.Trim() == "")
                {
                    MessageBox.Show("ҽ���������֤��Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtIDCard.Focus();
                    return;
                }
            }
            if (m_objViewer.txtIDCard.Text.Trim() != "")
            {
                //if (m_objViewer.txtIDCard.Text.Trim().Length == 15 || m_objViewer.txtIDCard.Text.Trim().Length == 18)
                //{
                //    Regex objReg = new Regex("^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$");
                //    Match objMat = objReg.Match(m_objViewer.txtIDCard.Text.Trim());
                //    if (!objMat.Success)
                //    {
                //        MessageBox.Show("��������Ч���֤�ţ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        m_objViewer.txtIDCard.Focus();
                //        return;
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("��ע�⣺���֤�Ų���18λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (m_objViewer.txtIDCard.Text.Length == 15)
            {
                string birthdate;
                birthdate = m_objViewer.txtIDCard.Text.Substring(6, 6);
                birthdate = "19" + birthdate.Substring(0, 2) + "-" + birthdate.Substring(2, 2) + "-" + birthdate.Substring(4, 2);
                m_objViewer.m_dtpBirthDate.Text = birthdate;
            }
            else if (m_objViewer.txtIDCard.Text.Length == 18)
            {
                string birthdate;
                birthdate = m_objViewer.txtIDCard.Text.Substring(6, 8);
                birthdate = birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2);
                m_objViewer.m_dtpBirthDate.Text = birthdate;
            }
        }
        #endregion

        #region �Լ�ͥ��ַ�������
        /// <summary>
        /// �Լ�ͥ��ַ�������
        /// </summary>
        public void m_mthAddressIdentity()
        {
            if (m_intNeedInput == 1)
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("��ͥ��ַΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return;
                }
            }
            if (m_objViewer.m_txtinsuranceid.Enabled)
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("ҽ�����˼�ͥ��ַΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                }
            }
        }
        #endregion

        #region ����ʱ���û�������֤
        /// <summary>
        /// ����ʱ���û�������֤
        /// </summary>
        /// <returns></returns>
        private bool IsPassValidate()
        {
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "��������Ϊ������!", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtPatientName.Focus();
                return false;
            }
            try
            {
                DateTime tempDate = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text);
            }
            catch
            {
                MessageBox.Show("��������Ч�������ڣ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_dtpBirthDate.Focus();
                return false;
            }
            //if (m_objViewer.m_txtPatiemtType.Value == null)
            //{
            //    MessageBox.Show("���Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.m_txtPatiemtType.Focus();
            //    return false;
            //}
            if (m_objViewer.m_cboPatientSource.Text.Trim() == "" || m_objViewer.m_cboPatientSource.Text.Trim() == null)
            {
                MessageBox.Show("������ԴΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_cboPatientSource.Focus();
                return false;
            }
            if (m_objViewer.m_txtPaytype.Value == null)
            {
                MessageBox.Show("�շ�����Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPaytype.Focus();
                return false;
            }
            if (m_objViewer.txtIDCard.Text.Trim() != "")
            {
                //if (m_objViewer.txtIDCard.Text.Trim().Length == 15 || m_objViewer.txtIDCard.Text.Trim().Length == 18)
                //{
                //    Regex objReg = new Regex("^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$");
                //    Match objMat = objReg.Match(m_objViewer.txtIDCard.Text.Trim());
                //    if (!objMat.Success)
                //    {
                //        MessageBox.Show("��������Ч���֤�ţ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        m_objViewer.txtIDCard.Focus();
                //        return false;
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("��ע�⣺���֤�Ų���18λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (m_objViewer.txtPatientName.Text != m_objViewer.txtContactpersonFirstaName.Text && m_objViewer.m_txtRelation.Text == "")
            {
                MessageBox.Show("��ϵ�˷Ǳ��ˣ����޸Ĺ�ϵ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtRelation.Focus();
                return false;
            }
            if (m_objViewer.m_txtAREAID.Value == null || m_objViewer.m_txtAREAID.Text == string.Empty)
            {
                MessageBox.Show("����Ϊ������!", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtAREAID.Focus();
                return false;
            }
            if (m_objViewer.m_txtMaindoctor.Value == null || m_objViewer.m_txtMaindoctor.Text == string.Empty)
            {
                MessageBox.Show("����ҽ��Ϊ������!", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtMaindoctor.Focus();
                return false;
            }

            if (m_intNeedInput == 1)  //������Ժ�ǼǴ�*�ŵ����Ƿ����:0-�ɲ��� 1-������
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("��ͥ��ַΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return false;
                }
            }

            if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
            {
                if (m_objViewer.m_txtinsuranceid.Text.Trim() == "")
                {
                    MessageBox.Show("ҽ������ҽ����Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtinsuranceid.Focus();
                    return false;
                }
                if (m_intPatientFlag == 2)
                {
                    if (m_objViewer.txtIDCard.Text.Trim() == "")
                    {
                        MessageBox.Show("ҽ���������֤��Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.txtIDCard.Focus();
                        return false;
                    }
                }
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("ҽ�����˼�ͥ��ַΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return false;
                }
                if (m_objViewer.txtEmployer.Text.Trim() == "")
                {
                    MessageBox.Show("ҽ�����˹�����λΪ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtEmployer.Focus();
                    return false;
                }

                if (this.m_objViewer.m_txtInsuredMoney.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredMoney.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("ҽ��ʣ�������벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredMoney.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ҽ��ʣ�������벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredMoney.Focus();
                        return false;
                    }
                }

                if (this.m_objViewer.m_txtInsuredPayTime.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayTime.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("ҽ�������������벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredPayTime.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ҽ�������������벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredPayTime.Focus();
                        return false;
                    }
                }

                if (this.m_objViewer.m_txtInsuredPayMoney.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayMoney.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("ҽ�������ν���벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredPayMoney.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ҽ������������벻��ȷ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredPayMoney.Focus();
                        return false;
                    }
                }
            }

            if (m_objViewer.m_txtGOVCARD_CHR.Enabled)
            {
                if (m_objViewer.m_txtGOVCARD_CHR.Text.Trim() == "")
                {
                    MessageBox.Show("ְ��ҽ��֤��Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtGOVCARD_CHR.Focus();
                    return false;
                }
            }

            if (this.m_disPrepayFalg == 0 && (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "" || m_objViewer.m_txtMONEY_DEC.Text.Trim() == "0"))
            {
                string message = "�ò����״�Ԥ�����Ϊ0Ԫ���Ƿ������";
                string caption = "��Ժ�Ǽ�";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(this.m_objViewer, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.No)
                {
                    m_objViewer.m_txtMONEY_DEC.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public void m_mthCalculateAge()
        {
            DateTime tempDate;
            try
            {
                tempDate = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text);

                //add 2007.5.9 zhu.w.t
                if (tempDate < Convert.ToDateTime("1753-1-1 12:00:00") || tempDate > Convert.ToDateTime("9999-12-31 11:59:59"))
                {
                }
                else
                {
                    m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(tempDate);
                }
            }
            catch
            {
                return;
            }

        }
        #endregion

        #region ����ҽ������
        public void m_mthYBPatient()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_strRegisterID))
            {
                return;
            }
            frmYBRegisterZY objYBReg = new frmYBRegisterZY();
            objYBReg.strRegisterId = m_objViewer.m_strRegisterID;
            objYBReg.ShowDialog();
        }
        #endregion

        #region ҽ����¼��ʼ��
        /// <summary>
        /// ҽ����¼��ʼ��
        /// </summary>
        public void m_mthInitYB()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\HNBridge.dll"))
            {
                //ҽԺ������ע����סԺ��¼
                string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
                long lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
                if (lngRes < 0)
                {
                    MessageBox.Show("�籣��ʼ��ʧ�ܣ������´򿪣�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion


    }



    #region ��clsColor ȡ��ɫ��
    public class clsColor
    {
        public clsColor()
        {
        }

        public static System.Drawing.Color m_ColorByInt(int itemIndex)
        {
            System.Drawing.Color selectedColor;
            switch (itemIndex)
            {
                case 0:
                    selectedColor = System.Drawing.Color.Blue;
                    break;
                case 1:
                    selectedColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    selectedColor = System.Drawing.Color.Green;
                    break;
                case 3:
                    selectedColor = System.Drawing.Color.Tomato;
                    break;
                case 4:
                    selectedColor = System.Drawing.Color.Brown;
                    break;
                default:
                    selectedColor = System.Drawing.Color.Black;
                    break;
            }
            return selectedColor;
        }
        /// <summary>
        /// �ܹ��������ɫ��
        /// </summary>
        /// <returns>�ܹ��������ɫ��</returns>
        public static int Count
        {
            get
            {
                return 5;
            }
        }
    }
    #endregion

    #region ��clsComboBoxTextValue
    public class clsComboBoxTextValue
    {
        private string _text;
        private int _value;

        public clsComboBoxTextValue(string _Text, int _Value)
        {
            _text = _Text;
            _value = _Value;
        }

        public override string ToString()
        {
            return _text;
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
    #endregion

}
