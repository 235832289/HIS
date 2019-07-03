using System;
using System.Xml;

using com.digitalwave.PICUShiftService;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsPICUShiftInDomain.
	/// </summary>
	public class clsPICUShiftOutDomain : clsPICUShiftBaseDomain
	{
		public clsPICUShiftOutDomain()
		{
		}

		protected override long m_lngSubAddNew(string p_strMainXml, string p_strContentXml)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strMainXml,p_strContentXml);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		protected override long m_lngSubModify(string p_strMainXml, string p_strContentXml)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strMainXml,p_strContentXml);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public override long m_lngCheckNewCreateDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out bool p_blnIsAddNew)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngCheckNewCreateDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_blnIsAddNew);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		protected override long m_lngSubGetPICUShiftInfo(string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate, ref string p_strResultXml, ref int p_intResultRows)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetPICUShiftInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,ref p_strResultXml,ref p_intResultRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		protected override long m_lngSubGetDeletedPICUShiftInfo(string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate, ref string p_strResultXml, ref int p_intResultRows)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetDeletedPICUShiftInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,ref p_strResultXml,ref p_intResultRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public override long m_lngCheckLastModifyDate(string p_strInPatientID, string p_strInPatientDate, string p_strCreateDate, string p_strLastModifyDate, out bool p_blnIsLast)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngCheckLastModifyDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,p_strLastModifyDate,out p_blnIsLast);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		protected override clsPICUShiftTurnInfo m_objGetTurnInfo()
		{
			return new clsPICUShiftOutTurnInfo();
		}
	
		protected override long m_lngSubGetCreateDateArr(string p_strInPatientID,string p_strInPatientDate,ref string p_strResultXml,ref int p_intResultRows)
		{
            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetPatientShiftInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,ref p_strResultXml,ref p_intResultRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public clsDepartment m_objGetPatientLastFromDept(clsPatient p_objPatient)
		{
			string strXML = "";
			int intRows = 0;

            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetPatientLastFromDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objPatient.m_StrInPatientID,p_objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),ref strXML,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(strXML);

				clsDepartment objDept = new clsDepartment();
				objDept.m_StrDeptID = xmlDoc.DocumentElement.FirstChild.Attributes[0].Value;
			
				return objDept;
			}
			return null;
		}

		/// <summary>
		/// 删除记录。
		/// </summary>
		/// <param name="p_objRecordContent">当前要删除的记录</param>
		/// <param name="p_objModifyInfo">若当前要删除的记录不是最新的记录,返回该最新记录的操作信息,否则为空</param>
		/// <returns></returns>
		public override long m_lngDeleteRecord(clsTrackRecordContent p_objRecordContent,		
			out clsPreModifyInfo p_objModifyInfo)
		{
			p_objModifyInfo=null;
			//参数判断
			if(p_objRecordContent==null)
				return (long)enmOperationResult.Parameter_Error;

            clsPICUShiftOutService m_objServ =
                (clsPICUShiftOutService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPICUShiftOutService));

			long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent,out p_objModifyInfo);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	}

	[Serializable]
	public class clsPICUShiftOutTurnInfo : clsPICUShiftTurnInfo
	{
		public override bool m_BlnIsShiftIn
		{
			get
			{
				return false;
			}
		}

		public override void m_mthMakeContentXML(XmlTextWriter p_objXmlWriter)
		{
			p_objXmlWriter.WriteAttributeString("INPATIENTID",m_strInPatientID);
			p_objXmlWriter.WriteAttributeString("INPATIENTDATE",m_strINPATIENTDATE);
			p_objXmlWriter.WriteAttributeString("CREATEDATE",m_dtmTurnTime.ToString("yyyy-MM-dd HH:mm:ss"));

			if(m_strTurnToDeptID != null)
			{
				p_objXmlWriter.WriteAttributeString("TURNTODEPTID",m_strTurnToDeptID);
			}

			if(m_strTurnToEmployeeID != null)
			{
				p_objXmlWriter.WriteAttributeString("TURNTODOCTORID",m_strTurnToEmployeeID);
			}
			
		}

		public override void m_mthSetValue(XmlTextReader p_objReader)
		{
			m_dtmTurnTime = DateTime.Parse(p_objReader.GetAttribute("CREATEDATE"));
			m_strTurnFromEmployeeID = new clsEmployee(p_objReader.GetAttribute("CREATEID")).m_StrEmployeeID;
//			m_strTurnFromDeptID = m_objTurnFromDoctor.m_ObjDepartment;

			
			m_strTurnToDeptID = p_objReader.GetAttribute("TURNTODEPTID");

			if(p_objReader.GetAttribute("TURNTODOCTORID") != DBNull.Value.ToString())
			{
				m_strTurnToEmployeeID = new clsEmployee(p_objReader.GetAttribute("TURNTODOCTORID")).m_StrEmployeeID;
			}
		}
	}
}
