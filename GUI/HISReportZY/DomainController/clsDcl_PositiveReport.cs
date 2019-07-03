using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_PositiveReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_PositiveReport()
        {
        }

        #region 检验项目阳性结果分析统计表
        /// <summary>
        /// 检验项目阳性结果分析统计表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetPositiveReport(out DataTable dtbResult, string dteStart, string dteEnd, string checkItemId, string strDept, string groupId,string patNo)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetPositiveReport(out dtbResult, dteStart, dteEnd, checkItemId, strDept, groupId, patNo);
            }
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

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                dtbResult = svc.GetGategoryType();
            }
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

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                dtbResult = svc.GetGategoryType();
            }
            return lngRes;
        }

        #endregion

        #region 获取所有检验组合项目
        /// <summary>
        /// 获取所有检验组合项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAllCheckItem(out DataTable dtbResult, string groupId)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetAllCheckItemCpy(out dtbResult, groupId);
            }
        }
        #endregion

        #region 获取所有检验组合项目
        /// <summary>
        /// 获取所有检验组合项目
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAllCheckItemDetail(out DataTable dtbResult, string groupId)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetAllCheckItemDetail(out dtbResult, groupId);
            }
        }
        #endregion

        #region 名称检索检验项目
        /// <summary>
        /// 名称检索检验项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetCheckItemDetailByNameCpy(string strTempName, string groudId, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetCheckItemDetailByNameCpy(strTempName, groudId, out dtbResult);
            }
        }
        #endregion
    }
}
