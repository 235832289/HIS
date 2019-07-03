using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 出库
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsOutStorageSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取出库主表
        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intFormType,out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
         when 3 then
          '即入即出'
         else
          ''
       end outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int
 where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?
   and (g.medicinename_vch like ? or g.assistcode_chr like ?)
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ?
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strMedicine + "%";
                objDPArr[4].Value = p_strMedicine + "%";
                objDPArr[5].Value = p_strAskDeptName + "%";
                objDPArr[6].Value = p_strOutID + "%";
                objDPArr[7].Value = p_intFormType;       

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutStorage, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion


        #region 获取出库主表（多类型）
        /// <summary>
        /// 获取出库主表（多类型）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intOutStorageType">出库类型</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intOutStorageType,int p_intFormType, out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       a.outstoragetype_int,
       g.typename_vchr outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
left join t_aid_impexptype g on g.typecode_vchr = a.outstoragetype_int
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                if (p_intOutStorageType == 0)
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?
   and (g.medicinename_vch like ? or g.assistcode_chr like ?)
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ?
 order by a.seriesid_int";
                    objHRPServ.CreateDatabaseParameter(8, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    objDPArr[3].Value = p_strMedicine + "%";
                    objDPArr[4].Value = p_strMedicine + "%";
                    objDPArr[5].Value = p_strAskDeptName + "%";
                    objDPArr[6].Value = p_strOutID + "%";
                    objDPArr[7].Value = p_intFormType;
                }
                else
                {
                    strSQL += @" where a.storageid_chr = ?
   and a.outstoragedate_dat between ? and ?
   and (g.medicinename_vch like ? or g.assistcode_chr like ?)
   and d.deptname_vchr like ? 
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ? 
   and a.outstoragetype_int = ?
 order by a.seriesid_int";
                    objHRPServ.CreateDatabaseParameter(9, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtmBegin;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    objDPArr[3].Value = p_strMedicine + "%";
                    objDPArr[4].Value = p_strMedicine + "%";
                    objDPArr[5].Value = p_strAskDeptName + "%";
                    objDPArr[6].Value = p_strOutID + "%";
                    objDPArr[7].Value = p_intFormType;
                    objDPArr[8].Value = p_intOutStorageType;
                }

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbOutStorage, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取出库子表实发数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_dblAmount">实发数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailGross(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, out double p_dblAmount)
        {
            p_dblAmount = 0d;

            long lngRes = 0;

            try
            {
                string strSQL = @"select netamount_int from t_ms_outstorage_detail where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_dblAmount = Convert.ToDouble(dtbValue.Rows[0]["netamount_int"]);
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
        /// 获取子表内容
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select a.seriesid_int,
			 a.seriesid2_int,
			 a.medicineid_chr,
			 a.medicinename_vch,
			 a.medspec_vchr,
			 a.opunit_chr,
			 a.netamount_int,
			 a.lotno_vchr,
			 a.instorageid_vchr,
			 a.callprice_int,
			 a.wholesaleprice_int,
			 a.retailprice_int,
			 a.vendorid_chr,
			 a.netamount_int originality_Amount,
			 a.rejectreason,
			 a.status,
			 b.assistcode_chr,
			 b.medicinetypeid_chr,
			 c.opamount_int askamount,
			 e.vendorname_vchr,
			 b.productorid_chr,
			 j.instoragedate_dat,
			 j.validperiod_dat,
			 j.realgross_int,
			 j.availagross_int,
			 j.opunit_vchr storageunit,
			 a.oldgross_int,
			 b.ipunit_chr,
			 b.packqty_dec,
			 a.instorageid_vchr,
			 f.instoragedate_dat,
			 z.outstoragetype_int typecode_vchr,
             a.producedate_dat
	from t_ms_outstorage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_ms_outstorage d on a.seriesid2_int = d.seriesid_int
	left outer join t_ms_ask c on d.askid_vchr = c.askid_vchr
														and a.medicineid_chr = c.medicineid_chr
	left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
	left join t_ms_instorage f on f.instorageid_vchr = a.instorageid_vchr
 inner join t_ms_storage_detail j on j.storageid_chr = d.storageid_chr
																 and j.medicineid_chr = a.medicineid_chr
																 and a.lotno_vchr = j.lotno_vchr
																 and a.instorageid_vchr =
																		 j.instorageid_vchr
																 and a.validperiod_dat = j.validperiod_dat
																 and a.callprice_int = j.callprice_int
																 and j.status = 1
	left join t_ms_outstorage z on z.seriesid_int = a.seriesid2_int
 where a.seriesid2_int = ?
   and a.status = 1
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

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

        #region 添加新的药品出库(主表)
        /// <summary>
        /// 添加新的药品出库(主表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOutStorage(System.Security.Principal.IPrincipal p_objPrincipal,ref clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
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
   outstoragedate_dat,receiptorid_chr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_OUTSTORAGE", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }
                p_objMain.m_lngSERIESID_INT = lngSEQ;

                string strOutStorageID = string.Empty;
                string strType = "2";
                if (p_objMain.m_intFORMTYPE_INT == 1)
                {
                    strType = "2";
                }
                else if (p_objMain.m_intFORMTYPE_INT == 2 || p_objMain.m_intFORMTYPE_INT == 5)
                {
                    strType = "3";
                }
                else if (p_objMain.m_intFORMTYPE_INT == 3)
                {
                    strType = "6";
                }
                else if (p_objMain.m_intFORMTYPE_INT == 4)
                {
                    strType = "5";
                }
                lngRes = m_lngGetLatestOutStorageID(p_objPrincipal,strType, out strOutStorageID);
                if (lngRes < 0 || string.IsNullOrEmpty(strOutStorageID))
                {
                    return -1;
                }
                p_objMain.m_strOUTSTORAGEID_VCHR = strOutStorageID;

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(19, out objDPArr);
                objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                objDPArr[1].Value = p_objMain.m_strSTORAGEID_CHR;
                objDPArr[2].Value = p_objMain.m_strOUTSTORAGEID_VCHR;
                objDPArr[3].Value = p_objMain.m_intOutStorageTYPE_INT;
                objDPArr[4].Value = p_objMain.m_intFORMTYPE_INT;
                objDPArr[5].Value = p_objMain.m_strEXPORTDEPT_CHR;
                objDPArr[6].Value = p_objMain.m_strASKDEPT_CHR;
                objDPArr[7].Value = p_objMain.m_intSTATUS;
                objDPArr[8].DbType = DbType.DateTime;
                objDPArr[8].Value = DateTime.Parse(p_objMain.m_dtmASKDATE_DAT.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[9].DbType = DbType.DateTime;
                objDPArr[9].Value = DBNull.Value;
                objDPArr[10].DbType = DbType.DateTime;
                objDPArr[10].Value = DBNull.Value;
                objDPArr[11].Value = p_objMain.m_strASKERID_CHR;
                objDPArr[12].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[13].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[14].Value = p_objMain.m_strASKID_VCHR;
                objDPArr[15].Value = p_objMain.m_strPARENTNID;
                objDPArr[16].Value = p_objMain.m_strCOMMENT_VCHR;
                objDPArr[17].DbType = DbType.DateTime;
                objDPArr[17].Value = p_objMain.m_dtmOutStorageDate;
                objDPArr[18].Value = p_objMain.m_strRECEIPTORID_CHR;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngEff > 0)
                {
                    strSQL = @" update t_ds_ask a set a.outstorageid_vchr=? ,a.status_int=3 where a.askid_vchr=?";
                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_objMain.m_strOUTSTORAGEID_VCHR;
                    objDPArr[1].Value = p_objMain.m_strASKID_VCHR;
                    objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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

        #region 最新的出库单据号

        /// <summary>
        /// 最新的出库单据号

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strType">出库类型</param>
        /// <param name="p_strID">返回单据号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLatestOutStorageID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strType, out string p_strID)
        {
            p_strID = string.Empty;

            long lngRes = -1;
            try
            {
                string strSQL = @"select max(t.outstorageid_vchr)
  from t_ms_outstorage t
 where t.outstorageid_vchr like ?";

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

        #region 添加新的药品出库(明细表)
        /// <summary>
        /// 添加新的药品出库(明细表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">明细表数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal,ref clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"insert into t_ms_outstorage_detail
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
   returnnum_int,
   validperiod_dat,
   oldgross_int,producedate_dat,askamount_int)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                long[] lngSEQArr = null;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;
                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_OUTSTORAGE_DETAIL", p_objDetailArr.Length, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(20, out objLisAddItemRefArr);
                        p_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objLisAddItemRefArr[0].Value = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        objLisAddItemRefArr[1].Value = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objLisAddItemRefArr[2].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[3].Value = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[4].Value = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[5].Value = p_objDetailArr[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[6].Value = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objLisAddItemRefArr[7].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[8].Value = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[9].Value = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objLisAddItemRefArr[10].Value = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[11].Value = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objLisAddItemRefArr[12].Value = p_objDetailArr[iRow].m_strVENDORID_CHR;
                        objLisAddItemRefArr[13].Value = p_objDetailArr[iRow].m_strRejectReason;
                        objLisAddItemRefArr[14].Value = p_objDetailArr[iRow].m_intStatus;
                        objLisAddItemRefArr[15].Value = p_objDetailArr[iRow].m_intRETURNNUM_INT;
                        objLisAddItemRefArr[16].DbType = DbType.DateTime;
                        objLisAddItemRefArr[16].Value = p_objDetailArr[iRow].m_dtmValidperiod_dat;
                        objLisAddItemRefArr[17].Value = p_objDetailArr[iRow].m_dblOldGross;
                        objLisAddItemRefArr[18].Value = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        objLisAddItemRefArr[19].Value = p_objDetailArr[iRow].m_dblAskAmount;
                        

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64, DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.Double,
                        DbType.String,DbType.String,DbType.Decimal,DbType.Decimal,DbType.Decimal,DbType.String,DbType.String,DbType.Int32,DbType.Int32,
                        DbType.DateTime,DbType.Double,DbType.DateTime,DbType.Double};

                    object[][] objValues = new object[20][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    lngRes = objPublic.m_lngGetSequenceArr(p_objPrincipal, "SEQ_MS_OUTSTORAGE_DETAIL", intItemCount, out lngSEQArr);
                    if (lngSEQArr == null || lngSEQArr.Length == 0)
                    {
                        return -1;
                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        p_objDetailArr[iRow].m_lngSERIESID_INT = lngSEQArr[iRow];
                        objValues[0][iRow] = lngSEQArr[iRow];
                        objValues[1][iRow] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_strOPUNIT_CHR;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[8][iRow] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[9][iRow] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[10][iRow] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[11][iRow] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[12][iRow] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                        objValues[13][iRow] = p_objDetailArr[iRow].m_strRejectReason;
                        objValues[14][iRow] = p_objDetailArr[iRow].m_intStatus;
                        objValues[15][iRow] = p_objDetailArr[iRow].m_intRETURNNUM_INT;
                        objValues[16][iRow] = p_objDetailArr[iRow].m_dtmValidperiod_dat;
                        objValues[17][iRow] = p_objDetailArr[iRow].m_dblOldGross;
                        objValues[18][iRow] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        objValues[19][iRow] = p_objDetailArr[iRow].m_dblAskAmount;
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

        #region 修改药品出库信息(主表)
        /// <summary>
        /// 修改药品出库信息(主表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">药品库存信息(主表)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_outstorage
   set storageid_chr      = ?,
       outstorageid_vchr  = ?,
       outstoragetype_int = ?,
       formtype           = ?,
       exportdept_chr     = ?,
       askdept_chr        = ?,
       status             = ?,
       askdate_dat        = ?,
       examdate_dat       = ?,
       inaccountdate_dat  = ?,
       askerid_chr        = ?,
       examerid_chr       = ?,
       inaccountid_chr    = ?,
       askid_vchr         = ?,
       parentnid          = ?,
       comment_vchr       = ?,
       outstoragedate_dat = ?,
       receiptorid_chr    = ?
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(19, out objDPArr);
                objDPArr[0].Value = p_objMain.m_strSTORAGEID_CHR;
                objDPArr[1].Value = p_objMain.m_strOUTSTORAGEID_VCHR;
                objDPArr[2].Value = p_objMain.m_intOutStorageTYPE_INT;
                objDPArr[3].Value = p_objMain.m_intFORMTYPE_INT;
                objDPArr[4].Value = p_objMain.m_strEXPORTDEPT_CHR;
                objDPArr[5].Value = p_objMain.m_strASKDEPT_CHR;
                objDPArr[6].Value = p_objMain.m_intSTATUS;
                objDPArr[7].DbType = DbType.DateTime;
                objDPArr[7].Value = DateTime.Parse(p_objMain.m_dtmASKDATE_DAT.ToString("yyyy-MM-dd HH:mm:ss"));
                objDPArr[8].Value = DBNull.Value;
                objDPArr[9].Value = DBNull.Value;
                objDPArr[10].Value = p_objMain.m_strASKERID_CHR;
                objDPArr[11].Value = p_objMain.m_strEXAMERID_CHR;
                objDPArr[12].Value = p_objMain.m_strINACCOUNTID_CHR;
                objDPArr[13].Value = p_objMain.m_strASKID_VCHR;
                objDPArr[14].Value = p_objMain.m_strPARENTNID;
                objDPArr[15].Value = p_objMain.m_strCOMMENT_VCHR;
                objDPArr[16].DbType = DbType.DateTime;
                objDPArr[16].Value = p_objMain.m_dtmOutStorageDate;
                objDPArr[17].Value = p_objMain.m_strRECEIPTORID_CHR;
                objDPArr[18].Value = p_objMain.m_lngSERIESID_INT;

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

        #region 修改药品出库信息(明细表)
        /// <summary>
        /// 修改药品出库信息(明细表)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetailArr">修改药品出库信息(明细表)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (p_objDetailArr == null || p_objDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_outstorage_detail
   set seriesid2_int      = ?,
       medicineid_chr     = ?,
       medicinename_vch   = ?,
       medspec_vchr       = ?,
       opunit_chr         = ?,
       netamount_int      = ?,
       lotno_vchr         = ?,
       instorageid_vchr   = ?,
       callprice_int      = ?,
       wholesaleprice_int = ?,
       retailprice_int    = ?,
       vendorid_chr       = ?,
       rejectreason       = ?,
       status             = ?,
       returnnum_int      = ?,
       validperiod_dat    = ?,
       producedate_dat    = ?,
 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();                
                long lngEff = -1;
                
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objLisAddItemRefArr = null;                    

                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(18, out objLisAddItemRefArr);
                        objLisAddItemRefArr[0].Value = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objLisAddItemRefArr[1].Value = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objLisAddItemRefArr[2].Value = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objLisAddItemRefArr[3].Value = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objLisAddItemRefArr[4].Value = p_objDetailArr[iRow].m_strOPUNIT_CHR;
                        objLisAddItemRefArr[5].Value = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objLisAddItemRefArr[6].Value = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objLisAddItemRefArr[7].Value = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objLisAddItemRefArr[8].Value = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objLisAddItemRefArr[9].Value = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objLisAddItemRefArr[10].Value = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objLisAddItemRefArr[11].Value = p_objDetailArr[iRow].m_strVENDORID_CHR;
                        objLisAddItemRefArr[12].Value = p_objDetailArr[iRow].m_strRejectReason;
                        objLisAddItemRefArr[13].Value = p_objDetailArr[iRow].m_intStatus;
                        objLisAddItemRefArr[14].Value = p_objDetailArr[iRow].m_intRETURNNUM_INT;
                        objLisAddItemRefArr[15].DbType = DbType.DateTime;
                        objLisAddItemRefArr[15].Value = p_objDetailArr[iRow].m_dtmValidperiod_dat;
                        objLisAddItemRefArr[16].Value = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT; 
                        objLisAddItemRefArr[17].Value = p_objDetailArr[iRow].m_lngSERIESID_INT;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objLisAddItemRefArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int64,DbType.String,DbType.String,DbType.String,DbType.String,DbType.Double,
                        DbType.String,DbType.String,DbType.Decimal,DbType.Decimal,DbType.Decimal,DbType.String, DbType.String,DbType.Int32,
                        DbType.Int32, DbType.DateTime, DbType.DateTime, DbType.Int64};

                    object[][] objValues = new object[18][];

                    int intItemCount = p_objDetailArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }
                   
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        objValues[1][iRow] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        objValues[2][iRow] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        objValues[3][iRow] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        objValues[4][iRow] = p_objDetailArr[iRow].m_strOPUNIT_CHR;
                        objValues[5][iRow] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objValues[6][iRow] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        objValues[7][iRow] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objValues[8][iRow] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objValues[9][iRow] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        objValues[10][iRow] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        objValues[11][iRow] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                        objValues[12][iRow] = p_objDetailArr[iRow].m_strRejectReason;
                        objValues[13][iRow] = p_objDetailArr[iRow].m_intStatus;
                        objValues[14][iRow] = p_objDetailArr[iRow].m_intRETURNNUM_INT;
                        objValues[15][iRow] = p_objDetailArr[iRow].m_dtmValidperiod_dat;
                        objValues[16][iRow] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        objValues[17][iRow] = p_objDetailArr[iRow].m_lngSERIESID_INT;
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

        #region 删除出库明细
        /// <summary>
        /// 删除本次出库单出库明细

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"delete from t_ms_outstorage_detail a where a.seriesid2_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

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
        /// 更新出库明细表状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageDetailStatusByMainSEQ(System.Security.Principal.IPrincipal p_objPrincipal,int p_intStatus, long p_lngMainSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_outstorage_detail a set a.status = ? where a.seriesid2_int = ? and a.status = 1";

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

        /// <summary>
        /// 更新出库明细表状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngMainSEQArr">主表序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageDetailStatusByMainSEQ(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long[] p_lngMainSEQArr)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_outstorage_detail a set a.status = ? where a.seriesid2_int = ? and a.status = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iRow = 0; iRow < p_lngMainSEQArr.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_intStatus;
                        objDPArr[1].Value = p_lngMainSEQArr[iRow];

                        long lngEff = -1;
                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32, DbType.Int64 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_lngMainSEQArr.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_intStatus;
                        objValues[1][iRow] = p_lngMainSEQArr[iRow];
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
        /// 更新出库明细表状态

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus">更新后的状态</param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStorageDetailStatus(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, long p_lngSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_outstorage_detail a set a.status = ? where a.seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_intStatus;
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

        /// <summary>
        /// 删除指定出库明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSpecOutStorageDetail(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"delete from t_ms_outstorage_detail a where a.seriesid_int = ?";

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
                string strSQL = @"update t_ms_outstorage set examerid_chr = ?,examdate_dat = ?,status=2 where seriesid_int = ?";

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
        /// 设置入帐者

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmDate">入帐时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strOutStorageID">出库单号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmDate, string p_strStorageID, string[] p_strOutStorageID)
        {
            if (p_strOutStorageID == null || p_strOutStorageID.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_outstorage set inaccountid_chr = ?,inaccountdate_dat = ?,status=3 where outstorageid_vchr = ? and storageid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < p_strOutStorageID.Length; iRow++)
                    {
                        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                        objDPArr[0].Value = p_strEmpID;
                        objDPArr[1].DbType = DbType.DateTime;
                        objDPArr[1].Value = dtmNow;
                        objDPArr[2].Value = p_strOutStorageID[iRow];
                        objDPArr[3].Value = p_strStorageID;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.String, DbType.DateTime, DbType.String, DbType.String };

                    object[][] objValues = new object[4][];

                    int intItemCount = p_strOutStorageID.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化



                    }

                    DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_strEmpID;
                        objValues[1][iRow] = dtmNow;
                        objValues[2][iRow] = p_strOutStorageID[iRow];
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
        /// <param name="p_dtmDate">入帐时间</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID, DateTime p_dtmDate, long[] p_lngSeq)
        {
            if (p_lngSeq == null || p_lngSeq.Length == 0 || string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_outstorage set inaccountid_chr = ?,inaccountdate_dat = ?,status=3 where seriesid_int = ?";

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
        /// 设置入帐者
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmDate">入帐时间</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetAccountUser(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpID,DateTime p_dtmDate, long p_lngSeq)
        {
            if ( string.IsNullOrEmpty(p_strEmpID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"update t_ms_outstorage set inaccountid_chr = ?,inaccountdate_dat = ?,status=3 where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strEmpID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmDate;
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

        #region 删除指定出库主表信息
        /// <summary>
        /// 删除指定出库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMainOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_outstorage
   set status = 0
 where seriesid_int = ?
   and status = 1";

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
        #endregion

        #region 删除指定出库主表信息（即入即出）
        /// <summary>
        /// 删除指定出库主表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteMainOutStorageInOut(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngSEQ)
        {
            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_outstorage
   set status = 0
 where seriesid_int = ?";

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
                string strSQL = @"update t_ms_outstorage set status=1 where seriesid_int = ?";

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

        #region 获取指定药品出库数量
        /// <summary>
        /// 获取指定药品出库数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_hstNetAmount">针对指定药物，以批号+入库单号为键，出库数量为值的哈希表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNetAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            p_hstNetAmount = new Hashtable();
            long lngRes = 0;

            try
            {
                string strSQL = @"select a.netamount_int,
        case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end lotno_vchr,
        a.instorageid_vchr,
        a.validperiod_dat,
        a.callprice_int
  from t_ms_outstorage_detail a, t_ms_outstorage b
 where a.seriesid2_int = b.seriesid_int
   and b.seriesid_int = ?
   and a.medicineid_chr = ?
   and a.status = 1
 order by a.lotno_vchr, a.instorageid_vchr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;
                objDPArr[1].Value = p_strMedicineID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbValue.Rows[iRow];
                        p_hstNetAmount.Add(drTemp["lotno_vchr"].ToString().PadLeft(10, '0') + drTemp["instorageid_vchr"].ToString() + Convert.ToDateTime(drTemp["validperiod_dat"]).ToString("yyyy-MM-dd HH:mm:ss") + Convert.ToDouble(drTemp["callprice_int"]).ToString("0.0000"), drTemp["netamount_int"].ToString());
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

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormID">单据类型</param>
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllInMoney(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID,
            int p_intFormID, out DataTable p_dtbMoney)
        {
            p_dtbMoney = null;
            long lngRes = 0;

            try
            {
                string strSQL;
                if (p_intFormID == 2)
                {
                    strSQL = @"select a.outstorageid_vchr,b.netamount_int * b.callprice_int buyinmoney,
       b.netamount_int * b.wholesaleprice_int wholesalemoney,
       b.netamount_int * b.retailprice_int retailprice,
       a.seriesid_int,
       a.outstoragetype_int,
       a.status
  from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.seriesid_int = b.seriesid2_int
   and a.askdate_dat between ? and ?
   and a.storageid_chr = ?
   and (a.formtype = ? or a.formtype = 5)
   and b.status = 1
   and a.status <> 0";
                }
                else
                {
                    strSQL = @"select a.outstorageid_vchr,b.netamount_int * b.callprice_int buyinmoney,
       b.netamount_int * b.wholesaleprice_int wholesalemoney,
       b.netamount_int * b.retailprice_int retailprice,
       a.seriesid_int,
       a.outstoragetype_int,
       a.status
  from t_ms_outstorage a, t_ms_outstorage_detail b
 where a.seriesid_int = b.seriesid2_int
   and a.askdate_dat between ? and ?
   and a.storageid_chr = ?
   and a.formtype = ?
   and b.status = 1
   and a.status <> 0";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].DbType = DbType.DateTime;
                objDPArr[0].Value = p_dtmBegin;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmEnd;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_intFormID;

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

        #region 获取子表内容(报表打印)
        /// <summary>
        /// 获取子表内容 (报表打印)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <param name="p_strDBConfig">第二个数据库的参数配置</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailReport(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, int intType, out DataTable p_dtbValue, string p_strDBConfig)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select k.medicinetypename_vchr medicinetypesetname,
       k.medicinetypeid_chr medicinetypesetid, a.seriesid_int,
       a.seriesid2_int, a.medicineid_chr, a.medicinename_vch, a.medspec_vchr,
       a.opunit_chr, a.netamount_int,
       case
         when a.lotno_vchr = 'UNKNOWN' then
          ''
         else
          a.lotno_vchr
       end lotno_vchr, a.instorageid_vchr, a.callprice_int,
       a.wholesaleprice_int, a.retailprice_int, a.vendorid_chr,
       a.rejectreason, b.assistcode_chr, c.opamount_int askamount,
       e.vendorname_vchr, b.productorid_chr, j.instoragedate_dat,
       j.validperiod_dat, j.realgross_int, j.availagross_int,
       j.opunit_vchr storageunit,
       case d.outstoragetype_int
         when 3 then
          w.oldgross_int
         else
          w.oldgross_int - w.netamount_int
       end oldgross_int,
       a.oldgross_int oldgross_int2, d.storageid_chr
  from t_ms_outstorage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left join t_aid_medicinetype k on k.medicinetypeid_chr =
                                    b.medicinetypeid_chr
 inner join t_ms_outstorage d on a.seriesid2_int = d.seriesid_int
  left outer join t_ms_ask c on d.askid_vchr = c.askid_vchr
                            and a.medicineid_chr = c.medicineid_chr
  left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
  left join t_ms_storage_detail j on j.storageid_chr = d.storageid_chr
                                 and j.medicineid_chr = a.medicineid_chr
                                 and a.lotno_vchr = j.lotno_vchr
                                 and a.instorageid_vchr =
                                     j.instorageid_vchr
                                 and a.validperiod_dat = j.validperiod_dat
                                 and a.callprice_int = j.callprice_int
  left join (select x.seriesid2_int, x.medicineid_chr, x.oldgross_int,
                    sum(x.netamount_int) netamount_int
               from t_ms_outstorage_detail x
              where x.status = 1
              group by x.seriesid2_int, x.medicineid_chr, x.oldgross_int) w on w.seriesid2_int =
                                                                               a.seriesid2_int
                                                                           and w.medicineid_chr =
                                                                               a.medicineid_chr
 where a.seriesid2_int = ?
   and j.status = 1
   and a.status = 1 ";

                if (intType == 0)
                {
                    strSQL += @"order by b.medicinetypeid_chr,b.assistcode_chr";
                }

                if (intType == 1)
                {
                    strSQL += @"order by b.medicinetypeid_chr,a.seriesid_int";
                }

                string strStorageID = string.Empty;
                string strAssistCode = string.Empty;
                bool blnComeOn = false;//是否继续查
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);
                DataRow dr = null;
                if (p_dtbValue != null && p_dtbValue.Rows.Count > 0)
                {
                    blnComeOn = true;
                    strStorageID = p_dtbValue.Rows[0]["storageid_chr"].ToString();

                    for (int i1 = 0; i1 < p_dtbValue.Rows.Count; i1++)
                    {
                        dr = p_dtbValue.Rows[i1];
                        if (!strAssistCode.Contains(dr["assistcode_chr"].ToString()))
                            strAssistCode += "'" + dr["assistcode_chr"].ToString() + "',";
                    }
                    if (strAssistCode.Length > 0)
                    {
                        strAssistCode = strAssistCode.Substring(0, strAssistCode.Length - 1);
                        blnComeOn = true;
                    }
                }
                p_dtbValue.Columns.Remove("storageid_chr");
                objHRPServ.Dispose();
                objHRPServ = null;

                //20091022:取消此功能
                /*
                //20090421:获取第二个数据库是否已建立连接
                //p_strDBConfig.Length > 0 && 
                if (blnComeOn == true)
                {
                    DataTable dtbTemp = new DataTable();
                    
                    strSQL = @"select b.assistcode_chr, sum(a.realgross_int) seconddbamount
  from t_ms_storage_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where a.storageid_chr = ?
and b.assistcode_chr in ( ? )
and a.status = 1
 group by b.assistcode_chr";
                    clsHRPTableService objHRPServ2 = new clsHRPTableService();
                    objHRPServ2.m_bytSetOtherDSN = (byte)com.digitalwave.iCare.middletier.HRPService.clsHRPTableService.enumDatabase.bytMed;
                    objDPArr = null;
                    objHRPServ2.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = strStorageID;
                    objDPArr[1].Value = strAssistCode;

                    objHRPServ2.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objDPArr);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["assistcode_chr"] };

                        DataRow drow2 = null;
                        foreach (DataRow drow in p_dtbValue.Rows)
                        {
                            drow2 = dtbTemp.Rows.Find(drow["assistcode_chr"].ToString());
                            if (drow2 != null)
                                drow["oldgross_int2"] = Convert.ToDouble(drow["oldgross_int2"]) + Convert.ToDouble(drow2["seconddbamount"]);
                        }
                    }
                    objHRPServ2.Dispose();
                    objHRPServ2 = null;
                }
               */
                //添加当前分批号的库存数


                //if (lngRes > 0 && p_dtbValue.Rows.Count > 0)
                //{
                //    double douGross=0;
                //    for (int iRows = 0; iRows < p_dtbValue.Rows.Count; iRows++)
                //    {
                //        m_lngGetMedicineGross(null, p_dtbValue.Rows[iRows]["medicineid_chr"].ToString(), p_dtbValue.Rows[iRows]["lotno_vchr"].ToString(), out douGross);
                //        p_dtbValue.Rows[iRows]["oldgross_int"] = douGross;
                //    }


                //}

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取指定出库单各药品的总库存
        /// <summary>
        /// 获取指定出库单各药品的总库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">各药品的总库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAllGross(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out clsMS_MedicineGross[] p_objGross)
        {
            p_objGross = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select sum(realgross_int) allrealgross,
       sum(availagross_int) allavagross,
       medicineid_chr
  from (select distinct a.realgross_int,
                        a.availagross_int,
                        a.medicineid_chr,
                        a.seriesid_int
          from t_ms_storage_detail a
         inner join t_ms_outstorage_detail b on a.medicineid_chr =
                                                b.medicineid_chr
                                            and b.status = 1
         inner join t_ms_outstorage c on c.seriesid_int = b.seriesid2_int
                                     and c.storageid_chr = a.storageid_chr
                                     and c.status <> 0
         where c.seriesid_int = ?
           and a.status = 1)
 group by medicineid_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                DataTable dtbGross = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbGross, objDPArr);

                if (dtbGross != null)
                {
                    int intRowsCount = dtbGross.Rows.Count;
                    if (intRowsCount == 0)
                    {
                        return 0;
                    }

                    p_objGross = new clsMS_MedicineGross[intRowsCount];
                    DataRow drTemp = null;
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        drTemp = dtbGross.Rows[iRow];
                        p_objGross[iRow] = new clsMS_MedicineGross();
                        p_objGross[iRow].m_strMedicineID = drTemp["medicineid_chr"].ToString();
                        p_objGross[iRow].m_dblAvailaGross = Convert.ToDouble(drTemp["allavagross"]);
                        p_objGross[iRow].m_dblRealGross = Convert.ToDouble(drTemp["allrealgross"]);
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

        #region 获取指定药品指定批号的总库存

        /// <summary>
        /// 获取指定药品指定批号的总库存

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">总库存</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineid,string p_strLotno, out double p_douGross)
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

        #region 审核出库记录
        /// <summary>
        /// 审核出库记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">出库药品</param>
        /// <param name="p_objAccDetailArr">帐本明细</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_lngSeq">出库主表序列</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCommitOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objDetail,clsMS_AccountDetail_VO[] p_objAccDetailArr, string p_strEmpID, long p_lngSeq, bool p_blnIsImmAccount)
        {
            if (p_objDetail == null || p_objDetail.Length == 0 || p_objAccDetailArr == null || p_objAccDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                clsStorageSVC objSTSvc = new clsStorageSVC();
                lngRes = objSTSvc.m_lngSubStorageDetailRealGross(p_objPrincipal, p_objDetail);
                if (lngRes > 0)
                {
                    Hashtable hstMedicine = new Hashtable();
                    ArrayList arrMed = new ArrayList();
                    for (int iMed = 0; iMed < p_objDetail.Length; iMed++)
                    {
                        if (!hstMedicine.Contains(p_objDetail[iMed].m_strMedicineID))
                        {
                            hstMedicine.Add(p_objDetail[iMed].m_strMedicineID, p_objDetail[iMed].m_strStorageID);
                            arrMed.Add(p_objDetail[iMed]);
                        }
                    }

                    if (arrMed.Count > 0)
                    {
                        clsMS_StorageGrossForOut[] objMainStorage = arrMed.ToArray(typeof(clsMS_StorageGrossForOut)) as clsMS_StorageGrossForOut[];
                        lngRes = objSTSvc.m_lngUpdateStorageCurrentGross(p_objPrincipal, objMainStorage);
                        objSTSvc = null;

                        if (lngRes > 0)
                        {
                            long[] lngSEQ = new long[]{p_lngSeq};
                            lngRes = m_lngSetCommitUser(p_objPrincipal, p_strEmpID, lngSEQ);
                            if (lngRes <= 0)
                            {
                                throw new Exception();
                            }
                        }
                    }

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                    lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, p_objAccDetailArr);
                    objAcSVC = null;
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }                    

                    if (lngRes > 0 && p_blnIsImmAccount)
                    {
                        lngRes = m_lngSetAccountUser(p_objPrincipal, p_strEmpID, p_objAccDetailArr[0].m_dtmINACCOUNTDATE_DAT, p_lngSeq);
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

        #region 退审出库记录

        /// <summary>
        /// 退审出库记录

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">出库药品</param>
        /// <param name="p_lngSeq">主表序列号</param>
        /// <param name="p_strOutStorageID">出库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUnCommitOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_StorageGrossForOut[] p_objDetail, long p_lngSeq,string p_strOutStorageID, string p_strStorageID)
        {
            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                clsStorageSVC objSTSvc = new clsStorageSVC();
                lngRes = objSTSvc.m_lngAddStorageDetailRealGross(p_objPrincipal, p_objDetail);
                if (lngRes > 0)
                {
                    Hashtable hstMedicine = new Hashtable();
                    ArrayList arrMed = new ArrayList();
                    for (int iMed = 0; iMed < p_objDetail.Length; iMed++)
                    {
                        if (!hstMedicine.Contains(p_objDetail[iMed].m_strMedicineID))
                        {
                            hstMedicine.Add(p_objDetail[iMed].m_strMedicineID, p_objDetail[iMed].m_strStorageID);
                            arrMed.Add(p_objDetail[iMed]);
                        }
                    }

                    if (arrMed.Count > 0)
                    {
                        clsMS_StorageGrossForOut[] objMainStorage = arrMed.ToArray(typeof(clsMS_StorageGrossForOut)) as clsMS_StorageGrossForOut[];
                        lngRes = objSTSvc.m_lngUpdateStorageCurrentGross(p_objPrincipal, objMainStorage);
                        objSTSvc = null;

                        if (lngRes > 0)
                        {
                            long[] lngSEQ = new long[] { p_lngSeq };
                            lngRes = m_lngUnCommit(p_objPrincipal, lngSEQ);
                        }
                    }

                    clsMS_AccountSVC objAccSVC = new clsMS_AccountSVC();
                    long lngRes1 = objAccSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strOutStorageID, p_strStorageID);
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
        #region 药库审核保存出库记录
        /// <summary>
        ///药库审核保存出库记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewDetailArr">新出库明细</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveOutStorageByStorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewDetailArr, bool p_blnIsCommit, bool p_lngIsAddNew, bool p_blnIsImmAccount)
        {
            if (p_objMain == null || p_objNewDetailArr == null || p_objNewDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();
                Hashtable hstMedicine = new Hashtable();//涉及到的最终要统计库存的药品

                if (p_objOldDetailArr != null && p_objOldDetailArr.Length > 0)
                {
                    if (p_blnIsCommit)//如果保存后即审核，则先将已有记录退审，保存成功后再重新审核
                    {
                        clsMS_StorageDetail[] objSTDetail = new clsMS_StorageDetail[p_objOldDetailArr.Length];
                        for (int iRow = 0; iRow < p_objOldDetailArr.Length; iRow++)
                        {
                            objSTDetail[iRow] = new clsMS_StorageDetail();
                            objSTDetail[iRow].m_dblAVAILAGROSS_INT = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objSTDetail[iRow].m_dblREALGROSS_INT = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objSTDetail[iRow].m_strMEDICINEID_CHR = p_objOldDetailArr[iRow].m_strMEDICINEID_CHR;
                            if (p_objOldDetailArr[iRow].m_strLOTNO_VCHR == "")
                            {
                                objSTDetail[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                            }
                            else
                            {
                                objSTDetail[iRow].m_strLOTNO_VCHR = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            }
                            //objSTDetail[iRow].m_strLOTNO_VCHR = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            objSTDetail[iRow].m_strINSTORAGEID_VCHR = p_objOldDetailArr[iRow].m_strINSTORAGEID_VCHR;
                            objSTDetail[iRow].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                            objSTDetail[iRow].m_dcmCALLPRICE_INT = p_objOldDetailArr[iRow].m_dcmCALLPRICE_INT;
                            objSTDetail[iRow].m_dtmVALIDPERIOD_DAT = p_objOldDetailArr[iRow].m_dtmValidperiod_dat;

                            if (!hstMedicine.Contains(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR))
                            {
                                hstMedicine.Add(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            }
                        }

                        lngRes = objStSVC.m_lngAddStorageDetailRealGross(p_objPrincipal, objSTDetail);
                    }
                    else
                    {
                        clsMS_StorageGrossForOut[] objGrossDetailArr = new clsMS_StorageGrossForOut[p_objOldDetailArr.Length];

                        for (int iRow = 0; iRow < p_objOldDetailArr.Length; iRow++)
                        {
                            objGrossDetailArr[iRow] = new clsMS_StorageGrossForOut();
                            objGrossDetailArr[iRow].m_strMedicineID = p_objOldDetailArr[iRow].m_strMEDICINEID_CHR;
                            objGrossDetailArr[iRow].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            objGrossDetailArr[iRow].m_strInStorageID = p_objOldDetailArr[iRow].m_strINSTORAGEID_VCHR;
                            if (p_objOldDetailArr[iRow].m_strLOTNO_VCHR == "")
                            {
                                objGrossDetailArr[iRow].m_strLotNO = "UNKNOWN";
                            }
                            else
                            {
                                objGrossDetailArr[iRow].m_strLotNO = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            }
                            objGrossDetailArr[iRow].m_dblGross = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objGrossDetailArr[iRow].m_dblInPrice = Convert.ToDouble(p_objOldDetailArr[iRow].m_dcmCALLPRICE_INT);
                            objGrossDetailArr[iRow].m_dtmValidDate = p_objOldDetailArr[iRow].m_dtmValidperiod_dat;

                            if (!hstMedicine.Contains(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR))
                            {
                                hstMedicine.Add(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            }
                        }
                        //先将旧有记录中的药品的可用库存回复

                        lngRes = objStSVC.m_lngAddStorageDetailAvailaGross(p_objPrincipal, objGrossDetailArr);
                    }

                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (p_lngIsAddNew)
                {
                    lngRes = m_lngAddNewOutStorage(p_objPrincipal, ref p_objMain);
                }
                else
                {
                    lngRes = m_lngModifyOutStorage(p_objPrincipal, p_objMain);
                    if (lngRes > 0)
                    {
                        lngRes = m_lngUpdateStorageDetailStatusByMainSEQ(p_objPrincipal, -1, p_objMain.m_lngSERIESID_INT);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                if (lngRes > 0)
                {
                    for (int iDel = 0; iDel < p_objNewDetailArr.Length; iDel++)
                    {
                        p_objNewDetailArr[iDel].m_lngSERIESID2_INT = p_objMain.m_lngSERIESID_INT;
                    }
                    lngRes = m_lngAddNewOutStorageDetail(p_objPrincipal, ref p_objNewDetailArr);
                }
                else
                {
                    throw new Exception();
                }

                #region 获取各药品出库前的实际库存

                if (lngRes > 0 && p_blnIsCommit)
                {
                    string strSQL = @"select t.seriesid_int, s.realgross_int
  from t_ms_outstorage_detail t, t_ms_storage_detail s
 where t.seriesid2_int = ?
   and t.status = 1
   and t.medicineid_chr = s.medicineid_chr
   and t.lotno_vchr = s.lotno_vchr
   and t.instorageid_vchr = s.instorageid_vchr
   and s.status = 1
   and s.storageid_chr = ?";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                    objDPArr[1].Value = p_objMain.m_strSTORAGEID_CHR;

                    DataTable dtbSt = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbSt, objDPArr);
                    if (lngRes > 0 && dtbSt != null)
                    {
                        DataRow[] drRow = null;
                        for (int iSt = 0; iSt < p_objNewDetailArr.Length; iSt++)
                        {
                            drRow = dtbSt.Select("seriesid_int = " + p_objNewDetailArr[iSt].m_lngSERIESID_INT.ToString());
                            if (drRow != null && drRow.Length > 0)
                            {
                                p_objNewDetailArr[iSt].m_dblRealGross = Convert.ToDouble(drRow[0]["realgross_int"]);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                #endregion

                if (lngRes > 0)
                {
                    clsMS_StorageDetail[] objNewSTDetail = new clsMS_StorageDetail[p_objNewDetailArr.Length];
                    for (int iRow = 0; iRow < p_objNewDetailArr.Length; iRow++)
                    {
                        objNewSTDetail[iRow] = new clsMS_StorageDetail();
                        objNewSTDetail[iRow].m_dblAVAILAGROSS_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objNewSTDetail[iRow].m_dblREALGROSS_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objNewSTDetail[iRow].m_strMEDICINEID_CHR = p_objNewDetailArr[iRow].m_strMEDICINEID_CHR;
                        objNewSTDetail[iRow].m_strLOTNO_VCHR = p_objNewDetailArr[iRow].m_strLOTNO_VCHR;
                        objNewSTDetail[iRow].m_strINSTORAGEID_VCHR = p_objNewDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objNewSTDetail[iRow].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                        objNewSTDetail[iRow].m_dcmCALLPRICE_INT = p_objNewDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objNewSTDetail[iRow].m_dtmVALIDPERIOD_DAT = p_objNewDetailArr[iRow].m_dtmValidperiod_dat;

                        if (!hstMedicine.Contains(p_objNewDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            hstMedicine.Add(p_objNewDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                        }
                    }

                    if (p_blnIsCommit)//减少库存
                    {
                        lngRes = objStSVC.m_lngSubStorageDetailGross(p_objPrincipal, objNewSTDetail);
                    }
                    else//只减少可用库存
                    {
                        lngRes = objStSVC.m_lngSubStorageDetailAvailaGross(p_objPrincipal, objNewSTDetail);
                    }

                    if (lngRes <= 0)
                    {
                        throw new Exception("出库数据大于可用库存");
                    }

                    if (hstMedicine.Count > 0 && p_blnIsCommit)
                    {
                        clsMS_StorageGrossForOut[] objOutGross = new clsMS_StorageGrossForOut[hstMedicine.Count];

                        int intMed = 0;
                        foreach (string strID in hstMedicine.Keys)
                        {
                            objOutGross[intMed] = new clsMS_StorageGrossForOut();
                            objOutGross[intMed].m_strMedicineID = strID;
                            objOutGross[intMed].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            intMed++;
                        }
                        lngRes = objStSVC.m_lngUpdateStorageCurrentGross(p_objPrincipal, objOutGross);
                        if (lngRes >= 0)
                        {
                            if (p_blnIsCommit)
                            {
                                long[] lngSEQ = new long[] { p_objMain.m_lngSERIESID_INT };
                                lngRes = m_lngSetCommitUser(p_objPrincipal, p_objMain.m_strASKERID_CHR, lngSEQ);
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }

                    if (p_blnIsCommit)
                    {
                        DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        
                        int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态

                        DateTime dtmInDate = p_blnIsImmAccount ? dtmNow : DateTime.MinValue;//入账日期
                        string strInEmp = p_blnIsImmAccount ? p_objMain.m_strASKERID_CHR : string.Empty;//入账人

                        //20091022 数量为0时不保存在流水表
                        int intLength = 0;
                        for (int i1 = 0; i1 < p_objNewDetailArr.Length; i1++)
                        {
                            if (p_objNewDetailArr[i1].m_dblNETAMOUNT_INT != 0)
                            {
                                intLength++;
                            }
                        }

                        if(intLength > 0)
                        {
                            clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[intLength];

                            int intRow = 0;
                            for(int iAcc = 0; iAcc < p_objNewDetailArr.Length; iAcc++)
                            {
                                if(p_objNewDetailArr[iAcc].m_dblNETAMOUNT_INT == 0)
                                    continue;
                                objAccArr[intRow] = new clsMS_AccountDetail_VO();
                                objAccArr[intRow].m_dblAMOUNT_INT = p_objNewDetailArr[iAcc].m_dblNETAMOUNT_INT;
                                objAccArr[intRow].m_dblCALLPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmCALLPRICE_INT;
                                objAccArr[intRow].m_dblOLDGROSS_INT = p_objNewDetailArr[iAcc].m_dblRealGross;
                                objAccArr[intRow].m_dblRETAILPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                                objAccArr[intRow].m_dblWHOLESALEPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                                objAccArr[intRow].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                                objAccArr[intRow].m_intFORMTYPE_INT = p_objMain.m_intFORMTYPE_INT;
                                objAccArr[intRow].m_intISEND_INT = 0;
                                objAccArr[intRow].m_intSTATE_INT = intAccState;
                                objAccArr[intRow].m_intTYPE_INT = 2;
                                objAccArr[intRow].m_strCHITTYID_VCHR = p_objMain.m_strOUTSTORAGEID_VCHR;
                                objAccArr[intRow].m_strDEPTID_CHR = p_objMain.m_strASKDEPT_CHR;
                                objAccArr[intRow].m_strINACCOUNTID_CHR = strInEmp;
                                objAccArr[intRow].m_strINSTORAGEID_VCHR = p_objNewDetailArr[iAcc].m_strINSTORAGEID_VCHR;
                                objAccArr[intRow].m_strLOTNO_VCHR = p_objNewDetailArr[iAcc].m_strLOTNO_VCHR;
                                objAccArr[intRow].m_strMEDICINEID_CHR = p_objNewDetailArr[iAcc].m_strMEDICINEID_CHR;
                                objAccArr[intRow].m_strMEDICINENAME_VCH = p_objNewDetailArr[iAcc].m_strMEDICINENAME_VCH;
                                objAccArr[intRow].m_strMEDICINETYPEID_CHR = p_objNewDetailArr[iAcc].m_strMedicineTypeID_chr;
                                objAccArr[intRow].m_strMEDSPEC_VCHR = p_objNewDetailArr[iAcc].m_strMEDSPEC_VCHR;
                                objAccArr[intRow].m_strOPUNIT_CHR = p_objNewDetailArr[iAcc].m_strOPUNIT_CHR;
                                objAccArr[intRow].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                                objAccArr[intRow].m_dtmOperateDate = dtmNow;
                                objAccArr[intRow].m_dtmValidDate = p_objNewDetailArr[iAcc].m_dtmValidperiod_dat;
                                objAccArr[intRow].m_strTYPECODE_CHR = p_objNewDetailArr[iAcc].m_strTYPECODE_CHR;
                                intRow++;
                            }

                            clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();

                            lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_objMain.m_strOUTSTORAGEID_VCHR, p_objMain.m_strSTORAGEID_CHR);

                            lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                            if(lngRes > 0 && p_blnIsImmAccount)
                            {
                                lngRes = m_lngSetAccountUser(p_objPrincipal, p_objMain.m_strASKERID_CHR, dtmInDate, p_objMain.m_lngSERIESID_INT);
                            }
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
        #region 保存出库记录
        /// <summary>
        /// 保存出库记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewDetailArr">新出库明细</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewDetailArr, bool p_blnIsCommit, bool p_lngIsAddNew,bool p_blnIsImmAccount)
        {
            if (p_objMain == null || p_objNewDetailArr == null || p_objNewDetailArr.Length == 0)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                clsStorageSVC objStSVC = new clsStorageSVC();
                Hashtable hstMedicine = new Hashtable();//涉及到的最终要统计库存的药品

                if (p_objOldDetailArr != null && p_objOldDetailArr.Length > 0)
                {
                    if (p_blnIsCommit)//如果保存后即审核，则先将已有记录退审，保存成功后再重新审核
                    {
                        clsMS_StorageDetail[] objSTDetail = new clsMS_StorageDetail[p_objOldDetailArr.Length];
                        for (int iRow = 0; iRow < p_objOldDetailArr.Length; iRow++)
                        {
                            objSTDetail[iRow] = new clsMS_StorageDetail();
                            objSTDetail[iRow].m_dblAVAILAGROSS_INT = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objSTDetail[iRow].m_dblREALGROSS_INT = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objSTDetail[iRow].m_strMEDICINEID_CHR = p_objOldDetailArr[iRow].m_strMEDICINEID_CHR;
                            if (p_objOldDetailArr[iRow].m_strLOTNO_VCHR == "")
                            {
                                objSTDetail[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                            }
                            else
                            {
                                objSTDetail[iRow].m_strLOTNO_VCHR = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            }
                            //objSTDetail[iRow].m_strLOTNO_VCHR = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            objSTDetail[iRow].m_strINSTORAGEID_VCHR = p_objOldDetailArr[iRow].m_strINSTORAGEID_VCHR;
                            objSTDetail[iRow].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                            objSTDetail[iRow].m_dcmCALLPRICE_INT = p_objOldDetailArr[iRow].m_dcmCALLPRICE_INT;
                            objSTDetail[iRow].m_dtmVALIDPERIOD_DAT = p_objOldDetailArr[iRow].m_dtmValidperiod_dat;

                            if (!hstMedicine.Contains(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR))
                            {
                                hstMedicine.Add(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            }
                        }

                        lngRes = objStSVC.m_lngAddStorageDetailRealGross(p_objPrincipal, objSTDetail);
                    }
                    else
                    {
                        clsMS_StorageGrossForOut[] objGrossDetailArr = new clsMS_StorageGrossForOut[p_objOldDetailArr.Length];

                        for (int iRow = 0; iRow < p_objOldDetailArr.Length; iRow++)
                        {
                            objGrossDetailArr[iRow] = new clsMS_StorageGrossForOut();
                            objGrossDetailArr[iRow].m_strMedicineID = p_objOldDetailArr[iRow].m_strMEDICINEID_CHR;
                            objGrossDetailArr[iRow].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            objGrossDetailArr[iRow].m_strInStorageID = p_objOldDetailArr[iRow].m_strINSTORAGEID_VCHR;
                            if (p_objOldDetailArr[iRow].m_strLOTNO_VCHR == "")
                            {
                                objGrossDetailArr[iRow].m_strLotNO = "UNKNOWN";
                            }
                            else
                            {
                                objGrossDetailArr[iRow].m_strLotNO = p_objOldDetailArr[iRow].m_strLOTNO_VCHR;
                            }
                            objGrossDetailArr[iRow].m_dblGross = p_objOldDetailArr[iRow].m_dblNETAMOUNT_INT;
                            objGrossDetailArr[iRow].m_dblInPrice = Convert.ToDouble(p_objOldDetailArr[iRow].m_dcmCALLPRICE_INT);
                            objGrossDetailArr[iRow].m_dtmValidDate = p_objOldDetailArr[iRow].m_dtmValidperiod_dat;

                            if (!hstMedicine.Contains(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR))
                            {
                                hstMedicine.Add(p_objOldDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                            }
                        }
                        //先将旧有记录中的药品的可用库存回复

                        lngRes = objStSVC.m_lngAddStorageDetailAvailaGross(p_objPrincipal, objGrossDetailArr);
                    }

                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                }

                if (p_lngIsAddNew)
                {
                    lngRes = m_lngAddNewOutStorage(p_objPrincipal, ref p_objMain);
                    if (p_blnIsCommit)
                    {
                        //判断领用部门是否为药房，且已设置为接收部门
                        clsMS_Public_Supported_SVC m_objPublic = new clsMS_Public_Supported_SVC();
                        string m_strDeptIDForStorage = string.Empty;//药库对应的部门ID
                        m_objPublic.m_lngGetDeptIDForStorage(p_objPrincipal, p_objMain.m_strSTORAGEID_CHR, out m_strDeptIDForStorage);
                        bool m_blnReceive = false;
                        m_lngGetReceiveDeptID(p_objPrincipal, m_strDeptIDForStorage, p_objMain.m_strASKDEPT_CHR, out m_blnReceive);
                        if (m_blnReceive)
                        {
                            string m_strSQL = @"select typecode_vchr
	from t_aid_impexptype
 where storgeflag_int <> 0
	 and status_int = 1
	 and flag_int = 0
	 and typename_vchr = '正常入库'";

                            DataTable dtbValue = null;
                            string m_strTypeCode = string.Empty;
                            clsHRPTableService objHRPServ = new clsHRPTableService();
                            lngRes = objHRPServ.lngGetDataTableWithoutParameters(m_strSQL, ref dtbValue);
                            objHRPServ.Dispose();
                            objHRPServ = null;
                            if (dtbValue != null && dtbValue.Rows.Count > 0)
                            {
                                m_strTypeCode = dtbValue.Rows[0]["typecode_vchr"].ToString();
                            }
                            dtbValue = null;
                            if (string.IsNullOrEmpty(m_strTypeCode))
                            {
                                throw new Exception("请在出入库类型设置中添加药房入库类型“正常入库”。");
                            }
                            clsInStorageSVC m_objGetPack = new clsInStorageSVC();
                            DataTable m_dtbPack;
                            clsInstorage_SVC m_objInstorageSvc = new clsInstorage_SVC();
                            clsDS_Instorage_VO m_objMainVo = new clsDS_Instorage_VO();
                            clsDS_Instorage_Detail[] m_objDetailArr = new clsDS_Instorage_Detail[p_objNewDetailArr.Length];

                            m_objMainVo.m_datMAKEORDER_DAT = p_objMain.m_dtmASKDATE_DAT;
                            m_objMainVo.m_datSTORAGEEXAM_DATE = p_objMain.m_dtmEXAMDATE_DAT;
                            m_objMainVo.m_intFORMTYPE_INT = 1;
                            m_objMainVo.m_intSTATUS = 1;
                            m_objMainVo.m_strBORROWDEPT_CHR = p_objMain.m_strEXPORTDEPT_CHR;
                            m_objMainVo.m_strDRUGSTOREID_INT = p_objMain.m_strASKDEPT_CHR;
                            m_objMainVo.m_strMAKERID_CHR = p_objMain.m_strASKERID_CHR;
                            m_objMainVo.m_strOUTSTORAGEID_VCHR = p_objMain.m_strOUTSTORAGEID_VCHR;
                            m_objMainVo.m_strSTORAGEEXAMID_CHR = p_objMain.m_strEXAMERID_CHR;
                            m_objMainVo.m_strTYPECODE_VCHR = m_strTypeCode;
                            for (int iRow = 0; iRow < p_objNewDetailArr.Length; iRow++)
                            {

                                m_objDetailArr[iRow] = new clsDS_Instorage_Detail();
                                //此处包装量取基本表
                                //m_objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_objNewDetailArr[iRow].m_decPackQty);
                                m_objGetPack.m_lngGetPack(p_objPrincipal, p_objNewDetailArr[iRow].m_strMEDICINEID_CHR, out m_dtbPack);
                                if (m_dtbPack != null && m_dtbPack.Rows.Count > 0)
                                {
                                    p_objNewDetailArr[iRow].m_decPackQty = Convert.ToDecimal(m_dtbPack.Rows[0]["packqty_dec"]);
                                }
                                m_objDetailArr[iRow].m_strMEDICINEID_CHR = p_objNewDetailArr[iRow].m_strMEDICINEID_CHR;
                                m_objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_objNewDetailArr[iRow].m_strMEDICINENAME_VCH;
                                m_objDetailArr[iRow].m_strMEDSPEC_VCHR = p_objNewDetailArr[iRow].m_strMEDSPEC_VCHR;
                                m_objDetailArr[iRow].m_dblOPAMOUNT_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT;
                                m_objDetailArr[iRow].m_strOPUNIT_CHR = p_objNewDetailArr[iRow].m_strOPUNIT_CHR;
                                m_objDetailArr[iRow].m_dblIPAMOUNT_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT * Convert.ToDouble(p_objNewDetailArr[iRow].m_decPackQty);
                                m_objDetailArr[iRow].m_strIPUNIT_CHR = p_objNewDetailArr[iRow].m_strIPUnit;
                                m_objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_objNewDetailArr[iRow].m_decPackQty);
                                m_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(p_objNewDetailArr[iRow].m_dcmWHOLESALEPRICE_INT);
                                m_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(((decimal)(p_objNewDetailArr[iRow].m_dcmWHOLESALEPRICE_INT / p_objNewDetailArr[iRow].m_decPackQty)).ToString("f4"));
                                m_objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_objNewDetailArr[iRow].m_dcmRETAILPRICE_INT);
                                m_objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(((decimal)(p_objNewDetailArr[iRow].m_dcmRETAILPRICE_INT / p_objNewDetailArr[iRow].m_decPackQty)).ToString("f4"));
                                m_objDetailArr[iRow].m_strLOTNO_VCHR = p_objNewDetailArr[iRow].m_strLOTNO_VCHR;
                                m_objDetailArr[iRow].m_datVALIDPERIOD_DAT = p_objNewDetailArr[iRow].m_dtmValidperiod_dat;
                                m_objDetailArr[iRow].m_intSTATUS = 1;
                                m_objDetailArr[iRow].m_strINSTOREID_VCHR = p_objNewDetailArr[iRow].m_strINSTORAGEID_VCHR;//药库入库单号
                                m_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = p_objNewDetailArr[iRow].m_dtmINSTORAGEDATE_DAT.Date;//药库入库日期
                            }
                            m_objInstorageSvc.m_lngAddNewInstorage(p_objPrincipal, ref m_objMainVo, ref m_objDetailArr, 1, p_objMain.m_strASKERID_CHR);
                        }
                    }
                }
                else
                {
                    lngRes = m_lngModifyOutStorage(p_objPrincipal, p_objMain);
                    if (lngRes > 0)
                    {
                        lngRes = m_lngUpdateStorageDetailStatusByMainSEQ(p_objPrincipal, -1, p_objMain.m_lngSERIESID_INT);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                if (lngRes > 0)
                {
                    for (int iDel = 0; iDel < p_objNewDetailArr.Length; iDel++)
                    {
                        p_objNewDetailArr[iDel].m_lngSERIESID2_INT = p_objMain.m_lngSERIESID_INT;
                    }
                    lngRes = m_lngAddNewOutStorageDetail(p_objPrincipal,ref p_objNewDetailArr);
                }
                else
                {
                    throw new Exception();
                }

                #region 获取各药品出库前的实际库存

                if (lngRes > 0 && p_blnIsCommit)
                {
                    string strSQL = @"select t.seriesid_int, s.realgross_int
  from t_ms_outstorage_detail t, t_ms_storage_detail s
 where t.seriesid2_int = ?
   and t.status = 1
   and t.medicineid_chr = s.medicineid_chr
   and t.lotno_vchr = s.lotno_vchr
   and t.instorageid_vchr = s.instorageid_vchr
   and s.status = 1
   and s.storageid_chr = ?";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = p_objMain.m_lngSERIESID_INT;
                    objDPArr[1].Value = p_objMain.m_strSTORAGEID_CHR;

                    DataTable dtbSt = null;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbSt, objDPArr);
                    if (lngRes > 0 && dtbSt != null)
                    {
                        DataRow[] drRow = null;
                        for (int iSt = 0; iSt < p_objNewDetailArr.Length; iSt++)
                        {
                            drRow = dtbSt.Select("seriesid_int = " + p_objNewDetailArr[iSt].m_lngSERIESID_INT.ToString());
                            if (drRow != null && drRow.Length > 0)
                            {
                                p_objNewDetailArr[iSt].m_dblRealGross = Convert.ToDouble(drRow[0]["realgross_int"]);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                } 
                #endregion

                if (lngRes > 0)
                {
                    clsMS_StorageDetail[] objNewSTDetail = new clsMS_StorageDetail[p_objNewDetailArr.Length];
                    for (int iRow = 0; iRow < p_objNewDetailArr.Length; iRow++)
                    {
                        objNewSTDetail[iRow] = new clsMS_StorageDetail();
                        objNewSTDetail[iRow].m_dblAVAILAGROSS_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objNewSTDetail[iRow].m_dblREALGROSS_INT = p_objNewDetailArr[iRow].m_dblNETAMOUNT_INT;
                        objNewSTDetail[iRow].m_strMEDICINEID_CHR = p_objNewDetailArr[iRow].m_strMEDICINEID_CHR;
                        objNewSTDetail[iRow].m_strLOTNO_VCHR = p_objNewDetailArr[iRow].m_strLOTNO_VCHR;
                        objNewSTDetail[iRow].m_strINSTORAGEID_VCHR = p_objNewDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        objNewSTDetail[iRow].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                        objNewSTDetail[iRow].m_dcmCALLPRICE_INT = p_objNewDetailArr[iRow].m_dcmCALLPRICE_INT;
                        objNewSTDetail[iRow].m_dtmVALIDPERIOD_DAT = p_objNewDetailArr[iRow].m_dtmValidperiod_dat;

                        if (!hstMedicine.Contains(p_objNewDetailArr[iRow].m_strMEDICINEID_CHR))
                        {
                            hstMedicine.Add(p_objNewDetailArr[iRow].m_strMEDICINEID_CHR, p_objMain.m_strSTORAGEID_CHR);
                        }
                    }

                    if (p_blnIsCommit)//减少库存
                    {
                        lngRes = objStSVC.m_lngSubStorageDetailGross(p_objPrincipal, objNewSTDetail);
                    }
                    else//只减少可用库存

                    {
                        lngRes = objStSVC.m_lngSubStorageDetailAvailaGross(p_objPrincipal, objNewSTDetail);
                    }

                    if (lngRes <= 0)
                    {
                        throw new Exception("出库数据大于可用库存");
                    }

                    if (hstMedicine.Count > 0 && p_blnIsCommit)
                    {
                        clsMS_StorageGrossForOut[] objOutGross = new clsMS_StorageGrossForOut[hstMedicine.Count];

                        int intMed = 0;
                        foreach (string strID in hstMedicine.Keys)
                        {
                            objOutGross[intMed] = new clsMS_StorageGrossForOut();
                            objOutGross[intMed].m_strMedicineID = strID;
                            objOutGross[intMed].m_strStorageID = p_objMain.m_strSTORAGEID_CHR;
                            intMed++;
                        }
                        lngRes = objStSVC.m_lngUpdateStorageCurrentGross(p_objPrincipal, objOutGross);
                        if (lngRes > 0)
                        {
                            if (p_blnIsCommit)
                            {
                                long[] lngSEQ = new long[] { p_objMain.m_lngSERIESID_INT };
                                lngRes = m_lngSetCommitUser(p_objPrincipal, p_objMain.m_strASKERID_CHR, lngSEQ);
                                if (lngRes <= 0)
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

                    if (p_blnIsCommit)
                    {
                        DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[p_objNewDetailArr.Length];
                        int intAccState = p_blnIsImmAccount ? 1 : 2;//入帐明细状态

                        DateTime dtmInDate = p_blnIsImmAccount ?  dtmNow : DateTime.MinValue;//入账日期
                        string strInEmp = p_blnIsImmAccount ? p_objMain.m_strASKERID_CHR : string.Empty;//入账人


                        for (int iAcc = 0; iAcc < p_objNewDetailArr.Length; iAcc++)
                        {
                            objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                            objAccArr[iAcc].m_dblAMOUNT_INT = p_objNewDetailArr[iAcc].m_dblNETAMOUNT_INT;
                            objAccArr[iAcc].m_dblCALLPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmCALLPRICE_INT;
                            objAccArr[iAcc].m_dblOLDGROSS_INT = p_objNewDetailArr[iAcc].m_dblRealGross;
                            objAccArr[iAcc].m_dblRETAILPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmRETAILPRICE_INT;
                            objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = (double)p_objNewDetailArr[iAcc].m_dcmWHOLESALEPRICE_INT;
                            objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                            objAccArr[iAcc].m_intFORMTYPE_INT = p_objMain.m_intFORMTYPE_INT;
                            objAccArr[iAcc].m_intISEND_INT = 0;
                            objAccArr[iAcc].m_intSTATE_INT = intAccState;
                            objAccArr[iAcc].m_intTYPE_INT = 2;
                            objAccArr[iAcc].m_strCHITTYID_VCHR = p_objMain.m_strOUTSTORAGEID_VCHR;
                            objAccArr[iAcc].m_strDEPTID_CHR = p_objMain.m_strASKDEPT_CHR;
                            objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                            objAccArr[iAcc].m_strINSTORAGEID_VCHR = p_objNewDetailArr[iAcc].m_strINSTORAGEID_VCHR;
                            objAccArr[iAcc].m_strLOTNO_VCHR = p_objNewDetailArr[iAcc].m_strLOTNO_VCHR;
                            objAccArr[iAcc].m_strMEDICINEID_CHR = p_objNewDetailArr[iAcc].m_strMEDICINEID_CHR;
                            objAccArr[iAcc].m_strMEDICINENAME_VCH = p_objNewDetailArr[iAcc].m_strMEDICINENAME_VCH;
                            objAccArr[iAcc].m_strMEDICINETYPEID_CHR = p_objNewDetailArr[iAcc].m_strMedicineTypeID_chr;
                            objAccArr[iAcc].m_strMEDSPEC_VCHR = p_objNewDetailArr[iAcc].m_strMEDSPEC_VCHR;
                            objAccArr[iAcc].m_strOPUNIT_CHR = p_objNewDetailArr[iAcc].m_strOPUNIT_CHR;
                            objAccArr[iAcc].m_strSTORAGEID_CHR = p_objMain.m_strSTORAGEID_CHR;
                            objAccArr[iAcc].m_dtmOperateDate = dtmNow;
                            objAccArr[iAcc].m_dtmValidDate = p_objNewDetailArr[iAcc].m_dtmValidperiod_dat;
                            objAccArr[iAcc].m_strTYPECODE_CHR = p_objNewDetailArr[iAcc].m_strTYPECODE_CHR;
                        }

                        clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();

                        lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_objMain.m_strOUTSTORAGEID_VCHR, p_objMain.m_strSTORAGEID_CHR);

                        lngRes = objAcSVC.m_lngAddNewAccountDetail(p_objPrincipal, objAccArr);

                        if (lngRes > 0 && p_blnIsImmAccount)
                        {
                            lngRes = m_lngSetAccountUser(p_objPrincipal, p_objMain.m_strASKERID_CHR, dtmInDate, p_objMain.m_lngSERIESID_INT);
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

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChittyIDArr">出库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与出库单据号一一对应)</param>
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

        #region 删除指定出库药品
        /// <summary>
        /// 删除指定出库药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeq">药品序列</param>
        /// <param name="p_strOutStorageID">出库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStroageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_objStMed">库存药品信息</param>
        /// <param name="p_dblOutGross">此药品出库数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSelectedMedicine(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeq, string p_strOutStorageID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed, double p_dblOutGross)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_lngUpdateStorageDetailStatus(p_objPrincipal, 0, p_lngSeq);
                if (lngRes <= 0)
                {
                    throw new Exception();
                }

                clsStorageSVC objStSVC = new clsStorageSVC();

                lngRes = objStSVC.m_lngAddStorageDetailAvailaGross(p_objPrincipal, p_dblOutGross, p_strMedicineID, p_strLotNO, p_strInStroageID,p_dtmValidDate,p_dblInPrice, p_strStorageID);
                if (lngRes > 0 && p_blnIsCommit)
                {
                    if (p_objStMed == null)
                    {
                        throw new Exception();
                    }

                    long lngSubSEQ = 0;
                    double p_dblRealgross = 0d;
                    double p_dblAvailagross = 0d;
                    lngRes = objStSVC.m_lngGetDetailSEQByIndex(p_objPrincipal, p_strInStroageID, p_strMedicineID, p_strLotNO, p_dtmValidDate,p_dblInPrice, p_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                    if (lngSubSEQ > 0)
                    {
                        p_objStMed.m_dblINSTOREGROSS_INT = 0;
                        p_objStMed.m_dblCURRENTGROSS_NUM = p_dblOutGross;
                        lngRes = objStSVC.m_lngAddStorageDetailGross(p_objPrincipal, p_dblOutGross, 0, lngSubSEQ);//删除时不再增加可用库存，以免重复添加
                        if (lngRes <= 0)
                        {
                            throw new Exception();
                        }
                    }

                    lngRes = objStSVC.m_lngAddStorageGross(p_objPrincipal, p_objStMed);
                    if (lngRes <= 0)
                    {
                        throw new Exception();
                    }
                    objStSVC = null;
                    p_objStMed = null;

                    clsMS_AccountSVC objAcSVC = new clsMS_AccountSVC();
                    lngRes = objAcSVC.m_lngSetAccountDetailInvalid(p_objPrincipal, p_strOutStorageID, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID, p_dtmValidDate, p_dblInPrice);
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

        /// <summary>
        /// 获取药品可用库存数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicinID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_decMedicineAmount">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAmount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicinID, string p_strStorageID, out double p_decMedicineAmount)
        {
            p_decMedicineAmount = 0d;
            string strSQL ;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select sum(availagross_int)
  from t_ms_storage_detail a left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where storageid_chr = ?
   and b.assistcode_chr = ?
   and status = 1";
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strMedicinID;
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
                                p_decMedicineAmount += dblGrossTemp;
                            }
                        }
                    }
                    else
                    {
                        p_decMedicineAmount = -1;
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
        /// 获取可用库存数量大于0的药品

        /// </summary>
        /// <param name="p_objPrincipal"></param>        
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_alMedicineArr">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineAmountNotZero(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out ArrayList p_alMedicineArr)
        {
            p_alMedicineArr = new ArrayList();
            string strSQL;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select b.assistcode_chr
  from t_ms_storage_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
 where storageid_chr = ?
   and status = 1
   having sum(a.availagross_int) > 0
   group by b.assistcode_chr
   order by b.assistcode_chr";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {                        
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            p_alMedicineArr.Add(dtbValue.Rows[iRow][0]);
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
        /// 获取主表开单时间

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOrderID">出库单号</param>
        /// <param name="dtAskDate">开单时间</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetBillDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOrderID,out DateTime dtAskDate)
        {
            dtAskDate = DateTime.Now;
            string strSQL;
            long lngRes = 0;

            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                strSQL = @"select a.askdate_dat from t_ms_outstorage a
  where a.outstorageid_vchr = ?";
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strOrderID;
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (dtbValue != null)
                {
                    if(dtbValue.Rows.Count> 0)
                    {
                        dtAskDate = Convert.ToDateTime(dtbValue.Rows[0][0].ToString());
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

        #region 审核出库单的时候新增药房入库单
        /// <summary>
        /// 审核出库单的时候新增药房入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">主表</param>
        /// <param name="p_objSub">子表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewDrugStore(System.Security.Principal.IPrincipal p_objPrincipal,clsMS_OutStorage_VO p_objMain,clsMS_OutStorageDetail_VO[] p_objSub)
        {
            long lngRes = 0;

            //判断领用部门是否为药房，且已设置为接收部门
                clsMS_Public_Supported_SVC m_objPublic = new clsMS_Public_Supported_SVC();
                string m_strDeptIDForStorage = string.Empty;//药库对应的部门ID
                m_objPublic.m_lngGetDeptIDForStorage(p_objPrincipal, p_objMain.m_strSTORAGEID_CHR, out m_strDeptIDForStorage);
                bool m_blnReceive = false;
                m_lngGetReceiveDeptID(p_objPrincipal, m_strDeptIDForStorage, p_objMain.m_strASKDEPT_CHR, out m_blnReceive);
                if (m_blnReceive)
                {
                    string m_strSQL = @"select typecode_vchr
from t_aid_impexptype
where storgeflag_int <> 0
and status_int = 1
and flag_int = 0
and typename_vchr = '正常入库'";
                    //clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtbValue = null;
                    string m_strTypeCode = string.Empty;
                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(m_strSQL, ref dtbValue);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    if (dtbValue != null && dtbValue.Rows.Count > 0)
                    {
                        m_strTypeCode = dtbValue.Rows[0]["typecode_vchr"].ToString();
                    }
                    dtbValue = null;
                    if (string.IsNullOrEmpty(m_strTypeCode))
                    {
                        throw new Exception("请在出入库类型设置中添加药房入库类型“正常入库”。");
                    }


                    clsInStorageSVC m_objGetPack = new clsInStorageSVC();
                    DataTable m_dtbPack;
                    clsInstorage_SVC m_objInstorageSvc = new clsInstorage_SVC();
                    clsDS_Instorage_VO m_objMainVo = new clsDS_Instorage_VO();
                    clsDS_Instorage_Detail[] m_objDetailArr = new clsDS_Instorage_Detail[p_objSub.Length];
                    m_objMainVo.m_datMAKEORDER_DAT = p_objMain.m_dtmASKDATE_DAT;
                    m_objMainVo.m_datSTORAGEEXAM_DATE = p_objMain.m_dtmEXAMDATE_DAT;
                    m_objMainVo.m_intFORMTYPE_INT = 6;
                    m_objMainVo.m_intSTATUS = 1;
                    m_objMainVo.m_strBORROWDEPT_CHR = m_strDeptIDForStorage;// p_objMain.m_strEXPORTDEPT_CHR;
                    m_objMainVo.m_strDRUGSTOREID_INT = p_objMain.m_strASKDEPT_CHR;
                    m_objMainVo.m_strMAKERID_CHR = p_objMain.m_strASKERID_CHR;
                    m_objMainVo.m_strOUTSTORAGEID_VCHR = p_objMain.m_strOUTSTORAGEID_VCHR;
                    m_objMainVo.m_strSTORAGEEXAMID_CHR = p_objMain.m_strEXAMERID_CHR;
                    m_objMainVo.m_strTYPECODE_VCHR = m_strTypeCode;
                    for (int iRow = 0; iRow < p_objSub.Length; iRow++)
                    {

                        m_objDetailArr[iRow] = new clsDS_Instorage_Detail();

                        //此处包装量取基本表
                        //m_objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_objSub[iRow].m_decPackQty);
                        m_objGetPack.m_lngGetPack(p_objPrincipal, p_objSub[iRow].m_strMEDICINEID_CHR, out m_dtbPack);
                        if (m_dtbPack != null && m_dtbPack.Rows.Count > 0)
                        {
                            p_objSub[iRow].m_decPackQty = Convert.ToDecimal(m_dtbPack.Rows[0]["packqty_dec"]);
                        }

                        m_objDetailArr[iRow].m_strMEDICINEID_CHR = p_objSub[iRow].m_strMEDICINEID_CHR;
                        m_objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_objSub[iRow].m_strMEDICINENAME_VCH;
                        m_objDetailArr[iRow].m_strMEDSPEC_VCHR = p_objSub[iRow].m_strMEDSPEC_VCHR;
                        m_objDetailArr[iRow].m_dblOPAMOUNT_INT = p_objSub[iRow].m_dblNETAMOUNT_INT;
                        m_objDetailArr[iRow].m_strOPUNIT_CHR = p_objSub[iRow].m_strOPUNIT_CHR;
                        m_objDetailArr[iRow].m_dblIPAMOUNT_INT = p_objSub[iRow].m_dblNETAMOUNT_INT * Convert.ToDouble(p_objSub[iRow].m_decPackQty);
                        m_objDetailArr[iRow].m_strIPUNIT_CHR = p_objSub[iRow].m_strIPUnit;
                        m_objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_objSub[iRow].m_decPackQty);
                        m_objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(p_objSub[iRow].m_dcmWHOLESALEPRICE_INT);
                        m_objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(((decimal)(p_objSub[iRow].m_dcmWHOLESALEPRICE_INT / p_objSub[iRow].m_decPackQty)).ToString("f4"));
                        m_objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_objSub[iRow].m_dcmRETAILPRICE_INT);
                        m_objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(((decimal)(p_objSub[iRow].m_dcmRETAILPRICE_INT / p_objSub[iRow].m_decPackQty)).ToString("f4"));
                        m_objDetailArr[iRow].m_strLOTNO_VCHR = p_objSub[iRow].m_strLOTNO_VCHR;
                        m_objDetailArr[iRow].m_datVALIDPERIOD_DAT = p_objSub[iRow].m_dtmValidperiod_dat;
                        m_objDetailArr[iRow].m_intSTATUS = 1;
                        m_objDetailArr[iRow].m_strINSTOREID_VCHR = p_objSub[iRow].m_strINSTORAGEID_VCHR;//药库入库单号
                        m_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = p_objSub[iRow].m_dtmINSTORAGEDATE_DAT.Date;//药库入库日期
                    }
                    lngRes = m_objInstorageSvc.m_lngAddNewInstorage(p_objPrincipal, ref m_objMainVo, ref m_objDetailArr, 0, p_objMain.m_strASKERID_CHR);
                }
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 申请单位是否接收入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeptIDForStorage"></param>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnReceive"></param>
        /// <returns></returns>
        private long m_lngGetReceiveDeptID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeptIDForStorage, string p_strDrugStoreID, out bool p_blnReceive)
        {
            long lngRes = 0;
            p_blnReceive = false;
            DataTable dtbResult = new DataTable();
            string strSQL = @"select a.instoragedept_chr
	from t_aid_outindeptrelation a
 where a.outstoragedept_chr = ?
	 and a.instoragedept_chr = ?
	 and exists (select b.deptid_chr
					from t_bse_medstore b
				 where b.deptid_chr = ?)";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParaArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objParaArr);
                objParaArr[0].Value = p_strDeptIDForStorage;
                objParaArr[1].Value = p_strDrugStoreID;
                objParaArr[2].Value = p_strDrugStoreID;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParaArr);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_blnReceive = true;
                }
                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <param name="dtbMain"></param>
        public void m_mthGetOutStorage(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID, out DataTable dtbMain)
        {
            dtbMain = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select distinct a.seriesid_int,
       a.storageid_chr,
       a.outstorageid_vchr,
       a.outstoragetype_int,
       a.formtype,
       a.exportdept_chr,
       a.askdept_chr,
       a.status,
       a.askdate_dat,
       a.examdate_dat,
       a.inaccountdate_dat,
       a.askerid_chr,
       a.examerid_chr,
       a.inaccountid_chr,
       a.askid_vchr,
       a.parentnid,
       a.comment_vchr,
       a.receiptorid_chr,
       a.outstoragedate_dat,
       z.lastname_vchr receiptorname,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
         when 3 then
          '即入即出'
         else
          ''
       end outstoragetypedesc,
       case a.status
         when 0 then
          '作废'
         when 1 then
          '新制'
         when 2 then
          '审核'
         when 3 then
          '入帐'
       end statusdesc
  from t_ms_outstorage a
 inner join t_bse_employee b on a.askerid_chr = b.empid_chr
 left outer join t_bse_employee c on a.examerid_chr = c.empid_chr
 left outer join t_bse_employee z on a.receiptorid_chr = z.empid_chr
 left outer join t_bse_deptdesc d on a.askdept_chr = d.deptid_chr
 inner join (select e.seriesid2_int,
                    e.medicineid_chr,
                    e.medicinename_vch,
                    f.assistcode_chr
               from t_ms_outstorage_detail e, t_bse_medicine f
              where e.medicineid_chr = f.medicineid_chr and e.status = 1) g on g.seriesid2_int =
                                                              a.seriesid_int
 where a.seriesid_int = ?   
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeriesID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, objDPArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 检查该出库单是否已开药房入库单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSeriesID">主表序列</param>
        public bool m_mthHaveAddedIntoDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSeriesID)
        {
            DataTable dtbMain = null;
            try
            {
                string strSQL = @"select a.outstorageid_vchr 
                from t_ds_instorage a
                left join t_ms_outstorage b 
                on b.outstorageid_vchr = a.outstorageid_vchr
                where b.seriesid_int = ?
                and a.status > 0 ";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSeriesID;

                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbMain, objDPArr);
                if (dtbMain != null && dtbMain.Rows.Count > 0)
                    return true;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                return false;
            }
            return false;
        }


        #region 获取单据类型
        /// <summary>
        /// 获取单据类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intBillTypeID">单据类型ID</param>
        /// <param name="p_strBillTypeName">单据类型名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBillTypeName(System.Security.Principal.IPrincipal p_objPrincipal, int p_intBillTypeID, out string p_strBillTypeName)
        {
            p_strBillTypeName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @" select distinct t.typecode_vchr, t.typename_vchr
  from t_aid_impExptype t
 where t.typecode_vchr = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_intBillTypeID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);

                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strBillTypeName = dtbValue.Rows[0]["typename_vchr"].ToString();
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

        #region 获取子表内容(广医三院报表打印)
        /// <summary>
        /// 获取子表内容 (广医三院报表打印)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailReportForGY3Y(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            p_dtbValue = null;
            long lngRes = 0;

            try
            {
                string strSQL = @"select rownum,
			 a.medicinename_vch,
			 a.medspec_vchr,
			 a.opunit_chr,
			 a.netamount_int,
			 case
				 when a.lotno_vchr = 'UNKNOWN' then
					''
				 else
					a.lotno_vchr
			 end lotno_vchr,
			 a.retailprice_int,
			 b.assistcode_chr,
			 b.productorid_chr,
			 a.validperiod_dat
	from t_ms_outstorage_detail a
	left join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
	left join t_ms_outstorage c on c.seriesid_int = a.seriesid2_int
	left join t_ms_storage d on d.storageid_chr = c.storageid_chr
													and d.medicineid_chr = a.medicineid_chr
 where a.seriesid2_int = ?
	 and a.status = 1
 order by d.storagerackid_chr, b.assistcode_chr";


                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngMainSEQ;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbValue, objDPArr);

                objHRPServ.Dispose();

                if (p_dtbValue.Rows.Count > 0)
                {
                    int iCount = p_dtbValue.Rows.Count;
                    for (int iR = 0; iR < iCount; iR++)
                    {
                        p_dtbValue.Rows[iR]["rownum"] = iR + 1;
                        if (Convert.ToDateTime(p_dtbValue.Rows[iR]["validperiod_dat"]).ToString("yyyy-MM-dd").Trim() == "0001-01-01")
                        {
                            p_dtbValue.Rows[iR]["validperiod_dat"] = DBNull.Value;
                        }
                    }
                    p_dtbValue.AcceptChanges();
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

        #region 杨镇伟添加,修改出库主表单据状态
        /// <summary>
        /// 修改出库主表单据状态
        /// </summary>
        /// <param name="p_strPattern">修改模式：0-接根据主表ID修改,1-根据子表ID修改</param>
        /// <param name="p_strStatus">状态</param>
        /// <param name="p_strSeriesId">单据ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdStorageStatus(string p_strPattern, string p_strStatus, long p_lngSeriesId)
        {
            long lngRes = 0;
            long lngRecord = 0;
            string strSQL = null;
            if (p_strPattern == "0")
            {
                strSQL = "update t_ms_outstorage a set a.status = ? where a.seriesid_int = ?";
            }
            else
            {
                strSQL = @"update t_ms_outstorage a
                       set a.status = ?
                     where a.seriesid_int = (select a1.seriesid2_int
                              from t_ms_outstorage_detail a1
                             where a1.seriesid_int = ?)";
            }
            try
            {
                clsHRPTableService clsHrpSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                clsHrpSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStatus;
                objDPArr[1].Value = p_lngSeriesId;

                lngRes = clsHrpSvc.lngExecuteParameterSQL(strSQL, ref lngRecord, objDPArr);

                clsHrpSvc.Dispose();
                clsHrpSvc = null;
            }
            catch (Exception objex)
            {
                com.digitalwave.Utility.clsLogText clsError = new com.digitalwave.Utility.clsLogText();
                bool blnRes = clsError.LogError(objex.ToString());
            }
            return lngRes;
        }
        #endregion
    }
}
