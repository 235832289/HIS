using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 获取盘点药品
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsGetStoreCheckMedicine_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 通过顺序号获取药品

        /// <summary>
        /// 通过顺序号获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSortBegin">顺序号段开始号码</param>
        /// <param name="p_strSortEnd">顺序号段结束号码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineBySortNum(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSortBegin, string p_strSortEnd, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = -1;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and d.checkmedicineorder_chr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and d.checkmedicineorder_chr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strSortBegin;
                objDPArr[1].Value = p_strSortEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品代码获取药品
        /// <summary>
        /// 根据药品代码获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineCodeBegin">药品代码段开始代码</param>
        /// <param name="p_strMedicineCodeEnd">药品代码段结束代码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineCodeBegin, string p_strMedicineCodeEnd, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and b.assistcode_chr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and b.assistcode_chr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strMedicineCodeBegin;
                objDPArr[1].Value = p_strMedicineCodeEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品剂型获取药品
        /// <summary>
        /// 根据药品剂型获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicinePreptypeID">药品剂型ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicinePreptype(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicinePreptypeID, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = 0;
            try
            {
                string strType = string.Empty;

                if (!string.IsNullOrEmpty(p_strMedicinePreptypeID))
                {
                    strType = @"
   and c.medicinepreptype_chr = ?";
                }

                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                if (!string.IsNullOrEmpty(p_strMedicinePreptypeID))
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicinePreptypeID;
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品类型获取药品
        /// <summary>
        /// 根据药品类型获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineType(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineTypeID, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = 0;
            try
            {
                string strType = string.Empty;

                if (!string.IsNullOrEmpty(p_strMedicineTypeID))
                {
                    strType = @"
   and b.medicinetypeid_chr = ?";
                }

                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                if (!string.IsNullOrEmpty(p_strMedicineTypeID))
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineTypeID;
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 根据药品类型获取药品
        /// </summary>
        /// <param name="p_objPrincipal">药品类型ID数组</param>
        /// <param name="p_strMedicineTypeIDArr">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_strStorageID">药品数据</param>
        /// <param name="p_dtbMedicine"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineTypeList(System.Security.Principal.IPrincipal p_objPrincipal, System.Collections.ArrayList p_strMedicineTypeIDArr, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = 0;
            try
            {
                string strType = string.Empty;

                if (p_strMedicineTypeIDArr.Count > 0)
                {
                    strType = @"
   and b.medicinetypeid_chr in(";
                    System.Text.StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < p_strMedicineTypeIDArr.Count; i++)
                    {
                        sb.Append("? ,");
                    }
                    strType = strType + sb.Remove(sb.Length - 2, 2).ToString() + ")";
                }
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ? " + strType + @"
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                if (p_strMedicineTypeIDArr.Count > 0)
                {
                    objHRPServ.CreateDatabaseParameter(p_strMedicineTypeIDArr.Count + 1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    for (int i2 = 0; i2 < p_strMedicineTypeIDArr.Count; i2++)
                    {
                        objDPArr[i2 + 1].Value = p_strMedicineTypeIDArr[i2];
                    }
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据货架号获取药品信息

        /// <summary>
        /// 根据货架号获取药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRackNOBegin">货架号码段开始号码</param>
        /// <param name="p_strRackNOEnd">货架号码段结束号码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineRackNO(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRackNOBegin, string p_strRackNOEnd, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and e.storagerackcode_vchr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and e.storagerackcode_vchr between ? and ?
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strRackNOBegin;
                objDPArr[1].Value = p_strRackNOEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取全部药品
        /// <summary>
        /// 获取全部药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = -1;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 realgross_int,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                a.opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 realgross_int,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          a.opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取上一次库存为零的药品
        /// <summary>
        /// 获取上一次库存为零的药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_hstMedicine">盘点药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngGetLastZeroStorageCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out Hashtable p_hstMedicine)
        {
            p_hstMedicine = null;
            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select seriesid_int
  from (select a.seriesid_int
          from t_ds_drugstorecheck a
         where a.status_int <> 0
           and a.drugstoreid_chr = ?
         order by a.seriesid_int desc)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 a.seriesid_int
  from t_ds_drugstorecheck a
 where a.status_int <> 0
   and a.drugstoreid_chr = ?
 order by a.seriesid_int desc";
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                DataTable dtbMainSEQ = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMainSEQ, objDPArr);

                if (dtbMainSEQ == null || dtbMainSEQ.Rows.Count == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                long lngMainSEQ = Convert.ToInt64(dtbMainSEQ.Rows[0][0]);

                strSQL = @"select b.medicineid_chr,        case
        when b.lotno_vchr = 'UNKNOWN' then
         ''
        else
            b.lotno_vchr
        end lotno_vchr, b.indrugstoreid_vchr 
  from t_ds_drugstorecheck_detail b
 where b.seriesid2_int = ?
   and b.iszero_int = 0
   and b.status_int = 1";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngMainSEQ;

                DataTable dtbCheck = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbCheck, objDPArr);
                if (dtbCheck != null)
                {
                    int intRowsCount = dtbCheck.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        DataRow drTemp = null;
                        p_hstMedicine = new Hashtable();
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbCheck.Rows[iRow];
                            string strKey = drTemp["medicineid_chr"].ToString().PadLeft(10, '0') + drTemp["lotno_vchr"].ToString().PadLeft(10, '0') + drTemp["indrugstoreid_vchr"].ToString().PadLeft(13, '0');
                            if (!p_hstMedicine.ContainsKey(strKey))
                                p_hstMedicine.Add(strKey, drTemp["medicineid_chr"].ToString());
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

        #region 获取排除上次盘点时库存为零，本期也为零的药品后的数据
        /// <summary>
        /// 获取排除上次盘点时库存为零，本期也为零的药品后的数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">本期库存数据</param>
        /// <returns></returns>
        [AutoComplete]
        private DataTable m_dtbGetMedicineWithoutLastCheckZero(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DataTable p_dtbMedicine)
        {
            if (p_dtbMedicine == null || p_dtbMedicine.Rows.Count == 0)
            {
                return null;
            }

            Hashtable hstLastIsZero = null;
            long lngRes = m_lngGetLastZeroStorageCheckMedicine(p_objPrincipal, p_strStorageID, out hstLastIsZero);

            if (hstLastIsZero == null || hstLastIsZero.Count == 0)
            {
                return p_dtbMedicine;
            }

            DataRow[] drIsZero = p_dtbMedicine.Select("realgross_int = 0");

            if (drIsZero == null || drIsZero.Length == 0)
            {
                return p_dtbMedicine;
            }

            List<DataRow> lstZero = new List<DataRow>();
            for (int iRow = 0; iRow < drIsZero.Length; iRow++)
            {
                string strKey = drIsZero[iRow]["medicineid_chr"].ToString().PadLeft(10, '0') + drIsZero[iRow]["lotno_vchr"].ToString().PadLeft(10, '0') + drIsZero[iRow]["indrugstoreid_vchr"].ToString().PadLeft(13, '0');
                if (hstLastIsZero.Contains(strKey))
                {
                    lstZero.Add(drIsZero[iRow]);
                }
            }

            if (lstZero.Count > 0)
            {
                foreach (DataRow dr in lstZero)
                {
                    p_dtbMedicine.Rows.Remove(dr);
                }
            }
            return p_dtbMedicine;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="dtMedType"></param>
        [AutoComplete]
        public long m_lngGetMedType(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtMedType)
        {
            long lngRes = 0;
            dtMedType = new DataTable();
            com.digitalwave.security.clsPrivilegeHandleService objPrivilege = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicineSVC", "m_lngGetMedType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select medicinetypeid_chr, medicinetypename_vchr
                                from t_aid_medicinetype";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtMedType);
                objHRPSvc.Dispose();
                objHRPSvc = null;
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

        #region 查询所有药品类型信息

        /// <summary>
        /// 查询所有药品类型信息

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngFindAllMedicineType(
            System.Security.Principal.IPrincipal p_objPrincipal,
            out com.digitalwave.iCare.ValueObject.clsMedicineType_VO[] p_objResultArr)
        {
            p_objResultArr = new com.digitalwave.iCare.ValueObject.clsMedicineType_VO[0];
            long lngRes = 0;
            //权限控制
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicineSVC", "m_lngFindAllMedicineType");
            if (lngRes < 0)
                return -1;

            string strSQL = @"select medicinetypeid_chr, medicinetypename_vchr
                                from t_aid_medicinetype";
            lngRes = m_getMedTypeResult(strSQL, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 输出药品类别的查询结果

        /// <summary>
        /// 输出药品类别的查询结果

        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_getMedTypeResult(string strSQL, out com.digitalwave.iCare.ValueObject.clsMedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new com.digitalwave.iCare.ValueObject.clsMedicineType_VO[0];
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                objHRPSvc.Dispose();
                objHRPSvc = null;
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new com.digitalwave.iCare.ValueObject.clsMedicineType_VO[dtbResult.Rows.Count];

                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsMedicineType_VO();
                        p_objResultArr[i1].m_strMedicineTypeID = dtbResult.Rows[i1]["medicinetypeid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strMedicineTypeName = dtbResult.Rows[i1]["medicinetypename_vchr"].ToString().Trim();
                    }
                }
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

        #region 获取药品类型

        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMTVO">药品类型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMedicineType(System.Security.Principal.IPrincipal p_objPrincipal, out com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO[] p_objMTVO)
        {
            p_objMTVO = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.medicinetypeid_chr, a.medicinetypename_vchr
  from t_aid_medicinetype a order by a.medicinetypeid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtbValue = null;

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objMTVO = new com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO[intRowsCount];
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objMTVO[iRow] = new com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO();
                        drTemp = dtbValue.Rows[iRow];
                        p_objMTVO[iRow].m_strMedicineTypeID_CHR = drTemp["medicinetypeid_chr"].ToString();
                        p_objMTVO[iRow].m_strMedicineTypeName_VCHR = drTemp["medicinetypename_vchr"].ToString();
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

        #region 获取全部药品(审核时使用，多了seriesid_int)
        /// <summary>
        /// 获取全部药品(审核时使用，多了seriesid_int)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicineForCommit(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = -1;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                round(a.opretailprice_int,4) opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.ipchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.ipchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr,
                a.seriesid_int,
                a.opavailablegross_num,
                a.ipavailablegross_num
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          opretailprice_int,
          lotno_vchr desc";
                }
                else
                {
                    strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.oprealgross_int,
                round(a.opretailprice_int,4) opretailprice_int,
                a.iprealgross_int,
                a.ipretailprice_int,
                decode(b.opchargeflg_int,
                       0,
                       a.oprealgross_int,
                       a.iprealgross_int) realgross_int,
                decode(b.opchargeflg_int,
                       0,
                       a.opretailprice_int,
                       a.ipretailprice_int) retailprice_int,
                case
                  when a.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   a.lotno_vchr
                end lotno_vchr,
                a.dsinstoreid_vchr,
                a.validperiod_dat,
                a.instoreid_vchr indrugstoreid_vchr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr,
                e.storagerackcode_vchr,
                b.productorid_chr,
                a.packqty_dec,
                b.opchargeflg_int,
                b.ipchargeflg_int,
                decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
                a.opunit_chr,
                a.ipunit_chr,
                0 checkgross_int,
                0 balance,
                0 retailmoney,
                0 realmoney,0 callmoney,
                decode(b.opchargeflg_int,
                       0,
                       a.opwholesaleprice_int,
                       a.ipwholesaleprice_int) callprice_int,
                a.opwholesaleprice_int opcallprice_int,
                a.ipwholesaleprice_int ipcallprice_int,
                a.dsinstoragedate_dat,
                h.medicinetypename_vchr,
                '' checkreason_vchr,
                a.seriesid_int,
                a.opavailablegross_num,
                a.ipavailablegross_num
  from t_ds_storage_detail a
  left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         a.medicineid_chr
                                     and a.drugstoreid_chr =
                                         d.storageid_chr
  left join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 where a.status = 1
   and a.drugstoreid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          a.medicineid_chr,
          opretailprice_int,
          lotno_vchr desc";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_dtbMedicine = m_dtbGetMedicineWithoutLastCheckZero(p_objPrincipal, p_strStorageID, p_dtbMedicine);
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
