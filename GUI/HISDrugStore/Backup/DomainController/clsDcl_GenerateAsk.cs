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
    public class clsDcl_GenerateAsk : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region ��ѯ�ֿ���Ϣ
        /// <summary>
        /// ��ѯ�ֿ���Ϣ
        /// </summary>
        /// <param name="p_objResultArr">�ֿ���Ϣ</param>
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

        #region ��ȡ������ϸ
        /// <summary>
        /// ��ȡ������ϸ
        /// </summary>
        /// <param name="p_blnIsHospital">�Ƿ�סԺ��λ</param>
        /// <param name="p_strStorageID">ҩ��ID</param>
        /// <param name="p_strBeginDate">���⿪ʼ����</param>
        /// <param name="p_strEndDate">�����������</param>
        /// <param name="m_intGetRequestAmount">����������������</param>
        /// <param name="p_dtbResult">������ϸ����</param>
        /// <returns></returns>
        public long m_mthGetOutStorageDetailData(bool p_blnIsHospital, string p_strStorageID, string p_strBeginDate, string p_strEndDate,int m_intGetRequestAmount, ref DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));

            lngRes = objSvc.m_mthGetOutStorageDetailData(objPrincipal, p_blnIsHospital,p_strStorageID, p_strBeginDate, p_strEndDate,m_intGetRequestAmount, ref p_dtbResult);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ�����������������
        /// <summary>
        /// ��ȡҩƷ�����������������
        /// </summary>
        /// <param name="p_strStorageID">ҩ��ID</param>
        /// <param name="p_strBeginDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbAmount">�������쵥�Ŀ����������</param>
        public long m_lngGetNeapData(string p_strStorageID,DateTime p_strBeginDate,DateTime p_strEndDate, ref DataTable p_dtbAmount)
        {            
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));

            return objSvc.m_mthGetNeapData(objPrincipal, p_strStorageID,p_strBeginDate,p_strEndDate, ref p_dtbAmount);            
        }
        #endregion

        #region ��ȡ���ⲿ����Ϣ
        /// <summary>
        /// ��ȡ���ⲿ����Ϣ
        /// </summary>
        /// <param name="m_dtExportDept">���ⲿ����Ϣ</param>
        /// <returns></returns>
        public long m_lngGetExportDept(out DataTable m_dtExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetExportDept(objPrincipal, out m_dtExportDept);
            return lngRes;
        }
        #endregion

        #region ��ȡ��ҩ������Ϣ
        /// <summary>
        /// ��ȡ��ҩ������Ϣ
        /// </summary>
        /// <param name="m_dtDept"></param>
        /// <returns></returns>
        public long m_lngGetApplyDept(out DataTable m_dtDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetApplyDept(objPrincipal, out m_dtDept);
            return lngRes;
        }
        #endregion

        internal long m_lngGetExptypeAndVendor(bool p_blnForDrugStore, out DataTable dtExp, out DataTable dtVendor, out DataTable dtMedType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageStatSvc));
            lngRes = objSvc.m_lngGetExptypeAndVendor(p_blnForDrugStore, out dtExp, out dtVendor, out dtMedType);
            return lngRes;
        }

        internal long m_lngGetDeptIDForStore(string p_strStorageID, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptIDForStore(objPrincipal, p_strStorageID, out p_strDeptID);
            return lngRes;
        }

        internal long m_lngGetRequestAmount(out int p_intGetRequestAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "0410", out p_intGetRequestAmount);
            return lngRes;
        }
    }
}
