using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS.Report;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_SampleStatMedSpec : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_SampleStatMedSpec()
        {
        }

        #region 检验标本周转中位数统计表
        /// <summary>
        /// 检验标本周转中位数统计表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetSampleMedSpec(out DataTable dtbResult, string dteStart, string dteEnd,string groupId, string applyUnitId,string strDept,string enmergencyFlg,string patType)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.GetSampleMedSpec(out dtbResult, dteStart, dteEnd, groupId, applyUnitId, strDept, enmergencyFlg, patType);
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

        #region 名称检索检验项目
        /// <summary>
        /// 名称检索检验项目
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
