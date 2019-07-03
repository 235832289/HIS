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
    /// 药品外退
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsForeignRetreatOutStorageSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取当前退货次数

        /// <summary>
        /// 获取当前退货次数

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_intReturnTimes">退货次数</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCurrentReturnTimes(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, out int p_intReturnTimes)
        {
            p_intReturnTimes = 0;
            long lngRes = 0;
            try
            {
                string strSQL = @"select returnnum_int
  from t_ms_outstorage_detail
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and status = 1
 order by returnnum_int desc";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strLotNO;
                objDPArr[2].Value = p_strInStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        p_intReturnTimes = 1;
                    }
                    else
                    {
                        p_intReturnTimes = Convert.ToInt32(dtbValue.Rows[0][0]) + 1;
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

        #region 获取出库主表
        /// <summary>
        /// 获取出库主表(退药出库)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendor">供应商ID或名称</param>
        /// <param name="p_strMedicine">药品ID或名称</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,string p_strVendor, string p_strMedicine, out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.outstoragedate_dat,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
         else
          ''
       end outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
 left outer join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr,
                    g.vendorname_vchr,
                   g.vendorid_chr
               from t_ms_outstorage_detail e,
                    t_bse_medicine         f,
                    t_bse_vendor           g
              where e.medicineid_chr = f.medicineid_chr
                and e.status = 1
                and e.vendorid_chr = g.vendorid_chr) g on g.seriesid2_int =
                                                              a.seriesid_int
 where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?
   and a.status <> 0
   and (a.formtype = 2 or a.formtype = 5)
   and (vendorid_chr like ? or vendorname_vchr like ?  or vendorname_vchr is null)
   and (g.medicineid_chr like ? or g.medicinename_vch like ? or g.medicinename_vch is null)
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strVendor + "%";
                //if (p_strVendor == "")
                //{
                //    objDPArr[4].Value = p_strVendor + "'%"+ "' or vendorname_vchr is null";
                //}
                //else
                //{
                //    objDPArr[4].Value = p_strVendor + "%";
                //}
                objDPArr[4].Value = p_strVendor + "%";
                objDPArr[5].Value = p_strMedicine + "%";

                //if (p_strMedicine == "")
                //{
                //    objDPArr[6].Value = p_strMedicine + "'%" + "' or g.medicinename_vch is null";
                //}
                //else
                //{
                //    objDPArr[6].Value = p_strMedicine + "%";
                //}
                objDPArr[6].Value = p_strMedicine + "%";
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutStorage, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取库存基本信息
        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID,string p_strVendorID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            p_objDetailArr = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                string strSQL;
                if (p_strVendorID.Length > 0)
                {
                    strSQL = @"select  a.medicineid_chr, a.medicinename_vchr, a.medspec_vchr, a.syslotno_chr,
                                       case
                                          when a.lotno_vchr = 'UNKNOWN'
                                             then ''
                                          else a.lotno_vchr
                                       end lotno_vchr, a.retailprice_int, a.callprice_int,
                                       a.wholesaleprice_int, a.realgross_int, a.availagross_int,
                                       a.opunit_vchr, a.validperiod_dat, a.productorid_chr,
                                       a.instorageid_vchr, a.instoragedate_dat, a.vendorid_chr,
                                       a.seriesid_int, c.vendorname_vchr, b.assistcode_chr,
                                       d.amount instorageamount, b.medicinetypeid_chr, b.packqty_dec
                                  from t_ms_storage_detail a inner join t_ms_instorage e on a.instorageid_vchr =
                                                                                              e.instorageid_vchr
                                                                                       and e.state_int <> 0
                                       inner join t_ms_instorage_detal d on e.seriesid_int = d.seriesid2_int
                                                                       and d.medicineid_chr = a.medicineid_chr
                                                                       and d.lotno_vchr = a.lotno_vchr
                                                                       and d.callprice_int = a.callprice_int
                                                                       and d.validperiod_dat =
                                                                                             a.validperiod_dat
                                                                       and d.status = 1
                                       inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
                                       left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
                                 where a.medicineid_chr = ?
                                   and a.storageid_chr = ?
                                   and a.status = 1
                                   and a.vendorid_chr = ?
                                union all
                                select a.medicineid_chr, a.medicinename_vchr, a.medspec_vchr, a.syslotno_chr,
                                       a.lotno_vchr, a.retailprice_int, a.callprice_int, a.wholesaleprice_int,
                                       a.realgross_int, a.availagross_int, a.opunit_vchr, a.validperiod_dat,
                                       a.productorid_chr, a.instorageid_vchr, a.instoragedate_dat,
                                       a.vendorid_chr, a.seriesid_int, c.vendorname_vchr, b.assistcode_chr,
                                       e.currentgross_num instorageamount, b.medicinetypeid_chr,
                                       b.packqty_dec
                                  from t_ms_storage_detail a inner join t_ms_initial e on e.medicineid_chr =
                                                                                              a.medicineid_chr
                                                                                     and e.lotno_vchr =
                                                                                                  a.lotno_vchr
                                                                                     and e.initialid_chr =
                                                                                            a.instorageid_vchr
                                                                                     and e.callprice_int =
                                                                                               a.callprice_int
                                                                                     and e.validperiod_dat =
                                                                                             a.validperiod_dat
                                                                                     and e.examerid is not null
                                       inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
                                       left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
                                 where a.medicineid_chr = ?
                                   and a.storageid_chr = ?
                                   and a.status = 1
                                   and a.vendorid_chr = ? ";


                    objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                    objDPArr[0].Value = p_strMedicineID;
                    objDPArr[1].Value = p_strStorageID;
                    objDPArr[2].Value = p_strVendorID;
                    objDPArr[3].Value = p_strMedicineID;
                    objDPArr[4].Value = p_strStorageID;
                    objDPArr[5].Value = p_strVendorID;

                }
                else
                {
                    strSQL = @"select a.medicineid_chr, a.medicinename_vchr, a.medspec_vchr, a.syslotno_chr,
                                       case
                                          when a.lotno_vchr = 'UNKNOWN'
                                             then ''
                                          else a.lotno_vchr
                                       end lotno_vchr, a.retailprice_int, a.callprice_int,
                                       a.wholesaleprice_int, a.realgross_int, a.availagross_int,
                                       a.opunit_vchr, a.validperiod_dat, a.productorid_chr,
                                       a.instorageid_vchr, a.instoragedate_dat, a.vendorid_chr,
                                       a.seriesid_int, c.vendorname_vchr, b.assistcode_chr,
                                       d.amount instorageamount, b.medicinetypeid_chr, b.packqty_dec
                                  from t_ms_storage_detail a inner join t_ms_instorage e on a.instorageid_vchr =
                                                                                              e.instorageid_vchr
                                                                                       and e.state_int <> 0
                                       inner join t_ms_instorage_detal d on e.seriesid_int = d.seriesid2_int
                                                                       and d.medicineid_chr = a.medicineid_chr
                                                                       and d.lotno_vchr = a.lotno_vchr
                                                                       and d.callprice_int = a.callprice_int
                                                                       and d.validperiod_dat =
                                                                                             a.validperiod_dat
                                                                       and d.status = 1
                                       inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
                                       left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
                                 where a.medicineid_chr = ? and a.storageid_chr = ? and a.status = 1
                                union all
                                select a.medicineid_chr, a.medicinename_vchr, a.medspec_vchr, a.syslotno_chr,
                                       a.lotno_vchr, a.retailprice_int, a.callprice_int, a.wholesaleprice_int,
                                       a.realgross_int, a.availagross_int, a.opunit_vchr, a.validperiod_dat,
                                       a.productorid_chr, a.instorageid_vchr, a.instoragedate_dat,
                                       a.vendorid_chr, a.seriesid_int, c.vendorname_vchr, b.assistcode_chr,
                                       e.currentgross_num instorageamount, b.medicinetypeid_chr,
                                       b.packqty_dec
                                  from t_ms_storage_detail a inner join t_ms_initial e on e.medicineid_chr =
                                                                                              a.medicineid_chr
                                                                                     and e.lotno_vchr =
                                                                                                  a.lotno_vchr
                                                                                     and e.initialid_chr =
                                                                                            a.instorageid_vchr
                                                                                     and e.callprice_int =
                                                                                               a.callprice_int
                                                                                     and e.validperiod_dat =
                                                                                             a.validperiod_dat
                                                                                     and e.examerid is not null
                                       inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
                                       left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
                                 where a.medicineid_chr = ? and a.storageid_chr = ? and a.status = 1 ";


                    objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                    objDPArr[0].Value = p_strMedicineID;
                    objDPArr[1].Value = p_strStorageID;
                    objDPArr[2].Value = p_strMedicineID;
                    objDPArr[3].Value = p_strStorageID;

                }


                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);                

                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objDetailArr = new clsMS_StorageDetail[intRowsCount];
                        DataRow drTemp = null;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbValue.Rows[iRow];
                            p_objDetailArr[iRow] = new clsMS_StorageDetail();
                            p_objDetailArr[iRow].m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                            p_objDetailArr[iRow].m_strMEDICINENAME_VCHR = drTemp["MEDICINENAME_VCHR"].ToString();
                            p_objDetailArr[iRow].m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                            p_objDetailArr[iRow].m_strSYSLOTNO_CHR = drTemp["SYSLOTNO_CHR"].ToString();
                            p_objDetailArr[iRow].m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drTemp["RETAILPRICE_INT"]);
                            p_objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drTemp["CALLPRICE_INT"]);
                            p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drTemp["WHOLESALEPRICE_INT"]);
                            if (drTemp["REALGROSS_INT"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblREALGROSS_INT = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drTemp["REALGROSS_INT"]);
                            }
                            if (drTemp["AVAILAGROSS_INT"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblAVAILAGROSS_INT = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drTemp["AVAILAGROSS_INT"]);
                            }
                            p_objDetailArr[iRow].m_strOPUNIT_VCHR = drTemp["OPUNIT_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                            p_objDetailArr[iRow].m_strPRODUCTORID_CHR = drTemp["PRODUCTORID_CHR"].ToString();
                            p_objDetailArr[iRow].m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drTemp["INSTORAGEDATE_DAT"]);
                            p_objDetailArr[iRow].m_strMEDICINECode = drTemp["assistcode_chr"].ToString();
                            p_objDetailArr[iRow].m_strVENDORID_CHR = drTemp["vendorid_chr"].ToString();
                            p_objDetailArr[iRow].m_strVENDORName = drTemp["vendorname_vchr"].ToString();
                            p_objDetailArr[iRow].m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"]);
                            p_objDetailArr[iRow].m_dblInStorageAmount = Convert.ToDouble(drTemp["instorageamount"]);
                            p_objDetailArr[iRow].m_strMEDICINETYPEID_CHR = drTemp["medicinetypeid_chr"].ToString();
                            p_objDetailArr[iRow].m_dblPackQty = Convert.ToDouble(drTemp["packqty_dec"]);
                        }
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

        #region 获取指定供应商药品可用库存总量
        /// <summary>
        /// 获取指定供应商药品可用库存总量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dblGross">可用库存总量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strVendorID, out double p_dblGross)
        {
            p_dblGross = 0d;
            string strSQL ;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (p_strVendorID.Length > 0)
                {
                    strSQL = @"select availagross_int
  from t_ms_storage_detail
 where storageid_chr = ?
   and medicineid_chr = ?
   and vendorid_chr = ?
   and status = 1";
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineID;
                    objDPArr[2].Value = p_strVendorID;
                }
                else
                {
                    strSQL = @"select availagross_int
  from t_ms_storage_detail
 where storageid_chr = ?
   and medicineid_chr = ?
   and status = 1";
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineID;
                }
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        double dblGrossTemp = 0d;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            if (double.TryParse(dtbValue.Rows[iRow][0].ToString(), out dblGrossTemp))
                            {
                                p_dblGross += dblGrossTemp;
                            }
                        }
                    }
                    else
                    {
                        p_dblGross = -1;
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

        #region 调入库单
        /// <summary>
        /// 根据入库单据号调入库单

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbInInfo">入库单信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCallInStorageInfoByInID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strInStorageID, string p_strVendorID, out DataTable p_dtbInInfo)
        {
            p_dtbInInfo = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select a.instorageid_vchr,
       a.vendorid_chr,
       a.instoragedate_dat,
       c.vendorname_vchr,
       b.seriesid_int,
       b.seriesid2_int,
       b.medicineid_chr,
       b.medicinename_vch,
       b.medspec_vchr,
       b.packamount,
       b.packunit_vchr,
       b.packcallprice_int,
       b.packconvert_int,
       b.lotno_vchr,
       b.amount,
       b.callprice_int,
       b.wholesaleprice_int,
       b.retailprice_int,
       b.validperiod_dat,
       b.acceptance_int,
       b.approvecode_vchr,
       b.apparentquality_int,
       b.packquality_int,
       b.examrusult_int,
       b.examiner,
       b.productorid_chr,
       b.accountperiod_int,
       b.acceptancecompany_chr,
       b.unit_vchr,
       b.status,
       b.ruturnnum_int,
       0 inmoney,
       0 salemoney,
       0 wholesalemoney,
       d.assistcode_chr,
       j.realgross_int,
       j.availagross_int
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
 inner join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 inner join t_bse_medicine d on d.medicineid_chr = b.medicineid_chr
 inner join t_ms_storage_detail j on j.storageid_chr = a.storageid_chr
                                 and j.medicineid_chr = b.medicineid_chr
                                 and b.lotno_vchr = j.lotno_vchr
                                 and a.instorageid_vchr =
                                     j.instorageid_vchr
                                 and b.callprice_int = j.callprice_int
                                 and b.validperiod_dat = j.validperiod_dat
                                 and j.status = 1
 where (a.state_int = 2 or a.state_int = 3)
   and b.status = 1
   and b.instorageid_vchr = ?
   and a.storageid_chr = ?
   and a.vendorid_chr = ?
   and j.availagross_int > 0
 order by a.instorageid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strVendorID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbInInfo, objDPArr);

                if (p_dtbInInfo != null)
                {
                    p_dtbInInfo.Columns["inmoney"].Expression = "callprice_int * amount";
                    p_dtbInInfo.Columns["salemoney"].Expression = "retailprice_int * amount";
                    p_dtbInInfo.Columns["wholesalemoney"].Expression = "wholesaleprice_int * amount";
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
        /// 根据药品助记码调入库单

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbInInfo">入库单信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCallInStorageInfoByMedicineID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID,string p_strVendorID, out DataTable p_dtbInInfo)
        {
            p_dtbInInfo = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select a.instorageid_vchr,
       a.vendorid_chr,
       a.instoragedate_dat,
       c.vendorname_vchr,
       b.seriesid_int,
       b.seriesid2_int,
       b.medicineid_chr,
       b.medicinename_vch,
       b.medspec_vchr,
       b.packamount,
       b.packunit_vchr,
       b.packcallprice_int,
       b.packconvert_int,
        b.lotno_vchr,
       b.amount,
       b.callprice_int,
       b.wholesaleprice_int,
       b.retailprice_int,
       b.validperiod_dat,
       b.acceptance_int,
       b.approvecode_vchr,
       b.apparentquality_int,
       b.packquality_int,
       b.examrusult_int,
       b.examiner,
       b.productorid_chr,
       b.accountperiod_int,
       b.acceptancecompany_chr,
       b.unit_vchr,
       b.status,
       b.ruturnnum_int,
       0 inmoney,
       0 salemoney,
       0 wholesalemoney,
       d.assistcode_chr,
       j.realgross_int,
       j.availagross_int
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
 inner join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 inner join t_bse_medicine d on d.medicineid_chr = b.medicineid_chr
 inner join t_ms_storage_detail j on j.storageid_chr = a.storageid_chr
                                 and j.medicineid_chr = b.medicineid_chr
                                 and b.lotno_vchr = j.lotno_vchr
                                 and a.instorageid_vchr =
                                     j.instorageid_vchr
                                 and j.status = 1
 where (a.state_int = 2 or a.state_int = 3)
   and b.status = 1
   and b.medicineid_chr = ?
   and a.storageid_chr = ?
   and a.vendorid_chr = ?
   and j.availagross_int > 0
 order by a.instorageid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strVendorID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbInInfo, objDPArr);

                if (p_dtbInInfo != null)
                {
                    p_dtbInInfo.Columns["inmoney"].Expression = "callprice_int * amount";
                    p_dtbInInfo.Columns["salemoney"].Expression = "retailprice_int * amount";
                    p_dtbInInfo.Columns["wholesalemoney"].Expression = "wholesaleprice_int * amount";
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
    }
}
