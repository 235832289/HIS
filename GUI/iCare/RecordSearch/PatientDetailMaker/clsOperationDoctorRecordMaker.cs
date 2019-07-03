using System;

namespace iCare.RecordSearch.PatientDetailMaker
{
	/// <summary>
	/// Summary description for clsOperationDoctorRecordMaker.
	/// </summary>
	public class clsOperationDoctorRecordMaker : clsPatientDetailMakerBase
	{
		
		public override string m_strMakerPatientDetailDesc(clsPatient p_objPatient,iCare.RecordSearch.clsRecordSearchDomain.clsPatientList p_objPatientList)
		{
			clsOperationRecordDoctorPrintTool objPrintRec = new  clsOperationRecordDoctorPrintTool();
			objPrintRec.m_mthSetPrintInfo(p_objPatient,DateTime.Parse(p_objPatientList.m_strInPatientDate),DateTime.Parse(p_objPatientList.m_strOpenDate));
			objPrintRec.m_mthInitPrintContent();
			iCareData.clsPrintInfo_OperationRecordDoctor  objRecordInfo = (iCareData.clsPrintInfo_OperationRecordDoctor)objPrintRec.m_objGetPrintInfo();
						
			System.Text.StringBuilder sbdTemp = new System.Text.StringBuilder(1000);			
			sbdTemp.Append(p_objPatient.m_StrName+"  "+p_objPatient.m_StrSex+"  "+p_objPatient.m_ObjPeopleInfo.m_StrAge+"\r\n");
			sbdTemp.Append(p_objPatient.m_ObjPeopleInfo.m_StrNationality+"  "+p_objPatient.m_ObjPeopleInfo.m_StrNativePlace+"  "+p_objPatient.m_ObjPeopleInfo.m_StrOccupation+"\r\n");
			sbdTemp.Append("入院日期："+objRecordInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")+"\r\n\r\n");
			
			sbdTemp.Append("手术开始时间："+DateTime.Parse(objRecordInfo.m_objSelectOperationRecordContent.m_strOperationBeginDate).ToString("yyyy年MM月dd日 HH:mm")+"\r\n");
			sbdTemp.Append("手术名称："+objRecordInfo.m_objSelectOperationRecordContent.m_strOperationName+"\r\n\r\n");
			//数据库没有赋值
			string strTemp="";
			if(objRecordInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr!=null)
				for(int i=0;i<objRecordInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr.Length;i++)
				{						
					strTemp=strTemp +objRecordInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr[i];
					if(i < objRecordInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr.Length-1)
					{
						strTemp += ",";
					}
				}
			sbdTemp.Append("手术医师："+strTemp+"\r\n");

			strTemp="";
			if(objRecordInfo.m_objSelectDoctorSign.m_strAssistantNameArr!=null)
				for(int i=0;i<objRecordInfo.m_objSelectDoctorSign.m_strAssistantNameArr.Length;i++)
				{
					strTemp=strTemp +objRecordInfo.m_objSelectDoctorSign.m_strAssistantNameArr[i];
					if(i < objRecordInfo.m_objSelectDoctorSign.m_strAssistantNameArr.Length-1)
					{
						strTemp += ",";
					}
				}
			sbdTemp.Append("助手："+strTemp+"\r\n\r\n");
			
			sbdTemp.Append("记录者："+p_objPatientList.m_strCreateUserName+"\r\n记录日期："+DateTime.Parse(objRecordInfo.m_objSelectOperationRecord.m_strCreateDate).ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmOperationRecordDoctor")));            			
			return sbdTemp.ToString();
		}

		public override string m_StrFormName
		{
			get
			{
				return "手术记录单";
			}
		}
	}
}
