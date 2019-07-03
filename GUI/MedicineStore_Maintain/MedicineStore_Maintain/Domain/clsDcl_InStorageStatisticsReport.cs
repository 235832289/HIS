using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsDcl_InStorageStatisticsReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
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

        #region 获取供应商

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="p_dtbVendor">供应商数据</param>
        /// <returns></returns>
        internal long m_lngGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetVendor(objPrincipal, out p_dtbVendor);
            return lngRes;
        }
        #endregion

        #region 入库统计

        /// <summary>
        /// 入库统计
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        internal long m_lngStatistics(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC));
            lngRes = objSvc.m_lngStatistics(objPrincipal,p_strStorageID, p_dtmBegin, p_dtmEnd, p_strVendorID, p_intMedicineSetID, out p_dtbData);
            return lngRes;
        }

        /// <summary>
        /// 入库统计(外退)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        internal long m_lngStatisticsForeignRetreat(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendorID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC));
            lngRes = objSvc.m_lngStatisticsForeignRetreat(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strVendorID, p_intMedicineSetID, out p_dtbData);
            return lngRes;
        }
        #endregion

        #region 获取排序字段

        /// <summary>
        /// 获取排序字段
        /// </summary>
        /// limitunitprice_mny
        internal long m_lngGetTaxisType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5022", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region　获取所有仓库名称

        /// <summary>
        /// 获取所有仓库名称
        /// </summary>
        /// limitunitprice_mny
        internal long m_lngGetStoreroom(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageStatisticsReportSVC));
            lngRes = objSvc.m_lngGetStoreroom(objPrincipal, out p_dtbVendor);
            return lngRes;
        }
        #endregion



    }
}
