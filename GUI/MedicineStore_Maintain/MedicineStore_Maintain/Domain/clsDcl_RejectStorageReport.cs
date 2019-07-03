using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.MedicineStoreService;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region 报废统计报表
    /// <summary>
    /// 逻辑控制层
    /// </summary>
    public class clsDcl_RejectStorageReport : com.digitalwave.GUI_Base.clsDomainController_Base
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStorageID, out p_strStorageName);

            return lngRes;
        }
        #endregion

        #region 查询药品报废明细
        /// <summary>
        /// 查询药品报废明细
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="p_intMedicineSetID">药品类型</param>
        /// <param name="p_dtbData">药品入库明细</param>
        /// <returns></returns>
        internal long m_lngStatistics(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd,int p_intMedicineSetID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectStorageReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectStorageReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectStorageReportSVC));
            lngRes = objSvc.m_lngStatistics(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_intMedicineSetID, out p_dtbData);
            return lngRes;
        }
        #endregion
    }
    #endregion
}
