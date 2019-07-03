using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsDcl_ResultReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取盘点主表信息
        /// <summary>
        /// 获取盘点主表信息
        /// </summary>
        /// <param name="p_strStarDate">查询开始时间</param>
        /// <param name="p_strEndDate">查询结束时间</param>
        /// <param name="p_strStorage">仓库ID</param>
        /// <param name="dtbStorageCheck">返回数据</param>
        /// <returns></returns>
        internal long m_lngGetStorageCheck(DateTime p_strStarDate, DateTime p_strEndDate, string p_strStorage, out DataTable dtbStorageCheck)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetStorageCheck(objPrincipal, p_strStarDate, p_strEndDate, p_strStorage, out dtbStorageCheck);
            return lngRes;
        }
        #endregion

        #region 获取盘点明细表信息

        /// <summary>
        /// 获取盘点明细表信息
        /// </summary>
        /// <param name="p_lngSeriesId">主表序列号</param>
        /// <param name="dtbStorageCheck_detail">明细表信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageCheck_detail(long p_lngSeriesId, out DataTable dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetStorageCheck_detail(objPrincipal, p_lngSeriesId, out dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

        #region 获取仓库名
        /// <summary>
        /// 获取仓库名
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
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
