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
    public class clsDcl_DrugStorageQuery : com.digitalwave.GUI_Base.clsDomainController_Base
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

        #region ��ѯ�����ϸ��Ϣ
        /// <summary>
        /// ��ѯ�����ϸ��Ϣ
        /// </summary>
        /// <param name="objvalue_Param"></param>
        /// <param name="lstMedicineType"></param>
        /// <param name="dtbResult"></param>
        /// <param name="p_strProductor"></param>
        /// <param name="p_objPrepTypeArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionStorageDetail(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, List<string> lstMedicineType, ref DataTable dtbResult, string p_strProductor, clsMEDICINEPREPTYPE_VO[] p_objPrepTypeArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageDetailData(objPrincipal, ref objvalue_Param, lstMedicineType, ref dtbResult, p_strProductor, p_objPrepTypeArr);
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

        internal long m_lngSaveProvide(DataTable m_dtbModify)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveProvide(objPrincipal, m_dtbModify);
            return lngRes;
        }

        /// <summary>
        /// ����Ƿ�סԺҩ��ʹ��
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <returns></returns>
        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngCheckIsHospital(objPrincipal, p_strDrugStoreID, out p_blnIsHospital);
            return lngRes;
        }

        /// <summary>
        /// ����ID��ȡ�����ϸ�������
        /// </summary>
        /// <param name="p_intSeriesID"></param>
        /// <param name="objHistory"></param>
        /// <returns></returns>
        internal long m_lngGetAmountBySeriesID(long p_intSeriesID, out clsDS_StorageHistory_VO p_objHistory)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetAmountBySeriesID(objPrincipal, p_intSeriesID, out p_objHistory);
            return lngRes;
        }

        /// <summary>
        /// ��������ϸ���޸ļ�¼
        /// </summary>
        /// <param name="objHistory"></param>
        /// <returns></returns>
        internal long m_lngSaveAmount(clsDS_StorageHistory_VO objHistory)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveAmount(objPrincipal, objHistory);
            return lngRes;
        }

        /// <summary>
        /// ����ҩ��IDȡ�ü���
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="objMPVO"></param>
        internal void m_mthShowMedicinePreptype(string p_strDrugStoreID,out clsMEDICINEPREPTYPE_VO[] objMPVO)
        {
            clsDcl_GetStoreCheckMedicine objDom = new clsDcl_GetStoreCheckMedicine();
            objDom.m_lngGetMedicinePreptype(p_strDrugStoreID, out objMPVO);
        }
    }
}
