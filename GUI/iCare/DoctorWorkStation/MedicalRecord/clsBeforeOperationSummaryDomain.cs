using System;
using System.Xml;
using System.IO;
using System.Text;
using iCareData;
using com.digitalwave.BeforeOperationSummaryService ;


namespace iCare
{
	/// <summary>
	/// Summary description for clsBeforeOperationSummaryDomain.
	/// </summary>
	public class clsBeforeOperationSummaryDomain
	{
		#region 变量


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
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsBeforeOperationSummaryDomain()
		{
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		}
		#endregion 

		#region  从表XML
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewContentXml(clsBeforeOperationSummaryContentInfo p_objInfo,bool blnIsAddNew)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("BeforeOperationSummaryContent");

			if(!blnIsAddNew)
				m_objXmlWriter.WriteAttributeString("OPENDATE",p_objInfo.m_strOpenDate);

			m_objXmlWriter.WriteAttributeString("INPATIENTID",p_objInfo.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE",p_objInfo.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("MODIFYUSERID",p_objInfo.m_strModifyUserID);
			m_objXmlWriter.WriteAttributeString("OPERATEDOCTORID",p_objInfo.m_strOperateDoctorID);
			m_objXmlWriter.WriteAttributeString("CHARGEDOCTORID",p_objInfo.m_strChargeDoctorID);
			m_objXmlWriter.WriteAttributeString("DIAGNOSE",p_objInfo.m_strDiagnose.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DIAGNOSEGIST",p_objInfo.m_strDiagnoseGist.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODYINFO",p_objInfo.m_strBodyInfo.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SPECIALHANDLE",p_objInfo.m_strSpecialHandle.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PREPARATION",p_objInfo.m_strPreparation.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PATIENTNOTION",p_objInfo.m_strPatientNotion.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANAESTHESIA",p_objInfo.m_strAnaesthesia.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AFTERNOTICE",p_objInfo.m_strAfterNotice.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DISCUSSNOTION",p_objInfo.m_strDiscussNotion.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONDATE",p_objInfo.m_strOperationDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}
		#endregion
        
		#region 主表XML
		/// <summary>
		/// 主表XML
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewMainXml(clsBeforeOperationSummaryInfo p_objInfo,bool blnIsAddNew)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("BeforeOperationSummary");
            
			if(!blnIsAddNew)
				m_objXmlWriter.WriteAttributeString("OPENDATE",p_objInfo.m_strOpenDate);

			m_objXmlWriter.WriteAttributeString("INPATIENTID",p_objInfo.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE",p_objInfo.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("CREATEDATE",p_objInfo.m_strCreateDate);
			m_objXmlWriter.WriteAttributeString("CREATEID",p_objInfo.m_strCreateID);
			m_objXmlWriter.WriteAttributeString("DIAGNOSEXML",p_objInfo.m_strDiagnoseXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DIAGNOSEGISTXML",p_objInfo.m_strDiagnoseGistXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODYINFOXML",p_objInfo.m_strBodyInfoXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SPECIALHANDLEXML",p_objInfo.m_strSpecialHandleXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PREPARATIONXML",p_objInfo.m_strPreparationXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PATIENTNOTIONXML",p_objInfo.m_strPatientNotionXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANAESTHESIAXML",p_objInfo.m_strAnaesthesiaXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AFTERNOTICEXML",p_objInfo.m_strAfterNoticeXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DISCUSSNOTIONXML",p_objInfo.m_strDiscussNotionXml.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("IFCONFIRM","0");
			m_objXmlWriter.WriteAttributeString("STATUS","0");
			
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}
		#endregion

		#region 检查新增时是否第一次添加
		/// <summary>
		/// 检查新增时是否第一次添加
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <param name="p_blnIsAddNew"></param>
		/// <returns>
		/// 操作结果。
		/// 0，失败。
		/// 1，成功。
		/// </returns>
		public long m_lngCheckNewCreateDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out bool p_blnIsAddNew)
		{
            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngCheckNewCreateDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out p_blnIsAddNew);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		#endregion

		#region 添加
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>
		/// 操作结果。
		/// 0，失败。
		/// 1，成功。
		/// </returns>
		public long m_lngAddNew(clsBeforeOperationSummaryInfo p_objMainInfo,clsBeforeOperationSummaryContentInfo p_objContentInfo)
		{
			string strMainXml = m_strMakeNewMainXml(p_objMainInfo,true);
			string strContentXml = m_strMakeNewContentXml(p_objContentInfo,true);

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strMainXml,strContentXml);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		#endregion
	    
		#region 最后修改时间
		/// <summary>
		/// 最后修改时间
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <param name="p_strLastModifyDate"></param>
		/// <param name="p_blnIsLast"></param>
		/// <returns></returns>
		public long m_lngGetLastModifyDate(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out string  p_strLastModifyDate, out string strModifyUserID)
		{
			p_strLastModifyDate="";
			strModifyUserID="";

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngCheckLastModifyDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_strLastModifyDate,out strModifyUserID);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		#endregion

		#region 修改
		public long m_lngModify(clsBeforeOperationSummaryInfo p_objMainInfo,clsBeforeOperationSummaryContentInfo p_objContentInfo)
		{
			string strMainXml = m_strMakeNewMainXml(p_objMainInfo,false);
			string strContentXml = m_strMakeNewContentXml(p_objContentInfo,false);

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strMainXml,strContentXml);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		#endregion 

		#region 删除

		public long m_lngDeleteRecord(string  p_strInPatientID, string p_strInPatientDate,string  p_strOpenDate )
		{
            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate , MDIParent.OperatorID);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		#endregion 
	
		#region 所有的时间记录
		public long m_lngGetOperationDateArr(string p_strInPatientID,string p_strInPatientDate,out string [] objCreateDateArr)
		{
			string strXML = "";
			int intRows = 0;
			objCreateDateArr = null;

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetOperationDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out strXML,out intRows);

			    objCreateDateArr = null;

			    if(lngRes > 0 && intRows >0)
			    {
				    objCreateDateArr = new string[intRows];

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
								    objCreateDateArr[intIndex] =DateTime.Parse( objReader.GetAttribute("CREATEDATE")).ToString("yyyy-MM-dd HH:mm:ss");;
								    intIndex++;
							    }
							    break;
					    }
				    }
			    }
			    else
			    {
				    objCreateDateArr = new string[0];
			    }
            }
            finally
            {
                //m_objService.Dispose();
            }
			return lngRes;
		}

		#endregion 
		
		#region 查出时间对应的主表信息
		///查出时间对应的主表信息
		public long m_lngGetSummary_All(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsBeforeOperationSummary_All objclsBeforeOperationSummary_All )
		{
			objclsBeforeOperationSummary_All=null;
			string strXML = "";
			int intRows = 0;

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetSummaryInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out  strXML, out intRows);
                if (intRows > 0)
                {
                    objclsBeforeOperationSummary_All = new clsBeforeOperationSummary_All();
                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo = new clsBeforeOperationSummaryInfo();
                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo = new clsBeforeOperationSummaryContentInfo();


                    XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {

                                    objclsBeforeOperationSummary_All.m_strFirstPrintDate = objReader.GetAttribute("FIRSTPRINTDATE");	//首次打印时间

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strInPatientID = p_strInPatientID;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strInPatientDate = p_strInPatientDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strCreateDate = p_strCreateDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE")).ToString("yyyy-MM-dd HH:mm:ss");

                                    if (objReader.GetAttribute("FIRSTPRINTDATE") == "")
                                        objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strFirstPrintDate = "";
                                    else
                                        objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strFirstPrintDate = DateTime.Parse(objReader.GetAttribute("FIRSTPRINTDATE")).ToString("yyyy-MM-dd HH:mm:ss");

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strCreateID = objReader.GetAttribute("CREATEID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAfterNoticeXml = objReader.GetAttribute("AFTERNOTICEXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAnaesthesiaXml = objReader.GetAttribute("ANAESTHESIAXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strBodyInfoXml = objReader.GetAttribute("BODYINFOXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strConfirmReason = objReader.GetAttribute("CONFIRMREASON").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strConfirmReasonXMLString = objReader.GetAttribute("CONFIRMREASONXMLSTRING").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseGistXml = objReader.GetAttribute("DIAGNOSEGISTXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseXml = objReader.GetAttribute("DIAGNOSEXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiscussNotionXml = objReader.GetAttribute("DISCUSSNOTIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPatientNotionXml = objReader.GetAttribute("PATIENTNOTIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPreparationXml = objReader.GetAttribute("PREPARATIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strSpecialHandleXml = objReader.GetAttribute("SPECIALHANDLEXML").Replace('き', '\'');

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strInPatientID = p_strInPatientID;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strInPatientDate = p_strInPatientDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strModifyUserID = objReader.GetAttribute("MODIFYUSERID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strModifyDate = DateTime.Parse(objReader.GetAttribute("MODIFYDATE")).ToString("yyyy-MM-dd HH:mm:ss");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperateDoctorID = objReader.GetAttribute("OPERATEDOCTORID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strChargeDoctorID = objReader.GetAttribute("CHARGEDOCTORID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperateDoctorName = objReader.GetAttribute("OPERATEDOCTORNAME").Replace('き', '\'').Trim();
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strChargeDoctorName = objReader.GetAttribute("CHARGEDOCTORNAME").Replace('き', '\'').Trim();

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnose = objReader.GetAttribute("DIAGNOSE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnoseGist = objReader.GetAttribute("DIAGNOSEGIST").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strBodyInfo = objReader.GetAttribute("BODYINFO").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strSpecialHandle = objReader.GetAttribute("SPECIALHANDLE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPreparation = objReader.GetAttribute("PREPARATION").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPatientNotion = objReader.GetAttribute("PATIENTNOTION").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAnaesthesia = objReader.GetAttribute("ANAESTHESIA").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAfterNotice = objReader.GetAttribute("AFTERNOTICE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiscussNotion = objReader.GetAttribute("DISCUSSNOTION").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperationDate = objReader.GetAttribute("OPERATIONDATE").Replace('き', '\'');
                                }
                                break;
                        }
                    }

                }
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		

		///查出时间对应的主表信息
		public long m_lngGetDeletedSummary_All(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsBeforeOperationSummary_All objclsBeforeOperationSummary_All )
		{
			objclsBeforeOperationSummary_All=null;
			string strXML = "";
			int intRows = 0;

            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetDeletedSummaryInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out  strXML, out intRows);
                if (intRows > 0)
                {
                    objclsBeforeOperationSummary_All = new clsBeforeOperationSummary_All();
                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo = new clsBeforeOperationSummaryInfo();
                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo = new clsBeforeOperationSummaryContentInfo();


                    XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {

                                    objclsBeforeOperationSummary_All.m_strFirstPrintDate = objReader.GetAttribute("FIRSTPRINTDATE");	//首次打印时间

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strInPatientID = p_strInPatientID;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strInPatientDate = p_strInPatientDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strCreateDate = p_strCreateDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE")).ToString("yyyy-MM-dd HH:mm:ss");

                                    if (objReader.GetAttribute("FIRSTPRINTDATE") == "")
                                        objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strFirstPrintDate = "";
                                    else
                                        objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strFirstPrintDate = DateTime.Parse(objReader.GetAttribute("FIRSTPRINTDATE")).ToString("yyyy-MM-dd HH:mm:ss");

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strCreateID = objReader.GetAttribute("CREATEID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAfterNoticeXml = objReader.GetAttribute("AFTERNOTICEXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strAnaesthesiaXml = objReader.GetAttribute("ANAESTHESIAXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strBodyInfoXml = objReader.GetAttribute("BODYINFOXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strConfirmReason = objReader.GetAttribute("CONFIRMREASON").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strConfirmReasonXMLString = objReader.GetAttribute("CONFIRMREASONXMLSTRING").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseGistXml = objReader.GetAttribute("DIAGNOSEGISTXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiagnoseXml = objReader.GetAttribute("DIAGNOSEXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strDiscussNotionXml = objReader.GetAttribute("DISCUSSNOTIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPatientNotionXml = objReader.GetAttribute("PATIENTNOTIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strPreparationXml = objReader.GetAttribute("PREPARATIONXML").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryInfo.m_strSpecialHandleXml = objReader.GetAttribute("SPECIALHANDLEXML").Replace('き', '\'');

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strInPatientID = p_strInPatientID;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strInPatientDate = p_strInPatientDate;
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOpenDate = objReader.GetAttribute("OPENDATE");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strModifyUserID = objReader.GetAttribute("MODIFYUSERID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strModifyDate = DateTime.Parse(objReader.GetAttribute("MODIFYDATE")).ToString("yyyy-MM-dd HH:mm:ss");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperateDoctorID = objReader.GetAttribute("OPERATEDOCTORID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strChargeDoctorID = objReader.GetAttribute("CHARGEDOCTORID");
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strOperateDoctorName = objReader.GetAttribute("OPERATEDOCTORNAME").Replace('き', '\'').Trim();
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strChargeDoctorName = objReader.GetAttribute("CHARGEDOCTORNAME").Replace('き', '\'').Trim();

                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnose = objReader.GetAttribute("DIAGNOSE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiagnoseGist = objReader.GetAttribute("DIAGNOSEGIST").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strBodyInfo = objReader.GetAttribute("BODYINFO").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strSpecialHandle = objReader.GetAttribute("SPECIALHANDLE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPreparation = objReader.GetAttribute("PREPARATION").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strPatientNotion = objReader.GetAttribute("PATIENTNOTION").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAnaesthesia = objReader.GetAttribute("ANAESTHESIA").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strAfterNotice = objReader.GetAttribute("AFTERNOTICE").Replace('き', '\'');
                                    objclsBeforeOperationSummary_All.m_objclsBeforeOperationSummaryContentInfo.m_strDiscussNotion = objReader.GetAttribute("DISCUSSNOTION").Replace('き', '\'');
                                }
                                break;
                        }
                    }

                }
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		

		#endregion 
		
		#region 更新当前病人当前创建时间上的首次打印时间
		/// <summary>
		/// 更新当前病人当前创建时间上的首次打印时间，仅有一条记录
		/// </summary>		
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,string p_strFirstPrintDate)
		{//更新第一次打印时间		
            clsBeforeOperationSummaryService m_objService =
                (clsBeforeOperationSummaryService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,p_strFirstPrintDate);
            }
            finally
            {
                //m_objService.Dispose();
            }
            return lngRes;
		}
		
		#endregion
	}

//	#region 交互数据用的类
//	/// <summary>
//	/// 
//	/// </summary>
//	[Serializable]
//	public class clsBeforeOperationSummaryInfo
//	{
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strInPatientID;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strInPatientDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strCreateDate;
//		public string m_strOpenDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strCreateID;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDiagnoseXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDiagnoseGistXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strBodyInfoXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strSpecialHandleXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strPreparationXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strPatientNotionXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strAnaesthesiaXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strAfterNoticeXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDiscussNotionXml;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strIfConfirm;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strConfirmReason;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strConfirmReasonXMLString;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strStatus;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDeActivedDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDeActivedOperatorID;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strFirstPrintDate;	
//
//	}
//	
//	/// <summary>
//	/// 
//	/// </summary>
//	[Serializable]
//	public class clsBeforeOperationSummaryContentInfo
//	{
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strInPatientID;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strInPatientDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strOpenDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strModifyDate;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strModifyUserID;
//		
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strOperateDoctorID;
//		public string m_strOperateDoctorName;//存放相应的名称，仅在读出时使用
//		
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strChargeDoctorID;
//		public string m_strChargeDoctorName;//存放相应的名称，仅在读出时使用
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDiagnose;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strDiagnoseGist;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strBodyInfo;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strSpecialHandle;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strPreparation;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strPatientNotion;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strAnaesthesia;
//
//		/// <summary>
//		/// 
//		/// </summary>
//		public string m_strAfterNotice;		
//
//		public string m_strDiscussNotion;
//
//	}
//
//	/// <summary>
//	/// 术前小结所有信息
//	/// </summary>
//	[Serializable]
//	public class clsBeforeOperationSummary_All
//	{
//		public string m_strFirstPrintDate;//首次打印时间
//		public clsBeforeOperationSummaryInfo m_objclsBeforeOperationSummaryInfo;
//		public clsBeforeOperationSummaryContentInfo m_objclsBeforeOperationSummaryContentInfo;
//	}
//	#endregion
}
