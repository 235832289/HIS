using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// סԺ����ת�߼����Ʋ�
    /// </summary>
    class clsDcl_BIHTransfer : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        // ��Ժ�Ǽ�
        #region ��ø����ֵ���Ϣ
        /// <summary>
        /// ��ø����ֵ���Ϣ
        /// </summary>
        /// <param name="p_intCat">�����ֵ����</param>
        /// <param name="p_objResultArr">�����ֵ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetAID_DICTArr(int p_intCat, out clsAIDDICT_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAID_DICTArr(objPrincipal, p_intCat, out p_objResultArr);
        }
        #endregion

        #region �������ƿ��Ż�סԺ�Ż�ȡ����ID
        /// <summary>
        /// �������ƿ��Ż�סԺ�Ż�ȡ����ID
        /// </summary>
        /// <param name="p_intFindType">���ұ�ʶ:0-���ƿ���,1-סԺ��</param>
        /// <param name="p_strFindText">���ұ���</param>
        /// <param name="p_strPatientID">����ID</param>
        /// <returns></returns>
        public long m_lngGetPatientIDByCarIDOrInPatientID(int p_intFindType, string p_strFindText, out string p_strPatientID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientIDByCarIDOrInPatientID(objPrincipal, p_intFindType, p_strFindText, out p_strPatientID);
        }
        #endregion

        #region ���ݲ���ID����Ժ���ͻ�ȡ��Ժ��¼������Ժ����
        /// <summary>
        /// ���ݲ���ID����Ժ���ͻ�ȡ��Ժ��¼������Ժ����
        /// </summary>
        /// <param name="p_strPatientID">����ID</param>
        /// <param name="p_intInType">��Ժ����:1-��ʽ,2-����</param>
        /// <param name="p_objResult">�������һ��סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngGetLatestInHospitalInfo(string p_strPatientID, int p_intInType, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetLatestInHospitalInfo(objPrincipal, p_strPatientID, p_intInType, out p_objResult);
        }
        #endregion

        #region ���ݲ���ID��ȡ���˻�����Ϣ
        /// <summary>
        /// ���ݲ���ID��ȡ���˻�����Ϣ
        /// </summary>
        /// <param name="p_strPatientid_chr">����ID</param>
        /// <param name="p_objResult">�˻�����ϢVO</param>
        /// <returns></returns>
        public long m_lngFindPatientInfoByPatientID(string p_strPatientid_chr, out clsPatient_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientInfoByPatientID(objPrincipal, p_strPatientid_chr, out p_objResult);
        }

        /// <summary>
        /// ���ݲ��˵Ǽ�ID��ȡ���˻�����Ϣ
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetPatientINfoByRegisterID(string p_strRegisterID, out clsPatient_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
       com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientINfoByRegisterID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_objResult">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngGetBIHPatientInfoByRegID(string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBIHPatientInfoByRegID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ���շ���Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ���շ���Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_objResult">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngGetBIHPatientInfoAndCharge(string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBIHPatientInfoAndCharge(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ(�����޸ĵǼ�����)
        /// <summary>
        /// ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ(�����޸ĵǼ�����)
        /// </summary>
        /// <param name="p_strPatientID">����ID</param>
        /// <param name="p_objResult">��Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByPatientID(string p_strPatientID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByPatientID(objPrincipal, p_strPatientID, out p_objResult);
        }
        /// <summary>
        /// ������Ժ�ǺŻ�ȡ������Ժ�Ǽ���Ϣ(�����޸ĵǼ�����)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByRegisterID(string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objRegisterVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByRegisterID(objPrincipal, p_strRegisterID, out p_objRegisterVo);
        }
        #endregion

        #region ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ(��Ժ����)
        /// <summary>
        /// ���ݲ���ID��ȡ������Ժ�Ǽ���Ϣ(��Ժ����)
        /// </summary>
        /// <param name="p_strPatientID">����ID</param>
        /// <param name="p_objResult">��Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByPatientID(string p_strPatientID, string p_strPStatus, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByPatientID(objPrincipal, p_strPatientID, p_strPStatus, out p_objResult);
        }
        #endregion

        #region ������Ժ�Ǽ�
        /// <summary>
        /// ������Ժ�Ǽ�
        /// </summary>
        /// <param name="p_objParaVo">����VO</param>
        /// <param name="objPatientVO">���˻�����Ϣ</param>
        /// <param name="p_objPay">Ԥ������Ϣ</param>
        /// <param name="objBIHVO">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngPatientRegister(clsRegisterParameterVO p_objParaVo, clsPatient_VO objPatientVO, clsT_opr_bih_prepay_VO p_objPay, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngPatientRegister(objPrincipal, p_objParaVo, objPatientVO, p_objPay, ref objBIHVO);

        }
        #endregion

        #region Ӥ����Ժ�Ǽ�(����)
        /// <summary>
        /// Ӥ����Ժ�Ǽǣ�������
        /// </summary>
        /// <param name="objPatientVO">���˻�����Ϣ</param>
        /// <param name="objBIHVO">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngBabyRegister(clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngBabyRegister(objPrincipal, objPatientVO, objBIHVO);

        }
        #endregion

        #region Ӥ����Ժ�Ǽ�(�޸�)
        /// <summary>
        /// Ӥ����Ժ�Ǽǣ��޸ģ�
        /// </summary>
        /// <param name="objPatientVO">���˻�����Ϣ</param>
        /// <param name="objBIHVO">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngChangeBabyRegister(clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngChangeBabyRegister(objPrincipal, objPatientVO, objBIHVO);

        }
        #endregion

        #region ������Ժ
        /// <summary>
        /// ������Ժ
        /// </summary>
        /// <param name="p_objRecord">����סԺ��Ϣ</param>
        /// <returns></returns>
        public long m_lngCancleBeInHospital(clsBIHpatientVO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngCancleBeInHospital(objPrincipal, p_objRecord);
        }
        #endregion

        #region ��ȡסԺ�շ����
        /// <summary>
        /// ��ȡסԺ�շ����
        /// </summary>
        /// <param name="p_objResultArr">�����</param>
        /// <returns></returns>
        public long m_GetBIHPatientType(out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_GetBIHPatientType(objPrincipal, out p_objResultArr);
        }
        #endregion

        #region ��ȡ����������
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="p_objResultArr">������</param>
        /// <returns></returns>
        public long m_GetPatientType(out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_GetPatientType(objPrincipal, out p_objResultArr);
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ�Ǽ���Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ�Ǽ���Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">������Ժ�Ǽ�ID</param>
        /// <param name="p_objResult">Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByID(string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region ���ݹ�����Ժ�Ǽ�ID��ȡӤ���Ǽ���Ϣ
        /// <summary>
        /// ���ݹ�����Ժ�Ǽ�ID��ȡӤ���Ǽ���Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">������Ժ�Ǽ�ID</param>
        /// <param name="p_objResult">Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetBabyRegisterInfoByID(string p_strRelateRegisterID, int p_intBornNum, out DataTable dtbBabyInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyRegisterInfoByID(objPrincipal, p_strRelateRegisterID, p_intBornNum, out dtbBabyInfo);
        }
        #endregion

        #region ���ݹ�����Ժ�Ǽ�ID��ȡӤ��̥��
        /// <summary>
        /// ���ݹ�����Ժ�Ǽ�ID��ȡӤ��̥��
        /// </summary>
        /// <param name="p_strRegisterID">������Ժ�Ǽ�ID</param>
        /// <param name="p_objResult">Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngGetBabyBornNumByID(string p_strRelateRegisterID, ref int p_intBornNum)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyBornNumByID(objPrincipal, p_strRelateRegisterID, ref p_intBornNum);
        }

        public long m_lngGetBabyBornNumByID(string p_strRelateRegisterID, ref ArrayList arrBornNum)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyBornNumByID(objPrincipal, p_strRelateRegisterID, ref arrBornNum);
        }
        #endregion


        #region ����ID�Ż�ȡϵͳ����
        /// <summary>
        /// ����ID�Ż�ȡϵͳ����
        /// </summary>
        /// <param name="p_strSetingID">ϵͳ����ID��</param>
        /// <param name="p_intSetstatus">״̬</param>
        /// <returns></returns>
        public long m_lngGetSetingByID(string p_strSetingID, out int p_intSetstatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                        com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetSetingByID(objPrincipal, p_strSetingID, out p_intSetstatus);
        }
        #endregion

        #region �޸���Ժ�Ǽ�����
        /// <summary>
        /// �޸���Ժ�Ǽ�����
        /// </summary>
        /// <param name="p_intFlag">������ʶ:0-�����޸ĵ�ת��,1-���޸ĵ�ת��</param>
        /// <param name="objPatientVO">���˻�����Ϣ</param>
        /// <param name="objBIHVO">��Ժ�Ǽ���Ϣ</param>
        /// <returns></returns>
        public long m_lngEditRegister(int p_intFlag, clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngEditRegister(objPrincipal, p_intFlag, objPatientVO, objBIHVO);
        }
        #endregion

        // ��λ����

        #region ���Ӵ�λ
        /// <summary>
        /// ���Ӵ�λ
        /// </summary>
        /// <param name="p_strRecordID">��λ��ID</param>
        /// <param name="p_objRecord">��λ��ϢVO</param>
        /// <returns></returns>
        public long m_lngAddNewBed(out string p_strRecordID, clsT_Bse_Bed_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngAddNewBed(objPrincipal, out p_strRecordID, p_objRecord);
        }
        #endregion

        #region ���ݴ�λID�޸Ĵ�λ��Ϣ
        /// <summary>
        /// ���ݴ�λID�޸Ĵ�λ��Ϣ
        /// </summary>
        /// <param name="p_strRecordID">��λID</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngModefyBedByID(clsT_Bse_Bed_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngModefyBedByID(objPrincipal, p_objRecord);
        }
        #endregion

        #region ���ݴ�λIDɾ����λ
        /// <summary>
        ///  ���ݴ�λIDɾ����λ
        /// </summary>
        /// <param name="p_Bedid_chr">��λ��ˮ��</param>
        /// <returns></returns>
        public long m_lngDeleteBedInfoByByBedID(string p_Bedid_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngDeleteBedInfoByByBedID(objPrincipal, p_Bedid_chr);
        }
        #endregion

        #region ���ݲ���ID�ʹ�λ״̬��ȡ������λ�����Ϣ
        /// <summary>
        /// ���ݲ���ID�ʹ�λ״̬��ȡ������λ�����Ϣ
        /// </summary>
        /// <param name="p_strAreaid_chr">����ID</param>
        /// <param name="p_strStatus">1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��</param>
        /// <returns></returns>
        public long m_lngGetBedShortInfoByAreaID(string p_strAreaid_chr, string p_strStatus, out clsT_Bse_Bed_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBedShortInfoByAreaID(objPrincipal, p_strAreaid_chr, p_strStatus, out p_objResultArr);
        }
        #endregion

        #region ���ݴ�λID��ȡ��λ��Ϣ
        /// <summary>
        /// ���ݴ�λID��ȡ��λ��Ϣ
        /// </summary>
        /// <param name="p_strBedID">��λID</param>
        /// <param name="p_objResult">λ��ϢVO</param>
        /// <returns></returns>
        public long m_lngGetBedInfoByBedID(string p_strBedID, out clsT_Bse_Bed_VO p_objResul)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBedInfoByBedID(objPrincipal, p_strBedID, out p_objResul);
        }
        #endregion

        #region ��ȡ��Ȩ��ʹ�õĲ�����Ϣ�б�
        /// <summary>
        /// ��ȡ��Ȩ��ʹ�õĲ�����Ϣ�б�
        /// </summary>
        /// <param name="p_strAreaIDs">��Ȩ��ʹ�õĲ���ID</param>
        /// <param name="p_objResultArr">��Ȩ��ʹ�õĲ�����Ϣ�б�ID</param>
        /// <returns></returns>
        public long m_lngGetAreaList(string p_strEmpID, out clsAreaInfoVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAreaList(objPrincipal, p_strEmpID, out p_objResultArr);
        }
        #endregion

        #region ���ݲ���ID��ѯ��ϸ��λ��Ϣ
        /// <summary>
        /// ���ݲ���ID��ѯ��ϸ��λ��Ϣ
        /// </summary>
        /// <param name="p_strArearID">����ID</param>
        /// <param name="p_ojbResultArr">��λ��ϸ��Ϣ</param>
        /// <returns></returns>
        public long m_lngGetBidInfoByArearID(string p_strArearID, out clsBedManageVO[] p_ojbResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));

            return objSvc.m_lngGetBedInfoByArearID(objPrincipal, p_strArearID, out p_ojbResultArr);
        }
        #endregion

        #region ���ݲ���ID��ѯδ���Ŵ�λ�Ĳ�����Ϣ
        /// <summary>
        /// ���ݲ���ID��ѯδ���Ŵ�λ�Ĳ�����Ϣ
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnInNA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnInNA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region ���ݲ���ID��ѯ����ת���ѽ��ղ���
        /// <summary>
        /// ���ݲ���ID��ѯ����ת���ѽ��ղ���
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnInA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnInA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region ���ݲ���ID��ѯ����ת��δ���ղ���
        /// <summary>
        /// ���ݲ���ID��ѯ����ת��δ���ղ���
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnOutNA(string p_strAreaID, out clsTransferVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnOutNA(objPrincipal, p_strAreaID, out p_objResultArr);
        }
        #endregion

        #region ���ݲ���ID��ѯ����ת���ѽ��ղ���
        /// <summary>
        /// ���ݲ���ID��ѯ����ת���ѽ��ղ���
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnOutA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnOutA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region ��ȡ����ǰ������ȫԺδ���Ŵ�λ�Ĳ���
        /// <summary>
        /// ��ȡ����ǰ������ȫԺδ���Ŵ�λ�Ĳ���
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngGetAllUnArrangeBedPatient(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAllUnArrangeBedPatient(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region �ж����������Ѿ�����
        /// <summary>
        /// �ж����������Ѿ�����
        /// </summary>
        /// <param name="p_strAreaID_chr">������</param>
        /// <param name="p_strBedId">����ID(��Ϊ��)</param>
        /// <param name="p_strCode_chr">����</param>
        /// <returns></returns>
        public long IsExistBedByAreaIDAndCode(string p_strAreaID_chr, string p_strBedId, string p_strCode_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngCheckBedCode(objPrincipal, p_strAreaID_chr, p_strBedId, p_strCode_chr);
        }
        #endregion

        #region ���Ŵ�λ
        /// <summary>
        /// ���Ŵ�λ
        /// </summary>
        /// <param name="p_objRecord">�޸���Ϣ</param>
        /// <returns></returns>
        public long m_lngArrangeBed(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngArrangeBed(objPrincipal, p_objRecord);
        }

        public long m_lngArrangeBed(clsT_Opr_Bih_Transfer_VO p_objRecord, clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngArrangeBed(objPrincipal, p_objRecord, p_objRegisterVO);
        }
        #endregion

        #region ��������ҽ�������(�ڴ�λ�༭ʱ�õ�)
        /// <summary>
        /// ��������ҽ�������(�ڴ�λ�༭ʱ�õ�)
        /// </summary>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        public long m_lngModifyRegInfo(clsT_Opr_Bih_Register_VO objPatientVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngModifyRegInfo(objPrincipal, objPatientVO);
        }
        #endregion

        #region ������Ժ���(ICD10)��Ϣ
        /// <summary>
        /// ������Ժ���(ICD10)��Ϣ
        /// </summary>
        /// <param name="p_strName">����</param>
        /// <param name="p_dtbRecord">���</param>
        /// <returns></returns>
        public long m_lngFindICD10(string p_strFind, out DataTable p_dtbRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngFindICD10(objPrincipal, p_strFind, out p_dtbRecord);
        }
        #endregion

        #region ת��
        /// <summary>
        /// ת��
        /// </summary>
        /// <param name="p_objRecord">�޸���Ϣ</param>
        /// <returns></returns>
        public long m_lngTurnOut(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngTurnOut(objPrincipal, p_objRecord);
        }
        #endregion

        #region ����ת��
        /// <summary>
        /// ����ת��
        /// </summary>
        /// <param name="p_objRecord">��ת��Ϣ</param>
        /// <returns></returns>
        public long m_lngUnDoTurnOut(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUnDoTurnOut(objPrincipal, p_objRecord);
        }
        #endregion

        #region ת��
        /// <summary>
        /// ת��
        /// </summary>
        /// <param name="p_objRecord">�޸���Ϣ</param>
        /// <returns></returns>
        public long m_lngTurnBed(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngTurnBed(objPrincipal, p_objRecord);
        }
        #endregion

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_strBedID">��λID</param>
        /// <param name="p_strOperateID">����ԱID</param>
        /// <returns></returns>
        public long m_lngWarpBed(string p_strRegisterID, string p_strBedID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                         com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngWarpBed(objPrincipal, p_strRegisterID, p_strBedID, p_strOperateID);
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_strBedID">��λID</param>
        /// <param name="p_strOperateID">������ID</param>
        /// <returns></returns>
        public long m_lngUndoWarpBed(string p_strBedID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoWarpBed(objPrincipal, p_strBedID, p_strOperateID);
        }
        #endregion

        #region ���
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="p_objRecord">���VO</param>
        /// <returns></returns>
        public long m_lngHoliday(clsHolidayRecord_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngHoliday(objPrincipal, p_objRecord);
        }
        #endregion

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_objRecord">���VO</param>
        /// <returns></returns>
        public long m_lngUndoHoliday(clsHolidayRecord_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoHoliday(objPrincipal, p_objRecord);
        }
        #endregion

        #region ��ѯ����
        public long m_lngQueryPatientInfoByOccupiedBedid(string Bedid, out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            return objSvc.m_lngQueryPatientInfoByOccupiedBedid(Bedid, out dtbResult);
        }
        #endregion

        #region ��ͨ��->���ۺ�
        /// <summary>
        /// ��ͨ��->���ۺ�
        /// </summary>
        /// <param name="m_strRegisterid_chr">ԭ�Ǽ���ˮ��</param>
        /// <param name="oldInpatientid_chr">ԭסԺ��</param>
        /// <param name="oldinpatientnotype_int">�ɵǼ�����(1-����,2-����)</param>
        /// <param name="newinpatientnotype_int">�µǼ�����(1-����,2-����)</param>
        /// <param name="m_strHead">��סԺ��ͷ��ʶ</param>
        /// <param name="m_strMain">��סԺ�����ֲ���</param>
        /// <param name="m_intSour">1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����</param>
        /// <returns></returns>
        public long m_lngChangePatientIDOth(string m_strRegisterid_chr, string oldInpatientid_chr, int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngChangePatientIDOth(objPrincipal, m_strRegisterid_chr, oldInpatientid_chr, oldinpatientnotype_int, newinpatientnotype_int, m_strHead, m_strMain, m_intSour);


        }
        #endregion

        #region ���ۺ�->��ͨ��
        /// <summary>
        /// ��ͨ��->���ۺ�
        /// </summary>
        /// <param name="m_strRegisterid_chr">ԭ�Ǽ���ˮ��</param>
        /// <param name="oldInpatientid_chr">ԭסԺ��</param>
        /// <param name="oldinpatientnotype_int">�ɵǼ�����(1-����,2-����)</param>
        /// <param name="newinpatientnotype_int">�µǼ�����(1-����,2-����)</param>
        /// <param name="m_strHead">��סԺ��ͷ��ʶ</param>
        /// <param name="m_strMain">��סԺ�����ֲ���</param>
        /// <param name="m_intSour">1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����</param>
        /// <returns></returns>
        public long m_lngChangePatientIDNor(string m_strRegisterid_chr, string oldInpatientid_chr, int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngChangePatientIDNor(objPrincipal, m_strRegisterid_chr, oldInpatientid_chr, oldinpatientnotype_int, newinpatientnotype_int, m_strHead, m_strMain, m_intSour);


        }
        #endregion

        #region ���ݲ����������Ա������ʷ��Ϣ
        public long GetHisPatientByName(string name, string sex, out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetHisPatientByName(objPrincipal, name, sex, out dtbResult);
        }
        #endregion

        #region  ������Ժ�Ǽ�ID�жϲ����Ƿ����ת�����Ժ��¼
        /// <summary>
        ///  ������Ժ�Ǽ�ID�жϲ����Ƿ����ת�����Ժ��¼
        /// </summary>
        /// <param name="p_strRegisterID_chr">��Ժ�ǼǺ�</param>
        /// <returns></returns>
        public long CheckTranOrOut(string p_strRegisterID_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.CheckTranOrOut(objPrincipal, p_strRegisterID_chr);
        }
        #endregion

        #region  ������Ժ�Ǽ�ID��ȡ���������ҽ��ʱ��
        /// <summary>
        ///  ������Ժ�Ǽ�ID��ȡ���������ҽ��ʱ��
        /// </summary>
        /// <param name="p_strRegisterID_chr">��Ժ�ǼǺ�</param>
        /// <param name="p_strFirstOrderDate"></param>
        /// <returns></returns>
        public long GetFirstOrderDateByRegId(string p_strRegisterID_chr, out string p_strFirstOrderDate)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetFirstOrderDateByRegId(objPrincipal, p_strRegisterID_chr, out p_strFirstOrderDate);
        }
        #endregion

        #region ���Ҳ���
        /// <summary>
        /// ���Ҳ���	���������ַ���
        /// </summary>
        /// <param name="strCode">�����ַ���</param>
        /// <param name="p_objResultArr">��������	[out ����]</param>
        public long m_lngFindArea(string strCode, out clsBIHArea[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindArea(strCode, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ���˲�����Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ���˲�����Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long GetPatientStateByRegID(string p_strRegisterID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetPatientStateByRegID(objPrincipal, p_strRegisterID, out p_dtbResult);
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ������Ч��ʳ������Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ������Ч��ʳ������Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long GetPatientNurseByRegID(string p_strRegisterID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetPatientNurseByRegID(objPrincipal, p_strRegisterID, out p_dtbResult);
        }
        #endregion

        #region ����Ա��ID��ȡĬ�ϵĿ���
        /// <summary>
        /// ����Ա��ID��ȡĬ�ϵĿ���
        /// </summary>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_dtbResult">Ĭ�Ͽ�����Ϣ</param>
        /// <returns></returns>
        public long GetDeptByEmpID(string p_strEmpID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetDeptByEmpID(objPrincipal, p_strEmpID, out p_dtbResult);
        }
        #endregion

        #region ���ݲ���Id��ȡ��������ID
        /// <summary>
        /// ���ݲ���Id��ȡ��������ID
        /// </summary>
        /// <param name="p_strDeptID">����ID</param>
        /// <param name="p_strParentId">��������ID</param>
        /// <returns></returns>
        public long GetParentIdByDeptId(string p_strDeptID, out string p_strParentId)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetParentIdByDeptId(objPrincipal, p_strDeptID, out p_strParentId);
        }
        #endregion

        #region �������ϱ䶯��¼
        /// <summary>
        /// �������ϱ䶯��¼
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long AddPatienInfLog(clsPatientInfLog p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc));
            return objSvc.AddPatienInfLog(objPrincipal, p_objRecord);
        }
        #endregion

        #region ��ѯ���ϱ䶯��Ϣ
        /// <summary>
        /// ��ѯ���ϱ䶯��Ϣ
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long GetPatienInfLog(DateTime p_dtStartDate, DateTime p_dtEndDate, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc));
            return objSvc.GetLogByDate(objPrincipal, p_dtStartDate, p_dtEndDate, out p_dtResult);
        }
        #endregion


        //////////////////////////////////////////////////
        //ת��ʱ�԰������в��� 2007.09.03 л�ƽ����
        /////////////////////////////////////////////////

        #region ��鲡��ת��ʱ���Ƿ���ڰ���
        /// <summary>
        /// ��鲡��ת��ʱ���Ƿ���ڰ���
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="intRowCount"></param>
        /// <returns></returns>
        public long m_lngGetWarpBedByRegID(string p_strRegisterID, ref int intRowCount)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetWarpBedByRegID(p_strRegisterID, ref intRowCount);
        }
        #endregion

        #region �������˵����а���
        /// <summary>
        /// �������˵����а���
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strOperateID"></param>
        /// <returns></returns>
        public long m_lngUndoWarpBedByRegID(string p_strRegisterID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoWarpBedByRegID(p_strRegisterID, p_strOperateID);
        }
        #endregion


        #region ��ȡ����������δ���Ѵ���
        /// <summary>
        /// ��ȡ����������δ���Ѵ���
        /// </summary>
        /// <param name="p_strPaitneNo">����סԺ�Ż����ƺ�</param>
        /// <param name="p_intType">1-סԺ�Ų�ѯ��2-���ƺŲ�ѯ</param>
        /// <param name="p_lstRecipeNoPay_VO">���ؽ��VO</param>
        /// <returns></returns>
        public long m_lngGetPatientRecipeNopay(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngGetPatientRecipeNopay(p_strPaitneNo,p_intType,out p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion


        #region ��ѯ����������δ���Ѵ���
        /// <summary>
        /// ��ȡ����������δ���Ѵ���
        /// </summary>
        /// <param name="p_strPaitneNo">����סԺ�Ż����ƺ�</param>
        /// <param name="p_intType">1-סԺ�Ų�ѯ��2-���ƺŲ�ѯ</param>
        /// <param name="p_lstRecipeNoPay_VO">���ؽ��VO</param>
        /// <returns></returns>
        public long m_lngGetPatientRecipeNopayZY(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngGetPatientRecipeNopayZY(p_strPaitneNo, p_intType, out p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion
        #region ����δ�����ô����ŵ�סԺ��Ϣ����
        /// <summary>
        /// ����δ�����ô����ŵ�סԺ��Ϣ����
        /// </summary>
        /// <param name="p_lstRecipeNoPay_VO">�����������VO LIST</param>
        /// <returns></returns>
        public long m_lngInsertPatientNopayRecipeZY(System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngInsertPatientNopayRecipeZY(p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region ���㲡������δ�����ô���
        /// <summary>
        /// ���㲡������δ�����ô���
        /// </summary>
        /// <param name="p_strPatientNO">סԺ�Ż����ƺ�</param>
        /// <param name="p_intType">1ΪסԺ��,2Ϊ���ƺŲ�ѯ</param>
        /// <param name="p_lstNoPayRecipe">����ID</param>
        /// <param name="p_lstRecipeNoPay_VO">�µ�δ���Ѵ���VO</param>
        /// <returns></returns>
        public long m_lngReSetPatientNoPayRecipe(string p_strPatientNO,int p_intType,System.Collections.Generic.List<string> p_lstNoPayRecipe, out System.Collections.Generic.List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngReSetPatientNoPayRecipe(p_strPatientNO, p_intType, p_lstNoPayRecipe, out m_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion
    }
}
