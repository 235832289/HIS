using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsDcl_StorageRacksetSet : com.digitalwave.GUI_Base.clsDomainController_Base
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            lngRes = objSvc.m_lngGetMedicineStoreroomInfo(objPrincipal, out p_MedicineStoreArr);
            return lngRes;
        }
        #endregion
        #region 根据库房类型id获取相应库房基本信息
        /// <summary>
        ///  根据库房类型id获取相应库房基本信息
        /// </summary>
        /// <param name="m_strType">1,药库货架 2,药房货架</param>
        /// <param name="p_objMedicineStoreroomInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetStorageInfoByTypeid(string m_strType, out clsMS_MedicineStoreroom_VO[] p_objMedicineStoreroomInfoArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            lngRes = objSvc.m_lngGetStorageInfoByTypeid(objPrincipal, m_strType, out p_objMedicineStoreroomInfoArr);
            return lngRes;
        }
        #endregion
        #region　获取最大ID
        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        internal string m_lngGetMaxId()
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            return objSvc.m_lngGetMaxId();
            
        }
        #endregion

        #region　获取货架记录
        /// <summary>
        /// 获取货架记录
        /// </summary>
        ///
        /// <param name="objSto_Vo"></param>
        internal void m_lngGetStor(string m_strType,out clsMS_StorInfoVo[] objSto_Vo)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            objSvc.m_lngGetStor(m_strType,out objSto_Vo);
        }
        #endregion

        #region　插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="objSto_Vo"></param>
        internal void m_lngInsertStor(clsMS_StorInfoVo objSto_Vo)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            objSvc.m_lngInsertStoreInfo(objSto_Vo);
        }
        #endregion
        
        #region　修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="objSto_Vo"></param>
        internal void m_lngEditStor(clsMS_StorInfoVo objSto_Vo)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            objSvc.m_lngEditStoreInfo(objSto_Vo);
        }
        #endregion
        
        #region　删除记录
         /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="objSto_Vo"></param>
        internal void m_lngDelStore(string m_strStorId)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            objSvc.m_lngDelStoreInfo(m_strStorId);
        }
         #endregion

        #region　查找货架ID是否已存在
         /// <summary>
        /// 查找货架ID是否已存在
        /// </summary>
        /// <param name="objSto_Vo"></param>
        internal bool m_lngFindId(string m_strStorgeType, string m_strStorId)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC));
            return objSvc.m_lngFindStoreId(m_strStorgeType,m_strStorId);
        }
         #endregion

    }
}
