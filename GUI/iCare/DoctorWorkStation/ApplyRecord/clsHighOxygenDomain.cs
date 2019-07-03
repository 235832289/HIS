using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.HighOxygenServ;
using com.digitalwave.SPECTCheckOrderServ;
using System.Text;


namespace iCare
{
	/// <summary>
	/// Summary description for clsHighOxygenDomain.
	/// </summary>
	public class clsHighOxygenDomain
	{
		/// <summary>
		/// 生成Xml的缓冲
		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 生成Xml的工具
		/// </summary>
	
		private XmlTextWriter m_objXmlWriter;
		///  <summary>
		/// 读取Xml工具输入参数		
		/// </summary>
		private XmlParserContext m_objXmlParser;
        //private com.digitalwave.HighOxygenServ.clsHighOxygenServ  m_objServ;
		
		public clsHighOxygenDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		
            //m_objServ =new com.digitalwave.HighOxygenServ.clsHighOxygenServ(); 
		
		}
		public long m_lngDeactive(string p_strDeactiveUserID,string p_strInPatientID,string p_strInPatientDate,
			string p_strCreateDate)
		{
            long lngRes = 0;

            clsSPECTCheckOrderServ m_objServ =
                (clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSPECTCheckOrderServ));

			try
            {
                string strDeactiveXML = "<Deactive Status='1' DeActivedOperatorID='"+p_strDeactiveUserID+"' InPatientID='"+p_strInPatientID +"'"+" InPatientDate='"+p_strInPatientDate+ "'" +" CreateDate='"+p_strCreateDate+"'" +" />";
                lngRes = m_objServ.m_lngDeActive(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strDeactiveXML, "HightOxygenCheckOrder");
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 所有的HighOxygen申请时间
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;

            com.digitalwave.HighOxygenServ.clsHighOxygenServ m_objServ =
                (com.digitalwave.HighOxygenServ.clsHighOxygenServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.HighOxygenServ.clsHighOxygenServ));

            try
            {
                string strXml = "";
                int intRows = 0;

                long lngRes = m_objServ.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, ref strXml, ref intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    dtmCreateRecordDateArr = new DateTime[intRows];

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    dtmCreateRecordDateArr[intIndex] = DateTime.Parse(objReader.GetAttribute("CREATEDATE"));
                                    intIndex++;
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return dtmCreateRecordDateArr ;
		}


		public long lngSave(clsHightOxygen m_objHightOxygen)
		{
            long lngSucceed = 0;

            com.digitalwave.HighOxygenServ.clsHighOxygenServ m_objServ =
                (com.digitalwave.HighOxygenServ.clsHighOxygenServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.HighOxygenServ.clsHighOxygenServ));

            try
            {
                string strXML = this.strSaveXML(m_objHightOxygen);
                lngSucceed = m_objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strXML);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngSucceed;
		}

		private string strSaveXML(clsHightOxygen m_objclsHightOxygen)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objclsHightOxygen.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objclsHightOxygen.strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", m_objclsHightOxygen.strCreateDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", m_objclsHightOxygen.strIfConfirm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", m_objclsHightOxygen.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", m_objclsHightOxygen.strCreateUserID.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("APPLYDOCID", m_objclsHightOxygen.strApplyDocID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTCT", m_objclsHightOxygen.strAssistantCT.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTEEG", m_objclsHightOxygen.strAssistantEEG.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("ASSISTANTEKG", m_objclsHightOxygen.strAssistantEKG.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTMR", m_objclsHightOxygen.strAssistantMR.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTOTHER", m_objclsHightOxygen.strAssistantOthe.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("CLINICCHECK", m_objclsHightOxygen.strClinicCheck.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CLINICCURE", m_objclsHightOxygen.strClinicCure.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CLINICDIAGNOSE", m_objclsHightOxygen.strClinicDiagnose.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("DOCID", m_objclsHightOxygen.strDocID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HIGHOXYGEN", m_objclsHightOxygen.strHighOxygen.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HIGHOXYGENTIME", m_objclsHightOxygen.strHighOxygenTime.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("RESUME", m_objclsHightOxygen.strResume.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ORDERID", m_objclsHightOxygen.strOrderID.Replace('\'','き'));
			
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}


		public clsHightOxygen objDisplay(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			string strXML="";
            int intRows = 0; 
            long lngSucceed = 0;
			clsHightOxygen m_objDisplay =new clsHightOxygen();

            com.digitalwave.HighOxygenServ.clsHighOxygenServ m_objServ =
                (com.digitalwave.HighOxygenServ.clsHighOxygenServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.HighOxygenServ.clsHighOxygenServ));

            try
            {
                lngSucceed = m_objServ.lngSelectNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref strXML, ref intRows);
                if (intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    m_objDisplay.strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');
                                    m_objDisplay.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                    m_objDisplay.strCreateDate = objReader.GetAttribute("CREATEDATE").ToString().Replace('き', '\'');
                                    m_objDisplay.strCreateUserID = objReader.GetAttribute("CREATEUSERID").ToString().Replace('き', '\'');

                                    m_objDisplay.strApplyDocID = objReader.GetAttribute("APPLYDOCID").ToString().Replace('き', '\'');
                                    m_objDisplay.strAssistantCT = objReader.GetAttribute("ASSISTANTCT").ToString().Replace('き', '\'');
                                    m_objDisplay.strAssistantEEG = objReader.GetAttribute("ASSISTANTEEG").ToString().Replace('き', '\'');

                                    m_objDisplay.strAssistantEKG = objReader.GetAttribute("ASSISTANTEKG").ToString().Replace('き', '\'');
                                    m_objDisplay.strAssistantMR = objReader.GetAttribute("ASSISTANTMR").ToString().Replace('き', '\'');
                                    m_objDisplay.strAssistantOthe = objReader.GetAttribute("ASSISTANTOTHER").ToString().Replace('き', '\'');

                                    m_objDisplay.strClinicCheck = objReader.GetAttribute("CLINICCHECK").ToString().Replace('き', '\'');
                                    m_objDisplay.strClinicCure = objReader.GetAttribute("CLINICCURE").ToString().Replace('き', '\'');
                                    m_objDisplay.strClinicDiagnose = objReader.GetAttribute("CLINICDIAGNOSE").ToString().Replace('き', '\'');

                                    m_objDisplay.strDocID = objReader.GetAttribute("DOCID").ToString().Replace('き', '\'');
                                    m_objDisplay.strHighOxygen = objReader.GetAttribute("HIGHOXYGEN").ToString().Replace('き', '\'');
                                    m_objDisplay.strHighOxygenTime = objReader.GetAttribute("HIGHOXYGENTIME").ToString().Replace('き', '\'');

                                    m_objDisplay.strResume = objReader.GetAttribute("RESUME").ToString().Replace('き', '\'');
                                    m_objDisplay.strOrderID = objReader.GetAttribute("ORDERID").ToString().Replace('き', '\'');
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return m_objDisplay;
		}
	}


	public class clsHightOxygen
	{
		public string strInPatientID = "";	
		public string strInPatientDate = "";
		public string strCreateDate = "";	
		public string strCreateUserID = "";	
		public string strIfConfirm = "";
		public string strStatus = "";

		public string strResume;
		public string strClinicCheck = "";
		public string strAssistantCT = "";
		public string strAssistantMR = "";
		public string strAssistantEEG = "";
		public string strAssistantEKG = "";
		public string strAssistantOthe = "";
		public string strClinicCure = "";
		public string strHighOxygen = "";
		public string strClinicDiagnose = "";
		public string strHighOxygenTime = "";
		public string strApplyDocID = "";
		public string strDocID = "";
		public string strOrderID = "";
	}

}
