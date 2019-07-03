using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 入库统计表    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsInStorageStatisticsReportSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 入库统计
        /// <summary>
        /// 入库统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intMedicineSetID">药品类型设置ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatistics(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strVendorSQL = string.Empty;
                string strSetID = string.Empty;
                if (!string.IsNullOrEmpty(p_strVendorID))
                {
                    strVendorSQL = @"
   and a.vendorid_chr = ? ";
                }
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @"
   and ty.medicinetypesetid = ?";
                }

                string strSQL = @"select c.usercode_chr,c.vendorname_vchr,
       ty.medicinetypesetname medicinetypename_vchr,
       sum(b.callprice_int * b.amount) inmoney,
       sum(b.wholesaleprice_int * b.amount) wholesalemoney,
       sum(b.retailprice_int * b.amount) retailmoney
  from t_ms_instorage_detal b
 inner join t_ms_instorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
  inner join t_ms_medicinetypeset ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
  left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 where a.formtype_int = 1 and b.status = 1
   and (a.state_int = 2 or a.state_int = 3)
   and a.exam_dat between ? and ?
   and a.storageid_chr = ? " + strVendorSQL + strSetID + @"
 group by ty.medicinetypesetname, a.vendorid_chr, c.vendorname_vchr,c.usercode_chr
 order by ty.medicinetypesetname, c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(p_strVendorID))
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_intMedicineSetID;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strVendorID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strVendorID;
                        objDPArr[4].Value = p_intMedicineSetID;
                    }
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 入库统计(外退)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intMedicineSetID">药品类型设置ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatisticsForeignRetreat(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                string strVendorSQL = string.Empty;
                string strSetID = string.Empty;
                if (!string.IsNullOrEmpty(p_strVendorID))
                {
                    strVendorSQL = @"
   and b.vendorid_chr = ? ";
                }
                if (p_intMedicineSetID > 0)
                {
                    strSetID = @"
   and ty.medicinetypesetid = ?";
                }

                string strSQL = @"select c.usercode_chr,c.vendorname_vchr,
        ty.medicinetypesetname medicinetypename_vchr,
        sum(b.callprice_int * b.netamount_int) inmoney,
        sum(b.wholesaleprice_int * b.netamount_int) wholesalemoney,
        sum(b.retailprice_int * b.netamount_int) retailmoney
  from t_ms_outstorage_detail b
 inner join t_ms_outstorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
  inner join t_ms_medicinetypeset ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
  left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 where (a.formtype = 2 or a.formtype = 5) and b.status = 1
   and (a.status = 2 or a.status = 3)
   and a.examdate_dat between ? and ?
   and a.storageid_chr = ? " + strVendorSQL + strSetID + @"
 group by ty.medicinetypesetname, b.vendorid_chr, c.vendorname_vchr,c.usercode_chr
 order by ty.medicinetypesetname, c.vendorname_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (string.IsNullOrEmpty(p_strVendorID))
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_intMedicineSetID;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(strSetID))
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strVendorID;
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].DbType = DbType.DateTime;
                        objDPArr[0].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        objDPArr[2].Value = p_strStorageID;
                        objDPArr[3].Value = p_strVendorID;
                        objDPArr[4].Value = p_intMedicineSetID;
                    }
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion
        #region 获取药品内退明细数据（报表打印）
        /// <summary>
        /// 表：T_MS_INSTORAGE（入库主表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInnerWithdrawDetailDataReport(string instorageid_vchr, out DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            dtbResult = null;
            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //问题：少一个字段：ComputeBillSum单据金额
            string strSQL = @"select distinct b.seriesid_int,
                b.seriesid2_int,
                b.medicineid_chr,
                b.medicinename_vch,
                b.medspec_vchr,
                case
                  when b.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   b.lotno_vchr
                end lotno_vchr,
                b.amount,
                b.unit_vchr,
                b.callprice_int,
                b.wholesaleprice_int,
                b.retailprice_int,
                b.instorageid_vchr,
                b.outstorageid_vchr,
                b.validperiod_dat,
                b.ruturnnum_int,
                b.productorid_chr,
                b.status,
                d.netamount_int,
                e.vendorid_chr,
                e.vendorname_vchr,
                f.assistcode_chr,
                g.realgross_int
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
  left outer join t_bse_medicine f on b.medicineid_chr = f.medicineid_chr
  left outer join t_ms_outstorage c on b.outstorageid_vchr =
                                       c.outstorageid_vchr
                                   and c.status > 1
  left outer join t_ms_outstorage_detail d on c.seriesid_int =
                                              d.seriesid2_int
                                          and d.status = 1
                                          and d.medicineid_chr =
                                              b.medicineid_chr
                                          and d.lotno_vchr = b.lotno_vchr
                                          and b.validperiod_dat =
                                              d.validperiod_dat
                                          and b.callprice_int =
                                              d.callprice_int
  left outer join t_bse_vendor e on d.vendorid_chr = e.vendorid_chr
  left outer join T_MS_STORAGE_DETAIL g on b.medicineid_chr =
                                           g.medicineid_chr
                                       and b.lotno_vchr = g.lotno_vchr
                                       and b.instorageid_vchr =
                                           g.instorageid_vchr
                                       and b.validperiod_dat =
                                           g.validperiod_dat
                                       and b.callprice_int =
                                           g.callprice_int
                                       and g.status = 1";

            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = instorageid_vchr;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

            }//try

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;


            }

            return lngRes;
        }

        #endregion

        #region 获取所有仓库名称
        /// <summary>
        /// 获取所有仓库名称
         /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor">仓库名称数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreroom(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbVendor)
        {
            p_dtbVendor = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select medicineroomid,medicineroomname,medicinetypeid_chr from t_ms_medicinestoreroomset";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
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
