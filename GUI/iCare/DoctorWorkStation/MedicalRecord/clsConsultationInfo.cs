using System;
using iCareData;
using System.Text;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 会诊记录信息。
	/// </summary>
	public class clsConsultationInfo	: clsDiseaseTrackInfo
	{		
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";

			clsConsultationRecordContent objContent=((clsConsultationRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmConsultation"))+"   "+"会诊记录\n";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
			if(objPatient !=null && objPatient.m_ObjPeopleInfo !=null)
				strText +="　　"+objPatient.m_ObjPeopleInfo.m_StrFirstName+"，"+objPatient.m_ObjPeopleInfo.m_StrSex+"，"+objPatient.m_ObjPeopleInfo.m_IntAge.ToString()+"岁，";
			else strText +="　　病人信息不详，";					
						
			strText+=objContent.m_strApplyConsultationDeptName;

			StringBuilder m_sbdTemp1 = new StringBuilder();
			
			m_sbdTemp1.Length = 0;

			if(objContent.m_strRequestDoctorNameArr != null)
			{
				for(int i=0;i<objContent.m_strRequestDoctorNameArr.Length;i++)
				{
					m_sbdTemp1.Append(objContent.m_strRequestDoctorNameArr[i]+"　");//注意：此处填充的空格是全角占一个汉字的空格
				}
			}
			string strRequestDoctor =  m_sbdTemp1.ToString();

			StringBuilder m_sbdTemp2 = new StringBuilder();

			m_sbdTemp2.Length = 0;

			if(objContent.m_strConsultationDoctorNameArr != null)
			{
				for(int i=0;i<objContent.m_strConsultationDoctorNameArr.Length;i++)
				{
					m_sbdTemp2.Append(objContent.m_strConsultationDoctorNameArr[i]+"　");//注意：此处填充的空格是全角占一个汉字的空格
				}
			}
			string strConsultationDoctor =  m_sbdTemp2.ToString();
			
			string strConsultationTime;
			if (objContent.m_intConsultationTime==1)
				strConsultationTime="请即时会诊";
			else if(objContent.m_intConsultationTime==2)
				strConsultationTime="请在24小时内会诊";
			else 
				strConsultationTime="一般会诊";
			
			clsEmployee objEmployee = new clsEmployee(objContent.m_strMainDoctorID);

			strText +="\n　　简要病历及会诊目的:"+objContent.m_strCaseHistory;
			strText +="\n　　目前诊断:"+objContent.m_strConsultationOrder;
			strText +="\n　　主治医师:"+objEmployee.m_StrLastName+"住院医师："+strRequestDoctor;
			strText +="\n　　会诊时间:"+strConsultationTime;
			strText +="\n　　会诊答复:"+objContent.m_strConsultationIdea;
			strText +="\n　　会诊医师: "+ strConsultationDoctor;
			
			return strText;
		}

		/// <summary>
		/// 特殊记录内容格式Xml的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackXml()
		{
			if(m_objRecordContent==null)
				return "";

			clsConsultationRecordContent objContent=((clsConsultationRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmConsultation"))+"   "+"会诊记录\n";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
			if(objPatient !=null && objPatient.m_ObjPeopleInfo !=null)
				strText +="　　"+objPatient.m_ObjPeopleInfo.m_StrFirstName+"，"+objPatient.m_ObjPeopleInfo.m_StrSex+"，"+objPatient.m_ObjPeopleInfo.m_IntAge.ToString()+"岁，";
			else strText +="　　病人信息不详，";					
						
			strText+=objContent.m_strApplyConsultationDeptName;
		
			StringBuilder m_sbdTemp1 = new StringBuilder();
			
			m_sbdTemp1.Length = 0;

			if(objContent.m_strRequestDoctorNameArr != null)
			{
				for(int i=0;i<objContent.m_strRequestDoctorNameArr.Length;i++)
				{
					m_sbdTemp1.Append(objContent.m_strRequestDoctorNameArr[i]+"　");//注意：此处填充的空格是全角占一个汉字的空格
				}
			}
			string strRequestDoctor =  m_sbdTemp1.ToString();

			StringBuilder m_sbdTemp2 = new StringBuilder();

			m_sbdTemp2.Length = 0;

			if(objContent.m_strConsultationDoctorNameArr != null)
			{
				for(int i=0;i<objContent.m_strConsultationDoctorNameArr.Length;i++)
				{
					m_sbdTemp2.Append(objContent.m_strConsultationDoctorNameArr[i]+"　");//注意：此处填充的空格是全角占一个汉字的空格
				}
			}
			string strConsultationDoctor =  m_sbdTemp2.ToString();

			string strCreateUserName = m_strGetSignText();

			string strConsultationTime;
			if (objContent.m_intConsultationTime==1)
				strConsultationTime="请即时会诊";
			else if(objContent.m_intConsultationTime==2)
				strConsultationTime="请在24小时内会诊";
			else 
				strConsultationTime="一般会诊";

			clsEmployee objEmployee = new clsEmployee(objContent.m_strMainDoctorID);
			
			/*ctlRichTextBox.s_strMakeTextXml把相应的文本变成Xml格式，
			 * ctlRichTextBox.s_strCombineXml把各段连接起来，相当于加号*/
            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　简要病历及会诊目的:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　目前诊断:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　主治医师:" + objEmployee.m_StrLastName + "住院医师：" + strRequestDoctor, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　会诊答复:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　会诊时间:" + strConsultationTime, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　会诊医师:" + strConsultationDoctor, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strCaseHistoryXml, strXML3, objContent.m_strConsultationOrderXml, strXML4, strXML5, strXML6, objContent.m_strConsultationIdeaXml, strXML7 });
			return strXML;
			

		}

		/// <summary>
		/// 特殊记录内容申请会诊医生签名的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetSignText()
		{
			if(m_objRecordContent==null)
				return "";		
			
						clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
						if(objEmployee !=null)
							return objEmployee.m_StrLastName;
						else return "";	
			
		}		

		/// <summary>
		/// 特殊记录内容签名的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetSignXml()
		{
			if(m_objRecordContent==null)
				return "";
			
			return "<Root />";
		}				
		
		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.Consultation;
		}

	}// END CLASS DEFINITION clsGeneralDiseaseInfo
}
