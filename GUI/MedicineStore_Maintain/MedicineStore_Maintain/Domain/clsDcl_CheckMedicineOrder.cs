using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 盘点药品顺序设置
    /// </summary>
    public class clsDcl_CheckMedicineOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取货架
        /// <summary>
        /// 获取货架
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intType">库房类型(1,药库 2,药房)</param>
        /// <param name="p_dtbDate">获取数据</param>
        /// <returns></returns>
        internal long m_lngGetStoragePack(string p_strStorageID, int p_intType, out DataTable p_dtbDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoragePack(objPrincipal, p_strStorageID, p_intType, out p_dtbDate);
            return lngRes;
        }
        #endregion

        #region 获取药库是否存在货架设置
        /// <summary>
        /// 获取药库是否存在货架设置
        /// </summary>
        /// <param name="p_intHasPack">0不存在 1存在</param>
        /// <returns></returns>
        internal long m_lngGetHasStoragePack(out int p_intHasPack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5008", out p_intHasPack);
            return lngRes;
        }
        #endregion

        #region 获取盘点药品顺序
        /// <summary>
        /// 获取盘点药品顺序
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strStoragePackID">货架ID</param>
        /// <param name="p_dtbData">数据</param>
        /// <returns></returns>
        internal long m_lngGetCheckMedicineOrder(string p_strStorageID, string p_strStoragePackID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngGetCheckMedicineOrder(objPrincipal, p_strStorageID, p_strStoragePackID, out p_dtbData);
            return lngRes;
        }

        /// <summary>
        /// 获取盘点药品顺序
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbData">数据</param>
        /// <returns></returns>
        internal long m_lngGetCheckMedicineOrderWithoutPack(string p_strStorageID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngGetCheckMedicineOrderWithoutPack(objPrincipal, p_strStorageID, out p_dtbData);
            return lngRes;
        }
        #endregion

        #region 新添盘点药品顺序
        /// <summary>
        /// 新添盘点药品顺序
        /// </summary>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        internal long m_lngAddNewCheckMedicineOrder(clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngAddNewCheckMedicineOrder(objPrincipal, p_objOrderArr);
            return lngRes;
        } 
        #endregion

        #region 修改盘点药品顺序
        /// <summary>
        /// 修改盘点药品顺序
        /// </summary>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        internal long m_lngModifyCheckOrder(clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngModifyCheckOrder(objPrincipal, p_objOrderArr);
            return lngRes;
        }

        /// <summary>
        /// 修改盘点药品顺序(无货架)
        /// </summary>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        internal long m_lngModifyCheckOrderWithoutPack(clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngModifyCheckOrderWithoutPack(objPrincipal, p_objOrderArr);
            return lngRes;
        }
        #endregion

        #region 删除盘点药品顺序
        /// <summary>
        /// 删除盘点药品顺序
        /// </summary>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        internal long m_lngDeleteMedicineOrder(clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngDeleteMedicineOrder(objPrincipal, p_objOrderArr);
            return lngRes;
        } 
     

        /// <summary>
        /// 删除盘点药品顺序(无货架)
        /// </summary>
        /// <param name="p_objOrderArr">盘点药品顺序</param>
        /// <returns></returns>
        internal long m_lngDeleteMedicineOrderWithoutPack(clsMS_CheckMedicineOrderVO[] p_objOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsCheckMedicineOrderSVC));
            lngRes = objSvc.m_lngDeleteMedicineOrderWithoutPack(objPrincipal, p_objOrderArr);
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
    }
}
