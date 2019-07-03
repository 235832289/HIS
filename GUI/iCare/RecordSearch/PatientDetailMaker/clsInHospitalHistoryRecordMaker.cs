using System;

namespace iCare.RecordSearch.PatientDetailMaker
{
	/// <summary>
	/// Summary description for clsInHospitalHistoryRecordMaker.
	/// </summary>
	public class clsInHospitalHistoryRecordMaker : clsPatientDetailMakerBase
	{
		public override string m_strMakerPatientDetailDesc(clsPatient p_objPatient,iCare.RecordSearch.clsRecordSearchDomain.clsPatientList p_objPatientList)
		{
			clsInPatientCaseHistoryPrintTool objPrintRec = new  clsInPatientCaseHistoryPrintTool();
			objPrintRec.m_mthSetPrintInfo(p_objPatient,DateTime.Parse(p_objPatientList.m_strInPatientDate),DateTime.Parse(p_objPatientList.m_strOpenDate));
			objPrintRec.m_mthInitPrintContent();
			iCareData.clsPrintInfo_InPatientCaseHistory  objRecordInfo = (iCareData.clsPrintInfo_InPatientCaseHistory)objPrintRec.m_objGetPrintInfo();
			iCareData.clsInPatientCaseHistoryContent objContent = (iCareData.clsInPatientCaseHistoryContent )objRecordInfo.m_objContent;
			
			System.Text.StringBuilder sbdTemp = new System.Text.StringBuilder(1000);			
			sbdTemp.Append(p_objPatient.m_StrName+"  "+p_objPatient.m_StrSex+"  "+p_objPatient.m_ObjPeopleInfo.m_StrAge+"  "+p_objPatient.m_ObjPeopleInfo.m_StrMarried+"\r\n");
			sbdTemp.Append(p_objPatient.m_ObjPeopleInfo.m_StrNationality+"  "+p_objPatient.m_ObjPeopleInfo.m_StrNativePlace+"  "+p_objPatient.m_ObjPeopleInfo.m_StrOccupation+"\r\n");
			sbdTemp.Append("入院日期："+objRecordInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")+"\r\n\r\n");
			sbdTemp.Append("主诉："+objContent.m_strMainDescription+"\r\n\r\n");
			if(objContent.m_strPrimaryDiagnoseAll != null && objContent.m_strPrimaryDiagnoseAll.Trim() != "")
			{
				sbdTemp.Append("入院诊断：\r\n");
//				for(int i=0;i<objContent.m_strPrimaryDiagnoseAll.Length;i++)
//				{
					sbdTemp.Append(com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPrimaryDiagnoseAll,objContent.m_strPrimaryDiagnoseXML) +"\r\n");
//				}
				sbdTemp.Append("\r\n");
			}
			
			sbdTemp.Append("病史记录者："+objContent.m_strCreateName+"\r\n记录日期："+objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory")));            			
			return sbdTemp.ToString();
		}

		public override string m_StrFormName
		{
			get
			{
				return "住院病历";
			}
		}
	}
}
