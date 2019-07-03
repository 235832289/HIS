using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ItemCatMapping ��ժҪ˵����
	/// </summary>
	public class clsDcl_ItemCatMapping:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ItemCatMapping()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ������listview��ѡ��
		public long m_mthLoadMainListViewItem(out clsChargeItemEXType_VO[] p_objResultArr)
		{
				long lngRes=0;
				com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
				lngRes = objSvc.m_lngFindChargeItemEXTypeListByFlag(objPrincipal,"2",out p_objResultArr);
			objSvc.Dispose();
				return lngRes;
			
		}
		#endregion
		#region �����������
		public long m_mthGetSubjectionCat(out DataTable dt,string strCatID,int flag)
		{
			dt=null;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc));
			lngRes = objSvc.m_mthGetSubjectionCat(objPrincipal,out dt,strCatID,flag);
			objSvc.Dispose();
			return lngRes;

		}
		#endregion
		#region ��������
		public long m_mthSaveData(clsItemCatMapping_VO[] ICM_VO,string strCatID,int flag)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc));
			lngRes = objSvc.m_mthSaveData(objPrincipal,ICM_VO,strCatID,flag);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯҩ����Ϣ
		public long m_mthMedstoreInfo(out DataTable dt,string strExpen)
		{
			dt=null;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc));
			lngRes = objSvc.m_mthMedstoreInfo(objPrincipal,out dt,strExpen);
			objSvc.Dispose();
			return lngRes;
		}

		#endregion
		#region ����ҩ��ID�������
		public long m_mthWindowInfoByID(out DataTable dt,string strExpen)
		{
			dt=null;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsItemCatMappingSvc));
			lngRes = objSvc.m_mthWindowInfoByID(objPrincipal,out dt,strExpen);
			objSvc.Dispose();
			return lngRes;
		}

		#endregion
	}
}
