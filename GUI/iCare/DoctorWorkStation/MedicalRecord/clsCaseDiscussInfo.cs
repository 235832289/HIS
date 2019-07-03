using System;
using iCareData;
using System.Collections;
using System.Text;
using com.digitalwave.controls;
namespace iCare
{
	/// <summary>
	/// 病例讨论记录信息。
	/// </summary>
	public class clsCaseDiscussInfo	: clsDiseaseTrackInfo
	{
		private const string c_strSplitText = "医生：";

		private const int c_intWhiteSpaceCount = 14;
		
		private const string c_strInsertTextWithEnter = "\n　　　              ";
		private const string c_strInsertText = "　　　              ";

		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";
			
			clsCaseDiscussRecordContent objContent=((clsCaseDiscussRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			strText +="\n地点:"+objContent.m_strAddress;
			strText +="\n参加人员:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvAttend");
			strText +="\n主持人:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvCompere");
			strText +="\n讨论内容:"+objContent.m_strDiscussContent;			
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

			clsCaseDiscussRecordContent objContent=((clsCaseDiscussRecordContent)m_objRecordContent);
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
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n讨论内容:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.s_strCombineXml(new string[] { strXML1, strXML2, objContent.m_strAddressXML, strXML3, strXML4, strXML5, objContent.m_strDiscussContentXML });
            //string strXML=ctlRichTextBox.s_strCombineXml(new string[]{strXML5,objContent.m_strDiscussContentXML});
			return strXML;	
		}

		public void m_mthGetFormatTrackInfo(int p_intCharPerLine,out string p_strText,out string p_strXml)
		{
			m_mthGetFormatTrackInfo(p_intCharPerLine,false,DateTime.Now,out p_strText,out p_strXml);
		}

		public void m_mthGetFormatTrackInfo(int p_intCharPerLine,bool p_blnIsPrintCall,DateTime p_dtmSeperateTime,out string p_strText,out string p_strXml)
		{
			p_strText = "";
			p_strXml = "";

			if(m_objRecordContent==null)
				return ;

			string strHeaderText = m_strGetHeaderText();
			
			clsCaseDiscussRecordContent objContent=((clsCaseDiscussRecordContent)m_objRecordContent);
			p_strText=strHeaderText;

			p_strText +="\n地点:"+objContent.m_strAddress;
			p_strText +="\n参加人员:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvAttend");
			p_strText +="\n主持人:"+m_strGetName(m_objRecordContent.objSignerArr,"lsvCompere");
			p_strText +="\n讨论内容:\n";				
			
			string strCreateUserName="";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
			if(objEmployee !=null)
				strCreateUserName= objEmployee.m_StrLastName;
            //须与以上项目保持一致，否则会导致修改痕迹移位
            string strXML1 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strHeaderText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n地点:", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n参加人员:" + m_strGetName(m_objRecordContent.objSignerArr, "lsvAttend"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n主持人:" + m_strGetName(m_objRecordContent.objSignerArr, "lsvCompere"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n讨论内容:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

			ArrayList arlXml = new ArrayList();
            arlXml.AddRange(new string[] { strXML1, strXML2, objContent.m_strAddressXML, strXML3, strXML4, strXML5 });
            //arlXml.AddRange(new string[]{strXML1,strXML2,objContent.m_strAddressXML,strXML5});
            //if(!p_blnIsPrintCall)
            //{
                //p_strText += m_strFormatText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML,p_intCharPerLine-1,arlXml);
                p_strText += objContent.m_strDiscussContent;
                arlXml.Add(objContent.m_strDiscussContentXML);
            //}
            //else
            //{
            //    //string strTempXml;
            //    //string strText = ctlRichTextBox.s_strGetRightText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML,p_dtmSeperateTime,out strTempXml);
            //    //p_strText += m_strFormatText(strText,strTempXml,p_intCharPerLine-1,arlXml);
            //    p_strText += ctlRichTextBox.s_strGetRightText(objContent.m_strDiscussContent, objContent.m_strDiscussContentXML);
            //    arlXml.Add("<r><D /><S /></r>");
            //}
			
			p_strXml=ctlRichTextBox.s_strCombineXml((string[])arlXml.ToArray(typeof(string)));
			
		}

		/// <summary>
		/// 提取表头基本信息
		/// </summary>
		/// <returns></returns>
		private string m_strGetHeaderText()
		{
			if(m_objRecordContent==null)
				return "";

			clsCaseDiscussRecordContent objContent=((clsCaseDiscussRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmCaseDiscuss"))+"   "+"疑难病例讨论记录";
			return strText;
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.CaseDiscuss;
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

		private string m_strFormatText(string p_strText,string p_strOldXml,int p_intCharPerLine,ArrayList p_arlXml)
		{
			string strTemp = p_strText.Replace("医生:","医生：");

			int intStarIndex = 0;	
			
			int intPreDocIndex = strTemp.IndexOf(c_strSplitText,intStarIndex);

			if(intPreDocIndex < 0)
			{
				p_arlXml.Add(p_strOldXml);
				return p_strText;
			}

			int intPreRetIndex = strTemp.LastIndexOf('\n',intPreDocIndex);
	
			intStarIndex = intPreDocIndex+3;
			
			ArrayList arlInsertIndex = new ArrayList();

			while(true)
			{
				int intDocIndex = strTemp.IndexOf(c_strSplitText,intStarIndex);
								
				if(intDocIndex >= 0)
				{
					int intRetIndex = strTemp.LastIndexOf('\n',intDocIndex);

					if(intRetIndex == -1)
						intRetIndex = 0;

					m_mthGetFormat(arlInsertIndex,p_strText,c_intWhiteSpaceCount,p_intCharPerLine,intStarIndex,intPreDocIndex,intPreRetIndex,intRetIndex);

					intPreDocIndex = intDocIndex;
					intPreRetIndex = intRetIndex;

					intStarIndex = intPreDocIndex+3;
				}		
				else
				{
					m_mthGetFormat(arlInsertIndex,p_strText,c_intWhiteSpaceCount,p_intCharPerLine,intStarIndex,intPreDocIndex,intPreRetIndex,-1);

					break;
				}
			}

			return m_strFormat(arlInsertIndex,p_strText,p_strOldXml,c_intWhiteSpaceCount,p_arlXml);			
		}

		private void m_mthGetFormat(ArrayList p_arlFormatInfo,string p_strText,int p_intWhiteSpaceCount,int p_intCharPerLine,int p_intStartIndex,int p_intPreDocIndex,int p_intPreRetIndex,int p_intRetIndex)
		{
			int intDocDescLength = p_intPreDocIndex+3-(p_intPreRetIndex+1);
			int intTempWhiteSpace = p_intWhiteSpaceCount;

			for(int i=0;i<intDocDescLength;i++)
			{
				if((int)p_strText[i+p_intPreRetIndex+1] < 255)
					intTempWhiteSpace--;
				else
					intTempWhiteSpace -= 2;
			}

			p_arlFormatInfo.Add(p_intPreRetIndex+1+20000000+intTempWhiteSpace*10000);

			int intTextLength = 0;
			if(p_intRetIndex >= 0)
			{
				intTextLength = p_intRetIndex-p_intStartIndex+1;
			}
			else
			{
				intTextLength = p_strText.Length - p_intStartIndex;
			}

			int intCountTemp = 0;

			for(int i=0;i<intTextLength;i++)
			{
				if(p_strText[i+p_intStartIndex] != '\n')
				{
					intCountTemp++;

					if(intCountTemp == p_intCharPerLine)
					{
						p_arlFormatInfo.Add(p_intStartIndex+i+1);
						intCountTemp = 0;
					}
				}
				else if(i != intTextLength-1)
				{
					p_arlFormatInfo.Add(p_intStartIndex+i+1+10000);
					intCountTemp = 0;
				}
			}
		}

		private string m_strFormat(ArrayList p_arlFormatInfo,string p_strText,string p_strOldXml,int p_intWhiteSpaceCount,ArrayList p_arlXml)
		{
			clsCaseDiscussRecordContent objContent=((clsCaseDiscussRecordContent)m_objRecordContent);
			string strCreateUserName="";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
			if(objEmployee !=null)
				strCreateUserName= objEmployee.m_StrLastName;

            string strInsertTextWithEnterXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(c_strInsertTextWithEnter, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strInsertTextXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(c_strInsertText, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

			ctlRichTextBox.clsUserXMLInfo objUserXmlInfo = ctlRichTextBox.s_objGetUserXMLInfo(p_strOldXml);

			StringBuilder sbValue = new StringBuilder();
			int intPreIndex = 0;
			
			for(int i=0;i<p_arlFormatInfo.Count;i++)
			{
				int intIndex = (int)p_arlFormatInfo[i];

				if(intIndex < 10000)
				{
					sbValue.Append(p_strText.Substring(intPreIndex,intIndex-intPreIndex));
					sbValue.Append(c_strInsertTextWithEnter);

					p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo,intPreIndex,intIndex-1));
					p_arlXml.Add(strInsertTextWithEnterXml);

					intPreIndex = intIndex;
				}
				else if(intIndex < 20000000)
				{
					intIndex %= 10000;
					
					sbValue.Append(p_strText.Substring(intPreIndex,intIndex-intPreIndex));
					sbValue.Append(c_strInsertText);

					p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo,intPreIndex,intIndex-1));
					p_arlXml.Add(strInsertTextXml);

					intPreIndex = intIndex;
				}
				else
				{
					intIndex %= 20000000;
					int intWhiteCount = intIndex/10000;
					intIndex %= 10000;

					string strWhiteSpace = "　　　";
					for(int j2=0;j2<intWhiteCount;j2++)
					{
						strWhiteSpace += " ";
					}
                    string strWhiteSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strWhiteSpace, objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

					if(intIndex > 0)
					{
						sbValue.Append(p_strText.Substring(intPreIndex,intIndex-intPreIndex));
						sbValue.Append(strWhiteSpace);

						p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo,intPreIndex,intIndex-1));
						p_arlXml.Add(strWhiteSpaceXml);							
						
						intPreIndex = intIndex;
					}
					else if(intIndex == 0)
					{
						sbValue.Append(strWhiteSpace);
						p_arlXml.Add(strWhiteSpaceXml);
						
					}
				}
			}

			sbValue.Append(p_strText.Substring(intPreIndex));

			p_arlXml.Add(ctlRichTextBox.s_strGetSubXml(objUserXmlInfo,intPreIndex,p_strText.Length-1));
			
			return sbValue.ToString();
		}

	}// END CLASS DEFINITION clsCaseDiscussInfo

}
