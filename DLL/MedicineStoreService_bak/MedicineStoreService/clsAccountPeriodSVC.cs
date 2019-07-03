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
    /// 帐务期结转
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAccountPeriodSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 帐务期表内容
        /// <summary>
        /// 新增帐务期表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAccPeVO">帐务期表内容</param>
        /// <param name="p_lngMainSEQ">帐务期表序列</param>
        /// <param name="p_strAccoutID">帐务期ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_AccountPeriodVO p_objAccPeVO, out long p_lngMainSEQ, out string p_strAccoutID)
        {
            p_lngMainSEQ = 0;
            p_strAccoutID = string.Empty;

            if (p_objAccPeVO == null)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_accountperiod
  (seriesid_int,
   accountid_chr,
   starttime_dat,
   endtime_dat,
   transfertime_dat,
   comment_vchr,
   storageid_chr)
values
  (?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                IDataParameter[] objLisAddItemRefArr = null;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_ACCOUNTPERIOD", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_lngMainSEQ = lngSEQ;
                lngRes = m_lngGetLatestAccountID(p_objPrincipal, p_objAccPeVO.m_strSTORAGEID_CHR, out p_strAccoutID);
                if (lngRes <= 0 || string.IsNullOrEmpty(p_strAccoutID))
                {
                    return -1;
                }

                objHRPServ.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_strAccoutID;
                objLisAddItemRefArr[2].DbType = DbType.DateTime;
                objLisAddItemRefArr[2].Value = p_objAccPeVO.m_dtmSTARTTIME_DAT;
                objLisAddItemRefArr[3].DbType = DbType.DateTime;
                objLisAddItemRefArr[3].Value = p_objAccPeVO.m_dtmENDTIME_DAT;
                objLisAddItemRefArr[4].DbType = DbType.DateTime;
                objLisAddItemRefArr[4].Value = p_objAccPeVO.m_dtmTRANSFERTIME_DAT;
                objLisAddItemRefArr[5].Value = p_objAccPeVO.m_strCOMMENT_VCHR;
                objLisAddItemRefArr[6].Value = p_objAccPeVO.m_strSTORAGEID_CHR;
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

        #region 获取帐务期表内容
        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">帐务期表序列</param>
        /// <param name="p_objAccPeVO">帐务期表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out clsMS_AccountPeriodVO p_objAccPeVO)
        {
            p_objAccPeVO = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.accountid_chr,
       t.starttime_dat,
       t.endtime_dat,
       t.transfertime_dat,
       t.comment_vchr,
       t.storageid_chr
  from t_ms_accountperiod t
 where t.seriesid_int = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    DataRow drCurrent = dtbValue.Rows[0];
                    p_objAccPeVO = new clsMS_AccountPeriodVO();
                    p_objAccPeVO.m_dtmENDTIME_DAT = Convert.ToDateTime(drCurrent["endtime_dat"]);
                    p_objAccPeVO.m_dtmSTARTTIME_DAT = Convert.ToDateTime(drCurrent["starttime_dat"]);
                    p_objAccPeVO.m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(drCurrent["transfertime_dat"]);
                    p_objAccPeVO.m_lngSERIESID_INT = p_lngMainSEQ;
                    p_objAccPeVO.m_strACCOUNTID_CHR = drCurrent["accountid_chr"].ToString();
                    p_objAccPeVO.m_strCOMMENT_VCHR = drCurrent["comment_vchr"].ToString();
                    p_objAccPeVO.m_strSTORAGEID_CHR = drCurrent["storageid_chr"].ToString();
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
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbAccountData">帐务期表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbAccountData)
        {
            p_dtbAccountData = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.accountid_chr,
       t.starttime_dat,
       t.endtime_dat,
       t.transfertime_dat,
       t.comment_vchr,
       t.storageid_chr,
       t.seriesid_int
  from t_ms_accountperiod t
 where t.storageid_chr = ?
  order by t.accountid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbAccountData, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccountData">帐务期表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out clsMS_AccountPeriodVO[] p_objAccountData)
        {
            p_objAccountData = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.accountid_chr,
       t.starttime_dat,
       t.endtime_dat,
       t.transfertime_dat,
       t.comment_vchr,
       t.storageid_chr,
       t.seriesid_int
  from t_ms_accountperiod t
 where t.storageid_chr = ?
  order by t.accountid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    DataRow drTemp = null;
                    p_objAccountData = new clsMS_AccountPeriodVO[intRowsCount];
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbValue.Rows[iRow];
                        p_objAccountData[iRow] = new clsMS_AccountPeriodVO();
                        p_objAccountData[iRow].m_dtmENDTIME_DAT = Convert.ToDateTime(drTemp["endtime_dat"]);
                        p_objAccountData[iRow].m_dtmSTARTTIME_DAT = Convert.ToDateTime(drTemp["starttime_dat"]);
                        p_objAccountData[iRow].m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(drTemp["transfertime_dat"]);
                        p_objAccountData[iRow].m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"]);
                        p_objAccountData[iRow].m_strACCOUNTID_CHR = drTemp["accountid_chr"].ToString();
                        p_objAccountData[iRow].m_strCOMMENT_VCHR = drTemp["comment_vchr"].ToString();
                        p_objAccountData[iRow].m_strSTORAGEID_CHR = p_strStorageID;
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

        #region 最新的帐务期号

        /// <summary>
        /// 最新的帐务期号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestAccountID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStorageID, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.accountid_chr)
  from t_ms_accountperiod t
 where t.accountid_chr like ?
  and t.storageid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = DateTime.Now.ToString("yyyy") + "%";
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    p_strID = DateTime.Now.ToString("yyyy") + "01";
                }
                else
                {
                    string strTemp = dtbValue.Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strTemp))
                    {
                        p_strID = DateTime.Now.ToString("yyyy") + "01";
                    }
                    else
                    {
                        double dblID = 0d;
                        if (double.TryParse(strTemp,out dblID))
                        {
                            p_strID = (dblID + 1).ToString();
                        }
                        else
                        {
                            return -1;
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

        #region 新增总帐表
        /// <summary>
        /// 新增总帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <param name="p_lngSEQ">总帐表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAccount(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Account p_objRecord, out long p_lngSEQ)
        {
            p_lngSEQ = 0;
            if (p_objRecord == null)
            {
                return -1;
            }
            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_account
  (seriesid_int,
   accountid,
   storageid_chr,
   comment_vchr,
   begincallfigure_int,
   beginretailfigure_int,
   beginwholesalefigure_int,
   instoragecallfigure_int,
   instorageretailfigure_int,
   instoragwholesalefigure_int,
   outstoragecallfigure_int,
   outstorageretailfigure_int,
   outstoragewholesalefigure_int,
   outreturncallfigure_int,
   outreturnretailfigure_int,
   outreturnwholesalefigure_int,
   inreturncallfigure_int,
   inreturnretailfigure_int,
   inreturnwholesalefigure_int,
   repealcallfigure_int,
   repealretailfigure_int,
   repealwholesalefigure_int,
   checkcallfigure_int,
   checkretailfigure_int,
   checkwholesalefigure_int,
   adjustcallfigure_int,
   adjustretailfigure_int,
   adjustwholesalefigure_int,
   endcallfigure_int,
   endretailfigure_int,
   endwholesalefigure_int)
values
  (?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,
   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,
   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,
   ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_ACCOUNT", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_lngSEQ = lngSEQ;

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPServ.CreateDatabaseParameter(31, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strACCOUNTID;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strSTORAGEID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strCOMMENT_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_dblBEGINCALLFIGURE_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_dblBEGINRETAILFIGURE_INT;
                objLisAddItemRefArr[6].Value = p_objRecord.m_dblBEGINWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_dblINSTORAGECALLFIGURE_INT;
                objLisAddItemRefArr[8].Value = p_objRecord.m_dblINSTORAGERETAILFIGURE_INT;
                objLisAddItemRefArr[9].Value = p_objRecord.m_dblINSTORAGWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[10].Value = p_objRecord.m_dblOUTSTORAGECALLFIGURE_INT;
                objLisAddItemRefArr[11].Value = p_objRecord.m_dblOUTSTORAGERETAILFIGURE_INT;
                objLisAddItemRefArr[12].Value = p_objRecord.m_dblOUTSTORAGEWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[13].Value = p_objRecord.m_dblOUTRETURNCALLFIGURE_INT;
                objLisAddItemRefArr[14].Value = p_objRecord.m_dblOUTRETURNRETAILFIGURE_INT;
                objLisAddItemRefArr[15].Value = p_objRecord.m_dblOUTRETURNWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[16].Value = p_objRecord.m_dblINRETURNCALLFIGURE_INT;
                objLisAddItemRefArr[17].Value = p_objRecord.m_dblINRETURNRETAILFIGURE_INT;
                objLisAddItemRefArr[18].Value = p_objRecord.m_dblINRETURNWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[19].Value = p_objRecord.m_dblREPEALCALLFIGURE_INT;
                objLisAddItemRefArr[20].Value = p_objRecord.m_dblREPEALRETAILFIGURE_INT;
                objLisAddItemRefArr[21].Value = p_objRecord.m_dblREPEALWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[22].Value = p_objRecord.m_dblCHECKCALLFIGURE_INT;
                objLisAddItemRefArr[23].Value = p_objRecord.m_dblCHECKRETAILFIGURE_INT;
                objLisAddItemRefArr[24].Value = p_objRecord.m_dblCHECKWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[25].Value = p_objRecord.m_dblADJUSTCALLFIGURE_INT;
                objLisAddItemRefArr[26].Value = p_objRecord.m_dblADJUSTRETAILFIGURE_INT;
                objLisAddItemRefArr[27].Value = p_objRecord.m_dblADJUSTWHOLESALEFIGURE_INT;
                objLisAddItemRefArr[28].Value = p_objRecord.m_dblENDCALLFIGURE_INT;
                objLisAddItemRefArr[29].Value = p_objRecord.m_dblENDRETAILFIGURE_INT;
                objLisAddItemRefArr[30].Value = p_objRecord.m_dblENDWHOLESALEFIGURE_INT;

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

        #region 获取总帐表内容
        /// <summary>
        /// 获取总帐表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccout(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAccountID, out clsMS_Account p_objRecord)
        {
            p_objRecord = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int,
       t.accountid,
       t.storageid_chr,
       t.comment_vchr,
       t.begincallfigure_int,
       t.beginretailfigure_int,
       t.beginwholesalefigure_int,
       t.instoragecallfigure_int,
       t.instorageretailfigure_int,
       t.instoragwholesalefigure_int,
       t.outstoragecallfigure_int,
       t.outstorageretailfigure_int,
       t.outstoragewholesalefigure_int,
       t.outreturncallfigure_int,
       t.outreturnretailfigure_int,
       t.outreturnwholesalefigure_int,
       t.inreturncallfigure_int,
       t.inreturnretailfigure_int,
       t.inreturnwholesalefigure_int,
       t.repealcallfigure_int,
       t.repealretailfigure_int,
       t.repealwholesalefigure_int,
       t.checkcallfigure_int,
       t.checkretailfigure_int,
       t.checkwholesalefigure_int,
       t.adjustcallfigure_int,
       t.adjustretailfigure_int,
       t.adjustwholesalefigure_int,
       t.endcallfigure_int,
       t.endretailfigure_int,
       t.endwholesalefigure_int
  from t_ms_account t
 where t.storageid_chr = ?
   and t.accountid = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_objRecord = new clsMS_Account();
                    DataRow drCurrent = dtbValue.Rows[0];
                    p_objRecord.m_dblADJUSTCALLFIGURE_INT = Convert.ToDouble(drCurrent["ADJUSTCALLFIGURE_INT"]);
                    p_objRecord.m_dblADJUSTRETAILFIGURE_INT = Convert.ToDouble(drCurrent["ADJUSTRETAILFIGURE_INT"]);
                    p_objRecord.m_dblADJUSTWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["ADJUSTWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblBEGINCALLFIGURE_INT = Convert.ToDouble(drCurrent["BEGINCALLFIGURE_INT"]);
                    p_objRecord.m_dblBEGINRETAILFIGURE_INT = Convert.ToDouble(drCurrent["BEGINRETAILFIGURE_INT"]);
                    p_objRecord.m_dblBEGINWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["BEGINWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblCHECKCALLFIGURE_INT = Convert.ToDouble(drCurrent["CHECKCALLFIGURE_INT"]);
                    p_objRecord.m_dblCHECKRETAILFIGURE_INT = Convert.ToDouble(drCurrent["CHECKRETAILFIGURE_INT"]);
                    p_objRecord.m_dblCHECKWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["CHECKWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblENDCALLFIGURE_INT = Convert.ToDouble(drCurrent["ENDCALLFIGURE_INT"]);
                    p_objRecord.m_dblENDRETAILFIGURE_INT = Convert.ToDouble(drCurrent["ENDRETAILFIGURE_INT"]);
                    p_objRecord.m_dblENDWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["ENDWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblINRETURNCALLFIGURE_INT = Convert.ToDouble(drCurrent["INRETURNCALLFIGURE_INT"]);
                    p_objRecord.m_dblINRETURNRETAILFIGURE_INT = Convert.ToDouble(drCurrent["INRETURNRETAILFIGURE_INT"]);
                    p_objRecord.m_dblINRETURNWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["INRETURNWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblINSTORAGECALLFIGURE_INT = Convert.ToDouble(drCurrent["INSTORAGECALLFIGURE_INT"]);
                    p_objRecord.m_dblINSTORAGERETAILFIGURE_INT = Convert.ToDouble(drCurrent["INSTORAGERETAILFIGURE_INT"]);
                    p_objRecord.m_dblINSTORAGWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["INSTORAGWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblOUTRETURNCALLFIGURE_INT = Convert.ToDouble(drCurrent["OUTRETURNCALLFIGURE_INT"]);
                    p_objRecord.m_dblOUTRETURNRETAILFIGURE_INT = Convert.ToDouble(drCurrent["OUTRETURNRETAILFIGURE_INT"]);
                    p_objRecord.m_dblOUTRETURNWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["OUTRETURNWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblOUTSTORAGECALLFIGURE_INT = Convert.ToDouble(drCurrent["OUTSTORAGECALLFIGURE_INT"]);
                    p_objRecord.m_dblOUTSTORAGERETAILFIGURE_INT = Convert.ToDouble(drCurrent["OUTSTORAGERETAILFIGURE_INT"]);
                    p_objRecord.m_dblOUTSTORAGEWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["OUTSTORAGEWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_dblREPEALCALLFIGURE_INT = Convert.ToDouble(drCurrent["REPEALCALLFIGURE_INT"]);
                    p_objRecord.m_dblREPEALRETAILFIGURE_INT = Convert.ToDouble(drCurrent["REPEALRETAILFIGURE_INT"]);
                    p_objRecord.m_dblREPEALWHOLESALEFIGURE_INT = Convert.ToDouble(drCurrent["REPEALWHOLESALEFIGURE_INT"]);
                    p_objRecord.m_lngSERIESID_INT = Convert.ToInt64(drCurrent["SERIESID_INT"]);
                    p_objRecord.m_strACCOUNTID = p_strAccountID;
                    p_objRecord.m_strCOMMENT_VCHR = drCurrent["COMMENT_VCHR"].ToString();
                    p_objRecord.m_strSTORAGEID_CHR = p_strStorageID;
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

        #region 获取总帐表内容(打印)

        /// <summary>
        /// 获取总帐表内容(打印)

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccout(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAccountID, out DataTable p_objDtb)
        {
            p_objDtb = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int,
       t.accountid,
       t.storageid_chr,
       t.comment_vchr,
       t.begincallfigure_int,
       t.beginretailfigure_int,
       t.beginwholesalefigure_int,
       t.instoragecallfigure_int,
       t.instorageretailfigure_int,
       t.instoragwholesalefigure_int,
       t.outstoragecallfigure_int,
       t.outstorageretailfigure_int,
       t.outstoragewholesalefigure_int,
       t.outreturncallfigure_int,
       t.outreturnretailfigure_int,
       t.outreturnwholesalefigure_int,
       t.inreturncallfigure_int,
       t.inreturnretailfigure_int,
       t.inreturnwholesalefigure_int,
       t.repealcallfigure_int,
       t.repealretailfigure_int,
       t.repealwholesalefigure_int,
       t.checkcallfigure_int,
       t.checkretailfigure_int,
       t.checkwholesalefigure_int,
       t.adjustcallfigure_int,
       t.adjustretailfigure_int,
       t.adjustwholesalefigure_int,
       t.endcallfigure_int,
       t.endretailfigure_int,
       t.endwholesalefigure_int
  from t_ms_account t
 where t.storageid_chr = ?
   and t.accountid = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_objDtb, objDPArr);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 生成帐表
        /// <summary>
        /// 生成帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccount">帐务表</param>
        /// <param name="p_lngSEQArr">序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGenarateAccount(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out clsMS_Account p_objAccount, out long[] p_lngSEQArr)
        {
            p_objAccount = new clsMS_Account();
            p_lngSEQArr = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select /* + all_rows */ t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.amount_int,
       t.chittyid_vchr,
       t.newretailprice_int,
       t.seriesid_int,
       t.type_int,
       t.newwholesaleprice_int
  from t_ms_account_detail t
 where (t.state_int = 1
    or t.state_int = 2)
   and t.operatedate_dat between ? and ?
   and t.storageid_chr = ?
   and t.isend_int = 0";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                int intRowsCount = 0;
                if (dtbValue == null)
                {
                    intRowsCount = 0;
                }
                else
                {
                    intRowsCount = dtbValue.Rows.Count;
                }

                DataRow drCurrent = null;
                int intProcessType = 0;
                p_objAccount.m_strSTORAGEID_CHR = p_strStorageID;
                p_lngSEQArr = new long[intRowsCount];
                double dblTemp = 0;
                double dblTmp = 0;

                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtbValue.Rows[iRow];
                    intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                    p_lngSEQArr[iRow] = Convert.ToInt64(drCurrent["seriesid_int"]);

                    switch (intProcessType)
                    {
                        case 1:
                            p_objAccount.m_dblINSTORAGECALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblINSTORAGERETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblINSTORAGWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            p_objAccount.m_dblOUTSTORAGECALLFIGURE_INT +=  Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblOUTSTORAGERETAILFIGURE_INT +=  Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblOUTSTORAGEWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            p_objAccount.m_dblOUTRETURNCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblOUTRETURNRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblOUTRETURNWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            p_objAccount.m_dblINRETURNCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblINRETURNRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblINRETURNWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            p_objAccount.m_dblREPEALCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblREPEALRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblREPEALWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)//盘盈
                            {
                                p_objAccount.m_dblCHECKCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objAccount.m_dblCHECKRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objAccount.m_dblCHECKWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)//盘亏
                            {
                                p_objAccount.m_dblCHECKCALLFIGURE_INT -=  Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objAccount.m_dblCHECKRETAILFIGURE_INT -=  Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objAccount.m_dblCHECKWHOLESALEFIGURE_INT -=  Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }                            
                            break;
                        case 7:
                            p_objAccount.m_dblBEGINCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblBEGINRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objAccount.m_dblBEGINWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 8:
                            //p_objAccount.m_dblADJUSTCALLFIGURE_INT += Convert.ToDouble(drCurrent["callprice_int"]) * Convert.ToDouble(drCurrent["amount_int"]);
                            p_objAccount.m_dblADJUSTRETAILFIGURE_INT += (Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4)) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]),4);
                            double.TryParse(drCurrent["newwholesaleprice_int"].ToString(), out dblTemp);
                            double.TryParse(drCurrent["wholesaleprice_int"].ToString(), out dblTmp);
                            p_objAccount.m_dblADJUSTWHOLESALEFIGURE_INT += (dblTemp - dblTmp) * Convert.ToDouble(drCurrent["amount_int"]);
                            break;
                    }
                }

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select endcallfigure_int, endretailfigure_int, endwholesalefigure_int
  from (select endcallfigure_int,
               endretailfigure_int,
               endwholesalefigure_int
          from t_ms_account
         where storageid_chr = ?
         order by seriesid_int desc)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 endcallfigure_int, endretailfigure_int, endwholesalefigure_int
  from t_ms_account
 where storageid_chr = ?
 order by seriesid_int desc";
                }

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    drCurrent = dtbValue.Rows[0];
                    p_objAccount.m_dblBEGINCALLFIGURE_INT = Math.Round(Convert.ToDouble(drCurrent["endcallfigure_int"]), 4);
                    p_objAccount.m_dblBEGINRETAILFIGURE_INT = Math.Round(Convert.ToDouble(drCurrent["endretailfigure_int"]), 4);
                    p_objAccount.m_dblBEGINWHOLESALEFIGURE_INT = Math.Round(Convert.ToDouble(drCurrent["endwholesalefigure_int"]), 4);
                }

                strSQL = @"select t.realgross_int,
       t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int
  from t_ms_storage_detail t
 where t.storageid_chr = ?
   and t.status = 1";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    intRowsCount = dtbValue.Rows.Count;
                    drCurrent = null;
                    for (int i = 0; i < intRowsCount; i++)
                    {
                        drCurrent = dtbValue.Rows[i];
                        p_objAccount.m_dblENDCALLFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["realgross_int"]), 4);
                        p_objAccount.m_dblENDRETAILFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["realgross_int"]), 4);
                        p_objAccount.m_dblENDWHOLESALEFIGURE_INT += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["realgross_int"]), 4);
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

        #region 获取操作类型
        /// <summary>
        /// 获取操作类型
        /// </summary>
        /// <param name="p_strChitty">单据号</param>
        /// <returns></returns>
        [AutoComplete]
        private int m_intGetProcessType(string p_strChitty)
        {
            int intType = 0;
            if (string.IsNullOrEmpty(p_strChitty))
            {
                return -1;
            }

            try
            {
                char chrPro = p_strChitty[8];

                if (!int.TryParse(chrPro.ToString(), out intType))
                {
                    return -1;
                }
                else
                {
                    if (intType < 1 || intType > 8)
                    {
                        return -1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return intType;
        } 
        #endregion

        #region 保存帐表
        /// <summary>
        /// 保存帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAccPe">帐务期结转内容</param>
        /// <param name="p_objAccount">帐表内容</param>
        /// <param name="p_lngMedSEQ">流水帐序列</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_lngMainSEQ">帐务期序列</param>
        /// <param name="p_lngSubSEQ">帐表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveAccount(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_AccountPeriodVO p_objAccPe, clsMS_Account p_objAccount,long[] p_lngMedSEQ,string p_strEmpID, out string p_strAccountID, out long p_lngMainSEQ, out long p_lngSubSEQ)
        {
            p_strAccountID = string.Empty;
            p_lngMainSEQ = 0;
            p_lngSubSEQ = 0;

            if (p_objAccount == null || p_objAccPe == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                lngRes = m_lngAddAccountPeriod(p_objPrincipal, p_objAccPe, out p_lngMainSEQ, out p_strAccountID);
                if (lngRes <= 0)
                {
                    return -1;
                }

                p_objAccount.m_strACCOUNTID = p_strAccountID;
                lngRes = m_lngAddNewAccount(p_objPrincipal, p_objAccount, out p_lngSubSEQ);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                lngRes = m_lngSaveToAccountDetail(p_objPrincipal, p_strEmpID, p_objAccPe.m_dtmTRANSFERTIME_DAT, p_strAccountID, p_objAccount.m_strSTORAGEID_CHR);
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
            return lngRes;
        }

        /// <summary>
        /// 保存至流水帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSaveToAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal,string p_strEmpID,DateTime  p_dtmAccountDate, string p_strAccountID, string p_strStorageID)
        {

            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID))
            {
                 return -1;
            }

            long lngRes = 0;
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
         b.medicinetypeid_chr,
         a.medspec_vchr,
         a.opunit_vchr,
         a.instorageid_vchr,
         a.lotno_vchr,
         a.callprice_int,
         a.wholesaleprice_int,
         a.retailprice_int,
         0,
         a.vendorid_chr,
         0,
         a.realgross_int,
         a.realgross_int,
         a.callprice_int,
         a.wholesaleprice_int,
         a.retailprice_int,
         a.instorageid_vchr,
         0,
         1,
         ?,
         ?,
         ?,
         1,
         null,
         ?,
         a.validperiod_dat
    from t_ms_storage_detail a, t_bse_medicine b
   where a.status = 1
     and a.medicineid_chr = b.medicineid_chr
     and a.storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objLisAddItemRefArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strEmpID;
                objLisAddItemRefArr[1].DbType = DbType.DateTime;
                objLisAddItemRefArr[1].Value = p_dtmAccountDate;
                objLisAddItemRefArr[2].Value = p_strAccountID;
                objLisAddItemRefArr[3].DbType = DbType.DateTime;
                objLisAddItemRefArr[3].Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                objLisAddItemRefArr[4].Value = p_strStorageID;

                long lngEff = -1;
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

        #region 检查是否有未确定入帐的记录
        /// <summary>
        /// 检查是否有未确定入帐的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasUnConfirmAccount(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out string[] p_strChittyIDArr,out Int64[] p_intSeriesIDArr)
        {
            p_strChittyIDArr = null;
            p_intSeriesIDArr = null;
            long lngRes = -1;
            try
            {
                string strSQL = @"select distinct t.chittyid_vchr
  from t_ms_account_detail t
 where t.state_int = 2
   and t.operatedate_dat between ? and ?
   and t.storageid_chr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    p_strChittyIDArr = new string[intRowsCount];
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_strChittyIDArr[iRow] = dtbValue.Rows[iRow][0].ToString();
                    }
                }

                strSQL = @"select t.seriesid_int
  from t_ms_account_detail t
 where t.state_int = 2
   and t.operatedate_dat between ? and ?
   and t.storageid_chr = ?";
                
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    p_intSeriesIDArr = new long[intRowsCount];
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        p_intSeriesIDArr[iRow] = Convert.ToInt64(dtbValue.Rows[iRow][0]);
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

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate, string[] p_strChittyIDArr, string p_strStorageID,Int64[] p_intSeriesIDArr)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                List<string> lstInID = new List<string>();//入库表单据号
                List<string> lstOutID = new List<string>();//出库表单据号
                List<string> lstStCheckID = new List<string>();//盘点表单据号
                List<string> lstAdjustID = new List<string>();//调价表单据号
                List<string> lstInitID = new List<string>();//期初数

                int intType = 0;
                for (int iStr = 0; iStr < p_strChittyIDArr.Length; iStr++)
                {
                    intType = m_intGetProcessType(p_strChittyIDArr[iStr]);
                    if (intType == 1 || intType == 4)
                    {
                        lstInID.Add(p_strChittyIDArr[iStr]);
                    }
                    else if (intType == 2 || intType == 3 || intType == 5)
                    {
                        lstOutID.Add(p_strChittyIDArr[iStr]);
                    }
                    else if (intType == 6)
                    {
                        lstStCheckID.Add(p_strChittyIDArr[iStr]);
                    }
                    else if (intType == 7)
                    {
                        lstInitID.Add(p_strChittyIDArr[iStr]);
                    }
                    else if (intType == 8)
                    {
                        lstAdjustID.Add(p_strChittyIDArr[iStr]);
                    }
                }

                if (lstInID.Count > 0)//入库表
                {
                    clsInStorageSVC objInSVC = new clsInStorageSVC();
                    lngRes = objInSVC.m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate, p_strStorageID,lstInID.ToArray());
                    objInSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (lstOutID.Count > 0)//出库表
                {
                    clsOutStorageSVC objOutSVC = new clsOutStorageSVC();
                    lngRes = objOutSVC.m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate,p_strStorageID, lstOutID.ToArray());
                    objOutSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (lstStCheckID.Count > 0)//盘点表
                {
                    clsStorageCheckSVC objStCheck = new clsStorageCheckSVC();
                    lngRes = objStCheck.m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmAccountDate,p_strStorageID, lstStCheckID.ToArray());
                    objStCheck = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (lstAdjustID.Count > 0)//调价表
                {
                    clsAdjustmentSVC objAdSVC = new clsAdjustmentSVC();
                    lngRes = objAdSVC.m_lngSetAccountUser(p_objPrincipal, lstAdjustID.ToArray(), p_strEmpID,p_strStorageID, p_dtmAccountDate);
                    objAdSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (lstInitID.Count > 0)//初始化
                {
                    clsInventoryRecordSVC objIniSVC = new clsInventoryRecordSVC();
                    lngRes = objIniSVC.m_lngSetAccoutnUser(p_objPrincipal, lstInitID.ToArray(), p_strEmpID, p_strStorageID);
                    objIniSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                lngRes = objAccSVC.m_lngRatifyAccountDetailBySeriesID(p_objPrincipal, p_intSeriesIDArr, p_strEmpID, p_dtmAccountDate);
                objAccSVC = null;
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
            return lngRes;
        } 
        #endregion

        #region 取消结转
        /// <summary>
        /// 取消结转
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">帐务期表序列</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCancelAccount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, string p_strAccountID, string p_strStorageID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"delete from t_ms_accountperiod where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes <= 0)
                {
                    return -1;
                }

                strSQL = @"delete from t_ms_account
 where accountid = ?
   and storageid_chr = ?";

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAccountID;
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes < 0)
                {
                    throw new Exception();
                }

                strSQL = @"delete from t_ms_account_detail
 where accountid_chr = ?
   and storageid_chr = ?";

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAccountID;
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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
        } 
        #endregion

        #region 判断是否可以取消选中的帐务结转
        /// <summary>
        /// 判断是否可以取消选中的帐务结转(如果已经有下一期的业务单据则不允许)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmEndDate">选中帐务结转的帐务结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnCanCancel">是否可以取消</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckCanCancelAccount(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmEndDate, string p_strStorageID, out bool p_blnCanCancel)
        {
            p_blnCanCancel = true;
            long lngRes = 0;
            try
            {
                string strSQL = @"select count(t.seriesid_int)
  from t_ms_account_detail t
 where (t.state_int = 1 or t.state_int = 2)
   and t.storageid_chr = ?
   and t.operatedate_dat > ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_dtmEndDate;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes <= 0)
                {
                    p_blnCanCancel = true;
                }
                else
                {
                    if (dtbValue == null || dtbValue.Rows.Count == 0)
                    {
                        p_blnCanCancel = true;
                    }

                    int intCount = 0;
                    if (int.TryParse(dtbValue.Rows[0][0].ToString(), out intCount))
                    {
                        if (intCount > 0)
                        {
                            p_blnCanCancel = false;
                        }
                        else
                        {
                            p_blnCanCancel = true;
                        }
                    }
                    else
                    {
                        p_blnCanCancel = true;
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

        #region 检查开帐务期内是否存在未审核的记录
        /// <summary>
        /// 检查开帐务期内是否存在未审核的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        /// <param name="p_dtmEndDate">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strHintText">存在未审核记录的单据名称(类型)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasUnCommitRecord(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out string p_strHintText)
        {
            p_strHintText = string.Empty;
            long lngRes = 0;
            try
            {
                StringBuilder stbHint = new StringBuilder(100);

                #region 入库表
                string strSQL = @"select t.seriesid_int, t.formtype_int
  from t_ms_instorage t, t_ms_instorage_detal d
 where t.instoragedate_dat between ? and ?
   and t.state_int = 1
   and t.storageid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    DataRow[] drTemp = dtbValue.Select("formtype_int = 1");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        stbHint.Append("　入库记录　");
                    }

                    drTemp = dtbValue.Select("formtype_int = 2");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        stbHint.Append("　内退记录　");
                    }
                    drTemp = null;
                }
                #endregion

                #region 出库表
                strSQL = @"select t.seriesid_int, t.formtype
  from t_ms_outstorage t,t_ms_outstorage_detail d
 where t.outstoragedate_dat between ? and ?
   and t.status = 1
   and t.storageid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status = 1";

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    DataRow[] drTemp = dtbValue.Select("formtype = 1");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        stbHint.Append("　出库记录　");
                    }
                    drTemp = dtbValue.Select("formtype = 2");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        stbHint.Append("　外退记录　");
                    }
                    drTemp = dtbValue.Select("formtype = 4");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        stbHint.Append("　报废记录　");
                    }
                    drTemp = null;
                }
                #endregion

                #region 调价表
                strSQL = @"select count(t.seriesid_int)
  from t_ms_adjustprice t, t_ms_adjustprice_detail d
 where t.adjustpricedate_dat between ? and ?
   and t.formstate_int = 1
   and t.storageid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status_int = 1";

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    int intCount = 0;
                    if (int.TryParse(dtbValue.Rows[0][0].ToString(), out intCount))
                    {
                        if (intCount > 0)
                        {
                            stbHint.Append("　调价记录　");
                        }                        
                    }
                }
                #endregion

                #region 盘点表
                strSQL = @"select count(t.seriesid_int)
  from t_ms_storagecheck t,t_ms_storagecheck_detail d
 where t.checkdate_dat between ? and ?
   and t.status = 1
   and t.storageid_chr = ?
   and t.seriesid_int = d.seriesid2_int
   and d.status_int = 1";

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBeginDate;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEndDate;
                objDPArr[2].Value = p_strStorageID;

                dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    int intCount = 0;
                    if (int.TryParse(dtbValue.Rows[0][0].ToString(), out intCount))
                    {
                        if (intCount > 0)
                        {
                            stbHint.Append("　盘点记录　");
                        }                        
                    }
                }
                #endregion

                p_strHintText = stbHint.ToString();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 获取选定帐务期期末结转的第一条SEQ
        /// <summary>
        /// 获取选定帐务期期末结转的第一条SEQ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngSEQ">返回所需的SEQ</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEndAccountFirstSEQ(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAccountID, string p_strStorageID, out long p_lngSEQ)
        {
            p_lngSEQ = 0;

            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    strSQL = @"select seriesid_int
  from (select t.seriesid_int
          from t_ms_account_detail t
         where t.storageid_chr = ?
           and t.accountid_chr = ?
           and t.isend_int = 1
           and t.state_int = 1
         order by t.seriesid_int)
 where rownum = 1";
                }
                else if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytODBC
                    || clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytSQL_Server)
                {
                    strSQL = @"select top 1 t.seriesid_int
  from t_ms_account_detail t
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.isend_int = 1
   and t.state_int = 1
 order t.seriesid_int";
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    return -1;
                }

                if (!long.TryParse(dtbValue.Rows[0][0].ToString(), out p_lngSEQ))
                {
                    return -1;
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
        
        #region 获取总帐表(不分类)
        /// <summary>
        /// 获取总帐表(不分类)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objAccount">总帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTotalAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAccountID, out clsMS_TotalAccountVO p_objAccount)
        {
            p_objAccount = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.accountid,
       t.storageid_chr,
       t.begincallfigure_int,
       t.beginretailfigure_int,
       t.beginwholesalefigure_int,
       t.instoragecallfigure_int,
       t.instorageretailfigure_int,
       t.instoragwholesalefigure_int,
       t.outstoragecallfigure_int,
       t.outstorageretailfigure_int,
       t.outstoragewholesalefigure_int,
       t.outreturncallfigure_int,
       t.outreturnretailfigure_int,
       t.outreturnwholesalefigure_int,
       t.inreturncallfigure_int,
       t.inreturnretailfigure_int,
       t.inreturnwholesalefigure_int,
       t.repealcallfigure_int,
       t.repealretailfigure_int,
       t.repealwholesalefigure_int,
       t.checkcallfigure_int,
       t.checkretailfigure_int,
       t.checkwholesalefigure_int,
       t.adjustcallfigure_int,
       t.adjustretailfigure_int,
       t.adjustwholesalefigure_int,
       t.endcallfigure_int,
       t.endretailfigure_int,
       t.endwholesalefigure_int
  from t_ms_account t
 where t.accountid = ?
   and t.storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAccountID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    DataRow drCurrent = dtbValue.Rows[0];
                    p_objAccount = new clsMS_TotalAccountVO();
                    p_objAccount.m_dblBeginCallMoney = Math.Round(Convert.ToDouble(drCurrent["begincallfigure_int"]), 4);
                    p_objAccount.m_dblBeginRetailMoney = Math.Round(Convert.ToDouble(drCurrent["beginretailfigure_int"]), 4);
                    p_objAccount.m_dblBeginWholesaleMoney = Math.Round(Convert.ToDouble(drCurrent["beginwholesalefigure_int"]), 4);
                    p_objAccount.m_dblInCallMoney = Math.Round(Convert.ToDouble(drCurrent["instoragecallfigure_int"]), 4);
                    p_objAccount.m_dblInRetailMoney = Math.Round(Convert.ToDouble(drCurrent["instorageretailfigure_int"]), 4);
                    p_objAccount.m_dblInWholesaleMoney = Math.Round(Convert.ToDouble(drCurrent["instoragwholesalefigure_int"]), 4);
                    p_objAccount.m_dblOutCallMoney = Math.Round(Convert.ToDouble(drCurrent["outstoragecallfigure_int"]), 4);
                    p_objAccount.m_dblOutRetailMoney = Math.Round(Convert.ToDouble(drCurrent["outstorageretailfigure_int"]), 4);
                    p_objAccount.m_dblOutWholesaleMoney = Math.Round(Convert.ToDouble(drCurrent["outstoragewholesalefigure_int"]), 4);
                    p_objAccount.m_dblOutCallMoney += Math.Round(Convert.ToDouble(drCurrent["outreturncallfigure_int"]), 4);
                    p_objAccount.m_dblOutRetailMoney += Math.Round(Convert.ToDouble(drCurrent["outreturnretailfigure_int"]), 4);
                    p_objAccount.m_dblOutWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["outreturnwholesalefigure_int"]), 4);
                    p_objAccount.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["inreturncallfigure_int"]), 4);
                    p_objAccount.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["inreturnretailfigure_int"]), 4);
                    p_objAccount.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["inreturnwholesalefigure_int"]), 4);
                    p_objAccount.m_dblOutCallMoney += Math.Round(Convert.ToDouble(drCurrent["repealcallfigure_int"]), 4);
                    p_objAccount.m_dblOutRetailMoney += Math.Round(Convert.ToDouble(drCurrent["repealretailfigure_int"]), 4);
                    p_objAccount.m_dblOutWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["repealwholesalefigure_int"]), 4);
                    double dblTemp = Convert.ToDouble(drCurrent["checkcallfigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutCallMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInCallMoney += Math.Round(dblTemp, 4);
                    }
                    dblTemp = Convert.ToDouble(drCurrent["checkretailfigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutRetailMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInRetailMoney += Math.Round(dblTemp, 4);
                    }
                    dblTemp = Convert.ToDouble(drCurrent["checkwholesalefigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutWholesaleMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInWholesaleMoney += Math.Round(dblTemp, 4);
                    }
                    dblTemp = Convert.ToDouble(drCurrent["adjustcallfigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutCallMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInCallMoney += Math.Round(dblTemp, 4);
                    }
                    dblTemp = Convert.ToDouble(drCurrent["adjustretailfigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutRetailMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInRetailMoney += Math.Round(dblTemp, 4);
                    }
                    dblTemp = Convert.ToDouble(drCurrent["adjustwholesalefigure_int"]);
                    if (dblTemp < 0)
                    {
                        p_objAccount.m_dblOutWholesaleMoney += Math.Round(dblTemp, 4);
                    }
                    else
                    {
                        p_objAccount.m_dblInWholesaleMoney += Math.Round(dblTemp, 4);
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

        #region 获取总帐报表(分类型)
        /// <summary>
        /// 获取总帐报表(分类型)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_lngEndFirstSEQ">本帐务期期末第一条SEQ</param>
        /// <param name="p_strAccountID">本帐务期ID</param>
        /// <param name="p_strLastAccountID">上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)</param>
        /// <param name="p_objAccount">总帐报表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTotalAccount_Divide(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, long p_lngEndFirstSEQ,string p_strAccountID, string p_strLastAccountID, out clsMS_TotalAccountVO[] p_objAccount)
        {
            p_objAccount = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int,
       t.medicinetypeid_chr,
       t.storageid_chr,
       t.amount_int,
       t.type_int,
       t.accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.newretailprice_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       b.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset b
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and t.seriesid_int < ?
   and (t.state_int = 1 or t.state_int = 2)
   and t.isend_int = 0
and t.medicinetypeid_chr = b.medicinetypeid_chr
 order by b.medicinetypesetid";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_lngEndFirstSEQ;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue == null)
                {
                    return -1;
                }

                strSQL = @"select t.seriesid_int,
       t.medicinetypeid_chr,
       t.storageid_chr,
       t.amount_int,
       t.type_int,
       t.accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.newretailprice_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       b.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset b
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.isend_int = 1
   and t.state_int = 1
   and t.medicinetypeid_chr = b.medicinetypeid_chr
 order by b.medicinetypesetid";

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;

                DataTable dtbEnd = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbEnd, objDPArr);
                if (lngRes < 0 || dtbEnd == null)
                {
                    return -1;
                }

                dtbValue.Merge(dtbEnd, true);

                if (!string.IsNullOrEmpty(p_strLastAccountID))
                {
                    strSQL = @"select t.seriesid_int,
       t.medicinetypeid_chr,
       t.storageid_chr,
       t.amount_int,
       t.type_int,
       t.accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.newretailprice_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       b.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset b
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.isend_int = 1
   and t.state_int = 1
 and t.medicinetypeid_chr = b.medicinetypeid_chr
 order by b.medicinetypesetid";

                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;

                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (dtbBegin == null || dtbBegin.Rows.Count == 0)
                    {
                        return -1;
                    }

                    dtbValue.Merge(dtbBegin, true);
                }

                DataView drValue = new DataView(dtbValue);
                drValue.Sort = "medicinetypeid_chr";

                System.Collections.ArrayList arrAcc = new System.Collections.ArrayList();
                int intRowsCount = drValue.Count;
                int intProcessType = 0;//操作类型
                DataRowView drCurrent = null;
                clsMS_TotalAccountVO objCurrent = null;
                int intIsEnd = 0;
                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;

                //调价零价金额
                double douCheckRetailMoney = 0;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = drValue[iRow];

                    if (iRow == 0)
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        arrAcc.Add(objCurrent);
                    }
                    else if (drCurrent["medicinetypesetname"].ToString() != drValue[iRow - 1]["medicinetypesetname"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        arrAcc.Add(objCurrent);
                    }
                    //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                    if ((iRow == drValue.Count - 1) || (iRow < drValue.Count - 1 && drCurrent["medicinetypesetname"].ToString() != drValue[iRow + 1]["medicinetypesetname"].ToString()))
                    {
                        if (douWholesaleMoney > 0)
                        {
                            objCurrent.m_dblInCallMoney += douCallMoney;
                            objCurrent.m_dblInRetailMoney += douRetailMoney;
                            objCurrent.m_dblInWholesaleMoney += douWholesaleMoney;
                        }
                        else
                        {
                            objCurrent.m_dblOutCallMoney += douCallMoney;
                            objCurrent.m_dblOutRetailMoney += douRetailMoney;
                            objCurrent.m_dblOutWholesaleMoney += douWholesaleMoney;
                        }
                        douCallMoney = 0;
                        douRetailMoney = 0;
                        douWholesaleMoney = 0;
                        if (douCheckRetailMoney > 0)
                        {
                            objCurrent.m_dblInRetailMoney += douCheckRetailMoney;
                        }
                        else
                        {
                            objCurrent.m_dblOutRetailMoney += douCheckRetailMoney;
                        }
                        douCheckRetailMoney = 0;
                    }
                    intIsEnd = Convert.ToInt32(drCurrent["isend_int"]);
                    if (intIsEnd == 1)
                    {
                        //上期期末为本期期初
                        if (!string.IsNullOrEmpty(p_strLastAccountID) && drCurrent["isthis"].ToString() == "0")
                        {
                            objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if(drCurrent["isthis"].ToString() =="1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                    }

                    intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                    switch (intProcessType)
                    {
                        case 1:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            //累加盘点金额
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                douCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                douCallMoney -= Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney -= Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney -= Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objAccount = arrAcc.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 获取总帐报表(分类型)（未转帐）
        /// <summary>
        /// 获取总帐报表(分类型)（未转帐）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_lngEndFirstSEQ">本帐务期期末第一条SEQ</param>
        /// <param name="p_strAccountID">本帐务期ID</param>
        /// <param name="p_strLastAccountID">上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)</param>
        /// <param name="p_objAccount">总帐报表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTotalAccount_DivideNoAcc(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, long p_lngEndFirstSEQ, string p_strAccountID, string p_strLastAccountID, out clsMS_TotalAccountVO[] p_objAccount)
        {
            p_objAccount = null;



            long lngRes = 0;
            try
            {
                string strSQL = @"select t.seriesid_int,
       t.medicinetypeid_chr,
       t.storageid_chr,
       t.amount_int,
       t.type_int,
       t.accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.newretailprice_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       b.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset b
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2) 
   and t.isend_int = 0
   and t.medicinetypeid_chr = b.medicinetypeid_chr
 order by b.medicinetypesetid";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue == null )
                {
                    return -1;
                }

                strSQL = @" select t.seriesid_int,
       b.medicinetypeid_chr,
       t.storageid_chr,
       t.realgross_int amount_int,
       0 type_int,
       '000000' accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.retailprice_int newretailprice_int,
       t.instorageid_vchr chittyid_vchr,
       1 isend_int,
       t.realgross_int endamount_int,
       t.callprice_int endcallprice_int,
       t.wholesaleprice_int endwholesaleprice_int,
       t.retailprice_int endretailprice_int,
       c.medicinetypesetname medicinetypesetname,
       1 isthis
  from t_ms_storage_detail t,t_bse_medicine b,t_ms_medicinetypeset c
 where t.medicineid_chr = b.medicineid_chr
 and b.medicinetypeid_chr = c.medicinetypeid_chr 
 and t.storageid_chr = ?
   and t.status = 1";

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                DataTable dtbEnd = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbEnd, objDPArr);
                if (lngRes < 0 || dtbEnd == null)
                {
                    return -1;
                }
                DataTable dtbTemp = dtbValue.Clone();
                dtbTemp.BeginLoadData();
                for (int iROw = 0; iROw < dtbEnd.Rows.Count; iROw++)
                {
                    dtbTemp.LoadDataRow(dtbEnd.Rows[iROw].ItemArray, true);
                }
                dtbTemp.EndLoadData();

                dtbValue.Merge(dtbTemp, true);

                if (!string.IsNullOrEmpty(p_strLastAccountID))
                {
                    strSQL = @"select t.seriesid_int,
       t.medicinetypeid_chr,
       t.storageid_chr,
       t.amount_int,
       t.type_int,
       t.accountid_chr,
       t.callprice_int,
       t.wholesaleprice_int,
       t.retailprice_int,
       t.newretailprice_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       b.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset b
 where t.storageid_chr = ?
and t.accountid_chr = ?
   and t.isend_int = 1
   and t.state_int = 1
   and t.medicinetypeid_chr = b.medicinetypeid_chr
 order by b.medicinetypesetid";

                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;
                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (dtbBegin == null || dtbBegin.Rows.Count == 0)
                    {
                        return -1;
                    }

                    dtbValue.Merge(dtbBegin, true);
                }

                DataView drValue = new DataView(dtbValue);
                drValue.Sort = "medicinetypeid_chr";

                System.Collections.ArrayList arrAcc = new System.Collections.ArrayList();
                int intRowsCount = drValue.Count;
               
                int intProcessType = 0;//操作类型
                DataRowView drCurrent = null;
                clsMS_TotalAccountVO objCurrent = null;
                int intIsEnd = 0;

                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;

                //调价零价金额
                double douCheckRetailMoney = 0;

                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = drValue[iRow];
                    if (iRow == 0)
                    {
                        
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        arrAcc.Add(objCurrent);
                    }
                    else if (drCurrent["medicinetypesetname"].ToString() != drValue[iRow - 1]["medicinetypesetname"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        arrAcc.Add(objCurrent);
                    }

                    //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                    if ((iRow == drValue.Count - 1) || (iRow < drValue.Count - 1 && drCurrent["medicinetypesetname"].ToString() != drValue[iRow + 1]["medicinetypesetname"].ToString()))
                    {
                        if (douWholesaleMoney > 0)
                        {
                            objCurrent.m_dblInCallMoney += douCallMoney;
                            objCurrent.m_dblInRetailMoney += douRetailMoney;
                            objCurrent.m_dblInWholesaleMoney += douWholesaleMoney;
                        }
                        else
                        {
                            objCurrent.m_dblOutCallMoney += douCallMoney;
                            objCurrent.m_dblOutRetailMoney += douRetailMoney;
                            objCurrent.m_dblOutWholesaleMoney += douWholesaleMoney;
                        }

                        douCallMoney = 0;
                        douRetailMoney = 0;
                        douWholesaleMoney = 0;

                        if (douCheckRetailMoney > 0)
                        {
                            objCurrent.m_dblInRetailMoney += douCheckRetailMoney;
                        }
                        else
                        {
                            objCurrent.m_dblOutRetailMoney += douCheckRetailMoney;
                        }
                        douCheckRetailMoney = 0;
                    }

                    intIsEnd = Convert.ToInt32(drCurrent["isend_int"]);
                    if (intIsEnd == 1)
                    {
                        //上期期末为本期期初

                        if (!string.IsNullOrEmpty(p_strLastAccountID) && drCurrent["isthis"].ToString() == "0")
                        {
                            objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if (drCurrent["isthis"].ToString() == "1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                    }

                    intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                    //单据号(第九位数字分别表示:1,入库2,出库3,外退4,内退5,损耗6,盘点7期初数,8调价)
                    switch (intProcessType)
                    {
                        case 1:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            //累加盘点金额
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                douCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                douCallMoney -= Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney -= Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney -= Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 8:
                            
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objAccount = arrAcc.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
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
