using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_AppGroupManage ��ժҪ˵����
	/// ���� 2004.05.26
	/// </summary>
	public class clsDomainController_AppGroupManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsDomainController_AppGroupManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ��ѯ���е��Զ������������Ϣ ͯ�� 2004.09.14
		public long m_lngGetAllApplUserGroupRelation(out clsApplUserGroupRelation_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetAllApplUserGroupRelation(objPrincipal,out p_objResultArr);
			//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region ��ѯ���е�һ���Զ�������Ϣ
       
        public long m_lngGetMasterUserGroup(out clsApplUserGroup_VO[] objApplUserGroupList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
            lngRes = objCheckGroupSvc.m_lngGetMasterUserGroup(objPrincipal, out objApplUserGroupList);
            //objCheckGroupSvc.Dispose();
            return lngRes;
        }
       
        #endregion

		#region ��ѯĳ���Զ�������(�����Զ�����)�����м�����Ŀ��ϸ ͯ�� 2004.05.28
		public long m_lngGetCheckItemApplGroupDetailByApplUserGroupID(string strApplUserGroupID,out DataTable dtbCheckItem)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetCheckItemInApplGroupDetailByApplUserGroupID(objPrincipal,strApplUserGroupID,out dtbCheckItem);
			//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ѯĳ���Զ�������(���Զ�����)�����м�����Ŀ��ϸ ͯ�� 2004.05.28
		public long m_lngGetCheckItemApplGroupRelationByApplUserGroupID(string strApplUserGroupID,out DataTable dtbCheckItem)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetCheckItemApplGroupRelationByApplUserGroupID(objPrincipal,strApplUserGroupID,out dtbCheckItem);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ���Զ�����Ĺ�ϵ������ϸ ͯ�� 2004.05.28
		public long m_lngDelApplUserGroupDetailAndRelation(string strApplUserGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngDelApplUserGroupDetailAndRelation(objPrincipal,strApplUserGroupID);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ���Զ������������Ϣ ͯ�� 2004.05.28
		public long m_lngDelApplUserGroupInfo(string strApplUserGroup,string strParentUserGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngDelApplUserGroupInfo(objPrincipal,strApplUserGroup,strParentUserGroupID);
			//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ�Զ������µ��������뵥ԪID ͯ�� 2004.05.28
		public long m_lngGetAllUserGroupApplUnitID(out DataTable dtbApplUnitID)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetAllUserGroupApplUnitID(objPrincipal,out dtbApplUnitID);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �����û��Զ����鼰����ϸ�͹�ϵ��Ϣ ͯ�� 2004.05.27
		public long m_lngAddApplUserGroupAndDetailRelation(ref clsApplUserGroup_VO objApplUserGroupVO,ref clsApplUserGroupDetail_VO[] objApplUserGroupDetailVOList,
			ref clsApplUserGroupRelation_VO[] objApplUserGroupRelationVOList,clsApplUserGroupRelation_VO p_objParentRelation)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc objAppGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngAddApplUserGroupAndDetail(objPrincipal,ref objApplUserGroupVO,ref objApplUserGroupDetailVOList,
				ref objApplUserGroupRelationVOList,p_objParentRelation);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �����û��Զ���ID��ѯ��������������뵥Ԫ ͯ�� 2004.05.26
		public long m_lngGetApplUnitByUserGroupID(string strUserGroupID,out clsApplUnit_VO[] objApplUnit)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetApplUnitByUserGroupID(objPrincipal,strUserGroupID,out objApplUnit);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �����û��Զ���ID��ѯ��������������� ͯ�� 2004.05.26
		public long m_lngGetSubGroupByUserGroupID(string strUserGroupID,out clsApplUserGroup_VO[] objApplUserGroupVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc objAppGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryAppGroupSvc));
			lngRes = objAppGroupSvc.m_lngGetChildGroupByUserGroupID(objPrincipal,strUserGroupID,out objApplUserGroupVOList);
//			objAppGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���е��û��Զ����� ͯ�� 2004.05.26
		public long m_lngGetAllUserGroup(out clsApplUserGroup_VO[] objApplUserGroupList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllUserGroup(objPrincipal,out objApplUserGroupList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
