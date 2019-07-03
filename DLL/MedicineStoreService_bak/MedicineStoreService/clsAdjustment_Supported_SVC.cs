using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.middletier.MedicineStoreService
{

    /// <summary>
    /// 药品调价
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsAdjustment_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药房药品调价记录
        /// <summary>
        ///  获取药房药品调价记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="lngMainSeq"></param>
        /// <param name="objMedInfoList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDsAdjustMedInfoList(System.Security.Principal.IPrincipal p_objPrincipal, long[] lngMainSeq,out  List<clsDS_MedicineInfoForAdjustPrice> objMedInfoList )
        {
            objMedInfoList = new List<clsDS_MedicineInfoForAdjustPrice>();
            if (lngMainSeq == null || lngMainSeq.Length == 0)
            {
                return -1;
            }
            clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr = null;
       
            long lngRes = 0;
            try
            {
                for (int i = 0; i < lngMainSeq.Length; i++)
                {
                    p_objAdjustMedicineArr = null;
                    lngRes = this.m_lngGetDSAdjustmentDetailArr(p_objPrincipal, lngMainSeq[i], out p_objAdjustMedicineArr);
                    if (lngRes > 0 && p_objAdjustMedicineArr!=null)
                        objMedInfoList.AddRange(p_objAdjustMedicineArr);
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

        #region 获取药房调价明细表内容

        /// <summary>
        ///  添加药房调价主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表Vo信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDSAdjustmentDetailArr(System.Security.Principal.IPrincipal p_objPrincipal,long lngSEQ, out clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {

 
            DataTable dt = new DataTable();
            long lngRes = 0;
            p_objAdjustMedicineArr = null;
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medicinename_vch,
       a.medspec_vchr,
       a.productorid_chr,
       a.lotno_vchr,
       a.ipcurrentgross_int,
       a.opcurrentgross_int,
       a.packqty_dec,
       a.ipoldretailprice_int,
       a.opoldretailprice_int,
       a.ipnewretailprice_int,
       a.opnewretailprice_int,
       a.reason_vchr,
       a.status_int,
       a.validperiod_dat,
       a.opunit_vchr,
       a.ipunit_vchr,
       a.drugstoreid_chr,
       a.hasgross_int,
       c.medicinetypeid_chr,b.adjustpriceid_vchr
  from t_ds_adjustprice_detail a, t_ds_adjustprice b, t_bse_medicine c
 where a.seriesid2_int = b.seriesid_int
   and a.status_int = 1
   and a.medicineid_chr = c.medicineid_chr
   and b.msseriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngSEQ;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    p_objAdjustMedicineArr = new clsDS_MedicineInfoForAdjustPrice[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        p_objAdjustMedicineArr[i] = new clsDS_MedicineInfoForAdjustPrice();
                        p_objAdjustMedicineArr[i].m_dblIPNewRetailPrice = Convert.ToDouble(dt.Rows[i]["ipnewretailprice_int"]);
                        p_objAdjustMedicineArr[i].m_dblOPNewRetailPrice = Convert.ToDouble(dt.Rows[i]["opnewretailprice_int"]);
                        p_objAdjustMedicineArr[i].m_dblIPOldRetailPrice = Convert.ToDouble(dt.Rows[i]["ipoldretailprice_int"]);
                        p_objAdjustMedicineArr[i].m_dblOPOldRetailPrice = Convert.ToDouble(dt.Rows[i]["opoldretailprice_int"]);
                        p_objAdjustMedicineArr[i].m_dtmValidDate = Convert.ToDateTime(dt.Rows[i]["validperiod_dat"]);
                        p_objAdjustMedicineArr[i].m_lngAdjustDetaiSEQ = Convert.ToInt64(dt.Rows[i]["seriesid_int"]);
                        p_objAdjustMedicineArr[i].m_strDrugStoreID = Convert.ToString(dt.Rows[i]["drugstoreid_chr"]);
                        p_objAdjustMedicineArr[i].m_strLotNO = Convert.ToString(dt.Rows[i]["lotno_vchr"]);
                        p_objAdjustMedicineArr[i].m_strMedicineID = Convert.ToString(dt.Rows[i]["medicineid_chr"]);
                        p_objAdjustMedicineArr[i].m_intHasGross = Convert.ToInt16(dt.Rows[i]["hasgross_int"]);
                        p_objAdjustMedicineArr[i].m_strMedicineTypeid = Convert.ToString(dt.Rows[i]["medicinetypeid_chr"]);
                        p_objAdjustMedicineArr[i].m_strMedicineSpec = Convert.ToString(dt.Rows[i]["medspec_vchr"]);
                        p_objAdjustMedicineArr[i].m_strMedicineName = Convert.ToString(dt.Rows[i]["medicinename_vch"]);
                        p_objAdjustMedicineArr[i].m_strProductor = Convert.ToString(dt.Rows[i]["productorid_chr"]);
                        p_objAdjustMedicineArr[i].m_strOPunit = Convert.ToString(dt.Rows[i]["opunit_vchr"]);
                        p_objAdjustMedicineArr[i].m_strIPunit = Convert.ToString(dt.Rows[i]["ipunit_vchr"]);
                        p_objAdjustMedicineArr[i].m_strAdjustPriceid = Convert.ToString(dt.Rows[i]["adjustpriceid_vchr"]);
                        p_objAdjustMedicineArr[i].m_dblPACKQTY_DEC = Convert.ToDouble(dt.Rows[i]["packqty_dec"]);
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

        #region 获取药房调价明细信息
        /// <summary>
        /// 获取药房调价明细信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngMainSeq"></param>
        /// <param name="m_objMsAdjustmentDetail"></param>
        /// <param name="m_objDsAdjustDetailList"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentSeriesid(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngMainSeq,out long m_lngDSMainSeq)
        {
            DataTable p_dtbValue = null;
            long lngRes = 0;
            m_lngDSMainSeq = 0;
            try
            {
         
                string strSQL = @"select a.seriesid_int from t_ds_adjustprice a where a.msseriesid_int=?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_lngMainSeq;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                {
                    m_lngDSMainSeq = Convert.ToInt64(p_dtbValue.Rows[0]["seriesid_int"]);
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
         /// 获取药房调价明细信息
         /// </summary>
         /// <param name="p_objPrincipal"></param>
         /// <param name="m_lngMainSeq"></param>
         /// <param name="m_objMsAdjustmentDetail"></param>
         /// <param name="m_objDsAdjustDetailList"></param>
         /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentDetailArr(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngMainSeq, clsMS_Adjustment_Detail m_objMsAdjustmentDetail, ref List<clsDS_Adjustment_Detail> m_objDsAdjustDetailList)
        {
            DataTable p_dtbValue = null;
            clsDS_Adjustment_Detail objTempDetailVo;
            long lngRes = 0;
            try
            {
                for (int i = 0; i < m_objDsAdjustDetailList.Count; i++)
                {
                    if (m_objDsAdjustDetailList[i].m_strMEDICINEID_CHR == m_objMsAdjustmentDetail.m_strMEDICINEID_CHR)
                        return lngRes;
                }
                string strSQL = @"select a.drugstoreid_chr,
       round(a.opretailprice_int / a.packqty_dec, 4) as ipretailprice_int,
       a.opretailprice_int, sum(a.iprealgross_int) as iprealgross_int,
       sum(round(a.iprealgross_int / a.packqty_dec, 2)) as oprealgross_int,
       a.lotno_vchr, a.validperiod_dat
  from t_ds_storage_detail a
 where a.medicineid_chr = ?
   and a.status = 1
 group by a.drugstoreid_chr, a.opretailprice_int, a.packqty_dec,
          a.lotno_vchr, a.validperiod_dat";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_objMsAdjustmentDetail.m_strMEDICINEID_CHR;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                {
                    for (int i = 0; i < p_dtbValue.Rows.Count; i++)
                    {
                        objTempDetailVo = new clsDS_Adjustment_Detail();
                        objTempDetailVo.m_dblIPNEWRETAILPRICE_INT = Convert.ToDouble(Convert.ToDouble(m_objMsAdjustmentDetail.m_dblNEWRETAILPRICE_INT / m_objMsAdjustmentDetail.m_dblPackage).ToString("0.0000"));
                        objTempDetailVo.m_dblOPNEWRETAILPRICE_INT = m_objMsAdjustmentDetail.m_dblNEWRETAILPRICE_INT;
                        objTempDetailVo.m_dblIPOLDRETAILPRICE_INT = Convert.ToDouble(p_dtbValue.Rows[i]["ipretailprice_int"].ToString());
                        objTempDetailVo.m_dblOPOLDRETAILPRICE_INT = Convert.ToDouble(p_dtbValue.Rows[i]["opretailprice_int"].ToString());
                        objTempDetailVo.m_strDrugStoreid = p_dtbValue.Rows[i]["drugstoreid_chr"].ToString();
                        objTempDetailVo.m_dblIPCURRENTGROSS_INT = Convert.ToDouble(p_dtbValue.Rows[i]["iprealgross_int"].ToString());
                        objTempDetailVo.m_dblOPCURRENTGROSS_INT = Convert.ToDouble(p_dtbValue.Rows[i]["oprealgross_int"].ToString());
                        objTempDetailVo.m_dblPackage = m_objMsAdjustmentDetail.m_dblPackage;
                        if(Convert.ToDateTime(p_dtbValue.Rows[i]["validperiod_dat"]).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            objTempDetailVo.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_dtbValue.Rows[i]["validperiod_dat"]);
                        }
                        objTempDetailVo.m_intSTATUS_INT = m_objMsAdjustmentDetail.m_intSTATUS_INT;
                        objTempDetailVo.m_lngSERIESID2_INT = m_lngMainSeq;
                        objTempDetailVo.m_strIPUNIT_VCHR = m_objMsAdjustmentDetail.m_strIPUNIT_VCHR;
                        objTempDetailVo.m_strOPUNIT_VCHR = m_objMsAdjustmentDetail.m_strOPUNIT_VCHR;
                        objTempDetailVo.m_strREASON_VCHR = m_objMsAdjustmentDetail.m_strREASON_VCHR;
                        objTempDetailVo.m_strMEDICINEID_CHR = m_objMsAdjustmentDetail.m_strMEDICINEID_CHR;
                        objTempDetailVo.m_strMEDICINENAME_VCHR = m_objMsAdjustmentDetail.m_strMEDICINENAME_VCH;
                        objTempDetailVo.m_strMEDSPEC_VCHR = m_objMsAdjustmentDetail.m_strMEDSPEC_VCHR;
                        objTempDetailVo.m_strLOTNO_VCHR = p_dtbValue.Rows[i]["lotno_vchr"].ToString();
                        objTempDetailVo.m_strPRODUCTORID_CHR = m_objMsAdjustmentDetail.m_strPRODUCTORID_CHR;
                        objTempDetailVo.m_intHasGross = 1;
                        m_objDsAdjustDetailList.Add(objTempDetailVo);
                    }
                }
                else if (lngRes > 0 && p_dtbValue.Rows.Count == 0)
                {
                    objTempDetailVo = new clsDS_Adjustment_Detail();
                    objTempDetailVo.m_dblIPNEWRETAILPRICE_INT = Convert.ToDouble(Convert.ToDouble(m_objMsAdjustmentDetail.m_dblNEWRETAILPRICE_INT / m_objMsAdjustmentDetail.m_dblPackage).ToString("0.0000"));
                    objTempDetailVo.m_dblOPNEWRETAILPRICE_INT = m_objMsAdjustmentDetail.m_dblNEWRETAILPRICE_INT;
                    objTempDetailVo.m_dblIPOLDRETAILPRICE_INT = Convert.ToDouble(Convert.ToDouble(m_objMsAdjustmentDetail.m_dblOLDRETAILPRICE_INT / m_objMsAdjustmentDetail.m_dblPackage).ToString("0.0000"));
                    objTempDetailVo.m_dblOPOLDRETAILPRICE_INT = m_objMsAdjustmentDetail.m_dblOLDRETAILPRICE_INT;
                    objTempDetailVo.m_strDrugStoreid = string.Empty;
                    objTempDetailVo.m_dblIPCURRENTGROSS_INT =0;
                    objTempDetailVo.m_dblOPCURRENTGROSS_INT = 0;
                    objTempDetailVo.m_dblPackage = m_objMsAdjustmentDetail.m_dblPackage;
                    objTempDetailVo.m_dtmVALIDPERIOD_DAT = m_objMsAdjustmentDetail.m_dtmVALIDPERIOD_DAT;
                    objTempDetailVo.m_intSTATUS_INT = m_objMsAdjustmentDetail.m_intSTATUS_INT;
                    objTempDetailVo.m_lngSERIESID2_INT = m_lngMainSeq;
                    objTempDetailVo.m_strIPUNIT_VCHR = m_objMsAdjustmentDetail.m_strIPUNIT_VCHR;
                    objTempDetailVo.m_strOPUNIT_VCHR = m_objMsAdjustmentDetail.m_strOPUNIT_VCHR;
                    objTempDetailVo.m_strREASON_VCHR = m_objMsAdjustmentDetail.m_strREASON_VCHR;
                    objTempDetailVo.m_strMEDICINEID_CHR = m_objMsAdjustmentDetail.m_strMEDICINEID_CHR;
                    objTempDetailVo.m_strMEDICINENAME_VCHR = m_objMsAdjustmentDetail.m_strMEDICINENAME_VCH;
                    objTempDetailVo.m_strMEDSPEC_VCHR = m_objMsAdjustmentDetail.m_strMEDSPEC_VCHR;
                    objTempDetailVo.m_strLOTNO_VCHR = m_objMsAdjustmentDetail.m_strLOTNO_VCHR;
                    objTempDetailVo.m_strPRODUCTORID_CHR = m_objMsAdjustmentDetail.m_strPRODUCTORID_CHR;
                    objTempDetailVo.m_intHasGross = 0;
                    m_objDsAdjustDetailList.Add(objTempDetailVo);
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

        #region 最新的调价单据号

        /// <summary>
        /// 最新的调价单据号


        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestAdjustmentID(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.adjustpriceid_vchr)
  from t_ms_adjustprice t
 where t.adjustpriceid_vchr like ?";

                DataTable dtbValue = null;
                DateTime dtmNow = DateTime.Now;
                clsMS_Public_Supported_SVC clsPub = new clsMS_Public_Supported_SVC();
                clsPub.m_lngGetCurrentDateTime(out dtmNow);
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = dtmNow.ToString("yyyyMMdd") + "8%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = dtmNow.ToString("yyyyMMdd") + "80001";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = dtmNow.ToString("yyyyMMdd") + "80001";
                    }
                    else
                    {
                        strTemp = strTemp.Substring(9, 4);
                        p_strID = dtmNow.ToString("yyyyMMdd") + "8" + (Convert.ToInt32(strTemp) + 1).ToString("0000");
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

        #region 获取药品调价主表信息
        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.adjustpriceid_vchr,
       a.adjustpricedate_dat,
       a.newdate_dat,
       a.formtype_int,
       a.formstate_int,
       a.creatorid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.comment_vchr,
       c.lastname_vchr creatorname,
       d.lastname_vchr examername,
       case a.formstate_int
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_adjustprice a
 inner join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
                                     and b.status_int = 1
 inner join t_bse_employee c on a.creatorid_chr = c.empid_chr
 left outer join t_bse_employee d on a.examerid_chr = d.empid_chr
 where a.storageid_chr = ?
   and a.adjustpricedate_dat between ? and ?
   and a.formstate_int <> 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmSearchBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmSearchEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                DataView dv = p_dtbValue.DefaultView;
                dv.Sort = "adjustpriceid_vchr desc";
                p_dtbValue = dv.ToTable();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取药品调价主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmSearchBegin">搜索开始时间</param>
        /// <param name="p_dtmSearchEnd">搜索结束时间</param>
        /// <param name="p_dtbValue">药品调价主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmSearchBegin, DateTime p_dtmSearchEnd, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.adjustpriceid_vchr,
       a.adjustpricedate_dat,
       a.newdate_dat,
       a.formtype_int,
       a.formstate_int,
       a.creatorid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.comment_vchr,
       c.lastname_vchr creatorname,
       d.lastname_vchr examername,
       case a.formstate_int
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_adjustprice a
 inner join t_ms_adjustprice_detail b on a.seriesid_int = b.seriesid2_int
                                     and b.status_int = 1
 inner join t_bse_employee c on a.creatorid_chr = c.empid_chr
 left outer join t_bse_employee d on a.examerid_chr = d.empid_chr
 where a.storageid_chr = ?
   and a.adjustpricedate_dat between ? and ?
   and a.formstate_int <> 0
   and b.medicineid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmSearchBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmSearchEnd;
                objDPArr[3].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                DataView dv = p_dtbValue.DefaultView;
                dv.Sort = "adjustpriceid_vchr desc";
                p_dtbValue = dv.ToTable();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取药品调价明细
        /// <summary>
        /// 获取药品调价明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_dtbDetail">药品调价明细记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbDetail)
        {
            p_dtbDetail = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medicinename_vch,
       a.medspec_vchr,
       case
         when a.lotno_vchr = 'UNKNOWN' then
          ''
         else
          a.lotno_vchr
       end lotno_vchr,
       decode(a.currentgross_int, null, 0, a.currentgross_int) as currentgross_int,
       a.oldretailprice_int,
       a.newretailprice_int,
       a.reason_vchr,
       a.status_int,
       a.validperiod_dat,
       a.opunit_vchr,
       a.instorageid_vchr,
       a.callprice_int,
       b.assistcode_chr,
       a.productorid_chr,
       b.packqty_dec,
       b.ipunit_chr,
       a.hasgross_int,
       b.medicinetypeid_chr,
       c.storageid_chr,
       a.medspec_vchr,
       c.adjustpriceid_vchr,
       a.inputcallprice_int,
       a.oldwholesaleprice_int,
       a.newwholesaleprice_int, a.callprice_int
  from t_ms_adjustprice_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_ms_adjustprice c on c.seriesid_int = a.seriesid2_int
 where a.seriesid2_int = ?
   and a.status_int = 1
 order by a.medicineid_chr, a.lotno_vchr
";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbDetail, objDPArr);
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
        
        #region 根据药品ID获取药品
        /// <summary>
        /// 根据药品ID获取药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineByMedicineID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.assistcode_chr,
       a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.opunit_vchr,
       a.realgross_int,
       a.callprice_int,
       a.wholesaleprice_int,
       a.retailprice_int,
       a.lotno_vchr,
       a.instorageid_vchr,
       a.validperiod_dat,
       a.productorid_chr,
       a.instorageid_vchr,
       a.vendorid_chr,
       b.packqty_dec,
       b.ipunit_chr,b.unitprice_mny as baseretailprice, b.tradeprice_mny as basetradprice,
       1 hasgross_int,
       b.medicinetypeid_chr,c.grossprofitrate
  from t_ms_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 left join t_ms_grossprofitrateset c on b.medicinetypeid_chr=c.medicinetypeid_chr
 where a.status = 1
   and a.medicineid_chr = ?
   and a.storageid_chr = ?
 order by a.instoragedate_dat";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                if (lngRes > 0 && p_dtbMedicine.Rows.Count == 0)
                {
                    strSQL = @"select b.assistcode_chr,
       b.medicineid_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       b.opunit_chr as opunit_vchr,
       0 realgross_int,
       0 callprice_int,
       b.wholesaleprice_mny wholesaleprice_int,
       b.unitprice_mny as retailprice_int,
       '' lotno_vchr,
       '' instorageid_vchr,
       sysdate validperiod_dat,
       b.productorid_chr,
       '' instorageid_vchr,
       '' vendorid_chr,
       b.packqty_dec,
       b.ipunit_chr, b.unitprice_mny as baseretailprice,b.tradeprice_mny as basetradprice,
       0 hasgross_int,
       b.medicinetypeid_chr,c.grossprofitrate
  from t_bse_medicine b
left join t_ms_grossprofitrateset c on b.medicinetypeid_chr=c.medicinetypeid_chr
 where b.medicineid_chr = ?";
                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strMedicineID;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
       
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

        #region 获取金额
        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.oldretailprice_int,
       a.newretailprice_int,
       decode(a.currentgross_int,null,0,a.currentgross_int) as currentgross_int,
       b.adjustpriceid_vchr,
       b.formstate_int
  from t_ms_adjustprice_detail a, t_ms_adjustprice b
 where a.status_int = 1
   and b.formstate_int <> 0
   and a.seriesid2_int = b.seriesid_int
   and b.adjustpricedate_dat between ? and ?
   and b.storageid_chr = ?";

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

        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID </param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtbMoney">金额 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, string p_strMedicineID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.oldretailprice_int,
       a.newretailprice_int,
       decode(a.currentgross_int,null,0,a.currentgross_int) as currentgross_int,
       b.adjustpriceid_vchr,
       b.formstate_int
  from t_ms_adjustprice_detail a, t_ms_adjustprice b
 where a.status_int = 1
   and b.formstate_int <> 0
   and a.seriesid2_int = b.seriesid_int
   and b.adjustpricedate_dat between ? and ?
   and b.storageid_chr = ?
   and exists (select c.seriesid2_int
          from t_ms_adjustprice_detail c
         where c.medicineid_chr = ?
           and c.seriesid2_int = b.seriesid_int)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_strMedicineID;

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

        #region 判断药品是否可以调价
        /// <summary>
        ///  判断药品是否可以调价
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_strReturnMsg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngJudgeCanAdjustPriceByMedicineid(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedicineid, out string m_strReturnMsg)
        {
            m_strReturnMsg = string.Empty;
            int m_intRowNo = 0;
            long lngRes = -1;
            try
            {
                //如果有单据药库审核了但药房没进行请领审核，不允许对这些药品进行调价;
                string strSQL = @"select c.medicineid_chr,
       c.medicinename_vch,
       b.askid_vchr,
       d.medstorename_vchr
  from t_ms_outstorage        a,
       t_ds_ask               b,
       t_ms_outstorage_detail c,
       t_bse_medstore         d
 where a.outstorageid_vchr = b.outstorageid_vchr
   and b.askdept_chr = d.deptid_chr(+)
   and b.status_int = 3
   and a.seriesid_int = c.seriesid2_int
   and c.status = 1
   and c.medicineid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtResult = new DataTable();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedicineid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0&&dtResult!=null)
                {
                    int m_intRowCount = dtResult.Rows.Count;
                    DataRow dr = null;
                    for (int i = 0; i < m_intRowCount; i++)
                    {
                        dr = dtResult.Rows[i];
                        m_strReturnMsg += string.Format("{0}.{1}含有该药品({2})的请领单据({3})尚未进行药房审核,不能进行调价。\r\n\r\n",++m_intRowNo, dr["medstorename_vchr"].ToString(), dr["medicinename_vch"].ToString(), dr["askid_vchr"].ToString());
                    }

                }
                //如果有单据药库出库但药房没对审核入库单，不允许对这些药品进行调价；

                strSQL = @" select c.medicineid_chr,
       c.medicinename_vch,
       b.indrugstoreid_vchr,
       d.medstorename_vchr
  from t_ms_outstorage        a,
       t_ds_instorage         b,
       t_ms_outstorage_detail c,
       t_bse_medstore         d
 where a.outstorageid_vchr = b.outstorageid_vchr
   and b.drugstoreid_chr = d.deptid_chr(+)
   and b.status = 1
   and a.seriesid_int = c.seriesid2_int
   and c.status = 1
   and c.medicineid_chr = ?";
                objDPArr = null;
                dtResult = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedicineid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null)
                {
                    int m_intRowCount = dtResult.Rows.Count;
                    DataRow dr = null;
                    for (int i = 0; i < m_intRowCount; i++)
                    {
                        dr = dtResult.Rows[i];
                        m_strReturnMsg += string.Format("{0}.{1}含有该药品({2})的入库单据({3})尚未进行药房审核,不能进行调价。\r\n\r\n", ++m_intRowNo, dr["medstorename_vchr"].ToString(), dr["medicinename_vch"].ToString(), dr["indrugstoreid_vchr"].ToString());
                    }

                }
                //如果有借调单据出库部门已审核，但入库部门没审核，不允许对这些药品进行调价

                strSQL = @"select c.medicineid_chr,
       c.medicinename_vchr,
       b.indrugstoreid_vchr,
       d.medstorename_vchr
  from t_ds_outstorage        a,
       t_ds_instorage         b,
       t_ds_outstorage_detail c,
       t_bse_medstore         d
 where a.outdrugstoreid_vchr = b.outstorageid_vchr
   and b.drugstoreid_chr = d.deptid_chr(+)
   and b.status = 1
   and a.seriesid_int = c.seriesid2_int
   and c.status = 1
   and c.medicineid_chr = ?";
                objDPArr = null;
                dtResult = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedicineid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtResult != null)
                {
                    int m_intRowCount = dtResult.Rows.Count;
                    DataRow dr = null;
                    for (int i = 0; i < m_intRowCount; i++)
                    {
                        dr = dtResult.Rows[i];
                        m_strReturnMsg += string.Format("{0}.{1}含有该药品({2})的入库单据({3})尚未进行药房审核,不能进行调价。\r\n\r\n", ++m_intRowNo, dr["medstorename_vchr"].ToString(), dr["medicinename_vchr"].ToString(), dr["indrugstoreid_vchr"].ToString());
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

        /// <summary>
        /// 如果单据存在先保存，后手工审核，那么调价的时候必须在出入库业务操作当中不存在新制作的单据，保持数据一致性
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_strReturnMsg"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngJudgeCanAdjustPriceByMedicineID_ALLNewBill(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedicineid, out string m_strReturnMsg)
        {
            m_strReturnMsg = string.Empty; 

            long lngRes = -1;
            int intRows = 0;
            try
            {
                string strSQL = @"select   distinct a.outstorageid_vchr
                                      from t_ms_outstorage a, t_ms_outstorage_detail b
                                     where a.seriesid_int = b.seriesid2_int
                                       and a.status = 1
                                       and b.status = 1
                                       and b.medicineid_chr = ?";
                DataTable dtValue = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strMedicineid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes < 0)
                {
                    return lngRes;
                }
                if(dtValue.Rows.Count > 0)
                {
                    m_strReturnMsg = "药库出库单据号：\r\n";
                    foreach(DataRow dr in dtValue.Rows)
                    {
                        intRows++;
                        if(intRows % 2 == 0)
                        {
                            m_strReturnMsg += dr[0].ToString() + "\r\n";
                        }
                        else
                        {
                            m_strReturnMsg += dr[0].ToString() + "\t";
                        }
                        
                    }
                    if(intRows % 2 != 0)
                    {
                        m_strReturnMsg += "\r\n";
                    }
                }

                strSQL = @"select  distinct a.outdrugstoreid_vchr
                              from t_ds_outstorage a, t_ds_outstorage_detail b
                             where a.seriesid_int = b.seriesid2_int
                               and a.status_int = 1
                               and b.status = 1
                               and b.medicineid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strMedicineid;
                dtValue = null;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes < 0)
                {
                    return lngRes;
                }
                if(dtValue.Rows.Count > 0)
                {
                    intRows = 0;
                    m_strReturnMsg = "药房出库单据号：\r\n";
                    foreach(DataRow dr in dtValue.Rows)
                    {
                        intRows++;
                        if(intRows % 2 == 0)
                        {
                            m_strReturnMsg += dr[0].ToString() + "\r\n";
                        }
                        else
                        {
                            m_strReturnMsg += dr[0].ToString() + "\t";
                        }

                    }
                    if(intRows % 2 != 0)
                    {
                        m_strReturnMsg += "\r\n";
                    }
                }

                strSQL = @"select distinct a.indrugstoreid_vchr
                              from t_ds_instorage a, t_ds_instorage_detail b
                             where a.seriesid_int = b.seriesid2_int
                               and a.status = 1
                               and b.status = 1
                               and b.medicineid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strMedicineid;
                dtValue = null;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes < 0)
                {
                    return lngRes;
                }
                if(dtValue.Rows.Count > 0)
                {
                    intRows = 0;
                    m_strReturnMsg = "药房入库单据号：\r\n";
                    foreach(DataRow dr in dtValue.Rows)
                    {
                        intRows++;
                        if(intRows % 2 == 0)
                        {
                            m_strReturnMsg += dr[0].ToString() + "\r\n";
                        }
                        else
                        {
                            m_strReturnMsg += dr[0].ToString() + "\t";
                        }

                    }
                    if(intRows % 2 != 0)
                    {
                        m_strReturnMsg += "\r\n";
                    }
                }

                strSQL = @"select  distinct a.instorageid_vchr
                              from t_ms_instorage a, t_ms_instorage_detal b
                             where a.seriesid_int = b.seriesid2_int
                               and a.state_int = 1
                               and b.status = 1
                               and b.medicineid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out param);
                param[0].Value = m_strMedicineid;
                dtValue = null;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, param);
                objHRPSvc.Dispose();
                objHRPSvc = null;

                if(lngRes < 0)
                {
                    return lngRes;
                }
                if(dtValue.Rows.Count > 0)
                {
                    intRows = 0;
                    m_strReturnMsg = "药库入库单据号：\r\n";
                    foreach(DataRow dr in dtValue.Rows)
                    {
                        intRows++;
                        if(intRows % 2 == 0)
                        {
                            m_strReturnMsg += dr[0].ToString() + "\r\n";
                        }
                        else
                        {
                            m_strReturnMsg += dr[0].ToString() + "\t";
                        }

                    }
                    if(intRows % 2 != 0)
                    {
                        m_strReturnMsg += "\r\n";
                    }
                }

                dtValue.Dispose();
                dtValue = null;

                m_strReturnMsg = m_strReturnMsg.Trim();
            }
            catch(Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品获取药品的购入价信息
        /// <summary>
        /// 根据药品获取药品的购入价信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strMedicineid">药品id</param>
        /// <param name="m_dblCallInPrice">购入价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineCallInPriceByMedicineid(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedicineid, out double m_dblCallInPrice)
        {
            m_dblCallInPrice = 0d;
            long lngRes = -1;
            try
            {

                string strSQL = @"select a.medicineid_chr,
       decode(b.callprice_int, null, a.tradeprice_mny, b.callprice_int) as callprice_int
  from t_bse_medicine a, t_ms_instorage_detal b, t_ms_instorage c
  where a.medicineid_chr = b.medicineid_chr(+)
  and b.seriesid2_int = c.seriesid_int(+)
  and a.medicineid_chr = ?
  order by c.instoragedate_dat desc";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtResult = new DataTable();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = m_strMedicineid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    m_dblCallInPrice = Convert.ToDouble(dtResult.Rows[0]["callprice_int"]);
                }
                objHRPServ.Dispose();
                objHRPServ = null;
                dtResult.Dispose();
                dtResult = null;
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
