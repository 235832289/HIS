using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 中标药品入库统计报表
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMedicineAcceptanceSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 汇总
        /// <summary>
        /// 入库汇总
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="dtbValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAcceptance(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select c.vendorname_vchr,
       sum(a.callprice_int * a.amount) callprice_int,
       sum(a.retailprice_int * a.amount) retailprice_int,   
case when sum(a.limitunitprice_mny* a.amount) != 0 then sum(a.limitunitprice_mny * a.amount) else sum(a.retailprice_int * a.amount) end limitunitprice_mny
  from t_ms_instorage_detal a
  join t_ms_instorage b on b.seriesid_int = a.seriesid2_int
  left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 where a.acceptance_int = 1
   and b.storageid_chr = ?
   and (b.state_int = 2 or b.state_int = 3)
   and a.status = 1
   and b.formtype_int = 1
   and b.exam_dat between ? and ?
 group by c.vendorname_vchr
 order by c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return -1;
        }


        /// <summary>
        /// 外退汇总
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="dtbValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAcceptance_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select c.vendorname_vchr,
       sum(b.callprice_int * b.netamount_int) callprice_int,
       sum(b.retailprice_int * b.netamount_int) retailprice_int,   
        case when sum(e.limitunitprice_mny* b.netamount_int) != 0 then sum(e.limitunitprice_mny * b.netamount_int) else sum(e.retailprice_int * b.netamount_int) end limitunitprice_mny
  from t_ms_outstorage_detail b
 inner join t_ms_outstorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
 left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 inner join t_ms_instorage_detal e on b.instorageid_vchr =
                                      e.instorageid_vchr
 where (a.formtype = 2 or a.formtype = 5) and b.status = 1
      and e.medicineid_chr = b.medicineid_chr
      and b.lotno_vchr = e.lotno_vchr
   and e.acceptance_int = 1
   and a.storageid_chr =?
   and (a.status = 2 or a.status = 3)
   and a.examdate_dat between ? and ?
 group by  c.vendorname_vchr 
 order by  c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return -1;
        }


        #endregion

        #region 明细
        /// <summary>
        /// 明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="dtbValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAcceptanceDetal(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select d.assistcode_chr,
       a.medicinename_vch,
       d.medspec_vchr,
       e.medicinepreptypename_vchr,
       d.opunit_chr,
       sum(a.amount) netamount_int,
       a.callprice_int,
       a.retailprice_int,
      a.limitunitprice_mny,
       case when a.limitunitprice_mny =0 then a.retailprice_int else a.limitunitprice_mny end as topprice,
       c.vendorname_vchr,
       d.medicineid_chr
  from t_ms_instorage_detal a
  join t_ms_instorage b on b.seriesid_int = a.seriesid2_int
  left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
  join t_bse_medicine d on a.medicineid_chr = d.medicineid_chr
  join t_aid_medicinepreptype e on d.medicinetypeid_chr =
                                   e.medicinepreptype_chr
 where a.acceptance_int = 1 and b.storageid_chr = ?
 and b.exam_dat between ? and ?
   and (b.state_int = 2 or b.state_int = 3)
and a.status = 1
and b.formtype_int = 1
 group by d.assistcode_chr,
          a.medicinename_vch,
          d.medspec_vchr,
          e.medicinepreptypename_vchr,
          d.opunit_chr,
          a.callprice_int,
          a.retailprice_int,
          a.limitunitprice_mny,
          c.vendorname_vchr,
          d.medicineid_chr
 order by c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// 外退明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="dtbValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAcceptanceDetal_Med(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select 
       d.assistcode_chr,
       b.medicinename_vch,
       d.medspec_vchr,
       f.medicinepreptypename_vchr,
       d.opunit_chr,
       sum(b.netamount_int) netamount_int,
       b.callprice_int,
       b.retailprice_int,
       e.limitunitprice_mny,
       case when e.limitunitprice_mny =0 then b.retailprice_int else e.limitunitprice_mny end as topprice,
       c.vendorname_vchr,
       d.medicineid_chr
  from t_ms_outstorage_detail b
 inner join t_ms_outstorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
 left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 inner join t_ms_instorage_detal e on b.instorageid_vchr =
                                      e.instorageid_vchr
 join t_aid_medicinepreptype f on d.medicinetypeid_chr =
                                   f.medicinepreptype_chr 
 where (a.formtype = 2 or a.formtype = 5) and b.status = 1
    and b.medicineid_chr = e.medicineid_chr
    and b.lotno_vchr = e.lotno_vchr
   and e.acceptance_int = 1
   and a.storageid_chr =?
   and (a.status = 2 or a.status = 3)
   and a.examdate_dat between ? and ?
   group by 
       d.assistcode_chr,
       b.medicinename_vch,
       d.medspec_vchr,
       f.medicinepreptypename_vchr,
       d.opunit_chr,
       b.callprice_int,
       b.retailprice_int,
       e.limitunitprice_mny,
       c.vendorname_vchr,
       d.medicineid_chr
 order by  c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return -1;
        }
        //m_lngGetAcceptanceDetal
        #endregion
    }
}
