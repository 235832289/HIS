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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsInStorageStatisticsReport_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
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
   and ty.medicinetypeid_chr = ?";
                }

                string strSQL = @"select c.usercode_chr,c.vendorname_vchr,
       ty.medicinetypename_vchr,
       sum(b.callprice_int * b.amount) inmoney,
       sum(b.wholesaleprice_int * b.amount) wholesalemoney,
       sum(b.retailprice_int * b.amount) retailmoney
  from t_ms_instorage_detal b
 inner join t_ms_instorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
  inner join t_aid_medicinetype ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
  left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 where  b.status = 1
   and (a.state_int = 2 or a.state_int = 3)
   and a.instoragedate_dat between ? and ?
   and a.storageid_chr = ? " + strVendorSQL + strSetID + @"
 group by ty.medicinetypename_vchr, a.vendorid_chr, c.vendorname_vchr,c.usercode_chr
 order by ty.medicinetypename_vchr, c.vendorname_vchr";

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
   and ty.medicinetypeid_chr = ?";
                }

                string strSQL = @"select c.usercode_chr,c.vendorname_vchr,
        ty.medicinetypename_vchr,
        sum(b.callprice_int * b.netamount_int) inmoney,
        sum(b.wholesaleprice_int * b.netamount_int) wholesalemoney,
        sum(b.retailprice_int * b.netamount_int) retailmoney
  from t_ms_outstorage_detail b
 inner join t_ms_outstorage a on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine d on b.medicineid_chr = d.medicineid_chr
  inner join t_aid_medicinetype ty on ty.medicinetypeid_chr =
                                             d.medicinetypeid_chr
  left outer join t_bse_vendor c on b.vendorid_chr = c.vendorid_chr
 where (a.formtype = 2 or a.formtype = 5) and b.status = 1
   and (a.status = 2 or a.status = 3)
   and a.examdate_dat between ? and ?
   and a.storageid_chr = ? " + strVendorSQL + strSetID + @"
 group by ty.medicinetypename_vchr, b.vendorid_chr, c.vendorname_vchr,c.usercode_chr
 order by ty.medicinetypename_vchr, c.vendorname_vchr";

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

        #region 药品来源情况汇总表(广医三院）
        /// <summary>
        /// 药品来源情况汇总表(广医三院）
        /// </summary>
        /// <param name="p_StorageId">药库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intSetID">药品分类ID</param>
        /// <param name="p_intSelfMake">是否自制，0表示不限制，1表示自制，2表示非自制</param>
        /// <param name="p_intMakeIn">0表示全部，1表示国产，2表示合资，3表示合资</param>
        /// <param name="p_dtbData">统计数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatisticsNew(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intSetID,int p_intSelfMake,int p_intMakeIn, out DataTable p_dtbData)
        {
            p_dtbData = null;
            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select vendorname_vchr, a, b, b - a c
	from (select b.vendorid_chr,
							 c.vendorname_vchr,
							 sum(round(a.callprice_int * a.amount, 2)) a,
							 sum(a.retailprice_int * a.amount) b
					from t_ms_instorage_detal a
					left join t_ms_instorage b on b.seriesid_int = a.seriesid2_int
					left join t_bse_vendor c on c.vendorid_chr = b.vendorid_chr
					left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
				 where a.status = 1	and state_int in (2,3)				
					 and b.storageid_chr = ?
				and b.instoragedate_dat between ? and ?");	

                int iRow = 3;
                if (p_strVendorID != "")
                {
                    iRow += 1;
                    strSQL.Append(" and b.vendorid_chr = ? ");
                }
                if (p_intSetID != 0)
                {
                    iRow += 1;
                    strSQL.Append(" and d.medicinetypeid_chr = ? ");
                }
                if (p_intSelfMake != 0)
                {
                    if (p_intSelfMake == 1)
                    {
                        strSQL.Append(" and c.vendorname_vchr in ('制剂室','中药制剂室','合剂室') ");
                    }
                    else
                    {
                        strSQL.Append(" and c.vendorname_vchr not in ('制剂室','中药制剂室','合剂室') ");
                    }
                }
                if (p_intMakeIn != 0)
                {
                    iRow += 1;
                    strSQL.Append(" and d.isimport_chr = ? ");
                }
                strSQL.Append(" group by b.vendorid_chr,c.vendorname_vchr order by c.vendorname_vchr )");
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(iRow, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (iRow == 4)
                {
                    if (p_strVendorID != "")
                    {
                        objDPArr[3].Value = p_strVendorID;
                    }
                    else if (p_intSetID != 0)
                    {
                        objDPArr[3].Value = p_intSetID;
                    }
                    else if (p_intMakeIn != 0)
                    {
                        if(p_intMakeIn == 1)
                            objDPArr[3].Value = "F";//国产
                        else if (p_intMakeIn == 2)
                            objDPArr[3].Value = "H";//合资
                        else if (p_intMakeIn == 3)
                            objDPArr[3].Value = "T";//进口
                    }
                }

                if (iRow == 5)
                {
                    if (p_strVendorID != "")
                    {
                        objDPArr[3].Value = p_strVendorID;
                        if (p_intSetID != 0)
                        {
                            objDPArr[4].Value = p_intSetID;
                        }
                        else
                        {
                            if (p_intMakeIn == 1)
                                objDPArr[4].Value = "F";//国产
                            else if (p_intMakeIn == 2)
                                objDPArr[4].Value = "H";//合资
                            else if (p_intMakeIn == 3)
                                objDPArr[4].Value = "T";//进口
                        }
                    }
                    else
                    {
                        objDPArr[3].Value = p_intSetID;
                        if (p_intMakeIn == 1)
                            objDPArr[4].Value = "F";//国产
                        else if (p_intMakeIn == 2)
                            objDPArr[4].Value = "H";//合资
                        else if (p_intMakeIn == 3)
                            objDPArr[4].Value = "T";//进口                        
                    }
                }

                if (iRow == 6)
                {
                    objDPArr[3].Value = p_strVendorID;
                    objDPArr[4].Value = p_intSetID;
                    if (p_intMakeIn == 1)
                        objDPArr[5].Value = "F";//国产
                    else if (p_intMakeIn == 2)
                        objDPArr[5].Value = "H";//合资
                    else if (p_intMakeIn == 3)
                        objDPArr[5].Value = "T";//进口
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbData, objDPArr);                
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

        #region 入库统计报表（按类型）
        /// <summary>
        /// 入库统计报表（按类型）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="InstorageID"></param>
        /// <param name="Instoragetype"></param>
        /// <param name="dtmBegin"></param>
        /// <param name="dtmEnd"></param>
        /// <param name="strMedID"></param>
        /// <param name="strMedType"></param>
        /// <param name="strProduct"></param>
        /// <param name="p_intBid">是否中标</param>
        /// <param name="p_strBidYear">中标年份</param>      
        /// <param name="p_strBidYear2">中标年份2</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRptInstorage(bool p_blnCombine,string InstorageID,string Instoragetype,DateTime dtmBegin,DateTime dtmEnd,string strMedID,
                                      string strMedType, string strProduct, string p_strBidYear,string p_strBidYear2, out DataTable dtResult)
        {
            long lngRes = -1;
            string strSQL = @"select b.medicineid_chr,
       b.medicinename_vch,
       b.medspec_vchr,
       b.amount amount,
       b.callprice_int,
       b.callprice_int * b.amount callsum,
       b.retailprice_int retailprice,
       b.retailprice_int * b.amount unitprice,
       (b.retailprice_int - b.callprice_int) * b.amount diffsum,
       b.instorageid_vchr,
       a.instoragedate_dat,
       c.typename_vchr,
       b.productorid_chr,
       d.opunit_chr unit,
       decode(d.standard_int, 1, '是', '否') standard_int,
       d.standarddate
  from t_ms_instorage       a,
       t_ms_instorage_detal b,
       t_aid_impexptype     c,
       t_bse_medicine       d
 where a.seriesid_int = b.seriesid2_int
	 and b.medicineid_chr = d.medicineid_chr
	 and a.instoragetype_int = c.typecode_vchr
	 and (a.state_int = 3 or a.state_int = 2)
	 and b.status = 1
	 and (a.instoragedate_dat between ? and ?)
	 and a.storageid_chr = ?";
            dtResult = null;
            try
            {
                if (!string.IsNullOrEmpty(Instoragetype))
                {
                    strSQL += " and a.instoragetype_int = '" + Instoragetype + "'";
                }
                if (!string.IsNullOrEmpty(strMedID))
                {
                    if (p_blnCombine)
                        strSQL += " and d.assistcode_chr = '" + strMedID + "'";
                    else
                        strSQL += " and b.medicineid_chr = '" + strMedID + "'";
                }
                if (!string.IsNullOrEmpty(strProduct))
                {
                    strSQL += "and a.vendorid_chr = '" + strProduct + "'";
                }
                if (!string.IsNullOrEmpty(strMedType))
                {
                    strSQL += " and d.medicinetypeid_chr = '" + strMedType + "'";
                }
                
                if (!string.IsNullOrEmpty(p_strBidYear))
                {
                    strSQL += " and d.standarddate like '%" + p_strBidYear + "%'";
                }
            
                if (!string.IsNullOrEmpty(p_strBidYear2))
                {
                    strSQL += " and (d.standarddate not like '%" + p_strBidYear2 + "%' or d.standarddate is null) ";
                }
                    
                
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(3, out param);
                param[0].DbType = DbType.DateTime;
                param[0].Value = dtmBegin;
                param[1].DbType = DbType.DateTime;
                param[1].Value = dtmEnd;
                param[2].Value = InstorageID;
                //param[3].DbType = DbType.Int32;
                //param[3].Value = int.Parse(Instoragetype);
                //param[4].Value = Instoragetype;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataView dvResult = dtResult.DefaultView;
                    dvResult.Sort = "medicinename_vch";
                    dtResult = dvResult.ToTable();
                }
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

        #region 药房入库统计报表（按类型）
        /// <summary>
        /// 药房入库统计报表（按类型）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="InstorageID"></param>
        /// <param name="Instoragetype"></param>
        /// <param name="dtmBegin"></param>
        /// <param name="dtmEnd"></param>
        /// <param name="strMedID"></param>
        /// <param name="strMedType"></param>
        /// <param name="strProduct"></param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDrugStoreInstorageStat(bool p_blnCombine,string InstorageID, string Instoragetype, DateTime dtmBegin, DateTime dtmEnd, string strMedID,
                                      string strMedType, string strProduct,bool p_blnIsHospital, out DataTable dtResult)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            if (p_blnIsHospital)
            {
                strSQL = @"select b.medicineid_chr,
			 b.medicinename_vchr medicinename_vch,
			 b.medspec_vchr,
             decode(d.ipchargeflg_int, 0, b.opamount_int, b.ipamount_int) amount,
			 decode(d.ipchargeflg_int,
							0,
							b.opretailprice_int,
							round(b.opretailprice_int/b.packqty_dec,2)) retailprice,			 
       b.opretailprice_int,b.packqty_dec,b.ipamount_int,
       0 unitprice,
			 a.indrugstoreid_vchr instorageid_vchr,
			 a.drugstoreexam_date instoragedate_dat,
			 c.typename_vchr,
			 b.productorid_chr,
			 decode(d.ipchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit
	from t_ds_instorage        a,
			 t_ds_instorage_detail b,
			 t_aid_impexptype      c,
			 t_bse_medicine        d
 where a.seriesid_int = b.seriesid2_int(+)
	 and b.medicineid_chr = d.medicineid_chr(+)
	 and a.typecode_vchr = c.typecode_vchr(+)
	 and (a.status = 3 or a.status = 2)
	 and b.status = 1
	 and (a.drugstoreexam_date between ? and ?)
	 and a.drugstoreid_chr = ?";
            }
            else
            {
                strSQL = @"select b.medicineid_chr,
			 b.medicinename_vchr medicinename_vch,
			 b.medspec_vchr,
             decode(d.opchargeflg_int, 0, b.opamount_int, b.ipamount_int) amount,
			 decode(d.opchargeflg_int,
							0,
							b.opretailprice_int,
							round(b.opretailprice_int/b.packqty_dec,2)) retailprice,			 
       b.opretailprice_int,b.packqty_dec,b.ipamount_int,
       0 unitprice,
			 a.indrugstoreid_vchr instorageid_vchr,
			 a.drugstoreexam_date instoragedate_dat,
			 c.typename_vchr,
			 b.productorid_chr,
			 decode(d.opchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit
	from t_ds_instorage        a,
			 t_ds_instorage_detail b,
			 t_aid_impexptype      c,
			 t_bse_medicine        d
 where a.seriesid_int = b.seriesid2_int(+)
	 and b.medicineid_chr = d.medicineid_chr(+)
	 and a.typecode_vchr = c.typecode_vchr(+)
	 and (a.status = 3 or a.status = 2)
	 and b.status = 1
	 and (a.drugstoreexam_date between ? and ?)
	 and a.drugstoreid_chr = ?";
            }
            dtResult = null;
            try
            {
                int m_intParamCount = 3;
                if(!string.IsNullOrEmpty(Instoragetype))
                {
                    strSQL += " and a.typecode_vchr = ? ";
                    m_intParamCount++;
                }
                if (!string.IsNullOrEmpty(strMedID))
                {
                    if (p_blnCombine)
                        strSQL += " and d.assistcode_chr = ? ";
                    else
                        strSQL += " and b.medicineid_chr = ? ";
                    m_intParamCount++;
                }
                if (!string.IsNullOrEmpty(strProduct))
                {
                    strSQL += "and a.borrowdept_chr like ? ";
                    m_intParamCount++;
                }
                if (!string.IsNullOrEmpty(strMedType))
                {
                    strSQL += " and d.medicinetypeid_chr = ? ";
                    m_intParamCount++;
                }
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out param);
                param[0].DbType = DbType.DateTime;
                param[0].Value = dtmBegin;
                param[1].DbType = DbType.DateTime;
                param[1].Value = dtmEnd;
                param[2].Value = InstorageID;                
                
                if (m_intParamCount == 4)
                {
                    if (!string.IsNullOrEmpty(Instoragetype))
                    {
                        param[3].DbType = DbType.Int32;
                        param[3].Value = int.Parse(Instoragetype);
                    }
                    else if (!string.IsNullOrEmpty(strMedID))
                    {
                        param[3].Value = strMedID;
                    }
                    else if (!string.IsNullOrEmpty(strProduct))
                    {
                        param[3].Value = strProduct + "%";
                    }
                    else
                    {
                        param[3].Value = strMedType;
                    }
                }
                else if (m_intParamCount == 5)
                {
                    if (!string.IsNullOrEmpty(Instoragetype))
                    {
                        param[3].DbType = DbType.Int32;
                        param[3].Value = int.Parse(Instoragetype);
                        if (!string.IsNullOrEmpty(strMedID))
                        {
                            param[4].Value = strMedID;                            
                        }
                        else if (!string.IsNullOrEmpty(strProduct))
                        {
                            param[4].Value = strProduct + "%";
                        }
                        else
                        {
                            param[4].Value = strMedType;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(strMedID))
                        {
                            param[3].Value = strMedID;
                            if (!string.IsNullOrEmpty(strProduct))
                            {
                                param[4].Value = strProduct + "%";
                            }
                            else
                            {
                                param[4].Value = strMedType;
                            }
                        }
                        else
                        {
                            param[3].Value = strProduct + "%";
                            param[4].Value = strMedType;
                        }
                    }                    
                }
                else if (m_intParamCount == 6)
                {
                    if (!string.IsNullOrEmpty(Instoragetype))
                    {
                        param[3].DbType = DbType.Int32;
                        param[3].Value = int.Parse(Instoragetype);
                        if (!string.IsNullOrEmpty(strMedID))
                        {
                            param[4].Value = strMedID;
                            if (!string.IsNullOrEmpty(strProduct))
                            {
                                param[5].Value = strProduct + "%";    
                            }
                            else
                            {
                                param[5].Value = strMedType;
                            }
                        }
                        else if (!string.IsNullOrEmpty(strProduct))
                        {
                            param[4].Value = strProduct + "%";                        
                            param[5].Value = strMedType;
                        }
                    }
                    else
                    {
                        param[3].Value = strMedID;
                        param[4].Value = strProduct + "%";
                        param[5].Value = strMedType;
                    }
                }
                else if (m_intParamCount == 7)
                {
                    param[3].DbType = DbType.Int32;
                    param[3].Value = int.Parse(Instoragetype);
                    param[4].Value = strMedID;
                    param[5].Value = strProduct + "%";
                    param[6].Value = strMedType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, param);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataView dvResult = dtResult.DefaultView;
                    dvResult.Sort = "medicinename_vch";
                    dtResult = dvResult.ToTable();
                }
                objHRPSvc.Dispose();

                int iRowCount = dtResult.Rows.Count;
                double dblOpRetailprice = 0d;
                double dblPackqty = 0d;
                double dblIpamount = 0d;
                double dblRetailPriceSum = 0d;
                DataRow drTemp = null;
                for (int iR = 0; iR < iRowCount; iR++)
                {
                    drTemp = dtResult.Rows[iR];
                    double.TryParse(Convert.ToString(drTemp["opretailprice_int"]), out dblOpRetailprice);
                    double.TryParse(Convert.ToString(drTemp["packqty_dec"]), out dblPackqty);
                    double.TryParse(Convert.ToString(drTemp["ipamount_int"]), out dblIpamount);
                    dblRetailPriceSum = (dblOpRetailprice / dblPackqty) * dblIpamount;
                    drTemp["unitprice"] = dblRetailPriceSum;
                }
                dtResult.Columns.Remove(dtResult.Columns[5]);
                dtResult.Columns.Remove(dtResult.Columns[5]);
                dtResult.Columns.Remove(dtResult.Columns[5]);
                dtResult.AcceptChanges();
                drTemp = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 药房药品来源情况汇总表(广医三院）

        /// <summary>
        /// 药房药品来源情况汇总表(广医三院）
        /// </summary>
        /// <param name="p_StorageId">药库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_intSetID">药品分类ID</param>
        /// <param name="p_intSelfMake">是否自制，0表示不限制，1表示自制，2表示非自制</param>
        /// <param name="p_intMakeIn">0表示全部，1表示国产，2表示合资，3表示合资</param>
        /// <param name="p_dtbData">统计数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDrugStoreStatisticsNew(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intSetID, int p_intSelfMake, int p_intMakeIn, out DataTable p_dtbData)
        {
            p_dtbData = null;
            DataTable dt = null;
            long lngRes = 0;
            try
            {
//                StringBuilder strSQL = new StringBuilder(@"select vendorname_vchr, a, b, b - a c from (
//            select b.borrowdept_chr vendorid_chr,
//			 case
//				 when c.deptname_vchr is null then
//					'其他'
//				 else
//					c.deptname_vchr
//			 end vendorname_vchr,
//			 sum(a.opretailprice_int * a.opamount_int) a,
//			 sum(a.opretailprice_int * a.opamount_int) b
//	from t_ds_instorage_detail a
//	left join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
//	left join t_bse_deptdesc c on c.deptid_chr = b.borrowdept_chr
//	left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
// where (b.status = 2 or b.status = 3)
//	 and a.status = 1 

                StringBuilder strSQL = new StringBuilder(@"select vendorname_vchr,0 a,0 b,0 c,vendorid_chr,opretailprice_int,
                                                                  packqty_dec,ipamount_int
            
            from (
            select b.borrowdept_chr vendorid_chr,
			 case
				 when c.deptname_vchr is null then
					'其他'
				 else
					c.deptname_vchr
			 end vendorname_vchr,
       a.opretailprice_int,
       a.packqty_dec,
       a.ipamount_int,
       a.opamount_int
	from t_ds_instorage_detail a
	left join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
	left join t_bse_deptdesc c on c.deptid_chr = b.borrowdept_chr
	left join t_bse_medicine d on d.medicineid_chr = a.medicineid_chr
 where (b.status = 2 or b.status = 3)
	 and a.status = 1
	 and b.drugstoreid_chr = ?
	 and b.drugstoreexam_date between ? and ? ");

                int iRow = 3;
                if (p_strVendorID != "")
                {
                    iRow += 1;
                    strSQL.Append(" and b.borrowdept_chr = ? ");
                }
                if (p_intSetID != 0)
                {
                    iRow += 1;
                    strSQL.Append(" and d.medicinetypeid_chr = ? ");
                }
                if (p_intSelfMake != 0)
                {
                    if (p_intSelfMake == 1)
                    {
                        strSQL.Append(" and c.deptname_vchr in ('制剂室','中药制剂室','合剂室') ");
                    }
                    else
                    {
                        strSQL.Append(" and c.deptname_vchr not in ('制剂室','中药制剂室','合剂室') ");
                    }
                }
                if (p_intMakeIn != 0)
                {
                    iRow += 1;
                    strSQL.Append(" and d.isimport_chr = ? ");
                }
                //strSQL.Append(" group by b.borrowdept_chr, c.deptname_vchr order by c.deptname_vchr)");
                strSQL.Append(" )");
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(iRow, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = DateTime.Parse(p_dtmBegin.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = DateTime.Parse(p_dtmEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                if (iRow == 4)
                {
                    if (p_strVendorID != "")
                    {
                        objDPArr[3].Value = p_strVendorID;
                    }
                    else if (p_intSetID != 0)
                    {
                        objDPArr[3].Value = p_intSetID;
                    }
                    else if (p_intMakeIn != 0)
                    {
                        if (p_intMakeIn == 1)
                            objDPArr[3].Value = "F";//国产
                        else if (p_intMakeIn == 2)
                            objDPArr[3].Value = "H";//合资
                        else if (p_intMakeIn == 3)
                            objDPArr[3].Value = "T";//进口
                    }
                }

                if (iRow == 5)
                {
                    if (p_strVendorID != "")
                    {
                        objDPArr[3].Value = p_strVendorID;
                        if (p_intSetID != 0)
                        {
                            objDPArr[4].Value = p_intSetID;
                        }
                        else
                        {
                            if (p_intMakeIn == 1)
                                objDPArr[4].Value = "F";//国产
                            else if (p_intMakeIn == 2)
                                objDPArr[4].Value = "H";//合资
                            else if (p_intMakeIn == 3)
                                objDPArr[4].Value = "T";//进口
                        }
                    }
                    else
                    {
                        objDPArr[3].Value = p_intSetID;
                        if (p_intMakeIn == 1)
                            objDPArr[4].Value = "F";//国产
                        else if (p_intMakeIn == 2)
                            objDPArr[4].Value = "H";//合资
                        else if (p_intMakeIn == 3)
                            objDPArr[4].Value = "T";//进口                        
                    }
                }

                if (iRow == 6)
                {
                    objDPArr[3].Value = p_strVendorID;
                    objDPArr[4].Value = p_intSetID;
                    if (p_intMakeIn == 1)
                        objDPArr[5].Value = "F";//国产
                    else if (p_intMakeIn == 2)
                        objDPArr[5].Value = "H";//合资
                    else if (p_intMakeIn == 3)
                        objDPArr[5].Value = "T";//进口
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dt, objDPArr);

                objHRPServ.Dispose();

                DataView dv = new DataView(dt);
                dv.Sort = "vendorid_chr desc";
                dt = dv.ToTable();

                p_dtbData = dt.Clone();

                int iRowCount = dt.Rows.Count;
                double dblOpRetailprice = 0d;
                double dblPackqty = 0d;
                double dblIpamount = 0d;
                double dblRetailPriceSum = 0d;
                DataRow drTemp = null;
                DataRow dr1 = null;
                DataRow dr2 = null;
                dr1 = p_dtbData.NewRow();
                for (int iR = 0; iR < iRowCount; iR++)
                {
                    drTemp = dt.Rows[iR];
                    if (blnExists(drTemp["vendorid_chr"].ToString().Trim(), ref p_dtbData))
                    {
                        continue;
                    }

                    dr1["vendorname_vchr"] = drTemp["vendorname_vchr"];
                    for (int jR = iR; jR < iRowCount; jR++)
                    {
                        dr2 = dt.Rows[jR];
                        double.TryParse(Convert.ToString(dr2["opretailprice_int"]), out dblOpRetailprice);
                        double.TryParse(Convert.ToString(dr2["packqty_dec"]), out dblPackqty);
                        double.TryParse(Convert.ToString(dr2["ipamount_int"]), out dblIpamount);
                        if (drTemp["vendorid_chr"].ToString().Trim() == dr2["vendorid_chr"].ToString().Trim())
                        {
                            dblRetailPriceSum += (dblOpRetailprice / dblPackqty) * dblIpamount;
                        }
                    }
                    dr1["a"] = dblRetailPriceSum;
                    dr1["b"] = dblRetailPriceSum;
                    dr1["c"] = 0;
                    dr1["vendorid_chr"] = drTemp["vendorid_chr"];
                    p_dtbData.Rows.Add(dr1.ItemArray);
                    dblRetailPriceSum = 0d;
                }
                p_dtbData.Columns.Remove(p_dtbData.Columns[4]);
                p_dtbData.Columns.Remove(p_dtbData.Columns[4]);
                p_dtbData.Columns.Remove(p_dtbData.Columns[4]);
                p_dtbData.Columns.Remove(p_dtbData.Columns[4]);
                p_dtbData.AcceptChanges();
                dr1 = null;
                dr2 = null;
                drTemp = null;
                dt.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        private bool blnExists(string p_vendorid, ref DataTable p_dtbData)
        {
            bool blnExist = false;
            int iCount = p_dtbData.Rows.Count;
            for (int i = 0; i < iCount; i++)
            {
                if (p_dtbData.Rows[i]["vendorid_chr"].ToString().Trim() == p_vendorid)
                {
                    blnExist = true;
                    break;
                }
            }
            return blnExist;
        }
        #endregion
    }
}
