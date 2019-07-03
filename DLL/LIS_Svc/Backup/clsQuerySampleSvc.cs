using System;
using System.Collections;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using System.EnterpriseServices;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility; //Utility.dll
using Microsoft.VisualBasic;
using System.Text;
using System.Data;
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQuerySampleSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region	根据标本号查询标本状态
        [AutoComplete]
        public long m_lngFindStatusBySampleID(System.Security.Principal.IPrincipal objPrincipal, string p_strSampleID, out int p_intStatus)
        {
            p_intStatus = 8;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngFindStatusBySampleID");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();

            string strSQL = @"select status_int from t_opr_lis_sample t where sample_id_chr = '" + p_strSampleID + "'";

            try
            {
                lngRes = 0;
                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                if (lngRes < 0)
                {
                    return -1;
                }

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    string strStatus = dtResult.Rows[0][0].ToString();
                    p_intStatus = int.Parse(strStatus);
                }
            }
            catch (Exception objEx)
            {
                string strTemp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 标本接收

        #region 根据BarCode查询待接收的样本信息
        /// <summary>
        /// 根据BarCode查询待接收的样本信息
        /// </summary>
        [AutoComplete]
        public long m_mthGetUnReceivedSampleByBarCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBarCode,
            out clsSampleReceive_VO p_objRecord)
        {
            long lngRes = 0;
            p_objRecord = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_mthGetUnReceivedSampleByBarCode");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.appl_dat,
       a.barcode_vchr,
       a.patient_type_chr,
       a.sampletype_vchr,
       a.accept_dat,
       a.sample_id_chr,
       a.status_int,
       a.acceptor_id_chr,
       a.sendsample_empid_chr,
       b.patient_name_vchr,
       b.sex_chr,
       b.age_chr,
       b.patientid_chr,
       b.patientcardid_chr,
       b.patient_inhospitalno_chr,
       b.patient_subno_chr,
       b.appl_deptid_chr,
       b.appl_empid_chr,
       b.bedno_chr,
       b.application_id_chr,
       b.check_content_vchr,
       b.special_int,
       b.emergency_int,
       c.lastname_vchr,
       e.dictname_vchr,
       f.lastname_vchr as sendname
  from t_opr_lis_sample a,
       t_opr_lis_application b,
       t_bse_employee c,
       (select d.dictid_chr, d.dictname_vchr
          from t_aid_dict d
         where trim(d.dictid_chr) <> 0
           and dictkind_chr = '61') e,
       t_bse_employee f
 where a.application_id_chr = b.application_id_chr
   and a.patient_type_chr = e.dictid_chr(+)
   and a.sendsample_empid_chr = f.empid_chr(+)
   and b.pstatus_int > 0
   and a.status_int > 0
   and a.acceptor_id_chr = c.empid_chr(+)
   and a.barcode_vchr = '" + p_strBarCode + "' order by appl_dat desc";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    p_objRecord = objConstructor.m_mthContructSampleReceiveVO(dtbResult.Rows[0]);
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

        #region 根据条件查询已接收的标本信息
        [AutoComplete]
        public long m_lngGetReceivedSampleByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDatFrom, string p_strDatTo,
            string p_strSampleType, string p_strAcceptEmp, string p_strPatientName, string p_strPatientCardID, string p_strBarCode, string p_strCheckCategory,string p_strSendPeopleID,string p_strInPatientNum, out clsSampleReceive_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetReceivedSampleByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.barcode_vchr,
       a.patient_type_chr,
       a.sampletype_vchr,
       a.accept_dat,
       a.sample_id_chr,
       a.status_int,
       a.acceptor_id_chr,
       a.sendsample_empid_chr,
       b.patient_name_vchr,
       b.sex_chr,
       b.age_chr,
       b.patientid_chr,
       b.patientcardid_chr,
       b.patient_inhospitalno_chr,
       b.patient_subno_chr,
       b.appl_deptid_chr,
       b.appl_empid_chr,
       b.bedno_chr,
       b.application_id_chr,
       b.check_content_vchr,
       b.special_int,
       b.emergency_int,
       t.isgreen_int,
       c.lastname_vchr,
       e.dictname_vchr,
       f.lastname_vchr as sendname
  from t_opr_lis_sample a,
       t_opr_lis_application b,
       t_opr_attachrelation t,
       t_bse_employee c,
       (select d.dictid_chr, d.dictname_vchr
          from t_aid_dict d
         where trim(d.dictid_chr) <> 0
           and dictkind_chr = '61') e,
       t_bse_employee f
 where a.application_id_chr = b.application_id_chr
   and a.application_id_chr = t.attachid_vchr(+)
   and b.pstatus_int > 0
   and a.patient_type_chr = e.dictid_chr(+)
   and a.acceptor_id_chr = c.empid_chr(+)
   and a.sendsample_empid_chr=f.empid_chr(+)
   and a.status_int > 2
   and a.status_int < 7
and a.accept_dat between to_date('" + p_strDatFrom + @"','yyyy-mm-dd hh24:mi:ss') 
	  and to_date('" + p_strDatTo + @"','yyyy-mm-dd hh24:mi:ss')";

            if (p_strSampleType != null && p_strSampleType != "")
            {
                strSQL += " and a.sampletype_vchr = '" + p_strSampleType + @"'";
            }

            if (p_strAcceptEmp != null && p_strAcceptEmp != "")
            {
                strSQL += " and a.acceptor_id_chr = '" + p_strAcceptEmp + @"'";
            }

            if (p_strPatientName != null && p_strPatientName.Trim() != "")
            {
                strSQL += " and b.patient_name_vchr like '%" + p_strPatientName + "%'";
            }

            if (p_strPatientCardID != null && p_strPatientCardID.Trim() != "")
            {
                strSQL += " and b.patientcardid_chr = '" + p_strPatientCardID + "'";
            }

            if (p_strBarCode != null && p_strBarCode.Trim() != "")
            {
                strSQL += " and a.barcode_vchr = '" + p_strBarCode + "'";
            }
            if (!string.IsNullOrEmpty(p_strSendPeopleID))
            {
                strSQL += " and a.sendsample_empid_chr ='" + p_strSendPeopleID + "'";
            }
            if (p_strCheckCategory != null && p_strCheckCategory.Trim() != "")   //新增按自定义申请组查询  baojian.mo 2007.09.10 add
            {
                strSQL += @" and b.check_content_vchr in (select t2.apply_unit_name_vchr
                              from t_aid_lis_appuser_group_detail t1,
                                   t_aid_lis_apply_unit t2,
                                   (select a.user_group_id_chr, a.user_group_name_vchr
                                      from t_aid_lis_appuser_group a
                                     where not exists (
                                                     select child_user_group_id_chr
                                                       from t_aid_lis_appuser_group_relate b
                                                      where a.user_group_id_chr =
                                                                                 b.child_user_group_id_chr)
                                       and a.user_group_name_vchr = '" + p_strCheckCategory + @"') t3
                             where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                               and t1.user_group_id_chr = t3.user_group_id_chr
                            union all
                            select t2.apply_unit_name_vchr
                              from t_aid_lis_appuser_group_detail t1,
                                   t_aid_lis_apply_unit t2,
                                   (select t4.child_user_group_id_chr
                                      from t_aid_lis_appuser_group_relate t4,
                                           (select a.user_group_id_chr, a.user_group_name_vchr
                                              from t_aid_lis_appuser_group a
                                             where not exists (
                                                      select child_user_group_id_chr
                                                        from t_aid_lis_appuser_group_relate b
                                                       where a.user_group_id_chr =
                                                                                 b.child_user_group_id_chr)) t5
                                     where t4.user_group_id_chr = t5.user_group_id_chr
                                       and t5.user_group_name_vchr = '" + p_strCheckCategory + @"') t3
                             where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                               and t1.user_group_id_chr = t3.child_user_group_id_chr
                            union all
                            select t2.apply_unit_name_vchr
                              from t_aid_lis_appuser_group_detail t1,
                                   t_aid_lis_apply_unit t2,
                                   (select t4.child_user_group_id_chr
                                      from t_aid_lis_appuser_group_relate t4,
                                           (select a.user_group_id_chr, a.user_group_name_vchr
                                              from t_aid_lis_appuser_group a
                                             where not exists (
                                                      select child_user_group_id_chr
                                                        from t_aid_lis_appuser_group_relate b
                                                       where a.user_group_id_chr =
                                                                                 b.child_user_group_id_chr)) t5
                                     where t4.user_group_id_chr = t5.user_group_id_chr
                                       and t5.user_group_name_vchr = '" + p_strCheckCategory + @"') t3
                             where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                               and t1.user_group_id_chr = t3.child_user_group_id_chr)";
            }
            if (!string.IsNullOrEmpty(p_strInPatientNum))
            {
                strSQL += " and trim(a.patient_inhospitalno_chr)='" + p_strInPatientNum + "'";
            }

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    p_objResultArr = new clsSampleReceive_VO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = objConstructor.m_mthContructSampleReceiveVO(dtbResult.Rows[i]);
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

        #region 根据条件查询已采集但未接收的标本信息
        /// <summary>
        /// 根据条件查询已采集但未接收的标本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDatFrom"></param>
        /// <param name="p_strDatTo"></param>
        /// <param name="p_strSampleType"></param>
        /// <param name="p_strConlectEmp"></param>
        /// <param name="p_strPatientName"></param>
        /// <param name="p_strPatientCardID"></param>
        /// <param name="p_strBarCode"></param>
        /// <param name="p_strCheckCategory"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUnReceivedSampleByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDatFrom,
            string p_strDatTo, string p_strSampleType, string p_strConlectEmp, string p_strPatientName,
            string p_strPatientCardID, string p_strBarCode, string p_strCheckCategory,string p_strSendPeopleID,string p_strInPatientNum, out clsSampleUnReceive_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetUnReceivedSampleByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL Builder
            string strSQL = @"select a.barcode_vchr,
       a.patient_type_chr,
       a.sampletype_vchr,
       a.sampling_date_dat,
       a.sample_id_chr,
       a.status_int,
       a.collector_id_chr,
       b.patient_name_vchr,
       b.check_content_vchr,
       b.special_int,
       b.emergency_int,
       t.isgreen_int,
       c.lastname_vchr,
       e.dictname_vchr
  from t_opr_lis_sample a,
       t_opr_lis_application b,
       t_opr_attachrelation t,
       t_bse_employee c,
       (select d.dictid_chr, d.dictname_vchr
          from t_aid_dict d
         where trim(d.dictid_chr) <> 0
           and dictkind_chr = '61') e
 where a.application_id_chr = b.application_id_chr
   and a.application_id_chr = t.attachid_vchr
   and t.status_int = 1
   and b.pstatus_int > 0
   and a.patient_type_chr = e.dictid_chr(+)
   and a.collector_id_chr = c.empid_chr(+)
   and a.status_int = 2
   and a.sampling_date_dat between  ? and  ?
";

            ArrayList alParams = new ArrayList();
            alParams.Add(Convert.ToDateTime(p_strDatFrom));
            alParams.Add(Convert.ToDateTime(p_strDatTo));

            if (p_strSampleType != null && p_strSampleType != "")
            {
                strSQL += " and a.sampletype_vchr = ?";
                alParams.Add(p_strSampleType);
            }

            if (p_strConlectEmp != null && p_strConlectEmp != "")
            {
                strSQL += " and a.collector_id_chr = ?";
                alParams.Add(p_strConlectEmp);
            }

            if (p_strPatientName != null && p_strPatientName.Trim() != "")
            {
                strSQL += " and b.patient_name_vchr like ?";
                alParams.Add("%" + p_strPatientName + "%");
            }

            if (p_strPatientCardID != null && p_strPatientCardID.Trim() != "")
            {
                strSQL += " and b.patientcardid_chr = ?";
                alParams.Add(p_strPatientCardID);
            }

            if (p_strBarCode != null && p_strBarCode.Trim() != "")
            {
                strSQL += " and a.barcode_vchr = ?";
                alParams.Add(p_strBarCode);
            }
            if (!string.IsNullOrEmpty(p_strSendPeopleID))
            {
                strSQL += "and a.sendsample_empid_chr = ?";
                alParams.Add(p_strSendPeopleID);
            }
            if (!string.IsNullOrEmpty(p_strInPatientNum))
            {
                strSQL += "and trim(a.patient_inhospitalno_chr) = ?";
                alParams.Add(p_strInPatientNum);
            }
            if (p_strCheckCategory != null && p_strCheckCategory.Trim() != "")   //新增按自定义申请组查询
            {
                strSQL += System.Environment.NewLine;
                strSQL += @"and b.check_content_vchr in
       (select t2.apply_unit_name_vchr
          from t_aid_lis_appuser_group_detail t1,
               t_aid_lis_apply_unit t2,
               (select a.user_group_id_chr, a.user_group_name_vchr
                  from t_aid_lis_appuser_group a
                 where not exists
                 (select child_user_group_id_chr
                          from t_aid_lis_appuser_group_relate b
                         where a.user_group_id_chr = b.child_user_group_id_chr)
                   and a.user_group_name_vchr = ?) t3
         where t1.apply_unit_id_chr = t2.apply_unit_id_chr
           and t1.user_group_id_chr = t3.user_group_id_chr
        union all
        select t2.apply_unit_name_vchr
          from t_aid_lis_appuser_group_detail t1,
               t_aid_lis_apply_unit t2,
               (select t4.child_user_group_id_chr
                  from t_aid_lis_appuser_group_relate t4,
                       (select a.user_group_id_chr, a.user_group_name_vchr
                          from t_aid_lis_appuser_group a
                         where not exists
                         (select child_user_group_id_chr
                                  from t_aid_lis_appuser_group_relate b
                                 where a.user_group_id_chr =
                                       b.child_user_group_id_chr)) t5
                 where t4.user_group_id_chr = t5.user_group_id_chr
                   and t5.user_group_name_vchr = ?) t3
         where t1.apply_unit_id_chr = t2.apply_unit_id_chr
           and t1.user_group_id_chr = t3.child_user_group_id_chr
        union all
        select t2.apply_unit_name_vchr
          from t_aid_lis_appuser_group_detail t1,
               t_aid_lis_apply_unit t2,
               (select t4.child_user_group_id_chr
                  from t_aid_lis_appuser_group_relate t4,
                       (select a.user_group_id_chr, a.user_group_name_vchr
                          from t_aid_lis_appuser_group a
                         where not exists
                         (select child_user_group_id_chr
                                  from t_aid_lis_appuser_group_relate b
                                 where a.user_group_id_chr =
                                       b.child_user_group_id_chr)) t5
                 where t4.user_group_id_chr = t5.user_group_id_chr
                   and t5.user_group_name_vchr = ?) t3
         where t1.apply_unit_id_chr = t2.apply_unit_id_chr
           and t1.user_group_id_chr = t3.child_user_group_id_chr)";

                alParams.Add(p_strCheckCategory);
                alParams.Add(p_strCheckCategory);
                alParams.Add(p_strCheckCategory);
            }

            strSQL += "    order by barcode_vchr";
            #endregion

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(alParams.Count, out objDPArr);
                for (int index = 0; index < alParams.Count; index++)
                {
                    if (alParams[index].GetType().Name == "DateTime")
                    {
                        objDPArr[index].DbType = DbType.DateTime;
                    }
                    objDPArr[index].Value = alParams[index];
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    clsVOConstructor objConstructor = new clsVOConstructor();
                    p_objResultArr = new clsSampleUnReceive_VO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objResultArr[i] = objConstructor.m_mthContructSampleUnReceiveVO(dtbResult.Rows[i]);
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

        #region 返回自定义组所有申请单元
        /// <summary>
        /// 返回自定义组所有申请单元
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckCategory"></param>
        /// <param name="p_dtbDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppuserGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckCategory, out DataTable p_dtbDetail)
        {
            long lngRes = 0;
            p_dtbDetail = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetAppuserGroupDetail");
            try
            {
                string strSQL = @"select t2.apply_unit_name_vchr
                                    from t_aid_lis_appuser_group_detail t1,
                                         t_aid_lis_apply_unit t2,
                                         (select a.user_group_id_chr, a.user_group_name_vchr
                                            from t_aid_lis_appuser_group a
                                           where not exists (
                                                           select child_user_group_id_chr
                                                             from t_aid_lis_appuser_group_relate b
                                                            where a.user_group_id_chr =
                                                                                       b.child_user_group_id_chr)
                                             and trim(a.user_group_name_vchr) = ? ) t3
                                   where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                     and t1.user_group_id_chr = t3.user_group_id_chr
                                  union all
                                  select t2.apply_unit_name_vchr
                                    from t_aid_lis_appuser_group_detail t1,
                                         t_aid_lis_apply_unit t2,
                                         (select t4.child_user_group_id_chr
                                            from t_aid_lis_appuser_group_relate t4,
                                                 (select a.user_group_id_chr, a.user_group_name_vchr
                                                    from t_aid_lis_appuser_group a
                                                   where not exists (
                                                            select child_user_group_id_chr
                                                              from t_aid_lis_appuser_group_relate b
                                                             where a.user_group_id_chr =
                                                                                       b.child_user_group_id_chr)) t5
                                           where t4.user_group_id_chr = t5.user_group_id_chr
                                             and trim(t5.user_group_name_vchr) = ? ) t3
                                   where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                     and t1.user_group_id_chr = t3.child_user_group_id_chr
                                  union all
                                  select t2.apply_unit_name_vchr
                                    from t_aid_lis_appuser_group_detail t1,
                                         t_aid_lis_apply_unit t2,
                                         (select t4.child_user_group_id_chr
                                            from t_aid_lis_appuser_group_relate t4,
                                                 (select a.user_group_id_chr, a.user_group_name_vchr
                                                    from t_aid_lis_appuser_group a
                                                   where not exists (
                                                            select child_user_group_id_chr
                                                              from t_aid_lis_appuser_group_relate b
                                                             where a.user_group_id_chr =
                                                                                       b.child_user_group_id_chr)) t5
                                           where t4.user_group_id_chr = t5.user_group_id_chr
                                             and trim(t5.user_group_name_vchr) = ? ) t3
                                   where t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                     and t1.user_group_id_chr = t3.child_user_group_id_chr";

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParam = null;
                objHRPSvc.CreateDatabaseParameter(3, out objParam);
                objParam[0].Value = p_strCheckCategory;
                objParam[1].Value = p_strCheckCategory;
                objParam[2].Value = p_strCheckCategory;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbDetail, objParam);
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
        #endregion

        #region 根据仪器ID查询插队记录
        [AutoComplete]
        public long m_lngGetSampleInterposeByDeviceID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID,
            out clsLisSampleInterposeVO p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleInterposeByDeviceID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT * 
							    FROM T_AID_LIS_SAMPLE_INTERPOSE 
							   WHERE DEVICEID_CHR = '" + p_strDeviceID + @"'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsLisSampleInterposeVO();
                    p_objResult.m_strBEGIN_DEVICE_SAMPLE_ID_CHR = dtbResult.Rows[0]["BEGIN_DEVICE_SAMPLE_ID_CHR"].ToString().Trim();
                    p_objResult.m_strCOMPLETE_FLAG_CHR = dtbResult.Rows[0]["COMPLETE_FLAG_CHR"].ToString().Trim();
                    p_objResult.m_strDEVICEID_CHR = dtbResult.Rows[0]["DEVICEID_CHR"].ToString().Trim();
                    p_objResult.m_strEND_DEVICE_SAMPLE_ID_CHR = dtbResult.Rows[0]["END_DEVICE_SAMPLE_ID_CHR"].ToString().Trim();
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

        #region 根据条件查询仪器与样本之间的关系
        [AutoComplete]
        public long m_lngGetDeviceRelationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, string p_strReceptDatFrom,
            string p_strReceptDatTo, out clsT_LIS_DeviceRelationVO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetDeviceRelationVOArrByCondition");

            #region SQL
            //			string strSQL = @"SELECT a.*,b.status_int as sample_status,b.barcode_vchr
            //								FROM t_opr_lis_device_relation a, t_opr_lis_sample b
            //							   WHERE a.sample_id_chr = b.sample_id_chr(+)
            //								 AND b.status_int >= 0";
            string strSQL = @"SELECT a.*, d.status_int AS sample_status, d.barcode_vchr,
									 d.application_form_no_chr
								FROM t_opr_lis_device_relation a,
									 (SELECT b.*, c.application_form_no_chr
										FROM t_opr_lis_sample b, t_opr_lis_application c
									   WHERE b.application_id_chr = c.application_id_chr
										 AND b.status_int >= 0
										 AND c.pstatus_int > 0) d
							   WHERE a.sample_id_chr = d.sample_id_chr(+)";
            string strSQL_ReceptDatFrom = " AND a.reception_dat >= ? ";
            string strSQL_ReceptDatTo = " AND a.reception_dat <= ? ";
            string strSQL_DeviceID = " AND a.deviceid_chr = ? ";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造
            if (p_strDeviceID != null && p_strDeviceID.Trim() != "")
            {
                arlSQL.Add(strSQL_DeviceID);
                arlParm.Add(p_strDeviceID);
            }
            if (p_strReceptDatFrom != null && Microsoft.VisualBasic.Information.IsDate(p_strReceptDatFrom.Trim()))
            {
                arlSQL.Add(strSQL_ReceptDatFrom);
                arlParm.Add(DateTime.Parse(p_strReceptDatFrom.Trim()));
            }
            if (p_strReceptDatTo != null && Microsoft.VisualBasic.Information.IsDate(p_strReceptDatTo.Trim()))
            {
                arlSQL.Add(strSQL_ReceptDatTo);
                arlParm.Add(DateTime.Parse(p_strReceptDatTo.Trim()));
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            strSQL += " ORDER BY to_number(a.seq_id_device_chr)";

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
                    p_objResultArr = new clsT_LIS_DeviceRelationVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        p_objResultArr[i1] = new clsT_LIS_DeviceRelationVO();
                        p_objResultArr[i1].m_strDEVICEID_CHR = dtbResult.Rows[i1]["DEVICEID_CHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["IMPORT_REQ_INT"].ToString().Trim() != "")
                        {
                            p_objResultArr[i1].m_intIMPORT_REQ_INT = int.Parse(dtbResult.Rows[i1]["IMPORT_REQ_INT"].ToString().Trim());
                        }
                        p_objResultArr[i1].m_strSEQ_ID_CHR = dtbResult.Rows[i1]["SEQ_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strRECEPTION_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["RECEPTION_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        p_objResultArr[i1].m_strDEVICE_SAMPLEID_CHR = dtbResult.Rows[i1]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["CHECK_DAT"].ToString().Trim() != "")
                        {
                            p_objResultArr[i1].m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        else
                        {
                            p_objResultArr[i1].m_strCHECK_DAT = dtbResult.Rows[i1]["CHECK_DAT"].ToString().Trim();
                        }
                        p_objResultArr[i1].m_strSAMPLE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPOSITIONID_CHR = dtbResult.Rows[i1]["POSITIONID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strSEQ_ID_DEVICE_CHR = dtbResult.Rows[i1]["SEQ_ID_DEVICE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intBIND_METHOD_INT = Convert.ToInt32(dtbResult.Rows[i1]["BIND_METHOD_INT"].ToString().Trim());
                        p_objResultArr[i1].m_intSAMPLE_STATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["sample_status"].ToString().Trim());
                        p_objResultArr[i1].m_strBARCODE_VCHR = dtbResult.Rows[i1]["barcode_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strCheckNO = dtbResult.Rows[i1]["application_form_no_chr"].ToString().Trim();
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

        #region 根据标本的BarCode查询相应的标本及标本组信息
        [AutoComplete]
        public long m_lngGetSampleInfoByBarCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBarCode,
            out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleGroupByBarCode");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.*,c.*, d.device_model_desc_vchr
								FROM t_opr_lis_sample a,
									 t_opr_lis_app_sample b,
									 t_aid_lis_sample_group c,
									 t_bse_lis_device_model d
							   WHERE a.sample_id_chr = b.sample_id_chr
								 AND b.sample_group_id_chr = c.sample_group_id_chr
								 AND c.device_model_id_chr = d.device_model_id_chr
								 AND a.status_int > 0
								 AND a.barcode_vchr = '" + p_strBarCode + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        #region 获取所有的标本类型信息
        [AutoComplete]
        public long m_lngGetSampleTypeArr(System.Security.Principal.IPrincipal p_objPrincipal, out clsSampleType_VO[] p_objResultArr)
        {
            p_objResultArr = new clsSampleType_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleTypeArr");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select sample_type_id_chr, sample_type_desc_vchr, pycode_chr, wbcode_chr,
       stdcode1_chr, stdcode2_chr, hasbarcode_int from t_aid_lis_sampletype order by sample_type_id_chr";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsSampleType_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsSampleType_VO();
                        p_objResultArr[i1].m_strSample_Type_ID = dtbResult.Rows[i1]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSample_Type_Desc = dtbResult.Rows[i1]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPyCode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strWbCode = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strStdCode1 = dtbResult.Rows[i1]["STDCODE1_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strStdCode2 = dtbResult.Rows[i1]["STDCODE2_CHR"].ToString().Trim();
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


        #region 根据标本ID查询标本和仪器标本的关系VO
        [AutoComplete]
        public long m_lngGetDeviceRelationVOArrBySampleID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleID,
            out clsT_LIS_DeviceRelationVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetDeviceRelationVOArrBySampleID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strCondition = "SAMPLE_ID_CHR = '" + p_strSampleID + "' AND STATUS_INT > 0";
            lngRes = m_lngGetDeviceRelationVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据标本ID查询标本信息
        [AutoComplete]
        public long m_lngGetSampleVOArrBySampleID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleID, out clsT_OPR_LIS_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleVOArrBySampleID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strCondition = "SAMPLE_ID_CHR = '" + p_strSampleID + "' AND STATUS_INT > 0";
            lngRes = m_lngGetSampleVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region *PROTECTED* m_lngGetSampleVOArrByCondition 组合查询,得到标本VOArr
        /// <summary>
        /// 组合查询,得到标本VOArr 刘彬 2004.05.27
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetSampleVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_OPR_LIS_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_OPR_LIS_SAMPLE_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select appl_dat, sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
                                   patient_type_chr, diagnose_vchr, sampletype_vchr, samplestate_vchr,
                                   bedno_chr, icd_vchr, patientcardid_chr, barcode_vchr, sample_id_chr,
                                   patientid_chr, sampling_date_dat, operator_id_chr, modify_dat,
                                   appl_empid_chr, appl_deptid_chr, status_int, sample_type_id_chr,
                                   qcsampleid_chr, samplekind_chr, check_date_dat, accept_dat,
                                   acceptor_id_chr, application_id_chr, patient_inhospitalno_chr,
                                   confirm_dat, confirmer_id_chr, collector_id_chr, checker_id_chr
                              from t_opr_lis_sample ";

            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }


            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_OPR_LIS_SAMPLE_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_OPR_LIS_SAMPLE_VO();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["APPL_DAT"]))
                        {
                            p_objResultArr[i1].m_strAPPL_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["APPL_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strSEX_CHR = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENT_NAME_VCHR = dtbResult.Rows[i1]["PATIENT_NAME_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENT_SUBNO_CHR = dtbResult.Rows[i1]["PATIENT_SUBNO_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAGE_CHR = dtbResult.Rows[i1]["AGE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENT_TYPE_CHR = dtbResult.Rows[i1]["PATIENT_TYPE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strDIAGNOSE_VCHR = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLETYPE_VCHR = dtbResult.Rows[i1]["SAMPLETYPE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLESTATE_VCHR = dtbResult.Rows[i1]["SAMPLESTATE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBEDNO_CHR = dtbResult.Rows[i1]["BEDNO_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strICD_VCHR = dtbResult.Rows[i1]["ICD_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENTCARDID_CHR = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strBARCODE_VCHR = dtbResult.Rows[i1]["BARCODE_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENTID_CHR = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["SAMPLING_DATE_DAT"]))
                        {
                            p_objResultArr[i1].m_strSAMPLING_DATE_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["SAMPLING_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strOPERATOR_ID_CHR = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["MODIFY_DAT"]))
                        {
                            p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strAPPL_EMPID_CHR = dtbResult.Rows[i1]["APPL_EMPID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAPPL_DEPTID_CHR = dtbResult.Rows[i1]["APPL_DEPTID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strSAMPLE_TYPE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strQCSAMPLEID_CHR = dtbResult.Rows[i1]["QCSAMPLEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLEKIND_CHR = dtbResult.Rows[i1]["SAMPLEKIND_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["CHECK_DATE_DAT"]))
                        {
                            p_objResultArr[i1].m_strCHECK_DATE_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CHECK_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["ACCEPT_DAT"]))
                        {
                            p_objResultArr[i1].m_strACCEPT_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["ACCEPT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strACCEPTOR_ID_CHR = dtbResult.Rows[i1]["ACCEPTOR_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAPPLICATION_ID_CHR = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPATIENT_INHOSPITALNO_CHR = dtbResult.Rows[i1]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["CONFIRM_DAT"]))
                        {
                            p_objResultArr[i1].m_strCONFIRM_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strCONFIRMER_ID_CHR = dtbResult.Rows[i1]["CONFIRMER_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strCOLLECTOR_ID_CHR = dtbResult.Rows[i1]["COLLECTOR_ID_CHR"].ToString().Trim();
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

        #region *PROTECTED* m_lngGetDeviceRelationVOArrByCondition 组合查询,得到标本VOArr
        /// <summary>
        /// 组合查询,得到核收VOArr 刘彬 2004.05.27
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetDeviceRelationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_LIS_DeviceRelationVO[] p_objResultArr)
        {
            p_objResultArr = new clsT_LIS_DeviceRelationVO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetDeviceRelationVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT * FROM T_OPR_LIS_DEVICE_RELATION ";

            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }


            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_LIS_DeviceRelationVO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_LIS_DeviceRelationVO();
                        p_objResultArr[i1].m_strDEVICEID_CHR = dtbResult.Rows[i1]["DEVICEID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSEQ_ID_CHR = dtbResult.Rows[i1]["SEQ_ID_CHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["IMPORT_REQ_INT"].ToString().Trim() != "")
                        {
                            p_objResultArr[i1].m_intIMPORT_REQ_INT = int.Parse(dtbResult.Rows[i1]["IMPORT_REQ_INT"].ToString().Trim());
                        }
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["RECEPTION_DAT"]))
                        {
                            p_objResultArr[i1].m_strRECEPTION_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["RECEPTION_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        else
                        {
                            p_objResultArr[i1].m_strRECEPTION_DAT = null;
                        }
                        p_objResultArr[i1].m_strDEVICE_SAMPLEID_CHR = dtbResult.Rows[i1]["DEVICE_SAMPLEID_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["CHECK_DAT"]))
                        {
                            p_objResultArr[i1].m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        else
                        {
                            p_objResultArr[i1].m_strCHECK_DAT = null;
                        }
                        p_objResultArr[i1].m_strSAMPLE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strPOSITIONID_CHR = dtbResult.Rows[i1]["POSITIONID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strSEQ_ID_DEVICE_CHR = dtbResult.Rows[i1]["SEQ_ID_DEVICE_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intBIND_METHOD_INT = Convert.ToInt32(dtbResult.Rows[i1]["BIND_METHOD_INT"].ToString().Trim());
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

        #region 根据BarCode 得到样本VO
        [AutoComplete]
        public long m_lngGetSampleVOByBarcode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBarCode, out clsT_OPR_LIS_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetSampleVOByBarcode");
            if (lngRes < 0)
            {
                return -1;
            }
            string strCondition = "BARCODE_VCHR = '" + p_strBarCode + "' AND STATUS_INT >= 0";
            lngRes = 0;
            lngRes = m_lngGetSampleVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 获得全部的样品种类的列表
        /// <summary>
        /// 获得全部的样品种类的列表 
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbSampleType">
        /// SAMPLE_TYPE_ID_CHR, 
        /// SAMPLE_TYPE_DESC_VCHR, 
        /// PYCODE_CHR, 
        /// WBCODE_CHR, 
        /// STDCODE1_CHR, 
        /// STDCODE2_CHR, 
        /// </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleTypeList(System.Security.Principal.IPrincipal p_objPrincipal, out System.Data.DataTable p_dtbSampleType)
        {
            p_dtbSampleType = null;
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetSampleTypeList");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select sample_type_id_chr, sample_type_desc_vchr, pycode_chr, wbcode_chr,
       stdcode1_chr, stdcode2_chr from t_aid_lis_sampletype order by sample_type_id_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSampleType);
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

        #region 获取所有的检验类别
        /// <summary>
        /// 获取所有的检验类别
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbCheckCategory"></param>
        /// <returns></returns>
        public long m_lngGetCheckCategoryList(System.Security.Principal.IPrincipal p_objPrincipal, out System.Data.DataTable p_dtbCheckCategory)
        {
            p_dtbCheckCategory = null;
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetCheckCategoryList");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select trim(a.user_group_id_chr),a.user_group_name_vchr
                                from t_aid_lis_appuser_group a
                               where not exists (select child_user_group_id_chr
                                                   from t_aid_lis_appuser_group_relate b
                                                  where a.user_group_id_chr = b.child_user_group_id_chr)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckCategory);
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

        #region 得到所有的样本状态信息列表

        /// <summary>
        /// 得到所有的样本状态信息列表
        ///  
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbSampleState">
        /// table:t_aid_lis_sample_character
        /// column:
        /// character_desc_vchr
        /// pycode_chr
        /// wbcode_chr
        /// sample_type_id_chr
        /// </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleState(System.Security.Principal.IPrincipal p_objPrincipal, out System.Data.DataTable p_dtbSampleState)
        {

            p_dtbSampleState = null;
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetSampleState");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "SELECT character_desc_vchr, pycode_chr, wbcode_chr, sample_type_id_chr FROM t_aid_lis_sample_character";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSampleState);
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

        #region 根据样品类别ID查询样本状态信息

        /// <summary>
        /// 根据样品类别ID查询样本状态信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSampleTypeID"></param>
        /// <param name="p_dtbSampleState">
        /// character_desc_vchr
        /// </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleState(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleTypeID, out System.Data.DataTable p_dtbSampleState)
        {

            p_dtbSampleState = null;
            long lngRes = 0;
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetSampleState");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "SELECT character_desc_vchr FROM t_aid_lis_sample_character WHERE sample_type_id_chr = '" + p_strSampleTypeID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSampleState);
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

        #region 根据BarCode判断该标本是否已经核收
        [AutoComplete]
        public long m_lngGetReceptedSampleInfoByBarCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBarCode,
            out clsT_OPR_LIS_SAMPLE_VO p_objRecord)
        {
            long lngRes = 0;
            p_objRecord = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsSampleSvc", "m_lngGetReceptedSampleInfoByBarCode");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT *
								FROM t_opr_lis_sample a
							   WHERE a.status_int > 3
								 AND a.status_int < 6
								 AND a.samplekind_chr < 3
								 AND a.barcode_vchr = '" + p_strBarCode + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objRecord = new clsT_OPR_LIS_SAMPLE_VO();
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["APPL_DAT"]))
                    {
                        p_objRecord.m_strAPPL_DAT = Convert.ToDateTime(dtbResult.Rows[0]["APPL_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objRecord.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    p_objRecord.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
                    p_objRecord.m_strPATIENT_SUBNO_CHR = dtbResult.Rows[0]["PATIENT_SUBNO_CHR"].ToString().Trim();
                    p_objRecord.m_strAGE_CHR = dtbResult.Rows[0]["AGE_CHR"].ToString().Trim();
                    p_objRecord.m_strPATIENT_TYPE_CHR = dtbResult.Rows[0]["PATIENT_TYPE_CHR"].ToString().Trim();
                    p_objRecord.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString().Trim();
                    p_objRecord.m_strSAMPLETYPE_VCHR = dtbResult.Rows[0]["SAMPLETYPE_VCHR"].ToString().Trim();
                    p_objRecord.m_strSAMPLESTATE_VCHR = dtbResult.Rows[0]["SAMPLESTATE_VCHR"].ToString().Trim();
                    p_objRecord.m_strBEDNO_CHR = dtbResult.Rows[0]["BEDNO_CHR"].ToString().Trim();
                    p_objRecord.m_strICD_VCHR = dtbResult.Rows[0]["ICD_VCHR"].ToString().Trim();
                    p_objRecord.m_strPATIENTCARDID_CHR = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    p_objRecord.m_strBARCODE_VCHR = dtbResult.Rows[0]["BARCODE_VCHR"].ToString().Trim();
                    p_objRecord.m_strSAMPLE_ID_CHR = dtbResult.Rows[0]["SAMPLE_ID_CHR"].ToString().Trim();
                    p_objRecord.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["SAMPLING_DATE_DAT"]))
                    {
                        p_objRecord.m_strSAMPLING_DATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["SAMPLING_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objRecord.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["MODIFY_DAT"]))
                    {
                        p_objRecord.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objRecord.m_strAPPL_EMPID_CHR = dtbResult.Rows[0]["APPL_EMPID_CHR"].ToString().Trim();
                    p_objRecord.m_strAPPL_DEPTID_CHR = dtbResult.Rows[0]["APPL_DEPTID_CHR"].ToString().Trim();
                    p_objRecord.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
                    p_objRecord.m_strSAMPLE_TYPE_ID_CHR = dtbResult.Rows[0]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                    p_objRecord.m_strQCSAMPLEID_CHR = dtbResult.Rows[0]["QCSAMPLEID_CHR"].ToString().Trim();
                    p_objRecord.m_strSAMPLEKIND_CHR = dtbResult.Rows[0]["SAMPLEKIND_CHR"].ToString().Trim();
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["CHECK_DATE_DAT"]))
                    {
                        p_objRecord.m_strCHECK_DATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECK_DATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["ACCEPT_DAT"]))
                    {
                        p_objRecord.m_strACCEPT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["ACCEPT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objRecord.m_strACCEPTOR_ID_CHR = dtbResult.Rows[0]["ACCEPTOR_ID_CHR"].ToString().Trim();
                    p_objRecord.m_strAPPLICATION_ID_CHR = dtbResult.Rows[0]["APPLICATION_ID_CHR"].ToString().Trim();
                    p_objRecord.m_strPATIENT_INHOSPITALNO_CHR = dtbResult.Rows[0]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
                    if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[0]["CONFIRM_DAT"]))
                    {
                        p_objRecord.m_strCONFIRM_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    }
                    p_objRecord.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
                    p_objRecord.m_strCOLLECTOR_ID_CHR = dtbResult.Rows[0]["COLLECTOR_ID_CHR"].ToString().Trim();
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

        #region 查询在某段时间内采集且已申请但未核收的标本 童华
        [AutoComplete]
        public long m_lngGetAllNotReceptSample(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFromDat, string p_strToDat, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.*,
									 t2.emergency_int,t2.special_int,t2.application_form_no_chr
								FROM t_opr_lis_sample t1, t_opr_lis_application t2
							   WHERE t1.APPLICATION_ID_CHR = t2.APPLICATION_ID_CHR
								 AND t1.status_int = 2
								 AND t2.pstatus_int > 0
								 AND t1.sampling_date_dat BETWEEN TO_DATE ('" + p_strFromDat + @"',
																		   'yyyy-mm-dd hh24:mi:ss'
																		   )
															   AND TO_DATE ('" + p_strToDat + @"',
																			'yyyy-mm-dd hh24:mi:ss'
																		   )";
            p_dtbResult = null;
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

        #region 根据日期范围查询已核收的标本
        [AutoComplete]
        public long m_lngGetReceptedSampleByDateRange(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceID, string p_strFromDat,
            string p_strToDat, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"SELECT   t2.devicename_vchr, t3.barcode_vchr, t1.check_dat, t1.positionid_chr,
								       t3.samplekind_chr, t3.ACCEPT_DAT,t1.seq_id_chr
								 FROM t_opr_lis_device_relation t1,
									  t_bse_lis_device t2,
									  t_opr_lis_sample t3
								 WHERE t1.deviceid_chr = '" + p_strDeviceID + @"'
								 AND t1.status_int > 0
								 AND t1.deviceid_chr = t2.deviceid_chr
								 AND t1.sample_id_chr = t3.sample_id_chr
								 AND t3.status_int > 0
								 AND t3.SAMPLEKIND_CHR = 1
								 AND t1.reception_dat BETWEEN TO_DATE ('" + p_strFromDat + @"',
                                        'YYYY-MM-DD hh24:mi:ss'
                                       )
								 AND TO_DATE ('" + p_strToDat + @"',
                                        'YYYY-MM-DD hh24:mi:ss'
                                       )
							ORDER BY t3.ACCEPT_DAT";
            p_dtbResult = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
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

        #region 查询所有未核收的标本（含未审请的）
        /// <summary>
        /// 查询所有未核收的标本（含未审请的） 刘彬 2004.05.06
        /// </summary>
        /// <param name="p_objPrincipal"></param>		
        /// <param name="dtbAllNotReceptSample"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllNotReceptSample(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbAllNotReceptSample)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.*
								FROM t_opr_lis_sample t1
							   WHERE t1.status_int = '2'
								";
            dtbAllNotReceptSample = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAllNotReceptSample);
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


        #region 根据检验申请表号和检验组（第一层）查询已经采集的各标本数量
        [AutoComplete]
        public long m_lngGetAllSampleCountByApplFormNoAndGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strApplFormNo, string strGroupID, out DataTable dtbGroupSampleCount)
        {
            long lngRes = 0;
            string strSQL = @"SELECT   COUNT (t1.sample_id_chr) as count, t2.sample_type_id_chr
								FROM t_opr_lis_applgrpsmp t1,
									 t_opr_lis_sample t2
							   WHERE t1.sample_id_chr = t2.sample_id_chr
								 AND t2.application_form_no_chr = '" + strApplFormNo + @"'
								 AND t1.groupid_chr = '" + strGroupID + @"'
							GROUP BY t2.sample_type_id_chr";
            dtbGroupSampleCount = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbGroupSampleCount);
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

        #region 查询t_opr_lis_application_detail下的Group的标本状态
        [AutoComplete]
        public long m_lngGetSampleStatusByGroup(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleID, string strApplFormNo, out DataTable dtbGroupSample)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.sample_id_chr,t2.status_int,t1.groupid_chr
								FROM t_opr_lis_applgrpsmp t1,
									 t_opr_lis_sample t2
							   WHERE t1.groupid_chr = (SELECT groupid_chr
														 FROM t_opr_lis_applgrpsmp
													    WHERE sample_id_chr = '" + strSampleID + @"')
														  AND t1.application_form_no_chr = '" + strApplFormNo + @"'
														  AND t1.sample_id_chr = t2.sample_id_chr";
            dtbGroupSample = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbGroupSample);
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

		#region 根据检验申请表号查询已经采集的各标本数量 
		[AutoComplete]
		public long m_lngGetAllSampleCountByApplFormNo(System.Security.Principal.IPrincipal p_objPrincipal,string strApplFormNo,out DataTable dtbAllSampleCount)
		{
			long lngRes = 0;
			string strSQL = @"SELECT   COUNT (sample_type_id_chr) as count, sample_type_id_chr
								FROM t_opr_lis_sample
							  WHERE application_form_no_chr = '"+strApplFormNo
								+"' GROUP BY sample_type_id_chr";
			dtbAllSampleCount = null;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbAllSampleCount);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
			}
			return lngRes;
		}
		#endregion

        #region 根据检验申请表上的号查出本申请已经有的样品。
        [AutoComplete]
        public long m_lngGetSampleInfoByFormId(System.Security.Principal.IPrincipal p_objPrincipal,
            string strFormNo, out System.Data.DataTable dtbSampleInfo)
        {
            string strSQL = @"select SAMPLE_ID_CHR,MODIFY_DAT,sample_type_id_chr,sampletype_vchr,samplestate_vchr,barcode_vchr,sampling_date_dat,operator_id_chr from t_opr_lis_sample where application_form_no_chr='" + strFormNo + "'";

            long lngRes = 0;//为0表示没有成功。大于0为成功。
            dtbSampleInfo = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbSampleInfo);
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

        #region 查询报告单上的样本信息和一些申请单信息(有些字段是ID的要查询相关表，查出ID对应的说明)
        [AutoComplete]
        public long m_lngGetApplSampleInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleID, out System.Data.DataTable p_dtbSample)
        {
            long lngRes = 0;
            p_dtbSample = null;
            string strSQL = @"SELECT t1.sample_id_chr,t1.sampletype_vchr, t1.samplestate_vchr,t2.patient_name_vchr,t3.deptname_vchr,t2.sex_chr,
							t2.patient_subno_chr,t4.lastname_vchr,t2.age_chr,t2.bedno_chr,t2.diagnose_vchr,t5.summary_vchr
							FROM t_opr_lis_sample t1,
								t_opr_lis_application t2,
								t_bse_deptdesc t3,
								t_bse_employee t4,
								t_opr_lis_application_detail t5,
								t_opr_lis_applgrpsmp t6      
							WHERE t1.sample_id_chr = '" + p_strSampleID + @"' and (t2.appl_deptid_chr=t3.deptid_chr(+))
							and (t2.appl_empid_chr=t4.empid_chr(+))
							AND t6.groupid_chr = t5.groupid_chr
							AND t6.sample_id_chr = t1.sample_id_chr
							AND t5.application_id_chr = t2.application_id_chr
							AND t2.modify_dat = t5.modify_dat
							AND t2.pstatus_int > 0
							and t1.application_form_no_chr=t2.application_form_no_chr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSample);
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

        #region 根据Application_ID查找该申请单中各种检查所需的各类样品的数量
        [AutoComplete]
        public long m_lngGetSampleTotalQtyByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplication_ID, out System.Data.DataTable p_dtbSampleQty)
        {
            long lngRes = 0;
            p_dtbSampleQty = null;

            try
            {
                //				System.Data.IDataParameter[] objDPArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //				objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                //				objDPArr[0].Value = p_strApplication_ID;
                //				lngRes = objHRPSvc.lngGetDataTableWithParameters(c_strGetSampleTotalQtyByApplicationID, ref p_dtbSampleQty, objDPArr);


                string strSQL = @"SELECT c.sample_type_id_chr, c.total, 
				d.SAMPLE_TYPE_DESC_VCHR FROM 
				(SELECT b.sample_type_id_chr, SUM(b.sample_qty_chr) AS total 
				FROM t_opr_lis_application_detail a, t_aid_lis_group_sample b
				WHERE a.STATUS_INT > 0 AND a.application_id_chr = '" + p_strApplication_ID + "' " +
                @"AND a.groupid_chr = b.groupid_chr
				GROUP BY b.sample_type_id_chr) c, t_aid_lis_sampletype d
				WHERE c.sample_type_id_chr = d.sample_type_id_chr";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbSampleQty);
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

        #region 根据DevID查询表t_opr_lis_device_relation（查询已核收的,STATUS_INT=1）
        [AutoComplete]
        public long m_lngGetDevRelationInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDevID, out System.Data.DataTable p_dtbDevRelation)
        {
            long lngRes = 0;
            p_dtbDevRelation = null;
            string strFromNow = System.DateTime.Now.ToShortDateString() + " 00:00:00";
            string strToNow = System.DateTime.Now.ToShortDateString() + " 23:59:59";
            string strSQL = @"SELECT t2.devicename_vchr, t3.barcode_vchr, t1.check_dat, t1.positionid_chr,t3.samplekind_chr
							FROM t_opr_lis_device_relation t1, t_bse_lis_device t2, t_opr_lis_sample t3
							WHERE t1.deviceid_chr = '" + p_strDevID + @"'
							AND t1.status_int = 1
							AND t1.deviceid_chr = t2.deviceid_chr
							AND t1.sample_id_chr = t3.sample_id_chr
							AND t3.modify_dat BETWEEN TO_DATE ('" + strFromNow + @"',
                                        'YYYY-MM-DD hh24:mi:ss'
                                       )
                           AND TO_DATE ('" + strToNow + @"',
                                        'YYYY-MM-DD hh24:mi:ss'
                                       )
							AND t3.status_int > 0 order by t1.SEQ_ID_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDevRelation);
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

        #region 查找某一申请单中使用某一种样品的所有检验组
        [AutoComplete]
        public long m_lngGetCheckGroupListByAppID_SampleType(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplication_ID, string p_strSampleTypeID, out System.Data.DataTable p_dtbCheckGroupList)
        {
            long lngRes = 0;
            p_dtbCheckGroupList = null;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = @"SELECT d.groupname_vchr, c.sample_type_desc_vchr, a.groupid_chr,
				b.sample_qty_chr, b.sample_valid_time ,a.status_int
				FROM t_opr_lis_application_detail a, t_aid_lis_group_sample b, t_aid_lis_sampletype c, 
				t_aid_lis_check_group d
				WHERE a.status_int > 0 AND a.groupid_chr = b.groupid_chr AND b.sample_type_id_chr = c.sample_type_id_chr
				AND a.groupid_chr = d.groupid_chr AND a.application_id_chr = '" + p_strApplication_ID + "' " +
                @"AND b.sample_type_id_chr = '" + p_strSampleTypeID + "'";


                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckGroupList);
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

        #region
        [AutoComplete]
        public long m_lngGetSampleDetailByAppID_SampleType(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strApplication_ID, string p_strSampleTypeID,
            out com.digitalwave.iCare.ValueObject.clsSampleVO[] colSampleList)
        {
            long lngRes = 0;
            colSampleList = null;

            try
            {

                string strSQL = @"SELECT   c.*, g.sample_valid_time, h.sample_type_desc_vchr
				FROM (SELECT b.application_id_chr, a.application_form_no_chr,
				a.barcode_vchr, a.sample_id_chr, a.sampling_date_dat,
				a.operator_id_chr, a.sample_type_id_chr, a.samplestate_vchr
				FROM t_opr_lis_sample a, t_opr_lis_application b
				WHERE b.application_id_chr = '" + p_strApplication_ID + "' " +
                    @"AND a.application_form_no_chr = b.application_form_no_chr
				AND a.status_int > 0 AND b.pstatus_int > 0) c,
				(SELECT e.application_id_chr, f.sample_type_id_chr,
				MIN (f.sample_valid_time) AS sample_valid_time
				FROM t_opr_lis_application_detail e,
				t_aid_lis_group_sample f
				WHERE e.groupid_chr = f.groupid_chr
				AND e.status_int > 0
				AND e.application_id_chr = '" + p_strApplication_ID + "' " +
                    @"GROUP BY e.application_id_chr, f.sample_type_id_chr) g,
				t_aid_lis_sampletype h
				WHERE c.application_id_chr = g.application_id_chr
				AND c.sample_type_id_chr = g.sample_type_id_chr
				AND c.sample_type_id_chr = '" + p_strSampleTypeID + "' " +
                    @"AND c.sample_type_id_chr = h.sample_type_id_chr
				ORDER BY c.sampling_date_dat";

                System.Data.DataTable dtbSampleList = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbSampleList);
                objHRPSvc.Dispose();
                if (lngRes == 1)
                {
                    int intCount = dtbSampleList.Rows.Count;
                    if (intCount > 0)
                    {
                        colSampleList = new com.digitalwave.iCare.ValueObject.clsSampleVO[intCount];
                        for (int i = 0; i < intCount; i++)
                        {
                            System.Data.DataRow objRow = dtbSampleList.Rows[i];
                            colSampleList[i] = new com.digitalwave.iCare.ValueObject.clsSampleVO();
                            ConstructSimpleSampleVO(objRow, ref colSampleList[i]);
                        }
                    }
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

        #region 构造 SampleVO
        [AutoComplete]
        private void ConstructSimpleSampleVO(System.Data.DataRow objRow, ref com.digitalwave.iCare.ValueObject.clsSampleVO objSampleVO)
        {
            if (objRow["application_id_chr"] != System.DBNull.Value)
            { objSampleVO.m_strApplication_ID = objRow["application_id_chr"].ToString().Trim(); }

            if (objRow["application_form_no_chr"] != System.DBNull.Value)
            { objSampleVO.m_strApplication_Form_No = objRow["application_form_no_chr"].ToString().Trim(); }

            if (objRow["barcode_vchr"] != System.DBNull.Value)
            { objSampleVO.m_strBarCode = objRow["barcode_vchr"].ToString().Trim(); }

            if (objRow["sample_id_chr"] != System.DBNull.Value)
            { objSampleVO.m_strSAMPLE_ID = objRow["sample_id_chr"].ToString().Trim(); }

            if (objRow["sampling_date_dat"] != System.DBNull.Value)
            { objSampleVO.m_strSampling_Dat = objRow["sampling_date_dat"].ToString().Trim(); }

            if (objRow["operator_id_chr"] != System.DBNull.Value)
            { objSampleVO.m_strOperator_ID = objRow["operator_id_chr"].ToString().Trim(); }

            if (objRow["sample_type_id_chr"] != System.DBNull.Value)
            { objSampleVO.m_strSample_Type_Id = objRow["sample_type_id_chr"].ToString().Trim(); }

            if (objRow["sample_valid_time"] != System.DBNull.Value)
            { objSampleVO.m_strSample_Valid_Time = objRow["sample_valid_time"].ToString().Trim(); }

            if (objRow["sample_type_desc_vchr"] != System.DBNull.Value)
            { objSampleVO.m_strSampleType = objRow["sample_type_desc_vchr"].ToString().Trim(); }

            if (objRow["samplestate_vchr"] != System.DBNull.Value)
            {
                objSampleVO.m_strSampleState = objRow["samplestate_vchr"].ToString().Trim();
            }


        }
        #endregion
        [AutoComplete]
        public long m_lngGetSampleInfoByBarCode(System.Security.Principal.IPrincipal df, string strBarCode, out com.digitalwave.iCare.ValueObject.clsSampleVO objSampleVO)
        {
            objSampleVO = null;
            return 0;
        }

        #region 获取样本状态
        /// <summary>
        /// 获取样本状态
        /// </summary>
        /// <param name="p_strSampleID"></param>
        /// <param name="p_intStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQuerySampleStatus(string p_strSampleID, out int p_intStatus,out string p_strIsSampleBack)
        {
            p_strIsSampleBack = null;
            long lngRes = 0;
            p_intStatus = 0;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.status_int,t.issampleback
                              from t_opr_lis_sample t
                             where t.sample_id_chr = ?
                               and t.status_int > 0
                            ";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strSampleID;
                DataTable dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_intStatus = dtResult.Rows[0]["status_int"] != DBNull.Value ? Convert.ToInt32(dtResult.Rows[0]["status_int"].ToString()) : 0;
                    p_strIsSampleBack = dtResult.Rows[0]["issampleback"].ToString().Trim();
                }
                dtResult.Dispose();
                dtResult = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                strSQL = null;
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }

}
