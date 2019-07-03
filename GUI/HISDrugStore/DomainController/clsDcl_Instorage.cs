using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ���������Ʋ�
    /// </summary>
    public class clsDcl_Instorage : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡ����ҩ�����������Ϣ
        /// <summary>
        ///  ��ȡ����ҩ�����������Ϣ
        /// </summary>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_dtInstorage"></param>
        /// <returns></returns>
        public long m_lngGetCurrentDayInstoragenfo( string m_strBeginDate, string m_strEndDate, out DataTable m_dtInstorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetCurrentDayInstoragenfo(objPrincipal, m_strBeginDate, m_strEndDate, out m_dtInstorage);
            return lngRes;
        }
        #endregion 
        #region ���ݲ�ѯ������ȡҩ�����������Ϣ
        /// <summary>
        ///  ���ݲ�ѯ������ȡҩ�����������Ϣ
        /// </summary>
        /// <param name="m_blnCombine">�Ƿ�Ʒ�ֲ�ѯ</param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_strMakeOrderName"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_strBorrowDeptID"></param>
        /// <param name="m_strBillID"></param>
        /// <param name="m_dtInstorage"></param>
        /// <returns></returns>
        public long m_lngGetInstoragenfoByconditions(bool m_blnCombine,string m_strBeginDate, string m_strEndDate, string m_strMakeOrderName, string m_strTypeCode,int m_intStatus, string m_strBorrowDeptID, string m_strBillID,string p_strMedicineID,
            out DataTable m_dtInstorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetInstoragenfoByconditions(objPrincipal, m_blnCombine, m_strBeginDate, m_strEndDate, m_strMakeOrderName, m_strTypeCode, m_intStatus, m_strBorrowDeptID, m_strBillID, p_strMedicineID, out m_dtInstorage);
            return lngRes;
        }
        #endregion
        #region ������ˮ�Ż�ȡҩ�������ϸ
        /// <summary>
        /// ������ˮ�Ż�ȡҩ�������ϸ
        /// </summary>        
        /// <param name="p_blnHospital">�Ƿ�סԺҩ��</param>
        /// <param name="m_lngSeqid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetInstorageDetailByID(bool p_blnHospital,long m_lngSeqid, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetInstorageDetailByID(objPrincipal, p_blnHospital,m_lngSeqid, out dt);
            return lngRes;
        }
        #endregion
        #region ������ˮ��ɾ��ҩ���������
        /// <summary>
        /// ������ˮ��ɾ��ҩ���������
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public long m_lngDelInstorage( long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngDelInstorage(objPrincipal, m_lngSeqid);
            return lngRes;
        }
        #endregion
        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="m_strdrugstoreexamid"></param>
        /// <param name="m_datdrugstoreexam"></param>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        public long m_lngInstorageExam(string m_strdrugstoreexamid, DateTime m_datdrugstoreexam, long p_lngSeriesID,clsDS_StorageDetail_VO[] m_objDetailArr,int m_intType,out bool m_blnHasEnoughGross,out string m_strMedName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngInstorageExam(m_strdrugstoreexamid, m_datdrugstoreexam, p_lngSeriesID, m_objDetailArr, m_intType, out m_blnHasEnoughGross, out m_strMedName);
            return lngRes;
        }
        #endregion
        #region ������ˮ�Ż�ȡҩ�������ϸ
       /// <summary>
        /// ������ˮ�Ż�ȡҩ�������ϸ
       /// </summary>
       /// <param name="m_lngSeqid"></param>
       /// <param name="m_objDetailVoArr"></param>
       /// <param name="m_intType"></param>
       /// <returns></returns>
        public long m_lngGetInstorageDetailByID(long m_lngSeqid, out clsDS_StorageDetail_VO[] m_objDetailVoArr,int m_intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngGetInstorageDetailByID(objPrincipal, m_lngSeqid, out m_objDetailVoArr, m_intType);
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
        public long m_lngAddStorage(ref clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngAddStorage(objPrincipal, ref p_objDetail, intType);
            return lngRes;
        }
        #endregion
        #region ����ҩ�����
        /// <summary>
        /// ����ҩ�����
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objDetail">�����ϸVO</param>
        /// <param name="intType">�޸����͡�1:�ӿ��,2:�����</param>
        /// <returns></returns>
        public long m_lngSubtractStorage(clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngSubtractStorage(objPrincipal, p_objDetail, intType);
            return lngRes;

        }
        #endregion
        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <returns></returns>
        public long m_lngInstorageUnExam(long p_lngSeriesID)
        {
            long lngRes = 0;
            bool m_blnHasGross = true;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngInstorageUnExam(p_lngSeriesID, out m_blnHasGross);
            return lngRes;
        }
         #endregion
        #region �����˱���ϸ
        /// <summary>
        /// �����˱���ϸ
        /// </summary>
        /// <param name="p_objAccountDetailArr">�˱���ϸ����</param>
        /// <returns></returns>
        public long m_lngAddNewAccountDetail(clsDS_StorageDetail_VO[] p_objAccountDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngAddNewAccountDetail(objPrincipal, p_objAccountDetailArr);
            return lngRes;
        }
        #endregion
        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="m_strEmpid"></param>
        /// <param name="m_strChittyid_vchr"></param>
        /// <param name="m_strDrugStoreid"></param>
        /// <returns></returns>
        public long m_lngInstorageInAccount(long p_lngSeriesID, string m_strEmpid, string m_strChittyid_vchr, string m_strDrugStoreid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngInstorageInAccount(objPrincipal, p_lngSeriesID,  m_strEmpid,  m_strChittyid_vchr,  m_strDrugStoreid);
            return lngRes;
        }
           #endregion
        #region ����ҩ������������ϸ������
        /// <summary>
        /// ����ҩ������������ϸ������
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngAddNewInstorage(ref clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngAddNewInstorage(objPrincipal, ref m_objMainVo, ref m_objDetailArr,0,"");
            return lngRes;
        }
        #endregion
        #region ���������ж��Ƿ�����㹻�Ŀ������
        /// <summary>
        /// ���������ж��Ƿ�����㹻�Ŀ������
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_dtmInstorage"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_blnEnough"></param>
        /// <returns></returns>
        public long m_lngInstorageUnExamCheck(string m_strDurgStoreid, string m_strLotNo, string m_strMedicineid, DateTime m_dtmInstorage, double m_dblOPAmount, out bool m_blnEnough)
        {

            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngInstorageUnExamCheck(m_strDurgStoreid, m_strLotNo,m_strMedicineid,m_dtmInstorage,m_dblOPAmount, out m_blnEnough);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// ��ȡ���������
        /// </summary>
        /// <param name="p_dtStoreType"></param>
        /// <returns></returns>
        public long m_lngGetTypeCode(Int16 p_intType, out DataTable p_dtStoreType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetTypeCode(objPrincipal, p_intType, out p_dtStoreType);
            return lngRes;
        }
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
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID,"ҩ�������ɫ", out p_blnHasRole);
            return lngRes;
        }
        #endregion

        #region ��鵥��״ֵ̬
        /// <summary>
        /// ��鵥��״ֵ̬
        /// </summary>
        /// <param name="p_intType">�������0Ϊҩ����ⵥ</param>
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

        internal long m_lngGetSumMoney(long p_intSeriesID, out double p_dblSummoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetSumMoney(objPrincipal, p_intSeriesID, out p_dblSummoney);
            return lngRes;
        }

        internal long m_lngAddNewInstorage(ref clsDS_Instorage_VO p_objMainVo, ref clsDS_Instorage_Detail[] p_objInStorageDetailVoArr, ref clsDS_StorageDetail_VO[] p_objDetailVoArr, int p_intAddOrSubtract, long p_lngAskSeqid, int p_intState)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngAddNewInstorage(objPrincipal, ref p_objMainVo, ref p_objInStorageDetailVoArr, 1, p_objMainVo.m_strDRUGSTOREEXAMID_CHR, ref p_objDetailVoArr, p_intAddOrSubtract, p_lngAskSeqid, p_intState);
            return lngRes;
        }

        #region ��鵥��FormType
        /// <summary>
        /// ��鵥��FormType
        /// </summary>
        /// <param name="p_lngSeq">����seq</param>
        /// <param name="p_intFormType">����FormTypeֵ</param>
        /// <returns></returns>
        internal long m_lngCheckFormType(long p_lngSeq, out int p_intFormType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckFormType(objPrincipal,p_lngSeq, out p_intFormType);
            return lngRes;
        }
        #endregion
    }

}
