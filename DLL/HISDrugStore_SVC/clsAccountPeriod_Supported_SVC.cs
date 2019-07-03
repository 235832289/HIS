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
    public class clsAccountPeriod_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取帐务期表内容
        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDrugStoreid">药房对应科室ID</param>
        /// <param name="p_dtbAccountData">帐务期表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, string m_strDrugStoreid, out DataTable p_dtbAccountData)
        {
            p_dtbAccountData = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.accountid_chr,
       t.starttime_dat,
       t.endtime_dat,
       t.transfertime_dat,
       t.comment_vchr,
       t.drugstoreid_chr,
       t.seriesid_int
  from t_ds_accountperiod t
 where t.drugstoreid_chr = ?
  order by t.accountid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strDrugStoreid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbAccountData, objDPArr);
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
        #region 检查是否有未确定入帐的记录
        /// <summary>
        /// 检查是否有未确定入帐的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasUnConfirmAccount(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out string[] p_strChittyIDArr)
        {
            p_strChittyIDArr = null;
            long lngRes = -1;
            try
            {
                string strSQL = @"select distinct t.chittyid_vchr
  from t_ds_account_detail t
 where t.state_int = 2
   and t.operatedate_dat between ? and ?
   and t.drugstoreid_int = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    p_strChittyIDArr = new string[intRowsCount];
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_strChittyIDArr[iRow] = dtbValue.Rows[iRow][0].ToString();
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
        #region 检查开帐务期内是否存在未审核的记录
        /// <summary>
        /// 检查开帐务期内是否存在未审核的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        /// <param name="p_dtmEndDate">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strHintText">存在未审核记录的单据名称(类型)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasUnCommitRecord(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out string p_strHintText)
        {
            p_strHintText = string.Empty;
            long lngRes = 0;
            try
            {
                #region 入库表

                string strSQL = @"select t.seriesid_int, t.formtype_int
  from t_ds_instorage t, t_ds_instorage_detail d
 where t.makeorder_dat between ? and ?
   and t.status = 1
   and t.drugstoreid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                StringBuilder stbHint = new StringBuilder(100);
                if (dtbValue != null)
                {
                    if (dtbValue.Rows.Count > 0)
                    {
                        stbHint.Append("　入库记录　");
                    }
                }
                #endregion
                #region 出库表

                strSQL = @"select t.seriesid_int, t.formtype_int
  from t_ds_outstorage t,t_ds_outstorage_detail d
 where t.makeorder_dat between ? and ?
   and t.status_int = 1
   and t.drugstoreid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status = 1";

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;
                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {

                    if (dtbValue.Rows.Count > 0)
                    {
                        stbHint.Append("　出库记录　");
                    }

                }
                #endregion

                //                #region 调价表

                //                strSQL = @"select count(t.seriesid_int)
                //  from t_ms_adjustprice t, t_ms_adjustprice_detail d
                // where t.adjustpricedate_dat between ? and ?
                //   and t.formstate_int = 1
                //   and t.storageid_chr = ?
                //   and t.seriesid_int = d.seriesid2_int
                //   and d.status_int = 1";

                //                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                //                objDPArr[0].DbType = DbType.DateTime;
                //                objDPArr[0].Value = p_dtmBeginDate;
                //                objDPArr[1].DbType = DbType.DateTime;
                //                objDPArr[1].Value = p_dtmEndDate;
                //                objDPArr[2].Value = p_strStorageID;

                //                dtbValue = null;
                //                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                //                if (dtbValue != null && dtbValue.Rows.Count == 1)
                //                {
                //                    int intCount = 0;
                //                    if (int.TryParse(dtbValue.Rows[0][0].ToString(), out intCount))
                //                    {
                //                        if (intCount > 0)
                //                        {
                //                            stbHint.Append("　调价记录　");
                //                        }
                //                    }
                //                }
                //                #endregion

                //                #region 盘点表

                //                strSQL = @"select count(t.seriesid_int)
                //  from t_ms_storagecheck t,t_ms_storagecheck_detail d
                // where t.checkdate_dat between ? and ?
                //   and t.status = 1
                //   and t.storageid_chr = ?
                //   and t.seriesid_int = d.seriesid2_int
                //   and d.status_int = 1";

                //                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                //                objDPArr[0].DbType = DbType.DateTime;
                //                objDPArr[0].Value = p_dtmBeginDate;
                //                objDPArr[1].DbType = DbType.DateTime;
                //                objDPArr[1].Value = p_dtmEndDate;
                //                objDPArr[2].Value = p_strStorageID;

                //                dtbValue = null;
                //                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                //                if (dtbValue != null && dtbValue.Rows.Count == 1)
                //                {
                //                    int intCount = 0;
                //                    if (int.TryParse(dtbValue.Rows[0][0].ToString(), out intCount))
                //                    {
                //                        if (intCount > 0)
                //                        {
                //                            stbHint.Append("　盘点记录　");
                //                        }
                //                    }
                //                }
                //                #endregion

                p_strHintText = stbHint.ToString();
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

        #region 药房发药汇总统计
        /// <summary>
        /// 药房发药汇总统计
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable StatMedSend(string startDate, string endDate, string medStoreId)
        {
            DataTable dtStat = null;
            try
            {
                string Sql = @"select c.itemid_chr as 药品编码,
                                       c.itemname_vchr as 药品名称,
                                       c.itemspec_vchr as 规格,
                                       c.unitid_chr as 单位,
                                       c.unitprice_mny as 单价,
                                       sum(c.tolqty_dec) as 数量,
                                       sum(c.tolprice_mny) as 金额,
                                       sum(c.toldiffprice_mny) as 优惠金额
                                  from t_opr_recipesend a
                                 inner join t_opr_recipesendentry b
                                    on a.sid_int = b.sid_int
                                 inner join t_opr_outpatientpwmrecipede c
                                    on b.outpatrecipeid_chr = c.outpatrecipeid_chr
                                    inner join t_opr_outpatientrecipe d on b.outpatrecipeid_chr = d.outpatrecipeid_chr
                                 where a.medstoreid_chr = ?
                                  and a.pstatus_int = 3
                                   and (d.recorddate_dat between ? and ?)
                                 group by c.itemid_chr,
                                          c.itemname_vchr,
                                          c.itemspec_vchr,
                                          c.unitid_chr,
                                          c.unitprice_mny
                                 order by c.itemid_chr";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = medStoreId;
                parm[1].Value = Convert.ToDateTime(Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + " 00:00:00");
                parm[2].Value = Convert.ToDateTime(Convert.ToDateTime(endDate).ToString("yyyy-MM-dd") + " 23:59:59");

                svc.lngGetDataTableWithParameters(Sql, ref dtStat, parm);
                svc.Dispose();
                svc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dtStat;
        }
        #endregion

    }
}
