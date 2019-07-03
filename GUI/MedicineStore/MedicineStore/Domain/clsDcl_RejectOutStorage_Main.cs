using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_RejectOutStorage_Main : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取出库主表
        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageMain(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,  string p_strOutID, int p_intFormType, out DataTable p_dtbOutStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageMain(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strOutID, p_intFormType, out p_dtbOutStorage);
            return lngRes;
        }
        #endregion

        #region 获取药品类型批号,有效期控制信息
        /// <summary>
        /// 获取药品类型批号,有效期控制信息
        /// </summary>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_objTypeVO"></param>
        /// <returns></returns>
        internal long m_lngGetMedicineTypeVisionm(string p_strMedicineTypeID, out clsMS_MedicineTypeVisionmSet p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC));
            lngRes = objSvc.m_lngGetMedicineTypeVisionm(objPrincipal, p_strMedicineTypeID, out p_objTypeVO);
            return lngRes;
        }
        #endregion
    }
}
