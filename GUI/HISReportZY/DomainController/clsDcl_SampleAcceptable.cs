using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_SampleAcceptable : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        public clsDcl_SampleAcceptable()
        {

        }

        #region 检验报告发放时限符合率统计报表
        /// <summary>
        /// 检验报告发放时限符合率统计报表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="dteStart"></param>
        /// <param name="dteEnd"></param>
        /// <param name="applyUnitId"></param>
        /// <param name="strDept"></param>
        /// <param name="enmergencyFlg"></param>
        /// <returns></returns>
        public long lngGetSampleAcceptable(out DataTable dtbResult, string dteStart, string dteEnd,  string applyUnitId, string strDept, string enmergencyFlg, string patType)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetSampleAcceptable(out dtbResult, dteStart, dteEnd,applyUnitId, strDept, enmergencyFlg, patType);
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
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetAllCheckSpec(out dtbResult);
            }
        }
        #endregion


        #region 获取申请单元时间维护
        /// <summary>
        /// lngGetLimitTime
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <param name="applyunitid"></param>
        /// <returns></returns>
        public long lngGetAllLimitTime(out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetAllLimitTime(out dtbResult);
            }
        }

        #endregion
        #region 获取专业组
        /// <summary>
        /// 获取专业组
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long GetAllCheckSpec(out DataTable dtbResult)
        {
            long lngRes = 0;

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                dtbResult = svc.GetGategoryType();
                return lngRes;
            }
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
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetAllCheckItemCpy(out dtbResult, groupId);
            }
        }
        #endregion

        #region 名称检验检验项目
        /// <summary>
        /// 名称检验检验项目
        /// </summary>
        /// <param name="strTempName"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetCheckItemByName(string strTempName, string groudId, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetCheckItemByNameCpy(strTempName, groudId, out dtbResult);
            }
        }
        #endregion
    }
}
