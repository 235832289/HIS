using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using System.Threading;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 连续性费用
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAutoCharge : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        public clsAutoCharge()
        {
        }
        #endregion

        #region 获取期帐日期信息
        /// <summary>
        /// 获取期帐日期信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetDayAccountsInfo(out DataTable dt)
        {
            long lngRes = 0;

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                string SQL = @"select distinct to_char(a.square_dat, 'yyyy-mm-dd hh24:mi:ss') as feedate, to_char(a.create_dat, 'yyyy-mm-dd hh24:mi:ss') as createdate
                                 from t_opr_bih_dayaccount a 
                                where areaid_chr is null 
                                  and to_char(a.square_dat, 'yyyy-mm-dd hh24:mi:ss') >= to_char(sysdate - 45, 'yyyy-mm-dd hh24:mi:ss')
                                 order by feedate";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 获取期帐最后生成时间
        /// <summary>
        /// 获取期帐最后生成时间
        /// </summary>
        /// <param name="RegID">入院登记ID</param>
        /// <returns></returns>
        [AutoComplete]
        public string GetDayAccountsMaxDate(string RegID)
        {
            string MaxDate = "";
            string SQL = "";

            long l = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                DataTable dt = new DataTable();

                if (RegID != null && RegID != "")
                {
                    SQL = @"select max(to_char(a.square_dat, 'yyyy-mm-dd hh24:mi:ss'))
                             from t_opr_bih_dayaccount a 
                            where registerid_chr = ?";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;

                    l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                }
                else
                {
                    SQL = @"select max(to_char(a.square_dat, 'yyyy-mm-dd hh24:mi:ss'))
                             from t_opr_bih_dayaccount a 
                            where areaid_chr is null ";

                    l = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                }

                if (l > 0 && dt.Rows.Count > 0)
                {
                    MaxDate = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return MaxDate;
        }
        #endregion

        #region 出院结算收取连续性费用
        /// <summary>
        /// 出院结算收取连续性费用
        /// </summary>
        /// <param name="FeeDate"></param>
        /// <param name="OperID"></param>
        /// <param name="RegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long AutoChargeContinueItem(string FeeDate, string OperID, string RegID)
        {
            long lngRes = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                //(住院基础表)连续性频率ID
                string ContiFreqID = "";
                SQL = "select confreqid_chr from t_bse_bih_specordercate where rownum = 1";

                DataTable dt = new DataTable();
                objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);

                if (dt.Rows.Count == 1)
                {
                    ContiFreqID = dt.Rows[0]["confreqid_chr"].ToString().Trim();
                }

                string subwhere = "";

                if (RegID != null && RegID != "")
                {
                    subwhere += " and t1.registerid_chr = '" + RegID + "'";
                }

                /***a、滚连续性费用 - 连续收费(按小时/分钟计费)***/
                SQL = @"/***生成连续性费用(按小时/分钟计费)***/
                        insert into t_opr_bih_patientcharge t5(pchargeid_chr, patientid_chr, registerid_chr, chargeactive_dat,
                                                               orderexectype_int, clacarea_chr, createarea_chr, calccateid_chr,
                                                               invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                               unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr,
                                                               createtype_int, creator_chr, create_dat, status_int, pstatus_int,
                                                               activator_chr, activatetype_int, isrich_int, orderid_chr, curareaid_chr, curbedid_chr, 
                                                               doctorid_chr, doctor_vchr, doctorgroupid_chr, totalmoney_dec, chargedoctorid_chr, 
                                                               chargedoctor_vchr, chargedoctorgroupid_chr)
                                                        select lpad (seq_pchargeid.nextval, 18, '0') as pchargeid_chr,
                                                               t1.patientid_chr, t1.registerid_chr,
                                                               to_date('" + FeeDate + @"','yyyy-mm-dd hh24:mi:ss') as chargeactive_dat,
                                                               0 as orderexectype_int, t2.clacarea_chr as clacarea_chr,
                                                               t2.createarea_chr as createarea_chr, t3.itemipcalctype_chr,
                                                               t3.itemipinvtype_chr, t3.itemid_chr, t3.itemname_vchr,
                                                               t2.unit_vchr, t2.unitprice_dec, ceil(case t3.keepuse_int when 0 then t2.timespan/60 when 1 then t2.timespan/3600 end) * t2.amount_dec as amount_dec,
                                                               100 as discount_dec, 1 as ismepay_int, '*LXF0*' as des_vchr,
                                                               2 as createtype_int, '" + OperID + @"' as creator_chr, sysdate as create_dat,
                                                               1 as status_int, 1 as pstatus_int, '" + OperID + @"' as activator_chr,
                                                               1 as activatetype_int, 0 as isrich_int, t2.orderid_chr, t2.curareaid_chr, t1.bedid_chr,
                                                               t1.casedoctor_chr, tbemp.lastname_vchr, tbemp.groupid_chr, t2.unitprice_dec * ceil(case t3.keepuse_int when 0 then t2.timespan/60 when 1 then t2.timespan/3600 end) * t2.amount_dec as totalmoney, 
                                                               t2.creatorid_chr, t2.creator_chr, t2.chargedoctorgroupid_chr            
                                                         from t_opr_bih_register t1,
                                                              (select a.orderid_chr, a.registerid_chr, b.chargeitemid_chr, b.unit_vchr, b.unitprice_dec, b.amount_dec,  
                                                                       (a.finishdate_dat - a.startdate_dat) * 24 * 60 * 60 AS timespan, a.creatorid_chr, a.creator_chr, a.chargedoctorgroupid_chr,b.clacarea_chr, b.createarea_chr,a.curareaid_chr
                                                                  from t_opr_bih_order a,
                                                                       t_opr_bih_orderchargedept b
                                                                 where a.orderid_chr = b.orderid_chr 
                                                                   and a.execfreqid_chr =  '" + ContiFreqID + @"'     
                                                                   and a.startdate_dat is not null 
                                                                   and a.executetype_int = 1  
                                                                   and (a.status_int <> -2 and a.status_int <> -1 and a.status_int <> 7)  
                                                                   and b.continueusetype_int = 0 
                                                                   and b.continuefreqid_chr is null       
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"'
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd') =
                                                                                                      to_char (a.finishdate_dat, 'yyyy-mm-dd')
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + @"'
                                                                union all
                                                                select a.orderid_chr, a.registerid_chr, b.chargeitemid_chr, b.unit_vchr, b.unitprice_dec, b.amount_dec,   
                                                                         (  to_date ('" + FeeDate.ToString() + @"',
                                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                                    )
                                                                          - a.startdate_dat
                                                                         )
                                                                       * 24
                                                                       * 60
                                                                       * 60 AS timespan, a.creatorid_chr, a.creator_chr, a.chargedoctorgroupid_chr,b.clacarea_chr, b.createarea_chr,a.curareaid_chr
                                                                  from t_opr_bih_order a,
                                                                       t_opr_bih_orderchargedept b 
                                                                 where a.orderid_chr = b.orderid_chr 
                                                                   and a.execfreqid_chr =  '" + ContiFreqID + @"'   
                                                                   and a.startdate_dat is not null 
                                                                   and b.continueusetype_int = 0 
                                                                   and b.continuefreqid_chr is null 
                                                                   and a.executetype_int = 1 
                                                                   and (a.status_int <> -2 and a.status_int <> -1 and a.status_int <> 7)       
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"'
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + @"' 
                                                                   and (a.finishdate_dat is null or to_char (a.finishdate_dat, 'yyyy-mm-dd') > '" + FeeDate.Substring(0, 10) + @"')
                                                                union all
                                                                select a.orderid_chr, a.registerid_chr, b.chargeitemid_chr, b.unit_vchr, b.unitprice_dec, b.amount_dec,    
                                                                       1 * 24 * 60 * 60 AS timespan, a.creatorid_chr, a.creator_chr, a.chargedoctorgroupid_chr,b.clacarea_chr, b.createarea_chr,a.curareaid_chr
                                                                  from t_opr_bih_order a,
                                                                       t_opr_bih_orderchargedept b
                                                                 where a.orderid_chr = b.orderid_chr 
                                                                   and a.execfreqid_chr =  '" + ContiFreqID + @"'    
                                                                   and a.startdate_dat is not null 
                                                                   and a.executetype_int = 1 
                                                                   and (a.status_int <> -2 and a.status_int <> -1 and a.status_int <> 7)     
                                                                   and b.continueusetype_int = 0 
                                                                   and b.continuefreqid_chr is null  
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"' 
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd') < '" + FeeDate.Substring(0, 10) + @"' 
                                                                   and (a.finishdate_dat is null or to_char (a.finishdate_dat, 'yyyy-mm-dd') > '" + FeeDate.Substring(0, 10) + @"') 
                                                                union all
                                                                select a.orderid_chr, a.registerid_chr, b.chargeitemid_chr, b.unit_vchr, b.unitprice_dec, b.amount_dec,    
                                                                         (  a.finishdate_dat
                                                                          - to_date ('" + FeeDate.Substring(0, 10) + @" 00:00:00',
                                                                                     'yyyy-mm-dd hh24:mi:ss'
                                                                                    )
                                                                         )
                                                                       * 24
                                                                       * 60
                                                                       * 60 AS timespan, a.creatorid_chr, a.creator_chr, a.chargedoctorgroupid_chr,b.clacarea_chr, b.createarea_chr,a.curareaid_chr
                                                                  from t_opr_bih_order a,
                                                                       t_opr_bih_orderchargedept b
                                                                 where a.orderid_chr = b.orderid_chr 
                                                                   and a.execfreqid_chr =  '" + ContiFreqID + @"'     
                                                                   and a.startdate_dat is not null 
                                                                   and a.executetype_int = 1 
                                                                   and (a.status_int <> -2 and a.status_int <> -1 and a.status_int <> 7)                                                                               
                                                                   and b.continueusetype_int = 0 
                                                                   and b.continuefreqid_chr is null   
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"'
                                                                   and to_char (a.startdate_dat, 'yyyy-mm-dd') < '" + FeeDate.Substring(0, 10) + @"' 
                                                                   and to_char (a.finishdate_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + @"') t2,
                                                              t_bse_chargeitem t3,                                                                
                                                              ( select a.empid_chr, a.lastname_vchr, b.groupid_chr
                                                                  from t_bse_employee a, t_bse_groupemp b
                                                                 where a.empid_chr = b.empid_chr(+) 
                                                                   and a.status_int = 1 
                                                                   and b.end_dat is null ) tbemp   
                                                        where t1.status_int = 1         
                                                          and t1.registerid_chr = t2.registerid_chr 
                                                          and t3.itemid_chr = t2.chargeitemid_chr 
                                                          and t1.casedoctor_chr = tbemp.empid_chr(+)                                        
                                                          and to_char(t1.inpatient_dat, 'yyyy-mm-dd') <= '" + FeeDate.Substring(0, 10) + @"'                                                          
                                                          and not exists (
                                                                 select 1
                                                                   from t_opr_bih_patientcharge c
                                                                  where c.registerid_chr = t1.registerid_chr
                                                                    and t2.orderid_chr = c.orderid_chr
                                                                    and c.des_vchr = '*LXF0*'
                                                                    and to_char(c.chargeactive_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + "')" + subwhere;

                lngRes = objHRPSvc.DoExcute(SQL);
                Thread.Sleep(1000);

                SQL = @"/***生成连续性费用 - 首日记费***/
                        insert into t_opr_bih_patientcharge t5(pchargeid_chr, patientid_chr, registerid_chr, chargeactive_dat,
                                                               orderexectype_int, clacarea_chr, createarea_chr, calccateid_chr,
                                                               invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                               unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr,
                                                               createtype_int, creator_chr, create_dat, status_int, pstatus_int,
                                                               activator_chr, activatetype_int, isrich_int, orderid_chr, curareaid_chr, curbedid_chr, 
                                                               doctorid_chr, doctor_vchr, doctorgroupid_chr, totalmoney_dec, chargedoctorid_chr, 
                                                               chargedoctor_vchr, chargedoctorgroupid_chr) 
                                                        select lpad (seq_pchargeid.nextval, 18, '0') as pchargeid_chr,
                                                               t1.patientid_chr, t1.registerid_chr,
                                                               to_date('" + FeeDate + @"','yyyy-mm-dd hh24:mi:ss') as chargeactive_dat,
                                                               0 as orderexectype_int,  t4.clacarea_chr as clacarea_chr,
                                                               t4.createarea_chr as createarea_chr, t3.itemipcalctype_chr,
                                                               t3.itemipinvtype_chr, t3.itemid_chr, t3.itemname_vchr,
                                                               t4.unit_vchr, t4.unitprice_dec, t4.amount_dec as amount_dec,
                                                               100 as discount_dec, 1 as ismepay_int, '*LXF1*' as des_vchr,
                                                               2 as createtype_int, '" + OperID + @"' as creator_chr, sysdate as create_dat,
                                                               1 as status_int, 1 as pstatus_int, '" + OperID + @"' as activator_chr,
                                                               1 as activatetype_int, 0 as isrich_int, t2.orderid_chr,t2.curareaid_chr, t1.bedid_chr,
                                                               t1.casedoctor_chr, tbemp.lastname_vchr, tbemp.groupid_chr, t4.unitprice_dec * t4.amount_dec as totalmoney, 
                                                               t2.creatorid_chr, t2.creator_chr, t2.chargedoctorgroupid_chr    
                                                         from t_opr_bih_register t1,
                                                              t_opr_bih_order t2,                                                                                                                            
                                                              t_bse_chargeitem t3,
                                                              t_opr_bih_orderchargedept t4,                                                                
                                                              ( select a.empid_chr, a.lastname_vchr, b.groupid_chr
                                                                  from t_bse_employee a, t_bse_groupemp b
                                                                 where a.empid_chr = b.empid_chr(+) 
                                                                   and a.status_int = 1 
                                                                   and b.end_dat is null ) tbemp  
                                                        where t1.status_int = 1         
                                                          and t1.registerid_chr = t2.registerid_chr                                                           
                                                          and t2.execfreqid_chr =  '" + ContiFreqID + @"'     
                                                          and t2.orderid_chr = t4.orderid_chr  
                                                          and t3.itemid_chr = t4.chargeitemid_chr 
                                                          and t2.executetype_int = 1           
                                                          and t2.startdate_dat is not null 
                                                          and (t2.status_int <> -2 and t2.status_int <> -1 and t2.status_int <> 7)    
                                                          and t1.casedoctor_chr = tbemp.empid_chr(+) 
                                                          and (to_char (t2.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"' and 
                                                               to_char (t2.startdate_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + @"' )          
                                                          and t4.continueusetype_int = 1 
                                                          and t4.continuefreqid_chr is null                                                
                                                          and to_char(t1.inpatient_dat, 'yyyy-mm-dd') <= '" + FeeDate.Substring(0, 10) + @"'                                                          
                                                          and not exists (
                                                                 select 1
                                                                   from t_opr_bih_patientcharge c
                                                                  where c.registerid_chr = t1.registerid_chr
                                                                    and t2.orderid_chr = c.orderid_chr
                                                                    and c.des_vchr = '*LXF1*'
                                                                    and to_char(c.chargeactive_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + "')" + subwhere;

                lngRes = objHRPSvc.DoExcute(SQL);
                Thread.Sleep(1000);

                SQL = @"/***生成连续性费用 - 每日按频率次数记费***/
                        insert into t_opr_bih_patientcharge t5(pchargeid_chr, patientid_chr, registerid_chr, chargeactive_dat,
                                                               orderexectype_int, clacarea_chr, createarea_chr, calccateid_chr,
                                                               invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                               unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr,
                                                               createtype_int, creator_chr, create_dat, status_int, pstatus_int,
                                                               activator_chr, activatetype_int, isrich_int, orderid_chr, curareaid_chr, curbedid_chr, 
                                                               doctorid_chr, doctor_vchr, doctorgroupid_chr, totalmoney_dec, chargedoctorid_chr, 
                                                               chargedoctor_vchr, chargedoctorgroupid_chr)
                                                        select lpad (seq_pchargeid.nextval, 18, '0') as pchargeid_chr,
                                                               t1.patientid_chr, t1.registerid_chr,
                                                               to_date('" + FeeDate + @"','yyyy-mm-dd hh24:mi:ss') as chargeactive_dat,
                                                               0 as orderexectype_int, t4.clacarea_chr as clacarea_chr,
                                                               t4.createarea_chr as createarea_chr, t3.itemipcalctype_chr,
                                                               t3.itemipinvtype_chr, t3.itemid_chr, t3.itemname_vchr,
                                                               t4.unit_vchr, t4.unitprice_dec, ceil(t6.times_int/t6.days_int) * t4.amount_dec as amount_dec,
                                                               100 as discount_dec, 1 as ismepay_int, '*LXF2*' as des_vchr,
                                                               2 as createtype_int, '" + OperID + @"' as creator_chr, sysdate as create_dat,
                                                               1 as status_int, 1 as pstatus_int, '" + OperID + @"' as activator_chr,
                                                               1 as activatetype_int, 0 as isrich_int, t2.orderid_chr, t2.curareaid_chr, t1.bedid_chr,
                                                               t1.casedoctor_chr, tbemp.lastname_vchr, tbemp.groupid_chr, t4.unitprice_dec * ceil(t6.times_int/t6.days_int) * t4.amount_dec as totalmoney, 
                                                               t2.creatorid_chr, t2.creator_chr, t2.chargedoctorgroupid_chr   
                                                         from t_opr_bih_register t1,
                                                              t_opr_bih_order t2,                                                                                                                            
                                                              t_bse_chargeitem t3,
                                                              t_opr_bih_orderchargedept t4,                                                                
                                                              t_aid_recipefreq t6,                                                                
                                                              ( select a.empid_chr, a.lastname_vchr, b.groupid_chr
                                                                  from t_bse_employee a, t_bse_groupemp b
                                                                 where a.empid_chr = b.empid_chr(+) 
                                                                   and a.status_int = 1 
                                                                   and b.end_dat is null ) tbemp    
                                                        where t1.status_int = 1         
                                                          and t1.registerid_chr = t2.registerid_chr                                                           
                                                          and t2.execfreqid_chr =  '" + ContiFreqID + @"'     
                                                          and t2.orderid_chr = t4.orderid_chr  
                                                          and t3.itemid_chr = t4.chargeitemid_chr 
                                                          and t2.executetype_int = 1 
                                                          and (t2.status_int <> -2 and t2.status_int <> -1 and t2.status_int <> 7)    
                                                          and t1.casedoctor_chr = tbemp.empid_chr(+)  
                                                          and (t2.startdate_dat is not null and to_char (t2.startdate_dat, 'yyyy-mm-dd hh24:mi:ss') < '" + FeeDate + @"' )
                                                          and (t2.finishdate_dat is null or 
                                                               to_char (t2.finishdate_dat, 'yyyy-mm-dd') >= '" + FeeDate.Substring(0, 10) + @"' )          
                                                          and t4.continuefreqid_chr = t6.freqid_chr                                               
                                                          and to_char(t1.inpatient_dat, 'yyyy-mm-dd') <= '" + FeeDate.Substring(0, 10) + @"'                                                          
                                                          and not exists (
                                                                 select 1
                                                                   from t_opr_bih_patientcharge c
                                                                  where c.registerid_chr = t1.registerid_chr 
                                                                    and t2.orderid_chr = c.orderid_chr
                                                                    and c.des_vchr = '*LXF2*'
                                                                    and to_char(c.chargeactive_dat, 'yyyy-mm-dd') = '" + FeeDate.Substring(0, 10) + "')" + subwhere;

                lngRes = objHRPSvc.DoExcute(SQL);
                Thread.Sleep(1000);
            }
            catch (System.Exception objEx)
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
