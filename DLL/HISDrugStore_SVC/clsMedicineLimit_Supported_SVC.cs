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
    /// 药房库存限量设置类
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsMedicineLimit_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region 获取库存限量设置数据
        /// <summary>
        /// 获取库存限量设置数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strDrugType">药品类型</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbResult">库存限量设置数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetLimitData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID,string p_strDrugType,bool p_blnIsHospital,ref DataTable p_dtbResult)
        {
            long lngRes = 0;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            StringBuilder strSQL = new StringBuilder();
            if (p_blnIsHospital)
            {
                strSQL.Append(@"select b.assistcode_chr,
			 b.medicineid_chr,
			 b.medicinename_vchr,
			 b.medspec_vchr,
             b.productorid_chr,
			 decode(b.ipchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit_chr,
			 a.drugstoreid_chr,
			 c.medstorename_vchr,
			 (select currentgross_num
					from (select decode(g.ipchargeflg_int,
															0,
															sum(round(f.iprealgross_int / f.packqty_dec, 2)),
															sum(f.iprealgross_int)) currentgross_num,
											 f.drugstoreid_chr,
											 f.medicineid_chr
									from t_ds_storage_detail f
									left join t_bse_medicine g on g.medicineid_chr =
																								f.medicineid_chr
								 where f.status = 1
								 group by f.drugstoreid_chr,
													g.ipchargeflg_int,
													f.medicineid_chr)
				 where rownum = 1
					 and drugstoreid_chr = ?
					 and medicineid_chr = b.medicineid_chr) realgross_int,
			 a.tiptoplimit_int,
			 a.neaplimit_int
	from t_bse_medicine b
	left join t_ds_medlimit a on a.medicineid_chr = b.medicineid_chr
													 and (a.drugstoreid_chr = ?)
	left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
 where b.medicinetypeid_chr = ? and b.ifstop_int = 0");
            }
            else
            {
                strSQL.Append(@"select b.assistcode_chr,
			 b.medicineid_chr,
			 b.medicinename_vchr,
			 b.medspec_vchr,
             b.productorid_chr,
			 decode(b.opchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit_chr,
			 a.drugstoreid_chr,
			 c.medstorename_vchr,
			 (select currentgross_num
					from (select decode(g.opchargeflg_int,
															0,
															sum(round(f.iprealgross_int / f.packqty_dec, 2)),
															sum(f.iprealgross_int)) currentgross_num,
											 f.drugstoreid_chr,
											 f.medicineid_chr
									from t_ds_storage_detail f
									left join t_bse_medicine g on g.medicineid_chr =
																								f.medicineid_chr
								 where f.status = 1
								 group by f.drugstoreid_chr,
													g.opchargeflg_int,
													f.medicineid_chr)
				 where rownum = 1
					 and drugstoreid_chr = ?
					 and medicineid_chr = b.medicineid_chr) realgross_int,
			 a.tiptoplimit_int,
			 a.neaplimit_int
	from t_bse_medicine b
	left join t_ds_medlimit a on a.medicineid_chr = b.medicineid_chr
													 and (a.drugstoreid_chr = ?)
	left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
 where b.medicinetypeid_chr = ? and b.ifstop_int = 0");
            }
            
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strDrugType;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objDPArr);
                if(p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbResult.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbResult = dvResult.ToTable();
                    p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["medicineid_chr"] };
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_dtbResult = null;
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 保存修改后的限量
        /// <summary>
        /// 保存修改后的限量
        /// </summary>
        /// <param name="p_objLimit">药房库存限量设置数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveMedicine(clsDS_MedicineLimit[] p_objLimit)
        {
            long lngRes = -1;
            string strSQLQuery = @"select tiptoplimit_int,neaplimit_int from t_ds_medlimit where drugstoreid_chr = ? and medicineid_chr = ?";
            string strSQLEdit = @"update t_ds_medlimit set tiptoplimit_int = ?,neaplimit_int = ? where drugstoreid_chr = ? and medicineid_chr = ?";
            string strSQLNew = @"insert into t_ds_medlimit (tiptoplimit_int,neaplimit_int,drugstoreid_chr,medicineid_chr) values (?,?,?,?)";
            clsHRPTableService objHRPServ = new clsHRPTableService();
            DataTable dtbResult = new DataTable();
            IDataParameter[] objDPQueryArr = null;
            IDataParameter[] objDPEditArr = null;
            IDataParameter[] objDPNewArr = null;
            for (int iOr = 0; iOr < p_objLimit.Length; iOr++)
            {
                objHRPServ.CreateDatabaseParameter(2, out objDPQueryArr);
                objDPQueryArr[0].Value = p_objLimit[iOr].m_strDrugstoreid_chr;
                objDPQueryArr[1].Value = p_objLimit[iOr].m_strMedicineid_chr;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQLQuery, ref dtbResult, objDPQueryArr);
                if (dtbResult.Rows.Count > 0)
                {
                    objHRPServ.CreateDatabaseParameter(4, out objDPEditArr);
                    objDPEditArr[0].Value = p_objLimit[iOr].m_dblTiptoplimit_int;
                    objDPEditArr[1].Value = p_objLimit[iOr].m_dblNeaplimit_int;
                    objDPEditArr[2].Value = p_objLimit[iOr].m_strDrugstoreid_chr;
                    objDPEditArr[3].Value = p_objLimit[iOr].m_strMedicineid_chr;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQLEdit, ref lngRes, objDPEditArr);
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(4, out objDPNewArr);
                    objDPNewArr[0].Value = p_objLimit[iOr].m_dblTiptoplimit_int;
                    objDPNewArr[1].Value = p_objLimit[iOr].m_dblNeaplimit_int;
                    objDPNewArr[2].Value = p_objLimit[iOr].m_strDrugstoreid_chr;
                    objDPNewArr[3].Value = p_objLimit[iOr].m_strMedicineid_chr;
                    lngRes = objHRPServ.lngExecuteParameterSQL(strSQLNew, ref lngRes, objDPNewArr);
                }
            }
            objHRPServ.Dispose();
            objHRPServ = null;
            return lngRes;
        }
        #endregion

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param> 
        /// <param name="p_strDrugType">药品类型</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode,string p_strDrugType, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;

            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                string strSQL = @"select t.assistcode_chr,
       t.medicinename_vchr,
       t.medspec_vchr,
       t.opunit_chr,
       t.ipunit_chr,
       t.packqty_dec,
       t.productorid_chr,
       t.pycode_chr,
       t.wbcode_chr,
       t.medicineid_chr,
       t.ispoison_chr,
       t.ischlorpromazine2_chr,
       t.unitprice_mny,
       t.medicinetypeid_chr,
       t.tradeprice_mny,
       t.limitunitprice_mny,
       t.opchargeflg_int,
       t.ipchargeflg_int,
       t.ifstop_int,
       b.itemname_vchr as aliasname_vchr,
       b.pycode_vchr as aliaspycode_vchr,
       b.wbcode_vchr as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
 where t.assistcode_chr like ?
    and t.medicinetypeid_chr = ? and  t.deleted_int=0
 order by t.assistcode_chr,t.medicineid_chr";
                
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strDrugType;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
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

        #region 获取药品低于最低限量的数量(住院药房使用)
        /// <summary>
        /// 获取药品低于最低限量的数量(住院药房使用)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_dtmStart">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbResult">库存限量设置数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetNeapData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID,DateTime p_dtmStart,DateTime p_dtmEnd, ref DataTable p_dtbResult)
        {
            long lngRes = 0;

            //创建COM对象
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            
            string strSQL = @"select 'F' ifcheck,
       b.assistcode_chr,
       b.medicineid_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       b.opunit_chr,
       a.drugstoreid_chr,
       c.medstorename_vchr,
       nvl((decode(b.ipchargeflg_int,
                   0,
                   sum(round(d.iprealgross_int / d.packqty_dec, 2)),
                   sum(d.iprealgross_int))),
           0) currentgross_num,
       a.tiptoplimit_int,
       a.neaplimit_int,
       0 opamount_int,
       b.packqty_dec,
       0 ipamount_int,
       b.ipunit_chr,
       decode(b.ipchargeflg_int, 0, b.opunit_chr, b.ipunit_chr) unit_chr,
       a.tiptoplimit_int amount_int,
       b.opchargeflg_int,
       b.ipchargeflg_int,
       b.productorid_chr,
       b.unitprice_mny,
       (select askdate_dat
          from (select s.askdate_dat, t.medicineid_chr, s.askdept_chr
                  from t_ds_ask_detail t
                  left join t_ds_ask s on s.seriesid_int = t.seriesid2_int
                 where s.status_int = 2
                 order by s.askdate_dat desc)
         where askdept_chr = a.drugstoreid_chr
           and medicineid_chr = a.medicineid_chr
           and rownum = 1) askdate_dat,
       b.medicinetypeid_chr,
       b.requestpackqty_dec,
       b.requestunit_chr,
       0 requestamount_int,
       0 useamount_int
  from t_bse_medicine b
  left join t_ds_medlimit a on a.medicineid_chr = b.medicineid_chr
  left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_chr
  left join t_ds_storage_detail d on d.medicineid_chr = b.medicineid_chr
                                 and d.drugstoreid_chr = c.deptid_chr
 where c.medstoreid_chr = ?
 group by b.assistcode_chr,
          b.medicineid_chr,
          b.medicinename_vchr,
          b.medspec_vchr,
          b.opunit_chr,
          a.drugstoreid_chr,
          c.medstorename_vchr,
          b.opchargeflg_int,
          b.ipchargeflg_int,
          a.tiptoplimit_int,
          a.neaplimit_int,
          a.tiptoplimit_int,
          b.ipunit_chr,
          b.packqty_dec,
          b.opchargeflg_int,
          b.productorid_chr,
          b.unitprice_mny,
          b.medicinetypeid_chr,
          b.requestpackqty_dec,
          b.requestunit_chr,
          a.medicineid_chr";
            try
            {
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;                

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
                if (p_dtbResult != null && p_dtbResult.Rows.Count > 0)
                {
                    DataTable dtbTemp = new DataTable();
                    strSQL = @"select a.medicineid_chr,
       nvl(sum(decode(a.type_int,
                      1,
                      decode(b.ipchargeflg_int,
                             0,
                             a.opamount_int,
                             a.ipamount_int),
                      2,
                      -decode(b.ipchargeflg_int,
                              0,
                              a.opamount_int,
                              a.ipamount_int))),
           0) useamount_int
  from t_ds_putmedaccount_detail a
  left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
  left join t_bse_medstore c on c.deptid_chr = a.drugstoreid_int
 where c.medstoreid_chr = ?
   and a.state_int <> 0
   and a.operatedate_dat between ? and ?
 group by a.medicineid_chr";
                    objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strStorageID;
                    objDPArr[1].Value = p_dtmStart;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtmEnd;
                    objDPArr[2].DbType = DbType.DateTime;
                    objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbTemp, objDPArr);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        dtbTemp.PrimaryKey = new DataColumn[] { dtbTemp.Columns["medicineid_chr"] };
                    }

                    DataRow drRow = null;
                    DataRow drTemp = null;
                    for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                    {
                        drRow = p_dtbResult.Rows[i1];
                        if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                        {
                            drTemp = dtbTemp.Rows.Find(drRow["medicineid_chr"]);
                            if (drTemp != null)
                            {
                                drRow["useamount_int"] = drTemp["useamount_int"];
                            }
                        }
                        if(Convert.ToDouble(drRow["requestpackqty_dec"]) > 0)
                        {                            
                            if (Convert.ToInt16(drRow["ipchargeflg_int"]) == 0)
                            {
                                drRow["requestamount_int"] = Math.Ceiling(Convert.ToDouble(drRow["amount_int"]) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                drRow["opamount_int"] = Convert.ToDouble(drRow["requestamount_int"]) * Convert.ToDouble(drRow["requestpackqty_dec"]);
                                drRow["ipamount_int"] = Convert.ToDouble(drRow["opamount_int"]) * Convert.ToDouble(drRow["packqty_dec"]);
                                drRow["amount_int"] = Convert.ToDouble(drRow["opamount_int"]);
                            }
                            else
                            {
                                drRow["requestamount_int"] = Math.Ceiling((Convert.ToDouble(drRow["amount_int"]) / Convert.ToDouble(drRow["packqty_dec"])) / Convert.ToDouble(drRow["requestpackqty_dec"]));
                                drRow["opamount_int"] = Convert.ToDouble(drRow["requestamount_int"]) * Convert.ToDouble(drRow["requestpackqty_dec"]);
                                drRow["ipamount_int"] = Convert.ToDouble(drRow["opamount_int"]) * Convert.ToDouble(drRow["packqty_dec"]);
                                drRow["amount_int"] = Convert.ToDouble(drRow["ipamount_int"]);
                            }
                        }                        
                    }
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_dtbResult = null;
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbResult">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineType(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select medicinetypeid_chr,medicinetypename_vchr from t_aid_medicinetype";

                clsHRPTableService objHRPServ = new clsHRPTableService();                
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);
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

        //下面方法多单位维护使用
        #region 获取药品信息
        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="p_dtMedicineList">药品信息列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTableMedicineList(ref DataTable p_dtMedicineList)
        {
            long lngRes = -1;

            string strSQL = @"select a.itemid_chr,
                                     a.itemcode_vchr,
                                     a.itempycode_chr,
                                     a.itemwbcode_chr,
                                     a.itemname_vchr,
                                     a.itemcommname_vchr,
                                     a.itemengname_vchr
                                from t_bse_chargeitem a, t_bse_medicine b
                               where a.itemsrcid_vchr = b.medicineid_chr
                                 and b.multiunitflag_int = 1
                                 and a.ifstop_int = 0";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtMedicineList);
                int x = p_dtMedicineList.Rows.Count;
                objHRPSvc.Dispose();
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

        #region 根据药品Id获取相应的单位列表
        /// <summary>
        /// 根据药品Id获取相应的单位列表
        /// </summary>
        /// <param name="p_strMedId">药品Id</param>
        /// <param name="p_dtMultiUnit"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTableMultiUnitList(string p_strMedId, out DataTable p_dtMultiUnit)
        {
            long lngRes = -1;
            p_dtMultiUnit = null;

            string strSQL = @"select a.itemid_chr,
       a.unit_vchr,
       a.package_dec,
       case
         when a.curruseflag_int = 0 then
          '否'
         else
          '是'
       end as curruseflag_int,
       case
         when a.status_int = 0 then
          '停用'
         else
          '启用'
       end as status_int
  from t_bse_itemmultiunit_drug a, t_bse_chargeitem b
 where b.itemsrcid_vchr = ?
   and a.itemid_chr = b.itemid_chr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strMedId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtMultiUnit, ParamArr);

                objHRPSvc.Dispose();
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

        #region 根据索引查询单位
        /// <summary>
        /// 根据索引查询单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">数量</param>
        /// <param name="p_CurruseFlag_Int">是否当前单位标记</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec, int p_CurruseFlag_Int)
        {
            bool blnIsFind = false;

            string strSQL = @"select a.itemid_chr, a.unit_vchr,a.status_int
                                  from t_bse_itemmultiunit_drug a
                                 where a.itemid_chr = ?
                                   and a.unit_vchr = ?
                                   and a.package_dec = ?
                                   and a.curruseflag_int = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strSeledMedId;
                ParamArr[1].Value = p_strUnit;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_intPackage_Dec;
                ParamArr[3].DbType = DbType.Int16;
                ParamArr[3].Value = p_CurruseFlag_Int;

                DataTable dtValue = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, ParamArr);
                if (dtValue != null && dtValue.Rows.Count > 0)
                {
                    blnIsFind = true;
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnIsFind;
        }
        #endregion

        #region 根据索引查询是否为当前使用单位
        /// <summary>
        /// 根据索引查询是否为当前使用单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">数量</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec)
        {
            bool blnIsFind = false;

            string strSQL = @"select a.itemid_chr,a.unit_vchr 
                                    from  t_bse_itemmultiunit_drug a
                                    where a.itemid_chr= ?
		                            and a.unit_vchr= ?
                                    and a.package_dec=?
                                    and a.curruseflag_int=1";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strSeledMedId;
                ParamArr[1].Value = p_strUnit;
                ParamArr[2].DbType = DbType.Int16;
                ParamArr[2].Value = p_intPackage_Dec;

                DataTable dtValue = new DataTable();
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtValue, ParamArr);
                if (dtValue != null && dtValue.Rows.Count > 0)
                {
                    blnIsFind = true;
                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnIsFind;
        }
        #endregion     

        #region 根据药品Id获取相应的收费项目ID
        /// <summary>
        /// 根据药品Id获取相应的收费项目ID
        /// </summary>
        /// <param name="p_strMedicineID">药品Id</param>
        /// <param name="p_strItemID">对应ChargeItemID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemID(string p_strMedicineID, out string p_strItemID)
        {
            p_strItemID = string.Empty;
            long lngRes = -1;
            DataTable p_dtbTemp = null;

            string strSQL = @"select a.itemid_chr from t_bse_chargeitem a where a.itemsrcid_vchr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strMedicineID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbTemp, ParamArr);
                if (p_dtbTemp != null && p_dtbTemp.Rows.Count > 0)
                {
                    p_strItemID = p_dtbTemp.Rows[0][0].ToString();
                }
                objHRPSvc.Dispose();
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
    }
}
