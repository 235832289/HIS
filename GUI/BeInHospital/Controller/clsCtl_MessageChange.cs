using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_MessageChange : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        com.digitalwave.iCare.gui.HIS.clsDcl_Register m_objRegister = null;
        clsDcl_BedAdmin m_objBedAdmin = null;
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
        /// סԺ���	[סԺ��]
        /// </summary>
        public string m_strInPatientID = "";
        /// <summary>
        /// סԺ״̬	{-1=�״���Ժ;0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
        /// </summary>
        public int m_intPStatus = -1;
        /// <summary>
        /// ���ｨ��Ԥ����
        /// </summary>
        public string m_strCLINICSAYPREPAY = "";
        /// <summary>
        /// ���˻�������
        /// </summary>
        public clsPatient_VO objPatientVO = null;
        public clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
        /// <summary>
        /// ���˵Ǽǵ��շ�����
        /// </summary>
        private String m_strPayType;

        #endregion


        #region ���캯��
        public clsCtl_MessageChange()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objRegister = new com.digitalwave.iCare.gui.HIS.clsDcl_Register();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmMessageChange m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMessageChange)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʼ��������
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        public void InitializationComboBox()
        {
            //��ʼ����Ժ��ʽ������
            //��Ժ��ʽ{1=����;2=����;3=��Ժת��}
            m_objViewer.m_cboTYPE_INT1.Items.Clear();
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("", 0));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("1-����", 1));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("2-����", 2));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("3-��Ժת��", 3));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("4-����ת��", 4));

            //��ʼ������������
            //����{1=Σ;2=��;3=��ͨ}
            m_objViewer.m_cboSTATE_INT2.Items.Clear();
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("", 0));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("1-Σ", 1));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("2-��", 2));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("3-��ͨ", 3));

            //��ʼ���������������
            m_objRegister.m_FillCboPatientType(m_objViewer.cobPaytypeid2);

            //��ʼ���������������
            m_objRegister.m_FillCboNationality(m_objViewer.txtNationality2);

            //��ʼ���������������
            m_objRegister.m_FillCboPatientRace(m_objViewer.txtRace2);

            //��ʼ������������
            //m_objRegister.m_FillCboPatientNativeplace(m_objViewer.txtNationality2);

            //��ʼ��ְҵ������
            m_objRegister.m_FillCboPatienttxtOccupation(m_objViewer.txtOccupation2);

            //��ʼ����ϵ������
            m_objRegister.m_FillCboPatientRelation(m_objViewer.txtRelation2);

            //��ʼ�����������
            m_objRegister.m_FillCboMarried(m_objViewer.cobMarried2);

            //��ʼ���Ա�������
            m_objRegister.m_FillCboSex(m_objViewer.cboSex2);
        }
        #endregion

        public void SetCurrentDoctor(com.digitalwave.iCare.ValueObject.clsLoginInfo loginInfo)
        {
            this.m_strOperatorID = loginInfo.m_strEmpID;
        }

        #region ������Ҷ�Ӧ�Ĳ���
        /// <summary>
        /// ������Ҷ�Ӧ�Ĳ���
        /// </summary>
        public void LoadAreaID()
        {
            
            DataTable dtbTemp = new DataTable();

            dtbTemp.Columns.Add(" �������	");
            dtbTemp.Columns.Add(" ��������	");
            dtbTemp.Columns.Add("id");

            DataRow dtRTemp;
            //����IDΪ���򷵻�
            //			if(m_objViewer.m_txtDEPTID_CHR.Value.Trim()=="") return;

            com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] ResultArr = null;
            string strFilter = "WHERE Trim(attributeid) = '0000003' AND STATUS_INT = 1 AND (Trim(lower(shortno_chr)) LIKE '" + m_objViewer.m_txtAREAID_CHR1.txtValuse.ToString().Trim().ToLower() + "%' or Trim(lower(DEPTNAME_VCHR)) like '" + m_objViewer.m_txtAREAID_CHR1.txtValuse.ToString().Trim().ToLower() + "%' or Trim(lower(PYCODE_CHR)) like '" + m_objViewer.m_txtAREAID_CHR1.txtValuse.ToString().Trim().ToLower() + "%' or Trim(lower(WBCODE_CHR)) like '" + m_objViewer.m_txtAREAID_CHR1.txtValuse.ToString().Trim().ToLower() + "%')";
            long lngRes = new clsDcl_Register().m_lngGetAreaInfo(strFilter, out ResultArr);

            if (lngRes > 0 && ResultArr.Length > 0)
            {
                for (int i = 0; i < ResultArr.Length; i++)
                {
                    dtRTemp = dtbTemp.NewRow();
                    dtRTemp[0] = ResultArr[i].m_strCODE_VCHR;
                    dtRTemp[1] = ResultArr[i].m_strDEPTNAME_VCHR;
                    dtRTemp[2] = ResultArr[i].m_strDEPTID_CHR;
                    dtbTemp.Rows.Add(dtRTemp);
                }
                m_objViewer.m_txtAREAID_CHR1.m_GetDataTable = dtbTemp;
            }
                  
        }
        #endregion

        #region ��������ҽ����Ϣ	glzhang		2005.07.12
        /// <summary>
        /// ��������ҽ����Ϣ	glzhang		2005.07.12
        /// </summary>
        public void m_mthLoadMainDoctor()
        {
            DataTable tempTable = new DataTable();

            DataRow tempRow;
            com.digitalwave.iCare.ValueObject.clsEmployee_VO[] DataResultArr = null;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetMainDoctor(this.m_objViewer.m_txtOutPatientDoctor2.Text.ToString().Trim().ToUpper(), out DataResultArr);
            if (lngRes > 0 && DataResultArr.Length > 0)
            {
                tempTable.Columns.Add("���	");
                tempTable.Columns.Add("ҽ��	");
                tempTable.Columns.Add("ID");
                for (int i = 0; i < DataResultArr.Length; i++)
                {
                    tempRow = tempTable.NewRow();
                    tempRow[0] = DataResultArr[i].m_strEMPNO_CHR;
                    tempRow[1] = DataResultArr[i].m_strLASTNAME_VCHR;
                    tempRow[2] = DataResultArr[i].m_strEMPID_CHR;
                    tempTable.Rows.Add(tempRow);
                }
                m_objViewer.m_txtOutPatientDoctor2.m_GetDataTable = tempTable;
                tempTable.Dispose();
            }
        }
        #endregion

        #region ���|����
        public void m_EmptyAndInitialization()
        {
            //��ղ��˻�����Ϣ
            //m_EmptyBaseInfo();
            //���סԺ��Ϣ
            //m_EmptyBihRegisterInfo();
            ////��յ�ת��Ϣ
            //m_EmptyBihTransferInfo();
            ////��ճ�Ժ��Ϣ
            //m_EmptyBihLeaveInfo();
            ////���סԺ״̬ ��������ذ�ť�ı�
            //m_EmptyBihState();

        }
        #endregion

        #region ��ղ��˻�����Ϣ
        /// <summary>
        /// ��ղ��˻�����Ϣ
        /// </summary>
        public void m_EmptyBaseInfo()
        {

        }

        internal void QueryPatient()
        {
            //clsPatient_VO objPatientVO = null;
            
            long lngReg = 0;
           // lngReg = m_objRegister.m_lngGetPatientInfoByInpatientID(m_strInPatientID, out objPatientVO);
            lngReg = m_objRegister.m_lngGetPatientInfoByREGISTERID_CHR(m_strRegisterID, out objPatientVO);
         
            if (lngReg > 0 && objPatientVO != null)
          {
              m_EmptyAndInitialization();
              VoToValueForAll(objPatientVO);
              LoadBihRegister();
              //���벡�˵�ת��Ϣ
              //LoadBihTransfer();
              //�����Ժ��Ϣ
              //LoadBihLeave();
              //��Ժ���
             // m_mthPatientDiag();
             // this.m_objViewer.m_cboTYPE_INT.Focus();
          }
					
        }
        #endregion

        #region Vo��ֵ���ؼ�
        /// <summary>
        /// Vo��ֵ���ؼ� {���¸�ֵ}
        /// </summary>
        /// <param name="objPatientVO"></param>
        private void VoToValueForAll(clsPatient_VO objPatientVO)
        {
            if (objPatientVO == null)
                return;

            string strTem = "";

            //�������� 
            m_objViewer.txtPatientName1.Text = objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
            //��������
            if (objPatientVO.m_strBIRTH_DAT != null && objPatientVO.m_strBIRTH_DAT.ToString() != "")
                m_objViewer.dtpBirthDate2.Text = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT.ToString()).ToString();
            //���֤�� 
            m_objViewer.txtIDCard1.Text = objPatientVO.m_strIDCARD_CHR;
            //��ϵ�绰 
            m_objViewer.txtPhone1.Text = objPatientVO.m_strHOMEPHONE_VCHR;
            //�칫�ʱ� 
            m_objViewer.txtOfficepc1.Text = objPatientVO.m_strOFFICEPC_VCHR;
            //��ϵ������ 
            m_objViewer.txtContactpersonFirstaName1.Text = objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR; // + objPatientVO.m_strCONTACTPERSONPHONE_VCHR
            //��ϵ�˵绰 
            m_objViewer.txtContactpersonPhone1.Text = objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
            //����ϵ�˹�ϵ 
            m_objViewer.txtRelation2.Text = objPatientVO.m_strPATIENTRELATION_VCHR;
            //��ϵ�˵�ַ 
            m_objViewer.txtContactpersonAddress1.Text = objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
            //�Ա� 
            m_objViewer.cboSex2.Text = objPatientVO.m_strSEX_CHR;
            //��� 
            m_objViewer.cobMarried2.Text = objPatientVO.m_strMARRIED_CHR;
            //���� 
            if (objPatientVO.m_strRACE_VCHR == null || objPatientVO.m_strRACE_VCHR == "")
            {
                m_objViewer.txtRace2.Text = "����";
            }
            else
            {
                m_objViewer.txtRace2.Text = objPatientVO.m_strRACE_VCHR;
            }
            //����
            if (objPatientVO.m_strNATIONALITY_VCHR == null || objPatientVO.m_strNATIONALITY_VCHR == "")
            {
                m_objViewer.txtNationality2.Text = "�й�";
            }
            else
            {
                m_objViewer.txtNationality2.Text = objPatientVO.m_strNATIONALITY_VCHR;
            }
            //��ͥסַ(���ڵ�ַ) 
            m_objViewer.txtAddress1.Text = objPatientVO.m_strHOMEADDRESS_VCHR;
            //ְҵ 
            m_objViewer.txtOccupation2.Text = objPatientVO.m_strOCCUPATION_VCHR;
            //������ 
            m_objViewer.txtBirthPlace1.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            //������λ 
            m_objViewer.txtEmployer1.Text = objPatientVO.m_strEMPLOYER_VCHR;
            //�칫��ַ
            m_objViewer.txtOfficeAddress1.Text = objPatientVO.m_strOFFICEADDRESS_VCHR;
           


            //���ƿ���
           // m_objViewer.txtPATIENTCARDID.Text = m_objRegister.m_strGetPatientcardidByPatientID(objPatientVO.m_strPATIENTID_CHR);

            //������Ϣ
            //���˱��
            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;
            //ҽ�����
           // m_objViewer.txtInsuranceID.Text = objPatientVO.m_strINSURANCEID_VCHR;
           
            //�������
            m_objViewer.cobPaytypeid2.Text =objPatientVO.m_strPAYTYPEID_CHR;
            //סԺ���
            m_objViewer.txtINPatient1.Text = objPatientVO.m_strINPATIENTID_CHR;
            m_strInPatientID = m_objViewer.txtINPatient1.Text.Trim();
            //�Ƿ�Ա��
            //m_objViewer.cboIsemployee1.Text = (Convert.ToBoolean(objPatientVO.m_intISEMPLOYEE_INT)) ? "��" : "��";
            //�ƶ��绰 
           // m_objViewer.txtMobile1.Text = objPatientVO.m_strMOBILE_CHR;
            //�������� 
           // if (objPatientVO.m_strFIRSTDATE_DAT != null && objPatientVO.m_strFIRSTDATE_DAT.ToString() != "")
            //    m_objViewer.dtpFirstDate.Value = Convert.ToDateTime(objPatientVO.m_strFIRSTDATE_DAT.ToString());
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
          //  m_objViewer.cobStatus.Text = strTem;
           
            //��ϸ��Ϣ
           
           
            //���� 
            m_objViewer.m_txtNativeplace2.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            
            //��ַ�ʱ� 
            m_objViewer.txtHomepc1.Text = objPatientVO.m_strHOMEPC_CHR;
           
           //��ϵ���ʱ� 
            //m_objViewer.txtContactpersonpc.Text = objPatientVO.m_strCONTACTPERSONPC_CHR;
             //�칫�绰 
           // m_objViewer.txtOfficephone.Text = objPatientVO.m_strOFFICEPHONE_VCHR;
         
            //�������� 
            //m_objViewer.txtEmail.Text = objPatientVO.m_strEMAIL_VCHR;
            //��������
            //m_objViewer.txtDeactivateDate.Text = objPatientVO.m_strDEACTIVATE_DAT;
            //������Ա
           // m_objViewer.txtOperatorid.Text = objPatientVO.m_strOPERATORID_CHR;
            //��������
          //  m_objViewer.txtModifydate.Text = objPatientVO.m_strMODIFY_DAT;
            //�������


            m_strPayType = objPatientVO.m_strPAYTYPEID_CHR;
            for (int i = 0; i < this.m_objViewer.cobPaytypeid2.Items.Count; i++)
            {
                if (objPatientVO.m_strPAYTYPEID_CHR == ((com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[])this.m_objViewer.cobPaytypeid2.Tag)[i].m_strPAYTYPEID_CHR)
                {
                    m_objViewer.cobPaytypeid2.SelectedIndex = i;//.Text =objPatientVO.m_strPAYTYPEID_CHR;
                }
            }
            
        }
        #endregion

        #region ����סԺ��Ϣ
        /// <summary>
        /// ����סԺ��Ϣ[����סԺ��]
        /// </summary>
        public void LoadBihRegister()
        {
            if (m_strInPatientID == string.Empty)
            {
                //m_objViewer.m_txtINPATIENTCOUNT_INT.Text = "0";
                //m_objViewer.cmdBihRecall.Enabled = false;
                return;
            }
            // ��ȡסԺ�ŵ����һ��סԺ�Ǽ���ˮ��
            long lngReg = m_objRegister.m_lngGetRegisteridByInpatientID(m_strInPatientID, out m_strRegisterID);
            if (lngReg < 0)
                return;
            if (m_strRegisterID == "")
            {
                //m_objViewer.m_txtINPATIENTCOUNT_INT.Text = "0";
                return;
            }
            //����סԺ��ˮ�� ��ѯסԺ�Ǽ�
            //clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
            lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(m_strRegisterID, out m_objItem);
            if (lngReg <= 0 || m_objItem == null)
                return;

            //���ؼ���ֵ
            //��������
            m_objViewer.m_txtLIMITRATE_MNY1.Text = m_objItem.m_dblLIMITRATE_MNY.ToString();
            //����
            m_objViewer.m_txtAREAID_CHR1.txtValuse = m_objItem.m_strAreaName;
            m_objViewer.m_txtAREAID_CHR1.Tag = m_objItem.m_strAREAID_CHR;
            //��Ժ����
            m_objViewer.m_dateInHosp2.Text = m_objItem.m_strINPATIENT_DAT.ToString();
            m_objViewer.m_dateInHosp2.Tag = m_objItem.m_strINPATIENT_DAT.ToString();
            //��Ժ��ʽ{1=����;2=����;3=��Ժת��;4=����ת��}
            m_objViewer.m_cboTYPE_INT1.SelectedIndex = m_objItem.m_intTYPE_INT;
           //��Ժ����
            m_objViewer.m_txtBEDID_CHR1.Text = m_objItem.m_strBedNo;
            m_objViewer.m_txtBEDID_CHR1.Tag = m_objItem.m_strBEDID_CHR;

            //����ҽ��]
            //this.m_objViewer.m_txtOutPatientDoctor2.Text = m_objItem.m_stroutdoctorname;
            //this.m_objViewer.m_txtOutPatientDoctor2.Tag = m_objItem.m_strMZDOCTOR_CHR;
            //���� {1Σ��2����3��ͨ}
            m_objViewer.m_cboSTATE_INT2.SelectedIndex = m_objItem.m_intSTATE_INT;
            //�������
            m_objViewer.m_txtOutPatientDiagnose1.Text = m_objItem.m_strMZDIAGNOSE_VCHR;
           
            #region	��Ժ��(ҽ��)	glzhang	20005.08.10
            m_objViewer.m_txtDIAGNOSE_VCHR1.Text = m_objItem.m_strDIAGNOSE_VCHR;
            m_objViewer.m_txtDIAGNOSE_VCHR1.Tag = m_objItem.m_strDIAGNOSEID_CHR;
            #endregion
            #region ��ע,��Ժ���ICD10 glzhang	2005.08.10

            this.m_objViewer.m_txtICD1.Text = m_objItem.m_strICD10DIAGTEXT_VCHR;
            this.m_objViewer.m_txtICD1.Tag = (string)m_objItem.m_strICD10DIAGID_VCHR;
            #endregion
            //��Ժ���ҡ�����������
            //m_objViewer.m_txtDEPTID_CHR1.Text = m_objItem.m_strDeptName;
            //m_objViewer.m_txtDEPTID_CHR1.Tag = m_objItem.m_strDEPTID_CHR;
            //LoadAreaID();//33
          
            if (m_objItem.m_intPSTATUS_INT == 1 || m_objItem.m_intPSTATUS_INT == 2 || m_objItem.m_intPSTATUS_INT == 4)
            {
                m_objViewer.m_txtBEDID_CHR1.Text = m_objItem.m_strBedNo;
                m_objViewer.m_txtBEDID_CHR1.Tag = m_objItem.m_strBEDID_CHR;
            }
           
            //m_objViewer.m_lblOperatorName.Text = m_objRegister.m_GetEmployeeNameByID(m_objItem.m_strOPERATORID_CHR);
            //סԺ״̬	{0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
            m_intPStatus = m_objItem.m_intPSTATUS_INT;

          //���ｨ��Ԥ����
            m_strCLINICSAYPREPAY = m_objItem.m_strCLINICSAYPREPAY;

            //������δ���Ŵ�λ�����޸�)
            if (m_intPStatus < 1)
            {
                
                m_objViewer.m_txtAREAID_CHR1.Enabled = true;
                
            }


            //����ҽ��]
            this.m_objViewer.m_txtOutPatientDoctor2.txtValuse = m_objItem.m_stroutdoctorname;
            this.m_objViewer.m_txtOutPatientDoctor2.Tag = m_objItem.m_strMZDOCTOR_CHR;
           
        }
        #endregion 

        /// <summary>
        /// �ؼ���ֵ��Vo {������Ϣ}
        /// </summary>
        /// <param name="objPatientVO">[out ����]</param>
        private void ValueToVoForBaseInfo()
        {
           // objPatientVO = new clsPatient_VO();
            //������Ϣ
            //���˱��
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //ҽ�����
            //objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.txtInsuranceID.Text;
            //��������
            objPatientVO.m_strBIRTH_DAT = m_objViewer.dtpBirthDate2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //���֤�� 
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard1.Text;
            //�������� 
            objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName1.Text;
            objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName1.Text;
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName1.Text;
            //��ϵ�绰 
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone1.Text;
            //�Ա� 
            objPatientVO.m_strSEX_CHR = m_objViewer.cboSex2.Text;
            //�������
           // objPatientVO.m_strPAYTYPEID_CHR = m_strPayType;
            ////�������
            //if (this.m_objViewer.cobPaytypeid2.SelectedIndex >= 0)
            //{
            //    objPatientVO.m_strPAYTYPEID_CHR = ((com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[])this.m_objViewer.cobPaytypeid2.Tag)[this.m_objViewer.cobPaytypeid2.SelectedIndex].m_strPAYTYPEID_CHR;
            //}
            //סԺ���
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //�Ƿ�Ա��
            //objPatientVO.m_intISEMPLOYEE_INT = (m_objViewer.cboIsemployee.Text.Trim() == "��") ? 1 : 0;
            //��� 
            objPatientVO.m_strMARRIED_CHR = m_objViewer.cobMarried2.Text;
            //�ƶ��绰 
            //objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //�������� 
           // objPatientVO.m_strFIRSTDATE_DAT = m_objViewer.dtpFirstDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
         
           // objPatientVO.m_intSTATUS_INT = 1;
            //��ͥסַ 
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress1.Text;

            //��ϸ��Ϣ
            //����
            objPatientVO.m_strNATIONALITY_VCHR = m_objViewer.txtNationality2.Text;
            //���� 
            objPatientVO.m_strRACE_VCHR = m_objViewer.txtRace2.Text;
            //���� 
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txtNativeplace2.Text;
            //ְҵ 
            objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.txtOccupation2.Text;
            //��ַ�ʱ� 
            objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc1.Text;
            //������ 
            objPatientVO.m_strBIRTHPLACE_VCHR = m_objViewer.txtBirthPlace1.Text;
            //��ϵ������ 
            objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName1.Text;
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName1.Text;
            //��ϵ�˵绰 
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone1.Text;
            //��ϵ���ʱ� 
            //objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //����ϵ�˹�ϵ 
            objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.txtRelation2.Text;
            //��ϵ�˵�ַ 
            objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress1.Text;
            //�칫�绰 
            //objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //�칫�ʱ� 
            objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc1.Text;
            //������λ 
            objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer1.Text;
            //�������� 
            //objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //�칫��ַ
            objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress1.Text;

            //������Ա
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //��������
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           
        }

        #region�����没����Ϣ
       
        public long m_SaveInfo()
        {
            if (this.m_strRegisterID.Trim().Equals(""))
            {
                return 0;
            }
            long lngReg = 0;
            //סԺʱ���޸ĵ��ж�
            DateTime m_strNewDate = m_objViewer.m_dateInHosp2.Value;
            if (m_intPStatus < 1)
            {

                DateTime m_strOldDate = Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT.ToString());
                if (m_strNewDate.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show(m_objViewer, "��Ժʱ�䲻�ܴ��ڵ�ǰϵͳʱ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // m_objViewer.m_dateInHosp2.Text = m_strOldDate.ToString();
                    m_objViewer.m_dateInHosp2.Focus();
                    return lngReg;
                }

            }
            else if (m_intPStatus >= 1)
            {

                DateTime m_strOldDate = Convert.ToDateTime(m_objItem.m_strMODIFY_DAT.ToString());
                if (m_strNewDate.CompareTo(m_strOldDate) > 0)
                {
                    MessageBox.Show(m_objViewer, "��Ժʱ�䲻�ܴ��ڰ��Ŵ�λ��ʱ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //  m_objViewer.m_dateInHosp2.Text = m_strOldDate.ToString();
                    m_objViewer.m_dateInHosp2.Focus();
                    return lngReg;
                }
            }
            /*<-----------------------------------------*/

           
            long ret = 0;

           
             ValueToVoForBaseInfo();
            if (!ValueToVoForBIHInfo())
                return lngReg;
            int intState = 1;
            if (m_intPStatus == 0 || m_intPStatus == 1) intState = 2;
            if (m_intPStatus == 2 || m_intPStatus == 3) intState = 3;
                try
                {
                    lngReg = m_objRegister.m_lngChangeRegisterHospital(intState, objPatientVO, ref m_objItem);
                 
            
                }
                catch (Exception e)
                {
                    MessageBox.Show(m_objViewer, e.Message, "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return lngReg;
                }
           


            //���������ʾ
            if (lngReg > 0)
            {
                string strMessage = "�����ɹ�!";
                if (ret > 0)
                {
                    strMessage = "�����ɹ�!";
                }
                else
                {
                    strMessage = "�����ɹ�!";
                }
               
                MessageBox.Show(m_objViewer, strMessage, "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // m_objViewer.txtINPatient.Text = objBIHVO.m_strINPATIENTID_CHR;
                m_objViewer.Cursor = Cursors.WaitCursor;
                //����סԺ�Ż�ȡ���˻�����Ϣ
                //if (LoadPatientInfoByInpatientID())
                //{
                //    //����סԺ��Ϣ
                //    LoadBihRegister();
                //    //���벡�˵�ת��Ϣ
                //    LoadBihTransfer();
                //    //�����Ժ��Ϣ
                //    LoadBihLeave();
                //}
                m_objViewer.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(m_objViewer, "����ʧ�ܣ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lngReg;
        }
 
        #endregion

        #region �ؼ���ֵ��Vo {סԺ��Ϣ}
        /// <summary> 
        /// �ؼ���ֵ��Vo {סԺ��Ϣ}
        /// </summary>
        /// <param name="objPatientVO">[out ����]</param>
        private bool ValueToVoForBIHInfo()
        {
           // m_objItem = new clsT_Opr_Bih_Register_VO();

            //��Ժ�Ǽ���ˮ��(200409010001)
            m_objItem.m_strREGISTERID_CHR = m_strRegisterID;
            //���ˣɣ�
            m_objItem.m_strPATIENTID_CHR = m_strPatientID;
            //�Ƿ�ԤԼ
            //m_objItem.m_intISBOOKING_INT = Convert.ToInt16(m_objViewer.m_chkISBOOKING_INT.Checked);
            //סԺ��
            m_objItem.m_strINPATIENTID_CHR = m_strInPatientID;
            //��Ժ����
            m_objItem.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                
           

            //��Ժ���ҡ���Ժ��������Ժ����
            m_objItem.m_strDEPTID_CHR = "";
            m_objItem.m_strBEDID_CHR = "";
           
            if (m_objViewer.m_txtAREAID_CHR1.Tag != null)
            {
                m_objItem.m_strAREAID_CHR = ((string)m_objViewer.m_txtAREAID_CHR1.Tag).ToString();
            }
            if (m_objViewer.m_txtBEDID_CHR1.Tag != null)
            {
                m_objItem.m_strBEDID_CHR = ((string)m_objViewer.m_txtBEDID_CHR1.Tag).ToString();
            }
         
            //��Ժ��ʽ {��������������Ժת��}
            m_objItem.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT1.SelectedIndex;
            //��Ժ���
            m_objItem.m_strDIAGNOSE_VCHR = m_objViewer.m_txtDIAGNOSE_VCHR1.Text.Trim();
            //��������
            //try
            //{
            //    Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY1.Text.Trim());
            //}
            //catch
            //{
            //    m_objViewer.m_txtLIMITRATE_MNY1.Focus();
            //    MessageBox.Show(this.m_objViewer, "��������Ч����");
            //    return false;
            //}
            //m_objItem.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY1.Text.Trim());

            //��Ժ����
            //m_objItem.m_intINPATIENTCOUNT_INT = int.Parse(m_objViewer.m_txtINPATIENTCOUNT_INT.Text.Trim());
            //���顡����Σ������������ͨ��
            m_objItem.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT2.SelectedIndex;
            //״̬����������ʷ������Ч������Ч��
            m_objItem.m_intSTATUS_INT = 1;
            //�����ˡ�����ʱ��
            m_objItem.m_strOPERATORID_CHR = m_strOperatorID;
            m_objItem.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //������Ժ״̬	{0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}
            m_objItem.m_intPSTATUS_INT = 0;
            if (m_objItem.m_strBEDID_CHR != null && m_objItem.m_strBEDID_CHR != string.Empty)
            {
                m_objItem.m_intPSTATUS_INT = 1;
            }
            
            //��ע
            //m_objItem.DES_VCHR = this.m_objViewer.m_txtRemark.Text;
            //סԺ������
           // m_objItem.m_intINPATIENTNOTYPE_INT = this.m_objViewer.m_cboInpatientNoType.SelectedIndex + 1;
            //����ҽ��]
            m_objItem.m_strMZDOCTOR_CHR = (string)this.m_objViewer.m_txtOutPatientDoctor2.Tag;
            //�������
            m_objItem.m_strMZDIAGNOSE_VCHR = this.m_objViewer.m_txtOutPatientDiagnose1.Text;

            //��Ժ���id(ҽ����) Add by jli in 2005-05-20
            if (this.m_objViewer.m_txtDIAGNOSE_VCHR1.Tag != null)
            {
                try
                {
                    m_objItem.m_strDIAGNOSEID_CHR = (string)this.m_objViewer.m_txtDIAGNOSE_VCHR1.Tag;
                }
                catch
                {
                    m_objItem.m_strDIAGNOSEID_CHR = "";
                }
            }
            else
            {
                m_objItem.m_strDIAGNOSEID_CHR = "";
            }

            #region ��Ժ���ICD10 glzhang	2005.08.10
            m_objItem.m_strICD10DIAGID_VCHR = (string)m_objViewer.m_txtICD1.Tag;
            m_objItem.m_strICD10DIAGTEXT_VCHR = m_objViewer.m_txtICD1.Text;
            #endregion
            
            if (this.m_objViewer.cobPaytypeid2.SelectedIndex >= 0)
            {
                m_objItem.m_strPAYTYPEID_CHR = ((com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[])this.m_objViewer.cobPaytypeid2.Tag)[this.m_objViewer.cobPaytypeid2.SelectedIndex].m_strPAYTYPEID_CHR;
            }

            return true;
        }
        #endregion

        internal void m_chnageTheTime()
        {
           
        }

        internal long m_lngGetNativeplace(string m_strFindCode, out DataTable m_dtResult)
        {
            long lngReg = m_objRegister.m_lngGetNativeplace(m_strFindCode, out m_dtResult);
            return lngReg;
        }
    }
}
