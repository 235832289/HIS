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
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)] 
    [ObjectPooling(true)]
    public class clsCharge : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCharge()
        {
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parmcode"></param>
        /// <returns></returns>
        [AutoComplete]
        public int m_intGetSysParm(string setid)
        {
            int val = -999;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = setid;

                string SQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                DataTable dt = new DataTable();

                long l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    val = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return val;
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parmcodearr">参数代码</param>
        /// <returns>值</returns>
        [AutoComplete]
        public Hashtable m_hasGetSysParm(ArrayList parmcodearr)
        {
            Hashtable hasValues = new Hashtable();
            try
            {
                string strValue = "";

                for (int i = 0; i < parmcodearr.Count; i++)
                {
                    strValue += "'" + parmcodearr[i].ToString().Trim() + "',";
                }
                strValue = strValue.Substring(0, strValue.Length - 1);

                string SQL = @"select parmcode_chr, parmvalue_vchr
                                 from t_bse_sysparm 
                                where status_int = 1 
                                  and parmcode_chr in (" + strValue + ")";

                DataTable dt = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long l = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hasValues.Add(dt.Rows[i]["parmcode_chr"].ToString(), dt.Rows[i]["parmvalue_vchr"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return hasValues;
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="setidarr">参数代码</param>
        /// <returns>值</returns>
        [AutoComplete]
        public Hashtable m_hasGetSysSetting(ArrayList setidarr)
        {
            Hashtable hasValues = new Hashtable();
            try
            {
                string strValue = "";

                for (int i = 0; i < setidarr.Count; i++)
                {
                    strValue += "'" + setidarr[i].ToString().Trim() + "',";
                }
                strValue = strValue.Substring(0, strValue.Length - 1);

                string SQL = @"select setid_chr, setstatus_int 
                                 from t_sys_setting 
                                where setid_chr in (" + strValue + ")";

                DataTable dt = new DataTable();
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                long l = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hasValues.Add(dt.Rows[i]["setid_chr"].ToString(), dt.Rows[i]["setstatus_int"].ToString());
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return hasValues;
        }
        #endregion

        #region 根据分类范围获取费用分类(门诊核算、发票；住院核算、发票)定义信息
        /// <summary>
        /// 根据分类范围获取费用分类(门诊核算、发票；住院核算、发票)定义信息
        /// </summary>
        /// <param name="Scope">范围: 1 门诊核算 2 门诊发票 3 住院核算 4 住院发票</param>
        /// <param name="Status">% 全部 0 停用 1 启用</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDefChargeCat(string Scope, string Status, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @" select scope_chr, catid_chr, catname_vchr, type_int, compexp_vchr,
                                   dispctl_vchr, prtclt_vchr, status_int 
                              from t_bse_defchargecat
                             where status_int like ? 
                               and scope_chr = ? 
                          order by catid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Status;
                ParamArr[1].Value = Scope;

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

        #region 获取员工代码表
        /// <summary>
        /// 获取员工代码表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmployee(out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.empid_chr, a.empno_chr, a.lastname_vchr, a.status_int from t_bse_employee a order by a.empno_chr";

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
        /// 根据员工工号获取ID和姓名
        /// </summary>
        /// <param name="EmpNo"></param>
        /// <param name="EmpID"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public long m_lngGetEmployee(string EmpNo, out string EmpID, out string EmpName)
        {
            long lngRes = 0;
            DataTable dt = new DataTable();

            string SQL = @"select a.empid_chr, a.lastname_vchr
                             from t_bse_employee a 
                            where a.empno_chr = ?";

            EmpID = "";
            EmpName = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = EmpNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    EmpID = dt.Rows[0]["empid_chr"].ToString();
                    EmpName = dt.Rows[0]["lastname_vchr"].ToString();
                }

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

        #region 根据住院登记流水号查找病人所有期帐信息
        /// <summary>
        /// 根据住院登记流水号查找病人所有期帐信息
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientDayaccountsByRegID(string RegID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @" select dayaccountid_chr, patientid_chr, registerid_chr, orderno_int,
                                   square_dat, charge_dec, clearchg_dec, chgofmepay_dec, clearchgofme_dec,
                                   chgofhepay_dec, clearchgofhe_dec, clearmpoptid_chr, chearmp_dat,
                                   clearhpoptid_chr, clearhp_dat, areaid_chr, create_dat, note_vchr,
                                   currareaid_chr, operid_chr, type_int
                              from t_opr_bih_dayaccount where registerid_chr = ? order by orderno_int";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

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

        #region 获取该期帐有效费用信息
        /// <summary>
        /// 获取该期帐有效费用信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="type">1 根据入院登记ID 2 根据期帐ID </param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeInfoByID(string ID, int type, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (type == 1)
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr, b.itemcode_vchr, b.itemopcode_chr, 
                                   b.itemname_vchr, c.orderno_int,
                                   (case a.pstatus_int
                                       when 3
                                          then a.discount_dec
                                       when 4
                                          then a.discount_dec
                                       else e.precent_dec
                                    end
                                   ) as precent_dec,
                                   f.typename_vchr as ipinvoname, b.insuranceid_chr as ybcode,
                                   g.chargetotalsum,a.itemchargetype_vchr,a.totaldiffcostmoney_dec,
                                   DECODE (b.ipchargeflg_int,
                                     1, round (b.tradeprice_mny / b.packqty_dec, 4),
                                     0, b.tradeprice_mny,
                                 round (b.tradeprice_mny / b.packqty_dec, 4)
                                ) tradeprice_mny
                              from t_opr_bih_patientcharge a,
                                   t_bse_chargeitem b,
                                   t_opr_bih_dayaccount c,
                                   t_opr_bih_register d,
                                   t_aid_inschargeitem e,
                                   t_bse_chargeitemextype f,
                                   (select   a.pchargeid_chr, sum (a.totalmoney_dec) as chargetotalsum
                                        from t_opr_bih_chargeitementry a, 
                                             t_opr_bih_register b,
                                             t_opr_bih_charge c 
                                       where a.registerid_chr = b.registerid_chr
                                         and a.chargeno_chr = c.chargeno_chr
                                         and b.status_int = 1
                                         and b.feestatus_int = 4
                                         and c.class_int = 3
                                         and a.registerid_chr = ?
                                    group by a.pchargeid_chr) g
                             where a.chargeitemid_chr = b.itemid_chr
                               and a.dayaccountid_chr = c.dayaccountid_chr(+)
                               and a.registerid_chr = d.registerid_chr
                               and a.chargeitemid_chr = e.itemid_chr
                               and b.itemipinvtype_chr = f.typeid_chr
                               and d.paytypeid_chr = e.copayid_chr
                               and a.pchargeid_chr = g.pchargeid_chr(+)
                               and a.pstatus_int <> 0
                               and a.status_int = 1
                               and f.flag_int = 4
                               and a.chargeactive_dat is not null
                               and a.registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ID;
                    ParamArr[1].Value = ID;
                }
                else if (type == 2)
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr, b.itemcode_vchr, b.itemname_vchr, itemopcode_chr, c.orderno_int,
                                  (case a.pstatus_int
                                     when 3
                                        then a.discount_dec
                                     when 4
                                        then a.discount_dec
                                     else e.precent_dec
                                  end
                                  ) as precent_dec,
                                  f.typename_vchr as ipinvoname, b.insuranceid_chr as ybcode ,a.itemchargetype_vchr,a.totaldiffcostmoney_dec,
                                  DECODE (b.ipchargeflg_int,
                                     1, round (b.tradeprice_mny / b.packqty_dec, 4),
                                     0, b.tradeprice_mny,
                                 round (b.tradeprice_mny / b.packqty_dec, 4)
                                ) tradeprice_mny
                             from t_opr_bih_patientcharge a,
                                  t_bse_chargeitem b,
                                  t_opr_bih_dayaccount c, 
                                  t_opr_bih_register d,
                                  t_aid_inschargeitem e, 
                                  t_bse_chargeitemextype f                                            
                            where a.chargeitemid_chr = b.itemid_chr 
                              and a.dayaccountid_chr = c.dayaccountid_chr(+) 
                              and a.registerid_chr = d.registerid_chr 
                              and a.chargeitemid_chr = e.itemid_chr 
                              and b.itemipinvtype_chr = f.typeid_chr
                              and d.paytypeid_chr = e.copayid_chr                                                
                              and a.pstatus_int <> 0 
                              and a.status_int = 1 
                              and f.flag_int = 4 
                              and a.chargeactive_dat is not null 
                              and a.dayaccountid_chr = ?                              
                         order by a.chargeactive_dat, a.orderid_chr, a.chargeitemid_chr";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ID;
                }

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

        #region 母婴合并结算费用一起查询ucpatien控件使用 by yibin.zheng 09-07-03

        /// <summary>
        /// 母婴合并结算费用一起查询ucpatien控件使用
        /// </summary>
        /// <param name="p_strRegisterID">病人registerId</param>

        /// <param name="p_dtbCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeInfoByIDForBaby(string p_strRegisterID, out DataTable p_dtbCharge)
        {
            long lngRes = 0;
            string SQL = "";
            p_dtbCharge = new DataTable();
            clsHRPTableService objHRPSvc = null; ;
            IDataParameter[] ParamArr = null;
            try
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr, b.itemcode_vchr, b.itemopcode_chr, 
                                   b.itemname_vchr, c.orderno_int,
                                   (case a.pstatus_int
                                       when 3
                                          then a.discount_dec
                                       when 4
                                          then a.discount_dec
                                       else e.precent_dec
                                    end
                                   ) as precent_dec,
                                   f.typename_vchr as ipinvoname, b.insuranceid_chr as ybcode,
                                   g.chargetotalsum,a.itemchargetype_vchr,
                                   DECODE (b.ipchargeflg_int,
                                     1, round (b.tradeprice_mny / b.packqty_dec, 4),
                                     0, b.tradeprice_mny,
                                 round (b.tradeprice_mny / b.packqty_dec, 4)
                                ) tradeprice_mny,a.totaldiffcostmoney_dec
                              from t_opr_bih_patientcharge a,
                                   t_bse_chargeitem b,
                                   t_opr_bih_dayaccount c,
                                   t_opr_bih_register d,
                                   t_aid_inschargeitem e,
                                   t_bse_chargeitemextype f,
                                   (select   a.pchargeid_chr, sum (a.totalmoney_dec) as chargetotalsum
                                        from t_opr_bih_chargeitementry a, 
                                             t_opr_bih_register b,
                                             t_opr_bih_charge c 
                                       where a.registerid_chr = b.registerid_chr
                                         and a.chargeno_chr = c.chargeno_chr
                                         and b.status_int = 1
                                         and b.feestatus_int = 4
                                         and c.class_int = 3
                                         and a.registerid_chr = ?
                                    group by a.pchargeid_chr) g
                             where a.chargeitemid_chr = b.itemid_chr
                               and a.dayaccountid_chr = c.dayaccountid_chr(+)
                               and a.registerid_chr = d.registerid_chr
                               and a.chargeitemid_chr = e.itemid_chr
                               and b.itemipinvtype_chr = f.typeid_chr
                               and d.paytypeid_chr = e.copayid_chr
                               and a.pchargeid_chr = g.pchargeid_chr(+)
                               and a.pstatus_int in (1,2,3,4)
                               and a.status_int = 1
                               and f.flag_int = 4
                               and a.chargeactive_dat is not null
                               and a.registerid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = p_strRegisterID;
                ParamArr[1].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref p_dtbCharge, ParamArr);
                //判断病人是否有婴儿带出费用，有的话就合并未结算
                SQL = @"select t.registerid_chr
  from t_opr_bih_register t
 where t.pstatus_int in (2,3)
 and t.relateregisterid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strRegisterID;
                DataTable dtbBabyId = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbBabyId, ParamArr);
                if (lngRes > 0 && dtbBabyId.Rows.Count > 0)
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr, b.itemcode_vchr, b.itemopcode_chr, 
                                   b.itemname_vchr, c.orderno_int,
                                   (case a.pstatus_int
                                       when 3
                                          then a.discount_dec
                                       when 4
                                          then a.discount_dec
                                       else e.precent_dec
                                    end
                                   ) as precent_dec,
                                   f.typename_vchr as ipinvoname, b.insuranceid_chr as ybcode,
                                   g.chargetotalsum,a.itemchargetype_vchr,
                                   DECODE (b.ipchargeflg_int,
                                     1, round (b.tradeprice_mny / b.packqty_dec, 4),
                                     0, b.tradeprice_mny,
                                 round (b.tradeprice_mny / b.packqty_dec, 4)
                                ) tradeprice_mny,a.totaldiffcostmoney_dec
                              from t_opr_bih_patientcharge a,
                                   t_bse_chargeitem b,
                                   t_opr_bih_dayaccount c,
                                   t_opr_bih_register d,
                                   t_aid_inschargeitem e,
                                   t_bse_chargeitemextype f,
                                   (select   a.pchargeid_chr, sum (a.totalmoney_dec) as chargetotalsum
                                        from t_opr_bih_chargeitementry a, 
                                             t_opr_bih_register b,
                                             t_opr_bih_charge c 
                                       where a.registerid_chr = b.registerid_chr
                                         and a.chargeno_chr = c.chargeno_chr
                                         and b.status_int = 1
                                         and b.feestatus_int = 4
                                         and c.class_int = 3
                                         and b.relateregisterid_chr = ?
                                    group by a.pchargeid_chr) g
                             where a.chargeitemid_chr = b.itemid_chr
                               and a.dayaccountid_chr = c.dayaccountid_chr(+)
                               and a.registerid_chr = d.registerid_chr
                               and a.chargeitemid_chr = e.itemid_chr
                               and b.itemipinvtype_chr = f.typeid_chr
                               and d.paytypeid_chr = e.copayid_chr
                               and a.pchargeid_chr = g.pchargeid_chr(+)
                               and a.pstatus_int in (1,2,3,4)
                               and a.status_int = 1
                               and f.flag_int = 4
                               and a.chargeactive_dat is not null
                               and d.relateregisterid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_strRegisterID;
                    ParamArr[1].Value = p_strRegisterID;
                    DataTable dtbTemp = new DataTable();
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbTemp, ParamArr);
                    if (lngRes > 0 && dtbTemp.Rows.Count > 0)
                    {
                        p_dtbCharge.Merge(dtbTemp);
                    }

                    dtbTemp.Dispose();
                    dtbTemp = null;
                }
                dtbBabyId.Dispose();
                dtbBabyId = null;





            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
                SQL = null;


            }

            return lngRes;
        }
        #endregion


        #region 调出婴儿未结费用 by yibin.zheng 09-07-03
        /// <summary>
        /// 调出婴儿未结费用
        /// </summary>
        /// <param name="p_strRegisterId">婴儿ID</param>
        /// <param name="p_dtbResult">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckBabyNoPayCharge(string p_strRegisterId, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            string strSQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr, b.itemcode_vchr, b.itemopcode_chr, 
                                   b.itemname_vchr, c.orderno_int,
                                   (case a.pstatus_int
                                       when 3
                                          then a.discount_dec
                                       when 4
                                          then a.discount_dec
                                       else e.precent_dec
                                    end
                                   ) as precent_dec,
                                   f.typename_vchr as ipinvoname, b.insuranceid_chr as ybcode,
                                   g.chargetotalsum,a.itemchargetype_vchr,a.totaldiffcostmoney_dec,
                                   DECODE (b.ipchargeflg_int,
                                     1, round (b.tradeprice_mny / b.packqty_dec, 4),
                                     0, b.tradeprice_mny,
                                 round (b.tradeprice_mny / b.packqty_dec, 4)
                                ) tradeprice_mny
                              from t_opr_bih_patientcharge a,
                                   t_bse_chargeitem b,
                                   t_opr_bih_dayaccount c,
                                   t_opr_bih_register d,
                                   t_aid_inschargeitem e,
                                   t_bse_chargeitemextype f,
                                   (select   a.pchargeid_chr, sum (a.totalmoney_dec) as chargetotalsum
                                        from t_opr_bih_chargeitementry a, 
                                             t_opr_bih_register b,
                                             t_opr_bih_charge c 
                                       where a.registerid_chr = b.registerid_chr
                                         and a.chargeno_chr = c.chargeno_chr
                                         and b.status_int = 1
                                         and b.feestatus_int = 4
                                         and c.class_int = 3
                                         and a.registerid_chr in ([registerId1])
                                    group by a.pchargeid_chr) g
                             where a.chargeitemid_chr = b.itemid_chr
                               and a.dayaccountid_chr = c.dayaccountid_chr(+)
                               and a.registerid_chr = d.registerid_chr
                               and a.chargeitemid_chr = e.itemid_chr
                               and b.itemipinvtype_chr = f.typeid_chr
                               and d.paytypeid_chr = e.copayid_chr
                               and a.pchargeid_chr = g.pchargeid_chr(+)
                               and a.pstatus_int in(1,2,3)
                               and a.status_int = 1
                               and f.flag_int = 4
                               and a.chargeactive_dat is not null
                               and a.registerid_chr in([registerId2])";
            p_dtbResult = null;
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                strSQL = strSQL.Replace("[registerId1]", p_strRegisterId);
                strSQL = strSQL.Replace("[registerId2]", p_strRegisterId);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
                strSQL = null;

            }
            return lngRes;

        }
        #endregion

        #region 获取母亲的婴儿registerID
        /// <summary>
        /// 获取母亲的婴儿registerID
        /// </summary>
        /// <param name="p_strRegisterId">母亲RegisterID</param>
        /// <param name="p_dtbBabyInfo">婴儿信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBabyRegisterId(string p_strRegisterId, out DataTable p_dtbBabyInfo)
        {
            long lngRes = 0;
            string strSQL = @"select t.registerid_chr,
       t.patientid_chr,
       t.areaid_chr,
       t.inpatientnotype_int,
       t.paytypeid_chr
  from t_opr_bih_register t
 where t.pstatus_int in (2,3) 
 and t.relateregisterid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;
            p_dtbBabyInfo = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strRegisterId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbBabyInfo, ParamArr);


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
                strSQL = null;

            }
            return lngRes;
        }
        #endregion

        #region 获取项目分类信息(核算分类、发票分类)
        /// <summary>
        /// 获取项目分类信息(核算分类、发票分类)
        /// </summary>
        /// <param name="flag">分类类型：1 门诊核算 2 门诊发票 3 住院核算 4 住院发票 5 病案核算</param>
        /// <param name="dt">
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemCat(int flag, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @" select typeid_chr, typename_vchr, flag_int, usercode_chr, sortcode_int,
                                   govtopcharge_mny, emrcat_vchr 
                              from t_bse_chargeitemextype
                             where flag_int = ? 
                          order by sortcode_int";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = flag;

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

        #region 根据住院登记流水号检查项目状态
        /// <summary>
        /// 根据住院登记流水号检查项目状态
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="status">0 待确认 1 待结 2 待清 3 已清 4 直收</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckChargeItemStatus(string RegID, int status)
        {
            long lngRes = 0;
            bool IsExist = false;

            string SQL = @"select count(registerid_chr) from t_opr_bih_patientcharge where registerid_chr = ? and status_int = 1 and pstatus_int = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RegID;
                ParamArr[1].Value = status;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);

                if (lngRes > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                    {
                        IsExist = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return IsExist;
        }
        #endregion

        #region 根据住院登记流水号生成各状态项目总费用
        /// <summary>
        /// 根据住院登记流水号生成各状态项目总费用
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="status">0 待确认 1 待结 2 待清 3 已清 4 直收 9 生成期帐</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemFee(string RegID, int status, out DataTable dt)
        {
            long lngRes = 0;

            string SubWhere = "";

            if (status == 9)
            {
                SubWhere = @"and a.pstatus_int <> 0 
                             and a.dayaccountid_chr is null";
            }
            else
            {
                SubWhere = "and a.pstatus_int = ?";
            }

            string SQL = @"select  a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
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
                                   (case a.pstatus_int
                                     when 3
                                        then a.discount_dec
                                     when 4
                                        then a.discount_dec
                                     else c.precent_dec
                                  end
                                  ) as precent_dec  
                             from t_opr_bih_patientcharge a,
                                  t_opr_bih_register b,
                                  t_aid_inschargeitem c
                            where a.registerid_chr = ?                                     
                              and a.registerid_chr = b.registerid_chr 
                              and a.chargeitemid_chr = c.itemid_chr 
                              and b.paytypeid_chr = c.copayid_chr 
                              and a.status_int = 1 ";

            SQL += SubWhere;

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (status == 9)
                {
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = RegID;
                    ParamArr[1].Value = status;
                }

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

        #region 根据住院登记流水号获取各生效类型(费用状态)费用信息
        /// <summary>
        /// 根据住院登记流水号获取各生效类型(费用状态)费用信息
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="ActiveType">生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费;888=费用状态分类;999=全部}</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeeItemByActiveType(string RegID, int ActiveType, string Pstatus, string AreaID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
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
                                   a.chargedoctor_vchr, a.chargedoctorgroupid_chr, a.pchargeidorg_chr, 
                                   d.deptname_vchr as execarea, e.itemcode_vchr, e.itemspec_vchr, e.insuranceid_chr as ybcode, 
                                   (case a.pstatus_int
                                      when 3
                                         then a.discount_dec
                                      when 4
                                         then a.discount_dec
                                      else c.precent_dec
                                    end
                                   ) as precent_dec, (a.amount_dec * a.unitprice_dec) as totalmony,
                                  f.recipeno2_int as recno, e.itemopcode_chr, e.itempycode_chr, 0 as chargetotalsum,a.itemchargetype_vchr,a.totaldiffcostmoney_dec      
                             from t_opr_bih_patientcharge a,
                                  t_opr_bih_register b,
                                  t_aid_inschargeitem c,
                                  t_bse_deptdesc d,                                           
                                  t_bse_chargeitem e,
                                  t_opr_bih_order f                                      
                            where a.registerid_chr = ?                                     
                              and a.registerid_chr = b.registerid_chr 
                              and a.chargeitemid_chr = c.itemid_chr 
                              and b.paytypeid_chr = c.copayid_chr 
                              and a.clacarea_chr = d.deptid_chr(+)
                              and a.chargeitemid_chr = e.itemid_chr(+) 
                              and a.orderid_chr = f.orderid_chr(+)   
                              and a.status_int = 1 ";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (ActiveType == 888)
                {
                    SQL += "and a.pstatus_int = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = RegID;
                    ParamArr[1].Value = Pstatus;
                }
                else if (ActiveType == 999)
                {
                    if (AreaID == "00")
                    {
                        SQL += " and a.pstatus_int <> 0 and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = RegID;
                        ParamArr[1].Value = BeginDate + " 00:00:00";
                        ParamArr[2].Value = EndDate + " 23:59:59";
                    }
                    else
                    {
                        SQL += " and a.pstatus_int <> 0 and a.curareaid_chr = ? and (a.chargeactive_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                        objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                        ParamArr[0].Value = RegID;
                        ParamArr[1].Value = AreaID;
                        ParamArr[2].Value = BeginDate + " 00:00:00";
                        ParamArr[3].Value = EndDate + " 23:59:59";
                    }
                }
                else
                {
                    SQL += "and a.activatetype_int = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = RegID;
                    ParamArr[1].Value = ActiveType;
                }

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

        #region 生成期帐
        /// <summary>
        /// 生成期帐
        /// </summary>
        /// <param name="DayAccounts_VO">期帐VO</param>      
        /// <param name="EmpID">收费员ID</param>     
        /// <param name="ChargeType">0 普通结帐 1 出院结帐 2 出院结算</param>     
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBuildDayAccounts(clsBihDayAccounts_VO DayAccounts_VO, string EmpID, int ChargeType)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";
            string NewOrderNO = "";
            string DayAccountsID = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                //取期帐序列ID
                SQL = "select lpad(seq_dayaccountid.NEXTVAL, 18, '0') from dual";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0)
                {
                    DayAccountsID = dt.Rows[0][0].ToString();
                }

                //取期号
                SQL = @"select nvl(max(orderno_int),0) + 1
                          from t_opr_bih_dayaccount
                         where registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = DayAccounts_VO.RegisterID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0)
                {
                    NewOrderNO = dt.Rows[0][0].ToString();
                }

                if (ChargeType == 2)
                {
                    //生成期帐
                    SQL = @"insert into t_opr_bih_dayaccount (dayaccountid_chr, patientid_chr, registerid_chr, orderno_int, square_dat, charge_dec, clearchg_dec, chgofmepay_dec, clearchgofme_dec, chgofhepay_dec, 
                                                          clearchgofhe_dec, clearmpoptid_chr, chearmp_dat, clearhpoptid_chr, clearhp_dat, areaid_chr, note_vchr, currareaid_chr, operid_chr, type_int) values ( 
                                                          ?, ?, ?, ?, sysdate, ?, ?, ?, ?, ?, ?, null, null, null, null, 'outhosp', ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(14, out ParamArr);
                    ParamArr[0].Value = DayAccountsID;
                    ParamArr[1].Value = DayAccounts_VO.PatientID;
                    ParamArr[2].Value = DayAccounts_VO.RegisterID;
                    ParamArr[3].Value = NewOrderNO;
                    ParamArr[4].Value = DayAccounts_VO.TotalSum;
                    ParamArr[5].Value = DayAccounts_VO.TotalSum;
                    ParamArr[6].Value = DayAccounts_VO.SbSum;
                    ParamArr[7].Value = DayAccounts_VO.SbSum;
                    ParamArr[8].Value = DayAccounts_VO.AcctSum;
                    ParamArr[9].Value = DayAccounts_VO.AcctSum;
                    ParamArr[10].Value = DayAccounts_VO.Note;
                    ParamArr[11].Value = DayAccounts_VO.CurrAreaID;
                    ParamArr[12].Value = DayAccounts_VO.OperID;
                    ParamArr[13].Value = DayAccounts_VO.Type;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else
                {
                    //生成期帐
                    SQL = @"insert into t_opr_bih_dayaccount (dayaccountid_chr, patientid_chr, registerid_chr, orderno_int, square_dat, charge_dec, clearchg_dec, chgofmepay_dec, clearchgofme_dec, chgofhepay_dec, 
                                                          clearchgofhe_dec, clearmpoptid_chr, chearmp_dat, clearhpoptid_chr, clearhp_dat, areaid_chr, note_vchr, currareaid_chr, operid_chr, type_int) values ( 
                                                          ?, ?, ?, ?, sysdate, ?, ?, ?, ?, ?, ?, null, null, null, null, 'inhosp', ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(14, out ParamArr);
                    ParamArr[0].Value = DayAccountsID;
                    ParamArr[1].Value = DayAccounts_VO.PatientID;
                    ParamArr[2].Value = DayAccounts_VO.RegisterID;
                    ParamArr[3].Value = NewOrderNO;
                    ParamArr[4].Value = DayAccounts_VO.TotalSum;
                    ParamArr[5].Value = 0;
                    ParamArr[6].Value = DayAccounts_VO.SbSum;
                    ParamArr[7].Value = 0;
                    ParamArr[8].Value = DayAccounts_VO.AcctSum;
                    ParamArr[9].Value = 0;
                    ParamArr[10].Value = DayAccounts_VO.Note;
                    ParamArr[11].Value = DayAccounts_VO.CurrAreaID;
                    ParamArr[12].Value = DayAccounts_VO.OperID;
                    ParamArr[13].Value = DayAccounts_VO.Type;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //将所有待结状态的收费信息改成待清状态
                    SQL = @"update t_opr_bih_patientcharge 
                                                set pstatus_int = 2 
                                              where status_int = 1 
                                                and pstatus_int = 1 
                                                and registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = DayAccounts_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    if (ChargeType == 1)
                    {
                        //更新病人费用状态 FEESTATUS_INT = 5 : 出院结帐
                        SQL = @"update t_opr_bih_register 
                                    set feestatus_int = 5 
                                  where registerid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = DayAccounts_VO.RegisterID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }

                //收费信息赋期帐ID
                SQL = @"update t_opr_bih_patientcharge 
                            set dayaccountid_chr = ?,  
                                operator_chr = ?, 
                                modify_dat = sysdate  
                          where status_int = 1 
                            and pstatus_int <> 0 
                            and registerid_chr = ?                           
                            and dayaccountid_chr is null";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = DayAccountsID;
                ParamArr[1].Value = EmpID;
                ParamArr[2].Value = DayAccounts_VO.RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 出院结帐则立即腾出床位
        /// <summary>
        /// 出院结帐则立即腾出床位
        /// </summary>
        /// <param name="RegID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngClearBed(string RegID)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //床位表
                SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 检查发票号是否重复
        /// <summary>
        /// 检查发票号是否重复
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckInvoiceNo(string CurrNo)
        {
            long lngRes = 0;
            bool IsExist = false;

            string SQL = @"select invoiceno_vchr as nos 
                             from t_opr_bih_invoice2 
                            where invoiceno_vchr = ? 

                           union all 

                           select repprnbillno_vchr as nos
                             from t_opr_bih_billrepeatprint
                               where billtype_chr = '2' 
                                 and repprnbillno_vchr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = CurrNo;
                ParamArr[1].Value = CurrNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    IsExist = true;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return IsExist;
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="DayChrgType">期帐结算类型：1 期帐 2 明细</param>
        /// <param name="DayAccountsArr"></param>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeCatArr"></param>
        /// <param name="Invoice_VO"></param>
        /// <param name="InvoCatArr"></param>
        /// <param name="PaymentArr"></param>
        /// <param name="PrePayDeal">预交金处理： 0 不处理 1 退回 2 转下期</param>   
        /// <param name="PrePayIDArr"></param>
        /// <param name="ChargeType">结算类型：1 中途结算 2 出院结算 3 呆帐结算 4 直收 5 确认收费 6 呆帐补交款结算</param>
        /// <param name="Confirm_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReckoning(DataTable dtSource, int DayChrgType, ArrayList DayAccountsArr, clsBihCharge_VO Charge_VO, ArrayList ChargeCatArr, clsBihInvoice_VO Invoice_VO, ArrayList InvoCatArr, ArrayList PaymentArr, int PrePayDeal, ArrayList PrePayIDArr, int ChargeType, clsBihConfirm_VO Confirm_VO, out string ChargeNo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";
            //根据时间生成结算号
            ChargeNo = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //入院登记号
                string RegID = Charge_VO.RegisterID;

                //发票号(现有业务默认一次结算对应一张发票)
                string Invono = Invoice_VO.InvoiceNo;

                //结算表
                SQL = @"insert into t_opr_bih_charge(chargeno_chr, registerid_chr, paytypeid_chr, patienttype_chr, totalsum_mny, sbsum_mny, acctsum_mny, operemp_chr, 
                                                     operdate_dat, recflag_int, recemp_chr, recdate_dat, class_int, type_int, status_int, billno_int, areaid_chr) values (  
                                                     ?, ?, ?, ?, ?, ?, ?, ?, sysdate, 0, null, null, ?, 1, 1, ?, ?)";

                objHRPSvc.CreateDatabaseParameter(11, out ParamArr);
                ParamArr[0].Value = ChargeNo;
                ParamArr[1].Value = Charge_VO.RegisterID;
                ParamArr[2].Value = Charge_VO.PayTypeID;
                ParamArr[3].Value = Charge_VO.PatientType;
                ParamArr[4].Value = Charge_VO.TotalSum;
                ParamArr[5].Value = Charge_VO.SbSum;
                ParamArr[6].Value = Charge_VO.AcctSum;
                ParamArr[7].Value = Charge_VO.OperEmp;
                ParamArr[8].Value = ChargeType;
                ParamArr[9].Value = Charge_VO.BillNO;
                ParamArr[10].Value = Charge_VO.CurrAreaID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //结算分类表
                for (int i = 0; i < ChargeCatArr.Count; i++)
                {
                    clsBihChargeCat_VO ChargeCat_VO = ChargeCatArr[i] as clsBihChargeCat_VO;

                    if (ChargeCat_VO.TotalSum == 0)
                    {
                        continue;
                    }

                    SQL = @"insert into t_opr_bih_chargecat(chargeno_chr, deptid_chr, itemcatid_chr, totalsum_mny, acctsum_mny) values(  
                                                            ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = ChargeCat_VO.DeptID;
                    ParamArr[2].Value = ChargeCat_VO.ItemCatID;
                    ParamArr[3].Value = ChargeCat_VO.TotalSum;
                    ParamArr[4].Value = ChargeCat_VO.AcctSum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                //结算发票对应表
                SQL = "insert into t_opr_bih_chargedefinv(chargeno_chr, invoiceno_vchr) values(?, ?)";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = ChargeNo;
                ParamArr[1].Value = Invono;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //发票表
                SQL = @"insert into t_opr_bih_invoice2(invoiceno_vchr, invdate_dat, totalsum_mny, sbsum_mny, acctsum_mny, status_int, confirmemp_chr, confirmdate_dat, split_int) values(  
                                                       ?, sysdate, ?, ?, ?, ?, null, null, ?)";

                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = Invoice_VO.InvoiceNo;
                ParamArr[1].Value = Invoice_VO.TotalSum;
                ParamArr[2].Value = Invoice_VO.SbSum;
                ParamArr[3].Value = Invoice_VO.AcctSum;
                ParamArr[4].Value = Invoice_VO.Status;
                ParamArr[5].Value = Invoice_VO.Split;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //发票明细表
                for (int i = 0; i < InvoCatArr.Count; i++)
                {
                    clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i] as clsBihInvoiceCat_VO;

                    if (InvoiceCat_VO.TotalSum == 0)
                    {
                        continue;
                    }

                    SQL = "insert into t_opr_bih_invoice2de(invoiceno_vchr, itemcatid_chr, totalsum_mny, acctsum_mny) values(?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ParamArr[0].Value = Invono;
                    ParamArr[1].Value = InvoiceCat_VO.ItemCatID;
                    ParamArr[2].Value = InvoiceCat_VO.TotalSum;
                    ParamArr[3].Value = InvoiceCat_VO.AcctSum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                //支付表
                for (int i = 0; i < PaymentArr.Count; i++)
                {
                    clsBihPayment_VO Payment_VO = PaymentArr[i] as clsBihPayment_VO;

                    SQL = @"insert into t_opr_bih_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny) values(  
                                                          ?, ?, null, null, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = Payment_VO.PayType;
                    ParamArr[2].Value = Payment_VO.PaySum;
                    ParamArr[3].Value = Payment_VO.RefuSum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                //费用明细序列ID(组串)
                string StrChargeID = "";

                //凑整费
                decimal RoundingVal = 0;

                //费用明细序列ID
                string rpid = "";

                //更新费用明细记录(将pchargeid_chr 交费记录id 暂时定为结算号)
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    #region 凑整
                    string RoundingFlag = dtSource.Rows[i]["des_vchr"].ToString().Trim();
                    if (RoundingFlag.ToLower() == "rounding")
                    {
                        DataTable dt = new DataTable();
                        SQL = "select lpad (seq_pchargeid.nextval, 18, '0') from dual";
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                        if (lngRes > 0)
                        {
                            rpid = dt.Rows[0][0].ToString();
                            dtSource.Rows[i]["pchargeid_chr"] = rpid;
                        }

                        SQL = @"insert into t_opr_bih_patientcharge (patientid_chr, registerid_chr, active_dat, orderid_chr, orderexectype_int, orderexecid_chr,
                                                             clacarea_chr, createarea_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                             unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr, createtype_int, creator_chr, create_dat, operator_chr,
                                                             modify_dat, deactivator_chr, deactivate_dat, status_int, pstatus_int, chearaccount_dat, paymoneyid_chr,
                                                             activator_chr, activatetype_int, isrich_int, isconfirmrefundment, refundmentchecker, refundmentdate, bmstatus_int, curareaid_chr,
                                                             curbedid_chr, doctorid_chr, doctor_vchr, doctorgroupid_chr, needconfirm_int, confirmerid_chr, confirmer_vchr, confirm_dat, 
                                                             chargeactive_dat, TotalMoney_dec, AcctMoney_dec, attachorderid_vchr, attachorderbasenum_dec, spec_vchr, dayaccountid_chr, 
                                                             pchargeid_chr, chargedoctorid_chr, chargedoctor_vchr, chargedoctorgroupid_chr,totaldiffcostmoney_dec) values (                
                                                            ?, ?, null, ?, ?, null, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                                                            ?, ?, sysdate, ?, sysdate, null, null, 1, ?, null, null, null, ?, ?, null, null, null, null, 
                                                            ?, ?, ?, ?, ?, ?, null, null, null, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                        objHRPSvc.CreateDatabaseParameter(40, out ParamArr);

                        DataRow drR = dtSource.Rows[i];
                        ParamArr[0].Value = drR["patientid_chr"].ToString();
                        ParamArr[1].Value = drR["registerid_chr"].ToString();
                        ParamArr[2].Value = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        ParamArr[3].Value = drR["orderexectype_int"].ToString();
                        ParamArr[4].Value = drR["clacarea_chr"].ToString();
                        ParamArr[5].Value = drR["createarea_chr"].ToString();
                        ParamArr[6].Value = drR["calccateid_chr"].ToString();
                        ParamArr[7].Value = drR["invcateid_chr"].ToString();
                        ParamArr[8].Value = drR["chargeitemid_chr"].ToString();
                        ParamArr[9].Value = drR["chargeitemname_chr"].ToString();
                        ParamArr[10].Value = drR["unit_vchr"].ToString();
                        ParamArr[11].Value = drR["unitprice_dec"].ToString();
                        ParamArr[12].Value = drR["amount_dec"].ToString();
                        ParamArr[13].Value = drR["discount_dec"].ToString();
                        ParamArr[14].Value = "0";
                        ParamArr[15].Value = drR["des_vchr"].ToString();
                        ParamArr[16].Value = drR["createtype_int"].ToString();
                        ParamArr[17].Value = drR["creator_chr"].ToString();
                        ParamArr[18].Value = drR["activator_chr"].ToString();
                        ParamArr[19].Value = "3";
                        ParamArr[20].Value = drR["activatetype_int"].ToString();
                        ParamArr[21].Value = "0";
                        ParamArr[22].Value = drR["curareaid_chr"].ToString();
                        ParamArr[23].Value = drR["curbedid_chr"].ToString();
                        ParamArr[24].Value = drR["doctorid_chr"].ToString();
                        ParamArr[25].Value = drR["doctor_vchr"].ToString();
                        ParamArr[26].Value = drR["doctorgroupid_chr"].ToString();
                        ParamArr[27].Value = "0";
                        ParamArr[28].Value = drR["active_dat"].ToString();
                        ParamArr[29].Value = drR["totalmoney_dec"].ToString();
                        ParamArr[30].Value = drR["acctmoney_dec"].ToString();
                        ParamArr[31].Value = "";
                        ParamArr[32].Value = "";
                        ParamArr[33].Value = drR["spec_vchr"].ToString();

                        if (DayAccountsArr != null && DayAccountsArr.Count > 0)
                        {
                            ParamArr[34].Value = ((clsBihDayAccounts_VO)DayAccountsArr[0]).AccountsID;
                        }
                        else
                        {
                            ParamArr[34].Value = "";
                        }
                        ParamArr[35].Value = rpid;

                        ParamArr[36].Value = drR["chargedoctorid_chr"].ToString();
                        ParamArr[37].Value = drR["chargedoctor_vchr"].ToString();
                        ParamArr[38].Value = drR["doctorgroupid_chr"].ToString();
                        ParamArr[39].Value = drR["totaldiffcostmoney_dec"].ToString();//让利金额

                        RoundingVal = decimal.Parse(drR["totalmoney_dec"].ToString());

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        if (ChargeType != 6)
                        {
                            StrChargeID += "a.pchargeid_chr = '" + rpid + "' or ";
                        }
                    }
                    #endregion

                    string id = dtSource.Rows[i]["pchargeid_chr"].ToString();
                    decimal totalmoney = Convert.ToDecimal(dtSource.Rows[i]["totalmoney_dec"].ToString());
                    decimal acctmoney = Convert.ToDecimal(dtSource.Rows[i]["acctmoney_dec"].ToString());
                    decimal precent = Convert.ToDecimal(dtSource.Rows[i]["precent_dec"].ToString());
                    decimal decTotalDiffCost = 0;
                    decimal.TryParse(dtSource.Rows[i]["totaldiffcostmoney_dec"].ToString(), out decTotalDiffCost); ;//让利金额

                    if (ChargeType == 4)
                    {
                        SQL = @"update t_opr_bih_patientcharge
                                   set pstatus_int = 4,
                                       chearaccount_dat = sysdate, 
                                       chargeactive_dat = sysdate,  
                                       discount_dec = ?, 
                                       paymoneyid_chr = ?,
                                       totalmoney_dec = ?,
                                       acctmoney_dec = ?,
                                       totaldiffcostmoney_dec=?
                                 where pchargeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                        ParamArr[0].Value = precent;
                        ParamArr[1].Value = ChargeNo;
                        ParamArr[2].Value = totalmoney - decTotalDiffCost;
                        ParamArr[3].Value = acctmoney;
                        ParamArr[4].Value = decTotalDiffCost;
                        ParamArr[5].Value = id;
                    }
                    else if (ChargeType == 5)
                    {
                        SQL = @"update t_opr_bih_patientcharge
                                   set pstatus_int = 4,                                   
                                       chearaccount_dat = sysdate, 
                                       chargeactive_dat = sysdate,
                                       confirm_dat = sysdate,
                                       confirmerid_chr = ?,
                                       confirmer_vchr = ?,    
                                       discount_dec = ?, 
                                       paymoneyid_chr = ?,
                                       totalmoney_dec = ?,
                                       acctmoney_dec = ?,
                                       totaldiffcostmoney_dec=? 
                                 where pchargeid_chr = ?";

                        //确认收费更新医嘱执行单
                        string ts = @"update t_opr_bih_orderexecute 
                                        set confirm_dat = sysdate, 
                                            confirmerid_chr = ?,
                                            confirmer_vchr = ?  
                                      where needconfirm_int = 1 
                                        and orderexecid_chr = ( select orderexecid_chr 
                                                                  from t_opr_bih_patientcharge
                                                                 where pchargeid_chr = ?)";

                        objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                        ParamArr[0].Value = Confirm_VO.EmpId;
                        ParamArr[1].Value = Confirm_VO.EmpName;
                        ParamArr[2].Value = id;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(ts, ref lngAffects, ParamArr);

                        objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                        ParamArr[0].Value = Confirm_VO.EmpId;
                        ParamArr[1].Value = Confirm_VO.EmpName;
                        ParamArr[2].Value = precent;
                        ParamArr[3].Value = ChargeNo;
                        ParamArr[4].Value = totalmoney - decTotalDiffCost;
                        ParamArr[5].Value = acctmoney;
                        ParamArr[6].Value = decTotalDiffCost;
                        ParamArr[7].Value = id;
                    }
                    else
                    {
                        SQL = @"update t_opr_bih_patientcharge
                                   set pstatus_int = 3,
                                       chearaccount_dat = sysdate,   
                                       discount_dec = ?, 
                                       paymoneyid_chr = ?,
                                       totalmoney_dec = ?,
                                       acctmoney_dec = ?,
                                       totaldiffcostmoney_dec=?   
                                 where pchargeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                        ParamArr[0].Value = precent;
                        ParamArr[1].Value = ChargeNo;
                        ParamArr[2].Value = totalmoney - decTotalDiffCost;
                        ParamArr[3].Value = acctmoney;
                        ParamArr[4].Value = decTotalDiffCost;
                        ParamArr[5].Value = id;
                    }

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    StrChargeID += "a.pchargeid_chr = '" + id + "' or ";
                }

                //生成结算项目明细
                if (ChargeType == 6)
                {
                    string SubStr = "";
                    if (rpid != "")
                    {
                        SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr,totaldiffcostmoney_dec)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   trim(a.paymoneyid_chr) as chargeno,
                                                                   sysdate,
                                                                   a.pchargeid_chr,
                                                                   a.registerid_chr,
                                                                   a.createarea_chr,  
                                                                   a.clacarea_chr,
                                                                   a.curareaid_chr,
                                                                   a.curbedid_chr,
                                                                   a.doctorid_chr,
                                                                   a.doctorgroupid_chr,
                                                                   a.calccateid_chr,
                                                                   a.invcateid_chr,
                                                                   a.chargeitemid_chr,
                                                                   a.chargeitemname_chr,
                                                                   a.unit_vchr,
                                                                   a.spec_vchr,
                                                                   a.unitprice_dec,
                                                                   a.amount_dec,
                                                                   a.totalmoney_dec,
                                                                   a.discount_dec,
                                                                   a.newdiscount_dec,
                                                                   a.acctmoney_dec,
                                                                   a.chargedoctorid_chr,
                                                                   a.chargedoctorgroupid_chr,
                                                                   a.totaldiffcostmoney_dec 
                                                              from t_opr_bih_patientcharge a
                                                             where trim(a.paymoneyid_chr) = ?
                                                               and a.pchargeid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = rpid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        SubStr = " and a.pchargeid_chr <> '" + rpid + "'";
                    }

                    if (StrChargeID != "")
                    {
                        SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr,totaldiffcostmoney_dec)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   trim(a.paymoneyid_chr) as chargeno,
                                                                   sysdate,
                                                                   a.pchargeid_chr,
                                                                   a.registerid_chr,
                                                                   a.createarea_chr,  
                                                                   a.clacarea_chr,
                                                                   a.curareaid_chr,
                                                                   a.curbedid_chr,
                                                                   a.doctorid_chr,
                                                                   a.doctorgroupid_chr,
                                                                   a.calccateid_chr,
                                                                   a.invcateid_chr,
                                                                   a.chargeitemid_chr,
                                                                   a.chargeitemname_chr,
                                                                   a.unit_vchr,
                                                                   a.spec_vchr,
                                                                   a.unitprice_dec,
                                                                   a.amount_dec,
                                                                   (a.totalmoney_dec - nvl(b.totalmoney_dec, 0)) as totalmoney_dec,
                                                                   a.discount_dec,
                                                                   a.newdiscount_dec,
                                                                   round((a.totalmoney_dec - nvl(b.totalmoney_dec, 0)) * (100 - a.discount_dec) / 100, 2) as acctmoney_dec,
                                                                   a.chargedoctorid_chr,
                                                                   a.chargedoctorgroupid_chr,
                                                                   a.totaldiffcostmoney_dec  
                                                              from t_opr_bih_patientcharge a,
                                                                   t_opr_bih_chargeitementry b                                                                    
                                                             where a.pchargeid_chr = b.pchargeid_chr(+) 
                                                               and a.status_int = 1 
                                                               and (a.pstatus_int = 3 or a.pstatus_int = 4)
                                                               and a.chargeactive_dat is not null 
                                                               and trim(a.paymoneyid_chr) = ? 
                                                               and a.registerid_chr = ? " + SubStr;

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = RegID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }
                else
                {
                    if (StrChargeID != "")
                    {
                        StrChargeID = StrChargeID.Trim();
                        StrChargeID = StrChargeID.Substring(0, StrChargeID.Length - 2);

                        if (ChargeType == 2)
                        {
                            SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr,totaldiffcostmoney_dec)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   trim(a.paymoneyid_chr) as chargeno,
                                                                   sysdate,
                                                                   a.pchargeid_chr,
                                                                   a.registerid_chr,
                                                                   a.createarea_chr,  
                                                                   a.clacarea_chr,
                                                                   a.curareaid_chr,
                                                                   a.curbedid_chr,
                                                                   a.doctorid_chr,
                                                                   a.doctorgroupid_chr,
                                                                   a.calccateid_chr,
                                                                   a.invcateid_chr,
                                                                   a.chargeitemid_chr,
                                                                   a.chargeitemname_chr,
                                                                   a.unit_vchr,
                                                                   a.spec_vchr,
                                                                   a.unitprice_dec,
                                                                   a.amount_dec,
                                                                   a.totalmoney_dec,
                                                                   a.discount_dec,
                                                                   a.newdiscount_dec,
                                                                   a.acctmoney_dec,
                                                                   a.chargedoctorid_chr,
                                                                   a.chargedoctorgroupid_chr,
                                                                   a.totaldiffcostmoney_dec  
                                                              from t_opr_bih_patientcharge a
                                                             where a.status_int = 1 
                                                               and (a.pstatus_int = 3 or a.pstatus_int = 4)
                                                               and a.chargeactive_dat is not null 
                                                               and a.paymoneyid_chr = ?  
                                                              ";// and a.registerid_chr = ? 

                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = ChargeNo;
                            //  ParamArr[1].Value = RegID;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
                        else
                        {
                            SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr,totaldiffcostmoney_dec)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   trim(a.paymoneyid_chr) as chargeno,
                                                                   sysdate,
                                                                   a.pchargeid_chr,
                                                                   a.registerid_chr,
                                                                   a.createarea_chr,  
                                                                   a.clacarea_chr,
                                                                   a.curareaid_chr,
                                                                   a.curbedid_chr,
                                                                   a.doctorid_chr,
                                                                   a.doctorgroupid_chr,
                                                                   a.calccateid_chr,
                                                                   a.invcateid_chr,
                                                                   a.chargeitemid_chr,
                                                                   a.chargeitemname_chr,
                                                                   a.unit_vchr,
                                                                   a.spec_vchr,
                                                                   a.unitprice_dec,
                                                                   a.amount_dec,
                                                                   a.totalmoney_dec,
                                                                   a.discount_dec,
                                                                   a.newdiscount_dec,
                                                                   a.acctmoney_dec,
                                                                   a.chargedoctorid_chr,
                                                                   a.chargedoctorgroupid_chr,
                                                                   a.totaldiffcostmoney_dec  
                                                              from t_opr_bih_patientcharge a
                                                             where trim(a.paymoneyid_chr) = ?
                                                               and " + StrChargeID;

                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = ChargeNo;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
                    }
                }

                //出院结算生成最后一笔期帐
                if (ChargeType == 2 || ChargeType == 6)
                {
                    clsBihDayAccounts_VO DayAccounts_VO = new clsBihDayAccounts_VO();
                    DayAccounts_VO.RegisterID = RegID;
                    DayAccounts_VO.PatientID = Charge_VO.PatientID;
                    DayAccounts_VO.AreaID = Charge_VO.CurrAreaID;

                    //计算总金额、自付金额和记帐金额
                    decimal decTotalSum = 0;
                    decimal decSbSum = 0;
                    decimal decAcctSum = 0;

                    DataView dv = new DataView(dtSource);
                    dv.RowFilter = "pstatus_int <> 0 and dayaccountid_chr is null and registerid_chr='" + RegID + "'";

                    foreach (DataRowView drv in dv)
                    {
                        decimal d = decimal.Parse(drv["unitprice_dec"].ToString()) * decimal.Parse(drv["amount_dec"].ToString());
                        decTotalSum += this.Round(d, 2);
                        decSbSum += this.Round(d * decimal.Parse(drv["precent_dec"].ToString()) / 100, 2);
                    }

                    if (decTotalSum > 0)
                    {
                        DayAccounts_VO.TotalSum = decTotalSum;
                        DayAccounts_VO.SbSum = decSbSum;
                        DayAccounts_VO.AcctSum = decAcctSum;

                        lngRes = this.m_lngBuildDayAccounts(DayAccounts_VO, Charge_VO.OperEmp, 2);
                    }

                    RoundingVal = 0;

                    //判断是否有婴儿
                    if (Charge_VO.m_objBabyInfoVo != null)
                    {
                        //婴儿期账操作
                        for (int i2 = 0; i2 < Charge_VO.m_objBabyInfoVo.Length; i2++)
                        {
                            //clsBihDayAccounts_VO DayAccounts_VO = new clsBihDayAccounts_VO();
                            DayAccounts_VO.RegisterID = Charge_VO.m_objBabyInfoVo[i2].RegisterID;
                            DayAccounts_VO.PatientID = Charge_VO.m_objBabyInfoVo[i2].PatientID;
                            DayAccounts_VO.AreaID = Charge_VO.m_objBabyInfoVo[i2].AreaID;

                            //计算总金额、自付金额和记帐金额
                            decTotalSum = 0;
                            decSbSum = 0;
                            decAcctSum = 0;

                            dv = new DataView(dtSource);
                            dv.RowFilter = "pstatus_int <> 0 and dayaccountid_chr is null and registerid_chr='" + Charge_VO.m_objBabyInfoVo[i2].RegisterID + "'";

                            foreach (DataRowView drv in dv)
                            {
                                decimal d = decimal.Parse(drv["unitprice_dec"].ToString()) * decimal.Parse(drv["amount_dec"].ToString());
                                decTotalSum += this.Round(d, 2);
                                decSbSum += this.Round(d * decimal.Parse(drv["precent_dec"].ToString()) / 100, 2);
                            }

                            if (decTotalSum > 0)
                            {
                                DayAccounts_VO.TotalSum = decTotalSum;
                                DayAccounts_VO.SbSum = decSbSum;
                                DayAccounts_VO.AcctSum = decAcctSum;

                                lngRes = this.m_lngBuildDayAccounts(DayAccounts_VO, Charge_VO.OperEmp, 2);
                            }

                            RoundingVal = 0;
                        }

                    }
                }

                //非直收、非确认收费更新期帐
                if (ChargeType != 4 && ChargeType != 5)
                {
                    for (int i = 0; i < DayAccountsArr.Count; i++)
                    {
                        clsBihDayAccounts_VO DayAccounts = DayAccountsArr[i] as clsBihDayAccounts_VO;
                        if (DayChrgType == 1)
                        {
                            SQL = @"update t_opr_bih_dayaccount
                                       set charge_dec = ?,
                                           clearchg_dec = ?, 
                                           chgofmepay_dec = ?, 
                                           clearchgofme_dec = ?, 
                                           chgofhepay_dec = ?, 
                                           clearchgofhe_dec = ?, 
                                           clearmpoptid_chr = ?, 
                                           chearmp_dat = sysdate, 
                                           clearhpoptid_chr = ?,       
                                           clearhp_dat = sysdate 
                                     where dayaccountid_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(9, out ParamArr);
                            ParamArr[0].Value = DayAccounts.TotalSum + RoundingVal;
                            ParamArr[1].Value = DayAccounts.TotalSum + RoundingVal;
                            ParamArr[2].Value = DayAccounts.SbSum + RoundingVal;
                            ParamArr[3].Value = DayAccounts.SbSum + RoundingVal;
                            ParamArr[4].Value = DayAccounts.AcctSum;
                            ParamArr[5].Value = DayAccounts.AcctSum;
                            ParamArr[6].Value = DayAccounts.ChargeEmp;
                            ParamArr[7].Value = DayAccounts.ChargeEmp;
                            ParamArr[8].Value = DayAccounts.AccountsID;
                        }
                        else if (DayChrgType == 2)
                        {
                            SQL = @"update t_opr_bih_dayaccount
                                       set charge_dec = ?,
                                           clearchg_dec = nvl(clearchg_dec,0) + ? + ?, 
                                           chgofmepay_dec = ?, 
                                           clearchgofme_dec = nvl(clearchgofme_dec,0) + ?, 
                                           chgofhepay_dec = ?, 
                                           clearchgofhe_dec = nvl(clearchgofhe_dec,0) + ?, 
                                           clearmpoptid_chr = ?, 
                                           chearmp_dat = null, 
                                           clearhpoptid_chr = ?,       
                                           clearhp_dat = null 
                                     where dayaccountid_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(10, out ParamArr);
                            ParamArr[0].Value = DayAccounts.TotalSum + RoundingVal;
                            ParamArr[1].Value = DayAccounts.ClearSbSum + RoundingVal;
                            ParamArr[2].Value = DayAccounts.ClearAcctSum;
                            ParamArr[3].Value = DayAccounts.SbSum + RoundingVal;
                            ParamArr[4].Value = DayAccounts.ClearSbSum + RoundingVal;
                            ParamArr[5].Value = DayAccounts.AcctSum;
                            ParamArr[6].Value = DayAccounts.ClearAcctSum;
                            ParamArr[7].Value = DayAccounts.ChargeEmp;
                            ParamArr[8].Value = DayAccounts.ChargeEmp;
                            ParamArr[9].Value = DayAccounts.AccountsID;
                        }

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        RoundingVal = 0;
                    }
                }

                //预交金冲帐
                if (PrePayDeal == 1 && PrePayIDArr != null)
                {
                    for (int i = 0; i < PrePayIDArr.Count; i++)
                    {
                        string prepayid = PrePayIDArr[i].ToString();

                        SQL = @"update t_opr_bih_prepay set isclear_int = 1, chargeno_chr = ? where prepayid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = prepayid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }

                /***出院结算***/
                if (ChargeType == 2)
                {
                    //入院登记表
                    SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 3, operatorid_chr = ? where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Charge_VO.OperEmp;
                    ParamArr[1].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //出院记录表
                    SQL = @"update t_opr_bih_leave set modify_dat = sysdate, pstatus_int = 1, operatorid_chr = ? where status_int = 1 and registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Charge_VO.OperEmp;
                    ParamArr[1].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //床位表
                    SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //调转信息表
                    SQL = @"insert into t_opr_bih_transfer (transferid_chr, sourcebedid_chr, targetbedid_chr, type_int, des_vchr, operatorid_chr, registerid_chr, 
                                                            modify_dat, sourcedeptid_chr, sourceareaid_chr, targetdeptid_chr, targetareaid_chr)
                                       select LPAD (seq_opr_bih_transfer.NEXTVAL, 12, '0'),
                                              a.sourcebedid_chr,
                                              a.targetbedid_chr,
                                              6,
                                              '', ?,                                               
                                              a.registerid_chr,
                                              sysdate,
                                              a.sourcedeptid_chr,
                                              a.sourceareaid_chr, 
                                              a.targetdeptid_chr, 
                                              a.targetareaid_chr     
                                          from t_opr_bih_transfer a 
                                         where a.transferid_chr = (
                                                                    select max(b.transferid_chr) 
                                                                      from t_opr_bih_transfer b 
                                                                     where b.type_int = 7                                
                                                                       and b.registerid_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Charge_VO.OperEmp;
                    ParamArr[1].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);


                    #region 婴儿操作  by yibin.zheng 09-07-03
                    if (Charge_VO.m_objBabyInfoVo != null)
                    {
                        for (int i3 = 0; i3 < Charge_VO.m_objBabyInfoVo.Length; i3++)
                        {
                            string strBabyRegisterId = Charge_VO.m_objBabyInfoVo[i3].RegisterID;
                            //入院登记表
                            SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 3 where registerid_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            //ParamArr[0].Value = Charge_VO.OperEmp;
                            ParamArr[0].Value = strBabyRegisterId;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                            //出院记录表
                            SQL = @"update t_opr_bih_leave set modify_dat = sysdate, pstatus_int = 1, operatorid_chr = ? where status_int = 1 and registerid_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = Charge_VO.OperEmp;
                            ParamArr[1].Value = strBabyRegisterId;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                            //床位表
                            SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strBabyRegisterId;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                            //调转信息表
                            SQL = @"insert into t_opr_bih_transfer (transferid_chr, sourcebedid_chr, targetbedid_chr, type_int, des_vchr, operatorid_chr, registerid_chr, 
                                                            modify_dat, sourcedeptid_chr, sourceareaid_chr, targetdeptid_chr, targetareaid_chr)
                                       select LPAD (seq_opr_bih_transfer.NEXTVAL, 12, '0'),
                                              a.sourcebedid_chr,
                                              a.targetbedid_chr,
                                              6,
                                              '', ?,                                               
                                              a.registerid_chr,
                                              sysdate,
                                              a.sourcedeptid_chr,
                                              a.sourceareaid_chr, 
                                              a.targetdeptid_chr, 
                                              a.targetareaid_chr     
                                          from t_opr_bih_transfer a 
                                         where a.transferid_chr = (
                                                                    select max(b.transferid_chr) 
                                                                      from t_opr_bih_transfer b 
                                                                     where b.type_int = 7                                
                                                                       and b.registerid_chr = ?)";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = Charge_VO.OperEmp;
                            ParamArr[1].Value = strBabyRegisterId;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);


                        }
                    }
                    #endregion
                }
                /***呆帐结算***/
                else if (ChargeType == 3)
                {

                }
                else if (ChargeType == 4)
                {

                }
                else if (ChargeType == 5)
                {

                }
                /***呆帐补结算-暂不作处理***/
                else if (ChargeType == 6)
                {
                    //入院登记表
                    SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 6, operatorid_chr = ? where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = Charge_VO.OperEmp;
                    ParamArr[1].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else
                {
                    //更新入院登记表费用状态 2 - 中途清帐
                    SQL = @"update t_opr_bih_register set feestatus_int = 2 where registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = Charge_VO.RegisterID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                /******/
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
        /// 结帐
        /// </summary>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReckoning(clsBihCharge_VO Charge_VO, out string ChargeNo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";
            //根据时间生成结算号
            ChargeNo = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //入院登记号
                string RegID = Charge_VO.RegisterID;

                //入院登记表
                SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 3, operatorid_chr = ? where registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = Charge_VO.RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //出院记录表
                SQL = @"update t_opr_bih_leave set modify_dat = sysdate, pstatus_int = 1, operatorid_chr = ? where status_int = 1 and registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = Charge_VO.RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //床位表
                SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = Charge_VO.RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //调转信息表
                SQL = @"insert into t_opr_bih_transfer (transferid_chr, sourcebedid_chr, targetbedid_chr, type_int, des_vchr, operatorid_chr, registerid_chr, 
                                                            modify_dat, sourcedeptid_chr, sourceareaid_chr, targetdeptid_chr, targetareaid_chr)
                                       select LPAD (seq_opr_bih_transfer.NEXTVAL, 12, '0'),
                                              a.sourcebedid_chr,
                                              a.targetbedid_chr,
                                              6,
                                              '', ?,                                               
                                              a.registerid_chr,
                                              sysdate,
                                              a.sourcedeptid_chr,
                                              a.sourceareaid_chr, 
                                              a.targetdeptid_chr, 
                                              a.targetareaid_chr     
                                          from t_opr_bih_transfer a 
                                         where a.transferid_chr = (
                                                                    select max(b.transferid_chr) 
                                                                      from t_opr_bih_transfer b 
                                                                     where b.type_int = 7                                
                                                                       and b.registerid_chr = ?)";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = Charge_VO.RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

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

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="ChargeNo"></param>
        /// <param name="Invono"></param>
        /// <param name="EmpID"></param>
        /// <param name="ChargeType">结算类型：1 中途结算 2 出院结算 3 呆帐结算 4 直收 5 确认收费 6 呆帐补交款结算</param>
        /// <param name="PayMode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRefundment(string ChargeNo, string Invono, string EmpID, int ChargeType, int PayMode)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";
            //根据时间生成退款结算号
            string RefChargeNo = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //结算主表插负记录
                SQL = @"insert into t_opr_bih_charge(chargeno_chr, registerid_chr, paytypeid_chr, patienttype_chr, totalsum_mny, sbsum_mny, acctsum_mny, operemp_chr, 
                                                     operdate_dat, recflag_int, recemp_chr, recdate_dat, class_int, type_int, status_int, billno_int, areaid_chr)
                                             select ?, 
                                                    registerid_chr,  
                                                    paytypeid_chr,                             
                                                    patienttype_chr,
                                                    -totalsum_mny,
                                                    -sbsum_mny,
                                                    -acctsum_mny, ?, 
                                                    sysdate,
                                                    0,
                                                    null,
                                                    null,
                                                    class_int,
                                                    2,
                                                    1,
                                                    billno_int,
                                                    areaid_chr     
                                               from t_opr_bih_charge 
                                              where chargeno_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = RefChargeNo;
                ParamArr[1].Value = EmpID;
                ParamArr[2].Value = ChargeNo;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //结算明细表插负记录
                SQL = @"insert into t_opr_bih_chargecat(chargeno_chr, deptid_chr, itemcatid_chr, totalsum_mny, acctsum_mny) 
                                                 select ?, 
                                                        deptid_chr,
                                                        itemcatid_chr,
                                                        -totalsum_mny,
                                                        -acctsum_mny 
                                                   from t_opr_bih_chargecat 
                                                  where chargeno_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RefChargeNo;
                ParamArr[1].Value = ChargeNo;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //结算-发票对应表                
                SQL = "insert into t_opr_bih_chargedefinv(chargeno_chr, invoiceno_vchr) values(?, ?)";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RefChargeNo;
                ParamArr[1].Value = Invono;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //发票主表状态改退款、记录审核人、审核时间
                SQL = @"update t_opr_bih_invoice2
                            set status_int = 2,
                                confirmemp_chr = ?,
                                confirmdate_dat = sysdate 
                          where invoiceno_vchr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = EmpID;
                ParamArr[1].Value = Invono;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //支付表插入负数
                if (PayMode > 0)
                {
                    SQL = @"insert into t_opr_bih_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny)
                                               select ?, 
                                                      ?,
                                                      null,
                                                      null,    
                                                      sum(-paysum_mny) as paysum_mny,
                                                      sum(-refusum_mny) as refusum_mny 
                                                 from t_opr_bih_payment 
                                                where chargeno_vchr = ? 
                                             group by chargeno_vchr";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = RefChargeNo;
                    ParamArr[1].Value = PayMode;
                    ParamArr[2].Value = ChargeNo;
                }
                else
                {
                    SQL = @"insert into t_opr_bih_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny)
                                               select ?, 
                                                      paytype_int,
                                                      paycardtype_int,
                                                      paycardno_vchr,    
                                                      -paysum_mny,
                                                      -refusum_mny 
                                                from  t_opr_bih_payment 
                                               where  chargeno_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = RefChargeNo;
                    ParamArr[1].Value = ChargeNo;
                }
                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //生成结算项目明细              
                SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                               curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                               unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                               chargedoctorid_chr, chargedoctorgroupid_chr)
                                                        select seq_chargeitementry.NEXTVAL,
                                                               ?,
                                                               sysdate,
                                                               pchargeid_chr,
                                                               registerid_chr,
                                                               createarea_chr,  
                                                               clacarea_chr,
                                                               curareaid_chr,
                                                               curbedid_chr,
                                                               doctorid_chr,
                                                               doctorgroupid_chr,
                                                               calccateid_chr,
                                                               invcateid_chr,
                                                               chargeitemid_chr,
                                                               chargeitemname_chr,
                                                               unit_vchr,
                                                               spec_vchr,
                                                               unitprice_dec,
                                                               -amount_dec,
                                                               -totalmoney_dec,
                                                               discount_dec,
                                                               newdiscount_dec,
                                                               -acctmoney_dec,
                                                               chargedoctorid_chr,
                                                               chargedoctorgroupid_chr
                                                          from t_opr_bih_patientcharge 
                                                         where paymoneyid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RefChargeNo;
                ParamArr[1].Value = ChargeNo;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                if (ChargeType == 4 || ChargeType == 5)
                {
                    //费用明细表改为无效
                    SQL = @"update t_opr_bih_patientcharge
                               set status_int = 0,
                                   chearaccount_dat = null,
                                   paymoneyid_chr = null                                 
                             where paymoneyid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else
                {
                    //期帐表
                    SQL = @"update t_opr_bih_dayaccount ta
                           set (ta.clearchg_dec, ta.clearchgofme_dec, ta.clearchgofhe_dec,
                                ta.chearmp_dat, ta.clearhp_dat) =
                                  (select ta.clearchg_dec - tb.totalmny,
                                          ta.clearchgofme_dec - tb.sbmny,
                                          ta.clearchgofhe_dec - (tb.totalmny - tb.sbmny), null, null
                                     from (select   a.dayaccountid_chr,
                                                    sum (round (a.unitprice_dec * a.amount_dec, 2)
                                                        ) as totalmny,
                                                    sum (round (  a.unitprice_dec
                                                                * a.amount_dec
                                                                * a.discount_dec
                                                                / 100,
                                                                2
                                                               )
                                                        ) as sbmny
                                               from t_opr_bih_patientcharge a
                                              where a.status_int = 1 and a.paymoneyid_chr = ? 
                                           group by a.dayaccountid_chr) tb
                                    where ta.dayaccountid_chr = tb.dayaccountid_chr)
                         where exists (select 1
                                         from (select distinct a.dayaccountid_chr
                                                          from t_opr_bih_patientcharge a
                                                         where a.status_int = 1 and a.paymoneyid_chr = ?) tb
                                        where ta.dayaccountid_chr = tb.dayaccountid_chr)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //费用明细表改为待清
                    SQL = @"update t_opr_bih_patientcharge
                               set pstatus_int = 2,
                                   chearaccount_dat = null,
                                   paymoneyid_chr = null                                 
                             where paymoneyid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //判断是否日结
                    bool IsRec = false;
                    SQL = @"select a.chargeno_chr
                              from t_opr_bih_prepay a, t_opr_bih_charge b
                             where a.chargeno_chr = b.chargeno_chr
                               and b.recflag_int = 1
                               and b.chargeno_chr = ?";

                    DataTable dt = new DataTable();
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString().Trim() != "")
                        {
                            IsRec = true;
                        }
                    }

                    //恢复预交金状态：已清->未清
                    if (IsRec)
                    {
                        SQL = @"update t_opr_bih_prepay set isclear_int = 0, chargeno_chr = null, origchargeno_chr = ? where chargeno_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = ChargeNo;
                    }
                    else
                    {
                        SQL = @"update t_opr_bih_prepay set isclear_int = 0, chargeno_chr = null, origchargeno_chr = null where chargeno_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                    }

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                if (ChargeType == 2)
                {
                    //状态: 出院->预出院；费用: 出院结算->待清
                    SQL = @"update t_opr_bih_register a
                               set a.pstatus_int = 2,
                                   a.feestatus_int = 1 
                             where a.registerid_chr = (
                                                      select b.registerid_chr
                                                        from t_opr_bih_charge b 
                                                       where b.chargeno_chr = ? 
                                                      )";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //出院记录表 出院->预出院
                    SQL = @"update t_opr_bih_leave a
                               set a.pstatus_int = 0 
                             where a.registerid_chr = (
                                                      select b.registerid_chr
                                                        from t_opr_bih_charge b 
                                                       where b.chargeno_chr = ? 
                                                      )";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else if (ChargeType == 6)
                {
                    //状态: 费用: 呆帐补交款结算->呆帐结算
                    SQL = @"update t_opr_bih_register a
                               set a.feestatus_int = 4 
                             where a.registerid_chr = (
                                                      select b.registerid_chr
                                                        from t_opr_bih_charge b 
                                                       where b.chargeno_chr = ? 
                                                      )";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 根据结算号获取发票明细信息
        /// <summary>
        /// 根据结算号获取发票明细信息
        /// </summary>
        /// <param name="ChargeNo">结算号</param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPrepay"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInvoiceByChargeNo(string ChargeNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPrepay, out DataTable dtPayMode, out DataTable dtItemDate)
        {
            long lngRes = 0;
            string SQL = "";

            dtMain = new DataTable();
            dtDet = new DataTable();
            dtPrepay = new DataTable();
            dtPayMode = new DataTable();
            dtItemDate = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //发票主信息
                SQL = @"select d.inpatientid_chr, g.deptname_vchr, c.invoiceno_vchr, c.invdate_dat, c.totalsum_mny, c.status_int, c.sbsum_mny, c.acctsum_mny, 
                               e.lastname_vchr,e.sex_chr,e.insuranceid_vchr, d.inpatientcount_int, d.inpatient_dat, h.paytypename_vchr, f.empno_chr, i.outhospital_dat as outpatient_dat, '' as dbyljzj, '' ybjzfpje , '' bcyltczf1 , '' bcyltczf2 , '' bcyltczf3 ,'' bcyltczf4 ,'' qtzhifu
                         from t_opr_bih_charge a,
                              t_opr_bih_chargedefinv b,
                              t_opr_bih_invoice2 c,
                              t_opr_bih_register d,
                              t_opr_bih_registerdetail e,
                              t_bse_employee f,
                              t_bse_deptdesc g, 
                              t_bse_patientpaytype h, 
                              (select registerid_chr, outhospital_dat from t_opr_bih_leave where status_int = 1) i                                 
                        where a.chargeno_chr = b.chargeno_chr 
                          and b.invoiceno_vchr = c.invoiceno_vchr 
                          and a.registerid_chr = d.registerid_chr 
                          and a.registerid_chr = e.registerid_chr                           
                          and d.areaid_chr = g.deptid_chr 
                          and a.status_int = 1   
                          and a.operemp_chr = f.empid_chr(+)
                          and d.paytypeid_chr = h.paytypeid_chr(+) 
                          and a.registerid_chr = i.registerid_chr(+)   
                          and g.attributeid = '0000003'                                                      
                          and a.chargeno_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ChargeNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                if (lngRes > 0 && dtMain.Rows.Count > 0)
                {
                    //目前默认一次结算对应一张发票
                    string invono = dtMain.Rows[0]["invoiceno_vchr"].ToString().Trim();

                    //发票分类信息
                    SQL = @"select invoiceno_vchr, itemcatid_chr, sum(totalsum_mny) as totalsum_mny, sum(acctsum_mny) as acctsum_mny 
                              from t_opr_bih_invoice2de 
                             where invoiceno_vchr = ? 
                          group by invoiceno_vchr, itemcatid_chr";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = invono;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);

                    //预交款冲帐信息
                    SQL = @"select a.chargeno_chr, a.registerid_chr, a.patienttype_chr, a.totalsum_mny,
                                   a.sbsum_mny, a.acctsum_mny, a.operemp_chr, a.operdate_dat,
                                   a.recflag_int, a.recemp_chr, a.recdate_dat, a.class_int, a.type_int,
                                   a.status_int, a.paytypeid_chr, a.billno_int, a.areaid_chr, a.note_vchr, 
                                   b.money_dec, c.paysum_mny 
                              from t_opr_bih_charge a,
                                   t_opr_bih_prepay b,
                                   t_opr_bih_payment c  
                             where a.chargeno_chr = b.chargeno_chr 
                               and a.chargeno_chr = c.chargeno_vchr 
                               and a.status_int = 1          
                               and c.paytype_int = 0 
                               and a.chargeno_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPrepay, ParamArr);

                    //支付方式(除预交金)
                    SQL = @"select b.paytype_int, b.paysum_mny 
                              from t_opr_bih_charge a,
                                   t_opr_bih_payment b  
                             where a.chargeno_chr = b.chargeno_vchr 
                               and a.status_int = 1          
                               and b.paytype_int <> 0 
                               and a.chargeno_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayMode, ParamArr);

                    #region 嵌入式社保结算金额返回

                    SQL = @"select a.zyfyze, a.grzfeije, a.sbzfje, a.ylbz, a.jzje, a.dbyljzj,a.ybjzfpje, a.bcyltczf1,a.bcyltczf2, a.bcyltczf3,a.bcyltczf4,a.qtzhifu
                                  from t_ins_chargezy_csyb a, t_opr_bih_chargedefinv b
                                 where a.invoiceno_vchr = b.invoiceno_vchr
                                   and a.charge_status=1
                                   and b.chargeno_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    DataTable dtSbDate = new DataTable();
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtSbDate, ParamArr);

                    if (dtSbDate.Rows.Count > 0)
                    {
                        //新 社保报销金额 = YBJZFPJE + BCYLTCZF1 + BCYLTCZF2 + BCYLTCZF3 + BCYLTCZF4 + QTZHIFU
                        //自费总额 = GRZFEIJE
                        //新 医疗费用总额（YLFYZE）= YBJZFPJE + BCYLTCZF1 + BCYLTCZF2 + BCYLTCZF3 + BCYLTCZF4 + QTZHIFU+ GRZFEIJE

                        //住院总金额
                        decimal decAcct = Convert.ToDecimal(dtSbDate.Rows[0]["zyfyze"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["zyfyze"].ToString().Trim());
                        //个人自费金额
                        decimal decZfje = Convert.ToDecimal(dtSbDate.Rows[0]["grzfeije"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["grzfeije"].ToString().Trim());
                        //低保医疗救助金
                        decimal decDbyljzj = Convert.ToDecimal(dtSbDate.Rows[0]["dbyljzj"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["dbyljzj"].ToString().Trim());
                        //其他支付金额
                        decimal decQtzhifu = Convert.ToDecimal(dtSbDate.Rows[0]["qtzhifu"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["qtzhifu"].ToString().Trim());
                        //补充支付1
                        decimal decBcyltczf1 = Convert.ToDecimal(dtSbDate.Rows[0]["bcyltczf1"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["bcyltczf1"].ToString().Trim());
                        //补充支付2
                        decimal decBcyltczf2 = Convert.ToDecimal(dtSbDate.Rows[0]["bcyltczf2"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["bcyltczf2"].ToString().Trim());
                        //补充支付3
                        decimal decBcyltczf3 = Convert.ToDecimal(dtSbDate.Rows[0]["bcyltczf3"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["bcyltczf3"].ToString().Trim());
                        //医保记账发票金额
                        decimal decYbjzfpje = Convert.ToDecimal(dtSbDate.Rows[0]["ybjzfpje"].ToString().Trim().Length == 0 ? "0" : dtSbDate.Rows[0]["ybjzfpje"].ToString().Trim());
                        dtMain.Rows[0]["ybjzfpje"] = decYbjzfpje;
                        dtMain.Rows[0]["bcyltczf1"] = decBcyltczf1;
                        dtMain.Rows[0]["bcyltczf2"] = decBcyltczf2;
                        dtMain.Rows[0]["bcyltczf3"] = decBcyltczf3;
                        dtMain.Rows[0]["qtzhifu"] = decQtzhifu;
                        dtMain.Rows[0]["acctsum_mny"] = decAcct - decZfje - decQtzhifu - decBcyltczf1 - decBcyltczf2 - decBcyltczf3;
                        dtMain.Rows[0]["dbyljzj"] = decDbyljzj;
                    }
                    #endregion

                    if (dtMain.Rows[0]["outpatient_dat"].ToString() == "")
                    {
                        //剔除凑整费
                        SQL = @"select parmvalue_vchr
                                  from t_bse_sysparm 
                                 where status_int = 1 
                                   and parmcode_chr = '0016'";

                        string parmid = "";
                        DataTable dtTmp = new DataTable();
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtTmp);
                        if (lngRes > 0)
                        {
                            parmid = dtTmp.Rows[0][0].ToString().Trim();
                        }

                        //费用项目起止时间
                        SQL = @"select (select min(to_char(a.chargeactive_dat, 'yyyy-mm-dd'))
                                          from t_opr_bih_patientcharge a
                                         where a.chargeitemid_chr <> ?
                                           and a.chargeactive_dat is not null
                                           and a.paymoneyid_chr = ?) as mindate,
                                       (select max(to_char(a.chargeactive_dat, 'yyyy-mm-dd'))
                                          from t_opr_bih_patientcharge a
                                         where a.chargeitemid_chr <> ?
                                           and a.chargeactive_dat is not null
                                           and a.paymoneyid_chr = ?) as maxdate
                                  from dual";

                        objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                        ParamArr[0].Value = parmid;
                        ParamArr[1].Value = ChargeNo;
                        ParamArr[2].Value = parmid;
                        ParamArr[3].Value = ChargeNo;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtItemDate, ParamArr);

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

        #region 根据入院登记流水ID获取最后诊金、床位费生成时间
        /// <summary>
        /// 根据入院登记流水ID获取最后诊金、床位费生成时间
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="FinallyDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFinallyDiagFeeDateByRegID(string RegID, out string FinallyDate)
        {
            long lngRes = 0;

            FinallyDate = "";

            string SQL = @"select nvl(max(to_char(a.create_dat, 'yyyy-mm-dd hh24:mi:ss')), '') as finallydate 
                             from t_opr_bih_patientcharge a,
                                  t_bse_bih_specordercate b,
                                  ( select a.chargeitemid_chr
                                      from t_bse_bed a,
                                        (select a.sourcebedid_chr as bedid_chr
                                          from t_opr_bih_transfer a 
                                         where a.transferid_chr = (
                                                                    select max(b.transferid_chr) 
                                                                      from t_opr_bih_transfer b 
                                                                     where b.type_int = 7                                
                                                                       and b.registerid_chr = ? 
                                                                   )) b  
                                     where a.bedid_chr = b.bedid_chr) c
                            where a.status_int = 1                               
                              and (a.chargeitemid_chr = b.autochargeitemtype or a.chargeitemid_chr = c.chargeitemid_chr) 
                              and a.registerid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RegID;
                ParamArr[1].Value = RegID;

                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0)
                {
                    FinallyDate = dt.Rows[0]["finallydate"].ToString();
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

        #region 根据入院登记流水号获取预出院时间
        /// <summary>
        /// 根据入院登记流水号获取预出院时间
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PrepDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepLHDateByRegID(string RegID, out string PrepDate)
        {
            long lngRes = 0;

            PrepDate = "";

            string SQL = "select to_char(a.outhospital_dat, 'yyyy-mm-dd hh24:mi:ss') as cysj from t_opr_bih_leave a where a.status_int = 1 and a.pstatus_int = 0 and a.registerid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0)
                {
                    PrepDate = dt.Rows[0]["cysj"].ToString();
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

        #region 根据入院登记流水ID获取发票号信息
        /// <summary>
        /// 根据入院登记流水ID获取发票号信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="Type">发票类型范围：1 正常 2 正常+重打</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInvoiceByRegID(string RegID, int Type, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            if (Type == 1)
            {
                SQL = @"select a.invoiceno_vchr, a.invdate_dat, a.totalsum_mny, a.sbsum_mny,
                               a.acctsum_mny, a.status_int, a.confirmemp_chr, a.confirmdate_dat,
                               a.split_int, c.chargeno_chr as chargeno 
                          from t_opr_bih_invoice2 a,
                               t_opr_bih_chargedefinv b,
                               t_opr_bih_charge c
                         where a.invoiceno_vchr = b.invoiceno_vchr 
                           and b.chargeno_chr = c.chargeno_chr 
                           and c.status_int = 1  
                           and c.registerid_chr = ? 
                        order by a.invoiceno_vchr";
            }
            else if (Type == 2)
            {
                SQL = @"select a.status_int as status, a.status_int, a.invoiceno_vchr as invono, '' as sourceinvono, c.chargeno_chr as chargeno 
                          from t_opr_bih_invoice2 a,
                               t_opr_bih_chargedefinv b,
                               t_opr_bih_charge c
                         where a.invoiceno_vchr = b.invoiceno_vchr 
                           and b.chargeno_chr = c.chargeno_chr 
                           and c.status_int = 1      
                           and c.registerid_chr = ?  
                           
                        union all
                           
                        select 999 as status, a.status_int, d.repprnbillno_vchr as invono, d.sourcebillno_vchr as sourceinvono, c.chargeno_chr as chargeno 
                          from t_opr_bih_invoice2 a,
                               t_opr_bih_chargedefinv b,
                               t_opr_bih_charge c,
                               t_opr_bih_billrepeatprint d
                         where a.invoiceno_vchr = b.invoiceno_vchr                          
                           and b.chargeno_chr = c.chargeno_chr 
                           and b.chargeno_chr = d.billid_chr
                           and c.status_int = 1  
                           and c.registerid_chr = ?";   //-- and a.invoiceno_vchr = d.sourcebillno_vchr  
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (Type == 1)
                {
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;
                }
                else if (Type == 2)
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = RegID;
                    ParamArr[1].Value = RegID;
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

        #region 查询收费项目
        /// <summary>
        /// 查询收费项目
        /// </summary>
        /// <param name="FindStr">查找条件</param>
        /// <param name="PatType">病人身份</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindChargeItem(string FindStr, string PatType, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.itemid_chr, a.itemname_vchr, a.itemcode_vchr, a.itempycode_chr,
                                  a.itemwbcode_chr, a.itemsrcid_vchr, a.itemsrctype_int, a.itemspec_vchr,
                                  a.itemprice_mny, a.itemunit_chr, a.itemopunit_chr, a.itemipunit_chr,
                                  a.itemopcalctype_chr, a.itemipcalctype_chr, a.itemopinvtype_chr,
                                  a.itemipinvtype_chr, a.dosage_dec, a.dosageunit_chr, a.isgroupitem_int,
                                  a.itemcatid_chr, a.usageid_chr, a.itemopcode_chr, a.insuranceid_chr,
                                  a.selfdefine_int, a.packqty_dec, a.tradeprice_mny, a.poflag_int,
                                  a.isrich_int, a.opchargeflg_int, a.itemsrcname_vchr,
                                  a.itemsrctypename_vchr, a.itemengname_vchr, a.ifstop_int,
                                  a.pdcarea_vchr, a.ipchargeflg_int, a.insurancetype_vchr,
                                  a.apply_type_int, a.itembihctype_chr, a.defaultpart_vchr,
                                  a.itemchecktype_chr, a.itemcommname_vchr, a.ordercateid_chr,
                                  a.freqid_chr, a.inpinsurancetype_vchr, a.ordercateid1_chr,
                                  a.isselfpay_chr, a.itemprice_mny_old, a.itemprice_mny_new,
                                  a.keepuse_int, a.itemspec_vchr1, 
								  b.ipnoqtyflag_int, b.ifstop_int, c.precent_dec, e.typename_vchr as ybtypename,  
								  round (a.itemprice_mny / a.packqty_dec,4) as submoney, b.putmedtype_int 
							 from t_bse_chargeitem a, 
                                  t_bse_medicine b,
                                  (select itemid_chr, precent_dec from t_aid_inschargeitem where copayid_chr = ?) c, 
                                  t_aid_medicaretype e 
  						    where trim(a.itemsrcid_vchr) = trim(b.medicineid_chr(+))
							  and a.ifstop_int = 0
                              and a.itemid_chr = c.itemid_chr(+) 
                              and a.inpinsurancetype_vchr = e.typeid_chr(+) 
							  and ((lower(a.itemname_vchr) like ?)
								   or (lower(a.itemcode_vchr) like ?)
								   or (lower(a.itempycode_chr) like ?)
								   or (lower(a.itemwbcode_chr) like ?)
								   or (lower(a.itemopcode_chr) like ?))
						 order by a.itemcatid_chr";

            SQL = SQL.Replace("[FindStr]", FindStr.Trim().ToLower());

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = PatType;
                ParamArr[1].Value = FindStr.Trim().ToLower() + "%";
                ParamArr[2].Value = FindStr.Trim().ToLower() + "%";
                ParamArr[3].Value = FindStr.Trim().ToLower() + "%";
                ParamArr[4].Value = FindStr.Trim().ToLower() + "%";
                ParamArr[5].Value = FindStr.Trim().ToLower() + "%";

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
        /// 根据项目ID查找收费项目
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindChargeItem(string ItemID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.itemid_chr, a.itemname_vchr, a.itemcode_vchr, a.itempycode_chr,
                                  a.itemwbcode_chr, a.itemsrcid_vchr, a.itemsrctype_int, a.itemspec_vchr,
                                  a.itemprice_mny, a.itemunit_chr, a.itemopunit_chr, a.itemipunit_chr,
                                  a.itemopcalctype_chr, a.itemipcalctype_chr, a.itemopinvtype_chr,
                                  a.itemipinvtype_chr, a.dosage_dec, a.dosageunit_chr, a.isgroupitem_int,
                                  a.itemcatid_chr, a.usageid_chr, a.itemopcode_chr, a.insuranceid_chr,
                                  a.selfdefine_int, a.packqty_dec, a.tradeprice_mny, a.poflag_int,
                                  a.isrich_int, a.opchargeflg_int, a.itemsrcname_vchr,
                                  a.itemsrctypename_vchr, a.itemengname_vchr, a.ifstop_int,
                                  a.pdcarea_vchr, a.ipchargeflg_int, a.insurancetype_vchr,
                                  a.apply_type_int, a.itembihctype_chr, a.defaultpart_vchr,
                                  a.itemchecktype_chr, a.itemcommname_vchr, a.ordercateid_chr,
                                  a.freqid_chr, a.inpinsurancetype_vchr, a.ordercateid1_chr,
                                  a.isselfpay_chr, a.itemprice_mny_old, a.itemprice_mny_new,
                                  a.keepuse_int, a.itemspec_vchr1, 100 as precent_dec 								 
							 from t_bse_chargeitem a
  						    where a.itemid_chr = ? ";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ItemID;

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

        #region 直接收费生成费用明细
        /// <summary>
        /// 直接收费生成费用明细
        /// </summary>
        /// <param name="OrderDicArr">主诊疗项目数组</param>
        /// <param name="PatientChargeArr">费用明细数组</param>
        /// <param name="Type">8 直收 9 补记帐 7 补期帐</param>
        /// <param name="OrderID">返回的费用ID号(医嘱号字段)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGenPatientChargeByDir(ArrayList OrderDicArr, ArrayList PatientChargeArr, int Type, ref string OrderID)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (OrderID != "")
                {
                    SQL = @"delete from t_opr_bih_orderdic where orderid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = OrderID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    SQL = @"delete from t_opr_bih_patientcharge where orderid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = OrderID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else
                {
                    //根据时间生成费用ID号
                    OrderID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                }

                if (OrderDicArr != null)
                {
                    for (int i = 0; i < OrderDicArr.Count; i++)
                    {
                        clsBihOrderDic_VO OrderDic_VO = OrderDicArr[i] as clsBihOrderDic_VO;

                        SQL = @"insert into t_opr_bih_orderdic (orderid_int, orderid_chr, type_int, orderque_int, orderdicid_chr, orderdicname_vchr,
                                                            spec_vchr, qty_dec, pricemny_dec, totalmny_dec, attachorderid_vchr, attachorderbasenum_dec, sbbasemny_dec) values (                
                                                            seq_recipeorderid.NEXTVAL, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";


                        objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
                        ParamArr[0].Value = OrderID;
                        ParamArr[1].Value = OrderDic_VO.Type;
                        ParamArr[2].Value = OrderDic_VO.OrderQue;
                        ParamArr[3].Value = OrderDic_VO.OrderDicID;
                        ParamArr[4].Value = OrderDic_VO.OrderDicName;
                        ParamArr[5].Value = OrderDic_VO.Spec;
                        ParamArr[6].Value = OrderDic_VO.Qty;
                        ParamArr[7].Value = OrderDic_VO.PriceMny;
                        ParamArr[8].Value = OrderDic_VO.TotalMny;
                        ParamArr[9].Value = OrderDic_VO.AttachOrderID;
                        ParamArr[10].Value = OrderDic_VO.AttachOrderBaseNum;
                        ParamArr[11].Value = OrderDic_VO.SbBaseMny;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }

                for (int i = 0; i < PatientChargeArr.Count; i++)
                {
                    clsBihPatientCharge_VO PatientCharge_VO = PatientChargeArr[i] as clsBihPatientCharge_VO;

                    SQL = @"insert into t_opr_bih_patientcharge (pchargeid_chr, patientid_chr, registerid_chr, active_dat, orderid_chr, orderexectype_int, orderexecid_chr,
                                                             clacarea_chr, createarea_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                             unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr, createtype_int, creator_chr, create_dat, operator_chr,
                                                             modify_dat, deactivator_chr, deactivate_dat, status_int, pstatus_int, chearaccount_dat, dayaccountid_chr, paymoneyid_chr,
                                                             activator_chr, activatetype_int, isrich_int, isconfirmrefundment, refundmentchecker, refundmentdate, bmstatus_int, curareaid_chr,
                                                             curbedid_chr, doctorid_chr, doctor_vchr, doctorgroupid_chr, needconfirm_int, confirmerid_chr, confirmer_vchr, confirm_dat, 
                                                             chargeactive_dat, TotalMoney_dec, AcctMoney_dec, attachorderid_vchr, attachorderbasenum_dec, spec_vchr, putmedicineflag_int, 
                                                             chargedoctorid_chr, chargedoctor_vchr, chargedoctorgroupid_chr,totaldiffcostmoney_dec) values (                
                                                            lpad (seq_pchargeid.nextval, 18, '0'), ?, ?, null, ?, ?, null, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
                                                            to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?, sysdate, null, null, 1, ?, null, null, null, null, ?, ?, null, null, null, null, 
                                                            ?, ?, ?, ?, ?, ?, null, null, null, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                    objHRPSvc.CreateDatabaseParameter(40, out ParamArr);
                    ParamArr[0].Value = PatientCharge_VO.PatientID;
                    ParamArr[1].Value = PatientCharge_VO.RegisterID;
                    ParamArr[2].Value = OrderID;
                    ParamArr[3].Value = Type;
                    ParamArr[4].Value = PatientCharge_VO.ClacArea;
                    ParamArr[5].Value = PatientCharge_VO.CreateArea;
                    ParamArr[6].Value = PatientCharge_VO.CalcCateID;
                    ParamArr[7].Value = PatientCharge_VO.InvCateID;
                    ParamArr[8].Value = PatientCharge_VO.ChargeItemID;
                    ParamArr[9].Value = PatientCharge_VO.ChargeItemName;
                    ParamArr[10].Value = PatientCharge_VO.Unit;
                    ParamArr[11].Value = PatientCharge_VO.UnitPrice;
                    ParamArr[12].Value = PatientCharge_VO.Amount;
                    ParamArr[13].Value = PatientCharge_VO.Discount;
                    ParamArr[14].Value = PatientCharge_VO.Ismepay;
                    ParamArr[15].Value = PatientCharge_VO.Des;
                    ParamArr[16].Value = PatientCharge_VO.CreateType;
                    ParamArr[17].Value = PatientCharge_VO.Creator;
                    if (PatientCharge_VO.CreateDat == null || PatientCharge_VO.CreateDat.Trim() == "")
                    {
                        ParamArr[18].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        ParamArr[18].Value = PatientCharge_VO.CreateDat;
                    }
                    ParamArr[19].Value = PatientCharge_VO.Operator;
                    ParamArr[20].Value = PatientCharge_VO.PStatus;
                    ParamArr[21].Value = PatientCharge_VO.ActivateType;
                    ParamArr[22].Value = PatientCharge_VO.IsRich;
                    ParamArr[23].Value = PatientCharge_VO.CurAreaID;
                    ParamArr[24].Value = PatientCharge_VO.CurBedID;
                    ParamArr[25].Value = PatientCharge_VO.DoctorID;
                    ParamArr[26].Value = PatientCharge_VO.Doctor;
                    ParamArr[27].Value = PatientCharge_VO.DoctorGroupID;
                    ParamArr[28].Value = PatientCharge_VO.NeedConfirm;
                    ParamArr[29].Value = PatientCharge_VO.ActiveDat;
                    ParamArr[30].Value = PatientCharge_VO.TotalMoney_dec;
                    ParamArr[31].Value = PatientCharge_VO.AcctMoney_dec;
                    ParamArr[32].Value = PatientCharge_VO.AttachOrderID;
                    ParamArr[33].Value = PatientCharge_VO.AttachOrderBaseNum;
                    ParamArr[34].Value = PatientCharge_VO.SPEC_VCHR;
                    ParamArr[35].Value = PatientCharge_VO.PutMedicineFlag;
                    ParamArr[36].Value = PatientCharge_VO.CHARGEDOCTORID_CHR;
                    ParamArr[37].Value = PatientCharge_VO.CHARGEDOCTOR_VCHR;
                    ParamArr[38].Value = PatientCharge_VO.CHARGEDOCTORGROUPID_CHR;
                    if (PatientCharge_VO.TotalDiffCostMoney_dec != null)
                    {
                        ParamArr[39].Value = PatientCharge_VO.TotalDiffCostMoney_dec;
                    }
                    else
                    {
                        ParamArr[39].Value = 0;
                    }
                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 提交补记帐费用明细
        /// <summary>
        /// 提交补记帐费用明细
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitPatchCharge(string OrderID, string RegID, string OperID, int Type)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"update t_opr_bih_patientcharge 
                                set chargeactive_dat = sysdate, 		
	                                pstatus_int = 1		                        
                              where	status_int = 1 and orderid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = OrderID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //摆药
                ArrayList RegIDArr = new ArrayList();
                RegIDArr.Add(RegID);
                clsPutMedRequisitionSvc objPut = new clsPutMedRequisitionSvc();
                lngRes = objPut.CreatePutMedDetailByDptType(null, RegIDArr, OperID, Type);
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

        #region 补记帐退费
        /// <summary>
        /// 补记帐退费
        /// </summary>
        /// <param name="ChargeIDArr"></param>        
        /// <param name="EmpID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatchRefundment(ArrayList ChargeIDArr, string EmpID)
        //public long m_lngPatchRefundment(ArrayList ChargeIDArr, string RoundingCode, string EmpID)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                DataTable dtbTmp = new DataTable();
                int m_intManyReturnMed = 0;
                for (int i = 0; i < ChargeIDArr.Count; i++)
                {
                    string OrderID = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                    clsBihRefCharge_VO Ref_VO = ChargeIDArr[i] as clsBihRefCharge_VO;
                    SQL = @"select t.pchargeid_chr
  from t_opr_bih_patientcharge t
 where t.status_int = 1
   and t.pchargeidorg_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = Ref_VO.PChargeID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbTmp, ParamArr);
                    if (lngRes > 0 && dtbTmp.Rows.Count > 0)
                    {
                        m_intManyReturnMed = 1;
                    }
                    //查询是否已摆药
                    SQL = @"select t.putmeddetailid_chr
  from t_bih_opr_putmeddetail t
 where t.status_int = 1
   and t.isput_int = 0
   and t.pchargeid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = Ref_VO.PChargeID;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbTmp, ParamArr);

                    int intAuditintMed = 0;//是否摆药和定义是否退药审核（0为未摆药不需退药审核，1为摆药状态未审核退药状态）
                    if (lngRes > 0 && dtbTmp.Rows.Count > 0)//未摆药
                    {
                        intAuditintMed = 0;
                    }
                    else//已摆药
                    {
                        intAuditintMed = 1;
                    }

                    SQL = @"insert into t_opr_bih_patientcharge (pchargeid_chr, patientid_chr, registerid_chr, active_dat, orderid_chr, orderexectype_int, orderexecid_chr,
                                                             clacarea_chr, createarea_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, unit_vchr,
                                                             unitprice_dec, amount_dec, discount_dec, ismepay_int, des_vchr, createtype_int, creator_chr, create_dat, operator_chr,
                                                             modify_dat, deactivator_chr, deactivate_dat, status_int, pstatus_int, chearaccount_dat, dayaccountid_chr, paymoneyid_chr,
                                                             activator_chr, activatetype_int, isrich_int, isconfirmrefundment, refundmentchecker, refundmentdate, bmstatus_int, curareaid_chr,
                                                             curbedid_chr, doctorid_chr, doctor_vchr, doctorgroupid_chr, needconfirm_int, confirmerid_chr, confirmer_vchr, confirm_dat, 
                                                             chargeactive_dat, TotalMoney_dec, AcctMoney_dec, attachorderid_vchr, attachorderbasenum_dec, spec_vchr, putmedicineflag_int, 
                                                             chargedoctorid_chr, chargedoctor_vchr, chargedoctorgroupid_chr, pchargeidorg_chr,manyreturnmedill_int,returnmedbillno,itemchargetype_vchr,totaldiffcostmoney_dec)
                                                      select lpad (seq_pchargeid.nextval, 18, '0'),
                                                             patientid_chr,
                                                             registerid_chr,
                                                             sysdate,
                                                             nvl(orderid_chr, ?),
                                                             9,
                                                             orderexecid_chr,
                                                             clacarea_chr,
                                                             createarea_chr,
                                                             calccateid_chr,                
                                                             invcateid_chr,
                                                             chargeitemid_chr,
                                                             chargeitemname_chr,
                                                             unit_vchr,
                                                             unitprice_dec,
                                                             ? * -1,
                                                             discount_dec,
                                                             ismepay_int,
                                                             des_vchr,
                                                             createtype_int,
                                                             ?,
                                                             sysdate,
                                                             ?,
                                                             sysdate,
                                                             deactivator_chr,
                                                             deactivate_dat,
                                                             status_int,
                                                             1,
                                                             chearaccount_dat,
                                                             null,
                                                             paymoneyid_chr,   
                                                             ?,
                                                             2,                                                           
                                                             isrich_int,
                                                             ?,
                                                             ?,
                                                             sysdate,
                                                             bmstatus_int,
                                                             curareaid_chr,
                                                             curbedid_chr, doctorid_chr, doctor_vchr, doctorgroupid_chr, needconfirm_int, confirmerid_chr, confirmer_vchr, confirm_dat,
                                                             sysdate,
                                                             round(? * unitprice_dec, 2) * -1,                                                             
                                                             0,
                                                             null,
                                                             null,
                                                             spec_vchr, putmedicineflag_int, chargedoctorid_chr, chargedoctor_vchr, chargedoctorgroupid_chr, 
                                                             ? ,?,lpad (seq_returnmedbillno.nextval, 18, '0'),itemchargetype_vchr,?
                                                        from t_opr_bih_patientcharge 
                                                       where pchargeid_chr = ? ";//,manyreturnmedill_int,returnmedbillno ,?,lpad (seq_returnmedbillno.nextval, 18, '0') //

                    objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
                    ParamArr[0].Value = OrderID;
                    ParamArr[1].Value = Ref_VO.RefAmount;
                    ParamArr[2].Value = EmpID;
                    ParamArr[3].Value = EmpID;
                    ParamArr[4].Value = EmpID;
                    ParamArr[5].DbType = DbType.Int32;
                    ParamArr[5].Value = intAuditintMed;
                    ParamArr[6].Value = EmpID;
                    ParamArr[7].Value = Ref_VO.RefAmount;
                    ParamArr[8].Value = Ref_VO.PChargeID;
                    ParamArr[9].Value = m_intManyReturnMed;
                    ParamArr[10].DbType = DbType.Decimal;
                    ParamArr[10].Value = Ref_VO.m_decTotalDiffCost;//补回让利金额
                    ParamArr[11].Value = Ref_VO.PChargeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);


                    //                    //退费时更新药品让利金额
                    //                    //Start
                    //                    if (Ref_VO.m_decTotalOrgDiffCost != 0)
                    //                    {
                    //                        SQL = @"update t_opr_bih_patientcharge a
                    //                            set a.totaldiffcostmoney_dec = ?
                    //                           where a.pchargeid_chr = ? 
                    //                            ";
                    //                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    //                        ParamArr[0].DbType = DbType.Decimal;
                    //                        ParamArr[0].Value = Math.Abs(Ref_VO.m_decTotalDiffCost) - Math.Abs(Ref_VO.m_decTotalOrgDiffCost);//存负值
                    //                        ParamArr[1].Value = Ref_VO.PChargeID;
                    //                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    //                    }
                    //                    //End
                    if (intAuditintMed == 0)//未摆药
                    {
                        string strPutmeddetailid = dtbTmp.Rows[0]["putmeddetailid_chr"].ToString();



                        SQL = @"update t_bih_opr_putmeddetail t
   set t.status_int = 0
 where t.isput_int = 0 
   and t.status_int=1
   and t.putmeddetailid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = strPutmeddetailid;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        if (lngAffects > 0 && Ref_VO.m_blnIsAllRef == false)
                        {
                            SQL = @"insert into t_bih_opr_putmeddetail
                                              (putmeddetailid_chr, areaid_chr, paientid_chr, registerid_chr,
                                               orderid_chr, orderexecid_chr, orderexectype_int, recipeno_int, dosage_dec,
                                               dosageunit_vchr, chargeitemid_chr, medid_chr, medname_vchr, isrich_int,
                                               dosetypeid_chr, execfreqid_chr, exectimes_int, execdays_int,
                                               unitprice_mny, unit_vchr, get_dec, pchargeid_chr, creator_chr, create_dat,
                                               isput_int, puttype_int, putmedreqid_chr, exectime_vchr, pubdate_dat,
                                               needconfirm_int, activatetype_int, isrecruit_int, areaseq_int,
                                               outgetmeddays_int, medstoreid_chr, medicnetype_int, putmedtype_int,
                                               bedid_chr, examreturnmed_int, examreturnmed_dat, status_int
                                               )
                                              select lpad(seq_putmeddetail.nextval, 18, '0'), a.areaid_chr,
                                                     a.paientid_chr, a.registerid_chr, a.orderid_chr, a.orderexecid_chr,
                                                     a.orderexectype_int, a.recipeno_int, a.dosage_dec,
                                                     a.dosageunit_vchr, a.chargeitemid_chr, a.medid_chr, a.medname_vchr,
                                                     a.isrich_int, a.dosetypeid_chr, a.execfreqid_chr, a.exectimes_int,
                                                     a.execdays_int, a.unitprice_mny, a.unit_vchr, a.get_dec - ?, ?, ?,
                                                     sysdate, a.isput_int, a.puttype_int, a.putmedreqid_chr,
                                                     a.exectime_vchr, a.pubdate_dat, a.needconfirm_int,
                                                     a.activatetype_int, a.isrecruit_int, a.areaseq_int,
                                                     a.outgetmeddays_int, a.medstoreid_chr, a.medicnetype_int,
                                                     a.putmedtype_int, a.bedid_chr, a.examreturnmed_int,
                                                     a.examreturnmed_dat, 1
                                                from t_bih_opr_putmeddetail a
                                               where a.status_int = 0
                                                 and isput_int = 0
                                                 and a.putmeddetailid_chr = ?
                                                 ";
                            objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                            ParamArr[0].Value = Ref_VO.RefAmount;
                            ParamArr[1].Value = Ref_VO.PChargeID;
                            ParamArr[2].Value = EmpID;
                            ParamArr[3].Value = strPutmeddetailid;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);


                        }
                    }
                    //else//已摆药
                    //{
                    //    SQL = @"update t_bih_opr_putmeddetail set status_int=2 where pchargeid_chr = ?";
                    //    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    //    ParamArr[0].Value = Ref_VO.PChargeID;
                    //    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    //}
                }

                #region
                /*
                //平帐
                if (RoundingCode != "")
                {
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RoundingCode;

                    DataTable dt = new DataTable();
                    SQL = @"select count(a.itemid_chr) from t_bse_chargeitem a where a.ifstop_int = 0 and a.itemid_chr = ?";
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (lngRes > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                        {
                            for (int i = 0; i < ChargeIDArr.Count; i++)
                            {                              
                                clsBihRefCharge_VO Ref_VO = ChargeIDArr[i] as clsBihRefCharge_VO;

                                if (this.Round(Ref_VO.RefPrice, 2) != Ref_VO.RefPrice)
                                {
                                    decimal decTotalSum = 0;
                                    decimal decTotalSumRef = 0;
                                    string pchargeid = Ref_VO.PChargeID;

                                    DataTable dt1 = new DataTable();
                                    SQL = @"select nvl(round(a.amount_dec * a.unitprice_dec, 2), 0) as totalsum from t_opr_bih_patientcharge a where a.pchargeid_chr = ?";

                                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                                    ParamArr[0].Value = pchargeid;

                                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, ParamArr);
                                    
                                    decTotalSum = Convert.ToDecimal(dt1.Rows[0][0].ToString());

                                    DataTable dt2 = new DataTable();
                                    SQL = @"select nvl(round(a.amount_dec * a.unitprice_dec, 2), 0) as totalsum from t_opr_bih_patientcharge a where a.pchargeidorg_chr = ?";

                                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                                    ParamArr[0].Value = pchargeid;

                                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt2, ParamArr);

                                    decTotalSumRef = Convert.ToDecimal(dt2.Rows[0][0].ToString());

                                    decimal val = decTotalSum - decTotalSumRef;
                                    if (val < 0)
                                    {                                     
                                        int pos = Convert.ToString(Math.Abs(val)).IndexOf(".");
                                        if (pos > 0)
                                        {
                                            int len = Convert.ToString(Math.Abs(val)).Length - pos - 1;
                                        }
                                    }
                                }                                                           
                            }
                        }
                    }
                } */
                #endregion
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

        #region 获取补记帐、直收费用(诊疗项目)主表记录
        /// <summary>
        /// 获取补记帐、直收费用(诊疗项目)主表记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderDic(string OrderID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @" select a.orderid_int, a.orderid_chr, a.type_int, a.orderque_int,
                                       a.orderdicid_chr, a.orderdicname_vchr, a.spec_vchr, a.qty_dec,
                                       a.pricemny_dec, a.totalmny_dec, a.attachorderid_vchr,
                                       a.attachorderbasenum_dec, a.sbbasemny_dec 
                                  from t_opr_bih_orderdic a
                                 where a.orderid_chr = ?                                        
                              order by a.orderque_int ";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = OrderID;

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

        #region 根据医嘱ID(直收费用ID)获取费用明细
        /// <summary>
        /// 根据医嘱ID(直收费用ID)获取费用明细
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientChargeByID(string ID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
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
                                   a.chargedoctor_vchr, a.pchargeidorg_chr
                              from t_opr_bih_patientcharge a
                             where a.status_int = 1 
                               and a.activatetype_int = 5 
                               and a.orderid_chr = ?";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;

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

        #region 补期帐
        /// <summary>
        /// 补期帐
        /// </summary>
        /// <param name="PatientChargeArr">费用明细数组</param>        
        /// <param name="DayAccountID">期帐ID</param>                
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPatchDayAccount(ArrayList PatientChargeArr, string DayAccountID)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                decimal total = 0;
                for (int i = 0; i < PatientChargeArr.Count; i++)
                {
                    clsBihPatientCharge_VO PatientCharge_VO = PatientChargeArr[i] as clsBihPatientCharge_VO;

                    total += this.Round(PatientCharge_VO.Amount * PatientCharge_VO.UnitPrice, 2);
                }

                string SQL = @"update t_opr_bih_dayaccount
                                   set charge_dec = charge_dec + ? 
                                 where dayaccountid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = total;
                ParamArr[1].Value = DayAccountID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                if (lngRes > 0)
                {
                    string orderid = "";
                    lngRes = this.m_lngGenPatientChargeByDir(null, PatientChargeArr, 7, ref orderid);
                    if (lngRes > 0)
                    {
                        SQL = @"update t_opr_bih_patientcharge
                                   set dayaccountid_chr = ?  
                                 where orderid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = DayAccountID;
                        ParamArr[1].Value = orderid;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 获取收费项目默认执行地点
        /// <summary>
        /// 获取收费项目默认执行地点
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="ApplyAreaID"></param>
        /// <param name="AreaName"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetChargeItemDefaultExecAreaID(string ItemID, string ApplyAreaID, out string ExecAreaName)
        {
            long lngRes = 0;
            string ExecAreaID = "";

            ExecAreaName = "";

            string SQL = @"select nvl(b.clacarea_chr, '') as areaid1, d1.deptname_vchr as areaname1,
                                  nvl(c.clacarea_chr, '') as areaid2, d2.deptname_vchr as areaname2 
                             from t_bse_chargeitem a,
                                  (select ordercateid_chr, clacarea_chr from t_aid_bih_ocdeptdefault where createarea_chr = ?) b,
                                  t_aid_bih_ocdeptlist c,
                                  t_bse_deptdesc d1,
                                  t_bse_deptdesc d2      
                            where a.ordercateid_chr = b.ordercateid_chr(+)                                                 
                              and a.ordercateid_chr = c.ordercateid_chr(+)
                              and b.clacarea_chr = d1.deptid_chr(+)
                              and c.clacarea_chr = d2.deptid_chr(+)    
                              and rownum = 1                       
                              and a.itemid_chr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = ApplyAreaID;
                ParamArr[1].Value = ItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    string s1 = dt.Rows[0]["areaid1"].ToString();
                    string s2 = dt.Rows[0]["areaid2"].ToString();

                    if (s1 == "")
                    {
                        if (s2 != "")
                        {
                            ExecAreaID = s2;
                            ExecAreaName = dt.Rows[0]["areaname2"].ToString();
                        }
                    }
                    else
                    {
                        ExecAreaID = s1;
                        ExecAreaName = dt.Rows[0]["areaname1"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return ExecAreaID;
        }
        #endregion

        #region 保存发票打印设置
        /// <summary>
        /// 保存发票打印设置
        /// </summary>
        /// <param name="ChargeItemCatArr">费用分类设置VO</param>
        /// <param name="Scope">范围: 1 门诊核算 2 门诊发票 3 住院核算 4 住院发票</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveInvoiceSet(ArrayList ChargeItemCatArr, string Scope)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = "delete from t_bse_defchargecat where scope_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = Scope;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                for (int i = 0; i < ChargeItemCatArr.Count; i++)
                {
                    clsBihChargeItemCat_VO ChargeItemCat_VO = ChargeItemCatArr[i] as clsBihChargeItemCat_VO;

                    SQL = @"insert into t_bse_defchargecat (scope_chr, catid_chr, catname_vchr, type_int, compexp_vchr, dispctl_vchr, prtclt_vchr, status_int) values ( 
                                                            ?, ?, ?, ?, ?, ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                    ParamArr[0].Value = ChargeItemCat_VO.Scope;
                    ParamArr[1].Value = ChargeItemCat_VO.CatID;
                    ParamArr[2].Value = ChargeItemCat_VO.CatName;
                    ParamArr[3].Value = ChargeItemCat_VO.Type;
                    ParamArr[4].Value = ChargeItemCat_VO.CompExp;
                    ParamArr[5].Value = ChargeItemCat_VO.DispCtl;
                    ParamArr[6].Value = ChargeItemCat_VO.PrtClt;
                    ParamArr[7].Value = ChargeItemCat_VO.Status;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parmcode">参数代码</param>
        /// <returns>值</returns>
        [AutoComplete]
        public string m_strGetSysparm(string parmcode)
        {
            string parmvalue = "";
            try
            {
                string SQL = @"select parmvalue_vchr
                                 from t_bse_sysparm 
                                where status_int = 1 
                                  and parmcode_chr = ?";

                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = parmcode;

                long l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    parmvalue = dt.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return parmvalue;
        }
        #endregion

        #region 收款员日结(发票+按金)
        /// <summary>
        /// 收款员日结(发票+按金)
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <param name="RecType">0 全部 1 发票 2 按金</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDayReckoningUnion(string EmpID, string RecDate, string RemarkInfo, int RecType)
        {
            long ret = 0;

            if (RecType == 0)
            {
                // 发票
                ret = this.m_lngDayReckoning(EmpID, RecDate, RemarkInfo);
                // 按金
                RemarkInfo = "";
                ret = this.m_lngDayReckoningPre(EmpID, RecDate, RemarkInfo);
            }
            else if (RecType == 1)
            {
                // 发票
                ret = this.m_lngDayReckoning(EmpID, RecDate, RemarkInfo);
            }
            else if (RecType == 2)
            {
                // 按金
                ret = this.m_lngDayReckoningPre(EmpID, RecDate, RemarkInfo);
            }

            return ret;
        }
        #endregion

        #region 收款员日结(发票)
        /// <summary>
        /// 收款员日结(发票)
        /// </summary>
        /// <param name="EmpID">收款员ID</param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDayReckoning(string EmpID, string RecDate, string RemarkInfo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL            
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"update t_opr_bih_charge a
                                set a.recflag_int = 1,
                                    a.recdate_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'), 
                                    a.recemp_chr = ?                               
                             where a.status_int = 1                                  
                               and a.recflag_int = 0 
                               and a.operemp_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = RecDate;
                ParamArr[1].Value = EmpID;
                ParamArr[2].Value = EmpID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                if (RemarkInfo.Trim() != "")
                {
                    SQL = "insert into t_opr_bih_ReckoningRemark (operemp_chr, recdate_dat, remark_vchr) values (?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?)";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = EmpID;
                    ParamArr[1].Value = RecDate;
                    ParamArr[2].Value = RemarkInfo.Trim();

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

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

        #region 收款员日结(按金)
        /// <summary>
        /// 收款员日结(按金)
        /// </summary>
        /// <param name="EmpID">收款员ID</param>
        /// <param name="RecDate"></param>      
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDayReckoningPre(string EmpID, string RecDate, string RemarkInfo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL            
            string SQL = "";
            //日结ID
            string BalanceID = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                //取期帐序列ID
                SQL = "select seq_prepaybalance.NEXTVAL from dual";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0)
                {
                    BalanceID = dt.Rows[0][0].ToString();
                }

                //插结帐备注表
                SQL = "insert into t_opr_bih_prepaybalance (balanceid_vchr, balanceemp_chr, balance_dat, remark_vchr) values (?, ?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?)";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = BalanceID;
                ParamArr[1].Value = EmpID;
                ParamArr[2].Value = RecDate;
                ParamArr[3].Value = RemarkInfo.Trim();

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //更新主表
                SQL = @"update t_opr_bih_prepay 
                           set balanceemp_chr = ?, balance_dat = to_date(?, 'yyyy-mm-dd hh24:mi:ss'), balanceid_vchr = ?, balanceflag_int = 1 
                         where balanceflag_int = 0
                           and creatorid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = EmpID;
                ParamArr[1].Value = RecDate;
                ParamArr[2].Value = BalanceID;
                ParamArr[3].Value = EmpID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 修改备注信息
        /// <summary>
        /// 修改备注信息
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateDayRecRemark(string EmpID, string RecDate, string RemarkInfo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL            
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"delete from t_opr_bih_ReckoningRemark where operemp_chr = ? and to_char(recdate_dat, 'yyyy-mm-dd hh24:mi:ss') = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = EmpID;
                ParamArr[1].Value = RecDate;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = "insert into t_opr_bih_ReckoningRemark (operemp_chr, recdate_dat, remark_vchr) values (?, to_date(?, 'yyyy-mm-dd hh24:mi:ss'), ?)";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = EmpID;
                ParamArr[1].Value = RecDate;
                ParamArr[2].Value = RemarkInfo.Trim();

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 获取收款员日结时间列表
        /// <summary>
        /// 获取收款员日结时间列表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDayReckoningTime(string EmpID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select distinct recdate
                           from (
                                   select to_char(a.recdate_dat, 'yyyy-mm-dd hh24:mi:ss') as recdate 
                                     from t_opr_bih_charge a 
                                    where a.status_int = 1                                  
                                      and a.recflag_int = 1 
                                      and a.recemp_chr = ? 
                                      and (a.recdate_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss')) 

                                   union all

                                   select to_char(a.balance_dat, 'yyyy-mm-dd hh24:mi:ss') as recdate
                                     from t_opr_bih_prepaybalance a 
                                    where a.balanceemp_chr = ?
                                      and (a.balance_dat between to_date(?, 'yyyy-mm-dd hh24:mi:ss') and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))   
                                 )
                           order by recdate";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = EmpID;
                ParamArr[1].Value = BeginDate;
                ParamArr[2].Value = EndDate;
                ParamArr[3].Value = EmpID;
                ParamArr[4].Value = BeginDate;
                ParamArr[5].Value = EndDate;

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

        #region 记录当前收费员使用之发票号
        /// <summary>
        /// 记录当前收费员使用之发票号
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="InvoNo"></param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRegOperInvoNO(string OperID, string InvoNo, int Type)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                bool IsExists = false;
                DataTable dt = new DataTable();

                SQL = @"select count(a.operid_chr) from t_opr_bih_operinvonorecord a where a.operid_chr = ? and a.type_int = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = OperID;
                ParamArr[1].Value = Type;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);

                if (lngRes > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                    {
                        IsExists = true;
                    }
                }

                if (IsExists)
                {
                    SQL = @"update t_opr_bih_operinvonorecord a set a.invono_vchr = ?, a.usedate_dat = sysdate where a.operid_chr = ? and a.type_int = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = InvoNo;
                    ParamArr[1].Value = OperID;
                    ParamArr[2].Value = Type;
                }
                else
                {
                    SQL = @"insert into t_opr_bih_operinvonorecord (operid_chr, invono_vchr, usedate_dat, type_int) 
                                                            values (?, ?, sysdate, ?)";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = OperID;
                    ParamArr[1].Value = InvoNo;
                    ParamArr[2].Value = Type;
                }

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 获取当前收费员使用之发票号
        /// <summary>
        /// 获取当前收费员使用之发票号
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOperInvoNO(string OperID, int Type, out string InvoNo)
        {
            long lngRes = 0;

            InvoNo = "";

            string SQL = "select a.invono_vchr from t_opr_bih_operinvonorecord a where a.operid_chr = ? and a.type_int = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = OperID;
                ParamArr[1].Value = Type;

                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    InvoNo = dt.Rows[0]["invono_vchr"].ToString().Trim();
                    if (InvoNo != "")
                    {
                        if (Type == 1)
                        {
                            InvoNo = InvoNo.Substring(0, 2) + Convert.ToString(Convert.ToDecimal(InvoNo.Substring(2)) + 1).PadLeft(8, '0');
                        }
                        //else if (Type == 2)
                        //{
                        //    //佛二的要求，押金单不用管
                        //    InvoNo =  Convert.ToString(int.Parse(InvoNo) + 1);
                        //}
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

        #region (医保试算)

        #region (医保试算)发送数据
        /// <summary>
        /// (医保试算)发送数据
        /// </summary>
        /// <param name="HospCode"></param>
        /// <param name="RegID"></param>        
        /// <param name="Mode">1 模式一：全部未清项目 2 模式二：指定项目</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBudgetSendData(string HospCode, string RegID, int Mode)
        {
            long lngRes = 0;
            long lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (Mode == 1)
                {
                    SQL = @"delete from ybad10 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(a.inpatientcount_int)
                                                                                       from t_opr_bih_register a
                                                                                      where a.registerid_chr = ? )";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    SQL = @"insert into ybad10 (yydm, zyhm, zych, xinm, xinb, sfzh, csrq, ksdm, ryrq, cyrq, zyts, 
                                                zdfl, zddm, sczt, rylb, dylb, jslx, yyfd, jjfd, ybcs, zfje)
                                        select ?,
                                               a.inpatientid_chr,
                                               a.inpatientcount_int,
                                               b.lastname_vchr,
                                               b.sex_chr,
                                               b.idcard_chr,
                                               b.birth_dat,
                                               a.deptid_chr,
                                               a.inareadate_dat,
                                               sysdate,
                                               floor(sysdate - a.inareadate_dat),
                                               null,
                                               null,
                                               null,
                                               c.jslx,
                                               null,
                                               c.rylb,
                                               100,
                                               nvl(b.insuredpayscale_dec, 100),
                                               b.insuredpaytime_int,
                                               b.insuredpaymoney_mny 
                                          from t_opr_bih_register a,
                                               t_opr_bih_registerdetail b,
                                               t_opr_bih_ybdefpaytype c          
                                         where a.registerid_chr = b.registerid_chr 
                                           and a.paytypeid_chr = c.paytypeid_chr  
                                           and a.registerid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = HospCode;
                    ParamArr[1].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    SQL = @"delete from ybad13 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(a.inpatientcount_int)
                                                                                       from t_opr_bih_register a
                                                                                      where a.registerid_chr = ? )";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    SQL = @"insert into ybad13 ( yydm, zyhm, zych, xmcode, xmdes, xmunt, xmqnt, xmprc, xmamt, trndate, trnflg) 
                                        select ?,
                                               a.inpatientid_chr,
                                               a.inpatientcount_int,
                                               c.itemcode_vchr,
                                               max(substr(c.itemname_vchr,0,15)),
                                               max(b.unit_vchr),
                                               sum(b.amount_dec),
                                               max(b.unitprice_dec),
                                               sum(round(b.amount_dec * b.unitprice_dec, 2)),
                                               sysdate,
                                               '0'        
                                          from t_opr_bih_register a,
                                               t_opr_bih_patientcharge b,
                                               t_bse_chargeitem c 
                                         where a.registerid_chr = b.registerid_chr 
                                           and b.chargeitemid_chr = c.itemid_chr 
                                           and length(c.itemcode_vchr) <= 20 
                                           and (b.pstatus_int = 1 or b.pstatus_int = 2)
                                           and a.registerid_chr = ? 
                                      group by a.inpatientid_chr, a.inpatientcount_int, c.itemcode_vchr";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = HospCode;
                    ParamArr[1].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }
                else if (Mode == 2)
                {
                    //待写
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

        #region (医保试算)接收数据
        /// <summary>
        /// (医保试算)接收数据
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBudgetGetData(string RegID, out DataTable dtMain, out DataTable dtDet)
        {
            long lngRes = 0;
            //long lngAffects = 0;
            string SQL = "";

            dtMain = new DataTable();
            dtDet = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select zl19, yb02 from ybad11 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(a.inpatientcount_int)
                                                                                              from t_opr_bih_register a
                                                                                             where a.registerid_chr = ? )";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                //                SQL = @"select * from ybad12 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(a.inpatientcount_int)
                //                                                                                     from t_opr_bih_register a
                //                                                                                    where a.registerid_chr = ? )";

                //                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //                ParamArr[0].Value = RegID;

                //                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);

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

        #region (医保)下载医保前置机数据->生成到本地
        /// <summary>
        /// (医保)下载医保前置机数据->生成到本地
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDownloadYBData(DataTable dt)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    SQL = @"insert into t_tmp_mashxm (hos_code, zyno, zysno, xmcode, xmdes, xmunt, xmqnt, 
                                                xmprc, xmamt, trndate, trnflag, memoa, u_version) values (
                                                ?, ?, ?, ?, ?, ?, ?, ?, ?, to_date(?, 'yyyy-mm-dd'), ?, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(13, out ParamArr);
                    ParamArr[0].Value = dr["hos_code"].ToString();
                    ParamArr[1].Value = dr["zyno"].ToString();
                    ParamArr[2].Value = dr["zysno"].ToString();
                    ParamArr[3].Value = dr["xmcode"].ToString();
                    ParamArr[4].Value = dr["xmdes"].ToString();
                    ParamArr[5].Value = dr["xmunt"].ToString();
                    ParamArr[6].Value = dr["xmqnt"].ToString();
                    ParamArr[7].Value = dr["xmprc"].ToString();
                    ParamArr[8].Value = dr["xmamt"].ToString();
                    ParamArr[9].Value = dr["trndate"].ToString();
                    ParamArr[10].Value = dr["trnflag"].ToString();
                    ParamArr[11].Value = dr["memoa"].ToString();
                    ParamArr[12].Value = dr["u_version"].ToString();

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region (医保)删除已下载医保前置机数据
        /// <summary>
        /// (医保)删除已下载医保前置机数据
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelDownloadYBData(string Zyh, int Zycs)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //执行SQL           
                string SQL = @"delete from t_tmp_mashxm where zyno = ? and zysno = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zyh;
                ParamArr[1].Value = Zycs;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region (医保)获取已下载医保前置机数据
        /// <summary>
        /// (医保)获取已下载医保前置机数据
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDownloadYBData(string Zyh, int Zycs, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //执行SQL           
                string SQL = @"select * from t_tmp_mashxm where zyno = ? and zysno = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zyh;
                ParamArr[1].Value = Zycs;

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

        #region (医保)更新医保统筹费用
        /// <summary>
        /// (医保)更新医保统筹费用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="InsuredSum"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInsuredSum(string RegID, decimal InsuredSum)
        {
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //执行SQL           
                string SQL = @"update t_opr_bih_register a set a.insuredsum_mny = ? where a.registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = InsuredSum;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public decimal ConvertObjToDecimal(object obj)
        //{
        //    try
        //    {
        //        if (obj != null && obj.ToString() != "")
        //        {
        //            return ConvertObjToDecimal(obj.ToString());

        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
        #endregion

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public decimal Round(decimal d, int decimals)
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

        #region 获取不同费别的费用明细
        /// <summary>
        /// 获取不同费别的费用明细
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientFeeDetByPayType(string RegID, string PayTypeID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.pchargeid_chr, a.patientid_chr, a.registerid_chr, a.active_dat,
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
                                   d.deptname_vchr as curarea, e.itemcode_vchr, e.itemspec_vchr, e.insuranceid_chr as ybcode, 
                                   (case a.pstatus_int
                                       when 3
                                          then a.discount_dec
                                       when 4
                                          then a.discount_dec
                                       else c.precent_dec
                                    end
                                  ) as precent_dec, round(a.amount_dec * a.unitprice_dec, 2) as totalmony
                             from t_opr_bih_patientcharge a,
                                  t_opr_bih_register b,
                                  t_aid_inschargeitem c,
                                  t_bse_deptdesc d,                                           
                                  t_bse_chargeitem e                                     
                            where a.registerid_chr = b.registerid_chr 
                              and a.chargeitemid_chr = c.itemid_chr                               
                              and a.curareaid_chr = d.deptid_chr(+)
                              and a.chargeitemid_chr = e.itemid_chr(+)
                              and a.status_int = 1 
                              and a.pstatus_int <> 0 
                              and a.chargeactive_dat is not null 
                              and a.registerid_chr = ?  
                              and c.copayid_chr = ? 
                         order by a.chargeitemname_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = RegID;
                ParamArr[1].Value = PayTypeID;
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

        #region 费用明细对应之诊疗项目
        /// <summary>
        /// 费用明细对应之诊疗项目
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="ActiveType">生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费;888=费用状态分类;999=全部}</param>
        /// <param name="Pstatus"></param>
        /// <param name="AreaID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeeDiagItem(string RegID, int ActiveType, string Pstatus, string AreaID, string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (ActiveType == 999)
                {
                    if (AreaID == "00")
                    {
                        SQL = @"select distinct to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                a.name_vchr as ordername, b.orderid_chr as orderid, b.orderexecid_chr as orderexecid,
                                                c.ordercateid_chr as ordercateid, c.pycode_chr as orderpycode, '#1' as orderflag 
                                           from t_opr_bih_order a,
                                                t_opr_bih_patientcharge b,
                                                t_bse_bih_orderdic c
                                          where a.orderid_chr = b.orderid_chr
                                            and a.orderdicid_chr = c.orderdicid_chr(+) 
                                            and (b.orderexectype_int in (1, 2, 3, 4)) 
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0
                                            and b.registerid_chr = ? 
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                union all
                                select distinct to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                a.orderdicname_vchr as ordername, b.orderid_chr as orderid, b.attachorderid_vchr as orderexecid,
                                                c.ordercateid_chr as ordercateid, c.pycode_chr as orderpycode, '#2' as orderflag 
                                           from t_opr_bih_orderdic a, 
                                                t_opr_bih_patientcharge b,
                                                t_bse_bih_orderdic c
                                          where a.orderid_chr = b.orderid_chr
                                            and a.orderdicid_chr = c.orderdicid_chr
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0 
                                            and b.attachorderid_vchr is not null    
                                            and b.registerid_chr = ? 
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                union all
                                select to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                b.chargeitemname_chr as ordername, b.orderid_chr as orderid, b.pchargeid_chr as orderexecid,
                                                '&' as ordercateid, c.itempycode_chr as orderpycode, '#3' as orderflag 
                                           from t_opr_bih_patientcharge b,
  	                                            t_bse_chargeitem c
                                          where b.chargeitemid_chr = c.itemid_chr(+)
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0 
                                            and b.amount_dec > 0 
                                            and b.orderexecid_chr is null
                                            and b.attachorderid_vchr is null
                                            and b.registerid_chr = ? 
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                        objHRPSvc.CreateDatabaseParameter(9, out ParamArr);
                        ParamArr[0].Value = RegID;
                        ParamArr[1].Value = BeginDate + " 00:00:00";
                        ParamArr[2].Value = EndDate + " 23:59:59";
                        ParamArr[3].Value = RegID;
                        ParamArr[4].Value = BeginDate + " 00:00:00";
                        ParamArr[5].Value = EndDate + " 23:59:59";
                        ParamArr[6].Value = RegID;
                        ParamArr[7].Value = BeginDate + " 00:00:00";
                        ParamArr[8].Value = EndDate + " 23:59:59";
                    }
                    else
                    {
                        SQL = @"select distinct to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                a.name_vchr as ordername, b.orderid_chr as orderid, b.orderexecid_chr as orderexecid,
                                                c.ordercateid_chr as ordercateid, c.pycode_chr as orderpycode, '#1' as orderflag 
                                           from t_opr_bih_order a,
                                                t_opr_bih_patientcharge b,
                                                t_bse_bih_orderdic c
                                          where a.orderid_chr = b.orderid_chr
                                            and a.orderdicid_chr = c.orderdicid_chr(+) 
                                            and (b.orderexectype_int in (1, 2, 3, 4)) 
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0
                                            and b.registerid_chr = ? 
                                            and b.curareaid_chr = ?
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                union all
                                select distinct to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                a.orderdicname_vchr as ordername, b.orderid_chr as orderid, b.attachorderid_vchr as orderexecid,
                                                c.ordercateid_chr as ordercateid, c.pycode_chr as orderpycode, '#2' as orderflag 
                                           from t_opr_bih_orderdic a,
                                                t_opr_bih_patientcharge b,
                                                t_bse_bih_orderdic c
                                          where a.orderid_chr = b.orderid_chr
                                            and a.orderdicid_chr = c.orderdicid_chr
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0 
                                            and b.attachorderid_vchr is not null 
                                            and b.registerid_chr = ? 
                                            and b.curareaid_chr = ?
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))
                                union all
                                select to_char (b.chargeactive_dat, 'yyyymmdd') as orderdate, b.orderexectype_int as ordertype,
                                                b.chargeitemname_chr as ordername, b.orderid_chr as orderid, b.pchargeid_chr as orderexecid,
                                                '&' as ordercateid, c.itempycode_chr as orderpycode, '#3' as orderflag 
                                           from t_opr_bih_patientcharge b,
  	                                            t_bse_chargeitem c
                                          where b.chargeitemid_chr = c.itemid_chr(+)
                                            and b.status_int = 1
                                            and b.pstatus_int <> 0 
                                            and b.amount_dec > 0 
                                            and b.orderexecid_chr is null
                                            and b.attachorderid_vchr is null
                                            and b.registerid_chr = ? 
                                            and b.curareaid_chr = ?
                                            and (b.chargeactive_dat 
                                                        between to_date(?, 'yyyy-mm-dd hh24:mi:ss')
                                                            and to_date(?, 'yyyy-mm-dd hh24:mi:ss'))";

                        objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
                        ParamArr[0].Value = RegID;
                        ParamArr[1].Value = AreaID;
                        ParamArr[2].Value = BeginDate + " 00:00:00";
                        ParamArr[3].Value = EndDate + " 23:59:59";
                        ParamArr[4].Value = RegID;
                        ParamArr[5].Value = AreaID;
                        ParamArr[6].Value = BeginDate + " 00:00:00";
                        ParamArr[7].Value = EndDate + " 23:59:59";
                        ParamArr[8].Value = RegID;
                        ParamArr[9].Value = AreaID;
                        ParamArr[10].Value = BeginDate + " 00:00:00";
                        ParamArr[11].Value = EndDate + " 23:59:59";
                    }
                }

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

        #region 根据费用明细ID查找费用信息
        /// <summary>
        /// 根据费用明细ID查找费用信息
        /// </summary>
        /// <param name="DiagArr"></param>
        /// <param name="dtNormal"></param>
        /// <param name="dtRefundment"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeeItemByActiveType(ArrayList DiagArr, out DataTable dtNormal, out DataTable dtRefundment)
        {
            long lngRes = 0;
            string strPChargeID = "";
            string SQL = "";

            for (int i = 0; i < DiagArr.Count; i++)
            {
                strPChargeID += "'" + ((clsParmDiagItem_VO)DiagArr[i]).PchargeID + "',";
            }
            strPChargeID = strPChargeID.Substring(0, strPChargeID.Length - 1);

            dtNormal = new DataTable();
            dtRefundment = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = @"select a.pchargeid_chr, a.chargeitemid_chr, a.chargeitemname_chr,
                               a.amount_dec, a.pchargeidorg_chr, b.itemcode_vchr, a.unitprice_dec,a.totaldiffcostmoney_dec 
                          from t_opr_bih_patientcharge a,
                               t_bse_chargeitem b  
                         where a.chargeitemid_chr = b.itemid_chr(+)
                           and a.pchargeid_chr in (" + strPChargeID + ")";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtNormal);

                SQL = @"select a.pchargeid_chr, a.chargeitemid_chr, a.chargeitemname_chr,
                               a.amount_dec, a.pchargeidorg_chr, b.itemcode_vchr, a.unitprice_dec,a.totaldiffcostmoney_dec 
                          from t_opr_bih_patientcharge a,
                               t_bse_chargeitem b  
                         where a.chargeitemid_chr = b.itemid_chr(+)
                           and a.pchargeidorg_chr in (" + strPChargeID + @") and a.amount_dec < 0";

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRefundment);

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

        #region 按科室类型获取病人费用分类
        /// <summary>
        /// 按科室类型获取病人费用分类
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DeptClass">1 执行科室 2 开单科室 3 所在病区</param>
        /// <param name="Status">0 未呆帐结算 1 已呆帐结算</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeeCatByDeptClass(string RegID, int DeptClass, int Status, out DataTable dt)
        {
            long lngRes = 0;
            string ChargeNo = "";
            string SQL = "";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (Status == 1)
                {
                    SQL = @"select a.chargeno_chr from t_opr_bih_charge a where a.class_int = 3 and a.registerid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;

                    DataTable dt1 = new DataTable();

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, ParamArr);
                    if (dt1.Rows.Count > 0)
                    {
                        ChargeNo = dt1.Rows[0][0].ToString();
                        if (ChargeNo.Trim() == "")
                        {
                            Status = 0;
                        }
                        else
                        {
                            if (DeptClass == 1)
                            {
                                SQL = @"select  a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                sum(a.totalmoney_dec) as catsum
                                          from  t_opr_bih_chargeitementry a, 
                                                (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                t_bse_deptdesc c
                                          where a.calccateid_chr = b.typeid_chr(+)
                                            and a.clacarea_chr = c.deptid_chr(+)
                                            and a.chargeno_chr = ?                  
                                            and a.registerid_chr = ? 
                                       group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                       order by a.clacarea_chr, a.calccateid_chr";
                            }
                            else if (DeptClass == 2)
                            {
                                SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_chargeitementry a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.createarea_chr = c.deptid_chr(+)
                                             and a.chargeno_chr = ?
                                             and a.registerid_chr = ? 
                                        group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.createarea_chr, a.calccateid_chr";
                            }
                            else if (DeptClass == 3)
                            {
                                SQL = @"select   a.curareaid_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_patientcharge a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.curareaid_chr = c.deptid_chr(+)
                                             and a.chargeno_chr = ?                           
                                             and a.registerid_chr = ? 
                                        group by a.curareaid_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.curareaid_chr, a.calccateid_chr";
                            }

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = ChargeNo;
                            ParamArr[1].Value = RegID;
                        }
                    }
                    else
                    {
                        Status = 0;
                    }
                }

                if (Status == 0)
                {
                    if (DeptClass == 1)
                    {
                        SQL = @"select   a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.clacarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                     and a.chargeactive_dat is not null                            
                                     and a.registerid_chr = ? 
                                group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.clacarea_chr, a.calccateid_chr";
                    }
                    else if (DeptClass == 2)
                    {
                        SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.createarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                     and a.chargeactive_dat is not null
                                     and a.registerid_chr = ? 
                                group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.createarea_chr, a.calccateid_chr";
                    }
                    else if (DeptClass == 3)
                    {
                        SQL = @"select   a.curareaid_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.curareaid_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and (a.pstatus_int = 1 or a.pstatus_int = 2)
                                     and a.chargeactive_dat is not null                            
                                     and a.registerid_chr = ? 
                                group by a.curareaid_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.curareaid_chr, a.calccateid_chr";
                    }

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;
                }

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

        #region 按科室类型获取病人费用分类母婴合并结算使用 by yibing.zheng 09-07-04

        /// <summary>
        /// 按科室类型获取病人费用分类母婴合并结算使用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DeptClass">1 执行科室 2 开单科室 3 所在病区</param>
        /// <param name="Status">0 未呆帐结算 1 已呆帐结算</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeeCatByDeptClassForMortherBaby(string RegID, int DeptClass, int Status, out DataTable dt)
        {
            long lngRes = 0;
            string ChargeNo = "";
            string SQL = "";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                #region 成人费用
                if (Status == 1)
                {
                    SQL = @"select a.chargeno_chr from t_opr_bih_charge a where a.class_int = 3 and a.registerid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;

                    DataTable dt1 = new DataTable();

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, ParamArr);
                    if (dt1.Rows.Count > 0)
                    {
                        ChargeNo = dt1.Rows[0][0].ToString();
                        if (ChargeNo.Trim() == "")
                        {
                            Status = 0;
                        }
                        else
                        {
                            if (DeptClass == 1)
                            {
                                SQL = @"select  a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                sum(a.totalmoney_dec) as catsum
                                          from  t_opr_bih_chargeitementry a, 
                                                (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                t_bse_deptdesc c
                                          where a.calccateid_chr = b.typeid_chr(+)
                                            and a.clacarea_chr = c.deptid_chr(+)
                                            and a.chargeno_chr = ?                  
                                            and a.registerid_chr = ? 
                                       group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                       order by a.clacarea_chr, a.calccateid_chr";
                            }
                            else if (DeptClass == 2)
                            {
                                SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_chargeitementry a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.createarea_chr = c.deptid_chr(+)
                                             and a.chargeno_chr = ?
                                             and a.registerid_chr = ? 
                                        group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.createarea_chr, a.calccateid_chr";
                            }
                            else if (DeptClass == 3)
                            {
                                SQL = @"select   a.curareaid_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_patientcharge a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.curareaid_chr = c.deptid_chr(+)
                                             and a.chargeno_chr = ?                           
                                             and a.registerid_chr = ? 
                                        group by a.curareaid_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.curareaid_chr, a.calccateid_chr";
                            }

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = ChargeNo;
                            ParamArr[1].Value = RegID;
                        }
                    }
                    else
                    {
                        Status = 0;
                    }
                }

                if (Status == 0)
                {
                    if (DeptClass == 1)
                    {
                        SQL = @"select   a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.clacarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and a.pstatus_int in (1,2)
                                     and a.chargeactive_dat is not null                            
                                     and a.registerid_chr = ? 
                                group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.clacarea_chr, a.calccateid_chr";
                    }
                    else if (DeptClass == 2)
                    {
                        SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.createarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and a.pstatus_int in (1,2)
                                     and a.chargeactive_dat is not null
                                     and a.registerid_chr = ? 
                                group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.createarea_chr, a.calccateid_chr";
                    }
                    else if (DeptClass == 3)
                    {
                        SQL = @"select   a.curareaid_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.amount_dec * a.unitprice_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.curareaid_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and a.pstatus_int in (1,2)
                                     and a.chargeactive_dat is not null                            
                                     and a.registerid_chr = ? 
                                group by a.curareaid_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.curareaid_chr, a.calccateid_chr";
                    }

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RegID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                #endregion

                #region 判断是否有婴儿费用
                SQL = @"select t.registerid_chr
  from t_opr_bih_register t
 where t.pstatus_int in (2,3) 
 and t.relateregisterid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;
                DataTable dtbBagyRegisterId = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbBagyRegisterId, ParamArr);
                int intRowCount = dtbBagyRegisterId.Rows.Count;
                string[] strBabyRegisterIdArr = new string[intRowCount];
                if (lngRes > 0 && intRowCount > 0)
                {
                    string strChargeNoRegId = null, strNOChargeNoRegId = null, strChargeNo = null;
                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        strBabyRegisterIdArr[i1] = "'" + dtbBagyRegisterId.Rows[i1]["registerid_chr"].ToString() + "',";
                        strNOChargeNoRegId += strBabyRegisterIdArr[i1];

                    }
                    strNOChargeNoRegId = strNOChargeNoRegId.Remove(strNOChargeNoRegId.Length - 1);

                    DataTable dtbBabyCharge = new DataTable();
                    #region 拿取婴儿费用
                    if (Status == 1)
                    {
                        DataTable dtbTemp = new DataTable();

                        strNOChargeNoRegId = null;
                        //判断婴儿是否有发票号，已呆账结算，有发票号的婴儿就往下，没发票号的婴儿另执行
                        for (int i2 = 0; i2 < strBabyRegisterIdArr.Length; i2++)
                        {
                            SQL = @"select a.chargeno_chr
                                  from t_opr_bih_charge a
                                 where a.class_int = 3
                                   and a.registerid_chr =?
                                order by a.operdate_dat desc";
                            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[0].Value = strBabyRegisterIdArr[i2];
                            lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbTemp, ParamArr);
                            if (lngRes > 0 && dtbTemp.Rows.Count > 0)
                            {
                                strChargeNoRegId += strBabyRegisterIdArr[i2];
                                strChargeNo += "'" + dtbTemp.Rows[0][0].ToString() + "',";
                            }
                            else
                            {
                                strNOChargeNoRegId += strBabyRegisterIdArr[i2];
                            }

                        }
                        if (strChargeNoRegId != null)
                        {
                            strChargeNoRegId = strChargeNoRegId.Remove(strChargeNoRegId.Length - 1);
                            strChargeNo = strChargeNo.Remove(strChargeNo.Length - 1);
                        }
                        if (strNOChargeNoRegId != null)
                        {
                            strNOChargeNoRegId = strNOChargeNoRegId.Remove(strNOChargeNoRegId.Length - 1);
                        }
                        if (!string.IsNullOrEmpty(strChargeNo))
                        {
                            //ChargeNo = dtbTemp.Rows[0][0].ToString();

                            if (strChargeNo.Trim() == "")
                            {
                                Status = 0;
                            }
                            else
                            {
                                if (DeptClass == 1)
                                {
                                    SQL = @"select  a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                sum(a.totalmoney_dec) as catsum
                                          from  t_opr_bih_chargeitementry a, 
                                                (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                t_bse_deptdesc c
                                          where a.calccateid_chr = b.typeid_chr(+)
                                            and a.clacarea_chr = c.deptid_chr(+)
                                            and a.chargeno_chr in ([strChargeNo])                 
                                            and a.registerid_chr in ([babyRegisterId])
                                       group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                       order by a.clacarea_chr, a.calccateid_chr";
                                }
                                else if (DeptClass == 2)
                                {
                                    SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_chargeitementry a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.createarea_chr = c.deptid_chr(+)
                                             and a.chargeno_chr in ([strChargeNo])
                                             and a.registerid_chr in ([babyRegisterId]) 
                                        group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.createarea_chr, a.calccateid_chr";
                                }
                                else if (DeptClass == 3)
                                {
                                    SQL = @"select   a.curareaid_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                                 sum(a.totalmoney_dec) as catsum
                                            from t_opr_bih_chargeitementry a, 
                                                 (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                                 t_bse_deptdesc c
                                           where a.calccateid_chr = b.typeid_chr(+)
                                             and a.curareaid_chr = c.deptid_chr(+)
                                             and a.chargeno_chr in ([strChargeNo])                           
                                             and a.registerid_chr in ([babyRegisterId])
                                        group by a.curareaid_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                        order by a.curareaid_chr, a.calccateid_chr";
                                }

                                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                                ParamArr[0].Value = ChargeNo;
                                SQL = SQL.Replace("[strChargeNo]", strChargeNo);
                                SQL = SQL.Replace("[babyRegisterId]", strChargeNoRegId);
                                DataTable dtbTemp2 = null;
                                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtbTemp2);
                                if (dtbTemp.Rows.Count > 0)
                                {
                                    dtbBabyCharge = dtbTemp2;
                                    dtbTemp2 = null;
                                }

                            }
                        }
                        else
                        {
                            Status = 0;
                        }
                        if (!string.IsNullOrEmpty(strNOChargeNoRegId))
                        {
                            Status = 0;
                        }
                        dtbTemp.Dispose();
                        dtbTemp = null;
                    }

                    if (Status == 0)
                    {
                        if (DeptClass == 1)
                        {
                            SQL = @"select   a.clacarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.totalmoney_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.clacarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and a.pstatus_int in (1,2)
                                     and a.chargeactive_dat is not null                            
                                     and a.registerid_chr in ([babyRegisterId]) 
                                group by a.clacarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.clacarea_chr, a.calccateid_chr";
                        }
                        else if (DeptClass == 2)
                        {
                            SQL = @"select   a.createarea_chr as deptid, c.deptname_vchr, a.calccateid_chr, b.typename_vchr,
                                         sum (round (a.totalmoney_dec, 2)) as catsum
                                    from t_opr_bih_patientcharge a, 
                                         (select typeid_chr, typename_vchr from t_bse_chargeitemextype where flag_int = 3) b,
                                         t_bse_deptdesc c
                                   where a.calccateid_chr = b.typeid_chr(+)
                                     and a.createarea_chr = c.deptid_chr(+)
                                     and a.status_int = 1
                                     and  a.pstatus_int in (1,2)
                                     and a.chargeactive_dat is not null
                                     and a.registerid_chr in ([babyRegisterId]) 
                                group by a.createarea_chr, c.deptname_vchr, a.calccateid_chr, b.typename_vchr
                                order by a.createarea_chr, a.calccateid_chr";
                        }
                        else if (DeptClass == 3)
                        {
                            SQL = @"select a.curareaid_chr as deptid,
                                       c.deptname_vchr,
                                       a.calccateid_chr,
                                       b.typename_vchr,
                                       sum(round(a.totalmoney_dec, 2)) as catsum
                                  from t_opr_bih_patientcharge a,
                                       (select typeid_chr, typename_vchr
                                          from t_bse_chargeitemextype
                                         where flag_int = 3) b,
                                       t_bse_deptdesc c
                                 where a.calccateid_chr = b.typeid_chr(+)
                                   and a.curareaid_chr = c.deptid_chr(+)
                                   and a.status_int = 1
                                   and a.pstatus_int in (1,2)
                                   and a.chargeactive_dat is not null
                                   and a.registerid_chr in ([babyRegisterId])
                                 group by a.curareaid_chr,
                                          c.deptname_vchr,
                                          a.calccateid_chr,
                                          b.typename_vchr
                                 order by a.curareaid_chr, a.calccateid_chr";
                        }

                        SQL = SQL.Replace("[babyRegisterId]", strNOChargeNoRegId);
                        DataTable dtbTemp2 = null;
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtbTemp2);
                        if (dtbTemp2.Rows.Count > 0)
                        {
                            if (dtbBabyCharge.Rows.Count > 0)
                            {
                                dtbBabyCharge.Merge(dtbTemp2);
                            }
                            else
                            {
                                dtbBabyCharge = dtbTemp2;
                            }
                            dtbTemp2 = null;
                        }
                    }

                    // lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbBabyCharge, ParamArr);
                    //lngRes=objHRPSvc.lngGetDataTableWithoutParameters(SQL,ref dtbBabyCharge);
                    if (lngRes > 0 && dtbBabyCharge.Rows.Count > 0)
                    {
                        //string strTmp = dt.Compute("sum(catsum)", "").ToString();
                        //strTmp = dtbBabyCharge.Compute("sum(catsum)", "").ToString();
                        string[] sarr = new string[5];
                        sarr[1] = "婴儿费用";
                        dt.Rows.Add(sarr);
                        dt.Merge(dtbBabyCharge);

                        //strTmp = dt.Compute("sum(catsum)", "").ToString();

                        //clsFieldInfo[] colSelectFields = new clsFieldInfo[5];
                        //colSelectFields[0] = new clsFieldInfo();
                        //colSelectFields[0].strFieldName = "catsum";
                        //colSelectFields[0].strFieldAlias = "catsum";
                        //colSelectFields[0].strAggregate = "sum";
                        //colSelectFields[0].strRelationName = "";
                        //colSelectFields[1] = new clsFieldInfo();
                        //colSelectFields[1].strFieldName = "deptid";
                        //colSelectFields[1].strFieldAlias = "deptid";
                        //colSelectFields[1].strAggregate = "";
                        //colSelectFields[1].strRelationName = "";
                        //colSelectFields[2] = new clsFieldInfo();
                        //colSelectFields[2].strFieldName = "deptname_vchr";
                        //colSelectFields[2].strFieldAlias = "deptname_vchr";
                        //colSelectFields[2].strAggregate = "";
                        //colSelectFields[2].strRelationName = "";
                        //colSelectFields[3] = new clsFieldInfo();
                        //colSelectFields[3].strFieldName = "calccateid_chr";
                        //colSelectFields[3].strFieldAlias = "calccateid_chr";
                        //colSelectFields[3].strAggregate = "";
                        //colSelectFields[3].strRelationName = "";
                        //colSelectFields[4] = new clsFieldInfo();
                        //colSelectFields[4].strFieldName = "typename_vchr";
                        //colSelectFields[4].strFieldAlias = "typename_vchr";
                        //colSelectFields[4].strAggregate = "";
                        //colSelectFields[4].strRelationName = "";
                        //clsFieldInfo[] colGroupByFields = new clsFieldInfo[4];
                        //colGroupByFields[0] = new clsFieldInfo();
                        //colGroupByFields[0].strFieldName = "deptid";
                        //colGroupByFields[0].strFieldAlias = "deptid";
                        //colGroupByFields[0].strAggregate = "";
                        //colGroupByFields[0].strRelationName = "";
                        //colGroupByFields[1] = new clsFieldInfo();
                        //colGroupByFields[1].strFieldName = "deptname_vchr";
                        //colGroupByFields[1].strFieldAlias = "deptname_vchr";
                        //colGroupByFields[1].strAggregate = "";
                        //colGroupByFields[1].strRelationName = "";
                        //colGroupByFields[2] = new clsFieldInfo();
                        //colGroupByFields[2].strFieldName = "calccateid_chr";
                        //colGroupByFields[2].strFieldAlias = "calccateid_chr";
                        //colGroupByFields[2].strAggregate = "";
                        //colGroupByFields[2].strRelationName = "";
                        //colGroupByFields[3] = new clsFieldInfo();
                        //colGroupByFields[3].strFieldName = "typename_vchr";
                        //colGroupByFields[3].strFieldAlias = "typename_vchr";
                        //colGroupByFields[3].strAggregate = "";
                        //colGroupByFields[3].strRelationName = "";
                        //DataTable dtbNewCharge = null;
                        //clsDataSetHelper objDSHelper = new clsDataSetHelper();
                        //objDSHelper.CreateGroupByTable("MatherBabyCharge", dt, colSelectFields, ref dtbNewCharge);
                        //strTmp = dtbNewCharge.Compute("sum(catsum)", "").ToString();

                        //objDSHelper.InsertGroupByInto(ref dtbNewCharge, dt, colSelectFields, "", colGroupByFields);
                        //dt = null;

                        //dt = dtbNewCharge;


                    }
                    dtbBabyCharge.Dispose();
                    dtbBabyCharge = null;
                    #endregion
                }
                dtbBagyRegisterId.Dispose();
                dtbBagyRegisterId = null;

                #endregion


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

        #region 获取呆帐病人未清费用
        /// <summary>
        /// 获取呆帐病人未清费用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBadChargeFeeInfo(string RegID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select a.chargeitemid_chr, a.invcateid_chr, a.amount_dec, a.unitprice_dec 
                             from t_opr_bih_patientcharge a 
                            where a.status_int = 1
                              and (a.pstatus_int = 1 or a.pstatus_int = 2)
                              and a.chargeactive_dat is not null                            
                              and a.registerid_chr = ? ";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

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
        /// 获取呆帐病人未清费用(母婴合并结算合用) by yibin.zheng 09-07
        /// </summary>
        /// <param name="RegID">病人ID</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBadChargeFeeInfoMotherBaby(string RegID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select t.registerid_chr
  from t_opr_bih_register t
 where t.pstatus_int in (2,3) 
   and t.relateregisterid_chr = ?
";

            DataTable dtbBaby = null;
            dt = new DataTable();
            clsHRPTableService objHRPSvc = null;
            try
            {

                objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtbBaby, ParamArr);
                string strBabyRegId = "";
                if (lngRes > 0 && dtbBaby.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbBaby.Rows.Count; i++)
                    {
                        strBabyRegId += "'" + dtbBaby.Rows[i][0].ToString() + "',";
                    }
                    strBabyRegId = strBabyRegId.Remove(strBabyRegId.Length - 1);
                }
                if (strBabyRegId != "")
                {
                    RegID = "'" + RegID + "'," + strBabyRegId;
                }
                else
                {
                    RegID = "'" + RegID + "'";
                }
                strBabyRegId = null;
                SQL = @"select a.chargeitemid_chr, a.invcateid_chr, a.amount_dec, a.unitprice_dec 
                             from t_opr_bih_patientcharge a 
                            where a.status_int = 1
                              and a.pstatus_int in (1,2)
                              and a.chargeactive_dat is not null                            
                              and a.registerid_chr in ([RegID]) ";
                SQL = SQL.Replace("[RegID]", RegID);

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                SQL = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
                dtbBaby.Dispose();
                dtbBaby = null;

            }
            return lngRes;
        }
        #endregion

        #region 呆帐结算
        /// <summary>
        /// 呆帐结算
        /// </summary>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeCatArr"></param>
        /// <param name="FactTotalMoney">实际未结、未清总金额</param>
        /// <param name="FactPreMoney">实际分摊总金额</param>
        /// <param name="DiffValDeptID">差值项科室ID</param>
        /// <param name="DiffValCatID">差值项核算分类ID</param>
        /// <param name="IsHavePrepayMoney">是否有预交金 (true 有 false 无)</param>
        /// <param name="ChargeNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngBadCharge(clsBihCharge_VO Charge_VO, ArrayList ChargeCatArr, clsBihInvoice_VO Invoice_VO, ArrayList InvoCatArr, ArrayList PaymentArr, decimal FactTotalMoney, decimal FactPreMoney, string DiffValDeptID, string DiffValCatID, bool IsHavePrepayMoney, out string ChargeNo)
        {
            long lngRes = 0, lngAffects = 0;
            //执行SQL
            string SQL = "";
            //根据时间生成结算号
            ChargeNo = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //入院登记号
                string RegID = Charge_VO.RegisterID;

                if (IsHavePrepayMoney)
                {
                    //结算表
                    SQL = @"insert into t_opr_bih_charge(chargeno_chr, registerid_chr, paytypeid_chr, patienttype_chr, totalsum_mny, sbsum_mny, acctsum_mny, operemp_chr, 
                                                     operdate_dat, recflag_int, recemp_chr, recdate_dat, class_int, type_int, status_int, billno_int, areaid_chr) values (  
                                                     ?, ?, ?, ?, ?, ?, ?, ?, sysdate, 0, null, null, ?, 1, 1, ?, ?)";

                    objHRPSvc.CreateDatabaseParameter(11, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = Charge_VO.RegisterID;
                    ParamArr[2].Value = Charge_VO.PayTypeID;
                    ParamArr[3].Value = Charge_VO.PatientType;
                    ParamArr[4].Value = Charge_VO.TotalSum;
                    ParamArr[5].Value = Charge_VO.SbSum;
                    ParamArr[6].Value = Charge_VO.AcctSum;
                    ParamArr[7].Value = Charge_VO.OperEmp;
                    ParamArr[8].Value = 3;
                    ParamArr[9].Value = Charge_VO.BillNO;
                    ParamArr[10].Value = Charge_VO.CurrAreaID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //结算分类表
                    for (int i = 0; i < ChargeCatArr.Count; i++)
                    {
                        clsBihChargeCat_VO ChargeCat_VO = ChargeCatArr[i] as clsBihChargeCat_VO;

                        if (ChargeCat_VO.TotalSum == 0)
                        {
                            continue;
                        }

                        SQL = @"insert into t_opr_bih_chargecat(chargeno_chr, deptid_chr, itemcatid_chr, totalsum_mny, acctsum_mny) values(  
                                                            ?, ?, ?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = ChargeCat_VO.DeptID;
                        ParamArr[2].Value = ChargeCat_VO.ItemCatID;
                        ParamArr[3].Value = ChargeCat_VO.TotalSum;
                        ParamArr[4].Value = ChargeCat_VO.AcctSum;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }

                    //发票号(现有业务默认一次结算对应一张发票)
                    string Invono = Invoice_VO.InvoiceNo;

                    //结算发票对应表
                    SQL = "insert into t_opr_bih_chargedefinv(chargeno_chr, invoiceno_vchr) values(?, ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = Invono;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //发票表
                    SQL = @"insert into t_opr_bih_invoice2(invoiceno_vchr, invdate_dat, totalsum_mny, sbsum_mny, acctsum_mny, status_int, confirmemp_chr, confirmdate_dat, split_int) values(  
                                                       ?, sysdate, ?, ?, ?, ?, null, null, ?)";

                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = Invoice_VO.InvoiceNo;
                    ParamArr[1].Value = Invoice_VO.TotalSum;
                    ParamArr[2].Value = Invoice_VO.SbSum;
                    ParamArr[3].Value = Invoice_VO.AcctSum;
                    ParamArr[4].Value = Invoice_VO.Status;
                    ParamArr[5].Value = Invoice_VO.Split;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //发票明细表
                    for (int i = 0; i < InvoCatArr.Count; i++)
                    {
                        clsBihInvoiceCat_VO InvoiceCat_VO = InvoCatArr[i] as clsBihInvoiceCat_VO;

                        if (InvoiceCat_VO.TotalSum == 0)
                        {
                            continue;
                        }

                        SQL = "insert into t_opr_bih_invoice2de(invoiceno_vchr, itemcatid_chr, totalsum_mny, acctsum_mny) values(?, ?, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                        ParamArr[0].Value = Invono;
                        ParamArr[1].Value = InvoiceCat_VO.ItemCatID;
                        ParamArr[2].Value = InvoiceCat_VO.TotalSum;
                        ParamArr[3].Value = InvoiceCat_VO.AcctSum;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }

                    //支付表
                    for (int i = 0; i < PaymentArr.Count; i++)
                    {
                        clsBihPayment_VO Payment_VO = PaymentArr[i] as clsBihPayment_VO;

                        SQL = @"insert into t_opr_bih_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny) values(  
                                                          ?, ?, null, null, ?, ?)";

                        objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = Payment_VO.PayType;
                        ParamArr[2].Value = Payment_VO.PaySum;
                        ParamArr[3].Value = Payment_VO.RefuSum;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }

                    //生成结算项目明细
                    SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   ?,
                                                                   sysdate,
                                                                   pchargeid_chr,
                                                                   registerid_chr,
                                                                   createarea_chr,  
                                                                   clacarea_chr,
                                                                   curareaid_chr,
                                                                   curbedid_chr,
                                                                   doctorid_chr,
                                                                   doctorgroupid_chr,
                                                                   calccateid_chr,
                                                                   invcateid_chr,
                                                                   chargeitemid_chr,
                                                                   chargeitemname_chr,
                                                                   unit_vchr,
                                                                   spec_vchr,
                                                                   unitprice_dec,
                                                                   amount_dec,
                                                                   round(unitprice_dec * amount_dec * " + FactPreMoney + "/" + FactTotalMoney + @", 2),
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   chargedoctorid_chr,
                                                                   chargedoctorgroupid_chr 
                                                              from t_opr_bih_patientcharge 
                                                             where status_int = 1
                                                               and (pstatus_int = 1 or pstatus_int = 2)
                                                               and chargeactive_dat is not null
                                                               and registerid_chr = ? ";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    //补差值
                    if (DiffValCatID != "")
                    {
                        SQL = @"select sum(totalmoney_dec) from t_opr_bih_chargeitementry where chargeno_chr = ? and registerid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = ChargeNo;
                        ParamArr[1].Value = RegID;

                        DataTable dt = new DataTable();

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                        if (lngRes > 0 && dt.Rows.Count == 1)
                        {
                            decimal val = FactPreMoney - Convert.ToDecimal(dt.Rows[0][0].ToString());

                            SQL = @"update t_opr_bih_chargeitementry 
                                   set totalmoney_dec = " + val + @" + totalmoney_dec
                                 where chargeno_chr = ? 
                                   and registerid_chr = ? 
                                   and clacarea_chr = ?  
                                   and calccateid_chr = ? 
                                   and rownum = 1 ";

                            objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                            ParamArr[0].Value = ChargeNo;
                            ParamArr[1].Value = RegID;
                            ParamArr[2].Value = DiffValDeptID;
                            ParamArr[3].Value = DiffValCatID;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
                    }

                    #region 婴儿结算生成项目明细处理
                    if (Charge_VO.m_objBabyInfoVo != null)
                    {
                        int intBabyCount = Charge_VO.m_objBabyInfoVo.Length;
                        string strBabyRegisterId = "";
                        for (int i1 = 0; i1 < intBabyCount; i1++)
                        {
                            strBabyRegisterId = Charge_VO.m_objBabyInfoVo[i1].RegisterID;
                            SQL = @"insert into t_opr_bih_chargeitementry (sid_int, chargeno_chr, operdate_dat, pchargeid_chr, registerid_chr, createarea_chr, clacarea_chr, curareaid_chr, 
                                                                   curbedid_chr, doctorid_chr, doctorgroupid_chr, calccateid_chr, invcateid_chr, chargeitemid_chr, chargeitemname_chr, 
                                                                   unit_vchr, spec_vchr, unitprice_dec, amount_dec, totalmoney_dec, discount_dec, newdiscount_dec, acctmoney_dec, 
                                                                   chargedoctorid_chr, chargedoctorgroupid_chr)
                                                            select seq_chargeitementry.NEXTVAL,
                                                                   ?,
                                                                   sysdate,
                                                                   pchargeid_chr,
                                                                   registerid_chr,
                                                                   createarea_chr,  
                                                                   clacarea_chr,
                                                                   curareaid_chr,
                                                                   curbedid_chr,
                                                                   doctorid_chr,
                                                                   doctorgroupid_chr,
                                                                   calccateid_chr,
                                                                   invcateid_chr,
                                                                   chargeitemid_chr,
                                                                   chargeitemname_chr,
                                                                   unit_vchr,
                                                                   spec_vchr,
                                                                   unitprice_dec,
                                                                   amount_dec,
                                                                   round(unitprice_dec * amount_dec * " + FactPreMoney + "/" + FactTotalMoney + @", 2),
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   chargedoctorid_chr,
                                                                   chargedoctorgroupid_chr 
                                                              from t_opr_bih_patientcharge 
                                                             where status_int = 1
                                                               and (pstatus_int = 1 or pstatus_int = 2)
                                                               and chargeactive_dat is not null
                                                               and registerid_chr = ? ";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = ChargeNo;
                            ParamArr[1].Value = strBabyRegisterId;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                            //补差值
                            if (DiffValCatID != "")
                            {
                                SQL = @"select sum(totalmoney_dec) from t_opr_bih_chargeitementry where chargeno_chr = ? and registerid_chr = ?";
                                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                                ParamArr[0].Value = ChargeNo;
                                ParamArr[1].Value = strBabyRegisterId;

                                DataTable dt = new DataTable();

                                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                                if (lngRes > 0 && dt.Rows.Count == 1)
                                {
                                    decimal val = FactPreMoney - Convert.ToDecimal(dt.Rows[0][0].ToString());

                                    SQL = @"update t_opr_bih_chargeitementry 
                                   set totalmoney_dec = " + val + @" + totalmoney_dec
                                 where chargeno_chr = ? 
                                   and registerid_chr = ? 
                                   and clacarea_chr = ?  
                                   and calccateid_chr = ? 
                                   and rownum = 1 ";

                                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                                    ParamArr[0].Value = ChargeNo;
                                    ParamArr[1].Value = strBabyRegisterId;
                                    ParamArr[2].Value = DiffValDeptID;
                                    ParamArr[3].Value = DiffValCatID;

                                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                                }
                            }
                        }

                    }

                    #endregion

                    //预交金处理
                    SQL = @"update t_opr_bih_prepay set isclear_int = 1, chargeno_chr = ? where chargeno_chr is null and registerid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ChargeNo;
                    ParamArr[1].Value = RegID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

                //入院登记表
                SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 4, operatorid_chr = ? where registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //出院记录表
                SQL = @"update t_opr_bih_leave set modify_dat = sysdate, pstatus_int = 1, operatorid_chr = ? where status_int = 1 and registerid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //床位表
                SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                //调转信息表
                SQL = @"insert into t_opr_bih_transfer (transferid_chr, sourcebedid_chr, targetbedid_chr, type_int, des_vchr, operatorid_chr, registerid_chr, 
                                                                            modify_dat, sourcedeptid_chr, sourceareaid_chr, targetdeptid_chr, targetareaid_chr)
                                                       select LPAD (seq_opr_bih_transfer.NEXTVAL, 12, '0'),
                                                              a.sourcebedid_chr,
                                                              a.targetbedid_chr,
                                                              6,
                                                              '', ?,                                               
                                                              a.registerid_chr,
                                                              sysdate,
                                                              a.sourcedeptid_chr,
                                                              a.sourceareaid_chr, 
                                                              a.targetdeptid_chr, 
                                                              a.targetareaid_chr     
                                                          from t_opr_bih_transfer a 
                                                         where a.transferid_chr = (
                                                                                    select max(b.transferid_chr) 
                                                                                      from t_opr_bih_transfer b 
                                                                                     where b.type_int = 7                                
                                                                                       and b.registerid_chr = ?)";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Charge_VO.OperEmp;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                #region 婴儿结算操作

                if (Charge_VO.m_objBabyInfoVo != null)
                {

                    for (int i2 = 0; i2 < Charge_VO.m_objBabyInfoVo.Length; i2++)
                    {
                        string strBabyRegisterId = Charge_VO.m_objBabyInfoVo[i2].RegisterID;
                        //入院登记表
                        SQL = @"update t_opr_bih_register set pstatus_int = 3, feestatus_int = 4, operatorid_chr = ? where registerid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = Charge_VO.OperEmp;
                        ParamArr[1].Value = strBabyRegisterId;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        //出院记录表
                        SQL = @"update t_opr_bih_leave set modify_dat = sysdate, pstatus_int = 1, operatorid_chr = ? where status_int = 1 and registerid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = Charge_VO.OperEmp;
                        ParamArr[1].Value = strBabyRegisterId;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        //床位表
                        SQL = @"update t_bse_bed set status_int = 1, bihregisterid_chr = '' where bihregisterid_chr = ?";
                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = strBabyRegisterId;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                        //调转信息表
                        SQL = @"insert into t_opr_bih_transfer (transferid_chr, sourcebedid_chr, targetbedid_chr, type_int, des_vchr, operatorid_chr, registerid_chr, 
                                                                            modify_dat, sourcedeptid_chr, sourceareaid_chr, targetdeptid_chr, targetareaid_chr)
                                                       select LPAD (seq_opr_bih_transfer.NEXTVAL, 12, '0'),
                                                              a.sourcebedid_chr,
                                                              a.targetbedid_chr,
                                                              6,
                                                              '', ?,                                               
                                                              a.registerid_chr,
                                                              sysdate,
                                                              a.sourcedeptid_chr,
                                                              a.sourceareaid_chr, 
                                                              a.targetdeptid_chr, 
                                                              a.targetareaid_chr     
                                                          from t_opr_bih_transfer a 
                                                         where a.transferid_chr = (
                                                                                    select max(b.transferid_chr) 
                                                                                      from t_opr_bih_transfer b 
                                                                                     where b.type_int = 7                                
                                                                                       and b.registerid_chr = ?)";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = Charge_VO.OperEmp;
                        ParamArr[1].Value = strBabyRegisterId;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);



                    }
                }
                #endregion
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

        #region <门诊>调正核算分类数据

        #region 获取记帐所有处方ID
        /// <summary>
        /// 获取记帐所有处方ID
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMzGetAcctRecipeID(string BeginDate, string EndDate, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select distinct a.outpatrecipeid_chr, a.sbsum_mny,
                                     count (b.outpatrecipeid_chr) as nums
                                from t_opr_outpatientrecipeinv a, t_opr_reciperelation b
                               where a.outpatrecipeid_chr = b.seqid
                                 and a.split_int = 0
                                 and a.acctsum_mny > 0
                                 and a.status_int <> 0
                                 and a.recorddate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                                          and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                            group by a.outpatrecipeid_chr, a.sbsum_mny
                            order by a.outpatrecipeid_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = BeginDate;
                ParamArr[1].Value = EndDate;
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

        #region 根据已收费处方ID获取核算分类
        /// <summary>
        /// 根据已收费处方ID获取核算分类
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMzGetRecipeCat(string RecipeID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select b.itemopcalctype_chr,
                                 sum (round (a.tolprice_mny * a.discount_dec, 2)) as catsum,
                                 sum (a.tolprice_mny) as totalsum
                            from t_opr_oprecipeitemde a, t_bse_chargeitem b
                           where a.itemid_chr = b.itemid_chr(+) and a.outpatrecipeid_chr = ?
                        group by b.itemopcalctype_chr";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RecipeID;
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

        #region 根据处方ID获取SEQID列表
        /// <summary>
        /// 根据处方ID获取SEQID列表
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMzGetSeqIDList(string RecipeID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @" select a.seqid_chr, a.status_int, a.outpatrecipeid_chr
                              from t_opr_outpatientrecipeinv a
                             where a.outpatrecipeid_chr = ?
                             order by a.outpatrecipeid_chr, a.status_int";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RecipeID;
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

        #region 根据SEQID获取核算分类
        /// <summary>
        /// 根据SEQID获取核算分类
        /// </summary>
        /// <param name="SeqID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMzGetChargeCat(string SeqID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select a.itemcatid_chr, a.tolfee_mny, a.sbsum_mny
                              from t_opr_outpatientrecipesumde a
                             where a.seqid_chr = ?";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = SeqID;
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

        #region 根据SEQID、CatID更新核算分类
        /// <summary>
        /// 根据SEQID、CatID更新核算分类
        /// </summary>
        /// <param name="SeqID"></param>
        /// <param name="CatIDArr"></param>
        /// <param name="CatSumArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMzUpdateChargeCat(string SeqID, ArrayList CatIDArr, ArrayList CatSumArr, string PStatus)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                int sign = 1;
                if (PStatus == "2")
                {
                    sign = -1;
                }

                for (int i = 0; i < CatIDArr.Count; i++)
                {
                    SQL = @"update t_opr_outpatientrecipesumde a
                               set a.sbsum_mny = ?
                             where a.seqid_chr = ? and a.itemcatid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = Convert.ToDecimal(CatSumArr[i].ToString()) * sign;
                    ParamArr[1].Value = SeqID;
                    ParamArr[2].Value = CatIDArr[i].ToString();

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                }

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

        #region (医保)试算接口 new
        /// <summary>
        /// (医保)试算接口
        /// </summary>
        /// <param name="vyydm">医院代码</param>
        /// <param name="vzyhm">住院号</param>
        /// <param name="vzych">住院次数</param>
        /// <param name="verdm">返回值代码</param>
        /// <param name="verms">返回值信息</param>
        /// <param name="blnIsInsertDetail">是否生成明细表YBAD12(当批查询时可设置为False)</param>
        /// <param name="m_strConn">数据库连接字符串</param>
        /// <returns></returns>
        [DllImport("ado_zyss.dll")]
        public static extern bool ZYSS_CONN(string vyydm, string vzyhm, int vzych, ref string verdm, ref string verms, bool blnIsInsertDetail, string m_strConn);
        [AutoComplete]
        public long m_lngZYSS(string HospCode, string Zyh, int Zycs, out decimal TotalMoney, out decimal InsuredMoney, out string OutErrMsg)
        {

            string OutDm = "";
            string OutMs = "";
            TotalMoney = 0;
            InsuredMoney = 0;
            OutErrMsg = "";
            try
            {
                string m_strConn = "Provider=OraOLEDB.Oracle.1;";
                m_strConn += HRPService.clsHRPTableService.strbytOracleICare;
                bool ret = ZYSS_CONN(HospCode, Zyh, Zycs, ref OutDm, ref OutMs, true, m_strConn);
                if (!ret)
                {
                    OutErrMsg = OutDm + "   " + OutMs;
                    return 0;
                }
                else
                {
                    if (OutDm.Contains("000"))
                    {
                        OutErrMsg = OutDm + "   " + OutMs;
                        string[] m_strArr = OutMs.Split('：');
                        if (m_strArr.Length == 4)
                        {
                            TotalMoney = Convert.ToDecimal(m_strArr[1].Trim().Replace("医保支付金额", string.Empty));
                            InsuredMoney = Convert.ToDecimal(m_strArr[2].Trim().Replace("个人支付", string.Empty));
                        }

                    }
                    else
                    {
                        OutErrMsg = OutDm + "   " + OutMs;
                        return 0;
                    }

                }
            }
            catch (Exception ex)
            {
                OutErrMsg = ex.Message;
                return 0;
            }
            return 1;

        }
        #region (医保)医保试算
        /// <summary>
        /// (医保)医保试算
        /// </summary>
        /// <param name="HospCode"></param>
        /// <param name="RegID"></param>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <param name="TotalMoney"></param>
        /// <param name="InsuredMoney"></param>
        /// <param name="OutErrMsg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngYBBudget(string HospCode, string RegID, string Zyh, int Zycs, out decimal TotalMoney, out decimal InsuredMoney, out string OutErrMsg)
        {
            long lngRes = 0;
            long lngAffects = 0;
            string SQL = "";

            TotalMoney = 0;
            InsuredMoney = 0;
            OutErrMsg = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"delete from ybad10 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(?)
                                                                                   from t_opr_bih_register a
                                                                                  where a.registerid_chr = ? )";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zycs;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"insert into ybad10 (yydm, zyhm, zych, xinm, xinb, sfzh, csrq, ksdm, ryrq, cyrq, zyts, 
                                            zdfl, zddm, sczt, rylb, dylb, jslx, yyfd, jjfd, ybcs, zfje)
                                    select ?,
                                           a.inpatientid_chr,
                                           ?,
                                           b.lastname_vchr,
                                           b.sex_chr,
                                           b.idcard_chr,
                                           b.birth_dat,
                                           a.deptid_chr,
                                           a.inareadate_dat,
                                           sysdate,
                                           floor(sysdate - a.inareadate_dat),
                                           null,
                                           null,
                                           null,
                                           c.rylb,
                                           null,
                                           c.jslx,
                                           100,
                                           nvl(b.insuredpayscale_dec, 100),
                                           b.insuredpaytime_int,
                                           b.insuredpaymoney_mny 
                                      from t_opr_bih_register a,
                                           t_opr_bih_registerdetail b,
                                           t_opr_bih_ybdefpaytype c          
                                     where a.registerid_chr = b.registerid_chr 
                                       and a.paytypeid_chr = c.paytypeid_chr  
                                       and a.registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = HospCode;
                ParamArr[1].Value = Zycs;
                ParamArr[2].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"delete from ybad13 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(?)
                                                                                   from t_opr_bih_register a
                                                                                  where a.registerid_chr = ? )";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zycs;
                ParamArr[1].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"insert into ybad13 ( yydm, zyhm, zych, xmcode, xmdes, xmunt, xmqnt, xmprc, xmamt, trndate, trnflg) 
                                    select ?,
                                           a.inpatientid_chr,
                                           ?,
                                           c.insuranceid_chr,
                                           max(substr(c.itemname_vchr,0,15)),
                                           max(b.unit_vchr),
                                           sum(b.amount_dec),
                                           max(b.unitprice_dec),
                                           sum(round(b.amount_dec * b.unitprice_dec, 2)),
                                           sysdate,
                                           '0'        
                                      from t_opr_bih_register a,
                                           t_opr_bih_patientcharge b,
                                           t_bse_chargeitem c 
                                     where a.registerid_chr = b.registerid_chr 
                                       and b.chargeitemid_chr = c.itemid_chr 
                                       and length(c.insuranceid_chr) <= 20
                                       and (b.pstatus_int = 1 or b.pstatus_int = 2)
                                       and a.registerid_chr = ? 
                                  group by a.inpatientid_chr, a.inpatientcount_int, c.insuranceid_chr";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = HospCode;
                ParamArr[1].Value = Zycs;
                ParamArr[2].Value = RegID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                #region old
                //if (lngRes > 0)
                //{
                //    string OutDm = "";
                //    string OutMs = "";

                //    try
                //    {
                //        // bool ret = ZYSS(HospCode, Zyh, Zycs, ref OutDm, ref OutMs);
                //        string m_strConn = "Provider=OraOLEDB.Oracle.1;";
                //        m_strConn += HRPService.clsHRPTableService.strbytOracleICare;
                //        bool ret = ZYSS_CONN(HospCode, Zyh, Zycs, ref OutDm, ref OutMs, true, m_strConn);
                //        if (!ret)
                //        {
                //            OutErrMsg = OutDm + "   " + OutMs;
                //            return 0;
                //        }
                //        else
                //        {
                //            OutErrMsg = OutDm + "   " + OutMs;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        OutErrMsg = ex.Message;
                //        return 0;
                //    }
                //}

                //                SQL = @"select zl19, yb02 from ybad11 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(?)
                //                                                                                              from t_opr_bih_register a
                //                                                                                             where a.registerid_chr = ? )";

                //                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                //                ParamArr[0].Value = Zycs;
                //                ParamArr[1].Value = RegID;

                //                DataTable dtMain = new DataTable();

                //                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                //                if (lngRes > 0 && dtMain.Rows.Count == 1)
                //                {
                //                    TotalMoney = this.ConvertObjToDecimal(dtMain.Rows[0]["zl19"]);
                //                    InsuredMoney = this.ConvertObjToDecimal(dtMain.Rows[0]["yb02"]);
                //                }
                #endregion
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

        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region <门诊>发票信息
        /// <summary>
        /// 门诊发票信息 
        /// </summary>
        /// <param name="ChargeNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPInvoiceByChargeNo(string ChargeNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            long lngRes = 0;
            string SQL = "";
            dtMain = null;
            dtDet = null;
            dtPayMode = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //发票主信息
                SQL = @"select c.invoiceno_vchr, c.outpatrecipeid_chr, c.invdate_dat, c.acctsum_mny,
                               c.sbsum_mny, c.opremp_chr, c.recordemp_chr, c.recorddate_dat,
                               c.status_int, c.seqid_chr, c.balanceemp_chr, c.balance_dat,
                               c.balanceflag_int, c.totalsum_mny, c.patientid_chr,
                               c.patientname_chr, c.deptid_chr, c.deptname_chr, c.doctorid_chr,
                               c.doctorname_chr, c.confirmemp_chr, a.paytypeid_chr,
                               c.internalflag_int, c.baseseqid_chr, a.groupid_chr,
                               c.confirmdeptid_chr, c.split_int, d.paytypename_vchr, e.empno_chr a,
                               f.empno_chr b, g.patientcardid_chr, h.shortno_chr confdept,
                               e.empno_chr confemp, c.medsendwininfo_vchr,c.totaldiffcost_mny
                         from t_opr_charge a,
                              t_opr_chargedefinv b,
                              t_opr_outpatientrecipeinv c,
                              t_bse_patientpaytype d,
                              t_bse_employee e,
                              t_bse_employee f,
                              t_bse_patientcard g,
                              t_bse_deptdesc h                                                            
                        where a.chargeno_chr = b.chargeno_chr 
                          and b.invoiceno_vchr = c.invoiceno_vchr 
                          and c.paytypeid_chr = d.paytypeid_chr(+)  
                          and a.patientid_chr = g.patientid_chr(+)
                          and a.operemp_chr = e.empid_chr(+)
                          and a.doctorid_chr = f.empid_chr(+)
                          and a.deptid_chr = h.deptid_chr(+)
                          and a.status_int = 1 
                          and a.chargeno_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ChargeNo;
                //((Oracle.DataAccess.Client.OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                if (lngRes > 0 && dtMain.Rows.Count > 0)
                {
                    //目前默认一次结算对应一张发票                    
                    string invono = "";
                    if (dtMain.Rows.Count == 1)
                    {
                        invono = dtMain.Rows[0]["invoiceno_vchr"].ToString().Trim();

                        //发票分类信息
                        SQL = @"select invoiceno_vchr, itemcatid_chr, abs(sum(tolfee_mny)) as totalsum_mny 
                                  from t_opr_outpatientrecipeinvde 
                                 where invoiceno_vchr = ? 
                              group by invoiceno_vchr, itemcatid_chr";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = invono;

                        lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);
                    }
                    else
                    {
                        for (int i = 0; i < dtMain.Rows.Count; i++)
                        {
                            invono += "'" + dtMain.Rows[i]["invoiceno_vchr"].ToString().Trim() + "',";
                        }
                        invono = invono.Substring(0, invono.Length - 1);

                        //发票分类信息
                        SQL = @"select invoiceno_vchr, itemcatid_chr, abs(sum(tolfee_mny)) as totalsum_mny 
                                  from t_opr_outpatientrecipeinvde 
                                 where invoiceno_vchr in (" + invono + @") 
                              group by invoiceno_vchr, itemcatid_chr";

                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtDet);
                    }

                    //支付方式
                    SQL = @"select b.paytype_int, b.paysum_mny 
                              from t_opr_charge a,
                                   t_opr_payment b  
                             where a.chargeno_chr = b.chargeno_vchr 
                               and a.status_int = 1                                         
                               and a.chargeno_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = ChargeNo;

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayMode, ParamArr);
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 门诊发票信息 
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPInvoiceByInvoNo(string InvoNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            long lngRes = 0;
            string SQL = "";
            dtMain = null;
            dtDet = null;
            dtPayMode = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //发票主信息
                SQL = @"select c.invoiceno_vchr, c.outpatrecipeid_chr, c.invdate_dat, c.acctsum_mny,
                               c.sbsum_mny, c.opremp_chr, c.recordemp_chr, c.recorddate_dat,
                               c.status_int, c.seqid_chr, c.balanceemp_chr, c.balance_dat,
                               c.balanceflag_int, c.totalsum_mny, c.patientid_chr, c.patientname_chr,
                               c.deptid_chr, c.deptname_chr, c.doctorid_chr, c.doctorname_chr,
                               c.confirmemp_chr, c.paytypeid_chr, c.internalflag_int, c.baseseqid_chr,
                               c.groupid_chr, c.confirmdeptid_chr, c.split_int, d.paytypename_vchr,
                               e.empno_chr a, f.empno_chr b, g.patientcardid_chr,
                               h.shortno_chr confdept, e.empno_chr confemp, c.medsendwininfo_vchr,c.totaldiffcost_mny
                          from t_opr_outpatientrecipeinv c,
                               t_bse_patientpaytype d,
                               t_bse_employee e,
                               t_bse_employee f,
                               t_bse_patientcard g,
                               t_bse_deptdesc h
                         where c.paytypeid_chr = d.paytypeid_chr(+)
                           and c.patientid_chr = g.patientid_chr(+)
                           and c.opremp_chr = e.empid_chr(+)
                           and c.doctorid_chr = f.empid_chr(+)
                           and c.deptid_chr = h.deptid_chr(+)
                           and c.status_int = 1
                           and c.invoiceno_vchr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                //发票分类信息
                SQL = @"select invoiceno_vchr, itemcatid_chr, abs(sum(tolfee_mny)) as totalsum_mny 
                          from t_opr_outpatientrecipeinvde 
                         where invoiceno_vchr = ? 
                      group by invoiceno_vchr, itemcatid_chr";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);

                //支付方式
                SQL = @"select distinct p.paytype_int, p.paysum_mny
                           from t_opr_charge a,
                                t_opr_chargedefinv b,
                                t_opr_outpatientrecipeinv c,
                                t_opr_payment p
                          where a.chargeno_chr = b.chargeno_chr
                            and b.invoiceno_vchr = c.invoiceno_vchr
                            and a.chargeno_chr = p.chargeno_vchr
                            and a.status_int = 1
                            and c.invoiceno_vchr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayMode, ParamArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 门诊发票信息
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="InvoNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPInvoiceByInvoNo(int mode, string InvoNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            long lngRes = 0;
            string SQL = "";
            dtMain = null;
            dtDet = null;
            dtPayMode = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                //发票主信息
                SQL = @"select c.invoiceno_vchr, c.outpatrecipeid_chr, c.invdate_dat, c.acctsum_mny,
                               c.sbsum_mny, c.opremp_chr, c.recordemp_chr, c.recorddate_dat,
                               c.status_int, c.seqid_chr, c.balanceemp_chr, c.balance_dat,
                               c.balanceflag_int, c.totalsum_mny, c.patientid_chr, c.patientname_chr,
                               c.deptid_chr, c.deptname_chr, c.doctorid_chr, c.doctorname_chr,
                               c.confirmemp_chr, c.paytypeid_chr, c.internalflag_int, c.baseseqid_chr,
                               c.groupid_chr, c.confirmdeptid_chr, c.split_int, d.paytypename_vchr,
                               e.empno_chr a, f.empno_chr b, g.patientcardid_chr,
                               h.shortno_chr confdept, e.empno_chr confemp, c.medsendwininfo_vchr
                          from t_opr_outpatientrecipeinv c,
                               t_bse_patientpaytype d,
                               t_bse_employee e,
                               t_bse_employee f,
                               t_bse_patientcard g,
                               t_bse_deptdesc h
                         where c.paytypeid_chr = d.paytypeid_chr(+)
                           and c.patientid_chr = g.patientid_chr(+)
                           and c.opremp_chr = e.empid_chr(+)
                           and c.doctorid_chr = f.empid_chr(+)
                           and c.deptid_chr = h.deptid_chr(+)
                           and c.status_int = 1
                           and c.invoiceno_vchr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                //发票分类信息
                SQL = @"select invoiceno_vchr, itemcatid_chr,
                               sum (abs (tolfee_mny)) / count (itemcatid_chr) as totalsum_mny
                          from t_opr_outpatientrecipeinvde
                         where invoiceno_vchr = ?
                      group by invoiceno_vchr, itemcatid_chr";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtDet, ParamArr);

                //支付方式
                SQL = @"select distinct p.paytype_int
                          from t_opr_charge a,
                               t_opr_chargedefinv b,
                               t_opr_outpatientrecipeinv c,
                               t_opr_payment p
                         where a.chargeno_chr = b.chargeno_chr
                           and b.invoiceno_vchr = c.invoiceno_vchr
                           and a.chargeno_chr = p.chargeno_vchr
                           and a.status_int = 1
                           and c.invoiceno_vchr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = InvoNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtPayMode, ParamArr);

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 更改病人费用核对状态
        /// <summary>
        /// 更改病人费用核对状态
        /// </summary>
        /// <param name="RegisterID"></param>
        /// <param name="CheckStatus"></param>
        [AutoComplete]
        public long m_lngUpdatePatientChargeCheckStatus(string RegisterID, string CheckStatus)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"update t_opr_bih_register a
                           set a.checkstatus_int = ?
                         where a.registerid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = CheckStatus;
                ParamArr[1].Value = RegisterID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

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

        #region 获取科室列表
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDepts(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = -1;
            string SQL = @"select t.deptname_vchr,t.wbcode_chr,t.pycode_chr,t.usercode_vchr,t.deptid_chr from t_bse_deptdesc t";
            try
            {
                clsHRPTableService objHRPTSvc = new clsHRPTableService();
                lngRes = objHRPTSvc.lngGetDataTableWithoutParameters(SQL, ref dtbResult);
                objHRPTSvc.Dispose();
                objHRPTSvc = null;
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

        /// <summary>
        /// 更新是否符合适应症标志
        /// </summary>
        /// <param name="m_glstSFLB"></param>
        /// <param name="p_strEmpID"></param>
        /// <param name="p_strEmpName"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetChargeSFLB_Zjwsy(List<clsSFLB_log> m_glstSFLB, string p_strEmpID, string p_strEmpName)
        {
            long lngRes = -1;
            try
            {
                DateTime dtmNow = DateTime.Now;
                string strSQL = @"insert into t_opr_bih_changesflb_log
                                      (seq_vchr, pchargeid_chr, empid_vchr, empname_vchr, createdat_dat,
                                       newsflbbh_vchr, oldsflbbh_vchr, itemid_chr)
                                    values
                                      (seq_changesflb_log.nextval, ?, ?, ?, sysdate, ?, ?, ?)";
                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
                object[][] objValues = new object[dbTypes.Length][];

                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[m_glstSFLB.Count];
                }

                int n = 0;
                for (int i = 0; i < m_glstSFLB.Count; i++)
                {
                    n = 0;
                    objValues[n++][i] = m_glstSFLB[i].m_strPChargeID;
                    objValues[n++][i] = p_strEmpID;
                    objValues[n++][i] = p_strEmpName;
                    objValues[n++][i] = m_glstSFLB[i].m_strNewSFLBBH;
                    objValues[n++][i] = m_glstSFLB[i].m_strOLDSFLBBH;
                    objValues[n++][i] = m_glstSFLB[i].m_strItemID;
                }
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                strSQL = "update t_opr_bih_patientcharge a set a.itemchargetype_vchr = ? where a.pchargeid_chr = ?";
                dbTypes = new DbType[] { DbType.String, DbType.String };
                objValues = new object[dbTypes.Length][];

                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[m_glstSFLB.Count];
                }

                n = 0;
                for (int i = 0; i < m_glstSFLB.Count; i++)
                {
                    n = 0;
                    objValues[n++][i] = m_glstSFLB[i].m_strNewSFLBBH;
                    objValues[n++][i] = m_glstSFLB[i].m_strPChargeID;
                }
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 检测社保病人社保结算没有成功就不能做HIS结算
        /// <summary>
        /// 检测社保病人社保结算没有成功就不能做HIS结算
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckYBChargeSuccessFull(string p_strRegisterID)
        {
            DataTable dtbResult = new DataTable();
            bool blnSuccess = false; // true 表示 社保病人 没有做社保结算，false 表示 病人可以HIS结算
            long lngRes = -1;
            string SQL = @"select t.status_chr
                              from t_ins_cszyreg t
                             where t.registerid_vchr = ?
                               and t.status_chr > -1";
            try
            {
                clsHRPTableService objHRPTSvc = new clsHRPTableService();
                IDataParameter[] Parars = null;
                objHRPTSvc.CreateDatabaseParameter(1, out Parars);
                Parars[0].Value = p_strRegisterID;
                lngRes = objHRPTSvc.lngGetDataTableWithParameters(SQL, ref dtbResult, Parars);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (dtbResult.Rows[0]["status_chr"].ToString() == "0")
                    {
                        blnSuccess = true;
                    }
                }
                objHRPTSvc.Dispose();
                objHRPTSvc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return blnSuccess;
        }
        #endregion
    }
}
