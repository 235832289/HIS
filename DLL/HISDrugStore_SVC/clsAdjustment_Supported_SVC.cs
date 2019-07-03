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
    /// 药品调价
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsAdjustment_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    { 
        #region 获取药品调价主表信息
        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.adjustpriceid_vchr,
       a.adjustpricedate_dat,
       a.newdate_dat,
       a.formtype_int,
       a.formstate_int,
       a.creatorid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.comment_vchr,
       c.lastname_vchr creatorname,
       d.lastname_vchr examername,
       case a.formstate_int
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_adjustprice a
 inner join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
                                     and b.status_int = 1
 inner join t_bse_employee c on a.creatorid_chr = c.empid_chr
 left outer join t_bse_employee d on a.examerid_chr = d.empid_chr
 where a.storageid_chr = ?
   and a.adjustpricedate_dat between ? and ?
   and a.formstate_int <> 0
  order by a.adjustpriceid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmSearchBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmSearchEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
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

        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.drugstoreid_chr,
       a.adjustpriceid_vchr,
       a.newdate_dat,
       a.status_int,
       a.creatorid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.comment_vchr,
       c.lastname_vchr creatorname,
       d.lastname_vchr examername,
       case a.status_int
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入账'
       end statusdesc
  from t_ds_adjustprice a
 inner join t_ds_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
                                     and b.status_int = 1
 inner join t_bse_employee c on a.creatorid_chr = c.empid_chr
 left outer join t_bse_employee d on a.examerid_chr = d.empid_chr
 where a.drugstoreid_chr = ?
   and a.newdate_dat between ? and ?
   and a.status_int <> 0
   and b.medicineid_chr = ?
  order by a.adjustpriceid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmSearchBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmSearchEnd;
                objDPArr[3].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
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

        #region 获取药品调价明细
        /// <summary>
        /// 获取药品调价明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_dtbDetail">药品调价明细记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbDetail)
        {
            p_dtbDetail = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       case
         when a.lotno_vchr = 'UNKNOWN' then
          ''
         else
          a.lotno_vchr
       end lotno_vchr,
       a.opcurrentgross_int,
       a.ipcurrentgross_int,
       a.ipoldretailprice_int,
       a.opoldretailprice_int,
       a.reason_vchr,
       a.status_int,
       a.validperiod_dat,
       a.opunit_vchr,
       a.ipunit_vchr,
       b.assistcode_chr,
       b.productorid_chr
  from t_ds_adjustprice_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_ds_adjustprice c on c.seriesid_int = a.seriesid2_int
 where a.seriesid2_int = ?
   and a.status_int = 1
 order by a.medicineid_chr, a.lotno_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbDetail, objDPArr);
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

        #region 根据药品ID获取药品
        /// <summary>
        /// 根据药品ID获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.assistcode_chr,
       a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr,
       a.ipunit_chr,
       a.iprealgross_int,
       a.oprealgross_int,
       a.ipretailprice_int,
       a.opretailprice_int,
       a.lotno_vchr,
       a.dsinstoreid_vchr,
       a.validperiod_dat,
       a.productorid_chr
  from t_ds_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 where a.status = 1
   and a.medicineid_chr = ?
   and a.drugstoreid_chr = ?
 order by b.assistcode_chr,
          a.lotno_vchr,
          a.opretailprice_int,
          a.ipretailprice_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
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

        #region 获取金额
        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.oldretailprice_int,
       a.newretailprice_int,
       a.currentgross_int,
       b.adjustpriceid_vchr,
       b.formstate_int
  from t_ms_adjustprice_detail a, t_ms_adjustprice b
 where a.status_int = 1
   and b.formstate_int <> 0
   and a.seriesid2_int = b.seriesid_int
   and b.adjustpricedate_dat between ? and ?
   and b.storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMoney, objDPArr);
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

        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID,string p_strMedicineID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.oldretailprice_int,
       a.newretailprice_int,
       a.currentgross_int,
       b.adjustpriceid_vchr,
       b.formstate_int
  from t_ms_adjustprice_detail a, t_ms_adjustprice b
 where a.status_int = 1
   and b.formstate_int <> 0
   and a.seriesid2_int = b.seriesid_int
   and b.adjustpricedate_dat between ? and ?
   and b.storageid_chr = ?
   and exists (select c.seriesid2_int
          from t_ms_adjustprice_detail c
         where c.medicineid_chr = ?
           and c.seriesid2_int = b.seriesid_int)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMoney, objDPArr);
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
    }
}
