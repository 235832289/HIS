using System;
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
using System.Collections;
using System.Collections.Generic;


namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��Ժ�Ǽ������޸�--���Ʋ�
    /// </summary>
    public class clsCtl_EditRegister : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        clsDcl_BIHTransfer m_objTran = null;
        /// <summary>
        /// ���˻�����ϢVO
        /// </summary>
        clsPatient_VO m_objPatientVO = null;
        /// <summary>
        /// ����סԺ��Ժ�Ǽ���ϢVO
        /// </summary>
        clsT_Opr_Bih_Register_VO m_objRegisterVO = null;
        /// <summary>
        /// ��Ժ�Ǽ���ˮ��
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// ���˱��
        /// </summary>
        public string m_strPatientID = "";
        /// <summary>
        /// ������Ժ�ǼǴ�*�ŵ����Ƿ����:0-�ɲ��� 1-������
        /// </summary>
        private int m_intNeedInput = 0;
        /// <summary>
        /// ��ǰ������ݱ�ʶ:0-��ͨ 1-���� 2-ҽ�� 3-���� 4-Ӧ��������
        /// </summary>
        private int m_intPatientFlag = 0;

        Hashtable m_initCtl;
        private clsBrithdayToAge m_objAge;

        #endregion

        #region ���캯��
        public clsCtl_EditRegister()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objTran = new clsDcl_BIHTransfer();
            m_objAge = new clsBrithdayToAge();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmEditRegister m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmEditRegister)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInit()
        {
            //m_objViewer.Cursor = Cursors.AppStarting;
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
                new clsColumns_VO("���ID","paytypeid_chr",HorizontalAlignment.Left,0),
                new clsColumns_VO("���","paytypeno_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("�������","paytypename_vchr",HorizontalAlignment.Left,140)
            };
            m_objViewer.m_txtPaytype.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr, bihlimitrate_dec,
         internalflag_int
    FROM t_bse_patientpaytype
   WHERE payflag_dec != 1 AND isusing_num != 0
ORDER BY paytypeno_vchr";
            m_objViewer.m_txtPaytype.m_mthInitListView(columArr);

//            //�������
//            columArr = new clsColumns_VO[]
//            {
//                new clsColumns_VO("���ID","paytypeid_chr",HorizontalAlignment.Left,0),
//                new clsColumns_VO("���","paytypeno_vchr",HorizontalAlignment.Left,40),
//                new clsColumns_VO("���","paytypename_vchr",HorizontalAlignment.Left,140)
//            };
//            m_objViewer.m_txtPatiemtType.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr
//    FROM t_bse_patientpaytype
//   WHERE payflag_dec != 2 AND isusing_num != 0
//ORDER BY paytypeno_vchr";
//            m_objViewer.m_txtPatiemtType.m_mthInitListView(columArr);

            //ְҵ
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("���","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("ְҵ","dictname_vchr",HorizontalAlignment.Left,60)
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

            // ���"������Դ"��  �������޸���2010\8\25
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

            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            m_objViewer.cboSex.SelectedIndex = 0;
            m_objViewer.m_txtRace.Text = "����";
            m_objViewer.txtNationality.SelectedValue = "�й�";
            m_objViewer.cobMarried.SelectedIndex = 0;
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            m_objViewer.m_cmbFindType.SelectedIndex = 0;
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            m_objViewer.m_txtAge.Text = "0��";
            //m_objViewer.Cursor = Cursors.Default;
            m_mthFindPatient();

            //��Ժ�������ϣ��������޸�
            if (this.m_objViewer.m_strOpentParm == "1")
            {
                DisableContols();
            }

            //����ؼ��ĳ�ʼֵ
            SaveContolsText();
        }
        #endregion

        #region	���Ҳ���
        /// <summary>
        /// ���Ҳ���
        /// </summary>
        public void m_mthFindPatient()
        {
            frmCommonFind frm;
            if (this.m_objViewer.m_strOpentParm == "1" || this.m_objViewer.m_strOpentParm == "2")
            {
                frm = new frmCommonFind("���Ҳ���", 3);
            }
            else
            {
                frm = new frmCommonFind("���Ҳ���", 9);
            }

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.m_strPatientID = frm.PatientID;
                this.m_strRegisterID = frm.RegisterID;
                m_objViewer.Cursor = Cursors.WaitCursor;
                if (m_mthGetRegisterInfoByPatientID())
                {
                    m_mthFindPatientInfoByPatientID();
                }
                m_objViewer.Cursor = Cursors.Default;
            }
            frm = null;
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
                    m_objViewer.Cursor = Cursors.WaitCursor;
                    long lngRes = m_objTran.m_lngGetPatientIDByCarIDOrInPatientID(m_objViewer.m_cmbFindType.SelectedIndex, m_objViewer.m_txtFindText.Text.Trim(), out m_strPatientID);
                    if (lngRes > 0 && m_strPatientID != "")
                    {
                        if (m_mthGetRegisterInfoByPatientID())
                        {
                            m_mthFindPatientInfoByPatientID();
                        }
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
                finally
                {
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ
        /// <summary>
        /// ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ
        /// </summary>
        public bool m_mthGetRegisterInfoByPatientID()
        {
            try
            {
                long lngRes = -1;
                if (this.m_objViewer.m_strOpentParm == "1" || this.m_objViewer.m_strOpentParm == "2")
                {
                    //��Ժ����
                    // lngRes = m_objTran.m_lngGetRegisterInfoByPatientID(m_strPatientID, "3", out m_objRegisterVO);
                    lngRes = m_objTran.m_lngGetRegisterInfoByRegisterID(this.m_strRegisterID, out m_objRegisterVO);
                }
                else
                {
                    lngRes = m_objTran.m_lngGetRegisterInfoByPatientID(m_strPatientID, out m_objRegisterVO);
                    //lngRes = m_objTran.m_lngGetRegisterInfoByRegisterID(this.m_strRegisterID, out m_objRegisterVO);
                }

                if (m_objRegisterVO.m_strREGISTERID_CHR != null)
                {
                    m_objViewer.m_lblPStatusName.Text = "�� " + m_objRegisterVO.m_intINPATIENTCOUNT_INT.ToString() + " ��סԺ";
                    m_objViewer.m_txtInPatienID.Text = m_objRegisterVO.m_strINPATIENTID_CHR;
                    m_objViewer.m_cboInpatientNoType.SelectedIndex = m_objRegisterVO.m_intINPATIENTNOTYPE_INT - 1;
                    m_objViewer.m_dateInHosp.Value = Convert.ToDateTime(m_objRegisterVO.m_strINPATIENT_DAT);
                    m_objViewer.m_cboTYPE_INT.SelectedIndex = m_objRegisterVO.m_intTYPE_INT - 1;
                    m_objViewer.m_txtAREAID.Value = m_objRegisterVO.m_strAREAID_CHR;
                    m_objViewer.m_txtAREAID.Text = m_objRegisterVO.m_strAreaName;
                    m_objViewer.m_txtBedCode.Text = m_objRegisterVO.m_strBedNo;
                    m_objViewer.m_txtMaindoctor.Value = m_objRegisterVO.m_strMZDOCTOR_CHR;
                    m_objViewer.m_txtMaindoctor.Text = m_objRegisterVO.m_stroutdoctorname;
                    m_objViewer.m_cboSTATE_INT.SelectedIndex = m_objRegisterVO.m_intSTATE_INT - 1;
                    m_objViewer.m_txtMZDiagnose.Text = m_objRegisterVO.m_strMZDIAGNOSE_VCHR;
                    m_objViewer.m_txtRemark.Text = m_objRegisterVO.DES_VCHR;
                    m_objViewer.m_txtPaytype.m_mthFindAndSelect(m_objRegisterVO.m_strPAYTYPEID_CHR);
                    m_objViewer.m_txtLIMITRATE_MNY.Text = m_objRegisterVO.m_dblLIMITRATE_MNY.ToString();

                    if (m_objRegisterVO.m_intPSTATUS_INT == 0)
                    {
                        m_objViewer.m_txtAREAID.Enabled = true;
                    }
                    else
                    {
                        m_objViewer.m_txtAREAID.Enabled = false;
                    }

                    //ҽ������
                    if (m_objViewer.m_txtinsuranceid.Enabled)
                    {
                        this.m_objViewer.m_txtInsuredTotalMoney.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayScale.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                    }
                }
                else
                {
                    //MessageBox.Show("�ò��˲���סԺ��", "�޸ĵǼ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("�޷���ȡ�ò��˵�סԺ�Ǽ���Ϣ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ȡ����סԺ��Ϣʧ�ܣ�");
                return false;
            }
            return true;
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
            long lngRes = m_objTran.m_lngFindPatientInfoByPatientID(m_strPatientID, out m_objPatientVO);
            //long lngRes = m_objTran.m_lngGetPatientINfoByRegisterID(m_strRegisterID, out m_objPatientVO);
            if (lngRes > 0 && m_objPatientVO.m_strPATIENTID_CHR != "")
            {
                //ҽ�����
                m_objViewer.m_txtinsuranceid.Text = m_objPatientVO.m_strINSURANCEID_VCHR;
                //��������
                if (m_objPatientVO.m_strBIRTH_DAT != null && m_objPatientVO.m_strBIRTH_DAT.ToString() != "")
                {
                    m_objViewer.m_dtpBirthDate.Text = Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT).ToString("yyyy-MM-dd");
                    //m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT));
                    m_objViewer.m_txtAge.Text = m_objAge.m_strGetAge(Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT));
                }
                //���֤�� 
                m_objViewer.txtIDCard.Text = m_objPatientVO.m_strIDCARD_CHR;
                //�������� 
                m_objViewer.txtPatientName.Text = m_objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
                //��ϵ�绰 
                m_objViewer.txtPhone.Text = m_objPatientVO.m_strHOMEPHONE_VCHR;
                //�Ա� 
                m_objViewer.cboSex.SelectedValue = m_objPatientVO.m_strSEX_CHR;
                //�������
                //m_objViewer.m_txtPatiemtType.m_mthFindAndSelect(m_objPatientVO.m_strPAYTYPEID_CHR);
                //�Ƿ�Ա��
                m_objViewer.cboIsemployee.SelectedIndex = m_objPatientVO.m_intISEMPLOYEE_INT;
                //������Դ
                m_objViewer.m_cboPatientSource.SelectedValue = m_objPatientVO.m_strPatientSource;
                //��� 
                m_objViewer.cobMarried.SelectedValue = m_objPatientVO.m_strMARRIED_CHR;
                //�ƶ��绰 
                m_objViewer.txtMobile.Text = m_objPatientVO.m_strMOBILE_CHR;
                //��ͥסַ 
                m_objViewer.txtAddress.Text = m_objPatientVO.m_strHOMEADDRESS_VCHR;
                //����
                if (m_objPatientVO.m_strNATIONALITY_VCHR == null || m_objPatientVO.m_strNATIONALITY_VCHR == "")
                {
                    m_objViewer.txtNationality.SelectedValue = "�й�";
                }
                else
                {
                    m_objViewer.txtNationality.SelectedValue = m_objPatientVO.m_strNATIONALITY_VCHR;
                }

                m_objViewer.m_txttNativeplace.Text = m_objPatientVO.m_strNATIVEPLACE_VCHR;

                //���� 
                if (m_objPatientVO.m_strRACE_VCHR == null || m_objPatientVO.m_strRACE_VCHR == "")
                {
                    m_objViewer.m_txtRace.Text = "����";
                }
                else
                {
                    m_objViewer.m_txtRace.Text = m_objPatientVO.m_strRACE_VCHR;
                }
                //ְҵ 
                m_objViewer.m_txtOccupation.Text = m_objPatientVO.m_strOCCUPATION_VCHR;
                //��ַ�ʱ� 
                m_objViewer.txtHomepc.Text = m_objPatientVO.m_strHOMEPC_CHR;
                //��ϵ������ 
                if (m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR != "")
                {
                    m_objViewer.txtContactpersonFirstaName.Text = m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR;
                }
                else
                {
                    m_objViewer.txtContactpersonFirstaName.Text = m_objViewer.txtPatientName.Text;
                }
                //��ϵ�˵绰 
                m_objViewer.txtContactpersonPhone.Text = m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
                //��ϵ���ʱ� 
                m_objViewer.txtContactpersonpc.Text = m_objPatientVO.m_strCONTACTPERSONPC_CHR;
                //����ϵ�˹�ϵ 
                m_objViewer.m_txtRelation.Text = m_objPatientVO.m_strPATIENTRELATION_VCHR;
                //��ϵ�˵�ַ 
                m_objViewer.txtContactpersonAddress.Text = m_objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
                //�칫�绰 
                m_objViewer.txtOfficephone.Text = m_objPatientVO.m_strOFFICEPHONE_VCHR;
                //�칫�ʱ� 
                m_objViewer.txtOfficepc.Text = m_objPatientVO.m_strOFFICEPC_VCHR;
                //������λ 
                m_objViewer.txtEmployer.Text = m_objPatientVO.m_strEMPLOYER_VCHR;
                //�������� 
                m_objViewer.txtEmail.Text = m_objPatientVO.m_strEMAIL_VCHR;
                //�칫��ַ
                m_objViewer.txtOfficeAddress.Text = m_objPatientVO.m_strOFFICEADDRESS_VCHR;
                //��������
                m_objViewer.txtDeactivateDate.Text = m_objPatientVO.m_strDEACTIVATE_DAT;
                //������Ա
                m_objViewer.txtOperatorid.Text = m_objPatientVO.m_strOPERATORID_CHR;
                //��������
                m_objViewer.txtModifydate.Text = m_objPatientVO.m_strMODIFY_DAT;
                m_objViewer.m_txtGOVCARD_CHR.Text = m_objPatientVO.m_strGOVCARD_CHR;

                m_objViewer.m_txtInsuredTotalMoney.Text = m_objPatientVO.m_decInsuredMoney.ToString();
                m_objViewer.m_txtInsuredPayMoney.Text = m_objPatientVO.m_decInsuredPayMoney.ToString();
                m_objViewer.m_txtInsuredPayTime.Text = m_objPatientVO.m_decInsuredPayTime.ToString();
                m_objViewer.m_txtInsuredPayScale.Text = m_objPatientVO.m_decInsuredPayScale.ToString();
                m_objViewer.txtBirthPlace.Text = m_objPatientVO.m_strBIRTHPLACE_VCHR.ToString();
                m_objViewer.txtResidenceplace.Text = m_objPatientVO.m_strResidencePlace.ToString();
                m_objViewer.txtConsigneeAddr.Text = m_objPatientVO.ConsigneeAddr;
                m_objViewer.txtPatientName.Focus();
            }
            else
            {
                MessageBox.Show("�Ҳ����ò�����Ϣ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ������Ժ�Ǽ�
        /// <summary>
        /// ������Ժ�Ǽ�
        /// </summary>
        public void m_mthSaveRegister()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            if (!IsPassValidate())
            {
                m_objViewer.Cursor = Cursors.Default;
                return;
            }
            int intFlag;
            if (m_objRegisterVO.m_strAREAID_CHR != m_objViewer.m_txtAREAID.Value)
            {
                intFlag = 1;
            }
            else
            {
                intFlag = 0;
            }
            ValueToVoForBaseInfo();
            ValueToVoForBIHInfo();
            try
            {
                // ͬ����� 2018-04-23
                m_objPatientVO.m_strPAYTYPEID_CHR = m_objRegisterVO.m_strPAYTYPEID_CHR;
                m_objTran.m_lngEditRegister(intFlag, m_objPatientVO, m_objRegisterVO);
                MessageBox.Show("����ɹ���", "�޸ĵǼ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //����䶯��־
                SaveEditLog();

                //�ؼ��ĵ�ǰֵΪ��ʼֵ
                SaveContolsText();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "�޸ĵǼ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                m_objViewer.Cursor = Cursors.Default;
            }
        }

        #region ����䶯��־
        private void SaveEditLog()
        {
            clsPatientInfLog patientLogVo = new clsPatientInfLog();
            patientLogVo.operatorId = this.m_objViewer.LoginInfo.m_strEmpID;
            patientLogVo.registerId = this.m_objRegisterVO.m_strREGISTERID_CHR;
            patientLogVo.desc = "";

            //����
            if (this.m_initCtl.Contains("txtPatientName"))
            {
                if (this.m_initCtl["txtPatientName"].ToString() != this.m_objViewer.txtPatientName.Text)
                {
                    patientLogVo.detail = "������" + this.m_initCtl["txtPatientName"].ToString() + "--> " + this.m_objViewer.txtPatientName.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //סԺ����
            if (this.m_initCtl.Contains("m_cboInpatientNoType"))
            {
                if (this.m_initCtl["m_cboInpatientNoType"].ToString() != this.m_objViewer.m_cboInpatientNoType.Text)
                {
                    patientLogVo.detail = "סԺ���ͣ�" + this.m_initCtl["m_cboInpatientNoType"].ToString() + "--> " + this.m_objViewer.m_cboInpatientNoType.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //�Ա�
            if (this.m_initCtl.Contains("cboSex"))
            {
                if (this.m_initCtl["cboSex"].ToString() != this.m_objViewer.cboSex.Text)
                {
                    patientLogVo.detail = "�Ա�" + this.m_initCtl["cboSex"].ToString() + "--> " + this.m_objViewer.cboSex.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //��������
            if (this.m_initCtl.Contains("m_dtpBirthDate"))
            {
                if (this.m_initCtl["m_dtpBirthDate"].ToString() != this.m_objViewer.m_dtpBirthDate.Text)
                {
                    patientLogVo.detail = "�������ڣ�" + this.m_initCtl["m_dtpBirthDate"].ToString() + "--> " + this.m_objViewer.m_dtpBirthDate.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //���
            if (this.m_initCtl.Contains("cobMarried"))
            {
                if (this.m_initCtl["cobMarried"].ToString() != this.m_objViewer.cobMarried.Text)
                {
                    patientLogVo.detail = "���" + this.m_initCtl["cobMarried"].ToString() + "--> " + this.m_objViewer.cobMarried.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //����
            if (this.m_initCtl.Contains("m_txtRace"))
            {
                if (this.m_initCtl["m_txtRace"].ToString() != this.m_objViewer.m_txtRace.Text)
                {
                    patientLogVo.detail = "���壺" + this.m_initCtl["m_txtRace"].ToString() + "--> " + this.m_objViewer.m_txtRace.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //����
            if (this.m_initCtl.Contains("txtNationality"))
            {
                if (this.m_initCtl["txtNationality"].ToString() != this.m_objViewer.txtNationality.Text)
                {
                    patientLogVo.detail = "������" + this.m_initCtl["txtNationality"].ToString() + "--> " + this.m_objViewer.txtNationality.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //�Ƿ�ְ��
            if (this.m_initCtl.Contains("cboIsemployee"))
            {
                if (this.m_initCtl["cboIsemployee"].ToString() != this.m_objViewer.cboIsemployee.Text)
                {
                    patientLogVo.detail = "�Ƿ�ְ����" + this.m_initCtl["cboIsemployee"].ToString() + "--> " + this.m_objViewer.cboIsemployee.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //ҽ��֤��
            if (this.m_initCtl.Contains("m_txtGOVCARD_CHR"))
            {
                if (this.m_initCtl["m_txtGOVCARD_CHR"].ToString() != this.m_objViewer.m_txtGOVCARD_CHR.Text)
                {
                    patientLogVo.detail = "ҽ��֤�ţ�" + this.m_initCtl["m_txtGOVCARD_CHR"].ToString() + "--> " + this.m_objViewer.m_txtGOVCARD_CHR.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //���
            //if (this.m_initCtl.Contains("m_txtPatiemtType"))
            //{
            //    if (this.m_initCtl["m_txtPatiemtType"].ToString() != this.m_objViewer.m_txtPatiemtType.Text)
            //    {
            //        patientLogVo.detail = "��ݣ�" + this.m_initCtl["m_txtPatiemtType"].ToString() + "--> " + this.m_objViewer.m_txtPatiemtType.Text;

            //        m_objTran.AddPatienInfLog(patientLogVo);
            //    }
            //}


            //�������
            if (this.m_initCtl.Contains("m_txtPaytype"))
            {
                if (this.m_initCtl["m_txtPaytype"].ToString() != this.m_objViewer.m_txtPaytype.Text)
                {
                    patientLogVo.detail = "������" + this.m_initCtl["m_txtPaytype"].ToString() + "--> " + this.m_objViewer.m_txtPaytype.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //ҽ����
            if (this.m_initCtl.Contains("m_txtinsuranceid"))
            {
                if (this.m_initCtl["m_txtinsuranceid"].ToString() != this.m_objViewer.m_txtinsuranceid.Text)
                {
                    patientLogVo.detail = "ҽ���ţ�" + this.m_initCtl["m_txtinsuranceid"].ToString() + "--> " + this.m_objViewer.m_txtinsuranceid.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //���֤��
            if (this.m_initCtl.Contains("txtIDCard"))
            {
                if (this.m_initCtl["txtIDCard"].ToString() != this.m_objViewer.txtIDCard.Text)
                {
                    patientLogVo.detail = "���֤�ţ�" + this.m_initCtl["txtIDCard"].ToString() + "--> " + this.m_objViewer.txtIDCard.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //��ͥ��ַ
            if (this.m_initCtl.Contains("txtAddress"))
            {
                if (this.m_initCtl["txtAddress"].ToString() != this.m_objViewer.txtAddress.Text)
                {
                    patientLogVo.detail = "��ͥ��ַ��" + this.m_initCtl["txtAddress"].ToString() + "--> " + this.m_objViewer.txtAddress.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //ҽ��ʣ����
            if (this.m_initCtl.Contains("m_txtInsuredTotalMoney"))
            {
                if (this.m_initCtl["m_txtInsuredTotalMoney"].ToString() != this.m_objViewer.m_txtInsuredTotalMoney.Text)
                {
                    patientLogVo.detail = "ҽ��ʣ���" + this.m_initCtl["m_txtInsuredTotalMoney"].ToString() + "--> " + this.m_objViewer.m_txtInsuredTotalMoney.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //ҽ����������
            if (this.m_initCtl.Contains("m_txtInsuredPayTime"))
            {
                if (this.m_initCtl["m_txtInsuredPayTime"].ToString() != this.m_objViewer.m_txtInsuredPayTime.Text)
                {
                    patientLogVo.detail = "ҽ������������" + this.m_initCtl["m_txtInsuredPayTime"].ToString() + "--> " + this.m_objViewer.m_txtInsuredPayTime.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //ҽ���������
            if (this.m_initCtl.Contains("m_txtInsuredPayMoney"))
            {
                if (this.m_initCtl["m_txtInsuredPayMoney"].ToString() != this.m_objViewer.m_txtInsuredPayMoney.Text)
                {
                    patientLogVo.detail = "ҽ��������" + this.m_initCtl["m_txtInsuredPayMoney"].ToString() + "--> " + this.m_objViewer.m_txtInsuredPayMoney.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //��Ժʱ��
            if (this.m_initCtl.Contains("m_dateInHosp"))
            {
                if (this.m_initCtl["m_dateInHosp"].ToString() != this.m_objViewer.m_dateInHosp.Text)
                {
                    patientLogVo.detail = "��Ժʱ�䣺" + this.m_initCtl["m_dateInHosp"].ToString() + "--> " + this.m_objViewer.m_dateInHosp.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //ת�뷽ʽ
            if (this.m_initCtl.Contains("m_cboTYPE_INT"))
            {
                if (this.m_initCtl["m_cboTYPE_INT"].ToString() != this.m_objViewer.m_cboTYPE_INT.Text)
                {
                    patientLogVo.detail = "ת�뷽ʽ��" + this.m_initCtl["m_cboTYPE_INT"].ToString() + "--> " + this.m_objViewer.m_cboTYPE_INT.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //����ҽ��
            if (this.m_initCtl.Contains("m_txtMaindoctor"))
            {
                if (this.m_initCtl["m_txtMaindoctor"].ToString() != this.m_objViewer.m_txtMaindoctor.Text)
                {
                    patientLogVo.detail = "����ҽ����" + this.m_initCtl["m_txtMaindoctor"].ToString() + "--> " + this.m_objViewer.m_txtMaindoctor.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //��������
            if (this.m_initCtl.Contains("m_txtLIMITRATE_MNY"))
            {
                if (this.m_initCtl["m_txtLIMITRATE_MNY"].ToString() != this.m_objViewer.m_txtLIMITRATE_MNY.Text)
                {
                    patientLogVo.detail = "�������ޣ�" + this.m_initCtl["m_txtLIMITRATE_MNY"].ToString() + "--> " + this.m_objViewer.m_txtLIMITRATE_MNY.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


        }
        #endregion

        #endregion

        #region �ؼ���ֵ��������ϢVo
        /// <summary>
        /// �ؼ���ֵ��������ϢVo
        /// </summary>
        private void ValueToVoForBaseInfo()
        {
            //ҽ�����
            m_objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
            //��������
            try
            {
                m_objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //���֤�� 
            m_objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //�������� 
            m_objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName.Text;
            m_objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName.Text;
            m_objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //��ϵ�绰 
            m_objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //�Ա� 
            m_objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //�������
            //m_objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPatiemtType.Value;
            //�Ƿ�Ա��
            m_objPatientVO.m_intISEMPLOYEE_INT = m_objViewer.cboIsemployee.SelectedIndex;
            //��� 
            m_objPatientVO.m_strMARRIED_CHR = (string)m_objViewer.cobMarried.SelectedValue;
            //�ƶ��绰 
            m_objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //��ͥסַ 
            m_objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //����
            m_objPatientVO.m_strNATIONALITY_VCHR = (string)m_objViewer.txtNationality.SelectedValue;

            m_objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text;

            //���� 
            m_objPatientVO.m_strRACE_VCHR = m_objViewer.m_txtRace.Text;
            //ְҵ 
            m_objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.m_txtOccupation.Text.Trim();
            //������Դ
            m_objPatientVO.m_strPatientSource = (string)m_objViewer.m_cboPatientSource.SelectedValue;
            //��ַ�ʱ� 
            m_objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc.Text;
            //��ϵ������ 
            m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            //��ϵ�˵绰 
            m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone.Text;
            //��ϵ���ʱ� 
            m_objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //����ϵ�˹�ϵ 
            m_objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.m_txtRelation.Text.Trim();
            //��ϵ�˵�ַ 
            m_objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress.Text;
            //�칫�绰 
            m_objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //�칫�ʱ� 
            m_objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc.Text;
            //������λ 
            m_objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer.Text;
            //�������� 
            m_objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //�칫��ַ
            m_objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress.Text;
            //������Ա
            m_objPatientVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objPatientVO.m_strGOVCARD_CHR = m_objViewer.m_txtGOVCARD_CHR.Text.Trim();

            try
            {
                m_objPatientVO.m_decInsuredMoney = Convert.ToDecimal(m_objViewer.m_txtInsuredTotalMoney.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredMoney = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayMoney = Convert.ToDecimal(m_objViewer.m_txtInsuredPayMoney.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayMoney = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayTime = Convert.ToDecimal(m_objViewer.m_txtInsuredPayTime.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayTime = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayScale = Convert.ToDecimal(m_objViewer.m_txtInsuredPayScale.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayScale = 100;
            }

            m_objPatientVO.m_strBIRTHPLACE_VCHR = this.m_objViewer.txtBirthPlace.Text.Trim();
            m_objPatientVO.m_strResidencePlace = this.m_objViewer.txtResidenceplace.Text.Trim();
            m_objPatientVO.ConsigneeAddr = this.m_objViewer.txtConsigneeAddr.Text.Trim();
        }
        #endregion

        #region �ؼ���ֵ����Ժ�Ǽ���ϢVo
        /// <summary>
        /// �ؼ���ֵ����Ժ�Ǽ���ϢVo
        /// </summary>
        private bool ValueToVoForBIHInfo()
        {
            m_objRegisterVO.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp.Value.ToString("yyyy-MM-dd HH:mm:ss");
            m_objRegisterVO.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            m_objRegisterVO.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT.SelectedIndex + 1;
            if (m_objViewer.m_txtLIMITRATE_MNY.Text.Trim() == "")
            {
                m_objRegisterVO.m_dblLIMITRATE_MNY = 0;
            }
            else
            {
                m_objRegisterVO.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY.Text.Trim());
            }
            m_objRegisterVO.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT.SelectedIndex + 1;
            m_objRegisterVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objRegisterVO.m_intPSTATUS_INT = 0;
            m_objRegisterVO.m_strMZDOCTOR_CHR = m_objViewer.m_txtMaindoctor.Value;
            m_objRegisterVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPaytype.Value;
            m_objRegisterVO.m_strMZDIAGNOSE_VCHR = m_objViewer.m_txtMZDiagnose.Text.Trim();
            m_objRegisterVO.DES_VCHR = m_objViewer.m_txtRemark.Text.Trim();
            return true;
        }
        #endregion

        #region ���������Ϣ
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        public void m_EmptyAndInitialization()
        {
            // ���סԺ״̬
            m_strRegisterID = "";
            m_strPatientID = "";
            m_objViewer.m_txtFindText.Text = "";
            m_objViewer.m_lblPStatusName.Text = "�״���Ժ";
            m_EmptyBaseInfo();
            m_objPatientVO = null;
            m_EmptyBihRegisterInfo();
            m_objRegisterVO = null;
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
            //��ͥסַ 
            m_objViewer.txtAddress.Text = "";
            //����
            m_objViewer.txtNationality.SelectedValue = "�й�";
            //���� 
            m_objViewer.m_txtRace.Text = "����";
            //ְҵ 
            m_objViewer.m_txtOccupation.Text = "";
            m_objViewer.m_txtOccupation.m_mthFindDate();
            m_objViewer.m_txtOccupation.m_listView.Visible = false;
            //��ַ�ʱ� 
            m_objViewer.txtHomepc.Text = "";
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

            m_objViewer.txtConsigneeAddr.Text = "";
        }
        #endregion

        #region ���סԺ��Ϣ
        /// <summary>
        /// ���סԺ��Ϣ
        /// </summary>
        public void m_EmptyBihRegisterInfo()
        {
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            //��Ժ����
            m_objViewer.m_dateInHosp.Enabled = true;
            m_objViewer.m_dateInHosp.Text = "";
            m_objViewer.m_dateInHosp.Tag = "";
            //��Ժ����
            m_objViewer.m_txtAREAID.Value = null;
            m_objViewer.m_txtAREAID.Text = "";
            if (m_objViewer.m_txtAREAID.Enabled)
            {
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
            m_objViewer.m_txtPaytype.Value = null;
            m_objViewer.m_txtPaytype.Text = "";
            m_objViewer.m_txtPaytype.m_mthFindDate();
            m_objViewer.m_txtLIMITRATE_MNY.Text = "";
            ////������
            //m_objViewer.m_txtPatiemtType.Value = null;
            //m_objViewer.m_txtPatiemtType.Text = "";
            //m_objViewer.m_txtPatiemtType.m_mthFindDate();
            m_mthSetPatType();
            m_objViewer.m_txtMaindoctor.Value = null;
            m_objViewer.m_txtMaindoctor.Text = "";
            m_objViewer.m_txtMaindoctor.m_mthFindDate();
            m_objViewer.m_txtRemark.Text = "";
            m_objViewer.m_txtMZDiagnose.Text = "";
            m_objViewer.m_txtInPatienID.Text = "";
            m_objViewer.m_txtBedCode.Text = "";
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
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = true;

                    this.m_objViewer.m_txtInsuredTotalMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                }
                else
                {
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = false;

                    this.m_objViewer.m_txtInsuredTotalMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = false;
                }
            }
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
            if (m_strPatientID == "")
            {
                m_EmptyAndInitialization();
            }
            else
            {
                if (m_mthGetRegisterInfoByPatientID())
                {
                    m_mthFindPatientInfoByPatientID();
                }
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
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("��ע�⣺���֤�Ų���18λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            if (m_objPatientVO == null)
            {
                MessageBox.Show(m_objViewer, "����벡����Ϣ��", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "��������Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (m_objViewer.m_txtAREAID.Value == null || m_objViewer.m_txtAREAID.Text == string.Empty)
            {
                MessageBox.Show("����Ϊ������!", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtAREAID.Focus();
                return false;
            }
            if (m_objViewer.m_txtMaindoctor.Value == null || m_objViewer.m_txtMaindoctor.Text == string.Empty)
            {
                MessageBox.Show("����ҽ��Ϊ�����", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_objViewer.m_txtAge.Text = m_objAge.m_strGetAge(tempDate);
                }
            }
            catch
            {
                return;
            }
        }
        #endregion

        private void SaveContolsText()
        {
            this.m_initCtl = new Hashtable();
            for (int i = 0; i < this.m_objViewer.groupBox2.Controls.Count; i++)
            {
                if (!this.m_initCtl.Contains(this.m_objViewer.groupBox2.Controls[i].Name))
                {
                    this.m_initCtl.Add(this.m_objViewer.groupBox2.Controls[i].Name, this.m_objViewer.groupBox2.Controls[i].Text);
                }
            }

            for (int i = 0; i < this.m_objViewer.groupBox5.Controls.Count; i++)
            {
                if (!this.m_initCtl.Contains(this.m_objViewer.groupBox5.Controls[i].Name))
                {
                    this.m_initCtl.Add(this.m_objViewer.groupBox5.Controls[i].Name, this.m_objViewer.groupBox5.Controls[i].Text);
                }
            }
        }

        private void DisableContols()
        {
            for (int i = 0; i < this.m_objViewer.groupBox2.Controls.Count; i++)
            {
                if (!(this.m_objViewer.groupBox2.Controls[i] is Label))
                {
                    this.m_objViewer.groupBox2.Controls[i].Enabled = false;
                    this.m_objViewer.groupBox2.Controls[i].BackColor = System.Drawing.Color.White;
                    this.m_objViewer.groupBox2.Controls[i].ForeColor = System.Drawing.Color.Black;
                }
            }

            for (int i = 0; i < this.m_objViewer.groupBox5.Controls.Count; i++)
            {
                if (!(this.m_objViewer.groupBox5.Controls[i] is Label))
                {
                    this.m_objViewer.groupBox5.Controls[i].Enabled = false;
                    this.m_objViewer.groupBox5.Controls[i].BackColor = System.Drawing.Color.White;
                    this.m_objViewer.groupBox5.Controls[i].ForeColor = System.Drawing.Color.Black;
                }
            }

            this.m_objViewer.cmdSaveBihRegister.Visible = false;
            this.m_objViewer.cmdEmpty.Enabled = false;
        }


        #region	����Ƕ��ʽ�籣���õǼǴ���
        /// <summary>
        /// �����籣����
        /// </summary>
        public void m_mthYBPatient()
        {
            string strRegisterID = m_objRegisterVO.m_strREGISTERID_CHR;
            if (strRegisterID == string.Empty)
            {
                return;
            }
            frmYBRegisterZY objYBReg = new frmYBRegisterZY();
            objYBReg.strRegisterId = strRegisterID;
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

}
