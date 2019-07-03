using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_Report : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 病人入院单统计报表
        /// <summary>
        /// 病人入院单统计报表
        /// </summary>
        /// <param name="p_dtFromTime">开始时间</param>
        /// <param name="p_dtToTime">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngPatientInHospitalReport(DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsReportSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportSvc));
            return objSvc.m_lngPatientInHospitalReport(objPrincipal, p_dtFromTime, p_dtToTime, out p_dtbResult);
        }
        #endregion

        #region 新生婴儿登记统计报表
        /// <summary>
        /// 新生婴儿登记统计报表
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtFromTime">开始时间</param>
        /// <param name="p_dtToTime">结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngBabyRegisterReport( string p_strAreaID, DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsReportSvc)
                         com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportSvc));
            return objSvc.m_lngBabyRegisterReport(objPrincipal,p_strAreaID, p_dtFromTime, p_dtToTime, out p_dtbResult);
        }
        #endregion
    }
}
