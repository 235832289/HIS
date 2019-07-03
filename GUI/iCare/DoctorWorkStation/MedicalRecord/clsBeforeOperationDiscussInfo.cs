using System;
using iCareData;
using com.digitalwave.controls;
namespace iCare
{
	/// <summary>
	/// 术前讨论记录信息。
	/// </summary>
	public class clsBeforeOperationDiscussInfo	: clsDiseaseTrackInfo
	{

		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";
			
			clsBeforeOperationDiscussRecordContent objContent=((clsBeforeOperationDiscussRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			strText +="\n地点:"+objContent.m_strAddress;
			strText +="\n参加人员:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvAttend");
			strText +="\n主持人:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvCompere");
			strText +="\n讨论内容:\n"+objContent.m_strDiscussContent;			
			return strText;
		}

		private string m_strGetName(clsEmrSigns_VO[] p_strNameArr,string strLsv)
		{

            //获取签名
            string strSigns = "";
            bool blnFirst = false;
            if (m_objRecordContent.objSignerArr != null)
            {
                for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
                {
                    if (m_objRecordContent.objSignerArr[i].controlName == strLsv)
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
		/// 特殊记录内容格式Xml的获取
		/// </summary>
		public override string m_strGetTrackXml()
		{
			if(m_objRecordContent==null)
				return "";

			clsBeforeOperationDiscussRecordContent objContent=((clsBeforeOperationDiscussRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			string strCreateUserName="";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
			if(objEmployee !=null)
				strCreateUserName= objEmployee.m_StrLastName;
            //须与m_strGetTrackText()项目保持一致，否则会导致修改痕迹移位
            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n地点:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n参加人员:" + m_strGetName(m_objRecordContent.objSignerArr, "lsvAttend"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n主持人:" + m_strGetName(m_objRecordContent.objSignerArr, "lsvCompere"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n讨论内容:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strAddressXML, strXML3, strXML4, strXML5, objContent.m_strDiscussContentXML });
            //string strXML=ctlRichTextBox.s_strCombineXml(new string[]{strXML1,strXML2,objContent.m_strAddressXML,strXML5,objContent.m_strDiscussContentXML});
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

			clsBeforeOperationDiscussRecordContent objContent=((clsBeforeOperationDiscussRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmBeforeOperationDiscuss"))+"   "+"术前讨论记录";
			return strText;
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.BeforeOperationDiscuss;
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

	}// END CLASS DEFINITION clsBeforeOperationDiscussInfo

}
