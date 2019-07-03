using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �����ڽ�ת����Ʋ�
    /// </summary>
    public class clsDcl_Account : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡҩ�����ʱ�����
        /// <summary>
        /// ��ȡҩ�����ʱ�����
        /// </summary>
        /// <param name="p_strStorageID">ҩ��ID</param>
        /// <param name="p_strAccountID">������ID</param>
        /// <param name="p_objRecord">���ʱ�����</param>
        /// <returns></returns>
        public long m_lngGetAccout(string p_strStorageID, string p_strAccountID, out clsDS_Account p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGetAccout(objPrincipal, p_strStorageID, p_strAccountID, out p_objRecord);
            return lngRes;
        }
        #endregion
        #region �����ʱ�
        /// <summary>
        /// �����ʱ�
        /// </summary>
        /// <param name="p_dtmBegin">�����ڿ�ʼʱ��</param>
        /// <param name="p_dtmEnd">�����ڽ���ʱ��</param>
        /// <param name="m_strDrugStoreid">ҩ��ID</param>
        /// <param name="p_objAccount">�����</param>
        /// <param name="p_lngSEQArr">����</param>
        /// <returns></returns>
        public long m_lngGenarateAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string m_strDrugStoreid, out clsDS_Account p_objAccount, out long[] p_lngSEQArr,int m_intTransferMode,long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGenarateAccount(objPrincipal, p_dtmBegin, p_dtmEnd, m_strDrugStoreid, out p_objAccount, out p_lngSEQArr, m_intTransferMode, m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
        #region ����Ƿ���δȷ�����ʵļ�¼
        /// <summary>
        /// ����Ƿ���δȷ�����ʵļ�¼
        /// </summary>
        /// <param name="p_dtmBegin">�����ڿ�ʼʱ��</param>
        /// <param name="p_dtmEnd">�����ڽ���ʱ��</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_strChittyIDArr">���ݺ�</param>
        /// <returns></returns>
        public long m_lngCheckHasUnConfirmAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out string[] p_strChittyIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasUnConfirmAccount(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_strChittyIDArr);
            return lngRes;
        }
        #endregion
        #region ��鿪���������Ƿ����δ��˵ļ�¼
        /// <summary>
        /// ��鿪���������Ƿ����δ��˵ļ�¼
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">�����ڿ�ʼʱ��</param>
        /// <param name="p_dtmEndDate">�����ڽ���ʱ��</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_strHintText">����δ��˼�¼�ĵ�������(����)</param>
        /// <returns></returns>
        public long m_lngCheckHasUnCommitRecord(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out string p_strHintText)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasUnCommitRecord(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, out p_strHintText);
            return lngRes;
        }
             #endregion
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_dtmAccountDate">��������</param>
        /// <param name="p_strChittyIDArr">���ݺ�</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        public long m_lngSetAccount( string p_strEmpID, DateTime p_dtmAccountDate, string[] p_strChittyIDArr, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_SVC));
            lngRes = objSvc.m_lngSetAccount(objPrincipal, p_strEmpID, p_dtmAccountDate, p_strChittyIDArr, p_strStorageID);
            return lngRes;
        }
        #endregion
        #region �����ʱ�
        /// <summary>
        /// �����ʱ�
        /// </summary>
        /// <param name="p_objAccPe">�����ڽ�ת����</param>
        /// <param name="p_objAccount">�ʱ�����</param>
        /// <param name="p_lngMedSEQ">��ˮ������</param>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_strAccountID">������ID</param>
        /// <param name="p_lngMainSEQ">����������</param>
        /// <param name="p_lngSubSEQ">�ʱ�����</param>
        /// <returns></returns>
        public long m_lngSaveAccount(clsDS_AccountPeriodVO p_objAccPe, clsDS_Account p_objAccount, long[] p_lngMedSEQ, string p_strEmpID, out string p_strAccountID, out long p_lngMainSEQ, out long p_lngSubSEQ,int m_intTransfermode,long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_SVC));
            lngRes = objSvc.m_lngSaveAccount(objPrincipal, p_objAccPe, p_objAccount, p_lngMedSEQ, p_strEmpID, out p_strAccountID, out p_lngMainSEQ, out p_lngSubSEQ,m_intTransfermode,m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
        #region  ��ȡ���һ���̵�ʱ����Ϊ���������ڵĽ���ʱ��

        /// <summary>
        /// ��ȡ���һ���̵�ʱ����Ϊ���������ڵĽ���ʱ��
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="m_dtmBeginAccountTime"></param>
        /// <param name="m_dtmEndAccountTime"></param>
        /// <returns></returns>
        public long m_lngGetAccountEndTime(string p_strStorageID, DateTime m_dtmBeginAccountTime, out  DateTime m_dtmEndAccountTime,out long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGetAccountEndTime(objPrincipal, p_strStorageID, m_dtmBeginAccountTime, out m_dtmEndAccountTime, out m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
    }
}
