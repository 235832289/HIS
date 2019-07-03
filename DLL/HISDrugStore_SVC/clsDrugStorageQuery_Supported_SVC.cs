using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房库存查询类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsDrugStorageQuery_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取仓库数据
        /// <summary>
        /// 获取仓库数据 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageBseData(System.Security.Principal.IPrincipal p_objPrincipal, out clsValue_StorageBse_VO[] p_objData)
        {
            p_objData = new clsValue_StorageBse_VO[0];
            long lngRes = 0;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC", "m_lngGetStorageBseData");
            if (lngRes < 0)
                return -1;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select distinct medstoreid_chr,medstorename_vchr from t_bse_medstore order by medstoreid_chr";

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

                        tmp_p_objData.MEDICINEROOMID = m_drDataRow["medstoreid_chr"].ToString();
                        tmp_p_objData.MEDICINEROOMNAME = m_drDataRow["medstorename_vchr"].ToString();

                        p_objData[i1] = tmp_p_objData;
                    }
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

        #region 获取药品类型数据
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
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC", "m_lngGetMedicineTypeData");
            if (lngRes < 0)
                return -1;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select medicinetypeid_chr,medicinetypename_vchr from t_aid_medicinetype order by medicinetypeid_chr asc";

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
                        tmp_p_objData.m_strMedicineTypeID = m_drDataRow["medicinetypeid_chr"].ToString();
                        tmp_p_objData.m_strMedicineTypeName = m_drDataRow["medicinetypename_vchr"].ToString();

                        p_objData[i1] = tmp_p_objData;

                    }
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

        #region 获取药房库存明细数据
        /// <summary>
        /// 表：T_MS_STORAGE_DETAIL
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <param name="p_strProductor">生产厂家</param>
        /// <param name="p_strPrepType">剂型</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageDetailData(System.Security.Principal.IPrincipal p_objPrincipal, ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, List<string> p_lstMedicineType, ref DataTable dtbResult, string p_strProductor, clsMEDICINEPREPTYPE_VO[] p_objPrepTypeArr)
        {
            long lngRes = 0;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC", "m_lngGetStorageDetailData");
            if (lngRes < 0)
            {
                dtbResult = null;
                return -1;
            }
            bool m_blnIsHospital = false;
            m_lngCheckIsHospital(p_objPrincipal, objvalue_Param.m_strStorageID, out m_blnIsHospital);
            StringBuilder strSQL = new StringBuilder();
            if (m_blnIsHospital)
            {
                strSQL.Append(@"select b.medicineid_chr,
			 c.assistcode_chr,
			 c.medicinename_vchr,
			 b.medspec_vchr,
			 case
				 when b.lotno_vchr = 'UNKNOWN' then
					''
				 else
					b.lotno_vchr
			 end lotno_vchr,
			 d.medicinetypename_vchr,
			 decode(c.ipchargeflg_int,
              0,
              round(b.iprealgross_int / b.packqty_dec, 2),
              b.iprealgross_int) realgross_int,
       decode(c.ipchargeflg_int,
              0,
              round(b.ipavailablegross_num / b.packqty_dec, 2),
              b.ipavailablegross_num) availagross_int,
       b.opunit_chr,
       decode(c.ipchargeflg_int,
              0,
              b.opretailprice_int,
              round(b.opretailprice_int / b.packqty_dec, 4)) retailprice_int,
       decode(c.ipchargeflg_int,
              0,
              b.opwholesaleprice_int,
              round(b.opwholesaleprice_int / b.packqty_dec, 4)) wholesaleprice_int,
			 b.validperiod_dat,
			 e.medicinepreptypename_vchr,
			 c.productorid_chr,
			 b.storagerackid_chr,
			 f.storagerackname_vchr,
             b.canprovide_int,
			 b.oprealgross_int,
			 b.opavailablegross_num opavailagross_int,
			 b.opretailprice_int,
			 b.opwholesaleprice_int,
			 b.iprealgross_int,
			 b.ipavailablegross_num ipavailagross_int,
			 b.ipunit_chr,
			 b.ipretailprice_int,
			 b.ipwholesaleprice_int,
			 decode(c.ipchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit_chr,
			 b.packqty_dec,
			 h.ifstop_int,
			 h.noqtyflag_int,
			 c.pycode_chr,
			 c.wbcode_chr,
			 b.seriesid_int,c.opchargeflg_int,c.ipchargeflg_int
	from t_ds_storage_detail b
 left join t_ds_storage h on b.medicineid_chr = h.medicineid_chr
													and b.drugstoreid_chr = h.drugstoreid_chr
 left join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr
 left join t_aid_medicinetype d on c.medicinetypeid_chr =
																		d.medicinetypeid_chr
	left outer join t_aid_medicinepreptype e on c.medicinepreptype_chr =
																							e.medicinepreptype_chr
	left join t_ms_storagerackset f on f.storagerackid_chr =
																		 b.storagerackid_chr
	left join t_bse_medstore g on g.deptid_chr = b.drugstoreid_chr");
            }
            else
            {
                strSQL.Append(@"select b.medicineid_chr,
			 c.assistcode_chr,
			 c.medicinename_vchr,
			 b.medspec_vchr,
			 case
				 when b.lotno_vchr = 'UNKNOWN' then
					''
				 else
					b.lotno_vchr
			 end lotno_vchr,
			 d.medicinetypename_vchr,
			 decode(c.opchargeflg_int,
              0,
              round(b.iprealgross_int / b.packqty_dec, 2),
              b.iprealgross_int) realgross_int,
       decode(c.opchargeflg_int,
              0,
              round(b.ipavailablegross_num / b.packqty_dec, 2),
              b.ipavailablegross_num) availagross_int,
       b.opunit_chr,
       decode(c.opchargeflg_int,
              0,
              b.opretailprice_int,
              round(b.opretailprice_int / b.packqty_dec, 4)) retailprice_int,
       decode(c.opchargeflg_int,
              0,
              b.opwholesaleprice_int,
              round(b.opwholesaleprice_int / b.packqty_dec, 4)) wholesaleprice_int,
			 b.validperiod_dat,
			 e.medicinepreptypename_vchr,
			 c.productorid_chr,
			 b.storagerackid_chr,
			 f.storagerackname_vchr,
             b.canprovide_int,
			 b.oprealgross_int,
			 b.opavailablegross_num opavailagross_int,
			 b.opretailprice_int,
			 b.opwholesaleprice_int,
			 b.iprealgross_int,
			 b.ipavailablegross_num ipavailagross_int,
			 b.ipunit_chr,
			 b.ipretailprice_int,
			 b.ipwholesaleprice_int,
			 decode(c.opchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit_chr,
			 b.packqty_dec,
			 h.ifstop_int,
			 h.noqtyflag_int,
			 c.pycode_chr,
			 c.wbcode_chr,
			 b.seriesid_int,c.opchargeflg_int,c.ipchargeflg_int
	from t_ds_storage_detail b
 left join t_ds_storage h on b.medicineid_chr = h.medicineid_chr
													and b.drugstoreid_chr = h.drugstoreid_chr
 left join t_bse_medicine c on b.medicineid_chr = c.medicineid_chr
 left join t_aid_medicinetype d on c.medicinetypeid_chr =
																		d.medicinetypeid_chr
	left outer join t_aid_medicinepreptype e on c.medicinepreptype_chr =
																							e.medicinepreptype_chr
	left join t_ms_storagerackset f on f.storagerackid_chr =
																		 b.storagerackid_chr
	left join t_bse_medstore g on g.deptid_chr = b.drugstoreid_chr");
            }

            try
            {
                int m_intParamCount = 1;

                StringBuilder m_strbCondition = new StringBuilder("");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(12 + p_lstMedicineType.Count, out tmp_objDPArr);
                strSQL.Append(@" where b.status=1 and (g.medstoreid_chr = ?) and h.ifstop_int = 0");
                tmp_objDPArr[0].Value = objvalue_Param.m_strStorageID;
                if (objvalue_Param.m_strValidBeginDate.Trim().Length == 10 && objvalue_Param.m_strValidEndDate.Trim().Length != 10)
                {
                    strSQL.Append(@" and (b.validperiod_dat>=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strValidBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                if (objvalue_Param.m_strValidEndDate.Trim().Length == 10 && objvalue_Param.m_strValidBeginDate.Trim().Length != 10)
                {
                    strSQL.Append(@" and  (b.validperiod_dat<=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strValidEndDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;
                }

                if (objvalue_Param.m_strValidBeginDate.Trim().Length == 10 && objvalue_Param.m_strValidEndDate.Trim().Length == 10)
                {
                    strSQL.Append(@" and (b.validperiod_dat between ? and ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = Convert.ToDateTime(objvalue_Param.m_strValidBeginDate);
                    tmp_objDPArr[m_intParamCount - 1].DbType = DbType.Date;

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
                                       or (c.medicinename_vchr like ?)
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
                    strSQL.Append(@" and (b.oprealgross_int<>?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = 0;

                }

                if (p_strProductor.Length > 0)
                {
                    strSQL.Append(@" and c.productorid_chr like ? ");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = p_strProductor+"%";
                }

                //if (p_strPrepType.Length > 0)
                //{
                //    strSQL.Append(@" and c.medicinepreptype_chr = ? ");
                //    ++m_intParamCount;
                //    tmp_objDPArr[m_intParamCount - 1].Value = p_strPrepType;
                //}

                string strType = string.Empty; 
                string strPrepType = string.Empty;
                bool blnAll = false;
                if (p_objPrepTypeArr != null && p_objPrepTypeArr.Length > 0)
                {
                    for (int i1 = 0; i1 < p_objPrepTypeArr.Length; i1++)
                    {
                        if (p_objPrepTypeArr[i1].m_strMEDICINEPREPTYPE_CHR.Length == 0)
                        {
                            blnAll = true;
                            break;
                        }
                        else
                        {
                            strPrepType += p_objPrepTypeArr[i1].m_strMEDICINEPREPTYPE_CHR + ",";
                        }
                    }
                    if (!blnAll)
                    {
                        strType = " and c.medicinepreptype_chr in (" + strPrepType.Substring(0, strPrepType.Length - 1) + ")";
                        strSQL.Append(strType);
                    }
                }

                strSQL.Append(@" order by  c.medicineid_chr,c.assistcode_chr,lotno_vchr");


                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }


                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                //合并药品 20080116 暂取消合并功能（考虑到可修改库存量的功能及此需求尚未有客户提出） by shaowei.zheng
                //double intRealGross = 0;
                //double intAvailaGross = 0;
                //double intTemA;
                //double intTemR;
                //double intIPRealGross = 0;
                //double intIPAvailaGross = 0;
                //double intIPTemA;
                //double intIPTemR;

                //DataTable dtbTemp = dtbResult.Clone();
                //for (int intRow = 0; intRow < dtbResult.Rows.Count; intRow++)
                //{
                //    DataRow dtrTemp = dtbResult.Rows[intRow];
                //    if ((intRow + 1 >= dtbResult.Rows.Count) || (dtbResult.Rows[intRow]["assistcode_chr"].ToString() != dtbResult.Rows[intRow + 1]["assistcode_chr"].ToString()
                //        || dtbResult.Rows[intRow]["lotno_vchr"].ToString() != dtbResult.Rows[intRow + 1]["lotno_vchr"].ToString()
                //        || Convert.ToDouble(dtbResult.Rows[intRow]["wholesaleprice_int"]) != Convert.ToDouble(dtbResult.Rows[intRow + 1]["wholesaleprice_int"])
                //        || Convert.ToDouble(dtbResult.Rows[intRow]["retailprice_int"]) != Convert.ToDouble(dtbResult.Rows[intRow + 1]["retailprice_int"])))
                //    {
                //        if (intRealGross > 0)
                //        {
                //            double.TryParse(Convert.ToString(dtbResult.Rows[intRow]["realgross_int"]),out intTemR);
                //            double.TryParse(Convert.ToString(dtbResult.Rows[intRow]["availagross_int"]),out intTemA);
                //            double.TryParse(Convert.ToString(dtbResult.Rows[intRow]["iprealgross_int"]), out intIPTemR);
                //            double.TryParse(Convert.ToString(dtbResult.Rows[intRow]["ipavailagross_int"]), out intIPTemA);
                //            dtrTemp["realgross_int"] = intTemR + intRealGross;
                //            dtrTemp["availagross_int"] = intTemA + intAvailaGross;
                //            dtrTemp["iprealgross_int"] = intIPTemR + intIPRealGross;
                //            dtrTemp["ipavailagross_int"] = intIPTemA + intIPAvailaGross;
                //        }
                //        dtbTemp.Rows.Add(dtrTemp.ItemArray);
                //        intRealGross = 0;
                //        intAvailaGross = 0;
                //        intIPRealGross = 0;
                //        intIPAvailaGross = 0;
                //    }
                //    else
                //    {
                //        double.TryParse(Convert.ToString(dtrTemp["realgross_int"]), out intTemR);
                //        double.TryParse(Convert.ToString(dtrTemp["availagross_int"]), out intTemA);
                //        double.TryParse(Convert.ToString(dtrTemp["iprealgross_int"]), out intIPTemR);
                //        double.TryParse(Convert.ToString(dtrTemp["ipavailagross_int"]), out intIPTemA);
                //        intRealGross += intTemR;
                //        intAvailaGross += intTemA;
                //        intIPRealGross += intIPTemR;
                //        intIPAvailaGross += intIPTemA;
                //    }
                //}
                //dtbResult = dtbTemp;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                dtbResult = null;
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
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC", "m_lngGetStorageRack");
            if (lngRes < 0)
                return -1;

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select 
            a.storagerackid_chr,
            a.storagerackname_vchr 
            from t_ms_storagerackset a
            left join t_bse_medstore b on b.medstoreid_chr = a.storageid_chr            
            and a.typeid_int = 2
            where b.medstorename_vchr = ?
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

        #region 获取药房库存缺药和停用数据
        /// <summary>
        /// 获取药房库存缺药和停用数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_strAssistCode"></param>
        /// <param name="p_strMedicineTypeID"></param>
        /// <param name="p_lstMedicineType"></param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageDataForSet(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID,string p_strMedicineID, string p_strAssistCode, string p_strMedicineTypeID,
            List<string> p_lstMedicineType,bool p_blnIsHospital, ref DataTable dtbResult)
        {
            long lngRes = 0;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC", "m_lngGetStorageDataForSet");
            if (lngRes < 0)
            {
                dtbResult = null;
                return -1;
            }

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            StringBuilder strSQL = new StringBuilder();
            if (p_blnIsHospital)
            {
                strSQL.Append(@"select a.seriesid_int,
			 a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.drugstoreid_chr,
			 a.noqtyflag_int,
			 decode(a.noqtyflag_int, 0, '有药', 1, '缺药') noquatityname_vchr,
			 a.ifstop_int,
			 decode(a.ifstop_int, 0, '正常', 1, '停用') ifstopname_vchr,a.storagerackid_chr,
			 b.productorid_chr,
			 b.assistcode_chr,
			 c.medstorename_vchr medicineroomname,
			 decode(b.ipchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
			 decode(b.ipchargeflg_int,
							0,
							sum(round(d.ipavailablegross_num / d.packqty_dec, 2)),
							sum(d.ipavailablegross_num)) availablegross_sum,
			 decode(b.ipchargeflg_int,
							0,
							sum(round(d.iprealgross_int / d.packqty_dec, 2)),
							sum(d.iprealgross_int)) realgross_int,
b.pycode_chr,b.wbcode_chr,
       decode(b.ipchargeflg_int,
              0,
              nvl((select opretailprice_int
                    from (select z.medicineid_chr, z.opretailprice_int
                            from t_ds_storage_detail z
                           inner join t_bse_medstore y on y.deptid_chr =
                                                          z.drugstoreid_chr
                                                      and y.medstoreid_chr = 0001
                           where z.status = 1
                           order by z.seriesid_int desc) x
                   where x.medicineid_chr = a.medicineid_chr
                     and rownum = 1),
                  0),
              round(nvl((select opretailprice_int
                          from (select z.medicineid_chr, z.opretailprice_int
                                  from t_ds_storage_detail z
                                 inner join t_bse_medstore y on y.deptid_chr =
                                                                z.drugstoreid_chr
                                                            and y.medstoreid_chr = 0001
                                 where z.status = 1
                                 order by z.seriesid_int desc) x
                         where x.medicineid_chr = a.medicineid_chr
                           and rownum = 1),
                        0) / b.packqty_dec,
                    4)) retailprice
	from t_ds_storage a
	left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
	left join t_ds_storage_detail d on d.medicineid_chr = a.medicineid_chr
																 and d.drugstoreid_chr = a.drugstoreid_chr");
            }
            else
            {
                strSQL.Append(@"select a.seriesid_int,
			 a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.drugstoreid_chr,
			 a.noqtyflag_int,
			 decode(a.noqtyflag_int, 0, '有药', 1, '缺药') noquatityname_vchr,
			 a.ifstop_int,
			 decode(a.ifstop_int, 0, '正常', 1, '停用') ifstopname_vchr,a.storagerackid_chr,
			 b.productorid_chr,
			 b.assistcode_chr,
			 c.medstorename_vchr medicineroomname,
			 decode(b.opchargeflg_int, 0, a.opunit_chr, a.ipunit_chr) unit_chr,
			 decode(b.opchargeflg_int,
							0,
							sum(round(d.ipavailablegross_num / d.packqty_dec, 2)),
							sum(d.ipavailablegross_num)) availablegross_sum,
			 decode(b.opchargeflg_int,
							0,
							sum(round(d.iprealgross_int / d.packqty_dec, 2)),
							sum(d.iprealgross_int)) realgross_int,
b.pycode_chr,b.wbcode_chr,
       decode(b.opchargeflg_int,
              0,
              nvl((select opretailprice_int
                    from (select z.medicineid_chr, z.opretailprice_int
                            from t_ds_storage_detail z
                           inner join t_bse_medstore y on y.deptid_chr =
                                                          z.drugstoreid_chr
                                                      and y.medstoreid_chr = 0001
                           where z.status = 1
                           order by z.seriesid_int desc) x
                   where x.medicineid_chr = a.medicineid_chr
                     and rownum = 1),
                  0),
              round(nvl((select opretailprice_int
                          from (select z.medicineid_chr, z.opretailprice_int
                                  from t_ds_storage_detail z
                                 inner join t_bse_medstore y on y.deptid_chr =
                                                                z.drugstoreid_chr
                                                            and y.medstoreid_chr = 0001
                                 where z.status = 1
                                 order by z.seriesid_int desc) x
                         where x.medicineid_chr = a.medicineid_chr
                           and rownum = 1),
                        0) / b.packqty_dec,
                    4)) retailprice
	from t_ds_storage a
	left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
	left join t_ds_storage_detail d on d.medicineid_chr = a.medicineid_chr
																 and d.drugstoreid_chr = a.drugstoreid_chr");
            }


            try
            {
                int m_intParamCount = 1;

                StringBuilder m_strbCondition = new StringBuilder("");

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                IDataParameter[] tmp_objDPArr = null;
                objHRPServ.CreateDatabaseParameter(12 + p_lstMedicineType.Count, out tmp_objDPArr);
                strSQL.Append(@" where (c.medstoreid_chr = ?) and d.status = 1 ");
                tmp_objDPArr[0].Value = p_strStorageID;
                
                if (p_strMedicineID.Trim().Length > 0)
                {
                    strSQL.Append(@" and (b.medicineid_chr = ?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = p_strMedicineID;
                }
                else
                {
                    if (p_strAssistCode.Length > 0)
                    {
                        strSQL.Append(@" and ((b.medicineid_chr like ?)
                                       or (b.assistcode_chr like ?) 
                                       or (b.medicinename_vchr like ?)
                                       or (b.pycode_chr like ?) 
                                       or (b.wbcode_chr like ?))");
                        for (int i1 = 0; i1 < 5; i1++)
                        {
                            tmp_objDPArr[m_intParamCount + i1].Value = p_strAssistCode;
                        }
                        m_intParamCount = m_intParamCount + 5;
                    }
                }

                if (p_lstMedicineType.Count > 0)
                {
                    strSQL.Append(@" and ((b.medicinetypeid_chr=?)");
                    ++m_intParamCount;
                    tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[0].ToString();

                    for (int i1 = 1; i1 < p_lstMedicineType.Count; i1++)
                    {
                        strSQL.Append(@" or (b.medicinetypeid_chr=?)");
                        ++m_intParamCount;
                        tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[i1].ToString();
                    }
                    strSQL.Append(@")");
                }
                if (p_blnIsHospital)
                {
                    strSQL.Append(@" group by a.seriesid_int,
					a.medicineid_chr,
					a.medicinename_vchr,
					a.medspec_vchr,
					a.drugstoreid_chr,
					a.noqtyflag_int,
					a.ifstop_int,a.storagerackid_chr,
					a.opunit_chr,
					a.ipunit_chr,
					b.productorid_chr,
					b.assistcode_chr,
					b.ipchargeflg_int,
					c.medstorename_vchr,b.pycode_chr,b.wbcode_chr,
          b.packqty_dec
                    order by  b.assistcode_chr asc");
                }
                else
                {
                    strSQL.Append(@" group by a.seriesid_int,
					a.medicineid_chr,
					a.medicinename_vchr,
					a.medspec_vchr,
					a.drugstoreid_chr,
					a.noqtyflag_int,
					a.ifstop_int,a.storagerackid_chr,
					a.opunit_chr,
					a.ipunit_chr,
					b.productorid_chr,
					b.assistcode_chr,
					b.opchargeflg_int,
					c.medstorename_vchr,b.pycode_chr,b.wbcode_chr,
          b.packqty_dec
                    order by  b.assistcode_chr asc");
                }

                objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

                for (int i1 = 0; i1 < m_intParamCount; i1++)
                {
                    objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                    objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
                }


                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);
                if (dtbResult.Rows.Count > 0)
                {
                    DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    dcPrimaryKeyArr[0] = dtbResult.Columns["seriesid_int"];
                    dtbResult.PrimaryKey = dcPrimaryKeyArr;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        dtbResult.Rows[i1]["unit_chr"] = dtbResult.Rows[i1]["unit_chr"].ToString().Trim();
                    }
                }

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

        #region 检查是否住院药房使用
        /// <summary>
        /// 是否住院药房使用
        /// </summary>
        /// <param name="p_objPrincipal">
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsHospital(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugStoreID,out bool p_blnIsHospital)
        {
            p_blnIsHospital = false;
            DataTable dtbTemp = new DataTable();
            long lngRes = 0;
            try
            {
                string strSQL = @"select a.medstoretype_int
	from t_bse_medstore a
 where a.medstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParam = null;
                objHRPServ.CreateDatabaseParameter(1, out objParam);
                objParam[0].Value = p_strDrugStoreID;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objParam);
                if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dtbTemp.Rows[0]["medstoretype_int"]) == 2)
                        p_blnIsHospital = true;
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
        #endregion 

        #region 根据ID获取库存明细表的资料
        /// <summary>
        /// 根据ID获取库存明细表的资料
        /// </summary>
        /// <param name="p_objPrincipal">权限</param>
        /// <param name="p_intSeriesID">ID</param>
        /// <param name="p_objHistory">库存明细</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAmountBySeriesID(System.Security.Principal.IPrincipal p_objPrincipal, long p_intSeriesID, out clsDS_StorageHistory_VO p_objHistory)
        {
            p_objHistory = new clsDS_StorageHistory_VO();
            long lngRes = 0;
            try
            {
                
                DataTable m_dtbTemp = new DataTable();
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                string strSQL = @"select a.opavailablegross_num,
       a.ipavailablegross_num,
       a.opunit_chr,
       a.ipunit_chr,
       a.drugstoreid_chr,
       a.medicineid_chr
  from t_ds_storage_detail a
 where a.seriesid_int = ?";

                objHRPServ.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_intSeriesID;
                objHRPServ.lngGetDataTableWithParameters(strSQL, ref m_dtbTemp, objParamArr);

                if (m_dtbTemp != null && m_dtbTemp.Rows.Count > 0)
                {
                    p_objHistory.m_lngSERIESID2_INT = p_intSeriesID;
                    p_objHistory.m_dblOPAVAILABLEGROSS_NUM = Convert.ToDouble(m_dtbTemp.Rows[0]["opavailablegross_num"]);
                    p_objHistory.m_dblIPAVAILABLEGROSS_NUM = Convert.ToDouble(m_dtbTemp.Rows[0]["ipavailablegross_num"]);
                    p_objHistory.m_strOPUNIT_CHR = m_dtbTemp.Rows[0]["opunit_chr"].ToString();
                    p_objHistory.m_strIPUNIT_CHR = m_dtbTemp.Rows[0]["ipunit_chr"].ToString();
                    p_objHistory.m_strDRUGSTOREID_CHR = m_dtbTemp.Rows[0]["drugstoreid_chr"].ToString();
                    p_objHistory.m_strMEDICINEID_CHR = m_dtbTemp.Rows[0]["medicineid_chr"].ToString();
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
