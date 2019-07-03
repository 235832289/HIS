using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Security.Principal;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; 
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 生成、修改、删除申请单Svc
    /// </summary>
    public class clsApplicationBizSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 增加一组新的检验申请信息


        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewApplication(clsLisApplMainVO p_objLisApplMainVO,out clsLisApplMainVO p_objLisApplMainOutVO,
                                           clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                           clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                           clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;

            p_objLisApplMainOutVO = p_objLisApplMainVO;

            try
            {
                if (p_objLisApplMainVO == null)
                {
                    throw new Exception("申请单信息为空!生成失败!");
                }


                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objLisApplMainVO, out p_objLisApplMainOutVO);
                
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord( p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup( p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem( p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint( p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr( p_objAppUnitItemArr);
                }
                if (lngRes <= 0)
                {
                    throw new Exception("生成申请单失败!");
                }
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }
        #endregion

        #region 增加一组新的检验申请信息(跳过采集和核收)

        /// <summary>
        /// 增加一组新的检验申请信息(跳过采集和核收)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objLisApplMainOutVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfoWithBarcode(IPrincipal p_objPrincipal, clsLisApplMainVO p_objLisApplMainVO,
                                                           out clsLisApplMainVO p_objLisApplMainOutVO, clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                                           clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr, clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                                           clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr, clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;

            if (p_objLisApplMainVO == null)
            {
                throw new Exception("检验申请单信息为空!");
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objLisApplMainVO, out p_objLisApplMainOutVO);

                p_objLisApplMainVO = p_objLisApplMainOutVO;

                #region 赋申请单ID

                if (lngRes > 0)
                {
                   

                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }

                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }

                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }

                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }

                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }

                }

                #endregion

                #region 生成报告单、样本组、检验项目表信息

                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objAppUnitItemArr);
                } 

                #endregion

                if (lngRes > 0)
                {
                    //自动生成barcode号

                    clsHRPTableService objHRPSvc = new clsHRPTableService();
                    string strSQL = @"select seq_lis_barcode.NEXTVAL from dual";
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

                    clsT_OPR_LIS_SAMPLE_VO objSampleVO = ConstructSampleVO(p_objLisApplMainVO, strBarcode);

                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(p_objPrincipal,objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                }

                if (lngRes <= 0)
                {
                    throw new Exception("生成申请单失败!");
                }

            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }

        private clsT_OPR_LIS_SAMPLE_VO ConstructSampleVO(clsLisApplMainVO p_objLisApplMainVO, string strBarcode)
        {
            clsT_OPR_LIS_SAMPLE_VO sampleVO = new clsT_OPR_LIS_SAMPLE_VO();

            sampleVO.m_strAPPL_DAT = p_objLisApplMainVO.m_strAppl_Dat;
            sampleVO.m_strSEX_CHR = p_objLisApplMainVO.m_strSex;
            sampleVO.m_strPATIENT_NAME_VCHR = p_objLisApplMainVO.m_strPatient_Name;
            sampleVO.m_strPATIENT_SUBNO_CHR = p_objLisApplMainVO.m_strPatient_SubNO;
            sampleVO.m_strAGE_CHR = p_objLisApplMainVO.m_strAge;
            sampleVO.m_strPATIENT_TYPE_CHR = p_objLisApplMainVO.m_strPatientType;
            sampleVO.m_strDIAGNOSE_VCHR = p_objLisApplMainVO.m_strDiagnose;
            sampleVO.m_strBEDNO_CHR = p_objLisApplMainVO.m_strBedNO;
            sampleVO.m_strICD_VCHR = p_objLisApplMainVO.m_strICD;
            sampleVO.m_strPATIENTCARDID_CHR = p_objLisApplMainVO.m_strPatientcardID;
            sampleVO.m_strPATIENTID_CHR = p_objLisApplMainVO.m_strPatientID;
            sampleVO.m_strAPPL_EMPID_CHR = p_objLisApplMainVO.m_strAppl_EmpID;
            sampleVO.m_strAPPL_DEPTID_CHR = p_objLisApplMainVO.m_strAppl_DeptID;
            sampleVO.m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
            sampleVO.m_strPATIENT_INHOSPITALNO_CHR = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
            sampleVO.m_strSAMPLE_TYPE_ID_CHR = p_objLisApplMainVO.m_strSampleTypeID;
            sampleVO.m_strSAMPLETYPE_VCHR = p_objLisApplMainVO.m_strSampleType;
            sampleVO.m_intSTATUS_INT = 3;
            sampleVO.m_strQCSAMPLEID_CHR = "-1";
            sampleVO.m_strSAMPLEKIND_CHR = "1";
            sampleVO.m_strSAMPLE_ID_CHR = null;
            sampleVO.m_strSAMPLESTATE_VCHR = "";
            sampleVO.m_strBARCODE_VCHR = strBarcode;
            sampleVO.m_strOPERATOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;
            sampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sampleVO.m_strCOLLECTOR_ID_CHR = null;
            sampleVO.m_strACCEPTOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;
            sampleVO.m_strACCEPT_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return sampleVO;
        }

        #endregion

        #region 新增检验申请单

        /// <summary>
        /// 增加新的检验申请记录(修改,删除时都为新增记录)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objLisApplMainOutVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppl(clsLisApplMainVO applMainVO,out clsLisApplMainVO applMainResult)
        {

            #region SQL

            string sql = @"insert into t_opr_lis_application
                                      (
                                       application_id_chr,
                                       modify_dat,
                                       patientid_chr,
                                       application_dat,
                                       sex_chr,
                                       patient_name_vchr,
                                       patient_subno_chr,
                                       age_chr,
                                       patient_type_id_chr,
                                       diagnose_vchr,
                                       bedno_chr,
                                       icdcode_chr,
                                       patientcardid_chr,
                                       application_form_no_chr,
                                       operator_id_chr,
                                       appl_empid_chr,
                                       appl_deptid_chr,
                                       summary_vchr,
                                       pstatus_int,
                                       emergency_int,
                                       special_int,
                                       form_int,
                                       patient_inhospitalno_chr,
                                       sample_type_id_chr,
                                       sample_type_vchr,
                                       check_content_vchr,
                                       oringin_dat,
                                       charge_info_vchr,
                                       orderunitrelation_vchr )
									   values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, ?)";

            #endregion

            long lngRes = 0;
            applMainResult = applMainVO;

            try
            {
                IDataParameter[] arrLisAppl = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DateTime CurTime = DateTime.Now;

                objHRPSvc.CreateDatabaseParameter(29, out arrLisAppl);
                
                if (!string.IsNullOrEmpty(applMainVO.m_strMODIFY_DAT))
                {
                    try
                    {
                        DateTime dtmPreModify = DateTime.Parse(applMainVO.m_strMODIFY_DAT);
                        TimeSpan ts = CurTime - dtmPreModify;

                        if (ts.TotalMilliseconds < 1000)
                        {
                            CurTime = CurTime.AddSeconds(1f);
                        }
                    }
                    catch { }
                }

                if (!string.IsNullOrEmpty(applMainVO.m_strAPPLICATION_ID))
                {
                    string strNewApplID = null;
                    objHRPSvc.m_lngGenerateNewID("t_opr_lis_application", "APPLICATION_ID_CHR", out strNewApplID);
                    
                    if (strNewApplID == null || strNewApplID == "")
                    {
                        throw new Exception("不能分配申请单ID");
                    }

                    applMainVO.m_strAPPLICATION_ID = strNewApplID;
                }


                arrLisAppl[0].Value = applMainVO.m_strAPPLICATION_ID;
                applMainVO.m_strMODIFY_DAT = CurTime.ToString("yyyy-MM-dd HH:mm:ss");

                arrLisAppl[1].Value = CurTime;

                if (string.IsNullOrEmpty(applMainVO.m_strPatientID))
                {
                    applMainVO.m_strPatientID = "-1";
                }
                arrLisAppl[2].Value = applMainVO.m_strPatientID;

                if (Microsoft.VisualBasic.Information.IsDate(applMainVO.m_strAppl_Dat))
                {
                    arrLisAppl[3].Value = DateTime.Parse(applMainVO.m_strAppl_Dat);
                }
                else
                {
                    applMainVO.m_strAppl_Dat = null;
                }

                arrLisAppl[4].Value = applMainVO.m_strSex;
                arrLisAppl[5].Value = applMainVO.m_strPatient_Name;
                arrLisAppl[6].Value = applMainVO.m_strPatient_SubNO;
                arrLisAppl[7].Value = applMainVO.m_strAge;
                arrLisAppl[8].Value = applMainVO.m_strPatientType;
                arrLisAppl[9].Value = applMainVO.m_strDiagnose;
                arrLisAppl[10].Value = applMainVO.m_strBedNO;
                arrLisAppl[11].Value = applMainVO.m_strICD;

                if (string.IsNullOrEmpty(applMainVO.m_strPatientcardID))
                {
                    arrLisAppl[12].Value = System.DBNull.Value;
                }
                else
                {
                    arrLisAppl[12].Value = applMainVO.m_strPatientcardID;
                }

                arrLisAppl[13].Value = applMainVO.m_strApplication_Form_NO;

                arrLisAppl[14].Value = applMainVO.m_strOperator_ID;
                arrLisAppl[15].Value = applMainVO.m_strAppl_EmpID;
                arrLisAppl[16].Value = applMainVO.m_strAppl_DeptID;
                arrLisAppl[17].Value = applMainVO.m_strSummary;
                arrLisAppl[18].Value = applMainVO.m_intPStatus_int;
                arrLisAppl[19].Value = applMainVO.m_intEmergency;
                arrLisAppl[20].Value = applMainVO.m_intSpecial;
                arrLisAppl[21].Value = applMainVO.m_intForm_int;
                arrLisAppl[22].Value = applMainVO.m_strPatient_inhospitalno_chr;
                arrLisAppl[23].Value = applMainVO.m_strSampleTypeID;
                arrLisAppl[24].Value = applMainVO.m_strSampleType;
                arrLisAppl[25].Value = applMainVO.m_strCheckContent;
                try
                {
                    DateTime.Parse(applMainVO.m_strOriginDate);
                }
                catch
                {
                    applMainVO.m_strOriginDate = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                arrLisAppl[26].Value = DateTime.Parse(applMainVO.m_strOriginDate);
                arrLisAppl[27].Value = applMainVO.m_strChargeInfo;
                arrLisAppl[28].Value = applMainVO.m_strOrderunitrelation;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngRecEff, arrLisAppl);

                if (lngRes<=0)
                {
                    throw new Exception("添加申请单错误!");
                }

                objHRPSvc.Dispose();

            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
                throw ex;
            }

            return lngRes;
        }

        #endregion

        #region 添加检验相关记录


        #region 新增申请单下标本组要做的检验项目


        /// <summary>
        /// 为表 T_OPR_LIS_APP_CHECK_ITEM 新增记录时用 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppCheckItem(clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            long lngReff=0;
            string message = string.Empty;

            #region sql

            string sql = @"insert into t_opr_lis_app_check_item ( 
                                                                    check_item_id_chr,
                                                                    sample_group_id_chr,
                                                                    report_group_id_chr,
                                                                    application_id_chr
                                                                )
                                                         values (?,?,?,?) ";

            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] arrParams = null;

                bool isNull = p_objRecordVOArr == null || p_objRecordVOArr.Length == 0;
                if (isNull)
                {
                    message = "新增申请单下标本组要做的检验项目失败!";
                    throw new Exception(message);
                }

                #region 赋 值


                for (int i = 0; i < p_objRecordVOArr.Length; i++)
                {
                    clsT_OPR_LIS_APP_CHECK_ITEM_VO checkItemVO = p_objRecordVOArr[i];
                    if (checkItemVO != null)
                    {
                        lngRes = 0;
                        objHRPSvc.CreateDatabaseParameter(4, out arrParams);

                        arrParams[0].Value = checkItemVO.m_strCHECK_ITEM_ID_CHR;
                        arrParams[1].Value = checkItemVO.m_strSAMPLE_GROUP_ID_CHR;
                        arrParams[2].Value = checkItemVO.m_strREPORT_GROUP_ID_CHR;
                        arrParams[3].Value = checkItemVO.m_strAPPLICATION_ID_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParams);
                    }
                }

                #endregion

                objHRPSvc.Dispose();
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }

        #endregion

        #region 新增申请单下要做的标本组

        /// <summary>
        /// T_OPR_LIS_APP_SAMPLE 新增
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppSampleGroup(clsT_OPR_LIS_APP_SAMPLE_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            long lngReff = 0;
            string sql = @" insert into t_opr_lis_app_sample (
                                                              application_id_chr,
                                                              sample_group_id_chr,
                                                              report_group_id_chr,
                                                              sample_id_chr
                                                             ) 
                                                      values (?,?,?,?) ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                bool isNull = p_objRecordVOArr == null || p_objRecordVOArr.Length == 0;
                if (isNull)
                {
                    throw new Exception(string.Format("要生成的申请单下要做的标本组为空!{0}", clsTip.ErrorMessageTip));
                }

                #region 循环赋值


                for (int i = 0; i < p_objRecordVOArr.Length; i++)
                {
                    clsT_OPR_LIS_APP_SAMPLE_VO sampleVO = p_objRecordVOArr[i];
                    if (sampleVO != null)
                    {
                        lngRes = 0;
                        IDataParameter[] arrParams = null;
                        objHRPSvc.CreateDatabaseParameter(4, out arrParams);

                        arrParams[0].Value = sampleVO.m_strAPPLICATION_ID_CHR;
                        arrParams[1].Value = sampleVO.m_strSAMPLE_GROUP_ID_CHR;
                        arrParams[2].Value = sampleVO.m_strREPORT_GROUP_ID_CHR;
                        arrParams[3].Value = sampleVO.m_strSAMPLE_ID_CHR;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParams);
                    }
                } 

                #endregion

                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 添加申请单与申请单元的关系


        /// <summary>
        /// 为表 T_OPR_LIS_APP_APPLY_UNIT 新增记录时用 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppApplyUint(clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrRecodes)
        {
            long lngRes = 0;
            long lngReff = 0;

            bool isNull = arrRecodes == null || arrRecodes.Length == 0;
            if (isNull)
            {
                throw new Exception("生成申请单与申请单元的关系失败!");
            }

            #region == SQL ==
            string sql = @" insert into t_opr_lis_app_apply_unit (
                                                                  application_id_chr, 
                                                                  user_group_string, 
                                                                  apply_unit_id_chr
                                                                 )
                                                          values (?, ?, ?) "; 
            #endregion

            try
            {
                clsHRPTableService dbSvc = new clsHRPTableService();

                #region 循环赋值


                for (int i = 0; i < arrRecodes.Length; i++)
                {
                    clsT_OPR_LIS_APP_APPLY_UNIT_VO applyUnitVO = arrRecodes[i];
                    if (applyUnitVO != null)
                    {
                        lngRes = 0;
                        IDataParameter[] arrParms = null;
                        dbSvc.CreateDatabaseParameter(3, out arrParms);
                        arrParms[0].Value = applyUnitVO.m_strAPPLICATION_ID_CHR;
                        arrParms[1].Value = applyUnitVO.m_strUSER_GROUP_STRING;
                        arrParms[2].Value = applyUnitVO.m_strAPPLY_UNIT_ID_CHR;

                        lngRes = dbSvc.lngExecuteParameterSQL(sql, ref lngReff, arrParms);
                    }
                } 

                #endregion

                dbSvc.Dispose();
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }
        
        #endregion

        #region 添加一批记录到申请单申请单元项目表

        /// <summary>
        /// 添加申请单的申请单元项目表

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppUintItemArr(clsLisAppUnitItemVO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            long lngRess = 0;

            try
            {
                bool isNull = p_objRecordVOArr == null || p_objRecordVOArr.Length == 0;
                if (isNull)
                {
                    throw new Exception("添加申请单元项目表失败!");
                }

                for (int i = 0; i < p_objRecordVOArr.Length; i++)
                {
                    if (p_objRecordVOArr[i] != null)
                    {
                        lngRes = 0;
                        lngRes = m_lngAddNewAppUnitItem(p_objRecordVOArr[i]);
                        if (lngRes <= 0)
                        {
                            throw new Exception("添加申请单元项目表失败!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }
        
        #endregion

        #region 添加检验报告组信息

        /// <summary>
        /// t_opr_lis_app_report 新增,修改,删除
        /// </summary>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngInsertAppReportRecord(clsT_OPR_LIS_APP_REPORT_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            long lngReff = 0;

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_opr_lis_app_report (application_id_chr,
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
                                                                xml_annotation_vchr)
                                                        values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                bool isNull = p_objRecordVOArr != null || p_objRecordVOArr.Length == 0;
                if (isNull)
                {
                    string errorMessage = "申请单下的报告单信息为空!";
                    throw new Exception(errorMessage);
                }

                for (int i = 0; i < p_objRecordVOArr.Length; i++)
                {
                    if (p_objRecordVOArr[i] != null)
                    {
                        IDataParameter[] objDPArr = null;
                        objHRPSvc.CreateDatabaseParameter(13, out objDPArr);

                        objDPArr[0].Value = p_objRecordVOArr[i].m_strAPPLICATION_ID_CHR;
                        objDPArr[1].Value = p_objRecordVOArr[i].m_strREPORT_GROUP_ID_CHR;
                        objDPArr[2].Value = DateTime.Parse(p_objRecordVOArr[i].m_strMODIFY_DAT);
                        objDPArr[3].Value = p_objRecordVOArr[i].m_strSUMMARY_VCHR;
                        objDPArr[4].Value = p_objRecordVOArr[i].m_strOPERATOR_ID_CHR;
                        objDPArr[5].Value = p_objRecordVOArr[i].m_intSTATUS_INT;
                        if (Microsoft.VisualBasic.Information.IsDate(p_objRecordVOArr[i].m_strREPORT_DAT))
                        {
                            objDPArr[6].Value = DateTime.Parse(p_objRecordVOArr[i].m_strREPORT_DAT);
                        }
                        else
                        {
                            p_objRecordVOArr[i].m_strREPORT_DAT = null;
                        }

                        objDPArr[7].Value = p_objRecordVOArr[i].m_strREPORTOR_ID_CHR;

                        if (Microsoft.VisualBasic.Information.IsDate(p_objRecordVOArr[i].m_strCONFIRM_DAT))
                        {
                            objDPArr[8].Value = DateTime.Parse(p_objRecordVOArr[i].m_strCONFIRM_DAT);
                        }
                        else
                        {
                            p_objRecordVOArr[i].m_strCONFIRM_DAT = null;
                        }
                        objDPArr[9].Value = p_objRecordVOArr[i].m_strCONFIRMER_ID_CHR;
                        objDPArr[10].Value = p_objRecordVOArr[i].m_strXML_SUMMARY_VCHR;
                        objDPArr[11].Value = p_objRecordVOArr[i].m_strANNOTATION_VCHR;
                        objDPArr[12].Value = p_objRecordVOArr[i].m_strXML_ANNOTATION_VCHR;

                        p_objRecordVOArr[i].m_strMODIFY_DAT = strNow;

                        lngRes = 0;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngReff, objDPArr);
                        if (lngRes < 0)
                        {
                            throw new Exception("保存报告单失败.");
                        }
                        objHRPSvc.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            return lngRes;
        }

        #endregion

        #region 添加申请单申请单元项目表

        /// <summary>
        /// 添加一条记录到申请单申请单元项目表
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngAddNewAppUnitItem(clsLisAppUnitItemVO p_objRecord)
        {
            long lngRes = 0;
            long lngReff = 0;
            clsHRPTableService dbSvc = new clsHRPTableService();

            #region == SQL ==
            string sql = @"insert into t_opr_lis_app_unit_item (
                                                                application_id_chr,
                                                                check_item_id_chr, 
                                                                apply_unit_id_chr
                                                               )
                                                         values(?, ?, ?) ";
            #endregion

            try
            {
                IDataParameter[] objLisAddItemRefArr = null;
                dbSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);

                objLisAddItemRefArr[0].Value = p_objRecord.m_strAPPLICATION_ID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strCHECK_ITEM_ID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strAPPLY_UNIT_ID_CHR;

                //往表增加记录

                lngRes = dbSvc.lngExecuteParameterSQL(sql, ref lngReff, objLisAddItemRefArr);
                dbSvc.Dispose();
            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }

            return lngRes;
        }
        
        #endregion

        #endregion

        #region 修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息) 刘彬 2004.06.30

        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAppInfo(clsLisApplMainVO p_objLisApplMainVO, clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                       clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr, clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                       clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr, clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;

            if (p_objLisApplMainVO == null) 
            {
                return -2;
            }
                
            string strSQL = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;

                strSQL = "DELETE FROM t_opr_lis_app_unit_item  WHERE application_id_chr = ?";

                lngRes = 0;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr1 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr1);
                    objDPArr1[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;

                    strSQL = "DELETE FROM t_opr_lis_app_check_item  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr1);

                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr2);
                    objDPArr2[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_sample  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr2);

                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr3 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr3);
                    objDPArr3[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_report  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr3);
                    objHRPSvc.Dispose();
                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr4 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr4);
                    objDPArr4[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_apply_unit WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr4);
                    objHRPSvc.Dispose();
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    com.digitalwave.iCare.ValueObject.clsLisApplMainVO objLisApplMainVO;
                    lngRes = m_lngAddNewApplication(p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
                }

                if (lngRes <= 0)
                {
                    throw new Exception("修改申请信息失败.");
                }

            }
            catch (Exception ex)
            {
                ThrowException(ex);
            }
            return lngRes;
        }

        #endregion

        private void ThrowException(Exception ex)
        {
            new clsLogText().LogError(ex.Message);
            Exception e = new Exception(ex.Message + clsTip.ErrorMessageTip);
            throw e;
        }
      
    }
}
