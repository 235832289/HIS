using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	public class clsSchQCBatchSmp
	{
		#region Property
		public static clsSchQCBatchSmp s_object
		{
			get
			{
				return new clsSchQCBatchSmp();
			}
		}
		#endregion

		#region Parameters

		private com.digitalwave.iCare.middletier.LIS.clsSchQCBatchSvc m_objSvc;
		private System.Security.Principal.IPrincipal m_objPrincipal;

		#endregion

		#region Construtor
        public clsSchQCBatchSmp()
		{
            m_objSvc = (com.digitalwave.iCare.middletier.LIS.clsSchQCBatchSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsSchQCBatchSvc));
			m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
		}
		#endregion        

        public long m_lngFindQCBatchCombinatorial(clsLisQCBatchSchVO p_objCondition, out clsLisQCBatchVO[] p_objRecordArr)
        {
            p_objRecordArr = null;
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngFindQCBatchCombinatorial(m_objPrincipal,p_objCondition, out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
	}
}