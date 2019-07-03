using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��λ�����߼����Ʋ�
    /// ���ߣ� ����
    /// ����ʱ�䣺 2004-09-13
    /// </summary>
    public class clsDcl_BedAdmin : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���캯��
        public clsDcl_BedAdmin()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #endregion

        #region ����һ�����ż�¼
        /// <summary>
        /// ����һ�����ż�¼
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public long m_lngGetItem(string id, out clsDepart_VO item)
        {
            long lngRes = 0;
            item = null;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc objSvc =
                (com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc));
            try
            {
                lngRes = objSvc.m_lngGetItem(p_objPrincipal, id, out item);
            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region �������в��ż�¼
        /// <summary>
        /// �������в��ż�¼
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc objSvc =
                (com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc));
            DataTable dtbResult = null;
            try
            {
                dtbResult = objSvc.findAll(null);
            }
            catch
            {
                return null;
            }
            objSvc.Dispose();
            return dtbResult;
        }
        #endregion

        #region �������в�����֯����
        /// <summary>
        /// �������в��ż�¼
        /// </summary>
        /// <returns></returns>
        public DataTable findAllAttribute()
        {
            com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc objSvc =
                (com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc));
            DataTable dtbResult = null;
            try
            {
                dtbResult = objSvc.findAllAttribute(null);
            }
            catch
            {
                return null;
            }
            objSvc.Dispose();
            return dtbResult;
        }
        #endregion

        #region ��ȡ�������ĵ�ǰʱ��
        public DateTime m_GetServTime()
        {
            DateTime DTR = DateTime.MinValue;
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetServerDate)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetServerDate));
            try
            {
                DTR = objSvc.m_GetServerDate();
            }
            catch
            {
            }
            objSvc.Dispose();
            return DTR;
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ����	���ݴ�λ��ˮ��
        /// </summary>
        /// <param name="p_strID">��λ��ˮ��</param>
        /// <returns></returns>
        public string m_BedIDToBedNo(string p_strID)
        {
            string strName = "";
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngBedIDToBedNo(objPrincipal, p_strID, out strName);

            }
            catch
            {
                return "";
            } objSvc.Dispose();
            return strName;
        }
        #endregion

        #region ��ѯĳ�����ŵ����в�����Ϣ
        /// <summary>
        /// ��ѯĳ�����ŵ����в�����Ϣ
        /// </summary>
        /// <param name="p_strAreaid_chr">������</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetBedInfoByAreaID(string p_strAreaid_chr, out clsT_Bse_Bed_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsT_Bse_Bed_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetBedInfoByAreaID(objPrincipal, p_strAreaid_chr, out p_objResultArr);
            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯĳ�����š����ŵĲ�����Ϣ
        /// <summary>
        /// ��ѯĳ�����š����ŵĲ�����Ϣ
        /// </summary>
        /// <param name="p_strAreaID_chr">������</param>
        /// <param name="p_strCode_chr">����</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetBedInfoByAreaIDAndCode(string p_strAreaID_chr, string p_strCode_chr, out clsT_Bse_Bed_VO p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetBedInfoByAreaIDAndCode(objPrincipal, p_strAreaID_chr, p_strCode_chr, out p_objResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯĳ����ĳ����ĳ��λ���һ��סԺ�Ļ�����Ϣ
        /// <summary>
        /// ��ѯĳ����ĳ����ĳ��λ���һ��סԺ�Ļ�����Ϣ
        /// </summary>
        /// <param name="p_strDeptID">���ſ�����ˮ��</param>
        /// <param name="p_strAreaID">����-��ˮ��</param>
        /// <param name="p_strBedID">��λ��ˮ��</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByDeptIDAreaIDBedID(string p_strDeptID, string p_strAreaID, string p_strBedID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetPatientInfoByDeptIDAreaIDBedID(objPrincipal, p_strDeptID, p_strAreaID, p_strBedID, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯĳ�����ŵ�����ĳ״̬�Ĳ�����Ϣ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}
        /// <summary>
        /// ��ѯĳ�����ŵ�����ĳ״̬�Ĳ�����Ϣ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}
        /// </summary>
        /// <param name="p_strAreaid_chr">����ID</param>
        /// <param name="p_intStatus_int">����״̬ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}</param>
        /// <param name="p_dtbResult">[DataTable out����]</param>
        /// <returns></returns>
        public long m_lngGetAreaBedInfoByStatus_int(string p_strAreaid_chr, int p_intStatus_int, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetAreaBedInfoByStatus_int(objPrincipal, p_strAreaid_chr, p_intStatus_int, out p_dtbResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region ͳ��סԺ����[��Ч��]����
        /// <summary>
        /// ͳ��סԺ����[��Ч��]����
        /// </summary>
        /// <param name="p_dtbResult">DataTable [out ����]</param>
        /// <returns></returns>
        public long m_lngGetDeptInfo(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetDeptInfo(objPrincipal, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region
        public long m_lngGetsickArea(out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetsickArea(objPrincipal, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͳ��ĳ���ҵ�����[��Ч��]����
        /// <summary>
        /// ͳ��ĳ���ҵ�����[��Ч��]����
        /// </summary>
        /// <param name="p_strDeptID">����ID</param>
        /// <param name="p_dtbResult">DataTable [out ����]</param>
        /// <returns></returns>
        public long m_lngGetDeptAreaInfo(string p_strDeptID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetDeptAreaInfo(objPrincipal, p_strDeptID, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͳ��ĳ����ĳ�����Ŀ�ת��Ĳ�����Ϣ
        /// <summary>
        /// ͳ��ĳ����ĳ�����Ŀ�ת��Ĳ�����Ϣ
        /// </summary>
        /// <param name="p_strDeptID">���ſ���ID</param>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtbResult">[out ����]</param>
        /// <returns></returns>
        public long m_lngMayGetInPatientByAreaID(string p_strDeptID, string p_strAreaID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngMayGetInPatientByAreaID(objPrincipal, p_strDeptID, p_strAreaID, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͳ��ĳ�����Ĵ�λ����
        /// <summary>
        /// ͳ��ĳ�����Ĵ�λ����
        /// </summary>
        /// <param name="p_strAreaid_chr">����ID</param>
        /// <param name="intNumber"></param>
        /// <returns></returns>
        public int m_intStatBedNumberByAreaID(string p_strAreaid_chr)
        {
            int intNumber = 0;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngStatBedNumberByAreaID(objPrincipal, p_strAreaid_chr, out intNumber);
            }
            catch
            {
            }
            objSvc.Dispose();

            return intNumber;
        }
        #endregion

        #region ͳ��ĳ�����Ŀմ�λ����
        /// <summary>
        /// ͳ��ĳ�����Ŀմ�λ����
        /// </summary>
        /// <param name="p_strAreaid_chr">����ID</param>
        /// <param name="intNumber"></param>
        /// <returns></returns>
        public int m_intStatEmptyBedNumberByAreaID(string p_strAreaid_chr)
        {
            int intNumber = 0;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngStatEmptyBedNumberByAreaID(objPrincipal, p_strAreaid_chr, out intNumber);

            }
            catch
            {
            }
            objSvc.Dispose();

            return intNumber;
        }
        #endregion

        #region ͳ��ĳ�����Ŀմ�λ���� [�����Ա�����]
        /// <summary>
        /// ͳ��ĳ�����Ŀմ�λ���� [�����Ա�����]
        /// </summary>
        /// <param name="p_strAreaid_chr">����ID</param>
        /// <param name="intSEX_INT">�Ա�����	[1���У�2��Ů��3�����ޣ�]</param>
        /// <returns></returns>
        public int m_intStatEmptyBedNumberByAreaIDSex(string p_strAreaid_chr, int intSEX_INT)
        {
            int intNumber = 0;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngStatEmptyBedNumberByAreaIDSex(objPrincipal, p_strAreaid_chr, intSEX_INT, out intNumber);

            }
            catch
            {
            }
            objSvc.Dispose();

            return intNumber;
        }
        #endregion

        #region �޸Ĵ�λ��Ϣ
        /// <summary>
        /// �޸Ĵ�λ��Ϣ
        /// </summary>
        /// <param name="p_strBEDID_CHR">��ˮ��</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngModifyBedInfoByVo(string p_strBEDID_CHR, clsT_Bse_Bed_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngModifyBedInfoByVo(objPrincipal, p_strBEDID_CHR, p_objRecord);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ɾ������
        public long m_lngDelPatientOccupyBedByRegisterID(string p_strRegisterID, string p_strBedid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngDelPatientOccupyBedByRegisterID(p_strRegisterID);
            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ����
        public long m_lngQueryOccupyBed(string p_strRegisterid, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngQueryOccupyBed(p_strRegisterid, out dtbResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ����
        public long m_lngGetInfoByRegisterID(string RegisterID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetInfoByRegisterID(null, RegisterID, out dtbResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ��λ�շ���Ϣ
        public long m_lngGetBedChargeItem(out com.digitalwave.iCare.ValueObject.clsT_bse_chargeitem_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsT_bse_chargeitem_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetBedChargeItem(objPrincipal, out p_objResultArr);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ�յ��շ���Ϣ
        /// <summary>
        /// ����յ��շ���Ϣ
        /// </summary>
        public long m_lngGetAIRRATEChargeItem(out com.digitalwave.iCare.ValueObject.clsT_bse_chargeitem_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsT_bse_chargeitem_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetAIRRATEChargeItem(objPrincipal, out p_objResultArr);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��֤�����Ƿ��ǲ���
        /// <summary>
        /// ��֤�����Ƿ��ǲ���
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDEPTID_CHR">����ID</param>
        /// <returns></returns>
        public bool IsIllAreaID(string p_strDEPTID_CHR)
        {
            bool IsAreaID = false;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.lngCheckIsIllAreaID(objPrincipal, p_strDEPTID_CHR, out IsAreaID);

            }
            catch
            {
            }
            objSvc.Dispose();
            return IsAreaID;
        }
        #endregion

        #region ��ʱ��ȡ��λ��
        public long m_lngCreateDailyChargeAUTO(string p_strOperatorID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            try
            {
                lngRes = objSvc.m_lngCreateDailyChargeAUTO(objPrincipal, p_strOperatorID);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ�շ���Ŀ��Ϣ
        public long m_lngGetChargeNameByID(string p_strChargeItemID, out com.digitalwave.iCare.ValueObject.clsT_bse_chargeitem_VO p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetChargeNameByID(objPrincipal, p_strChargeItemID, out p_objResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��ѯ�������µĵ�ת��Ϣ
        public long m_lngGetPatientLastestTransferInfo(string p_strRegisterID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetPatientLastestTransferInfo(objPrincipal, p_strRegisterID, out p_dtbResult);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ����ת��
        public long m_lngUndoTransferOut(string AreaID, string strTransferID, string RegisterID, string BedID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngUndoTransferOut(objPrincipal, AreaID, strTransferID, RegisterID, BedID);

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͳ��סԺ����ת��Ϣ
        /// <summary>
        /// ��Ժ��־
        /// </summary>
        /// <param name="p_intType"></param>
        /// <param name="p_strAreaid"></param>
        /// <param name="p_BeginTime"></param>
        /// <param name="p_EndTime"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetInhospitalReportData(int p_intType, string p_strAreaid, System.DateTime p_BeginTime, System.DateTime p_EndTime, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetInhospitalReportData(p_intType, p_strAreaid, p_BeginTime, p_EndTime, out p_dtbResult);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }

        /// <summary>
        /// ��Ժ��־����
        /// </summary>
        /// <param name="p_strAreaid"></param>
        /// <param name="p_BeginTime"></param>
        /// <param name="p_EndTime"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetOuthospitalReportData(string p_strAreaid, System.DateTime p_BeginTime, System.DateTime p_EndTime, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            try
            {
                lngRes = objSvc.m_lngGetOuthospitalReportData(p_strAreaid, p_BeginTime, p_EndTime, out p_dtbResult);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        #endregion

        #region �����շ��ر����
        public long m_GetEXType(string strFlag, out clsChargeItemEXType_VO[] objResult)
        {
            long lngRes = 0;
            objResult = new clsChargeItemEXType_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
            try
            {
                lngRes = objSvc.m_lngFindChargeItemEXTypeListByFlag(objPrincipal, strFlag, out objResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ����һ�������շ����
        public long m_lngAddOneItem(string ItemID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            lngRes = objSvc.m_lngAddOneItem(ItemID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region  ɾ��һ�������շ����
        public long m_lngDeleteOneItem(string ItemID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            try
            {
                lngRes = objSvc.m_lngDeleteOneItem(ItemID);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ��������Ȩ��
        /// <summary>
        /// ���˳���Ȩ�޵Ĳ���
        /// </summary>
        /// <param name="p_objArea">��������</param>
        /// <param name="p_ilUsableAreaID">��Ȩ���ʵĲ���ID����</param>
        /// <returns>��Ȩ���ʵĲ������󼯺�</returns>
        public System.Collections.IList GetUsableAreaObject(clsBIHArea[] p_objArea, System.Collections.IList p_ilUsableAreaID)
        {
            System.Collections.IList ilRes = new System.Collections.ArrayList();
            if (p_objArea == null || p_objArea.Length <= 0) return ilRes;

            //ȫ���Ŀɷ��ʵĲ�������
            for (int i1 = 0; i1 < p_objArea.Length; i1++)
            {
                if (p_objArea[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objArea[i1].m_strAreaID.Trim()))
                {
                    if (!(ilRes.Contains(p_objArea[i1])))
                        ilRes.Contains(ilRes);
                }
            }
            return ilRes;
        }
        #endregion

        #region
        public string m_mlngGetEMRroomIDBYAREAID(string AreaID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            string strtemp = "";
            try
            {
                strtemp = objSvc.m_mlngGetEMRroomIDBYAREAID(AreaID);
            }
            catch
            {
                return "";
            }
            return strtemp;
        }
        #endregion

        #region
        public string m_mlngGetEMRbedIDBYbedcode(string roomID, string bedcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            string strtemp = "";
            try
            {
                strtemp = objSvc.m_mlngGetEMRbedIDBYbedcode(roomID, bedcode);
            }
            catch
            {
                return "";
            }
            return strtemp;
        }
        #endregion

        #region
        public bool m_blnEMRGetInPatientByID(string InpatientID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            bool bln = false;
            try
            {
                bln = objSvc.m_blnEMRGetInPatientByID(InpatientID);
            }
            catch
            {
            }
            return bln;

        }
        #endregion

        #region �ж��Ƿ��籣�Ǽ�
        /// <summary>
        /// �ж��Ƿ��籣�Ǽ�
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public bool IsYbReg(string regId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc svc = (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)))
            {
                return svc.IsYbReg(regId);
            }
        }
        #endregion
    }
}
