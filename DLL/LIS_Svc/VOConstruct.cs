using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.middletier.LIS
{
    internal class clsVOConstructor
    {
        #region 构造打印申请单信息VO
        [AutoComplete]
        public clsLisApplyReportInfo_VO m_mthContructApplyReportInfoVO(DataRow p_objRow)
        {
            clsLisApplyReportInfo_VO p_objResult = new clsLisApplyReportInfo_VO();
            p_objResult.m_strAge = p_objRow["AGE_CHR"].ToString().Trim();
            p_objResult.m_strApplicationNO = p_objRow["APPLICATION_ID_CHR"].ToString().Trim();
            p_objResult.m_strApplyDat = p_objRow["APPLICATION_DAT"].ToString().Trim();
            p_objResult.m_strApplyDept = p_objRow["deptname_vchr"].ToString().Trim();
            p_objResult.m_strApplyer = p_objRow["applyer"].ToString().Trim();
            p_objResult.m_strBedNO = p_objRow["BEDNO_CHR"].ToString().Trim();
            p_objResult.m_strCheckContent = p_objRow["CHECK_CONTENT_VCHR"].ToString().Trim();
            p_objResult.m_strCollectDat = p_objRow["sampling_date_dat"].ToString().Trim();
            p_objResult.m_strCollector = p_objRow["collector"].ToString().Trim();
            p_objResult.m_strDiagnose = p_objRow["DIAGNOSE_VCHR"].ToString().Trim();
            p_objResult.m_strPatientInHospitalNO = p_objRow["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
            p_objResult.m_strPatientName = p_objRow["PATIENT_NAME_VCHR"].ToString().Trim();
            p_objResult.m_strSampleType = p_objRow["SAMPLE_TYPE_VCHR"].ToString().Trim();
            p_objResult.m_strSex = p_objRow["SEX_CHR"].ToString().Trim();
            p_objResult.m_strChargeInfo = p_objRow["CHARGE_INFO_VCHR"].ToString().Trim();
            int.TryParse(p_objRow["PRINTED_NUM"].ToString().Trim(), out p_objResult.m_intPRINTED_NUM);
            DateTime.TryParse(p_objRow["PRINTED_DATE"].ToString().Trim(), out p_objResult.m_dtPRINTED_DATE);
            p_objResult.m_strPatientType = p_objRow["patient_type_id_chr"].ToString().Trim();
            p_objResult.m_strEmergency = p_objRow["emergency_int"].ToString().Trim();

            return p_objResult;
        }
        #endregion

        #region 构造clsSampleReceive_VO
        [AutoComplete]
        public clsSampleReceive_VO m_mthContructSampleReceiveVO(DataRow p_objRow)
        {
            clsSampleReceive_VO objRecord = new clsSampleReceive_VO();
            objRecord.m_strBarCode = p_objRow["barcode_vchr"].ToString().Trim();
            objRecord.m_strCheckContent = p_objRow["check_content_vchr"].ToString().Trim();
            objRecord.m_strIsEmergency = p_objRow["emergency_int"].ToString().Trim();
            objRecord.m_strIsSpecial = p_objRow["special_int"].ToString().Trim();
            objRecord.m_strPatientType = p_objRow["patient_type_chr"].ToString().Trim();
            objRecord.m_strReceiveDat = p_objRow["accept_dat"].ToString().Trim();
            objRecord.m_strReceiveEmpID = p_objRow["acceptor_id_chr"].ToString().Trim();
            objRecord.m_strSampleType = p_objRow["sampletype_vchr"].ToString().Trim();
            objRecord.m_intStatus = int.Parse(p_objRow["STATUS_INT"].ToString().Trim());
            objRecord.m_strSampleID = p_objRow["SAMPLE_ID_CHR"].ToString().Trim();
            objRecord.m_strReceiveEmpDec = p_objRow["lastname_vchr"].ToString().Trim();
            objRecord.m_strPatientTypeDec = p_objRow["dictname_vchr"].ToString().Trim();

            objRecord.m_strApplicationID = p_objRow["application_id_chr"].ToString().Trim();
            objRecord.m_strPatientName = p_objRow["patient_name_vchr"].ToString().Trim();
            objRecord.m_strPatientSex = p_objRow["sex_chr"].ToString().Trim();
            objRecord.m_strAge = p_objRow["age_chr"].ToString().Trim();
            objRecord.m_strPatientID = p_objRow["patientid_chr"].ToString().Trim();
            objRecord.m_strPatientCardID = p_objRow["patientcardid_chr"].ToString().Trim();
            objRecord.m_strPatientSubID = p_objRow["patient_subno_chr"].ToString().Trim();
            objRecord.m_strInpatientID = p_objRow["patient_inhospitalno_chr"].ToString().Trim();
            objRecord.m_strDeptID = p_objRow["appl_deptid_chr"].ToString().Trim();
            objRecord.m_strBedID = p_objRow["bedno_chr"].ToString().Trim();
            objRecord.m_strDocID = p_objRow["appl_empid_chr"].ToString().Trim();
            objRecord.m_strSendsample_empid_chr = p_objRow["sendsample_empid_chr"].ToString().Trim();
            objRecord.m_strSendName = p_objRow["sendname"].ToString().Trim();

            //添加是否是先诊疗后收费的项目
            try
            {
                if (!string.IsNullOrEmpty(p_objRow["isgreen_int"].ToString().Trim()))
                {
                    objRecord.m_intIsGreen = int.Parse(p_objRow["isgreen_int"].ToString().Trim());
                }
            }
            catch (Exception objEx) { }

            return objRecord;
        }
        #endregion

        #region 构造clsSampleUnReceive_VO
        /// <summary>
        /// 构造clsSampleUnReceive_VO
        /// </summary>
        /// <param name="p_objRow"></param>
        /// <returns></returns>
        public clsSampleUnReceive_VO m_mthContructSampleUnReceiveVO(DataRow p_objRow)
        {
            clsSampleUnReceive_VO objRecord = new clsSampleUnReceive_VO();

            objRecord.m_strBarCode = p_objRow["barcode_vchr"].ToString().Trim();
            objRecord.m_strCheckContent = p_objRow["check_content_vchr"].ToString().Trim();
            objRecord.m_strIsEmergency = p_objRow["emergency_int"].ToString().Trim();
            objRecord.m_strIsSpecial = p_objRow["special_int"].ToString().Trim();
            objRecord.m_strPatientType = p_objRow["patient_type_chr"].ToString().Trim();
            objRecord.m_strSamplingDat = p_objRow["sampling_date_dat"].ToString().Trim();

            objRecord.m_strSamplingEmpID = p_objRow["collector_id_chr"].ToString().Trim();
            objRecord.m_strSampleType = p_objRow["sampletype_vchr"].ToString().Trim();
            objRecord.m_strSamplingeEmpDec = p_objRow["lastname_vchr"].ToString().Trim();
            objRecord.m_strPatientTypeDec = p_objRow["dictname_vchr"].ToString().Trim();
            objRecord.m_strPatientName = p_objRow["patient_name_vchr"].ToString().Trim();

            //添加是否是先诊疗后收费的项目
            try
            {
                if (!string.IsNullOrEmpty(p_objRow["isgreen_int"].ToString().Trim()))
                {
                    objRecord.m_intIsGreen = int.Parse(p_objRow["isgreen_int"].ToString().Trim());
                }
            }
            catch (Exception objEx) { }

            return objRecord;
        }
        #endregion

        #region 构造SampleVO 刘彬 2004.5.26
        [AutoComplete]
        public clsT_OPR_LIS_SAMPLE_VO m_objConstructSampleVO(DataRow objRow)
        {
            clsT_OPR_LIS_SAMPLE_VO objSampleVO = null;
            try
            {
                objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();
                if (Microsoft.VisualBasic.Information.IsDate(objRow["APPL_DAT"]))
                {
                    objSampleVO.m_strAPPL_DAT = Convert.ToDateTime(objRow["APPL_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objSampleVO.m_strSEX_CHR = objRow["SEX_CHR"].ToString().Trim();
                objSampleVO.m_strPATIENT_NAME_VCHR = objRow["PATIENT_NAME_VCHR"].ToString().Trim();
                objSampleVO.m_strPATIENT_SUBNO_CHR = objRow["PATIENT_SUBNO_CHR"].ToString().Trim();
                objSampleVO.m_strAGE_CHR = objRow["AGE_CHR"].ToString().Trim();
                objSampleVO.m_strPATIENT_TYPE_CHR = objRow["PATIENT_TYPE_CHR"].ToString().Trim();
                objSampleVO.m_strDIAGNOSE_VCHR = objRow["DIAGNOSE_VCHR"].ToString().Trim();
                objSampleVO.m_strSAMPLETYPE_VCHR = objRow["SAMPLETYPE_VCHR"].ToString().Trim();
                objSampleVO.m_strSAMPLESTATE_VCHR = objRow["SAMPLESTATE_VCHR"].ToString().Trim();
                objSampleVO.m_strBEDNO_CHR = objRow["BEDNO_CHR"].ToString().Trim();
                objSampleVO.m_strICD_VCHR = objRow["ICD_VCHR"].ToString().Trim();
                objSampleVO.m_strPATIENTCARDID_CHR = objRow["PATIENTCARDID_CHR"].ToString().Trim();
                objSampleVO.m_strBARCODE_VCHR = objRow["BARCODE_VCHR"].ToString().Trim();
                objSampleVO.m_strSAMPLE_ID_CHR = objRow["SAMPLE_ID_CHR"].ToString().Trim();
                objSampleVO.m_strPATIENTID_CHR = objRow["PATIENTID_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(objRow["SAMPLING_DATE_DAT"]))
                {
                    objSampleVO.m_strSAMPLING_DATE_DAT = Convert.ToDateTime(objRow["SAMPLING_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objSampleVO.m_strOPERATOR_ID_CHR = objRow["OPERATOR_ID_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(objRow["MODIFY_DAT"]))
                {
                    objSampleVO.m_strMODIFY_DAT = Convert.ToDateTime(objRow["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objSampleVO.m_strAPPL_EMPID_CHR = objRow["APPL_EMPID_CHR"].ToString().Trim();
                objSampleVO.m_strAPPL_DEPTID_CHR = objRow["APPL_DEPTID_CHR"].ToString().Trim();
                objSampleVO.m_intSTATUS_INT = Convert.ToInt32(objRow["STATUS_INT"].ToString().Trim());
                objSampleVO.m_strSAMPLE_TYPE_ID_CHR = objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                objSampleVO.m_strQCSAMPLEID_CHR = objRow["QCSAMPLEID_CHR"].ToString().Trim();
                objSampleVO.m_strSAMPLEKIND_CHR = objRow["SAMPLEKIND_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(objRow["CHECK_DATE_DAT"]))
                {
                    objSampleVO.m_strCHECK_DATE_DAT = Convert.ToDateTime(objRow["CHECK_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                if (Microsoft.VisualBasic.Information.IsDate(objRow["ACCEPT_DAT"]))
                {
                    objSampleVO.m_strACCEPT_DAT = Convert.ToDateTime(objRow["ACCEPT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objSampleVO.m_strACCEPTOR_ID_CHR = objRow["ACCEPTOR_ID_CHR"].ToString().Trim();
                objSampleVO.m_strAPPLICATION_ID_CHR = objRow["APPLICATION_ID_CHR"].ToString().Trim();
                objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = objRow["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(objRow["CONFIRM_DAT"]))
                {
                    objSampleVO.m_strCONFIRM_DAT = Convert.ToDateTime(objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objSampleVO.m_strCONFIRMER_ID_CHR = objRow["CONFIRMER_ID_CHR"].ToString().Trim();
                objSampleVO.m_strCOLLECTOR_ID_CHR = objRow["COLLECTOR_ID_CHR"].ToString().Trim();
                objSampleVO.m_strCHECKER_ID_CHR = objRow["CHECKER_ID_CHR"].ToString().Trim();
                objSampleVO.m_strSendsample_empid_chr = objRow["sendsample_empid_chr"].ToString().Trim();
            }
            catch
            {
                objSampleVO = null;
            }
            return objSampleVO;
        }

        #endregion

        #region 构造clsLisApplMainVO
        [AutoComplete]
        public clsLisApplMainVO m_objConstructAppMainVO(System.Data.DataRow p_objRow)
        {
            clsLisApplMainVO objApplMainVO = new clsLisApplMainVO();
            try
            {
                if (p_objRow["APPLICATION_ID_CHR"] != System.DBNull.Value)
                { objApplMainVO.m_strAPPLICATION_ID = p_objRow["APPLICATION_ID_CHR"].ToString().Trim(); }

                if (p_objRow["MODIFY_DAT"] != System.DBNull.Value)
                { objApplMainVO.m_strMODIFY_DAT = p_objRow["MODIFY_DAT"].ToString().Trim(); }

                try
                {
                    // 存在没有barcode_vchr列的调用
                    if (p_objRow["barcode_vchr"] != System.DBNull.Value)
                        objApplMainVO.m_strBarcode = p_objRow["barcode_vchr"].ToString();
                }
                catch { }

                if (p_objRow["patientid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientID = p_objRow["patientid_chr"].ToString().Trim(); }

                if (p_objRow["application_dat"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_Dat = Convert.ToDateTime(p_objRow["application_dat"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"); }

                if (p_objRow["sex_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strSex = p_objRow["sex_chr"].ToString().Trim(); }

                if (p_objRow["patient_name_vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_Name = p_objRow["patient_name_vchr"].ToString().Trim(); }

                if (p_objRow["patient_subno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_SubNO = p_objRow["patient_subno_chr"].ToString().Trim(); }

                if (p_objRow["age_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAge = p_objRow["age_chr"].ToString().Trim(); }

                if (p_objRow["patient_type_id_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientType = p_objRow["patient_type_id_chr"].ToString().Trim(); }

                if (p_objRow["diagnose_vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strDiagnose = p_objRow["diagnose_vchr"].ToString().Trim(); }

                if (p_objRow["bedno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strBedNO = p_objRow["bedno_chr"].ToString().Trim(); }

                if (p_objRow["icdcode_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strICD = p_objRow["icdcode_chr"].ToString().Trim(); }

                if (p_objRow["patientcardid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatientcardID = p_objRow["patientcardid_chr"].ToString().Trim(); }


                if (p_objRow["application_form_no_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strApplication_Form_NO = p_objRow["application_form_no_chr"].ToString().Trim(); }

                if (p_objRow["operator_id_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strOperator_ID = p_objRow["operator_id_chr"].ToString().Trim(); }

                if (p_objRow["appl_empid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_EmpID = p_objRow["appl_empid_chr"].ToString().Trim(); }

                if (p_objRow["appl_deptid_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strAppl_DeptID = p_objRow["appl_deptid_chr"].ToString().Trim(); }

                if (p_objRow["Summary_Vchr"] != System.DBNull.Value)
                { objApplMainVO.m_strSummary = p_objRow["Summary_Vchr"].ToString().Trim(); }

                if (p_objRow["PStatus_int"] != System.DBNull.Value)
                { objApplMainVO.m_intPStatus_int = Convert.ToInt32(p_objRow["PStatus_int"]); }

                if (p_objRow["emergency_int"] != System.DBNull.Value)
                { objApplMainVO.m_intEmergency = Convert.ToInt32(p_objRow["emergency_int"]); }

                if (p_objRow["special_int"] != System.DBNull.Value)
                { objApplMainVO.m_intSpecial = Convert.ToInt32(p_objRow["special_int"]); }

                if (p_objRow["form_int"] != System.DBNull.Value)
                { objApplMainVO.m_intForm_int = Convert.ToInt32(p_objRow["form_int"]); }

                if (p_objRow["patient_inhospitalno_chr"] != System.DBNull.Value)
                { objApplMainVO.m_strPatient_inhospitalno_chr = p_objRow["patient_inhospitalno_chr"].ToString().Trim(); }

                if (p_objRow["SAMPLE_TYPE_ID_CHR"] != System.DBNull.Value)
                { objApplMainVO.m_strSampleTypeID = p_objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim(); }

                if (p_objRow["SAMPLE_TYPE_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strSampleType = p_objRow["SAMPLE_TYPE_VCHR"].ToString().Trim(); }

                if (p_objRow["CHECK_CONTENT_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strCheckContent = p_objRow["CHECK_CONTENT_VCHR"].ToString().Trim(); }
                if (p_objRow["oringin_dat"] != System.DBNull.Value)
                { objApplMainVO.m_strOriginDate = DateTime.Parse(p_objRow["oringin_dat"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss"); }
                if (p_objRow["CHARGE_INFO_VCHR"] != System.DBNull.Value)
                { objApplMainVO.m_strChargeInfo = p_objRow["CHARGE_INFO_VCHR"].ToString().Trim(); }

                if (p_objRow.Table.Columns.Contains("orderunitrelation_vchr"))
                {
                    if (p_objRow["orderunitrelation_vchr"] != System.DBNull.Value)
                    { objApplMainVO.m_strOrderunitrelation = p_objRow["orderunitrelation_vchr"].ToString().Trim(); }
                    else
                    {
                        objApplMainVO.m_strOrderunitrelation = string.Empty;
                    }
                }

                try
                {
                    //先诊疗后检查的判断条件
                    if (!string.IsNullOrEmpty(p_objRow["isgreen_int"].ToString().Trim()))
                    {
                        objApplMainVO.m_intIsGreen = int.Parse(p_objRow["isgreen_int"].ToString().Trim());
                    }
                }
                catch (Exception objEx) { }

                if (p_objRow.Table.Columns.Contains("sample_id_chr"))
                {
                    if (p_objRow["sample_id_chr"] != System.DBNull.Value)
                    { objApplMainVO.m_strSampleID = p_objRow["sample_id_chr"].ToString().Trim(); }
                    else
                    {
                        objApplMainVO.m_strSampleID = string.Empty;
                    }
                }


            }
            catch
            {
                objApplMainVO = null;
            }
            return objApplMainVO;
        }
        #endregion

        #region 构造clsLisAppReportVO,刘彬 2004-6-23
        [AutoComplete]
        public clsT_OPR_LIS_APP_REPORT_VO m_objConstructAppReportVO(System.Data.DataRow p_objRow)
        {
            clsT_OPR_LIS_APP_REPORT_VO objAppReportVO = new clsT_OPR_LIS_APP_REPORT_VO();
            try
            {
                objAppReportVO.m_strAPPLICATION_ID_CHR = p_objRow["APPLICATION_ID_CHR"].ToString().Trim();
                objAppReportVO.m_strREPORT_GROUP_ID_CHR = p_objRow["REPORT_GROUP_ID_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["MODIFY_DAT"]))
                {
                    objAppReportVO.m_strMODIFY_DAT = Convert.ToDateTime(p_objRow["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objAppReportVO.m_strSUMMARY_VCHR = p_objRow["SUMMARY_VCHR"].ToString().Trim();
                objAppReportVO.m_strOPERATOR_ID_CHR = p_objRow["OPERATOR_ID_CHR"].ToString().Trim();
                objAppReportVO.m_intSTATUS_INT = int.Parse(p_objRow["STATUS_INT"].ToString().Trim());
                objAppReportVO.m_strXML_SUMMARY_VCHR = p_objRow["XML_SUMMARY_VCHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["REPORT_DAT"]))
                {
                    objAppReportVO.m_strREPORT_DAT = Convert.ToDateTime(p_objRow["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objAppReportVO.m_strREPORTOR_ID_CHR = p_objRow["REPORTOR_ID_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["CONFIRM_DAT"]))
                {
                    objAppReportVO.m_strCONFIRM_DAT = Convert.ToDateTime(p_objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objAppReportVO.m_strCONFIRMER_ID_CHR = p_objRow["CONFIRMER_ID_CHR"].ToString().Trim();
                objAppReportVO.m_strXML_ANNOTATION_VCHR = p_objRow["XML_ANNOTATION_VCHR"].ToString().Trim();
                objAppReportVO.m_strANNOTATION_VCHR = p_objRow["ANNOTATION_VCHR"].ToString().Trim();
            }
            catch
            {
                objAppReportVO = null;
            }
            return objAppReportVO;
        }
        #endregion

        #region 构造 DeviceRelationVO 刘彬 2004.10.25
        [AutoComplete]
        public clsT_LIS_DeviceRelationVO m_objConstructDeviceRelationVO(System.Data.DataRow p_objRow)
        {
            clsT_LIS_DeviceRelationVO objVO = new clsT_LIS_DeviceRelationVO();
            try
            {
                objVO = new clsT_LIS_DeviceRelationVO();
                objVO.m_strDEVICEID_CHR = p_objRow["DEVICEID_CHR"].ToString().Trim();
                objVO.m_strSEQ_ID_CHR = p_objRow["SEQ_ID_CHR"].ToString().Trim();
                if (p_objRow["IMPORT_REQ_INT"].ToString().Trim() != "")
                {
                    objVO.m_intIMPORT_REQ_INT = int.Parse(p_objRow["IMPORT_REQ_INT"].ToString().Trim());
                }
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["RECEPTION_DAT"]))
                {
                    objVO.m_strRECEPTION_DAT = Convert.ToDateTime(p_objRow["RECEPTION_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                else
                {
                    objVO.m_strRECEPTION_DAT = null;
                }
                objVO.m_strDEVICE_SAMPLEID_CHR = p_objRow["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["CHECK_DAT"]))
                {
                    objVO.m_strCHECK_DAT = Convert.ToDateTime(p_objRow["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                else
                {
                    objVO.m_strCHECK_DAT = null;
                }
                objVO.m_strSAMPLE_ID_CHR = p_objRow["SAMPLE_ID_CHR"].ToString().Trim();
                objVO.m_strPOSITIONID_CHR = p_objRow["POSITIONID_CHR"].ToString().Trim();
                objVO.m_intSTATUS_INT = Convert.ToInt32(p_objRow["STATUS_INT"].ToString().Trim());
                objVO.m_strSEQ_ID_DEVICE_CHR = p_objRow["SEQ_ID_DEVICE_CHR"].ToString().Trim();
                objVO.m_intBIND_METHOD_INT = Convert.ToInt32(p_objRow["BIND_METHOD_INT"].ToString().Trim());
            }
            catch
            {
                objVO = null;
            }
            return objVO;
        }
        #endregion


        #region 构造 clsCheckResult_VO 刘彬 2004.10.25
        [AutoComplete]
        public clsCheckResult_VO m_objConstructCheckResultVO(System.Data.DataRow p_objRow)
        {
            clsCheckResult_VO objResultVO = new clsCheckResult_VO();
            try
            {
                objResultVO.m_strResult = p_objRow["RESULT_VCHR"].ToString().Trim();
                objResultVO.m_strUnit = p_objRow["UNIT_VCHR"].ToString().Trim();
                objResultVO.m_strDevice_Check_Item_Name = p_objRow["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["MODIFY_DAT"]))
                {
                    objResultVO.m_strModify_Dat = Convert.ToDateTime(p_objRow["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objResultVO.m_strRefrange = p_objRow["REFRANGE_VCHR"].ToString().Trim();
                objResultVO.m_strCheck_Item_Name = p_objRow["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                objResultVO.m_strCheck_Item_English_Name = p_objRow["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
                objResultVO.m_strMin_Val = p_objRow["MIN_VAL_DEC"].ToString().Trim();
                objResultVO.m_strMax_Val = p_objRow["MAX_VAL_DEC"].ToString().Trim();
                objResultVO.m_strAbnormal_Flag = p_objRow["ABNORMAL_FLAG_CHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["CHECK_DAT"]))
                {
                    objResultVO.m_strCheck_Dat = Convert.ToDateTime(p_objRow["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objResultVO.m_strClinicApp = p_objRow["CLINICAPP_VCHR"].ToString().Trim();
                objResultVO.m_strMemo = p_objRow["MEMO_VCHR"].ToString().Trim();
                if (Microsoft.VisualBasic.Information.IsDate(p_objRow["CONFIRM_DAT"]))
                {
                    objResultVO.m_strConfirm_Dat = Convert.ToDateTime(p_objRow["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                }
                objResultVO.m_strDeviceID = p_objRow["DEVICEID_CHR"].ToString().Trim();
                objResultVO.m_strPointliststr = p_objRow["POINTLISTSTR_VCHR"].ToString().Trim();
                objResultVO.m_strSummary = p_objRow["SUMMARY_VCHR"].ToString().Trim();
                objResultVO.m_intStatus = Convert.ToInt32(p_objRow["STATUS_INT"].ToString().Trim());
                objResultVO.m_strChecker1 = p_objRow["CHECKER1_CHR"].ToString().Trim();
                objResultVO.m_strChecker2 = p_objRow["CHECKER2_CHR"].ToString().Trim();
                objResultVO.m_strConfirm_Person = p_objRow["CONFIRM_PERSON_CHR"].ToString().Trim();
                objResultVO.m_strOperator_ID = p_objRow["OPERATOR_ID_CHR"].ToString().Trim();
                objResultVO.m_strCheck_DeptID = p_objRow["CHECK_DEPTID_CHR"].ToString().Trim();
                objResultVO.m_strGroupID = p_objRow["GROUPID_CHR"].ToString().Trim();
                objResultVO.m_strCheck_Item_ID = p_objRow["CHECK_ITEM_ID_CHR"].ToString().Trim();
                objResultVO.m_strSample_ID = p_objRow["SAMPLE_ID_CHR"].ToString().Trim();
                objResultVO.strGraphFormatName = p_objRow["GRAPH_FORMAT_NAME_VCHR"].ToString().Trim();
                if (p_objRow["IS_GRAPH_RESULT_NUM"] != DBNull.Value)
                {
                    objResultVO.intIsGraphResult = Convert.ToInt32(p_objRow["IS_GRAPH_RESULT_NUM"]);
                }
                if (p_objRow["GRAPH_IMG"] != DBNull.Value)
                {
                    objResultVO.m_byaGraph = (byte[])p_objRow["GRAPH_IMG"];
                }
            }
            catch
            {
                objResultVO = null;
            }
            return objResultVO;
        }
        #endregion

        #region 分单
        #region 构造 clsUnitPropertyVO
        [AutoComplete]
        public clsUnitProperty_VO m_objConstructUnitPropertyVO(System.Data.DataRow p_objRow)
        {
            clsUnitProperty_VO objVO = new clsUnitProperty_VO();
            try
            {
                objVO.m_intINUSE_FLAG_NUM = int.Parse(p_objRow["INUSE_FLAG_NUM"].ToString());
                objVO.m_intPROPERTY_PRIORITY_NUM = int.Parse(p_objRow["PROPERTY_PRIORITY_NUM"].ToString());
                objVO.m_strPROPERTY_ID_CHR = p_objRow["PROPERTY_ID_CHR"].ToString().Trim();
                objVO.m_strPROPERTY_NAME_VCHR = p_objRow["PROPERTY_NAME_VCHR"].ToString().Trim();
                objVO.m_strSUMMARY_VCHR = p_objRow["SUMMARY_VCHR"].ToString().Trim();
            }
            catch
            {
                objVO = null;
            }
            return objVO;
        }
        #endregion

        #region 构造 clsUnitPropertyVO
        [AutoComplete]
        public clsUnitPropertyValue_VO m_objConstructUnitPropertyValueVO(System.Data.DataRow p_objRow)
        {
            clsUnitPropertyValue_VO objVO = new clsUnitPropertyValue_VO();
            try
            {
                objVO.m_intINUSE_FLAG_NUM = int.Parse(p_objRow["INUSE_FLAG_NUM"].ToString());
                objVO.m_strVLAUE_VCHR = p_objRow["VLAUE_VCHR"].ToString();
                objVO.m_strPROPERTY_ID_CHR = p_objRow["PROPERTY_ID_CHR"].ToString().Trim();
                objVO.m_strVALUE_ID_CHR = p_objRow["VLAUE_ID_CHR"].ToString().Trim();
            }
            catch
            {
                objVO = null;
            }
            return objVO;
        }
        #endregion

        #region 构造 clsUnitPropertyRelate_VO
        [AutoComplete]
        public clsUnitPropertyRelate_VO m_objConstructUnitPropertyRelateVO(System.Data.DataRow p_objRow)
        {
            clsUnitPropertyRelate_VO objVO = new clsUnitPropertyRelate_VO();
            try
            {
                objVO.m_strAPPLY_UNIT_ID_CHR = p_objRow["APPLY_UNIT_ID_CHR"].ToString();
                objVO.m_strUNIT_PROPERTY_ID_CHR = p_objRow["UNIT_PROPERTY_ID_CHR"].ToString();
                objVO.m_strVALUE_ID_CHR = p_objRow["VALUE_ID_CHR"].ToString();
                objVO.m_intPRIORITY_NUM = int.Parse(p_objRow["PRIORITY_NUM"].ToString());
            }
            catch
            {
                objVO = null;
            }
            return objVO;
        }
        #endregion

        #endregion

    }
}