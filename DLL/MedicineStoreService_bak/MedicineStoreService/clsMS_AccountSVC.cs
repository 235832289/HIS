using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.security;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品进出明细统计报表（按时间段查询）
    /// </summary>
    public class clsMS_TotalAccountVO_rq : clsMS_TotalAccountVO
    {
        private string m_strmedicinempec;
        /// <summary>
        /// 规格
        /// </summary>
        public string m_strMedicineSpec
        {
            get
            {
                return m_strmedicinempec;
            }
            set
            {
                m_strmedicinempec = value;
            }
        }
    }

    /// <summary>
    /// 账本
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMS_AccountSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 新增账本明细
        /// <summary>
        /// 新增账本明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAccountDetailArr">账本明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_AccountDetail_VO[] p_objAccountDetailArr)
        {
            if (p_objAccountDetailArr == null || p_objAccountDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_account_detail
  (seriesid_int,
   storageid_chr,
   medicineid_chr,
   medicinename_vch,
   medicinetypeid_chr,
   medspec_vchr,
   opunit_chr,
   instorageid_vchr,
   lotno_vchr,
   callprice_int,
   wholesaleprice_int,
   retailprice_int,
   amount_int,
   deptid_chr,
   type_int,
   oldgross_int,
   endamount_int,
   endcallprice_int,
   endwholesaleprice_int,
   endretailprice_int,
   chittyid_vchr,
   formtype_int,
   state_int,
   inaccountid_chr,
   inaccountdate_dat,
   accountid_chr,
   isend_int,
   newretailprice_int,
   operatedate_dat,
   validperiod_dat,
   typecode_vchr,producedate_dat)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
   ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 
   ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_ACCOUNT_DETAIL", p_objAccountDetailArr.Length, out lngSEQArr);
                
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objAccountDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(32, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = lngSEQArr[iRow];
                        objLisAddItemRefArr[1].Value = p_objAccountDetailArr[iRow].m_strSTORAGEID_CHR;
                        objLisAddItemRefArr[2].Value = p_objAccountDetailArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[3].Value = p_objAccountDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[4].Value = p_objAccountDetailArr[iRow].m_strMEDICINETYPEID_CHR;
                        objLisAddItemRefArr[5].Value = p_objAccountDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[6].Value = p_objAccountDetailArr[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[7].Value = p_objAccountDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[8].Value = p_objAccountDetailArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[9].Value = p_objAccountDetailArr[iRow].m_dblCALLPRICE_INT;
                        objLisAddItemRefArr[10].Value = p_objAccountDetailArr[iRow].m_dblWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[11].Value = p_objAccountDetailArr[iRow].m_dblRETAILPRICE_INT;
                        objLisAddItemRefArr[12].Value = p_objAccountDetailArr[iRow].m_dblAMOUNT_INT;
                        objLisAddItemRefArr[13].Value = p_objAccountDetailArr[iRow].m_strDEPTID_CHR;
                        objLisAddItemRefArr[14].Value = p_objAccountDetailArr[iRow].m_intTYPE_INT;
                        objLisAddItemRefArr[15].Value = p_objAccountDetailArr[iRow].m_dblOLDGROSS_INT;
                        objLisAddItemRefArr[16].Value = p_objAccountDetailArr[iRow].m_dblENDAMOUNT_INT;
                        objLisAddItemRefArr[17].Value = p_objAccountDetailArr[iRow].m_dblENDCALLPRICE_INT;
                        objLisAddItemRefArr[18].Value = p_objAccountDetailArr[iRow].m_dblENDWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[19].Value = p_objAccountDetailArr[iRow].m_dblENDRETAILPRICE_INT;
                        objLisAddItemRefArr[20].Value = p_objAccountDetailArr[iRow].m_strCHITTYID_VCHR;
                        objLisAddItemRefArr[21].Value = p_objAccountDetailArr[iRow].m_intFORMTYPE_INT;
                        objLisAddItemRefArr[22].Value = p_objAccountDetailArr[iRow].m_intSTATE_INT;
                        objLisAddItemRefArr[23].Value = p_objAccountDetailArr[iRow].m_strINACCOUNTID_CHR;
                        if (p_objAccountDetailArr[iRow].m_dtmINACCOUNTDATE_DAT != DateTime.MinValue)
                        {
                            objLisAddItemRefArr[24].DbType = DbType.DateTime;
                            objLisAddItemRefArr[24].Value = p_objAccountDetailArr[iRow].m_dtmINACCOUNTDATE_DAT;
                        }
                        else
                        {
                            objLisAddItemRefArr[24].Value = DBNull.Value;
                        }
                        objLisAddItemRefArr[25].Value = p_objAccountDetailArr[iRow].m_strACCOUNTID_CHR;
                        objLisAddItemRefArr[26].Value = p_objAccountDetailArr[iRow].m_intISEND_INT;
                        if (p_objAccountDetailArr[iRow].m_dblNewRetailPrice < 0)
                        {
                            objLisAddItemRefArr[27].Value = DBNull.Value;
                        }
                        else
                        {
                            objLisAddItemRefArr[27].Value = p_objAccountDetailArr[iRow].m_dblNewRetailPrice;
                        }
                        objLisAddItemRefArr[28].DbType = DbType.DateTime;
                        objLisAddItemRefArr[28].Value = p_objAccountDetailArr[iRow].m_dtmOperateDate;
                        objLisAddItemRefArr[29].DbType = DbType.DateTime;
                        objLisAddItemRefArr[29].Value = p_objAccountDetailArr[iRow].m_dtmValidDate;
                        objLisAddItemRefArr[30].Value = p_objAccountDetailArr[iRow].m_strTYPECODE_CHR;
                        objLisAddItemRefArr[31].Value = p_objAccountDetailArr[iRow].m_dtmPRODUCEDATE_DAT;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Int32,DbType.Double,DbType.Double,DbType.Double,
                        DbType.Double,DbType.Double,DbType.String,DbType.Int32,DbType.Int32,DbType.String,DbType.DateTime,DbType.String,DbType.String,DbType.Double,
                        DbType.DateTime,DbType.DateTime,DbType.String,DbType.DateTime};

                    object[][] objValues = new object[32][];

                    int intItemCount = p_objAccountDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objAccountDetailArr[iRow].m_strSTORAGEID_CHR;
                        objValues[2][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINETYPEID_CHR;
                        objValues[5][iRow] = p_objAccountDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[6][iRow] = p_objAccountDetailArr[iRow].m_strOPUNIT_CHR;
                        objValues[7][iRow] = p_objAccountDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[8][iRow] = p_objAccountDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[9][iRow] = p_objAccountDetailArr[iRow].m_dblCALLPRICE_INT;
                        objValues[10][iRow] = p_objAccountDetailArr[iRow].m_dblWHOLESALEPRICE_INT;
                        objValues[11][iRow] = p_objAccountDetailArr[iRow].m_dblRETAILPRICE_INT;
                        objValues[12][iRow] = p_objAccountDetailArr[iRow].m_dblAMOUNT_INT;
                        objValues[13][iRow] = p_objAccountDetailArr[iRow].m_strDEPTID_CHR;
                        objValues[14][iRow] = p_objAccountDetailArr[iRow].m_intTYPE_INT;
                        objValues[15][iRow] = p_objAccountDetailArr[iRow].m_dblOLDGROSS_INT;
                        objValues[16][iRow] = p_objAccountDetailArr[iRow].m_dblENDAMOUNT_INT;
                        objValues[17][iRow] = p_objAccountDetailArr[iRow].m_dblENDCALLPRICE_INT;
                        objValues[18][iRow] = p_objAccountDetailArr[iRow].m_dblENDWHOLESALEPRICE_INT;
                        objValues[19][iRow] = p_objAccountDetailArr[iRow].m_dblENDRETAILPRICE_INT;
                        objValues[20][iRow] = p_objAccountDetailArr[iRow].m_strCHITTYID_VCHR;
                        objValues[21][iRow] = p_objAccountDetailArr[iRow].m_intFORMTYPE_INT;
                        objValues[22][iRow] = p_objAccountDetailArr[iRow].m_intSTATE_INT;
                        objValues[23][iRow] = p_objAccountDetailArr[iRow].m_strINACCOUNTID_CHR;
                        if (p_objAccountDetailArr[iRow].m_dtmINACCOUNTDATE_DAT != DateTime.MinValue)
                        {
                            objValues[24][iRow] = p_objAccountDetailArr[iRow].m_dtmINACCOUNTDATE_DAT;
                        }
                        else
                        {
                            objValues[24][iRow] = DBNull.Value;
                        }
                        objValues[25][iRow] = p_objAccountDetailArr[iRow].m_strACCOUNTID_CHR;
                        objValues[26][iRow] = p_objAccountDetailArr[iRow].m_intISEND_INT;
                        if (p_objAccountDetailArr[iRow].m_dblNewRetailPrice < 0)
                        {
                            objValues[27][iRow] = DBNull.Value;
                        }
                        else
                        {
                            objValues[27][iRow] = p_objAccountDetailArr[iRow].m_dblNewRetailPrice;
                        }
                        objValues[28][iRow] = p_objAccountDetailArr[iRow].m_dtmOperateDate;
                        objValues[29][iRow] = p_objAccountDetailArr[iRow].m_dtmValidDate;
                        objValues[30][iRow] = p_objAccountDetailArr[iRow].m_strTYPECODE_CHR;
                        objValues[31][iRow] = p_objAccountDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
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

        #region 设置帐本明细为无效
        /// <summary>
        /// 设置帐本明细为无效        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, string p_strChittyID, string p_strStorageID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strChittyID;
                objDPArr[1].Value = p_strStorageID;

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
        /// 设置帐本明细为无效        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyID, string p_strStorageID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_strChittyID.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strChittyID[i];
                        objDPArr[1].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_strChittyID.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strChittyID[iRow];
                        objValues[1][iRow] = p_strStorageID;
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
        /// 设置账本明细为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, string p_strChittyID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValidDate, double p_dblInPrice)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?
   and t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.instorageid_vchr = ?
   and t.callprice_int = ?
   and t.validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                objDPArr[0].Value = p_strChittyID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strMedicineID;
                objDPArr[3].Value = p_strLotNO;
                objDPArr[4].Value = p_strInStorageID;
                objDPArr[5].Value = p_dblInPrice;
                objDPArr[6].DbType = DbType.DateTime;
                objDPArr[6].Value = p_dtmValidDate;

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
        /// 设置帐本明细为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineArr">帐本药品</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_AccountMedicine_VO[] p_objMedicineArr)
        {
            if (p_objMedicineArr == null || p_objMedicineArr.Length ==0 )
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?
   and t.medicineid_chr = ?
   and t.lotno_vchr = ?
   and t.instorageid_vchr = ?
   and t.callprice_int = ?
   and t.validperiod_dat = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_objMedicineArr.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(7, out objDPArr);
                        objDPArr[0].Value = p_objMedicineArr[i].m_strChittyID;
                        objDPArr[1].Value = p_objMedicineArr[i].m_strStorageID;
                        objDPArr[2].Value = p_objMedicineArr[i].m_strMedicineID;
                        objDPArr[3].Value = p_objMedicineArr[i].m_strLotNO;
                        objDPArr[4].Value = p_objMedicineArr[i].m_strInStorageID;
                        objDPArr[5].Value = p_objMedicineArr[i].m_dblInPrice;
                        objDPArr[6].DbType = DbType.DateTime;
                        objDPArr[6].Value = p_objMedicineArr[i].m_dtmValidDate;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime };

                    object[][] objValues = new object[7][];

                    int intItemCount = p_objMedicineArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objMedicineArr[iRow].m_strChittyID;
                        objValues[1][iRow] = p_objMedicineArr[iRow].m_strStorageID;
                        objValues[2][iRow] = p_objMedicineArr[iRow].m_strMedicineID;
                        objValues[3][iRow] = p_objMedicineArr[iRow].m_strLotNO;
                        objValues[4][iRow] = p_objMedicineArr[iRow].m_strInStorageID;
                        objValues[5][iRow] = p_objMedicineArr[iRow].m_dblInPrice;
                        objValues[6][iRow] = p_objMedicineArr[iRow].m_dtmValidDate;
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
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = ?
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?
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
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 确认入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRatifyAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyIDArr, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = ?
 where t.chittyid_vchr = ?
   and t.storageid_chr = ?
   and t.state_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_strChittyIDArr.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = p_dtmAccountDate;
                        objDPArr[2].Value = p_strChittyIDArr[i];
                        objDPArr[3].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }                    
                }
                else
                {
                    DbType[] dbTypes = new DbType[] {DbType.String,DbType.DateTime,DbType.String,DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_strChittyIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_strChittyIDArr[iRow];
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
        #endregion

        #region 通过序列号确认入帐
        /// <summary>
        /// 通过序列号确认入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRatifyAccountDetailBySeriesID(System.Security.Principal.IPrincipal p_objPrincipal, Int64[] p_intSeriesIDArr, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            if (p_intSeriesIDArr == null || p_intSeriesIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = ?
 where t.seriesid_int = ? and t.state_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_intSeriesIDArr.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = p_dtmAccountDate;
                        objDPArr[2].Value = p_intSeriesIDArr[i];                        

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }                    
                }
                else
                {
                    DbType[] dbTypes = new DbType[] {DbType.String,DbType.DateTime,DbType.Int64};

                    object[][] objValues = new object[3][];

                    int intItemCount = p_intSeriesIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_intSeriesIDArr[iRow];
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

        #region 获取所有药品帐表
        /// <summary>
        /// 获取所有药品帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">本期帐务开始时间</param>
        /// <param name="p_dtmEnd">本期帐务结束时间</param>
        /// <param name="p_lngEndFirstSEQ">本帐务期期末第一条SEQ</param>
        /// <param name="p_strLastAccountID">上一期帐务期ID(如IsNullOrEmpty则表示本次为第一期)</param>
        /// <param name="p_objMedicineDetail">总帐报表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccount_AllMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, long p_lngEndFirstSEQ, string p_strLastAccountID, out clsMS_DetailMedicineAccountVO[] p_objMedicineDetail)
        {
            p_objMedicineDetail = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.type_int,
       t.medicinename_vch
  from t_ms_account_detail t
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and t.seriesid_int < ?
   and t.state_int = 1
 order by t.medicineid_chr, t.operatedate_dat";

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

                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    return -1;
                }

                if (!string.IsNullOrEmpty(p_strLastAccountID))
                {
                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.chittyid_vchr,
       t.isend_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.medicineid_chr,
       t.type_int,
       t.medicinename_vch
  from t_ms_account_detail t
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
 order by t.medicineid_chr, t.operatedate_dat";

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

                DataView dtvValue = new DataView(dtbValue);
                dtvValue.Sort = "medicineid_chr";

                System.Collections.ArrayList arrAcc = new System.Collections.ArrayList();
                int intRowsCount = dtvValue.Count;
                int intProcessType = 0;//操作类型
                DataRowView drCurrent = null;
                clsMS_DetailMedicineAccountVO objCurrent = null;
                int intIsEnd = 0;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtvValue[iRow];

                    if (iRow == 0)
                    {
                        objCurrent = new clsMS_DetailMedicineAccountVO();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();
                        arrAcc.Add(objCurrent);
                    }
                    else if (drCurrent["medicineid_chr"].ToString() != dtvValue[iRow - 1]["medicineid_chr"].ToString())
                    {
                        objCurrent = new clsMS_DetailMedicineAccountVO();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();
                        arrAcc.Add(objCurrent);
                    }

                    intIsEnd = Convert.ToInt32(drCurrent["isend_int"]);

                    if (intIsEnd == 1)
                    {
                        //上期期末为本期期初
                        if (!string.IsNullOrEmpty(p_strLastAccountID))
                        {
                            objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
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
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            break;
                        case 6:
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            if (dblCheck < 0)
                            {
                                objCurrent.m_dblInRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            else
                            {
                                objCurrent.m_dblOutRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            break;
                    }
                }
                p_objMedicineDetail = arrAcc.ToArray(typeof(clsMS_DetailMedicineAccountVO)) as clsMS_DetailMedicineAccountVO[];
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

        #region 获取药品帐表
        /// <summary>
        /// 获取药品帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strLastAccountID">上期帐务期ID(如为空则本期为第一期)</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objValue">帐务内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTotalAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO p_objValue)
        {
            p_objValue = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t,t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.medicineid_chr = ?
   and t.operatedate_dat between ? and ?
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                DataRow drCurrent = null;
                int intRowsCount = 0;

                if (lngRes > 0 && dtbValue != null)
                {
                    intRowsCount = dtbValue.Rows.Count;

                    //if (intRowsCount == 0)
                    //{
                    //    return 0;
                    //}

                    p_objValue = new clsMS_TotalAccountVO();

                    //盘点各金额
                    double douCallMoney = 0;
                    double douRetailMoney = 0;
                    double douWholesaleMoney = 0;
                    double douInAmount = 0;
                    double douOutAmount = 0;
                    //调价零价金额
                    double douCheckRetailMoney = 0;
                    double douCheckAmount = 0;

                    int intProcessType = 0;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = dtbValue.Rows[iRow];
                        p_objValue.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        p_objValue.m_strMedicineName = drCurrent["medicinename_vch"].ToString();

                        intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                        switch (intProcessType)
                        {
                            case 1:
                                p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 2:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 3:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 4:
                                p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 5:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 6:
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
                                douInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 7:
                                if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                                {
                                    p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                break;
                            case 8:
                                double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                if (dblCheck < 0)
                                {
                                    douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                else
                                {
                                    douCheckRetailMoney -= dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                douCheckAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                        }
                        if (iRow == intRowsCount - 1)
                        {
                            if (douWholesaleMoney > 0)
                            {
                                p_objValue.m_dblInCallMoney += douCallMoney;
                                p_objValue.m_dblInRetailMoney += douRetailMoney;
                                p_objValue.m_dblInWholesaleMoney += douWholesaleMoney;
                                p_objValue.m_dblInAmount += douInAmount;
                            }
                            else
                            {
                                p_objValue.m_dblOutCallMoney += douCallMoney;
                                p_objValue.m_dblOutRetailMoney += douRetailMoney;
                                p_objValue.m_dblOutWholesaleMoney += douWholesaleMoney;
                                p_objValue.m_dblOutAmount += douOutAmount;
                            }

                            if (douCheckRetailMoney > 0)
                            {
                                p_objValue.m_dblInRetailMoney += douCheckRetailMoney;
                                p_objValue.m_dblInAmount += douCheckAmount;
                            }
                            else
                            {
                                p_objValue.m_dblOutRetailMoney += douCheckRetailMoney;
                                p_objValue.m_dblOutAmount += douCheckAmount;
                            }
                        }
                    }
                }

                strSQL = @"select t.callprice_int,
   t.retailprice_int,
   t.wholesaleprice_int,
   t.newretailprice_int,
   t.amount_int,
   t.endamount_int,
   t.endcallprice_int,
   t.endwholesaleprice_int,
   t.endretailprice_int,
   t.oldgross_int,
   t.chittyid_vchr,
   t.medicineid_chr,
   t.medicinename_vch,
   t.medicinetypeid_chr,
   t.type_int,
   s.medicinetypesetname
from t_ms_account_detail t, t_ms_medicinetypeset s
where t.storageid_chr = ?
and t.isend_int = 1
and t.accountid_chr = ?
and t.medicineid_chr = ?
and t.state_int = 1
and t.medicinetypeid_chr = s.medicinetypeid_chr";

                if (!string.IsNullOrEmpty(p_strLastAccountID))
                {
                    dtbValue = null;
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;
                    objDPArr[2].Value = p_strMedicineID;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                    if (lngRes > 0 && dtbValue != null)
                    {
                        if (p_objValue == null)
                        {
                            p_objValue = new clsMS_TotalAccountVO();
                        }
                        
                        intRowsCount = dtbValue.Rows.Count;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drCurrent = dtbValue.Rows[iRow];
                            p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        }
                    }
                }

                dtbValue = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;
                objDPArr[2].Value = p_strMedicineID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null)
                {
                    if (p_objValue == null)
                    {
                        p_objValue = new clsMS_TotalAccountVO();
                    }

                    intRowsCount = dtbValue.Rows.Count;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = dtbValue.Rows[iRow];
                        p_objValue.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objValue.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objValue.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objValue.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        } 
        #endregion

        #region 获取药品帐表 (未结转)
        /// <summary>
        /// 获取药品帐表 (未结转)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strLastAccountID">上期帐务期ID(如为空则本期为第一期)</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objValue">帐务内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTotalAccountNoAcc(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO p_objValue)
        {
            p_objValue = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t,t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.medicineid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2)
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;

                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objValue = new clsMS_TotalAccountVO();
                    DataRow drCurrent = null;
                    int intProcessType = 0;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = dtbValue.Rows[iRow];
                        p_objValue.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        p_objValue.m_strMedicineName = drCurrent["medicinename_vch"].ToString();

                        intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                        switch (intProcessType)
                        {
                            case 1:
                                p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 2:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 3:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 4:
                                p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 5:
                                p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                break;
                            case 6:
                                int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                                if (intType == 1)
                                {
                                    p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                else if (intType == 2)
                                {
                                    p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                break;
                            case 7:
                                if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                                {
                                    p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                break;
                            case 8:
                                double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                if (dblCheck < 0)
                                {
                                    p_objValue.m_dblInRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                else
                                {
                                    p_objValue.m_dblOutRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                }
                                break;
                        }
                    }

                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.isend_int = 1
   and t.accountid_chr = ?
   and t.medicineid_chr = ?
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

                    if (!string.IsNullOrEmpty(p_strLastAccountID))
                    {
                        dtbValue = null;
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strStorageID;
                        objDPArr[1].Value = p_strLastAccountID;
                        objDPArr[2].Value = p_strMedicineID;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue != null)
                        {
                            intRowsCount = dtbValue.Rows.Count;
                            for (int iRow = 0; iRow < intRowsCount; iRow++)
                            {
                                drCurrent = dtbValue.Rows[iRow];
                                p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                        }
                    }


                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.retailprice_int newretailprice_int,
       t.realgross_int amount_int,
       t.realgross_int endamount_int,
       t.callprice_int endcallprice_int,
       t.wholesaleprice_int endwholesaleprice_int,
       t.retailprice_int endretailprice_int,
       0 oldgross_int,
       t.instorageid_vchr chittyid_vchr,
       b.medicineid_chr,
       b.medicinename_vchr,
       c.medicinetypeid_chr,
       0 type_int,
       1 isend_int,
       c.medicinetypesetname,
       1 isthis
  from t_ms_storage_detail t, t_bse_medicine b, t_ms_medicinetypeset c
 where t.medicineid_chr = b.medicineid_chr
   and b.medicinetypeid_chr = c.medicinetypeid_chr
   and t.storageid_chr = ?
    and b.medicineid_chr =?
   and t.status = 1";
                    dtbValue = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineID;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                    if (lngRes > 0 && dtbValue != null)
                    {
                        intRowsCount = dtbValue.Rows.Count;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drCurrent = dtbValue.Rows[iRow];
                            p_objValue.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objValue.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objValue.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objValue.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 根据药品类型获取药品帐表
        /// <summary>
        /// 根据药品类型获取药品帐表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineTypeSetID">药品类型(大类)</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTypeAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineTypeSetID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineTypeSetID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and t.state_int = 1
   and t.isend_int = 0
   and t.medicinetypeid_chr = s.medicinetypeid_chr
   and s.medicinetypesetid = ?
 order by t.medicineid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineTypeSetID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes < 0 || dtbValue == null)
                {
                    return -1;
                }

                int intRowsCount = dtbValue.Rows.Count;
                if (intRowsCount == 0)
                {
                    return 0;
                }

                //本期期末
                strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
   and s.medicinetypesetid = ?
 order by t.medicineid_chr";

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAccountID;
                objDPArr[2].Value = p_strMedicineTypeSetID;

                DataTable dtbEnd = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbEnd, objDPArr);
                if (lngRes < 0 || dtbEnd == null)
                {
                    return -1;
                }
                dtbValue.Merge(dtbEnd, true);

                if (!string.IsNullOrEmpty(p_strLastAccountID))
                {
                    //上期期末，本期期初
                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
   and s.medicinetypesetid = ?
 order by t.medicineid_chr";

                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;
                    objDPArr[2].Value = p_strMedicineTypeSetID;

                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (lngRes < 0 || dtbBegin == null)
                    {
                        return -1;
                    }
                    dtbValue.Merge(dtbBegin, true);
                }

                DataView dtvValue = new DataView(dtbValue);
                dtvValue.Sort = "medicineid_chr";

                intRowsCount = dtvValue.Count;
                DataRowView drCurrent = null;
                int intProcessType = 0;//操作类型
                int intIsEnd = 0;//期末标志
                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;
                double dblPdAmount = 0;
                //调价零价金额
                double douCheckRetailMoney = 0;
                double dblTjAmount = 0;
                System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
                clsMS_TotalAccountVO objCurrent = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtvValue[iRow];
                    if (iRow == 0 || drCurrent["medicineid_chr"].ToString() != dtvValue[iRow - 1]["medicineid_chr"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();
                        objCurrent.m_dblInAmount += dblPdAmount;
                        arrAccount.Add(objCurrent);

                        //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                        if ((iRow == dtvValue.Count - 1) || (iRow < dtvValue.Count - 1))
                        {
                            if (douWholesaleMoney > 0)
                            {
                                objCurrent.m_dblInCallMoney += douCallMoney;
                                objCurrent.m_dblInRetailMoney += douRetailMoney;
                                objCurrent.m_dblInWholesaleMoney += douWholesaleMoney;
                                objCurrent.m_dblInAmount += dblPdAmount;
                            }
                            else
                            {
                                objCurrent.m_dblOutCallMoney += douCallMoney;
                                objCurrent.m_dblOutRetailMoney += douRetailMoney;
                                objCurrent.m_dblOutWholesaleMoney += douWholesaleMoney;
                                objCurrent.m_dblOutAmount += dblPdAmount;
                            }
                            douCallMoney = 0;
                            douRetailMoney = 0;
                            douWholesaleMoney = 0;
                            dblPdAmount = 0;

                            if (douCheckRetailMoney > 0)
                            {
                                objCurrent.m_dblInRetailMoney += douCheckRetailMoney;
                                objCurrent.m_dblInAmount += dblTjAmount;
                            }
                            else
                            {
                                objCurrent.m_dblOutRetailMoney += douCheckRetailMoney;
                                objCurrent.m_dblOutAmount += dblTjAmount;
                            }
                            douCheckRetailMoney = 0;
                            dblTjAmount = 0;
                        }
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
                            objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if (drCurrent["isthis"].ToString() == "1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
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
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            //累加盘点金额
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                douCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                douCallMoney -= Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney -= Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney -= Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount -= Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            dblTjAmount -= Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objValueArr = arrAccount.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        } 
        #endregion

        #region 根据药品类型获取药品帐表 (未结转)
        /// <summary>
        /// 根据药品类型获取药品帐表 (未结转)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineTypeSetID">药品类型(大类)</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTypeAccountNoAcc(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineTypeSetID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineTypeSetID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2) 
   and t.isend_int = 0
   and t.medicinetypeid_chr = s.medicinetypeid_chr
   and s.medicinetypesetid = ?
 order by t.medicineid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicineTypeSetID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes < 0 || dtbValue == null)
                {
                    return -1;
                }

                int intRowsCount = dtbValue.Rows.Count;
                if (intRowsCount == 0)
                {
                    return 0;
                }

                //本期期末
                strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.retailprice_int newretailprice_int,
       t.realgross_int amount_int,
       t.realgross_int endamount_int,
       t.callprice_int endcallprice_int,
       t.wholesaleprice_int endwholesaleprice_int,
       t.retailprice_int endretailprice_int,
       0 oldgross_int,
       t.instorageid_vchr chittyid_vchr,
       b.medicineid_chr,
       b.medicinename_vchr,
       c.medicinetypeid_chr,
       0 type_int,
       1 isend_int,
       c.medicinetypesetname,
       1 isthis
  from t_ms_storage_detail t, t_bse_medicine b, t_ms_medicinetypeset c
 where t.medicineid_chr = b.medicineid_chr
   and b.medicinetypeid_chr = c.medicinetypeid_chr
   and t.storageid_chr = ?
and c.medicinetypesetid = ?
   and t.status = 1";

                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineTypeSetID;

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
                    //上期期末，本期期初

                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
   and s.medicinetypesetid = ?
 order by t.medicineid_chr";

                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;
                    objDPArr[2].Value = p_strMedicineTypeSetID;

                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (lngRes < 0 || dtbBegin == null)
                    {
                        return -1;
                    }
                    dtbValue.Merge(dtbBegin, true);
                }

                DataView dtvValue = new DataView(dtbValue);
                dtvValue.Sort = "medicineid_chr";

                intRowsCount = dtvValue.Count;
                DataRowView drCurrent = null;
                int intProcessType = 0;//操作类型
                int intIsEnd = 0;//期末标志
                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;
                double dblPdAmount = 0;
                //调价零价金额
                double douCheckRetailMoney = 0;
                double dblTjAmount = 0;

                System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
                clsMS_TotalAccountVO objCurrent = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtvValue[iRow];
                    if (iRow == 0 || drCurrent["medicineid_chr"].ToString() != dtvValue[iRow - 1]["medicineid_chr"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();

                        arrAccount.Add(objCurrent);
                        //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                        if ((iRow == dtvValue.Count - 1) || (iRow < dtvValue.Count - 1))
                        {
                            if (douWholesaleMoney > 0)
                            {
                                objCurrent.m_dblInCallMoney += douCallMoney;
                                objCurrent.m_dblInRetailMoney += douRetailMoney;
                                objCurrent.m_dblInWholesaleMoney += douWholesaleMoney;
                                objCurrent.m_dblInAmount += dblPdAmount;
                            }
                            else
                            {
                                objCurrent.m_dblOutCallMoney += douCallMoney;
                                objCurrent.m_dblOutRetailMoney += douRetailMoney;
                                objCurrent.m_dblOutWholesaleMoney += douWholesaleMoney;
                                objCurrent.m_dblOutAmount += dblPdAmount;
                            }
                            douCallMoney = 0;
                            douRetailMoney = 0;
                            douWholesaleMoney = 0;
                            dblPdAmount = 0;
                            if (douCheckRetailMoney > 0)
                            {
                                objCurrent.m_dblInRetailMoney += douCheckRetailMoney;
                                objCurrent.m_dblInAmount += dblTjAmount;
                            }
                            else
                            {
                                objCurrent.m_dblOutRetailMoney += douCheckRetailMoney;
                                objCurrent.m_dblOutAmount += dblTjAmount;
                            }
                            douCheckRetailMoney = 0;
                            dblTjAmount = 0;
                        }
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
                            objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if (drCurrent["isthis"].ToString() == "1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
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
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            //累加盘点金额
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                douCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                douCallMoney -= Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney -= Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney -= Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount -= Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            dblTjAmount -= Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objValueArr = arrAccount.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 获取指定帐务期所有药品明细
        /// <summary>
        /// 获取指定帐务期所有药品明细        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicineDetailAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2)
   and t.isend_int = 0
   and t.medicinetypeid_chr = s.medicinetypeid_chr
 order by s.medicinetypesetname,t.medicineid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes < 0 || dtbValue == null)
                {
                    return -1;
                }

               int intRowsCount = dtbValue.Rows.Count;
                //if (intRowsCount == 0)
                //{
                //    return 0;
                //}

                //本期期末
                strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
 order by s.medicinetypesetname,t.medicineid_chr";

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
                    //上期期末，本期期初
                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
 order by s.medicinetypesetname,t.medicineid_chr";

                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;

                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (lngRes < 0 || dtbBegin == null)
                    {
                        return -1;
                    }
                    dtbValue.Merge(dtbBegin, true);
                }

                DataView dtvValue = new DataView(dtbValue);
                dtvValue.Sort = "medicineid_chr";

                intRowsCount = dtvValue.Count;
                DataRowView drCurrent = null;
                int intProcessType = 0;//操作类型
                int intIsEnd = 0;//期末标志

                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;
                //调价零价金额
                double douCheckRetailMoney = 0;

                System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
                clsMS_TotalAccountVO objCurrent = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtvValue[iRow];
                    if (iRow == 0 || drCurrent["medicineid_chr"].ToString() != dtvValue[iRow - 1]["medicineid_chr"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();

                        arrAccount.Add(objCurrent);
                    }

                    //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                    if ((iRow == dtvValue.Count - 1) || (iRow < dtvValue.Count - 1 && drCurrent["medicinetypesetname"].ToString() != dtvValue[iRow + 1]["medicinetypesetname"].ToString()))
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
                            objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if (drCurrent["isthis"].ToString() == "1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
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
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
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
                                objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objValueArr = arrAccount.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 获取指定帐务期所有药品明细 (未结转)
        /// <summary>
        /// 获取指定帐务期所有药品明细 (未结转)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicineDetailAccountNoAcc(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strAccountID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       1 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2)
   and t.isend_int = 0
   and t.medicinetypeid_chr = s.medicinetypeid_chr
 order by s.medicinetypesetname,t.medicineid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes < 0 || dtbValue == null)
                {
                    return -1;
                }

                int intRowsCount = dtbValue.Rows.Count;
                //if (intRowsCount == 0)
                //{
                //    return 0;
                //}

                //本期期末
                strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.retailprice_int newretailprice_int,
       t.realgross_int amount_int,
       t.realgross_int endamount_int,
       t.callprice_int endcallprice_int,
       t.wholesaleprice_int endwholesaleprice_int,
       t.retailprice_int endretailprice_int,
       0 oldgross_int,
       t.instorageid_vchr chittyid_vchr,
       b.medicineid_chr,
       b.medicinename_vchr,
       c.medicinetypeid_chr,
       0 type_int,
       1 isend_int,
       c.medicinetypesetname,
       1 isthis
  from t_ms_storage_detail t, t_bse_medicine b, t_ms_medicinetypeset c
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
                    //上期期末，本期期初

                    strSQL = @"select t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       t.isend_int,
       s.medicinetypesetname,
       0 isthis
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.accountid_chr = ?
   and t.state_int = 1
   and t.isend_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr
 order by s.medicinetypesetname,t.medicineid_chr";

                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strLastAccountID;

                    DataTable dtbBegin = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbBegin, objDPArr);
                    if (lngRes < 0 || dtbBegin == null)
                    {
                        return -1;
                    }
                    dtbValue.Merge(dtbBegin, true);
                }

                DataView dtvValue = new DataView(dtbValue);
                dtvValue.Sort = "medicineid_chr";

                intRowsCount = dtvValue.Count;
                DataRowView drCurrent = null;
                int intProcessType = 0;//操作类型
                int intIsEnd = 0;//期末标志

                //盘点各金额
                double douCallMoney = 0;
                double douRetailMoney = 0;
                double douWholesaleMoney = 0;
                double dblPdAmount = 0;

                //调价零价金额
                double douCheckRetailMoney = 0;
                double dblTjAmount = 0;
                System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
                clsMS_TotalAccountVO objCurrent = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = dtvValue[iRow];
                    if (iRow == 0 || drCurrent["medicineid_chr"].ToString() != dtvValue[iRow - 1]["medicineid_chr"].ToString())
                    {
                        objCurrent = new clsMS_TotalAccountVO();
                        objCurrent.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                        objCurrent.m_strMedicineName = drCurrent["medicinename_vch"].ToString();

                        arrAccount.Add(objCurrent);
                    }

                    //当盘点金额为正时加到本期收入金额中,为负数时加到本期调拔金额中
                    if ((iRow == dtvValue.Count - 1) || (iRow < dtvValue.Count - 1 && drCurrent["medicinetypesetname"].ToString() != dtvValue[iRow + 1]["medicinetypesetname"].ToString()))
                    {
                        if (douWholesaleMoney > 0)
                        {
                            objCurrent.m_dblInCallMoney += douCallMoney;
                            objCurrent.m_dblInRetailMoney += douRetailMoney;
                            objCurrent.m_dblInWholesaleMoney += douWholesaleMoney;
                            objCurrent.m_dblInAmount += dblPdAmount;
                        }
                        else
                        {
                            objCurrent.m_dblOutCallMoney += douCallMoney;
                            objCurrent.m_dblOutRetailMoney += douRetailMoney;
                            objCurrent.m_dblOutWholesaleMoney += douWholesaleMoney;
                            objCurrent.m_dblOutAmount += dblPdAmount;
                        }

                        douCallMoney = 0;
                        douRetailMoney = 0;
                        douWholesaleMoney = 0;
                        dblPdAmount = 0;

                        if (douCheckRetailMoney > 0)
                        {
                            objCurrent.m_dblInRetailMoney += douCheckRetailMoney;
                            objCurrent.m_dblInAmount += dblTjAmount;
                        }
                        else
                        {
                            objCurrent.m_dblOutRetailMoney += douCheckRetailMoney;
                            objCurrent.m_dblOutAmount += dblTjAmount;
                            
                        }
                        douCheckRetailMoney = 0;
                        dblTjAmount = 0;
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
                            objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                        else if (drCurrent["isthis"].ToString() == "1")//本期期末
                        {
                            objCurrent.m_dblEndCallMoney += Math.Round(Convert.ToDouble(drCurrent["endcallprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndRetailMoney += Math.Round(Convert.ToDouble(drCurrent["endretailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["endwholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            objCurrent.m_dblEndAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            continue;
                        }
                    }

                    intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                    switch (intProcessType)
                    {//单据号(第九位数字分别表示:1,入库2,出库3,外退4,内退5,损耗6,盘点7期初数,8调价)
                        case 1:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            objCurrent.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            objCurrent.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            objCurrent.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            //累加盘点金额
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                douCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                douCallMoney -= Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douRetailMoney -= Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                douWholesaleMoney -= Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                dblPdAmount -= Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            if (string.IsNullOrEmpty(p_strLastAccountID))//上一期为空，则期初结存为期初数录入数据
                            {
                                objCurrent.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                objCurrent.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            douCheckRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            dblTjAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                    }
                }
                p_objValueArr = arrAccount.ToArray(typeof(clsMS_TotalAccountVO)) as clsMS_TotalAccountVO[];
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return -1;
            }
            return lngRes;
        }
        #endregion


        #region 按时间段获取药品帐表 (指定某种药品)
        /// <summary>
        /// 按时间段获取药品帐表 (指定某种药品)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strLastAccountID">上期帐务期ID(如为空则本期为第一期)</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objValue">帐务内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTotalAccountByTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO_rq p_objValue)
        {
            p_objValue = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t,t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.medicineid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2)
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicineID;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmBegin;
                objDPArr[3].DbType = DbType.DateTime;
                objDPArr[3].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;

                    if (intRowsCount != 0)
                    {
                        p_objValue = new clsMS_TotalAccountVO_rq();
                        DataRow drCurrent = null;
                        int intProcessType = 0;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drCurrent = dtbValue.Rows[iRow];
                            p_objValue.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                            p_objValue.m_strMedicineName = drCurrent["medicinename_vch"].ToString();
                            p_objValue.m_strMedicineSpec = drCurrent["medspec_vchr"].ToString();

                            intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                            switch (intProcessType)
                            {
                                case 1:
                                    p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    break;
                                case 2:
                                    p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    break;
                                case 3:
                                    p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    break;
                                case 4:
                                    p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    break;
                                case 5:
                                    p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    break;
                                case 6:
                                    int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                                    if (intType == 1)
                                    {
                                        p_objValue.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    }
                                    else if (intType == 2)
                                    {
                                        p_objValue.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    }
                                    break;
                                case 7:
                                    //在后面单独处理
                                    break;
                                case 8:
                                    double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                                    if (dblCheck < 0)
                                    {
                                        p_objValue.m_dblInRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    }
                                    else
                                    {
                                        p_objValue.m_dblOutRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                        p_objValue.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                    }
                                    break;
                            }
                        }

                        strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?   
   and t.medicineid_chr = ? 
   and substr(t.chittyid_vchr,9,1) = '7'
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";


                        dtbValue = null;
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strStorageID;
                        objDPArr[1].Value = p_strMedicineID;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue != null)
                        {
                            intRowsCount = dtbValue.Rows.Count;
                            for (int iRow = 0; iRow < intRowsCount; iRow++)
                            {
                                drCurrent = dtbValue.Rows[iRow];
                                p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);

                            }
                        }

                        strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       nvl(t.endamount_int,0) endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?   
   and t.medicineid_chr = ?
   and t.operatedate_dat < ? 
   and substr(t.chittyid_vchr,9,1) != '7'
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";


                        dtbValue = null;
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strStorageID;
                        objDPArr[1].Value = p_strMedicineID;
                        objDPArr[2].Value = p_dtmBegin;
                        objDPArr[2].DbType = DbType.DateTime;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue != null)
                        {
                            intRowsCount = dtbValue.Rows.Count;
                            for (int iRow = 0; iRow < intRowsCount; iRow++)
                            {
                                drCurrent = dtbValue.Rows[iRow];
                                //if (Convert.IsDBNull(drCurrent["endamount_int"]))
                                //    continue;
                                if (Convert.ToInt16(drCurrent["type_int"]) == 1)
                                {
                                    p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                }
                                else
                                {
                                    p_objValue.m_dblBeginCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                    p_objValue.m_dblBeginAmount += 0 - Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                }
                            }
                        }

                        p_objValue.m_dblEndAmount += (p_objValue.m_dblBeginAmount + p_objValue.m_dblInAmount - p_objValue.m_dblOutAmount);
                        if (p_objValue.m_dblEndAmount == 0)
                        {
                            p_objValue.m_dblEndCallMoney = 0;
                            p_objValue.m_dblEndRetailMoney = 0;
                            p_objValue.m_dblEndWholesaleMoney = 0;
                        }
                        else
                        {
                            p_objValue.m_dblEndCallMoney += (p_objValue.m_dblBeginCallMoney + p_objValue.m_dblInCallMoney + p_objValue.m_dblOutCallMoney);
                            p_objValue.m_dblEndRetailMoney += (p_objValue.m_dblBeginRetailMoney + p_objValue.m_dblInRetailMoney + p_objValue.m_dblOutRetailMoney);
                            p_objValue.m_dblEndWholesaleMoney += (p_objValue.m_dblBeginWholesaleMoney + p_objValue.m_dblInWholesaleMoney + p_objValue.m_dblOutWholesaleMoney);
                        }
                    }
                    else//没有出入库记录时，只有初始数据和结存数据且两者相等
                    {
                        p_objValue = new clsMS_TotalAccountVO_rq();
                        strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       t.endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?   
   and t.medicineid_chr = ? 
   and substr(t.chittyid_vchr,9,1) = '7'
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";


                        dtbValue = null;
                        intRowsCount = 0;
                        DataRow drCurrent = null;
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strStorageID;
                        objDPArr[1].Value = p_strMedicineID;

                        lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                        if (lngRes > 0 && dtbValue != null)
                        {
                            intRowsCount = dtbValue.Rows.Count;
                            for (int iRow = 0; iRow < intRowsCount; iRow++)
                            {
                                drCurrent = dtbValue.Rows[iRow];
                                p_objValue.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                                p_objValue.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);

                            }

                            p_objValue.m_dblEndAmount = p_objValue.m_dblBeginAmount;
                            p_objValue.m_dblEndCallMoney = p_objValue.m_dblBeginCallMoney;
                            p_objValue.m_dblEndRetailMoney = p_objValue.m_dblBeginRetailMoney;
                            p_objValue.m_dblEndWholesaleMoney = p_objValue.m_dblBeginWholesaleMoney;

                            clsMS_PublicSVC objPulic = new clsMS_PublicSVC();
                            string p_strMedName = string.Empty;
                            string p_strMedSpec = string.Empty;
                            objPulic.m_lngGetMedicineName(p_objPrincipal, p_strMedicineID, out p_strMedName);
                            objPulic.m_lngGetMedicineSpec(p_objPrincipal, p_strMedicineID, out p_strMedSpec);
                            p_objValue.m_strMedicineName = p_strMedName;
                            p_objValue.m_strMedicineSpec = p_strMedSpec;
                        }
                        
                    }
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 按时间段根据药品类型获取药品帐表 (指定某个类型)
        /// <summary>
        /// 按时间段根据药品类型获取药品帐表 (指定某个类型)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineTypeSetID">药品类型(大类)</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTypeAccountByTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineTypeSetID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO_rq[] p_objValueArr)
        {            
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strStorageID) || string.IsNullOrEmpty(p_strMedicineTypeSetID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                DataTable p_dtbMedicine = null;
                DataTable p_dtbValue = null;
                DataTable p_dtbInitialValue = null;
                DataTable p_dtbOutValue = null;
                ArrayList p_arrMedicine = new ArrayList();
                clsMS_TotalAccountVO_rq p_objMedicine = null;
                long lngTemp = 0;
                lngRes = m_lngGetMedicineData(p_objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, out p_dtbValue, out p_dtbInitialValue, out p_dtbOutValue);
                lngRes = m_lngGetMedicineByType(p_objPrincipal, p_strStorageID, p_strMedicineTypeSetID, out p_dtbMedicine);
                if (lngRes > 0 && p_dtbMedicine != null)
                {
                    if (p_dtbMedicine.Rows.Count > 0)
                    {
                        for(int intRow = 0;intRow < p_dtbMedicine.Rows.Count;intRow++)
                        {
                            lngTemp = m_lngGetMedicineDataDetail(p_objPrincipal,p_dtbMedicine.Rows[intRow][0].ToString(),p_dtbValue,p_dtbInitialValue,p_dtbOutValue,out p_objMedicine);
                            if (lngTemp > 0 && p_objMedicine != null)
                            {
                                if (p_objMedicine.m_dblBeginAmount == 0 && p_objMedicine.m_dblInAmount == 0 && p_objMedicine.m_dblOutAmount == 0 && p_objMedicine.m_dblEndAmount == 0)
                                    continue;
                                p_arrMedicine.Add(p_objMedicine);
                            }
                        }
                        p_objValueArr = p_arrMedicine.ToArray(typeof(clsMS_TotalAccountVO_rq)) as clsMS_TotalAccountVO_rq[];
                    }
                }
                return lngRes;
            }
            catch(Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
                return -1;
            }
        }

        /// <summary>
        /// 根据仓库、类型取得所有药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库号</param>
        /// <param name="p_strMedicineTypeSetID">类型号</param>
        /// <param name="p_dtbMedicine">所有药品</param>
        /// <returns></returns>
        private long m_lngGetMedicineByType(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineTypeSetID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;

            long lngRes = 0;
            try
            {
                string strSQL = string.Empty;
                if (p_strMedicineTypeSetID != "")
                {
                    strSQL = @"select distinct t.medicineid_chr
                              from t_ms_account_detail t, t_ms_medicinetypeset s
                            where t.storageid_chr = ?
                            and (t.state_int = 1 or t.state_int = 2)
                            and t.medicinetypeid_chr = s.medicinetypeid_chr
                            and s.medicinetypesetid = ?
                            order by t.medicineid_chr";
                }
                else
                {
                    strSQL = @"select distinct t.medicineid_chr
                              from t_ms_account_detail t
                            where t.storageid_chr = ?
                            and (t.state_int = 1 or t.state_int = 2)
                            order by t.medicineid_chr";
                }

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (p_strMedicineTypeSetID != "")
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_strMedicineTypeSetID;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;                    
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine,objDPArr);
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

        #region 按时间段获取药品帐表 (全部类型)
        /// <summary>
        /// 按时间段获取药品帐表 (全部类型)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllMedicineDetailAccountByTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO_rq[] p_objValueArr)
        {
            p_objValueArr = null;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                DataTable p_dtbMedicine = null;
                DataTable p_dtbValue = null;
                DataTable p_dtbInitialValue = null;
                DataTable p_dtbOutValue = null;
                ArrayList p_arrMedicine = new ArrayList();
                clsMS_TotalAccountVO_rq p_objMedicine = null;
                long lngTemp = 0;
                lngRes = m_lngGetMedicineData(p_objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, out p_dtbValue, out p_dtbInitialValue, out p_dtbOutValue);
                lngRes = m_lngGetMedicineByType(p_objPrincipal, p_strStorageID, "", out p_dtbMedicine);

                if (lngRes > 0 && p_dtbMedicine != null)
                {
                    if (p_dtbMedicine.Rows.Count > 0)
                    {
                        for (int intRow = 0; intRow < p_dtbMedicine.Rows.Count; intRow++)
                        {
                            lngTemp = m_lngGetMedicineDataDetail(p_objPrincipal, p_dtbMedicine.Rows[intRow][0].ToString(),p_dtbValue,p_dtbInitialValue,p_dtbOutValue, out p_objMedicine);
                            if (lngTemp > 0 && p_objMedicine != null)
                            {
                                if (p_objMedicine.m_dblBeginAmount == 0 && p_objMedicine.m_dblInAmount == 0 && p_objMedicine.m_dblOutAmount == 0 && p_objMedicine.m_dblEndAmount == 0)
                                    continue;
                                p_arrMedicine.Add(p_objMedicine);
                            }
                        }
                        p_objValueArr = p_arrMedicine.ToArray(typeof(clsMS_TotalAccountVO_rq)) as clsMS_TotalAccountVO_rq[];
                    }
                }
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
                return -1;
            }
        }

        /// <summary>
        /// 按照条件筛选药品数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtbValue">进出记录</param>
        /// <param name="p_dtbInitialValue">初始数据</param>
        /// <param name="p_dtbOutValue">出库数据</param>
        /// <param name="p_objMedicine"></param>
        /// <returns></returns>
        private long m_lngGetMedicineDataDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, DataTable p_dtbValue,
            DataTable p_dtbInitialValue,DataTable p_dtbOutValue,out clsMS_TotalAccountVO_rq p_objMedicine)
        {
            long lngRes = 0;
            int intRowsCount = 0;
            p_objMedicine = null;
            DataRow drCurrent = null;
            DataRow[] p_drValueFilterArr = p_dtbValue.Select(" medicineid_chr = '" + p_strMedicineID + "'");
            DataRow[] p_drInitialFilterArr = p_dtbInitialValue.Select(" medicineid_chr = '" + p_strMedicineID + "'");
            DataRow[] p_drOutFilterArr = p_dtbOutValue.Select(" medicineid_chr = '" + p_strMedicineID + "'");
            if (p_drValueFilterArr != null && p_drValueFilterArr.Length > 0)
            {
                p_objMedicine = new clsMS_TotalAccountVO_rq();
                
                int intProcessType = 0;
                intRowsCount = p_drValueFilterArr.Length;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = p_drValueFilterArr[iRow];
                    p_objMedicine.m_strMedicineTypeName = drCurrent["medicinetypesetname"].ToString();
                    p_objMedicine.m_strMedicineName = drCurrent["medicinename_vch"].ToString();
                    p_objMedicine.m_strMedicineSpec = drCurrent["medspec_vchr"].ToString();

                    intProcessType = m_intGetProcessType(drCurrent["chittyid_vchr"].ToString());
                    switch (intProcessType)
                    {
                        case 1:
                            p_objMedicine.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 2:
                            p_objMedicine.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 3:
                            p_objMedicine.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 4:
                            p_objMedicine.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 5:
                            p_objMedicine.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            p_objMedicine.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            break;
                        case 6:
                            int intType = Convert.ToInt32(drCurrent["TYPE_INT"]);
                            if (intType == 1)
                            {
                                p_objMedicine.m_dblInCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblInRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblInWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else if (intType == 2)
                            {
                                p_objMedicine.m_dblOutCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblOutRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblOutWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                        case 7:
                            //在后面单独处理
                            break;
                        case 8:
                            double dblCheck = Math.Round(Convert.ToDouble(drCurrent["newretailprice_int"]), 4) - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4);
                            if (dblCheck < 0)
                            {
                                p_objMedicine.m_dblInRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblInAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            else
                            {
                                p_objMedicine.m_dblOutRetailMoney += dblCheck * Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                                p_objMedicine.m_dblOutAmount += Math.Round(Convert.ToDouble(drCurrent["amount_int"]), 4);
                            }
                            break;
                    }
                    lngRes = 1;
                }

                if (p_drInitialFilterArr != null && p_drInitialFilterArr.Length > 0)
                {
                    intRowsCount = p_drInitialFilterArr.Length;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_drInitialFilterArr[iRow];
                        p_objMedicine.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                    }
                    lngRes = 1;
                }

                if (p_drOutFilterArr != null && p_drOutFilterArr.Length > 0)
                {
                    intRowsCount = p_drOutFilterArr.Length;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_drOutFilterArr[iRow];
                        if (Convert.ToInt16(drCurrent["type_int"]) == 1)
                        {
                            p_objMedicine.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        }
                        else
                        {
                            p_objMedicine.m_dblBeginCallMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginRetailMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginWholesaleMoney += 0 - Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                            p_objMedicine.m_dblBeginAmount += 0 - Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        }
                    }
                    lngRes = 1;
                }
                p_objMedicine.m_dblEndAmount += (p_objMedicine.m_dblBeginAmount + p_objMedicine.m_dblInAmount - p_objMedicine.m_dblOutAmount);
                if (p_objMedicine.m_dblEndAmount == 0)
                {
                    p_objMedicine.m_dblEndCallMoney = 0;
                    p_objMedicine.m_dblEndRetailMoney = 0;
                    p_objMedicine.m_dblEndWholesaleMoney = 0;
                }
                else
                {
                    p_objMedicine.m_dblEndCallMoney += (p_objMedicine.m_dblBeginCallMoney + p_objMedicine.m_dblInCallMoney + p_objMedicine.m_dblOutCallMoney);
                    p_objMedicine.m_dblEndRetailMoney += (p_objMedicine.m_dblBeginRetailMoney + p_objMedicine.m_dblInRetailMoney + p_objMedicine.m_dblOutRetailMoney);
                    p_objMedicine.m_dblEndWholesaleMoney += (p_objMedicine.m_dblBeginWholesaleMoney + p_objMedicine.m_dblInWholesaleMoney + p_objMedicine.m_dblOutWholesaleMoney);
                }
            }
            else//只有初始化记录
            {
                if (p_drInitialFilterArr != null && p_drInitialFilterArr.Length > 0)                
                {
                    p_objMedicine = new clsMS_TotalAccountVO_rq();
                    intRowsCount = p_drInitialFilterArr.Length;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drCurrent = p_drInitialFilterArr[iRow];
                        p_objMedicine.m_dblBeginCallMoney += Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginRetailMoney += Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginWholesaleMoney += Math.Round(Convert.ToDouble(drCurrent["wholesaleprice_int"]), 4) * Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);
                        p_objMedicine.m_dblBeginAmount += Math.Round(Convert.ToDouble(drCurrent["endamount_int"]), 4);

                    }

                    p_objMedicine.m_dblEndAmount = p_objMedicine.m_dblBeginAmount;
                    p_objMedicine.m_dblEndCallMoney = p_objMedicine.m_dblBeginCallMoney;
                    p_objMedicine.m_dblEndRetailMoney = p_objMedicine.m_dblBeginRetailMoney;
                    p_objMedicine.m_dblEndWholesaleMoney = p_objMedicine.m_dblBeginWholesaleMoney;

                    clsMS_PublicSVC objPulic = new clsMS_PublicSVC();
                    string p_strMedName = string.Empty;
                    string p_strMedSpec = string.Empty;
                    objPulic.m_lngGetMedicineName(p_objPrincipal, p_strMedicineID, out p_strMedName);
                    objPulic.m_lngGetMedicineSpec(p_objPrincipal, p_strMedicineID, out p_strMedSpec);
                    p_objMedicine.m_strMedicineName = p_strMedName;
                    p_objMedicine.m_strMedicineSpec = p_strMedSpec;

                    lngRes = 1;
                }
            }
            return lngRes;
        }
        #endregion

        #region 按时间段获取药品帐表 (所有药品列表)
        /// <summary>
        /// 按时间段获取药品帐表 (所有药品列表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_dtbValue">出入库数据</param>
        /// <param name="p_dtbInitialValue">初始化数据</param>
        /// <param name="p_dtbOutValue">出库数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,
            out DataTable p_dtbValue,out DataTable p_dtbInitialValue,out DataTable p_dtbOutValue)
        {
            p_dtbOutValue = null;
            p_dtbValue = null;
            p_dtbInitialValue = null;

            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                //出入库记录
                string strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       nvl(t.endamount_int,0) endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t,t_ms_medicinetypeset s
 where t.storageid_chr = ?
   and t.operatedate_dat between ? and ?
   and (t.state_int = 1 or t.state_int = 2)
   and substr(t.chittyid_vchr,9,1) != '7'
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);

                //初始化记录
                strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       nvl(t.endamount_int,0) endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?  
   and substr(t.chittyid_vchr,9,1) = '7'
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";
                
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbInitialValue, objDPArr);

                //出库记录
                strSQL = @"select t.medspec_vchr,t.callprice_int,
       t.retailprice_int,
       t.wholesaleprice_int,
       t.newretailprice_int,
       t.amount_int,
       nvl(t.endamount_int,0) endamount_int,
       t.endcallprice_int,
       t.endwholesaleprice_int,
       t.endretailprice_int,
       t.oldgross_int,
       t.chittyid_vchr,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medicinetypeid_chr,
       t.type_int,
       s.medicinetypesetname
  from t_ms_account_detail t, t_ms_medicinetypeset s
 where t.storageid_chr = ?   
   and t.operatedate_dat < ? 
   and substr(t.chittyid_vchr,9,1) != '7'
   and t.state_int = 1
   and t.medicinetypeid_chr = s.medicinetypeid_chr";

               
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutValue, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx.Message);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 设置药房帐本明细为无效
        /// <summary>
        /// 设置药房帐本明细为无效
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyID">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetDsAccountDetailInvalid(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyID)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_account_detail t
   set t.state_int = 0
 where t.chittyid_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_strChittyID.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_strChittyID[i];


                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_strChittyID.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strChittyID[iRow];

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


        #region 药房确认入帐
        /// <summary>
        /// 药房确认入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRatifyDsAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, string[] p_strChittyIDArr, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ds_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = ?
 where t.chittyid_vchr = ?
   and t.state_int = 2";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    long lngEff = -1;
                    for (int i = 0; i < p_strChittyIDArr.Length; i++)
                    {
                        objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = p_dtmAccountDate;
                        objDPArr[2].Value = p_strChittyIDArr[i];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String };

                    object[][] objValues = new object[3][];

                    int intItemCount = p_strChittyIDArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化


                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = p_dtmAccountDate;
                        objValues[2][iRow] = p_strChittyIDArr[iRow];

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
