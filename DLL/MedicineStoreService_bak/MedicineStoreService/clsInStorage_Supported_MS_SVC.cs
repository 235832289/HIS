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
    /// 入库
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsInStorage_Supported_MS_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {     
        #region 获取最近一次的中标单位及批准文号

        /// <summary>
        /// 获取最近一次的中标单位及批准文号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批准文号</param>
        /// <param name="p_strBidCompanyID">中标单位</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestBidCompany(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out string p_strLotNO, out string p_strBidCompanyID)
        {
            p_strBidCompanyID = string.Empty;
            p_strLotNO = string.Empty;
            if (p_strMedicineID == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = string.Empty;
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select    case
    when lotno_vchr = 'UNKNOWN' then
     ''
    else
        lotno_vchr
    end lotno_vchr, acceptancecompany_chr
  from (select t.lotno_vchr, t.acceptancecompany_chr
          from t_ms_instorage_detal t, t_ms_instorage a
         where t.medicineid_chr = ?
           and t.status = 1
           and t.seriesid2_int = a.seriesid_int
           and a.state_int <> 0
         
         order by seriesid_int desc)
 where rownum = 1";//  and a.formtype_int = 1
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 t.lotno_vchr, t.acceptancecompany_chr
  from t_ms_instorage_detal t, t_ms_instorage a
 where t.medicineid_chr = ?
   and t.status = 1
   and a.seriesid_int = t.seriesid2_int
   and a.state_int <> 0

 order by t.seriesid_int desc";
                }//   and a.formtype_int = 1

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_strBidCompanyID = dtbValue.Rows[0]["ACCEPTANCECOMPANY_CHR"].ToString();
                    p_strLotNO = dtbValue.Rows[0]["lotno_vchr"].ToString();
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

        #region 获取最近一次的价格
        /// <summary>
        /// 获取最近一次的价格
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dcmAvgPrice">平均入价</param>
        /// <param name="p_dcmLastBuyIn">上一次购入</param>
        /// <param name="p_dcmLastWholeSale">上一次批发</param>
        /// <param name="p_dcmLastRetail">上一次零售</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestPrice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out decimal p_dcmAvgPrice, out decimal p_dcmLastBuyIn, out decimal p_dcmLastWholeSale, out decimal p_dcmLastRetail)
        {
            p_dcmAvgPrice = 0m;
            p_dcmLastBuyIn = 0m;
            p_dcmLastRetail = 0m;
            p_dcmLastWholeSale = 0m;

            if (p_strMedicineID == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = string.Empty;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select avgcallprice_int, callprice_int, retailprice_int, wholesaleprice_int
  from (select a.avgcallprice_int,
               b.callprice_int,
               b.retailprice_int,
               b.wholesaleprice_int
          from t_ms_storage a, t_ms_storage_detail b
         where a.medicineid_chr = b.medicineid_chr
           and a.medicineid_chr = ?
           and b.status = 1
         order by b.seriesid_int desc)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 a.avgcallprice_int,
       b.callprice_int,
       b.retailprice_int,
       b.wholesaleprice_int
  from t_ms_storage a, t_ms_storage_detail b
 where a.medicineid_chr = b.medicineid_chr
   and a.medicineid_chr = ?
   and b.status = 1
   order by b.seriesid_int desc";
                }


                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_dcmAvgPrice = Convert.ToDecimal(dtbValue.Rows[0]["avgcallprice_int"]);
                    p_dcmLastBuyIn = Convert.ToDecimal(dtbValue.Rows[0]["callprice_int"]);
                    p_dcmLastRetail = Convert.ToDecimal(dtbValue.Rows[0]["retailprice_int"]);
                    p_dcmLastWholeSale = Convert.ToDecimal(dtbValue.Rows[0]["wholesaleprice_int"]);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取最近一次的包装购入价格
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dcmLastBuyIn">上一次购入</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestPackBuyInPrice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out decimal p_dcmLastBuyIn)
        {
            p_dcmLastBuyIn = 0m;

            if (p_strMedicineID == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = string.Empty ;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select packcallprice_int
  from (select a.packcallprice_int
          from t_ms_instorage_detal a, t_ms_instorage b
         where a.medicineid_chr = ?
           and a.status = 1
           and a.seriesid2_int = b.seriesid_int
           and b.state_int <> 0
         order by a.seriesid_int desc)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 a.packcallprice_int
  from t_ms_instorage_detal a, t_ms_instorage b
 where a.medicineid_chr = ? and a.status = 1 
   and a.seriesid2_int = b.seriesid_int
   and b.state_int <> 0
 order by a.seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_dcmLastBuyIn = Convert.ToDecimal(dtbValue.Rows[0]["PACKCALLPRICE_INT"]);
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

        #region 获取最近一次的相关人员信息
        /// <summary>
        /// 获取最近一次的相关人员信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strBuyerID">采购员ID</param>
        /// <param name="p_strBuyerName">采购员</param>
        /// <param name="p_strStoragerID">仓管员ID</param>
        /// <param name="p_strStoragerName">仓管员</param>
        /// <param name="p_strAccounterID">会计员ID</param>
        /// <param name="p_strAccounterName">会计员</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestEmpInfo(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStorageID, out string p_strBuyerID,out string p_strBuyerName,
            out string p_strStoragerID, out string p_strStoragerName, out string p_strAccounterID, out string p_strAccounterName)
        {
            p_strBuyerID = string.Empty;
            p_strBuyerName = string.Empty;
            p_strStoragerID = string.Empty;
            p_strStoragerName = string.Empty;
            p_strAccounterID = string.Empty;
            p_strAccounterName = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = string.Empty ;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select buyerid_char,
       storagerid_char,
       accounterid_char,
       buyername,
       storagername,
       accountername
  from (select a.buyerid_char,
               a.storagerid_char,
               a.accounterid_char,
               b.lastname_vchr buyername,
               c.lastname_vchr storagername,
               d.lastname_vchr accountername
          from t_ms_instorage a
          left outer join t_bse_employee b on a.buyerid_char = b.empid_chr
          left outer join t_bse_employee c on a.storagerid_char =
                                              c.empid_chr
          left outer join t_bse_employee d on a.accounterid_char =
                                              d.empid_chr
         where a.storageid_chr = ?

          and a.state_int <> 0
         order by seriesid_int desc)
 where rownum = 1";       //   and a.formtype_int = 1
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 a.buyerid_char,
       a.storagerid_char,
       a.accounterid_char,
       b.lastname_vchr buyername,
       c.lastname_vchr storagername,
       d.lastname_vchr accountername
  from t_ms_instorage a
  left outer join t_bse_employee b on a.buyerid_char = b.empid_chr
  left outer join t_bse_employee c on a.storagerid_char = c.empid_chr
  left outer join t_bse_employee d on a.accounterid_char = d.empid_chr
  where a.storageid_chr = ?

   and a.state_int <> 0
 order by seriesid_int desc";//   and a.formtype_int = 1
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_strBuyerID = dtbValue.Rows[0]["BUYERID_CHAR"].ToString();
                    p_strBuyerName = dtbValue.Rows[0]["buyername"].ToString();
                    p_strStoragerID = dtbValue.Rows[0]["STORAGERID_CHAR"].ToString();
                    p_strStoragerName = dtbValue.Rows[0]["storagername"].ToString();
                    p_strAccounterID = dtbValue.Rows[0]["ACCOUNTERID_CHAR"].ToString();
                    p_strAccounterName = dtbValue.Rows[0]["accountername"].ToString();
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

        #region 获取入库明细表内容

        /// <summary>
        /// 获取入库明细表内容

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetal(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_lngSeries2ID < 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select   t.seriesid_int, t.seriesid2_int, t.medicineid_chr,
         t.medicinename_vch, t.medspec_vchr, t.packamount, t.packunit_vchr,
         t.packcallprice_int, t.packconvert_int,
         case
            when t.lotno_vchr = 'UNKNOWN'
               then ''
            else t.lotno_vchr
         end lotno_vchr, t.amount, t.callprice_int, t.wholesaleprice_int,
         t.retailprice_int, t.validperiod_dat, t.acceptance_int,
         t.approvecode_vchr, t.apparentquality_int, t.packquality_int,
         t.examrusult_int, t.examiner, t.productorid_chr, t.accountperiod_int,
         t.acceptancecompany_chr, t.unit_vchr, t.status, t.ruturnnum_int,
         t.grossprofitrate_int, t.limitunitprice_mny,
         v.vendorname_vchr acceptancecompanyname,
         e.lastname_vchr examinername,
         case
            when t.acceptance_int = 1
               then '是'
            when t.acceptance_int = 0
               then '否'
            else ''
         end acceptancename,
         case
            when t.apparentquality_int = 1
               then '合格'
            when t.apparentquality_int = 0
               then '不合格'
            else ''
         end apparentqualityname,
         case
            when t.packquality_int = 1
               then '合格'
            when t.packquality_int = 0
               then '不合格'
            else ''
         end packqualityname,
         case
            when t.examrusult_int = 1
               then '合格'
            when t.examrusult_int = 0
               then '不合格'
            else ''
         end examrusultname,
         0 inmoney, 0 salemoney, 0 wholesalemoney,
         b.assistcode_chr medicinecode, b.medicinepreptype_chr,
         b.medicinetypeid_chr, t.invoicedater_dat, t.invoicecode_vchr,a.instoragetype_int typecode_vchr,
         t.gmpflag_int,
			 decode(t.gmpflag_int,0,'不符合',1,'符合') gmpflagname,
			 t.trademark_vchr
    from t_ms_instorage_detal t left outer join t_bse_vendor v on v.vendorid_chr =
                                                                    t.acceptancecompany_chr
         left outer join t_bse_employee e on e.empid_chr = t.examiner
         inner join t_bse_medicine b on t.medicineid_chr = b.medicineid_chr
         left join t_ms_instorage a on a.seriesid_int = t.seriesid2_int
   where t.seriesid2_int = ? and t.status = 1
order by t.seriesid_int ";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeries2ID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbValue != null)
                {
                    p_dtbValue.Columns["inmoney"].Expression = "callprice_int * amount";
                    p_dtbValue.Columns["salemoney"].Expression = "retailprice_int * amount";
                    p_dtbValue.Columns["wholesalemoney"].Expression = "wholesaleprice_int * amount";
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

        #region 最新的入库单据号

        /// <summary>
        /// 最新的入库单据号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strType">入类型</param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestInStorageID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strType, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.instorageid_vchr)
  from t_ms_instorage t
 where t.instorageid_vchr like ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                DateTime dtmNow = DateTime.Now;
                clsMS_Public_Supported_SVC clsPub = new clsMS_Public_Supported_SVC();
                clsPub.m_lngGetCurrentDateTime(out dtmNow);
                objDPArr[0].Value = dtmNow.ToString("yyyyMMdd") + p_strType + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + "0001";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + "0001";
                    }
                    else
                    {
                        strTemp = strTemp.Substring(9, 4);
                        p_strID = dtmNow.ToString("yyyyMMdd") + p_strType + (Convert.ToInt32(strTemp) + 1).ToString("0000");
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

        #region 获取入库主表内容
        /// <summary>
        /// 获取入库主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorage(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_strStorageID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.instorageid_vchr,
       a.formtype_int,
       a.instoragetype_int,
       a.state_int,
       a.storageid_chr,
       a.vendorid_chr,
       a.buyerid_char,
       a.storagerid_char,
       a.accounterid_char,
       a.instoragedate_dat,
       a.neworder_dat,
       a.exam_dat,
       a.account_dat,
       a.supplycode_vchr,
       a.paystate_int,
       a.paydate_dat,
       a.commnet_vchr,
       a.makerid_chr,
       a.examerid_chr,
       a.inaccounterid_chr,
       b.vendorname_vchr,
       case state_int
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 0 then
          '删除'
         when 3 then
          '入帐'
         else
          ''
       end statedesc,
       case instoragetype_int
         when 1 then
          '采购入库'
         when 2 then
          '生产入库'
         when 3 then
          '即入即出'
         else
          ''
       end instoragetypedesc,
       c.lastname_vchr makername,
       d.lastname_vchr examername,
       e.lastname_vchr buyername,
       f.lastname_vchr storagername,
       g.lastname_vchr accountername,
       h.deptname_vchr,
        h.deptid_chr, a.Procurement 
  from t_ms_instorage a
 inner join t_bse_vendor b on a.vendorid_chr = b.vendorid_chr
 left outer join t_bse_employee c on c.empid_chr = a.makerid_chr
 left outer join t_bse_employee d on d.empid_chr = a.examerid_chr
 left outer join t_bse_employee e on e.empid_chr = a.buyerid_char
 left outer join t_bse_employee f on f.empid_chr = a.storagerid_char
 left outer join t_bse_employee g on g.empid_chr = a.accounterid_char
 left outer join t_bse_deptdesc h on h.deptid_chr = a.exportdept_chr
 where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?
   and a.state_int <> 0
 order by a.seriesid_int desc";
                //   and a.formtype_int = 1
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBeginDate;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEndDate;

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
        /// 获取入库主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicineType">药品类型</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorage(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strInStorageID, string p_strMedicineType, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_strStorageID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.instorageid_vchr,
       a.formtype_int,
       a.instoragetype_int,
       a.state_int,
       a.storageid_chr,
       a.vendorid_chr,
       a.buyerid_char,
       a.storagerid_char,
       a.accounterid_char,
       a.instoragedate_dat,
       a.neworder_dat,
       a.exam_dat,
       a.account_dat,
       a.supplycode_vchr,
       a.paystate_int,
       a.paydate_dat,
       a.commnet_vchr,
       a.makerid_chr,
       a.examerid_chr,
       a.inaccounterid_chr,
       b.vendorname_vchr,
       case state_int
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 0 then
          '删除'
         when 3 then
          '入帐'
         else
          ''
       end statedesc,
       case instoragetype_int
         when 1 then
          '采购入库'
         when 2 then
          '生产入库'
         when 3 then
          '即入即出'
         else
          ''
       end instoragetypedesc,
       c.lastname_vchr makername,
       d.lastname_vchr examername,
       e.lastname_vchr buyername,
       f.lastname_vchr storagername,
       g.lastname_vchr accountername,
       h.deptname_vchr,
       h.deptid_chr, a.Procurement 
  from t_ms_instorage a
 inner join t_bse_vendor b on a.vendorid_chr = b.vendorid_chr
 inner join (select i.seriesid_int,
                    i.medicinename_vch,
                    i.seriesid2_int,
                    j.medicinetypeid_chr,
                    j.assistcode_chr
               from t_ms_instorage_detal i, t_bse_medicine j
              where i.medicineid_chr = j.medicineid_chr and i.status = 1) h on a.seriesid_int =
                                                              h.seriesid2_int
 left outer join t_bse_employee c on c.empid_chr = a.makerid_chr
 left outer join t_bse_employee d on d.empid_chr = a.examerid_chr
 left outer join t_bse_employee e on e.empid_chr = a.buyerid_char
 left outer join t_bse_employee f on f.empid_chr = a.storagerid_char
 left outer join t_bse_employee g on g.empid_chr = a.accounterid_char
 left outer join t_bse_deptdesc h on h.deptid_chr = a.exportdept_chr
 where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?
   and (h.medicinename_vch like ?
   or h.assistcode_chr like ?)
   and b.vendorname_vchr like ?
   and a.instorageid_vchr like ?
   and h.medicinetypeid_chr like ?
   and a.state_int <> 0
 order by a.seriesid_int desc";
                // and a.formtype_int = 1
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBeginDate;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEndDate;
                objDPArr[3].Value = p_strMedicineName + "%";
                objDPArr[4].Value = p_strMedicineName + "%";
                objDPArr[5].Value = p_strVendorName + "%";
                objDPArr[6].Value = p_strInStorageID + "%";
                if (p_strMedicineType != "0")
                {
                    objDPArr[7].Value = p_strMedicineType + "%";
                }
                else
                {
                    objDPArr[7].Value = "%";
                }

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

        #region 获取入库主表内容（多类型）

        /// <summary>
        /// 获取入库主表内容（多类型）

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicineType">药品类型</param>
        /// <param name="p_intInStorageTypeID">入库类型</param>
        /// <param name="p_intPayState">是否已付款</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorage(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine,DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineID, string p_strVendorName, string p_strInStorageID, string p_strMedicineType, int p_intInStorageTypeID,int p_intPayState,out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_strStorageID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
                a.instorageid_vchr,
                a.formtype_int,
                a.instoragetype_int,
                a.state_int,
                a.storageid_chr,
                a.vendorid_chr,
                a.buyerid_char,
                a.storagerid_char,
                a.accounterid_char,
                a.instoragedate_dat,
                a.neworder_dat,
                a.exam_dat,
                a.account_dat,
                a.supplycode_vchr,
                a.paystate_int,
                a.paydate_dat,
                a.commnet_vchr,
                a.makerid_chr,
                a.examerid_chr,
                a.inaccounterid_chr,
                b.vendorname_vchr,
                case state_int
                  when 1 then
                   '新制'
                  when 2 then
                   '审核'
                  when 0 then
                   '删除'
                  when 3 then
                   '入帐'
                  else
                   ''
                end statedesc,
                k.typename_vchr instoragetypedesc,
                c.lastname_vchr makername,
                d.lastname_vchr examername,
                e.lastname_vchr buyername,
                f.lastname_vchr storagername,
                g.lastname_vchr accountername,
                y.deptname_vchr,
				y.deptid_chr,
                m.typename_vchr as outtypename,
                a.outtypecode_vchr,
                z.buyinmoney,
                z.retailprice,
                decode(a.paystate_int, 0, '是', '否') paystate, a.Procurement 
  from t_ms_instorage a
 inner join t_bse_vendor b on a.vendorid_chr = b.vendorid_chr
 inner join (select seriesid2_int,
                    sum(round(i.callprice_int * i.amount, 2)) buyinmoney,
                    sum(i.retailprice_int * i.amount) retailprice
               from t_ms_instorage_detal i
              where i.status = 1
              group by i.seriesid2_int) z on a.seriesid_int =
                                             z.seriesid2_int
 inner join (select i.seriesid_int,
                    i.medicineid_chr,
                    i.medicinename_vch,
                    i.seriesid2_int,
                    j.medicinetypeid_chr,
                    j.assistcode_chr
               from t_ms_instorage_detal i, t_bse_medicine j
              where i.medicineid_chr = j.medicineid_chr
                and i.status = 1) h on a.seriesid_int = h.seriesid2_int
  left outer join t_bse_employee c on c.empid_chr = a.makerid_chr
  left outer join t_bse_employee d on d.empid_chr = a.examerid_chr
  left outer join t_bse_employee e on e.empid_chr = a.buyerid_char
  left outer join t_bse_employee f on f.empid_chr = a.storagerid_char
  left outer join t_bse_employee g on g.empid_chr = a.accounterid_char
  left outer join t_bse_deptdesc y on y.deptid_chr = a.exportdept_chr
  left join t_aid_impexptype k on k.typecode_vchr = a.instoragetype_int
  left join t_aid_impexptype m on a.outtypecode_vchr = m.typecode_vchr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                string m_strAdd;
                if (p_blnCombine)
                {                    
                    m_strAdd = @"and (h.medicinename_vch like ? or h.assistcode_chr like ?)";                   
                }
                else
                {
                    if (p_strMedicineID == "" || p_strMedicineID == null)
                    {
                        m_strAdd = @"and(h.medicinename_vch like ? or h.assistcode_chr like ?)";
                    }
                    else
                    {
                        m_strAdd = @"and (h.medicineid_chr like ? or h.medicinename_vch like ?)";
                    }
                }
                
                if (p_intInStorageTypeID == 0)
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?"+m_strAdd+@"
   and b.vendorname_vchr like ?
   and a.instorageid_vchr like ?
   and h.medicinetypeid_chr like ?   
   and a.state_int <> 0";
                    if(p_intPayState != 2)
                    {
                        strSQL += " and a.paystate_int = ?";
                    }
                    strSQL += "order by a.seriesid_int desc";
                    //   and a.formtype_int = 1
                    if (p_intPayState == 2)
                    {
                        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(9, out objDPArr);
                    }
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBeginDate;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEndDate;
                    objDPArr[3].Value = p_strMedicineID+"%";
                    objDPArr[4].Value = p_strMedicineID + "%";
                    objDPArr[5].Value = p_strVendorName + "%";
                    objDPArr[6].Value = p_strInStorageID + "%";
                    if (p_strMedicineType != "0")
                    {
                        objDPArr[7].Value = p_strMedicineType + "%";
                    }
                    else
                    {
                        objDPArr[7].Value = "%";
                    }
                    if (p_intPayState != 2)
                    {
                        objDPArr[8].Value = p_intPayState;
                    }
                }
                else
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?
   and (h.medicineid_chr like ?
   or h.assistcode_chr like ?)
   and b.vendorname_vchr like ?
   and a.instorageid_vchr like ?
   and h.medicinetypeid_chr like ?
   and a.instoragetype_int = ?
   and a.state_int <> 0";
                    if(p_intPayState != 2)
                    {
                        strSQL += " and a.paystate_int = ?";
                    }
                    strSQL += "order by a.seriesid_int desc";

                    if (p_intPayState != 2)
                    {
                        objHRPServ.CreateDatabaseParameter(10, out objDPArr);
                    }
                    else
                    {
                        objHRPServ.CreateDatabaseParameter(9, out objDPArr);
                    }
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBeginDate;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEndDate;
                    objDPArr[3].Value = p_strMedicineID+"%";
                    objDPArr[4].Value = p_strMedicineID + "%";
                    objDPArr[5].Value = p_strVendorName + "%";
                    objDPArr[6].Value = p_strInStorageID + "%";
                    if (p_strMedicineType != "0")
                    {
                        objDPArr[7].Value = p_strMedicineType + "%";
                    }
                    else
                    {
                        objDPArr[7].Value = "%";
                    }
                    objDPArr[8].Value = p_intInStorageTypeID;
                    if (p_intPayState != 2)
                    {
                        objDPArr[9].Value = p_intPayState;
                    }
                }             
                
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

        #region 获取药品毛利率

        /// <summary>
        /// 获取药品毛利率

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_dblRate">毛利率</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGrossProfitRate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineTypeID, out double p_dblRate)
        {
            p_dblRate = 15.00d;
            if (p_strMedicineTypeID == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select grossprofitrate from t_ms_grossprofitrateset where medicinetypeid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineTypeID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_dblRate = Convert.ToDouble(dtbValue.Rows[0][0]);
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

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllInMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd,string p_strStorageID,
            out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select case
         when b.packamount > 0 then
          round(b.packamount * b.packcallprice_int, 2)
         else
          round(b.amount * b.callprice_int, 2)
       end buyinmoney,
       round(b.amount * b.wholesaleprice_int, 2) wholesalemoney,
       b.amount * b.retailprice_int retailprice,
       a.seriesid_int,
       a.instoragetype_int,
       a.state_int
  from t_ms_instorage a, t_ms_instorage_detal b
 where a.seriesid_int = b.seriesid2_int
    and a.instoragedate_dat between ? and ?
    and a.storageid_chr = ?
    and b.status = 1
    and a.state_int <> 0";

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
        #endregion

        #region 获取最近一次入库的验收员

        /// <summary>
        /// 获取最近一次入库的验收员

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strExaminerID">返回验收员ID</param>
        /// <param name="p_strExaminerName">返回验收员Name</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestExaminer(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out string p_strExaminerID, out string p_strExaminerName)
        {
            p_strExaminerID = string.Empty;
            p_strExaminerName = string.Empty;
            long lngRes = -1;

            try
            {
                string strSQL =string.Empty;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select examinerid, examinername
  from (select a.examiner examinerid, c.lastname_vchr examinername
          from t_ms_instorage_detal a, t_ms_instorage b, t_bse_employee c
         where c.empid_chr = a.examiner
           and a.seriesid2_int = b.seriesid_int
           and a.examiner is not null
           and b.storageid_chr = ?
           and a.status = 1
           and b.state_int <> 0
         order by a.seriesid_int desc)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 a.examiner examinerid, c.lastname_vchr examinername
  from t_ms_instorage_detal a, t_ms_instorage b, t_bse_employee c
 where c.empid_chr = a.examiner
   and a.seriesid2_int = b.seriesid_int
   and a.examiner is not null
   and b.storageid_chr = ?
   and a.status = 1
   and b.state_int <> 0
 order by a.seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_strExaminerID = dtbValue.Rows[0]["ExaminerID"].ToString();
                    p_strExaminerName = dtbValue.Rows[0]["ExaminerName"].ToString();
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

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息，包括当前库存

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineWithGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       t.opunit_chr,
       t.ipunit_chr,
       t.packqty_dec,
       t.productorid_chr,
       t.pycode_chr,
       t.wbcode_chr,
       t.medicineid_chr,
       t.ispoison_chr,
       t.ischlorpromazine2_chr,
       t.unitprice_mny,
       t.medicinetypeid_chr,
       t.tradeprice_mny,
       t.limitunitprice_mny,
       t.opchargeflg_int,
       t.ipchargeflg_int,
       t.ifstop_int,
       s.currentgross_num,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
  left outer join t_ms_storage s on t.medicineid_chr = s.medicineid_chr
 where t.assistcode_chr like ? and t.deleted_int=0
   and exists (select r.medicineroomid
          from t_ms_medicinestoreroomset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medicineroomid = ?)
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = p_strStorageID;
                objDPArr[0].Value = p_strAssistCode + "%";
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

        #region 获取入库明细表内容(零售金额为数值形)
        /// <summary>
        /// 获取入库明细表内容(零售金额为数值形)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetal_money(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_lngSeries2ID < 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select k.medicinetypename_vchr medicinetypesetname,
			 f.supplycode_vchr,
			 to_char(t.seriesid_int) seriesid_int,
			 t.seriesid2_int,
			 t.medicineid_chr,
			 t.medicinename_vch,
			 t.medspec_vchr,
			 t.packamount,
			 t.packunit_vchr,
			 t.packcallprice_int,
			 t.packconvert_int,
			 case
				 when t.lotno_vchr = 'UNKNOWN' then
					''
				 else
					t.lotno_vchr
			 end lotno_vchr,
			 t.amount,
			 t.callprice_int,
			 t.wholesaleprice_int,
			 t.retailprice_int,
			 t.validperiod_dat,
			 t.acceptance_int,
			 t.approvecode_vchr,
			 t.apparentquality_int,
			 t.packquality_int,
			 t.examrusult_int,
			 t.examiner,
			 t.productorid_chr,
			 t.accountperiod_int,
			 t.acceptancecompany_chr,
			 t.unit_vchr,
			 t.grossprofitrate_int,
			 v.vendorname_vchr acceptancecompanyname,
			 e.lastname_vchr examinername,
			 case
				 when t.acceptance_int = 1 then
					'是'
				 when t.acceptance_int = 0 then
					'否'
				 else
					''
			 end acceptancename,
			 case
				 when t.apparentquality_int = 1 then
					'合格'
				 when t.apparentquality_int = 0 then
					'不合格'
				 else
					''
			 end apparentqualityname,
			 case
				 when t.packquality_int = 1 then
					'合格'
				 when t.packquality_int = 0 then
					'不合格'
				 else
					''
			 end packqualityname,
			 case
				 when t.examrusult_int = 1 then
					'合格'
				 when t.examrusult_int = 0 then
					'不合格'
				 else
					''
			 end examrusultname,
			 (t.callprice_int * t.amount) as inmoney,
			 (t.retailprice_int * t.amount) as salemoney,
			 (t.wholesaleprice_int * t.amount) as wholesalemoney,
			 b.assistcode_chr medicinecode,
			 b.medicinepreptype_chr,
			 l.oldgross_int,
			 a.instoragetype_int typecode_vchr,
             t.gmpflag_int,
			 decode(t.gmpflag_int,0,'不符合',1,'符合') gmpflagname,
			 t.trademark_vchr
	from t_ms_instorage_detal t
	left outer join t_bse_vendor v on v.vendorid_chr =
																		t.acceptancecompany_chr
	left outer join t_bse_employee e on e.empid_chr = t.examiner
	left outer join t_ms_instorage f on f.seriesid_int = t.seriesid2_int
 inner join t_bse_medicine b on t.medicineid_chr = b.medicineid_chr
	left join t_aid_medicinetype k on k.medicinetypeid_chr =
																			b.medicinetypeid_chr
	left join t_ms_account_detail l on f.instorageid_vchr = l.chittyid_vchr
																 and l.medicineid_chr = t.medicineid_chr
																 and l.lotno_vchr = t.lotno_vchr
																 and l.validperiod_dat = t.validperiod_dat
																 and l.callprice_int = t.callprice_int
																 and l.state_int > 0
																 and l.isend_int = 0
	left join t_ms_instorage a on a.seriesid_int = t.seriesid2_int
 where t.seriesid2_int = ?
   and t.status = 1
 order by t.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeries2ID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                //添加当前分批号的库存数

                if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                {
                    double douGross = 0;
                    for (int iRows = 0; iRows < p_dtbValue.Rows.Count; iRows++)
                    {
                        m_lngGetMedicineGross(null, p_dtbValue.Rows[iRows]["medicineid_chr"].ToString(), p_dtbValue.Rows[iRows]["lotno_vchr"].ToString(), out douGross);
                        p_dtbValue.Rows[iRows]["oldgross_int"] = douGross;
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

        #region 获取入库明细表内容(打印专用)
        /// <summary>
        /// 获取入库明细表内容(打印专用)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetal_ForPrint(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            if (p_lngSeries2ID < 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select rownum,
             f.instoragedate_dat,
			 t.medicinename_vch,
			 t.medspec_vchr,
			 t.unit_vchr,
			 t.productorid_chr,
			 case
				 when t.lotno_vchr = 'UNKNOWN' then
					''
				 else
					t.lotno_vchr
			 end lotno_vchr,
			 t.callprice_int,
			 t.amount,
			 v.vendorname_vchr,
			 t.retailprice_int,
			 t.invoicecode_vchr,
			 t.invoicedater_dat,
			 f.instorageid_vchr,
			 '' ramark,
			 l.oldgross_int - t.amount remain,
			 g.typename_vchr,
			 round(t.amount * t.callprice_int, 2) callsum,
			 t.amount * t.retailprice_int retailsum
	from t_ms_instorage_detal t
	left outer join t_bse_vendor v on v.vendorid_chr =
																		t.acceptancecompany_chr
	left outer join t_bse_employee e on e.empid_chr = t.examiner
	left outer join t_ms_instorage f on f.seriesid_int = t.seriesid2_int
 inner join t_bse_medicine b on t.medicineid_chr = b.medicineid_chr
	left join t_ms_account_detail l on f.instorageid_vchr = l.chittyid_vchr
																 and l.medicineid_chr = t.medicineid_chr
																 and l.lotno_vchr = t.lotno_vchr
																 and l.validperiod_dat = t.validperiod_dat
																 and l.callprice_int = t.callprice_int
																 and l.state_int > 0
																 and l.isend_int = 0
	left join t_aid_impexptype g on g.typecode_vchr = f.instoragetype_int
 where t.seriesid2_int = ?
	 and t.status = 1
 order by t.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeries2ID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbValue != null && p_dtbValue.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < p_dtbValue.Rows.Count; i1++)
                    {
                        p_dtbValue.Rows[i1]["rownum"] = i1 + 1;
                    }
                }

                //添加当前分批号的库存数

                //if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                //{
                //    double douGross = 0;
                //    for (int iRows = 0; iRows < p_dtbValue.Rows.Count; iRows++)
                //    {
                //        m_lngGetMedicineGross(null, p_dtbValue.Rows[iRows]["medicineid_chr"].ToString(), p_dtbValue.Rows[iRows]["lotno_vchr"].ToString(), out douGross);
                //        p_dtbValue.Rows[iRows]["oldgross_int"] = douGross;
                //    }
                //}
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出库主表SERIESID
        /// <summary>
        /// 通过入库单号获取出库主表序列，只适用于即出即出，此时一个入库单对应一个出库单
        /// </summary>
        /// <param name="instorageid">入库单号</param>
        /// <param name="SeriesID">出库主表序列</param>
        /// <returns></returns>
        public long m_lngGetOutSeriesid(string[] instorageid, out long[] SeriesID)
        {
            DataTable p_dtbSeries = new DataTable();
            SeriesID = new long[instorageid.Length];
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct seriesid2_int
  from t_ms_outstorage_detail
 where instorageid_vchr = ?
   and status = 1";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int intItemCount = instorageid.Length;
                for (int j = 0; j < intItemCount; j++)
                {
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = instorageid[j];
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbSeries, objDPArr);
                    if (p_dtbSeries != null && p_dtbSeries.Rows.Count > 0)
                    {
                        SeriesID[j] = Convert.ToInt32(p_dtbSeries.Rows[0]["seriesid2_int"].ToString());
                    }
                }
                objHRPServ.Dispose();
                objHRPServ = null;
                return lngRes;

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    
        #region 获取指定药品指定批号的总库存

        /// <summary>
        /// 获取指定药品指定批号的总库存

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">总库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineid, string p_strLotno, out double p_douGross)
        {
            DataTable dtbGross = new DataTable();
            p_douGross = 0;
            long lngRes = 0;
            try
            {
                string strSQL = @" select sum(t.realgross_int) gross
   from t_ms_storage_detail t
  where t.medicineid_chr = ?
    and t.lotno_vchr = ? and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineid;
                objDPArr[1].Value = p_strLotno;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbGross, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbGross.Rows.Count > 0)
                {
                    if (dtbGross.Rows[0]["gross"] != DBNull.Value)
                    {
                        p_douGross = Convert.ToDouble(dtbGross.Rows[0]["gross"]);
                    }
                    else
                    {
                        p_douGross = 0;
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

        #region 获取默认包装值

        /// <summary>
        /// 获取默认包装值

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="m_dtbPack">包装数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPack(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out DataTable m_dtbPack)
        {
            m_dtbPack = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select packqty_dec,ipunit_chr from t_bse_medicine where medicineid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbPack, objDPArr);                   
                objHRPServ.Dispose();
                objHRPServ = null;
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 新增入库时，若药品数量为负数,检查库存明细表的药品ID、批号、购入价、零售价，并给出不同的提示。

        /// <summary>
        /// 新增入库时，若药品数量为负数,检查库存明细表的药品ID。

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strVendorid">供应商ID</param>
        /// <param name="p_blnExist">是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIfExist(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strVendorid,out bool p_blnExist)
        {
            DataTable m_dtbCheck = new DataTable();
            p_blnExist = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.vendorid_chr,count(medicineid_chr) rowscount
  from t_ms_storage_detail a
	left join t_ms_instorage b on b.instorageid_vchr = a.instorageid_vchr
 where a.storageid_chr = ?
   and a.medicineid_chr = ?
	 and b.vendorid_chr = ?
   and a.status = 1 
	 group by b.vendorid_chr";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strVendorid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0 && Convert.ToDouble(m_dtbCheck.Rows[0][0]) > 0)
                {
                    p_blnExist = true;
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 新增入库时，若药品数量为负数,检查库存明细表的药品ID、批号。

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotno">批号</param>
        /// <param name="p_dcmPrice">零售金额</param>
        /// <param name="p_blnExist">是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIfExist(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strLotno,decimal p_dcmPrice, out bool p_blnExist)
        {
            DataTable m_dtbCheck = new DataTable();
            p_blnExist = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select count(medicineid_chr) rowscount
  from t_ms_storage_detail a
 where a.storageid_chr = ?
   and a.medicineid_chr = ?
   and a.lotno_vchr = ?
   and a.retailprice_int = ?
   and a.status = 1";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotno;
                objDPArr[3].Value = p_dcmPrice;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0 && Convert.ToDouble(m_dtbCheck.Rows[0][0]) > 0)
                {
                    p_blnExist = true;
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 新增入库时，若药品数量为负数,检查库存明细表的药品ID、批号、购入价、零售价。

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotno">批号</param>
        /// <param name="p_dblBuyPrice">购入价</param>
        /// <param name="p_dblSellPrice">零售价</param>
        /// <param name="p_strVendorid">供应商ID</param>
        /// <param name="p_blnExist">是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIfExist(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strLotno,
            double p_dblBuyPrice,double p_dblSellPrice,string p_strVendorid,out bool p_blnExist)
        {
            DataTable m_dtbCheck = new DataTable();
            p_blnExist = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.vendorid_chr,count(medicineid_chr) rowscount
  from t_ms_storage_detail a
	left join t_ms_instorage b on b.instorageid_vchr = a.instorageid_vchr
 where a.storageid_chr = ?
   and a.medicineid_chr = ?
    and lotno_vchr = ?
   and callprice_int = ?
	 and retailprice_int = ?
	 and b.vendorid_chr = ?
   and a.status = 1 
	 group by b.vendorid_chr ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotno;
                objDPArr[3].Value = p_dblBuyPrice;
                objDPArr[4].Value = p_dblSellPrice;
                objDPArr[5].Value = p_strVendorid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0 && Convert.ToDouble(m_dtbCheck.Rows[0][0]) > 0)
                {
                    p_blnExist = true;
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 获取入库明细（打印）（药库使用）
        /// <summary>
        /// 获取入库明细（打印）
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strVendor">供应商ID</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">入库类型ID</param>        
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine,string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendor, 
            string p_strMedType,string p_strMedicine, string p_strType, out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select distinct b.instoragedate_dat,
                a.medicinename_vch,
                a.medspec_vchr,
                a.unit_vchr,
                a.productorid_chr,
                decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
                to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
                a.callprice_int,
                a.amount,
                d.vendorname_vchr,
                a.retailprice_int,
                a.invoicecode_vchr,
                to_char(a.invoicedater_dat, 'yyyy-mm-dd') comedate_vchr,
                b.instorageid_vchr,
                b.commnet_vchr ramark,
                nvl(f.oldgross_int, 0) remain,
                e.typename_vchr,
                round(a.amount * a.callprice_int, 2) callsum,
                a.amount * a.retailprice_int retailsum,a.seriesid_int
  from t_ms_instorage_detal a
  left join t_ms_instorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_vendor d on d.vendorid_chr = b.vendorid_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.instoragetype_int
  left join t_ms_account_detail f on f.chittyid_vchr = b.instorageid_vchr
                                 and f.medicineid_chr = a.medicineid_chr
                                 and f.lotno_vchr = a.lotno_vchr
                                 and f.callprice_int = a.callprice_int
                                 and f.retailprice_int = a.retailprice_int
                                 and f.validperiod_dat = a.validperiod_dat
                                 and f.operatedate_dat = b.exam_dat
                                 and f.instorageid_vchr=a.instorageid_vchr
 where b.state_int in (2, 3)
   and a.status = 1
   and f.state_int <> 0
   and b.storageid_chr = ?
   and b.instoragedate_dat between ? and ? ");                

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int intArg = 3;
                if (p_strVendor != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.vendorid_chr = ? ");
                }
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and c.medicinetypeid_chr = ? ");
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and c.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and a.medicineid_chr = ? ");
                }
                if (p_strType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.instoragetype_int = ? ");
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                if (intArg == 4)
                {
                    if (p_strVendor != "")
                    {
                        objDPArr[3].Value = p_strVendor;
                    }
                    if (p_strMedType != "")
                    {
                        objDPArr[3].Value = p_strMedType;
                    }
                    else if (p_strMedicine != "")
                    {
                        objDPArr[3].Value = p_strMedicine;
                    }
                    else if (p_strType != "")
                    {
                        objDPArr[3].Value = p_strType;
                    }
                }
                if (intArg == 5)
                {
                    if (p_strVendor != "")
                    {
                        objDPArr[3].Value = p_strVendor;
                        if (p_strMedType != "")
                        {
                            objDPArr[4].Value = p_strMedType;
                        }
                        else if (p_strMedicine != "")
                        {
                            objDPArr[4].Value = p_strMedicine;
                        }
                        else if (p_strType != "")
                        {
                            objDPArr[4].Value = p_strType;
                        }
                    }
                    else
                    {
                        if (p_strMedType == "")
                        {
                            objDPArr[3].Value = p_strMedicine;
                            objDPArr[4].Value = p_strType;
                        }
                        else if (p_strMedicine == "")
                        {
                            objDPArr[3].Value = p_strMedType;
                            objDPArr[4].Value = p_strType;
                        }
                        else
                        {
                            objDPArr[3].Value = p_strMedType;
                            objDPArr[4].Value = p_strMedicine;
                        }                                         
                    }
                }
                if (intArg == 6)
                {
                    if (p_strVendor != "")
                    {
                        if (p_strMedType == "")
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedicine;
                            objDPArr[5].Value = p_strType;
                        }
                        else if (p_strMedicine == "")
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedType;
                            objDPArr[5].Value = p_strType;
                        }
                        else
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedType;
                            objDPArr[5].Value = p_strMedicine;
                        }
                    }
                    else
                    {
                        objDPArr[3].Value = p_strMedType;
                        objDPArr[4].Value = p_strMedicine;
                        objDPArr[5].Value = p_strType;
                    }
                }
                if (intArg == 7)
                {
                    objDPArr[3].Value = p_strVendor;
                    objDPArr[4].Value = p_strMedType;
                    objDPArr[5].Value = p_strMedicine;
                    objDPArr[6].Value = p_strType;  
                }

                //strSQL.Append(" order by b.instoragedate_dat desc ");
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);
                p_dtbReport.Columns.Remove("seriesid_int");

                //当供应商为空、入库类型为"建帐入库"或"全部"时，查询初始化的内容
                string m_strSQL = @"select typecode_vchr
	from t_aid_impexptype
 where storgeflag_int <> 1
	 and status_int = 1
	 and flag_int = 0
	 and typename_vchr = '建帐入库'";
                DataTable dtbValue = null;
                string m_strTypeCode = string.Empty;
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(m_strSQL, ref dtbValue);
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    m_strTypeCode = dtbValue.Rows[0]["typecode_vchr"].ToString();
                }
                dtbValue = null;
                if (string.IsNullOrEmpty(m_strTypeCode))
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception("请在出入库类型设置中添加药库入库类型“建帐入库”。");
                }
                if (p_strVendor.Length == 0 && (p_strType == "" || p_strType == m_strTypeCode))
                {
                    strSQL = new StringBuilder(@"select z.exam_dat instoragedate_dat,
			 z.medicinename_vch medicinename_vch,
			 z.medspec_vchr medspec_vchr,
			 z.opunit_vchr unit_vchr,
			 z.productorid_chr productorid_chr,
			 decode(z.lotno_vchr, 'UNKNOWN', '', z.lotno_vchr) lotno_vchr,
			 to_char(z.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
			 z.callprice_int callprice_int,
			 z.currentgross_num amount,
			 '' vendorname_vchr,
			 z.retailprice_int retailprice_int,
			 '' invoicecode_vchr,
			 '' comedate_vchr,
			 z.initialid_chr instorageid_vchr,
			 '' ramark,
			 nvl(y.oldgross_int,0) + z.currentgross_num remain,
			 '建帐入库' typename_vchr,
			 round(z.currentgross_num * z.callprice_int,2) callsum,
			 z.currentgross_num * z.retailprice_int retailsum
	from t_ms_initial z
	left join t_ms_account_detail y on y.chittyid_vchr = z.initialid_chr
																 and y.medicineid_chr = z.medicineid_chr
																 and y.lotno_vchr = z.lotno_vchr
																 and y.callprice_int = z.callprice_int
																 and y.retailprice_int = z.retailprice_int
																 and y.validperiod_dat = z.validperiod_dat
																 and y.operatedate_dat = z.exam_dat
																 and y.state_int <> 0
	left join t_bse_medicine x on x.medicineid_chr = z.medicineid_chr where z.storageid_chr = ? and z.exam_dat between ? and ? ");

                    objDPArr = null;
                    intArg = 3;
                    if (p_strMedType != "")
                    {
                        intArg += 1;
                        strSQL.Append(" and x.medicinetypeid_chr = ? ");
                    }
                    if (p_strMedicine != "")
                    {
                        intArg += 1;
                        if (p_blnCombine)
                            strSQL.Append(" and x.assistcode_chr = ? ");
                        else
                            strSQL.Append(" and z.medicineid_chr = ? ");                        
                    }
                    objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    if (intArg == 4)
                    {
                        if (p_strMedType != "")
                        {
                            objDPArr[3].Value = p_strMedType;
                        }
                        else if (p_strMedicine != "")
                        {
                            objDPArr[3].Value = p_strMedicine;
                        }
                    }
                    if (intArg == 5)
                    {                        
                        objDPArr[3].Value = p_strMedType;                   
                        objDPArr[4].Value = p_strMedicine;  
                    }

                    //strSQL.Append(" order by b.instoragedate_dat desc ");
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbValue, objDPArr);                    
                }

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_dtbReport.Merge(dtbValue);
                }

                DataView dvResult = p_dtbReport.DefaultView;
                //dvResult.RowFilter = "amount <> 0";
                dvResult.Sort = "instoragedate_dat desc";
                p_dtbReport = dvResult.ToTable();

                foreach (DataRow dr in p_dtbReport.Rows)
                {
                    if (Convert.ToDateTime(dr["validperiod_chr"]).ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        dr["validperiod_chr"] = string.Empty;
                    }
                }

                objHRPServ.Dispose();
                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 入库时，若药品数量为负数,根据仓库号，药品ID、批号零售价检查数量，看是否满足冲减。

        /// <summary>
        /// 入库时，若药品数量为负数,根据仓库号，药品ID、批号、零售价检查数量，看是否满足冲减。

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库号</param>
        /// <param name="p_strProviderID">供应商</param>
        /// <param name="p_objDetailArr">药品ID、批号、购入价、零售价</param>
        /// <param name="p_strMessage">提示信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckInStorageAmount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, clsMS_InStorageDetail_VO p_objDetail, out string p_strMessage)
        {
            DataTable m_dtbCheck = new DataTable();
            p_strMessage = string.Empty;
            long lngRes = 0;
            double m_dblReal = 0d;
            try
            {
                string strSQL = @"select sum(a.realgross_int) realgross_int
	from t_ms_storage_detail a
 where a.storageid_chr = ?	 
	 and a.medicineid_chr = ?
	 and a.lotno_vchr = ?
	 and a.retailprice_int = ?
	 and a.status = 1";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_objDetail.m_strMEDICINEID_CHR;
                objDPArr[2].Value = p_objDetail.m_strLOTNO_VCHR;
                objDPArr[3].Value = p_objDetail.m_dcmRETAILPRICE_INT;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0)
                {
                    double.TryParse(Convert.ToString(m_dtbCheck.Rows[0]["realgross_int"]), out m_dblReal);
                    if (m_dblReal < Math.Abs(p_objDetail.m_dblAMOUNT))
                    {
                        lngRes = -1;
                        p_strMessage = p_objDetail.m_strMEDICINENAME_VCH + "的库存量不足冲减，请检查！";
                    }
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取入库明细（打印）（药房使用）
        /// <summary>
        /// 获取入库明细（打印）（药房使用）
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strVendor">供应商ID</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">入库类型ID</param>        
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetailReportForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine,string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendor, string p_strMedType,string p_strMedicine, string p_strType,bool p_blnIsHospital, out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder();
                if (p_blnIsHospital)
                {
                    strSQL.Append(@"select b.drugstoreexam_date instoragedate_dat,
       a.medicinename_vchr medicinename_vch,
       a.medspec_vchr,
       decode(c.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as unit_vchr,
       a.productorid_chr,
       decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
       to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
       decode(c.ipchargeflg_int,
              0,
              a.opwholesaleprice_int,
              round(a.opwholesaleprice_int / a.packqty_dec, 4)) as callprice_int,
       decode(c.ipchargeflg_int, 0, a.opamount_int, a.ipamount_int) as amount,
       d.deptname_vchr vendorname_vchr,
       decode(c.opchargeflg_int,
              0,
              a.opretailprice_int,
              round(a.opretailprice_int / a.packqty_dec, 4)) as retailprice_int,
       b.outstorageid_vchr invoicecode_vchr,
       case
         when to_char(b.storageexam_date) = '01-1月 -01' then
          ''
         else
          to_char(b.storageexam_date, 'yyyy-mm-dd HH:mm:ss')
       end comedate_vchr,
       b.indrugstoreid_vchr instorageid_vchr,
       b.comment_vchr ramark,
       --decode(c.ipchargeflg_int,
       --       0,
       --       nvl(f.opoldgross_int, 0) + a.opamount_int,
       --       nvl(f.ipoldgross_int, 0) + a.ipamount_int) remain,
nvl(decode(c.ipchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int),0) remain,
       e.typename_vchr,
       decode(c.ipchargeflg_int,
              0,
              a.opamount_int * a.opwholesaleprice_int,
              round(a.ipamount_int * a.ipwholesaleprice_int / a.packqty_dec,
                    4)) callsum,
       a.opretailprice_int,
       a.packqty_dec,
       a.ipamount_int,
       0 retailsum
  from t_ds_instorage_detail a
  left join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.borrowdept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.typecode_vchr
  --left join t_ds_account_detail f on f.instoreid_vchr =
  --                                   b.indrugstoreid_vchr
  --                               and f.medicineid_chr = a.medicineid_chr
  --                               and f.lotno_vchr = a.lotno_vchr
  --                               and f.opwholesaleprice_int =
  --                                   a.opwholesaleprice_int
  --                               and f.opretailprice_int =
 --                                    a.opretailprice_int
  --                               and f.validperiod_dat = a.validperiod_dat
   --                              and f.operatedate_dat =
   --                                  b.drugstoreexam_date
 where b.status in (2, 3)
   and a.status = 1
   --and f.state_int <> 0
	 and b.drugstoreid_chr = ?
	 and b.drugstoreexam_date between ? and ? ");
                }
                else
                {
                    strSQL.Append(@"select b.drugstoreexam_date instoragedate_dat,
       a.medicinename_vchr medicinename_vch,
       a.medspec_vchr,
       decode(c.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as unit_vchr,
       a.productorid_chr,
       decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
       to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
       decode(c.opchargeflg_int,
              0,
              a.opwholesaleprice_int,
              round(a.opwholesaleprice_int / a.packqty_dec, 4)) as callprice_int,
       decode(c.opchargeflg_int, 0, a.opamount_int, a.ipamount_int) as amount,
       d.deptname_vchr vendorname_vchr,
       decode(c.opchargeflg_int,
              0,
              a.opretailprice_int,
              round(a.opretailprice_int / a.packqty_dec, 4)) as retailprice_int,
       b.outstorageid_vchr invoicecode_vchr,
       case
         when to_char(b.storageexam_date) = '01-1月 -01' then
          ''
         else
          to_char(b.storageexam_date, 'yyyy-mm-dd HH:mm:ss')
       end comedate_vchr,
       b.indrugstoreid_vchr instorageid_vchr,
       b.comment_vchr ramark,
       --decode(c.opchargeflg_int,
        --      0,
        --      nvl(f.opoldgross_int, 0) + a.opamount_int,
         --     nvl(f.ipoldgross_int, 0) + a.ipamount_int) remain,
nvl(decode(c.opchargeflg_int, 0, a.opoldgross_int, a.ipoldgross_int),0) remain,
       e.typename_vchr,
       decode(c.opchargeflg_int,
              0,
              a.opamount_int * a.opwholesaleprice_int,
              round(a.ipamount_int * a.ipwholesaleprice_int / a.packqty_dec,
                    4)) callsum,
       a.opretailprice_int,
       a.packqty_dec,
       a.ipamount_int,
       0 retailsum
  from t_ds_instorage_detail a
  left join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
  left join t_bse_deptdesc d on d.deptid_chr = b.borrowdept_chr
  left join t_aid_impexptype e on e.typecode_vchr = b.typecode_vchr
  --left join t_ds_account_detail f on f.instoreid_vchr =
  --                                   b.indrugstoreid_vchr
    --                             and f.medicineid_chr = a.medicineid_chr
      --                           and f.lotno_vchr = a.lotno_vchr
        --                         and f.opwholesaleprice_int =
          --                           a.opwholesaleprice_int
            --                     and f.opretailprice_int =
              --                       a.opretailprice_int
                --                 and f.validperiod_dat = a.validperiod_dat
                  --               and f.operatedate_dat =
                    --                 b.drugstoreexam_date
 where b.status in (2, 3)
   and a.status = 1
   --and f.state_int <> 0
	 and b.drugstoreid_chr = ?
	 and b.drugstoreexam_date between ? and ? ");//b.storageexam_date invoicedater_dat,
                    //decode(b.storageexam_date,'01-1月 -01','',storageexam_date) invoicedater_dat,
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int intArg = 3;
                if (p_strVendor != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.borrowdept_chr = ? ");
                }
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and c.medicinetypeid_chr = ? ");
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and c.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and a.medicineid_chr = ? ");
                }
                if (p_strType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and b.typecode_vchr = ? ");
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                if (intArg == 4)
                {
                    if (p_strVendor != "")
                    {
                        objDPArr[3].Value = p_strVendor;
                    }
                    else if (p_strMedType != "")
                    {
                        objDPArr[3].Value = p_strMedType;
                    }
                    else if (p_strMedicine != "")
                    {
                        objDPArr[3].Value = p_strMedicine;
                    }
                    else if (p_strType != "")
                    {
                        objDPArr[3].Value = p_strType;
                    }
                }
                if (intArg == 5)
                {
                    if (p_strVendor != "")
                    {
                        objDPArr[3].Value = p_strVendor;
                        if (p_strMedType != "")
                        {
                            objDPArr[4].Value = p_strMedType;
                        }
                        else if (p_strMedicine != "")
                        {
                            objDPArr[4].Value = p_strMedicine;
                        }
                        else if (p_strType != "")
                        {
                            objDPArr[4].Value = p_strType;
                        }
                    }
                    else if (p_strMedType != "")
                    {
                        if (p_strMedicine != "")
                        {
                            objDPArr[3].Value = p_strMedType;
                            objDPArr[4].Value = p_strMedicine;
                        }
                        else
                        {
                            objDPArr[3].Value = p_strMedType;
                            objDPArr[4].Value = p_strType;
                        }
                    }
                    else
                    {
                        objDPArr[3].Value = p_strMedicine;
                        objDPArr[4].Value = p_strType;
                    }
                }
                if (intArg == 6)
                {
                    if (p_strVendor == "")
                    {
                        objDPArr[3].Value = p_strMedType;
                        objDPArr[4].Value = p_strMedicine;
                        objDPArr[5].Value = p_strType;
                    }
                    else
                    {
                        if (p_strMedType == "")
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedicine;
                            objDPArr[5].Value = p_strType;
                        }
                        else if (p_strMedicine == "")
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedType;
                            objDPArr[5].Value = p_strType;
                        }
                        else
                        {
                            objDPArr[3].Value = p_strVendor;
                            objDPArr[4].Value = p_strMedType;
                            objDPArr[5].Value = p_strMedicine;
                        }
                    }
                }
                if (intArg == 7)
                {
                    objDPArr[3].Value = p_strVendor;
                    objDPArr[4].Value = p_strMedType;
                    objDPArr[5].Value = p_strMedicine;
                    objDPArr[6].Value = p_strType;
                }
                //strSQL.Append(" order by b.drugstoreexam_date desc ");

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);

                //当供应商为空、入库类型为"建帐入库"或"全部"时，查询初始化的内容
                string m_strSQL = @"select typecode_vchr
	from t_aid_impexptype
 where storgeflag_int <> 0
	 and status_int = 1
	 and flag_int = 0
	 and typename_vchr = '建帐入库'";
                DataTable dtbValue = null;
                string m_strTypeCode = string.Empty;
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(m_strSQL, ref dtbValue);
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    m_strTypeCode = dtbValue.Rows[0]["typecode_vchr"].ToString();
                }
                dtbValue = null;
                if (string.IsNullOrEmpty(m_strTypeCode))
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception("请在出入库类型设置中添加药房入库类型“建帐入库”。");
                }
                if (p_strVendor.Length == 0 && (p_strType == "" || p_strType == m_strTypeCode))
                {
                    if (p_blnIsHospital)
                    {
                        strSQL = new StringBuilder(@"select a.exam_dat instoragedate_dat,
			 a.medicinename_vchr medicinename_vch,
			 a.medspec_vchr medspec_vchr,
			 decode(c.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as unit_vchr,
			 a.productorid_chr,
			 decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
			 to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
			 decode(c.ipchargeflg_int,
							0,
							a.opwholesaleprice_int,
							round(a.opwholesaleprice_int / a.packqty_dec, 4)) as callprice_int,
			 decode(c.ipchargeflg_int, 0, a.opamount, a.ipamount) as amount,
			 '' vendorname_vchr,
			 decode(c.ipchargeflg_int,
							0,
							a.opretailprice_int,
							round(a.opretailprice_int / a.packqty_dec, 4)) as retailprice_int,
			 '' invoicecode_vchr,
			 '' comedate_vchr,
			 a.initialid_chr instorageid_vchr,
			 '' ramark,
			 decode(c.ipchargeflg_int,
							0,
							nvl(f.opoldgross_int,0),
							nvl(f.ipoldgross_int,0)) remain,
			 '建帐入库' typename_vchr,
			 decode(c.ipchargeflg_int,
							0,
							a.opamount * a.opwholesaleprice_int,
							round(a.ipamount * a.ipwholesaleprice_int / a.packqty_dec, 4)) callsum,
			 a.opretailprice_int,
			 a.packqty_dec,
			 a.ipamount ipamount_int,
			 0 retailsum
	from t_ds_initial a
	left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
	left join t_ds_account_detail f on f.instoreid_vchr = a.drugstoreid_chr
																 and f.medicineid_chr = a.medicineid_chr
																 and f.lotno_vchr = a.lotno_vchr
																 and f.opwholesaleprice_int =
																		 a.opwholesaleprice_int
																 and f.opretailprice_int =
																		 a.opretailprice_int
																 and f.validperiod_dat = a.validperiod_dat
																 and f.operatedate_dat = a.exam_dat
 where
--and f.state_int <> 0
 a.drugstoreid_chr = ?
 and a.exam_dat between ? and ?");
                    }
                    else
                    {
                        strSQL = new StringBuilder(@"select a.exam_dat instoragedate_dat,
			 a.medicinename_vchr medicinename_vch,
			 a.medspec_vchr medspec_vchr,
			 decode(c.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) as unit_vchr,
			 a.productorid_chr,
			 decode(a.lotno_vchr, 'UNKNOWN', '', a.lotno_vchr) lotno_vchr,
			 to_char(a.validperiod_dat, 'yyyy-mm-dd') validperiod_chr,
			 decode(c.opchargeflg_int,
							0,
							a.opwholesaleprice_int,
							round(a.opwholesaleprice_int / a.packqty_dec, 4)) as callprice_int,
			 decode(c.opchargeflg_int, 0, a.opamount, a.ipamount) as amount,
			 '' vendorname_vchr,
			 decode(c.opchargeflg_int,
							0,
							a.opretailprice_int,
							round(a.opretailprice_int / a.packqty_dec, 4)) as retailprice_int,
			 '' invoicecode_vchr,
			 '' comedate_vchr,
			 a.initialid_chr instorageid_vchr,
			 '' ramark,
			 decode(c.opchargeflg_int,
							0,
							nvl(f.opoldgross_int,0),
							nvl(f.ipoldgross_int,0)) remain,
			 '建帐入库' typename_vchr,
			 decode(c.opchargeflg_int,
							0,
							a.opamount * a.opwholesaleprice_int,
							round(a.ipamount * a.ipwholesaleprice_int / a.packqty_dec, 4)) callsum,
			 a.opretailprice_int,
			 a.packqty_dec,
			 a.ipamount ipamount_int,
			 0 retailsum
	from t_ds_initial a
	left join t_bse_medicine c on c.medicineid_chr = a.medicineid_chr
	left join t_ds_account_detail f on f.instoreid_vchr = a.drugstoreid_chr
																 and f.medicineid_chr = a.medicineid_chr
																 and f.lotno_vchr = a.lotno_vchr
																 and f.opwholesaleprice_int =
																		 a.opwholesaleprice_int
																 and f.opretailprice_int =
																		 a.opretailprice_int
																 and f.validperiod_dat = a.validperiod_dat
																 and f.operatedate_dat = a.exam_dat
 where
--and f.state_int <> 0
 a.drugstoreid_chr = ?
 and a.exam_dat between ? and ?");
                    }

                    objDPArr = null;
                    intArg = 3;
                    if (p_strMedType != "")
                    {
                        intArg += 1;
                        strSQL.Append(" and c.medicinetypeid_chr = ? ");
                    }
                    if (p_strMedicine != "")
                    {
                        intArg += 1;
                        if (p_blnCombine)
                            strSQL.Append(" and c.assistcode_chr = ? ");
                        else
                            strSQL.Append(" and a.medicineid_chr = ? ");
                    }
                    objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    if (intArg == 4)
                    {
                        if (p_strMedType != "")
                        {
                            objDPArr[3].Value = p_strMedType;
                        }
                        else if (p_strMedicine != "")
                        {
                            objDPArr[3].Value = p_strMedicine;
                        }
                    }
                    if (intArg == 5)
                    {
                        objDPArr[3].Value = p_strMedType;
                        objDPArr[4].Value = p_strMedicine;
                    }

                    //strSQL.Append(" order by b.instoragedate_dat desc ");
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbValue, objDPArr);
                }

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_dtbReport.Merge(dtbValue);
                }

                DataView dvResult = p_dtbReport.DefaultView;
               //dvResult.RowFilter = "amount <> 0";
                dvResult.Sort = "instoragedate_dat desc";
                p_dtbReport = dvResult.ToTable();
                objHRPServ.Dispose();

                int iRowCount = p_dtbReport.Rows.Count;
                double dblOpRetailprice = 0d;
                double dblPackqty = 0d;
                double dblIpamount = 0d;
                double dblRetailPriceSum = 0d;
                DataRow drTemp = null;
                for (int iR = 0; iR < iRowCount; iR++)
                {
                    drTemp = p_dtbReport.Rows[iR];
                    double.TryParse(Convert.ToString(drTemp["opretailprice_int"]), out dblOpRetailprice);
                    double.TryParse(Convert.ToString(drTemp["packqty_dec"]), out dblPackqty);
                    double.TryParse(Convert.ToString(drTemp["ipamount_int"]), out dblIpamount);
                    dblRetailPriceSum = (dblOpRetailprice / dblPackqty) * dblIpamount;
                    drTemp["retailsum"] = dblRetailPriceSum;

                    if (Convert.ToDateTime(drTemp["validperiod_chr"]).ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        drTemp["validperiod_chr"] = string.Empty;
                    }
                }
                p_dtbReport.Columns.Remove(p_dtbReport.Columns[18]);
                p_dtbReport.Columns.Remove(p_dtbReport.Columns[18]);
                p_dtbReport.Columns.Remove(p_dtbReport.Columns[18]);
                p_dtbReport.AcceptChanges();
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

        #region 获取药品最小单位

        /// <summary>
        /// 获取药品最小单位

        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strIPUnit">最小单位</param>
        [AutoComplete]
        public long m_lngGetIPUnit(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out string p_strIPUnit)
        {
            p_strIPUnit = string.Empty;
            if (p_strMedicineID == string.Empty)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select a.ipunit_chr from t_bse_medicine a where a.medicineid_chr = ? ";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strIPUnit = Convert.ToString(dtbValue.Rows[0][0]);
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

        #region 获取库存量

        /// <summary>
        /// 获取库存量

        /// </summary>
        /// <param name="p_intType">即入即出标志，3是，其他不是</param>
        /// <param name="p_strStorageID">药库Id</param>
        /// <param name="p_strMedicineID">药品</param>
        /// <param name="p_strLotno">批号</param>
        /// <param name="p_dblRetailprice">零售价</param>
        /// <param name="p_dblGross">库存量</param>
        [AutoComplete]
        public long m_lngGetGross(int p_intType,string p_strStorageID, string p_strMedicineID, string p_strLotno,
            double p_dblRetailprice,double p_dblCallprice, out double p_dblGross)
        {
            p_dblGross = 0d;
            DataTable m_dtbCheck = new DataTable();
            long lngRes = -1;
            try
            {
                string strSQL = "";
                //if (p_intType != 3)
                //{
                    strSQL = @"select sum(a.realgross_int) realgross_int
	from t_ms_storage_detail a
 where a.storageid_chr = ?
	 and a.medicineid_chr = ?
	 and a.lotno_vchr = ?
	 and a.retailprice_int = ? and a.callprice_int = ?
	 and a.status = 1";
//                }
//                else
//                {
//                    strSQL = @"select sum(a.realgross_int) realgross_int
//	from t_ms_storage_detail a
// where a.storageid_chr = ?	 
//	 and a.medicineid_chr = ?	 
//	 and a.status = 1";
//                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                //if (p_intType != 3)
                //{
                    objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineID;
                    objDPArr[2].Value = p_strLotno;
                    objDPArr[3].Value = p_dblRetailprice;
                    objDPArr[4].Value = p_dblCallprice;
                //}
                //else
                //{
                //    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                //    objDPArr[0].Value = p_strStorageID;                    
                //    objDPArr[1].Value = p_strMedicineID;
                //}
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0)
                {
                    double.TryParse(Convert.ToString(m_dtbCheck.Rows[0]["realgross_int"]), out p_dblGross);
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 入库负数冲帐：不需要去判断供应商和购入价


        /// <summary>
        /// 入库负数冲帐：不需要去判断供应商和购入价

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strBatchNumber">批号</param>
        /// <param name="p_blnExist">是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckExist(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strBatchNumber, out bool p_blnExist)
        {
            DataTable m_dtbCheck = new DataTable();
            p_blnExist = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select count(medicineid_chr) rowscount
  from t_ms_storage_detail a
 where a.storageid_chr = ?
   and a.medicineid_chr = ?	 
   and a.lotno_vchr = ?
   and a.status = 1 ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strBatchNumber;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0 && Convert.ToDouble(m_dtbCheck.Rows[0][0]) > 0)
                {
                    p_blnExist = true;
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 新增入库时，若药品数量为负数,检查库存明细表的药品ID、批号、零售价。

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotno">批号</param>
        /// <param name="p_dblBuyPrice">购入价</param>
        /// <param name="p_dblSellPrice">零售价</param>
        /// <param name="p_strVendorid">供应商ID</param>
        /// <param name="p_blnExist">是否存在</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckExist(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strLotno,
             double p_dblSellPrice,  out bool p_blnExist)
        {
            DataTable m_dtbCheck = new DataTable();
            p_blnExist = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select count(medicineid_chr) rowscount
  from t_ms_storage_detail a	
 where a.storageid_chr = ?
   and a.medicineid_chr = ?
    and lotno_vchr = ?   
	 and retailprice_int = ?	 
   and a.status = 1 ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotno;
                objDPArr[3].Value = p_dblSellPrice;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck.Rows.Count > 0 && Convert.ToDouble(m_dtbCheck.Rows[0][0]) > 0)
                {
                    p_blnExist = true;
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 获取药品的批准文号

        /// <summary>
        /// 获取药品的批准文号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strApproveCode">批准文号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApproveCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out string p_strApproveCode)
        {
            p_strApproveCode = string.Empty;
            DataTable m_dtbCheck = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.permitno_vchr from t_bse_medicine a where a.medicineid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbCheck, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbCheck != null && m_dtbCheck.Rows.Count > 0)
                {
                    p_strApproveCode = m_dtbCheck.Rows[0][0].ToString();
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 获取中标值

        /// <summary>
        /// 获取中标值

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_intBid">中标值</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBid(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, out int p_intBid)
        {
            p_intBid = -1;
            DataTable m_dtbBid = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.standard_int from t_bse_medicine a where a.medicineid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbBid, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtbBid != null && m_dtbBid.Rows.Count > 0)
                {
                    int.TryParse(Convert.ToString(m_dtbBid.Rows[0]["standard_int"]), out p_intBid);
                }
                
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出入库情况（药库）

        /// <summary>
        /// 获取出入库情况（药库）

        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_intFilter">过滤</param>        
        /// <param name="p_blnShowNoAmount">是否显示零库存</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInOutDetail(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,
            string p_strMedType, string p_strMedicine, int p_intFilter,bool p_blnShowNoAmount, out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select t.medicineid_chr,
       t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       t.opunit_chr unit_chr,
       t.productorid_chr,
       nvl(p.storageamount,0) storageamount,
       nvl(q.inamount,0) inamount,
       nvl(r.outamount,0) outamount,'' outdate
  from t_bse_medicine t
  left join (select a.medicineid_chr, sum(a.realgross_int) storageamount
               from t_ms_storage_detail a
              where a.storageid_chr = ?
                and a.status = 1
              group by a.medicineid_chr) p on t.medicineid_chr =
                                              p.medicineid_chr
  left join (select b.medicineid_chr, sum(b.amount) inamount
               from t_ms_instorage_detal b
               left join t_ms_instorage c on c.seriesid_int =
                                             b.seriesid2_int
              where b.status = 1
                and c.state_int in (2, 3)
                and c.storageid_chr = ?
                and c.exam_dat between ? and ?
              group by b.medicineid_chr) q on t.medicineid_chr =
                                              q.medicineid_chr
  left join (select d.medicineid_chr, sum(d.netamount_int) outamount
               from t_ms_outstorage_detail d
               left join t_ms_outstorage e on e.seriesid_int =
                                              d.seriesid2_int
              where d.status = 1
                and e.status in (2, 3)
                and e.storageid_chr = ?
                and e.examdate_dat between ? and ?
              group by d.medicineid_chr) r on t.medicineid_chr =
                                              r.medicineid_chr
 where t.deleted_int = 0
   and exists (select r.medicineroomid
          from t_ms_medicinestoreroomset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medicineroomid = ?)");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int intArg = 8;
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and t.medicinetypeid_chr = ? ");
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and t.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and t.medicineid_chr = ? ");
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;
                objDPArr[4].Value = p_strStorageID;
                objDPArr[5].DbType = DbType.DateTime;
                objDPArr[5].Value = p_dtmBegin;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_dtmEnd;
                objDPArr[7].Value = p_strStorageID;
                if (intArg == 9)
                {
                    if (p_strMedType != "")
                        objDPArr[8].Value = p_strMedType;
                    else
                        objDPArr[8].Value = p_strMedicine;
                }
                else if (intArg == 10)
                {
                    objDPArr[8].Value = p_strMedType;
                    objDPArr[9].Value = p_strMedicine;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);               

                DataView dvResult = p_dtbReport.DefaultView;
                if (p_blnShowNoAmount == false)
                {
                    dvResult.RowFilter = "storageamount <> 0 ";
                }
                //p_intFilter为0时不用处理

                if (p_intFilter == 1)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0";
                    else
                        dvResult.RowFilter = "inamount <> 0";
                }
                else if (p_intFilter == 2)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0";
                    else
                        dvResult.RowFilter = "inamount = 0";
                }
                else if (p_intFilter == 3)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and outamount <> 0";
                    else
                        dvResult.RowFilter = "outamount <> 0";
                }
                else if (p_intFilter == 4)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0 and outamount <> 0";
                    else
                        dvResult.RowFilter = "inamount <> 0 and outamount <> 0";
                }
                else if (p_intFilter == 5)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0 and outamount <> 0";
                    else
                        dvResult.RowFilter = "inamount = 0 and outamount <> 0";
                }
                else if (p_intFilter == 6)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and outamount = 0";
                    else
                        dvResult.RowFilter = "outamount  = 0";
                }
                else if (p_intFilter == 7)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0 and outamount = 0";
                    else
                        dvResult.RowFilter = "inamount <> 0 and outamount = 0";
                }
                else if (p_intFilter == 8)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0 and outamount = 0";
                    else
                        dvResult.RowFilter = "inamount = 0 and outamount = 0";
                }

                dvResult.Sort = "assistcode_chr";
                p_dtbReport = dvResult.ToTable();

                if (p_dtbReport.Rows.Count > 0)
                {
                    //获取最后出库时间

                    DataTable dtbOutDateTemp = new DataTable();
                    strSQL = new StringBuilder(@"select a.medicineid_chr, b.examdate_dat outdate
  from t_ms_outstorage_detail a
  left join t_ms_outstorage b on b.seriesid_int = a.seriesid2_int
 where a.status = 1
   and b.status in (2, 3)
   and b.storageid_chr = ?
 order by a.medicineid_chr, b.examdate_dat desc");
                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbOutDateTemp, objDPArr);
                    if (dtbOutDateTemp != null && dtbOutDateTemp.Rows.Count > 0)
                    {
                        DataTable dtbOutDate = dtbOutDateTemp.Clone();
                        string strMedicineID = string.Empty;
                        DataRow drRow = null;
                        for (int i1 = 0; i1 < dtbOutDateTemp.Rows.Count; i1++)
                        {
                            drRow = dtbOutDateTemp.Rows[i1];
                            if (strMedicineID == drRow["medicineid_chr"].ToString())
                            {
                                continue;
                            }
                            else
                            {
                                dtbOutDate.Rows.Add(drRow.ItemArray);
                                strMedicineID = drRow["medicineid_chr"].ToString();
                            }
                        }
                        dtbOutDate.PrimaryKey = new DataColumn[] { dtbOutDate.Columns["medicineid_chr"] };

                        DataRow drOutDate = null;
                        DateTime dtOutDate;
                        foreach (DataRow dr in p_dtbReport.Rows)
                        {
                            drOutDate = dtbOutDate.Rows.Find(dr["medicineid_chr"]);
                            if (drOutDate != null)
                            {
                                if(DateTime.TryParse(drOutDate["outdate"].ToString(),out dtOutDate))
                                {
                                    dr["outdate"] = dtOutDate.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                            }
                        }
                        p_dtbReport.AcceptChanges();
                    }

                }
                objHRPServ.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取出入库情况（药房）

        /// <summary>
        /// 获取出入库情况（药房）

        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_intFilter">过滤</param>        
        /// <param name="p_blnShowNoAmount">是否显示零库存</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInOutDetailForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,
            string p_strMedType, string p_strMedicine, int p_intFilter, bool p_blnShowNoAmount,out DataTable p_dtbReport)
        {
            p_dtbReport = null;
            if (p_strStorageID == "") return -1;

            long lngRes = 0;
            try
            {
                StringBuilder strSQL = new StringBuilder(@"select t.medicineid_chr,
       t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       decode(t.opchargeflg_int, 0, t.opunit_chr, 1, t.ipunit_chr) unit_chr,
       t.productorid_chr,
       nvl(decode(t.opchargeflg_int, 0, p.storageopamount, 1, p.storageipamount),0) storageamount,
       nvl(decode(t.opchargeflg_int, 0, q.inopamount, 1, q.inipamount),0) inamount,
       nvl(decode(t.opchargeflg_int,
              0,
              nvl(r.outopamount,0) + nvl(g.recipeopamount,0),
              1,
              nvl(r.outipamount,0) + nvl(g.recipeipamount,0)),0) outamount,'' outdate 
  from t_bse_medicine t
  left join (select a.medicineid_chr,
                    sum(a.oprealgross_int) storageopamount,
                    sum(a.iprealgross_int) storageipamount
               from t_ds_storage_detail a
              where a.drugstoreid_chr = ?
                and a.status = 1
              group by a.medicineid_chr) p on t.medicineid_chr =
                                              p.medicineid_chr
  left join (select b.medicineid_chr,
                    sum(b.opamount_int) inopamount,
                    sum(b.ipamount_int) inipamount
               from t_ds_instorage_detail b
               left join t_ds_instorage c on c.seriesid_int =
                                             b.seriesid2_int
              where b.status = 1
                and c.status in (2, 3)
                and c.drugstoreid_chr = ?
                and c.drugstoreexam_date between ? and ?
              group by b.medicineid_chr) q on t.medicineid_chr =
                                              q.medicineid_chr
  left join (select d.medicineid_chr,
                    sum(d.opamount_int) outopamount,
                    sum(d.ipamount_int) outipamount
               from t_ds_outstorage_detail d
               left join t_ds_outstorage e on e.seriesid_int =
                                              d.seriesid2_int
              where d.status = 1
                and e.status_int in (2, 3)
                and e.drugstoreid_chr = ?
                and e.examdate_dat between ? and ?
              group by d.medicineid_chr) r on t.medicineid_chr =
                                              r.medicineid_chr
left join (select f.medicineid_chr,
                   sum(decode(f.type_int,1,-f.opamount_int,f.opamount_int)) recipeopamount,
                    sum(decode(f.type_int,1,-f.ipamount_int,f.ipamount_int)) recipeipamount
               from t_ds_recipeaccount_detail f
              where f.state_int <> 0
                and f.type_int <> 0
                and f.drugstoreid_int = ?
                and f.operatedate_dat between ? and ?
              group by f.medicineid_chr) g on t.medicineid_chr =
                                              g.medicineid_chr
 where t.deleted_int = 0
   and exists (select medicinetypeid_chr
          from t_ds_medstoreset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medstoreid =  (select s.medstoreid_chr
                                 from t_bse_medstore s
                                where s.deptid_chr = ?))");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                int intArg = 11;
                if (p_strMedType != "")
                {
                    intArg += 1;
                    strSQL.Append(" and t.medicinetypeid_chr = ? ");
                }
                if (p_strMedicine != "")
                {
                    intArg += 1;
                    if (p_blnCombine)
                        strSQL.Append(" and t.assistcode_chr = ? ");
                    else
                        strSQL.Append(" and t.medicineid_chr = ? ");
                }
                objHRPServ.CreateDatabaseParameter(intArg, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;                
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;
                objDPArr[4].Value = p_strStorageID;
                objDPArr[5].DbType = DbType.DateTime;
                objDPArr[5].Value = p_dtmBegin;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_dtmEnd;
                objDPArr[7].Value = p_strStorageID;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = p_dtmBegin;
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[9].Value = p_dtmEnd;
                objDPArr[10].Value = p_strStorageID;
                
                if (intArg == 12)
                {
                    if (p_strMedType != "")
                        objDPArr[11].Value = p_strMedType;
                    else
                        objDPArr[11].Value = p_strMedicine;
                }
                else if (intArg == 13)
                {
                    objDPArr[11].Value = p_strMedType;
                    objDPArr[12].Value = p_strMedicine;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbReport, objDPArr);

                DataView dvResult = p_dtbReport.DefaultView;
                if (p_blnShowNoAmount == false)
                {
                    dvResult.RowFilter = "isnull(storageamount,0) <> 0 ";
                }
                //p_intFilter为0时不用处理

                if (p_intFilter == 1)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0";
                    else
                        dvResult.RowFilter = "inamount <> 0";
                }
                else if (p_intFilter == 2)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0";
                    else
                        dvResult.RowFilter = "inamount = 0";
                }
                else if (p_intFilter == 3)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and outamount <> 0";
                    else
                        dvResult.RowFilter = "outamount <> 0";
                }
                else if (p_intFilter == 4)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0 and outamount <> 0";
                    else
                        dvResult.RowFilter = "inamount <> 0 and outamount <> 0";
                }
                else if (p_intFilter == 5)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0 and outamount <> 0";
                    else
                        dvResult.RowFilter = "inamount = 0 and outamount <> 0";
                }
                else if (p_intFilter == 6)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and outamount = 0";
                    else
                        dvResult.RowFilter = "outamount  = 0";
                }
                else if (p_intFilter == 7)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount <> 0 and outamount = 0";
                    else
                        dvResult.RowFilter = "inamount <> 0 and outamount = 0";
                }
                else if (p_intFilter == 8)
                {
                    if (dvResult.RowFilter.Length > 0)
                        dvResult.RowFilter += "and inamount = 0 and outamount = 0";
                    else
                        dvResult.RowFilter = "inamount = 0 and outamount = 0";
                }
                dvResult.Sort = "assistcode_chr";
                p_dtbReport = dvResult.ToTable();

                objHRPServ.Dispose();

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

