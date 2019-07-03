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
    /// 入库单据
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsReportInStorageBillSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 入库类别
        /// <summary>
        /// 入库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorageType(out DataTable m_objTable)
        {
            long lngRes = -1;
            m_objTable = new DataTable();

            string strSql = @"select t.typename_vchr,t.typecode_vchr from t_aid_impexptype t where flag_int=0";
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

        #region 缓存供贷商表
        /// <summary>
        /// 缓存供贷商表
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        /// <param name="m_dtVendor"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetVendorInfo(int intDsOrMs, out DataTable m_dtVendor)
        {
            long lngRes = -1;
            m_dtVendor = new DataTable();
            string strSql = "";

            if (intDsOrMs == 0)
            {
                strSql = @"select a.deptid_chr id, a.deptname_vchr name, 
                                  a.usercode_vchr code,a.pycode_chr,a.wbcode_chr
                             from t_ms_exportdept b, t_bse_deptdesc a 
                            where b.exportdept_chr=a.deptid_chr(+)
                         order by b.seriesid_int";
            }
            else
            {
                strSql = @"select t.vendorid_chr id, t.vendorname_vchr name, 
                                     t.usercode_chr code,t.pycode_chr,t.wbcode_chr 
                                from t_bse_vendor t where vendortype_int = 1 or vendortype_int = 3 
                            order by t.usercode_chr";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref m_dtVendor);

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

        #region 获取入库单据数据
        /// <summary>
        /// 获取入库单据数据
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid">0000为全部</param>
        /// <param name="m_dtResult"></param>
        /// <param name="strStorageid">0000为全部</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageBillInfo(int intDsOrMs, string strBegin, string strEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
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
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e 
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreexam_date between ? and ?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e 
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreexam_date between ? and ?
                                          and b.deptid_chr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e 
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreexam_date between ? and ?
                                          and c.typecode_vchr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e 
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreexam_date between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
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
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
                                          and b.deptid_chr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
                                          and c.typecode_vchr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
                                              b.deptname_vchr,
                                              c.typename_vchr,
                                              d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.drugstoreexam_date instoragedate_dat,
                                              a.indrugstoreid_vchr instorageid_vchr,
                                              b.deptname_vchr vendorname_vchr,
                                              sum(e.ipamount_int*e.ipretailprice_int) allprice,
                                              c.typename_vchr,
                                              d.lastname_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_bse_employee d,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.borrowdept_chr=b.deptid_chr(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.makerid_chr=d.empid_chr(+)
                                          and a.seriesid_int=e.seriesid2_int(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
                                          and c.typecode_vchr=?
                                          and b.deptid_chr=?
 and (a.status = 2 or a.status = 3) and e.status = 1
                                     group by a.drugstoreexam_date,
                                              a.indrugstoreid_vchr,
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
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e 
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragedate_dat between ? and ?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e 
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragedate_dat between ? and ?
                              and b.vendorid_chr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e 
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e 
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
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
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and b.vendorid_chr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                    }
                    else
                    {
                        if (strVendorid == "0000")
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  c.typename_vchr,
                                  d.lastname_vchr";
                        }
                        else
                        {
                            strSql = @"select a.instoragedate_dat,a.instorageid_vchr,
                                  b.vendorname_vchr,
                                  sum(e.amount*e.callprice_int) allprice,
                                  c.typename_vchr,
                                  d.lastname_vchr
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_bse_employee d,
                                  t_ms_instorage_detal e
                            where a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.makerid_chr=d.empid_chr(+)
                              and a.seriesid_int=e.seriesid2_int(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
and state_int in (2,3) and status = 1
                         group by a.instoragedate_dat,a.instorageid_vchr,
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

        #region 获取入库单据的明细数据
        /// <summary>
        /// 获取入库单据的明细数据
        /// </summary>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="strTypeid"></param>
        /// <param name="strVendorid"></param>
        /// <param name="m_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetailBillInfo(int intDsOrMs, string strBegin, string strEnd, string strTypeid, string strVendorid, string strStorageid, out DataTable m_dtResult)
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreexam_date between ? and ?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreexam_date between ? and ?
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreexam_date between ? and ?
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e 
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreexam_date between ? and ?
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vchr,e.medspec_vchr,
                                              e.ipunit_chr,
                                              e.productorid_chr,
                                              e.ipamount_int,
                                              e.ipretailprice_int,
                                              e.lotno_vchr
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
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
                                         from t_ds_instorage a,
                                              t_bse_deptdesc b,
                                              t_aid_impexptype c,
                                              t_ds_instorage_detail e,
                                              t_bse_medstore f
                                        where a.seriesid_int=e.seriesid2_int(+)
                                          and a.typecode_vchr=c.typecode_vchr(+)
                                          and a.borrowdept_chr=b.deptid_chr(+)
                                          and a.drugstoreid_chr=f.deptid_chr(+)
                                          and f.medstoreid_chr=?
                                          and a.drugstoreexam_date between ? and ?
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
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragedate_dat between ? and ?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
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
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
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
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
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
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  e.retailprice_int,
                                  e.lotno_vchr,
                                  e.validperiod_dat";
                        }
                        else
                        {
                            strSql = @"select e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
                                  e.callprice_int,
                                  sum(e.amount*e.callprice_int) as callprice,
                                  e.retailprice_int,
                                  sum(e.amount*e.retailprice_int) as retailprice,
                                  e.lotno_vchr,
                                  e.validperiod_dat
                             from t_ms_instorage a,
                                  t_bse_vendor b,
                                  t_aid_impexptype c,
                                  t_ms_instorage_detal e 
                            where a.seriesid_int=e.seriesid2_int(+)
                              and a.instoragetype_int=c.typecode_vchr(+)
                              and a.vendorid_chr=b.vendorid_chr(+)
                              and a.storageid_chr=?
                              and a.instoragedate_dat between ? and ?
                              and c.typecode_vchr=?
                              and b.vendorid_chr=?
                         group by e.medicinename_vch,e.medspec_vchr,e.productorid_chr,
                                  e.invoicecode_vchr,
                                  e.invoicedater_dat,
                                  e.amount,
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

        #region 库房名称
        /// <summary>
        /// 库房名称
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetStorageName(int intDsOrMs, out DataTable dt)
        {
            long lngRes = -1;
            dt = new DataTable();
            string strSql = "";
            if (intDsOrMs == 0)
            {
                strSql = @"select t.medstoreid_chr storageid_chr,t.medstorename_vchr storagename_vchr from t_bse_medstore t";
            }
            else
            {
                strSql = @"select t.storageid_chr,t.storagename_vchr from t_bse_storage t";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dt);

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
    }
}
