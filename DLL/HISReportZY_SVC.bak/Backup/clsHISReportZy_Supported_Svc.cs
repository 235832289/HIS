using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.Utility;//Utility.dll

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
                               a.recorddate,
                               b.deptname_vchr   as appdeptname,
                               a.responsedate,
                               a.doctadvicemsg,
                               a.doctadvicedate,
                               a.status
                          from icare.t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                         where (a.recorddate between ? and ?)
                           and (a.status = 0 or a.status = 1)
                           and a.applytypeid = 1 
                        union all
                        select a.cvmid,
                               a.recorddate,
                               b.deptname_vchr as appdeptname,
                               a.responsedate,
                               a.doctadvicemsg,
                               a.doctadvicedate,
                               a.status
                          from icare.t_criticalvalue_main a
                          left join t_bse_deptdesc b
                            on a.applydeptid = b.deptid_chr
                         where (a.recorddate between ?  and ? )
                           and (a.status = 0 or a.status = 1)
                           and a.applytypeid = 2 ";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                parm[2].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[3].Value = Convert.ToDateTime(endDate + " 23:59:59");
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
                        where (a.recorddate between ? and ?)
                        and a.applytypeid = 1 
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
                        where (a.recorddate between ? and ?)
                        and a.applytypeid = 2) order by checkitemname";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                parm[2].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[3].Value = Convert.ToDateTime(endDate + " 23:59:59");
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
                              a.responsedate,
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
                              a.recorddate,
                              a.pattypeid,
                              a.cardno,
                              responsemsg,
                              lis.checkitemid,
                              lis.unit,
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
                              left join icare.t_criticalvalue_lis lis
                              on a.cvmid = lis.cvmid
                              where (a.recorddate between ? and ?)
                              and (a.status = 0 or a.status = 1)    
                              {0}
                              and a.applytypeid = 1 
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
                            where (a.recorddate between ?  and ? )
                            and (a.status = 0 or a.status = 1)
                            {1}
                            and a.applytypeid = 2 ) order by responsedate";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                parm[2].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[3].Value = Convert.ToDateTime(endDate + " 23:59:59");

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and b.code_vchr in " + deptStr;

                Sql = string.Format(Sql,  deptStr,deptStr);

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
                              a.recorddate,
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
                              where (a.recorddate between ? and ?)
                              and (a.status = 0 or a.status = 1)
                              {0}    
                              and a.applytypeid = 1 
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
                              where (a.recorddate between ? and ? )
                              and (a.status = 0 or a.status = 1)
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

                Sql = string.Format(Sql,  deptStr,deptStr);

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
                Sql = @"select * from (select a.cvmid,
                              a.recorddate,
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
                              where (a.recorddate between ? and ? )
                              and (a.status = 0 or a.status = 1) 
                              {0}
                              and a.applytypeid = 1 
                       union all
                       select a.cvmid,
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
                              where (a.recorddate between ? and ? )
                              and (a.status = 0 or a.status = 1)
                              {0}
                              and a.applytypeid = 2 ) order by checkitemname";

                svc.CreateDatabaseParameter(4, out parm);
                parm[0].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[1].Value = Convert.ToDateTime(endDate + " 23:59:59");
                parm[2].Value = Convert.ToDateTime(beginDate + " 00:00:00");
                parm[3].Value = Convert.ToDateTime(endDate + " 23:59:59");

                if (deptStr == null)
                    deptStr = "";
                else
                    deptStr = "and e.code_vchr in " + deptStr;

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
                              on a.applydeptid = b.deptid_chr
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
                              on a.applydeptid = b.deptid_chr
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

        #region 获取科室信息
        /// <summary>
        /// GetDeptList
        /// </summary>
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
                           and ((inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
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
    }
}
