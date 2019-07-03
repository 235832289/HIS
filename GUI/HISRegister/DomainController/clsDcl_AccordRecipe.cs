using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
namespace com.digitalwave.iCare.gui.HIS

{
	/// <summary>
	/// clsDcl_AccordRecipe ��ժҪ˵����
	/// </summary>
	public class clsDcl_AccordRecipe:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_AccordRecipe()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region  ѡ����������
		public long m_mthGetAccordRecipeDetail(string ID,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc));
			long lngRes=	objSvc.m_mthGetAccordRecipeDetail(objPrincipal,ID,out dt);
			objSvc.Dispose();
			return lngRes;

		}
		#endregion

		#region ������ҩ������ϸ
		public long m_mthFindWMRecipeDetail(string ID,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc));
			long lngRes=	objSvc.m_mthFindWMRecipeDetail(objPrincipal,ID,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ������ҩ������ϸ
		public long m_mthFindCMRecipeDetail(string ID,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc));
			long lngRes=	objSvc.m_mthFindCMRecipeDetail(objPrincipal,ID,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��������������ϸ
		public long m_mthFindOtherRecipeDetail(string ID,out DataTable dt)
		{
			dt=null;
			com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccordRecipeSvc));
			long lngRes=	objSvc.m_mthFindOtherRecipeDetail(objPrincipal,ID,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
