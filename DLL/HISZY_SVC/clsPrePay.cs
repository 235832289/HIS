using System;
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
    public class clsPrePay : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        public clsPrePay()
        {
        }
        #endregion

        #region 检查预交金单据号是否重复
        /// <summary>
        /// 检查预交金单据号是否重复
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckPrepayBillNo(string CurrNo, int Uptype)
        {
            long lngRes = 0;
            bool IsExist = false;

            string SQL = @"select prepayinv_vchr as nos 
                             from t_opr_bih_prepay 
                            where prepayinv_vchr = ? 

                           union all 

                           select a.repprnbillno_vchr as nos
                             from t_opr_bih_billrepeatprint a,
                                  t_opr_bih_prepay b 
                               where a.billid_chr = b.prepayid_chr 
                                 and a.billtype_chr = '1' 
                                 and a.repprnbillno_vchr = ?";

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

        #region 根据住院登记流水号获取预交金信息
        /// <summary>
        /// 根据住院登记流水号获取预交金信息
        /// </summary>
        /// <param name="RegID">入院登记号</param>
        /// <param name="Type">类型：1 明细；2 汇总</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepayByRegID(string RegID, int Type, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";

            if (Type == 1)
            {
                SQL = @"select a.prepayid_chr, a.patientid_chr, a.registerid_chr, a.liner_int,
                               a.paytype_int, a.cuycate_int, a.money_dec, a.prepayinv_vchr,
                               a.areaid_chr, a.des_vchr, a.creatorid_chr, a.create_dat, a.deactid_chr,
                               a.deactivate_dat, a.status_int, a.isclear_int, a.pressno_vchr,
                               a.uptype_int, a.balanceemp_chr, a.balance_dat, a.patientname_chr,
                               a.areaname_vchr, a.balanceflag_int, a.balanceid_vchr, a.confirmemp_chr,
                               a.chargeno_chr, a.originvono_vchr, a.origchargeno_chr, 
                               b.empno_chr as lastname_vchr, nvl(c.empno_chr, '') as confirmemp,  r.repprnbillno_vchr   
                          from t_opr_bih_prepay a,
                               t_bse_employee b,
                               t_bse_employee c,
                               t_opr_bih_billrepeatprint r             
                         where a.creatorid_chr = b.empid_chr(+) 
                           and a.confirmemp_chr = c.empid_chr(+) 
                           and a.prepayid_chr = r.billid_chr(+)
                           and a.registerid_chr = ? 
                        order by a.create_dat, a.prepayinv_vchr, a.paytype_int";
            }
            else
            {
                SQL = @"select ta.registerid_chr, ta.total, tb.prepayid_chr, tb.prepayinv_vchr, tb.balancetotal 
                          from 
                               (select a.registerid_chr, sum(nvl(a.money_dec,0)) as total 
                                  from t_opr_bih_prepay a
                                 where a.status_int = 1 
                                group by a.registerid_chr) ta,
                                (select a.prepayid_chr, a.registerid_chr, a.prepayinv_vchr, nvl(a.money_dec,0) as balancetotal 
                                  from t_opr_bih_prepay a
                                 where a.status_int = 1 
                                   and a.isclear_int = 0 
                                   and a.paytype_int = 1                                   
                                   and not exists (select 1
                                                   from t_opr_bih_prepay b 
                                                  where b.status_int = 1 
                                                    and b.isclear_int = 0 
                                                    and b.paytype_int = 2
                                                    and a.prepayinv_vchr = b.prepayinv_vchr)
                                   and not exists (select 1
                                                   from t_opr_bih_prepay b 
                                                  where b.status_int = 1 
                                                    and b.isclear_int = 0 
                                                    and b.paytype_int = 4
                                                    and a.prepayinv_vchr = b.originvono_vchr)
                                    union all
                                    select a.prepayid_chr, a.registerid_chr, a.prepayinv_vchr, nvl(a.money_dec,0) as balancetotal 
                                                                      from t_opr_bih_prepay a
                                                                     where a.status_int = 1 
                                                                       and a.isclear_int = 0 
                                                                       and a.paytype_int = 3 ) tb
                         where ta.registerid_chr = tb.registerid_chr(+)
                           and ta.registerid_chr = ?";
            }

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = RegID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (Type == 1 && dt != null && dt.Rows.Count > 0)
                {
                    #region 删除多次重打记录
                    List<int> lstRowNo = new List<int>();
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (i < dt.Rows.Count - 1)
                        {
                            if (dt.Rows[i]["prepayid_chr"].ToString() == dt.Rows[i + 1]["prepayid_chr"].ToString())
                            {
                                lstRowNo.Add(i);
                            }
                        }
                    }
                    if (lstRowNo.Count > 0)
                    {
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (lstRowNo.IndexOf(i) >= 0)
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
                    }
                    #endregion
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

        #region 根据预交金ID获取预交金信息
        /// <summary>
        /// 根据预交金ID获取预交金信息
        /// </summary>
        /// <param name="PrePayID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPrepayByPrePayID(string PrePayID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select  a.prepayid_chr, a.patientid_chr, a.registerid_chr, a.liner_int,
                                   a.paytype_int, a.cuycate_int, a.money_dec, a.prepayinv_vchr,
                                   a.areaid_chr, a.des_vchr, a.creatorid_chr, a.create_dat,
                                   a.deactid_chr, a.deactivate_dat, a.status_int, a.isclear_int,
                                   a.pressno_vchr, a.uptype_int, a.balanceemp_chr, a.balance_dat,
                                   a.patientname_chr, a.areaname_vchr, a.balanceflag_int,
                                   a.balanceid_vchr, a.confirmemp_chr, a.chargeno_chr, a.originvono_vchr,
                                   a.origchargeno_chr, b.inpatientid_chr, c.lastname_vchr, d.empno_chr,
                                   e.deptname_vchr, f.bed_no, d.lastname_vchr as empname,g.paytypename_vchr
                              from t_opr_bih_prepay a, t_opr_bih_register b, t_opr_bih_registerdetail c,
                                   t_bse_employee d, t_bse_deptdesc e, t_bse_bed f,t_bse_patientpaytype g
                             where a.registerid_chr = b.registerid_chr
                               and a.registerid_chr = c.registerid_chr
                               and b.bedid_chr = f.bedid_chr(+)
                               and a.creatorid_chr = d.empid_chr(+)
                               and b.paytypeid_chr=g.paytypeid_chr
                               and b.areaid_chr = e.deptid_chr(+)
                               and a.prepayid_chr = ?";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = PrePayID;

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

        #region 新增预交金记录
        /// <summary>
        /// 新增预交金记录
        /// </summary>
        /// <param name="PrePay_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddPrePay(clsBihPrePay_VO PrePay_VO, out string PrePayID)
        {
            long lngRes = 0, lngAffects = 0;
            PrePayID = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                DataTable dt = new DataTable();

                //取预交金序列ID
                string SQL = "select lpad(seq_prepayid.NEXTVAL, 12, '0') from dual";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0)
                {
                    PrePayID = dt.Rows[0][0].ToString();
                }

                SQL = @"insert into t_opr_bih_prepay (prepayid_chr, patientid_chr, registerid_chr, paytype_int, cuycate_int, 
                                                      money_dec, prepayinv_vchr, areaid_chr, des_vchr, creatorid_chr, create_dat, 
                                                      status_int, isclear_int, uptype_int, patientname_chr, areaname_vchr, balanceflag_int) values ( 
                                                      ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, sysdate, 1, 0, ?, ?, ?, 0)";

                objHRPSvc.CreateDatabaseParameter(13, out ParamArr);
                ParamArr[0].Value = PrePayID;
                ParamArr[1].Value = PrePay_VO.strPatientID;
                ParamArr[2].Value = PrePay_VO.strRegisterID;
                ParamArr[3].Value = PrePay_VO.intPayType;
                ParamArr[4].Value = PrePay_VO.intCuyCate;
                ParamArr[5].Value = PrePay_VO.decMoney;
                ParamArr[6].Value = PrePay_VO.strPrePayInv;
                ParamArr[7].Value = PrePay_VO.strAreaID;
                ParamArr[8].Value = PrePay_VO.strDes;
                ParamArr[9].Value = PrePay_VO.strCreatorID;
                ParamArr[10].Value = PrePay_VO.intUpType;
                ParamArr[11].Value = PrePay_VO.strPatientName;
                ParamArr[12].Value = PrePay_VO.strAreaName;

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

        #region 退、恢复和冲单预交金
        /// <summary>
        /// 退、恢复和冲单预交金
        /// </summary>
        /// <param name="PrePayID">当前预交金流水ID</param>
        /// <param name="EmpID">收款员ID</param>
        /// <param name="ConfirmID">审核人ID</param>
        /// <param name="type">类型 2 退款 3 恢复 4 冲单</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRefundAndResumeAndStrikePrePay(string PrePayID, string NewBillNO, string EmpID, string ConfirmID, int type, string CuyCate, out string NewPrePayID)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            NewPrePayID = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (type == 4)
                {
                    //取预交金序列ID
                    DataTable dt = new DataTable();

                    SQL = "select lpad(seq_prepayid.NEXTVAL, 12, '0') from dual";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                    if (lngRes > 0)
                    {
                        NewPrePayID = dt.Rows[0][0].ToString();
                    }

                    SQL = @"insert into t_opr_bih_prepay (prepayid_chr, patientid_chr, registerid_chr, paytype_int, cuycate_int, 
                                                             money_dec, prepayinv_vchr, areaid_chr, des_vchr, creatorid_chr, create_dat, 
                                                             status_int, isclear_int, uptype_int, balanceemp_chr, balance_dat, patientname_chr, 
                                                             areaname_vchr, balanceflag_int, balanceid_vchr, confirmemp_chr, originvono_vchr) 
                                                      select ?, 
                                                             patientid_chr,
                                                             registerid_chr,
                                                             ?,
                                                             ?,
                                                             -money_dec,
                                                             ?,
                                                             areaid_chr,
                                                             des_vchr, ?,                                                              
                                                             sysdate,
                                                             status_int,
                                                             isclear_int,
                                                             uptype_int,
                                                             null,
                                                             null,
                                                             patientname_chr,
                                                             areaname_vchr,  
                                                             0, 
                                                             null, 
                                                             null, 
                                                             prepayinv_vchr                                          
                                                        from t_opr_bih_prepay 
                                                       where prepayid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                    ParamArr[0].Value = NewPrePayID;
                    ParamArr[1].Value = type;
                    ParamArr[2].Value = CuyCate;
                    ParamArr[3].Value = NewBillNO;
                    ParamArr[4].Value = EmpID;
                    ParamArr[5].Value = PrePayID;
                }
                else
                {
                    SQL = @"insert into t_opr_bih_prepay (prepayid_chr, patientid_chr, registerid_chr, paytype_int, cuycate_int, 
                                                             money_dec, prepayinv_vchr, areaid_chr, des_vchr, creatorid_chr, create_dat, 
                                                             status_int, isclear_int, uptype_int, balanceemp_chr, balance_dat, patientname_chr, 
                                                             areaname_vchr, balanceflag_int, balanceid_vchr, confirmemp_chr) 
                                                      select lpad(seq_prepayid.NEXTVAL, 12, '0'), 
                                                             patientid_chr,
                                                             registerid_chr,
                                                             ?,
                                                             cuycate_int,
                                                             -money_dec,
                                                             prepayinv_vchr,
                                                             areaid_chr,
                                                             des_vchr, ?,                                                              
                                                             sysdate,
                                                             status_int,
                                                             isclear_int,
                                                             uptype_int,
                                                             null,
                                                             null,
                                                             patientname_chr,
                                                             areaname_vchr,  
                                                             0, 
                                                             null, null  
                                                        from t_opr_bih_prepay 
                                                       where prepayid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = type;
                    ParamArr[1].Value = EmpID;
                    ParamArr[2].Value = PrePayID;
                }

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                if (type == 3)
                {
                    SQL = @"select prepayinv_vchr from t_opr_bih_prepay where prepayid_chr = ?";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = PrePayID;
                    DataTable dt = null;
                    objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        SQL = @"update t_invoice_refundreason status = 0 where flagid = 3 and invono = ?";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = dt.Rows[0]["prepayinv_vchr"].ToString();
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

        #region 根据操作员工号获取ID、姓名和密码
        /// <summary>
        /// 根据操作员工号获取ID、姓名和密码
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="empno"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetempinfo(out DataTable dt, string empno)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select empid_chr, lastname_vchr, psw_chr from t_bse_employee where status_int = 1 and empno_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = empno;

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

        #region 保存重打票据信息
        /// <summary>
        /// 保存重打票据信息
        /// </summary>
        /// <param name="BillID"></param>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <param name="Empid"></param>
        /// <param name="BillType">票据类型：1 预交金 2 发票</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveRepeatPrn(string BillID, string OldBillNo, string NewBillNo, string Empid, string BillType)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";
            string repbillno = this.m_strGetrepeatprnbillno(BillID, OldBillNo, BillType);

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (repbillno != "")
                {
                    SQL = @"update t_opr_bih_billrepeatprint
                                set printstatus_int = -1   
                              where billid_chr = ?
                                and billtype_chr = ?  
                                and repprnbillno_vchr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = BillID;
                    ParamArr[1].Value = BillType;
                    ParamArr[2].Value = repbillno;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                    OldBillNo = repbillno;
                }

                SQL = @"insert into t_opr_bih_billrepeatprint(billtype_chr, billid_chr, sourcebillno_vchr, repprnbillno_vchr, printemp_chr, printdate_dat, printstatus_int)
                        values(?, ?, ?, ?, ?, sysdate, 0)";

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ParamArr[0].Value = BillType;
                ParamArr[1].Value = BillID;
                ParamArr[2].Value = OldBillNo;
                ParamArr[3].Value = NewBillNo;
                ParamArr[4].Value = Empid;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        [AutoComplete]
        private string m_strGetrepeatprnbillno(string BillID, string OldBillNo, string BillType)
        {
            long lngRes = 0;
            string billno = "";
            string SQL = @" select repprnbillno_vchr
                              from t_opr_bih_billrepeatprint
                             where printstatus_int = 0
                               and billtype_chr = ?   
                               and billid_chr = ? 
                               and sourcebillno_vchr = ?";

            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = BillType;
                ParamArr[1].Value = BillID;
                ParamArr[2].Value = OldBillNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dt.Rows.Count == 1)
            {
                billno = dt.Rows[0][0].ToString().Trim();
            }

            return billno;
        }
        #endregion

        #region 根据住院登记流水号获取已呆帐结算的预交金信息
        /// <summary>
        /// 根据住院登记流水号获取已呆帐结算的预交金信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PrepayTotalSum"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBadChargePrepayByRegID(string RegID, out decimal PrepayTotalSum)
        {
            long lngRes = 0;
            string SQL = @"select sum(b.money_dec) as totalsum
                             from t_opr_bih_charge a, 
                                  t_opr_bih_prepay b
                            where a.chargeno_chr = b.chargeno_chr
                              and a.status_int = 1
                              and a.class_int = 3
                              and a.registerid_chr = ?";

            PrepayTotalSum = 0;
            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = RegID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString().Trim() != "")
                    {
                        PrepayTotalSum = Convert.ToDecimal(dt.Rows[0][0].ToString());
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
    }
}
