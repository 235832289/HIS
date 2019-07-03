using System;
using com.digitalwave.DeactiveRecordService;
using iCareData;


namespace iCare
{
	/// <summary>
	/// Summary description for clsDeactiveRecordDomain.
	/// </summary>
	public class clsDeactiveRecordDomain
	{
		public clsDeactiveRecordDomain()
		{
			
		}

		public long m_lngGetDeactiveFormInfo(out clsDeactiveFormInfo[] p_objFormInfoArr)
		{
            com.digitalwave.DeactiveRecordService.clsDeactiveRecordService m_objServ =
                (com.digitalwave.DeactiveRecordService.clsDeactiveRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DeactiveRecordService.clsDeactiveRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetDeactiveFormInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out p_objFormInfoArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public long m_lngGetDeactiveInfo(string p_strInPatientID,string p_strInPatientDate,int p_intFormID,out clsDeactiveInfo [] p_objDeactiveInfoArr)
		{
            com.digitalwave.DeactiveRecordService.clsDeactiveRecordService m_objServ =
                (com.digitalwave.DeactiveRecordService.clsDeactiveRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DeactiveRecordService.clsDeactiveRecordService));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetDeactiveInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_intFormID, out p_objDeactiveInfoArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	}
}
