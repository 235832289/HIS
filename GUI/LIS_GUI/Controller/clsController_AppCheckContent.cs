using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.middletier.LIS; //LisApplSvr.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Text;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_AppCheckContent 的摘要说明。
	/// 刘彬 2004.05.26
	/// </summary>
	public class clsController_AppCheckContent : com.digitalwave.GUI_Base.clsController_Base
	{
		internal frmAppCheckContent m_objViewer;
		public clsAppCollection m_objApps = new clsAppCollection();
		public clsAppCheckReportCollection m_objAppReports = new clsAppCheckReportCollection();
		public clsAppApplyUnitCollection m_objAppApplyUnits =  new clsAppApplyUnitCollection();

		public clsController_AppCheckContent(frmAppCheckContent p_objViewer)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.m_objViewer = p_objViewer;
		}
		public void m_mthGenerateAppContent()
		{
			m_mthGenerateAppApplyUnits();
			m_mthGenerateAppReports();
			foreach(clsLIS_AppCheckReport objReport in m_objAppReports)
			{
				clsLisApplMainVO objAppVO = new clsLisApplMainVO();
				clsLIS_App objApp = new clsLIS_App(objAppVO,false);
				foreach(clsLIS_AppSampleGroup objSG in objReport.m_ObjAppSampleGroups)
				{
					for(int i=0;i<objSG.m_ObjAppUnitArr.Length;i++)
					{
						objApp.m_ObjAppApplyUnits.Add(objSG.m_ObjAppUnitArr[i]);
					}
				}
				this.m_objApps.Add(objApp);
				objApp.m_ObjAppReports.Add(objReport);
			}
		}


		#region 初始化所有检验申请组列表
		public void m_mthInitialAppGroupList()
		{
			m_mthInitialAppGroupList(this.m_objViewer.m_trvFrameGroup,'F');
			m_mthInitialAppGroupList(this.m_objViewer.m_trvDeptGroup,'D');
			m_mthInitialAppGroupList(this.m_objViewer.m_trvCustomGroup,'C');
		}

		#region 初始化检验申请组列表
		public void m_mthInitialAppGroupList(TreeView p_trvGroup,char p_chrGroupFlag)
		{
			p_trvGroup.Nodes.Clear();
			long lngRes = 0;
			//查询所有的作为子组的用户自定义
			
			clsDomainController_AppGroupManage objDomainControllerAppGroup = new clsDomainController_AppGroupManage();
			clsApplUserGroup_VO[] objUserGroupVOList = null;
			TreeNode objTreeNode = null;

			lngRes = objDomainControllerAppGroup.m_lngGetMasterUserGroup(out objUserGroupVOList);
			if(lngRes > 0 && objUserGroupVOList != null)
			{
				if(objUserGroupVOList.Length > 0)
				{
					for(int i=0;i<objUserGroupVOList.Length;i++)
					{						
						objTreeNode = p_trvGroup.Nodes.Add(objUserGroupVOList[i].strUserGroupName);
						objTreeNode.Tag = objUserGroupVOList[i];
						TreeNode objChildNode = objTreeNode.Nodes.Add("");
					}
				}
			}

		}
		#endregion

		#region 在节点展开后查找下一层的用户自定义子组和申请单元
		public void m_mthGetNextLevelUserGorupAndApplUnit(TreeNode objTreeNode)
		{
			long lngRes = 0;
			objTreeNode.Nodes.Clear();
			TreeNode objChildTreeNode = null;
			clsDomainController_AppGroupManage objDomainControllerAppGroup = new clsDomainController_AppGroupManage();
			string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
			//获取该节点下的用户自定义子组
			clsApplUserGroup_VO[] objApplUserGroupVO = null;
			lngRes = objDomainControllerAppGroup.m_lngGetSubGroupByUserGroupID(strUserGroupID,out objApplUserGroupVO);
			if(lngRes>0 && objApplUserGroupVO != null)
			{
				if(objApplUserGroupVO.Length > 0)
				{
					for(int i=0;i<objApplUserGroupVO.Length;i++)
					{
						objChildTreeNode = objTreeNode.Nodes.Add(objApplUserGroupVO[i].strUserGroupName);
						objChildTreeNode.Tag = objApplUserGroupVO[i];
						objChildTreeNode.Nodes.Add("");
						}
				}
			}
			//获取该节点下的申请单元
			m_mthGetChildApplUnit(objTreeNode);
		}
		#endregion

		#region 查找下一层的用户定义子组和申请单元
		public void m_mthGetChildUserGroupAndApplUnit(TreeNode objTreeNode)
		{
			long lngRes = 0;
			TreeNode objChildTreeNode = null;
			clsDomainController_AppGroupManage objDomainControllerAppGroup = new clsDomainController_AppGroupManage();
			string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
			clsApplUserGroup_VO[] objApplUserGroupVO = null;
			lngRes = objDomainControllerAppGroup.m_lngGetSubGroupByUserGroupID(strUserGroupID,out objApplUserGroupVO);
			if(lngRes>0 && objApplUserGroupVO != null)
			{
				if(objApplUserGroupVO.Length > 0)
				{
					//考虑到用户自定义组会有包含申请单元的情况
					m_mthGetChildApplUnit(objTreeNode);
					for(int i=0;i<objApplUserGroupVO.Length;i++)
					{
						objChildTreeNode = objTreeNode.Nodes.Add(objApplUserGroupVO[i].strUserGroupName);
						objChildTreeNode.Tag = objApplUserGroupVO[i];

						if(int.Parse(objApplUserGroupVO[i].strHasChildGroup) > 0)
						{
							//查找下一层的用户定义子组和申请单元
							m_mthGetChildUserGroupAndApplUnit(objChildTreeNode);
						}
						else
						{
							m_mthGetChildApplUnit(objChildTreeNode);
						}
					}
				}
				else
				{
					m_mthGetChildApplUnit(objTreeNode);
				}
			}
			else
			{
				m_mthGetChildApplUnit(objTreeNode);
			}
		}
		#endregion

		#region 查找该组下的申请单元
		private void m_mthGetChildApplUnit(TreeNode objTreeNode)
		{
			long lngRes = 0;
			TreeNode objChildTreeNode = null;
			clsDomainController_AppGroupManage objDomainControllerAppGroup = new clsDomainController_AppGroupManage();
			string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
			clsApplUnit_VO[] objApplUnit = null;
			lngRes = objDomainControllerAppGroup.m_lngGetApplUnitByUserGroupID(strUserGroupID,out objApplUnit);
			if(lngRes > 0 && objApplUnit != null)
			{
				if(objApplUnit.Length > 0)
				{
					for(int i=0;i<objApplUnit.Length;i++)
					{
						objChildTreeNode = objTreeNode.Nodes.Add(objApplUnit[i].strApplUnitName);
						objChildTreeNode.Tag = objApplUnit[i];
					}
				}
			}
		}
		#endregion
		#endregion

		#region 形成申请单的申请单元
		private void m_mthGenerateAppApplyUnits()
		{
			foreach(TreeNode trnNode in this.m_objViewer.m_trvFrameGroup.Nodes)
			{
				m_mthJudgeNodeChecked(trnNode);
			}
		}
		private void m_mthJudgeNodeChecked(TreeNode p_trnNode)
		{
			if(p_trnNode.Checked)
			{
				m_mthJudgeNodeIsAppUnitNode(p_trnNode);
			}
			else
			{
				foreach(TreeNode trnNode in p_trnNode.Nodes)
				{
					m_mthJudgeNodeChecked(trnNode);
				}
			}
		}
		private void m_mthJudgeNodeIsAppUnitNode(TreeNode p_trnNode)
		{
			if(p_trnNode.Nodes.Count == 0)
			{
				m_mthGenerateAppUnitForAppUnitNode(p_trnNode);
			}
			else
			{
				foreach(TreeNode trnNode in p_trnNode.Nodes)
				{
					m_mthJudgeNodeIsAppUnitNode(trnNode);
				}
			}
		}
		private void m_mthGenerateAppUnitForAppUnitNode(TreeNode p_trnNode)
		{
			if(p_trnNode.Tag == null)
				return;
			if(p_trnNode.Tag.GetType().Name != typeof(clsApplUnit_VO).Name)
				return;

			clsApplUnit_VO objApplyUnitDataVO = (clsApplUnit_VO)p_trnNode.Tag;

			clsLIS_ApplyUnit objApplyUnit = new clsLIS_ApplyUnit();
			objApplyUnit.m_ObjDataVO = objApplyUnitDataVO;	
		
			clsT_OPR_LIS_APP_APPLY_UNIT_VO objAppAppUnitVO = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();
			clsLIS_AppApplyUnit objAppApplyUnit = new clsLIS_AppApplyUnit(objAppAppUnitVO);
			objAppApplyUnit.m_ObjApplyUnit = objApplyUnit;
			objAppApplyUnit.m_StrApplyUnitID = objApplyUnitDataVO.strApplUnitID;

			string strUserGroupPath = m_strGenerateGroupPathString(p_trnNode);
			strUserGroupPath += objApplyUnitDataVO.strApplUnitID;
			objAppApplyUnit.m_StrUserGroupPath = strUserGroupPath;

			bool blnUnitExist = false;
			foreach(clsLIS_AppApplyUnit obj in m_objAppApplyUnits)
			{
				if(obj.m_StrApplyUnitID == objAppApplyUnit.m_StrApplyUnitID)
				{
					blnUnitExist = true;
					break;
				}
			}
			if(!blnUnitExist)
			{
				this.m_objAppApplyUnits.Add(objAppApplyUnit);
			}
		}
		private string m_strGenerateGroupPathString(TreeNode p_trnNode)
		{
			StringBuilder sb = new StringBuilder();
			while(p_trnNode.Parent != null && p_trnNode.Parent.Tag != null && p_trnNode.Parent.Tag.GetType().Name == typeof(clsApplUserGroup_VO).Name)
			{
				clsApplUserGroup_VO objUserGroupVO = (clsApplUserGroup_VO)p_trnNode.Parent.Tag;
				sb.Insert(0,objUserGroupVO.strUserGroupID + ">>");		
				p_trnNode = p_trnNode.Parent;
			}
			return sb.ToString();
		}
		#endregion
		#region 形成申请单的报告组
		private void m_mthGenerateAppReports()
		{
			clsAppSampleGroupCollection objSampleGroups = m_objGenerateAppSampleGroups();
			clsDomainController_ReportManage objReportManage = new clsDomainController_ReportManage();

			foreach(clsLIS_AppSampleGroup objAppSampleGroup in objSampleGroups)
			{
				bool blnAppReportGroupExist = false;
				clsReportGroup_VO objReportGroupVO = null;
				long lngRes = objReportManage.m_lngGetReportGoupVOBySampleGroupID(objAppSampleGroup.m_ObjDataVO.m_strSAMPLE_GROUP_ID_CHR,out objReportGroupVO);
				if(lngRes >0 &&  objReportGroupVO != null)
				{
					objAppSampleGroup.m_ObjDataVO.m_strREPORT_GROUP_ID_CHR = objReportGroupVO.strReportGroupID;
					foreach(clsLIS_AppCheckItem objAppCheckItem in objAppSampleGroup.m_ObjAppCheckItems)
					{
						objAppCheckItem.m_ObjDataVO.m_strREPORT_GROUP_ID_CHR = objReportGroupVO.strReportGroupID;
					}
					
					foreach(clsLIS_AppCheckReport objAppCheckReport in this.m_objAppReports)
					{
						if(objAppCheckReport.m_ObjCheckReport.m_ObjDataVO.strReportGroupID == objReportGroupVO.strReportGroupID)
						{
							objAppCheckReport.m_ObjAppSampleGroups.Add(objAppSampleGroup);
							System.Collections.ArrayList arlSGID = new System.Collections.ArrayList();
							if(objAppCheckReport.m_ObjDataVO.m_strSampleGroupIDArr != null)
							{
								arlSGID.AddRange(objAppCheckReport.m_ObjDataVO.m_strSampleGroupIDArr);
							}
							arlSGID.Add(objAppSampleGroup.m_StrSampleGroupID);
							objAppCheckReport.m_ObjDataVO.m_strSampleGroupIDArr = (string[])arlSGID.ToArray(typeof(string));
							blnAppReportGroupExist = true;
							break;
						}
					}
					if(!blnAppReportGroupExist)
					{
						clsLIS_CheckReport objCheckReport = new clsLIS_CheckReport();
						objCheckReport.m_ObjDataVO = objReportGroupVO;
						clsT_OPR_LIS_APP_REPORT_VO objAppReportVO = new clsT_OPR_LIS_APP_REPORT_VO();
						clsLIS_AppCheckReport objAppReport = new clsLIS_AppCheckReport(objAppReportVO);
						objAppReport.m_ObjCheckReport = objCheckReport;
						objAppReport.m_StrReportGroupID = objCheckReport.m_ObjDataVO.strReportGroupID;
						objAppReport.m_ObjAppSampleGroups.Add(objAppSampleGroup);
						objAppReport.m_ObjDataVO.m_strSampleGroupIDArr = new string[]{objAppSampleGroup.m_StrSampleGroupID};
						objAppReport.m_IntStatus = 1;
						
						this.m_objAppReports.Add(objAppReport);
					}
				}
			}
		}


		#endregion
		#region 形成申请单的报告组的标本组
		private clsAppSampleGroupCollection m_objGenerateAppSampleGroups()
		{
			m_objGenerateAppUnitItems();
			clsAppSampleGroupCollection objSampleGroups = new clsAppSampleGroupCollection();

			clsDomainController_SampleGroupManage objSampleGroupManage = new clsDomainController_SampleGroupManage();

			foreach(clsLIS_AppApplyUnit objAppUnit in m_objAppApplyUnits)
			{
				bool blnAppSampleGroupExist = false;
				clsSampleGroup_VO objSampleGroupVO = null;
				long lngRes = objSampleGroupManage.m_lngGetSampleGoupVOByApplyUnitID(objAppUnit.m_StrApplyUnitID,out objSampleGroupVO);
				if(lngRes >0 &&  objSampleGroupVO != null)
				{
//					objAppCheckItem.m_StrSampleGroupID = objSampleGroupVO.strSampleGroupID;
					clsLIS_AppSampleGroup objAppSampleGroup = null;
					foreach(clsLIS_AppSampleGroup obj in objSampleGroups)
					{
						if(obj.m_ObjSampleGroup.m_ObjDataVO.strSampleGroupID == objSampleGroupVO.strSampleGroupID)
						{
							objAppSampleGroup = obj;
							blnAppSampleGroupExist = true;
							break;
						}
					}
					if(!blnAppSampleGroupExist)
					{
						clsLIS_SampleGroup objSampleGroup = new clsLIS_SampleGroup();
						objSampleGroup.m_ObjDataVO = objSampleGroupVO;
						clsT_OPR_LIS_APP_SAMPLE_VO objAppSampleGroupVO = new clsT_OPR_LIS_APP_SAMPLE_VO();
						clsLIS_AppSampleGroup objAppSGroup = new clsLIS_AppSampleGroup(objAppSampleGroupVO);
						objAppSGroup.m_ObjSampleGroup = objSampleGroup;
						objAppSGroup.m_StrSampleGroupID = objSampleGroup.m_ObjDataVO.strSampleGroupID;
						objSampleGroups.Add(objAppSGroup);
						objAppSampleGroup = objAppSGroup;
					}
					System.Collections.ArrayList arlSU = new System.Collections.ArrayList();
					if(objAppSampleGroup.m_ObjAppUnitArr != null)
					{
						arlSU.AddRange(objAppSampleGroup.m_ObjAppUnitArr);
					}
					arlSU.Add(objAppUnit);
					objAppSampleGroup.m_ObjAppUnitArr = (clsLIS_AppApplyUnit[])arlSU.ToArray(typeof(clsLIS_AppApplyUnit));

					for(int i = 0;i<objAppUnit.m_ObjItemArr.Length;i++)
					{
						bool blnItemExist = false;
						foreach(clsLIS_AppCheckItem objAppItem in objAppSampleGroup.m_ObjAppCheckItems)
						{
							if(objAppItem.m_StrCheckItemID == objAppUnit.m_ObjItemArr[i].m_strCHECK_ITEM_ID_CHR)
							{
								blnItemExist = true;
								break;
							}
						}
						if(!blnItemExist)
						{
							clsT_OPR_LIS_APP_CHECK_ITEM_VO objAppItemVO = new clsT_OPR_LIS_APP_CHECK_ITEM_VO();
							clsLIS_AppCheckItem objAppCheckItem = new clsLIS_AppCheckItem(objAppItemVO);
						
							objAppCheckItem.m_StrCheckItemID = objAppUnit.m_ObjItemArr[i].m_strCHECK_ITEM_ID_CHR;
							objAppCheckItem.m_StrSampleGroupID = objAppSampleGroup.m_StrSampleGroupID;
                            objAppCheckItem.m_ObjDataVO.m_strItemprice_mny = objAppUnit.m_ObjItemArr[i].m_strItemprice_mny;
                            
							objAppSampleGroup.m_ObjAppCheckItems.Add(objAppCheckItem);
						}
					}

				}
			}
			return objSampleGroups;
		}


		#endregion


		#region 形成申请单的报告组的标本组的检验项目
		private void m_objGenerateAppUnitItems()
		{
			clsDomainController_ApplyUnitManage objApplyUnitManage = new clsDomainController_ApplyUnitManage();
			System.Collections.ArrayList arlUnitItems = new System.Collections.ArrayList();
			foreach(clsLIS_AppApplyUnit objAppApplyUnit in this.m_objAppApplyUnits)
			{
				arlUnitItems.Clear();

				clsCheckItem_VO[] objCheckItemVOArr = null;
				long lngRet = objApplyUnitManage.m_lngGetCheckItemByApplUnitID(objAppApplyUnit.m_ObjDataVO.m_strAPPLY_UNIT_ID_CHR,out objCheckItemVOArr);
				if(lngRet > 0 && objCheckItemVOArr != null && objCheckItemVOArr.Length > 0)
				{
					for(int i=0;i<objCheckItemVOArr.Length;i++)
					{
//						clsLisDeviceCheckItem_VO objDevItem = null;
//						new clsDomainController_LisDeviceManage().m_lngGetDeviceCheckItemInfoByCheckItemID(
//							objCheckItemVOArr[i].m_strCheck_Item_ID.Trim(),out objDevItem);

//						if(objDevItem != null)
//						{
//							objCheckItem.m_StrDeviceItemName = objDevItem.strDeviceCheckItemName.Trim();
//						}
						

						clsLisAppUnitItemVO objUnitItem = new clsLisAppUnitItemVO();
						objUnitItem.m_strAPPLY_UNIT_ID_CHR = objAppApplyUnit.m_StrApplyUnitID;
						objUnitItem.m_strCHECK_ITEM_ID_CHR = objCheckItemVOArr[i].m_strCheck_Item_ID;
                        objUnitItem.m_strItemprice_mny = objCheckItemVOArr[i].m_strItemprice_mny;

						arlUnitItems.Add(objUnitItem);
					}
					objAppApplyUnit.m_ObjItemArr = (clsLisAppUnitItemVO[])arlUnitItems.ToArray(typeof(clsLisAppUnitItemVO));
				}			
			}			
		}
		#endregion

		#region 支无界面从申请单元ID数组生成 2005.07.16
        /// <summary>
        /// 从申请单元ID数组生成
        /// </summary>
        /// <param name="p_strApplyUnitsIDArr"></param>
		public void m_mthGenerateAppContent(string[] p_strApplyUnitsIDArr)
		{
			m_mthGenerateAppApplyUnits(p_strApplyUnitsIDArr);
			if(m_objAppApplyUnits.Count == 0)
				return;
			m_mthGenerateAppReports();
			foreach(clsLIS_AppCheckReport objReport in m_objAppReports)
			{
				clsLisApplMainVO objAppVO = new clsLisApplMainVO();
				clsLIS_App objApp = new clsLIS_App(objAppVO,false);
				foreach(clsLIS_AppSampleGroup objSG in objReport.m_ObjAppSampleGroups)
				{
					for(int i=0;i<objSG.m_ObjAppUnitArr.Length;i++)
					{
						objApp.m_ObjAppApplyUnits.Add(objSG.m_ObjAppUnitArr[i]);
					}
				}
				this.m_objApps.Add(objApp);
				objApp.m_ObjAppReports.Add(objReport);
			}
		}

        /// <summary>
        /// 生成申请单元ID数组
        /// </summary>
        /// <param name="p_strApplyUnitsIDArr"></param>
		private void m_mthGenerateAppApplyUnits(string[] p_strApplyUnitsIDArr)
		{
			if(p_strApplyUnitsIDArr == null)
				return;
			clsDomainController_ApplyUnitManage objDomUnit = new clsDomainController_ApplyUnitManage();
			foreach(string str in p_strApplyUnitsIDArr)
			{
				
				clsApplUnit_VO objApplyUnitDataVO = null;
				long lngRes = objDomUnit.m_lngGetApplyUnitVOByApplyUnitID(str,out objApplyUnitDataVO);
				if(lngRes <=0)
				{
					MessageBox.Show("数据访问失败!请与管理员联系。");
					m_objAppApplyUnits.Clear();
					return;
				}
				if(objApplyUnitDataVO == null)
				{
					MessageBox.Show("无效的申请单元ID!请与管理员联系。");
					m_objAppApplyUnits.Clear();
					return;
				}

				clsLIS_ApplyUnit objApplyUnit = new clsLIS_ApplyUnit();
				objApplyUnit.m_ObjDataVO = objApplyUnitDataVO;	
		
				clsT_OPR_LIS_APP_APPLY_UNIT_VO objAppAppUnitVO = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();
				clsLIS_AppApplyUnit objAppApplyUnit = new clsLIS_AppApplyUnit(objAppAppUnitVO);
				objAppApplyUnit.m_ObjApplyUnit = objApplyUnit;
				objAppApplyUnit.m_StrApplyUnitID = objApplyUnitDataVO.strApplUnitID;
				m_objAppApplyUnits.Add(objAppApplyUnit);
			}
		}
		#endregion

		#region 根据节点，返回节点对应类型的备注		xing.chen
		/// <summary>
		/// 根据节点，返回节点对应类型的备注
		/// </summary>
		/// <param name="infrmAppCheckContent">检验项目申请窗体对象</param>
		/// <param name="p_objTreeNode">选定的treeview节点对象</param>
		/// <returns></returns>
		public string m_mthReturnNodeSummary(TreeNode p_objTreeNode)
		{
			string NodeSummary = null;

			//申请单元的备注
			if(p_objTreeNode.Tag is clsApplUnit_VO)
			{
				NodeSummary = ((clsApplUnit_VO)p_objTreeNode.Tag).strSummary;
			}

			//自定义组合的备注
			if(p_objTreeNode.Tag is clsApplUserGroup_VO)
			{
				NodeSummary = ((clsApplUserGroup_VO)p_objTreeNode.Tag).strSummary;
			}

			return NodeSummary;
		}
		#endregion
	}
}
