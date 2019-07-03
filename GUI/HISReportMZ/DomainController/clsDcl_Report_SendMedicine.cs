using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊药房发药工作量统计报表
    /// </summary>
    public class clsDcl_Report_SendMedicine : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 发送药品信息
        /// <summary>
        /// 发送药品信息
        /// </summary>
        /// <param name="p_dtpBegin"></param>
        /// <param name="p_dtpEnd"></param>
        /// <param name="p_strMedstoreid"></param>
        /// <param name="m_dtbResult"></param>
        /// <returns></returns>
        internal long m_lngSelectSendMedicine(DateTime p_dtpBegin, DateTime p_dtpEnd, string p_strMedstoreid,string p_strTreatEmp, out DataTable m_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc));
            lngRes = objSvc.m_lngSelectSendMedicine(p_dtpBegin, p_dtpEnd, p_strMedstoreid,p_strTreatEmp, out m_dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取药房名称
        /// <summary>
        /// 获取药房名称
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        internal long m_lngGetSendMedicine(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportSendMedicineSvc));
            lngRes = objSvc.m_lngGetSendMedicine(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 获取配药员工
        /// <summary>
        /// 获取配药员工
        /// </summary>
        /// <param name="p_strSearch"></param>
        /// <param name="m_objResult"></param>
        /// <returns></returns>
        internal long m_mthGetSendEmp(string p_strMedNameid, out DataTable m_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc));
            lngRes = objSvc.m_lngGetTreatEmp(p_strMedNameid, out m_objResult);
            return lngRes;
        }
        #endregion
    }
}
