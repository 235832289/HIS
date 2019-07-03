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
        /// 查询所有有效科室
        /// </summary>
        /// <param name="p_dtbResult">查询结果</param>
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
                clsPublicFunction.ShowInformationMessageBox("查询科室信息出错，原因：" + System.Environment.NewLine
                    + ex.Message);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取指定科室的会诊情况
        /// </summary>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_dtmStartTime">查询开始时间</param>
        /// <param name="p_dtmEndTime">查询结束时间</param>
        /// <param name="p_intSendOrReceive">发送或接收科室０：发送科室；１：接收科室</param>
        /// <param name="p_dtbResult">查询结果</param>
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
        /// 获取所有科室的会诊情况
        /// </summary>
        /// <param name="p_dtmStartTime">查询开始时间</param>
        /// <param name="p_dtmEndTime">查询结束时间</param>
        /// <param name="p_dtbResult">查询结果</param>
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
        /// 获取全部作废记录clsConsultationService
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
