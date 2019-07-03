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
    /// 报废出库中间件
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRejectOutStorageSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 添加作废原因
        /// <summary>
        /// 添加作废原因
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objReason">作废原因</param>
        /// <param name="p_intReasonID">作废原因ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewRejectReason(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_RejectReason p_objReason, out int p_intReasonID)
        {
            p_intReasonID = 1;
            if (p_objReason == null)
            {
                return -1;
            }
            long lngRes = 0;

            try
            {
                int intReasonID = 0;
                clsHRPTableService objHRPServ = new clsHRPTableService();

                string strGetMaxID = @"select max(reasonid_int) from t_ms_rejectreasonset";
                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strGetMaxID, ref dtbValue);
                if (dtbValue == null || dtbValue.Rows.Count == 0)
                {
                    intReasonID = 1;
                }
                else if (dtbValue.Rows.Count == 1)
                {
                    int intMax = 0;
                    if (!int.TryParse(dtbValue.Rows[0][0].ToString(), out intMax))
                    {
                        intReasonID = 1;
                    }
                    else
                    {
                        intReasonID = intMax + 1;
                    }
                }
                p_intReasonID = intReasonID;

                string strSQL = @"insert into t_ms_rejectreasonset
  (reasonid_int, reasondesc_vchr, sortnum_int)
values
  (?, ?, ?)";

                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = intReasonID;
                objDPArr[1].Value = p_objReason.m_strREASONDESC_VCHR;
                objDPArr[2].Value = p_objReason.m_intSORTNUM_INT;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                p_objReason = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 修改作废原因
        /// <summary>
        /// 修改作废原因
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyRejectReason(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_RejectReason p_objReason)
        {
            if (p_objReason == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"update t_ms_rejectreasonset set reasondesc_vchr = ? where reasonid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_objReason.m_strREASONDESC_VCHR;
                objDPArr[1].Value = p_objReason.m_intREASONID_INT;

                long lngEff = -1;
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                p_objReason = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion

        #region 删除选定作废原因
        /// <summary>
        /// 删除选定作废原因
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngReasonID">作废原因ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteRejectReason(System.Security.Principal.IPrincipal p_objPrincipal, long[] p_lngReasonID)
        {
            if (p_lngReasonID == null || p_lngReasonID.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"delete from t_ms_rejectreasonset where reasonid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iID = 0; iID < p_lngReasonID.Length; iID++)
                    {
                        objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                        objDPArr[0].Value = p_lngReasonID[iID];

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32 };

                    object[][] objValues = new object[1][];

                    int intItemCount = p_lngReasonID.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_lngReasonID[iRow];
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

        #region 更新作废原因顺序
        /// <summary>
        /// 更新作废原因顺序
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateReasonSort(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_RejectReason[] p_objReason)
        {
            if (p_objReason == null || p_objReason.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_rejectreasonset set sortnum_int = ? where reasonid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                long lngEff = -1;
                if (clsHRPTableService.bytDatabase_Selector != (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    IDataParameter[] objDPArr = null;
                    for (int iID = 0; iID < p_objReason.Length; iID++)
                    {
                        objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_objReason[iID].m_intSORTNUM_INT;
                        objDPArr[1].Value = p_objReason[iID].m_intREASONID_INT;

                        lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                    }
                }
                else
                {
                    DbType[] dbTypes = new DbType[] { DbType.Int32,DbType.Int32 };

                    object[][] objValues = new object[2][];

                    int intItemCount = p_objReason.Length;
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[intItemCount];//初始化

                    }

                    for (int iRow = 0; iRow < intItemCount; iRow++)
                    {
                        objValues[0][iRow] = p_objReason[iRow].m_intSORTNUM_INT;
                        objValues[1][iRow] = p_objReason[iRow].m_intREASONID_INT;
                    }

                    lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
                }

                p_objReason = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取所有作废原因
        /// <summary>
        /// 获取所有作废原因
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objReason">作废原因</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllRejectReason(System.Security.Principal.IPrincipal p_objPrincipal, out clsMS_RejectReason[] p_objReason)
        {
            p_objReason = null;

            long lngRes = 0;
            try
            {
                string strSQL = @"select reasonid_int, reasondesc_vchr, sortnum_int from t_ms_rejectreasonset order by sortnum_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DataTable dtbValue = null;

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref dtbValue);
                if (lngRes > 0 && dtbValue != null)
                {
                    int intRowsCount = dtbValue.Rows.Count;
                    if (intRowsCount > 0)
                    {
                        p_objReason = new clsMS_RejectReason[intRowsCount];
                        DataRow drTemp = null;
                        for (int iRow = 0; iRow < intRowsCount; iRow++)
                        {
                            drTemp = dtbValue.Rows[iRow];
                            p_objReason[iRow] = new clsMS_RejectReason();
                            p_objReason[iRow].m_intREASONID_INT = Convert.ToInt32(drTemp["reasonid_int"]);
                            p_objReason[iRow].m_intSORTNUM_INT = Convert.ToInt32(drTemp["sortnum_int"]);
                            p_objReason[iRow].m_strREASONDESC_VCHR = drTemp["reasondesc_vchr"].ToString();
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

        #region 获取出库主表
        /// <summary>
        /// 获取出库主表(报废出库)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMain(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strOutID, int p_intFormType, out DataTable p_dtbOutStorage)
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
       a.outstoragedate_dat,
       b.lastname_vchr askername,
       c.lastname_vchr examername,
       d.deptname_vchr askdeptname,
       case a.outstoragetype_int
         when 1 then
          '领药出库'
         when 2 then
          '销售出库'
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
   and a.outstorageid_vchr like ?
   and a.status <> 0
   and a.formtype = ?
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[1].Value = p_dtmBegin;
                objDPArr[2].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[3].Value = p_strOutID + "%";
                objDPArr[4].Value = p_intFormType;

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

        #region 获取报废药品信息（打印）
        /// <summary>
        /// 获取报废药品信息（打印）
        /// </summary>
        [AutoComplete]
        public long m_lngGetRejectPrint(System.Security.Principal.IPrincipal p_objPrincipal, long lngSeriesid, out DataTable p_dtbOutStorage)
        {
            p_dtbOutStorage = null;
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
       j.opunit_vchr storageunit
  from t_ms_outstorage_detail a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_ms_outstorage d on a.seriesid2_int = d.seriesid_int
  left outer join t_ms_ask c on d.askid_vchr = c.askid_vchr
                            and a.medicineid_chr = c.medicineid_chr
  left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
 inner join t_ms_storage_detail j on j.storageid_chr = d.storageid_chr
                                 and j.medicineid_chr = a.medicineid_chr
                                 and a.lotno_vchr = j.lotno_vchr
                                 and a.instorageid_vchr =
                                     j.instorageid_vchr
                                 and a.validperiod_dat = j.validperiod_dat
                                 and a.callprice_int = j.callprice_int
                                 and j.status = 1
 where a.seriesid2_int = :1
   and a.status = 1
 order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = lngSeriesid;
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

    }
}
