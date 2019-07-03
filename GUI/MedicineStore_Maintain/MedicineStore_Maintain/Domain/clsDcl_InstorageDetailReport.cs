using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsDcl_InstorageDetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdraw_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdraw_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdraw_Supported_SVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStorageID, out p_strStorageName);

            return lngRes;
        }
        #endregion

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_blnIsDrugStore">药房使用</param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(bool p_blnIsDrugStore,bool p_blnByStorageID,string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC));
            if (p_blnIsDrugStore)
            {
                if (p_blnByStorageID)
                {
                    lngRes = objSvc.m_lngGetBaseMedicineForDrugStoreByStorageID(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
                }
                else
                {
                    lngRes = objSvc.m_lngGetBaseMedicineForDrugStoreByDeptID(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
                }
            }
            else
            {
                lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            }
            return lngRes;
        }
        #endregion

        #region 获取供应商
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="p_dtbVendor">供应商数据</param>
        /// <returns></returns>
        internal long m_lngGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetVendor(objPrincipal, out p_dtbVendor);
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

        #region 获取入库明细（打印）
        /// <summary>
        /// 获取入库明细（打印）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strVendor">供应商ID</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">入库类型ID</param>        
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetailReport(bool p_blnCombine,string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendor,string p_strMedType, string p_strMedicine, string p_strType, out DataTable p_dtbReport)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC));
            lngRes = objSvc.m_lngGetInstorageDetailReport(objPrincipal, p_blnCombine,p_strStorageID, p_dtmBegin, p_dtmEnd, p_strVendor, p_strMedType, p_strMedicine, p_strType, out p_dtbReport);
            return lngRes;
        }
        #endregion 

        /// <summary>
        /// 入库报表
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="InstorageID">仓库号</param>
        /// <param name="Instoragetype">类型</param>
        /// <param name="dtmBegin">开始时间</param>
        /// <param name="dtmEnd">结束时间</param>
        /// <param name="strMedID">药品ID</param>
        /// <param name="strMedType">药品类型</param>
        /// <param name="strProduct">厂家</param>
        /// <param name="p_strBidYear">中标年份</param>        
        /// <param name="p_strBidYear2">非中标年份</param>
        /// <param name="dtResult">结果</param>
        /// <returns></returns>
        internal long m_lngRptInstorage(bool p_blnCombine,string InstorageID, string Instoragetype, DateTime dtmBegin, DateTime dtmEnd, string strMedID,
                                      string strMedType, string strProduct, string p_strBidYear,string p_strBidYear2,out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC));
            lngRes = objSvc.m_lngRptInstorage(p_blnCombine,InstorageID, Instoragetype, dtmBegin, dtmEnd, strMedID, strMedType, strProduct, p_strBidYear,p_strBidYear2, out dtResult);
            return lngRes;
        }

        #region 药房入库统计报表（按类型）
        /// <summary>
        /// 药房入库统计报表（按类型）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="InstorageID">仓库号</param>
        /// <param name="Instoragetype">类型</param>
        /// <param name="dtmBegin">开始时间</param>
        /// <param name="dtmEnd">结束时间</param>
        /// <param name="strMedID">药品ID</param>
        /// <param name="strMedType">药品类型</param>
        /// <param name="strProduct">厂家</param>
        /// <param name="p_blnIsHospital">是否住院药房使用</param>
        /// <param name="dtResult">结果</param>
        /// <returns></returns>
        internal long m_lngGetDrugStoreInstorageStat(bool p_blnCombine,string InstorageID, string Instoragetype, DateTime dtmBegin, DateTime dtmEnd, string strMedID,
                                      string strMedType, string strProduct,bool p_blnIsHospital,out DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReport_Supported_SVC));
            lngRes = objSvc.m_lngGetDrugStoreInstorageStat(p_blnCombine,InstorageID, Instoragetype, dtmBegin, dtmEnd, strMedID, strMedType, strProduct,p_blnIsHospital, out dtResult);
            return lngRes;
        }
        #endregion

        internal long m_lngGetTypeNameByID(int p_intFlag, string p_strInType, out string m_strTypeName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetTypeNameByID(objPrincipal, p_intFlag, p_strInType, out m_strTypeName);
            return lngRes;
        }

        internal long m_lngGetDeptIDForStore(string m_strStorageID, out string m_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptIDForStore(objPrincipal, m_strStorageID, out m_strDeptID);
            return lngRes;
        }

        internal long m_lngGetDrugStoreName(string m_strStorageID, out string m_strRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetDrugStoreRoomName(objPrincipal, m_strStorageID, out m_strRoomName);
            return lngRes;
        }

        #region 获取入库明细（打印）（药房使用）
        /// <summary>
        /// 获取入库明细（打印）（药房使用）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strVendor">供应商ID</param>
        /// <param name="p_strMedTypeCode">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_strType">入库类型ID</param>  
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetailReportForDrugStore(bool p_blnCombine,string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendor, string p_strMedTypeCode,string p_strMedicine, string p_strType, bool p_blnIsHospital,out DataTable p_dtbReport)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC));
            lngRes = objSvc.m_lngGetInstorageDetailReportForDrugStore(objPrincipal, p_blnCombine,p_strStorageID, p_dtmBegin, p_dtmEnd, p_strVendor, p_strMedTypeCode, p_strMedicine, p_strType,p_blnIsHospital, out p_dtbReport);
            return lngRes;
        }
        #endregion 
    
        #region 获取领用部门
        /// <summary>
        /// 获取领用部门
        /// </summary>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        internal long m_lngGetExportDept(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_mthGetExportDept(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion

        internal long m_lngGetDeptIDByStoreID(string p_strInstorageType, out string p_strDeptId)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptIDForStore(objPrincipal, p_strInstorageType, out p_strDeptId);
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

        internal long m_lngGetStoreName(string m_strStorageID, out string m_strRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageRoomName(objPrincipal, m_strStorageID, out m_strRoomName);
            return lngRes;
        }

        /// <summary>
        /// 检查是否住院药房使用
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <returns></returns>
        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckIsHospital(objPrincipal, p_strDrugStoreID, out p_blnIsHospital);
            return lngRes;
        }
    }
}
