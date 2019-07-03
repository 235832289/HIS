using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	#region 基本检验组的抽象，封装基本检验组自身的逻辑 刘彬 2004.05.07
	/// <summary>
	/// 基本检验组的抽象，封装基本检验组自身的逻辑
	/// 刘彬 2004.05.07
	/// </summary>
	public class clsDomainController_BaseCheckGroup:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		private string m_strBaseCheckGroupID;
		public clsDomainController_BaseCheckGroup(string p_strBaseCheckGroupID)
		{
			m_strBaseCheckGroupID = p_strBaseCheckGroupID;
		}

		#region 根据样本的类型ID查询所有可能做的基本检验组
		/// <summary>
		/// 根据样本的类型ID查询所有可能做的基本检验组
		/// </summary>
		/// <param name="p_strSampleTypeID"></param>
		/// <param name="p_dtbGroup"></param>
		/// <returns></returns>
		public static long s_lngGetBaseCheckGroupBySampleTypeID(string p_strSampleTypeID,out System.Data.DataTable p_dtbGroup)
		{
			p_dtbGroup = null;
			long lngRet = 0;
			System.Security.Principal.IPrincipal objPrinipal = null;
			try
			{
				com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc objCheckSvc = (com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc));
				lngRet = objCheckSvc.m_lngGetBaseCheckGroupBySampleTypeID(objPrinipal,p_strSampleTypeID,out p_dtbGroup);
			}
			catch(Exception ex)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(ex);
			}
			return lngRet;
		}
		#endregion

		#region 根据基本检验组ID查找能做这组检验的所有的仪器类型ID 
		/// <summary>
		/// 根据基本检验组ID查找能做这组检验的所有的仪器类型ID 刘彬
		/// </summary>
		/// <param name="p_objPrinipal"></param>
		/// <param name="p_strBaseCheckGroupID"></param>
		/// <param name="p_dtbDeviceModel"></param>
		/// <returns>
		/// DEVICE_MODEL_ID_CHR
		/// DEVICE_MODEL_DESC_VCHR
		/// </returns>
		public static long s_lngGetDeviceModelByBaseCheckGroupID(string p_strBaseCheckGroupID,out System.Data.DataTable p_dtbDeviceModel)
		{
			long lngRes = 0;
			p_dtbDeviceModel = null;
			System.Security.Principal.IPrincipal objPrinipal = null;	

			try
			{
				com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc objCheckSvc = (com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsBaseCheckGroupSvc));
				lngRes = objCheckSvc.m_lngGetDeviceModelByBaseCheckGroupID(objPrinipal,p_strBaseCheckGroupID,out p_dtbDeviceModel);
			}
			catch(Exception ex)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(ex);
			}
			return lngRes;
		}
		public long m_lngGetDeviceModelByBaseCheckGroupID(out System.Data.DataTable p_dtbDeviceModel)
		{
			return clsDomainController_BaseCheckGroup.s_lngGetDeviceModelByBaseCheckGroupID(m_strBaseCheckGroupID,out p_dtbDeviceModel);
		}
		#endregion

	}
	#endregion

	public class clsDomainController_LisCheckGroupManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 获取所有的标本组列表 童华 2004.05.24
		public long m_lngGetAllSampleGroup(out com.digitalwave.iCare.ValueObject.clsSampleGroup_VO[] objSampleGroupVOList)
		{
			long lngRes = 0;
			objSampleGroupVOList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllSampleGroup(objPrincipal,ref objSampleGroupVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的报告组及其明细资料 童华 2004.05.25(go)
		public long m_lngGetAllReportGroup(out com.digitalwave.iCare.ValueObject.clsReportGroup_VO[] objReportGroupVOList)
		{
			long lngRes = 0;
			objReportGroupVOList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllReportGroup(objPrincipal,ref objReportGroupVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取某一标本组下的所有检验项目信息 童华 2004.05.25(go)
		public long m_lngGetCheckItemBySampleGroupID(string strSampleGroupID,out DataTable dtbCheckItem)
		{
			long lngRes = 0;
			dtbCheckItem = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemBySampleGroupID(objPrincipal,strSampleGroupID,out dtbCheckItem);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 保存标本组及其明细 童华 2004.05.25(go)
		public long m_lngAddSampleGroup(ref clsSampleGroup_VO objSampleGroupVO,ref clsSampleGroupDetail_VO[] objSampleGroupDetailVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngAddSampleGroupAndDetail(objPrincipal,ref objSampleGroupVO,ref objSampleGroupDetailVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除标本组及其明细 童华 2004.05.25(go)
		public long m_lngDelSampleGroupAndDetail(string strSampleGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngDelSampleGroupAndDetail(objPrincipal,strSampleGroupID);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除检验组明细 童华 2004.05.25(go)
		public long m_lngDelSampleGroupDetail(string strSampleGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngDelSampleGroupDetail(objPrincipal,strSampleGroupID);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 保存报告组及其明细 童华 2004.05.26(go)
		public long m_lngAddReportGroupAndDetail(ref clsReportGroup_VO objReportGroupVO,ref clsReportGroupDetail_VO[] objReportGroupDetailVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngAddReportGroupAndDetail(objPrincipal,ref objReportGroupVO,ref objReportGroupDetailVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除报告组及其明细 童华 2004.05.26(go)
		public long m_lngDelReportGroupAndDetail(string strReportGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngDelReportGroupAndDetail(objPrincipal,strReportGroupID);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除报告组明细 童华 2004.05.26(go)
		public long m_lngDelReportGroupDetail(string strReportGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngDelReportGroupDetail(objPrincipal,strReportGroupID);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的标本组明细列表 童华 2004.05.26(go)
		public long m_lngGetAllSampleGroupDetail(out clsSampleGroupDetail_VO[] objSampleGroupDetailVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllSampleGroupDetail(objPrincipal,out objSampleGroupDetailVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的报告组明细列表 童华 2004.05.26(go)
		public long m_lngGetAllReportGroupDetail(out clsReportGroupDetail_VO[] objReportGroupDetailVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllReportGroupDetail(objPrincipal,out objReportGroupDetailVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的申请单元 童华 2004.05.26
		public long m_lngGetAllApplUnit(out clsApplUnit_VO[] objApplUnitVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllApplUnit(objPrincipal,out objApplUnitVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的用户自定义组 童华 2004.05.26(转移)
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

		#region 根据用户自定义ID查询其包含的所有申请单元 童华 2004.05.26(已转移)
		public long m_lngGetApplUnitByUserGroupID(string strUserGroupID,out clsApplUnit_VO[] objApplUnit)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetApplUnitByUserGroupID(objPrincipal,strUserGroupID,out objApplUnit);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据用户自定义ID查询其包含的所有子组 童华 2004.05.26(已转移)
		public long m_lngGetSubGroupByUserGroupID(string strUserGroupID,out clsApplUserGroup_VO[] objApplUserGroupVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetChildGroupByUserGroupID(objPrincipal,strUserGroupID,out objApplUserGroupVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据申请单元ID查询所有的检验项目信息 童华 2004.05.26(已转移)
		public long m_lngGetCheckItemByApplUnitID(string strApplUnitID,out DataTable dtbCheckItem)
		{
			long lngRes = 0;
			dtbCheckItem = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemByApplUnitID(objPrincipal,strApplUnitID,out dtbCheckItem);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的申请单元明细 童华 2004.05.27
		public long m_lngGetAllApplUnitDetail(out clsApplUnitDetail_VO[] objApplUnitDetailVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objCheckGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
			lngRes = objCheckGroupSvc.m_lngGetAllApplUnitDetail(objPrincipal,out objApplUnitDetailVOList);
			objCheckGroupSvc.Dispose();
			return lngRes;
		}
		#endregion
	}

}
