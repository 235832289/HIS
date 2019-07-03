using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房盘点中间件
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDrugStoreCheck_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {       
        #region 添加盘点主表信息
        /// <summary>
        /// 添加盘点主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSCVO">盘点主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewStorageCheckMain(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_Check_VO p_objSCVO)
        {
            if (p_objSCVO == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_drugstorecheck
  (seriesid_int,
   drugstoreid_chr,
   checkid_chr,
   status_int,
   askdate_dat,
   examdate_dat,
   askerid_chr,
   examerid_chr,
   inaccountid_chr,
   inaccountdate_dat,
   checkdate_dat)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_DRUGSTORECHECK", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_objSCVO.m_lngSERIESID_INT = lngSEQ;
                string m_strTempId = string.Empty;
                string strCheckID = string.Empty;
                string m_strMedStoreShortCode = string.Empty;
                string m_strParaValue = string.Empty;
                objPublic.m_lngGetSysParaByID(p_objPrincipal, "8007", out m_strParaValue);
                objPublic.m_lngGetMedStoreShortCodeByDeptid(p_objPrincipal, p_objSCVO.m_strDRUGSTOREID_CHR, out m_strMedStoreShortCode);
               // lngRes = m_lngGetLatestCheckID(p_objPrincipal, out strCheckID);
                objPublic.m_lngGetNewIdByName(p_objPrincipal, "t_ds_drugstorecheck", "checkid_chr", m_strMedStoreShortCode, p_objSCVO.m_dtmCHECKDATE_DAT, ref m_strTempId);
                strCheckID = m_strMedStoreShortCode + p_objSCVO.m_dtmCHECKDATE_DAT.ToString("yyMMdd") + m_strParaValue.Split(';')[2] + m_strTempId;

                if (lngRes < 0 || string.IsNullOrEmpty(strCheckID))
                {
                    return -1;
                }
                p_objSCVO.m_strCHECKID_CHR = strCheckID;

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                objDPArr[0].Value = p_objSCVO.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objSCVO.m_strDRUGSTOREID_CHR;
                objDPArr[2].Value = p_objSCVO.m_strCHECKID_CHR;
                objDPArr[3].Value = p_objSCVO.m_intSTATUS_INT;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_objSCVO.m_dtmASKDATE_DAT;
                objDPArr[5].DbType = DbType.DateTime;
                objDPArr[5].Value = p_objSCVO.m_dtmEXAMDATE_DAT;
                objDPArr[6].Value = p_objSCVO.m_strASKERID_CHR;
                objDPArr[7].Value = p_objSCVO.m_strEXAMERID_CHR;
                objDPArr[8].Value = p_objSCVO.m_strINACCOUNTID_CHR;
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[9].Value = p_objSCVO.m_dtmINACCOUNTDATE_DAT;
                objDPArr[10].DbType = DbType.DateTime;
                objDPArr[10].Value = p_objSCVO.m_dtmCHECKDATE_DAT;

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
        #endregion

        #region 添加盘点明细
        /// <summary>
        /// 添加盘点明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailVO">盘点明细</param>
        /// <param name="p_lngSEQArr">明细序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewStorageCheckDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageCheckDetail_VO[] p_objDetailVO, out long[] p_lngSEQArr)
        {
            p_lngSEQArr = null;
            if (p_objDetailVO == null || p_objDetailVO.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_drugstorecheck_detail
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   ipunit_chr,
   opunit_chr,
   lotno_vchr,
   validperiod_dat,
   ipcheckgross_int,
   opcheckgross_int,
   productorid_chr,  
   checkreason_vchr,
   ipcheckresult_int,
   opcheckresult_int,
   iszero_int,
   modifier_chr,
   modifydate_dat,
   status_int,
   indrugstoreid_vchr,
   packqty_dec,
   opchargeflg_int,
   iprealgross_int,
oprealgross_int,
ipretailprice_int,
opretailprice_int,
ipcallprice_int,
opcallprice_int,
dsinstoragedate_dat,ipchargeflg_int)
VALUES
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_DRUGSTORECHECK_DETAIL", p_objDetailVO.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }
                    p_lngSEQArr = lngSEQArr;

                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    for (int iRow = 0; iRow < lngSEQArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(30, out objLisAddItemRefArr);
                        p_objDetailVO[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objLisAddItemRefArr[0].Value = p_objDetailVO[iRow].m_lngSERIESID_INT;
                        objLisAddItemRefArr[1].Value = p_objDetailVO[iRow].m_lngSERIESID2_INT;
                        objLisAddItemRefArr[2].Value = p_objDetailVO[iRow].m_strMedicineCode;
                        objLisAddItemRefArr[3].Value = p_objDetailVO[iRow].m_strMEDICINENAME_VCHR;
                        objLisAddItemRefArr[4].Value = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[5].Value = p_objDetailVO[iRow].m_strIPUNIT_CHR;
                        objLisAddItemRefArr[6].Value = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[7].Value = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[8].DbType = DbType.DateTime;
                        objLisAddItemRefArr[8].Value = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[9].Value = p_objDetailVO[iRow].m_dblIPCHECKGROSS_INT;
                        objLisAddItemRefArr[10].Value = p_objDetailVO[iRow].m_dblOPCHECKGROSS_INT;
                        objLisAddItemRefArr[11].Value = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[12].Value = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objLisAddItemRefArr[13].Value = p_objDetailVO[iRow].m_dblIPCHECKRESULT_INT;
                        objLisAddItemRefArr[14].Value = p_objDetailVO[iRow].m_dblOPCHECKRESULT_INT;
                        objLisAddItemRefArr[15].Value = p_objDetailVO[iRow].m_intISZERO_INT;
                        objLisAddItemRefArr[16].Value = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objLisAddItemRefArr[17].DbType = DbType.DateTime;
                        objLisAddItemRefArr[17].Value = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objLisAddItemRefArr[18].Value = 1;
                        objLisAddItemRefArr[19].Value = p_objDetailVO[iRow].m_strINDRUGSTOREID_VCHR;
                        objLisAddItemRefArr[20].Value = p_objDetailVO[iRow].m_dblPACKQTY_DEC;
                        objLisAddItemRefArr[21].Value = p_objDetailVO[iRow].m_dblOPCHARGEFLG_INT;
                        objLisAddItemRefArr[22].Value = p_objDetailVO[iRow].m_dblIPREALGROSS_INT;
                        objLisAddItemRefArr[23].Value = p_objDetailVO[iRow].m_dblOPREALGROSS_INT;
                        objLisAddItemRefArr[24].Value = p_objDetailVO[iRow].m_dblIPRETAILPRICE_INT;
                        objLisAddItemRefArr[25].Value = p_objDetailVO[iRow].m_dblOPRETAILPRICE_INT;
                        objLisAddItemRefArr[26].Value = p_objDetailVO[iRow].m_dblIPCALLPRICE_INT;
                        objLisAddItemRefArr[27].Value = p_objDetailVO[iRow].m_dblOPCALLPRICE_INT;
                        objLisAddItemRefArr[28].Value = p_objDetailVO[iRow].m_dtmDSINSTORAGEDATE_DAT;
                        objLisAddItemRefArr[29].Value = p_objDetailVO[iRow].m_dblIPCHARGEFLG_INT;
                        //往表增加记录

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.DateTime,DbType.Double,DbType.Double,DbType.String,DbType.String,DbType.Double,DbType.Double,DbType.Double,
                        DbType.String,DbType.DateTime,DbType.Int32,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.Double,
                    DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.DateTime,DbType.Double};

                    object[][] objValues = new object[30][];

                    int intItemCount = p_objDetailVO.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_DRUGSTORECHECK_DETAIL", intItemCount, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        return -1;
                    }
                    p_lngSEQArr = lngSEQArr;

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        p_objDetailVO[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objDetailVO[iRow].m_lngSERIESID2_INT;
                        objValues[2][iRow] = p_objDetailVO[iRow].m_strMedicineCode;
                        objValues[3][iRow] = p_objDetailVO[iRow].m_strMEDICINENAME_VCHR;
                        objValues[4][iRow] = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objDetailVO[iRow].m_strIPUNIT_CHR;
                        objValues[6][iRow] = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objValues[7][iRow] = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objValues[8][iRow] = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[9][iRow] = p_objDetailVO[iRow].m_dblIPCHECKGROSS_INT;
                        objValues[10][iRow] = p_objDetailVO[iRow].m_dblOPCHECKGROSS_INT;
                        objValues[11][iRow] = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objValues[12][iRow] = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objValues[13][iRow] = p_objDetailVO[iRow].m_dblIPCHECKRESULT_INT;
                        objValues[14][iRow] = p_objDetailVO[iRow].m_dblOPCHECKRESULT_INT;
                        objValues[15][iRow] = p_objDetailVO[iRow].m_intISZERO_INT;
                        objValues[16][iRow] = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objValues[17][iRow] = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objValues[18][iRow] = 1;
                        objValues[19][iRow] = p_objDetailVO[iRow].m_strINDRUGSTOREID_VCHR;
                        objValues[20][iRow] = p_objDetailVO[iRow].m_dblPACKQTY_DEC;
                        objValues[21][iRow] = p_objDetailVO[iRow].m_dblOPCHARGEFLG_INT;
                        objValues[22][iRow] = p_objDetailVO[iRow].m_dblIPREALGROSS_INT;
                        objValues[23][iRow] = p_objDetailVO[iRow].m_dblOPREALGROSS_INT;
                        objValues[24][iRow] = p_objDetailVO[iRow].m_dblIPRETAILPRICE_INT;
                        objValues[25][iRow] = p_objDetailVO[iRow].m_dblOPRETAILPRICE_INT;
                        objValues[26][iRow] = p_objDetailVO[iRow].m_dblIPCALLPRICE_INT;
                        objValues[27][iRow] = p_objDetailVO[iRow].m_dblOPCALLPRICE_INT;
                        objValues[28][iRow] = p_objDetailVO[iRow].m_dtmDSINSTORAGEDATE_DAT;
                        objValues[29][iRow] = p_objDetailVO[iRow].m_dblIPCHARGEFLG_INT;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objDetailVO = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion      

        #region 修改盘点主表
        /// <summary>
        /// 修改盘点主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSCVO">盘点主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngMofifyStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Check_VO p_objSCVO)
        {
            if (p_objSCVO == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ds_drugstorecheck
                                       set drugstoreid_chr = ?, checkid_chr = ?, status_int = ?, askdate_dat = ?,
                                           examdate_dat = ?, askerid_chr = ?, examerid_chr = ?,
                                           inaccountid_chr = ?, inaccountdate_dat = ?, checkdate_dat = ?
                                     where seriesid_int = ?
                                       and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(11, out objDPArr);
                objDPArr[0].Value = p_objSCVO.m_strDRUGSTOREID_CHR;
                objDPArr[1].Value = p_objSCVO.m_strCHECKID_CHR;
                objDPArr[2].Value = p_objSCVO.m_intSTATUS_INT;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_objSCVO.m_dtmASKDATE_DAT;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_objSCVO.m_dtmEXAMDATE_DAT;
                objDPArr[5].Value = p_objSCVO.m_strASKERID_CHR;
                objDPArr[6].Value = p_objSCVO.m_strEXAMERID_CHR;
                objDPArr[7].Value = p_objSCVO.m_strINACCOUNTID_CHR;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = p_objSCVO.m_dtmINACCOUNTDATE_DAT;
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[9].Value = p_objSCVO.m_dtmCHECKDATE_DAT;
                objDPArr[10].Value = p_objSCVO.m_lngSERIESID_INT;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngEff != 1)
                {
                    return -99;
                }

                //20090824:修改时将所有记录清空
                strSQL = @"delete from t_ds_drugstorecheck_detail a where a.seriesid2_int = ?";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_objSCVO.m_lngSERIESID_INT;
                objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                objHRPServ.Dispose();
                objHRPServ = null;
                p_objSCVO = null;                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 修改盘点明细信息
        /// <summary>
        /// 修改盘点明细信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailVO">盘点明细信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageCheckDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageCheckDetail_VO[] p_objDetailVO)
        {
            if (p_objDetailVO == null || p_objDetailVO.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck_detail
   set medicineid_chr      = ?,
       medicinename_vchr   = ?,
       medspec_vchr        = ?,
       ipunit_chr          = ?,
       opunit_chr          = ?,
       lotno_vchr          = ?,
       validperiod_dat     = ?,
       ipcheckgross_int    = ?,
       opcheckgross_int    = ?,
       productorid_chr     = ?,
       checkreason_vchr    = ?,
       ipcheckresult_int   = ?,
       opcheckresult_int   = ?,
       iszero_int          = ?,
       modifier_chr        = ?,
       modifydate_dat      = ?,
       status_int          = ?,
       indrugstoreid_vchr  = ?,
       opchargeflg_int     = ?,
       iprealgross_int     = ?,
       oprealgross_int     = ?,
       ipretailprice_int   = ?,
       opretailprice_int   = ?,
       ipcallprice_int     = ?,
       opcallprice_int     = ?,
       dsinstoragedate_dat = ?,
       ipchargeflg_int     = ?
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    for (int iRow = 0; iRow < p_objDetailVO.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(28, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_objDetailVO[iRow].m_strMedicineCode;
                        objLisAddItemRefArr[1].Value = p_objDetailVO[iRow].m_strMEDICINENAME_VCHR;
                        objLisAddItemRefArr[2].Value = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[3].Value = p_objDetailVO[iRow].m_strIPUNIT_CHR;
                        objLisAddItemRefArr[4].Value = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[5].Value = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[6].DbType = DbType.DateTime;
                        objLisAddItemRefArr[6].Value = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[7].Value = p_objDetailVO[iRow].m_dblIPCHECKGROSS_INT;
                        objLisAddItemRefArr[8].Value = p_objDetailVO[iRow].m_dblOPCHECKGROSS_INT;
                        objLisAddItemRefArr[9].Value = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[10].Value = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objLisAddItemRefArr[11].Value = p_objDetailVO[iRow].m_dblIPCHECKRESULT_INT;
                        objLisAddItemRefArr[12].Value = p_objDetailVO[iRow].m_dblOPCHECKRESULT_INT;
                        objLisAddItemRefArr[13].Value = p_objDetailVO[iRow].m_intISZERO_INT;
                        objLisAddItemRefArr[14].Value = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objLisAddItemRefArr[15].DbType = DbType.DateTime;
                        objLisAddItemRefArr[15].Value = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objLisAddItemRefArr[16].Value = p_objDetailVO[iRow].m_intSTATUS_INT;
                        objLisAddItemRefArr[17].Value = p_objDetailVO[iRow].m_strINDRUGSTOREID_VCHR;
                        objLisAddItemRefArr[18].Value = p_objDetailVO[iRow].m_dblOPCHARGEFLG_INT;
                        objLisAddItemRefArr[19].Value = p_objDetailVO[iRow].m_dblIPREALGROSS_INT;
                        objLisAddItemRefArr[20].Value = p_objDetailVO[iRow].m_dblOPREALGROSS_INT;
                        objLisAddItemRefArr[21].Value = p_objDetailVO[iRow].m_dblIPRETAILPRICE_INT;
                        objLisAddItemRefArr[22].Value = p_objDetailVO[iRow].m_dblOPRETAILPRICE_INT;
                        objLisAddItemRefArr[23].Value = p_objDetailVO[iRow].m_dblIPCALLPRICE_INT;
                        objLisAddItemRefArr[24].Value = p_objDetailVO[iRow].m_dblOPCALLPRICE_INT;
                        objLisAddItemRefArr[25].Value = p_objDetailVO[iRow].m_dtmDSINSTORAGEDATE_DAT;
                        objLisAddItemRefArr[26].Value = p_objDetailVO[iRow].m_dblIPCHARGEFLG_INT;
                        objLisAddItemRefArr[27].Value = p_objDetailVO[iRow].m_lngSERIESID_INT;

                        //往表增加记录

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.DateTime,DbType.Double,DbType.Double,DbType.String,DbType.String,DbType.Double,DbType.Double,DbType.Double,
                        DbType.String,DbType.DateTime,DbType.Int32,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.Double,
                        DbType.Double,DbType.Double,DbType.Double,DbType.DateTime,DbType.Double, DbType.Int64};

                    object[][] objValues = new object[28][];

                    int intItemCount = p_objDetailVO.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetailVO[iRow].m_strMedicineCode;
                        objValues[1][iRow] = p_objDetailVO[iRow].m_strMEDICINENAME_VCHR;
                        objValues[2][iRow] = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objValues[3][iRow] = p_objDetailVO[iRow].m_strIPUNIT_CHR;
                        objValues[4][iRow] = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objValues[5][iRow] = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objValues[6][iRow] = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[7][iRow] = p_objDetailVO[iRow].m_dblIPCHECKGROSS_INT;
                        objValues[8][iRow] = p_objDetailVO[iRow].m_dblOPCHECKGROSS_INT;
                        objValues[9][iRow] = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objValues[10][iRow] = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objValues[11][iRow] = p_objDetailVO[iRow].m_dblIPCHECKRESULT_INT;
                        objValues[12][iRow] = p_objDetailVO[iRow].m_dblOPCHECKRESULT_INT;
                        objValues[13][iRow] = p_objDetailVO[iRow].m_intISZERO_INT;
                        objValues[14][iRow] = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objValues[15][iRow] = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objValues[16][iRow] = p_objDetailVO[iRow].m_intSTATUS_INT;
                        objValues[17][iRow] = p_objDetailVO[iRow].m_strINDRUGSTOREID_VCHR;
                        objValues[18][iRow] = p_objDetailVO[iRow].m_dblOPCHARGEFLG_INT;
                        objValues[19][iRow] = p_objDetailVO[iRow].m_dblIPREALGROSS_INT;
                        objValues[20][iRow] = p_objDetailVO[iRow].m_dblOPREALGROSS_INT;
                        objValues[21][iRow] = p_objDetailVO[iRow].m_dblIPRETAILPRICE_INT;
                        objValues[22][iRow] = p_objDetailVO[iRow].m_dblOPRETAILPRICE_INT;
                        objValues[23][iRow] = p_objDetailVO[iRow].m_dblIPCALLPRICE_INT;
                        objValues[24][iRow] = p_objDetailVO[iRow].m_dblOPCALLPRICE_INT;
                        objValues[25][iRow] = p_objDetailVO[iRow].m_dtmDSINSTORAGEDATE_DAT;
                        objValues[26][iRow] = p_objDetailVO[iRow].m_dblIPCHARGEFLG_INT;
                        objValues[27][iRow] = p_objDetailVO[iRow].m_lngSERIESID_INT;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
                objHRPServ.Dispose();
                objHRPServ = null;
                p_objDetailVO = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 设置审核人及日期
        /// <summary>
        /// 设置审核人及日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_lngSeq">审核记录的序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetCommitUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, long p_lngSeq)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update   t_ds_drugstorecheck
                                       set status_int = 2, examerid_chr = ?, examdate_dat = sysdate
                                     where seriesid_int = ?
                                       and status_int = 1";
                                
                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].Value = p_lngSeq;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;

                if(lngEff != 1)
                {
                    return -99;
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

        #region 设置入帐人及日期
        /// <summary>
        /// 设置入帐人及日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">入帐人ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strCheckIDArr">盘点单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate, string p_strStorageID, string[] p_strCheckIDArr)
        {
            if (p_strCheckIDArr == null || p_strCheckIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck
   set status_int = 3, inaccountid_chr = ?, inaccountdate_dat = ?
 where checkid_chr = ? and drugstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    for (int iSEQ = 0; iSEQ < p_strCheckIDArr.Length; iSEQ++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_strEmpID;
                        objLisAddItemRefArr[1].DbType = DbType.DateTime;
                        objLisAddItemRefArr[1].Value = p_dtmAccountDate;
                        objLisAddItemRefArr[2].Value = p_strCheckIDArr[iSEQ];
                        objLisAddItemRefArr[3].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String, DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_strCheckIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_strCheckIDArr[iRow];
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
        /// 设置入帐人及日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">入帐人ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_lngSeq">审核记录的序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate, long p_lngSeq)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck
   set status_int = 3, inaccountid_chr = ?, inaccountdate_dat = ?
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmAccountDate;
                objDPArr[2].Value = p_lngSeq;

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
        #endregion
       
        #region 修改盘盈数量
        /// <summary>
        /// 修改盘盈数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">入库明细序列</param>
        /// <param name="p_dblAmount">盘盈数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyInAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, double p_dblAmount)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_instorage_detail t set t.amount = ? where t.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_dblAmount;
                objDPArr[1].Value = p_lngSEQ;

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
        #endregion

        #region 修改盘亏数量
        /// <summary>
        /// 修改盘亏数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">出库明细序列</param>
        /// <param name="p_dblAmount">盘亏数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyOutAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, double p_dblAmount)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_outstorage_detail t
	 set t.opamount_int = ?, t.ipamount_int = t.packqty_dec * ?
 where t.seriesid_int = ?	";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_dblAmount;
                objDPArr[1].Value = p_dblAmount;
                objDPArr[2].Value = p_lngSEQ;

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
        #endregion

        #region 保存盘盈数据至入库表
        /// <summary>
        /// 保存盘盈数据至入库表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objInMain">入库主表信息</param>
        /// <param name="p_objInDetail">入库明细信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveCheckToInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Instorage_VO p_objInMain, clsDS_Instorage_Detail p_objInDetail)
        {
            if (p_objInMain == null || p_objInDetail == null)
            {
                return -1;
            }

            long lngRes = 0;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
            IDataParameter[] objLisAddItemRefArr = null;

            string m_strTypeCode = string.Empty;
            DataTable m_dtbTypeCode = new DataTable();
            string strSQL = @"select typecode_vchr from t_aid_impexptype where typename_vchr like '%盘盈入库%'
and storgeflag_int <> 0 and flag_int = 0 and status_int = 1";
            objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtbTypeCode);
            if (m_dtbTypeCode.Rows.Count > 0)
            {
                m_strTypeCode = m_dtbTypeCode.Rows[0]["typecode_vchr"].ToString();
            }

            try
            {
                strSQL = @"insert into t_ds_instorage a
  (seriesid_int,
			 formtype_int,
			 a.status,
			 a.drugstoreid_chr,
			 a.inaccounterid_chr,
			 a.indrugstoreid_vchr,
			 a.makeorder_dat,
			 a.drugstoreexam_date,			 
			 a.comment_vchr,
			 makerid_chr,
			 a.drugstoreexamid_chr,typecode_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";


                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_INSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                objHRPServ.CreateDatabaseParameter(12, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objInMain.m_intFORMTYPE_INT;
                objLisAddItemRefArr[2].Value = p_objInMain.m_intSTATUS;
                objLisAddItemRefArr[3].Value = p_objInMain.m_strDRUGSTOREID_INT;
                objLisAddItemRefArr[4].Value = p_objInMain.m_strINACCOUNTERID_CHR;
                objLisAddItemRefArr[5].Value = p_objInMain.m_strINDRUGSTOREID_VCHR;
                objLisAddItemRefArr[6].Value = p_objInMain.m_datMAKEORDER_DAT;
                if (p_objInMain.m_datDRUGSTOREEXAM_DATE == DateTime.MinValue)
                {
                    objLisAddItemRefArr[7].Value = DBNull.Value;
                }
                else
                {
                    objLisAddItemRefArr[7].Value = p_objInMain.m_datDRUGSTOREEXAM_DATE;
                }
                objLisAddItemRefArr[8].Value = p_objInMain.m_strCOMMENT_VCHR;
                objLisAddItemRefArr[9].Value = p_objInMain.m_strMAKERID_CHR;
                objLisAddItemRefArr[10].Value = p_objInMain.m_strSTORAGEEXAMID_CHR;
                objLisAddItemRefArr[11].Value = m_strTypeCode;
                long lngRecEff = -1;
                //往表增加记录

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_instorage_detail a
  (a.seriesid_int,
   a.seriesid2_int,
   a.medicineid_chr,
   a.medicinename_vchr,
   a.medspec_vchr,
	 a.opamount_int,
	 a.opunit_chr,
	 a.opwholesaleprice_int,
	 a.opretailprice_int,
	 a.ipamount_int,
	 a.ipunit_chr,
	 a.ipwholesaleprice_int,
	 a.ipretailprice_int,
	 a.packqty_dec,
	 a.lotno_vchr,
	 a.validperiod_dat,
	 a.status,
	 a.productorid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                long lngSubSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", out lngSubSEQ);

                objHRPServ.CreateDatabaseParameter(18, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSubSEQ;
                objLisAddItemRefArr[1].Value = lngSEQ;
                objLisAddItemRefArr[2].Value = p_objInDetail.m_strMEDICINEID_CHR;
                objLisAddItemRefArr[3].Value = p_objInDetail.m_strMEDICINENAME_VCHR;
                objLisAddItemRefArr[4].Value = p_objInDetail.m_strMEDSPEC_VCHR;
                objLisAddItemRefArr[5].Value = p_objInDetail.m_dblOPAMOUNT_INT;
                objLisAddItemRefArr[6].Value = p_objInDetail.m_strOPUNIT_CHR;
                objLisAddItemRefArr[7].Value = p_objInDetail.m_dblOPWHOLESALEPRICE_INT;
                objLisAddItemRefArr[8].Value = p_objInDetail.m_dblOPRETAILPRICE_INT;
                objLisAddItemRefArr[9].Value = p_objInDetail.m_dblIPAMOUNT_INT;
                objLisAddItemRefArr[10].Value = p_objInDetail.m_strIPUNIT_CHR;
                objLisAddItemRefArr[11].Value = p_objInDetail.m_dblIPWHOLESALEPRICE_INT;
                objLisAddItemRefArr[12].Value = p_objInDetail.m_dblIPRETAILPRICE_INT;
                objLisAddItemRefArr[13].Value = p_objInDetail.m_dblPACKQTY_DEC;
                objLisAddItemRefArr[14].Value = p_objInDetail.m_strLOTNO_VCHR;
                objLisAddItemRefArr[15].DbType = DbType.DateTime;
                objLisAddItemRefArr[15].Value = p_objInDetail.m_datVALIDPERIOD_DAT;
                objLisAddItemRefArr[16].Value = p_objInDetail.m_intSTATUS;
                objLisAddItemRefArr[17].Value = p_objInDetail.m_strPRODUCTORID_CHR; ;
                //往表增加记录

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 保存盘亏记录至出库表
        /// <summary>
        /// 保存盘亏记录至出库表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOutMain">出库主表信息</param>
        /// <param name="p_objOutDetail">出库明细信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveCheckToOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_OutStorage_VO p_objOutMain, clsDS_Outstorage_Detail p_objOutDetail)
        {
            if (p_objOutMain == null || p_objOutDetail == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"insert into t_ds_outstorage a
  (a.seriesid_int,
a.outdrugstoreid_vchr,
a.formtype_int,
a.status_int,
a.instoredept_chr,
a.patientid_chr,
a.makeorder_dat,
a.examdate_dat,
a.inaccount_dat,
a.makerid_chr,
a.examid_chr,
a.inaccounterid_chr,
a.comment_vchr,
a.drugstoreid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_OUTSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_objOutMain.m_lngSERIESID_INT = lngSEQ;

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(14, out objDPArr);
                objDPArr[0].Value = p_objOutMain.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objOutMain.m_strOUTDRUGSTOREID_VCHR;
                objDPArr[2].Value = p_objOutMain.m_intFORMTYPE_INT;
                objDPArr[3].Value = p_objOutMain.m_intSTATUS;
                objDPArr[4].Value = p_objOutMain.m_strINSTOREDEPT_CHR;
                objDPArr[5].Value = p_objOutMain.m_strPatientid;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_objOutMain.m_datMAKEORDER_DAT;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[7].Value = p_objOutMain.m_datEXAM_DATE;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = p_objOutMain.m_datINACCOUNT_DAT;
                objDPArr[9].Value = p_objOutMain.m_strMAKERID_CHR;
                objDPArr[10].Value = p_objOutMain.m_strEXAMID_CHR;
                objDPArr[11].Value = p_objOutMain.m_strINACCOUNTERID_CHR;
                objDPArr[12].Value = p_objOutMain.m_strCOMMENT_VCHR;
                objDPArr[13].Value = p_objOutMain.m_strDRUGSTOREID_CHR;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_outstorage_detail a
  (a.seriesid_int,
a.seriesid2_int,
a.medicineid_chr,
a.medicinename_vchr,
a.medspec_vchr,
a.lotno_vchr,
a.validperiod_dat,
a.opamount_int,
a.opunit_chr,
a.opwholesaleprice_int,
a.opretailprice_int,
a.ipamount_int,
a.ipunit_chr,
a.ipwholesaleprice_int,
a.ipretailprice_int,
a.rejectreason,
a.status,
a.packqty_dec,
a.storageseriesid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?)";

                IDataParameter[] objLisAddItemRefArr = null;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_OUTSTORAGE_DETAIL", out lngSEQ);

                objHRPServ.CreateDatabaseParameter(19, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objOutMain.m_lngSERIESID_INT;
                objLisAddItemRefArr[2].Value = p_objOutDetail.m_strMEDICINEID_CHR;
                objLisAddItemRefArr[3].Value = p_objOutDetail.m_strMEDICINENAME_VCHR;
                objLisAddItemRefArr[4].Value = p_objOutDetail.m_strMEDSPEC_VCHR;
                objLisAddItemRefArr[5].Value = p_objOutDetail.m_strLOTNO_VCHR;
                objLisAddItemRefArr[6].DbType = DbType.DateTime;
                objLisAddItemRefArr[6].Value = p_objOutDetail.m_datVALIDPERIOD_DAT;
                objLisAddItemRefArr[7].Value = p_objOutDetail.m_dblOPAMOUNT_INT;
                objLisAddItemRefArr[8].Value = p_objOutDetail.m_strOPUNIT_CHR;
                objLisAddItemRefArr[9].Value = p_objOutDetail.m_dblOPWHOLESALEPRICE_INT;
                objLisAddItemRefArr[10].Value = p_objOutDetail.m_dblOPRETAILPRICE_INT;
                objLisAddItemRefArr[11].Value = p_objOutDetail.m_dblIPAMOUNT_INT;
                objLisAddItemRefArr[12].Value = p_objOutDetail.m_strIPUNIT_CHR;
                objLisAddItemRefArr[13].Value = p_objOutDetail.m_dblIPWHOLESALEPRICE_INT;
                objLisAddItemRefArr[14].Value = p_objOutDetail.m_dblIPRETAILPRICE_INT;
                objLisAddItemRefArr[15].Value = p_objOutDetail.m_strRejectReason;
                objLisAddItemRefArr[16].Value = p_objOutDetail.m_intSTATUS;
                objLisAddItemRefArr[17].Value = p_objOutDetail.m_dblPACKQTY_DEC;
                objLisAddItemRefArr[18].Value = p_objOutDetail.m_intSTORAGESERIESID_CHR;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
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

        #region 将旧有的盘盈记录设为无效
        /// <summary>
        /// 将旧有的盘盈记录设为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_instorage set status = 0 where indrugstoreid_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckID;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    return -1;
                }

                strSQL = @"update t_ds_instorage_detail a
   set a.status = -1
 where a.status = 1
   and exists (select b.seriesid_int
          from t_ds_instorage b
         where a.seriesid2_int = b.seriesid_int
           and b.indrugstoreid_vchr = ?)";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckID;

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
        /// 将旧有的盘盈记录设为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValiDate, double p_dblInPrice)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int mainseq, b.seriesid_int subseq
  from t_ds_instorage a, t_ds_instorage_detail b
 where a.status <> 0
   and b.status = 1
   and a.seriesid_int = b.seriesid2_int
   and a.indrugstoreid_vchr = ?
   and b.medicineid_chr = ?
   and b.lotno_vchr = ?
   and a.indrugstoreid_vchr = ?
   and b.validperiod_dat = ?
   and b.opwholesaleprice_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                objDPArr[0].Value = p_strCheckID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotNO;
                objDPArr[3].Value = p_strInStorageID;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_dtmValiDate;
                objDPArr[5].Value = p_dblInPrice;

                DataTable dtbSEQ = null;
                long lngMainSEQ = 0;
                long lngSubSEQ = 0;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbSEQ, objDPArr);
                if (dtbSEQ != null && dtbSEQ.Rows.Count > 0)
                {
                    lngMainSEQ = Convert.ToInt64(dtbSEQ.Rows[0]["mainseq"]);
                    lngSubSEQ = Convert.ToInt64(dtbSEQ.Rows[0]["subseq"]);
                }

                strSQL = @"update t_ds_instorage set status = 0 where seriesid_int = ?";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngMainSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"update t_ds_instorage_detail a
   set a.status = -1
 where a.seriesid_int = ?";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngSubSEQ;

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
        #endregion

        #region 将旧有的盘亏记录设为无效
        /// <summary>
        /// 将旧有的盘亏记录设为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_outstorage set status_int = 0 where outdrugstoreid_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckID;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"update t_ds_outstorage_detail a
   set a.status = -1
 where a.status = 1
   and exists (select b.seriesid_int
          from t_ds_outstorage b
         where a.seriesid2_int = b.seriesid_int
           and b.outdrugstoreid_vchr = ?)";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strCheckID;

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
        /// 将旧有的盘亏记录设为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValiDate, double p_dblInPrice)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.seriesid_int mainseq, b.seriesid_int subseq
  from t_ds_outstorage a, t_ds_outstorage_detail b
 where a.status_int <> 0
   and b.status = 1
   and a.seriesid_int = b.seriesid2_int
   and a.outdrugstoreid_vchr = ?
   and b.medicineid_chr = ?
   and b.lotno_vchr = ?
   and a.outdrugstoreid_vchr = ''
   and b.validperiod_dat = ?
   and b.opwholesaleprice_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strCheckID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].Value = p_strLotNO;
                objDPArr[3].Value = p_strInStorageID;
                objDPArr[4].DbType = DbType.DateTime;
                objDPArr[4].Value = p_dtmValiDate;
                objDPArr[5].Value = p_dblInPrice;

                DataTable dtbSEQ = null;
                long lngMainSEQ = 0;
                long lngSubSEQ = 0;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbSEQ, objDPArr);
                if (dtbSEQ != null && dtbSEQ.Rows.Count > 0)
                {
                    lngMainSEQ = Convert.ToInt64(dtbSEQ.Rows[0]["mainseq"]);
                    lngSubSEQ = Convert.ToInt64(dtbSEQ.Rows[0]["subseq"]);
                }

                strSQL = @"update t_ds_outstorage set status_int = 0 where seriesid_int = ?";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngMainSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"update t_ds_outstorage_detail a
   set a.status = -1
 where a.seriesid_int = ?";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngSubSEQ;

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
        #endregion

        #region 修改库存明细表库存数量

        /// <summary>
        /// 修改库存明细表库存数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOutArr">更改库存VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] p_objOutArr)
        {
            if (p_objOutArr == null || p_objOutArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage_detail a
	 set oprealgross_int        = oprealgross_int + ?,
			 opavailablegross_num   = opavailablegross_num + ?,
			 a.iprealgross_int      = a.iprealgross_int + ?,
			 a.ipavailablegross_num = a.ipavailablegross_num + ?
 where medicineid_chr = ?
	 and lotno_vchr = ?
	 and drugstoreid_chr = ?
	 and iprealgross_int + ? >= 0
	 and ipavailablegross_num + ? >= 0
	 and status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_objOutArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(9, out objDPArr);
                        objDPArr[0].Value = Math.Round(p_objOutArr[iRow].m_dblIPREALGROSS_INT / p_objOutArr[iRow].m_dblPACKQTY_DEC,2,MidpointRounding.AwayFromZero);
                        objDPArr[1].Value = Math.Round(p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objOutArr[iRow].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
                        objDPArr[2].Value = p_objOutArr[iRow].m_dblIPREALGROSS_INT;
                        objDPArr[3].Value = p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM;
                        objDPArr[4].Value = p_objOutArr[iRow].m_strMEDICINEID_CHR;
                        objDPArr[5].Value = p_objOutArr[iRow].m_strLOTNO_VCHR;
                        objDPArr[6].Value = p_objOutArr[iRow].m_strDRUGSTOREID_CHR;
                        objDPArr[7].Value = p_objOutArr[iRow].m_dblIPREALGROSS_INT;
                        objDPArr[8].Value = p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double,DbType.Double, DbType.Double,
                        DbType.String, DbType.String,DbType.String, DbType.Double, DbType.Double };

                    object[][] objValues = new object[9][];

                    int intItemCount = p_objOutArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = Math.Round(p_objOutArr[iRow].m_dblIPREALGROSS_INT / p_objOutArr[iRow].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
                        objValues[1][iRow] = Math.Round(p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objOutArr[iRow].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
                        objValues[2][iRow] = p_objOutArr[iRow].m_dblIPREALGROSS_INT;
                        objValues[3][iRow] = p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM;
                        objValues[4][iRow] = p_objOutArr[iRow].m_strMEDICINEID_CHR;
                        objValues[5][iRow] = p_objOutArr[iRow].m_strLOTNO_VCHR;
                        objValues[6][iRow] = p_objOutArr[iRow].m_strDRUGSTOREID_CHR;
                        objValues[7][iRow] = p_objOutArr[iRow].m_dblIPREALGROSS_INT;
                        objValues[8][iRow] = p_objOutArr[iRow].m_dblIPAVAILABLEGROSS_NUM;
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

        #region 删除盘点明细
        /// <summary>
        /// 删除盘点明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageCheckDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck_detail a
   set a.status_int = 0
 where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

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
        #endregion

        #region 删除盘点信息
        /// <summary>
        /// 删除盘点信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck set status_int = 0 where seriesid_int = ? and status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if(lngEff != 1)
                {
                    ContextUtil.SetAbort();
                    return -99;
                }
                if (lngRes > 0)
                {
                    lngRes = m_lngUpdateStorageDetailStatusByMainSEQ(p_objPrincipal, 0, p_lngSEQ);
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
        /// 更新盘点明细表状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageDetailStatusByMainSEQ(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_drugstorecheck_detail a set a.status_int = ? where a.seriesid2_int = ? and a.status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_intStatus;
                objDPArr[1].Value = p_lngMainSEQ;

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
        #endregion

        #region 修改库存主表药品当前数量
        /// <summary>
        /// 修改库存主表药品当前数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineIDArr">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageGross(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strMedicineIDArr, string p_strStorageID)
        {
            if (p_strMedicineIDArr == null || p_strMedicineIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_storage a
	 set a.opcurrentgross_num = (select sum(b.oprealgross_int)
																 from t_ds_storage_detail b
																where b.status = 1
																	and b.medicineid_chr = ?
																	and b.drugstoreid_chr = ?),
			 a.ipcurrentgross_num = (select sum(b.iprealgross_int)
																 from t_ds_storage_detail b
																where b.status = 1
																	and b.medicineid_chr = ?
																	and b.drugstoreid_chr = ?)
 where a.medicineid_chr = ?
	 and a.drugstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_strMedicineIDArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(6, out objDPArr);
                        objDPArr[0].Value = p_strMedicineIDArr[iRow];
                        objDPArr[1].Value = p_strStorageID;
                        objDPArr[2].Value = p_strMedicineIDArr[iRow];
                        objDPArr[3].Value = p_strStorageID;
                        objDPArr[4].Value = p_strMedicineIDArr[iRow];
                        objDPArr[5].Value = p_strStorageID;

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };

                    object[][] objValues = new object[6][];

                    int intItemCount = p_strMedicineIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strMedicineIDArr[iRow];
                        objValues[1][iRow] = p_strStorageID;
                        objValues[2][iRow] = p_strMedicineIDArr[iRow];
                        objValues[3][iRow] = p_strStorageID;
                        objValues[4][iRow] = p_strMedicineIDArr[iRow];
                        objValues[5][iRow] = p_strStorageID;
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

        #region 审核盘点
        /// <summary>
        /// 审核盘点
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_objDefCheckDetail">盘亏明细</param>
        /// <param name="p_objSufCheckDetail">盘盈明细</param>
        /// <param name="p_objStDetail">盘点药品相关库存明细</param>
        /// <param name="p_strMedicineIDArr">盘点药品ID</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strCreatorID">盘点人ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsImmAccount">是否盘点即审核</param>
        /// <param name="p_strCommit">审核流程</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, clsDS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsDS_StorageCheckDetail_VO[] p_objSufCheckDetail, clsDS_StorageDetail_VO[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, DateTime p_dtmCommitDate,
             string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID, bool p_blnIsImmAccount,string p_strCommit,bool p_blnIsHospital)
        {
            long lngRes = 0;
            try
            {
                if (p_objDefCheckDetail != null && p_objDefCheckDetail.Length > 0)
                { 
                    //20090703:盘亏的时候，根据盘亏数量，对每个药品从批次最小开始，减去该数量。
                    clsDS_Outstorage_Detail[] objOutDetailArr = null;
                    m_lngTransToOutDetail(p_objPrincipal, p_strStorageID, p_blnIsHospital,p_objDefCheckDetail, out objOutDetailArr);
                    
                    //lngRes = m_lngSaveCheckToOutStorageOne(p_objPrincipal, m_objMainOutVO(p_objDefCheckDetail[0], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID), p_objDefCheckDetail,p_blnIsHospital);
                    string strTemp = string.Empty;
                    clsDS_OutStorage_VO objOutMain = m_objMainOutVO(p_objDefCheckDetail[0], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID);
                    lngRes = m_lngAddNewOutstorageInfo(p_objPrincipal, ref objOutMain,ref objOutDetailArr, 1, p_strEmpID, out strTemp);
                    if (lngRes <= 0)
                    {
                        throw new Exception("保存盘亏出库数据时出错");
                    }
                    //注意，此处已写入流水帐表，下面不需再写入流水帐表
                }

                if (p_objSufCheckDetail != null && p_objSufCheckDetail.Length > 0)
                { 

                    //20090703:盘盈时，直接加到批号最大的记录上。
                    clsDS_Instorage_Detail[] objInDetailArr = null;
                    m_lngTransToInDetail(p_objPrincipal, p_strStorageID, p_blnIsHospital, p_objSufCheckDetail, out objInDetailArr);
                    clsInstorage_SVC objInSvc = new clsInstorage_SVC();
                    clsDS_Instorage_VO objInMain = m_objMainInVO(p_objSufCheckDetail[0], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID);
                    lngRes = objInSvc.m_lngAddNewInstorage(p_objPrincipal, ref objInMain,ref objInDetailArr, 1, p_strEmpID);
                    //lngRes = m_lngSaveCheckToInStorageOne(p_objPrincipal, m_objMainInVO(p_objSufCheckDetail[0], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID),p_objSufCheckDetail,p_blnIsHospital);
                    if (lngRes <= 0)
                    {
                        throw new Exception("保存盘盈入库数据时出错");
                    }
                    
                }

                if (p_strCommit == "0")
                {
                    lngRes = m_lngSetCommitUser(p_objPrincipal, p_strEmpID, p_lngMainSEQ);
                    if (lngRes <= 0)
                    {
                        ContextUtil.SetAbort();
                        if (lngRes == -99)
                        {
                            return -99;
                        }
                        else
                        {
                            throw new Exception("设置审核状态时出错");
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
        /// 盘亏的时候，根据盘亏数量，对每个药品从批次最小开始，减去该数量。
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <param name="p_objDefCheckDetail"></param>
        /// <param name="objOutDetailArr"></param>
        private void m_lngTransToOutDetail(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStorageID,bool p_blnIsHospital,clsDS_StorageCheckDetail_VO[] p_objDefCheckDetail, out clsDS_Outstorage_Detail[] objOutDetailArr)
        {
            objOutDetailArr = null;

            DataTable dtbStorageDetail = new DataTable();
            clsGetStoreCheckMedicine_Supported_SVC objStorageDetailSvc = new clsGetStoreCheckMedicine_Supported_SVC();
            objStorageDetailSvc.m_lngGetAllMedicineForCommit(p_objPrincipal, p_strStorageID, p_blnIsHospital, out dtbStorageDetail);
            DataView dv = dtbStorageDetail.DefaultView;
            dv.Sort = "checkmedicineorder_chr,assistcode_chr,medicineid_chr,opretailprice_int,lotno_vchr";
            dtbStorageDetail = dv.ToTable();

            List<clsDS_Outstorage_Detail> lstOutDetail = new List<clsDS_Outstorage_Detail>();
            clsDS_Outstorage_Detail objOutDetail = null;
            DataTable dtbTemp = null;
            DataRow dr = null;

            double dblOPTemp = 0d;
            double dblIPTemp = 0d;
            for (int i1 = 0; i1 < p_objDefCheckDetail.Length; i1++)
            {
                dtbTemp = dtbStorageDetail.Copy();
                dtbTemp.DefaultView.RowFilter = "medicineid_chr = '" + p_objDefCheckDetail[i1].m_strMedicineCode + "' and opretailprice_int = " +
                    Math.Round(p_objDefCheckDetail[i1].m_dblOPRETAILPRICE_INT,4) + " and iprealgross_int > 0 ";
                dtbTemp = dtbTemp.DefaultView.ToTable();

                for (int i2 = 0; i2 < dtbTemp.Rows.Count; i2++)
                {
                    if (p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT < 0 || p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT < 0)
                    {
                        objOutDetail = new clsDS_Outstorage_Detail();
                        dr = dtbTemp.Rows[i2];
                        objOutDetail.m_strMEDICINEID_CHR = p_objDefCheckDetail[i1].m_strMedicineCode;
                        objOutDetail.m_strMEDICINENAME_VCHR = p_objDefCheckDetail[i1].m_strMEDICINENAME_VCHR;
                        objOutDetail.m_strMEDSPEC_VCHR = p_objDefCheckDetail[i1].m_strMEDSPEC_VCHR;
                        objOutDetail.m_strOPUNIT_CHR = p_objDefCheckDetail[i1].m_strOPUNIT_CHR;
                        objOutDetail.m_strIPUNIT_CHR = p_objDefCheckDetail[i1].m_strIPUNIT_CHR;
                        objOutDetail.m_strLOTNO_VCHR = dr["lotno_vchr"].ToString() == "" ? "UNKNOWN" : dr["lotno_vchr"].ToString();
                        if(Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd") != "0001-01-01")
                            objOutDetail.m_datVALIDPERIOD_DAT = Convert.ToDateTime(dr["validperiod_dat"]);

                        objOutDetail.m_dblOPWHOLESALEPRICE_INT = p_objDefCheckDetail[i1].m_dblOPCALLPRICE_INT;
                        objOutDetail.m_dblOPRETAILPRICE_INT = p_objDefCheckDetail[i1].m_dblOPRETAILPRICE_INT;
                        objOutDetail.m_dblIPWHOLESALEPRICE_INT = p_objDefCheckDetail[i1].m_dblIPCALLPRICE_INT;
                        objOutDetail.m_dblIPRETAILPRICE_INT = p_objDefCheckDetail[i1].m_dblIPRETAILPRICE_INT;

                        dblOPTemp = p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT;
                        dblIPTemp = p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT;

                        if (Convert.ToDouble(dr["ipavailablegross_num"]) >= (Math.Abs(p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT) + Math.Abs(p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT) * p_objDefCheckDetail[i1].m_dblPACKQTY_DEC))
                        {
                            objOutDetail.m_dblOPAMOUNT_INT = -p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT + (-p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT / p_objDefCheckDetail[i1].m_dblPACKQTY_DEC);
                            objOutDetail.m_dblIPAMOUNT_INT = -p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT * p_objDefCheckDetail[i1].m_dblPACKQTY_DEC + (-p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT);
                            p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT = 0;
                            p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT = 0;
                        }
                        else
                        {
                            objOutDetail.m_dblOPAMOUNT_INT = Convert.ToDouble(dr["opavailablegross_num"]);
                            objOutDetail.m_dblIPAMOUNT_INT = Convert.ToDouble(dr["ipavailablegross_num"]);
                            p_objDefCheckDetail[i1].m_dblIPCHECKRESULT_INT = (dblOPTemp * p_objDefCheckDetail[i1].m_dblPACKQTY_DEC + dblIPTemp + Convert.ToDouble(dr["ipavailablegross_num"])) % p_objDefCheckDetail[i1].m_dblPACKQTY_DEC;
                            p_objDefCheckDetail[i1].m_dblOPCHECKRESULT_INT = (int)((dblOPTemp * p_objDefCheckDetail[i1].m_dblPACKQTY_DEC + dblIPTemp + Convert.ToDouble(dr["ipavailablegross_num"])) / p_objDefCheckDetail[i1].m_dblPACKQTY_DEC);
                        }    
                        objOutDetail.m_strRejectReason = p_objDefCheckDetail[i1].m_strCHECKREASON_VCHR;
                        objOutDetail.m_intSTATUS = 1;
                        objOutDetail.m_dblPACKQTY_DEC = p_objDefCheckDetail[i1].m_dblPACKQTY_DEC;
                        objOutDetail.m_strPRODUCTORID_CHR = p_objDefCheckDetail[i1].m_strPRODUCTORID_CHR;
                        objOutDetail.m_intSTORAGESERIESID_CHR = dr["seriesid_int"].ToString();                        
                        lstOutDetail.Add(objOutDetail);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            objOutDetailArr = new clsDS_Outstorage_Detail[lstOutDetail.Count];
            lstOutDetail.CopyTo(objOutDetailArr);
        }

        /// <summary>
        /// 盘盈的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <param name="p_objSufCheckDetail"></param>
        /// <param name="objInDetailArr"></param>
        private void m_lngTransToInDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, bool p_blnIsHospital, clsDS_StorageCheckDetail_VO[] p_objSufCheckDetail, out clsDS_Instorage_Detail[] objInDetailArr)
        {
            objInDetailArr = null;

            DataTable dtbStorageDetail = new DataTable();
            clsGetStoreCheckMedicine_Supported_SVC objStorageDetailSvc = new clsGetStoreCheckMedicine_Supported_SVC();
            objStorageDetailSvc.m_lngGetAllMedicineForCommit(p_objPrincipal, p_strStorageID, p_blnIsHospital, out dtbStorageDetail);

            DataView dv = dtbStorageDetail.DefaultView;
            dv.Sort = "checkmedicineorder_chr,assistcode_chr,medicineid_chr,opretailprice_int,lotno_vchr desc";
            dtbStorageDetail = dv.ToTable();

            List<clsDS_Instorage_Detail> lstInDetail = new List<clsDS_Instorage_Detail>();
            clsDS_Instorage_Detail objInDetail = null;
            DataTable dtbTemp = null;
            DataRow dr = null;
            Hashtable hstDone = new Hashtable();
            double dblopretailprice = 0d;
            for (int i1 = 0; i1 < p_objSufCheckDetail.Length; i1++)
            {
                dblopretailprice = Math.Round(p_objSufCheckDetail[i1].m_dblOPRETAILPRICE_INT, 4);
                dtbTemp = dtbStorageDetail.Copy();
                dtbTemp.DefaultView.RowFilter = "medicineid_chr = '" + p_objSufCheckDetail[i1].m_strMedicineCode + "' and opretailprice_int = "+
                    dblopretailprice + " and iprealgross_int > 0 ";
                dtbTemp = dtbTemp.DefaultView.ToTable();

                if (dtbTemp.Rows.Count == 0)
                {
                    dtbTemp = dtbStorageDetail.Copy();
                    dtbTemp.DefaultView.RowFilter = "medicineid_chr = '" + p_objSufCheckDetail[i1].m_strMedicineCode + "' and opretailprice_int = " +
                    dblopretailprice;
                    dtbTemp = dtbTemp.DefaultView.ToTable();
                }

                for (int i2 = 0; i2 < dtbTemp.Rows.Count; i2++)
                {
                    dr = dtbTemp.Rows[i2];

                    if (hstDone.ContainsKey(dr["medicineid_chr"].ToString()+dr["opretailprice_int"].ToString()))
                        continue;

                    objInDetail = new clsDS_Instorage_Detail();

                    objInDetail.m_strMEDICINEID_CHR = p_objSufCheckDetail[i1].m_strMedicineCode;
                    objInDetail.m_strMEDICINENAME_VCHR = p_objSufCheckDetail[i1].m_strMEDICINENAME_VCHR;
                    objInDetail.m_strMEDSPEC_VCHR = p_objSufCheckDetail[i1].m_strMEDSPEC_VCHR;
                    objInDetail.m_strOPUNIT_CHR = p_objSufCheckDetail[i1].m_strOPUNIT_CHR;
                    objInDetail.m_strIPUNIT_CHR = p_objSufCheckDetail[i1].m_strIPUNIT_CHR;
                    objInDetail.m_strLOTNO_VCHR = dr["lotno_vchr"].ToString() == "" ? "UNKNOWN" : dr["lotno_vchr"].ToString();
                    if (Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd") == "0001-01-01")
                        objInDetail.m_datVALIDPERIOD_DAT = Convert.ToDateTime(dr["validperiod_dat"]);

                    objInDetail.m_dblOPAMOUNT_INT = p_objSufCheckDetail[i1].m_dblOPCHECKRESULT_INT + Math.Round(p_objSufCheckDetail[i1].m_dblIPCHECKRESULT_INT / p_objSufCheckDetail[i1].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
                    objInDetail.m_dblIPAMOUNT_INT = p_objSufCheckDetail[i1].m_dblOPCHECKRESULT_INT * p_objSufCheckDetail[i1].m_dblPACKQTY_DEC + p_objSufCheckDetail[i1].m_dblIPCHECKRESULT_INT;
                    objInDetail.m_dblOPWHOLESALEPRICE_INT = p_objSufCheckDetail[i1].m_dblOPCALLPRICE_INT;
                    objInDetail.m_dblOPRETAILPRICE_INT = p_objSufCheckDetail[i1].m_dblOPRETAILPRICE_INT;
                    objInDetail.m_dblIPWHOLESALEPRICE_INT = p_objSufCheckDetail[i1].m_dblIPCALLPRICE_INT;
                    objInDetail.m_dblIPRETAILPRICE_INT = p_objSufCheckDetail[i1].m_dblOPCALLPRICE_INT;

                    objInDetail.m_intSTATUS = 1;
                    objInDetail.m_dblPACKQTY_DEC = p_objSufCheckDetail[i1].m_dblPACKQTY_DEC;
                    objInDetail.m_strPRODUCTORID_CHR = p_objSufCheckDetail[i1].m_strPRODUCTORID_CHR;
                    objInDetail.m_strStorageSeriesID = dr["seriesid_int"].ToString();
                    lstInDetail.Add(objInDetail);
                    hstDone.Add(dr["medicineid_chr"].ToString() + dr["opretailprice_int"].ToString(), null);
                }
            }
            objInDetailArr = new clsDS_Instorage_Detail[lstInDetail.Count];
            lstInDetail.CopyTo(objInDetailArr);
        }

        private long m_lngSaveCheckToInStorageOne(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Instorage_VO p_objInMain, clsDS_StorageCheckDetail_VO[] p_objSufCheckDetail,bool p_blnIsHospital)
        {
            if (p_objInMain == null || p_objSufCheckDetail == null)
            {
                return -1;
            }

            long lngRes = 0;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
            IDataParameter[] objLisAddItemRefArr = null;

            try
            {
                string strSQL = @"insert into t_ds_instorage a
  (seriesid_int,
			 formtype_int,
			 a.status,
			 a.drugstoreid_chr,
			 a.inaccounterid_chr,
			 a.indrugstoreid_vchr,
			 a.makeorder_dat,
			 a.drugstoreexam_date,			 
			 a.comment_vchr,
			 makerid_chr,
			 a.drugstoreexamid_chr,typecode_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";


                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_INSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                objHRPServ.CreateDatabaseParameter(12, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objInMain.m_intFORMTYPE_INT;
                objLisAddItemRefArr[2].Value = p_objInMain.m_intSTATUS;
                objLisAddItemRefArr[3].Value = p_objInMain.m_strDRUGSTOREID_INT;
                objLisAddItemRefArr[4].Value = p_objInMain.m_strINACCOUNTERID_CHR;
                objLisAddItemRefArr[5].Value = p_objInMain.m_strINDRUGSTOREID_VCHR;
                objLisAddItemRefArr[6].Value = p_objInMain.m_datMAKEORDER_DAT;
                if (p_objInMain.m_datDRUGSTOREEXAM_DATE == DateTime.MinValue)
                {
                    objLisAddItemRefArr[7].Value = DBNull.Value;
                }
                else
                {
                    objLisAddItemRefArr[7].Value = p_objInMain.m_datDRUGSTOREEXAM_DATE;
                }
                objLisAddItemRefArr[8].Value = p_objInMain.m_strCOMMENT_VCHR;
                objLisAddItemRefArr[9].Value = p_objInMain.m_strMAKERID_CHR;
                objLisAddItemRefArr[10].Value = p_objInMain.m_strSTORAGEEXAMID_CHR;
                objLisAddItemRefArr[11].Value = p_objInMain.m_strTYPECODE_VCHR;
                long lngRecEff = -1;
                //往表增加记录

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_instorage_detail a
  (a.seriesid_int,
   a.seriesid2_int,
   a.medicineid_chr,
   a.medicinename_vchr,
   a.medspec_vchr,
	 a.opamount_int,
	 a.opunit_chr,
	 a.opwholesaleprice_int,
	 a.opretailprice_int,
	 a.ipamount_int,
	 a.ipunit_chr,
	 a.ipwholesaleprice_int,
	 a.ipretailprice_int,
	 a.packqty_dec,
	 a.lotno_vchr,
	 a.validperiod_dat,
	 a.status,
	 a.productorid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                long[] lngSEQArr = null;
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.Double,DbType.String,
                        DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.String,
                        DbType.DateTime,DbType.Int32,DbType.String };

                object[][] objValues = new object[18][];

                int intItemCount = p_objSufCheckDetail.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", intItemCount, out lngSEQArr);
                if (lngSEQArr == null || lngSEQArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = lngSEQArr[iRow];
                    objValues[1][iRow] = lngSEQ;
                    objValues[2][iRow] = p_objSufCheckDetail[iRow].m_strMedicineCode;
                    objValues[3][iRow] = p_objSufCheckDetail[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = p_objSufCheckDetail[iRow].m_strMEDSPEC_VCHR;

                    objValues[5][iRow] = p_objSufCheckDetail[iRow].m_dblOPCHECKRESULT_INT;
                    objValues[6][iRow] = p_objSufCheckDetail[iRow].m_strOPUNIT_CHR;
                    objValues[7][iRow] = p_objSufCheckDetail[iRow].m_dblOPCALLPRICE_INT;
                    objValues[8][iRow] = p_objSufCheckDetail[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[9][iRow] = p_objSufCheckDetail[iRow].m_dblIPCHECKRESULT_INT;
                    objValues[10][iRow] = p_objSufCheckDetail[iRow].m_strIPUNIT_CHR;
                    objValues[11][iRow] = p_objSufCheckDetail[iRow].m_dblIPCALLPRICE_INT;
                    objValues[12][iRow] = p_objSufCheckDetail[iRow].m_dblIPCHECKRESULT_INT;

                    objValues[13][iRow] = p_objSufCheckDetail[iRow].m_dblPACKQTY_DEC;
                    objValues[14][iRow] = p_objSufCheckDetail[iRow].m_strLOTNO_VCHR;
                    objValues[15][iRow] = p_objSufCheckDetail[iRow].m_dtmVALIDPERIOD_DAT;
                    objValues[16][iRow] = p_objSufCheckDetail[iRow].m_intSTATUS_INT;
                    objValues[17][iRow] = p_objSufCheckDetail[iRow].m_strPRODUCTORID_CHR;
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
            return lngRes;
        }

        #region 一张盘点单的所有盘亏记录保存到同一张出库单
        /// <summary>
        /// 一张盘点单的所有盘亏记录保存到同一张出库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOutMain">出库主表</param>
        /// <param name="p_objDefCheckDetail">盘点明细</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSaveCheckToOutStorageOne(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_OutStorage_VO p_objOutMain, clsDS_StorageCheckDetail_VO[] p_objDefCheckDetail,bool p_blnIsHospital)
        {
            if (p_objOutMain == null || p_objDefCheckDetail == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"insert into t_ds_outstorage a
  (a.seriesid_int,
a.outdrugstoreid_vchr,
a.formtype_int,
a.status_int,
a.instoredept_chr,
a.patientid_chr,
a.makeorder_dat,
a.examdate_dat,
a.inaccount_dat,
a.makerid_chr,
a.examid_chr,
a.inaccounterid_chr,
a.comment_vchr,
a.drugstoreid_chr,
a.typecode_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_OUTSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }
                p_objOutMain.m_lngSERIESID_INT = lngSEQ;

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(15, out objDPArr);
                objDPArr[0].Value = p_objOutMain.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objOutMain.m_strOUTDRUGSTOREID_VCHR;
                objDPArr[2].Value = p_objOutMain.m_intFORMTYPE_INT;
                objDPArr[3].Value = p_objOutMain.m_intSTATUS;
                objDPArr[4].Value = p_objOutMain.m_strINSTOREDEPT_CHR;
                objDPArr[5].Value = p_objOutMain.m_strPatientid;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_objOutMain.m_datMAKEORDER_DAT;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[7].Value = p_objOutMain.m_datEXAM_DATE;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = p_objOutMain.m_datINACCOUNT_DAT;
                objDPArr[9].Value = p_objOutMain.m_strMAKERID_CHR;
                objDPArr[10].Value = p_objOutMain.m_strEXAMID_CHR;
                objDPArr[11].Value = p_objOutMain.m_strINACCOUNTERID_CHR;
                objDPArr[12].Value = p_objOutMain.m_strCOMMENT_VCHR;
                objDPArr[13].Value = p_objOutMain.m_strDRUGSTOREID_CHR;
                objDPArr[14].Value = p_objOutMain.m_strTYPECODE_VCHR;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_outstorage_detail a
  (a.seriesid_int,
a.seriesid2_int,
a.medicineid_chr,
a.medicinename_vchr,
a.medspec_vchr,
a.lotno_vchr,
a.validperiod_dat,
a.opamount_int,
a.opunit_chr,
a.opwholesaleprice_int,
a.opretailprice_int,
a.ipamount_int,
a.ipunit_chr,
a.ipwholesaleprice_int,
a.ipretailprice_int,
a.rejectreason,
a.status,
a.packqty_dec,
a.storageseriesid_chr,
a.productorid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?)";

                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,
                        DbType.Double,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Double,DbType.Double,DbType.String,
                        DbType.Int32,DbType.Double,DbType.String,DbType.String};

                object[][] objValues = new object[20][];

                int intItemCount = p_objDefCheckDetail.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                long[] lngSEQArr = null;
                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_OUTSTORAGE_DETAIL", intItemCount, out lngSEQArr);
                if (lngSEQArr == null || lngSEQArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = lngSEQArr[iRow];
                    objValues[1][iRow] = lngSEQ;
                    objValues[2][iRow] = p_objDefCheckDetail[iRow].m_strMedicineCode;
                    objValues[3][iRow] = p_objDefCheckDetail[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = p_objDefCheckDetail[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = p_objDefCheckDetail[iRow].m_strLOTNO_VCHR;
                    objValues[6][iRow] = p_objDefCheckDetail[iRow].m_dtmVALIDPERIOD_DAT;

                    objValues[7][iRow] = Math.Abs(p_objDefCheckDetail[iRow].m_dblOPCHECKRESULT_INT);
                    objValues[8][iRow] = p_objDefCheckDetail[iRow].m_strOPUNIT_CHR;
                    objValues[9][iRow] = p_objDefCheckDetail[iRow].m_dblOPCALLPRICE_INT;
                    objValues[10][iRow] = p_objDefCheckDetail[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[11][iRow] = Math.Abs(p_objDefCheckDetail[iRow].m_dblIPCHECKRESULT_INT);
                    objValues[12][iRow] = p_objDefCheckDetail[iRow].m_strIPUNIT_CHR;
                    objValues[13][iRow] = p_objDefCheckDetail[iRow].m_dblIPCALLPRICE_INT;
                    objValues[14][iRow] = p_objDefCheckDetail[iRow].m_dblIPRETAILPRICE_INT;

                    objValues[15][iRow] = p_objDefCheckDetail[iRow].m_strCHECKREASON_VCHR;
                    objValues[16][iRow] = p_objDefCheckDetail[iRow].m_intSTATUS_INT;
                    objValues[17][iRow] = p_objDefCheckDetail[iRow].m_dblPACKQTY_DEC;
                    objValues[18][iRow] = string.Empty;
                    objValues[19][iRow] = p_objDefCheckDetail[iRow].m_strPRODUCTORID_CHR;
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
            return lngRes;
        }
        #endregion 

        #region 新增账本明细
        /// <summary>
        /// 新增账本明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objForUpdateArr">账本明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_AccountDetail_VO[] m_objForUpdateArr)
        {
            if (m_objForUpdateArr == null || m_objForUpdateArr.Length == 0)
            {
                return -1;
            }            
            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_account_detail a
  (a.seriesid_int,
   a.medicineid_chr,
   a.medicinename_vchr,
   a.medicinetypeid_chr,
   a.medspec_vchr,
   a.drugstoreid_int,
   a.lotno_vchr,
   a.validperiod_dat,
   a.instoreid_vchr,
   a.ipwholesaleprice_int,
   a.opwholesaleprice_int,
   a.ipretailprice_int,
   a.opretailprice_int,
   a.instoragedate_dat,
   a.ipunit_chr,
   a.ipamount_int,
   a.opamount_int,
   a.opunit_chr,
   a.ipoldgross_int,
   a.opoldgross_int,
   a.type_int,
   a.deptid_chr,
   a.chittyid_vchr,
   a.formtype_int,
   a.state_int,
   a.isend_int,
   a.endipamount_int,
   a.endopamount_int,
   a.endipwholesaleprice_int,
   a.endopwholesaleprice_int,
   a.endipretailprice_int,
   a.endopretailprice_int,
   a.inaccountid_chr,
   a.inaccountdate_dat,
   a.accountid_chr,
   a.productorid_chr,operatedate_dat,packqty_dec)
values
  (?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,?,sysdate,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long[] lngSEQArr = null;
                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_ACCOUNT_DETAIL", m_objForUpdateArr.Length, out lngSEQArr);


                DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,
                        DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.DateTime,DbType.String,DbType.Double,DbType.Double,DbType.String,
                        DbType.Double,DbType.Double,DbType.Int16,DbType.String,DbType.String,DbType.Int16,DbType.Int16,DbType.Int16,DbType.Double,DbType.Double,
                        DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.DateTime,DbType.String,DbType.String,DbType.Double};

                object[][] objValues = new object[37][];

                int intItemCount = m_objForUpdateArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                if (lngSEQArr == null || lngSEQArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = lngSEQArr[iRow];
                    objValues[1][iRow] = m_objForUpdateArr[iRow].m_strMEDICINEID_CHR;
                    objValues[2][iRow] = m_objForUpdateArr[iRow].m_strMEDICINENAME_VCH;
                    objValues[3][iRow] = m_objForUpdateArr[iRow].m_strMEDICINETYPEID_CHR;
                    objValues[4][iRow] = m_objForUpdateArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = m_objForUpdateArr[iRow].m_strDrugStoreID_CHR;
                    objValues[6][iRow] = m_objForUpdateArr[iRow].m_strLOTNO_VCHR;
                    objValues[7][iRow] = m_objForUpdateArr[iRow].m_dtmValidDate;
                    objValues[8][iRow] = m_objForUpdateArr[iRow].m_strINSTORAGEID_VCHR;
                    objValues[9][iRow] = m_objForUpdateArr[iRow].m_dblIPCALLPRICE_INT;
                    objValues[10][iRow] = m_objForUpdateArr[iRow].m_dblOPCALLPRICE_INT;
                    objValues[11][iRow] = m_objForUpdateArr[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[12][iRow] = m_objForUpdateArr[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[13][iRow] = m_objForUpdateArr[iRow].m_dtmOperateDate;
                    objValues[14][iRow] = m_objForUpdateArr[iRow].m_strIPUNIT_CHR;
                    objValues[15][iRow] = m_objForUpdateArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[16][iRow] = m_objForUpdateArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[17][iRow] = m_objForUpdateArr[iRow].m_strOPUNIT_CHR;
                    objValues[18][iRow] = m_objForUpdateArr[iRow].m_dblIPOLDGROSS_INT;
                    objValues[19][iRow] = m_objForUpdateArr[iRow].m_dblOPOLDGROSS_INT;
                    objValues[20][iRow] = m_objForUpdateArr[iRow].m_intTYPE_INT;
                    objValues[21][iRow] = m_objForUpdateArr[iRow].m_strDeptid_chr;
                    objValues[22][iRow] = m_objForUpdateArr[iRow].m_strCHITTYID_VCHR;
                    objValues[23][iRow] = m_objForUpdateArr[iRow].m_intFORMTYPE_INT;
                    objValues[24][iRow] = m_objForUpdateArr[iRow].m_intSTATE_INT;
                    objValues[25][iRow] = 0;
                    objValues[26][iRow] = 0;
                    objValues[27][iRow] = 0;
                    objValues[28][iRow] = 0;
                    objValues[29][iRow] = 0;
                    objValues[30][iRow] = 0;
                    objValues[31][iRow] = 0;
                    objValues[32][iRow] = string.Empty;
                    objValues[33][iRow] = DateTime.MinValue;
                    objValues[34][iRow] = string.Empty;
                    objValues[35][iRow] = m_objForUpdateArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[36][iRow] = m_objForUpdateArr[iRow].m_dblPACKQTY_DEC;

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
            return lngRes;
        }
        #endregion
        /// <summary>
        /// 获取入库主表记录
        /// </summary>
        /// <param name="p_objCheckDetail">盘盈明细</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strCreatorID">盘点人ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        private clsDS_Instorage_VO m_objMainInVO(clsDS_StorageCheckDetail_VO p_objCheckDetail, DateTime p_dtmCommitDate, string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID)
        {
            if (p_objCheckDetail == null)
            {
                return null;
            }
            clsDS_Instorage_VO objISMainVO = new clsDS_Instorage_VO();
            clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
            objISMainVO.m_datMAKEORDER_DAT = p_dtmCheckDate;
            objISMainVO.m_intSTATUS = 1;
            objISMainVO.m_lngSERIESID_INT = 0;
            objISMainVO.m_strINDRUGSTOREID_VCHR = p_strCheckID;
            objISMainVO.m_datDRUGSTOREEXAM_DATE = p_dtmCheckDate;
            objISMainVO.m_strMAKERID_CHR = p_strCreatorID;
            objISMainVO.m_strCOMMENT_VCHR = p_objCheckDetail.m_strCHECKREASON_VCHR;
            //1、请领入库 2、药房自身入库(来源部门是本药房)  3、药房借调（来源部门是其它药房） 4、科室借调（来源部门除了药房以外的部门） 5、盘盈，
            objISMainVO.m_intFORMTYPE_INT = 5;
            objISMainVO.m_strBORROWDEPT_CHR = p_strStorageID;
            objISMainVO.m_strDRUGSTOREID_INT = p_strStorageID;
            int m_intTypeCode;
            objPublic.m_lngGetTypeCodeByName(null, 0, "盘盈入库", out m_intTypeCode);
            objISMainVO.m_strTYPECODE_VCHR = m_intTypeCode.ToString();
            return objISMainVO;
        }

        /// <summary>
        /// 获取入库明细
        /// </summary>
        /// <param name="p_objCheckDetail">盘盈明细</param>
        /// <returns></returns>
        [AutoComplete]
        private clsDS_Instorage_Detail m_objDetailInVO(clsDS_StorageCheckDetail_VO p_objCheckDetail,bool p_blnIsHospital)
        {
            if (p_objCheckDetail == null)
            {
                return null;
            }

            clsDS_Instorage_Detail objNewDetail = new clsDS_Instorage_Detail();

            objNewDetail.m_intSTATUS = 1;
            objNewDetail.m_dblPACKQTY_DEC = p_objCheckDetail.m_dblPACKQTY_DEC;

            objNewDetail.m_dblOPAMOUNT_INT = p_objCheckDetail.m_dblOPCHECKRESULT_INT + Math.Round(p_objCheckDetail.m_dblIPCHECKRESULT_INT / p_objCheckDetail.m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
            objNewDetail.m_dblOPWHOLESALEPRICE_INT = p_objCheckDetail.m_dblOPCALLPRICE_INT;
            objNewDetail.m_dblOPRETAILPRICE_INT = p_objCheckDetail.m_dblOPRETAILPRICE_INT;
            objNewDetail.m_dblIPAMOUNT_INT = p_objCheckDetail.m_dblOPCHECKRESULT_INT * p_objCheckDetail.m_dblPACKQTY_DEC + p_objCheckDetail.m_dblIPCHECKRESULT_INT;
            objNewDetail.m_dblIPWHOLESALEPRICE_INT = p_objCheckDetail.m_dblIPCALLPRICE_INT;
            objNewDetail.m_dblIPRETAILPRICE_INT = p_objCheckDetail.m_dblIPRETAILPRICE_INT;

            objNewDetail.m_strMEDICINEID_CHR = p_objCheckDetail.m_strMedicineCode;
            objNewDetail.m_strMEDICINENAME_VCHR = p_objCheckDetail.m_strMEDICINENAME_VCHR;
            objNewDetail.m_strMEDSPEC_VCHR = p_objCheckDetail.m_strMEDSPEC_VCHR;
            objNewDetail.m_strOPUNIT_CHR = p_objCheckDetail.m_strOPUNIT_CHR;
            objNewDetail.m_strLOTNO_VCHR = p_objCheckDetail.m_strLOTNO_VCHR;
            objNewDetail.m_strPRODUCTORID_CHR = p_objCheckDetail.m_strPRODUCTORID_CHR;
            objNewDetail.m_datVALIDPERIOD_DAT = p_objCheckDetail.m_dtmVALIDPERIOD_DAT;
            objNewDetail.m_strINSTOREID_VCHR = p_objCheckDetail.m_strINDRUGSTOREID_VCHR;
            
            objNewDetail.m_lngSERIESID_INT = p_objCheckDetail.m_lngSERIESID_INT;
            objNewDetail.m_lngSERIESID2_INT = p_objCheckDetail.m_lngSERIESID2_INT;
            objNewDetail.m_strIPUNIT_CHR = p_objCheckDetail.m_strIPUNIT_CHR;
           
            return objNewDetail;
        }

        /// <summary>
        /// 获取出库主记录
        /// </summary>
        /// <param name="p_objCheckDetail">盘亏明细</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strCreatorID">盘点人ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        private clsDS_OutStorage_VO m_objMainOutVO(clsDS_StorageCheckDetail_VO p_objCheckDetail, DateTime p_dtmCommitDate, string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID)
        {
            if (p_objCheckDetail == null)
            {
                return null;
            }
            clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
            clsDS_OutStorage_VO objOutMain = new clsDS_OutStorage_VO();
            objOutMain.m_datMAKEORDER_DAT = p_dtmCommitDate;
            objOutMain.m_intSTATUS = 1;
            objOutMain.m_intFORMTYPE_INT = 4;
            objOutMain.m_strEXAMID_CHR = p_strCreatorID;
            objOutMain.m_strCOMMENT_VCHR = p_objCheckDetail.m_strCHECKREASON_VCHR;
            objOutMain.m_strDRUGSTOREID_CHR = p_strStorageID;
            objOutMain.m_strINSTOREDEPT_CHR = p_strStorageID;
            objOutMain.m_datEXAM_DATE = p_dtmCheckDate;
            objOutMain.m_strOUTDRUGSTOREID_VCHR = p_strCheckID;
            int m_intTypeCode;
            objPublic.m_lngGetTypeCodeByName(null, 1, "盘亏出库", out m_intTypeCode);
            objOutMain.m_strTYPECODE_VCHR = m_intTypeCode.ToString();
            return objOutMain;
        }

        /// <summary>
        /// 获取出库明细记录
        /// </summary>
        /// <param name="p_objCheckDetail">盘亏明细</param>
        /// <returns></returns>
        [AutoComplete]
        private clsDS_Outstorage_Detail m_objDetailOutVO(clsDS_StorageCheckDetail_VO p_objCheckDetail,bool p_blnIsHospital)
        {
            if (p_objCheckDetail == null)
            {
                return null;
            }            
            clsDS_Outstorage_Detail objDetail = new clsDS_Outstorage_Detail();

            objDetail.m_dblOPAMOUNT_INT = Math.Abs(p_objCheckDetail.m_dblOPCHECKRESULT_INT) + Math.Round(Math.Abs(p_objCheckDetail.m_dblIPCHECKRESULT_INT) / p_objCheckDetail.m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
            objDetail.m_dblOPWHOLESALEPRICE_INT = p_objCheckDetail.m_dblOPCALLPRICE_INT;
            objDetail.m_dblOPRETAILPRICE_INT = p_objCheckDetail.m_dblOPRETAILPRICE_INT;
            objDetail.m_dblIPAMOUNT_INT = Math.Abs(p_objCheckDetail.m_dblOPCHECKRESULT_INT) * p_objCheckDetail.m_dblPACKQTY_DEC + Math.Abs(p_objCheckDetail.m_dblIPCHECKRESULT_INT);
            objDetail.m_dblIPWHOLESALEPRICE_INT = p_objCheckDetail.m_dblIPCALLPRICE_INT;
            objDetail.m_dblIPRETAILPRICE_INT = p_objCheckDetail.m_dblIPRETAILPRICE_INT;

            objDetail.m_strMEDICINEID_CHR = p_objCheckDetail.m_strMedicineCode;
            objDetail.m_strMEDICINENAME_VCHR = p_objCheckDetail.m_strMEDICINENAME_VCHR;
            objDetail.m_strMEDSPEC_VCHR = p_objCheckDetail.m_strMEDSPEC_VCHR;
            objDetail.m_strOPUNIT_CHR = p_objCheckDetail.m_strOPUNIT_CHR;            
            objDetail.m_strLOTNO_VCHR = p_objCheckDetail.m_strLOTNO_VCHR;
            objDetail.m_strPRODUCTORID_CHR = p_objCheckDetail.m_strPRODUCTORID_CHR;
            objDetail.m_strInStorageid = p_objCheckDetail.m_strINDRUGSTOREID_VCHR;
            objDetail.m_datVALIDPERIOD_DAT = p_objCheckDetail.m_dtmVALIDPERIOD_DAT;
            objDetail.m_intSTATUS = 1;
            objDetail.m_dblPACKQTY_DEC = p_objCheckDetail.m_dblPACKQTY_DEC;
            
            objDetail.m_strIPUNIT_CHR = p_objCheckDetail.m_strIPUNIT_CHR;

            return objDetail;
        }

        /// <summary>
        /// 获取帐本明细
        /// </summary>
        /// <param name="p_objCheckDetail"></param>
        /// <param name="p_strEmpID">入帐人ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_intType">出入类型 0入库 1出库</param>
        /// <param name="p_strCheckID">盘点单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmCheckDate">盘点时间</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <returns></returns>
        [AutoComplete]
        private clsDS_AccountDetail_VO[] m_objAccountDetail(clsDS_StorageCheckDetail_VO[] p_objCheckDetail, string p_strEmpID, DateTime p_dtmAccountDate, bool p_blnIsImmAccount, int p_intType, string p_strCheckID, string p_strStorageID, DateTime p_dtmCheckDate,bool p_blnIsHospital)
        {
            if (p_objCheckDetail == null || p_objCheckDetail.Length == 0)
            {
                return null;
            }

            clsDS_AccountDetail_VO[] objAcc = new clsDS_AccountDetail_VO[p_objCheckDetail.Length];
            int m_intTypeCode;
            clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
            if(p_intType == 0)//入库
                objPublic.m_lngGetTypeCodeByName(null, 0, "盘盈入库", out m_intTypeCode);
            else
                objPublic.m_lngGetTypeCodeByName(null, 1, "盘亏出库", out m_intTypeCode);
            int intState = p_blnIsImmAccount ? 1 : 2;
            string strEmpID = p_blnIsImmAccount ? p_strEmpID : string.Empty;
            DateTime dtmAccount = p_blnIsImmAccount ? p_dtmAccountDate : DateTime.MinValue;
            for (int i1 = 0; i1 < p_objCheckDetail.Length; i1++)
            {
                objAcc[i1] = new clsDS_AccountDetail_VO();

                objAcc[i1].m_lngSERIESID_INT = p_objCheckDetail[i1].m_lngSERIESID_INT;
                objAcc[i1].m_strMEDICINEID_CHR = p_objCheckDetail[i1].m_strMedicineCode;
                objAcc[i1].m_strMEDICINENAME_VCH = p_objCheckDetail[i1].m_strMEDICINENAME_VCHR;
                objAcc[i1].m_strMEDICINETYPEID_CHR = p_objCheckDetail[i1].m_strMedicineTypeID;
                objAcc[i1].m_strMEDSPEC_VCHR = p_objCheckDetail[i1].m_strMEDSPEC_VCHR;
                objAcc[i1].m_strDrugStoreID_CHR = p_strStorageID;
                objAcc[i1].m_strLOTNO_VCHR = p_objCheckDetail[i1].m_strLOTNO_VCHR;
                objAcc[i1].m_dtmValidDate = p_objCheckDetail[i1].m_dtmVALIDPERIOD_DAT;
                objAcc[i1].m_strINSTORAGEID_VCHR = p_objCheckDetail[i1].m_strINDRUGSTOREID_VCHR;

                objAcc[i1].m_dblIPOLDGROSS_INT = p_objCheckDetail[i1].m_dblOPREALGROSS_INT * p_objCheckDetail[i1].m_dblPACKQTY_DEC + p_objCheckDetail[i1].m_dblIPREALGROSS_INT;
                objAcc[i1].m_dblOPOLDGROSS_INT = p_objCheckDetail[i1].m_dblOPREALGROSS_INT + Math.Round(p_objCheckDetail[i1].m_dblIPREALGROSS_INT / p_objCheckDetail[i1].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
                objAcc[i1].m_dblIPCALLPRICE_INT = p_objCheckDetail[i1].m_dblIPCALLPRICE_INT;
                objAcc[i1].m_dblOPCALLPRICE_INT = p_objCheckDetail[i1].m_dblOPCALLPRICE_INT;
                objAcc[i1].m_dblIPRETAILPRICE_INT = p_objCheckDetail[i1].m_dblIPRETAILPRICE_INT;
                objAcc[i1].m_dblOPRETAILPRICE_INT = p_objCheckDetail[i1].m_dblOPRETAILPRICE_INT;
                objAcc[i1].m_dblIPAMOUNT_INT = p_objCheckDetail[i1].m_dblOPCHECKRESULT_INT * p_objCheckDetail[i1].m_dblPACKQTY_DEC + p_objCheckDetail[i1].m_dblIPREALGROSS_INT;
                objAcc[i1].m_dblOPAMOUNT_INT = p_objCheckDetail[i1].m_dblOPCHECKRESULT_INT + Math.Round(p_objCheckDetail[i1].m_dblIPCHECKRESULT_INT / p_objCheckDetail[i1].m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);

                //入库时间，（审核时间）
                objAcc[i1].m_dtmOperateDate = p_dtmCheckDate;
                objAcc[i1].m_strIPUNIT_CHR = p_objCheckDetail[i1].m_strIPUNIT_CHR;                
                objAcc[i1].m_strOPUNIT_CHR = p_objCheckDetail[i1].m_strOPUNIT_CHR;
                objAcc[i1].m_intTYPE_INT = p_intType;//入库0，出库1
                objAcc[i1].m_strDeptid_chr = p_strStorageID;
                objAcc[i1].m_strCHITTYID_VCHR = p_strCheckID;
                if (p_intType == 0)//单据类型，1、请领入库 2、药房自身入库(来源部门是本药房)  3、药房借调（来源部门是其它药房） 4、科室借调（来源部门除了药房以外的部门） 5、盘盈
                {
                    objAcc[i1].m_intFORMTYPE_INT = 5;//入库0
                }
                else if(p_intType==1)//单据类型，1、药房自身出库（出库部门是本药房），2、药房借调（出库部门是其它药房），3、科室出库（出库部门除药房外的其它部门），4、盘亏
                {
                    objAcc[i1].m_intFORMTYPE_INT = 4;//出库1
                }
                objAcc[i1].m_intSTATE_INT = intState;
                objAcc[i1].m_intISEND_INT = 0;
                objAcc[i1].m_dblENDOPAMOUNT_INT = 0;
                objAcc[i1].m_dblENDIPAMOUNT_INT = 0;
                objAcc[i1].m_dblENDOPWHOLESALEPRICE_INT = 0;
                objAcc[i1].m_dblENDIPWHOLESALEPRICE_INT = 0;
                objAcc[i1].m_dblENDOPRETAILPRICE_INT = 0;
                objAcc[i1].m_dblENDIPRETAILPRICE_INT = 0;
                objAcc[i1].m_strINACCOUNTID_CHR = string.Empty;
                objAcc[i1].m_dtmINACCOUNTDATE_DAT = DateTime.MinValue;
                objAcc[i1].m_strACCOUNTID_CHR = string.Empty;
                objAcc[i1].m_strPRODUCTORID_CHR = p_objCheckDetail[i1].m_strPRODUCTORID_CHR;
                objAcc[i1].m_strTYPECODE_CHR = m_intTypeCode.ToString();
                objAcc[i1].m_dblPACKQTY_DEC = p_objCheckDetail[i1].m_dblPACKQTY_DEC;
            }
            return objAcc;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strCheckID">盘点单据号</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">盘点日期</param>
        /// <param name="p_strStorage">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInAccount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, string p_strCheckID, string p_strEmpID, DateTime p_dtmAccountDate, string p_strStorage)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate, p_lngMainSEQ);
                if (lngRes > 0)
                {
                    //如果无盈亏记录，则在帐本明细表中不会存在相应的帐本明细
                    long lngAcc = m_lngRatifyAccountDetail(p_objPrincipal, p_strCheckID, p_strStorage, p_strEmpID, p_dtmAccountDate);
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

        #region 确认入帐
        /// <summary>
        /// 确认入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRatifyAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strChittyID, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = ?
 where t.chittyid_vchr = ?
   and t.drugstoreid_int = ?
   and t.state_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmAccountDate;
                objDPArr[2].Value = p_strChittyID;
                objDPArr[3].Value = p_strStorageID;

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
        #endregion

        #region 保存盘点
        /// <summary>
        /// 保存盘点
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表记录</param>
        /// <param name="p_objModifyDetaiArr">修改过的盘点记录</param>
        /// <param name="p_objNewDetailArr">新增的盘点记录</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsAddNew">是否新增</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strCommit">审核流程</param>
        /// <param name="p_lngNewSubSEQArr">新增盘点记录明细序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_Check_VO p_objMain, clsDS_StorageCheckDetail_VO[] p_objModifyDetaiArr, clsDS_StorageCheckDetail_VO[] p_objNewDetailArr,
             string p_strEmpID, string p_strStorageID, bool p_blnIsAddNew,bool p_blnIsHospital,string p_strCommit,out long[] p_lngNewSubSEQArr)
        {
            p_lngNewSubSEQArr = null;

            long lngRes = 0;
            try
            {
                //保存主表
                if (p_blnIsAddNew)
                {
                    lngRes = m_lngAddNewStorageCheckMain(p_objPrincipal, ref p_objMain);
                }
                else
                {
                    lngRes = m_lngMofifyStorageCheck(p_objPrincipal, p_objMain);
                }

                if (lngRes <= 0)
                {
                    if(lngRes == -99)
                    {
                        ContextUtil.SetAbort();
                        return -99;
                    }
                    else
                    {
                        return -1;
                    }
                }


                //保存修改记录
                //if (p_objModifyDetaiArr != null && p_objModifyDetaiArr.Length > 0)
                //{
                //    lngRes = m_lngModifyStorageCheckDetail(p_objPrincipal, p_objModifyDetaiArr);
                //    if (lngRes <= 0)
                //    {
                //        throw new Exception("修改盘点明细表出错");
                //    }
                //}                

                //全部是新增记录
                if (p_objNewDetailArr != null && p_objNewDetailArr.Length > 0)
                {
                    for (int iNew = 0; iNew < p_objNewDetailArr.Length; iNew++)
                    {
                        p_objNewDetailArr[iNew].m_lngSERIESID2_INT = p_objMain.m_lngSERIESID_INT;
                    }

                    lngRes = m_lngAddNewStorageCheckDetail(p_objPrincipal, p_objNewDetailArr, out p_lngNewSubSEQArr);
                    if (lngRes <= 0)
                    {
                        throw new Exception("保存盘点表明细出错");
                    }
                }

                //保存即审核时保存盘盈盘亏记录
                if (p_objMain.m_intSTATUS_INT == 2)
                {
                    List<clsDS_StorageDetail_VO> lstStDetail = new List<clsDS_StorageDetail_VO>();//库存盈亏数量
                    List<clsDS_StorageCheckDetail_VO> lstDef = new List<clsDS_StorageCheckDetail_VO>();//盘亏
                    List<clsDS_StorageCheckDetail_VO> lstSuf = new List<clsDS_StorageCheckDetail_VO>();//盘盈
                                       
                    if (p_objNewDetailArr != null)
                    {
                        for (int i1 = 0; i1 < p_objNewDetailArr.Length; i1++)
                        {
                            //盘亏
                            if (p_objNewDetailArr[i1].m_dblIPCHECKRESULT_INT < 0 || p_objNewDetailArr[i1].m_dblOPCHECKRESULT_INT < 0)
                            {
                                lstDef.Add(p_objNewDetailArr[i1]);
                                lstStDetail.Add(m_mthConvertToStorageDetail(p_blnIsHospital, p_objMain.m_strDRUGSTOREID_CHR, p_objNewDetailArr[i1]));
                            }
                            else if (p_objNewDetailArr[i1].m_dblIPCHECKRESULT_INT > 0 || p_objNewDetailArr[i1].m_dblOPCHECKRESULT_INT > 0)
                            {
                                lstSuf.Add(p_objNewDetailArr[i1]);
                                lstStDetail.Add(m_mthConvertToStorageDetail(p_blnIsHospital, p_objMain.m_strDRUGSTOREID_CHR, p_objNewDetailArr[i1]));
                            }
                            //盘盈
                            if (p_objNewDetailArr[i1].m_dblIPCHECKRESULT_INT < 0 || p_objNewDetailArr[i1].m_dblOPCHECKRESULT_INT < 0)
                            {
                                lstDef.Add(p_objNewDetailArr[i1]);
                                lstStDetail.Add(m_mthConvertToStorageDetail(p_blnIsHospital, p_objMain.m_strDRUGSTOREID_CHR, p_objNewDetailArr[i1]));
                            }
                            else if (p_objNewDetailArr[i1].m_dblIPCHECKRESULT_INT > 0 || p_objNewDetailArr[i1].m_dblOPCHECKRESULT_INT > 0)
                            {
                                lstSuf.Add(p_objNewDetailArr[i1]);
                                lstStDetail.Add(m_mthConvertToStorageDetail(p_blnIsHospital, p_objMain.m_strDRUGSTOREID_CHR, p_objNewDetailArr[i1]));
                            }
                        }
                    }

                    if (lstDef.Count > 0 || lstSuf.Count > 0)
                    {
                        Hashtable hstMedicine = new Hashtable();
                        List<string> lstMedicineID = new List<string>();
                        if (lstStDetail.Count > 0)
                        {
                            for (int i2 = 0; i2 < lstStDetail.Count; i2++)
                            {
                                if (!hstMedicine.Contains(lstStDetail[i2].m_strMEDICINEID_CHR))
                                {
                                    hstMedicine.Add(lstStDetail[i2].m_strMEDICINEID_CHR, lstStDetail[i2].m_strMEDICINENAME_VCHR);
                                    lstMedicineID.Add(lstStDetail[i2].m_strMEDICINEID_CHR);
                                }
                            }
                        }


                        lngRes = m_lngCommitStorageCheck(p_objPrincipal, p_objMain.m_lngSERIESID_INT, lstDef.ToArray(), lstSuf.ToArray(), lstStDetail.ToArray(),
                            lstMedicineID.ToArray(), p_objMain.m_strEXAMERID_CHR, p_objMain.m_dtmEXAMDATE_DAT, p_objMain.m_strCHECKID_CHR, p_objMain.m_strEXAMERID_CHR,
                            p_objMain.m_dtmEXAMDATE_DAT, p_objMain.m_strDRUGSTOREID_CHR, false,p_strCommit, p_blnIsHospital);
                        if (lngRes <= 0)
                        {
                            throw new Exception("保存盘盈盘亏记录出错");
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
        /// 库存盈亏
        /// </summary>
        ///<param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="objSCD">盘点明细</param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO m_mthConvertToStorageDetail(bool p_blnIsHospital,string p_strDrugStoreID,clsDS_StorageCheckDetail_VO objSCD)
        {
            clsDS_StorageDetail_VO objSD = new clsDS_StorageDetail_VO();
            objSD.m_strMEDICINEID_CHR = objSCD.m_strMedicineCode;
            objSD.m_dblPACKQTY_DEC = objSCD.m_dblPACKQTY_DEC;
            objSD.m_strDRUGSTOREID_CHR = p_strDrugStoreID;
            objSD.m_strLOTNO_VCHR = objSCD.m_strLOTNO_VCHR;
            objSD.m_dblIPREALGROSS_INT = objSCD.m_dblOPCHECKRESULT_INT*objSCD.m_dblPACKQTY_DEC+objSCD.m_dblOPCHECKRESULT_INT;
            objSD.m_dblIPAVAILABLEGROSS_NUM = objSCD.m_dblOPCHECKRESULT_INT + Math.Round(objSCD.m_dblIPCHECKRESULT_INT / objSCD.m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
            return objSD;
        }
        #endregion

        #region 删除指定药品
        /// <summary>
        /// 删除指定药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicneSt">药品库存信息</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_lngSubSEQ">盘点明细序列</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorageCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] p_objMedicneSt, string p_strCheckID, long p_lngSubSEQ, bool p_blnIsCommit)
        {
            if (p_objMedicneSt == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                lngRes = m_lngDeleteStorageCheckDetail(p_objPrincipal, p_lngSubSEQ);
                if (lngRes <= 0)
                {
                    return -1;
                }

                if (p_blnIsCommit && p_objMedicneSt.Length > 0)
                {
                    for (int i1 = 0; i1 < p_objMedicneSt.Length; i1++)
                    {
                        if (p_objMedicneSt[i1].m_dblOPREALGROSS_INT < 0)//盘亏
                        {
                            lngRes = m_lngDeleteOutStorage(p_objPrincipal, p_strCheckID, p_objMedicneSt[i1].m_strMEDICINEID_CHR, p_objMedicneSt[i1].m_strLOTNO_VCHR, p_objMedicneSt[i1].m_strINSTOREID_VCHR, p_objMedicneSt[i1].m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt[i1].m_dblOPWHOLESALEPRICE_INT));

                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                        else if (p_objMedicneSt[i1].m_dblOPREALGROSS_INT > 0)//盘盈
                        {
                            lngRes = m_lngDeleteInStorage(p_objPrincipal, p_strCheckID, p_objMedicneSt[i1].m_strMEDICINEID_CHR, p_objMedicneSt[i1].m_strLOTNO_VCHR, p_objMedicneSt[i1].m_strINSTOREID_VCHR, p_objMedicneSt[i1].m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt[i1].m_dblOPWHOLESALEPRICE_INT));
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }

                        p_objMedicneSt[i1].m_dblOPAVAILABLEGROSS_NUM = 0 - p_objMedicneSt[i1].m_dblOPAVAILABLEGROSS_NUM;
                        p_objMedicneSt[i1].m_dblOPREALGROSS_INT = 0 - p_objMedicneSt[i1].m_dblOPREALGROSS_INT;
                        //clsDS_StorageDetail_VO[] objSTArr = new clsDS_StorageDetail_VO[] { p_objMedicneSt };                        
                    }

                    lngRes = m_lngAddStorageDetailGross(p_objPrincipal, p_objMedicneSt);//还原库存明细数量
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    string[] strMedID = new string[] { p_objMedicneSt[0].m_strMEDICINEID_CHR };
                    lngRes = m_lngUpdateStorageGross(p_objPrincipal, strMedID, p_objMedicneSt[0].m_strDRUGSTOREID_CHR);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }

                    m_lngSetAccountDetailInvalid(p_objPrincipal, p_strCheckID, p_objMedicneSt[0].m_strDRUGSTOREID_CHR,p_objMedicneSt[0].m_strMEDICINEID_CHR);//, p_objMedicneSt.m_strMEDICINEID_CHR, p_objMedicneSt.m_strLOTNO_VCHR, p_objMedicneSt.m_strINDRUGSTOREID_VCHR, p_objMedicneSt.m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt.m_dcmCALLPRICE_INT));
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

        #region 设置帐本明细为无效

        /// <summary>
        /// 设置帐本明细为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, string p_strChittyID, string p_strStorageID,string p_strMedicineID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?
   and t.drugstoreid_int = ?
and t.medicineid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strChittyID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;

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
        #endregion

        #region 审核盘亏记录
        /// <summary>
        /// 审核盘亏记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow">是否保存即审核</param>
        /// <param name="p_strExamerID">设置审核者名字</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOutstorageInfo(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_OutStorage_VO m_objMainVo, ref clsDS_Outstorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID, out string p_strMedicineName)
        {
            p_strMedicineName = string.Empty;
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL =
             @"insert into t_ds_outstorage
            (seriesid_int,  outdrugstoreid_vchr,formtype_int,
             status_int, drugstoreid_chr, instoredept_chr,
             makeorder_dat, examdate_dat,inaccount_dat, 
             comment_vchr, makerid_chr, examid_chr,
             inaccounterid_chr,patientid_chr,typecode_vchr
            )
            values (?, ?, ?, ?,?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                string m_strTempId = string.Empty;
                string m_strMedStoreShortCode = string.Empty;
                string m_strParaValue = string.Empty;
                objPubSvc.m_lngGetSysParaByID(p_objPrincipal, "8007", out m_strParaValue);
                objPubSvc.m_lngGetMedStoreShortCodeByDeptid(p_objPrincipal, m_objMainVo.m_strDRUGSTOREID_CHR, out m_strMedStoreShortCode);
                objPubSvc.m_lngGetSequence(p_objPrincipal, "SEQ_DS_OUTSTORAGE", out m_objMainVo.m_lngSERIESID_INT);
                objPubSvc.m_lngGetNewIdByName(p_objPrincipal, "t_ds_outstorage", "outdrugstoreid_vchr", m_strMedStoreShortCode, m_objMainVo.m_datMAKEORDER_DAT, ref m_strTempId);
                m_objMainVo.m_strOUTDRUGSTOREID_VCHR = m_strMedStoreShortCode + m_objMainVo.m_datMAKEORDER_DAT.ToString("yyMMdd") + m_strParaValue.Split(';')[1] + m_strTempId;
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(15, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_lngSERIESID_INT;
                objDataParm[1].Value = m_objMainVo.m_strOUTDRUGSTOREID_VCHR;
                objDataParm[2].Value = m_objMainVo.m_intFORMTYPE_INT;
                objDataParm[3].Value = m_objMainVo.m_intSTATUS;

                objDataParm[4].Value = m_objMainVo.m_strDRUGSTOREID_CHR;
                objDataParm[5].Value = m_objMainVo.m_strINSTOREDEPT_CHR;
                objDataParm[6].Value = m_objMainVo.m_datMAKEORDER_DAT; ;
                objDataParm[7].Value = m_objMainVo.m_datEXAM_DATE;

                objDataParm[8].Value = m_objMainVo.m_datINACCOUNT_DAT;
                objDataParm[9].Value = m_objMainVo.m_strCOMMENT_VCHR;
                objDataParm[10].Value = m_objMainVo.m_strMAKERID_CHR;
                objDataParm[11].Value = m_objMainVo.m_strEXAMID_CHR;

                objDataParm[12].Value = m_objMainVo.m_strINACCOUNTERID_CHR;
                objDataParm[13].Value = m_objMainVo.m_strPatientid;
                objDataParm[14].Value = m_objMainVo.m_strTYPECODE_VCHR;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (m_objDetailArr == null || m_objDetailArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    //return -1;
                    throw new Exception("出库明细不能为空");
                }

                strSQL = @"insert into t_ds_outstorage_detail
            (seriesid_int, seriesid2_int, medicineid_chr, medicinename_vchr,
             medspec_vchr, opamount_int, opunit_chr, ipamount_int,
             ipunit_chr, packqty_dec, opwholesaleprice_int,
             ipwholesaleprice_int, opretailprice_int, ipretailprice_int,
             lotno_vchr, validperiod_dat, status,rejectreason,storageseriesid_chr,productorid_chr
            )
     values (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,?,?,?
            )";
                long[] lngSEQArr = null;
                clsDS_UpdateStorageBySeriesID_VO[] objUpdateArr = null;
                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_OUTSTORAGE_DETAIL", m_objDetailArr.Length, out lngSEQArr);
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, 
                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
                    DbType.String, DbType.Double, DbType.Double, 
                    DbType.Double, DbType.Double, DbType.Double, 
                    DbType.String,DbType.DateTime, DbType.Int16,
                    DbType.String,DbType.String,DbType.String};
                object[][] objValues = new object[20][];
                int intItemCount = m_objDetailArr.Length;
                objUpdateArr = new clsDS_UpdateStorageBySeriesID_VO[intItemCount];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                for (int iRow = 0; iRow < m_objDetailArr.Length; iRow++)
                {
                    objUpdateArr[iRow] = new clsDS_UpdateStorageBySeriesID_VO();
                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    objValues[0][iRow] = m_objDetailArr[iRow].m_lngSERIESID_INT;
                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                    objValues[1][iRow] = m_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = m_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = m_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[6][iRow] = m_objDetailArr[iRow].m_strOPUNIT_CHR;
                    objValues[7][iRow] = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[8][iRow] = m_objDetailArr[iRow].m_strIPUNIT_CHR;
                    objValues[9][iRow] = m_objDetailArr[iRow].m_dblPACKQTY_DEC;
                    objValues[10][iRow] = m_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT;
                    objValues[11][iRow] = m_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT;
                    objValues[12][iRow] = m_objDetailArr[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[13][iRow] = m_objDetailArr[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[14][iRow] = m_objDetailArr[iRow].m_strLOTNO_VCHR;
                    objValues[15][iRow] = m_objDetailArr[iRow].m_datVALIDPERIOD_DAT;
                    objValues[16][iRow] = m_objDetailArr[iRow].m_intSTATUS;
                    objValues[17][iRow] = m_objDetailArr[iRow].m_strRejectReason;
                    objValues[18][iRow] = m_objDetailArr[iRow].m_intSTORAGESERIESID_CHR;
                    objValues[19][iRow] = m_objDetailArr[iRow].m_strPRODUCTORID_CHR;

                    objUpdateArr[iRow].m_dblOPAvalid = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
                    objUpdateArr[iRow].m_dblIPAvalid = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
                    objUpdateArr[iRow].m_intSeriesID = Convert.ToInt64(m_objDetailArr[iRow].m_intSTORAGESERIESID_CHR);
                    objUpdateArr[iRow].m_strMEDICINENAME_VCHR = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                //更新可用库存 
                clsOutstorage_SVC clsOutSvc = new clsOutstorage_SVC();
                lngRes = clsOutSvc.m_lngUpdateStorageAvalid(p_objPrincipal, objUpdateArr, out p_strMedicineName);
                if (lngRes <= 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception(p_strMedicineName + "可用库存不足，请修改");
                }

                //保存即审核
                if (p_intCommitFolow == 1 && m_objDetailArr.Length > 0)
                {
                    clsDS_UpdateStorageBySeriesID_VO[] objStorageDetailArr = new clsDS_UpdateStorageBySeriesID_VO[m_objDetailArr.Length];
                    for (int i1 = 0; i1 < m_objDetailArr.Length; i1++)
                    {
                        objStorageDetailArr[i1] = new clsDS_UpdateStorageBySeriesID_VO();
                        objStorageDetailArr[i1].m_strMedicineCode = m_objDetailArr[i1].m_strMEDICINEID_CHR;
                        objStorageDetailArr[i1].m_strMEDICINENAME_VCHR = m_objDetailArr[i1].m_strMEDICINENAME_VCHR;
                        objStorageDetailArr[i1].m_strMEDSPEC_VCHR = m_objDetailArr[i1].m_strMEDSPEC_VCHR;
                        objStorageDetailArr[i1].m_strLOTNO_VCHR = m_objDetailArr[i1].m_strLOTNO_VCHR;
                        objStorageDetailArr[i1].m_strOPUNIT_CHR = m_objDetailArr[i1].m_strOPUNIT_CHR;
                        objStorageDetailArr[i1].m_dblOPReal = m_objDetailArr[i1].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i1].m_dblOPAvalid = m_objDetailArr[i1].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i1].m_dblOPRETAILPRICE_INT = m_objDetailArr[i1].m_dblOPRETAILPRICE_INT;
                        objStorageDetailArr[i1].m_dblOPWHOLESALEPRICE_INT = m_objDetailArr[i1].m_dblOPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i1].m_strIPUNIT_CHR = m_objDetailArr[i1].m_strIPUNIT_CHR;
                        objStorageDetailArr[i1].m_dblIPReal = m_objDetailArr[i1].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i1].m_dblIPAvalid = m_objDetailArr[i1].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i1].m_dblIPRETAILPRICE_INT = m_objDetailArr[i1].m_dblIPRETAILPRICE_INT;
                        objStorageDetailArr[i1].m_dblIPWHOLESALEPRICE_INT = m_objDetailArr[i1].m_dblIPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i1].m_dblPACKQTY_DEC = m_objDetailArr[i1].m_dblPACKQTY_DEC;
                        objStorageDetailArr[i1].m_dtmVALIDPERIOD_DAT = m_objDetailArr[i1].m_datVALIDPERIOD_DAT;
                        objStorageDetailArr[i1].m_strINSTOREID_VCHR = m_objDetailArr[i1].m_strDSInStorageid;//这里取药房入库单的单号
                        objStorageDetailArr[i1].m_strDrugID = m_objMainVo.m_strDRUGSTOREID_CHR;
                        objStorageDetailArr[i1].m_strDSINSTOREID_VCHR = m_objMainVo.m_strOUTDRUGSTOREID_VCHR;//这里当作chittyid_vchr
                        objStorageDetailArr[i1].m_intType = Convert.ToInt16(m_objMainVo.m_intFORMTYPE_INT);
                        objStorageDetailArr[i1].m_strPRODUCTORID_CHR = m_objDetailArr[i1].m_strPRODUCTORID_CHR;
                        objStorageDetailArr[i1].m_intSeriesID = Convert.ToInt64(m_objDetailArr[i1].m_intSTORAGESERIESID_CHR);
                        objStorageDetailArr[i1].m_strMEDICINETYPEID_CHR = m_objDetailArr[i1].m_strMedicineTypeid;
                        objStorageDetailArr[i1].m_lngRELATEDSERIESID_INT = m_objDetailArr[i1].m_lngSERIESID_INT;
                    }
                    string strInfo = string.Empty;
                    lngRes = clsOutSvc.m_lngSubtractStorage(p_objPrincipal, objStorageDetailArr, 2, out strInfo);
                    if (lngRes < 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception(strInfo);
                    }
                    else
                    {
                        lngRes = clsOutSvc.m_lngOutstorageExam(p_strExamerID, m_objMainVo.m_lngSERIESID_INT);
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception("设置审核者出错");
                        }
                        lngRes = clsOutSvc.m_lngAddNewAccountDetail(p_objPrincipal, objStorageDetailArr);
                    }

                    objHRPServ.Dispose();
                    objHRPServ = null;
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

        #region 盘盈操作
        /// <summary>
        /// 盘盈操作
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow">是否审核，0否，1 是</param>
        /// <param name="p_strExamerID">审核者</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewInstorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL =
             @"insert into t_ds_instorage
            (seriesid_int, indrugstoreid_vchr, askid_vchr, outstorageid_vchr,
             formtype_int, status, drugstoreid_chr, borrowdept_chr,
             makeorder_dat, storageexam_date, drugstoreexam_date,
             inaccount_dat, comment_vchr, makerid_chr, storageexamid_chr,
             drugstoreexamid_chr, inaccounterid_chr,typecode_vchr
            )
            values (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?,?
            )";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                string m_strTempId = string.Empty;
                string m_strMedStoreShortCode = string.Empty;
                string m_strParaValue = string.Empty;
                objPubSvc.m_lngGetSysParaByID(p_objPrincipal, "8007", out m_strParaValue);
                objPubSvc.m_lngGetMedStoreShortCodeByDeptid(p_objPrincipal, m_objMainVo.m_strDRUGSTOREID_INT, out m_strMedStoreShortCode);
                objPubSvc.m_lngGetSequence(p_objPrincipal, "SEQ_DS_INSTORAGE", out m_objMainVo.m_lngSERIESID_INT);
                objPubSvc.m_lngGetNewIdByName(p_objPrincipal, "t_ds_instorage", "indrugstoreid_vchr", m_strMedStoreShortCode, m_objMainVo.m_datMAKEORDER_DAT, ref m_strTempId);
                m_objMainVo.m_strINDRUGSTOREID_VCHR = m_strMedStoreShortCode + m_objMainVo.m_datMAKEORDER_DAT.ToString("yyMMdd") + m_strParaValue.Split(';')[0] + m_strTempId;
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(18, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_lngSERIESID_INT;
                objDataParm[1].Value = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                objDataParm[2].Value = m_objMainVo.m_strASKID_VCHR;
                objDataParm[3].Value = m_objMainVo.m_strOUTSTORAGEID_VCHR;

                objDataParm[4].Value = m_objMainVo.m_intFORMTYPE_INT;
                objDataParm[5].Value = m_objMainVo.m_intSTATUS;
                objDataParm[6].Value = m_objMainVo.m_strDRUGSTOREID_INT; ;
                objDataParm[7].Value = m_objMainVo.m_strBORROWDEPT_CHR;

                objDataParm[8].Value = m_objMainVo.m_datMAKEORDER_DAT;
                objDataParm[9].Value = m_objMainVo.m_datSTORAGEEXAM_DATE;
                objDataParm[10].Value = m_objMainVo.m_datDRUGSTOREEXAM_DATE;

                objDataParm[11].Value = m_objMainVo.m_datINACCOUNT_DAT;
                objDataParm[12].Value = m_objMainVo.m_strCOMMENT_VCHR;
                objDataParm[13].Value = m_objMainVo.m_strMAKERID_CHR;
                objDataParm[14].Value = m_objMainVo.m_strSTORAGEEXAMID_CHR;

                objDataParm[15].Value = m_objMainVo.m_strDRUGSTOREEXAMID_CHR;
                objDataParm[16].Value = m_objMainVo.m_strINACCOUNTERID_CHR;
                objDataParm[17].Value = m_objMainVo.m_strTYPECODE_VCHR;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (m_objDetailArr == null || m_objDetailArr.Length == 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    return -1;
                }

                strSQL = @"insert into t_ds_instorage_detail
            (seriesid_int, seriesid2_int, medicineid_chr, medicinename_vchr,
             medspec_vchr, opamount_int, opunit_chr, ipamount_int,
             ipunit_chr, packqty_dec, opwholesaleprice_int,
             ipwholesaleprice_int, opretailprice_int, ipretailprice_int,
             lotno_vchr, validperiod_dat, status,instoreid_vchr,instoragedate_dat,productorid_chr
            )
     values (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,?,?,?
            )";
                long[] lngSEQArr = null;
                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", m_objDetailArr.Length, out lngSEQArr);
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, 
                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
                    DbType.String, DbType.Double, DbType.Double, 
                    DbType.Double, DbType.Double, DbType.Double, 
                    DbType.String,DbType.DateTime, DbType.Int16,DbType.String,DbType.DateTime,DbType.String};
                object[][] objValues = new object[20][];
                int intItemCount = m_objDetailArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                for (int iRow = 0; iRow < m_objDetailArr.Length; iRow++)
                {
                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    objValues[0][iRow] = m_objDetailArr[iRow].m_lngSERIESID_INT;
                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                    objValues[1][iRow] = m_objDetailArr[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = m_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = m_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[6][iRow] = m_objDetailArr[iRow].m_strOPUNIT_CHR;
                    objValues[7][iRow] = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[8][iRow] = m_objDetailArr[iRow].m_strIPUNIT_CHR;
                    objValues[9][iRow] = m_objDetailArr[iRow].m_dblPACKQTY_DEC;
                    objValues[10][iRow] = m_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT;
                    objValues[11][iRow] = m_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT;
                    objValues[12][iRow] = m_objDetailArr[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[13][iRow] = m_objDetailArr[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[14][iRow] = m_objDetailArr[iRow].m_strLOTNO_VCHR;
                    objValues[15][iRow] = m_objDetailArr[iRow].m_datVALIDPERIOD_DAT;
                    objValues[16][iRow] = m_objDetailArr[iRow].m_intSTATUS;
                    objValues[17][iRow] = m_objDetailArr[iRow].m_strINSTOREID_VCHR;
                    objValues[18][iRow] = m_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT;
                    objValues[19][iRow] = m_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                //保存即审核
                if (p_intCommitFolow == 1 && m_objDetailArr.Length > 0)
                {
                    clsDS_StorageDetail_VO[] objStorageDetailArr = new clsDS_StorageDetail_VO[m_objDetailArr.Length];
                    bool m_blnCheckEnough = false;
                    double m_dblStoregeAmount = 0d;
                    double m_dblStorageIPAmount = 0d;
                    DateTime dtmNow;
                    clsDS_Public_Supported_SVC objService = new clsDS_Public_Supported_SVC();
                    objService.m_lngGetSystemDateTime(out dtmNow);
                    //保存库存明细表
                    for (int i2 = 0; i2 < m_objDetailArr.Length; i2++)
                    {
                        objStorageDetailArr[i2] = new clsDS_StorageDetail_VO();
                        objStorageDetailArr[i2].m_strMEDICINEID_CHR = m_objDetailArr[i2].m_strMEDICINEID_CHR;
                        objStorageDetailArr[i2].m_strMEDICINENAME_VCHR = m_objDetailArr[i2].m_strMEDICINENAME_VCHR;
                        objStorageDetailArr[i2].m_strMEDSPEC_VCHR = m_objDetailArr[i2].m_strMEDSPEC_VCHR;
                        objStorageDetailArr[i2].m_strLOTNO_VCHR = m_objDetailArr[i2].m_strLOTNO_VCHR;
                        objStorageDetailArr[i2].m_dblOPREALGROSS_INT = m_objDetailArr[i2].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblOPAVAILABLEGROSS_NUM = m_objDetailArr[i2].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblOPRETAILPRICE_INT = m_objDetailArr[i2].m_dblOPRETAILPRICE_INT;
                        objStorageDetailArr[i2].m_dblOPWHOLESALEPRICE_INT = m_objDetailArr[i2].m_dblOPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i2].m_dblIPREALGROSS_INT = m_objDetailArr[i2].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblIPAVAILABLEGROSS_NUM = m_objDetailArr[i2].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblIPRETAILPRICE_INT = m_objDetailArr[i2].m_dblIPRETAILPRICE_INT;
                        objStorageDetailArr[i2].m_dblIPWHOLESALEPRICE_INT = m_objDetailArr[i2].m_dblIPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i2].m_dblPACKQTY_DEC = m_objDetailArr[i2].m_dblPACKQTY_DEC;
                        objStorageDetailArr[i2].m_strOPUNIT_CHR = m_objDetailArr[i2].m_strOPUNIT_CHR;
                        objStorageDetailArr[i2].m_strIPUNIT_CHR = m_objDetailArr[i2].m_strIPUNIT_CHR;
                        objStorageDetailArr[i2].m_dtmVALIDPERIOD_DAT = m_objDetailArr[i2].m_datVALIDPERIOD_DAT;
                        objStorageDetailArr[i2].m_strINSTOREID_VCHR = m_objDetailArr[i2].m_strINSTOREID_VCHR;
                        objStorageDetailArr[i2].m_dtmINSTORAGEDATE_DAT = m_objDetailArr[i2].m_dtmINSTORAGEDATE_DAT;
                        objStorageDetailArr[i2].STATUS = 1;
                        objStorageDetailArr[i2].m_intType = (byte)m_objMainVo.m_intFORMTYPE_INT;
                        objStorageDetailArr[i2].m_strDRUGSTOREID_CHR = m_objMainVo.m_strDRUGSTOREID_INT;
                        objStorageDetailArr[i2].m_strDSINSTOREID_VCHR = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                        objStorageDetailArr[i2].m_dtmDSINSTORAGEDATE_DAT = dtmNow;
                        objStorageDetailArr[i2].m_strPRODUCTORID_CHR = m_objDetailArr[i2].m_strPRODUCTORID_CHR;
                        objStorageDetailArr[i2].m_strMEDICINETYPEID_CHR = m_objDetailArr[i2].m_strMedicineTypeid;
                        objStorageDetailArr[i2].m_lngRELATEDSERIESID_INT = Convert.ToInt64(m_objDetailArr[i2].m_strStorageSeriesID);
                        //20080617 负数不再检查库存是否足以冲减，允许库存为负数
                        //if(m_objDetailArr[i2].m_dblIPAMOUNT_INT < 0)
                        //{
                        //    m_dblStoregeAmount = m_objDetailArr[i2].m_dblOPAMOUNT_INT;
                        //    m_dblStorageIPAmount = m_objDetailArr[i2].m_dblIPAMOUNT_INT;
                        //    m_lngJudgeMedicineExisted(m_objMainVo.m_strDRUGSTOREID_INT, m_objDetailArr[i2].m_strLOTNO_VCHR, m_objDetailArr[i2].m_strMEDICINEID_CHR,
                        //        ref m_dblStoregeAmount,ref m_dblStorageIPAmount, out m_blnCheckEnough);
                        //    if (m_dblStoregeAmount == 1)
                        //    {
                        //        throw new Exception("批号为[" + m_objDetailArr[i2].m_strLOTNO_VCHR + "]的药品[" + m_objDetailArr[i2].m_strMEDICINENAME_VCHR
                        //            +"]数量不够冲减！");
                        //    }
                        //    if (m_blnCheckEnough == false)
                        //    {
                        //        throw new Exception("库存不存在批号为[" + m_objDetailArr[i2].m_strLOTNO_VCHR + "]的药品[" + m_objDetailArr[i2].m_strMEDICINENAME_VCHR
                        //            + "]！");
                        //    }
                        //}
                    }
                    clsInstorage_SVC clsInSvc = new clsInstorage_SVC();
                    lngRes = clsInSvc.m_lngAddStorage(p_objPrincipal, ref objStorageDetailArr, 1);
                    if (lngRes < 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("保存库存出错");
                    }

                    lngRes = clsInSvc.m_lngInstorageSetExamer(p_strExamerID, m_objMainVo.m_lngSERIESID_INT);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("设置审核者出错");
                    }
                    if (lngRes > 0)//入帐
                    {
                        clsInSvc.m_lngAddNewAccountDetail(p_objPrincipal, objStorageDetailArr);
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

        /// <summary>
        /// 查询药房盘点状态
        /// </summary>
        /// <param name="p_strSeriesid">序列号</param>
        /// <param name="p_strState">状态</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryStoreCheckState(string p_strSeriesid, out string p_strState)
        {
            long lngRes = 0;
            p_strState = null;
            DataTable dtResult = null;
            string strSql = @"select a.status from t_ds_storagecheck a where a.seriesid_int = ?";
            try
            {
                clsHRPTableService clsHrpSvc = new clsHRPTableService();
                IDataParameter[] objParams = null;
                clsHrpSvc.CreateDatabaseParameter(1, out objParams);
                objParams[0].Value = p_strSeriesid;

                lngRes = clsHrpSvc.lngGetDataTableWithParameters(strSql, ref dtResult, objParams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_strState = dtResult.Rows[0][0].ToString();
                }

                clsHrpSvc.Dispose();
                clsHrpSvc = null;
            }
            catch (Exception objex)
            {
                clsLogText clsError = new clsLogText();
                bool blnRes = clsError.LogError(objex.ToString());
            }

            return lngRes;
        }
    }
}
