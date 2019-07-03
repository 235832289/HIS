using System;
using System.Xml;
using com.digitalwave.ICUIntensiveTendRecordServ;
using System.IO;
using System.Text;
using System.Collections;

namespace iCare
{
	/// <summary>
	/// Summary description for clsICUIntensiveTendRecordDomain.
	/// </summary>
	public class clsICUIntensiveTendRecordDomain
	{
        //private clsICUIntensiveTendRecordServ m_objServ=new clsICUIntensiveTendRecordServ();
		private XmlParserContext m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		private MemoryStream m_objXmlMemStream;
		private XmlTextWriter m_objXmlWriter;
		public clsICUIntensiveTendRecordDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符
		}
		///只需要查出时间
		public string[] m_strGetAllTendRecordCreateDateArr(string p_strInPatientID,string p_strInPatientDate)
		{
			string strXML = "";
			int intRows = 0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            try
            {
                long lngResult = m_objServ.m_lngGetAllTendRecordCreateDateArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out  strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)
			{
				string[] strDateArr=new string[intRows];

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				int intIndex = 0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{								
								strDateArr[intIndex++]= objReader.GetAttribute("CREATEDATE");								
							}
							break;
					}
				}				
				return strDateArr;
			}
			return null;		
		}

		public clsICUIntensiveTendRecord m_objGetLatestTendRecord(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			string strXML = "";
			int intRows = 0;
			string strParamXML="";
			int intParamRows=0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            try
            {
			    long lngResult=m_objServ.m_lngGetLatestTendRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out  strXML,out intRows,out strParamXML,out intParamRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)
			{
				clsICUIntensiveTendRecord objclsICUIntensiveTendRecord=new clsICUIntensiveTendRecord();

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{												
								objclsICUIntensiveTendRecord.m_strInPatientID= p_strInPatientID;
								objclsICUIntensiveTendRecord.m_strInPatientDate= p_strInPatientDate;
								objclsICUIntensiveTendRecord.m_strCreateDate= p_strCreateDate;
								objclsICUIntensiveTendRecord.m_strCreateUserID= objReader.GetAttribute("CREATEUSERID");
								objclsICUIntensiveTendRecord.m_strRecordContentXML= objReader.GetAttribute("RECORDCONTENTXML").Replace('き','\'');								
								objclsICUIntensiveTendRecord.m_strTemperatureXML= objReader.GetAttribute("TEMPERATUREXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strBreathXML= objReader.GetAttribute("BREATHXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strPulseXML= objReader.GetAttribute("PULSEXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strBloodPressureSXML= objReader.GetAttribute("BLOODPRESSURESXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strBloodPressureAXML= objReader.GetAttribute("BLOODPRESSUREAXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strPupilLeftXML= objReader.GetAttribute("PUPILLEFTXML").Replace('き','\'');									
								objclsICUIntensiveTendRecord.m_strPupilRightXML= objReader.GetAttribute("PUPILRIGHTXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strEchoLeftXML= objReader.GetAttribute("ECHOLEFTXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strEchoRightXML= objReader.GetAttribute("ECHORIGHTXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strInDXML= objReader.GetAttribute("INDXML").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strInIXML= objReader.GetAttribute("INIXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutUXML= objReader.GetAttribute("OUTUXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutSXML= objReader.GetAttribute("OUTSXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutVXML= objReader.GetAttribute("OUTVXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutEXML= objReader.GetAttribute("OUTEXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strIfConfirm= objReader.GetAttribute("IFCONFIRM");	
								objclsICUIntensiveTendRecord.m_strConfirmReason= objReader.GetAttribute("CONFIRMREASON").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strConfirmReasonXML= objReader.GetAttribute("CONFIRMREASONXML").Replace('き','\'');		
								
								objclsICUIntensiveTendRecord.m_strSensesXML= objReader.GetAttribute("SENSESXML").Replace('き','\'');
								//objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDateXML= objReader.GetAttribute("ABSORBPHLEGMDATEXML").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strPhlegmAttributeXML= objReader.GetAttribute("PHLEGMATTRIBUTEXML").Replace('き','\'');
						

								objclsICUIntensiveTendRecord.m_strRecordContent= objReader.GetAttribute("RECORDCONTENT").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strTemperature= objReader.GetAttribute("TEMPERATURE").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strBreath= objReader.GetAttribute("BREATH").Replace('き','\'');		
								objclsICUIntensiveTendRecord.m_strPulse= objReader.GetAttribute("PULSE").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strBloodPressureS= objReader.GetAttribute("BLOODPRESSURES").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strBloodPressureA= objReader.GetAttribute("BLOODPRESSUREA").Replace('き','\'');		
								objclsICUIntensiveTendRecord.m_strPupilLeft= objReader.GetAttribute("PUPILLEFT").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strPupilRight= objReader.GetAttribute("PUPILRIGHT").Replace('き','\'');		
								objclsICUIntensiveTendRecord.m_strEchoLeft= objReader.GetAttribute("ECHOLEFT").Replace('き','\'');		
								objclsICUIntensiveTendRecord.m_strEchoRight= objReader.GetAttribute("ECHORIGHT").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strInD= objReader.GetAttribute("IND").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strInI= objReader.GetAttribute("INI").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutU= objReader.GetAttribute("OUTU").Replace('き','\'');
								objclsICUIntensiveTendRecord.m_strOutS= objReader.GetAttribute("OUTS").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strOutV= objReader.GetAttribute("OUTV").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strOutE= objReader.GetAttribute("OUTE").Replace('き','\'');
			
								objclsICUIntensiveTendRecord.m_strSenses= objReader.GetAttribute("SENSES").Replace('き','\'');	
								objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDate= objReader.GetAttribute("ABSORBPHLEGMDATE");	
								objclsICUIntensiveTendRecord.m_strPhlegmAttribute= objReader.GetAttribute("PHLEGMATTRIBUTE").Replace('き','\'');	
								

							}
							break;
					}
				}
				objclsICUIntensiveTendRecord .m_objclsICUIntensiveTendRecordParamArr=m_objGetLatestTendRecordParam(strParamXML,intParamRows);
				
				return objclsICUIntensiveTendRecord;
			}
			return null;		
		}

		///读取机械参数表信息
		private clsICUIntensiveTendRecordParam[] m_objGetLatestTendRecordParam(string p_strXML,int p_intRows)
		{
			if(p_intRows>0)
			{
				clsICUIntensiveTendRecordParam[] objclsICUIntensiveTendRecordParamArr=new clsICUIntensiveTendRecordParam[p_intRows];

				XmlTextReader objReader = new XmlTextReader(p_strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				int intIndex = 0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{			
								objclsICUIntensiveTendRecordParamArr[intIndex]=new clsICUIntensiveTendRecordParam();
//								objclsICUIntensiveTendRecordParamArr[intIndex].m_strInPatientID= objReader.GetAttribute("INPATIENTID");//读取时此字段不必要
//								objclsICUIntensiveTendRecordParamArr[intIndex].m_strInPatientDate= objReader.GetAttribute("INPATIENTDATE");
//								objclsICUIntensiveTendRecordParamArr[intIndex].m_strCreateDate= objReader.GetAttribute("CREATEDATE");
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strModifyDate= objReader.GetAttribute("MODIFYDATE");	
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strModifyUserID= objReader.GetAttribute("MODIFYUSERID");		
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strModifyUserName= objReader.GetAttribute("MODIFYUSERNAME");		
							
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strStandardParamID= objReader.GetAttribute("STANDARDPARAMID").Replace('き','\'');	
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strStandardParamValue= objReader.GetAttribute("STANDARDPARAMVALUE").Replace('き','\'');
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strParamFlag= objReader.GetAttribute("PARAMFLAG");
								objclsICUIntensiveTendRecordParamArr[intIndex].m_strParamName= objReader.GetAttribute("PARAMNAME");
								intIndex++;								
							}
							break;
					}
				}		
				return objclsICUIntensiveTendRecordParamArr;
			}
			return null;			
		}

		///查出时间对应的从表信息（作用：在统计时读出相关的变量）
		public clsICUIntensiveTendRecordContent m_objGetLatestTendRecordContent(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			string strXML = "";
			int intRows = 0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            try
            {
                long lngResult = m_objServ.m_lngGetLatestTendRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out  strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)//intRows==1
			{
				clsICUIntensiveTendRecordContent objclsICUIntensiveTendRecordContent=new clsICUIntensiveTendRecordContent();

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{											
								objclsICUIntensiveTendRecordContent.m_strInPatientID= p_strInPatientID;
								objclsICUIntensiveTendRecordContent.m_strInPatientDate= p_strInPatientDate;
								objclsICUIntensiveTendRecordContent.m_strCreateDate= p_strCreateDate;

								objclsICUIntensiveTendRecordContent.m_strModifyDate= objReader.GetAttribute("MODIFYDATE");	
								objclsICUIntensiveTendRecordContent.m_strModifyUserID= objReader.GetAttribute("MODIFYUSERID");		
							
								objclsICUIntensiveTendRecordContent.m_strInD_Last= objReader.GetAttribute("IND_LAST");		
								objclsICUIntensiveTendRecordContent.m_strInI_Last= objReader.GetAttribute("INI_LAST");	
								objclsICUIntensiveTendRecordContent.m_strOutU_Last= objReader.GetAttribute("OUTU_LAST");	
								objclsICUIntensiveTendRecordContent.m_strOutS_Last= objReader.GetAttribute("OUTS_LAST");	
								objclsICUIntensiveTendRecordContent.m_strOutV_Last= objReader.GetAttribute("OUTV_LAST");	
								objclsICUIntensiveTendRecordContent.m_strOutE_Last= objReader.GetAttribute("OUTE_LAST");	
											
							}
							break;
					}
				}		
				return objclsICUIntensiveTendRecordContent;
			}
			return null;			
		}		

		/// <summary>
		/// 查询创建时间p_strCreateDate对应的当天出入量统计信息
		/// </summary>		
		public clsStatisticInfo_TotalInOut m_objGetStatisticInfo(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			string strXML = "";
			int intRows = 0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            try
            {
                long lngResult = m_objServ.m_lngGetStatisticInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out  strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)//intRows==1
			{
				clsStatisticInfo_TotalInOut objclsStatisticInfo_TotalInOut=new clsStatisticInfo_TotalInOut();

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								objclsStatisticInfo_TotalInOut.m_strTotalInD= objReader.GetAttribute("TOTALIND");
								objclsStatisticInfo_TotalInOut.m_strTotalInI= objReader.GetAttribute("TOTALINI");
								objclsStatisticInfo_TotalInOut.m_strTotalOutU= objReader.GetAttribute("TOTALOUTU");
								objclsStatisticInfo_TotalInOut.m_strTotalOutS= objReader.GetAttribute("TOTALOUTS");	
								objclsStatisticInfo_TotalInOut.m_strTotalOutV= objReader.GetAttribute("TOTALOUTV");				
								objclsStatisticInfo_TotalInOut.m_strTotalOutE= objReader.GetAttribute("TOTALOUTE");	
								objclsStatisticInfo_TotalInOut.m_strTotalIn= objReader.GetAttribute("TOTALIN");	
								objclsStatisticInfo_TotalInOut.m_strTotalOut= objReader.GetAttribute("TOTALOUT");		
							}
							break;
					}
				}
				objclsStatisticInfo_TotalInOut.m_strCreateDate=DateTime.Parse(p_strCreateDate).ToShortDateString();
				return objclsStatisticInfo_TotalInOut;
			}
			return null;			
		}
		
		/// 保存信息		
		public long m_lngSave(clsICUIntensiveTendRecord p_objclsICUIntensiveTendRecord,clsICUIntensiveTendRecordContent p_objclsICUIntensiveTendRecordContent,bool p_blnIsAddNew)
		{
            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            long lngResult = 0;
            try
            {
                if (p_blnIsAddNew == true)
                    lngResult = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMainXML(p_objclsICUIntensiveTendRecord), m_strGetMainAllContentXML(p_objclsICUIntensiveTendRecord), m_strGetParamXMLArr(p_objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr), m_strGetSubXML(p_objclsICUIntensiveTendRecordContent));
                else
                    lngResult = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMainXML(p_objclsICUIntensiveTendRecord), m_strGetMainAllContentXML(p_objclsICUIntensiveTendRecord), m_strGetParamXMLArr(p_objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr), m_strGetSubXML(p_objclsICUIntensiveTendRecordContent));
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}

		private string m_strGetMainXML(clsICUIntensiveTendRecord p_objclsICUIntensiveTendRecord)
		{
			
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("Model");

			try
			{
				m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsICUIntensiveTendRecord.m_strInPatientID);
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsICUIntensiveTendRecord.m_strInPatientDate);
				m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objclsICUIntensiveTendRecord.m_strCreateDate);
				m_objXmlWriter.WriteAttributeString("CREATEUSERID", p_objclsICUIntensiveTendRecord.m_strCreateUserID);
				m_objXmlWriter.WriteAttributeString("RECORDCONTENTXML", p_objclsICUIntensiveTendRecord.m_strRecordContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("TEMPERATUREXML", p_objclsICUIntensiveTendRecord.m_strTemperatureXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BREATHXML", p_objclsICUIntensiveTendRecord.m_strBreathXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PULSEXML", p_objclsICUIntensiveTendRecord.m_strPulseXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSURESXML", p_objclsICUIntensiveTendRecord.m_strBloodPressureSXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSUREAXML", p_objclsICUIntensiveTendRecord.m_strBloodPressureAXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILLEFTXML", p_objclsICUIntensiveTendRecord.m_strPupilLeftXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILRIGHTXML", p_objclsICUIntensiveTendRecord.m_strPupilRightXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHOLEFTXML", p_objclsICUIntensiveTendRecord.m_strEchoLeftXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHORIGHTXML", p_objclsICUIntensiveTendRecord.m_strEchoRightXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INDXML", p_objclsICUIntensiveTendRecord.m_strInDXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INIXML", p_objclsICUIntensiveTendRecord.m_strInIXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTUXML", p_objclsICUIntensiveTendRecord.m_strOutUXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTSXML", p_objclsICUIntensiveTendRecord.m_strOutSXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTVXML", p_objclsICUIntensiveTendRecord.m_strOutVXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTEXML", p_objclsICUIntensiveTendRecord.m_strOutEXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("IFCONFIRM", "0");//p_objclsICUIntensiveTendRecord.m_strIfConfirm);
				//	暂无，备用			m_objXmlWriter.WriteAttributeString("CONFIRMREASON", p_objclsICUIntensiveTendRecord.m_strConfirmReason.Replace('\'','き'));
				//	暂无，备用			m_objXmlWriter.WriteAttributeString("CONFIRMREASONXML", p_objclsICUIntensiveTendRecord.m_strConfirmReasonXML.Replace('\'','き'));

				m_objXmlWriter.WriteAttributeString("SENSESXML", p_objclsICUIntensiveTendRecord.m_strSensesXML.Replace('\'','き'));				
				m_objXmlWriter.WriteAttributeString("PHLEGMATTRIBUTEXML", p_objclsICUIntensiveTendRecord.m_strPhlegmAttributeXML.Replace('\'','き'));
		
				m_objXmlWriter.WriteAttributeString("STATUS", "0");
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);				
			}

			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
		
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}

		private string m_strGetMainAllContentXML(clsICUIntensiveTendRecord p_objclsICUIntensiveTendRecord)
		{
			m_objXmlMemStream.SetLength(0);			

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("Model");
			try
			{
				m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsICUIntensiveTendRecord.m_strInPatientID);
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsICUIntensiveTendRecord.m_strInPatientDate);
				m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objclsICUIntensiveTendRecord.m_strCreateDate);
				m_objXmlWriter.WriteAttributeString("RECORDCONTENT", p_objclsICUIntensiveTendRecord.m_strRecordContent.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("TEMPERATURE", p_objclsICUIntensiveTendRecord.m_strTemperature.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BREATH", p_objclsICUIntensiveTendRecord.m_strBreath.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PULSE", p_objclsICUIntensiveTendRecord.m_strPulse.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSURES", p_objclsICUIntensiveTendRecord.m_strBloodPressureS.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSUREA", p_objclsICUIntensiveTendRecord.m_strBloodPressureA.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILLEFT", p_objclsICUIntensiveTendRecord.m_strPupilLeft.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILRIGHT", p_objclsICUIntensiveTendRecord.m_strPupilRight.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHOLEFT", p_objclsICUIntensiveTendRecord.m_strEchoLeft.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHORIGHT", p_objclsICUIntensiveTendRecord.m_strEchoRight.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("IND", p_objclsICUIntensiveTendRecord.m_strInD.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INI", p_objclsICUIntensiveTendRecord.m_strInI.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTU", p_objclsICUIntensiveTendRecord.m_strOutU.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTS", p_objclsICUIntensiveTendRecord.m_strOutS.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTV", p_objclsICUIntensiveTendRecord.m_strOutV.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTE", p_objclsICUIntensiveTendRecord.m_strOutE.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("SENSES", p_objclsICUIntensiveTendRecord.m_strSenses.Replace('\'','き'));	
				m_objXmlWriter.WriteAttributeString("ABSORBPHLEGMDATE", p_objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PHLEGMATTRIBUTE", p_objclsICUIntensiveTendRecord.m_strPhlegmAttribute.Replace('\'','き'));		
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);				
			}
			//不存在此字段，m_objXmlWriter.WriteAttributeString("STATUS", "0");
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
		
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);	
		}

		

		private string m_strGetSubXML(clsICUIntensiveTendRecordContent p_objclsICUIntensiveTendRecordContent)
		{
			m_objXmlMemStream.SetLength(0);			

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("Model");
			try
			{
				m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsICUIntensiveTendRecordContent.m_strInPatientID);
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsICUIntensiveTendRecordContent.m_strInPatientDate);
				m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objclsICUIntensiveTendRecordContent.m_strCreateDate);
				m_objXmlWriter.WriteAttributeString("MODIFYDATE", p_objclsICUIntensiveTendRecordContent.m_strModifyDate);
				m_objXmlWriter.WriteAttributeString("MODIFYUSERID", p_objclsICUIntensiveTendRecordContent.m_strModifyUserID);
				m_objXmlWriter.WriteAttributeString("RECORDCONTENT_LAST", p_objclsICUIntensiveTendRecordContent.m_strRecordContent_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("TEMPERATURE_LAST", p_objclsICUIntensiveTendRecordContent.m_strTemperature_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BREATH_LAST", p_objclsICUIntensiveTendRecordContent.m_strBreath_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PULSE_LAST", p_objclsICUIntensiveTendRecordContent.m_strPulse_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSURES_LAST", p_objclsICUIntensiveTendRecordContent.m_strBloodPressureS_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPRESSUREA_LAST", p_objclsICUIntensiveTendRecordContent.m_strBloodPressureA_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILLEFT_LAST", p_objclsICUIntensiveTendRecordContent.m_strPupilLeft_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PUPILRIGHT_LAST", p_objclsICUIntensiveTendRecordContent.m_strPupilRight_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHOLEFT_LAST", p_objclsICUIntensiveTendRecordContent.m_strEchoLeft_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ECHORIGHT_LAST", p_objclsICUIntensiveTendRecordContent.m_strEchoRight_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("IND_LAST", p_objclsICUIntensiveTendRecordContent.m_strInD_Last);
				m_objXmlWriter.WriteAttributeString("INI_LAST", p_objclsICUIntensiveTendRecordContent.m_strInI_Last);	
				m_objXmlWriter.WriteAttributeString("OUTU_LAST", p_objclsICUIntensiveTendRecordContent.m_strOutU_Last);	
				m_objXmlWriter.WriteAttributeString("OUTS_LAST", p_objclsICUIntensiveTendRecordContent.m_strOutS_Last);	
				m_objXmlWriter.WriteAttributeString("OUTV_LAST", p_objclsICUIntensiveTendRecordContent.m_strOutV_Last);	
				m_objXmlWriter.WriteAttributeString("OUTE_LAST", p_objclsICUIntensiveTendRecordContent.m_strOutE_Last);		
	
				m_objXmlWriter.WriteAttributeString("SENSES_LAST", p_objclsICUIntensiveTendRecordContent.m_strSenses_Last.Replace('\'','き'));	
				m_objXmlWriter.WriteAttributeString("ABSORBPHLEGMDATE_LAST", p_objclsICUIntensiveTendRecordContent.m_strAbsorbPhlegmDate_Last.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PHLEGMATTRIBUTE_LAST", p_objclsICUIntensiveTendRecordContent.m_strPhlegmAttribute_Last.Replace('\'','き'));		
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);				
			}
			//不存在此字段，m_objXmlWriter.WriteAttributeString("STATUS", "0");
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
		
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);	
		}

		private string[] m_strGetParamXMLArr(clsICUIntensiveTendRecordParam[] p_objclsICUIntensiveTendRecordParamArr)
		{
			if(p_objclsICUIntensiveTendRecordParamArr ==null || p_objclsICUIntensiveTendRecordParamArr.Length==0)
				return null;
			string [] strParamXMLArr=new string[p_objclsICUIntensiveTendRecordParamArr.Length];
			for(int i=0;i<p_objclsICUIntensiveTendRecordParamArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);			

				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("Model");
				try
				{
					m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsICUIntensiveTendRecordParamArr[i].m_strInPatientID);
					m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsICUIntensiveTendRecordParamArr[i].m_strInPatientDate);
					m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objclsICUIntensiveTendRecordParamArr[i].m_strCreateDate);
					m_objXmlWriter.WriteAttributeString("MODIFYDATE", p_objclsICUIntensiveTendRecordParamArr[i].m_strModifyDate);
					m_objXmlWriter.WriteAttributeString("MODIFYUSERID", p_objclsICUIntensiveTendRecordParamArr[i].m_strModifyUserID);
					m_objXmlWriter.WriteAttributeString("STANDARDPARAMID", p_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamID.Replace('\'','き'));
					m_objXmlWriter.WriteAttributeString("STANDARDPARAMVALUE", p_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamValue.Replace('\'','き'));		
				}
				catch(Exception ex)
				{
					clsPublicFunction.ShowInformationMessageBox(ex.Message);				
				}
				m_objXmlWriter.WriteAttributeString("STATUS", "0");
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();
		
				strParamXMLArr[i]= System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);	
			}
			return strParamXMLArr;

		}

			

		public clsICUIntensiveTendRecordContent_All[] m_strGetclsICUIntensiveTendRecordContent_AllArr(string p_strInPatientID,string p_strInPatientDate,out clsStatisticInfo_TotalInOut[] p_objclsStatisticInfo_TotalInOutArr)
		{
			string strXML = "";
			int intRows = 0;
			p_objclsStatisticInfo_TotalInOutArr=null;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            long lngResult = 0;
            try
            {
                lngResult = m_objServ.m_lngGetAllTendRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out  strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			ArrayList arlStatisticInfo=new ArrayList();
			if(intRows>0)
			{
				clsICUIntensiveTendRecordContent_All[] objclsICUIntensiveTendRecordContent_AllArr=new clsICUIntensiveTendRecordContent_All[intRows];

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
								
				string strPreCreateDate="";
				int intIndex = 0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{		
								objclsICUIntensiveTendRecordContent_AllArr[intIndex]=new clsICUIntensiveTendRecordContent_All();
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate= objReader.GetAttribute("CREATEDATE");	
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateUserID= objReader.GetAttribute("CREATEUSERID");		
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strPhlegmAttribute= objReader.GetAttribute("PHLEGMATTRIBUTE");	
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strPhlegmAttributeXML= objReader.GetAttribute("PHLEGMATTRIBUTEXML");	
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strSenses= objReader.GetAttribute("SENSES");	
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strSensesXML= objReader.GetAttribute("SENSESXML");	
								
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strRecordContent= objReader.GetAttribute("RECORDCONTENT");	
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strRecordContentXML= objReader.GetAttribute("RECORDCONTENTXML");	

								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strFirstPrintDate= objReader.GetAttribute("FIRSTPRINTDATE");	//首次打印时间
								
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_objclsICUIntensiveTendRecordContentArr=m_strGetAllTendRecordContentArr(p_strInPatientID,p_strInPatientDate,objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate);
								objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_objclsICUIntensiveTendRecordParamArr=m_strGetAllTendRecordParamArr(p_strInPatientID,p_strInPatientDate,objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate);
								

								if(strPreCreateDate != DateTime.Parse(objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate).ToShortDateString())
								{
									arlStatisticInfo.Add(m_objGetStatisticInfo(p_strInPatientID,p_strInPatientDate,objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate));
								}
								strPreCreateDate=DateTime.Parse(objclsICUIntensiveTendRecordContent_AllArr[intIndex].m_strCreateDate).ToShortDateString();//保存上一天的日期
								
								intIndex++;
							}
							break;
					}
				}

				p_objclsStatisticInfo_TotalInOutArr= (clsStatisticInfo_TotalInOut[])(arlStatisticInfo.ToArray(typeof(clsStatisticInfo_TotalInOut)));
				return objclsICUIntensiveTendRecordContent_AllArr;
			}
			return null;		
		}	

		/// <summary>
		/// 查出所有信息（从表中所有修改过的结果），p_strInPatientDate的格式必须为"yyyy-MM-dd HH:mm:ss"
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public clsICUIntensiveTendRecordContent[] m_strGetAllTendRecordContentArr(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			string strXML = "";
			int intRows = 0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            long lngResult = 0;
            try
            {
                lngResult=m_objServ.m_lngGetAllTendRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out  strXML,out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)
			{
				clsICUIntensiveTendRecordContent[] objclsICUIntensiveTendRecordContentArr=new clsICUIntensiveTendRecordContent[intRows];

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				int intIndex = 0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								
								objclsICUIntensiveTendRecordContentArr[intIndex]=new clsICUIntensiveTendRecordContent();
								
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strCreateDate= objReader.GetAttribute("CDATE");//p_strCreateDate;
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strModifyDate= objReader.GetAttribute("MODIFYDATE");	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strModifyUserID= objReader.GetAttribute("MODIFYUSERID");		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strModifyUserName= objReader.GetAttribute("MODIFYUSERNAME");							
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strInD_Last= objReader.GetAttribute("IND_LAST");		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strInI_Last= objReader.GetAttribute("INI_LAST");
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strOutU_Last= objReader.GetAttribute("OUTU_LAST");		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strOutS_Last= objReader.GetAttribute("OUTS_LAST");		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strOutV_Last= objReader.GetAttribute("OUTV_LAST");	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strOutE_Last= objReader.GetAttribute("OUTE_LAST");	

								///////////////////////////////////////
								////.///////////////////////////////
								///
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strTemperature_Last= objReader.GetAttribute("TEMPERATURE_LAST").Replace('き','\'');
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strBreath_Last= objReader.GetAttribute("BREATH_LAST").Replace('き','\'');		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strPulse_Last= objReader.GetAttribute("PULSE_LAST").Replace('き','\'');
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strBloodPressureS_Last= objReader.GetAttribute("BLOODPRESSURES_LAST").Replace('き','\'');	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strBloodPressureA_Last= objReader.GetAttribute("BLOODPRESSUREA_LAST").Replace('き','\'');		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strPupilLeft_Last= objReader.GetAttribute("PUPILLEFT_LAST").Replace('き','\'');	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strPupilRight_Last= objReader.GetAttribute("PUPILRIGHT_LAST").Replace('き','\'');	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strEchoLeft_Last= objReader.GetAttribute("ECHOLEFT_LAST").Replace('き','\'');		
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strEchoRight_Last= objReader.GetAttribute("ECHORIGHT_LAST").Replace('き','\'');
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strSenses_Last= objReader.GetAttribute("SENSES_LAST").Replace('き','\'');	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strAbsorbPhlegmDate_Last= objReader.GetAttribute("ABSORBPHLEGMDATE_LAST");	
								objclsICUIntensiveTendRecordContentArr[intIndex].m_strPhlegmAttribute_Last= objReader.GetAttribute("PHLEGMATTRIBUTE_LAST").Replace('き','\'');	
								
								intIndex++;
							}
							break;
					}
				}				
				return objclsICUIntensiveTendRecordContentArr;
			}
			return null;		
		}

		/// <summary>
		/// 查出所有机械参数信息（从表中所有修改过的结果），p_strInPatientDate的格式必须为"yyyy-MM-dd HH:mm:ss"
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public clsICUIntensiveTendRecordParam[] m_strGetAllTendRecordParamArr(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			string strXML = "";
			int intRows = 0;

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            long lngResult = 0;
            try
            {
                lngResult=m_objServ.m_lngGetAllTendRecordParam(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out  strXML,out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return m_objGetLatestTendRecordParam(strXML,intRows);				
		}
		
		/// <summary>
		/// 更新当前病人所有对应记录的首次打印时间
		/// </summary>		
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,string p_strInPatientDate/*,string p_strCreateDate*/)
		{//更新第一次打印时间		

            clsICUIntensiveTendRecordServ m_objServ =
                (clsICUIntensiveTendRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTendRecordServ));

            long lngResult = 0;
            try
            {
                lngResult= m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate/*,p_strCreateDate*/);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}
	}

	/// <summary>
	/// ICU危重护理记录主表的类
	/// </summary>
	public class clsICUIntensiveTendRecord
	{
		public string m_strInPatientID;
		public string m_strInPatientDate;
		public string m_strCreateDate;

		public string m_strCreateUserID;
		
		public string m_strSensesXML;//神志,比clsIntensiveTendRecord多出的字段
		//已删除该字段，public string m_strAbsorbPhlegmDateXML;//吸痰时间，比clsIntensiveTendRecord多出的字段
		public string m_strPhlegmAttributeXML;//痰液性状,比clsIntensiveTendRecord多出的字段

		public string m_strRecordContentXML;		
		public string m_strTemperatureXML;		
		public string m_strBreathXML;		
		public string m_strPulseXML;		
		public string m_strBloodPressureSXML;		
		public string m_strBloodPressureAXML;		
		public string m_strPupilLeftXML;		
		public string m_strPupilRightXML;
		public string m_strEchoLeftXML;
		public string m_strEchoRightXML;
		public string m_strInDXML;
		public string m_strInIXML;
		public string m_strOutUXML;
		public string m_strOutSXML;
		public string m_strOutVXML;
		public string m_strOutEXML;
		public string m_strConfirmReasonXML;	
		
		public string m_strSenses;//包含历史内容的所有值串	
		public string m_strAbsorbPhlegmDate;//此字段只保存最终值，读取时直接读取该时间即可
		public string m_strPhlegmAttribute;
		public string m_strRecordContent;
		public string m_strTemperature;
		public string m_strBreath;
		public string m_strPulse;
		public string m_strBloodPressureS;
		public string m_strBloodPressureA;
		public string m_strPupilLeft;
		public string m_strPupilRight;
		public string m_strEchoLeft;
		public string m_strEchoRight;
		public string m_strInD;
		public string m_strInI;
		public string m_strOutU;
		public string m_strOutS;
		public string m_strOutV;
		public string m_strOutE;
		
		public string m_strIfConfirm;
		public string m_strConfirmReason;			

		public clsICUIntensiveTendRecordParam[] m_objclsICUIntensiveTendRecordParamArr;
	}

	/// <summary>
	/// ICU危重护理记录从表的类
	/// </summary>
	public class clsICUIntensiveTendRecordContent
	{
		public string m_strInPatientID;
		public string m_strInPatientDate;
		public string m_strCreateDate;
		public string m_strModifyDate;
		public string m_strModifyUserID;
		public string m_strModifyUserName;//仅读出时使用

		public string m_strSenses_Last;//最后结果值	
		public string m_strAbsorbPhlegmDate_Last;
		public string m_strPhlegmAttribute_Last;
		public string m_strRecordContent_Last;
		public string m_strTemperature_Last;
		public string m_strBreath_Last;
		public string m_strPulse_Last;
		public string m_strBloodPressureS_Last;
		public string m_strBloodPressureA_Last;
		public string m_strPupilLeft_Last;
		public string m_strPupilRight_Last;
		public string m_strEchoLeft_Last;
		public string m_strEchoRight_Last;		
		
		public string m_strInD_Last;//保存时用到，查询统计时用到		
		public string m_strInI_Last;		
		public string m_strOutU_Last;		
		public string m_strOutS_Last;		
		public string m_strOutV_Last;		
		public string m_strOutE_Last;			
	}

	/// <summary>
	/// 出入量统计的类
	/// </summary>
	public class clsStatisticInfo_TotalInOut
	{
		public string m_strTotalInD;//查询统计时用来输出，保存时不用
		public string m_strTotalInI;
		public string m_strTotalOutU;
		public string m_strTotalOutS;
		public string m_strTotalOutV;
		public string m_strTotalOutE;
		public string m_strTotalIn;
		public string m_strTotalOut;
		public string m_strCreateDate;
	}

//	/// <summary>
//	/// ICU危重护理记录所有信息的类
//	/// </summary>
//	public class clsICUIntensiveTendRecord_All
//	{
//		public clsICUIntensiveTendRecord m_objclsICUIntensiveTendRecord;
//		public clsICUIntensiveTendRecordContent m_objclsICUIntensiveTendRecordContent;
//	}

	public class clsICUIntensiveTendRecordParam
	{
		public string m_strInPatientID;
		public string m_strInPatientDate;
		public string m_strCreateDate;
		public string m_strModifyDate;
		public string m_strModifyUserID;
		public string m_strModifyUserName;//仅读出时使用

		public string m_strStandardParamID;//参数ID		
		public string m_strStandardParamValue;//参数值,（数值型）

		/// <summary>
		/// 参数标志：0：监护仪，2：呼吸机
		/// </summary>
		public string m_strParamFlag;//仅读出时使用
		/// <summary>
		/// 参数名称
		/// </summary>
		public string m_strParamName;//仅读出时使用
	}

	/// <summary>
	/// 包含所有打印数据的类（所有中间结果和中间参数）
	/// </summary>
	public class clsICUIntensiveTendRecordContent_All
	{
		public string m_strCreateDate;
		public string m_strCreateUserID;
		public string m_strSenses;//神志	
		public string m_strPhlegmAttribute;//痰液性状
		public string m_strSensesXML;//神志	
		public string m_strPhlegmAttributeXML;//痰液性状
		public string m_strRecordContentXML;//含所有修改痕迹的内容的格式
		public string m_strRecordContent;//含所有修改痕迹的内容
		public string m_strFirstPrintDate;//首次打印时间
		public clsICUIntensiveTendRecordContent[] m_objclsICUIntensiveTendRecordContentArr;//要打印的每次修改后的正确内容
		public clsICUIntensiveTendRecordParam[] m_objclsICUIntensiveTendRecordParamArr;//最后一次保存后留下的正确内容
	}
	
}
