using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using System.EnterpriseServices;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility; //Utility.dll
using Microsoft.VisualBasic;
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQueryCheckResultSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region SQL语句

        private const string c_strAddNewCheckResult_SQL = @"insert into t_opr_lis_check_result(modify_dat, 
														groupid_chr, 
														check_item_id_chr, 
														sample_id_chr, 
														result_vchr, 
														unit_vchr, 
														deviceid_chr, 
														device_check_item_name_vchr, 
														refrange_vchr, 
														check_item_name_vchr, 
														check_item_english_name_vchr, 
														min_val_dec, 
														max_val_dec, 
														abnormal_flag_chr, 
														check_dat, 
														clinicapp_vchr, 
														memo_vchr, 
														confirm_dat, 
														pointliststr_vchr, 
														summary_vchr, 
														graph_img, 
														status_int, 
														checker1_chr, 
														checker2_chr, 
														confirm_person_chr, 
														operator_id_chr, 
														check_deptid_chr, 
														graph_format_name_vchr, 
														is_graph_result_num)
						values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        #endregion

        #region 批量数据调整

        #region 根据条件查询T_OPR_LIS_RESULT_IMPORT_REQ表的信息
        [AutoComplete]
        public long m_lngGetResultImportReqByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID,
            string p_strCheckDatFrom, string p_strCheckDatTo, out clsLisResultImportReq_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetResultImportReqByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"SELECT a.*
								FROM t_opr_lis_result_import_req a 
							   WHERE 1=1 ";
            string strSQL_CheckDatFrom = " AND a.check_dat >= ? ";
            string strSQL_CheckDatTo = " AND a.check_dat <= ? ";
            string strSQL_DeviceID = "AND a.deviceid_chr = ? ";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造
            if (p_strDeviceID != null && p_strDeviceID.Trim() != "")
            {
                arlSQL.Add(strSQL_DeviceID);
                arlParm.Add(p_strDeviceID);
            }
            if (p_strCheckDatFrom != null && Microsoft.VisualBasic.Information.IsDate(p_strCheckDatFrom.Trim()))
            {
                arlSQL.Add(strSQL_CheckDatFrom);
                arlParm.Add(DateTime.Parse(p_strCheckDatFrom.Trim()));
            }
            if (p_strCheckDatTo != null && Microsoft.VisualBasic.Information.IsDate(p_strCheckDatTo.Trim()))
            {
                arlSQL.Add(strSQL_CheckDatTo);
                arlParm.Add(DateTime.Parse(p_strCheckDatTo.Trim()));
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            strSQL += " ORDER BY a.IMPORT_REQ_INT";

            int intParmCount = arlSQL.Count;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

            for (int i = 0; i < intParmCount; i++)
            {
                objDPArr[i].Value = arlParm[i];
            }

            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisResultImportReq_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsLisResultImportReq_VO();
                        p_objResultArr[i1].m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strDEVICE_SAMPLEID_CHR = dtbResult.Rows[i1]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDEVICEID_CHR = dtbResult.Rows[i1]["DEVICEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_intIS_AUTOBIND_ENDPOINTER_INT = Convert.ToInt32(dtbResult.Rows[i1]["IS_AUTOBIND_ENDPOINTER_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strIMPORT_REQ_INT = dtbResult.Rows[i1]["IMPORT_REQ_INT"].ToString().Trim();
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
        #endregion

        #endregion

        #region 查询得到  CheckResultVO

        /// <summary>
        /// 查询得到  CheckResultVO
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSampleID"></param>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objResultVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckResultVO(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strSampleID, string p_strCheckItemID, out clsCheckResult_VO p_objResultVO)
        {
            long lngRes = 0;
            p_objResultVO = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetCheckResultVO");
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;

            string strSQL = @"SELECT t1.*
								FROM t_opr_lis_check_result t1
							   WHERE t1.sample_id_chr = ?
								 AND t1.check_item_id_chr = ?
								 AND t1.status_int > 0";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strSampleID;
                objDPArr[1].Value = p_strCheckItemID;

                DataTable dtbCheckResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbCheckResult, objDPArr);

                if (lngRes > 0 && dtbCheckResult != null && dtbCheckResult.Rows.Count != 0)
                {
                    p_objResultVO = new clsVOConstructor().m_objConstructCheckResultVO(dtbCheckResult.Rows[0]);
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

        #region 查询得到  CheckResultTable

        /// <summary>
        /// 查询得到  CheckResultTable 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strReportID"></param>
        /// <param name="p_strGroupID"></param>
        /// <param name="p_blnRealResult"></param>
        /// <param name="p_dtbResultList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckResultTable(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strAppID, string p_strOringinDate, bool p_blnRealResult, out DataTable p_dtbResultList)
        {
            long lngRes = 0;
            p_dtbResultList = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetCheckResultTable");
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;

            try
            {
                DateTime.Parse(p_strOringinDate);
            }
            catch
            {
                p_strOringinDate = "1900-01-01 00:00:00";
            }

            string strSQL = "";

            #region SQL
            if (p_blnRealResult)
            {
                strSQL = @"select t1.sample_id_chr,
       t3.check_item_id_chr,
       t5.print_seq_int                group_seq,
       t7.item_print_seq_int           item_seq,
       t6.check_category_id_chr,
       t6.sampletype_vchr,
       t6.unit_chr                     item_unit_chr,
       t6.rptno_chr,
       t6.check_item_english_name_vchr item_english_name,
       t6.formula_vchr,
       t6.resulttype_chr,
       t6.is_calculated_chr,
       t6.alarm_low_val_vchr,
       t6.alarm_up_val_vchr,
       t6.alert_value_range_vchr,
       null                            alert_flag,
       t4.device_check_item_name_vchr  device_item_name_vchr,
       t4.*,
       t1.status_int                   samplestatus,
       0                               new_result,
       0                               modify_flag,
       null                            raw_result_vchr,
       null                            eff_caculate_id_chr,
       0                               invisible,
       t1.appl_deptid_chr           as applyDeptId 
  from t_opr_lis_sample t1
 inner join t_opr_lis_app_sample t2
    on t1.sample_id_chr = t2.sample_id_chr
 inner join t_opr_lis_app_check_item t3
    on t1.application_id_chr = t3.application_id_chr
   and t2.sample_group_id_chr = t3.sample_group_id_chr
   and t2.report_group_id_chr = t3.report_group_id_chr
 inner join t_opr_lis_check_result t4
    on t1.sample_id_chr = t4.sample_id_chr
   and t4.check_item_id_chr = t3.check_item_id_chr
   and t4.status_int > 0
   and t4.groupid_chr=t3.sample_group_id_chr
 inner join t_aid_lis_report_group_detail t5
    on t2.sample_group_id_chr = t5.sample_group_id_chr
   and t2.report_group_id_chr = t5.report_group_id_chr
 inner join t_bse_lis_check_item t6
    on t3.check_item_id_chr = t6.check_item_id_chr
 inner join v_lis_bse_sample_group_items t7
    on t3.check_item_id_chr = t7.check_item_id_chr
   and t7.sample_group_id_chr = t2.sample_group_id_chr
 where t1.application_id_chr = ?
   and t1.status_int > 0
";//t_bse_lis_device_check_item t8//AND t7.device_check_item_id_chr = t8.device_check_item_id_chr//
            }//AND t7.device_model_id_chr = t8.device_model_id_chr
            else
            {
                strSQL = @"select t1.sample_id_chr,
       t3.check_item_id_chr,
       t5.print_seq_int group_seq,
       t7.item_print_seq_int item_seq,
       t6.check_category_id_chr,
       t6.sampletype_vchr,
       t6.unit_chr item_unit_chr,
       t6.rptno_chr,
       t6.check_item_english_name_vchr item_english_name,
       t6.formula_vchr,
       t6.resulttype_chr,
       t6.is_calculated_chr,
       t6.alarm_low_val_vchr,
       t6.alarm_up_val_vchr,
       t6.alert_value_range_vchr,
       null alert_flag,
       f_getitemref_low(t3.check_item_id_chr,
                        trim(t1.age_chr),
                        trim(t1.sex_chr),
                        'menses') min_val_dec,
       f_getitemref_up(t3.check_item_id_chr,
                       trim(t1.age_chr),
                       trim(t1.sex_chr),
                       'menses') max_val_dec,
       f_getitemref_range(t3.check_item_id_chr,
                          trim(t1.age_chr),
                          trim(t1.sex_chr),
                          'menses') refrange_vchr,
       
       t3.sample_group_id_chr         groupid_chr,
       t8.value_vchr                  result_vchr,
       t9.device_check_item_name_vchr device_item_name_vchr,
       t4.*,
       t1.status_int                  samplestatus,
       1                              new_result,
       0                              modify_flag,
       null                           raw_result_vchr,
       null                           eff_caculate_id_chr,
       0                              invisible,
       t1.appl_deptid_chr           as applyDeptId 
  from t_opr_lis_sample t1
 inner join t_opr_lis_app_sample t2
    on t1.sample_id_chr = t2.sample_id_chr
 inner join t_opr_lis_app_check_item t3
    on t1.application_id_chr = t3.application_id_chr
   and t2.sample_group_id_chr = t3.sample_group_id_chr
   and t2.report_group_id_chr = t3.report_group_id_chr
  left outer join t_opr_lis_check_result t4
    on t1.sample_id_chr = t4.sample_id_chr
    and t3.check_item_id_chr=t4.check_item_id_chr
 inner join t_aid_lis_report_group_detail t5
    on t2.sample_group_id_chr = t5.sample_group_id_chr
   and t2.report_group_id_chr = t5.report_group_id_chr
 inner join t_bse_lis_check_item t6
    on t3.check_item_id_chr = t6.check_item_id_chr
  left outer join v_lis_bse_sample_group_items t7
    on t3.check_item_id_chr = t7.check_item_id_chr
   and t7.sample_group_id_chr = t3.sample_group_id_chr
  left outer join v_lis_aid_check_item_default t8
    on t3.check_item_id_chr = t8.check_item_id_chr
  left outer join (select t70.check_item_id_chr,
                          t71.device_check_item_name_vchr
                     from t_bse_lis_check_item_dev_item t70,
                          t_bse_lis_device_check_item   t71
                    where t71.device_model_id_chr = t70.device_model_id_chr
                      and t71.device_check_item_id_chr =
                          t70.device_check_item_id_chr) t9
    on t9.check_item_id_chr = t3.check_item_id_chr
 where t1.application_id_chr = ?
   and t1.status_int > 0";

            }
            #endregion

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_blnRealResult)
                {
                    IDataParameter[] objDPArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);

                    objDPArr[0].Value = p_strAppID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResultList, objDPArr);
                    objHRPSvc.Dispose();
                }
                else
                {
                    IDataParameter[] objDPArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strAppID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResultList, objDPArr);
                    objHRPSvc.Dispose();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
            }
            return lngRes;
        }
        #endregion

        #region 打印时报告单查询

        #region 批量打印报告单
        [AutoComplete]
        public long m_lngGetBatchReportDataByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFromSampleID,
            string p_strToSampleID, string p_strFromConfirmDat, string p_strToConfirmDat, string p_strReportGroupID, out clsLisBatchReport_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetBatchReportDataByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"SELECT DISTINCT t1.sex_chr,t1.patient_name_vchr, t2.*, t4.deptname_vchr, 
									 t7.lastname_vchr AS applyer,
									 t9.report_group_name_vchr,t11.check_dat
								FROM t_opr_lis_sample t1,
									 t_opr_lis_app_report t2,
									 t_opr_lis_app_sample t3,
									 t_bse_deptdesc t4,
									 t_bse_employee t7,
									 t_aid_lis_report_group t9,
									 (SELECT t10.check_dat,t10.sample_id_chr
										FROM t_opr_lis_device_relation t10
									   WHERE t10.status_int > 0) t11
							   WHERE t2.report_group_id_chr = t3.report_group_id_chr
								 AND t2.application_id_chr = t3.application_id_chr
								 AND t3.sample_id_chr = t1.sample_id_chr
								 AND t1.appl_empid_chr = t7.empid_chr(+)
								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
								 AND t2.report_group_id_chr = t9.report_group_id_chr
								 AND t1.status_int = 6
								 AND t2.status_int > 0
								 AND t1.sample_id_chr = t11.sample_id_chr(+)";
            string strSQL_SampleNOFrom = " AND t1.sample_id_chr >= ? ";
            string strSQL_SampleNOTo = " AND t1.sample_id_chr <= ? ";
            string strSQL_ComfirmDatFrom = " AND t2.CONFIRM_DAT >= ? ";
            string strSQL_ConfirmDatTo = " AND t2.CONFIRM_DAT <= ? ";
            string strSQL_ReportGroupID = " AND t2.report_group_id_chr = ? ";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造
            if (p_strFromSampleID != null && p_strFromSampleID.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_SampleNOFrom);
                arlParm.Add(p_strFromSampleID);
            }
            if (p_strToSampleID != null && p_strToSampleID.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_SampleNOTo);
                arlParm.Add(p_strToSampleID);
            }
            if (p_strFromConfirmDat != null && Microsoft.VisualBasic.Information.IsDate(p_strFromConfirmDat.Trim()))
            {
                arlSQL.Add(strSQL_ComfirmDatFrom);
                arlParm.Add(DateTime.Parse(p_strFromConfirmDat.Trim()));
            }
            if (p_strToConfirmDat != null && Microsoft.VisualBasic.Information.IsDate(p_strToConfirmDat.Trim()))
            {
                arlSQL.Add(strSQL_ConfirmDatTo);
                arlParm.Add(DateTime.Parse(p_strToConfirmDat.Trim()));
            }
            if (p_strReportGroupID != null && p_strReportGroupID.Trim() != "")
            {
                arlSQL.Add(strSQL_ReportGroupID);
                arlParm.Add(p_strReportGroupID.Trim());
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            strSQL += " ORDER BY t11.check_dat";

            int intParmCount = arlSQL.Count;

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
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisBatchReport_VO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = new clsLisBatchReport_VO();
                        p_objResultArr[i].strApplyDept = dtbResult.Rows[i]["deptname_vchr"].ToString().Trim();
                        p_objResultArr[i].strConfirmDat = dtbResult.Rows[i]["CONFIRM_DAT"].ToString().Trim();
                        p_objResultArr[i].strPatientName = dtbResult.Rows[i]["patient_name_vchr"].ToString().Trim();
                        p_objResultArr[i].strReportGroupName = dtbResult.Rows[i]["report_group_name_vchr"].ToString().Trim();
                        p_objResultArr[i].strSex = dtbResult.Rows[i]["sex_chr"].ToString().Trim();

                        string strSQL_BaseInfo = @"SELECT t1.*, t2.*, t4.deptname_vchr, t5.lastname_vchr AS reportor,
														  t6.lastname_vchr AS confirmer, t7.lastname_vchr AS applyer,
														  t8.sample_type_desc_vchr, t9.report_group_name_vchr,
														  t11.device_sampleid_chr, t21.sign_grp as reportorsign,
                                                          t22.sign_grp as confirmersign, t23.sign_grp as applyersign 
													 FROM t_opr_lis_sample t1,
														  t_opr_lis_app_report t2,
														  t_opr_lis_app_sample t3,
														  T_BSE_DEPTDESC t4,
														  t_bse_employee t5,
														  t_bse_employee t6,
														  t_bse_employee t7,
														  t_aid_lis_sampletype t8,
														  t_aid_lis_report_group t9,
														  (SELECT t10.device_sampleid_chr,t10.sample_id_chr
															 FROM t_opr_lis_device_relation t10
														    WHERE t10.status_int > 0) t11,
                                                         t_bse_empsign t21,
                                                         t_bse_empsign t22,
                                                         t_bse_empsign t23 
													WHERE t2.report_group_id_chr = t3.report_group_id_chr
													  AND t2.application_id_chr = t3.application_id_chr
													  AND t3.sample_id_chr = t1.sample_id_chr
													  AND t2.reportor_id_chr = t5.empid_chr(+)
													  AND t2.confirmer_id_chr = t6.empid_chr(+)
													  AND t1.appl_empid_chr = t7.empid_chr(+)
													  AND t1.appl_deptid_chr = t4.deptid_chr(+)
													  AND t1.sample_type_id_chr = t8.sample_type_id_chr(+)
													  AND t2.report_group_id_chr = t9.report_group_id_chr
													  AND t1.sample_id_chr = t11.sample_id_chr(+)
                                                      and t5.empid_chr = t21.empid_chr(+)
                                                      and t6.empid_chr = t22.empid_chr(+)
                                                      and t7.empid_chr = t23.empid_chr(+)
													  AND t1.status_int = 6
													  AND t2.status_int > 0
													  AND t2.report_group_id_chr = '" + dtbResult.Rows[i]["report_group_id_chr"].ToString().Trim() + @"'
													  AND t2.application_id_chr = '" + dtbResult.Rows[i]["application_id_chr"].ToString().Trim() + @"'";

                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL_BaseInfo, ref p_objResultArr[i].m_dtbReportBaseInfo);

                        if (lngRes > 0 && p_objResultArr[i].m_dtbReportBaseInfo != null && p_objResultArr[i].m_dtbReportBaseInfo.Rows.Count > 0)
                        {

                            string strSQL_Result = @"SELECT a.*, d.print_title_vchr, e.print_seq_int AS report_print_seq_int,
																f.print_seq_int AS sample_print_seq_int, g.rptno_chr
														   FROM t_opr_lis_check_result a,
																t_opr_lis_app_report b,
																t_opr_lis_app_sample c,
																t_aid_lis_report_group d,
																t_aid_lis_report_group_detail e,
																t_aid_lis_sample_group_detail f,
																t_bse_lis_check_item g
														  WHERE a.groupid_chr = b.report_group_id_chr
															AND b.report_group_id_chr = c.report_group_id_chr
															AND b.application_id_chr = c.application_id_chr
															AND a.groupid_chr = d.report_group_id_chr
															AND d.report_group_id_chr = e.report_group_id_chr
															AND e.sample_group_id_chr = f.sample_group_id_chr
															AND c.sample_group_id_chr = f.sample_group_id_chr
															AND a.check_item_id_chr = g.check_item_id_chr
															AND a.check_item_id_chr = f.check_item_id_chr
															AND a.sample_id_chr = c.sample_id_chr
															AND a.status_int > 0
															AND b.status_int > 0
															AND b.report_group_id_chr = '" + dtbResult.Rows[i]["report_group_id_chr"].ToString().Trim() + @"'
															AND b.application_id_chr = '" + dtbResult.Rows[i]["application_id_chr"].ToString().Trim() + @"'";
                            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL_Result, ref p_objResultArr[i].m_dtbCheckResult);

                        }
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


        #region 根据条件查询批量打印的报告单列表
        [AutoComplete]
        public long m_lngGetLisBatchReportListByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFromSampleID,
            string p_strToSampleID, string p_strFromConfirmDat, string p_strToConfirmDat, string p_strReportGroupID, string p_strPatientType, out clsLisBatchReportList_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetLisBatchReportListByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"select distinct t1.sex_chr, t1.patient_name_vchr, 
                                        t2.application_id_chr, t2.report_group_id_chr, t2.modify_dat,
                                       t2.summary_vchr, t2.operator_id_chr, t2.status_int, t2.report_dat,
                                       t2.reportor_id_chr, t2.confirm_dat, t2.confirmer_id_chr,
                                       t2.xml_summary_vchr, t2.annotation_vchr, t2.xml_annotation_vchr, 
                                        t4.deptname_vchr, t7.lastname_vchr as applyer, t9.report_group_name_vchr,
										t2.report_dat,t1.application_form_no_chr
								from t_opr_lis_application t1,
										t_opr_lis_app_report t2,
										t_opr_lis_app_sample t3,
										t_bse_deptdesc t4,
										t_bse_employee t7,
										t_aid_lis_report_group t9
								where t2.report_group_id_chr = t3.report_group_id_chr
									and t2.application_id_chr = t3.application_id_chr
									and t2.application_id_chr = t1.application_id_chr
									and t1.appl_empid_chr = t7.empid_chr(+)
									and t1.appl_deptid_chr = t4.deptid_chr(+)
									and t2.report_group_id_chr = t9.report_group_id_chr
									and t2.status_int = 2
									and t1.pstatus_int > 0";
            //			string strSQL_CheckNOFrom = " AND t1.application_form_no_chr >= ? ";
            //			string strSQL_CheckNOTo = " AND t1.application_form_no_chr <= ? ";
            //			string strSQL_ComfirmDatFrom = " AND t2.CONFIRM_DAT >= ? ";
            //			string strSQL_ConfirmDatTo = " AND t2.CONFIRM_DAT <= ? ";
            //			string strSQL_ReportGroupID = " AND t2.report_group_id_chr = ? ";
            string strSQL_CheckNOFrom = " and t1.application_form_no_chr >= '" + p_strFromSampleID + @"'";
            string strSQL_CheckNOTo = " and t1.application_form_no_chr <= '" + p_strToSampleID + @"'";
            string strSQL_ComfirmDatFrom = " and t2.confirm_dat >= TO_DATE('" + p_strFromConfirmDat + @"','yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ConfirmDatTo = " and t2.confirm_dat <= TO_DATE('" + p_strToConfirmDat + @"','yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ReportGroupID = " and t2.report_group_id_chr = '" + p_strReportGroupID + @"'";
            string strSQL_PatientType_Out = " and t1.patient_type_id_chr='2'";
            string strSQL_PatientType_In = " and t1.patient_type_id_chr='1'";
            #endregion

            //			ArrayList arlSQL = new ArrayList();
            //			ArrayList arlParm = new ArrayList();

            #region 构造
            if (p_strFromSampleID != null && p_strFromSampleID.ToString().Trim() != "")
            {
                strSQL += strSQL_CheckNOFrom;
                //				arlSQL.Add(strSQL_CheckNOFrom);
                //				arlParm.Add(p_strFromSampleID);
            }
            if (p_strToSampleID != null && p_strToSampleID.ToString().Trim() != "")
            {
                strSQL += strSQL_CheckNOTo;
                //				arlSQL.Add(strSQL_CheckNOTo);
                //				arlParm.Add(p_strToSampleID);
            }
            if (p_strPatientType == "1")
            {
                strSQL += strSQL_PatientType_Out;
            }
            if (p_strPatientType == "2")
            {
                strSQL += strSQL_PatientType_In;
            }
            if (p_strFromConfirmDat != null && Microsoft.VisualBasic.Information.IsDate(p_strFromConfirmDat.Trim()))
            {
                strSQL += strSQL_ComfirmDatFrom;
                //				arlSQL.Add(strSQL_ComfirmDatFrom);
                //				arlParm.Add(DateTime.Parse(p_strFromConfirmDat.Trim()));
            }
            if (p_strToConfirmDat != null && Microsoft.VisualBasic.Information.IsDate(p_strToConfirmDat.Trim()))
            {
                strSQL += strSQL_ConfirmDatTo;
                //				arlSQL.Add(strSQL_ConfirmDatTo);
                //				arlParm.Add(DateTime.Parse(p_strToConfirmDat.Trim()));
            }
            if (p_strReportGroupID != null && p_strReportGroupID.Trim() != "")
            {
                strSQL += strSQL_ReportGroupID;
                //				arlSQL.Add(strSQL_ReportGroupID);
                //				arlParm.Add(p_strReportGroupID.Trim());
            }

            #endregion

            //			foreach(object obj in arlSQL)
            //			{
            //				strSQL += obj.ToString();
            //			}

            strSQL += " order by t2.report_group_id_chr,t1.application_form_no_chr";

            //			int intParmCount = arlSQL.Count;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            //			IDataParameter[] objDPArr = null;
            //			objHRPSvc.CreateDatabaseParameter(intParmCount,out objDPArr);
            //
            //			for(int i=0;i< intParmCount;i++)
            //			{
            //				objDPArr[i].Value = arlParm[i];
            //			}

            try
            {
                DataTable dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                //				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult,objDPArr);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsLisBatchReportList_VO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = new clsLisBatchReportList_VO();
                        p_objResultArr[i].strApplyDept = dtbResult.Rows[i]["deptname_vchr"].ToString().Trim();
                        p_objResultArr[i].strConfirmDat = dtbResult.Rows[i]["CONFIRM_DAT"].ToString().Trim();
                        p_objResultArr[i].strPatientName = dtbResult.Rows[i]["patient_name_vchr"].ToString().Trim();
                        p_objResultArr[i].strReportGroupName = dtbResult.Rows[i]["report_group_name_vchr"].ToString().Trim();
                        p_objResultArr[i].strSex = dtbResult.Rows[i]["sex_chr"].ToString().Trim();
                        p_objResultArr[i].strApplicationID = dtbResult.Rows[i]["application_id_chr"].ToString().Trim();
                        p_objResultArr[i].strReportGroupID = dtbResult.Rows[i]["report_group_id_chr"].ToString().Trim();
                        p_objResultArr[i].strCheckNO = dtbResult.Rows[i]["application_form_no_chr"].ToString().Trim();
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

        #region 根据申请单号和报告组号查询批量打印信息列表
        [AutoComplete]
        public long m_lngGetLisBatchReportDetailByCondition(System.Security.Principal.IPrincipal p_objPrincipal, clsLisBatchReportList_VO[] p_objReportList,
            out clsLisBatchReportDetail_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetLisBatchReportDetailByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                //				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_objReportList != null)
                {
                    p_objResultArr = new clsLisBatchReportDetail_VO[p_objReportList.Length];
                    for (int i = 0; i < p_objReportList.Length; i++)
                    {
                        p_objResultArr[i] = new clsLisBatchReportDetail_VO();

                        lngRes = 0;
                        lngRes = m_lngGetReportInfoByReportGroupIDAndApplicationID(p_objPrincipal,
                            p_objReportList[i].strReportGroupID, p_objReportList[i].strApplicationID, true, out p_objResultArr[i].m_dtbReportBaseInfo);

                        if (lngRes > 0 && p_objResultArr[i].m_dtbReportBaseInfo != null && p_objResultArr[i].m_dtbReportBaseInfo.Rows.Count > 0)
                        {
                            lngRes = 0;
                            lngRes = m_lngGetCheckResultByReportGroupIDAndApplicationID(p_objPrincipal,
                                p_objReportList[i].strApplicationID, p_objReportList[i].strReportGroupID, true, out p_objResultArr[i].m_dtbCheckResult);

                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据report_group_id和application_id_chr查询报告单相关信息
        /// <summary>
        /// 根据report_group_id和application_id_chr查询报告单相关信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strReportGroupID">报告组ID</param>
        /// <param name="p_strApplID">申请单ID</param>
        /// <param name="p_blnConfirmed">是否审核</param>
        /// <param name="p_dtbReportInfo">返回报告单相关信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetReportInfoByReportGroupIDAndApplicationID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strReportGroupID, string p_strApplID, bool p_blnConfirmed, out DataTable p_dtbReportInfo)
        {
            long lngRes = 0;
            p_dtbReportInfo = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetReportInfoByReportGroupIDAndApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strConfirmed = "";

            if (p_blnConfirmed)
            {
                strConfirmed = " AND t2.status_int = 2";
            }
            else
            {
                strConfirmed = " AND t2.status_int > 0";
            }

            string strSQL = @"SELECT t1.*, t2.*, t4.deptname_vchr, t5.lastname_vchr AS reportor,
									 t6.lastname_vchr AS confirmer, t7.lastname_vchr AS applyer,
									 t8.sample_type_desc_vchr, t9.application_form_no_chr AS check_no_chr,
									 t10.print_title_vchr, t9.SUMMARY_VCHR AS application_summary,
                                     t21.sign_grp as reportorsign, t22.sign_grp as confirmersign, t23.sign_grp as applyersign 
								FROM t_opr_lis_sample t1,
									 t_opr_lis_app_report t2,
									 t_opr_lis_app_sample t3,
									 T_BSE_DEPTDESC t4,
									 t_bse_employee t5,
									 t_bse_employee t6,
									 t_bse_employee t7,
									 t_aid_lis_sampletype t8,
									 t_opr_lis_application t9,
									 t_aid_lis_report_group t10,
                                     t_bse_empsign t21,
                                     t_bse_empsign t22,
                                     t_bse_empsign t23  
							   WHERE t2.application_id_chr = '" + p_strApplID + @"'
								 AND t2.report_group_id_chr = '" + p_strReportGroupID + @"'
								 AND t2.report_group_id_chr = t3.report_group_id_chr
								 AND t2.application_id_chr = t3.application_id_chr
								 AND t3.sample_id_chr = t1.sample_id_chr
								 AND t2.reportor_id_chr = t5.empid_chr(+)
								 AND t2.confirmer_id_chr = t6.empid_chr(+)
								 AND t9.appl_empid_chr = t7.empid_chr(+)
								 AND t9.appl_deptid_chr = t4.deptid_chr(+)
								 AND t1.sample_type_id_chr = t8.sample_type_id_chr(+)
								 AND t2.application_id_chr = t9.application_id_chr
								 AND t2.report_group_id_chr = t10.report_group_id_chr
                                 and t5.empid_chr = t21.empid_chr(+)
                                 and t6.empid_chr = t22.empid_chr(+)
                                 and t7.empid_chr = t23.empid_chr(+)
								 AND t9.pstatus_int > 0
								 AND t1.status_int > 0
								 AND t2.status_int > 0";
            strSQL += strConfirmed;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbReportInfo);
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

        #region 根据report_group_id和application_id_chr查询报告的结果记录
        /// <summary>
        /// 根据report_group_id和application_id_chr查询报告的结果记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strApplicationID">申请单ID</param>
        /// <param name="strReportGroupID">报告组ID</param>
        /// <param name="blnConfirmed">是否审核</param>
        /// <param name="dtbCheckResult">返回结果信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckResultByReportGroupIDAndApplicationID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strApplicationID, string p_strReportGroupID, bool p_blnConfirmed, out DataTable p_dtbCheckResult)
        {
            long lngRes = 0;
            p_dtbCheckResult = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetCheckResultByReportGroupIDAndApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strConfirmed = "";

            if (p_blnConfirmed)
            {
                strConfirmed = " and t2.status_int = 2";
            }
            else
            {
                strConfirmed = " and t2.status_int > 0";
            }
            string strSQL0 = @"select t4.oringin_dat,t3.sample_id_chr
									from t_opr_lis_app_report t2, 
										t_opr_lis_app_sample t3, t_opr_lis_application t4
									where t2.application_id_chr = '" + p_strApplicationID + @"' 
									and t2.report_group_id_chr = '" + p_strReportGroupID + @"'
									and t4.application_id_chr = t2.application_id_chr
									and t4.pstatus_int >= 0
									and t3.application_id_chr = t2.application_id_chr
									and t3.report_group_id_chr = t2.report_group_id_chr      
									";
            //t7.assist_code02_chr AS item_type 兼容 细菌报告样式（药敏）
            string strSQL = @"select /*+ use_hash(t1) */
 t1.*,
 t9.print_title_vchr,
 t5.print_seq_int as report_print_seq_int,
 t8.item_print_seq_int as sample_print_seq_int,
 t7.rptno_chr,
 t7.check_item_english_name_vchr,
 t7.assist_code02_chr as item_type,
 t7.shortname_chr
  from (select /*+ all_rows */
         *
          from t_opr_lis_check_result
         where sample_id_chr = ?
           and modify_dat >= to_date(?, 'yyyy-mm-dd hh24:mi:ss')
           and status_int = 1) t1,
       t_aid_lis_report_group_detail t5,
       t_bse_lis_check_item t7,
       v_lis_bse_sample_group_items t8,
       t_aid_lis_sample_group t9
 where t9.sample_group_id_chr = t1.groupid_chr
   and t7.check_item_id_chr = t1.check_item_id_chr
   and t8.check_item_id_chr = t1.check_item_id_chr
   and t8.sample_group_id_chr = t1.groupid_chr
   and t5.sample_group_id_chr = t1.groupid_chr";

            strSQL0 += strConfirmed;

            //			string strSQLAllRows = "ALTER SESSION SET OPTIMIZER_MODE=ALL_ROWS";

            string strSampleID = null;
            string strOriginDate = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL0, ref p_dtbCheckResult);
                if (lngRes == 1 && p_dtbCheckResult != null && p_dtbCheckResult.Rows.Count > 0)
                {
                    strSampleID = p_dtbCheckResult.Rows[0]["sample_id_chr"].ToString().Trim();
                    strOriginDate = p_dtbCheckResult.Rows[0]["oringin_dat"].ToString().Trim();
                    IDataParameter[] objDPArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = strSampleID;
                    objDPArr[1].Value = strOriginDate;
                    p_dtbCheckResult = null;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbCheckResult, objDPArr);
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

        #endregion

        #region 仪器接口

        #region 根据检验日期和仪器编号查询DeviceResultLog
        /// <summary>
        /// 根据检验日期和仪器编号查询DeviceResultLog
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckDatFrom"></param>
        /// <param name="p_strCheckDatTo"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceResultLogByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckDatFrom,
            string p_strCheckDatTo, string p_strDeviceID, out clsResultLogVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_mthGetDeviceResultLogByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT *
								FROM t_opr_Lis_result_log
							   WHERE CHECK_DAT between TO_DATE('" + p_strCheckDatFrom + @"','yyyy-mm-dd HH24:mi:ss') 
												   and TO_DATE('" + p_strCheckDatTo + @"','yyyy-mm-dd hh24:mi:ss')
								 AND DEVICEID_CHR = '" + p_strDeviceID + @"'";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsResultLogVO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsResultLogVO();
                        p_objResultArr[i].m_strBeginIndex = dtbResult.Rows[i]["BEGIN_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strCheckDat = dtbResult.Rows[i]["CHECK_DAT"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceID = dtbResult.Rows[i]["DEVICEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceSampleID = dtbResult.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strEndIndex = dtbResult.Rows[i]["END_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strIMPORT_REQ_INT = dtbResult.Rows[i]["IMPORT_REQ_INT"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 根据申请号得到对应样本的仪器关联
        /// <summary>
        /// 根据申请号得到对应样本的仪器关联
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_objDRVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceRelationByAppID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strAppID, out clsT_LIS_DeviceRelationVO[] p_objDRVOArr)
        {
            long lngRes = 0;
            p_objDRVOArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceDataByAppointment");
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;

            if (p_strAppID == null)
                return -1;

            DataTable dtbRelation = null;
            string strSQL = @"SELECT DISTINCT t2.*
								FROM t_opr_lis_app_sample t1, t_opr_lis_device_relation t2
								WHERE t1.sample_id_chr = t2.sample_id_chr
								AND t2.status_int > 0
								AND t1.application_id_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);

                objDPArr[0].Value = p_strAppID.Trim();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbRelation, objDPArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbRelation != null && dtbRelation.Rows.Count != 0)
                {
                    p_objDRVOArr = new clsT_LIS_DeviceRelationVO[dtbRelation.Rows.Count];
                    for (int i = 0; i < dtbRelation.Rows.Count; i++)
                    {
                        p_objDRVOArr[i] = new clsVOConstructor().m_objConstructDeviceRelationVO(dtbRelation.Rows[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 仪器样本融合,重做
        #region 根据Imp_Req_int和仪器ID查询标本列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strImpReq"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceSampleListByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strImpReq, string p_strDeviceID,
            out clsResultLogVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceSampleListByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"SELECT a.*,d.devicesample_status_int, d.sample_status_int
							    FROM t_opr_lis_result_log a,
									 (SELECT b.status_int AS devicesample_status_int,
											 c.status_int AS sample_status_int, c.sample_id_chr,
											 b.device_sampleid_chr, b.check_dat, b.import_req_int,
											 b.deviceid_chr
										FROM t_opr_lis_device_relation b, t_opr_lis_sample c
									   WHERE b.status_int > 0
										 AND b.sample_id_chr = c.sample_id_chr
										 AND c.status_int > -1) d
							  WHERE a.import_req_int = d.import_req_int(+)
								AND a.deviceid_chr = d.deviceid_chr(+)
								AND a.import_req_int = '" + p_strImpReq + @"'
								AND a.deviceid_chr = '" + p_strDeviceID + @"'
							 ORDER BY a.import_req_int";
            #endregion

            DataTable dtbResult = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsResultLogVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = new clsResultLogVO();
                        p_objResultArr[i].m_strBeginIndex = dtbResult.Rows[i]["BEGIN_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strCheckDat = dtbResult.Rows[i]["CHECK_DAT"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceID = dtbResult.Rows[i]["DEVICEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceSampleID = dtbResult.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strEndIndex = dtbResult.Rows[i]["END_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strUseFlag = dtbResult.Rows[i]["USE_FLAG_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strIMPORT_REQ_INT = dtbResult.Rows[i]["IMPORT_REQ_INT"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceSample_status = dtbResult.Rows[i]["devicesample_status_int"].ToString().Trim();
                        p_objResultArr[i].m_strSample_status = dtbResult.Rows[i]["sample_status_int"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据仪器样本号，仪器ID和检验时间查询标本列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceSampleID"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_strCheckDat"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceSampleListByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceSampleID,
            string p_strDeviceID, string p_strCheckDat, out clsResultLogVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceSampleListByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            string strSQL = @"SELECT a.*,d.devicesample_status_int, d.sample_status_int
							    FROM t_opr_lis_result_log a,
									 (SELECT b.status_int AS devicesample_status_int,
											 c.status_int AS sample_status_int, c.sample_id_chr,
											 b.device_sampleid_chr, b.check_dat, b.import_req_int,
											 b.deviceid_chr
										FROM t_opr_lis_device_relation b, t_opr_lis_sample c
									   WHERE b.status_int > 0
										 AND b.sample_id_chr = c.sample_id_chr
										 AND c.status_int > -1) d
							  WHERE a.import_req_int = d.import_req_int(+)
								AND a.deviceid_chr = d.deviceid_chr(+)
								AND a.device_sampleid_chr = '" + p_strDeviceSampleID + @"'
								AND TRUNC (a.check_dat) =
										TRUNC (TO_DATE ('" + p_strCheckDat + @"', 'yyyy-mm-dd'))
								AND a.deviceid_chr = '" + p_strDeviceID + @"'
							 ORDER BY a.import_req_int";
            #endregion

            DataTable dtbResult = new DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsResultLogVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = new clsResultLogVO();
                        p_objResultArr[i].m_strBeginIndex = dtbResult.Rows[i]["BEGIN_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strCheckDat = dtbResult.Rows[i]["CHECK_DAT"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceID = dtbResult.Rows[i]["DEVICEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceSampleID = dtbResult.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strEndIndex = dtbResult.Rows[i]["END_IDX_INT"].ToString().Trim();
                        p_objResultArr[i].m_strUseFlag = dtbResult.Rows[i]["USE_FLAG_CHR"].ToString().Trim();
                        p_objResultArr[i].m_strIMPORT_REQ_INT = dtbResult.Rows[i]["IMPORT_REQ_INT"].ToString().Trim();
                        p_objResultArr[i].m_strDeviceSample_status = dtbResult.Rows[i]["devicesample_status_int"].ToString().Trim();
                        p_objResultArr[i].m_strSample_status = dtbResult.Rows[i]["sample_status_int"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定和提取数据
        /// <summary>
        /// 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定和提取数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_strDeviceSampleID"></param>
        /// <param name="p_strCheckDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns>
        /// 小于等于 0 : 查询失败; 
        /// 100: 无可绑定的仪器样本; 
        /// 300: 指定的仪器样本号无历史记录; 
        /// 400:指定的仪器样本无原始数据; 
        /// 其它: 成功返回
        /// </returns>
        [AutoComplete]
        public long m_lngQueryBindAndGetDeviceDataByAppointment(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, string p_strDeviceSampleID, string p_strCheckDate,
            out clsDeviceReslutVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            DataTable dtbResult = null;
            clsResultLogVO objResultLogVO = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceDataByAppointment");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_strDeviceID == null || p_strDeviceSampleID == null || !Microsoft.VisualBasic.Information.IsDate(p_strCheckDate))
                return -1;

            try
            {
                lngRes = 0;
                lngRes = m_lngQueryBindByAppointment(p_objPrincipal, p_strDeviceID, p_strDeviceSampleID, p_strCheckDate, out objResultLogVO);
                if (lngRes == 100 || lngRes == 300 || lngRes == 400 || lngRes <= 0)
                {
                    return lngRes;
                }
                else
                {
                    lngRes = 0;
                    int intBeginIndex = int.Parse(objResultLogVO.m_strBeginIndex);
                    int intEndIndex = int.Parse(objResultLogVO.m_strEndIndex);
                    lngRes = m_lngGetDeviceData(p_objPrincipal, p_strDeviceID, objResultLogVO.m_strDeviceSampleID, objResultLogVO.m_strCheckDat, intBeginIndex, intEndIndex, out p_objResultArr);
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
            }
            return lngRes;
        }
        #endregion
        
        #region 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定
        /// <summary>
        /// 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定 刘彬 2004.06.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_strDeviceSampleID"></param>
        /// <param name="p_strCheckDate"></param>
        /// <param name="p_objResultLogVO">以此到仪器结果表提取数据</param>
        /// <returns>
        /// 小于等于 0 : 查询失败;
        /// 100: 无可绑定的仪器样本;
        /// 300: 指定的仪器样本号无历史记录;
        /// 其它: 成功返回
        /// </returns>
        [AutoComplete]
        public long m_lngQueryBindByAppointment(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, string p_strDeviceSampleID, string p_strCheckDate,
            out clsResultLogVO p_objResultLogVO)
        {
            long lngRes = 0;
            p_objResultLogVO = null;
            DataTable dtbImportReq = null;
            string strSQL = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceDataByAppointment");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_strDeviceID == null || p_strDeviceSampleID == null || !Microsoft.VisualBasic.Information.IsDate(p_strCheckDate))
                return -1;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                #region 查询绑定
                #region 此 SQL 性能不好
                //				strSQL =@"SELECT *
                //							FROM t_opr_lis_result_import_req
                //							WHERE CONCAT (deviceid_chr, TO_CHAR (import_req_int)) =
                //									(SELECT   CONCAT (deviceid_chr,
                //														TO_CHAR (MAX (import_req_int))
                //													) AS flag
                //										FROM t_opr_lis_result_import_req
                //										WHERE deviceid_chr = ? 
                //											AND TRIM (device_sampleid_chr) = ? 
                //											AND TRUNC (check_dat) = 
                //												TRUNC (TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss'))
                //									GROUP BY deviceid_chr)";

                #endregion

                strSQL = @"SELECT *
							FROM (SELECT   *
										FROM t_opr_lis_result_import_req
									WHERE deviceid_chr = ? 
										AND TRIM (device_sampleid_chr) = ? 
										AND TRUNC (check_dat) =
												TRUNC (TO_DATE (?,
																'yyyy-mm-dd hh24:mi:ss'))
									ORDER BY import_req_int DESC)
							WHERE ROWNUM = 1";

                System.Data.IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);

                objDPArr[0].Value = p_strDeviceID.Trim();
                objDPArr[1].Value = p_strDeviceSampleID.Trim();
                objDPArr[2].Value = p_strCheckDate;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbImportReq, objDPArr);
                objHRPSvc.Dispose();
                #endregion

                if (lngRes > 0 && (dtbImportReq == null || dtbImportReq.Rows.Count == 0))
                {
                    return 100;//无可绑定的仪器样本
                }
                else if (lngRes <= 0)
                {
                    return lngRes;//查询失败
                }
                DataRow dtrSample = dtbImportReq.Rows[0];

                string strCheckDate = dtrSample["check_dat"].ToString();
                int intImportReq = int.Parse(dtrSample["import_req_int"].ToString().Trim());
                lngRes = 0;
                lngRes = m_lngQueryResultLog(p_objPrincipal, p_strDeviceID, intImportReq, out p_objResultLogVO);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #region  m_lngGetDeviceData 根据指定的仪器编号,REQ ,查询 DeviceResultLog 和提取仪器数据
        /// <summary>
        ///  根据指定的仪器编号,REQ ,查询 DeviceResultLog 和提取仪器数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_intImportReq"></param>
        /// <param name="p_objDeviceResultList"></param>
        /// <returns>
        /// 小于 0 : 查询失败;
        /// 300:指定的仪器样本无历史记录
        /// 400:指定的仪器样本无原始数据
        /// 其它: 成功返回 
        /// </returns>
        [AutoComplete]
        public long m_lngGetDeviceData(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, int p_intImportReq,
            out clsDeviceReslutVO[] p_objDeviceResultList)
        {
            long lngRes = 0;
            p_objDeviceResultList = null;
            DataTable dtbResult = null;
            string strSQL = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceData");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_strDeviceID == null)
                return -1;
            try
            {
                clsResultLogVO objResultLogVO = null;
                lngRes = 0;
                lngRes = m_lngQueryResultLog(p_objPrincipal, p_strDeviceID, p_intImportReq, out objResultLogVO);
                if (lngRes <= 0)
                    return lngRes;
                if (objResultLogVO == null)
                {
                    return 300;
                }
                lngRes = 0;
                lngRes = this.m_lngGetDeviceData(p_objPrincipal, p_strDeviceID,
                    objResultLogVO.m_strDeviceSampleID, objResultLogVO.m_strCheckDat, int.Parse(objResultLogVO.m_strBeginIndex.Trim()), int.Parse(objResultLogVO.m_strEndIndex.Trim()), out p_objDeviceResultList);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #region m_lngQueryResultLog 根据指定的仪器编号,REQ 查询DeviceResultLog
        /// <summary>
        /// 根据指定的仪器编号,REQ 查询DeviceResultLog 刘彬 2004.06.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_intImportReq"></param>
        /// <param name="p_objResultLogVO">以此到仪器结果表提取数据</param>
        /// <returns>
        /// 小于 0 : 查询失败; 
        /// 300: 指定的仪器样本号无历史记录; 
        /// 其它: 成功返回 
        /// </returns>
        [AutoComplete]
        public long m_lngQueryResultLog(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, int p_intImportReq,
            out clsResultLogVO p_objResultLogVO)
        {
            long lngRes = 0;
            p_objResultLogVO = null;
            DataTable dtbResultLog = null;
            string strSQL = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngQueryResultLog");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_strDeviceID == null)
                return -1;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                strSQL = @"SELECT deviceid_chr,import_req_int,device_sampleid_chr,check_dat,begin_idx_int,end_idx_int
						  FROM t_opr_lis_result_log
						  WHERE deviceid_chr = ? 
						  AND import_req_int = ?
						  ";

                System.Data.IDataParameter[] objDPArr1 = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr1);

                objDPArr1[0].Value = p_strDeviceID.Trim();
                objDPArr1[1].Value = p_intImportReq;

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResultLog, objDPArr1);


                if (lngRes > 0 && (dtbResultLog == null || dtbResultLog.Rows.Count == 0))
                {
                    return 300;//指定的仪器样本无历史记录
                }
                else if (lngRes > 0)
                {
                    p_objResultLogVO = new com.digitalwave.iCare.ValueObject.clsResultLogVO();
                    p_objResultLogVO.m_strBeginIndex = dtbResultLog.Rows[0]["BEGIN_IDX_INT"].ToString().Trim();
                    p_objResultLogVO.m_strCheckDat = dtbResultLog.Rows[0]["CHECK_DAT"].ToString().Trim();
                    p_objResultLogVO.m_strDeviceID = dtbResultLog.Rows[0]["DEVICEID_CHR"].ToString().Trim();
                    p_objResultLogVO.m_strDeviceSampleID = dtbResultLog.Rows[0]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                    p_objResultLogVO.m_strEndIndex = dtbResultLog.Rows[0]["END_IDX_INT"].ToString().Trim();
                    p_objResultLogVO.m_strIMPORT_REQ_INT = dtbResultLog.Rows[0]["IMPORT_REQ_INT"].ToString().Trim();
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #region  m_lngGetDeviceData 根据指定的仪器编号,检验日期,和仪器样本编号,及开始索引和结束索引提取仪器数据
        /// <summary>
        ///  根据指定的仪器编号,检验日期,和仪器样本编号,及开始索引和结束索引提取仪器数据 刘彬 2004.06.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_strDeviceSampleID"></param>
        /// <param name="p_strCheckDate"></param>
        /// <param name="p_intBeginIndex"></param>
        /// <param name="p_intEndIndex"></param>
        /// <param name="p_objDeviceResultList"></param>
        /// <returns>
        /// 小于等于 0 : 查询失败; 
        /// 400:指定的仪器样本无原始数据
        /// 其它: 成功返回 
        /// </returns>
        [AutoComplete]
        public long m_lngGetDeviceData(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, string p_strDeviceSampleID, string p_strCheckDate, int p_intBeginIndex, int p_intEndIndex,
            out clsDeviceReslutVO[] p_objDeviceResultList)
        {
            long lngRes = 0;
            p_objDeviceResultList = null;
            DataTable dtbResult = null;
            string strSQL = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngGetDeviceData");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_strDeviceID == null || p_strDeviceSampleID == null || !Microsoft.VisualBasic.Information.IsDate(p_strCheckDate))
                return -1;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                DateTime m_dtDate;
                DateTime.TryParse(p_strCheckDate, out m_dtDate);
                strSQL = @"select idx_int,
       device_check_item_name_vchr,
       device_sampleid_chr,
       abnormal_flag_vchr,
       check_dat,
       min_val_dec,
       max_val_dec,
       deviceid_chr,
       pstatus_int,
       refrange_vchr,
       result_vchr,
       unit_vchr,
       graph_img,
       graph_format_name_vchr,
       is_graph_result_num,
       result2_vchr,
       doctorexpress
  from t_opr_lis_result
 where deviceid_chr = ?
   and trim(device_sampleid_chr) = ?
   and check_dat = ?
   and idx_int >= ?
   and idx_int <= ?
   order by idx_int desc";
                lngRes = 0;
                System.Data.IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strDeviceID.PadRight(6, ' ');
                objDPArr[1].Value = p_strDeviceSampleID.Trim();
                objDPArr[2].Value = m_dtDate;
                objDPArr[3].Value = p_intBeginIndex;
                objDPArr[4].Value = p_intEndIndex;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                /*<================================*/

                if (lngRes > 0 && (dtbResult == null || dtbResult.Rows.Count == 0))
                {
                    return 400;//指定的仪器样本无原始数据
                }
                else if (lngRes > 0)
                {
                    p_objDeviceResultList = new clsDeviceReslutVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objDeviceResultList[i] = new clsDeviceReslutVO();
                        p_objDeviceResultList[i].m_strAbnormalFlag = dtbResult.Rows[i]["ABNORMAL_FLAG_VCHR"].ToString().Trim().ToString().Trim();
                        p_objDeviceResultList[i].m_strCheckDat = dtbResult.Rows[i]["CHECK_DAT"].ToString().Trim();
                        p_objDeviceResultList[i].m_strDeviceCheckItemName = dtbResult.Rows[i]["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                        p_objDeviceResultList[i].m_strDeviceID = dtbResult.Rows[i]["DEVICEID_CHR"].ToString().Trim();
                        p_objDeviceResultList[i].m_strDeviceSampleID = dtbResult.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        p_objDeviceResultList[i].m_strIdx = dtbResult.Rows[i]["IDX_INT"].ToString().Trim();
                        p_objDeviceResultList[i].m_strMaxVal = dtbResult.Rows[i]["MAX_VAL_DEC"].ToString().Trim();
                        p_objDeviceResultList[i].m_strMinVal = dtbResult.Rows[i]["MIN_VAL_DEC"].ToString().Trim();
                        p_objDeviceResultList[i].m_strPstatus = dtbResult.Rows[i]["PSTATUS_INT"].ToString().Trim();
                        p_objDeviceResultList[i].m_strRefRange = dtbResult.Rows[i]["REFRANGE_VCHR"].ToString().Trim();
                        p_objDeviceResultList[i].m_strResult = dtbResult.Rows[i]["RESULT_VCHR"].ToString().Trim();
                        p_objDeviceResultList[i].m_strUnit = dtbResult.Rows[i]["UNIT_VCHR"].ToString().Trim();
                        p_objDeviceResultList[i].strResult2 = dtbResult.Rows[i]["result2_vchr"].ToString().Trim();
                        p_objDeviceResultList[i].strDoctorExpress = dtbResult.Rows[i]["doctorexpress"].ToString().Trim();
                        p_objDeviceResultList[i].strGraphFormatName = dtbResult.Rows[i]["GRAPH_FORMAT_NAME_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i]["GRAPH_IMG"] != DBNull.Value)
                        {
                            p_objDeviceResultList[i].bytGraph = (byte[])dtbResult.Rows[i]["GRAPH_IMG"];
                        }
                        if (dtbResult.Rows[i]["IS_GRAPH_RESULT_NUM"] != DBNull.Value)
                        {
                            p_objDeviceResultList[i].intIsGraphResult = Convert.ToInt32(dtbResult.Rows[i]["IS_GRAPH_RESULT_NUM"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region 以自动绑定方式,根据指定的仪器编号  查询绑定和提取数据
        /// <summary>
        /// 以指定编号方式,根据指定的仪器编号,和仪器样本编号查询绑定和提取数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns>
        /// 小于 0 : 查询失败; 
        /// 100: 无可绑定的仪器样本;
        /// 300: 指定的仪器样本号存在且未绑定,但无历史记录; 
        /// 400:指定的仪器样本无原始数据; 
        /// 其它: 成功返回
        /// </returns>
        [AutoComplete]
        public long m_lngQueryBindAndGetDeviceDataByAutoBind(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, out clsDeviceReslutVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            DataTable dtbResult = null;
            clsResultLogVO objResultLogVO = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngQueryBindAndGetDeviceDataByAutoBind");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_strDeviceID == null)
                return -1;
            try
            {
                lngRes = 0;
                lngRes = m_lngQueryBindByAutoBind(p_objPrincipal, p_strDeviceID, out objResultLogVO);
                if (lngRes == 100 || lngRes == 300 || lngRes <= 0)
                {
                    return lngRes;
                }
                else
                {
                    lngRes = 0;
                    int intBeginIndex = int.Parse(objResultLogVO.m_strBeginIndex);
                    string strSid = objResultLogVO.m_strDeviceSampleID.Trim();
                    string strCheckDate = objResultLogVO.m_strCheckDat;
                    int intEndIndex = int.Parse(objResultLogVO.m_strEndIndex);
                    lngRes = m_lngGetDeviceData(p_objPrincipal, p_strDeviceID, strSid, strCheckDate, intBeginIndex, intEndIndex, out p_objResultArr);
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
            }
            return lngRes;
        }
        #endregion

        #region 以自动绑定方式,根据指定的仪器编号 查询绑定
        /// <summary>
        /// 以自动绑定方式,根据指定的仪器编号 查询绑定 刘彬 2004.06.10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_objResultLogVO">以此到仪器结果表提取数据</param>
        /// <returns>
        /// 小于 0 : 查询失败;
        /// 100: 无可绑定的仪器样本;
        /// 300: 可绑定的仪器样本号存在且未绑定,但无历史记录 
        /// 其它: 成功返回
        /// </returns>
        [AutoComplete]
        public long m_lngQueryBindByAutoBind(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strDeviceID, out clsResultLogVO p_objResultLogVO)
        {
            long lngRes = 0;
            p_objResultLogVO = null;
            DataTable dtbResultLog = null;
            DataTable dtbImportReq = null;
            string strSQL = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc", "m_lngQueryBindByAutoBind");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_strDeviceID == null)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                int intLastBindIndex = -1;

                #region 查找最后一次的绑定点
                dtbImportReq = null;
                lngRes = 0;

                strSQL = @"SELECT *
						  FROM t_opr_lis_result_import_req
						  WHERE deviceid_chr = ? 
					 	  AND IS_AUTOBIND_ENDPOINTER_INT = 1";

                System.Data.IDataParameter[] objDPArr0 = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr0);

                objDPArr0[0].Value = p_strDeviceID.Trim();


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbImportReq, objDPArr0);
                #endregion

                if (lngRes <= 0)
                {
                    return lngRes;
                }

                if (dtbImportReq != null && dtbImportReq.Rows.Count != 0)
                {
                    intLastBindIndex = int.Parse(dtbImportReq.Rows[0]["IMPORT_REQ_INT"].ToString().Trim());
                }
                else
                {
                    intLastBindIndex = -1;
                }

                #region 查询绑定

                dtbImportReq = null;
                lngRes = 0;

                strSQL = @"SELECT *
						  FROM t_opr_lis_result_import_req
						  WHERE deviceid_chr = ? 
					 	  AND IMPORT_REQ_INT > ? 
						  AND STATUS_INT = 1  ";

                System.Data.IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);

                objDPArr[0].Value = p_strDeviceID.Trim();
                objDPArr[1].Value = intLastBindIndex;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbImportReq, objDPArr);
                #endregion

                if (lngRes > 0 && (dtbImportReq == null || dtbImportReq.Rows.Count == 0))
                {
                    return 100;//无可绑定的仪器样本
                }
                else if (lngRes <= 0)
                {
                    return lngRes;//查询失败
                }

                int intImportReq = int.Parse(dtbImportReq.Rows[0]["IMPORT_REQ_INT"].ToString().Trim());
                lngRes = m_lngQueryResultLog(p_objPrincipal, p_strDeviceID, intImportReq, out p_objResultLogVO);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        #region 查找指定病人，指定检验项目ID的检验结果
        /// <summary>
        /// 查找指定病人，指定检验项目ID的检验结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strExcItemID"> 需要特殊处理的项目ID</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryPatientExcItemResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientID, string p_strExcItemID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;

            if (string.IsNullOrEmpty(p_strPatientID) || string.IsNullOrEmpty(p_strExcItemID))
                return lngRes;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc", "m_lngQueryPatientExcItemResult");
            objPrivilege = null;
            if (lngRes <= 0)
            {
                return -1;
            }
            lngRes = 0;

            string strSQL = @"select a.application_id_chr,
       a.confirm_dat,
       b.result_vchr,
       c.rptno_chr,
       c.check_item_english_name_vchr,
       c.check_item_id_chr
  from t_opr_lis_sample a
 inner join t_opr_lis_check_result b on a.sample_id_chr = b.sample_id_chr
                                    and b.status_int = 1
 inner join t_bse_lis_check_item c on b.check_item_id_chr =
                                      c.check_item_id_chr
 where a.status_int = 6
   and a.patientid_chr = ?
   and c.check_item_id_chr = ?";

            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strPatientID;
                objDPArr[1].Value = p_strExcItemID;

                DataTable dtbCheckResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbCheckResult, objDPArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbCheckResult != null && dtbCheckResult.Rows.Count > 0)
                {
                    dtbCheckResult.DefaultView.Sort = "confirm_dat desc";
                    p_dtResult = dtbCheckResult.DefaultView.ToTable();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPSvc = null;
                p_strExcItemID = null;
                p_strPatientID = null;
            }
            return lngRes;
        }

        #endregion

        #region OLD

        #region SQl
        private const string c_strAddNewDeviceRelation_SQL = @"INSERT INTO t_opr_lis_device_relation(SEQ_ID_CHR, 
															DEVICEID_CHR, 
															device_sampleid_chr, 
															CHECK_DAT, 
															sample_id_chr, 
															PositionID_Chr, 
															STATUS_INT,
															RECEPTION_DAT,
															SEQ_ID_DEVICE_CHR)
															VALUES(?,?,?,?,?,?,?,?,?)";
        #endregion

        #region 构造SampleVO
        [AutoComplete]
        private void ConstructSampleVO(DataRow objRow, ref com.digitalwave.iCare.ValueObject.clsSampleVO objSampleVO)
        {
            if (objRow["SAMPLE_ID_CHR"] != System.DBNull.Value)
                objSampleVO.m_strSAMPLE_ID = objRow["SAMPLE_ID_CHR"].ToString().Trim();

            if (objRow["application_form_no_chr"] != System.DBNull.Value)
                objSampleVO.m_strApplication_ID = objRow["application_form_no_chr"].ToString().Trim();

            if (objRow["appl_dat"] != System.DBNull.Value)
                objSampleVO.m_strAppl_Dat = objRow["appl_dat"].ToString().Trim();

            if (objRow["sex_chr"] != System.DBNull.Value)
                objSampleVO.m_strSex = objRow["sex_chr"].ToString().Trim();

            if (objRow["patient_name_vchr"] != System.DBNull.Value)
                objSampleVO.m_strPatient_Name = objRow["patient_name_vchr"].ToString().Trim();

            if (objRow["patient_subno_chr"] != System.DBNull.Value)
                objSampleVO.m_strPatient_SubNO = objRow["patient_subno_chr"].ToString().Trim();

            if (objRow["age_chr"] != System.DBNull.Value)
                objSampleVO.m_strAge = objRow["age_chr"].ToString().Trim();

            if (objRow["patient_type_chr"] != System.DBNull.Value)
                objSampleVO.m_strPatient_Type = objRow["patienttype"].ToString().Trim();

            if (objRow["diagnose_vchr"] != System.DBNull.Value)
                objSampleVO.m_strDiagnose = objRow["diagnose_vchr"].ToString().Trim();

            if (objRow["sampletype_vchr"] != System.DBNull.Value)
                objSampleVO.m_strSampleType = objRow["sampletype_vchr"].ToString().Trim();

            if (objRow["samplestate_vchr"] != System.DBNull.Value)
                objSampleVO.m_strSampleState = objRow["samplestate_vchr"].ToString().Trim();

            if (objRow["bedno_chr"] != System.DBNull.Value)
                objSampleVO.m_strBedNO = objRow["bedno_chr"].ToString().Trim();

            if (objRow["icd_vchr"] != System.DBNull.Value)
                objSampleVO.m_strIcd = objRow["icd_vchrr"].ToString().Trim();

            if (objRow["PATIENTCARDID_CHR"] != System.DBNull.Value)
                objSampleVO.m_strPatientCardID = objRow["PATIENTCARDID_CHR"].ToString().Trim();

            if (objRow["barcode_vchr"] != System.DBNull.Value)
                objSampleVO.m_strBarCode = objRow["barcode_vchr"].ToString().Trim();

            if (objRow["patientid_chr"] != System.DBNull.Value)
                objSampleVO.m_strPatientID = objRow["patientid_chr"].ToString().Trim();

            if (objRow["sampling_date_dat"] != System.DBNull.Value)
                objSampleVO.m_strSampling_Dat = objRow["sampling_date_dat"].ToString().Trim();

            if (objRow["operator_id_chr"] != System.DBNull.Value)
                objSampleVO.m_strOperator_ID = objRow["operator_id_chr"].ToString().Trim();

            if (objRow["appl_empid_chr"] != System.DBNull.Value)
                objSampleVO.m_strAppl_EmpID = objRow["applyemployee"].ToString().Trim();

            if (objRow["appl_deptid_chr"] != System.DBNull.Value)
                objSampleVO.m_strAppl_DeptID = objRow["deptname"].ToString().Trim();

            if (objRow["status_int"] != System.DBNull.Value)
                objSampleVO.m_strStatus = objRow["status_int"].ToString().Trim();

            if (objRow["SAMPLE_TYPE_ID_CHR"] != System.DBNull.Value)
                objSampleVO.m_strSampleType = objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();

            if (objRow["QCSAMPLEID_CHR"] != System.DBNull.Value)
            {
                objSampleVO.m_strQCSampleID = objRow["QCSAMPLEID_CHR"].ToString().Trim();
            }

            if (objRow["SAMPLEKIND_CHR"] != System.DBNull.Value)
            {
                objSampleVO.m_strSampleKind = objRow["SAMPLEKIND_CHR"].ToString().Trim();
            }

            if (objRow["CHECK_DATE_DAT"] != System.DBNull.Value)
            {
                objSampleVO.m_strCheckDat = objRow["CHECK_DATE_DAT"].ToString().Trim();
            }
        }

        #endregion

        #region 根据申请单和检验大组查询检验结果
        [AutoComplete]
        public long m_lngGetCheckResultByApplFormNoAndCheckGroupID(System.Security.Principal.IPrincipal objPrincipal, string strApplFormNo, string strGroupID, out DataTable dtbCheckResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.modify_dat, t1.groupid_chr, t1.check_item_id_chr, t1.sample_id_chr,											t1.result_vchr,t1.unit_vchr, t1.deviceid_chr,																	t1.device_check_item_name_vchr, t1.refrange_vchr AS ss,
									t1.check_item_name_vchr, t1.check_item_english_name_vchr, t1.min_val_dec,
									t1.max_val_dec, t1.abnormal_flag_chr, t1.check_dat, t1.clinicapp_vchr, 
									t1.memo_vchr,t1.confirm_dat, t1.pointliststr_vchr, t1.summary_vchr, 
									t1.graph_img, t1.status_int,t1.checker1_chr, t1.checker2_chr, 
									t1.confirm_person_chr, t1.operator_id_chr,t1.check_deptid_chr, 
									t2.lastname_vchr AS confirmperson,t3.lastname_vchr AS checkperson,
									t1.refrange_vchr
								FROM t_opr_lis_check_result t1,t_bse_employee t2,t_bse_employee t3,
									 t_bse_lis_check_item t4
								WHERE t1.status_int = 1
								AND t1.check_item_id_chr = t4.check_item_id_chr
								AND (t1.confirm_person_chr = t2.empid_chr(+))
								AND (t1.checker1_chr = t3.empid_chr(+))
								AND sample_id_chr IN (
														SELECT sample_id_chr
															FROM t_opr_lis_applgrpsmp
														WHERE groupid_chr = '" + strGroupID
                + "' AND application_form_no_chr = '" + strApplFormNo + "')";
            dtbCheckResult = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckResult);
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

        #region 根据样品号查询表t_opr_lis_check_result的结果信息
        [AutoComplete]
        public long m_lngGetManualCheckResultBySampleID(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleID, out DataTable dtbManualCheckResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT modify_dat, 
									groupid_chr, 
									check_item_id_chr, 
									sample_id_chr, 
									result_vchr, 
									unit_vchr as UNIT_CHR, 
									deviceid_chr, 
									device_check_item_name_vchr, 
									refrange_vchr as REF_VALUE_RANGE_VCHR, 
									check_item_name_vchr, 
									check_item_english_name_vchr, 
									min_val_dec, 
									max_val_dec, 
									abnormal_flag_chr, 
									check_dat, 
									clinicapp_vchr, 
									memo_vchr, 
									confirm_dat, 
									pointliststr_vchr, 
									Summary_Vchr, 
									graph_img, 
									status_int, 
									checker1_chr, 
									checker2_chr, 
									confirm_person_chr, 
									operator_id_chr, 
									check_deptid_chr
								FROM t_opr_lis_check_result
								WHERE sample_id_chr = '" + strSampleID
                + "' AND status_int = 1";
            dtbManualCheckResult = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbManualCheckResult);
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

        #region 根据申请日期查询手工录入的检验项目的标本资料
        [AutoComplete]
        public long m_lngGetSampleListByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtBegin, DateTime p_dtEnd, string flag, out System.Data.DataTable p_dtbSampleList)
        {
            long lngRes = 0;
            p_dtbSampleList = null;
            string strfilter = null;
            if (flag == "1")
            {
                strfilter = "NOT IN";
            }
            else
            {
                strfilter = "IN";
            }
            string strSQL = @"SELECT t1.sample_id_chr,t2.groupid_chr,t3.groupname_vchr,t1.appl_dat,t2.stepflag_chr 
								FROM t_opr_lis_sample t1, t_opr_lis_req_check t2, t_aid_lis_check_group t3
								WHERE t1.sample_id_chr = t2.sample_id_chr
								AND t2.groupid_chr = t3.groupid_chr
								AND appl_dat BETWEEN TO_DATE ('" + p_dtBegin.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss') AND TO_DATE ('" + p_dtEnd.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss')
								AND  t1.samplekind_chr = '2'
								AND t1.sample_id_chr " + strfilter + " (SELECT sample_id_chr FROM t_opr_lis_check_result)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSampleList);
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

        #region 根据SampleID和GroupID查询手工录入的具体检验项目
        [AutoComplete]
        public long m_lngGetCheckItemBySampleIDAndGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleID, string strGroupID, out System.Data.DataTable dtbManualCheckItemList)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t2.check_item_name_vchr, t1.check_item_id_chr, t2.unit_chr,t2.ref_value_range_vchr,  t2.unit_chr, t2.check_item_english_name_vchr 
								FROM t_opr_lis_req_check_detail t1, t_bse_lis_check_item t2
								WHERE t1.check_item_id_chr = t2.check_item_id_chr
								AND t1.sample_id_chr = '" + strSampleID +
                "'AND t1.groupid_chr = '" + strGroupID + "'";
            dtbManualCheckItemList = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbManualCheckItemList);
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

        #region 根据仪器号（不是型号，是一台具体仪器的代号）和检验日期范围，查询出符合条件(该仪器在该段时间内所检验的）标本资料 周振忠 2004-3-7
        //。返回结果必须包含仪器标本号，样品Barcode
        //和检验日期。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDeviceId">设备ID</param>
        /// <param name="dtBegin">查询开始时间</param>
        /// <param name="dtEnd">查询结束时间</param>
        /// <param name="dtbDeviceSampleList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceSampleList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, string strBeginDate, string strEndDate, out System.Data.DataTable p_dtbDeviceSampleList)
        {
            long lngRes = 0;
            string strSQL = null;
            p_dtbDeviceSampleList = null;
            strSQL = @"select d.*, e.barcode_vchr from (select b.*, c.PositionID_Chr, c.sample_id_chr, c.STATUS_INT FROM
					(select distinct a.deviceid_chr,
					a.device_sampleid_chr,
					a.check_dat
					from t_opr_lis_result_log a where a.deviceid_chr = '" + p_strDeviceID + "' and " +
                @"a.check_dat > to_date('" + strBeginDate + "','yyyy-mm-dd hh24:mi:ss') " +
                @"and a.check_dat < to_date('" + strEndDate + "','yyyy-mm-dd hh24:mi:ss')) b left join " +
                @"(select f.* from t_opr_lis_device_relation f where f.deviceid_chr = '" + p_strDeviceID + "' " +
                @"and f.check_dat > to_date('" + strBeginDate + "','yyyy-mm-dd hh24:mi:ss') " +
                @"and f.check_dat < to_date('" + strEndDate + "','yyyy-mm-dd hh24:mi:ss')) c " +
                @"on b.deviceid_chr = c.DEVICEID_CHR and b.CHECK_DAT = c.CHECK_DAT 
					and b.DEVICE_SAMPLEID_CHR = c.DEVICE_SAMPLEID_CHR) d left join t_opr_lis_sample e
					on d.sample_id_chr = e.sample_id_chr ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceSampleList);
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

        #region 根据仪器号（不是型号，是一台具体仪器的代号）和检验日期范围，查询出符合条件(该仪器在该段时间内所检验的）标本资料
        //。返回结果必须包含仪器标本号，检验的项目（无子组的项目）
        //和检验日期。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDeviceId">设备ID</param>
        /// <param name="dtBegin">查询开始时间</param>
        /// <param name="dtEnd">查询结束时间</param>
        /// <param name="intDeviceSampleObj">0-全部标本;1-未审核标本</param>
        /// <param name="dtbDeviceSampleList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceSampleList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, DateTime p_dtBegin, DateTime p_dtEnd, int p_intDeviceSampleObj, out System.Data.DataTable p_dtbDeviceSampleList)
        {
            long lngRes = 0;
            string strSQL = null;
            p_dtbDeviceSampleList = null;
            strSQL = @"SELECT t2.deviceid_chr, t2.sample_id_chr, t2.device_sampleid_chr,t2.check_dat, t1.groupid_chr, t1.stepflag_chr,t3.groupname_vchr,t4.barcode_vchr, t4.application_form_no_chr,t4.status_int,t4.application_form_no_chr as application_id_chr
                         FROM t_opr_lis_req_check t1,t_opr_lis_device_relation t2, t_aid_lis_check_group t3, t_opr_lis_sample t4 
                         WHERE (t2.check_dat BETWEEN TO_DATE ('" + p_dtBegin.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss') AND TO_DATE ('" + p_dtEnd.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss')) 
                         AND t2.deviceid_chr = '" + p_strDeviceID + @"' AND t1.sample_id_chr = t2.sample_id_chr AND t4.sample_id_chr = t1.sample_id_chr 
                         AND t3.groupid_chr = t1.groupid_chr AND t4.status_int" + ((p_intDeviceSampleObj == 1) ? ">= 1 AND t4.status_int <= 5" : ">=1 AND t4.status_int <= 6");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceSampleList);
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

        #region 根据仪器号（不是型号，是一台具体仪器的代号）和检验日期范围，再加上一个检验项目（无子组）号，查询出符合条件（该仪器在该段时间内所检验的该检验项目的）标本资料。
        //返回结果必须包含仪器标本号，检验的项目（无子组的项目）和检验日期。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceID"></param>
        /// <param name="p_dtBegin"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="strCheckGroupID">组合ID（不包含子组）</param>
        /// <param name="p_intDeviceSampleObj">0-全部标本;1-未审核标本</param>
        /// <param name="p_dtbDeviceSample"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceSampleList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, DateTime p_dtBegin, DateTime p_dtEnd, string p_strCheckGroupID, int p_intDeviceSampleObj, out System.Data.DataTable p_dtbDeviceSample)
        {
            long lngRes = 0;
            p_dtbDeviceSample = null;
            string strSQL = null;

            strSQL = @"SELECT t2.deviceid_chr, t2.sample_id_chr, t2.device_sampleid_chr,t2.check_dat, t1.groupid_chr, t1.stepflag_chr, t3.groupname_vchr
                         FROM t_opr_lis_req_check t1,t_opr_lis_device_relation t2, t_aid_lis_check_group t3
                         WHERE (t2.check_dat BETWEEN TO_DATE ('" + p_dtBegin.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss') AND TO_DATE ('" + p_dtEnd.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss'))
                         AND t2.deviceid_chr = '" + p_strDeviceID + @"' AND t1.groupid_chr = '" + p_strCheckGroupID + @"' AND t1.sample_id_chr = t2.sample_id_chr
                         AND t3.groupid_chr = t1.groupid_chr AND t1.stepflag_chr" + ((p_intDeviceSampleObj == 1) ? "='1'" : ">='1'");

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceSample);
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

        #region 根据仪器号（不是型号，是一台具体仪器的代号）和检验日期范围，再加上仪器标本号范围，查询出符合条件（该仪器在该段时间内所检验的标本范围内的）标本资料。
        [AutoComplete]
        public long m_lngGetDeviceSampleList(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceId, DateTime p_dtBegin, DateTime p_dtEnd, string p_strDeviceSampleIDBegin, string p_strDeviceSampleIDEnd, int p_intDeviceSampleObj, out System.Data.DataTable p_dtbDeviceSampleList)
        {
            long lngRes = 0;
            p_dtbDeviceSampleList = null;
            string strSQL = null;
            strSQL = @"SELECT t2.deviceid_chr, t2.sample_id_chr, t2.device_sampleid_chr,t2.check_dat, t1.groupid_chr, t1.stepflag_chr, t3.groupname_vchr
                         FROM t_opr_lis_req_check t1,t_opr_lis_device_relation t2, t_aid_lis_check_group t3
                         WHERE (t2.check_dat BETWEEN TO_DATE ('" + p_dtBegin.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss') AND TO_DATE ('" + p_dtEnd.ToString() + @"', 'YYYY-MM-DD hh24:mi:ss'))
                         AND t2.device_sampleid_chr BETWEEN '" + p_strDeviceSampleIDBegin + @"' AND '" + p_strDeviceSampleIDEnd +
                @"' AND t2.deviceid_chr = '" + p_strDeviceId + @"' AND t1.sample_id_chr = t2.sample_id_chr
                         AND t3.groupid_chr = t1.groupid_chr AND t1.stepflag_chr" + ((p_intDeviceSampleObj == 1) ? "='1'" : ">='1'");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceSampleList);
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

        #region  根据仪器标本号列表（即一个集合，放在DataTable中）, 查询出该标本的所有检验项目的结果项的代号、名称、值等详细内容。
        /// <summary>
        /// 注意，这里是从t_opr_lis_result表中查询，所得到的结果为仪器输出的结果
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbDeviceSampleList">此结构和上面方法的DataTable结构相同</param>
        /// <param name="p_dtbDeviceResultList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceResultList(System.Security.Principal.IPrincipal p_objPrincipal, System.Data.DataTable p_dtbDeviceSampleList, out System.Data.DataTable p_dtbDeviceResultList)
        {
            long lngRes = 0;
            p_dtbDeviceResultList = null;
            string strSQL = null;
            string strDeviceSampleID;
            string strDeviceId;
            DateTime dtCheckDate;
            DataRow drDeviceResult;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                for (int i = 0; i < p_dtbDeviceSampleList.Rows.Count; i++)
                {
                    if (p_dtbDeviceSampleList.Rows[i]["DEVICE_SAMPLEID_CHR"] != System.DBNull.Value)
                    {
                        strDeviceSampleID = p_dtbDeviceSampleList.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        dtCheckDate = (DateTime)(p_dtbDeviceSampleList.Rows[i]["CHECK_DAT"]);
                        strDeviceId = p_dtbDeviceSampleList.Rows[i]["DEVICEID_CHR"].ToString().Trim();

                        strSQL = @"select t1.IDX_INT,	t1.result_vchr,t1.device_check_item_name_vchr,
								t1.unit_vchr,t1.device_sampleid_chr,t1.refrange_vchr,t1.min_val_dec,t1.max_val_dec,
								t1.abnormal_flag_vchr,t1.deviceid_chr,t1.check_dat,t1.PStatus_int,t2.sample_id_chr
								from t_opr_lis_result t1,t_opr_lis_device_relation t2 
                                where t1.device_sampleid_chr='" + strDeviceSampleID
                            + @"' and t1.deviceid_chr='" + strDeviceId + @"' and 
                                t1.check_dat = to_date('" + dtCheckDate.ToString() + @"','yyyy-mm-dd hh24:mi:ss')
								and t1.IDX_INT >= (select max(begin_idx_int) from t_opr_lis_result_log t3 where
                                t3.device_sampleid_chr='" + strDeviceSampleID + @"' and t3.deviceid_chr='" + strDeviceId + @"' and 
                                t3.check_dat = to_date('" + dtCheckDate.ToString() + @"','yyyy-mm-dd hh24:mi:ss'))
                                and t1.device_sampleid_chr=t2.device_sampleid_chr 
                                and t1.deviceid_chr=t2.deviceid_chr
							    and t1.check_dat=t2.check_dat";

                        System.Data.DataTable objDT_ResultListTmp = null;
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objDT_ResultListTmp);
                        objHRPSvc.Dispose();
                        if (lngRes > 0)
                        {
                            if (p_dtbDeviceResultList == null)
                            {
                                p_dtbDeviceResultList = objDT_ResultListTmp.Clone();
                            }
                            for (int j = 0; j < objDT_ResultListTmp.Rows.Count; j++)
                            {
                                drDeviceResult = p_dtbDeviceResultList.NewRow();
                                drDeviceResult.ItemArray = objDT_ResultListTmp.Rows[j].ItemArray;
                                p_dtbDeviceResultList.Rows.Add(drDeviceResult);
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 

            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 根据仪器标本号列表（即一个集合，放在DataTable中），查询出该标本的所要进行的检验项目的结果项的代号、名称等详细内容。
        /// <summary>
        /// 注意，这里要根据仪器标本号查询出对应的标本号（系统内部给定的）；根据标本号，从t_opr_lis_req_check和t_opr_lis_req_check_detail中查询结果。这里得到的结果与方法11所得到的结果相似，但没有结果值。另外，可能多了一些计算类的结果记录。
        //Long getResultList(DataTable dtbDeviceSample, out DataTable dtbResultList)
        //说明：这里，dtbDeviceSample的结构与方法8~11一样。其中，包含了检验日期。另外，dtbResultList中要有结果值字段，虽然该字段暂时为空。请参考t_opr_lis_check_result表结构确定此返回结果的结构。
        //2004.2.26郑大鹏修改
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbDeviceSample"></param>
        /// <param name="p_dtbResultList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetResultList(System.Security.Principal.IPrincipal p_objPrincipal, System.Data.DataTable p_dtbDeviceSample, out System.Data.DataTable p_dtbResultList)
        {
            long lngRes = 0;
            p_dtbResultList = null;
            string strSQL = null;
            string strDeviceSampleID;
            DateTime dtCheckDate;
            string strDeviceId;
            DataRow drResultList;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                for (int i = 0; i < p_dtbDeviceSample.Rows.Count; i++)
                {
                    if (p_dtbDeviceSample.Rows[i]["device_sampleid_chr"] != System.DBNull.Value)
                    {
                        strDeviceSampleID = p_dtbDeviceSample.Rows[i]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        dtCheckDate = (DateTime)(p_dtbDeviceSample.Rows[i]["CHECK_DAT"]);
                        strDeviceId = p_dtbDeviceSample.Rows[i]["DEVICEID_CHR"].ToString().Trim();
                        //following sql clause modified by chen kun.
                        strSQL = @"SELECT SYSDATE modify_dat, tt1.groupid_chr, tt1.check_item_id_chr,tt1.sample_id_chr,
                              NULL raw_result_vchr, NULL result_vchr, NULL unit_vchr,
                              tt1.deviceid_chr, NULL refrange_vchr, tt1.check_item_name_vchr,
                              tt1.check_item_english_name_vchr, NULL min_val_dec, NULL max_val_dec,
                              NULL abnormal_flag_chr, NULL check_dat,
                              tt1.clinic_meaning_vchr clinicapp_vchr, NULL memo_vchr,
                              NULL pointliststr_vchr, NULL summary_vchr, NULL graph_img,
                              (CASE
                                 WHEN LENGTH (tt1.formula_vchr) > 0
                                 THEN 1
                                 ELSE 0
                              END) iscalitem, tt1.formula_vchr, tt2.device_check_item_id_chr,
                              tt2.device_check_item_name_vchr, tt2.has_graph_result_int,NULL idx_int,NULL isdirty,NULL saved,
							  tt1.resulttype_chr
                              FROM (SELECT t1.deviceid_chr, t1.check_dat, t1.device_sampleid_chr,
                              t1.sample_id_chr, t2.check_item_id_chr, t2.groupid_chr,
                              t3.check_item_name_vchr, t3.check_item_english_name_vchr,
                              t3.formula_vchr, t3.clinic_meaning_vchr,t3.resulttype_chr
                              FROM t_opr_lis_device_relation t1,
                                   t_opr_lis_req_check_detail t2,
                                   t_bse_lis_check_item t3
                              WHERE t1.sample_id_chr = t2.sample_id_chr
                               AND t2.check_item_id_chr = t3.check_item_id_chr
                               AND t1.deviceid_chr = '" + strDeviceId + @"'
                               AND t1.device_sampleid_chr = '" + strDeviceSampleID + @"'
                               AND t1.check_dat = to_date('" + dtCheckDate.ToString() + @"','yyyy-mm-dd hh24:mi:ss')) tt1,
                            (SELECT t1.deviceid_chr, t1.device_model_id_chr, t2.check_item_id_chr,
                             t2.device_check_item_id_chr, t3.device_check_item_name_vchr,
                             t3.has_graph_result_int
                             FROM t_bse_lis_device t1,
                              t_bse_lis_check_item_dev_item t2,
                              t_bse_lis_device_check_item t3
                             WHERE t1.device_model_id_chr = t2.device_model_id_chr
                                  AND t2.device_check_item_id_chr = t3.device_check_item_id_chr
                                  AND t2.device_model_id_chr = t3.device_model_id_chr
                                  AND t1.deviceid_chr = '" + strDeviceId + @"') tt2
                             WHERE tt1.check_item_id_chr = tt2.check_item_id_chr";

                        System.Data.DataTable objDT_ResultListTmp = null;
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objDT_ResultListTmp);
                        objHRPSvc.Dispose();
                        if (lngRes > 0)
                        {
                            if (p_dtbResultList == null)
                            {
                                p_dtbResultList = objDT_ResultListTmp.Clone();
                            }
                            for (int j = 0; j < objDT_ResultListTmp.Rows.Count; j++)
                            {
                                drResultList = p_dtbResultList.NewRow();
                                //drResultList = new DataRow();
                                drResultList.ItemArray = objDT_ResultListTmp.Rows[j].ItemArray;
                                p_dtbResultList.Rows.Add(drResultList);
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
            }
            finally
            {
                objHRPSvc.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 根据仪器标本号列表（即一个集合，放在DataTable中），查询出该标本的检验项目的已经有的结果详细内容。
        [AutoComplete]
        public long m_lngGetCurrentResultList(System.Security.Principal.IPrincipal p_objPrincipal, System.Data.DataTable p_dtbDeviceSampleList, out System.Data.DataTable p_dtbCurrentResults)
        {
            long lngRes = 0;
            p_dtbCurrentResults = null;
            string strSampleID;
            string strGroupId;
            DataRow drCurrentResult;
            System.Data.DataTable objDT_ResultListTmp = null;
            try
            {
                for (int i = 0; i < p_dtbDeviceSampleList.Rows.Count; i++)
                {
                    if ((p_dtbDeviceSampleList.Rows[i]["SAMPLE_ID_CHR"] != System.DBNull.Value) && (p_dtbDeviceSampleList.Rows[i]["GROUPID_CHR"] != System.DBNull.Value))
                    {
                        strSampleID = p_dtbDeviceSampleList.Rows[i]["SAMPLE_ID_CHR"].ToString().Trim();
                        strGroupId = p_dtbDeviceSampleList.Rows[i]["GROUPID_CHR"].ToString().Trim();
                        lngRes = this.m_lngGetCheckResult(p_objPrincipal, strSampleID, strGroupId, out objDT_ResultListTmp);

                        if (lngRes > 0)
                        {
                            if (p_dtbCurrentResults == null)
                            {
                                p_dtbCurrentResults = objDT_ResultListTmp.Clone();
                            }
                            for (int j = 0; j < objDT_ResultListTmp.Rows.Count; j++)
                            {
                                drCurrentResult = p_dtbCurrentResults.NewRow();
                                drCurrentResult.ItemArray = objDT_ResultListTmp.Rows[j].ItemArray;
                                p_dtbCurrentResults.Rows.Add(drCurrentResult);
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 

            }
            return lngRes;
        }
        #endregion

        #region 根据样本号、检验项目（不含子组），查询对应的检验结果（这里从t_opr_lis_check_result查询）
        [AutoComplete]
        public long m_lngGetCheckResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleID, string p_strCheckGroupID, out System.Data.DataTable p_dtbCheckResult)
        {
            long lngRes = 0;
            p_dtbCheckResult = null;
            string strSQL = @"SELECT t1.modify_dat, t1.groupid_chr, t1.check_item_id_chr, t1.sample_id_chr, t1.result_vchr,
							t1.unit_vchr, t1.deviceid_chr, t1.device_check_item_name_vchr, t1.refrange_vchr,
							t1.check_item_name_vchr, t1.check_item_english_name_vchr, t1.min_val_dec,
							t1.max_val_dec, t1.abnormal_flag_chr, t1.check_dat, t1.clinicapp_vchr, t1.memo_vchr,
							t1.confirm_dat, t1.pointliststr_vchr, t1.summary_vchr, t1.graph_img, t1.status_int,
							t1.checker1_chr, t1.checker2_chr, t1.confirm_person_chr, t1.operator_id_chr,
							t1.check_deptid_chr,t2.lastname_vchr as confirmPerson,t3.lastname_vchr as checkPerson
							FROM t_opr_lis_check_result t1,t_bse_employee t2,t_bse_employee t3
							WHERE groupid_chr = '" + p_strCheckGroupID + @"'
							AND (t1.confirm_person_chr = t2.empid_chr(+))
							AND (t1.checker1_chr = t3.empid_chr(+))
							AND sample_id_chr = '" + p_strSampleID + "'and t1.status_int=1";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckResult);
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

        #region 查询两个标本的检验结果
        [AutoComplete]
        public long m_lngGetUnionCheckResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSmapleIDFirst, string p_strGroupIDFirst, string p_strSampleIDSecond, string p_strGroupIDSecond, out System.Data.DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            string strSQL = @"SELECT modify_dat, groupid_chr, check_item_id_chr, sample_id_chr, result_vchr,
								unit_vchr, deviceid_chr, device_check_item_name_vchr, refrange_vchr,
								check_item_name_vchr, check_item_english_name_vchr, min_val_dec,
								max_val_dec, abnormal_flag_chr, check_dat, clinicapp_vchr, memo_vchr,
								confirm_dat, pointliststr_vchr, summary_vchr, graph_img, t1.status_int,
								checker1_chr, checker2_chr, confirm_person_chr, operator_id_chr,
								check_deptid_chr,t2.lastname_vchr as confirmPerson,t3.lastname_vchr as checkPerson
							FROM t_opr_lis_check_result t1,t_bse_employee t2,t_bse_employee t3
							WHERE (t1.confirm_person_chr = t2.empid_chr(+))
   AND (t1.checker1_chr = t3.empid_chr(+)) AND  groupid_chr in ( '" + p_strGroupIDFirst + "','" + p_strGroupIDSecond + "') AND sample_id_chr in ('" + p_strSmapleIDFirst + "','" + p_strSampleIDSecond + "') AND t1.status_int = 1 ";


            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region 根据检验日期或者审核日期查询检验单号(不得重复)
        [AutoComplete]
        public long m_lngGetApplFormNOByDateRange(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDateFieldName, System.DateTime p_dtBegin, System.DateTime p_dtEnd, out System.Data.DataTable p_dtbAppl)
        {
            long lngRes = 0;
            p_dtbAppl = null;
            string strSQL = @"SELECT DISTINCT application_form_no_chr
							FROM t_opr_lis_sample
							WHERE status_int=1 and  sample_id_chr IN (
									SELECT  sample_id_chr
												FROM t_opr_lis_check_result
												WHERE status_int=1 and " + p_strDateFieldName + " BETWEEN '" + p_dtBegin + @"'
																				AND '" + p_dtEnd + "')";
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

        #region 根据SampleID,GroupID（基本检验组）查询结果项,这里要查询两个表，一个是t_opr_lis_check_result,一个是t_aid_lis_check_group_detail，打印时按打印类别，打印顺序打印。
        [AutoComplete]
        /// <summary>
        /// 根据SampleID,GroupID（基本检验组）查询结果项
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strGroupID"></param>
        /// <param name="p_strSmapleID"></param>
        /// <param name="p_dtbPrintResult">
        /// modify_dat
        /// groupid_chr
        /// check_item_id_chr
        /// sample_id_chr
        /// result_vchr
        /// unit_vchr 
        /// device_check_item_name_vchr
        /// refrange_vchr
        /// check_item_name_vchr
        /// check_item_english_name_vchr
        /// min_val_dec
        /// max_val_dec
        /// abnormal_flag_chr
        /// check_dat
        /// clinicapp_vchr
        /// memo_vchr
        /// confirm_dat
        /// deviceid_chr
        /// pointliststr_vchr
        /// summary_vchr
        /// graph_img
        /// status_int
        /// checker1_chr
        /// checker2_chr
        /// confirm_person_chr
        /// operator_id_chr
        /// check_deptid_chr
        /// print_ord_int
        /// </param>
        /// <returns></returns>
        public long m_lngGetPrintResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strGroupID, string p_strSmapleID, out System.Data.DataTable p_dtbPrintResult)
        {
            long lngRes = 0;
            p_dtbPrintResult = null;
            string strSQL = @"SELECT t1.modify_dat, t1.groupid_chr, t1.check_item_id_chr, t1.sample_id_chr,
							t1.result_vchr, t1.unit_vchr, t1.device_check_item_name_vchr,
							t1.refrange_vchr, t1.check_item_name_vchr,
							t1.check_item_english_name_vchr, t1.min_val_dec, t1.max_val_dec,
							t1.abnormal_flag_chr, t1.check_dat, t1.clinicapp_vchr, t1.memo_vchr,
							t1.confirm_dat, t1.deviceid_chr, t1.pointliststr_vchr, t1.summary_vchr,
							t1.graph_img, t1.status_int, t1.checker1_chr, t1.checker2_chr,
							t1.confirm_person_chr, t1.operator_id_chr, t1.check_deptid_chr,
							t2.print_ord_int
							FROM t_opr_lis_check_result t1, t_aid_lis_check_group_detail t2
							WHERE t1.groupid_chr = '" + p_strGroupID + @"'
							AND t1.sample_id_chr = '" + p_strSmapleID + @"'
							AND t1.groupid_chr = t2.groupid_chr 
							AND t1.status_int > 0 
							AND t1.check_item_id_chr = t2.check_item_id_chr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbPrintResult);
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

        #region  根据仪器标本号, 仪器号，检验日期查询出该标本的所有结果项的代号、名称、值等详细内容。
        [AutoComplete]
        public long m_lngGetDeviceSampleResultList(System.Security.Principal.IPrincipal p_objPrincipal, string strDeviceID, string strDeviceSampleID, string strCheckDate, out System.Data.DataTable dtbSampleResultList)
        {
            long lngRes = 0;
            dtbSampleResultList = null;
            string strSQL = @"SELECT tab1.check_item_name_vchr, tab2.result_vchr, tab2.unit_vchr,
		                        tab2.refrange_vchr, tab2.max_val_dec, tab2.min_val_dec,tab2.abnormal_flag_vchr
			                  FROM 
                                (SELECT t11.check_item_name_vchr, t12.device_check_item_name_vchr
								   FROM t_bse_lis_check_item t11,t_bse_lis_device_check_item t12,
									  t_bse_lis_check_item_dev_item t13,t_bse_lis_device t14
								   WHERE t14.deviceid_chr = '" + strDeviceID + @"' AND t12.device_model_id_chr = t14.device_model_id_chr
								   AND t13.device_check_item_id_chr = t12.device_check_item_id_chr
								   AND t13.device_model_id_chr = t12.device_model_id_chr 
                                   AND t11.check_item_id_chr = t13.check_item_id_chr) tab1,
		                        (SELECT t1.device_check_item_name_vchr, t1.result_vchr, t1.unit_vchr,
		                                t1.refrange_vchr, t1.max_val_dec, t1.min_val_dec, t1.abnormal_flag_vchr
			                       FROM t_opr_lis_result t1
					               WHERE t1.device_sampleid_chr = '" + strDeviceSampleID + @"'
		                           AND t1.check_dat = TO_DATE ('" + strCheckDate + @"', 'yyyy-mm-dd hh24:mi:ss')
		                           AND t1.deviceid_chr = '" + strDeviceID + @"'
		                           AND t1.idx_int >=
		                              (SELECT MAX (t2.begin_idx_int)
			                             FROM t_opr_lis_result_log t2
										 WHERE t2.device_sampleid_chr = '" + strDeviceSampleID + @"'
		                                 AND t2.check_dat = TO_DATE ('" + strCheckDate + @"', 'yyyy-mm-dd hh24:mi:ss')
		                                 AND t2.deviceid_chr = '" + strDeviceID + @"')) tab2
							  WHERE tab2.device_check_item_name_vchr = tab1.device_check_item_name_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbSampleResultList);
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
        #endregion

        #region 获取签名图片
        /// <summary>
        /// 获取签名图片
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        [AutoComplete]
        public byte[] GetEmpSign(string empName)
        {
            byte[] data = null;
            string Sql = string.Empty;
            clsHRPTableService svc = null;
            try
            {
                Sql = @"select a.sign_grp
                          from t_bse_empsign a
                         inner join t_bse_employee b
                            on a.empid_chr = b.empid_chr
                         where b.status_int = 1
                           and b.lastname_vchr = ?";
                svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = empName;

                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] != DBNull.Value) data = (byte[])dt.Rows[0][0];
                }
            }
            catch (Exception ex)
            {
                clsLogText log = new clsLogText();
                log.LogDetailError(ex, true);
            }
            finally
            {
                svc = null;
            }
            return data;
        }
        #endregion

    }
}
