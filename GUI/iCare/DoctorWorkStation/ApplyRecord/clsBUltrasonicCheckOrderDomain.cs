using System;
using System.IO ;
using System .Xml ;
using iCareData;
using com.digitalwave.BUltrasonicCheckOrderServ;
using com.digitalwave.SPECTCheckOrderServ;

namespace iCare
{
	/// <summary>
	/// Summary description for clsBUltrasonicCheckOrderDomain.
	/// </summary>
	public class clsBUltrasonicCheckOrderDomain
	{
		#region Member
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
		/// <summary>
		/// 
		/// </summary>
        //private clsBUltrasonicCheckOrderServ m_objServ;
		#endregion

		#region Constructor
		public clsBUltrasonicCheckOrderDomain()
		{
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);

            //m_objServ = new clsBUltrasonicCheckOrderServ();
		}
		#endregion

		#region 读取初始化信息
		/// <summary>
		/// 获得所有CreateDate
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;

            clsBUltrasonicCheckOrderServ m_objServ =
                (clsBUltrasonicCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBUltrasonicCheckOrderServ));

			DateTime[] dtmCreateRecordDateArr = null;

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
		#endregion

		public long m_lngDeactive(string p_strDeactiveUserID,string p_strInPatientID,string p_strInPatientDate,
			string p_strCreateDate)
		{
            clsSPECTCheckOrderServ m_objServ =
                (clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSPECTCheckOrderServ));

            long lngRes = 0;
            try
            {
			    string strDeactiveXML = "<Deactive Status='1' DeActivedOperatorID='"+p_strDeactiveUserID+"' InPatientID='"+p_strInPatientID +"'"+" InPatientDate='"+p_strInPatientDate+ "'" +" CreateDate='"+p_strCreateDate+"'" +" />";
                lngRes = m_objServ.m_lngDeActive(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strDeactiveXML, "BUltrasonicCheckOrder");
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}

		//添加两个参数：RequestImage,ApplicationID。
		public long m_lngSave(clsBUltrasonicCheckOrder p_objBUltraCheckOrder,
							  ImageRequest p_objImageRequest,ref string p_strApplicationID,bool p_bnlIsNew)

		{	
			string m_strApplicationID="";
			long m_lngRe = 0;

            clsBUltrasonicCheckOrderServ m_objServ =
                (clsBUltrasonicCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBUltrasonicCheckOrderServ));
			
			    if(p_objBUltraCheckOrder == null)
				    return -1;
			    else
				    if(p_bnlIsNew==false)
					    m_strApplicationID=p_objBUltraCheckOrder.m_strApplicationID ;


            try
            {
			    string strOrderXML = m_strOrderXML(p_objBUltraCheckOrder);
                			
			    m_lngRe=m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strOrderXML,
										     p_objImageRequest,ref m_strApplicationID,p_bnlIsNew);

			    p_strApplicationID=m_strApplicationID;
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return m_lngRe;


		}

		private string m_strOrderXML(clsBUltrasonicCheckOrder p_objBUltraCheckOrder)
		{
			if(p_objBUltraCheckOrder == null)
				return null;
			m_objXmlWriter.Flush();
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");

			m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objBUltraCheckOrder.m_strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objBUltraCheckOrder.m_strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objBUltraCheckOrder.m_strCreateDate.Replace('\'','き'));
//			m_objXmlWriter.WriteAttributeString("MODIFYDATE", p_objBUltraCheckOrder.m_strModifyDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", p_objBUltraCheckOrder.m_strCreateUserID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", p_objBUltraCheckOrder.m_strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", p_objBUltraCheckOrder.m_strIfConfirm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERDEPTID", p_objBUltraCheckOrder.m_strCreateUserDeptID.Replace('\'','き'));

			m_objXmlWriter.WriteAttributeString("CHECKNUMBER", p_objBUltraCheckOrder.m_strCheckNumber.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HISTORY", p_objBUltraCheckOrder.m_strHistory.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODYCHECK", p_objBUltraCheckOrder.m_strBodyCheck.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("XRAY", p_objBUltraCheckOrder.m_strXRay.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("XRAYDATE", p_objBUltraCheckOrder.m_strXRayDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("XRAYNUMBER", p_objBUltraCheckOrder.m_strXRayNumber.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LABCHECK", p_objBUltraCheckOrder.m_strLabCheck.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OTHERCHECK", p_objBUltraCheckOrder.m_strOtherCheck.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CLINICALDISGONSE", p_objBUltraCheckOrder.m_strClinicalDisgonse.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKPLACE", p_objBUltraCheckOrder.m_strCheckPlace.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PATHOLYDISGONSEDATE", p_objBUltraCheckOrder.m_strPatholyDisgonseDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONDATE", p_objBUltraCheckOrder.m_strOperationDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONINFORMATION", p_objBUltraCheckOrder.m_strOperationInformation.Replace('\'','き'));

			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}


		/// <summary>
		/// 获取主表的信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public clsBUltrasonicCheckOrder  m_objGetBUltrasonicCheckOrder(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{ 
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return null;

            clsBUltrasonicCheckOrderServ m_objServ =
                (clsBUltrasonicCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBUltrasonicCheckOrderServ));

			clsBUltrasonicCheckOrder  objBUltrasonicCheckOrder = null;

            try
            {
                string strXml = "";
                int intRows = 0;

                long lngRes = m_objServ.GetBUltrasonicCheckOrder(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, ref strXml, ref intRows);

                if (lngRes > 0 && intRows > 0)
                {

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    objBUltrasonicCheckOrder = new clsBUltrasonicCheckOrder();

                                    objBUltrasonicCheckOrder.m_strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strCreateDate = objReader.GetAttribute("CREATEDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strStatus = objReader.GetAttribute("STATUS").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strIfConfirm = objReader.GetAttribute("IFCONFIRM").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strConfirmReason = objReader.GetAttribute("CONFIRMREASON").ToString().Replace('き', '\''); ;
                                    objBUltrasonicCheckOrder.m_strConfirmReasonXML = objReader.GetAttribute("CONFIRMREASONXML").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strCreateUserID = objReader.GetAttribute("CREATEUSERID").ToString().Replace('き', '\'');

                                    objBUltrasonicCheckOrder.m_strCheckNumber = objReader.GetAttribute("CHECKNUMBER").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strHistory = objReader.GetAttribute("HISTORY").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strBodyCheck = objReader.GetAttribute("BODYCHECK").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strXRay = objReader.GetAttribute("XRAY").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strXRayDate = objReader.GetAttribute("XRAYDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strXRayNumber = objReader.GetAttribute("XRAYNUMBER").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strLabCheck = objReader.GetAttribute("LABCHECK").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strOtherCheck = objReader.GetAttribute("OTHERCHECK").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strClinicalDisgonse = objReader.GetAttribute("CLINICALDISGONSE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strCheckPlace = objReader.GetAttribute("CHECKPLACE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strPatholyDisgonseDate = objReader.GetAttribute("PATHOLYDISGONSEDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strOperationDate = objReader.GetAttribute("OPERATIONDATE").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strOperationInformation = objReader.GetAttribute("OPERATIONINFORMATION").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strCreateUserDeptID = objReader.GetAttribute("CREATEUSERDEPTID").ToString().Replace('き', '\'');
                                    objBUltrasonicCheckOrder.m_strApplicationID = objReader.GetAttribute("APPLICATIONID").ToString().Replace('き', '\'');
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
			return objBUltrasonicCheckOrder;
            
		}
	}

	/// <summary>
	/// 表信息
	/// </summary>
	public class clsBUltrasonicCheckOrder
	{
		public string m_strInPatientID = "";
		public string m_strInPatientDate = "";
		public string m_strCreateDate = "";
		public string m_strModifyDate = "";

		public string m_strCreateUserDeptID = "";
		public string m_strCreateUserID = "";
		public string m_strIfConfirm = "";
		public string m_strConfirmReason = "";
		public string m_strConfirmReasonXML = "";
		public string m_strFirstPrintDate = "";
		public string m_strDeActivedDate = "";
		public string m_strDeActivedOperatorID = "";
		public string m_strStatus = "";

		public string m_strCheckNumber = "";
		public string m_strHistory = "";
		public string m_strBodyCheck = "";
		public string m_strXRay = "";
		public string m_strXRayDate = "";
		public string m_strXRayNumber = "";
		public string m_strLabCheck = "";
		public string m_strOtherCheck = "";
		public string m_strClinicalDisgonse = "";
		public string m_strCheckPlace = "";
		public string m_strPatholyDisgonseDate = "";
		public string m_strOperationDate = "";
		public string m_strOperationInformation = "";
		public string m_strApplicationID="";
	}
}
