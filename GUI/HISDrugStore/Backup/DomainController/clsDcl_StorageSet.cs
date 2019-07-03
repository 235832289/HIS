using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ������������
    /// </summary>
    public class clsDcl_StorageSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ѯ�ֿ���Ϣ
        /// <summary>
        /// ��ѯ�ֿ���Ϣ
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

        #region ��ȡҩƷ����
        /// <summary>
        /// ��ȡҩƷ����
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionMedicineType(out clsValue_MedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetMedicineTypeData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region ����ҩ�����ƻ�ȡ������Ϣ
        /// <summary>
        /// ����ҩ�����ƻ�ȡ������Ϣ
        /// </summary>
        /// <param name="p_strStoreName">ҩ������</param>
        /// <param name="m_dtbStorageRack">������Ϣ</param>
        /// <returns></returns>
        internal long m_lngGetStorageRack(string p_strStoreName, out DataTable m_dtbStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageRack(objPrincipal, p_strStoreName, out m_dtbStorageRack);
            return lngRes;
        }
        #endregion

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="p_dicStorageRack">��Ҫ���������Ϣ�ļ�¼</param>
        /// <returns></returns>
        internal long m_lngSaveStorageRack(Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveStorageRack(objPrincipal, p_dicStorageRack);
            return lngRes;
        }
        #endregion

        #region ��������
        internal long m_lngSaveStorageSet(DataTable m_dtbModify)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveStorageSet(objPrincipal, m_dtbModify);
            return lngRes;
        }
        #endregion

        #region ��ȡ����
        internal long m_mthGetStorageDetailData(string p_strStorageID, string p_strMedicineID, string p_strAssistCode, string p_strMedicineTypeID,
            out DataTable dtbResult,List<string> lstMedicineType,bool p_blnIsHospital)
        {
            long lngRes = 0;
            dtbResult = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageDataForSet(objPrincipal, p_strStorageID, p_strMedicineID, p_strAssistCode, p_strMedicineTypeID, lstMedicineType, p_blnIsHospital,ref dtbResult);
            return lngRes;
        }
        #endregion 
    }
}
