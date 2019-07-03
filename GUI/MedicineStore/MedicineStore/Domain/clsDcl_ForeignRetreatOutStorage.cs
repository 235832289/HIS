using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品外退
    /// </summary>
    public class clsDcl_ForeignRetreatOutStorage : com.digitalwave.GUI_Base.clsDomainController_Base
    {


        #region 获取出库主表(退药出库)
        /// <summary>
        /// 获取出库主表(退药出库)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendor">供应商ID或名称</param>
        /// <param name="p_strMedicine">药品ID或名称</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageMain(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,string p_strVendor,string p_strMedicine, out DataTable p_dtbOutStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageMain(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd,p_strVendor,p_strMedicine, out p_dtbOutStorage);
            return lngRes;
        }
        #endregion

        #region 取仓库名称

        /// <summary>
        /// 取仓库名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID"></param>
        /// <param name="p_strStoreRoomName"></param>
        /// <returns></returns>
        public long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID, out p_strStoreRoomName);
            return lngRes;
        }
        #endregion
    }
}
