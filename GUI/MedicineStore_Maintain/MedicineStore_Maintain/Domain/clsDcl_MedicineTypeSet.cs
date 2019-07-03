using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品类型设置
    /// </summary>
    public class clsDcl_MedicineTypeSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品类型设置信息
        /// <summary>
        /// 获取药品类型设置信息
        /// </summary>
        /// <param name="p_objTypeVO">药品类型设置信息</param>
        /// <returns></returns>
        internal long m_lngGetAllMedicinTypeSetInfo(out clsMS_MedicineTypeSetVO[] p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngGetAllMedicinTypeSetInfo(objPrincipal, out p_objTypeVO);
            return lngRes;
        }

        /// <summary>
        /// 获取药品类型设置信息
        /// </summary>
        /// <param name="p_intSetID">设置ID</param>
        /// <param name="p_objTypeVO">药品类型</param>
        /// <returns></returns>
        internal long m_lngGetMedicinTypeSetInfo(int p_intSetID,out clsMS_MedicineType_VO[] p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngGetMedicinTypeSetInfo(objPrincipal, p_intSetID, out p_objTypeVO);
            return lngRes;
        } 
        #endregion

        #region 添加药品类型设置
        /// <summary>
        /// 添加药品类型设置
        /// </summary>
        /// <param name="p_objTypeVO">药品类型设置</param>
        /// <returns></returns>
        internal long m_lngAddNewMedicneTypeSet(clsMS_MedicineTypeSetVO p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngAddNewMedicneTypeSet(objPrincipal, p_objTypeVO);
            return lngRes;
        }  
        #endregion

        #region 修改药品类型设置
        /// <summary>
        /// 修改药品类型设置
        /// </summary>
        /// <param name="p_objTypeVO">药品类型设置</param>
        /// <returns></returns>
        internal long m_lngModifyMedicineTypeSet(clsMS_MedicineTypeSetVO p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngModifyMedicineTypeSet(objPrincipal, p_objTypeVO);
            return lngRes;
        }  
        #endregion

        #region 删除指定药品类型设置
        /// <summary>
        /// 删除指定药品类型设置
        /// </summary>
        /// <param name="p_intSetID">设置ID</param>
        /// <returns></returns>
        internal long m_lngDeleteMedicineTypeSet(int p_intSetID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngDeleteMedicineTypeSet(objPrincipal, p_intSetID);
            return lngRes;
        }
        #endregion

        #region 检查指定药品类型是否已设置至其它大类
        /// <summary>
        /// 检查指定药品类型是否已设置至其它大类
        /// </summary>
        /// <param name="p_strTypeID">药品基本类型ID</param>
        /// <param name="p_strSetName">若已设置，些返回已设置的大类名称</param>
        /// <returns></returns>
        internal long m_lngCheckHasSetOtherType(string p_strTypeID, out string p_strSetName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeSetSVC));
            lngRes = objSvc.m_lngCheckHasSetOtherType(objPrincipal, p_strTypeID, out p_strSetName);
            return lngRes;
        }
        #endregion
    }
}
