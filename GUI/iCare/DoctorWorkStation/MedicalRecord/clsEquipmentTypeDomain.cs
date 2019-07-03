using System;
using System.Xml;

namespace iCare
{
	/// <summary>
	/// Summary description for EquipmentTypeDomain.
	/// </summary>
	public class clsEquipmentTypeDomain
	{
        //private com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ;

		public clsEquipmentTypeDomain()
		{
			//
			// TODO: Add constructor logic here
			//
            //objETServ = new com.digitalwave.EquipmentTypeService.clsEquipmentTypeService();

		}

		public long m_lngAddNewRecord(clsEquipmentTypeInfo obj)
		{
            long lngRes = 0;

            com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ =
                (com.digitalwave.EquipmentTypeService.clsEquipmentTypeService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EquipmentTypeService.clsEquipmentTypeService));

			try
            {
                string strXML = "";

			    strXML = "<Patient EquipmentTypeID ='" + obj.strEquipmentTypeID + "' "
				    + "Begin_Type_Date='" + obj.strBegin_Type_Date + "' "
				    + "Status='" + obj.strStatus + "' "
				    + "PYCode='" + obj.strPYCode + "' "
				    + "EquipmentTypeName='" + obj.strEquipmentTypeName + "' "
				    + "OperatorID='" + obj.strOperatorID + "' "
				    + "DeActivedDate='" + obj.strDeActivedDate + "' />" ;

			    lngRes = objETServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strXML);
            }
            finally
            {
                //objETServ.Dispose();
            }
            return lngRes;
		}

		public long m_lngModifyRecord(clsEquipmentTypeInfo obj)
		{
            long lngRes = 0;

            com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ =
                (com.digitalwave.EquipmentTypeService.clsEquipmentTypeService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EquipmentTypeService.clsEquipmentTypeService));

			try
            {
			    string strXML = "";

			    strXML = "<Patient EquipmentTypeID ='" + obj.strEquipmentTypeID + "' "
				    + "Status='" + obj.strStatus + "' "
				    + "EquipmentTypeName='" + obj.strEquipmentTypeName + "' "
				    + "PYCode='" + obj.strPYCode + "' "
				    + "OperatorID='" + obj.strOperatorID + "' "
				    + "DeActivedDate='" + obj.strDeActivedDate + "' />" ;

                lngRes = objETServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strXML, obj.strEquipmentTypeID);
            }
            finally
            {
                //objETServ.Dispose();
            }
            return lngRes;
		}

		public clsEquipmentTypeInfo[] m_clsGetXMLTable(ref int returnrows)
		{
			string strRecievedXML = "";
            long lngSucc = 0;
            clsEquipmentTypeInfo[] EquipmentTypeInfo = null;

            com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ = 
                (com.digitalwave.EquipmentTypeService.clsEquipmentTypeService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EquipmentTypeService.clsEquipmentTypeService));

			try
			{
				lngSucc = objETServ.m_lngGetXMLTable(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,ref strRecievedXML,ref returnrows);
				if(returnrows>0)
				{
					EquipmentTypeInfo = new clsEquipmentTypeInfo[returnrows];
					System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
					doc.LoadXml(strRecievedXML);
					XmlNode root  = doc.DocumentElement;

					for(int i = 0; i<root.ChildNodes.Count; i++)
					{	
						EquipmentTypeInfo[i] = new clsEquipmentTypeInfo();
						EquipmentTypeInfo[i].strEquipmentTypeID = root.ChildNodes[i].Attributes["EQUIPMENTTYPEID"].Value;
						EquipmentTypeInfo[i].strEquipmentTypeName = root.ChildNodes[i].Attributes["EQUIPMENTTYPENAME"].Value;
						EquipmentTypeInfo[i].strPYCode = root.ChildNodes[i].Attributes["PYCODE"].Value;
					}

				}
			}
            finally
            {
                //objETServ.Dispose();
            }
            return EquipmentTypeInfo;

		}

		public string m_strGetRecordCount()
		{
			int p_intReturnRows = 0;
			string strReceivedXML = "";
            string strValue = "";

            com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ =
                (com.digitalwave.EquipmentTypeService.clsEquipmentTypeService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EquipmentTypeService.clsEquipmentTypeService));

            try
            {
                long lngSucc = objETServ.m_lngGetRecordCount(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, ref strReceivedXML, ref p_intReturnRows);
                if (p_intReturnRows == 1)
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(strReceivedXML);
                    strValue = doc.FirstChild.ChildNodes[0].Attributes["ROW"].Value;
                }
            }
            finally
            {
                //objETServ.Dispose();
            }
            return strValue;
		}
	}

	public class clsEquipmentTypeInfo
	{
		public string strEquipmentTypeID;
		public string strBegin_Type_Date;
		public string strEquipmentTypeName;
		public string strPYCode;
		public string strStatus;
		public string strDeActivedDate;
		public string strOperatorID;
	}
}
