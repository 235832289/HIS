using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    public partial class frmFetalCustodialRecord : frmDiseaseTrackBase
    {

        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        public frmFetalCustodialRecord()
        {
            InitializeComponent();
        }

        private void frmFetalCustodialRecord_Load(object sender, EventArgs e)
        {
            //指明医生工作站表单
            intFormType = 1;

            m_mthSetRichTextBoxAttribInControl(this);

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign1, m_txtSign1, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdSign2, m_txtSign2, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //先隐藏掉无痕迹修改字样.过渡使用
            chkModifyWithoutMatk.Left = m_trvCreateDate.Left;
            chkModifyWithoutMatk.Top = m_trvCreateDate.Top;

            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            m_mthfrmLoad();

            m_trvCreateDate.Focus();
        }

        private void m_cmdSign1_Click(object sender, EventArgs e)
        {            
        }

        /// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsFetalCustodialRecordContent objContent = (clsFetalCustodialRecordContent)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            //m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            m_txtClinicalDiagnose.m_mthSetNewText(objContent.m_strClinicalDiagnose, objContent.m_strClinicalDiagnoseXml);
            m_txtCustodialIndication.m_mthSetNewText(objContent.m_strCustodialIndication, objContent.m_strCustodialIndicationXml);
            m_txtUltraSonicscanCue.m_mthSetNewText(objContent.m_strUltraSonicscanCue, objContent.m_strUltraSonicscanCueXml);
            m_txtUltraSonicscanerType.m_mthSetNewText(objContent.m_strUltraSonicscanerType, objContent.m_strUltraSonicscanerTypeXml);
            m_txtFetalHeartRate.Text = objContent.m_strFetalHeartRate;
            m_txtAmplitudeVariation.Text = objContent.m_strAmplitudeVariation;
            m_txtPeriodicVariation.Text = objContent.m_strPeriodicVariation;
            m_txtAcceleration.Text = objContent.m_strAccerleration;
            m_txtDeceleration.Text = objContent.m_strDecerleration;
            m_txtTotalRate.Text = objContent.m_strTotalRate;
            m_txtManagementSuggestion.m_mthSetNewText(objContent.m_strManagementSuggestion, objContent.m_strManagementSuggestionXml);
            m_txtOCT.m_mthSetNewText(objContent.m_strOCT, objContent.m_strOCTXml);
            m_txtCSF.m_mthSetNewText(objContent.m_strCSF, objContent.m_strCSFXml);
            m_txtCustodialRecord.m_mthSetNewText(objContent.m_strCustodialRecord, objContent.m_strCustodialRecordXml);
            m_txtHour.m_mthSetNewText(objContent.m_strAfterParturientHour, objContent.m_strAfterParturientHourXml);
            m_txtMinute.m_mthSetNewText(objContent.m_strAfterParturientMinute, objContent.m_strAfterParturientMinuteXml);
            m_txtOstiumUteri.m_mthSetNewText(objContent.m_strOstiumUteri, objContent.m_strOstiumUteriXml);
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strSignID1, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign1.Tag = objEmpVO;
                m_txtSign1.Text = objEmpVO.m_strGetTechnicalRankAndName;
                if (objContent.m_dtmSignTime1.ToString() != "0001-1-1 0:00:00")
                {
                    m_dtpSignTime1.Value = objContent.m_dtmSignTime1;
                }
            }            
            m_txtNatalType.m_mthSetNewText(objContent.m_strNatalType, objContent.m_strNatalTypeXml);
            m_txtBirthHour.m_mthSetNewText(objContent.m_strBirthProcessHour, objContent.m_strBirthProcessHourXml);
            m_txtBirthMinute.m_mthSetNewText(objContent.m_strBirthProcessMinute, objContent.m_strBirthProcessMinuteXml);
            m_txtEvaluation.m_mthSetNewText(objContent.m_strEvaluation, objContent.m_strEvaluationXml);
            m_txtFetalWeight.m_mthSetNewText(objContent.m_strFetalWeight, objContent.m_strFetalWeightXml);
            m_txtFetalLength.m_mthSetNewText(objContent.m_strFetalLength, objContent.m_strFetalLengthXml);
            m_txtAmnioticFluid.m_mthSetNewText(objContent.m_strAmnioticFluid, objContent.m_strAmnioticFluidXml);
            m_txtColor.m_mthSetNewText(objContent.m_strColor, objContent.m_strColorXml);
            m_txtPlacenta.m_mthSetNewText(objContent.m_strPlacenta, objContent.m_strPlacentaXml);
            m_txtUmbilicalcord.m_mthSetNewText(objContent.m_strUmbilicalcord, objContent.m_strUmbilicalcordXml);
            m_txtRemark.m_mthSetNewText(objContent.m_strRemark, objContent.m_strRemarkXml);
            objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strSignID2, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign2.Tag = objEmpVO;
                m_txtSign2.Text = objEmpVO.m_strGetTechnicalRankAndName;
                if (objContent.m_dtmSignTime2.ToString() != "0001-1-1 0:00:00")
                {
                    m_dtpSignTime2.Value = objContent.m_dtmSignTime2;
                }
            }            

        }

        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsFetalCustodialRecordContent objContent = (clsFetalCustodialRecordContent)p_objContent;
            m_txtClinicalDiagnose.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strClinicalDiagnose, objContent.m_strClinicalDiagnoseXml);
            m_txtCustodialIndication.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strCustodialIndication, objContent.m_strCustodialIndicationXml);
            m_txtUltraSonicscanCue.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strUltraSonicscanCue, objContent.m_strUltraSonicscanCueXml);
            m_txtManagementSuggestion.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strManagementSuggestion, objContent.m_strManagementSuggestionXml);
            m_txtCustodialRecord.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strCustodialRecord, objContent.m_strCustodialRecordXml);
            m_txtUltraSonicscanerType.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strUltraSonicscanerType, objContent.m_strUltraSonicscanerTypeXml);
            m_txtOCT.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strOCT, objContent.m_strOCTXml);
            m_txtCSF.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strCSF, objContent.m_strCSFXml);
            m_txtHour.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strAfterParturientHour, objContent.m_strAfterParturientHourXml);
            m_txtMinute.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strAfterParturientMinute, objContent.m_strAfterParturientMinuteXml);
            m_txtOstiumUteri.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strOstiumUteri, objContent.m_strOstiumUteriXml);
            m_txtNatalType.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strNatalType, objContent.m_strNatalTypeXml);
            m_txtBirthHour.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strBirthProcessHour, objContent.m_strBirthProcessHourXml);
            m_txtBirthMinute.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strBirthProcessMinute, objContent.m_strBirthProcessMinuteXml);
            m_txtEvaluation.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strEvaluation, objContent.m_strEvaluationXml);
            m_txtFetalWeight.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strFetalWeight, objContent.m_strFetalWeightXml);
            m_txtFetalLength.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strFetalLength, objContent.m_strFetalLengthXml);
            m_txtAmnioticFluid.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strAmnioticFluid, objContent.m_strAmnioticFluidXml);
            m_txtColor.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strColor, objContent.m_strColorXml);
            m_txtPlacenta.Text =  ctlRichTextBox.s_strGetRightText(objContent.m_strPlacenta, objContent.m_strPlacentaXml);
            m_txtUmbilicalcord.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strUmbilicalcord, objContent.m_strUmbilicalcordXml);
            m_txtRemark.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strRemark, objContent.m_strRemarkXml);
        }

        /// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;
            clsFetalCustodialRecordContent objContent = new clsFetalCustodialRecordContent();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            objContent.m_strClinicalDiagnose = m_txtClinicalDiagnose.Text;
            objContent.m_strClinicalDiagnoseXml = m_txtClinicalDiagnose.m_strGetXmlText();
            objContent.m_strClinicalDiagnoseRight = m_txtClinicalDiagnose.m_strGetRightText();

            objContent.m_strCustodialIndication = m_txtCustodialIndication.Text;
            objContent.m_strCustodialIndicationXml = m_txtCustodialIndication.m_strGetXmlText();
            objContent.m_strCustodialIndicationRight = m_txtCustodialIndication.m_strGetRightText();

            objContent.m_strUltraSonicscanCue = m_txtUltraSonicscanCue.Text;
            objContent.m_strUltraSonicscanCueXml = m_txtUltraSonicscanCue.m_strGetXmlText();
            objContent.m_strUltraSonicscanCueRight = m_txtUltraSonicscanCue.m_strGetRightText();

            objContent.m_strUltraSonicscanerType = m_txtUltraSonicscanerType.Text;
            objContent.m_strUltraSonicscanerTypeXml = m_txtUltraSonicscanerType.m_strGetXmlText();
            objContent.m_strUltraSonicscanerTypeRight = m_txtUltraSonicscanerType.m_strGetRightText();

            objContent.m_strFetalHeartRate = m_txtFetalHeartRate.Text;
            objContent.m_strAmplitudeVariation = m_txtAmplitudeVariation.Text;
            objContent.m_strPeriodicVariation = m_txtPeriodicVariation.Text;
            objContent.m_strAccerleration = m_txtAcceleration.Text;
            objContent.m_strDecerleration = m_txtDeceleration.Text;
            objContent.m_strTotalRate = m_txtTotalRate.Text;

            objContent.m_strManagementSuggestion = m_txtManagementSuggestion.Text;
            objContent.m_strManagementSuggestionXml = m_txtManagementSuggestion.m_strGetXmlText();
            objContent.m_strManagementSuggestionRight = m_txtManagementSuggestion.m_strGetRightText();

            objContent.m_strOCT = m_txtOCT.Text;
            objContent.m_strOCTXml = m_txtOCT.m_strGetXmlText();
            objContent.m_strOCTRight = m_txtOCT.m_strGetRightText();
            objContent.m_strCSF = m_txtCSF.Text;
            objContent.m_strCSFXml = m_txtCSF.m_strGetXmlText();
            objContent.m_strCSFRight = m_txtCSF.m_strGetRightText();

            objContent.m_strCustodialRecord = m_txtCustodialRecord.Text;
            objContent.m_strCustodialRecordXml = m_txtCustodialRecord.m_strGetXmlText();
            objContent.m_strCustodialRecordRight = m_txtCustodialRecord.m_strGetRightText();

            objContent.m_strAfterParturientHour = m_txtHour.Text;
            objContent.m_strAfterParturientHourXml = m_txtHour.m_strGetXmlText();
            objContent.m_strAfterParturientHourRight = m_txtHour.m_strGetRightText();

            objContent.m_strAfterParturientMinute = m_txtMinute.Text;
            objContent.m_strAfterParturientMinuteXml = m_txtMinute.m_strGetXmlText();
            objContent.m_strAfterParturientMinuteRight = m_txtMinute.m_strGetRightText();

            objContent.m_strOstiumUteri = m_txtOstiumUteri.Text;
            objContent.m_strOstiumUteriXml = m_txtOstiumUteri.m_strGetXmlText();
            objContent.m_strOstiumUteriRight = m_txtOstiumUteri.m_strGetRightText();
            if (m_txtSign1.Tag != null)
            {
                objContent.m_strSignID1 = ((clsEmrEmployeeBase_VO)m_txtSign1.Tag).m_strEMPNO_CHR.Trim();
                objContent.m_strSignName1 = ((clsEmrEmployeeBase_VO)m_txtSign1.Tag).m_strLASTNAME_VCHR;
                objContent.m_dtmSignTime1 = m_dtpSignTime1.Value;
            }

            objContent.m_strNatalType = m_txtNatalType.Text;
            objContent.m_strNatalTypeXml = m_txtNatalType.m_strGetXmlText();
            objContent.m_strNatalTypeRight = m_txtNatalType.m_strGetRightText();
            objContent.m_strBirthProcessHour = m_txtBirthHour.Text;
            objContent.m_strBirthProcessHourXml = m_txtBirthHour.m_strGetXmlText();
            objContent.m_strBirthProcessHourRight = m_txtBirthHour.m_strGetRightText();
            objContent.m_strBirthProcessMinute = m_txtBirthMinute.Text;
            objContent.m_strBirthProcessMinuteXml = m_txtBirthMinute.m_strGetXmlText();
            objContent.m_strBirthProcessMinuteRight = m_txtBirthMinute.m_strGetRightText();

            objContent.m_strEvaluation = m_txtEvaluation.Text;
            objContent.m_strEvaluationXml = m_txtEvaluation.m_strGetXmlText();
            objContent.m_strEvaluationRight = m_txtEvaluation.m_strGetRightText();
            objContent.m_strFetalWeight = m_txtFetalWeight.Text;
            objContent.m_strFetalWeightXml = m_txtFetalWeight.m_strGetXmlText();
            objContent.m_strFetalWeightRight = m_txtFetalWeight.m_strGetRightText();
            objContent.m_strFetalLength = m_txtFetalLength.Text;
            objContent.m_strFetalLengthXml = m_txtFetalLength.m_strGetXmlText();
            objContent.m_strFetalLengthRight = m_txtFetalLength.m_strGetRightText();
            objContent.m_strAmnioticFluid = m_txtAmnioticFluid.Text;
            objContent.m_strAmnioticFluidXml = m_txtAmnioticFluid.m_strGetXmlText();
            objContent.m_strAmnioticFluidRight = m_txtAmnioticFluid.m_strGetRightText();
            objContent.m_strColor = m_txtColor.Text;
            objContent.m_strColorXml = m_txtColor.m_strGetXmlText();
            objContent.m_strColorRight = m_txtColor.m_strGetRightText();
            objContent.m_strPlacenta = m_txtPlacenta.Text;
            objContent.m_strPlacentaXml = m_txtPlacenta.m_strGetXmlText();
            objContent.m_strPlacentaRight = m_txtPlacenta.m_strGetRightText();
            objContent.m_strUmbilicalcord = m_txtUmbilicalcord.Text;
            objContent.m_strUmbilicalcordXml = m_txtUmbilicalcord.m_strGetXmlText();
            objContent.m_strUmbilicalcordRight = m_txtUmbilicalcord.m_strGetRightText();
            
            objContent.m_strRemark = m_txtRemark.Text;
            objContent.m_strRemarkXml = m_txtRemark.m_strGetXmlText();
            objContent.m_strRemarkRight = m_txtRemark.m_strGetRightText();

            if(m_txtSign2.Tag != null)
            {
                objContent.m_strSignID2 = ((clsEmrEmployeeBase_VO)m_txtSign2.Tag).m_strEMPNO_CHR.Trim();
                objContent.m_strSignName2 = ((clsEmrEmployeeBase_VO)m_txtSign2.Tag).m_strLASTNAME_VCHR;
                objContent.m_dtmSignTime2 = m_dtpSignTime2.Value;
            }
            
            return objContent;
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.FetalCustodialRecord);
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue || p_dtmRecordDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误！");
                return;
            }

            clsTrackRecordContent objContent = null;
            long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
            if (lngRes > 0 && objContent != null)
            {
                m_mthSetDeletedGUIFromContent(objContent);
            }

        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容	
            m_txtAcceleration.Text = "";
            m_txtAmnioticFluid.Text = "";
            m_txtAmplitudeVariation.Text = "";
            m_txtBirthHour.Text = "0";
            m_txtBirthMinute.Text = "0";
            m_txtClinicalDiagnose.m_mthClearText();
            m_txtColor.Text = "";
            m_txtCSF.Text = "";
            m_txtCustodialIndication.m_mthClearText();
            m_txtCustodialRecord.m_mthClearText();
            m_txtDeceleration.Text = "";
            m_txtEvaluation.Text = "";
            m_txtFetalHeartRate.Text = "";
            m_txtFetalLength.Text = "";
            m_txtFetalWeight.Text = "";
            m_txtHour.Text = "0";
            m_txtManagementSuggestion.m_mthClearText();
            m_txtMinute.Text = "0";
            m_txtNatalType.Text = "";
            m_txtOCT.Text = "";
            m_txtOstiumUteri.Text = "";
            m_txtPeriodicVariation.Text = "";
            m_txtPlacenta.Text = "";
            m_txtRemark.Text = "";
            m_txtSign1.Text = "";
            m_txtSign1.Tag = null;
            m_txtSign2.Text = "";
            m_txtSign2.Tag = null;
            m_txtTotalRate.Text = "";
            m_txtUltraSonicscanCue.m_mthClearText();
            m_txtUmbilicalcord.Text = "";
        }


        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }

        private bool m_blnHasInitPrintTool = false;
        clsFetalCustodialRecordPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new clsFetalCustodialRecordPrintTool();
                objPrintTool.m_mthInitPrintTool(null);
                m_blnHasInitPrintTool = true;
            }
            clsFetalCustodialRecordContent objContent = (clsFetalCustodialRecordContent)this.m_objGetContentFromGUI();
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,objContent, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, objContent, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, objContent, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, m_objCurrentRecordContent.m_dtmOpenDate);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        }

        private void m_mthStartPrint_this()
        {
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion 外部打印.

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


    }
}