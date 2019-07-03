using System;
using System.Data;
using com.digitalwave.DiseaseTrackService;
using iCareData;
using com.digitalwave.DepartmentManagerService;

namespace iCare
{
	/// <summary>
	/// Summary description for clsConsultationDomain.
	/// </summary>
	public class clsConsultationDomain
	{
        //protected clsDiseaseTrackService m_objRecordsServ=new clsConsultationService();
		
		/// <summary>
		/// ��ȡ���˵ĸü�¼ʱ���б�
		/// </summary>
		/// <param name="p_strInPatientID">סԺ��</param>
		/// <param name="p_strInPatientDate">��Ժ����</param>
		/// <param name="p_strCreateDateArr">�û���д�Ĵ���ʱ������</param>
		/// <param name="p_strOpenDateArr">ϵͳ���ɵĿ�ʼʱ������</param>
		/// <returns></returns>
		public long m_lngGetRecordTimeList(string p_strInPatientID,
			string p_strInPatientDate,
			out string[] p_strCreateDateArr,
			out string[] p_strOpenDateArr)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

			long lngRes = 0;
            try
            {
                lngRes = m_objRecordsServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out p_strCreateDateArr,out p_strOpenDateArr);
            }
            finally
            {
                //m_objRecordsServ.Dispose();
            }
            return lngRes;
		}
		
		/// <summary>
		/// ��ȡָ����¼�����ݡ�
		/// </summary>
		/// <param name="p_strInPatientID">סԺ��</param>
		/// <param name="p_strInPatientDate">��Ժ����</param>
		/// <param name="p_strOpenDate">��¼ʱ��</param>
		/// <param name="p_objRecordContent">���صļ�¼����</param>
		/// <returns></returns>
		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			out clsTrackRecordContent p_objRecordContent)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

			long lngRes = 0;
            try
            {
                lngRes = m_objRecordsServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_objRecordContent);
            }
            finally
            {
                //m_objRecordsServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// �������ݿ��е��״δ�ӡʱ�䡣
		/// </summary>
		/// <param name="p_strInPatientID">סԺ��</param>
		/// <param name="p_strInPatientDate">��Ժ����</param>
		/// <param name="p_strOpenDate">��¼ʱ��</param>
		/// <param name="p_dtmFirstPrintDate">�״δ�ӡʱ��</param>
		/// <returns></returns>
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			DateTime p_dtmFirstPrintDate)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

			long lngRes = 0;
            try
            {
                lngRes = m_objRecordsServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate, p_dtmFirstPrintDate);
            }
            finally
            {
                //m_objRecordsServ.Dispose();
            }
            return lngRes;
		}

        /// <summary>
        /// ��ѯ������Ч����
        /// </summary>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngGetAllDept(out DataTable p_dtbResult)
        {
            clsDepartmentManagerService m_objDeptServ =
                (clsDepartmentManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDepartmentManagerService));

            p_dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                lngRes = m_objDeptServ.m_lngGetAllDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out p_dtbResult);
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox("��ѯ������Ϣ����ԭ��" + System.Environment.NewLine
                    + ex.Message);
            }
            return lngRes;
        }

        /// <summary>
        /// ��ȡָ�����ҵĻ������
        /// </summary>
        /// <param name="p_strDeptID">����ID</param>
        /// <param name="p_dtmStartTime">��ѯ��ʼʱ��</param>
        /// <param name="p_dtmEndTime">��ѯ����ʱ��</param>
        /// <param name="p_intSendOrReceive">���ͻ���տ��ң������Ϳ��ң��������տ���</param>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngSearchSpesifyDeptConsultationSituation(string p_strDeptID, DateTime p_dtmStartTime,
            DateTime p_dtmEndTime, int p_intSendOrReceive, out DataTable p_dtbResult)
        {
            clsConsultationService objServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

            long lngRes = objServ.m_lngSearchSpesifyDeptConsultationSituation(p_strDeptID, p_dtmStartTime, p_dtmEndTime,p_intSendOrReceive, out p_dtbResult);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ���п��ҵĻ������
        /// </summary>
        /// <param name="p_dtmStartTime">��ѯ��ʼʱ��</param>
        /// <param name="p_dtmEndTime">��ѯ����ʱ��</param>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngSearchAllDeptConsultationSituation(DateTime p_dtmStartTime,
            DateTime p_dtmEndTime, out DataTable p_dtbResult)
        {
            clsConsultationService objServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

            long lngRes = objServ.m_lngSearchAllDeptConsultationSituation(p_dtmStartTime, p_dtmEndTime, out p_dtbResult);
            return lngRes;
        }

        /// <summary>
        /// ��ȡȫ�����ϼ�¼clsConsultationService
        /// </summary>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            com.digitalwave.DiseaseTrackService.clsConsultationService objServ =
                    (com.digitalwave.DiseaseTrackService.clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsConsultationService));

            long lngRes = objServ.m_lngGetAllInactiveInfo(p_strInpatientId, p_dtmInpatientDate, out p_objInactiveRecordInfoArr);
            objServ = null;
            return lngRes;
        }

	}
}
