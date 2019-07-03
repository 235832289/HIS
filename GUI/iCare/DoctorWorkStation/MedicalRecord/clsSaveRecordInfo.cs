using System;
using iCareData;
using com.digitalwave.controls;
namespace iCare
{
	/// <summary>
	/// 死亡病例讨论记录信息。
	/// </summary>
	public class clsSaveRecordInfo	: clsDiseaseTrackInfo
	{

		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";
			
			clsSaveRecordContent objContent=((clsSaveRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			strText +="\n    抢救时间:"+objContent.m_dtmSaveTime.ToString("yyyy年MM月dd日HH时mm分");				
			strText +="\n危重病情名称:\n"+objContent.m_strDiseaseName;	
			strText +="\n病情变化情况及抢救措施:\n"+objContent.m_strDiseaseChangeCase;	
			strText +="\n抢救结果:\n"+objContent.m_strSaveResult;
			strText +="\n在场家属:\n"+objContent.m_strSaveDeal;	
			strText +="\n参加人员:\n"+m_strGetName(m_objRecordContent.objSignerArr,"lsvAttendPeople");

			return strText;
		}

		private string m_strGetName(clsEmrSigns_VO[] p_strNameArr,string strLsv)
		{
			string strSigns="";
			bool blnFirst=false;
			//显示签名者
			if (m_objRecordContent.objSignerArr!=null)
			{
				for (int i = 0; i < m_objRecordContent.objSignerArr.Length; i++)
				{
					if (m_objRecordContent.objSignerArr[i].controlName==strLsv)
					{
						//名称
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

			clsSaveRecordContent objContent=((clsSaveRecordContent)m_objRecordContent);
			string strText=m_strGetHeaderText();

			string strCreateUserName="";
			clsEmployee objEmployee=new clsEmployee(m_objRecordContent.m_strCreateUserID);
			if(objEmployee !=null)
				strCreateUserName= objEmployee.m_StrLastName;
            //须与m_strGetTrackText()项目保持一致，否则会导致修改痕迹移位
			string strXML1=ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strText,objContent.m_strCreateUserID,strCreateUserName,System.Drawing.Color.White);
            string strXML2 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n    抢救时间:" + objContent.m_dtmSaveTime.ToString("yyyy年MM月dd日HH时mm分"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML3 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n危重病情名称:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML4 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n病情变化情况及抢救措施:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML5 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n抢救结果:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML6 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n在场家属:\n", objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);
            string strXML7 = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("\n参加人员:\n" + m_strGetName(m_objRecordContent.objSignerArr, "lsvAttendPeople"), objContent.m_strCreateUserID, strCreateUserName, System.Drawing.Color.White);

            string strXML = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[]{strXML1,strXML2,strXML3,objContent.m_strDiseaseNameXML,strXML4,objContent.m_strDiseaseChangeCaseXML,strXML5,objContent.m_strSaveResultXML,
																		 strXML6,objContent.m_strSaveDealXML/*});*/,strXML7/*,objContent.m_strAttendPeopleXML*/ });
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

			clsSaveRecordContent objContent=((clsSaveRecordContent)m_objRecordContent);
			string strText;
			strText=objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmSaveRecord"))+"   "+"抢救记录";
			return strText;
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.Save;
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

	}// END CLASS DEFINITION clsSaveInfo

}
