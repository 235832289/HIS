using System;
using System.Xml;
using System.IO;
using System.Text;
using iCareData;
using com.digitalwave.Utility.Controls;
using com.digitalwave.BornScheduleService;
using System.Data ;
using System.Collections ;
namespace iCare
{
	/// <summary>
	/// clsBornScheduleDomain 的摘要说明。
	/// </summary>
	public class clsBornScheduleDomain
	{
		/// 生成Xml的缓冲

		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 生成Xml的工具

		/// </summary>
		private XmlTextWriter m_objXmlWriter;

		/// <summary>
		/// 读取Xml工具输入参数
		/// </summary>
		private XmlParserContext m_objXmlParser;

		private XmlTextReader m_objXmlReader;

        //private clsBornScheduleService  m_objBornScheduleService;

		public clsBornScheduleDomain( )
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符


			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);

//			m_objXmlReader = new XmlTextReader("1",XmlNodeType.Element,m_objXmlParser);
		
            //m_objBornScheduleService=new clsBornScheduleService();

		}

		//生成表所需要的XML格式
		public long m_bnlMainXml(clsBornRecordManager p_objBornRecordManager,int p_intPageIndex,string p_strINPATIENTID,DateTime p_dtINPATIENTDATE,DateTime p_dtOPENDATE,string p_strCREATEID,DateTime p_dtCHILDBIRTHDATE,DateTime p_dtFORECASTDATE,string p_strPREGNANCYNUM,bool p_bnlIsNew)
		{
            clsBornScheduleService m_objBornScheduleService =
                (clsBornScheduleService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBornScheduleService));

            long lngRes = 0;
            try
            {
                clsBornScheduleRecordInfo objRecordInfo = (clsBornScheduleRecordInfo)m_objChangeBornScheduleToXml(p_objBornRecordManager, p_intPageIndex, p_strINPATIENTID, p_dtINPATIENTDATE, p_dtOPENDATE, p_strCREATEID, p_dtCHILDBIRTHDATE, p_dtFORECASTDATE, p_strPREGNANCYNUM);
                string strXML = m_strMakeMainXml(objRecordInfo);
                lngRes = m_objBornScheduleService.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strXML, p_bnlIsNew);
            }
            finally
            {
                //m_objBornScheduleService.Dispose();
            }
            return lngRes;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成mainxML</returns>
		private string  m_strMakeMainXml(clsBornScheduleRecordInfo p_objBornScheduleRecordInfo)
		{
			string strMainXml = null;

		
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("clsBornScheduleRecordInfo");

			m_objXmlWriter.WriteAttributeString("INPATIENTID",p_objBornScheduleRecordInfo.m_strINPATIENTID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE",p_objBornScheduleRecordInfo.m_dtmINPATIENTDATE.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("OPENDATE",p_objBornScheduleRecordInfo.m_dtmOPENDATE.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("CHILDBIRTHDATE",p_objBornScheduleRecordInfo.m_dtmCHILDBIRTHDATE.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("CREATEID",p_objBornScheduleRecordInfo.m_strCREATEID);
			m_objXmlWriter.WriteAttributeString("MODIFYDATE",p_objBornScheduleRecordInfo.m_dtmMODIFYDATE.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("FORECASTDATE",p_objBornScheduleRecordInfo.m_dtmFORECASTDATE.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("FIRSTPOINT",p_objBornScheduleRecordInfo.m_strFIRSTPOINT);
			m_objXmlWriter.WriteAttributeString("SECONDPOINT",p_objBornScheduleRecordInfo.m_strSECONDPOINT);
			m_objXmlWriter.WriteAttributeString("THREEPOINT",p_objBornScheduleRecordInfo.m_strTHREEPOINT);
			m_objXmlWriter.WriteAttributeString("FOUTPOINT",p_objBornScheduleRecordInfo.m_strFOUTPOINT);
			m_objXmlWriter.WriteAttributeString("PREGNANCYNUM",p_objBornScheduleRecordInfo.m_strPREGNANCYNUM);
			m_objXmlWriter.WriteAttributeString("VENTERPOINTXML",p_objBornScheduleRecordInfo.m_strVENTERPOINTXML);
			m_objXmlWriter.WriteAttributeString("CHECKVENTERTIMEXML",p_objBornScheduleRecordInfo.m_strCHECKVENTERTIMEXML);
			m_objXmlWriter.WriteAttributeString("BLOODPRESSUREXML",p_objBornScheduleRecordInfo.m_strBLOODPRESSUREXML);
			m_objXmlWriter.WriteAttributeString("EMBRYOHEARTXML",p_objBornScheduleRecordInfo.m_strEMBRYOHEARTXML);
			m_objXmlWriter.WriteAttributeString("VENTERSCALEXML",p_objBornScheduleRecordInfo.m_strVENTERSCALEXML);
			m_objXmlWriter.WriteAttributeString("EXCEPTIONNOTEXML",p_objBornScheduleRecordInfo.m_strEXCEPTIONNOTEXML);
			m_objXmlWriter.WriteAttributeString("DEALNOTEXML",p_objBornScheduleRecordInfo.m_strDEALNOTEXML);
			m_objXmlWriter.WriteAttributeString("SIGNXML",p_objBornScheduleRecordInfo.m_strSIGNXML);
			
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			strMainXml = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			

			return strMainXml;
		}

		//clsBornRecordManager  change into clsBornScheduleRecordInfo
		public clsBornScheduleRecordInfo m_objChangeBornScheduleToXml(clsBornRecordManager p_objBornRecordManager,int p_intPageIndex,string p_strINPATIENTID,DateTime p_dtINPATIENTDATE,DateTime p_dtOPENDATE,string p_strCREATEID,DateTime p_dtCHILDBIRTHDATE,DateTime p_dtFORECASTDATE,string p_strPREGNANCYNUM)
		{
			try
			{
				if(p_objBornRecordManager==null)
					return null;

				clsBornScheduleRecordInfo m_objBornScheduleRecordInfo=new clsBornScheduleRecordInfo();
				m_objBornScheduleRecordInfo.m_strINPATIENTID=p_strINPATIENTID;
				m_objBornScheduleRecordInfo.m_dtmINPATIENTDATE=p_dtINPATIENTDATE;
				m_objBornScheduleRecordInfo.m_dtmOPENDATE=p_dtOPENDATE;
				m_objBornScheduleRecordInfo.m_strCREATEID=p_strCREATEID;
				m_objBornScheduleRecordInfo.m_strFIRSTPOINT=p_objBornRecordManager.m_strFIRSTPOINT;
				m_objBornScheduleRecordInfo.m_strSECONDPOINT=p_objBornRecordManager.m_strSECONDPOINT;
				m_objBornScheduleRecordInfo.m_strTHREEPOINT=p_objBornRecordManager.m_strTHREEPOINT;
				m_objBornScheduleRecordInfo.m_strFOUTPOINT=p_objBornRecordManager.m_strFOUTPOINT;
				m_objBornScheduleRecordInfo.m_dtmMODIFYDATE=System.DateTime.Now;
				m_objBornScheduleRecordInfo.m_dtmCHILDBIRTHDATE=p_dtCHILDBIRTHDATE;
				m_objBornScheduleRecordInfo.m_dtmFORECASTDATE=p_dtFORECASTDATE;
				m_objBornScheduleRecordInfo.m_strPREGNANCYNUM=p_strPREGNANCYNUM;

				clsBornScheduleEveryDay objBornScheduleEveryDay =(clsBornScheduleEveryDay)p_objBornRecordManager.m_arlBornScheduleEveryDay[p_intPageIndex];
				if(objBornScheduleEveryDay!=null)
				{
					clsBornScheduleEveryHourCol[] objclsBornScheduleEveryHourCol=new clsBornScheduleEveryHourCol[objBornScheduleEveryDay.m_arlBornScheduleEveryHourCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlBornScheduleEveryHourCol.Count;i++)
					{
						objclsBornScheduleEveryHourCol[i]= (clsBornScheduleEveryHourCol)objBornScheduleEveryDay.m_arlBornScheduleEveryHourCol[i];
					}
				
				
					m_objBornScheduleRecordInfo.m_strVENTERPOINTXML=m_strMakeVenterPointXml(objclsBornScheduleEveryHourCol);

					clsCheckTimeCol[] objCheckTimeCol=new clsCheckTimeCol[objBornScheduleEveryDay.m_arlCheckTimeCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlCheckTimeCol.Count;i++)
					{
						objCheckTimeCol[i]= (clsCheckTimeCol)objBornScheduleEveryDay.m_arlCheckTimeCol[i];
					}
					m_objBornScheduleRecordInfo.m_strCHECKVENTERTIMEXML=m_strMakeCheckVenterTimeXML(objCheckTimeCol);

					clsBloodPressureCol[] objBloodPressureCol=new clsBloodPressureCol[objBornScheduleEveryDay.m_arlBloodPressureCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlBloodPressureCol.Count;i++)
					{
						objBloodPressureCol[i]= (clsBloodPressureCol)objBornScheduleEveryDay.m_arlBloodPressureCol[i];
					}
					m_objBornScheduleRecordInfo.m_strBLOODPRESSUREXML=m_strMakeBloodPressureXML(objBloodPressureCol);

					clsEmbryoHeartCol[] objEmbryoHeartCol=new clsEmbryoHeartCol[objBornScheduleEveryDay.m_arlEmbryoHeartCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlEmbryoHeartCol.Count;i++)
					{
						objEmbryoHeartCol[i]= (clsEmbryoHeartCol)objBornScheduleEveryDay.m_arlEmbryoHeartCol[i];
					}
					m_objBornScheduleRecordInfo.m_strEMBRYOHEARTXML=m_strMakeEmbryoHeartXML(objEmbryoHeartCol);

					clsVenterScaleExtendCol[] objVenterScaleExtendCol=new clsVenterScaleExtendCol[objBornScheduleEveryDay.m_arlVenterScaleExtendCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlVenterScaleExtendCol.Count;i++)
					{
						objVenterScaleExtendCol[i]= (clsVenterScaleExtendCol)objBornScheduleEveryDay.m_arlVenterScaleExtendCol[i];
					}
					m_objBornScheduleRecordInfo.m_strVENTERSCALEXML=m_strMakeVenterScaleExtendXML(objVenterScaleExtendCol);

					clsExceptionNoteCol[] objExceptionNoteCol=new clsExceptionNoteCol[objBornScheduleEveryDay.m_arlExceptionNoteCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlExceptionNoteCol.Count;i++)
					{
						objExceptionNoteCol[i]= (clsExceptionNoteCol)objBornScheduleEveryDay.m_arlExceptionNoteCol[i];
					}
					m_objBornScheduleRecordInfo.m_strEXCEPTIONNOTEXML=m_strMakeExceptionNoteXML(objExceptionNoteCol);

					clsDealNoteCol[] objDealNoteCol=new clsDealNoteCol[objBornScheduleEveryDay.m_arlDealNoteCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlDealNoteCol.Count;i++)
					{
						objDealNoteCol[i]= (clsDealNoteCol)objBornScheduleEveryDay.m_arlDealNoteCol[i];
					}
					m_objBornScheduleRecordInfo.m_strDEALNOTEXML=m_strMakeDealNoteXML(objDealNoteCol);

					clsSignNameCol[] objSignNameCol=new clsSignNameCol[objBornScheduleEveryDay.m_arlSignNameCol.Count];
					for(int i=0;i<objBornScheduleEveryDay.m_arlSignNameCol.Count;i++)
					{
						objSignNameCol[i]= (clsSignNameCol)objBornScheduleEveryDay.m_arlSignNameCol[i];
					}
					m_objBornScheduleRecordInfo.m_strSIGNXML=m_strMakeSignNameXML(objSignNameCol);

					return m_objBornScheduleRecordInfo;
				}
				else
					return null;
			}
			catch(Exception ex)
			{ 
				ex.ToString();
				return null;
				
			}
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成画点集XML</returns>
		private string  m_strMakeVenterPointXml(clsBornScheduleEveryHourCol[] p_objBornScheduleEveryHourColArr)
		{
			//string [] strXmlArr = new string[p_objBornScheduleEveryHourColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objBornScheduleEveryHourColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				
				
				m_objXmlWriter.WriteStartElement("clsBornScheduleEveryHourCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objBornScheduleEveryHourColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objBornScheduleEveryHourColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_intVenterValue",p_objBornScheduleEveryHourColArr[i].m_intVenterValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_bnlIsHavePreValue",p_objBornScheduleEveryHourColArr[i].m_bnlIsHavePreValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_strModifyUserID",p_objBornScheduleEveryHourColArr[i].m_strModifyUserID);
				m_objXmlWriter.WriteAttributeString("m_bnlIsDelete",p_objBornScheduleEveryHourColArr[i].m_bnlIsDelete.ToString());
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			

			return strXmlArr;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成画点集XML</returns>
		private string  m_strMakeCheckVenterTimeXML(clsCheckTimeCol[] p_objCheckTimeColArr)
		{
			//string [] strXmlArr = new string[p_objCheckTimeColArr.Length];
			string  strXmlArr=null;

			
			for(int i=0;i<p_objCheckTimeColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("clsCheckTimeCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objCheckTimeColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objCheckTimeColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strCheckTime",p_objCheckTimeColArr[i].m_strCheckTime);
			
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
			
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			
			

			return strXmlArr;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成血压集XML</returns>
		private string  m_strMakeBloodPressureXML(clsBloodPressureCol[] p_objBloodPressureColArr)
		{
			//string [] strXmlArr = new string[p_objBloodPressureColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objBloodPressureColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				
				m_objXmlWriter.WriteStartElement("clsBloodPressureCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objBloodPressureColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objBloodPressureColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strScaleBloodPressureValue",p_objBloodPressureColArr[i].m_strScaleBloodPressureValue);
				m_objXmlWriter.WriteAttributeString("m_strExtendBloodPressureValue",p_objBloodPressureColArr[i].m_strExtendBloodPressureValue);
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
		
			return strXmlArr;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成胎心集XML</returns>
		private string  m_strMakeEmbryoHeartXML(clsEmbryoHeartCol[] p_objEmbryoHeartColArr)
		{
			//string [] strXmlArr = new string[p_objEmbryoHeartColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objEmbryoHeartColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("clsEmbryoHeartCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objEmbryoHeartColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objEmbryoHeartColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strEmbryoHeartValue",p_objEmbryoHeartColArr[i].m_strEmbryoHeartValue);
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
		
			return strXmlArr;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成宫缩集XML</returns>
		private string  m_strMakeVenterScaleExtendXML(clsVenterScaleExtendCol[] p_objVenterScaleExtendColArr)
		{
			//string [] strXmlArr = new string[p_objVenterScaleExtendColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objVenterScaleExtendColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				
				m_objXmlWriter.WriteStartElement("clsVenterScaleExtendCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objVenterScaleExtendColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objVenterScaleExtendColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strScaleVenterValue",p_objVenterScaleExtendColArr[i].m_strScaleVenterValue);
				m_objXmlWriter.WriteAttributeString("m_strExtendVenterValue",p_objVenterScaleExtendColArr[i].m_strExtendVenterValue);
				
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}

		
			return strXmlArr;
		}

		/// <param name="p_objInfo"></param>
		/// <returns>生成宫缩集XML</returns>
		private string  m_strMakeExceptionNoteXML(clsExceptionNoteCol[] p_objExceptionNoteColArr)
		{
			//string [] strXmlArr = new string[p_objExceptionNoteColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objExceptionNoteColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
			
				m_objXmlWriter.WriteStartElement("clsExceptionNoteCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objExceptionNoteColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objExceptionNoteColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strExceptionNoteValue",p_objExceptionNoteColArr[i].m_strExceptionNoteValue);
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			

			return strXmlArr;
		}

		

		
		/// <param name="p_objInfo"></param>
		/// <returns>生成处理记录集XML</returns>
		private string  m_strMakeDealNoteXML(clsDealNoteCol[] p_objDealNoteColArr)
		{
			//string [] strXmlArr = new string[p_objDealNoteColArr.Length];
			string  strXmlArr=null;
			
			for(int i=0;i<p_objDealNoteColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				
				m_objXmlWriter.WriteStartElement("clsDealNoteCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objDealNoteColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objDealNoteColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strDealNoteValue",p_objDealNoteColArr[i].m_strDealNoteValue);
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
				
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
		
			return strXmlArr;
		}


		/// <param name="p_objInfo"></param>
		/// <returns>生成签名集XML</returns>
		private string  m_strMakeSignNameXML(clsSignNameCol[] p_objSignNameColArr)
		{
			//string [] strXmlArr = new string[p_objSignNameColArr.Length];
			string  strXmlArr=null;
		
			for(int i=0;i<p_objSignNameColArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);

				m_objXmlWriter.WriteStartDocument();
				
				m_objXmlWriter.WriteStartElement("clsSignNameCol");

				m_objXmlWriter.WriteAttributeString("m_intHourValue",p_objSignNameColArr[i].m_intHourValue.ToString());
				m_objXmlWriter.WriteAttributeString("m_dtmModifyTime",p_objSignNameColArr[i].m_dtmModifyTime.ToString("yyyy-MM-dd HH:mm:ss"));
				m_objXmlWriter.WriteAttributeString("m_strSignNameID",p_objSignNameColArr[i].m_strSignNameID);
				
				
				m_objXmlWriter.WriteEndElement();
				m_objXmlWriter.WriteEndDocument();
			
				m_objXmlWriter.Flush();

				strXmlArr += System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			

			return strXmlArr;
		}

		//选择当前病人的历史分娩记录日期
		public long  m_GetPatientRecordDate(string p_InPatientID,DateTime p_dtmInPatientDate,out DataTable p_dtbResult)
		{
            clsBornScheduleService m_objBornScheduleService =
                (clsBornScheduleService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBornScheduleService));

            long lngRes = 0;
            try
            {
                lngRes = m_objBornScheduleService.m_GetPatientRecordDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_InPatientID,p_dtmInPatientDate,out p_dtbResult);
            }
            finally
            {
                //m_objBornScheduleService.Dispose();
            }
            return lngRes;
//			p_dtbResult=null;
//			return 0;
		}

		//获取分娩记录
		public clsBornRecordManager[] m_GetPatientBornScheduleRecord(string p_InPatientID,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)//,string lngGetXMLTable)
		{
			//把病人信息xml转换为clsBornRecordManager类
            clsBornRecordManager[] objBornRecordManagerAr = null;

            clsBornScheduleService m_objBornScheduleService =
                (clsBornScheduleService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBornScheduleService));
            
            try
            {
                DataTable dbResult = new DataTable();
                long m_lngRes = m_objBornScheduleService.m_GetPatientBornScheduleRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_InPatientID, p_dtmInPatientDate, p_dtmOpenDate, out dbResult);//
                if (m_lngRes > 0)
                {
                    if (dbResult != null & dbResult.Rows.Count > 0)
                    {
                        objBornRecordManagerAr = new clsBornRecordManager[dbResult.Rows.Count];
                        for (int j = 0; j < dbResult.Rows.Count; j++)
                        {
                            objBornRecordManagerAr[j] = new clsBornRecordManager();
                            objBornRecordManagerAr[j].m_strINPATIENTID = dbResult.Rows[0]["INPATIENTID"].ToString(); //病人ID
                            objBornRecordManagerAr[j].m_dtmINPATIENTDATE = DateTime.Parse(dbResult.Rows[0]["INPATIENTDATE"].ToString()); //入院时间
                            objBornRecordManagerAr[j].m_dtmOPENDATE = DateTime.Parse(dbResult.Rows[0]["OPENDATE"].ToString()); //打开时间
                            objBornRecordManagerAr[j].m_dtmCHILDBIRTHDATE = DateTime.Parse(dbResult.Rows[0]["CHILDBIRTHDATE"].ToString()); //分娩日期
                            objBornRecordManagerAr[j].m_dtmCREATEID = dbResult.Rows[0]["CREATEID"].ToString(); //创建用户ID
                            objBornRecordManagerAr[j].m_dtmMODIFYDATE = DateTime.Parse(dbResult.Rows[0]["MODIFYDATE"].ToString()); //创建用户ID

                            objBornRecordManagerAr[j].m_strFIRSTPOINT = dbResult.Rows[0]["FIRSTPOINT"].ToString(); //第一点
                            objBornRecordManagerAr[j].m_strSECONDPOINT = dbResult.Rows[0]["SECONDPOINT"].ToString(); //第二点
                            objBornRecordManagerAr[j].m_strTHREEPOINT = dbResult.Rows[0]["THREEPOINT"].ToString(); //第三点
                            objBornRecordManagerAr[j].m_strFOUTPOINT = dbResult.Rows[0]["FOUTPOINT"].ToString(); //第四点
                            objBornRecordManagerAr[j].m_strPREGNANCYNUM = dbResult.Rows[0]["PREGNANCYNUM"].ToString(); //孕产次
                            objBornRecordManagerAr[j].m_dtmFORECASTDATE = DateTime.Parse(dbResult.Rows[0]["FORECASTDATE"].ToString()); //预产期



                            for (int i = 0; i < dbResult.Rows.Count; i++)
                            {
                                clsBornScheduleEveryDay objBornScheduleEveryDay = new clsBornScheduleEveryDay(DateTime.Parse(dbResult.Rows[i]["OPENDATE"].ToString())); //打开时间作为记录时间;

                                objBornScheduleEveryDay.m_arlBornScheduleEveryHourCol = m_arlChangeXmlToBornScheduleEveryHourCoL(dbResult.Rows[i]["VENTERPOINTXML"].ToString());	//宫口点转化为每小时画点集类
                                objBornScheduleEveryDay.m_arlCheckTimeCol = m_arlChangeXmlToCheckTimeCoL(dbResult.Rows[i]["CHECKVENTERTIMEXML"].ToString());	//把检查时间集转化为clsCheckTimeCol集合
                                objBornScheduleEveryDay.m_arlBloodPressureCol = m_arlChangeXmlToBloodPressureCoL(dbResult.Rows[i]["BLOODPRESSUREXML"].ToString());	//把检查时间集转化为clsCheckTimeCol集合
                                objBornScheduleEveryDay.m_arlEmbryoHeartCol = m_arlChangeXmlToEmbryoHeartCoL(dbResult.Rows[i]["EMBRYOHEARTXML"].ToString());	//把胎心集转化为clsEmbryoHeartCol集合
                                objBornScheduleEveryDay.m_arlVenterScaleExtendCol = m_arlChangeXmlToVenterScaleExtendCoL(dbResult.Rows[i]["VENTERSCALEXML"].ToString());	//把宫缩集转化为clsVenterScaleExtendCol集合
                                objBornScheduleEveryDay.m_arlExceptionNoteCol = m_arlChangeXmlToExceptionNoteCol(dbResult.Rows[i]["EXCEPTIONNOTEXML"].ToString());	//把异常情况集转化为clsExceptionNoteCol集合
                                objBornScheduleEveryDay.m_arlDealNoteCol = m_arlChangeXmlToDealNoteCoL(dbResult.Rows[i]["DEALNOTEXML"].ToString());	//把处理记录集转化为clsDealNoteCol集合
                                objBornScheduleEveryDay.m_arlSignNameCol = m_arlChangeXmlToSignNameCoL(dbResult.Rows[i]["SIGNXML"].ToString());	//把签名集转化为clsSignNameCol集合
                                objBornScheduleEveryDay.m_dtmRecordDate = DateTime.Parse(dbResult.Rows[i]["OPENDATE"].ToString());	//每天的记录日期

                                objBornRecordManagerAr[j].m_arlBornScheduleEveryDay.Add(objBornScheduleEveryDay);
                            }
                        }
                    }
                }
            }
            finally
            {
                //m_objBornScheduleService.Dispose();
            }
            return objBornRecordManagerAr;
		}

		//把产妇每小时画点集转化为m_arlBornScheduleEveryHourCoL集合
		private ArrayList m_arlChangeXmlToBornScheduleEveryHourCoL(string strEveryHourXML)
		{
			if(strEveryHourXML == null)
				return null;	

			ArrayList objEveryHourArr=new ArrayList();

			m_objXmlReader = new XmlTextReader(strEveryHourXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsBornScheduleEveryHourCol objEveryHour = new clsBornScheduleEveryHourCol();
							objEveryHour.m_intHourValue = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objEveryHour.m_intVenterValue =int.Parse(m_objXmlReader.GetAttribute("m_intVenterValue"));
							objEveryHour.m_bnlIsHavePreValue = bool.Parse(m_objXmlReader.GetAttribute("m_bnlIsHavePreValue"));
							objEveryHour.m_strModifyUserID =m_objXmlReader.GetAttribute("m_strModifyUserID");
							objEveryHour.m_dtmModifyTime = DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objEveryHour.m_bnlIsDelete =bool.Parse(m_objXmlReader.GetAttribute("m_bnlIsDelete"));
							objEveryHourArr.Add(objEveryHour);
						}
						break;
				}
			}

			return objEveryHourArr;
		}

		//把检查时间集转化为clsCheckTimeCol集合
		private ArrayList m_arlChangeXmlToCheckTimeCoL(string strCheckTimeXML)
		{
			if(strCheckTimeXML == null)
				return null;	

			ArrayList objCheckTimeArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strCheckTimeXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsCheckTimeCol objCheckTime = new clsCheckTimeCol();
							objCheckTime.m_intHourValue = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objCheckTime.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objCheckTime.m_strCheckTime = m_objXmlReader.GetAttribute("m_strCheckTime");
							objCheckTimeArr.Add(objCheckTime);
						}
						break;
				}
			}
			
			return objCheckTimeArr;
		}

		//把血压转化为clsBloodPressureCol集合
		private ArrayList m_arlChangeXmlToBloodPressureCoL(string strBloodPressureXML)
		{
			if(strBloodPressureXML == null)
			return null;	

			ArrayList objBloodPressureArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strBloodPressureXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsBloodPressureCol objBloodPressure = new clsBloodPressureCol();
							objBloodPressure.m_intHourValue  = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objBloodPressure.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objBloodPressure.m_strScaleBloodPressureValue = m_objXmlReader.GetAttribute("m_strScaleBloodPressureValue");
							objBloodPressure.m_strExtendBloodPressureValue  = m_objXmlReader.GetAttribute("m_strExtendBloodPressureValue");
							objBloodPressureArr.Add(objBloodPressure);
						}
						break;
				}
			}

			
			return objBloodPressureArr;
		}

		//把胎心集转化为clsEmbryoHeartCol集合
		private ArrayList m_arlChangeXmlToEmbryoHeartCoL(string strEmbryoHeartXML)
		{
			if(strEmbryoHeartXML == null)
				return null;	

			ArrayList objEmbryoHeartArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strEmbryoHeartXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsEmbryoHeartCol objEmbryoHeart = new clsEmbryoHeartCol();
							objEmbryoHeart.m_intHourValue = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objEmbryoHeart.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objEmbryoHeart.m_strEmbryoHeartValue = m_objXmlReader.GetAttribute("m_strEmbryoHeartValue");
							objEmbryoHeartArr.Add(objEmbryoHeart);
						}
						break;
				}
			}

			
			return objEmbryoHeartArr;
		}

		//把宫缩集转化为clsVenterScaleExtendCol集合
		private ArrayList m_arlChangeXmlToVenterScaleExtendCoL(string strVenterScaleExtendXML)
		{
			if(strVenterScaleExtendXML == null)
				return null;	

			ArrayList objVenterScaleExtendArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strVenterScaleExtendXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsVenterScaleExtendCol objVenterScaleExtend = new clsVenterScaleExtendCol();
							objVenterScaleExtend.m_intHourValue = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objVenterScaleExtend.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objVenterScaleExtend.m_strScaleVenterValue = m_objXmlReader.GetAttribute("m_strScaleVenterValue");
							objVenterScaleExtend.m_strExtendVenterValue = m_objXmlReader.GetAttribute("m_strExtendVenterValue");
							objVenterScaleExtendArr.Add(objVenterScaleExtend);
						}
						break;
				}
			}

			return objVenterScaleExtendArr;
		}

		//把异常情况集转化为clsExceptionNoteCol集合
		private ArrayList m_arlChangeXmlToExceptionNoteCol(string strExceptionNoteXML)
		{
			if(strExceptionNoteXML == null)
				return null;	

			ArrayList objExceptionNoteArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strExceptionNoteXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsExceptionNoteCol objExceptionNote = new clsExceptionNoteCol();
							objExceptionNote.m_intHourValue  = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objExceptionNote.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objExceptionNote.m_strExceptionNoteValue= m_objXmlReader.GetAttribute("m_strExceptionNoteValue");
							
							objExceptionNoteArr.Add(objExceptionNote);
						}
						break;
				}
			}

			
			return objExceptionNoteArr;
		}

		//把处理记录集转化为clsDealNoteCol集合
		private ArrayList m_arlChangeXmlToDealNoteCoL(string strDealNoteXML)
		{
			if(strDealNoteXML == null)
				return null;	

			ArrayList objDealNoteArr=new ArrayList();
			m_objXmlReader = new XmlTextReader(strDealNoteXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsDealNoteCol objDealNote = new clsDealNoteCol();
							objDealNote.m_intHourValue  = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objDealNote.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objDealNote.m_strDealNoteValue = m_objXmlReader.GetAttribute("m_strDealNoteValue");
							
							objDealNoteArr.Add(objDealNote);
						}
						break;
				}
			}

		
			return objDealNoteArr;
		}


		//把签名集转化为clsSignNameCol集合
		private ArrayList m_arlChangeXmlToSignNameCoL(string strSignNameXML)
		{
			if(strSignNameXML == null)
				return null;	

			ArrayList objSignNameArr=new ArrayList();

			m_objXmlReader = new XmlTextReader(strSignNameXML,XmlNodeType.Element,m_objXmlParser);
			m_objXmlReader.WhitespaceHandling = WhitespaceHandling.None;		
			while(m_objXmlReader.Read())
			{
				switch(m_objXmlReader.NodeType)
				{
					case XmlNodeType.Element://
						if(m_objXmlReader.HasAttributes)
						{	
							clsSignNameCol objSignName = new clsSignNameCol();
							objSignName.m_intHourValue  = int.Parse(m_objXmlReader.GetAttribute("m_intHourValue"));
							objSignName.m_dtmModifyTime =DateTime.Parse(m_objXmlReader.GetAttribute("m_dtmModifyTime"));
							objSignName.m_strSignNameID = m_objXmlReader.GetAttribute("m_strSignNameID");
							
							objSignNameArr.Add(objSignName);
						}
						break;
				}
			}

//			XmlDocument objDoc = new XmlDocument();			
//
//			objDoc.LoadXml(strSignNameXML);
//			for(int i=0;i<objDoc.ChildNodes.Count;i++)
//			{
//				clsSignNameCol objSignName = new clsSignNameCol();
//				objSignName.m_intHourValue = int.Parse(objDoc.ChildNodes[i].Attributes["m_intHourValue"].Value);
//				objSignName.m_dtmModifyTime = DateTime.Parse(objDoc.ChildNodes[i].Attributes["m_dtmModifyTime"].Value);
//				objSignName.m_strSignNameID =objDoc.ChildNodes[i].Attributes["m_strSignNameID"].Value;

//				clsSignNameCol objSignName = new clsSignNameCol();
//				objSignName.m_intHourValue = int.Parse(objDoc.DocumentElement.ChildNodes[i].Attributes["m_intHourValue"].Value);
//				objSignName.m_dtmModifyTime = DateTime.Parse(objDoc.DocumentElement.ChildNodes[i].Attributes["m_dtmModifyTime"].Value);
//				objSignName.m_strSignNameID =objDoc.DocumentElement.ChildNodes[i].Attributes["m_strSignNameID"].Value;

//				objSignNameArr.Add(objSignName);
//			}
			return objSignNameArr;
		}	



	}
}
