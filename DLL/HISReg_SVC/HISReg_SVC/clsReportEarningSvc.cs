using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.HIS;
using System.Text;


namespace com.digitalwave.iCare.middletier.HIS
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

            string strSql = @"
                        select   t6.usercode_chr, t6.groupname_vchr,
                                 sum (t2.payment_mny * t2.discount_dec) as totalghmny,
                                 sum (t3.payment_mny * t3.discount_dec) as totalzcmny
                            from (select a.groupid_chr, a.registerid_chr
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
                                 t_bse_groupdesc t6
                           where t1.registerid_chr = t2.registerid_chr(+)
                             and t1.registerid_chr = t3.registerid_chr(+)
                             and t1.groupid_chr = t6.groupid_chr(+)
                        group by t6.usercode_chr, t6.groupname_vchr
                    ";

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
            StringBuilder sbdSql = new StringBuilder (
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
            lngRes = this.m_lngGetGroupEarningCollect2(strBeginDat, strEndDat, p_strTypeIDArr1, out dt2);
            lngRes = this.m_lngGetGroupEarningCollect3(strBeginDat, strEndDat, p_strTypeIDArr2, out dt3);

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


            StringBuilder sbdSQL = new StringBuilder (@"
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
            for (int i1 = 1; i1 < p_strTypeIDArr1.Length; i1++)
            {
                sbdSQL.Append(@" or e1.itemcatid_chr = ?");
            }

            sbdSQL.Append(@")  and c1.balance_dat >= ?
                          and c1.balance_dat <= ?
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
            for (int i1 = 1; i1 < p_strTypeIDArr2.Length; i1++)
            {
                sbdSQL.Append(@" or e2.itemcatid_chr = ?");
            }

            sbdSQL.Append(@")  and c2.balance_dat >= ?
                         and c2.balance_dat <= ?
                    group by f.usercode_chr, f.groupname_vchr");

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
    }
}
