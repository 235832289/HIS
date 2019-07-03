using System;
using System.Data;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ���﷢ҩ���Ʋ�
    /// </summary>
    public class clsDomainControlOPMedStore : clsDomainController_Base
    {
        /// <summary>
        /// ��ȡҩ����Ϣ
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo(string m_strMedStoreid, ref DataTable dtResult)
        {
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetMedStoreInfo(m_strMedStoreid, ref dtResult);
            return lngRes;
        }
        /// <summary>
        /// ��ȡ��ҩ������Ϣ
        /// </summary>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetReturnMedicine(string strMedStoreid, string strBeginDate, string strEndDate, int p_intDeductFlow, out DataTable m_objTable)
        {
            m_objTable = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetReturnMedicine(objPrincipal, strMedStoreid, strBeginDate, strEndDate, p_intDeductFlow, out m_objTable);
            return lngRes;

        }
        /// <summary>
        /// ���ݴ���id��ҩ��id��ȡ�ѷ�ҩ������ϸ
        /// </summary>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        public long m_lngGetSendMedRecipeDetailByid(string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            p_dtItemDe = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetSendMedRecipeDetailByid(objPrincipal, m_strOPRecipeid, m_strMedStoreid, out p_dtItemDe);
            return lngRes;
        }
        /// <summary>
        /// ��ȡ��ҩ��Ϣ
        /// </summary>
        /// <param name="m_strOutPatientRecipe"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetReturnDetailInfo(string m_strOutPatientRecipe, ref DataTable dtResult)
        {
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetReturnDetailInfo(m_strOutPatientRecipe, ref dtResult);
            return lngRes;
        }
        /// <summary>
        /// ���ݴ����Ż�ȡ����״̬
        /// </summary>
        /// <param name="m_strOutPatientRecipeid"></param>
        /// <param name="m_intStatus"></param>
        /// <returns></returns>
        public long m_lngGetRecipeStatus(string m_strOutPatientRecipeid, out int m_intStatus)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetRecipeStatus(objPrincipal, m_strOutPatientRecipeid, out m_intStatus);
            return lngRes;
        }
        /// <summary>
        /// ����ҩ����ҩ��Ϣ
        /// </summary>
        /// <param name="m_objDetailList"></param>
        /// <returns></returns>
        public long m_lngRollBackReturnMedInfo(string m_strOperatorid, List<clsReutrnMedEntry> m_objDetailList, out string p_strExcp)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngRollBackReturnMedInfo(objPrincipal, m_strOperatorid, m_objDetailList, out p_strExcp);
            return lngRes;

        }
        /// <summary>
        /// ���ҩ����ҩ��Ϣ
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailList"></param>
        /// <returns></returns>
        public long m_lngAddReturnMedInfo(clsReutrnMed m_objMainVo, List<clsReutrnMedEntry> m_objDetailList)
        {

            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngAddReturnMedInfo(objPrincipal, m_objMainVo, m_objDetailList);
            return lngRes;

        }
        /// <summary>
        /// �ж��Ƿ���ڸ�Ա��
        /// </summary>
        /// <param name="m_strEmpNO"></param>
        /// <param name="m_strPwd"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetEmpInfo(string m_strEmpNO, string m_strPwd, ref DataTable dtResult)
        {

            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetEmpInfo(m_strEmpNO, m_strPwd, ref dtResult);
            return lngRes;
        }

        #region ���캯��
        /// <summary>
        /// ���﷢ҩ���Ʋ�
        /// </summary>
        public clsDomainControlOPMedStore()
        {

        }
        #endregion

        #region ͨ������ȡ��ǰ���˶���
        /// <summary>
        /// ͨ������ȡ��ǰ���˶���
        /// </summary>
        /// <param name="windStatus">����״̬��Ϣ</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region ��ȡ�����ƺ���㲡�˵���ҩ�б�
        /// <summary>
        /// ��ȡ�����ƺ���㲡�˵���ҩ�б�
        /// </summary>
        /// <param name="windStatus"></param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetTreatMetnFirstByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetTreatMetnFirstByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region ͨ������ȡ��ǰ��������⴦���Ĳ��˶���
        /// <summary>
        /// ͨ������ȡ��ǰ��������⴦���Ĳ��˶���
        /// </summary>
        /// <param name="windStatus">����״̬��Ϣ</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListByWinIDForData(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListByWinIDForData(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region ��ͨ��ͨ����ҩ����ȡ��ǰ���˶���
        /// <summary>
        ///��ͨ��ͨ����ҩ����ȡ��ǰ���˶���
        /// </summary>
        /// <param name="windStatus">����״̬��Ϣ</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListNotByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListNotByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region ��ȡ��ҩ��Ŀ��ϸ����
        /// <summary>
        /// ��ȡ��ҩ��Ŀ��ϸ����
        /// </summary>
        /// <param name="itemCode">��Ŀ����</param>
        /// <param name="dtbResult">���ص����ݱ�</param>
        /// <returns></returns>
        public long m_lngGetItemData(string itemCode, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetItemData(objPrincipal, itemCode, out dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region �޸�ҩ�����ͱ�кű�־
        public long m_lngUpdateRecipeSendCalledFlag2(long m_intSid)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCalledFlag2(m_intSid);
            return lngRes;
        }
        #endregion

        #region �޸�ҩ�����ͱ�кű�־
        /// <summary>
        /// �޸�ҩ�����ͱ�кű�־
        /// </summary>
        /// <param name="m_intSid">���к�</param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCalledFlag(long m_intSid, int p_intIsReCall)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCalledFlag(m_intSid, p_intIsReCall);
            return lngRes;

        }
        #endregion
        #region �޸�ҩ�����ͱ�ǰ�кű�־
        /// <summary>
        /// �޸�ҩ�����ͱ�ǰ�кű�־
        /// </summary>
        /// <param name="m_intSid">���к�</param>
        /// <param name="m_strSendWindowid"></param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCurrentCallFlag(long m_intSid, string m_strSendWindowid, int m_intIsReCall, bool m_blnIsModfilySendWinId)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCurrentCallFlag2(m_intSid, m_strSendWindowid, m_intIsReCall, m_blnIsModfilySendWinId);
            return lngRes;
        }
        #endregion

        #region �����кţ�����������������ֻ�Ƿŵ����еĺ��棩
        /// <summary>
        /// �����кţ�����������������ֻ�Ƿŵ����еĺ��棩
        /// </summary>
        /// <param name="m_intSid">���к�</param>
        /// <returns></returns>
        public long m_lngRecipeSendQuit(long m_intSid)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngRecipeSendQuit(m_intSid);
            return lngRes;
        }
        #endregion

        #region �����к�
        /// <summary>
        /// �����к�
        /// </summary>
        /// <param name="p_intSid"></param>
        /// <returns></returns>
        public long m_lngCancelCalledFalg(long p_lngSid)
        {
            long lngRes = -1;
            clsMedStoreSvc objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngCancelRecipeSendCalledFlag(p_lngSid);
            return lngRes;

        }
        #endregion

        #region ͨ������ȡ��ǰ���˶���
        /// <summary>
        /// ͨ������ȡ����ҩ���˶���
        /// </summary>
        /// <param name="p_strID">���ں�</param>
        /// <param name="p_dtbResult">�������</param>
        /// <returns></returns>
        public long m_lngGetPutOutPatientListByWinID(string p_strID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPutOutPatientListByWinID(objPrincipal, p_strID, out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// <summary>
        /// ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// </summary>
        /// <param name="p_objItem">������������</param>
        /// <param name="winID">����ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, clsMedRecipeSend_VO p_objItem, DataTable dt, string stroageID, string strTOLMNY, clst_opr_nurseexecute[] nurseexecuteArr, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail, string m_strSubtractMode, string m_strSecondLevelMode)
        {
            long lngRes = 0;

            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, p_objItem, dt, stroageID, strTOLMNY, nurseexecuteArr, p_objDetail, ref m_objOutStorageDetail, m_strSubtractMode, m_strSecondLevelMode);
            return lngRes;
        }
        #endregion
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strCardID">���ƿ���</param>
        /// <param name="p_strPatient">��������</param>
        /// <param name="p_strRegNo">��ˮ��</param>
        /// <param name="p_strRegDate">��ʼ����</param>
        ///  <param name="p_endDate">��������</param>
        /// <param name="p_dtbResult">�������</param>
        /// <returns></returns>
        public long m_lngGetPatientList(int p_intStatus, string p_strStorageID, string p_strWinID, string p_strCardID, string p_strPatient,
            string p_strRegNo, string p_strRegDate, string p_endDate, bool isShowReturn, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPatientList(objPrincipal, p_intStatus, p_strStorageID, p_strWinID, p_strCardID, p_strPatient,
                p_strRegNo, p_strRegDate, p_endDate, isShowReturn, out p_dtbResult);
            return lngRes;
        }
        #endregion
        #region ��ҩ����
        /// <summary>
        ///  ��ҩ����
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="m_strWindowid"></param>
        /// <param name="m_strSendwindowid"></param>
        /// <param name="m_intSID"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="m_objOutStorageDetail"></param>
        /// <param name="m_strSubtractMode"></param>
        /// <param name="m_strSecondLevelMode"></param>
        /// <returns></returns>
        public long m_lngDosage(clst_opr_nurseexecute[] p_objRecord, string m_strWindowid, string m_strSendwindowid, int m_intSID, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail, string m_strSubtractMode, string m_strSecondLevelMode, string p_strMedStoreID)
        {
            long lngRes = 0;

            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngDosageRecipe(objPrincipal, p_objRecord, m_strWindowid, m_strSendwindowid, m_intSID, p_objDetail, ref m_objOutStorageDetail, m_strSubtractMode, m_strSecondLevelMode, p_strMedStoreID);
            return lngRes;
        }
        #endregion
        #region ��ҩ����
        /// <summary>
        /// ��ҩ����
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="strwindowsID"></param>
        /// <param name="oldWinID"></param>
        /// <param name="m_intSID"></param>
        /// <returns></returns>
        public long m_lngDosage(clst_opr_nurseexecute[] p_objRecord, string strwindowsID, string oldWinID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngDosage(objPrincipal, p_objRecord, strwindowsID, oldWinID, m_intSID);
            return lngRes;
        }
        #endregion

        #region �˴���
        /// <summary>
        /// �˴���
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngBreak(clst_opr_nurseexecute[] p_objRecord, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngBreak(objPrincipal, p_objRecord, m_intSID);
            return lngRes;
        }
        #endregion

        #region ��˴�����������
        /// <summary>
        /// ��˴�����������
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="intStatus"></param>
        /// <param name="strCONFIRMDESC"></param>
        /// <param name="strEMPID"></param>
        /// <returns></returns>
        public long m_lngAuditing(clsOutpatientRecipe_VO[] p_objRecord, int intStatus, string strCONFIRMDESC, string strEMPID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngAuditing(objPrincipal, p_objRecord, intStatus, strCONFIRMDESC, strEMPID);
            return lngRes;
        }
        #endregion

        #region ����δ��ҩ����
        /// <summary>
        /// ����δ��ҩ����
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strCardID">���ƿ���</param>
        /// <param name="p_strPatient">��������</param>
        /// <param name="p_strRegNo">��ˮ��</param>
        /// <param name="p_strRegDate">�Һ�����</param>
        /// <param name="p_dtbResult">�������</param>
        /// <returns></returns>
        public long m_lngGetPatient(string p_strWinID, string p_strCardID, string p_strPatient,
            string p_strRegNo, string p_strRegDate, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPatient(objPrincipal, p_strWinID, p_strCardID, p_strPatient,
                p_strRegNo, p_strRegDate, out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region �Ƿ��Զ���ӡ��ҩ��
        /// <summary>
        /// �Ƿ��Զ���ӡ��ҩ��
        /// </summary>
        /// <param name="isAuto"></param>
        /// <returns></returns>
        public long m_mthIsAutoPrint(out bool isAuto)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_mthIsAutoPrint(out isAuto);
            return lngRes;
        }
        #endregion

        #region ͨ���Һ�ID���Ҵ���
        /// <summary>
        /// ͨ���Һ�ID���Ҵ���
        /// </summary>
        /// <param name="p_strID">�Һ�ID</param>
        /// <param name="p_objResult">�������</param>
        /// <returns></returns>
        public long m_lngGetRepiceListByRegID(string p_strID,
            out clsOutpatientRecipe_VO[] p_objResult, DateTime date1, DateTime date2, int intptatus, string strDep)
        {
            long lngRes = 0;
            p_objResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMainRecipe(objPrincipal, p_strID, out p_objResult, date1, date2, intptatus, strDep);
            return lngRes;
        }
        #endregion
        #region ͨ������ID���Ҵ���
        /// <summary>
        /// ͨ������ID���Ҵ���
        /// </summary>
        /// <param name="m_strSid"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetRepiceListBySid(string m_strSid, out clsOutpatientRecipe_VO[] p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetMainRecipe(objPrincipal, m_strSid, out p_objResult);
            return lngRes;
        }
        #endregion
        #region �������еķ�Ʊ�ţ��ַ�Ʊ��
        /// <summary>
        /// �������еķ�Ʊ�ţ��ַ�Ʊ��
        /// </summary>
        /// <param name="strOutpatrecipeid">�����ɣ�</param>
        /// <returns></returns>
        public string m_lngGetAllINVOICENO(string strOutpatrecipeid)
        {
            string strNO = "";
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            strNO = objSvc.m_lngGetAllINVOICENO(objPrincipal, strOutpatrecipeid);
            return strNO;
        }
        #endregion

        #region ͨ������IDȡ��ǰ��Ҫ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ������IDȡ��ǰ��Ҫ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strID">����ID</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinID(string p_strID,
            out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinID(objPrincipal, p_strID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ������IDȡ��ǰ��Ҫ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ������IDȡ��ǰ��Ҫ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strID">����ID</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByOPID(string p_strID,
            out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByOPID(objPrincipal, p_strID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźʹ�������ȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźʹ�������ȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strID">���ں�</param>
        /// <param name="p_intType">�������ͣ�1����ҩ��2����ҩ</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndType(string p_strID,
            int p_intType, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndType(objPrincipal, p_strID, p_intType, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźʹ���״̬ȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźʹ���״̬ȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strID">���ں�</param>
        /// <param name="p_intStatus">����״̬��1���½���2���ѷ�ҩ...</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndStatus(string p_strID,
            int p_intStatus, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndStatus(objPrincipal, p_strID, p_intStatus, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźͷ���Աȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźͷ���Աȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strEmpID">����Ա����</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndSendEmp(string p_strWinID,
            string p_strEmpID, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndSendEmp(objPrincipal, p_strWinID, p_strEmpID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźͷ���ʱ��ȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźͷ���ʱ��ȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strDate">����ʱ��</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndSendDate(string p_strWinID,
            string p_strDate, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndSendDate(objPrincipal, p_strWinID, p_strDate, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźʹ���Աȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźʹ���Աȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strEmpID">����Ա����</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndTreatEmp(string p_strWinID,
            string p_strEmpID, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndTreatEmp(objPrincipal, p_strWinID, p_strEmpID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ�����ںźʹ���ʱ��ȡ��ҩ�Ĵ�������
        /// <summary>
        /// ͨ�����ںźʹ���ʱ��ȡ��ҩ�Ĵ�������
        /// </summary>
        /// <param name="p_strWinID">���ں�</param>
        /// <param name="p_strDate">����ʱ��</param>
        /// <param name="p_objResultArr">�������</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndTreatDate(string p_strWinID,
            string p_strDate, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndTreatDate(objPrincipal, p_strWinID, p_strDate, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// <summary>
        /// ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// </summary>
        /// <param name="p_objItem">������������</param>
        /// <param name="winID">����ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, clsMedRecipeSend_VO p_objItem, DataTable dt, string stroageID, string strTOLMNY, clst_opr_nurseexecute[] nurseexecuteArr)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, p_objItem, dt, stroageID, strTOLMNY, nurseexecuteArr);
            return lngRes;
        }
        #endregion

        #region д���Ѵ�ӡ��־
        /// <summary>
        /// д���Ѵ�ӡ��־
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="m_intSID"></param>
        /// <returns></returns>
        public long m_lngPrintSucc(string winID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngPrintSucc(winID, m_intSID, 0);
            return lngRes;
        }
        #endregion

        #region ��ȡ����NO
        /// <summary>
        /// ��ȡ����NO
        /// </summary>
        /// <param name="strOUTPATRECIPEID"></param>
        /// <param name="RECORDDATE"></param>
        /// <param name="strPATIENTID"></param>
        /// <returns></returns>
        public string m_getOutpatientNO(string strOUTPATRECIPEID, string RECORDDATE, string strPATIENTID)
        {
            string strRes = "";

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            strRes = objSvc.m_getOutpatientNO(strOUTPATRECIPEID, RECORDDATE, strPATIENTID);
            return strRes;
        }
        #endregion

        #region ������ⵥ�޸Ŀ��
        /// <summary>
        /// ������ⵥ�޸Ŀ��
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="SaveRow"></param>
        /// <param name="SaveTableDe"></param>
        /// <returns>1-������2-��û������ҩ���������ͣ�3-û���ҵ���Ӧ��ҩƷ</returns>
        public long m_mthSaveData(DataRow SaveRow, DataTable SaveTableDe)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_mthSaveData(objPrincipal, SaveRow, SaveTableDe);
            return lngRes;
        }
        #endregion

        #region �����շ���Ŀ��ԴID
        /// <summary>
        /// �����շ���Ŀ��ԴID
        /// </summary>
        /// <param name="NewID"></param>
        /// <param name="oldID"></param>
        /// <returns></returns>
        public long m_lngGetID(string NewID,
            out string oldID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetID(objPrincipal, NewID, out oldID);
            return lngRes;
        }
        #endregion

        #region ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// <summary>
        /// ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬
        /// </summary>
        /// <param name="winID">����ID</param>
        /// <param name="m_intSID">���к�ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedCiPeByID(string winID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedCiPeByID(objPrincipal, winID, m_intSID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͨ������ID������ID����������ȡ��ǰ��Ҫ��ҩ�Ĵ�����¼
        /// <summary>
        /// ͨ������ID������ID����������ȡ��ǰ��Ҫ��ҩ�Ĵ�����¼
        /// </summary>
        /// <param name="p_strOPRecID">����ID</param>
        /// <param name="p_intType">��������</param>
        /// <param name="p_objResultArr">�������</param>
        ///  <param name="flag">��־λ,1-��ҩ����ҩ 2-������˴���</param>
        /// <returns></returns>
        public long m_lngGetOPRecipeListByWinAndOpRecAndType(
            string m_intSid, string p_intType, out DataTable p_objResultArr, int flag)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPRecipeListByWinAndOpRecAndType(objPrincipal, int.Parse(m_intSid),
                p_intType, out p_objResultArr, flag);
            return lngRes;
        }
        #endregion

        #region ͨ������ID������ID����������ȡ��ǰ��Ҫ��ҩ�Ĵ�����ϸ��������Ϣ
        /// <summary>
        /// ͨ������ID������ID����������ȡ��ǰ��Ҫ��ҩ�Ĵ�����ϸ��������Ϣ
        /// </summary>
        /// <param name="p_strOPRecID">����ID</param>
        /// <param name="p_strWinID">����ID</param>
        /// <param name="p_dtOutPatrecIp">���ش�����Ϣ</param>
        /// <param name="p_dtItemDe">���ش�����ϸ</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public long m_lngGetPrintItem(int m_intSID, string p_strWinID, out DataTable p_dtOutPatrecIp, out DataTable p_dtItemDe, int flag)
        {
            long lngRes = 0;
            p_dtOutPatrecIp = null;
            p_dtItemDe = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPrintItem(objPrincipal, m_intSID,
                p_strWinID, out p_dtOutPatrecIp, out p_dtItemDe, flag);
            return lngRes;
        }
        #endregion


        #region ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬(�Ƿ��Զ���ӡ��)
        /// <summary>
        /// ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬(�Ƿ��Զ���ӡ��)
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="arrList"></param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, System.Collections.ArrayList arrList, int m_intFlag)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, arrList, m_intFlag);
            return lngRes;
        }
        #endregion

        #region ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬(�Ƿ��Զ���ӡע�䵥)
        /// <summary>
        ///  ͨ��ID���ķ�ҩ�Ĵ�����¼��״̬(�Ƿ��Զ���ӡע�䵥)
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="arrList"></param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendTableByID(string winID, System.Collections.ArrayList arrList)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateRecipeSendTableByID(objPrincipal, winID, arrList);
            return lngRes;
        }
        #endregion

        #region ����ҩƷ���ţ����Ŀ�棩
        /// <summary>
        /// ����ҩƷ���ţ����Ŀ�棩
        /// </summary>
        /// <param name="p_strMedStoreID">ҩ��</param>
        /// <param name="p_strWinID">����</param>
        /// <param name="p_strOPRecID">������</param>
        /// <param name="p_intType">�������ͣ�1����ҩ��2����ҩ</param>
        /// <param name="p_intFlag">��־��1���ɹ���0��ʧ�ܣ�-1���쳣</param>
        /// <returns></returns>
        public long m_lngOPRecipeMedProvide(string p_strMedStoreID, string p_strWinID,
            string p_strOPRecID, int p_intType, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngOPRecipeMedProvide(objPrincipal, p_strMedStoreID, p_strWinID, p_strOPRecID,
                p_intType, out p_intFlag);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ���ݴ���ID����Ա�����Ƽ�����
        /// <summary>
        /// ���ݴ���ID����Ա�����Ƽ�����
        /// </summary>
        /// <param name="p_patrecipeid">����ID</param>
        /// <param name="p_strID">���Ա��ID</param>
        /// <param name="p_strName">���Ա����</param>
        public long m_lngFinaEmp(string p_patrecipeid, out string p_strID, out string p_strName)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngFinaEmp(objPrincipal, p_patrecipeid, out p_strID, out p_strName);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ô����������շ���ϸ
        /// <summary>
        /// ��ô����������շ���ϸ
        /// </summary>
        /// <param name="p_strOUTPATRECIPEID"></param>
        /// <param name="btpatientcnkre"></param>
        /// <param name="btpatientest"></param>
        /// <param name="btpatienOpsre"></param>
        /// <param name="btpatienothre"></param>
        /// <returns></returns>
        public long m_lngGetAll(string p_strOUTPATRECIPEID, out DataTable btpatientcnkre, out DataTable btpatientest, out DataTable btpatienOpsre, out DataTable btpatienothre)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetAll(objPrincipal, p_strOUTPATRECIPEID, out btpatientcnkre, out btpatientest, out btpatienOpsre, out btpatienothre);
            return lngRes;
        }
        #endregion

        #region ��ȡ���е���Ŀ����
        /// <summary>
        /// ��ȡ���е���Ŀ����
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindMedicine(out DataTable dt)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_mthFindMedicine(objPrincipal, out dt);
            return lngRes;
        }
        #endregion

        #region �ѷ�ҩ���������Ч����
        /// <summary>
        /// �ѷ�ҩ���������Ч����
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public long m_lngSetNullityData(string strID)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngSetNullityData(objPrincipal, strID);
            return lngRes;
        }
        #endregion

        #region �жϷ�Ʊ�Ƿ���Ч
        /// <summary>
        /// �жϷ�Ʊ�Ƿ���Ч
        /// </summary>
        /// <param name="INVOICENO"></param>
        /// <returns></returns>
        public bool m_blCheckOut(string INVOICENO)
        {
            bool lngRes;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_blCheckOut(INVOICENO);
            return lngRes;
        }
        #endregion

        #region ��ȡ����ҩ��������ָ��Ĵ���
        /// <summary>
        /// ��ȡ����ҩ��������ָ��Ĵ���
        /// </summary>
        public long m_longDutydt(string strStorageID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_longDutydt(strStorageID, out dt);
            return lngRes;
        }
        #endregion

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        public long m_lngGetOPDeptList(out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDeptList(null, out dt);
            return lngRes;
        }
        #endregion

        #region ���ݵ�������ȡ�÷��б�0 ע�䵥 1 ��ҺѲ�ӿ� 2 ��ƿ�� 3 ���Ƶ� 4 ������ 5 ��Ѫ�� 6 ��ҩ 7 ��ҩ
        /// <summary>
        /// ���ݵ�������ȡ�÷��б�0 ע�䵥 1 ��ҺѲ�ӿ� 2 ��ƿ�� 3 ���Ƶ� 4 ������ 5 ��Ѫ�� 6 ��ҩ 7 ��ҩ
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetUsagebyordertypeid(string typeid, out DataTable dtRecord)
        {
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            long res = objSvc.m_lngGetUsagebyordertypeid(typeid, out dtRecord);
            return res;
        }
        #endregion


        #region �����û����������ȡԱ������
        /// <summary>
        /// �����û����������ȡԱ������
        /// </summary>
        /// <param name="EmpNO"></param>
        /// <param name="EmpPw"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public long m_lngGetEmpName(string EmpNO, string EmpPw, out string EmpName, out string empID)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetEmpName(EmpNO, EmpPw, out EmpName, out empID);
            return lngRes;
        }
        #endregion

        #region ȡʱ��
        /// <summary>
        /// ȡʱ��
        /// </summary>
        /// <param name="p_datatime"></param>
        /// <returns></returns>
        public long m_lngGetServerDate(out DateTime p_datatime)
        {
            p_datatime = DateTime.Now;
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetServerDate(out p_datatime);
            return lngRes;
        }
        #endregion

        #region ȡ������Ϣ
        /// <summary>
        /// ȡ������Ϣ
        /// </summary>
        /// <param name="p_datatime"></param>
        /// <returns></returns>
        public long m_lngGetWindowInfo(out DataTable dtbResult, string p_strWINDOWID_CHR, string p_strMEDSTOREID_CHR)
        {
            dtbResult = null;
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetWindowInfo(out dtbResult, p_strWINDOWID_CHR, p_strMEDSTOREID_CHR);
            return lngRes;
        }
        #endregion

        #region GetSendMedInfo
        /// <summary>
        /// GetSendMedInfo
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public DataTable GetSendMedInfo(string recipeId)
        {
            clsMedStoreSvc svc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            return svc.GetSendMedInfo(recipeId);
        }
        #endregion

        #region �ж��Ƿ��ѷ�ҩ
        /// <summary>
        /// �ж��Ƿ��ѷ�ҩ
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool IsSendMed(string sid)
        {
            clsMedStoreSvc svc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            return svc.IsSendMed(sid);
        }
        #endregion

        #region ���ݲ���ID�Ϳ����Ա����ж��Ƿ���ڸ�Ա��
        /// <summary>
        /// ���ݲ���ID�Ϳ����Ա����ж��Ƿ���ڸ�Ա��
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        public long m_lngJudgeEmpByIDAndCode(string m_strDeptID, string m_strDeptSelfCode, out string m_strEMPID, out string m_strEMPName)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngJudgeEmpByIDAndCode(objPrincipal, m_strDeptID, m_strDeptSelfCode, out m_strEMPID, out m_strEMPName);
            return lngRes;

        }
        #endregion
        #region ����Ա�������ж��Ƿ���ڸ�Ա��
        /// <summary>
        /// ����Ա�������ж��Ƿ���ڸ�Ա��
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        public long m_lngJudgeEmpByEmpNo(string m_strEMPNO, out string m_strEMPID, out string m_strEMPName)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngJudgeEmpByEmpNo(objPrincipal, m_strEMPNO, out m_strEMPID, out m_strEMPName);
            return lngRes;

        }
        #endregion
        #region  ��ȡ�������Ƶ���Ӧ���÷�ID
        /// <summary>
        /// ��ȡ�������Ƶ���Ӧ���÷�ID
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetUsageIDByOrderID(string m_strOrderID, out DataTable m_objTable)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetUsageIDByOrderID(objPrincipal, m_strOrderID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region ��ȡ����ҽ������ҩ��Ϣ
        /// <summary>
        ///  ��ȡ����ҽ������ҩ��Ϣ
        /// </summary>
        /// <param name="m_strDepID"></param>
        /// <param name="m_strMedType"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetDoctorUseMedInfo(string m_strDepID, string m_strDoctorID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDoctorUseMedInfo(objPrincipal, m_strDepID, m_strDoctorID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        public long m_lngGetDoctorUseMedInfoByQuatity(string m_strDepID, string m_strDoctorID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDoctorUseMedInfoByQuatity(objPrincipal, m_strDepID, m_strDoctorID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        #endregion
        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="objDep"></param>
        /// <returns></returns>
        public long m_lngGetOPDeptInfo(out DataTable objDep)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDeptInfo(objPrincipal, out objDep);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// ��ȡҩƷ������Ϣ
        /// </summary>
        /// <param name="m_strMedType"></param>
        /// <param name="p_dtbData"></param>
        /// <returns></returns>
        public long m_lngGetMedTypeInfo(string m_strMedType, out DataTable p_dtbData)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetMedTypeInfo(objPrincipal, m_strMedType, out p_dtbData);
            return lngRes;

        }
        #region  ��ȡ����ҩƷ���ñ���
        /// <summary>
        /// ��ȡ����ҩƷ���ñ���
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetDeptMedFeePercentInfo(string m_strDeptID, string m_strCataID, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDeptMedFeePercentInfo(objPrincipal, m_strDeptID, m_strCataID, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        #endregion

        #region  ��ȡ����ҩƷ������Ϣ
        /// <summary>
        /// ��ȡ����ҩƷ������Ϣ
        /// </summary>
        /// <param name="m_strDepID"></param>
        /// <param name="m_strItemID"></param>
        /// <param name="m_strMedType"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long GetDoctorUseMedByItemId(string m_strDepID, string m_strItemID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.GetDoctorUseMedByItemId(objPrincipal, m_strDepID, m_strItemID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        #endregion

        #region ��ѯ�շ���Ŀ
        /// <summary>
        /// ��ѯ�շ���Ŀ
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="PatType">�������</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindChargeItem(string FindStr, string PatType, out DataTable dt)
        {
            clsOPMedStoreSvc objSvc =
                       (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            long l = objSvc.m_lngFindChargeItem(FindStr, PatType, out dt);
            objSvc.Dispose();

            return l;
        }

        #endregion
        /// <summary>
        /// �ж��Ƿ����㹻�Ŀ����Խ��пۼ�
        /// </summary>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_dtPutMedDetail"></param>
        /// <param name="m_strMsg"></param>
        /// <param name="m_htReturn"></param>
        /// <returns></returns>
        public bool m_lngJudgeHasEnoughStorage(string m_strDrugStoreid, DataTable m_dtPutMedDetail, out string m_strMsg, out Hashtable m_htReturn)
        {
            bool blnHasEnough = false;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));

            blnHasEnough = objSvc.m_lngJudgeHasEnoughStorage(m_strDrugStoreid, m_dtPutMedDetail, out m_strMsg, out m_htReturn);
            return blnHasEnough;

        }
        #region ���ݴ����Ų��ҷ��ʹ�������ID
        /// <summary>
        /// ���ݴ����Ų��ҷ��ʹ�������ID
        /// </summary>
        /// <param name="m_lngSid"></param>
        /// <param name="m_strStatus"></param>
        /// <returns></returns>
        public long m_lngGetRecipeSendStatusBySid(long m_lngSid, out string m_strStatus)
        {
            long lngRes = 0;
            clsMedStoreSvc m_objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = m_objSvc.m_lngGetRecipeSendStatusBySid(objPrincipal, m_lngSid, out m_strStatus);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ��ȡδ�䴦����Ϣ
        /// </summary>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetQueryUnDosageRecipeInfo(string strMedStoreid, string strBeginDate, string strEndDate, out DataTable m_objTable)
        {
            m_objTable = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetQueryUnDosageRecipeInfo(objPrincipal, strMedStoreid, strBeginDate, strEndDate, out m_objTable);
            return lngRes;

        }
        #region ���ݴ���id��ҩ��id��ȡΪ��ҩ������ϸ
        /// <summary>
        /// ���ݴ���id��ҩ��id��ȡΪ��ҩ������ϸ
        /// </summary>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        public long m_lngGetUnDosageRecipeDetailByid(string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            p_dtItemDe = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetUnDosageRecipeDetailByid(objPrincipal, m_strOPRecipeid, m_strMedStoreid, out p_dtItemDe);
            return lngRes;
        }
        #endregion

        #region ����ҩƷID��ѯ����ص�ҩƷ��Ϣ
        /// <summary>
        /// ����ҩƷID��ѯ����ص�ҩƷ��Ϣ
        /// </summary>
        /// <param name="p_strMedID"></param>
        /// <param name="p_strDosage"></param>
        /// <param name="p_strIpUnit"></param>
        /// <param name="p_strPrepType"></param>
        /// <returns></returns>
        public long m_lngGetMedDetailByMedID(string p_strMedID, out string p_strDosage, out string p_strIpUnit, out string p_strPrepType)
        {
            long lngRes = 0;
            p_strDosage = "";
            p_strIpUnit = "";
            p_strPrepType = "";

            #region �м������
            clsHisMedStoreSelect objServ = null;
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                lngRes = objServ.m_lngGetMedDetailByMedID(objPrincipal, p_strMedID, out p_strDosage, out p_strIpUnit, out p_strPrepType);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError("�����м�������쳣��" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region ��ȡϵͳʱ��
        /// <summary>
        /// ��ȡϵͳʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime m_datGetServerDate()
        {
            clsHisMedStoreSelect objSvc = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            return objSvc.m_datGetServerDate();
        }
        #endregion

        #region �������֤�Ż����籣�Ų�ѯ���ƿ���
        /// <summary>
        /// �������֤�Ż����籣�Ų�ѯ���ƿ���
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="p_strTable"></param>
        /// <returns></returns>
        public string m_strGetCardID(string p_strPatientID, string p_strTable)
        {
            clsHisMedStoreSelect objServ = null;
            string strCardID = "";
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                strCardID = objServ.m_strGetCardID(p_strPatientID, p_strTable);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError("�����м�������쳣��" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            return strCardID;
        }
        #endregion

        #region ��ѯҩƷ����
        /// <summary>
        /// ��ѯҩƷ����
        /// </summary>
        /// <param name="lstMedId"></param>
        /// <returns></returns>
        public void GetMedPrepType(List<string> lstMedId, out Dictionary<string, string> dicPrepType, out Dictionary<string, string> dicIpUnit, out Dictionary<string, string> dicMedBagUnit)
        {
            clsHisMedStoreSelect svc = null;
            dicPrepType = new Dictionary<string, string>();
            dicIpUnit = new Dictionary<string, string>();
            dicMedBagUnit = new Dictionary<string, string>();
            try
            {
                svc = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                svc.GetMedPrepType(lstMedId, out dicPrepType, out dicIpUnit, out dicMedBagUnit);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError("�����м�������쳣��" + ex.Message);
            }
            finally
            {
                if (svc != null)
                {
                    svc.Dispose();
                    svc = null;
                }
            }
        }
        #endregion

        #region ���÷�
        /// <summary>
        /// ���÷�
        /// </summary>
        /// <param name="strMedUsageID"></param>
        /// <param name="dtKFUsageID"></param>
        public void GetMedUsageID(string strMedUsageID, ref DataTable dtKFUsageID)
        {
            clsHisMedStoreSelect objServ = null;
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                objServ.m_lngGetMedUsageID(strMedUsageID, ref dtKFUsageID);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError("�����м�������쳣��" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
        }

        #endregion

        #region ͨ����Ʊ�Ų�ѯ������Ϣ
        /// <summary>
        /// ͨ����Ʊ�Ų�ѯ������Ϣ
        /// </summary>
        /// <param name="invoNo"></param>
        /// <returns></returns>
        public DataTable GetPatInfoByInvo(string invoNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc));
            return svc.GetPatInfoByInvo(invoNo);
        }
        #endregion

        #region ΢�ż���Ƿ��
        /// <summary>
        /// ΢�ż���Ƿ��
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsWechatBanding(string cardNo)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.IsWechatBanding(cardNo);
            }
        }
        #endregion

        #region ͨ������ID��ȡ���ƿ���
        /// <summary>
        /// ͨ������ID��ȡ���ƿ���
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public string GetCardNoByRecipeId(string recipeId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.GetCardNoByRecipeId(recipeId);
            }
        }
        #endregion

        #region ���ʹ�����ҩ����

        #region ��ѯ���ʹ�����ҩ����Դ�б�
        /// <summary>
        /// ��ѯ���ʹ�����ҩ����Դ�б�
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="opIp">1 ����; 2 סԺ</param>
        /// <returns></returns>
        public DataTable QueryProxyBoilMed(string startDate, string endDate, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.QueryProxyBoilMed(startDate, endDate, opIp);
            }
        }
        #endregion

        #region ��ѯ���ʹ�����ҩ��ϸ
        /// <summary>
        /// ��ѯ���ʹ�����ҩ��ϸ
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="recipeNo"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        public DataTable QueryProxyBoilMedDet(string recipeId, string recipeNo, string recipeDate, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.QueryProxyBoilMedDet(recipeId, recipeNo, recipeDate, opIp);
            }
        }
        #endregion

        #region ����Ƿ��ѷ���
        /// <summary>
        /// ����Ƿ��ѷ���
        /// </summary>
        /// <param name="putMedIds"></param>
        /// <returns></returns>
        public bool CheckIsSend(string putMedIds, bool isEqual)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.CheckIsSend(putMedIds, isEqual);
            }
        }
        #endregion

        #region ���ʹ���ҩת������ҩ��
        /// <summary>
        /// ���ʹ���ҩת������ҩ��
        /// </summary>
        /// <param name="recipeIds"></param>
        /// <param name="putMedIds"></param>
        /// <param name="operId"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        public int ConvertMedStore(string recipeIds, string putMedIds, string operId, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.ConvertMedStore(recipeIds, putMedIds, operId, opIp);
            }
        }
        #endregion

        #endregion

    }
}
