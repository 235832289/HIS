using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ReckoningReport ��ժҪ˵����
	/// </summary>
	public class clsDcl_StstemSeting:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_StstemSeting()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ���ģ����Ϣ  xigui.peng 2005-12-3

		public long m_lngGetLeftInfo(out  DataTable p_dtInfo)
		{
		 com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc objSvc=
			 (com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc));
			long lngRegs = objSvc.m_lngGetLeftInfo(objPrincipal,out p_dtInfo);
			objSvc.Dispose();
			return lngRegs;
		}
		#endregion
		#region ϵͳ���������б�  �Ź���  2005-2-23
		public long m_lngStstemSeting(out System.Data.DataTable p_tabReport)
		{
			com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc));
			long lngRes = objSvc.m_lngStstemSeting(objPrincipal,out p_tabReport);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸�״̬  �Ź���  2005-2-23
		public long m_lngModifyStstemSeting(string p_strID,string p_strStatue,string p_strModuleID)
		{
			com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsStstemSetingSvc));
			long lngRes = objSvc.m_lngModifyStstemSeting(objPrincipal,p_strID,p_strStatue,p_strModuleID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

	}
}