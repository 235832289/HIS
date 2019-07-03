using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_StatBaseInfo 的摘要说明。
	/// </summary>
	public class clsController_StatBaseInfo: com.digitalwave.GUI_Base.clsController_Base
	{
		frmStatBaseInfo m_objViewer;
		clsDomainController_StatManage m_objManage;
		bool m_blnIsChange = false;//判断工作组的资料是否有改动
		#region 构造函数
		public clsController_StatBaseInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDomainController_StatManage();
		}
		#endregion

		#region 设置窗体界面
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			m_objViewer = (frmStatBaseInfo)frmMDI_Child_Base_in;
		}
		#endregion

		#region 初始化界面信息
		public void m_mthInitViewer()
		{
			m_mthGetAllWorkGroup();
			m_mthInitStatGroupInfo();
		}
		#endregion

		#region 工作组维护
		#region 获取所有的工作组信息 童华 2004.09.16
		public void m_mthGetAllWorkGroup()
		{
			long lngRes = 0;
			m_objViewer.m_lsvWorkGroup.Items.Clear();
			clsLisWorkGroup_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetAllWorkGroupInfo(out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objResultArr[i].m_strWORK_GROUP_NO_CHR;
					objlsvItem.SubItems.Add(objResultArr[i].m_strWORK_GROUP_NAME_VCHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strPRINT_NAME_VCHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strPY_CODE_CHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strWB_CODE_CHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strASSIST_CODE01_CHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strASSIST_CODE02_CHR);
					objlsvItem.SubItems.Add(objResultArr[i].m_strSUMMARY_VCHR);
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvWorkGroup.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 新增工作组 童华 2004.09.16
		public void m_mthNewWorkGroup()
		{
			if(m_objViewer.m_lsvWorkGroup.SelectedItems.Count > 0)
			{
				m_objViewer.m_lsvWorkGroup.SelectedItems[0].Selected = false;
			}
			m_mthResetWorkGroup();
		}

		public void m_mthResetWorkGroup()
		{
			m_objViewer.m_txtWorkGroupName.Clear();
			m_objViewer.m_txtWorkGroupNO.Clear();
			m_objViewer.m_txtWrokGroupPrintTitle.Clear();
			m_objViewer.m_txtWorkGroupPyCode.Clear();
			m_objViewer.m_txtWorkGroupWbCode.Clear();
			m_objViewer.m_txtWorkGroupSummary.Clear();
			m_objViewer.m_txtWorkGroupAssist01.Clear();
			m_objViewer.m_txtWorkGroupAssist02.Clear();
			m_objViewer.m_txtWorKGroupID.Clear();
		}
		#endregion

		#region 删除工作组 童华 2004.09.16
		public void m_mthDelWorkGroup()
		{
			if(m_objViewer.m_lsvWorkGroup.SelectedItems.Count <= 0)
				return;
			DialogResult dlgRes = MessageBox.Show("是否确认删除该条记录？","",MessageBoxButtons.YesNo);
			if(dlgRes == DialogResult.No)
				return;
			long lngRes = 0;
			lngRes = m_objManage.m_lngDelWorkGroup(((clsLisWorkGroup_VO)m_objViewer.m_lsvWorkGroup.SelectedItems[0].Tag).m_strWORK_GROUP_ID_CHR,"0");
			if(lngRes > 0)
			{
				m_blnIsChange = true;
				m_mthGetAllWorkGroup();
				m_mthResetWorkGroup();
			}
		}
		#endregion

		#region 显示选中的工作组信息 童华 2004.09.16
		public void m_mthShowWorkGroupInfo()
		{
			if(m_objViewer.m_lsvWorkGroup.SelectedItems.Count <= 0)
				return;
			m_mthResetWorkGroup();
			clsLisWorkGroup_VO objRecord = (clsLisWorkGroup_VO)m_objViewer.m_lsvWorkGroup.SelectedItems[0].Tag;
			m_objViewer.m_txtWorKGroupID.Text = objRecord.m_strWORK_GROUP_ID_CHR;
			m_objViewer.m_txtWorkGroupName.Text = objRecord.m_strWORK_GROUP_NAME_VCHR;
			m_objViewer.m_txtWorkGroupAssist01.Text = objRecord.m_strASSIST_CODE01_CHR;
			m_objViewer.m_txtWorkGroupAssist02.Text = objRecord.m_strASSIST_CODE02_CHR;
			m_objViewer.m_txtWorkGroupNO.Text = objRecord.m_strWORK_GROUP_NO_CHR;
			m_objViewer.m_txtWorkGroupPyCode.Text = objRecord.m_strPY_CODE_CHR;
			m_objViewer.m_txtWorkGroupWbCode.Text = objRecord.m_strWB_CODE_CHR;
			m_objViewer.m_txtWorkGroupSummary.Text = objRecord.m_strSUMMARY_VCHR;
			m_objViewer.m_txtWrokGroupPrintTitle.Text = objRecord.m_strPRINT_NAME_VCHR;
		}
		#endregion

		#region 保存工作组 童华 2004.09.16
		public void m_mthSaveWorkGroup()
		{
			if(m_objViewer.m_txtWorkGroupName.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入工作组名称！");
				return;
			}
			long lngRes = 0;
			clsLisWorkGroup_VO objRecord = new clsLisWorkGroup_VO();
			objRecord.m_strWORK_GROUP_NO_CHR = m_objViewer.m_txtWorkGroupNO.Text.ToString().Trim();
			objRecord.m_strWORK_GROUP_NAME_VCHR = m_objViewer.m_txtWorkGroupName.Text.ToString().Trim();
			objRecord.m_strWORK_GROUP_ID_CHR = m_objViewer.m_txtWorKGroupID.Text.ToString().Trim();
			objRecord.m_strWB_CODE_CHR = m_objViewer.m_txtWorkGroupWbCode.Text.ToString().Trim();
			objRecord.m_strPY_CODE_CHR = m_objViewer.m_txtWorkGroupPyCode.Text.ToString().Trim();
			objRecord.m_strPRINT_NAME_VCHR = m_objViewer.m_txtWrokGroupPrintTitle.Text.ToString().Trim();
			objRecord.m_strASSIST_CODE01_CHR = m_objViewer.m_txtWorkGroupAssist01.Text.ToString().Trim();
			objRecord.m_strASSIST_CODE02_CHR = m_objViewer.m_txtWorkGroupAssist02.Text.ToString().Trim();
			objRecord.m_strSUMMARY_VCHR = m_objViewer.m_txtWorkGroupSummary.Text.ToString().Trim();
			objRecord.m_intSTATUS_INT = 1;
			if(objRecord.m_strWORK_GROUP_ID_CHR == "")
			{
				lngRes = m_objManage.m_lngAddNewWorkGroup(objRecord);
			}
			else
			{
				lngRes = m_objManage.m_lngModifyWorkGroup(objRecord);
			}
			if(lngRes > 0)
			{
				m_blnIsChange = true;
				m_mthGetAllWorkGroup();
				m_mthResetWorkGroup();
			}
		}
		#endregion
		#endregion

		#region 统计组初始化信息 童华 2004.09.17
		public void m_mthInitStatGroupInfo()
		{
			m_mthGetAllStatGroup();
			m_mthGetAllCheckCategory();
			m_mthGetAllWorkGroupList();
			m_mthGetApplUnitByCheckCategory();
		}
		#endregion

		#region 获取所有的检验类别 童华 2004.09.17
		public void m_mthGetAllCheckCategory()
		{
			long lngRes = 0;
			DataTable dtbResult = null;
			clsDomainController_CheckItemManage objManage = new clsDomainController_CheckItemManage();
			lngRes = objManage.m_lngGetCheckCategory(out dtbResult);
			if(lngRes > 0 && dtbResult != null)
			{
				m_objViewer.m_cboCheckCategory.DataSource = dtbResult;
				m_objViewer.m_cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
				m_objViewer.m_cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
			}
		}
		#endregion

		#region 获取所有的统计组 童华 2004.09.17
		public void m_mthGetAllStatGroup()
		{
			long lngRes = 0;
			m_objViewer.m_trvStatGroup.Nodes.Clear();
			clsLisWorkGroup_VO[] objWorkGroupArr = null;
			lngRes = m_objManage.m_lngGetAllWorkGroupInfo(out objWorkGroupArr);
			if(lngRes > 0 && objWorkGroupArr != null)
			{
				for(int i=0;i<objWorkGroupArr.Length;i++)
				{
					TreeNode objTreeNode = new TreeNode();
					objTreeNode.Text = objWorkGroupArr[i].m_strWORK_GROUP_NAME_VCHR;
					objTreeNode.Tag = objWorkGroupArr[i];
					m_objViewer.m_trvStatGroup.Nodes.Add(objTreeNode);
				}

				clsLisStatGroup_VO[] objStatGroupArr = null;
				lngRes = m_objManage.m_lngGetAllStatGroupInfo(out objStatGroupArr);
				if(lngRes > 0 && objStatGroupArr != null)
				{
					for(int j=0;j<objStatGroupArr.Length;j++)
					{
						for(int i=0;i<m_objViewer.m_trvStatGroup.Nodes.Count;i++)
						{
							if(objStatGroupArr[j].m_strWORK_GROUP_ID_CHR == 
								((clsLisWorkGroup_VO)m_objViewer.m_trvStatGroup.Nodes[i].Tag).m_strWORK_GROUP_ID_CHR)
							{
								TreeNode objTreeNode = new TreeNode();
								objTreeNode.Text = objStatGroupArr[j].m_strSTAT_GROUP_NAME_VCHR;
								objTreeNode.Tag = objStatGroupArr[j];
								m_objViewer.m_trvStatGroup.Nodes[i].Nodes.Add(objTreeNode);
							}
						}
					}
				}
			}
		}
		#endregion

		#region 显示统计组界面信息时刷新 童华 2004.09.17
		public void m_mthRefreshStatGroup()
		{
			if(m_blnIsChange)
			{
				m_mthGetAllStatGroup();
				m_mthGetAllWorkGroupList();
			}
		}
		#endregion

		#region 根据检验类别获取未被其他统计组添加的申请单元 童华 2004.09.17
		public void m_mthGetApplUnitByCheckCategory()
		{
			if(m_objViewer.m_cboCheckCategory.Items.Count <= 0)
				return;
			m_objViewer.m_lsvApplUnitList.Items.Clear();
			long lngRes = 0;
			clsApplUnit_VO[] objApplUnitArr = null;
			clsLisStatGroupUnit_VO[] objStatGroupUnitArr = null;
			clsDomainController_ApplyUnitManage objApplUnitManage = new clsDomainController_ApplyUnitManage();
			lngRes = objApplUnitManage.m_lngGetApplUnitByCheckCategory(m_objViewer.m_cboCheckCategory.SelectedValue.ToString().Trim(),
				out objApplUnitArr);
			if(lngRes > 0 && objApplUnitArr != null)
			{
				lngRes = m_objManage.m_lngGetAllStatGroupUnitInfo(out objStatGroupUnitArr);
				if(lngRes > 0)
				{
					for(int i=0;i<objApplUnitArr.Length;i++)
					{
						bool blnHas = false;
						if(objStatGroupUnitArr != null)
						{
							for(int j=0;j<objStatGroupUnitArr.Length;j++)
							{
								if(objApplUnitArr[i].strApplUnitID == objStatGroupUnitArr[j].m_strAPPLY_UNIT_ID_CHR)
								{
									blnHas = true;
								}
							}
						}
						if(!blnHas)
						{
							ListViewItem objlsvItem = new ListViewItem();
							objlsvItem.Text = objApplUnitArr[i].strApplUnitID;
							objlsvItem.SubItems.Add(objApplUnitArr[i].strApplUnitName);
							objlsvItem.Tag = objApplUnitArr[i];
							m_objViewer.m_lsvApplUnitList.Items.Add(objlsvItem);
						}
					}
				}
			}
		}
		#endregion

		#region 获取所有的工作组信息 童华 2004.09.17
		public void m_mthGetAllWorkGroupList()
		{
			long lngRes = 0;
			DataTable dtbResult = null;
			lngRes = m_objManage.m_lngGetAllWorkGroupInfo(out dtbResult);
			if(lngRes > 0 && dtbResult != null)
			{
				m_objViewer.m_cboWorkGroup.DataSource = dtbResult;
				m_objViewer.m_cboWorkGroup.DisplayMember = "WORK_GROUP_NAME_VCHR";
				m_objViewer.m_cboWorkGroup.ValueMember = "WORK_GROUP_ID_CHR";
			}
		}
		#endregion

		#region 新增统计组 童华 2004.09.17
		public void m_mthNewStatGroup()
		{
			m_mthResetStatGroup();
			for(int i=0;i<m_objViewer.m_trvStatGroup.Nodes.Count;i++)
			{
				if(m_objViewer.m_cboWorkGroup.SelectedValue.ToString().Trim() ==
					((clsLisWorkGroup_VO)m_objViewer.m_trvStatGroup.Nodes[i].Tag).m_strWORK_GROUP_ID_CHR)
				{
					m_objViewer.m_trvStatGroup.SelectedNode = m_objViewer.m_trvStatGroup.Nodes[i];
					break;
				}
			}
		}

		public void m_mthResetStatGroup()
		{
			m_objViewer.m_txtStatGroupName.Clear();
			m_objViewer.m_txtStatGroupName.Tag = null;
			m_objViewer.m_txtStatGroupPrintTitle.Clear();
			m_objViewer.m_txtWorkCoefficient.Clear();
			m_objViewer.m_txtStatGroupAssist01.Clear();
			m_objViewer.m_txtStatGroupAssist02.Clear();
			m_objViewer.m_txtStatGroupPyCode.Clear();
			m_objViewer.m_txtStatGroupWbCode.Clear();
			m_objViewer.m_txtStatGroupSummary.Clear();
			m_objViewer.m_lsvStatApplUnitList.Items.Clear();
		}
		#endregion

		#region 添加申请单元 童华 2004.09.17
		public void m_mthAddApplUnit()
		{
			if(m_objViewer.m_lsvApplUnitList.Items.Count <= 0)
				return;
			for(int i=0;i<m_objViewer.m_lsvApplUnitList.Items.Count;i++)
			{
				if(m_objViewer.m_lsvApplUnitList.Items[i].Checked)
				{
					clsApplUnit_VO objApplUnit = (clsApplUnit_VO)m_objViewer.m_lsvApplUnitList.Items[i].Tag;
					for(int j=0;j<m_objViewer.m_lsvStatApplUnitList.Items.Count;j++)
					{
						if(objApplUnit.strApplUnitID == ((clsApplUnit_VO)m_objViewer.m_lsvStatApplUnitList.Items[j].Tag).strApplUnitID)
						{
							MessageBox.Show("申请单元<"+objApplUnit.strApplUnitName+">已被添加！");
							return;
						}
					}
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objApplUnit.strApplUnitID;
					objlsvItem.SubItems.Add(objApplUnit.strApplUnitName);
					objlsvItem.Tag = objApplUnit;
					m_objViewer.m_lsvStatApplUnitList.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 删除申请单元 童华 2004.09.17
		public void m_mthDelApplUnit()
		{
			if(m_objViewer.m_lsvStatApplUnitList.Items.Count <= 0)
				return;
			for(int i=0;i<m_objViewer.m_lsvStatApplUnitList.Items.Count;i++)
			{
				if(m_objViewer.m_lsvStatApplUnitList.Items[i].Checked)
				{
					m_objViewer.m_lsvStatApplUnitList.Items[i].Remove();
					i--;
				}
			}
		}
		#endregion

		#region 保存统计组 童华 2004.09.20
		public void m_mthSaveStatGroup()
		{
			if(m_objViewer.m_txtStatGroupName.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入统计组名称！");
				m_objViewer.m_txtWorkGroupName.Focus();
				return;
			}
			if(m_objViewer.m_lsvStatApplUnitList.Items.Count <= 0)
			{
				MessageBox.Show("请添加申请单元！");
				return;
			}
			long lngRes = 0;
			//构造统计组的基本信息
			clsLisStatGroup_VO objStatGroup = new clsLisStatGroup_VO();
			if(Microsoft.VisualBasic.Information.IsNumeric(m_objViewer.m_txtWorkCoefficient.Text.ToString().Trim()))
			{
				objStatGroup.m_fltWORK_COEFFICIENT_NUM = float.Parse(m_objViewer.m_txtWorkCoefficient.Text.ToString().Trim());
			}
			objStatGroup.m_intSTATUS_INT = 1;
			objStatGroup.m_strASSIST_CODE01_CHR = m_objViewer.m_txtStatGroupAssist01.Text.ToString().Trim();
			objStatGroup.m_strASSIST_CODE02_CHR = m_objViewer.m_txtStatGroupAssist02.Text.ToString().Trim();
			objStatGroup.m_strPRINT_NAME_VCHR = m_objViewer.m_txtStatGroupPrintTitle.Text.ToString().Trim();
			objStatGroup.m_strPY_CODE_CHR = m_objViewer.m_txtWorkGroupPyCode.Text.ToString().Trim();
			if(m_objViewer.m_txtStatGroupName.Tag != null)
			{
				objStatGroup.m_strSTAT_GROUP_ID_CHR = m_objViewer.m_txtStatGroupName.Tag.ToString().Trim();
			}
			objStatGroup.m_strSTAT_GROUP_NAME_VCHR = m_objViewer.m_txtStatGroupName.Text.ToString().Trim();
			objStatGroup.m_strSUMMARY_VCHR = m_objViewer.m_txtStatGroupSummary.Text.ToString().Trim();
			objStatGroup.m_strWB_CODE_CHR = m_objViewer.m_txtStatGroupWbCode.Text.ToString().Trim();
			objStatGroup.m_strWORK_GROUP_ID_CHR = m_objViewer.m_cboWorkGroup.SelectedValue.ToString().Trim();
			//构造统计组的申请单元信息
			clsLisStatGroupUnit_VO[] objStatGroupUnitArr = new clsLisStatGroupUnit_VO[m_objViewer.m_lsvStatApplUnitList.Items.Count];
			for(int i=0;i<m_objViewer.m_lsvStatApplUnitList.Items.Count;i++)
			{
				objStatGroupUnitArr[i] = new clsLisStatGroupUnit_VO();
				objStatGroupUnitArr[i].m_strAPPLY_UNIT_ID_CHR = ((clsApplUnit_VO)m_objViewer.m_lsvStatApplUnitList.Items[i].Tag).strApplUnitID;
				objStatGroupUnitArr[i].m_strSTAT_GROUP_ID_CHR = objStatGroup.m_strSTAT_GROUP_ID_CHR;
			}

			if(m_objViewer.m_txtStatGroupName.Tag != null)
			{
				lngRes = m_objManage.m_lngModifyStatGroup(objStatGroup,objStatGroupUnitArr);
			}
			else
			{
				lngRes = m_objManage.m_lngAddNewStatGroup(objStatGroup,objStatGroupUnitArr);
			}
			if(lngRes > 0)
			{
				m_mthResetStatGroup();
				m_mthGetAllStatGroup();
				m_mthGetApplUnitByCheckCategory();
				for(int i=0;i<m_objViewer.m_trvStatGroup.Nodes.Count;i++)
				{
					if(((clsLisWorkGroup_VO)m_objViewer.m_trvStatGroup.Nodes[i].Tag).m_strWORK_GROUP_ID_CHR == 
						objStatGroup.m_strWORK_GROUP_ID_CHR)
					{
						for(int j=0;j<m_objViewer.m_trvStatGroup.Nodes[i].Nodes.Count;j++)
						{
							if(((clsLisStatGroup_VO)m_objViewer.m_trvStatGroup.Nodes[i].Nodes[j].Tag).m_strSTAT_GROUP_ID_CHR ==
								objStatGroup.m_strSTAT_GROUP_ID_CHR)
							{
								m_objViewer.m_trvStatGroup.SelectedNode = m_objViewer.m_trvStatGroup.Nodes[i].Nodes[j];
								break;
							}
						}
						break;
					}
				}
			}
		}
		#endregion

		#region 显示选中的节点的信息 童华 2004.09.20
		public void m_mthShowStatGroup()
		{
			m_mthResetStatGroup();
			if(m_objViewer.m_trvStatGroup.SelectedNode.Parent == null)
			{
				m_objViewer.m_cboWorkGroup.SelectedValue = ((clsLisWorkGroup_VO)m_objViewer.m_trvStatGroup.SelectedNode.Tag).m_strWORK_GROUP_ID_CHR;
				return;
			}
			clsLisStatGroup_VO objStatGroup = (clsLisStatGroup_VO)m_objViewer.m_trvStatGroup.SelectedNode.Tag;
			m_objViewer.m_txtStatGroupName.Text = objStatGroup.m_strSTAT_GROUP_NAME_VCHR;
			m_objViewer.m_txtStatGroupName.Tag = objStatGroup.m_strSTAT_GROUP_ID_CHR;
			m_objViewer.m_txtStatGroupPrintTitle.Text = objStatGroup.m_strPRINT_NAME_VCHR;
			m_objViewer.m_txtStatGroupPyCode.Text = objStatGroup.m_strPY_CODE_CHR;
			m_objViewer.m_txtStatGroupWbCode.Text = objStatGroup.m_strWB_CODE_CHR;
			m_objViewer.m_txtStatGroupAssist01.Text = objStatGroup.m_strASSIST_CODE01_CHR;
			m_objViewer.m_txtStatGroupAssist02.Text = objStatGroup.m_strASSIST_CODE02_CHR;
			m_objViewer.m_txtStatGroupSummary.Text = objStatGroup.m_strSUMMARY_VCHR;
			m_objViewer.m_txtWorkCoefficient.Text = objStatGroup.m_fltWORK_COEFFICIENT_NUM.ToString().Trim();
			m_objViewer.m_cboWorkGroup.SelectedValue = objStatGroup.m_strWORK_GROUP_ID_CHR;
			long lngRes = 0;
			clsApplUnit_VO[] objApplUnitArr = null;
			lngRes = m_objManage.m_lngGetApplUnitByStatGroupID(objStatGroup.m_strSTAT_GROUP_ID_CHR,out objApplUnitArr);
			if(lngRes > 0 && objApplUnitArr != null)
			{
				for(int i=0;i<objApplUnitArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objApplUnitArr[i].strApplUnitID;
					objlsvItem.SubItems.Add(objApplUnitArr[i].strApplUnitName);
					objlsvItem.Tag = objApplUnitArr[i];
					m_objViewer.m_lsvStatApplUnitList.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 删除统计组 童华 2004.09.20
		public void m_mthDelStatGroup()
		{
			if(m_objViewer.m_txtStatGroupName.Tag == null)
				return;
			DialogResult dlgRes = MessageBox.Show("确认删除该记录？","删除",MessageBoxButtons.YesNo);
			if(dlgRes == DialogResult.No)
				return;
			long lngRes = 0;
			string strStatGroupID = m_objViewer.m_txtStatGroupName.Tag.ToString().Trim();
			lngRes = m_objManage.m_lngDelStatGroup(strStatGroupID);
			if(lngRes > 0)
			{
				m_mthResetStatGroup();
				m_mthGetAllStatGroup();
				m_mthGetApplUnitByCheckCategory();
			}
		}
		#endregion
	}
}
