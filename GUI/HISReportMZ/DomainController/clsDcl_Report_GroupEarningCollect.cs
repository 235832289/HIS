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
    /// 
    /// </summary>
    public class clsDcl_Report_GroupEarningCollect : com.digitalwave.GUI_Base.clsDomainController_Base
    {   
        public long m_lngSelectGroupEarningCollect(string strBeginDat, string strEndDat, string[] strTypeOfGh, string[] strTypeOfZc, out DataTable m_dtbReport)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngSelectGroupEarningCollect(strBeginDat, strEndDat, strTypeOfGh, strTypeOfZc, out m_dtbReport);
        }
        
         #region 专业组挂号费及诊金汇总表(旧)
        /// <summary>
        /// 4.专业组挂号费及诊金汇总表（旧）
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns> 
        public long m_lngSelectGroupEarningCollect(string strBeginDat, string strEndDat, string strGhfParams, string strZcParams, out DataTable dt1, out DataTable dt2, out DataTable dt3)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                                                                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            long l = objSvc.m_lngSelectGroupEarningCollect(strBeginDat, strEndDat, strGhfParams, strZcParams, out dt1, out dt2, out dt3);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 专业组挂号费及诊金汇总表（新）
        /// <summary>
        /// 4.专业组挂号费及诊金汇总表（新）
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="m_strTypeOfGh"></param>
        /// <param name="m_strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns> 
        public long m_lngGetGroupEarningCollect(string strBeginDat, string strEndDat,string[] p_strTypeIDArr1, string[] p_strTypeIDArr2, out DataTable dt1, out DataTable dt2, out DataTable dt3)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                                                                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            long l = objSvc.m_lngGetGroupEarningCollect(strBeginDat, strEndDat, p_strTypeIDArr1, p_strTypeIDArr2, out dt1, out dt2, out dt3);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 取核算分类
        /// <summary>
        /// 取核算分类
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="strTypeOfGh"></param>
        /// <param name="strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        internal long m_lngGetTypeID(string p_strRptID, string p_strGroupID, out DataTable p_dtbTypeID)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngGetTypeID(p_strRptID, p_strGroupID, out p_dtbTypeID);
        }

        #endregion

    }
}
