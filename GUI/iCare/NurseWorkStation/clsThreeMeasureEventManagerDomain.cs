using System;
using System.Xml;
using System.IO;
using System.Text;
using iCare;
using com.digitalwave.ThreeMeasureEventManagerService;

namespace HRP
{
	/// <summary>
	/// 领域层

	/// </summary>
	public class clsThreeMeasureEventManagerDomain
	{ 
		/// <summary>
		/// 仪器管理的中间层
		/// </summary>
        //private clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ;

		/// <summary>
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

		/// <summary>
		/// 构造函数

		/// </summary>
		public clsThreeMeasureEventManagerDomain()
		{
            //m_objThreeMeasureEventManagerServ = new clsThreeMeasureEventManagerService();

			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符


			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		}	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <param name="p_strOperatorID"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeOldXml(clsThreeMeasureEventInfo p_objInfo,string p_strOperatorID)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("ThreeMeasureEvent");

			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTID",p_objInfo.m_strThreeMeasureEventID);
			//			m_objXmlWriter.WriteAttributeString("BEGINEVENTDATE",p_objInfo.m_strBeginEventDate);
			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTNAME",p_objInfo.m_strThreeMeasureEventName);
			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTFLAG",p_objInfo.m_strThreeMeasureEventFlag);
			//			m_objXmlWriter.WriteAttributeString("STAUTS",p_objInfo.m_strStauts);
			//			m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE",p_objInfo.m_strDeActivedDate);
			//			m_objXmlWriter.WriteAttributeString("OPERATORID",p_objInfo.m_strOperatorID);
			
			m_objXmlWriter.WriteAttributeString("STATUS","1");
			m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objXmlWriter.WriteAttributeString("OPERATORID",p_strOperatorID);

			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewXml(clsThreeMeasureEventInfo p_objInfo)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("ThreeMeasureEvent");

			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTID",p_objInfo.m_strThreeMeasureEventID);
			//			m_objXmlWriter.WriteAttributeString("BEGINEVENTDATE",p_objInfo.m_strBeginEventDate);
			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTNAME",p_objInfo.m_strThreeMeasureEventName);
			//			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTFLAG",p_objInfo.m_strThreeMeasureEventFlag);
			//			m_objXmlWriter.WriteAttributeString("STAUTS",p_objInfo.m_strStauts);
			//			m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE",p_objInfo.m_strDeActivedDate);
			//			m_objXmlWriter.WriteAttributeString("OPERATORID",p_objInfo.m_strOperatorID);
			
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>
		/// 操作结果。

		/// 0，失败。

		/// 1，成功。

		/// </returns>
		public long m_lngAddNew(clsThreeMeasureEventInfo p_objInfo)
		{
            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_strMakeNewXml(p_objInfo));
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objOldInfo"></param>
		/// <param name="p_objNewInfo"></param>
		/// <param name="p_strOperatorID">操作者ID</param>
		/// <returns>
		/// 操作结果。

		/// 0，失败。

		/// 1，成功。

		/// </returns>
		public long m_lngModify(clsThreeMeasureEventInfo p_objOldInfo,clsThreeMeasureEventInfo p_objNewInfo,string p_strOperatorID)
		{
			string strOldXml = m_strMakeOldXml(p_objOldInfo,p_strOperatorID);
			string strNewXml = m_strMakeNewXml(p_objNewInfo);

            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strOldXml,strNewXml);
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
            return lngRes;
		}	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objOldInfo"></param>
		/// <param name="p_strOperatorID">操作者ID</param>
		/// <returns>
		/// 操作结果。

		/// 0，失败。

		/// 1，成功。

		/// </returns>
		public long m_lngDelete(clsThreeMeasureEventInfo p_objOldInfo,string p_strOperatorID)
		{
            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_strMakeOldXml(p_objOldInfo,p_strOperatorID));
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// </returns>
		public clsThreeMeasureEventInfo [] m_objGetThreeMeasureEventInfoArr()
		{
			string strXML = "";
			int intRows = 0;

            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngGetAllEvent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,ref strXML,ref intRows);
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
			clsThreeMeasureEventInfo[] objInfoArr = null;

			if(lngRes > 0 && intRows >0)
			{
				objInfoArr = new clsThreeMeasureEventInfo[intRows];

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
								objInfoArr[intIndex] = new clsThreeMeasureEventInfo();
								objInfoArr[intIndex].m_strThreeMeasureEventID = objReader.GetAttribute("THREEMEASUREEVENTID");
								objInfoArr[intIndex].m_strBeginEventDate = objReader.GetAttribute("BEGINEVENTDATE");
								objInfoArr[intIndex].m_strThreeMeasureEventName = objReader.GetAttribute("THREEMEASUREEVENTNAME").Replace ("き","\'");
								objInfoArr[intIndex].m_strThreeMeasureEventFlag = objReader.GetAttribute("THREEMEASUREEVENTFLAG");
								objInfoArr[intIndex].m_strStatus = objReader.GetAttribute("STATUS");
								objInfoArr[intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE");
								objInfoArr[intIndex].m_strOperatorID = objReader.GetAttribute("OPERATORID");
								
								intIndex++;
							}
							break;
					}
				}
			}
			else
			{
				objInfoArr = new clsThreeMeasureEventInfo[0];
			}

			return objInfoArr;
		}

		/// <summary>
		/// 
		/// </summary>
		public void m_mthInitThreeMeasureEventInfo(ref clsThreeMeasureEventInfo p_objInfo)
		{
			string strXML = "";
			int intRows = 0;

            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngGetAllEvent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,ref strXML,ref intRows);
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
			if(lngRes > 0 && intRows == 1)
			{
				XmlDocument objXMLDoc = new XmlDocument();
				objXMLDoc.LoadXml(strXML);				

				//				p_objInfo.m_strThreeMeasureEventID = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTID"].Value;
				//				p_objInfo.m_strBeginEventDate = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["BEGINEVENTDATE"].Value;
				//				p_objInfo.m_strThreeMeasureEventName = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTNAME"].Value;
				//				p_objInfo.m_strThreeMeasureEventFlag = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTFLAG"].Value;
				//				p_objInfo.m_strStauts = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["STAUTS"].Value;
				//				p_objInfo.m_strDeActivedDate = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["DEACTIVEDDATE"].Value;
				//				p_objInfo.m_strOperatorID = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["OPERATORID"].Value;

				
			}			
		}


	}	

	#region 交互数据用的类

	/// <summary>
	/// 
	/// </summary>
	public class clsThreeMeasureEventInfo
	{
		/// <summary>
		/// 
		/// </summary>
		public string m_strThreeMeasureEventID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strBeginEventDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strThreeMeasureEventName;

		/// <summary>
		/// 
		/// </summary>
		public string m_strThreeMeasureEventFlag;

		/// <summary>
		/// 
		/// </summary>
		public string m_strStatus;

		/// <summary>
		/// 
		/// </summary>
		public string m_strDeActivedDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strOperatorID;

		public override string ToString()
		{
			return m_strThreeMeasureEventName;
		}
	}
	#endregion
}
