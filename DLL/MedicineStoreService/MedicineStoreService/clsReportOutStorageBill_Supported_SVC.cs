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
    /// 出库单据/出库单据明细表
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReportOutStorageBill_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 缓存供贷商表 不用
        /// <summary>
        /// 缓存供贷商表
        /// </summary>
        /// <param name="m_dtVendor"></param>
        /// <returns></returns>
//        [AutoComplete]
//        public long m_mthGetVendorTable(out DataTable m_dtVendor)
//        {
//            long lngRes = -1;
//            m_dtVendor = new DataTable();

//            string strSql = @"select t.vendorid_chr id, t.vendorname_vchr name, 
//                                     t.usercode_chr code,t.pycode_chr,t.wbcode_chr 
//                                from t_bse_vendor t where vendortype_int = 1 or vendortype_int = 3 
//                            order by t.usercode_chr";
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtVendor);

//                objHRPSvc.Dispose();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
        #endregion

        #region 出库类别
        /// <summary>
        /// 出库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetOutstorageType(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();

            string strSql = @"select t.typename_vchr,t.typecode_vchr from t_aid_impexptype t where flag_int=1";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_objTable);

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

        #region 获取出库单据的明细数据
        /// <summary>
        /// 获取出库单据的明细数据
        /// </summary>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailBillInfo(int intDsOrMs, DateTime p_dtmBegin, DateTime p_dtmEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
        {
            long lngRes = -1;
            m_dtResult = new DataTable();
            string strSql = "";
            if (intDsOrMs == 0)
            {
                #region 药房
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.examdate_dat between ? and ?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and b.deptid_chr=?";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?";
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and b.deptid_chr=?";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.instoredept_chr=d.borrowdept_chr(+)
                                          and d.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?";
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 药库
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  '' outvoicecode_vchr,
                                  '' outvoicedater_dat,
                                  e.netamount_int,
                                  e.callprice_int,
                                  sum(e.netamount_int*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.netamount_int*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_medicine d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and e.medicineid_chr=d.medicineid_chr(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,d.productorid_chr,
                                  e.netamount_int,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                    }
                }
                #endregion
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                int i = 0;
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtResult, objDPArr);

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

        #region 获取出库单据数据
        /// <summary>
        /// 获取出库单据数据
        /// </summary>
        /// <param name="p_dtmBegin"></param>
        /// <param name="p_dtmEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid">0000为全部</param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageBillInfo(int intDsOrMs, DateTime p_dtmBegin, DateTime p_dtmEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
        {
            long lngRes = -1;
            m_dtResult = new DataTable();
            string strSql = "";
            if (intDsOrMs == 0)
            {
                #region 药房
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.examdate_dat between ? and ?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and b.deptid_chr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.drugstoreid_chr=g.deptid_chr(+)
                                          and g.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.drugstoreid_chr=g.deptid_chr(+)
                                          and g.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and b.deptid_chr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.drugstoreid_chr=g.deptid_chr(+)
                                          and g.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.examdate_dat outstoragedate_dat,
                                              a.outdrugstoreid_vchr outstorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(round(e.ipamount_int * e.opretailprice_int / e.packqty_dec, 4)) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.drugstoreid_chr=g.deptid_chr(+)
                                          and g.medstoreid_chr=?
                                          and a.examdate_dat between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?
                                     group by a.examdate_dat,a.outdrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 药库
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.netamount_int*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_outstorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_outstorage_detail e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and e.vendorid_chr=b.vendorid_chr(+)
                              and a.outstoragetype_int=c.typecode_vchr(+)
                              and a.askerid_chr=d.empid_chr(+)
                              and a.storageid_chr=?
                              and a.outstoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by a.outstoragedate_dat,a.outstorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                }
                #endregion
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                int i = 0;
                if (strStorageid == "0000")
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                }
                else
                {
                    if (strTypeid == "0000")
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = p_dtmBegin;
                            objDPArr[i++].Value = p_dtmEnd;
                            objDPArr[i++].Value = strTypeid;
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref m_dtResult, objDPArr);

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

        #region 获取单据、处方、摆药去向统计表       
        /// <summary>
        /// 获取单据、处方、摆药去向统计表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineTypeID">药品类型</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <param name="p_dblSumMoney">处方总金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGoWayStat(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineTypeID, out DataTable p_dtbResult, out double p_dblSumMoney)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            p_dblSumMoney = 0;
            DataTable m_dtbTemp = new DataTable();
            DataTable dtbTemp = new DataTable();

            string m_strCondition1 = string.Empty;
            string m_strCondition2 = string.Empty;
            string m_strCondition3 = string.Empty;
            if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
            {
                m_strCondition1 = @" and h.medicinetypeid_chr = ? ";
                m_strCondition2 = @" and b.medicinetypeid_chr = ? ";
                m_strCondition3 = @" and l.medicinetypeid_chr = ? ";
            }

            string strSQL = @"select nvl(a.instoredept_chr, '0000000') instoredept_chr,
       nvl(c.deptname_vchr, '其他') deptname_vchr,
       sum(round(b.ipamount_int * b.opretailprice_int / b.packqty_dec, 4)) outamount,
       0 opramount,
       0 putamount
  from t_ds_outstorage a
  left join t_ds_outstorage_detail b on b.seriesid2_int = a.seriesid_int
                                    and b.status = 1
  left join t_bse_deptdesc c on c.deptid_chr = a.instoredept_chr
  left join t_bse_medicine h on h.medicineid_chr = b.medicineid_chr
 where a.status_int in (2, 3) and a.drugstoreid_chr = ? and a.examdate_dat between ? and ? " +
                     m_strCondition1 + @" 
				 group by a.instoredept_chr, c.deptname_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].Value = p_strMedicineTypeID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                p_dtbResult = dtbTemp.Copy();

                strSQL = @"select nvl(d.diagdept_chr, '0000000') instoredept_chr,
       nvl(e.deptname_vchr, '其他') deptname_vchr,
       0 outamount,
       sum(round(decode(a.type_int, 2, a.ipamount_int, 1, -a. ipamount_int) *
                 a.opretailprice_int / b.packqty_dec,
                 4)) opramount,
       0 putamount
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
  left join t_opr_outpatientrecipe d on d.outpatrecipeid_chr =
                                        a.outpatrecipeid_chr
  left join t_bse_deptdesc e on e.deptid_chr = d.diagdept_chr
 where a.state_int <> 0
	 and a.drugstoreid_int = ?
	 and a.operatedate_dat between ? and ?
	 " + m_strCondition2 + @"
 group by d.diagdept_chr, e.deptname_vchr";
                objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].Value = p_strMedicineTypeID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["instoredept_chr"] };

                DataRow dr = null;
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = p_dtbResult.Rows.Find(dtbTemp.Rows[i1]["instoredept_chr"]);
                    if (dr != null)
                    {
                        dr["opramount"] = dtbTemp.Rows[i1]["opramount"];
                    }
                    else
                    {
                        p_dtbResult.Rows.Add(dtbTemp.Rows[i1].ItemArray);
                    }
                }

                strSQL = @"select nvl(j.nurseunitid_chr, '0000000') instoredept_chr,
       nvl(k.deptname_vchr, '其他') deptname_vchr,
       0 outamount,
       0 opramount,
       sum(round(decode(i.type_int, 1, i.ipamount_int, 2, -i.ipamount_int) *
                 i.opretailprice_int / i.packqty_dec,
                 8)) putamount
  from t_ds_putmedaccount_detail i
  left join t_bse_nurseunit_dept_ref j on j.deptid_chr = i.deptid_chr
  left join t_bse_deptdesc k on k.deptid_chr = j.nurseunitid_chr
  left join t_bse_medicine l on l.medicineid_chr = i.medicineid_chr
 where i.state_int <> 0
   and i.drugstoreid_int = ?
   and i.operatedate_dat between ? and ? " + m_strCondition3 + @"
 group by j.nurseunitid_chr, k.deptname_vchr";
                objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].Value = p_strMedicineTypeID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);

                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = p_dtbResult.Rows.Find(dtbTemp.Rows[i1]["instoredept_chr"]);
                    if (dr != null)
                    {
                        dr["putamount"] = dtbTemp.Rows[i1]["putamount"];
                    }
                    else
                    {
                        p_dtbResult.Rows.Add(dtbTemp.Rows[i1].ItemArray);
                    }
                }

                /*
            string m_strSql = @"select instoredept_chr,
			 case
				 when deptname_vchr is null then
					'其他'
				 else
					deptname_vchr
			 end deptname_vchr,
			 sum(outamount) outamount,
			 sum(opramount) opramount,
			 sum(putamount) putamount
	from (select a.instoredept_chr instoredept_chr,
							 c.deptname_vchr deptname_vchr,
							 sum(round(b.ipamount_int * b.opretailprice_int / h.packqty_dec,4)) outamount,
							 0 opramount,
							 0 putamount
					from t_ds_outstorage a
					left join t_ds_outstorage_detail b on b.seriesid2_int =
																								a.seriesid_int
					left join t_bse_deptdesc c on c.deptid_chr = a.instoredept_chr
					left join t_bse_medicine h on h.medicineid_chr = b.medicineid_chr
				 where a.status_int in (2, 3) and a.drugstoreid_chr = ? and a.examdate_dat between ? and ? " +
                     m_strCondition1 + @" 
				 group by a.instoredept_chr, c.deptname_vchr
				union
select d.diagdept_chr instoredept_chr,
			 e.deptname_vchr deptname_vchr,
			 0 outamount,
			 sum(round(decode(a.type_int,2,a.ipamount_int,1,-a. ipamount_int) * a.opretailprice_int / b.packqty_dec,4)) opramount,
			 0 putamount
	from t_ds_recipeaccount_detail a
	left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_ds_storage_detail c on c.seriesid_int = a.medseriesid_int
	left join t_opr_outpatientrecipe d on d.outpatrecipeid_chr =
																				a.outpatrecipeid_chr
	left join t_bse_deptdesc e on e.deptid_chr = d.diagdept_chr
 where c.status = 1
	 and a.state_int <> 0
	 and a.drugstoreid_int = ?
	 and a.operatedate_dat between ? and ?
	 " + m_strCondition2 + @"
 group by d.diagdept_chr, e.deptname_vchr
union
        select j.areaid_chr instoredept_chr,
               k.deptname_vchr,
               0 outamount,
               0 opramount,
               sum(round(decode(i.type_int,
                                1,
                                i.ipamount_int,
                                2,
                                -i.ipamount_int) * i.opretailprice_int /
                         i.packqty_dec,
                         4)) putamount
          from t_ds_putmedaccount_detail i
          left join t_bih_opr_putmeddetail j on j.putmeddetailid_chr =
                                                i.putmeddetailid_chr
          left join t_bse_deptdesc k on k.deptid_chr = j.areaid_chr
          left join t_bse_medicine l on l.medicineid_chr = i.medicineid_chr
         where i.state_int <> 0
           and j.status_int <> 0
           and i.drugstoreid_int = ?
           and i.operatedate_dat between ? and ?" + m_strCondition3 + @"
         group by j.areaid_chr, k.deptname_vchr)
group by instoredept_chr, deptname_vchr
 order by deptname_vchr";
            
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    objHRPSvc.CreateDatabaseParameter(9, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].Value = p_strDrugID;
                    objParamArr[4].DbType = DbType.DateTime;
                    objParamArr[4].Value = p_dtmStartDate;
                    objParamArr[5].DbType = DbType.DateTime;
                    objParamArr[5].Value = p_dtmEndDate;
                    objParamArr[6].Value = p_strDrugID;
                    objParamArr[7].DbType = DbType.DateTime;
                    objParamArr[7].Value = p_dtmStartDate;
                    objParamArr[8].DbType = DbType.DateTime;
                    objParamArr[8].Value = p_dtmEndDate;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(12, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].Value = p_strMedicineTypeID;
                    objParamArr[4].Value = p_strDrugID;
                    objParamArr[5].DbType = DbType.DateTime;
                    objParamArr[5].Value = p_dtmStartDate;
                    objParamArr[6].DbType = DbType.DateTime;
                    objParamArr[6].Value = p_dtmEndDate;
                    objParamArr[7].Value = p_strMedicineTypeID;
                    objParamArr[8].Value = p_strDrugID;
                    objParamArr[9].DbType = DbType.DateTime;
                    objParamArr[9].Value = p_dtmStartDate;
                    objParamArr[10].DbType = DbType.DateTime;
                    objParamArr[10].Value = p_dtmEndDate;
                    objParamArr[11].Value = p_strMedicineTypeID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                 */
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    //求处方总金额

                    strSQL = @"select round(sum(decode(a.type_int, 2, a.ipamount_int, 1, -a. ipamount_int) *
                 a.opretailprice_int / b.packqty_dec),
             4) opramount
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
  left join t_ds_storage_detail c on c.seriesid_int = a.medseriesid_int
  left join t_opr_outpatientrecipe d on d.outpatrecipeid_chr =
                                        a.outpatrecipeid_chr
  left join t_bse_deptdesc e on e.deptid_chr = d.diagdept_chr
 where c.status = 1
   and a.state_int <> 0
   and a.drugstoreid_int = ?
   and a.operatedate_dat between ? and ?" + m_strCondition2;

                    objParamArr = null;
                    if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                    }
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbTemp, objParamArr);
                    if (m_dtbTemp != null && m_dtbTemp.Rows.Count > 0)
                    {
                        double.TryParse(m_dtbTemp.Rows[0][0].ToString(), out p_dblSumMoney);
                    }
                }
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

        #region 根据库房类型id获取药房名称
        /// <summary>
        ///  根据库房类型id获取药房名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="p_strName">药房名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreNameByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID,out string p_strName)
        {
            p_strName = string.Empty;
            DataTable dtTemp = new DataTable();
            long lngReturn = 0;

            string strSQL = @"select a.medstorename_vchr from t_bse_medstore a where a.medstoreid_chr = ?";

            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] objParamArr = null;
            objHRPServ.CreateDatabaseParameter(1, out objParamArr);
            objParamArr[0].Value = p_strID;
            lngReturn = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParamArr);
            objHRPServ.Dispose();
            objHRPServ = null;
            if (dtTemp.Rows.Count > 0)
            {
                p_strName = Convert.ToString(dtTemp.Rows[0]["medstorename_vchr"]);
            }
            return lngReturn;           
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="dtMedType">数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineType(out DataTable dtMedType)
        {
            long lngRes = -1;
            string strSQL = @" select a.medicinetypeid_chr,a.medicinetypename_vchr from t_aid_medicinetype  a order by medicinetypeid_chr";
            dtMedType = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtMedType);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据库房类型id获取部门ID
        /// <summary>
        ///  根据库房类型id获取部门ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房ID</param>
        /// <param name="p_strDeptID">部门ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptIDByDrugID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, out string p_strDeptID)
        {
            p_strDeptID = string.Empty;
            DataTable dtTemp = new DataTable();
            long lngReturn = 0;

            string strSQL = @"select a.deptid_chr from t_bse_medstore a where a.medstoreid_chr = ?";

            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] objParamArr = null;
            objHRPServ.CreateDatabaseParameter(1, out objParamArr);
            objParamArr[0].Value = p_strDrugID;
            lngReturn = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParamArr);
            objHRPServ.Dispose();
            objHRPServ = null;
            if (dtTemp.Rows.Count > 0)
            {
                p_strDeptID = Convert.ToString(dtTemp.Rows[0]["deptid_chr"]);
            }
            return lngReturn;
        }
        #endregion

        #region 获取处方药品出库品种金额统计表
        /// <summary>
        /// 获取处方药品出库品种金额统计表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineTypeID">药品类型</param>
        /// <param name="p_strMedicineId">药品Id</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <param name="p_dblSumMoney">总金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeOutSumStat(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital,string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineTypeID, string p_strMedicineId,bool p_blnCombine,out DataTable p_dtbResult,out double p_dblSumMoney)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            p_dblSumMoney = 0d;
            DataTable m_dtbTemp = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;
            if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
            {
                if (p_strMedicineId == string.Empty)
                {
                    m_strCondition = @" and b.medicinetypeid_chr = ? ";
                    m_intParamCount++;
                }
                else
                {
                    if (p_blnCombine)
                    {
                        m_strCondition = @" and b.medicinetypeid_chr = ? and b.assistcode_chr = ?";
                    }
                    else
                    {
                        m_strCondition = @" and b.medicinetypeid_chr = ? and b.medicineid_chr = ?";
                    }
                    m_intParamCount += 2;
                }
            }
            else
            {
                if (p_strMedicineId != string.Empty)
                {
                    if (p_blnCombine)
                    {
                        m_strCondition = @" and b.assistcode_chr = ?";
                    }
                    else
                    {
                        m_strCondition = @" and b.medicineid_chr = ?";
                    }
                    m_intParamCount++;
                }
            }

            string m_strSql = "";
            if (p_blnIsHospital)
            {
                m_strSql = @"select b.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) ipunit_chr,
       b.productorid_chr,
       decode(b.ipchargeflg_int,
              0,
              sum(decode(a.type_int,
                         1,
                         a.opamount_int,
                         2,
                         -a.opamount_int)),
              sum(decode(a.type_int, 1, a.ipamount_int, 2, -a.ipamount_int))) ipamount,
       sum(round(decode(a.type_int,
                        1,
                        a.ipamount_int * a.opretailprice_int / b.packqty_dec,
                        2,
                        -a.ipamount_int * a.opretailprice_int /
                        b.packqty_dec),
                 4)) sumprice
  from t_ds_putmedaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.state_int <> 0
   and a.type_int <> 0
   and a.drugstoreid_int = ?
   and a.operatedate_dat between ? and ?" +
                     m_strCondition + @" group by b.assistcode_chr,
          b.medicinename_vchr,
          b.medspec_vchr,
          a.opunit_chr,
          a.ipunit_chr,
          b.productorid_chr,
          b.ipchargeflg_int
 order by b.assistcode_chr";
            }
            else
            {
                m_strSql = @"select b.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) ipunit_chr,
       b.productorid_chr,
       decode(b.opchargeflg_int,
              0,
              sum(decode(a.type_int, 2, a.opamount_int, 1, -a.opamount_int)),
              sum(decode(a.type_int, 2, a.ipamount_int, 1, -a.ipamount_int))) ipamount,
       sum(round(decode(a.type_int,
                  2,
                  a.ipamount_int * a.opretailprice_int / b.packqty_dec,
                  1,
                  -a.ipamount_int * a.opretailprice_int / b.packqty_dec),4)) sumprice
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.state_int <> 0
   and a.type_int <> 0
   and a.drugstoreid_int = ?
   and a.operatedate_dat between ? and ?" +
                     m_strCondition + @" group by b.assistcode_chr,b.medicinename_vchr,
					b.medspec_vchr,
					a.opunit_chr,
					a.ipunit_chr,
					b.productorid_chr,
					b.opchargeflg_int order by b.assistcode_chr";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                
                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                objParamArr[0].Value = p_strDrugID;
                objParamArr[1].DbType = DbType.DateTime;
                objParamArr[1].Value = p_dtmStartDate;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmEndDate;
                if (m_intParamCount == 4)
                {
                    if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
                    {
                        objParamArr[3].Value = p_strMedicineTypeID;
                    }
                    else
                    {
                        objParamArr[3].Value = p_strMedicineId;
                    }
                }
                else if (m_intParamCount == 5)
                {
                    objParamArr[3].Value = p_strMedicineTypeID;
                    objParamArr[4].Value = p_strMedicineId;
                }               

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    //获取总金额
                    if (p_blnIsHospital)
                    {
                        m_strSql = @"select round(sum(decode(a.type_int,
                        1,
                        a.ipamount_int * a.opretailprice_int / b.packqty_dec,
                        2,
                        -a.ipamount_int * a.opretailprice_int /
                        b.packqty_dec)),
             4) sumprice
  from t_ds_putmedaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.state_int <> 0
   and a.type_int <> 0
   and a.drugstoreid_int = ?
   and a.operatedate_dat between ? and ?" + m_strCondition;
                    }
                    else
                    {
                        m_strSql = @"select round(sum(decode(a.type_int,
                        2,
                        a.ipamount_int * a.opretailprice_int / b.packqty_dec,
                        1,
                        -a.ipamount_int * a.opretailprice_int /
                        b.packqty_dec)),
             4) sumprice
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.state_int <> 0
   and a.type_int <> 0
   and a.drugstoreid_int = ?
   and a.operatedate_dat between ? and ?" + m_strCondition;
                    }
                    objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    if (m_intParamCount == 4)
                    {
                        if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
                        {
                            objParamArr[3].Value = p_strMedicineTypeID;
                        }
                        else
                        {
                            objParamArr[3].Value = p_strMedicineId;
                        }
                    }
                    else if (m_intParamCount == 5)
                    {
                        objParamArr[3].Value = p_strMedicineTypeID;
                        objParamArr[4].Value = p_strMedicineId;
                    }

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref m_dtbTemp, objParamArr);
                    if (m_dtbTemp != null && m_dtbTemp.Rows.Count > 0)
                    {
                        double.TryParse(m_dtbTemp.Rows[0][0].ToString(), out p_dblSumMoney);
                    }

                }
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

        #region 获取处方药品出库药品明细表
        /// <summary>
        /// 获取处方药品出库药品明细表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnHospital">是否住院药房</param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineId">药品Id</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <param name="p_dblSumMoney">总金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnHospital,string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineId, out DataTable p_dtbResult,out double p_dblSumMoney)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            p_dblSumMoney = 0;
            DataTable m_dtbTemp = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;
            if (p_strDrugID != "0000")
            {
                m_strCondition = @" and g.medstoreid_chr = ? ";
                m_intParamCount++;
            }

            string m_strSql = "";
            if (p_blnHospital)
            {
                m_strSql = @"select a.operatedate_dat,
       f.inpatientid_chr patientcardid_chr,
       c.lastname_vchr,
       decode(a.type_int,
              1,
              decode(d.ipchargeflg_int,
                     0,
                     a.opamount_int,
                     a.ipamount_int),
              2,
              decode(d.ipchargeflg_int,
                     0,
                     -a.opamount_int,
                     -a.ipamount_int)) amount_int,
       decode(d.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
       decode(d.ipchargeflg_int,
              0,
              a.opoldgross_int,
              a.ipoldgross_int) oldgross_int,
       decode(a.type_int,
              1,
              decode(d.ipchargeflg_int,
                     0,
                     a.opretailprice_int,
                     round(a.opretailprice_int / d.packqty_dec, 4)),
              2,
              decode(d.ipchargeflg_int,
                     0,
                     -a.opretailprice_int,
                     -round(a.opretailprice_int / d.packqty_dec, 4))) retailprice_int,
       decode(a.type_int,
              1,
              round(a.ipamount_int * a.opretailprice_int / d.packqty_dec, 4),
              2,
              -round(a.ipamount_int * a.opretailprice_int / d.packqty_dec, 4)) sumprice,
       decode(a.type_int, 1, e.lastname_vchr, '') sharer,
       decode(a.type_int, 2, e.lastname_vchr, '') withdrawer
  from t_ds_putmedaccount_detail a
  left join t_bih_opr_putmeddetail b on b.putmeddetailid_chr =
                                        a.putmeddetailid_chr
  left join t_bse_patient c on c.patientid_chr = b.paientid_chr
  left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
  left join t_bse_employee e on e.empid_chr = a.operatorid_chr
  left join t_opr_bih_register f on f.registerid_chr = b.registerid_chr
  left join t_bse_medstore g on g.deptid_chr = a.drugstoreid_int
 where a.medicineid_chr = ?
   and a.operatedate_dat between ? and ?
 " + m_strCondition + @" order by a.operatedate_dat";
            }
            else
            {
                m_strSql = @"select a.operatedate_dat,
       f.patientcardid_chr,
       c.lastname_vchr,
       decode(a.type_int,
              2,
              decode(d.opchargeflg_int, 0, a.opamount_int, a.ipamount_int),
              1,
              decode(d.opchargeflg_int, 0, -a.opamount_int, -a.ipamount_int)) amount_int,
       decode(d.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
       decode(d.opchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int) oldgross_int,
       decode(a.type_int,
              2,
              decode(d.opchargeflg_int,
                     0,
                     a.opretailprice_int,
                     round(a.opretailprice_int / d.packqty_dec, 4)),
              1,
              decode(d.opchargeflg_int,
                     0,
                     -a.opretailprice_int,
                     -round(a.opretailprice_int / d.packqty_dec, 4))) retailprice_int,
       decode(a.type_int,
              2,
              round(a.ipamount_int * a.opretailprice_int / d.packqty_dec, 4),
              1,
              -round(a.ipamount_int * a.opretailprice_int / d.packqty_dec, 4)) sumprice,
       decode(a.type_int, 2, e.lastname_vchr, '') sharer,
       decode(a.type_int, 1, e.lastname_vchr, '') withdrawer
  from t_ds_recipeaccount_detail a
  left join t_opr_outpatientrecipe b on b.outpatrecipeid_chr =
                                        a.outpatrecipeid_chr
  left join t_bse_patient c on c.patientid_chr = b.patientid_chr
  left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
  left join t_bse_employee e on e.empid_chr = a.operatorid_chr
  left join t_bse_patientcard f on f.patientid_chr = b.patientid_chr
  left join t_bse_medstore g on g.deptid_chr = a.drugstoreid_int
 where a.medicineid_chr = ?
	 and a.operatedate_dat between ? and ?
 " + m_strCondition + @" order by a.operatedate_dat";
            }
            
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                objParamArr[0].Value = p_strMedicineId;
                objParamArr[1].DbType = DbType.DateTime;
                objParamArr[1].Value = p_dtmStartDate;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmEndDate;
                if (m_intParamCount == 4)
                {
                    objParamArr[3].Value = p_strDrugID;                   
                }               

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    //求总金额
                    if (p_blnHospital)
                    {
                        m_strSql = @"select round(sum(a.ipamount_int * a.opretailprice_int / d.packqty_dec *
                 decode(a.type_int, 1, 1, -1)),
             4) sumprice
  from t_ds_putmedaccount_detail a
  left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore g on g.deptid_chr = a.drugstoreid_int
  where a.medicineid_chr = ?
	 and a.operatedate_dat between ? and ?
 " + m_strCondition + @" order by a.operatedate_dat";
                    }
                    else
                    {
                        m_strSql = @"select round(sum(a.ipamount_int * a.opretailprice_int / d.packqty_dec *
                 decode(a.type_int, 2, 1, -1)),
             4) sumprice
  from t_ds_recipeaccount_detail a
  left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore g on g.deptid_chr = a.drugstoreid_int
 where a.medicineid_chr = ?
	 and a.operatedate_dat between ? and ?
 " + m_strCondition + @" order by a.operatedate_dat";
                    }
                    objParamArr = null;

                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strMedicineId;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    if (m_intParamCount == 4)
                    {
                        objParamArr[3].Value = p_strDrugID;
                    }

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref m_dtbTemp, objParamArr);
                    if (m_dtbTemp != null && m_dtbTemp.Rows.Count > 0)
                    {
                        double.TryParse(m_dtbTemp.Rows[0][0].ToString(), out p_dblSumMoney);
                    }
                }
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


        #region 单据处方摆药出库药品统计报表
        /// <summary>
        /// 单据处方摆药出库药品统计报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineTypeID">药品类型</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <param name="p_dblSumMoney">处方总金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGoWayStatDetail(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineTypeID, string p_strMedicineID, bool p_blnCombine, out DataTable p_dtbResult, out double p_dblSumMoney)
        {
            long lngRes = -1;
            p_dblSumMoney = 0;
            p_dtbResult = new DataTable();

            try
            {

                DataTable m_dtbTemp = new DataTable();
                string m_strCondition1 = string.Empty;
                string m_strCondition2 = string.Empty;
                string m_strCondition3 = string.Empty;
                if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
                {
                    m_strCondition1 = " where a.medicinetypeid_chr = ? ";
                    m_strCondition2 = " where p.medicinetypeid_chr = ? ";
                    m_strCondition3 = " where i.medicinetypeid_chr = ? ";
                }
                if (p_strMedicineID.Length > 0)
                {
                    if (p_blnCombine)
                    {
                        if (m_strCondition1.Length > 0)
                        {
                            m_strCondition1 += " and a.assistcode_chr = ?";
                            m_strCondition2 += " and p.assistcode_chr = ?";
                            m_strCondition3 += " and i.assistcode_chr = ?";
                        }
                        else
                        {
                            m_strCondition1 += " where a.assistcode_chr = ?";
                            m_strCondition2 += " where p.assistcode_chr = ?";
                            m_strCondition3 += " where i.assistcode_chr = ?";
                        }
                    }
                    else
                    {
                        if (m_strCondition1.Length > 0)
                        {
                            m_strCondition1 += " and a.medicineid_chr = ?";
                            m_strCondition2 += " and p.medicineid_chr = ?";
                            m_strCondition3 += " and i.medicineid_chr = ?";
                        }
                        else
                        {
                            m_strCondition1 += " where a.medicineid_chr = ?";
                            m_strCondition2 += " where p.medicineid_chr = ?";
                            m_strCondition3 += " where i.medicineid_chr = ?";
                        }
                    }
                }

                DataTable dtbTemp = new DataTable();
                string strSQL = @"select a.medicineid_chr,
               a.medicinename_vchr,
               a.medspec_vchr,
               decode(a.opchargeflg_int, 0, a.opunit_chr, 1, a.ipunit_chr) unit_chr,
               a.productorid_chr,
               decode(a.opchargeflg_int,
                      0,
                      sum(f.opamount_int),
                      1,
                      sum(f.ipamount_int)) outamount_int,
               sum(round(f.ipamount_int * f.opretailprice_int /
                         f.packqty_dec,
                         4)) outmoney,
               0 rpamount_int,
               0 rpmoney,
               0 putamount_int,
               0 putmoney
          from t_bse_medicine a
         inner join t_ds_medstoreset c on c.medicinetypeid_chr =
                                          a.medicinetypeid_chr
                                      and c.medstoreid = ?
         inner join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
         inner join t_ds_outstorage_detail f on f.medicineid_chr =
                                                a.medicineid_chr
                                            and f.status = 1
         inner join t_ds_outstorage g on g.seriesid_int = f.seriesid2_int
                                     and g.status_int in (2, 3)
                                     and g.drugstoreid_chr = d.deptid_chr
                                     and g.examdate_dat between ? and ? " + m_strCondition1 + @"
         group by a.medicineid_chr,
                  a.medicinename_vchr,
                  a.medspec_vchr,
                  a.opchargeflg_int,
                  a.opunit_chr,
                  a.ipunit_chr,
                  a.productorid_chr";
                if (p_blnIsHospital)
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                    }
                }
                else
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(5, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                        objParamArr[4].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                p_dtbResult = dtbTemp.Copy();
                p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["medicineid_chr"] };
                strSQL = @"select p.medicineid_chr,
               p.medicinename_vchr,
               p.medspec_vchr,
               decode(p.opchargeflg_int, 0, p.opunit_chr, 1, p.ipunit_chr) unit_chr,
               p.productorid_chr,
               0 outamount_int,
               0 outmoney,
               decode(p.opchargeflg_int,
                      0,
                      sum(decode(h.type_int,
                                 1,
                                 -h.opamount_int,
                                 h.opamount_int)),
                      sum(decode(h.type_int,
                                 1,
                                 -h.ipamount_int,
                                 h.ipamount_int))) rpamount_int,
               sum(decode(h.type_int,
                          1,
                          round(-h.ipamount_int * h.opretailprice_int /
                                p.packqty_dec,
                                4),
                          round(h.ipamount_int * h.opretailprice_int /
                                p.packqty_dec,
                                4))) rpmoney,
               0 putamount_int,
               0 putmoney
          from t_bse_medicine p
         inner join t_ds_medstoreset c on c.medicinetypeid_chr =
                                          p.medicinetypeid_chr
                                      and c.medstoreid = ?
         inner join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
         inner join t_ds_recipeaccount_detail h on h.medicineid_chr =
                                                   p.medicineid_chr
                                               and h.drugstoreid_int =
                                                   d.deptid_chr
                                               and h.state_int <> 0
                                               and h.isend_int = 0
                                               and h.operatedate_dat between ? and ? " + m_strCondition2 + @"
         group by p.medicineid_chr,
                  p.medicinename_vchr,
                  p.medspec_vchr,
                  p.opchargeflg_int,
                  p.opunit_chr,
                  p.ipunit_chr,
                  p.productorid_chr";
                if (p_blnIsHospital)
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");
                objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                    }
                }
                else
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(5, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                        objParamArr[4].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["medicineid_chr"] };

                DataRow dr = null;
                
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = p_dtbResult.Rows.Find(dtbTemp.Rows[i1]["medicineid_chr"]);
                    if (dr != null)
                    {
                        dr["rpamount_int"] = dtbTemp.Rows[i1]["rpamount_int"];
                        dr["rpmoney"] = dtbTemp.Rows[i1]["rpmoney"];
                        continue;
                    }
                    else
                    {
                        p_dtbResult.Rows.Add(dtbTemp.Rows[i1].ItemArray);
                    }
                }

                strSQL = @"select i.medicineid_chr,
               i.medicinename_vchr,
               i.medspec_vchr,
               decode(i.opchargeflg_int, 0, i.opunit_chr, 1, i.ipunit_chr) unit_chr,
               i.productorid_chr,
               0 outamount_int,
               0 outmoney,
               0 rpamount_int,
               0 rpmoney,
               sum(decode(i.opchargeflg_int,
                          0,
                          decode(j.type_int,
                                 1,
                                 j.opamount_int,
                                 2,
                                 -j.opamount_int),
                          decode(j.type_int,
                                 1,
                                 j.ipamount_int,
                                 2,
                                 -j.ipamount_int))) putamount_int,
               sum(round(decode(j.type_int,
                                1,
                                j.ipamount_int,
                                2,
                                -j.ipamount_int) * j.opretailprice_int /
                         j.packqty_dec,
                         8)) putmoney
          from t_bse_medicine i
         inner join t_ds_medstoreset k on k.medicinetypeid_chr =
                                          i.medicinetypeid_chr
                                      and k.medstoreid = ?
         inner join t_bse_medstore l on l.medstoreid_chr = k.medstoreid
         inner join t_ds_putmedaccount_detail j on j.medicineid_chr =
                                                   i.medicineid_chr
                                               and j.drugstoreid_int =
                                                   l.deptid_chr
                                               and j.state_int <> 0
                                               and j.operatedate_dat between ? and ? " + m_strCondition3 + @"
         group by i.medicineid_chr,
                  i.medicinename_vchr,
                  i.medspec_vchr,
                  i.opchargeflg_int,
                  i.opunit_chr,
                  i.ipunit_chr,
                  i.productorid_chr";
                if (p_blnIsHospital)
                    strSQL = strSQL.Replace("opchargeflg_int", "ipchargeflg_int");
                objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                    }
                }
                else
                {
                    if (p_strMedicineID.Length > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(5, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                        objParamArr[4].Value = p_strMedicineID;
                    }
                    else
                    {
                        objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineTypeID;
                    }
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParamArr);
                dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["medicineid_chr"] };

                dr = null;
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = p_dtbResult.Rows.Find(dtbTemp.Rows[i1]["medicineid_chr"]);
                    if (dr != null)
                    {
                        dr["putamount_int"] = dtbTemp.Rows[i1]["putamount_int"];
                        dr["putmoney"] = dtbTemp.Rows[i1]["putmoney"];
                        continue;
                    }
                    else
                    {
                        p_dtbResult.Rows.Add(dtbTemp.Rows[i1].ItemArray);
                    }
                }

                /*
                string m_strSql = @"select medicinename_vchr,
           medspec_vchr,
           unit_chr,
           productorid_chr,
           sum(outamount_int) outamount_int,
           sum(outmoney) outmoney,
           sum(rpamount_int) rpamount_int,
           sum(rpmoney) rpmoney,
           sum(putamount_int) putamount_int,
           sum(putmoney) putmoney
      from (select a.medicineid_chr,
                   a.medicinename_vchr,
                   a.medspec_vchr,
                   decode(a.opchargeflg_int, 0, a.opunit_chr, 1, a.ipunit_chr) unit_chr,
                   a.productorid_chr,
                   decode(a.opchargeflg_int,
                          0,
                          sum(f.opamount_int),
                          1,
                          sum(f.ipamount_int)) outamount_int,
                   sum(round(f.ipamount_int * f.opretailprice_int /
                             f.packqty_dec,
                             4)) outmoney,
                   0 rpamount_int,
                   0 rpmoney,
                   0 putamount_int,
                   0 putmoney
              from t_bse_medicine a
             inner join t_ds_medstoreset c on c.medicinetypeid_chr =
                                              a.medicinetypeid_chr
                                          and c.medstoreid = ?
             inner join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
             inner join t_ds_outstorage_detail f on f.medicineid_chr =
                                                    a.medicineid_chr
                                                and f.status = 1
             inner join t_ds_outstorage g on g.seriesid_int = f.seriesid2_int
                                         and g.status_int in (2, 3)
                                         and g.drugstoreid_chr = d.deptid_chr
                                         and g.examdate_dat between ? and ? "+m_strCondition1+@"
             group by a.medicineid_chr,
                      a.medicinename_vchr,
                      a.medspec_vchr,
                      a.opchargeflg_int,
                      a.opunit_chr,
                      a.ipunit_chr,
                      a.productorid_chr
            union
            select p.medicineid_chr,
                   p.medicinename_vchr,
                   p.medspec_vchr,
                   decode(p.opchargeflg_int, 0, p.opunit_chr, 1, p.ipunit_chr) unit_chr,
                   p.productorid_chr,
                   0 outamount_int,
                   0 outmoney,
                   decode(p.opchargeflg_int,
                          0,
                          sum(decode(h.type_int,
                                     1,
                                     -h.opamount_int,
                                     h.opamount_int)),
                          sum(decode(h.type_int,
                                     1,
                                     -h.ipamount_int,
                                     h.ipamount_int))) rpamount_int,
                   sum(decode(h.type_int,
                              1,
                              round(-h.ipamount_int * h.opretailprice_int /
                                    p.packqty_dec,
                                    4),
                              round(h.ipamount_int * h.opretailprice_int /
                                    p.packqty_dec,
                                    4))) rpmoney,
                   0 putamount_int,
                   0 putmoney
              from t_bse_medicine p
             inner join t_ds_medstoreset c on c.medicinetypeid_chr =
                                              p.medicinetypeid_chr
                                          and c.medstoreid = ?
             inner join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
             inner join t_ds_recipeaccount_detail h on h.medicineid_chr =
                                                       p.medicineid_chr
                                                   and h.drugstoreid_int =
                                                       d.deptid_chr
                                                   and h.state_int <> 0
                                                   and h.isend_int = 0
                                                   and h.operatedate_dat between ? and ? " + m_strCondition2 + @"
             group by p.medicineid_chr,
                      p.medicinename_vchr,
                      p.medspec_vchr,
                      p.opchargeflg_int,
                      p.opunit_chr,
                      p.ipunit_chr,
                      p.productorid_chr
            union
            select i.medicineid_chr,
                   i.medicinename_vchr,
                   i.medspec_vchr,
                   decode(i.opchargeflg_int, 0, i.opunit_chr, 1, i.ipunit_chr) unit_chr,
                   i.productorid_chr,
                   0 outamount_int,
                   0 outmoney,
                   0 rpamount_int,
                   0 rpmoney,
                   sum(decode(i.opchargeflg_int,
                              0,
                              decode(j.type_int,
                                     1,
                                     j.opamount_int,
                                     2,
                                     -j.opamount_int),
                              decode(j.type_int,
                                     1,
                                     j.ipamount_int,
                                     2,
                                     -j.ipamount_int))) putamount_int,
                   sum(round(decode(j.type_int,
                                    1,
                                    j.ipamount_int,
                                    2,
                                    -j.ipamount_int) * j.opretailprice_int /
                             j.packqty_dec,
                             4)) putmoney
              from t_bse_medicine i
             inner join t_ds_medstoreset k on k.medicinetypeid_chr =
                                              i.medicinetypeid_chr
                                          and k.medstoreid = ?
             inner join t_bse_medstore l on l.medstoreid_chr = k.medstoreid
             inner join t_ds_putmedaccount_detail j on j.medicineid_chr =
                                                       i.medicineid_chr
                                                   and j.drugstoreid_int =
                                                       l.deptid_chr
                                                   and j.state_int <> 0
                                                   and j.operatedate_dat between ? and ? " + m_strCondition3 + @"
             group by i.medicineid_chr,
                      i.medicinename_vchr,
                      i.medspec_vchr,
                      i.opchargeflg_int,
                      i.opunit_chr,
                      i.ipunit_chr,
                      i.productorid_chr)
     group by medicineid_chr,
              medicinename_vchr,
              medspec_vchr,
              unit_chr,
              productorid_chr
     order by medicinename_vchr";

                if (p_blnIsHospital)
                    m_strSql = m_strSql.Replace("opchargeflg_int", "ipchargeflg_int");

                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    IDataParameter[] objParamArr = null;
                    if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                    {
                        if (p_strMedicineID.Length > 0)
                        {
                            objHRPSvc.CreateDatabaseParameter(12, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;                        
                            objParamArr[3].Value = p_strMedicineID;
                            objParamArr[4].Value = p_strDrugID;
                            objParamArr[5].DbType = DbType.DateTime;
                            objParamArr[5].Value = p_dtmStartDate;
                            objParamArr[6].DbType = DbType.DateTime;
                            objParamArr[6].Value = p_dtmEndDate;
                            objParamArr[7].Value = p_strMedicineID;
                            objParamArr[8].Value = p_strDrugID;
                            objParamArr[9].DbType = DbType.DateTime;
                            objParamArr[9].Value = p_dtmStartDate;
                            objParamArr[10].DbType = DbType.DateTime;
                            objParamArr[10].Value = p_dtmEndDate;
                            objParamArr[11].Value = p_strMedicineID;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(9, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                            objParamArr[3].Value = p_strDrugID;
                            objParamArr[4].DbType = DbType.DateTime;
                            objParamArr[4].Value = p_dtmStartDate;
                            objParamArr[5].DbType = DbType.DateTime;
                            objParamArr[5].Value = p_dtmEndDate;
                            objParamArr[6].Value = p_strDrugID;
                            objParamArr[7].DbType = DbType.DateTime;
                            objParamArr[7].Value = p_dtmStartDate;
                            objParamArr[8].DbType = DbType.DateTime;
                            objParamArr[8].Value = p_dtmEndDate;
                        }
                    }
                    else
                    {
                        if (p_strMedicineID.Length > 0)
                        {
                            objHRPSvc.CreateDatabaseParameter(15, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;                        
                            objParamArr[3].Value = p_strMedicineTypeID;
                            objParamArr[4].Value = p_strMedicineID;
                            objParamArr[5].Value = p_strDrugID;
                            objParamArr[6].DbType = DbType.DateTime;
                            objParamArr[6].Value = p_dtmStartDate;
                            objParamArr[7].DbType = DbType.DateTime;
                            objParamArr[7].Value = p_dtmEndDate;
                            objParamArr[8].Value = p_strMedicineTypeID;
                            objParamArr[9].Value = p_strMedicineID;
                            objParamArr[10].Value = p_strDrugID;
                            objParamArr[11].DbType = DbType.DateTime;
                            objParamArr[11].Value = p_dtmStartDate;
                            objParamArr[12].DbType = DbType.DateTime;
                            objParamArr[12].Value = p_dtmEndDate;
                            objParamArr[13].Value = p_strMedicineTypeID;
                            objParamArr[14].Value = p_strMedicineID;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(12, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                            objParamArr[3].Value = p_strMedicineTypeID;
                            objParamArr[4].Value = p_strDrugID;
                            objParamArr[5].DbType = DbType.DateTime;
                            objParamArr[5].Value = p_dtmStartDate;
                            objParamArr[6].DbType = DbType.DateTime;
                            objParamArr[6].Value = p_dtmEndDate;
                            objParamArr[7].Value = p_strMedicineTypeID;
                            objParamArr[8].Value = p_strDrugID;
                            objParamArr[9].DbType = DbType.DateTime;
                            objParamArr[9].Value = p_dtmStartDate;
                            objParamArr[10].DbType = DbType.DateTime;
                            objParamArr[10].Value = p_dtmEndDate;
                            objParamArr[11].Value = p_strMedicineTypeID;
                        }
                    }

                    lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                 */
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    p_dtbResult.Columns.Add("allamount", typeof(double));
                    p_dtbResult.Columns.Add("allmoney", typeof(double));
                    p_dtbResult.Columns["allamount"].Expression = "IsNull(outamount_int,0) + IsNull(rpamount_int,0) + IsNull(putamount_int,0)";
                    p_dtbResult.Columns["allmoney"].Expression = "IsNull(outmoney,0) + IsNull(rpmoney,0) +IsNull(putmoney,0)";
                    //求处方总金额

                    strSQL = @"select round(sum(rpmoney),5) rpmoney 
  from (select sum(decode(h.type_int,
                          1,
                          -h.ipamount_int * h.opretailprice_int /
                                a.packqty_dec,
                          h.ipamount_int * h.opretailprice_int /
                                a.packqty_dec)) rpmoney
          from t_bse_medicine a
         inner join t_ds_medstoreset c on a.medicinetypeid_chr =
                                          c.medicinetypeid_chr
                                      and c.medstoreid = ?
         inner join t_bse_medstore d on d.medstoreid_chr = c.medstoreid
         inner join t_ds_recipeaccount_detail h on h.medicineid_chr =
                                                   a.medicineid_chr
                                               and h.drugstoreid_int =
                                                   d.deptid_chr
                                               and h.state_int <> 0
                                               and h.isend_int = 0
                                               and h.operatedate_dat between ? and ? " + m_strCondition1 + @"
         group by a.medicineid_chr,
                  a.medicinename_vchr,
                  a.medspec_vchr,
                  a.opchargeflg_int,
                  a.opunit_chr,
                  a.ipunit_chr,
                  a.productorid_chr)";

                    objParamArr = null;
                    if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                    {
                        if (p_strMedicineID.Length > 0)
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                            objParamArr[3].Value = p_strMedicineID;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                        }
                    }
                    else
                    {
                        if (p_strMedicineID.Length > 0)
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                            objParamArr[3].Value = p_strMedicineTypeID;
                            objParamArr[4].Value = p_strMedicineID;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                            objParamArr[0].Value = p_strDrugID;
                            objParamArr[1].DbType = DbType.DateTime;
                            objParamArr[1].Value = p_dtmStartDate;
                            objParamArr[2].DbType = DbType.DateTime;
                            objParamArr[2].Value = p_dtmEndDate;
                            objParamArr[3].Value = p_strMedicineTypeID;
                        }
                    }

                    objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbTemp, objParamArr);
                    if (m_dtbTemp != null && m_dtbTemp.Rows.Count > 0)
                    {
                        double.TryParse(m_dtbTemp.Rows[0][0].ToString(), out p_dblSumMoney);
                    }
                }
                if (p_dtbResult.Columns.Contains("medicineid_chr"))
                {
                    p_dtbResult.PrimaryKey = null;
                    p_dtbResult.Columns.Remove("medicineid_chr");
                    DataView dv = p_dtbResult.DefaultView;
                    dv.Sort = "medicinename_vchr desc";
                    p_dtbResult = dv.ToTable();
                }
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
    }
}
