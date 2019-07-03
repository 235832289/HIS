using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// ҩ���̵�����Ʋ�
    /// </summary>
    public class clsDcl_DrugStoreCheck : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region �����Ƶ�ʱ���ҩ��id��ȡҩ���̵�����
        /// <summary>
        /// �����Ƶ�ʱ���ҩ��id��ȡҩ���̵�����
        /// </summary>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_datBeginTime"></param>
        /// <param name="m_datEndTime"></param>
        /// <param name="m_dtCheckMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckMainInfo(string m_strDrugStoreid, DateTime m_datBeginTime, DateTime m_datEndTime, out DataTable m_dtCheckMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckMainInfo(objPrincipal, m_strDrugStoreid, m_datBeginTime, m_datEndTime, out m_dtCheckMainInfo);          
            return lngRes;
        }
        #endregion
        #region �������кŻ�ȡҩ���̵���ϸ����
        /// <summary>
        /// �������кŻ�ȡҩ���̵���ϸ����
        /// </summary>
        /// <param name="m_strSerialID"></param>
        /// <param name="m_dtCheckDetailInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckDetailInfoById(string m_strSerialID, out DataTable m_dtCheckDetailInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckDetailInfoById(objPrincipal, m_strSerialID, out m_dtCheckDetailInfo);
            return lngRes;
        }
        #endregion
        #region ���ݲ�ѯ������ȡҩ���̵�����
        /// <summary>
        /// ���ݲ�ѯ������ȡҩ���̵�����
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_datBeginTime"></param>
        /// <param name="m_datEndTime"></param>
        /// <param name="m_strCheckid"></param>
        /// <param name="m_strMakerid"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_dtCheckMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckMainInfo(string m_strDrugStoreid, DateTime m_datBeginTime, DateTime m_datEndTime, string m_strCheckid, string m_strMakerid, Int16 m_intStatus, out DataTable m_dtCheckMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckMainInfo(objPrincipal,  m_strDrugStoreid,  m_datBeginTime,  m_datEndTime,  m_strCheckid,  m_strMakerid,  m_intStatus, out  m_dtCheckMainInfo);
            return lngRes;
        }
        #endregion

        #region ɾ���̵���Ϣ
        /// <summary>
        /// ɾ���̵���Ϣ
        /// </summary>
        /// <param name="p_lngSEQ">��������</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageCheck(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngDeleteStorageCheck(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion
        
        #region ��ȡ�̵���ϸ����Ϣ

        /// <summary>
        /// ��ȡ�̵���ϸ����Ϣ
        /// </summary>
        /// <param name="p_lngSeriesId">�������к�</param>
        /// <param name="p_intCheckMode">�̵�ģʽ��0ΪĬ�ϣ�1Ϊ��Ժ</param>
        /// <param name="p_blnIsHospital">�Ƿ�סԺҩ��</param>
        /// <param name="dtbDetailTrue">δ�ϲ�����ϸ����Ϣ</param>
        /// <param name="dtbStorageCheck_detail">�Ѻϲ�����ϸ����Ϣ</param>
        /// <returns></returns>
        internal long m_lngGetStoreCheck_detail(long p_lngSeriesId,int p_intCheckMode,bool p_blnIsHospital,out DataTable dtbDetailTrue, out DataTable dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageCheck_detail(objPrincipal, p_lngSeriesId,p_intCheckMode, p_blnIsHospital,out dtbDetailTrue, out dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

       
        #region ����̵�
        /// <summary>
        /// ����̵�
        /// </summary>
        /// <param name="p_lngMainSEQ">��������</param>
        /// <param name="p_objDefCheckDetail">�̿���ϸ</param>
        /// <param name="p_objSufCheckDetail">��ӯ��ϸ</param>
        /// <param name="p_objStDetail">�̵�ҩƷ��ؿ����ϸ</param>
        /// <param name="p_strMedicineIDArr">�̵�ҩƷID</param>
        /// <param name="p_strEmpID">�����ID</param>
        /// <param name="p_dtmCommitDate">�������</param>
        /// <param name="p_strCheckID">�̵�ID</param>
        /// <param name="p_strCreatorID">�̵���ID</param>
        /// <param name="p_dtmCheckDate">�̵�����</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        internal long m_lngCommitStoreCheck(long p_lngMainSEQ, clsDS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsDS_StorageCheckDetail_VO[] p_objSufCheckDetail, clsDS_StorageDetail_VO[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, DateTime p_dtmCommitDate,
            string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID,bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngCommitStorageCheck(objPrincipal, p_lngMainSEQ, p_objDefCheckDetail, p_objSufCheckDetail, p_objStDetail, p_strMedicineIDArr, p_strEmpID, p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID, false,"0",p_blnIsHospital);
            return lngRes;
        }
        #endregion

        #region ��ȡ��ǰԱ���Ƿ���ҩ�������ɫ
        /// <summary>
        /// ��ȡ��ǰԱ���Ƿ���ҩ�������ɫ
        /// </summary>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_blnHasRole">�Ƿ���ҩ�������ɫ</param>
        /// <returns></returns>
        internal long m_lngCheckEmpHasRole(string p_strEmpID, out bool p_blnHasRole)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID, "ҩ�������ɫ", out p_blnHasRole);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_strEmpID">������</param>
        /// <param name="p_dtmAccountDate">��������</param>
        /// <param name="p_lngSeq">����</param>
        /// <param name="p_strChittyid">���ݺ�</param>
        /// <param name="p_strDrugStoreid">ҩ��ID</param>
        /// <returns></returns>
        internal long m_lngInAccount(string p_strEmpID, DateTime p_dtmAccountDate, long p_lngSeq,string  p_strChittyid, string p_strDrugStoreid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_lngSeq, p_strChittyid, p_strEmpID, p_dtmAccountDate, p_strDrugStoreid);
            return lngRes;
        }

        #region ��ȡ�̵�ģʽ��0ΪĬ�ϣ�1Ϊ��ҽ��Ժ
        /// <summary>
        /// ��ȡ�̵�ģʽ��0ΪĬ�ϣ�1Ϊ��ҽ��Ժ
        /// </summary>
        /// <param name="p_intCheckMode">�̵�ģʽ��0ΪĬ�ϣ�1Ϊ��ҽ��Ժ</param>
        /// <returns></returns>
        internal long m_mthGetCheckMode(out int p_intCheckMode)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "0406", out p_intCheckMode);
            return lngRes;
        }
        #endregion


        #region ��鵥��״ֵ̬
        /// <summary>
        /// ��鵥��״ֵ̬
        /// </summary>
        /// <param name="p_intType">�������2Ϊҩ���̵��</param>
        /// <param name="p_lngSeq">����seq</param>
        /// <param name="m_intStatus">����״ֵ̬</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(int p_intType, long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_intType, p_lngSeq, out m_intStatus);
            return lngRes;
        }
        #endregion
    }
}
