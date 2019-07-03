using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using com.digitalwave.controls;
using com.digitalwave.common.ICD10.Tool;
using com.digitalwave.Emr.Signature_gui;
using System.Text.RegularExpressions;
using com.digitalwave.emr.AssistModuleVO;
using iCareData;

namespace iCare
{
    public partial class frmInPatientCaseHistory_XJ : iCare.frmBaseCaseHistory
    {
        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (txtSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                return "";
            }
        }
        #endregion 属性
        //定义签名类
        private clsEmrSignToolCollection m_objSign = null;
        private string m_strCurrentOpenDate = string.Empty;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        public frmInPatientCaseHistory_XJ()
        {
            InitializeComponent();

            m_mthInit();
            m_mthSetRichTextBoxAttribInControl(this);
            m_mthUnEnableRichTextBox();

            #region 新通用绑定签名
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse,员工ID);
            //记录者签名
            m_objSign.m_mthBindEmployeeSign(m_cmdCreateID, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);           
            //住院医师
            m_objSign.m_mthBindEmployeeSign(m_cmdDirectorDoc, m_txtDirectorDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //主治医师
            m_objSign.m_mthBindEmployeeSign(m_cmdChargeDoc, m_txtChargeDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //医师签名
            m_objSign.m_mthBindEmployeeSign(m_cmdAddDiagnoseDoctor, m_txtDiagnoseDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            #endregion
        }

        /// <summary>
        /// 显示体格检查窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdBodyCheck_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly objAsm = System.Reflection.Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath + "\\Emr_InpatMedRec.dll");
            object obj = objAsm.CreateInstance("iCare.frmIMR_intHosptalrecord");

            if (obj != null && obj is frmHRPBaseForm)
            {
                frmHRPBaseForm frmCheck = obj as frmHRPBaseForm;
                frmCheck.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmCheck.WindowState = FormWindowState.Maximized;

                if (clsEMRLogin.LoginInfo != null && obj is com.digitalwave.iCare.ValueObject.iLoginInfo)
                {
                    ((com.digitalwave.iCare.ValueObject.iLoginInfo)obj).LoginInfo = clsEMRLogin.LoginInfo;
                }

                frmCheck.Show();

                if (MDIParent.s_ObjCurrentPatient != null)
                    frmCheck.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
            }
        }

        private void m_cboCatameniaCase_IndexChanged(object sender, EventArgs e)
        {
            m_dtpLastCatameniaTime.Enabled = !m_cboCatameniaCase.Text.Trim().Equals("已绝经");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void m_mthInit()
        {
            m_cboCatameniaCase.SelectedIndexChanged += new EventHandler(m_cboCatameniaCase_IndexChanged);
        }

        protected override void m_mthUnEnableRichTextBox()
        {
            m_mthEnableRichTextBox(false);
        }

        private void m_mthEnableRichTextBox(bool p_blnEnabled)
        {
            this.m_txtBeforetimeStatus.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtCurrentStatus.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtFamilyHistory.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtLabCheck.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtMainDescription.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtMarriageHistory.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtOwnHistory.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtCatameniaHistory.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtDiagnose_CHN.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtDiagnose.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtaddDiagnose_CHN.m_BlnReadOnly = !p_blnEnabled;
            this.m_txtaddDiagnose.m_BlnReadOnly = !p_blnEnabled;
        }

        /// <summary>
        /// 设置月经生育史可不可用
        /// </summary>
        /// <param name="p_blnIfEnable"></param>
        private void m_mthEnableCatamenia(bool p_blnIfEnable)
        {
            m_grbCatamenia.Enabled = p_blnIfEnable;
            if (!p_blnIfEnable)
            {
                m_txtCatameniaHistory.m_mthClearText();
                this.m_cboFirstCatamenia.Text = "";
                this.m_cboCatameniaLastTime.Text = "";
                this.m_cboCatameniaCycle.Text = "";
                this.m_cboCatameniaCase.Text = "";
            }
            else
            {
                m_txtCatameniaHistory.m_BlnReadOnly = false;
                this.m_cboFirstCatamenia.Text = "14岁";
                this.m_cboCatameniaLastTime.Text = "5-6天";
                this.m_cboCatameniaCycle.Text = "28-30天";
                this.m_cboCatameniaCase.Text = "经量正常";
                this.m_txtCatameniaHistory.Text = "G1P1，一男一女，健康";
            }
        }


        #region OVERRIDE function
        // 获取选择已经删除记录的窗体标题
        public override void m_strReloadFormTitle()
        {

        }

        // 清空特殊记录信息，并重置记录控制状态为不控制。
        protected override void m_mthClearRecordInfo()
        {
            //m_objSignTool.m_mthSetDefaulEmployee();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);

            m_strCurrentOpenDate = "";

            this.m_txtBeforetimeStatus.m_mthClearText();
            this.m_txtCurrentStatus.m_mthClearText();
            this.m_txtFamilyHistory.m_mthClearText();
            this.m_txtLabCheck.m_mthClearText();
            this.m_txtMainDescription.m_mthClearText();
            this.m_txtMarriageHistory.m_mthClearText();
            this.m_txtOwnHistory.m_mthClearText();
            this.m_cboCredibility.SelectedIndex = -1;
            this.m_cboRepresentor.SelectedIndex = -1;
            this.m_txtCatameniaHistory.m_mthClearText();
            this.m_txtChargeDoc.Text = "";
            m_txtChargeDoc.Enabled = true;
            this.m_txtChargeDoc.Tag = null;
            //			this.m_txtMidwife.Text = "";
            this.m_txtDirectorDoc.Text = "";
            m_txtDirectorDoc.Enabled = true;
            this.m_txtDirectorDoc.Tag = null;

            this.m_txtDiagnoseDoctor.Text = "";
            m_txtDiagnoseDoctor.Enabled = true;
            this.m_txtDiagnoseDoctor.Tag = null;
            this.m_txtaddDiagnose.m_mthClearText();
            this.m_txtaddDiagnose_CHN.m_mthClearText();
            this.m_txtDiagnose.m_mthClearText();
            this.m_txtDiagnose_CHN.m_mthClearText();

            m_mthSetModifyControl(null, true);

            m_dtpCreateDate.Enabled = true;
            m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

            //			m_mthClearAllPic(ctlPaintContainer1);
            ctlPaintContainer1.m_mthClear();
            m_cboFirstCatamenia.Text = "";
            m_cboCatameniaLastTime.Text = "";
            m_cboCatameniaCycle.Text = "";
            m_dtpLastCatameniaTime.Value = DateTime.Now;
            m_cboCatameniaCase.Text = "";
            m_dtpDiagnoseDate.Value = DateTime.Now;     

            if (m_objBaseCurrentPatient != null && m_objBaseCurrentPatient.m_StrSex.Trim() == "男")
            {
                m_mthEnableCatamenia(false);
            }
        }

        protected override void m_mthClearPatientBaseInfo()
        {
            base.m_mthClearPatientBaseInfo();
            m_lblLinkMan.Text = "";
            m_lblOccupation.Text = "";
            m_lblMarriaged.Text = "";
            m_lblCreateUserName.Text = "";
            m_lblNativePlace.Text = "";
            m_lblAddress.Text = "";
            m_lblNation.Text = "";
        }

        protected override void m_mthEnableRichTextBox()
        {
            m_mthEnableRichTextBox(true);
        }

        // 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {

        }

        // 是否允许修改特殊记录的记录信息。
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {
            
        }

        //获取记录创建者
        protected override clsInPatientCaseHistoryContent m_objGetCreateUserFromGUI()
        {
            clsInPatientCaseHistoryContent m_objContent = new clsInPatientCaseHistoryContent();
            try
            {
                m_objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return m_objContent;
        }

        // 从界面获取特殊记录的值。如果界面值出错，返回null。
        protected override clsInPatientCaseHistoryContent m_objGetContentFromGUI()
        {
            clsInPatientCaseHistoryContent m_objContent = new clsInPatientCaseHistoryContent();
            try
            {
                m_objContent.m_strModifyUserID = clsEMRLogin.LoginEmployee.m_strEMPNO_CHR;
                m_objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;

                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref m_objContent.objSignerArr, ref strUserIDList, ref strUserNameList);

                m_objContent.m_strBeforetimeStatusAll = this.m_txtBeforetimeStatus.Text;
                m_objContent.m_strBeforetimeStatusXML = this.m_txtBeforetimeStatus.m_strGetXmlText();
                m_objContent.m_strBeforetimeStatus = this.m_txtBeforetimeStatus.m_strGetRightText();

                m_objContent.m_strCatameniaHistory = this.m_txtCatameniaHistory.m_strGetRightText();
                m_objContent.m_strCatameniaHistoryAll = this.m_txtCatameniaHistory.Text;
                m_objContent.m_strCatameniaHistoryXML = this.m_txtCatameniaHistory.m_strGetXmlText();

                m_objContent.m_strCredibility = this.m_cboCredibility.Text;

                m_objContent.m_strCurrentStatus = this.m_txtCurrentStatus.m_strGetRightText();
                m_objContent.m_strCurrentStatusXAll = this.m_txtCurrentStatus.Text;
                m_objContent.m_strCurrentStatusXML = this.m_txtCurrentStatus.m_strGetXmlText();

                m_objContent.m_strFamilyHistory = this.m_txtFamilyHistory.m_strGetRightText();
                m_objContent.m_strFamilyHistoryAll = this.m_txtFamilyHistory.Text;
                m_objContent.m_strFamilyHistoryXML = this.m_txtFamilyHistory.m_strGetXmlText();

                m_objContent.m_strLabCheck = this.m_txtLabCheck.m_strGetRightText();
                m_objContent.m_strLabCheckAll = this.m_txtLabCheck.Text;
                m_objContent.m_strLabCheckXML = this.m_txtLabCheck.m_strGetXmlText();

                m_objContent.m_strMainDescription = this.m_txtMainDescription.m_strGetRightText();
                m_objContent.m_strMainDescriptionAll = this.m_txtMainDescription.Text;
                m_objContent.m_strMainDescriptionXML = this.m_txtMainDescription.m_strGetXmlText();

                m_objContent.m_strMarriageHistory = this.m_txtMarriageHistory.m_strGetRightText();
                m_objContent.m_strMarriageHistoryAll = this.m_txtMarriageHistory.Text;
                m_objContent.m_strMarriageHistoryXML = this.m_txtMarriageHistory.m_strGetXmlText();

                m_objContent.m_strOwnHistory = this.m_txtOwnHistory.m_strGetRightText();
                m_objContent.m_strOwnHistoryAll = this.m_txtOwnHistory.Text;
                m_objContent.m_strOwnHistoryXML = this.m_txtOwnHistory.m_strGetXmlText();

                m_objContent.m_strRepresentor = this.m_cboRepresentor.Text;

                m_objContent.m_strFinallyDiagnoseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                m_objContent.m_strPrimaryDiagnoseDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                m_objContent.m_strSOLARTERMS = m_cboSolarTerms.Text;
                m_objContent.m_strMEDICARENO = m_txtMedicareNO.Text;
                //补充诊断
                //进行判断，一旦写入补充诊断则要求签名 否则
                if (!string.IsNullOrEmpty(this.m_txtaddDiagnose.Text.Trim()) || !string.IsNullOrEmpty(m_txtaddDiagnose_CHN.Text.Trim()))
                {
                    if (m_txtDiagnoseDoctor.Tag == null)
                    {
                        MessageBox.Show("已书写确定诊断，必须有医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
                m_objContent.m_strAddDiagnose = this.m_txtaddDiagnose.m_strGetRightText();
                m_objContent.m_strAddDiagnoseALL = this.m_txtaddDiagnose.Text;
                m_objContent.m_strAddDiagnoseXML = this.m_txtaddDiagnose.m_strGetXmlText();
                m_objContent.m_strADDDIAGNOSE_CHN = this.m_txtaddDiagnose_CHN.m_strGetRightText();
                m_objContent.m_strADDDIAGNOSE_CHNALL = this.m_txtaddDiagnose_CHN.Text;
                m_objContent.m_strADDDIAGNOSE_CHNXML = this.m_txtaddDiagnose_CHN.m_strGetXmlText();
                if (this.m_txtDiagnoseDoctor.Tag != null)
                    m_objContent.m_strAddDiagnoseDoctorID = ((clsEmrEmployeeBase_VO)this.m_txtDiagnoseDoctor.Tag).m_strEMPNO_CHR;


                if (!string.IsNullOrEmpty(this.m_txtDiagnose_CHN.Text.Trim()) || !string.IsNullOrEmpty(m_txtDiagnose.Text.Trim()))
                {
                    if (m_txtChargeDoc.Tag == null)
                    {
                        MessageBox.Show("已书写初步诊断，必须有主治医师签名", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }

                m_objContent.m_strINIDIAGNOSISALL = m_txtDiagnose.Text;
                m_objContent.m_strINIDIAGNOSISXML = m_txtDiagnose.m_strGetXmlText();
                m_objContent.m_strINIDIAGNOSIS = m_txtDiagnose.m_strGetRightText();
                m_objContent.m_strINIDIAGNOSIS_CHNALL = m_txtDiagnose_CHN.Text;
                m_objContent.m_strINIDIAGNOSIS_CHNXML = m_txtDiagnose_CHN.m_strGetXmlText();
                m_objContent.m_strINIDIAGNOSIS_CHN = m_txtDiagnose_CHN.m_strGetRightText();
                //主治医师
                if (this.m_txtChargeDoc.Tag != null)
                    m_objContent.m_strChargeDoctor = ((clsEmrEmployeeBase_VO)this.m_txtChargeDoc.Tag).m_strEMPNO_CHR;
                //住院医师
                if (this.m_txtDirectorDoc.Tag != null)
                    m_objContent.m_strDiretDoctor = ((clsEmrEmployeeBase_VO)this.m_txtDirectorDoc.Tag).m_strEMPNO_CHR;
                m_objContent.m_dtDiagnoseDate = DateTime.Parse(m_dtpDiagnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                m_objContent.m_strCreateName = MDIParent.OperatorName;

                //补充月经部分
                m_objContent.m_strFirstCatamenia = this.m_cboFirstCatamenia.Text;
                m_objContent.m_strCatameniaLastTime = this.m_cboCatameniaLastTime.Text;
                m_objContent.m_strCatameniaCycle = this.m_cboCatameniaCycle.Text;
                m_objContent.m_dtmLastCatameniaTime = this.m_dtpLastCatameniaTime.Value;
                m_objContent.m_strCatameniaCase = this.m_cboCatameniaCase.Text.Trim();
                m_objContent.m_intSelectedMC = m_chkCatamenia.Checked ? 1 : 0;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return m_objContent;


        }

        //		public clsPictureBoxValue[] m_objPicValueArr = null;
        protected override clsPictureBoxValue[] m_objGetPicContentFromGUI()
        {
            return ctlPaintContainer1.m_objGetPicValue();
        }

        // 把特殊记录的值显示到界面上。
        protected override void m_mthSetGUIFromContent(clsInPatientCaseHistoryContent p_objContent, clsPictureBoxValue[] p_objPicValueArr)
        {
            ctlPaintContainer1.m_mthSetPicValue(p_objPicValueArr);

            if (p_objContent.m_strInPatientID != null && p_objContent.m_strInPatientID != "")
            {
                m_strCurrentOpenDate = p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            }

            this.m_txtBeforetimeStatus.m_mthSetNewText(p_objContent.m_strBeforetimeStatusAll, p_objContent.m_strBeforetimeStatusXML);
            this.m_txtCurrentStatus.m_mthSetNewText(p_objContent.m_strCurrentStatusXAll, p_objContent.m_strCurrentStatusXML);
            this.m_txtFamilyHistory.m_mthSetNewText(p_objContent.m_strFamilyHistoryAll, p_objContent.m_strFamilyHistoryXML);
            this.m_txtLabCheck.m_mthSetNewText(p_objContent.m_strLabCheckAll, p_objContent.m_strLabCheckXML);
            this.m_txtMainDescription.m_mthSetNewText(p_objContent.m_strMainDescriptionAll, p_objContent.m_strMainDescriptionXML);
            this.m_txtMarriageHistory.m_mthSetNewText(p_objContent.m_strMarriageHistoryAll, p_objContent.m_strMarriageHistoryXML);
            this.m_txtOwnHistory.m_mthSetNewText(p_objContent.m_strOwnHistoryAll, p_objContent.m_strOwnHistoryXML);
            this.m_cboCredibility.Text = p_objContent.m_strCredibility;
            this.m_cboRepresentor.Text = p_objContent.m_strRepresentor;

            this.m_txtDiagnose_CHN.m_mthSetNewText(p_objContent.m_strINIDIAGNOSIS_CHNALL, p_objContent.m_strINIDIAGNOSIS_CHNXML);
            this.m_txtDiagnose.m_mthSetNewText(p_objContent.m_strINIDIAGNOSISALL, p_objContent.m_strINIDIAGNOSISXML);
            this.m_txtaddDiagnose_CHN.m_mthSetNewText(p_objContent.m_strADDDIAGNOSE_CHNALL, p_objContent.m_strADDDIAGNOSE_CHNXML);
            this.m_txtaddDiagnose.m_mthSetNewText(p_objContent.m_strAddDiagnoseALL, p_objContent.m_strAddDiagnoseXML);

            //补充月经部分
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {
                this.m_txtCatameniaHistory.m_mthSetNewText(p_objContent.m_strCatameniaHistoryAll, p_objContent.m_strCatameniaHistoryXML);
                this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                if (m_cboCatameniaCase.Text.Equals("已绝经"))
                    this.m_dtpLastCatameniaTime.Enabled = false;
            }
            m_dtpDiagnoseDate.Value = p_objContent.m_dtDiagnoseDate;
            m_cboSolarTerms.Text = p_objContent.m_strSOLARTERMS;
            m_txtMedicareNO.Text = p_objContent.m_strMEDICARENO;
           
            #region 签名赋值
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, m_txtDiagnoseDoctor, m_txtDirectorDoc, m_txtChargeDoc },
                new string[] { p_objContent.m_strCreateUserID, p_objContent.m_strAddDiagnoseDoctorID, p_objContent.m_strDiretDoctor, p_objContent.m_strChargeDoctor },
                new bool[] { false, false, false, false });
           
            #endregion

        }

        // 获取病程记录的领域层实例
        protected override clsBaseCaseHistoryDomain m_objGetDomain()
        {
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.InPatientCaseHistory);
        }

        // 把选择时间记录内容重新整理为完全正确的内容。
        protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
        {

        }

        protected override void m_mthHandleAddRecordSucceed()
        {
            if (trvTime.SelectedNode != null)
                trvTime.SelectedNode.Tag = (string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //审核
        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (string.IsNullOrEmpty(m_strCurrentOpenDate))
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return string.Empty;
                }
                return m_strCurrentOpenDate;
            }
        }

        protected override bool m_BlnCanApprove
        {
            get
            {
                return true;
            }
        }
        //~审核
        protected override void m_mthSetNewRecord()
        {
            if (m_objCurrentPatient != null)
            {
                //默认值 m_IntCurCase
                new clsDefaultValueTool(this, m_objCurrentPatient).m_mthSetDefaultValue();
            }
        }

        protected override void m_mthLoadRecord(string p_strInPatientDate, string p_strOpenDate)
        {
            m_mthSetSelectedRecord(m_objCurrentPatient);
        }

        protected override long m_lngSubAddNewRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
        {
            clsMedicalExamInHospital_TargetValue objMedicalExamInHopital = new clsMedicalExamInHospital_TargetValue();
            objMedicalExamInHopital.m_strInPatientDate = p_objNewContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            objMedicalExamInHopital.m_strInPatientID = p_objNewContent.m_strInPatientID;
            objMedicalExamInHopital.m_strItemID = "1";
            objMedicalExamInHopital.m_strMedicalExam_ID = "";
            objMedicalExamInHopital.m_strModifyDate = p_objNewContent.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
            objMedicalExamInHopital.m_strOpenDate = p_objNewContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            return 1;
        }

        protected override long m_lngSubModifyRecordAfterMain(iCareData.clsInPatientCaseHistoryContent p_objNewContent)
        {
            clsMedicalExamInHospital_TargetValue objMedicalExamInHopital = new clsMedicalExamInHospital_TargetValue();
            objMedicalExamInHopital.m_strInPatientDate = p_objNewContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            objMedicalExamInHopital.m_strInPatientID = p_objNewContent.m_strInPatientID;
            objMedicalExamInHopital.m_strItemID = "1";
            //objMedicalExamInHopital.m_strMedicalExam_ID = m_strMedicalExam_ID.Trim();
            objMedicalExamInHopital.m_strModifyDate = p_objNewContent.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
            objMedicalExamInHopital.m_strOpenDate = p_objNewContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            return 1;
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            clsInPatientCaseHistoryContent p_objContent = new clsInPatientCaseHistoryContent();
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue)
            {
                //m_strMedicalExam_ID = "";
                return;
            }

            long lngRes = m_objGetDomain().m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
            if (lngRes <= 0 || p_objContent == null)
            {
                switch (lngRes)
                {
                    case (long)(iCareData.enmOperationResult.Not_permission):
                        m_mthShowNotPermitted(); break;
                    case (long)(iCareData.enmOperationResult.DB_Fail):
                        m_mthShowDBError(); break;
                }
                return;
            }

            this.m_txtBeforetimeStatus.Text = p_objContent.m_strBeforetimeStatus;
            this.m_txtCurrentStatus.Text = p_objContent.m_strCurrentStatus;
            this.m_txtFamilyHistory.Text = p_objContent.m_strFamilyHistory;
            this.m_txtLabCheck.Text = p_objContent.m_strLabCheck;
            this.m_txtMainDescription.Text = p_objContent.m_strMainDescription;
            this.m_txtMarriageHistory.Text = p_objContent.m_strMarriageHistory;
            this.m_txtOwnHistory.Text = p_objContent.m_strOwnHistory;
            this.m_cboCredibility.Text = p_objContent.m_strCredibility;
            this.m_cboRepresentor.Text = p_objContent.m_strRepresentor;
            m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
            if (m_chkCatamenia.Checked)
            {
                this.m_txtCatameniaHistory.Text = p_objContent.m_strCatameniaHistory;
                this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                    this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                if (m_cboCatameniaCase.Text.Equals("已绝经"))
                    this.m_dtpLastCatameniaTime.Enabled = false;
            }
            if (!string.IsNullOrEmpty(p_objContent.m_strChargeDoctor))
            {
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strChargeDoctor, out objEmpVO);
                this.m_txtChargeDoc.Text = objEmpVO.m_strLASTNAME_VCHR;
                this.m_txtChargeDoc.Tag = objEmpVO;
            }
            if (!string.IsNullOrEmpty(p_objContent.m_strDiretDoctor))
            {
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strDiretDoctor, out objEmpVO);
                this.m_txtDirectorDoc.Text = objEmpVO.m_strLASTNAME_VCHR;
                this.m_txtDirectorDoc.Tag = objEmpVO;
            }
            if (!string.IsNullOrEmpty(p_objContent.m_strDiagnoseDoc))
            {
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(p_objContent.m_strDiagnoseDoc, out objEmpVO);
                this.m_txtDiagnoseDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                this.m_txtDiagnoseDoctor.Tag = objEmpVO;
            }
            m_dtpDiagnoseDate.Value = p_objContent.m_dtDiagnoseDate;
            m_txtDiagnose_CHN.Text = p_objContent.m_strINIDIAGNOSIS_CHN;
            m_txtDiagnose.Text = p_objContent.m_strINIDIAGNOSIS;
            m_txtaddDiagnose_CHN.Text = p_objContent.m_strADDDIAGNOSE_CHN;
            m_txtaddDiagnose.Text = p_objContent.m_strAddDiagnose;
        }

        public override int m_IntFormID
        {
            get
            {
                return 19;
            }
        }

        #endregion override function

        #region 添加键盘快捷键

        private byte m_bytListOnDoctor;
        /// <summary>
        /// 是否处理医生的TextChanged事件
        /// </summary>
        private bool m_blnCanDoctorTextChanged;

        private void m_mthSetQuickKeys()
        {
            m_mthSetControlEvent(this);
        }

        private void m_mthSetControlEvent(Control p_ctlControl)
        {
            #region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName != "Lable" && strTypeName != "Button")
            {
                p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        m_mthSetControlEvent(subcontrol);
                    }
                }
            }
            #endregion
        }

        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
                case 13:// enter				

                    break;

                case 38:
                case 40:

                    break;
                case 113://save
                    this.m_lngSave();
                    break;
                case 114://del
                    this.m_lngDelete();
                    break;
                case 115://print
                    this.m_lngPrint();
                    break;
                case 116://refresh
                    m_mthClearAll();
                    m_mthClearPatientBaseInfo();
                    break;
                case 117://Search					
                    break;
            }
        }  
        #endregion

        private void m_cboCatameniaCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dtpLastCatameniaTime.Enabled = !m_cboCatameniaCase.Text.Trim().Equals("已绝经");
        }

        private void m_chkCatamenia_CheckedChanged(object sender, EventArgs e)
        {
            m_mthEnableCatamenia(m_chkCatamenia.Checked);
        }

        private void frmInPatientCaseHistory_XJ_Load(object sender, EventArgs e)
        {
            m_mthSetQuickKeys();

            m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            m_dtpCreateDate.m_mthResetSize();

            m_cboSolarTerms.Focus();
        }

        /// <summary>
        /// 隐藏月经生育史项目
        /// </summary>
        private void m_mthHideCatameniaItem()
        {
            m_txtCatameniaHistory.m_mthClearText();
            this.m_cboFirstCatamenia.Text = "";
            this.m_cboCatameniaLastTime.Text = "";
            this.m_cboCatameniaCycle.Text = "";
            this.m_cboCatameniaCase.Text = "";
            m_chkCatamenia.Enabled = false;
            m_grbCatamenia.Enabled = false;

            int intVSpace = m_grbCatamenia.Height;
        }

        /// <summary>
        /// 隐藏婚姻史项目
        /// </summary>
        private void m_mthHideMarry()
        {
            m_txtMarriageHistory.m_mthClearText();
            m_txtMarriageHistory.Enabled = false;
            m_lklMarriageHistory.Enabled = false;
            m_txtMarriageHistory.Text = "未婚。";

            int intVSpace = m_txtMarriageHistory.Bottom - m_lklMarriageHistory.Top + 8;
        }

        private void frmInPatientCaseHistory_XJ_FormClosing(object sender, FormClosingEventArgs e)
        {
            MDIParent.m_EnmCaseType = frmInPatientCaseHistory.enmCaseType.默认;
        }

        // <summary>
        /// 根据病人情况隐藏一些项目
        /// </summary>
        private void m_mthHideSomeItem(clsPatient p_objPatient)
        {
            if (p_objPatient == null)
                return;

            if (p_objPatient.m_ObjPeopleInfo.m_StrSex == "男")
                m_mthHideCatameniaItem();
            else
            {
                m_chkCatamenia.Enabled = true;
                m_grbCatamenia.Enabled = true;
            }
            if (p_objPatient.m_ObjPeopleInfo.m_StrMarried == "未婚")
                m_mthHideMarry();
            else
            {
                m_txtMarriageHistory.Enabled = true;
                m_lklMarriageHistory.Enabled = true;
            }
        }

        #region 调用最小元素集模板
        private void m_mth(com.digitalwave.controls.ctlRichTextBox p_ctlSource)
        {
            iCare.CustomForm.clsExteriorFunctionInterface.m_ObjUserInfo = clsEMRLogin.LoginInfo;
            iCare.CustomForm.clsExteriorFunctionInterface.s_ObjCurrentPatient = MDIParent.s_ObjCurrentPatient;
            int intSelectedStart = (p_ctlSource.SelectionStart < 0 ? p_ctlSource.Text.Length : p_ctlSource.SelectionStart);
            using (iCare.CustomForm.frmTextTemplate frm = new iCare.CustomForm.frmTextTemplate(p_ctlSource, this.Name, p_ctlSource.Name, intSelectedStart, m_dtmCreatedDate))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m_arlMinElementColValue.AddRange((clsMinElementValues[])frm.m_ArlTextTemplate.ToArray(typeof(clsMinElementValues)));
                }
            }
        }

        private void m_lklMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnklb = (LinkLabel)sender;
            switch (lnklb.Name.ToString())
            {
                case "m_lklMain":
                    m_mth(m_txtMainDescription);
                    break;
                case "m_lklCurrentStatus":
                    m_mth(m_txtCurrentStatus);
                    break;
                case "m_lklBeforetimeStatus":
                    m_mth(m_txtBeforetimeStatus);
                    break;
                case "m_lklOwnHistory":
                    m_mth(m_txtOwnHistory);
                    break;
                case "m_lklMarriageHistory":
                    m_mth(m_txtMarriageHistory);
                    break;
                case "m_lklFamilyHistory":
                    m_mth(m_txtFamilyHistory);
                    break;
                case "m_lklLabCheck":
                    m_mth(m_txtLabCheck);
                    break;
                case "m_lklDiagnose_CHN":
                    m_mth(m_txtDiagnose_CHN);
                    break;
                case "m_lklDiagnose":
                    m_mth(m_txtDiagnose);
                    break;
                case "m_lkladdDiagnose_CHN":
                    m_mth(m_txtaddDiagnose_CHN);
                    break;
                case "m_lkladdDiagnose":
                    m_mth(m_txtaddDiagnose);
                    break;
            }
        }
        #endregion 调用最小元素集模板

        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            base.m_mthSetPatientFormInfo(p_objSelectedPatient);

            m_mthHideSomeItem(p_objSelectedPatient);
        }

        #region 作废重做
        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsInPatientCaseHistoryContent p_objContent = new clsInPatientCaseHistoryContent();

                long lngRes = m_objGetDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                if (lngRes <= 0 || p_objContent == null)
                {
                    switch (lngRes)
                    {
                        case (long)(iCareData.enmOperationResult.Not_permission):
                            m_mthShowNotPermitted(); break;
                        case (long)(iCareData.enmOperationResult.DB_Fail):
                            m_mthShowDBError(); break;
                    }
                    return blnIsOK;
                }

                this.m_txtBeforetimeStatus.Text = p_objContent.m_strBeforetimeStatus;
                this.m_txtCurrentStatus.Text = p_objContent.m_strCurrentStatus;
                this.m_txtFamilyHistory.Text = p_objContent.m_strFamilyHistory;
                this.m_txtLabCheck.Text = p_objContent.m_strLabCheck;
                this.m_txtMainDescription.Text = p_objContent.m_strMainDescription;
                this.m_txtMarriageHistory.Text = p_objContent.m_strMarriageHistory;
                this.m_txtOwnHistory.Text = p_objContent.m_strOwnHistory;
                this.m_cboCredibility.Text = p_objContent.m_strCredibility;
                this.m_cboRepresentor.Text = p_objContent.m_strRepresentor;
                m_chkCatamenia.Checked = p_objContent.m_intSelectedMC == 1 ? true : false;
                if (m_chkCatamenia.Checked)
                {
                    this.m_txtCatameniaHistory.Text = p_objContent.m_strCatameniaHistory;
                    this.m_cboFirstCatamenia.Text = p_objContent.m_strFirstCatamenia;
                    this.m_cboCatameniaLastTime.Text = p_objContent.m_strCatameniaLastTime;
                    this.m_cboCatameniaCycle.Text = p_objContent.m_strCatameniaCycle;
                    if (!p_objContent.m_dtmLastCatameniaTime.Equals(DateTime.MinValue))
                        this.m_dtpLastCatameniaTime.Value = p_objContent.m_dtmLastCatameniaTime;
                    this.m_cboCatameniaCase.Text = p_objContent.m_strCatameniaCase;
                    if (m_cboCatameniaCase.Text.Equals("已绝经"))
                        this.m_dtpLastCatameniaTime.Enabled = false;
                }
                m_txtDiagnose_CHN.Text = p_objContent.m_strINIDIAGNOSIS_CHN;
                m_txtDiagnose.Text = p_objContent.m_strINIDIAGNOSIS;
                m_txtaddDiagnose_CHN.Text = p_objContent.m_strADDDIAGNOSE_CHN;
                m_txtaddDiagnose.Text = p_objContent.m_strAddDiagnose;
                m_cboSolarTerms.Text = p_objContent.m_strSOLARTERMS;
                m_txtMedicareNO.Text = p_objContent.m_strMEDICARENO;
                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsInPatientCaseHistory_XJPrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_InPatientCaseHistory objPrintInfo = new clsPrintInfo_InPatientCaseHistory();
                objPrintInfo.m_strInPatentID = m_objBaseCurrentPatient.m_StrInPatientID;
                objPrintInfo.m_strPatientName = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
                objPrintInfo.m_strSex = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrSex;
                objPrintInfo.m_strAge = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objPrintInfo.m_strBedName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
                objPrintInfo.m_strDeptName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName;
                objPrintInfo.m_strAreaName = m_objBaseCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objSelectedValue.m_DtmInpatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName;
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;

                objPrintInfo.m_strHomeplace = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrHomeplace;//出生地
                objPrintInfo.m_strNativePlace = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrNativePlace;//籍贯
                objPrintInfo.m_strOccupation = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;//职业
                objPrintInfo.m_strMarried = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrMarried;//婚否
                objPrintInfo.m_StrLinkManFirstName = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;//联系人
                objPrintInfo.m_strNationality = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrNation;//民族
                objPrintInfo.m_strHomePhone = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrLinkManPhone;//电话
                objPrintInfo.m_strHomeAddress = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;//地址

                objPrintInfo.m_strHISInPatientID = m_objBaseCurrentPatient.m_StrHISInPatientID;
                objPrintInfo.m_dtmHISInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedHISInDate;
                clsInPatientCaseHistoryContent objContent = null;
                long lngRes = m_objGetDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_blnIsFirstPrint = false;
                objPrintTool.m_mthSetPrintContent(objPrintInfo);

                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;
            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做
    }
}