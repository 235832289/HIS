using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 手术后病程记录信息。
	/// </summary>
	public class clsAfterOperationInfo	: clsDiseaseTrackInfo
	{

		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";
			
			clsAfterOperationRecordContent objContent=((clsAfterOperationRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();			

			strText +="\n　　"+objContent.m_dtmTakeOutStitchesDate.ToString("yyyy年M月d日H时m分")+"在"+objContent.m_strAnaesthesiaMode ;
			strText += "麻醉下，进行" + objContent.m_strOperationName ;
            strText += "。" + "\n术中诊断:\n" + objContent.m_strOperationDiagnose;
			strText +="\n手术中所见(手术简要经过,引流物,手术标本及其处理):\n"+objContent.m_strInOperationSeeing;
			strText +="\n术后处理:\n"+objContent.m_strAfterOperationDeal;
			strText +="\n术后注意:\n"+objContent.m_strAfterOperationNotice;
			strText +="\n伤口愈合情况:\n"+objContent.m_strCutHealUpStatus;
			
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
			
			clsAfterOperationRecordContent objContent=((clsAfterOperationRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();
			string strCreateUserName=m_strGetSignText();

            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n　　" + objContent.m_dtmTakeOutStitchesDate.ToString("yyyy年M月d日H时m分") + "在", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("麻醉下，进行", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("。" + "\n术中诊断:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n手术中所见(手术简要经过,引流物,手术标本及其处理):\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n术后处理:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n术后注意:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML8 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n伤口愈合情况:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[]{strXML1,strXML2,objContent.m_strAnaesthesiaModeXML,strXML3,objContent.m_strOperationNameXML,
																		 strXML4,objContent.m_strOperationDiagnoseXML,strXML5,objContent.m_strInOperationSeeingXML,strXML6,objContent.m_strAfterOperationDealXML,
																		 strXML7,objContent.m_strAfterOperationNoticeXML,strXML8,objContent.m_strCutHealUpStatusXML	});
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

			clsAfterOperationRecordContent objContent=((clsAfterOperationRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmAfterOperation"))+"   "+"手术后病程记录";
						
			return strText;
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.AfterOperation;
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

	}// END CLASS DEFINITION clsAfterOperationInfo

}
