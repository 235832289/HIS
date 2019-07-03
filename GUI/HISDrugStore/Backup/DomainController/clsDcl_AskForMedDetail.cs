using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ��������ϸ
    /// </summary>
    public class clsDcl_AskForMedDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {   
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsDcl_AskForMedDetail()
        {
        }
        /// <summary>
        /// ��ȡ����ҩƷ��Ϣ
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfo(string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfo(objPrincipal,m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ����ҩƷ��Ϣ(��������Ϣ)
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoForAsk(string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoForAsk(objPrincipal, m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ����ҩƷ��Ϣ(��������Ϣ)(��ʾ�����Ϣ)
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoForAskWithStorageInfo(bool p_blnIsHospital,string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoForAskWithStorageInfo(objPrincipal, p_blnIsHospital,m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }
        
        /// <summary>
        /// ��ȡҩ������ҩƷ������Ϣ
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetOutStorageMedicineInfo(bool p_blnIsHospital,string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetOutStorageMedicineInfo(objPrincipal,p_blnIsHospital, m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }
        /// <summary>
        /// �������к�ɾ��ҩƷid
        /// </summary>
        /// <param name="m_strSeqid"></param>
        /// <returns></returns>
        public long m_lngDelMedDetail(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngDelAskMedDetail(objPrincipal, m_lngSeqid);
            return lngRes;
        }
        /// <summary>
        /// ����ҩ�������������ϸ������
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngAddNewAskMedInfo(ref clsDS_Ask_VO m_objMainVo, ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngAddNewAskMedInfo(objPrincipal,ref m_objMainVo,ref m_objDetailArr);
            return lngRes;
        }
        /// <summary>
        /// ����ҩ�������������ϸ������
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngUpdateAskMedInfo(clsDS_Ask_VO m_objMainVo, ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngUpdateAskMedInfo(objPrincipal, m_objMainVo, ref m_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ����ҩƷ��Ϣ
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoWithStorageID(string m_strMedStoreid, string p_strStorageID,out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoWithStorageID(objPrincipal, m_strMedStoreid,p_strStorageID, out m_dtMedicine);
            return lngRes;
        }
       
        /// <summary>
        /// ��ȡ���쵥״̬�Ƿ��ύ��
        /// </summary>
        /// <param name="p_strAskID"></param>
        /// <returns></returns>
        public long m_lngCheckStatus(string p_strAskID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_strAskID);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ���ݿ��������ǰʱ��
        /// </summary>
        /// <param name="p_dtmDateTime"></param>
        /// <returns></returns>
        public long m_lngGetSystemDateTime(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objDomain =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objDomain.m_lngGetSystemDateTime(out p_dtmDateTime);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ�м����������ǰʱ��
        /// </summary>
        /// <param name="p_dtmDateTime"></param>
        /// <returns></returns>
        public long m_lngGetCurrentDateTime(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objDomain =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objDomain.m_lngGetCurrentDateTime(out p_dtmDateTime);
            return lngRes;
        }

        /// <summary>
        /// �������������ݵ�״̬
        /// </summary>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        public long m_lngDeleteBill(string p_strBillID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngDeleAskInfo(objPrincipal, p_strBillID);
            return lngRes;
        }

        /// <summary>
        /// ��ѯ���쵥״̬
        /// </summary>
        /// <param name="p_strSeq">���쵥���к�</param>
        /// <param name="p_intQueryStyle">��ѯ��ʽ:0-���������кŲ�ѯ,1-���ӱ����кŲ�ѯ</param>
        /// <param name="p_strStatus">���쵥״̬</param>
        /// <returns></returns>
        public long m_lngQueryAskMedStatus(string p_strSeq, int p_intQueryStyle, out string p_strStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngQueryAskMedStatus(p_strSeq, p_intQueryStyle, out p_strStatus);
            return lngRes;
        }

    }
}
