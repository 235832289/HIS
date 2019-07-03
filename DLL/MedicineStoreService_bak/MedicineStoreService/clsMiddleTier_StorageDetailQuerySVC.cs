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

    #region  药库明细查询中间件  王勇 2007-4-2

    /// <summary>
    /// 药库明细查询
    /// </summary>

    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsMiddleTier_StorageDetailQuerySVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsMiddleTier_StorageDetailQuerySVC()
        {

        }

        #region 获取<<药品信息说明>>数据
        /// <summary>
        /// 表：T_BSE_MEDICINE 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]

        public long m_lngGetMedicineBseData(System.Security.Principal.IPrincipal p_objPrincipal, out clsValue_MedicineBse_VO[] p_objData)
        {
            p_objData = new clsValue_MedicineBse_VO[0];
            long lngRes = 0;
            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC", "m_lngGetMedicineBseData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select
                                medicineid_chr,
                                medicinename_vchr,
                                assistcode_chr,
                                medspec_vchr,
                                medicinestdid_chr,
                                medicinepreptype_chr,
                                productorid_chr
                              from t_bse_medicine
                              order by medicineid_chr asc";


            DataTable dtbResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    p_objData = new clsValue_MedicineBse_VO[dtbResult.Rows.Count];

                    DataRow m_drDataRow = null;
                    clsValue_MedicineBse_VO tmp_p_objData = null;

                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        tmp_p_objData = new clsValue_MedicineBse_VO();
                        m_drDataRow = dtbResult.Rows[i1];

                        tmp_p_objData.m_strMedicineStdID = m_drDataRow["medicinestdid_chr"].ToString();
                        tmp_p_objData.m_strAssistCode = m_drDataRow["assistcode_chr"].ToString();
                        tmp_p_objData.m_strMedicineID = m_drDataRow["medicineid_chr"].ToString();
                        tmp_p_objData.m_strMedicineName = m_drDataRow["medicinename_vchr"].ToString();
                        tmp_p_objData.m_strProductorID = m_drDataRow["productorid_chr"].ToString();
                        tmp_p_objData.m_strMedSpec = m_drDataRow["medspec_vchr"].ToString();
                        tmp_p_objData.m_strMedicinePrepType = m_drDataRow["medicinepreptype_chr"].ToString();
                        p_objData[i1] = tmp_p_objData;

                        //p_objData[i1].m_strMedicineStdID = dtbResult.Rows[i1]["medicinestdid_chr"].ToString();
                        //p_objData[i1].m_strAssistCode = dtbResult.Rows[i1]["assistcode_chr"].ToString();
                        //p_objData[i1].m_strMedicineID = dtbResult.Rows[i1]["medicineid_chr"].ToString();
                        //p_objData[i1].m_strMedicineName = dtbResult.Rows[i1]["medicinename_vchr"].ToString();
                        //p_objData[i1].m_strProductorID = dtbResult.Rows[i1]["productorid_chr"].ToString();
                        //p_objData[i1].m_strMedSpec = dtbResult.Rows[i1]["medspec_vchr"].ToString();
                        //p_objData[i1].m_strMedicinePrepType = dtbResult.Rows[i1]["medicinepreptype_chr"].ToString();
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


        #region 获取<<库存明细表>>明细数据
        /// <summary>
        /// 表：T_MS_STORAGE_DETAIL
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnAccount">是否结帐</param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageDetailData(System.Security.Principal.IPrincipal p_objPrincipal, bool p_blnAccount,ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param,List<string> p_lstMedicineType, ref DataTable dtbResult)
        {
            long lngRes = 0;
            string strAccountId = "";

            if(!p_blnAccount)
            m_lngGetMaxAccountId(null, out strAccountId);

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC", "m_lngGetStorageDetailData");
            if (lngRes < 0)
            {
                dtbResult = null;
                return -1;
            }

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            StringBuilder strSQL = new StringBuilder(@"select b.canprovide,b.storagerackid_chr,b.medicineid_chr,
       c.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       case
         when b.lotno_vchr = 'UNKNOWN' then
          ''
         else
          b.lotno_vchr
       end lotno_vchr,
       d.medicinetypename_vchr,
       realgross_int,
       availagross_int,
       b.opunit_vchr,       
       b.callprice_int,
       b.retailprice_int,
       b.wholesaleprice_int,
       b.validperiod_dat,
       e.medicinepreptypename_vchr,   
       b.productorid_chr,
       v.vendorname_vchr,
       f.endamount_int
	from t_ms_storage_detail b
 inner join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr

	left join t_bse_storage h on h.storageid_chr = b.storageid_chr
 inner join t_aid_medicinetype d on c.medicinetypeid_chr =
																		d.medicinetypeid_chr
	left outer join t_aid_medicinepreptype e on c.medicinepreptype_chr =
																							e.medicinepreptype_chr
	left outer join t_bse_vendor v on b.vendorid_chr = v.vendorid_chr
	left outer join t_ms_account_detail f on b.medicineid_chr =
																					 f.medicineid_chr
																			 and f.accountid_chr like ?
																			 and f.lotno_vchr = b.lotno_vchr
																			 and b.instorageid_vchr =
																					 f.instorageid_vchr
																			 and b.callprice_int =
																					 f.callprice_int
																			 and b.validperiod_dat =
																					 f.validperiod_dat
																			 and f.isend_int = 1
																			 and f.state_int > 0
																			 and f.storageid_chr =
																					 b.storageid_chr
	left join t_ms_storagerackset g on g.storagerackid_chr =
																		 b.storagerackid_chr");

            //g.storagerackname_vchr,
            try
            {
                int m_intParamCount = 1;

                StringBuilder m_strbCondition = new StringBuilder("");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(13 + p_lstMedicineType.Count, out tmp_objDPArr);
                tmp_objDPArr[0].Value = strAccountId +"%";
                strSQL.Append(@" where (b.storageid_chr = ?)");
                tmp_objDPArr[1].Value = objvalue_Param.m_strStorageID;
                ++m_intParamCount;
                if (objvalue_Param.m_strValidBeginDate.Trim().Length == 10)
                {
                    strSQL.Append(@" and (b.validperiod_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strValidBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                if (objvalue_Param.m_strValidEndDate.Trim().Length == 10)
                {
                    strSQL.Append(@" and  (b.validperiod_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strValidEndDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }


                if (objvalue_Param.m_strMedicineID.Trim().Length > 0)
                {
                    strSQL.Append(@" and (b.medicineid_chr = ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = objvalue_Param.m_strMedicineID;
                }
                else
                {
                    if (objvalue_Param.m_strAssistCode.Length > 0)
                    {
                        strSQL.Append(@" and ((b.medicineid_chr like ?)
                                       or (c.assistcode_chr like ?) 
                                       or (b.medicinename_vchr like ?)
                                       or (c.pycode_chr like ?) 
                                       or (c.wbcode_chr like ?))");
                        for (int i1 = 0; i1 < 5; i1++)
                        {
                            tmp_objDPArr[m_intParamCount + i1].Value = objvalue_Param.m_strAssistCode;
                        }
                        m_intParamCount = m_intParamCount + 5;
                    }
                }

                if (p_lstMedicineType.Count > 0)
                {
                    strSQL.Append(@" and ((c.medicinetypeid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[0].ToString();

                    for (int i1 = 1; i1 < p_lstMedicineType.Count; i1++)
                    {
                        strSQL.Append(@" or (c.medicinetypeid_chr=?)");
                        ++m_intParamCount;
                        tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[i1].ToString();
                    }
                    strSQL.Append(@")");
                }

                if (objvalue_Param.m_blnZeroGross == false)
                {
                    strSQL.Append(@" and (b.realgross_int<>?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = 0;

                }

                strSQL.Append(@" and (b.status=?)");
                ++m_intParamCount;
                tmp_objDPArr[m_intParamCount - 1].Value = 1;


                //strSQL.Append(@" ORDER BY B.MEDICINEID_CHR ASC");
                strSQL.Append(@" order by  c.assistcode_chr asc");
               

                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);
                
                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }

                
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);

                //合拼药品　只分药品ID和批号，不管入库单据号
                double intRealGross = 0;
                double intAvailaGross = 0;
                double intEndamount = 0;
                double intTemA;
                double intTemR;
                double intTemE;
             
                DataTable dtbTemp = dtbResult.Clone();
                for (int intRow = 0; intRow < dtbResult.Rows.Count; intRow++)
                {
                    DataRow dtrTemp = dtbResult.Rows[intRow];
                    if (dtbResult.Rows[intRow]["Endamount_int"] == DBNull.Value)
                    {
                        dtbResult.Rows[intRow]["Endamount_int"] = 0;
                    }
                    if ((intRow + 1 >= dtbResult.Rows.Count) || (dtbResult.Rows[intRow]["assistcode_chr"].ToString() != dtbResult.Rows[intRow + 1]["assistcode_chr"].ToString()
                        || dtbResult.Rows[intRow]["lotno_vchr"].ToString() != dtbResult.Rows[intRow + 1]["lotno_vchr"].ToString()
                        || Convert.ToDouble(dtbResult.Rows[intRow]["callprice_int"]) != Convert.ToDouble(dtbResult.Rows[intRow + 1]["callprice_int"])
                        || Convert.ToDouble(dtbResult.Rows[intRow]["retailprice_int"]) != Convert.ToDouble(dtbResult.Rows[intRow + 1]["retailprice_int"])))
                    {
                        if (intRealGross > 0)
                        {

                            intTemR = Convert.ToDouble(dtbResult.Rows[intRow]["realgross_int"]);
                            intTemA = Convert.ToDouble(dtbResult.Rows[intRow]["availagross_int"]);
                            intTemE = Convert.ToDouble(dtbResult.Rows[intRow]["Endamount_int"]);
                            dtrTemp["realgross_int"] = intTemR + intRealGross;
                            dtrTemp["availagross_int"] = intTemA + intAvailaGross;
                            dtrTemp["Endamount_int"] = intTemE + intEndamount;
                        }
                        dtbTemp.Rows.Add(dtrTemp.ItemArray);
                        intRealGross = 0;
                        intAvailaGross = 0;
                        intEndamount = 0;
                    }
                    else
                    {
                        intRealGross += Convert.ToDouble(dtrTemp["realgross_int"]);
                        intAvailaGross += Convert.ToDouble(dtrTemp["availagross_int"]);
                        intEndamount += Convert.ToDouble(dtrTemp["Endamount_int"]); 
                    }
                }
                dtbResult = dtbTemp;
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                dtbResult = null;
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region 获取<<药品类型大类>>数据
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
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC", "m_lngGetStorageDetailData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select 
                                b.medicineroomid, 
                                a.medicinetypeid_chr, 
                                a.medicinetypename_vchr,
                                c.medicinetypesetid,
                                c.medicinetypesetname
                             from t_aid_medicinetype a
                                inner join t_ms_medicinestoreroomset b 
                                    on a.medicinetypeid_chr = b.medicinetypeid_chr
                                inner join t_ms_medicinetypeset c
                                    on a.medicinetypeid_chr = c.medicinetypeid_chr
                            order by c.medicinetypesetid asc";

//            string strSQL = @"select 
//                                b.medicineroomid,
//                                a.medicinetypeid_chr,
//                                a.medicinetypename_vchr from t_aid_medicinetype a
//                              inner join t_ms_medicinestoreroomset b
//                                 on a.medicinetypeid_chr=b.medicinetypeid_chr
//                              order by a.medicinetypeid_chr asc";

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
                        tmp_p_objData.m_strMedicineTypesetID = m_drDataRow["MedicineTypesetID"].ToString();
                        tmp_p_objData.m_strMedicineTypesetName = m_drDataRow["MedicineTypesetName"].ToString();

                        //p_objData[i1].m_strMedicineRoomID = dtbResult.Rows[i1]["medicineroomid"].ToString();
                        //p_objData[i1].m_strMedicineTypeID = dtbResult.Rows[i1]["medicinetypeid_chr"].ToString();
                        //p_objData[i1].m_strMedicineTypeName = dtbResult.Rows[i1]["medicinetypename_vchr"].ToString();

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


        #region 获取<<仓库信息说明>>数据
        /// <summary>
        /// 表：T_BSE_STORAGE 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageBseData(System.Security.Principal.IPrincipal p_objPrincipal, out clsValue_StorageBse_VO[] p_objData)
        {
            p_objData = new clsValue_StorageBse_VO[0];
            long lngRes = 0;
            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC", "m_lngGetStorageBseData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select distinct  medicineroomid,medicineroomname from t_ms_medicinestoreroomset order by medicineroomid";

            DataTable dtbResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    p_objData = new clsValue_StorageBse_VO[dtbResult.Rows.Count];
                    DataRow m_drDataRow = null;
                    clsValue_StorageBse_VO tmp_p_objData = null;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        tmp_p_objData = new clsValue_StorageBse_VO();
                        m_drDataRow = dtbResult.Rows[i1];

                        tmp_p_objData.MEDICINEROOMID = m_drDataRow["medicineroomid"].ToString();
                        tmp_p_objData.MEDICINEROOMNAME = m_drDataRow["medicineroomname"].ToString();

                        p_objData[i1] = tmp_p_objData;

                        //p_objData[i1].MEDICINEROOMID = dtbResult.Rows[i1]["medicineroomid"].ToString();
                        ////p_objData[i1].MEDICINETYPEID_CHR = dtbResult.Rows[i1]["MEDICINETYPEID_CHR"].ToString();
                        //p_objData[i1].MEDICINEROOMNAME = dtbResult.Rows[i1]["medicineroomname"].ToString();

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

   
        #region 获取最后一次帐务期ID

        /// <summary>
        /// 获取最后一次帐务期ID

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbVendor"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMaxAccountId(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strAccountId)
        {
            p_strAccountId = "";
            DataTable p_dtbVendor = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select max(a.accountid) accountid from t_ms_account a";

                clsHRPTableService objHRPServ = new clsHRPTableService();

                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbVendor);
                if (p_dtbVendor != null)
                {
                    p_strAccountId = p_dtbVendor.Rows[0]["accountid"].ToString();
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

        #region 获取货架数据
        /// <summary>
        /// 获取货架数据 
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_strStoreName">药库名称</param>
        /// <param name="m_dtbStorageRack">货架</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageRack(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreName, out DataTable m_dtbStorageRack)
        {
            m_dtbStorageRack = new DataTable();
            m_dtbStorageRack.Columns.Add("storagerackid_chr");
            m_dtbStorageRack.Columns.Add("storagerackname_vchr");
            long lngRes = 0;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC", "m_lngGetStorageRack");
            if (lngRes < 0)
                return -1;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select a.storagerackid_chr, a.storagerackname_vchr
	from t_ms_storagerackset a
			left join t_bse_storage b on b.storageid_chr = a.storageid_chr											
 where b.storagename_vchr = ? and a.typeid_int = 1
 order by a.storagerackid_chr";

            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStoreName;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbStorageRack, objDPArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新药房药品货架
        /// <summary>
        /// 更新药房药品货架
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dicStorageRack">货架</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveStorageRack(System.Security.Principal.IPrincipal p_objPrincipal, Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail a set a.storagerackid_chr = ?
                                    where a.medicineid_chr = ? and a.lotno_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                object[][] objValues = new object[3][];

                int intItemCount = p_dicStorageRack.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }

                int iRow = 0;
                foreach (KeyValuePair<string, string> kvp in p_dicStorageRack)
                {
                    objValues[0][iRow] = kvp.Value;
                    objValues[1][iRow] = kvp.Key.Substring(0, 10);
                    objValues[2][iRow] = kvp.Key.Substring(10);
                    iRow++;
                }

                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion 

        #region 更新可供标志
        /// <summary>
        /// 更新可供标志
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_dicStorageProvide">可供标志</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveStorageProvide(System.Security.Principal.IPrincipal p_objPrincipal, Dictionary<string, string> p_dicStorageProvide)
        {
            long lngRes = 0;
            try
            {
                string strSQL = @"update t_ms_storage_detail a set a.canprovide = ?
                                    where a.medicineid_chr = ? and a.lotno_vchr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                DbType[] dbTypes = new DbType[] { DbType.String, DbType.String, DbType.String };

                object[][] objValues = new object[3][];

                int intItemCount = p_dicStorageProvide.Count;
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[intItemCount];//初始化
                }

                int iRow = 0;
                foreach (KeyValuePair<string, string> kvp in p_dicStorageProvide)
                {
                    objValues[0][iRow] = kvp.Value;
                    objValues[1][iRow] = kvp.Key.Substring(0, 10);
                    objValues[2][iRow] = kvp.Key.Substring(10);
                    iRow++;
                }

                lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
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

    #endregion
}
