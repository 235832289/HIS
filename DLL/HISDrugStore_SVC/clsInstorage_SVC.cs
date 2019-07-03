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
    /// 药房入库业务类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsInstorage_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {      
        #region 插入药房入库主表和明细表数据
        /// <summary>
        /// 插入药房入库主表和明细表数据
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
                        objStorageDetailArr[i2].m_lngRELATEDSERIESID_INT = m_objDetailArr[i2].m_lngSERIESID_INT;
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
                    lngRes = m_lngAddStorage(p_objPrincipal, ref objStorageDetailArr, 1);
                    if (lngRes < 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("保存库存出错");
                    }

                    lngRes = m_lngInstorageSetExamer(p_strExamerID, m_objMainVo.m_lngSERIESID_INT);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("设置审核者出错");
                    }
                    if (lngRes > 0)//入帐
                    {
                        m_lngAddNewAccountDetail(p_objPrincipal, objStorageDetailArr);
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
        #region 根据流水号删除药房入库明细
        /// <summary>
        /// 根据流水号删除药房入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelInstorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSeqid)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"update t_ds_instorage_detail a set a.status=0 where a.seriesid_int=?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
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
        #region 根据流水号删除药房入库主表
        /// <summary>
        /// 根据流水号删除药房入库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelInstorage(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSeqid)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"update t_ds_instorage a set a.status=0 where a.seriesid_int=?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (lngRes > 0)
                {
                    strSQL = @"update t_ds_instorage_detail a  set a.status=0 where a.seriesid2_int=?";
                    objDataParm = null;
                    objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                    objDataParm[0].Value = m_lngSeqid;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);

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
        #region 更新药房入库主表和明细表数据
        /// <summary>
        /// 更新药房入库主表和明细表数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow">是否审核，0否，1是</param>
        /// <param name="p_strExamerID">审核者</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateInStorageInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID)
        {
            long lngRes = 0;
            long lngAffected = -1;
            try
            {
                string strSQL = @"update t_ds_instorage a 
    set a.typecode_vchr = ?,
    a.drugstoreid_chr = ?,
    a.comment_vchr = ?,
    a.borrowdept_chr = ?
    where a.seriesid_int = ?
    and a.status = 1 ";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPubSvc = new clsDS_Public_Supported_SVC();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(5, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_strTYPECODE_VCHR;
                objDataParm[1].Value = m_objMainVo.m_strDRUGSTOREID_INT;
                objDataParm[2].Value = m_objMainVo.m_strCOMMENT_VCHR;
                objDataParm[3].Value = m_objMainVo.m_strBORROWDEPT_CHR;
                objDataParm[4].Value = m_objMainVo.m_lngSERIESID_INT;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);
                if (lngAffected != 1)
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    ContextUtil.SetAbort();
                    return -1;
                }
                System.Collections.Generic.List<clsDS_Instorage_Detail> m_objInsertDetialArr = new List<clsDS_Instorage_Detail>();
                System.Collections.Generic.List<clsDS_Instorage_Detail> m_objUpdateDetialArr = new List<clsDS_Instorage_Detail>();

                for(int i = 0; i < m_objDetailArr.Length; i++)
                {
                    //if (m_objDetailArr[i].m_lngSERIESID_INT >= 0)
                    //{
                    //    m_objUpdateDetialArr.Add(m_objDetailArr[i]);
                    //}
                    //else
                    //{
                    m_objInsertDetialArr.Add(m_objDetailArr[i]);
                    //}
                }

                strSQL = @"delete from t_ds_instorage_detail a where a.seriesid2_int = ?";
                objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_objMainVo.m_lngSERIESID_INT;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objDataParm);

                    #region 作废
                    /*
                strSQL = @"update t_ds_instorage_detail set 
             seriesid2_int=?, medicineid_chr=?, medicinename_vchr=?,
             medspec_vchr=?, opamount_int=?, opunit_chr=?, ipamount_int=?,
             ipunit_chr=?, packqty_dec=?, opwholesaleprice_int=?,
             ipwholesaleprice_int=?, opretailprice_int=?, ipretailprice_int=?,
             lotno_vchr=?, validperiod_dat=?, status=?,productorid_chr = ?
             where seriesid_int=?";
                //,instoreid_vchr = ?,instoragedate_dat = ?修改时此两项不变
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.String, DbType.String, 
                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
                    DbType.String, DbType.Double, DbType.Double, 
                    DbType.Double, DbType.Double, DbType.Double, 
                    DbType.String,DbType.DateTime, DbType.Int16,
                    DbType.String,DbType.Int64};
                object[][] objValues = new object[18][];
                int intItemCount = m_objUpdateDetialArr.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }
                for (int iRow = 0; iRow < m_objUpdateDetialArr.Count; iRow++)
                {
                    objValues[0][iRow] = m_objUpdateDetialArr[iRow].m_lngSERIESID2_INT;
                    objValues[1][iRow] = m_objUpdateDetialArr[iRow].m_strMEDICINEID_CHR;
                    objValues[2][iRow] = m_objUpdateDetialArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[3][iRow] = m_objUpdateDetialArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[4][iRow] = m_objUpdateDetialArr[iRow].m_dblOPAMOUNT_INT;
                    objValues[5][iRow] = m_objUpdateDetialArr[iRow].m_strOPUNIT_CHR;
                    objValues[6][iRow] = m_objUpdateDetialArr[iRow].m_dblIPAMOUNT_INT;
                    objValues[7][iRow] = m_objUpdateDetialArr[iRow].m_strIPUNIT_CHR;
                    objValues[8][iRow] = m_objUpdateDetialArr[iRow].m_dblPACKQTY_DEC;
                    objValues[9][iRow] = m_objUpdateDetialArr[iRow].m_dblOPWHOLESALEPRICE_INT;
                    objValues[10][iRow] = m_objUpdateDetialArr[iRow].m_dblIPWHOLESALEPRICE_INT;
                    objValues[11][iRow] = m_objUpdateDetialArr[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[12][iRow] = m_objUpdateDetialArr[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[13][iRow] = m_objUpdateDetialArr[iRow].m_strLOTNO_VCHR;
                    objValues[14][iRow] = m_objUpdateDetialArr[iRow].m_datVALIDPERIOD_DAT;
                    objValues[15][iRow] = m_objUpdateDetialArr[iRow].m_intSTATUS;
                    objValues[16][iRow] = m_objUpdateDetialArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[17][iRow] = m_objUpdateDetialArr[iRow].m_lngSERIESID_INT;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                //保存即审核
                if (p_intCommitFolow == 1 && m_objUpdateDetialArr.Count > 0)
                {
                    clsDS_StorageDetail_VO[] objStorageDetailArr = new clsDS_StorageDetail_VO[m_objUpdateDetialArr.Count];
                    double m_dblStoregeAmount = 0d;
                    double m_dblStorageIPAmount = 0d;
                    bool m_blnCheckEnough = false;
                    DateTime dtmNow;
                    clsDS_Public_Supported_SVC objService = new clsDS_Public_Supported_SVC();
                    objService.m_lngGetSystemDateTime(out dtmNow);
                    //保存库存明细表
                    for (int i2 = 0; i2 < m_objUpdateDetialArr.Count; i2++)
                    {
                        objStorageDetailArr[i2] = new clsDS_StorageDetail_VO();
                        objStorageDetailArr[i2].m_strMEDICINEID_CHR = m_objUpdateDetialArr[i2].m_strMEDICINEID_CHR;
                        objStorageDetailArr[i2].m_strMEDICINENAME_VCHR = m_objUpdateDetialArr[i2].m_strMEDICINENAME_VCHR;
                        objStorageDetailArr[i2].m_strMEDSPEC_VCHR = m_objUpdateDetialArr[i2].m_strMEDSPEC_VCHR;
                        objStorageDetailArr[i2].m_strLOTNO_VCHR = m_objUpdateDetialArr[i2].m_strLOTNO_VCHR;
                        objStorageDetailArr[i2].m_dblOPREALGROSS_INT = m_objUpdateDetialArr[i2].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblOPAVAILABLEGROSS_NUM = m_objUpdateDetialArr[i2].m_dblOPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblOPRETAILPRICE_INT = m_objUpdateDetialArr[i2].m_dblOPRETAILPRICE_INT;
                        objStorageDetailArr[i2].m_dblOPWHOLESALEPRICE_INT = m_objUpdateDetialArr[i2].m_dblOPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i2].m_dblIPREALGROSS_INT = m_objUpdateDetialArr[i2].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblIPAVAILABLEGROSS_NUM = m_objUpdateDetialArr[i2].m_dblIPAMOUNT_INT;
                        objStorageDetailArr[i2].m_dblIPRETAILPRICE_INT = m_objUpdateDetialArr[i2].m_dblIPRETAILPRICE_INT;
                        objStorageDetailArr[i2].m_dblIPWHOLESALEPRICE_INT = m_objUpdateDetialArr[i2].m_dblIPWHOLESALEPRICE_INT;
                        objStorageDetailArr[i2].m_dblPACKQTY_DEC = m_objUpdateDetialArr[i2].m_dblPACKQTY_DEC;
                        objStorageDetailArr[i2].m_strOPUNIT_CHR = m_objUpdateDetialArr[i2].m_strOPUNIT_CHR;
                        objStorageDetailArr[i2].m_strIPUNIT_CHR = m_objUpdateDetialArr[i2].m_strIPUNIT_CHR;
                        objStorageDetailArr[i2].m_dtmVALIDPERIOD_DAT = m_objUpdateDetialArr[i2].m_datVALIDPERIOD_DAT;
                        objStorageDetailArr[i2].m_strINSTOREID_VCHR = m_objUpdateDetialArr[i2].m_strINSTOREID_VCHR;
                        objStorageDetailArr[i2].m_dtmINSTORAGEDATE_DAT = m_objUpdateDetialArr[i2].m_dtmINSTORAGEDATE_DAT;
                        objStorageDetailArr[i2].STATUS = 1;
                        objStorageDetailArr[i2].m_intType = (byte)m_objMainVo.m_intFORMTYPE_INT;
                        objStorageDetailArr[i2].m_strDRUGSTOREID_CHR = m_objMainVo.m_strDRUGSTOREID_INT;
                        objStorageDetailArr[i2].m_strDSINSTOREID_VCHR = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                        objStorageDetailArr[i2].m_dtmDSINSTORAGEDATE_DAT = dtmNow;
                        objStorageDetailArr[i2].m_strPRODUCTORID_CHR = m_objUpdateDetialArr[i2].m_strPRODUCTORID_CHR;
                        objStorageDetailArr[i2].m_lngRELATEDSERIESID_INT = m_objUpdateDetialArr[i2].m_lngSERIESID_INT;

                        //if (m_objUpdateDetialArr[i2].m_dblIPAMOUNT_INT < 0)
                        //{
                        //    m_dblStoregeAmount = m_objUpdateDetialArr[i2].m_dblOPAMOUNT_INT;
                        //    m_dblStorageIPAmount = m_objUpdateDetialArr[i2].m_dblIPAMOUNT_INT;
                        //    m_lngJudgeMedicineExisted(m_objMainVo.m_strDRUGSTOREID_INT, m_objUpdateDetialArr[i2].m_strLOTNO_VCHR, m_objUpdateDetialArr[i2].m_strMEDICINEID_CHR,
                        //        ref m_dblStoregeAmount,ref m_dblStorageIPAmount, out m_blnCheckEnough);
                        //    if (m_dblStoregeAmount == 1)
                        //    {
                        //        throw new Exception("批号为[" + m_objUpdateDetialArr[i2].m_strLOTNO_VCHR + "]的药品[" + m_objUpdateDetialArr[i2].m_strMEDICINENAME_VCHR
                        //            + "]数量不够冲减！");
                        //    }
                        //    if (m_blnCheckEnough == false)
                        //    {
                        //        throw new Exception("库存不存在批号为[" + m_objUpdateDetialArr[i2].m_strLOTNO_VCHR + "]的药品[" + m_objUpdateDetialArr[i2].m_strMEDICINENAME_VCHR
                        //            + "]！");
                        //    }
                        //}
                    }
                    lngRes = m_lngAddStorage(p_objPrincipal, ref objStorageDetailArr, 1);
                    if (lngRes < 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("保存库存出错");
                    }
                    if (objStorageDetailArr.Length > 0)
                    {
                        lngRes = m_lngUpdateAccountDetail(p_objPrincipal, objStorageDetailArr[0].m_strDRUGSTOREID_CHR, objStorageDetailArr[0].m_strDSINSTOREID_VCHR);
                        lngRes = m_lngAddNewAccountDetail(p_objPrincipal, objStorageDetailArr);
                    }
                }*/
                    #endregion

                if(m_objInsertDetialArr.Count > 0)
                {
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
             ?, ?, ?,
             ?,?,?
            )";
                    long[] lngSEQArr = null;
                    lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", m_objInsertDetialArr.Count, out lngSEQArr);
                    DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, 
                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
                    DbType.String, DbType.Double, DbType.Double, 
                    DbType.Double, DbType.Double, DbType.Double, 
                    DbType.String,DbType.DateTime, DbType.Int16,
                    DbType.String,DbType.DateTime,DbType.String };
                    object[][] objValues = new object[20][];
                    int intItemCount = m_objInsertDetialArr.Count
                        ;
                    for(int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for(int iRow = 0; iRow < m_objInsertDetialArr.Count; iRow++)
                    {
                        m_objInsertDetialArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objValues[0][iRow] = m_objInsertDetialArr[iRow].m_lngSERIESID_INT;
                        m_objInsertDetialArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                        objValues[1][iRow] = m_objInsertDetialArr[iRow].m_lngSERIESID2_INT;
                        objValues[2][iRow] = m_objInsertDetialArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = m_objInsertDetialArr[iRow].m_strMEDICINENAME_VCHR;
                        objValues[4][iRow] = m_objInsertDetialArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = m_objInsertDetialArr[iRow].m_dblOPAMOUNT_INT;
                        objValues[6][iRow] = m_objInsertDetialArr[iRow].m_strOPUNIT_CHR;
                        objValues[7][iRow] = m_objInsertDetialArr[iRow].m_dblIPAMOUNT_INT;
                        objValues[8][iRow] = m_objInsertDetialArr[iRow].m_strIPUNIT_CHR;
                        objValues[9][iRow] = m_objInsertDetialArr[iRow].m_dblPACKQTY_DEC;
                        objValues[10][iRow] = m_objInsertDetialArr[iRow].m_dblOPWHOLESALEPRICE_INT;
                        objValues[11][iRow] = m_objInsertDetialArr[iRow].m_dblIPWHOLESALEPRICE_INT;
                        objValues[12][iRow] = m_objInsertDetialArr[iRow].m_dblOPRETAILPRICE_INT;
                        objValues[13][iRow] = m_objInsertDetialArr[iRow].m_dblIPRETAILPRICE_INT;
                        objValues[14][iRow] = m_objInsertDetialArr[iRow].m_strLOTNO_VCHR;
                        objValues[15][iRow] = m_objInsertDetialArr[iRow].m_datVALIDPERIOD_DAT;
                        objValues[16][iRow] = m_objInsertDetialArr[iRow].m_intSTATUS;
                        objValues[17][iRow] = m_objInsertDetialArr[iRow].m_strINSTOREID_VCHR;
                        objValues[18][iRow] = m_objInsertDetialArr[iRow].m_dtmINSTORAGEDATE_DAT;
                        objValues[19][iRow] = m_objInsertDetialArr[iRow].m_strPRODUCTORID_CHR;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                    //保存即审核
                    if(p_intCommitFolow == 1 && m_objInsertDetialArr.Count > 0)
                    {
                        clsDS_StorageDetail_VO[] objStorageInsertDetailArr = new clsDS_StorageDetail_VO[m_objInsertDetialArr.Count];
                        double m_dblStoregeAmount = 0d;
                        double m_dblStorageIPAmount = 0d;
                        bool m_blnCheckEnough = false;
                        DateTime dtmNow;
                        clsDS_Public_Supported_SVC objService = new clsDS_Public_Supported_SVC();
                        objService.m_lngGetSystemDateTime(out dtmNow);
                        //保存库存明细表
                        for(int i3 = 0; i3 < m_objInsertDetialArr.Count; i3++)
                        {
                            objStorageInsertDetailArr[i3] = new clsDS_StorageDetail_VO();
                            objStorageInsertDetailArr[i3].m_strMEDICINEID_CHR = m_objInsertDetialArr[i3].m_strMEDICINEID_CHR;
                            objStorageInsertDetailArr[i3].m_strMEDICINENAME_VCHR = m_objInsertDetialArr[i3].m_strMEDICINENAME_VCHR;
                            objStorageInsertDetailArr[i3].m_strMEDSPEC_VCHR = m_objInsertDetialArr[i3].m_strMEDSPEC_VCHR;
                            objStorageInsertDetailArr[i3].m_strLOTNO_VCHR = m_objInsertDetialArr[i3].m_strLOTNO_VCHR;
                            objStorageInsertDetailArr[i3].m_dblOPREALGROSS_INT = m_objInsertDetialArr[i3].m_dblOPAMOUNT_INT;
                            objStorageInsertDetailArr[i3].m_dblOPAVAILABLEGROSS_NUM = m_objInsertDetialArr[i3].m_dblOPAMOUNT_INT;
                            objStorageInsertDetailArr[i3].m_dblOPRETAILPRICE_INT = m_objInsertDetialArr[i3].m_dblOPRETAILPRICE_INT;
                            objStorageInsertDetailArr[i3].m_dblOPWHOLESALEPRICE_INT = m_objInsertDetialArr[i3].m_dblOPWHOLESALEPRICE_INT;
                            objStorageInsertDetailArr[i3].m_dblIPREALGROSS_INT = m_objInsertDetialArr[i3].m_dblIPAMOUNT_INT;
                            objStorageInsertDetailArr[i3].m_dblIPAVAILABLEGROSS_NUM = m_objInsertDetialArr[i3].m_dblIPAMOUNT_INT;
                            objStorageInsertDetailArr[i3].m_dblIPRETAILPRICE_INT = m_objInsertDetialArr[i3].m_dblIPRETAILPRICE_INT;
                            objStorageInsertDetailArr[i3].m_dblIPWHOLESALEPRICE_INT = m_objInsertDetialArr[i3].m_dblIPWHOLESALEPRICE_INT;
                            objStorageInsertDetailArr[i3].m_dblPACKQTY_DEC = m_objInsertDetialArr[i3].m_dblPACKQTY_DEC;
                            objStorageInsertDetailArr[i3].m_strOPUNIT_CHR = m_objInsertDetialArr[i3].m_strOPUNIT_CHR;
                            objStorageInsertDetailArr[i3].m_strIPUNIT_CHR = m_objInsertDetialArr[i3].m_strIPUNIT_CHR;
                            objStorageInsertDetailArr[i3].m_dtmVALIDPERIOD_DAT = m_objInsertDetialArr[i3].m_datVALIDPERIOD_DAT;
                            objStorageInsertDetailArr[i3].m_strINSTOREID_VCHR = m_objInsertDetialArr[i3].m_strINSTOREID_VCHR;
                            objStorageInsertDetailArr[i3].m_dtmINSTORAGEDATE_DAT = m_objInsertDetialArr[i3].m_dtmINSTORAGEDATE_DAT;
                            objStorageInsertDetailArr[i3].STATUS = 1;
                            objStorageInsertDetailArr[i3].m_strDRUGSTOREID_CHR = m_objMainVo.m_strDRUGSTOREID_INT;
                            objStorageInsertDetailArr[i3].m_strDSINSTOREID_VCHR = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                            objStorageInsertDetailArr[i3].m_dtmDSINSTORAGEDATE_DAT = dtmNow;
                            objStorageInsertDetailArr[i3].m_strPRODUCTORID_CHR = m_objInsertDetialArr[i3].m_strPRODUCTORID_CHR;
                            objStorageInsertDetailArr[i3].m_lngRELATEDSERIESID_INT = m_objInsertDetialArr[i3].m_lngSERIESID_INT;
                            //if (m_objInsertDetialArr[i3].m_dblIPAMOUNT_INT < 0)
                            //{
                            //    m_dblStoregeAmount = m_objInsertDetialArr[i3].m_dblOPAMOUNT_INT;
                            //    m_dblStorageIPAmount = m_objInsertDetialArr[i3].m_dblIPAMOUNT_INT;
                            //    m_lngJudgeMedicineExisted(m_objMainVo.m_strDRUGSTOREID_INT, m_objInsertDetialArr[i3].m_strLOTNO_VCHR, m_objInsertDetialArr[i3].m_strMEDICINEID_CHR,
                            //        ref m_dblStoregeAmount,ref m_dblStorageIPAmount, out m_blnCheckEnough);
                            //    if (m_dblStoregeAmount == 1)
                            //    {
                            //        throw new Exception("批号为[" + m_objInsertDetialArr[i3].m_strLOTNO_VCHR + "]的药品[" + m_objInsertDetialArr[i3].m_strMEDICINENAME_VCHR
                            //            + "]数量不够冲减！");
                            //    }
                            //    if (m_blnCheckEnough == false)
                            //    {
                            //        throw new Exception("库存不存在批号为[" + m_objInsertDetialArr[i3].m_strLOTNO_VCHR + "]的药品[" + m_objInsertDetialArr[i3].m_strMEDICINENAME_VCHR
                            //            + "]！");
                            //    }
                            //}
                        }
                        lngRes = m_lngAddStorage(p_objPrincipal, ref objStorageInsertDetailArr, 1);
                        if(lngRes < 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception("保存库存出错");
                        }
                        if(objStorageInsertDetailArr.Length > 0)
                        {
                            lngRes = m_lngAddNewAccountDetail(p_objPrincipal, objStorageInsertDetailArr);
                        }
                    }
                }
                if (p_intCommitFolow == 1 && lngRes > 0)
                {
                    lngRes = m_lngInstorageSetExamer(p_strExamerID, m_objMainVo.m_lngSERIESID_INT);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("设置审核者出错");
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

        #region 添加库存主表记录
        [AutoComplete]
        public long m_lngAddStorageGross(string p_strStorageID, clsDS_StorageDetail_VO p_objDetail)
        {
            long lngRes = -1;
            string strSQL;
            long lngSEQ;
            strSQL = @"insert into t_ds_storage
  (seriesid_int,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   opcurrentgross_num,
   opunit_chr,
   ipcurrentgross_num,
   ipunit_chr,
   drugstoreid_chr
   )
  values
  (?, ?, ?, ?, ?, ?, ?, ?, ?)";


            clsDS_Public_Supported_SVC clsPub = new clsDS_Public_Supported_SVC();
            lngRes = clsPub.m_lngGetSequence(null, "SEQ_DS_STORAGE", out lngSEQ);

            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(9, out objValues);

            objValues[0].Value = lngSEQ;
            objValues[1].Value = p_objDetail.m_strMEDICINEID_CHR;
            objValues[2].Value = p_objDetail.m_strMEDICINENAME_VCHR;
            objValues[3].Value = p_objDetail.m_strMEDSPEC_VCHR;
            objValues[4].Value = p_objDetail.m_dblOPREALGROSS_INT;
            objValues[5].Value = p_objDetail.m_strOPUNIT_CHR;
            objValues[6].Value = p_objDetail.m_dblIPREALGROSS_INT;
            objValues[7].Value = p_objDetail.m_strIPUNIT_CHR;
            objValues[8].Value = p_objDetail.m_strDRUGSTOREID_CHR;

            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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
        #region 修改库存主表数量
        /// <summary>
        /// 修改库存主表数量
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1：加库存,2：减库存</param>
        /// <param name="p_lngSeriesID">主表顺号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyStorageGross(string p_strStorageID, clsDS_StorageDetail_VO p_objDetail, Int16 intType, long p_lngSeriesID)
        {
            //修改库存主表
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"update t_ds_storage
       set opcurrentgross_num = opcurrentgross_num + ?,
       ipcurrentgross_num = ipcurrentgross_num + ?
       where seriesid_int = ?";
            objHRPServ.CreateDatabaseParameter(3, out objValues);
            //判断当前为添加库存数还是减小
            if (intType == 1)
            {
                objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_lngSeriesID;
            }
            else
            {
                objValues[0].Value = -p_objDetail.m_dblOPREALGROSS_INT;
                objValues[1].Value = -p_objDetail.m_dblIPREALGROSS_INT;
                objValues[2].Value = p_lngSeriesID;
            }
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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
        #region 添加库存明细表记录
        /// <summary>
        /// 添加库存明细表表记录(批量)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objDetail">库存明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorage_detail(string p_strStorageID, clsDS_StorageDetail_VO[] p_objDetail)
        {
            long lngRes = -1;
            string strSQL;
            long[] lngSEQArr = null;
            strSQL = @"insert into t_ds_storage_detail
  (seriesid_int,
   drugstoreid_chr,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr,
   lotno_vchr,
   iprealgross_int,
   ipunit_chr,
   oprealgross_int,
   opunit_chr,
   packqty_dec,
   ipretailprice_int,
   opretailprice_int,
   ipwholesaleprice_int,
   opwholesaleprice_int,
   validperiod_dat ,
   instoreid_vchr,
   instoragedate_dat,
   status,
   adjustpriceman_chr,
   adjustpricedate_dat,
   opavailablegross_num,
   ipavailablegross_num,
   productorid_chr
   )
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)";

            DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, 
                DbType.String, DbType.String,DbType.String,DbType.String,DbType.Int32, DbType.Int32,
                DbType.String,DbType.Double,DbType.Int32,DbType.Int32,DbType.Int32,DbType.Int32,
                DbType.DateTime,DbType.String,DbType.Int32, DbType.String,DbType.DateTime,
                DbType.Int32,DbType.Int32,DbType.String};
            clsDS_Public_Supported_SVC clsPub = new clsDS_Public_Supported_SVC();
            lngRes = clsPub.m_lngGetSequenceArr(null, "SEQ_DS_STORAGE_DETAIL", p_objDetail.Length, out lngSEQArr);
            clsHRPTableService objHRPServ = new clsHRPTableService();
            object[][] objValues = new object[24][];
            int intItemCount = p_objDetail.Length;
            for (int j = 0; j < objValues.Length; j++)
            {
                objValues[j] = new object[intItemCount];//初始化
            }
            for (int iRow = 0; iRow < intItemCount; iRow++)
            {
                objValues[0][iRow] = lngSEQArr;
                objValues[1][iRow] = p_objDetail[iRow].m_strDRUGSTOREID_CHR;
                objValues[2][iRow] = p_objDetail[iRow].m_strMEDICINEID_CHR;
                objValues[3][iRow] = p_objDetail[iRow].m_strMEDICINENAME_VCHR;
                objValues[4][iRow] = p_objDetail[iRow].m_strMEDSPEC_VCHR;
                objValues[5][iRow] = p_objDetail[iRow].m_strLOTNO_VCHR;
                objValues[6][iRow] = p_objDetail[iRow].m_dblIPREALGROSS_INT;
                objValues[7][iRow] = p_objDetail[iRow].m_strIPUNIT_CHR;
                objValues[8][iRow] = p_objDetail[iRow].m_dblOPREALGROSS_INT;
                objValues[9][iRow] = p_objDetail[iRow].m_strOPUNIT_CHR;
                objValues[10][iRow] = p_objDetail[iRow].m_dblOPREALGROSS_INT;
                objValues[11][iRow] = p_objDetail[iRow].m_dblPACKQTY_DEC;
                objValues[12][iRow] = p_objDetail[iRow].m_dblIPRETAILPRICE_INT;
                objValues[13][iRow] = p_objDetail[iRow].m_dblOPRETAILPRICE_INT;
                objValues[14][iRow] = p_objDetail[iRow].m_dblIPWHOLESALEPRICE_INT;
                objValues[15][iRow] = p_objDetail[iRow].m_dblOPWHOLESALEPRICE_INT;
                objValues[16][iRow] = p_objDetail[iRow].m_dtmVALIDPERIOD_DAT;
                objValues[17][iRow] = p_objDetail[iRow].m_strINSTOREID_VCHR;
                objValues[18][iRow] = p_objDetail[iRow].m_dtmINSTORAGEDATE_DAT;
                objValues[19][iRow] = p_objDetail[iRow].m_strADJUSTPRICEMAN_CHR;
                objValues[20][iRow] = p_objDetail[iRow].m_dtmADJUSTPRICEDATE_DAT;
                objValues[21][iRow] = p_objDetail[iRow].m_dblOPREALGROSS_INT;
                objValues[22][iRow] = p_objDetail[iRow].m_dblIPREALGROSS_INT;
                objValues[23][iRow] = p_objDetail[iRow].m_strPRODUCTORID_CHR;
            }
            try
            {
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
        #region 添加库存明细表表记录(单条明细)
        /// <summary>
        /// 添加库存明细表表记录(单条明细)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objDetail">库存明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorage_detail(string p_strStorageID, ref clsDS_StorageDetail_VO p_objDetail)
        {
            long lngRes = -1;
            string strSQL;
            long lngSEQ;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"select a.seriesid_int,
       a.iprealgross_int,
       a.oprealgross_int
  from t_ds_storage_detail a
                         where a.medicineid_chr = ?
                           and a.lotno_vchr = ?
                           and a.drugstoreid_chr = ?
                           and a.status = 1";
            DataTable dt = new DataTable();
            objHRPServ.CreateDatabaseParameter(3, out objValues);
            objValues[0].Value = p_objDetail.m_strMEDICINEID_CHR;
            objValues[1].Value = p_objDetail.m_strLOTNO_VCHR;
            objValues[2].Value = p_objDetail.m_strDRUGSTOREID_CHR;
            lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objValues);
            if (lngRes > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    long lngSeriesid = Convert.ToInt64(dt.Rows[0]["seriesid_int"]);
                    //20081212:入库结存数改为入库操作后的数量
                    p_objDetail.m_dblOldIPREALGROSS_INT = Convert.ToDouble(dt.Rows[0]["iprealgross_int"]) + p_objDetail.m_dblIPREALGROSS_INT;
                    p_objDetail.m_dblOldOPREALGROSS_INT = Convert.ToDouble(dt.Rows[0]["oprealgross_int"]) + p_objDetail.m_dblOPREALGROSS_INT;
                    strSQL = @" update t_ds_storage_detail a
                                  set a.oprealgross_int      = a.oprealgross_int + ?,
                                      a.iprealgross_int      = a.iprealgross_int + ?,
                                      a.opavailablegross_num = a.opavailablegross_num + ?,
                                      a.ipavailablegross_num = a.ipavailablegross_num + ?
                                  where a.seriesid_int = ?";
                    objValues = null;
                    objHRPServ.CreateDatabaseParameter(5, out objValues);
                    objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[2].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[3].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[4].Value = lngSeriesid;
                    long lngAffected = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);


                }
                else
                {
                    strSQL = @"insert into t_ds_storage_detail
                                  (seriesid_int,
                                   drugstoreid_chr,
                                   medicineid_chr,
                                   medicinename_vchr,
                                   medspec_vchr,
                                   lotno_vchr,
                                   iprealgross_int,
                                   ipunit_chr,
                                   oprealgross_int,
                                   opunit_chr,
                                   packqty_dec,
                                   ipretailprice_int,
                                   opretailprice_int,
                                   ipwholesaleprice_int,
                                   opwholesaleprice_int,
                                   validperiod_dat ,
                                   instoreid_vchr,
                                   instoragedate_dat,
                                   status,
                                   adjustpriceman_chr,
                                   adjustpricedate_dat,
                                   opavailablegross_num,
                                   ipavailablegross_num,dsinstoreid_vchr,dsinstoragedate_dat,productorid_chr
                                   )
                                values
                                  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?)";

                    clsDS_Public_Supported_SVC clsPub = new clsDS_Public_Supported_SVC();
                    lngRes = clsPub.m_lngGetSequence(null, "SEQ_DS_STORAGE_DETAIL", out lngSEQ);

                    objValues = null;
                    objHRPServ.CreateDatabaseParameter(26, out objValues);
                    objValues[0].Value = lngSEQ;
                    objValues[1].Value = p_objDetail.m_strDRUGSTOREID_CHR;
                    objValues[2].Value = p_objDetail.m_strMEDICINEID_CHR;
                    objValues[3].Value = p_objDetail.m_strMEDICINENAME_VCHR;
                    objValues[4].Value = p_objDetail.m_strMEDSPEC_VCHR;
                    objValues[5].Value = p_objDetail.m_strLOTNO_VCHR;
                    objValues[6].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[7].Value = p_objDetail.m_strIPUNIT_CHR;
                    objValues[8].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[9].Value = p_objDetail.m_strOPUNIT_CHR;
                    objValues[10].Value = p_objDetail.m_dblPACKQTY_DEC;
                    objValues[11].Value = p_objDetail.m_dblIPRETAILPRICE_INT;
                    objValues[12].Value = p_objDetail.m_dblOPRETAILPRICE_INT;
                    objValues[13].Value = p_objDetail.m_dblIPWHOLESALEPRICE_INT;
                    objValues[14].Value = p_objDetail.m_dblOPWHOLESALEPRICE_INT;
                    objValues[15].Value = p_objDetail.m_dtmVALIDPERIOD_DAT;
                    objValues[16].Value = p_objDetail.m_strINSTOREID_VCHR;
                    objValues[17].Value = p_objDetail.m_dtmINSTORAGEDATE_DAT;
                    objValues[18].Value = p_objDetail.STATUS;
                    objValues[19].Value = p_objDetail.m_strADJUSTPRICEMAN_CHR;
                    objValues[20].Value = p_objDetail.m_dtmADJUSTPRICEDATE_DAT;
                    objValues[21].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[22].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[23].Value = p_objDetail.m_strDSINSTOREID_VCHR;
                    objValues[24].Value = p_objDetail.m_dtmDSINSTORAGEDATE_DAT;
                    objValues[25].Value = p_objDetail.m_strPRODUCTORID_CHR;
                    try
                    {
                        long lngAffected = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                        p_objDetail.m_dblOldIPREALGROSS_INT = p_objDetail.m_dblIPREALGROSS_INT;
                        p_objDetail.m_dblOldOPREALGROSS_INT = p_objDetail.m_dblOPREALGROSS_INT;
                    }
                    catch (Exception objEx)
                    {
                        com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        bool blnRes = objLogger.LogError(objEx);
                    }
                }
            }
            objHRPServ.Dispose();
            objHRPServ = null;
            return lngRes;

        }
        #endregion
        #region 删除库存明细表表记录(单条明细)
        /// <summary>
        /// 删除库存明细表表记录(单条明细)
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_objDetail"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteStorage_detail(string p_strStorageID, clsDS_StorageDetail_VO p_objDetail)
        {
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"select a.seriesid_int
                          from t_ds_storage_detail a
                         where a.medicineid_chr = ?
                           and a.lotno_vchr = ?
                           and a.drugstoreid_chr = ?
                           and a.status = 1";
            DataTable dt = new DataTable();
            objHRPServ.CreateDatabaseParameter(3, out objValues);
            objValues[0].Value = p_objDetail.m_strMEDICINEID_CHR;
            objValues[1].Value = p_objDetail.m_strLOTNO_VCHR;
            objValues[2].Value = p_objDetail.m_strDRUGSTOREID_CHR;
            lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objValues);
            try
            {
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    long lngSeriesid = Convert.ToInt64(dt.Rows[0]["seriesid_int"]);
                    strSQL = @" update t_ds_storage_detail a
                                  set a.oprealgross_int      = a.oprealgross_int -?,
                                      a.iprealgross_int      = a.iprealgross_int - ?,
                                      a.opavailablegross_num = a.opavailablegross_num - ?,
                                      a.ipavailablegross_num = a.ipavailablegross_num - ?
                                  where a.seriesid_int = ?";
                    objValues = null;
                    objHRPServ.CreateDatabaseParameter(5, out objValues);
                    objValues[0].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[1].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[2].Value = p_objDetail.m_dblOPREALGROSS_INT;
                    objValues[3].Value = p_objDetail.m_dblIPREALGROSS_INT;
                    objValues[4].Value = lngSeriesid;
                    long lngAffected = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPServ.Dispose();
            objHRPServ = null;
            return lngRes;

        }
        #endregion
       
        #region 增加药房库存
        /// <summary>
        /// 增加药房库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1:加库存,2:减库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddStorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return -1;
            }
            long lngRes = -1;
            bool p_blnHasDetail;
            long p_lngSeriesID;
            clsInstorage_Supported_SVC objSelect = new clsInstorage_Supported_SVC();
            for (int intRow = 0; intRow < p_objDetail.Length; intRow++)
            {
                //判断当前药品是否已存在库存主表中
                objSelect.m_lngCheckMedExistInStorage(null, p_objDetail[intRow].m_strMEDICINEID_CHR, p_objDetail[intRow].m_strDRUGSTOREID_CHR, out p_blnHasDetail, out p_lngSeriesID);
                if (p_blnHasDetail)
                {
                    //修改库存主表数量
                    lngRes = m_lngModifyStorageGross(p_objDetail[intRow].m_strDRUGSTOREID_CHR, p_objDetail[intRow], intType, p_lngSeriesID);
                }
                else
                {
                    //添加库存主表记录
                    lngRes = m_lngAddStorageGross(p_objDetail[intRow].m_strDRUGSTOREID_CHR, p_objDetail[intRow]);
                }
                if (lngRes != -1)
                {
                    //添加库存明细表记录
                    lngRes = m_lngAddStorage_detail(p_objDetail[intRow].m_strDRUGSTOREID_CHR, ref p_objDetail[intRow]);
                }
                else
                {
                    return -1;
                }
            }
            return lngRes;

        }
        #endregion
        #region 减少药房库存
        /// <summary>
        /// 减少药房库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">库存明细VO</param>
        /// <param name="intType">修改类型　1:加库存,2:减库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSubtractStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return -1;
            }
            long lngRes = -1;
            bool p_blnHasDetail;
            long p_lngSeriesID;
            clsInstorage_Supported_SVC objSelect = new clsInstorage_Supported_SVC();
            for (int intRow = 0; intRow < p_objDetail.Length; intRow++)
            {
                //判断当前药品是否已存在库存主表中
                objSelect.m_lngCheckMedExistInStorage(null, p_objDetail[intRow].m_strMEDICINEID_CHR, p_objDetail[intRow].m_strDRUGSTOREID_CHR, out p_blnHasDetail, out p_lngSeriesID);
                if (p_blnHasDetail)
                {
                    //修改库存主表数量
                    lngRes = m_lngModifyStorageGross(p_objDetail[intRow].m_strDRUGSTOREID_CHR, p_objDetail[intRow], intType, p_lngSeriesID);
                    if (lngRes != -1)
                    {
                        //更新库存明细表记录
                        lngRes = m_lngDeleteStorage_detail(p_objDetail[intRow].m_strDRUGSTOREID_CHR, p_objDetail[intRow]);

                    }
                }
            }
            return lngRes;

        }
        #endregion
        #region 入库审核
        /// <summary>
        /// 入库审核
        /// </summary>
        /// <param name="m_strdrugstoreexamid"></param>
        /// <param name="m_datdrugstoreexam"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInstorageExam(string m_strdrugstoreexamid, DateTime m_datdrugstoreexam, long p_lngSeriesID, clsDS_StorageDetail_VO[] m_objDetailArr, int m_intType, out bool m_blnHasEnough, out string m_strMedName)
        {
            m_blnHasEnough = true;
            m_strMedName = "";
            //入库审核
            long lngRes = -1;
            string strSQL;
            strSQL = @"update t_ds_instorage a
    set a.drugstoreexamid_chr = ?,
    a.drugstoreexam_date = sysdate,
    a.status = 2
    where  a.seriesid_int = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(2, out objValues);
            objValues[0].Value = m_strdrugstoreexamid;
            objValues[1].Value = p_lngSeriesID;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngRes > 0)
                {
                    lngRes = m_lngGetInstorageDetailByID(null, p_lngSeriesID, out m_objDetailArr, m_intType, out m_blnHasEnough, out m_strMedName);
                    if (lngRes <= 0)                    
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("更新库存出错");
                    }
                }
                else
                {
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    throw new Exception("审核出错");
                }                
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPServ.Dispose();
            objHRPServ = null;
            return lngRes;
        }
        #endregion
        #region 入库退审
        /// <summary>
        /// 入库退审
        /// </summary>
        /// <param name="m_strdrugstoreexamid"></param>
        /// <param name="m_datdrugstoreexam"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInstorageUnExam(long p_lngSeriesID, out bool m_blnHasEnoughGross)
        {
            m_blnHasEnoughGross = true;
            string m_strMedName = "";
            // 入库退审
            long lngRes = -1;
            string strSQL;
            strSQL = @"update t_ds_instorage a
                        set a.status = 1
                        where  a.seriesid_int = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(1, out objValues);

            objValues[0].Value = p_lngSeriesID;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngRes > 0)
                {
                    clsDS_StorageDetail_VO[] m_objDetailVoArr = null;
                    lngRes = m_lngGetInstorageDetailByID(null, p_lngSeriesID, out m_objDetailVoArr, 2, out m_blnHasEnoughGross, out m_strMedName);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPServ.Dispose();
            objHRPServ = null;
            return lngRes;
        }
        #endregion
        #region 入库入帐
        /// <summary>
        /// 入库入帐
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInstorageInAccount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, string m_strEmpid, string m_strChittyid_vchr, string m_strDrugStoreid)
        {
            // 入库入帐
            long lngRes = -1;
            string strSQL;
            strSQL = @"update t_ds_instorage a
                        set a.inaccounterid_chr=?,a.inaccount_dat=sysdate, a.status = 3
                        where  a.seriesid_int = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(2, out objValues);

            objValues[0].Value = m_strEmpid;
            objValues[1].Value = p_lngSeriesID;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngRes > 0)
                {
                    strSQL = @"update t_ds_account_detail t
   set t.state_int = 1, t.inaccountid_chr = ?, t.inaccountdate_dat = sysdate
 where t.chittyid_vchr = ?
   and t.drugstoreid_int = ?
   and t.state_int = 2";
                    objValues = null;
                    objHRPServ.CreateDatabaseParameter(3, out objValues);
                    objValues[0].Value = m_strEmpid;
                    objValues[1].Value = m_strChittyid_vchr;
                    objValues[2].Value = m_strDrugStoreid;
                    lngAffected = -1;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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
        #region 新增账本明细
        /// <summary>
        /// 新增账本明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAccountDetailArr">账本明细内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsDS_StorageDetail_VO[] p_objAccountDetailArr)
        {
            if (p_objAccountDetailArr == null || p_objAccountDetailArr.Length == 0)
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
   a.productorid_chr,a.operatedate_dat,a.packqty_dec)
values
  (?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,
  ?,?,?,?,?,?,?,?,sysdate,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsDS_Public_Supported_SVC objPublic = new clsDS_Public_Supported_SVC();
                long[] lngSEQArr = null;
                lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_ACCOUNT_DETAIL", p_objAccountDetailArr.Length, out lngSEQArr);


                DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.DateTime,
                        DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.DateTime,DbType.String,DbType.Double,DbType.Double,DbType.String,
                        DbType.Double,DbType.Double,DbType.Int16,DbType.String,DbType.String,DbType.Int16,DbType.Int16,DbType.Int16,DbType.Double,DbType.Double,
                        DbType.Double,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.DateTime,DbType.String,DbType.String,DbType.Double};

                object[][] objValues = new object[37][];

                int intItemCount = p_objAccountDetailArr.Length;
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
                    objValues[1][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINEID_CHR;
                    objValues[2][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    objValues[3][iRow] = p_objAccountDetailArr[iRow].m_strMEDICINETYPEID_CHR;
                    objValues[4][iRow] = p_objAccountDetailArr[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = p_objAccountDetailArr[iRow].m_strDRUGSTOREID_CHR;
                    objValues[6][iRow] = p_objAccountDetailArr[iRow].m_strLOTNO_VCHR;
                    objValues[7][iRow] = p_objAccountDetailArr[iRow].m_dtmVALIDPERIOD_DAT;
                    objValues[8][iRow] = p_objAccountDetailArr[iRow].m_strDSINSTOREID_VCHR;
                    objValues[9][iRow] = p_objAccountDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT;
                    objValues[10][iRow] = p_objAccountDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT;
                    objValues[11][iRow] = p_objAccountDetailArr[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[12][iRow] = p_objAccountDetailArr[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[13][iRow] = p_objAccountDetailArr[iRow].m_dtmDSINSTORAGEDATE_DAT;
                    objValues[14][iRow] = p_objAccountDetailArr[iRow].m_strIPUNIT_CHR;
                    objValues[15][iRow] = p_objAccountDetailArr[iRow].m_dblIPREALGROSS_INT;
                    objValues[16][iRow] = p_objAccountDetailArr[iRow].m_dblOPREALGROSS_INT;
                    objValues[17][iRow] = p_objAccountDetailArr[iRow].m_strOPUNIT_CHR;
                    objValues[18][iRow] = p_objAccountDetailArr[iRow].m_dblOldIPREALGROSS_INT;
                    objValues[19][iRow] = p_objAccountDetailArr[iRow].m_dblOldOPREALGROSS_INT;
                    objValues[20][iRow] = 1;
                    objValues[21][iRow] = p_objAccountDetailArr[iRow].m_strDRUGSTOREID_CHR;
                    objValues[22][iRow] = p_objAccountDetailArr[iRow].m_strDSINSTOREID_VCHR;
                    objValues[23][iRow] = p_objAccountDetailArr[iRow].m_intType;
                    objValues[24][iRow] = 2;
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
                    objValues[35][iRow] = p_objAccountDetailArr[iRow].m_strPRODUCTORID_CHR;
                    objValues[36][iRow] = p_objAccountDetailArr[iRow].m_dblPACKQTY_DEC;

                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                
                //更新入库明细表的结存数
                if (lngRes > 0)
                {
                    strSQL = @"update t_ds_instorage_detail a
   set a.opoldgross_int = ?, a.ipoldgross_int = ?
 where a.seriesid_int = ?";

                    DbType[] dbTypes2 = new DbType[] { DbType.Double, DbType.Double,DbType.Int64};
                    object[][] objValues2 = new object[3][];
                    intItemCount = p_objAccountDetailArr.Length;
                    for (int j = 0; j < objValues2.Length; j++)
                    {
                        objValues2[j] = new object[intItemCount];//初始化

                    }
                    for (int k = 0; k < intItemCount; k++)
                    {
                        objValues2[0][k] = p_objAccountDetailArr[k].m_dblOldOPREALGROSS_INT;
                        objValues2[1][k] = p_objAccountDetailArr[k].m_dblOldIPREALGROSS_INT;
                        objValues2[2][k] = p_objAccountDetailArr[k].m_lngRELATEDSERIESID_INT;                        
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues2, dbTypes2);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("更新明细表结存数出错");
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
        #region 更新账本明细
        /// <summary>
        /// 更新账本明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strChittyid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateAccountDetail(System.Security.Principal.IPrincipal p_objPrincipal, string m_strDurgStoreid, string m_strChittyid)
        {

            long lngRes = -1;
            string strSQL;
            strSQL = @"update t_ds_account_detail t
   set t.state_int = 0
   where t.chittyid_vchr = ?
   and t.drugstoreid_int = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(2, out objValues);
            objValues[0].Value = m_strChittyid;
            objValues[1].Value = m_strDurgStoreid;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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

        #region 设置审核人员
        /// <summary>
        /// 设置审核人员
        /// </summary>
        /// <param name="m_strdrugstoreexamid"></param>
        /// <param name="m_datdrugstoreexam"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInstorageSetExamer(string m_strdrugstoreexamid, long p_lngSeriesID)
        {
            //入库审核
            long lngRes = -1;
            string strSQL;
            strSQL = @"update t_ds_instorage a
    set a.drugstoreexamid_chr = ?,
    a.drugstoreexam_date = sysdate,
    a.status = 2
    where  a.seriesid_int = ?";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            objHRPServ.CreateDatabaseParameter(2, out objValues);
            objValues[0].Value = m_strdrugstoreexamid;
            objValues[1].Value = p_lngSeriesID;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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

        #region 修改入库单的FormType、入库类型、来源部门、备注
        /// <summary>
        /// 修改入库单的FormType、入库类型、来源部门、备注
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">状态，1为审核、2为新制</param>
        /// <param name="p_strBillNo">入库单号</param>
        /// <param name="p_intFormType_int">FormType</param>
        /// <param name="p_strTypeCode">入库类型</param>
        /// <param name="p_strDeptCode">来源部门</param>
        /// <param name="p_strComment">备注</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateTypeAndDept(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus,string p_strBillNo, int p_intFormType_int, string p_strTypeCode, string p_strDeptCode,string p_strComment)
        {
            long lngRes = -1;
            string strSQL;
            clsHRPTableService objHRPServ = new clsHRPTableService();
            System.Data.IDataParameter[] objValues = null;
            strSQL = @"update t_ds_instorage a
	 set a.formtype_int = ?, a.typecode_vchr = ?, a.borrowdept_chr = ?,a.comment_vchr = ? 
 where a.indrugstoreid_vchr = ?";
            objHRPServ.CreateDatabaseParameter(5, out objValues);

            objValues[0].Value = p_intFormType_int;
            objValues[1].Value = p_strTypeCode;
            objValues[2].Value = p_strDeptCode;
            objValues[3].Value = p_strComment;
            objValues[4].Value = p_strBillNo;
            try
            {
                long lngAffected = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
                if (lngAffected > 0 && p_intStatus == 1)
                {
                    strSQL = @"update t_ds_account_detail a
	 set a.deptid_chr = ?, a.formtype_int = ?
 where a.chittyid_vchr = ?";
                    objValues = null;
                    objHRPServ.CreateDatabaseParameter(3, out objValues);
                    objValues[0].Value = p_strDeptCode;
                    objValues[1].Value = p_intFormType_int;
                    objValues[2].Value = p_strBillNo;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngAffected, objValues);
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

        #region 药房审核
        /// <summary>
        /// 药房审核
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow">是否审核，0否，1 是</param>
        /// <param name="p_strExamerID">审核者</param>
        /// <param name="p_objDetailVoArr">库存明细</param>
        /// <param name="p_intAddOrSubtract">1:加库存,2:减库存</param>
        /// <param name="p_lngAskSeqid">请领单单号</param>
        /// <param name="p_intState">请领单状态</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewInstorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID, ref clsDS_StorageDetail_VO[] p_objDetailVoArr, int p_intAddOrSubtract, long p_lngAskSeqid, int p_intState)
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

                #region 合并入库记录的代码
                //20081013 合并批号相同的入库记录    
                Hashtable m_hstCombine = new Hashtable();
                for (int i1 = 0; i1 < m_objDetailArr.Length; i1++)
                {
                    for (int i2 = i1 + 1; i2 < m_objDetailArr.Length; i2++)
                    {
                        if (m_objDetailArr[i2].m_strMEDICINEID_CHR == m_objDetailArr[i1].m_strMEDICINEID_CHR
                            && m_objDetailArr[i2].m_strLOTNO_VCHR == m_objDetailArr[i1].m_strLOTNO_VCHR)
                        {
                            m_objDetailArr[i1].m_dblIPAMOUNT_INT += m_objDetailArr[i2].m_dblIPAMOUNT_INT;
                            m_objDetailArr[i1].m_dblOPAMOUNT_INT += m_objDetailArr[i2].m_dblOPAMOUNT_INT;
                        }
                    }
                    if (!m_hstCombine.ContainsKey(m_objDetailArr[i1].m_strMEDICINEID_CHR + m_objDetailArr[i1].m_strLOTNO_VCHR))
                    {
                        m_hstCombine.Add(m_objDetailArr[i1].m_strMEDICINEID_CHR + m_objDetailArr[i1].m_strLOTNO_VCHR, m_objDetailArr[i1].m_dblOPAMOUNT_INT);
                    }
                }

                clsDS_Instorage_Detail[] m_objDetailCombine = new clsDS_Instorage_Detail[m_hstCombine.Count];
                int m_intCount = 0;
                foreach (DictionaryEntry de in m_hstCombine)
                {
                    for (int i2 = 0; i2 < m_objDetailArr.Length; i2++)
                    {
                        if (m_objDetailArr[i2].m_strMEDICINEID_CHR + m_objDetailArr[i2].m_strLOTNO_VCHR == de.Key.ToString())
                        {
                            m_objDetailCombine[m_intCount] = new clsDS_Instorage_Detail();
                            m_objDetailArr[i2].m_mthCopyTo(m_objDetailCombine[m_intCount]);
                            m_intCount++;
                            break;
                        }
                    }
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
                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", m_objDetailCombine.Length, out lngSEQArr);
                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, 
                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
                    DbType.String, DbType.Double, DbType.Double, 
                    DbType.Double, DbType.Double, DbType.Double, 
                    DbType.String,DbType.DateTime, DbType.Int16,DbType.String,DbType.DateTime,DbType.String};
                object[][] objValues = new object[20][];
                int intItemCount = m_objDetailCombine.Length;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化

                }

                for (int iRow = 0; iRow < m_objDetailCombine.Length; iRow++)
                {
                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;

                    m_objDetailCombine[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                    m_objDetailCombine[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
                    objValues[0][iRow] = m_objDetailCombine[iRow].m_lngSERIESID_INT;
                    objValues[1][iRow] = m_objDetailCombine[iRow].m_lngSERIESID2_INT;
                    objValues[2][iRow] = m_objDetailCombine[iRow].m_strMEDICINEID_CHR;
                    objValues[3][iRow] = m_objDetailCombine[iRow].m_strMEDICINENAME_VCHR;
                    objValues[4][iRow] = m_objDetailCombine[iRow].m_strMEDSPEC_VCHR;
                    objValues[5][iRow] = m_objDetailCombine[iRow].m_dblOPAMOUNT_INT;
                    objValues[6][iRow] = m_objDetailCombine[iRow].m_strOPUNIT_CHR;
                    objValues[7][iRow] = m_objDetailCombine[iRow].m_dblIPAMOUNT_INT;
                    objValues[8][iRow] = m_objDetailCombine[iRow].m_strIPUNIT_CHR;
                    objValues[9][iRow] = m_objDetailCombine[iRow].m_dblPACKQTY_DEC;
                    objValues[10][iRow] = m_objDetailCombine[iRow].m_dblOPWHOLESALEPRICE_INT;
                    objValues[11][iRow] = m_objDetailCombine[iRow].m_dblIPWHOLESALEPRICE_INT;
                    objValues[12][iRow] = m_objDetailCombine[iRow].m_dblOPRETAILPRICE_INT;
                    objValues[13][iRow] = m_objDetailCombine[iRow].m_dblIPRETAILPRICE_INT;
                    objValues[14][iRow] = m_objDetailCombine[iRow].m_strLOTNO_VCHR;
                    objValues[15][iRow] = m_objDetailCombine[iRow].m_datVALIDPERIOD_DAT;
                    objValues[16][iRow] = m_objDetailCombine[iRow].m_intSTATUS;
                    objValues[17][iRow] = m_objDetailCombine[iRow].m_strINSTOREID_VCHR;
                    objValues[18][iRow] = m_objDetailCombine[iRow].m_dtmINSTORAGEDATE_DAT;
                    objValues[19][iRow] = m_objDetailCombine[iRow].m_strPRODUCTORID_CHR;
                }
                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                #endregion

//                strSQL = @"insert into t_ds_instorage_detail
//            (seriesid_int, seriesid2_int, medicineid_chr, medicinename_vchr,
//             medspec_vchr, opamount_int, opunit_chr, ipamount_int,
//             ipunit_chr, packqty_dec, opwholesaleprice_int,
//             ipwholesaleprice_int, opretailprice_int, ipretailprice_int,
//             lotno_vchr, validperiod_dat, status,instoreid_vchr,instoragedate_dat,productorid_chr
//            )
//     values (?, ?, ?, ?,
//             ?, ?, ?, ?,
//             ?, ?, ?,
//             ?, ?, ?,
//             ?, ?, ?,?,?,?
//            )";
//                long[] lngSEQArr = null;
//                lngRes = objPubSvc.m_lngGetSequenceArr(p_objPrincipal, "SEQ_DS_INSTORAGE_DETAIL", m_objDetailArr.Length, out lngSEQArr);
//                DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64, DbType.String, DbType.String, 
//                    DbType.String, DbType.Double, DbType.String, DbType.Double, 
//                    DbType.String, DbType.Double, DbType.Double, 
//                    DbType.Double, DbType.Double, DbType.Double, 
//                    DbType.String,DbType.DateTime, DbType.Int16,DbType.String,DbType.DateTime,DbType.String};
//                object[][] objValues = new object[20][];
//                int intItemCount = m_objDetailArr.Length;
//                for (int j = 0; j < objValues.Length; j++)
//                {
//                    objValues[j] = new object[intItemCount];//初始化

//                }

//                for (int iRow = 0; iRow < m_objDetailArr.Length; iRow++)
//                {
//                    m_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
//                    objValues[0][iRow] = m_objDetailArr[iRow].m_lngSERIESID_INT;
//                    m_objDetailArr[iRow].m_lngSERIESID2_INT = m_objMainVo.m_lngSERIESID_INT;
//                    objValues[1][iRow] = m_objDetailArr[iRow].m_lngSERIESID2_INT;
//                    objValues[2][iRow] = m_objDetailArr[iRow].m_strMEDICINEID_CHR;
//                    objValues[3][iRow] = m_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
//                    objValues[4][iRow] = m_objDetailArr[iRow].m_strMEDSPEC_VCHR;
//                    objValues[5][iRow] = m_objDetailArr[iRow].m_dblOPAMOUNT_INT;
//                    objValues[6][iRow] = m_objDetailArr[iRow].m_strOPUNIT_CHR;
//                    objValues[7][iRow] = m_objDetailArr[iRow].m_dblIPAMOUNT_INT;
//                    objValues[8][iRow] = m_objDetailArr[iRow].m_strIPUNIT_CHR;
//                    objValues[9][iRow] = m_objDetailArr[iRow].m_dblPACKQTY_DEC;
//                    objValues[10][iRow] = m_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT;
//                    objValues[11][iRow] = m_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT;
//                    objValues[12][iRow] = m_objDetailArr[iRow].m_dblOPRETAILPRICE_INT;
//                    objValues[13][iRow] = m_objDetailArr[iRow].m_dblIPRETAILPRICE_INT;
//                    objValues[14][iRow] = m_objDetailArr[iRow].m_strLOTNO_VCHR;
//                    objValues[15][iRow] = m_objDetailArr[iRow].m_datVALIDPERIOD_DAT;
//                    objValues[16][iRow] = m_objDetailArr[iRow].m_intSTATUS;
//                    objValues[17][iRow] = m_objDetailArr[iRow].m_strINSTOREID_VCHR;
//                    objValues[18][iRow] = m_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT;
//                    objValues[19][iRow] = m_objDetailArr[iRow].m_strPRODUCTORID_CHR;
//                }
//                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

                //保存即审核
                if (p_intCommitFolow == 1)// && p_objDetailVoArr != null && p_objDetailVoArr.Length > 0)
                {
                    if (p_objDetailVoArr != null && p_objDetailVoArr.Length > 0)
                    {
                        lngRes = m_lngAddStorage(p_objPrincipal, ref p_objDetailVoArr, (short)p_intAddOrSubtract);
                        if (lngRes < 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception("保存库存出错");
                        }

                        if (lngRes > 0)//入帐
                        {
                            for (int i1 = 0; i1 < p_objDetailVoArr.Length; i1++)
                            {
                                p_objDetailVoArr[i1].m_strDSINSTOREID_VCHR = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                            }

                            //合并相同批号
                            m_hstCombine.Clear();
                            for (int i2 = 0; i2 < p_objDetailVoArr.Length; i2++)
                            {
                                for (int i3 = i2 + 1; i3 < p_objDetailVoArr.Length; i3++)
                                {
                                    if (p_objDetailVoArr[i3].m_strMEDICINEID_CHR == p_objDetailVoArr[i2].m_strMEDICINEID_CHR
                                        && p_objDetailVoArr[i3].m_strLOTNO_VCHR == p_objDetailVoArr[i2].m_strLOTNO_VCHR)
                                    {
                                        p_objDetailVoArr[i2].m_dblIPREALGROSS_INT += p_objDetailVoArr[i3].m_dblIPREALGROSS_INT;
                                        p_objDetailVoArr[i2].m_dblOPREALGROSS_INT += p_objDetailVoArr[i3].m_dblOPREALGROSS_INT;

                                        p_objDetailVoArr[i2].m_dblOldIPREALGROSS_INT += p_objDetailVoArr[i3].m_dblOldIPREALGROSS_INT;
                                        p_objDetailVoArr[i2].m_dblOldOPREALGROSS_INT += p_objDetailVoArr[i3].m_dblOldOPREALGROSS_INT;
                                    }
                                }
                                for (int i5 = 0; i5 < m_objDetailCombine.Length; i5++)
                                {
                                    if (m_objDetailCombine[i5].m_strMEDICINEID_CHR == p_objDetailVoArr[i2].m_strMEDICINEID_CHR
                                        && m_objDetailCombine[i5].m_strLOTNO_VCHR == p_objDetailVoArr[i2].m_strLOTNO_VCHR
                                        && m_objDetailCombine[i5].m_dblOPAMOUNT_INT != 0)
                                    {
                                        p_objDetailVoArr[i2].m_lngRELATEDSERIESID_INT = m_objDetailCombine[i5].m_lngSERIESID_INT;
                                        if (!m_hstCombine.ContainsKey(p_objDetailVoArr[i2].m_strMEDICINEID_CHR + p_objDetailVoArr[i2].m_strLOTNO_VCHR))
                                        {
                                            m_hstCombine.Add(p_objDetailVoArr[i2].m_strMEDICINEID_CHR + p_objDetailVoArr[i2].m_strLOTNO_VCHR, p_objDetailVoArr[i2].m_dblOPREALGROSS_INT);
                                        }
                                        break;
                                    }
                                }                                
                            }

                            clsDS_StorageDetail_VO[] m_objStorageDetailCombine = new clsDS_StorageDetail_VO[m_hstCombine.Count];//liuyingrui 2008-10-24
                            //List<clsDS_StorageDetail_VO> m_objList = new List<clsDS_StorageDetail_VO>();
                            //clsDS_StorageDetail_VO m_objTempVo = null ;
                            m_intCount = 0;
                            foreach (DictionaryEntry de in m_hstCombine)
                            {
                                for (int i4 = 0; i4 < p_objDetailVoArr.Length; i4++)
                                {
                                    if (p_objDetailVoArr[i4].m_strMEDICINEID_CHR + p_objDetailVoArr[i4].m_strLOTNO_VCHR == de.Key.ToString())
                                    {
                                        m_objStorageDetailCombine[m_intCount] = new clsDS_StorageDetail_VO();
                                        p_objDetailVoArr[i4].m_mthCopyTo(m_objStorageDetailCombine[m_intCount]);
                                        //m_objTempVo = new clsDS_StorageDetail_VO();
                                        //p_objDetailVoArr[i4].m_mthCopyTo(m_objTempVo);
                                        //m_objList.Add(m_objTempVo);
                                        m_intCount++;
                                        break;
                                    }
                                }
                            }
                            
                           lngRes = m_lngAddNewAccountDetail(p_objPrincipal, m_objStorageDetailCombine);
                            //lngRes = m_lngAddNewAccountDetail(p_objPrincipal, m_objList.ToArray());
                        }
                        if (lngRes <= 0)
                        {
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            throw new Exception("添加药房流水帐表出错");
                        }
                    }
                    lngRes = m_lngInstorageSetExamer(p_strExamerID, m_objMainVo.m_lngSERIESID_INT);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("设置审核者出错");
                    }

                    clsAskForMedicineSVC AskSvc = new clsAskForMedicineSVC();
                    lngRes = AskSvc.m_lngExamAskInfo(p_objPrincipal, p_lngAskSeqid, p_intState, m_objMainVo.m_strINDRUGSTOREID_VCHR);
                    if (lngRes <= 0)
                    {
                        objHRPServ.Dispose();
                        objHRPServ = null;
                        throw new Exception("更新请领单状态出错");
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

        #region 根据流水号获取药房入库明细
        /// <summary>
        /// 根据流水号获取药房入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetailByID(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSeqid, out clsDS_StorageDetail_VO[] m_objDetailVoArr, int m_intType)
        {
            long lngRes = 0;
            m_objDetailVoArr = null;
            DataTable dt = new DataTable();
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medspec_vchr,
       a.opamount_int,
       a.opunit_chr,
       a.ipamount_int,
       a.ipunit_chr,
       a.packqty_dec,
       a.opwholesaleprice_int,
       a.ipwholesaleprice_int,
       a.opretailprice_int,
       a.ipretailprice_int,
       a.lotno_vchr,
       a.validperiod_dat,
       a.status,
       a.medicinename_vchr,
       b.assistcode_chr,
       a.instoreid_vchr,
       c.drugstoreid_chr,
       a.instoragedate_dat,
       c.indrugstoreid_vchr,
       c.drugstoreexam_date,
       c.formtype_int,
       c.makeorder_dat,
       b.medicinetypeid_chr,
       a.productorid_chr
  from t_ds_instorage_detail a, t_bse_medicine b, t_ds_instorage c
 where a.medicineid_chr = b.medicineid_chr(+)
   and a.status = 1
   and a.seriesid2_int = ?
   and a.seriesid2_int = c.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDataParm);
                m_objDetailVoArr = new clsDS_StorageDetail_VO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_objDetailVoArr[i] = new clsDS_StorageDetail_VO();
                    m_objDetailVoArr[i].m_dblIPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["ipamount_int"]);
                    m_objDetailVoArr[i].m_dblIPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipretailprice_int"]);
                    m_objDetailVoArr[i].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipwholesaleprice_int"]);
                    m_objDetailVoArr[i].m_dblOPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["opamount_int"]);
                    m_objDetailVoArr[i].m_dblOPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["opretailprice_int"]);
                    m_objDetailVoArr[i].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["opwholesaleprice_int"]);
                    m_objDetailVoArr[i].m_dblPACKQTY_DEC = Convert.ToDouble(dt.Rows[i]["packqty_dec"]);

                    m_objDetailVoArr[i].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["instoragedate_dat"]);
                    m_objDetailVoArr[i].m_dtmDSINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["makeorder_dat"]);
                    m_objDetailVoArr[i].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(dt.Rows[i]["validperiod_dat"]);

                    m_objDetailVoArr[i].m_strDRUGSTOREID_CHR = Convert.ToString(dt.Rows[i]["drugstoreid_chr"]);
                    m_objDetailVoArr[i].m_strINSTOREID_VCHR = Convert.ToString(dt.Rows[i]["instoreid_vchr"]);
                    m_objDetailVoArr[i].m_strIPUNIT_CHR = Convert.ToString(dt.Rows[i]["ipunit_chr"]);
                    m_objDetailVoArr[i].m_strLOTNO_VCHR = Convert.ToString(dt.Rows[i]["lotno_vchr"]);
                    m_objDetailVoArr[i].m_strMEDICINEID_CHR = Convert.ToString(dt.Rows[i]["medicineid_chr"]);
                    m_objDetailVoArr[i].m_strMEDICINETYPEID_CHR = Convert.ToString(dt.Rows[i]["medicinetypeid_chr"]);
                    m_objDetailVoArr[i].m_strMEDICINENAME_VCHR = Convert.ToString(dt.Rows[i]["medicinename_vchr"]);
                    m_objDetailVoArr[i].m_strMEDSPEC_VCHR = Convert.ToString(dt.Rows[i]["medspec_vchr"]);
                    m_objDetailVoArr[i].m_strOPUNIT_CHR = Convert.ToString(dt.Rows[i]["opunit_chr"]);
                    m_objDetailVoArr[i].STATUS = Convert.ToInt16(dt.Rows[i]["status"]);
                    m_objDetailVoArr[i].m_strDSINSTOREID_VCHR = Convert.ToString(dt.Rows[i]["indrugstoreid_vchr"]);
                    m_objDetailVoArr[i].m_dtmDSINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["makeorder_dat"]);
                    m_objDetailVoArr[i].m_strPRODUCTORID_CHR = dt.Rows[i]["productorid_chr"].ToString();
                    m_objDetailVoArr[i].m_intType = Convert.ToInt16(dt.Rows[i]["formtype_int"]);
                    m_objDetailVoArr[i].m_lngRELATEDSERIESID_INT = Convert.ToInt64(dt.Rows[i]["seriesid_int"]);
                    //if (m_objDetailVoArr[i].m_dblOPREALGROSS_INT < 0)
                    //{
                    //    this.m_lngGetCurrentGrossByConditions(m_objDetailVoArr[i].m_strDRUGSTOREID_CHR, m_objDetailVoArr[i].m_strLOTNO_VCHR, m_objDetailVoArr[i].m_strMEDICINEID_CHR, m_objDetailVoArr[i].m_dtmINSTORAGEDATE_DAT, ref   m_objDetailVoArr[i].m_dblOldOPREALGROSS_INT, ref   m_objDetailVoArr[i].m_dblOldIPREALGROSS_INT);
                    //    if (Math.Abs(m_objDetailVoArr[i].m_dblOPREALGROSS_INT) > m_objDetailVoArr[i].m_dblOldOPREALGROSS_INT)
                    //    {
                    //        m_blnHasGross = false;
                    //        throw new Exception();
                    //    }
                    //}
                }
                if (lngRes > 0)
                {
                    if (m_intType == 1)
                    {
                        lngRes = this.m_lngAddStorage(null, ref m_objDetailVoArr, 1);
                        if (lngRes > 0)
                            this.m_lngAddNewAccountDetail(p_objPrincipal, m_objDetailVoArr);
                    }
                    else if (m_intType == 2)//退审
                    {
                        lngRes = this.m_lngSubtractStorage(null, m_objDetailVoArr, 2);
                        if (m_objDetailVoArr.Length > 0)
                        {
                            lngRes = this.m_lngUpdateAccountDetail(p_objPrincipal, m_objDetailVoArr[0].m_strDRUGSTOREID_CHR, m_objDetailVoArr[0].m_strDSINSTOREID_VCHR);
                        }
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

        #region 根据流水号获取药房入库明细
        /// <summary>
        /// 根据流水号获取药房入库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInstorageDetailByID(System.Security.Principal.IPrincipal p_objPrincipal, long m_lngSeqid, out clsDS_StorageDetail_VO[] m_objDetailVoArr, int m_intType, out bool m_blnHasGross, out string m_strMedName)
        {
            m_blnHasGross = true;
            m_strMedName = "";
            long lngRes = 0;
            m_objDetailVoArr = null;
            DataTable dt = new DataTable();
            try
            {
                string strSQL = @"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medspec_vchr,
       a.opamount_int,
       a.opunit_chr,
       a.ipamount_int,
       a.ipunit_chr,
       a.packqty_dec,
       a.opwholesaleprice_int,
       a.ipwholesaleprice_int,
       a.opretailprice_int,
       a.ipretailprice_int,
       a.lotno_vchr,
       a.validperiod_dat,
       a.status,
       a.medicinename_vchr,
       b.assistcode_chr,
       a.instoreid_vchr,
       c.drugstoreid_chr,
       a.instoragedate_dat,
       c.indrugstoreid_vchr,
       c.drugstoreexam_date,
       c.formtype_int,
       c.makeorder_dat,
       b.medicinetypeid_chr,
       a.productorid_chr
  from t_ds_instorage_detail a, t_bse_medicine b, t_ds_instorage c
 where a.medicineid_chr = b.medicineid_chr(+)
   and a.status = 1
   and a.seriesid2_int = ?
   and a.seriesid2_int = c.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objDataParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objDataParm);
                objDataParm[0].Value = m_lngSeqid;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dt, objDataParm);
                m_objDetailVoArr = new clsDS_StorageDetail_VO[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_objDetailVoArr[i] = new clsDS_StorageDetail_VO();
                    m_objDetailVoArr[i].m_dblIPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["ipamount_int"]);
                    m_objDetailVoArr[i].m_dblIPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipretailprice_int"]);
                    m_objDetailVoArr[i].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["ipwholesaleprice_int"]);
                    m_objDetailVoArr[i].m_dblOPREALGROSS_INT = Convert.ToDouble(dt.Rows[i]["opamount_int"]);
                    m_objDetailVoArr[i].m_dblOPRETAILPRICE_INT = Convert.ToDouble(dt.Rows[i]["opretailprice_int"]);
                    m_objDetailVoArr[i].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(dt.Rows[i]["opwholesaleprice_int"]);
                    m_objDetailVoArr[i].m_dblPACKQTY_DEC = Convert.ToDouble(dt.Rows[i]["packqty_dec"]);

                    m_objDetailVoArr[i].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["instoragedate_dat"]);
                    m_objDetailVoArr[i].m_dtmDSINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["makeorder_dat"]);
                    m_objDetailVoArr[i].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(dt.Rows[i]["validperiod_dat"]);

                    m_objDetailVoArr[i].m_strDRUGSTOREID_CHR = Convert.ToString(dt.Rows[i]["drugstoreid_chr"]);
                    m_objDetailVoArr[i].m_strINSTOREID_VCHR = Convert.ToString(dt.Rows[i]["instoreid_vchr"]);
                    m_objDetailVoArr[i].m_strIPUNIT_CHR = Convert.ToString(dt.Rows[i]["ipunit_chr"]);
                    m_objDetailVoArr[i].m_strLOTNO_VCHR = Convert.ToString(dt.Rows[i]["lotno_vchr"]);
                    m_objDetailVoArr[i].m_strMEDICINEID_CHR = Convert.ToString(dt.Rows[i]["medicineid_chr"]);
                    m_objDetailVoArr[i].m_strMEDICINETYPEID_CHR = Convert.ToString(dt.Rows[i]["medicinetypeid_chr"]);
                    m_objDetailVoArr[i].m_strMEDICINENAME_VCHR = Convert.ToString(dt.Rows[i]["medicinename_vchr"]);
                    m_objDetailVoArr[i].m_strMEDSPEC_VCHR = Convert.ToString(dt.Rows[i]["medspec_vchr"]);
                    m_objDetailVoArr[i].m_strOPUNIT_CHR = Convert.ToString(dt.Rows[i]["opunit_chr"]);
                    m_objDetailVoArr[i].STATUS = Convert.ToInt16(dt.Rows[i]["status"]);
                    m_objDetailVoArr[i].m_strDSINSTOREID_VCHR = Convert.ToString(dt.Rows[i]["indrugstoreid_vchr"]);
                    m_objDetailVoArr[i].m_dtmDSINSTORAGEDATE_DAT = Convert.ToDateTime(dt.Rows[i]["drugstoreexam_date"]);
                    m_objDetailVoArr[i].m_strPRODUCTORID_CHR = dt.Rows[i]["productorid_chr"].ToString();
                    m_objDetailVoArr[i].m_intType = Convert.ToInt16(dt.Rows[i]["formtype_int"]);
                    m_objDetailVoArr[i].m_lngRELATEDSERIESID_INT = Convert.ToInt64(dt.Rows[i]["seriesid_int"]);
                    //if (m_objDetailVoArr[i].m_dblOPREALGROSS_INT < 0)
                    //{
                    //    this.m_lngGetCurrentGrossByConditions(m_objDetailVoArr[i].m_strDRUGSTOREID_CHR, m_objDetailVoArr[i].m_strLOTNO_VCHR, m_objDetailVoArr[i].m_strMEDICINEID_CHR, m_objDetailVoArr[i].m_dtmINSTORAGEDATE_DAT, ref   m_objDetailVoArr[i].m_dblOldOPREALGROSS_INT, ref   m_objDetailVoArr[i].m_dblOldIPREALGROSS_INT);
                    //    if (Math.Abs(m_objDetailVoArr[i].m_dblOPREALGROSS_INT) > m_objDetailVoArr[i].m_dblOldOPREALGROSS_INT)
                    //    {
                    //        m_strMedName = m_objDetailVoArr[i].m_strMEDICINENAME_VCHR;
                    //        m_blnHasGross = false;
                    //        throw new Exception();
                    //    }
                    //}
                }
                if (lngRes > 0)
                {
                    if (m_intType == 1)
                    {
                        lngRes = this.m_lngAddStorage(null, ref m_objDetailVoArr, 1);
                        if (lngRes > 0)
                            this.m_lngAddNewAccountDetail(p_objPrincipal, m_objDetailVoArr);
                    }
                    else if (m_intType == 2)//退审
                    {
                        lngRes = this.m_lngSubtractStorage(null, m_objDetailVoArr, 2);
                        if (m_objDetailVoArr.Length > 0)
                        {
                            lngRes = this.m_lngUpdateAccountDetail(p_objPrincipal, m_objDetailVoArr[0].m_strDRUGSTOREID_CHR, m_objDetailVoArr[0].m_strDSINSTOREID_VCHR);
                        }
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


    }

}
