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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAdjustmentSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 添加药房调价主表内容
        /// <summary>
        ///  添加药房调价主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表Vo信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewDSAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_VO p_objMain)
        {

            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_adjustprice
  (seriesid_int,
   adjustpriceid_vchr,
   newdate_dat,
   status_int ,
   creatorid_chr,
   examerid_chr,
   inaccountid_chr,
   examdate_dat,
   inaccountdate_dat,
   comment_vchr,msseriesid_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objMain.m_strADJUSTPRICEID_VCHR;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_objMain.m_dtmNEWDATE_DAT;
                objDPArr[3].Value = p_objMain.m_intFORMSTATE_INT;
                objDPArr[4].Value = p_objMain.m_strCREATORID_CHR;
                objDPArr[5].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[6].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[7].Value = p_objMain.m_dtmEXAMDATE_DAT;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[8].Value = p_objMain.m_dtmINACCOUNTDATE_DAT;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[9].Value = p_objMain.m_strCOMMENT_VCHR;
                objDPArr[10].Value = p_objMain.m_lngMSSERIESID_INT;
                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objMain = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 添加药房药品调价明细
        /// <summary>
        /// 添加药房药品调价明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">药品调价明细内容</param>
        /// <param name="p_lngSEQ">生成的序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewDSAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_Detail[] p_objDetailArr, out long[] p_lngSEQ)
        {
            p_lngSEQ = null;
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return 1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_adjustprice_detail
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   lotno_vchr,
   ipcurrentgross_int,
   opcurrentgross_int,
   packqty_dec,
   ipoldretailprice_int,
   opoldretailprice_int,
   ipnewretailprice_int,
   opnewretailprice_int,
   reason_vchr,
   status_int,
   validperiod_dat,
   opunit_vchr,
   ipunit_vchr,drugstoreid_chr,productorid_chr,hasgross_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?)";
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();


                DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.Int64,DbType.String,DbType.String,DbType.String, DbType.String,
                        DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Int16,DbType.DateTime,DbType.String,DbType.String,DbType.String,DbType.String,DbType.Int16};

                object[][] objValues = new object[21][];

                int intItemCount = p_objDetailArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_ADJUSTPRICE_DETAIL", intItemCount, out p_lngSEQ);
                if (p_lngSEQ == null || p_lngSEQ.Length == 0)
                {
                    return -1;
                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_lngSEQ[iRow];
                    objValues[1][iRow] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                    objValues[6][iRow] = p_objDetailArr[iRow].m_dblIPCURRENTGROSS_INT;
                    objValues[7][iRow] = p_objDetailArr[iRow].m_dblOPCURRENTGROSS_INT;
                    objValues[8][iRow] = p_objDetailArr[iRow].m_dblPackage;
                    objValues[9][iRow] = p_objDetailArr[iRow].m_dblIPOLDRETAILPRICE_INT;
                    objValues[10][iRow] = p_objDetailArr[iRow].m_dblOPOLDRETAILPRICE_INT;
                    objValues[11][iRow] = p_objDetailArr[iRow].m_dblIPNEWRETAILPRICE_INT;
                    objValues[12][iRow] = p_objDetailArr[iRow].m_dblOPNEWRETAILPRICE_INT;
                    objValues[13][iRow] = p_objDetailArr[iRow].m_strREASON_VCHR;
                    objValues[14][iRow] = p_objDetailArr[iRow].m_intSTATUS_INT;
                    objValues[15][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                    objValues[16][iRow] = p_objDetailArr[iRow].m_strOPUNIT_VCHR;
                    objValues[17][iRow] = p_objDetailArr[iRow].m_strIPUNIT_VCHR;
                    objValues[18][iRow] = p_objDetailArr[iRow].m_strDrugStoreid;
                    objValues[19][iRow] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[20][iRow] = p_objDetailArr[iRow].m_intHasGross;
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objDetailArr = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 保存药品调价记录
        /// <summary>
        /// 保存药品调价记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表记录</param>
        /// <param name="p_objDetailArr">明细记录</param>
        /// <param name="p_blnIsCommit">是否直接审核</param>
        /// <param name="p_blnIsDiffLotNO">是否分批号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strAdjustID">调价单据号</param>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="m_blnChangeMedStore">是否调整药房库存价格</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Adjustment_VO p_objMain, clsMS_Adjustment_Detail[] p_objDetailArr, bool p_blnIsCommit, bool p_blnIsDiffLotNO, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strAdjustID, out long[] p_lngSEQ, bool m_blnChangeMedStore)
        {

            p_lngMainSEQ = 0;
            p_strAdjustID = string.Empty;
            p_lngSEQ = null;
            long[] p_lngDsSEQ = null;
            if (p_objMain == null || p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }
            List<clsDS_Adjustment_Detail> m_objDsAdjustmentDetail = new List<clsDS_Adjustment_Detail>();
            clsDS_Adjustment_VO objDsAdjustment = new clsDS_Adjustment_VO();
            clsAdjustment_Supported_SVC objSelect = new clsAdjustment_Supported_SVC();
            long lngRes = 0;
            try
            {
                lngRes = m_lngAddNewAdjustmentMain(p_objPrincipal, p_objMain, out p_lngMainSEQ, out p_strAdjustID);
                if (m_blnChangeMedStore)
                {
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                    lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_ADJUSTPRICE", out objDsAdjustment.m_lngSERIESID_INT);
                    objDsAdjustment.m_dtmEXAMDATE_DAT = p_objMain.m_dtmEXAMDATE_DAT;
                    objDsAdjustment.m_dtmADJUSTPRICEDATE_DAT = p_objMain.m_dtmADJUSTPRICEDATE_DAT;
                    objDsAdjustment.m_dtmINACCOUNTDATE_DAT = p_objMain.m_dtmINACCOUNTDATE_DAT;
                    objDsAdjustment.m_dtmNEWDATE_DAT = p_objMain.m_dtmNEWDATE_DAT;
                    objDsAdjustment.m_intFORMSTATE_INT = p_objMain.m_intFORMSTATE_INT;
                    objDsAdjustment.m_strADJUSTPRICEID_VCHR = p_strAdjustID;
                    objDsAdjustment.m_strCOMMENT_VCHR = p_objMain.m_strCOMMENT_VCHR;
                    objDsAdjustment.m_strCREATORID_CHR = p_objMain.m_strCREATORID_CHR;
                    objDsAdjustment.m_strEXAMERID_CHR = p_objMain.m_strEXAMERID_CHR;
                    objDsAdjustment.m_strINACCOUNTID_CHR = p_objMain.m_strINACCOUNTID_CHR;
                    objDsAdjustment.m_lngMSSERIESID_INT = p_lngMainSEQ;
                    lngRes = m_lngAddNewDSAdjustmentMain(p_objPrincipal, objDsAdjustment);
                }
                if (lngRes > 0)
                {

                    for (int iDe = 0; iDe < p_objDetailArr.Length; iDe++)
                    {
                        p_objDetailArr[iDe].m_lngSERIESID2_INT = p_lngMainSEQ;
                    }
                    lngRes = m_lngAddNewAdjustmentDetail(p_objPrincipal, p_objDetailArr, out p_lngSEQ);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    if (m_blnChangeMedStore)
                    {
                        for (int i = 0; i < p_objDetailArr.Length; i++)
                        {
                            objSelect.m_lngGetAdjustmentDetailArr(p_objPrincipal, objDsAdjustment.m_lngSERIESID_INT, p_objDetailArr[i], ref m_objDsAdjustmentDetail);
                        }
                        lngRes = this.m_lngAddNewDSAdjustmentDetail(p_objPrincipal, m_objDsAdjustmentDetail.ToArray(), out p_lngDsSEQ);
                    }
                    //string strSQL = @"select * from t_ds_adjustprice_detail ";
                    //DataTable dt = new DataTable();
                    //clsHRPTableService objHRP = new clsHRPTableService();
                    //lngRes = objHRP.lngGetDataTableWithoutParameters(strSQL, ref dt);
                    if (p_blnIsCommit)
                    {
                        clsMS_MedicineInfoForAdjustPrice[] objAdjust = new clsMS_MedicineInfoForAdjustPrice[p_objDetailArr.Length];
                        clsDS_MedicineInfoForAdjustPrice[] objDsAdjust = new clsDS_MedicineInfoForAdjustPrice[m_objDsAdjustmentDetail.Count];
                        for (int iPr = 0; iPr < p_objDetailArr.Length; iPr++)
                        {
                            objAdjust[iPr] = new clsMS_MedicineInfoForAdjustPrice();
                            objAdjust[iPr].m_lngSeriesID = p_objDetailArr[iPr].m_lngSERIESID_INT;
                            objAdjust[iPr].m_dblNewRetailPrice = p_objDetailArr[iPr].m_dblNEWRETAILPRICE_INT;
                            objAdjust[iPr].m_dblOldRetailPrice = p_objDetailArr[iPr].m_dblOLDRETAILPRICE_INT;
                            objAdjust[iPr].m_dtmAdjustDate = p_objMain.m_dtmEXAMDATE_DAT;
                            objAdjust[iPr].m_strAdjustManID = p_objMain.m_strEXAMERID_CHR;
                            objAdjust[iPr].m_strLotNO = p_objDetailArr[iPr].m_strLOTNO_VCHR;
                            objAdjust[iPr].m_strMedicineID = p_objDetailArr[iPr].m_strMEDICINEID_CHR;
                            objAdjust[iPr].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            objAdjust[iPr].m_dblInPrice = p_objDetailArr[iPr].m_dblCALLPRICE_INT;
                            objAdjust[iPr].m_dtmValidDate = p_objDetailArr[iPr].m_dtmVALIDPERIOD_DAT;
                            objAdjust[iPr].m_lngAdjustDetaiSEQ = p_lngSEQ[iPr];
                            objAdjust[iPr].m_intHasGross = p_objDetailArr[iPr].m_intHasGross;
                            objAdjust[iPr].m_strInStorageID = p_objDetailArr[iPr].m_strINSTORAGEID_VCHR;
                            objAdjust[iPr].m_strAdjustPriceid = p_strAdjustID;

                            objAdjust[iPr].m_strMedicineName = p_objDetailArr[iPr].m_strMEDICINENAME_VCH;
                            objAdjust[iPr].m_strMedicineTypeid = p_objDetailArr[iPr].m_strMedicineTypeID;
                            objAdjust[iPr].m_strMedicineSpec = p_objDetailArr[iPr].m_strMEDSPEC_VCHR;
                            objAdjust[iPr].m_strOPunit = p_objDetailArr[iPr].m_strOPUNIT_VCHR;
                            objAdjust[iPr].m_dblNewWholeSalePrice = p_objDetailArr[iPr].m_dblNEWWHOLESALEPRICE_INT;
                            objAdjust[iPr].m_dblOldWholeSalePrice = p_objDetailArr[iPr].m_dblOLDWHOLESALEPRICE_INT;
                            objAdjust[iPr].m_dblINPUTCALLPRICE_INT = p_objDetailArr[iPr].m_dblINPUTCALLPRICE_INT;
                        }
                        for (int j = 0; j < m_objDsAdjustmentDetail.Count; j++)
                        {
                            objDsAdjust[j] = new clsDS_MedicineInfoForAdjustPrice();
                            objDsAdjust[j].m_strMedicineID = m_objDsAdjustmentDetail[j].m_strMEDICINEID_CHR;
                            objDsAdjust[j].m_dblIPNewRetailPrice = m_objDsAdjustmentDetail[j].m_dblIPNEWRETAILPRICE_INT;
                            objDsAdjust[j].m_dblOPNewRetailPrice = m_objDsAdjustmentDetail[j].m_dblOPNEWRETAILPRICE_INT;
                            objDsAdjust[j].m_dblIPOldRetailPrice = m_objDsAdjustmentDetail[j].m_dblIPOLDRETAILPRICE_INT;
                            objDsAdjust[j].m_dblOPOldRetailPrice = m_objDsAdjustmentDetail[j].m_dblOPOLDRETAILPRICE_INT;
                            objDsAdjust[j].m_intHasGross = m_objDsAdjustmentDetail[j].m_intHasGross;
                            objDsAdjust[j].m_strDrugStoreID = m_objDsAdjustmentDetail[j].m_strDrugStoreid;
                            objDsAdjust[j].m_strAdjustManID = objDsAdjustment.m_strEXAMERID_CHR;
                            objDsAdjust[j].m_dtmAdjustDate = objDsAdjustment.m_dtmEXAMDATE_DAT;
                            objDsAdjust[j].m_lngAdjustDetaiSEQ = p_lngDsSEQ[j];
                            objDsAdjust[j].m_strInStorageID = m_objDsAdjustmentDetail[j].m_strINSTORAGEID_VCHR;
                            objDsAdjust[j].m_strAdjustPriceid = p_strAdjustID;
                            objDsAdjust[j].m_dblPACKQTY_DEC = m_objDsAdjustmentDetail[j].m_dblPackage;
                        }

                        lngRes = m_lngModifyStoragePrice(p_objPrincipal, p_blnIsDiffLotNO, objAdjust);

                        if (lngRes < 0)
                        {
                            return -1;
                        }
                        if(m_blnChangeMedStore)
                        {
                            lngRes = m_lngModifyDsStorageMedicinePrice(p_objPrincipal, p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT, objDsAdjust);
                            if(lngRes < 0)
                            {
                                throw new Exception();
                            }
                        }
                        lngRes = m_lngModifyAdjustCurrentGross(p_objPrincipal, objAdjust);
                        if (lngRes < 0)
                        {
                            throw new Exception();
                        } 
                        lngRes = m_lngSetCommitUser(p_objPrincipal, new long[] { p_lngMainSEQ }, p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT);

                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                        if (m_blnChangeMedStore)
                        {
                            lngRes = m_lngSetDsCommitUser(p_objPrincipal, new long[] { p_lngMainSEQ }, p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT);

                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        if (objAdjust != null && objAdjust.Length > 0)
                        {
                            long[] m_lngMainSEQ=new long[] {p_lngMainSEQ};
                            lngRes = m_lngAddDataToAccountDetail(p_objPrincipal, m_lngMainSEQ, objAdjust, p_blnIsImmAccount, p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT);
                            if (lngRes < 0)
                            {
                                throw new Exception();
                            }
                            if (m_blnChangeMedStore)
                            {
                                lngRes = this.m_lngAddDataToDsAccountDetail(p_objPrincipal, objDsAdjust, p_blnIsImmAccount, p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT, objDsAdjustment.m_lngSERIESID_INT);
                                if (lngRes < 0)
                                {
                                    throw new Exception();
                                }
                            }
                            Hashtable hstMedicineID = new Hashtable();
                            Hashtable hstWholeSalePrice = new Hashtable();
                            Hashtable hstReatPrice = new Hashtable();
                            if (m_blnChangeMedStore)
                            {
                                for (int iMe = 0; iMe < objAdjust.Length; iMe++)
                                {
                                    if (!hstMedicineID.Contains(objAdjust[iMe].m_strMedicineID))
                                    {
                                        hstMedicineID.Add(objAdjust[iMe].m_strMedicineID, objAdjust[iMe].m_dblNewRetailPrice);
                                        hstWholeSalePrice.Add(objAdjust[iMe].m_strMedicineID, objAdjust[iMe].m_dblNewWholeSalePrice);
                                       // hstReatPrice.Add(objAdjust[iMe].m_strMedicineID,objAdjust[iMe].m_dblInPrice);
                                        //CS-542 (ID:14541)药库调价需求
                                        hstReatPrice.Add(objAdjust[iMe].m_strMedicineID, objAdjust[iMe].m_dblINPUTCALLPRICE_INT);
                                    }
                                }
                                lngRes = m_lngSetMedicineBasePrice(p_objMain.m_strCREATORID_CHR, p_objMain.m_dtmADJUSTPRICEDATE_DAT, hstMedicineID, hstWholeSalePrice, hstReatPrice);
                            }
                        } 
                        if (lngRes <= 0)
                        {
                            throw new Exception();
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

        #region 设置入帐
        /// <summary>
        /// 设置入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">入帐者ID</param>
        /// <param name="p_dtmCommitDate">入帐时间</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetDSAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice
   set inaccountid_chr = ?, inaccountdate_dat = ?,status_int = 3
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[2].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;
                        objValues[1][iRow] = p_dtmCommitDate;
                        objValues[2][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 修改药品调价记录
        /// <summary>
        /// 修改药品调价记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">药品调价主记录</param>
        /// <param name="p_objDetailArr">药品调价明细记录</param>
        /// <param name="p_blnIsCommit">是否直接审核</param>
        /// <param name="p_blnIsDiffLotNO">是否分批号</param>
        /// <param name="p_lngSEQ">明细序列</param>
        ///<param name="m_blnChangeMedStore">是否改变药房库存价格</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Adjustment_VO p_objMain, clsMS_Adjustment_Detail[] p_objDetailArr, bool p_blnIsCommit, bool p_blnIsDiffLotNO, out long[] p_lngSEQ, bool m_blnChangeMedStore)
        {
            p_lngSEQ = null;
            long[] p_lngDsSEQ = null;
            long lngRes = 0;
            long m_lngDSSERIESID_INT = 0;
            List<clsDS_Adjustment_Detail> m_objDsAdjustmentDetail = new List<clsDS_Adjustment_Detail>();
            if (p_objDetailArr == null || p_objDetailArr.Length == 0 || p_objMain == null)
            {
                return -1;
            }
            clsAdjustment_Supported_SVC objSelect = new clsAdjustment_Supported_SVC();
            try
            {
                lngRes = m_lngModifyAdjustmentMain(p_objPrincipal, p_objMain);
                if (lngRes > 0)
                {
                    lngRes = this.m_lngSetAdjustmentDetailInvalid(p_objPrincipal, p_objMain.m_lngSERIESID_INT);
                    lngRes = objSelect.m_lngGetAdjustmentSeriesid(p_objPrincipal, p_objMain.m_lngSERIESID_INT, out m_lngDSSERIESID_INT);
                    if (m_blnChangeMedStore)
                    {
                        //作废药房调价明细
                        lngRes = m_lngSetDsAdjustmentDetailInvalid(p_objPrincipal, m_lngDSSERIESID_INT);
                    }
                    if (lngRes > 0)
                    {
                        lngRes = m_lngAddNewAdjustmentDetail(p_objPrincipal, p_objDetailArr, out p_lngSEQ);
                        if (m_blnChangeMedStore)
                        {
                            //插入药房调价明细
                            for (int i = 0; i < p_objDetailArr.Length; i++)
                            {
                                objSelect.m_lngGetAdjustmentDetailArr(p_objPrincipal, m_lngDSSERIESID_INT, p_objDetailArr[i], ref m_objDsAdjustmentDetail);
                            }
                            lngRes = this.m_lngAddNewDSAdjustmentDetail(p_objPrincipal, m_objDsAdjustmentDetail.ToArray(), out p_lngDsSEQ);
                        }
                    }

                    if (p_blnIsCommit)
                    {
                        clsMS_MedicineInfoForAdjustPrice[] objAdjust = new clsMS_MedicineInfoForAdjustPrice[p_objDetailArr.Length];
                        for (int iPr = 0; iPr < p_objDetailArr.Length; iPr++)
                        {
                            objAdjust[iPr] = new clsMS_MedicineInfoForAdjustPrice();
                            objAdjust[iPr].m_dblNewRetailPrice = p_objDetailArr[iPr].m_dblNEWRETAILPRICE_INT;
                            objAdjust[iPr].m_dblOldRetailPrice = p_objDetailArr[iPr].m_dblOLDRETAILPRICE_INT;
                            objAdjust[iPr].m_dtmAdjustDate = p_objMain.m_dtmEXAMDATE_DAT;
                            objAdjust[iPr].m_strAdjustManID = p_objMain.m_strEXAMERID_CHR;
                            objAdjust[iPr].m_strLotNO = p_objDetailArr[iPr].m_strLOTNO_VCHR;
                            objAdjust[iPr].m_strMedicineID = p_objDetailArr[iPr].m_strMEDICINEID_CHR;
                            objAdjust[iPr].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            objAdjust[iPr].m_dtmValidDate = p_objDetailArr[iPr].m_dtmVALIDPERIOD_DAT;
                            objAdjust[iPr].m_dblInPrice = p_objDetailArr[iPr].m_dblCALLPRICE_INT;
                        }


                        lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, p_blnIsDiffLotNO, objAdjust);

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

        #region 添加药品调价明细
        /// <summary>
        /// 添加药品调价明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">药品调价明细内容</param>
        /// <param name="p_lngSEQ">生成的序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Adjustment_Detail[] p_objDetailArr, out long[] p_lngSEQ)
        {
            p_lngSEQ = null;
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_adjustprice_detail
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   lotno_vchr,
   currentgross_int,
   oldretailprice_int,
   newretailprice_int,
   reason_vchr,
   status_int,
   validperiod_dat,
   opunit_vchr,
   instorageid_vchr,
   callprice_int,productorid_chr,hasgross_int,inputcallprice_int,oldwholesaleprice_int,newwholesaleprice_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_ADJUSTPRICE_DETAIL", p_objDetailArr.Length, out p_lngSEQ);
                    if (p_lngSEQ == null || p_lngSEQ.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(20, out objLisAddItemRefArr);
                        //Please change the datetime and reocrdid 
                        objLisAddItemRefArr[0].Value = p_lngSEQ[iRow];
                        objLisAddItemRefArr[1].Value = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objLisAddItemRefArr[2].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[3].Value = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[4].Value = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[5].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[6].Value = p_objDetailArr[iRow].m_dblCURRENTGROSS_INT;
                        objLisAddItemRefArr[7].Value = p_objDetailArr[iRow].m_dblOLDRETAILPRICE_INT;
                        objLisAddItemRefArr[8].Value = p_objDetailArr[iRow].m_dblNEWRETAILPRICE_INT;
                        objLisAddItemRefArr[9].Value = p_objDetailArr[iRow].m_strREASON_VCHR;
                        objLisAddItemRefArr[10].Value = p_objDetailArr[iRow].m_intSTATUS_INT;
                        objLisAddItemRefArr[11].Value = DbType.DateTime;
                        objLisAddItemRefArr[11].Value = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[12].Value = p_objDetailArr[iRow].m_strOPUNIT_VCHR;
                        objLisAddItemRefArr[13].Value = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[14].Value = p_objDetailArr[iRow].m_dblCALLPRICE_INT;
                        objLisAddItemRefArr[15].Value = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[16].Value = p_objDetailArr[iRow].m_intHasGross;
                        objLisAddItemRefArr[17].Value = p_objDetailArr[iRow].m_dblINPUTCALLPRICE_INT;
                        objLisAddItemRefArr[18].Value = p_objDetailArr[iRow].m_dblOLDWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[19].Value = p_objDetailArr[iRow].m_dblNEWWHOLESALEPRICE_INT;

                        p_objDetailArr[iRow].m_lngSERIESID_INT = p_lngSEQ[iRow];
                        //往表增加记录


                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.Int64,DbType.String,DbType.String,DbType.String, DbType.String,
                        DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Int32,DbType.DateTime,DbType.String,DbType.String,
                        DbType.Double,DbType.String,DbType.Int16,DbType.Double,DbType.Double,DbType.Double};

                    object[][] objValues = new object[20][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_ADJUSTPRICE_DETAIL", intItemCount, out p_lngSEQ);
                    if (p_lngSEQ == null || p_lngSEQ.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngSEQ[iRow];
                        objValues[1][iRow] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_dblCURRENTGROSS_INT;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_dblOLDRETAILPRICE_INT;
                        objValues[8][iRow] = p_objDetailArr[iRow].m_dblNEWRETAILPRICE_INT;
                        objValues[9][iRow] = p_objDetailArr[iRow].m_strREASON_VCHR;
                        objValues[10][iRow] = p_objDetailArr[iRow].m_intSTATUS_INT;
                        objValues[11][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[12][iRow] = p_objDetailArr[iRow].m_strOPUNIT_VCHR;
                        objValues[13][iRow] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[14][iRow] = p_objDetailArr[iRow].m_dblCALLPRICE_INT;
                        objValues[15][iRow] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[16][iRow] = p_objDetailArr[iRow].m_intHasGross;
                        objValues[17][iRow] = p_objDetailArr[iRow].m_dblINPUTCALLPRICE_INT;
                        objValues[18][iRow] = p_objDetailArr[iRow].m_dblOLDWHOLESALEPRICE_INT;
                        objValues[19][iRow] = p_objDetailArr[iRow].m_dblNEWWHOLESALEPRICE_INT;

                        p_objDetailArr[iRow].m_lngSERIESID_INT = p_lngSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objDetailArr = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 添加调价主表内容
        /// <summary>
        /// 添加调价主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">调价主表内容</param>
        /// <param name="p_lngMainSEQ">序列</param>
        /// <param name="p_strAdjustID">调价单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Adjustment_VO p_objMain, out long p_lngMainSEQ, out string p_strAdjustID)
        {
            p_lngMainSEQ = 0;
            p_strAdjustID = string.Empty;
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_adjustprice
  (seriesid_int,
   storageid_chr,
   adjustpriceid_vchr,
   adjustpricedate_dat,
   newdate_dat,
   formtype_int,
   formstate_int,
   creatorid_chr,
   examerid_chr,
   inaccountid_chr,
   examdate_dat,
   inaccountdate_dat,
   comment_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";



                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_ADJUSTPRICE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_objMain.m_lngSERIESID_INT = lngSEQ;
                p_lngMainSEQ = lngSEQ;

                string strAdjustmentID = string.Empty;
                lngRes = m_lngGetLatestAdjustmentID(p_objPrincipal, out strAdjustmentID);
                //string m_strTempId = string.Empty;
                //string m_strMedStoreShortCode = string.Empty;
                //string m_strParaValue = string.Empty;
                //lngRes = objPublic.m_lngGetSysParaByID(p_objPrincipal, "5002", out m_strParaValue);
                //lngRes = objPublic.m_lngGetStorageShortCode(p_objPrincipal, p_objMain.m_strSTORAGEID_CHR, out m_strMedStoreShortCode);
                //lngRes = objPublic.m_lngGetNewIdByName(p_objPrincipal, "t_ms_adjustprice", "adjustpriceid_vchr", m_strMedStoreShortCode, p_objMain.m_dtmADJUSTPRICEDATE_DAT,m_strParaValue.Split(';')[4], ref m_strTempId);
                //strAdjustmentID = m_strMedStoreShortCode + p_objMain.m_dtmADJUSTPRICEDATE_DAT.ToString("yyMMdd") + m_strParaValue.Split(';')[4] + m_strTempId;
                if (string.IsNullOrEmpty(strAdjustmentID))
                {
                    return -1;
                }
                p_objMain.m_strADJUSTPRICEID_VCHR = strAdjustmentID;
                p_strAdjustID = strAdjustmentID;
                IDataParameter[] objDPArr = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(13, out objDPArr);
                objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objMain.m_strSTORAGEID_CHR;
                objDPArr[2].Value = p_objMain.m_strADJUSTPRICEID_VCHR;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_objMain.m_dtmADJUSTPRICEDATE_DAT;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_objMain.m_dtmNEWDATE_DAT;
                objDPArr[5].Value = p_objMain.m_intFORMTYPE_INT;
                objDPArr[6].Value = p_objMain.m_intFORMSTATE_INT;
                objDPArr[7].Value = p_objMain.m_strCREATORID_CHR;
                objDPArr[8].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[9].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[10].DbType = DbType.DateTime;
                objDPArr[10].Value = p_objMain.m_dtmEXAMDATE_DAT;
                objDPArr[11].DbType = DbType.DateTime;
                objDPArr[11].Value = p_objMain.m_dtmINACCOUNTDATE_DAT;
                objDPArr[12].Value = p_objMain.m_strCOMMENT_VCHR;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objMain = null;
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
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = DateTime.Now.ToString("yyyyMMdd") + "8%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if(dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = DateTime.Now.ToString("yyyyMMdd") + "80001";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if(string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = DateTime.Now.ToString("yyyyMMdd") + "80001";
                    }
                    else
                    {
                        strTemp = strTemp.Substring(9, 4);
                        p_strID = DateTime.Now.ToString("yyyyMMdd") + "8" + (Convert.ToInt32(strTemp) + 1).ToString("0000");
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
        #endregion

        #region 删除指定药品调价明细记录
        /// <summary>
        /// 删除指定药品调价明细记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsDiffLotNO">是否分批号</param>
        /// <param name="p_objAdjustMedicine">调价审核药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSpecAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, bool p_blnIsCommit, bool p_blnIsDiffLotNO, clsMS_MedicineInfoForAdjustPrice p_objAdjustMedicine)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_adjustprice_detail set status_int = 0 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0)
                {
                    if (p_blnIsCommit)
                    {
                        if (p_objAdjustMedicine == null)
                        {
                            return -1;
                        }
                        clsMS_MedicineInfoForAdjustPrice[] objAdjust = new clsMS_MedicineInfoForAdjustPrice[1];
                        objAdjust[0] = p_objAdjustMedicine;

                        lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, p_blnIsDiffLotNO, objAdjust);


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
        /// 删除指定药品调价明细记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsDiffLotNO">是否分批号</param>
        /// <param name="p_objAdjustMedicine">调价审核药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSpecAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ, bool p_blnIsCommit, bool p_blnIsDiffLotNO, clsMS_MedicineInfoForAdjustPrice p_objAdjustMedicine)
        {
            long lngRes = 0;
            try
            {
                //删除子表记录
                string strSQL = "update t_ms_adjustprice_detail set status_int = 0 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        /// <summary>
        /// 设置指定调价单所有明细记录为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAdjustmentDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_adjustprice_detail set status_int = -1 where seriesid2_int = ? and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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
        /// 设置指定药房调价单所有明细记录为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">药房调价主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetDsAdjustmentDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice_detail
   set status_int = -1
 where status_int = 1
   and seriesid2_int =?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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
        /// 删除指定药房调价单所有明细记录

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetDSAdjustmentInvalid(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                //删除子表记录
                string strSQL = "update t_ds_adjustprice set status_int = 0 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// <summary>
        /// 删除指定调价单所有明细记录

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAdjustmentDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                //删除子表记录
                string strSQL = "update t_ms_adjustprice_detail set status_int = 0 where seriesid2_int = ? and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
        /// <summary>
        /// 删除指定药房调价单所有明细记录

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetDsAdjustmentDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ)
        {
            long lngRes = 0;

            try
            {
                //删除子表记录
                string strSQL = "update t_ds_adjustprice_detail set status_int = 0 where seriesid2_int = ? and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 删除整条药品调价记录
        /// <summary>
        /// 删除整条药品调价记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">药品调价主表索引</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ, bool m_blnChangeMedStore)
        {
            if (p_lngSEQ == null || p_lngSEQ.Length == 0)
            {
                return -1;
            }
            long[] p_lngDsSEQ = new long[p_lngSEQ.Length];
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_adjustprice set formstate_int = 0
                                   where seriesid_int = ? and formstate_int = 1";
                clsAdjustment_Supported_SVC objSelect = new clsAdjustment_Supported_SVC();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
                objHRPServ.Dispose();
                objHRPServ = null;

                if (lngRes <= 0)
                {
                    return -1;
                }
                lngRes = m_lngSetAdjustmentDetailInvalid(p_objPrincipal, p_lngSEQ);
                if (m_blnChangeMedStore)
                {
                    for (int i = 0; i < p_lngSEQ.Length; i++)
                    {
                        objSelect.m_lngGetAdjustmentSeriesid(p_objPrincipal, p_lngSEQ[i], out p_lngDsSEQ[i]);
                    }

                    //作废药房调价主表信息
                    lngRes = this.m_lngSetDSAdjustmentInvalid(p_objPrincipal, p_lngDsSEQ);
                    //作废药房调价明细表信息

                    lngRes = m_lngSetDsAdjustmentDetailInvalid(p_objPrincipal, p_lngDsSEQ);

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

        #region 修改调价主表内容
        /// <summary>
        /// 修改调价主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">调价主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Adjustment_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ms_adjustprice
                                       set adjustpricedate_dat = ?, examerid_chr = ?, inaccountid_chr = ?,
                                           examdate_dat = ?, inaccountdate_dat = ?, comment_vchr = ?
                                     where seriesid_int = ?
                                       and formstate_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_objMain.m_dtmADJUSTPRICEDATE_DAT;
                objDPArr[1].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[2].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_objMain.m_dtmEXAMDATE_DAT;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_objMain.m_dtmINACCOUNTDATE_DAT;
                objDPArr[5].Value = p_objMain.m_strCOMMENT_VCHR;
                objDPArr[6].Value = p_objMain.m_lngSERIESID_INT;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objMain = null;

                if(lngEff != 1)
                {
                    lngRes = -1;

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

        #region 修改药房库存药品零售价


        /// <summary>
        /// 修改库存药品零售价(分批号)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArr">调价药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyDsStorageMedicinePrice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strExamerID, DateTime m_dtmExamTime, clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {
            if (p_objAdjustMedicineArr == null)
            {
                return -1;
            }
            if (p_objAdjustMedicineArr.Length == 0)
            {
                return 1;
            }
            long lngRes = 0;
            try
            {
                string strUpdateSQL = @"update t_ds_storage_detail t
   set  t.ipretailprice_int=?,t.opretailprice_int=?
   where t.medicineid_chr = ?
   and t.drugstoreid_chr = ?
   and t.status = 1";
                clsHRPTableService objHRPServ = new clsHRPTableService();

                long lngEff1 = -1;

                DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };

                object[][] objValues = new object[4][];
                int intItemCount = p_objAdjustMedicineArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化


                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPNewRetailPrice;
                    objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPNewRetailPrice;
                    objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                    objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_strDrugStoreID;


                }
                lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strUpdateSQL, objValues, ref lngEff1, dbTypes);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes < 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
            #region old code backup
            //            if (p_objAdjustMedicineArr == null)
            //            {
            //                return -1;
            //            }
            //            if (p_objAdjustMedicineArr.Length == 0)
            //            {
            //                return 1;
            //            }
            //            long lngRes = 0;
            //            try
            //            {
            //                string strAddSQL = @"insert into t_ds_storage_detail
            //  (seriesid_int,
            //   drugstoreid_chr ,
            //   medicineid_chr,
            //   medicinename_vchr,
            //   medspec_vchr,
            //   lotno_vchr,packqty_dec,
            //   ipretailprice_int ,
            //   opretailprice_int ,
            //   iprealgross_int ,
            //   oprealgross_int ,
            //   opavailablegross_num ,
            //   ipavailablegross_num ,
            //   ipwholesaleprice_int ,
            //   opwholesaleprice_int, 
            //   opunit_chr,
            //   ipunit_chr ,
            //   validperiod_dat,
            //   productorid_chr,
            //   instoreid_vchr,
            //   instoragedate_dat,
            //   dsinstoragedate_dat ,
            //   dsinstoreid_vchr ,
            //   status, 
            //   storagerackid_chr ,
            //   adjustpriceman_chr,
            //   adjustpricedate_dat)
            //  select seq_ds_storage_detail.nextval,
            //         t.drugstoreid_chr ,
            //         t.medicineid_chr,
            //         t.medicinename_vchr,
            //         t.medspec_vchr,
            //         t.lotno_vchr,packqty_dec,
            //         ?,
            //         ?,
            //         t.iprealgross_int ,
            //         t.oprealgross_int ,
            //         t.opavailablegross_num ,
            //         t.ipavailablegross_num ,
            //         t.ipwholesaleprice_int  ,
            //         t.opwholesaleprice_int  ,
            //         t.opunit_chr,
            //         t.ipunit_chr ,
            //         t.validperiod_dat,
            //         t.productorid_chr,
            //         t.instoreid_vchr,
            //         t.instoragedate_dat,
            //         t.dsinstoragedate_dat ,
            //         t.dsinstoreid_vchr ,
            //         1,
            //         storagerackid_chr,
            //         ?,
            //         ?
            //    from t_ds_storage_detail t
            //   where t.medicineid_chr = ?
            //     and t.drugstoreid_chr = ?
            //   and t.ipretailprice_int = ?
            //   and t.opretailprice_int = ?
            //     and t.status = 1";

            //                string strDelSQL = @"update t_ds_storage_detail t
            //   set t.status = 2,adjustpriceman_chr=?,adjustpricedate_dat=?
            // where t.medicineid_chr = ?
            //   and t.drugstoreid_chr = ?
            //   and t.ipretailprice_int = ?
            //   and t.opretailprice_int = ?
            //   and t.status = 1";

            //                clsHRPTableService objHRPServ = new clsHRPTableService();

            //                long lngEff = -1;
            //                long lngEff1 = -1;
            //                #region 添加记录

            //                DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.Double, DbType.Double };

            //                object[][] objValues = new object[8][];

            //                int intItemCount = p_objAdjustMedicineArr.Length;
            //                for (int j = 0; j < objValues.Length; j++)
            //                {
            //                    objValues[j] = new object[intItemCount];//初始化


            //                }

            //                for (int iRow = 0; iRow < intItemCount; iRow++)
            //                {
            //                    objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPNewRetailPrice;
            //                    objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPNewRetailPrice;
            //                    objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strAdjustManID;
            //                    objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_dtmAdjustDate;
            //                    objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                    objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_strDrugStoreID;
            //                    objValues[6][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPOldRetailPrice;
            //                    objValues[7][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPOldRetailPrice;

            //                }
            //                lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strAddSQL, objValues, ref lngEff, dbTypes);

            //                if (lngRes >= 0)
            //                {
            //                    dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.Double, DbType.Double };

            //                    objValues = new object[6][];

            //                    for (int j = 0; j < objValues.Length; j++)
            //                    {
            //                        objValues[j] = new object[intItemCount];//初始化


            //                    }

            //                    for (int iRow = 0; iRow < intItemCount; iRow++)
            //                    {
            //                        objValues[0][iRow] = p_strExamerID;
            //                        objValues[1][iRow] = m_dtmExamTime;
            //                        objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                        objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_strDrugStoreID;
            //                        objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPOldRetailPrice;
            //                        objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPOldRetailPrice;

            //                    }
            //                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strDelSQL, objValues, ref lngEff1, dbTypes);

            //                    //if (lngEff != lngEff1)
            //                    //{
            //                    //    throw new Exception();
            //                    //}
            //                }
            //                else
            //                {
            //                    throw new Exception();
            //                }

            //                #endregion
            //            }
            //            catch (Exception objEx)
            //            {
            //                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
            //                bool blnRes = objLogger.LogError(objEx);
            //            }
            //            return lngRes;
            #endregion
        }

        #endregion

        #region 修改库存药品零售价
        /// <summary>
        /// 修改库存药品零售价(分批号)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArr">调价药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageMedicinePrice(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsDiffLotNO, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {
            if (p_objAdjustMedicineArr == null)
            {
                return -1;
            }

            long lngRes = 0;
            if (p_blnIsDiffLotNO)
            {
                try
                {

                    string strUpdateSQL = @"update t_ms_storage_detail t
   set t.retailprice_int = ?,t.wholesaleprice_int = ? 
 where t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.storageid_chr = ?
   and t.retailprice_int = ?
   and t.instorageid_vchr = ?
   and t.validperiod_dat = ?
   and t.callprice_int = ?    
   and t.status = 1";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                    long lngEff = -1;

                    #region 添加记录
                    if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                    {
                        IDataParameter[] objLisAddItemRefArr = null;

                        for (int iRow = 0; iRow < p_objAdjustMedicineArr.Length; iRow++)
                        {

                            objHRPServ.CreateDatabaseParameter(9, out objLisAddItemRefArr);
                            objLisAddItemRefArr[0].Value = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
                            objLisAddItemRefArr[1].Value = p_objAdjustMedicineArr[iRow].m_dblNewWholeSalePrice;
                            objLisAddItemRefArr[2].Value = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                            objLisAddItemRefArr[3].Value = p_objAdjustMedicineArr[iRow].m_strLotNO;
                            objLisAddItemRefArr[4].Value = p_objAdjustMedicineArr[iRow].m_strStorageID;
                            objLisAddItemRefArr[5].Value = p_objAdjustMedicineArr[iRow].m_dblOldRetailPrice;
                            objLisAddItemRefArr[6].Value = p_objAdjustMedicineArr[iRow].m_strInStorageID;
                            objLisAddItemRefArr[6].DbType = DbType.DateTime;
                            objLisAddItemRefArr[7].Value = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
                            objLisAddItemRefArr[8].Value = p_objAdjustMedicineArr[iRow].m_dblInPrice;
                            lngRes = objHRPServ.lngExecuteParameterSQL(strUpdateSQL, ref lngEff, objLisAddItemRefArr);
                            if (lngRes <= 0)
                            {
                                objHRPServ.Dispose();
                                objHRPServ = null;
                                throw new Exception();
                            }
                        }
                    }
                    else
                    {
                        DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.String, DbType.DateTime, DbType.Double };

                        object[][] objValues = new object[9][];
                        int intItemCount = p_objAdjustMedicineArr.Length;
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[intItemCount];//初始化
                        }

                        for (int iRow = 0; iRow < intItemCount; iRow++)
                        {
                            objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
                            objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_dblNewWholeSalePrice;
                            objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                            objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_strLotNO;
                            objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strStorageID;
                            objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_dblOldRetailPrice;
                            objValues[6][iRow] = p_objAdjustMedicineArr[iRow].m_strInStorageID;
                            objValues[7][iRow] = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
                            objValues[8][iRow] = p_objAdjustMedicineArr[iRow].m_dblInPrice;
                        }
                        lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strUpdateSQL, objValues, ref lngEff, dbTypes);

                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }


                    }
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    #endregion
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                try
                {

                    string strUpdateSQL = @"update t_ms_storage_detail t
   set t.retailprice_int = ?,t.wholesaleprice_int = ?
 where t.medicineid_chr = ?
   and t.storageid_chr = ?
   and t.status = 1";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                    long lngEff = -1;

                    #region 添加记录
                    if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                    {
                        IDataParameter[] objLisAddItemRefArr = null;

                        for (int iRow = 0; iRow < p_objAdjustMedicineArr.Length; iRow++)
                        {

                            objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                            objLisAddItemRefArr[0].Value = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
                            objLisAddItemRefArr[1].Value = p_objAdjustMedicineArr[iRow].m_dblNewWholeSalePrice;
                            objLisAddItemRefArr[2].Value = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                            objLisAddItemRefArr[3].Value = p_objAdjustMedicineArr[iRow].m_strStorageID;

                            lngRes = objHRPServ.lngExecuteParameterSQL(strUpdateSQL, ref lngEff, objLisAddItemRefArr);
                            if (lngRes < 0)
                            {
                                objHRPServ.Dispose();
                                objHRPServ = null;
                                throw new Exception();
                            }
                        }
                    }
                    else
                    {
                        DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String };

                        object[][] objValues = new object[4][];
                        int intItemCount = p_objAdjustMedicineArr.Length;
                        for (int j = 0; j < objValues.Length; j++)
                        {
                            objValues[j] = new object[intItemCount];//初始化
                        }

                        for (int iRow = 0; iRow < intItemCount; iRow++)
                        {
                            objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
                            objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_dblNewWholeSalePrice;
                            objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                            objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_strStorageID;

                        }
                        lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strUpdateSQL, objValues, ref lngEff, dbTypes);

                        if (lngRes < 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }


                    }
                    #endregion
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
            #region old code backup
            //            if (p_objAdjustMedicineArr == null)
            //            {
            //                return -1;
            //            }

            //            long lngRes = 0;
            //            try
            //            {
            //                string strAddSQL = @"insert into t_ms_storage_detail
            //  (seriesid_int,
            //   storageid_chr,
            //   medicineid_chr,
            //   medicinename_vchr,
            //   medspec_vchr,
            //   syslotno_chr,
            //   lotno_vchr,
            //   retailprice_int,
            //   callprice_int,
            //   wholesaleprice_int,
            //   realgross_int,
            //   availagross_int,
            //   opunit_vchr,
            //   validperiod_dat,
            //   productorid_chr,
            //   instorageid_vchr,
            //   instoragedate_dat,
            //   vendorid_chr,
            //   status,
            //   adjustpriceman_chr,
            //   adjustpricedate_dat)
            //  select seq_ms_storage_detail.nextval,
            //         t.storageid_chr,
            //         t.medicineid_chr,
            //         t.medicinename_vchr,
            //         t.medspec_vchr,
            //         t.syslotno_chr,
            //         t.lotno_vchr,
            //         ?,
            //         t.callprice_int,
            //         t.wholesaleprice_int,
            //         t.realgross_int,
            //         t.availagross_int,
            //         t.opunit_vchr,
            //         t.validperiod_dat,
            //         t.productorid_chr,
            //         t.instorageid_vchr,
            //         t.instoragedate_dat,
            //         t.vendorid_chr,
            //         1,
            //         ?,
            //         ?
            //    from t_ms_storage_detail t
            //   where t.medicineid_chr = ?
            //     and t.lotno_vchr = ?
            //     and t.instorageid_vchr = ?
            //     and t.storageid_chr = ?
            //     and t.validperiod_dat = ?
            //     and t.callprice_int = ?
            //     and t.status = 1";

            //                string strDelSQL = @"update t_ms_storage_detail t
            //   set t.status = 2
            // where t.medicineid_chr = ?
            //   and t.lotno_vchr = ?
            //   and t.storageid_chr = ?
            //   and t.retailprice_int = ?
            //   and t.instorageid_vchr = ?
            //   and t.validperiod_dat = ?
            //   and t.callprice_int = ?
            //   and t.status = 1";

            //                clsHRPTableService objHRPServ = new clsHRPTableService();
            //                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
            //                long lngEff = -1;

            //                #region 添加记录
            //                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
            //                {
            //                    IDataParameter[] objLisAddItemRefArr = null;

            //                    for (int iRow = 0; iRow < p_objAdjustMedicineArr.Length; iRow++)
            //                    {
            //                        objHRPServ.CreateDatabaseParameter(9, out objLisAddItemRefArr);
            //                        objLisAddItemRefArr[0].Value = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
            //                        objLisAddItemRefArr[1].Value = p_objAdjustMedicineArr[iRow].m_strAdjustManID;
            //                        objLisAddItemRefArr[2].DbType = DbType.DateTime;
            //                        objLisAddItemRefArr[2].Value = p_objAdjustMedicineArr[iRow].m_dtmAdjustDate;
            //                        objLisAddItemRefArr[3].Value = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                        objLisAddItemRefArr[4].Value = p_objAdjustMedicineArr[iRow].m_strLotNO;
            //                        objLisAddItemRefArr[5].Value = p_objAdjustMedicineArr[iRow].m_strInStorageID;
            //                        objLisAddItemRefArr[6].Value = p_objAdjustMedicineArr[iRow].m_strStorageID;
            //                        objLisAddItemRefArr[7].DbType = DbType.DateTime;
            //                        objLisAddItemRefArr[7].Value = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
            //                        objLisAddItemRefArr[8].Value = p_objAdjustMedicineArr[iRow].m_dblInPrice;

            //                        lngRes = objHRPServ.lngExecuteParameterSQL(strAddSQL, ref lngEff, objLisAddItemRefArr);

            //                        if (lngRes > 0)
            //                        {
            //                            objHRPServ.CreateDatabaseParameter(7, out objLisAddItemRefArr);
            //                            objLisAddItemRefArr[0].Value = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                            objLisAddItemRefArr[1].Value = p_objAdjustMedicineArr[iRow].m_strLotNO;
            //                            objLisAddItemRefArr[2].Value = p_objAdjustMedicineArr[iRow].m_strStorageID;
            //                            objLisAddItemRefArr[3].Value = p_objAdjustMedicineArr[iRow].m_dblOldRetailPrice;
            //                            objLisAddItemRefArr[4].Value = p_objAdjustMedicineArr[iRow].m_strInStorageID;
            //                            objLisAddItemRefArr[5].DbType = DbType.DateTime;
            //                            objLisAddItemRefArr[5].Value = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
            //                            objLisAddItemRefArr[6].Value = p_objAdjustMedicineArr[iRow].m_dblInPrice;

            //                            lngRes = objHRPServ.lngExecuteParameterSQL(strDelSQL, ref lngEff, objLisAddItemRefArr);
            //                        }

            //                        if (lngRes <= 0)
            //                        {
            //                            throw new Exception();
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime, DbType.Double };

            //                    object[][] objValues = new object[9][];

            //                    int intItemCount = p_objAdjustMedicineArr.Length;
            //                    for (int j = 0; j < objValues.Length; j++)
            //                    {
            //                        objValues[j] = new object[intItemCount];//初始化


            //                    }

            //                    for (int iRow = 0; iRow < intItemCount; iRow++)
            //                    {
            //                        objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblNewRetailPrice;
            //                        objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_strAdjustManID;
            //                        objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_dtmAdjustDate;
            //                        objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                        objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strLotNO;
            //                        objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_strInStorageID;
            //                        objValues[6][iRow] = p_objAdjustMedicineArr[iRow].m_strStorageID;
            //                        objValues[7][iRow] = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
            //                        objValues[8][iRow] = p_objAdjustMedicineArr[iRow].m_dblInPrice;
            //                    }
            //                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strAddSQL, objValues, ref lngEff, dbTypes);

            //                    if (lngRes >= 0) //if (lngRes > 0 && lngEff == intItemCount)
            //                    {
            //                        dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Double, DbType.String, DbType.DateTime, DbType.Double };

            //                        objValues = new object[7][];

            //                        for (int j = 0; j < objValues.Length; j++)
            //                        {
            //                            objValues[j] = new object[intItemCount];//初始化


            //                        }

            //                        for (int iRow = 0; iRow < intItemCount; iRow++)
            //                        {
            //                            objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
            //                            objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_strLotNO;
            //                            objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strStorageID;
            //                            objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_dblOldRetailPrice;
            //                            objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strInStorageID;
            //                            objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
            //                            objValues[6][iRow] = p_objAdjustMedicineArr[iRow].m_dblInPrice;
            //                        }
            //                        lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strDelSQL, objValues, ref lngEff, dbTypes);

            //                        //if (lngEff < intItemCount)
            //                        //{
            //                        //    throw new Exception();
            //                        //}
            //                    }
            //                    else
            //                    {
            //                        throw new Exception();
            //                    }
            //                }
            //                #endregion
            //            }
            //            catch (Exception objEx)
            //            {
            //                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
            //                bool blnRes = objLogger.LogError(objEx);
            //            }
            //            return lngRes;
            #endregion
        }

        #endregion

        #region 修改药品调价记录
        /// <summary>
        /// 修改药品调价记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArr">药品调价记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStoragePrice(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnIsDiffLotNO, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {
            if (p_objAdjustMedicineArr == null || p_objAdjustMedicineArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, p_blnIsDiffLotNO, p_objAdjustMedicineArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 设置审核
        /// <summary>
        /// 设置审核
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">审核者ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ms_adjustprice
                                       set examerid_chr = ?, examdate_dat = sysdate, formstate_int = 2
                                     where seriesid_int = ?
                                       and formstate_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        //objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        //objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[1].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;

                        objValues[1][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if(lngEff != intItemCount)
                    {
                        ContextUtil.SetAbort();
                        lngRes = -1;
                    }
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

        #region 设置药房调价审核
        /// <summary>
        /// 设置药房调价审核
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">审核者ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetDsCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice
   set examerid_chr = ?, examdate_dat = sysdate,status_int = 2
 where msseriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        //objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        //objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[1].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;

                        objValues[1][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 设置入帐
        /// <summary>
        /// 设置入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAdjustIDArr">调价单据号</param>
        /// <param name="p_strExamerID">入帐者ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmCommitDate">入帐时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strAdjustIDArr, string p_strExamerID, string p_strStorageID, DateTime p_dtmCommitDate)
        {
            if (p_strAdjustIDArr == null || p_strAdjustIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ms_adjustprice
                                       set inaccountid_chr = ?, inaccountdate_dat = ?, formstate_int = 3
                                     where adjustpriceid_vchr = ?
                                       and storageid_chr = ?
                                       and formstate_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_strAdjustIDArr.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[2].Value = p_strAdjustIDArr[iSEQ];
                        objLisAddItemRefArr[3].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String, DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_strAdjustIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;
                        objValues[1][iRow] = p_dtmCommitDate;
                        objValues[2][iRow] = p_strAdjustIDArr[iRow];
                        objValues[3][iRow] = p_strStorageID;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff != intItemCount)
                    {
                        lngRes = -1;
                        ContextUtil.SetAbort();
                    }
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

        /// <summary>
        /// 设置入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">入帐者ID</param>
        /// <param name="p_dtmCommitDate">入帐时间</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ms_adjustprice
                                       set inaccountid_chr = ?, inaccountdate_dat = ?, formstate_int = 3
                                     where seriesid_int = ?
                                       and formstate_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[2].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;
                        objValues[1][iRow] = p_dtmCommitDate;
                        objValues[2][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if(lngEff != intItemCount)
                    {
                        lngRes = -1;
                        ContextUtil.SetAbort();
                    }

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

        #region 设置药房入帐
        /// <summary>
        /// 设置药房入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">入帐者ID</param>
        /// <param name="p_dtmCommitDate">入帐时间</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetDsAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice
   set inaccountid_chr = ?, inaccountdate_dat = ?,status_int = 3
 where msseriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strExamerID;
                        objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        objLisAddItemRefArr[1].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[2].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strExamerID;
                        objValues[1][iRow] = p_dtmCommitDate;
                        objValues[2][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 设置药房退审

        /// <summary>
        /// 设置药房退审

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetDsUnCommit(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice
   set status_int = 1,examerid_chr = null
 where msseriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                //DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        throw new Exception();
                    }
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

        #region 设置退审

        /// <summary>
        /// 设置退审

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetUnCommit(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ)
        {
            if (p_lngMainSEQ == null || p_lngMainSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_adjustprice
   set formstate_int = 1,examerid_chr = null
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                //DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_lngMainSEQ.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_lngMainSEQ[iSEQ];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngMainSEQ.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngMainSEQ[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception();
                    }
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

        #region 审核药品调价
        /// <summary>
        /// 审核药品调价
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strExamerID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <param name="p_objAdjustMedicineArr">药品调价记录</param>
        /// <param name="p_blnIsImmAccount">是否保存即审核</param>
        /// <param name="p_blnIsChangeBase">是否同时调整字典表零售价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitAdjustPrice(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID, DateTime p_dtmCommitDate, 
        clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr, bool p_blnIsImmAccount, bool p_blnIsChangeBase)
        {
            long lngRes = 0;
            List<clsDS_MedicineInfoForAdjustPrice> objMedInfoList = new List<clsDS_MedicineInfoForAdjustPrice>();
            try
            {
                clsAdjustment_Supported_SVC objSelect = new clsAdjustment_Supported_SVC();
                lngRes = m_lngModifyStoragePrice(p_objPrincipal, false, p_objAdjustMedicineArr);

                if (lngRes < 0)
                {
                    return -1;
                }
                if (p_blnIsChangeBase)
                {
                    lngRes = objSelect.m_lngGetDsAdjustMedInfoList(p_objPrincipal, p_lngMainSEQ, out objMedInfoList);
                    if (lngRes < 0)
                    {
                        throw new Exception();
                    }
                    lngRes = m_lngModifyDsStorageMedicinePrice(p_objPrincipal, p_strExamerID, p_dtmCommitDate, objMedInfoList.ToArray());
                    if (lngRes < 0)
                    {
                        throw new Exception();
                    }
                }
                lngRes = m_lngModifyAdjustCurrentGross(p_objPrincipal, p_objAdjustMedicineArr);
                if (lngRes < 0)
                {
                    throw new Exception();
                }
                if (p_blnIsChangeBase)
                {
                    lngRes = m_lngModifyDsAdjustCurrentGross(p_objPrincipal, objMedInfoList.ToArray());
                    if (lngRes < 0)
                    {
                        throw new Exception();
                    }
                }
                lngRes = m_lngSetCommitUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);

                if (lngRes <= 0)
                {
                    throw new Exception();
                }
                if (p_blnIsChangeBase)
                {
                    lngRes = m_lngSetDsCommitUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);

                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }
                if (p_objAdjustMedicineArr != null && p_objAdjustMedicineArr.Length > 0)
                {
                    lngRes = m_lngAddDataToAccountDetail(p_objPrincipal,p_lngMainSEQ, p_objAdjustMedicineArr, p_blnIsImmAccount, p_strExamerID, p_dtmCommitDate);
                    if (lngRes < 0)
                    {
                        ContextUtil.SetAbort();

                        throw new Exception();
                    }
                    if (p_blnIsChangeBase)
                    {
                        lngRes = this.m_lngAddDataToDsAccountDetail(p_objPrincipal, objMedInfoList.ToArray(), p_blnIsImmAccount, p_strExamerID, p_dtmCommitDate, 0);
                        if (lngRes < 0)
                        {
                            throw new Exception();
                        }
                    }
                    Hashtable hstMedicineID = new Hashtable();
                    Hashtable hstWholeSalePrice = new Hashtable();
                    Hashtable hstTreatePrice = new Hashtable();
                    if (p_blnIsChangeBase)
                    {
                        for (int iMe = 0; iMe < p_objAdjustMedicineArr.Length; iMe++)
                        {
                            if (!hstMedicineID.Contains(p_objAdjustMedicineArr[iMe].m_strMedicineID))
                            {
                                hstMedicineID.Add(p_objAdjustMedicineArr[iMe].m_strMedicineID, p_objAdjustMedicineArr[iMe].m_dblNewRetailPrice);
                                hstWholeSalePrice.Add(p_objAdjustMedicineArr[iMe].m_strMedicineID, p_objAdjustMedicineArr[iMe].m_dblNewWholeSalePrice);
                                hstTreatePrice.Add(p_objAdjustMedicineArr[iMe].m_strMedicineID,p_objAdjustMedicineArr[iMe].m_dblInPrice);
                            }
                        }
                        lngRes = m_lngSetMedicineBasePrice(p_strExamerID, p_dtmCommitDate, hstMedicineID, hstWholeSalePrice,hstTreatePrice);
                    }
                }

                if (p_blnIsImmAccount)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                    if (p_blnIsChangeBase)
                    {
                        lngRes = m_lngSetDsAccountUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);
                        if (lngRes <= 0)
                        {
                            throw new Exception();
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

        /// <summary>
        /// 设置药品基本表零售价
        /// </summary>
        /// <param name="p_strExamerID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <param name="p_hstMedicine">药品</param>
        /// <param name="p_hstWholeSalePrice">批发价</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetMedicineBasePrice(string p_strExamerID, DateTime p_dtmCommitDate, Hashtable p_hstMedicine, Hashtable p_hstWholeSalePrice, Hashtable p_hstTreatePrice)
        {
            if (p_hstMedicine == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;

                string strSQL = @"insert into t_bse_medicine_history
  (medicineid_chr,
   modifydate_dat,
   modifyuserid_chr,
   packqty_dec,
   tradeprice_mny,
   unitprice_mny,
   ipunitprice_mny,
   opchargeflg_int,
   ipchargeflg_int,
   opunit_chr,
   ipunit_chr,wholesaleprice_mny)
  select t.medicineid_chr,
         ?,
         ?,
         t.packqty_dec,
         t.tradeprice_mny,
         t.unitprice_mny,
         t.ipunitprice_mny,
         t.opchargeflg_int,
         t.ipchargeflg_int,
         t.opunit_chr,
         t.ipunit_chr,t.wholesaleprice_mny
    from t_bse_medicine t
   where t.medicineid_chr = ?";

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].DbType = DbType.DateTime;
                        objLisAddItemRefArr[0].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[1].Value = p_strExamerID;
                        objLisAddItemRefArr[2].Value = key.ToString();

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_hstMedicine.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    int iRow = 0;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objValues[0][iRow] = p_dtmCommitDate;
                        objValues[1][iRow] = p_strExamerID;
                        objValues[2][iRow] = key.ToString();
                        iRow++;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception();
                    }
                }

                strSQL = @"update t_bse_medicine t set t.unitprice_mny = ?, t.ipunitprice_mny=?,t.TRADEPRICE_MNY = ?, t.wholesaleprice_mny= ? where t.medicineid_chr = ?";
                string strSQL1 = @"select a.packqty_dec from t_bse_medicine a where a.medicineid_chr=?";
                DataTable dtTemp = new DataTable();
                double m_dblIpUnitPrice = 0d;
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        m_dblIpUnitPrice = 0d;
                        objLisAddItemRefArr = null;
                        objHRPServ.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = key.ToString();
                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL1, ref dtTemp, objLisAddItemRefArr);
                        if (lngRes > 0 && dtTemp.Rows.Count > 0)
                        {
                            m_dblIpUnitPrice = Convert.ToDouble(Convert.ToDouble(((double)p_hstMedicine[key] / Convert.ToDouble(dtTemp.Rows[0][0]))).ToString("0.0000"));
                        }
                        objLisAddItemRefArr = null;
                        objHRPServ.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = (double)p_hstMedicine[key];
                        objLisAddItemRefArr[1].Value = m_dblIpUnitPrice;
                        objLisAddItemRefArr[2].Value = (double)p_hstTreatePrice[key];
                        objLisAddItemRefArr[3].Value = (double)p_hstWholeSalePrice[key];
                        objLisAddItemRefArr[4].Value = key.ToString(); 

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }
                    }
                }

                strSQL = @"update t_bse_chargeitem t set t.itemprice_mny= ?, t.tradeprice_mny = ? where t.itemsrcid_vchr = ?";

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = (double)p_hstMedicine[key];
                        objLisAddItemRefArr[1].Value = (double)p_hstTreatePrice[key];
                        objLisAddItemRefArr[2].Value = key.ToString();

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String };
                    object[][] objValues = new object[3][];

                    int intItemCount = p_hstMedicine.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }
                    int iRow = 0;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objValues[0][iRow] = (double)p_hstMedicine[key];
                        objValues[1][iRow] = (double)p_hstTreatePrice[key];
                        objValues[2][iRow] = key.ToString();
                        iRow++;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues, ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception();
                    }
                }
                //                strSQL = @"update  t_ds_storage_detail
                //                               set opretailprice_int = ?,
                //                                   adjustpriceman_chr = ?,
                //                                   adjustpricedate_dat = ?
                //                             where medicineid_chr = ?";
                //                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                //                {
                //                    IDataParameter[] objLisAddItemRefArr = null;
                //                    foreach (Object keys in p_hstMedicine)
                //                    {
                //                        objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //                        objLisAddItemRefArr[0].DbType = DbType.Double;
                //                        objLisAddItemRefArr[0].Value = (double)p_hstMedicine[keys];
                //                        objLisAddItemRefArr[1].Value = p_strExamerID;
                //                        objLisAddItemRefArr[2].Value = p_dtmCommitDate;
                //                        objLisAddItemRefArr[3].Value = keys.ToString();

                //                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                //                    }
                //                }
                //                else
                //                {
                //                    DbType[] dbtypes = new DbType[] { DbType.Double, DbType.String, DbType.DateTime, DbType.String };

                //                    object[][] objValues = new object[4][];
                //                    for (int i1 = 0; i1 < objValues.Length; i1++)
                //                    {
                //                        objValues[i1] = new object[p_hstMedicine.Count];
                //                    }

                //                    int iRow = 0;
                //                    foreach (Object keys in p_hstMedicine.Keys)
                //                    {
                //                        objValues[0][iRow] = (double)p_hstMedicine[keys];
                //                        objValues[1][iRow] = p_strExamerID;
                //                        objValues[2][iRow] = p_dtmCommitDate;
                //                        objValues[3][iRow] = keys.ToString();
                //                        iRow++;
                //                    }

                //                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbtypes);
                //                }
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

        #region 退审药品调价
        /// <summary>
        /// 退审药品调价

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_objAdjustMedicineArrWithLotNO">药品调价记录</param>
        /// <param name="p_strAdjustIDArr">调价单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strUserID">退审人ID</param>
        /// <param name="p_dtmUnCommitDate">退审时间</param>
        /// <param name="p_blnIsChangeBase">是否修改字典表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommitAdjustPrice(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithLotNO, string[] p_strAdjustIDArr, string p_strStorageID, string p_strUserID, DateTime p_dtmUnCommitDate, bool p_blnIsChangeBase)
        {
            long lngRes = 0;
            try
            {
                clsAdjustment_Supported_SVC objSelect = new clsAdjustment_Supported_SVC();
                lngRes = m_lngModifyStoragePrice(p_objPrincipal, false, p_objAdjustMedicineArrWithLotNO);
                if (lngRes < 0)
                {
                    throw new Exception();
                }
                List<clsDS_MedicineInfoForAdjustPrice> objMedInfoList = new List<clsDS_MedicineInfoForAdjustPrice>();
                lngRes = objSelect.m_lngGetDsAdjustMedInfoList(p_objPrincipal, p_lngMainSEQ, out objMedInfoList);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }
                lngRes = m_lngModifyDsStorageMedicinePrice(p_objPrincipal, p_strUserID, p_dtmUnCommitDate, objMedInfoList.ToArray());
                if (lngRes <= 0)
                {
                    throw new Exception();
                }
                if (lngRes > 0)
                {
                    lngRes = m_lngSetUnCommit(p_objPrincipal, p_lngMainSEQ);
                    if (lngRes < 0)
                    {
                        throw new Exception();
                    }
                    lngRes = m_lngSetDsUnCommit(p_objPrincipal, p_lngMainSEQ);
                }

                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                lngRes = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strAdjustIDArr, p_strStorageID);
                if (lngRes < 0)
                {
                    throw new Exception();
                }
                lngRes = objAccSVC.m_lngSetDsAccountDetailInvalid(p_objPrincipal, p_strAdjustIDArr);
                objAccSVC = null;
                if (lngRes < 0)
                {
                    throw new Exception();
                }

                if (p_blnIsChangeBase)
                {
                    Hashtable hstBase = new Hashtable();
                    Hashtable hstWholeSalePrice = new Hashtable();
                    Hashtable hstReatPrice = new Hashtable();
                    for (int iRow = 0; iRow < p_objAdjustMedicineArrWithLotNO.Length; iRow++)
                    {
                        if (!hstBase.Contains(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID))
                        {
                            hstBase.Add(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID, p_objAdjustMedicineArrWithLotNO[iRow].m_dblNewRetailPrice);
                            hstWholeSalePrice.Add(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID, p_objAdjustMedicineArrWithLotNO[iRow].m_dblNewWholeSalePrice);
                            hstReatPrice.Add(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID,p_objAdjustMedicineArrWithLotNO[iRow].m_dblInPrice);
                        }
                    }
                    lngRes = m_lngSetMedicineBasePrice(p_strUserID, p_dtmUnCommitDate, hstBase, hstWholeSalePrice, hstReatPrice);
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

        #region 添加数据至帐本明细


        /// <summary>
        /// 添加数据至帐本明细(调价分批号)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArrWithLotNO">分批号的药品调价记录</param>
        /// <param name="p_blnIsImmAcount">是否即入帐</param>
        /// <param name="p_strExamerID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddDataToAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithLotNO, bool p_blnIsImmAcount, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_objAdjustMedicineArrWithLotNO == null || p_objAdjustMedicineArrWithLotNO.Length == 0)
            {
                return -1;
            }
            List<clsMS_MedicineInfoForAdjustPrice> lisHasGrossMedInfoForAdjustPrice = new List<clsMS_MedicineInfoForAdjustPrice>();
            List<clsMS_MedicineInfoForAdjustPrice> lisHasNotGrossMedInfoForAdjustPrice = new List<clsMS_MedicineInfoForAdjustPrice>();
            for (int i = 0; i < p_objAdjustMedicineArrWithLotNO.Length; i++)
            {
                if (p_objAdjustMedicineArrWithLotNO[i].m_intHasGross == 1)
                    lisHasGrossMedInfoForAdjustPrice.Add(p_objAdjustMedicineArrWithLotNO[i]);
                else
                    lisHasNotGrossMedInfoForAdjustPrice.Add(p_objAdjustMedicineArrWithLotNO[i]);
            }
            long lngRes = -1;
            if (lisHasGrossMedInfoForAdjustPrice.Count > 0)
            {
                try
                {
                    string strSQL = @"insert into t_ms_account_detail t
                                              (t.seriesid_int, t.storageid_chr, t.medicineid_chr, t.medicinename_vch,
                                               t.medicinetypeid_chr, t.medspec_vchr, t.opunit_chr, t.instorageid_vchr,
                                               t.lotno_vchr, t.callprice_int, t.wholesaleprice_int, t.retailprice_int,
                                               t.amount_int, t.deptid_chr, t.type_int, t.oldgross_int, t.endamount_int,
                                               t.endcallprice_int, t.endwholesaleprice_int, t.endretailprice_int,
                                               t.chittyid_vchr, t.formtype_int, t.state_int, t.inaccountid_chr,
                                               t.inaccountdate_dat, t.accountid_chr, t.isend_int, t.newretailprice_int,
                                               t.operatedate_dat, t.validperiod_dat, t.newwholesaleprice_int,
                                               t.newallgross_int)
                                              select seq_ms_account_detail.nextval, a.storageid_chr, a.medicineid_chr,
                                                     a.medicinename_vchr, d.medicinetypeid_chr, a.medspec_vchr,
                                                     a.opunit_vchr, a.instorageid_vchr, a.lotno_vchr, a.callprice_int,
                                                     a.wholesaleprice_int, b.oldretailprice_int, a.realgross_int,
                                                     a.vendorid_chr, 0, a.realgross_int, null, null, null, null,
                                                     c.adjustpriceid_vchr, 0, ?, ?, ?, null, 0, b.newretailprice_int,
                                                     sysdate, a.validperiod_dat, b.newwholesaleprice_int,
                                                     nvl(curgross, 0) as curgorss
                                                from t_ms_storage_detail a
                                               inner join t_ms_adjustprice_detail b on a.medicineid_chr =
                                                                                       b.medicineid_chr
                                                                                   and a.instorageid_vchr =
                                                                                       b.instorageid_vchr
                                                                                   and a.lotno_vchr = b.lotno_vchr
                                                                                   and a.validperiod_dat =
                                                                                       b.validperiod_dat
                                                                                   and a.callprice_int =
                                                                                       b.callprice_int
                                                                                   and b.status_int = 1
                                               inner join t_ms_adjustprice c on b.seriesid2_int = c.seriesid_int
                                                                            and c.formstate_int = 2
                                                                            and a.storageid_chr = c.storageid_chr
                                               inner join t_bse_medicine d on a.medicineid_chr = d.medicineid_chr
                                               inner join (select sum(t.realgross_int) as curgross, t.medicineid_chr,
                                                                  t.storageid_chr
                                                             from t_ms_storage_detail t
                                                            where t.status = 1
                                                            group by t.medicineid_chr, t.storageid_chr) te on te.storageid_chr =
                                                                                                              a.storageid_chr
                                                                                                          and te.medicineid_chr =
                                                                                                              a.medicineid_chr
                                               where b.seriesid_int = ?
                                                 and a.status = 1";

                    int intState = p_blnIsImmAcount ? 1 : 2;
                    string strAccUser = p_blnIsImmAcount ? p_strExamerID : string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                    long lngEff = -1;

                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.String, DbType.DateTime, DbType.Int64};

                    object[][] objValues = new object[dbTypes.Length][];

                    int intItemCount = lisHasGrossMedInfoForAdjustPrice.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = intState;
                        objValues[1][iRow] = strAccUser;
                        if (p_blnIsImmAcount)
                        {
                            objValues[2][iRow] = p_dtmCommitDate;
                        }
                        else
                        {
                            objValues[2][iRow] = DBNull.Value;
                        }
                        objValues[3][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_lngSeriesID; 
                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            if (lisHasNotGrossMedInfoForAdjustPrice.Count > 0)
            {
                try
                {
                    string strSQL = @"insert into t_ms_account_detail t
                                      (t.seriesid_int, t.storageid_chr, t.medicineid_chr, t.medicinename_vch,
                                       t.medicinetypeid_chr, t.medspec_vchr, t.opunit_chr, t.instorageid_vchr,
                                       t.lotno_vchr, t.callprice_int, t.wholesaleprice_int, t.retailprice_int,
                                       t.amount_int, t.deptid_chr, t.type_int, t.oldgross_int, t.endamount_int,
                                       t.endcallprice_int, t.endwholesaleprice_int, t.endretailprice_int,
                                       t.chittyid_vchr, t.formtype_int, t.state_int, t.inaccountid_chr,
                                       t.inaccountdate_dat, t.accountid_chr, t.isend_int, t.newretailprice_int,
                                       t.operatedate_dat, t.validperiod_dat, t.newwholesaleprice_int,t.newallgross_int)
                                    values
                                      (seq_ms_account_detail.nextval, ?, ?, ?, ?, ?, ?, null, null, null, null,
                                       ?, 0, null, 0, 0, null, null, null, null, ?, 0, ?, ?, ?, null, 0, ?,
                                       sysdate, null, ?,
                                       (select sum(t.realgross_int) as curgross
                                           from t_ms_storage_detail t
                                          where t.status = 1
                                            and t.medicineid_chr = ?
                                            and t.storageid_chr = ?
                                          group by t.medicineid_chr, t.storageid_chr))";

                    int intState = p_blnIsImmAcount ? 1 : 2;
                    string strAccUser = p_blnIsImmAcount ? p_strExamerID : string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();
                    long lngEff = -1;

                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, 
                    DbType.String, DbType.String, DbType.Double, DbType.String, DbType.Int16, DbType.String,
                    DbType.DateTime, DbType.Double, DbType.Double,DbType.String, DbType.String };

                    object[][] objValues = new object[dbTypes.Length][];

                    int intItemCount = lisHasNotGrossMedInfoForAdjustPrice.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strStorageID;
                        objValues[1][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineID;
                        objValues[2][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineName;
                        objValues[3][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineTypeid;
                        objValues[4][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineSpec;
                        objValues[5][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strOPunit;
                        objValues[6][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblOldRetailPrice;
                        objValues[7][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strAdjustPriceid;
                        objValues[8][iRow] = intState;
                        objValues[9][iRow] = strAccUser;
                        if (p_blnIsImmAcount)
                        {
                            objValues[10][iRow] = p_dtmCommitDate;
                        }
                        else
                        {
                            objValues[10][iRow] = DBNull.Value;
                        }
                        objValues[11][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblNewRetailPrice;
                        objValues[12][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblNewWholeSalePrice;
                        objValues[13][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineID;
                        objValues[14][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strStorageID;
                        

                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception();
                    }
                    objHRPServ.Dispose();
                    objHRPServ = null;

                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 添加数据至药房帐本明细


        /// <summary>
        /// 添加数据至药房帐本明细（不分批号）

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArrWithOutLotNO">不分批号的药品调价记录</param>
        /// <param name="p_blnIsImmAcount">是否即入帐</param>
        /// <param name="p_strExamerID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddDataToDsAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithOutLotNO, bool p_blnIsImmAcount, string p_strExamerID, DateTime p_dtmCommitDate, long m_lngSERIESID_INT)
        {
            if (p_objAdjustMedicineArrWithOutLotNO == null)
            {
                return -1;
            }
            if (p_objAdjustMedicineArrWithOutLotNO.Length == 0)
            {
                return 1;
            }
            List<clsDS_MedicineInfoForAdjustPrice> lisHasGrossMedInfoForAdjustPrice = new List<clsDS_MedicineInfoForAdjustPrice>();
            List<clsDS_MedicineInfoForAdjustPrice> lisHasNotGrossMedInfoForAdjustPrice = new List<clsDS_MedicineInfoForAdjustPrice>();

            //20091029:一个药品只需要执行一次
            //20091211:必须每个药房都要执行一次
            Hashtable hstSameMedID = new Hashtable();            

            for (int i = 0; i < p_objAdjustMedicineArrWithOutLotNO.Length; i++)
            {
                if(p_objAdjustMedicineArrWithOutLotNO[i].m_intHasGross == 1)
                {
                    if(hstSameMedID.ContainsKey(p_objAdjustMedicineArrWithOutLotNO[i].m_strMedicineID))
                        continue;
                    lisHasGrossMedInfoForAdjustPrice.Add(p_objAdjustMedicineArrWithOutLotNO[i]);
                    hstSameMedID.Add(p_objAdjustMedicineArrWithOutLotNO[i].m_strMedicineID, null);                    
                }
                else
                    lisHasNotGrossMedInfoForAdjustPrice.Add(p_objAdjustMedicineArrWithOutLotNO[i]);
            }
            long lngRes = -1;
            if (lisHasGrossMedInfoForAdjustPrice.Count > 0)
            {
                try
                {
                    string strSQL = @"insert into t_ds_account_detail t
  (t.seriesid_int,
   t.drugstoreid_int,
   t.medicineid_chr,
   t.medicinename_vchr,
   t.medicinetypeid_chr,
   t.medspec_vchr,
   t.opunit_chr,
   t.ipunit_chr,
   t.instoreid_vchr,
   t.lotno_vchr,
   t.ipwholesaleprice_int,
   t.opwholesaleprice_int,
   t.ipretailprice_int,
   t.opretailprice_int,
   t.instoragedate_dat,
   t.ipamount_int,
   t.opamount_int,
   t.deptid_chr,
   t.ipoldgross_int,
   t.opoldgross_int,
   t.type_int,
   t.endipamount_int,
   t.endopamount_int,
   t.endipwholesaleprice_int,
   t.endopwholesaleprice_int,
   t.endipretailprice_int,
   t.endopretailprice_int,
   t.chittyid_vchr,
   t.formtype_int,
   t.state_int,
   t.inaccountid_chr,
   t.inaccountdate_dat,
   t.accountid_chr,
   t.isend_int,
   t.productorid_chr,
   t.validperiod_dat,
   t.operatedate_dat,
   t.ipnewretailprice_int,
   t.opnewretailprice_int,t.packqty_dec)
  select seq_ds_account_detail.nextval,
         a.drugstoreid_chr,
         a.medicineid_chr,
         a.medicinename_vchr,
         d.medicinetypeid_chr,
         a.medspec_vchr,
         a.opunit_chr,
         a.ipunit_chr,
         a.dsinstoreid_vchr,
         a.lotno_vchr,
         a.ipwholesaleprice_int,
         a.opwholesaleprice_int,
         b.ipoldretailprice_int,
         b.opoldretailprice_int,
         a.instoragedate_dat,
         a.iprealgross_int,
         a.oprealgross_int,
         a.drugstoreid_chr,
         a.iprealgross_int,
         a.oprealgross_int,
         0,
         null,
         null,
         null,
         null,
         null,
         null,
         c.adjustpriceid_vchr,
         0,
         ?,
         ?,
         ?,
         null,
         0,
         a.productorid_chr,
         a.validperiod_dat,
         sysdate,
         ?,
         ?,?
    from t_ds_storage_detail a
   inner join t_ds_adjustprice_detail b on a.medicineid_chr =
                                           b.medicineid_chr
                                       and a.drugstoreid_chr =
                                           b.drugstoreid_chr
                                       and b.status_int = 1
                                       and b.lotno_vchr = a.lotno_vchr
                                       and b.validperiod_dat = a.validperiod_dat
   inner join t_ds_adjustprice c on b.seriesid2_int = c.seriesid_int
   inner join t_bse_medicine d on a.medicineid_chr = d.medicineid_chr
   where b.medicineid_chr = ? 
     and a.status = 1 and c.seriesid_int=?";


                    int intState = p_blnIsImmAcount ? 1 : 2;
                    string strAccUser = p_blnIsImmAcount ? p_strExamerID : string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();


                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.String, DbType.DateTime, DbType.Double, DbType.Double, DbType.Double, DbType.String,DbType.Int64 };

                    object[][] objValues = new object[8][];

                    int intItemCount = lisHasGrossMedInfoForAdjustPrice.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = intState;
                        objValues[1][iRow] = strAccUser;
                        objValues[2][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_dtmValidDate;

                        objValues[3][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_dblIPNewRetailPrice;
                        objValues[4][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_dblOPNewRetailPrice;
                        objValues[5][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_dblPACKQTY_DEC;
                        objValues[6][iRow] = lisHasGrossMedInfoForAdjustPrice[iRow].m_strMedicineID;                        
                        objValues[7][iRow] = m_lngSERIESID_INT;

                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    objHRPServ.Dispose();
                    objHRPServ = null;

                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            if (lisHasNotGrossMedInfoForAdjustPrice.Count > 0)
            {
                try
                {
                    string strSQL = @"insert into t_ds_account_detail t
  (t.seriesid_int,
   t.drugstoreid_int,
   t.medicineid_chr,
   t.medicinename_vchr,
   t.medicinetypeid_chr,
   t.medspec_vchr,
   t.opunit_chr,
   t.ipunit_chr,
   t.instoreid_vchr,
   t.lotno_vchr,
   t.ipwholesaleprice_int,
   t.opwholesaleprice_int,
   t.ipretailprice_int,
   t.opretailprice_int,
   t.instoragedate_dat,
   t.ipamount_int,
   t.opamount_int,
   t.deptid_chr,
   t.ipoldgross_int,
   t.opoldgross_int,
   t.type_int,
   t.endipamount_int,
   t.endopamount_int,
   t.endipwholesaleprice_int,
   t.endopwholesaleprice_int,
   t.endipretailprice_int,
   t.endopretailprice_int,
   t.chittyid_vchr,
   t.formtype_int,
   t.state_int,
   t.inaccountid_chr,
   t.inaccountdate_dat,
   t.accountid_chr,
   t.isend_int,
   t.productorid_chr,
   t.validperiod_dat,
   t.operatedate_dat,
   t.ipnewretailprice_int,
   t.opnewretailprice_int,t.packqty_dec)
values
  (seq_ds_account_detail.nextval,
   ?,
   ?,
   ?,
   ?,
   ?,
   ?,
   ?,
   null,
   null,
   null,
   null,
   ?,
   ?,
   null,
   0,
   0,
   ?,
   0,
   0,
   0,
   null,
   null,
   null,
   null,
   null,
   null,
   ?,
   0,
   ?,
   ?,
   ?,
   null,
   0,
   ?,
   null,
   sysdate,
   ?,
   ?,?)";

                    int intState = p_blnIsImmAcount ? 1 : 2;
                    string strAccUser = p_blnIsImmAcount ? p_strExamerID : string.Empty;

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    clsMS_Public_Supported_SVC objPublic = new clsMS_Public_Supported_SVC();

                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, 
                        DbType.String, DbType.String, DbType.Int16, DbType.String, DbType.DateTime, DbType.String, DbType.Double,
                        DbType.Double, DbType.Double };

                    object[][] objValues = new object[18][];

                    int intItemCount = lisHasNotGrossMedInfoForAdjustPrice.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strDrugStoreID;
                        objValues[1][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineID;
                        objValues[2][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineName;
                        objValues[3][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineTypeid;
                        objValues[4][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strMedicineSpec;
                        objValues[5][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strOPunit;
                        objValues[6][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strIPunit;
                        objValues[7][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblIPOldRetailPrice;
                        objValues[8][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblOPOldRetailPrice;
                        objValues[9][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strDrugStoreID;
                        objValues[10][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strAdjustPriceid;
                        objValues[11][iRow] = intState;
                        objValues[12][iRow] = strAccUser;
                        if (p_blnIsImmAcount)
                        {
                            objValues[13][iRow] = p_dtmCommitDate;
                        }
                        else
                        {
                            objValues[13][iRow] = DBNull.Value;
                        }
                        objValues[14][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_strProductor;

                        objValues[15][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblIPNewRetailPrice;
                        objValues[16][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblOPNewRetailPrice;
                        objValues[17][iRow] = lisHasNotGrossMedInfoForAdjustPrice[iRow].m_dblPACKQTY_DEC;

                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyIDArr">入库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与入库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入账日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInAccount(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate, bool m_blnChangeMedStore)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0 || p_lngMainSEQ == null || p_lngMainSEQ.Length == 0 || p_lngMainSEQ.Length != p_strChittyIDArr.Length)
            {
                return -1;
            }
            long lngRes = 0;

            try
            {
                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                lngRes = objAccSVC.m_lngRatifyAccountDetail(p_objPrincipal, p_strChittyIDArr, p_strStorageID, p_strEmpID, p_dtmAccountDate);
                if (lngRes < 0)
                {
                    throw new Exception();
                }
                if (m_blnChangeMedStore)
                {
                    lngRes = objAccSVC.m_lngRatifyDsAccountDetail(p_objPrincipal, p_strChittyIDArr, p_strEmpID, p_dtmAccountDate);
                }
                objAccSVC = null;

                if (lngRes >= 0)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_lngMainSEQ, p_strEmpID, p_dtmAccountDate);
                    if (lngRes < 0)
                    {
                        throw new Exception();
                    }
                    if (m_blnChangeMedStore)
                    {
                        lngRes = m_lngSetDsAccountUser(p_objPrincipal, p_lngMainSEQ, p_strEmpID, p_dtmAccountDate);
                        if (lngRes < 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    throw new Exception();
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

        #region 修改调价明细当前库存
        /// <summary>
        /// 修改调价明细当前库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineArr">调价药品</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngModifyAdjustCurrentGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineInfoForAdjustPrice[] p_objMedicineArr)
        {
            if (p_objMedicineArr == null || p_objMedicineArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_adjustprice_detail t
   set t.currentgross_int = (select s.realgross_int
                               from t_ms_storage_detail s
                              where s.medicineid_chr = ?
                                and s.lotno_vchr = ?
                                and s.instorageid_vchr = ?
                                and s.storageid_chr = ?
                                and s.callprice_int = ?
                                and s.validperiod_dat = ?
                                and s.status = 1)
 where t.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objMedicineArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                        objDPArr[0].Value = p_objMedicineArr[iRow].m_strMedicineID;
                        objDPArr[1].Value = p_objMedicineArr[iRow].m_strLotNO;
                        objDPArr[2].Value = p_objMedicineArr[iRow].m_strInStorageID;
                        objDPArr[3].Value = p_objMedicineArr[iRow].m_strStorageID;
                        objDPArr[4].Value = p_objMedicineArr[iRow].m_dblInPrice;
                        objDPArr[5].DbType = DbType.DateTime;
                        objDPArr[5].Value = p_objMedicineArr[iRow].m_dtmValidDate;
                        objDPArr[6].Value = p_objMedicineArr[iRow].m_lngAdjustDetaiSEQ;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[7][];

                    int intItemCount = p_objMedicineArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objMedicineArr[iRow].m_strMedicineID;
                        objValues[1][iRow] = p_objMedicineArr[iRow].m_strLotNO;
                        objValues[2][iRow] = p_objMedicineArr[iRow].m_strInStorageID;
                        objValues[3][iRow] = p_objMedicineArr[iRow].m_strStorageID;
                        objValues[4][iRow] = p_objMedicineArr[iRow].m_dblInPrice;
                        objValues[5][iRow] = p_objMedicineArr[iRow].m_dtmValidDate;
                        objValues[6][iRow] = p_objMedicineArr[iRow].m_lngAdjustDetaiSEQ;
                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

        #region 修改调价明细当前库存
        /// <summary>
        /// 修改调价明细当前库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineArr">调价药品</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngModifyDsAdjustCurrentGross(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_MedicineInfoForAdjustPrice[] p_objMedicineArr)
        {
            if (p_objMedicineArr == null)
            {
                return -1;
            }
            if (p_objMedicineArr.Length == 0)
            {
                return 1;
            }
            long lngRes = 0;
            try
            {
                //调价审核时update当前药房当前药品的库存量
                string strSQL = @"update t_ds_adjustprice_detail t
   set (t.ipcurrentgross_int, t.opcurrentgross_int) = (select sum(a.iprealgross_int) as iprealgross_int,
                                                              sum(round(a.iprealgross_int /
                                                                        a.packqty_dec,
                                                                        2)) as oprealgross_int
                                                         from t_ds_storage_detail a
                                                        where a.medicineid_chr = ?
                                                          and a.drugstoreid_chr = ?
                                                          and a.status = 1)
 where t.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objMedicineArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_objMedicineArr[iRow].m_strMedicineID;
                        objDPArr[1].Value = p_objMedicineArr[iRow].m_strDrugStoreID;
                        objDPArr[2].Value = p_objMedicineArr[iRow].m_lngAdjustDetaiSEQ;


                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.Double };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_objMedicineArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objMedicineArr[iRow].m_strMedicineID;
                        objValues[1][iRow] = p_objMedicineArr[iRow].m_strDrugStoreID;
                        objValues[2][iRow] = p_objMedicineArr[iRow].m_lngAdjustDetaiSEQ;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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
    }
}
