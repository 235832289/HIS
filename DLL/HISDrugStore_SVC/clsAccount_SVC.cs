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
    /// 药房帐务期结转
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAccount_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {        
    
        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate, string[] p_strChittyIDArr, string p_strStorageID)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_instorage a set a.inaccount_dat=? ,a.inaccounterid_chr=?  where a.indrugstoreid_vchr=?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                object[][] objValues = new object[3][];

                int intItemCount = p_strChittyIDArr.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_dtmAccountDate;
                    objValues[1][iRow] = p_strEmpID;
                    objValues[2][iRow] = p_strChittyIDArr[iRow];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                if (lngRes < 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
                }
                strSQL = @"update t_ds_outstorage a set a.inaccount_dat=? ,a.inaccounterid_chr=?  where a.outdrugstoreid_vchr=?";
                dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                objValues = new object[3][];


                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_dtmAccountDate;
                    objValues[1][iRow] = p_strEmpID;
                    objValues[2][iRow] = p_strChittyIDArr[iRow];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                if (lngRes < 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
                }
                strSQL = @"update t_ds_drugstorecheck a set a.inaccountdate_dat=? ,a.inaccountid_chr=?  where a.checkid_chr=?";
                dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                objValues = new object[3][];


                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_dtmAccountDate;
                    objValues[1][iRow] = p_strEmpID;
                    objValues[2][iRow] = p_strChittyIDArr[iRow];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                if (lngRes < 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
                }

                strSQL = @"update t_ds_adjustprice a set a.inaccountdate_dat=? ,a.inaccountid_chr=?  where a.adjustpriceid_vchr=?";
                dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                objValues = new object[3][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_dtmAccountDate;
                    objValues[1][iRow] = p_strEmpID;
                    objValues[2][iRow] = p_strChittyIDArr[iRow];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                if (lngRes < 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
                }

                strSQL = @"update t_ds_initial a set a.inaccounterid_chr=?  where a.initialid_chr=?";
                dbTypes = new DbType[] { DbType.String, DbType.String };

                objValues = new object[2][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {

                    objValues[0][iRow] = p_strEmpID;
                    objValues[1][iRow] = p_strChittyIDArr[iRow];
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                if (lngRes < 0)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception();
                }

                strSQL = @"update t_ds_account_detail a
   set a.state_int = 1, a.inaccountdate_dat = ?, a.inaccountid_chr = ?
 where a.chittyid_vchr = ?";
                dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String };

                objValues = new object[3][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }
                for (int iRow = 0; iRow < intItemCount; iRow++)
                {
                    objValues[0][iRow] = p_dtmAccountDate;
                    objValues[1][iRow] = p_strEmpID;
                    objValues[2][iRow] = p_strChittyIDArr[iRow];
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
            return lngRes;
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
        /// <param name="m_intTransferMode">0-库存模式；1-盘点模式</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveAccount(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_AccountPeriodVO p_objAccPe, clsDS_Account p_objAccount, long[] p_lngMedSEQ, string p_strEmpID, out string p_strAccountID, out long p_lngMainSEQ, out long p_lngSubSEQ,int m_intTransferMode,long m_lngCheckSeqid)
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

                lngRes = m_lngSaveToAccountDetail(p_objPrincipal, p_strEmpID, p_objAccPe.m_dtmTRANSFERTIME_DAT, p_strAccountID, p_objAccount.m_strDrugStoreid,m_intTransferMode,m_lngCheckSeqid);
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
        public long m_lngAddAccountPeriod(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_AccountPeriodVO p_objAccPeVO, out long p_lngMainSEQ, out string p_strAccoutID)
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
                string strSQL = @"insert into t_ds_accountperiod t
  (t.seriesid_int,
   t.accountid_chr,
   t.starttime_dat,
   t.endtime_dat,
   t.transfertime_dat,
   t.comment_vchr,
   t.drugstoreid_chr)
values
  (?, ?, ?, ?, ?, ?, ?)";
                
                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                clsAccount_Supported_SVC objSelect = new clsAccount_Supported_SVC();
                IDataParameter[] objLisAddItemRefArr = null;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_ACCOUNTPERIOD", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_lngMainSEQ = lngSEQ;
                lngRes = objSelect.m_lngGetLatestAccountID(p_objPrincipal, p_objAccPeVO.m_strDrugStoreid, out p_strAccoutID);
                if (lngRes <= 0 || string.IsNullOrEmpty(p_strAccoutID))
                {
                    return -1;
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
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
                objLisAddItemRefArr[6].Value = p_objAccPeVO.m_strDrugStoreid;
                long lngRecEff = -1;
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
        
        #region 新增总帐表

        /// <summary>
        /// 新增总帐表

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <param name="p_lngSEQ">总帐表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAccount(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Account p_objRecord, out long p_lngSEQ)
        {
            p_lngSEQ = 0;
            if (p_objRecord == null)
            {
                return -1;
            }
            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ds_account
  (seriesid_int,
   accountid_chr,
   drugstoreid_chr,
   comment_vchr,
   beginretailfigure_int,
   instorageretailfigure_int,
   outstorageretailfigure_int,
   reciperetailfigure_int,
   putmedretailfigure_int,
   checkretailfigure_int,
   adjustretailfigure_int,
   endretailfigure_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long lngEff = -1;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_DS_ACCOUNT", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_lngSEQ = lngSEQ;

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPServ.CreateDatabaseParameter(12, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strACCOUNTID;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strDrugStoreid;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strCOMMENT_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_dblBEGINRETAILFIGURE_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_dblINSTORAGERETAILFIGURE_INT;
                objLisAddItemRefArr[6].Value = p_objRecord.m_dblOUTSTORAGERETAILFIGURE_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_dblRECIPERETAILFIGURE_INT;
                objLisAddItemRefArr[8].Value = p_objRecord.m_dblPutMedRetailFigure_INT;
                objLisAddItemRefArr[9].Value = p_objRecord.m_dblCHECKRETAILFIGURE_INT;
                objLisAddItemRefArr[10].Value = p_objRecord.m_dblADJUSTRETAILFIGURE_INT;
                objLisAddItemRefArr[11].Value = p_objRecord.m_dblENDRETAILFIGURE_INT;


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
        /// <summary>
        /// 保存至流水帐表

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="m_intTransferMode">0-库存模式；1-盘点模式</param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngSaveToAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmAccountDate, string p_strAccountID, string p_strStorageID,int m_intTransferMode,long m_lngCheckSeqid)
        {

            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                if (m_intTransferMode == 0)
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
         a.ipretailprice_int,
         a.opretailprice_int,
         a.instoragedate_dat,
         a.iprealgross_int,
         a.oprealgross_int,
         a.drugstoreid_chr,
         a.iprealgross_int,
         a.oprealgross_int,
         3,
         a.iprealgross_int,
         a.oprealgross_int,
         a.ipwholesaleprice_int,
         a.opwholesaleprice_int,
         a.ipretailprice_int,
         a.opretailprice_int,
         a.dsinstoreid_vchr,
         0,
         1,
         ?,
         ?,
         ?,
         1,
         a.productorid_chr,
         a.validperiod_dat,
         sysdate,
         null,
         null,a.packqty_dec
    from t_ds_storage_detail a
   inner join t_bse_medicine d on a.medicineid_chr = d.medicineid_chr
   where a.status = 1
     and a.drugstoreid_chr = ?";
                                        
                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    IDataParameter[] objLisAddItemRefArr = null;
                    objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = p_strEmpID;
                    objLisAddItemRefArr[1].DbType = DbType.DateTime;
                    objLisAddItemRefArr[1].Value = p_dtmAccountDate;
                    objLisAddItemRefArr[2].Value = p_strAccountID;                    
                    objLisAddItemRefArr[3].Value = p_strStorageID;

                    long lngEff = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                }
                else
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
         b.drugstoreid_chr,
         a.medicineid_chr,
         a.medicinename_vchr,
         d.medicinetypeid_chr,
         a.medspec_vchr,
         d.opunit_chr,
         d.ipunit_chr,
         a.indrugstoreid_vchr,
         a.lotno_vchr,
         a.ipcallprice_int ,
         a.opcallprice_int ,
         a.ipretailprice_int ,
         a.opretailprice_int ,
         a.dsinstoragedate_dat,
         a.ipcheckgross_int + a.opcheckgross_int * a.packqty_dec,
         a.opcheckgross_int + round(a.ipcheckgross_int / a.packqty_dec, 2),
         b.drugstoreid_chr,
         a.ipcheckgross_int + a.opcheckgross_int * a.packqty_dec,
         a.opcheckgross_int + round(a.ipcheckgross_int / a.packqty_dec, 2),
         0,
         a.ipcheckgross_int + a.opcheckgross_int * a.packqty_dec,
         a.opcheckgross_int + round(a.ipcheckgross_int / a.packqty_dec, 2),
         a.ipcallprice_int,
         a.opcallprice_int,
         a.ipretailprice_int,
         a.opretailprice_int,
         b.checkid_chr,
         0,
         1,
         ?,
         ?,
         ?,
         1,
         a.productorid_chr,
         a.validperiod_dat,
         sysdate,
         null,
         null,a.packqty_dec
    from t_ds_drugstorecheck_detail a 
    inner join t_ds_drugstorecheck b on a.seriesid2_int=b.seriesid_int
   inner join t_bse_medicine d on a.medicineid_chr = d.medicineid_chr
   where a.status_int = 1 and a.seriesid2_int=?";
                                        
                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    IDataParameter[] objLisAddItemRefArr = null;
                    objHRPServ.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = p_strEmpID;
                    objLisAddItemRefArr[1].DbType = DbType.DateTime;
                    objLisAddItemRefArr[1].Value = p_dtmAccountDate;
                    objLisAddItemRefArr[2].Value = p_strAccountID;                    
                    objLisAddItemRefArr[3].Value = m_lngCheckSeqid;

                    long lngEff = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
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
    }
}
