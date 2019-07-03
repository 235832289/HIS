using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomainControl_RecipeFreq ��ժҪ˵����
	/// </summary>
	public class clsDomainControl_RecipeFreq : com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControl_RecipeFreq()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		
		//��ҩƵ��
		#region ��ȡ��ҩƵ���б�	�Ź���		2004-8-11
		public long m_lngFindRecipeFrequencyeList(out clsRecipefreq_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngFindRecipeFrequencyTypeList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ������ҩƵ��	�Ź���		2004-8-11
		public long m_lngAddRecipeFrequencyType(clsRecipefreq_VO p_objResult,out string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngAddNewRecipeFrequencyType(objPrincipal,p_objResult,out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region �޸���ҩƵ��	�Ź���		2004-8-11
		public long m_lngDoUpdRecipeFrequencyTypeByID(clsRecipefreq_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDoUpdRecipeFrequencyByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ɾ����ҩƵ��	�Ź���		2004-8-11
		public long m_lngDelTRecipeFrequencyTypeByID(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDeleteRecipeFrequencyByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
