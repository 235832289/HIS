using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
	#region 首次病程记录信息
	/// <summary>
	/// 首次病程记录信息。
	/// </summary>
	public class clsFirstIllnessNoteInfo  : clsDiseaseTrackInfo
	{
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";

			clsFirstIllnessNoteRecordContent objContent=((clsFirstIllnessNoteRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote"))+"   "+"首次病程记录";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
			
			strText +="\n主要内容:\n"+objContent.m_strMostlyContent;
			strText +="\n初步诊断:\n"+objContent.m_strOriginalDiagnose;
			strText +="\n诊断依据:\n"+objContent.m_strThereunderDiagnose;
			strText +="\n鉴别诊断:\n"+objContent.m_strDiagnoseDiffe;
			strText +="\n治疗计划:\n"+objContent.m_strCurePlan;
			
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

			clsFirstIllnessNoteRecordContent objContent=((clsFirstIllnessNoteRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote"))+"   "+"首次病程记录";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);

			string strCreateUserName=m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n主要内容:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n初步诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊断依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White, System.Drawing.FontStyle.Bold.ToString());
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n治疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strMostlyContentXML, strXML3, objContent.m_strOriginalDiagnoseXML, strXML4, objContent.m_strThereunderDiagnoseXML, strXML5, objContent.m_strDiagnoseDiffeXML, strXML6, objContent.m_strCurePlanXML });
			return strXML;			
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.FirstIllnessNote;
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
	}// END CLASS DEFINITION clsFirstIllnessNoteInfo
	#endregion

	#region 首次病程记录信息(市一中医科)
	/// <summary>
	/// 首次病程记录信息(市一中医科)。
	/// </summary>
	public class clsFirstIllnessNote_ZYInfo  : clsDiseaseTrackInfo
	{
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";

			clsFirstIllnessNote_ZYRecordContent objContent=((clsFirstIllnessNote_ZYRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote_ZY"))+"   "+"首次病程记录";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);
			
			strText +="\n主要内容:\n"+objContent.m_strMostlyContent;
			strText +="\n初步诊断:\n"+objContent.m_strOriginalDiagnose;
			strText +="\n中医辨病辩证依据:\n"+objContent.m_strIdentifyReston;
			strText +="\n西医诊断依据:\n"+objContent.m_strThereunderDiagnose;
			strText +="\n中医鉴别诊断:\n"+objContent.m_strIdentifyDiagnos;
			strText +="\n西医鉴别诊断:\n"+objContent.m_strDiagnoseDiffe;
			strText +="\n诊疗计划:\n"+objContent.m_strCurePlan;
			
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

			clsFirstIllnessNote_ZYRecordContent objContent=((clsFirstIllnessNote_ZYRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote_ZY"))+"   "+"首次病程记录";
			clsPatient objPatient=new clsPatient(objContent.m_strInPatientID);

			string strCreateUserName=m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n主要内容:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n初步诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n中医辨病辩证依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n西医诊断依据:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n中医鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n西医鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n诊疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
			
			string strXML=ctlRichTextBox.s_strCombineXml(new string[]{strXML1,strXML2,objContent.m_strMostlyContentXML,strXML3,objContent.m_strOriginalDiagnoseXML,strXML4,objContent.m_strIdentifyRestonXML, 
																		 strXML5,objContent.m_strThereunderDiagnoseXML,strXML6,objContent.m_strIdentifyDiagnoseXML, strXML7,objContent.m_strDiagnoseDiffeXML,strXML8,objContent.m_strCurePlanXML});
			return strXML;			
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.FirstIllnessNote_ZY;
		}

		/// <summary>
		/// 特殊记录内容签名的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetSignText()
		{
			if(m_objRecordContent==null)
				return "";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strModifyUserID);
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
	}
	#endregion

    #region 首次病程记录信息(佛二)
    /// <summary>
    /// 首次病程记录信息。
    /// </summary>
    public class clsFirstIllnessNoteInfo_F2 : clsDiseaseTrackInfo
    {
        /// <summary>
        /// 特殊记录内容文本的获取。
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackText()
        {
            if (m_objRecordContent == null)
                return "";

            clsFirstIllnessNoteRecordContent objContent = ((clsFirstIllnessNoteRecordContent)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote")) + "   " + "首次病程记录";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);

            strText += "\n" + objContent.m_strMostlyContent;
            strText += "\n(一)病例特点:\n" + objContent.m_strOriginalDiagnose;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
                strText += "\n(二)诊断依据与鉴别诊断:\n" + objContent.m_strDiagnoseDiffe;
            else
                strText += "\n(二)诊断与鉴别诊断:\n" + objContent.m_strDiagnoseDiffe;
            strText += "\n(三)诊疗计划:\n" + objContent.m_strCurePlan;

            return strText;
        }

        /// <summary>
        /// 特殊记录内容格式Xml的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetTrackXml()
        {
            if (m_objRecordContent == null)
                return "";

            clsFirstIllnessNoteRecordContent objContent = ((clsFirstIllnessNoteRecordContent)m_objRecordContent);
            string strText;
            strText = objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmFirstIllnessNote")) + "   " + "首次病程记录";
            clsPatient objPatient = new clsPatient(objContent.m_strInPatientID);

            string strCreateUserName = m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(一)病例特点:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            //string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(二)诊断与鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5="";
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
                strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(二)诊断依据与鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            else strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(二)诊断与鉴别诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n(三)诊疗计划:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strMostlyContentXML, strXML3, objContent.m_strOriginalDiagnoseXML, strXML5, objContent.m_strDiagnoseDiffeXML, strXML6, objContent.m_strCurePlanXML });
            return strXML;
        }

        /// <summary>
        /// 特殊记录类型的获取
        /// </summary>
        /// <returns></returns>
        public override enmDiseaseTrackType m_enmGetTrackType()
        {
            return enmDiseaseTrackType.FirstIllnessNote;
        }

        /// <summary>
        /// 特殊记录内容签名的获取
        /// </summary>
        /// <returns></returns>
        public override string m_strGetSignText()
        {
            if (m_objRecordContent == null)
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
            if (m_objRecordContent == null)
                return "";

            return "<Root />";
        }
    }// END CLASS DEFINITION clsFirstIllnessNoteInfo
    #endregion

}
