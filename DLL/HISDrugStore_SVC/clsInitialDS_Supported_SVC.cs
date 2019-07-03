using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房库存初始化
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsInitialDS_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药房初始化药品信息
        /// <summary>
        /// 获取药房初始化药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugStoreID">药房ID（对应部门ID）</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetInitilaMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugStoreID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            if (string.IsNullOrEmpty(p_strDrugStoreID))
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = "";
                if (p_blnIsHospital)
                {
                    strSQL = @"select a.seriesid_int,
       a.drugstoreid_chr,
       a.medicineid_chr,
       a.medicinename_vchr,
       a.medspec_vchr,
       a.ipamount,
       a.ipunit_chr,
       a.opamount,
       a.opunit_chr,
       a.packqty_dec,
       a.ipretailprice_int,
       a.opretailprice_int,
       a.ipwholesaleprice_int,
       a.opwholesaleprice_int,
       a.validperiod_dat,
       a.lotno_vchr,
       a.createrid,
       a.examerid,
       a.inaccounterid_chr,
       a.initialid_chr,
       a.productorid_chr,
       m.assistcode_chr,
       m.medicinetypeid_chr,
       b.empno_chr createrno,
       b.lastname_vchr creatername,
       c.empno_chr examerno,
       c.lastname_vchr examername,
       case
         when m.ipchargeflg_int = 0 then
          a.opamount
         else
          a.ipamount
       end as amount,
       case
         when m.ipchargeflg_int = 0 then
          a.opunit_chr
         else
          a.ipunit_chr
       end as unit_chr,
       case
         when m.ipchargeflg_int = 0 then
          a.opretailprice_int
         else
          a.ipretailprice_int
       end as retailprice_int,
       case
         when m.ipchargeflg_int = 0 then
          a.opwholesaleprice_int
         else
          a.ipwholesaleprice_int
       end as wholesaleprice_int,
       m.opchargeflg_int,
       m.ipchargeflg_int
  from t_ds_initial a
 inner join t_bse_medicine m on a.medicineid_chr = m.medicineid_chr
	left outer join t_bse_employee b on a.createrid = b.empid_chr
																	and b.status_int = 1
	left outer join t_bse_employee c on a.examerid = c.empid_chr
																	and c.status_int = 1
 where a.drugstoreid_chr = ?
 order by a.seriesid_int";
                }
                else
                {
                    strSQL = @"select a.seriesid_int,
			 a.drugstoreid_chr,
			 a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.ipamount,
			 a.ipunit_chr,
			 a.opamount,
			 a.opunit_chr,
			 a.packqty_dec,
			 a.ipretailprice_int,
			 a.opretailprice_int,
			 a.ipwholesaleprice_int,
			 a.opwholesaleprice_int,
			 a.validperiod_dat,
			 a.lotno_vchr,
			 a.createrid,
			 a.examerid,
			 a.inaccounterid_chr,
			 a.initialid_chr,
			 a.productorid_chr,
			 m.assistcode_chr,
			 m.medicinetypeid_chr,
			 b.empno_chr createrno,
			 b.lastname_vchr creatername,
			 c.empno_chr examerno,
			 c.lastname_vchr examername,
			 case
				 when m.opchargeflg_int = 0 then
					a.opamount
				 else
					a.ipamount
			 end as amount,
			 case
				 when m.opchargeflg_int = 0 then
					a.opunit_chr
				 else
					a.ipunit_chr
			 end as unit_chr,
			 case
				 when m.opchargeflg_int = 0 then
					a.opretailprice_int
				 else
					a.ipretailprice_int
			 end as retailprice_int,
			 case
				 when m.opchargeflg_int = 0 then
					a.opwholesaleprice_int
				 else
					a.ipwholesaleprice_int
			 end as wholesaleprice_int,
			 m.opchargeflg_int,
             m.ipchargeflg_int            
	from t_ds_initial a
 inner join t_bse_medicine m on a.medicineid_chr = m.medicineid_chr
	left outer join t_bse_employee b on a.createrid = b.empid_chr
																	and b.status_int = 1
	left outer join t_bse_employee c on a.examerid = c.empid_chr
																	and c.status_int = 1
 where a.drugstoreid_chr = ?
 order by a.seriesid_int";
                }
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDrugStoreID;

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

        #region 检查库存主表是否已存在该药
        /// <summary>
        /// 检查库存主表是否已存在该药
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasStorage(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedicineID, string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            p_lngSeriesID = 0;
            p_blnHasDetail = false;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strMedicineID) || string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }
            try
            {
                string strSQL = @"select seriesid_int from t_ds_storage where medicineid_chr = ? and drugstoreid_chr = ?";
                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strMedicineID;
                objDPArr[1].Value = p_strStorageID;

                DataTable dtbValue = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbValue, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtbValue != null && dtbValue.Rows.Count > 0)
                {
                    p_blnHasDetail = true;
                    p_lngSeriesID = Convert.ToInt64(dtbValue.Rows[0][0]);
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

        #region 获取药房信息
        /// <summary>
        /// 获取药房信息
        /// </summary>
        /// <param name="m_strDrugStoreID">药房ID</param>
        /// <param name="m_strStoreName">药房名称</param>
        /// <param name="m_strDeptID">对应的部门ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStoreInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugStoreID, out string p_strStoreName, out string p_strDeptID)
        {
            p_strStoreName = string.Empty;
            p_strDeptID = string.Empty;
            if (string.IsNullOrEmpty(p_strDrugStoreID))
            {
                return -1;
            }

            long lngRes = -1;
            DataTable p_dtbMedicine = new DataTable();
            try
            {
                string strSQL = @"select medstorename_vchr,deptid_chr from t_bse_medstore where medstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDrugStoreID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine.Rows.Count > 0)
                {
                    p_strStoreName = p_dtbMedicine.Rows[0]["medstorename_vchr"].ToString();
                    p_strDeptID = p_dtbMedicine.Rows[0]["deptid_chr"].ToString();
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

        #region 是否已存在结转记录

        /// <summary>
        /// 是否已存在结转记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_blnHasAccountPeriod">是否</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckHasAccount(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out bool p_blnHasAccountPeriod)
        {
            p_blnHasAccountPeriod = false;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }
            DataTable dtResult = new DataTable();
            long lngRes = 0;

            try
            {
                string strSQL = @" select count(*) from t_ds_accountperiod a where a.drugstoreid_chr = ?";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_blnHasAccountPeriod = Convert.ToInt32(dtResult.Rows[0][0]) > 0;
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
