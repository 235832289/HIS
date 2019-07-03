using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.HIS;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// clsReportQuerySupportSvc
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsReportQuerySupportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 门诊医生绩效统计报表
        /// <summary>
        /// 门诊医生绩效统计报表
        /// </summary>
        /// <param name="p_beginDate"></param>
        /// <param name="p_endDate"></param>
        /// <param name="p_strStatType"></param>
        /// <param name="p_strDoctorID"></param>
        /// <param name="DeptIDArr">科室ID，数组</param>
        /// <param name="intFlag">标识，0按医生统计，1按科室统计</param>
        /// <param name="dtResult">返回datatable</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRptDoctorPerformance(string p_beginDate, string p_endDate, string p_strStatType, string p_strDoctorID, ArrayList DeptIDArr, int intFlag, ref DataTable dtResult)
        {
            long lngRes = 0;
            p_beginDate += " 00:00:00";
            p_endDate += " 23:59:59";

            string strSQL = string.Empty;
            string strSQLSub = string.Empty;
            string strsqlsub = string.Empty;
            //            string strSQLSub1 = string.Empty;
            //            string strSQL0 = @"select parmvalue_vchr
            //                                  from t_bse_sysparm t
            //                                 where t.parmcode_chr = '3069'
            //                                   and t.status_int = 1";
            //try
            //{
            //    clsHRPTableService objSvc = new clsHRPTableService();
            //    DataTable dtTemp = new DataTable();
            //    long l = objSvc.lngGetDataTableWithoutParameters(strSQL0, ref dtTemp);
            //    if (l > 0 && dtTemp.Rows.Count > 0)
            //    {
            //        string strValue = dtTemp.Rows[0][0].ToString();
            //        string[] Val = strValue.Split('*');
            //        strValue = string.Empty;
            //        for (int k = 0; k < Val.Length; k++)
            //        {
            //            strValue = "'" + Val[k] + "',";
            //        }
            //        strSQLSub1 = @"and d.INSURANCETYPE_VCHR in (" + strValue.Substring(0, strValue.Length) + ")";
            //    }
            //}
            //catch (Exception objEx)
            //{
            //    clsLogText objLog = new clsLogText();
            //    objLog.LogError(objEx);
            //}

            DataTable dtT1 = new DataTable();
            DataTable dtT2 = new DataTable();
            DataTable dtT3 = new DataTable();
            DataTable dtT4 = new DataTable();
            DataTable dtT9 = new DataTable();
            DataTable dtT10 = new DataTable();
            DataTable dtT11 = new DataTable();
            DataTable dtT21 = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (intFlag == 0)//按医生
            {
                #region T1
                string strSQLT1 = @"select mm.typeid_chr,
       mm.typename_vchr,
       mm.doctorid_chr,
       mm.empno_chr,
       mm.lastname_vchr,
       mm.code_vchr,
       mm.deptname_vchr,
       (mm.tolfee_mny +  nvl(tt.diffSum,0)) tolfee_mny,
       mm.jxywl,
       tt.diffSum
  from (select g.typeid_chr,
                                           g.typename_vchr,
                                           a.doctorid_chr, 
                                           e.empno_chr, 
                                           e.lastname_vchr,
                                           e.code_vchr,
                                           e.deptname_vchr,
                                           sum (b.tolfee_mny) tolfee_mny,
                                           sum(b.tolfee_mny*f.percentage) jxywl
                                      from t_opr_outpatientrecipeinv a,
                                           t_opr_outpatientrecipesumde b,
                                           (select e.empid_chr,
                                                       e.empno_chr,
                                                       e.lastname_vchr,
                                                       r.deptid_chr,
                                                       d.code_vchr,
                                                       d.deptname_vchr
                                                  from t_bse_employee e,
                                                       t_bse_deptemp r,
                                                       t_bse_deptdesc d
                                                 where r.deptid_chr = d.deptid_chr
                                                   and e.empid_chr = r.empid_chr
                                                   and r.default_dept_int = 1
                                                union all
                                                select e2.empid_chr,
                                                       e2.empno_chr,
                                                       e2.lastname_vchr,
                                                       '' deptid_chr,
                                                       '' code_vchr,
                                                       '' deptname_vchr
                                                  from t_bse_employee e2
                                                 where not exists (select ''
                                                          from t_bse_deptemp r2
                                                         where r2.empid_chr = e2.empid_chr
                                                           and r2.default_dept_int = 1)) e,
                                             t_opr_drachformula  f,
                                             t_bse_chargeitemextype g
                                     where a.seqid_chr = b.seqid_chr(+)
                                       and b.itemcatid_chr = g.typeid_chr
                                       and b.itemcatid_chr = f.typeid_chr(+)
                                       and g.flag_int = 1
                                       and a.doctorid_chr = e.empid_chr
                                       and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                       {0}
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                       group by g.typeid_chr,
                                                g.typename_vchr,
                                                a.doctorid_chr, 
                                                e.empno_chr, 
                                                e.lastname_vchr,
                                                e.code_vchr,
                                                e.deptname_vchr) mm,
       
       (select ss.itcatid,
       ss.doctorid_chr,
       ss.empno_chr,
       ss.lastname_vchr,
       ss.code_vchr,
       ss.deptname_vchr,
       sum(ss.diffSum) diffSum
  from (select '1003' itcatid,
               m.doctorid_chr,
               e.empno_chr,
               e.lastname_vchr,
               e.code_vchr,
               e.deptname_vchr,
               sum(decode(m.STATUS_INT,
                          0,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          2,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          nvl(n.toldiffprice_mny, 0))) diffSum
          from t_opr_outpatientrecipeinv m,
               t_opr_outpatientpwmrecipede n,
               (select e.empid_chr,
                       e.empno_chr,
                       e.lastname_vchr,
                       r.deptid_chr,
                       d.code_vchr,
                       d.deptname_vchr
                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                 where r.deptid_chr = d.deptid_chr
                   and e.empid_chr = r.empid_chr
                   and r.default_dept_int = 1
                union all
                select e2.empid_chr,
                       e2.empno_chr,
                       e2.lastname_vchr,
                       '' deptid_chr,
                       '' code_vchr,
                       '' deptname_vchr
                  from t_bse_employee e2
                 where not exists (select ''
                          from t_bse_deptemp r2
                         where r2.empid_chr = e2.empid_chr
                           and r2.default_dept_int = 1)) e
         where m.outpatrecipeid_chr = n.outpatrecipeid_chr
           and m.doctorid_chr = e.empid_chr
           and( m.isvouchers_int <> 2 or m.isvouchers_int is null)
           {1}
           and m.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
           and m.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
         group by m.outpatrecipeid_chr,
                  e.empno_chr,
                  e.lastname_vchr,
                  e.code_vchr,
                  e.deptname_vchr,
                  m.doctorid_chr
        union all
        select '1006' itcatid,
               m.doctorid_chr,
               e.empno_chr,
               e.lastname_vchr,
               e.code_vchr,
               e.deptname_vchr,
               sum(decode(m.status_int,
                          0,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          2,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          nvl(n.toldiffprice_mny, 0))) diffSum
          from t_opr_outpatientrecipeinv m,
               t_opr_outpatientcmrecipede n,
               (select e.empid_chr,
                       e.empno_chr,
                       e.lastname_vchr,
                       r.deptid_chr,
                       d.code_vchr,
                       d.deptname_vchr
                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                 where r.deptid_chr = d.deptid_chr
                   and e.empid_chr = r.empid_chr
                   and r.default_dept_int = 1
                union all
                select e2.empid_chr,
                       e2.empno_chr,
                       e2.lastname_vchr,
                       '' deptid_chr,
                       '' code_vchr,
                       '' deptname_vchr
                  from t_bse_employee e2
                 where not exists (select ''
                          from t_bse_deptemp r2
                         where r2.empid_chr = e2.empid_chr
                           and r2.default_dept_int = 1)) e
         where m.outpatrecipeid_chr = n.outpatrecipeid_chr
           and m.doctorid_chr = e.empid_chr
            {2}
           and( m.isvouchers_int <> 2 or m.isvouchers_int is null)
           and m.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
           and m.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
         group by m.outpatrecipeid_chr,
                  m.doctorid_chr,
                  e.empno_chr,
                  e.lastname_vchr,
                  e.code_vchr,
                  e.deptname_vchr) ss
                  group by ss.itcatid,
       ss.doctorid_chr,
       ss.empno_chr,
       ss.lastname_vchr,
       ss.code_vchr,
       ss.deptname_vchr) tt
 where mm.typeid_chr = tt.itcatid(+)
      and mm.doctorid_chr = tt.doctorid_chr(+)
      and mm.code_vchr = tt.code_vchr(+)";

                if (p_strDoctorID != string.Empty)
                {
                    strSQLSub = @"and a.doctorid_chr in (" + p_strDoctorID + ")";
                    strsqlsub = @"and m.doctorid_chr in (" + p_strDoctorID + ")";
                }
                strSQLT1 = string.Format(strSQLT1, strSQLSub, strsqlsub, strsqlsub);
                if (p_strStatType == "1")
                {
                    strSQLT1 = strSQLT1.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT1, ref dtT1);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T1表异常：" + e.Message);
                }
                #endregion

                #region T2
                string strSQLT2 = @"select   a.doctorid_chr,
                                             sum (case a.status_int
                                                       when 1
                                                          then 1
                                                       when 3
                                                          then 1
                                                       when 2
                                                          then -1
                                                    end
                                                   ) as zfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and a.balanceflag_int = 1
                                         and c.recipeflag_int = 1
                                         and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                         and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                         and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                         group by a.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT2 = strSQLT2.Replace("recorddate_dat", "balance_dat");
                }
                else
                {
                    strSQLT2 = strSQLT2.Replace("and a.balanceflag_int = 1", "");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT2, ref dtT2);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T2表异常：" + e.Message);
                }
                #endregion

                #region T21
                string strSQLT21 = string.Empty;

                strSQLT21 = @"select a.doctorid_chr,
                                       sum(case a.status_int
                                             when 1 then
                                              1
                                             when 3 then
                                              1
                                             when 2 then
                                              -1
                                           end) as kjrs 
                                  from t_opr_outpatientrecipeinv a,
                                       t_opr_reciperelation      b,
                                       t_opr_outpatientrecipe    c
                                 where a.outpatrecipeid_chr = b.seqid
                                   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                   and a.balanceflag_int = 1
                                   and c.recipeflag_int = 1
                                   and (a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                   and exists
                                 (select 1
                                          from t_opr_oprecipeitemde t1,
                                               t_bse_chargeitem     t2,
                                               t_bse_medicine       t3
                                         where c.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                           and t1.itemid_chr = t2.itemid_chr
                                           and t2.itemsrcid_vchr = t3.medicineid_chr
                                           and t3.medicinetypeid_chr = 2
                                           and t3.pharmaid_chr in ('00001', '00005', '00006', '00013'))
                                   and (a.recorddate_dat between timestamp'{0}' and timestamp'{1}')
                                   and (a.recorddate_dat between to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))
                                 group by a.doctorid_chr";

                object[] objs = new object[4] { p_beginDate, p_endDate, p_beginDate, p_endDate };
                strSQLT21 = string.Format(strSQLT21, objs);

                if (p_strStatType == "1")
                {
                    strSQLT21 = strSQLT21.Replace("recorddate_dat", "balance_dat");
                }
                else
                {
                    strSQLT21 = strSQLT21.Replace("and a.balanceflag_int = 1", "");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT21, ref dtT21);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T21表异常：" + e.Message);
                }
                #endregion

                #region T3
                string strSQLT3 = @"select   a.doctorid_chr,
                                             sum (case a.status_int
                                                       when 1
                                                          then 1
                                                       when 3
                                                          then 1
                                                       when 2
                                                          then -1
                                                   end
                                                  ) as cfs
                                        from t_opr_outpatientrecipeinv a,
                                             t_opr_reciperelation b,
                                             t_opr_outpatientrecipe c
                                       where a.outpatrecipeid_chr = b.seqid
                                         and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                         and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                         and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                         and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                         group by a.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT3 = strSQLT3.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT3, ref dtT3);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T3表异常：" + e.Message);
                }
                #endregion

                #region T4
                string strSQLT4 = @"select t5.diagdr_chr,
                                           t5.tolprice_mny,
                                           t6.xytolprice_mny,
                                           round((t5.tolprice_mny / t6.xytolprice_mny) * 100, 2) as kjybl,
                                           round((t5.kjcfs / t6.zcfs)*100, 2) as kjcfbl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny + decode(d.opchargeflg_int,
                      0,
                      cc.tradeprice_mny - cc.itemprice_mny,
                      1,
                      round((cc.tradeprice_mny - cc.itemprice_mny) /
                            d.packqty_dec,
                            4))* bb.qty_dec) tolprice_mny,
                                                   sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                         end
                                                        ) as kjcfs
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and d.pharmaid_chr in ('00001', '00005', '00006', '00013')
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t5,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                    sum(bb.tolprice_mny +
                                                       decode(d.opchargeflg_int,
                                                              0,
                                                              cc.tradeprice_mny - cc.itemprice_mny,
                                                              1,
                                                              round((cc.tradeprice_mny - cc.itemprice_mny) /
                                                                    d.packqty_dec,
                                                                    4))* bb.qty_dec) xytolprice_mny,
                                                   sum (case a.status_int
                                                             when 1
                                                                then 1
                                                             when 3
                                                                then 1
                                                             when 2
                                                                then -1
                                                         end
                                                        ) as zcfs
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                               group by g.lastname_vchr, c.diagdr_chr) t6
                                     where t5.diagdr_chr = t6.diagdr_chr
                                     group by t5.diagdr_chr, t5.tolprice_mny, t6.xytolprice_mny, t6.zcfs, t5.kjcfs";

                if (p_strStatType == "1")
                {
                    strSQLT4 = strSQLT4.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT4, ref dtT4);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T4表异常：" + e.Message);
                }
                #endregion

                #region T9
                string strSQLT9 = @"select t7.diagdr_chr,
                                           t7.tolprice_mny as tolprice_jby,
                                           t8.xytolprice_mny as xytolprice_jby,
                                           round((t7.tolprice_mny / t8.xytolprice_mny) * 100, 2) as jbybl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny + decode(d.opchargeflg_int,
                      0,
                      cc.tradeprice_mny - cc.itemprice_mny,
                      1,
                      round((cc.tradeprice_mny - cc.itemprice_mny) /
                            d.packqty_dec,
                            4))* bb.qty_dec) tolprice_mny
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and d.insurancetype_vchr in ('1006', '1007', '1008')
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t7,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny +
                   decode(d.opchargeflg_int,
                          0,
                          cc.tradeprice_mny - cc.itemprice_mny,
                          1,
                          round((cc.tradeprice_mny - cc.itemprice_mny) /
                                d.packqty_dec,
                                4))* bb.qty_dec) xytolprice_mny
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t8
                                     where t7.diagdr_chr = t8.diagdr_chr
                                     group by t7.diagdr_chr, t7.tolprice_mny, t8.xytolprice_mny";

                if (p_strStatType == "1")
                {
                    strSQLT9 = strSQLT9.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT9, ref dtT9);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T9表异常：" + e.Message);
                }
                #endregion

                #region T10
                string strSQLT10 = @"select m.doctorid_chr, count(m.outpatrecipeid_chr) Counts_KJY
  from (select n.doctorid_chr, n.outpatrecipeid_chr,sum(n.status) as statussum
  from (select b.doctorid_chr, t.outpatrecipeid_chr,decode(b.status_int,0,-1,2,-1,1) as status
          from t_opr_outpatientpwmrecipede t,
               t_opr_reciperelation        a,
               t_opr_outpatientrecipeinv   b,
               t_bse_medicine              c,
               t_bse_chargeitem            e
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr
           and a.seqid = b.outpatrecipeid_chr
           and t.itemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.pharmaid_chr in ('00001', '00005', '00006', '00013') ---抗菌药分类  
           and( b.isvouchers_int <> 2 or b.isvouchers_int is null)
           and b.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
           and b.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')) n
               group by n.doctorid_chr, n.outpatrecipeid_chr) m
                       where m.statussum<>0
 group by m.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT10 = strSQLT10.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT10, ref dtT10);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T10表异常：" + e.Message);
                }
                #endregion

                #region T11
                string strSQLT11 = @"select tab1.doctorid_chr,
                                            sum(case tab1.status_int
                                                     when 1 then
                                                      1
                                                     when 3 then
                                                      1
                                                     when 2 then
                                                      -1
                                                 end
                                                )as xycfs
                                      from (select distinct a.outpatrecipeid_chr,
                                                            a.status_int,
                                                            a.doctorid_chr
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation      b,
                                                   t_opr_outpatientrecipe    c,
                                                   t_opr_outpatientpwmrecipede t,
                                                   t_bse_chargeitem            e,
                                                   t_bse_medicine              m
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and t.outpatrecipeid_chr = b.outpatrecipeid_chr
                                               and t.itemid_chr = e.itemid_chr
                                               and e.itemsrcid_vchr = m.medicineid_chr
                                               and m.medicinetypeid_chr = '2'
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             ) tab1
                                      group by tab1.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT11 = strSQLT11.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT11, ref dtT11);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T11表异常：" + e.Message);
                }
                #endregion

                #region 数据合并处理整合为和原查询语句得到的datatable相同

                string[] strDtT2JoinColArr = new string[] { "zfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT2, "doctorid_chr", "doctorid_chr", strDtT2JoinColArr);

                string[] strDtT21JoinColArr = new string[] { "kjrs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT21, "doctorid_chr", "doctorid_chr", strDtT21JoinColArr);

                string[] strDtT3JoinColArr = new string[] { "cfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT3, "doctorid_chr", "doctorid_chr", strDtT3JoinColArr);

                string[] strDtT4JoinColArr = new string[] { "kjybl", "tolprice_mny", "xytolprice_mny" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT4, "doctorid_chr", "diagdr_chr", strDtT4JoinColArr);

                string[] strDtT9JoinColArr = new string[] { "jbybl", "tolprice_jby", "xytolprice_jby" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT9, "doctorid_chr", "diagdr_chr", strDtT9JoinColArr);

                string[] strDtT10JoinColArr = new string[] { "Counts_KJY" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT10, "doctorid_chr", "doctorid_chr", strDtT10JoinColArr);

                string[] strDtT11JoinColArr = new string[] { "xycfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT11, "doctorid_chr", "doctorid_chr", strDtT11JoinColArr);

                DataView dvJoinResult = dtT1.DefaultView;
                dvJoinResult.Sort = "empno_chr, lastname_vchr, typeid_chr, typename_vchr, zfs, kjrs, cfs, code_vchr, deptname_vchr, tolprice_mny, xytolprice_mny, kjybl, counts_kjy, xycfs, jbybl";
                DataTable dtFinalResult = dvJoinResult.ToTable();

                for (int i = 0; i < dtFinalResult.Rows.Count - 1; i++)
                {
                    DataRow drFirst = dtFinalResult.Rows[i];
                    DataRow drSecond = dtFinalResult.Rows[i + 1];

                    if (drFirst["empno_chr"] == drSecond["empno_chr"] && drFirst["lastname_vchr"] == drSecond["lastname_vchr"] && drFirst["typeid_chr"] == drSecond["typeid_chr"])
                    {
                        if (drFirst["typename_vchr"] == drSecond["typename_vchr"] && drFirst["zfs"] == drSecond["zfs"] && drFirst["kjrs"] == drSecond["kjrs"] && drFirst["cfs"] == drSecond["cfs"] && drFirst["xytolprice_mnyc"] == drSecond["xytolprice_mnyc"])
                        {
                            if (drFirst["code_vchr"] == drSecond["code_vchr"] && drFirst["deptname_vchr"] == drSecond["deptname_vchr"] && drFirst["tolprice_mny"] == drSecond["tolprice_mny"] && drFirst["tolprice_jby"] == drSecond["tolprice_jby"] && drFirst["xytolprice_jby"] == drSecond["xytolprice_jby"])
                            {
                                if (drFirst["kjybl"] == drSecond["kjybl"] && drFirst["counts_kjy"] == drSecond["counts_kjy"] && drFirst["xycfs"] == drSecond["xycfs"] && drFirst["jbybl"] == drSecond["jbybl"])
                                {
                                    if (dtFinalResult.Rows[i]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["tolfee_jby"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_jby"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["jxywl"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_jby"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_jby"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["jxywl"] = 0;
                                    }
                                    dtFinalResult.Rows[i]["tolfee_mny"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_mny"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_mny"]);
                                    dtFinalResult.Rows[i]["tolfee_jby"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_jby"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_jby"]);
                                    dtFinalResult.Rows[i]["jxywl"] = Convert.ToDecimal(dtFinalResult.Rows[i]["jxywl"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["jxywl"]);
                                    dtFinalResult.Rows.Remove(drSecond);
                                    dtFinalResult.AcceptChanges();
                                    i = i - 1;
                                }
                            }
                        }
                    }
                }

                dtResult.Columns.Add("typeid_chr", typeof(string));
                dtResult.Columns.Add("typename_vchr", typeof(string));
                dtResult.Columns.Add("empno_chr", typeof(string));
                dtResult.Columns.Add("lastname_vchr", typeof(string));
                dtResult.Columns.Add("zfs", typeof(int));
                dtResult.Columns.Add("kjrs", typeof(int));
                dtResult.Columns.Add("cfs", typeof(int));
                dtResult.Columns.Add("code_vchr", typeof(string));
                dtResult.Columns.Add("deptname_vchr", typeof(string));
                dtResult.Columns.Add("tolfee_mny", typeof(decimal));
                dtResult.Columns.Add("jxywl", typeof(decimal));
                dtResult.Columns.Add("kjybl", typeof(decimal));
                dtResult.Columns.Add("tolprice_mny", typeof(decimal));
                dtResult.Columns.Add("xytolprice_mny", typeof(decimal));
                dtResult.Columns.Add("kjcfbl", typeof(decimal));
                dtResult.Columns.Add("jbybl", typeof(decimal));
                dtResult.Columns.Add("tolprice_jby", typeof(decimal));
                dtResult.Columns.Add("xytolprice_jby", typeof(decimal));

                for (int i = 0; i < dtFinalResult.Rows.Count; i++)
                {
                    DataRow drResu = dtResult.NewRow();
                    drResu["typeid_chr"] = dtFinalResult.Rows[i]["typeid_chr"];
                    drResu["typename_vchr"] = dtFinalResult.Rows[i]["typename_vchr"];
                    drResu["empno_chr"] = dtFinalResult.Rows[i]["empno_chr"];
                    drResu["lastname_vchr"] = dtFinalResult.Rows[i]["lastname_vchr"];
                    drResu["zfs"] = dtFinalResult.Rows[i]["zfs"];
                    drResu["kjrs"] = dtFinalResult.Rows[i]["kjrs"];
                    drResu["cfs"] = dtFinalResult.Rows[i]["cfs"];
                    drResu["code_vchr"] = dtFinalResult.Rows[i]["code_vchr"];
                    drResu["deptname_vchr"] = dtFinalResult.Rows[i]["deptname_vchr"];
                    drResu["tolfee_mny"] = dtFinalResult.Rows[i]["tolfee_mny"];
                    drResu["jxywl"] = dtFinalResult.Rows[i]["jxywl"];
                    drResu["kjybl"] = dtFinalResult.Rows[i]["kjybl"];
                    drResu["tolprice_mny"] = dtFinalResult.Rows[i]["tolprice_mny"];
                    drResu["xytolprice_mny"] = dtFinalResult.Rows[i]["xytolprice_mny"];
                    drResu["jbybl"] = dtFinalResult.Rows[i]["jbybl"];
                    drResu["tolprice_jby"] = dtFinalResult.Rows[i]["tolprice_jby"];
                    drResu["xytolprice_jby"] = dtFinalResult.Rows[i]["xytolprice_jby"];
                    //if (dtFinalResult.Rows[i]["Counts_KJY"] != DBNull.Value && dtFinalResult.Rows[i]["xycfs"] != DBNull.Value)
                    //{
                    //    drResu["kjcfbl"] = Math.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["Counts_KJY"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["xycfs"])) * 100, 2);
                    //}
                    if (dtFinalResult.Rows[i]["kjrs"] != DBNull.Value && dtFinalResult.Rows[i]["zfs"] != DBNull.Value && Convert.ToInt32(dtFinalResult.Rows[i]["zfs"]) != 0)
                    {
                        drResu["kjcfbl"] = this.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["kjrs"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["zfs"])) * 100, 2);
                    }
                    dtResult.Rows.Add(drResu);
                }

                dtResult.AcceptChanges();
                #endregion
            }

            if (intFlag == 1)//按科室
            {
                #region T1
                string strSQLT1 = @"select mm.typeid_chr,
       mm.typename_vchr,
       mm.doctorid_chr,
       mm.empno_chr,
       mm.lastname_vchr,
       mm.code_vchr,
       mm.deptname_vchr,
       (mm.tolfee_mny +  nvl(tt.diffSum,0)) tolfee_mny,
       mm.jxywl,
       tt.diffSum
  from (select g.typeid_chr,
                                           g.typename_vchr,
                                           a.doctorid_chr,
                                           e.empno_chr,
                                           e.lastname_vchr,
                                           e.code_vchr,
                                           e.deptname_vchr,
                                           sum(b.tolfee_mny) tolfee_mny,
                                           sum(b.tolfee_mny * f.percentage) jxywl
                                      from t_opr_outpatientrecipeinv a,
                                           t_opr_outpatientrecipesumde b,
                                           (select e.empid_chr,
                                                   e.empno_chr,
                                                   e.lastname_vchr,
                                                   r.deptid_chr,
                                                   d.code_vchr,
                                                   d.deptname_vchr
                                              from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                                             where r.deptid_chr = d.deptid_chr
                                               and e.empid_chr = r.empid_chr
                                               and r.default_dept_int = 1
                                            union all
                                            select e2.empid_chr,
                                                   e2.empno_chr,
                                                   e2.lastname_vchr,
                                                   '' deptid_chr,
                                                   '' code_vchr,
                                                   '' deptname_vchr
                                              from t_bse_employee e2
                                             where not exists (select ''
                                                      from t_bse_deptemp r2
                                                     where r2.empid_chr = e2.empid_chr
                                                       and r2.default_dept_int = 1)) e,
                                           t_opr_drachformula f,
                                           t_bse_chargeitemextype g
                                     where a.seqid_chr = b.seqid_chr(+)
                                       and b.itemcatid_chr = g.typeid_chr
                                       and b.itemcatid_chr = f.typeid_chr(+)
                                       and g.flag_int = 1
                                       and a.doctorid_chr = e.empid_chr
                                        {0} 
                                       and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                     group by g.typeid_chr,
                                              g.typename_vchr,
                                              a.doctorid_chr,
                                              e.empno_chr,
                                              e.lastname_vchr,
                                              e.code_vchr,
                                              e.deptname_vchr) mm,
       
       (select ss.itcatid,
       ss.doctorid_chr,
       ss.empno_chr,
       ss.lastname_vchr,
       ss.code_vchr,
       ss.deptname_vchr,
       sum(ss.diffSum) diffSum
  from (select '1003' itcatid,
               m.doctorid_chr,
               e.empno_chr,
               e.lastname_vchr,
               e.code_vchr,
               e.deptname_vchr,
               sum(decode(m.STATUS_INT,
                          0,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          2,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          nvl(n.toldiffprice_mny, 0))) diffSum
          from t_opr_outpatientrecipeinv m,
               t_opr_outpatientpwmrecipede n,
               (select e.empid_chr,
                       e.empno_chr,
                       e.lastname_vchr,
                       r.deptid_chr,
                       d.code_vchr,
                       d.deptname_vchr
                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                 where r.deptid_chr = d.deptid_chr
                   and e.empid_chr = r.empid_chr
                   and r.default_dept_int = 1
                union all
                select e2.empid_chr,
                       e2.empno_chr,
                       e2.lastname_vchr,
                       '' deptid_chr,
                       '' code_vchr,
                       '' deptname_vchr
                  from t_bse_employee e2
                 where not exists (select ''
                          from t_bse_deptemp r2
                         where r2.empid_chr = e2.empid_chr
                           and r2.default_dept_int = 1)) e
         where m.outpatrecipeid_chr = n.outpatrecipeid_chr
           and m.doctorid_chr = e.empid_chr
            {1}
           and( m.isvouchers_int <> 2 or m.isvouchers_int is null)
           and m.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
           and m.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
         group by m.outpatrecipeid_chr,
                  e.empno_chr,
                  e.lastname_vchr,
                  e.code_vchr,
                  e.deptname_vchr,
                  m.doctorid_chr
        union all
        select '1006' itcatid,
               m.doctorid_chr,
               e.empno_chr,
               e.lastname_vchr,
               e.code_vchr,
               e.deptname_vchr,
               sum(decode(m.status_int,
                          0,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          2,
                          (-1) * nvl(n.toldiffprice_mny, 0),
                          nvl(n.toldiffprice_mny, 0))) diffSum
          from t_opr_outpatientrecipeinv m,
               t_opr_outpatientcmrecipede n,
               (select e.empid_chr,
                       e.empno_chr,
                       e.lastname_vchr,
                       r.deptid_chr,
                       d.code_vchr,
                       d.deptname_vchr
                  from t_bse_employee e, t_bse_deptemp r, t_bse_deptdesc d
                 where r.deptid_chr = d.deptid_chr
                   and e.empid_chr = r.empid_chr
                   and r.default_dept_int = 1
                union all
                select e2.empid_chr,
                       e2.empno_chr,
                       e2.lastname_vchr,
                       '' deptid_chr,
                       '' code_vchr,
                       '' deptname_vchr
                  from t_bse_employee e2
                 where not exists (select ''
                          from t_bse_deptemp r2
                         where r2.empid_chr = e2.empid_chr
                           and r2.default_dept_int = 1)) e
         where m.outpatrecipeid_chr = n.outpatrecipeid_chr
           and m.doctorid_chr = e.empid_chr
            {2}
           and( m.isvouchers_int <> 2 or m.isvouchers_int is null)
           and m.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
           and m.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
         group by m.outpatrecipeid_chr,
                  m.doctorid_chr,
                  e.empno_chr,
                  e.lastname_vchr,
                  e.code_vchr,
                  e.deptname_vchr) ss
                  group by ss.itcatid,
       ss.doctorid_chr,
       ss.empno_chr,
       ss.lastname_vchr,
       ss.code_vchr,
       ss.deptname_vchr) tt
 where mm.typeid_chr = tt.itcatid(+)
      and mm.doctorid_chr = tt.doctorid_chr(+)
      and mm.code_vchr = tt.code_vchr(+)";

                if (DeptIDArr != null && DeptIDArr.Count > 0)
                {
                    string str = "";
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "'" + DeptIDArr[i].ToString() + "',";
                    }
                    strSQLSub = @"and a.deptid_chr in (" + str.Substring(0, str.Length - 1) + ")";
                    strsqlsub = @"and m.deptid_chr in (" + str.Substring(0, str.Length - 1) + ")";
                }
                strSQLT1 = string.Format(strSQLT1, strSQLSub, strsqlsub, strsqlsub);
                if (p_strStatType == "1")
                {
                    strSQLT1 = strSQLT1.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT1, ref dtT1);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T1表异常：" + e.Message);
                }
                #endregion

                #region T2
                string strSQLT2 = @"select a.doctorid_chr,
                                           sum(case a.status_int
                                                 when 1 then
                                                  1
                                                 when 3 then
                                                  1
                                                 when 2 then
                                                  -1
                                               end) as zfs
                                      from t_opr_outpatientrecipeinv a,
                                           t_opr_reciperelation      b,
                                           t_opr_outpatientrecipe    c
                                     where a.outpatrecipeid_chr = b.seqid
                                       and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                       and c.recipeflag_int = 1
                                       and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                     group by a.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT2 = strSQLT2.Replace("recorddate_dat", "balance_dat");
                }
                else
                {
                    strSQLT2 = strSQLT2.Replace("and a.balanceflag_int = 1", "");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT2, ref dtT2);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T2表异常：" + e.Message);
                }
                #endregion

                #region T21
                string strSQLT21 = string.Empty;

                strSQLT21 = @"select a.doctorid_chr,
                                       sum(case a.status_int
                                             when 1 then
                                              1
                                             when 3 then
                                              1
                                             when 2 then
                                              -1
                                           end) as kjrs 
                                  from t_opr_outpatientrecipeinv a,
                                       t_opr_reciperelation      b,
                                       t_opr_outpatientrecipe    c
                                 where a.outpatrecipeid_chr = b.seqid
                                   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                   and c.recipeflag_int = 1
                                   and (a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                   and exists
                                 (select 1
                                          from t_opr_oprecipeitemde t1,
                                               t_bse_chargeitem     t2,
                                               t_bse_medicine       t3
                                         where c.outpatrecipeid_chr = t1.outpatrecipeid_chr
                                           and t1.itemid_chr = t2.itemid_chr
                                           and t2.itemsrcid_vchr = t3.medicineid_chr
                                           and t3.medicinetypeid_chr = 2
                                           and t3.pharmaid_chr in ('00001', '00005', '00006', '00013'))
                                   and (a.recorddate_dat between timestamp'{0}' and timestamp'{1}')
                                   and (a.recorddate_dat between to_date('{2}', 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'))
                                 group by a.doctorid_chr";

                object[] objs = new object[4] { p_beginDate, p_endDate, p_beginDate, p_endDate };
                strSQLT21 = string.Format(strSQLT21, objs);

                if (p_strStatType == "1")
                {
                    strSQLT21 = strSQLT21.Replace("recorddate_dat", "balance_dat");
                }
                else
                {
                    strSQLT21 = strSQLT21.Replace("and a.balanceflag_int = 1", "");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT21, ref dtT21);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T21表异常：" + e.Message);
                }
                #endregion

                #region T3
                string strSQLT3 = @"select a.doctorid_chr,
                                           sum(case a.status_int
                                                 when 1 then
                                                  1
                                                 when 3 then
                                                  1
                                                 when 2 then
                                                  -1
                                               end) as cfs
                                      from t_opr_outpatientrecipeinv a,
                                           t_opr_reciperelation      b,
                                           t_opr_outpatientrecipe    c
                                     where a.outpatrecipeid_chr = b.seqid
                                       and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                       and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                     group by a.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT3 = strSQLT3.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT3, ref dtT3);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T3表异常：" + e.Message);
                }
                #endregion

                #region T4
                string strSQLT4 = @"select t5.diagdr_chr,
                                           t5.tolprice_mny,
                                           t6.xytolprice_mny,
                                           round((t5.tolprice_mny / t6.xytolprice_mny) * 100, 2) as kjybl,
                                           round((t5.kjcfs / t6.zcfs)*100, 2) as kjcfbl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny + decode(d.opchargeflg_int,
                      0,
                      cc.tradeprice_mny - cc.itemprice_mny,
                      1,
                      round((cc.tradeprice_mny - cc.itemprice_mny) /
                            d.packqty_dec,
                            4))* bb.qty_dec) tolprice_mny,
                                                   sum (case a.status_int
                                                       when 1
                                                          then 1
                                                       when 3
                                                          then 1
                                                       when 2
                                                          then -1
                                                    end
                                                   ) as kjcfs
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and d.pharmaid_chr in ('00001', '00005', '00006', '00013')
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t5,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                    sum(bb.tolprice_mny +
                   decode(d.opchargeflg_int,
                          0,
                          cc.tradeprice_mny - cc.itemprice_mny,
                          1,
                          round((cc.tradeprice_mny - cc.itemprice_mny) /
                                d.packqty_dec,
                                4))* bb.qty_dec) xytolprice_mny,
                                                   sum (case a.status_int
                                                       when 1
                                                          then 1
                                                       when 3
                                                          then 1
                                                       when 2
                                                          then -1
                                                    end
                                                   ) as zcfs
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t6
                                     where t5.diagdr_chr = t6.diagdr_chr
                                     group by t5.diagdr_chr, t5.tolprice_mny, t6.xytolprice_mny,t6.zcfs,t5.kjcfs";

                // and d.pharmaid_chr in ('00001' 抗菌药类, '00005' 非限制使用, '00006' 限制使用, '00013' 特殊使用)
                if (p_strStatType == "1")
                {
                    strSQLT4 = strSQLT4.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT4, ref dtT4);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T4表异常：" + e.Message);
                }
                #endregion

                #region T9
                string strSQLT9 = @"select t7.diagdr_chr,
                                           t7.tolprice_mny as tolprice_jby,
                                           t8.xytolprice_mny as xytolprice_jby,
                                           round((t7.tolprice_mny / t8.xytolprice_mny) * 100, 2) as jbybl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny + decode(d.opchargeflg_int,
                      0,
                      cc.tradeprice_mny - cc.itemprice_mny,
                      1,
                      round((cc.tradeprice_mny - cc.itemprice_mny) /
                            d.packqty_dec,
                            4))* bb.qty_dec) tolprice_mny
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               --and d.pharmaid_chr in ('00001', '00005', '00006', '00013')
                                               and d.insurancetype_vchr in ('1006', '1007', '1008')
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t7,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny +
                   decode(d.opchargeflg_int,
                          0,
                          cc.tradeprice_mny - cc.itemprice_mny,
                          1,
                          round((cc.tradeprice_mny - cc.itemprice_mny) /
                                d.packqty_dec,
                                4))* bb.qty_dec) xytolprice_mny
                                              from t_opr_outpatientrecipeinv a,
                                                   t_opr_reciperelation b,
                                                   t_opr_outpatientrecipe c,
                                                   t_opr_oprecipeitemde bb,
                                                   t_bse_chargeitem cc,
                                                   t_bse_medicine d,
                                                   t_bse_deptdesc f,
                                                   t_bse_employee g,
                                                   (select t1.empid_chr, t1.deptid_chr, t2.deptname_vchr
                                                      from t_bse_deptemp t1, t_bse_deptdesc t2
                                                     where t1.default_dept_int = 1
                                                       and t1.deptid_chr = t2.deptid_chr) e
                                             where a.outpatrecipeid_chr = b.seqid
                                               and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                               and c.outpatrecipeid_chr = bb.outpatrecipeid_chr
                                               and bb.itemid_chr = cc.itemid_chr
                                               and c.diagdr_chr = e.empid_chr(+)
                                               and c.diagdept_chr = f.deptid_chr
                                               and c.diagdr_chr = g.empid_chr
                                               and c.pstauts_int in (2, 3)
                                               and cc.itemsrcid_vchr = d.medicineid_chr
                                               and d.medicinetypeid_chr = 2
                                               and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t8
                                     where t7.diagdr_chr = t8.diagdr_chr
                                     group by t7.diagdr_chr, t7.tolprice_mny, t8.xytolprice_mny";

                // t_aid_medicaretype.typeid_chr = d.insurancetype_vchr in ('1006' 自费(基), '1007' 甲类(基), '1008' 乙类(基))
                if (p_strStatType == "1")
                {
                    strSQLT9 = strSQLT9.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT9, ref dtT9);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T9表异常：" + e.Message);
                }
                #endregion

                #region T10
                string strSQLT10 = @"select m.doctorid_chr, count(m.outpatrecipeid_chr) Counts_KJY
  from (select n.doctorid_chr, n.outpatrecipeid_chr,sum(n.status) as statussum
  from (select b.doctorid_chr, t.outpatrecipeid_chr,decode(b.status_int,0,-1,2,-1,1) as status
          from t_opr_outpatientpwmrecipede t,
               t_opr_reciperelation        a,
               t_opr_outpatientrecipeinv   b,
               t_bse_medicine              c,
               t_bse_chargeitem            e
         where t.outpatrecipeid_chr = a.outpatrecipeid_chr
           and a.seqid = b.outpatrecipeid_chr
           and t.itemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.pharmaid_chr in ('00001', '00005', '00006', '00013')  
           and( b.isvouchers_int <> 2 or b.isvouchers_int is null)
           and b.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
           and b.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')) n
               group by n.doctorid_chr, n.outpatrecipeid_chr) m
                       where m.statussum<>0
 group by m.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT10 = strSQLT10.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT10, ref dtT10);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T10表异常：" + e.Message);
                }
                #endregion

                #region T11
                string strSQLT11 = @"select tab1.doctorid_chr, sum(case tab1.status_int
                                                                     when 1 then
                                                                      1
                                                                     when 3 then
                                                                      1
                                                                     when 2 then
                                                                      -1
                                                                   end) as xycfs
                                              from (select distinct a.outpatrecipeid_chr,
                                                                    a.status_int,
                                                                    a.doctorid_chr
                                                      from t_opr_outpatientrecipeinv a,
                                                           t_opr_reciperelation      b,
                                                           t_opr_outpatientrecipe    c,
                                                           t_opr_outpatientpwmrecipede t,
                                                           t_bse_chargeitem            e,
                                                           t_bse_medicine              m
                                                     where a.outpatrecipeid_chr = b.seqid
                                                       and b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                                       and t.outpatrecipeid_chr = b.outpatrecipeid_chr
                                                       and t.itemid_chr = e.itemid_chr
                                                       and e.itemsrcid_vchr = m.medicineid_chr
                                                       and m.medicinetypeid_chr = '2'
                                                       and( a.isvouchers_int <> 2 or a.isvouchers_int is null)
                                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                                    ) tab1
                                               group by tab1.doctorid_chr";

                if (p_strStatType == "1")
                {
                    strSQLT11 = strSQLT11.Replace("recorddate_dat", "balance_dat");
                }

                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQLT11, ref dtT11);
                }
                catch (Exception e)
                {
                    clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError("获取T11表异常：" + e.Message);
                }
                #endregion

                #region 数据合并处理整合为和原查询语句得到的datatable相同

                string[] strDtT2JoinColArr = new string[] { "zfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT2, "doctorid_chr", "doctorid_chr", strDtT2JoinColArr);

                string[] strDtT21JoinColArr = new string[] { "kjrs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT21, "doctorid_chr", "doctorid_chr", strDtT21JoinColArr);

                string[] strDtT3JoinColArr = new string[] { "cfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT3, "doctorid_chr", "doctorid_chr", strDtT3JoinColArr);

                string[] strDtT4JoinColArr = new string[] { "kjybl", "tolprice_mny", "xytolprice_mny" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT4, "doctorid_chr", "diagdr_chr", strDtT4JoinColArr);

                string[] strDtT9JoinColArr = new string[] { "jbybl", "tolprice_jby", "xytolprice_jby" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT9, "doctorid_chr", "diagdr_chr", strDtT9JoinColArr);

                string[] strDtT10JoinColArr = new string[] { "Counts_KJY" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT10, "doctorid_chr", "doctorid_chr", strDtT10JoinColArr);

                string[] strDtT11JoinColArr = new string[] { "xycfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT11, "doctorid_chr", "doctorid_chr", strDtT11JoinColArr);

                DataView dvJoinResult = dtT1.DefaultView;
                dvJoinResult.Sort = "empno_chr, lastname_vchr, typeid_chr, typename_vchr, zfs, kjrs, cfs, code_vchr, deptname_vchr, tolprice_mny, xytolprice_mny, kjybl, counts_kjy, xycfs, jbybl";
                DataTable dtFinalResult = dvJoinResult.ToTable();

                for (int i = 0; i < dtFinalResult.Rows.Count - 1; i++)
                {
                    DataRow drFirst = dtFinalResult.Rows[i];
                    DataRow drSecond = dtFinalResult.Rows[i + 1];

                    if (drFirst["empno_chr"] == drSecond["empno_chr"] && drFirst["lastname_vchr"] == drSecond["lastname_vchr"] && drFirst["typeid_chr"] == drSecond["typeid_chr"])
                    {
                        if (drFirst["typename_vchr"] == drSecond["typename_vchr"] && drFirst["zfs"] == drSecond["zfs"] && drFirst["kjrs"] == drSecond["kjrs"] && drFirst["cfs"] == drSecond["cfs"] && drFirst["xytolprice_mny"] == drSecond["xytolprice_mny"] && drFirst["xytolprice_jby"] == drSecond["xytolprice_jby"])
                        {
                            if (drFirst["code_vchr"] == drSecond["code_vchr"] && drFirst["deptname_vchr"] == drSecond["deptname_vchr"] && drFirst["tolprice_mny"] == drSecond["tolprice_mny"] && drFirst["tolprice_jby"] == drSecond["tolprice_jby"])
                            {
                                if (drFirst["kjybl"] == drSecond["kjybl"] && drFirst["counts_kjy"] == drSecond["counts_kjy"] && drFirst["xycfs"] == drSecond["xycfs"] && drFirst["jbybl"] == drSecond["jbybl"])
                                {
                                    if (dtFinalResult.Rows[i]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["tolfee_jby"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_jby"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["jxywl"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_jby"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_jby"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["jxywl"] = 0;
                                    }
                                    dtFinalResult.Rows[i]["tolfee_mny"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_mny"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_mny"]);
                                    dtFinalResult.Rows[i]["tolfee_jby"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_jby"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_jby"]);
                                    dtFinalResult.Rows[i]["jxywl"] = Convert.ToDecimal(dtFinalResult.Rows[i]["jxywl"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["jxywl"]);
                                    dtFinalResult.Rows.Remove(drSecond);
                                    dtFinalResult.AcceptChanges();
                                    i = i - 1;
                                }
                            }
                        }
                    }
                }

                dtResult.Columns.Add("typeid_chr", typeof(string));
                dtResult.Columns.Add("typename_vchr", typeof(string));
                dtResult.Columns.Add("empno_chr", typeof(string));
                dtResult.Columns.Add("lastname_vchr", typeof(string));
                dtResult.Columns.Add("zfs", typeof(int));
                dtResult.Columns.Add("kjrs", typeof(int));
                dtResult.Columns.Add("cfs", typeof(int));
                dtResult.Columns.Add("code_vchr", typeof(string));
                dtResult.Columns.Add("deptname_vchr", typeof(string));
                dtResult.Columns.Add("tolfee_mny", typeof(decimal));
                dtResult.Columns.Add("jxywl", typeof(decimal));
                dtResult.Columns.Add("kjybl", typeof(decimal));
                dtResult.Columns.Add("tolprice_mny", typeof(decimal));
                dtResult.Columns.Add("xytolprice_mny", typeof(decimal));
                dtResult.Columns.Add("kjcfbl", typeof(decimal));
                dtResult.Columns.Add("jbybl", typeof(decimal));
                dtResult.Columns.Add("tolprice_jby", typeof(decimal));
                dtResult.Columns.Add("xytolprice_jby", typeof(decimal));

                for (int i = 0; i < dtFinalResult.Rows.Count; i++)
                {
                    DataRow drResu = dtResult.NewRow();
                    drResu["typeid_chr"] = dtFinalResult.Rows[i]["typeid_chr"];
                    drResu["typename_vchr"] = dtFinalResult.Rows[i]["typename_vchr"];
                    drResu["empno_chr"] = dtFinalResult.Rows[i]["empno_chr"];
                    drResu["lastname_vchr"] = dtFinalResult.Rows[i]["lastname_vchr"];
                    drResu["zfs"] = dtFinalResult.Rows[i]["zfs"];
                    drResu["kjrs"] = dtFinalResult.Rows[i]["kjrs"];
                    drResu["cfs"] = dtFinalResult.Rows[i]["cfs"];
                    drResu["code_vchr"] = dtFinalResult.Rows[i]["code_vchr"];
                    drResu["deptname_vchr"] = dtFinalResult.Rows[i]["deptname_vchr"];
                    drResu["tolfee_mny"] = dtFinalResult.Rows[i]["tolfee_mny"];
                    drResu["jxywl"] = dtFinalResult.Rows[i]["jxywl"];
                    drResu["kjybl"] = dtFinalResult.Rows[i]["kjybl"];
                    drResu["tolprice_mny"] = dtFinalResult.Rows[i]["tolprice_mny"];
                    drResu["xytolprice_mny"] = dtFinalResult.Rows[i]["xytolprice_mny"];
                    drResu["jbybl"] = dtFinalResult.Rows[i]["jbybl"];
                    drResu["tolprice_jby"] = dtFinalResult.Rows[i]["tolprice_jby"];
                    drResu["xytolprice_jby"] = dtFinalResult.Rows[i]["xytolprice_jby"];
                    //if (dtFinalResult.Rows[i]["Counts_KJY"] != DBNull.Value && dtFinalResult.Rows[i]["xycfs"] != DBNull.Value)
                    //{
                    //    drResu["kjcfbl"] = Math.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["Counts_KJY"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["xycfs"])) * 100, 2);
                    //}
                    if (dtFinalResult.Rows[i]["kjrs"] != DBNull.Value && dtFinalResult.Rows[i]["zfs"] != DBNull.Value && Convert.ToInt32(dtFinalResult.Rows[i]["zfs"]) != 0)
                    {
                        drResu["kjcfbl"] = this.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["kjrs"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["zfs"])) * 100, 2);
                    }
                    dtResult.Rows.Add(drResu);
                }

                dtResult.AcceptChanges();
                #endregion
            }
            return lngRes;
        }
        #endregion

        #region 两个datatable左连接
        /// <summary>
        /// 两个datatable左连接
        /// </summary>
        /// <param name="dtMain"></param>
        /// <param name="dtSub"></param>
        /// <param name="strLinkColumn"></param>
        /// <param name="strJoinColumnArr"></param>
        /// <returns></returns>
        public DataTable m_dtbDataTableLeftJoin(DataTable dtMain, DataTable dtSub, string strMainIDColumn, string strSubIDColumn, string[] strJoinColumnArr)
        {
            for (int i = 0; i < strJoinColumnArr.Length; i++)
            {
                dtMain.Columns.Add(strJoinColumnArr[i]);
            }

            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                string strMainID = dtMain.Rows[i][strMainIDColumn].ToString();
                DataRow[] drEqualArr = dtSub.Select(strSubIDColumn + " = " + strMainID);
                if (drEqualArr != null && drEqualArr.Length > 0)
                {
                    DataRow drEqu = drEqualArr[0];
                    for (int j = 0; j < strJoinColumnArr.Length; j++)
                    {
                        dtMain.Rows[i][strJoinColumnArr[j]] = drEqu[strJoinColumnArr[j]];
                    }
                    dtSub.AcceptChanges();
                }
            }
            dtMain.AcceptChanges();
            return dtMain;
        }
        #endregion

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        decimal Round(decimal d, int decimals)
        {
            try
            {
                if (decimals < 1)
                {
                    return Convert.ToDecimal(Convert.ToInt32(d));
                }
                else
                {
                    string s = "0.";
                    for (int i = 0; i < decimals; i++)
                    {
                        s += "0";
                    }
                    return Convert.ToDecimal(d.ToString(s));
                }
            }
            catch
            {
                return d;
            }
        }
        #endregion  
    }
}
