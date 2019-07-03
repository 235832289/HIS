using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��������
    /// </summary>
    public class clsDcl_OutStorage : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡ����ҩ������������Ϣ
        /// <summary>
        ///  ��ȡ����ҩ������������Ϣ
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_dtOutstorage"></param>
        /// <returns></returns>
        public long m_mthGetCurrentDayOutstoragenfo(string m_strBeginDate, string m_strEndDate, out DataTable m_dtOutstorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_mthGetCurrentDayOutstorageInfo(objPrincipal, m_strBeginDate, m_strEndDate, out m_dtOutstorage);
            return lngRes;
        }
        #endregion

        #region ������ˮ�Ż�ȡҩ��������ϸ
        /// <summary>
        /// ������ˮ�Ż�ȡҩ��������ϸ
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetOutstorageDetailByID(bool p_blnIsHospital,long m_lngSeqid, out DataTable m_dtDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetOutstorageDetailByID(objPrincipal, p_blnIsHospital,m_lngSeqid, out m_dtDetail);
            return lngRes;
        }
        #endregion

        #region ���ݲ�ѯ������ȡҩ������������Ϣ
        /// <summary>
        ///  ���ݲ�ѯ������ȡҩ������������Ϣ
        /// </summary>
        /// <param name="p_blnCombine">�Ƿ�Ʒ�ֲ�ѯ</param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strMakeOrderName"></param>
        /// <param name="m_strTypeCode"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="m_strBorrowDeptID"></param>
        /// <param name="m_strBillID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="m_dtInstorage"></param>
        /// <returns></returns>
        public long m_mthGetOutstorageInfoByconditions(bool p_blnCombine,string m_strBeginDate, string m_strEndDate, string m_strMakeOrderName, string m_strTypeCode, int m_intStatus, string m_strMedStoreID, string m_strBorrowDeptID, string m_strBillID,string p_strMedicineID,
           out DataTable m_dtInstorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_mthGetOutstorageInfoByconditions(objPrincipal,p_blnCombine, m_strBeginDate, m_strEndDate, m_strMakeOrderName,  m_strTypeCode, m_intStatus, m_strMedStoreID, m_strBorrowDeptID, m_strBillID, p_strMedicineID,out m_dtInstorage);
            return lngRes;
        }
        #endregion

        #region ������ˮ��ɾ��ҩ����������
        /// <summary>
        /// ������ˮ��ɾ��ҩ����������
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public long m_lngDelOutstorage(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngDelOutstorage(objPrincipal, m_lngSeqid,0);
            return lngRes;
        }
        #endregion

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="m_strdrugstoreexamid"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        public long m_lngOutstorageExam(string m_strdrugstoreexamid, long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngOutstorageExam(m_strdrugstoreexamid, p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region ������ˮ�Ż�ȡҩ�������ϸ
        /// <summary>
        /// ������ˮ�Ż�ȡҩ�������ϸ
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <param name="m_objDetailVoArr"></param>
        /// <returns></returns>
        public long m_lngGetOutstorageDetailByID(long m_lngSeqid, out clsDS_UpdateStorageBySeriesID_VO[] m_objDetailVoArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetOutstorageDetailByID(objPrincipal, m_lngSeqid, out m_objDetailVoArr);
            return lngRes;
        }
        #endregion

        #region ����ҩ�����
        /// <summary>
        /// ����ҩ�����
        /// </summary>
        /// <param name="p_objDetail">�����ϸVO</param>
        /// <param name="intType">�޸����͡�1:�ӿ��,2:�����</param>
        /// <returns></returns>
        public long m_lngAddStorage(clsDS_UpdateStorageBySeriesID_VO[] p_objDetail, Int16 intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngAddStorage(objPrincipal, p_objDetail, intType);
            return lngRes;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        public long m_lngOutstorageUnExam(long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngOutstorageUnExam(p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region ����ҩ�����
        /// <summary>
        /// ����ҩ�����
        /// </summary>
        /// <param name="p_objDetail">�����ϸVO</param>
        /// <param name="intType">�޸����͡�1:�ӿ��,2:�����</param>
        /// <returns></returns>
        public long m_lngSubtractStorage(clsDS_UpdateStorageBySeriesID_VO[] p_objDetail, Int16 intType, out string p_strErrorInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngSubtractStorage(objPrincipal, p_objDetail, intType, out p_strErrorInfo);
            return lngRes;

        }
        #endregion
        #region ��������
        /// <summary>
        ///��������
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="m_strEmpid"></param>
        /// <param name="m_strChittyid_vchr"></param>
        /// <param name="m_strDrugStoreid"></param>
        /// <returns></returns>
        public long m_lngOutstorageInAccount(long p_lngSeriesID, string m_strEmpid, string m_strChittyid_vchr, string m_strDrugStoreid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngOutstorageInAccount(objPrincipal, p_lngSeriesID,  m_strEmpid,  m_strChittyid_vchr, m_strDrugStoreid);
            return lngRes;
        }
            #endregion
        #region �����˱���ϸ
        /// <summary>
        /// �����˱���ϸ
        /// </summary>
        /// <param name="m_objForUpdateArr">�˱���ϸ����</param>
        /// <returns></returns>
        public long m_lngAddNewAccountDetail(clsDS_UpdateStorageBySeriesID_VO[] m_objForUpdateArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngAddNewAccountDetail(objPrincipal, m_objForUpdateArr);
            return lngRes;
        }
        #endregion
        #region �����˱���ϸ
        /// <summary>
        /// �����˱���ϸ
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strChittyid"></param>
        /// <returns></returns>
        public long m_lngUpdateAccountDetail(string m_strDurgStoreid, string m_strChittyid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngUpdateAccountDetail(objPrincipal, m_strDurgStoreid, m_strChittyid);
            return lngRes;
    
        }
             #endregion

        #region ��鵥��״ֵ̬
        /// <summary>
        /// ��鵥��״ֵ̬
        /// </summary>
        /// <param name="p_intType">�������1Ϊҩ�����ⵥ</param>
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

        /// <summary>
        /// ������벿����ҩ������ͬʱ����һ�Ŵ�ҩ������ⵥ��
        /// </summary>
        /// <param name="m_lngSeqid">������������</param>
        /// <returns></returns>
        internal long m_lngAddInstorage(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngAddInstorage(objPrincipal, m_lngSeqid);
            return lngRes;
        }

        internal long m_lngGetSumMoney(long p_intSeriesID, out double p_dblSummoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetSumMoney(objPrincipal, p_intSeriesID, out p_dblSummoney);
            return lngRes;
        }
    }
}