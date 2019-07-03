using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.CTCheckOrderServ;
using com.digitalwave.SPECTCheckOrderServ ;
using System.Text;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsCTCheckOrderDomain.
	/// </summary>
	public class clsCTCheckOrderDomain
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
        //private com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ  m_objServ;
		
		/// <summary>
		/// 所有的CT申请时间
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;

            com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ m_objServ =
                (com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ));

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

		/// <summary>
		/// 所有的CT申请时间
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;

            com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ m_objServ =
                (com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ));

            try
            {
			    string strXml = "";
			    int intRows = 0;

			    long lngRes= m_objServ.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,null,ref strXml,ref intRows);
    		
			    if(lngRes > 0 && intRows >0)
			    {
				    dtmCreateRecordDateArr = new DateTime [intRows];

				    XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				    objReader.WhitespaceHandling = WhitespaceHandling.None;
    			
				    int intIndex = 0;
				    while(objReader.Read())
				    {
					    switch (objReader.NodeType)
					    {
						    case XmlNodeType.Element:
							    if(objReader.HasAttributes)
							    {
								    dtmCreateRecordDateArr[intIndex]=DateTime.Parse (objReader.GetAttribute("CREATEDATE"));
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

		public clsCTCheckOrderDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		
            //m_objServ =new com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ(); 
		
		}

		
		public long m_lngDeactive(string p_strDeactiveUserID,string p_strInPatientID,string p_strInPatientDate,
			string p_strCreateDate)
		{
            clsSPECTCheckOrderServ m_objServ =
                (clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSPECTCheckOrderServ));

            long lngRes = 0;
            try
            {
                string strDeactiveXML = "<Deactive STATUS='1' DEACTIVEDOPERATORID='" + p_strDeactiveUserID + "' INPATIENTID='" + p_strInPatientID + "'" + " INPATIENTDATE='" + p_strInPatientDate + "'" + " CREATEDATE='" + p_strCreateDate + "'" + " />";
                lngRes = m_objServ.m_lngDeActive(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strDeactiveXML, "CTCheckOrder");
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}
//
//		//添加两个参数：RequestImage,ApplicationID。
//		public long lngSave(clsCTCheckOrder m_objCTCheckOrderContent)
//
//		{			
//			string strXML=this.strSaveXML(m_objCTCheckOrderContent); 
//			long lngSucceed=m_objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strXML); 
//
//			return lngSucceed;
//		}

		public long lngSave(clsCTCheckOrder m_objCTCheckOrderContent,bool p_bnlIsAddNew,
							ImageRequest p_objImageRequest ,ref string p_strApplicationID)

		{		
			string m_strApplicationID="";

			if( p_bnlIsAddNew==false)
			{
				if(m_objCTCheckOrderContent!=null)
					//m_strApplicationID=m_objCTCheckOrderContent.strApplicationID;
					m_strApplicationID=p_strApplicationID;
					
			}
			else
			{
				m_lngGetApplicationid(ref m_strApplicationID);
			}
            long lngSucceed = 0;
            com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ m_objServ =
                (com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ));

            try
            {
                string strXML = this.strSaveXML(m_objCTCheckOrderContent);
                lngSucceed = m_objServ.m_lngSaveRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strXML,
                    p_objImageRequest, ref m_strApplicationID, p_bnlIsAddNew);

                p_strApplicationID = m_strApplicationID;
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngSucceed;
		}

		private string strSaveXML(clsCTCheckOrder m_objCTCheckOrderContent)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objCTCheckOrderContent.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objCTCheckOrderContent.strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", m_objCTCheckOrderContent.strCreateDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", m_objCTCheckOrderContent.strIfConfirm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", m_objCTCheckOrderContent.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", m_objCTCheckOrderContent.strCreateUserID.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("ADVANCEID", m_objCTCheckOrderContent.strAdvanceID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ADVANCETIME", m_objCTCheckOrderContent.strAdvanceTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AKP", m_objCTCheckOrderContent.strAKP.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("ALBUMEN", m_objCTCheckOrderContent.strAlbumen.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("APPLYDOTORID", m_objCTCheckOrderContent.strApplyDotorID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLADDER", m_objCTCheckOrderContent.strBladder.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("BLOOD", m_objCTCheckOrderContent.strBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLOODDOOP", m_objCTCheckOrderContent.strBloodDoop.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BREAST", m_objCTCheckOrderContent.strBreast.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("CANCER", m_objCTCheckOrderContent.strCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKMONEYCONTENT", m_objCTCheckOrderContent.strCheckMoneyContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKPART", m_objCTCheckOrderContent.strCheckPart.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("CLINIC", m_objCTCheckOrderContent.strClinic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CTNO", m_objCTCheckOrderContent.strCTNO.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("EMICTION", m_objCTCheckOrderContent.strEmiction.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FECULA", m_objCTCheckOrderContent.strFecula.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FETUS", m_objCTCheckOrderContent.strFetus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("IDEA", m_objCTCheckOrderContent.strIdea.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LIVER", m_objCTCheckOrderContent.strLiver.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OTHER", m_objCTCheckOrderContent.strOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PANCREAS", m_objCTCheckOrderContent.strPancreas.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("PARTICULAR", m_objCTCheckOrderContent.strParticular.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEE17", m_objCTCheckOrderContent.strPee17.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGM", m_objCTCheckOrderContent.strPhlegm.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("PHOTOMONTYCONTENT", m_objCTCheckOrderContent.strPhotoMontyContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RED", m_objCTCheckOrderContent.strRed.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RESUMEASTHMAHAVE", m_objCTCheckOrderContent.strResumeAsthmaHave.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("RESUMEASTHMANONE", m_objCTCheckOrderContent.strResumeAsthmaNone.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RESUMEHAVE", m_objCTCheckOrderContent.strResumeHave.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RESUMENONE", m_objCTCheckOrderContent.strResumeNone.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("SCAN", m_objCTCheckOrderContent.strScan.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TOOL", m_objCTCheckOrderContent.strTool.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ULTRASONIC", m_objCTCheckOrderContent.strUltrasonic.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("WALK", m_objCTCheckOrderContent.strWalk.Replace('\'','き'));
			
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}


		public clsCTCheckOrder objDisplay(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			string strXML="";
			int intRows=0;

			clsCTCheckOrder m_objDisplay =new clsCTCheckOrder();

            com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ m_objServ =
                (com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ));

            try
            {
                if (strInPatientDate == null || strInPatientDate.Trim() == "")
                {
                    long lngSucceed = m_objServ.lngSelectNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strCreateDate, ref strXML, ref intRows);
                }
                else
                {
                    long lngSucceed = m_objServ.lngSelectNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref strXML, ref intRows);
                }
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

                                    m_objDisplay.strAdvanceID = objReader.GetAttribute("ADVANCEID").ToString().Replace('き', '\'');
                                    m_objDisplay.strAdvanceTime = objReader.GetAttribute("ADVANCETIME").ToString().Replace('き', '\'');
                                    m_objDisplay.strAKP = objReader.GetAttribute("AKP").ToString().Replace('き', '\'');

                                    m_objDisplay.strAlbumen = objReader.GetAttribute("ALBUMEN").ToString().Replace('き', '\'');
                                    m_objDisplay.strApplyDotorID = objReader.GetAttribute("APPLYDOTORID").ToString().Replace('き', '\'');
                                    m_objDisplay.strBladder = objReader.GetAttribute("BLADDER").ToString().Replace('き', '\'');

                                    m_objDisplay.strBlood = objReader.GetAttribute("BLOOD").ToString().Replace('き', '\'');
                                    m_objDisplay.strBloodDoop = objReader.GetAttribute("BLOODDOOP").ToString().Replace('き', '\'');
                                    m_objDisplay.strBreast = objReader.GetAttribute("BREAST").ToString().Replace('き', '\'');

                                    m_objDisplay.strCancer = objReader.GetAttribute("CANCER").ToString().Replace('き', '\'');
                                    m_objDisplay.strCheckMoneyContent = objReader.GetAttribute("CHECKMONEYCONTENT").ToString().Replace('き', '\'');
                                    m_objDisplay.strCheckPart = objReader.GetAttribute("CHECKPART").ToString().Replace('き', '\'');

                                    m_objDisplay.strClinic = objReader.GetAttribute("CLINIC").ToString().Replace('き', '\'');
                                    m_objDisplay.strCreateUserID = objReader.GetAttribute("CREATEUSERID").ToString().Replace('き', '\'');

                                    m_objDisplay.strCTNO = objReader.GetAttribute("CTNO").ToString().Replace('き', '\'');
                                    m_objDisplay.strEmiction = objReader.GetAttribute("EMICTION").ToString().Replace('き', '\'');
                                    m_objDisplay.strFecula = objReader.GetAttribute("FECULA").ToString().Replace('き', '\'');

                                    m_objDisplay.strFetus = objReader.GetAttribute("FETUS").ToString().Replace('き', '\'');
                                    m_objDisplay.strIdea = objReader.GetAttribute("IDEA").ToString().Replace('き', '\'');
                                    m_objDisplay.strLiver = objReader.GetAttribute("LIVER").ToString().Replace('き', '\'');

                                    m_objDisplay.strOther = objReader.GetAttribute("OTHER").ToString().Replace('き', '\'');
                                    m_objDisplay.strPancreas = objReader.GetAttribute("PANCREAS").ToString().Replace('き', '\'');
                                    m_objDisplay.strParticular = objReader.GetAttribute("PARTICULAR").ToString().Replace('き', '\'');

                                    m_objDisplay.strPee17 = objReader.GetAttribute("PEE17").ToString().Replace('き', '\'');
                                    m_objDisplay.strPhlegm = objReader.GetAttribute("PHLEGM").ToString().Replace('き', '\'');
                                    m_objDisplay.strPhotoMontyContent = objReader.GetAttribute("PHOTOMONTYCONTENT").ToString().Replace('き', '\'');

                                    m_objDisplay.strRed = objReader.GetAttribute("RED").ToString().Replace('き', '\'');
                                    m_objDisplay.strResumeAsthmaHave = objReader.GetAttribute("RESUMEASTHMAHAVE").ToString().Replace('き', '\'');
                                    m_objDisplay.strResumeAsthmaNone = objReader.GetAttribute("RESUMEASTHMANONE").ToString().Replace('き', '\'');

                                    m_objDisplay.strResumeHave = objReader.GetAttribute("RESUMEHAVE").ToString().Replace('き', '\'');
                                    m_objDisplay.strResumeNone = objReader.GetAttribute("RESUMENONE").ToString().Replace('き', '\'');
                                    m_objDisplay.strScan = objReader.GetAttribute("SCAN").ToString().Replace('き', '\'');

                                    m_objDisplay.strTool = objReader.GetAttribute("TOOL").ToString().Replace('き', '\'');
                                    m_objDisplay.strUltrasonic = objReader.GetAttribute("ULTRASONIC").ToString().Replace('き', '\'');
                                    m_objDisplay.strWalk = objReader.GetAttribute("WALK").ToString().Replace('き', '\'');
                                    m_objDisplay.strApplicationID = objReader.GetAttribute("APPLICATIONID").ToString().Replace('き', '\'');


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

		public long m_lngGetApplicationid(ref string p_strApplicationid)
		{
			long lngRet=0;
			string strXML="";
			int intRows=0;

            com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ m_objServ =
                (com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CTCheckOrderServ.clsCTCheckOrderServ));

            try
            {
                lngRet = m_objServ.m_lngGetApplicationID(ref strXML, ref intRows);
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
                                    p_strApplicationid = objReader.GetAttribute("APPLICATIONID").ToString().Replace('き', '\'');
                                }
                                break;
                        }
                    }
                    if (p_strApplicationid.StartsWith("P"))
                        p_strApplicationid = p_strApplicationid.Remove(0, 1);
                    long mMax = long.Parse(p_strApplicationid) + 1;
                    if (mMax < 100000)
                    {
                        p_strApplicationid = "P" + mMax.ToString("00000");
                    }
                    else
                    {
                        p_strApplicationid = "P" + mMax.ToString();
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRet;
		}
	}

	public class clsCTCheckOrder
	{
		public string strResumeHave = "";
		public string strResumeNone = "";
		public string strResumeAsthmaHave = "";
		public string strResumeAsthmaNone = "";
		public string strTool = "";
		public string strWalk = "";
		public string strParticular = "";	
		public string strClinic = "";	
		public string strCheckPart = "";	
		public string strApplyDotorID = "";
		public string strLiver = "";	
		public string strAlbumen = "";	
		public string strFetus = "";	
		public string strRed = "";	
		public string strAKP = "";	
		public string strCancer = "";	
		public string strFecula = "";	
		public string strPee17 = "";	
		public string strBlood = "";	
		public string strBloodDoop = "";	
		public string strPhlegm = "";	
		public string strEmiction = "";	
		public string strBreast = "";	
		public string strPancreas = "";	
		public string strScan = "";	
		public string strBladder = "";	
		public string strUltrasonic = "";	
		public string strOther = "";	
		public string strIdea = "";	
		public string strAdvanceTime = "";	
		public string strAdvanceID = "";	
		public string strCheckMoneyContent = "";	
		public string strCTNO = "";
		public string strPhotoMontyContent = "";	
		public string strInPatientID = "";	
		public string strInPatientDate = "";
		public string strCreateDate = "";	
		public string strCreateUserID = "";	
		public string strIfConfirm = "";
		public string strStatus = "";
		public string strApplicationID = "";
	}

}
