using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房出库业务类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOutstorage_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        
        #region 根据药房id和药品id判断库存明细表是否已存在该药
        /// <summary>
        /// 根据药房id和药品id判断库存明细表是否已存在该药
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objStorageDetail">库存明细</param>
        /// <param name="m_objOutStorageDetail">获取出库明细</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckMedExistInStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal,clsDS_StorageDetail_VO m_objStorageDetail,ref clsDS_Outstorage_Detail m_objOutStorageDetail, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            p_lngSeriesID = 0;
            p_blnHasDetail = false;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int,a.medicineid_chr,a.medicinename_vchr,a.medspec_vchr,a.lotno_vchr,a.ipunit_chr,
a.opunit_chr,a.packqty_dec,a.ipretailprice_int,a.opretailprice_int,a.ipwholesaleprice_int,
a.opwholesaleprice_int,a.validperiod_dat,a.instoreid_vchr,a.drugstoreid_chr,a.productorid_chr
from t_ds_storage_detail a where a.seriesid_int=? ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_objStorageDetail.m_lngSERIESID_INT;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDetail = true;
                    p_lngSeriesID = Convert.ToInt64(dtbValue.Rows[0]["seriesid_int"]);
                    m_objOutStorageDetail.m_datVALIDPERIOD_DAT = Convert.ToDateTime(dtbValue.Rows[0]["validperiod_dat"]);
                    m_objOutStorageDetail.m_dblIPAMOUNT_INT = m_objStorageDetail.m_dblIPREALGROSS_INT;
                    m_objOutStorageDetail.m_dblIPRETAILPRICE_INT = Convert.ToDouble(dtbValue.Rows[0]["ipretailprice_int"]);
                    m_objOutStorageDetail.m_dblIPWHOLESALEPRICE_INT =dtbValue.Rows[0]["ipwholesaleprice_int"]==System.DBNull.Value?0: Convert.ToDouble(dtbValue.Rows[0]["ipwholesaleprice_int"]);
                    m_objOutStorageDetail.m_dblOPAMOUNT_INT = m_objStorageDetail.m_dblOPREALGROSS_INT;
                    m_objOutStorageDetail.m_dblOPRETAILPRICE_INT = Convert.ToDouble(dtbValue.Rows[0]["opretailprice_int"]);
                    m_objOutStorageDetail.m_dblOPWHOLESALEPRICE_INT =dtbValue.Rows[0]["opwholesaleprice_int"]==System.DBNull.Value?0: Convert.ToDouble(dtbValue.Rows[0]["opwholesaleprice_int"]);
                    m_objOutStorageDetail.m_dblPACKQTY_DEC = Convert.ToDouble(dtbValue.Rows[0]["packqty_dec"]);
                    m_objOutStorageDetail.m_intSTATUS = 1;
                    m_objOutStorageDetail.m_strIPUNIT_CHR = dtbValue.Rows[0]["ipunit_chr"].ToString();
                    m_objOutStorageDetail.m_strLOTNO_VCHR = dtbValue.Rows[0]["lotno_vchr"].ToString();
                    m_objOutStorageDetail.m_strMEDICINEID_CHR = m_objStorageDetail.m_strMEDICINEID_CHR;
                    m_objOutStorageDetail.m_strMEDICINENAME_VCHR = dtbValue.Rows[0]["medicinename_vchr"].ToString();
                    m_objOutStorageDetail.m_strMEDSPEC_VCHR = dtbValue.Rows[0]["medspec_vchr"].ToString();
                    m_objOutStorageDetail.m_strOPUNIT_CHR = dtbValue.Rows[0]["opunit_chr"].ToString();
                    m_objOutStorageDetail.m_strInStorageid = dtbValue.Rows[0]["instoreid_vchr"].ToString();
                    m_objOutStorageDetail.m_strPRODUCTORID_CHR = dtbValue.Rows[0]["productorid_chr"].ToString(); 
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
      
        #region 根据药库主表流水号获取明细表信息
        /// <summary>
        /// 根据药库主表流水号获取明细表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="m_dtOutStorageDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailInfoByid(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital,long m_lngSeqid, out DataTable m_dtOutStorageDetail)
        {
            m_dtOutStorageDetail = null;
            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;
                if (p_blnIsHospital)
                {
                    strSQL = @"select a.seriesid_int,
                                           a.seriesid2_int,
                                           a.medicineid_chr,
                                           b.assistcode_chr,
                                           a.medicinename_vch,
                                           a.medspec_vchr,
                                           a.opunit_chr,
                                           a.netamount_int as opamount,
                                           a.lotno_vchr,
                                           a.validperiod_dat,
                                           a.callprice_int,
                                           a.retailprice_int * a.netamount_int as retailmoney,
                                           a.retailprice_int,
                                           a.callprice_int * a.netamount_int as inmoney,
                                           a.vendorid_chr,
                                           c.vendorname_vchr,
                                           b.packqty_dec,
                                           b.packqty_dec * a.netamount_int as ipamount,
                                           b.ipunit_chr,
                                           a.instorageid_vchr,
                                           d.instoragedate_dat,b.medicinetypeid_chr,
                                           decode(b.ipchargeflg_int,0,a.opunit_chr,b.ipunit_chr) unit_chr,
			                               decode(b.ipchargeflg_int,0,a.netamount_int,b.packqty_dec * a.netamount_int) amount_int,
                                           b.productorid_chr,a.askamount_int
                                      from t_ms_outstorage_detail a,
                                           t_bse_medicine         b,
                                           t_bse_vendor           c,
                                           t_ms_instorage         d
                                     where a.seriesid2_int = ?
                                       and a.medicineid_chr = b.medicineid_chr(+)
                                       and a.vendorid_chr = c.vendorid_chr(+)
                                       and a.instorageid_vchr = d.instorageid_vchr(+)
                                    ";
                }
                else
                {
                    strSQL = @"select a.seriesid_int,
                                           a.seriesid2_int,
                                           a.medicineid_chr,
                                           b.assistcode_chr,
                                           a.medicinename_vch,
                                           a.medspec_vchr,
                                           a.opunit_chr,
                                           a.netamount_int as opamount,
                                           a.lotno_vchr,
                                           a.validperiod_dat,
                                           a.callprice_int,
                                           a.retailprice_int * a.netamount_int as retailmoney,
                                           a.retailprice_int,
                                           a.callprice_int * a.netamount_int as inmoney,
                                           a.vendorid_chr,
                                           c.vendorname_vchr,
                                           b.packqty_dec,
                                           b.packqty_dec * a.netamount_int as ipamount,
                                           b.ipunit_chr,
                                           a.instorageid_vchr,
                                           d.instoragedate_dat,b.medicinetypeid_chr,
                                           decode(b.opchargeflg_int,0,a.opunit_chr,b.ipunit_chr) unit_chr,
			                               decode(b.opchargeflg_int,0,a.netamount_int,b.packqty_dec * a.netamount_int) amount_int,
                                           b.productorid_chr,a.askamount_int
                                      from t_ms_outstorage_detail a,
                                           t_bse_medicine         b,
                                           t_bse_vendor           c,
                                           t_ms_instorage         d
                                     where a.seriesid2_int = ?  and a.status = 1
                                       and a.medicineid_chr = b.medicineid_chr(+)
                                       and a.vendorid_chr = c.vendorid_chr(+)
                                       and a.instorageid_vchr = d.instorageid_vchr(+)
                                    ";
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = m_lngSeqid;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutStorageDetail, m_objParaArr);
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

        #region 根据药房对应的部门id和发送表流水号获取发药处方的明细信息
        /// <summary>
        /// 根据药房对应的部门id和发送表流水号获取发药处方的明细信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="intSerialid"></param>
        /// <param name="m_strDrugstoreid"></param>
        /// <param name="m_dtRecipeDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSendMedRecipeDetailByid(System.Security.Principal.IPrincipal p_objPrincipal, int intSerialid, string m_strDrugstoreid, out DataTable m_dtRecipeDetail)
        {
            m_dtRecipeDetail = null;
            long num = 0L;
            try
            {
                string strSQLCommand = "select c.outpatrecipeid_chr,c.medseriesid_int,c.drugstoreid_chr,c.medicineid_chr,\r\nc.lotno_vchr,c.chargetype_int,c.opamount_dec,c.ipamount_dec\r\nfrom  t_opr_recipesend a,t_opr_recipesendentry b,t_opr_recipededuct c\r\nwhere a.sid_int=b.sid_int and b.outpatrecipeid_chr=c.outpatrecipeid_chr \r\nand a.sid_int=? and c.drugstoreid_chr=? ";
                clsHRPTableService service = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                service.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = intSerialid;
                objDPArr[1].Value = m_strDrugstoreid;
                num = service.lngGetDataTableWithParameters(strSQLCommand, ref m_dtRecipeDetail, objDPArr);
                service.Dispose();
                service = null;
            }
            catch (Exception exception)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exception.Message);
            }
            return num;
        }
        #endregion

        #region 获取库存基本信息
        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMedicineDetailInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID,out clsMS_StorageDetail[] p_objDetailArr)
        {
            p_objDetailArr = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"select a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.syslotno_chr,
       case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
       a.retailprice_int,
       a.callprice_int,
       a.wholesaleprice_int,
       a.realgross_int,
       a.availagross_int,
       a.opunit_vchr,
       a.validperiod_dat,
       a.productorid_chr,
       a.instorageid_vchr,
       a.instoragedate_dat,
       a.vendorid_chr,
       a.seriesid_int,
       b.assistcode_chr,
       b.medicinetypeid_chr,
       c.vendorname_vchr
  from t_ms_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 where a.medicineid_chr = ?
   and a.storageid_chr = ?
   and a.status = 1 and a.canprovide = 0
 order by a.validperiod_dat,a.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null)
                {
                    //20090330:先处理同一批号药品的合并(负数)
                    DataTable dt = new DataTable();
                    DataView dv1 = dtbValue.DefaultView;
                    dv1.RowFilter = "realgross_int>0";
                    dv1.Sort = "validperiod_dat,instoragedate_dat";
                    dt = dv1.ToTable();
                    DataView dv2 = dtbValue.DefaultView;
                    dv2.RowFilter = "realgross_int<=0";
                    dv2.Sort = "validperiod_dat,instoragedate_dat";
                    dt.Merge(dv2.ToTable(), true);
                    dtbValue = dt;

                    DataTable dtbTemp = dtbValue.Clone();
                    int intRowCount = dtbValue.Rows.Count;
                    string strLotNo = string.Empty;
                    string strValidDate = string.Empty;
                    string strSeriesID = string.Empty;                    
                    DataRow drTp = null;
                    DataRow[] drTmp = null;
                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        drTp = dtbTemp.NewRow();
                        for (int i = 0; i < dtbValue.Columns.Count; i++)
                        {
                            drTp[i] = dtbValue.Rows[i1][i];
                        }

                        if (i1 != intRowCount + 1)
                        {
                            strLotNo = dtbValue.Rows[i1]["lotno_vchr"].ToString();
                            strValidDate = dtbValue.Rows[i1]["validperiod_dat"].ToString();
                            strSeriesID = dtbValue.Rows[i1]["seriesid_int"].ToString();
                            drTmp = dtbValue.Select("lotno_vchr = '" + strLotNo + "' and convert(validperiod_dat,'System.String') = '" + strValidDate + "' and availagross_int < 0");
                            if (drTmp != null)
                            {
                                foreach (DataRow dr in drTmp)
                                {
                                    if (dr["seriesid_int"].ToString() != strSeriesID)
                                    {
                                        drTp["realgross_int"] = Convert.ToDouble(drTp["realgross_int"]) + Convert.ToDouble(dr["realgross_int"]);
                                        drTp["availagross_int"] = Convert.ToDouble(drTp["availagross_int"]) + Convert.ToDouble(dr["availagross_int"]);
                                        dtbValue.Rows.Remove(dr);
                                        intRowCount--;
                                    }
                                }
                            }
                        }

                        dtbTemp.Rows.Add(drTp);
                    }

                    int intRowsCount = dtbTemp.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objDetailArr = new clsMS_StorageDetail[intRowsCount];
                        DataRow drTemp = null;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbTemp.Rows[iRow];
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
                            p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]).Date;
                            p_objDetailArr[iRow].m_strPRODUCTORID_CHR = drTemp["PRODUCTORID_CHR"].ToString();
                            p_objDetailArr[iRow].m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drTemp["INSTORAGEDATE_DAT"]);
                            p_objDetailArr[iRow].m_strMEDICINECode = drTemp["assistcode_chr"].ToString();
                            p_objDetailArr[iRow].m_strVENDORID_CHR = drTemp["vendorid_chr"].ToString();
                            p_objDetailArr[iRow].m_strVENDORName = drTemp["vendorname_vchr"].ToString();
                            p_objDetailArr[iRow].m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"].ToString());
                            p_objDetailArr[iRow].m_strMEDICINETYPEID_CHR = drTemp["MEDICINETYPEID_CHR"].ToString();
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

        #region 获取当天药房出库主表信息
        /// <summary>
        /// 获取当天药房出库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetCurrentDayOutstorageInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strBeginDate, string m_strEndDate, out DataTable m_dtOutstorage)
        {
            m_dtOutstorage = null;
            long lngRes = 0;
            try
            {
                /*decode (a.formtype_int,
               1, '病人发药',
               2, '药房退药库',
               3, '盘亏',
               4, '报废',
               5, '药品出库',
			   6, '药房借调'							 
              ) as */
                string strSQL =
       @"select a.seriesid_int,
       a.outdrugstoreid_vchr,
       b.deptname_vchr as medstorename_vchr,
       a.drugstoreid_chr,
       a.comment_vchr,a.status_int as status,
       decode(a.status_int, 0, '删除', 1, '新制', 2, '审核', 3, '入帐') as status_int,
       formtype_int,
       a.typecode_vchr,
       a.instoredept_chr,
       c.deptname_vchr,
       a.makeorder_dat,
       a.examid_chr,
       d.lastname_vchr as examname,
       a.examid_chr,
       a.inaccounterid_chr,
       f.lastname_vchr as inaccountername,
       a.makerid_chr,
       h.lastname_vchr as makername,
       i.typename_vchr,
       a.inaccount_dat,a.examdate_dat,
       0 summoney
  from t_ds_outstorage  a,
       t_bse_deptdesc   b,
       t_bse_deptdesc   c,
       t_bse_employee   d,
       t_bse_employee   f,
       t_bse_employee   h,
       t_aid_impexptype i
 where a.drugstoreid_chr = b.deptid_chr(+)
   and a.instoredept_chr = c.deptid_chr(+)
   and a.examid_chr = d.empid_chr(+)
   and a.inaccounterid_chr = f.empid_chr(+)
   and a.makerid_chr = h.empid_chr(+)
   and a.typecode_vchr = i.typecode_vchr(+)
   and a.makeorder_dat between ? and ?
 order by a.outdrugstoreid_vchr desc";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate + " 00:00:00");
                m_objParaArr[0].DbType = DbType.DateTime;
                m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate + " 23:59:59");
                m_objParaArr[1].DbType = DbType.DateTime;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                DataView dv = m_dtOutstorage.DefaultView;
                dv.RowFilter = "status<> 0";
                m_dtOutstorage = dv.ToTable();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion 

        #region 根据流水号获取药房出库明细
        /// <summary>
        /// 根据流水号获取药房出库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailByID(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital,long m_lngSeqid, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select a.seriesid_int,
			 a.seriesid2_int,
			 a.medicineid_chr,
			 b.assistcode_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.lotno_vchr,
			 a.validperiod_dat,
			 a.opamount_int,
			 a.opunit_chr,
			 a.ipamount_int,
			 a.ipunit_chr,
			 a.opwholesaleprice_int,
			 a.ipwholesaleprice_int,
			 a.opretailprice_int,
			 a.ipretailprice_int,
			 c.instoreid_vchr,
			 c.instoragedate_dat,
			 0 as oprealgross_int,
			 0 as opavailagross_int,
			 0 as iprealgross_int,
			 0 as ipavailablegross_num,
             0 as retailmoney,
			 a.rejectreason,
			 a.status,
			 a.packqty_dec,
			 a.storageseriesid_chr,
			 b.medicinetypeid_chr,
			 a.productorid_chr,
			 b.opchargeflg_int,
             b.ipchargeflg_int,
			 decode(b.ipchargeflg_int, 0, a.opamount_int, a.ipamount_int) amount_int,
			 decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
			 decode(b.ipchargeflg_int,
							0,
							a.opwholesaleprice_int,
							a.ipwholesaleprice_int) wholesaleprice_int,
			 decode(b.ipchargeflg_int,
							0,
							a.opretailprice_int,
							a.ipretailprice_int) retailprice_int
	from t_ds_outstorage_detail a, t_bse_medicine b, t_ds_storage_detail c
 where a.medicineid_chr = b.medicineid_chr(+)
	 and a.storageseriesid_chr = c.seriesid_int(+)
	 and a.status = 1
	 and c.status = 1
     and a.seriesid2_int = ?";
                }
                else
                {
                    strSQL = @"select a.seriesid_int,
			 a.seriesid2_int,
			 a.medicineid_chr,
			 b.assistcode_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.lotno_vchr,
			 a.validperiod_dat,
			 a.opamount_int,
			 a.opunit_chr,
			 a.ipamount_int,
			 a.ipunit_chr,
			 a.opwholesaleprice_int,
			 a.ipwholesaleprice_int,
			 a.opretailprice_int,
			 a.ipretailprice_int,
			 c.instoreid_vchr,
			 c.instoragedate_dat,
			 0 as oprealgross_int,
			 0 as opavailagross_int,
			 0 as iprealgross_int,
			 0 as ipavailablegross_num,
             0 as retailmoney,
			 a.rejectreason,
			 a.status,
			 a.packqty_dec,
			 a.storageseriesid_chr,
			 b.medicinetypeid_chr,
			 a.productorid_chr,
			 b.opchargeflg_int,
             b.ipchargeflg_int,
			 decode(b.opchargeflg_int, 0, a.opamount_int, a.ipamount_int) amount_int,
			 decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
			 decode(b.opchargeflg_int,
							0,
							a.opwholesaleprice_int,
							a.ipwholesaleprice_int) wholesaleprice_int,
			 decode(b.opchargeflg_int,
							0,
							a.opretailprice_int,
							a.ipretailprice_int) retailprice_int
	from t_ds_outstorage_detail a, t_bse_medicine b, t_ds_storage_detail c
 where a.medicineid_chr = b.medicineid_chr(+)
	 and a.storageseriesid_chr = c.seriesid_int(+)
	 and a.status = 1
	 and c.status = 1
     and a.seriesid2_int = ?";
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDataParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                dt.Columns["retailmoney"].Expression = "opretailprice_int*ipamount_int/packqty_dec";
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据查询条件获取药房出库主表信息
        /// <summary>
        /// 根据查询条件获取药房出库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strMakeOrderName"></param>
        /// <param name="m_strTypeCode"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="m_strInstorageDeptID"></param>
        /// <param name="m_strBillID"></param>
        /// <param name="p_strMedicineName"></param>
        /// <param name="m_dtInstorage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetOutstorageInfoByconditions(System.Security.Principal.IPrincipal p_objPrincipal,bool p_blnCombine, string m_strBeginDate, string m_strEndDate, string m_strMakeOrderName, string m_strTypeCode, int m_intStatus, string m_strMedStoreID, string m_strInstorageDeptID, string m_strBillID, string p_strMedicineID,
            out DataTable m_dtInstorage)
        {
            m_dtInstorage = null;
            long lngRes = 0;
            try
            {
                string strSQL =
       @"select distinct a.seriesid_int,
                a.outdrugstoreid_vchr,
                b.deptname_vchr as medstorename_vchr,
                a.drugstoreid_chr,
                a.comment_vchr,
                a.status_int as status,
                decode(a.status_int,
                       0,
                       '删除',
                       1,
                       '新制',
                       2,
                       '审核',
                       3,
                       '入帐') as status_int,
                formtype_int,
                a.typecode_vchr,
                a.instoredept_chr,
                c.deptname_vchr,
                a.makeorder_dat,
                a.examid_chr,
                d.lastname_vchr as examname,
                a.examid_chr,
                a.inaccounterid_chr,
                f.lastname_vchr as inaccountername,
                a.makerid_chr,
                h.lastname_vchr as makername,
                i.typename_vchr,
                a.inaccount_dat,
                a.examdate_dat,
                0 summoney
  from t_ds_outstorage        a,
       t_bse_deptdesc         b,
       t_bse_deptdesc         c,
       t_bse_employee         d,
       t_bse_employee         f,
       t_bse_employee         h,
       t_aid_impexptype       i,
       t_ds_outstorage_detail j,
       t_bse_medicine         k
 where a.drugstoreid_chr = b.deptid_chr(+)
   and a.instoredept_chr = c.deptid_chr(+)
   and a.examid_chr = d.empid_chr(+)
   and a.inaccounterid_chr = f.empid_chr(+)
   and a.makerid_chr = h.empid_chr(+)
   and a.typecode_vchr = i.typecode_vchr(+)
   and (a.seriesid_int = j.seriesid2_int(+) and j.status = 1)
   and j.medicineid_chr = k.medicineid_chr(+)
   and a.makeorder_dat between ? and ?
	";
                if (m_strMakeOrderName != string.Empty)
                {
                    strSQL += " and h.lastname_vchr like '" + m_strMakeOrderName + "%' ";
                }
                if (m_strTypeCode != string.Empty)
                {
                    strSQL += " and a.typecode_vchr=" + m_strTypeCode + " ";
                }                
                if (m_intStatus != -1)
                {
                    strSQL += " and a.status_int=" + m_intStatus + " ";
                }
                if (m_strMedStoreID != string.Empty)
                {
                    strSQL += " and a.drugstoreid_chr ='" + m_strMedStoreID + "' ";
                }
                if (m_strInstorageDeptID != string.Empty)
                {
                    strSQL += " and a.instoredept_chr ='" + m_strInstorageDeptID + "' ";
                }
                if (m_strBillID != string.Empty)
                {
                    strSQL += " and a.outdrugstoreid_vchr ='" + m_strBillID + "' ";
                }
                if (p_strMedicineID.Length > 0)
                {
                    if (p_blnCombine)
                    {
                        strSQL += " and k.assistcode_chr = '" + p_strMedicineID + "'";
                    }
                    else
                    {
                        strSQL += " and j.medicineid_chr = '" + p_strMedicineID + "'";
                    }
                }
                strSQL += " order by a.outdrugstoreid_vchr desc";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                m_objParaArr[0].Value = Convert.ToDateTime(m_strBeginDate);
                m_objParaArr[0].DbType = DbType.DateTime;
                m_objParaArr[1].Value = Convert.ToDateTime(m_strEndDate);
                m_objParaArr[1].DbType = DbType.DateTime;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtInstorage, m_objParaArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                DataView dv = m_dtInstorage.DefaultView;
                dv.RowFilter = "status<> 0 and formtype_int in (1,2,3)";
                m_dtInstorage = dv.ToTable();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion     
      
        #region 获取保存前出库明细的数量
        /// <summary>
        /// 获取保存前出库明细的数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_intMode">删除模式，0为删全部明细，1为删单条明细</param>
        /// <param name="p_objUpdateArr">获取保存前出库明细的数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDetailForUpdate(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ,int p_intMode,out clsDS_UpdateStorageBySeriesID_VO[] p_objUpdateArr)
        {
            p_objUpdateArr = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select   a.opamount_int, a.opunit_chr, a.ipunit_chr, a.packqty_dec,
                                           a.opwholesaleprice_int, a.ipwholesaleprice_int, a.opretailprice_int,
                                           a.ipretailprice_int, a.lotno_vchr, a.validperiod_dat, a.status,
                                           a.rejectreason, a.storageseriesid_chr, a.productorid_chr,
                                           a.seriesid_int, a.ipamount_int, a.storageseriesid_chr,
                                           a.medicineid_chr, a.medicinename_vchr, a.medspec_vchr, a.seriesid_int
                                      from t_ds_outstorage_detail a
                                     where a.status = 1 and ";
                if(p_intMode == 0)
                {
                    strSQL += " a.seriesid2_int = ? ";
                }
                else if(p_intMode == 1)
                {
                    strSQL += " a.seriesid_int = ? ";
                }  

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    p_objUpdateArr = new clsDS_UpdateStorageBySeriesID_VO[intRowsCount];
                    DataRow drTemp = null;
                    for(int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_objUpdateArr[iRow] = new clsDS_UpdateStorageBySeriesID_VO();
                        drTemp = dtbValue.Rows[iRow];
                        //20090625:改为负数，不然扣库存有误。
                        p_objUpdateArr[iRow].m_dblOPAvalid = -Convert.ToDouble(drTemp["opamount_int"]);
                        p_objUpdateArr[iRow].m_dblIPAvalid = -Convert.ToDouble(drTemp["ipamount_int"]);
                        p_objUpdateArr[iRow].m_intSeriesID = Convert.ToInt64(drTemp["storageseriesid_chr"]);
                        p_objUpdateArr[iRow].m_strIPUNIT_CHR = drTemp["ipunit_chr"].ToString();
                        p_objUpdateArr[iRow].m_strOPUNIT_CHR = drTemp["opunit_chr"].ToString();
                        p_objUpdateArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(drTemp["packqty_dec"]);
                        p_objUpdateArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(drTemp["opwholesaleprice_int"]);
                        p_objUpdateArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(drTemp["ipwholesaleprice_int"]);
                        p_objUpdateArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(drTemp["opretailprice_int"]);
                        p_objUpdateArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(drTemp["ipretailprice_int"]);
                        p_objUpdateArr[iRow].m_strLOTNO_VCHR = drTemp["lotno_vchr"].ToString();
                        p_objUpdateArr[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["validperiod_dat"]);
                        p_objUpdateArr[iRow].STATUS = Convert.ToInt16(drTemp["status"]);
                        p_objUpdateArr[iRow].m_strPRODUCTORID_CHR = drTemp["productorid_chr"].ToString();
                        p_objUpdateArr[iRow].m_strMEDICINEID_CHR = drTemp["medicineid_chr"].ToString();
                        p_objUpdateArr[iRow].m_strMEDICINENAME_VCHR = drTemp["medicinename_vchr"].ToString();
                        p_objUpdateArr[iRow].m_strMEDSPEC_VCHR = drTemp["medspec_vchr"].ToString();
                        p_objUpdateArr[iRow].m_lngOutSeriesID = long.Parse(drTemp["seriesid_int"].ToString());
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

        #region 获取库存基本信息
        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedSpec">药品规格</param>
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out clsDS_StorageDetail_VO[] p_objDetailArr)
        {
            p_objDetailArr = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"select a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       case
         when a.lotno_vchr = 'UNKNOWN' then
          ''
         else
          a.lotno_vchr
       end lotno_vchr,
       a.opretailprice_int,
       a.opwholesaleprice_int,
       a.oprealgross_int,
       a.opavailablegross_num,
       a.opunit_chr,
       a.ipretailprice_int,
       a.ipwholesaleprice_int,
       a.iprealgross_int,
       a.ipavailablegross_num,
       a.ipunit_chr,
       a.validperiod_dat,
       a.instoreid_vchr,
       a.instoragedate_dat,
       a.seriesid_int,
       b.assistcode_chr,
       b.medicinetypeid_chr,
       b.packqty_dec,
       a.productorid_chr,
       a.dsinstoreid_vchr,
       b.opchargeflg_int,b.ipchargeflg_int
  from t_ds_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 where a.medicineid_chr = ?
   and a.drugstoreid_chr = ?
   and a.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null)
                {
                    DataTable dt = new DataTable();
                    DataView dv1 = dtbValue.DefaultView;
                    dv1.RowFilter = "iprealgross_int>0";
                    dv1.Sort = "validperiod_dat,instoragedate_dat";
                    dt = dv1.ToTable();
                    DataView dv2 = dtbValue.DefaultView;
                    dv2.RowFilter = "iprealgross_int<=0";
                    dv2.Sort = "validperiod_dat,instoragedate_dat";
                    dt.Merge(dv2.ToTable(), true);
                    dtbValue = dt;
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objDetailArr = new clsDS_StorageDetail_VO[intRowsCount];
                        DataRow drTemp = null;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbValue.Rows[iRow];
                            p_objDetailArr[iRow] = new clsDS_StorageDetail_VO();
                            p_objDetailArr[iRow].m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                            p_objDetailArr[iRow].m_strMEDICINENAME_VCHR = drTemp["MEDICINENAME_VCHR"].ToString();
                            p_objDetailArr[iRow].m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                            p_objDetailArr[iRow].m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(drTemp["OPRETAILPRICE_INT"]);        
                            if (drTemp["OPWHOLESALEPRICE_INT"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(drTemp["OPWHOLESALEPRICE_INT"]);
                            }

                            if (drTemp["OPREALGROSS_INT"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblOPREALGROSS_INT = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblOPREALGROSS_INT = Convert.ToDouble(drTemp["OPREALGROSS_INT"]);
                            }
                            if (drTemp["opavailablegross_num"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblOPAVAILABLEGROSS_NUM = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblOPAVAILABLEGROSS_NUM = Convert.ToDouble(drTemp["opavailablegross_num"]);
                            }
                            if (drTemp["ipwholesaleprice_int"] == DBNull.Value)
                            {
                                p_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = 0.00d;
                            }
                            else
                            {
                                p_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(drTemp["ipwholesaleprice_int"]);
                            }
                            p_objDetailArr[iRow].m_strOPUNIT_CHR = drTemp["opunit_chr"].ToString();
                            p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                            p_objDetailArr[iRow].m_strINSTOREID_VCHR = drTemp["INSTOREID_VCHR"].ToString();
                            p_objDetailArr[iRow].m_strDSINSTOREID_VCHR = drTemp["DSINSTOREID_VCHR"].ToString();
                            p_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drTemp["INSTORAGEDATE_DAT"]);
                            p_objDetailArr[iRow].m_strASSISTCODE_CHR = drTemp["assistcode_chr"].ToString();
                            p_objDetailArr[iRow].m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"].ToString());
                            p_objDetailArr[iRow].m_strMEDICINETYPEID_CHR = drTemp["MEDICINETYPEID_CHR"].ToString();
                            p_objDetailArr[iRow].m_strIPUNIT_CHR = drTemp["ipunit_chr"].ToString();
                            p_objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(drTemp["ipretailprice_int"]);
                            p_objDetailArr[iRow].m_dblIPREALGROSS_INT = Convert.ToDouble(drTemp["iprealgross_int"]);
                            p_objDetailArr[iRow].m_dblIPAVAILABLEGROSS_NUM = Convert.ToDouble(drTemp["ipavailablegross_num"]);
                            p_objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(drTemp["packqty_dec"]);
                            p_objDetailArr[iRow].m_strPRODUCTORID_CHR = drTemp["productorid_chr"].ToString();
                            p_objDetailArr[iRow].m_dblOPCHARGEFLG_INT = Convert.ToDouble(drTemp["opchargeflg_int"]);
                            p_objDetailArr[iRow].m_dblIPCHARGEFLG_INT = Convert.ToDouble(drTemp["ipchargeflg_int"]);
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

        #region 获取指定药品出库数量
        /// <summary>
        /// 获取指定药品出库数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_hstNetAmount">针对指定药物，以批号+入库单号为键，出库数量为值的哈希表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIPAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            p_hstNetAmount = new Hashtable();
            long lngRes = 0;

            try
            {
                string strSQL = @"select   a.ipamount_int,
                                           case
                                             when a.lotno_vchr = 'unknown' then
                                              ''
                                             else
                                              a.lotno_vchr
                                           end lotno_vchr, a.storageseriesid_chr, a.validperiod_dat,
                                           a.seriesid_int
                                      from t_ds_outstorage_detail a, t_ds_outstorage b
                                     where a.seriesid2_int = b.seriesid_int
                                       and b.seriesid_int = ?
                                       and a.medicineid_chr = ?
                                       and a.status = 1
                                     order by a.lotno_vchr, a.storageseriesid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;
                objDPArr[1].Value = p_strMedicineID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    DataRow drTemp = null;

                    for(int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbValue.Rows[iRow];
                        //p_hstNetAmount.Add(drTemp["lotno_vchr"].ToString().PadLeft(10, '0') + drTemp["storageseriesid_chr"].ToString() + Convert.ToDateTime(drTemp["validperiod_dat"]).ToString("yyyy-MM-dd HH:mm:ss"), drTemp["ipamount_int"].ToString());
                        p_hstNetAmount.Add(drTemp["storageseriesid_chr"].ToString() + "*" + drTemp["seriesid_int"].ToString(), drTemp["ipamount_int"].ToString());
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
      
        #region 根据流水号获取药房出库明细
        /// <summary>
        /// 根据流水号获取药房出库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutstorageDetailByID(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSeqid, out clsDS_UpdateStorageBySeriesID_VO[] m_objDetailVoArr)
        {
            long lngRes = 0;
            m_objDetailVoArr = null;
            DataTable dt = new DataTable();
            try
            {
                string strSQL = @"select b.drugstoreid_chr,
       a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       c.assistcode_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.lotno_vchr,
       a.validperiod_dat,
       a.opamount_int,
       a.opunit_chr,
       a.ipamount_int,
       a.ipunit_chr,
       a.opwholesaleprice_int,
       a.ipwholesaleprice_int,
       a.opretailprice_int,
       a.ipretailprice_int,
       a.rejectreason,
       a.status,
       a.packqty_dec,
       a.storageseriesid_chr,
       c.medicinetypeid_chr,
       d.instoreid_vchr,
       d.instoragedate_dat,
       d.iprealgross_int as oldiprealgross_int,
       d.oprealgross_int as oldoprealgross_int,b.outdrugstoreid_vchr,b.formtype_int,a.productorid_chr
  from t_ds_outstorage_detail a
  left join t_ds_outstorage b on b.seriesid_int = a.seriesid2_int
  left join t_bse_medicine c on a.medicineid_chr = c.medicineid_chr
  left join t_ds_storage_detail d on a.storageseriesid_chr = d.seriesid_int
 where a.seriesid2_int = ?
   and a.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDataParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                m_objDetailVoArr = new clsDS_UpdateStorageBySeriesID_VO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_objDetailVoArr[i] = new clsDS_UpdateStorageBySeriesID_VO();
                    m_objDetailVoArr[i].m_dblOPAvalid = Convert.ToDouble(dt.Rows[i]["opamount_int"]);
                    m_objDetailVoArr[i].m_dblIPAvalid = Convert.ToDouble(dt.Rows[i]["ipamount_int"]);
                    m_objDetailVoArr[i].m_dblOPReal = Convert.ToDouble(dt.Rows[i]["opamount_int"]);
                    m_objDetailVoArr[i].m_dblIPReal = Convert.ToDouble(dt.Rows[i]["ipamount_int"]);
                    m_objDetailVoArr[i].m_intSeriesID = Convert.ToInt64(dt.Rows[i]["storageseriesid_chr"]);
                    m_objDetailVoArr[i].m_strMedicineCode = dt.Rows[i]["medicineid_chr"].ToString();
                    m_objDetailVoArr[i].m_strDrugID = dt.Rows[i]["drugstoreid_chr"].ToString();
                    m_objDetailVoArr[i].m_strMEDICINENAME_VCHR = dt.Rows[i]["medicinename_vchr"].ToString();
                    m_objDetailVoArr[i].m_strMEDICINETYPEID_CHR = dt.Rows[i]["medicinetypeid_chr"].ToString();
                    m_objDetailVoArr[i].m_strMEDSPEC_VCHR = dt.Rows[i]["medspec_vchr"].ToString();
                    m_objDetailVoArr[i].m_strLOTNO_VCHR = dt.Rows[i]["lotno_vchr"].ToString();
                    m_objDetailVoArr[i].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(dt.Rows[i]["validperiod_dat"].ToString());
                    m_objDetailVoArr[i].m_strINSTOREID_VCHR = dt.Rows[i]["instoreid_vchr"].ToString();
                    m_objDetailVoArr[i].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipwholesaleprice_int"].ToString());
                    m_objDetailVoArr[i].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["opwholesaleprice_int"].ToString());
                    m_objDetailVoArr[i].m_dblIPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipretailprice_int"].ToString());
                    m_objDetailVoArr[i].m_dblOPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["opretailprice_int"].ToString());
                    m_objDetailVoArr[i].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["instoragedate_dat"].ToString());
                    m_objDetailVoArr[i].m_strIPUNIT_CHR = dt.Rows[i]["ipunit_chr"].ToString();
                    m_objDetailVoArr[i].m_strOPUNIT_CHR = dt.Rows[i]["opunit_chr"].ToString();
                    m_objDetailVoArr[i].m_strDSINSTOREID_VCHR = dt.Rows[i]["outdrugstoreid_vchr"].ToString();
                    m_objDetailVoArr[i].m_intType = Convert.ToInt16(dt.Rows[i]["formtype_int"].ToString());
                    m_objDetailVoArr[i].m_dblOldIPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["oldiprealgross_int"].ToString());
                    m_objDetailVoArr[i].m_dblOldOPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["oldoprealgross_int"].ToString());
                    m_objDetailVoArr[i].m_strPRODUCTORID_CHR = dt.Rows[i]["productorid_chr"].ToString();
                    m_objDetailVoArr[i].m_dblPACKQTY_DEC = Convert.ToDouble(dt.Rows[i]["packqty_dec"]);
                    m_objDetailVoArr[i].m_lngRELATEDSERIESID_INT = Convert.ToInt32(dt.Rows[i]["seriesid_int"]);
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

        #region 根据药房id和药品id判断库存主表是否已存在该药
        /// <summary>
        /// 根据药房id和药品id判断库存主表是否已存在该药
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckMedExistOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            p_lngSeriesID = 0;
            p_blnHasDetail = false;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strMedicineID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }
            try
            {
                string strSQL = @"select seriesid_int
                                  from t_ds_storage
                                  where medicineid_chr = ? and drugstoreid_chr= ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDetail = true;
                    p_lngSeriesID = Convert.ToInt64(dtbValue.Rows[0][0]);
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

        #region 根据条件获取某药品当前库存数量
        /// <summary>
        /// 根据条件获取某药品当前库存数量
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_strInstorageid"></param>
        /// <param name="m_dtmInstorage"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_dblIPAmount"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCurrentGrossByConditions(string m_strDurgStoreid, string m_strLotNo, string m_strMedicineid, DateTime m_dtmInstorage, ref double m_dblOPAmount, ref double m_dblIPAmount)
        {
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"select a.seriesid_int, a.iprealgross_int, round(a.iprealgross_int / a.packqty_dec, 2) oprealgross_int
  from t_ds_storage_detail a
  where a.medicineid_chr = ?
   and a.lotno_vchr = ?
   and a.drugstoreid_chr = ?
   and a.status = 1";
            DataTable dt = new DataTable();
            objHRPServ.CreateDatabaseParameter(3, out objValues);
            objValues[0].Value = m_strMedicineid;
            objValues[1].Value = m_strLotNo;
            objValues[2].Value = m_strDurgStoreid;
            lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objValues);
            objHRPServ.Dispose();
            objHRPServ = null;
            if (lngRes > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        m_dblIPAmount += Convert.ToDouble(dt.Rows[i1]["iprealgross_int"]);
                        m_dblOPAmount += Convert.ToDouble(dt.Rows[i1]["oprealgross_int"]);
                    }
                    //m_dblIPAmount = Convert.ToDouble(dt.Rows[0]["iprealgross_int"]);
                    //m_dblOPAmount = Convert.ToDouble(dt.Rows[0]["oprealgross_int"]);

                }
            }
            return lngRes;

        }
        #endregion

        #region 根据条件获取某药品当前库存数量
        /// <summary>
        /// 根据条件获取某药品当前库存数量
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_strInstorageid"></param>
        /// <param name="m_dtmInstorage"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_dblIPAmount"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCurrentGrossByConditions(long m_lngseriesid_int, ref double m_dblOPAmount, ref double m_dblIPAmount)
        {
            long lngRes = -1;
            string strSQL;
            m_dblOPAmount = 0d;
            m_dblIPAmount = 0d;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"select a.seriesid_int, a.iprealgross_int, a.oprealgross_int
  from t_ds_storage_detail a
  where a.seriesid_int=?
   and a.status = 1";
            DataTable dt = new DataTable();
            objHRPServ.CreateDatabaseParameter(1, out objValues);
            objValues[0].Value = m_lngseriesid_int;

            lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objValues);
            objHRPServ.Dispose();
            objHRPServ = null;
            if (lngRes > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        m_dblIPAmount = Convert.ToDouble(dt.Rows[i1]["iprealgross_int"]);
                        m_dblOPAmount = Convert.ToDouble(dt.Rows[i1]["oprealgross_int"]);
                    }

                }
            }
            return lngRes;

        }
         #endregion   

        #region 获取流水号获取药房出库主表信息
        /// <summary>
        /// 获取流水号获取药房出库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetOutstorageInfoBySeriesID(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeq, out clsDS_OutStorage_VO p_objOutMainVO)
        {
            p_objOutMainVO = null;
            DataTable m_dtOutstorage = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL =
       @"select a.seriesid_int,
       a.outdrugstoreid_vchr,
       b.deptname_vchr as medstorename_vchr,
       a.drugstoreid_chr,
       a.comment_vchr,
       a.status_int,
       formtype_int,
       a.typecode_vchr,
       a.instoredept_chr,
       c.deptname_vchr,
       a.makeorder_dat,
       a.examid_chr,
       d.lastname_vchr as examname,
       a.examid_chr,
       a.inaccounterid_chr,
       f.lastname_vchr as inaccountername,
       a.makerid_chr,
       h.lastname_vchr as makername,
       i.typename_vchr,
       a.inaccount_dat,a.examdate_dat,
       0 summoney
  from t_ds_outstorage  a,
       t_bse_deptdesc   b,
       t_bse_deptdesc   c,
       t_bse_employee   d,
       t_bse_employee   f,
       t_bse_employee   h,
       t_aid_impexptype i
 where a.drugstoreid_chr = b.deptid_chr(+)
   and a.instoredept_chr = c.deptid_chr(+)
   and a.examid_chr = d.empid_chr(+)
   and a.inaccounterid_chr = f.empid_chr(+)
   and a.makerid_chr = h.empid_chr(+)
   and a.typecode_vchr = i.typecode_vchr(+)
   and a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_lngSeq;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtOutstorage, m_objParaArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (m_dtOutstorage.Rows.Count > 0)
                {
                    DataRow dr = m_dtOutstorage.Rows[0];
                    p_objOutMainVO = new clsDS_OutStorage_VO();
                    p_objOutMainVO.m_datMAKEORDER_DAT = Convert.ToDateTime(dr["makeorder_dat"]);
                    p_objOutMainVO.m_intSTATUS = Convert.ToInt32(dr["status_int"]);
                    p_objOutMainVO.m_intFORMTYPE_INT = Convert.ToInt32(dr["formtype_int"]);
                    p_objOutMainVO.m_strTYPECODE_VCHR = Convert.ToString(dr["typecode_vchr"]);
                    p_objOutMainVO.m_strTYPENAME_VCHR = Convert.ToString(dr["typename_vchr"]);
                    p_objOutMainVO.m_lngSERIESID_INT = Convert.ToInt64(dr["seriesid_int"]);
                    p_objOutMainVO.m_strMAKERID_CHR = Convert.ToString(dr["makerid_chr"]);
                    p_objOutMainVO.m_strMakeName = Convert.ToString(dr["makername"]);
                    p_objOutMainVO.m_strINSTOREDEPT_CHR = Convert.ToString(dr["instoredept_chr"]);
                    p_objOutMainVO.m_strEXAMID_CHR = Convert.ToString(dr["examid_chr"]);
                    p_objOutMainVO.m_strDRUGSTOREID_CHR = Convert.ToString(dr["drugstoreid_chr"]);
                    p_objOutMainVO.m_strOUTDRUGSTOREID_VCHR = Convert.ToString(dr["outdrugstoreid_vchr"]);
                    p_objOutMainVO.m_datEXAM_DATE = Convert.ToDateTime(dr["examdate_dat"]);
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

        #region 获取主表对应的零售金额
        /// <summary>
        /// 获取主表对应的零售金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="p_dblSummoney"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSumMoney(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, out double p_dblSummoney)
        {
            p_dblSummoney = 0;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL =
       @"select a.ipamount_int, a.opretailprice_int, a.packqty_dec
	from t_ds_outstorage_detail a, t_ds_outstorage b
 where b.seriesid_int = a.seriesid2_int
	 and b.seriesid_int = ?
	 and a.status = 1 ";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_lngSeriesID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, m_objParaArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        dr = dtbResult.Rows[i1];
                        p_dblSummoney += Math.Round(Convert.ToDouble(dr["ipamount_int"]) * Convert.ToDouble(dr["opretailprice_int"]) / Convert.ToDouble(dr["packqty_dec"]), 4);
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

        #region 判断出库单是否已开入库单
        /// <summary>
        /// 判断出库单是否已开入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_blnHasGenerateInstorageBill"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIfHasGenerateInstorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBillNo, out bool p_blnHasGenerateInstorageBill)
        {
            p_blnHasGenerateInstorageBill = false;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL =
       @"select a.indrugstoreid_vchr
	from t_ds_instorage a
 where a.outstorageid_vchr = ?
	 and a.status <> 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_strBillNo;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, m_objParaArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_blnHasGenerateInstorageBill = true;
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

        #region 从Excel导入住院处方
        /// <summary>
        /// 从Excel导入住院处方
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_dtbTemp"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckStorage(System.Security.Principal.IPrincipal p_objPrincipal,bool p_blnIsHospital, string p_strDrugStoreID, ref DataTable p_dtbTemp, ref DataTable p_dtbResult)
        {      
            p_dtbResult.Rows.Clear();
            DataTable dtbTemp = new DataTable();
            string m_strMedicineID = string.Empty;
            bool m_blnByIP = false;//为false时使用基本单位，为true使用最小单位
            double m_dblPackQty = 0d;//包装量
            double m_dblOutAmount = 0d;//出库量
            double m_dblAvalidAmount = 0d;//可用库存数量
            
            DataRow drRow = null;//出库单每一行
            long lngRes = 0;
            try
            {
                foreach (DataRow p_drTemp in p_dtbTemp.Rows)
                {
                    m_strMedicineID = string.Empty;
                    m_dblPackQty = 0;
                    m_blnByIP = false;
                    m_dblOutAmount = 0;
                    m_dblAvalidAmount = 0;
                    #region 检查药品信息表是否有所求药品，用助剂码、厂家、单价作条件，如果有多条，则返回药品编码最大者；
                    string strSQL = "";
                    //按基本单位来查
                    if (p_blnIsHospital)
                    {
                        strSQL = @"select a.medicineid_chr,a.packqty_dec
  from t_bse_medicine a
 where a.ifstop_int = 0 and a.assistcode_chr = ?
   and a.productorid_chr = ?
   and abs(a.unitprice_mny - ?) < 0.01
   and a.ipchargeflg_int = 0
order by a.medicineid_chr desc";
                    }
                    else
                    {
                        strSQL = @"select a.medicineid_chr,a.packqty_dec
  from t_bse_medicine a
 where a.ifstop_int = 0 and a.assistcode_chr = ?
   and a.productorid_chr = ?
   and abs(a.unitprice_mny - ?) < 0.01
   and a.opchargeflg_int = 0
order by a.medicineid_chr desc";
                    }
                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    System.Data.IDataParameter[] m_objParaArr = null;
                    objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                    m_objParaArr[0].Value = Convert.ToString(p_drTemp[0]);
                    m_objParaArr[1].Value = Convert.ToString(p_drTemp[2]);
                    m_objParaArr[2].Value = Convert.ToDouble(p_drTemp[7]);

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, m_objParaArr);
                    
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        if (dtbTemp.Rows[0][0] != null)
                        {
                            m_strMedicineID = Convert.ToString(dtbTemp.Rows[0][0]);
                            m_dblPackQty = Convert.ToDouble(dtbTemp.Rows[0][1]);
                            m_blnByIP = false;
                        }
                    }
                    
                    if (m_strMedicineID.Length == 0)//按最小单位来查
                    {
                        //允许误差在0.01之内
                        if (p_blnIsHospital)
                        {
                            strSQL = @"select a.medicineid_chr, a.packqty_dec
  from t_bse_medicine a
 where a.ifstop_int = 0
   and a.assistcode_chr = ?
   and a.productorid_chr = ?
   and abs(round(a.unitprice_mny / a.packqty_dec, 4) - ?) < 0.01
   and a.ipchargeflg_int = 1
 order by a.medicineid_chr desc";
                        }
                        else
                        {
                            strSQL = @"select a.medicineid_chr, a.packqty_dec
  from t_bse_medicine a
 where a.ifstop_int = 0
   and a.assistcode_chr = ?
   and a.productorid_chr = ?
   and abs(round(a.unitprice_mny / a.packqty_dec, 4) - ?) < 0.01
   and a.opchargeflg_int = 1
 order by a.medicineid_chr desc";
                        }
                        objHRPServ.CreateDatabaseParameter(3, out m_objParaArr);
                        m_objParaArr[0].Value = Convert.ToString(p_drTemp[0]);
                        m_objParaArr[1].Value = Convert.ToString(p_drTemp[2]);
                        m_objParaArr[2].Value = Convert.ToDouble(p_drTemp[7]);

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, m_objParaArr);
                        
                        if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                        {
                            if (dtbTemp.Rows[0][0] != null)
                            {
                                m_strMedicineID = Convert.ToString(dtbTemp.Rows[0][0]);
                                m_dblPackQty = Convert.ToDouble(dtbTemp.Rows[0][1]);
                                m_blnByIP = true;
                            }
                        }
                        
                    }
                    if (m_strMedicineID.Length == 0)
                    {
                        p_drTemp[8] = "找不到符合条件的药品";
                        continue;
                    }
                    #endregion

                    #region 检查可用库存是否足以出库
                    if (!m_blnByIP)//基本单位
                    {
                        m_dblOutAmount = Convert.ToDouble(p_drTemp[5]) * m_dblPackQty;
                    }
                    else//最小单位
                    {
                        m_dblOutAmount = Convert.ToDouble(p_drTemp[5]);
                    }
                    strSQL = @"select sum(a.ipavailablegross_num)
  from t_ds_storage_detail a, t_ds_storage b
 where a.medicineid_chr = b.medicineid_chr
   and a.drugstoreid_chr = b.drugstoreid_chr
   and a.status = 1
   and b.ifstop_int = 0
   and a.drugstoreid_chr = ?
   and a.medicineid_chr = ?";
                    objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                    m_objParaArr[0].Value = p_strDrugStoreID;
                    m_objParaArr[1].Value = m_strMedicineID;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, m_objParaArr);
                    
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        if (Convert.ToString(dtbTemp.Rows[0][0]).Length > 0)
                        {
                            m_dblAvalidAmount = Convert.ToDouble(dtbTemp.Rows[0][0]);
                            if (m_dblOutAmount > m_dblAvalidAmount)
                            {                                  
                                p_drTemp[8] = "可用库存不足出库";
                                continue;
                            }
                        }
                        else
                        {
                            p_drTemp[8] = "可用库存不足出库";
                            continue;
                        }
                    }
                    

                    #endregion

                    strSQL = @"select a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       case
         when a.lotno_vchr = 'UNKNOWN' then
          ''
         else
          a.lotno_vchr
       end lotno_vchr,
       a.opretailprice_int,
       a.opwholesaleprice_int,
       a.oprealgross_int,
       a.opavailablegross_num,
       a.opunit_chr,
       a.ipretailprice_int,
       a.ipwholesaleprice_int,
       a.iprealgross_int,
       a.ipavailablegross_num,
       a.ipunit_chr,
       a.validperiod_dat,
       a.instoreid_vchr,
       a.instoragedate_dat,
       a.seriesid_int,
       b.assistcode_chr,
       b.medicinetypeid_chr,
       b.packqty_dec,
       a.productorid_chr,
       b.opchargeflg_int,b.ipchargeflg_int,a.dsinstoreid_vchr
  from t_ds_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 where a.drugstoreid_chr = ?
   and a.medicineid_chr = ?
   and a.status = 1
 order by a.validperiod_dat, a.instoragedate_dat";

                    objHRPServ.CreateDatabaseParameter(2, out m_objParaArr);
                    m_objParaArr[0].Value = p_strDrugStoreID;
                    m_objParaArr[1].Value = m_strMedicineID;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, m_objParaArr);
                    
                        if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                        {
                            for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                            {
                                if (m_dblOutAmount == 0) break;
                                m_dblAvalidAmount = Convert.ToDouble(dtbTemp.Rows[i1]["ipavailablegross_num"]);
                                if (m_dblAvalidAmount <= 0 && i1 != dtbTemp.Rows.Count - 1)//如果不是最后一条记录，且可用量小于等于0，则不使用当前行
                                    continue;
                                drRow = p_dtbResult.NewRow();
                                drRow["MEDICINEID_CHR"] = dtbTemp.Rows[i1]["MEDICINEID_CHR"];
                                drRow["MEDICINENAME_VCHR"] = dtbTemp.Rows[i1]["MEDICINENAME_VCHR"];
                                drRow["MEDSPEC_VCHR"] = dtbTemp.Rows[i1]["MEDSPEC_VCHR"];
                                drRow["OPUNIT_CHR"] = dtbTemp.Rows[i1]["OPUNIT_CHR"];

                                drRow["LOTNO_VCHR"] = dtbTemp.Rows[i1]["LOTNO_VCHR"];
                                drRow["INSTOREID_VCHR"] = dtbTemp.Rows[i1]["DSINSTOREID_VCHR"];
                                if (Convert.ToDateTime(dtbTemp.Rows[i1]["instoragedate_dat"]).ToString("yyyy-MM-dd") == "0001-01-01")
                                {
                                    drRow["instoragedate_dat"] = DBNull.Value;
                                }
                                else
                                {
                                    drRow["instoragedate_dat"] = Convert.ToDateTime(dtbTemp.Rows[i1]["instoragedate_dat"]).ToString("yyyy-MM-dd");
                                }
                                if (Convert.ToDateTime(dtbTemp.Rows[i1]["validperiod_dat"]).ToString("yyyy-MM-dd") == "0001-01-01")
                                {
                                    drRow["validperiod_dat"] = DBNull.Value;
                                }
                                else
                                {
                                    drRow["validperiod_dat"] = Convert.ToDateTime(dtbTemp.Rows[i1]["validperiod_dat"]).ToString("yyyy-MM-dd");
                                }

                                drRow["OPWHOLESALEPRICE_INT"] = dtbTemp.Rows[i1]["OPWHOLESALEPRICE_INT"];
                                drRow["OPRETAILPRICE_INT"] = dtbTemp.Rows[i1]["OPRETAILPRICE_INT"];//小数位

                                //drRow["oprealgross_int"] = dtbTemp.Rows[i1]["oprealgross_int"];
                                drRow["assistcode_chr"] = dtbTemp.Rows[i1]["assistcode_chr"];
                                //drRow["opavailagross_int"] = dtbTemp.Rows[i1]["opavailagross_int"];
                                drRow["medicinetypeid_chr"] = dtbTemp.Rows[i1]["medicinetypeid_chr"];
                                drRow["ipunit_chr"] = dtbTemp.Rows[i1]["ipunit_chr"];
                                drRow["packqty_dec"] = dtbTemp.Rows[i1]["packqty_dec"];
                                //drRow["seriesid_int"] = dtbTemp.Rows[i1]["seriesid_int"];
                                drRow["storageseriesid_chr"] = dtbTemp.Rows[i1]["seriesid_int"];
                                drRow["ipretailprice_int"] = dtbTemp.Rows[i1]["ipretailprice_int"];
                                drRow["ipwholesaleprice_int"] = dtbTemp.Rows[i1]["ipwholesaleprice_int"];
                                //drRow["iprealgross_int"] = dtbTemp.Rows[i1]["iprealgross_int"];
                                drRow["ipavailablegross_num"] = dtbTemp.Rows[i1]["ipavailablegross_num"];
                                drRow["productorid_chr"] = dtbTemp.Rows[i1]["productorid_chr"];
                                drRow["opchargeflg_int"] = dtbTemp.Rows[i1]["opchargeflg_int"];
                                drRow["ipchargeflg_int"] = dtbTemp.Rows[i1]["ipchargeflg_int"];
                                //drRow["opavailagross_int"] = dtbTemp.Rows[i1]["opavailablegross_num"];

                                if (!m_blnByIP)//基本单位                                
                                {
                                    drRow["UNIT_CHR"] = dtbTemp.Rows[i1]["OPUNIT_CHR"];
                                    drRow["WHOLESALEPRICE_INT"] = dtbTemp.Rows[i1]["OPWHOLESALEPRICE_INT"];
                                }
                                else//最小单位
                                {
                                    drRow["UNIT_CHR"] = dtbTemp.Rows[i1]["IPUNIT_CHR"];
                                    drRow["WHOLESALEPRICE_INT"] = dtbTemp.Rows[i1]["ipwholesaleprice_int"];
                                }

                                if (m_dblOutAmount > 0 && m_dblAvalidAmount > 0)
                                {
                                    if (m_dblOutAmount >= m_dblAvalidAmount)
                                    {
                                        if (!m_blnByIP)
                                        {
                                            drRow["AMOUNT_INT"] = Math.Round(m_dblAvalidAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["IPAMOUNT_INT"] = m_dblAvalidAmount;
                                            drRow["OPAMOUNT_INT"] = Math.Round(m_dblAvalidAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["RETAILPRICE_INT"] = Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]);
                                        }
                                        else
                                        {
                                            drRow["AMOUNT_INT"] = m_dblAvalidAmount;
                                            drRow["IPAMOUNT_INT"] = m_dblAvalidAmount;
                                            drRow["OPAMOUNT_INT"] = Math.Round(m_dblAvalidAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["RETAILPRICE_INT"] = Math.Round(Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 4);
                                        }                                        
                                        m_dblOutAmount -= m_dblAvalidAmount;
                                    }
                                    else
                                    {
                                        if (!m_blnByIP)
                                        {
                                            drRow["AMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["IPAMOUNT_INT"] = m_dblOutAmount;
                                            drRow["OPAMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["RETAILPRICE_INT"] = Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]);
                                        }
                                        else
                                        {
                                            drRow["AMOUNT_INT"] = m_dblOutAmount;
                                            drRow["IPAMOUNT_INT"] = m_dblOutAmount;
                                            drRow["OPAMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                            drRow["RETAILPRICE_INT"] = Math.Round(Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 4);
                                        }                                        
                                        m_dblOutAmount = 0;
                                    }
                                }
                                else
                                {
                                    if (!m_blnByIP)
                                    {
                                        drRow["AMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                        drRow["IPAMOUNT_INT"] = m_dblOutAmount;
                                        drRow["OPAMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                        drRow["RETAILPRICE_INT"] = Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]);
                                    }
                                    else
                                    {
                                        drRow["AMOUNT_INT"] = m_dblOutAmount;
                                        drRow["IPAMOUNT_INT"] = m_dblOutAmount;
                                        drRow["OPAMOUNT_INT"] = Math.Round(m_dblOutAmount / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 2);
                                        drRow["RETAILPRICE_INT"] = Math.Round(Convert.ToDouble(dtbTemp.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(dtbTemp.Rows[i1]["packqty_dec"]), 4);
                                    }                                    
                                    m_dblOutAmount = 0;
                                }

                                p_dtbResult.Rows.Add(drRow);

                            }
                        }
                        objHRPServ.Dispose();
                        objHRPServ = null;                  
                }
                p_dtbTemp.AcceptChanges();
                DataView dvResult = p_dtbTemp.DefaultView;
                dvResult.RowFilter = "isnull(原因,'') <> ''";
                p_dtbTemp = dvResult.ToTable();
                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取单据号获取出库单信息
        /// <summary>
        /// 获取单据号获取出库单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_strBillID">单据号</param>
        /// <param name="p_objMain">主表信息</param>
        /// <param name="p_dtbSub">明细表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngLoadBill(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsHospital,string p_strBillID, out clsDS_OutStorage_VO p_objMain, out DataTable p_dtbSub)
        {
            p_objMain = null;
            p_dtbSub = null;
            DataTable dtbMain = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL =
       @"select a.seriesid_int,
       a.outdrugstoreid_vchr,
       b.deptname_vchr as medstorename_vchr,
       a.drugstoreid_chr,
       a.comment_vchr,a.status_int as status,
       decode(a.status_int, 0, '删除', 1, '新制', 2, '审核', 3, '入帐') as status_int,
       formtype_int,
       a.typecode_vchr,
       a.instoredept_chr,
       c.deptname_vchr,
       a.makeorder_dat,
       a.examid_chr,
       d.lastname_vchr as examname,
       a.examid_chr,
       a.inaccounterid_chr,
       f.lastname_vchr as inaccountername,
       a.makerid_chr,
       h.lastname_vchr as makername,
       i.typename_vchr,
       a.inaccount_dat,a.examdate_dat,
       0 summoney
  from t_ds_outstorage  a,
       t_bse_deptdesc   b,
       t_bse_deptdesc   c,
       t_bse_employee   d,
       t_bse_employee   f,
       t_bse_employee   h,
       t_aid_impexptype i
 where a.drugstoreid_chr = b.deptid_chr(+)
   and a.instoredept_chr = c.deptid_chr(+)
   and a.examid_chr = d.empid_chr(+)
   and a.inaccounterid_chr = f.empid_chr(+)
   and a.makerid_chr = h.empid_chr(+)
   and a.typecode_vchr = i.typecode_vchr(+)
   and a.outdrugstoreid_vchr = ? 
 order by a.outdrugstoreid_vchr desc";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] m_objParaArr = null;
                objHRPServ.CreateDatabaseParameter(1, out m_objParaArr);
                m_objParaArr[0].Value = p_strBillID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, m_objParaArr);
                if (dtbMain != null && dtbMain.Rows.Count > 0)
                {
                    p_objMain = new clsDS_OutStorage_VO();
                    p_objMain.m_datMAKEORDER_DAT = Convert.ToDateTime(dtbMain.Rows[0]["makeorder_dat"]);
                    p_objMain.m_strMakeName = dtbMain.Rows[0]["makername"].ToString();
                    p_objMain.m_strTYPENAME_VCHR = dtbMain.Rows[0]["typename_vchr"].ToString();
                    p_objMain.m_strINSTOREDEPTName_CHR = dtbMain.Rows[0]["deptname_vchr"].ToString();
                    p_objMain.m_strDRUGSTOREName = dtbMain.Rows[0]["medstorename_vchr"].ToString();
                    p_objMain.m_strOUTDRUGSTOREID_VCHR = dtbMain.Rows[0]["outdrugstoreid_vchr"].ToString();
                    p_objMain.m_strCOMMENT_VCHR = dtbMain.Rows[0]["comment_vchr"].ToString();

                    m_lngGetOutstorageDetailByID(p_objPrincipal,p_blnIsHospital, Convert.ToInt64(dtbMain.Rows[0]["seriesid_int"]), out p_dtbSub);
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

        [AutoComplete]
        public long m_lngGetDSStorageGross(System.Security.Principal.IPrincipal p_objPrincipal,
                    List<long> m_glstSeriesID, long p_lngMainSeriesID, out Dictionary<long, double> m_gdicDSStorage)
        {
            long lngRes = -1;
            m_gdicDSStorage = null;
            StringBuilder stb = new StringBuilder(21 * m_glstSeriesID.Count);
            for(int i = 0; i < m_glstSeriesID.Count; i++)
            {
                if(i==0)
                {
                    stb.Append(m_glstSeriesID[i].ToString());
                }
                else
                {
                    stb.Append("," + m_glstSeriesID[i].ToString());
                } 
            }

            try
            {
                string strSQL = @"select   a.seriesid_int, a.ipavailablegross_num
                                      from t_ds_storage_detail a
                                     where a.canprovide_int = 1
                                       and a.seriesid_int in (" + stb.ToString().Trim() + ")";
                stb = null;

                DataTable dtbValue = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes > 0 && dtbValue.Rows.Count > 0)
                {
                    m_gdicDSStorage = new Dictionary<long, double>();
                    foreach(DataRow dr in dtbValue.Rows)
                    {
                        m_gdicDSStorage.Add(Convert.ToInt64(dr["seriesid_int"]), Convert.ToDouble(dr["ipavailablegross_num"]));
                    }
                }
                else
                {
                    return lngRes;
                }

                if(p_lngMainSeriesID!=-1)
                {
                    clsDS_UpdateStorageBySeriesID_VO[] m_objForUpdateArr;
                    this.m_lngGetDetailForUpdate(p_objPrincipal, p_lngMainSeriesID, 0, out m_objForUpdateArr);
                    if (m_objForUpdateArr != null)
                    {
                        for (int i = 0; i < m_objForUpdateArr.Length; i++)
                        {
                            if (m_gdicDSStorage.ContainsKey(m_objForUpdateArr[i].m_intSeriesID))
                            {
                                m_gdicDSStorage[m_objForUpdateArr[i].m_intSeriesID] -= m_objForUpdateArr[i].m_dblIPAvalid;
                            }
                            else
                            {
                                m_gdicDSStorage.Add(m_objForUpdateArr[i].m_intSeriesID, m_objForUpdateArr[i].m_dblIPAvalid * -1);
                            }
                        }
                        m_objForUpdateArr = null;
                    }
                    else{
                        return -11;   
                    }
                } 
            }
            catch(Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 查询药房出库药品状态
        /// </summary>
        /// <param name="p_strSeq">序列号</param>
        /// <param name="p_intQueryStyle">查询类型是根据主表序列号还是子表序列号0-主表,1-子表</param>
        /// <param name="p_strState">状态</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryMedOutStoreState(string p_strSeq, int p_intQueryStyle, out string p_strState)
        {
            long lngRes = 0;
            p_strState = null;
            DataTable dtResult = null;
            string strSql = null;
            if (p_intQueryStyle == 0)
            {
                strSql = @"select a.status_int from t_ds_outstorage a where a.seriesid_int = ?";
            }
            else
            {
                strSql = @"select b.status_int
                            from t_ds_outstorage b
                            where b.seriesid_int = (select a.seriesid2_int
                                                   from t_ds_outstorage_detail a
                                                  where a.seriesid_int = ?)";
            }
            try {
                clsHRPTableService clsHrpSvc = new clsHRPTableService();
                IDataParameter[] objParams = null;
                clsHrpSvc.CreateDatabaseParameter(1, out objParams);
                objParams[0].Value = p_strSeq;

                lngRes = clsHrpSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objParams);
                if (dtResult.Rows.Count > 0 && dtResult != null)
                {
                    p_strState = dtResult.Rows[0][0].ToString();
                }
                clsHrpSvc.Dispose();
                clsHrpSvc = null;
                
            }
            catch (Exception objex)
            {
                com.digitalwave.Utility.clsLogText clsError = new com.digitalwave.Utility.clsLogText();
                bool blnRes = clsError.LogError(objex.ToString());
            }
            return lngRes;
        }
    }
}
