using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.HIS;
namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    #region �������ⰴ��λƷ��ͳ��
    /// <summary>
    /// �������ⰴ��λƷ��ͳ��
    /// </summary>
    /// <param name="p_objPrincipal"></param>
    /// <param name="p_strDrugID">ҩ��</param>
    /// <param name="p_dtmStartDate">��ʼ����</param>
    /// <param name="p_dtmEndDate">��������</param>
    /// <param name="p_dtbResult">��ѯ���</param>
    /// <returns></returns>
    public class clsDcl_RecipeByEachDeptReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetRecipeByEachDeptReport(string p_strDrugID, string p_strDeptID,DateTime p_dtmStartDate, DateTime p_dtmEndDate, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRecipeReportSVC));
            lngRes = objSvc.m_lngRecipeByEachDeptReport(objPrincipal, p_strDrugID,p_strDeptID, p_dtmStartDate, p_dtmEndDate, out p_dtbResult);
            return lngRes;
        }

        #region ��ȡ���ò���
        /// <summary>
        /// ��ȡ���ò���
        /// </summary>
        /// <param name="p_dtbVendor">���ò�������</param>
        /// <returns></returns>
        internal long m_lngGetExportDeptForDrugStore(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetExportDeptForDrugStore(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion
    }
    #endregion
}
