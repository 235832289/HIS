using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_OPLog ��ժҪ˵����
	/// </summary>
	public class clsDcl_OPLog:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_OPLog()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public long m_mthLogData(out DataTable dt,string strEx,string strICDCode)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsOPLogSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPLogSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPLogSvc));
			long lngRes = objSvc.m_mthLogData(out dt,strEx,strICDCode);
			objSvc.Dispose();
			return lngRes;
		}
	}
}
