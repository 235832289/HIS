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
        #region 变量
        com.digitalwave.iCare.gui.HIS.clsDcl_Register m_objRegister = null;
        clsDcl_BedAdmin m_objBedAdmin = null;
        public string m_strOperatorID;
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// 病人编号
        /// </summary>
        public string m_strPatientID = "";
        /// <summary>
        /// 住院编号	[住院号]
        /// </summary>
        public string m_strInPatientID = "";
        /// <summary>
        /// 住院状态	{-1=首次入院;0=未上床;1=已上床;2=预出院;3=实际出院}
        /// </summary>
        public int m_intPStatus = -1;
        /// <summary>
        /// 门诊建议预交金
        /// </summary>
        public string m_strCLINICSAYPREPAY = "";
        /// <summary>
        /// 病人基本资料
        /// </summary>
        public clsPatient_VO objPatientVO = null;
        public clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
        /// <summary>
        /// 病人登记的收费类型
        /// </summary>
        private String m_strPayType;

        #endregion


        #region 构造函数
        public clsCtl_MessageChange()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objRegister = new com.digitalwave.iCare.gui.HIS.clsDcl_Register();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmMessageChange m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMessageChange)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化下拉框
        /// <summary>
        /// 初始化下拉框
        /// </summary>
        public void InitializationComboBox()
        {
            //初始化入院方式下拉框
            //入院方式{1=门诊;2=急诊;3=他院转入}
            m_objViewer.m_cboTYPE_INT1.Items.Clear();
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("", 0));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("1-门诊", 1));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("2-急诊", 2));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("3-他院转入", 3));
            m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("4-他科转入", 4));

            //初始化病情下拉框
            //病情{1=危;2=急;3=普通}
            m_objViewer.m_cboSTATE_INT2.Items.Clear();
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("", 0));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("1-危", 1));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("2-急", 2));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("3-普通", 3));

            //初始化费用类别下拉框
            m_objRegister.m_FillCboPatientType(m_objViewer.cobPaytypeid2);

            //初始化国籍类别下拉框
            m_objRegister.m_FillCboNationality(m_objViewer.txtNationality2);

            //初始化民族类别下拉框
            m_objRegister.m_FillCboPatientRace(m_objViewer.txtRace2);

            //初始化籍贯下拉框
            //m_objRegister.m_FillCboPatientNativeplace(m_objViewer.txtNationality2);

            //初始化职业下拉框
            m_objRegister.m_FillCboPatienttxtOccupation(m_objViewer.txtOccupation2);

            //初始化关系下拉框
            m_objRegister.m_FillCboPatientRelation(m_objViewer.txtRelation2);

            //初始化婚否下拉框
            m_objRegister.m_FillCboMarried(m_objViewer.cobMarried2);

            //初始化性别下拉框
            m_objRegister.m_FillCboSex(m_objViewer.cboSex2);
        }
        #endregion

        public void SetCurrentDoctor(com.digitalwave.iCare.ValueObject.clsLoginInfo loginInfo)
        {
            this.m_strOperatorID = loginInfo.m_strEmpID;
        }

        #region 载入科室对应的病区
        /// <summary>
        /// 载入科室对应的病区
        /// </summary>
        public void LoadAreaID()
        {
            
            DataTable dtbTemp = new DataTable();

            dtbTemp.Columns.Add(" 病区编号	");
            dtbTemp.Columns.Add(" 病区名称	");
            dtbTemp.Columns.Add("id");

            DataRow dtRTemp;
            //科室ID为空则返回
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

        #region 载入门诊医生信息	glzhang		2005.07.12
        /// <summary>
        /// 载入门诊医生信息	glzhang		2005.07.12
        /// </summary>
        public void m_mthLoadMainDoctor()
        {
            DataTable tempTable = new DataTable();

            DataRow tempRow;
            com.digitalwave.iCare.ValueObject.clsEmployee_VO[] DataResultArr = null;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetMainDoctor(this.m_objViewer.m_txtOutPatientDoctor2.Text.ToString().Trim().ToUpper(), out DataResultArr);
            if (lngRes > 0 && DataResultArr.Length > 0)
            {
                tempTable.Columns.Add("编号	");
                tempTable.Columns.Add("医生	");
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

        #region 清空|重置
        public void m_EmptyAndInitialization()
        {
            //清空病人基本信息
            //m_EmptyBaseInfo();
            //清空住院信息
            //m_EmptyBihRegisterInfo();
            ////清空调转信息
            //m_EmptyBihTransferInfo();
            ////清空出院信息
            //m_EmptyBihLeaveInfo();
            ////清空住院状态 并设置相关按钮文本
            //m_EmptyBihState();

        }
        #endregion

        #region 清空病人基本信息
        /// <summary>
        /// 清空病人基本信息
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
              //载入病人调转信息
              //LoadBihTransfer();
              //载入出院信息
              //LoadBihLeave();
              //入院诊断
             // m_mthPatientDiag();
             // this.m_objViewer.m_cboTYPE_INT.Focus();
          }
					
        }
        #endregion

        #region Vo赋值给控件
        /// <summary>
        /// Vo赋值给控件 {重新赋值}
        /// </summary>
        /// <param name="objPatientVO"></param>
        private void VoToValueForAll(clsPatient_VO objPatientVO)
        {
            if (objPatientVO == null)
                return;

            string strTem = "";

            //病人姓名 
            m_objViewer.txtPatientName1.Text = objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
            //出生年月
            if (objPatientVO.m_strBIRTH_DAT != null && objPatientVO.m_strBIRTH_DAT.ToString() != "")
                m_objViewer.dtpBirthDate2.Text = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT.ToString()).ToString();
            //身份证号 
            m_objViewer.txtIDCard1.Text = objPatientVO.m_strIDCARD_CHR;
            //联系电话 
            m_objViewer.txtPhone1.Text = objPatientVO.m_strHOMEPHONE_VCHR;
            //办公邮编 
            m_objViewer.txtOfficepc1.Text = objPatientVO.m_strOFFICEPC_VCHR;
            //联系人姓名 
            m_objViewer.txtContactpersonFirstaName1.Text = objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR; // + objPatientVO.m_strCONTACTPERSONPHONE_VCHR
            //联系人电话 
            m_objViewer.txtContactpersonPhone1.Text = objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
            //与联系人关系 
            m_objViewer.txtRelation2.Text = objPatientVO.m_strPATIENTRELATION_VCHR;
            //联系人地址 
            m_objViewer.txtContactpersonAddress1.Text = objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
            //性别 
            m_objViewer.cboSex2.Text = objPatientVO.m_strSEX_CHR;
            //婚否 
            m_objViewer.cobMarried2.Text = objPatientVO.m_strMARRIED_CHR;
            //民族 
            if (objPatientVO.m_strRACE_VCHR == null || objPatientVO.m_strRACE_VCHR == "")
            {
                m_objViewer.txtRace2.Text = "汉族";
            }
            else
            {
                m_objViewer.txtRace2.Text = objPatientVO.m_strRACE_VCHR;
            }
            //国籍
            if (objPatientVO.m_strNATIONALITY_VCHR == null || objPatientVO.m_strNATIONALITY_VCHR == "")
            {
                m_objViewer.txtNationality2.Text = "中国";
            }
            else
            {
                m_objViewer.txtNationality2.Text = objPatientVO.m_strNATIONALITY_VCHR;
            }
            //家庭住址(户口地址) 
            m_objViewer.txtAddress1.Text = objPatientVO.m_strHOMEADDRESS_VCHR;
            //职业 
            m_objViewer.txtOccupation2.Text = objPatientVO.m_strOCCUPATION_VCHR;
            //出生地 
            m_objViewer.txtBirthPlace1.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            //工作单位 
            m_objViewer.txtEmployer1.Text = objPatientVO.m_strEMPLOYER_VCHR;
            //办公地址
            m_objViewer.txtOfficeAddress1.Text = objPatientVO.m_strOFFICEADDRESS_VCHR;
           


            //诊疗卡号
           // m_objViewer.txtPATIENTCARDID.Text = m_objRegister.m_strGetPatientcardidByPatientID(objPatientVO.m_strPATIENTID_CHR);

            //基本信息
            //病人编号
            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;
            //医保编号
           // m_objViewer.txtInsuranceID.Text = objPatientVO.m_strINSURANCEID_VCHR;
           
            //费用类别
            m_objViewer.cobPaytypeid2.Text =objPatientVO.m_strPAYTYPEID_CHR;
            //住院编号
            m_objViewer.txtINPatient1.Text = objPatientVO.m_strINPATIENTID_CHR;
            m_strInPatientID = m_objViewer.txtINPatient1.Text.Trim();
            //是否员工
            //m_objViewer.cboIsemployee1.Text = (Convert.ToBoolean(objPatientVO.m_intISEMPLOYEE_INT)) ? "是" : "否";
            //移动电话 
           // m_objViewer.txtMobile1.Text = objPatientVO.m_strMOBILE_CHR;
            //初诊日期 
           // if (objPatientVO.m_strFIRSTDATE_DAT != null && objPatientVO.m_strFIRSTDATE_DAT.ToString() != "")
            //    m_objViewer.dtpFirstDate.Value = Convert.ToDateTime(objPatientVO.m_strFIRSTDATE_DAT.ToString());
            //有效状态 {1：有效、0：无效、-1：历史}
            switch (objPatientVO.m_intSTATUS_INT)
            {
                case 1:
                    strTem = "有效";
                    break;
                case 0:
                    strTem = "无效";
                    break;
                case -1:
                    strTem = "历史";
                    break;
                default:
                    strTem = "";
                    break;
            }
          //  m_objViewer.cobStatus.Text = strTem;
           
            //详细信息
           
           
            //籍贯 
            m_objViewer.m_txtNativeplace2.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            
            //地址邮编 
            m_objViewer.txtHomepc1.Text = objPatientVO.m_strHOMEPC_CHR;
           
           //联系人邮编 
            //m_objViewer.txtContactpersonpc.Text = objPatientVO.m_strCONTACTPERSONPC_CHR;
             //办公电话 
           // m_objViewer.txtOfficephone.Text = objPatientVO.m_strOFFICEPHONE_VCHR;
         
            //电子邮箱 
            //m_objViewer.txtEmail.Text = objPatientVO.m_strEMAIL_VCHR;
            //作废日期
            //m_objViewer.txtDeactivateDate.Text = objPatientVO.m_strDEACTIVATE_DAT;
            //操作人员
           // m_objViewer.txtOperatorid.Text = objPatientVO.m_strOPERATORID_CHR;
            //更新日期
          //  m_objViewer.txtModifydate.Text = objPatientVO.m_strMODIFY_DAT;
            //费用类别


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

        #region 载入住院信息
        /// <summary>
        /// 载入住院信息[根据住院号]
        /// </summary>
        public void LoadBihRegister()
        {
            if (m_strInPatientID == string.Empty)
            {
                //m_objViewer.m_txtINPATIENTCOUNT_INT.Text = "0";
                //m_objViewer.cmdBihRecall.Enabled = false;
                return;
            }
            // 获取住院号的最近一次住院登记流水号
            long lngReg = m_objRegister.m_lngGetRegisteridByInpatientID(m_strInPatientID, out m_strRegisterID);
            if (lngReg < 0)
                return;
            if (m_strRegisterID == "")
            {
                //m_objViewer.m_txtINPATIENTCOUNT_INT.Text = "0";
                return;
            }
            //根据住院流水号 查询住院登记
            //clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
            lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(m_strRegisterID, out m_objItem);
            if (lngReg <= 0 || m_objItem == null)
                return;

            //给控件赋值
            //费用下限
            m_objViewer.m_txtLIMITRATE_MNY1.Text = m_objItem.m_dblLIMITRATE_MNY.ToString();
            //病区
            m_objViewer.m_txtAREAID_CHR1.txtValuse = m_objItem.m_strAreaName;
            m_objViewer.m_txtAREAID_CHR1.Tag = m_objItem.m_strAREAID_CHR;
            //入院日期
            m_objViewer.m_dateInHosp2.Text = m_objItem.m_strINPATIENT_DAT.ToString();
            m_objViewer.m_dateInHosp2.Tag = m_objItem.m_strINPATIENT_DAT.ToString();
            //入院方式{1=门诊;2=急诊;3=他院转入;4=他科转入}
            m_objViewer.m_cboTYPE_INT1.SelectedIndex = m_objItem.m_intTYPE_INT;
           //入院床号
            m_objViewer.m_txtBEDID_CHR1.Text = m_objItem.m_strBedNo;
            m_objViewer.m_txtBEDID_CHR1.Tag = m_objItem.m_strBEDID_CHR;

            //门诊医生]
            //this.m_objViewer.m_txtOutPatientDoctor2.Text = m_objItem.m_stroutdoctorname;
            //this.m_objViewer.m_txtOutPatientDoctor2.Tag = m_objItem.m_strMZDOCTOR_CHR;
            //病情 {1危、2急、3普通}
            m_objViewer.m_cboSTATE_INT2.SelectedIndex = m_objItem.m_intSTATE_INT;
            //门诊诊断
            m_objViewer.m_txtOutPatientDiagnose1.Text = m_objItem.m_strMZDIAGNOSE_VCHR;
           
            #region	入院断(医保)	glzhang	20005.08.10
            m_objViewer.m_txtDIAGNOSE_VCHR1.Text = m_objItem.m_strDIAGNOSE_VCHR;
            m_objViewer.m_txtDIAGNOSE_VCHR1.Tag = m_objItem.m_strDIAGNOSEID_CHR;
            #endregion
            #region 备注,入院诊断ICD10 glzhang	2005.08.10

            this.m_objViewer.m_txtICD1.Text = m_objItem.m_strICD10DIAGTEXT_VCHR;
            this.m_objViewer.m_txtICD1.Tag = (string)m_objItem.m_strICD10DIAGID_VCHR;
            #endregion
            //入院科室、病区、床号
            //m_objViewer.m_txtDEPTID_CHR1.Text = m_objItem.m_strDeptName;
            //m_objViewer.m_txtDEPTID_CHR1.Tag = m_objItem.m_strDEPTID_CHR;
            //LoadAreaID();//33
          
            if (m_objItem.m_intPSTATUS_INT == 1 || m_objItem.m_intPSTATUS_INT == 2 || m_objItem.m_intPSTATUS_INT == 4)
            {
                m_objViewer.m_txtBEDID_CHR1.Text = m_objItem.m_strBedNo;
                m_objViewer.m_txtBEDID_CHR1.Tag = m_objItem.m_strBEDID_CHR;
            }
           
            //m_objViewer.m_lblOperatorName.Text = m_objRegister.m_GetEmployeeNameByID(m_objItem.m_strOPERATORID_CHR);
            //住院状态	{0=未上床;1=已上床;2=预出院;3=实际出院}
            m_intPStatus = m_objItem.m_intPSTATUS_INT;

          //门诊建议预交金
            m_strCLINICSAYPREPAY = m_objItem.m_strCLINICSAYPREPAY;

            //病区（未安排床位可以修改)
            if (m_intPStatus < 1)
            {
                
                m_objViewer.m_txtAREAID_CHR1.Enabled = true;
                
            }


            //门诊医生]
            this.m_objViewer.m_txtOutPatientDoctor2.txtValuse = m_objItem.m_stroutdoctorname;
            this.m_objViewer.m_txtOutPatientDoctor2.Tag = m_objItem.m_strMZDOCTOR_CHR;
           
        }
        #endregion 

        /// <summary>
        /// 控件赋值给Vo {基本信息}
        /// </summary>
        /// <param name="objPatientVO">[out 参数]</param>
        private void ValueToVoForBaseInfo()
        {
           // objPatientVO = new clsPatient_VO();
            //基本信息
            //病人编号
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //医保编号
            //objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.txtInsuranceID.Text;
            //出生年月
            objPatientVO.m_strBIRTH_DAT = m_objViewer.dtpBirthDate2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //身份证号 
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard1.Text;
            //病人姓名 
            objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName1.Text;
            objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName1.Text;
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName1.Text;
            //联系电话 
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone1.Text;
            //性别 
            objPatientVO.m_strSEX_CHR = m_objViewer.cboSex2.Text;
            //费用类别
           // objPatientVO.m_strPAYTYPEID_CHR = m_strPayType;
            ////费用类别
            //if (this.m_objViewer.cobPaytypeid2.SelectedIndex >= 0)
            //{
            //    objPatientVO.m_strPAYTYPEID_CHR = ((com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[])this.m_objViewer.cobPaytypeid2.Tag)[this.m_objViewer.cobPaytypeid2.SelectedIndex].m_strPAYTYPEID_CHR;
            //}
            //住院编号
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //是否员工
            //objPatientVO.m_intISEMPLOYEE_INT = (m_objViewer.cboIsemployee.Text.Trim() == "是") ? 1 : 0;
            //婚否 
            objPatientVO.m_strMARRIED_CHR = m_objViewer.cobMarried2.Text;
            //移动电话 
            //objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //初诊日期 
           // objPatientVO.m_strFIRSTDATE_DAT = m_objViewer.dtpFirstDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
         
           // objPatientVO.m_intSTATUS_INT = 1;
            //家庭住址 
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress1.Text;

            //详细信息
            //国籍
            objPatientVO.m_strNATIONALITY_VCHR = m_objViewer.txtNationality2.Text;
            //民族 
            objPatientVO.m_strRACE_VCHR = m_objViewer.txtRace2.Text;
            //籍贯 
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txtNativeplace2.Text;
            //职业 
            objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.txtOccupation2.Text;
            //地址邮编 
            objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc1.Text;
            //出生地 
            objPatientVO.m_strBIRTHPLACE_VCHR = m_objViewer.txtBirthPlace1.Text;
            //联系人姓名 
            objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName1.Text;
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName1.Text;
            //联系人电话 
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone1.Text;
            //联系人邮编 
            //objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //与联系人关系 
            objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.txtRelation2.Text;
            //联系人地址 
            objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress1.Text;
            //办公电话 
            //objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //办公邮编 
            objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc1.Text;
            //工作单位 
            objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer1.Text;
            //电子邮箱 
            //objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //办公地址
            objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress1.Text;

            //操作人员
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //更新日期
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           
        }

        #region　保存病人信息
       
        public long m_SaveInfo()
        {
            if (this.m_strRegisterID.Trim().Equals(""))
            {
                return 0;
            }
            long lngReg = 0;
            //住院时间修改的判断
            DateTime m_strNewDate = m_objViewer.m_dateInHosp2.Value;
            if (m_intPStatus < 1)
            {

                DateTime m_strOldDate = Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT.ToString());
                if (m_strNewDate.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show(m_objViewer, "入院时间不能大于当前系统时间!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(m_objViewer, "入院时间不能大于安排床位的时间!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show(m_objViewer, e.Message, "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return lngReg;
                }
           


            //操作结果提示
            if (lngReg > 0)
            {
                string strMessage = "操作成功!";
                if (ret > 0)
                {
                    strMessage = "操作成功!";
                }
                else
                {
                    strMessage = "操作成功!";
                }
               
                MessageBox.Show(m_objViewer, strMessage, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // m_objViewer.txtINPatient.Text = objBIHVO.m_strINPATIENTID_CHR;
                m_objViewer.Cursor = Cursors.WaitCursor;
                //根据住院号获取病人基本信息
                //if (LoadPatientInfoByInpatientID())
                //{
                //    //载入住院信息
                //    LoadBihRegister();
                //    //载入病人调转信息
                //    LoadBihTransfer();
                //    //载入出院信息
                //    LoadBihLeave();
                //}
                m_objViewer.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(m_objViewer, "操作失败！", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lngReg;
        }
 
        #endregion

        #region 控件赋值给Vo {住院信息}
        /// <summary> 
        /// 控件赋值给Vo {住院信息}
        /// </summary>
        /// <param name="objPatientVO">[out 参数]</param>
        private bool ValueToVoForBIHInfo()
        {
           // m_objItem = new clsT_Opr_Bih_Register_VO();

            //入院登记流水号(200409010001)
            m_objItem.m_strREGISTERID_CHR = m_strRegisterID;
            //病人ＩＤ
            m_objItem.m_strPATIENTID_CHR = m_strPatientID;
            //是否预约
            //m_objItem.m_intISBOOKING_INT = Convert.ToInt16(m_objViewer.m_chkISBOOKING_INT.Checked);
            //住院号
            m_objItem.m_strINPATIENTID_CHR = m_strInPatientID;
            //入院日期
            m_objItem.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                
           

            //入院科室、入院病区、入院病床
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
         
            //入院方式 {１门诊、２急诊、３他院转入}
            m_objItem.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT1.SelectedIndex;
            //入院诊断
            m_objItem.m_strDIAGNOSE_VCHR = m_objViewer.m_txtDIAGNOSE_VCHR1.Text.Trim();
            //费用下限
            //try
            //{
            //    Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY1.Text.Trim());
            //}
            //catch
            //{
            //    m_objViewer.m_txtLIMITRATE_MNY1.Focus();
            //    MessageBox.Show(this.m_objViewer, "请输入有效数字");
            //    return false;
            //}
            //m_objItem.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY1.Text.Trim());

            //入院次数
            //m_objItem.m_intINPATIENTCOUNT_INT = int.Parse(m_objViewer.m_txtINPATIENTCOUNT_INT.Text.Trim());
            //病情　｛１危、２急、３普通｝
            m_objItem.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT2.SelectedIndex;
            //状态　｛－１历史、０无效、１有效｝
            m_objItem.m_intSTATUS_INT = 1;
            //操作人、操作时间
            m_objItem.m_strOPERATORID_CHR = m_strOperatorID;
            m_objItem.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //患者在院状态	{0=未上床;1=已上床;2=预出院;3=实际出院}
            m_objItem.m_intPSTATUS_INT = 0;
            if (m_objItem.m_strBEDID_CHR != null && m_objItem.m_strBEDID_CHR != string.Empty)
            {
                m_objItem.m_intPSTATUS_INT = 1;
            }
            
            //备注
            //m_objItem.DES_VCHR = this.m_objViewer.m_txtRemark.Text;
            //住院号类型
           // m_objItem.m_intINPATIENTNOTYPE_INT = this.m_objViewer.m_cboInpatientNoType.SelectedIndex + 1;
            //门诊医生]
            m_objItem.m_strMZDOCTOR_CHR = (string)this.m_objViewer.m_txtOutPatientDoctor2.Tag;
            //门诊诊断
            m_objItem.m_strMZDIAGNOSE_VCHR = this.m_objViewer.m_txtOutPatientDiagnose1.Text;

            //入院诊断id(医保用) Add by jli in 2005-05-20
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

            #region 入院诊断ICD10 glzhang	2005.08.10
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
