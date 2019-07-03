using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.HIS
{
    public class clsYB
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsYB()
        {
        }
        #endregion

        #region (医保)获取医保结算明细
        /// <summary>
        /// (医保)获取医保结算明细
        /// </summary>
        /// <param name="Hospcode"></param>
        /// <param name="Billno"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>      
        public long m_lngGetybjsmx(string DSN, string Hospcode, string Billno, out DataTable dtRecord)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @"select b.*, a.*  
                             from masmzhzfjs a,
                                  mashjsmx b
                            where a.medno = b.medno 
                              and a.hos_code = '" + Hospcode + @"' 
                              and a.billno = '" + Billno + "'";

            try
            {
                clsF2 f2 = new clsF2();
                f2.DSN = DSN;
                lngRes = f2.GetDatatable(SQL, out dtRecord);
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

        #region (医保)传送门诊收费数据到医保前置机
        /// <summary>
        /// (医保)传送门诊收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objSQLArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, ArrayList objYBArr, ref string BillNo)
        {
            long lngRes = 0;
            string Sql = ""; 

            try
            {
                if (BillNo.Trim() == "")
                {
                    clsOPChargeSvc objCharge = new clsOPChargeSvc();
                    objCharge.m_mthGenBillNo(out BillNo);
                }

                if (BillNo != "")
                {
                    ArrayList SqlArr = new ArrayList();
                    for (int i = 0; i < objYBArr.Count; i++)
                    {
                        clsYB_VO objYB = objYBArr[i] as clsYB_VO;

                        //由于UI控件DATAGRID自身BUG,合计栏偶尔显示错误，故在此重算【合计 = 数量 * 单价】
                        Sql = @"insert into masmzhxm (hos_code, billno, xmcode, ass_sign, xmdes, xmunt , xmqnt, 
                                                 xmprc, xmamt, trndate, trnflag, memoa, u_version) values ('" +
                                                     objYB.Hoscode + "','" +
                                                     BillNo + "','" +
                                                     objYB.XMCode + "','" +
                                                     objYB.Asssign + "','" +
                                                     objYB.XMDes + "','" +
                                                     objYB.XMUnt + "'," +
                                                     objYB.XMQnt + "," +
                                                     objYB.XMPrc + "," +
                                                     Convert.ToDecimal(objYB.XMQnt * objYB.XMPrc).ToString("0.00") + ",'" +
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
                else
                {
                    return 0;
                }
            }
            catch
            {
                //throw Exp;
                return 0;
            }

            return lngRes;
        }
        #endregion

        #region (医保)检测结算自费项目表是否存在指定的BILLNO
        /// <summary>
        /// (医保)检测结算自费项目表是否存在指定的BILLNO
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="BillNo"></param>      
        public bool m_blnCheckBillNo(string DSN, string Hospcode, string BillNo)
        {
            long lngRes = 0;
            string SQL = @"select count(*) from masmzhzfjs where hos_code = '" + Hospcode + "' and billno = '" + BillNo + "'";
            bool IsExist = false;

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

        #region 查询传送收费项目是否成功
        /// <summary>
        /// 查询传送收费项目是否成功
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public bool m_blnCheckSendRes(string DSN, string Hospcode, string BillNo)
        {
            long lngRes = 0;
            string SQL = @"select count(*) from masmzhxm where hos_code = '" + Hospcode + "' and billno = '" + BillNo + "'";
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

        #region (医保)手工更改记帐单号
        /// <summary>
        /// (医保)手工更改记帐单号
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <returns></returns>
        public long m_lngModifyBillNo(string DSN, string OldBillNo, string NewBillNo)
        {
            try
            {
                string SQL = @"update masmzhxm set billno = '" + NewBillNo + "' where billno = '" + OldBillNo + "'";
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

        #region (医保)传送时HIS事务失败，手工删除传送数据
        /// <summary>
        /// (医保)传送时HIS事务失败，手工删除传送数据
        /// </summary>
        /// <param name="billno"></param>
        /// <returns></returns>
        public long m_lngDelybdata(string DSN, string billno)
        {
            try
            {
                string SQL = @"delete from masmzhxm where billno = '" + billno + "'";
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

    }
}
