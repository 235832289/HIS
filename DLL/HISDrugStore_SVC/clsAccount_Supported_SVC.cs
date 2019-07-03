using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房帐务期结转
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsAccount_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药房总帐表内容

        /// <summary>
        /// 获取药房总帐表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccout(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAccountID, out clsDS_Account p_objRecord)
        {
            p_objRecord = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int,
       t.accountid_chr,
       t.drugstoreid_chr,
       t.comment_vchr,
       t.beginretailfigure_int,
       t.instorageretailfigure_int,
       t.outstorageretailfigure_int,
       t.reciperetailfigure_int,
       t.checkretailfigure_int,
       t.adjustretailfigure_int,
       t.endretailfigure_int,
       t.putmedretailfigure_int
  from t_ds_account t
 where t.drugstoreid_chr = ?
   and t.accountid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_objRecord = new clsDS_Account();
                    DataRow drCurrent = dtbValue.Rows[0];
                    p_objRecord.m_dblBEGINRETAILFIGURE_INT = Convert.ToDouble(drCurrent["beginretailfigure_int"]);
                    p_objRecord.m_dblINSTORAGERETAILFIGURE_INT = Convert.ToDouble(drCurrent["instorageretailfigure_int"]);
                    p_objRecord.m_dblOUTSTORAGERETAILFIGURE_INT = Convert.ToDouble(drCurrent["outstorageretailfigure_int"]);
                    p_objRecord.m_dblRECIPERETAILFIGURE_INT = Convert.ToDouble(drCurrent["reciperetailfigure_int"]);
                    p_objRecord.m_dblCHECKRETAILFIGURE_INT = Convert.ToDouble(drCurrent["checkretailfigure_int"]);
                    p_objRecord.m_dblADJUSTRETAILFIGURE_INT = Convert.ToDouble(drCurrent["adjustretailfigure_int"]);
                    p_objRecord.m_dblENDRETAILFIGURE_INT = Convert.ToDouble(drCurrent["endretailfigure_int"]);
                    p_objRecord.m_lngSERIESID_INT = Convert.ToInt64(drCurrent["SERIESID_INT"]);
                    p_objRecord.m_strACCOUNTID = p_strAccountID;
                    p_objRecord.m_strCOMMENT_VCHR = drCurrent["COMMENT_VCHR"].ToString();
                    p_objRecord.m_dblPutMedRetailFigure_INT = drCurrent["putmedretailfigure_int"].ToString() == ""?0D:Convert.ToDouble(drCurrent["putmedretailfigure_int"]);
                    p_objRecord.m_strDrugStoreid = p_strStorageID;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 生成帐表
        /// <summary>
        /// 生成帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_objAccount">帐务表</param>
        /// <param name="p_lngSEQArr">序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGenarateAccount(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string m_strDrugStoreid, out clsDS_Account p_objAccount, out long[] p_lngSEQArr,int m_intTransferMode,long m_lngCheckSeqid)
        {
            p_objAccount = new clsDS_Account();
            p_lngSEQArr = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.ipretailprice_int,
       t.opretailprice_int,
       t.ipamount_int,
       t.opamount_int,
       t.chittyid_vchr,
       t.ipnewretailprice_int,
       t.opnewretailprice_int,
       t.seriesid_int,
       t.type_int,
       t.packqty_dec
  from t_ds_account_detail t, t_bse_medicine b
 where (t.state_int = 1 or t.state_int = 2)
   and t.operatedate_dat between ? and ?
   and t.drugstoreid_int = ?
   and t.isend_int = 0
   and t.medicineid_chr = b.medicineid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = m_strDrugStoreid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                int intRowsCount = 0;
                if (dtbValue == null)
                {
                    intRowsCount = 0;
                }
                else
                {
                    intRowsCount = dtbValue.Rows.Count;
                }

                DataRow drCurrent = null;
                int intProcessType = 0;
                p_objAccount.m_strDrugStoreid = m_strDrugStoreid;
                p_lngSEQArr = new long[intRowsCount];

                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtbValue.Rows[iRow];
                    intProcessType = Convert.ToInt16(drCurrent["type_int"]);
                    p_lngSEQArr[iRow] = Convert.ToInt64(drCurrent["seriesid_int"]);

                    switch (intProcessType)
                    {
                        case 1://入库
                            p_objAccount.m_dblINSTORAGERETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                            break;
                        case 2://出库

                            p_objAccount.m_dblOUTSTORAGERETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                            break;
                        case 3://初始化

                            p_objAccount.m_dblBEGINRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                            break;
                        case 0://调价
                            if (drCurrent["opnewretailprice_int"] != DBNull.Value && drCurrent["opretailprice_int"] != DBNull.Value && drCurrent["packqty_dec"] != DBNull.Value && drCurrent["ipamount_int"]!=DBNull .Value )
                            p_objAccount.m_dblADJUSTRETAILFIGURE_INT += Math.Round((Convert.ToDouble(drCurrent["opnewretailprice_int"]) - Convert.ToDouble(drCurrent["opretailprice_int"])) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                            break;
                    }
                }

                //bool blnIsHostpital = false;//是否住院药房
//                strSQL = @"select a.medstoretype_int
//  from t_bse_medstore a
// where a.deptid_chr = ?";
//                objDPArr = null;
//                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
//                objDPArr[0].Value = m_strDrugStoreid;
//                DataTable dtbTemp = new DataTable();
//                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objDPArr);
                //if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                //{
                //    if (Convert.ToInt16(dtbTemp.Rows[0][0]) == 2)
                //        blnIsHostpital = true;
                //}

                //if (blnIsHostpital)
                //{
                    strSQL = @"select a.ipretailprice_int,
       a.opretailprice_int,
       a.ipamount_int,
       a.opamount_int,
       a.seriesid_int,
       a.type_int,
       b.packqty_dec
  from t_ds_putmedaccount_detail a, t_bse_medicine b
 where a.state_int = 1
   and a.operatedate_dat between ? and ?
   and a.drugstoreid_int = ?
   and a.isend_int = 0
   and a.medicineid_chr = b.medicineid_chr";
                //}
                //else
                //{
//                    strSQL = @"select a.ipretailprice_int,
//          a.opretailprice_int,
//          a.ipamount_int,
//          a.opamount_int,
//          a.seriesid_int,
//          a.type_int,
//          b.packqty_dec
//     from t_ds_recipeaccount_detail a, t_bse_medicine b
//    where a.state_int = 1
//      and a.operatedate_dat between ? and ?
//      and a.drugstoreid_int = ?
//      and a.isend_int = 0
//      and a.medicineid_chr = b.medicineid_chr";
                //}

                dtbValue = null;

                objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = m_strDrugStoreid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                intRowsCount = 0;
                if (dtbValue == null)
                {
                    intRowsCount = 0;
                }
                else
                {
                    intRowsCount = dtbValue.Rows.Count;
                }

                drCurrent = null;


                //if (blnIsHostpital)
                //{
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = dtbValue.Rows[iRow];

                        if (Convert.ToByte(drCurrent["type_int"]) == 1)
                        {
                            p_objAccount.m_dblPutMedRetailFigure_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);

                        }
                        else
                        {
                            p_objAccount.m_dblPutMedRetailFigure_INT  -= Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                        }

                    }
                //}
                //else
                //{
                    strSQL = @"select a.ipretailprice_int,
          a.opretailprice_int,
          a.ipamount_int,
          a.opamount_int,
          a.seriesid_int,
          a.type_int,
          b.packqty_dec
     from t_ds_recipeaccount_detail a, t_bse_medicine b
    where a.state_int = 1
      and a.operatedate_dat between ? and ?
      and a.drugstoreid_int = ?
      and a.isend_int = 0
      and a.medicineid_chr = b.medicineid_chr";
                    //}

                    dtbValue = null;

                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = p_dtmBegin;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmEnd;
                    objDPArr[2].Value = m_strDrugStoreid;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                    intRowsCount = 0;
                    if (dtbValue == null)
                    {
                        intRowsCount = 0;
                    }
                    else
                    {
                        intRowsCount = dtbValue.Rows.Count;
                    }

                    drCurrent = null;

                //
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = dtbValue.Rows[iRow];

                        if (Convert.ToByte(drCurrent["type_int"]) == 2)
                        {
                            p_objAccount.m_dblRECIPERETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);

                        }
                        else
                        {
                            p_objAccount.m_dblRECIPERETAILFIGURE_INT -= Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["ipamount_int"]), 8);
                        }

                    }
                //}

                strSQL = @" select a.endretailfigure_int
   from t_ds_account a
  where a.drugstoreid_chr = ?
  order by a.seriesid_int desc";


                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strDrugStoreid;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    drCurrent = dtbValue.Rows[0];
                    p_objAccount.m_dblBEGINRETAILFIGURE_INT = Math.Round(Convert.ToDouble(drCurrent["endretailfigure_int"]), 8);

                }
                if (m_intTransferMode == 0)
                {
                    strSQL = @" select t.iprealgross_int, t.opretailprice_int, t.packqty_dec
   from t_ds_storage_detail t
  where t.drugstoreid_chr = ?
    and t.status = 1";

                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = m_strDrugStoreid;
                }
                else
                {
                    strSQL = @"select t.opcheckgross_int,
       t.ipcheckgross_int,
       t.opchargeflg_int,
       t.ipchargeflg_int,
       t.opretailprice_int,
       t.packqty_dec
      from t_ds_drugstorecheck_detail t
     where t.status_int = 1
       and t.seriesid2_int = ?";

                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = m_lngCheckSeqid;
                }
                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    intRowsCount = dtbValue.Rows.Count;
                    drCurrent = null;
                    if(m_intTransferMode == 0)
                    {
                        for(int i = 0; i < intRowsCount; i++)
                        {
                            drCurrent = dtbValue.Rows[i];
                            if(drCurrent["opretailprice_int"] != DBNull.Value && drCurrent["packqty_dec"] != DBNull.Value && drCurrent["iprealgross_int"] != DBNull.Value)
                                p_objAccount.m_dblENDRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * Convert.ToDouble(drCurrent["iprealgross_int"]), 8);
                        }
                    }
                    else
                    {
                        for(int i = 0; i < intRowsCount; i++)
                        {
                            drCurrent = dtbValue.Rows[i];
                            if(drCurrent["opretailprice_int"] != DBNull.Value && drCurrent["packqty_dec"] != DBNull.Value && drCurrent["opcheckgross_int"] != DBNull.Value && drCurrent["ipcheckgross_int"] != DBNull.Value)
                                p_objAccount.m_dblENDRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["opretailprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]) * (Convert.ToDouble(drCurrent["opcheckgross_int"]) * Convert.ToDouble(drCurrent["packqty_dec"]) + Convert.ToDouble(drCurrent["ipcheckgross_int"])), 8);
                        }
                    }
                }
                objHRPServ.Dispose();
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion    

        #region 最新的帐务期号

        /// <summary>
        /// 最新的帐务期号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestAccountID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.accountid_chr)
  from t_ds_accountperiod t
 where t.accountid_chr like ?
   and t.drugstoreid_chr = ?";

                DataTable dtbValue = null;
                clsDS_Public_Supported_SVC clsPub = new clsDS_Public_Supported_SVC();
                DateTime dtmNow = DateTime.Now;
                clsPub.m_lngGetCurrentDateTime(out dtmNow);
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = dtmNow.ToString("yyyy") + "%";
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = dtmNow.ToString("yyyy") + "01";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = dtmNow.ToString("yyyy") + "01";
                    }
                    else
                    {
                        double dblID = 0d;
                        if (double.TryParse(strTemp, out dblID))
                        {
                            p_strID = (dblID + 1).ToString();
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
         #endregion
     
        #region  获取最近一次盘点时间作为本期帐务期的结束时间

        /// <summary>
        /// 获取最近一次盘点时间作为本期帐务期的结束时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="m_dtmBeginAccountTime"></param>
        /// <param name="m_dtmEndAccountTime"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccountEndTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime m_dtmBeginAccountTime,out  DateTime m_dtmEndAccountTime,out long m_lngCheckSeqid)
        {
            m_dtmEndAccountTime = DateTime.MinValue;
            m_lngCheckSeqid = 0;
            long lngRes = -1;
            try
            {
                string strSQL = @"select a.examdate_dat, a.seriesid_int
  from t_ds_drugstorecheck a
 where a.examdate_dat > ?
   and a.drugstoreid_chr = ?
 order by a.examdate_dat desc";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = m_dtmBeginAccountTime;
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    m_dtmEndAccountTime = DateTime.MinValue;
                }
                else
                {
                    m_dtmEndAccountTime = Convert.ToDateTime(dtbValue.Rows[0]["examdate_dat"]);
                    m_lngCheckSeqid = Convert.ToInt64(dtbValue.Rows[0]["seriesid_int"]);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
       #endregion
    }
}
