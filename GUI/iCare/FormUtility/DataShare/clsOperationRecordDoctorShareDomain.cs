using System;
using System.Data;
using com.digitalwave.DataShareService;

namespace iCare
{
	/// <summary>
	/// 手术记录单数据共享
	/// </summary>
	public class clsOperationRecordDoctorShareDomain
	{
        //private clsOperationRecordDoctorShareService m_objServ;

		public clsOperationRecordDoctorShareDomain()
		{
            //m_objServ = new clsOperationRecordDoctorShareService();
		}

		/// <summary>
		/// 获取手术数据，只为住院病案首页提供共享
		/// </summary>
		/// <param name="p_strInPaitentID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_stuResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBaseOperationValueArr(string p_strInPaitentID,string p_strInPatientDate, out stuBaseOperationValue[] p_stuResultArr)
		{
			p_stuResultArr = null;
			
			DataTable dtbResult;

            clsOperationRecordDoctorShareService m_objServ =
                (clsOperationRecordDoctorShareService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorShareService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetBaseOperationValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID, p_strInPatientDate,out dtbResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes <= 0)
				return lngRes;

			p_stuResultArr = new stuBaseOperationValue[dtbResult.Rows.Count];

			for(int i=0;i<p_stuResultArr.Length;i++)
			{
                //手术记录单
				p_stuResultArr[i].m_strAnaesther = dtbResult.Rows[i]["ANAESTHER"].ToString();
				p_stuResultArr[i].m_strAnaesthesiaCategoryDosage = dtbResult.Rows[i]["ANAESTHESIACATEGORYDOSAGE"].ToString();
				p_stuResultArr[i].m_strOperationBeginDate = dtbResult.Rows[i]["OPERATIONBEGINDATE"].ToString();
				p_stuResultArr[i].m_strFirstAssistantID = dtbResult.Rows[i]["FIRSTASSISTANTID"].ToString();
				p_stuResultArr[i].m_strFirstAssistantName = dtbResult.Rows[i]["FIRSTASSISTANTNAME"].ToString();
				p_stuResultArr[i].m_strOperationDoctorID = dtbResult.Rows[i]["OPERATIONDOCTORID"].ToString();
				p_stuResultArr[i].m_strOperationDoctorName = dtbResult.Rows[i]["OPERATIONDOCTORNAME"].ToString();
				p_stuResultArr[i].m_strOperationName = dtbResult.Rows[i]["OPERATIONNAME"].ToString();
				p_stuResultArr[i].m_strSecondAssistantID = dtbResult.Rows[i]["SECONDASSISTANTID"].ToString();
				p_stuResultArr[i].m_strSecondAssistantName = dtbResult.Rows[i]["SECONDASSISTANTNAME"].ToString();
                p_stuResultArr[i].m_strOperationCutLevel = ""; //dtbResult.Rows[i]["CUTLEVEL"].ToString();
                p_stuResultArr[i].m_strZqOperation = "";// dtbResult.Rows[i]["OPERATIONELECTIVE"].ToString();
                p_stuResultArr[i].m_strAnaesthesiaCategoryDosageID = "";// dtbResult.Rows[i]["AANAESTHESIAMODEID"].ToString();
                p_stuResultArr[i].m_strOperationLevel = "";// dtbResult.Rows[i]["OPERATIONLEVEL"].ToString();
                //
			}

			return 1;
		}

		/// <summary>
		/// 获取手术数据，只为手术后病程记录提供共享
		/// </summary>
		/// <param name="p_strInPaitentID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_dtmRecordDate">记录日期，获取次日期之前最近的信息</param>
		/// <param name="p_stuResultArr"></param>
		/// <returns></returns>
		public long m_lngGetLatestOperationInfo(string p_strInPaitentID,string p_strInPatientDate,DateTime p_dtmRecordDate, out stuLatestOperationValue p_stuResult)
		{
			p_stuResult = new stuLatestOperationValue();
			
			DataTable dtbResult;

            clsOperationRecordDoctorShareService m_objServ =
                (clsOperationRecordDoctorShareService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorShareService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetLatestOperationInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID, p_strInPatientDate,p_dtmRecordDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"),out dtbResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes <= 0)
				return lngRes;

			if(dtbResult.Rows.Count == 1)
			{			
				p_stuResult.m_strOperationBeginDate = dtbResult.Rows[0]["OPERATIONBEGINDATE"].ToString();
				p_stuResult.m_strOperationName = dtbResult.Rows[0]["OPERATIONNAME"].ToString();
				p_stuResult.m_strAnaesthesiaCategoryDosage = dtbResult.Rows[0]["ANAESTHESIACATEGORYDOSAGE"].ToString();
				p_stuResult.m_strDiagnoseAfterOperation = dtbResult.Rows[0]["DIAGNOSEAFTEROPERATION"].ToString();
				p_stuResult.m_strOperationProcess = dtbResult.Rows[0]["OPERATIONPROCESS"].ToString();				
			}
			else
			{
				p_stuResult.m_strOperationBeginDate = DateTime.Now.ToString();
				p_stuResult.m_strOperationName = "";
				p_stuResult.m_strAnaesthesiaCategoryDosage = "";
				p_stuResult.m_strDiagnoseAfterOperation = "";
				p_stuResult.m_strOperationProcess = "";				
			}
			
			return 1;
		}

		/// <summary>
		/// 手术后病程记录使用的字段
		/// </summary>
		public struct stuLatestOperationValue
		{
			/// <summary>
			/// 手术开始日期
			/// </summary>
			public string m_strOperationBeginDate;
			/// <summary>
			/// 手术名称
			/// </summary>
			public string m_strOperationName;
			/// <summary>
			/// 麻醉方式
			/// </summary>
			public string m_strAnaesthesiaCategoryDosage;

			/// <summary>
			/// 术后诊断
			/// </summary>
			public string m_strDiagnoseAfterOperation;

			/// <summary>
			/// 手术过程
			/// </summary>
			public string m_strOperationProcess;			
		}

		/// <summary>
		/// 住院病案首页中使用的字段
		/// </summary>
		public struct stuBaseOperationValue
		{
			/// <summary>
			/// 手术开始日期
			/// </summary>
			public string m_strOperationBeginDate;
			/// <summary>
			/// 手术名称
			/// </summary>
			public string m_strOperationName;
			/// <summary>
			/// 麻醉方式
			/// </summary>
			public string m_strAnaesthesiaCategoryDosage;
            /// <summary>
            /// 麻醉方式
            /// </summary>
            public string m_strAnaesthesiaCategoryDosageID;
			/// <summary>
			/// 麻醉医师
			/// </summary>
			public string m_strAnaesther;
			/// <summary>
			/// 术者名称
			/// </summary>
			public string m_strOperationDoctorName;
			/// <summary>
			/// 一助名称
			/// </summary>
			public string m_strFirstAssistantName;
			/// <summary>
			/// 二助名称
			/// </summary>
			public string m_strSecondAssistantName;
			/// <summary>
			/// 术者ID
			/// </summary>
			public string m_strOperationDoctorID;
			/// <summary>
			/// 一助ID
			/// </summary>
			public string m_strFirstAssistantID;
			/// <summary>
			/// 二助ID
			/// </summary>
			public string m_strSecondAssistantID;

            //su.liang
            /// <summary>
            /// 切口愈合等级
            /// </summary>
            public string m_strOperationCutLevel;
            /// <summary>
            /// 择期手术
            /// </summary>
            public string m_strZqOperation;
            /// <summary>
            /// 手术等级
            /// </summary>
            public string m_strOperationLevel;
		}
	}
}
