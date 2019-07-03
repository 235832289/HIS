using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库明细报表
    /// </summary>
    public class clsDcl_OutStorageDetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取领用部门
        /// <summary>
        /// 获取领用部门
        /// </summary>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        internal long m_lngGetExportDept(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetExportDept(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 出库明细报表
        /// <summary>
        /// 出库明细报表(未指定科室及药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutStorageDetailReport(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutStorageDetailReport(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表查询内退(未指定科室及药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">内退明细内容</param>
        /// <returns></returns>
        public long m_lngOutReportGetWithinWithdrawal(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutReportGetWithinWithdrawal(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表(只指定科室)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutStorageDetailReport_Dept(string p_strStorageID, string p_strAskDeptID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutStorageDetailReport_Dept(objPrincipal, p_strStorageID,p_strAskDeptID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表查询内退(只指定科室)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutReportGetWithinWithdrawal_Dept(string p_strStorageID, string p_strAskDeptID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutReportGetWithinWithdrawal_Dept(objPrincipal, p_strStorageID, p_strAskDeptID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表(只指定药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutStorageDetailReport_Med(string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutStorageDetailReport_Med(objPrincipal, p_strStorageID, p_strMedicineID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表查询内退(只指定药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutReportGetWithinWithdrawal_Med(string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutReportGetWithinWithdrawal_Med(objPrincipal, p_strStorageID, p_strMedicineID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表(指定科室及药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutStorageDetailReport_Dept_Med(string p_strStorageID, string p_strAskDeptID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutStorageDetailReport_Dept_Med(objPrincipal, p_strStorageID,p_strAskDeptID, p_strMedicineID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }

        /// <summary>
        /// 出库明细报表查询内退(指定科室及药品)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAskDeptID">请领科室ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_dtbOutDetail">出库明细内容</param>
        /// <returns></returns>
        public long m_lngOutReportGetWithinWithdrawal_Dept_Med(string p_strStorageID, string p_strAskDeptID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable p_dtbOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngOutReportGetWithinWithdrawal_Dept_Med(objPrincipal, p_strStorageID, p_strAskDeptID, p_strMedicineID, p_dtmBegin, p_dtmEnd, out p_dtbOutDetail);
            return lngRes;
        }
        #endregion

        #region 获取仓库名称
        /// <summary>
        /// 获取仓库名称
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strStorageName"></param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStorageID, out string p_strStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStorageID, out p_strStorageName);

            return lngRes;
        }
        #endregion

        #region 获取类型和厂家
        
        internal long m_lngGetExptypeAndVendor(bool p_blnForDrugStore, out DataTable dtExp, out DataTable dtVendor, out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngGetExptypeAndVendor(p_blnForDrugStore, out dtExp, out dtVendor, out dtMedType);
            return lngRes;
        }
        #endregion

        #region 药房出库统计
        /// <summary>
        /// 药房出库统计
        /// </summary>
        /// <param name="p_blnCombine">查询单品种</param>
        /// <param name="Medid"></param>
        /// <param name="Typecode"></param>
        /// <param name="Medicinetype"></param>
        /// <param name="Storageid"></param>
        /// <param name="VendorName"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreOutstorageStat(bool p_blnCombine, string Medid, string Typecode, string Medicinetype, string Storageid, string VendorName,
                                DateTime BeginDate, DateTime EndDate, bool p_blnIsHospital, out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngGetDrugStoreOutstorageStat(p_blnCombine, Medid, Typecode, Medicinetype, Storageid, VendorName, BeginDate, EndDate, p_blnIsHospital, out dtResult);
            return lngRes;
        }
        #endregion

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_blnCombine"></param>
        /// <param name="Medid"></param>
        /// <param name="Typecode"></param>
        /// <param name="Medicinetype"></param>
        /// <param name="Storageid"></param>
        /// <param name="VendorName"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngOutstorageStat(bool p_blnCombine, string Medid, string Typecode, string Medicinetype, string Storageid, string VendorName,
                        DateTime BeginDate, DateTime EndDate, out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngOutstorageStat(p_blnCombine, Medid, Typecode, Medicinetype, Storageid, VendorName, BeginDate, EndDate, out dtResult);
            return lngRes;
        }
        #endregion

        #region 获取出入库类型信息表
        public long m_mthGetImpExpTypeInfo(out DataTable m_dtImpExpType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_mthGetImpExpTypeInfo(objPrincipal, out m_dtImpExpType);
            return lngRes;
        }
        #endregion

        #region 合计金额
        public long m_lngOutStorageSumMoney(DateTime BeginDate, DateTime EndDate, string MedStorgeID, string DeptID, string MedTypeID, out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngOutStorageSumMoney(BeginDate, EndDate, MedStorgeID, DeptID, MedTypeID, out dtResult);
            return lngRes;
        }
        #endregion

        #region 获取类型名称
        internal long m_lngGetTypeNameByID(int p_intFlag, string p_stroutType, out string m_strTypeName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetTypeNameByID(objPrincipal, p_intFlag, p_stroutType, out m_strTypeName);
            return lngRes;
        }
        #endregion


        public long m_lngGetMedStroge(out DataTable dtExp)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngGetMedStroge(false, out dtExp);
            return lngRes;
        }


        internal long m_lngGetRoomid(out DataTable dtTemp)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC));
            lngRes = objSvc.m_lngGetRoomid(out dtTemp);
            return lngRes;
        }

        public long m_lngGetMedType(out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStat_Supported_Svc));
            lngRes = objSvc.m_lngGetMedType(false, out dtMedType);
            return lngRes;
        }

    }
}
