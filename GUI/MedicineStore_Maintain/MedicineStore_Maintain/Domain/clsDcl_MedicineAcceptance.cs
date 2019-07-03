using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsDcl_MedicineAcceptance : com.digitalwave.GUI_Base.clsDomainController_Base
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

        /// <summary>
        /// 获取汇总数据
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="dtbValue">DataTable</param>
        /// <returns></returns>
        internal long m_lngGetAcceptance(string p_strStoreRoomID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC));
            lngRes = objSvc.m_lngGetAcceptance(objPrincipal, p_strStoreRoomID, p_dtmBegin, p_dtmEnd, out dtbValue);
            return lngRes;
        }


        internal long m_lngGetAcceptance_Med(string p_strStoreRoomID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC));
            lngRes = objSvc.m_lngGetAcceptance_Med(objPrincipal, p_strStoreRoomID, p_dtmBegin, p_dtmEnd, out dtbValue);
            return lngRes;
        }
        
        /// <summary>
        /// 获取明细数据
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_dtmBegin">开始日期</param>
        /// <param name="p_dtmEnd">结束日期</param>
        /// <param name="dtbValue">DataTable</param>
        /// <returns></returns>
        internal long m_lngGetAcceptanceDetal(string p_strStoreRoomID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC));
            lngRes = objSvc.m_lngGetAcceptanceDetal(objPrincipal, p_strStoreRoomID, p_dtmBegin, p_dtmEnd, out dtbValue);
            return lngRes;
        }

        internal long m_lngGetAcceptanceDetal_Med(string p_strStoreRoomID, DateTime p_dtmBegin, DateTime p_dtmEnd, out DataTable dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineAcceptanceSVC));
            lngRes = objSvc.m_lngGetAcceptanceDetal_Med(objPrincipal, p_strStoreRoomID, p_dtmBegin, p_dtmEnd, out dtbValue);
            return lngRes;
        }

        
    }
}
