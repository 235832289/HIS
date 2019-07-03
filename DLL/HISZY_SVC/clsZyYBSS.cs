using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Disabled)]
    [ObjectPooling(true)]
    public class clsZyYBSS : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
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
    }
}
