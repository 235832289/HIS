using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDomainController_PositiveReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainController_PositiveReport()
        {
        }

        #region 检验项目阳性结果分析统计表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPositiveReport(out DataTable dtbResult, string dteStart, string dteEnd, string applyUnitId, string strDept, string groupId,string patNo)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetPositiveReport(out dtbResult, dteStart, dteEnd, applyUnitId, strDept, groupId, patNo);

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
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            //lngRes = objSvc.lngGetAllCheckSpec(out dtbResult);
            dtbResult = objSvc.GetGategoryType();

            return lngRes;
        }
        #endregion


        #region 专业组
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGgetAllZyz(out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            dtbResult = objSvc.GetGategoryType();

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
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            //lngRes = objSvc.lngGetAllCheckItem(out dtbResult, groupId);
            lngRes = objSvc.lngGetAllCheckItemCpy(out dtbResult, groupId);
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
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.HIS.Report.clsHISReportZy_Supported_Svc));

            lngRes = objSvc.lngGetCheckItemByNameCpy(strTempName, groudId, out dtbResult);

            return lngRes;
        }
    }
}
