using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.Utility;
using Oracle.DataAccess.Client;
using System.Collections;//Utility.dll

namespace com.digitalwave.iCare.middletier.HIS.Report
{
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsHISReportZy_Supported_Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 病人（来源）住院查询
        /// <summary>
        /// 病人（来源）住院查询
        /// </summary>
        /// <param name="p_dtmStart"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="p_dtmOutStart"></param>
        /// <param name="p_dtmOutEnd"></param>
        /// <param name="p_dtbReulst"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCollectorReport_PatientSource(string p_dtmStart, string p_dtmEnd, string p_dtmOutStart, string p_dtmOutEnd, out DataTable p_dtbReulst)
        {
            long lngRes = 0;
            p_dtbReulst = new DataTable();
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] Paramer = null;
            try
            {
                if (!string.IsNullOrEmpty(p_dtmStart))
                {
                    string strSQL = @" select d.deptname_vchr,
           c.patientsources_vchr,
           count(d.deptname_vchr) as a1,
           round(count(d.deptname_vchr) / a2, 3) a3
      from t_opr_bih_register a,
           t_opr_bih_leave b,
           t_bse_patient c,
           t_bse_deptdesc d,
           (select d.deptid_chr, count(d.deptid_chr) a2
              from t_opr_bih_register a,
                   t_opr_bih_leave    b,
                   t_bse_patient      c,
                   t_bse_deptdesc     d
             where a.status_int = 1 
               and a.patientid_chr = c.patientid_chr
               and a.deptid_chr = d.deptid_chr
               and a.registerid_chr = b.registerid_chr(+)
               and a.inpatient_dat between
                   to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
             group by d.deptid_chr) e
     where a.status_int = 1 
       and a.patientid_chr = c.patientid_chr
       and a.deptid_chr = d.deptid_chr
       and a.registerid_chr = b.registerid_chr(+)
       and d.deptid_chr = e.deptid_chr
       and a.inpatient_dat between
           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
     group by d.deptname_vchr, c.patientsources_vchr, e.a2
     order by d.deptname_vchr";
                    objHRPSvc.CreateDatabaseParameter(4, out Paramer);
                    Paramer[0].Value = p_dtmStart;
                    Paramer[1].Value = p_dtmEnd;
                    Paramer[2].Value = p_dtmStart;
                    Paramer[3].Value = p_dtmEnd;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbReulst, Paramer);
                    objHRPSvc.Dispose();
                }
                else if (!string.IsNullOrEmpty(p_dtmOutStart))
                {
                    string strSQL = @"select d.deptname_vchr,
           c.patientsources_vchr,
           count(d.deptname_vchr) as a1,
           round(count(d.deptname_vchr) / a2, 3) a3
      from t_opr_bih_register a,
           t_opr_bih_leave b,
           t_bse_patient c,
           t_bse_deptdesc d,
           (select d.deptid_chr, count(d.deptid_chr) a2
              from t_opr_bih_register a,
                   t_opr_bih_leave    b,
                   t_bse_patient      c,
                   t_bse_deptdesc     d
             where a.status_int = 1 
               and a.patientid_chr = c.patientid_chr
               and b.outdeptid_chr = d.deptid_chr
               and a.registerid_chr = b.registerid_chr(+)
               and b.status_int = 1
               and b.outhospital_dat between
                   to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
             group by d.deptid_chr) e
     where a.status_int = 1 
       and a.patientid_chr = c.patientid_chr
       and b.outdeptid_chr = d.deptid_chr
       and a.registerid_chr = b.registerid_chr(+)
       and d.deptid_chr = e.deptid_chr
       and b.status_int = 1
       and b.outhospital_dat between
           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
     group by d.deptname_vchr, c.patientsources_vchr, e.a2
     order by d.deptname_vchr";
                    objHRPSvc.CreateDatabaseParameter(4, out Paramer);
                    Paramer[0].Value = p_dtmOutStart;
                    Paramer[1].Value = p_dtmOutEnd;
                    Paramer[2].Value = p_dtmOutStart;
                    Paramer[3].Value = p_dtmOutEnd;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbReulst, Paramer);
                    objHRPSvc.Dispose();
                }
                else
                {
                    return lngRes;
                }
                //try
                //{
                if (p_dtbReulst != null && p_dtbReulst.Rows.Count > 0)
                {
                    DataView objDv = new DataView(p_dtbReulst);
                    objDv.Sort = "deptname_vchr asc";
                    p_dtbReulst = objDv.ToTable();
                }
                objHRPSvc = null;
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

        #region GetYGItem
        /// <summary>
        /// GetYGItem
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetYGItem(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select e.deptname_vchr   as areaName,
                               f.bed_no          as bedNo,
                               c.inpatientid_chr as ipNo,
                               d.lastname_vchr   as patName,
                               d.sex_chr         as patSex,
                               d.birth_dat       as birthday,
                               b.usercode_chr    as itemCode,
                               a.name_vchr       as itemName,
                               a.startdate_dat   as startDate,
                               a.finishdate_dat  as stopDate
                          from t_opr_bih_order a
                         inner join t_bse_bih_orderdic b
                            on a.orderdicid_chr = b.orderdicid_chr
                         inner join t_opr_bih_register c
                            on a.registerid_chr = c.registerid_chr
                         inner join t_bse_patient d
                            on a.patientid_chr = d.patientid_chr
                          left join t_bse_deptdesc e
                            on a.curareaid_chr = e.deptid_chr
                          left join t_bse_bed f
                            on a.curbedid_chr = f.bedid_chr
                         where a.status_int > 0
                           and b.usercode_chr in ('812168', '812241', '831107')
                           and (c.pstatus_int = 1 or c.pstatus_int = 4)
                           and (c.inareadate_dat between ? and ?)";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "YG";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetCriticalDeal 危急值处理情况登记表
        /// <summary>
        /// GetCriticalDeal
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalDeal(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select a.cvmid,
                               --a.recorddate,
                               d.confirm_dat as recorddate,
                               b.deptname_vchr   as appdeptname,
                               a.responsedate,
                               a.doctadvicemsg,
                               a.doctadvicedate,
                               lis.resultval,
                               a.status
                          from icare.t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                          left join icare.t_criticalvalue_lis lis
                            on a.cvmid = lis.cvmid
                         left join t_opr_lis_sample d 
                          on a.applyid = d.application_id_chr
                         where (d.confirm_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                           and lis.resultval not in (select refdesc from icare.t_criticalvalue_ref_yg )
                           and (a.status = 0 or a.status = 1)
                           and (d.status_int >= 6)
                           and a.applytypeid = 1 
                        union all
                        select a.cvmid,
                               a.recorddate,
                               b.deptname_vchr as appdeptname,
                               a.responsedate,
                               a.doctadvicemsg,
                               a.doctadvicedate,
                               pacs.cridesc as resultval,
                               a.status
                          from icare.t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                          left join icare.t_criticalvalue_pacs pacs
                            on a.cvmid = pacs.cvmid
                         where (a.recorddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') )
                           and (a.status = 0 or a.status = 1)
                           and a.applytypeid = 2  ";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalDeal";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetCriticalExecute 危急值报告执行情况统计表
        /// <summary>
        /// GetCriticalExecute
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalExecute(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from (select a.cvmid,
                        lis.checkitemname,
                        a.recorddeptid,
                        b.deptname_vchr   as appdeptname,
                        b.deptid_chr      as appdeptid,
                        a.doctadvicemsg,
                        lis.checkitemid,
                        lis.resultval,
                        a.status
                        from icare.t_criticalvalue_main a
                        left join t_bse_deptdesc b
                        on a.applydeptid = b.deptid_chr
                        left join icare.t_criticalvalue_lis lis
                        on a.cvmid = lis.cvmid
                        left join t_opr_lis_sample d 
                          on a.applyid = d.application_id_chr
                        where (d.confirm_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        and lis.resultval not in (select refdesc from icare.t_criticalvalue_ref_yg ) 
                        and a.applytypeid = 1 
                        and (d.status_int >= 6)
                        union all
                 select a.cvmid,
                        pacs.examitem as checkitemname,
                        a.recorddeptid,
                        b.deptname_vchr as appdeptname,
                        b.deptid_chr    as appdeptid,
                        a.doctadvicemsg,
                        pacs.examid as checkitemid,
                        pacs.cridesc as resultval,
                        a.status
                        from icare.t_criticalvalue_main a
                        left join t_bse_deptdesc b
                        on a.applydeptid = b.deptid_chr
                        left join icare.t_criticalvalue_pacs pacs
                        on a.cvmid = pacs.cvmid
                        where (a.recorddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        and a.applytypeid = 2) order by checkitemname";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalExecute";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetCriticalClinicaldept 科室临床“危急值”报告登记表（临床科室用表）
        /// <summary>
        /// CriticalClinicaldept
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalClinicaldept(string beginDate, string endDate, string deptStr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from (select a.cvmid,
                              --a.responsedate,
                              t1.confirm_dat as responsedate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              lis.checkitemname,
                              lis.resultval,
                              a.recorddeptid,
                              c.lastname_vchr   as recorder,
                              b.deptname_vchr   as appdeptname,
                              d.lastname_vchr   as responseopername,
                              e.lastname_vchr    as doctname,
                              a.doctadvicedate,
                              ''    as dealif,
                              a.doctadvicemsg,
                              --a.recorddate,
                              t1.confirm_dat as recorddate,
                              a.pattypeid,
                              a.cardno,
                              a.lisverifydate as jykrectime,
                              a.lisverifymsg,
                              responsemsg,
                              lis.checkitemid,
                              lis.unit,
                              a.applytypeid 
                              from icare.t_criticalvalue_main a
                              left join icare.t_opr_lis_sample t1
                              on a.applyid = t1.application_id_chr
                              left join t_bse_deptdesc b
                              on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join t_bse_employee e
                              on a.doctid = e.empid_chr
                              left join icare.t_criticalvalue_lis lis
                              on a.cvmid = lis.cvmid
                              where (t1.confirm_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                              and (a.status = 0 or a.status = 1)   
                              and lis.resultval not in (select refdesc from icare.t_criticalvalue_ref_yg ) 
                              {0}
                              and a.applytypeid = 1 
                              and t1.status_int > 5
                       union all
                       select a.cvmid,
                              a.responsedate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              pacs.examitem as checkitemname,
                              pacs.cridesc as resultval,
                              a.recorddeptid,
                              c.lastname_vchr as recorder,
                              b.deptname_vchr as appdeptname,
                              d.lastname_vchr as responseopername,
                              e.lastname_vchr    as doctname,
                              a.doctadvicedate,
                            ''    as dealif,
                            a.doctadvicemsg,
                            a.recorddate,
                            a.pattypeid,
                            a.cardno,
                            a.lisverifydate as jykrectime,
                            a.lisverifymsg,
                            a.responsemsg,
                            pacs.examid as checkitemid,
                            '' as unit,
                            a.applytypeid 
                            from icare.t_criticalvalue_main a
                            left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                            left join t_bse_employee c
                            on a.recorderid = c.empid_chr
                            left join t_bse_employee d
                            on a.responseempid = d.empid_chr
                            left join t_bse_employee e
                            on a.doctid = e.empid_chr
                            left join icare.t_criticalvalue_pacs pacs
                            on a.cvmid = pacs.cvmid
                            where (a.recorddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') )
                            and (a.status = 0 or a.status = 1)
                            {1}
                            and a.applytypeid = 2 ) order by responsedate";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and b.code_vchr in " + deptStr;

                Sql = string.Format(Sql, deptStr, deptStr);

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalMedicaldept";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetCriticalMedicaldept 科室临床“危急值”报告登记表（医技科室用表）
        /// <summary>
        /// CriticalMedicaldept
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalMedicaldept(string beginDate, string endDate, string deptStr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from (select a.cvmid,
                              --a.recorddate,
                              t1.confirm_dat as recorddate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              lis.checkitemname,
                              lis.resultval,
                              a.recorddeptid,
                              c.lastname_vchr   as recorder,
                              b.deptname_vchr   as appdeptname,
                              d.lastname_vchr   as responseopername,
                              e.lastname_vchr    as doctname,
                              a.responsemsg,
                              a.doctadvicemsg,
                              a.doctadvicedate,
                              a.responsedate,
                              a.pattypeid,
                              a.cardno,
                              lis.checkitemid,
                              lis.unit,
                              a.applytypeid 
                              from icare.t_criticalvalue_main a
                              left join icare.t_opr_lis_sample t1
                              on a.applyid = t1.application_id_chr
                              left join t_bse_deptdesc b
                               on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join t_bse_employee e
                              on a.doctid = e.empid_chr
                              left join icare.t_criticalvalue_lis lis
                              on a.cvmid = lis.cvmid
                              where (t1.confirm_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                              and (a.status = 0 or a.status = 1)
                              and lis.resultval not in (select refdesc from icare.t_criticalvalue_ref_yg )
                              {0}    
                              and a.applytypeid = 1 
                              and t1.status_int > 5
                       union all
                       select a.cvmid,
                              a.recorddate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              pacs.examitem as checkitemname,
                              pacs.cridesc as resultval,
                              a.recorddeptid,
                              c.lastname_vchr as recorder,
                              b.deptname_vchr as appdeptname,
                              d.lastname_vchr as responseopername,
                              e.lastname_vchr    as doctname,
                              a.responsemsg,
                              a.doctadvicemsg,
                              a.doctadvicedate,
                              a.responsedate,
                              a.pattypeid,
                              a.cardno,
                              pacs.examid as checkitemid,
                              '' as unit,
                              a.applytypeid 
                              from icare.t_criticalvalue_main a
                              left join t_bse_deptdesc b
                              on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join t_bse_employee e
                              on a.doctid = e.empid_chr
                              left join icare.t_criticalvalue_pacs pacs
                              on a.cvmid = pacs.cvmid
                              where (a.recorddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') )
                              and (a.status = 0 or a.status = 1)
                              {1}
                              and a.applytypeid = 2 ) order by recorddate";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and b.code_vchr in " + deptStr;

                Sql = string.Format(Sql, deptStr, deptStr);

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalMedicaldept";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetCriticalAreaDpet 科室临床危危值发生数统计表
        /// <summary>
        /// CriticalMedicaldept
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalAreaDpet(string beginDate, string endDate, string deptStr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select a.cvmid,a.applytypeid,
                              --a.recorddate,
                               d.confirm_dat as recorddate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              lis.checkitemid,
                              lis.checkitemname,
                              lis.resultval,
                              a.recorddeptid,
                              c.lastname_vchr   as recorder,
                              b.deptname_vchr   as appdeptname,
                              b.code_vchr,
                              d.lastname_vchr   as responseopername,
                              ''    as doctname,
                              a.responsemsg,
                              a.doctadvicemsg,
                              a.doctadvicedate,
                              a.responsedate,
                              a.pattypeid,
                              a.cardno,
                              lis.unit,
                              a.applytypeid 
                              from icare.t_criticalvalue_main a
                              left join t_bse_deptdesc b
                              on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join t_bse_deptdesc e
                              on a.recorddeptid = e.deptname_vchr
                              left join icare.t_criticalvalue_lis lis
                              on a.cvmid = lis.cvmid
                              where (d.confirm_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') )
                              and (a.status = 0 or a.status = 1) 
                              and b.code_vchr is not null
                              and b.deptname_vchr is not null
                              and lis.resultval not in (select refdesc from icare.t_criticalvalue_ref_yg )
                              {0}
                              and a.applytypeid = 1 
                       union all
                       select a.cvmid,a.applytypeid,
                              a.recorddate,
                              a.patname,
                              a.bedno, 
                              a.ipno,
                              pacs.examid as checkitemid,
                              pacs.examitem as checkitemname,
                              pacs.cridesc as resultval,
                              a.recorddeptid,
                              c.lastname_vchr as recorder,
                              b.deptname_vchr as appdeptname,
                              b.code_vchr,
                              d.lastname_vchr as responseopername,
                              ''    as doctname,
                              a.responsemsg,
                              a.doctadvicemsg,
                              a.doctadvicedate,
                              a.responsedate,
                              a.pattypeid,
                              a.cardno,
                              '' as unit,
                              a.applytypeid 
                              from icare.t_criticalvalue_main a
                              left join t_bse_deptdesc b
                              on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join t_bse_deptdesc e
                              on a.recorddeptid = e.deptname_vchr
                              left join icare.t_criticalvalue_pacs pacs
                              on a.cvmid = pacs.cvmid
                              where (a.recorddate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') )
                              and (a.status = 0 or a.status = 1)
                              and b.deptname_vchr is not null
                              {1}
                              and a.applytypeid = 2 ";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and e.code_vchr in " + deptStr;

                Sql = string.Format(Sql, deptStr, deptStr);

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalAreaDept";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }

        #endregion

        #region GetCriticalUnreport 科室临床“危急值”未报告登记表（医技科室用表）
        /// <summary>
        /// GetCriticalUnreport
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCriticalUnreport(string beginDate, string endDate, string deptStr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select * from (select a.cvmid,
                              a.recorddate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              lis.checkitemid,
                              lis.checkitemname,
                              lis.resultval,
                              a.recorddeptid,
                              c.lastname_vchr   as recorder
                              from icare.t_criticalvalue_main a
                              left join t_bse_deptdesc b
                              on a.recorddeptid = b.deptname_vchr  -- on a.applydeptid = b.deptid_chr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join icare.t_criticalvalue_lis lis
                              on a.cvmid = lis.cvmid
                              where (a.recorddate between ? and ?)
                              and (a.status = '-1')
                              {0} 
                              and a.applytypeid = 1 
                       union all
                       select a.cvmid,
                              a.recorddate,
                              a.patname,
                              a.bedno,
                              a.ipno,
                              pacs.examid   as checkitemid,
                              pacs.examitem as checkitemname,
                              pacs.cridesc as resultval,
                              a.recorddeptid,
                              c.lastname_vchr as recorder
                              from icare.t_criticalvalue_main a
                              left join t_bse_deptdesc b
                              on a.recorddeptid = b.deptname_vchr
                              left join t_bse_employee c
                              on a.recorderid = c.empid_chr
                              left join t_bse_employee d
                              on a.responseempid = d.empid_chr
                              left join icare.t_criticalvalue_pacs pacs
                              on a.cvmid = pacs.cvmid
                              where (a.recorddate between ? and ? )
                              and (a.status = '-1')
                              {1} 
                              and a.applytypeid = 2 ) order by recorddate";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                parm[2].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[3].Value = Convert.ToDateTime(endDate + " 23:59:59");

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and b.code_vchr in " + deptStr;

                Sql = string.Format(Sql, deptStr, deptStr);

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "CriticalUnreport";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetSamplePackStat 检验标本打包、核收及项目统计
        /// <summary>
        /// GetSamplePackStat
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetSamplePackStat(List<string> lstParam, string dteStart, string dteEnd, string sampleType, string patName, string barCode, string peno, string deptStr, int checkState, int timeType)
        {
            string Sql = string.Empty;
            string Sql1 = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select distinct 
                        t.barcode_vchr as barcode,--条码号
                        t.patientcardid_chr as patcardno,--门诊号
                        t.patient_inhospitalno_chr as peno,--住院号/体检号
                        e.dictname_vchr as pattype, --病人类型
                        t.patient_name_vchr as patname, --病人姓名
                        t.sampletype_vchr as sampletype,--标本类型
                        --f.itemname as checkcontent,   --检验内容
                        j.check_content_vchr as checkcontent,
                        c.lastname_vchr as applyername,--申请人
                        d.DEPTNAME_VCHR as deptname,--申请科室
                        a.recorderid,--打包人id
                        a.recorddate , 
                        a.packdate as packtime, --打包时间
                        g.lastname_vchr as packname,--打包人
                        t.accept_dat as checktime,  --核收时间
                        h.lastname_vchr as checkname,--核收人
                        k.feedback_date_date as rechecktime,--拒收时间
                        k.sample_back_reason_vchr as recheckreason,--拒收原因
                        t.appl_dat
                        from   t_opr_lis_sample  t
                        left join t_samplepack a
                        on  t.barcode_vchr = a.barcode 
                        left join t_samplepack_detail f
                        on t.barcode_vchr = f.barcode
                        left join (select d.dictid_chr, d.dictname_vchr
                                  from t_aid_dict d
                                 where trim(d.dictid_chr) <> 0
                                   and dictkind_chr = '61') e
                        on t.patient_type_chr = e.dictid_chr
                        left join t_bse_employee c
                        on t.appl_empid_chr = c.empid_chr
                        left join t_bse_deptdesc d
                        on t.appl_deptid_chr = d.DEPTID_CHR
                        left join t_bse_employee g
                        on a.recorderid = g.empid_chr
                        left join t_bse_employee h
                        on t.acceptor_id_chr =h.empid_chr
                        left join t_opr_lis_application j
                        on t.application_id_chr = j.application_id_chr
                        left join t_opr_lis_sample_feedback k
                        on t.sample_id_chr = k.sample_id_chr
                        where t.appl_deptid_chr is not null 
                        and (t.APPL_DAT between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))  {1} "; //a.appl_deptid_chr is not null 

                Sql1 = @"select distinct 
                        t.barcode_vchr as barcode,--条码号
                        t.patientcardid_chr as patcardno,--门诊号
                        t.patient_inhospitalno_chr as peno,--住院号/体检号
                        e.dictname_vchr as pattype, --病人类型
                        t.patient_name_vchr as patname, --病人姓名
                        t.sampletype_vchr as sampletype,--标本类型
                        --f.itemname as checkcontent,   --检验内容
                        j.check_content_vchr as checkcontent,
                        c.lastname_vchr as applyername,--申请人
                        d.DEPTNAME_VCHR as deptname,--申请科室
                        a.recorderid,--打包人id
                        a.recorddate , 
                        a.packdate as packtime, --打包时间
                        g.lastname_vchr as packname,--打包人
                        t.accept_dat as checktime,  --核收时间
                        h.lastname_vchr as checkname,--核收人
                        k.feedback_date_date as rechecktime,--拒收时间
                        k.sample_back_reason_vchr as recheckreason,--拒收原因
                        t.appl_dat
                        from   t_opr_lis_sample  t
                        left join t_samplepack a
                        on  t.barcode_vchr = a.barcode 
                        left join t_samplepack_detail f
                        on t.barcode_vchr = f.barcode
                        left join (select d.dictid_chr, d.dictname_vchr
                                  from t_aid_dict d
                                 where trim(d.dictid_chr) <> 0
                                   and dictkind_chr = '61') e
                        on t.patient_type_chr = e.dictid_chr
                        left join t_bse_employee c
                        on t.appl_empid_chr = c.empid_chr
                        left join t_bse_deptdesc d
                        on t.appl_deptid_chr = d.DEPTID_CHR
                        left join t_bse_employee g
                        on a.recorderid = g.empid_chr
                        left join t_bse_employee h
                        on t.acceptor_id_chr =h.empid_chr
                        left join t_opr_lis_application j
                        on t.application_id_chr = j.application_id_chr
                        left join t_opr_lis_sample_feedback k
                        on t.sample_id_chr = k.sample_id_chr
                        where t.appl_deptid_chr is not null 
                        and (t.accept_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))  {1} "; //a.appl_deptid_chr is not null 

                if (timeType == 0)
                    Sql = Sql1;

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + ":01";
                parm[1].Value = dteEnd + ":59";

                foreach (string s in lstParam)
                {
                    if (s == "sampleType" && sampleType != "全部")
                        Sql += " and trim(t.sampletype_vchr) = '" + sampleType + "'";

                    if (s == "patName" && patName != string.Empty)
                        Sql += " and trim(t.patient_name_vchr) = '" + patName + "'";

                    if (s == "barCode" && barCode != string.Empty)
                        Sql += " and trim(t.barcode_vchr) = " + barCode;

                    if (s == "peno" && peno != string.Empty)
                        Sql += " and trim(t.patient_inhospitalno_chr) = '" + peno + "'";
                    if (s == "ownerDept" && deptStr != null)
                    {
                        Sql += " and d.DEPTID_CHR in " + deptStr;
                        deptStr = "";
                    }

                    if (s == "deptStr")
                    {
                        if (deptStr == null)
                            deptStr = "";
                        else
                            deptStr = "and d.code_vchr in " + deptStr;
                    }

                    if (s == "check" && checkState > 0)
                    {
                        if (checkState == 1)//已核收
                        {
                            Sql += " and t.status_int > 2 and t.status_int < 7 and k.samplebackid_chr is  null";
                            Sql += " and t.accept_dat is not null and t.acceptor_id_chr is not null ";
                        }
                        else if (checkState == 2)//未核收
                        {
                            Sql += " and t.status_int = 2 and k.samplebackid_chr is null";
                            Sql += " and t.accept_dat is null and t.acceptor_id_chr is  null ";
                        }
                        else if (checkState == 3)  //拒收
                        {
                            Sql += " and k.samplebackid_chr is not null ";
                        }
                    }
                }

                if (checkState == 0)
                {
                    Sql += " and t.status_int >= 2 and t.status_int < 7 ";
                }

                Sql = string.Format(Sql, deptStr, deptStr);

                Sql += " order by t.appl_dat";

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "samplePackStat";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetLisSampletype 临床病原微生物标本送检情况
        /// <summary>
        /// GetLisSampletype
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetLisSampletype(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select d.registerid_chr as id,
                               f.itemid_chr,
                               f.itemcode_vchr,
                               f.itemname_vchr,
                               c.sampletype_vchr,
                               g.code_vchr,
                               g.deptname_vchr,
                               c.modify_dat
                          from t_opr_lis_application a
                          left join t_opr_attachrelation b
                            on a.application_id_chr = b.attachid_vchr
                          left join t_opr_bih_order d
                            on b.sourceitemid_vchr = d.orderid_chr
                          left join t_opr_bih_patientcharge e
                            on d.orderid_chr = e.orderid_chr
                          left join t_bse_chargeitem f
                            on e.chargeitemid_chr = f.itemid_chr
                          left join t_opr_lis_sample c
                            on a.application_id_chr = c.application_id_chr
                          left join t_bse_deptdesc g
                            on a.appl_deptid_chr = g.deptid_chr
                         where e.status_int = 1
                           and e.pstatus_int <> 0
                           and c.status_int >= 5
                           and a.pstatus_int = 2
                           and f.itemcode_vchr in
                               ('861636', '861618', '861621', '861633', '861616', '861619')
                           and c.modify_dat between
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                        union
                        select e.outpatrecipeid_chr as id,
                               f.itemid_chr,
                               f.itemcode_vchr,
                               f.itemname_vchr,
                               c.sampletype_vchr,
                               g.code_vchr,
                               g.deptname_vchr,
                               c.modify_dat
                          from t_opr_lis_application a
                          left join t_opr_lis_sample c
                            on a.application_id_chr = c.application_id_chr
                          left join t_opr_outpatient_orderdic d
                            on a.application_id_chr = d.attachid_vchr
                          left join t_tmp_outpatientchkrecipede e
                            on d.outpatrecipeid_chr = e.outpatrecipeid_chr
                          left join t_bse_chargeitem f
                            on e.itemid_chr = f.itemid_chr
                          left join t_bse_deptdesc g
                            on a.appl_deptid_chr = g.deptid_chr
                         where c.status_int >= 5
                           and a.pstatus_int = 2
                           and f.itemcode_vchr in
                               ('861636', '861618', '861621', '861633', '861616', '861619')
                           and c.modify_dat between
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + ":00";
                parm[1].Value = endDate + ":59";
                parm[2].Value = beginDate + ":00";
                parm[3].Value = endDate + ":59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "LisSampleType";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region GetLisSampletype2
        /// <summary>
        /// GetLisSampletype2
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="groupId"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetLisSampletype2(string beginDate, string endDate, string groupId, string applyUnitId, string patType, string strDept)
        {
            long lngRes = 0;
            DataTable dtbResult = null;
            string strSQL = string.Empty;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();
                strSQL = @"select distinct a.application_id_chr,
                                            d.barcode_vchr              AS BARCODE,
                                            t1.apply_unit_name_vchr,
                                            a.patient_name_vchr         AS HZXM, --患者姓名
                                            d.patient_inhospitalno_chr  AS patInNo,
                                            d.patientcardid_chr         AS CARDNO,
                                            a.patientid_chr,
                                            e.code_vchr, -- 送检科室
                                            e.deptname_vchr, --科室名称
                                            d.sampletype_vchr, --标本类型
                                            t2.check_category_desc_vchr
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_apply_unit t
                                on a.application_id_chr = t.application_id_chr
                              left join t_aid_lis_apply_unit t1
                                on t.apply_unit_id_chr = t1.apply_unit_id_chr
                              left join t_bse_lis_check_category t2
                                on t1.check_category_id_chr = t2.check_category_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and d.modify_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                               and e.deptid_chr is not null ";

                if (!string.IsNullOrEmpty(strDept))
                {
                    strSQL += " and e.deptid_chr in  ( " + strDept + ")" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(applyUnitId))
                {
                    strSQL += " and t.apply_unit_id_chr  in " + applyUnitId + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t2.check_category_id_chr  = '" + groupId + "'" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(patType))
                {
                    strSQL += " and a.patient_type_id_chr = 2 " + Environment.NewLine;
                }

                strSQL += " order by deptname_vchr,t1.apply_unit_name_vchr";
                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":00";
                parm[1].Value = endDate + ":59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return dtbResult;
        }
        #endregion

        #region  病原微生物标本类型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="groupId"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="patType"></param>
        /// <param name="strDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetBysswSampletype(string beginDate, string endDate, string groupId, string applyUnitId, string patType, string strDept)
        {
            long lngRes = 0;
            DataTable dtbResult = null;
            string strSQL = string.Empty;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();
                strSQL = @"select distinct 
                                            d.sampletype_vchr --标本类型
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_apply_unit t
                                on a.application_id_chr = t.application_id_chr
                              left join t_aid_lis_apply_unit t1
                                on t.apply_unit_id_chr = t1.apply_unit_id_chr
                              left join t_bse_lis_check_category t2
                                on t1.check_category_id_chr = t2.check_category_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and d.modify_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                               and e.deptid_chr is not null ";

                if (!string.IsNullOrEmpty(strDept))
                {
                    strSQL += " and e.deptid_chr in  ( " + strDept + ")" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(applyUnitId))
                {
                    strSQL += " and t.apply_unit_id_chr  in " + applyUnitId + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t2.check_category_id_chr  = '" + groupId + "'" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(patType))
                {
                    strSQL += " and a.patient_type_id_chr = 2 " + Environment.NewLine;
                }

                strSQL += " order by sampletype_vchr ";
                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":00";
                parm[1].Value = endDate + ":59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return dtbResult;
        }
        #endregion

        #region    检验标本质量分析
        /// <summary>
        /// GetStatSampleBack
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetStatSampleBack(string beginDate, string endDate, string sampleType, int patType)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                //                Sql = @"select distinct t.application_id_chr,t.sample_id_chr,
                //                        t.patient_name_vchr ,b.code_vchr,
                //                        b.deptname_vchr,t.sampletype_vchr,a.sample_back_reason_vchr
                //                        from t_opr_lis_sample t 
                //                        left join t_opr_lis_sample_feedback a 
                //                        on t.sample_id_chr = a.sample_id_chr
                //                        left join t_bse_deptdesc b 
                //                        on t.appl_deptid_chr = b.deptid_chr
                //                        where t.status_int >= 0 and t.status_int <= 7
                //                        and (t.accept_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                //                        and to_date(?, 'yyyy-mm-dd hh24:mi:ss')) ";

                //                if (!string.IsNullOrEmpty(type) && type != "全部")
                //                    Sql += " and trim(t.sampletype_vchr) = '" + type + "'";

                Sql = @"select distinct  t.application_id_chr,t.sample_id_chr,
                        t.patient_name_vchr ,b.code_vchr,
                        b.deptname_vchr,t.sampletype_vchr,a.sample_back_reason_vchr
                        --t3.check_category_id_chr,t3.check_category_desc_vchr
                        from t_opr_lis_sample t 
                        left join icare.t_opr_lis_sample_feedback a 
                        on t.sample_id_chr = a.sample_id_chr
                        left join t_bse_deptdesc b 
                        on t.appl_deptid_chr = b.deptid_chr
                        left join t_opr_lis_app_check_item t1
                        on t.application_id_chr = t1.application_id_chr
                        left join  t_bse_lis_check_item t2
                        on t1.check_item_id_chr = t2.check_item_id_chr
                        left join t_bse_lis_check_category t3
                        on t2.check_category_id_chr = t3.check_category_id_chr
                        where t.status_int >= 0 and t.status_int <= 7
                        and (t.modify_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                        and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        and b.deptname_vchr is not null ";

                if (!string.IsNullOrEmpty(sampleType) && sampleType != "全部")
                    Sql += " and trim(t3.check_category_desc_vchr) = '" + sampleType.Trim() + "'";
                if (patType != 0)
                    Sql += " and t.patient_type_chr = " + patType;

                Sql += " order by b.deptname_vchr";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":01";
                parm[1].Value = endDate + ":59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "SampleBack";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region    检验标本质量分析
        /// <summary>
        /// GetStatSampleBack
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetStatSampleBack2(string beginDate, string endDate, string sampleType, int patType)
        {
            string Sql = string.Empty;
            DataTable dtSample = new DataTable();
            DataTable dtBack = new DataTable();
            DataTable dtResult = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {

                Sql = @"select distinct  
                                t.application_id_chr,
                                t.sample_id_chr,
                                t.patient_name_vchr ,
                                b.code_vchr,
                                b.deptname_vchr,
                                t.sampletype_vchr,
                                '' as sample_back_reason_vchr
                                from t_opr_lis_sample t 
                                left join t_bse_deptdesc b 
                                on t.appl_deptid_chr = b.deptid_chr
                                left join t_opr_lis_app_check_item t1
                                on t.application_id_chr = t1.application_id_chr
                                left join  t_bse_lis_check_item t2
                                on t1.check_item_id_chr = t2.check_item_id_chr
                                left join t_bse_lis_check_category t3
                                on t2.check_category_id_chr = t3.check_category_id_chr
                                where t.status_int >= 0 and t.status_int <= 7
                                and (t.modify_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                                and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                and b.deptname_vchr is not null ";

                //if (!string.IsNullOrEmpty(sampleType) && sampleType != "全部")
                //    Sql += " and trim(t3.check_category_desc_vchr) = '" + sampleType.Trim() + "'";
                if (patType != 0)
                    Sql += " and t.patient_type_chr = " + patType;

                Sql += " order by b.deptname_vchr";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":01";
                parm[1].Value = endDate + ":59";
                svc.lngGetDataTableWithParameters(Sql, ref dtSample, parm);

                if (dtSample != null && dtSample.Rows.Count > 0)
                {
                    if (dtResult == null) dtResult = dtSample.Clone();
                    dtResult.Merge(dtSample);
                    dtResult.AcceptChanges();
                }

                Sql = @"select 
                            c.application_id_chr,
                            c.sample_id_chr,
                            a.patient_name_vchr,
                            b.code_vchr,
                            b.deptname_vchr,
                            c.sampletype_vchr,
                            a.sample_back_reason_vchr,
                            a.feedback_date_date
                            from t_opr_lis_sample_feedback a
                            inner join t_opr_lis_sample c
                            on a.sample_id_chr = c.sample_id_chr
                            inner join t_opr_lis_application d
                            on c.application_id_chr = d.application_id_chr
                            left outer join t_bse_deptdesc b
                            on a.appl_empid_chr = b.deptid_chr
                            where a.feedback_date_date between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                            to_date(?, 'yyyy-mm-dd hh24:mi:ss')   ";

                if (patType != 0)
                    Sql += " and c.patient_type_chr = " + patType;

                Sql += " order by a.sample_id_chr, a.feedback_date_date";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":01";
                parm[1].Value = endDate + ":59";
                svc.lngGetDataTableWithParameters(Sql, ref dtBack, parm);

                if (dtBack != null)
                {
                    if (dtBack.Rows.Count > 0)
                    {
                        List<int> lstDelRowNo = new List<int>();
                        for (int i = 0; i < dtBack.Rows.Count - 1; i++)
                        {
                            for (int j = i + 1; j < dtBack.Rows.Count - 1; j++)
                            {
                                if (j == 574)
                                    j = 574;
                                if (dtBack.Rows[j]["sample_id_chr"].ToString() == dtBack.Rows[i]["sample_id_chr"].ToString() && dtBack.Rows[j]["sample_back_reason_vchr"].ToString() == dtBack.Rows[i]["sample_back_reason_vchr"].ToString())
                                {
                                    if (lstDelRowNo.IndexOf(j) < 0) lstDelRowNo.Add(j);
                                }
                            }
                        }
                        if (lstDelRowNo.Count > 0)
                        {
                            for (int i = lstDelRowNo.Count - 1; i >= 0; i--)
                            {
                                dtBack.Rows.RemoveAt(lstDelRowNo[i]);
                            }
                        }

                    }
                    dtBack.Columns.Remove("feedback_date_date");
                    if (dtResult == null) dtResult = dtBack.Clone();
                    dtResult.Merge(dtBack);
                    dtResult.AcceptChanges();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dtResult;
        }
        #endregion

        #region 拒收原因
        /// <summary>
        /// GetStatSampleBack
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetStatSampleBackReson(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;

            try
            {
                Sql = @"select distinct a.sample_back_reason_vchr
                                        from t_opr_lis_sample_feedback a where a.feedback_date_date 
                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                        and to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + ":01";
                parm[1].Value = endDate + ":59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);

                if (dt != null)
                    dt.TableName = "SampleBackReson";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取科室信息
        /// <summary>
        /// GetDeptList
        /// </summary>
        /// <param>0 全院  1 医技科室<param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetDeptList(int deptint)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                if (deptint == 0)
                    Sql = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                           and ((inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0
                                  or code_vchr in ('0103'))
                      order by code_vchr
                       ";
                else
                    Sql = @"select deptid_chr,code_vchr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                               and code_vchr in ('30','31','32','3201','3202','3205','3206')
                      order by code_vchr
                       ";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "DeptList";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取危急值范围
        /// <summary>
        /// GetCrval
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCrval()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select a.check_item_id_chr,
                                   a.seq_int,
                                   a.from_age_dec,
                                   a.to_age_dec,
                                   a.sex_vchr,
                                   a.crvalmin,
                                   a.crvalmax,
                                   b.ALERT_VALUE_RANGE_VCHR,
                                   b.is_sex_related_chr,
                                   b.is_age_related_chr
                              from t_bse_lis_itemref a
                             inner join t_bse_lis_check_item b
                                on a.check_item_id_chr = b.check_item_id_chr";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "Crval";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }

        /// <summary>
        /// GetCrval
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetCrval2()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select * from t_bse_lis_check_item b";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "Crval2";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取标本类型
        /// <summary>
        /// GetSampleType
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetSampleType()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select sample_type_id_chr, sample_type_desc_vchr, pycode_chr, wbcode_chr,
       stdcode1_chr, stdcode2_chr from t_aid_lis_sampletype order by sample_type_id_chr";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "SampleType";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取检验类型
        /// <summary>
        /// GetSampleType
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetGategoryType()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select a.check_category_desc_vchr,a.check_category_id_chr from t_bse_lis_check_category a";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "GategoryType";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取检验类型
        /// <summary>
        /// GetSampleType
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetGategoryType2()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select a.itemcode,a.itemname from diccommon a where a.classid = 33";

                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "applyUnit";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取院感危急值条件
        /// <summary>
        /// GetSampleType
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetYGItemType()
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select refId, refDesc from t_criticalvalue_ref_yg";

                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "YGItemType";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取服务价格内容
        /// <summary>
        /// GeItemContent
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GeItemContent(string findStr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            try
            {
                Sql = @"select 
                    a.clasifinancial as 财务分类,
                    a.itemcode as 编码,
                    a.itemname as 项目名称,
                    a.itemcontent as 项目内涵,
                    a.extracontent as 除外内容,
                    a.unit as 计价单位,
                    a.reamark as 说明,
                    a.proprice as 省定价格,
                    a.thirdprice as 三档,
                    a.secondprice as 二档,
                    a.firstprice as 一档 
                    from t_financial a ";

                if (findStr != "")
                {
                    Sql += " where  a.itemcode = '" + findStr + "'";
                    Sql += " or (a.itemname like '%" + findStr + "%'" + "or upper(a.py) like '" + findStr + "%')";
                }
                svc.lngGetDataTableWithParameters(Sql, ref dt);
                if (dt != null) dt.TableName = "ItemContent";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region 获取所有检验项目
        #region GetLisCheckItem
        /// <summary>
        /// GetLisCheckItem
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetLisCheckItem(string beginDate, string endDate, string CheckLisId)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select /*+ INDEX(a,IDX_APPID)*/ a.check_item_id_chr 
                        from  t_opr_lis_app_check_item a
                        left join  t_opr_lis_sample b
                        on a.application_id_chr = b.application_id_chr and b.status_int >= 5
                        where b.appl_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

                //and b.status_int >= 3 and b.status_int < 7 ;

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                if (!string.IsNullOrEmpty(CheckLisId))
                    Sql += "  and a.check_item_id_chr in " + CheckLisId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "LisCheckItem";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #endregion

        #region 获取所有检查项目

        #region 获取所有检查项目
        /// <summary>
        /// GetPacsCheckItem
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPacsCheckItem(string beginDate, string endDate, string CheckPacsId)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select a.applyid,a.applydate, 
                        a.department,a.diagnosepart 
                        from ar_common_apply a 
                        where a.applydate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                            and a.submitted = 1
                            and a.deleted <> 1
                            and a.bihno is not null";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                if (!string.IsNullOrEmpty(CheckPacsId))
                    Sql += "  and a.diagnosepart in " + CheckPacsId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "PacsCheckItem";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #endregion

        #region 检验质量报表

        #region 检验科工作人员工作量统计分析表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetWorkLoadCount(string dteStart, string dteEnd, string categoryId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select a.application_id_chr,
                                           f.lastname_vchr as checker, --检验者
                                           f.empid_chr as checkerId,
                                           d.sampletype_vchr AS BBLX, --标本类型
                                           t2.check_category_id_chr as categoryId,
                                           t2.check_category_desc_vchr as categoryDesc
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_apply_unit t
                                        on a.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                      left join t_bse_lis_check_category t2
                                        on t1.check_category_id_chr = t2.check_category_id_chr
                                      left join t_bse_employee f
                                        on a.operator_id_chr = f.empid_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and d.confirm_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";

                if (!string.IsNullOrEmpty(categoryId))
                {
                    strSQL += " and t1.check_category_id_chr = '" + categoryId + "'";
                }

                strSQL += " order by f.lastname_vchr ,t2.check_category_id_chr  ";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 检验标本周转中位数统计表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <param name="enmergencyFlg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetSampleMedSpec(out DataTable dtbResult, string dteStart, string dteEnd, string groupId, string applyUnitId, string strDept, string enmergencyFlg, string patType)
        {
            long lngRes = 0;
            dtbResult = null;
            string strSQL = string.Empty;
            string strSQL1 = string.Empty;
            string strSQL2 = string.Empty;

            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                if (string.IsNullOrEmpty(patType))
                {
                    strSQL1 = @"select distinct a.application_id_chr,a.age_chr as Age,
                                                    d.barcode_vchr  AS BARCODE,
                                                    a.check_content_vchr,
                                                    --t1.apply_unit_name_vchr,
                                                    a.patient_name_vchr AS HZXM, --患者姓名
                                                    d.patient_inhospitalno_chr   AS patInNo,
                                                    d.patientcardid_chr   AS CARDNO,
                                                    a.patientid_chr,
                                                    f.lastname_vchr ,         --检验者
                                                    e.deptid_chr AS SJKS, -- 送检科室
                                                    e.deptname_vchr AS DEPTNAME, --科室名称
                                                    d.sampletype_vchr AS BBLX, --标本类型
                                                    t2.check_category_desc_vchr,
                                                    d.appl_dat       AS applyTime,
                                                    to_char(k.packdate, 'yyyy-mm-dd hh24:mi:ss') AS DBSJ, --打包时间
                                                    to_char(d.confirm_dat, 'yyyy-mm-dd hh24:mi:ss') AS SHSJ, --审核时间
                                                    to_char(d.accept_dat, 'yyyy-mm-dd hh24:mi:ss') AS HSSJ, --核收时间
                                                    ceil((d.accept_dat - k.packdate) * 24 * 60) as preTime,
                                                    ceil((d.confirm_dat - d.accept_dat) * 24 * 60) as lisTime
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_apply_unit t
                                        on a.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                     left join t_bse_lis_check_category t2
                                    on t1.check_category_id_chr = t2.check_category_id_chr
                                      left join icare.t_samplepack k
                                        on d.barcode_vchr = k.barcode
                                      left join t_bse_deptdesc e
                                        on a.appl_deptid_chr = e.deptid_chr
                                      left join t_bse_employee f
                                        on a.operator_id_chr = f.empid_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and d.modify_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       and e.deptid_chr is not null
                                       and d.patient_type_chr = 1 ";

                    strSQL2 = @"select distinct a.application_id_chr,a.age_chr as Age,
                                                    d.barcode_vchr   AS BARCODE,
                                                    a.check_content_vchr,
                                                    --t1.apply_unit_name_vchr,
                                                    a.patient_name_vchr AS HZXM, --患者姓名
                                                    d.patient_inhospitalno_chr   AS patInNo,
                                                    d.patientcardid_chr   AS CARDNO,
                                                    a.patientid_chr,
                                                    f.lastname_vchr ,         --检验者
                                                    e.deptid_chr AS SJKS, -- 送检科室
                                                    e.deptname_vchr AS DEPTNAME, --科室名称
                                                    d.sampletype_vchr AS BBLX, --标本类型
                                                    t2.check_category_desc_vchr,
                                                    d.appl_dat       AS applyTime,
                                                    to_char(a.printed_date, 'yyyy-mm-dd hh24:mi:ss') AS DBSJ, --打印时间
                                                    to_char(d.confirm_dat, 'yyyy-mm-dd hh24:mi:ss') AS SHSJ, --审核时间
                                                    to_char(d.accept_dat, 'yyyy-mm-dd hh24:mi:ss') AS HSSJ, --核收时间
                                                    ceil((d.accept_dat - a.printed_date) * 24 * 60) as preTime,
                                                    ceil((d.confirm_dat - d.accept_dat) * 24 * 60) as lisTime
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_apply_unit t
                                        on a.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                      left join t_bse_lis_check_category t2
                                        on t1.check_category_id_chr = t2.check_category_id_chr
                                      left join t_bse_deptdesc e
                                        on a.appl_deptid_chr = e.deptid_chr
                                      left join t_bse_employee f
                                        on a.operator_id_chr = f.empid_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and d.modify_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       and e.deptid_chr is not null
                                       and d.patient_type_chr = 2 ";
                }
                if (patType == "2")   //门诊
                {
                    strSQL = @"select distinct a.application_id_chr,a.age_chr as Age,
                                                    d.barcode_vchr   AS BARCODE,
                                                     a.check_content_vchr,
                                                    --t1.apply_unit_name_vchr,
                                                    a.patient_name_vchr AS HZXM, --患者姓名
                                                    d.patient_inhospitalno_chr   AS patInNo,
                                                    d.patientcardid_chr   AS CARDNO,
                                                    a.patientid_chr,
                                                    f.lastname_vchr ,         --检验者
                                                    e.deptid_chr AS SJKS, -- 送检科室
                                                    e.deptname_vchr AS DEPTNAME, --科室名称
                                                    d.sampletype_vchr AS BBLX, --标本类型
                                                    t2.check_category_desc_vchr,
                                                    d.appl_dat       AS applyTime,
                                                    to_char(a.printed_date, 'yyyy-mm-dd hh24:mi:ss') AS DBSJ, --打印时间
                                                    to_char(d.confirm_dat, 'yyyy-mm-dd hh24:mi:ss') AS SHSJ, --审核时间
                                                    to_char(d.accept_dat, 'yyyy-mm-dd hh24:mi:ss') AS HSSJ, --核收时间
                                                    ceil((d.accept_dat - a.printed_date) * 24 * 60) as preTime,
                                                    ceil((d.confirm_dat - d.accept_dat) * 24 * 60) as lisTime
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_apply_unit t
                                        on a.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                      left join t_bse_lis_check_category t2
                                        on t1.check_category_id_chr = t2.check_category_id_chr
                                      left join t_bse_deptdesc e
                                        on a.appl_deptid_chr = e.deptid_chr
                                      left join t_bse_employee f
                                      on a.operator_id_chr = f.empid_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and d.modify_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       and e.deptid_chr is not null
                                       and d.patient_type_chr = 2 ";
                }
                else if (patType == "1")   //住院
                {
                    strSQL = @"select distinct a.application_id_chr,a.age_chr as Age,
                                                    d.barcode_vchr AS BARCODE,
                                                     a.check_content_vchr,
                                                    --t1.apply_unit_name_vchr,
                                                    a.patient_name_vchr AS HZXM, --患者姓名
                                                    d.patient_inhospitalno_chr AS patInNo, 
                                                    d.patientcardid_chr  AS CARDNO,
                                                    a.patientid_chr, 
                                                    f.lastname_vchr ,         --检验者
                                                    e.deptid_chr AS SJKS, -- 送检科室
                                                    e.deptname_vchr AS DEPTNAME, --科室名称
                                                    d.sampletype_vchr AS BBLX, --标本类型
                                                    t2.check_category_desc_vchr,
                                                    d.appl_dat       AS applyTime,
                                                    to_char(k.packdate, 'yyyy-mm-dd hh24:mi:ss') AS DBSJ, --打包时间
                                                    to_char(d.confirm_dat, 'yyyy-mm-dd hh24:mi:ss') AS SHSJ, --审核时间
                                                    to_char(d.accept_dat, 'yyyy-mm-dd hh24:mi:ss') AS HSSJ, --核收时间
                                                    ceil((d.accept_dat - k.packdate) * 24 * 60) as preTime,
                                                    ceil((d.confirm_dat - d.accept_dat) * 24 * 60) as lisTime
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_apply_unit t
                                        on a.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                      left join t_bse_lis_check_category t2
                                        on t1.check_category_id_chr = t2.check_category_id_chr
                                      left join icare.t_samplepack k
                                        on d.barcode_vchr = k.barcode
                                      left join t_bse_deptdesc e
                                        on a.appl_deptid_chr = e.deptid_chr
                                      left join t_bse_employee f
                                        on a.operator_id_chr = f.empid_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and d.modify_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       and e.deptid_chr is not null
                                       and d.patient_type_chr = 1 ";
                }


                if (!string.IsNullOrEmpty(strDept))
                {
                    strSQL += " and e.deptid_chr in  ( " + strDept + ")";
                    strSQL1 += "  and e.deptid_chr in  ( " + strDept + ")";
                    strSQL2 += "  and e.deptid_chr in  ( " + strDept + ")";
                }
                if (!string.IsNullOrEmpty(enmergencyFlg))
                {
                    strSQL += " and a.emergency_int  = " + enmergencyFlg;
                    strSQL1 += " and a.emergency_int  = " + enmergencyFlg;
                    strSQL2 += " and a.emergency_int  = " + enmergencyFlg;
                }

                if (!string.IsNullOrEmpty(applyUnitId))
                {
                    strSQL += " and t.apply_unit_id_chr  in " + applyUnitId;
                    strSQL1 += " and t.apply_unit_id_chr  in " + applyUnitId;
                    strSQL2 += " and t.apply_unit_id_chr  in " + applyUnitId;
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t2.check_category_id_chr  = '" + groupId + "'";
                    strSQL1 += " and t2.check_category_id_chr  = '" + groupId + "'";
                    strSQL2 += " and t2.check_category_id_chr  = '" + groupId + "'";
                }

                if (patType == "1" || patType == "2")
                {
                    strSQL += " order by  DEPTNAME";
                    objHRPServ.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = dteStart + ":00";
                    parm[1].Value = dteEnd + ":59";
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);
                }
                else
                {
                    strSQL = strSQL1 + Environment.NewLine + "union all " + Environment.NewLine + strSQL2;
                    strSQL = "select * from (" + strSQL + ")" + " order by application_id_chr, DEPTNAME ";
                    objHRPServ.CreateDatabaseParameter(4, out parm);
                    parm[0].Value = dteStart + ":00";
                    parm[1].Value = dteEnd + ":59";
                    parm[2].Value = dteStart + ":00";
                    parm[3].Value = dteEnd + ":59";
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);
                }

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }

        #endregion

        #region 检验报告发放时限符合率统计报表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <param name="enmergencyFlg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetSampleAcceptable(out DataTable dtbResult, string dteStart, string dteEnd, string groupId, string applyUnitId, string strDept, string enmergencyFlg, string patType)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select distinct 
                                a.application_id_chr, a.check_content_vchr as checkContent,
                                d.patient_inhospitalno_chr as patInNo,
                                d.patientcardid_chr  as CARDNO,
                                d.barcode_vchr as barcode,
                                t1.apply_unit_id_chr,--检验项目编号
                                t1.apply_unit_name_vchr,
                                a.patient_name_vchr  AS HZXM, --患者姓名
                                a.patientid_chr,
                                a.appl_deptid_chr,
                                e.deptid_chr          AS SJKS, -- 送检科室
                                e.deptname_vchr       AS DEPTNAME,--科室名称
                                d.sampletype_vchr     AS BBLX, --标本类型       
                                to_char(d.confirm_dat, 'yyyy-mm-dd hh24:mi:ss')     AS confirmtime,  --报告时间
                                to_char(d.accept_dat,'yyyy-mm-dd hh24:mi:ss')       AS accepttime, --核收时间
                                d.appl_dat       AS applyTime,
                                ceil((d.confirm_dat-d.accept_dat)* 24 * 60)         as lisTime,
                                g.lastname_vchr ,         --检验者
                                a.emergency_int,              --是否急诊
                                f.*
                                from t_opr_lis_application a 
                                left join t_opr_lis_sample d 
                                on a.application_id_chr = d.application_id_chr 
                                left join t_opr_lis_app_apply_unit t
                                on a.application_id_chr = t.application_id_chr
                                left join t_aid_lis_apply_unit t1
                                on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                left join t_bse_lis_check_category t2
                                on t1.check_category_id_chr = t2.check_category_id_chr
                                left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                                left join t_limittimemaitain f
                                on t1.apply_unit_id_chr = f.applyunitid
                                left join t_bse_employee g
                                on a.operator_id_chr = g.empid_chr
                                where d.status_int > 5
                                and a.pstatus_int  = 2
                                and d.modify_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                                and to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                                and e.deptid_chr is not null ";

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t2.check_category_id_chr = '" + groupId + "'";
                }

                if (!string.IsNullOrEmpty(strDept))
                {
                    strSQL += " and e.deptid_chr in  ( " + strDept + ")";
                }

                if (!string.IsNullOrEmpty(enmergencyFlg))
                {
                    strSQL += " and a.emergency_int  = " + enmergencyFlg;
                }

                if (!string.IsNullOrEmpty(patType))
                {
                    strSQL += " d.patient_type_chr = " + patType;
                }

                if (!string.IsNullOrEmpty(applyUnitId))
                {
                    strSQL += " and t.apply_unit_id_chr  in " + applyUnitId;
                }

                strSQL += " order by e.deptname_vchr ";
                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + ":00";
                parm[1].Value = dteEnd + ":59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }

        #endregion

        #region  阳性结果分析统计
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <param name="enmergencyFlg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPositiveReport(out DataTable dtbResult, string dteStart, string dteEnd, string checkItemId, string strDept, string groupId, string patNo)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select distinct  /*+ index(a I_IDX_OPR_LIS_APPLICATIONID) index(d IDX_MODIFYDAT) index(r I_IDX_T_OPR_LIS_RE_APPID)*/ 
                                            a.patient_name_vchr AS HZXM, --患者姓名
                                            a.sex_chr,
                                            a.patient_inhospitalno_chr,
                                            a.patientcardid_chr,
                                            a.appl_deptid_chr,
                                            e.deptname_vchr AS deptName, -- 送检科室
                                            e1.lastname_vchr AS applyDoct, -- 申请医生
                                            e2.lastname_vchr  AS checker,  --检验者
                                            r1.check_item_id_chr ,
                                            r1.check_item_name_vchr,
                                            d.sampletype_vchr AS BBLX, --标本类型
                                            to_char(d.sampling_date_dat, 'yyyy-mm-dd hh24:mi:ss') AS CYSJ, --采样时间
                                            to_char(r.report_dat, 'yyyy-mm-dd hh24:mi:ss') AS BGSJ, --报告时间
                                            r1.refrange_vchr,
                                            r1.max_val_dec,
                                            r1.min_val_dec,
                                            r1.abnormal_flag_chr as abnormal,
                                            r1.result_vchr
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_bse_employee e1
                                on a.appl_empid_chr = e1.empid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                              left join t_bse_employee e2
                                on r.reportor_id_chr = e2.empid_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and d.modify_dat between
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss') 
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and r1.status_int = 1  ";

                if (!string.IsNullOrEmpty(strDept))
                {
                    strSQL += " and e.deptid_chr in  ( " + strDept + ")";
                }

                if (!string.IsNullOrEmpty(checkItemId))
                {
                    strSQL += " and r1.check_item_id_chr in " + checkItemId;
                }

                if (!string.IsNullOrEmpty(patNo))
                {
                    strSQL += " and (a.patientcardid_chr like '%" + patNo + "%' or a.patient_inhospitalno_chr like '" + patNo + "%')";
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t2.check_category_id_chr = '" + groupId + "'";
                }

                strSQL += " order by e.deptname_vchr";
                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + ":00";
                parm[1].Value = dteEnd + ":59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }

        #endregion

        #region 免费母婴阻断阳性结果汇总表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPmpctDetail(string dteStart, string dteEnd, string patType, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select c.application_id_chr,
                                       c.modify_dat           as RQ,
                                       d.patient_name_vchr    as XM,
                                       c.sex_chr              as XB,
                                       e.deptname_vchr        as KS,
                                       d.patientcardid_chr    as MZH,
                                       d.patient_inhospitalno_chr as ZYH,
                                       c.patient_type_chr,
                                       a.check_item_id_chr,
                                       a.check_item_name_vchr     as XMMC,
                                       a.result_vchr              as XMJG,
                                       f.lastname_vchr            as SQYS,
                                       g.lastname_vchr            as JYZ
                                  from t_opr_lis_check_result a
                                  left join t_opr_lis_sample c
                                    on a.sample_id_chr = c.sample_id_chr
                                  left join t_opr_lis_application d
                                    on c.application_id_chr = d.application_id_chr
                                    left join t_opr_lis_app_apply_unit t
                                        on c.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                    left join t_bse_deptdesc e
                                    on d.appl_deptid_chr = e.deptid_chr
                                    left join t_bse_employee f
                                    on d.appl_empid_chr = f.empid_chr
                                    left join t_bse_employee g
                                    on a.operator_id_chr = g.empid_chr
                                 where a.check_item_id_chr in ('000194','000195', '000196', '001448', '000199','001069')
                                   and c.modify_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and c.status_int >= 5
                                   and d.pstatus_int = 2
                                   and a.status_int = 1 
                                    and  t.apply_unit_id_chr in ('001174','001127','001126','001176','001078','001080','001006','001252','001239') ";

                if (patType == "1")
                {
                    strSQL += Environment.NewLine + " and c.patient_type_chr = 1";
                }
                else if (patType == "2")
                {
                    strSQL += Environment.NewLine + " and c.patient_type_chr = 2";
                }
                else
                    strSQL += " and (c.patient_type_chr = 1 or c.patient_type_chr = 2)";

                strSQL += " order by KS , c.application_id_chr";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 免费母婴阻断检测工作情况记录表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPmpctStat(string dteStart, string dteEnd, string patType, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select c.application_id_chr,
                                       c.patient_type_chr,
                                       a.check_item_id_chr,
                                       a.check_item_name_vchr,
                                       a.result_vchr,
                                       c.modify_dat   
                                  from t_opr_lis_check_result a
                                  left join t_opr_lis_sample c
                                    on a.sample_id_chr = c.sample_id_chr
                                    left join t_opr_lis_app_apply_unit t
                                        on c.application_id_chr = t.application_id_chr
                                      left join t_aid_lis_apply_unit t1
                                        on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                 where  a.check_item_id_chr in ('000194','000195','000196','001448','000199','001069')
                                   and c.modify_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and c.status_int >= 5
                                   and a.status_int = 1 
                                   and  t.apply_unit_id_chr in('001174','001127','001126','001176','001078','001080','001006','001252','001239') ";
                if (patType == "1")
                {
                    strSQL += Environment.NewLine + " and c.patient_type_chr = 1";
                }
                else if (patType == "2")
                {
                    strSQL += Environment.NewLine + " and c.patient_type_chr = 2";
                }
                else
                    strSQL += " and (c.patient_type_chr = 1 or c.patient_type_chr = 2)";

                strSQL += " order by c.modify_dat";
                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region  工作量统计
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckerQc(out DataTable dtbResult, string dteStart, string dteEnd)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select distinct a.application_id_chr,
                                                a.patient_name_vchr         AS HZXM, --患者姓名
                                                a.sex_chr,
                                                a.patient_inhospitalno_chr,
                                                t3.check_category_id_chr,
                                                t3.check_category_desc_vchr,  --专业组名称
                                                a.patientcardid_chr,
                                                e2.empid_chr,
                                                e2.lastname_vchr            AS checker, --检验者
                                                d.sampletype_vchr           AS BBLX --标本类型
                                  from t_opr_lis_application a
                                  left join t_opr_lis_sample d
                                    on a.application_id_chr = d.application_id_chr
                                  left join t_opr_lis_app_apply_unit t
                                    on a.application_id_chr = t.application_id_chr
                                  left join t_aid_lis_apply_unit t1
                                    on t.apply_unit_id_chr = t1.apply_unit_id_chr
                                  left join t_aid_lis_apply_unit t2
                                    on t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                  left join t_bse_lis_check_category t3
                                    on t2.check_category_id_chr = t3.check_category_id_chr
                                  left join t_opr_lis_app_report r
                                    on a.application_id_chr = r.application_id_chr
                                  left join t_bse_employee e1
                                    on a.appl_empid_chr = e1.empid_chr
                                  left join t_bse_employee e2
                                    on r.reportor_id_chr = e2.empid_chr
                                 where d.status_int > 5
                                   and a.pstatus_int = 2
                                   and r.report_dat between
                                       to_date('2017-04-24 00:00:00', 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date('2017-04-24 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
                                   and r.report_dat is not null
                                   and r.status_int > 1  ";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region  获取申请单元时间维护
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="applyunitid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetLimitTime(out DataTable dtbResult, string applyunitid)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select * 	from t_limitTimeMaitain where applyunitid = ?  ";

                objHRPServ.CreateDatabaseParameter(1, out parm);
                parm[0].Value = applyunitid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 保存申请单元时间
        /// <summary>
        /// lngSaveLimitTime
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long SaveLimitTime(DataTable dt)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            string applyunitid = string.Empty;
            string week1 = string.Empty;
            string week2 = string.Empty;
            string normalLimit = string.Empty;
            string emergencyLimit = string.Empty;
            string acceptTime1 = string.Empty;
            string acceptTime2 = string.Empty;
            string acceptTime3 = string.Empty;
            string acceptTime4 = string.Empty;
            string acceptTime5 = string.Empty;
            string acceptTime6 = string.Empty;
            string confirTime1 = string.Empty;
            string confirTime2 = string.Empty;
            string confirTime3 = string.Empty;
            string confirTime4 = string.Empty;
            string week3 = string.Empty;
            string week4 = string.Empty;
            string week5 = string.Empty;
            string week6 = string.Empty;
            string confirmEndTime = string.Empty;
            string timelimit5 = string.Empty;
            string timelimit6 = string.Empty;

            long res = -1;

            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    applyunitid = dr["applyunitid"].ToString();
                    week1 = string.IsNullOrEmpty(dr["week1"].ToString()) ? "" : dr["week1"].ToString();
                    week2 = string.IsNullOrEmpty(dr["week2"].ToString()) ? "" : dr["week2"].ToString();
                    week3 = string.IsNullOrEmpty(dr["week3"].ToString()) ? "" : dr["week3"].ToString();
                    week4 = string.IsNullOrEmpty(dr["week4"].ToString()) ? "" : dr["week4"].ToString();
                    week5 = string.IsNullOrEmpty(dr["week5"].ToString()) ? "" : dr["week5"].ToString();
                    week6 = string.IsNullOrEmpty(dr["week6"].ToString()) ? "" : dr["week6"].ToString();

                    normalLimit = string.IsNullOrEmpty(dr["normalLimit"].ToString()) ? "" : dr["normalLimit"].ToString();
                    emergencyLimit = string.IsNullOrEmpty(dr["emergencyLimit"].ToString()) ? "" : dr["emergencyLimit"].ToString().Trim();
                    acceptTime1 = string.IsNullOrEmpty(dr["acceptTime1"].ToString()) ? "" : dr["acceptTime1"].ToString();
                    acceptTime2 = string.IsNullOrEmpty(dr["acceptTime2"].ToString()) ? "" : dr["acceptTime2"].ToString();
                    acceptTime3 = string.IsNullOrEmpty(dr["acceptTime3"].ToString()) ? "" : dr["acceptTime3"].ToString();
                    acceptTime4 = string.IsNullOrEmpty(dr["acceptTime4"].ToString()) ? "" : dr["acceptTime4"].ToString();
                    acceptTime5 = string.IsNullOrEmpty(dr["acceptTime5"].ToString()) ? "" : dr["acceptTime5"].ToString();
                    acceptTime6 = string.IsNullOrEmpty(dr["acceptTime6"].ToString()) ? "" : dr["acceptTime6"].ToString();
                    confirmEndTime = string.IsNullOrEmpty(dr["confirmendtime"].ToString()) ? "" : dr["confirmendtime"].ToString();
                    confirTime1 = string.IsNullOrEmpty(dr["confirTime1"].ToString()) ? "" : dr["confirTime1"].ToString();
                    confirTime2 = string.IsNullOrEmpty(dr["confirTime2"].ToString()) ? "" : dr["confirTime2"].ToString();
                    confirTime3 = string.IsNullOrEmpty(dr["confirTime3"].ToString()) ? "" : dr["confirTime3"].ToString();
                    confirTime4 = string.IsNullOrEmpty(dr["confirTime4"].ToString()) ? "" : dr["confirTime4"].ToString();

                    timelimit5 = string.IsNullOrEmpty(dr["timelimit5"].ToString()) ? "" : dr["timelimit5"].ToString();
                    timelimit6 = string.IsNullOrEmpty(dr["timelimit6"].ToString()) ? "" : dr["timelimit6"].ToString();

                    Sql = "delete from t_limitTimeMaitain where applyunitid = '" + applyunitid + "'";
                    svc.DoExcute(Sql);

                    Sql = @"insert into t_limitTimeMaitain
                                     (  applyunitid,
                                        week1,
                                        week2,
                                        normalLimit,
                                        emergencyLimit,
                                        acceptTime1,
                                        acceptTime2,
                                        acceptTime3,
                                        acceptTime4,
                                        week3,
                                        week4,
                                        week5,
                                        week6,
                                        confirmendtime,
                                        confirTime1,
                                        confirTime2,
                                        confirTime3,
                                        confirTime4,
                                        acceptTime5,
                                        acceptTime6,
                                        timelimit5,
                                        timelimit6 )
                             values('" + applyunitid + "','"
                                       + week1 + "','"
                                       + week2 + "','"
                                       + normalLimit + "','"
                                       + emergencyLimit + "','"
                                       + acceptTime1 + "','"
                                       + acceptTime2 + "','"
                                       + acceptTime3 + "','"
                                       + acceptTime4 + "','"
                                       + week3 + "','"
                                       + week4 + "','"
                                       + week5 + "','"
                                       + week6 + "','"
                                       + confirmEndTime + "','"
                                       + confirTime1 + "','"
                                       + confirTime2 + "','"
                                       + confirTime3 + "','"
                                       + confirTime4 + "','"
                                       + acceptTime5 + "','"
                                       + acceptTime6 + "','"
                                       + timelimit5 + "','"
                                       + timelimit6 + "')";

                    res = svc.DoExcute(Sql);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            finally
            {
                svc = null;
            }

            return res;
        }
        #endregion

        #region 删除申请单元时间
        /// <summary>
        /// lngDeleteLimitTime
        /// </summary>
        /// <param name="applyunitid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long DeleteLimitTime(string applyunitid)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();

            long res = -1;

            try
            {
                Sql = "delete from t_limitTimeMaitain where applyunitid = '" + applyunitid + "'";
                svc.DoExcute(Sql);

                res = svc.DoExcute(Sql);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            finally
            {
                svc = null;
            }

            return res;
        }
        #endregion

        #region 获取专业组
        /// <summary>
        /// 获取专业组
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllCheckSpec(out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"SELECT a.user_group_id_chr, a.user_group_name_vchr, a.has_child_group,
                                       a.py_code_chr, a.assist_code01_chr, a.wb_code_chr, a.assist_code02_chr,
                                       a.group_flag_chr, a.operator_id_chr, a.summary_vchr
                                  FROM t_aid_lis_appuser_group a
                                 WHERE a.user_group_id_chr NOT IN (SELECT b.child_user_group_id_chr
                                                                     FROM t_aid_lis_appuser_group_relate b)";


                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 获取所有检验组合项目
        /// <summary>
        /// 获取所有检验项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllCheckItem(out DataTable dtbResult, string groupId)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"SELECT t2.apply_unit_id_chr as 检验项目ID, t2.apply_unit_name_vchr as 检验项目名称
								FROM t_aid_lis_appuser_group_detail t1, t_aid_lis_apply_unit t2
							   WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr ";

                string strSQL1 = @"SELECT t2.apply_unit_id_chr    as 检验项目ID,
                                       t2.apply_unit_name_vchr as 检验项目名称
                                  FROM t_aid_lis_appuser_group_detail t1, t_aid_lis_apply_unit t2
                                 WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                   AND t1.user_group_id_chr = ?
                                union all
                                SELECT t1.user_group_id_chr    as 检验项目ID,
                                       t1.user_group_name_vchr as 检验项目名称
                                  FROM t_aid_lis_appuser_group t1, t_aid_lis_appuser_group_relate t2
                                 WHERE t1.user_group_id_chr = t2.child_user_group_id_chr
                                   AND t2.user_group_id_chr = ? ";
                if (!string.IsNullOrEmpty(groupId))
                {
                    objHRPServ.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = groupId;
                    parm[1].Value = groupId;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL1, ref dtbResult, parm);
                }
                else
                {
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                }

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 获取所有检验组合项目
        /// <summary>
        /// 获取所有检验项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllCheckItemCpy(out DataTable dtbResult, string groupId)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select apply_unit_id_chr as 项目编码, apply_unit_name_vchr as 项目名称 from t_aid_lis_apply_unit ";

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += "where check_category_id_chr = '" + groupId + "'";
                }

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 获取所有检验项目
        /// <summary>
        /// 获取所有检验项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetAllCheckItemDetail(out DataTable dtbResult, string groupId)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                //string strSQL = @"select apply_unit_id_chr as 项目编码, apply_unit_name_vchr as 项目名称 from t_aid_lis_apply_unit ";

                string strSQL = @"select distinct 
                                           t1.check_item_id_chr as 项目编码,
                                           t1.check_item_name_vchr as 项目名称 
                                      from t_bse_lis_check_item         t1,
                                           t_bse_lis_check_category     t2,
                                           t_aid_lis_sampletype         t3
                                     where t1.check_category_id_chr = t2.check_category_id_chr(+)
                                       and t1.sampletype_vchr = t3.sample_type_id_chr
                                     order by t1.check_item_id_chr ";

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += "where t1.check_category_id_chr = '" + groupId + "'";
                }

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 名称检索检验项目
        /// <summary>
        /// 名称检验检验项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="groupId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckItemByName(string strTempName, string groupId, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"SELECT t2.apply_unit_id_chr as 检验项目ID, t2.apply_unit_name_vchr as 检验项目名称
								FROM t_aid_lis_appuser_group_detail t1, t_aid_lis_apply_unit t2
							   WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr ";

                string strSQL1 = @"SELECT t2.apply_unit_id_chr    as 检验项目ID,
                                       t2.apply_unit_name_vchr as 检验项目名称
                                  FROM t_aid_lis_appuser_group_detail t1, t_aid_lis_apply_unit t2
                                 WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr
                                   AND t1.user_group_id_chr = ? {0}
                                union all
                                SELECT t1.user_group_id_chr    as 检验项目ID,
                                       t1.user_group_name_vchr as 检验项目名称
                                  FROM t_aid_lis_appuser_group t1, t_aid_lis_appuser_group_relate t2
                                 WHERE t1.user_group_id_chr = t2.child_user_group_id_chr
                                   AND t2.user_group_id_chr = ? {1}";

                if (!string.IsNullOrEmpty(strTempName))
                {
                    strSQL += "  and t2.apply_unit_name_vchr like '%" + strTempName + "%'";
                    strSQL1 = string.Format(strSQL1, "  and t2.apply_unit_name_vchr like '%" + strTempName + "%'", "  and t1.user_group_name_vchr like '%" + strTempName + "%'");
                }
                else
                {
                    strSQL1 = string.Format(strSQL1, "", "");
                }
                if (!string.IsNullOrEmpty(groupId))
                {
                    objHRPServ.CreateDatabaseParameter(2, out parm);
                    parm[0].Value = groupId;
                    parm[1].Value = groupId;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL1, ref dtbResult, parm);
                }
                else
                {
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                }

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 名称检索检验组合项目
        /// <summary>
        /// 名称检索检验组合项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="groupId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckItemByNameCpy(string strTempName, string groupId, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select a.apply_unit_id_chr  as 项目编码, 
                                         a.apply_unit_name_vchr  as 项目名称
                                         from t_aid_lis_apply_unit a
                                         left join t_bse_lis_check_category b
                                         on a.check_category_id_chr = b.check_category_id_chr 
                                        where a.apply_unit_id_chr is not null";

                if (!string.IsNullOrEmpty(strTempName))
                {
                    strSQL += "  and (a.apply_unit_name_vchr like '%" + strTempName + "%'";
                    strSQL += "  or a.apply_unit_id_chr like '%" + strTempName + "%')";
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and b.check_category_id_chr = '" + groupId + "'";
                }

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 名称检索检验项目
        /// <summary>
        /// 名称检索检验组名称检索检验项目合项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="groupId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckItemDetailByNameCpy(string strTempName, string groupId, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;
            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select distinct 
                                           t1.check_item_id_chr as 项目编码,
                                           t1.check_item_name_vchr as 项目名称 
                                      from t_bse_lis_check_item         t1,
                                           t_bse_lis_check_category     t2,
                                           t_aid_lis_sampletype         t3
                                     where t1.check_category_id_chr = t2.check_category_id_chr(+)
                                       and t1.sampletype_vchr = t3.sample_type_id_chr
                                     ";

                if (!string.IsNullOrEmpty(strTempName))
                {
                    strSQL += "  and (t1.check_item_name_vchr like '%" + strTempName + "%'";
                    strSQL += "  or t1.check_item_id_chr like '%" + strTempName + "%')";
                }

                if (!string.IsNullOrEmpty(groupId))
                {
                    strSQL += " and t1.check_category_id_chr = '" + groupId + "'";
                }

                strSQL += Environment.NewLine + "order by t1.check_item_id_chr ";
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取科室信息
        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetDeptArea(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";

            SQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                               inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                               attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                               wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                               putmed_int
                          from t_bse_deptdesc 
                         where status_int = 1 
                                and category_int = 0
                           and ((inpatientoroutpatient_int = 0 or inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
                      order by code_vchr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 微生物 ATB

        #region 获取所有抗生素
        /// <summary>
        /// 获取所有抗生素
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAllAnti(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"select t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t  order by antiid ";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;

        }
        #endregion

        #region 模糊查询抗生素
        /// <summary>
        /// 模糊查询抗生素
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetFuzzyQueryAnti(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = null;
            if (IsEnglish)
            {
                strSQL = @"select t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t where instr(t.antiid,?)> 0 order by antiid ";
            }
            else
            {
                strSQL = @"select t.cname as 抗生素名称,t.ename as 英文名称 from t_atb_anti t where instr(t.cname,?)> 0 order by antiid ";
            }

            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].DbType = DbType.String;
                objDPArr[0].Value = micName;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有细菌
        /// <summary>
        /// 获取所有细菌
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAllMic(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"select t.cname as 细菌名称,t.ename as 英文名称 from t_atb_germ t order by germid ";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有革半细菌
        /// <summary>
        /// 获取所有革半细菌
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAllGlMic(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;

            string strSQL = @"select * from t_xjmc_glys  b;";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 模糊查询细菌
        /// <summary>
        /// 模糊查询细菌
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetFuzzyQueryMic(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = null;
            if (IsEnglish)
            {
                strSQL = @"select t.cname as 细菌名称,t.ename as 英文名称 
from t_atb_germ t where instr(t.germid,?)> 0 order by germid ";
            }
            else
            {
                strSQL = @"select t.cname as 细菌名称,t.ename as 英文名称 
from t_atb_germ t where instr(t.cname,?)> 0 order by germid ";
            }

            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].DbType = DbType.String;
                objDPArr[0].Value = micName;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 细菌分布报告统计报表
        /// <summary>
        /// 细菌分布报告统计报表
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetBacteriaDistribution(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, string TestMethod, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.age_chr,
                                            a.appl_deptid_chr,
                                            e.deptid_chr               AS SJKS, -- 送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            a.patientid_chr,
                                            r1.CHECK_ITEM_NAME_VCHR,
                                            r1.result_vchr             AS XJMC,
                                            r1.REFRANGE_VCHR
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r.report_dat is not null
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and trim(r1.check_item_name_vchr) = '鉴定结果'
                               and r1.status_int = 1 ";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and a.application_id_chr in " + applicationStr;
                }

                if (!string.IsNullOrEmpty(micname))
                {
                    strSQL += " and r1.result_vchr like'%" + micname + "%' ";
                }
                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += " and e.deptid_chr in " + DeptIdArr;
                }

                strSQL += "  order by a.application_id_chr  ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 累计敏感性报表
        /// <summary>
        /// 累计敏感性报表
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetMicSensitive(string applicationStr, string sampleId, string DisNo, string Sex, string strTempAntiName, string strTempAnti, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.age_chr,
                                            a.appl_deptid_chr,
                                            e.deptid_chr               AS SJKS, -- 送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            a.patientid_chr,
                                            r1.CHECK_ITEM_NAME_VCHR    AS ITEMNAME,
                                            r1.result_vchr             AS RESULT,
                                            r1.REFRANGE_VCHR,
                                            lis.resultval              AS criticalResult
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                                left join t_criticalvalue_main mm
                                      on d.application_id_chr = mm.applyid and mm.status >= 0
                                left join t_criticalvalue_lis lis 
                                      on mm.cvmid = lis.cvmid
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r1.status_int = 1
                               and r1.result_vchr <> '\'";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and a.application_id_chr in " + applicationStr;
                }
                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += " and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(strTempAnti))
                {
                }

                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 细菌分布趋势报告
        /// <summary>
        /// 细菌分布
        /// </summary>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetMicdistributionTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, string TestMethod, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                //IDataParameter[] objDPArr = null;
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.age_chr,
                                            a.appl_deptid_chr,
                                            e.deptid_chr               AS SJKS, -- 送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            d.accept_dat               AS HSSJ,
                                            a.patientid_chr,
                                            r1.CHECK_ITEM_NAME_VCHR,
                                            r1.result_vchr             AS XJMC,
                                            r1.REFRANGE_VCHR
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r.report_dat is not null
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and trim(r1.check_item_name_vchr) = '鉴定结果'
                               and r1.status_int = 1 ";

                //objHRPServ = new clsHRPTableService();
                //objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = p_dtDateFrom.ToString();
                //objDPArr[1].Value = p_dtDateTO.ToString();

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and d.application_id_chr in " + applicationStr;
                }

                if (!string.IsNullOrEmpty(micname))
                {
                    strSQL += " and r1.result_vchr like'%" + micname + "%' ";
                }

                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += " and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += " and e.deptid_chr in " + DeptIdArr;
                }

                strSQL += "  order by a.application_id_chr  ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;

        }
        #endregion

        #region 敏感率趋势报告
        /// <summary>
        /// 敏感率趋势报告
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetSensitiveTend(string applicationStr, string sampleId, string DisNo, string Sex, string strTempAntiID, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.age_chr,
                                            a.appl_deptid_chr,
                                            e.deptid_chr               AS SJKS, --送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            a.patientid_chr,
                                            d.accept_dat               AS HSSJ,
                                            r1.CHECK_ITEM_NAME_VCHR    AS ITEMNAME,
                                            r1.result_vchr             AS RESULT,
                                            r1.REFRANGE_VCHR,
                                            d.modify_dat
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r.report_dat is not null
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and a.application_form_no_chr like '18%'
                               and r1.status_int = 1  ";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and a.application_id_chr in " + applicationStr;
                }
                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 累计MIC报告
        /// <summary>
        /// 累计MIC
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetMicCumulative(string applicationStr, string sampleId, string DisNo, string Sex, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.age_chr,
                                            a.appl_deptid_chr,
                                            e.deptid_chr               AS SJKS, -- 送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            a.patientid_chr,
                                            r1.CHECK_ITEM_NAME_VCHR    AS ITEMNAME,
                                            r1.result_vchr             AS RESULT,
                                            r1.REFRANGE_VCHR,
                                            d.modify_dat
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r.report_dat is not null
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and r1.status_int = 1 ";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and a.application_id_chr in " + applicationStr;
                }
                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                strSQL += "  order by a.application_id_chr  ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 微生物报表明细
        /// <summary>
        /// 
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAntiDetail(string strTempName, DateTime p_dtDateFrom, DateTime p_dtDateTO, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                string strSQL = @"select distinct a.application_id_chr,
                                            a.patient_name_vchr        AS HZXM, --患者姓名
                                            a.sex_chr                  AS SEX,
                                            a.age_chr                  AS AGE,
                                            e.deptname_vchr            AS SJKS, -- 送检科室
                                            a.application_form_no_chr  AS BGBH, --报告编号
                                            d.sampletype_vchr          AS BBLX, --标本类型
                                            a.patient_inhospitalno_chr AS ZYH,
                                            a.patientcardid_chr        AS  KH,
                                            r1.CHECK_ITEM_NAME_VCHR    AS  CHECKITEM,
                                            r1.result_vchr             AS  RESULT,
                                            r1.REFRANGE_VCHR           AS  REFRANGE
                              from t_opr_lis_application a
                              left join t_opr_lis_sample d
                                on a.application_id_chr = d.application_id_chr
                              left join t_opr_lis_app_report r
                                on a.application_id_chr = r.application_id_chr
                              left join t_bse_deptdesc e
                                on a.appl_deptid_chr = e.deptid_chr
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                             where d.status_int > 5
                               and a.pstatus_int = 2
                               and r.report_dat is not null
                               and r.status_int > 1
                               and r1.result_vchr <> '\'
                               and r1.status_int = 1
                               and a.application_id_chr in (select distinct a.application_id_chr
                                  from t_opr_lis_application a
                                  left join t_opr_lis_sample d
                                    on a.application_id_chr = d.application_id_chr
                                  left join t_opr_lis_check_result r1
                                    on d.sample_id_chr = r1.sample_id_chr
                                 where d.status_int > 5
                                   and a.pstatus_int = 2
                                   and d.accept_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and r1.result_vchr <> '\'
                                   and (trim(r1.result_vchr) = '耐药' or trim(r1.result_vchr) = '敏感' or
                                       trim(r1.result_vchr) = '中介')
                                   and r1.status_int = 1 ) ";

                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtDateFrom.ToString();
                objDPArr[1].Value = p_dtDateTO.ToString();

                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += " and e.deptid_chr in " + DeptIdArr;
                }

                //strSQL += "  order by r1.CHECK_ITEM_NAME_VCHR, r1.result_vchr  ";
                strSQL += " order by a.application_id_chr ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 细菌分布 按类型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAntiSample(string strTempName, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select d.sampletype_vchr AS BBLX, --标本类型
                                            a.age_chr   as age,
                                           r1.result_vchr    AS RESULT
                                      from t_opr_lis_application a
                                      left join t_opr_lis_sample d
                                        on a.application_id_chr = d.application_id_chr
                                      left join t_opr_lis_app_report r
                                        on a.application_id_chr = r.application_id_chr
                                      left join t_bse_deptdesc e
                                        on a.appl_deptid_chr = e.deptid_chr
                                      left join t_opr_lis_check_result r1
                                        on d.sample_id_chr = r1.sample_id_chr
                                     where d.status_int > 5
                                       and a.pstatus_int = 2
                                       and r.report_dat is not null
                                       and r.status_int > 1
                                       and r1.result_vchr <> '\'
                                       and r1.status_int = 1
                                       and trim(r1.check_item_name_vchr) = '鉴定结果'  ";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and d.application_id_chr in " + applicationStr;
                }

                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += " and e.deptid_chr in " + DeptIdArr;
                }

                strSQL += " order by d.sample_type_id_chr ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 细菌分布 按科室
        /// <summary>
        /// 
        /// </summary>
        /// <param name="micname">细菌名称</param>
        /// <param name="p_dtDateFrom">日期</param>
        /// <param name="p_dtDateTO">日期</param>
        /// <param name="SamtNo">样本类型</param>
        /// <param name="DisNo">病区号</param>
        /// <param name="Sex">性别</param>
        /// <param name="AgeFrom">年龄</param>
        /// <param name="AgeTo">年龄</param>
        /// <param name="TestMethod">实验方法</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAntiByDept(string strTempName, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select e.deptname_vchr AS KS, --标本类型
                                         a.age_chr   as age,
                                         r1.result_vchr    AS RESULT
                                          from t_opr_lis_application a
                                          left join t_opr_lis_sample d
                                            on a.application_id_chr = d.application_id_chr
                                          left join t_opr_lis_app_report r
                                            on a.application_id_chr = r.application_id_chr
                                          left join t_bse_deptdesc e
                                            on a.appl_deptid_chr = e.deptid_chr
                                          left join t_opr_lis_check_result r1
                                            on d.sample_id_chr = r1.sample_id_chr
                                         where d.status_int > 5
                                           and a.pstatus_int = 2
                                           and r.report_dat is not null
                                           and r.status_int > 1
                                           and r1.result_vchr <> '\'
                                           and r1.status_int = 1
                                           and trim(r1.check_item_name_vchr) = '鉴定结果' ";

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and d.application_id_chr in " + applicationStr;
                }
                if (!string.IsNullOrEmpty(Sex))
                {
                    strSQL += " and trim(a.sex_chr)='" + Sex + "'";
                }
                if (!string.IsNullOrEmpty(DisNo))
                {
                    strSQL += " and a.patient_type_id_chr= '" + DisNo + "'";
                }
                if (!string.IsNullOrEmpty(sampleId))
                {
                    strSQL += "  and d.sample_type_id_chr= '" + sampleId + "'";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += " and e.deptid_chr in " + DeptIdArr;
                }

                strSQL += " order by e.deptname_vchr ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 获取APPLICATION
        /// <summary>
        /// 
        /// </summary>
        /// <param name="micname"></param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetApplicateion(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string criticalStr, string DeptIdArr, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                string strSQL = @"select distinct  d.application_id_chr,
                                            r1.CHECK_ITEM_NAME_VCHR,
                                            r1.result_vchr             AS XJMC,
                                            lis.resultval              AS criticalResult,
                                            d.accept_dat               AS HSSJ
                              from  t_opr_lis_sample d
                              left join t_opr_lis_check_result r1
                                on d.sample_id_chr = r1.sample_id_chr
                                left join t_bse_deptdesc dept
                                on d.appl_deptid_chr = dept.deptid_chr
                                left join t_criticalvalue_main mm
                                      on d.application_id_chr = mm.applyid and mm.status >= 0
                                left join t_criticalvalue_lis lis 
                                      on mm.cvmid = lis.cvmid
                             where r1.check_item_name_vchr = '鉴定结果'
                                and d.status_int > 5
                             and r1.status_int = 1
                               and d.application_id_chr in (select distinct d.application_id_chr
                                  from t_opr_lis_sample d
                                  left join t_opr_lis_check_result r1
                                    on d.sample_id_chr = r1.sample_id_chr
                                 where d.status_int > 5
                                   and d.accept_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                   and r1.result_vchr <> '\'
                                   and (r1.result_vchr = '耐药' or r1.result_vchr = '敏感' or
                                       r1.result_vchr = '中介')
                                   and r1.status_int = 1 )  ";

                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtDateFrom.ToString();
                objDPArr[1].Value = p_dtDateTO.ToString();

                if (criticalStr == "1")
                {
                    strSQL += " and mm.status >= 0 ";
                }

                if (criticalStr == "0")
                {
                    strSQL += "  and mm.status is  null ";
                }

                if (!string.IsNullOrEmpty(micname))
                {
                    strSQL += " and r1.result_vchr like'%" + micname + "%' ";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += "  and dept.deptid_chr in  " + DeptIdArr;
                }
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 获取细菌
        /// <summary>
        /// 
        /// </summary>
        /// <param name="micname"></param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAnti(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string DeptIdArr, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                string strSQL = @"select distinct d.application_id_chr ,
                                                    r1.result_vchr          AS XJMC
                                                  from t_opr_lis_sample d
                                                  left join t_opr_lis_check_result r1
                                                    on d.sample_id_chr = r1.sample_id_chr
                                                 where d.status_int > 5
                                                   and r1.result_vchr <> '\'
                                                   and trim(r1.check_item_name_vchr) = '鉴定结果'
                                                   and r1.status_int = 1
                                                   and d.application_id_chr in
                                                       (select distinct d.application_id_chr
                                                          from t_opr_lis_sample d
                                                          left join t_opr_lis_check_result r1
                                                            on d.sample_id_chr = r1.sample_id_chr
                                                         where d.status_int > 5
                                                           and d.accept_dat between
                                                               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                                               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                           and r1.result_vchr <> '\'
                                                           and (trim(r1.result_vchr) = '耐药' or trim(r1.result_vchr) = '敏感' or
                                                               trim(r1.result_vchr) = '中介')
                                                           and r1.status_int = 1) ";

                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtDateFrom.ToString();
                objDPArr[1].Value = p_dtDateTO.ToString();

                if (!string.IsNullOrEmpty(micname))
                {
                    strSQL += " and r1.result_vchr like'%" + micname + "%' ";
                }

                if (!string.IsNullOrEmpty(DeptIdArr))
                {
                    strSQL += "  and dept.deptid_chr in  " + DeptIdArr;
                }

                strSQL += " order by r1.result_vchr ";
                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 获取抗生素
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationStr"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetGss(string applicationStr, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select distinct r1.CHECK_ITEM_NAME_VCHR AS ITEMNAME
                                                  from t_opr_lis_application a
                                                  left join t_opr_lis_sample d
                                                    on a.application_id_chr = d.application_id_chr
                                                  left join t_opr_lis_app_report r
                                                    on a.application_id_chr = r.application_id_chr
                                                  left join t_opr_lis_check_result r1
                                                    on d.sample_id_chr = r1.sample_id_chr
                                                 where d.status_int > 5
                                                   and a.pstatus_int = 2
                                                   and r.report_dat is not null
                                                   and r.status_int > 1
                                                   and r1.result_vchr <> '\'
                                                   and r1.status_int = 1 ";

                objHRPServ = new clsHRPTableService();

                if (!string.IsNullOrEmpty(applicationStr))
                {
                    strSQL += " and a.application_id_chr in " + applicationStr;
                }

                objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetAntiCheckItem(DateTime p_dtDateFrom, DateTime p_dtDateTO, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                string strSQL = @"select distinct r1.check_item_name_vchr as itemName
                                                  from t_opr_lis_sample d
                                                  left join t_opr_lis_check_result r1
                                                    on d.sample_id_chr = r1.sample_id_chr
                                                 where d.status_int > 5
                                                   and r1.result_vchr <> '\'
                                                   and r1.status_int = 1
                                                   and d.application_id_chr in
                                                       (select distinct a.application_id_chr
                                                          from t_opr_lis_application a
                                                          left join t_opr_lis_sample d
                                                            on a.application_id_chr = d.application_id_chr
                                                          left join t_opr_lis_check_result r1
                                                            on d.sample_id_chr = r1.sample_id_chr
                                                         where d.status_int > 5
                                                           and a.pstatus_int = 2
                                                           and d.accept_dat between
                                                               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                                               to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                           and r1.result_vchr <> '\'
                                                           and (trim(r1.result_vchr) = '耐药' or trim(r1.result_vchr) = '敏感' or
                                                               trim(r1.result_vchr) = '中介')
                                                           and r1.status_int = 1)
                                                           and  (trim( r1.check_item_name_vchr) <> '细菌计数' 
                                                           and  trim( r1.check_item_name_vchr) <> '鉴定结果' ) ";

                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dtDateFrom.ToString();
                objDPArr[1].Value = p_dtDateTO.ToString();
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }

            return lngRes;
        }
        #endregion

        #region 取得病区
        /// <summary>
        /// 获取病区
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetDeptName(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = "select dictid_chr,dictname_vchr from t_aid_dict where trim(dictid_chr) <> '0' and dictkind_chr = '61'";
            clsHRPTableService objHRPServ = null;
            try
            {

                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #region 取得样本类型
        /// <summary>
        /// 取得样本类型
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetSamType(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strSQL = " select sample_type_id_chr, sample_type_desc_vchr from t_aid_lis_sampletype order by sample_type_id_chr ";
            clsHRPTableService objHRPServ = null;
            try
            {
                objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPServ.Dispose();
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }
        #endregion

        #endregion

        #region GetRptCross
        /// <summary>
        /// GetRptCross
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetRptCross(string month)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();

            try
            {
                string tableName = string.Empty;
                if (month == "201701")
                    tableName = "t_rpt_cross201701";
                else if (month == "201702")
                    tableName = "t_rpt_cross201702";
                else if (month == "201703")
                    tableName = "t_rpt_cross201703";
                else if (month == "201704")
                    tableName = "t_rpt_cross201704";
                else if (month == "201705")
                    tableName = "t_rpt_cross201705";
                else if (month == "201706")
                    tableName = "t_rpt_cross201706";
                else if (month == "201707")
                    tableName = "t_rpt_cross201707";
                else if (month == "201708")
                    tableName = "t_rpt_cross201708";
                else if (month == "201709")
                    tableName = "t_rpt_cross201709";
                else if (month == "201710")
                    tableName = "t_rpt_cross201710";
                else if (month == "201711")
                    tableName = "t_rpt_cross201711";
                else if (month == "201712")
                    tableName = "t_rpt_cross201712";
                else
                    tableName = "t_rpt_cross2017";

                Sql = @"select * from " + tableName;
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            finally
            {
                svc = null;
            }
            return dt;
        }
        #endregion

        #region SaveCrossSum
        /// <summary>
        /// SaveCrossSum
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long SaveCrossSum(DataTable dt)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            string shortno_chr = string.Empty;
            string deptname_vchr = string.Empty;
            decimal totalsum = 0;
            string groupid_chr = string.Empty;
            string groupname_chr = string.Empty;
            decimal catsum = 0;

            long res = -1;
            try
            {
                Sql = "delete from t_rpt_cross2017";
                svc.DoExcute(Sql);

                foreach (DataRow dr in dt.Rows)
                {
                    shortno_chr = dr["shortno_chr"].ToString();
                    deptname_vchr = dr["deptname_vchr"].ToString();
                    totalsum = Convert.ToDecimal(dr["totalsum"]);
                    groupid_chr = dr["groupid_chr"].ToString();
                    groupname_chr = dr["groupname_chr"].ToString().Trim();
                    catsum = Convert.ToDecimal(dr["catsum"]);

                    Sql = @"insert into t_rpt_cross2017
                                     (shortno_chr,deptname_vchr,totalsum,
                                        groupid_chr,groupname_chr,catsum)
                             values('" + shortno_chr + "','" + deptname_vchr +
                                                                     "'," + totalsum + ",'" + groupid_chr +
                                                                     "','" + groupname_chr + "'," + catsum + ")";

                    res = svc.DoExcute(Sql);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            finally
            {
                svc = null;
            }

            return res;
        }
        #endregion

        #region 添加到临时表
        /// <summary>
        /// 添加到临时表
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long AddCharegToTable(DataTable dt, string date)
        {
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();
            string shortno_chr = string.Empty;
            string deptname_vchr = string.Empty;
            decimal totalsum = 0;
            string groupid_chr = string.Empty;
            string groupname_chr = string.Empty;
            decimal catsum = 0;

            long res = -1;
            try
            {
                string tableName = string.Empty;
                if (date == "201701")
                    tableName = "t_rpt_cross201701";
                else if (date == "201702")
                    tableName = "t_rpt_cross201702";
                else if (date == "201703")
                    tableName = "t_rpt_cross201703";
                else if (date == "201704")
                    tableName = "t_rpt_cross201704";
                else if (date == "201705")
                    tableName = "t_rpt_cross201705";
                else if (date == "201706")
                    tableName = "t_rpt_cross201706";
                else if (date == "201707")
                    tableName = "t_rpt_cross201707";
                else if (date == "201708")
                    tableName = "t_rpt_cross201708";
                else if (date == "201709")
                    tableName = "t_rpt_cross201709";
                else if (date == "201710")
                    tableName = "t_rpt_cross201710";
                else if (date == "201711")
                    tableName = "t_rpt_cross201711";
                else if (date == "201712")
                    tableName = "t_rpt_cross201712";

                Sql = "delete from t_rpt_cross1";
                svc.DoExcute(Sql);

                Sql = "delete from " + tableName;
                svc.DoExcute(Sql);
                foreach (DataRow dr in dt.Rows)
                {
                    shortno_chr = dr["shortno_chr"].ToString();
                    deptname_vchr = dr["deptname_vchr"].ToString();
                    totalsum = Convert.ToDecimal(dr["totalsum"]);
                    groupid_chr = dr["groupid_chr"].ToString();
                    groupname_chr = dr["groupname_chr"].ToString().Trim();
                    catsum = Convert.ToDecimal(dr["catsum"]);
                    Sql = @"insert into t_rpt_cross1
                                     (shortno_chr,deptname_vchr,totalsum,
                                        groupid_chr,groupname_chr,catsum)
                             values('" + shortno_chr + "','" + deptname_vchr +
                                                                     "'," + totalsum + ",'" + groupid_chr +
                                                                     "','" + groupname_chr + "'," + catsum + ")";
                    res = svc.DoExcute(Sql);

                    Sql = @"insert into " + tableName + @" 
                                     (shortno_chr,deptname_vchr,totalsum,
                                        groupid_chr,groupname_chr,catsum)
                             values('" + shortno_chr + "','" + deptname_vchr +
                                                                    "'," + totalsum + ",'" + groupid_chr +
                                                                    "','" + groupname_chr + "'," + catsum + ")";
                    res = svc.DoExcute(Sql);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);

            }
            finally
            {
                svc = null;
            }

            return res;
        }
        #endregion

        #region 查找各科室费用
        /// <summary>
        /// 查找各科室费用
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetDeptChareg(string beginDate, string endDate, ArrayList DeptIDArr)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @" select  td.shortno_chr, td.deptname_vchr, ta.totalsum, tc.groupid_chr,
                                 nvl (tc.groupname_chr, '未定义') as groupname_chr, tc.catsum
                            from (select   a.createarea_chr, sum (round(a.amount_dec*a.unitprice_dec,2)) as totalsum
                                      from t_opr_bih_patientcharge a
                                     where a.status_int = 1
                                       and a.pstatus_int <> 0  
                                       and (a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') 
                                       and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       )                                          
                                  group by a.createarea_chr) ta,
                                 ( select  a.createarea_chr, tb.groupid_chr, tb.groupname_chr,
                                           sum (round(a.amount_dec*a.unitprice_dec,2)) as catsum
                                      from t_opr_bih_patientcharge a,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '0006' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb
                                     where a.status_int = 1 
                                       and a.pstatus_int <> 0         
                                       and a.calccateid_chr = tb.typeid_chr(+)
                                       and (a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') 
                                       and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                       )   
                                  group by a.createarea_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                 t_bse_deptdesc td
                           where ta.createarea_chr = tc.createarea_chr
                             and ta.totalsum <> 0
                             and ta.createarea_chr = td.deptid_chr(+)
                             and td.shortno_chr <> '0201' and 1 <> 1 
                        order by td.deptname_vchr ";//and a.registerid_chr = '000000153264' 

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                parm[2].Value = beginDate + " 00:00:00";
                parm[3].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null)
                    dt.TableName = "DeptCharge";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 查找各患者ICU费用
        /// <summary>
        /// 查找ICU费用
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetICUchareg(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select a.pchargeid_chr, nvl(a.pchargeidorg_chr, '') as refpchargeid_chr, a.registerid_chr,a.chargeactive_dat, td.shortno_chr, td.deptname_vchr, tb.groupid_chr, tb.groupname_chr,
                                           round(a.amount_dec*a.unitprice_dec,2) as catsum, 0 as rowNo  
                                      from t_opr_bih_patientcharge a,
                                           (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                              from t_aid_rpt_def a,
                                                   t_aid_rpt_gop_def b,
                                                   t_aid_rpt_gop_rla c
                                             where a.rptid_chr = '0006' 
                                               and a.rptid_chr = b.rptid_chr
                                               and b.rptid_chr = c.rptid_chr
                                               and b.groupid_chr = c.groupid_chr(+)) tb,
                                               t_bse_deptdesc td
                                     where a.status_int = 1 
                                       and a.pstatus_int <> 0         
                                       and a.calccateid_chr = tb.typeid_chr(+)
                                       and (a.chargeactive_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 
                                       and a.createarea_chr = td.deptid_chr(+)
                                       and td.shortno_chr = '0201' ";
                //   group by a.registerid_chr,a.chargeactive_dat,td.shortno_chr, tb.groupid_chr, tb.groupname_chr";//and a.registerid_chr = '000000153264' 

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null) dt.TableName = "ICUCharge";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region 患者转科记录
        /// <summary>
        /// 患者转科记录
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPatTransf(string registerid)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {

                Sql = @"select distinct reg.registerid_chr,
                                        trf.transferid_chr,
                                        pat.lastname_vchr as lastname,
                                        reg.inpatientid_chr as inpatientid,
                                        reg.inpatient_dat as inpatientdate,
                                        trf.sourceareaid_chr,
                                        (select code_vchr
                                           from t_bse_deptdesc
                                          where deptid_chr = trf.sourceareaid_chr) as sourceareacode,
                                        (select deptname_vchr
                                          from t_bse_deptdesc
                                         where deptid_chr = trf.sourceareaid_chr) as sourceareaname,
                                        trf.targetareaid_chr,
                                        dep.deptname_vchr as targetareaname,
                                        dep.code_vchr     as targetareancode,
                                        trf.modify_dat as modify_dat
                          from t_bse_deptdesc dep,
                               t_opr_bih_transfer trf,
                               t_opr_bih_register reg,
                               t_opr_bih_registerdetail pat
                         where  reg.registerid_chr = pat.registerid_chr
                           and reg.registerid_chr = trf.registerid_chr
                           and trf.targetareaid_chr = dep.deptid_chr(+)
                           and trf.type_int >= 3
                           and reg.registerid_chr = ? ";

                Sql += " order by trf.modify_dat asc";
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = registerid;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null)
                    dt.TableName = "PatTransf";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
            return dt;
        }
        #endregion

        #region  中心药房报表

        #region 预发药汇总
        /// <summary>
        /// 预发药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="deptStr"></param>
        /// <param name="orderStatus"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetPretestMedStatment(string dteStart, string dteEnd, string deptStr, string orderType, string medName, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select * from ( select 0 as sortNo,
                                                       a.areaid_chr as deptId,
                                                       pre.refputmedreqid_chr as refputmedreqid_chr,
                                                       a.putmedreqid_chr,
                                                       a.putmeddetailid_chr as putMedId,
                                                       p.refputmedreqid_chr as reputMedId,
                                                       b.status_int,
                                                       (case b.status_int
                                                         when -2 then
                                                          '删除'
                                                         when -1 then
                                                          '作废'
                                                         when 0 then
                                                          '创建'
                                                         when 1 then
                                                          '提交'
                                                         when 2 then
                                                          '执行'
                                                         when 3 then
                                                          '停止'
                                                         when 4 then
                                                          '重整'
                                                         when 5 then
                                                          '审核提交'
                                                         when 6 then
                                                          '审核停止'
                                                         when 7 then
                                                          '退回'
                                                       end) as orderStatus,
                                                       d.deptname_vchr as deptName,
                                                       e.bed_no as bedNo,
                                                       c.lastname_vchr as patName,
                                                       a.pubdate_dat as preDate,
                                                       b.finishdate_dat,
                                                       x.creator_chr as nurse,
                                                       n.assistcode_chr as assistcode_chr,
                                                       n.medicinename_vchr,
                                                       n.medspec_vchr,
                                                       a.unitprice_mny,
                                                       a.unit_vchr,
                                                       a.get_dec,
                                                       b.orderdicid_chr as orderDicId,
                                                       b.dosetypename_chr as usageName,
                                                       f.freqname_chr as freqName,
                                                       (a.get_dec2 * a.pretestdays / (a.pretestdays + 1)) as preAmount,
                                                       a.pretestdays,
                                                       decode(nvl(b.isPreTestCharge, 0), 0, '', '是') as isPretestCharge,
                                                       a.unit_vchr as unit,
                                                       m.lastname_vchr as recOperName,
                                                       p.recorddate as recDate,
                                                       p.remark as reMark
                                                  from t_bih_opr_putmeddetail a
                                                 inner join t_opr_bih_order b
                                                    on a.orderid_chr = b.orderid_chr
                                                 inner join t_opr_bih_orderexecute x
                                                    on a.orderexecid_chr = x.orderexecid_chr
                                                 inner join t_bse_patient c
                                                    on a.paientid_chr = c.patientid_chr
                                                 inner join t_bse_deptdesc d
                                                    on a.areaid_chr = d.deptid_chr
                                                 inner join t_bse_bed e
                                                    on a.bedid_chr = e.bedid_chr
                                                 inner join t_aid_recipefreq f
                                                    on b.execfreqid_chr = f.freqid_chr
                                                  left join t_pretestmed p
                                                    on a.putmeddetailid_chr = p.putmeddetailid_chr
                                                  left join (select refputmedreqid_chr, sum(pp.recqty) as preamount
                                                               from t_pretestmed pp
                                                              group by pp.refputmedreqid_chr) pre
                                                    on p.refputmedreqid_chr = pre.refputmedreqid_chr
                                                  left join t_bse_employee m
                                                    on m.empid_chr = p.operid
                                                  left join t_bse_medicine n
                                                    on a.medid_chr = n.medicineid_chr
                                                 where ({0} between
                                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                                union all
                                                select 0 as sortNo,
                                                       a.areaid_chr as deptId,
                                                       pre.refputmedreqid_chr as refputmedreqid_chr,
                                                       a.putmedreqid_chr,
                                                       a.putmeddetailid_chr as putMedId,
                                                       p.refputmedreqid_chr as reputMedId,
                                                       b.status_int,
                                                       (case b.status_int
                                                         when -2 then
                                                          '删除'
                                                         when -1 then
                                                          '作废'
                                                         when 0 then
                                                          '创建'
                                                         when 1 then
                                                          '提交'
                                                         when 2 then
                                                          '执行'
                                                         when 3 then
                                                          '停止'
                                                         when 4 then
                                                          '重整'
                                                         when 5 then
                                                          '审核提交'
                                                         when 6 then
                                                          '审核停止'
                                                         when 7 then
                                                          '退回'
                                                       end) as orderStatus,
                                                       d.deptname_vchr as deptName,
                                                       e.bed_no as bedNo,
                                                       c.lastname_vchr as patName,
                                                       a.pubdate_dat as preDate,
                                                       b.finishdate_dat,
                                                       x.creator_chr as nurse,
                                                       n.assistcode_chr as assistcode_chr,
                                                       n.medicinename_vchr,
                                                       n.medspec_vchr,
                                                       a.unitprice_mny,
                                                       a.unit_vchr,
                                                       a.get_dec,
                                                       b.orderdicid_chr as orderDicId,
                                                       b.dosetypename_chr as usageName,
                                                       f.freqname_chr as freqName,
                                                       (a.get_dec2 * a.pretestdays / (a.pretestdays + 1)) as preAmount,
                                                       a.pretestdays,
                                                       decode(nvl(b.isPreTestCharge, 0), 0, '', '是') as isPretestCharge,
                                                       a.unit_vchr as unit,
                                                       m.lastname_vchr as recOperName,
                                                       p.recorddate as recDate,
                                                       p.remark as reMark
                                                  from t_bih_opr_putmeddetail a
                                                 inner join t_opr_bih_order b
                                                    on a.orderid_chr = b.orderid_chr
                                                 inner join t_opr_bih_orderexecute x
                                                    on a.orderexecid_chr = x.orderexecid_chr
                                                 inner join t_bse_patient c
                                                    on a.paientid_chr = c.patientid_chr
                                                 inner join t_bse_deptdesc d
                                                    on a.areaid_chr = d.deptid_chr
                                                 inner join t_bse_bed e
                                                    on a.bedid_chr = e.bedid_chr
                                                 inner join t_aid_recipefreq f
                                                    on b.execfreqid_chr = f.freqid_chr
                                                  left join t_pretestmed p
                                                    on a.putmeddetailid_chr = p.putmeddetailid_chr
                                                  left join (select refputmedreqid_chr, sum(pp.recqty) as preamount
                                                               from t_pretestmed pp
                                                              group by pp.refputmedreqid_chr) pre
                                                    on p.refputmedreqid_chr = pre.refputmedreqid_chr
                                                  left join t_bse_employee m
                                                    on m.empid_chr = p.operid
                                                  left join t_bse_medicine n
                                                    on a.medid_chr = n.medicineid_chr
                                                 where (b.finishdate_dat between
                                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                                   and b.ispretestcharge = 1) where pretestdays > 0";



                if (!string.IsNullOrEmpty(deptStr))
                {

                    strSQL += " and deptId in (" + deptStr + ") ";
                }

                //if (!string.IsNullOrEmpty(orderStatus))
                //{
                //    strSQL += " and status_int = " + orderStatus;
                //}

                if (orderType == "停止")
                {
                    strSQL = string.Format(strSQL, "p.recorddate");
                    strSQL += " and status_int in ('3','6')";
                }
                else if (orderType == "未停止")
                {
                    strSQL = string.Format(strSQL, "a.pubdate_dat");
                    strSQL += " and status_int not in ('3','6')";
                }

                if (!string.IsNullOrEmpty(medName))
                {
                    strSQL += " and medicinename_vchr like '%" + medName + "%' ";
                }

                strSQL += " order by deptName ";

                objHRPServ.CreateDatabaseParameter(4, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                parm[2].Value = dteStart + " 00:00:00";
                parm[3].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion


        #region 预发药退药
        /// <summary>
        /// 预发药退药
        /// </summary>
        /// <param name="putmeddetailId"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetRePretestMedStat(string putmedreqIdStr, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select a.putmeddetailid_chr,
                                       a.medid_chr,
                                       a.get_dec,
                                       a.putmedreqid_chr,
                                       ( b.assistcode_chr) as assistcode_chr,
                                       (b.medicinename_vchr || '(' || b.mednormalname_vchr || ') ' ) as medicinename_vchr,
                                       nvl(pre.preamount, 0) as premedamount,
                                       b.medspec_vchr
                                  from t_bih_opr_putmeddetail a,
                                       t_bse_medicine b,
                                       t_bse_deptdesc c,
                                       t_opr_bih_register d,
                                       t_opr_bih_registerdetail e,
                                       t_bse_bed f,
                                       t_bse_usagetype g,
                                       t_aid_recipefreq h,
                                       t_opr_bih_orderexecute j,
                                       t_bse_patientcard card,
                                       t_aid_medicinepreptype k,
                                       t_opr_bih_order ord,
                                       (select refputmedreqid_chr, sum(pp.recqty) as preamount
                                                      from t_pretestmed pp
                                                     group by pp.refputmedreqid_chr) pre
                                 where (a.areaid_chr = c.deptid_chr)
                                   and (a.medid_chr = b.medicineid_chr)
                                   and (b.medicinepreptype_chr = k.medicinepreptype_chr(+))
                                   and (a.registerid_chr = d.registerid_chr)
                                   and (d.registerid_chr = e.registerid_chr)
                                   and (a.bedid_chr = f.bedid_chr(+))
                                   and (a.dosetypeid_chr = g.usageid_chr(+))
                                   and (a.execfreqid_chr = h.freqid_chr(+))
                                   and (a.orderexecid_chr = j.orderexecid_chr(+))
                                   and (a.paientid_chr = card.patientid_chr)
                                   and (a.orderid_chr = ord.orderid_chr(+))
                                   and (a.putmeddetailid_chr = pre.refputmedreqid_chr(+))
                                   and a.status_int = 1
                                    and  a.putmeddetailid_chr in   ";

                if (!string.IsNullOrEmpty(putmedreqIdStr))
                {
                    strSQL += putmedreqIdStr;
                }
                else
                    return -1;


                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 疗程用药汇总
        /// <summary>
        /// 疗程用药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="deptStr"></param>
        /// <param name="orderStatus"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetCureMedStatment(string dteStart, string dteEnd, string deptStr, string medName, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select distinct 0 as sortNo,
                                   c.deptid_chr as deptId,
                                   c.deptname_vchr as deptName,
                                   d.bed_no as bedNo,
                                   b.lastname_vchr as patName,
                                   a.registerid_chr as registerid,
                                   a.name_vchr as orderName,
                                   e.freqname_chr as freqName,
                                   a.curedays as cureDays,
                                   (a.get_dec * a.curedays) as preAmount,
                                   a.getunit_chr as unit,
                                   g.ipamountreal,
                                   g.opamountreal,
                                   g.ipamountre,
                                   g.opamountre,
                                   g.medid,
                                   n.unitprice_mny,
                                   n.assistcode_chr,
                                   n.medicinename_vchr,
                                   n.medspec_vchr
                              from t_opr_bih_order a
                             inner join t_bse_bih_orderdic ob
                                on a.orderdicid_chr = ob.orderdicid_chr
                             inner join t_opr_bih_orderchargedept oc
                                on a.orderid_chr = oc.orderid_chr
                               and ob.itemid_chr = oc.chargeitemid_chr
                             inner join t_bse_patient b
                                on a.patientid_chr = b.patientid_chr
                             inner join t_bse_deptdesc c
                                on a.curareaid_chr = c.deptid_chr
                             inner join t_bse_bed d
                                on a.curbedid_chr = d.bedid_chr
                             inner join t_aid_recipefreq e
                                on a.execfreqid_chr = e.freqid_chr
                              left join t_bse_employee f
                                on a.checkoperid = f.empid_chr
                              left join t_curemedsubtract g
                                   on a.orderid_chr = g.orderid
                              left join t_bse_medicine n
                                   on g.medid = n.medicineid_chr
                             where (a.postdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                               and a.curedays > 0 
                               and a.checkdate is not null  ";

                if (!string.IsNullOrEmpty(deptStr))
                {
                    strSQL += " and a.curareaid_chr in (" + deptStr + ")";
                }

                if (!string.IsNullOrEmpty(medName))
                {
                    strSQL += " and n.medicinename_vchr like '%" + medName + "%'";
                }

                strSQL += "order by c.deptname_vchr ";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 科室用药汇总
        /// <summary>
        /// 疗程用药汇总
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="deptStr"></param>
        /// <param name="orderStatus"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetKsMedStatment(string dteStart, string dteEnd, string deptStr, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();
                string strSQL = @"select a.createdate_dat,
                                       c.deptid_chr as deptId,
                                       c.deptname_vchr as deptName,
                                       g.medicineid_chr as medid,
                                       g.assistcode_chr,
                                       e.NAME_CHR DicName,
                                       f.packqty_dec,
                                       g.mednormalname_vchr,
                                       a.spec_vchr as medspec_vchr,
                                       a.get_dec  as medMount,
                                       a.getunit_chr,
                                       g.unitprice_mny
                                  from t_opr_bih_order    a
                                       left join t_bse_bih_orderdic e
                                       on a.orderdicid_chr = e.orderdicid_chr
                                       left join t_bse_chargeitem   f
                                       on e.itemid_chr = f.itemid_chr
                                       left join t_bse_medicine     g
                                       on f.ITEMSRCID_VCHR = g.medicineid_chr
                                       inner join t_bse_deptdesc c
                                       on a.curareaid_chr = c.deptid_chr
                                 where a.STATUS_INT <> -2
                                   and a.ratetype_int = 2
                                   and (a.postdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                if (!string.IsNullOrEmpty(deptStr))
                {
                    strSQL += " and a.curareaid_chr in (" + deptStr + ")";
                }

                strSQL += "order by c.deptname_vchr ";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 科室用药
        /// <summary>
        /// 疗程用药
        /// </summary>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="deptStr"></param>
        /// <param name="orderStatus"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetKsMed(string dteStart, string dteEnd, string deptStr, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            clsHRPTableService objHRPServ = null;
            IDataParameter[] parm = null;

            try
            {
                objHRPServ = new clsHRPTableService();

                string strSQL = @"select a.createdate_dat,
                                   a.registerid_chr as registerid,
                                   c.deptid_chr as deptId,
                                   c.deptname_vchr as deptName,
                                   (case a.status_int
                                     when -2 then
                                      '删除'
                                     when -1 then
                                      '作废'
                                     when 0 then
                                      '创建'
                                     when 1 then
                                      '提交'
                                     when 2 then
                                      '执行'
                                     when 3 then
                                      '停止'
                                     when 4 then
                                      '重整'
                                     when 5 then
                                      '审核提交'
                                     when 6 then
                                      '审核停止'
                                     when 7 then
                                      '退回'
                                   end) as orderStatus,
                                   b.inpatientid_chr as inpatientid,
                                   b.lastname_vchr as patName,
                                   g.medicineid_chr,
                                   g.assistcode_chr,
                                   e.NAME_CHR DicName,
                                   f.packqty_dec,
                                   a.postdate_dat  as ordertime,
                                   a.dosetypename_chr as usageName,
                                   h.freqname_chr as freqName,
                                   g.mednormalname_vchr,
                                   a.spec_vchr,
                                   a.get_dec as medMount,
                                   a.getunit_chr  as unit,
                                   g.unitprice_mny,
                                   f.lastname_vchr as postdoct
                              from t_opr_bih_order a
                             inner join t_bse_patient b
                                on a.patientid_chr = b.patientid_chr
                              left join t_bse_bih_orderdic e
                                on a.orderdicid_chr = e.orderdicid_chr
                              left join t_bse_chargeitem f
                                on e.itemid_chr = f.itemid_chr
                              left join t_bse_medicine g
                                on f.ITEMSRCID_VCHR = g.medicineid_chr
                             inner join t_bse_deptdesc c
                                on a.curareaid_chr = c.deptid_chr
                              left join t_bse_employee f
                                on a.posterid_chr = f.empid_chr
                                inner join t_aid_recipefreq h
                                on a.execfreqid_chr = h.freqid_chr
                                     where a.STATUS_INT <> -2
                                       and a.ratetype_int = 2
                                       and (a.postdate_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')) ";

                if (!string.IsNullOrEmpty(deptStr))
                {
                    strSQL += " and a.curareaid_chr in (" + deptStr + ")";
                }

                strSQL += "order by c.deptname_vchr ";

                objHRPServ.CreateDatabaseParameter(2, out parm);
                parm[0].Value = dteStart + " 00:00:00";
                parm[1].Value = dteEnd + " 23:59:59";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, parm);

                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }

            return lngRes;
        }
        #endregion

        #region 病区科室
        /// <summary>
        /// 病区科室
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetArea(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = string.Empty;

            SQL = @"select deptid_chr,
                           deptname_vchr,
                           code_vchr,
                           PYCode_Chr,
                           CODE_VCHR
                      from T_BSE_DeptDesc
                     where ATTRIBUTEID = '0000003'
                       and Status_Int = 1
                     ORDER BY deptid_chr ";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 调价报表
        /// <summary>
        /// 调价报表
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="dtItem"></param>
        /// <param name="dtCharge"></param>
        [AutoComplete]
        public void GetAdjustPrice(string beginDate, string endDate, string effectDate, out DataTable dtItem, out DataTable dtCharge)
        {
            dtItem = new DataTable();
            dtCharge = new DataTable();
            string subStr = string.Empty;
            string Sql = string.Empty;
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select a.itemid_chr as itemid,
                               to_char(a.effect_dat,'yyyy-mm-dd hh24:mi:ss') as begindate,
                               '' as enddate,
                               a.preprice_mny as preprice,
                               a.curprice_mny as curprice,
                               --nvl(a.itemscope, 0) as itemscope
                               b.ischildprice
                          from t_opr_chargeitempricehis a
                          left join t_bse_chargeitem b 
                          on a.itemid_chr = b.itemid_chr
                         where ((a.effect_dat > to_date(?, 'yyyy-mm-dd hh24:mi:ss') ) )
                         order by a.itemid_chr";

                subStr = @"select a.itemid_chr as itemid
                          from t_opr_chargeitempricehis a
                          left join t_bse_chargeitem b 
                          on a.itemid_chr = b.itemid_chr
                         where ((a.effect_dat > to_date(?, 'yyyy-mm-dd hh24:mi:ss') ) )";

                #region
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = effectDate;
                svc.lngGetDataTableWithParameters(Sql, ref dtItem, parm);

                if (dtItem != null && dtItem.Rows.Count > 0)
                {
                    #region set value
                    string itemIdArr = string.Empty;
                    List<string> lstItemId = new List<string>();
                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        if (i + 1 < dtItem.Rows.Count)
                        {
                            if (dtItem.Rows[i]["itemid"].ToString() == dtItem.Rows[i + 1]["itemid"].ToString())
                            {
                                dtItem.Rows[i]["enddate"] = dtItem.Rows[i + 1]["begindate"];
                            }
                            else
                            {
                                dtItem.Rows[i]["enddate"] = endDate;
                            }
                        }
                        else
                        {
                            if (dtItem.Rows[i]["itemid"].ToString() == dtItem.Rows[i - 1]["itemid"].ToString())
                            {
                                dtItem.Rows[i]["enddate"] = dtItem.Rows[i - 1]["begindate"];
                            }
                            else
                            {
                                dtItem.Rows[i]["enddate"] = endDate;
                            }
                        }
                    }
                    #endregion
                }
                #endregion

                #region 门诊费用

                Sql = @"select a.itemid_chr as itemid,
                               p.patientid_chr,
                               p.birth_dat,
                               nvl(a.qty_dec, 0) as qty,
                               nvl(a.price_mny, 0) as price,
                               to_char(c.recorddate_dat, 'yyyy-mm-dd hh24:mi:ss') as recdate,
                               nvl(c.deptname_chr, '') as deptname,
                               b.itemcatid_chr as catid,
                               nvl(d.typename_vchr, '') as calctypename,
                               nvl(m.medicinetypeid_chr, '0') as medtypeid,
                               b.ischildprice,
                               1 as opip
                          from t_opr_oprecipeitemde a
                         inner join t_bse_chargeitem b
                            on a.itemid_chr = b.itemid_chr
                         inner join t_opr_outpatientrecipeinv c
                            on a.outpatrecipeid_chr = c.outpatrecipeid_chr
                          left join t_bse_chargeitemextype d
                            on b.itemopcalctype_chr = d.typeid_chr
                           and d.flag_int = 1
                          left join t_bse_medicine m
                            on b.itemsrcid_vchr = m.medicineid_chr
                          left join t_bse_patient p
                            on c.patientid_chr = p.patientid_chr
                         where a.itemid_chr in ({0})
                           and (c.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))  ";

                Sql = string.Format(Sql, subStr);
                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = effectDate;
                parm[1].Value = beginDate;
                parm[2].Value = endDate;

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dtCharge == null) dtCharge = dt.Clone();
                    dtCharge.Merge(dt);
                    dtCharge.AcceptChanges();
                }
                #endregion

                #region 住院费用

                Sql = @"select a.chargeitemid_chr as itemid,
                               p.patientid_chr,
                               p.birth_dat,
                               nvl(a.amount_dec, 0) as qty,
                               nvl(a.unitprice_dec, 0) as price,
                               to_char(a.chargeactive_dat, 'yyyy-mm-dd hh24:mi:ss') as recdate,
                               nvl(d.deptname_vchr, '') as deptname,
                               b.itemcatid_chr as catid,
                               nvl(c.typename_vchr, '') as calctypename,
                               nvl(m.medicinetypeid_chr, '0') as medtypeid,
                               b.ischildprice,
                               2 as opip
                          from t_opr_bih_patientcharge a
                         inner join t_bse_chargeitem b
                            on a.chargeitemid_chr = b.itemid_chr
                          left join t_bse_chargeitemextype c
                            on b.itemipcalctype_chr = c.typeid_chr
                           and c.flag_int = 3
                          left join t_bse_medicine m
                            on b.itemsrcid_vchr = m.medicineid_chr
                          left join t_bse_deptdesc d
                            on a.clacarea_chr = d.deptid_chr
                          left join t_bse_patient p
                            on a.patientid_chr = p.patientid_chr
                         where a.status_int = 1
                           and a.pstatus_int > 0
                           and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                           and a.chargeitemid_chr in ({0})  ";




                Sql = string.Format(Sql, subStr);
                svc.CreateDatabaseParameter(3, out parm);
                parm[0].Value = beginDate;
                parm[1].Value = endDate;
                parm[2].Value = effectDate;

                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dtCharge == null) dtCharge = dt.Clone();
                    dtCharge.Merge(dt);
                    dtCharge.AcceptChanges();
                }
                #endregion
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
                parm = null;
            }
        }
        #endregion

        #region 保存.调价报表数据
        /// <summary>
        /// 保存.调价报表数据
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long SaveAdjustPrice(DataTable dt)
        {
            long res = -1;
            string Sql = string.Empty;
            clsHRPTableService svc = new clsHRPTableService();

            try
            {
                Sql = "delete from t_rpt_adjustprice";
                svc.DoExcute(Sql);

                Sql = @"insert into t_rpt_adjustprice
                          (feeClass, feeNum, feeSum, deptName, deptNum, deptSum)
                        values
                          (?, ?, ?, ?, ?, ?)";

                DbType[] dbTypes = new DbType[] { DbType.String, DbType.Decimal, DbType.Decimal, DbType.String, DbType.Decimal, DbType.Decimal };
                object[][] objValues = new object[6][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[dt.Rows.Count];
                }
                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    objValues[0][i] = dr["feeClass"].ToString();
                    objValues[1][i] = Convert.ToDecimal(dr["feeNum"]);
                    objValues[2][i] = Convert.ToDecimal(dr["feeSum"]);
                    objValues[3][i] = dr["deptName"].ToString();
                    objValues[4][i] = Convert.ToDecimal(dr["deptNum"]);
                    objValues[5][i] = Convert.ToDecimal(dr["deptSum"]);
                }
                svc.m_lngSaveArrayWithParametersWithAffected(Sql, objValues, ref res, dbTypes);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                svc = null;
            }
            return res;
        }
        #endregion
    }
}
