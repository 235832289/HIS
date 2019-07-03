using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �Զ��������쵥�������
    /// </summary>
    public class clsDcl_MedicineLimit : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region ��ѯҩ����Ϣ
        /// <summary>
        /// ��ѯҩ����Ϣ
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
        /// ��ȡҩ��������Ϣ
        /// </summary>
        /// <param name="p_strStorageID">ҩ��ID</param>
        /// <param name="p_strDrugType">ҩƷ����</param>
        /// <param name="p_blnIsHospital">�Ƿ�סԺҩ��</param>
        /// <param name="p_dtbResult">������Ϣ</param>
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
        /// ����������Ϣ
        /// </summary>
        /// <param name="p_objLimit">Ҫ�����������Ϣ</param>
        /// <returns></returns>
        public long m_lngSaveMedicine(clsDS_MedicineLimit[] p_objLimit)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            lngRes = objSvc.m_lngSaveMedicine(p_objLimit);
            return lngRes;
        }

        #region ��ȡҩƷ�������Ϣ
        /// <summary>
        /// ��ȡҩƷ�������Ϣ
        /// </summary>
        /// <param name="p_strAssistCode">��ѯ����</param>
        /// <param name="p_strDrugType">ҩƷ����</param>
        /// <param name="p_dtbMedicine">���ؽ��</param>
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

        #region ��ȡҩƷ����
        /// <summary>
        /// ��ȡҩƷ����
        /// </summary>
        /// <param name="p_dtbResult">���ؽ��</param>
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

        #region ��ȡ����ҩ����Ӧ�Ĳ��ź�
        internal void m_mthGetDeptID(string p_strStorageID, out string p_strDeptID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            objSvc.m_lngGetDeptID(objPrincipal, p_strStorageID, out p_strDeptID);            
        }
        #endregion
    }
}
