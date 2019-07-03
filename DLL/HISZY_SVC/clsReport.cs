using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
//using Oracle.DataAccess.Client;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReport : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsReport()
        {

        }
        #endregion

        #region 根据报表编号获取住院核算分类
        /// <summary>
        /// 根据报表编号获取住院核算分类
        /// </summary>
        /// <param name="RptID">自定义报表ID</param>
        /// <param name="Flag">3 住院核算分类 4 住院发票分类</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCatIDByRptID(string RptID, int Flag, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.rptid_chr, a.groupid_chr, a.typeid_chr, a.flag_int
                              from t_aid_rpt_gop_rla a 
                             where a.flag_int = ? 
                               and a.rptid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Flag;
                ParamArr[1].Value = RptID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 每日清单
        /// <summary>
        /// 每日清单(主信息)
        /// </summary>        
        /// <param name="RegID">住院登记流水ID</param>
        /// <param name="BillDate">清单日期</param> 
        /// <param name="objEveryDayBill"></param> 
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptEveryDayBill(string RegID, string BillDate, out clsBihEveryDayBill_VO objEveryDayBill)
        {
            long lngRes = 0;
            string SQL = "";
            DataTable dt = new DataTable();

            objEveryDayBill = new clsBihEveryDayBill_VO();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //1、住院号、姓名 ...
                SQL = @"select a.inpatientid_chr, c.lastname_vchr, d.deptname_vchr, b.code_chr
                          from t_opr_bih_register a, t_bse_bed b, 
                               t_opr_bih_registerdetail c, t_bse_deptdesc D 
                         where a.registerid_chr = b.bihregisterid_chr(+)
                           and a.registerid_chr = c.registerid_chr
                           and a.bedid_chr = b.bedid_chr(+) 
                           and a.areaid_chr = d.deptid_chr 
                           and a.status_int = 1 
                           and a.registerid_chr = ? 
                      order by b.code_chr";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    objEveryDayBill.Zyh = dt.Rows[0]["inpatientid_chr"].ToString();
                    objEveryDayBill.Name = dt.Rows[0]["lastname_vchr"].ToString();
                    objEveryDayBill.AreaName = dt.Rows[0]["deptname_vchr"].ToString();
                    objEveryDayBill.BedNO = dt.Rows[0]["code_chr"].ToString();
                }

                //2、总费用、当日费用合计、已清费用、欠费合计
                SQL = @"select nvl((select sum(round(a.unitprice_dec * a.amount_dec,2)) 
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and a.pstatus_int <> 0  
                           and a.chargeactive_dat is not null 
                           and a.chargeactive_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')                                                           
                           and a.registerid_chr = ?), 0) as AllTotal,
                         nvl((select sum(round(a.totaldiffcostmoney_dec, 2))
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and a.pstatus_int <> 0  
                           and a.chargeactive_dat is not null 
                           and a.chargeactive_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')                                                           
                           and a.registerid_chr = ?), 0) as ALLDIFFTOTAL ,   
                  
                                                  
                            nvl((select sum(round(a.unitprice_dec * a.amount_dec, 2))
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat is not null 
                           and to_char(a.chargeactive_dat, 'yyyy-mm-dd') = ?     
                           and a.registerid_chr = ?), 0) as CurrDayTotal,
                                 nvl((select sum(round(a.totaldiffcostmoney_dec, 2))
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat is not null 
                           and to_char(a.chargeactive_dat, 'yyyy-mm-dd') = ?     
                           and a.registerid_chr = ?), 0) as CurrDayDiffTotal,
                           nvl((select sum(round(a.unitprice_dec * a.amount_dec, 2))
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and a.chargeactive_dat is not null  
                           and a.chargeactive_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')   
                           and (a.pstatus_int = 1 or a.pstatus_int = 2)                            
                           and a.registerid_chr = ?), 0) as ArrearageTotal,  
                       nvl((select sum(round(a.unitprice_dec * a.amount_dec, 2))
                          from t_opr_bih_patientcharge a 
                         where a.status_int = 1 
                           and (a.pstatus_int = 3 or a.pstatus_int = 4)
                           and a.chargeactive_dat is not null 
                           and a.chargeactive_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss')                               
                           and a.registerid_chr = ?), 0) as ClearTotal   
                       from dual";

                decimal ArrearageTotal = 0;
                decimal PrePayMoney = 0;

                objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
                ParamArr[0].Value = BillDate + " 23:59:59";
                ParamArr[1].Value = RegID;
                ParamArr[2].Value = BillDate + " 23:59:59";
                ParamArr[3].Value = RegID;
                ParamArr[4].Value = BillDate;
                ParamArr[5].Value = RegID;
                ParamArr[6].Value = BillDate;
                ParamArr[7].Value = RegID;
                ParamArr[8].Value = BillDate + " 23:59:59";
                ParamArr[9].Value = RegID;
                ParamArr[10].Value = BillDate + " 23:59:59";
                ParamArr[11].Value = RegID;



                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    objEveryDayBill.AllTotal = dt.Rows[0]["AllTotal"].ToString();
                    objEveryDayBill.CurrDayTotal = dt.Rows[0]["CurrDayTotal"].ToString();
                    objEveryDayBill.ClearTotal = dt.Rows[0]["ClearTotal"].ToString();
                    ArrearageTotal = Convert.ToDecimal(dt.Rows[0]["ArrearageTotal"].ToString());
                    objEveryDayBill.m_decTotalDiffCost = Convert.ToDecimal(dt.Rows[0]["ALLDIFFTOTAL"].ToString());
                    objEveryDayBill.m_decDayTotalDiffCost = Convert.ToDecimal(dt.Rows[0]["CurrDayDiffTotal"].ToString());

                }

                //3、预交金
                SQL = @"select nvl(sum(nvl(a.money_dec,0)), 0)  
                          from t_opr_bih_prepay a
                         where a.status_int = 1 
                           and a.isclear_int = 0                            
                           and a.create_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss')   
                           and a.registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BillDate + " 23:59:59";
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    PrePayMoney = Convert.ToDecimal(dt.Rows[0][0].ToString());
                    objEveryDayBill.PrePayMoney = PrePayMoney.ToString();
                }
                objEveryDayBill.ArrearageTotal = Convert.ToString(PrePayMoney - ArrearageTotal);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 每日清单(分类费用)
        /// </summary>
        /// <param name="ID">1-病区ID 2-住院登记流水ID 3-住院号</param>        
        /// <param name="BillDate">清单日期</param>
        /// <param name="Type">类型：1 按病区 2 按床位 3 按住院号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptEveryDayBillFee(string ID, string BillDate, int Type, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            if (Type == 1)
            {
                SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
                               a.orderid_chr, a.orderexectype_int, a.orderexecid_chr, a.clacarea_chr,
                               a.createarea_chr, a.calccateid_chr, a.invcateid_chr,
                               a.chargeitemid_chr, a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec,
                               a.amount_dec, a.discount_dec, a.ismepay_int, a.des_vchr,
                               a.createtype_int, a.creator_chr, a.create_dat, a.operator_chr,
                               a.modify_dat, a.deactivator_chr, a.deactivate_dat, a.status_int,
                               a.pstatus_int, a.chearaccount_dat, a.dayaccountid_chr,
                               a.paymoneyid_chr, a.activator_chr, a.activatetype_int, a.isrich_int,
                               a.isconfirmrefundment, a.refundmentchecker, a.refundmentdate,
                               a.bmstatus_int, a.curareaid_chr, a.curbedid_chr, a.doctorid_chr,
                               a.doctor_vchr, a.doctorgroupid_chr, a.needconfirm_int,
                               a.confirmerid_chr, a.confirmer_vchr, a.confirm_dat, a.chargeactive_dat,
                               a.insuracedesc_vchr, a.spec_vchr, a.totalmoney_dec, a.acctmoney_dec,
                               a.patientnurse_int, a.newdiscount_dec, a.attachorderid_vchr,
                               a.attachorderbasenum_dec, a.putmedicineflag_int, a.chargedoctorid_chr,
                               a.chargedoctor_vchr, a.pchargeidorg_chr, 
                               b.code_chr as bedcode,a.totaldiffcostmoney_dec  
                          from t_opr_bih_patientcharge a,
                               t_bse_bed b   
                         where a.registerid_chr = b.bihregisterid_chr(+)
                           and a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')";

                if (ID == "00")
                {
                    SQL += @" and exists (
                                      select 1
                                        from t_opr_bih_register c
                                       where a.registerid_chr = c.registerid_chr
                                         and (c.pstatus_int = 1 or c.pstatus_int = 4))";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                }
                else
                {
                    SQL += @" and exists (
                                      select 1
                                        from t_opr_bih_register c
                                       where a.registerid_chr = c.registerid_chr
                                         and (c.pstatus_int = 1 or c.pstatus_int = 4)
                                         and c.areaid_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                    ParamArr[2].Value = ID;
                }

                SQL += " order by b.code_chr";
            }
            else if (Type == 2)
            {
                SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
                               a.orderid_chr, a.orderexectype_int, a.orderexecid_chr, a.clacarea_chr,
                               a.createarea_chr, a.calccateid_chr, a.invcateid_chr,
                               a.chargeitemid_chr, a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec,
                               a.amount_dec, a.discount_dec, a.ismepay_int, a.des_vchr,
                               a.createtype_int, a.creator_chr, a.create_dat, a.operator_chr,
                               a.modify_dat, a.deactivator_chr, a.deactivate_dat, a.status_int,
                               a.pstatus_int, a.chearaccount_dat, a.dayaccountid_chr,
                               a.paymoneyid_chr, a.activator_chr, a.activatetype_int, a.isrich_int,
                               a.isconfirmrefundment, a.refundmentchecker, a.refundmentdate,
                               a.bmstatus_int, a.curareaid_chr, a.curbedid_chr, a.doctorid_chr,
                               a.doctor_vchr, a.doctorgroupid_chr, a.needconfirm_int,
                               a.confirmerid_chr, a.confirmer_vchr, a.confirm_dat, a.chargeactive_dat,
                               a.insuracedesc_vchr, a.spec_vchr, a.totalmoney_dec, a.acctmoney_dec,
                               a.patientnurse_int, a.newdiscount_dec, a.attachorderid_vchr,
                               a.attachorderbasenum_dec, a.putmedicineflag_int, a.chargedoctorid_chr,
                               a.chargedoctor_vchr, a.pchargeidorg_chr, 
                               b.code_chr as bedcode,a.totaldiffcostmoney_dec 
                          from t_opr_bih_patientcharge a, 
                               t_bse_bed b  
                         where a.registerid_chr = b.bihregisterid_chr(+)
                           and a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                           and a.registerid_chr = ? 
                      order by b.code_chr";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 3)
            {
                SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
                               a.orderid_chr, a.orderexectype_int, a.orderexecid_chr, a.clacarea_chr,
                               a.createarea_chr, a.calccateid_chr, a.invcateid_chr,
                               a.chargeitemid_chr, a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec,
                               a.amount_dec, a.discount_dec, a.ismepay_int, a.des_vchr,
                               a.createtype_int, a.creator_chr, a.create_dat, a.operator_chr,
                               a.modify_dat, a.deactivator_chr, a.deactivate_dat, a.status_int,
                               a.pstatus_int, a.chearaccount_dat, a.dayaccountid_chr,
                               a.paymoneyid_chr, a.activator_chr, a.activatetype_int, a.isrich_int,
                               a.isconfirmrefundment, a.refundmentchecker, a.refundmentdate,
                               a.bmstatus_int, a.curareaid_chr, a.curbedid_chr, a.doctorid_chr,
                               a.doctor_vchr, a.doctorgroupid_chr, a.needconfirm_int,
                               a.confirmerid_chr, a.confirmer_vchr, a.confirm_dat, a.chargeactive_dat,
                               a.insuracedesc_vchr, a.spec_vchr, a.totalmoney_dec, a.acctmoney_dec,
                               a.patientnurse_int, a.newdiscount_dec, a.attachorderid_vchr,
                               a.attachorderbasenum_dec, a.putmedicineflag_int, a.chargedoctorid_chr,
                               a.chargedoctor_vchr, a.pchargeidorg_chr, 
                               b.code_chr as bedcode,a.totaldiffcostmoney_dec 
                          from t_opr_bih_patientcharge a, 
                               t_bse_bed b,
                               (select tb1.registerid_chr, tb1.inpatientid_chr 
                                   from t_opr_bih_register tb1
                                   where exists (select 1
                                                   from (select max(tb2.registerid_chr) as registerid_chr
                                                           from t_opr_bih_register tb2
                                                           group by tb2.inpatientid_chr) tb2
                                                   where tb1.registerid_chr = tb2.registerid_chr)
                                ) c  
                         where a.registerid_chr = b.bihregisterid_chr(+) 
                           and a.registerid_chr = c.registerid_chr 
                           and a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                           and c.inpatientid_chr = ? 
                      order by b.code_chr";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 4)
            {
                SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
                               a.orderid_chr, a.orderexectype_int, a.orderexecid_chr, a.clacarea_chr,
                               a.createarea_chr, a.calccateid_chr, a.invcateid_chr,
                               a.chargeitemid_chr, a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec,
                               a.amount_dec, a.discount_dec, a.ismepay_int, a.des_vchr,
                               a.createtype_int, a.creator_chr, a.create_dat, a.operator_chr,
                               a.modify_dat, a.deactivator_chr, a.deactivate_dat, a.status_int,
                               a.pstatus_int, a.chearaccount_dat, a.dayaccountid_chr,
                               a.paymoneyid_chr, a.activator_chr, a.activatetype_int, a.isrich_int,
                               a.isconfirmrefundment, a.refundmentchecker, a.refundmentdate,
                               a.bmstatus_int, a.curareaid_chr, a.curbedid_chr, a.doctorid_chr,
                               a.doctor_vchr, a.doctorgroupid_chr, a.needconfirm_int,
                               a.confirmerid_chr, a.confirmer_vchr, a.confirm_dat, a.chargeactive_dat,
                               a.insuracedesc_vchr, a.spec_vchr, a.totalmoney_dec, a.acctmoney_dec,
                               a.patientnurse_int, a.newdiscount_dec, a.attachorderid_vchr,
                               a.attachorderbasenum_dec, a.putmedicineflag_int, a.chargedoctorid_chr,
                               a.chargedoctor_vchr, a.pchargeidorg_chr, 
                               b.code_chr as bedcode,a.totaldiffcostmoney_dec  
                          from t_opr_bih_patientcharge a, 
                               t_bse_bed b  
                         where a.registerid_chr = b.bihregisterid_chr(+)
                           and a.status_int = 1 
                           and a.pstatus_int <> 0 
                           and a.chargeactive_dat between ? and ?
                           and a.registerid_chr in ([ArrBedno]) 
                      order by b.code_chr";

                SQL = SQL.Replace("[ArrBedno]", ID);
                //clsHRPTableService objHRPSvc = new clsHRPTableService();
                //IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = DateTime.Parse(BillDate + " 00:00:00");
                ParamArr[0].DbType = DbType.DateTime;
                ParamArr[1].Value = DateTime.Parse(BillDate + " 23:59:59");
                ParamArr[1].DbType = DbType.DateTime;

                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        ///每日清单  ---- 按类别 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="ItemCodeType"></param>
        /// <returns></returns>
        public long m_lngRptEveryDayBillCate(string ID, string BillDate, int Type, int ItemCodeType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            string SQL = string.Empty;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(BillDate))
                return lngRes;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            if (Type == 1)
            {
                string strsub = "";

                if (ID == "00")
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                }
                else
                {
                    strsub = " and c.areaid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                    ParamArr[2].Value = ID;
                }

                SQL = @"select a.registerid_chr, a.calccateid_chr,g.typename_vchr,
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, a.chargeitemid_chr,
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec,  
                                f.code_chr, 
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f ,
                                t_bse_chargeitemextype g
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+)
                            and a.status_int = 1 
                            and a.calccateid_chr = g.typeid_chr
                            and a.pstatus_int <> 0 
                            and (c.pstatus_int = 1 or c.pstatus_int = 4)
                            and a.chargeactive_dat  between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') " + strsub + @"                       
                     group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr, g.typename_vchr,a.calccateid_chr,a.chargeitemid_chr
                      order by a.registerid_chr,f.code_chr,amount_dec desc ";

            }
            else if (Type == 2)
            {
                SQL = @"select a.registerid_chr, a.calccateid_chr,g.typename_vchr,
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, a.chargeitemid_chr,
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f ,
                                t_bse_chargeitemextype g
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.calccateid_chr = g.typeid_chr
                            and a.pstatus_int <> 0                             
                            and a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                            and a.registerid_chr = ? 
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr, g.typename_vchr,a.calccateid_chr,a.chargeitemid_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc ";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 3)
            {
                SQL = @"select a.registerid_chr, a.calccateid_chr,g.typename_vchr,
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, a.chargeitemid_chr,
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        (select tb1.registerid_chr, tb1.modify_dat, tb1.patientid_chr,
                                        tb1.isbooking_int, tb1.inpatientid_chr, tb1.inpatient_dat,
                                        tb1.deptid_chr, tb1.areaid_chr, tb1.bedid_chr, tb1.type_int,
                                        tb1.diagnose_vchr, tb1.limitrate_mny, tb1.inpatientcount_int,
                                        tb1.state_int, tb1.status_int, tb1.operatorid_chr, tb1.pstatus_int,
                                        tb1.casedoctor_chr, tb1.inpatientnotype_int, tb1.des_vchr,
                                        tb1.inareadate_dat, tb1.mzdoctor_chr, tb1.mzdiagnose_vchr,
                                        tb1.diagnoseid_chr, tb1.icd10diagid_vchr, tb1.icd10diagtext_vchr,
                                        tb1.isfromclinic, tb1.clinicsayprepay, tb1.paytypeid_chr,
                                        tb1.bornnum_int, tb1.relateregisterid_chr, tb1.feestatus_int,
                                        tb1.extendid_vchr, tb1.nursing_class, tb1.casedoctordept_chr,
                                        tb1.cancelerid_chr, tb1.cancel_dat, tb1.outdiagnose_vchr,
                                        tb1.insuredsum_mny
                                   from t_opr_bih_register tb1
                                   where exists (select 1
                                                   from (select max(tb2.registerid_chr) as registerid_chr
                                                           from t_opr_bih_register tb2
                                                           group by tb2.inpatientid_chr) tb2
                                                   where tb1.registerid_chr = tb2.registerid_chr)
                                ) c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f  ,
                                t_bse_chargeitemextype g
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.calccateid_chr = g.typeid_chr
                            and a.pstatus_int <> 0 
                            and a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') 
                            and c.inpatientid_chr = ? 
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr,g.typename_vchr,a.calccateid_chr,a.chargeitemid_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc ";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 4)
            {
                SQL = @"select a.registerid_chr, a.calccateid_chr,g.typename_vchr,
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, a.chargeitemid_chr,
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr ,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f,
                                t_bse_chargeitemextype g
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.calccateid_chr = g.typeid_chr
                            and a.pstatus_int <> 0                             
                            and a.chargeactive_dat between ? and ?
                            and a.registerid_chr in ([ArrBedno])
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr,g.typename_vchr,a.calccateid_chr,a.chargeitemid_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc";
                SQL = SQL.Replace("[ArrBedno]", ID);
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].DbType = DbType.DateTime;
                ParamArr[0].Value = DateTime.Parse(BillDate + " 00:00:00");
                ParamArr[1].DbType = DbType.DateTime;
                ParamArr[1].Value = DateTime.Parse(BillDate + " 23:59:59");

            }
            if (ItemCodeType == 0)
            {
                SQL = SQL.Replace("[ITEMCODETYPE]", "b.itemopcode_chr");
            }
            else
            {
                SQL = SQL.Replace("[ITEMCODETYPE]", "b.itemcode_vchr");
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 每日清单(费用明细)
        /// </summary>
        /// <param name="ID">1-病区ID 2-住院登记流水ID 3-住院号</param>        
        /// <param name="BillDate">清单日期</param>
        /// <param name="Type">类型：1 按病区 2 按床位 3 按住院号</param>
        /// <param name="ItemCodeType">项目代码使用类型 0 门诊收费编码 1 项目代码</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptEveryDayBillEntry(string ID, string BillDate, int Type, int ItemCodeType, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            if (Type == 1)
            {
                string strsub = "";

                if (ID == "00")
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                }
                else
                {
                    strsub = " and c.areaid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = BillDate + " 00:00:00";
                    ParamArr[1].Value = BillDate + " 23:59:59";
                    ParamArr[2].Value = ID;
                }

                SQL = @"select a.registerid_chr, 
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr,
                                e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, 
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec,  
                                b.itemid_chr,
                                f.code_chr, 
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f 
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+)
                            and a.status_int = 1 
                            and a.pstatus_int <> 0 
                            and (c.pstatus_int = 1 or c.pstatus_int = 4)
                            and a.chargeactive_dat  between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') " + strsub + @"                       
                     group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr,[ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr, b.itemid_chr
                      order by a.registerid_chr,f.code_chr,amount_dec desc ";

            }
            else if (Type == 2)
            {
                SQL = @"select a.registerid_chr, 
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, 
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f 
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.pstatus_int <> 0                             
                            and a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                            and a.registerid_chr = ? 
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc ";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 3)
            {
                SQL = @"select a.registerid_chr, 
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, 
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        (select tb1.registerid_chr, tb1.modify_dat, tb1.patientid_chr,
                                        tb1.isbooking_int, tb1.inpatientid_chr, tb1.inpatient_dat,
                                        tb1.deptid_chr, tb1.areaid_chr, tb1.bedid_chr, tb1.type_int,
                                        tb1.diagnose_vchr, tb1.limitrate_mny, tb1.inpatientcount_int,
                                        tb1.state_int, tb1.status_int, tb1.operatorid_chr, tb1.pstatus_int,
                                        tb1.casedoctor_chr, tb1.inpatientnotype_int, tb1.des_vchr,
                                        tb1.inareadate_dat, tb1.mzdoctor_chr, tb1.mzdiagnose_vchr,
                                        tb1.diagnoseid_chr, tb1.icd10diagid_vchr, tb1.icd10diagtext_vchr,
                                        tb1.isfromclinic, tb1.clinicsayprepay, tb1.paytypeid_chr,
                                        tb1.bornnum_int, tb1.relateregisterid_chr, tb1.feestatus_int,
                                        tb1.extendid_vchr, tb1.nursing_class, tb1.casedoctordept_chr,
                                        tb1.cancelerid_chr, tb1.cancel_dat, tb1.outdiagnose_vchr,
                                        tb1.insuredsum_mny
                                   from t_opr_bih_register tb1
                                   where exists (select 1
                                                   from (select max(tb2.registerid_chr) as registerid_chr
                                                           from t_opr_bih_register tb2
                                                           group by tb2.inpatientid_chr) tb2
                                                   where tb1.registerid_chr = tb2.registerid_chr)
                                ) c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f 
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.pstatus_int <> 0 
                            and a.chargeactive_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') 
                            and c.inpatientid_chr = ? 
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc ";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillDate + " 00:00:00";
                ParamArr[1].Value = BillDate + " 23:59:59";
                ParamArr[2].Value = ID;
            }
            else if (Type == 4)
            {
                SQL = @"select a.registerid_chr, 
		                        d.lastname_vchr, 
		                        to_char(a.chargeactive_dat, 'yyyy-mm-dd') as chargedate, 
		                        c.inpatientid_chr, 
		                        e.deptname_vchr,
		                        [ITEMCODETYPE], 
		                        a.chargeitemname_chr, 
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec, 
                                f.code_chr,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(round(a.unitprice_dec * a.amount_dec, 2)) as totalmoney, 
		                        (case a.pstatus_int when 3 then '√已交费' when 4 then '√已交费' else '' end) as des_vchr,sum(round(a.totaldiffcostmoney_dec,2)) as totaldiffcostmoney_dec 
                          from  t_opr_bih_patientcharge a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_opr_bih_registerdetail d,
		                        t_bse_deptdesc e,
                                t_bse_bed f 
                          where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and a.registerid_chr = d.registerid_chr
	                        and a.createarea_chr = e.deptid_chr 
                            and a.registerid_chr = f.bihregisterid_chr(+) 
                            and a.status_int = 1 
                            and a.pstatus_int <> 0                             
                            and a.chargeactive_dat between ? and ?
                            and a.registerid_chr in ([ArrBedno])
                       group by a.registerid_chr, d.lastname_vchr, to_char(a.chargeactive_dat, 'yyyy-mm-dd'), c.inpatientid_chr, 
                              e.deptname_vchr, [ITEMCODETYPE], a.chargeitemname_chr, a.spec_vchr, a.unit_vchr, 
                              a.unitprice_dec, a.pstatus_int, f.code_chr
                       order by a.registerid_chr,f.code_chr,amount_dec desc";
                SQL = SQL.Replace("[ArrBedno]", ID);
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].DbType = DbType.DateTime;
                ParamArr[0].Value = DateTime.Parse(BillDate + " 00:00:00");
                ParamArr[1].DbType = DbType.DateTime;
                ParamArr[1].Value = DateTime.Parse(BillDate + " 23:59:59");

            }
            if (ItemCodeType == 0)
            {
                SQL = SQL.Replace("[ITEMCODETYPE]", "b.itemopcode_chr");
            }
            else
            {
                SQL = SQL.Replace("[ITEMCODETYPE]", "b.itemcode_vchr");
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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
        public long m_lngRptGetBednoByAreaid(string p_strAreaid, out DataTable dtResult)
        {
            long lngRes = 1;
            string strSQL = @"select a.code_chr, b.inpatientid_chr, c.lastname_vchr, c.registerid_chr
                                from t_bse_bed a, t_opr_bih_register b, t_opr_bih_registerdetail c
                               where a.bihregisterid_chr = b.registerid_chr
                                 and b.registerid_chr = c.registerid_chr
                                 and a.bedid_chr = b.bedid_chr
                                 and a.areaid_chr = ? 
                                 and a.status_int <> 5
                            order by a.code_chr ";
            dtResult = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = p_strAreaid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
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

        #region 全院缴款(发票)分类报表
        /// <summary>
        /// 全院缴款(发票)分类报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RepType">0 缴款分类 1 发票分类</param>
        /// <param name="StatType">0 汇总 1 汇总＋分类</param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptIncomeClass(string BeginDate, string EndDate, int RepType, int StatType, out DataTable dtMain, out DataTable dtDet)
        {
            long lngRes = 0;
            string SQL = "";
            dtMain = new DataTable();
            dtDet = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select a.chargeno_chr as chargeno, a.totalsum_mny as totalsum, '#' || c.paytype_int as paytype, (c.paysum_mny - c.refusum_mny) as paysum 
                         from t_opr_bih_charge a,		                          
	                          t_opr_bih_payment c	 		                          
                        where a.chargeno_chr = c.chargeno_vchr 	                          
                          and a.status_int = 1 	                          
                          and ([DateType] between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) 
                
                      union all

                      select a.chargeno_chr as chargeno, a.totalsum_mny as totalsum, '&' || b.internalflag_int as paytype, a.acctsum_mny as paysum 
                        from t_opr_bih_charge a,
                             t_bse_patientpaytype b 
                       where a.paytypeid_chr = b.paytypeid_chr(+)                             
                         and a.status_int = 1                          
                         and a.acctsum_mny <> 0
                         and ([DateType] between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))";

                if (RepType == 0)
                {
                    SQL = SQL.Replace("[DateType]", "a.recdate_dat");
                }
                else if (RepType == 1)
                {
                    SQL = SQL.Replace("[DateType]", "a.operdate_dat");
                }

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                if (StatType == 1)
                {
                    SQL = @"select a.chargeno_chr as chargeno, nvl(d.typename_vchr, '*') as typename, sum(b.totalsum_mny) as catsum, d.sortcode_int as sortcode 
	                         from t_opr_bih_charge a,
		                          t_opr_bih_chargecat b,			                          
		                          t_bse_chargeitemextype d 
                            where a.chargeno_chr = b.chargeno_chr 	                          
	                          and b.itemcatid_chr = d.typeid_chr(+) 
	                          and a.status_int = 1                               
	                          and d.flag_int = 3 
                              and ([DateType] between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                     group by a.chargeno_chr, d.typename_vchr, d.sortcode_int ";

                    if (RepType == 0)
                    {
                        SQL = SQL.Replace("[DateType]", "a.recdate_dat");
                    }
                    else if (RepType == 1)
                    {
                        SQL = SQL.Replace("[DateType]", "a.operdate_dat");
                    }

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);
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

        #region 收款员缴款报表
        /// <summary>
        /// 收款员缴款报表
        /// </summary>
        /// <param name="EmpID">收费员ID</param>
        /// <param name="IsRec">是否已结帐</param>
        /// <param name="RecTime">结帐时间</param>
        /// <param name="dtCharge"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptReckoningEmp(string EmpID, bool IsRec, string RecTime, out DataTable dtCharge, out DataTable dtInvoice, out DataTable dtPayment, out DataTable dtPrepayChargeNo, out string RemarkInfo)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            dtCharge = new DataTable();
            dtInvoice = new DataTable();
            dtPayment = new DataTable();
            dtPrepayChargeNo = new DataTable();
            RemarkInfo = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"update t_opr_bih_prepay a
                           set a.chargeno_chr = a.origchargeno_chr
                         where a.isclear_int = 1
                           and a.origchargeno_chr is not null
                           and exists (
                                  select 1
                                    from t_opr_bih_charge b
                                   where a.chargeno_chr = b.chargeno_chr
                                     and b.status_int = 1                                      
                                     and b.recflag_int = 0
                                     and b.operemp_chr = ?)";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = EmpID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                if (IsRec)
                {
                    SQL = @"select a.chargeno_chr, a.type_int, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as invotime, a.totalsum_mny, a.sbsum_mny, a.acctsum_mny,
                             nvl((select d.totalsum_mny from t_opr_bih_invoice2de d where b.invoiceno_vchr = d.invoiceno_vchr and d.itemcatid_chr = '3026'),0) as totaldiffcostmoney_dec
                              from t_opr_bih_charge a,
                              t_opr_bih_chargedefinv b,
                              t_opr_bih_invoice2 c 
                             where a.recflag_int = 1 
                               and a.status_int = 1 
                               and a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr                                 
                               and a.recdate_dat = ?
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Convert.ToDateTime(RecTime);
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtCharge, ParamArr);

                    SQL = @"select 1 as flag, c.invoiceno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_chargedefinv b,
                                   t_opr_bih_invoice2 c
                             where a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr  
                               and a.recflag_int = 1 
                               and a.status_int = 1 
                               and a.type_int = 1  
                               and a.recdate_dat = ?
                               and a.operemp_chr = ? 
                               
                            union all

                            select 2 as flag, c.invoiceno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_chargedefinv b,
                                   t_opr_bih_invoice2 c
                             where a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr  
                               and a.recflag_int = 1 
                               and a.status_int = 1 
                               and a.type_int = 2 
                               and c.status_int = 2  
                               and a.recdate_dat = ?
                               and a.operemp_chr = ?

                            union all                                

                            select distinct 999 as flag, b.repprnbillno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_billrepeatprint b 
                             where a.chargeno_chr = b.billid_chr  
                               and a.recflag_int = 1 
                               and a.status_int = 1 
                               and b.billtype_chr = 2                                
                               and a.recdate_dat = ?
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = Convert.ToDateTime(RecTime);
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = Convert.ToDateTime(RecTime);
                    ParamArr[3].Value = EmpID;
                    ParamArr[4].Value = Convert.ToDateTime(RecTime);
                    ParamArr[5].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtInvoice, ParamArr);

                    SQL = @"select '#' || b.paytype_int as paytype, sum(b.paysum_mny - b.refusum_mny) as paysum
                              from t_opr_bih_charge a,
                                   t_opr_bih_payment b 
                             where a.chargeno_chr = b.chargeno_vchr                                
                               and a.recflag_int = 1 
                               and a.status_int = 1 
                               and a.recdate_dat = ?
                               and a.operemp_chr = ? 
                          group by b.paytype_int 

                          union all

                          select '&' || b.internalflag_int as paytype, sum(a.acctsum_mny) as paysum 
                            from t_opr_bih_charge a,
                                 t_bse_patientpaytype b 
                           where a.paytypeid_chr = b.paytypeid_chr(+) 
                             and a.status_int = 1                                 
                             and a.acctsum_mny <> 0 
                             and a.recdate_dat = ?
                             and a.operemp_chr = ? 
                        group by b.internalflag_int 
                
                          union all 

                          select '999' as paytype, sum(c.money_dec) as paysum
                            from t_opr_bih_charge a,
                                 t_opr_bih_prepay c 
                           where a.chargeno_chr = c.chargeno_chr                                
                             and a.recflag_int = 1 
                             and a.status_int = 1                              
                             and a.recdate_dat = ?
                             and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = Convert.ToDateTime(RecTime);
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = Convert.ToDateTime(RecTime);
                    ParamArr[3].Value = EmpID;
                    ParamArr[4].Value = Convert.ToDateTime(RecTime);
                    ParamArr[5].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayment, ParamArr);

                    SQL = @"select b.prepayinv_vchr, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as operdate_dat, a.class_int
                              from t_opr_bih_charge a,
                                   t_opr_bih_prepay b   
                             where a.chargeno_chr = b.chargeno_chr
                               and a.recflag_int = 1 
                               and a.status_int = 1                                                             
                               and a.recdate_dat = ?
                               and a.operemp_chr = ?

                            union all 

                            select b.prepayinv_vchr, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as operdate_dat, a.class_int
                              from t_opr_bih_charge a,
                                   t_opr_bih_prepay b   
                             where a.chargeno_chr = b.chargeno_chr                              
                               and a.status_int = 1  
                               and a.class_int = 3                               
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = Convert.ToDateTime(RecTime);
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepayChargeNo, ParamArr);

                    DataTable dt = new DataTable();

                    SQL = @"select a.remark_vchr 
                              from t_opr_bih_ReckoningRemark a 
                             where a.recdate_dat = ?
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Convert.ToDateTime(RecTime);
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        RemarkInfo = dt.Rows[0][0].ToString().Trim();
                    }
                }
                else
                {
                    SQL = @"select a.chargeno_chr, a.type_int, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as invotime, a.totalsum_mny, a.sbsum_mny, a.acctsum_mny,
                            nvl((select d.totalsum_mny from t_opr_bih_invoice2de d where b.invoiceno_vchr = d.invoiceno_vchr and d.itemcatid_chr = '3026'),0) as totaldiffcostmoney_dec
                              from t_opr_bih_charge a,
                              t_opr_bih_chargedefinv b,
                              t_opr_bih_invoice2 c                                  
                             where a.recflag_int = 0 
                               and a.status_int = 1
                               and a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr                                   
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtCharge, ParamArr);

                    SQL = @"select 1 as flag, c.invoiceno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_chargedefinv b,
                                   t_opr_bih_invoice2 c
                             where a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr  
                               and a.recflag_int = 0 
                               and a.status_int = 1 
                               and a.type_int = 1                                
                               and a.operemp_chr = ? 
                                    
                            union all   

                            select 2 as flag, c.invoiceno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_chargedefinv b,
                                   t_opr_bih_invoice2 c
                             where a.chargeno_chr = b.chargeno_chr 
                               and b.invoiceno_vchr = c.invoiceno_vchr  
                               and a.recflag_int = 0 
                               and a.status_int = 1 
                               and a.type_int = 2 
                               and c.status_int = 2  
                               and a.operemp_chr = ?                         

                            union all                                

                            select distinct 999 as flag, b.repprnbillno_vchr as invono, a.operemp_chr as empid  
                              from t_opr_bih_charge a,
                                   t_opr_bih_billrepeatprint b 
                             where a.chargeno_chr = b.billid_chr  
                               and a.recflag_int = 0 
                               and a.status_int = 1 
                               and b.billtype_chr = 2                                                               
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = EmpID;
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtInvoice, ParamArr);

                    SQL = @"select '#' || b.paytype_int as paytype, sum(b.paysum_mny - b.refusum_mny) as paysum
                              from t_opr_bih_charge a,
                                   t_opr_bih_payment b 
                             where a.chargeno_chr = b.chargeno_vchr 
                               and a.recflag_int = 0 
                               and a.status_int = 1 
                               and a.operemp_chr = ? 
                          group by b.paytype_int 
                    
                          union all

                          select '&' || b.internalflag_int as paytype, sum(a.acctsum_mny) as paysum 
                            from t_opr_bih_charge a,
                                 t_bse_patientpaytype b 
                           where a.paytypeid_chr = b.paytypeid_chr(+)                             
                             and a.recflag_int = 0 
                             and a.status_int = 1                              
                             and a.acctsum_mny <> 0 
                             and a.operemp_chr = ?    
                        group by b.internalflag_int

                          union all 

                          select '999' as paytype, sum(c.money_dec) as paysum
                            from t_opr_bih_charge a,
                                 t_opr_bih_prepay c 
                           where a.chargeno_chr = c.chargeno_chr                                
                             and a.recflag_int = 0 
                             and a.status_int = 1                              
                             and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = EmpID;
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayment, ParamArr);

                    SQL = @"select b.prepayinv_vchr, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as operdate_dat, a.class_int
                              from t_opr_bih_charge a,
                                   t_opr_bih_prepay b   
                             where a.chargeno_chr = b.chargeno_chr
                               and a.recflag_int = 0
                               and a.status_int = 1                                 
                               and a.operemp_chr = ?

                            union all 

                            select b.prepayinv_vchr, to_char(a.operdate_dat, 'yyyy-mm-dd hh24:mi:ss') as operdate_dat, a.class_int
                              from t_opr_bih_charge a,
                                   t_opr_bih_prepay b   
                             where a.chargeno_chr = b.chargeno_chr                              
                               and a.status_int = 1  
                               and a.class_int = 3                               
                               and a.operemp_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = EmpID;
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepayChargeNo, ParamArr);
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

        #region 收费处缴款报表
        /// <summary>
        /// 收费处缴款报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtCharge"></param>
        /// <param name="dtPayment"></param>
        /// <param name="dtRemarkInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptReckoningDept(string BeginDate, string EndDate, out DataTable dtCharge, out DataTable dtPayment, out DataTable dtRemarkInfo, out DataTable dtChargeno)
        {
            long lngRes = 0;
            string SQL = "";

            dtCharge = new DataTable();
            dtPayment = new DataTable();
            dtRemarkInfo = new DataTable();
            dtChargeno = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select a.recemp_chr as empid, nvl(b.lastname_vchr,'*') as empname, a.type_int, count(1) as invonums, 
                               sum(a.totalsum_mny) as totalsum, sum(a.sbsum_mny) as sbsum, sum(a.acctsum_mny) as acctsum 
                          from t_opr_bih_charge a,
                               t_bse_employee b   
                         where a.recemp_chr = b.empid_chr(+)
                           and a.recflag_int = 1 
                           and a.status_int = 1                            
                           and (a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                         group by a.recemp_chr, b.lastname_vchr, a.type_int 
                         order by b.lastname_vchr asc";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtCharge, ParamArr);

                SQL = @"select a.recemp_chr as empid, '#' || b.paytype_int as paytype, sum(b.paysum_mny - b.refusum_mny) as paysum 
                          from t_opr_bih_charge a,
                               t_opr_bih_payment b  
                         where a.chargeno_chr = b.chargeno_vchr                            
                           and a.recflag_int = 1 
                           and a.status_int = 1 
                           and (a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                      group by a.recemp_chr, b.paytype_int 
            
                      union all

                      select a.recemp_chr as empid, '&' || b.internalflag_int as paytype, sum(a.acctsum_mny) as paysum   
                            from t_opr_bih_charge a,
                                 t_bse_patientpaytype b 
                           where a.paytypeid_chr = b.paytypeid_chr(+)                             
                             and a.recflag_int = 1 
                             and a.status_int = 1                                 
                             and a.acctsum_mny <> 0 
                             and (a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                        group by a.recemp_chr, b.internalflag_int

                      union all 

                      select a.recemp_chr as empid, '999' as paytype, sum(c.money_dec) as paysum
                            from t_opr_bih_charge a,
                                 t_opr_bih_prepay c 
                           where a.chargeno_chr = c.chargeno_chr                                
                             and a.recflag_int = 1 
                             and a.status_int = 1                              
                             and (a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) 
                        group by a.recemp_chr

                        union all 

                        select   a.creatorid_chr as empid, '#999' as paytype, sum (a.money_dec)
                            from t_opr_bih_prepay a, t_opr_bih_prepaybalance b
                           where a.balanceid_vchr = b.balanceid_vchr
                             and a.balanceflag_int = 1
                             and a.status_int = 1
                             and b.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                   and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                        group by a.creatorid_chr ";

                objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";
                ParamArr[4].Value = BeginDate + " 00:00:00";
                ParamArr[5].Value = EndDate + " 23:59:59";
                ParamArr[6].Value = BeginDate + " 00:00:00";
                ParamArr[7].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayment, ParamArr);

                SQL = @"select a.operemp_chr as empid, a.remark_vchr 
                          from t_opr_bih_ReckoningRemark a 
                         where a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') ";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRemarkInfo, ParamArr);

                SQL = @"select a.chargeno_chr
                          from t_opr_bih_charge a,
                               t_opr_bih_payment b  
                         where a.chargeno_chr = b.chargeno_vchr                            
                           and a.recflag_int = 1 
                           and a.status_int = 1 
                           and (a.recdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                      group by a.chargeno_chr";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtChargeno, ParamArr);
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

        #region 发票明细报表
        /// <summary>
        /// 发票明细报表
        /// </summary>
        /// <param name="InvoiceNO">发票号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptInvoiceEntry(string InvoiceNO, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @" select a.registerid_chr, 
		                        d.lastname_vchr, 		                        
		                        c.inpatientid_chr,		                        
		                        b.itemcode_vchr, 
		                        a.chargeitemname_chr, 
		                        a.spec_vchr, 
		                        a.unit_vchr, 
		                        a.unitprice_dec,  
       	                        sum(a.amount_dec) as amount_dec, 
		                        sum(a.totalmoney_dec) as totalmoney,
                                sum(nvl(a.totaldiffcostmoney_dec,0)) as totaldiffcostmoney,
                                sum(a.totalmoney_dec) + sum(nvl(a.totaldiffcostmoney_dec,0)) as facttotalpay
                         from   t_opr_bih_chargeitementry a,
		                        t_bse_chargeitem b,
		                        t_opr_bih_register c,
		                        t_bse_patient d,
		                        t_bse_deptdesc e,
		                        (
		                        select c.chargeno_chr as chargeno 
		                          from t_opr_bih_invoice2 a,
				                         t_opr_bih_chargedefinv b,
				                         t_opr_bih_charge c
		                         where a.invoiceno_vchr = b.invoiceno_vchr 
			                        and b.chargeno_chr = c.chargeno_chr 
                                    and c.status_int = 1 
                                    and a.invoiceno_vchr in ({0})     			
		                        union all			
		                        select c.chargeno_chr as chargeno 
		                          from t_opr_bih_invoice2 a,
				                         t_opr_bih_chargedefinv b,
				                         t_opr_bih_charge c,
				                         t_opr_bih_billrepeatprint d
		                         where a.invoiceno_vchr = b.invoiceno_vchr 
			                        and a.invoiceno_vchr = d.sourcebillno_vchr  
			                        and b.chargeno_chr = c.chargeno_chr 
                                    and c.status_int = 1 
                                    and d.repprnbillno_vchr in ({1})                     
		                        ) f 
                        where a.chargeitemid_chr = b.itemid_chr(+) 
	                        and a.registerid_chr = c.registerid_chr 
	                        and c.patientid_chr = d.patientid_chr
	                        and a.createarea_chr = e.deptid_chr 
	                        and a.chargeno_chr = f.chargeno 
                     group by a.registerid_chr, d.lastname_vchr,c.inpatientid_chr,
                              b.itemcode_vchr, a.chargeitemname_chr, a.spec_vchr,
		                      a.unit_vchr, a.unitprice_dec
                     order by b.itemcode_vchr";

                //objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //ParamArr[0].Value = InvoiceNO;
                //ParamArr[1].Value = InvoiceNO;
                string[] invonoArr = InvoiceNO.Split(',');
                if (invonoArr != null && invonoArr.Length > 1)
                {
                    string invono = string.Empty;
                    foreach (string item in invonoArr)
                    {
                        invono += "'" + item + "',";
                    }
                    invono = invono.TrimEnd(',');
                    SQL = string.Format(SQL, invono, invono);
                }
                else
                {
                    InvoiceNO = "'" + InvoiceNO + "'";
                    SQL = string.Format(SQL, InvoiceNO, InvoiceNO);
                }
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

        #region 实收明细日志(发票明细)
        /// <summary>
        /// 实收明细日志(发票明细)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptInvoiceSum(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, out DataTable dtInvoice, out DataTable dtPayment)
        {
            long lngRes = 0;
            string SQL = "";
            dtInvoice = new DataTable();
            dtPayment = new DataTable();

            //构造where查询条件
            int nums = 2;
            string SubStr = " and (a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))";

            if (OperCode != null && OperCode.Trim() != "")
            {
                SubStr += " and g.empno_chr = ?";
                nums++;
            }

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.areaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = @"select g.lastname_vchr as opername, to_char(a.operdate_dat,'yyyy/mm/dd hh24:mi:ss') as invodate, c.invoiceno_vchr, 
                               e.inpatientid_chr, f.lastname_vchr as patname, h.deptname_vchr, a.class_int, c.totalsum_mny, c.acctsum_mny, 
                               nvl(i.summoney,0) as premoney, (a.sbsum_mny - nvl(i.summoney,0)) as patchmoney, a.chargeno_chr, a.type_int as invostatus, j.paytypename_vchr          
                          from t_opr_bih_charge a,
                               t_opr_bih_chargedefinv b,
                               t_opr_bih_invoice2 c,   
                               t_opr_bih_register e,
                               t_opr_bih_registerdetail f,
                               t_bse_employee g,
                               t_bse_deptdesc h,
                               (
                                select a.chargeno_chr, sum(a.money_dec) as summoney
                                  from t_opr_bih_prepay a,
                                       t_opr_bih_charge b
                                 where a.chargeno_chr = b.chargeno_chr                                    
                                 group by a.chargeno_chr
                               ) i,
                               t_bse_patientpaytype j    
                         where a.chargeno_chr = b.chargeno_chr 
                           and b.invoiceno_vchr = c.invoiceno_vchr 
                           and a.registerid_chr = e.registerid_chr 
                           and e.registerid_chr = f.registerid_chr 
                           and a.status_int = 1           
                           and a.operemp_chr = g.empid_chr(+)    
                           and a.areaid_chr = h.deptid_chr(+)   
                           and a.chargeno_chr = i.chargeno_chr(+) 
                           and a.paytypeid_chr = j.paytypeid_chr(+) " + SubStr + " order by g.lastname_vchr, c.invoiceno_vchr";

                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                if (nums == 3)
                {
                    ParamArr[2].Value = OperCode;
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtInvoice, ParamArr);

                SQL = @"select a.chargeno_chr, b.paytype_int, (b.paysum_mny - b.refusum_mny) as paymoney
                          from t_opr_bih_charge a,
                               t_opr_bih_payment b,
                               t_bse_employee g   
                         where a.chargeno_chr = b.chargeno_vchr 
                           and a.status_int = 1  
                           and a.operemp_chr = g.empid_chr(+) " + SubStr;

                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                if (nums == 3)
                {
                    ParamArr[2].Value = OperCode;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayment, ParamArr);
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

        #region 实收明细日志(退票)
        /// <summary>
        /// 实收明细日志(退票)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptInvoiceRefundment(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, out DataTable dtInvoice, out DataTable dtPayment)
        {
            long lngRes = 0;
            string SQL = "";
            dtInvoice = new DataTable();
            dtPayment = new DataTable();

            //构造where查询条件
            int nums = 2;
            string SubStr = " and (a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))";

            if (OperCode != null && OperCode.Trim() != "")
            {
                SubStr += " and g.empno_chr = ?";
                nums++;
            }

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.areaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = @"select g.lastname_vchr as opername, to_char(a.operdate_dat,'yyyy/mm/dd hh24:mi:ss') as invodate, c.invoiceno_vchr, 
                               e.inpatientid_chr, f.lastname_vchr as patname, h.deptname_vchr, a.class_int, c.totalsum_mny * -1 as totalsum_mny, c.acctsum_mny * -1 as acctsum_mny        
                          from t_opr_bih_charge a,
                               t_opr_bih_chargedefinv b,
                               t_opr_bih_invoice2 c,   
                               t_opr_bih_register e,
                               t_opr_bih_registerdetail f,
                               t_bse_employee g,
                               t_bse_deptdesc h
                         where a.chargeno_chr = b.chargeno_chr 
                           and b.invoiceno_vchr = c.invoiceno_vchr 
                           and a.registerid_chr = e.registerid_chr 
                           and e.registerid_chr = f.registerid_chr 
                           and a.status_int = 1 
                           and a.type_int = 2        
                           and a.operemp_chr = g.empid_chr(+)    
                           and a.areaid_chr = h.deptid_chr(+) " + SubStr + " order by g.lastname_vchr, c.invoiceno_vchr";

                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                if (nums == 3)
                {
                    ParamArr[2].Value = OperCode;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtInvoice, ParamArr);

                SQL = @"select fb.invoiceno_vchr, g.lastname_vchr, c.paytype_int,
                               (c.paysum_mny - c.refusum_mny) * -1 AS paymoney, to_char(a.operdate_dat,'yyyy/mm/dd hh24:mi:ss') as invodate
                          from t_opr_bih_charge a,
                               t_opr_bih_chargedefinv fb,
                               t_opr_bih_payment c,
                               t_bse_employee g
                         where a.chargeno_chr = fb.chargeno_chr
                           and a.status_int = 1
                           and a.type_int = 1
                           and exists (
                                  select 1
                                    from t_opr_bih_charge a, t_opr_bih_chargedefinv b, t_bse_employee g 
                                   where a.chargeno_chr = b.chargeno_chr 
                                     and a.operemp_chr = g.empid_chr(+)   
                                     and a.status_int = 1                                      
                                     and a.type_int = 2 " + SubStr + @" 
                                     and fb.invoiceno_vchr = b.invoiceno_vchr)
                           and a.chargeno_chr = c.chargeno_vchr
                           and a.operemp_chr = g.empid_chr(+)";

                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                if (nums == 3)
                {
                    ParamArr[2].Value = OperCode;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayment, ParamArr);
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

        #region 科室实收报表
        /// <summary>
        /// 科室实收报表
        /// </summary>
        /// <param name="Type">1 开单科室实收 2 执行科室实收</param>
        /// <param name="RptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptIncome(int Type, string RptID, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            //构造where查询条件

            string SubStr = "";
            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                if (Type == 1)
                {
                }
                else if (Type == 2)
                {
                    for (int i = 0; i < DeptIDArr.Count; i++)
                    {
                        str += "b.deptid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    }
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (Type == 1)
                {

                }
                else if (Type == 2)
                {
                    SQL = @"select b.deptid_chr as deptid, f.deptname_vchr as deptname,
                               d.groupid_chr as groupid, d.groupname_chr as groupname,
                               sum(b.totalsum_mny) as cattotalsum		  	 
                          from t_opr_bih_charge a,
	                           t_opr_bih_chargecat b,
	                           t_aid_rpt_def c,
	                           t_aid_rpt_gop_def d,
	                           t_aid_rpt_gop_rla e,
	                           t_bse_deptdesc f
                         where a.chargeno_chr = b.chargeno_chr 
                           and c.rptid_chr = d.rptid_chr 
                           and c.rptid_chr = e.rptid_chr 
                           and d.groupid_chr = e.groupid_chr
                           and b.itemcatid_chr = e.typeid_chr 
                           and a.status_int = 1  
                           and b.deptid_chr = f.deptid_chr(+) 
                           and c.rptid_chr = ? 
                           and (a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @" 
                      group by b.deptid_chr, f.deptname_vchr, d.groupid_chr, d.groupname_chr";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = RptID;
                    ParamArr[1].Value = BeginDate + " 00:00:00";
                    ParamArr[2].Value = EndDate + " 23:59:59";
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 医保结算明细报表
        /// <summary>
        /// 医保结算明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptYBEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            //构造where查询条件              
            string SubStr = " and ( a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.areaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @" select   nvl (d.idno_vchr, '未填') as idno_vchr,
                                         to_char (a.operdate_dat, 'yyyy/mm/dd') as operdate,
                                         a.inpatientid_chr, c.lastname_vchr, e.deptname_vchr, a.acctsum_mny,
                                         a.sbsum_mny, a.totalsum_mny
                                    from (select a.registerid_chr, a.paytypeid_chr, b.patientid_chr,
                                                 a.operdate_dat, b.inpatientid_chr, a.areaid_chr,
                                                 a.acctsum_mny, a.sbsum_mny, a.totalsum_mny
                                            from t_opr_bih_charge a, t_opr_bih_register b
                                           where a.registerid_chr = b.registerid_chr
                                             and a.status_int = 1
                                             and a.billno_int is not null " + SubStr + @" ) a,
                                         t_opr_bih_registerdetail c,
                                         t_bse_patientidentityno d,
                                         t_bse_deptdesc e
                                   where a.registerid_chr = c.registerid_chr
                                     and a.patientid_chr = d.patientid_chr(+)
                                     and a.paytypeid_chr = d.paytypeid_chr(+)
                                     and a.areaid_chr = e.deptid_chr(+)
                                order by e.deptname_vchr, a.operdate_dat, a.inpatientid_chr";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 已清预交金明细报表
        /// <summary>
        /// 已清预交金明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptPrePayClear(string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select a.prepayinv_vchr, e.deptname_vchr, c.inpatientid_chr,
                                     c.inpatientcount_int, d.lastname_vchr, d.sex_chr, b.operdate_dat,
                                     a.money_dec, g.empno_chr
                                from t_opr_bih_prepay a,
                                     t_opr_bih_charge b,
                                     t_opr_bih_register c,
                                     t_opr_bih_registerdetail d,
                                     t_bse_deptdesc e,
                                     t_bse_employee g
                               where a.registerid_chr = b.registerid_chr
                                 and a.registerid_chr = c.registerid_chr
                                 and a.registerid_chr = d.registerid_chr
                                 and a.chargeno_chr = b.chargeno_chr
                                 and c.areaid_chr = e.deptid_chr(+)
                                 and b.operemp_chr = g.empid_chr(+)
                                 and a.isclear_int = 1
                                 and b.status_int = 1 
                                 and (b.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss'))
                            order by e.deptname_vchr, a.prepayinv_vchr, d.lastname_vchr";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 科室实收明细报表
        /// <summary>
        /// 科室实收明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptIncomeEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            //构造where查询条件

            string SubStr = "";
            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.areaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select b.inpatientid_chr, d.lastname_vchr,
                               to_char(b.inpatient_dat, 'yyyy-mm-dd') as ryrq,
                               to_char(c.outhospital_dat, 'yyyy-mm-dd') as cyrq, a.totalsum, a.jsrq,
                               dr.area_sr, dr.area_tr, dr.deptname_r, dc.area_sc, dc.area_tc,
                               dc.deptname_c, a.areaid_chr, p2.deptname_vchr as areaname 
                          from (select a.registerid_chr, a.areaid_chr,
                                       sum(a.totalsum_mny) as totalsum, 
                                       max (a.operdate_dat) as jsrq                                      
                                  from t_opr_bih_charge a
                                 where ( a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') ) " + SubStr + @" 
                                 group by a.registerid_chr, a.areaid_chr) a,
                               t_opr_bih_register b,
                               (select registerid_chr, outhospital_dat
                                  from t_opr_bih_leave
                                 where status_int = 1) c,
                               t_opr_bih_registerdetail d,
                               (select t.registerid_chr, t.sourceareaid_chr AS area_sr,
                                       t.targetareaid_chr as area_tr, p.deptname_vchr as deptname_r
                                  from (select a.registerid_chr, max(a.operdate_dat) as jsrq
                                          from t_opr_bih_charge a
                                         where ( a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss') ) " + SubStr + @" 
                                         group by a.registerid_chr) ta,
                                       (select *
                                          from t_opr_bih_transfer t
                                         where (t.registerid_chr
                                                || to_char (t.modify_dat, 'yyyy-mm-dd hh24:mi:ss')
                                               ) in (
                                                  select t1.registerid_chr
                                                         || to_char (min (t1.modify_dat),
                                                                       'yyyy-mm-dd hh24:mi:ss'
                                                                      )
                                                      from t_opr_bih_transfer t1
                                                  group by t1.registerid_chr)) t,
                                       t_bse_deptdesc p
                                 where ta.registerid_chr = t.registerid_chr
                                   and t.targetareaid_chr = p.deptid_chr
                                   and t.modify_dat <= ta.jsrq) dr,
                               (select t.registerid_chr, t.sourceareaid_chr as area_sc,
                                       t.targetareaid_chr as area_tc, p.deptname_vchr as deptname_c
                                  from (select a.registerid_chr, max (a.operdate_dat) as jsrq
                                          from t_opr_bih_charge a
                                         where (a.operdate_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) " + SubStr + @" 
                                         group by a.registerid_chr) ta,
                                       (select *
                                          from t_opr_bih_transfer t
                                         where (t.registerid_chr
                                                || to_char (t.modify_dat, 'yyyy-mm-dd hh24:mi:ss')
                                               ) in (
                                                  select t1.registerid_chr
                                                         || to_char (max (t1.modify_dat),
                                                                       'yyyy-mm-dd hh24:mi:ss'
                                                                      )
                                                      from t_opr_bih_transfer t1
                                                  group by t1.registerid_chr)) t,
                                       t_bse_deptdesc p
                                 where ta.registerid_chr = t.registerid_chr
                                   and t.targetareaid_chr = p.deptid_chr
                                   and t.modify_dat >= ta.jsrq) dc,
                               t_bse_deptdesc p2 
                         where a.registerid_chr = b.registerid_chr
                           and a.registerid_chr = c.registerid_chr(+)
                           and a.registerid_chr = d.registerid_chr(+)
                           and a.registerid_chr = dr.registerid_chr(+)
                           and a.registerid_chr = dc.registerid_chr(+) 
                           and a.areaid_chr = p2.deptid_chr 
                           and a.totalsum > 0
                        order by b.inpatientid_chr";

                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";
                ParamArr[4].Value = BeginDate + " 00:00:00";
                ParamArr[5].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 补计费报表
        /// <summary>
        /// 补计费报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptLogBuShou(int RptType, string ConfirmNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dtCharge)
        {
            long lngRes = 0;
            string SQL = "";
            string SubStr = "";
            int nums = 3;

            SubStr = @" and a.activatetype_int = ? and (a.create_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) ";

            if (ConfirmNo.Trim() != "")
            {
                SubStr += " and f.empno_chr = ?";
                nums++;
            }

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.createarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            dtCharge = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @" select d.inpatientid_chr, 
                                b.lastname_vchr, 
                                c.deptname_vchr, 
                                d.paytypename_vchr, 
                                a.confirmerid_chr, 
                                f.empno_chr, 
                                a.chargeitemname_chr,
                                e.typename_vchr, 
                                (case a.activatetype_int when 2 then '补充记帐' when 3 then '确认记帐' when 4 then '确认收费' when 5 then '直接收费' else '' end) as chargetype, 
                                a.unitprice_dec, 
                                a.amount_dec, 
                                a.totalmoney_dec, 
                                (case a.ismepay_int when 1 then '自费' else '公费' end) as paytype 
                           from t_opr_bih_patientcharge a,
                                t_bse_patient  b,
                                t_bse_deptdesc c,
                                (select a.registerid_chr, 
                                        a.inpatientid_chr, 
                                        b.paytypename_vchr
                                   from t_opr_bih_register   a, 
                                        t_bse_patientpaytype b
                                  where a.paytypeid_chr = b.paytypeid_chr
                                ) d,
                                t_bse_chargeitemextype e,
                                t_bse_employee f
                          where a.patientid_chr = b.patientid_chr
                            and a.createarea_chr = c.deptid_chr
                            and a.registerid_chr = d.registerid_chr
                            and a.calccateid_chr = e.typeid_chr
                            and a.confirmerid_chr = f.empid_chr 
                            and a.status_int = 1 " + SubStr + @"                               
                       order by b.lastname_vchr, c.deptname_vchr";

                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = RptType;
                ParamArr[1].Value = BeginDate + " 00:00:00";
                ParamArr[2].Value = EndDate + " 23:59:59";
                if (nums == 4)
                {
                    ParamArr[3].Value = ConfirmNo;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtCharge, ParamArr);
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

        #region 住院结账日志报表
        /// <summary>
        /// 住院结账日志报表
        /// </summary>
        /// <param name="OperatorNo"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptLogSettleAccount(string OperatorNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dtCharge)
        {
            long lngRes = 0;
            string SQL = "";
            string SubStr = "";
            int nums = 2;

            SubStr = @" and (a.square_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')) ";

            if (OperatorNo.Trim() != "")
            {
                SubStr += "  and e.empno_chr= ? ";
                nums++;
            }

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.currareaid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            dtCharge = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"    select b.inpatientid_chr,
                                   c.lastname_vchr,
                                   d.deptname_vchr,
                                   charge_dec,
                                   b1.paytypename_vchr,
                                   e.empno_chr,
                                   a.note_vchr,
                                   a.square_dat
                              from t_opr_bih_dayaccount a,
                                   t_opr_bih_register   b,
                                   t_bse_patientpaytype b1,
                                   t_bse_patient        c,
                                   t_bse_deptdesc       d,
                                   t_bse_employee       e
                             where a.registerid_chr = b.registerid_chr
                               and c.patientid_chr = a.patientid_chr
                               and d.deptid_chr = a.currareaid_chr
                               and a.operid_chr = e.empid_chr
                               and b.paytypeid_chr = b1.paytypeid_chr
                               and a.type_int=1 " + SubStr + @"
                           order by a.square_dat, b.inpatientid_chr
                        ";

                objHRPSvc.CreateDatabaseParameter(nums, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                if (nums == 3)
                {
                    ParamArr[2].Value = OperatorNo;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtCharge, ParamArr);
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

        #region 项目统计发生明细报表
        /// <summary>
        /// 项目统计发生明细报表
        /// </summary>
        /// <param name="CodeNo">项目编码</param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dtCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptItemDetailStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            string SubStr = "";

            SubStr = @" and e.itemcode_vchr = ? and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')) ";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    str += "a.createarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @" select  e.itemcode_vchr, a.chargeitemname_chr, e.itemspec_vchr,
                                 c.deptname_vchr, d.inpatientid_chr, b.lastname_vchr, create_dat,
                                 a.amount_dec, a.totalmoney_dec, a.chearaccount_dat
                            from t_opr_bih_patientcharge a,
                                 t_bse_patient b,
                                 t_bse_deptdesc c,
                                 t_opr_bih_register d,
                                 t_bse_chargeitem e
                           where a.patientid_chr = b.patientid_chr
                             and a.createarea_chr = c.deptid_chr
                             and a.registerid_chr = d.registerid_chr
                             and a.chargeitemid_chr = e.itemid_chr
                             and a.status_int = 1 " + SubStr + @"
                        order by c.deptname_vchr, a.chargeactive_dat";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = CodeNo;
                ParamArr[1].Value = BeginDate + " 00:00:00";
                ParamArr[2].Value = EndDate + " 23:59:59";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 药品消报表(按发生)
        /// <summary>
        /// 药品消报表(按发生)
        /// </summary>
        /// <param name="CodeNo">项目编码</param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDragUsedStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            string SubStr = "";

            ///鉴于数据敏感，屏蔽该方法 by tfzhang at20100805
            dt = new DataTable();
            return lngRes;

            SubStr = @" and c.itemcode_vchr = ? and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')) ";

            if (DeptIDArr != null && DeptIDArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < DeptIDArr.Count; i++)
                {
                    //str += "d.deptid_chr = '" + DeptIDArr[i].ToString() + "' or ";
                    str += "a.createarea_chr = '" + DeptIDArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr += " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                #region OLD
                //                SQL = @"    select  b.deptname_vchr, 
                //                                    c.itemcode_vchr,
                //                                    a.chargeitemname_chr,
                //                                    c.itemspec_vchr, 
                //                                    a.totalmoney_dec,
                //                                    a.amount_dec as amount_dec,
                //                                    d.empno_chr,
                //                                    d.lastname_vchr,
                //                                    a.unitprice_dec as itemprice
                //                            from    t_opr_bih_patientcharge a,
                //                                    t_bse_deptdesc b,
                //                                    t_bse_chargeitem c,
                //                                     (
                //                                        select   c.empid_chr,d.empno_chr, deptid_chr, d.lastname_vchr,c.default_inpatient_dept_int
                //    		                              from t_bse_deptemp c, t_bse_employee d
                //   			                             where c.empid_chr = d.empid_chr(+)
                //     		                               and  
                //	 	                             ((  exists (select deptid_chr from t_bse_deptemp where empid_chr=d.empid_chr and default_inpatient_dept_int = 1)
                //	 	  	                                and c.default_inpatient_dept_int = 1) 
                //			                                 or
                //                                     (not exists (select deptid_chr from t_bse_deptemp where empid_chr=d.empid_chr and default_inpatient_dept_int = 1) 
                //	 		                               and c.default_inpatient_dept_int = 0
                //                                           and deptid_chr=(select max(deptid_chr) from t_bse_deptemp where empid_chr=d.empid_chr and c.default_inpatient_dept_int = 0)
                //     	                             ))) d
                //                               where d.deptid_chr= b.deptid_chr(+)
                //                                 and a.chargeitemid_chr = c.itemid_chr
                //                                 and a.chargedoctorid_chr = d.empid_chr(+) 
                //                                 and a.status_int = 1
                //                                 and a.pstatus_int<>0   
                //                                 and a.chargeactive_dat is not null " + SubStr + @" 
                //                            order by a.createarea_chr, 
                //                                     d.lastname_vchr   ";
                #endregion

                SQL = @"select  b.deptname_vchr, 
                                c.itemcode_vchr,
                                a.chargeitemname_chr,
                                c.itemspec_vchr, 
                                a.totalmoney_dec,
                                a.amount_dec as amount_dec,
                                d.empno_chr,
                                d.lastname_vchr,
                                a.unitprice_dec as itemprice
                           from t_opr_bih_patientcharge a,
                                t_bse_deptdesc b,
                                t_bse_chargeitem c,
                                t_bse_employee d
                          where a.createarea_chr = b.deptid_chr
                            and a.chargeitemid_chr = c.itemid_chr
                            and a.chargedoctorid_chr = d.empid_chr(+)
                            and a.pstatus_int<>0   
                            and a.chargeactive_dat is not null
                            and a.status_int = 1" + SubStr + @"
                       order by a.chargeactive_dat,
                                d.lastname_vchr";


                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = CodeNo;
                ParamArr[1].Value = BeginDate;
                ParamArr[2].Value = EndDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 顺德门诊普通医保、住院医保费用明细统计
        /// <summary>
        /// 顺德门诊普通医保、住院医保费用明细统计
        /// </summary>
        /// <param name="Type">1 门诊 2 住院</param>
        /// <param name="NO"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSDYBFeeDetail(int Type, string NO, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (Type == 1)
                {
                    SQL = @"select c.invoiceno_vchr as zlbh, b.insuranceid_chr as xmbh, b.itemopinvtype_chr as fldm, '门诊' as zlfs, b.itemname_vchr as zlxm, e.medicinepreptypename_vchr as xmlx,
	 		                        a.price_mny as xmjg, sum(a.qty_dec) as xmsl, nvl(sum(a.tolprice_mny),0) as zlfy, c.patientname_chr as xm, c.recorddate as kssj, c.recorddate as jssj, 0 as zycs, 1 as jscs  	 		
	                           from t_opr_oprecipeitemde a,
	   		                        t_bse_chargeitem b,
	   		                        (select a.patientname_chr, a.invoiceno_vchr, b.outpatrecipeid_chr, to_char(a.recorddate_dat,'yyyy-mm-dd hh24:mi:ss') as recorddate  
			                           from t_opr_outpatientrecipeinv a,
					                        t_opr_reciperelation b 
			                          where a.outpatrecipeid_chr = b.seqid 
				                        and a.invoiceno_vchr = ?) c,
			                        t_bse_medicine d,
                                    t_aid_medicinepreptype e	
	                          where	a.itemid_chr = b.itemid_chr(+) 
                                and a.outpatrecipeid_chr = c.outpatrecipeid_chr  
                                and b.itemsrcid_vchr = d.medicineid_chr(+) 
                                and d.medicinepreptype_chr = e.medicinepreptype_chr(+)
                           group by c.invoiceno_vchr, b.insuranceid_chr, b.itemopinvtype_chr, b.itemname_vchr, e.medicinepreptypename_vchr,
   			                        a.price_mny, c.patientname_chr, c.recorddate 
                           order by b.itemname_vchr	";
                }
                else if (Type == 2)
                {
                    SQL = @"select c.inpatientid_chr as zlbh, c.inpatientcount_int as zycs, b.insuranceid_chr as xmbh, a.invcateid_chr as fldm, '住院' as zlfs, a.chargeitemname_chr as zlxm, e.medicinepreptypename_vchr as xmlx, a.unitprice_dec as xmjg, 
	 		                        sum(a.amount_dec) as xmsl, nvl(sum(round(a.amount_dec * a.unitprice_dec,2)),0) as zlfy, f.lastname_vchr as xm, 
			                        to_char(c.inpatient_dat, 'yyyy-mm-dd hh24:mi:ss') as kssj, to_char(nvl(g.outhospital_dat, sysdate), 'yyyy/mm/dd hh24:mi:ss') as jssj, 1 as jscs
	                           from t_opr_bih_patientcharge a,
	   		                        t_bse_chargeitem b,
	   		                        (select tb1.registerid_chr, tb1.modify_dat, tb1.patientid_chr,
                                            tb1.isbooking_int, tb1.inpatientid_chr, tb1.inpatient_dat,
                                            tb1.deptid_chr, tb1.areaid_chr, tb1.bedid_chr, tb1.type_int,
                                            tb1.diagnose_vchr, tb1.limitrate_mny, tb1.inpatientcount_int,
                                            tb1.state_int, tb1.status_int, tb1.operatorid_chr, tb1.pstatus_int,
                                            tb1.casedoctor_chr, tb1.inpatientnotype_int, tb1.des_vchr,
                                            tb1.inareadate_dat, tb1.mzdoctor_chr, tb1.mzdiagnose_vchr,
                                            tb1.diagnoseid_chr, tb1.icd10diagid_vchr, tb1.icd10diagtext_vchr,
                                            tb1.isfromclinic, tb1.clinicsayprepay, tb1.paytypeid_chr,
                                            tb1.bornnum_int, tb1.relateregisterid_chr, tb1.feestatus_int,
                                            tb1.extendid_vchr, tb1.nursing_class, tb1.casedoctordept_chr,
                                            tb1.cancelerid_chr, tb1.cancel_dat, tb1.outdiagnose_vchr,
                                            tb1.insuredsum_mny
                                       from t_opr_bih_register tb1
                                       where exists (select 1
                                                       from (select max(tb2.registerid_chr) as registerid_chr
                                                               from t_opr_bih_register tb2
                                                               group by tb2.inpatientid_chr) tb2
                                                       where tb1.registerid_chr = tb2.registerid_chr)
                                    ) c,
	   		                        t_opr_bih_registerdetail f,
	   		                        (select registerid_chr, outhospital_dat from t_opr_bih_leave where status_int = 1) g,
	   		                        t_bse_medicine d,
                                    t_aid_medicinepreptype e 
                              where a.chargeitemid_chr = b.itemid_chr(+) 
	  	                        and a.registerid_chr = c.registerid_chr 
		                        and a.registerid_chr = f.registerid_chr 
		                        and a.registerid_chr = g.registerid_chr(+)
		                        and b.itemsrcid_vchr = d.medicineid_chr(+) 
                                and d.medicinepreptype_chr = e.medicinepreptype_chr(+)
                                and a.status_int = 1
                                and a.pstatus_int <> 0
                                and a.chargeactive_dat is not null
		                        and c.inpatientid_chr = ?   
                           group by c.inpatientid_chr, c.inpatientcount_int, b.insuranceid_chr, a.invcateid_chr, a.chargeitemname_chr, e.medicinepreptypename_vchr, a.unitprice_dec, 
   			                        f.lastname_vchr, c.inpatient_dat, g.outhospital_dat 	 
                           order by	a.chargeitemname_chr";
                }

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = NO;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 住院医生绩效统计报表
        /// <summary>
        /// 住院医生绩效统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="MedCatArr"></param>
        /// <param name="dtDoct"></param>
        /// <param name="dtDept"></param>
        /// <param name="dtPersonNums"></param>
        /// <param name="dtBedDays"></param>
        /// <param name="dtFeeSum"></param>
        /// <param name="dtMedSum"></param>
        /// <param name="dtNonMedSum"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDoctorPerformance(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtDoct, out DataTable dtDept,
                                              out DataTable dtPersonNums, out DataTable dtBedDays, out DataTable dtFeeSum, out DataTable dtMedSum, out DataTable dtNonMedSum)
        {
            long lngRes = 0;
            string SQL = "";
            dtDoct = new DataTable();
            dtDept = new DataTable();
            dtPersonNums = new DataTable();
            dtBedDays = new DataTable();
            dtFeeSum = new DataTable();
            dtMedSum = new DataTable();
            dtNonMedSum = new DataTable();

            #region 分方法
            try
            {
                //1、基本资料
                lngRes = this.m_lngRptDoctorPerformance_Doct(BeginDate, EndDate, DoctIDArr, FeeType, out dtDoct);
                //2、默认科室
                lngRes = this.m_lngRptDoctorPerformance_Dept(BeginDate, EndDate, DoctIDArr, out dtDept);
                //3、收住人次
                lngRes = this.m_lngRptDoctorPerformance_PersonNums(BeginDate, EndDate, DoctIDArr, out dtPersonNums);
                //4、出院人次 占床总日数
                lngRes = this.m_lngRptDoctorPerformance_BedDays(BeginDate, EndDate, DoctIDArr, out dtBedDays);
                //5、出院者(含预出院)总费用
                lngRes = this.m_lngRptDoctorPerformance_FeeSum(BeginDate, EndDate, DoctIDArr, FeeType, out dtFeeSum);
                //6、出院者(含预出院)药费
                lngRes = this.m_lngRptDoctorPerformance_MedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtMedSum);
                //7、出院者(含预出院)非药费
                lngRes = this.m_lngRptDoctorPerformance_NonMedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtNonMedSum);
            }
            catch
            {
                lngRes = 0;
            }
            #endregion

            return lngRes;
        }

        [AutoComplete]
        public long m_lngRptDoctorPerformance_Doct(string BeginDate, string EndDate, string DoctIDArr, int FeeType, out DataTable dtDoct)
        {
            long lngRes = 0;
            string SQL = "";
            dtDoct = new DataTable();

            //构造where查询条件                      
            string SubStr1 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr1 = " and a.doctid in (" + DoctIDArr + ")";
            }

            string SubStr2 = "";
            if (FeeType == 1)
            {
                SubStr2 = @" union all
                             select c.chargedoctorid_chr as doctid
                               from t_opr_bih_register a,
                                    t_opr_bih_charge b,
                                    t_opr_bih_chargeitementry c
                              where a.registerid_chr = b.registerid_chr
                                and b.chargeno_chr = c.chargeno_chr
                                and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and b.status_int = 1                                            
                                and (b.operdate_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    )";
            }
            else if (FeeType == 2)
            {
                SubStr2 = @" union all
                             select b.chargedoctorid_chr as doctid
                               from t_opr_bih_register a, 
                                    t_opr_bih_patientcharge b
                              where a.registerid_chr = b.registerid_chr
                              --  and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1
                                and b.status_int = 1 
                                and b.pstatus_int <> 0
                                and (b.chargeactive_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    )";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //1、基本资料
                SQL = @"select nvl(a.doctid, 'a99999') as doctid, b.empno_chr, b.lastname_vchr
                         from (select distinct doctid
                                 from (  select a.casedoctor_chr as doctid
                                           from t_opr_bih_register a
                                          where a.status_int = 1                                         
                                            and (a.inpatient_dat
                                                    between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                )
                                         union all
                                         select a.mzdoctor_chr as doctid
                                           from t_opr_bih_register a
                                          where a.status_int = 1                                          
                                            and (a.inpatient_dat
                                                    between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                )
                                         union all
                                         select a.casedoctor_chr as doctid
                                           from t_opr_bih_register a, t_opr_bih_leave b
                                          where a.registerid_chr = b.registerid_chr
                                            and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                            and b.status_int = 1
                                            and (b.outhospital_dat
                                                    between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                )"
                                          + SubStr2 + @")) a,
                                       t_bse_employee b
                                 where a.doctid = b.empid_chr(+)" + SubStr1 + @"
                              order by b.empno_chr";

                objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";
                ParamArr[4].Value = BeginDate + " 00:00:00";
                ParamArr[5].Value = EndDate + " 23:59:59";
                ParamArr[6].Value = BeginDate + " 00:00:00";
                ParamArr[7].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDoct, ParamArr);
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
        public long m_lngRptDoctorPerformance_Dept(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtDept)
        {
            long lngRes = 0;
            string SQL = "";
            dtDept = new DataTable();

            //构造where查询条件                                
            string SubStr2 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr2 = " and a.empid_chr in (" + DoctIDArr + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                //2、默认科室
                SQL = @"select nvl(a.empid_chr, 'a99999') as doctid, a.default_inpatient_dept_int, b.deptname_vchr
                          from t_bse_deptemp a, t_bse_deptdesc b
                         where a.deptid_chr = b.deptid_chr " + SubStr2 + @" 
                      order by a.empid_chr asc, a.default_inpatient_dept_int desc";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtDept);
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
        public long m_lngRptDoctorPerformance_PersonNums(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtPersonNums)
        {
            long lngRes = 0;
            string SQL = "";
            dtPersonNums = new DataTable();

            //构造where查询条件                                 
            string SubStr3 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr3 = " and a.mzdoctor_chr in (" + DoctIDArr + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //3、收住人次
                SQL = @"select nvl(a.mzdoctor_chr, 'a99999') as doctid, count(a.registerid_chr) as inpersonnums
                          from t_opr_bih_register a
                         where a.status_int = 1 
                           and a.relateregisterid_chr is null                       
                           and (a.inpatient_dat 
                                    between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                               ) " + SubStr3 + @" 
                      group by a.mzdoctor_chr";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPersonNums, ParamArr);
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
        public long m_lngRptDoctorPerformance_BedDays(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtBedDays)
        {
            long lngRes = 0;
            string SQL = "";
            dtBedDays = new DataTable();

            //构造where查询条件                                 
            string SubStr4 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and a.casedoctor_chr in (" + DoctIDArr + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //4、出院人次 占床总日数
                SQL = @"select nvl(a.casedoctor_chr, 'a99999') as doctid, count(a.registerid_chr) as outpersonnums,
                               sum(to_date(to_char(b.outhospital_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                                   - to_date(to_char(a.inpatient_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')) as days
                          from t_opr_bih_register a, t_opr_bih_leave b
                         where a.registerid_chr = b.registerid_chr
                           and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                           and a.relateregisterid_chr is null 
                           and b.status_int = 1
                           and (b.outhospital_dat 
                                    between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                               ) " + SubStr4 + @"
                      group by a.casedoctor_chr";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtBedDays, ParamArr);
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
        public long m_lngRptDoctorPerformance_FeeSum(string BeginDate, string EndDate, string DoctIDArr, int FeeType, out DataTable dtFeeSum)
        {
            long lngRes = 0;
            string SQL = "";
            dtFeeSum = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //构造where查询条件                                  
                string SubStr4 = "";
                if (DoctIDArr.Trim() != "")
                {
                    SubStr4 = " and a.casedoctor_chr in (" + DoctIDArr + ")";
                }

                //5、出院者(含预出院)总费用
                if (FeeType == 1)
                {
                    SQL = @" select nvl(a.casedoctor_chr, 'a99999') as doctid, sum(c.totalmoney_dec + nvl(c.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_charge b,
                                    t_opr_bih_chargeitementry c
                              where a.registerid_chr = b.registerid_chr
                                and b.chargeno_chr = c.chargeno_chr
                                and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and b.status_int = 1                                            
                                and (b.operdate_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"                                       
                              group by a.casedoctor_chr";
                }
                else if (FeeType == 2)
                {
                    SQL = @" select nvl(a.casedoctor_chr, 'a99999') as doctid, sum (round (b.unitprice_dec * b.amount_dec, 2) + nvl(b.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_patientcharge b
                              where a.registerid_chr = b.registerid_chr
                            --    and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and b.status_int = 1 
                                and b.pstatus_int <> 0                                           
                                and (b.chargeactive_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"                                       
                              group by a.casedoctor_chr";
                }

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtFeeSum, ParamArr);
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
        public long m_lngRptDoctorPerformance_MedSum(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtMedSum)
        {
            long lngRes = 0;
            string SQL = "";
            dtMedSum = new DataTable();

            //构造where查询条件                                  
            string SubStr4 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and c.chargedoctorid_chr in (" + DoctIDArr + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //6、出院者(含预出院)药费
                if (FeeType == 1)
                {
                    SQL = @" select nvl(c.chargedoctorid_chr, 'a99999') as doctid, sum(c.totalmoney_dec + nvl(c.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_charge b,
                                    t_opr_bih_chargeitementry c
                              where a.registerid_chr = b.registerid_chr
                                and b.chargeno_chr = c.chargeno_chr
                                and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and b.status_int = 1                                            
                                and (b.operdate_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"  
                                and c.invcateid_chr in (" + MedCatArr + @")                                     
                              group by c.chargedoctorid_chr";
                }
                else if (FeeType == 2)
                {
                    SQL = @" select nvl(c.chargedoctorid_chr, 'a99999') as doctid, sum (round (c.unitprice_dec * c.amount_dec, 2)+ nvl(c.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_patientcharge c
                              where a.registerid_chr = c.registerid_chr
                          --      and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and c.status_int = 1   
                                and c.pstatus_int <> 0                                          
                                and (c.chargeactive_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"  
                                and c.invcateid_chr in (" + MedCatArr + @")                                     
                              group by c.chargedoctorid_chr";
                }

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMedSum, ParamArr);
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
        public long m_lngRptDoctorPerformance_NonMedSum(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtNonMedSum)
        {
            long lngRes = 0;
            string SQL = "";
            dtNonMedSum = new DataTable();

            //构造where查询条件                                  
            string SubStr4 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and c.chargedoctorid_chr in (" + DoctIDArr + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //7、出院者(含预出院)非药费
                if (FeeType == 1)
                {
                    SQL = @" select nvl(c.chargedoctorid_chr, 'a99999') as doctid, sum(c.totalmoney_dec+ nvl(c.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_charge b,
                                    t_opr_bih_chargeitementry c
                              where a.registerid_chr = b.registerid_chr
                                and b.chargeno_chr = c.chargeno_chr
                                and (a.pstatus_int = 2 or a.pstatus_int = 3)   
                                and a.status_int = 1                                          
                                and b.status_int = 1                                            
                                and (b.operdate_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"  
                                and c.invcateid_chr not in (" + MedCatArr + @")                                     
                              group by c.chargedoctorid_chr";
                }
                else if (FeeType == 2)
                {
                    SQL = @" select nvl(c.chargedoctorid_chr, 'a99999') as doctid, sum (round (c.unitprice_dec * c.amount_dec, 2)+ nvl(c.totaldiffcostmoney_dec,0)) as totalsum
                               from t_opr_bih_register a,
                                    t_opr_bih_patientcharge c
                              where a.registerid_chr = c.registerid_chr
                      --          and (a.pstatus_int = 2 or a.pstatus_int = 3) 
                                and a.status_int = 1                                          
                                and c.status_int = 1  
                                and c.pstatus_int <> 0                                          
                                and (c.chargeactive_dat
                                        between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                    ) " + SubStr4 + @"  
                                and c.invcateid_chr not in (" + MedCatArr + @")                                     
                              group by c.chargedoctorid_chr";
                }

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtNonMedSum, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 绩效统计
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="FeeType"></param>
        /// <param name="RptID"></param>
        /// <param name="m_objGroup"></param>
        /// <param name="m_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDoctorPerformance_Effects(string BeginDate, string EndDate, string DoctIDArr, int FeeType,
            string RptID, Dictionary<string, decimal> m_objGroup, out Dictionary<string, decimal> m_objResult)
        {
            string strSQL = "";
            long lngRes = -1;
            DataTable dtTmp = null;
            m_objResult = null;
            string SubStr4 = "";
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and c.chargedoctorid_chr in (" + DoctIDArr + ") ";
            }

            try
            {
                if (FeeType == 1)
                {
                    //if (DoctIDArr.Trim() != "")
                    //{
                    //    SubStr4 = " and b.chargedoctorid_chr in (" + DoctIDArr + ") ";
                    //}

                    strSQL = @"select   nvl (c.chargedoctorid_chr, 'a99999') as doctid,
                                         sum (c.totalmoney_dec + nvl(c.totaldiffcostmoney_dec,0)) as totalsum, td.groupid_chr
                                    from t_opr_bih_register a,
                                         t_opr_bih_charge b,
                                         t_opr_bih_chargeitementry c,
                                         (select b.groupid_chr, c.typeid_chr
                                            from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                                           where a.rptid_chr = b.rptid_chr
                                             and b.rptid_chr = c.rptid_chr(+)
                                             and b.groupid_chr = c.groupid_chr(+)
                                             and a.rptid_chr = ?) td
                                   where a.registerid_chr = b.registerid_chr
                                     and b.chargeno_chr = c.chargeno_chr
                                     and td.typeid_chr = c.calccateid_chr
                                     and (a.pstatus_int = 2 or a.pstatus_int = 3)
                                     and a.status_int = 1
                                     and b.status_int = 1
                                     and (b.operdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss'))
                                     " + SubStr4 + @" 
                                group by c.chargedoctorid_chr, td.groupid_chr ";
                }
                else if (FeeType == 2)
                {
                    strSQL = @"select   nvl (c.chargedoctorid_chr, 'a99999') as doctid,
                                         sum (c.totalmoney_dec + nvl(c.totaldiffcostmoney_dec,0)) as totalsum, td.groupid_chr
                                    from t_opr_bih_register a,
                                         t_opr_bih_patientcharge c,
                                         (select b.groupid_chr, c.typeid_chr
                                            from t_aid_rpt_def a, t_aid_rpt_gop_def b, t_aid_rpt_gop_rla c
                                           where a.rptid_chr = b.rptid_chr
                                             and b.rptid_chr = c.rptid_chr(+)
                                             and b.groupid_chr = c.groupid_chr(+)
                                             and a.rptid_chr = ?) td
                                   where a.registerid_chr = c.registerid_chr
                                     and c.calccateid_chr = td.typeid_chr
                                     and a.status_int = 1
                                     and c.status_int = 1
                                     and c.pstatus_int <> 0
                                     and (c.chargeactive_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss'))
                                     " + SubStr4 + @" 
                                group by c.chargedoctorid_chr, td.groupid_chr ";
                }

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = RptID;
                ParamArr[1].Value = BeginDate + " 00:00:00";
                ParamArr[2].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmp, ParamArr);

                objHRPSvc.Dispose();
                objHRPSvc = null;
                m_objResult = new Dictionary<string, decimal>();

                int intCount = dtTmp.Rows.Count;
                DataRow dr = null;
                DataRow[] drArr = null;
                for (int i1 = 0; i1 < intCount; i1++)
                {
                    dr = dtTmp.Rows[i1];
                    if (m_objResult.ContainsKey(dr["doctid"].ToString()))
                    {
                        continue;
                    }

                    drArr = dtTmp.Select("doctid = '" + dr["doctid"].ToString() + "'");
                    decimal dclSum = 0m;

                    for (int j = 0; j < drArr.Length; j++)
                    {
                        if (m_objGroup.ContainsKey(drArr[j]["groupid_chr"].ToString()))
                        {
                            dclSum += m_objGroup[drArr[j]["groupid_chr"].ToString()] * Convert.ToDecimal(drArr[j]["totalsum"]);
                        }
                    }

                    m_objResult.Add(dr["doctid"].ToString(), dclSum);
                }

                dtTmp.Dispose();
                dtTmp = null;

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        /// <summary>
        /// 抗菌药比例
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="FeeType"></param>
        /// <param name="m_objAntiseptic"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Antiseptic(string BeginDate, string EndDate, string DoctIDArr, string KangJunArr, int FeeType, out DataTable dtAntiseptic)
        {
            string SubStr4 = "";
            string SubStr1 = "";
            long lngRes = -1;
            string strSQL = "";
            dtAntiseptic = new DataTable();
            //dtWesternMedicinetotal = new DataTable();
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and a.chargedoctorid_chr in (" + DoctIDArr + ") ";
            }
            if (KangJunArr.Trim() != "")
            {
                SubStr1 = " and c.pharmaid_chr in (" + KangJunArr + ") ";
            }

            try
            {
                if (FeeType == 1)
                {
                    strSQL = @"select t1.doctid,
       t1.xytotalmoney_dec,
       t2.kjytotalmoney_dec,
       round(t2.kjytotalmoney_dec * 100 /
             decode(t1.xytotalmoney_dec, 0, 1, t1.xytotalmoney_dec),
             2) kjyb
  from (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as xytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
           and a.chargeactive_dat is not null
           and a.status_int = 1
            " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t1,
       (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as kjytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
            " + SubStr1 + @"
           and a.chargeactive_dat is not null
           and a.status_int = 1
           " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t2
 where t1.doctid = t2.doctid";


                }
                else if (FeeType == 2)
                {
                    strSQL = @"select t1.doctid,
       t1.xytotalmoney_dec,
       t2.kjytotalmoney_dec,
       round(t2.kjytotalmoney_dec * 100 /
             decode(t1.xytotalmoney_dec, 0, 1, t1.xytotalmoney_dec),
             2) kjyb
  from (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as xytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
           and a.chargeactive_dat is not null
           and a.status_int = 1
            " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t1,
       (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as kjytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
            " + SubStr1 + @"
           and a.chargeactive_dat is not null
           and a.status_int = 1
           " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t2
 where t1.doctid = t2.doctid";


                }
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtAntiseptic, ParamArr);

                //IDataParameter[] Param = null;
                //objHRPSvc.CreateDatabaseParameter(2, out Param);
                //Param[0].Value = BeginDate + " 00:00:00";
                //Param[1].Value = EndDate + " 23:59:59";
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtWesternMedicinetotal, Param);
                objHRPSvc.Dispose();
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

        /// <summary>
        /// 基本药物比例
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="FeeType"></param>
        /// <param name="m_objAntiseptic"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Essential(string BeginDate, string EndDate, string DoctIDArr, string JiBenArr, int FeeType, out DataTable dtEssential)
        {
            string SubStr4 = "";
            string SubStr1 = "";
            long lngRes = -1;
            string strSQL = "";
            dtEssential = new DataTable();
            //dtWesternMedicinetotal = new DataTable();
            if (DoctIDArr.Trim() != "")
            {
                SubStr4 = " and a.chargedoctorid_chr in (" + DoctIDArr + ") ";
            }
            if (JiBenArr.Trim() != "")
            {
                SubStr1 = " and c.inpinsurancetype_vchr in (" + JiBenArr + ") ";
            }

            try
            {
                if (FeeType == 1)
                {
                    strSQL = @"select t1.doctid,
       t1.xytotalmoney_dec,
       t2.kjytotalmoney_dec,
       round(t2.kjytotalmoney_dec * 100 /
             decode(t1.xytotalmoney_dec, 0, 1, t1.xytotalmoney_dec),
             2) jbyb
  from (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as xytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
           and a.chargeactive_dat is not null
           and a.status_int = 1
            " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t1,
       (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as kjytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
            " + SubStr1 + @"
           and a.chargeactive_dat is not null
           and a.status_int = 1
           " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t2
 where t1.doctid = t2.doctid";


                }
                else if (FeeType == 2)
                {
                    strSQL = @"select t1.doctid,
       t1.xytotalmoney_dec,
       t2.kjytotalmoney_dec,
       round(t2.kjytotalmoney_dec * 100 /
             decode(t1.xytotalmoney_dec, 0, 1, t1.xytotalmoney_dec),
             2) jbyb
  from (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as xytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
           and a.chargeactive_dat is not null
           and a.status_int = 1
            " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t1,
       (select nvl(a.chargedoctorid_chr, 'a99999') as doctid,
               sum(a.totalmoney_dec + nvl(a.totaldiffcostmoney_dec,0)) as kjytotalmoney_dec
          from t_opr_bih_patientcharge a,
               t_bse_deptdesc          b,
               t_bse_medicine          c,
               t_bse_chargeitem        e
         where a.createarea_chr = b.deptid_chr
           and a.chargeitemid_chr = e.itemid_chr
           and e.itemsrcid_vchr = c.medicineid_chr
           and c.medicinetypeid_chr = 2
            " + SubStr1 + @"
           and a.chargeactive_dat is not null
           and a.status_int = 1
           " + SubStr4 + @" 
           and (a.chargeactive_dat between
               to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
         group by a.chargedoctorid_chr) t2
 where t1.doctid = t2.doctid";


                }
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = BeginDate + " 00:00:00";
                ParamArr[1].Value = EndDate + " 23:59:59";
                ParamArr[2].Value = BeginDate + " 00:00:00";
                ParamArr[3].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtEssential, ParamArr);
                objHRPSvc.Dispose();
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

        #region 全院(门诊、住院)各核算单位实收报表
        /// <summary>
        /// 全院(门诊、住院)各核算单位实收报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="Type">1 发票时间 2 日结时间</param>
        /// <param name="dtGroup"></param>
        /// <param name="dtRecNums"></param>
        /// <param name="dtMz"></param>
        /// <param name="dtZy"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptAllDeptIncome(string BeginDate, string EndDate, int Type, out DataTable dtGroup, out DataTable dtRecNums, out DataTable dtMz, out DataTable dtZy)
        {
            long lngRes = 0;
            string SQL = "";
            dtGroup = new DataTable();
            dtRecNums = new DataTable();
            dtMz = new DataTable();
            dtZy = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select groupid_chr, groupname_vchr
                          from  (select a.groupid_chr, a.groupname_vchr 
                                  from t_bse_groupdesc a 
                                 order by a.sort_int)
                         union all 
                         select 'a999' as groupid_chr, '未定义组' as groupname_vchr
                           from dual";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtGroup);

                if (Type == 1)
                {
                    SQL = @"select   nvl(c.groupid_chr, 'a999') as groupid_chr, sum(case c.status_int when 1 then 1 when 3 then 1 else -1 end) as recnums
                                from t_opr_outpatientrecipe a,
                                     t_opr_reciperelation b,
                                     t_opr_outpatientrecipeinv c
                               where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                 and b.seqid = c.outpatrecipeid_chr                                 
                                 and a.recipeflag_int = 1
                                 and (c.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                            group by c.groupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecNums, ParamArr);

                    SQL = @"select   nvl(a.groupid_chr, 'a999') as groupid_chr, sum (a.totalsum_mny) as totalsum
                                from t_opr_outpatientrecipeinv a
                               where (a.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                           and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                            group by a.groupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMz, ParamArr);

                    SQL = @"select   nvl(a.doctorgroupid_chr, 'a999') as groupid_chr, sum (a.totalmoney_dec) as totalsum
                                from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                               where a.chargeno_chr = b.chargeno_chr 
                                 and b.status_int = 1
                                 and (b.operdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                         and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                            group by a.doctorgroupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtZy, ParamArr);

                }
                else if (Type == 2)
                {
                    SQL = @"select   nvl(c.groupid_chr, 'a999') as groupid_chr,  sum(case c.status_int when 1 then 1 when 3 then 1 else -1 end) as recnums
                                from t_opr_outpatientrecipe a,
                                     t_opr_reciperelation b,
                                     t_opr_outpatientrecipeinv c
                               where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                 and b.seqid = c.outpatrecipeid_chr                               
                                 and a.recipeflag_int = 1 
                                 and c.balanceflag_int = 1
                                 and (c.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                            group by c.groupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecNums, ParamArr);

                    SQL = @"select   nvl(a.groupid_chr, 'a999') as groupid_chr, sum (a.totalsum_mny) as totalsum
                                from t_opr_outpatientrecipeinv a
                               where (a.balance_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     ) 
                                 and a.balanceflag_int = 1
                            group by a.groupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMz, ParamArr);

                    SQL = @"select   nvl(a.doctorgroupid_chr, 'a999') as groupid_chr, sum (a.totalmoney_dec) as totalsum
                                from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                               where a.chargeno_chr = b.chargeno_chr 
                                 and b.status_int = 1
                                 and b.recflag_int = 1
                                 and (b.recdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                        and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                            group by a.doctorgroupid_chr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = BeginDate + " 00:00:00";
                    ParamArr[1].Value = EndDate + " 23:59:59";

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtZy, ParamArr);
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

        #region 收款员缴款报表(按金)
        /// <summary>
        /// 收款员缴款报表(按金)
        /// </summary>
        /// <param name="EmpID">收费员ID</param>
        /// <param name="IsRec">是否已结帐</param>
        /// <param name="RecTime">结帐时间</param>
        /// <param name="dtPrepay"></param>
        /// <param name="dtPrepayRepNo"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptReckoningEmpPre(string EmpID, bool IsRec, string RecTime, out DataTable dtPrepay, out DataTable dtPrepayRepNo, out string RemarkInfo)
        {
            long lngRes = 0;
            string SQL = "";

            dtPrepay = new DataTable();
            dtPrepayRepNo = new DataTable();
            RemarkInfo = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (IsRec)
                {
                    //                    SQL = @"select a.chargeno_chr, a.prepayinv_vchr, a.paytype_int, 
                    //                                   a.uptype_int, a.cuycate_int, a.money_dec 
                    //                              from t_opr_bih_prepay a,
                    //                                   t_opr_bih_prepaybalance b
                    //                             where a.balanceid_vchr = b.balanceid_vchr                              
                    //                               and a.balanceflag_int = 1 
                    //                               and a.status_int = 1                              
                    //                               and b.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                    //                               and a.creatorid_chr = ?";
                    SQL = @"select a.chargeno_chr, a.prepayinv_vchr, a.paytype_int, 
                                   a.uptype_int, a.cuycate_int, a.money_dec 
                              from t_opr_bih_prepay a,
                                   t_opr_bih_prepaybalance b
                             where a.balanceid_vchr = b.balanceid_vchr                              
                               and a.balanceflag_int = 1 
                               and a.status_int = 1                              
                               and b.balance_dat = ? 
                               and a.creatorid_chr = ?";

                    //objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    //ParamArr[0].Value = RecTime + " 00:00:00";
                    //ParamArr[1].Value = RecTime + " 23:59:59";
                    //ParamArr[2].Value = EmpID;
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].DbType = DbType.DateTime;
                    ParamArr[0].Value = DateTime.Parse(RecTime);
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepay, ParamArr);

                    //                    SQL = @"select 999 flag, a.prepayinv_vchr, a.creatorid_chr as empid 
                    //                              from t_opr_bih_prepay a,
                    //                                   t_opr_bih_prepaybalance b,   
                    //                                   t_opr_bih_billrepeatprint c                                   
                    //                             where a.balanceid_vchr = b.balanceid_vchr
                    //                               and a.prepayid_chr = c.billid_chr
                    //                               and a.balanceflag_int = 1
                    //                               and a.status_int = 1 
                    //                               and c.billtype_chr = '1' 
                    //                               and b.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                    //                               and a.creatorid_chr = ?";
                    SQL = @"select 999 flag, a.prepayinv_vchr, a.creatorid_chr as empid 
                                                  from t_opr_bih_prepay a,
                                                       t_opr_bih_prepaybalance b,   
                                                       t_opr_bih_billrepeatprint c                                   
                                                 where a.balanceid_vchr = b.balanceid_vchr
                                                   and a.prepayid_chr = c.billid_chr
                                                   and a.balanceflag_int = 1
                                                   and a.status_int = 1 
                                                   and c.billtype_chr = '1' 
                                                   and b.balance_dat = ?
                                                   and a.creatorid_chr = ?";

                    //objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    //ParamArr[0].Value = RecTime + " 00:00:00";
                    //ParamArr[1].Value = RecTime + " 23:59:59";
                    //ParamArr[2].Value = EmpID;
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].DbType = DbType.DateTime;
                    ParamArr[0].Value = DateTime.Parse(RecTime);
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepayRepNo, ParamArr);

                    DataTable dt = new DataTable();

                    //                    SQL = @"select a.remark_vchr 
                    //                              from t_opr_bih_prepaybalance a 
                    //                             where a.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                    //                               and a.balanceemp_chr = ?";
                    SQL = @"select a.remark_vchr 
                                                  from t_opr_bih_prepaybalance a 
                                                 where a.balance_dat = ? 
                                                   and a.balanceemp_chr = ?";

                    //objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    //ParamArr[0].Value = RecTime + " 00:00:00";
                    //ParamArr[1].Value = RecTime + " 23:59:59";
                    //ParamArr[2].Value = EmpID;
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].DbType = DbType.DateTime;
                    ParamArr[0].Value = DateTime.Parse(RecTime);
                    ParamArr[1].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        RemarkInfo = dt.Rows[0][0].ToString().Trim();
                    }
                }
                else
                {
                    SQL = @"select a.chargeno_chr, a.prepayinv_vchr, a.paytype_int, 
                                   a.uptype_int, a.cuycate_int, a.money_dec
                              from t_opr_bih_prepay a
                             where a.balanceflag_int = 0 
                               and a.status_int = 1 
                               and a.creatorid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepay, ParamArr);

                    SQL = @"select 999 flag, a.prepayinv_vchr, a.creatorid_chr as empid 
                              from t_opr_bih_prepay a,
                                   t_opr_bih_billrepeatprint b  
                             where a.prepayid_chr = b.billid_chr 
                               and a.balanceflag_int = 0 
                               and a.status_int = 1
                               and b.billtype_chr = '1'                               
                               and a.creatorid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = EmpID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepayRepNo, ParamArr);
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

        #region 获取功能科室专业组分类统计数据
        /// <summary>
        /// 获取功能科室专业组分类统计数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupInComeByDoctor(System.Security.Principal.IPrincipal p_objPrincipal, ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;

            clsHRPTableService objHRPServ = new clsHRPTableService();
            StringBuilder sbdSQL = new StringBuilder(
                    @"select c.groupname_vchr as groupname_vchr,
                             tb.groupname_chr as itemgroupname_chr,
                             sum(a.totalmoney_dec) as totalmoney_dec
                      from t_opr_bih_chargeitementry a
                        inner join t_opr_bih_charge b on a.chargeno_chr = b.chargeno_chr
                        inner join t_bse_groupdesc c  on a.doctorgroupid_chr = c.groupid_chr    
                        inner join
                            (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                from t_aid_rpt_def a 
                                    inner join t_aid_rpt_gop_def b  on a.rptid_chr = b.rptid_chr
                                    inner join t_aid_rpt_gop_rla c  on b.rptid_chr = c.rptid_chr
                                        and b.groupid_chr = c.groupid_chr
                                        and a.rptid_chr = ?) tb  on a.calccateid_chr = tb.typeid_chr
                     where b.status_int = 1
                        and b.recflag_int = 1
                        and a.createarea_chr = ?
                        and b.recdate_dat >= ? 
                        and b.recdate_dat <= ? 
                    group by tb.groupname_chr, c.groupname_vchr ");

            try
            {

                IDataParameter[] objDPArr = null;

                lngRes = objHRPServ.lngGetDataTableWithParameters(sbdSQL.ToString(), ref dtbResult, objDPArr);

                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                dtbResult = null;
            }
            objHRPServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 查询病区信息
        /// <summary>
        /// 查询病区信息
        /// </summary>
        /// <param name="strCode">查询字符串</param>
        /// <param name="arrArea"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindArea(string strCode, out clsBIHArea[] arrArea)
        {
            string strSql = @"select deptid_chr, deptname_vchr, shortno_chr, pycode_chr, code_vchr
                                from t_bse_deptdesc
                               where attributeid = '0000003' and status_int = 1
                            order by deptid_chr";

            strCode = strCode.Trim();
            if (strCode.Length <= 0)
            {
                strSql = strSql.Replace("[FindCondition]", "");
            }
            else if ((strCode[0] >= '0') && (strCode[0] <= '9'))
            {
                strSql = strSql.Replace("[FindCondition]", " and Trim(LOWER(code_vchr)) Like '" + strCode.ToLower().Trim() + "%' ");
            }
            else if (((strCode[0] >= 'a') && (strCode[0] <= 'z')) || ((strCode[0] >= 'A') && (strCode[0] <= 'Z')))
            {
                strSql = strSql.Replace("[FindCondition]", " and Trim(LOWER(PYCode_Chr)) Like '" + strCode.ToLower().Trim() + "%' ");
            }
            else
            {
                strSql = strSql.Replace("[FindCondition]", " and LOWER(DeptName_VChr) Like '" + strCode.ToLower().Trim() + "%' ");
            }

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrArea = new clsBIHArea[objDT.Rows.Count];
                for (int i = 0; i < arrArea.Length; i++)
                {
                    arrArea[i] = new clsBIHArea();
                    arrArea[i].m_strAreaID = Convert.ToString(objDT.Rows[i]["DeptID_Chr"]).Trim();
                    arrArea[i].m_strAreaName = Convert.ToString(objDT.Rows[i]["DeptName_VChr"]).Trim();
                    arrArea[i].code = Convert.ToString(objDT.Rows[i]["code_vchr"].ToString().Trim());

                }
                return 1;
            }
            else
            {
                arrArea = null;
                return 0;
            }
        }
        #endregion

        #region 预出院未清帐统计-得到人员列表
        /// <summary>
        /// 得到人员列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="p_strSections"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutNoChargePatientList(string BeginDate, string EndDate, string p_strSections, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                string SQL = @"select d.code_vchr, d.deptname_vchr, e.lastname_vchr as doctname,
                                     a.inpatientid_chr, b.lastname_vchr as patname, a.paytypeid_chr,
                                     f.paytypename_vchr,
                                     to_char (a.inpatient_dat, 'yyyy-mm-dd hh24:mi:ss') as indate,
                                     to_char (c.outhospital_dat, 'yyyy-mm-dd hh24:mi:ss') as outdate,
                                     g.remarkname_vchr, a.registerid_chr
                                from t_opr_bih_register a,
                                     t_opr_bih_registerdetail b,
                                     t_opr_bih_leave c,
                                     t_bse_deptdesc d,
                                     t_bse_employee e,
                                     t_bse_patientpaytype f,
                                     (select registerid_chr, remarkname_vchr
                                        from t_opr_bih_patspecremark
                                       where status_int = 1) g
                               where a.registerid_chr = b.registerid_chr
                                 and a.registerid_chr = c.registerid_chr
                                 and a.areaid_chr = d.deptid_chr(+)
                                 and a.casedoctor_chr = e.empid_chr(+)
                                 and a.paytypeid_chr = f.paytypeid_chr(+)
                                 and a.registerid_chr = g.registerid_chr(+)
                                 and a.status_int = 1
                                 and a.pstatus_int = 2
                                 and c.status_int = 1                                 
                                 and (c.outhospital_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                                 [deptid]
                            order by d.code_vchr, e.lastname_vchr";
                string strDeptId = "";
                if (p_strSections != null && p_strSections != "%")
                {
                    strDeptId = @" and d.deptid_chr='" + p_strSections + "'";

                }

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate;
                ParamArr[1].Value = EndDate;
                SQL = SQL.Replace("[deptid]", strDeptId);
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 预出院未清帐统计-得到病人列表
        /// <summary>
        /// 得到病人列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="p_strSections"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutNoChargePatients(string BeginDate, string EndDate, string p_strSections, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                string SQL = @"select d.code_vchr, d.deptname_vchr, e.lastname_vchr as doctname,
                                     a.inpatientid_chr, b.lastname_vchr as patname, a.paytypeid_chr,
                                     f.paytypename_vchr,
                                     to_char (a.inpatient_dat, 'yyyy-mm-dd hh24:mi:ss') as indate,
                                     to_char (c.outhospital_dat, 'yyyy-mm-dd hh24:mi:ss') as outdate,
                                     g.remarkname_vchr, a.registerid_chr
                                from t_opr_bih_register a,
                                     t_opr_bih_registerdetail b,
                                     t_opr_bih_leave c,
                                     t_bse_deptdesc d,
                                     t_bse_employee e,
                                     t_bse_patientpaytype f,
                                     (select registerid_chr, remarkname_vchr
                                        from t_opr_bih_patspecremark
                                       where status_int = 1) g
                               where a.registerid_chr = b.registerid_chr
                                 and a.registerid_chr = c.registerid_chr
                                 and a.areaid_chr = d.deptid_chr(+)
                                 and a.casedoctor_chr = e.empid_chr(+)
                                 and a.paytypeid_chr = f.paytypeid_chr(+)
                                 and a.registerid_chr = g.registerid_chr(+)
                                 and a.status_int = 1
                                 and a.pstatus_int = 2
                                 and c.status_int = 1                                 
                                 and (c.outhospital_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                     )
                                 [deptid]
                            order by d.code_vchr, e.lastname_vchr";
                string strDeptId = "";
                if (p_strSections != null && p_strSections != "%")
                {
                    strDeptId = @" and d.deptid_chr='" + p_strSections + "'";

                }

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate;
                ParamArr[1].Value = EndDate;
                SQL = p_strSections;
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

        #region 根据REGID获取病人状态分类预交金
        /// <summary>
        /// 根据REGID获取病人状态分类预交金
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepayStatusSumByRegID(string RegID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select a.isclear_int, sum (a.money_dec) as prepaysum
                                from t_opr_bih_prepay a
                               where a.status_int = 1 and a.registerid_chr = ?
                            group by a.isclear_int";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 根据REGID获取病人所有各状态费用信息
        /// <summary>
        /// 根据REGID获取病人所有各状态费用信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientStatusSumByRegID(string RegID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"select a.pstatus_int,
                                     sum (round (a.unitprice_dec * a.amount_dec, 2)) as totalsum,
                                     sum (round (a.totaldiffcostmoney_dec, 2)) as totalsumdiff 
                                from t_opr_bih_patientcharge a
                               where a.status_int = 1
                                 and a.pstatus_int <> 0
                                 and a.chargeactive_dat is not null
                                 and a.registerid_chr = ?
                            group by a.pstatus_int";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 住院月发票统计数据
        /// <summary>
        /// 住院月发票统计数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBIHInvoiceStatData(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_opratorId, string p_beginDate, string p_endDate, out DataTable p_dtbStat)
        {
            long lngRes = 0;
            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsReport", "m_lngGetBIHInvoiceStatData");
            //if (lngRes < 0)//没有使用权限
            //{
            //    return -1;
            //}

            clsHRPTableService objHRPServ = new clsHRPTableService();
            StringBuilder strSQL = new StringBuilder(@"select 
                                a.invoiceno_vchr,
                                a.status_int,       
                                c.chargeno_chr,
                                c.type_int,
                                c.totalsum_mny,
                                c.sbsum_mny,
                                c.acctsum_mny,
                                d.empid_chr,
                                d.lastname_vchr
                             from t_opr_bih_invoice2     a,
                                  t_opr_bih_chargedefinv b, 
                                  t_opr_bih_charge       c,
                                  t_bse_employee         d
                             where a.invoiceno_vchr = b.invoiceno_vchr
                               and b.chargeno_chr = c.chargeno_chr
                               and c.operemp_chr = d.empid_chr(+)
                               and c.recflag_int = 1
                               and c.status_int = 1
                               and c.recdate_dat >= ?
                               and c.recdate_dat <= ?");

            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;
            objHRPServ.CreateDatabaseParameter(3, out tmp_objDPArr);
            int m_intParamCount = 2;
            tmp_objDPArr[0].DbType = DbType.Date;
            tmp_objDPArr[0].Value = Convert.ToDateTime(p_beginDate);
            tmp_objDPArr[1].DbType = DbType.Date;
            tmp_objDPArr[1].Value = Convert.ToDateTime(p_endDate);

            try
            {
                if (p_opratorId.Trim().Length > 0)
                {
                    strSQL.Append(@" and c.recemp_chr = ? order by a.invoiceno_vchr asc,c.chargeno_chr asc");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = p_opratorId;
                }
                else
                {
                    strSQL.Append(@" order by a.invoiceno_vchr asc,c.chargeno_chr asc");
                }

                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }


                p_dtbStat = new DataTable();
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbStat, objDPArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_dtbStat = null;
            }
            objHRPServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据操作员Id和日期查找住院重打发票信息
        /// <summary>
        /// 根据操作员Id和日期查找住院重打发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBIHBillReprintByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strOperatorId,
                                                 string p_strStartDate,
                                                 string p_strEndDate,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsReport", "m_lngGetBIHBillReprintByDate");
            //if (lngRes < 0)
            //{
            //    return -1;
            //}

            StringBuilder strSQL = new StringBuilder(
                              @"select distinct a.sourcebillno_vchr, a.repprnbillno_vchr, a.printemp_chr
                                    from t_opr_bih_billrepeatprint a,
                                         t_opr_bih_charge          b
                                    where a.billid_chr = b.chargeno_chr
                                      and a.billtype_chr = 2
                                      and a.printstatus_int = 0
                                      and b.type_int = 1
                                      and b.recflag_int = 1
                                      and b.status_int = 1
                                      and b.recdate_dat >= ?
                                      and b.recdate_dat <= ?");

            //            StringBuilder strSQL = new StringBuilder(
            //                              @"select a.sourcebillno_vchr,
            //                                       a.repprnbillno_vchr,
            //                                       a.printemp_chr       
            //                                from t_opr_bih_billrepeatprint  a,
            //                                     t_opr_bih_chargedefinv     b,
            //                                     t_opr_bih_charge           c
            //                                where a.sourcebillno_vchr = b.invoiceno_vchr
            //                                  and b.chargeno_chr = c.chargeno_chr
            //                                  and a.billtype_chr = 2
            //                                  and a.printstatus_int = 0
            //                                  and c.type_int = 1   
            //                                  and c.recflag_int = 1
            //                                  and c.status_int = 1
            //                                  and c.recdate_dat >= ?
            //                                  and c.recdate_dat <= ?");

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParamerArr = null;
            IDataParameter[] tmp_objParamerArr = null;
            objHRPSvc.CreateDatabaseParameter(3, out tmp_objParamerArr);
            int m_intParamCount = 2;
            tmp_objParamerArr[0].DbType = DbType.Date;
            tmp_objParamerArr[0].Value = Convert.ToDateTime(p_strStartDate);
            tmp_objParamerArr[1].DbType = DbType.Date;
            tmp_objParamerArr[1].Value = Convert.ToDateTime(p_strEndDate);

            try
            {
                if (p_strOperatorId.Trim().Length > 0)
                {
                    strSQL.Append(@" and a.printemp_chr = ?");
                    ++m_intParamCount;
                    tmp_objParamerArr[m_intParamCount - 1].Value = p_strOperatorId;
                }

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamerArr);
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objParamerArr[i1].Value = tmp_objParamerArr[i1].Value;
                    objParamerArr[i1].DbType = tmp_objParamerArr[i1].DbType;
                }


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtResult, objParamerArr);
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
        #endregion //根据操作员Id和日期查找住院重打发票信息

        #region 获取所有的收费员数据
        /// <summary>
        /// 获取所有的收费员数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtCheckMan"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecEmp(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbRecEmp)
        {
            long lngRes = 0;
            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            ////检查是否有使用些函数的权限
            //long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsReport", "m_lngGetRecEmp");
            //if (lngRes < 0) //没有使用的权限
            //{
            //    return -1;
            //}

            string strSQL = @"select distinct 
                                a.recemp_chr, 
                                b.lastname_vchr
                              from t_opr_bih_charge a, t_bse_employee b
                              where a.recemp_chr = b.empid_chr(+)
                                and a.recemp_chr is not null
                              order by a.recemp_chr asc";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            p_dtbRecEmp = new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref p_dtbRecEmp);
            }
            catch (Exception objEx)
            {
                string strTmp1 = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger1 = new clsLogText();
                bool blnRes1 = objLogger1.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;

        }
        #endregion //获取所有的收费员数据

        #region 病区工作日志
        /// <summary>
        /// 获取病区
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_Dept(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.deptid_chr, a.deptname_vchr, a.stdbed_count_int
                            from t_bse_deptdesc a
                           where a.inpatientoroutpatient_int = 1
                             and a.status_int = 1
                             and a.attributeid = '0000003'
                        order by a.code_vchr";

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

        /// <summary>
        /// 当天入院人数
        /// </summary>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_InNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SubStr = "";

            if (AreaID != null && AreaID.Trim() != "")
            {
                SubStr = " and a.targetareaid_chr = '" + AreaID + "' ";
            }

            string SQL = @"select a.targetareaid_chr as areaid_chr, c.paytypeid_chr,
                                 count (a.registerid_chr) as innums
                            from t_opr_bih_transfer a, t_opr_bih_register c
                           where a.registerid_chr = c.registerid_chr
                             and c.relateregisterid_chr is null
                             and c.bedid_chr is not null
                             and c.status_int = 1
                             and a.modify_dat =
                                    (select min (b.modify_dat)
                                       from t_opr_bih_transfer b
                                      where a.registerid_chr = b.registerid_chr
                                        and b.type_int = 5 
                                        and trunc (b.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd'))) " + SubStr + @" 
                        group by a.targetareaid_chr, c.paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 当天出院人数
        /// </summary>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_OutNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SubStr = "";

            if (AreaID != null && AreaID.Trim() != "")
            {
                SubStr = " and a.outareaid_chr = '" + AreaID + "' ";
            }

            string SQL = @"select a.outareaid_chr, b.paytypeid_chr, count (a.registerid_chr) as outnums
                            from t_opr_bih_leave a, t_opr_bih_register b
                           where a.registerid_chr = b.registerid_chr     
   	                         and b.relateregisterid_chr is null   	 
                             and a.status_int = 1
                             and b.status_int = 1 " + SubStr + @" 
                             and trunc (a.outhospital_dat) = trunc (to_date (?, 'yyyy-mm-dd'))
                        group by a.outareaid_chr, b.paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 出院死亡人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_OutDeadNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.outareaid_chr, count (a.registerid_chr) as outdeadnums
                            from t_opr_bih_leave a, t_opr_bih_register b
                           where a.registerid_chr = b.registerid_chr
                             and b.relateregisterid_chr is null
                             and a.status_int = 1
                             and b.status_int = 1
                             and a.type_int = 4
                             and a.outareaid_chr = ?
                             and trunc (a.outhospital_dat) = trunc (to_date (?, 'yyyy-mm-dd'))
                        group by a.outareaid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 出院死亡人数(24小时)
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_OutDead24Nums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.outareaid_chr, count (a.registerid_chr) as outdead24nums
                            from t_opr_bih_leave a, t_opr_bih_register b
                           where a.registerid_chr = b.registerid_chr
                             and b.relateregisterid_chr is null
                             and a.status_int = 1
                             and b.status_int = 1
                             and a.type_int = 4
                             and a.outareaid_chr = ?
                             and floor ((a.outhospital_dat - b.inpatient_dat) * 24) <= 12
                             and trunc (a.outhospital_dat) = trunc (to_date (?, 'yyyy-mm-dd'))
                        group by a.outareaid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 当天在院人数
        /// </summary>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_OnNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SubStr = "";

            if (AreaID != null && AreaID.Trim() != "")
            {
                SubStr = " and a.areaid_chr = '" + AreaID + "' ";
            }

            string SQL = @"select a.areaid_chr, a.paytypeid_chr,decode(a.state_int,1,1,0) as state_int,
                                 count (a.registerid_chr) as onnums
                            from (select c.targetareaid_chr as areaid_chr, a.registerid_chr, a.paytypeid_chr,a.state_int,
                                         a.inpatient_dat as indate,
                                         nvl (b.outhospital_dat, sysdate + 100) as outdate
                                    from t_opr_bih_register a,
                                         (select registerid_chr, outhospital_dat
                                            from t_opr_bih_leave
                                           where status_int = 1) b,
                                         (select a.registerid_chr, a.targetareaid_chr
                                            from t_opr_bih_transfer a
                                           where a.modify_dat =
                                                    (select max (b.modify_dat)
                                                       from t_opr_bih_transfer b
                                                      where a.registerid_chr = b.registerid_chr
                                                        and (b.type_int <> 0 and b.type_int <> 1)  
                                                        and trunc (b.modify_dat) <= trunc (to_date (?, 'yyyy-mm-dd')))) c
                                   where a.registerid_chr = b.registerid_chr(+)
                                     and a.registerid_chr = c.registerid_chr
                                     and a.relateregisterid_chr is null
                                     and a.bedid_chr is not null
                                     and a.status_int = 1) a
                           where (    trunc (to_date (?, 'yyyy-mm-dd')) >= trunc (a.indate)
                                  and trunc (to_date (?, 'yyyy-mm-dd')) < trunc (a.outdate)
                                 ) " + SubStr + @"
                        group by a.areaid_chr,a.state_int, a.paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = CurrDate;
                ParamArr[1].Value = CurrDate;
                ParamArr[2].Value = CurrDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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


        /// <summary>
        /// 当天在院分娩人数
        /// </summary>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_FMNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SubStr = "";


            if (AreaID != null && AreaID.Trim() != "")
            {
                SubStr = " and a.areaid_chr = '" + AreaID + "' ";
            }

            string SQL = @"select a.areaid_chr, count(a.registerid_chr) as onnums
                      from t_opr_bih_register a
                     where a.status_int = 1
                       and a.isshunchan = 1
                       and trunc(a.modify_dat) = trunc(to_date(?, 'yyyy-mm-dd'))
                     group by a.areaid_chr ";

            dt = new DataTable();


            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = CurrDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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



        /// <summary>
        /// 当天转出人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_TransOutNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select b.paytypeid_chr, count (a.registerid_chr) as transoutnums
                            from t_opr_bih_transfer a,
                                 t_opr_bih_register b 
                           where a.registerid_chr = b.registerid_chr
                             and b.relateregisterid_chr is null
                             and b.bedid_chr is not null
                             and b.status_int = 1
                             and a.type_int = 3
                             and a.sourceareaid_chr = ?
                             and trunc (a.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd'))
                        group by b.paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 当天转入人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_TransInNums(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select b.paytypeid_chr, count (a.registerid_chr) as transinnums
                            from t_opr_bih_transfer a,
                                 t_opr_bih_register b 
                           where a.registerid_chr = b.registerid_chr
                             and b.relateregisterid_chr is null
                             and b.bedid_chr is not null
                             and b.status_int = 1
                             and a.type_int = 3
                             and a.targetareaid_chr = ?
                             and trunc (a.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd')) 
                        group by b.paytypeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 入院病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_InPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  c.inpatientid_chr, d.lastname_vchr, d.sex_chr, e.code_chr,
                                   c.mzdiagnose_vchr
                              from t_opr_bih_transfer a,
                                   t_opr_bih_register c,
                                   t_opr_bih_registerdetail d,
                                   t_bse_bed e
                             where a.registerid_chr = c.registerid_chr
                               and c.registerid_chr = d.registerid_chr
                               and a.targetbedid_chr = e.bedid_chr(+)
                               and c.relateregisterid_chr is null
                               and c.bedid_chr is not null
                               and c.status_int = 1
                               and a.targetareaid_chr = ?
                               and a.modify_dat =
                                      (select min (b.modify_dat)
                                         from t_opr_bih_transfer b
                                        where a.registerid_chr = b.registerid_chr
                                          and b.type_int = 5                                          
                                          and trunc (b.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd')))";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 转入病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_TransInPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  b.inpatientid_chr, c.lastname_vchr, c.sex_chr,
                                   d.code_chr as sourcebedno, e.deptname_vchr, f.code_chr as targetbedno
                              from t_opr_bih_transfer a,
                                   t_opr_bih_register b,
                                   t_opr_bih_registerdetail c,
                                   t_bse_bed d,
                                   t_bse_deptdesc e,
                                   t_bse_bed f
                             where a.registerid_chr = b.registerid_chr
                               and b.registerid_chr = c.registerid_chr
                               and a.targetbedid_chr = d.bedid_chr(+)
                               and a.sourceareaid_chr = e.deptid_chr(+)
                               and a.sourcebedid_chr = f.bedid_chr(+)
                               and b.relateregisterid_chr is null
                               and b.bedid_chr is not null
                               and b.status_int = 1
                               and a.type_int = 3
                               and a.targetareaid_chr = ?
                               and trunc (a.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd'))";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 转出病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_TransOutPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  b.inpatientid_chr, c.lastname_vchr, c.sex_chr,
                                   d.code_chr as sourcebedno, e.deptname_vchr, f.code_chr as targetbedno
                              from t_opr_bih_transfer a,
                                   t_opr_bih_register b,
                                   t_opr_bih_registerdetail c,
                                   t_bse_bed d,
                                   t_bse_deptdesc e,
                                   t_bse_bed f
                             where a.registerid_chr = b.registerid_chr
                               and b.registerid_chr = c.registerid_chr
                               and a.sourcebedid_chr = d.bedid_chr(+)
                               and a.targetareaid_chr = e.deptid_chr(+)
                               and a.targetbedid_chr = f.bedid_chr(+)
                               and b.relateregisterid_chr is null
                               and b.bedid_chr is not null
                               and b.status_int = 1
                               and a.type_int = 3
                               and a.sourceareaid_chr = ?
                               and trunc (a.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd'))";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        /// <summary>
        /// 出院病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptDeptWorkLog_OutPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  b.inpatientid_chr, c.lastname_vchr, c.sex_chr, d.code_chr,
                                   a.diagnose_vchr
                              from t_opr_bih_leave a,
                                   t_opr_bih_register b,
                                   t_opr_bih_registerdetail c,
                                   t_bse_bed d
                             where a.registerid_chr = b.registerid_chr
                               and b.registerid_chr = c.registerid_chr
                               and b.bedid_chr = d.bedid_chr(+)
                               and b.relateregisterid_chr is null
                               and a.status_int = 1
                               and b.status_int = 1
                               and a.outareaid_chr = ?
                               and trunc (a.outhospital_dat) = trunc (to_date (?, 'yyyy-mm-dd'))";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = AreaID;
                ParamArr[1].Value = CurrDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 合作医疗
        #region 基本资料
        /// <summary>
        /// 基本资料
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLPatientInfo(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select distinct c.patientcardid_chr, b.idcard_chr, d.idno_vchr, e.vbcode_vchr,
                                   b.lastname_vchr, b.sex_chr, b.birth_dat
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_bse_patientidentityno d,
                                   t_aid_villageboard e
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.patientid_chr = d.patientid_chr
                               and a.paytypeid_chr = d.paytypeid_chr
                               and b.birthplace_vchr = e.vbname_vchr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and e.cantoncode_chr = '003'
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方合计
        #region 处方合计1-西药
        /// <summary>
        /// 处方合计1-西药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeSum1(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, 1 as cflx, a.recorddate_dat, c.patientcardid_chr,
                                   sum (d.totalsum_mny) as zje, sum (nvl(d.acctsum_mny,0)) as mfje, nvl(a.ts, 0) as ts
                              from (select   a.patientid_chr, a.outpatrecipeid_chr, a.recorddate_dat, max (b.days_int) as ts
                                        from t_opr_outpatientrecipe a, t_opr_outpatientpwmrecipede b
                                       where a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                                         and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                         and a.paytypeid_chr in (" + PayTypeID + @")
                                         and (a.recorddate_dat between ? and ?)
                                    group by a.patientid_chr, a.outpatrecipeid_chr, a.recorddate_dat) a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientrecipeinv d
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and (c.status_int = 1 or c.status_int = 3) 
                          group by a.outpatrecipeid_chr, a.recorddate_dat, c.patientcardid_chr, a.ts";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方合计2-中药
        /// <summary>
        /// 处方合计2-中药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeSum2(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, 2 as cflx, a.recorddate_dat, c.patientcardid_chr,
                                   sum (d.totalsum_mny) as zje, sum (nvl(d.acctsum_mny,0)) as mfje, nvl(a.fs, 0) as fs
                              from (select   a.patientid_chr, a.outpatrecipeid_chr, a.recorddate_dat, max (b.times_int) as fs
                                        from t_opr_outpatientrecipe a, t_opr_outpatientcmrecipede b
                                       where a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                         and (a.pstauts_int = 2 or a.pstauts_int = 3)
                                         and a.paytypeid_chr in (" + PayTypeID + @")
                                         and (a.recorddate_dat between ? and ?)
                                    group by a.patientid_chr, a.outpatrecipeid_chr, a.recorddate_dat) a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientrecipeinv d
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and (c.status_int = 1 or c.status_int = 3) 
                          group by a.outpatrecipeid_chr, a.recorddate_dat, c.patientcardid_chr, a.fs";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细
        #region 处方明细1-西药
        /// <summary>
        /// 处方明细1-西药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry1(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.unitprice_mny as dj, d.tolqty_dec as sl, d.tolprice_mny as je,
                                   1 as cflx, d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientpwmrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细2-中药
        /// <summary>
        /// 处方明细2-中药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry2(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.unitprice_mny as dj, d.qty_dec * d.times_int as sl,
                                   d.tolprice_mny as je, 2 as cflx, d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientcmrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细3-检验
        /// <summary>
        /// 处方明细3-检验
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry3(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.price_mny as dj, d.qty_dec as sl, d.tolprice_mny as je, 1 as cflx,
                                   d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientchkrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细4-检查
        /// <summary>
        /// 处方明细4-检查
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry4(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.price_mny as dj, d.qty_dec as sl, d.tolprice_mny as je, 1 as cflx,
                                   d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatienttestrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细5-治疗
        /// <summary>
        /// 处方明细5-治疗
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry5(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.price_mny as dj, d.qty_dec as sl, d.tolprice_mny as je, 1 as cflx,
                                   d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientopsrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 处方明细6-材料
        /// <summary>
        /// 处方明细6-材料
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHZYLRecipeEntry6(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.outpatrecipeid_chr, c.patientcardid_chr, a.recorddate_dat,
                                   e.itemcode_vchr, e.insuranceid_chr, e.itemname_vchr, f.typename_vchr,
                                   d.unitprice_mny as dj, d.qty_dec as sl, d.tolprice_mny as je, 1 as cflx,
                                   d.itemspec_vchr
                              from t_opr_outpatientrecipe a,
                                   t_bse_patient b,
                                   t_bse_patientcard c,
                                   t_opr_outpatientothrecipede d,
                                   t_bse_chargeitem e,
                                   t_bse_chargeitemextype f
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = c.patientid_chr
                               and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                               and d.itemid_chr = e.itemid_chr
                               and e.itemopinvtype_chr = f.typeid_chr
                               and (a.pstauts_int = 2 or a.pstauts_int = 3)
                               and (c.status_int = 1 or c.status_int = 3)
                               and f.flag_int = 2
                               and a.paytypeid_chr in (" + PayTypeID + @")
                               and (a.recorddate_dat between ? and ?)";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);

                ParamArr[0].Value = Convert.ToDateTime(BeginDate + " 00:00:00");
                ParamArr[1].Value = Convert.ToDateTime(EndDate + " 23:59:59");

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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
        #endregion

        #region 医保身份
        /// <summary>
        /// 医保身份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetALLYBType(out DataTable dt)
        {
            string strSQL = @"select '-1' as paytypeid_chr, '全部' as paytypename_vchr,
                                   '' as paytypeno_vchr
                              from dual
                            union all
                            select paytypeid_chr, paytypename_vchr, paytypeno_vchr
                              from (select   p.paytypeid_chr, p.paytypename_vchr, p.paytypeno_vchr
                                        from t_bse_patientpaytype p
                                    order by p.paytypeno_vchr) ";
            long lngRes = -1;
            dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
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

        #region 查找医保-HIS对应项目
        /// <summary>
        /// 查找医保-HIS对应项目
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetShiying(string strQuery, out DataTable dtResult)
        {
            long lngRes = 0;
            dtResult = new DataTable();
            string strSQL = string.Empty;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (strQuery == string.Empty)
            {
                strSQL = @"select t.hisitemcode_vchr,
                                   t.ybitemcode_vchr,
                                   t.itemtype,
                                   t.itemname_vchr,
                                   t.englishname_vchr,
                                   t.itemjixingtype_vchr,
                                   t.xzsyzbz,
                                   t.xzsysm,
                                   t.yxbz
                              from t_bse_chargeitemybrla t";
                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                strSQL = @"select t.hisitemcode_vchr,
                                   t.ybitemcode_vchr,
                                   t.itemtype,
                                   t.itemname_vchr,
                                   t.englishname_vchr,
                                   t.itemjixingtype_vchr,
                                   t.xzsyzbz,
                                   t.xzsysm,
                                   t.yxbz
                              from t_bse_chargeitemybrla t
                            where t.hisitemcode_vchr like ?
                            or t.ybitemcode_vchr like ?
                            or t.itemname_vchr like ?";

                IDataParameter[] paraArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paraArr);
                paraArr[0].Value = strQuery + "%";
                paraArr[1].Value = strQuery + "%";
                paraArr[2].Value = strQuery + "%";
                try
                {
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, paraArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 保存适应症
        /// <summary>
        /// 保存适应症
        /// </summary>
        /// <param name="strHosCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveShiying(clsShiyingVO objVO)
        {
            long lngRes = 0;
            long lngEffect = 0;
            string strSQL = string.Empty;
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paraArr = null;
            try
            {
                strSQL = @"delete from t_bse_chargeitemybrla a where a.hisitemcode_vchr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out paraArr);
                paraArr[0].Value = objVO.HosCode;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            try
            {
                strSQL = @"insert into t_bse_chargeitemybrla values(?,?,?,?,?,?,?,?,?)";
                objHRPSvc.CreateDatabaseParameter(9, out paraArr);
                paraArr[0].Value = objVO.HosCode;
                paraArr[1].Value = objVO.ybitemcode;
                paraArr[2].Value = objVO.itemtype;
                paraArr[3].Value = objVO.itemname;
                paraArr[4].Value = objVO.englishname;
                paraArr[5].Value = objVO.itemjixingtype;
                paraArr[6].Value = objVO.xzsyzbz;
                paraArr[7].Value = objVO.xzsysm;
                paraArr[8].Value = objVO.yxbz;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (objVO.xzsysm != "")
            {
                try
                {
                    strSQL = @"delete from t_bse_shiying a where a.menucode_vchr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out paraArr);
                    paraArr[0].Value = objVO.ybitemcode;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                try
                {
                    strSQL = @"insert into t_bse_shiying values(?,?,?,?,?,?)";
                    objHRPSvc.CreateDatabaseParameter(6, out paraArr);
                    paraArr[0].Value = objVO.ybitemcode;
                    paraArr[1].Value = objVO.itemtype;
                    paraArr[2].Value = objVO.itemname;
                    paraArr[3].Value = objVO.englishname;
                    paraArr[4].Value = objVO.itemjixingtype;
                    paraArr[5].Value = objVO.xzsysm;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 删除适应症
        /// <summary>
        /// 删除适应症
        /// </summary>
        /// <param name="strHosCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelShiying(clsShiyingVO objVO)
        {
            long lngRes = 0;
            long lngEffect = 0;
            string strSQL = string.Empty;
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paraArr = null;
            try
            {
                strSQL = @"delete from t_bse_chargeitemybrla a where a.hisitemcode_vchr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out paraArr);
                paraArr[0].Value = objVO.HosCode;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            if (objVO.xzsysm != "")
            {
                try
                {
                    strSQL = @"delete from t_bse_shiying a where a.menucode_vchr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out paraArr);
                    paraArr[0].Value = objVO.ybitemcode;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEffect, paraArr);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;
        }
        #endregion

        #region 收费处缴款报表统计让利金额
        /// <summary>
        /// 收费处缴款报表统计让利金额
        /// </summary>
        /// <param name="strHosCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptTotaldiffcostmoney(string m_strChargeno, string EmpID, out DataTable dttodiffsum)
        {
            long lngRes = 0;
            string strSQL = string.Empty;
            dttodiffsum = new DataTable();
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paraArr = null;
            try
            {
                strSQL = @"select max(nvl(b.totalsum_mny,0)) as totaldiffcostmoney_dec 
                             from t_opr_bih_charge a,t_opr_bih_invoice2de b,t_opr_bih_chargedefinv c
                            where a.chargeno_chr = c.chargeno_chr
                              and b.invoiceno_vchr = c.invoiceno_vchr
                              and b.itemcatid_chr = '3026'
                              and a.recemp_chr = ?
                              and a.chargeno_chr = ?";
                objHRPSvc.CreateDatabaseParameter(2, out paraArr);
                paraArr[0].Value = EmpID;
                paraArr[1].Value = m_strChargeno;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dttodiffsum, paraArr);

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

        #region 社保登记日志
        /// <summary>
        /// 社保登记日志
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="deptIdArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetRptSbRegister(string beginDate, string endDate, string deptIdArr)
        {
            string Sql = string.Empty;
            DataTable dtResult = new DataTable();
            HRPService.clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                Sql = @"select b.inpatientid_chr as ipNo,
                               b.inpatient_dat as inDate,
                               a.zylb_vchr,
                               a.jzlb_vchr,
                               a.yycyks_vchr,
                               a.cbdtcqbm_vchr as cbdtcqbm, 
                               a.operatime_dat as regDate,
                               a.recorddate as regDate2,
                               f.lastname_vchr as operName,
                               a.status_chr,
                               c.lastname_vchr as patName,
                               c.sex_chr,
                               c.birth_dat,
                               d.deptname_vchr as areaName,
                               e.bed_no as bedNo,
                               (p.totalmoney - p.clearmoney) as premoney,
                               0    as flag,
                               0    as nums 
                          from t_ins_cszyreg a
                         inner join t_opr_bih_register b
                            on a.registerid_vchr = b.registerid_chr
                         inner join t_opr_bih_registerdetail c
                            on a.registerid_vchr = c.registerid_chr
                         inner join t_bse_deptdesc d
                            on b.areaid_chr = d.deptid_chr
                          left join t_bse_bed e
                            on b.bedid_chr = e.bedid_chr
                          left join t_bse_employee f
                            on a.recordoperid = f.empid_chr
                          left join (select t.registerid_chr,
                                            sum(t.money_dec) as totalmoney,
                                            sum((case t.isclear_int
                                                  when 1 then
                                                   t.money_dec
                                                  else
                                                   0
                                                end)) as clearmoney
                                       from t_opr_bih_prepay t
                                      where t.status_int = 1
                                      group by t.registerid_chr) p
                            on a.registerid_vchr = p.registerid_chr
                     where (a.operatime_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 
                     ";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                if (!string.IsNullOrEmpty(deptIdArr))
                {
                    Sql += string.Format("and b.deptid_chr in ({0})", deptIdArr);
                }
                svc.lngGetDataTableWithParameters(Sql, ref dtResult, parm);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    for (int i = dtResult.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dtResult.Rows[i]["status_chr"].ToString()) < 0)
                        {
                            dtResult.Rows.RemoveAt(i);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtResult;
        }
        #endregion

        #region 门诊住院退费原因
        /// <summary>
        /// 门诊住院退费原因
        /// </summary>
        /// <param name="flagId">1 门诊; 1 住院; 3 预交金</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetRptInvoiceRefundReason(int flagId, string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dtResult = new DataTable();
            HRPService.clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                if (flagId == 1)
                {
                    Sql = @"select a.flagid,
                                   a.invono,
                                   (abs(b.totalsum_mny) - abs(b.totaldiffcost_mny)) as invomny,
                                   a.operdate,
                                   b.patientname_chr as patname,
                                   b.deptname_chr as deptname,
                                   a.reason
                              from t_invoice_refundreason a
                             inner join t_opr_outpatientrecipeinv b
                                on a.invono = b.invoiceno_vchr
                               and b.status_int = 2
                             where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                }
                else if (flagId == 2)
                {
                    Sql = @"select a.flagid, a.invono, b.totalsum_mny as invomny, a.operdate, a.reason
                              from t_invoice_refundreason a
                             inner join t_opr_bih_invoice2 b
                                on a.invono = b.invoiceno_vchr
                               and b.status_int = 2
                             where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                }
                else if (flagId == 3)
                {
                    Sql = @"select a.flagid,
                                   a.invono,
                                   b.money_dec     as invomny,
                                   a.operdate,
                                   b.areaname_vchr as deptname,
                                   a.reason
                              from t_invoice_refundreason a
                             inner join t_opr_bih_prepay b
                                on a.invono = b.prepayinv_vchr
                               and b.paytype_int = 2
                             where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                   to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                }

                #region bak
                //                Sql = @"select a.flagid,
                //                               a.invono,
                //                               (abs(b.totalsum_mny) - abs(b.totaldiffcost_mny)) as invomny,
                //                               a.operdate,
                //                               c.patientcardid_chr as patno,
                //                               b.patientname_chr as patname,
                //                               d.sex_chr as sex,
                //                               d.birth_dat,
                //                               b.deptname_chr as deptname,
                //                               a.reason
                //                          from t_invoice_refundreason a
                //                         inner join t_opr_outpatientrecipeinv b
                //                            on a.invono = b.invoiceno_vchr
                //                           and b.status_int = 2
                //                         inner join t_bse_patientcard c
                //                            on b.patientid_chr = c.patientid_chr
                //                         inner join t_bse_patient d
                //                            on b.patientid_chr = d.patientid_chr
                //                         where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                //                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                //                        union all
                //                        select a.flagid,
                //                               a.invono,
                //                               b.totalsum_mny    as invomny,
                //                               a.operdate,
                //                               c.inpatientid_chr as patno,
                //                               d.lastname_vchr   as patname,
                //                               d.sex_chr         as sex,
                //                               d.birth_dat,
                //                               e.deptname_vchr   as deptname,
                //                               a.reason
                //                          from t_invoice_refundreason a
                //                         inner join t_opr_bih_invoice2 b
                //                            on a.invono = b.invoiceno_vchr
                //                           and b.status_int = 2
                //                         inner join t_opr_bih_chargedefinv b1
                //                            on b.invoiceno_vchr = b1.invoiceno_vchr
                //                         inner join t_opr_bih_charge b2
                //                            on b1.chargeno_chr = b2.chargeno_chr
                //                         inner join t_opr_bih_register c
                //                            on b2.registerid_chr = c.registerid_chr
                //                         inner join t_opr_bih_registerdetail d
                //                            on c.registerid_chr = d.registerid_chr
                //                          left join t_bse_deptdesc e
                //                            on b2.areaid_chr = e.deptid_chr
                //                         where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                //                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                //                        union all
                //                        select a.flagid,
                //                               a.invono,
                //                               b.money_dec       as invomny,
                //                               a.operdate,
                //                               c.inpatientid_chr as patno,
                //                               d.lastname_vchr   as patname,
                //                               d.sex_chr         as sex,
                //                               d.birth_dat,
                //                               b.areaname_vchr   as deptname,
                //                               a.reason
                //                          from t_invoice_refundreason a
                //                         inner join t_opr_bih_prepay b
                //                            on a.invono = b.prepayinv_vchr
                //                           and b.paytype_int = 2
                //                         inner join t_opr_bih_register c
                //                            on b.registerid_chr = c.registerid_chr
                //                         inner join t_opr_bih_registerdetail d
                //                            on c.registerid_chr = d.registerid_chr
                //                         where (a.operdate between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                //                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                #endregion

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dtResult, parm);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtResult;
        }
        #endregion

        #region 获取外送单位
        /// <summary>
        /// 获取外送单位
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOutsideUnit()
        {
            string Sql = string.Empty;
            DataTable dt = null;
            try
            {
                Sql = @"select a.funitno, a.funitname from t_aid_outsideunit a";

                clsHRPTableService svc = new clsHRPTableService();
                svc.lngGetDataTableWithoutParameters(Sql, ref dt);
                svc.Dispose();
                svc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dt;
        }
        #endregion

        #region 获取外送费用明细
        /// <summary>
        /// 获取外送费用明细
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetOutsideChargeItem(string beginDate, string endDate)
        {
            string Sql = string.Empty;
            DataTable dtResult = null;
            DataTable dt = null;
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                #region bak

                /*Sql = @"select 1 as flagId,
                               a.recorddate_dat as recipeDate,
                               b.patientname_chr as patName,
                               b.invoiceno_vchr,
                               c.orderdicid_chr,
                               c.orderdicname_vchr as orderName,
                               c.pricemny_dec as orderPrice,
                               c.qty_dec as orderQty,
                               c.totalmny_dec * (case b.status_int
                                 when 1 then
                                  1
                                 when 3 then
                                  1
                                 else
                                  -1
                               end) as orderTotal,
                               d.outsideunit,
                               e.patientcardid_chr as cardNo,
                               '' as ipNo,
                               a.patientid_chr as pid, 
                               f.deptname_vchr as deptName,
                               g.lastname_vchr as doctName
                          from t_opr_outpatientrecipe a
                         inner join t_opr_outpatientrecipeinv b
                            on a.outpatrecipeid_chr = b.outpatrecipeid_chr
                         inner join t_opr_outpatient_orderdic c
                            on a.outpatrecipeid_chr = c.outpatrecipeid_chr
                         inner join t_bse_bih_orderdic d
                            on c.orderdicid_chr = d.orderdicid_chr
                         inner join t_bse_patientcard e
                            on a.patientid_chr = e.patientid_chr
                          left join t_bse_deptdesc f
                            on a.diagdept_chr = f.deptid_chr
                          left join t_bse_employee g
                            on a.diagdr_chr = g.empid_chr
                         where d.isoutside = 1
                           and (b.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                        union all
                        select 2 as flagId,
                               tg.recipeDate,
                               r.lastname_vchr as patName,
                               '' as invoiceno_vchr,
                               tg.orderdicid_chr,
                               tg.orderName,
                               abs(tg.orderTotal) as orderPrice,
                               tg.orderQty,
                               tg.orderTotal,
                               tg.outsideunit,
                               '' as cardNo,
                               p.inpatientid_chr as ipNo,
                               p.patientid_chr as pid, 
                               tg.deptName,
                               tg.doctName
                          from (select b.chargeactive_dat as recipeDate,
                                       a.registerid_chr,
                                       a.orderid_chr,
                                       a.orderdicid_chr,
                                       a.name_vchr as orderName,
                                       1 as orderQty,
                                       sum(round(b.unitprice_dec * b.amount_dec, 2)) as orderTotal,
                                       c.outsideunit,
                                       f.deptname_vchr as deptName,
                                       b.chargedoctor_vchr as doctName
                                  from t_opr_bih_order a
                                 inner join t_opr_bih_patientcharge b
                                    on a.orderid_chr = b.orderid_chr
                                 inner join t_bse_bih_orderdic c
                                    on a.orderdicid_chr = c.orderdicid_chr
                                  left join t_bse_deptdesc f
                                    on b.createarea_chr = f.deptid_chr
                                 where b.status_int = 1
                                   and b.pstatus_int <> 0
                                   and c.isoutside = 1
                                   and (b.chargeactive_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                 group by b.chargeactive_dat,
                                          a.registerid_chr,
                                          a.orderid_chr,
                                          a.orderdicid_chr,
                                          a.name_vchr,
                                          c.outsideunit,
                                          f.deptname_vchr,
                                          b.chargedoctor_vchr) tg
                         inner join t_opr_bih_registerdetail r
                            on tg.registerid_chr = r.registerid_chr
                         inner join t_opr_bih_register p
                            on r.registerid_chr = p.registerid_chr"; */
                #endregion

                #region 门诊

                #region bak
                Sql = @"select 1 as flagId,
                               a.recorddate_dat as recipeDate,
                               b.patientname_chr as patName,
                               b.invoiceno_vchr,
                               c.orderdicid_chr,
                               c.orderdicname_vchr as orderName,
                               nvl(c.pricemny_dec,0) as orderPrice,
                               nvl(c.qty_dec,0) as orderQty,
                               nvl(c.totalmny_dec * (case b.status_int
                                 when 1 then
                                  1
                                 when 3 then
                                  1
                                 else
                                  -1
                               end),0) as orderTotal,
                               d.outsideunit,
                               e.patientcardid_chr as cardNo,
                               '' as ipNo,
                               a.patientid_chr as pid, 
                               f.deptname_vchr as deptName,
                               g.lastname_vchr as doctName
                          from t_opr_outpatientrecipe a
                         inner join t_opr_outpatientrecipeinv b
                            on a.outpatrecipeid_chr = b.outpatrecipeid_chr
                         inner join t_opr_outpatient_orderdic c
                            on a.outpatrecipeid_chr = c.outpatrecipeid_chr
                         inner join t_bse_bih_orderdic d
                            on c.orderdicid_chr = d.orderdicid_chr
                         inner join t_bse_patientcard e
                            on a.patientid_chr = e.patientid_chr
                          left join t_bse_deptdesc f
                            on a.diagdept_chr = f.deptid_chr
                          left join t_bse_employee g
                            on a.diagdr_chr = g.empid_chr
                         where d.isoutside = 1
                           and (b.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";
                #endregion

                Sql = @"select 1 as flagId,
                               a.recorddate_dat as recipeDate,
                               b.patientname_chr as patName,
                               b.invoiceno_vchr,
                               d.itemid_chr as orderdicid_chr,
                               dc.itemname_vchr as orderName,
                               nvl(dc.itemprice_mny, 0) as orderPrice,
                               nvl(c.qty_dec, 0) as orderQty,
                               nvl(round(dc.itemprice_mny * c.qty_dec, 2) *
                                   (case b.status_int
                                      when 1 then
                                       1
                                      when 3 then
                                       1
                                      else
                                       -1
                                    end),
                                   0) as orderTotal,
                               d.outsideunit,
                               e.patientcardid_chr as cardNo,
                               '' as ipNo,
                               a.patientid_chr as pid,
                               f.deptname_vchr as deptName,
                               g.lastname_vchr as doctName
                          from t_opr_outpatientrecipe a
                         inner join t_opr_outpatientrecipeinv b
                            on a.outpatrecipeid_chr = b.outpatrecipeid_chr
                         inner join t_opr_outpatient_orderdic c
                            on a.outpatrecipeid_chr = c.outpatrecipeid_chr
                         inner join t_bse_bih_orderdic d
                            on c.orderdicid_chr = d.orderdicid_chr
                         inner join t_bse_chargeitem dc
                            on d.itemid_chr = dc.itemid_chr
                         inner join t_bse_patientcard e
                            on a.patientid_chr = e.patientid_chr
                          left join t_bse_deptdesc f
                            on a.diagdept_chr = f.deptid_chr
                          left join t_bse_employee g
                            on a.diagdr_chr = g.empid_chr
                         where d.isoutside = 1
                           and (b.recorddate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dtResult == null) dtResult = dt.Clone();
                    dtResult.Merge(dt);
                }
                #endregion

                #region 住院

                #region bak
                Sql = @"select 2 as flagId,
                               tg.recipeDate,
                               r.lastname_vchr as patName,
                               '' as invoiceno_vchr,
                               tg.orderdicid_chr,
                               tg.orderName,
                               nvl(abs(tg.orderTotal),0) as orderPrice,
                               nvl(tg.orderQty,0) as orderQty,
                               nvl(tg.orderTotal,0) as orderTotal,
                               tg.outsideunit,
                               '' as cardNo,
                               p.inpatientid_chr as ipNo,
                               p.patientid_chr as pid, 
                               tg.deptName,
                               tg.doctName
                          from (select b.chargeactive_dat as recipeDate,
                                       a.registerid_chr,
                                       a.orderid_chr,
                                       a.orderdicid_chr,
                                       a.name_vchr as orderName,
                                       1 as orderQty,
                                       sum(round(b.unitprice_dec * b.amount_dec, 2)) as orderTotal,
                                       c.outsideunit,
                                       f.deptname_vchr as deptName,
                                       b.chargedoctor_vchr as doctName
                                  from t_opr_bih_order a
                                 inner join t_opr_bih_patientcharge b
                                    on a.orderid_chr = b.orderid_chr
                                 inner join t_bse_bih_orderdic c
                                    on a.orderdicid_chr = c.orderdicid_chr
                                  left join t_bse_deptdesc f
                                    on b.createarea_chr = f.deptid_chr
                                 where b.status_int = 1
                                   and b.pstatus_int <> 0
                                   and c.isoutside = 1
                                   and (b.chargeactive_dat between
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                                       to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                 group by b.chargeactive_dat,
                                          a.registerid_chr,
                                          a.orderid_chr,
                                          a.orderdicid_chr,
                                          a.name_vchr,
                                          c.outsideunit,
                                          f.deptname_vchr,
                                          b.chargedoctor_vchr) tg
                         inner join t_opr_bih_registerdetail r
                            on tg.registerid_chr = r.registerid_chr
                         inner join t_opr_bih_register p
                            on r.registerid_chr = p.registerid_chr";
                #endregion

                Sql = @"select distinct 2 as flagId,
                               a.chargeactive_dat as recipeDate,
                               d.lastname_vchr as patName,
                               '' as invoiceno_vchr,
                               c.chargeitemid_chr as orderdicid_chr,
                               c.chargeitemname_chr as orderName,
                               nvl(c.unitprice_dec, 0) as orderPrice,
                               nvl(c.amount_dec, 0) as orderQty,
                               nvl(round(c.unitprice_dec * c.amount_dec, 2), 0) as orderTotal,
                               e.outsideunit,
                               '' as cardNo,
                               f.inpatientid_chr as ipNo,
                               f.patientid_chr as pid,
                               g.deptname_vchr as deptName,
                               a.chargedoctor_vchr as doctName
                          from t_opr_bih_patientcharge a
                         inner join t_opr_bih_orderexecute b
                            on a.orderexecid_chr = b.orderexecid_chr
                         inner join t_opr_bih_order o
                            on a.orderid_chr = o.orderid_chr
                         inner join t_bse_bih_orderdic e
                            on o.orderdicid_chr = e.orderdicid_chr
                         inner join t_opr_bih_orderchargedept c
                            on b.orderid_chr = c.orderid_chr
                           and e.itemid_chr = c.chargeitemid_chr
                         inner join t_opr_bih_registerdetail d
                            on a.registerid_chr = d.registerid_chr
                         inner join t_opr_bih_register f
                            on a.registerid_chr = f.registerid_chr
                          left join t_bse_deptdesc g
                            on a.createarea_chr = g.deptid_chr
                         where a.status_int = 1
                           and a.pstatus_int <> 0
                           and e.isoutside = 1
                           and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and
                               to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = beginDate + " 00:00:00";
                parm[1].Value = endDate + " 23:59:59";
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dtResult == null) dtResult = dt.Clone();
                    dtResult.Merge(dt);
                }
                #endregion

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtResult;
        }
        #endregion

    }
}
