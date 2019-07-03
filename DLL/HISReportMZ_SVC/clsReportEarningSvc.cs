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
    /// 
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReportEarningSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 按接诊医生统计门诊挂号费及诊金报表
        /// <summary>
        /// 1.按接诊医生统计门诊挂号费及诊金报表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectDoctorEarning(string strBeginDat, string strEndDat, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"
                        select   t4.empno_chr, t4.lastname_vchr,
                                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                            from (select c.doctorid_chr, a.registerid_chr
                                    from t_opr_outpatientrecipe a,
                                         t_opr_reciperelation b,
                                         t_opr_outpatientrecipeinv c
                                   where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                     and b.seqid = c.outpatrecipeid_chr
                                     and a.recipeflag_int = 1
                                     and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                     and a.registerid_chr is not null
                                     and c.balance_dat > ?
                                     and c.balance_dat < ?
                                     and a.recorddate_dat =
                                            (select min (recorddate_dat)
                                               from t_opr_outpatientrecipe
                                              where registerid_chr = a.registerid_chr
                                                and recipeflag_int = 1
                                                and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                         (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
                                         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
                                 t_bse_employee t4
                           where t1.registerid_chr = t2.registerid_chr(+)
                             and t1.registerid_chr = t3.registerid_chr(+)
                             and t1.doctorid_chr = t4.empid_chr(+)
                        group by t4.empno_chr, t4.lastname_vchr
                    ";
//            string strSql = @"select   t4.empno_chr, t4.lastname_vchr,
//                                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
//                                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
//                            from (select c.doctorid_chr, a.registerid_chr
//                                    from t_opr_outpatientrecipe a,
//                                         t_opr_reciperelation b,
//                                         t_opr_charge c
//                                   where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                     and c.chargeno_chr = b.chargeno_chr
//                                     and a.recipeflag_int = 1
//                                     and (a.pstauts_int = 2 or a.pstauts_int = 3)
//                                     and a.registerid_chr is not null
//                                     and c.recdate_dat > ?
//                                     and c.recdate_dat < ?
//                                     and a.recorddate_dat =
//                                            (select min (recorddate_dat)
//                                               from t_opr_outpatientrecipe
//                                              where registerid_chr = a.registerid_chr
//                                                and recipeflag_int = 1
//                                                and (pstauts_int = 2 or pstauts_int = 3))) t1,
//                                         (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
//                                         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
//                                 t_bse_employee t4
//                           where t1.registerid_chr = t2.registerid_chr(+)
//                             and t1.registerid_chr = t3.registerid_chr(+)
//                             and t1.doctorid_chr = t4.empid_chr(+)
//                        group by t4.empno_chr, t4.lastname_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                int n = -1;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

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

        #region 按组统计门诊挂号费及诊金报表
        /// <summary>
        /// 2.按组统计门诊挂号费及诊金报表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectGroupEarning(string strBeginDat, string strEndDat, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            //string strSql = @"
//                        select   t6.usercode_chr, t6.groupname_vchr,
//                                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
//                                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
//                            from (select a.groupid_chr, a.registerid_chr
//                                    from t_opr_outpatientrecipe a,
//                                         t_opr_reciperelation b,
//                                         t_opr_outpatientrecipeinv c
//                                   where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                     and b.seqid = c.outpatrecipeid_chr
//                                     and a.recipeflag_int = 1
//                                     and (a.pstauts_int = 2 or a.pstauts_int = 3)
//                                     and a.registerid_chr is not null
//                                     and c.balance_dat > ?
//                                     and c.balance_dat < ?
//                                     and a.recorddate_dat =
//                                            (select min (recorddate_dat)
//                                               from t_opr_outpatientrecipe
//                                              where registerid_chr = a.registerid_chr
//                                                and recipeflag_int = 1
//                                                and (pstauts_int = 2 or pstauts_int = 3))) t1,
//                                     (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
//         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
//                                 t_bse_groupdesc t6
//                           where t1.registerid_chr = t2.registerid_chr(+)
//                             and t1.registerid_chr = t3.registerid_chr(+)
//                             and t1.groupid_chr = t6.groupid_chr(+)
//                        group by t6.usercode_chr, t6.groupname_vchr
                    //";
            string strSql = @"select   t6.usercode_chr, t6.groupname_vchr,
                                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                            from (select a.groupid_chr, a.registerid_chr
                                    from t_opr_outpatientrecipe a,
                                         t_opr_reciperelation b,
                                         t_opr_charge c
                                   where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                     and c.chargeno_chr = b.chargeno_chr
                                     and a.recipeflag_int = 1
                                     and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                     and a.registerid_chr is not null
                                     and c.recdate_dat > ?
                                     and c.recdate_dat < ?
                                     and a.recorddate_dat =
                                            (select min (recorddate_dat)
                                               from t_opr_outpatientrecipe
                                              where registerid_chr = a.registerid_chr
                                                and recipeflag_int = 1
                                                and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                     (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
                                 t_bse_groupdesc t6
                           where t1.registerid_chr = t2.registerid_chr(+)
                             and t1.registerid_chr = t3.registerid_chr(+)
                             and t1.groupid_chr = t6.groupid_chr(+)
                        group by t6.usercode_chr, t6.groupname_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                int n = -1;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

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

        #region 医生挂号费及诊金汇总表(旧）
        /// <summary>
        /// 3.医生挂号费及诊金汇总表（旧）
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectDoctorEarningCollect(string strBeginDat, string strEndDat, string[] strGhfParams, string[] strZcParams, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"
                        select t4.empno_chr, t4.lastname_vchr, t7.totalghmny, t7.totalzcmny,
                               t5.totaloghmny, t6.totalozcmny
                          from (select   t1.doctorid_chr,
                                         sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                         sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                                    from (select c.doctorid_chr, a.registerid_chr
                                            from t_opr_outpatientrecipe a,
                                                 t_opr_reciperelation b,
                                                 t_opr_outpatientrecipeinv c
                                           where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                             and b.seqid = c.outpatrecipeid_chr
                                             and a.recipeflag_int = 1
                                             and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                             and a.registerid_chr is not null
                                             and c.balance_dat > ?
                                             and c.balance_dat < ?
                                             and a.recorddate_dat =
                                                    (select min (recorddate_dat)
                                                       from t_opr_outpatientrecipe
                                                      where registerid_chr = a.registerid_chr
                                                        and recipeflag_int = 1
                                                        and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                             (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3
                                   where t1.registerid_chr = t2.registerid_chr(+)
                                     and t1.registerid_chr = t3.registerid_chr(+)
                                group by t1.doctorid_chr) t7,
                               t_bse_employee t4,
                               (select   c1.doctorid_chr, sum (e1.tolprice_mny) as totaloghmny
                                    from t_opr_outpatientrecipe a1,
                                         t_opr_reciperelation b1,
                                         t_opr_outpatientrecipeinv c1,
                                         t_opr_oprecipeitemde e1
                                   where a1.outpatrecipeid_chr = b1.outpatrecipeid_chr
                                     and b1.seqid = c1.outpatrecipeid_chr
                                     and a1.outpatrecipeid_chr = e1.outpatrecipeid_chr
                                     and (a1.pstauts_int = 2 or a1.pstauts_int = 3)
                                     [condition1]
                                     and c1.status_int = 1
                                     and c1.balance_dat > ?
                                     and c1.balance_dat < ?
                                group by c1.doctorid_chr) t5,
                               (select   c2.doctorid_chr, sum (e2.tolprice_mny) as totalozcmny
                                    from t_opr_outpatientrecipe a2,
                                         t_opr_reciperelation b2,
                                         t_opr_outpatientrecipeinv c2,
                                         t_opr_oprecipeitemde e2
                                   where a2.outpatrecipeid_chr = b2.outpatrecipeid_chr
                                     and b2.seqid = c2.outpatrecipeid_chr
                                     and a2.outpatrecipeid_chr = e2.outpatrecipeid_chr
                                     and (a2.pstauts_int = 2 or a2.pstauts_int = 3)
                                     [condition2]
                                     and c2.status_int = 1
                                     and c2.balance_dat > ?
                                     and c2.balance_dat < ?
                                group by c2.doctorid_chr) t6
                         where t4.empid_chr = t7.doctorid_chr(+) and t4.empid_chr = t5.doctorid_chr(+)
                               and t4.empid_chr = t6.doctorid_chr(+)";

            strSql = m_strMakeSql(strSql, strGhfParams, strZcParams);

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();


                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(6, out arrParams);
                int n = -1;

                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

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

        #region 按组统计医生挂号费及诊金汇总表(旧)
        /// <summary>
        /// 5.2按组统计医生挂号费及诊金汇总表(旧)
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="groupid"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectDoctorEarningGrouping(string strBeginDat, string strEndDat, string groupid, string[] strGhfParams, string[] strZcParams, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"  select   t4.empno_chr, t4.lastname_vchr,t7.totalghmny,
                             t7.totalzcmny, t5.totaloghmny, t6.totalozcmny
                        from (select   t1.doctorid_chr,
                                       sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                       sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                                  from (select c.doctorid_chr, a.registerid_chr
                                          from t_opr_outpatientrecipe a,
                                               t_opr_reciperelation b,
                                               t_opr_outpatientrecipeinv c
                                         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                           and b.seqid = c.outpatrecipeid_chr
                                           and a.recipeflag_int = 1
                                           and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                           and a.registerid_chr is not null
                                           and c.balance_dat > ?
                                           and c.balance_dat < ?
                                           and a.groupid_chr= ?
                                           and a.recorddate_dat =
                                                  (select min (recorddate_dat)
                                                     from t_opr_outpatientrecipe
                                                    where registerid_chr = a.registerid_chr
                                                      and recipeflag_int = 1
                                                      and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                   (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3
                                 where t1.registerid_chr = t2.registerid_chr(+)
                                   and t1.registerid_chr = t3.registerid_chr(+)
                              group by t1.doctorid_chr) t7,
                             t_bse_employee t4,
                             (select   c1.doctorid_chr, sum (e1.tolprice_mny) as totaloghmny
                                  from t_opr_outpatientrecipe a1,
                                       t_opr_reciperelation b1,
                                       t_opr_outpatientrecipeinv c1,
                                       t_opr_oprecipeitemde e1
                                 where a1.outpatrecipeid_chr = b1.outpatrecipeid_chr
                                   and b1.seqid = c1.outpatrecipeid_chr
                                   and a1.outpatrecipeid_chr = e1.outpatrecipeid_chr
                                   and (a1.pstauts_int = 2 or a1.pstauts_int = 3)
                                   [condition1]
                                   --and (e1.itemid_chr = '0000122767' or e1.itemid_chr = '1000000458' or e1.itemid_chr = '1000007859' or e1.itemid_chr = '0000000426') 
                                   and c1.status_int = 1
                                   and c1.balance_dat > ?
                                   and c1.balance_dat < ?
                                   and a1.groupid_chr= ?
                              group by c1.doctorid_chr) t5,
                             (select    c2.doctorid_chr, sum (e2.tolprice_mny) as totalozcmny
                                  from t_opr_outpatientrecipe a2,
                                       t_opr_reciperelation b2,
                                       t_opr_outpatientrecipeinv c2,
                                       t_opr_oprecipeitemde e2
                                 where a2.outpatrecipeid_chr = b2.outpatrecipeid_chr
                                   and b2.seqid = c2.outpatrecipeid_chr
                                   and a2.outpatrecipeid_chr = e2.outpatrecipeid_chr
                                   and (a2.pstauts_int = 2 or a2.pstauts_int = 3)
                                   [condition2]
                                   --and (e2.itemid_chr = '1000000460' or e2.itemid_chr = '1000000464') 
                                   and c2.status_int = 1
                                   and c2.balance_dat > ?
                                   and c2.balance_dat < ?
                                   and a2.groupid_chr= ?
                              group by c2.doctorid_chr) t6
                       where t4.empid_chr = t7.doctorid_chr(+)
                         and t4.empid_chr = t5.doctorid_chr(+)
                         and t4.empid_chr = t6.doctorid_chr(+)
                     ";

            strSql = m_strMakeSql(strSql, strGhfParams, strZcParams);

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(9, out arrParams);

                int n = -1;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = groupid;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = groupid;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = groupid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

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


        #region 取核算分类
        [AutoComplete]
        public long m_lngGetTypeID(string p_strRptID,string p_strGroupID, out DataTable p_dtbTypeID)
        {
            long lngRes = -1;
            
            p_dtbTypeID = new DataTable();
            string strSQL = @"select b.typeid_chr
                        from t_aid_rpt_gop_def a, t_aid_rpt_gop_rla b
                        where a.groupid_chr = b.groupid_chr(+)
                            and a.rptid_chr = b.rptid_chr
                            and a.rptid_chr = ?
                            and a.groupid_chr = ?
                        order by b.typeid_chr asc";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strRptID;
                objDPArr[1].Value = p_strGroupID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbTypeID, objDPArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region 医生挂号费及诊金汇总表(新)
        /// <summary>
        /// 3.医生挂号费及诊金汇总表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorEarningCollect(string strBeginDat, string strEndDat, string[] p_strTypeIDArr1,string[] p_strTypeIDArr2, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();
            StringBuilder sbdSql = new StringBuilder(
                    @"select t4.empno_chr,
                             t4.lastname_vchr,
                             t7.totalghmny,
                             t7.totalzcmny,
                             t5.totaloghmny,
                             t6.totalozcmny
                     from (select t1.doctorid_chr,
                       sum(t2.payment_mny * t2.discount_dec) as totalghmny,
                       sum(t3.payment_mny * t3.discount_dec) as totalzcmny
                     from (select c.doctorid_chr, a.registerid_chr
                     from t_opr_outpatientrecipe    a,
                          t_opr_reciperelation      b,
                          t_opr_outpatientrecipeinv c
                     where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                        and b.seqid = c.outpatrecipeid_chr
                        and a.recipeflag_int = 1
                        and (a.pstauts_int = 2 or a.pstauts_int = 3)
                        and a.registerid_chr is not null
                        and c.balance_dat >= ?
                        and c.balance_dat <= ?
                        and a.recorddate_dat =
                       (select min(recorddate_dat)
                         from t_opr_outpatientrecipe
                         where registerid_chr = a.registerid_chr
                           and recipeflag_int = 1
                           and (pstauts_int = 2 or pstauts_int = 3))) t1,
                      (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3
                    where t1.registerid_chr = t2.registerid_chr(+)
                        and t1.registerid_chr = t3.registerid_chr(+)
                        group by t1.doctorid_chr) t7,
                        t_bse_employee t4,

                    (select c1.doctorid_chr, sum(e1.tolfee_mny) as totaloghmny
                    from t_opr_outpatientrecipeinv c1, t_opr_outpatientrecipesumde e1
                    where c1.seqid_chr = e1.seqid_chr 
                     and (e1.itemcatid_chr = ?");
//            StringBuilder sbdSql = new StringBuilder(@"select t4.empno_chr, t4.lastname_vchr, t7.totalghmny, t7.totalzcmny,
//       t5.totaloghmny, t6.totalozcmny
//  from (select   t1.diagdr_chr,
//                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
//                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
//            from (select a.diagdr_chr, a.registerid_chr
//                    from t_opr_outpatientrecipe a,
//                         t_opr_reciperelation b,
//                         t_opr_charge c
//                   where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                     and c.chargeno_chr = b.chargeno_chr
//                     and a.recipeflag_int = 1
//                     and (a.pstauts_int = 2 or a.pstauts_int = 3)
//                     and a.registerid_chr is not null
//                     and c.recdate_dat >=?
//                     and c.recdate_dat <=?
//                     and a.recorddate_dat =
//                            (select min (recorddate_dat)
//                               from t_opr_outpatientrecipe
//                              where registerid_chr = a.registerid_chr
//                                and recipeflag_int = 1
//                                and (pstauts_int = 2 or pstauts_int = 3))) t1,
//                 (select m.registerid_chr, m.chargeid_chr, m.payment_mny,
//                         m.discount_dec
//                    from t_opr_patientregdetail m
//                   where chargeid_chr = '001') t2,
//                 (select n.registerid_chr, n.chargeid_chr, n.payment_mny,
//                         n.discount_dec
//                    from t_opr_patientregdetail n
//                   where chargeid_chr = '002') t3
//           where t1.registerid_chr = t2.registerid_chr(+)
//                 and t1.registerid_chr = t3.registerid_chr(+)
//        group by t1.diagdr_chr) t7,
//       t_bse_employee t4,
//       (select   f1.diagdr_chr, sum (e1.tolfee_mny) as totaloghmny
//            from t_opr_charge c1,
//                 t_opr_reciperelation d1,
//                 t_opr_outpatientrecipe f1,
//                 t_opr_outpatientrecipesumde e1
//           where c1.chargeno_chr = d1.chargeno_chr
//             and f1.outpatrecipeid_chr = d1.outpatrecipeid_chr
//             and c1.chargeno_chr = e1.chargeno_chr
//             and (e1.itemcatid_chr = ?");
            for (int i1 = 1; i1 < p_strTypeIDArr1.Length; i1++)
            {
                sbdSql.Append(@" or e1.itemcatid_chr = ?");
            }

            sbdSql.Append(@") and c1.balance_dat >= ?
                         and c1.balance_dat <= ?
                    group by c1.doctorid_chr) t5,
                    (select c2.doctorid_chr, sum(e2.tolfee_mny) as totalozcmny
                    from t_opr_outpatientrecipeinv c2, t_opr_outpatientrecipesumde e2
                    where c2.seqid_chr = e2.seqid_chr
                      and (e2.itemcatid_chr = ?");
//            sbdSql.Append(@") and c1.recdate_dat >= ?
//                         and c1.recdate_dat <= ?
//                    group by f1.diagdr_chr) t5,
//                    (SELECT   f.diagdr_chr, SUM (e2.tolfee_mny) AS totalozcmny
//            FROM t_opr_charge c2,
//                 t_opr_reciperelation d,
//                 t_opr_outpatientrecipe f,
//                 t_opr_outpatientrecipesumde e2
//           WHERE c2.chargeno_chr = d.chargeno_chr
//             AND f.outpatrecipeid_chr = d.outpatrecipeid_chr
//             AND c2.chargeno_chr = e2.chargeno_chr
//             AND (e2.itemcatid_chr = ?");
       for (int i1 = 1; i1 < p_strTypeIDArr2.Length; i1++)
       {
           sbdSql.Append(@" or e2.itemcatid_chr = ?");
       }

       sbdSql.Append(@") and c2.balance_dat >= ?
                         and c2.balance_dat <= ?
                    group by c2.doctorid_chr) t6
                    where t4.empid_chr = t7.doctorid_chr(+)
                      and t4.empid_chr = t5.doctorid_chr(+)
                      and t4.empid_chr = t6.doctorid_chr(+)");  
//       sbdSql.Append(@") and c2.recdate_dat >= ?
//                         and c2.recdate_dat <= ?
//                    group by f.diagdr_chr) t6
//                    where t4.empid_chr = t7.diagdr_chr(+)
//                      and t4.empid_chr = t5.diagdr_chr(+)
//                      and t4.empid_chr = t6.diagdr_chr(+)"); 

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();


                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(6 + p_strTypeIDArr1.Length + p_strTypeIDArr2.Length, out arrParams);
                int n = -1;

                arrParams[0].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[0].DbType = DbType.Date;
                arrParams[1].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[1].DbType = DbType.Date;
                int intIndex = 2;
                for (int i1 = 0; i1 < p_strTypeIDArr1.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr1[i1];
                    
                }
                intIndex += p_strTypeIDArr1.Length
                    ;
                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;

                for (int i1 = 0; i1 < p_strTypeIDArr2.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr2[i1];
                    
                }

                intIndex += p_strTypeIDArr2.Length;

                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[intIndex].DbType = DbType.Date;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSql.ToString(), ref m_dtbReport, arrParams);

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


        #region 按组统计医生挂号费及诊金汇总表(新)
        /// <summary>
        /// 3.按组统计医生挂号费及诊金汇总表(新)
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorEarningGrouping(string strBeginDat, string strEndDat,string groupid, string[] p_strTypeIDArr1, string[] p_strTypeIDArr2, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            StringBuilder sbdSql = new StringBuilder(@"
                select  t4.empno_chr,
                        t4.lastname_vchr,
                        t7.totalghmny,
                        t7.totalzcmny,
                        t5.totaloghmny,
                        t6.totalozcmny
                from (select t1.doctorid_chr,
                        sum(t2.payment_mny * t2.discount_dec) as totalghmny,
                        sum(t3.payment_mny * t3.discount_dec) as totalzcmny
                from (select c.doctorid_chr, a.registerid_chr
                  from t_opr_outpatientrecipe    a,
                       t_opr_reciperelation      b,
                       t_opr_outpatientrecipeinv c
                 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                   and b.seqid = c.outpatrecipeid_chr
                   and a.recipeflag_int = 1
                   and (a.pstauts_int = 2 or a.pstauts_int = 3)
                   and a.registerid_chr is not null
                   and c.balance_dat >= ?
                   and c.balance_dat <= ?
                   and a.groupid_chr = ?
                   and a.recorddate_dat =
                       (select min(recorddate_dat)
                          from t_opr_outpatientrecipe
                         where registerid_chr = a.registerid_chr
                           and recipeflag_int = 1
                           and (pstauts_int = 2 or pstauts_int = 3))) t1,
                  (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3
         where t1.registerid_chr = t2.registerid_chr(+)
           and t1.registerid_chr = t3.registerid_chr(+)
         group by t1.doctorid_chr) t7,
       t_bse_employee t4,
       (select c1.doctorid_chr, sum(e1.tolfee_mny) as totaloghmny
          from t_opr_outpatientrecipeinv c1, t_opr_outpatientrecipesumde e1
         where c1.seqid_chr = e1.seqid_chr
           and (e1.itemcatid_chr = ?");

            for (int i1 = 1; i1 < p_strTypeIDArr1.Length; i1++)
            {
                sbdSql.Append(@" or e1.itemcatid_chr = ?");
            }

          sbdSql.Append(@") and c1.balance_dat >= ?
           and c1.balance_dat <= ?
           and c1.groupid_chr = ?
         group by c1.doctorid_chr) t5,
          (select c2.doctorid_chr, sum(e2.tolfee_mny) as totalozcmny
          from t_opr_outpatientrecipeinv c2, t_opr_outpatientrecipesumde e2
         where c2.seqid_chr = e2.seqid_chr
           and (e2.itemcatid_chr = ?");

          for (int i1 = 1; i1 < p_strTypeIDArr2.Length; i1++)
          {
              sbdSql.Append(@" or e2.itemcatid_chr = ?");
          }

         sbdSql.Append(@")  and c2.balance_dat >= ?
           and c2.balance_dat <= ?
           and c2.groupid_chr = ?
         group by c2.doctorid_chr) t6
         where t4.empid_chr = t7.doctorid_chr(+)
            and t4.empid_chr = t5.doctorid_chr(+)
            and t4.empid_chr = t6.doctorid_chr(+)
            and (t7.totalghmny > 0 or t7.totalzcmny > 0 or t5.totaloghmny > 0 or
                t6.totalozcmny > 0)");


            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();


                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(9 + p_strTypeIDArr1.Length + p_strTypeIDArr2.Length, out arrParams);
                int n = -1;

                arrParams[0].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[0].DbType = DbType.Date;
                arrParams[1].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[1].DbType = DbType.Date;
                arrParams[2].Value = groupid;


                int intIndex = 3;
                for (int i1 = 0; i1 < p_strTypeIDArr1.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr1[i1];

                }
                intIndex += p_strTypeIDArr1.Length
                    ;
                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = groupid;
                intIndex++;

                for (int i1 = 0; i1 < p_strTypeIDArr2.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr2[i1];

                }

                intIndex += p_strTypeIDArr2.Length;

                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = groupid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSql.ToString(), ref m_dtbReport, arrParams);

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


        #region 专业组挂号费及诊金汇总表(新)
        /// <summary>
        /// 4.专业组挂号费及诊金汇总表（新）
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupEarningCollect(string strBeginDat, string strEndDat, string[] p_strTypeIDArr1, string[] p_strTypeIDArr2,  out DataTable dt1, out DataTable dt2, out DataTable dt3)
        {
            long lngRes = 0;

            dt1 = new DataTable();
            dt2 = new DataTable();
            dt3 = new DataTable();

            lngRes = this.m_lngGetGroupEarningCollect1(strBeginDat, strEndDat, out dt1);
            if (p_strTypeIDArr1 != null)
            {
                lngRes = this.m_lngGetGroupEarningCollect2(strBeginDat, strEndDat, p_strTypeIDArr1, out dt2);
            }
            if (p_strTypeIDArr2 != null)
            {
            lngRes = this.m_lngGetGroupEarningCollect3(strBeginDat, strEndDat, p_strTypeIDArr2, out dt3);
            }

            return lngRes;
        }

        [AutoComplete]
        public long m_lngGetGroupEarningCollect1(string strBeginDat, string strEndDat, out DataTable dt1)
        {
            long lngRes = 0;
            dt1 = new DataTable();

            string SQL = @"select  f.usercode_chr,
                                   f.groupname_vchr,
                                   sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                   sum (t3.payment_mny * t3.discount_dec) as totalzcmny,
                                   0 as totaloghmny,
                                   0 as totalozcmny
                              from (select c.groupid_chr, a.registerid_chr
                                      from t_opr_outpatientrecipe a,
                                           t_opr_reciperelation b,
                                           t_opr_outpatientrecipeinv c
                                     where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                       and b.seqid = c.outpatrecipeid_chr
                                       and a.recipeflag_int = 1
                                       and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                       and a.registerid_chr is not null
                                       and c.balance_dat >= to_date(?,'yyyy-mm-dd hh24:mi:ss')
                                       and c.balance_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss')
                                       and a.recorddate_dat =
                                              (select min (recorddate_dat)
                                                 from t_opr_outpatientrecipe
                                                where registerid_chr = a.registerid_chr
                                                  and recipeflag_int = 1
                                                  and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                    (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
                                   t_bse_groupdesc f
                             where t1.registerid_chr = t2.registerid_chr(+)
                               and t1.registerid_chr = t3.registerid_chr(+)
                               and t1.groupid_chr = f.groupid_chr(+)
                          group by f.usercode_chr,f.groupname_vchr";
//            string SQL = @"select  f.usercode_chr,
//                                   f.groupname_vchr,
//                                   sum (t2.payment_mny * t2.discount_dec) as totalghmny,
//                                   sum (t3.payment_mny * t3.discount_dec) as totalzcmny,
//                                   0 as totaloghmny,
//                                   0 as totalozcmny
//                              from (select c.groupid_chr, a.registerid_chr
//                                      from t_opr_outpatientrecipe a,
//                                           t_opr_reciperelation b,
//                                           t_opr_charge c
//                                     where a.outpatrecipeid_chr = b.outpatrecipeid_chr
//                                       and c.chargeno_chr = b.chargeno_chr
//                                       and a.recipeflag_int = 1
//                                       and (a.pstauts_int = 2 or a.pstauts_int = 3)
//                                       and a.registerid_chr is not null
//                                       and c.recdate_dat >= to_date(?,'yyyy-mm-dd hh24:mi:ss')
//                                       and c.recdate_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss')
//                                       and a.recorddate_dat =
//                                              (select min (recorddate_dat)
//                                                 from t_opr_outpatientrecipe
//                                                where registerid_chr = a.registerid_chr
//                                                  and recipeflag_int = 1
//                                                  and (pstauts_int = 2 or pstauts_int = 3))) t1,
//                                    (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
//         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
//                                   t_bse_groupdesc f
//                             where t1.registerid_chr = t2.registerid_chr(+)
//                               and t1.registerid_chr = t3.registerid_chr(+)
//                               and t1.groupid_chr = f.groupid_chr(+)
//                          group by f.usercode_chr,f.groupname_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strBeginDat;
                arrParams[1].Value = strEndDat;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, arrParams);
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

        [AutoComplete]
        public long m_lngGetGroupEarningCollect2(string strBeginDat, string strEndDat, string[] p_strTypeIDArr1, out DataTable dt2)
        {
            long lngRes = 0;
            dt2 = new DataTable();


            StringBuilder sbdSQL = new StringBuilder(@"
                     select f.usercode_chr,
                            f.groupname_vchr,
                            0 as totalghmny,
                            0 as totalzcmny,
                            sum(e1.tolfee_mny) as totaloghmny,
                            0 as totalozcmny
                    from t_opr_outpatientrecipeinv   c1,
                         t_opr_outpatientrecipesumde e1,
                         t_bse_groupdesc             f
                    where c1.seqid_chr = e1.seqid_chr
                      and c1.groupid_chr = f.groupid_chr(+)
                      and (e1.itemcatid_chr = ?");
//            StringBuilder sbdSQL = new StringBuilder(@"select f.usercode_chr,
//                            f.groupname_vchr,
//                            0 as totalghmny,
//                            0 as totalzcmny,
//                            sum(e1.tolfee_mny) as totaloghmny,
//                            0 as totalozcmny
//                    from t_opr_charge   c1,
//                         t_opr_outpatientrecipesumde e1,
//                         t_bse_groupdesc             f
//                    where c1.chargeno_chr = e1.seqid_chr
//                      and c1.groupid_chr = f.groupid_chr(+)
//                      and (e1.itemcatid_chr = ?");
            if (p_strTypeIDArr1.Length > 1)
            {
                sbdSQL.Replace("(+)", "");
            }
            for (int i1 = 1; i1 < p_strTypeIDArr1.Length; i1++)
            {
                sbdSQL.Append(@" or e1.itemcatid_chr = ?");
            }

            sbdSQL.Append(@")  and c1.recdate_dat >= ?
                          and c1.recdate_dat <= ?
                          group by f.usercode_chr, f.groupname_vchr");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2 + p_strTypeIDArr1.Length, out arrParams);

                int intIndex = 0;
                for (int i1 = 0; i1 < p_strTypeIDArr1.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr1[i1];

                }
                intIndex += p_strTypeIDArr1.Length
                    ;
                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat);
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat);
                arrParams[intIndex].DbType = DbType.Date;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSQL.ToString(), ref dt2, arrParams);
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

        [AutoComplete]
        public long m_lngGetGroupEarningCollect3(string strBeginDat, string strEndDat, string[] p_strTypeIDArr2, out DataTable dt3)
        {
            long lngRes = 0;
            dt3 = new DataTable();


            StringBuilder sbdSQL = new StringBuilder(@"
                select   f.usercode_chr, f.groupname_vchr, 0 as totalghmny, 0 as totalzcmny,
                         0 as totaloghmny, sum (e2.tolfee_mny) as totalozcmny
                from t_opr_outpatientrecipeinv c2,
                     t_opr_outpatientrecipesumde e2,
                     t_bse_groupdesc f
                where c2.seqid_chr = e2.seqid_chr
                  and c2.groupid_chr = f.groupid_chr(+)
                  and (e2.itemcatid_chr = ? ");
//            StringBuilder sbdSQL = new StringBuilder(@"select f.usercode_chr, f.groupname_vchr, 0 as totalghmny, 0 as totalzcmny,
//       0 as totaloghmny, sum (e2.tolfee_mny) as totalozcmny
//  from t_opr_charge c2,
//       t_opr_outpatientrecipesumde e2,
//       t_bse_groupdesc f
// where c2.chargeno_chr = e2.chargeno_chr
//   and c2.groupid_chr = f.groupid_chr(+)
//   and (e2.itemcatid_chr = ?)");
            if (p_strTypeIDArr2.Length > 1)
            {
                sbdSQL.Replace("(+)", "");
            }
            for (int i1 = 1; i1 < p_strTypeIDArr2.Length; i1++)
            {
                sbdSQL.Append(@" or e2.itemcatid_chr = ?");
            }

            sbdSQL.Append(@")  and c2.balance_dat >= ?
                         and c2.balance_dat <= ?
                    group by f.usercode_chr, f.groupname_vchr");
//            sbdSQL.Append(@"and c2.recdate_dat>= ?
//and c2.recdate_dat <= ?
//group by f.usercode_chr, f.groupname_vchr");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2 + p_strTypeIDArr2.Length, out arrParams);

                int intIndex = 0;
                for (int i1 = 0; i1 < p_strTypeIDArr2.Length; i1++)
                {
                    arrParams[i1 + intIndex].Value = p_strTypeIDArr2[i1];

                }

                intIndex += p_strTypeIDArr2.Length;
                arrParams[intIndex].Value = Convert.ToDateTime(strBeginDat);
                arrParams[intIndex].DbType = DbType.Date;
                intIndex++;
                arrParams[intIndex].Value = Convert.ToDateTime(strEndDat);
                arrParams[intIndex].DbType = DbType.Date;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(sbdSQL.ToString(), ref dt3, arrParams);
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


        #region MakeSQL
        private string m_strMakeSql(string strSql,string[] strGhfParams, string[] strZcParams)
        {
            int i = strGhfParams.Length,
                j = strZcParams.Length;

            StringBuilder condition1 = new StringBuilder(" and (e1.itemid_chr = '", 100);
            condition1.Append(strGhfParams[0]);
            condition1.Append("'");

            StringBuilder condition2 = new StringBuilder(" and (e2.itemid_chr = '", 100);
            condition2.Append(strZcParams[0]);
            condition2.Append("'");

            for (int a = 1; a < i; a++)
            {
                condition1.Append(" or e1.itemid_chr = '");
                condition1.Append(strGhfParams[a]);
                condition1.Append("'");
            }

            condition1.Append(") ");

            for (int b = 1; b < j; b++)
            {
                condition2.Append(" or e2.itemid_chr = '");
                condition2.Append(strZcParams[b]);
                condition2.Append("'");
            }

            condition2.Append(") ");

            strSql = strSql.Replace("[condition1]", condition1.ToString());
            strSql = strSql.Replace("[condition2]", condition2.ToString());

            return strSql;
        }
        #endregion

        #region 专业组挂号费及诊金汇总表
        /// <summary>
        /// 4.专业组挂号费及诊金汇总表
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectGroupEarningCollect(string strBeginDat, string strEndDat, string[] strGhfParams, string[] strZcParams, out DataTable m_dtbReport)
        {
            long lngRes = -1;
            m_dtbReport = new DataTable();

            string strSql = @"
                select   t9.usercode_chr, t9.groupname_vchr, sum (t7.totalghmny)  as totalghmny,
                         sum (t7.totalzcmny) as totalzcmny, sum (t5.totaloghmny) as totaloghmny, sum (t6.totalozcmny) as totalozcmny
                    from (select   t1.doctorid_chr,
                                   sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                   sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                              from (select c.doctorid_chr, a.registerid_chr
                                      from t_opr_outpatientrecipe a,
                                           t_opr_reciperelation b,
                                           t_opr_outpatientrecipeinv c
                                     where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                       and b.seqid = c.outpatrecipeid_chr
                                       and a.recipeflag_int = 1
                                       and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                       and a.registerid_chr is not null
                                       and c.balance_dat > ?
                                       and c.balance_dat < ?
                                       and a.recorddate_dat =
                                              (select min (recorddate_dat)
                                                 from t_opr_outpatientrecipe
                                                where registerid_chr = a.registerid_chr
                                                  and recipeflag_int = 1
                                                  and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                  (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3
                             where t1.registerid_chr = t2.registerid_chr(+)
                               and t1.registerid_chr = t3.registerid_chr(+)
                          group by t1.doctorid_chr) t7,
                         t_bse_employee t4,
                         (select   c1.doctorid_chr, sum (e1.tolprice_mny) as totaloghmny
                              from t_opr_outpatientrecipe a1,
                                   t_opr_reciperelation b1,
                                   t_opr_outpatientrecipeinv c1,
                                   t_opr_oprecipeitemde e1
                             where a1.outpatrecipeid_chr = b1.outpatrecipeid_chr
                               and b1.seqid = c1.outpatrecipeid_chr
                               and a1.outpatrecipeid_chr = e1.outpatrecipeid_chr
                               and (a1.pstauts_int = 2 or a1.pstauts_int = 3)
                               [condition1]
                               and c1.status_int = 1
                               and c1.balance_dat > ?
                               and c1.balance_dat < ?
                          group by c1.doctorid_chr) t5,
                         (select   c2.doctorid_chr, sum (e2.tolprice_mny) as totalozcmny
                              from t_opr_outpatientrecipe a2,
                                   t_opr_reciperelation b2,
                                   t_opr_outpatientrecipeinv c2,
                                   t_opr_oprecipeitemde e2
                             where a2.outpatrecipeid_chr = b2.outpatrecipeid_chr
                               and b2.seqid = c2.outpatrecipeid_chr
                               and a2.outpatrecipeid_chr = e2.outpatrecipeid_chr
                               and (a2.pstauts_int = 2 or a2.pstauts_int = 3)
                               [condition2]
                               and c2.status_int = 1
                               and c2.balance_dat > ?
                               and c2.balance_dat < ?
                          group by c2.doctorid_chr) t6,
                          (select h.empid_chr,h.groupid_chr,h.begin_dat,i.usercode_chr,i.groupname_vchr 
                                    from t_bse_groupemp h,t_bse_groupdesc i 
                                    where  h.groupid_chr = i.groupid_chr
                                        and h.begin_dat = (select max (begin_dat)
                                                             from t_bse_groupemp
                                                             where empid_chr = h.empid_chr)
                                    ) t9
                   where t4.empid_chr = t7.doctorid_chr(+)
                     and t4.empid_chr = t5.doctorid_chr(+)
                     and t4.empid_chr = t6.doctorid_chr(+)
                     and t4.empid_chr = t9.empid_chr(+)
                group by t9.usercode_chr, t9.groupname_vchr ";

            strSql = m_strMakeSql(strSql, strGhfParams, strZcParams);

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(6, out arrParams);

                int n = -1;
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");
                arrParams[++n].Value = Convert.ToDateTime(strBeginDat + " 00:00:00");
                arrParams[++n].Value = Convert.ToDateTime(strEndDat + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbReport, arrParams);

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

        #region 获取专业组ID和Name
        /// <summary>
        /// 5.1获取专业组ID和Name
        /// </summary>
        /// <param name="strFindCode"></param>
        /// <param name="m_dtbresult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectGroupIdAndName(string strFindCode, out DataTable m_dtbresult)
        {
            long lngRes = -1;
            m_dtbresult = new DataTable();
            string strSql = @"
                    select   a.groupid_chr, a.groupname_vchr, a.usercode_chr
                        from t_bse_groupdesc a
                       where a.usercode_chr like ? or a.groupname_vchr like ?
                    order by sort_int ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                int n = -1;
                arrParams[++n].Value = "%" + strFindCode + "%";
                arrParams[++n].Value = "%" + strFindCode + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtbresult, arrParams);


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


        #region 获取挂号费和诊金参数值
        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="strCode"></param>
        /// <param name="strRst"></param>
        /// <returns></returns>
        private long m_lngGetSysparm(string strCode,out string[] strRst)
        {
            long lngRst = -1;
            string strSql = @"select a.parmvalue_vchr from t_bse_sysparm a where a.parmcode_chr = ?";
            strRst = null;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = strCode;

                DataTable dtResult = null;
                lngRst = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                
                int intRowsNum = dtResult.Rows.Count;
                strRst = dtResult.Rows[0][0].ToString().Split(';');

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRst;
        }

        /// <summary>
        /// 获取补交挂号和诊金的参数值
        /// </summary>
        /// <param name="strGhfCode"></param>
        /// <param name="strZjCode"></param>
        /// <param name="strGhParams"></param>
        /// <param name="strZjParams"></param>
        /// <returns></returns>
        [AutoComplete]
        public void m_mthGetSysparm(string strGhfCode, string strZjCode, out string[] strGhParams, out string[] strZjParams)
        {
            m_lngGetSysparm(strGhfCode, out strGhParams);
            m_lngGetSysparm(strZjCode, out strZjParams);
        }
        #endregion

        #region 初始化 DataTable
        private void m_mthInitDataTable()
        {
            DataTable tb1 = new DataTable();
            tb1.Columns.Add("usercode_chr", typeof(string));
            tb1.Columns.Add("groupname_vchr", typeof(string));
            tb1.Columns.Add("totalghmny", typeof(float));
            tb1.Columns.Add("totalzcmny", typeof(float));
            tb1.Columns.Add("totaloghmny", typeof(float));
            tb1.Columns.Add("totalozcmny", typeof(float));
        }
        #endregion

        #region 专业组挂号费及诊金汇总表（旧）
        /// <summary>
        /// 4.专业组挂号费及诊金汇总表（旧）
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSelectGroupEarningCollect(string strBeginDat, string strEndDat, string strGhfParams, string strZcParams, out DataTable dt1, out DataTable dt2, out DataTable dt3)
        {
            long lngRes = 0;

            dt1 = new DataTable();
            dt2 = new DataTable();
            dt3 = new DataTable();

            lngRes = this.m_lngGroupEarningCollect1(strBeginDat, strEndDat, out dt1);
            lngRes = this.m_lngGroupEarningCollect2(strBeginDat, strEndDat, strGhfParams, out dt2);
            lngRes = this.m_lngGroupEarningCollect3(strBeginDat, strEndDat, strZcParams, out dt3);

            return lngRes;
        }

        [AutoComplete]
        public long m_lngGroupEarningCollect1(string strBeginDat, string strEndDat, out DataTable dt1)
        {
            long lngRes = 0;
            dt1 = new DataTable();

            string SQL = @"select  f.usercode_chr,
                                   f.groupname_vchr,
                                   sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                   sum (t3.payment_mny * t3.discount_dec) as totalzcmny,
                                   0 as totaloghmny,
                                   0 as totalozcmny
                              from (select c.groupid_chr, a.registerid_chr
                                      from t_opr_outpatientrecipe a,
                                           t_opr_reciperelation b,
                                           t_opr_outpatientrecipeinv c
                                     where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                       and b.seqid = c.outpatrecipeid_chr
                                       and a.recipeflag_int = 1
                                       and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                       and a.registerid_chr is not null
                                       and c.balance_dat > to_date(?,'yyyy-mm-dd hh24:mi:ss')
                                       and c.balance_dat < to_date(?,'yyyy-mm-dd hh24:mi:ss')
                                       and a.recorddate_dat =
                                              (select min (recorddate_dat)
                                                 from t_opr_outpatientrecipe
                                                where registerid_chr = a.registerid_chr
                                                  and recipeflag_int = 1
                                                  and (pstauts_int = 2 or pstauts_int = 3))) t1,
                                      (select m.registerid_chr,m.chargeid_chr,m.payment_mny,m.discount_dec from t_opr_patientregdetail m where chargeid_chr = '001') t2,
         (select n.registerid_chr,n.chargeid_chr,n.payment_mny,n.discount_dec from t_opr_patientregdetail n where chargeid_chr = '002') t3,
                                   t_bse_groupdesc f
                             where t1.registerid_chr = t2.registerid_chr(+)
                               and t1.registerid_chr = t3.registerid_chr(+)
                               and t1.groupid_chr = f.groupid_chr(+)
                          group by f.usercode_chr,f.groupname_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);                
                arrParams[0].Value = strBeginDat;
                arrParams[1].Value = strEndDat;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, arrParams);
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

        [AutoComplete]
        public long m_lngGroupEarningCollect2(string strBeginDat, string strEndDat, string strGhfParams, out DataTable dt2)
        {
            long lngRes = 0;
            dt2 = new DataTable();


            string SubSQL = "";

            if (strGhfParams != "")
            {
                SubSQL = " and (e1.itemid_chr in (" + strGhfParams + "))";
            }

            string SQL = @"select f.usercode_chr,
                                  f.groupname_vchr,
                                  0 as totalghmny,
                                  0 as totalzcmny ,
                                  sum (e1.tolprice_mny) as totaloghmny,
                                  0 as totalozcmny
                              from t_opr_outpatientrecipe a1,
                                   t_opr_reciperelation b1,
                                   t_opr_outpatientrecipeinv c1,
                                   t_opr_oprecipeitemde e1,
                                   t_bse_groupdesc f
                             where a1.outpatrecipeid_chr = b1.outpatrecipeid_chr
                               and b1.seqid = c1.outpatrecipeid_chr
                               and a1.outpatrecipeid_chr = e1.outpatrecipeid_chr
                               and c1.groupid_chr = f.groupid_chr(+)
                               and (a1.pstauts_int = 2 or a1.pstauts_int = 3) " + SubSQL + @"                                
                               and c1.status_int = 1
                               and c1.balance_dat > to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and c1.balance_dat < to_date(?,'yyyy-mm-dd hh24:mi:ss')
                          group by f.usercode_chr,f.groupname_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strBeginDat;
                arrParams[1].Value = strEndDat;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt2, arrParams);
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

        [AutoComplete]
        public long m_lngGroupEarningCollect3(string strBeginDat, string strEndDat, string strZcParams, out DataTable dt3)
        {
            long lngRes = 0;
            dt3 = new DataTable();

            string SubSQL = "";           

            if (strZcParams != "")
            {
                SubSQL = " and (e2.itemid_chr in (" + strZcParams + "))";
            }

            string SQL = @"select  f.usercode_chr,
                                   f.groupname_vchr,
                                   0 as totalghmny,
                                   0 as totalzcmny ,
                                   0 as totaloghmny,
                                   sum (e2.tolprice_mny) as totalozcmny
                              from t_opr_outpatientrecipe a2,
                                   t_opr_reciperelation b2,
                                   t_opr_outpatientrecipeinv c2,
                                   t_opr_oprecipeitemde e2,
                                   t_bse_groupdesc f
                             where a2.outpatrecipeid_chr = b2.outpatrecipeid_chr
                               and b2.seqid = c2.outpatrecipeid_chr
                               and a2.outpatrecipeid_chr = e2.outpatrecipeid_chr
                               and c2.groupid_chr = f.groupid_chr(+)
                               and (a2.pstauts_int = 2 or a2.pstauts_int = 3) " + SubSQL + @"                                  
                               and c2.status_int = 1
                               and c2.balance_dat > to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and c2.balance_dat < to_date(?,'yyyy-mm-dd hh24:mi:ss')
                          group by f.usercode_chr,f.groupname_vchr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = strBeginDat;
                arrParams[1].Value = strEndDat;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt3, arrParams);
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
            string strSQLSub1 = string.Empty;
            string strSQL0 = @"select parmvalue_vchr
                                  from t_bse_sysparm t
                                 where t.parmcode_chr = '3069'
                                   and t.status_int = 1";
            try
            {
                clsHRPTableService objSvc = new clsHRPTableService();
                DataTable dtTemp = new DataTable();
                long l = objSvc.lngGetDataTableWithoutParameters(strSQL0, ref dtTemp);
                if (l > 0 && dtTemp.Rows.Count > 0)
                {
                    string strValue = dtTemp.Rows[0][0].ToString();
                    string[] Val = strValue.Split('*');
                    strValue = string.Empty;
                    for (int k = 0; k < Val.Length; k++)
                    {
                        strValue = "'" + Val[k] + "',";
                    }
                    strSQLSub1 = @"and d.INSURANCETYPE_VCHR in (" + strValue.Substring(0, strValue.Length) + ")";
                }
            }
            catch(Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
            }

            DataTable dtT1 = new DataTable();
            DataTable dtT2 = new DataTable();
            DataTable dtT3 = new DataTable();
            DataTable dtT4 = new DataTable();
            DataTable dtT9 = new DataTable();
            DataTable dtT10 = new DataTable();
            DataTable dtT11 = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (intFlag == 0)//按医生
            {
                #region T1
                string strSQLT1 = @"select g.typeid_chr,
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
                                       {0}
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"' 
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                       group by g.typeid_chr,
                                                g.typename_vchr,
                                                a.doctorid_chr, 
                                                e.empno_chr, 
                                                e.lastname_vchr,
                                                e.code_vchr,
                                                e.deptname_vchr";

                if (p_strDoctorID != string.Empty)
                {
                    strSQLSub = @"and a.doctorid_chr in (" + p_strDoctorID + ")";
                }
                strSQLT1 = string.Format(strSQLT1, strSQLSub);
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
                                                   sum(bb.tolprice_mny) tolprice_mny,
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t5,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) xytolprice_mny,
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
                                           t7.tolprice_mny,
                                           t8.xytolprice_mny,
                                           round((t7.tolprice_mny / t8.xytolprice_mny) * 100, 2) as jbybl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) tolprice_mny
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp '" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t7,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) xytolprice_mny
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

                string[] strDtT3JoinColArr = new string[] { "cfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT3, "doctorid_chr", "doctorid_chr", strDtT3JoinColArr);

                string[] strDtT4JoinColArr = new string[] { "kjybl", "tolprice_mny", "xytolprice_mny" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT4, "doctorid_chr", "diagdr_chr", strDtT4JoinColArr);

                string[] strDtT9JoinColArr = new string[] { "jbybl" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT9, "doctorid_chr", "diagdr_chr", strDtT9JoinColArr);

                string[] strDtT10JoinColArr = new string[] { "Counts_KJY" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT10, "doctorid_chr", "doctorid_chr", strDtT10JoinColArr);

                string[] strDtT11JoinColArr = new string[] { "xycfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT11, "doctorid_chr", "doctorid_chr", strDtT11JoinColArr);

                DataView dvJoinResult = dtT1.DefaultView;
                dvJoinResult.Sort = "empno_chr, lastname_vchr, typeid_chr, typename_vchr, zfs, cfs, code_vchr, deptname_vchr, tolprice_mny, xytolprice_mny, kjybl, counts_kjy, xycfs, jbybl";
                DataTable dtFinalResult = dvJoinResult.ToTable();

                for (int i = 0; i < dtFinalResult.Rows.Count - 1; i++)
                {
                    DataRow drFirst = dtFinalResult.Rows[i];
                    DataRow drSecond = dtFinalResult.Rows[i + 1];

                    if (drFirst["empno_chr"] == drSecond["empno_chr"] && drFirst["lastname_vchr"] == drSecond["lastname_vchr"] && drFirst["typeid_chr"] == drSecond["typeid_chr"])
                    {
                        if (drFirst["typename_vchr"] == drSecond["typename_vchr"] && drFirst["zfs"] == drSecond["zfs"] && drFirst["cfs"] == drSecond["cfs"] && drFirst["xytolprice_mnyc"] == drSecond["xytolprice_mnyc"])
                        {
                            if (drFirst["code_vchr"] == drSecond["code_vchr"] && drFirst["deptname_vchr"] == drSecond["deptname_vchr"] && drFirst["tolprice_mny"] == drSecond["tolprice_mny"])
                            {
                                if (drFirst["kjybl"] == drSecond["kjybl"] && drFirst["counts_kjy"] == drSecond["counts_kjy"] && drFirst["xycfs"] == drSecond["xycfs"] && drFirst["jbybl"] == drSecond["jbybl"])
                                {
                                    if (dtFinalResult.Rows[i]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["jxywl"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["jxywl"] = 0;
                                    }
                                    dtFinalResult.Rows[i]["tolfee_mny"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_mny"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_mny"]);
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

                for (int i = 0; i < dtFinalResult.Rows.Count; i++)
                {
                    DataRow drResu = dtResult.NewRow();
                    drResu["typeid_chr"] = dtFinalResult.Rows[i]["typeid_chr"];
                    drResu["typename_vchr"] = dtFinalResult.Rows[i]["typename_vchr"];
                    drResu["empno_chr"] = dtFinalResult.Rows[i]["empno_chr"];
                    drResu["lastname_vchr"] = dtFinalResult.Rows[i]["lastname_vchr"];
                    drResu["zfs"] = dtFinalResult.Rows[i]["zfs"];
                    drResu["cfs"] = dtFinalResult.Rows[i]["cfs"];
                    drResu["code_vchr"] = dtFinalResult.Rows[i]["code_vchr"];
                    drResu["deptname_vchr"] = dtFinalResult.Rows[i]["deptname_vchr"];
                    drResu["tolfee_mny"] = dtFinalResult.Rows[i]["tolfee_mny"];
                    drResu["jxywl"] = dtFinalResult.Rows[i]["jxywl"];
                    drResu["kjybl"] = dtFinalResult.Rows[i]["kjybl"];
                    drResu["tolprice_mny"] = dtFinalResult.Rows[i]["tolprice_mny"];
                    drResu["xytolprice_mny"] = dtFinalResult.Rows[i]["xytolprice_mny"];
                    drResu["jbybl"] = dtFinalResult.Rows[i]["jbybl"];
                    if (dtFinalResult.Rows[i]["Counts_KJY"] != DBNull.Value && dtFinalResult.Rows[i]["xycfs"] != DBNull.Value)
                    {
                        drResu["kjcfbl"] = Math.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["Counts_KJY"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["xycfs"])) * 100, 2);
                    }
                    dtResult.Rows.Add(drResu);
                }

                dtResult.AcceptChanges();
                #endregion
            }

            if (intFlag == 1)//按科室
            {
                #region T1
                string strSQLT1 = @"select g.typeid_chr,
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
                                       and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                       and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                     group by g.typeid_chr,
                                              g.typename_vchr,
                                              a.doctorid_chr,
                                              e.empno_chr,
                                              e.lastname_vchr,
                                              e.code_vchr,
                                              e.deptname_vchr";

                if (DeptIDArr != null && DeptIDArr.Count > 0)
                {
                    string str = "";
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "'" + DeptIDArr[i].ToString() + "',";
                    }
                    strSQLSub = @"and a.deptid_chr in (" + str.Substring(0, str.Length - 1) + ")";
                }
                strSQLT1 = string.Format(strSQLT1, strSQLSub);
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
                                                   sum(bb.tolprice_mny) tolprice_mny,
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t5,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) xytolprice_mny,
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t6
                                     where t5.diagdr_chr = t6.diagdr_chr
                                     group by t5.diagdr_chr, t5.tolprice_mny, t6.xytolprice_mny,t6.zcfs,t5.kjcfs";

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
                                           t7.tolprice_mny,
                                           t8.xytolprice_mny,
                                           round((t7.tolprice_mny / t8.xytolprice_mny) * 100, 2) as jbybl
                                      from (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) tolprice_mny
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
                                               and a.recorddate_dat between to_date('" + p_beginDate + @"', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + p_endDate + @"', 'yyyy-mm-dd hh24:mi:ss')
                                             group by g.lastname_vchr, c.diagdr_chr) t7,
                                           (select g.lastname_vchr,
                                                   c.diagdr_chr,
                                                   sum(bb.tolprice_mny) xytolprice_mny
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
                                               and a.recorddate_dat between timestamp '" + p_beginDate + @"' and timestamp'" + p_endDate + @"'
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

                string[] strDtT3JoinColArr = new string[] { "cfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT3, "doctorid_chr", "doctorid_chr", strDtT3JoinColArr);

                string[] strDtT4JoinColArr = new string[] { "kjybl", "tolprice_mny", "xytolprice_mny" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT4, "doctorid_chr", "diagdr_chr", strDtT4JoinColArr);

                string[] strDtT9JoinColArr = new string[] { "jbybl" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT9, "doctorid_chr", "diagdr_chr", strDtT9JoinColArr);

                string[] strDtT10JoinColArr = new string[] { "Counts_KJY" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT10, "doctorid_chr", "doctorid_chr", strDtT10JoinColArr);

                string[] strDtT11JoinColArr = new string[] { "xycfs" };
                dtT1 = m_dtbDataTableLeftJoin(dtT1, dtT11, "doctorid_chr", "doctorid_chr", strDtT11JoinColArr);

                DataView dvJoinResult = dtT1.DefaultView;
                dvJoinResult.Sort = "empno_chr, lastname_vchr, typeid_chr, typename_vchr, zfs, cfs, code_vchr, deptname_vchr, tolprice_mny, xytolprice_mny, kjybl, counts_kjy, xycfs, jbybl";
                DataTable dtFinalResult = dvJoinResult.ToTable();

                for (int i = 0; i < dtFinalResult.Rows.Count - 1; i++)
                {
                    DataRow drFirst = dtFinalResult.Rows[i];
                    DataRow drSecond = dtFinalResult.Rows[i + 1];

                    if (drFirst["empno_chr"] == drSecond["empno_chr"] && drFirst["lastname_vchr"] == drSecond["lastname_vchr"] && drFirst["typeid_chr"] == drSecond["typeid_chr"])
                    {
                        if (drFirst["typename_vchr"] == drSecond["typename_vchr"] && drFirst["zfs"] == drSecond["zfs"] && drFirst["cfs"] == drSecond["cfs"] && drFirst["xytolprice_mnyc"] == drSecond["xytolprice_mnyc"])
                        {
                            if (drFirst["code_vchr"] == drSecond["code_vchr"] && drFirst["deptname_vchr"] == drSecond["deptname_vchr"] && drFirst["tolprice_mny"] == drSecond["tolprice_mny"])
                            {
                                if (drFirst["kjybl"] == drSecond["kjybl"] && drFirst["counts_kjy"] == drSecond["counts_kjy"] && drFirst["xycfs"] == drSecond["xycfs"] && drFirst["jbybl"] == drSecond["jbybl"])
                                {
                                    if (dtFinalResult.Rows[i]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i]["jxywl"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["tolfee_mny"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["tolfee_mny"] = 0;
                                    }
                                    if (dtFinalResult.Rows[i + 1]["jxywl"] == DBNull.Value)
                                    {
                                        dtFinalResult.Rows[i + 1]["jxywl"] = 0;
                                    }
                                    dtFinalResult.Rows[i]["tolfee_mny"] = Convert.ToDecimal(dtFinalResult.Rows[i]["tolfee_mny"]) + Convert.ToDecimal(dtFinalResult.Rows[i + 1]["tolfee_mny"]);
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

                for (int i = 0; i < dtFinalResult.Rows.Count; i++)
                {
                    DataRow drResu = dtResult.NewRow();
                    drResu["typeid_chr"] = dtFinalResult.Rows[i]["typeid_chr"];
                    drResu["typename_vchr"] = dtFinalResult.Rows[i]["typename_vchr"];
                    drResu["empno_chr"] = dtFinalResult.Rows[i]["empno_chr"];
                    drResu["lastname_vchr"] = dtFinalResult.Rows[i]["lastname_vchr"];
                    drResu["zfs"] = dtFinalResult.Rows[i]["zfs"];
                    drResu["cfs"] = dtFinalResult.Rows[i]["cfs"];
                    drResu["code_vchr"] = dtFinalResult.Rows[i]["code_vchr"];
                    drResu["deptname_vchr"] = dtFinalResult.Rows[i]["deptname_vchr"];
                    drResu["tolfee_mny"] = dtFinalResult.Rows[i]["tolfee_mny"];
                    drResu["jxywl"] = dtFinalResult.Rows[i]["jxywl"];
                    drResu["kjybl"] = dtFinalResult.Rows[i]["kjybl"];
                    drResu["tolprice_mny"] = dtFinalResult.Rows[i]["tolprice_mny"];
                    drResu["xytolprice_mny"] = dtFinalResult.Rows[i]["xytolprice_mny"];
                    drResu["jbybl"] = dtFinalResult.Rows[i]["jbybl"];
                    if (dtFinalResult.Rows[i]["Counts_KJY"] != DBNull.Value && dtFinalResult.Rows[i]["xycfs"] != DBNull.Value)
                    {
                        drResu["kjcfbl"] = Math.Round((Convert.ToDecimal(dtFinalResult.Rows[i]["Counts_KJY"]) / Convert.ToDecimal(dtFinalResult.Rows[i]["xycfs"])) * 100, 2);
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

        #region 门诊未日结汇总报表
        /// <summary>
        /// 门诊未日结汇总报表
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNOCheckOutInvoice(string startDate, string endDate,out DataTable p_dtResult)
        {
            long lngRes = -1;
            p_dtResult = new DataTable();
            p_dtResult = null;

            string strSQL = @"select m.lastname_vchr,m.totalsum_mny, max(t.balance_dat) balance_dat
                              from t_opr_outpatientrecipeinv t,
                                   (select sum(a.totalsum_mny) totalsum_mny, a.opremp_chr,b.lastname_vchr
                                      from t_opr_outpatientrecipeinv a,t_bse_employee b
                                     where a.opremp_chr=b.empid_chr
                                     and a.balanceflag_int = 0
                                       and a.recorddate_dat between
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                           to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                     group by a.opremp_chr,b.lastname_vchr) m
                             where t.opremp_chr = m.opremp_chr 
                             group by m.totalsum_mny,t.opremp_chr,m.lastname_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] arrPara = null;
                objHRPSvc.CreateDatabaseParameter(2,out arrPara);
                arrPara[0].Value = startDate;
                arrPara[1].Value = endDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrPara);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTem = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取病区信息
        /// <summary>
        /// 获取病区信息
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="Flag">1 科室 2 病区</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptArea(out DataTable dt)
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
    }
}
