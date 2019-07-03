using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 标本反馈Domain层
    /// </summary>
    public class clsDcl_SampleBack:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region  获取样本反馈信息
        /// <summary>
        /// 获取样本反馈信息
        /// </summary>
        /// <param name="p_strFromDate">开始日期</param>
        /// <param name="p_strToDate">结束日期</param>
        /// <param name="p_strPatientName">病人姓名</param>
        /// <param name="p_strInHospitalNO">住院号</param>
        /// <param name="p_strAppDeptID">申请科室ID</param>
        /// <param name="p_dtResult">返回结果表</param>
        /// <returns>大于0成功，小于或等于0失败</returns>
        public long m_lngQuerySampleBack(string p_strFromDate, string p_strToDate, string p_strPatientName, string p_strInHospitalNO, string p_strAppDeptID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            clsQuerySampleBackSvc objSvc =
                (clsQuerySampleBackSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuerySampleBackSvc));
            lngRes = objSvc.m_lngQuerySampleBack(p_strFromDate, p_strToDate, p_strPatientName,p_strInHospitalNO, p_strAppDeptID, out p_dtResult);
            return lngRes;
        }
        #endregion
    }
}
