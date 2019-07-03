using System;
using com.digitalwave.DiseaseTrackService;
using com.digitalwave.EMR_DeathRecorIn24HoursService;
using iCareData;


namespace iCare
{
	/// <summary>
	/// clsDeathRecordIn24HoursDomain 的摘要说明。
	/// Description:入院24小时内死亡记录DOMAIN类,操作多个记录类型的领域层,用于连接界面和中间件
	/// Author:Jock
	/// Date:06-01-03
	/// </summary>
	public class clsDeathRecordIn24HoursDomain
	{
		public clsDeathRecordIn24HoursDomain()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
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
            clsEMR_DeathRecorIn24HoursService m_objServ =
                (clsEMR_DeathRecorIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_DeathRecorIn24HoursService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out p_strCreateDateArr,out p_strOpenDateArr);
            }
            finally
            {
                //m_objServ.Dispose();
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
            clsEMR_DeathRecorIn24HoursService m_objServ =
                (clsEMR_DeathRecorIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_DeathRecorIn24HoursService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
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
            clsEMR_DeathRecorIn24HoursService m_objServ =
                (clsEMR_DeathRecorIn24HoursService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_DeathRecorIn24HoursService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate, p_dtmFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	}
}
