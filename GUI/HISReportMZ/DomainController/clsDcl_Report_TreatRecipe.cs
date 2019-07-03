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
    /// 门诊药房配药工作量统计报表
    /// </summary>
    public class clsDcl_Report_TreatRecipe : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 配药处方信息
        /// <summary>
        /// 配药处方信息
        /// </summary>
        /// <param name="p_dtpBegin"></param>
        /// <param name="p_dtpEnd"></param>
        /// <param name="p_strMedstoreid"></param>
        /// <param name="m_dtbResult"></param>
        /// <returns></returns>
        public long m_lngSelectTreatRecipe(DateTime p_dtpBegin, DateTime p_dtpEnd, string p_strMedstoreid,string p_strTreatEmp,int p_intMedicineType, out DataTable m_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc));
            lngRes = objSvc.m_lngSelectTreatRecipe(p_dtpBegin, p_dtpEnd, p_strMedstoreid, p_strTreatEmp,p_intMedicineType, out m_dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取药房名称
        /// <summary>
        /// 获取药房名称
        /// </summary>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetTreatRecipe(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc));
            lngRes = objSvc.m_lngGetTreatRecipe(out m_objTable);
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

        internal long m_lngGetMedicineType(string p_strDrugStoreID, out int m_intMedicineType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportTreatRecipeSvc));
            lngRes = objSvc.m_lngGetMedicineType(p_strDrugStoreID, out m_intMedicineType);
            return lngRes;
        }
    }
}
