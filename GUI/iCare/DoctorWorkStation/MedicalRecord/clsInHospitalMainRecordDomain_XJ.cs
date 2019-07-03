using System;
using System.Xml;
using System.IO;
using System.Text;
//using com.digitalwave.InHospitalMainRecord_XJ;
using com.digitalwave.InHospitalMainRecord_XJ;
using iCareData;
using System.Data;
using com.digitalwave.PatientManagerService;
namespace iCare
{
    /// <summary>
    /// 蛂埏瓷偶忑珜---陔蔭 
    /// </summary>
    public class clsInHospitalMainRecordDomain_XJ
    {
        /// <summary>
        /// 汜傖Xml腔遣喳
        /// </summary>
        private MemoryStream m_objXmlMemStream;

        /// <summary>
        /// 汜傖Xml腔馱撿
        /// </summary>
        private XmlTextWriter m_objXmlWriter;
        ///  <summary>
        /// 黍�—ml馱撿怀�貒恀�		
        /// </summary>
        private XmlParserContext m_objXmlParser;
        //private com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ;
        public clsInHospitalMainRecordDomain_XJ()
        {
            //
            // TODO: Add constructor logic here
            //
            //m_objServ=new com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ();
            m_objXmlMemStream = new MemoryStream(300);

            m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream, System.Text.Encoding.Unicode);
            m_objXmlWriter.Flush();//ь諾埻懂腔趼睫
            m_objXmlParser = new XmlParserContext(null, null, null, XmlSpace.None, System.Text.Encoding.Unicode);
        }

        /// <summary>
        /// //脤戙菴珨棒湖荂奀潔
        /// </summary>		
        public long m_strGetFirstPrintDate(string p_strInPatientID, string p_strInPatientDate,/*string p_strOpenDate,*/out string p_strFirstPrintDate)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate,/*p_strOpenDate,*/out p_strFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 載陔絞ヶ瓷�佽探拵√熊騫袨帤藣﹋掉銫來孖痟佽扔黨遘鶲郺瘓梪睍齥倷遘譅penDateㄛ嘟祥蚚OpenDate統杅ㄛ撈躺載陔珨沭暮翹ㄘ
        /// </summary>		
        public long m_lngUpdateFirstPrintDate(string p_strInPatientID, string p_strInPatientDate/*,string p_strOpenDate*/)
        {//載陔菴珨棒湖荂奀潔		
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate/*,p_strOpenDate*/);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        public long m_lngDoSave(clsInHospitalMainRecord_Collection p_objCollection, bool p_blnIsAddNew)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                if (p_blnIsAddNew)
                {
                    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objCollection);
                }
                else
                {
                    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objCollection);
                }
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
            }
            return lngRes;
        }

        public long m_lngDoSave(clsInHospitalMainRecord_Main p_objMain, clsInHospitalMainRecord_Content p_objContent, clsInHospitalMainRecord_OtherDiagnosis[] p_objOtherDiagnosisArr, clsInHospitalMainRecord_Operation[] p_objOperationArr, clsInHospitalMainRecord_Baby[] p_objBabyArr, clsInHospitalMainRecord_Chemotherapy[] p_objChemotherapyArr, bool p_bolIfAddNew)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                string m_strMainXML = m_strGetMainXML(p_objMain);
                string m_strContentXML = m_strGetContentXML(p_objContent);
                string[] m_strOtherDiagnosisXMLArr = m_strGetOtherDiagnosisXMLArr(p_objOtherDiagnosisArr);
                string[] m_strOperationXMLArr = m_strGetOperationXMLArr(p_objOperationArr);
                string[] m_strBabyXMLArr = m_strGetBabyXMLArr(p_objBabyArr);
                string[] m_strChemotherapyXMLArr = m_strGetChemotherapyXMLArr(p_objChemotherapyArr);

                if (p_bolIfAddNew)//陔崝
                    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strMainXML, m_strContentXML, m_strOtherDiagnosisXMLArr, m_strOperationXMLArr, m_strBabyXMLArr, m_strChemotherapyXMLArr);
                else//党蜊
                    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objMain.m_strInPatientID, p_objMain.m_strInPatientDate, p_objMain.m_strOpenDate, p_objContent.m_strLastModifyUserID,
                        m_strMainXML, m_strContentXML, m_strOtherDiagnosisXMLArr, m_strOperationXMLArr, m_strBabyXMLArr, m_strChemotherapyXMLArr);
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;

        }

        #region 翋桶XML
        /// <summary>
        /// 翋桶XML
        /// </summary>
        /// <param name="p_objMain"></param>
        /// <returns></returns>
        private string m_strGetMainXML(clsInHospitalMainRecord_Main p_objMain)
        {

            if (p_objMain == null)
                return null;
            m_objXmlMemStream.SetLength(0);
            m_objXmlWriter.WriteStartDocument();
            m_objXmlWriter.WriteStartElement("Main");
            m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objMain.m_strInPatientID);
            m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objMain.m_strInPatientDate);
            m_objXmlWriter.WriteAttributeString("OPENDATE", p_objMain.m_strOpenDate);
            m_objXmlWriter.WriteAttributeString("CREATEUSERID", p_objMain.m_strCreateUserID);
            m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objMain.m_strDeActivedDate);
            m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objMain.m_strDeActivedOperatorID);
            m_objXmlWriter.WriteAttributeString("STATUS", p_objMain.m_strStatus);
            m_objXmlWriter.WriteAttributeString("DIAGNOSISXML", p_objMain.m_strDiagnosisXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INHOSPITALDIAGNOSISXML", p_objMain.m_strInHospitalDiagnosisXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MAINDIAGNOSISXML", p_objMain.m_strMainDiagnosisXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICD_10OFMAINXML", p_objMain.m_strICD_10OfMainXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INFECTIONDIAGNOSISXML", p_objMain.m_strInfectionDiagnosisXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICD_10OFINFECTIONXML", p_objMain.m_strICD_10OfInfectionXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PATHOLOGYDIAGNOSISXML", p_objMain.m_strPathologyDiagnosisXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SCACHESOURCEXML", p_objMain.m_strScacheSourceXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SENSITIVEXML", p_objMain.m_strSensitiveXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HBSAGXML", p_objMain.m_strHbsAgXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HCV_ABXML", p_objMain.m_strHCV_AbXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HIV_ABXML", p_objMain.m_strHIV_AbXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDWITHOUTHOSPITALXML", p_objMain.m_strAccordWithOutHospitalXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDINWITHOUTXML", p_objMain.m_strAccordInWithOutXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDBFOPRWITHAFXML", p_objMain.m_strAccordBeforeOperationWithAfterXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDCLINICWITHPATHOLOGYXML", p_objMain.m_strAccordClinicWithPathologyXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDRADIATEWITHPATHOLOGYXML", p_objMain.m_strAccordRadiateWithPathologyXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SALVETIMESXML", p_objMain.m_strSalveTimesXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SALVESUCCESSXML", p_objMain.m_strSalveSuccessXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEGYXML", p_objMain.m_strOriginalDiseaseGyXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASETIMESXML", p_objMain.m_strOriginalDiseaseTimesXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEDAYSXML", p_objMain.m_strOriginalDiseaseDaysXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHGYXML", p_objMain.m_strLymphGyXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHTIMESXML", p_objMain.m_strLymphTimesXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHDAYSXML", p_objMain.m_strLymphDaysXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISGYXML", p_objMain.m_strMetastasisGyXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISTIMESXML", p_objMain.m_strMetastasisTimesXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISDAYSXML", p_objMain.m_strMetastasisDaysXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TOTALAMTXML", p_objMain.m_strTotalAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BEDAMTXML", p_objMain.m_strBedAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSEAMTXML", p_objMain.m_strNurseAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("WMAMTXML", p_objMain.m_strWMAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CMFINISHEDAMTXML", p_objMain.m_strCMFinishedAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CMSEMIFINISHEDAMTXML", p_objMain.m_strCMSemiFinishedAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RADIATIONAMTXML", p_objMain.m_strRadiationAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ASSAYAMTXML", p_objMain.m_strAssayAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("O2AMTXML", p_objMain.m_strO2AmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODAMTXML", p_objMain.m_strBloodAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TREATMENTAMTXML", p_objMain.m_strTreatmentAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OPERATIONAMTXML", p_objMain.m_strOperationAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DELIVERYCHILDAMTXML", p_objMain.m_strDeliveryChildAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHECKAMTXML", p_objMain.m_strCheckAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ANAETHESIAAMTXML", p_objMain.m_strAnaethesiaAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BABYAMTXML", p_objMain.m_strBabyAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCOMPANYAMTXML", p_objMain.m_strAccompanyAmtXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT1XML", p_objMain.m_strOtherAmt1XML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT2XML", p_objMain.m_strOtherAmt2XML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT3XML", p_objMain.m_strOtherAmt3XML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_WEEKXML", p_objMain.m_strFollow_WeekXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_MONTHXML", p_objMain.m_strFollow_MonthXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_YEARXML", p_objMain.m_strFollow_YearXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODTYPEXML", p_objMain.m_strBloodTypeXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RBCXML", p_objMain.m_strRBCXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PLTXML", p_objMain.m_strPLTXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PLASMXML", p_objMain.m_strPlasmXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("WHOLEBLOODXML", p_objMain.m_strWholeBloodXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERBLOODXML", p_objMain.m_strOtherBloodXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CONSULTATIONXML", p_objMain.m_strConsultationXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LONGDISTANCTCONSULTATIONXML", p_objMain.m_strLongDistanctConsultationXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TOPLEVELXML", p_objMain.m_strTOPLevelXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELIXML", p_objMain.m_strNurseLevelIXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELIIXML", p_objMain.m_strNurseLevelIIXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELIIIXML", p_objMain.m_strNurseLevelIIIXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICUXML", p_objMain.m_strICUXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SPECIALNURSEXML", p_objMain.m_strSpecialNurseXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DIAGNOSISZHONGXML", p_objMain.m_strDiagnosiszhongXML.Replace('\'', '五'));

            m_objXmlWriter.WriteAttributeString("INSURANCENUMXML", p_objMain.m_strInsuranceNumXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MODEOFPAYMENTXML", p_objMain.m_strModeOfPaymentXML.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PATIENTHISTORYNOXML", p_objMain.m_strPatientHistoryNOXML.Replace('\'', '五'));

            m_objXmlWriter.WriteEndElement();
            m_objXmlWriter.WriteEndDocument();
            m_objXmlWriter.Flush();
            return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
        }
        #endregion

        #region 翋赽桶XML
        /// <summary>
        /// 翋赽桶XML
        /// </summary>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        private string m_strGetContentXML(clsInHospitalMainRecord_Content p_objContent)
        {
            if (p_objContent == null)
                return null;
            m_objXmlMemStream.SetLength(0);
            m_objXmlWriter.WriteStartDocument();
            m_objXmlWriter.WriteStartElement("Content");
            m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objContent.m_strInPatientID.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objContent.m_strInPatientDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OPENDATE", p_objContent.m_strOpenDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objContent.m_strLastModifyDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objContent.m_strLastModifyUserID.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objContent.m_strDeActivedDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objContent.m_strDeActivedOperatorID.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("STATUS", p_objContent.m_strStatus.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DIAGNOSIS", p_objContent.m_strDiagnosis.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INHOSPITALDIAGNOSIS", p_objContent.m_strInHospitalDiagnosis.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DOCTOR", p_objContent.m_strDoctor.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CONFIRMDIAGNOSISDATE", p_objContent.m_strConfirmDiagnosisDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CONDICTIONWHENIN", p_objContent.m_strCondictionWhenIn.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MAINDIAGNOSIS", p_objContent.m_strMainDiagnosis.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MAINCONDITIONSEQ", p_objContent.m_strMainConditionSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICD_10OFMAIN", p_objContent.m_strICD_10OfMain.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INFECTIONDIAGNOSIS", p_objContent.m_strInfectionDiagnosis.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INFECTIONCONDICTIONSEQ", p_objContent.m_strInfectionCondictionSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICD_10OFINFECTION", p_objContent.m_strICD_10OfInfection.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PATHOLOGYDIAGNOSIS", p_objContent.m_strPathologyDiagnosis.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SCACHESOURCE", p_objContent.m_strScacheSource.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SENSITIVE", p_objContent.m_strSensitive.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HBSAG", p_objContent.m_strHbsAg.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HCV_AB", p_objContent.m_strHCV_Ab.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("HIV_AB", p_objContent.m_strHIV_Ab.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDWITHOUTHOSPITAL", p_objContent.m_strAccordWithOutHospital.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDINWITHOUT", p_objContent.m_strAccordInWithOut.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDBEFOREOPERATIONWITHAFTER", p_objContent.m_strAccordBeforeOperationWithAfter.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDCLINICWITHPATHOLOGY", p_objContent.m_strAccordClinicWithPathology.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCORDRADIATEWITHPATHOLOGY", p_objContent.m_strAccordRadiateWithPathology.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SALVETIMES", p_objContent.m_strSalveTimes.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SALVESUCCESS", p_objContent.m_strSalveSuccess.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DIRECTORDT", p_objContent.m_strDirectorDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SUBDIRECTORDT", p_objContent.m_strSubDirectorDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DT", p_objContent.m_strDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INHOSPITALDT", p_objContent.m_strInHospitalDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ATTENDINFORADVANCESSTUDYDT", p_objContent.m_strAttendInForAdvancesStudyDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("GRADUATESTUDENTINTERN", p_objContent.m_strGraduateStudentIntern.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("INTERN", p_objContent.m_strIntern.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CODER", p_objContent.m_strCoder.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("QUALITY", p_objContent.m_strQuality.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("QCDT", p_objContent.m_strQCDt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("QCNURSE", p_objContent.m_strQCNurse.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("QCTIME", p_objContent.m_strQCTime.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTMODESEQ", p_objContent.m_strRTModeSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTRULESEQ", p_objContent.m_strRTRuleSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTCO", p_objContent.m_strRTCo.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTACCELERATOR", p_objContent.m_strRTAccelerator.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTX_RAY", p_objContent.m_strRTX_Ray.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RTLACUNA", p_objContent.m_strRTLacuna.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASESEQ", p_objContent.m_strOriginalDiseaseSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEGY", p_objContent.m_strOriginalDiseaseGy.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASETIMES", p_objContent.m_strOriginalDiseaseTimes.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEDAYS", p_objContent.m_strOriginalDiseaseDays.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEBEGINDATE", p_objContent.m_strOriginalDiseaseBeginDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ORIGINALDISEASEENDDATE", p_objContent.m_strOriginalDiseaseEndDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHSEQ", p_objContent.m_strLymphSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHGY", p_objContent.m_strLymphGy.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHTIMES", p_objContent.m_strLymphTimes.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHDAYS", p_objContent.m_strLymphDays.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHBEGINDATE", p_objContent.m_strLymphBeginDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LYMPHENDDATE", p_objContent.m_strLymphEndDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISGY", p_objContent.m_strMetastasisGy.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISTIMES", p_objContent.m_strMetastasisTimes.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISDAYS", p_objContent.m_strMetastasisDays.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISBEGINDATE", p_objContent.m_strMetastasisBeginDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("METASTASISENDDATE", p_objContent.m_strMetastasisEndDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYMODESEQ", p_objContent.m_strChemotherapyModeSeq.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYWHOLEBODY", p_objContent.m_strChemotherapyWholeBody.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYLOCAL", p_objContent.m_strChemotherapyLocal.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYINTUBATE", p_objContent.m_strChemotherapyIntubate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYTHORAX", p_objContent.m_strChemotherapyThorax.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYABDOMEN", p_objContent.m_strChemotherapyAbdomen.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYSPINAL", p_objContent.m_strChemotherapySpinal.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYOTHERTRY", p_objContent.m_strChemotherapyOtherTry.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYOTHER", p_objContent.m_strChemotherapyOther.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TOTALAMT", p_objContent.m_strTotalAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BEDAMT", p_objContent.m_strBedAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSEAMT", p_objContent.m_strNurseAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("WMAMT", p_objContent.m_strWMAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CMFINISHEDAMT", p_objContent.m_strCMFinishedAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CMSEMIFINISHEDAMT", p_objContent.m_strCMSemiFinishedAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RADIATIONAMT", p_objContent.m_strRadiationAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ASSAYAMT", p_objContent.m_strAssayAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("O2AMT", p_objContent.m_strO2Amt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODAMT", p_objContent.m_strBloodAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TREATMENTAMT", p_objContent.m_strTreatmentAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OPERATIONAMT", p_objContent.m_strOperationAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DELIVERYCHILDAMT", p_objContent.m_strDeliveryChildAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CHECKAMT", p_objContent.m_strCheckAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ANAETHESIAAMT", p_objContent.m_strAnaethesiaAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BABYAMT", p_objContent.m_strBabyAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ACCOMPANYAMT", p_objContent.m_strAccompanyAmt.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT1", p_objContent.m_strOtherAmt1.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT2", p_objContent.m_strOtherAmt2.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERAMT3", p_objContent.m_strOtherAmt3.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CORPSECHECK", p_objContent.m_strCorpseCheck.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FIRSTCASE", p_objContent.m_strFirstCase.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW", p_objContent.m_strFollow.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_WEEK", p_objContent.m_strFollow_Week.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_MONTH", p_objContent.m_strFollow_Month.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("FOLLOW_YEAR", p_objContent.m_strFollow_Year.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MODELCASE", p_objContent.m_strModelCase.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODTYPE", p_objContent.m_strBloodType.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODRH", p_objContent.m_strBloodRh.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BLOODTRANSACTOIN", p_objContent.m_strBloodTransActoin.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("RBC", p_objContent.m_strRBC.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PLT", p_objContent.m_strPLT.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PLASM", p_objContent.m_strPlasm.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("WHOLEBLOOD", p_objContent.m_strWholeBlood.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OTHERBLOOD", p_objContent.m_strOtherBlood.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("CONSULTATION", p_objContent.m_strConsultation.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("LONGDISTANCTCONSULTATION", p_objContent.m_strLongDistanctConsultation.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("TOPLEVEL", p_objContent.m_strTOPLevel.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELI", p_objContent.m_strNurseLevelI.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELII", p_objContent.m_strNurseLevelII.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("NURSELEVELIII", p_objContent.m_strNurseLevelIII.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("ICU", p_objContent.m_strICU.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("SPECIALNURSE", p_objContent.m_strSpecialNurse.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("DIAGNOSISZHONG", p_objContent.m_strDiagnosiszhong.Replace('\'', '五'));


            m_objXmlWriter.WriteAttributeString("INSURANCENUM", p_objContent.m_strInsuranceNum.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("MODEOFPAYMENT", p_objContent.m_strModeOfPayment.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("PATIENTHISTORYNO", p_objContent.m_strPatientHistoryNO.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("OUTPATIENTDATE", p_objContent.m_strOutPatientDate.Replace('\'', '五'));
            m_objXmlWriter.WriteAttributeString("BIRTHPLACE", p_objContent.m_strBirthPlace.Replace('\'', '五'));

            m_objXmlWriter.WriteEndElement();
            m_objXmlWriter.WriteEndDocument();
            m_objXmlWriter.Flush();
            return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
        }
        #endregion

        #region む坳淖剿赽桶
        /// <summary>
        /// OtherDiagnosis む坳淖剿赽桶
        /// </summary>
        /// <param name="p_objOtherDiagnosisArr"></param>
        /// <returns></returns>
        public string[] m_strGetOtherDiagnosisXMLArr(clsInHospitalMainRecord_OtherDiagnosis[] p_objOtherDiagnosisArr)
        {
            if (p_objOtherDiagnosisArr == null || p_objOtherDiagnosisArr.Length <= 0)
                return null;

            string[] m_strXMLArr = new string[p_objOtherDiagnosisArr.Length];
            for (int i1 = 0; i1 < p_objOtherDiagnosisArr.Length; i1++)
            {
                m_objXmlMemStream.SetLength(0);
                m_objXmlWriter.WriteStartDocument();
                m_objXmlWriter.WriteStartElement("OtherDiagnosis");
                m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objOtherDiagnosisArr[i1].m_strInPatientID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objOtherDiagnosisArr[i1].m_strInPatientDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPENDATE", p_objOtherDiagnosisArr[i1].m_strOpenDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objOtherDiagnosisArr[i1].m_strLastModifyDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objOtherDiagnosisArr[i1].m_strLastModifyUserID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objOtherDiagnosisArr[i1].m_strDeActivedDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objOtherDiagnosisArr[i1].m_strDeActivedOperatorID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("STATUS", p_objOtherDiagnosisArr[i1].m_strStatus.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SEQID", p_objOtherDiagnosisArr[i1].m_strSeqID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DIAGNOSISDESC", p_objOtherDiagnosisArr[i1].m_strDiagnosisDesc.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("CONDITIONSEQ", p_objOtherDiagnosisArr[i1].m_strConditionSeq.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("ICD10", p_objOtherDiagnosisArr[i1].m_strICD10.Replace('\'', '五'));
                m_objXmlWriter.WriteEndElement();
                m_objXmlWriter.WriteEndDocument();
                m_objXmlWriter.Flush();
                m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
            }
            return m_strXMLArr;
        }

        #endregion

        #region 忒扲陓洘赽桶
        /// <summary>
        /// 忒扲陓洘赽桶
        /// </summary>
        /// <param name="p_objOperationArr"></param>
        /// <returns></returns>
        public string[] m_strGetOperationXMLArr(clsInHospitalMainRecord_Operation[] p_objOperationArr)
        {
            if (p_objOperationArr == null || p_objOperationArr.Length <= 0)
                return null;

            string[] m_strXMLArr = new string[p_objOperationArr.Length];
            for (int i1 = 0; i1 < p_objOperationArr.Length; i1++)
            {
                m_objXmlMemStream.SetLength(0);
                m_objXmlWriter.WriteStartDocument();
                m_objXmlWriter.WriteStartElement("Operation");
                m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objOperationArr[i1].m_strInPatientID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objOperationArr[i1].m_strInPatientDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPENDATE", p_objOperationArr[i1].m_strOpenDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objOperationArr[i1].m_strLastModifyDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objOperationArr[i1].m_strLastModifyUserID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objOperationArr[i1].m_strDeActivedDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objOperationArr[i1].m_strDeActivedOperatorID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("STATUS", p_objOperationArr[i1].m_strStatus.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SEQID", p_objOperationArr[i1].m_strSeqID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPERATIONID", p_objOperationArr[i1].m_strOperationID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPERATIONDATE", p_objOperationArr[i1].m_strOperationDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPERATIONNAME", p_objOperationArr[i1].m_strOperationName.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPERATOR", p_objOperationArr[i1].m_strOperator.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("ASSISTANT1", p_objOperationArr[i1].m_strAssistant1.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("ASSISTANT2", p_objOperationArr[i1].m_strAssistant2.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("AANAESTHESIAMODEID", p_objOperationArr[i1].m_strAanaesthesiaModeID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("CUTLEVEL", p_objOperationArr[i1].m_strCutLevel.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("ANAESTHETIST", p_objOperationArr[i1].m_strAnaesthetist.Replace('\'', '五'));

                m_objXmlWriter.WriteAttributeString("OPERATIONAANAESTHESIAMODENAME", p_objOperationArr[i1].m_strAanaesthesiaModeName.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPERATIONANAESTHETISTNAME", p_objOperationArr[i1].m_strAnaesthetistName.Replace('\'', '五'));

                m_objXmlWriter.WriteEndElement();
                m_objXmlWriter.WriteEndDocument();
                m_objXmlWriter.Flush();
                m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
            }
            return m_strXMLArr;
        }
        #endregion

        #region 茪嫁赽桶
        /// <summary>
        /// 茪嫁赽桶
        /// </summary>
        /// <param name="p_objBabyArr"></param>
        /// <returns></returns>
        public string[] m_strGetBabyXMLArr(clsInHospitalMainRecord_Baby[] p_objBabyArr)
        {
            if (p_objBabyArr == null || p_objBabyArr.Length <= 0)
                return null;

            string[] m_strXMLArr = new string[p_objBabyArr.Length];
            for (int i1 = 0; i1 < p_objBabyArr.Length; i1++)
            {
                m_objXmlMemStream.SetLength(0);
                m_objXmlWriter.WriteStartDocument();
                m_objXmlWriter.WriteStartElement("Baby");
                m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objBabyArr[i1].m_strInPatientID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objBabyArr[i1].m_strInPatientDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPENDATE", p_objBabyArr[i1].m_strOpenDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objBabyArr[i1].m_strLastModifyDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objBabyArr[i1].m_strLastModifyUserID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objBabyArr[i1].m_strDeActivedDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objBabyArr[i1].m_strDeActivedOperatorID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("STATUS", p_objBabyArr[i1].m_strStatus.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SEQID", p_objBabyArr[i1].m_strSeqID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("MALE", p_objBabyArr[i1].m_strMale.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FEMALE", p_objBabyArr[i1].m_strFemale.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LIVEBORN", p_objBabyArr[i1].m_strLiveBorn.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DIEBORN", p_objBabyArr[i1].m_strDieBorn.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DIENOTBORN", p_objBabyArr[i1].m_strDieNotBorn.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("WEIGHT", p_objBabyArr[i1].m_strWeight.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DIE", p_objBabyArr[i1].m_strDie.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("CHANGEDEPARTMENT", p_objBabyArr[i1].m_strChangeDepartment.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OUTHOSPITAL", p_objBabyArr[i1].m_strOutHospital.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("NATURALCONDICTION", p_objBabyArr[i1].m_strNaturalCondiction.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SUFFOCATE1", p_objBabyArr[i1].m_strSuffocate1.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SUFFOCATE2", p_objBabyArr[i1].m_strSuffocate2.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INFECTIONTIMES", p_objBabyArr[i1].m_strInfectionTimes.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INFECTIONNAME", p_objBabyArr[i1].m_strInfectionName.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("ICD10", p_objBabyArr[i1].m_strICD10.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SALVETIMES", p_objBabyArr[i1].m_strSalveTimes.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SALVESUCCESSTIMES", p_objBabyArr[i1].m_strSalveSuccessTimes.Replace('\'', '五'));

                m_objXmlWriter.WriteEndElement();
                m_objXmlWriter.WriteEndDocument();
                m_objXmlWriter.Flush();
                m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
            }
            return m_strXMLArr;
        }

        #endregion

        #region 趙谿赽桶
        /// <summary>
        /// 趙谿赽桶
        /// </summary>
        /// <param name="p_objChemotherapyArr"></param>
        /// <returns></returns>
        public string[] m_strGetChemotherapyXMLArr(clsInHospitalMainRecord_Chemotherapy[] p_objChemotherapyArr)
        {
            if (p_objChemotherapyArr == null || p_objChemotherapyArr.Length <= 0)
                return null;

            string[] m_strXMLArr = new string[p_objChemotherapyArr.Length];
            for (int i1 = 0; i1 < p_objChemotherapyArr.Length; i1++)
            {
                m_objXmlMemStream.SetLength(0);
                m_objXmlWriter.WriteStartDocument();
                m_objXmlWriter.WriteStartElement("Chemotherapy");
                m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objChemotherapyArr[i1].m_strInPatientID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objChemotherapyArr[i1].m_strInPatientDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("OPENDATE", p_objChemotherapyArr[i1].m_strOpenDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objChemotherapyArr[i1].m_strLastModifyDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objChemotherapyArr[i1].m_strLastModifyUserID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objChemotherapyArr[i1].m_strDeActivedDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objChemotherapyArr[i1].m_strDeActivedOperatorID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("STATUS", p_objChemotherapyArr[i1].m_strStatus.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("SEQID", p_objChemotherapyArr[i1].m_strSeqID.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("CHEMOTHERAPYDATE", p_objChemotherapyArr[i1].m_strChemotherapyDate.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("MEDICINENAME", p_objChemotherapyArr[i1].m_strMedicineName.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("PERIOD", p_objChemotherapyArr[i1].m_strPeriod.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_CR", p_objChemotherapyArr[i1].m_strField_CR.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_PR", p_objChemotherapyArr[i1].m_strField_PR.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_MR", p_objChemotherapyArr[i1].m_strField_MR.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_S", p_objChemotherapyArr[i1].m_strField_S.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_P", p_objChemotherapyArr[i1].m_strField_P.Replace('\'', '五'));
                m_objXmlWriter.WriteAttributeString("FIELD_NA", p_objChemotherapyArr[i1].m_strField_NA.Replace('\'', '五'));

                m_objXmlWriter.WriteEndElement();
                m_objXmlWriter.WriteEndDocument();
                m_objXmlWriter.Flush();
                m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(), 39 * 2, (int)m_objXmlMemStream.Length - 39 * 2);
            }
            return m_strXMLArr;
        }
        #endregion

        #region 鳳腕蜆棒蛂埏腔蛂埏瓷偶忑珜腔汜傖奀潔
        /// <summary>
        /// 鳳腕蜆棒蛂埏腔蛂埏瓷偶忑珜腔汜傖奀潔
        /// 諾寀峈羶衄汜傖徹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <returns></returns>
        public long m_lngGetOpenDateInfo(string p_strInPatientID, string p_strInPatientDate, out string p_strOpenDate)
        {
            p_strOpenDate = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                string m_strXML = "";
                int m_intRows = 0;
                lngRes = m_objServ.m_lngGetOpenDateInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out m_strXML, out m_intRows);
                if (lngRes >= 0 && m_intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    p_strOpenDate = objReader.GetAttribute("OPENDATE").ToString();
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕翋桶暮翹
        /// <summary>
        /// 植杅擂踱鳳腕翋桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objMain"></param>
        /// <returns></returns>
        public long m_lngGetMainInfo(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Main p_objMain)
        {
            p_objMain = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long lngRes = 0;
            try
            {
                string m_strXML = "";
                int m_intRows = 0;

                lngRes = m_objServ.m_lngGetMainInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objMain);
                #region 導源楊ㄛ眒煙ィ
                //if (lngRes >= 0 && lngRes > 0)
                //{
                //    p_objMain = new clsInHospitalMainRecord_Main();
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objMain.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objMain.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objMain.m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objMain.m_strCreateUserID = objReader.GetAttribute("CREATEUSERID").Replace('五', '\'');
                //                    p_objMain.m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objMain.m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objMain.m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objMain.m_strDiagnosisXML = objReader.GetAttribute("DIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strInHospitalDiagnosisXML = objReader.GetAttribute("INHOSPITALDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strMainDiagnosisXML = objReader.GetAttribute("MAINDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strICD_10OfMainXML = objReader.GetAttribute("ICD_10OFMAINXML").Replace('五', '\'');
                //                    p_objMain.m_strInfectionDiagnosisXML = objReader.GetAttribute("INFECTIONDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strICD_10OfInfectionXML = objReader.GetAttribute("ICD_10OFINFECTIONXML").Replace('五', '\'');
                //                    p_objMain.m_strPathologyDiagnosisXML = objReader.GetAttribute("PATHOLOGYDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strScacheSourceXML = objReader.GetAttribute("SCACHESOURCEXML").Replace('五', '\'');
                //                    p_objMain.m_strSensitiveXML = objReader.GetAttribute("SENSITIVEXML").Replace('五', '\'');
                //                    p_objMain.m_strHbsAgXML = objReader.GetAttribute("HBSAGXML").Replace('五', '\'');
                //                    p_objMain.m_strHCV_AbXML = objReader.GetAttribute("HCV_ABXML").Replace('五', '\'');
                //                    p_objMain.m_strHIV_AbXML = objReader.GetAttribute("HIV_ABXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordWithOutHospitalXML = objReader.GetAttribute("ACCORDWITHOUTHOSPITALXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordInWithOutXML = objReader.GetAttribute("ACCORDINWITHOUTXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordBeforeOperationWithAfterXML = objReader.GetAttribute("ACCORDBFOPRWITHAFXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordClinicWithPathologyXML = objReader.GetAttribute("ACCORDCLINICWITHPATHOLOGYXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordRadiateWithPathologyXML = objReader.GetAttribute("ACCORDRADIATEWITHPATHOLOGYXML").Replace('五', '\'');
                //                    p_objMain.m_strSalveTimesXML = objReader.GetAttribute("SALVETIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strSalveSuccessXML = objReader.GetAttribute("SALVESUCCESSXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseGyXML = objReader.GetAttribute("ORIGINALDISEASEGYXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseTimesXML = objReader.GetAttribute("ORIGINALDISEASETIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseDaysXML = objReader.GetAttribute("ORIGINALDISEASEDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphGyXML = objReader.GetAttribute("LYMPHGYXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphTimesXML = objReader.GetAttribute("LYMPHTIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphDaysXML = objReader.GetAttribute("LYMPHDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisGyXML = objReader.GetAttribute("METASTASISGYXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisTimesXML = objReader.GetAttribute("METASTASISTIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisDaysXML = objReader.GetAttribute("METASTASISDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strTotalAmtXML = objReader.GetAttribute("TOTALAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBedAmtXML = objReader.GetAttribute("BEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseAmtXML = objReader.GetAttribute("NURSEAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strWMAmtXML = objReader.GetAttribute("WMAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCMFinishedAmtXML = objReader.GetAttribute("CMFINISHEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCMSemiFinishedAmtXML = objReader.GetAttribute("CMSEMIFINISHEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strRadiationAmtXML = objReader.GetAttribute("RADIATIONAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAssayAmtXML = objReader.GetAttribute("ASSAYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strO2AmtXML = objReader.GetAttribute("O2AMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBloodAmtXML = objReader.GetAttribute("BLOODAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strTreatmentAmtXML = objReader.GetAttribute("TREATMENTAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strOperationAmtXML = objReader.GetAttribute("OPERATIONAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strDeliveryChildAmtXML = objReader.GetAttribute("DELIVERYCHILDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCheckAmtXML = objReader.GetAttribute("CHECKAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAnaethesiaAmtXML = objReader.GetAttribute("ANAETHESIAAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBabyAmtXML = objReader.GetAttribute("BABYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAccompanyAmtXML = objReader.GetAttribute("ACCOMPANYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt1XML = objReader.GetAttribute("OTHERAMT1XML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt2XML = objReader.GetAttribute("OTHERAMT2XML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt3XML = objReader.GetAttribute("OTHERAMT3XML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_WeekXML = objReader.GetAttribute("FOLLOW_WEEKXML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_MonthXML = objReader.GetAttribute("FOLLOW_MONTHXML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_YearXML = objReader.GetAttribute("FOLLOW_YEARXML").Replace('五', '\'');
                //                    p_objMain.m_strBloodTypeXML = objReader.GetAttribute("BLOODTYPEXML").Replace('五', '\'');
                //                    p_objMain.m_strRBCXML = objReader.GetAttribute("RBCXML").Replace('五', '\'');
                //                    p_objMain.m_strPLTXML = objReader.GetAttribute("PLTXML").Replace('五', '\'');
                //                    p_objMain.m_strPlasmXML = objReader.GetAttribute("PLASMXML").Replace('五', '\'');
                //                    p_objMain.m_strWholeBloodXML = objReader.GetAttribute("WHOLEBLOODXML").Replace('五', '\'');
                //                    p_objMain.m_strOtherBloodXML = objReader.GetAttribute("OTHERBLOODXML").Replace('五', '\'');
                //                    p_objMain.m_strConsultationXML = objReader.GetAttribute("CONSULTATIONXML").Replace('五', '\'');
                //                    p_objMain.m_strLongDistanctConsultationXML = objReader.GetAttribute("LONGDISTANCTCONSULTATIONXML").Replace('五', '\'');
                //                    p_objMain.m_strTOPLevelXML = objReader.GetAttribute("TOPLEVELXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIXML = objReader.GetAttribute("NURSELEVELIXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIIXML = objReader.GetAttribute("NURSELEVELIIXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIIIXML = objReader.GetAttribute("NURSELEVELIIIXML").Replace('五', '\'');
                //                    p_objMain.m_strICUXML = objReader.GetAttribute("ICUXML").Replace('五', '\'');
                //                    p_objMain.m_strSpecialNurseXML = objReader.GetAttribute("SPECIALNURSEXML").Replace('五', '\'');
                //                    p_objMain.m_strSpecialNurseXML = objReader.GetAttribute("SPECIALNURSEXML").Replace('五', '\'');
                //                    p_objMain.m_strInsuranceNumXML = objReader.GetAttribute("INSURANCENUMXML").Replace('五', '\'');
                //                    p_objMain.m_strModeOfPaymentXML = objReader.GetAttribute("MODEOFPAYMENTXML").Replace('五', '\'');
                //                    p_objMain.m_strPatientHistoryNOXML = objReader.GetAttribute("PATIENTHISTORYNOXML").Replace('五', '\'');
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        public long m_lngGetDeletedMainInfo(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Main p_objMain)
        {
            p_objMain = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                string m_strXML = "";
                int m_intRows = 0;

                m_lngRes = m_objServ.m_lngGetDeletedMainInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objMain);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objMain = new clsInHospitalMainRecord_Main();
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objMain.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objMain.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objMain.m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objMain.m_strCreateUserID = objReader.GetAttribute("CREATEUSERID").Replace('五', '\'');
                //                    p_objMain.m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objMain.m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objMain.m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objMain.m_strDiagnosisXML = objReader.GetAttribute("DIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strInHospitalDiagnosisXML = objReader.GetAttribute("INHOSPITALDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strMainDiagnosisXML = objReader.GetAttribute("MAINDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strICD_10OfMainXML = objReader.GetAttribute("ICD_10OFMAINXML").Replace('五', '\'');
                //                    p_objMain.m_strInfectionDiagnosisXML = objReader.GetAttribute("INFECTIONDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strICD_10OfInfectionXML = objReader.GetAttribute("ICD_10OFINFECTIONXML").Replace('五', '\'');
                //                    p_objMain.m_strPathologyDiagnosisXML = objReader.GetAttribute("PATHOLOGYDIAGNOSISXML").Replace('五', '\'');
                //                    p_objMain.m_strScacheSourceXML = objReader.GetAttribute("SCACHESOURCEXML").Replace('五', '\'');
                //                    p_objMain.m_strSensitiveXML = objReader.GetAttribute("SENSITIVEXML").Replace('五', '\'');
                //                    p_objMain.m_strHbsAgXML = objReader.GetAttribute("HBSAGXML").Replace('五', '\'');
                //                    p_objMain.m_strHCV_AbXML = objReader.GetAttribute("HCV_ABXML").Replace('五', '\'');
                //                    p_objMain.m_strHIV_AbXML = objReader.GetAttribute("HIV_ABXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordWithOutHospitalXML = objReader.GetAttribute("ACCORDWITHOUTHOSPITALXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordInWithOutXML = objReader.GetAttribute("ACCORDINWITHOUTXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordBeforeOperationWithAfterXML = objReader.GetAttribute("ACCORDBFOPRWITHAFXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordClinicWithPathologyXML = objReader.GetAttribute("ACCORDCLINICWITHPATHOLOGYXML").Replace('五', '\'');
                //                    p_objMain.m_strAccordRadiateWithPathologyXML = objReader.GetAttribute("ACCORDRADIATEWITHPATHOLOGYXML").Replace('五', '\'');
                //                    p_objMain.m_strSalveTimesXML = objReader.GetAttribute("SALVETIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strSalveSuccessXML = objReader.GetAttribute("SALVESUCCESSXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseGyXML = objReader.GetAttribute("ORIGINALDISEASEGYXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseTimesXML = objReader.GetAttribute("ORIGINALDISEASETIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strOriginalDiseaseDaysXML = objReader.GetAttribute("ORIGINALDISEASEDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphGyXML = objReader.GetAttribute("LYMPHGYXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphTimesXML = objReader.GetAttribute("LYMPHTIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strLymphDaysXML = objReader.GetAttribute("LYMPHDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisGyXML = objReader.GetAttribute("METASTASISGYXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisTimesXML = objReader.GetAttribute("METASTASISTIMESXML").Replace('五', '\'');
                //                    p_objMain.m_strMetastasisDaysXML = objReader.GetAttribute("METASTASISDAYSXML").Replace('五', '\'');
                //                    p_objMain.m_strTotalAmtXML = objReader.GetAttribute("TOTALAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBedAmtXML = objReader.GetAttribute("BEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseAmtXML = objReader.GetAttribute("NURSEAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strWMAmtXML = objReader.GetAttribute("WMAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCMFinishedAmtXML = objReader.GetAttribute("CMFINISHEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCMSemiFinishedAmtXML = objReader.GetAttribute("CMSEMIFINISHEDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strRadiationAmtXML = objReader.GetAttribute("RADIATIONAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAssayAmtXML = objReader.GetAttribute("ASSAYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strO2AmtXML = objReader.GetAttribute("O2AMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBloodAmtXML = objReader.GetAttribute("BLOODAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strTreatmentAmtXML = objReader.GetAttribute("TREATMENTAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strOperationAmtXML = objReader.GetAttribute("OPERATIONAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strDeliveryChildAmtXML = objReader.GetAttribute("DELIVERYCHILDAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strCheckAmtXML = objReader.GetAttribute("CHECKAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAnaethesiaAmtXML = objReader.GetAttribute("ANAETHESIAAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strBabyAmtXML = objReader.GetAttribute("BABYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strAccompanyAmtXML = objReader.GetAttribute("ACCOMPANYAMTXML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt1XML = objReader.GetAttribute("OTHERAMT1XML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt2XML = objReader.GetAttribute("OTHERAMT2XML").Replace('五', '\'');
                //                    p_objMain.m_strOtherAmt3XML = objReader.GetAttribute("OTHERAMT3XML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_WeekXML = objReader.GetAttribute("FOLLOW_WEEKXML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_MonthXML = objReader.GetAttribute("FOLLOW_MONTHXML").Replace('五', '\'');
                //                    p_objMain.m_strFollow_YearXML = objReader.GetAttribute("FOLLOW_YEARXML").Replace('五', '\'');
                //                    p_objMain.m_strBloodTypeXML = objReader.GetAttribute("BLOODTYPEXML").Replace('五', '\'');
                //                    p_objMain.m_strRBCXML = objReader.GetAttribute("RBCXML").Replace('五', '\'');
                //                    p_objMain.m_strPLTXML = objReader.GetAttribute("PLTXML").Replace('五', '\'');
                //                    p_objMain.m_strPlasmXML = objReader.GetAttribute("PLASMXML").Replace('五', '\'');
                //                    p_objMain.m_strWholeBloodXML = objReader.GetAttribute("WHOLEBLOODXML").Replace('五', '\'');
                //                    p_objMain.m_strOtherBloodXML = objReader.GetAttribute("OTHERBLOODXML").Replace('五', '\'');
                //                    p_objMain.m_strConsultationXML = objReader.GetAttribute("CONSULTATIONXML").Replace('五', '\'');
                //                    p_objMain.m_strLongDistanctConsultationXML = objReader.GetAttribute("LONGDISTANCTCONSULTATIONXML").Replace('五', '\'');
                //                    p_objMain.m_strTOPLevelXML = objReader.GetAttribute("TOPLEVELXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIXML = objReader.GetAttribute("NURSELEVELIXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIIXML = objReader.GetAttribute("NURSELEVELIIXML").Replace('五', '\'');
                //                    p_objMain.m_strNurseLevelIIIXML = objReader.GetAttribute("NURSELEVELIIIXML").Replace('五', '\'');
                //                    p_objMain.m_strICUXML = objReader.GetAttribute("ICUXML").Replace('五', '\'');
                //                    p_objMain.m_strSpecialNurseXML = objReader.GetAttribute("SPECIALNURSEXML").Replace('五', '\'');
                //                    p_objMain.m_strSpecialNurseXML = objReader.GetAttribute("SPECIALNURSEXML").Replace('五', '\'');
                //                    p_objMain.m_strInsuranceNumXML = objReader.GetAttribute("INSURANCENUMXML").Replace('五', '\'');
                //                    p_objMain.m_strModeOfPaymentXML = objReader.GetAttribute("MODEOFPAYMENTXML").Replace('五', '\'');
                //                    p_objMain.m_strPatientHistoryNOXML = objReader.GetAttribute("PATIENTHISTORYNOXML").Replace('五', '\'');
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕翋赽桶暮翹
        /// <summary>
        /// 植杅擂踱鳳腕翋赽桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objContent"></param>
        /// <returns></returns>
        public long m_lngGetContentInfo(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Content p_objContent)
        {
            p_objContent = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetContentInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objContent);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objContent = new clsInHospitalMainRecord_Content();
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objContent.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objContent.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objContent.m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objContent.m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objContent.m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objContent.m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objContent.m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objContent.m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objContent.m_strDiagnosis = objReader.GetAttribute("DIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDiagnosis = objReader.GetAttribute("INHOSPITALDIAGNOSIS").Replace('五', '\'');
                //                    //ID
                //                    p_objContent.m_strDoctor = objReader.GetAttribute("DOCTOR").Replace('五', '\'');
                //                    //Name
                //                    p_objContent.m_strDoctorName = objReader.GetAttribute("DOCTORNAME").Replace('五', '\'');
                //                    p_objContent.m_strConfirmDiagnosisDate = objReader.GetAttribute("CONFIRMDIAGNOSISDATE").Replace('五', '\'');
                //                    p_objContent.m_strCondictionWhenIn = objReader.GetAttribute("CONDICTIONWHENIN").Replace('五', '\'');
                //                    p_objContent.m_strMainDiagnosis = objReader.GetAttribute("MAINDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strMainConditionSeq = objReader.GetAttribute("MAINCONDITIONSEQ").Replace('五', '\'');
                //                    p_objContent.m_strICD_10OfMain = objReader.GetAttribute("ICD_10OFMAIN").Replace('五', '\'');
                //                    p_objContent.m_strInfectionDiagnosis = objReader.GetAttribute("INFECTIONDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strInfectionCondictionSeq = objReader.GetAttribute("INFECTIONCONDICTIONSEQ").Replace('五', '\'');
                //                    p_objContent.m_strICD_10OfInfection = objReader.GetAttribute("ICD_10OFINFECTION").Replace('五', '\'');
                //                    p_objContent.m_strPathologyDiagnosis = objReader.GetAttribute("PATHOLOGYDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strScacheSource = objReader.GetAttribute("SCACHESOURCE").Replace('五', '\'');
                //                    p_objContent.m_strSensitive = objReader.GetAttribute("SENSITIVE").Replace('五', '\'');
                //                    p_objContent.m_strHbsAg = objReader.GetAttribute("HBSAG").Replace('五', '\'');
                //                    p_objContent.m_strHCV_Ab = objReader.GetAttribute("HCV_AB").Replace('五', '\'');
                //                    p_objContent.m_strHIV_Ab = objReader.GetAttribute("HIV_AB").Replace('五', '\'');
                //                    p_objContent.m_strAccordWithOutHospital = objReader.GetAttribute("ACCORDWITHOUTHOSPITAL").Replace('五', '\'');
                //                    p_objContent.m_strAccordInWithOut = objReader.GetAttribute("ACCORDINWITHOUT").Replace('五', '\'');
                //                    p_objContent.m_strAccordBeforeOperationWithAfter = objReader.GetAttribute("ACCORDBEFOREOPERATIONWITHAFTER").Replace('五', '\'');
                //                    p_objContent.m_strAccordClinicWithPathology = objReader.GetAttribute("ACCORDCLINICWITHPATHOLOGY").Replace('五', '\'');
                //                    p_objContent.m_strAccordRadiateWithPathology = objReader.GetAttribute("ACCORDRADIATEWITHPATHOLOGY").Replace('五', '\'');
                //                    p_objContent.m_strSalveTimes = objReader.GetAttribute("SALVETIMES").Replace('五', '\'');
                //                    p_objContent.m_strSalveSuccess = objReader.GetAttribute("SALVESUCCESS").Replace('五', '\'');
                //                    //ID
                //                    p_objContent.m_strDirectorDt = objReader.GetAttribute("DIRECTORDT").Replace('五', '\'');
                //                    p_objContent.m_strSubDirectorDt = objReader.GetAttribute("SUBDIRECTORDT").Replace('五', '\'');
                //                    p_objContent.m_strDt = objReader.GetAttribute("DT").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDt = objReader.GetAttribute("INHOSPITALDT").Replace('五', '\'');
                //                    p_objContent.m_strAttendInForAdvancesStudyDt = objReader.GetAttribute("ATTENDINFORADVANCESSTUDYDT").Replace('五', '\'');
                //                    p_objContent.m_strGraduateStudentIntern = objReader.GetAttribute("GRADUATESTUDENTINTERN").Replace('五', '\'');
                //                    p_objContent.m_strIntern = objReader.GetAttribute("INTERN").Replace('五', '\'');
                //                    p_objContent.m_strCoder = objReader.GetAttribute("CODER").Replace('五', '\'');
                //                    p_objContent.m_strQCDt = objReader.GetAttribute("QCDT").Replace('五', '\'');
                //                    p_objContent.m_strQCNurse = objReader.GetAttribute("QCNURSE").Replace('五', '\'');
                //                    //Name
                //                    p_objContent.m_strDirectorDtName = objReader.GetAttribute("DIRECTORDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strSubDirectorDtName = objReader.GetAttribute("SUBDIRECTORDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strDtName = objReader.GetAttribute("DTNAME").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDtName = objReader.GetAttribute("INHOSPITALDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strAttendInForAdvancesStudyDtName = objReader.GetAttribute("ATTENDINFORADVANCESSTUDYDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strGraduateStudentInternName = objReader.GetAttribute("GRADUATESTUDENTINTERNNAME").Replace('五', '\'');
                //                    //妗炾瓟汜赻撩ワ靡
                //                    //								p_objContent.m_strInternName= objReader.GetAttribute("INTERNNAME").Replace('五','\'');
                //                    p_objContent.m_strCoderName = objReader.GetAttribute("CODERNAME").Replace('五', '\'');
                //                    p_objContent.m_strQCDtName = objReader.GetAttribute("QCDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strQCNurseName = objReader.GetAttribute("QCNURSENAME").Replace('五', '\'');

                //                    p_objContent.m_strQuality = objReader.GetAttribute("QUALITY").Replace('五', '\'');

                //                    p_objContent.m_strQCTime = objReader.GetAttribute("QCTIME").Replace('五', '\'');
                //                    p_objContent.m_strRTModeSeq = objReader.GetAttribute("RTMODESEQ").Replace('五', '\'');
                //                    p_objContent.m_strRTRuleSeq = objReader.GetAttribute("RTRULESEQ").Replace('五', '\'');
                //                    p_objContent.m_strRTCo = objReader.GetAttribute("RTCO").Replace('五', '\'');
                //                    p_objContent.m_strRTAccelerator = objReader.GetAttribute("RTACCELERATOR").Replace('五', '\'');
                //                    p_objContent.m_strRTX_Ray = objReader.GetAttribute("RTX_RAY").Replace('五', '\'');

                //                    p_objContent.m_strRTLacuna = objReader.GetAttribute("RTLACUNA").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseSeq = objReader.GetAttribute("ORIGINALDISEASESEQ").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseGy = objReader.GetAttribute("ORIGINALDISEASEGY").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseTimes = objReader.GetAttribute("ORIGINALDISEASETIMES").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseDays = objReader.GetAttribute("ORIGINALDISEASEDAYS").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseBeginDate = objReader.GetAttribute("ORIGINALDISEASEBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseEndDate = objReader.GetAttribute("ORIGINALDISEASEENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strLymphSeq = objReader.GetAttribute("LYMPHSEQ").Replace('五', '\'');
                //                    p_objContent.m_strLymphGy = objReader.GetAttribute("LYMPHGY").Replace('五', '\'');
                //                    p_objContent.m_strLymphTimes = objReader.GetAttribute("LYMPHTIMES").Replace('五', '\'');
                //                    p_objContent.m_strLymphDays = objReader.GetAttribute("LYMPHDAYS").Replace('五', '\'');
                //                    p_objContent.m_strLymphBeginDate = objReader.GetAttribute("LYMPHBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strLymphEndDate = objReader.GetAttribute("LYMPHENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisGy = objReader.GetAttribute("METASTASISGY").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisTimes = objReader.GetAttribute("METASTASISTIMES").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisDays = objReader.GetAttribute("METASTASISDAYS").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisBeginDate = objReader.GetAttribute("METASTASISBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisEndDate = objReader.GetAttribute("METASTASISENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyModeSeq = objReader.GetAttribute("CHEMOTHERAPYMODESEQ").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyWholeBody = objReader.GetAttribute("CHEMOTHERAPYWHOLEBODY").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyLocal = objReader.GetAttribute("CHEMOTHERAPYLOCAL").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyIntubate = objReader.GetAttribute("CHEMOTHERAPYINTUBATE").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyThorax = objReader.GetAttribute("CHEMOTHERAPYTHORAX").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyAbdomen = objReader.GetAttribute("CHEMOTHERAPYABDOMEN").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapySpinal = objReader.GetAttribute("CHEMOTHERAPYSPINAL").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyOtherTry = objReader.GetAttribute("CHEMOTHERAPYOTHERTRY").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyOther = objReader.GetAttribute("CHEMOTHERAPYOTHER").Replace('五', '\'');
                //                    p_objContent.m_strTotalAmt = objReader.GetAttribute("TOTALAMT").Replace('五', '\'');
                //                    p_objContent.m_strBedAmt = objReader.GetAttribute("BEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strNurseAmt = objReader.GetAttribute("NURSEAMT").Replace('五', '\'');
                //                    p_objContent.m_strWMAmt = objReader.GetAttribute("WMAMT").Replace('五', '\'');
                //                    p_objContent.m_strCMFinishedAmt = objReader.GetAttribute("CMFINISHEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strCMSemiFinishedAmt = objReader.GetAttribute("CMSEMIFINISHEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strRadiationAmt = objReader.GetAttribute("RADIATIONAMT").Replace('五', '\'');
                //                    p_objContent.m_strAssayAmt = objReader.GetAttribute("ASSAYAMT").Replace('五', '\'');
                //                    p_objContent.m_strO2Amt = objReader.GetAttribute("O2AMT").Replace('五', '\'');
                //                    p_objContent.m_strBloodAmt = objReader.GetAttribute("BLOODAMT").Replace('五', '\'');
                //                    p_objContent.m_strTreatmentAmt = objReader.GetAttribute("TREATMENTAMT").Replace('五', '\'');
                //                    p_objContent.m_strOperationAmt = objReader.GetAttribute("OPERATIONAMT").Replace('五', '\'');
                //                    p_objContent.m_strDeliveryChildAmt = objReader.GetAttribute("DELIVERYCHILDAMT").Replace('五', '\'');
                //                    p_objContent.m_strCheckAmt = objReader.GetAttribute("CHECKAMT").Replace('五', '\'');
                //                    p_objContent.m_strAnaethesiaAmt = objReader.GetAttribute("ANAETHESIAAMT").Replace('五', '\'');
                //                    p_objContent.m_strBabyAmt = objReader.GetAttribute("BABYAMT").Replace('五', '\'');
                //                    p_objContent.m_strAccompanyAmt = objReader.GetAttribute("ACCOMPANYAMT").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt1 = objReader.GetAttribute("OTHERAMT1").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt2 = objReader.GetAttribute("OTHERAMT2").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt3 = objReader.GetAttribute("OTHERAMT3").Replace('五', '\'');
                //                    p_objContent.m_strCorpseCheck = objReader.GetAttribute("CORPSECHECK").Replace('五', '\'');
                //                    p_objContent.m_strFirstCase = objReader.GetAttribute("FIRSTCASE").Replace('五', '\'');
                //                    p_objContent.m_strFollow = objReader.GetAttribute("FOLLOW").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Week = objReader.GetAttribute("FOLLOW_WEEK").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Month = objReader.GetAttribute("FOLLOW_MONTH").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Year = objReader.GetAttribute("FOLLOW_YEAR").Replace('五', '\'');
                //                    p_objContent.m_strModelCase = objReader.GetAttribute("MODELCASE").Replace('五', '\'');
                //                    p_objContent.m_strBloodType = objReader.GetAttribute("BLOODTYPE").Replace('五', '\'');
                //                    p_objContent.m_strBloodRh = objReader.GetAttribute("BLOODRH").Replace('五', '\'');

                //                    p_objContent.m_strBloodTransActoin = objReader.GetAttribute("BLOODTRANSACTOIN").Replace('五', '\'');
                //                    p_objContent.m_strRBC = objReader.GetAttribute("RBC").Replace('五', '\'');
                //                    p_objContent.m_strPLT = objReader.GetAttribute("PLT").Replace('五', '\'');
                //                    p_objContent.m_strPlasm = objReader.GetAttribute("PLASM").Replace('五', '\'');
                //                    p_objContent.m_strWholeBlood = objReader.GetAttribute("WHOLEBLOOD").Replace('五', '\'');
                //                    p_objContent.m_strOtherBlood = objReader.GetAttribute("OTHERBLOOD").Replace('五', '\'');
                //                    p_objContent.m_strConsultation = objReader.GetAttribute("CONSULTATION").Replace('五', '\'');
                //                    p_objContent.m_strLongDistanctConsultation = objReader.GetAttribute("LONGDISTANCTCONSULTATION").Replace('五', '\'');
                //                    p_objContent.m_strTOPLevel = objReader.GetAttribute("TOPLEVEL").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelI = objReader.GetAttribute("NURSELEVELI").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelII = objReader.GetAttribute("NURSELEVELII").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelIII = objReader.GetAttribute("NURSELEVELIII").Replace('五', '\'');
                //                    p_objContent.m_strICU = objReader.GetAttribute("ICU").Replace('五', '\'');
                //                    p_objContent.m_strSpecialNurse = objReader.GetAttribute("SPECIALNURSE").Replace('五', '\'');
                //                    p_objContent.m_strInsuranceNum = objReader.GetAttribute("INSURANCENUM").Replace('五', '\'');
                //                    p_objContent.m_strModeOfPayment = objReader.GetAttribute("MODEOFPAYMENT").Replace('五', '\'');
                //                    p_objContent.m_strPatientHistoryNO = objReader.GetAttribute("PATIENTHISTORYNO").Replace('五', '\'');
                //                    p_objContent.m_strOutPatientDate = objReader.GetAttribute("OUTPATIENTDATE").Replace('五', '\'');
                //                    p_objContent.m_strBirthPlace = objReader.GetAttribute("BIRTHPLACE").Replace('五', '\'');
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        public long m_lngGetDeletedContentInfo(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Content p_objContent)
        {
            p_objContent = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeletedContentInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objContent);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objContent = new clsInHospitalMainRecord_Content();
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objContent.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objContent.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objContent.m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objContent.m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objContent.m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objContent.m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objContent.m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objContent.m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objContent.m_strDiagnosis = objReader.GetAttribute("DIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDiagnosis = objReader.GetAttribute("INHOSPITALDIAGNOSIS").Replace('五', '\'');
                //                    //ID
                //                    p_objContent.m_strDoctor = objReader.GetAttribute("DOCTOR").Replace('五', '\'');
                //                    //Name
                //                    p_objContent.m_strDoctorName = objReader.GetAttribute("DOCTORNAME").Replace('五', '\'');
                //                    p_objContent.m_strConfirmDiagnosisDate = objReader.GetAttribute("CONFIRMDIAGNOSISDATE").Replace('五', '\'');
                //                    p_objContent.m_strCondictionWhenIn = objReader.GetAttribute("CONDICTIONWHENIN").Replace('五', '\'');
                //                    p_objContent.m_strMainDiagnosis = objReader.GetAttribute("MAINDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strMainConditionSeq = objReader.GetAttribute("MAINCONDITIONSEQ").Replace('五', '\'');
                //                    p_objContent.m_strICD_10OfMain = objReader.GetAttribute("ICD_10OFMAIN").Replace('五', '\'');
                //                    p_objContent.m_strInfectionDiagnosis = objReader.GetAttribute("INFECTIONDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strInfectionCondictionSeq = objReader.GetAttribute("INFECTIONCONDICTIONSEQ").Replace('五', '\'');
                //                    p_objContent.m_strICD_10OfInfection = objReader.GetAttribute("ICD_10OFINFECTION").Replace('五', '\'');
                //                    p_objContent.m_strPathologyDiagnosis = objReader.GetAttribute("PATHOLOGYDIAGNOSIS").Replace('五', '\'');
                //                    p_objContent.m_strScacheSource = objReader.GetAttribute("SCACHESOURCE").Replace('五', '\'');
                //                    p_objContent.m_strSensitive = objReader.GetAttribute("SENSITIVE").Replace('五', '\'');
                //                    p_objContent.m_strHbsAg = objReader.GetAttribute("HBSAG").Replace('五', '\'');
                //                    p_objContent.m_strHCV_Ab = objReader.GetAttribute("HCV_AB").Replace('五', '\'');
                //                    p_objContent.m_strHIV_Ab = objReader.GetAttribute("HIV_AB").Replace('五', '\'');
                //                    p_objContent.m_strAccordWithOutHospital = objReader.GetAttribute("ACCORDWITHOUTHOSPITAL").Replace('五', '\'');
                //                    p_objContent.m_strAccordInWithOut = objReader.GetAttribute("ACCORDINWITHOUT").Replace('五', '\'');
                //                    p_objContent.m_strAccordBeforeOperationWithAfter = objReader.GetAttribute("ACCORDBEFOREOPERATIONWITHAFTER").Replace('五', '\'');
                //                    p_objContent.m_strAccordClinicWithPathology = objReader.GetAttribute("ACCORDCLINICWITHPATHOLOGY").Replace('五', '\'');
                //                    p_objContent.m_strAccordRadiateWithPathology = objReader.GetAttribute("ACCORDRADIATEWITHPATHOLOGY").Replace('五', '\'');
                //                    p_objContent.m_strSalveTimes = objReader.GetAttribute("SALVETIMES").Replace('五', '\'');
                //                    p_objContent.m_strSalveSuccess = objReader.GetAttribute("SALVESUCCESS").Replace('五', '\'');
                //                    //ID
                //                    p_objContent.m_strDirectorDt = objReader.GetAttribute("DIRECTORDT").Replace('五', '\'');
                //                    p_objContent.m_strSubDirectorDt = objReader.GetAttribute("SUBDIRECTORDT").Replace('五', '\'');
                //                    p_objContent.m_strDt = objReader.GetAttribute("DT").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDt = objReader.GetAttribute("INHOSPITALDT").Replace('五', '\'');
                //                    p_objContent.m_strAttendInForAdvancesStudyDt = objReader.GetAttribute("ATTENDINFORADVANCESSTUDYDT").Replace('五', '\'');
                //                    p_objContent.m_strGraduateStudentIntern = objReader.GetAttribute("GRADUATESTUDENTINTERN").Replace('五', '\'');
                //                    p_objContent.m_strIntern = objReader.GetAttribute("INTERN").Replace('五', '\'');
                //                    p_objContent.m_strCoder = objReader.GetAttribute("CODER").Replace('五', '\'');
                //                    p_objContent.m_strQCDt = objReader.GetAttribute("QCDT").Replace('五', '\'');
                //                    p_objContent.m_strQCNurse = objReader.GetAttribute("QCNURSE").Replace('五', '\'');
                //                    //Name
                //                    p_objContent.m_strDirectorDtName = objReader.GetAttribute("DIRECTORDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strSubDirectorDtName = objReader.GetAttribute("SUBDIRECTORDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strDtName = objReader.GetAttribute("DTNAME").Replace('五', '\'');
                //                    p_objContent.m_strInHospitalDtName = objReader.GetAttribute("INHOSPITALDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strAttendInForAdvancesStudyDtName = objReader.GetAttribute("ATTENDINFORADVANCESSTUDYDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strGraduateStudentInternName = objReader.GetAttribute("GRADUATESTUDENTINTERNNAME").Replace('五', '\'');
                //                    //妗炾瓟汜赻撩ワ靡
                //                    //								p_objContent.m_strInternName= objReader.GetAttribute("INTERNNAME").Replace('五','\'');
                //                    p_objContent.m_strCoderName = objReader.GetAttribute("CODERNAME").Replace('五', '\'');
                //                    p_objContent.m_strQCDtName = objReader.GetAttribute("QCDTNAME").Replace('五', '\'');
                //                    p_objContent.m_strQCNurseName = objReader.GetAttribute("QCNURSENAME").Replace('五', '\'');

                //                    p_objContent.m_strQuality = objReader.GetAttribute("QUALITY").Replace('五', '\'');

                //                    p_objContent.m_strQCTime = objReader.GetAttribute("QCTIME").Replace('五', '\'');
                //                    p_objContent.m_strRTModeSeq = objReader.GetAttribute("RTMODESEQ").Replace('五', '\'');
                //                    p_objContent.m_strRTRuleSeq = objReader.GetAttribute("RTRULESEQ").Replace('五', '\'');
                //                    p_objContent.m_strRTCo = objReader.GetAttribute("RTCO").Replace('五', '\'');
                //                    p_objContent.m_strRTAccelerator = objReader.GetAttribute("RTACCELERATOR").Replace('五', '\'');
                //                    p_objContent.m_strRTX_Ray = objReader.GetAttribute("RTX_RAY").Replace('五', '\'');

                //                    p_objContent.m_strRTLacuna = objReader.GetAttribute("RTLACUNA").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseSeq = objReader.GetAttribute("ORIGINALDISEASESEQ").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseGy = objReader.GetAttribute("ORIGINALDISEASEGY").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseTimes = objReader.GetAttribute("ORIGINALDISEASETIMES").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseDays = objReader.GetAttribute("ORIGINALDISEASEDAYS").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseBeginDate = objReader.GetAttribute("ORIGINALDISEASEBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strOriginalDiseaseEndDate = objReader.GetAttribute("ORIGINALDISEASEENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strLymphSeq = objReader.GetAttribute("LYMPHSEQ").Replace('五', '\'');
                //                    p_objContent.m_strLymphGy = objReader.GetAttribute("LYMPHGY").Replace('五', '\'');
                //                    p_objContent.m_strLymphTimes = objReader.GetAttribute("LYMPHTIMES").Replace('五', '\'');
                //                    p_objContent.m_strLymphDays = objReader.GetAttribute("LYMPHDAYS").Replace('五', '\'');
                //                    p_objContent.m_strLymphBeginDate = objReader.GetAttribute("LYMPHBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strLymphEndDate = objReader.GetAttribute("LYMPHENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisGy = objReader.GetAttribute("METASTASISGY").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisTimes = objReader.GetAttribute("METASTASISTIMES").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisDays = objReader.GetAttribute("METASTASISDAYS").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisBeginDate = objReader.GetAttribute("METASTASISBEGINDATE").Replace('五', '\'');
                //                    p_objContent.m_strMetastasisEndDate = objReader.GetAttribute("METASTASISENDDATE").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyModeSeq = objReader.GetAttribute("CHEMOTHERAPYMODESEQ").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyWholeBody = objReader.GetAttribute("CHEMOTHERAPYWHOLEBODY").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyLocal = objReader.GetAttribute("CHEMOTHERAPYLOCAL").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyIntubate = objReader.GetAttribute("CHEMOTHERAPYINTUBATE").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyThorax = objReader.GetAttribute("CHEMOTHERAPYTHORAX").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyAbdomen = objReader.GetAttribute("CHEMOTHERAPYABDOMEN").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapySpinal = objReader.GetAttribute("CHEMOTHERAPYSPINAL").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyOtherTry = objReader.GetAttribute("CHEMOTHERAPYOTHERTRY").Replace('五', '\'');
                //                    p_objContent.m_strChemotherapyOther = objReader.GetAttribute("CHEMOTHERAPYOTHER").Replace('五', '\'');
                //                    p_objContent.m_strTotalAmt = objReader.GetAttribute("TOTALAMT").Replace('五', '\'');
                //                    p_objContent.m_strBedAmt = objReader.GetAttribute("BEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strNurseAmt = objReader.GetAttribute("NURSEAMT").Replace('五', '\'');
                //                    p_objContent.m_strWMAmt = objReader.GetAttribute("WMAMT").Replace('五', '\'');
                //                    p_objContent.m_strCMFinishedAmt = objReader.GetAttribute("CMFINISHEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strCMSemiFinishedAmt = objReader.GetAttribute("CMSEMIFINISHEDAMT").Replace('五', '\'');
                //                    p_objContent.m_strRadiationAmt = objReader.GetAttribute("RADIATIONAMT").Replace('五', '\'');
                //                    p_objContent.m_strAssayAmt = objReader.GetAttribute("ASSAYAMT").Replace('五', '\'');
                //                    p_objContent.m_strO2Amt = objReader.GetAttribute("O2AMT").Replace('五', '\'');
                //                    p_objContent.m_strBloodAmt = objReader.GetAttribute("BLOODAMT").Replace('五', '\'');
                //                    p_objContent.m_strTreatmentAmt = objReader.GetAttribute("TREATMENTAMT").Replace('五', '\'');
                //                    p_objContent.m_strOperationAmt = objReader.GetAttribute("OPERATIONAMT").Replace('五', '\'');
                //                    p_objContent.m_strDeliveryChildAmt = objReader.GetAttribute("DELIVERYCHILDAMT").Replace('五', '\'');
                //                    p_objContent.m_strCheckAmt = objReader.GetAttribute("CHECKAMT").Replace('五', '\'');
                //                    p_objContent.m_strAnaethesiaAmt = objReader.GetAttribute("ANAETHESIAAMT").Replace('五', '\'');
                //                    p_objContent.m_strBabyAmt = objReader.GetAttribute("BABYAMT").Replace('五', '\'');
                //                    p_objContent.m_strAccompanyAmt = objReader.GetAttribute("ACCOMPANYAMT").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt1 = objReader.GetAttribute("OTHERAMT1").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt2 = objReader.GetAttribute("OTHERAMT2").Replace('五', '\'');
                //                    p_objContent.m_strOtherAmt3 = objReader.GetAttribute("OTHERAMT3").Replace('五', '\'');
                //                    p_objContent.m_strCorpseCheck = objReader.GetAttribute("CORPSECHECK").Replace('五', '\'');
                //                    p_objContent.m_strFirstCase = objReader.GetAttribute("FIRSTCASE").Replace('五', '\'');
                //                    p_objContent.m_strFollow = objReader.GetAttribute("FOLLOW").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Week = objReader.GetAttribute("FOLLOW_WEEK").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Month = objReader.GetAttribute("FOLLOW_MONTH").Replace('五', '\'');
                //                    p_objContent.m_strFollow_Year = objReader.GetAttribute("FOLLOW_YEAR").Replace('五', '\'');
                //                    p_objContent.m_strModelCase = objReader.GetAttribute("MODELCASE").Replace('五', '\'');
                //                    p_objContent.m_strBloodType = objReader.GetAttribute("BLOODTYPE").Replace('五', '\'');
                //                    p_objContent.m_strBloodRh = objReader.GetAttribute("BLOODRH").Replace('五', '\'');

                //                    p_objContent.m_strBloodTransActoin = objReader.GetAttribute("BLOODTRANSACTOIN").Replace('五', '\'');
                //                    p_objContent.m_strRBC = objReader.GetAttribute("RBC").Replace('五', '\'');
                //                    p_objContent.m_strPLT = objReader.GetAttribute("PLT").Replace('五', '\'');
                //                    p_objContent.m_strPlasm = objReader.GetAttribute("PLASM").Replace('五', '\'');
                //                    p_objContent.m_strWholeBlood = objReader.GetAttribute("WHOLEBLOOD").Replace('五', '\'');
                //                    p_objContent.m_strOtherBlood = objReader.GetAttribute("OTHERBLOOD").Replace('五', '\'');
                //                    p_objContent.m_strConsultation = objReader.GetAttribute("CONSULTATION").Replace('五', '\'');
                //                    p_objContent.m_strLongDistanctConsultation = objReader.GetAttribute("LONGDISTANCTCONSULTATION").Replace('五', '\'');
                //                    p_objContent.m_strTOPLevel = objReader.GetAttribute("TOPLEVEL").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelI = objReader.GetAttribute("NURSELEVELI").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelII = objReader.GetAttribute("NURSELEVELII").Replace('五', '\'');
                //                    p_objContent.m_strNurseLevelIII = objReader.GetAttribute("NURSELEVELIII").Replace('五', '\'');
                //                    p_objContent.m_strICU = objReader.GetAttribute("ICU").Replace('五', '\'');
                //                    p_objContent.m_strSpecialNurse = objReader.GetAttribute("SPECIALNURSE").Replace('五', '\'');
                //                    p_objContent.m_strInsuranceNum = objReader.GetAttribute("INSURANCENUM").Replace('五', '\'');
                //                    p_objContent.m_strModeOfPayment = objReader.GetAttribute("MODEOFPAYMENT").Replace('五', '\'');
                //                    p_objContent.m_strPatientHistoryNO = objReader.GetAttribute("PATIENTHISTORYNO").Replace('五', '\'');
                //                    p_objContent.m_strOutPatientDate = objReader.GetAttribute("OUTPATIENTDATE").Replace('五', '\'');
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕む坳淖剿赽桶暮翹(蜆桶眒煙ィ)
        /// <summary>
        /// 植杅擂踱鳳腕む坳淖剿赽桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public long m_lngGetOtherDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_OtherDiagnosis[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetOtherDiagnosisInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out m_strXML, out m_intRows);
                if (m_lngRes >= 0 && m_intRows > 0)
                {
                    p_objDataArr = new clsInHospitalMainRecord_OtherDiagnosis[m_intRows];
                    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    int m_intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_OtherDiagnosis();
                                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDiagnosisDesc = objReader.GetAttribute("DIAGNOSISDESC").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strConditionSeq = objReader.GetAttribute("CONDITIONSEQ").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strICD10 = objReader.GetAttribute("ICD10").Replace('五', '\'');

                                    m_intIndex++;
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        public long m_lngGetDeletedOtherDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_OtherDiagnosis[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeletedOtherDiagnosisInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out m_strXML, out m_intRows);
                if (m_lngRes >= 0 && m_intRows > 0)
                {
                    p_objDataArr = new clsInHospitalMainRecord_OtherDiagnosis[m_intRows];
                    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    int m_intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_OtherDiagnosis();
                                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strDiagnosisDesc = objReader.GetAttribute("DIAGNOSISDESC").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strConditionSeq = objReader.GetAttribute("CONDITIONSEQ").Replace('五', '\'');
                                    p_objDataArr[m_intIndex].m_strICD10 = objReader.GetAttribute("ICD10").Replace('五', '\'');

                                    m_intIndex++;
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕忒扲赽桶暮翹
        /// <summary>
        /// 植杅擂踱鳳腕忒扲赽桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public long m_lngGetOperationArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out	clsInHospitalMainRecord_Operation[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetOperationInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Operation[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Operation();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationID = objReader.GetAttribute("OPERATIONID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationDate = objReader.GetAttribute("OPERATIONDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationName = objReader.GetAttribute("OPERATIONNAME").Replace('五', '\'');
                //                    //ID
                //                    p_objDataArr[m_intIndex].m_strOperator = objReader.GetAttribute("OPERATOR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant1 = objReader.GetAttribute("ASSISTANT1").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant2 = objReader.GetAttribute("ASSISTANT2").Replace('五', '\'');
                //                    //Name
                //                    p_objDataArr[m_intIndex].m_strOperatorName = objReader.GetAttribute("OPERATORNAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant1Name = objReader.GetAttribute("ASSISTANT1NAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant2Name = objReader.GetAttribute("ASSISTANT2NAME").Replace('五', '\'');
                //                    //id
                //                    p_objDataArr[m_intIndex].m_strAanaesthesiaModeID = objReader.GetAttribute("AANAESTHESIAMODEID").Replace('五', '\'');
                //                    //name
                //                    p_objDataArr[m_intIndex].m_strAanaesthesiaModeName = objReader.GetAttribute("OPERATIONAANAESTHESIAMODENAME").Replace('五', '\'');

                //                    p_objDataArr[m_intIndex].m_strCutLevel = objReader.GetAttribute("CUTLEVEL").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAnaesthetist = objReader.GetAttribute("ANAESTHETIST").Replace('五', '\'');
                //                    //Name
                //                    p_objDataArr[m_intIndex].m_strAnaesthetistName = objReader.GetAttribute("OPERATIONANAESTHETISTNAME").Replace('五', '\'');
                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        public long m_lngGetDeletedOperationArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out	clsInHospitalMainRecord_Operation[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeletedOperationInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Operation[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Operation();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationID = objReader.GetAttribute("OPERATIONID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationDate = objReader.GetAttribute("OPERATIONDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOperationName = objReader.GetAttribute("OPERATIONNAME").Replace('五', '\'');
                //                    //ID
                //                    p_objDataArr[m_intIndex].m_strOperator = objReader.GetAttribute("OPERATOR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant1 = objReader.GetAttribute("ASSISTANT1").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant2 = objReader.GetAttribute("ASSISTANT2").Replace('五', '\'');
                //                    //Name
                //                    p_objDataArr[m_intIndex].m_strOperatorName = objReader.GetAttribute("OPERATORNAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant1Name = objReader.GetAttribute("ASSISTANT1NAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAssistant2Name = objReader.GetAttribute("ASSISTANT2NAME").Replace('五', '\'');
                //                    //id
                //                    p_objDataArr[m_intIndex].m_strAanaesthesiaModeID = objReader.GetAttribute("AANAESTHESIAMODEID").Replace('五', '\'');
                //                    //name
                //                    p_objDataArr[m_intIndex].m_strAanaesthesiaModeName = objReader.GetAttribute("OPERATIONAANAESTHESIAMODENAME").Replace('五', '\'');

                //                    p_objDataArr[m_intIndex].m_strCutLevel = objReader.GetAttribute("CUTLEVEL").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strAnaesthetist = objReader.GetAttribute("ANAESTHETIST").Replace('五', '\'');
                //                    //Name
                //                    p_objDataArr[m_intIndex].m_strAnaesthetistName = objReader.GetAttribute("OPERATIONANAESTHETISTNAME").Replace('五', '\'');
                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕茪嫁赽桶暮翹
        /// <summary>
        /// 植杅擂踱鳳腕茪嫁赽桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public long m_lngGetBabyArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Baby[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetBabyInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Baby[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Baby();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strMale = objReader.GetAttribute("MALE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strFemale = objReader.GetAttribute("FEMALE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLiveBorn = objReader.GetAttribute("LIVEBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDieBorn = objReader.GetAttribute("DIEBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDieNotBorn = objReader.GetAttribute("DIENOTBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strWeight = objReader.GetAttribute("WEIGHT").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDie = objReader.GetAttribute("DIE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strChangeDepartment = objReader.GetAttribute("CHANGEDEPARTMENT").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOutHospital = objReader.GetAttribute("OUTHOSPITAL").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strNaturalCondiction = objReader.GetAttribute("NATURALCONDICTION").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSuffocate1 = objReader.GetAttribute("SUFFOCATE1").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSuffocate2 = objReader.GetAttribute("SUFFOCATE2").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInfectionTimes = objReader.GetAttribute("INFECTIONTIMES").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInfectionName = objReader.GetAttribute("INFECTIONNAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strICD10 = objReader.GetAttribute("ICD10").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSalveTimes = objReader.GetAttribute("SALVETIMES").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSalveSuccessTimes = objReader.GetAttribute("SALVESUCCESSTIMES").Replace('五', '\'');
                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        public long m_lngGetDeletedBabyArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Baby[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeletedBabyInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Baby[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Baby();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strMale = objReader.GetAttribute("MALE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strFemale = objReader.GetAttribute("FEMALE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLiveBorn = objReader.GetAttribute("LIVEBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDieBorn = objReader.GetAttribute("DIEBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDieNotBorn = objReader.GetAttribute("DIENOTBORN").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strWeight = objReader.GetAttribute("WEIGHT").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDie = objReader.GetAttribute("DIE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strChangeDepartment = objReader.GetAttribute("CHANGEDEPARTMENT").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOutHospital = objReader.GetAttribute("OUTHOSPITAL").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strNaturalCondiction = objReader.GetAttribute("NATURALCONDICTION").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSuffocate1 = objReader.GetAttribute("SUFFOCATE1").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSuffocate2 = objReader.GetAttribute("SUFFOCATE2").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInfectionTimes = objReader.GetAttribute("INFECTIONTIMES").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInfectionName = objReader.GetAttribute("INFECTIONNAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strICD10 = objReader.GetAttribute("ICD10").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSalveTimes = objReader.GetAttribute("SALVETIMES").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSalveSuccessTimes = objReader.GetAttribute("SALVESUCCESSTIMES").Replace('五', '\'');
                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳腕趙谿赽桶暮翹
        /// <summary>
        /// 植杅擂踱鳳腕趙谿赽桶暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public long m_lngGetChemotherapyArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Chemotherapy[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetChemotherapyInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Chemotherapy[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Chemotherapy();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strChemotherapyDate = objReader.GetAttribute("CHEMOTHERAPYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strMedicineName = objReader.GetAttribute("MEDICINENAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strPeriod = objReader.GetAttribute("PERIOD").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_CR = objReader.GetAttribute("FIELD_CR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_PR = objReader.GetAttribute("FIELD_PR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_MR = objReader.GetAttribute("FIELD_MR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_S = objReader.GetAttribute("FIELD_S").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_P = objReader.GetAttribute("FIELD_P").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_NA = objReader.GetAttribute("FIELD_NA").Replace('五', '\'');

                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        public long m_lngGetDeletedChemotherapyArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Chemotherapy[] p_objDataArr)
        {
            p_objDataArr = null;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            string m_strXML = "";
            int m_intRows = 0;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeletedChemotherapyInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && m_intRows > 0)
                //{
                //    p_objDataArr = new clsInHospitalMainRecord_Chemotherapy[m_intRows];
                //    XmlTextReader objReader = new XmlTextReader(m_strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int m_intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objDataArr[m_intIndex] = new clsInHospitalMainRecord_Chemotherapy();
                //                    p_objDataArr[m_intIndex].m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strOpenDate = objReader.GetAttribute("OPENDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyDate = objReader.GetAttribute("LASTMODIFYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strStatus = objReader.GetAttribute("STATUS").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strSeqID = objReader.GetAttribute("SEQID").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strChemotherapyDate = objReader.GetAttribute("CHEMOTHERAPYDATE").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strMedicineName = objReader.GetAttribute("MEDICINENAME").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strPeriod = objReader.GetAttribute("PERIOD").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_CR = objReader.GetAttribute("FIELD_CR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_PR = objReader.GetAttribute("FIELD_PR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_MR = objReader.GetAttribute("FIELD_MR").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_S = objReader.GetAttribute("FIELD_S").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_P = objReader.GetAttribute("FIELD_P").Replace('五', '\'');
                //                    p_objDataArr[m_intIndex].m_strField_NA = objReader.GetAttribute("FIELD_NA").Replace('五', '\'');

                //                    m_intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        #endregion

        #region 植杅擂踱鳳�＜龠牳Ъ�
        /// <summary>
        /// 植杅擂踱鳳�＜龠牳Ъ�
        /// </summary>
        /// <param name="p_strInPatientID">蛂埏瘍</param>
        /// <param name="p_strInPatientDate">�郺瘓梪�</param>
        /// <param name="p_strOpenDate">郔綴悵湔奀潔</param>
        /// <param name="p_objDataArr">淖剿暮翹</param>
        /// <returns></returns>
        public long m_lngGetDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Diagnosis[] p_objDataArr)
        {
            p_objDataArr = null;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDiagnosisInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            return m_lngRes;
        }

        /// <summary>
        /// 植杅擂踱鳳�＜龠牳Ъ�
        /// </summary>
        /// <param name="p_strInPatientID">蛂埏瘍</param>
        /// <param name="p_strInPatientDate">�郺瘓梪�</param>
        /// <param name="p_strOpenDate">郔綴悵湔奀潔</param>
        /// <param name="p_objDataArr">淖剿暮翹</param>
        /// <returns></returns>
        public long m_lngGetDeleteDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Diagnosis[] p_objDataArr)
        {
            p_objDataArr = null;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeleteDiagnosisInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objDataArr);
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            return m_lngRes;
        }
        #endregion

        #region 耀緇脤戙鳳腕鎊郳源宒
        /// <summary>
        ///耀緇脤戙鳳腕鎊郳源宒
        /// </summary>
        /// <returns></returns>
        public long m_lngGetAnaesthesiaModeLikeID(string p_strInput, out clsAnaesthesiaModeInOperation[] p_objAnaesthesiaModeInOperation)
        {
            string strXML = "";
            int intRows = 0;
            p_objAnaesthesiaModeInOperation = null;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetAnaesthesiaModeLikeID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInput, out p_objAnaesthesiaModeInOperation);
                #region 導源楊ㄛ眒煙ィ
                //if (m_lngRes >= 0 && intRows > 0)
                //{
                //    p_objAnaesthesiaModeInOperation = new clsAnaesthesiaModeInOperation[intRows];
                //    XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                //    objReader.WhitespaceHandling = WhitespaceHandling.None;
                //    int intIndex = 0;
                //    while (objReader.Read())
                //    {
                //        switch (objReader.NodeType)
                //        {
                //            case XmlNodeType.Element:
                //                if (objReader.HasAttributes)
                //                {
                //                    p_objAnaesthesiaModeInOperation[intIndex] = new clsAnaesthesiaModeInOperation();
                //                    p_objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeID = objReader.GetAttribute("ANAESTHESIAMODEID").ToString().Replace('五', '\'');
                //                    p_objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeName = objReader.GetAttribute("ANAESTHESIAMODENAME").ToString().Replace('五', '\'');
                //                    intIndex++;
                //                }
                //                break;
                //        }

                //    }

                //} 
                #endregion
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 脤梑蜆桶婓蜆沭璃狟岆瘁衄笭葩腔暮翹
        /// <summary>
        /// 脤梑蜆桶婓蜆沭璃狟岆瘁衄笭葩腔暮翹
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_intRows"></param>
        /// <returns></returns>
        public long m_lngGetCreateDateCount(string p_strInPatientID, string p_strInPatientDate, out int p_intRows)
        {
            p_intRows = 0;
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetCreateDateCount(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out p_intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 鳳腕郔綴党蜊奀潔,党蜊��
        /// <summary>
        /// 鳳腕郔綴党蜊奀潔,党蜊��
        /// �蝜�殿隙諾ㄛ桶尨蜆暮翹眒掩刉壺
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_strLastModifyDate"></param>
        /// <param name="p_strLastModifyUserID"></param>
        /// <returns></returns>
        public long m_lngGetLastModifyDateAndUser(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out string p_strLastModifyDate, out string p_strLastModifyUserID)
        {
            p_strLastModifyDate = null;
            p_strLastModifyUserID = null;
            if (p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLastModifyDateAndUser(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_strLastModifyDate, out p_strLastModifyUserID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 鳳腕郔綴刉壺奀潔,刉壺��
        /// <summary>
        /// 鳳腕郔綴刉壺奀潔,刉壺��
        /// �蝜�殿隙諾ㄛ桶尨蜆暮翹眒掩刉壺
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strDeactivedDate"></param>
        /// <param name="p_strDeactivedUserID"></param>
        /// <returns></returns>
        public long m_lngGetDeactivedDateAndUser(string p_strInPatientID, string p_strInPatientDate, out string p_strDeactivedDate, out string p_strDeactivedUserID)
        {
            p_strDeactivedDate = null;
            p_strDeactivedUserID = null;
            if (p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDeactivedDateAndUser(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out p_strDeactivedDate, out p_strDeactivedUserID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 刉壺暮翹
        /// <summary>
        /// 刉壺暮翹
        /// </summary>
        /// <param name="p_strTableName"></param>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_strOperatorID"></param>
        /// <returns></returns>
        public long m_lngDeleteRecord(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, string p_strOperatorID)
        {
            if (p_strInPatientID == null || p_strInPatientID == "")
                return -1;
            if (p_strInPatientDate == null || p_strInPatientDate == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, p_strOperatorID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        /// <summary>
        /// 氝樓堤汜華華靡蹈桶
        /// </summary>
        /// <param name="p_strDistrict">華靡</param>
        /// <returns></returns>
        public long m_lngAddDistrict(string p_strDistrict, string p_strParentID, string p_strType)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngAddDistrict(p_strDistrict, p_strParentID, p_strType);
                if (m_lngRes == -31)
                    MDIParent.ShowInformationMessageBox("蜆華靡眒湔婓ㄐ");
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 党蜊堤汜華華靡蹈桶
        /// </summary>
        /// <param name="p_strDistrict">華靡</param>
        /// <returns></returns>
        public long m_lngModifyDistrict(string p_strDistrict, string p_strID)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngModifyDistrict(p_strDistrict, p_strID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 跦擂虜濬ID鳳�○鹺�華華靡
        /// </summary>
        /// <param name="p_strParentID">虜濬ID</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetDistrict(string p_strParentID, ref DataTable dtResult)
        {
            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDistrict(p_strParentID, ref dtResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 跦擂華靡鳳�！D
        /// </summary>
        /// <param name="p_strDistrict">華靡</param>
        /// <param name="p_strType">濬倰</param>
        /// <param name="p_strDisID">ID</param>
        /// <returns></returns>
        public long m_lngGetIDByName(string p_strDistrict, string p_strType, string p_strParentID, out string p_strDisID)
        {
            p_strDisID = "";

            com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ m_objServ =
                (com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord_XJ.clsInHospitalMainRecordServ_XJ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetDisIDByName(p_strDistrict, p_strType, p_strParentID, out p_strDisID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 植杅擂踱鳳腕垀衄桶陓洘
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objCollection"></param>
        /// <returns></returns>
        public long m_lngGetAllInfo(string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate, out clsInHospitalMainRecord_Collection p_objCollection)
        {
            p_objCollection = new clsInHospitalMainRecord_Collection();
            long m_lngRes = 0;
            m_lngRes = m_lngGetMainInfo(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objMain);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            m_lngRes = m_lngGetContentInfo(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objContent);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            m_lngRes = m_lngGetDiagnosisArr(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objDiagnosisArr);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            m_lngRes = m_lngGetOperationArr(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objOperationArr);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            m_lngRes = m_lngGetBabyArr(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objBabyArr);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            m_lngRes = m_lngGetChemotherapyArr(p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objCollection.m_objChemotherapyArr);
            if (m_lngRes < 1)
            {
                p_objCollection = null;
                return -1;
            }
            return m_lngRes;
        }
        #region 鳳�＝矽っ橦�
        /// <summary>
        /// 鳳�＝矽っ橦�
        /// </summary>
        /// <param name="p_strPatientID">瓷�氙D</param>
        /// <param name="p_strInPatientDate">蛂埏腎暮桶笢腔蛂埏�梪�</param>
        /// <param name="p_strRegisterID">蛂埏腎暮瘍</param>
        /// <param name="p_objDeptInstance">蛌褪①錶</param>
        /// <returns></returns>
        public long m_lngGetInHospitalMainTransDeptInstance(string p_strPatientID, string p_strInPatientDate, out string p_strRegisterID, out clsInHospitalMainTransDeptInstance p_objDeptInstance)
        {
            p_strRegisterID = "";
            long lngRes = 0;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));


            lngRes = objServ.m_lngGetRegisterIDByPatient(p_strPatientID, p_strInPatientDate, out p_strRegisterID);

            lngRes = m_lngGetInHospitalMainTransDeptInstance(p_strRegisterID, out p_objDeptInstance);
            //objServ.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 鳳�〃﹍佼齤監掉銫皈楟救�婓跪跺敦极脤戙
        /// </summary>
        /// <returns></returns>
        public long m_lngGetInHospitalMainTransDeptInstance(string p_strRegisterID, out clsInHospitalMainTransDeptInstance p_objDeptInstance)
        {
            long lngRes = 0;

            clsInHospitalMainRecordServ_XJ objServ =
                (clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_XJ));

            lngRes = objServ.m_lngGetInHospitalMainTransDeptInstance(p_strRegisterID, out p_objDeptInstance);
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 党蜊瓷�侄饡憶欐�
        /// </summary>
        /// <param name="p_strPatientID">瓷�氙D</param>
        /// <param name="p_strRegisterID">�郺熊ФМ�</param>
        /// <param name="p_objPeopleInfo">瓷�刵欐�</param>
        /// <returns></returns>
        public long m_lngSavePatientInfo(string p_strPatientID, string p_strRegisterID, clsPeopleInfo p_objPeopleInfo)
        {
            long lngRes = 0;

            clsInHospitalMainRecordServ_XJ objServ =
                (clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_XJ));

            lngRes = objServ.m_lngUpdateToBsePatient(p_strPatientID, p_objPeopleInfo);
            lngRes = objServ.m_lngUpdateToRegisterDetail(p_strRegisterID, p_objPeopleInfo);

            return lngRes;
        }

        /// <summary>
        /// 鳳�★蒹垓※裒腴陬鯧CD淖剿
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetICDDiagnosisCode(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsDictFromBAServ objServ =
                (clsDictFromBAServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDictFromBAServ));


            lngRes = objServ.m_lngGetICDDiagnosisCode(null, out p_dtbResult);

            return lngRes;
        }

        /// <summary>
        /// 鳳�★蒹垓※裒腴陬鐃樼窾褊�
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetAnaesthesiaMode(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsDictFromBAServ objServ =
                (clsDictFromBAServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDictFromBAServ));


            lngRes = objServ.m_lngGetAnaesthesiaMode(null, out p_dtbResult);

            return lngRes;
        }

        /// <summary>
        /// 鳳�★蒹垓※裒腴陬騫窐劘�
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetOprationCode(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsDictFromBAServ objServ =
                (clsDictFromBAServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDictFromBAServ));

            lngRes = objServ.m_lngGetOprationCode(null, out p_dtbResult);

            return lngRes;
        }

        #region 枑蝠祫嫘陲吽瓟埏苀數瓷偶奪燴炵苀
        /// <summary>
        /// 枑蝠祫嫘陲吽瓟埏苀數瓷偶奪燴炵苀
        /// </summary>
        /// <param name="p_objCollection">蛂埏瓷偶忑珜囀��</param>
        /// <param name="p_objPeoInfo">瓷�侄饡憶欐�</param>
        /// <param name="p_objTransferDept">蛌褪暮翹</param>
        /// <param name="p_strHISInDate">HIS�郺瘓梪�</param>
        /// <returns></returns>
        public long m_lngCommitToGD(clsInHospitalMainRecord_Collection p_objCollection, clsPeopleInfo p_objPeoInfo, clsInHospitalMainTransDeptInstance p_objTransferDept, string p_strHISInDate)
        {
            long lngRes = -1;
            if (p_objCollection == null || p_objCollection.m_objMain == null || p_objCollection.m_objContent == null || p_objPeoInfo == null)
            {
                return -1;
            }

            clsInHospitalMainRecordServ_XJ objServ =
                (clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_XJ));

            lngRes = objServ.m_lngCommitRecord(p_objCollection.m_objMain.m_strInPatientID, Convert.ToDateTime(p_objCollection.m_objMain.m_strInPatientDate), Convert.ToDateTime(p_objCollection.m_objMain.m_strOpenDate));
            if (lngRes < 0)
            {
                return -1;
            }

            int intInTimes = 1;
            lngRes = objServ.m_lngGetInTimes(p_objCollection.m_objMain.m_strInPatientID,
                Convert.ToDateTime(p_objCollection.m_objMain.m_strInPatientDate), out intInTimes);

            lngRes = objServ.m_lngCommitToBA1(p_objCollection.m_objMain.m_strInPatientID, intInTimes, p_objPeoInfo);
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = objServ.m_lngCommitToBA2(p_objCollection, intInTimes, p_objTransferDept, p_objPeoInfo, p_strHISInDate);

            if (lngRes < 0)
                return -1;
            lngRes = objServ.m_lngCommitToBA3(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA4(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA5(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA6(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA7(p_objTransferDept, p_objCollection.m_objMain.m_strInPatientID, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA9(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            lngRes = objServ.m_lngCommitToBA10(p_objCollection, intInTimes, p_objPeoInfo.m_StrLastName);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 鳳�◎晊襖炬蔣縭欐�
        /// </summary>
        /// <param name="p_strRegisterID">�郺熊ФМ�</param>
        /// <param name="p_objRecordArr">煤蚚肮祭陓洘</param>
        /// <returns></returns>
        public long m_lngGetCHRCATE(string p_strRegisterID, out clsInHospitalMainCharge[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;

            clsInHospitalMainRecordServ_XJ objServ =
                (clsInHospitalMainRecordServ_XJ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_XJ));

            lngRes = objServ.m_lngGetCHRCATE(null, p_strRegisterID, out p_objRecordArr);

            return lngRes;
        }
        internal void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate, ref clsPrintInfo_InHospitalMainRecord p_objPrintInfo)
        {
            p_objPrintInfo.m_strInPatentID = p_objPatient != null ? p_objPatient.m_StrInPatientID : "";
            p_objPrintInfo.m_strPatientName = p_objPatient != null ? p_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            p_objPrintInfo.m_strSex = p_objPatient != null ? p_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            p_objPrintInfo.m_strAge = p_objPatient != null ? p_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            p_objPrintInfo.m_strBedName = p_objPatient != null ? p_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            p_objPrintInfo.m_strDeptName = p_objPatient != null ? p_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            p_objPrintInfo.m_strAreaName = p_objPatient != null ? p_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            p_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            p_objPrintInfo.m_strHISInPatientID = p_objPatient != null ? p_objPatient.m_StrHISInPatientID : "";
            p_objPrintInfo.m_dtmHISInPatientDate = p_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            p_objPrintInfo.m_objPeopleInfo = p_objPatient != null ? p_objPatient.m_ObjPeopleInfo : null;
            if (p_dtmOpenDate == DateTime.MinValue)
            {
                string strOpenDate = null;
                long lngRes = m_lngGetOpenDateInfo(p_objPrintInfo.m_strInPatentID, p_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out strOpenDate);
                if (lngRes < 1)
                {
                    return;
                }
                if (strOpenDate == null || strOpenDate == "")
                    p_objPrintInfo.m_dtmOpenDate = DateTime.MinValue;
                else p_objPrintInfo.m_dtmOpenDate = DateTime.Parse(strOpenDate);
            }
            else
                p_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            clsInBedSessionInfo m_objSession = p_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_objPrintInfo.m_dtmInPatientDate);
            if (m_objSession == null)
                return;
            int m_intSessionIndex = p_objPatient.m_ObjInBedInfo.m_intGetSessionIndex(m_objSession);
            p_objPrintInfo.m_strTimes = ((int)(m_intSessionIndex + 1)).ToString();//菴撓棒蛂埏


        }
    }
}
