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
    /// <summary>
    /// 住院医保结算类
    /// </summary>
    public class clsZyYB 
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsZyYB()
        {
        }
        #endregion

        #region (医保)传送住院收费数据到医保前置机
        /// <summary>
        /// (医保)传送住院收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, ArrayList objYBArr)
        {
            long lngRes = 0;
            string Sql = "";

            try
            {               
                ArrayList SqlArr = new ArrayList();
                for (int i = 0; i < objYBArr.Count; i++)
                {
                    clsYB_VO objYB = objYBArr[i] as clsYB_VO;
                                        
                    Sql = @"insert into mashxm (hos_code, zyno, zysno, xmcode, xmdes, xmunt , xmqnt, 
                                             xmprc, xmamt, trndate, trnflag, memoa, u_version) values ('" +
                                                 objYB.Hoscode + "','" +
                                                 objYB.ZYNo + "'," +
                                                 objYB.ZYSno + ",'" +
                                                 objYB.XMCode + "','" +                                                 
                                                 objYB.XMDes + "','" +
                                                 objYB.XMUnt + "'," +
                                                 objYB.XMQnt + "," +
                                                 objYB.XMPrc + "," +
                                                 objYB.XMAmt + ",'" +
                                                 objYB.Trndate + "','" +
                                                 objYB.Trnflag + "','" +
                                                 objYB.Memoa + "','" +
                                                 objYB.UVersion + "')";

                    SqlArr.Add(Sql);
                }

                clsF2 F2Svc = new clsF2();
                F2Svc.DSN = DSN;
                lngRes = F2Svc.ExecuteSQL(SqlArr);               
            }
            catch
            {
                //throw Exp;
                return 0;
            }

            return lngRes;
        }

        /// <summary>
        /// (医保)传送住院收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, DataTable dt)
        {
            long lngRes = 0;
            string Sql = "";

            try
            {
                ArrayList SqlArr = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    DataRow dr = dt.Rows[i];

                    Sql = @"insert into mashxm (hos_code, zyno, zysno, xmcode, xmdes, xmunt, xmqnt, 
                                             xmprc, xmamt, trndate, trnflag, memoa, u_version) values ('" +
                                                 dr["hos_code"].ToString() + "','" +
                                                 dr["zyno"].ToString() + "'," +
                                                 dr["zysno"].ToString() + ",'" +
                                                 dr["xmcode"].ToString() + "','" +
                                                 dr["xmdes"].ToString() + "','" +
                                                 dr["xmunt"].ToString() + "'," +
                                                 dr["xmqnt"].ToString() + "," +
                                                 dr["xmprc"].ToString() + "," +
                                                 dr["xmamt"].ToString() + ",'" +
                                                 Convert.ToDateTime(dr["trndate"].ToString()).ToString("yyyy-MM-dd") + "','" +
                                                 dr["trnflag"].ToString() + "','" +
                                                 dr["memoa"].ToString() + "','" +
                                                 dr["u_version"].ToString() + "')";

                    SqlArr.Add(Sql);
                }

                clsF2 F2Svc = new clsF2();
                F2Svc.DSN = DSN;
                lngRes = F2Svc.ExecuteSQL(SqlArr);
            }
            catch
            {
                //throw Exp;
                return 0;
            }

            return lngRes;
        }
        #endregion

        #region (医保)下载医保前置机数据
        /// <summary>
        /// (医保)下载医保前置机数据
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngDownloadYBData(string DSN, string Hospcode, string ZYNo, string ZYSno, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {               
                string SQL = @"select * from mashxm where hos_code = '" + Hospcode + "' and zyno = '" + ZYNo + "' and zysno = " + ZYSno; 

                clsF2 f2 = new clsF2();
                f2.DSN = DSN;
                lngRes = f2.GetDatatable(SQL, out dt);
            }
            catch
            {
                //throw Exp;
                return 0;
            }

            return lngRes;
        }
        #endregion

        #region (医保)查询传送收费项目是否成功
        /// <summary>
        /// (医保)查询传送收费项目是否成功
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <returns></returns>
        public bool m_blnCheckSendRes(string DSN, string Hospcode, string ZYNo, string ZYSno)
        {
            long lngRes = 0;
            string SQL = @"select count(zyno) from mashxm where hos_code = '" + Hospcode + "' and zyno = '" + ZYNo + "' and zysno = " + ZYSno;
            bool IsSuccess = false;

            try
            {
                DataTable dt = new DataTable();
                clsF2 f2 = new clsF2();
                f2.DSN = DSN;
                lngRes = f2.GetDatatable(SQL, out dt);
                if (lngRes > 0)
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                    {
                        IsSuccess = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return IsSuccess;
        }
        #endregion

        #region (医保)传送时HIS事务失败，手工删除传送数据
        /// <summary>
        /// (医保)传送时HIS事务失败，手工删除传送数据
        /// </summary>
        /// <param name="billno"></param>
        /// <returns></returns>
        public long m_lngDelybdata(string DSN, string ZYNo, string ZYSno)
        {
            try
            {
                string SQL = @"delete from mashxm where zyno = '" + ZYNo + "' and zysno = " + ZYSno;
                long rows = 0;

                clsF2 F2Svc = new clsF2();
                F2Svc.DSN = DSN;
                long l = F2Svc.ExecuteSQL(SQL, ref rows);
            }
            catch
            {
                return 0;
            }

            return 1;
        }
        #endregion

        #region (医保)获取医保结算明细
        /// <summary>
        /// (医保)获取医保结算明细
        /// </summary>
        /// <param name="Hospcode"></param>        
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <param name="YbType">1 普通 2 公务员</param>
        /// <returns></returns>      
        public long m_lngGetybjsmx(string DSN, string Hospcode, string ZYNo, string ZYSno, out DataTable dtRecord, out int YbType)
        {
            YbType = 0;
            dtRecord = new DataTable();
            long lngRes = 0;
            string SQL = "";       

            try
            {
                clsF2 f2 = new clsF2();
                f2.DSN = DSN;

                SQL = @"select count(a.medno) 
                          from mashbzjs a 
                         where a.hos_code = '" + Hospcode + @"' 
                           and a.zyno = '" + ZYNo + "' and a.zysno = " + ZYSno + @" 
                           and upper(a.trnflg) = 'T'";

                DataTable dt;
                lngRes = f2.GetDatatable(SQL, out dt);
                if (lngRes > 0)
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                    {
                        YbType = 1;

                        SQL = @"select a.*  
                                  from mashzfjs a
                                 where a.hos_code = '" + Hospcode + @"' 
                                   and a.zyno = '" + ZYNo + "' and a.zysno = " + ZYSno + @" 
                                   and upper(a.trnflg) = 'T'";

                        lngRes = f2.GetDatatable(SQL, out dtRecord);
                    }
                    else
                    {
                        YbType = 2;

                        SQL = @"select a.*  
                                  from mashbzjs a
                                 where a.hos_code = '" + Hospcode + @"' 
                                   and a.zyno = '" + ZYNo + "' and a.zysno = " + ZYSno + @" 
                                   and upper(a.trnflg) = 'T'";

                        lngRes = f2.GetDatatable(SQL, out dtRecord);
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

        #region (医保)试算接口
        /// <summary>
        /// (医保)试算接口
        /// </summary>
        /// <param name="vyydm">医院代码</param>
        /// <param name="vzyhm">住院号</param>
        /// <param name="vzych">住院次数</param>
        /// <param name="verdm">返回值代码</param>
        /// <param name="verms">返回值信息</param>
        /// <returns></returns>
        [DllImport("ado_zyss.dll")]
        public static extern bool ZYSS(string vyydm, string vzyhm, int vzych, ref string verdm, ref string verms);
        
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

                if (lngRes > 0)
                {
                    string OutDm = "";
                    string OutMs = "";

                    try
                    {
                        bool ret = ZYSS(HospCode, Zyh, Zycs, ref OutDm, ref OutMs);

                        if (!ret)
                        {
                            OutErrMsg = OutDm + "   " + OutMs;
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        OutErrMsg = ex.Message;
                        return 0;
                    }
                }

                SQL = @"select zl19, yb02 from ybad11 where trim(zyhm) || to_char(zych) = ( select a.inpatientid_chr || to_char(?)
                                                                                              from t_opr_bih_register a
                                                                                             where a.registerid_chr = ? )";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = Zycs;
                ParamArr[1].Value = RegID;

                DataTable dtMain = new DataTable();

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtMain, ParamArr);

                if (lngRes > 0 && dtMain.Rows.Count == 1)
                {
                    TotalMoney = this.ConvertObjToDecimal(dtMain.Rows[0]["zl19"]);
                    InsuredMoney = this.ConvertObjToDecimal(dtMain.Rows[0]["yb02"]);
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

        #region 江门台山医保结算
        /// <summary>
        /// 江门台山医保结算
        /// </summary>
        /// <param name="p_strlsh0"></param>
        /// <param name="p_inpatientid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertRegisterCharge(string p_strlsh0, string p_inpatientid)
        {
            long lngRes = 0;
            DataTable dtResult = new DataTable();

            string strSQL = @"select a.patientid_chr, a.registerid_chr, a.orderid_chr, a.chargeitemid_chr,
                                     a.chargeitemname_chr, a.unit_vchr, a.unitprice_dec, a.amount_dec,
                                     a.operator_chr, a.status_int, a.pstatus_int, a.curareaid_chr,
                                     a.chargedoctorid_chr, a.chargedoctor_vchr, b.insuranceid_chr,
                                     c.inpatientid_chr, d.executetype_int, d.name_vchr,
                                     d.startdate_dat, d.finishdate_dat, d.status_int as orderstatus
                                from t_opr_bih_patientcharge a,
                                     t_bse_chargeitem b,
                                     t_opr_bih_register c,
                                     t_opr_bih_order d
                               where a.chargeitemid_chr = b.itemid_chr(+)
                                 and a.registerid_chr = c.registerid_chr(+)
                                 and a.orderid_chr = d.orderid_chr(+)
                                 and a.status_int = 1
                                 and a.pstatus_int > 0
                                 and a.pstatus_int < 3
                                 and c.inpatientid_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
                IDataParameter[] objDPArr;
                objSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_inpatientid;
                lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objSvc.Dispose();

                int dtCount = dtResult.Rows.Count;
                DataRow dr = null;

                if (dtCount == 0)
                    return 0;

                com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService objYBSvc = new com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService();
                string[] strSQLArr = new string[dtCount + 1];
                string strSQL1 = "";
                string strinPatientID = "";
                for (int i1 = 0; i1 < dtCount; i1++)
                {
                    strSQL = @"insert into zy_yzbjb0
                                      (zylsh0, zyhao0, zyfwbm,
                                       yzlxbh, xmbhao, xmmc00,
                                       xmdjia, xmsl00, csjl00, qssj00, fyqssj,
                                       jzsj00, tempid, yzysbh,jsbz00
                                      )
                               values (";

                    dr = dtResult.Rows[i1];
                    StringBuilder sb = new StringBuilder();
                    DateTime datTmp;
                    string strTemp = null;

                    sb.Append(p_strlsh0 + ", '");
                    if (dr["inpatientid_chr"].ToString().Length > 9)
                    {
                        strTemp = dr["inpatientid_chr"].ToString().Substring(dr["inpatientid_chr"].ToString().Length - 9, 9);
                        sb.Append(strTemp + "', '");
                    }
                    else
                    {
                        strTemp = dr["inpatientid_chr"].ToString();
                        sb.Append(strTemp + "', '");
                    }
                    strinPatientID = strTemp;//赋给删除语句的条件值

                    if (dr["curareaid_chr"].ToString().Length > 6)
                    {
                        strTemp = dr["curareaid_chr"].ToString().Substring(dr["curareaid_chr"].ToString().Length - 6, 6);
                        sb.Append(strTemp + "', ");
                    }
                    else
                    {
                        strTemp = dr["curareaid_chr"].ToString();
                        sb.Append(strTemp + "', ");
                    }

                    sb.Append("1 , '");//我们系统长嘱都是转成临嘱来执行的

                    if (dr["insuranceid_chr"].ToString().Length > 8)
                    {
                        strTemp = dr["insuranceid_chr"].ToString().Substring(dr["inpatientid_chr"].ToString().Length - 8, 8);
                        sb.Append(strTemp + "', '");
                    }
                    else
                    {
                        strTemp = dr["insuranceid_chr"].ToString();
                        sb.Append(strTemp + "', '");
                    }

                    strTemp = m_strCutString(dr["name_vchr"].ToString(), 24);
                    sb.Append(strTemp + "', ");

                    if (!string.IsNullOrEmpty(dr["unitprice_dec"].ToString()))
                    {
                        sb.Append(dr["unitprice_dec"].ToString() + " ,");
                    }
                    else
                    {
                        sb.Append("0 ,");
                    }

                    if (!string.IsNullOrEmpty(dr["amount_dec"].ToString()))
                    {
                        sb.Append(dr["amount_dec"].ToString() + " ,");
                    }
                    else
                    {
                        sb.Append("0 ,");
                    }

                    sb.Append("1 ,");

                    if (string.IsNullOrEmpty(dr["startdate_dat"].ToString()))
                    {
                        sb.Append("to_char(sysdate, 'yyyymmddhh24mi'), ");
                    }
                    else
                    {
                        datTmp = Convert.ToDateTime(dr["startdate_dat"]);
                        strTemp = datTmp.ToString("yyyyMMdd");
                        sb.Append("'" + strTemp + "', ");
                    }

                    if (string.IsNullOrEmpty(dr["startdate_dat"].ToString()))
                    {
                        sb.Append("null, ");
                    }
                    else
                    {
                        datTmp = Convert.ToDateTime(dr["startdate_dat"]);
                        strTemp = datTmp.ToString("yyyyMMdd");
                        sb.Append("'" + strTemp + "', ");
                    }

                    if (string.IsNullOrEmpty(dr["finishdate_dat"].ToString()))
                    {
                        sb.Append("null, ");
                    }
                    else
                    {
                        datTmp = Convert.ToDateTime(dr["finishdate_dat"]);
                        strTemp = datTmp.ToString("yyyyMMdd");
                        sb.Append("'" + strTemp + "', ");
                    }
 
                    sb.Append("'" + i1.ToString() + "', '");
                    sb.Append(dr["chargedoctorid_chr"].ToString() + "', ");
                    
                    strTemp = dr["pstatus_int"].ToString();
                    switch (int.Parse(strTemp))
                    {
                        case 0:
                        case 1:
                        case 2:
                            strTemp = "0";
                            break;
                        case 3:
                        case 4:
                            strTemp = "1";
                            break;
                        default:
                            strTemp = "0";
                            break;
                    }                   

                    sb.Append(strTemp);
                    strSQL += sb.ToString() + ")";
                    if (i1 == 0)
                    {
                        strSQL1 = @"delete from zy_yzbjb0 where zyhao0 = '" + strinPatientID + "'";
                        strSQLArr[i1] = strSQL1;
                    }
                    strSQLArr[i1 + 1] = strSQL;
                }
                lngRes = objYBSvc.DoExcute(strSQLArr);
                objYBSvc.Dispose();
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objText = new clsLogText();
                objText.LogError(ex);
            }

            return lngRes;
        }

        /// <summary>
        /// 插入医保病人住院信息
        /// </summary>
        /// <param name="p_strlsh0"></param>
        /// <param name="p_inpatientid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertRegister(string p_strlsh0, string p_inpatientid)
        {
            long lngRes = -1;
            DataTable dtResult = new DataTable();

            string strSQL = @"select a.registerid_chr, a.inpatientid_chr, a.inpatient_dat, a.areaid_chr,
                                     a.bedid_chr, a.inareadate_dat, a.mzdiagnose_vchr, b.homeaddress_vchr,
                                     b.birth_dat, b.insuranceid_vchr, b.homephone_vchr, b.lastname_vchr,
                                     b.sex_chr, b.idcard_chr, b.operatorid_chr as inhospital_operator,
                                     b.govcard_chr, c.code_chr, d.outhospital_dat,
                                     d.operatorid_chr as outhospital_operator, d.diagnose_vchr,
                                     d.diseasetype_int, e.deptname_vchr, f.lastname_vchr as reg_operator,
                                     h.paytypeno_vchr
                                from t_opr_bih_register a,
                                     t_opr_bih_registerdetail b,
                                     t_bse_bed c,
                                     t_opr_bih_leave d,
                                     t_bse_deptdesc e,
                                     t_bse_employee f,
                                     t_bse_patient g,
                                     t_bse_patientpaytype h
                               where a.registerid_chr = b.registerid_chr
                                 and a.registerid_chr = d.registerid_chr
                                 and a.deptid_chr = e.deptid_chr(+)
                                 and a.patientid_chr = g.patientid_chr(+)
                                 and g.paytypeid_chr = h.paytypeid_chr
                                 and a.inpatientid_chr = ?
                                 and a.pstatus_int = 2
                                 and b.registerid_chr = c.bihregisterid_chr(+)
                                 and b.operatorid_chr = f.empid_chr(+)
                                 and d.status_int = 1";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
                IDataParameter[] objDPArr;
                objSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_inpatientid;
                lngRes = objSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
              
                DataRow drPatientInfo = null;
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    drPatientInfo = dtResult.Rows[0];
                }
                dtResult.Dispose();
                objSvc.Dispose();
               
                #region 插入台山旧的His系统 baojian.mo
                if (drPatientInfo == null)
                {
                    return 0;
                }
                else
                {
                    com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService objYBSvc = new com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService(); //Created by baojian.mo
                    string strSQL1 = @"delete from zy_zydjb0 where zyhao0 = '";

                    strSQL = @"insert into zy_zydjb0
                                              (zylsh0, zyhao0, brxm00, brxbie,
                                               brnl00, brdzhi, brlxdh, sfzhao,
                                               zydjrq, zyrqi0, zyfwbm,
                                               ksmc00, cwbhao, zyyyin, ysxm00,
                                               bzhong,
                                               cydjr0, ylbxh1, cyzd00, sffsbh
                                              )
                                       values (";
                    StringBuilder sb = new StringBuilder();
                    DateTime datTmp;
                    string strTemp = null;

                    sb.Append(p_strlsh0 + ", '");
                    if (drPatientInfo["inpatientid_chr"].ToString().Length > 9)
                    {
                        strTemp = drPatientInfo["inpatientid_chr"].ToString().Substring(drPatientInfo["inpatientid_chr"].ToString().Length - 9, 9);
                        sb.Append(strTemp + "', '");//截后面9位
                    }
                    else
                    {
                        strTemp = drPatientInfo["inpatientid_chr"].ToString();
                        sb.Append(strTemp + "', '");
                    }

                    //<------------------------
                    strSQL1 += strTemp + "'";
                    //------------------------>

                    sb.Append(drPatientInfo["lastname_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["sex_chr"].ToString() + "', ");

                    if (string.IsNullOrEmpty(drPatientInfo["birth_dat"].ToString()))
                    {
                        sb.Append("null, '");
                    }
                    else
                    {
                        datTmp = DateTime.Parse(drPatientInfo["birth_dat"].ToString());
                        strTemp = new clsBrithdayToAge().m_strGetAge(datTmp);
                        sb.Append("'" + this.m_strCutString(strTemp) + "', '");
                    }

                    sb.Append(drPatientInfo["homeaddress_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["homephone_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["idcard_chr"].ToString() + "', ");

                    if (string.IsNullOrEmpty(drPatientInfo["inpatient_dat"].ToString()))
                    {
                        sb.Append("null, ");
                    }
                    else
                    {
                        datTmp = Convert.ToDateTime(drPatientInfo["inpatient_dat"]);
                        strTemp = datTmp.ToString("yyyyMMdd");
                        sb.Append("'" + strTemp + "', ");
                    }

                    if (string.IsNullOrEmpty(drPatientInfo["inareadate_dat"].ToString()))
                    {
                        sb.Append("null, '");
                    }
                    else
                    {
                        datTmp = Convert.ToDateTime(drPatientInfo["inareadate_dat"]);
                        strTemp = datTmp.ToString("yyyyMMdd");
                        sb.Append("'" + strTemp + "', '");
                    }

                    strTemp = drPatientInfo["areaid_chr"].ToString();
                    if (strTemp.Length > 6)
                    {
                        strTemp = strTemp.Substring(strTemp.Length - 6, 6);
                    }
                    sb.Append(strTemp + "', '");
                    sb.Append(drPatientInfo["deptname_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["code_chr"].ToString() + "', '");
                    sb.Append(drPatientInfo["mzdiagnose_vchr"].ToString() + "', '");

                    strTemp = m_strCutString(drPatientInfo["reg_operator"].ToString(), 8);
                    sb.Append(strTemp + "', '");
                    sb.Append(drPatientInfo["diseasetype_int"].ToString() + "', ");

                    //if (string.IsNullOrEmpty(drPatientInfo["outhospital_dat"].ToString()))
                    //{
                    //    sb.Append("null, null, ");
                    //}
                    //else
                    //{
                    //    datTmp = Convert.ToDateTime(drPatientInfo["outhospital_dat"]);
                    //    strTemp = datTmp.ToString("yyyyMMdd");
                    //    sb.Append("'" + strTemp + "', '" + strTemp + "', ");
                    //}

                    sb.Append("'" + drPatientInfo["outhospital_operator"].ToString() + "', '");
                    sb.Append(drPatientInfo["insuranceid_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["diagnose_vchr"].ToString() + "', '");
                    sb.Append(drPatientInfo["paytypeno_vchr"].ToString() + "'");

                    strSQL += sb.ToString() + ")";
                    lngRes = objYBSvc.DoExcute(strSQL1);
                    lngRes = objYBSvc.DoExcute(strSQL);
                    objYBSvc.Dispose();
                }
                #endregion
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objText = new clsLogText();
                objText.LogError(ex);
            }
            return lngRes;
        }

        /// <summary>
        /// 接收医保数据
        /// </summary>
        /// <param name="strlsh0"></param>
        /// <param name="strYBpay"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBpay(string strRegisterID, out string strMedno, out string strYBpay)
        {
            long lngRes = 0;
            strMedno = "";
            strYBpay = "";
            DataTable dtResult = new DataTable();
            
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                string strSQL = @"select a.extendid_vchr, a.insuredsum_mny
                                    from t_opr_bih_register a
                                   where a.registerid_chr = ?";

                IDataParameter[] objParam = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParam);
                objParam[0].Value = strRegisterID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParam);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    strMedno = dtResult.Rows[0]["extendid_vchr"].ToString();
                    strYBpay = dtResult.Rows[0]["insuredsum_mny"].ToString();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objText = new clsLogText();
                objText.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 删除旧HIS上传信息
        /// </summary>
        /// <param name="p_registerid"></param>
        [AutoComplete]
        public long m_lngDelYBInfo(string strlsh0)
        {
            long lngRes = 0;
            string[] strSqlList = new string[2];

            strSqlList[0] = @"delete from zy_zydjb0 where zylsh0 = " + strlsh0;
            strSqlList[1] = @"delete from zy_yzbjb0 where zylsh0 = " + strlsh0;
            try
            {
                com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService objYBSvc = new com.digitalwave.iCare.middletier.TSZZYHRPServiceYB.clsTSYBHRPService();
                lngRes = objYBSvc.DoExcute(strSqlList);
                objYBSvc.Dispose();
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #region 截取指定长度的字符串(汉字长度视为2)
        /// <summary>
        /// 截取指定长度的字符串(汉字长度视为2)
        /// baojian.mo add in 2007.12.13
        /// </summary>
        /// <param name="p_strInputString">输入字符串</param>
        /// <param name="length">保留位数</param>
        /// <returns></returns>
        private string m_strCutString(string p_strInputString, int length)
        {
            ASCIIEncoding objascii = new ASCIIEncoding();
            string strTmp = "";
            int intlen = 0;
            byte[] s = objascii.GetBytes(p_strInputString);
            for (int i1 = 0; i1 < s.Length; i1++)
            {
                if ((int)s[i1] == 63)
                {
                    intlen++;
                }
                intlen++;

                if (intlen > length)
                    break;
                try
                {
                    strTmp += p_strInputString.Substring(i1, 1);
                }
                catch
                {
                    break;
                }
            }
            return strTmp;
        }

        /// <summary>
        /// 截取含汉字字符串
        /// baojian.mo add in 2007.12.13 
        /// </summary>
        /// <param name="p_strInputString">输入字符串</param>
        /// <param name="intMode"></param>
        /// <returns></returns>
        private string m_strCutString(string p_strInputString)
        {
            ASCIIEncoding objascii = new ASCIIEncoding();
            string strTmp = "";
            byte[] s = objascii.GetBytes(p_strInputString);
            for (int i1 = 0; i1 < s.Length; i1++)
            {
                if ((int)s[i1] == 63)
                {
                    break;//出现汉字即结束循环
                }
                try
                {
                    strTmp += p_strInputString.Substring(i1, 1);
                }
                catch
                {
                    break;
                }
            }
            return strTmp;
        }
        #endregion
        #endregion
    }
}

