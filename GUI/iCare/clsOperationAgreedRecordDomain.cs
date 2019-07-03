using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.OperationAgreedRecordServ;
using com.digitalwave.SPECTCheckOrderServ;
using System.Text;

namespace iCare
{
	/// <summary>
	/// Summary description for clsOperationAgreedRecordDomain.
	/// </summary>
	public class clsOperationAgreedRecordDomain
	{
		/// <summary>
		/// 伏撹Xml議産喝
		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 伏撹Xml議垢醤
		/// </summary>
	
		private XmlTextWriter m_objXmlWriter;
		///  <summary>
		/// 響函Xml垢醤補秘歌方		
		/// </summary>
		private XmlParserContext m_objXmlParser;
		
		public clsOperationAgreedRecordDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//賠腎圻栖議忖憲

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		}

		public long lngSave(clsOperationAgreed m_objOperationAgreedContent)
		{
            clsOperationAgreedRecordServ m_objService =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            long lngSucceed = 0;
            try
            {
                string strXML = this.strSaveXML(m_objOperationAgreedContent);
                lngSucceed = m_objService.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strXML);
            }
            finally
            {
                ////m_objService.Dispose();
            }
			return lngSucceed;
		}
		/// <summary>
		/// 侭嗤議揖吭慕扮寂
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;
			string strXml = "";
			int intRows = 0;

            clsOperationAgreedRecordServ m_objService =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, ref strXml, ref intRows);
		    }
            finally
            {
                ////m_objService.Dispose();
            }
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
			return dtmCreateRecordDateArr ;
		}

	
		private string strSaveXML(clsOperationAgreed  m_objOperationAgreedContent)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objOperationAgreedContent.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objOperationAgreedContent.strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", m_objOperationAgreedContent.strCreateDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", m_objOperationAgreedContent.strIfConfirm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", m_objOperationAgreedContent.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", m_objOperationAgreedContent.strCreateUserID.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("BEFOREDISGONE", m_objOperationAgreedContent.strBeforeDisgone.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_1", m_objOperationAgreedContent.strAuris_1.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_2", m_objOperationAgreedContent.strAuris_2.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_3", m_objOperationAgreedContent.strAuris_3.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_4", m_objOperationAgreedContent.strAuris_4.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_5", m_objOperationAgreedContent.strAuris_5.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_6", m_objOperationAgreedContent.strAuris_6.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_7", m_objOperationAgreedContent.strAuris_7.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_8", m_objOperationAgreedContent.strAuris_8.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_9", m_objOperationAgreedContent.strAuris_9.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_10", m_objOperationAgreedContent.strAuris_10.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_11", m_objOperationAgreedContent.strAuris_11.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_12", m_objOperationAgreedContent.strAuris_12.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_13", m_objOperationAgreedContent.strAuris_13.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_14", m_objOperationAgreedContent.strAuris_14.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_15", m_objOperationAgreedContent.strAuris_15.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_16", m_objOperationAgreedContent.strAuris_16.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_17", m_objOperationAgreedContent.strAuris_17.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_18", m_objOperationAgreedContent.strAuris_18.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_19", m_objOperationAgreedContent.strAuris_19.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_20", m_objOperationAgreedContent.strAuris_20.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_21", m_objOperationAgreedContent.strAuris_21.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_22", m_objOperationAgreedContent.strAuris_22.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_23", m_objOperationAgreedContent.strAuris_23.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_24", m_objOperationAgreedContent.strAuris_24.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_25", m_objOperationAgreedContent.strAuris_25.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_26", m_objOperationAgreedContent.strAuris_26.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_27", m_objOperationAgreedContent.strAuris_27.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_28", m_objOperationAgreedContent.strAuris_28.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_29", m_objOperationAgreedContent.strAuris_29.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_30", m_objOperationAgreedContent.strAuris_30.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_31", m_objOperationAgreedContent.strAuris_31.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_32", m_objOperationAgreedContent.strAuris_32.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_33", m_objOperationAgreedContent.strAuris_33.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_34", m_objOperationAgreedContent.strAuris_34.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_35", m_objOperationAgreedContent.strAuris_35.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("AURIS_36", m_objOperationAgreedContent.strAuris_36.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_37", m_objOperationAgreedContent.strAuris_37.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AURIS_38", m_objOperationAgreedContent.strAuris_38.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_1", m_objOperationAgreedContent.strNose_1.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_2", m_objOperationAgreedContent.strNose_2.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_3", m_objOperationAgreedContent.strNose_3.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_4", m_objOperationAgreedContent.strNose_4.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_5", m_objOperationAgreedContent.strNose_5.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_6", m_objOperationAgreedContent.strNose_6.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_7", m_objOperationAgreedContent.strNose_7.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_8", m_objOperationAgreedContent.strNose_8.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_9", m_objOperationAgreedContent.strNose_9.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_10", m_objOperationAgreedContent.strNose_10.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_11", m_objOperationAgreedContent.strNose_11.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_12", m_objOperationAgreedContent.strNose_12.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_13", m_objOperationAgreedContent.strNose_13.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_14", m_objOperationAgreedContent.strNose_14.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_15", m_objOperationAgreedContent.strNose_15.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_16", m_objOperationAgreedContent.strNose_16.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_17", m_objOperationAgreedContent.strNose_17.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_18", m_objOperationAgreedContent.strNose_18.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_19", m_objOperationAgreedContent.strNose_19.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_20", m_objOperationAgreedContent.strNose_20.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_21", m_objOperationAgreedContent.strNose_21.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_22", m_objOperationAgreedContent.strNose_22.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_23", m_objOperationAgreedContent.strNose_23.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_24", m_objOperationAgreedContent.strNose_24.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_25", m_objOperationAgreedContent.strNose_25.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_26", m_objOperationAgreedContent.strNose_26.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_27", m_objOperationAgreedContent.strNose_27.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("NOSE_28", m_objOperationAgreedContent.strNose_28.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_29", m_objOperationAgreedContent.strNose_29.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_30", m_objOperationAgreedContent.strNose_30.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE_31", m_objOperationAgreedContent.strNose_31.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_1", m_objOperationAgreedContent.strFauces_1.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_2", m_objOperationAgreedContent.strFauces_2.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_3", m_objOperationAgreedContent.strFauces_3.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_4", m_objOperationAgreedContent.strFauces_4.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_5", m_objOperationAgreedContent.strFauces_5.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_6", m_objOperationAgreedContent.strFauces_6.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_7", m_objOperationAgreedContent.strFauces_7.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_8", m_objOperationAgreedContent.strFauces_8.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_9", m_objOperationAgreedContent.strFauces_9.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_10", m_objOperationAgreedContent.strFauces_10.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_11", m_objOperationAgreedContent.strFauces_11.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_12", m_objOperationAgreedContent.strFauces_12.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_13", m_objOperationAgreedContent.strFauces_13.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_14", m_objOperationAgreedContent.strFauces_14.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_15", m_objOperationAgreedContent.strFauces_15.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_16", m_objOperationAgreedContent.strFauces_16.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_17", m_objOperationAgreedContent.strFauces_17.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_18", m_objOperationAgreedContent.strFauces_18.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_19", m_objOperationAgreedContent.strFauces_19.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_20", m_objOperationAgreedContent.strFauces_20.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_21", m_objOperationAgreedContent.strFauces_21.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("FAUCES_22", m_objOperationAgreedContent.strFauces_22.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_23", m_objOperationAgreedContent.strFauces_23.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FAUCES_24", m_objOperationAgreedContent.strFauces_24.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_1", m_objOperationAgreedContent.strHead_1.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_2", m_objOperationAgreedContent.strHead_2.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_3", m_objOperationAgreedContent.strHead_3.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_4", m_objOperationAgreedContent.strHead_4.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_5", m_objOperationAgreedContent.strHead_5.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_6", m_objOperationAgreedContent.strHead_6.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_7", m_objOperationAgreedContent.strHead_7.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_8", m_objOperationAgreedContent.strHead_8.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_9", m_objOperationAgreedContent.strHead_9.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_10", m_objOperationAgreedContent.strHead_10.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_11", m_objOperationAgreedContent.strHead_11.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_12", m_objOperationAgreedContent.strHead_12.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_13", m_objOperationAgreedContent.strHead_13.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_14", m_objOperationAgreedContent.strHead_14.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_15", m_objOperationAgreedContent.strHead_15.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEAD_16", m_objOperationAgreedContent.strHead_16.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_17", m_objOperationAgreedContent.strHead_17.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEAD_18", m_objOperationAgreedContent.strHead_18.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_1", m_objOperationAgreedContent.strLarynxGullet_1.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_2", m_objOperationAgreedContent.strLarynxGullet_2.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_3", m_objOperationAgreedContent.strLarynxGullet_3.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_4", m_objOperationAgreedContent.strLarynxGullet_4.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_5", m_objOperationAgreedContent.strLarynxGullet_5.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_6", m_objOperationAgreedContent.strLarynxGullet_6.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_7", m_objOperationAgreedContent.strLarynxGullet_7.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_8", m_objOperationAgreedContent.strLarynxGullet_8.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_9", m_objOperationAgreedContent.strLarynxGullet_9.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_10", m_objOperationAgreedContent.strLarynxGullet_10.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_11", m_objOperationAgreedContent.strLarynxGullet_11.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_12", m_objOperationAgreedContent.strLarynxGullet_12.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_13", m_objOperationAgreedContent.strLarynxGullet_13.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_14", m_objOperationAgreedContent.strLarynxGullet_14.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_15", m_objOperationAgreedContent.strLarynxGullet_15.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_16", m_objOperationAgreedContent.strLarynxGullet_16.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_17", m_objOperationAgreedContent.strLarynxGullet_17.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_18", m_objOperationAgreedContent.strLarynxGullet_18.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_19", m_objOperationAgreedContent.strLarynxGullet_19.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_20", m_objOperationAgreedContent.strLarynxGullet_20.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LARYNXGULLET_21", m_objOperationAgreedContent.strLarynxGullet_21.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("OPERATIONNAME", m_objOperationAgreedContent.strOperationName.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RELATION", m_objOperationAgreedContent.strRelation.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TALKDOC", m_objOperationAgreedContent.strTalkDoc.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("WRITER", m_objOperationAgreedContent.strSignatory.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RELATIONSUFFERER", m_objOperationAgreedContent.strRelationSufferer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RELATIONID", m_objOperationAgreedContent.strRelationID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHONE", m_objOperationAgreedContent.strPhone.Replace('\'','き'));
			

			


			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}

		public clsOperationAgreed objDisplay(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			string strXML="";
			int intRows=0;

			clsOperationAgreed m_objDisplay =new clsOperationAgreed();

            clsOperationAgreedRecordServ m_objService =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.lngSelectNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref strXML, ref intRows);
            }
            finally
            {
                ////m_objService.Dispose();
            }
			if(intRows>0)
			{
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								m_objDisplay.strInPatientID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('き','\'');
								m_objDisplay.strInPatientDate=objReader.GetAttribute("INPATIENTDATE").ToString().Replace ('き','\'');
								m_objDisplay.strCreateDate=objReader.GetAttribute("CREATEDATE").ToString().Replace ('き','\'');
								m_objDisplay.strCreateUserID=objReader.GetAttribute("CREATEUSERID").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_1=objReader.GetAttribute("AURIS_1").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_2=objReader.GetAttribute("AURIS_2").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_3=objReader.GetAttribute("AURIS_3").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_4=objReader.GetAttribute("AURIS_4").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_5=objReader.GetAttribute("AURIS_5").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_6=objReader.GetAttribute("AURIS_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_7=objReader.GetAttribute("AURIS_7").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_8=objReader.GetAttribute("AURIS_8").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_9=objReader.GetAttribute("AURIS_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_10=objReader.GetAttribute("AURIS_10").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_11=objReader.GetAttribute("AURIS_11").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_12=objReader.GetAttribute("AURIS_12").ToString().Replace ('き','\'');

								m_objDisplay.strAuris_13=objReader.GetAttribute("AURIS_13").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_14=objReader.GetAttribute("AURIS_14").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_15=objReader.GetAttribute("AURIS_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_16=objReader.GetAttribute("AURIS_16").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_17=objReader.GetAttribute("AURIS_17").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_18=objReader.GetAttribute("AURIS_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_19=objReader.GetAttribute("AURIS_19").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_20=objReader.GetAttribute("AURIS_20").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_21=objReader.GetAttribute("AURIS_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_22=objReader.GetAttribute("AURIS_22").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_23=objReader.GetAttribute("AURIS_23").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_24=objReader.GetAttribute("AURIS_24").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_25=objReader.GetAttribute("AURIS_25").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_26=objReader.GetAttribute("AURIS_26").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_27=objReader.GetAttribute("AURIS_27").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_28=objReader.GetAttribute("AURIS_28").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_29=objReader.GetAttribute("AURIS_29").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_30=objReader.GetAttribute("AURIS_30").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_31=objReader.GetAttribute("AURIS_31").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_32=objReader.GetAttribute("AURIS_32").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_33=objReader.GetAttribute("AURIS_33").ToString().Replace ('き','\'');

								m_objDisplay.strAuris_34=objReader.GetAttribute("AURIS_34").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_35=objReader.GetAttribute("AURIS_35").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_36=objReader.GetAttribute("AURIS_36").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_37=objReader.GetAttribute("AURIS_37").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_38=objReader.GetAttribute("AURIS_38").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_1=objReader.GetAttribute("FAUCES_1").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_2=objReader.GetAttribute("FAUCES_2").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_3=objReader.GetAttribute("FAUCES_3").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_4=objReader.GetAttribute("FAUCES_4").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_5=objReader.GetAttribute("FAUCES_5").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_6=objReader.GetAttribute("FAUCES_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_7=objReader.GetAttribute("FAUCES_7").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_8=objReader.GetAttribute("FAUCES_8").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_9=objReader.GetAttribute("FAUCES_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_10=objReader.GetAttribute("FAUCES_10").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_11=objReader.GetAttribute("FAUCES_11").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_12=objReader.GetAttribute("FAUCES_12").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_13=objReader.GetAttribute("FAUCES_13").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_14=objReader.GetAttribute("FAUCES_14").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_15=objReader.GetAttribute("FAUCES_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_16=objReader.GetAttribute("FAUCES_16").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_17=objReader.GetAttribute("FAUCES_17").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_18=objReader.GetAttribute("FAUCES_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_19=objReader.GetAttribute("FAUCES_19").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_20=objReader.GetAttribute("FAUCES_20").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_21=objReader.GetAttribute("FAUCES_21").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_22=objReader.GetAttribute("FAUCES_22").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_23=objReader.GetAttribute("FAUCES_23").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_24=objReader.GetAttribute("FAUCES_24").ToString().Replace ('き','\'');

								m_objDisplay.strHead_1=objReader.GetAttribute("HEAD_1").ToString().Replace ('き','\'');
								m_objDisplay.strHead_2=objReader.GetAttribute("HEAD_2").ToString().Replace ('き','\'');
								m_objDisplay.strHead_3=objReader.GetAttribute("HEAD_3").ToString().Replace ('き','\'');

								m_objDisplay.strHead_4=objReader.GetAttribute("HEAD_4").ToString().Replace ('き','\'');
								m_objDisplay.strHead_5=objReader.GetAttribute("HEAD_5").ToString().Replace ('き','\'');
								m_objDisplay.strHead_6=objReader.GetAttribute("HEAD_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_7=objReader.GetAttribute("HEAD_7").ToString().Replace ('き','\'');
								m_objDisplay.strHead_8=objReader.GetAttribute("HEAD_8").ToString().Replace ('き','\'');
								m_objDisplay.strHead_9=objReader.GetAttribute("HEAD_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_10=objReader.GetAttribute("HEAD_10").ToString().Replace ('き','\'');
								m_objDisplay.strHead_11=objReader.GetAttribute("HEAD_11").ToString().Replace ('き','\'');
								m_objDisplay.strHead_12=objReader.GetAttribute("HEAD_12").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_13=objReader.GetAttribute("HEAD_13").ToString().Replace ('き','\'');
								m_objDisplay.strHead_14=objReader.GetAttribute("HEAD_14").ToString().Replace ('き','\'');
								m_objDisplay.strHead_15=objReader.GetAttribute("HEAD_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_16=objReader.GetAttribute("HEAD_16").ToString().Replace ('き','\'');
								m_objDisplay.strHead_17=objReader.GetAttribute("HEAD_17").ToString().Replace ('き','\'');
								m_objDisplay.strHead_18=objReader.GetAttribute("HEAD_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_1=objReader.GetAttribute("NOSE_1").ToString().Replace ('き','\'');
								m_objDisplay.strNose_2=objReader.GetAttribute("NOSE_2").ToString().Replace ('き','\'');
								m_objDisplay.strNose_3=objReader.GetAttribute("NOSE_3").ToString().Replace ('き','\'');

								m_objDisplay.strNose_4=objReader.GetAttribute("NOSE_4").ToString().Replace ('き','\'');
								m_objDisplay.strNose_5=objReader.GetAttribute("NOSE_5").ToString().Replace ('き','\'');
								m_objDisplay.strNose_6=objReader.GetAttribute("NOSE_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_7=objReader.GetAttribute("NOSE_7").ToString().Replace ('き','\'');
								m_objDisplay.strNose_8=objReader.GetAttribute("NOSE_8").ToString().Replace ('き','\'');
								m_objDisplay.strNose_9=objReader.GetAttribute("NOSE_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_10=objReader.GetAttribute("NOSE_10").ToString().Replace ('き','\'');
								m_objDisplay.strNose_11=objReader.GetAttribute("NOSE_11").ToString().Replace ('き','\'');
								m_objDisplay.strNose_12=objReader.GetAttribute("NOSE_12").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_13=objReader.GetAttribute("NOSE_13").ToString().Replace ('き','\'');
								m_objDisplay.strNose_14=objReader.GetAttribute("NOSE_14").ToString().Replace ('き','\'');
								m_objDisplay.strNose_15=objReader.GetAttribute("NOSE_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_16=objReader.GetAttribute("NOSE_16").ToString().Replace ('き','\'');
								m_objDisplay.strNose_17=objReader.GetAttribute("NOSE_17").ToString().Replace ('き','\'');
								m_objDisplay.strNose_18=objReader.GetAttribute("NOSE_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_19=objReader.GetAttribute("NOSE_19").ToString().Replace ('き','\'');
								m_objDisplay.strNose_20=objReader.GetAttribute("NOSE_20").ToString().Replace ('き','\'');
								m_objDisplay.strNose_21=objReader.GetAttribute("NOSE_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_22=objReader.GetAttribute("NOSE_22").ToString().Replace ('き','\'');
								m_objDisplay.strNose_23=objReader.GetAttribute("NOSE_23").ToString().Replace ('き','\'');
								m_objDisplay.strNose_24=objReader.GetAttribute("NOSE_24").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_25=objReader.GetAttribute("NOSE_25").ToString().Replace ('き','\'');
								m_objDisplay.strNose_26=objReader.GetAttribute("NOSE_26").ToString().Replace ('き','\'');
								m_objDisplay.strNose_27=objReader.GetAttribute("NOSE_27").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_28=objReader.GetAttribute("NOSE_28").ToString().Replace ('き','\'');
								m_objDisplay.strNose_29=objReader.GetAttribute("NOSE_29").ToString().Replace ('き','\'');
								m_objDisplay.strNose_30=objReader.GetAttribute("NOSE_30").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_31=objReader.GetAttribute("NOSE_31").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_1=objReader.GetAttribute("LARYNXGULLET_1").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_2=objReader.GetAttribute("LARYNXGULLET_2").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_3=objReader.GetAttribute("LARYNXGULLET_3").ToString().Replace ('き','\'');

								m_objDisplay.strLarynxGullet_4=objReader.GetAttribute("LARYNXGULLET_4").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_5=objReader.GetAttribute("LARYNXGULLET_5").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_6=objReader.GetAttribute("LARYNXGULLET_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_7=objReader.GetAttribute("LARYNXGULLET_7").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_8=objReader.GetAttribute("LARYNXGULLET_8").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_9=objReader.GetAttribute("LARYNXGULLET_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_10=objReader.GetAttribute("LARYNXGULLET_10").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_11=objReader.GetAttribute("LARYNXGULLET_11").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_12=objReader.GetAttribute("LARYNXGULLET_12").ToString().Replace ('き','\'');

								m_objDisplay.strLarynxGullet_13=objReader.GetAttribute("LARYNXGULLET_13").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_14=objReader.GetAttribute("LARYNXGULLET_14").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_15=objReader.GetAttribute("LARYNXGULLET_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_16=objReader.GetAttribute("LARYNXGULLET_16").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_17=objReader.GetAttribute("LARYNXGULLET_17").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_18=objReader.GetAttribute("LARYNXGULLET_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_19=objReader.GetAttribute("LARYNXGULLET_19").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_20=objReader.GetAttribute("LARYNXGULLET_20").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_21=objReader.GetAttribute("LARYNXGULLET_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strTalkDoc=objReader.GetAttribute("TALKDOC").ToString().Replace ('き','\'');
								m_objDisplay.strBeforeDisgone=objReader.GetAttribute("BEFOREDISGONE").ToString().Replace ('き','\'');
								m_objDisplay.strRelationSufferer=objReader.GetAttribute("RELATIONSUFFERER").ToString().Replace ('き','\'');
								
								m_objDisplay.strRelationID=objReader.GetAttribute("RELATIONID").ToString().Replace ('き','\'');
								m_objDisplay.strRelation=objReader.GetAttribute("RELATION").ToString().Replace ('き','\'');
								m_objDisplay.strOperationName=objReader.GetAttribute("OPERATIONNAME").ToString().Replace ('き','\'');
								m_objDisplay.strPhone=objReader.GetAttribute("PHONE").ToString().Replace ('き','\'');
								m_objDisplay.strSignatory=objReader.GetAttribute("WRITER").ToString().Replace ('き','\'');
								
								
							}
							break;
					}
				}
			}
			return m_objDisplay;
		}

		
		public clsOperationAgreed objGetDeletedRecord(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			string strXML="";
			int intRows=0;

			clsOperationAgreed m_objDisplay =new clsOperationAgreed();

            clsOperationAgreedRecordServ m_objService =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.lngGetDeletedRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref strXML, ref intRows);
            }
            finally
            {
                ////m_objService.Dispose();
            }
			if(intRows>0)
			{
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								m_objDisplay.strInPatientID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('き','\'');
								m_objDisplay.strInPatientDate=objReader.GetAttribute("INPATIENTDATE").ToString().Replace ('き','\'');
								m_objDisplay.strCreateDate=objReader.GetAttribute("CREATEDATE").ToString().Replace ('き','\'');
								m_objDisplay.strCreateUserID=objReader.GetAttribute("CREATEUSERID").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_1=objReader.GetAttribute("AURIS_1").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_2=objReader.GetAttribute("AURIS_2").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_3=objReader.GetAttribute("AURIS_3").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_4=objReader.GetAttribute("AURIS_4").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_5=objReader.GetAttribute("AURIS_5").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_6=objReader.GetAttribute("AURIS_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_7=objReader.GetAttribute("AURIS_7").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_8=objReader.GetAttribute("AURIS_8").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_9=objReader.GetAttribute("AURIS_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_10=objReader.GetAttribute("AURIS_10").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_11=objReader.GetAttribute("AURIS_11").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_12=objReader.GetAttribute("AURIS_12").ToString().Replace ('き','\'');

								m_objDisplay.strAuris_13=objReader.GetAttribute("AURIS_13").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_14=objReader.GetAttribute("AURIS_14").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_15=objReader.GetAttribute("AURIS_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_16=objReader.GetAttribute("AURIS_16").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_17=objReader.GetAttribute("AURIS_17").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_18=objReader.GetAttribute("AURIS_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_19=objReader.GetAttribute("AURIS_19").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_20=objReader.GetAttribute("AURIS_20").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_21=objReader.GetAttribute("AURIS_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_22=objReader.GetAttribute("AURIS_22").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_23=objReader.GetAttribute("AURIS_23").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_24=objReader.GetAttribute("AURIS_24").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_25=objReader.GetAttribute("AURIS_25").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_26=objReader.GetAttribute("AURIS_26").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_27=objReader.GetAttribute("AURIS_27").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_28=objReader.GetAttribute("AURIS_28").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_29=objReader.GetAttribute("AURIS_29").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_30=objReader.GetAttribute("AURIS_30").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_31=objReader.GetAttribute("AURIS_31").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_32=objReader.GetAttribute("AURIS_32").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_33=objReader.GetAttribute("AURIS_33").ToString().Replace ('き','\'');

								m_objDisplay.strAuris_34=objReader.GetAttribute("AURIS_34").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_35=objReader.GetAttribute("AURIS_35").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_36=objReader.GetAttribute("AURIS_36").ToString().Replace ('き','\'');
								
								m_objDisplay.strAuris_37=objReader.GetAttribute("AURIS_37").ToString().Replace ('き','\'');
								m_objDisplay.strAuris_38=objReader.GetAttribute("AURIS_38").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_1=objReader.GetAttribute("FAUCES_1").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_2=objReader.GetAttribute("FAUCES_2").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_3=objReader.GetAttribute("FAUCES_3").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_4=objReader.GetAttribute("FAUCES_4").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_5=objReader.GetAttribute("FAUCES_5").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_6=objReader.GetAttribute("FAUCES_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_7=objReader.GetAttribute("FAUCES_7").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_8=objReader.GetAttribute("FAUCES_8").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_9=objReader.GetAttribute("FAUCES_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_10=objReader.GetAttribute("FAUCES_10").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_11=objReader.GetAttribute("FAUCES_11").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_12=objReader.GetAttribute("FAUCES_12").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_13=objReader.GetAttribute("FAUCES_13").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_14=objReader.GetAttribute("FAUCES_14").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_15=objReader.GetAttribute("FAUCES_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_16=objReader.GetAttribute("FAUCES_16").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_17=objReader.GetAttribute("FAUCES_17").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_18=objReader.GetAttribute("FAUCES_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strFauces_19=objReader.GetAttribute("FAUCES_19").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_20=objReader.GetAttribute("FAUCES_20").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_21=objReader.GetAttribute("FAUCES_21").ToString().Replace ('き','\'');

								m_objDisplay.strFauces_22=objReader.GetAttribute("FAUCES_22").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_23=objReader.GetAttribute("FAUCES_23").ToString().Replace ('き','\'');
								m_objDisplay.strFauces_24=objReader.GetAttribute("FAUCES_24").ToString().Replace ('き','\'');

								m_objDisplay.strHead_1=objReader.GetAttribute("HEAD_1").ToString().Replace ('き','\'');
								m_objDisplay.strHead_2=objReader.GetAttribute("HEAD_2").ToString().Replace ('き','\'');
								m_objDisplay.strHead_3=objReader.GetAttribute("HEAD_3").ToString().Replace ('き','\'');

								m_objDisplay.strHead_4=objReader.GetAttribute("HEAD_4").ToString().Replace ('き','\'');
								m_objDisplay.strHead_5=objReader.GetAttribute("HEAD_5").ToString().Replace ('き','\'');
								m_objDisplay.strHead_6=objReader.GetAttribute("HEAD_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_7=objReader.GetAttribute("HEAD_7").ToString().Replace ('き','\'');
								m_objDisplay.strHead_8=objReader.GetAttribute("HEAD_8").ToString().Replace ('き','\'');
								m_objDisplay.strHead_9=objReader.GetAttribute("HEAD_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_10=objReader.GetAttribute("HEAD_10").ToString().Replace ('き','\'');
								m_objDisplay.strHead_11=objReader.GetAttribute("HEAD_11").ToString().Replace ('き','\'');
								m_objDisplay.strHead_12=objReader.GetAttribute("HEAD_12").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_13=objReader.GetAttribute("HEAD_13").ToString().Replace ('き','\'');
								m_objDisplay.strHead_14=objReader.GetAttribute("HEAD_14").ToString().Replace ('き','\'');
								m_objDisplay.strHead_15=objReader.GetAttribute("HEAD_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strHead_16=objReader.GetAttribute("HEAD_16").ToString().Replace ('き','\'');
								m_objDisplay.strHead_17=objReader.GetAttribute("HEAD_17").ToString().Replace ('き','\'');
								m_objDisplay.strHead_18=objReader.GetAttribute("HEAD_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_1=objReader.GetAttribute("NOSE_1").ToString().Replace ('き','\'');
								m_objDisplay.strNose_2=objReader.GetAttribute("NOSE_2").ToString().Replace ('き','\'');
								m_objDisplay.strNose_3=objReader.GetAttribute("NOSE_3").ToString().Replace ('き','\'');

								m_objDisplay.strNose_4=objReader.GetAttribute("NOSE_4").ToString().Replace ('き','\'');
								m_objDisplay.strNose_5=objReader.GetAttribute("NOSE_5").ToString().Replace ('き','\'');
								m_objDisplay.strNose_6=objReader.GetAttribute("NOSE_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_7=objReader.GetAttribute("NOSE_7").ToString().Replace ('き','\'');
								m_objDisplay.strNose_8=objReader.GetAttribute("NOSE_8").ToString().Replace ('き','\'');
								m_objDisplay.strNose_9=objReader.GetAttribute("NOSE_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_10=objReader.GetAttribute("NOSE_10").ToString().Replace ('き','\'');
								m_objDisplay.strNose_11=objReader.GetAttribute("NOSE_11").ToString().Replace ('き','\'');
								m_objDisplay.strNose_12=objReader.GetAttribute("NOSE_12").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_13=objReader.GetAttribute("NOSE_13").ToString().Replace ('き','\'');
								m_objDisplay.strNose_14=objReader.GetAttribute("NOSE_14").ToString().Replace ('き','\'');
								m_objDisplay.strNose_15=objReader.GetAttribute("NOSE_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_16=objReader.GetAttribute("NOSE_16").ToString().Replace ('き','\'');
								m_objDisplay.strNose_17=objReader.GetAttribute("NOSE_17").ToString().Replace ('き','\'');
								m_objDisplay.strNose_18=objReader.GetAttribute("NOSE_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_19=objReader.GetAttribute("NOSE_19").ToString().Replace ('き','\'');
								m_objDisplay.strNose_20=objReader.GetAttribute("NOSE_20").ToString().Replace ('き','\'');
								m_objDisplay.strNose_21=objReader.GetAttribute("NOSE_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_22=objReader.GetAttribute("NOSE_22").ToString().Replace ('き','\'');
								m_objDisplay.strNose_23=objReader.GetAttribute("NOSE_23").ToString().Replace ('き','\'');
								m_objDisplay.strNose_24=objReader.GetAttribute("NOSE_24").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_25=objReader.GetAttribute("NOSE_25").ToString().Replace ('き','\'');
								m_objDisplay.strNose_26=objReader.GetAttribute("NOSE_26").ToString().Replace ('き','\'');
								m_objDisplay.strNose_27=objReader.GetAttribute("NOSE_27").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_28=objReader.GetAttribute("NOSE_28").ToString().Replace ('き','\'');
								m_objDisplay.strNose_29=objReader.GetAttribute("NOSE_29").ToString().Replace ('き','\'');
								m_objDisplay.strNose_30=objReader.GetAttribute("NOSE_30").ToString().Replace ('き','\'');
								
								m_objDisplay.strNose_31=objReader.GetAttribute("NOSE_31").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_1=objReader.GetAttribute("LARYNXGULLET_1").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_2=objReader.GetAttribute("LARYNXGULLET_2").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_3=objReader.GetAttribute("LARYNXGULLET_3").ToString().Replace ('き','\'');

								m_objDisplay.strLarynxGullet_4=objReader.GetAttribute("LARYNXGULLET_4").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_5=objReader.GetAttribute("LARYNXGULLET_5").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_6=objReader.GetAttribute("LARYNXGULLET_6").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_7=objReader.GetAttribute("LARYNXGULLET_7").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_8=objReader.GetAttribute("LARYNXGULLET_8").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_9=objReader.GetAttribute("LARYNXGULLET_9").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_10=objReader.GetAttribute("LARYNXGULLET_10").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_11=objReader.GetAttribute("LARYNXGULLET_11").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_12=objReader.GetAttribute("LARYNXGULLET_12").ToString().Replace ('き','\'');

								m_objDisplay.strLarynxGullet_13=objReader.GetAttribute("LARYNXGULLET_13").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_14=objReader.GetAttribute("LARYNXGULLET_14").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_15=objReader.GetAttribute("LARYNXGULLET_15").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_16=objReader.GetAttribute("LARYNXGULLET_16").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_17=objReader.GetAttribute("LARYNXGULLET_17").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_18=objReader.GetAttribute("LARYNXGULLET_18").ToString().Replace ('き','\'');
								
								m_objDisplay.strLarynxGullet_19=objReader.GetAttribute("LARYNXGULLET_19").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_20=objReader.GetAttribute("LARYNXGULLET_20").ToString().Replace ('き','\'');
								m_objDisplay.strLarynxGullet_21=objReader.GetAttribute("LARYNXGULLET_21").ToString().Replace ('き','\'');
								
								m_objDisplay.strTalkDoc=objReader.GetAttribute("TALKDOC").ToString().Replace ('き','\'');
								m_objDisplay.strBeforeDisgone=objReader.GetAttribute("BEFOREDISGONE").ToString().Replace ('き','\'');
								m_objDisplay.strRelationSufferer=objReader.GetAttribute("RELATIONSUFFERER").ToString().Replace ('き','\'');
								
								m_objDisplay.strRelationID=objReader.GetAttribute("RELATIONID").ToString().Replace ('き','\'');
								m_objDisplay.strRelation=objReader.GetAttribute("RELATION").ToString().Replace ('き','\'');
								m_objDisplay.strOperationName=objReader.GetAttribute("OPERATIONNAME").ToString().Replace ('き','\'');
								m_objDisplay.strPhone=objReader.GetAttribute("PHONE").ToString().Replace ('き','\'');
								m_objDisplay.strSignatory=objReader.GetAttribute("WRITER").ToString().Replace ('き','\'');
								
								
							}
							break;
					}
				}
			}
			return m_objDisplay;
		}

		
		#region 2003-3-28 LiuRongGuo 奐紗評茅
		public long m_lngDeactive(string p_strDeActiveOperatorID, string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate)
		{
			if(p_strDeActiveOperatorID == null || p_strDeActiveOperatorID == "" || 
			   p_strInPatientID == null || p_strInPatientID =="" || 
			   p_strInPatientDate == null || p_strInPatientDate == "" ||
			   p_strCreateDate == null || p_strCreateDate =="")
				return -1;
            long lngRes = 0;
			string strDeActiveXml = m_strGetDeActiveXml(p_strDeActiveOperatorID,p_strInPatientID,p_strInPatientDate,p_strCreateDate);

            clsSPECTCheckOrderServ m_objService =
                (clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSPECTCheckOrderServ));

			try
            {
                lngRes = m_objService.m_lngDeActive(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strDeActiveXml,"OperationRecordAgreed");
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		private string m_strGetDeActiveXml(string p_strDeActiveOperatorID, string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", p_strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", p_strCreateDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_strDeActiveOperatorID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", "1");

			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);	
		}
		#endregion

	}

	public class clsOperationAgreed
	{
		public string strInPatientID;
		public string strInPatientDate;
		public string strCreateDate;

		public string strModifyDate;
		public string strCreateUserID;
		public string strIfConfirm;

		public string strConfirmReason;
		public string strConfirmReasonXML;
		public string strFirstPrintDate;

		public string strDeActivedDate;
		public string strDeActivedOperatorID;
		public string strStatus;

		public string strBeforeDisgone;
		public string strOperationName;
		public string strAuris_1;
		public string strAuris_2;
		public string strAuris_3;
		public string strAuris_4;
		public string strAuris_5;
		public string strAuris_6;
		public string strAuris_7;
		public string strAuris_8;
		public string strAuris_9;
		public string strAuris_10;
		public string strAuris_11;
		public string strAuris_12;
		public string strAuris_13;
		public string strAuris_14;
		public string strAuris_15;
		public string strAuris_16;
		public string strAuris_17;
		public string strAuris_18;
		public string strAuris_19;
		public string strAuris_20;
		public string strAuris_21;
		public string strAuris_22;
		public string strAuris_23;
		public string strAuris_24;
		public string strAuris_25;
		public string strAuris_26;
		public string strAuris_27;
		public string strAuris_28;
		public string strAuris_29;
		public string strAuris_30;
		public string strAuris_31;
		public string strAuris_32;
		public string strAuris_33;
		public string strAuris_34;
		public string strAuris_35;
		public string strAuris_36;
		public string strAuris_37;
		public string strAuris_38;
		public string strNose_1;
		public string strNose_2;
		public string strNose_3;
		public string strNose_4;
		public string strNose_5;
		public string strNose_6;
		public string strNose_7;
		public string strNose_8;
		public string strNose_9;
		public string strNose_10;
		public string strNose_11;
		public string strNose_12;
		public string strNose_13;
		public string strNose_14;
		public string strNose_15;
		public string strNose_16;
		public string strNose_17;
		public string strNose_18;
		public string strNose_19;
		public string strNose_20;
		public string strNose_21;
		public string strNose_22;
		public string strNose_23;
		public string strNose_24;
		public string strNose_25;
		public string strNose_26;
		public string strNose_27;
		public string strNose_28;
		public string strNose_29;
		public string strNose_30;
		public string strNose_31;

		public string strFauces_1;
		public string strFauces_2;
		public string strFauces_3;
		public string strFauces_4;
		public string strFauces_5;
		public string strFauces_6;
		public string strFauces_7;
		public string strFauces_8;
		public string strFauces_9;
		public string strFauces_10;
		public string strFauces_11;
		public string strFauces_12;
		public string strFauces_13;
		public string strFauces_14;
		public string strFauces_15;
		public string strFauces_16;
		public string strFauces_17;
		public string strFauces_18;
		public string strFauces_19;
		public string strFauces_20;
		public string strFauces_21;
		public string strFauces_22;
		public string strFauces_23;
		public string strFauces_24;
		public string strHead_1;
		public string strHead_2;
		public string strHead_3;
		public string strHead_4;
		public string strHead_5;
		public string strHead_6;
		public string strHead_7;
		public string strHead_8;
		public string strHead_9;
		public string strHead_10;
		public string strHead_11;
		public string strHead_12;
		public string strHead_13;
		public string strHead_14;
		public string strHead_15;
		public string strHead_16;
		public string strHead_17;
		public string strHead_18;
		public string strLarynxGullet_1;
		public string strLarynxGullet_2;
		public string strLarynxGullet_3;
		public string strLarynxGullet_4;
		public string strLarynxGullet_5;
		public string strLarynxGullet_6;
		public string strLarynxGullet_7;
		public string strLarynxGullet_8;
		public string strLarynxGullet_9;
		public string strLarynxGullet_10;
		public string strLarynxGullet_11;
		public string strLarynxGullet_12;
		public string strLarynxGullet_13;
		public string strLarynxGullet_14;
		public string strLarynxGullet_15;
		public string strLarynxGullet_16;
		public string strLarynxGullet_17;
		public string strLarynxGullet_18;
		public string strLarynxGullet_19;
		public string strLarynxGullet_20;
		public string strLarynxGullet_21;

		public string strRelation;

		public string strTalkDoc;
		public string strRelationSufferer;
		public string strRelationID;
		public string strSignatory;
		public string strPhone;
	}

}
