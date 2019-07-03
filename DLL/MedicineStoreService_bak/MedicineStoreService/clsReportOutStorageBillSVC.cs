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
    public class clsReportOutStorageBillSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
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
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailBillInfo(int intDsOrMs, string strBegin, string strEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
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
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
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
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
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
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid">0000为全部</param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageBillInfo(int intDsOrMs, string strBegin, string strEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
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
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_outstorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_outstorage_detail e,
                                              t_ds_instorage f,
                                              t_bse_medstore g
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.instoredept_chr=f.borrowdept_chr(+)
                                          and f.borrowdept_chr=b.deptid_chr(+)
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
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
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
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strVendorid;
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
                            objDPArr[i++].Value = strTypeid;
                        }
                        else
                        {
                            objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                            objDPArr[i++].Value = strStorageid;
                            objDPArr[i++].Value = Convert.ToDateTime(strBegin + " 00:00:00");
                            objDPArr[i++].Value = Convert.ToDateTime(strEnd + " 23:59:59");
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
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGoWayStat(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDrugID,DateTime p_dtmStartDate,DateTime p_dtmEndDate,
            string p_strMedicineTypeID,out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition1 = string.Empty;
            string m_strCondition2 = string.Empty;
            if (p_strMedicineTypeID != "-1" && p_strMedicineTypeID != "")
            {
                m_strCondition1 = @" and h.medicinetypeid_chr = ? ";
                m_strCondition2 = @" and b.medicinetypeid_chr = ? ";
            }

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
				 where a.drugstoreid_chr = ? and a.examdate_dat between ? and ? " +
                     m_strCondition1 + @" having
				 sum(round(b.ipamount_int * b.opretailprice_int / h.packqty_dec,0)) > 0
				
				 group by a.instoredept_chr, c.deptname_vchr
				union
select d.diagdept_chr instoredept_chr,
			 e.deptname_vchr deptname_vchr,
			 0 outamount,
			 sum(round(a.ipamount_int * a.opretailprice_int / b.packqty_dec,4)) opramount,
			 0 putamount
	from t_ds_recipeaccount_detail a
	left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_ds_storage_detail c on c.seriesid_int = a.medseriesid_int
	left join t_opr_outpatientrecipe d on d.outpatrecipeid_chr =
																				a.outpatrecipeid_chr
	left join t_bse_deptdesc e on e.deptid_chr = d.diagdept_chr
 where c.status = 1
	 and a.state_int <> 0
	 and a.type_int = 2
	 and a.drugstoreid_int = ?
	 and a.operatedate_dat between ? and ?
	 " + m_strCondition2 + @" having
 sum(round(a.ipamount_int * a.opretailprice_int / b.packqty_dec,4)) > 0
 group by d.diagdept_chr, e.deptname_vchr)
group by instoredept_chr, deptname_vchr
 order by deptname_vchr";
//				select d.diagdept_chr instoredept_chr,
//							 f.deptname_vchr deptname_vchr,
//							 0 outamount,
//							 sum(e.ipamount_dec * g.ipretailprice_int) opramount,
//							 0 putamount
//					from t_opr_outpatientrecipe d
//					left join t_opr_recipededuct e on e.outpatrecipeid_chr =
//																						d.outpatrecipeid_chr
//					left join t_bse_deptdesc f on f.deptid_chr = d.diagdept_chr
//					left join t_ds_storage_detail g on g.seriesid_int =
//																						 e.medseriesid_int
//					left join t_bse_medicine i on i.medicineid_chr = e.medicineid_chr
//				 where e.drugstoreid_chr = ? and d.recorddate_dat between ? and ? " +
//                    m_strCondition2 + @" having
//				 sum(e.ipamount_dec * g.ipretailprice_int) > 0
//				 group by d.diagdept_chr, f.deptname_vchr)
// group by instoredept_chr, deptname_vchr
// order by deptname_vchr";
            //
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (p_strMedicineTypeID == "-1" || p_strMedicineTypeID == "")
                {
                    objHRPSvc.CreateDatabaseParameter(6, out objParamArr);
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
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(8, out objParamArr);
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
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
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
            if (dtTemp.Rows.Count > 0)
            {
                p_strDeptID = Convert.ToString(dtTemp.Rows[0]["deptid_chr"]);
            }
            return lngReturn;
        }
        #endregion


        #region 合并门西药房处方药品消耗住院中心药房摆药品消耗金额统计[三九特别需求]
        /// <summary>
        /// 合并门西药房处方药品消耗住院中心药房摆药品消耗金额统计 wuchongkun 2008-10-5
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtBeginDate">开始时间</param>
        /// <param name="p_dtEndDate">结束时间</param>
        /// <param name="p_dtResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUnionMedicineSumStat(System.Security.Principal.IPrincipal p_objPrincipal,DateTime p_dtBeginDate, DateTime p_dtEndDate,out DataTable p_dtResult)
        {
            long lngRes = -1;
            p_dtResult = new DataTable();
            string strSQL = @"select   t.assistcode_chr,
          t.medicinename_vchr,
          t.medspec_vchr,
          t.ipunit_chr,
          t.productorid_chr,
          t.unitprice_mny,
          sum(t.ipamount)ipamount,
         round(sum(t.sumprice),2) sumprice
          from 
(select  b.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr ipunit_chr,
       b.productorid_chr,
       b.unitprice_mny,
       sum(decode(a.type_int, 2, a.opamount_int, 1, -a.opamount_int)) ipamount,
       sum(round(decode(a.type_int,
                        2,
                        a.ipamount_int * a.opretailprice_int / b.packqty_dec,
                        1,
                        -a.ipamount_int * a.opretailprice_int /
                        b.packqty_dec),
                 4)) sumprice
  from t_ds_recipeaccount_detail a, t_bse_medicine b
 where b.medicineid_chr = a.medicineid_chr(+)
   and a.state_int <> 0
   and a.type_int <> 0
   and a.drugstoreid_int = '0000512'
   and a.operatedate_dat between ?
   and ?
 group by b.assistcode_chr,
          a.medicinename_vchr,
          a.medspec_vchr,
          a.opunit_chr,
          a.ipunit_chr,
          b.unitprice_mny,
          b.productorid_chr,
          b.opchargeflg_int
          
          union all

         select d.assistcode_chr,
       c.medname_vchr,
       d.medspec_vchr,
       d.opunit_chr,
       d.productorid_chr,
       d.unitprice_mny,
       sum(round(c.get_dec / d.packqty_dec, 2)) ipamount,
       sum(c.get_dec * c.unitprice_mny) sumprice
  from t_bih_opr_putmeddetail c
 inner join t_bse_medicine d on d.medicineid_chr = c.medid_chr
 where c.medstoreid_chr = '0003'
   and c.pubdate_dat between ?
   and ?
   and c.medicnetype_int = 1
   and c.isput_int = 1
   and c.status_int=1
   and c.examreturnmed_int = 0
 group by d.assistcode_chr,
          c.medname_vchr,
          d.medspec_vchr,
          d.opunit_chr,
          d.unitprice_mny,
          d.productorid_chr,
          c.unitprice_mny
          )t
          group by
          t.assistcode_chr,
          t.medicinename_vchr,
          t.medspec_vchr,
          t.ipunit_chr,
          t.unitprice_mny,
          t.productorid_chr
          order by sumprice desc";
            IDataParameter[] objParameterArr=null;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSVC = new clsHRPTableService();
            objHRPSVC.CreateDatabaseParameter(4,out objParameterArr);
            try
            {
                objParameterArr[0].DbType = DbType.Date;
                objParameterArr[0].Value = p_dtBeginDate;
                objParameterArr[1].DbType = DbType.Date;
                objParameterArr[1].Value = p_dtEndDate;
                objParameterArr[2].DbType = DbType.Date;
                objParameterArr[2].Value = p_dtBeginDate;
                objParameterArr[3].DbType = DbType.Date;
                objParameterArr[3].Value = p_dtEndDate;
                objHRPSVC.lngGetDataTableWithParameters(strSQL,ref p_dtResult,objParameterArr);
            }
            catch (Exception objex)
            {
                string strTmp = objex.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objex);
 
            }
            return lngRes = 1;
        }

        #endregion

        #region 获取住院西药房摆药金额统计表
        /// <summary>
        /// 获取住院西药房摆药金额统计表 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">部门id[区分住院中西药房]</param>
        /// <param name="p_dtBeginDate">开始时间</param>
        /// <param name="p_dtEndDate">结束时间</param>
        /// <param name="p_strMedicineTypeID">药品类型</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPutMedicineSumStat(System.Security .Principal.IPrincipal p_objPrincipal,string p_strDrugID,DateTime p_dtBeginDate,DateTime p_dtEndDate,
           string p_strMedicineTypeID,string p_strMedicineID,out DataTable p_dtResult )
        {
            long lngRes = -1;
            p_dtResult = new DataTable();
            int m_intParamCount = 3;
            string strSQL = null;
            string strSQL1 = @"        
       select b.assistcode_chr,
       a.medname_vchr,
       b.medspec_vchr,
       b.opunit_chr unit_vchr,
       round((a.unitprice_mny*b.packqty_dec),2) unitprice_mny,
       b.productorid_chr,
       sum(round(a.get_dec/b.packqty_dec,2)) get_dec,
       sum(get_dec * a.unitprice_mny) account_mny,
       c.deptname_vchr
  from t_bih_opr_putmeddetail a
 inner join t_bse_medicine b on b.medicineid_chr = a.medid_chr
 inner join t_bse_deptdesc c on c.deptid_chr = a.areaid_chr                        
                            and a.medstoreid_chr =?
                            and a.pubdate_dat between ? and ?
                            and a.medicnetype_int = 1
                            and a.isput_int = 1
                            and a.status_int=1";
            string strAdd=@"and a.medid_chr=?";
            string strEnd= @" group by b.assistcode_chr,
          a.medname_vchr,
          b.medspec_vchr,
          a.unit_vchr,
          b.productorid_chr,
          c.deptname_vchr,
          b.opunit_chr,
          b.packqty_dec,
          a.unitprice_mny";
            if (p_strMedicineID != "")
            {
                m_intParamCount = 4;
                strSQL = strSQL1 + strAdd + strEnd;
                strSQL = strSQL.ToString();
            }
            else
            {
                strSQL =strSQL1+strEnd;
                strSQL = strSQL.ToString();
            }
            IDataParameter[] objParamArr=null ;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSVC = new clsHRPTableService();
            objHRPSVC.CreateDatabaseParameter(m_intParamCount,out objParamArr);
            try
            {
                objParamArr[0].DbType=DbType.String ;
                objParamArr[0].Value=p_strDrugID.Trim ();
                objParamArr[1].DbType=DbType .DateTime;
                objParamArr[1].Value=p_dtBeginDate;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value=p_dtEndDate;
                if (m_intParamCount == 4)
                {
                    objParamArr[3].DbType = DbType.String;
                    objParamArr[3].Value = p_strMedicineID;
                }
               lngRes =objHRPSVC.lngGetDataTableWithParameters(strSQL ,ref p_dtResult ,objParamArr);

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

        #region 获取处方药品出库品种金额统计表

        /// <summary>
        /// 获取处方药品出库品种金额统计表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineTypeID">药品类型</param>
        /// <param name="p_strMedicineId">药品Id</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeOutSumStat(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineTypeID, string p_strMedicineId,out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
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
                    m_strCondition = @" and b.medicinetypeid_chr = ? and b.medicineid_chr = ?";
                    m_intParamCount += 2;
                }
            }
            else
            {
                if (p_strMedicineId != string.Empty)
                {
                    m_strCondition = @" and b.medicineid_chr = ?";
                    m_intParamCount++;
                }
            }
            #region oldcode
            //            string m_strSql = @"select b.assistcode_chr,
//       a.medicinename_vchr,
//       a.medspec_vchr,
//       decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) ipunit_chr,
//       b.productorid_chr,
//       decode(b.opchargeflg_int,
//              0,
//              sum(decode(a.type_int, 2, a.opamount_int, 1, -a.opamount_int)),
//              sum(decode(a.type_int, 2, a.ipamount_int, 1, -a.ipamount_int))) ipamount,
//       sum(round(decode(a.type_int,
//                  2,
//                  a.ipamount_int * a.opretailprice_int / b.packqty_dec,
//                  1,
//                  -a.ipamount_int * a.opretailprice_int / b.packqty_dec),4)) sumprice
//  from t_ds_recipeaccount_detail a
//  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
// where a.state_int <> 0
//   and a.type_int <> 0
//   and a.drugstoreid_int = ?
//   and a.operatedate_dat between ? and ?" +
//    m_strCondition + @" group by b.assistcode_chr,a.medicinename_vchr,
//					a.medspec_vchr,
//					a.opunit_chr,
//					a.ipunit_chr,
//					b.productorid_chr,
            //					b.opchargeflg_int order by b.assistcode_chr";
            #endregion
          
            string m_strSql = @"select b.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_chr ipunit_chr,
       b.productorid_chr,
       b.unitprice_mny,
       sum(decode(a.type_int, 2, a.opamount_int, 1, -a.opamount_int)) ipamount,
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
    m_strCondition + @" group by b.assistcode_chr,a.medicinename_vchr,
					a.medspec_vchr,
					a.opunit_chr,
					a.ipunit_chr,
					b.productorid_chr,
					b.opchargeflg_int,b.unitprice_mny order by sumprice desc ";
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
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_strMedicineId">药品Id</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            string p_strMedicineId, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;
            if (p_strDrugID != "0000")
            {
                m_strCondition = @" and g.medstoreid_chr = ? ";
                m_intParamCount++;
            }

            string m_strSql = @"select a.operatedate_dat,
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
