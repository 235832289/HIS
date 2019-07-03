using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存域控制类
    /// </summary>
    public class clsDcl_StorageSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 查询仓库信息
        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionStorageBse(out clsValue_StorageBse_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageBseData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionMedicineType(out clsValue_MedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetMedicineTypeData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据药房名称获取货架信息
        /// <summary>
        /// 根据药房名称获取货架信息
        /// </summary>
        /// <param name="p_strStoreName">药房名称</param>
        /// <param name="m_dtbStorageRack">货架信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageRack(string p_strStoreName, out DataTable m_dtbStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageRack(objPrincipal, p_strStoreName, out m_dtbStorageRack);
            return lngRes;
        }
        #endregion

        #region 保存货架设置
        /// <summary>
        /// 保存货架设置
        /// </summary>
        /// <param name="p_dicStorageRack">需要保存货架信息的记录</param>
        /// <returns></returns>
        internal long m_lngSaveStorageRack(Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveStorageRack(objPrincipal, p_dicStorageRack);
            return lngRes;
        }
        #endregion

        #region 保存数据
        internal long m_lngSaveStorageSet(DataTable m_dtbModify)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveStorageSet(objPrincipal, m_dtbModify);
            return lngRes;
        }
        #endregion

        #region 获取数据
        internal long m_mthGetStorageDetailData(string p_strStorageID, string p_strMedicineID, string p_strAssistCode, string p_strMedicineTypeID,
            out DataTable dtbResult,List<string> lstMedicineType,bool p_blnIsHospital)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageDataForSet(objPrincipal, p_strStorageID, p_strMedicineID, p_strAssistCode, p_strMedicineTypeID, lstMedicineType, p_blnIsHospital,ref dtbResult);
            return lngRes;
        }
        #endregion 
    }
}
