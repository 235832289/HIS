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
    /// 查询配药人员的处方信息
    /// </summary>
    public class clsDcl_TreatRecipeInfo : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region 获取药房名称
        /// <summary>
        /// 获取药房名称
        /// </summary>
        /// <param name="m_objTable"></param>
        public long m_lngGetMedicineName(out DataTable m_objTable)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc));
            lngRes = objSvc.m_lngGetMedicineName(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 配药员工和处方信息列表

        /// <summary>
        /// 配药员工和处方信息列表
        /// </summary>
        public long m_lngGetTreatEmpInfo(string p_strCartNo, string p_strPatientName, string p_strInvoiceNo, DateTime p_dtpBegin, DateTime p_dtpEnd, string p_strMedicineName, string p_strTreatEmp, out DataTable m_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc));
            lngRes = objSvc.m_lngGetTreatEmpInfo(p_strCartNo, p_strPatientName, p_strInvoiceNo, p_dtpBegin.ToShortDateString(), p_dtpEnd.ToShortDateString(), p_strMedicineName, p_strTreatEmp, out m_dtbResult);
            return lngRes;
        }
        #endregion

        #region 处方明细信息表

        /// <summary>
        /// 处方明细信息表

        /// </summary>
        public long m_lngGetDetailInfo(string p_strsid_int, string p_strmedstoreid_chr, out DataTable m_dtbDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsTreatRecipeInfoSvc));
            lngRes = objSvc.m_lngGetDetailInfo(p_strsid_int, p_strmedstoreid_chr, out m_dtbDetail);
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
        internal long m_lngGetTreatEmp(string p_strMedNameid, out DataTable m_objResult)
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
