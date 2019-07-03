using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	public class clsBnsQCBatchSmp
	{
		#region Property
		public static clsBnsQCBatchSmp s_object
		{
			get
			{
				return new clsBnsQCBatchSmp();
			}
		}
		#endregion

		#region Parameters

		private com.digitalwave.iCare.middletier.LIS.clsBnsQCBatchSvc m_objSvc;
		private System.Security.Principal.IPrincipal m_objPrincipal;

		#endregion

		#region Construtor
        public clsBnsQCBatchSmp()
		{
            m_objSvc = (com.digitalwave.iCare.middletier.LIS.clsBnsQCBatchSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsBnsQCBatchSvc));
			m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
		}
		#endregion       
	}
}