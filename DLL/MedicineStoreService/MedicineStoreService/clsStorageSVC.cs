using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 库存
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsStorageSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 添加库存明细
        /// <summary>
        /// 添加库存明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSDVOArr">库存明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objSDVOArr)
        {
            if (p_objSDVOArr == null || p_objSDVOArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_storage_detail
  (seriesid_int,
   storageid_chr,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   syslotno_chr,
   lotno_vchr,
   retailprice_int,
   callprice_int,
   wholesaleprice_int,
   realgross_int,
   availagross_int,
   opunit_vchr,
   validperiod_dat,
   productorid_chr,
   instorageid_vchr,
   instoragedate_dat,
   vendorid_chr,
   status,
   adjustpriceman_chr,
   adjustpricedate_dat,producedate_dat)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGE_DETAIL", p_objSDVOArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    string strSysLogNo = string.Empty;
                    for (int iRow = 0; iRow < p_objSDVOArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(22, out objLisAddItemRefArr);
                        lngRes = objPublic.m_lngGetStorageDetailNewSysLog(p_objPrincipal, p_objSDVOArr[iRow].m_strMEDICINEID_CHR, out strSysLogNo);
                        //Please change the datetime and reocrdid 
                        objLisAddItemRefArr[0].Value = lngSEQArr[iRow];
                        objLisAddItemRefArr[1].Value = p_objSDVOArr[iRow].m_strSTORAGEID_CHR;
                        objLisAddItemRefArr[2].Value = p_objSDVOArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[3].Value = p_objSDVOArr[iRow].m_strMEDICINENAME_VCHR;
                        objLisAddItemRefArr[4].Value = p_objSDVOArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[5].Value = strSysLogNo;
                        objLisAddItemRefArr[6].Value = p_objSDVOArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[7].Value = p_objSDVOArr[iRow].m_dcmRETAILPRICE_INT;
                        objLisAddItemRefArr[8].Value = p_objSDVOArr[iRow].m_dcmCALLPRICE_INT;
                        objLisAddItemRefArr[9].Value = p_objSDVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[10].Value = p_objSDVOArr[iRow].m_dblREALGROSS_INT;
                        objLisAddItemRefArr[11].Value = p_objSDVOArr[iRow].m_dblAVAILAGROSS_INT;
                        objLisAddItemRefArr[12].Value = p_objSDVOArr[iRow].m_strOPUNIT_VCHR;
                        objLisAddItemRefArr[13].DbType = DbType.DateTime;
                        objLisAddItemRefArr[13].Value = p_objSDVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[14].Value = p_objSDVOArr[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[15].Value = p_objSDVOArr[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[16].DbType = DbType.DateTime;
                        objLisAddItemRefArr[16].Value = p_objSDVOArr[iRow].m_dtmINSTORAGEDATE_DAT;
                        objLisAddItemRefArr[17].Value = p_objSDVOArr[iRow].m_strVENDORID_CHR;
                        objLisAddItemRefArr[18].Value = p_objSDVOArr[iRow].m_intStatus;
                        objLisAddItemRefArr[19].Value = p_objSDVOArr[iRow].m_strAdjustManID;
                        if (p_objSDVOArr[iRow].m_dtmAdjustPriceDate == DateTime.MinValue)
                        {
                            objLisAddItemRefArr[20].Value = DBNull.Value;
                        }
                        else
                        {
                            objLisAddItemRefArr[20].DbType = DbType.DateTime;
                            objLisAddItemRefArr[20].Value = p_objSDVOArr[iRow].m_dtmAdjustPriceDate;
                        }
                        if (p_objSDVOArr[iRow].m_dtmPRODUCEDATE_DAT == DateTime.MinValue)
                        {
                            objLisAddItemRefArr[21].Value = DBNull.Value;
                        }
                        else
                        {
                            objLisAddItemRefArr[21].DbType = DbType.DateTime;
                            objLisAddItemRefArr[21].Value = p_objSDVOArr[iRow].m_dtmPRODUCEDATE_DAT;
                        }
                        
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,
                        DbType.String,DbType.String,DbType.DateTime,DbType.String, DbType.Int32, DbType.String, DbType.DateTime,DbType.DateTime};

                    object[][] objValues = new object[22][];

                    int intItemCount = p_objSDVOArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGE_DETAIL", p_objSDVOArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    string strSysLogNo = string.Empty;
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        lngRes = objPublic.m_lngGetStorageDetailNewSysLog(p_objPrincipal, p_objSDVOArr[iRow].m_strMEDICINEID_CHR, out strSysLogNo);

                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objSDVOArr[iRow].m_strSTORAGEID_CHR;
                        objValues[2][iRow] = p_objSDVOArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objSDVOArr[iRow].m_strMEDICINENAME_VCHR;
                        objValues[4][iRow] = p_objSDVOArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = strSysLogNo;
                        objValues[6][iRow] = p_objSDVOArr[iRow].m_strLOTNO_VCHR;
                        objValues[7][iRow] = p_objSDVOArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[8][iRow] = p_objSDVOArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[9][iRow] = p_objSDVOArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[10][iRow] = p_objSDVOArr[iRow].m_dblREALGROSS_INT;
                        objValues[11][iRow] = p_objSDVOArr[iRow].m_dblAVAILAGROSS_INT;
                        objValues[12][iRow] = p_objSDVOArr[iRow].m_strOPUNIT_VCHR;
                        objValues[13][iRow] = p_objSDVOArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[14][iRow] = p_objSDVOArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[15][iRow] = p_objSDVOArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[16][iRow] = p_objSDVOArr[iRow].m_dtmINSTORAGEDATE_DAT;
                        objValues[17][iRow] = p_objSDVOArr[iRow].m_strVENDORID_CHR;
                        objValues[18][iRow] = p_objSDVOArr[iRow].m_intStatus;
                        objValues[19][iRow] = p_objSDVOArr[iRow].m_strAdjustManID;
                        if (p_objSDVOArr[iRow].m_dtmAdjustPriceDate == DateTime.MinValue)
                        {
                            objValues[20][iRow] = DBNull.Value;
                        }
                        else
                        {
                            objValues[20][iRow] = p_objSDVOArr[iRow].m_dtmAdjustPriceDate;
                        }
                        if (p_objSDVOArr[iRow].m_dtmPRODUCEDATE_DAT == DateTime.MinValue)
                        {
                            objValues[21][iRow] = DBNull.Value;
                        }
                        else
                        {
                            objValues[21][iRow] = p_objSDVOArr[iRow].m_dtmPRODUCEDATE_DAT;
                        }
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 添加库存主表
        /// <summary>
        /// 添加库存主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSDVOArr">库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Storage[] p_objSDVOArr)
        {
            if (p_objSDVOArr == null || p_objSDVOArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_storage
  (seriesid_int,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   opunit_vchr,
   instoregross_int,
   currentgross_num,
   maximum_int,
   minimum_int,
   vendorid_chr,
   callprice_int,
   avgcallprice_int,
   maxcallprice_int,
   mincallprice_int,
   storageid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGE", p_objSDVOArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objSDVOArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(15, out objLisAddItemRefArr);
                        //Please change the datetime and reocrdid 
                        objLisAddItemRefArr[0].Value = lngSEQArr[iRow];
                        objLisAddItemRefArr[1].Value = p_objSDVOArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[2].Value = p_objSDVOArr[iRow].m_strMEDICINENAME_VCHR;
                        objLisAddItemRefArr[3].Value = p_objSDVOArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[4].Value = p_objSDVOArr[iRow].m_strOPUNIT_VCHR;
                        objLisAddItemRefArr[5].Value = p_objSDVOArr[iRow].m_dblINSTOREGROSS_INT;
                        objLisAddItemRefArr[6].Value = p_objSDVOArr[iRow].m_dblCURRENTGROSS_NUM;
                        objLisAddItemRefArr[7].Value = p_objSDVOArr[iRow].m_dblMAXIMUM_INT;
                        objLisAddItemRefArr[8].Value = p_objSDVOArr[iRow].m_dblMINIMUM_INT;
                        objLisAddItemRefArr[9].Value = p_objSDVOArr[iRow].m_strVENDORID_CHR;
                        objLisAddItemRefArr[10].Value = p_objSDVOArr[iRow].m_dcmCALLPRICE_INT;
                        objLisAddItemRefArr[11].Value = p_objSDVOArr[iRow].m_dcmAVGCALLPRICE_INT;
                        objLisAddItemRefArr[12].Value = p_objSDVOArr[iRow].m_dcmMAXCALLPRICE_INT;
                        objLisAddItemRefArr[13].Value = p_objSDVOArr[iRow].m_dcmMINCALLPRICE_INT;
                        objLisAddItemRefArr[14].Value = p_objSDVOArr[iRow].m_strSTORAGEID_CHR;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String};

                    object[][] objValues = new object[15][];

                    int intItemCount = p_objSDVOArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGE", p_objSDVOArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objSDVOArr[iRow].m_strMEDICINEID_CHR;
                        objValues[2][iRow] = p_objSDVOArr[iRow].m_strMEDICINENAME_VCHR;
                        objValues[3][iRow] = p_objSDVOArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[4][iRow] = p_objSDVOArr[iRow].m_strOPUNIT_VCHR;
                        objValues[5][iRow] = p_objSDVOArr[iRow].m_dblINSTOREGROSS_INT;
                        objValues[6][iRow] = p_objSDVOArr[iRow].m_dblCURRENTGROSS_NUM;
                        objValues[7][iRow] = p_objSDVOArr[iRow].m_dblMAXIMUM_INT;
                        objValues[8][iRow] = p_objSDVOArr[iRow].m_dblMINIMUM_INT;
                        objValues[9][iRow] = p_objSDVOArr[iRow].m_strVENDORID_CHR;
                        objValues[10][iRow] = p_objSDVOArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[11][iRow] = p_objSDVOArr[iRow].m_dcmAVGCALLPRICE_INT;
                        objValues[12][iRow] = p_objSDVOArr[iRow].m_dcmMAXCALLPRICE_INT;
                        objValues[13][iRow] = p_objSDVOArr[iRow].m_dcmMINCALLPRICE_INT;
                        objValues[14][iRow] = p_objSDVOArr[iRow].m_strSTORAGEID_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// 添加库存主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSDVO">库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewStorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_Storage p_objSDVO)
        {
            if (p_objSDVO == null )
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_storage
  (seriesid_int,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   opunit_vchr,
   instoregross_int,
   currentgross_num,
   maximum_int,
   minimum_int,
   vendorid_chr,
   callprice_int,
   avgcallprice_int,
   maxcallprice_int,
   mincallprice_int,
   storageid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                IDataParameter[] objLisAddItemRefArr = null;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_STORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }

                objHRPServ.CreateDatabaseParameter(15, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                p_objSDVO.m_lngSERIESID_INT = lngSEQ;
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objSDVO.m_strMEDICINEID_CHR;
                objLisAddItemRefArr[2].Value = p_objSDVO.m_strMEDICINENAME_VCHR;
                objLisAddItemRefArr[3].Value = p_objSDVO.m_strMEDSPEC_VCHR;
                objLisAddItemRefArr[4].Value = p_objSDVO.m_strOPUNIT_VCHR;
                objLisAddItemRefArr[5].Value = p_objSDVO.m_dblINSTOREGROSS_INT;
                objLisAddItemRefArr[6].Value = p_objSDVO.m_dblCURRENTGROSS_NUM;
                objLisAddItemRefArr[7].Value = p_objSDVO.m_dblMAXIMUM_INT;
                objLisAddItemRefArr[8].Value = p_objSDVO.m_dblMINIMUM_INT;
                objLisAddItemRefArr[9].Value = p_objSDVO.m_strVENDORID_CHR;
                objLisAddItemRefArr[10].Value = p_objSDVO.m_dcmCALLPRICE_INT;
                objLisAddItemRefArr[11].Value = p_objSDVO.m_dcmAVGCALLPRICE_INT;
                objLisAddItemRefArr[12].Value = p_objSDVO.m_dcmMAXCALLPRICE_INT;
                objLisAddItemRefArr[13].Value = p_objSDVO.m_dcmMINCALLPRICE_INT;
                objLisAddItemRefArr[14].Value = p_objSDVO.m_strSTORAGEID_CHR;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 检查库存主表是否已存在该药
        /// <summary>
        /// 检查库存主表是否已存在该药
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID,string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
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
                string strSQL = @"select seriesid_int from t_ms_storage where medicineid_chr = ? and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

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

        #region 修改库存主表信息
        /// <summary>
        /// 库存主表添加库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageFromInitial(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            if (p_objRecord == null || p_lngSEQ <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set instoregross_int = instoregross_int + ?,
       currentgross_num = currentgross_num + ?,
       vendorid_chr = ?,
       callprice_int = ?
 where seriesid_int = ?
  and instoregross_int + ? >= 0
  and currentgross_num + ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[1].Value = p_objRecord.m_dblCURRENTGROSS_NUM;
                objDPArr[2].Value = p_objRecord.m_strVENDORID_CHR;
                objDPArr[3].Value = p_objRecord.m_dcmCALLPRICE_INT;
                objDPArr[4].Value = p_lngSEQ;
                objDPArr[5].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[6].Value = p_objRecord.m_dblCURRENTGROSS_NUM;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 库存主表增加库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Storage p_objRecord)
        {
            if (p_objRecord == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set instoregross_int = instoregross_int + ?,
       currentgross_num = currentgross_num + ?,
       vendorid_chr     = ?,
       callprice_int    = ?
 where medicineid_chr = ?
   and storageid_chr = ?
   and instoregross_int + ? >= 0
   and currentgross_num + ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[1].Value = p_objRecord.m_dblCURRENTGROSS_NUM;
                objDPArr[2].Value = p_objRecord.m_strVENDORID_CHR;
                objDPArr[3].Value = p_objRecord.m_dcmCALLPRICE_INT;
                objDPArr[4].Value = p_objRecord.m_strMEDICINEID_CHR;
                objDPArr[5].Value = p_objRecord.m_strSTORAGEID_CHR;
                objDPArr[6].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[7].Value = p_objRecord.m_dblCURRENTGROSS_NUM;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 库存主表添加当前库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut p_objRecord)
        {
            if (p_objRecord == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set currentgross_num = currentgross_num + ?
 where medicineid_chr = ?
   and storageid_chr = ?
   and currentgross_num + ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblGross;
                objDPArr[1].Value = p_objRecord.m_strMedicineID;
                objDPArr[2].Value = p_objRecord.m_strStorageID;
                objDPArr[3].Value = p_objRecord.m_dblGross;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 退审后更新库存信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageFromUnCommit(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            if (p_objRecord == null || p_lngSEQ <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set instoregross_int = instoregross_int - ?,
       currentgross_num = currentgross_num - ?,
       vendorid_chr     = ?,
       callprice_int    = ?
 where seriesid_int = ?
   and instoregross_int - ? >= 0
   and currentgross_num - ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[1].Value = p_objRecord.m_dblCURRENTGROSS_NUM;
                objDPArr[2].Value = p_objRecord.m_strVENDORID_CHR;
                objDPArr[3].Value = p_objRecord.m_dcmCALLPRICE_INT;
                objDPArr[4].Value = p_lngSEQ;
                objDPArr[5].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[6].Value = p_objRecord.m_dblCURRENTGROSS_NUM;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 库存主表减少库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Storage p_objRecord)
        {
            if (p_objRecord == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set instoregross_int = instoregross_int - ?,
       currentgross_num = currentgross_num - ?,
       vendorid_chr     = ?,
       callprice_int    = ?
 where medicineid_chr = ?
   and storageid_chr = ?
   and instoregross_int - ? >= 0
   and currentgross_num - ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[1].Value = p_objRecord.m_dblCURRENTGROSS_NUM;
                objDPArr[2].Value = p_objRecord.m_strVENDORID_CHR;
                objDPArr[3].Value = p_objRecord.m_dcmCALLPRICE_INT;
                objDPArr[4].Value = p_objRecord.m_strMEDICINEID_CHR;
                objDPArr[5].Value = p_objRecord.m_strSTORAGEID_CHR;
                objDPArr[6].Value = p_objRecord.m_dblINSTOREGROSS_INT;
                objDPArr[7].Value = p_objRecord.m_dblCURRENTGROSS_NUM;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 库存主表减少当前库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut p_objRecord)
        {
            if (p_objRecord == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage
   set currentgross_num = currentgross_num - ?
 where medicineid_chr = ?
   and storageid_chr = ?
   and currentgross_num - ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_objRecord.m_dblGross;
                objDPArr[1].Value = p_objRecord.m_strMedicineID;
                objDPArr[2].Value = p_objRecord.m_strStorageID;
                objDPArr[3].Value = p_objRecord.m_dblGross;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 统计库存
        /// <summary>
        /// 统计库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngStatisticsStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strMedicineID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select callprice_int
  from t_ms_storage_detail
 where medicineid_chr = ? and storageid_chr = ? and status = 1";

                string strMaxP = string.Empty;
                string strMinP = string.Empty;
                string strAvgP = string.Empty;

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes < 0)
                {
                    return -1;
                }

                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        DataRow drTemp = dtbValue.Rows[0];
                        double dblPrice = Convert.ToDouble(drTemp["callprice_int"]);//临时变量

                        double dblMin = dblPrice;//最大值

                        double dblMax = dblPrice;//最小值

                        double dblAll = dblPrice;//总和
                        for (int iRow = 1; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbValue.Rows[iRow];
                            if (double.TryParse(drTemp["callprice_int"].ToString(), out dblPrice))
                            {
                                if (dblPrice > dblMax)
                                {
                                    dblMax = dblPrice;
                                }
                                if (dblPrice < dblMin)
                                {
                                    dblMin = dblPrice;
                                }
                                dblAll += dblPrice;
                            }
                        }
                        strMaxP = dblMax.ToString("0.0000");
                        strMinP = dblMin.ToString("0.0000");
                        strAvgP = (dblAll / intRowsCount).ToString("0.0000");

                        strSQL = @"update t_ms_storage
   set avgcallprice_int = ?, maxcallprice_int = ?, mincallprice_int = ?
 where medicineid_chr = ? and storageid_chr = ?";

                        objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                        objDPArr[0].Value = strAvgP;
                        objDPArr[1].Value = strMaxP;
                        objDPArr[2].Value = strMinP;
                        objDPArr[3].Value = p_strMedicineID;
                        objDPArr[4].Value = p_strStorageID;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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

        #region 删除指定入库单号的库存明细

        /// <summary>
        /// 删除指定入库单号的库存明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <param name="p_dtmInStorageDate">入库日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInStorageID, DateTime p_dtmInStorageDate)
        {
            if (p_strInStorageID == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_storage_detail set status = 0
 where instorageid_vchr = ? and instoragedate_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmInStorageDate;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 删除指定入库单号的库存明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageArr">入库单号</param>
        ///<param name=" storageid_chr">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strInStorageArr,string storageid_chr)
        {
            if (p_strInStorageArr == null || p_strInStorageArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_storage_detail set status = 0
 where instorageid_vchr = ? and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int iArr = 0; iArr < p_strInStorageArr.Length; iArr++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strInStorageArr[0];
                        objDPArr[1].Value = storageid_chr;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_strInStorageArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strInStorageArr[iRow];
                        objValues[1][iRow] = storageid_chr;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// 删除指定序列号的库存明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQArr)
        {
            if (p_lngSEQArr == null || p_lngSEQArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_storage_detail set status = 0
 where seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;

                    for (int iArr = 0; iArr < p_lngSEQArr.Length; iArr++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngSEQArr[0];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64};

                     object[][] objValues = new object[1][];

                     int intItemCount = p_lngSEQArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngSEQArr[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 删除指定序列号的库存明细
        /// <summary>
        /// 删除指定序列号的库存明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">入库序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_storage_detail set status = 0
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据药品信息获取库存明细序列号

        /// <summary>
        /// 根据药品信息获取库存明细序列号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngSEQ">库存明细序列号</param>
        /// <param name="p_dblRealgross">实际库存</param>
        /// <param name="p_dblAvailagross">可用库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDetailSEQByIndex(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInStorageID, string p_strMedicineID,string p_strLotNO, DateTime p_dtmValidDate, double p_dblInPrice ,string p_strStorageID, 
            out long p_lngSEQ,out double p_dblRealgross, out double p_dblAvailagross)
        {
            p_lngSEQ = 0;
            p_dblRealgross = 0d;
            p_dblAvailagross = 0d;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int, t.realgross_int, t.availagross_int
  from t_ms_storage_detail t
 where t.instorageid_vchr = ?
   and t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.storageid_chr = ?
   and t.validperiod_dat = ?
   and t.callprice_int = ?
   and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotNO;
                objDPArr[3].Value = p_strStorageID;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_dtmValidDate;
                objDPArr[5].Value = p_dblInPrice;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_lngSEQ = Convert.ToInt64(dtbValue.Rows[0]["seriesid_int"]);
                        p_dblRealgross = Convert.ToDouble(dtbValue.Rows[0]["realgross_int"]);
                        p_dblAvailagross = Convert.ToDouble(dtbValue.Rows[0]["availagross_int"]);
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
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out clsMS_StorageDetail[] p_objDetailArr)
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
       c.vendorname_vchr,b.packqty_dec,b.ipunit_chr,a.producedate_dat 
  from t_ms_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr
 where a.medicineid_chr = ?
   and a.storageid_chr = ?
   and a.status = 1 and a.realgross_int > 0
 order by a.validperiod_dat,a.lotno_vchr,a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        DateTime datTemp;
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
                            p_objDetailArr[iRow].m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"].ToString());
                            p_objDetailArr[iRow].m_strMEDICINETYPEID_CHR = drTemp["MEDICINETYPEID_CHR"].ToString();
                            p_objDetailArr[iRow].m_dblPackQty = Convert.ToDouble(drTemp["packqty_dec"]);
                            p_objDetailArr[iRow].m_strIPUnit = drTemp["ipunit_chr"].ToString();
                            if (DateTime.TryParse(drTemp["producedate_dat"].ToString(), out datTemp))
                            {
                                p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                            }
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

        #region 添加库存明细表库存数量

        /// <summary>
        /// 添加库存明细表库存数量

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dblRealGross">实际库存</param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, double p_dblRealGross,double p_dblAvailaGross, long p_lngSEQ)
        {
            if (p_lngSEQ <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int   = realgross_int + ?,
       availagross_int = availagross_int + ?
 where seriesid_int = ?
   and realgross_int + ? >= 0
   and availagross_int + ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_dblRealGross;
                objDPArr[1].Value = p_dblAvailaGross;
                objDPArr[2].Value = p_lngSEQ;
                objDPArr[3].Value = p_dblRealGross;
                objDPArr[4].Value = p_dblAvailaGross;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 添加库存明细表库存数量(出库删除未审核记录时只添加可用库存)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO,
            string p_strInStorageID, DateTime p_dtmValidDate, double p_dblInPrice,string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set availagross_int = availagross_int + ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and callprice_int = ?
   and validperiod_dat = ?
   and availagross_int + ? >= 0
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_dblAvailaGross;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotNO;
                objDPArr[3].Value = p_strInStorageID;
                objDPArr[4].Value = p_strStorageID;
                objDPArr[5].Value = p_dblInPrice;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_dtmValidDate;
                objDPArr[7].Value = p_dblAvailaGross;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 添加库存明细表库存数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">更改库存VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailRealGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objDetailArr)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int = realgross_int + ?,
       availagross_int = availagross_int + ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and callprice_int = ?
   and validperiod_dat = ?
   and realgross_int + ? >= 0
   and availagross_int + ? >= 0
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(10, out objDPArr);
                        objDPArr[0].Value = p_objDetailArr[iRow].m_dblREALGROSS_INT;
                        objDPArr[1].Value = p_objDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objDPArr[2].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objDPArr[3].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objDPArr[4].Value = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objDPArr[5].Value = p_objDetailArr[iRow].m_strSTORAGEID_CHR;
                        objDPArr[6].Value = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objDPArr[7].DbType = DbType.DateTime;
                        objDPArr[7].Value = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objDPArr[8].Value = p_objDetailArr[iRow].m_dblREALGROSS_INT;
                        objDPArr[9].Value = p_objDetailArr[iRow].m_dblAVAILAGROSS_INT;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime, DbType.Double, DbType.Double };

                    object[][] objValues = new object[10][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetailArr[iRow].m_dblREALGROSS_INT;
                        objValues[1][iRow] = p_objDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_strSTORAGEID_CHR;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[8][iRow] = p_objDetailArr[iRow].m_dblREALGROSS_INT;
                        objValues[9][iRow] = p_objDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// 添加库存明细表库存数量(实际库存)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOutArr">更改库存VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailRealGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objOutArr)
        {
            if (p_objOutArr == null || p_objOutArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int = realgross_int + ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and callprice_int = ?
   and validperiod_dat = ?
   and realgross_int + ? >= 0
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objOutArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                        objDPArr[0].Value = p_objOutArr[iRow].m_dblGross;
                        objDPArr[1].Value = p_objOutArr[iRow].m_strMedicineID;
                        objDPArr[2].Value = p_objOutArr[iRow].m_strLotNO;
                        objDPArr[3].Value = p_objOutArr[iRow].m_strInStorageID;
                        objDPArr[4].Value = p_objOutArr[iRow].m_strStorageID;
                        objDPArr[5].Value = p_objOutArr[iRow].m_dblInPrice;
                        objDPArr[6].DbType = DbType.DateTime;
                        objDPArr[6].Value = p_objOutArr[iRow].m_dtmValidDate;
                        objDPArr[7].Value = p_objOutArr[iRow].m_dblGross;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime , DbType.Double };

                    object[][] objValues = new object[8][];

                    int intItemCount = p_objOutArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objOutArr[iRow].m_dblGross;
                        objValues[1][iRow] = p_objOutArr[iRow].m_strMedicineID;
                        objValues[2][iRow] = p_objOutArr[iRow].m_strLotNO;
                        objValues[3][iRow] = p_objOutArr[iRow].m_strInStorageID;
                        objValues[4][iRow] = p_objOutArr[iRow].m_strStorageID;
                        objValues[5][iRow] = p_objOutArr[iRow].m_dblInPrice;
                        objValues[6][iRow] = p_objOutArr[iRow].m_dtmValidDate;
                        objValues[7][iRow] = p_objOutArr[iRow].m_dblGross;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// 添加库存明细表库存数量(可用库存)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOutArr">更改库存VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objOutArr)
        {
            if (p_objOutArr == null || p_objOutArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set availagross_int = availagross_int + ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and callprice_int = ?
   and validperiod_dat = ?
   and availagross_int + ? > 0
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objOutArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                        objDPArr[0].Value = p_objOutArr[iRow].m_dblGross;
                        objDPArr[1].Value = p_objOutArr[iRow].m_strMedicineID;
                        objDPArr[2].Value = p_objOutArr[iRow].m_strLotNO;
                        objDPArr[3].Value = p_objOutArr[iRow].m_strInStorageID;
                        objDPArr[4].Value = p_objOutArr[iRow].m_strStorageID;
                        objDPArr[5].Value = p_objOutArr[iRow].m_dblInPrice;
                        objDPArr[6].DbType = DbType.DateTime;
                        objDPArr[6].Value = p_objOutArr[iRow].m_dtmValidDate;
                        objDPArr[7].Value = p_objOutArr[iRow].m_dblGross;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                        if (lngRes <= 0)
                        {
                            throw new Exception("更新可用库存失败");
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime, DbType.Double };

                    object[][] objValues = new object[8][];

                    int intItemCount = p_objOutArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objOutArr[iRow].m_dblGross;
                        objValues[1][iRow] = p_objOutArr[iRow].m_strMedicineID;
                        objValues[2][iRow] = p_objOutArr[iRow].m_strLotNO;
                        objValues[3][iRow] = p_objOutArr[iRow].m_strInStorageID;
                        objValues[4][iRow] = p_objOutArr[iRow].m_strStorageID;
                        objValues[5][iRow] = p_objOutArr[iRow].m_dblInPrice;
                        objValues[6][iRow] = p_objOutArr[iRow].m_dtmValidDate;
                        objValues[7][iRow] = p_objOutArr[iRow].m_dblGross;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues,ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        throw (new System.Exception("更新可用库存失败"));
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

        #region 减少库存明细表库存数量

        /// <summary>
        /// 减少库存明细表库存数量

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dblRealGross">实际库存</param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, double p_dblRealGross, double p_dblAvailaGross, long p_lngSEQ)
        {
            if (p_lngSEQ <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int   = realgross_int - ?,
       availagross_int = availagross_int - ?
 where seriesid_int = ?
   and status = 1
   and realgross_int - ? >= 0
   and availagross_int - ? >= 0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_dblRealGross;
                objDPArr[1].Value = p_dblAvailaGross;
                objDPArr[2].Value = p_lngSEQ;
                objDPArr[3].Value = p_dblRealGross;
                objDPArr[4].Value = p_dblAvailaGross;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 减少库存明细表库存数量

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objDetail)
        {
            if (p_objDetail == null || p_objDetail.Length <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int   = realgross_int - ?,
       availagross_int = availagross_int - ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and status = 1
   and realgross_int - ? >= 0
   and availagross_int - ? >= 0
   and callprice_int = ?
   and validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objDetail.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(10, out objDPArr);
                        objDPArr[0].Value = p_objDetail[iRow].m_dblREALGROSS_INT;
                        objDPArr[1].Value = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objDPArr[2].Value = p_objDetail[iRow].m_strMEDICINEID_CHR;
                        objDPArr[3].Value = p_objDetail[iRow].m_strLOTNO_VCHR;
                        objDPArr[4].Value = p_objDetail[iRow].m_strINSTORAGEID_VCHR;
                        objDPArr[5].Value = p_objDetail[iRow].m_strSTORAGEID_CHR;
                        objDPArr[6].Value = p_objDetail[iRow].m_dblREALGROSS_INT;
                        objDPArr[7].Value = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objDPArr[8].Value = p_objDetail[iRow].m_dcmCALLPRICE_INT;
                        objDPArr[9].DbType = DbType.DateTime;
                        objDPArr[9].Value = p_objDetail[iRow].m_dtmVALIDPERIOD_DAT;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }                    
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, DbType.Double, DbType.DateTime };

                    object[][] objValues = new object[10][];

                    int intItemCount = 0;
                    for(int i1 = 0; i1 < p_objDetail.Length; i1++)
                    {
                        if(p_objDetail[i1].m_dblREALGROSS_INT != 0)
                            intItemCount++;
                    }
                    if(intItemCount == 0)//全部为0的情况
                    {
                        return 1;
                    }
                    clsMS_StorageDetail[] objTemp = new clsMS_StorageDetail[intItemCount];
                    int intIndex = 0;
                    for(int i2 = 0; i2 < p_objDetail.Length; i2++)
                    {
                        if(p_objDetail[i2].m_dblREALGROSS_INT != 0)
                        {
                            objTemp[intIndex] = p_objDetail[i2];
                            intIndex++;
                        }
                    }
                    for(int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = objTemp[iRow].m_dblREALGROSS_INT;
                        objValues[1][iRow] = objTemp[iRow].m_dblAVAILAGROSS_INT;
                        objValues[2][iRow] = objTemp[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = objTemp[iRow].m_strLOTNO_VCHR;
                        objValues[4][iRow] = objTemp[iRow].m_strINSTORAGEID_VCHR;
                        objValues[5][iRow] = objTemp[iRow].m_strSTORAGEID_CHR;
                        objValues[6][iRow] = objTemp[iRow].m_dblREALGROSS_INT;
                        objValues[7][iRow] = objTemp[iRow].m_dblAVAILAGROSS_INT;
                        objValues[8][iRow] = objTemp[iRow].m_dcmCALLPRICE_INT;
                        objValues[9][iRow] = objTemp[iRow].m_dtmVALIDPERIOD_DAT;
                    }

                    long lngEff = -1;
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff,dbTypes);
                    if (lngEff < intItemCount)
                    {
                        //广医3院导数据后，instorageid_vchr默认为null值，导致出错，可考虑判断是否为空，为空则不作为条件
                        //20080111 by shaowei.zheng
                        throw (new System.Exception());
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
        /// 减少库存明细表库存数量(保存出库时只对可用库存作修改)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存明细表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageDetailAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objDetail)
        {
            if (p_objDetail == null || p_objDetail.Length <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set availagross_int = availagross_int - ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and status = 1
   and availagross_int - ? >= 0
   and callprice_int = ?
   and validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objDetail.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                        objDPArr[0].Value = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objDPArr[1].Value = p_objDetail[iRow].m_strMEDICINEID_CHR;
                        objDPArr[2].Value = p_objDetail[iRow].m_strLOTNO_VCHR;
                        objDPArr[3].Value = p_objDetail[iRow].m_strINSTORAGEID_VCHR;
                        objDPArr[4].Value = p_objDetail[iRow].m_strSTORAGEID_CHR;
                        objDPArr[5].Value = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objDPArr[6].Value = p_objDetail[iRow].m_dcmCALLPRICE_INT;
                        objDPArr[7].DbType = DbType.DateTime;
                        objDPArr[7].Value = p_objDetail[iRow].m_dtmVALIDPERIOD_DAT;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, DbType.DateTime};

                    object[][] objValues = new object[8][];

                    int intItemCount = p_objDetail.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objValues[1][iRow] = p_objDetail[iRow].m_strMEDICINEID_CHR;
                        objValues[2][iRow] = p_objDetail[iRow].m_strLOTNO_VCHR;
                        objValues[3][iRow] = p_objDetail[iRow].m_strINSTORAGEID_VCHR;
                        objValues[4][iRow] = p_objDetail[iRow].m_strSTORAGEID_CHR;
                        objValues[5][iRow] = p_objDetail[iRow].m_dblAVAILAGROSS_INT;
                        objValues[6][iRow] = p_objDetail[iRow].m_dcmCALLPRICE_INT;
                        objValues[7][iRow] = p_objDetail[iRow].m_dtmVALIDPERIOD_DAT;
                    }
                    long lngEff = -1;
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff,dbTypes);
                    if (lngEff < intItemCount)
                    {
                        throw new Exception("出库数量大于可用库存");
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
        /// 减少库存明细表库存数量

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dblInPrice">购入单价</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageDetailAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO,
            string p_strInStorageID, double p_dblInPrice, DateTime p_dtmValidDate, string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set availagross_int = availagross_int - ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and status = 1
   and availagross_int - ? >= 0
   and callprice_int = ?
   and validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_dblAvailaGross;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotNO;
                objDPArr[3].Value = p_strInStorageID;
                objDPArr[4].Value = p_strStorageID;
                objDPArr[5].Value = p_dblAvailaGross;
                objDPArr[6].Value = p_dblInPrice;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[7].Value = p_dtmValidDate;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 减少库存明细表库存数量(出库审核)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubStorageDetailRealGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objDetail)
        {
            if (p_objDetail == null || p_objDetail.Length <= 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail
   set realgross_int = realgross_int - ?
 where medicineid_chr = ?
   and lotno_vchr = ?
   and instorageid_vchr = ?
   and storageid_chr = ?
   and status = 1
   and realgross_int - ? >= 0
   and callprice_int = ?
   and validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1; 

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objDetail.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                        objDPArr[0].Value = p_objDetail[iRow].m_dblGross;
                        objDPArr[1].Value = p_objDetail[iRow].m_strMedicineID;
                        objDPArr[2].Value = p_objDetail[iRow].m_strLotNO;
                        objDPArr[3].Value = p_objDetail[iRow].m_strInStorageID;
                        objDPArr[4].Value = p_objDetail[iRow].m_strStorageID;
                        objDPArr[5].Value = p_objDetail[iRow].m_dblGross;
                        objDPArr[6].Value = p_objDetail[iRow].m_dblInPrice;
                        objDPArr[7].DbType = DbType.DateTime;
                        objDPArr[7].Value = p_objDetail[iRow].m_dtmValidDate;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                        if (lngRes == 0)
                        {
                            throw (new System.Exception());
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, DbType.DateTime };

                    object[][] objValues = new object[8][];

                    int intItemCount = p_objDetail.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetail[iRow].m_dblGross;
                        objValues[1][iRow] = p_objDetail[iRow].m_strMedicineID;
                        objValues[2][iRow] = p_objDetail[iRow].m_strLotNO;
                        objValues[3][iRow] = p_objDetail[iRow].m_strInStorageID;
                        objValues[4][iRow] = p_objDetail[iRow].m_strStorageID;
                        objValues[5][iRow] = p_objDetail[iRow].m_dblGross;
                        objValues[6][iRow] = p_objDetail[iRow].m_dblInPrice;
                        objValues[7][iRow] = p_objDetail[iRow].m_dtmValidDate;
                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        throw (new System.Exception("出库数量超过实际库存量"));
                    }
                }

                if (lngRes == 0)
                {
                    throw(new System.Exception("出库数量超过实际库存量"));
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

        /// <summary>
        /// 获取指定药品可用库存总量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dblGross">可用库存总量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAvailaGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            p_dblGross = 0d;

            long lngRes = 0;
            try
            {
                string strSQL = @"select availagross_int
  from t_ms_storage_detail
 where storageid_chr = ?
   and medicineid_chr = ?
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;

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
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #region 检查入库后是否对该批药品作其它操作，如出库，外退，内退
        /// <summary>
        /// 检查入库后是否对该批药品作其它操作，如出库，外退，内退
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnHasDone">是否有做其它操作</param>
        /// <param name="p_strID">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasDoneAfterInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInStorageID, out bool p_blnHasDone, out string p_strID)
        {
            p_blnHasDone = false;
            p_strID = string.Empty;
            long lngRes = 0;

            try
            {
                string strOutSQL = @"select b.outstorageid_vchr
  from t_ms_outstorage_detail a, t_ms_outstorage b
 where a.instorageid_vchr = ?
   and a.status = 1
   and b.status <> 0
   and a.seriesid2_int = b.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strOutSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDone = true;
                    p_strID = dtbValue.Rows[0][0].ToString();
                    return 1;
                }

                string strInSQL = @"select b.instorageid_vchr
  from t_ms_instorage_detal a, t_ms_instorage b
 where a.seriesid2_int = b.seriesid_int
   and b.formtype_int <> 1
   and a.status = 1
   and b.state_int <> 0
   and a.instorageid_vchr = ?";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strInSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDone = true;
                    p_strID = dtbValue.Rows[0][0].ToString();
                }

                strInSQL = @"select b.indrugstoreid_vchr
  from t_ds_instorage_detail a
  left join t_ds_instorage b on b.seriesid_int = a.seriesid2_int
 where a.instoreid_vchr = ?
   and a.status = 1
   and b.status > 0";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strInSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDone = true;
                    p_strID = dtbValue.Rows[0][0].ToString();
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
        /// 检查入库后是否对该批药品作出库操作
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnHasDone">是否有作出库操作</param>
        /// <param name="p_strID">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasOutAfterInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strInStorageID, out bool p_blnHasDone, out string p_strID)
        {
            p_blnHasDone = false;
            p_strID = string.Empty;
            long lngRes = 0;

            try
            {
                string strOutSQL = @"select b.outstorageid_vchr
  from t_ms_outstorage_detail a, t_ms_outstorage b
 where a.instorageid_vchr = ?
   and a.status = 1
   and b.status <> 0
   and a.seriesid2_int = b.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strInStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strOutSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDone = true;
                    p_strID = dtbValue.Rows[0][0].ToString();
                    return 1;
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

        #region 更新库存主表当前库存
        /// <summary>
        /// 更新库存主表当前库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">药品信息(因是批量更新，故此数组不能有同一仓库同一药品有多条记录的情况)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageCurrentGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objDetail)
        {
            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_storage
   set currentgross_num = (select sum(d.realgross_int)
                             from t_ms_storage_detail d
                            where d.medicineid_chr = ?
                              and d.storageid_chr = ?
                              and d.status = 1)
 where medicineid_chr = ?
   and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objDetail.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_objDetail[iRow].m_strMedicineID;
                        objDPArr[1].Value = p_objDetail[iRow].m_strStorageID;
                        objDPArr[2].Value = p_objDetail[iRow].m_strMedicineID;
                        objDPArr[3].Value = p_objDetail[iRow].m_strStorageID;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }                    
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.String,DbType.String};

                    object[][] objValues = new object[4][];

                    int intItemCount = p_objDetail.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetail[iRow].m_strMedicineID;
                        objValues[1][iRow] = p_objDetail[iRow].m_strStorageID;
                        objValues[2][iRow] = p_objDetail[iRow].m_strMedicineID;
                        objValues[3][iRow] = p_objDetail[iRow].m_strStorageID;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        /// <summary>
        /// 查询该药库当前该药品总数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dblGross">实际库存总量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllRealGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            p_dblGross = 0d;

            long lngRes = 0;
            try
            {
                string strSQL = @"select realgross_int
  from t_ms_storage_detail
 where storageid_chr = ?
   and medicineid_chr = ?
   and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if(dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if(intRowsCount > 0)
                    {
                        double dblGrossTemp = 0d;
                        for(int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            if(double.TryParse(dtbValue.Rows[iRow][0].ToString(), out dblGrossTemp))
                            {
                                p_dblGross += dblGrossTemp;
                            }
                        }
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

    }
}
