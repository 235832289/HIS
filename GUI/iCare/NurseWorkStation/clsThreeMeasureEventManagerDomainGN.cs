using System;
using System.Xml;
using System.IO;
using System.Text;
using iCare;
using com.digitalwave.ThreeMeasureEventManagerService;
using System.Windows.Forms;

namespace HRP
{
	/// <summary>
	/// 领域层

	/// </summary>
	public class  clsThreeMeasureEventManagerDomainGN
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
		public  clsThreeMeasureEventManagerDomainGN()
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

			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTID",p_objInfo.m_strThreeMeasureEventID);
			m_objXmlWriter.WriteAttributeString("BEGINEVENTDATE",p_objInfo.m_strBeginEventDate);
			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTNAME",p_objInfo.m_strThreeMeasureEventName);
			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTFLAG",p_objInfo.m_strThreeMeasureEventFlag);
//			m_objXmlWriter.WriteAttributeString("STATUS",p_objInfo.m_strStatus);
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

			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTID",p_objInfo.m_strThreeMeasureEventID);
			m_objXmlWriter.WriteAttributeString("BEGINEVENTDATE",p_objInfo.m_strBeginEventDate);
			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTNAME",p_objInfo.m_strThreeMeasureEventName);
			m_objXmlWriter.WriteAttributeString("THREEMEASUREEVENTFLAG",p_objInfo.m_strThreeMeasureEventFlag);
			m_objXmlWriter.WriteAttributeString("STATUS",p_objInfo.m_strStatus);
			m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE",p_objInfo.m_strDeActivedDate);
			m_objXmlWriter.WriteAttributeString("OPERATORID",p_objInfo.m_strOperatorID);
			
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
			string strID=m_strGetMaxThreeMeasureEventID();
			p_objNewInfo.m_strThreeMeasureEventID=strID;
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
		/// 

		public string m_strGetMaxThreeMeasureEventID()
		{
            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            string strRes = "";
			try
            {
                strRes = m_objThreeMeasureEventManagerServ.m_strGetMaxThreeMeasureEventID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }
            return strRes;
		}
		public long m_lngDelete(clsThreeMeasureEventInfo p_objOldInfo,string p_strOperatorID)
		{
            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
			try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strMakeOldXml(p_objOldInfo, p_strOperatorID));
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
            if (lngRes > 0 && intRows > 0)
            {
                objInfoArr = m_objGetThreeMeasureEventInfoFromXml(strXML, intRows);

            }
            else
            {
                objInfoArr = new clsThreeMeasureEventInfo[0];
            }
			return objInfoArr;
		}
        public clsThreeMeasureEventInfo[] m_objGetThreeMeasureEventInfoByType(string p_strFlag)
        {
            string strXML = "";
            int intRows = 0;

            clsThreeMeasureEventManagerService m_objThreeMeasureEventManagerServ =
                (clsThreeMeasureEventManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureEventManagerService));

            long lngRes = 0;
            try
            {
                lngRes = m_objThreeMeasureEventManagerServ.m_lngGetEventItemByType(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strFlag, ref strXML, ref intRows);
            }
            finally
            {
                //m_objThreeMeasureEventManagerServ.Dispose();
            }

            clsThreeMeasureEventInfo[] objInfoArr = null;
            if (lngRes > 0 && intRows > 0)
            {
                objInfoArr = m_objGetThreeMeasureEventInfoFromXml(strXML, intRows);

            }
            else
            {
                objInfoArr = new clsThreeMeasureEventInfo[0];
            }
            return objInfoArr;
        }
        private clsThreeMeasureEventInfo[] m_objGetThreeMeasureEventInfoFromXml(string strXML, int intRows)
        {
            clsThreeMeasureEventInfo[] objInfoArr = null;
            objInfoArr = new clsThreeMeasureEventInfo[intRows];

            XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
            objReader.WhitespaceHandling = WhitespaceHandling.None;

            int intIndex = 0;
            while (objReader.Read())
            {
                switch (objReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (objReader.HasAttributes)
                        {
                            objInfoArr[intIndex] = new clsThreeMeasureEventInfo();
                            objInfoArr[intIndex].m_strThreeMeasureEventID = objReader.GetAttribute("THREEMEASUREEVENTID");
                            objInfoArr[intIndex].m_strBeginEventDate = objReader.GetAttribute("BEGINEVENTDATE");
                            objInfoArr[intIndex].m_strThreeMeasureEventName = objReader.GetAttribute("THREEMEASUREEVENTNAME").Replace("き", "\'");
                            objInfoArr[intIndex].m_strThreeMeasureEventFlag = objReader.GetAttribute("THREEMEASUREEVENTFLAG");
                            objInfoArr[intIndex].m_strStatus = objReader.GetAttribute("STATUS");
                            objInfoArr[intIndex].m_strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE");
                            objInfoArr[intIndex].m_strOperatorID = objReader.GetAttribute("OPERATORID");

                            intIndex++;
                        }
                        break;
                }
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

//				for(int i=0;i<objXMLDoc.DocumentElement.ChildNodes.Count;i++)	
//				{
//					p_objInfo.m_strThreeMeasureEventID = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTID"].Value;
//					p_objInfo.m_strBeginEventDate = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["BEGINEVENTDATE"].Value;
//					p_objInfo.m_strThreeMeasureEventName = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTNAME"].Value;
//					p_objInfo.m_strThreeMeasureEventFlag = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["THREEMEASUREEVENTFLAG"].Value;
//					p_objInfo.m_strStatus = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["STATUS"].Value;
//					p_objInfo.m_strDeActivedDate = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["DEACTIVEDDATE"].Value;
//					p_objInfo.m_strOperatorID = objXMLDoc.DocumentElement.ChildNodes[i].Attributes["OPERATORID"].Value;
//				}
				
			}			
		}

        /// <summary>
        /// 添加特殊记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="p_strEventFlag"></param>
        public void m_mthEventAddItem(object sender, EventArgs e, string p_strEventFlag)
        {
            MenuItem mniEvent = sender as MenuItem;
            com.digitalwave.Utility.Controls.ctlComboBox cboEvent = mniEvent.GetContextMenu().SourceControl as com.digitalwave.Utility.Controls.ctlComboBox;
            if (cboEvent == null)
                return;
            clsThreeMeasureEventInfo objEvent = new clsThreeMeasureEventInfo();
            if (objEvent == null)
                return;
            objEvent.m_strThreeMeasureEventID = m_strGetMaxThreeMeasureEventID();
            objEvent.m_strThreeMeasureEventName = cboEvent.Text.Trim();
            objEvent.m_strBeginEventDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objEvent.m_strStatus = "0";
            objEvent.m_strThreeMeasureEventFlag = p_strEventFlag;
            objEvent.m_strOperatorID = clsEMRLogin.LoginInfo.m_strEmpID;
            long lngRes = m_lngAddNew(objEvent);
        }
        /// <summary>
        /// 删除特殊记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="p_strEventFlag"></param>
        public void m_mthEventDeleteItem(object sender, System.EventArgs e, string p_strEventFlag)
        {
            MenuItem mniEvent = sender as MenuItem;
            com.digitalwave.Utility.Controls.ctlComboBox cboEvent = mniEvent.GetContextMenu().SourceControl as com.digitalwave.Utility.Controls.ctlComboBox;
            if (cboEvent == null)
                return;

            clsThreeMeasureEventInfo objEvent = (clsThreeMeasureEventInfo)cboEvent.SelectedItem;
            if (objEvent == null)
                return;
            objEvent.m_strStatus = "1";
            objEvent.m_strThreeMeasureEventFlag = p_strEventFlag;
            objEvent.m_strOperatorID = clsEMRLogin.LoginInfo.m_strEmpID;
            objEvent.m_strDeActivedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            long lngRes = m_lngDelete(objEvent, clsEMRLogin.LoginInfo.m_strEmpID);
        }
        /// <summary>
        /// 修改特殊记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="p_strEventFlag"></param>
        public void m_mthEventModifyItem(object sender, System.EventArgs e, string p_strEventFlag)
        {
            MenuItem mniEvent = sender as MenuItem;
            com.digitalwave.Utility.Controls.ctlComboBox cboEvent = mniEvent.GetContextMenu().SourceControl as com.digitalwave.Utility.Controls.ctlComboBox;
            if (cboEvent == null)
                return;
            clsThreeMeasureEventInfo objEvent = (clsThreeMeasureEventInfo)cboEvent.SelectedItem;
            if (objEvent == null)
                return;
            clsThreeMeasureEventInfo objEventNew = (clsThreeMeasureEventInfo)cboEvent.SelectedItem;
            objEventNew.m_strThreeMeasureEventName = cboEvent.Text.Trim();
            objEventNew.m_strStatus = "0";
            objEvent.m_strThreeMeasureEventFlag = p_strEventFlag;
            objEventNew.m_strOperatorID = clsEMRLogin.LoginInfo.m_strEmpID;
            long lngRes = m_lngModify(objEvent, objEventNew, clsEMRLogin.LoginInfo.m_strEmpID);
        }

        public void m_cmthEventItem_DropDown(object sender, System.EventArgs e, string p_strEventFlag)
        {
            com.digitalwave.Utility.Controls.ctlComboBox cboEvent = sender as com.digitalwave.Utility.Controls.ctlComboBox;
            cboEvent.ClearItem();
            clsThreeMeasureEventInfo[] objEvents = m_objGetThreeMeasureEventInfoByType(p_strEventFlag);

            for (int i = 0 ; i < objEvents.Length ; i++)
            {
                cboEvent.AddItem(objEvents[i]);
            }
        }


	}	

}
