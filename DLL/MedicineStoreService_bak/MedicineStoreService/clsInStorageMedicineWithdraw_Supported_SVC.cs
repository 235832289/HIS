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
    /// 药品内退中间件
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsMiddletier_InStorageMedicineWithdraw_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取<<药剂类型>>数据
        /// <summary>
        /// 表：t_aid_medicinepreptype 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicinePrepTypeData(System.Security.Principal.IPrincipal p_objPrincipal, out clsMS_MedicinePrepType_VO[] p_objData)
        {
            p_objData = new clsMS_MedicinePrepType_VO[0];
            long lngRes = 0;
            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicinePrepTypeData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select 
                                medicinepreptype_chr,
                                medicinepreptypename_vchr,
                                flaga_int
                              from t_aid_medicinepreptype";


            DataTable dtbResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    p_objData = new clsMS_MedicinePrepType_VO[dtbResult.Rows.Count];
                    DataRow m_drDataRow = null;
                    clsMS_MedicinePrepType_VO tmp_p_objData = null;

                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        tmp_p_objData = new clsMS_MedicinePrepType_VO();
                        m_drDataRow = dtbResult.Rows[i1];

                        tmp_p_objData.m_strMedicinePrepTypeID = m_drDataRow["medicinepreptype_chr"].ToString();
                        tmp_p_objData.m_strMedicinePrepName = m_drDataRow["medicinepreptypename_vchr"].ToString();
                        tmp_p_objData.m_strTypeFlag = m_drDataRow["flaga_int"].ToString();

                        p_objData[i1] = tmp_p_objData;

                    }//for
                    m_drDataRow = null;
                }
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取<<药品类型>>数据
        /// <summary>
        /// 表：t_aid_medicinetype 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineTypeData(System.Security.Principal.IPrincipal p_objPrincipal, out clsValue_MedicineType_VO[] p_objData)
        {
            p_objData = new clsValue_MedicineType_VO[0];
            long lngRes = 0;
            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineTypeData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select 
                                b.medicineroomid,
                                a.medicinetypeid_chr,
                                a.medicinetypename_vchr from t_aid_medicinetype a
                              inner join t_ms_medicinestoreroomset b
                                 on a.medicinetypeid_chr=b.medicinetypeid_chr
                              order by a.medicinetypeid_chr asc";

            DataTable dtbResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    p_objData = new clsValue_MedicineType_VO[dtbResult.Rows.Count];
                    DataRow m_drDataRow = null;
                    clsValue_MedicineType_VO tmp_p_objData = null;

                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        tmp_p_objData = new clsValue_MedicineType_VO();
                        m_drDataRow = dtbResult.Rows[i1];

                        tmp_p_objData.m_strMedicineRoomID = m_drDataRow["medicineroomid"].ToString();
                        tmp_p_objData.m_strMedicineTypeID = m_drDataRow["medicinetypeid_chr"].ToString();
                        tmp_p_objData.m_strMedicineTypeName = m_drDataRow["medicinetypename_vchr"].ToString();


                        p_objData[i1] = tmp_p_objData;

                    }//for
                    m_drDataRow = null;
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取仓库名

        /// <summary>
        /// 获取仓库名
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreRoomName(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            p_strStoreRoomName = string.Empty;

            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct t.medicineroomid, t.medicineroomname
                                       from t_ms_medicinestoreroomset t
                                         where t.medicineroomid = ?";

                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStoreRoomID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_strStoreRoomName = dtbValue.Rows[0]["medicineroomname"].ToString();
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

        #region 获取药品内退主表数据
        /// <summary>
        /// 表：T_MS_INSTORAGE（入库主表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInnerWithdrawData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_InMedicineWithdrawQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineInnerWithdrawData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            StringBuilder strSQL = new StringBuilder(@"select distinct a.seriesid_int,
       a.state_int,
       a.storageid_chr,
       a.instorageid_vchr,
       a.returndept_chr,
       a.commnet_vchr,
       a.examerid_chr,
       a.makerid_chr,
       a.vendorid_chr,
       a.instoragedate_dat,
       a.neworder_dat,
       a.exam_dat,
       a.storagerid_char,
       a.accounterid_char,
       d.deptname_vchr,
       b.lastname_vchr,
       c.vendorname_vchr
  from t_ms_instorage a
  inner join t_ms_instorage_detal e on a.seriesid_int = e.seriesid2_int and e.status = 1
  left outer join t_bse_medicine f on e.medicineid_chr = f.medicineid_chr
  left outer join t_bse_deptdesc d on a.returndept_chr = d.deptid_chr
  left outer join t_bse_employee b on a.makerid_chr = b.empid_chr
  left outer join t_bse_vendor c on a.vendorid_chr = c.vendorid_chr");



            try 
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(14, out tmp_objDPArr);

                if (objvalue_Param.m_strQueryBeginDate.Length > 0)
                {
                    strSQL.Append(@" where (a.neworder_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strQueryBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                }


                if (objvalue_Param.m_strQueryEndDate.Length > 0)
                {
                    strSQL.Append(@" and (a.neworder_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strQueryEndDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                }


                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }

                if (objvalue_Param.m_strMedicineID.Trim().Length > 0)
                {
                    strSQL.Append(@" and (e.medicineid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMedicineID;
                }

                if (objvalue_Param.m_strVendorID.Length > 0)
                {
                    strSQL.Append(@" and (a.vendorid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strVendorID;
                }



                if (objvalue_Param.m_strInStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.instorageid_vchr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strInStorageID;
                }

                strSQL.Append(@" and (a.formtype_int=?)");
                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intFormType;


                if (objvalue_Param.m_intState > 0)
                {
                    strSQL.Append(@" and (a.state_int=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intState;
                }
                else if (objvalue_Param.m_intState == -1)//全部
                {
                    strSQL.Append(@" and (a.state_int <>?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = 0;
                }

                if (objvalue_Param.m_strMakeBillPeopleID.Length > 0)
                {
                    strSQL.Append(@" and (a.makerid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMakeBillPeopleID;
                }

                if (objvalue_Param.m_strReturnDeptID.Length > 0)
                {
                    strSQL.Append(@" and (a.returndept_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strReturnDeptID;
                }

                if (objvalue_Param.m_strMedicineTypeID.Length > 0)
                {
                    strSQL.Append(@" and (f.medicinetypeid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMedicineTypeID;
                }


                strSQL.Append(@" order by  a.instorageid_vchr");

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;
                objvalue_Param = null;
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
                string strSQL = @"select a.seriesid_int,
       case
         when b.packamount > 0 then
          b.packamount * b.packcallprice_int
         else
          b.amount * b.callprice_int
       end buyinmoney,
       b.amount * b.wholesaleprice_int wholesalemoney,
       b.amount * b.retailprice_int retailmoney
  from t_ms_instorage a, t_ms_instorage_detal b
 where a.seriesid_int = b.seriesid2_int
   and a.neworder_dat between ? and ?
   and a.storageid_chr = ?
   and a.formtype_int = ?
   and b.status = 1
   and a.state_int <> 0";
             
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

        #region 获取药品内退明细数据
        /// <summary>
        /// 表：T_MS_INSTORAGE（入库主表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineInnerWithdrawDetailData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawDetailQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineInnerWithdrawData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //问题：少一个字段：ComputeBillSum单据金额
            StringBuilder strSQL = new StringBuilder(@"select distinct b.seriesid_int,
                b.seriesid2_int,
                b.medicineid_chr,
                b.medicinename_vch,
                b.medspec_vchr,
                case
                  when b.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   b.lotno_vchr
                end lotno_vchr,
                b.amount,
                b.unit_vchr,
                b.callprice_int,
                b.wholesaleprice_int,
                b.retailprice_int,
                b.instorageid_vchr,
                b.outstorageid_vchr,
                b.validperiod_dat,
                b.ruturnnum_int,
                b.productorid_chr,
                b.status,
                d.netamount_int,
                e.vendorid_chr,
                e.vendorname_vchr,
                f.assistcode_chr,
                f.medicinetypeid_chr,
                g.realgross_int
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
 inner join t_bse_medicine f on b.medicineid_chr = f.medicineid_chr
  left outer join t_ms_outstorage c on b.outstorageid_vchr =
                                       c.outstorageid_vchr
                                   and c.status > 1
  inner join t_ms_outstorage_detail d on c.seriesid_int =
                                              d.seriesid2_int
                                          and d.status = 1
                                          and d.medicineid_chr =
                                              b.medicineid_chr
                                          and d.lotno_vchr = b.lotno_vchr
                                          and b.instorageid_vchr =
                                              d.instorageid_vchr
                                          and b.validperiod_dat =
                                              d.validperiod_dat
                                          and b.callprice_int =
                                              d.callprice_int
  left outer join t_bse_vendor e on d.vendorid_chr = e.vendorid_chr
  left outer join t_ms_storage_detail g on b.medicineid_chr =
                                           g.medicineid_chr
                                       and b.lotno_vchr = g.lotno_vchr
                                       and b.instorageid_vchr =
                                           g.instorageid_vchr
                                       and g.status = 1
                                       and b.validperiod_dat =
                                           g.validperiod_dat
                                       and b.callprice_int =
                                           g.callprice_int");

            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(4, out tmp_objDPArr);

                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" where (a.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }


                if (objvalue_Param.m_intSERIESID2_INT > 0)
                {
                    strSQL.Append(@" and (a.seriesid_int=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intSERIESID2_INT;
                }

                if (objvalue_Param.m_intStatus > 0)
                {
                    strSQL.Append(@" and (b.status=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intStatus;
                }

                strSQL.Append(@" order by b.seriesid_int asc");

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;

            }

            return lngRes;
        }

        #endregion

        #region 审核时获取药品内退明细数据
        /// <summary>
        /// 表：T_MS_INSTORAGE（入库主表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWithdrawDetailData(System.Security.Principal.IPrincipal p_objPrincipal, long lngSEQ, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetWithdrawDetailData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //问题：少一个字段：ComputeBillSum单据金额
            StringBuilder strSQL = new StringBuilder(@"select a.seriesid_int,
       a.seriesid2_int,
       a.medicineid_chr,
       a.medicinename_vch,
       a.medspec_vchr,
       a.lotno_vchr,
       a.amount,
       a.unit_vchr,
       a.callprice_int,
       a.wholesaleprice_int,
       a.retailprice_int,
       a.instorageid_vchr,
       a.outstorageid_vchr,
       a.validperiod_dat,
       a.ruturnnum_int,
       a.productorid_chr,
       b.medicinetypeid_chr,
       c.realgross_int
  from t_ms_instorage_detal a
 inner join t_ms_instorage d on a.seriesid2_int = d.seriesid_int
                            and d.state_int <> 0
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
  left outer join t_ms_storage_detail c on a.medicineid_chr =
                                           c.medicineid_chr
                                       and a.lotno_vchr = c.lotno_vchr
                                       and a.instorageid_vchr =
                                           c.instorageid_vchr
                                       and a.validperiod_dat =
                                           c.validperiod_dat
                                       and a.callprice_int =
                                           c.callprice_int
                                       and c.status = 1
                                       and d.storageid_chr =
                                           c.storageid_chr");

            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(2, out tmp_objDPArr);

                strSQL.Append(@" where (a.status= ?)");
                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = 1;


                strSQL.Append(@" and (a.seriesid2_int=?)");
                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = lngSEQ;



                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;

            }

            return lngRes;
        }

        #endregion

        #region 获取药品出库主表数据
        /// <summary>
        /// 表：T_MS_OUTSTORAGE（出库主表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageMainData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetOutStorageMainData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //问题：
            StringBuilder strSQL = new StringBuilder(@"select distinct
                                a.seriesid_int,
                                a.outstorageid_vchr,
                                a.exportdept_chr,
                                c.deptname_vchr,
                                a.outstoragedate_dat,
                                a.askerid_chr,
                                a.askdate_dat
                              from t_ms_outstorage a
                              left outer join t_ms_outstorage_detail b
                               on a.seriesid_int=b.seriesid2_int
                              left outer join t_bse_deptdesc c
                               on a.askdept_chr=c.deptid_chr");

            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(14, out tmp_objDPArr);

                if (objvalue_Param.m_strQueryBeginDate.Length > 0)
                {
                    strSQL.Append(@" where (a.outstoragedate_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strQueryBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                }


                if (objvalue_Param.m_strQueryEndDate.Length > 0)
                {
                    strSQL.Append(@" and (a.outstoragedate_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strQueryEndDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

                }

                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }


                if (objvalue_Param.m_strOutStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.outstorageid_vchr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strOutStorageID;
                }


                if (objvalue_Param.m_intOutStorageType > 0)
                {
                    strSQL.Append(@" and (a.outstoragetype_int=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intOutStorageType;
                }

                if (objvalue_Param.m_intFormType > 0)
                {
                    strSQL.Append(@" and (a.formtype=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intFormType;
                }

                if (objvalue_Param.m_intStatus > 0)
                {
                    strSQL.Append(@" and (a.status>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intStatus;
                }


                if (objvalue_Param.m_strMedicineID.Length > 0)
                {
                    strSQL.Append(@" and (b.medicineid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMedicineID;
                }


                if (objvalue_Param.m_strLotNo.Length > 0)
                {
                    strSQL.Append(@" and (b.lotno_vchr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strLotNo;
                }


                if (objvalue_Param.m_strASKDEPT_CHR.Trim().Length > 0)
                {
                    strSQL.Append(@" and (a.askdept_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strASKDEPT_CHR;
                }

                strSQL.Append(@" order by a.outstorageid_vchr asc");

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;
                objvalue_Param = null;
            }

            return lngRes;
        }

        #endregion

        #region 获取出库明细表数据

        /// <summary>
        /// 表：T_MS_OUTSTORAGE_DETAIL（出库明细表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_intSn"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_OutStorageDetailQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetOutStorageDetailData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            StringBuilder strSQL = new StringBuilder(@"select a.outstorageid_vchr,
       a.storageid_chr,
       b.seriesid_int,
       b.medicineid_chr,
       b.medspec_vchr,
       case
         when b.lotno_vchr = 'UNKNOWN' then
          ''
         else
          b.lotno_vchr
       end lotno_vchr,
       b.netamount_int,
       b.opunit_chr,
       b.callprice_int,
       b.wholesaleprice_int,
       b.retailprice_int oldretailprice,
       b.vendorid_chr,
       d.vendorname_vchr,
       b.instorageid_vchr,
       e.realgross_int,
       e.validperiod_dat,
       e.retailprice_int,
       c.medicinetypeid_chr,
       c.productorid_chr,
       c.assistcode_chr,
       c.medicinename_vchr
  from t_ms_outstorage a
 inner join t_ms_outstorage_detail b on a.seriesid_int = b.seriesid2_int
                                    and a.status > 0
                                    and b.status = 1
 left join t_ms_storage_detail e on b.medicineid_chr = e.medicineid_chr
                                 and b.lotno_vchr = e.lotno_vchr
                                 and b.instorageid_vchr =
                                     e.instorageid_vchr
                                 and e.status = 1
                                 and e.storageid_chr = a.storageid_chr
                                 and b.validperiod_dat = e.validperiod_dat
                                 and b.callprice_int = e.callprice_int
 inner join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr
  left outer join t_bse_vendor d on b.vendorid_chr = d.vendorid_chr");


            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(5, out tmp_objDPArr);

                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" where (a.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }


                if (objvalue_Param.m_intSERIESID2_INT > 0)
                {
                    strSQL.Append(@" and (b.seriesid2_int=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intSERIESID2_INT;
                }

                //if (objvalue_Param.m_intStatus > 0)
                //{
                //    strSQL.Append(@" and (b.status=?)");
                //    ++m_intParamCount;
                //    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intStatus;
                //}


                strSQL.Append(@" order by b.seriesid_int asc");

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;

            }

            return lngRes;
        }

        #endregion

        #region 制单时获取出库明细表数据

        /// <summary>
        /// 表：T_MS_OUTSTORAGE_DETAIL（出库明细表） 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_intSn"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutStorageDetailData_MadkerBill(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            IDataParameter[] objDPArr = null;
            IDataParameter[] tmp_objDPArr = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetOutStorageDetailData_MadkerBill");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            StringBuilder strSQL = new StringBuilder(@"select a.outstorageid_vchr,
       b.medicineid_chr,
       c.assistcode_chr,
       c.medicinename_vchr,
       c.medicinetypeid_chr,
       a.storageid_chr,
       a.askdept_chr,
       b.seriesid_int,
       b.medspec_vchr,
       case
         when b.lotno_vchr = 'UNKNOWN' then
          ''
         else
          b.lotno_vchr
       end lotno_vchr,
       b.netamount_int,
       b.opunit_chr,
       e.callprice_int,
       e.wholesaleprice_int,
       e.retailprice_int,
       b.vendorid_chr,
       d.vendorname_vchr,
       c.productorid_chr,
       b.instorageid_vchr,
       e.realgross_int,
       e.validperiod_dat
  from t_ms_outstorage a
 inner join t_ms_outstorage_detail b on a.seriesid_int = b.seriesid2_int
                                    and a.status > 0
                                    and b.status = 1
 left join t_ms_storage_detail e on b.medicineid_chr = e.medicineid_chr
                                 and b.lotno_vchr = e.lotno_vchr
                                 and b.instorageid_vchr =
                                     e.instorageid_vchr
                                 and e.status = 1
                                 and e.callprice_int = b.callprice_int
                                 and e.validperiod_dat = b.validperiod_dat
                                 and e.storageid_chr = a.storageid_chr
 inner join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr
  left outer join t_bse_vendor d on b.vendorid_chr = d.vendorid_chr");


            try
            {
                int m_intParamCount = 0;
                StringBuilder m_strbCondition = new StringBuilder("");

                objHRPSvc.CreateDatabaseParameter(6, out tmp_objDPArr);

                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" where (a.storageid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;
                }


                if (objvalue_Param.m_strOutStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.outstorageid_vchr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strOutStorageID;
                }


                if (objvalue_Param.m_strASKDEPT_CHR.Trim().Length > 0)
                {
                    strSQL.Append(@" and (a.askdept_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strASKDEPT_CHR;
                }

                if (objvalue_Param.m_strMedicineID.Trim().Length > 0)
                {
                    strSQL.Append(@" and (b.medicineid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMedicineID;
                }

                if (objvalue_Param.m_strLotNo.Trim().Length > 0)
                {
                    strSQL.Append(@" and (b.lotno_vchr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strLotNo;
                }

                //if (objvalue_Param.m_intStatus > 0)
                //{
                //    strSQL.Append(@" and (b.status=?)");
                //    ++m_intParamCount;
                //    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_intStatus;
                //}


                strSQL.Append(@" order by b.seriesid_int asc");

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
                tmp_objDPArr = null;

            }

            return lngRes;
        }

        #endregion

        #region 获取已退药数量
        /// <summary>
        /// 查询入库单获取同一种出库单一种药品的退药数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="m_objMedicineWithdrawNum">退药数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineWithdrawSum(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineWithdrawSum");
            if (lngRes < 0)
                return -1;

            try
            {
                StringBuilder strSQL = new StringBuilder(@"select distinct a.instorageid_vchr,
                b.outstorageid_vchr,
                b.medicineid_chr,
                case
                  when b.lotno_vchr = 'UNKNOWN' then
                   ''
                  else
                   b.lotno_vchr
                end lotno_vchr,
                b.amount,
                b.instorageid_vchr withdrawinid
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
                                  and a.formtype_int = 2
                                  and a.state_int > 0
                                  and b.status = 1
  left outer join t_ms_outstorage c on b.outstorageid_vchr =
                                       c.outstorageid_vchr
  left outer join t_ms_outstorage_detail d on c.seriesid_int =
                                              d.seriesid2_int
                                          and b.medicineid_chr =
                                              d.medicineid_chr
                                          and b.callprice_int =
                                              d.callprice_int
                                          and b.validperiod_dat =
                                              d.validperiod_dat
                                          and b.lotno_vchr = d.lotno_vchr
                                          and c.status > 0
                                          and d.status = 1");



                int m_intParamCount = 0;
                DataTable dtbValue = null;
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(5, out tmp_objDPArr);


                if (objvalue_Param.m_strStorageID.Length > 0)
                {
                    strSQL.Append(@" where (a.storageid_chr = ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strStorageID;

                }

                if (objvalue_Param.m_strOutStorageID.Length > 0)
                {
                    strSQL.Append(@" and (b.outstorageid_vchr = ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strOutStorageID;

                }

                if (objvalue_Param.m_strInStorageID.Length > 0)
                {
                    strSQL.Append(@" and (a.instorageid_vchr <> ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strInStorageID;
                }


                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }


                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);
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

        #region 获取当前库存
        /// <summary>
        /// 获取当前库存(已废弃不用)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="m_objMedicineWithdrawNum">退药数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineRealGross(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;


            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineRealGross");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objDPArr = null;
            try
            {
                string strSQL = @"select realgross_int,validperiod_dat
                                       from t_ms_storage_detail
                                         where (storageid_chr = ?) 
                                           and (medicineid_chr = ?)
                                           and (lotno_vchr = ?)";



                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = objvalue_Param.m_strStorageID;
                objDPArr[1].Value = objvalue_Param.m_strMedicineID;
                objDPArr[2].Value = objvalue_Param.m_strLotNo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
            }

            return lngRes;
        }
        #endregion

        #region 退审时获取当前库存、实际库存、可用库存
        /// <summary>
        /// 退审时获取当前库存、实际库存、可用库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineGross(System.Security.Principal.IPrincipal p_objPrincipal, ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;


            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC", "m_lngGetMedicineGross");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objDPArr = null;
            try
            {
                string strSQL = @"select b.medicineid_chr,
       case
         when b.lotno_vchr = 'UNKNOWN' then
          ''
         else
          b.lotno_vchr
       end lotno_vchr,
       c.currentgross_num,
       d.realgross_int,
       d.availagross_int,
       d.instorageid_vchr
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
                                  and a.state_int > 0
                                  and b.status = 1
 inner join t_ms_storage c on b.medicineid_chr = c.medicineid_chr
  left outer join t_ms_storage_detail d on b.medicineid_chr =
                                           d.medicineid_chr
                                       and b.lotno_vchr = d.lotno_vchr
                                       and b.instorageid_vchr =
                                           d.instorageid_vchr
                                       and a.storageid_chr =
                                           d.storageid_chr
                                       and d.callprice_int =
                                           b.callprice_int
                                       and d.validperiod_dat =
                                           b.validperiod_dat
                                       and d.status = 1
 where (a.storageid_chr = ?)
   and (a.instorageid_vchr = ?)
 order by b.seriesid_int asc
";

                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = objvalue_Param.m_strStorageID;
                objDPArr[1].Value = objvalue_Param.m_strInStorageID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

            }//try
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            finally
            {
                objHRPSvc.Dispose();
                objDPArr = null;
            }

            return lngRes;
        }
        #endregion

        #region 审核药品内退

        #endregion        

        #region 获取内退明细（报表打印）
        /// <summary>
        /// 获取内退明细（报表打印）.
        /// </summary>
        [AutoComplete]
        public long m_lngGetOutStorageDetailData_report(string strId,out DataTable dtb)
        {
            dtb = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select b.medicineid_chr,f.assistcode_chr,
b.medicinename_vch,
b.medspec_vchr,
b.unit_vchr,
b.amount,
b.wholesaleprice_int,
b.retailprice_int,
b.lotno_vchr
  from t_ms_instorage a
 inner join t_ms_instorage_detal b on a.seriesid_int = b.seriesid2_int
  left outer join t_bse_medicine f on b.medicineid_chr = f.medicineid_chr
 where a.instorageid_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = strId;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtb, objDPArr);
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

        #region 获取指定药品内退数量
        /// <summary>
        /// 获取指定药品内退数量
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="p_dblAmount">内退数量</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWinthdrawAmount(System.Security.Principal.IPrincipal p_objPrincipal, long p_lngSEQ, out double p_dblAmount)
        {
            p_dblAmount = 0d;
            long lngRes = 0;
            try
            {
                string strSQL = @"select amount from t_ms_instorage_detal where seriesid_int = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_lngSEQ;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count == 1)
                {
                    p_dblAmount = Convert.ToDouble(dtbValue.Rows[0][0]);
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
