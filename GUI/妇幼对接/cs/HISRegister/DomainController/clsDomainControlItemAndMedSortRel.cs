using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomainControlItemAndMedSortRel 的摘要说明。
	/// </summary>
	public class clsDomainControlItemAndMedSortRel:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControlItemAndMedSortRel()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public long m_lngGetFeeSort(out DataTable p_outDtResult,out DataTable p_outDtMedType,out DataTable p_outDtMedStorage,out DataTable p_outStorage)
		{
			p_outDtResult = null;
            com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc));
			long lngRes = objSvc.m_lngGetFeeSort(this.objPrincipal,out p_outDtResult,out p_outDtMedType,out p_outDtMedStorage,out p_outStorage);

            objSvc.Dispose();
            objSvc = null;
            return lngRes;
		}
		public long m_lngGetFeeAndMedSortRel(out DataTable p_outDtResult)
		{
			p_outDtResult = null;
            com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc));
				
			long lngRes;
			try
			{
                lngRes = objSvc.m_lngGetFeeAndMedSortRel(this.objPrincipal, out p_outDtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		public long m_lngSaveFeeAndMedSortRel(DataTable p_dtRelation,DataTable p_dtDel)
		{
            com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsFeeAndMedSortRelSvc));
			long lngRes;
			try
			{
				lngRes = objSvc.m_lngSaveFeeAndMedSortRel(this.objPrincipal,p_dtRelation,p_dtDel);	
				p_dtRelation.AcceptChanges();
                p_dtDel = null;
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				lngRes = -1;
			}
			return lngRes;
		}
	}
}
