using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 自动生成请领单域控制类
    /// </summary>
    public class clsDcl_MedicineLimit : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region 查询药房信息
        /// <summary>
        /// 查询药房信息
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionStorageBse(out clsValue_StorageBse_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageBseData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取药房限量信息
        /// </summary>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strDrugType">药品类型</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_dtbResult">限量信息</param>
        /// <returns></returns>
        public long m_mthGetLimitData(string p_strStorageID, string p_strDrugType,bool p_blnIsHospital,ref DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));

            lngRes = objSvc.m_mthGetLimitData(objPrincipal, p_strStorageID,p_strDrugType,p_blnIsHospital, ref p_dtbResult);
            return lngRes;
        }

        /// <summary>
        /// 保存限量信息
        /// </summary>
        /// <param name="p_objLimit">要保存的限量信息</param>
        /// <returns></returns>
        public long m_lngSaveMedicine(clsDS_MedicineLimit[] p_objLimit)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            lngRes = objSvc.m_lngSaveMedicine(p_objLimit);
            return lngRes;
        }

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strDrugType">药品类型</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode,  string p_strDrugType,out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strDrugType,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="p_dtbResult">返回结果</param>
        /// <returns></returns>
        public long m_lngGetMedicineType(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineType(objPrincipal, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取门诊药房对应的部门号
        internal void m_mthGetDeptID(string p_strStorageID, out string p_strDeptID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            objSvc.m_lngGetDeptID(objPrincipal, p_strStorageID, out p_strDeptID);            
        }
        #endregion
    }
}
