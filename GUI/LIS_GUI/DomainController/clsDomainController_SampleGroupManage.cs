using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_SampleGroupManage 的摘要说明。
	/// 刘彬 2004.05.26
	/// </summary>
	public class clsDomainController_SampleGroupManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainController_SampleGroupManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 构造标本组TreeView
		public void m_mthGetSampleGroupTreeNodes(out TreeNode[] p_objTreeNodeArr)
		{
			long lngRes = 0;
			p_objTreeNodeArr = null;
			clsCheckCategory_VO[] objCheckCategoryArr = null;
			clsDomainController_CheckItemManage objCheckItemManage = new clsDomainController_CheckItemManage();
			lngRes = objCheckItemManage.m_lngGetCheckCategory(out objCheckCategoryArr);
			if(lngRes > 0 && objCheckCategoryArr != null)
			{
				p_objTreeNodeArr = new TreeNode[objCheckCategoryArr.Length];
				for(int i=0;i<objCheckCategoryArr.Length;i++)
				{
					p_objTreeNodeArr[i] = new TreeNode();
					p_objTreeNodeArr[i].Text = objCheckCategoryArr[i].m_strCheck_Category_Name;
					p_objTreeNodeArr[i].Tag = objCheckCategoryArr[i];
				}
				clsSampleGroup_VO[] objSampleGroupArr = null;
				lngRes = m_lngGetAllSampleGroup(out objSampleGroupArr);
				if(lngRes > 0 && objSampleGroupArr != null)
				{
					for(int i=0;i<objSampleGroupArr.Length;i++)
					{
						TreeNode objChildTreeNode = new TreeNode();
						objChildTreeNode.Text = objSampleGroupArr[i].strSampleGroupName;
						objChildTreeNode.Tag = objSampleGroupArr[i];
						for(int j=0;j<p_objTreeNodeArr.Length;j++)
						{
							if(((clsCheckCategory_VO)p_objTreeNodeArr[j].Tag).m_strCheck_Category_ID ==
								objSampleGroupArr[i].strCheckCategoryID)
							{
								p_objTreeNodeArr[j].Nodes.Add(objChildTreeNode);
								break;
							}
						}
					}
				}
			}
		}
		#endregion

		#region 根据申请单元ID查询标本组与申请单元的关系 
		public long m_lngGetSampleGroupUnitByApplUnitID(string p_strApplUnitID,out DataTable p_dtbResult)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetSampleGroupUnitByApplUnitID(objPrincipal,p_strApplUnitID,out p_dtbResult);
//			objSampleGroupSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据样本组ID查询该样本组下包含的申请单元 
		public long m_lngGetApplUnitBySampleGroupID(string p_strSampleGroupID,out clsLisSampleGroupUnit_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetApplUnitBySampleGroupID(objPrincipal,p_strSampleGroupID,out p_objResultArr);
//			objSampleGroupSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据标本组ID获取该组的标本类型
		public long m_lngGetGroupSampleTypeBySampleGroupID(string p_strSampleGroupID,out clsLisGroupSampleType_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetGroupSampleTypeBySampleGroupID(objPrincipal,p_strSampleGroupID,out p_objResultArr);
//			objSampleGroupSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 批量修改标本组的标本类型列表 童华 2004.09.06
		public long m_lngModifyGroupSampleTypeArr(ArrayList p_arlAdd,ArrayList p_arlRemove)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc objSampleGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngModifyGroupSampleTypeArr(objPrincipal,p_arlAdd,p_arlRemove);
//			objSampleGroupSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据样本组ID 得到样本组对应的仪器型号列表 
		/// <summary>
		/// 根据样本组ID 得到样本组对应的仪器型号列表
		/// </summary>
		/// <param name="p_strSampleGroupID"></param>
		/// <param name="p_strSampleGroupModelArr"></param>
		/// <returns></returns>
		public long m_lngGetSampleGroupModelArr(string p_strSampleGroupID,out string[] p_strSampleGroupModelArr)
		{
			long lngRes = 0;
			p_strSampleGroupModelArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetSampleGroupModelArr(objPrincipal,p_strSampleGroupID,out p_strSampleGroupModelArr);
			//			objSampleGroupSvc.Dispose();
			
			return lngRes;
		}
		#endregion


		#region 批量修改标本组的仪器型号列表 童华 2004.08.18
		public long m_lngSetSampleGroupModelArr(ArrayList p_arlAdd,ArrayList p_arlRemove)
		{
			long lngRes = 0;

			com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc objSampleGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngSetSampleGroupModelArr(objPrincipal,p_arlAdd,p_arlRemove);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据标本组ID获取对应的仪器型号列表 童华 2004.08.18
		public long m_lngGetDeviceModelArrBySampleGroupID(string p_strSampleGroupID,out clsLisSampleGroupModel_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetDeviceModelArrBySampleGroupID(objPrincipal,p_strSampleGroupID,out p_objResultArr);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 得到样本组的列表 刘彬 2004.07.27
		/// <summary>
		/// 得到样本组的列表
		/// </summary>
		/// <param name="p_strCategory"></param>
		/// <param name="p_strSampleType"></param>
		/// <param name="p_dtpResult"></param>
		/// <returns></returns>
		public long m_lngGetSampleGroupList(
			string p_strCategory,string p_strSampleType,out DataTable p_dtpResult)
		{
			long lngRes = 0;
			p_dtpResult = null;

            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetSampleGroupList(objPrincipal,p_strCategory,p_strSampleType,out p_dtpResult);
			//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region 根据标本组ID查询标本组VO 童华 2004.06.21
		public long m_lngGetSampleGroupVOBySampleGroupID(string p_strSampleGroupID,out clsSampleGroup_VO p_objSampleGroupVO)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetSampleGroupVOBySampleGroupID(objPrincipal,p_strSampleGroupID,out p_objSampleGroupVO);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据申请单元ID得到它所在标本组的VO 刘彬 2004.06.1
		/// <summary>
		/// 根据检验项目ID得到它所在标本组的VO,及打印顺序 刘彬 2004.06.1
		/// </summary>
		/// <param name="p_strCheckItemID"></param>
		/// <param name="p_intPrintSeq"></param>
		/// <param name="p_objSampleGroupVO"></param>
		/// <returns></returns>
		public long m_lngGetSampleGoupVOByApplyUnitID(string p_strApplyUnitID,out clsSampleGroup_VO p_objSampleGroupVO)
		{
			long lngRes = 0;
			p_objSampleGroupVO = null;

            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetSampleGoupVOByApplyUnitID(objPrincipal,p_strApplyUnitID,out p_objSampleGroupVO);
			//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region 获取所有的标本组明细列表 
		public long m_lngGetAllSampleGroupDetail(out clsSampleGroupDetail_VO[] objSampleGroupDetailVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetAllSampleGroupDetail(objPrincipal,out objSampleGroupDetailVOList);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除检验组明细 童华 2004.05.25
		public long m_lngDelSampleGroupDetail(string strSampleGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc objSampleGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngDelSampleGroupDetail(objPrincipal,strSampleGroupID);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除标本组及其明细 童华 2004.05.25
		public long m_lngDelSampleGroupAndDetail(string strSampleGroupID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc objSampleGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngDelSampleGroupAndDetail(objPrincipal,strSampleGroupID);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 保存标本组及其明细 童华 2004.05.25
		public long m_lngAddSampleGroup(ref clsSampleGroup_VO p_objSampleGroupVO,ref clsLisSampleGroupUnit_VO[] p_objSampleGroupUnitList,
			clsApplUnitDetail_VO[] p_objApplUnitArr,ArrayList p_arlAdd,ArrayList p_arlRemove,
			ArrayList p_arlAddSampleType,ArrayList p_arlRemoveSampleType)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc objSampleGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngAddSampleGroupAndDetail(objPrincipal,ref p_objSampleGroupVO,ref p_objSampleGroupUnitList,p_objApplUnitArr
				,p_arlAdd,p_arlRemove,p_arlAddSampleType,p_arlRemoveSampleType);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取某一标本组下的所有检验项目信息 童华 2004.05.25
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

		#region 获取所有的标本组列表 童华 2004.05.24
		public long m_lngGetAllSampleGroup(out com.digitalwave.iCare.ValueObject.clsSampleGroup_VO[] objSampleGroupVOList)
		{
			long lngRes = 0;
			objSampleGroupVOList = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc objSampleGroupSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleGroupSvc));
			lngRes = objSampleGroupSvc.m_lngGetAllSampleGroup(objPrincipal,ref objSampleGroupVOList);
//			objSampleGroupSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	根据申请单取得对应样本的采样说明 
		public long m_lngGetSampleRemark(string p_ApplicationID,out clsSampleGroup_VO[] p_objSampleGroupVOArr)
		{
			long lngRes = 0;
			p_objSampleGroupVOArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplicationSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
			lngRes = objApplicationSvc.m_lngGetSampleRemark(objPrincipal,p_ApplicationID,out p_objSampleGroupVOArr);
			return lngRes;
		}
		#endregion

		#region 获取是否显示未收费状态申请单的配置信息	xing.chen 
		public long m_lngGetCollocate(out bool p_blnConfig,string p_strSetID)
		{
			p_blnConfig = false;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplicationSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
			long lngRes = objApplicationSvc.m_lngGetCollocate(objPrincipal,out p_blnConfig,p_strSetID);
			return lngRes;
		}
		#endregion
	}
}
