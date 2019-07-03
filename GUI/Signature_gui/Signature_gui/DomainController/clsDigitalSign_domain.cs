using System;
using System.Windows.Forms;
using iCareData;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using com.digitalwave.Emr.DigitalSign_srv;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.Emr.Signature_gui
{
    /// <summary>
    /// ����ǩ����������ݿ�
    /// </summary>
    public class clsDigitalSign_domain
    {
        #region ����Ƿ���Ҫ����ǩ��
        /// <summary>
        /// ����Ƿ���Ҫ����ǩ��
        /// </summary>
        /// <param name="p_strFormID">����ID</param>
        /// <param name="p_blnNeed">false����Ҫ true��Ҫ</param>
        /// <returns></returns>
        public long m_lngCheckNeedToSign(string p_strFormID, out bool p_blnNeed)
        {
            long lngRes = 0;
            p_blnNeed = false;
            try
            {
                clsDigitalSign_srv objSvc =
                    (clsDigitalSign_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDigitalSign_srv));

                lngRes = objSvc.m_lngCheckNeedToSign(null, p_strFormID, out p_blnNeed);
                //�ͷ�
                objSvc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion
        
        #region ��������ǩ����Ϣ
        /// <summary>
        /// ��������ǩ����Ϣ
        /// </summary>
        /// <param name="p_strInsertSql">ǩ��vo</param>
        /// <param name="p_blnIsHistory">���浽ʵʱ������ʷ��(true=��ʷ;false=ʵʱ)</param>
        /// <returns></returns>
        public long m_lngAddDigitalSign(clsEmrDigitalSign_VO p_objRecord)
        {
            long lngRes = 0;
            try
            {
                clsDigitalSign_srv objSvc =
                    (clsDigitalSign_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDigitalSign_srv));

                lngRes = objSvc.m_lngAddDigitalSign(null, p_objRecord);
                //�ͷ�
                objSvc = null;

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = 0;
            }
            return lngRes;
        }

        #endregion

        #region ��ȡָ�����ݵ���������ǩ����Ϣ
        /// <summary>
        /// ��ȡָ�����ݵ���������ǩ����Ϣ
        /// �ȵ�ʵʱ��飬���ʵʱ��û���ٵ���ʷ���
        /// </summary>
        /// <param name="p_strFormID">����ID</param>
        /// <param name="p_strFormRecordID">��¼��</param>
        /// <param name="p_blnIsOutPatient">(false=δ����Ժ�����뵽��ʷ���ȡ����)</param>
        /// <param name="p_dtbValue">���ر�</param>
        /// <returns></returns>
        public long m_lngGetDigitalSign(string p_strFormID, string p_strFormRecordID, bool p_blnIsOutPatient, out clsEmrDigitalSign_VO p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;
            try
            {
                clsDigitalSign_srv objSvc =
                    (clsDigitalSign_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDigitalSign_srv));

                DataTable dtbResult = new DataTable();
                lngRes = objSvc.m_lngGetDigitalSign(null, p_strFormID, p_strFormRecordID, p_blnIsOutPatient, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsEmrDigitalSign_VO();
                    byte[] b = { 0x00, 0x12 };
                    p_objResult.m_intSIGNID_INT = dtbResult.Rows[0]["SIGNID_INT"] == DBNull.Value ? 0 : Convert.ToInt32(dtbResult.Rows[0]["SIGNID_INT"]);
                    p_objResult.m_strFORMID_VCHR = dtbResult.Rows[0]["FORMID_VCHR"] == DBNull.Value ? "" : dtbResult.Rows[0]["SIGNID_INT"].ToString();
                    p_objResult.m_strFORMRECORDID_VCHR = dtbResult.Rows[0]["FORMRECORDID_VCHR"] == DBNull.Value ? "" : dtbResult.Rows[0]["FORMRECORDID_VCHR"].ToString();
                    p_objResult.m_bteCONTENT_TXT = (byte[])(dtbResult.Rows[0]["CONTENT_TXT"]);
                    p_objResult.m_strDSCONTENT_TXT = dtbResult.Rows[0]["DSCONTENT_TXT"] == DBNull.Value ? "" : dtbResult.Rows[0]["DSCONTENT_TXT"].ToString();
                    p_objResult.m_strSIGNNAME_VCHR = dtbResult.Rows[0]["SIGNNAME_VCHR"] == DBNull.Value ? "" : dtbResult.Rows[0]["SIGNNAME_VCHR"].ToString();
                    p_objResult.m_strSIGNIDID_VCHR = dtbResult.Rows[0]["SIGNIDID_VCHR"] == DBNull.Value ? "" : dtbResult.Rows[0]["SIGNIDID_VCHR"].ToString();
                    p_objResult.m_datSIGNDATE_DAT = dtbResult.Rows[0]["SIGNDATE_DAT"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dtbResult.Rows[0]["SIGNDATE_DAT"].ToString());
                    p_objResult.m_strDESCRIPTION_VCHR = dtbResult.Rows[0]["DESCRIPTION_VCHR"] == DBNull.Value ? "" : dtbResult.Rows[0]["DESCRIPTION_VCHR"].ToString();

                }
                //�ͷ�
                objSvc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }


        #endregion

        #region ��ָ�����˵ļ�¼��ʵʱ���Ƶ���ʷ��
        /// <summary>
        /// ��ָ�����˵ļ�¼��ʵʱ���Ƶ���ʷ��
        /// </summary>
        /// <param name="p_strFormRecordID">סԺ��-סԺ����:��(00134272-2005-11-18 08:11:50)</param>
        /// <returns></returns>
        public long m_lngMoveDigitalSign(string p_strFormRecordID)
        {
            clsDigitalSign_srv objSvc =
                (clsDigitalSign_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDigitalSign_srv));

            long lngRes = objSvc.m_lngMoveDigitalSign(null, p_strFormRecordID);
            objSvc = null;
            return lngRes;
        }
        #endregion ��ָ�����˵ļ�¼��ʵʱ���Ƶ���ʷ��

        #region ��ȡǩ������
        /// <summary>
        /// �Ƿ��ȡȫԺԱ��
        /// </summary>
        /// <param name="p_strSetID">����ID</param>
        /// <param name="p_intConfig">ǩ������</param>
        /// <returns></returns>
        public long m_lngGetSignConfig(string p_strSetID, out int p_intConfig)
        {
            p_intConfig = 0;
            long lngRes = 0;
            try
            {
                string strReturnValue = string.Empty;
                com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objServ =
                    (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

                lngRes = objServ.m_lngGetConfigBySettingID(p_strSetID, out strReturnValue);
                objServ = null;

                int.TryParse(strReturnValue, out p_intConfig);
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            return lngRes;
        }
        #endregion

        #region ���ݿ���IDȡ��ҽ����Ϣ
        /// <summary>
        /// ���ݿ���IDȡ��ҽ����Ϣ
        /// </summary>
        public long m_lngGetDocByDepID(string empId, out clsEmployeeVO[] p_objResultArr)
        {
            p_objResultArr = new clsEmployeeVO[0];

            long lngRes = 0;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.m_lngGetEmployeeList(objPrincipal, empId, null, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region GetEmpInfo
        /// <summary>
        /// GetEmpInfo
        /// </summary>
        /// <param name="empNo"></param>
        /// <returns></returns>
        public DataTable GetEmpInfo(string empNo)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsCharge svc = (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge)))
            {
                return svc.GetEmpInfo(empNo);
            }
        }
        #endregion
    }
}
