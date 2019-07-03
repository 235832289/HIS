using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// clsDomainControl_Register ��ժҪ˵����
    /// </summary>
    public class clsDomainControl_RegisterAuto : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainControl_RegisterAuto()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #region ���������շ���Ŀά��

        #region ������еĲ�������
        /// <summary>
        /// ������еĲ�������
        /// </summary>
        /// <param name="btPatientPayType"></param>
        /// <returns></returns>
        public long m_lngGetAllPatientPayType(out DataTable btPatientPayType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc));
            lngRes = objSvc.m_lngGetAllPatientPayType(objPrincipal, out btPatientPayType);
            return lngRes;
        }
        #endregion

        #region ������Ŀ��ϸ
        /// <summary>
        /// ������Ŀ��ϸ
        /// </summary>
        /// <param name="strPayTypeID"></param>
        /// <param name="strItemId"></param>
        /// <param name="intQty"></param>
        /// <returns></returns>
        public long m_lngAddNewItem(string strPayTypeID, string strItemId, int intQty, int REGISTER, int RECIPEFLAG, int EXPERT)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc));
            lngRes = objSvc.m_lngAddNewItem(objPrincipal, strPayTypeID, strItemId, intQty, REGISTER, RECIPEFLAG, EXPERT);
            return lngRes;
        }
        #endregion


        #region ɾ����Ŀ
        /// <summary>
        /// ɾ����Ŀ
        /// </summary>
        /// <param name="strPayTypeID"></param>
        /// <param name="strItemId"></param>
        /// <returns></returns>
        public long m_lngDeleItem(string strPayTypeID, string strItemId)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc));
            lngRes = objSvc.m_lngDeleItem(objPrincipal, strPayTypeID, strItemId);
            return lngRes;
        }
        #endregion

        #region �޸���Ŀ����
        /// <summary>
        /// ������Ŀ��ϸ
        /// </summary>
        /// <param name="strPayTypeID"></param>
        /// <param name="strItemId"></param>
        /// <param name="intQty"></param>
        /// <returns></returns>
        public long m_lngModifyItem(string strPayTypeID, string strOldItemId, string strItemId, int intQty, int REGISTER, int RECIPEFLAG, int EXPERT)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc));
            lngRes = objSvc.m_lngModifyItem(objPrincipal, strPayTypeID, strOldItemId, strItemId, intQty, REGISTER, RECIPEFLAG, EXPERT);
            return lngRes;
        }
        #endregion

        #region ���ݲ�������ID��ȡ��Ŀ����
        /// <summary>
        /// ���ݲ�������ID��ȡ��Ŀ����
        /// </summary>
        /// <param name="strPayTypeID"></param>
        /// <param name="bt"></param>
        /// <returns></returns>
        public long m_lngGetItemByPayID(string strPayTypeID, out DataTable bt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsConcertreCipeSvc));
            lngRes = objSvc.m_lngGetItemByPayID(objPrincipal, strPayTypeID, out bt);
            return lngRes;
        }
        #endregion

        #endregion

        #region ���ҹҺ�����
        /// <summary>
        /// ���ҹҺ�����
        /// </summary>
        public long m_lngGetRegType(out clsRegisterType_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsRegisterType_VO[0];
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetRegType(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region ��ѯ������Ϣ
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="Sex"></param>
        /// <param name="brith"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindPatient(string strName, string Sex, string brith, out DataTable dt)
        {
            long lngRes = 0;
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngFindPatient(objPrincipal, strName, Sex, brith, out dt);
            return lngRes;
        }
        #endregion

        #region ���Ҳ�������
        /// <summary>
        /// ���Ҳ�������
        /// </summary>
        public long m_lngGetPatType(out clsPatientType_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsPatientType_VO[0];
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngGetPatType(objPrincipal, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region ����ID���ҹҺŷ���
        /// <summary>
        /// ����ID���ҹҺŷ���
        /// </summary>
        /// <param name="PatTypeID"></param>
        /// <param name="RegTypeID"></param>
        /// <param name="clsVO"></param>
        public long m_lngFindPatRegFeeByID(string PatTypeID, string RegTypeID, out clsPatRegFee_VO clsVO)
        {
            long lngRes = 0;
            clsVO = new clsPatRegFee_VO();
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc));
            lngRes = objSvc.m_lngFindFeeListByID(objPrincipal, RegTypeID, PatTypeID, out clsVO);

            return lngRes;
        }
        #endregion

        #region ���ҹҺŷ���
        /// <summary>
        /// ���ҹҺŷ���
        /// </summary>
        /// <param name="dtResult"></param>
        public long m_lngFindPatRegFee(ref DataTable dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc));
            lngRes = objSvc.m_lngFindFeeList(objPrincipal, ref dtResult);

            return lngRes;
        }
        #endregion

        #region ����Һŷ���
        /// <summary>
        /// ����Һŷ���
        /// </summary>
        /// <param name="clsVO"></param>
        /// <param name="IsNew"></param>
        public long m_lngSavePatRegFee(clsPatRegFee_VO clsVO, bool IsNew)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc));
            if (IsNew) //����
                lngRes = objSvc.m_lngNewFeeList(objPrincipal, clsVO);
            else
                lngRes = objSvc.m_lngUPDateFeeList(objPrincipal, clsVO);

            return lngRes;
        }
        #endregion

        #region ɾ���Һŷ���
        /// <summary>
        /// ɾ���Һŷ���
        /// </summary>
        /// <param name="clsVO"></param>
        public long m_lngDelPatRegFee(clsPatRegFee_VO clsVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc));
            lngRes = objSvc.m_lngDelFeeList(objPrincipal, clsVO);

            return lngRes;
        }
        #endregion

        #region �������ƿ���ȡ�ò��˵���Ϣ
        /// <summary>
        /// �������ƿ���ȡ�ò��˵���Ϣ
        /// </summary>
        /// <param name="strCardID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetPatByCard(string strCardID, out clsPatient_VO p_objResultArr, string registerDate, out string DepName, out string doctorName, out string registerDate1)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngGetPatByCardID(objPrincipal, strCardID, out p_objResultArr, registerDate, out DepName, out doctorName, out registerDate1);

            return lngRes;
        }
        #endregion

        #region ��ѯ�ҹҺ�����״̬
        /// <summary>
        /// ��ѯ�ҹҺ�����״̬
        /// </summary>
        /// <param name="strTypeid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public long m_lngFindType(string strTypeid, out string command)
        {
            command = "";
            long lngRes = 0;
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngFindType(objPrincipal, strTypeid, out command);

            return lngRes;
        }
        #endregion

        #region ��ȡ��ǰʱ�εĹҺſ�����Ϣ
        /// <summary>
        /// ��ȡ��ǰʱ�εĹҺſ�����Ϣ
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="strPerio"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetPlanDepByDate(string strDate, string strPerio, out clsDepartmentVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsDepartmentVO[0];
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetOPDeptListByDate(objPrincipal, strDate, strPerio, out p_objResultArr);

            return lngRes;
        }
        #endregion


        #region ��ȡ��ǰʱ�εĹҺſ�����Ϣ

        public long m_lngGetPlanDep(string strDate, string strPerio, out clsDepartmentVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsDepartmentVO[0];
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetOPDeptList(objPrincipal, strDate, strPerio, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region ��ȡҽ���б�
        /// <summary>
        /// ��ȡҽ���б�
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="strPerio"></param>
        /// <param name="strDepID"></param>
        /// <param name="strRegType"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetOPDoctorList(string strDepID, out clsEmployeeVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsEmployeeVO[0];
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetOPDoctorListForReg(objPrincipal, strDepID, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region ��ȡû�п�������Ա��
        /// <summary>
        /// ��ȡû�п�������Ա��
        /// </summary>
        /// <returns></returns>
        public long m_lngGetEmployeeNo(out DataTable p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new DataTable();
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetEmployeeNo(objPrincipal, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region ����Ƿ��е�ǰʱ�ε��Ű��¼
        public bool m_bnlCheckPlanByDatePerio(string strDate, string strPerio)
        {
            bool bnlRes = false;
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            bnlRes = objSvc.m_bnlCheckPlanByDatePerio(objPrincipal, strDate, strPerio);

            return bnlRes;
        }
        #endregion

        #region ��ȡĳ��ҽ���ļƻ���Ϣ
        /// <summary>
        /// ��ȡĳ��ҽ���ļƻ���Ϣ
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="strPerio"></param>
        /// <param name="strDocID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetDocPlan(string strDate, string strPerio, string strDocID,
            out clsOPDoctorPlan_VO p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsOPDoctorPlan_VO();
            //			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetDocPlan(objPrincipal, strDate, strPerio, strDocID, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region �����Һż�¼
        /// <summary>
        /// �����Һż�¼
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <param name="strID"></param>
        /// <param name="strNo"></param>
        /// <param name="strOrderNo"></param>
        /// <param name="intRegCount"></param>
        /// <returns></returns>
        public long m_lngAddRegister(clsPatientRegister_VO p_objResultArr, out string strID, out string strNo, out string strOrderNo, out string intRegCount, clsPatient_VO clsPatientvo, int isNewPatient, string strCardID, out string outCardID, clsPatientDetail_VO[] PatientDetail_VO, string strNO, string strPatienID, string patientidentityno)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngAddNewPatientRegister(objPrincipal, p_objResultArr, out strID, out strNo, out strOrderNo, out intRegCount, clsPatientvo, isNewPatient, strCardID, out outCardID, PatientDetail_VO, strPatienID, patientidentityno);
            return lngRes;
        }
        public long m_lngAddRegisterDegail(clsPatientDetail_VO p_objResultArr)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            lngRes = objSvc.m_lngAddNewRegDetail(p_objPrincipal, p_objResultArr);
            return lngRes;
        }
        #endregion

        #region ȡ�÷������ĵ�ǰʱ��
        public DateTime m_GetServTime()
        {
            DateTime DTR;
            com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate));
            DTR = objSvc.m_GetServerDate();
            return DTR;
        }
        #endregion

        #region ���ص�ǰҽ���ѽ�������
        public int m_GetDocTakeCout(string strDocID, string RegDate)
        {
            int intCount = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            objSvc.m_lngGetDocTakeCount(objPrincipal, strDocID, RegDate, out intCount);
            return intCount;
        }
        #endregion

        #region �޸ĹҺ�
        public long m_lngModifyRegister(clsPatientRegister_VO objResult)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngDoUpdPatientRegisterByID(p_objPrincipal, objResult);
            return LngArg;
        }
        public long m_lngModifyRegisterDetail(clsPatientDetail_VO objResult)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngModifyRegDetail(p_objPrincipal, objResult);
            return LngArg;
        }
        #endregion

        #region ��ȡ���ñ�
        public long m_lngGetPay(out clsRegisterPay[] m_clsRegisterPay)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            m_clsRegisterPay = new clsRegisterPay[0];
            com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsPatRegFeeSvc));
            long LngArg = objSvc.m_lngGetRegCharge(p_objPrincipal, out m_clsRegisterPay);
            return LngArg;
        }
        #endregion

        #region ���ҹҺ�(��)
        /// <summary>
        /// ���ҹҺ�
        /// </summary>
        /// <param name="firstdate"></param>
        /// <param name="lastdate"></param>
        /// <param name="dtRegister"></param>
        /// <returns></returns>
        public long m_lngQulRegByDateNew(string firstdate, string lastdate, out DataTable dtRegister, string EmpID, string Scope)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegByDateNew(p_objPrincipal, out dtRegister, firstdate, lastdate, EmpID, Scope);
            return LngArg;
        }
        #endregion
        #region �����ֶβ��ҹҺ�(��)
        /// <summary>
        ///  �����ֶβ��ҹҺ�(��)
        /// </summary>
        /// <param name="m_strArr"></param>
        /// <param name="dtRegister"></param>
        /// <returns></returns>
        public long m_lngQulRegByFieldNew(string[] m_strArr, out DataTable dtRegister)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegByFieldNew(p_objPrincipal, m_strArr, out dtRegister);
            return LngArg;
        }
        #endregion

        #region ���ùҺ��Ƿ��չ���
        /// <summary>
        /// ���ùҺ��Ƿ��չ���
        /// </summary>
        /// <param name="registerID"></param>
        /// <param name="isReMoney"></param>
        /// <returns></returns>
        public long m_lngCheckRegister(string registerID, out bool isReMoney, out string outstr)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngCheckRegister(p_objPrincipal, registerID, out isReMoney, out outstr);
            return LngArg;
        }
        #endregion

        #region ��ȡ�Һ����͵�״̬
        /// <summary>
        /// ��ȡ�Һ����͵�״̬
        /// </summary>
        /// <param name="strTypeID"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        public long m_lngGetPatTypeFLAG(string strTypeID, out int intType)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPatTypeFLAG(p_objPrincipal, strTypeID, out intType);
            return LngArg;
        }
        #endregion

        #region ���ҹҺ�
        /// <summary>
        /// ���ҹҺ�
        /// </summary>
        /// <param name="firstdate"></param>
        /// <param name="lastdate"></param>
        /// <param name="dtRegister"></param>
        /// <returns></returns>
        public long m_lngQulRegByDate(string firstdate, string lastdate, out DataTable dtRegister)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegByDate(p_objPrincipal, out dtRegister, firstdate, lastdate);
            return LngArg;
        }
        #endregion

        #region �����ֶβ��ҹҺ�
        public long m_lngQulRegByCol(out DataTable dtRegister, string strFeilt, string strValue, string Option)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegByCol(p_objPrincipal, out dtRegister, strFeilt, strValue, Option);
            return LngArg;
        }
        #endregion

        #region ��ȡ�Һŷ���
        /// <summary>
        /// ��ȡ�Һŷ���
        /// </summary>
        /// <param name="strRegister"></param>
        /// <param name="dtRegister"></param>
        /// <returns></returns>
        public long m_lngQulRegDetail(string strRegister, out DataTable dtRegister)
        {
            dtRegister = new DataTable();
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegDetailByID(p_objPrincipal, strRegister, out dtRegister);
            return LngArg;
        }
        #endregion

        #region ��ȡ�Һŷ���(��ѯ��)
        /// <summary>
        /// ��ȡ�Һŷ���
        /// </summary>
        /// <param name="strRegister"></param>
        /// <param name="dtRegister"></param>
        /// <returns></returns>
        public long m_lngQulRegDetailfind(string strRegister, out DataTable dtRegister)
        {
            dtRegister = new DataTable();
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngQulRegDetailByIDFind(p_objPrincipal, strRegister, out dtRegister);
            return LngArg;
        }
        #endregion

        #region �˺�
        /// <summary>
        /// �˺�
        /// </summary>
        /// <param name="strRegisterID"></param>
        /// <param name="strReturnRegEmpno"></param>
        /// <param name="strReturnDate"></param>
        /// <returns></returns>
        public long m_lngCancelReg(string strRegisterID, string strReturnRegEmpno, string strReturnDate, string ConfirmID, out string newID)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngCancelReg(p_objPrincipal, strRegisterID, strReturnRegEmpno, strReturnDate, ConfirmID, out newID);
            return LngArg;
        }
        #endregion

        #region �շѽ����ձ���

        public long m_lngGetPayTypeAndCheckOutData(string OPREMPID, string strDate, out DataTable dtPayType, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutData(p_objPrincipal, OPREMPID, strDate, out dtPayType, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
            return LngArg;
        }

        public long GetCheckOutData(string OPREMPID, string strDate, string strRptId, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.GetCheckOutData(p_objPrincipal, OPREMPID, strDate, strRptId, out dtCheckOut);
            return LngArg;
        }

        public long GetCheckOutData(int intMode, string OPREMPID, string strStartDate, string strEndDate, string strRptId, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.GetCheckOutData(p_objPrincipal, intMode, OPREMPID, strStartDate, strEndDate, strRptId, out dtCheckOut);
            return LngArg;
        }

        #region �շ�Ա�սᱨ��ֿ���ӡ
        /// <summary>
        /// �շ�Ա�սᱨ��ֿ���ӡ
        /// </summary>
        /// <param name="CheckDate">��������</param>
        /// <param name="checkMan">������</param>
        /// <param name="dt1">�ֽ��սᱨ��</param>
        /// <param name="dtDe1">�ֽ��սᱨ��(��ϸ)</param>
        /// <param name="dt2">ҽ����ˢ���սᱨ��</param>
        ///  <param name="dtDe2">ҽ����ˢ���սᱨ��(��ϸ)</param>
        /// <param name="dt3">�����սᱨ��</param>
        /// <param name="dtDe3">�����սᱨ��(��ϸ)</param>
        /// <param name="dt4">�����սᱨ��</param>
        /// <param name="dtDe4">�����սᱨ��(��ϸ)</param>
        /// <param name="dtType">�շ�����</param>
        /// <returns></returns>
        public long m_lngGetDataAllOfStat(string CheckDate, string checkMan, out DataTable dt1, out DataTable dtDe1, out DataTable dt2, out DataTable dtDe2, out DataTable dt3, out DataTable dtDe3, out DataTable dt4, out DataTable dtDe4, out DataTable dtType)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetDataAllOfStat(p_objPrincipal, CheckDate, checkMan, out dt1, out dtDe1, out dt2, out dtDe2, out dt3, out dtDe3, out dt4, out dtDe4, out dtType);
            return LngArg;
        }
        #endregion

        #region ����(��,ͣ��)
        public long m_lngCheckData(DataTable dt, string CheckName, string CheckDate)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngCheckData(p_objPrincipal, dt, CheckName, CheckDate);
            return LngArg;
        }
        #endregion

        #region ����(��)
        /// <summary>
        /// ����(��)
        /// </summary>
        /// <param name="OperID">�տ�ԱID</param>
        /// <param name="CheckDate">�ս�ʱ��</param>
        /// <returns></returns>
        public long m_lngCheckData(string OperID, out string CheckDate)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));

            long l = objSvc.m_lngCheckData(OperID, out CheckDate);
            objSvc.Dispose();
            return l;
        }

        /// <summary>
        /// ָ������ǰ����
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="strIdentCheckDate">ָ������</param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public long CheckDataByDate(string OperID, string strIdentCheckDate, out string CheckDate)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));

            long l = objSvc.m_lngCheckDataByDate(OperID, strIdentCheckDate, out CheckDate);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region ��ʷ��ѯ
        public long m_lngGetHistory(string startDate, string endDate, string checkMan, out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetHistor(p_objPrincipal, startDate, endDate, checkMan, out dt);
            return LngArg;
        }
        #endregion

        #region ��ʷ��ѯ����
        public long m_lngGetPayTypeAndCheckOutDatahistory(string strDate, string BALANCEEMP, out DataTable dtPayType, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutDatahistory(p_objPrincipal, strDate, BALANCEEMP, out dtPayType, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
            return LngArg;
        }

        public long GetCheckOutHistory(string strDate, string BALANCEEMP, string strRptId, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.GetCheckOutHistory(p_objPrincipal, strDate, BALANCEEMP, strRptId, out dtCheckOut);
            return LngArg;
        }
        #endregion

        #endregion

        #region ��ȡĬ�ϵĴ�ӡ״̬
        /// <summary>
        /// ��ȡĬ�ϵĴ�ӡ״̬
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="STATUSINT">0,Ĭ�ϴ�ӡ��1,����ӡ�� -2��û������Ĭ��ֵ</param>
        /// <returns></returns>
        public long m_lngPrint(string strID, out int STATUSINT)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngPrint(p_objPrincipal, strID, out STATUSINT);
            return LngArg;
        }
        #endregion

        #region ��ȡ�˺ŵ�״̬
        /// <summary>
        /// ��ȡ�˺ŵ�״̬
        /// </summary>
        /// <param name="strSetStatus"></param>
        /// <returns></returns>
        public long m_lngGetSetStatus(out int strSetStatus)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetSetStatus(p_objPrincipal, out strSetStatus);
            return LngArg;
        }
        #endregion

        #region �˿�ϵͳ
        #region �������ڷ��ؼ�������Ϣ
        public long m_lngGetCarData(string startDate, string endDate, out DataTable dt, string strCardID, string strName)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngGetCarData(objPrincipal, startDate, endDate, out dt, strCardID, strName);
            return lngRes;
        }
        #endregion
        #region �˿�
        public long m_lngReturnCar(string CarID, string patientNO)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngReturnCar(objPrincipal, CarID, patientNO);
            return lngRes;
        }
        #endregion
        #region �޸Ŀ���
        public long m_lngUpdateCar(string CarID, string patientNO, string strEmpID, string oldCardID)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngUpdateCar(objPrincipal, CarID, patientNO, strEmpID, oldCardID);
            return lngRes;
        }
        #endregion
        #region �жϿ����Ƿ��Ѿ�����
        /// <summary>
        /// �жϿ����Ƿ��Ѿ�����
        /// </summary>
        /// <param name="CarID"></param>
        /// <returns>����3����</returns>
        public long m_lngCheckCarID(string CarID)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngCheckCarID(objPrincipal, CarID);
            return lngRes;
        }
        #endregion
        #endregion

        #region ��ԭ�˺�
        public long m_lngResetReg(string strRegisterID, string strResetRegEmpno, string strResetRegDate, out string newID, out int waitNO)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngResetReg(p_objPrincipal, strRegisterID, strResetRegEmpno, strResetRegDate, out newID, out waitNO);
            return LngArg;
        }
        #endregion

        #region ��鷢Ʊ��
        /// <summary>
        /// ��鷢Ʊ��
        /// </summary>
        /// <param name="strNO"></param>
        /// <returns></returns>
        public long m_lngCheckNO(string strNO, out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngCheckNO(p_objPrincipal, strNO, out dt);
            return LngArg;
        }
        #endregion

        #region ��ȡĳһ���Ű�ƻ�
        public long m_lngGetTodayPlan(out clsOPDoctorPlan_VO[] p_objResult)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            DateTime date = m_GetServTime();
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            long lngarg = objSvc.m_lngGetPlanByday(p_objPrincipal, date.ToShortDateString(), out p_objResult);
            return lngarg;
        }
        public long m_lngGetTodayPlanByDate(string strdate, out clsOPDoctorPlan_VO[] p_objResult)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            long lngarg = objSvc.m_lngGetPlanByday(p_objPrincipal, strdate, out p_objResult);
            return lngarg;
        }

        public long m_lngGetSomedayPlan(DateTime date, out clsOPDoctorPlan_VO[] p_objResult)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc));
            long lngarg = objSvc.m_lngGetPlanByday(p_objPrincipal, date.ToShortDateString(), out p_objResult);
            return lngarg;
        }
        #endregion

        #region ��Ʊ����

        #region ��ȡ���еķ�Ʊ����
        /// <summary>
        /// ��ȡ���еķ�Ʊ����
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetAllData(out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetAllData(p_objPrincipal, out dt);
            return LngArg;
        }
        #endregion

        #region ���Ϸ�Ʊ
        /// <summary>
        /// ���Ϸ�Ʊ
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public long m_lngCancel(string strID, string acctID, DateTime AccDate)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngCancel(p_objPrincipal, strID, acctID, AccDate);
            return LngArg;
        }
        #endregion

        #region ���ݹ��Ų���Ա��
        /// <summary>
        /// ���ݹ��Ų���Ա��
        /// </summary>
        /// <param name="strNO"></param>
        /// <param name="dtEmp"></param>
        /// <returns></returns>
        public long m_lngfindEmp(string strNO, out DataTable dtEmp)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngfindEmp(p_objPrincipal, strNO, out dtEmp);

            return LngArg;
        }
        #endregion

        #region �������
        /// <summary>
        ///������� 
        /// </summary>
        /// <param name="AddRow"></param>
        /// <returns></returns>
        public long m_lngAddNew(DataRow AddRow, out string newID)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngAddNew(p_objPrincipal, AddRow, out newID);

            return LngArg;
        }
        #endregion
        #endregion

        #region ��ȡ�շ�Ա�ĵ�����շѼ�¼
        public long m_lngGetOneDayData(string OPREMPID, string strDate, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetOneDayData(p_objPrincipal, OPREMPID, strDate, out dtCheckOut);

            return LngArg;
        }

        #endregion

        #region ��ȡĳһ��ʱ��Ľ��ʼ�¼
        public long m_lngGetPayTypeAndCheckOutBetWeenDate(string startDate, string EndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtEmp, string strINTERNALFLAG, string strCheckMan)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutBetWeenDate(p_objPrincipal, startDate, EndDate, out dtPayType, out dtCheckOut, out dtEmp, strINTERNALFLAG, strCheckMan);
            return LngArg;
        }

        #endregion

        #region ��ȡĳһ�յĽ��ʼ�¼
        public long m_lngGetPayTypeAndCheckOutBetWeenDay(string strBeginDate, string strEndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtRecipesumde, out DataTable dtPayment, out DataTable dtEmp, string INTERNALFLAG, string CheckOutName)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutBetWeenDay(p_objPrincipal, strBeginDate, strEndDate, out dtPayType, out dtCheckOut, out dtRecipesumde, out dtPayment, out dtEmp, INTERNALFLAG, CheckOutName);
            return LngArg;
        }
        #endregion
        #region ��ȡĳһ�յĿ��ҽ��ʼ�¼
        public long m_lngGetPayTypeAndCheckOutBetofDept(string strBeginDate, string strEndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtEmp, string INTERNALFLAG, string CheckOutName)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutBetOfDept(p_objPrincipal, strBeginDate, strEndDate, out dtPayType, out dtCheckOut, out dtEmp, INTERNALFLAG, CheckOutName);
            return LngArg;
        }
        #endregion
        #region ������н���Ա����
        public long m_lngGetCheckMan(out DataTable dtEmpAll, string strINTERNALFLAG)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetCheckMan(p_objPrincipal, out dtEmpAll, strINTERNALFLAG);
            return LngArg;
        }

        public long m_lngGetAllCheckMan(out DataTable dtEmpAll)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetAllCheckMan(p_objPrincipal, out dtEmpAll);
            return LngArg;
        }
        #endregion
        #region ������п�������
        public long m_lngGetDeptInfo(out DataTable dtDeptAll, string strINTERNALFLAG)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetDeptInfo(p_objPrincipal, out dtDeptAll, strINTERNALFLAG);
            return LngArg;
        }
        #endregion

        #region ����ͳ�Ʊ�
        public long m_lngGetPublicMoney(string startDate, string endDate, out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPublicMoney(p_objPrincipal, startDate, endDate, out dt);
            return LngArg;
        }

        public long m_lngGetGopRla(out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetGopRla(p_objPrincipal, out dt);
            return LngArg;
        }
        #endregion

        #region ����������ͳ�Ʊ���
        /// <summary>
        /// ����������ͳ�Ʊ���
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="EndDate">����ʱ��</param>
        /// <param name="dtPayType">�����շ�����</param>
        /// <param name="dtCheckOut">�����շ�����</param>
        /// <param name="dtCheckOutDe">�����շ���ϸ���ݱ�</param>
        /// <param name="dtEmp">�����շ�Ա�б�</param>
        /// <param name="isOne">�����շ�ԱID��ALLȫ��ͳ��</param>
        /// <param name="isFull">ָ�Ƿ���������������ݷֿ�ͳ��-1-ͳ���������������(ҽ������0-����ͳ����������(ҽ������1-����ͳ�ƺ������(ҽ����.2-ͳ��������������ݣ����ѣ���3-����ͳ���������ݣ����ѣ���4-����ͳ�ƺ�����ݣ����ѣ���5-ͳ��������������ݣ��Էѣ���6-����ͳ���������ݣ��Էѣ���7-����ͳ�ƺ�����ݣ��Էѣ���8-ͳ��������������ݣ���������9-����ͳ���������ݣ���������10-����ͳ�ƺ�����ݣ�������</param>
        /// <returns></returns>
        public long m_lngGetIatrical(string startDate, string EndDate, out DataTable dtPayType, out DataTable dtCheckOut, out DataTable dtCheckOutDe, out DataTable dtEmp, string isOne, string isFull)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetIatrical(p_objPrincipal, startDate, EndDate, out dtPayType, out dtCheckOut, out dtCheckOutDe, out dtEmp, isOne, isFull);
            return LngArg;
        }


        public long m_lngReturnAllBALANCEEMP(out DataTable dt)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngReturnAllBALANCEEMP(p_objPrincipal, out dt);
            return LngArg;
        }
        #endregion

        #region ����ܷ���һЩϵͳ���õĲ���
        public bool m_mthIsCanDo(string strID)
        {
            bool isCheck = false;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            isCheck = objSvc.m_mthIsCanDo(strID);
            return isCheck;
        }
        #endregion

        /// <summary>
        /// ���ݴ���������ȡ�ѽ���������Ϣ
        /// </summary>
        /// <param name="m_strCheckManID"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="strRptId"></param>
        /// <param name="m_dtCheckOutData"></param>
        /// <returns></returns>
        public long m_lngGetCheckedOutDataByCondition(int m_intStatDateType,string m_strCheckManID,string m_strBalanceDeptID, string m_strBeginTime, string m_strEndTime, string strRptId, ArrayList fysfcdeptidARR, out DataTable m_dtCheckOutData)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
             (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngGetCheckedOutDataByCondition(objPrincipal,m_intStatDateType, m_strCheckManID,m_strBalanceDeptID, m_strBeginTime, m_strEndTime, strRptId,fysfcdeptidARR, out m_dtCheckOutData);
            return lngRes;
        }
        #region �����շѲ�ѯģ��
        #region ����ʱ��λ�ȡ��Ʊ����
        /// <summary>
        /// ����ʱ��λ�ȡ��Ʊ����
        /// </summary>
        /// <param name="strDateStart"></param>
        /// <param name="strDateEnd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeByDate(string strDateStart, string strDateEnd, out DataTable dt)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeByDate(p_objPrincipal, strDateStart, strDateEnd, out dt);
            return lngRes;
        }
        #endregion

        #region ���ݲ�ѯ���������ݻ�ȡ��Ʊ����  add by liuyingrui
        /// <summary>
        /// ���ݲ�ѯ���������ݻ�ȡ��Ʊ����
        /// </summary>
        /// <param name="m_strArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeByCondition(string[] m_strArr, out DataTable dt)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeByCondition(objPrincipal, m_strArr, out dt);
            return lngRes;
        }
        #endregion

        #region ���ݲ�ѯ���������ݼ�����Ա(�շ�Աid)��ȡ��Ʊ����  add by liuyingrui
        /// <summary>
        /// ���ݲ�ѯ���������ݼ�����Ա(�շ�Աid)��ȡ��Ʊ����
        /// </summary>
        /// <param name="m_strArr"></param>
        /// <param name="dt">
        /// <param name="m_strEmpid"></param>
        /// <returns></returns>
        public long m_lngGetChargeByEmpid(string[] m_strArr, string m_strEmpid, out DataTable dt)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeByEmpID(objPrincipal, m_strArr, m_strEmpid, out dt);
            return lngRes;
        }
        #endregion

        #region ���ݲ���Ա(�շ�Ա)ID��ʱ��β�ѯ��Ʊ��Ϣ
        /// <summary>
        /// ���ݲ���Ա(�շ�Ա)ID��ʱ��β�ѯ��Ʊ��Ϣ
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeByempid(string strDateStart, string strDateEnd, string empid, out DataTable dt)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeByempid(p_objPrincipal, strDateStart, strDateEnd, empid, out dt);
            return lngRes;
        }
        #endregion

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="blIS">������ 0--�� 1--��ʱ��false ��true �ǣ������� 1--�� 0--��ʱ��false �ǣ�true ��</param>
        /// <param name="strsetid">����ID��</param>
        /// <returns></returns>
        public long m_lngGetCollocate(out bool blIS, string strsetid)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetCollocate(p_objPrincipal, out  blIS, strsetid);
            return lngRes;
        }
        #endregion

        #region ����ʱ��λ�ȡ��Ʊ����
        /// <summary>
        /// ����ʱ��λ�ȡ��Ʊ����
        /// </summary>
        /// <param name="strDateStart"></param>
        /// <param name="strDateEnd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeByDate1(string strDateStart, string strDateEnd, out DataTable dt)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeByDate1(p_objPrincipal, strDateStart, strDateEnd, out dt);
            return lngRes;
        }
        #endregion

        #region �����ڲ���Ż�ȡ��Ʊ����¼��Ϣ
        /// <summary>
        /// �����ڲ���Ż�ȡ��Ʊ����¼��Ϣ
        /// </summary>
        /// <param name="seqid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetChargeByseqid(string seqid, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            long ret = objSvc.m_lngGetChargeByseqid(seqid, out dtRecord);
            return ret;
        }
        #endregion

        #region ��ȡ��Ʊ������ϸ
        /// <summary>
        /// ��ȡ��Ʊ������ϸ
        /// </summary>
        /// <param name="strINVOICENO"></param>
        /// <param name="strSEQID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeDe(string strINVOICENO, string strSEQID, out DataTable dt)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetChargeDe(p_objPrincipal, strINVOICENO, strSEQID, out dt);
            return lngRes;
        }
        #endregion

        #region ��ȡ��Ʊ������ϸ
        /// <summary>
        /// ��ȡ��Ʊ������ϸ
        /// </summary>
        /// <param name="strINVOICENO"></param>
        /// <param name="strSEQID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetRecipeDate(string recipeNO, out DataTable dt,out DataTable m_objAccountTable)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngGetRecipeDate(p_objPrincipal, recipeNO, out dt,out m_objAccountTable);
            return lngRes;
        }
        #endregion

        #region ��ȡ����֤��
        /// <summary>
        /// ��ȡ����֤��
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetPatientCertificateInfo(string strID, out DataTable dt)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_mthGetPatientCertificateInfo(p_objPrincipal, strID, out dt);
            return lngRes;
        }
        #endregion

        #region ��ȡ��Ʊ������ϸ
        /// <summary>
        /// ��ȡ��Ʊ������ϸ
        /// </summary>
        /// <param name="strINVOICENO"></param>
        /// <param name="strSEQID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngModifiyType(string strType, string strINVOICENO, string strSEQID, string modifiyMan)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsChargeCheckSvc));
            lngRes = objSvc.m_lngModifiyType(p_objPrincipal, strType, strINVOICENO, strSEQID, modifiyMan);
            return lngRes;
        }
        #endregion

        #region ���ݷ�Ʊ��.��Ʊ�Ż�ȡҽ�����ʵ���
        /// <summary>
        /// ���ݷ�Ʊ��.��Ʊ�Ż�ȡҽ�����ʵ���
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        public string m_strGetBillNoByInvoNo(string InvoNo)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc));
            string BillNo = objSvc.m_strGetBillNoByInvoNo(InvoNo);
            objSvc.Dispose();
            return BillNo;
        }
        #endregion
        #endregion

        public long m_lngGetRegiterByNo(string RegisterID, string strdate, out clsPatientRegister_VO objreg)
        {
            objreg = new clsPatientRegister_VO();
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngGetCurRegisterByNo(objPrincipal, RegisterID, strdate, out objreg);

            return lngRes;
        }
        public long m_mthGetPatientInfo(string strPatientType, out int intPayType)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsGetPatientType objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsGetPatientType)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsGetPatientType));
            long lngRes = objSvc.m_mthGetPatientInfo(strPatientType, out intPayType);
            return lngRes;
        }

        #region (������ݶ�Ӧ�ű�)
        /// <summary>
        /// ���ݲ���ID���뻼����������ҳ�֤����(������ݶ�Ӧ�ű�)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPATIENTID_CHR">���߱��</param>
        /// <param name="p_strPAYTYPEID_CHR">�����������</param>
        /// <param name="p_strNo">������Ͷ�Ӧ����</param>
        /// <param name="p_strResultPAYTYPEID_CHR">�������</param>
        /// <param name="p_strPAYTYPENAME_VCHR"></param>
        /// <param name="p_strINTERNALFLAG_INT">0-��ͨ 1-���� 2-ҽ�� 3-���� ���ڲ�ʹ�ã��������֣�</param>
        /// <param name="?"></param>
        /// <returns></returns>
        public long m_lngFindNoByPatientIdAndTypeId(string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR,
            out string p_strNo,
            out string p_strResultPAYTYPEID_CHR,
            out string p_strPAYTYPENAME_VCHR,
            out string p_strINTERNALFLAG_INT
            )
        {
            p_strNo = null;
            p_strResultPAYTYPEID_CHR = null;
            p_strPAYTYPENAME_VCHR = null;
            p_strINTERNALFLAG_INT = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngFindNoByPatientIdAndTypeId(objPrincipal, p_strPATIENTID_CHR, p_strPAYTYPEID_CHR, out p_strNo, out p_strResultPAYTYPEID_CHR, out p_strPAYTYPENAME_VCHR, out p_strINTERNALFLAG_INT);
            return LngArg;
        }
        /// <summary>
        /// ���Ӳ��������֤����(������ݶ�Ӧ�ű�)
        /// </summary>
        public long m_lngAddPatientIdTypeIdNo(string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR, string p_strNo)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngAddPatientIdTypeIdNo(objPrincipal, p_strPATIENTID_CHR, p_strPAYTYPEID_CHR, p_strNo);
            return LngArg;
        }
        /// <summary>
        /// ���²��������֤����(������ݶ�Ӧ�ű�)
        /// </summary>
        public long m_lngUpdatePatientIdTypeIdNo(string p_strPATIENTID_CHR, string p_strPAYTYPEID_CHR, string p_strNoNew)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngUpdatePatientIdTypeIdNo(objPrincipal, p_strPATIENTID_CHR, p_strPAYTYPEID_CHR, p_strNoNew);
            return LngArg;
        }
        #endregion

        #region ���ݷ�Ʊ�Ż�ȡ�������Ӧ��
        /// <summary>
        /// ���ݷ�Ʊ�Ż�ȡ�������Ӧ��
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <returns></returns>
        public string m_strGetpatientidentityno(string invo)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc objSvc =
                               (com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc));

            string idno = objSvc.m_strGetpatientidentityno(invo);
            objSvc.Dispose();
            return idno;
        }
        #endregion

        #region ���ݽ����ˡ�����ʱ���ȡ��Ӧ���ش�Ʊ��Ϣ
        /// <summary>
        /// ���ݽ����ˡ�����ʱ���ȡ��Ӧ���ش�Ʊ��Ϣ
        /// </summary>
        /// <param name="BalanceEmp"></param>
        /// <param name="BalanceTime"></param>
        /// <returns></returns>
        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string BalanceTime, out string[] InvonoArr, int status)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            objSvc.m_mthGetbalancerepeatinvoinfo(BalanceEmp, BalanceTime, out InvonoArr, status);

        }

        public void m_mthGetbalancerepeatinvoinfo(string BalanceEmp, string strBeginDate, string strEndDate, out string[] InvonoArr, int intMode)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            objSvc.m_mthGetbalancerepeatinvoinfo(BalanceEmp, strBeginDate, strEndDate, out InvonoArr, intMode);
        }
        #endregion

        #region ���淢Ʊ�ش���Ϣ
        /// <summary>
        /// ���淢Ʊ�ش���Ϣ
        /// </summary>
        /// <param name="TypeID"> '1' �շѷ�Ʊ '2' �Һŷ�Ʊ</param>
        /// <param name="Seqid"></param>
        /// <param name="Oldinvono"></param>
        /// <param name="Newinvono"></param>
        /// <param name="Empid"></param>
        /// <returns></returns>        
        public long m_lngSaveinvorepeatprninfo(string TypeID, string Seqid, string Oldinvono, string Newinvono, string Empid)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOPChargeSvc));

            long l = objSvc.m_lngSaveinvorepeatprninfo(TypeID, Seqid, Oldinvono, Newinvono, Empid);
            objSvc.Dispose();

            return l;
        }
        #endregion
        #region ��ӡ������Ϣ
        /// <summary>
        /// ��ȡ��ӡ������Ϣ
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        public long m_lngGetOutpatientRecipeDetail(string m_strRecipeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc m_objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetOutpatientRecipeDetail(objPrincipal, m_strRecipeID, out  obj_VO);
            return lngRes;
        }
        #endregion
        #region ��ȡ����������Ϣ
        /// <summary>
        /// ��ȡ����������Ϣ
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="m_objRTVO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeTypeInfo(string m_strRecipeID, out clsRecipeType_VO m_objRTVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc m_objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetRecipeTypeInfo(objPrincipal, m_strRecipeID, out  m_objRTVO);
            return lngRes;
        }
        #endregion

        #region �սᱨ����෢Ʊ
        /// <summary>
        /// �սᱨ����෢Ʊ
        /// </summary>
        /// <param name="strCheckDate"></param>
        /// <param name="strCheckManID"></param>
        /// <param name="dtbAllRecipeinv">��Ʊ������Ϣ(��֧����ʽ�Ͳ���֧������)</param>
        /// <returns></returns>
        public long m_lngGetAllRecipeinvInfo(string strCheckDate, string strCheckManID, out DataTable dtbAllRecipeinv)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            return objSvc.m_lngGetAllRecipeinvInfo(p_objPrincipal, strCheckDate, strCheckManID, out dtbAllRecipeinv);
        }
        #endregion


        #region �շѽ����ձ���

        public long m_lngGetPayTypeAndCheckOutData(string OPREMPID, string strDate, out DataTable dtPayType, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutData(p_objPrincipal, OPREMPID, strDate, out dtPayType, out dtCheckOut);
            return LngArg;
        }
        #endregion

        #region ��ʷ��ѯ����
        public long m_lngGetPayTypeAndCheckOutDatahistory(string strDate, string BALANCEEMP, out DataTable dtPayType, out DataTable dtCheckOut)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutDatahistory(p_objPrincipal, strDate, BALANCEEMP, out dtPayType, out dtCheckOut);
            return LngArg;
        }
        #endregion

        #region �շ�Ա�����ձ���(��ҽ��Ժ)
        /// <summary>
        /// �շ�Ա�����ձ���(��ҽ��Ժ)
        /// </summary>
        /// <param name="p_strRptID"></param>
        /// <param name="p_intType"></param>
        /// <param name="OPREMPID"></param>
        /// <param name="strDate"></param>
        /// <param name="dtRecipesumde"></param>
        /// <param name="dtCheckOut"></param>
        /// <param name="dtRecipeinv"></param>
        /// <returns></returns>
        public long m_lngGetCheckOutOfData(string p_strRptID, int p_intType, int p_intRecFlag, string OPREMPID, string[] strDateArr, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngGetCheckOutOfData(p_objPrincipal, p_strRptID, p_intType, p_intRecFlag, OPREMPID, strDateArr, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
            return lngRes;
        }

        /// <summary>
        /// ��ҽ��Ժ�ս���ʷ���ݲ�ѯ
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="BALANCEEMP"></param>
        /// <param name="dtPayType"></param>
        /// <param name="dtRecipesumde"></param>
        /// <param name="dtCheckOut"></param>
        /// <param name="dtRecipeinv"></param>
        /// <returns></returns>
        public long m_lngGetPayTypeAndCheckOutDatahistory(string p_strRptID, int p_intType, string[] strDate, string BALANCEEMP, out DataTable dtRecipesumde, out DataTable dtCheckOut, out DataTable dtRecipeinv)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetPayTypeAndCheckOutDatahistory(p_objPrincipal, p_strRptID, p_intType, strDate, BALANCEEMP, out dtRecipesumde, out dtCheckOut, out dtRecipeinv);
            return LngArg;
        }
        #endregion

        #region ��ȡ����ҵ����������
        /// <summary>
        /// ��ȡ����ҵ����������
        /// baojian.mo add in 2008.02.28
        /// </summary>
        /// <param name="p_isConfirmFlag">0-δ��� 1-�����</param>
        /// <param name="p_strDateFrom"></param>
        /// <param name="p_strDateTo"></param>
        /// <param name="p_strConfirmManID"></param>
        /// <param name="p_objInvRecArr"></param>
        /// <returns></returns>
        public long m_lngGetInvoRecData(int p_isConfirmFlag, string p_strDateFrom, string p_strDateTo, string p_strConfirmManID, out com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] p_objInvRecArr)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetInvoRecData(p_isConfirmFlag, p_strDateFrom, p_strDateTo, p_strConfirmManID, out p_objInvRecArr);
            return LngArg;
        }
        #endregion

        #region ��˼�¼
        /// <summary>
        /// ��˼�¼
        /// </summary>
        /// <param name="p_arrConDate"></param>
        /// <param name="p_objReceiptVo"></param>
        /// <returns></returns>
        public long m_lngConfirmRecord(System.Collections.ArrayList p_arrConDate, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO p_objReceiptVo)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngConfirmRecord(p_arrConDate, p_objReceiptVo);
            return LngArg;
        }
        #endregion

        #region �޸ļ�¼
        /// <summary>
        /// �޸ļ�¼
        /// </summary>
        /// <param name="p_strInvoRecNO"></param>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        public long m_lngModifyRecord(string p_strInvoRecNO, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO p_objVO)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngModifyRecord(p_strInvoRecNO, p_objVO);
            return LngArg;
        }
        #endregion

        /// <summary>
        /// ����ѡ��Ŀ���ID���¼����շ�Ա
        /// </summary>
        /// <param name="dtdept"></param>
        /// <param name="strEmpId"></param>
        internal void m_lngGetCheckManByDeptId(out DataTable dt,string strdeptId)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngner = objSvc.m_lngGetCheckManByDeptId(p_objPrincipal, out dt, strdeptId);
            objSvc.Dispose();
            objSvc = null;
        }
        /// <summary>
        /// ��ȡ�շ�Ա���ڿ���
        /// </summary>
        /// <param name="dtdept"></param>
        /// <param name="strEmpId"></param>
        internal void m_lngGetRegdept(out DataTable dtdept, string strEmpId)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngner = objSvc.m_lngGetRegdept(p_objPrincipal, out dtdept, strEmpId);
            objSvc.Dispose();
            objSvc = null;
        }

    }

    /// <summary>
    /// �����շ��Ż� 
    /// </summary>
    public class clsDomainControl_RegisterDetailAuto : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainControl_RegisterDetailAuto()
        { }
        public long m_lngGetRegisterdetail()
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long lngRes = objSvc.m_lngGetRegisterdetail(p_objPrincipal);

            return lngRes;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dt">�������ݵı�</param>
        /// <returns></returns>
        public long m_lngLoadData(out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc));
            return objSvc.m_lngLoadData(this.objPrincipal, out dt);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="ID1">�Һ�����ID</param>
        /// <param name="ID2">����ID</param>
        /// <param name="ID3">�ѱ�ID</param>
        /// <param name="PAYMENT_MNY">����</param>
        /// <param name="DISCOUNT_DEC">�Żݱ���</param>
        /// <returns></returns>
        public long m_lngSave(string ID1, string ID2, string ID3, string PAYMENT_MNY, string DISCOUNT_DEC)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterDetailSvc));
            return objSvc.m_lngSave(this.objPrincipal, ID1, ID2, ID3, PAYMENT_MNY, DISCOUNT_DEC);
        }
    }
    public class clsGetIsUsingAuto : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsGetIsUsingAuto()
        {
        }
        /// <summary>
        /// �ж��Ƿ����ù���������Ϊ�Ѿ����ã�
        /// </summary>
        /// <param name="feild">�ֶΣ���ĿID��</param>
        /// <param name="valueid">ֵ����ĿID��</param>m_lngGetIsUsingChargeType
        /// <returns></returns>
        public static bool m_blGetIsUsing(string feild, string valueid)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetIsUsing(p_objPrincipal, feild, valueid);

            if (LngArg == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// �жϹҺ������Ƿ����ù���������Ϊ�Ѿ����ã�
        /// </summary>
        /// <param name="feild">�ֶΣ���ĿID��</param>
        /// <param name="valueid">ֵ����ĿID��</param>
        /// <returns></returns>
        public static bool m_blGetIsUsingChargeType(string feild, string valueid)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_lngGetIsUsingChargeType(p_objPrincipal, feild, valueid);

            if (LngArg == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ɾ���Żݱ�
        /// </summary>
        /// <param name="feild">�ֶΣ���ĿID��</param>
        /// <param name="valueid">ֵ����ĿID��</param>
        /// <returns></returns>
        public static bool m_blDeleteDetail(string feild, string valueid)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvcAuto));
            long LngArg = objSvc.m_blDeleteDetail(p_objPrincipal, feild, valueid);

            if (LngArg == 0)
            {
                return false;
            }
            return true;
        }
    }
}
