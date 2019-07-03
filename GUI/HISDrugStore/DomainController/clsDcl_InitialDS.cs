using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ������ʼ��
    /// </summary>
    public class clsDcl_InitialDS : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡҩƷ�������Ϣ
        /// <summary>
        /// ��ȡҩƷ�������Ϣ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">��ѯ����</param>
        /// <param name="p_dtbMedicine">���ؽ��</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode,string m_strMedStoreid, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode,m_strMedStoreid, out p_dtbMedicine);
            return lngRes;
        } 
        #endregion

        #region ����ҩƷ
        /// <summary>
        /// ����ҩƷ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objNew">�����ҩƷ</param>
        /// <param name="p_objModify">�޸ĵ�ҩƷ</param>
        /// <param name="p_lngNewSeqArr">������¼������</param>
        /// <returns></returns>
        public long m_lngSaveMedicineInfo(clsDS_Initial_VO[] p_objNew, clsDS_Initial_VO[] p_objModify, out long[] p_lngNewSeqArr,out string[] p_strIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngSaveMedicineInfo(objPrincipal, p_objNew, p_objModify, out p_lngNewSeqArr, out p_strIDArr);
            return lngRes;
        }
        #endregion

        #region ��ȡҩ����ʼ��ҩƷ��Ϣ
        /// <summary>
        /// ��ȡҩ����ʼ��ҩƷ��Ϣ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugStoreID">ҩ��ID</param>
        /// <param name="p_blnIsHospital">�Ƿ�סԺ��λ</param>
        /// <param name="p_dtbMedicine">ҩƷ��Ϣ</param>
        /// <returns></returns>
        public long m_lngGetInitilaMedicine(string p_strDrugStoreID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngGetInitilaMedicine(objPrincipal, p_strDrugStoreID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ɾ��ָ����ʼ���
        /// <summary>
        /// ɾ��ָ����ʼ���
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">���к�</param>
        /// <returns></returns>
        public long m_lngDeleteMedicineInitial(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngDeleteMedicineInitial(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region ���ҩ������ʼ��
        /// <summary>
        /// ���ҩ������ʼ��
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        public long m_lngCommitInitila(string p_strStorageID, clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngCommitInitila(objPrincipal, p_strStorageID, p_objDetail,intType);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ��ȡҩ����Ϣ
        /// </summary>
        /// <param name="p_strDrugStoreID">ҩ��ID</param>
        /// <param name="p_strStoreName">ҩ������</param>
        /// <param name="p_strDeptID">��Ӧ�Ĳ���ID</param>
        /// <returns></returns>
        internal long m_lngGetStoreInfo(string p_strDrugStoreID, out string p_strStoreName, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreInfo(objPrincipal, p_strDrugStoreID, out p_strStoreName, out p_strDeptID);
            return lngRes;
        }

        #region ���ҩƷ
        /// <summary>
        /// ���ҩƷ
        /// </summary>
        /// <param name="p_objDetailArr">�����ϸ</param>
        /// <param name="p_objStorageArr">�����������</param>
        /// <param name="p_lngSEQArr">���������</param>
        /// <param name="p_strEmpID">�����ID</param>
        /// <param name="p_blnIsImmAccount">�Ƿ���˼�����</param>
        /// <returns></returns>
        internal long m_lngCommitMedicineInfo(clsDS_StorageDetail_VO[] p_objDetailArr, clsDS_Storage_VO[] p_objStorageArr, long[] p_lngSEQArr, string p_strEmpID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngCommitMedicineInfo(objPrincipal, p_objDetailArr, p_objStorageArr, p_lngSEQArr, p_strEmpID, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_lngSEQArr">���ʼ�¼����</param>
        /// <param name="p_strInitialID">����ID</param>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        internal long m_lngInAccount(long[] p_lngSEQArr, string[] p_strInitialID, string p_strEmpID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_lngSEQArr, p_strInitialID, p_strEmpID, p_strStorageID);
            return lngRes;
        }
        #endregion
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_lngSEQ">����</param>
        /// <param name="p_strInitialID">����</param>
        /// <param name="p_strStorageID">ҩ��ID</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strLotNO">����</param>
        /// <param name="p_dblInAmount">�������</param>
        /// <returns></returns>
        internal long m_lngUnCommit(long p_lngSEQ, string p_strInitialID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, double p_dblInAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_lngSEQ, p_strInitialID, p_strStorageID, p_strMedicineID, p_strLotNO, p_dblInAmount);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ��ѯ�Ƿ����н�ת��¼
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_blnHasAccountPeriod"></param>
        /// <returns></returns>
        internal long m_lngCheckHasAccount(string p_strStorageID, out bool p_blnHasAccountPeriod)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasAccount(objPrincipal, p_strStorageID, out p_blnHasAccountPeriod);
            return lngRes;
        }
    }
}
