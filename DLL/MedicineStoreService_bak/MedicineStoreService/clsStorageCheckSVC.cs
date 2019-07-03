using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.security;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品盘点
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
  　public class clsStorageCheckSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
       #region 获取盘点主表
        /// <summary>
        /// 获取盘点主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_dtmStarDate">开始时间</param>
        /// <param name="m_dtmEndDate">结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbStorageCheck">盘点主表数据</param>
        /// <returns></returns>
       [AutoComplete]
       public long m_lngGetStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, DateTime m_dtmStarDate, DateTime m_dtmEndDate,string p_strStorageID, out DataTable p_dtbStorageCheck)
       {
           p_dtbStorageCheck = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select distinct  t.inaccountdate_dat,
                t.inaccountid_chr,
                t.examerid_chr,
                t.askerid_chr,
                t.examdate_dat,
                t.askdate_dat,
                t.status,
                t.checkid_chr,
                t.storageid_chr,
                t.seriesid_int,
                to_char(t.checkdate_dat,'yyyy-mm-dd hh24:mi:ss') as checkdate_dat,
                case t.status
                  when 0 then
                   '作废'
                  when 1 then
                   '新制'
                  when 2 then
                   '审核'
                  when 3 then
                   '入帐'
                end statusdesc,
                ea.lastname_vchr examername,
                eb.lastname_vchr askername
  from t_ms_storagecheck t
 inner join t_ms_storagecheck_detail de on t.seriesid_int =
                                           de.seriesid2_int
                                       and de.status_int = 1
  left outer join t_bse_employee ea on t.examerid_chr = ea.empid_chr
  left outer join t_bse_employee eb on t.askerid_chr = eb.empid_chr
 where t.status <> 0
   and t.checkdate_dat between ? and ?
   and t.storageid_chr = ?
 order by t.checkid_chr";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(3, out objDPArr);
               objDPArr[0].DbType = DbType.DateTime;
               objDPArr[0].Value = m_dtmStarDate;
               objDPArr[1].DbType = DbType.DateTime;
               objDPArr[1].Value = m_dtmEndDate;
               objDPArr[2].Value = p_strStorageID;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbStorageCheck, objDPArr);
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }
        #endregion

       #region 获取盘点明细
       /// <summary>
       /// 获取盘点明细
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_lngMainSEQ">主表序列</param>
       /// <param name="p_dtbStorageCheck_detail">明细表数据</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetStorageCheck_detail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbStorageCheck_detail)
       {
           p_dtbStorageCheck_detail = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select t.seriesid_int,
       t.seriesid2_int,
       t.medicineid_chr,
       t.medicinename_vch,
       t.medspec_vchr,
       t.opunit_chr,
       case
            when t.lotno_vchr = 'UNKNOWN' then
             ''
            else
                t.lotno_vchr
            end lotno_vchr,
       t.currentgross_int,
       t.validperiod_dat,
       t.checkgross_int,
       t.productorid_chr,
       t.retailprice_int,
       t.callprice_int,
       t.wholesaleprice_int,
       t.checkreason_vchr,
       t.checkresult_int,
       t.iszero_int,
       t.modifier_chr,
       t.modifydate_dat,
       t.status_int,
       t.instorageid_vchr,
       t.vendorid_chr,
       m.assistcode_chr,
       m.medicinetypeid_chr,
       d.checkmedicineorder_chr,
       c.medicinepreptype_chr,
       c.medicinepreptypename_vchr,
       e.storagerackcode_vchr,
       h.medicinetypename_vchr
  from t_ms_storagecheck_detail t
 inner join t_ms_storagecheck f on t.seriesid2_int = f.seriesid_int
                               and f.status <> 0
 inner join t_bse_medicine m on t.medicineid_chr = m.medicineid_chr
 inner join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        m.medicinepreptype_chr
 left outer join t_ms_checkmedicineorder d on d.medicineid_chr =
                                         t.medicineid_chr
                                     and f.storageid_chr = d.storageid_chr
 left outer join t_ms_storagerackset e on e.storagerackid_chr =
                                     d.storagerackid_chr
                                 and e.storageid_chr = d.storageid_chr
 inner join t_aid_medicinetype h on h.medicinetypeid_chr =
                                        m.medicinetypeid_chr
 where t.status_int = 1
   and t.seriesid2_int = ?
 order by t.seriesid_int";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_lngMainSEQ;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbStorageCheck_detail, objDPArr);
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;

       }
        #endregion

       
       #region 添加盘点主表信息
       /// <summary>
       /// 添加盘点主表信息
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objSCVO">盘点主表信息</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngAddNewStorageCheckMain(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_StorageCheck_VO p_objSCVO)
       {
           if (p_objSCVO == null)
           {
               return -1;
           }

           long lngRes = 0;
           try
           {
               string strSQL = @"insert into t_ms_storagecheck
  (seriesid_int,
   storageid_chr,
   checkid_chr,
   status,
   askdate_dat,
   examdate_dat,
   askerid_chr,
   examerid_chr,
   inaccountid_chr,
   inaccountdate_dat,
   checkdate_dat)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

               clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
               long lngSEQ = 0;
               lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_STORAGECHECK", out lngSEQ);
               if (lngSEQ <= 0)
               {
                   return -1;
               }
               p_objSCVO.m_lngSeriesID_INT = lngSEQ;

               string strCheckID = string.Empty;
               lngRes = m_lngGetLatestCheckID(p_objPrincipal, out strCheckID);
               if (lngRes < 0 || string.IsNullOrEmpty(strCheckID))
               {
                   return -1;
               }
               p_objSCVO.m_strCheckID_CHR = strCheckID;

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(11, out objDPArr);
               objDPArr[0].Value = p_objSCVO.m_lngSeriesID_INT;
               objDPArr[1].Value = p_objSCVO.m_strStorageID_CHR;
               objDPArr[2].Value = p_objSCVO.m_strCheckID_CHR;
               objDPArr[3].Value = p_objSCVO.m_intStatus_INT;
               objDPArr[4].DbType = DbType.DateTime;
               objDPArr[4].Value = p_objSCVO.m_dtmAskDate_DAT;
               objDPArr[5].DbType = DbType.DateTime;
               objDPArr[5].Value = p_objSCVO.m_dtmExamDate_DAT;
               objDPArr[6].Value = p_objSCVO.m_strAskerID_CHR;
               objDPArr[7].Value = p_objSCVO.m_strExamerID_CHR;
               objDPArr[8].Value = p_objSCVO.m_strInaccountID_CHR;
               objDPArr[9].DbType = DbType.DateTime;
               objDPArr[9].Value = p_objSCVO.m_dtmInaccountDate_DAT;
               objDPArr[10].DbType = DbType.DateTime;
               objDPArr[10].Value = p_objSCVO.m_dtmCheckDate;

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

       #region 添加盘点明细
       /// <summary>
       /// 添加盘点明细
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objDetailVO">盘点明细</param>
       /// <param name="p_lngSEQArr">明细序列</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngAddNewStorageCheckDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageCheckDetail_VO[] p_objDetailVO, out long[] p_lngSEQArr)
       {
           p_lngSEQArr = null;
           if (p_objDetailVO == null || p_objDetailVO.Length == 0)
           {
               return -1;
           }

           long lngRes = 0;
           try
           {
               string strSQL = @"insert into t_ms_storagecheck_detail
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   opunit_chr,
   lotno_vchr,
   validperiod_dat,
   currentgross_int,
   checkgross_int,
   productorid_chr,
   retailprice_int,
   callprice_int,
   wholesaleprice_int,
   checkreason_vchr,
   checkresult_int,
   iszero_int,
   modifier_chr,
   modifydate_dat,
   status_int,
   instorageid_vchr,
   vendorid_chr)
VALUES
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

               clsHRPTableService objHRPServ = new clsHRPTableService();

               clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGECHECK_DETAIL", p_objDetailVO.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }
                    p_lngSEQArr = lngSEQArr;

                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    for (int iRow = 0; iRow < lngSEQArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(22, out objLisAddItemRefArr);
                        //Please change the datetime and reocrdid 
                        p_objDetailVO[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objLisAddItemRefArr[0].Value = p_objDetailVO[iRow].m_lngSERIESID_INT;
                        objLisAddItemRefArr[1].Value = p_objDetailVO[iRow].m_lngSERIESID2_INT;
                        objLisAddItemRefArr[2].Value = p_objDetailVO[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[3].Value = p_objDetailVO[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[4].Value = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[5].Value = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[6].Value = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[7].DbType = DbType.DateTime;
                        objLisAddItemRefArr[7].Value = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objLisAddItemRefArr[8].Value = p_objDetailVO[iRow].m_dblCURRENTGROSS_INT;
                        objLisAddItemRefArr[9].Value = p_objDetailVO[iRow].m_dblCHECKGROSS_INT;
                        objLisAddItemRefArr[10].Value = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objLisAddItemRefArr[11].Value = p_objDetailVO[iRow].m_dblRETAILPRICE_INT;
                        objLisAddItemRefArr[12].Value = p_objDetailVO[iRow].m_dblCALLPRICE_INT;
                        objLisAddItemRefArr[13].Value = p_objDetailVO[iRow].m_dblWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[14].Value = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objLisAddItemRefArr[15].Value = p_objDetailVO[iRow].m_dblCHECKRESULT_INT;
                        objLisAddItemRefArr[16].Value = p_objDetailVO[iRow].m_intISZERO_INT;
                        objLisAddItemRefArr[17].Value = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objLisAddItemRefArr[18].DbType = DbType.DateTime;
                        objLisAddItemRefArr[18].Value = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objLisAddItemRefArr[19].Value = 1;
                        objLisAddItemRefArr[20].Value = p_objDetailVO[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[21].Value = p_objDetailVO[iRow].m_strVendorID;
                        
                        //往表增加记录
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }                    
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.DateTime,DbType.Double,DbType.Double,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Double,
                        DbType.Int32,DbType.String,DbType.DateTime,DbType.Int32,DbType.String, DbType.String};

                    object[][] objValues = new object[22][];

                    int intItemCount = p_objDetailVO.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_STORAGECHECK_DETAIL", intItemCount, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }
                    p_lngSEQArr = lngSEQArr;

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        p_objDetailVO[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objDetailVO[iRow].m_lngSERIESID2_INT;
                        objValues[2][iRow] = p_objDetailVO[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objDetailVO[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                        objValues[6][iRow] = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                        objValues[7][iRow] = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                        objValues[8][iRow] = p_objDetailVO[iRow].m_dblCURRENTGROSS_INT;
                        objValues[9][iRow] = p_objDetailVO[iRow].m_dblCHECKGROSS_INT;
                        objValues[10][iRow] = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                        objValues[11][iRow] = p_objDetailVO[iRow].m_dblRETAILPRICE_INT;
                        objValues[12][iRow] = p_objDetailVO[iRow].m_dblCALLPRICE_INT;
                        objValues[13][iRow] = p_objDetailVO[iRow].m_dblWHOLESALEPRICE_INT;
                        objValues[14][iRow] = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                        objValues[15][iRow] = p_objDetailVO[iRow].m_dblCHECKRESULT_INT;
                        objValues[16][iRow] = p_objDetailVO[iRow].m_intISZERO_INT;
                        objValues[17][iRow] = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                        objValues[18][iRow] = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                        objValues[19][iRow] = 1;
                        objValues[20][iRow] = p_objDetailVO[iRow].m_strINSTORAGEID_VCHR;
                        objValues[21][iRow] = p_objDetailVO[iRow].m_strVendorID;
                    }
                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }
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

       #region 最新的盘点号

       /// <summary>
       /// 最新的盘点号
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strID">返回单据号</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetLatestCheckID(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strID)
       {
           p_strID = string.Empty;

           long lngRes = -1;
           try
           {
               string strSQL = @"select max(t.checkid_chr)
  from t_ms_storagecheck t
 where t.checkid_chr like ?";

               DataTable dtbValue = null;
               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = DateTime.Now.ToString("yyyyMMdd") + "6%";

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

               if (dtbValue == null || dtbValue.Rows.Count == 0)
               {
                   p_strID = DateTime.Now.ToString("yyyyMMdd") + "60001";
               }
               else
               {
                   string strTemp = dtbValue.Rows[0][0].ToString();
                   if (string.IsNullOrEmpty(strTemp))
                   {
                       p_strID = DateTime.Now.ToString("yyyyMMdd") + "60001";
                   }
                   else
                   {
                       strTemp = strTemp.Substring(9, 4);
                       p_strID = DateTime.Now.ToString("yyyyMMdd") + "6" + (Convert.ToInt32(strTemp) + 1).ToString("0000");
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

       #region 修改盘点主表
       /// <summary>
       /// 修改盘点主表
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objSCVO">盘点主表信息</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngMofifyStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageCheck_VO p_objSCVO)
       {
           if (p_objSCVO == null)
           {
               return -1;
           }

           long lngRes = 0;
           try
           {
               string strSQL = @"update t_ms_storagecheck
   set storageid_chr     = ?,
       checkid_chr       = ?,
       status            = ?,
       askdate_dat       = ?,
       examdate_dat      = ?,
       askerid_chr       = ?,
       examerid_chr      = ?,
       inaccountid_chr   = ?,
       inaccountdate_dat = ?,
       checkdate_dat     = ?
 where seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(11, out objDPArr);
               objDPArr[0].Value = p_objSCVO.m_strStorageID_CHR;
               objDPArr[1].Value = p_objSCVO.m_strCheckID_CHR;
               objDPArr[2].Value = p_objSCVO.m_intStatus_INT;
               objDPArr[3].DbType = DbType.DateTime;
               objDPArr[3].Value = p_objSCVO.m_dtmAskDate_DAT;
               objDPArr[4].DbType = DbType.DateTime;
               objDPArr[4].Value = p_objSCVO.m_dtmExamDate_DAT;
               objDPArr[5].Value = p_objSCVO.m_strAskerID_CHR;
               objDPArr[6].Value = p_objSCVO.m_strExamerID_CHR;
               objDPArr[7].Value = p_objSCVO.m_strInaccountID_CHR;
               objDPArr[8].DbType = DbType.DateTime;
               objDPArr[8].Value = p_objSCVO.m_dtmInaccountDate_DAT;
               objDPArr[9].DbType = DbType.DateTime;
               objDPArr[9].Value = p_objSCVO.m_dtmCheckDate;
               objDPArr[10].Value = p_objSCVO.m_lngSeriesID_INT;

               long lngEff = -1;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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
       public long m_lngModifyStorageCheckDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageCheckDetail_VO[] p_objDetailVO)
       {
           if (p_objDetailVO == null || p_objDetailVO.Length == 0)
           {
               return -1;
           }

           long lngRes = 0;
           try
           {
               string strSQL = @"update t_ms_storagecheck_detail
   set medicineid_chr     = ?,
       medicinename_vch   = ?,
       medspec_vchr       = ?,
       opunit_chr         = ?,
       lotno_vchr         = ?,
       validperiod_dat    = ?,
       currentgross_int   = ?,
       checkgross_int     = ?,
       productorid_chr    = ?,
       retailprice_int    = ?,
       callprice_int      = ?,
       wholesaleprice_int = ?,
       checkreason_vchr   = ?,
       checkresult_int    = ?,
       iszero_int         = ?,
       modifier_chr       = ?,
       modifydate_dat     = ?,
       status_int         = ?,
       instorageid_vchr   = ?
 where seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               long lngEff = -1;
               if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
               {
                   System.Data.IDataParameter[] objLisAddItemRefArr = null;
                   for (int iRow = 0; iRow < p_objDetailVO.Length; iRow++)
                   {
                       objHRPServ.CreateDatabaseParameter(20, out objLisAddItemRefArr);
                       //Please change the datetime and reocrdid 
                       objLisAddItemRefArr[0].Value = p_objDetailVO[iRow].m_strMEDICINEID_CHR;
                       objLisAddItemRefArr[1].Value = p_objDetailVO[iRow].m_strMEDICINENAME_VCH;
                       objLisAddItemRefArr[2].Value = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                       objLisAddItemRefArr[3].Value = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                       objLisAddItemRefArr[4].Value = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                       objLisAddItemRefArr[5].DbType = DbType.DateTime;
                       objLisAddItemRefArr[5].Value = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                       objLisAddItemRefArr[6].Value = p_objDetailVO[iRow].m_dblCURRENTGROSS_INT;
                       objLisAddItemRefArr[7].Value = p_objDetailVO[iRow].m_dblCHECKGROSS_INT;
                       objLisAddItemRefArr[8].Value = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                       objLisAddItemRefArr[9].Value = p_objDetailVO[iRow].m_dblRETAILPRICE_INT;
                       objLisAddItemRefArr[10].Value = p_objDetailVO[iRow].m_dblCALLPRICE_INT;
                       objLisAddItemRefArr[11].Value = p_objDetailVO[iRow].m_dblWHOLESALEPRICE_INT;
                       objLisAddItemRefArr[12].Value = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                       objLisAddItemRefArr[13].Value = p_objDetailVO[iRow].m_dblCHECKRESULT_INT;
                       objLisAddItemRefArr[14].Value = p_objDetailVO[iRow].m_intISZERO_INT;
                       objLisAddItemRefArr[15].Value = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                       objLisAddItemRefArr[16].DbType = DbType.DateTime;
                       objLisAddItemRefArr[16].Value = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                       objLisAddItemRefArr[17].Value = p_objDetailVO[iRow].m_intSTATUS_INT;
                       objLisAddItemRefArr[18].Value = p_objDetailVO[iRow].m_strINSTORAGEID_VCHR;
                       objLisAddItemRefArr[19].Value = p_objDetailVO[iRow].m_lngSERIESID_INT;

                       //往表增加记录
                       lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                   }
               }
               else
               {
                   DbType[] dbTypes = new DbType[] { DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        DbType.DateTime,DbType.Double,DbType.Double,DbType.String,DbType.Double,DbType.Double,DbType.Double,DbType.String,DbType.Double,
                        DbType.Int32,DbType.String,DbType.DateTime,DbType.Int32,DbType.String,DbType.Int64};

                   object[][] objValues = new object[20][];

                   int intItemCount = p_objDetailVO.Length;
                   for (int j = 0; j < objValues.Length; j++)
                   {
                       objValues[j] = new object[intItemCount];//初始化

                   }

                   for (int iRow = 0; iRow < intItemCount; iRow++)
                   {
                       objValues[0][iRow] = p_objDetailVO[iRow].m_strMEDICINEID_CHR;
                       objValues[1][iRow] = p_objDetailVO[iRow].m_strMEDICINENAME_VCH;
                       objValues[2][iRow] = p_objDetailVO[iRow].m_strMEDSPEC_VCHR;
                       objValues[3][iRow] = p_objDetailVO[iRow].m_strOPUNIT_CHR;
                       objValues[4][iRow] = p_objDetailVO[iRow].m_strLOTNO_VCHR;
                       objValues[5][iRow] = p_objDetailVO[iRow].m_dtmVALIDPERIOD_DAT;
                       objValues[6][iRow] = p_objDetailVO[iRow].m_dblCURRENTGROSS_INT;
                       objValues[7][iRow] = p_objDetailVO[iRow].m_dblCHECKGROSS_INT;
                       objValues[8][iRow] = p_objDetailVO[iRow].m_strPRODUCTORID_CHR;
                       objValues[9][iRow] = p_objDetailVO[iRow].m_dblRETAILPRICE_INT;
                       objValues[10][iRow] = p_objDetailVO[iRow].m_dblCALLPRICE_INT;
                       objValues[11][iRow] = p_objDetailVO[iRow].m_dblWHOLESALEPRICE_INT;
                       objValues[12][iRow] = p_objDetailVO[iRow].m_strCHECKREASON_VCHR;
                       objValues[13][iRow] = p_objDetailVO[iRow].m_dblCHECKRESULT_INT;
                       objValues[14][iRow] = p_objDetailVO[iRow].m_intISZERO_INT;
                       objValues[15][iRow] = p_objDetailVO[iRow].m_strMODIFIER_CHR;
                       objValues[16][iRow] = p_objDetailVO[iRow].m_dtmMODIFYDATE_DAT;
                       objValues[17][iRow] = p_objDetailVO[iRow].m_intSTATUS_INT;
                       objValues[18][iRow] = p_objDetailVO[iRow].m_strINSTORAGEID_VCHR;
                       objValues[19][iRow] = p_objDetailVO[iRow].m_lngSERIESID_INT;
                   }
                   lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
               }
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
               string strSQL = @"update t_ms_storagecheck
   set status = 2, examerid_chr = ?, examdate_dat = ?
 where seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               long lngEff = -1;
               IDataParameter[] objDPArr = null;
               DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
               objHRPServ.CreateDatabaseParameter(3, out objDPArr);
               objDPArr[0].Value = p_strEmpID;
               objDPArr[1].DbType = DbType.DateTime;
               objDPArr[1].Value = dtmNow;
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
               string strSQL = @"update t_ms_storagecheck
   set status = 3, inaccountid_chr = ?, inaccountdate_dat = ?
 where checkid_chr = ? and storageid_chr = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
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
       public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID,DateTime p_dtmAccountDate, long p_lngSeq)
       {
           long lngRes = 0;
           try
           {
               string strSQL = @"update t_ms_storagecheck
   set status = 3, inaccountid_chr = ?, inaccountdate_dat = ?
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

           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }
       #endregion

       #region 获取有出库记录的盘盈药品
       /// <summary>
       /// 获取有出库记录的盘盈药品
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strCheckID">盘点ID</param>
       /// <param name="p_dtbOut">出库药品</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetHasOutCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, out DataTable p_dtbOut)
       {
           p_dtbOut = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select distinct t.medicineid_chr,        case
        when t.lotno_vchr = 'UNKNOWN' then
         ''
        else
            t.lotno_vchr
        end lotno_vchr, t.instorageid_vchr
  from t_ms_outstorage_detail t
 where t.instorageid_vchr = ?
   and t.status = 1";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOut, objDPArr);
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }
       #endregion

       #region 获取已保存至入库表的盘盈记录
       /// <summary>
       /// 获取已保存至入库表的盘盈记录
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strCheckID">盘点ID</param>
       /// <param name="p_dtbIn">入库药品记录</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetInCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, out DataTable p_dtbIn)
       {
           p_dtbIn = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select t.medicineid_chr,
              case
        when t.lotno_vchr = 'UNKNOWN' then
         ''
        else
            t.lotno_vchr
        end lotno_vchr,
       t.instorageid_vchr,
       t.seriesid_int,
       t.seriesid2_int,
       t.ruturnnum_int
  from t_ms_instorage_detal t, t_ms_instorage b
 where b.instorageid_vchr = ?
   and t.status = 1
   and t.seriesid2_int = b.seriesid_int
   and (b.state_int = 1 or b.state_int = 2)";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbIn, objDPArr);
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       } 
       #endregion

       #region 获取已保存至出库表的盘亏记录
       /// <summary>
       /// 获取已保存至出库表的盘亏记录
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strCheckID">盘点ID</param>
       /// <param name="p_dtbIn">出库药品记录</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetOutCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, out DataTable p_dtbIn)
       {
           p_dtbIn = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select t.medicineid_chr,
              case
        when t.lotno_vchr = 'UNKNOWN' then
         ''
        else
            t.lotno_vchr
        end lotno_vchr,
       t.instorageid_vchr,
       t.seriesid_int,
       t.seriesid2_int,
       t.returnnum_int
  from t_ms_outstorage_detail t, t_ms_outstorage b
 where b.outstorageid_vchr = ?
   and t.status = 1
   and t.seriesid2_int = b.seriesid_int
   and (b.status = 1 or b.status = 2)";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbIn, objDPArr);
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
               string strSQL = @"update t_ms_instorage_detal t set t.amount = ? where t.seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(2, out objDPArr);
               objDPArr[0].Value = p_dblAmount;
               objDPArr[1].Value = p_lngSEQ;

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
               string strSQL = @"update t_ms_outstorage_detail t
   set t.netamount_int = ?
 where t.seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(2, out objDPArr);
               objDPArr[0].Value = p_dblAmount;
               objDPArr[1].Value = p_lngSEQ;

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

       #region 保存盘盈数据至入库表
       /// <summary>
       /// 保存盘盈数据至入库表
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objInMain">入库主表信息</param>
       /// <param name="p_objInDetail">入库明细信息</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaveCheckToInStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_InStorage_VO p_objInMain, clsMS_InStorageDetail_VO p_objInDetail)
       {
           if (p_objInMain == null || p_objInDetail == null)
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
   returndept_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
               IDataParameter[] objLisAddItemRefArr = null;
               long lngSEQ = 0;
               lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_INSTORAGE", out lngSEQ);
               if (lngSEQ <= 0)
               {
                   return -1;
               }

               objHRPServ.CreateDatabaseParameter(24, out objLisAddItemRefArr);
               objLisAddItemRefArr[0].Value = lngSEQ;
               objLisAddItemRefArr[1].Value = p_objInMain.m_strINSTORAGEID_VCHR;
               objLisAddItemRefArr[2].Value = p_objInMain.m_intFORMTYPE_INT;
               objLisAddItemRefArr[3].Value = p_objInMain.m_intINSTORAGETYPE_INT;
               objLisAddItemRefArr[4].Value = p_objInMain.m_intSTATE_INT;
               objLisAddItemRefArr[5].Value = p_objInMain.m_strSTORAGEID_CHR;
               objLisAddItemRefArr[6].Value = p_objInMain.m_strVENDORID_CHR;
               objLisAddItemRefArr[7].Value = p_objInMain.m_strBUYERID_CHAR;
               objLisAddItemRefArr[8].Value = p_objInMain.m_strSTORAGERID_CHAR;
               objLisAddItemRefArr[9].Value = p_objInMain.m_strACCOUNTERID_CHAR;
               objLisAddItemRefArr[10].DbType = DbType.DateTime;
               objLisAddItemRefArr[10].Value = p_objInMain.m_dtmINSTORAGEDATE_DAT;
               objLisAddItemRefArr[11].DbType = DbType.DateTime;
               objLisAddItemRefArr[11].Value = p_objInMain.m_dtmNEWORDER_DAT;
               objLisAddItemRefArr[12].DbType = DbType.DateTime;
               objLisAddItemRefArr[12].Value = p_objInMain.m_dtmEXAM_DAT;
               objLisAddItemRefArr[13].DbType = DbType.DateTime;
               objLisAddItemRefArr[13].Value = p_objInMain.m_dtmACCOUNT_DAT;
               objLisAddItemRefArr[14].Value = p_objInMain.m_strSUPPLYCODE_VCHR;
               objLisAddItemRefArr[15].Value = p_objInMain.m_strINVOICECODE_VCHR;
               objLisAddItemRefArr[16].DbType = DbType.DateTime;
               objLisAddItemRefArr[16].Value = p_objInMain.m_dtmINVOICEDATER_DAT;
               objLisAddItemRefArr[17].Value = p_objInMain.m_intPAYSTATE_INT;
               objLisAddItemRefArr[18].DbType = DbType.DateTime;
               objLisAddItemRefArr[18].Value = p_objInMain.m_dtmPAYDATE_DAT;
               objLisAddItemRefArr[19].Value = p_objInMain.m_strCOMMNET_VCHR;
               objLisAddItemRefArr[20].Value = p_objInMain.m_strMAKERID_CHR;
               objLisAddItemRefArr[21].Value = p_objInMain.m_strEXAMERID_CHR;
               objLisAddItemRefArr[22].Value = p_objInMain.m_strINACCOUNTERID_CHR;
               objLisAddItemRefArr[23].Value = p_objInMain.m_strRETURNDEPT_CHR;
               long lngRecEff = -1;
               //往表增加记录
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

               if (lngRes <= 0)
               {
                   return -1;
               }

               strSQL = @"insert into t_ms_instorage_detal
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   packamount,
   packunit_vchr,
   packcallprice_int,
   packconvert_int,
   lotno_vchr,
   amount,
   callprice_int,
   wholesaleprice_int,
   retailprice_int,
   validperiod_dat,
   acceptance_int,
   approvecode_vchr,
   apparentquality_int,
   packquality_int,
   examrusult_int,
   examiner,
   productorid_chr,
   accountperiod_int,
   acceptancecompany_chr,
   unit_vchr,
   status,
   instorageid_vchr,
   ruturnnum_int,
   outstorageid_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

               long lngSubSEQ = 0;
               lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_INSTORAGEDETAIL", out lngSubSEQ);
               
               objHRPServ.CreateDatabaseParameter(29, out objLisAddItemRefArr);
               objLisAddItemRefArr[0].Value = lngSubSEQ;
               objLisAddItemRefArr[1].Value = lngSEQ;
               objLisAddItemRefArr[2].Value = p_objInDetail.m_strMEDICINEID_CHR;
               objLisAddItemRefArr[3].Value = p_objInDetail.m_strMEDICINENAME_VCH;
               objLisAddItemRefArr[4].Value = p_objInDetail.m_strMEDSPEC_VCHR;
               objLisAddItemRefArr[5].Value = p_objInDetail.m_dblPACKAMOUNT;
               objLisAddItemRefArr[6].Value = p_objInDetail.m_strPACKUNIT_VCHR;
               objLisAddItemRefArr[7].Value = p_objInDetail.m_dcmPACKCALLPRICE_INT;
               objLisAddItemRefArr[8].Value = p_objInDetail.m_dblPACKCONVERT_INT;
               objLisAddItemRefArr[9].Value = p_objInDetail.m_strLOTNO_VCHR;
               objLisAddItemRefArr[10].Value = p_objInDetail.m_dblAMOUNT;
               objLisAddItemRefArr[11].Value = p_objInDetail.m_dcmCALLPRICE_INT;
               objLisAddItemRefArr[12].Value = p_objInDetail.m_dcmWHOLESALEPRICE_INT;
               objLisAddItemRefArr[13].Value = p_objInDetail.m_dcmRETAILPRICE_INT;
               objLisAddItemRefArr[14].DbType = DbType.DateTime;
               objLisAddItemRefArr[14].Value = p_objInDetail.m_dtmVALIDPERIOD_DAT;
               objLisAddItemRefArr[15].Value = p_objInDetail.m_intACCEPTANCE_INT;
               objLisAddItemRefArr[16].Value = p_objInDetail.m_strAPPROVECODE_VCHR;
               objLisAddItemRefArr[17].Value = p_objInDetail.m_intAPPARENTQUALITY_INT;
               objLisAddItemRefArr[18].Value = p_objInDetail.m_intPACKQUALITY_INT;
               objLisAddItemRefArr[19].Value = p_objInDetail.m_intEXAMRUSULT_INT;
               objLisAddItemRefArr[20].Value = p_objInDetail.m_strEXAMINER;
               objLisAddItemRefArr[21].Value = p_objInDetail.m_strPRODUCTORID_CHR;
               objLisAddItemRefArr[22].Value = p_objInDetail.m_lngACCOUNTPERIOD_INT;
               objLisAddItemRefArr[23].Value = p_objInDetail.m_strACCEPTANCECOMPANY_CHR;
               objLisAddItemRefArr[24].Value = p_objInDetail.m_strUNIT_VCHR;
               objLisAddItemRefArr[25].Value = p_objInDetail.m_intStatus;
               objLisAddItemRefArr[26].Value = p_objInDetail.m_strInStorageID;
               objLisAddItemRefArr[27].Value = p_objInDetail.m_intRUTURNNUM_INT;
               objLisAddItemRefArr[28].Value = p_objInDetail.m_strOUTSTORAGEID_VCHR;
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

       #region 保存盘亏记录至出库表
       /// <summary>
       /// 保存盘亏记录至出库表
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objOutMain">出库主表信息</param>
       /// <param name="p_objOutDetail">出库明细信息</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaveCheckToOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO p_objOutDetail)
       {
           if (p_objOutMain == null || p_objOutDetail == null)
           {
               return -1;
           }

           long lngRes = -1;
           try
           {
               string strSQL = @"insert into t_ms_outstorage
  (seriesid_int,
   storageid_chr,
   outstorageid_vchr,
   outstoragetype_int,
   formtype,
   exportdept_chr,
   askdept_chr,
   status,
   askdate_dat,
   examdate_dat,
   inaccountdate_dat,
   askerid_chr,
   examerid_chr,
   inaccountid_chr,
   askid_vchr,
   parentnid,
   comment_vchr,
   outstoragedate_dat)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

               clsHRPTableService objHRPServ = new clsHRPTableService();

               clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
               long lngSEQ = 0;
               lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_OUTSTORAGE", out lngSEQ);
               if (lngSEQ <= 0)
               {
                   return -1;
               }
               p_objOutMain.m_lngSERIESID_INT = lngSEQ;

               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(18, out objDPArr);
               objDPArr[0].Value = p_objOutMain.m_lngSERIESID_INT;
               objDPArr[1].Value = p_objOutMain.m_strSTORAGEID_CHR;
               objDPArr[2].Value = p_objOutMain.m_strOUTSTORAGEID_VCHR;
               objDPArr[3].Value = p_objOutMain.m_intOutStorageTYPE_INT;
               objDPArr[4].Value = p_objOutMain.m_intFORMTYPE_INT;
               objDPArr[5].Value = p_objOutMain.m_strEXPORTDEPT_CHR;
               objDPArr[6].Value = p_objOutMain.m_strASKDEPT_CHR;
               objDPArr[7].Value = p_objOutMain.m_intSTATUS;
               objDPArr[8].DbType = DbType.DateTime;
               objDPArr[8].Value = DateTime.Parse(p_objOutMain.m_dtmASKDATE_DAT.ToString("yyyy-MM-dd HH:mm:ss"));
               objDPArr[9].DbType = DbType.DateTime;
               objDPArr[9].Value = DBNull.Value;
               objDPArr[10].DbType = DbType.DateTime;
               objDPArr[10].Value = DBNull.Value;
               objDPArr[11].Value = p_objOutMain.m_strASKERID_CHR;
               objDPArr[12].Value = p_objOutMain.m_strEXAMERID_CHR;
               objDPArr[13].Value = p_objOutMain.m_strINACCOUNTID_CHR;
               objDPArr[14].Value = p_objOutMain.m_strASKID_VCHR;
               objDPArr[15].Value = p_objOutMain.m_strPARENTNID;
               objDPArr[16].Value = p_objOutMain.m_strCOMMENT_VCHR;
               objDPArr[17].DbType = DbType.DateTime;
               objDPArr[17].Value = p_objOutMain.m_dtmOutStorageDate;

               long lngEff = -1;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

               if (lngRes <= 0)
               {
                   return -1;
               }

               strSQL = @"insert into t_ms_outstorage_detail
  (seriesid_int,
   seriesid2_int,
   medicineid_chr,
   medicinename_vch,
   medspec_vchr,
   opunit_chr,
   netamount_int,
   lotno_vchr,
   instorageid_vchr,
   callprice_int,
   wholesaleprice_int,
   retailprice_int,
   vendorid_chr,
   rejectreason,
   status,
   returnnum_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                IDataParameter[] objLisAddItemRefArr = null;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_OUTSTORAGE_DETAIL", out lngSEQ);
                    
                objHRPServ.CreateDatabaseParameter(16, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objOutMain.m_lngSERIESID_INT;
                objLisAddItemRefArr[2].Value = p_objOutDetail.m_strMEDICINEID_CHR;
                objLisAddItemRefArr[3].Value = p_objOutDetail.m_strMEDICINENAME_VCH;
                objLisAddItemRefArr[4].Value = p_objOutDetail.m_strMEDSPEC_VCHR;
                objLisAddItemRefArr[5].Value = p_objOutDetail.m_strOPUNIT_CHR;
                objLisAddItemRefArr[6].Value = p_objOutDetail.m_dblNETAMOUNT_INT;
                objLisAddItemRefArr[7].Value = p_objOutDetail.m_strLOTNO_VCHR;
                objLisAddItemRefArr[8].Value = p_objOutDetail.m_strINSTORAGEID_VCHR;
                objLisAddItemRefArr[9].Value = p_objOutDetail.m_dcmCALLPRICE_INT;
                objLisAddItemRefArr[10].Value = p_objOutDetail.m_dcmWHOLESALEPRICE_INT;
                objLisAddItemRefArr[11].Value = p_objOutDetail.m_dcmRETAILPRICE_INT;
                objLisAddItemRefArr[12].Value = p_objOutDetail.m_strVENDORID_CHR;
                objLisAddItemRefArr[13].Value = p_objOutDetail.m_strRejectReason;
                objLisAddItemRefArr[14].Value = p_objOutDetail.m_intStatus;
                objLisAddItemRefArr[15].Value = p_objOutDetail.m_intRETURNNUM_INT;

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
               string strSQL = @"update t_ms_instorage set state_int = 0 where instorageid_vchr = ?";

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

               strSQL = @"update t_ms_instorage_detal a
   set a.status = -1
 where a.status = 1
   and exists (select b.seriesid_int
          from t_ms_instorage b
         where a.seriesid2_int = b.seriesid_int
           and b.instorageid_vchr = ?)";

               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

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
       public long m_lngDeleteInStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID,string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValiDate, double p_dblInPrice)
       {
           long lngRes = 0;
           try
           {
               string strSQL = @"select a.seriesid_int mainseq, b.seriesid_int subseq
  from t_ms_instorage a, t_ms_instorage_detal b
 where a.state_int <> 0
   and b.status = 1
   and a.seriesid_int = b.seriesid2_int
   and a.instorageid_vchr = ?
   and b.medicineid_chr = ?
   and b.lotno_vchr = ?
   and b.instorageid_vchr = ?
   and b.validperiod_dat = ?
   and b.callprice_int = ?";

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

               strSQL = @"update t_ms_instorage set state_int = 0 where seriesid_int = ?";
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = lngMainSEQ;

               long lngEff = -1;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

               if (lngRes <= 0)
               {
                   return -1;
               }

               strSQL = @"update t_ms_instorage_detal a
   set a.status = -1
 where a.seriesid_int = ?";

               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = lngSubSEQ;

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
               string strSQL = @"update t_ms_outstorage set status = 0 where outstorageid_vchr = ?";

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

               strSQL = @"update t_ms_outstorage_detail a
   set a.status = -1
 where a.status = 1
   and exists (select b.seriesid_int
          from t_ms_outstorage b
         where a.seriesid2_int = b.seriesid_int
           and b.outstorageid_vchr = ?)";

               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

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
  from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.status <> 0
   and b.status = 1
   and a.seriesid_int = b.seriesid2_int
   and a.outstorageid_vchr = ?
   and b.medicineid_chr = ?
   and b.lotno_vchr = ?
   and b.instorageid_vchr = ?
   and b.validperiod_dat = ?
   and b.callprice_int = ?";

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

               strSQL = @"update t_ms_outstorage set status = 0 where seriesid_int = ?";

               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = lngMainSEQ;

               long lngEff = -1;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

               if (lngRes <= 0)
               {
                   return -1;
               }

               strSQL = @"update t_ms_outstorage_detail a
   set a.status = -1
 where a.seriesid_int = ?";

               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = lngSubSEQ;

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

       #region 修改库存明细表库存数量
       /// <summary>
       /// 修改库存明细表库存数量
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objOutArr">更改库存VO</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngAddStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail[] p_objOutArr)
       {
           if (p_objOutArr == null || p_objOutArr.Length == 0)
           {
               return -1;
           }

           long lngRes = 0;
           try
           {
               string strSQL = @"update t_ms_storage_detail
   set realgross_int   = realgross_int + ?,
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
                   for (int iRow = 0; iRow < p_objOutArr.Length; iRow++)
                   {
                       objHRPServ.CreateDatabaseParameter(10, out objDPArr);
                       objDPArr[0].Value = p_objOutArr[iRow].m_dblREALGROSS_INT;
                       objDPArr[1].Value = p_objOutArr[iRow].m_dblAVAILAGROSS_INT;
                       objDPArr[2].Value = p_objOutArr[iRow].m_strMEDICINEID_CHR;
                       objDPArr[3].Value = p_objOutArr[iRow].m_strLOTNO_VCHR;
                       objDPArr[4].Value = p_objOutArr[iRow].m_strINSTORAGEID_VCHR;
                       objDPArr[5].Value = p_objOutArr[iRow].m_strSTORAGEID_CHR;
                       objDPArr[6].Value = p_objOutArr[iRow].m_dcmCALLPRICE_INT;
                       objDPArr[7].DbType = DbType.DateTime;
                       objDPArr[7].Value = p_objOutArr[iRow].m_dtmVALIDPERIOD_DAT;
                       objDPArr[8].Value = p_objOutArr[iRow].m_dblREALGROSS_INT;
                       objDPArr[9].Value = p_objOutArr[iRow].m_dblAVAILAGROSS_INT;

                       long lngEff = -1;
                       lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                   }
               }
               else
               {
                   DbType[] dbTypes = new DbType[] { DbType.Double, DbType.Double, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Double, DbType.DateTime, DbType.Double, DbType.Double };

                   object[][] objValues = new object[10][];

                   int intItemCount = p_objOutArr.Length;
                   for (int j = 0; j < objValues.Length; j++)
                   {
                       objValues[j] = new object[intItemCount];//初始化
                   }

                   for (int iRow = 0; iRow < intItemCount; iRow++)
                   {
                       objValues[0][iRow] = p_objOutArr[iRow].m_dblREALGROSS_INT;
                       objValues[1][iRow] = p_objOutArr[iRow].m_dblAVAILAGROSS_INT;
                       objValues[2][iRow] = p_objOutArr[iRow].m_strMEDICINEID_CHR;
                       objValues[3][iRow] = p_objOutArr[iRow].m_strLOTNO_VCHR;
                       objValues[4][iRow] = p_objOutArr[iRow].m_strINSTORAGEID_VCHR;
                       objValues[5][iRow] = p_objOutArr[iRow].m_strSTORAGEID_CHR;
                       objValues[6][iRow] = p_objOutArr[iRow].m_dcmCALLPRICE_INT;
                       objValues[7][iRow] = p_objOutArr[iRow].m_dtmVALIDPERIOD_DAT;
                       objValues[8][iRow] = p_objOutArr[iRow].m_dblREALGROSS_INT;
                       objValues[9][iRow] = p_objOutArr[iRow].m_dblAVAILAGROSS_INT;
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
               string strSQL = @"update t_ms_storagecheck_detail set status_int = 0 where seriesid_int = ?";

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
               string strSQL = @"update t_ms_storagecheck set status = 0 where seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_lngSEQ;

               long lngEff = -1;
               lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
               
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
               string strSQL = @"update t_ms_storagecheck_detail a set a.status_int = ? where a.seriesid2_int = ? and a.status_int = 1";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(2, out objDPArr);
               objDPArr[0].Value = p_intStatus;
               objDPArr[1].Value = p_lngMainSEQ;

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

       #region 获取盘点数量不为零的数据
       /// <summary>
       /// 获取盘点数量不为零的数据
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_strCheckID">盘点ID</param>
       /// <param name="p_dtbResult">结果数据</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetCheckResult(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckID, out DataTable p_dtbResult)
       {
           p_dtbResult = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select a.medicineid_chr,
              case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
       a.instorageid_vchr,
       a.checkresult_int,
       a.seriesid_int
  from t_ms_storagecheck_detail a, t_ms_storagecheck b
 where a.checkresult_int <> 0
   and a.status_int = 1
   and a.seriesid2_int = b.seriesid_int
   and b.status <> 0
   and b.checkid_chr = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strCheckID;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }

       /// <summary>
       /// 获取盘点数量
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_lngSEQ">明细表序列</param>
       /// <param name="p_dtbResult">结果数据</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetCheckResult(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, out DataTable p_dtbResult)
       {
           p_dtbResult = null;
           long lngRes = 0;
           try
           {
               string strSQL = @"select a.medicineid_chr,
              case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
       a.instorageid_vchr,
       a.checkresult_int
  from t_ms_storagecheck_detail a
 where a.seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_lngSEQ;

               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
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
               string strSQL = @"update t_ms_storage a
   set a.currentgross_num = (select sum(b.realgross_int)
                               from t_ms_storage_detail b
                              where b.status = 1
                                and b.medicineid_chr = ?
                                and b.storageid_chr = ?)
 where a.medicineid_chr = ?
   and a.storageid_chr = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();

               if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
               {
                   IDataParameter[] objDPArr = null;
                   for (int iRow = 0; iRow < p_strMedicineIDArr.Length; iRow++)
                   {
                       objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                       objDPArr[0].Value = p_strMedicineIDArr[iRow];
                       objDPArr[1].Value = p_strStorageID;
                       objDPArr[2].Value = p_strMedicineIDArr[iRow];
                       objDPArr[3].Value = p_strStorageID;

                       long lngEff = -1;
                       lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                   }
               }
               else
               {
                   DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String };

                   object[][] objValues = new object[4][];

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
               string strSQL = @"select distinct d.checkmedicineorder_chr,
                b.assistcode_chr,
                b.medicinetypeid_chr,
                a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.opunit_vchr,
                a.realgross_int,
                a.callprice_int,
                a.wholesaleprice_int,
                a.retailprice_int,
                case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
                a.instorageid_vchr,
                a.validperiod_dat,
                a.productorid_chr,
                a.instorageid_vchr,
                a.vendorid_chr,
                c.medicinepreptype_chr,
                c.medicinepreptypename_vchr
  from t_ms_storage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_aid_medicinepreptype c on c.medicinepreptype_chr =
                                        b.medicinepreptype_chr
  left outer join t_ms_checkmedicineorder d on d.medicineid_chr =
                                               a.medicineid_chr
                                           and a.storageid_chr =
                                               d.storageid_chr
 where a.status = 1
   and a.medicineid_chr = ?
   and a.storageid_chr = ?
 order by d.checkmedicineorder_chr,
          b.assistcode_chr,
          lotno_vchr,
          a.instorageid_vchr";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               objHRPServ.CreateDatabaseParameter(2, out objDPArr);
               objDPArr[0].Value = p_strMedicineID;
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
       /// <returns></returns>
       [AutoComplete]
       public long m_lngCommitStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, clsMS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsMS_StorageCheckDetail_VO[] p_objSufCheckDetail, clsMS_StorageDetail[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, DateTime p_dtmCommitDate,
            string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID, bool p_blnIsImmAccount)
       {
           long lngRes = 0;
           try
           {
               if (p_objDefCheckDetail != null && p_objDefCheckDetail.Length > 0)
               {
                   for (int iDef = 0; iDef < p_objDefCheckDetail.Length; iDef++)
                   {
                       lngRes = m_lngSaveCheckToOutStorage(p_objPrincipal, m_objMainOutVO(p_objDefCheckDetail[iDef], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID), m_objDetailOutVO(p_objDefCheckDetail[iDef]));
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }
               }

               if (p_objSufCheckDetail != null && p_objSufCheckDetail.Length > 0)
               {
                   for (int iSuf = 0; iSuf < p_objSufCheckDetail.Length; iSuf++)
                   {
                       lngRes = m_lngSaveCheckToInStorage(p_objPrincipal, m_objMainInVO(p_objSufCheckDetail[iSuf], p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID), m_objDetailInVO(p_objSufCheckDetail[iSuf]));
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }
               }

               if (p_objStDetail != null && p_objStDetail.Length > 0)
               {
                   lngRes = m_lngAddStorageDetailGross(p_objPrincipal, p_objStDetail);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }
               }

               if (p_strMedicineIDArr != null && p_strMedicineIDArr.Length > 0)
               {
                   lngRes = m_lngUpdateStorageGross(p_objPrincipal, p_strMedicineIDArr, p_strStorageID);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }
               }

               lngRes = m_lngSetCommitUser(p_objPrincipal, p_strEmpID, p_lngMainSEQ);
               if (lngRes <= 0)
               {
                   throw new Exception();
               }

               System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
               clsMS_AccountDetail_VO[] objDef = m_objAccountDetail(p_objDefCheckDetail, p_strEmpID, p_dtmCommitDate, p_blnIsImmAccount, 2, p_strCheckID, p_strStorageID);
               if (objDef != null && objDef.Length > 0)
               {
                   arrAccount.AddRange(objDef);
               }
               clsMS_AccountDetail_VO[] objSuf = m_objAccountDetail(p_objSufCheckDetail, p_strEmpID, p_dtmCommitDate, p_blnIsImmAccount, 1, p_strCheckID, p_strStorageID);
               if (objSuf != null && objSuf.Length > 0)
               {
                   arrAccount.AddRange(objSuf);
               }

               if (arrAccount.Count > 0)
               {
                   clsMS_AccountDetail_VO[] objAccount = arrAccount.ToArray(typeof(clsMS_AccountDetail_VO)) as clsMS_AccountDetail_VO[];
                   if (objAccount != null && objAccount.Length > 0)
                   {
                       clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                       lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccount);
                       objAcSVC = null;
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }
               }

               if (p_blnIsImmAccount)
               {
                   lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_dtmCommitDate, p_lngMainSEQ);
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
       private clsMS_InStorage_VO m_objMainInVO(clsMS_StorageCheckDetail_VO p_objCheckDetail, DateTime p_dtmCommitDate, string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID)
       {
           if (p_objCheckDetail == null)
           {
               return null;
           }
           clsMS_InStorage_VO objISMainVO = new clsMS_InStorage_VO();

           objISMainVO.m_dtmNEWORDER_DAT = p_dtmCheckDate;
           objISMainVO.m_intSTATE_INT = 2;
           objISMainVO.m_lngSERIESID_INT = 0;
           objISMainVO.m_strINSTORAGEID_VCHR = p_strCheckID;
           objISMainVO.m_strVENDORID_CHR = p_objCheckDetail.m_strVendorID;
           objISMainVO.m_dtmINSTORAGEDATE_DAT = p_dtmCheckDate;
           objISMainVO.m_strBUYERID_CHAR = string.Empty;
           objISMainVO.m_strSTORAGERID_CHAR = string.Empty;
           objISMainVO.m_strACCOUNTERID_CHAR = string.Empty;
           objISMainVO.m_strMAKERID_CHR = p_strCreatorID;
           objISMainVO.m_strSUPPLYCODE_VCHR = string.Empty;
           objISMainVO.m_strCOMMNET_VCHR = p_objCheckDetail.m_strCHECKREASON_VCHR;
           objISMainVO.m_strINVOICECODE_VCHR = string.Empty;
           objISMainVO.m_dtmINVOICEDATER_DAT = DateTime.MinValue;
           objISMainVO.m_intFORMTYPE_INT = 3;
           objISMainVO.m_intINSTORAGETYPE_INT = 1;
           objISMainVO.m_strSTORAGEID_CHR = p_strStorageID;
           objISMainVO.m_intPAYSTATE_INT = 1;
           return objISMainVO;
       }

       /// <summary>
       /// 获取入库明细
       /// </summary>
       /// <param name="p_objCheckDetail">盘盈明细</param>
       /// <returns></returns>
       [AutoComplete]
       private clsMS_InStorageDetail_VO m_objDetailInVO(clsMS_StorageCheckDetail_VO p_objCheckDetail)
       {
           if (p_objCheckDetail == null)
           {
               return null;
           }

           clsMS_InStorageDetail_VO objNewDetail = new clsMS_InStorageDetail_VO();

           objNewDetail.m_intStatus = 1;
           objNewDetail.m_strMEDICINEID_CHR = p_objCheckDetail.m_strMEDICINEID_CHR;
           objNewDetail.m_strMEDICINENAME_VCH = p_objCheckDetail.m_strMEDICINENAME_VCH;
           objNewDetail.m_strMEDSPEC_VCHR = p_objCheckDetail.m_strMEDSPEC_VCHR;
           objNewDetail.m_dblPACKAMOUNT = 0d;
           objNewDetail.m_strPACKUNIT_VCHR = string.Empty;
           objNewDetail.m_dcmPACKCALLPRICE_INT = 0m;
           objNewDetail.m_dblPACKCONVERT_INT = 0d;
           objNewDetail.m_strLOTNO_VCHR = p_objCheckDetail.m_strLOTNO_VCHR;
           objNewDetail.m_dblAMOUNT = p_objCheckDetail.m_dblCHECKRESULT_INT;
           objNewDetail.m_dcmCALLPRICE_INT = (decimal)p_objCheckDetail.m_dblCALLPRICE_INT;
           objNewDetail.m_dcmWHOLESALEPRICE_INT = (decimal)p_objCheckDetail.m_dblWHOLESALEPRICE_INT;
           objNewDetail.m_dcmRETAILPRICE_INT = (decimal)p_objCheckDetail.m_dblRETAILPRICE_INT;
           objNewDetail.m_dtmVALIDPERIOD_DAT = p_objCheckDetail.m_dtmVALIDPERIOD_DAT;
           objNewDetail.m_intACCEPTANCE_INT = 1;
           objNewDetail.m_strAPPROVECODE_VCHR = string.Empty;
           objNewDetail.m_intAPPARENTQUALITY_INT = 1;
           objNewDetail.m_intPACKQUALITY_INT = 1;
           objNewDetail.m_intEXAMRUSULT_INT = 1;
           objNewDetail.m_strEXAMINER = string.Empty;
           objNewDetail.m_strPRODUCTORID_CHR = p_objCheckDetail.m_strPRODUCTORID_CHR;
           objNewDetail.m_strACCEPTANCECOMPANY_CHR = string.Empty;
           objNewDetail.m_strUNIT_VCHR = p_objCheckDetail.m_strOPUNIT_CHR;
           objNewDetail.m_strInStorageID = p_objCheckDetail.m_strINSTORAGEID_VCHR;
           objNewDetail.m_intRUTURNNUM_INT = 0;

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
       private clsMS_OutStorage_VO m_objMainOutVO(clsMS_StorageCheckDetail_VO p_objCheckDetail, DateTime p_dtmCommitDate, string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID)
       {
           if (p_objCheckDetail == null)
           {
               return null;
           }

           clsMS_OutStorage_VO objOutMain = new clsMS_OutStorage_VO();
           objOutMain.m_dtmASKDATE_DAT = p_dtmCommitDate;
           objOutMain.m_intSTATUS = 2;

           objOutMain.m_strASKDEPT_CHR = string.Empty;
           objOutMain.m_intOutStorageTYPE_INT = 1;
           objOutMain.m_intFORMTYPE_INT = 3;
           objOutMain.m_strASKERID_CHR = p_strCreatorID;
           objOutMain.m_strCOMMENT_VCHR = p_objCheckDetail.m_strCHECKREASON_VCHR;
           objOutMain.m_strSTORAGEID_CHR = p_strStorageID;
           objOutMain.m_dtmOutStorageDate = p_dtmCheckDate;
           objOutMain.m_strOUTSTORAGEID_VCHR = p_strCheckID;
           return objOutMain;
       }

       /// <summary>
       /// 获取出库明细记录
       /// </summary>
       /// <param name="p_objCheckDetail">盘亏明细</param>
       /// <returns></returns>
       [AutoComplete]
       private clsMS_OutStorageDetail_VO m_objDetailOutVO(clsMS_StorageCheckDetail_VO p_objCheckDetail)
       {
           if (p_objCheckDetail == null)
           {
               return null;
           }

           clsMS_OutStorageDetail_VO objDetail = new clsMS_OutStorageDetail_VO();
           objDetail.m_strMEDICINEID_CHR = p_objCheckDetail.m_strMEDICINEID_CHR;
           objDetail.m_strMEDICINENAME_VCH = p_objCheckDetail.m_strMEDICINENAME_VCH;
           objDetail.m_strMEDSPEC_VCHR = p_objCheckDetail.m_strMEDSPEC_VCHR;
           objDetail.m_strOPUNIT_CHR = p_objCheckDetail.m_strOPUNIT_CHR;
           objDetail.m_dblNETAMOUNT_INT = Math.Abs(p_objCheckDetail.m_dblCHECKRESULT_INT);
           objDetail.m_strLOTNO_VCHR = p_objCheckDetail.m_strLOTNO_VCHR;
           objDetail.m_strINSTORAGEID_VCHR = string.Empty;
           objDetail.m_dcmCALLPRICE_INT = (decimal)p_objCheckDetail.m_dblCALLPRICE_INT;
           objDetail.m_dcmWHOLESALEPRICE_INT = (decimal)p_objCheckDetail.m_dblWHOLESALEPRICE_INT;
           objDetail.m_dcmRETAILPRICE_INT = (decimal)p_objCheckDetail.m_dblRETAILPRICE_INT;
           objDetail.m_strVENDORID_CHR = p_objCheckDetail.m_strVendorID;
           objDetail.m_dtmValidperiod_dat = p_objCheckDetail.m_dtmVALIDPERIOD_DAT;
           objDetail.m_strProductorID_chr = p_objCheckDetail.m_strPRODUCTORID_CHR;
           objDetail.m_dtmINSTORAGEDATE_DAT = DateTime.MinValue;
           objDetail.m_intStatus = 1;
           objDetail.m_intRETURNNUM_INT = 0;

           return objDetail;
       }

        /// <summary>
        /// 获取帐本明细
        /// </summary>
        /// <param name="p_objCheckDetail"></param>
        /// <param name="p_strEmpID">入帐人ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_intType">出入类型 1入库 2出库</param>
        /// <param name="p_strCheckID">盘点单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
       private clsMS_AccountDetail_VO[] m_objAccountDetail(clsMS_StorageCheckDetail_VO[] p_objCheckDetail,string p_strEmpID, DateTime p_dtmAccountDate, bool p_blnIsImmAccount, int p_intType, string p_strCheckID, string p_strStorageID)
       {
           if (p_objCheckDetail == null || p_objCheckDetail.Length == 0)
           {
               return null;
           }

           clsMS_AccountDetail_VO[] objAcc = new clsMS_AccountDetail_VO[p_objCheckDetail.Length];

           int intState = p_blnIsImmAccount ? 1 : 2;
           string strEmpID = p_blnIsImmAccount ? p_strEmpID : string.Empty;
           DateTime dtmAccount = p_blnIsImmAccount ? p_dtmAccountDate : DateTime.MinValue;
           for (int iAcc = 0; iAcc < p_objCheckDetail.Length; iAcc++)
           {
               objAcc[iAcc] = new clsMS_AccountDetail_VO();
               objAcc[iAcc].m_dblAMOUNT_INT = Math.Abs(p_objCheckDetail[iAcc].m_dblCHECKRESULT_INT);
               objAcc[iAcc].m_dblCALLPRICE_INT = p_objCheckDetail[iAcc].m_dblCALLPRICE_INT;
               objAcc[iAcc].m_dblOLDGROSS_INT = p_objCheckDetail[iAcc].m_dblCURRENTGROSS_INT;
               objAcc[iAcc].m_dblRETAILPRICE_INT = p_objCheckDetail[iAcc].m_dblRETAILPRICE_INT;
               objAcc[iAcc].m_dblWHOLESALEPRICE_INT = p_objCheckDetail[iAcc].m_dblWHOLESALEPRICE_INT;
               objAcc[iAcc].m_dtmINACCOUNTDATE_DAT = dtmAccount;
               objAcc[iAcc].m_intFORMTYPE_INT = 3;
               objAcc[iAcc].m_intISEND_INT = 0;
               objAcc[iAcc].m_intSTATE_INT = intState;
               objAcc[iAcc].m_intTYPE_INT = p_intType;
               objAcc[iAcc].m_strCHITTYID_VCHR = p_strCheckID;
               objAcc[iAcc].m_strDEPTID_CHR = p_objCheckDetail[iAcc].m_strVendorID;
               objAcc[iAcc].m_strINACCOUNTID_CHR = strEmpID;
               objAcc[iAcc].m_strINSTORAGEID_VCHR = p_objCheckDetail[iAcc].m_strINSTORAGEID_VCHR;
               objAcc[iAcc].m_strLOTNO_VCHR = p_objCheckDetail[iAcc].m_strLOTNO_VCHR;
               objAcc[iAcc].m_strMEDICINEID_CHR = p_objCheckDetail[iAcc].m_strMEDICINEID_CHR;
               objAcc[iAcc].m_strMEDICINENAME_VCH = p_objCheckDetail[iAcc].m_strMEDICINENAME_VCH;
               objAcc[iAcc].m_strMEDICINETYPEID_CHR = p_objCheckDetail[iAcc].m_strMedicineTypeID;
               objAcc[iAcc].m_strMEDSPEC_VCHR = p_objCheckDetail[iAcc].m_strMEDSPEC_VCHR;
               objAcc[iAcc].m_strOPUNIT_CHR = p_objCheckDetail[iAcc].m_strOPUNIT_CHR;
               objAcc[iAcc].m_strSTORAGEID_CHR = p_strStorageID;
               objAcc[iAcc].m_dtmOperateDate = p_dtmAccountDate;
               objAcc[iAcc].m_dtmValidDate = p_objCheckDetail[iAcc].m_dtmVALIDPERIOD_DAT;
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
                   clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                   //如果无盈亏记录，则在帐本明细表中不会存在相应的帐本明细
                   long lngAcc = objAccSVC.m_lngRatifyAccountDetail(p_objPrincipal, p_strCheckID, p_strStorage, p_strEmpID, p_dtmAccountDate);

                   objAccSVC = null;
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

       #region 保存盘点
       /// <summary>
       /// 保存盘点
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_objMain">主表记录</param>
       /// <param name="p_objOldStDetial">旧的盘点药品库存信息</param>
       /// <param name="p_objModifyDetaiArr">修改过的盘点记录</param>
       /// <param name="p_objNewDetailArr">新增的盘点记录</param>
       /// <param name="p_objDefCheckDetail">盘亏药品</param>
       /// <param name="p_objSufCheckDetail">盘盈药品</param>
       /// <param name="p_objStDetail">盘点药品相关库存明细</param>
       /// <param name="p_strMedicineIDArr">盈亏药品ID</param>
       /// <param name="p_strEmpID">员工ID</param>
       /// <param name="p_strStorageID">仓库ID</param>
       /// <param name="p_blnIsAddNew">是否新增</param>
       /// <param name="p_blnIsCommit">是否保存即审核</param>
       /// <param name="p_lngNewSubSEQArr">新增盘点记录明细序列</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaveStorageCheck(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_StorageCheck_VO p_objMain, clsMS_StorageDetail[] p_objOldStDetial, clsMS_StorageCheckDetail_VO[] p_objModifyDetaiArr, clsMS_StorageCheckDetail_VO[] p_objNewDetailArr, clsMS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsMS_StorageCheckDetail_VO[] p_objSufCheckDetail,
            clsMS_StorageDetail[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, string p_strStorageID, bool p_blnIsAddNew, bool p_blnIsCommit, out long[] p_lngNewSubSEQArr)
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
                   return -1;
               }

               //针对保存即审核，回复修改过的旧有数据（相当于退审）
               if (p_blnIsCommit && !p_blnIsAddNew && p_objOldStDetial != null && p_objOldStDetial.Length > 0)
               {
                   lngRes = m_lngAddStorageDetailGross(p_objPrincipal, p_objOldStDetial);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }

                   clsMS_AccountMedicine_VO[] objAccMed = new clsMS_AccountMedicine_VO[p_objOldStDetial.Length];
                   for (int iOld = 0; iOld < p_objOldStDetial.Length; iOld++)
                   {
                       objAccMed[iOld] = new clsMS_AccountMedicine_VO();
                       objAccMed[iOld].m_strChittyID = p_objMain.m_strCheckID_CHR;
                       objAccMed[iOld].m_strInStorageID = p_objOldStDetial[iOld].m_strINSTORAGEID_VCHR;
                       objAccMed[iOld].m_strLotNO = p_objOldStDetial[iOld].m_strLOTNO_VCHR;
                       objAccMed[iOld].m_strMedicineID = p_objOldStDetial[iOld].m_strMEDICINEID_CHR;
                       objAccMed[iOld].m_strStorageID = p_strStorageID;
                       objAccMed[iOld].m_dtmValidDate = p_objOldStDetial[iOld].m_dtmVALIDPERIOD_DAT;
                       objAccMed[iOld].m_dblInPrice = Convert.ToDouble(p_objOldStDetial[iOld].m_dcmCALLPRICE_INT);
                   }
                   clsMS_AccountSVC objAccSvc = new clsMS_AccountSVC();
                   lngRes = objAccSvc.m_lngSetAccountDetailInvalid(p_objPrincipal, objAccMed);
                   objAccSvc = null;
               }

               //保存修改记录
               if (p_objModifyDetaiArr != null && p_objModifyDetaiArr.Length > 0)
               {
                   lngRes = m_lngModifyStorageCheckDetail(p_objPrincipal, p_objModifyDetaiArr);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }
               }

               //保存新增记录
               if (p_objNewDetailArr != null && p_objNewDetailArr.Length > 0)
               {
                   for (int iNew = 0; iNew < p_objNewDetailArr.Length; iNew++)
                   {
                       p_objNewDetailArr[iNew].m_lngSERIESID2_INT = p_objMain.m_lngSeriesID_INT;
                   }

                   lngRes = m_lngAddNewStorageCheckDetail(p_objPrincipal, p_objNewDetailArr, out p_lngNewSubSEQArr);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }
               }

               //保存即审核操作
               if (p_blnIsCommit)
               {
                   if (p_objDefCheckDetail != null && p_objDefCheckDetail.Length > 0)
                   {
                       clsMS_OutStorage_VO objOutMain = null;
                       clsMS_OutStorageDetail_VO objOutDetail = null;
                       for (int iDef = 0; iDef < p_objDefCheckDetail.Length; iDef++)
                       {
                           if (!p_blnIsAddNew)
                           {
                               //将旧有盘亏记录设为无效

                               lngRes = m_lngDeleteOutStorage(p_objPrincipal, p_objMain.m_strCheckID_CHR, p_objDefCheckDetail[iDef].m_strMEDICINEID_CHR, p_objDefCheckDetail[iDef].m_strLOTNO_VCHR, p_objDefCheckDetail[iDef].m_strINSTORAGEID_VCHR, p_objDefCheckDetail[iDef].m_dtmVALIDPERIOD_DAT, p_objDefCheckDetail[iDef].m_dblCALLPRICE_INT);
                           }

                           //保存盘亏记录至出库表
                           objOutMain = m_objMainOutVO(p_objDefCheckDetail[iDef], p_objMain.m_dtmAskDate_DAT, p_objMain.m_strCheckID_CHR, p_objMain.m_strAskerID_CHR, p_objMain.m_dtmCheckDate, p_strStorageID);
                           objOutDetail = m_objDetailOutVO(p_objDefCheckDetail[iDef]);
                           lngRes = m_lngSaveCheckToOutStorage(p_objPrincipal, objOutMain, objOutDetail);
                           if (lngRes <= 0)
                           {
                               throw new Exception();
                           }
                       }
                   }

                   if (p_objSufCheckDetail != null && p_objSufCheckDetail.Length > 0)
                   {
                       clsMS_InStorage_VO objInMain = null;
                       clsMS_InStorageDetail_VO objInDetail = null;
                       for (int iSuf = 0; iSuf < p_objSufCheckDetail.Length; iSuf++)
                       {
                           if (!p_blnIsAddNew)
                           {
                               //将旧有盘盈记录设为无效

                               lngRes = m_lngDeleteInStorage(p_objPrincipal, p_objMain.m_strCheckID_CHR, p_objDefCheckDetail[iSuf].m_strMEDICINEID_CHR, p_objDefCheckDetail[iSuf].m_strLOTNO_VCHR, p_objDefCheckDetail[iSuf].m_strINSTORAGEID_VCHR, p_objDefCheckDetail[iSuf].m_dtmVALIDPERIOD_DAT, p_objDefCheckDetail[iSuf].m_dblCALLPRICE_INT);
                           }

                           //保存盘盈记录
                           objInMain = m_objMainInVO(p_objSufCheckDetail[iSuf], p_objMain.m_dtmAskDate_DAT, p_objMain.m_strCheckID_CHR, p_objMain.m_strAskerID_CHR, p_objMain.m_dtmCheckDate, p_strStorageID);
                           objInDetail = m_objDetailInVO(p_objSufCheckDetail[iSuf]);
                           lngRes = m_lngSaveCheckToInStorage(p_objPrincipal, objInMain, objInDetail);
                           if (lngRes <= 0)
                           {
                               throw new Exception();
                           }
                       }
                   }

                   if (p_objStDetail != null && p_objStDetail.Length > 0)
                   {
                       //修改库存明细记录
                       lngRes = m_lngAddStorageDetailGross(p_objPrincipal, p_objStDetail);
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }

                   if (p_strMedicineIDArr != null && p_strMedicineIDArr.Length > 0)
                   {
                       //更新库存主表药品当前数量
                       lngRes = m_lngUpdateStorageGross(p_objPrincipal, p_strMedicineIDArr, p_strStorageID);
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }

                   //设置审核者
                   lngRes = m_lngSetCommitUser(p_objPrincipal, p_objMain.m_strAskerID_CHR, p_objMain.m_lngSeriesID_INT);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }

                   //帐本明细表增加数据
                   System.Collections.ArrayList arrAccount = new System.Collections.ArrayList();
                   clsMS_AccountDetail_VO[] objDef = m_objAccountDetail(p_objDefCheckDetail, p_strEmpID, p_objMain.m_dtmAskDate_DAT, false, 2, p_objMain.m_strCheckID_CHR, p_strStorageID);
                   if (objDef != null && objDef.Length > 0)
                   {
                       arrAccount.AddRange(objDef);
                   }
                   clsMS_AccountDetail_VO[] objSuf = m_objAccountDetail(p_objSufCheckDetail, p_strEmpID, p_objMain.m_dtmAskDate_DAT, false, 1, p_objMain.m_strCheckID_CHR, p_strStorageID);
                   if (objSuf != null && objSuf.Length > 0)
                   {
                       arrAccount.AddRange(objSuf);
                   }

                   if (arrAccount.Count > 0)
                   {
                       clsMS_AccountDetail_VO[] objAccount = arrAccount.ToArray(typeof(clsMS_AccountDetail_VO)) as clsMS_AccountDetail_VO[];
                       if (objAccount != null && objAccount.Length > 0)
                       {
                           clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                           lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccount);
                           objAcSVC = null;
                           if (lngRes <= 0)
                           {
                               throw new Exception();
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
       public long m_lngDeleteStorageCheckMedicine(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageDetail p_objMedicneSt, string p_strCheckID, long p_lngSubSEQ, bool p_blnIsCommit)
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

               if (p_blnIsCommit)
               {
                   if (p_objMedicneSt.m_dblREALGROSS_INT < 0)//盘亏
                   {
                       lngRes = m_lngDeleteOutStorage(p_objPrincipal, p_strCheckID, p_objMedicneSt.m_strMEDICINEID_CHR, p_objMedicneSt.m_strLOTNO_VCHR, p_objMedicneSt.m_strINSTORAGEID_VCHR, p_objMedicneSt.m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt.m_dcmCALLPRICE_INT));

                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }
                   else if (p_objMedicneSt.m_dblREALGROSS_INT > 0)//盘盈
                   {
                       lngRes = m_lngDeleteInStorage(p_objPrincipal, p_strCheckID, p_objMedicneSt.m_strMEDICINEID_CHR, p_objMedicneSt.m_strLOTNO_VCHR, p_objMedicneSt.m_strINSTORAGEID_VCHR, p_objMedicneSt.m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt.m_dcmCALLPRICE_INT));
                       if (lngRes <= 0)
                       {
                           throw new Exception();
                       }
                   }

                   p_objMedicneSt.m_dblAVAILAGROSS_INT = 0 - p_objMedicneSt.m_dblAVAILAGROSS_INT;
                   p_objMedicneSt.m_dblREALGROSS_INT = 0 - p_objMedicneSt.m_dblREALGROSS_INT;
                   clsMS_StorageDetail[] objSTArr = new clsMS_StorageDetail[] { p_objMedicneSt };
                   lngRes = m_lngAddStorageDetailGross(p_objPrincipal, objSTArr);//还原库存明细数量
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }

                   string[] strMedID = new string[] { p_objMedicneSt.m_strMEDICINEID_CHR };
                   lngRes = m_lngUpdateStorageGross(p_objPrincipal, strMedID, p_objMedicneSt.m_strSTORAGEID_CHR);
                   if (lngRes <= 0)
                   {
                       throw new Exception();
                   }

                   clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                   long lngAcc = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strCheckID, p_objMedicneSt.m_strSTORAGEID_CHR, p_objMedicneSt.m_strMEDICINEID_CHR, p_objMedicneSt.m_strLOTNO_VCHR, p_objMedicneSt.m_strINSTORAGEID_VCHR, p_objMedicneSt.m_dtmVALIDPERIOD_DAT, Convert.ToDouble(p_objMedicneSt.m_dcmCALLPRICE_INT));
                   objAccSVC = null;
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
