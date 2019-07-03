using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.MedicineStoreService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 出库统计报表  王勇  2007-4-16
    /// <summary>
    /// 逻辑控制层
    /// </summary>
    class clsDomainController_OutStorageStat : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取出库统计数据

        public long m_lngGetResultByOutStorageStat(ref clsMS_OutStorageStatQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));

            lngRes = objSvc.m_lngGetOutStorageStatData(objPrincipal, ref objvalue_Param,ref dtbResult);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 内退统计
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_dtbData">统计结果</param>
        /// <returns></returns>
        internal long m_lngGetWithinWithdrawal(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strDeptID, int p_intMedicineSetID, out DataTable p_dtbData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngGetWithinWithdrawal(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strDeptID, p_intMedicineSetID, out p_dtbData);
            return lngRes;
        }

        internal long m_lngGetExportDept(out DataTable dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetExportDept(objPrincipal, out dtbExportDept);
            return lngRes;
        }

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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStorageID, out p_strStorageName);

            return lngRes;
        }
        #endregion
    }
    #endregion
}
