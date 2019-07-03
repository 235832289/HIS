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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsInStorageSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 添加入库主表
        /// <summary>
        /// 添加入库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objISVO">入库主表</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorage_VO p_objISVO, out long p_lngSEQ, out string p_strInStorageID)
        {
            p_lngSEQ = 1;
            p_strInStorageID = string.Empty;
            if (p_objISVO == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_instorage
  (seriesid_int,
   instorageid_vchr,
   formtype_int,
   instoragetype_int,
   state_int,
   storageid_chr,
   vendorid_chr,
   buyerid_char,
   storagerid_char,
   accounterid_char,
   instoragedate_dat,
   neworder_dat,
   exam_dat,
   account_dat,
   supplycode_vchr,
   invoicecode_vchr,
   invoicedater_dat,
   paystate_int,
   paydate_dat,
   commnet_vchr,
   makerid_chr,
   examerid_chr,
   inaccounterid_chr,
   returndept_chr,
exportdept_chr, Procurement) 
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                IDataParameter[] objLisAddItemRefArr = null;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_INSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }

                string strType = "1";
                if (p_objISVO.m_intFORMTYPE_INT == 1)
                {
                    strType = "1";
                }
                else if (p_objISVO.m_intFORMTYPE_INT == 2)
                {
                    strType = "4";
                }
                else if (p_objISVO.m_intFORMTYPE_INT == 3)
                {
                    strType = "6";
                }

                lngRes = m_lngGetLatestInStorageID(p_objPrincipal,strType, out p_strInStorageID);
                if (lngRes < 0 || string.IsNullOrEmpty(p_strInStorageID))
                {
                    return -1;
                }

                p_lngSEQ = lngSEQ;

                objHRPServ.CreateDatabaseParameter(26, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_strInStorageID;
                objLisAddItemRefArr[2].Value = p_objISVO.m_intFORMTYPE_INT;
                objLisAddItemRefArr[3].Value = p_objISVO.m_intINSTORAGETYPE_INT;
                objLisAddItemRefArr[4].Value = p_objISVO.m_intSTATE_INT;
                objLisAddItemRefArr[5].Value = p_objISVO.m_strSTORAGEID_CHR;
                objLisAddItemRefArr[6].Value = p_objISVO.m_strVENDORID_CHR;
                objLisAddItemRefArr[7].Value = p_objISVO.m_strBUYERID_CHAR;
                objLisAddItemRefArr[8].Value = p_objISVO.m_strSTORAGERID_CHAR;
                objLisAddItemRefArr[9].Value = p_objISVO.m_strACCOUNTERID_CHAR;
                objLisAddItemRefArr[10].DbType = DbType.DateTime;
                objLisAddItemRefArr[10].Value = p_objISVO.m_dtmINSTORAGEDATE_DAT;
                objLisAddItemRefArr[11].DbType = DbType.DateTime;
                objLisAddItemRefArr[11].Value = p_objISVO.m_dtmNEWORDER_DAT;
                objLisAddItemRefArr[12].DbType = DbType.DateTime;
                objLisAddItemRefArr[12].Value = p_objISVO.m_dtmEXAM_DAT;
                objLisAddItemRefArr[13].DbType = DbType.DateTime;
                objLisAddItemRefArr[13].Value = p_objISVO.m_dtmACCOUNT_DAT;
                objLisAddItemRefArr[14].Value = p_objISVO.m_strSUPPLYCODE_VCHR;
                objLisAddItemRefArr[15].Value = p_objISVO.m_strINVOICECODE_VCHR;
                objLisAddItemRefArr[16].DbType = DbType.DateTime;
                objLisAddItemRefArr[16].Value = p_objISVO.m_dtmINVOICEDATER_DAT;
                objLisAddItemRefArr[17].Value = p_objISVO.m_intPAYSTATE_INT;
                objLisAddItemRefArr[18].DbType = DbType.DateTime;
                objLisAddItemRefArr[18].Value = p_objISVO.m_dtmPAYDATE_DAT;
                objLisAddItemRefArr[19].Value = p_objISVO.m_strCOMMNET_VCHR;
                objLisAddItemRefArr[20].Value = p_objISVO.m_strMAKERID_CHR;
                objLisAddItemRefArr[21].Value = p_objISVO.m_strEXAMERID_CHR;
                objLisAddItemRefArr[22].Value = p_objISVO.m_strINACCOUNTERID_CHR;
                objLisAddItemRefArr[23].Value = p_objISVO.m_strRETURNDEPT_CHR;
                objLisAddItemRefArr[24].Value = p_objISVO.m_strExportDept_CHR;
                objLisAddItemRefArr[25].Value = p_objISVO.Procurement; 
                long lngRecEff = -1;
                //往表增加记录

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 修改入库主表
        /// <summary>
        /// 修改入库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objISVO">入库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorage_VO p_objISVO)
        {
            if (p_objISVO == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage
   set instorageid_vchr  = ?,
       formtype_int      = ?,
       instoragetype_int = ?,
       state_int         = ?,
       storageid_chr     = ?,
       vendorid_chr      = ?,
       buyerid_char      = ?,
       storagerid_char   = ?,
       accounterid_char  = ?,
       instoragedate_dat = ?,
       neworder_dat      = ?,
       exam_dat          = ?,
       account_dat       = ?,
       supplycode_vchr   = ?,
       invoicecode_vchr  = ?,
       invoicedater_dat  = ?,
       paystate_int      = ?,
       paydate_dat       = ?,
       commnet_vchr      = ?,
       makerid_chr       = ?,
       examerid_chr      = ?,
       inaccounterid_chr = ?,
       returndept_chr    = ?,
       exportdept_chr    = ?,
       Procurement       = ? 
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objLisAddItemRefArr = null;

                objHRPServ.CreateDatabaseParameter(26, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_objISVO.m_strINSTORAGEID_VCHR;
                objLisAddItemRefArr[1].Value = p_objISVO.m_intFORMTYPE_INT;
                objLisAddItemRefArr[2].Value = p_objISVO.m_intINSTORAGETYPE_INT;
                objLisAddItemRefArr[3].Value = p_objISVO.m_intSTATE_INT;
                objLisAddItemRefArr[4].Value = p_objISVO.m_strSTORAGEID_CHR;
                objLisAddItemRefArr[5].Value = p_objISVO.m_strVENDORID_CHR;
                objLisAddItemRefArr[6].Value = p_objISVO.m_strBUYERID_CHAR;
                objLisAddItemRefArr[7].Value = p_objISVO.m_strSTORAGERID_CHAR;
                objLisAddItemRefArr[8].Value = p_objISVO.m_strACCOUNTERID_CHAR;
                objLisAddItemRefArr[9].DbType = DbType.DateTime;
                objLisAddItemRefArr[9].Value = p_objISVO.m_dtmINSTORAGEDATE_DAT;
                objLisAddItemRefArr[10].DbType = DbType.DateTime;
                objLisAddItemRefArr[10].Value = p_objISVO.m_dtmNEWORDER_DAT;
                objLisAddItemRefArr[11].DbType = DbType.DateTime;
                objLisAddItemRefArr[11].Value = p_objISVO.m_dtmEXAM_DAT;
                objLisAddItemRefArr[12].DbType = DbType.DateTime;
                objLisAddItemRefArr[12].Value = p_objISVO.m_dtmACCOUNT_DAT;
                objLisAddItemRefArr[13].Value = p_objISVO.m_strSUPPLYCODE_VCHR;
                objLisAddItemRefArr[14].Value = p_objISVO.m_strINVOICECODE_VCHR;
                objLisAddItemRefArr[15].DbType = DbType.DateTime;
                objLisAddItemRefArr[15].Value = p_objISVO.m_dtmINVOICEDATER_DAT;
                objLisAddItemRefArr[16].Value = p_objISVO.m_intPAYSTATE_INT;
                objLisAddItemRefArr[17].DbType = DbType.DateTime;
                objLisAddItemRefArr[17].Value = p_objISVO.m_dtmPAYDATE_DAT;
                objLisAddItemRefArr[18].Value = p_objISVO.m_strCOMMNET_VCHR;
                objLisAddItemRefArr[19].Value = p_objISVO.m_strMAKERID_CHR;
                objLisAddItemRefArr[20].Value = p_objISVO.m_strEXAMERID_CHR;
                objLisAddItemRefArr[21].Value = p_objISVO.m_strINACCOUNTERID_CHR;
                objLisAddItemRefArr[22].Value = p_objISVO.m_strRETURNDEPT_CHR;
                objLisAddItemRefArr[23].Value = p_objISVO.m_strExportDept_CHR;
                objLisAddItemRefArr[24].Value = p_objISVO.Procurement;
                objLisAddItemRefArr[25].Value = p_objISVO.m_lngSERIESID_INT;
                long lngRecEff = -1;
                //往表增加记录

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 添加入库明细
        /// <summary>
        /// 添加入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">入库明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddInStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_InStorageDetail_VO[] p_objDetailArr)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_instorage_detal
                                        (seriesid_int, seriesid2_int, medicineid_chr, medicinename_vch,
                                         medspec_vchr, packamount, packunit_vchr, packcallprice_int,
                                         packconvert_int, lotno_vchr, amount, callprice_int,
                                         wholesaleprice_int, retailprice_int, validperiod_dat,
                                         acceptance_int, approvecode_vchr, apparentquality_int,
                                         packquality_int, examrusult_int, examiner, productorid_chr,
                                         accountperiod_int, acceptancecompany_chr, unit_vchr, status,
                                         instorageid_vchr, ruturnnum_int, outstorageid_vchr,
                                         grossprofitrate_int, limitunitprice_mny, invoicecode_vchr,
                                         invoicedater_dat, gmpflag_int, trademark_vchr,producedate_dat )
                                 values (?, ?, ?, ?,
                                         ?, ?, ?, ?,
                                         ?, ?, ?, ?,
                                         ?, ?, ?,
                                         ?, ?, ?,
                                         ?, ?, ?, ?,
                                         ?, ?, ?, ?,
                                         ?, ?, ?,
                                         ?, ?, ?,
                                         ?, ?, ?,? ) ";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_INSTORAGEDETAIL", p_objDetailArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(35, out objLisAddItemRefArr);
                        p_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objLisAddItemRefArr[0].Value = lngSEQArr[iRow];
                        objLisAddItemRefArr[1].Value = p_objDetailArr[iRow].m_lngSERIESID_INT2;
		                objLisAddItemRefArr[2].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
		                objLisAddItemRefArr[3].Value = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
		                objLisAddItemRefArr[4].Value = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
		                objLisAddItemRefArr[5].Value = p_objDetailArr[iRow].m_dblPACKAMOUNT.ToString("F2");
		                objLisAddItemRefArr[6].Value = p_objDetailArr[iRow].m_strPACKUNIT_VCHR;
		                objLisAddItemRefArr[7].Value = p_objDetailArr[iRow].m_dcmPACKCALLPRICE_INT.ToString("F4");
		                objLisAddItemRefArr[8].Value = p_objDetailArr[iRow].m_dblPACKCONVERT_INT.ToString("F2");
		                objLisAddItemRefArr[9].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
		                objLisAddItemRefArr[10].Value = p_objDetailArr[iRow].m_dblAMOUNT;
		                objLisAddItemRefArr[11].Value = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
		                objLisAddItemRefArr[12].Value = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
		                objLisAddItemRefArr[13].Value = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objLisAddItemRefArr[14].DbType = DbType.DateTime;
		                objLisAddItemRefArr[14].Value = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
		                objLisAddItemRefArr[15].Value = p_objDetailArr[iRow].m_intACCEPTANCE_INT;
		                objLisAddItemRefArr[16].Value = p_objDetailArr[iRow].m_strAPPROVECODE_VCHR;
		                objLisAddItemRefArr[17].Value = p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT;
		                objLisAddItemRefArr[18].Value = p_objDetailArr[iRow].m_intPACKQUALITY_INT;
		                objLisAddItemRefArr[19].Value = p_objDetailArr[iRow].m_intEXAMRUSULT_INT;
		                objLisAddItemRefArr[20].Value = p_objDetailArr[iRow].m_strEXAMINER;
                        objLisAddItemRefArr[21].Value = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[22].Value = p_objDetailArr[iRow].m_lngACCOUNTPERIOD_INT;
                        objLisAddItemRefArr[23].Value = p_objDetailArr[iRow].m_strACCEPTANCECOMPANY_CHR;
                        objLisAddItemRefArr[24].Value = p_objDetailArr[iRow].m_strUNIT_VCHR;
                        objLisAddItemRefArr[25].Value = p_objDetailArr[iRow].m_intStatus;
                        objLisAddItemRefArr[26].Value = p_objDetailArr[iRow].m_strInStorageID;
                        objLisAddItemRefArr[27].Value = p_objDetailArr[iRow].m_intRUTURNNUM_INT;
                        objLisAddItemRefArr[28].Value = p_objDetailArr[iRow].m_strOUTSTORAGEID_VCHR;
                        objLisAddItemRefArr[29].Value = p_objDetailArr[iRow].m_dblGrossProfitRate;
                        objLisAddItemRefArr[30].Value = p_objDetailArr[iRow].m_strInvoicecode_vchr;
                        objLisAddItemRefArr[31].DbType = DbType.DateTime;
                        objLisAddItemRefArr[31].Value = p_objDetailArr[iRow].m_dtmInvoicedater_dat;
                        objLisAddItemRefArr[32].Value = p_objDetailArr[iRow].m_intGMPFlag;
                        objLisAddItemRefArr[33].Value = p_objDetailArr[iRow].m_strTrade;
                        objLisAddItemRefArr[34].Value = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
		                //往表增加记录

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.Double,DbType.String,
                        DbType.Decimal,DbType.Double,DbType.String,DbType.Double,DbType.Decimal,DbType.Decimal,DbType.Decimal,DbType.DateTime,
                        DbType.Int32,DbType.String,DbType.Int32,DbType.Int32,DbType.Int32,DbType.String,DbType.String,DbType.Int64,DbType.String,DbType.String,
                        DbType.Int32,DbType.String,DbType.Int32,DbType.String,DbType.Double,DbType.Double,DbType.String,DbType.DateTime,
                        DbType.Int32,DbType.String,DbType.DateTime};

                    object[][] objValues = new object[36][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_INSTORAGEDETAIL", intItemCount, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        p_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objDetailArr[iRow].m_lngSERIESID_INT2;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_dblPACKAMOUNT.ToString("F2"); ;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_strPACKUNIT_VCHR;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_dcmPACKCALLPRICE_INT.ToString("F4");
                        objValues[8][iRow] = p_objDetailArr[iRow].m_dblPACKCONVERT_INT.ToString("F2");
                        objValues[9][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[10][iRow] = p_objDetailArr[iRow].m_dblAMOUNT;
                        objValues[11][iRow] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[12][iRow] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[13][iRow] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[14][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[15][iRow] = p_objDetailArr[iRow].m_intACCEPTANCE_INT;
                        objValues[16][iRow] = p_objDetailArr[iRow].m_strAPPROVECODE_VCHR;
                        objValues[17][iRow] = p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT;
                        objValues[18][iRow] = p_objDetailArr[iRow].m_intPACKQUALITY_INT;
                        objValues[19][iRow] = p_objDetailArr[iRow].m_intEXAMRUSULT_INT;
                        objValues[20][iRow] = p_objDetailArr[iRow].m_strEXAMINER;
                        objValues[21][iRow] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[22][iRow] = p_objDetailArr[iRow].m_lngACCOUNTPERIOD_INT;
                        objValues[23][iRow] = p_objDetailArr[iRow].m_strACCEPTANCECOMPANY_CHR;
                        objValues[24][iRow] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                        objValues[25][iRow] = p_objDetailArr[iRow].m_intStatus;
                        objValues[26][iRow] = p_objDetailArr[iRow].m_strInStorageID;
                        objValues[27][iRow] = p_objDetailArr[iRow].m_intRUTURNNUM_INT;
                        objValues[28][iRow] = p_objDetailArr[iRow].m_strOUTSTORAGEID_VCHR;
                        objValues[29][iRow] = p_objDetailArr[iRow].m_dblGrossProfitRate;
                        objValues[30][iRow] = p_objDetailArr[iRow].m_dblLimitunitPrice;
                        objValues[31][iRow] = p_objDetailArr[iRow].m_strInvoicecode_vchr;
                        objValues[32][iRow] = p_objDetailArr[iRow].m_dtmInvoicedater_dat;
                        objValues[33][iRow] = p_objDetailArr[iRow].m_intGMPFlag;
                        objValues[34][iRow] = p_objDetailArr[iRow].m_strTrade;
                        objValues[35][iRow] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
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

        #region 修改入库明细
        /// <summary>
        /// 修改入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">入库明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyInStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorageDetail_VO[] p_objDetailArr)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update   t_ms_instorage_detal
                                       set medicineid_chr = ?,
                                           medicinename_vch = ?,
                                           medspec_vchr = ?,
                                           packamount = ?,
                                           packunit_vchr = ?,
                                           packcallprice_int = ?,
                                           packconvert_int = ?,
                                           lotno_vchr = ?,
                                           amount = ?,
                                           callprice_int = ?,
                                           wholesaleprice_int = ?,
                                           retailprice_int = ?,
                                           validperiod_dat = ?,
                                           acceptance_int = ?,
                                           approvecode_vchr = ?,
                                           apparentquality_int = ?,
                                           packquality_int = ?,
                                           examrusult_int = ?,
                                           examiner = ?,
                                           productorid_chr = ?,
                                           accountperiod_int = ?,
                                           acceptancecompany_chr = ?,
                                           unit_vchr = ?,
                                           status = ?,
                                           instorageid_vchr = ?,
                                           ruturnnum_int = ?,
                                           outstorageid_vchr = ?,
                                           grossprofitrate_int = ?,
                                           limitunitprice_mny = ?,
                                           invoicecode_vchr = ?,
                                           invoicedater_dat = ?,
                                           gmpflag_int = ?,
                                           trademark_vchr = ?,
                                           producedate_dat = ?
                                     where seriesid_int = ? ";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;

                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(35, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[1].Value = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[2].Value = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[3].Value = p_objDetailArr[iRow].m_dblPACKAMOUNT;
                        objLisAddItemRefArr[4].Value = p_objDetailArr[iRow].m_strPACKUNIT_VCHR;
                        objLisAddItemRefArr[5].Value = p_objDetailArr[iRow].m_dcmPACKCALLPRICE_INT;
                        objLisAddItemRefArr[6].Value = p_objDetailArr[iRow].m_dblPACKCONVERT_INT;
                        objLisAddItemRefArr[7].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[8].Value = p_objDetailArr[iRow].m_dblAMOUNT;
                        objLisAddItemRefArr[9].Value = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objLisAddItemRefArr[10].Value = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[11].Value = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objLisAddItemRefArr[12].DbType = DbType.DateTime;
                        objLisAddItemRefArr[12].Value = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[13].Value = p_objDetailArr[iRow].m_intACCEPTANCE_INT;
                        objLisAddItemRefArr[14].Value = p_objDetailArr[iRow].m_strAPPROVECODE_VCHR;
                        objLisAddItemRefArr[15].Value = p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT;
                        objLisAddItemRefArr[16].Value = p_objDetailArr[iRow].m_intPACKQUALITY_INT;
                        objLisAddItemRefArr[17].Value = p_objDetailArr[iRow].m_intEXAMRUSULT_INT;
                        objLisAddItemRefArr[18].Value = p_objDetailArr[iRow].m_strEXAMINER;
                        objLisAddItemRefArr[19].Value = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[20].Value = p_objDetailArr[iRow].m_lngACCOUNTPERIOD_INT;
                        objLisAddItemRefArr[21].Value = p_objDetailArr[iRow].m_strACCEPTANCECOMPANY_CHR;
                        objLisAddItemRefArr[22].Value = p_objDetailArr[iRow].m_strUNIT_VCHR;
                        objLisAddItemRefArr[23].Value = p_objDetailArr[iRow].m_intStatus;
                        objLisAddItemRefArr[24].Value = p_objDetailArr[iRow].m_strInStorageID;
                        objLisAddItemRefArr[25].Value = p_objDetailArr[iRow].m_intRUTURNNUM_INT;
                        objLisAddItemRefArr[26].Value = p_objDetailArr[iRow].m_strOUTSTORAGEID_VCHR;
                        objLisAddItemRefArr[27].Value = p_objDetailArr[iRow].m_dblGrossProfitRate;
                        objLisAddItemRefArr[28].Value = p_objDetailArr[iRow].m_dblLimitunitPrice;
                        objLisAddItemRefArr[29].Value = p_objDetailArr[iRow].m_strInvoicecode_vchr;
                        objLisAddItemRefArr[30].DbType = DbType.DateTime;
                        objLisAddItemRefArr[30].Value = p_objDetailArr[iRow].m_dtmInvoicedater_dat;
                        objLisAddItemRefArr[31].Value = p_objDetailArr[iRow].m_intGMPFlag;
                        objLisAddItemRefArr[32].Value = p_objDetailArr[iRow].m_strTrade;
                        objLisAddItemRefArr[33].Value = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        objLisAddItemRefArr[34].Value = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        //往表增加记录

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.String,DbType.Double,DbType.String,
                        DbType.Decimal,DbType.Double,DbType.String,DbType.Double,DbType.Decimal,DbType.Decimal,DbType.Decimal,DbType.DateTime,
                        DbType.Int32,DbType.String,DbType.Int32,DbType.Int32,DbType.Int32,DbType.String,DbType.String,DbType.Int64,DbType.String,
                        DbType.String,DbType.Int32,DbType.String,DbType.Int32,DbType.String,DbType.Double, DbType.Int64,DbType.String,
                        DbType.DateTime,DbType.Int32,DbType.String,DbType.DateTime, DbType.Int64};

                    object[][] objValues = new object[35][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[1][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_dblPACKAMOUNT;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strPACKUNIT_VCHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_dcmPACKCALLPRICE_INT;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_dblPACKCONVERT_INT;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[8][iRow] = p_objDetailArr[iRow].m_dblAMOUNT;
                        objValues[9][iRow] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[10][iRow] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[11][iRow] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[12][iRow] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[13][iRow] = p_objDetailArr[iRow].m_intACCEPTANCE_INT;
                        objValues[14][iRow] = p_objDetailArr[iRow].m_strAPPROVECODE_VCHR;
                        objValues[15][iRow] = p_objDetailArr[iRow].m_intAPPARENTQUALITY_INT;
                        objValues[16][iRow] = p_objDetailArr[iRow].m_intPACKQUALITY_INT;
                        objValues[17][iRow] = p_objDetailArr[iRow].m_intEXAMRUSULT_INT;
                        objValues[18][iRow] = p_objDetailArr[iRow].m_strEXAMINER;
                        objValues[19][iRow] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                        objValues[20][iRow] = p_objDetailArr[iRow].m_lngACCOUNTPERIOD_INT;
                        objValues[21][iRow] = p_objDetailArr[iRow].m_strACCEPTANCECOMPANY_CHR;
                        objValues[22][iRow] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                        objValues[23][iRow] = p_objDetailArr[iRow].m_intStatus;
                        objValues[24][iRow] = p_objDetailArr[iRow].m_strInStorageID;
                        objValues[25][iRow] = p_objDetailArr[iRow].m_intRUTURNNUM_INT;
                        objValues[26][iRow] = p_objDetailArr[iRow].m_strOUTSTORAGEID_VCHR;
                        objValues[27][iRow] = p_objDetailArr[iRow].m_dblGrossProfitRate;
                        objValues[28][iRow] = p_objDetailArr[iRow].m_dblLimitunitPrice;
                        objValues[29][iRow] = p_objDetailArr[iRow].m_strInvoicecode_vchr;
                        objValues[30][iRow] = p_objDetailArr[iRow].m_dtmInvoicedater_dat;
                        objValues[31][iRow] = p_objDetailArr[iRow].m_intGMPFlag;
                        objValues[32][iRow] = p_objDetailArr[iRow].m_strTrade;
                        objValues[33][iRow] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        objValues[34][iRow] = p_objDetailArr[iRow].m_lngSERIESID_INT;
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
           and a.formtype_int = 1
         order by seriesid_int desc)
 where rownum = 1";
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
   and a.formtype_int = 1
 order by t.seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

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
           and b.formtype_int = 1
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
   and b.formtype_int = 1
 order by a.seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

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
          and a.formtype_int = 1
          and a.state_int <> 0
         order by seriesid_int desc)
 where rownum = 1";
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
   and a.formtype_int = 1
   and a.state_int <> 0
 order by seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

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
         b.medicinetypeid_chr, t.invoicedater_dat, t.invoicecode_vchr,a.instoragetype_int typecode_vchr,t.producedate_dat
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
                objDPArr[0].Value = DateTime.Now.ToString("yyyyMMdd") + p_strType + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = DateTime.Now.ToString("yyyyMMdd") + p_strType + "0001";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = DateTime.Now.ToString("yyyyMMdd") + p_strType + "0001";
                    }
                    else
                    {
                        strTemp = strTemp.Substring(9, 4);
                        p_strID = DateTime.Now.ToString("yyyyMMdd") + p_strType + (Convert.ToInt32(strTemp) + 1).ToString("0000");
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

        #region 删除指定入库主表信息
        /// <summary>
        /// 删除指定入库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMainInStorage(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage
   set state_int = 0
 where seriesid_int = ?
   and state_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes > 0)
                {
                    lngRes = m_lngUpdateInStorageStatusByMainSEQ(p_objPrincipal, 0, p_lngSEQ);
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
        /// 删除指定入库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMainInStorage(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage
   set state_int = 0
 where seriesid_int = ?
   and state_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngSEQ.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngSEQ[iRow];

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64};

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
                if (lngRes > 0)
                {
                    lngRes = m_lngUpdateInStorageStatusByMainSEQ(p_objPrincipal, 0, p_lngSEQ);
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

        #region 设置审核者

        /// <summary>
        /// 设置审核者

       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strEmpID">员工ID</param>
       /// <param name="p_lngSeq">序列号</param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngSetCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, long[] p_lngSeq)
        {
            if (p_lngSeq == null || p_lngSeq.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set examerid_chr = ?,exam_dat = ?,state_int=2 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < p_lngSeq.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = dtmNow;
                        objDPArr[2].Value = p_lngSeq[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_lngSeq.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = dtmNow;
                        objValues[2][iRow] = p_lngSeq[iRow];
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
        /// 设置审核者

       /// </summary>
       /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
       /// <param name="p_lngSeq">序列号</param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngSetCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID,DateTime p_dtmCommitDate, long p_lngSeq)
        {
            if (string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set examerid_chr = ?,exam_dat = ?,state_int=2 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3,out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmCommitDate;
                objDPArr[2].Value = p_lngSeq;

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

        #region 退审

        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommit(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSeq)
        {
            if (p_lngSeq == null || p_lngSeq.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set state_int=1 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < p_lngSeq.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngSeq[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngSeq.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngSeq[iRow];
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

        #region 删除指定入库明细
        /// <summary>
        /// 删除指定入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeq">序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteInStorage(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeq)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"delete from t_ms_instorage_detal t where t.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeq;

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
        /// 更新入库明细状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngMainSeq">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInStorageStatusByMainSEQ(System.Security.Principal.IPrincipal p_objPrincipal,int p_intStatus, long p_lngMainSeq)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage_detal t set t.status = ? where t.seriesid2_int = ? and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_intStatus;
                objDPArr[1].Value = p_lngMainSeq;

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
        /// 更新入库明细状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngMainSeqArr">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInStorageStatusByMainSEQ(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long[] p_lngMainSeqArr)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage_detal t set t.status = ? where t.seriesid2_int = ? and t.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngMainSeqArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_intStatus;
                        objDPArr[1].Value = p_lngMainSeqArr[iRow];

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] {DbType.Int32, DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngMainSeqArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_intStatus;
                        objValues[1][iRow] = p_lngMainSeqArr[iRow];
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
        /// 更新入库明细状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngSeq">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInStorageStatus(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long p_lngSeq)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage_detal t set t.status = ? where t.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_intStatus;
                objDPArr[1].Value = p_lngSeq;

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
        /// 更新入库明细状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngSeqArr">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInStorageStatus(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long[] p_lngSeqArr)
        {
            if (p_lngSeqArr == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_instorage_detal t set t.status = ? where t.seriesid_int = ?";

                long lngEff = -1;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngSeqArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_intStatus;
                        objDPArr[1].Value = p_lngSeqArr[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngSeqArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_intStatus;
                        objValues[1][iRow] = p_lngSeqArr[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParametersWithAffected(strSQL, objValues,ref lngEff, dbTypes);
                    if (lngEff < intItemCount)
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
        #endregion

        #region 删除选定药品
        /// <summary>
        /// 删除选定药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeq">药品序列</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStroageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_objStMed">库存药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSelectedMedicine(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeq, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_lngUpdateInStorageStatus(p_objPrincipal, 0, p_lngSeq);
                if (lngRes > 0 && p_blnIsCommit)
                {
                    if (p_objStMed == null)
                    {
                        throw new Exception();
                    }

                    clsStorageSVC objStSVC = new clsStorageSVC();
                    long lngSubSEQ = 0;
                    double p_dblRealgross = 0d;
                    double p_dblAvailagross = 0d;
                    lngRes = objStSVC.m_lngGetDetailSEQByIndex(p_objPrincipal, p_strInStroageID, p_strMedicineID, p_strLotNO, p_dtmValidDate, p_dblInPrice, p_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
                   
                    if (lngSubSEQ > 0)
                    {
                        p_objStMed.m_dblINSTOREGROSS_INT = p_dblRealgross;
                        p_objStMed.m_dblCURRENTGROSS_NUM = p_dblRealgross;
                        lngRes = objStSVC.m_lngDeleteStorageDetail(p_objPrincipal,lngSubSEQ);
                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                    }

                    lngRes = objStSVC.m_lngSubStorageGross(p_objPrincipal, p_objStMed);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStMed.m_strMEDICINEID_CHR, p_strStorageID);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    objStSVC = null;
                    p_objStMed = null;

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                    lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strInStroageID, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID,p_dtmValidDate, p_dblInPrice);
                    objAcSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                    objAcSVC = null;
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
       a.invoicecode_vchr,
       a.invoicedater_dat,
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
   and a.formtype_int = 1
 order by a.SERIESID_INT";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBeginDate;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEndDate;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
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
       a.invoicecode_vchr,
       a.invoicedater_dat,
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
   and a.formtype_int = 1
 order by a.seriesid_int";

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
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicineType">药品类型</param>
        /// <param name="p_intInStorageTypeID">入库类型</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInStorage(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strInStorageID, string p_strMedicineType, int p_intInStorageTypeID,out DataTable p_dtbValue)
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
								a.invoicecode_vchr,
								a.invoicedater_dat,
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
							where i.medicineid_chr = j.medicineid_chr
								and i.status = 1) h on a.seriesid_int = h.seriesid2_int
	left outer join t_bse_employee c on c.empid_chr = a.makerid_chr
	left outer join t_bse_employee d on d.empid_chr = a.examerid_chr
	left outer join t_bse_employee e on e.empid_chr = a.buyerid_char
	left outer join t_bse_employee f on f.empid_chr = a.storagerid_char
	left outer join t_bse_employee g on g.empid_chr = a.accounterid_char
	left outer join t_bse_deptdesc h on h.deptid_chr = a.exportdept_chr
	left join t_aid_impexptype k on k.typecode_vchr = a.instoragetype_int";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                if (p_intInStorageTypeID == 0)
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?
   and (h.medicinename_vch like ?
   or h.assistcode_chr like ?)
   and b.vendorname_vchr like ?
   and a.instorageid_vchr like ?
   and h.medicinetypeid_chr like ?
   and a.state_int <> 0
   and a.formtype_int = 1
 order by a.seriesid_int";

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

                }
                else
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.instoragedate_dat between ? and ?
   and (h.medicinename_vch like ?
   or h.assistcode_chr like ?)
   and b.vendorname_vchr like ?
   and a.instorageid_vchr like ?
   and h.medicinetypeid_chr like ?
   and a.instoragetype_int = ?
   and a.state_int <> 0
   and a.formtype_int = 1
 order by a.seriesid_int";
                    objHRPServ.CreateDatabaseParameter(9, out objDPArr);
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
                    objDPArr[8].Value = p_intInStorageTypeID;
                }             
                
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
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
                string strSQL = @" select case
          when b.packamount > 0 then
           b.packamount * b.packcallprice_int
          else
           b.amount * b.callprice_int
        end buyinmoney,
        b.amount * b.wholesaleprice_int WholeSaleMoney,
        b.amount * b.retailprice_int RetailPrice,
        a.seriesid_int,
        a.instoragetype_int,
        a.state_int
   from t_ms_instorage a, t_ms_instorage_detal b
  where a.seriesid_int = b.seriesid2_int
    and a.instoragedate_dat between ? and ?
    and a.storageid_chr = ?
    and b.status = 1
    and a.state_int <> 0
    and a.formtype_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMoney, objDPArr);                
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
           and b.formtype_int = 1
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
   and b.formtype_int = 1
 order by a.seriesid_int desc";
                }

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

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
			 decode(sum(s.realgross_int), null, 0, sum(s.realgross_int)) currentgross_num
	from t_bse_medicine t
	left outer join t_ms_storage_detail s on t.medicineid_chr =
																					 s.medicineid_chr																		
 where t.assistcode_chr like ?
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)
 group by t.assistcode_chr,
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
					t.ifstop_int
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                //objDPArr[0].Value = p_strStorageID;
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
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
                string strSQL = @"select k.medicinetypesetname,
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
			 l.oldgross_int
	from t_ms_instorage_detal t
	left outer join t_bse_vendor v on v.vendorid_chr =
																		t.acceptancecompany_chr
	left outer join t_bse_employee e on e.empid_chr = t.examiner
	left outer join t_ms_instorage f on f.seriesid_int = t.seriesid2_int
 inner join t_bse_medicine b on t.medicineid_chr = b.medicineid_chr
	left join t_ms_medicinetypeset k on k.medicinetypeid_chr =
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

        #region 设置入帐者

        /// <summary>
        /// 设置入帐者

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate,string p_strStorageID, string[] p_strInStorageID)
        {
            if (p_strInStorageID == null || p_strInStorageID.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set inaccounterid_chr = ?,account_dat = ?,state_int=3 where instorageid_vchr = ? and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_strInStorageID.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = p_dtmAccountDate;
                        objDPArr[2].Value = p_strInStorageID[iRow];
                        objDPArr[3].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String, DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_strInStorageID.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化                        
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_strInStorageID[iRow];
                        objValues[3][iRow] = p_strStorageID;
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
        /// 设置入帐者

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID,DateTime p_dtmAccountDate, long[] p_lngSeq)
        {
            if (p_lngSeq == null || p_lngSeq.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set inaccounterid_chr = ?,account_dat = ?,state_int=3 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngSeq.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = p_dtmAccountDate;
                        objDPArr[2].Value = p_lngSeq[iRow];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.Int64 };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_lngSeq.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_lngSeq[iRow];
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
        /// 设置入帐者

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmCommitDate">入帐日期</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngSeq)
        {
            if (string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_instorage set inaccounterid_chr = ?,account_dat = ?,state_int=3 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmCommitDate;
                objDPArr[2].Value = p_lngSeq;

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

        #region 审核入库单

        /// <summary>
        /// 审核入库单

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objStDetailArr">库存明细表内容</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_lngOutSEQ">入库主表序列</param>
        /// <param name="p_intFormType">入库类型</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objStDetailArr, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngOutSEQ, int p_intFormType, string p_strInStorageID, bool p_blnIsImmAccount)
        {
            if (p_objStDetailArr == null || p_objStDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();

                lngRes = objStSVC.m_lngAddNewStorageDetail(p_objPrincipal, p_objStDetailArr);

                if (lngRes <= 0)
                {
                    return -1;
                }

                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在


                for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = p_objStDetailArr[iRow].m_strMEDICINEID_CHR;
                    objStorage.m_strMEDICINENAME_VCHR = p_objStDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objStorage.m_strMEDSPEC_VCHR = p_objStDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objStorage.m_strOPUNIT_VCHR = p_objStDetailArr[iRow].m_strOPUNIT_VCHR;
                    objStorage.m_dblINSTOREGROSS_INT = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dblCURRENTGROSS_NUM = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dcmCALLPRICE_INT = p_objStDetailArr[iRow].m_dcmCALLPRICE_INT;
                    objStorage.m_strVENDORID_CHR = p_objStDetailArr[iRow].m_strVENDORID_CHR;
                    objStorage.m_strSTORAGEID_CHR = p_objStDetailArr[iRow].m_strSTORAGEID_CHR;

                    if (!hstMedicine.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                    {
                        long lngCurrentSeriesID = 0;
                        //检查是否已存在该药
                        lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_strSTORAGEID_CHR, out blnHasDetail, out lngCurrentSeriesID);

                        if (blnHasDetail)
                        {
                            if (objStorage != null)
                            {
                                //添加库存
                                lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal,objStorage, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            if (objStorage != null)
                            {
                                //库存主表添加记录
                                lngRes = objStSVC.m_lngAddNewStorage(p_objPrincipal,ref objStorage);
                            }
                            hstMedicine.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                        }
                    }
                    else
                    {
                        //添加库存
                        lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, Convert.ToInt64(hstMedicine[p_objStDetailArr[iRow].m_strMEDICINEID_CHR]));
                    }
                }
                hstMedicine = null;
                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                {
                    if (!hstStastic.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_lngSERIESID_INT);
                        //统计库存(平均进价，最高进价，最低进价)
                        lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_strSTORAGEID_CHR);
                    }
                }
                objStSVC = null;

                if (lngRes > 0)
                {
                    lngRes = m_lngSetCommitUser(p_objPrincipal, p_strEmpID,p_dtmCommitDate, p_lngOutSEQ);
                }

                if (lngRes > 0)
                {
                    clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objStDetailArr.Length];
                    int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态

                    DateTime dtmInDate = p_blnIsImmAccount ? p_dtmCommitDate : DateTime.MinValue;//入账日期
                    string strInEmp = p_blnIsImmAccount ? p_strEmpID : string.Empty;//入账人


                    for (int iAcc = 0; iAcc < p_objStDetailArr.Length; iAcc++)
                    {
                        objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                        objAccArr[iAcc].m_dblAMOUNT_INT = p_objStDetailArr[iAcc].m_dblREALGROSS_INT;
                        objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmCALLPRICE_INT;
                        objAccArr[iAcc].m_dblOLDGROSS_INT = 0;
                        objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                        objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                        objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                        objAccArr[iAcc].m_intFORMTYPE_INT = p_intFormType;
                        objAccArr[iAcc].m_intISEND_INT = 0;
                        objAccArr[iAcc].m_intSTATE_INT = intAccState;
                        objAccArr[iAcc].m_intTYPE_INT = 1;
                        objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strDEPTID_CHR = p_objStDetailArr[iAcc].m_strVENDORID_CHR;// p_objStDetailArr[iAcc].m_strDEPTID_CHR;
                        objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                        objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strLOTNO_VCHR = p_objStDetailArr[iAcc].m_strLOTNO_VCHR;
                        objAccArr[iAcc].m_strMEDICINEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINEID_CHR;
                        objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objStDetailArr[iAcc].m_strMEDICINENAME_VCHR;
                        objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINETYPEID_CHR;
                        objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objStDetailArr[iAcc].m_strMEDSPEC_VCHR;
                        objAccArr[iAcc].m_strOPUNIT_CHR = p_objStDetailArr[iAcc].m_strOPUNIT_VCHR;
                        objAccArr[iAcc].m_strSTORAGEID_CHR = p_objStDetailArr[iAcc].m_strSTORAGEID_CHR;
                        objAccArr[iAcc].m_dtmOperateDate = p_dtmCommitDate;
                        objAccArr[iAcc].m_dtmValidDate = p_objStDetailArr[iAcc].m_dtmVALIDPERIOD_DAT;
                        objAccArr[iAcc].m_strTYPECODE_CHR = p_objStDetailArr[iAcc].m_strTYPECODE_CHR;
                        objAccArr[iAcc].m_dtmPRODUCEDATE_DAT = p_objStDetailArr[iAcc].m_dtmPRODUCEDATE_DAT;
                    }

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                    lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                    if (lngRes > 0 && p_blnIsImmAccount)
                    {
                        lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmCommitDate, p_lngOutSEQ);
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

        #region 审核入库单（即入即出）


        /// <summary>
        /// 审核入库单

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objStDetailArr">库存明细表内容</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_lngOutSEQ">入库主表序列</param>
        /// <param name="p_intFormType">入库类型</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_objOutMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewOutDetailArr">新出库明细</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objStDetailArr, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngOutSEQ, int p_intFormType, string p_strInStorageID, bool p_blnIsImmAccount, ref clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewOutDetailArr, bool p_lngIsAddNew)
        {
            if (p_objStDetailArr == null || p_objStDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();

                lngRes = objStSVC.m_lngAddNewStorageDetail(p_objPrincipal, p_objStDetailArr);

                if (lngRes <= 0)
                {
                    return -1;
                }

                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在



                for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = p_objStDetailArr[iRow].m_strMEDICINEID_CHR;
                    objStorage.m_strMEDICINENAME_VCHR = p_objStDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objStorage.m_strMEDSPEC_VCHR = p_objStDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objStorage.m_strOPUNIT_VCHR = p_objStDetailArr[iRow].m_strOPUNIT_VCHR;
                    objStorage.m_dblINSTOREGROSS_INT = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dblCURRENTGROSS_NUM = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dcmCALLPRICE_INT = p_objStDetailArr[iRow].m_dcmCALLPRICE_INT;
                    objStorage.m_strVENDORID_CHR = p_objStDetailArr[iRow].m_strVENDORID_CHR;
                    objStorage.m_strSTORAGEID_CHR = p_objStDetailArr[iRow].m_strSTORAGEID_CHR;

                    if (!hstMedicine.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                    {
                        long lngCurrentSeriesID = 0;
                        //检查是否已存在该药
                        lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_strSTORAGEID_CHR, out blnHasDetail, out lngCurrentSeriesID);

                        if (blnHasDetail)
                        {
                            if (objStorage != null)
                            {
                                //添加库存
                                lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            if (objStorage != null)
                            {
                                //库存主表添加记录
                                lngRes = objStSVC.m_lngAddNewStorage(p_objPrincipal, ref objStorage);
                            }
                            hstMedicine.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                        }
                    }
                    else
                    {
                        //添加库存
                        lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, Convert.ToInt64(hstMedicine[p_objStDetailArr[iRow].m_strMEDICINEID_CHR]));
                    }
                }
                hstMedicine = null;

                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                {
                    if (!hstStastic.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_lngSERIESID_INT);
                        //统计库存(平均进价，最高进价，最低进价)
                        lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_strSTORAGEID_CHR);
                    }
                }
                objStSVC = null;

                if (lngRes > 0)
                {
                    lngRes = m_lngSetCommitUser(p_objPrincipal, p_strEmpID, p_dtmCommitDate, p_lngOutSEQ);
                }

                if (lngRes > 0)
                {
                    clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objStDetailArr.Length];
                    int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态


                    DateTime dtmInDate = p_blnIsImmAccount ? p_dtmCommitDate : DateTime.MinValue;//入账日期
                    string strInEmp = p_blnIsImmAccount ? p_strEmpID : string.Empty;//入账人



                    for (int iAcc = 0; iAcc < p_objStDetailArr.Length; iAcc++)
                    {
                        objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                        objAccArr[iAcc].m_dblAMOUNT_INT = p_objStDetailArr[iAcc].m_dblREALGROSS_INT;
                        objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmCALLPRICE_INT;
                        objAccArr[iAcc].m_dblOLDGROSS_INT = 0;
                        objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                        objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                        objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                        objAccArr[iAcc].m_intFORMTYPE_INT = p_intFormType;
                        objAccArr[iAcc].m_intISEND_INT = 0;
                        objAccArr[iAcc].m_intSTATE_INT = intAccState;
                        objAccArr[iAcc].m_intTYPE_INT = 1;
                        objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strDEPTID_CHR = p_objStDetailArr[iAcc].m_strVENDORID_CHR;
                        objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                        objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strLOTNO_VCHR = p_objStDetailArr[iAcc].m_strLOTNO_VCHR;
                        objAccArr[iAcc].m_strMEDICINEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINEID_CHR;
                        objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objStDetailArr[iAcc].m_strMEDICINENAME_VCHR;
                        objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINETYPEID_CHR;
                        objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objStDetailArr[iAcc].m_strMEDSPEC_VCHR;
                        objAccArr[iAcc].m_strOPUNIT_CHR = p_objStDetailArr[iAcc].m_strOPUNIT_VCHR;
                        objAccArr[iAcc].m_strSTORAGEID_CHR = p_objStDetailArr[iAcc].m_strSTORAGEID_CHR;
                        objAccArr[iAcc].m_dtmOperateDate = p_dtmCommitDate;
                        objAccArr[iAcc].m_dtmValidDate = p_objStDetailArr[iAcc].m_dtmVALIDPERIOD_DAT;
                        objAccArr[iAcc].m_strTYPECODE_CHR = p_objStDetailArr[iAcc].m_strTYPECODE_CHR;
                    }

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                    lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                    if (lngRes > 0 && p_blnIsImmAccount)
                    {
                        lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmCommitDate, p_lngOutSEQ);
                    }
                }
                //出库
                clsOutStorageSVC objOutSVC = new clsOutStorageSVC();
                for (int iRowVO = 0; iRowVO < p_objNewOutDetailArr.Length; iRowVO++)
                {
                    //m_strLOTNO_VCHR
                    p_objNewOutDetailArr[iRowVO].m_strINSTORAGEID_VCHR = p_strInStorageID.Trim();
                }
                objOutSVC.m_lngSaveOutStorage(p_objPrincipal, ref p_objOutMain, p_objOldDetailArr, ref p_objNewOutDetailArr, true, true, p_blnIsImmAccount);

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
            if (p_strChittyIDArr ==null || p_strChittyIDArr.Length == 0 || p_lngMainSEQ == null || p_lngMainSEQ.Length == 0 || p_lngMainSEQ.Length != p_strChittyIDArr.Length)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();

                lngRes = objAccSVC.m_lngRatifyAccountDetail(p_objPrincipal, p_strChittyIDArr, p_strStorageID, p_strEmpID, p_dtmAccountDate);

                objAccSVC = null;

                if (lngRes > 0)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate, p_lngMainSEQ);
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

        #region 入帐(即入即出)
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyIDArr">入库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与入库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入账日期</param>
        /// <param name="isInOut">是否即入即出</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInAccount(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate,bool isInOut)
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

                if (isInOut && lngRes >0)
                {
                    long[] Seriesid;
                    m_lngGetOutSeriesid(p_strChittyIDArr, out Seriesid);
                   string strSQL = @"update t_ms_outstorage
   set status = 3
 where seriesid_int = ?";
                   clsHRPTableService objHRPServ = new clsHRPTableService();
                    DbType[] dbTypes = new DbType[] { DbType.Int64 };

                    object[][] objValues = new object[1][];

                    int intItemCount = Seriesid.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = Seriesid[iRow];
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);


                }

                objAccSVC = null;

                if (lngRes > 0)
                {
                    lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate, p_lngMainSEQ);
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

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngMainSEQArr">入库主表序列</param>
        /// <param name="p_strInStorageIDArr">入库单据号</param>
        /// <param name="p_objSTDetailArr">入库相关库存明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommitInStorage(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStorageID, long[] p_lngMainSEQArr,string[] p_strInStorageIDArr, clsMS_StorageDetail[] p_objSTDetailArr)
        {
            if (p_lngMainSEQArr == null || p_lngMainSEQArr.Length == 0 || p_objSTDetailArr == null || p_objSTDetailArr.Length == 0 || p_strInStorageIDArr == null || p_strInStorageIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在


                for (int iRow = 0; iRow < p_objSTDetailArr.Length; iRow++)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = p_objSTDetailArr[iRow].m_strMEDICINEID_CHR;
                    objStorage.m_strMEDICINENAME_VCHR = p_objSTDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objStorage.m_strMEDSPEC_VCHR = p_objSTDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objStorage.m_strOPUNIT_VCHR = p_objSTDetailArr[iRow].m_strOPUNIT_VCHR;
                    objStorage.m_dblINSTOREGROSS_INT = p_objSTDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dblCURRENTGROSS_NUM = p_objSTDetailArr[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dcmCALLPRICE_INT = p_objSTDetailArr[iRow].m_dcmCALLPRICE_INT;
                    objStorage.m_strVENDORID_CHR = p_objSTDetailArr[iRow].m_strVENDORID_CHR;
                    objStorage.m_strSTORAGEID_CHR = p_strStorageID;

                    long lngCurrentSeriesID = 0;
                    lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objSTDetailArr[iRow].m_strMEDICINEID_CHR, p_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

                    p_objSTDetailArr[iRow].m_lngSERIESID_INT = lngCurrentSeriesID;
                    lngRes = objStSVC.m_lngModifyStorageFromUnCommit(p_objPrincipal, objStorage, lngCurrentSeriesID);

                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                lngRes = objStSVC.m_lngDeleteStorageDetail(p_objPrincipal, p_strInStorageIDArr, p_strStorageID);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < p_objSTDetailArr.Length; iRow++)
                {
                    if (!hstStastic.Contains(p_objSTDetailArr[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(p_objSTDetailArr[iRow].m_strMEDICINEID_CHR, p_objSTDetailArr[iRow].m_lngSERIESID_INT);
                        lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objSTDetailArr[iRow].m_strMEDICINEID_CHR, p_strStorageID);

                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }

                objStSVC = null;

                lngRes = m_lngUnCommit(p_objPrincipal, p_lngMainSEQArr);

                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                long lngRes1 = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strInStorageIDArr, p_strStorageID);
                
                objAccSVC = null;

                clsOutStorageSVC objOutSvc = new clsOutStorageSVC();
                long[] SeriesID;
                SeriesID = null;
                long lngResGetId= m_lngGetOutSeriesid(p_strInStorageIDArr,out SeriesID);
                if (lngResGetId > 0)
                {
                    long lngRes2 = objOutSvc.m_lngDeleteMainOutStorageInOut(p_objPrincipal, SeriesID);
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

        #region 保存入库
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">入库主记录</param>
        /// <param name="p_objNewDetailArr">新增的入库明细</param>
        /// <param name="p_objModifyDetailArr">修改的入库明细</param>
        /// <param name="p_objAllDetailArr">所有入库明细</param>
        /// <param name="p_objStDetailArr">库存明细</param>
        /// <param name="p_blnIsAddNew">是否新添入库</param>
        /// <param name="p_blnHasCommit">是否已审核</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorage_VO p_objMain, ref clsMS_InStorageDetail_VO[] p_objNewDetailArr, clsMS_InStorageDetail_VO[] p_objModifyDetailArr, clsMS_InStorageDetail_VO[] p_objAllDetailArr, 
            clsMS_StorageDetail[] p_objStDetailArr, bool p_blnIsAddNew, bool p_blnHasCommit, bool p_blnIsCommit, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strInStorageID)
        {
            p_lngMainSEQ = 0;
            p_strInStorageID = string.Empty;
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (p_blnIsAddNew)
                {
                    //新增
                    lngRes = m_lngAddNewInStorage(p_objPrincipal, p_objMain, out p_lngMainSEQ, out p_strInStorageID);
                    p_objMain.m_lngSERIESID_INT = p_lngMainSEQ;
                    p_objMain.m_strINSTORAGEID_VCHR = p_strInStorageID;
                }
                else
                {
                    //修改
                    lngRes = m_lngModifyInStorage(p_objPrincipal, p_objMain);
                    p_lngMainSEQ = p_objMain.m_lngSERIESID_INT;
                    p_strInStorageID = p_objMain.m_strINSTORAGEID_VCHR;
                }

                if (lngRes <= 0)
                {
                    return -1;
                }

                if (p_objNewDetailArr != null && p_objNewDetailArr.Length > 0)
                {
                    for (int iNew = 0; iNew < p_objNewDetailArr.Length; iNew++)
                    {
                        p_objNewDetailArr[iNew].m_lngSERIESID_INT2 = p_lngMainSEQ;
                        p_objNewDetailArr[iNew].m_strInStorageID = p_strInStorageID;
                    }
                    //新增的入库明细

                    lngRes = m_lngAddInStorageDetail(p_objPrincipal, ref p_objNewDetailArr);
                }

                if (p_objModifyDetailArr != null && p_objModifyDetailArr.Length > 0)
                {
                    for (int iNew = 0; iNew < p_objModifyDetailArr.Length; iNew++)
                    {
                        p_objModifyDetailArr[iNew].m_lngSERIESID_INT2 = p_lngMainSEQ;
                        p_objModifyDetailArr[iNew].m_strInStorageID = p_strInStorageID;
                    }
                    //修改入库明细
                    lngRes = m_lngModifyInStorageDetail(p_objPrincipal, p_objModifyDetailArr);
                }

                if (p_blnIsCommit && p_objStDetailArr != null && p_objStDetailArr.Length > 0)//保存即审核

                {
                    clsStorageSVC objStSVC = new clsStorageSVC();
                    if (p_blnHasCommit)//之前已审核过，先将之前的入库设为无效(界面已对本入库单中的药品是否已出库或其它操作进行判断)
                    {
                        lngRes = objStSVC.m_lngDeleteStorageDetail(p_objPrincipal, p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT);
                        if (lngRes < 0)
                        {
                            throw new Exception();
                        }
                    }

                    for (int iSt = 0; iSt < p_objStDetailArr.Length; iSt++)
                    {
                        p_objStDetailArr[iSt].m_strINSTORAGEID_VCHR = p_objMain.m_strINSTORAGEID_VCHR;
                        p_objStDetailArr[iSt].m_dtmINSTORAGEDATE_DAT = p_objMain.m_dtmINSTORAGEDATE_DAT;
                    }

                    lngRes = objStSVC.m_lngAddNewStorageDetail(p_objPrincipal, p_objStDetailArr);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                    clsMS_Storage objStorage = null;
                    bool blnHasDetail = false;//是否已存在

                    for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                    {
                        objStorage = new clsMS_Storage();
                        objStorage.m_strMEDICINEID_CHR = p_objStDetailArr[iRow].m_strMEDICINEID_CHR;
                        objStorage.m_strMEDICINENAME_VCHR = p_objStDetailArr[iRow].m_strMEDICINENAME_VCHR;
                        objStorage.m_strMEDSPEC_VCHR = p_objStDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objStorage.m_strOPUNIT_VCHR = p_objStDetailArr[iRow].m_strOPUNIT_VCHR;
                        objStorage.m_dblINSTOREGROSS_INT = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objStorage.m_dblCURRENTGROSS_NUM = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objStorage.m_dcmCALLPRICE_INT = p_objStDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objStorage.m_strVENDORID_CHR = p_objStDetailArr[iRow].m_strVENDORID_CHR;
                        objStorage.m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                   

                        if (!hstMedicine.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            long lngCurrentSeriesID = 0;
                            lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR, out blnHasDetail, out lngCurrentSeriesID);

                            if (blnHasDetail)
                            {
                                if (objStorage != null)
                                {
                                    lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, lngCurrentSeriesID);
                                    if (lngRes <= 0)
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            else
                            {
                                if (objStorage != null)
                                {
                                    lngRes = objStSVC.m_lngAddNewStorage(p_objPrincipal, ref objStorage);
                                    if (lngRes <= 0)
                                    {
                                        throw new Exception();
                                    }
                                }
                                hstMedicine.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, Convert.ToInt64(hstMedicine[p_objStDetailArr[iRow].m_strMEDICINEID_CHR]));
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                    }
                    hstMedicine = null;

                    System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                    for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                    {
                        if (!hstStastic.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            hstStastic.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_lngSERIESID_INT);
                            lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                    }

                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lngRes = m_lngSetCommitUser(p_objPrincipal, p_objMain.m_strMAKERID_CHR, dtmNow, p_lngMainSEQ);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    p_objMain.m_dtmEXAM_DAT = dtmNow;

                    clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objStDetailArr.Length];
                    int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态

                    DateTime dtmInDate = p_blnIsImmAccount ? p_objMain.m_dtmEXAM_DAT : DateTime.MinValue;//入账日期
                    string strInEmp = p_blnIsImmAccount ? p_objMain.m_strMAKERID_CHR : string.Empty;//入账人


                    for (int iAcc = 0; iAcc < p_objStDetailArr.Length; iAcc++)
                    {
                        objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                        objAccArr[iAcc].m_dblAMOUNT_INT = p_objStDetailArr[iAcc].m_dblREALGROSS_INT;
                        objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmCALLPRICE_INT;
                        objAccArr[iAcc].m_dblOLDGROSS_INT = 0;
                        objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                        objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                        objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                        objAccArr[iAcc].m_intFORMTYPE_INT = p_objMain.m_intFORMTYPE_INT;
                        objAccArr[iAcc].m_intISEND_INT = 0;
                        objAccArr[iAcc].m_intSTATE_INT = intAccState;
                        objAccArr[iAcc].m_intTYPE_INT = 1;
                        objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strDEPTID_CHR = p_objStDetailArr[iAcc].m_strVENDORID_CHR;
                        objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                        objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strLOTNO_VCHR = p_objStDetailArr[iAcc].m_strLOTNO_VCHR;
                        objAccArr[iAcc].m_strMEDICINEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINEID_CHR;
                        objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objStDetailArr[iAcc].m_strMEDICINENAME_VCHR;
                        objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINETYPEID_CHR;
                        objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objStDetailArr[iAcc].m_strMEDSPEC_VCHR;
                        objAccArr[iAcc].m_strOPUNIT_CHR = p_objStDetailArr[iAcc].m_strOPUNIT_VCHR;
                        objAccArr[iAcc].m_strSTORAGEID_CHR = p_objStDetailArr[iAcc].m_strSTORAGEID_CHR;
                        objAccArr[iAcc].m_dtmOperateDate = p_objMain.m_dtmEXAM_DAT;
                        objAccArr[iAcc].m_dtmValidDate = p_objStDetailArr[iAcc].m_dtmVALIDPERIOD_DAT;
                        objAccArr[iAcc].m_strTYPECODE_CHR = p_objStDetailArr[iAcc].m_strTYPECODE_CHR;
                        objAccArr[iAcc].m_dtmPRODUCEDATE_DAT = p_objStDetailArr[iAcc].m_dtmPRODUCEDATE_DAT;
                    }

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();

                    if (p_blnHasCommit)
                    {
                        lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strInStorageID, p_objMain.m_strSTORAGEID_CHR);
                    }

                    lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                    if (lngRes > 0 && p_blnIsImmAccount)
                    {
                        lngRes = m_lngSetAccountUser(p_objPrincipal, p_objMain.m_strMAKERID_CHR, dtmNow, p_lngMainSEQ);
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

        #region 保存入库(即入即出)
        /// <summary>
        /// 保存入库(即入即出)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">入库主记录</param>
        /// <param name="p_objNewDetailArr">新增的入库明细</param>
        /// <param name="p_objModifyDetailArr">修改的入库明细</param>
        /// <param name="p_objAllDetailArr">所有入库明细</param>
        /// <param name="p_objStDetailArr">库存明细</param>
        /// <param name="p_blnIsAddNew">是否新添入库</param>
        /// <param name="p_blnHasCommit">是否已审核</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_objOutMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewOutDetailArr">新出库明细</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorage_VO p_objMain, ref clsMS_InStorageDetail_VO[] p_objNewDetailArr, clsMS_InStorageDetail_VO[] p_objModifyDetailArr, clsMS_InStorageDetail_VO[] p_objAllDetailArr,
            clsMS_StorageDetail[] p_objStDetailArr, bool p_blnIsAddNew, bool p_blnHasCommit, bool p_blnIsCommit, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strInStorageID, ref clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewOutDetailArr, bool p_lngIsAddNew)
        {
            
            p_lngMainSEQ = 0;
            p_strInStorageID = string.Empty;
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (p_blnIsAddNew)
                {
                    //新增
                    lngRes = m_lngAddNewInStorage(p_objPrincipal, p_objMain, out p_lngMainSEQ, out p_strInStorageID);
                    p_objMain.m_lngSERIESID_INT = p_lngMainSEQ;
                    p_objMain.m_strINSTORAGEID_VCHR = p_strInStorageID;
                }
                else
                {
                    //修改
                    lngRes = m_lngModifyInStorage(p_objPrincipal, p_objMain);
                    p_lngMainSEQ = p_objMain.m_lngSERIESID_INT;
                    p_strInStorageID = p_objMain.m_strINSTORAGEID_VCHR;
                }

                if (lngRes <= 0)
                {
                    return -1;
                }

                if (p_objNewDetailArr != null && p_objNewDetailArr.Length > 0)
                {
                    for (int iNew = 0; iNew < p_objNewDetailArr.Length; iNew++)
                    {
                        p_objNewDetailArr[iNew].m_lngSERIESID_INT2 = p_lngMainSEQ;
                        p_objNewDetailArr[iNew].m_strInStorageID = p_strInStorageID;
                    }
                    //新增的入库明细


                    lngRes = m_lngAddInStorageDetail(p_objPrincipal, ref p_objNewDetailArr);
                }

                if (p_objModifyDetailArr != null && p_objModifyDetailArr.Length > 0)
                {
                    for (int iNew = 0; iNew < p_objModifyDetailArr.Length; iNew++)
                    {
                        p_objModifyDetailArr[iNew].m_lngSERIESID_INT2 = p_lngMainSEQ;
                        p_objModifyDetailArr[iNew].m_strInStorageID = p_strInStorageID;
                    }
                    //修改入库明细
                    lngRes = m_lngModifyInStorageDetail(p_objPrincipal, p_objModifyDetailArr);
                }

                if (p_blnIsCommit && p_objStDetailArr != null && p_objStDetailArr.Length > 0)//保存即审核

                {
                    clsStorageSVC objStSVC = new clsStorageSVC();
                    if (p_blnHasCommit)//之前已审核过，先将之前的入库设为无效(界面已对本入库单中的药品是否已出库或其它操作进行判断)
                    {
                        lngRes = objStSVC.m_lngDeleteStorageDetail(p_objPrincipal, p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT);
                        if (lngRes < 0)
                        {
                            throw new Exception();
                        }
                    }

                    for (int iSt = 0; iSt < p_objStDetailArr.Length; iSt++)
                    {
                        p_objStDetailArr[iSt].m_strINSTORAGEID_VCHR = p_objMain.m_strINSTORAGEID_VCHR;
                        p_objStDetailArr[iSt].m_dtmINSTORAGEDATE_DAT = p_objMain.m_dtmINSTORAGEDATE_DAT;
                    }

                    lngRes = objStSVC.m_lngAddNewStorageDetail(p_objPrincipal, p_objStDetailArr);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                    clsMS_Storage objStorage = null;
                    bool blnHasDetail = false;//是否已存在


                    for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                    {
                        objStorage = new clsMS_Storage();
                        objStorage.m_strMEDICINEID_CHR = p_objStDetailArr[iRow].m_strMEDICINEID_CHR;
                        objStorage.m_strMEDICINENAME_VCHR = p_objStDetailArr[iRow].m_strMEDICINENAME_VCHR;
                        objStorage.m_strMEDSPEC_VCHR = p_objStDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objStorage.m_strOPUNIT_VCHR = p_objStDetailArr[iRow].m_strOPUNIT_VCHR;
                        objStorage.m_dblINSTOREGROSS_INT = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objStorage.m_dblCURRENTGROSS_NUM = p_objStDetailArr[iRow].m_dblAVAILAGROSS_INT;
                        objStorage.m_dcmCALLPRICE_INT = p_objStDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objStorage.m_strVENDORID_CHR = p_objStDetailArr[iRow].m_strVENDORID_CHR;
                        objStorage.m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;


                        if (!hstMedicine.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            long lngCurrentSeriesID = 0;
                            lngRes = objStSVC.m_lngCheckHasStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR, out blnHasDetail, out lngCurrentSeriesID);

                            if (blnHasDetail)
                            {
                                if (objStorage != null)
                                {
                                    lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, lngCurrentSeriesID);
                                    if (lngRes <= 0)
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            else
                            {
                                if (objStorage != null)
                                {
                                    lngRes = objStSVC.m_lngAddNewStorage(p_objPrincipal, ref objStorage);
                                    if (lngRes <= 0)
                                    {
                                        throw new Exception();
                                    }
                                }
                                hstMedicine.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            lngRes = objStSVC.m_lngModifyStorageFromInitial(p_objPrincipal, objStorage, Convert.ToInt64(hstMedicine[p_objStDetailArr[iRow].m_strMEDICINEID_CHR]));
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                    }
                    hstMedicine = null;

                    System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                    for (int iRow = 0; iRow < p_objStDetailArr.Length; iRow++)
                    {
                        if (!hstStastic.Contains(p_objStDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            hstStastic.Add(p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objStDetailArr[iRow].m_lngSERIESID_INT);
                            lngRes = objStSVC.m_lngStatisticsStorage(p_objPrincipal, p_objStDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                    }

                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lngRes = m_lngSetCommitUser(p_objPrincipal, p_objMain.m_strMAKERID_CHR, dtmNow, p_lngMainSEQ);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    p_objMain.m_dtmEXAM_DAT = dtmNow;

                    clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objStDetailArr.Length];
                    int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态


                    DateTime dtmInDate = p_blnIsImmAccount ? p_objMain.m_dtmEXAM_DAT : DateTime.MinValue;//入账日期
                    string strInEmp = p_blnIsImmAccount ? p_objMain.m_strMAKERID_CHR : string.Empty;//入账人



                    for (int iAcc = 0; iAcc < p_objStDetailArr.Length; iAcc++)
                    {
                        objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                        objAccArr[iAcc].m_dblAMOUNT_INT = p_objStDetailArr[iAcc].m_dblREALGROSS_INT;
                        objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmCALLPRICE_INT;
                        objAccArr[iAcc].m_dblOLDGROSS_INT = 0;
                        objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                        objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objStDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                        objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                        objAccArr[iAcc].m_intFORMTYPE_INT = p_objMain.m_intFORMTYPE_INT;
                        objAccArr[iAcc].m_intISEND_INT = 0;
                        objAccArr[iAcc].m_intSTATE_INT = intAccState;
                        objAccArr[iAcc].m_intTYPE_INT = 1;
                        objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strDEPTID_CHR = p_objStDetailArr[iAcc].m_strVENDORID_CHR;
                        objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                        objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_strInStorageID;
                        objAccArr[iAcc].m_strLOTNO_VCHR = p_objStDetailArr[iAcc].m_strLOTNO_VCHR;
                        objAccArr[iAcc].m_strMEDICINEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINEID_CHR;
                        objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objStDetailArr[iAcc].m_strMEDICINENAME_VCHR;
                        objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objStDetailArr[iAcc].m_strMEDICINETYPEID_CHR;
                        objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objStDetailArr[iAcc].m_strMEDSPEC_VCHR;
                        objAccArr[iAcc].m_strOPUNIT_CHR = p_objStDetailArr[iAcc].m_strOPUNIT_VCHR;
                        objAccArr[iAcc].m_strSTORAGEID_CHR = p_objStDetailArr[iAcc].m_strSTORAGEID_CHR;
                        objAccArr[iAcc].m_dtmOperateDate = p_objMain.m_dtmEXAM_DAT;
                        objAccArr[iAcc].m_dtmValidDate = p_objStDetailArr[iAcc].m_dtmVALIDPERIOD_DAT;
                        objAccArr[iAcc].m_strTYPECODE_CHR = p_objStDetailArr[iAcc].m_strTYPECODE_CHR;
                    }

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();

                    if (p_blnHasCommit)
                    {
                        lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strInStorageID, p_objMain.m_strSTORAGEID_CHR);
                    }

                    lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                    if (lngRes > 0 && p_blnIsImmAccount)
                    {
                        lngRes = m_lngSetAccountUser(p_objPrincipal, p_objMain.m_strMAKERID_CHR, dtmNow, p_lngMainSEQ);
                    }

                }

            //出库
                if (p_blnIsCommit)
                {
                    clsOutStorageSVC objOutSVC = new clsOutStorageSVC();
                    for (int iRowVO = 0; iRowVO < p_objNewOutDetailArr.Length; iRowVO++)
                    {
                        //m_strLOTNO_VCHR
                        p_objNewOutDetailArr[iRowVO].m_strINSTORAGEID_VCHR = p_strInStorageID.Trim();
                    }
                    objOutSVC.m_lngSaveOutStorage(p_objPrincipal, ref p_objOutMain, p_objOldDetailArr, ref p_objNewOutDetailArr, p_blnIsCommit, true, p_blnIsImmAccount);
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

        #region 退审(即入即出,保存前自动退审)
        /// <summary>
        /// 退审(即入即出,保存前自动退审)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngMainSEQArr">入库主表序列</param>
        /// <param name="p_strInStorageIDArr">入库单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommitInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, long[] p_lngMainSEQArr, string[] p_strInStorageIDArr)
        {
            if (p_lngMainSEQArr == null || p_lngMainSEQArr.Length == 0  || p_strInStorageIDArr == null || p_strInStorageIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在

                lngRes = objStSVC.m_lngDeleteStorageDetail(p_objPrincipal, p_strInStorageIDArr, p_strStorageID);
                if (lngRes <= 0)
                {
                    return lngRes;
                }

                objStSVC = null;

           //     lngRes = m_lngUnCommit(p_objPrincipal, p_lngMainSEQArr);

                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                long lngRes1 = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strInStorageIDArr, p_strStorageID);

                objAccSVC = null;

                clsOutStorageSVC objOutSvc = new clsOutStorageSVC();
                long[] SeriesID;
                SeriesID = null;
                long lngResGetId = m_lngGetOutSeriesid(p_strInStorageIDArr, out SeriesID);
                if (lngResGetId > 0)
                {
                    long lngRes2 = objOutSvc.m_lngDeleteMainOutStorageInOut(p_objPrincipal, SeriesID);
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
    and t.lotno_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineid;
                objDPArr[1].Value = p_strLotno;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbGross, objDPArr);
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

        #region 获取上次入库厂家

        /// <summary>
        /// 获取上次入库厂家
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_strProductor"></param>
        /// <returns></returns>
        public long m_lngGetLastProductor(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, out string p_strProductor)
        {
            p_strProductor = string.Empty;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select productorid_chr
	from (select a.productorid_chr
					from t_ms_instorage_detal a
					left join t_ms_instorage b on b.seriesid_int = a.seriesid2_int
																		and b.state_int <> 0
				 where b.storageid_chr = ?
					 and a.medicineid_chr = ?
				 order by b.neworder_dat desc)
 where rownum = 1";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                if (dtbResult != null && dtbResult.Rows.Count == 1)
                {
                    p_strProductor = Convert.ToString(dtbResult.Rows[0][0]);
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
    }
}
