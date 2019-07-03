using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.MedicineStoreService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 药品明细查询/逻辑控制层  王勇  2007-4-2
    /// <summary>
    /// 逻辑控制层

    /// </summary>
    class clsDomainController_StorageDetailQuery : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数

        public clsDomainController_StorageDetailQuery()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
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
        internal long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, "", p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion


        #region 查询药品信息说明

        public long m_lngGetResultByConditionMedicineBse(out clsValue_MedicineBse_VO[] p_objResultArr)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngGetMedicineBseData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion


        #region 查询库存明细信息	根据条件

        public long m_lngGetResultByConditionStorageDetail(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param,bool p_blnAccount,List<string> lstMedicineType ,ref DataTable dtbResult)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngGetStorageDetailData(objPrincipal, p_blnAccount,ref objvalue_Param,lstMedicineType, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 查询药品类型信息

        public long m_lngGetResultByConditionMedicineType(out clsValue_MedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngGetMedicineTypeData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion


        #region 查询仓库信息说明

        public long m_lngGetResultByConditionStorageBse(out clsValue_StorageBse_VO[] p_objResultArr)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngGetStorageBseData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据药库名称获取货架信息
        /// <summary>
        /// 根据药库名称获取货架信息
        /// </summary>
        /// <param name="p_strStoreName">药库名称</param>
        /// <param name="m_dtbStorageRack">货架信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageRack(string p_strStoreName, out DataTable m_dtbStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngSaveStorageRack(objPrincipal, p_dicStorageRack);
            return lngRes;
        }
        #endregion

        #region 保存可供标志
        /// <summary>
        /// 保存可供标志
        /// </summary>
        /// <param name="m_dicStorageProvide"></param>
        /// <returns></returns>
        internal long m_lngSaveStorageProvide(Dictionary<string, string> m_dicStorageProvide)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddleTier_StorageDetailQuerySVC));

            lngRes = objSvc.m_lngSaveStorageProvide(objPrincipal, m_dicStorageProvide);
            return lngRes;
        }
        #endregion
    }
    #endregion
}
