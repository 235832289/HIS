using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using System.Security.Principal;
using com.digitalwave.iCare.middletier;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;
using System.Collections;

namespace com.digitalwave.iCare.middletier.LIS
{

    /// <summary>
    /// 检验申请单SVc
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsApplicationMainSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        [AutoComplete]
        public long m_lngGetApplicationValid(string applicationId, out bool isValid)
        {

            long lngRes = 0;
            isValid = false;

            #region == sql ==

            string sql = string.Format(@"   select application_id_chr
                                              from t_opr_lis_application 
                                             where application_id_chr = '{0}' 
                                               and pstatus_int = 2  ", applicationId);

            #endregion

            try
            {
                DataTable dtbResult = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql, ref dtbResult);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    isValid = true;
                }
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngGetApplication(string orderId, out List<clsLisApplMainVO> lstAppMain)
        {
            long lngRes = 0;
            lstAppMain = new List<clsLisApplMainVO>();

            string sql = string.Format(@"   select b.sample_id_chr,a.*
                                              from t_opr_lis_application a, 
                                                   t_opr_lis_sample b
                                             where a.pstatus_int = 2
                                               and a.application_id_chr=b.application_id_chr(+)
                                               and a.orderunitrelation_vchr like '%{0}%' ", orderId);

            try
            {
                sql = @"select c.sample_id_chr, b.*
                          from t_opr_attachrelation a
                         inner join t_opr_lis_application b
                            on a.attachid_vchr = b.application_id_chr
                          left join t_opr_lis_sample c
                            on b.application_id_chr = c.application_id_chr
                         where a.sourceitemid_vchr = ?
                           and b.pstatus_int = 2";

                DataTable dtbResult = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] parm = null;
                objHRPSvc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = orderId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql, ref dtbResult, parm);
                if (lngRes > 0 && dtbResult != null)
                {
                    foreach (DataRow dr in dtbResult.Rows)
                    {
                        lstAppMain.Add(new clsVOConstructor().m_objConstructAppMainVO(dr));
                    }
                    //if (dtbResult.Rows.Count == 0)
                    //{
                    //    // throw new Exception(string.Format("未找到医嘱Id{0}对应的申请单!", orderId));
                    //}
                    //else if (dtbResult.Rows.Count == 1)
                    //{
                    //    applMain = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[0]);
                    //}
                    //else
                    //{
                    //    throw new Exception(string.Format("医嘱Id为{0}对应的不只一个申请单!", orderId));
                    //}
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex.Message);
                throw ex;
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngDeleteApplication(string applicationId)
        {
            long lngRes = 0;
            clsApplicationSvc objServ = new clsApplicationSvc();
            lngRes = objServ.m_lngDeleteApp(applicationId, "");
            return lngRes;
        }


        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfoWithBarcode(
                        IPrincipal principal,
                        clsLisApplMainVO applMain, out clsLisApplMainVO applMainOut,
                        clsT_OPR_LIS_APP_REPORT_VO[] arrReports, clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples,
                        clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems, clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnits,
                        clsLisAppUnitItemVO[] arrUnitItemRelations)
        {
            applMainOut = applMain;
            long lngRes = 0;
            long lngReff = 0;

            if (applMain == null)
            {
                return -2;
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(applMain, out applMainOut);
                applMain = applMainOut;

                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < arrReports.Length; i++)
                    {
                        arrReports[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrSamples.Length; i++)
                    {
                        arrSamples[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrCheckItems.Length; i++)
                    {
                        arrCheckItems[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrApplyUnits.Length; i++)
                    {
                        arrApplyUnits[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrUnitItemRelations.Length; i++)
                    {
                        arrUnitItemRelations[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewReportGroup(arrReports);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(arrSamples);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(arrCheckItems);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(arrApplyUnits);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(arrUnitItemRelations);
                }
                if (lngRes > 0)
                {
                    //自动生成barcode号
                    clsHRPTableService objHRPSvc = new clsHRPTableService();
                    string strSQL = @"select seq_lis_barcode.nextval from dual";
                    DataTable dtResult = new DataTable();
                    string strBarcode = "";
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                    if (lngRes > 0)
                    {
                        if (dtResult.Rows[0][0] == System.DBNull.Value)
                        {
                            strBarcode = "";
                        }
                        else
                        {
                            strBarcode = dtResult.Rows[0][0].ToString();
                        }
                    }
                    dtResult = null;
                    objHRPSvc = null;

                    clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();

                    #region 构造SampleVO

                    objSampleVO.m_strAPPL_DAT = applMain.m_strAppl_Dat;
                    objSampleVO.m_strSEX_CHR = applMain.m_strSex;
                    objSampleVO.m_strPATIENT_NAME_VCHR = applMain.m_strPatient_Name;
                    objSampleVO.m_strPATIENT_SUBNO_CHR = applMain.m_strPatient_SubNO;
                    objSampleVO.m_strAGE_CHR = applMain.m_strAge;
                    objSampleVO.m_strPATIENT_TYPE_CHR = applMain.m_strPatientType;
                    objSampleVO.m_strDIAGNOSE_VCHR = applMain.m_strDiagnose;
                    objSampleVO.m_strBEDNO_CHR = applMain.m_strBedNO;
                    objSampleVO.m_strICD_VCHR = applMain.m_strICD;
                    objSampleVO.m_strPATIENTCARDID_CHR = applMain.m_strPatientcardID;
                    objSampleVO.m_strPATIENTID_CHR = applMain.m_strPatientID;
                    objSampleVO.m_strAPPL_EMPID_CHR = applMain.m_strAppl_EmpID;
                    objSampleVO.m_strAPPL_DEPTID_CHR = applMain.m_strAppl_DeptID;
                    objSampleVO.m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = applMain.m_strPatient_inhospitalno_chr;
                    objSampleVO.m_strSAMPLE_TYPE_ID_CHR = applMain.m_strSampleTypeID;
                    objSampleVO.m_strSAMPLETYPE_VCHR = applMain.m_strSampleType;
                    objSampleVO.m_intSTATUS_INT = 3;
                    objSampleVO.m_strQCSAMPLEID_CHR = "-1";

                    objSampleVO.m_strSAMPLEKIND_CHR = "1";
                    objSampleVO.m_strSAMPLE_ID_CHR = null;

                    objSampleVO.m_strSAMPLESTATE_VCHR = "";

                    if (strBarcode.Trim() != "")
                    {
                        strBarcode = strBarcode.PadLeft(9, '0');
                    }

                    objSampleVO.m_strBARCODE_VCHR = strBarcode;

                    objSampleVO.m_strOPERATOR_ID_CHR = applMain.m_strOperator_ID;

                    objSampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    objSampleVO.m_strCOLLECTOR_ID_CHR = null;

                    objSampleVO.m_strACCEPTOR_ID_CHR = applMain.m_strOperator_ID;

                    objSampleVO.m_strACCEPT_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    #endregion

                    lngRes = 0;
                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(principal, objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    for (int i = 0; i < arrSamples.Length; i++)
                    {
                        arrSamples[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                }
                if (lngRes <= 0)
                {
                    throw new Exception(string.Empty);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }


        [AutoComplete]
        public long m_lngAddNewAppInfo(clsLisApplMainVO applMain, out clsLisApplMainVO applMainOut, bool isSend,
                                       clsT_OPR_LIS_APP_REPORT_VO[] arrReports, clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples,
                                       clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems, clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnits,
                                       clsLisAppUnitItemVO[] arrUnitItems)
        {
            long lngRes = 0;
            applMainOut = applMain;

            if (isSend)
            {
                applMain.m_intPStatus_int = 2;
            }

            if (applMain == null)
            {
                return -2;
            }

            try
            {
                lngRes = m_lngAddNewAppl(applMain, out applMainOut);
                applMain = applMainOut;
                if (lngRes > 0)
                {
                    #region 赋申请单ID

                    for (int i = 0; i < arrReports.Length; i++)
                    {
                        arrReports[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrSamples.Length; i++)
                    {
                        arrSamples[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrCheckItems.Length; i++)
                    {
                        arrCheckItems[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrApplyUnits.Length; i++)
                    {
                        arrApplyUnits[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < arrUnitItems.Length; i++)
                    {
                        arrUnitItems[i].m_strAPPLICATION_ID_CHR = applMain.m_strAPPLICATION_ID;
                    }

                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewReportGroup(arrReports);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(arrSamples);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(arrCheckItems);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(arrApplyUnits);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(arrUnitItems);
                }

                if (lngRes <= 0)
                {
                    throw new Exception(string.Empty);
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppl(clsLisApplMainVO applMain, out clsLisApplMainVO applMainOut)
        {
            #region == SQL ==

            string sql = @"insert into t_opr_lis_application
                                      ( application_id_chr      , modify_dat, 
							            patientid_chr           , application_dat, 
							            sex_chr                 , patient_name_vchr, 
							            patient_subno_chr       , age_chr, 
							            patient_type_id_chr     , diagnose_vchr, 
							            bedno_chr               , icdcode_chr, 
							            patientcardid_chr       , application_form_no_chr, 
							            operator_id_chr         , appl_empid_chr, 
							            appl_deptid_chr         , summary_vchr, 
							            pstatus_int             , emergency_int,
							            special_int             , form_int,
							            patient_inhospitalno_chr, sample_type_id_chr,
							            sample_type_vchr        , check_content_vchr,
							            oringin_dat             , charge_info_vchr,   orderunitrelation_vchr  )
								values(      ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?   )";


            #endregion

            applMainOut = applMain;
            long lngRes = 0;
            try
            {
                IDataParameter[] objLisApplArr = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(29, out objLisApplArr);

                DateTime CurTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (!IsNullOrEmptyOrSpace(applMain.m_strMODIFY_DAT))
                {
                    try
                    {
                        DateTime dtmPreModify = DateTime.Parse(applMain.m_strMODIFY_DAT);
                        TimeSpan ts = CurTime - dtmPreModify;
                        if (ts.TotalMilliseconds < 1000)
                            CurTime = CurTime.AddSeconds(1f);
                    }
                    catch { }
                }

                if (IsNullOrEmptyOrSpace(applMain.m_strAPPLICATION_ID))
                {
                    string strNewApplID = null;
                    objHRPSvc.m_lngGenerateNewID("t_opr_lis_application", "APPLICATION_ID_CHR", out strNewApplID);
                    if (string.IsNullOrEmpty(strNewApplID))
                    {
                        throw new Exception("不能分配申请单ID");
                    }
                    applMain.m_strAPPLICATION_ID = strNewApplID;
                }


                objLisApplArr[0].Value = applMain.m_strAPPLICATION_ID;
                applMain.m_strMODIFY_DAT = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
                objLisApplArr[1].Value = CurTime;
                if (IsNullOrEmptyOrSpace(applMain.m_strPatientID))
                {
                    applMain.m_strPatientID = "-1";
                }
                objLisApplArr[2].Value = applMain.m_strPatientID;
                objLisApplArr[2].DbType = DbType.String;

                if (Microsoft.VisualBasic.Information.IsDate(applMain.m_strAppl_Dat))
                {
                    objLisApplArr[3].Value = System.DateTime.Parse(applMain.m_strAppl_Dat);
                }
                else
                {
                    applMain.m_strAppl_Dat = null;
                }
                objLisApplArr[4].Value = applMain.m_strSex;
                objLisApplArr[5].Value = applMain.m_strPatient_Name;
                objLisApplArr[6].Value = applMain.m_strPatient_SubNO;
                objLisApplArr[7].Value = applMain.m_strAge;
                objLisApplArr[8].Value = applMain.m_strPatientType;
                objLisApplArr[9].Value = applMain.m_strDiagnose;
                objLisApplArr[10].Value = applMain.m_strBedNO;
                objLisApplArr[11].Value = applMain.m_strICD;

                if (IsNullOrEmptyOrSpace(applMain.m_strPatientcardID))
                {
                    objLisApplArr[12].Value = System.DBNull.Value;
                }
                else
                {
                    objLisApplArr[12].Value = applMain.m_strPatientcardID;
                }

                objLisApplArr[13].Value = applMain.m_strApplication_Form_NO;
                objLisApplArr[14].Value = applMain.m_strOperator_ID;
                objLisApplArr[15].Value = applMain.m_strAppl_EmpID;
                objLisApplArr[16].Value = applMain.m_strAppl_DeptID;
                objLisApplArr[17].Value = applMain.m_strSummary;
                objLisApplArr[18].Value = applMain.m_intPStatus_int;
                objLisApplArr[19].Value = applMain.m_intEmergency;
                objLisApplArr[20].Value = applMain.m_intSpecial;
                objLisApplArr[21].Value = applMain.m_intForm_int;
                objLisApplArr[22].Value = applMain.m_strPatient_inhospitalno_chr;
                objLisApplArr[23].Value = applMain.m_strSampleTypeID;
                objLisApplArr[24].Value = applMain.m_strSampleType;
                objLisApplArr[25].Value = applMain.m_strCheckContent;
                try
                {
                    DateTime.Parse(applMain.m_strOriginDate);
                }
                catch
                {
                    applMain.m_strOriginDate = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
                }

                objLisApplArr[26].Value = DateTime.Parse(applMain.m_strOriginDate);
                objLisApplArr[27].Value = applMain.m_strChargeInfo;
                objLisApplArr[28].Value = applMain.m_strOrderunitrelation;

                long lngRecEff = -1;

                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, objLisApplArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewReportGroup(clsT_OPR_LIS_APP_REPORT_VO[] arrReports)
        {
            long lngRes = 0;
            long lngEff = 0;
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            #region === sql ===

            string strSQL = @"insert into t_opr_lis_app_report(    
                                                                   application_id_chr,
                                                                   report_group_id_chr,
                                                                   modify_dat,
                                                                   summary_vchr,
                                                                   operator_id_chr, 
                                                                   status_int,
                                                                   report_dat,
                                                                   reportor_id_chr, 
                                                                   confirm_dat,
                                                                   confirmer_id_chr,
                                                                   xml_summary_vchr, 
                                                                   annotation_vchr,
                                                                   xml_annotation_vchr
                                                             )
                                                     values  (     ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (arrReports != null)
                {
                    for (int i = 0; i < arrReports.Length; i++)
                    {
                        if (arrReports[i] != null)
                        {
                            arrReports[i].m_strMODIFY_DAT = strNow;

                            IDataParameter[] objDPArr = null;
                            objHRPSvc.CreateDatabaseParameter(13, out objDPArr);

                            objDPArr[0].Value = arrReports[i].m_strAPPLICATION_ID_CHR;
                            objDPArr[1].Value = arrReports[i].m_strREPORT_GROUP_ID_CHR;
                            objDPArr[2].Value = DateTime.Parse(arrReports[i].m_strMODIFY_DAT);
                            objDPArr[3].Value = arrReports[i].m_strSUMMARY_VCHR;
                            objDPArr[4].Value = arrReports[i].m_strOPERATOR_ID_CHR;
                            objDPArr[5].Value = arrReports[i].m_intSTATUS_INT;
                            if (Microsoft.VisualBasic.Information.IsDate(arrReports[i].m_strREPORT_DAT))
                            {
                                objDPArr[6].Value = DateTime.Parse(arrReports[i].m_strREPORT_DAT);
                            }
                            else
                            {
                                arrReports[i].m_strREPORT_DAT = null;
                            }
                            objDPArr[7].Value = arrReports[i].m_strREPORTOR_ID_CHR;
                            if (Microsoft.VisualBasic.Information.IsDate(arrReports[i].m_strCONFIRM_DAT))
                            {
                                objDPArr[8].Value = DateTime.Parse(arrReports[i].m_strCONFIRM_DAT);
                            }
                            else
                            {
                                arrReports[i].m_strCONFIRM_DAT = null;
                            }
                            objDPArr[9].Value = arrReports[i].m_strCONFIRMER_ID_CHR;
                            objDPArr[10].Value = arrReports[i].m_strXML_SUMMARY_VCHR;
                            objDPArr[11].Value = arrReports[i].m_strANNOTATION_VCHR;
                            objDPArr[12].Value = arrReports[i].m_strXML_ANNOTATION_VCHR;

                            lngRes = 0;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                            if (lngRes < 0)
                            {
                                throw new Exception("保存报告单失败.");
                            }
                            objHRPSvc.Dispose();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppCheckItem(clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems)
        {
            long lngRes = 0;
            long lngEff = 0;

            #region == SQL ==

            string sql = @"insert into t_opr_lis_app_check_item (
                                                                    check_item_id_chr,
                                                                    sample_group_id_chr,
                                                                    report_group_id_chr,
                                                                    application_id_chr
                                                                )
                                                         values ( ?, ?, ?, ?) ";

            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                for (int i = 0; i < arrCheckItems.Length; i++)
                {
                    if (arrCheckItems[i] != null)
                    {
                        IDataParameter[] arrParams = null;
                        objHRPSvc.CreateDatabaseParameter(4, out arrParams);

                        arrParams[0].Value = arrCheckItems[i].m_strCHECK_ITEM_ID_CHR;
                        arrParams[1].Value = arrCheckItems[i].m_strSAMPLE_GROUP_ID_CHR;
                        arrParams[2].Value = arrCheckItems[i].m_strREPORT_GROUP_ID_CHR;
                        arrParams[3].Value = arrCheckItems[i].m_strAPPLICATION_ID_CHR;

                        lngRes = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngEff, arrParams);
                        if (lngRes < 0)
                        {
                            throw new Exception("保存报告单失败.");
                        }
                    }
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppSampleGroup(clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples)
        {
            long lngRes = 0;
            long lngReff = 0;

            #region == SQL ==

            string sql = @" insert into t_opr_lis_app_sample (
                                                                application_id_chr,
                                                                sample_group_id_chr,
                                                                report_group_id_chr,
                                                                sample_id_chr) 
                                                      values ( ?, ?, ?, ? )";

            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                for (int i = 0; i < arrSamples.Length; i++)
                {
                    if (arrSamples[i] != null)
                    {
                        IDataParameter[] arrParams = null;
                        objHRPSvc.CreateDatabaseParameter(4, out arrParams);

                        arrParams[0].Value = arrSamples[i].m_strAPPLICATION_ID_CHR;
                        arrParams[1].Value = arrSamples[i].m_strSAMPLE_GROUP_ID_CHR;
                        arrParams[2].Value = arrSamples[i].m_strREPORT_GROUP_ID_CHR;
                        arrParams[3].Value = arrSamples[i].m_strSAMPLE_ID_CHR;

                        lngRes = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParams);
                        if (lngRes < 0)
                        {
                            throw new Exception("保存报告单失败.");
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }

            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppApplyUint(clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnit)
        {
            long lngRes = 0;
            long lngReff = 0;

            #region == SQL ===
            string sql = @"insert into t_opr_lis_app_apply_unit(
                                                                    application_id_chr,
                                                                    user_group_string,
                                                                    apply_unit_id_chr
                                                                ) 
                                                         values ( ?, ?, ?) ";
            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                for (int i = 0; i < arrApplyUnit.Length; i++)
                {
                    if (arrApplyUnit[i] != null)
                    {
                        IDataParameter[] arrParams = null;
                        objHRPSvc.CreateDatabaseParameter(3, out arrParams);

                        arrParams[0].Value = arrApplyUnit[i].m_strAPPLICATION_ID_CHR;
                        arrParams[1].Value = arrApplyUnit[i].m_strUSER_GROUP_STRING;
                        arrParams[2].Value = arrApplyUnit[i].m_strAPPLY_UNIT_ID_CHR;

                        lngRes = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParams);
                        if (lngRes < 0)
                        {
                            throw new Exception("保存报告单失败.");
                        }
                    }
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppUintItemArr(clsLisAppUnitItemVO[] arrUnitItems)
        {
            long lngRes = 0;
            long lngReff = 0;
            try
            {
                for (int i = 0; i < arrUnitItems.Length; i++)
                {
                    if (arrUnitItems[i] != null)
                    {
                        lngRes = 0;
                        lngRes = m_lngAddNewAppUnitItem(arrUnitItems[i]);
                        if (lngRes <= 0)
                        {
                            throw new Exception("保存报告单失败!");
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        [AutoComplete]
        private long m_lngAddNewAppUnitItem(clsLisAppUnitItemVO unitItemRelation)
        {
            long lngRes = 0;
            long lngReff = 0;

            #region == SQL ==

            string sql = @"insert into t_opr_lis_app_unit_item (
                                                                    application_id_chr,
                                                                    check_item_id_chr,
                                                                    apply_unit_id_chr
                                                                )
                                                        values  ( ?, ?, ?) ";

            #endregion

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(3, out arrParams);

            try
            {
                arrParams[0].Value = unitItemRelation.m_strAPPLICATION_ID_CHR;
                arrParams[1].Value = unitItemRelation.m_strCHECK_ITEM_ID_CHR;
                arrParams[2].Value = unitItemRelation.m_strAPPLY_UNIT_ID_CHR;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParams);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 设置打印状态
        /// </summary>
        /// <param name="arrApplicationId"></param>
        /// <param name="isPrinted"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetApplPrintedStatus(string[] arrApplicationId, bool isPrinted)
        {
            //            long lngRes=0;

            //            StringBuilder sb=new StringBuilder();
            //            int len= arrApplicationId.Length;

            //            for (int i = 0; i <len; i++)
            //            {
            //                if (i != len - 1)
            //                {
            //                    sb.Append(arrApplicationId[i] + " ,");
            //                }
            //                else 
            //                {
            //                    sb.Append(arrApplicationId[i]);
            //                }
            //            }

            //            string sqlFormat = @"  update t_opr_lis_application
            //                                      set printed_num = {0}
            //                                    where pstatus_int = 2
            //                                      and application_id_chr in ( {1} ) ";

            //            clsHRPTableService dbSvc = new clsHRPTableService();

            //            try
            //            {
            //                lngRes = dbSvc.DoExcute(string.Format(sqlFormat, isPrinted ? "1" : "0", sb.ToString()));
            //            }
            //            catch (Exception ex)
            //            {
            //                lngRes = 0;
            //                new clsLogText().LogError(ex.Message);
            //            }

            //            return lngRes;

            long lngRes = 1;
            int n = -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                n = 0;
                if (isPrinted)
                {

                    string strSQL = @"update t_opr_lis_application
   set printed_num = 1, printed_date = sysdate
 where pstatus_int > 0
   and application_id_chr = ?";

                    DbType[] dbTypes = new DbType[] { 
                       DbType.String
                        };
                    object[][] objValues = new object[1][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[arrApplicationId.Length];//初始化
                    }
                    for (int k1 = 0; k1 < arrApplicationId.Length; k1++)
                    {
                        n = -1;
                        objValues[++n][k1] = arrApplicationId[k1].Trim();
                    }
                    if (arrApplicationId.Length > 0)
                    {
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    }


                    //                     strSQL = @"  
                    //                            update t_opr_lis_application
                    //                                     set printed_num = 1
                    //                                     where pstatus_int = 2
                    //                                     and application_id_chr =? ";

                    //                    dbTypes = new DbType[] { 
                    //                        DbType.String

                    //                        };
                    //                    objValues = new object[1][];
                    //                    for (int j = 0; j < objValues.Length; j++)
                    //                    {
                    //                        objValues[j] = new object[arrApplicationId.Length];//初始化
                    //                    }
                    //                    for (int k1 = 0; k1 < arrApplicationId.Length; k1++)
                    //                    {
                    //                        n = -1;
                    //                        objValues[++n][k1] = arrApplicationId[k1].Trim();
                    //                    }
                    //                    if (arrApplicationId.Length > 0)
                    //                    {
                    //                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    //                    }
                }
                else
                {
                    string strSQL = @"  
                            update t_opr_lis_application
                                     set PRINTED_DATE = null,printed_num = 0
                                     where pstatus_int = 2
                                     and application_id_chr =? ";

                    DbType[] dbTypes = new DbType[] { 
                       DbType.String
                        };
                    object[][] objValues = new object[1][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[arrApplicationId.Length];//初始化
                    }
                    for (int k1 = 0; k1 < arrApplicationId.Length; k1++)
                    {
                        n = -1;
                        objValues[++n][k1] = arrApplicationId[k1].Trim();
                    }
                    if (arrApplicationId.Length > 0)
                    {
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    }



                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }

        private bool IsNullOrEmptyOrSpace(string value)
        {
            if (value == null)
            {
                return true;
            }
            return string.IsNullOrEmpty(value.Trim());
        }

        /// <summary>
        /// 根据医嘱ID获得检验申请单主要信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="applMain"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplVO(string orderId, out clsLisApplMainVO applMain)
        {
            long lngRes = 0;
            applMain = null;

            string sql = @"select a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
                                  a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
                                  a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
                                  a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
                                  a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
                                  a.pstatus_int, a.emergency_int, a.special_int, a.form_int,
                                  a.patient_inhospitalno_chr, a.sample_type_id_chr, a.check_content_vchr,
                                  a.sample_type_vchr, a.oringin_dat, a.charge_info_vchr, a.printed_num,
                                  a.orderunitrelation_vchr, a.printed_date, b.sample_id_chr
                             from t_opr_lis_application a, t_opr_lis_sample b
                            where a.application_id_chr = b.application_id_chr(+)
                              and a.orderunitrelation_vchr like ?
                              and b.status_int > 0";

            try
            {
                DataTable dtbResult = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = "%" + orderId + "%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql, ref dtbResult, objParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null)
                {
                    if (dtbResult.Rows.Count == 0)
                    {
                        // throw new Exception(string.Format("未找到医嘱Id{0}对应的申请单!", orderId));
                    }
                    else if (dtbResult.Rows.Count == 1)
                    {
                        applMain = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[0]);
                    }
                    else
                    {
                        throw new Exception(string.Format("医嘱Id为{0}对应的不只一个申请单!", orderId));
                    }
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex.Message);
                throw ex;
            }

            return lngRes;
        }
    }
}