using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 期初数录入
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsInventoryRecord_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strAssistCode == null)
            {
                p_strAssistCode = string.Empty;
            }

            try
            {
                //nvl()加这函数，防止漏了数据
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
			 0 currentgross_num,
			 nvl(b.itemname_vchr,'') as aliasname_vchr,
			 nvl(b.pycode_vchr,'') as aliaspycode_vchr,
			 nvl(b.wbcode_vchr,'') as aliaswbcode_vchr
	from t_bse_medicine t
	left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
	left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
																	and b.status_int = 1
																	and b.flag_int = 1
 where t.assistcode_chr like ? and t.deleted_int=0";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode,string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

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
			 0 currentgross_num,
			 nvl(b.itemname_vchr,'') as aliasname_vchr,
			 nvl(b.pycode_vchr,'') as aliaspycode_vchr,
			 nvl(b.wbcode_vchr,'') as aliaswbcode_vchr
	from t_bse_medicine t
	left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
	left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
																	and b.status_int = 1
																	and b.flag_int = 1
 where t.assistcode_chr like ? and t.deleted_int=0
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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
        /// 获取药品最基本信息(带库存信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineWithGross(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

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
			 s.currentgross_num,
			 nvl(b.itemname_vchr,'') as aliasname_vchr,
			 nvl(b.pycode_vchr,'') as aliaspycode_vchr,
			 nvl(b.wbcode_vchr,'') as aliaswbcode_vchr
	from t_bse_medicine t
	left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
	left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
																	and b.status_int = 1
																	and b.flag_int = 1
	left join t_ms_storage s on s.medicineid_chr = t.medicineid_chr
													and s.storageid_chr = ?
 where t.assistcode_chr like ? and t.deleted_int=0
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAssistCode + "%";
                objDPArr[2].Value = p_strStorageID;

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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
        /// 获取可用数大于0药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineNotZero(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID,out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

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
			 a.currentgross_num,
       nvl(b.itemname_vchr,'') as aliasname_vchr,
       nvl(b.pycode_vchr,'') as aliaspycode_vchr,
       nvl(b.wbcode_vchr,'') as aliaswbcode_vchr
	from t_bse_medicine t
	left join t_ms_storage a on a.medicineid_chr = t.medicineid_chr
    left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
    left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
    where t.assistcode_chr like ? and t.deleted_int=0
	 and exists (select r.medicineroomid
					from t_ms_medicinestoreroomset r
				 where r.medicinetypeid_chr = t.medicinetypeid_chr
					 and r.medicineroomid = ?
					 and a.storageid_chr = ?)
	 and a.currentgross_num > 0
 order by t.assistcode_chr";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strAssistCode + "%";
                objDPArr[1].Value = p_strStorageID;
                objDPArr[2].Value = p_strStorageID;

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

        #region 获取药房药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineForDrugStoreByDeptID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

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
       d.ifstop_int,
       0 currentgross_num,
       nvl(b.itemname_vchr, '') as aliasname_vchr,
       nvl(b.pycode_vchr, '') as aliaspycode_vchr,
       nvl(b.wbcode_vchr, '') as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
  left join t_bse_medstore c on c.deptid_chr = ?
  left join t_ds_storage d on d.medicineid_chr = t.medicineid_chr
                          and d.drugstoreid_chr = c.deptid_chr
 where t.assistcode_chr like ?
   and t.deleted_int = 0
   and exists (select medicinetypeid_chr
          from t_ds_medstoreset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medstoreid = c.medstoreid_chr)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAssistCode + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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
        #region 获取药房药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetBaseMedicineForDrugStoreByStorageID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            long lngRes = 0;
            if (p_strStorageID == null)
            {
                return -1;
            }

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
       d.ifstop_int,
       0 currentgross_num,
       nvl(b.itemname_vchr, '') as aliasname_vchr,
       nvl(b.pycode_vchr, '') as aliaspycode_vchr,
       nvl(b.wbcode_vchr, '') as aliaswbcode_vchr
  from t_bse_medicine t
  left join t_bse_chargeitem a on t.medicineid_chr = a.itemsrcid_vchr
  left join t_bse_itemalias_drug b on a.itemid_chr = b.itemid_chr
                                  and b.status_int = 1
                                  and b.flag_int = 1
  left join t_bse_medstore c on c.medstoreid_chr = ?
  left join t_ds_storage d on d.medicineid_chr = t.medicineid_chr
                          and d.drugstoreid_chr = c.deptid_chr
 where t.assistcode_chr like ?
   and t.deleted_int = 0
   and exists (select medicinetypeid_chr
          from t_ds_medstoreset r
         where r.medicinetypeid_chr = t.medicinetypeid_chr
           and r.medstoreid = c.medstoreid_chr)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strStorageID;
                objDPArr[1].Value = p_strAssistCode + "%";

                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref p_dtbMedicine, objDPArr);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (p_dtbMedicine != null && p_dtbMedicine.Rows.Count > 0)
                {
                    DataView dvResult = p_dtbMedicine.DefaultView;
                    dvResult.Sort = "assistcode_chr";
                    p_dtbMedicine = dvResult.ToTable();
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

        #region 获取已录入药品信息
        /// <summary>
        /// 获取已录入药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedicineDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            p_dtbMedicine = null;
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                string strSQL = @"select a.seriesid_int seriesid,
       a.medicineid_chr medicineid,
       a.medicinename_vch medicinename,
       a.medspec_vchr medicinespec,
       a.currentgross_num storeamount,
       a.retailprice_int saleunitprice,
       a.wholesaleprice_int wholesaleunitprice,
       a.callprice_int bugunitprice,
       a.vendorid_chr supplierid,
       a.productorid_chr manufacturer,
       a.validperiod_dat validity,
       b.assistcode_chr medicinecode,
       b.medicinetypeid_chr,
       a.opunit_vchr medicineunit,
        case
        when a.lotno_vchr = 'UNKNOWN' then
         ''
        else
            a.lotno_vchr
        end  batchnumber,
       a.createrid,
       c.empno_chr createrno,
       c.lastname_vchr creatername,
       a.examerid,
       d.empno_chr examerno,
       d.lastname_vchr examername,
       case
         when examerid is null then
          '未审核'
         when inaccounterid_chr is not null then
          '已入帐'
         else
          '已审核'
       end status,
       e.vendorname_vchr suppliername,
       a.inaccounterid_chr,
       a.initialid_chr,
       f.lotno_int,
       f.validperiod_int
  from t_ms_initial a
 inner join t_bse_medicine b on a.medicineid_chr = b.medicineid_chr
 inner join t_bse_employee c on a.createrid = c.empid_chr
  left outer join t_bse_vendor e on e.vendorid_chr = a.vendorid_chr
  left outer join t_bse_employee d on a.examerid = d.empid_chr
  left outer join t_ms_medicinetypevisionmset f on b.medicinetypeid_chr = f.medicinetypeid_vchr
 where a.storageid_chr = ?
  order by a.seriesid_int";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strStorageID;

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

        #region 是否存在记录，整张初始化只有一个单据号
        /// <summary>
        ///  是否存在记录，整张初始化只有一个单据号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strInitialID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckExistsInitialID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, out string p_strInitialID)
        {
            p_strInitialID = string.Empty;
            long lngRes = 0;
            DataTable dtTemp = null;
            string strSQL = @"select initialid_chr
	from (select a.initialid_chr
					from t_ms_initial a
				 where a.storageid_chr = ?
				 order by a.seriesid_int)
 where rownum = 1";
            try
            {

                clsHRPTableService objHRPServ = new clsHRPTableService();
                System.Data.IDataParameter[] objParm = null;
                objHRPServ.CreateDatabaseParameter(1, out objParm);
                objParm[0].Value = p_strStorageID;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtTemp, objParm);
                objHRPServ.Dispose();
                objHRPServ = null;
                if (lngRes > 0 && dtTemp.Rows.Count == 1)
                {
                    p_strInitialID = dtTemp.Rows[0][0].ToString();
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
        /// <param name="p_strStorageID">药库ID</param>
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
                string strSQL = @"select count(*) from t_ms_accountperiod a where a.storageid_chr = ?";

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
