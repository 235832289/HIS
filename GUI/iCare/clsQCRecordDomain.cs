using System;
using System.Xml;
using System.IO;
using System.Text;

using com.digitalwave.QCRecordService;

namespace iCare
{
	/// <summary>
	/// 领域层

	/// </summary>
	public class clsQCRecordDomain
	{ 
		/// <summary>
		/// 仪器管理的中间层
		/// </summary>
        //private clsQCRecordService m_objQCRecordServ;

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
		public clsQCRecordDomain()
		{
            //m_objQCRecordServ = new clsQCRecordService();

			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符


			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		}	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewMainXml(clsQCRecordInfo p_objInfo)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("QCRecord");

			m_objXmlWriter.WriteAttributeString("INPATIENTID",p_objInfo.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE",p_objInfo.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("OPENDATE",p_objInfo.m_strOpenDate);
			m_objXmlWriter.WriteAttributeString("CREATEID",p_objInfo.m_strCreateID);
			m_objXmlWriter.WriteAttributeString("IFCONFIRM","0");
			m_objXmlWriter.WriteAttributeString("STATUS","0");
			
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
		private string m_strMakeNewContentXml(clsQCRecordContentInfo p_objInfo)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("QCRecordContent");

			m_objXmlWriter.WriteAttributeString("INPATIENTID",p_objInfo.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE",p_objInfo.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("OPENDATE",p_objInfo.m_strOpenDate);
			m_objXmlWriter.WriteAttributeString("MODIFYDATE",p_objInfo.m_strModifyDate);
			m_objXmlWriter.WriteAttributeString("MODIFYUSERID",p_objInfo.m_strModifyUserID);
			m_objXmlWriter.WriteAttributeString("WRITEDOCTORID",p_objInfo.m_strWriteDoctorID);
			m_objXmlWriter.WriteAttributeString("FILECHECKERID",p_objInfo.m_strFileCheckerID);
			m_objXmlWriter.WriteAttributeString("CHECKDOCTORID",p_objInfo.m_strCheckDoctorID);
			m_objXmlWriter.WriteAttributeString("FIRSTPAGETIDYVALUE",p_objInfo.m_strFirstPageTidyValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FIRSTPAGETIDYREASON",p_objInfo.m_strFirstPageTidyReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LITIGANTVALUE",p_objInfo.m_strLitigantValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LITIGANTREASON",p_objInfo.m_strLitigantReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CASEHISTORYVALUE",p_objInfo.m_strCaseHistoryValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CASEHISTORYREASON",p_objInfo.m_strCaseHistoryReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKVALUE",p_objInfo.m_strCheckValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKREASON",p_objInfo.m_strCheckReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DIAGNOSEVALUE",p_objInfo.m_strDiagnoseValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DIAGNOSEREASON",p_objInfo.m_strDiagnoseReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CUREVALUE",p_objInfo.m_strCureValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CUREREASON",p_objInfo.m_strCureReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATEILLNESSVALUE",p_objInfo.m_strStateillnessValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATEILLNESSREASON",p_objInfo.m_strStateillnessReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OTHERRECORDVALUE",p_objInfo.m_strOtherRecordValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OTHERRECORDREASON",p_objInfo.m_strOtherRecordReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORADVICEVALUE",p_objInfo.m_strDoctorAdviceValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORADVICEREASON",p_objInfo.m_strDoctorAdviceReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NURSEVALUE",p_objInfo.m_strNurseValue.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NURSEREASON",p_objInfo.m_strNurseReason.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TOTALVALUE",p_objInfo.m_strTotalValue.Replace('\'','き'));
            m_objXmlWriter.WriteAttributeString("RECORDERID", p_objInfo.m_strRecorderID.Replace('\'', 'き'));
			
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
		public long m_lngAddNew(clsQCRecordInfo p_objMainInfo,clsQCRecordContentInfo p_objContentInfo)
		{
            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                string strMainXml = m_strMakeNewMainXml(p_objMainInfo);
                string strContentXml = m_strMakeNewContentXml(p_objContentInfo);
                lngRes = m_objQCRecordServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strMainXml, strContentXml);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
            return lngRes;
		}		

		public long m_lngCheckNewOpenDate(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out bool p_blnIsAddNew)
		{
            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objQCRecordServ.m_lngCheckNewOpenDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_blnIsAddNew);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
            return lngRes;
		}		

		public long m_lngGetQCRecord(clsPatient p_objPatient,string p_strInPatientDate,out clsQCRecordInfo p_objMainInfo,out clsQCRecordContentInfo p_objContentInfo)
		{
			string strXML = "";
			int intRows = 0;

            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objQCRecordServ.m_lngGetQCRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objPatient.m_StrInPatientID,p_strInPatientDate,ref strXML,ref intRows);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
			if(lngRes > 0 && intRows > 0)
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
								p_objContentInfo = new clsQCRecordContentInfo();
								p_objContentInfo.m_strInPatientID = objReader.GetAttribute("INPATIENTID");
								p_objContentInfo.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE");
								p_objContentInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
								p_objContentInfo.m_strModifyDate = objReader.GetAttribute("MODIFYDATE");
								p_objContentInfo.m_strModifyUserID = objReader.GetAttribute("MODIFYUSERID");
								p_objContentInfo.m_strWriteDoctorID = objReader.GetAttribute("WRITEDOCTORID");
								p_objContentInfo.m_strFileCheckerID = objReader.GetAttribute("FILECHECKERID");
								p_objContentInfo.m_strCheckDoctorID = objReader.GetAttribute("CHECKDOCTORID");
								p_objContentInfo.m_strFirstPageTidyValue = objReader.GetAttribute("FIRSTPAGETIDYVALUE").Replace('き','\'');
								p_objContentInfo.m_strFirstPageTidyReason = objReader.GetAttribute("FIRSTPAGETIDYREASON").Replace('き','\'');
								p_objContentInfo.m_strLitigantValue = objReader.GetAttribute("LITIGANTVALUE").Replace('き','\'');
								p_objContentInfo.m_strLitigantReason = objReader.GetAttribute("LITIGANTREASON").Replace('き','\'');
								p_objContentInfo.m_strCaseHistoryValue = objReader.GetAttribute("CASEHISTORYVALUE").Replace('き','\'');
								p_objContentInfo.m_strCaseHistoryReason = objReader.GetAttribute("CASEHISTORYREASON").Replace('き','\'');
								p_objContentInfo.m_strCheckValue = objReader.GetAttribute("CHECKVALUE").Replace('き','\'');
								p_objContentInfo.m_strCheckReason = objReader.GetAttribute("CHECKREASON").Replace('き','\'');
								p_objContentInfo.m_strDiagnoseValue = objReader.GetAttribute("DIAGNOSEVALUE").Replace('き','\'');
								p_objContentInfo.m_strDiagnoseReason = objReader.GetAttribute("DIAGNOSEREASON").Replace('き','\'');
								p_objContentInfo.m_strCureValue = objReader.GetAttribute("CUREVALUE").Replace('き','\'');
								p_objContentInfo.m_strCureReason = objReader.GetAttribute("CUREREASON").Replace('き','\'');
								p_objContentInfo.m_strStateillnessValue = objReader.GetAttribute("STATEILLNESSVALUE").Replace('き','\'');
								p_objContentInfo.m_strStateillnessReason = objReader.GetAttribute("STATEILLNESSREASON").Replace('き','\'');
								p_objContentInfo.m_strOtherRecordValue = objReader.GetAttribute("OTHERRECORDVALUE").Replace('き','\'');
								p_objContentInfo.m_strOtherRecordReason = objReader.GetAttribute("OTHERRECORDREASON").Replace('き','\'');
								p_objContentInfo.m_strDoctorAdviceValue = objReader.GetAttribute("DOCTORADVICEVALUE").Replace('き','\'');
								p_objContentInfo.m_strDoctorAdviceReason = objReader.GetAttribute("DOCTORADVICEREASON").Replace('き','\'');
								p_objContentInfo.m_strNurseValue = objReader.GetAttribute("NURSEVALUE").Replace('き','\'');
								p_objContentInfo.m_strNurseReason = objReader.GetAttribute("NURSEREASON").Replace('き','\'');
								p_objContentInfo.m_strTotalValue = objReader.GetAttribute("TOTALVALUE").Replace('き','\'');
                                p_objContentInfo.m_strRecorderID = objReader.GetAttribute("RECORDERID").Replace('き', '\'');
								
								p_objMainInfo = new clsQCRecordInfo();
								p_objMainInfo.m_strInPatientID = objReader.GetAttribute("INPATIENTID");
								p_objMainInfo.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE");
								p_objMainInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
								p_objMainInfo.m_strCreateID = objReader.GetAttribute("CREATEID");
								return 1;
							}
							break;
					}
				}
			}

			p_objMainInfo = null;
			p_objContentInfo = null;

			return 0;
		}


		public long m_lngGetDeleteQCRecord(clsPatient p_objPatient,string p_strInPatientDate,string p_strOpenDate,out clsQCRecordInfo p_objMainInfo,out clsQCRecordContentInfo p_objContentInfo)
		{
			string strXML = "";
			int intRows = 0;

            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objQCRecordServ.m_lngGetDeleteQCRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objPatient.m_StrInPatientID,p_strInPatientDate,p_strOpenDate,ref strXML,ref intRows);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
			if(lngRes > 0 && intRows > 0)
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
								p_objContentInfo = new clsQCRecordContentInfo();
								p_objContentInfo.m_strInPatientID = objReader.GetAttribute("INPATIENTID");
								p_objContentInfo.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE");
								p_objContentInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
								p_objContentInfo.m_strModifyDate = objReader.GetAttribute("MODIFYDATE");
								p_objContentInfo.m_strModifyUserID = objReader.GetAttribute("MODIFYUSERID");
								p_objContentInfo.m_strWriteDoctorID = objReader.GetAttribute("WRITEDOCTORID");
								p_objContentInfo.m_strFileCheckerID = objReader.GetAttribute("FILECHECKERID");
								p_objContentInfo.m_strCheckDoctorID = objReader.GetAttribute("CHECKDOCTORID");
								p_objContentInfo.m_strFirstPageTidyValue = objReader.GetAttribute("FIRSTPAGETIDYVALUE").Replace('き','\'');
								p_objContentInfo.m_strFirstPageTidyReason = objReader.GetAttribute("FIRSTPAGETIDYREASON").Replace('き','\'');
								p_objContentInfo.m_strLitigantValue = objReader.GetAttribute("LITIGANTVALUE").Replace('き','\'');
								p_objContentInfo.m_strLitigantReason = objReader.GetAttribute("LITIGANTREASON").Replace('き','\'');
								p_objContentInfo.m_strCaseHistoryValue = objReader.GetAttribute("CASEHISTORYVALUE").Replace('き','\'');
								p_objContentInfo.m_strCaseHistoryReason = objReader.GetAttribute("CASEHISTORYREASON").Replace('き','\'');
								p_objContentInfo.m_strCheckValue = objReader.GetAttribute("CHECKVALUE").Replace('き','\'');
								p_objContentInfo.m_strCheckReason = objReader.GetAttribute("CHECKREASON").Replace('き','\'');
								p_objContentInfo.m_strDiagnoseValue = objReader.GetAttribute("DIAGNOSEVALUE").Replace('き','\'');
								p_objContentInfo.m_strDiagnoseReason = objReader.GetAttribute("DIAGNOSEREASON").Replace('き','\'');
								p_objContentInfo.m_strCureValue = objReader.GetAttribute("CUREVALUE").Replace('き','\'');
								p_objContentInfo.m_strCureReason = objReader.GetAttribute("CUREREASON").Replace('き','\'');
								p_objContentInfo.m_strStateillnessValue = objReader.GetAttribute("STATEILLNESSVALUE").Replace('き','\'');
								p_objContentInfo.m_strStateillnessReason = objReader.GetAttribute("STATEILLNESSREASON").Replace('き','\'');
								p_objContentInfo.m_strOtherRecordValue = objReader.GetAttribute("OTHERRECORDVALUE").Replace('き','\'');
								p_objContentInfo.m_strOtherRecordReason = objReader.GetAttribute("OTHERRECORDREASON").Replace('き','\'');
								p_objContentInfo.m_strDoctorAdviceValue = objReader.GetAttribute("DOCTORADVICEVALUE").Replace('き','\'');
								p_objContentInfo.m_strDoctorAdviceReason = objReader.GetAttribute("DOCTORADVICEREASON").Replace('き','\'');
								p_objContentInfo.m_strNurseValue = objReader.GetAttribute("NURSEVALUE").Replace('き','\'');
								p_objContentInfo.m_strNurseReason = objReader.GetAttribute("NURSEREASON").Replace('き','\'');
								p_objContentInfo.m_strTotalValue = objReader.GetAttribute("TOTALVALUE").Replace('き','\'');
                                p_objContentInfo.m_strRecorderID = objReader.GetAttribute("RECORDERID").Replace('き', '\'');
								
								p_objMainInfo = new clsQCRecordInfo();
								p_objMainInfo.m_strInPatientID = objReader.GetAttribute("INPATIENTID");
								p_objMainInfo.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE");
								p_objMainInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
								p_objMainInfo.m_strCreateID = objReader.GetAttribute("CREATEID");
								
								return 1;
							}
							break;
					}
				}
			}

			p_objMainInfo = null;
			p_objContentInfo = null;

			return 0;
		}

		/// <summary>
		/// 删除
		/// </summary>		
		public long m_lngDelete(string p_strDeActivedOperatorID,string p_strInPatientID,string p_strInPatientDate/*,string p_strOpenDate*/)
		{
            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objQCRecordServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strDeActivedOperatorID,p_strInPatientID,p_strInPatientDate/*,p_strOpenDate*/);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 得到已被删除的记录相关信息，Jacky-2003-4-1
		/// </summary>		
		public long m_lngGetIDandTimeOfDeletedRecord(clsPatient p_objPatient,string p_strInPatientDate,out clsQCRecordInfo p_objMainInfo)
		{
			string strXML = "";
			int intRows = 0;

            clsQCRecordService m_objQCRecordServ =
                (clsQCRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQCRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objQCRecordServ.m_lngGetIDandTimeOfDeletedRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objPatient.m_StrInPatientID,p_strInPatientDate,ref strXML,ref intRows);
            }
            finally
            {
                //m_objQCRecordServ.Dispose();
            }
			if(lngRes > 0 && intRows == 1)
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
								p_objMainInfo = new clsQCRecordInfo();
								//								p_objMainInfo.m_strInPatientID = objReader.GetAttribute("INPATIENTID");
								//								p_objMainInfo.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE");
								//								p_objMainInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
								//								p_objMainInfo.m_strCreateID = objReader.GetAttribute("CREATEID");								
								
								p_objMainInfo.m_strDeActivedDate=objReader.GetAttribute("DEACTIVEDDATE");
								p_objMainInfo.m_strDeActivedOperatorID=objReader.GetAttribute("DEACTIVEDOPERATORID");
								return 1;
							}
							break;
					}
				}
			}

			p_objMainInfo = null;
			return 0;
		}
	}	

	#region 交互数据用的类

	/// <summary>
	/// 
	/// </summary>
	public class clsQCRecordInfo
	{
		/// <summary>
		/// 
		/// </summary>
		public string m_strInPatientID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strInPatientDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strOpenDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCreateID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strIfConfirm;

		/// <summary>
		/// 
		/// </summary>
		public string m_strConfirmReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strConfirmReasonXMLString;


		/// <summary>
		/// 仅在该记录已经被删除之后查询之用
		/// </summary>
		public string m_strDeActivedDate;

		/// <summary>
		/// 仅在该记录已经被删除之后查询之用
		/// </summary>
		public string m_strDeActivedOperatorID;
	}

	/// <summary>
	/// 
	/// </summary>
	public class clsQCRecordContentInfo
	{
		/// <summary>
		/// 
		/// </summary>
		public string m_strInPatientID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strInPatientDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strOpenDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strModifyDate;

		/// <summary>
		/// 
		/// </summary>
		public string m_strModifyUserID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strWriteDoctorID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strFileCheckerID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCheckDoctorID;

		/// <summary>
		/// 
		/// </summary>
		public string m_strFirstPageTidyValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strFirstPageTidyReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strLitigantValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strLitigantReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCaseHistoryValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCaseHistoryReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCheckValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCheckReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strDiagnoseValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strDiagnoseReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCureValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strCureReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strStateillnessValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strStateillnessReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strOtherRecordValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strOtherRecordReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strDoctorAdviceValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strDoctorAdviceReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strNurseValue;

		/// <summary>
		/// 
		/// </summary>
		public string m_strNurseReason;

		/// <summary>
		/// 
		/// </summary>
		public string m_strTotalValue;
        public string m_strRecorderID;

	}
	#endregion
}
