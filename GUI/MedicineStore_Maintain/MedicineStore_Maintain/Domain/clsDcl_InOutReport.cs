using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsDcl_InOutReport : com.digitalwave.GUI_Base.clsDomainController_Base
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
        public long m_lngGetBaseMedicine(bool p_blnIsDrugStore,string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecord_Supported_SVC));
            if (p_blnIsDrugStore)
            {
                lngRes = objSvc.m_lngGetBaseMedicineForDrugStoreByStorageID(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            }
            else
            {
                lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            }
            return lngRes;
        }
        #endregion


        #region 获取出入库情况（药库）
        /// <summary>
        /// 获取出入库情况（药库）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strMedType">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_intFilter">过滤</param>        
        /// <param name="p_blnShowNoAmount">是否显示零库存</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        internal long m_lngGetInOutDetail(bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strMedType, string p_strMedicine, int p_intFilter,bool p_blnShowNoAmount, out DataTable p_dtbReport)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC));
            lngRes = objSvc.m_lngGetInOutDetail(objPrincipal, p_blnCombine, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strMedType, p_strMedicine, p_intFilter,p_blnShowNoAmount, out p_dtbReport);
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

        #region 获取出入库情况（药房使用）
        /// <summary>
        /// 获取出入库情况（药房使用）
        /// </summary>
        /// <param name="p_blnCombine">是否单品种查询</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始时间</param>
        /// <param name="p_dtmEnd">结束时间</param>
        /// <param name="p_strMedTypeCode">药品类型</param>
        /// <param name="p_strMedicine">药品ID</param>
        /// <param name="p_intFilter">入库类型ID</param>
        /// <param name="p_blnShowNoAmount">是否显示零库存</param>
        /// <param name="p_dtbReport">入库明细数据</param>
        /// <returns></returns>
        internal long m_lngGetInOutDetailForDrugStore(bool p_blnCombine, string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strMedTypeCode, string p_strMedicine, int p_intFilter,bool p_blnShowNoAmount, out DataTable p_dtbReport)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorage_Supported_MS_SVC));
            lngRes = objSvc.m_lngGetInOutDetailForDrugStore(objPrincipal, p_blnCombine,p_strStorageID, p_dtmBegin, p_dtmEnd,  p_strMedTypeCode, p_strMedicine,p_intFilter,p_blnShowNoAmount, out p_dtbReport);
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
    }
}
