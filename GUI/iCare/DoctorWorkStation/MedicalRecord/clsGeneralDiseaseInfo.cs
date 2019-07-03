using System;
using iCareData;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 一般病程记录信息。
	/// </summary>
	public class clsGeneralDiseaseInfo	: clsDiseaseTrackInfo
	{
		private string m_strText,m_strXml,m_strSignText,m_strSignXml;
		private bool m_blnInited = false;
		
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			if(m_objRecordContent==null)
				return "";

			if(!m_blnInited)
			{
				m_mthInit();

				m_blnInited = true;
			}

			return m_strText;
		}

		/// <summary>
		/// 特殊记录内容格式Xml的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackXml()
		{
			if(m_objRecordContent==null)
				return "";

			if(!m_blnInited)
			{
				m_mthInit();

				m_blnInited = true;
			}
			
			return m_strXml;
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

//			if(!m_blnInited)
//			{
//				m_mthInit();
//
//				m_blnInited = true;
//			}
//			
//			return m_strSignXml;
			return "<Root />";
		}		

		private void m_mthInit()
		{
			clsGeneralDiseaseRecordContent objGDRC = (clsGeneralDiseaseRecordContent)m_objRecordContent;
			string strHeader = objGDRC.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmGeneralDisease"))+"   "
				+objGDRC.m_strRecordTitle + "\n";
            string strHeaderXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml(strHeader, objGDRC.m_strModifyUserID, new clsEmployee(objGDRC.m_strModifyUserID).m_StrFirstName, System.Drawing.Color.White);
			m_strText =  strHeader + objGDRC.m_strRecordContent;
            m_strXml = ctlRichTextBox.clsXmlTool.s_strCombineXml(new string[] { strHeaderXml, objGDRC.m_strRecordContentXml });
           
			m_sbdTemp.Length = 0;

			if(objGDRC.m_strGeneralDiseaseDoctorNameArr != null)
			{
				for(int i=0;i<objGDRC.m_strGeneralDiseaseDoctorNameArr.Length;i++)
				{
					if(i !=objGDRC.m_strGeneralDiseaseDoctorNameArr.Length-1)
						m_sbdTemp.Append(objGDRC.m_strGeneralDiseaseDoctorNameArr[i]+"　");//注意：此处填充的空格是全角占一个汉字的空格
					else
						m_sbdTemp.Append(objGDRC.m_strGeneralDiseaseDoctorNameArr[i]);

				}
			}
			
			m_strSignText = m_sbdTemp.ToString();
			m_strSignXml = "<root />";
		}
		
		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.GeneralDisease;
		}

	}// END CLASS DEFINITION clsGeneralDiseaseInfo
}
