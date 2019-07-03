using System;
using com.digitalwave.clsRecordsService;
using iCareData;

namespace iCare
{

	/// <summary>
	///  ���������¼���͵�����㡣��Ϊ��Ϣ��ת�����������������ӽ�����м����
	/// </summary>
	public class clsRecordsDomain
	{

        //protected clsRecordsService m_objRecordsServ;
        enmRecordsType m_enmRecordsType = new enmRecordsType();

		/// <summary>
		///  ���캯��������Ϊָ�����м����
		/// </summary>
		/// <param name="p_objRecordsServ"></param>
        public clsRecordsDomain(enmRecordsType p_enmRecordsType)
		{
            //m_objRecordsServ =  p_objRecordsServ;
            m_enmRecordsType = p_enmRecordsType;
		}

		/// <summary>
		/// ��ȡָ����¼���ݡ�
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_objTansDataInfoArr"></param>
		/// <returns></returns>
		public long m_lngGetTransDataInfoArr(string p_strInPatientID,
			string p_strInPatientDate,
			out clsTransDataInfo[] p_objTansDataInfoArr)
		{   
			//�����ж�
			p_objTansDataInfoArr = null;
			if(string.IsNullOrEmpty(p_strInPatientID) || string.IsNullOrEmpty(p_strInPatientDate))
				return (long)enmOperationResult.Parameter_Error;

            clsRecordsService m_objServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objServ.m_lngGetTransDataInfoArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out p_objTansDataInfoArr);
            //m_objServ.Dispose();
            return lngRes;
        }
        /// <summary>
        /// ��ȡָ����¼���ݡ�
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_objTansDataInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetTransDataInfoArr(string p_strRegisterId,out clsTransDataInfo[] p_objTansDataInfoArr)
        {
            //�����ж�
            p_objTansDataInfoArr = null;
            if (string.IsNullOrEmpty(p_strRegisterId))
                return (long)enmOperationResult.Parameter_Error;
            clsRecordsService m_objServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objServ.m_lngGetTransDataInfoArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterId, out p_objTansDataInfoArr);
            //m_objServ.Dispose();
            m_objServ = null;
            return lngRes;
        }
        #region ����
        /// <summary>
        /// ��ȡָ����¼���ݣ���ɽ�������ų��Ļ�����ã���
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strFormID"></param>
        /// <param name="p_objTansDataInfoArr"></param>
        /// <returns></returns>
        //public long m_lngGetTransDataInfoArr(string p_strInPatientID,
        //    string p_strInPatientDate,string p_strFormID,
        //    out clsTransDataInfo[] p_objTansDataInfoArr)
        //{
        //    //�����ж�
        //    p_objTansDataInfoArr = null;
        //    if (string.IsNullOrEmpty(p_strInPatientID) || string.IsNullOrEmpty(p_strInPatientDate))
        //        return (long)enmOperationResult.Parameter_Error;

        //    clsRecordsService m_objServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
        //    long lngRes = m_objServ.m_lngGetTransDataInfoArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate,p_strFormID, out p_objTansDataInfoArr);
        //    //m_objServ.Dispose();
        //    return lngRes;
        //}
        #endregion
        /// <summary>
		///  ɾ����¼��
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_objModifyInfo"></param>
		/// <returns></returns>
		public long m_lngDeleteRecord(int p_intRecordType,
			clsTrackRecordContent p_objRecordContent,
			out clsPreModifyInfo p_objModifyInfo)
		{
			//�����ж�
			p_objModifyInfo = null;
			if(p_intRecordType < 0 || p_objRecordContent == null)
				return (long)enmOperationResult.Parameter_Error;
            clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objRecordsServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_intRecordType, p_objRecordContent, out p_objModifyInfo);
            //m_objRecordsServ.Dispose();
            return lngRes;
		}

		/// <summary>
		/// ��ȡ��ӡ��Ϣ��
		/// 1.��ȡ��ӡ���ݣ�����������p_dtmModifyDate�������µ�ModifyDate��������� p_objContent
		///   �������µ����ݣ������������Ϊnull��
		/// 2.��ȡ��ӡʱ�䣺������� p_dtmFirstPrintDate ����״δ�ӡʱ�䡣p_blnIsFirstPrint���
		///   �Ƿ��״δ�ӡ�������Ϊtrue���ͻ����ڴ�ӡ����Ҫ����p_dtmFirstPrintDate�����ݿ⡣
		/// </summary>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_objTransDataInfoArr"></param>
		/// <param name="p_dtmFirstPrintDateArr"></param>
		/// <param name="p_blnIsFirstPrintArr"></param>
		/// <returns></returns>
		public long m_lngGetPrintInfo(string p_strInPatientID,
			string p_strInPatientDate,
			out clsTransDataInfo[] p_objTransDataInfoArr,
			out DateTime[] p_dtmFirstPrintDateArr,
			out bool[] p_blnIsFirstPrintArr)
		{
			p_objTransDataInfoArr = null;
			p_dtmFirstPrintDateArr = null;
			p_blnIsFirstPrintArr = null;

			if(p_strInPatientID == null || p_strInPatientID == "")
				return (long)enmOperationResult.Parameter_Error;
			if(p_strInPatientDate == null || p_strInPatientDate == "")
				return (long)enmOperationResult.Parameter_Error;
            clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objRecordsServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID,
				p_strInPatientDate,
				out p_objTransDataInfoArr,
				out p_dtmFirstPrintDateArr,
				out p_blnIsFirstPrintArr);
            //m_objRecordsServ.Dispose();
            return lngRes;
		}

        /// <summary>
        /// ��ȡ��ӡ��Ϣ���ظ��ݵǼǺ�
        /// </summary>
        /// <param name="p_strInPatientID"></param>string p_strRegisterId
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_objTransDataInfoArr"></param>
        /// <param name="p_dtmFirstPrintDateArr"></param>
        /// <param name="p_blnIsFirstPrintArr"></param>
        /// <returns></returns>
        public long m_lngGetPrintInfo(string p_strRegisterId,
        int p_intStatus,
        out clsTransDataInfo[] p_objTransDataInfoArr,
        out DateTime[] p_dtmFirstPrintDateArr,
        out bool[] p_blnIsFirstPrintArr)
        {
            p_objTransDataInfoArr = null;
            p_dtmFirstPrintDateArr = null;
            p_blnIsFirstPrintArr = null;

            //if (p_strInPatientID == null || p_strInPatientID == "")
            //    return (long)enmOperationResult.Parameter_Error;
            //if (p_strInPatientDate == null || p_strInPatientDate == "")
            //    return (long)enmOperationResult.Parameter_Error;
            clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objRecordsServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterId,
                p_intStatus,
                out p_objTransDataInfoArr,
                out p_dtmFirstPrintDateArr,
                out p_blnIsFirstPrintArr);
            //m_objRecordsServ.Dispose();
            return lngRes;
        }

		/// <summary>
		///  �������ݿ��е��״δ�ӡʱ�䡣
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_intRecordTypeArr"></param>
		/// <param name="p_dtmOpenDateArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		/// <returns></returns>
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
			string p_strInPatientDate,
			int[] p_intRecordTypeArr,
			DateTime[] p_dtmOpenDateArr,
			DateTime p_dtmFirstPrintDate)
		{
			if(p_strInPatientID == null || p_strInPatientID == "")
				return (long)enmOperationResult.Parameter_Error;
			if(p_strInPatientDate == null || p_strInPatientDate == "")
				return (long)enmOperationResult.Parameter_Error;
			if(p_intRecordTypeArr == null || p_intRecordTypeArr.Length <= 0)
				return (long)enmOperationResult.Parameter_Error;
			if(p_dtmOpenDateArr == null || p_dtmOpenDateArr.Length <= 0)
				return (long)enmOperationResult.Parameter_Error;
            clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objRecordsServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_intRecordTypeArr, p_dtmOpenDateArr, p_dtmFirstPrintDate);
            //m_objRecordsServ.Dispose();
            return lngRes;
		}
        
        /// <summary>
        /// ��ȡһ��סԺȫ�����ϼ�¼
        /// </summary>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strSQL, string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
            long lngRes = m_objRecordsServ.m_lngGetAllInactiveInfo(p_strSQL, p_strInpatientId,  p_dtmInpatientDate, out  p_objInactiveRecordInfoArr);
            //m_objRecordsServ.Dispose();
            return lngRes;
        }
        
        /// <summary>
        /// ת����Ϣ��ѯ --> 20151208 ������EMR_clsRecordsServiceҲδ�ҵ��÷��������ɸ÷���δͶ��ʹ��
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_intdetpID"></param>
        /// <param name="p_objModifyInfo"></param>
        /// <returns></returns>
        //public long m_lngGetTransferInfo(string p_strRegisterID, string p_intdetpID,
        //           out DateTime[] p_objModifyInfo)
        //{
        //    p_objModifyInfo = null;
        //    clsRecordsService m_objRecordsServ = clsRecordsDomainFactory.s_objGetRecordsDomain(m_enmRecordsType);
        //    long lngRes = m_objRecordsServ.m_lngGetTransferInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID,
        //        p_intdetpID,
        //        out p_objModifyInfo);

        //    return lngRes;
        //}
	}
}
