using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDomainController_SampleAcceptable : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        public clsDomainController_SampleAcceptable()
        {

        }

        #region 检验报告发放时限符合率统计报表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <param name="enmergencyFlg"></param>
        /// <returns></returns>
        public long lngGetSampleAcceptable(out DataTable dtbResult, string dteStart, string dteEnd, string applyUnitId, string strDept, string enmergencyFlg, string patType)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetSampleAcceptable(out dtbResult, dteStart, dteEnd, applyUnitId, strDept, enmergencyFlg, patType);

            return lngRes;
        }
        #endregion

        #region 获取专业组
        /// <summary>
        /// 获取专业组
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAllCheckSpec(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetAllCheckSpec(out dtbResult);

            return lngRes;
        }
        #endregion

        #region 获取所有检验项目
        /// <summary>
        /// 获取所有检验项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAllCheckItem(out DataTable dtbResult, string groupId)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetAllCheckItem(out dtbResult, groupId);

            return lngRes;
        }
        #endregion


        /// <summary>
        /// 名称检验检验项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetCheckItemByName(string strTempName, string groudId, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetCheckItemByName(strTempName, groudId, out dtbResult);

            return lngRes;
        }

    }
}
