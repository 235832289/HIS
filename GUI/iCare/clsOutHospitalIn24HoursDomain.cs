using System;
using com.digitalwave.DiseaseTrackService;
using iCareData;

namespace iCare
{

	/// <summary>
	///  操作多个记录类型的领域层。作为信息的转发控制器，用来连接界面和中间件。
	/// </summary>
	public class clsOutHospitalIn24HoursDomain
	{

        //protected clsDiseaseTrackService m_objRecordsServ = new clsEMR_OutHospitalIn24HoursService();
		
		/// <summary>
		/// 获取病人的该记录时间列表。
		/// </summary>
		/// <param name="p_strInPatientID">住院号</param>
		/// <param name="p_strInPatientDate">入院日期</param>
		/// <param name="p_strCreateDateArr">用户填写的创建时间数组</param>
		/// <param name="p_strOpenDateArr">系统生成的开始时间数组</param>
		/// <returns></returns>
		public long m_lngGetRecordTimeList(string p_strInPatientID,
			string p_strInPatientDate,
			out string[] p_strCreateDateArr,
			out string[] p_strOpenDateArr)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsDiseaseTrackService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OutHospitalIn24HoursService));

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
		/// 获取指定记录的内容。
		/// </summary>
		/// <param name="p_strInPatientID">住院号</param>
		/// <param name="p_strInPatientDate">入院日期</param>
		/// <param name="p_strOpenDate">记录时间</param>
		/// <param name="p_objRecordContent">返回的记录内容</param>
		/// <returns></returns>
		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			out clsTrackRecordContent p_objRecordContent)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsDiseaseTrackService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OutHospitalIn24HoursService));

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
		/// 更新数据库中的首次打印时间。
		/// </summary>
		/// <param name="p_strInPatientID">住院号</param>
		/// <param name="p_strInPatientDate">入院日期</param>
		/// <param name="p_strOpenDate">记录时间</param>
		/// <param name="p_dtmFirstPrintDate">首次打印时间</param>
		/// <returns></returns>
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			DateTime p_dtmFirstPrintDate)
		{
            clsDiseaseTrackService m_objRecordsServ =
                (clsDiseaseTrackService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OutHospitalIn24HoursService));

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
        /// 获取全部作废记录clsConsultationService
        /// </summary>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService objServ =
                    (com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsEMR_OutHospitalIn24HoursService));

            long lngRes = objServ.m_lngGetAllInactiveInfo(p_strInpatientId, p_dtmInpatientDate, out p_objInactiveRecordInfoArr);
            objServ = null;
            return lngRes;
        }

	}
}
