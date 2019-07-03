using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药品调价
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAdjustmentSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
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
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_VO p_objMain, clsDS_Adjustment_Detail[] p_objDetailArr,bool p_blnIsCommit,bool p_blnIsDiffLotNO,bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strAdjustID, out long[] p_lngSEQ)
        {
            p_lngMainSEQ = 0;
            p_strAdjustID = string.Empty;
            p_lngSEQ = null;
            if (p_objMain == null || p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_lngAddNewAdjustmentMain(p_objPrincipal, p_objMain, out p_lngMainSEQ, out p_strAdjustID);
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

                    //if (p_blnIsCommit)
                    //{
                    //    clsMS_MedicineInfoForAdjustPrice[] objAdjust = new clsMS_MedicineInfoForAdjustPrice[p_objDetailArr.Length];
                    //    for (int iPr = 0; iPr < p_objDetailArr.Length; iPr++)
                    //    {
                    //        objAdjust[iPr] = new clsMS_MedicineInfoForAdjustPrice();
                    //        objAdjust[iPr].m_dblNewRetailPrice = p_objDetailArr[iPr].m_dblNEWRETAILPRICE_INT;
                    //        objAdjust[iPr].m_dblOldRetailPrice = p_objDetailArr[iPr].m_dblOLDRETAILPRICE_INT;
                    //        objAdjust[iPr].m_dtmAdjustDate = p_objMain.m_dtmEXAMDATE_DAT;
                    //        objAdjust[iPr].m_strAdjustManID = p_objMain.m_strEXAMERID_CHR;
                    //        objAdjust[iPr].m_strLotNO = p_objDetailArr[iPr].m_strLOTNO_VCHR;
                    //        objAdjust[iPr].m_strMedicineID = p_objDetailArr[iPr].m_strMEDICINEID_CHR;
                    //        objAdjust[iPr].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                    //        objAdjust[iPr].m_dblInPrice = p_objDetailArr[iPr].m_dblCALLPRICE_INT;
                    //        objAdjust[iPr].m_dtmValidDate = p_objDetailArr[iPr].m_dtmVALIDPERIOD_DAT;
                    //    }

                    //    if (p_blnIsDiffLotNO)
                    //    {
                    //        lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, objAdjust);
                    //        if (lngRes <= 0)
                    //        {
                    //            throw new Exception();
                    //        }
                    //        lngRes = m_lngAddDataToAccountDetail(p_objPrincipal, objAdjust, p_blnIsImmAccount, p_objMain.m_strEXAMERID_CHR, p_objMain.m_dtmEXAMDATE_DAT);
                    //    }
                    //    else
                    //    {
                    //        //lngRes = m_lngModifyStorageMedicinePriceNoLotNO(p_objPrincipal, objAdjust);
                    //        if (lngRes <= 0)
                    //        {
                    //            throw new Exception();
                    //        }
                    //        //lngRes = m_lngAddDataToAccountDetailNoLotNO(p_objPrincipal, objAdjust, p_blnIsImmAccount, p_objMain.m_strEXAMERID_CHR, p_objMain.m_dtmEXAMDATE_DAT);
                    //    }

                    //    if (lngRes <= 0)
                    //    {
                    //        throw new Exception();
                    //    }

                    //    if (p_blnIsImmAccount)
                    //    {
                    //        long[] lngSEQArr = new long[] { p_lngMainSEQ };
                    //        lngRes = m_lngSetAccountUser(p_objPrincipal, lngSEQArr, p_objMain.m_strEXAMERID_CHR, p_objMain.m_dtmEXAMDATE_DAT);
                    //    }
                    //    if (lngRes <= 0)
                    //    {
                    //        throw new Exception();
                    //    }                     
                    //}
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
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_VO p_objMain, clsDS_Adjustment_Detail[] p_objDetailArr,bool p_blnIsCommit,bool p_blnIsDiffLotNO, out long[] p_lngSEQ)
        {
            p_lngSEQ = null;
            long lngRes = 0;
            if (p_objDetailArr == null || p_objDetailArr.Length == 0 || p_objMain == null)
            {
                return -1;
            }

            try
            {
                lngRes = m_lngModifyAdjustmentMain(p_objPrincipal, p_objMain);
                if (lngRes > 0)
                {
                    lngRes = m_lngSetAdjustmentDetailInvalid(p_objPrincipal, p_objMain.m_lngSERIESID_INT);
                    if (lngRes > 0)
                    {
                        lngRes = m_lngAddNewAdjustmentDetail(p_objPrincipal, p_objDetailArr, out p_lngSEQ);
                    }

                    //if (p_blnIsCommit)
                    //{
                    //    clsMS_MedicineInfoForAdjustPrice[] objAdjust = new clsMS_MedicineInfoForAdjustPrice[p_objDetailArr.Length];
                    //    for (int iPr = 0; iPr < p_objDetailArr.Length; iPr++)
                    //    {
                    //        objAdjust[iPr] = new clsMS_MedicineInfoForAdjustPrice();
                    //        objAdjust[iPr].m_dblNewRetailPrice = p_objDetailArr[iPr].m_dblNEWRETAILPRICE_INT;
                    //        objAdjust[iPr].m_dblOldRetailPrice = p_objDetailArr[iPr].m_dblOLDRETAILPRICE_INT;
                    //        objAdjust[iPr].m_dtmAdjustDate = p_objMain.m_dtmEXAMDATE_DAT;
                    //        objAdjust[iPr].m_strAdjustManID = p_objMain.m_strEXAMERID_CHR;
                    //        objAdjust[iPr].m_strLotNO = p_objDetailArr[iPr].m_strLOTNO_VCHR;
                    //        objAdjust[iPr].m_strMedicineID = p_objDetailArr[iPr].m_strMEDICINEID_CHR;
                    //        objAdjust[iPr].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                    //        objAdjust[iPr].m_dtmValidDate = p_objDetailArr[iPr].m_dtmVALIDPERIOD_DAT;
                    //        objAdjust[iPr].m_dblInPrice = p_objDetailArr[iPr].m_dblCALLPRICE_INT;
                    //    }

                    //    if (p_blnIsDiffLotNO)
                    //    {
                    //        lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, objAdjust);
                    //    }
                    //    else
                    //    {
                    //        //lngRes = m_lngModifyStorageMedicinePriceNoLotNO(p_objPrincipal, objAdjust);
                    //    }
                    //}
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
        public long m_lngAddNewAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_Detail[] p_objDetailArr, out long[] p_lngSEQ)
        {
            p_lngSEQ = null;
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
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
   ipunit_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                
                DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.Int64,DbType.String,DbType.String,DbType.String, DbType.String,
                        DbType.Double,DbType.Double,DbType.Double,DbType.Int64,DbType.Int64,DbType.Int64,DbType.Int64,DbType.String,DbType.Int16,DbType.DateTime,DbType.String,DbType.String};

                object[][] objValues = new object[18][];

                int intItemCount = p_objDetailArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                //20080301 lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "seq_ds_account_detail", intItemCount, out p_lngSEQ);
                if (p_lngSEQ == null || p_lngSEQ.Length == 0)
                {
                    return -1;
                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_lngSEQ[iRow];
                    objValues[1][iRow] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    //20080301 objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                    objValues[4][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                    objValues[6][iRow] = p_objDetailArr[iRow].m_dblIPCURRENTGROSS_INT;
                    objValues[7][iRow] = p_objDetailArr[iRow].m_dblOPCURRENTGROSS_INT;
                    objValues[8][iRow] = p_objDetailArr[iRow].m_dblPackage ;
                     objValues[9][iRow] = p_objDetailArr[iRow].m_dblIPOLDRETAILPRICE_INT ;
                     objValues[10][iRow] = p_objDetailArr[iRow].m_dblOPCURRENTGROSS_INT ;
                     objValues[11][iRow] = p_objDetailArr[iRow].m_dblIPNEWRETAILPRICE_INT  ;
                    objValues[12][iRow] = p_objDetailArr[iRow].m_dblOPNEWRETAILPRICE_INT;
                    objValues[13][iRow] = p_objDetailArr[iRow].m_strREASON_VCHR;
                    objValues[14][iRow] = p_objDetailArr[iRow].m_intSTATUS_INT;
                    objValues[15][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                    objValues[16][iRow] = p_objDetailArr[iRow].m_strOPUNIT_VCHR;
                    objValues[17][iRow] = p_objDetailArr[iRow].m_strIPUNIT_VCHR;
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
        public long m_lngAddNewAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_VO p_objMain, out long p_lngMainSEQ, out string p_strAdjustID)
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
                string strSQL = @"insert into t_ds_adjustprice
  (seriesid_int,
   drugstoreid_chr ,
   adjustpriceid_vchr,
   newdate_dat,
   status_int ,
   creatorid_chr,
   examerid_chr,
   inaccountid_chr,
   examdate_dat,
   inaccountdate_dat,
   comment_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "seq_ds_adjustprice", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_objMain.m_lngSERIESID_INT = lngSEQ;
                p_lngMainSEQ = lngSEQ;
                string m_strTempId = "";
                string strAdjustmentID = string.Empty;
                objPublic.m_lngGetNewIdByName(p_objPrincipal, "t_ds_adjustprice", "adjustpriceid_vchr", p_objMain.m_dtmNEWDATE_DAT, ref strAdjustmentID);
                p_objMain.m_strADJUSTPRICEID_VCHR = p_objMain.m_dtmNEWDATE_DAT.ToString("yyMMdd") + "08" + m_strTempId;
                if (string.IsNullOrEmpty(strAdjustmentID))
                {
                    return -1;
                }
                p_objMain.m_strADJUSTPRICEID_VCHR = strAdjustmentID;
                p_strAdjustID = strAdjustmentID;
                IDataParameter[] objDPArr = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                //20080301 objDPArr[1].Value = p_objMain.m_strDrugStoreid;
                objDPArr[2].Value = p_objMain.m_strADJUSTPRICEID_VCHR;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_objMain.m_dtmNEWDATE_DAT;
                objDPArr[4].Value = p_objMain.m_intFORMSTATE_INT;
                objDPArr[5].Value = p_objMain.m_strCREATORID_CHR;
                objDPArr[6].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[7].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[8].Value = p_objMain.m_dtmEXAMDATE_DAT;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[9].Value = p_objMain.m_dtmINACCOUNTDATE_DAT;
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[10].Value = p_objMain.m_strCOMMENT_VCHR;

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
        public long m_lngDeleteSpecAdjustmentDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, bool p_blnIsCommit, bool p_blnIsDiffLotNO,clsMS_MedicineInfoForAdjustPrice p_objAdjustMedicine)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice_detail set status_int = 0 where seriesid_int = ?";

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
                        if (p_blnIsDiffLotNO)
                        {
                            //20080301  lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, objAdjust);
                        }
                        else
                        {
                            //lngRes = m_lngModifyStorageMedicinePriceNoLotNO(p_objPrincipal, objAdjust);
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
                string strSQL = @"update t_ds_adjustprice_detail set status_int = -1 where seriesid2_int = ? and status_int = 1";

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
        public long m_lngDeleteAdjustment(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ)
        {
            if (p_lngSEQ == null || p_lngSEQ.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = "update t_ds_adjustprice set status_int  = 0 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
    

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
                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                lngRes = m_lngSetAdjustmentDetailInvalid(p_objPrincipal, p_lngSEQ);
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

        #region 修改调价主表内容
        /// <summary>
        /// 修改调价主表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">调价主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAdjustmentMain(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Adjustment_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_adjustprice
   set examerid_chr        = ?,
       inaccountid_chr     = ?,
       examdate_dat        = ?,
       inaccountdate_dat   = ?,
       comment_vchr        = ?
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();       

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
  
                objDPArr[0].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[1].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_objMain.m_dtmEXAMDATE_DAT;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_objMain.m_dtmINACCOUNTDATE_DAT;
                objDPArr[4].Value = p_objMain.m_strCOMMENT_VCHR;
                objDPArr[5].Value = p_objMain.m_lngSERIESID_INT;

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

        #region 修改库存药品零售价


        /// <summary>
        /// 修改库存药品零售价(分批号)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAdjustMedicineArr">调价药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageMedicinePrice(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {
            if (p_objAdjustMedicineArr == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strAddSQL = @"insert into t_ds_storage_detail
  (seriesid_int,
   drugstoreid_chr ,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   lotno_vchr,
   ipretailprice_int ,
   opretailprice_int ,
   iprealgross_int ,
   oprealgross_int ,
   opavailablegross_num ,
   ipavailablegross_num ,
   ipwholesaleprice_int ,
   opwholesaleprice_int, 
   opunit_vchr,
   ipunit_chr ,
   validperiod_dat,
   productorid_chr,
   instorageid_vchr,
   instoragedate_dat,
   dsinstoragedate_dat ,
   dsinstoreid_vchr ,
   status, 
   storagerackid_chr ,
   adjustpriceman_chr,
   adjustpricedate_dat)
  select seq_ds_storage_detail.nextval,
         t.drugstoreid_chr ,
         t.medicineid_chr,
         t.medicinename_vchr,
         t.medspec_vchr,
         t.lotno_vchr,
         ?,
         ?,
         t.iprealgross_int ,
         t.oprealgross_int ,
         t.opavailablegross_num ,
         t.ipavailablegross_num ,
         t.ipwholesaleprice_int  ,
         t.opwholesaleprice_int  ,
         t.opunit_vchr,
         t.ipunit_chr ,
         t.validperiod_dat,
         t.productorid_chr,
         t.instorageid_vchr,
         t.instoragedate_dat,
         t.dsinstoragedate_dat ,
         t.dsinstoreid_vchr ,
         1,
         storagerackid_chr
         ?,
         ?
    from t_ds_storage_detail t
   where t.medicineid_chr = ?
     and t.lotno_vchr = ?
     and t.instorageid_vchr = ?
     and t.drugstoreid_chr = ?
     and t.validperiod_dat = ?
     and t.status = 1";

                string strDelSQL = @"update t_ds_storage_detail t
   set t.status = 2
 where t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.drugstoreid_chr = ?
   and t.ipretailprice_int = ?
   and t.opretailprice_int = ?
   and t.instorageid_vchr = ?
   and t.validperiod_dat = ?
   and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                long lngEff = -1;

                #region 添加记录

                DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String, DbType.DateTime };

                object[][] objValues = new object[9][];

                int intItemCount = p_objAdjustMedicineArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化



                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPNewRetailPrice;
                    objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPNewRetailPrice;
                    objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strAdjustManID;
                    objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_dtmAdjustDate;
                    objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                    objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_strLotNO;
                    objValues[6][iRow] = p_objAdjustMedicineArr[iRow].m_strDrugStoreID;
                    objValues[7][iRow] = p_objAdjustMedicineArr[iRow].m_strInStorageID;
                    objValues[8][iRow] = p_objAdjustMedicineArr[iRow].m_dtmValidDate;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strAddSQL, objValues, ref lngEff, dbTypes);

                if (lngRes > 0 && lngEff == intItemCount)
                {
                    dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.Double, DbType.Double, DbType.String, DbType.DateTime };

                    objValues = new object[7][];

                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objAdjustMedicineArr[iRow].m_strMedicineID;
                        objValues[1][iRow] = p_objAdjustMedicineArr[iRow].m_strLotNO;
                        objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_strDrugStoreID;
                        objValues[2][iRow] = p_objAdjustMedicineArr[iRow].m_dblIPOldRetailPrice;
                        objValues[3][iRow] = p_objAdjustMedicineArr[iRow].m_dblOPOldRetailPrice;
                        objValues[4][iRow] = p_objAdjustMedicineArr[iRow].m_strInStorageID;
                        objValues[5][iRow] = p_objAdjustMedicineArr[iRow].m_dtmValidDate;

                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strDelSQL, objValues, ref lngEff, dbTypes);
                    
                    if (lngEff < intItemCount)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception();
                    }
                }
                else
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
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
            return lngRes;
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
        public long m_lngModifyStoragePrice(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr)
        {
            if (p_objAdjustMedicineArr == null || p_objAdjustMedicineArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_lngModifyStorageMedicinePrice(p_objPrincipal, p_objAdjustMedicineArr);
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
                string strSQL = @"update t_ds_adjustprice
   set examerid_chr = ?, examdate_dat = ?,status_int  = 2
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
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.DateTime,DbType.Int64};

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
                string strSQL = @"update t_ds_adjustprice
   set inaccountid_chr = ?, inaccountdate_dat = ?,status_int  = 3
 where adjustpriceid_vchr  = ? and drugstoreid_chr   = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
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
                string strSQL = @"update t_ds_adjustprice
   set status_int = 1, examerid_chr = null, examdate_dat = null
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
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
        public long m_lngCommitAdjustPrice(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngMainSEQ, string p_strExamerID,DateTime p_dtmCommitDate, clsDS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArr, bool p_blnIsImmAccount, bool p_blnIsChangeBase)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_lngModifyStoragePrice(p_objPrincipal, p_objAdjustMedicineArr);

                if (lngRes <= 0)
                {
                    return -1;
                }

                //20080301 lngRes = m_lngModifyAdjustCurrentGross(p_objPrincipal, p_objAdjustMedicineArr);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                lngRes = m_lngSetCommitUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);

                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                if (p_objAdjustMedicineArr != null && p_objAdjustMedicineArr.Length > 0)
                {
                    //20080301 lngRes = m_lngAddDataToAccountDetail(p_objPrincipal, p_objAdjustMedicineArr, p_blnIsImmAccount, p_strExamerID, p_dtmCommitDate);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    Hashtable hstMedicineID = new Hashtable();
                    if (p_blnIsChangeBase)
                    {
                        for (int iMe = 0; iMe < p_objAdjustMedicineArr.Length; iMe++)
                        {
                            if (!hstMedicineID.Contains(p_objAdjustMedicineArr[iMe].m_strMedicineID))
                            {
                                //20080301  hstMedicineID.Add(p_objAdjustMedicineArr[iMe].m_strMedicineID, p_objAdjustMedicineArr[iMe].m_dblNewRetailPrice);
                            }
                        }
                        lngRes = m_lngSetMedicineBasePrice(p_strExamerID, p_dtmCommitDate, hstMedicineID);
                    }                    
                }

                if (p_blnIsImmAccount)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_lngMainSEQ, p_strExamerID, p_dtmCommitDate);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
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
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSetMedicineBasePrice(string p_strExamerID, DateTime p_dtmCommitDate, Hashtable p_hstMedicine)
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
   ipunit_chr)
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
         t.ipunit_chr
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

                strSQL = @"update t_bse_medicine t set t.unitprice_mny = ? where t.medicineid_chr = ?";

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = (double)p_hstMedicine[key];
                        objLisAddItemRefArr[1].Value = key.ToString();

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
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.String };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_hstMedicine.Count;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    int iRow = 0;
                    foreach (object key in p_hstMedicine.Keys)
                    {
                        objValues[0][iRow] = (double)p_hstMedicine[key];
                        objValues[1][iRow] = key.ToString();
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

                strSQL = @"update  t_ds_storage_detail
                               set opretailprice_int = ?,
                                   adjustpriceman_chr = ?,
                                   adjustpricedate_dat = ?
                             where medicineid_chr = ?";
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    foreach (Object keys in p_hstMedicine)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].DbType = DbType.Double;
                        objLisAddItemRefArr[0].Value = (double)p_hstMedicine[keys];
                        objLisAddItemRefArr[1].Value = p_strExamerID;
                        objLisAddItemRefArr[2].Value = p_dtmCommitDate;
                        objLisAddItemRefArr[3].Value = keys.ToString();

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbtypes = new DbType[] { DbType.Double, DbType.String, DbType.DateTime, DbType.String };

                    object[][] objValues = new object[4][];
                    for (int i1 = 0; i1 < objValues.Length; i1++)
                    {
                        objValues[i1] = new object[p_hstMedicine.Count];
                    }

                    int iRow = 0;
                    foreach (Object keys in p_hstMedicine.Keys)
                    {
                        objValues[0][iRow] = (double)p_hstMedicine[keys];
                        objValues[1][iRow] = p_strExamerID;
                        objValues[2][iRow] = p_dtmCommitDate;
                        objValues[3][iRow] = keys.ToString();
                        iRow++;
                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbtypes);
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
                //20080301 lngRes = m_lngModifyStoragePrice(p_objPrincipal, p_objAdjustMedicineArrWithLotNO);
                if (lngRes > 0)
                {
                    lngRes = m_lngSetUnCommit(p_objPrincipal, p_lngMainSEQ);
                }

                //20080301  //clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                //lngRes = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strAdjustIDArr, p_strStorageID);
                //objAccSVC = null;
                if (lngRes < 0)
                {
                    throw new Exception();
                }

                if (p_blnIsChangeBase)
                {
                    Hashtable hstBase = new Hashtable();
                    for (int iRow = 0; iRow < p_objAdjustMedicineArrWithLotNO.Length; iRow++)
                    {
                        if (!hstBase.Contains(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID))
                        {
                            hstBase.Add(p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID, p_objAdjustMedicineArrWithLotNO[iRow].m_dblNewRetailPrice);
                        }
                    }
                    lngRes = m_lngSetMedicineBasePrice(p_strUserID, p_dtmUnCommitDate, hstBase);
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
        public long m_lngAddDataToAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_MedicineInfoForAdjustPrice[] p_objAdjustMedicineArrWithLotNO, bool p_blnIsImmAcount, string p_strExamerID, DateTime p_dtmCommitDate)
        {
            if (p_objAdjustMedicineArrWithLotNO == null || p_objAdjustMedicineArrWithLotNO.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"insert into t_ms_account_detail t
  (t.seriesid_int,
   t.storageid_chr,
   t.medicineid_chr,
   t.medicinename_vch,
   t.medicinetypeid_chr,
   t.medspec_vchr,
   t.opunit_chr,
   t.instorageid_vchr,
   t.lotno_vchr,
   t.callprice_int,
   t.wholesaleprice_int,
   t.retailprice_int,
   t.amount_int,
   t.deptid_chr,
   t.type_int,
   t.oldgross_int,
   t.endamount_int,
   t.endcallprice_int,
   t.endwholesaleprice_int,
   t.endretailprice_int,
   t.chittyid_vchr,
   t.formtype_int,
   t.state_int,
   t.inaccountid_chr,
   t.inaccountdate_dat,
   t.accountid_chr,
   t.isend_int,
   t.newretailprice_int,
   t.operatedate_dat,
   t.validperiod_dat)
  select seq_ms_account_detail.nextval,
         a.storageid_chr,
         a.medicineid_chr,
         a.medicinename_vchr,
         d.medicinetypeid_chr,
         a.medspec_vchr,
         a.opunit_vchr,
         a.instorageid_vchr,
         a.lotno_vchr,
         a.callprice_int,
         a.wholesaleprice_int,
         b.oldretailprice_int,
         a.realgross_int,
         a.vendorid_chr,
         0,
         a.realgross_int,
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
         b.newretailprice_int,
         ?,
         a.validperiod_dat
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
   where b.medicineid_chr = ?
     and a.status = 1
     and b.lotno_vchr = ?
     and b.instorageid_vchr = ?
     and a.storageid_chr = ?
     and b.validperiod_dat = ?
     and b.callprice_int = ?";

                int intState = p_blnIsImmAcount ? 1 : 2;
                string strAccUser = p_blnIsImmAcount ? p_strExamerID : string.Empty;

                clsHRPTableService objHRPServ = new clsHRPTableService();
                //20080301 clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iAcc = 0; iAcc < p_objAdjustMedicineArrWithLotNO.Length; iAcc++)
                    {
                        objHRPServ.CreateDatabaseParameter(10, out objDPArr);
                        objDPArr[0].Value = intState;
                        objDPArr[1].Value = strAccUser;
                        if (p_blnIsImmAcount)
                        {
                            objDPArr[2].DbType = DbType.DateTime;
                            objDPArr[2].Value = p_dtmCommitDate;
                        }
                        else
                        {
                            objDPArr[2].Value = DBNull.Value;
                        }
                        objDPArr[3].DbType = DbType.DateTime;
                        objDPArr[3].Value = p_dtmCommitDate;
                        objDPArr[4].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_strMedicineID;
                        objDPArr[5].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_strLotNO;
                        objDPArr[6].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_strInStorageID;
                        objDPArr[7].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_strStorageID;
                        objDPArr[8].DbType = DbType.DateTime;
                        objDPArr[8].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_dtmValidDate;
                        objDPArr[9].Value = p_objAdjustMedicineArrWithLotNO[iAcc].m_dblInPrice;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.String, DbType.DateTime, DbType.DateTime, DbType.String, DbType.String, DbType.String, DbType.String,DbType.DateTime, DbType.Double };

                    object[][] objValues = new object[10][];

                    int intItemCount = p_objAdjustMedicineArrWithLotNO.Length;
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
                        objValues[3][iRow] = p_dtmCommitDate;
                        objValues[4][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_strMedicineID;
                        objValues[5][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_strLotNO;
                        objValues[6][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_strInStorageID;
                        objValues[7][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_strStorageID;
                        objValues[8][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_dtmValidDate;
                        objValues[9][iRow] = p_objAdjustMedicineArrWithLotNO[iRow].m_dblInPrice;
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
        public long m_lngInAccount(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0 || p_lngMainSEQ == null || p_lngMainSEQ.Length == 0 || p_lngMainSEQ.Length != p_strChittyIDArr.Length)
            {
                return -1;
            }
            long lngRes = 0;

            try
            {
                //20080301 clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                //lngRes = objAccSVC.m_lngRatifyAccountDetail(p_objPrincipal, p_strChittyIDArr, p_strStorageID, p_strEmpID, p_dtmAccountDate);

                //objAccSVC = null;

                if (lngRes > 0)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_lngMainSEQ, p_strEmpID, p_dtmAccountDate);
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
                string strSQL = @"";

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
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String,DbType.Double,DbType.DateTime, DbType.Int64 };

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
    }
}
