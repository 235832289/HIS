using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 阶段小结。
	/// </summary>
	public class clsDiseaseSummaryInfo	: clsDiseaseTrackInfo
	{
		
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";

			clsDiseaseSummaryRecordContent objContent=((clsDiseaseSummaryRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmDiseaseSummary"))+"   "+"阶段小结";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
			
			strText +="\n入院情况:\n"+objContent.m_strInHospitalCase;
			strText +="\n入院诊断:\n"+objContent.m_strInHospitalDiagnose;
			strText +="\n诊疗经过:\n"+objContent.m_strDiagnoseBy;
			strText +="\n目前情况:\n"+objContent.m_strCurrentCase;
			strText +="\n目前诊断:\n"+objContent.m_strCurrentDiagnose;
			strText +="\n诊疗计划:\n"+objContent.m_strReferral;
			
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

			clsDiseaseSummaryRecordContent objContent=((clsDiseaseSummaryRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmDiseaseSummary"))+"   "+"阶段小结";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);

			string strCreateUserName=m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n入院情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n入院诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊疗经过:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n目前情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n目前诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strInHospitalCaseXML, strXML3, objContent.m_strInHospitalDiagnoseXML, strXML4, objContent.m_strDiagnoseByXML, strXML5, objContent.m_strCurrentCaseXML, strXML6, objContent.m_strCurrentDiagnoseXML, strXML7, objContent.m_strReferralXML });
			return strXML;			
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.DiseaseSummary;
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
		/// 特殊记录内容签名XML的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetSignXml()
		{
			if(m_objRecordContent==null)
				return "";
			
			return "<Root />";
		}	

	}

}
