using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Security.Principal;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQueryApplicationSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {


        #region  根据员工工号查询员工信息
        [AutoComplete]
        public long m_lngFindEmpMsgByEmpNO(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpNO, out string strEmpID, out string strEmpPwd)
        {
            strEmpID = "";
            strEmpPwd = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngFindEmpMsgByEmpNO");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select t1.empid_chr,t1.psw_chr from t_bse_Employee t1 where t1.empno_chr = '" + p_strEmpNO + "'";
            DataTable dtResult = new DataTable();
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                if (dtResult != null)
                {
                    strEmpID = dtResult.Rows[0]["empid_chr"].ToString();
                    strEmpPwd = dtResult.Rows[0]["psw_chr"].ToString();
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
        #endregion

        #region 联合查询（包括病人住院号）申请单信息
        /// <summary>
        /// 联合查询（包括病人住院号）申请单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSchVO"></param>
        /// <param name="p_strInHospitalNO">承载联合查询条件的VO,其中值为NULL的成员会被必忽略</param>
        /// <param name="p_objAppVOArr">返回的承载申请单信息的数组</param>
        /// <returns>0:失败;1:成功</returns>
        [AutoComplete]
        public long m_lngGetAppInfoByConditionAndInHospitalNO(System.Security.Principal.IPrincipal p_objPrincipal,
            clsLISApplicationSchVO p_objSchVO, string p_strInHospitalNO,
            out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppInfoByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"select * from (SELECT  DISTINCT t2.*,
											t1.REPORT_GROUP_ID_CHR REPORT_GROUP_ID_CHR_Report,
											t1.MODIFY_DAT MODIFY_DAT_Report,											
											t1.OPERATOR_ID_CHR OPERATOR_ID_CHR_Report,
											t1.STATUS_INT STATUS_INT_Report,
											t1.REPORT_DAT REPORT_DAT_Report,
											t1.REPORTOR_ID_CHR REPORTOR_ID_CHR_Report,
											t1.CONFIRM_DAT CONFIRM_DAT_Report,
											t1.CONFIRMER_ID_CHR CONFIRMER_ID_CHR_Report
								FROM t_opr_lis_app_report t1,
									t_opr_lis_application t2,
									t_opr_lis_app_sample t3,
									t_opr_lis_sample t4       
								WHERE t1.application_id_chr = t2.application_id_chr
								AND t2.pstatus_int + 0 = 2
								AND t3.application_id_chr = t1.application_id_chr
								AND t3.report_group_id_chr = t1.report_group_id_chr 
								AND t3.sample_id_chr = t4.sample_id_chr
								AND t4.status_int = 3";

            string strSQL_ConfirmState = " AND t1.status_int = ? ";
            string strSQL_ConfirmStateAll = " AND t1.status_int > ?";
            string strSQL_FromDate = " AND t4.accept_dat >= ? ";
            string strSQL_ToDate = " AND t4.accept_dat <= ? ";
            string strSQL_PatientName = " AND Trim(t2.patient_name_vchr) LIKE ? ";
            string strSQL_BarCode = " AND t4.barcode_vchr = ? ";
            string strSQL_SampleGroupID = @" AND t2.application_id_chr IN (
													SELECT DISTINCT tt1.application_id_chr
																FROM t_opr_lis_app_sample tt1
																WHERE tt1.sample_group_id_chr IN
																					(*))";

            string strSQL_FromDateApp = " AND t4.appl_dat >= ? ";
            string strSQL_ToDateApp = " AND t4.appl_dat <= ? ";
            string strSQL_InhospNO = " AND Trim(t2.patient_inhospitalno_chr) = ? ";
            string strSQL_BedNO = " AND Trim(t2.bedno_chr) = ? ";
            string strSQL_AppDept = " AND Trim(t2.appl_deptid_chr) = ? ";
            string strSQL_AppDoct = " AND Trim(t2.appl_empid_chr) = ? ";
            string strSQL_AppID = " AND t2.application_id_chr = ?";
            string strSQL_PatientID = " AND t2.patientid_chr = ?";
            string strSQL_InHospitalNO = " AND trim(t2.patient_inhospitalno_chr) = ?";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造
            if (p_objSchVO.m_strApplicationID != null)
            {
                arlSQL.Add(strSQL_AppID);
                arlParm.Add(p_objSchVO.m_strApplicationID);
            }
            if (p_objSchVO.m_strPatientID != null)
            {
                arlSQL.Add(strSQL_PatientID);
                arlParm.Add(p_objSchVO.m_strPatientID);
            }
            if (p_objSchVO.m_strConfirmState == "1")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(1);
            }
            else if (p_objSchVO.m_strConfirmState == "2")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(2);
            }
            else if (p_objSchVO.m_strConfirmState == "0")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(0);
            }
            else
            {
                arlSQL.Add(strSQL_ConfirmStateAll);
                arlParm.Add(0);
            }
            if (p_objSchVO.m_strConfirmedDateBegin != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateBegin.Trim()))
            {
                arlSQL.Add(strSQL_FromDate);
                arlParm.Add(DateTime.Parse(p_objSchVO.m_strConfirmedDateBegin.Trim()));
            }
            if (p_objSchVO.m_strConfirmedDateEnd != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateEnd.Trim()))
            {
                arlSQL.Add(strSQL_ToDate);
                arlParm.Add(DateTime.Parse(p_objSchVO.m_strConfirmedDateEnd.Trim()));
            }
            if (p_objSchVO.m_strSampleGroupIDArr != null && p_objSchVO.m_strSampleGroupIDArr.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < p_objSchVO.m_strSampleGroupIDArr.Length; i++)
                {
                    sb.Append("?,");
                }
                sb.Remove(sb.Length - 1, 1);
                string strReplace = sb.ToString();
                strSQL_SampleGroupID = strSQL_SampleGroupID.Replace("*", strReplace);
                arlSQL.Add(strSQL_SampleGroupID);
                arlParm.AddRange(p_objSchVO.m_strSampleGroupIDArr);
            }
            if (p_objSchVO.m_strPatientName != null && p_objSchVO.m_strPatientName.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add("%" + p_objSchVO.m_strPatientName.Trim() + "%");
            }
            if (p_objSchVO.m_strBarCode != null && p_objSchVO.m_strBarCode.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BarCode);
                arlParm.Add(p_objSchVO.m_strBarCode.Trim());
            }


            if (p_objSchVO.m_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strFromDatApp.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                arlParm.Add(DateTime.Parse(p_objSchVO.m_strFromDatApp.Trim()));
            }
            if (p_objSchVO.m_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strToDatApp.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                arlParm.Add(DateTime.Parse(p_objSchVO.m_strToDatApp.Trim()));
            }
            if (p_objSchVO.m_strInhospNO != null && p_objSchVO.m_strInhospNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_InhospNO);
                arlParm.Add(p_objSchVO.m_strInhospNO.Trim());
            }
            if (p_objSchVO.m_strBedNO != null && p_objSchVO.m_strBedNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BedNO);
                arlParm.Add(p_objSchVO.m_strBedNO.Trim());
            }
            if (p_objSchVO.m_strAppDept != null && p_objSchVO.m_strAppDept.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(p_objSchVO.m_strAppDept.Trim());
            }
            if (p_objSchVO.m_strAppDoct != null && p_objSchVO.m_strAppDoct.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDoct);
                arlParm.Add(p_objSchVO.m_strAppDoct.Trim());
            }
            if (p_strInHospitalNO != null && p_strInHospitalNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_InHospitalNO);
                arlParm.Add(p_strInHospitalNO.Trim());
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }
            strSQL += ") order by accept_dat";

            int intParmCount = arlParm.Count;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

            for (int i = 0; i < intParmCount; i++)
            {
                objDPArr[i].Value = arlParm[i];
            }

            try
            {
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    System.Collections.ArrayList arlApp = new ArrayList();
                    //					System.Data.DataRow[] dtrResultArr = dtbResult.Select("","application_id_chr");
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
                        objMainVO.m_strReportGroupID = dtbResult.Rows[i]["REPORT_GROUP_ID_CHR_Report"].ToString().Trim();
                        objMainVO.m_strReportDate = dtbResult.Rows[i]["CONFIRM_DAT_Report"].ToString().Trim();
                        objMainVO.m_intReportStatus = int.Parse(dtbResult.Rows[i]["status_int_Report"].ToString().Trim());
                        objMainVO.m_strOriginDate = dtbResult.Rows[i]["oringin_dat"].ToString().Trim();
                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_objAppVOArr = null;
            }
            return lngRes;
        }
        #endregion

        #region	根据申请单取得对应样本的采样说明
        /// <summary>
        /// 根据申请单取得对应样本的采样说明
        /// </summary>
        /// <param name="p_Principal"></param>
        /// <param name="p_ApplicationID"></param>
        /// <param name="p_objSampleGroupVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleRemark(System.Security.Principal.IPrincipal p_Principal, string p_ApplicationID, out clsSampleGroup_VO[] p_objSampleGroupVOArr)
        {
            p_objSampleGroupVOArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            objPrivilege.m_lngCheckCallPrivilege(p_Principal, "clsApplicationSvc", "m_lngGetSampleRemark");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.sample_group_id_chr, a.py_code_chr, a.wb_code_chr,
                                   a.assist_code01_chr, a.assist_code02_chr, a.is_hand_work_int,
                                   a.device_model_id_chr, a.remark_vchr, a.check_category_id_chr,
                                   a.sample_type_id_chr, a.sample_group_name_chr, a.print_title_vchr,
                                   a.print_seq_int
								FROM t_aid_lis_sample_group a, t_opr_lis_app_sample b
								WHERE a.sample_group_id_chr = b.sample_group_id_chr
								AND b.application_id_chr = '" + p_ApplicationID + "'";

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes <= 0)
                {
                    return -1;
                }

                p_objSampleGroupVOArr = new clsSampleGroup_VO[dtbResult.Rows.Count];
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    p_objSampleGroupVOArr[i] = new clsSampleGroup_VO();
                    p_objSampleGroupVOArr[i].strSampleGroupID = dtbResult.Rows[i]["SAMPLE_GROUP_ID_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strPYCode = dtbResult.Rows[i]["PY_CODE_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strWBCode = dtbResult.Rows[i]["WB_CODE_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strAssistCode01 = dtbResult.Rows[i]["ASSIST_CODE01_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strAssistCode02 = dtbResult.Rows[i]["ASSIST_CODE02_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strIsHandWork = dtbResult.Rows[i]["IS_HAND_WORK_INT"].ToString();
                    p_objSampleGroupVOArr[i].strDeviceModelName = dtbResult.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strRemark = dtbResult.Rows[i]["REMARK_VCHR"].ToString();
                    p_objSampleGroupVOArr[i].strCheckCategoryID = dtbResult.Rows[i]["CHECK_CATEGORY_ID_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strSampleTypeID = dtbResult.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strSampleGroupName = dtbResult.Rows[i]["SAMPLE_GROUP_NAME_CHR"].ToString();
                    p_objSampleGroupVOArr[i].strPRINT_TITLE_VCHR = dtbResult.Rows[i]["PRINT_TITLE_VCHR"].ToString();
                    if (dtbResult.Rows[i]["PRINT_SEQ_INT"] != null && dtbResult.Rows[i]["PRINT_SEQ_INT"].ToString() != "")
                    {
                        p_objSampleGroupVOArr[i].intPRINT_SEQ_INT = int.Parse(dtbResult.Rows[i]["PRINT_SEQ_INT"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 获取配置信息
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="blIS"></param>
        /// <param name="strsetid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCollocate(System.Security.Principal.IPrincipal p_objPrincipal, out bool blIS, string strsetid)
        {
            long lngRes = 0;
            blIS = false;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetCollocate");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select SETSTATUS_INT from t_sys_setting where  setid_chr='" + strsetid + "'";
            DataTable dt = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString()) == 1)
            {
                blIS = true;
            }
            return lngRes;
        }
        #endregion

        #region 获取配置信息(重载)
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="blIS"></param>
        /// <param name="strsetid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCollocate(System.Security.Principal.IPrincipal p_objPrincipal, out string strFlag, string strsetid)
        {
            long lngRes = 0;
            strFlag = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetCollocate");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select SETSTATUS_INT from t_sys_setting where  setid_chr='" + strsetid + "'";
            DataTable dt = new DataTable();
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0 && dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "")
            {
                strFlag = dt.Rows[0]["SETSTATUS_INT"].ToString().Trim();
            }
            return lngRes;
        }
        #endregion

        //PIS

        #region 根据体检号和体检组合项目ID查询PIS申请报告单

        /// <summary>
        /// 根据体检号和体检组合项目ID查询PIS申请报告单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strExamineID"></param>
        /// <param name="p_strItemGroupID"></param>
        /// <param name="p_objApplyReportArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindApplyReportArrByExamineIDItemGroupID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strExamineID, string p_strItemGroupID, out clsLisApplyReportInfo_VO[] p_objApplyReportArr)
        {
            long lngRes = 0;
            p_objApplyReportArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc"
                , "m_lngFindApplyReportArrByExamineIDItemGroupID");
            if (lngRes <= 0)
            {
                return -1;
            }

            #region SQL

            string strSQL = @"SELECT a.*, f.collector, f.sampling_date_dat, d.lastname_vchr AS applyer,
									 e.deptname_vchr
								FROM t_opr_lis_application a,
									 t_bse_employee d,
									 t_bse_deptdesc e,
									 (SELECT c.lastname_vchr AS collector, b.*
										FROM t_opr_lis_sample b, t_bse_employee c
									   WHERE b.application_id_chr IN (
												SELECT DISTINCT a.application_id_chr
															FROM t_pis_opr_application_to_lis a,
																 t_pis_aid_item_to_lis b,
																 t_opr_lis_app_apply_unit c
															WHERE a.person_examine_id_chr = ?
															 AND b.group_id_chr = ?
															 AND b.apply_unit_id_chr = c.apply_unit_id_chr
															 AND a.application_id_chr = c.application_id_chr)
										AND b.status_int > 0
										AND b.collector_id_chr = c.empid_chr(+)) f
								WHERE a.application_id_chr = f.application_id_chr(+)
								AND a.appl_empid_chr = d.empid_chr(+)
								AND a.appl_deptid_chr = e.deptid_chr(+)
								AND a.pstatus_int > 0
								AND a.application_id_chr IN (
										SELECT DISTINCT a.application_id_chr
													FROM t_pis_opr_application_to_lis a,
														t_pis_aid_item_to_lis b,
														t_opr_lis_app_apply_unit c
													WHERE a.person_examine_id_chr = ?
													AND b.group_id_chr = ?
													AND b.apply_unit_id_chr = c.apply_unit_id_chr
													AND a.application_id_chr = c.application_id_chr)";

            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objIDPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_strExamineID, p_strItemGroupID,
                    p_strExamineID, p_strItemGroupID);
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objIDPArr);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objApplyReportArr = new clsLisApplyReportInfo_VO[dtbResult.Rows.Count];
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    for (int i = 0; i < p_objApplyReportArr.Length; i++)
                    {
                        p_objApplyReportArr[i] = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 查询根据体检号PIS申请报告单

        /// <summary>
        /// 查询根据体检号PIS申请报告单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strExamineID"></param>
        /// <param name="p_objApplyReportArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindApplyReportArrByExamineID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strExamineID,
            out clsLisApplyReportInfo_VO[] p_objApplyReportArr)
        {
            long lngRes = 0;
            p_objApplyReportArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc"
                , "m_lngFindApplyReportArrByExamineID");
            if (lngRes <= 0)
            {
                return -1;
            }

            #region SQL

            string strSQL = @"SELECT a.*, f.collector, f.sampling_date_dat, d.lastname_vchr AS applyer,
									 e.deptname_vchr
								FROM t_opr_lis_application a,
									 t_bse_employee d,
									 t_bse_deptdesc e,
									 (SELECT c.lastname_vchr AS collector, b.*
										FROM t_opr_lis_sample b, t_bse_employee c
									   WHERE b.application_id_chr IN (
																SELECT a.application_id_chr
																  FROM t_pis_opr_application_to_lis a
																 WHERE a.person_examine_id_chr = ? )
										AND b.status_int > 0
										AND b.collector_id_chr = c.empid_chr(+)) f
								WHERE a.application_id_chr = f.application_id_chr(+)
								  AND a.appl_empid_chr = d.empid_chr(+)
								  AND a.appl_deptid_chr = e.deptid_chr(+)
								  AND a.pstatus_int > 0
								  AND a.application_id_chr IN (SELECT a.application_id_chr
																 FROM t_pis_opr_application_to_lis a
																WHERE a.person_examine_id_chr = ? )";

            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objIDPArr = clsPublicSvc.m_objConstructIDataParameterArr(p_strExamineID, p_strExamineID);
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objIDPArr);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objApplyReportArr = new clsLisApplyReportInfo_VO[dtbResult.Rows.Count];
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    for (int i = 0; i < p_objApplyReportArr.Length; i++)
                    {
                        p_objApplyReportArr[i] = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 根据病人住院号和住院日期查询,出院日期 查询得到 检验结果信息
        /// <summary>
        /// 根据病人住院号和住院日期查询,出院日期 查询得到 检验结果信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInPatientNO"></param>
        /// <param name="p_strInHospitalDate"></param>
        /// <param name="p_strOutHospitalDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetResultInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strInPatientNO, string p_strInHospitalDate, string p_strOutHospitalDate,
            out clsLISPatientCheckResultInfoVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetResultInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                   t1.printed_date, 
                                   t2.summary_vchr AS report_summary_vchr, t2.confirm_dat AS report_confirm_dat
								FROM t_opr_lis_application t1, t_opr_lis_app_report t2
								WHERE t1.application_id_chr = t2.application_id_chr
								AND t1.pstatus_int + 0 = 2
								AND t2.status_int = 2
								AND TRIM(patient_inhospitalno_chr) = TRIM(?)
								AND application_dat >= TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
								AND application_dat <= TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ItemResult = @"SELECT *
											FROM t_opr_lis_check_result t1
											WHERE t1.status_int = 1
											AND t1.modify_dat >= TO_DATE(?, 'yyyy-mm-dd hh24:mi:ss') 
											AND t1.sample_id_chr IN (SELECT t2.sample_id_chr
																		FROM t_opr_lis_app_sample t2
																		WHERE t2.application_id_chr = ?)";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            clsVOConstructor objConstructor = new clsVOConstructor();

            try
            {
                try
                {
                    DateTime.Parse(p_strInHospitalDate);
                }
                catch
                {
                    p_strInHospitalDate = "1900-01-01 00:00:00";
                }
                try
                {
                    DateTime.Parse(p_strOutHospitalDate);
                }
                catch
                {
                    p_strOutHospitalDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }


                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);

                objDPArr[0].Value = p_strInPatientNO;
                objDPArr[1].Value = p_strInHospitalDate;
                objDPArr[2].Value = p_strOutHospitalDate;

                DataTable dtbResult = new DataTable();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLISPatientCheckResultInfoVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = new clsLISPatientCheckResultInfoVO();
                        p_objResultArr[i].m_objApp = objConstructor.m_objConstructAppMainVO(dtbResult.Rows[i]);
                        p_objResultArr[i].m_objAppReport = new clsT_OPR_LIS_APP_REPORT_VO();
                        p_objResultArr[i].m_objAppReport.m_strSUMMARY_VCHR = dtbResult.Rows[i]["report_summary_vchr"].ToString();
                        p_objResultArr[i].m_objAppReport.m_strCONFIRM_DAT = dtbResult.Rows[i]["report_confirm_dat"].ToString();

                        IDataParameter[] objDPArr1 = null;
                        objHRPSvc.CreateDatabaseParameter(2, out objDPArr1);

                        objDPArr1[0].Value = p_objResultArr[i].m_objApp.m_strOriginDate;
                        objDPArr1[1].Value = p_objResultArr[i].m_objApp.m_strAPPLICATION_ID;

                        DataTable dtbResult1 = new DataTable();
                        lngRes = 0;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL_ItemResult, ref dtbResult1, objDPArr1);
                        if (lngRes > 0 && dtbResult1.Rows.Count > 0)
                        {
                            p_objResultArr[i].m_objResults = new clsCheckResult_VO[dtbResult1.Rows.Count];
                            for (int j = 0; j < dtbResult1.Rows.Count; j++)
                            {
                                p_objResultArr[i].m_objResults[j] = objConstructor.m_objConstructCheckResultVO(dtbResult1.Rows[j]);
                            }
                        }
                    }
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                p_objResultArr = null;
                objHRPSvc.Dispose();
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 根据申请单ID查询打印申请单信息
        /// <summary>
        /// 根据申请单ID查询打印申请单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplicationReportInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
            out clsLisApplyReportInfo_VO p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationReportInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.application_id_chr,
       a.patientid_chr,
       a.application_dat,
       a.sex_chr,
       a.patient_name_vchr,
       a.patient_subno_chr,
       a.age_chr,
       a.patient_type_id_chr,
       a.diagnose_vchr,
       a.bedno_chr,
       a.icdcode_chr,
       a.patientcardid_chr,
       a.application_form_no_chr,
       a.modify_dat,
       a.operator_id_chr,
       a.appl_empid_chr,
       a.appl_deptid_chr,
       a.summary_vchr,
       a.pstatus_int,
       a.emergency_int,
       a.special_int,
       a.form_int,
       a.patient_inhospitalno_chr,
       a.sample_type_id_chr,
       a.check_content_vchr,
       a.sample_type_vchr,
       a.oringin_dat,
       a.charge_info_vchr,
       a.printed_num,
       a.orderunitrelation_vchr,
       a.printed_date,
       d.lastname_vchr as applyer,
       e.deptname_vchr,
       f.collector,
       f.sampling_date_dat,
       f.barcode_vchr
  from t_opr_lis_application a,
       t_bse_employee d,
       t_bse_deptdesc e,
       (select c.lastname_vchr as collector,
               b.barcode_vchr,
               b.sample_id_chr,
               b.sampling_date_dat,
               b.application_id_chr
          from t_opr_lis_sample b, t_bse_employee c
         where b.application_id_chr = ?
           and b.status_int > 0
           and b.collector_id_chr = c.empid_chr(+)) f
 where a.application_id_chr = f.application_id_chr(+)
   and a.appl_empid_chr = d.empid_chr(+)
   and a.appl_deptid_chr = e.deptid_chr(+)
   and a.pstatus_int > 0
   and a.application_id_chr = ?";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strApplicationID;
                objParamArr[1].Value = p_strApplicationID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    p_objResult = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[0]);
                    if (p_objResult != null)
                    {
                        p_objResult.m_strBarCode = dtbResult.Rows[0]["barcode_vchr"].ToString().Trim();
                        p_objResult.m_strOutPatientNO = dtbResult.Rows[0]["patientcardid_chr"].ToString().Trim();
                    }
                    strSQL = @"select d.vlaue_vchr
  from t_opr_lis_app_apply_unit      a,
       t_aid_lis_unit_propert_relate b,
       t_aid_lis_unit_property       c,
       t_aid_lis_unit_property_value d
 where a.apply_unit_id_chr = b.apply_unit_id_chr
   and b.unit_property_id_chr = c.property_id_chr
   and b.value_id_chr = d.vlaue_id_chr
   and c.property_name_vchr = '颜色'
   and a.application_id_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = p_strApplicationID;
                    dtbResult = null;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                    if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                    {
                        p_objResult.m_strColor = dtbResult.Rows[0]["vlaue_vchr"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询得到申请单详细信息
        /// <summary>
        /// 根据申请单ID查询得到申请单详细信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strOringinDate"></param>
        /// <param name="p_objLISInfoVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLISInfoByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, string p_strOringinDate, out clsLISInfoVO p_objLISInfoVO)
        {
            long lngRes = 0;
            p_objLISInfoVO = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetLISInfoByApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_strApplicationID == null)
            {
                return 1;
            }

            try
            {
                DateTime.Parse(p_strOringinDate);
            }
            catch
            {
                p_strOringinDate = "1900-01-01 00:00:00";
            }
            #region SQL
            string strSQL = @"select t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                   t1.printed_date, 
                                   t2.application_id_chr, t2.report_group_id_chr, t2.modify_dat,
                                   t2.summary_vchr, t2.operator_id_chr, t2.status_int, t2.report_dat,
                                   t2.reportor_id_chr, t2.confirm_dat, t2.confirmer_id_chr,
                                   t2.xml_summary_vchr, t2.annotation_vchr, t2.xml_annotation_vchr, 
                                   t2.summary_vchr as report_summary_vchr, 
                                   t3.appl_dat, t3.sex_chr, t3.patient_name_vchr, t3.patient_subno_chr,
                                   t3.age_chr, t3.patient_type_chr, t3.diagnose_vchr, t3.sampletype_vchr,
                                   t3.samplestate_vchr, t3.bedno_chr, t3.icd_vchr, t3.patientcardid_chr,
                                   t3.barcode_vchr, t3.sample_id_chr, t3.patientid_chr,
                                   t3.sampling_date_dat, t3.operator_id_chr, t3.modify_dat,
                                   t3.appl_empid_chr, t3.appl_deptid_chr, t3.status_int,
                                   t3.sample_type_id_chr, t3.qcsampleid_chr, t3.samplekind_chr,
                                   t3.check_date_dat, t3.accept_dat, t3.acceptor_id_chr,
                                   t3.application_id_chr, t3.patient_inhospitalno_chr, t3.confirm_dat,
                                   t3.confirmer_id_chr, t3.collector_id_chr, t3.checker_id_chr,t3.sendsample_empid_chr,
                   t3.status_int as sample_status_int
                from t_opr_lis_application t1, t_opr_lis_app_report t2, t_opr_lis_sample t3
                where t1.pstatus_int + 0 = 2
                and t2.status_int > 0
                and (t3.status_int = 3 or t3.status_int = 5 or t3.status_int = 6)
                and t1.application_id_chr = t2.application_id_chr
                and t1.application_id_chr = t3.application_id_chr
                and t1.application_id_chr = ?
                and t1.oringin_dat >= ?
								";
            string strSQL1 = @"select a.apply_unit_id_chr
  from t_opr_lis_app_apply_unit a
 where a.application_id_chr = ?";
            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
            objDPArr[0].Value = p_strApplicationID;
            objDPArr[1].Value = DateTime.Parse(p_strOringinDate);

            DataTable dtbResult = null;
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
                {

                    IDataParameter[] objDPArr1 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr1);
                    objDPArr1[0].Value = p_strApplicationID;

                    DataTable dtbUnits = new DataTable();
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtbUnits, objDPArr1);
                    if (lngRes == 1 && dtbUnits != null && dtbUnits.Rows.Count > 0)
                    {
                        clsLisApplMainVO objApp = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[0]);
                        clsT_OPR_LIS_APP_REPORT_VO objReport = new clsVOConstructor().m_objConstructAppReportVO(dtbResult.Rows[0]);
                        objReport.m_strSUMMARY_VCHR = dtbResult.Rows[0]["report_summary_vchr"].ToString().Trim();
                        clsT_OPR_LIS_SAMPLE_VO objSample = new clsVOConstructor().m_objConstructSampleVO(dtbResult.Rows[0]);
                        objSample.m_intSTATUS_INT = int.Parse(dtbResult.Rows[0]["sample_status_int"].ToString().Trim());
                        objApp.m_strReportGroupID = objReport.m_strREPORT_GROUP_ID_CHR;
                        objApp.m_strReportDate = objReport.m_strCONFIRM_DAT;
                        objApp.m_intReportStatus = objReport.m_intSTATUS_INT;
                        objApp.m_intSampleStatus = objSample.m_intSTATUS_INT;

                        p_objLISInfoVO = new clsLISInfoVO();
                        p_objLISInfoVO.m_objAppMainVO = objApp;
                        p_objLISInfoVO.m_objReportVO = objReport;
                        p_objLISInfoVO.m_objSampleVO = objSample;

                        p_objLISInfoVO.m_strApplyUnitArr = new string[dtbUnits.Rows.Count];
                        for (int i = 0; i < dtbUnits.Rows.Count; i++)
                        {
                            p_objLISInfoVO.m_strApplyUnitArr[i] = dtbUnits.Rows[i]["apply_unit_id_chr"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 根据条件查询病人信息
        [AutoComplete]
        public long m_lngGetPatientInfoByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientInHospitalNO, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetPatientInfoByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"select distinct a.patient_inhospitalno_chr,
                a.patient_name_vchr,
                a.sex_chr,
                a.age_chr,
                a.patient_subno_chr,
                a.patient_type_id_chr,
                a.diagnose_vchr,
                a.bedno_chr,
                a.appl_empid_chr,
                c.lastname_vchr as employeename,
                a.appl_deptid_chr,
                b.deptname_vchr,
                a.emergency_int,
                a.special_int,
                a.patientid_chr,
                a.application_dat
  from t_opr_lis_application a, t_bse_deptdesc b, t_bse_employee c
 where a.appl_deptid_chr = b.deptid_chr(+)
   and a.appl_empid_chr = c.empid_chr(+)
   and a.patient_inhospitalno_chr = ?
";

            #endregion


            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
            objDPArr[0].Value = p_strPatientInHospitalNO;
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                if (lngRes > 0 && p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvTemp = p_dtbResult.DefaultView;
                    dvTemp.Sort = "application_dat desc";
                    p_dtbResult = dvTemp.ToTable();
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 组合查询查询已发送申请单及样本信息
        /// <summary>
        /// 组合查询查询已发送申请单及样本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSampleStatus">1为未采集,2为已采集,0为所有</param>
        /// <param name="p_strAppDept"></param>
        /// <param name="p_strFromDatApp"></param>
        /// <param name="p_strToDatApp"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppAndSampleInfo(IPrincipal p_objPrincipal, int p_intSampleStatus, string p_strAppDept,
                                             string p_strFromDatApp, string p_strToDatApp, string p_strPatientName,
                                             string p_strPatiendCardID, string p_strAcceptStatus, int p_intSampleBackeStatus, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL

            string strSQL = @" select distinct a.*,
                                   b.status_int as paystatus,
                                   b.isgreen_int, b.chargedesc 
                              from v_lis_app_report_sample_info a,
                                   t_opr_attachrelation b
                             where a.application_id_chr = b.attachid_vchr(+)
                               and a.patient_type_id_chr=2
                               and a.pstatus_int = 2
                               and b.status_int < 2
                               and a.form_int    = 1  ";

            lngRes = 0;
            bool blnResult;
            //【系统开关 -> 是否显示没交费病人信息:4001 0:不显示】
            lngRes = this.m_lngGetCollocate(p_objPrincipal, out blnResult, "4001");
            if (!blnResult)
            {
                strSQL += " and b.status_int = 1 ";
            }

            string strSQL_FromDateApp = " and application_dat >= to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ToDateApp = " and application_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_AppDept = " and trim(appl_deptid_chr) = ? ";

            string strSQL_SampleSatus_NoSample = " and sample_status_int = 1 ";
            string strSQL_SampleSatus_Sampled = " and sample_status_int > 1 ";
            string strSQL_SampleSatus_All = " and sample_status_int > 0 ";

            string strSQL_PatientName = " and patient_name_vchr like ? ";
            string strSQL_PatientCardID = " and patientcardid_chr = ? ";
            string strSQL_Accept = " and sample_status_int >=3";
            string strSQL_NotAccept = " and sample_status_int < 3";
            //string strSQL_AllAccept = " and sample_status_int between 3 and 6";

            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造

            if (p_intSampleStatus == 1)
            {
                arlSQL.Add(strSQL_SampleSatus_NoSample);
            }
            else if (p_intSampleStatus == 2)
            {
                arlSQL.Add(strSQL_SampleSatus_Sampled);
            }
            else if (p_intSampleStatus == 0)
            {
                arlSQL.Add(strSQL_SampleSatus_All);
            }
            if (p_strAcceptStatus == "1")
            {
                arlSQL.Add(strSQL_Accept);
            }
            else if (p_strAcceptStatus == "0")
            {
                arlSQL.Add(strSQL_NotAccept);
            }
            if (p_intSampleBackeStatus == 0)
            {
                arlSQL.Add("and sampleback='0'");
            }
            else if (p_intSampleBackeStatus == 1)
            {
                arlSQL.Add("and sampleback = '1'");
            }
            if (p_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_strFromDatApp.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                arlParm.Add(p_strFromDatApp.Trim());
            }
            if (p_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_strToDatApp.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                arlParm.Add(p_strToDatApp.Trim());
            }

            if (p_strAppDept != null && p_strAppDept.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(p_strAppDept.Trim());
            }

            if (p_strPatientName != null && p_strPatientName.ToString().Replace('%', ' ').Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add(p_strPatientName.Trim());
            }

            if (p_strPatiendCardID != null && p_strPatiendCardID.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientCardID);
                arlParm.Add(p_strPatiendCardID.Trim());
            }

            arlSQL.Add("order by a.application_dat desc");
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            int intParmCount = 0;

            intParmCount = arlParm.Count;

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

            for (int i = 0; i < intParmCount; i++)
            {
                objDPArr[i].Value = arlParm[i];
            }

            try
            {
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    System.Collections.ArrayList arlApp = new ArrayList();
                    DataRow drTemp = null;
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        drTemp = dtbResult.Rows[i];
                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(drTemp);
                        objMainVO.m_strSampleID = drTemp["sample_id_chr"].ToString().Trim();
                        objMainVO.m_intSampleStatus = int.Parse(drTemp["sample_status_int"].ToString().Trim());
                        if (dtbResult.Columns.Contains("paystatus"))
                        {
                            objMainVO.m_intChargeState = DBAssist.ToInt32(drTemp["paystatus"]);
                        }
                        if (drTemp["sampleback"].ToString().Trim() == "1")
                        {
                            objMainVO.m_strSample_Back_Reason = drTemp["sample_back_reason"].ToString().Trim();
                        }
                        
                        if (!string.IsNullOrEmpty(drTemp["isgreen_int"].ToString().Trim()))
                        {
                            objMainVO.m_intIsGreen = int.Parse(drTemp["isgreen_int"].ToString().Trim());
                        }
                        objMainVO.ChargeDesc = drTemp["chargedesc"].ToString();

                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
                else
                {
                    p_objAppVOArr = new clsLisApplMainVO[0];
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                p_objAppVOArr = new clsLisApplMainVO[0];
            }

            return lngRes;
        }
        #endregion

        #region［住院采集样本］组合查询查询已发送申请单及样本信息
        /// <summary>
        /// [住院采集样本］组合查询查询已发送申请单及样本信息
        /// </summary>
        /// <remarks>住院部分不关联收费信息</remarks>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSampleStatus"></param>
        /// <param name="p_strAppDept"></param>
        /// <param name="p_strFromDatApp"></param>
        /// <param name="p_strToDatApp"></param>
        /// <param name="p_strPatientName"></param>
        /// <param name="p_strPatiendCardID"></param>
        /// <param name="p_strHosipitalNO"></param>
        /// <param name="bedNo"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppAndSampleInfo(IPrincipal principal, int sampleStatus, string areaId,
                                             string beginDate, string endDate, string patientName,
                                             string patientCardId, string hosipitalNo, string bedNo, out clsLisApplMainVO[] p_objAppVOArr)
        {

            long lngRes = 0;
            p_objAppVOArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(principal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL

            lngRes = 0;

            string strSQL = @"select *
						        from v_lis_app_report_sample_info 
						       where patient_type_id_chr = 1 
                                 and pstatus_int = 2 
                                 and form_int = 1 ";

            string strSQL_FromDateApp = " and application_dat >= ? ";
            string strSQL_ToDateApp = " and application_dat <= ? ";
            string strSQL_AppDept = " and trim(appl_deptid_chr) = ? ";
            string strSQL_SampleSatus_NoSample = " and sample_status_int = 1 ";
            string strSQL_SampleSatus_Sampled = " and sample_status_int > 1 ";
            string strSQL_SampleSatus_All = " and sample_status_int > 0 ";
            string strSQL_PatientName = " and patient_name_vchr like ? ";
            string strSQL_PatientCardID = " and patientcardid_chr = ? ";
            string strSQL_PatientHosipitalNO = " and trim(patient_inhospitalno_chr) = ?";
            string strSQL_PatientBedNo = " and trim(bedno_chr) = ? ";

            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造

            if (sampleStatus == 1)
            {
                arlSQL.Add(strSQL_SampleSatus_NoSample);
            }
            else if (sampleStatus == 2)
            {
                arlSQL.Add(strSQL_SampleSatus_Sampled);
            }
            else if (sampleStatus == 0)
            {
                arlSQL.Add(strSQL_SampleSatus_All);
            }

            if (beginDate != null && Microsoft.VisualBasic.Information.IsDate(beginDate.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                arlParm.Add(DateTime.Parse(beginDate.Trim()));
            }
            if (endDate != null && Microsoft.VisualBasic.Information.IsDate(endDate.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                arlParm.Add(DateTime.Parse(endDate.Trim()));
            }

            if (areaId != null && areaId.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(areaId.Trim());
            }

            if (patientName != null && patientName.ToString().Replace('%', ' ').Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add(patientName.Trim());
            }

            if (patientCardId != null && patientCardId.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientCardID);
                arlParm.Add(patientCardId.Trim());
            }

            if (areaId != null && areaId.ToString().Trim() != "" && hosipitalNo.Trim() != string.Empty)
            {
                arlSQL.Add(strSQL_PatientHosipitalNO);
                arlParm.Add(hosipitalNo.Trim());
            }
            if (areaId != null && areaId.ToString().Trim() != "" && bedNo.Trim() != string.Empty)
            {
                arlSQL.Add(strSQL_PatientBedNo);
                arlParm.Add(bedNo.Trim());
            }

            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            int intParmCount = 0;
            intParmCount = arlParm.Count;

            clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

            for (int i = 0; i < intParmCount; i++)
            {
                objDPArr[i].Value = arlParm[i];
            }
            try
            {
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    System.Collections.ArrayList arlApp = new ArrayList();
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
                        objMainVO.m_strSampleID = dtbResult.Rows[i]["SAMPLE_ID_CHR"].ToString().Trim();
                        objMainVO.m_intSampleStatus = int.Parse(dtbResult.Rows[i]["SAMPLE_STATUS_INT"].ToString().Trim());
                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
                else
                {
                    p_objAppVOArr = new clsLisApplMainVO[0];
                }
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                p_objAppVOArr = new clsLisApplMainVO[0];
            }

            return lngRes;
        }

        #endregion

        #region 根据申请日期、发送状态组合查询申请单信息
        /// <summary>
        /// 根据申请日期、发送状态组合查询申请单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFromDat"></param>
        /// <param name="p_strToDat"></param>
        /// <param name="p_blnSend"></param>
        /// <param name="p_blnUnSend"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplicationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strFromDat, string p_strToDat, bool p_blnSend, bool p_blnUnSend, out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select t.*, a.isgreen_int from t_opr_lis_application t, t_opr_attachrelation a";

            #region Condition
            if (p_blnSend && !p_blnUnSend)
            {
                strSQL += " where pstatus_int = 2 ";
            }
            else if (!p_blnSend && p_blnUnSend)
            {
                strSQL += " where pstatus_int = 1 ";
            }
            else if (p_blnSend && p_blnUnSend)
            {
                strSQL += " where pstatus_int >0 ";
            }
            else
            {
                strSQL += " where pstatus_int = 0 ";
            }

            strSQL += " and t.application_id_chr = a.attachid_vchr(+)";

            if (p_strFromDat != null && p_strToDat == null)
            {
                strSQL += " and application_dat >= to_date('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') ";
            }
            else if (p_strFromDat == null && p_strToDat != null)
            {
                strSQL += " and application_dat <= to_date('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss') ";
            }
            else if (p_strFromDat != null && p_strToDat != null)
            {
                strSQL += " and application_dat between to_date('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss')";
            }
            #endregion

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据检验日期、标本号、仪器和病人姓名组合查询查询申请单信息
        [AutoComplete]
        public long m_lngGetApplicationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFromDat, string p_strToDat,
            string p_strDeviceID, string p_strPatientName, string p_strSampleID, out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                       t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                       t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                       t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                       t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                       t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                       t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                       t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                       t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                       t1.printed_date
								FROM t_opr_lis_application t1,
									 t_opr_lis_sample t2,
									 t_opr_lis_device_relation t3
							   WHERE t1.application_id_chr = t2.application_id_chr
								 AND t2.sample_id_chr = t3.sample_id_chr
								 AND t2.status_int > 0
								 AND t1.pstatus_int > 0
								 AND t3.status_int > 0";
            if (p_strFromDat.ToString().Trim() != "" && p_strToDat.ToString().Trim() != "")
            {
                strSQL += " AND t2.CHECK_DATE_DAT BETWEEN TO_DATE('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss')";
            }
            if (p_strDeviceID.ToString().Trim() != "")
            {
                strSQL += " AND t3.deviceid_chr = '" + p_strDeviceID + "'";
            }
            if (p_strPatientName.ToString().Trim() != "")
            {
                strSQL += " AND t1.PATIENT_NAME_VCHR = '" + p_strPatientName + "'";
            }
            if (p_strSampleID.ToString().Trim() != "")
            {
                strSQL += " AND t2.sample_id_chr = '" + p_strSampleID + "'";
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
                        //						p_objResultArr[i1] = new clsLisApplMainVO();
                        //						p_objResultArr[i1].m_strAPPLICATION_ID = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientID = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_Dat = dtbResult.Rows[i1]["APPLICATION_DAT"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSex = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatient_Name = dtbResult.Rows[i1]["PATIENT_NAME_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatient_SubNO = dtbResult.Rows[i1]["PATIENT_SUBNO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAge = dtbResult.Rows[i1]["AGE_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientType = dtbResult.Rows[i1]["PATIENT_TYPE_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strDiagnose = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strBedNO = dtbResult.Rows[i1]["BEDNO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strICD = dtbResult.Rows[i1]["ICDCODE_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientcardID = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strApplication_Form_NO = dtbResult.Rows[i1]["APPLICATION_FORM_NO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        //						p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_EmpID = dtbResult.Rows[i1]["APPL_EMPID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_DeptID = dtbResult.Rows[i1]["APPL_DEPTID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSummary = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_intPStatus_int = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intEmergency = Convert.ToInt32(dtbResult.Rows[i1]["EMERGENCY_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intSpecial = Convert.ToInt32(dtbResult.Rows[i1]["SPECIAL_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intForm_int = Convert.ToInt32(dtbResult.Rows[i1]["FORM_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_strPatient_inhospitalno_chr = dtbResult.Rows[i1]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单信息
        [AutoComplete]
        public long m_lngGetApplicationInfoByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
            out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationInfoByApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT * FROM T_OPR_LIS_APPLICATION WHERE application_id_chr = '" + p_strApplicationID + @"' AND PSTATUS_INT > 0";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
                        //						p_objResultArr[i1] = new clsLisApplMainVO();
                        //						p_objResultArr[i1].m_strAPPLICATION_ID = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientID = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_Dat = dtbResult.Rows[i1]["APPLICATION_DAT"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSex = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatient_Name = dtbResult.Rows[i1]["PATIENT_NAME_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatient_SubNO = dtbResult.Rows[i1]["PATIENT_SUBNO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAge = dtbResult.Rows[i1]["AGE_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientType = dtbResult.Rows[i1]["PATIENT_TYPE_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strDiagnose = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strBedNO = dtbResult.Rows[i1]["BEDNO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strICD = dtbResult.Rows[i1]["ICDCODE_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strPatientcardID = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strApplication_Form_NO = dtbResult.Rows[i1]["APPLICATION_FORM_NO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        //						p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_EmpID = dtbResult.Rows[i1]["APPL_EMPID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strAppl_DeptID = dtbResult.Rows[i1]["APPL_DEPTID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSummary = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_intPStatus_int = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intEmergency = Convert.ToInt32(dtbResult.Rows[i1]["EMERGENCY_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intSpecial = Convert.ToInt32(dtbResult.Rows[i1]["SPECIAL_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_intForm_int = Convert.ToInt32(dtbResult.Rows[i1]["FORM_INT"].ToString().Trim());
                        //						p_objResultArr[i1].m_strPatient_inhospitalno_chr = dtbResult.Rows[i1]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strCheckContent = dtbResult.Rows[i1]["CHECK_CONTENT_VCHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSampleTypeID = dtbResult.Rows[i1]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                        //						p_objResultArr[i1].m_strSampleType = dtbResult.Rows[i1]["SAMPLE_TYPE_VCHR"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请日期查询所有已发送的检验申请单信息
        [AutoComplete]
        public long m_lngGetAllSendApplInfoByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                   t1.printed_date, 
                                     t3.lastname_vchr operatorname,
									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
									 t7.dictname_vchr pattype
								FROM t_opr_lis_application t1,
									 t_bse_employee t3,
									 t_bse_deptbaseinfo t4,
									 t_bse_employee t5,
									 t_aid_icd10 t6,
									 t_aid_dict t7
							   WHERE t1.operator_id_chr = t3.empid_chr(+)
								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
								 AND t1.appl_empid_chr = t5.empid_chr(+)
								 AND t1.icdcode_chr = t6.icdcode_chr(+)
								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
								 AND t7.dictkind_chr(+) = '61'
								 AND t1.pstatus_int = 2
								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')";
            dtbAppInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请日期查询所有具有未采集的标本的检验申请信息
        [AutoComplete]
        public long m_lngGetAllNoCollectSampleByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                   t1.printed_date, 
                                     t3.lastname_vchr operatorname,
									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
									 t7.dictname_vchr pattype,0 collected_int
								FROM t_opr_lis_application t1,
									 t_bse_employee t3,
									 t_bse_deptbaseinfo t4,
									 t_bse_employee t5,
									 t_aid_icd10 t6,
									 t_aid_dict t7
							   WHERE t1.operator_id_chr = t3.empid_chr(+)
								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
								 AND t1.appl_empid_chr = t5.empid_chr(+)
								 AND t1.icdcode_chr = t6.icdcode_chr(+)
								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
								 AND t7.dictkind_chr(+) = '61'
								 AND t1.pstatus_int = 2
								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')
								 AND t1.application_id_chr IN (SELECT application_id_chr
																FROM t_opr_lis_app_sample
																WHERE sample_id_chr IS NULL)";
            dtbAppInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请日期查询所有已采集的检验申请信息
        [AutoComplete]
        public long m_lngGetAllCollectedApplInfoByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
                                   t1.printed_date, 
                                     t3.lastname_vchr operatorname,
									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
									 t7.dictname_vchr pattype,1 collected_int
								FROM t_opr_lis_application t1,
									 t_bse_employee t3,
									 t_bse_deptbaseinfo t4,
									 t_bse_employee t5,
									 t_aid_icd10 t6,
									 t_aid_dict t7
							   WHERE t1.operator_id_chr = t3.empid_chr(+)
								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
								 AND t1.appl_empid_chr = t5.empid_chr(+)
								 AND t1.icdcode_chr = t6.icdcode_chr(+)
								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
								 AND t7.dictkind_chr(+) = '61'
								 AND t1.pstatus_int = 2
								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')
								 AND t1.application_id_chr NOT IN (SELECT application_id_chr
																	FROM t_opr_lis_app_sample
																	WHERE sample_id_chr IS NULL)";
            dtbAppInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号查询(已审核=3、未审核<3和全部>0)申请单信息
        [AutoComplete]
        public long m_lngQryApplInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, string strPstatus, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
									 sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
								   	 patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
									 patientcardid_chr, application_form_no_chr, operator_id_chr,
									 appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int, 
									 EMERGENCY_INT, SPECIAL_INT
								FROM t_opr_lis_application
							   WHERE pstatus_int > 0
								 AND application_form_no_chr = '" + p_strApplFormNo + @"'
								 AND pstatus_int " + strPstatus;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据诊疗卡号查询检验申请信息
        [AutoComplete]
        public long m_lngApplInfoByPatientCardID(System.Security.Principal.IPrincipal p_objPrincipal, string strPatientCardID, out DataTable dtbAppInfo)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
									 t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
									 t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
									 t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
									 t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
									 t1.summary_vchr, t1.pstatus_int, t3.lastname_vchr operatorname,
									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
									 t7.dictname_vchr pattype
								FROM t_opr_lis_application t1,
									 t_opr_lis_application_detail t2,
									 t_bse_employee t3,
									 t_bse_deptbaseinfo t4,
									 t_bse_employee t5,
									 t_aid_icd10 t6,
									 t_aid_dict t7
							   WHERE t1.operator_id_chr = t3.empid_chr(+)
								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
								 AND t1.appl_empid_chr = t5.empid_chr(+)
								 AND t1.icdcode_chr = t6.icdcode_chr(+)
								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
								 AND t7.dictkind_chr(+) = '61'
								 AND t1.application_id_chr = t2.application_id_chr
								 AND t1.pstatus_int > 0
								 AND t1.patientid_chr=(select patientid_chr from t_bse_patientcard where patientcardid_chr='" + strPatientCardID + "')";
            dtbAppInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据Application_Form_No查询表t_opr_lis_application_detail所有属于该申请单的大组
        [AutoComplete]
        public long m_lngGetCheckGroupByApplicationFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string strApplFormNo, out DataTable dtbCheckGroup)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.groupid_chr, t2.groupname_vchr, t1.application_id_chr,
									 t1.status_int, t1.summary_vchr, t2.PRINT_CATEGORY_ID_CHR
								FROM t_opr_lis_application_detail t1,
									 t_aid_lis_check_group t2,
									 t_opr_lis_application t3
							   WHERE t1.groupid_chr = t2.groupid_chr
								 AND t1.status_int > 0
								 AND t1.modify_dat = t3.modify_dat
								 AND t1.application_id_chr = t3.application_id_chr
								 AND t3.application_form_no_chr = '" + strApplFormNo + @"'
								 AND t3.pstatus_int > 0";
            dtbCheckGroup = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckGroup);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号查询检验组信息(含子组)
        [AutoComplete]
        public long m_lngGetCheckGroupByApplFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string strApplFormNo, out DataTable dtbCheckGroup)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.sample_id_chr, t2.groupname_vchr, t1.groupid_chr
								FROM t_opr_lis_req_check t1, t_aid_lis_check_group t2
								WHERE t1.groupid_chr = t2.groupid_chr
								AND sample_id_chr IN (SELECT sample_id_chr
															 FROM t_opr_lis_sample WHERE application_form_no_chr = '" + strApplFormNo + "')";
            dtbCheckGroup = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckGroup);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region SQL
        private const string c_strQueryAppl_SQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
												a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
												a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
												a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
												a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
												a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
												d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr patType
												FROM t_opr_lis_application a,
													t_bse_employee b,
													t_bse_deptbaseinfo c,
													t_bse_employee d,
													t_aid_icd10 e,
													t_aid_dict f
												WHERE a.operator_id_chr = b.empid_chr(+)
												AND a.appl_deptid_chr = c.deptid_chr(+)
												AND a.appl_empid_chr = d.empid_chr(+)
												AND a.icdcode_chr = e.icdcode_chr(+)
												AND a.patient_type_id_chr = f.dictid_chr(+)
												AND f.dictkind_chr(+) = '61'";//61代表病人类型
        private const string c_strQueryApplDetail_SQL = @"SELECT application_id_chr, seq_int, modify_dat, groupid_chr, summary_vchr,
														status_int
													FROM t_opr_lis_application_detail";

        #endregion

        #region 按照某一字段，模糊查询表t_opr_lis_application，也可比较查询,可自定义按那个字段排序，是倒序还是顺序
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intQueryType">查询方法:0-模糊查询 1-比较查询,查询字段为字符型 2-比较查询,查询字段为时间型</param>
        /// <param name="p_strFussField">查询字段</param>
        /// <param name="p_strCompare">比较测试条件</param>
        /// <param name="p_strFussValue">查询字段的值</param>
        /// <param name="p_strOrderByField">排序字段</param>
        /// <param name="p_blnDesc">true-DESC;false-ASC</param></param>
        /// <param name="p_objLisApplVOList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplByQuery(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQueryType, string p_strField, string p_strCompare, string p_strFieldValue, string p_strOrderByField, bool p_blnDesc, out System.Data.DataTable p_dtbAppl)
        {
            string strSQL = "";
            p_dtbAppl = null;
            if (p_intQueryType == 0)
                strSQL = c_strQueryAppl_SQL + " and a." + p_strField + " LIKE '" + p_strFieldValue + "%' ORDER BY a." + p_strOrderByField;
            else if (p_intQueryType == 1)
                strSQL = c_strQueryAppl_SQL + " and a." + p_strField + p_strCompare + p_strFieldValue + " ORDER BY a." + p_strOrderByField;
            else if (p_intQueryType == 2)
                strSQL = c_strQueryAppl_SQL + " and a." + p_strField + p_strCompare + "to_date('" + p_strFieldValue + "','yyyy-mm-dd')" + " ORDER BY a." + p_strOrderByField;

            if (p_blnDesc)
            { strSQL = strSQL + " DESC"; }

            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据ApplicationID查询t_opr_lis_application_detail
        [AutoComplete]
        public long m_lngGetApplDetailByApplID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplID, out System.Data.DataTable p_dtbApplDetail)
        {
            p_dtbApplDetail = null;
            string strSQL = c_strQueryApplDetail_SQL + " where application_id_chr='" + p_strApplID + "' and status_int>0";
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbApplDetail);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据病人的诊疗卡号，查询出所有的未完成的检验申请。这里有一个样本采集的过滤条件。
        [AutoComplete]
        //这里，过滤条件strFilter表示PStatus_int字段的条件。如"=1"，或者">1"，"in (1,2,3)"等。
        public long m_lngGetApplicationInfoByPtCard(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDate, string strToDate,
            string strPtCardId, string strFilter, out System.Data.DataTable dtbAppInfo)
        {
            long lngRes = 0;
            string strPtCond = (strPtCardId == "") ? "1=1" : @"a.patientid_chr=(select patientid_chr from t_bse_patientcard where patientcardid_chr='" + strPtCardId + "')";
            string strSQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
												a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
												a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
												a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
												a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
												a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
												d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr patType
												FROM t_opr_lis_application a,
													t_bse_employee b,
													t_bse_deptbaseinfo c,
													t_bse_employee d,
													t_aid_icd10 e,
													t_aid_dict f
												WHERE a.operator_id_chr = b.empid_chr(+)
												AND a.appl_deptid_chr = c.deptid_chr(+)
												AND a.appl_empid_chr = d.empid_chr(+)
												AND a.icdcode_chr = e.icdcode_chr(+)
												AND a.patient_type_id_chr = f.dictid_chr(+)
												AND f.dictkind_chr(+) = '61'
												AND a.application_dat BETWEEN TO_DATE('" + strFromDate + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + strToDate
                + "','yyyy-mm-dd hh24:mi:ss') AND " + strPtCond
                + " AND a.pstatus_int" + strFilter;
            dtbAppInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
                objHRPSvc.Dispose();
            }
            catch (System.Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据申请号，获得所有的检查组。
        [AutoComplete]
        public long m_lngGetApplicationContent(System.Security.Principal.IPrincipal p_objPrincipal,
            string strAppId, out string[] strGroupIdArr)
        {
            long lngRes = 0;
            strGroupIdArr = null;
            string strSQL = @"select groupid_chr from t_opr_lis_application_detail where APPLICATION_ID_CHR='"
                + strAppId + @"' and MODIFY_DAT=(select MODIFY_DAT from t_opr_lis_application where APPLICATION_ID_CHR='"
                + strAppId + @"' and PStatus_int>0)"; //要保证申请表上一个申请号只有一条状态不等于0的记录。
            System.Data.DataTable dtbTmp = new System.Data.DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbTmp);
                objHRPSvc.Dispose();
                strGroupIdArr = new string[dtbTmp.Rows.Count];
                for (int i = 0; i < dtbTmp.Rows.Count; i++)
                {
                    strGroupIdArr[i] = dtbTmp.Rows[i][0].ToString();
                }
            }
            catch (System.Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据申请号，获得所有需要的样本列表。
        //这里假定所有的组都可以在t_lis_aid_group_sample表中找到样本要求。如果在t_lis_aid_group_sample表中
        //只有没有子组的检验项目的样本要求，则要先进行组的分析。相关方法见clsCheckGroupSvc类。
        [AutoComplete]
        public long m_lngGetApplicationSample(System.Security.Principal.IPrincipal p_objPrincipal,
            string strAppId, out System.Data.DataTable dtbAppSample)
        {
            long lngRes = 0;
            string strSQL = @"select c.GROUPNAME_VCHR,a.SAMPLE_TYPE_ID_CHR,b.SAMPLE_TYPE_DESC_VCHR,a.SAMPLE_ORD_INT,a.SAMPLE_QTY_CHR,
                       a.SAMPLE_VALID_TIME from t_aid_lis_group_sample a, t_aid_lis_sampletype b,t_aid_lis_check_group c
                       where a.GROUPID_CHR = c.GROUPID_CHR and b.SAMPLE_TYPE_ID_CHR=a.SAMPLE_TYPE_ID_CHR and a.GROUPID_CHR in (select 
                       GROUPID_CHR from t_opr_lis_application_detail where APPLICATION_ID_CHR='" + strAppId + @"' and
				       MODIFY_DAT = (select MODIFY_DAT from t_opr_lis_application where APPLICATION_ID_CHR='" + strAppId + @"' and
					   PStatus_int>0))";
            dtbAppSample = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppSample);
                objHRPSvc.Dispose();
            }
            catch (System.Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据标本上的条码号，查询该标本所对应的检验申请的所有检验项目
        [AutoComplete]
        public long m_lngGetApplCheckGroupBySampleBarCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleBarCode, out DataTable p_dtbCheckGroupList)
        {
            long lngRes = 0;
            string strSQL = @"SELECT distinct t1.application_id_chr, t1.groupid_chr,t4.GROUPNAME_VCHR
							FROM t_opr_lis_application_item t1,
								t_opr_lis_application t2,
								t_opr_lis_sample t3,
								t_aid_lis_check_group t4
							WHERE t3.application_form_no_chr = t2.application_form_no_chr
							AND t1.application_id_chr = t2.application_id_chr
							AND t1.modify_dat = t2.modify_dat
							AND t2.pstatus_int > 0
							AND t4.groupid_chr = t1.groupid_chr
							AND t3.barcode_vchr='" + p_strSampleBarCode + @"'";


            p_dtbCheckGroupList = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckGroupList);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。

            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号（指申请单上贴得条码号或者印刷的号码，不是系统内部为每个申请指定的号码）查出对应的检验申请的资料
        [AutoComplete]
        public long m_lngGetApplicationInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objApplMainVO)
        {
            long lngRes = 0;
            p_objApplMainVO = null;
            string strSQL = @"select APPLICATION_ID_CHR,MODIFY_DAT,patientid_chr,application_dat
							sex_chr,patient_name_vchr,patient_subno_chr,age_chr,patient_type_chr,diagnose_vchr
							bedno_chr,icd_vchr,patientcardid_chr,application_form_no_chr,operator_id_chr,
							appl_empid_chr,appl_deptid_chr,Summary_Vchr,PStatus_int
							from t_opr_lis_application where and PStatus_int>0 application_form_no_chr='" + p_strApplFormNo + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.DataTable objDT_AppList = null;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objDT_AppList);
                if (lngRes > 0)
                {
                    if (objDT_AppList.Rows.Count == 1)
                    {
                        p_objApplMainVO = new clsVOConstructor().m_objConstructAppMainVO(objDT_AppList.Rows[0]);
                    }
                }
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号（指申请单上贴得条码号或者印刷的号码，不是系统内部为每个申请指定的号码）查出对应的检验申请的资料
        [AutoComplete]
        public long m_lngGetApplicationInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = c_strQueryAppl_SQL + @" and a.pstatus_int > 0 AND a.application_form_no_chr = '" + p_strApplFormNo + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据日期范围，查询指定日期范围(按申请日期、采样日期、检验日期、审核日期)之内的全部申请资料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期; 2-检验日期、审核日期</param>
        /// <param name="p_strDateFieldName"></param>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="p_dtbAppl"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplInfoByDateRange(System.Security.Principal.IPrincipal p_objPrincipal, int p_intDateQueryType, string p_strDateFieldName, System.DateTime p_dtBegin, System.DateTime p_dtEnd, string strPstatus, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = null;
            if (p_intDateQueryType == 0)//按申请日期查询
            {
                strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
						sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
						patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
						patientcardid_chr, application_form_no_chr, operator_id_chr,
						appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int, EMERGENCY_INT, SPECIAL_INT
						FROM t_opr_lis_application
						WHERE pstatus_int > 0
						AND pstatus_int " + strPstatus + @"
						AND " + p_strDateFieldName + " BETWEEN ? AND ?";

            }
            else if (p_intDateQueryType == 1)//按采样日期查询
            {
                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
						t1.patientcardid_chr, t1.application_form_no_chr,
						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
						t1.summary_vchr
						FROM t_opr_lis_application t1,
								t_opr_lis_sample t2,
								t_opr_lis_req_check_detail t3
						WHERE t1.pstatus_int > 0
							AND t2.status_int > 0
							AND pstatus_int " + strPstatus + @"
							AND t2.application_form_no_chr = t1.application_form_no_chr
							AND t3.sample_id_chr = t2.sample_id_chr							
							AND t2.sampling_date_dat BETWEEN ? AND ?
						ORDER BY application_id_chr";

            }
            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
            {
                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
						t1.patientcardid_chr, t1.application_form_no_chr,
						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
						t1.summary_vchr
						FROM t_opr_lis_application t1,
								t_opr_lis_sample t2,
								t_opr_lis_check_result t3
						WHERE  t1.pstatus_int > 0
							AND t2.status_int > 0			
							AND t3.status_int > 0
							AND t2.application_form_no_chr = t1.application_form_no_chr
							AND t3.sample_id_chr = t2.sample_id_chr								
							AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
						ORDER BY t1.application_id_chr";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objAppArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objAppArr);
                objAppArr[0].Value = p_dtBegin;
                objAppArr[1].Value = p_dtEnd;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objAppArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 按申请日期范围、PStatus_int状态查询申请单信息
        [AutoComplete]
        public long m_lngGetApplByApplDateRange(System.Security.Principal.IPrincipal p_objPrincipal, System.DateTime p_dtBegin, System.DateTime p_dtEnd, string p_strStatusFilter, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;

            p_dtBegin = Convert.ToDateTime(p_dtBegin.ToString("yyyy-MM-dd 00:00:00"));
            p_dtEnd = Convert.ToDateTime(p_dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
            string strSQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
							a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
							a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
							a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
							a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
							a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
							d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr pattype,a.EMERGENCY_INT,
							a.SPECIAL_INT
							FROM t_opr_lis_application a,
								t_bse_employee b,
								t_bse_deptbaseinfo c,
								t_bse_employee d,
								t_aid_icd10 e,
								t_aid_dict f
							WHERE a.operator_id_chr = b.empid_chr(+)
							AND a.appl_deptid_chr = c.deptid_chr(+)
							AND a.appl_empid_chr = d.empid_chr(+)
							AND a.icdcode_chr = e.icdcode_chr(+)
							AND a.patient_type_id_chr = f.dictid_chr(+)
							AND f.dictkind_chr(+) = '61'
							AND a.application_dat BETWEEN ? AND ?
							AND a.pstatus_int " + p_strStatusFilter + " order by a.application_id_chr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objAppArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objAppArr);
                objAppArr[0].Value = p_dtBegin;
                objAppArr[1].Value = p_dtEnd;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objAppArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据申请号（系统内部给定的申请唯一号）查询该申请所有检验项目（不含有子组）资料(含SampleID)
        [AutoComplete]
        public long m_lngGetApplicationCheckInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormID, out System.Data.DataTable p_dtbAppCheckInfo)
        {
            long lngRes = 0;
            p_dtbAppCheckInfo = null;

            string strSQL = @"SELECT distinct t2.sample_id_chr , t1.groupid_chr , t3.groupname_vchr,t3.print_category_id_chr
								FROM t_opr_lis_req_check_detail t1,
									t_opr_lis_sample t2,
									t_aid_lis_check_group t3
								WHERE t1.sample_id_chr = t2.sample_id_chr
								AND t1.groupid_chr = t3.groupid_chr
								AND t2.status_int > 0
								AND t2.application_form_no_chr ='" + p_strApplFormID + "'";


            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppCheckInfo);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异
            }
            return lngRes;
        }
        #endregion

        #region 根据t_opr_lis_application某一字段和各种日期范围(申请日期、采样日期、检验日期、审核日期)查询所有申请资料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFieldName"></param>
        /// <param name="p_strFieldValue"></param>
        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期 2-检验日期、审核日期</param>
        /// <param name="p_strDateFieldName"></param>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="p_dtbAppl"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplInfoByFieldValue(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFieldName, string p_strFieldValue, int p_intDateQueryType, string p_strDateFieldName, DateTime p_dtBegin, DateTime p_dtEnd, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = null;

            if (p_intDateQueryType == 0)//按申请日期查询
            {
                strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
						sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
						patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
						patientcardid_chr, application_form_no_chr, operator_id_chr,
						appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int
						FROM t_opr_lis_application
						WHERE pstatus_int > 0
						AND " + p_strFieldName + " = '" + p_strFieldValue + @"'
						AND " + p_strDateFieldName + @" BETWEEN ? AND ?
						ORDER BY application_id_chr";

            }
            else if (p_intDateQueryType == 1)//按采样日期查询
            {
                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
						t1.patientcardid_chr, t1.application_form_no_chr,
						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
						t1.summary_vchr
						FROM t_opr_lis_application t1,
								t_opr_lis_sample t2,
								t_opr_lis_req_check_detail t3
						WHERE t1.pstatus_int > 0
							and t1." + p_strFieldName + " = '" + p_strFieldValue + @"'
							AND t2.status_int > 0
							AND t2.application_form_no_chr = t1.application_form_no_chr
							AND t3.sample_id_chr = t2.sample_id_chr							
							AND t2.sampling_date_dat BETWEEN '' AND ''
						ORDER BY application_id_chr";
            }
            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
            {
                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
                t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
                t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
                t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
                t1.patientcardid_chr, t1.application_form_no_chr,
                t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
                t1.summary_vchr
				FROM t_opr_lis_application t1,
						t_opr_lis_sample t2,
						t_opr_lis_check_result t3
				WHERE t1." + p_strFieldName + " = '" + p_strFieldValue + @"'
					AND t1.pstatus_int > 0
					AND t2.application_form_no_chr = t1.application_form_no_chr
					AND t3.sample_id_chr = t2.sample_id_chr						
					AND t2.status_int > 0			
					AND t3.status_int > 0					
					AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
				ORDER BY t1.application_id_chr";
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objApplArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objApplArr);

                objApplArr[0].Value = p_dtBegin;
                objApplArr[1].Value = p_dtEnd;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objApplArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异             
            }
            return lngRes;
        }
        #endregion

        #region  根据GroupID(无子组)和各种日期范围(申请日期、采样日期、检验日期、审核日期)查询所有申请资料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strGroupID"></param>
        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期 2-检验日期、审核日期</param>
        /// <param name="p_strDateFieldName"></param>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="p_dtbAppl"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplInfoByFieldValue(System.Security.Principal.IPrincipal p_objPrincipal, string p_strGroupID, int p_intDateQueryType, string p_strDateFieldName, System.DateTime p_dtBegin, System.DateTime p_dtEnd, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = null;

            if (p_intDateQueryType == 0)//按申请日期查询
            {
                strSQL = @"SELECT distinct t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr, t1.patientcardid_chr,
						t1.application_form_no_chr, t1.operator_id_chr, t1.appl_empid_chr,
						t1.appl_deptid_chr, t1.summary_vchr
						FROM t_opr_lis_application t1,
							t_opr_lis_sample t2,
							t_opr_lis_req_check_detail t3
						WHERE t2.application_form_no_chr = t1.application_form_no_chr
						AND t1.pstatus_int > 0
						AND t2.status_int > 0
						AND t3.sample_id_chr = t2.sample_id_chr
						AND t3.groupid_chr = '" + p_strGroupID + @"'						
						AND t1.application_dat BETWEEN ? AND ? 
						ORDER BY application_id_chr";

            }
            else if (p_intDateQueryType == 1)//按采样日期查询
            {
                strSQL = @"SELECT distinct t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr, t1.patientcardid_chr,
						t1.application_form_no_chr, t1.operator_id_chr, t1.appl_empid_chr,
						t1.appl_deptid_chr, t1.summary_vchr
						FROM t_opr_lis_application t1,
							t_opr_lis_sample t2,
							t_opr_lis_req_check_detail t3
						WHERE t2.application_form_no_chr = t1.application_form_no_chr
						AND t1.pstatus_int > 0
						AND t2.status_int > 0						
						AND t3.sample_id_chr = t2.sample_id_chr
						AND t3.groupid_chr = '" + p_strGroupID + @"'
						AND t2.sampling_date_dat BETWEEN ? AND ? 
						ORDER BY application_id_chr";
            }
            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
            {
                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
						t1.patientcardid_chr, t1.application_form_no_chr,
						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
						t1.summary_vchr
						FROM t_opr_lis_application t1,
								t_opr_lis_sample t2,
								t_opr_lis_check_result t3
						WHERE t2.application_form_no_chr = t1.application_form_no_chr
							AND t1.pstatus_int > 0
							AND t2.status_int > 0	
							AND t3.sample_id_chr = t2.sample_id_chr
							AND t3.groupid_chr = '" + p_strGroupID + @"'				
							AND t3.status_int > 0							
							AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
						ORDER BY t1.application_id_chr";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                System.Data.IDataParameter[] objApplArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objApplArr);
                objApplArr[0].Value = p_dtBegin;
                objApplArr[1].Value = p_dtEnd;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objApplArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异

            }
            return lngRes;
        }
        #endregion

        #region 获取病人基本信息
        /// <summary>
        /// 通过住院号，获取病人信息和诊断医生信息
        /// </summary>
        /// <param name="p_pbjprincipal"></param>
        /// <param name="p_InHospitalID"></param>
        /// <param name="objPatientVO"></param>
        /// <param name="objBihRegisterVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindPatientInfoByInpatientID(System.Security.Principal.IPrincipal p_pbjprincipal, string p_InHospitalID, out DataTable p_dvbResult)
        {
            p_dvbResult = null;
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_pbjprincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngFindPatientInfoByInpatientID");
            if (lngRes < 0)
                return lngRes;
            string strSQL = "";
            clsHRPTableService objHRPServ = null;
            try
            {
                strSQL = @"select a.patientid_chr,
       a.lastname_vchr patientname,
       a.sex_chr,
       a.birth_dat,
       b.patientcardid_chr,
       c.code_chr,
       d.lastname_vchr casedoctorname,
       t.deptid_chr,
       t.diagnose_vchr,
       t.casedoctor_chr,
       t.inpatient_dat,
       e.deptname_vchr
  from t_bse_patient      a,
       t_opr_bih_register t,
       t_bse_patientcard  b,
       t_bse_bed          c,
       t_bse_employee     d,
       t_bse_deptdesc     e
 where a.patientid_chr = b.patientid_chr(+)
   and a.patientid_chr = t.patientid_chr(+)
   and t.bedid_chr = c.bedid_chr(+)
   and t.casedoctor_chr = d.empid_chr(+)
   and t.deptid_chr = e.deptid_chr(+)
   and t.status_int = 1
   and a.inpatientid_chr = ? ";
                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_InHospitalID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dvbResult, objDPArr);
                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_InHospitalID = null;
            }
            return lngRes;
        }
        #endregion
    }
}
