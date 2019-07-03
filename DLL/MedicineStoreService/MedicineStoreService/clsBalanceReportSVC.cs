using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 盘点对账表
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBalanceReportSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药库盘点对账表数据
        /// <summary>
        /// 获取药库盘点对账表数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnAccount">是否结帐</param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBalance(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbResult)
        {
            long lngRes = 0;

            p_dtbResult = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC", "m_mthGetBalance");
            if (lngRes < 0)
            {
                p_dtbResult = null;
                return -1;
            }

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"select a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.opunit_chr,
			 0 realendamountdiff,
			 0 realendsumdiff,
			 decode(c.type_int, 1, c.amount_int, 0) inamount,
			 decode(c.type_int, 1, c.amount_int, 0) * c.retailprice_int insum,
			 decode(c.type_int, 2, c.amount_int, 0) outamount,
			 decode(c.type_int, 2, c.amount_int, 0) * c.retailprice_int outsum,
			 decode(c.isend_int, 0, decode(c.type_int, 0, c.oldgross_int, 0), 0) adjustamount,
			 decode(c.isend_int, 0, decode(c.type_int, 0, c.oldgross_int, 0), 0) *
			 (c.newretailprice_int - c.retailprice_int) adjustsum,
			 0 recipeamount,
			 0 recipesum,
			 decode(c.isend_int, 1, c.endamount_int, 0) startamount,
			 decode(c.isend_int, 1, c.endamount_int, 0) * c.endretailprice_int startsum,
			 c.endamount_int endamount,
			 c.endamount_int * c.endretailprice_int endsum,
			 (select sum(z.realgross_int)
					from t_ms_storage_detail z
				 where z.medicineid_chr = a.medicineid_chr
					 and z.status = 1
					 and z.storageid_chr = ?) realendamount,
			 (select sum(z.realgross_int * z.retailprice_int)
					from t_ms_storage_detail z
				 where z.medicineid_chr = a.medicineid_chr
					 and z.status = 1
					 and z.storageid_chr = ?) realendsum,
			 0 putamount,
			 0 putsum,
			 c.type_int,
			 c.isend_int,
			 c.state_int,
			 c.accountid_chr,
             a.medicinetypeid_chr,
			 c.operatedate_dat,
			 a.assistcode_chr,
			 a.wbcode_chr,
			 a.pycode_chr
	from t_bse_medicine a
	left join t_ms_medicinestoreroomset b on b.medicinetypeid_chr =
																					 a.medicinetypeid_chr
	left outer join t_ms_account_detail c on c.medicineid_chr =
																					 a.medicineid_chr
																			 and c.state_int <> 0
																			 and c.storageid_chr = ?
 where exists (select medicinetypeid_chr
					from t_ms_medicinestoreroomset b
				 where b.medicinetypeid_chr = a.medicinetypeid_chr
					 and b.medicineroomid = ?)	 
	 and a.ifstop_int = 0";


            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 取得上次结转时间
        /// <summary>
        /// 取得上次结转时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLastBalanceTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageId, out DateTime p_dtTime)
        {
            DataTable p_dtbVendor = new DataTable();
            p_dtTime = DateTime.MinValue;
            long lngRes = 0;
            try
            {
                string strSQL = @"select max(endtime_dat) endtime_dat
	from t_ms_accountperiod
 where storageid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageId;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbVendor, objDPArr);
                if (p_dtbVendor != null && p_dtbVendor.Rows.Count > 0)
                {
                    if (p_dtbVendor.Rows[0]["endtime_dat"].ToString() == "")
                    {
                        p_dtTime = DateTime.MinValue;
                    }
                    else
                    {
                        p_dtTime = Convert.ToDateTime(p_dtbVendor.Rows[0]["endtime_dat"]);
                    }
                }
                objHRPServ.Dispose();
                return lngRes;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取药库盘点对账表数据（分帐务期）
        /// <summary>
        /// 获取药库盘点对账表数据（分帐务期）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBalanceDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbResult)
        {
            long lngRes = 0;

            p_dtbResult = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC", "m_lngGetBalanceDetail");
            if (lngRes < 0)
            {
                p_dtbResult = null;
                return -1;
            }

            string strSQL = @"select a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.opunit_chr,
			 a.medicinetypeid_chr,
			 a.assistcode_chr,
			 a.wbcode_chr,
			 a.pycode_chr,a.productorid_chr,
			 c.amount_int,
			 c.retailprice_int,
			 c.oldgross_int,
			 c.newretailprice_int,
			 c.endamount_int,
			 c.endretailprice_int,
			 c.type_int,
			 c.isend_int,
			 c.state_int,
			 c.accountid_chr,
			 c.operatedate_dat,
			 c.chittyid_vchr,
			 (select sum(z.realgross_int)
					from t_ms_storage_detail z
				 where z.medicineid_chr = a.medicineid_chr
					 and z.status = 1
					 and z.storageid_chr = ?) realamount,
			 (select sum(z.realgross_int * z.retailprice_int)
					from t_ms_storage_detail z
				 where z.medicineid_chr = a.medicineid_chr
					 and z.status = 1
					 and z.storageid_chr = ?) realsum
	from t_bse_medicine a
	left join t_ms_medicinestoreroomset b on b.medicinetypeid_chr =
																					 a.medicinetypeid_chr
	left outer join t_ms_account_detail c on c.medicineid_chr =
																					 a.medicineid_chr
																			 and c.state_int <> 0
																			 and c.storageid_chr = ?
 where exists (select medicinetypeid_chr
					from t_ms_medicinestoreroomset b
				 where b.medicinetypeid_chr = a.medicinetypeid_chr
					 and b.medicineroomid = ?)";


            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strStorageID;
                objDPArr[3].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbResult.DefaultView;
                    dvResult.Sort = "medicinename_vchr,medicineid_chr";
                    p_dtbResult = dvResult.ToTable();
                }

                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion


        #region 获取药房盘点对账表数据（分帐务期）
        /// <summary>
        /// 获取药库盘点对账表数据（分帐务期）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_blnAccount">是否结帐</param>
        /// <param name="p_dtm1"></param>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBalanceDetailForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strAccountID, string p_strLastAccountID,
            DateTime p_dtmStart, DateTime p_dtmEnd, out DataTable p_dtbResult)
        {
            long lngRes = 0;

            p_dtbResult = null;

            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC", "m_lngGetBalanceDetailForDrugStore");
            if (lngRes < 0)
            {
                p_dtbResult = null;
                return -1;
            }

            string strSQL = @"select a.medicineid_chr,
                a.medicinename_vchr,
                a.medspec_vchr,
                a.opunit_chr,
                a.productorid_chr,
                a.medicinetypeid_chr,
                a.assistcode_chr,
                a.wbcode_chr,
                a.pycode_chr,
                a.opchargeflg_int,
                a.packqty_dec bsepackty,
                c.opamount_int,
                c.ipamount_int,
                c.opretailprice_int,
                c.ipretailprice_int,
                c.opoldgross_int,
                c.ipoldgross_int,
                c.opnewretailprice_int,
                c.ipnewretailprice_int,
                c.endopamount_int,
                c.endipamount_int,
                c.endopretailprice_int,
                c.endipretailprice_int,
                c.type_int,
                c.isend_int,
                c.state_int,
                c.accountid_chr,
                c.operatedate_dat,
                c.chittyid_vchr,
                c.packqty_dec,
                (select sum(z.oprealgross_int)
                   from t_ds_storage_detail z
                  where z.drugstoreid_chr = ?
                    and z.medicineid_chr = a.medicineid_chr
                    and z.status = 1
                  group by z.opretailprice_int) oprealgross_int,
                (select sum(z.iprealgross_int)
                   from t_ds_storage_detail z
                  where z.drugstoreid_chr = ?
                    and z.medicineid_chr = a.medicineid_chr
                    and z.status = 1
                  group by z.opretailprice_int) iprealgross_int,
                (select z.opretailprice_int
          from t_ds_storage_detail z
         where z.drugstoreid_chr = ?
           and z.medicineid_chr = a.medicineid_chr
           and z.status = 1
           and rownum = 1) oprealprice
  from t_bse_medicine a
  left join t_ds_account_detail c on c.medicineid_chr = a.medicineid_chr
                                 and c.state_int <> 0
                                 and c.drugstoreid_int = ?
 where exists
 (select medicinetypeid_chr
          from t_ds_medstoreset b
          left join t_bse_medstore f on f.medstoreid_chr = b.medstoreid
         where b.medicinetypeid_chr = a.medicinetypeid_chr
           and f.deptid_chr = ?)";

            clsHRPTableService objHRPServ = new clsHRPTableService();
            IDataParameter[] objDPArr = null;
            objHRPServ.CreateDatabaseParameter(5, out objDPArr);
            objDPArr[0].Value = p_strStorageID;
            objDPArr[1].Value = p_strStorageID;
            objDPArr[2].Value = p_strStorageID;
            objDPArr[3].Value = p_strStorageID;
            objDPArr[4].Value = p_strStorageID;
            //if (p_strAccountID == "未结转")
            //{
            //    if (p_strLastAccountID == "")//第一期
            //    {
            //        //返回全部数据
            //        objHRPServ.CreateDatabaseParameter(4, out objDPArr);
            //        objDPArr[0].Value = p_strStorageID;
            //        objDPArr[1].Value = p_strStorageID;
            //        objDPArr[2].Value = p_strStorageID;
            //        objDPArr[3].Value = p_strStorageID;
            //    }
            //    else//最后一期
            //    {
            //        strSQL += " and c.accountid_chr = ? or operatedate_dat >= ?";//p_strLastAccountID,p_dtmStart
            //        objHRPServ.CreateDatabaseParameter(6, out objDPArr);
            //        objDPArr[0].Value = p_strStorageID;
            //        objDPArr[1].Value = p_strStorageID;
            //        objDPArr[2].Value = p_strStorageID;
            //        objDPArr[3].Value = p_strStorageID;
            //        objDPArr[4].Value = p_strLastAccountID;
            //        objDPArr[5].Value = p_dtmStart;
            //        objDPArr[5].DbType = DbType.DateTime;
            //    }
            //}
            //else
            //{
            //    if (p_strLastAccountID == "")//第一期
            //    {
            //        strSQL += " and c.accountid_chr = ? and (operatedate_dat <  ? or operatedate_dat is null)";//p_strAccountID,p_dtmStart
            //        objHRPServ.CreateDatabaseParameter(6, out objDPArr);
            //        objDPArr[0].Value = p_strStorageID;
            //        objDPArr[1].Value = p_strStorageID;
            //        objDPArr[2].Value = p_strStorageID;
            //        objDPArr[3].Value = p_strStorageID;
            //        objDPArr[4].Value = p_strAccountID;
            //        objDPArr[5].Value = p_dtmEnd;
            //        objDPArr[5].DbType = DbType.DateTime;
            //    }
            //    else
            //    {
            //        //p_strAccountID,p_strLastAccountID,p_dtmStart,p_dtmEnd
            //        strSQL += " and c.accountid_chr = ?  or c.accountid_chr = ? or ( operatedate_dat between ? and ? )";
            //        objHRPServ.CreateDatabaseParameter(8, out objDPArr);
            //        objDPArr[0].Value = p_strStorageID;
            //        objDPArr[1].Value = p_strStorageID;
            //        objDPArr[2].Value = p_strStorageID;
            //        objDPArr[3].Value = p_strStorageID;
            //        objDPArr[4].Value = p_strAccountID;
            //        objDPArr[5].Value = p_strLastAccountID;
            //        objDPArr[6].Value = p_dtmStart;
            //        objDPArr[6].DbType = DbType.DateTime;
            //        objDPArr[7].Value = p_dtmEnd;
            //        objDPArr[7].DbType = DbType.DateTime;   
            //    }
            //}

            try
            {

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbResult.DefaultView;
                    dvResult.Sort = "medicinename_vchr,medicineid_chr";
                    if (p_strAccountID == "未结转")
                    {
                        if (p_strLastAccountID != "")
                        {
                            dvResult.RowFilter = "accountid_chr = '" + p_strLastAccountID + "' or accountid_chr is null or operatedate_dat >= #" + p_dtmStart + "#";
                        }
                    }
                    else
                    {
                        if (p_strLastAccountID == "")//第一期
                        {
                            dvResult.RowFilter = "accountid_chr = '" + p_strAccountID + "' or accountid_chr is null or operatedate_dat is null or operatedate_dat <= #" + p_dtmEnd + "#";
                        }
                        else
                        {
                            dvResult.RowFilter = "accountid_chr = '" + p_strAccountID + "' or accountid_chr is null or accountid_chr = '" + p_strLastAccountID + "' or (operatedate_dat >= #" + p_dtmStart + "# and operatedate_dat <= #" + p_dtmEnd + "#)";
                        }
                    }


                    p_dtbResult = dvResult.ToTable();
                }
                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion


        #region 获取出退库处方药品明细
        /// <summary>
        /// 获取出退库处方药品明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, DateTime p_dtmStart, DateTime p_dtmEnd, out DataTable p_dtbResult)
        {
            long lngRes = 0;

            p_dtbResult = null;
            string strMedicineID = string.Empty;
            //权限控制,clsPrivilegeHandleService为权限处理服务类
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new com.digitalwave.security.clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsBalanceReportSVC", "m_lngGetRecipeDetail");
            if (lngRes < 0)
            {
                p_dtbResult = null;
                return -1;
            }

            string strSQL = @"select a.medicineid_chr,
			 a.opamount_int,
			 a.ipamount_int,
			 a.opretailprice_int,
			 a.type_int,
			 b.opchargeflg_int,
			 decode(c.packqty_dec, null, b.packqty_dec, c.packqty_dec) packqty_dec,
             0 amount_int,
             0 sum_int
	from t_ds_recipeaccount_detail a
	inner join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_ds_storage_detail c on c.seriesid_int = a.medseriesid_int
 where a.drugstoreid_int = ?
	 and a.state_int <> 0 and a.type_int <> 0
	 and a.operatedate_dat between ? and ?";


            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;

                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_dtmStart;
                objDPArr[1].DbType = DbType.DateTime;
                objDPArr[2].Value = p_dtmEnd;
                objDPArr[2].DbType = DbType.DateTime;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbResult.DefaultView;
                    dvResult.Sort = "medicineid_chr";
                    p_dtbResult = dvResult.ToTable();

                    DataTable dtbTemp = p_dtbResult.Clone();
                    
                    DataRow drRow = null;
                    DataRow drNew = null;
                    for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                    {
                        drRow = p_dtbResult.Rows[i1];
                        if (strMedicineID != drRow["medicineid_chr"].ToString())
                        {
                            strMedicineID = drRow["medicineid_chr"].ToString();
                            drNew = dtbTemp.NewRow();
                            drNew["medicineid_chr"] = drRow["medicineid_chr"];
                            if (Convert.ToInt16(drRow["opchargeflg_int"]) == 0)
                            {
                                if (Convert.ToInt16(drRow["type_int"]) == 1)//入库
                                {
                                    drNew["amount_int"] = -Convert.ToDouble(drRow["opamount_int"]);
                                    drNew["sum_int"] = -Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                                else
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(drRow["type_int"]) == 1)//入库
                                {
                                    drNew["amount_int"] = -Convert.ToDouble(drRow["ipamount_int"]);
                                    drNew["sum_int"] = -Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                                else
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                            }
                            dtbTemp.Rows.Add(drNew);
                        }
                        else
                        {
                            if (Convert.ToInt16(drRow["opchargeflg_int"]) == 0)
                            {
                                if (Convert.ToInt16(drRow["type_int"]) == 1)//入库
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drNew["amount_int"]) - Convert.ToDouble(drRow["opamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drNew["sum_int"]) - Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                                else
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drNew["amount_int"]) + Convert.ToDouble(drRow["opamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drNew["sum_int"]) + Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(drRow["type_int"]) == 1)//入库
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drNew["amount_int"]) - Convert.ToDouble(drRow["ipamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drNew["sum_int"]) - Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                                else
                                {
                                    drNew["amount_int"] = Convert.ToDouble(drNew["amount_int"]) + Convert.ToDouble(drRow["ipamount_int"]);
                                    drNew["sum_int"] = Convert.ToDouble(drNew["sum_int"]) + Convert.ToDouble(drRow["ipamount_int"]) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]);
                                }
                            }
                        }
                    }
                    p_dtbResult = dtbTemp.Copy();
                }

                objHRPServ.Dispose();
            }
            catch (Exception objEx)
            {
                string strTemp = strMedicineID;
                string strTmp = objEx.Message;
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
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccountData">帐务期表内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAccountIDListForDrugStore(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out clsMS_AccountPeriodVO[] p_objAccountData)
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
       t.drugstoreid_chr,
       t.seriesid_int
  from t_ds_accountperiod t
 where t.drugstoreid_chr = ?
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
    }
}
