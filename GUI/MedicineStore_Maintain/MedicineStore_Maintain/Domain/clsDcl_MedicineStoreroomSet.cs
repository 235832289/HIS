using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;


namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 库存设置,从中间件获取数据.
    /// </summary>
    public class clsDcl_MedicineStoreroomSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取仓库类型信息.
        /// <summary>
        /// 获取仓库类型信息.
        /// </summary>
        /// <param name="p_MedicineStoreArr">返回结果.</param>
        /// <returns></returns>
        internal long m_lngGetMedicineStoreInfo(out clsMS_MedicineStoreroom_VO[] p_MedicineStoreArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineStoreroomInfo(objPrincipal, out p_MedicineStoreArr);
            return lngRes;
        }
        #endregion

        #region 获取指定仓库已设置的药品类型.
        /// <summary>
        /// 获取指定仓库已设置的药品类型
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库</param>
        /// <param name="p_objType">药品类型</param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomSetCheck(string p_strStoreRoomID, out clsMS_MedicineType_VO[] p_objType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreRoomSetCheck(objPrincipal, p_strStoreRoomID, out p_objType);
            return lngRes;
        }
        #endregion
        #region 获取指定药房已设置的药品类型ID
        /// <summary>
        ///  获取指定药房已设置的药品类型ID
        /// </summary>
        /// <param name="p_strStoreRoomID">药房</param>
        /// <param name="p_objType">药品类型</param>
        /// <returns></returns>
        public long m_lngGetMedStoreSetCheck(string p_strStoreRoomID, out clsMS_MedicineType_VO[] p_objType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC));
            lngRes = objSvc.m_lngGetMedStoreSetCheck(objPrincipal, p_strStoreRoomID, out p_objType);
            return lngRes;
        }
#endregion
        #region 获取药品类型信息.
        /// <summary>
        /// 获取药品类型信息.
        /// </summary>
        /// <param name="p_dtbMedicine">返回结果.</param>
        /// <returns></returns>
        internal long m_lngGetMedicineInfo(out clsMS_MedicineType_VO[] p_objMedicineType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfo(objPrincipal, out p_objMedicineType);
            return lngRes;
        }
        #endregion

        #region 添加库存记录.

        /// <summary>
        ///  添加库存记录.
        /// </summary>
        /// <param name="p_objMedicineStoreArr">新增库房记录.</param>
        /// <returns></returns>
        internal long m_lngInsertMedicineStoreInfo(ref clsMS_MedicineStoreroom_VO p_objMedicineStore)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC objSvc = 
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC));
            lngRes = objSvc.m_lngAddNewMedicineStoreInfo(objPrincipal, ref p_objMedicineStore);
            return lngRes;
        }
        #endregion
        #region 添加库房记录.

        /// <summary>
        /// 添加库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineStoreroom">新增库房记录.</param>
        /// <returns></returns>
        public long m_lngAddNewMedStoreSetInfo(ref clsMS_MedicineStoreroom_VO p_objMedicineStoreroom)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC));
            lngRes = objSvc.m_lngAddNewMedStoreSetInfo(objPrincipal, ref p_objMedicineStoreroom);
            return lngRes;
        }
           #endregion
        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="strStoreID">要删除的库房记录的库房ID.</param>
        /// <returns></returns>
        internal long m_lngDeleteMedicineStoreInfo(string strStoreID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC objSvc = 
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC));
            lngRes = objSvc.m_lngDeleteMedicineStoreInfo(objPrincipal, strStoreID);
            return lngRes;
        }
        #endregion
        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strStoreID">指定要删除的库房记录.</param>
        /// <returns></returns>
        public long m_lngDeleteMedStoreSetInfo( string strStoreID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSetSVC));
            lngRes = objSvc.m_lngDeleteMedStoreSetInfo(objPrincipal, strStoreID);
            return lngRes;
        }
                #endregion
        #region 查询库房药品信息.

        /// <summary>
        /// 查询库房药品信息.
        /// </summary>
        /// <param name="strStoreID">查询条件.</param>
        /// <param name="strMedicineNameArr">返回结果.</param>
        /// <returns></returns>
        internal long m_lngSelectMedicineName(string strStoreID, out string[] strMedicineNameArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineStoreroomSet_Supported_SVC));
            lngRes = objSvc.m_lngSelectMedicineName(objPrincipal, strStoreID, out strMedicineNameArr);
            return lngRes;
        }
        #endregion

        #region 获取门诊药房基本信息表
        /// <summary>
        ///  获取门诊药房基本信息表
        /// </summary>
        /// <param name="m_dtMedStore"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo(out DataTable m_dtMedStore)
        {

            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetMedStoreInfo(objPrincipal, out m_dtMedStore);
            return lngRes;

        }
        #endregion

        #region 获取科室基本信息表
        /// <summary>
        /// 获取门诊药房基本信息表
        /// </summary>
        /// <param name="m_dtDeptDesc"></param>
        /// <returns></returns>
        public long m_lngGetDeptInfo(out DataTable m_dtDeptDesc)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptInfo(objPrincipal, out m_dtDeptDesc);
            return lngRes;

        }
        #endregion
    }
}
