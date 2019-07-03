using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 查房记录信息。
	/// </summary>
	public class clsCheckRoomInfo	: clsDiseaseTrackInfo
	{

		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";
			
			clsCheckRoomRecordContent objContent=((clsCheckRoomRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			strText +="\n患者病情:\n"+objContent.m_strPatientState;
			strText +="\n诊断:\n"+objContent.m_strDiagnose;
			strText +="\n鉴别诊断:\n"+objContent.m_strDifferentiateDiagnose;


            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001")
            {
                strText += "\n当前治疗:\n" + objContent.m_strCurrentCure;
                strText += "\n下一步治疗:\n" + objContent.m_strNextCure;
            }
            else
            {
                strText += "\n治疗:\n" + objContent.m_strCurrentCure;
                if (!string.IsNullOrEmpty(objContent.m_strNextCure))
                {
                    strText += "\n" + objContent.m_strNextCure;
                }
            }
			
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

			clsCheckRoomRecordContent objContent=((clsCheckRoomRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			string strCreateUserName="";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
			if(objEmployee !=null)
				strCreateUserName= objEmployee.m_StrLastName;

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n患者病情:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML5;
            string strXML6 = string.Empty;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            {
                strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n治疗:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
                if (!string.IsNullOrEmpty(objContent.m_strNextCure))
                {
                    strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
                }
            }
            else
            {
                strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n当前治疗:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
                strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n下一步治疗:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            }
            
            string strXML;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            {
                if (!string.IsNullOrEmpty(objContent.m_strNextCure))
                {
                    strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strPatientStateXML, strXML3, objContent.m_strDiagnoseXML, strXML4, objContent.m_strDifferentiateDiagnoseXML, strXML5, objContent.m_strCurrentCureXML, strXML6, objContent.m_strNextCureXML });
                }
                else
                {
                    strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strPatientStateXML, strXML3, objContent.m_strDiagnoseXML, strXML4, objContent.m_strDifferentiateDiagnoseXML, strXML5, objContent.m_strCurrentCureXML });
                }                
            }
            else
            {
                strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strPatientStateXML, strXML3, objContent.m_strDiagnoseXML, strXML4, objContent.m_strDifferentiateDiagnoseXML, strXML5, objContent.m_strCurrentCureXML, strXML6, objContent.m_strNextCureXML });
            }
			return strXML;	
		}

		/// <summary>
		/// 提取表头基本信息
		/// </summary>
		/// <returns></returns>
		private string m_strGetHeaderText()
		{
			if(m_objRecordContent==null)
				return "";

			clsCheckRoomRecordContent objContent=((clsCheckRoomRecordContent)m_objRecordContent);
			string strText;
			 
            //显示查房医师
            string strSigns = "";
            bool blnFirst = false;
            if (m_objRecordContent.objSignerArr != null)
            {
                for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
                {
                    if (m_objRecordContent.objSignerArr[i].controlName == "lsvCheckRoomSign")
                    {
                        //名称
                        if (!blnFirst)
                        {
                            strSigns = m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                            blnFirst = true;
                        }
                        else
                            strSigns = strSigns + "、" + m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                    }
                }
            }
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmCheckRoom"))+"   "+strSigns+"查房记录";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
//			if(objPatient !=null && objPatient.m_ObjPeopleInfo !=null)
//				strText +="　　"+objPatient.m_ObjPeopleInfo.m_StrFirstName+"，"+objPatient.m_ObjPeopleInfo.m_StrSex+"，"+objPatient.m_ObjPeopleInfo.m_IntAge.ToString()+"岁，";
//			else strText +="　　病人信息不详，";				
			
			return strText;
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.CheckRoom;
		}

		/// <summary>
		/// 特殊记录内容签名的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetSignText()
		{
			if(m_objRecordContent==null)
				return "";
            //获取签名
            string strSigns = "";
            bool blnFirst = false;
            if (m_objRecordContent.objSignerArr != null)
            {
                for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
                {
                    if (m_objRecordContent.objSignerArr[i].controlName == "lsvSign")
                    {
                        //名称
                        if (!blnFirst)
                        {
                            strSigns = m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                            blnFirst = true;
                        }
                        else
                            strSigns = strSigns + "、" + m_objRecordContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName;
                    }
                }
            }

			return strSigns;
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

	}// END CLASS DEFINITION clsCheckRoomInfo

}
