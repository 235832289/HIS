using System;

namespace iCare.RecordSearch.PatientDetailMaker
{
	/// <summary>
	/// Summary description for clsInHospitalMainRecordMaker.
	/// </summary>
	public class clsInHospitalMainRecordMaker : clsPatientDetailMakerBase
	{
		
		public override string m_strMakerPatientDetailDesc(clsPatient p_objPatient,iCare.RecordSearch.clsRecordSearchDomain.clsPatientList p_objPatientList)
		{
			clsInHospitalMainRecordPrintTool objPrintRec = new  clsInHospitalMainRecordPrintTool();
			objPrintRec.m_BlnNeedModifyFlag = false;
			objPrintRec.m_mthSetPrintInfo(p_objPatient,DateTime.Parse(p_objPatientList.m_strInPatientDate),DateTime.Parse(p_objPatientList.m_strOpenDate));
			objPrintRec.m_mthInitPrintContent();
			iCareData.clsPrintInfo_InHospitalMainRecord  objRecordInfo = (iCareData.clsPrintInfo_InHospitalMainRecord)objPrintRec.m_objGetPrintInfo();
			objPrintRec.m_BlnNeedModifyFlag = true;

			System.Text.StringBuilder sbdTemp = new System.Text.StringBuilder(1000);			
			sbdTemp.Append(p_objPatient.m_StrName+"  "+p_objPatient.m_StrSex+"  "+p_objPatient.m_ObjPeopleInfo.m_StrAge+"\r\n");
			sbdTemp.Append(p_objPatient.m_ObjPeopleInfo.m_StrNationality+"  "+p_objPatient.m_ObjPeopleInfo.m_StrNativePlace+"  "+p_objPatient.m_ObjPeopleInfo.m_StrOccupation+"\r\n");
			sbdTemp.Append(p_objPatient.m_ObjPeopleInfo.m_StrMarried+"  "+p_objPatient.m_ObjPeopleInfo.m_StrHomeAddress+"\r\n");
			sbdTemp.Append("家庭电话："+p_objPatient.m_ObjPeopleInfo.m_StrHomePhone+"\r\n移动电话："+p_objPatient.m_ObjPeopleInfo.m_StrMobile+"\r\n办公电话："+p_objPatient.m_ObjPeopleInfo.m_StrOfficePhone+"\r\n\r\n");
			sbdTemp.Append("入院日期："+objRecordInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")+"\r\n");
			sbdTemp.Append("入院诊断：\r\n"+objRecordInfo.m_objCollection.m_objContent.m_strInHospitalDiagnosis+"\r\n\r\n");
			if(objRecordInfo.m_dtmOutHospitalDate != DateTime.Parse("1900-1-1"))
			{
				sbdTemp.Append("出院日期："+objRecordInfo.m_dtmOutHospitalDate.ToString("yyyy年MM月dd日")+"\r\n");
				sbdTemp.Append("出院诊断：\r\n"+objRecordInfo.m_objCollection.m_objContent.m_strMainDiagnosis+"\r\n\r\n");
			}
			if(objRecordInfo.m_objCollection.m_objOperationArr != null)
			{
				sbdTemp.Append("手术信息："+"\r\n");
				for(int i1=0;i1<objRecordInfo.m_objCollection.m_objOperationArr.Length;i1++)
				{
					sbdTemp.Append(DateTime.Parse(objRecordInfo.m_objCollection.m_objOperationArr[i1].m_strOperationDate).ToString("yyyy年MM月dd日 HH:mm")+"\r\n    "+objRecordInfo.m_objCollection.m_objOperationArr[i1].m_strOperationName+"\r\n    术者："+objRecordInfo.m_objCollection.m_objOperationArr[i1].m_strOperatorName+"\r\n");				
				}
				sbdTemp.Append("\r\n");
			}
			sbdTemp.Append("记录者："+p_objPatientList.m_strCreateUserName+"\r\n记录日期："+DateTime.Parse(p_objPatientList.m_strCreateDate).ToString("yyyy年MM月dd日 HH:mm"));            			
			return sbdTemp.ToString();
		}

		public override string m_StrFormName
		{
			get
			{
				return "住院病案首页";
			}
		}
	}
}
