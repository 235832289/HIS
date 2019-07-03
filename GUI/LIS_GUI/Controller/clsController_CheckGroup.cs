using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for clsController_CheckGroup.
	/// </summary>
	public class clsController_CheckGroup  : com.digitalwave.GUI_Base.clsController_Base
	{
		//用于记录所有已经添加为标本组的检验项目
		com.digitalwave.iCare.ValueObject.clsSampleGroupDetail_VO[] objSampleGroupDetailVOList = null;
		//用于记录所有已经添加为报告组的标本组
		com.digitalwave.iCare.ValueObject.clsReportGroupDetail_VO[] objReportGroupDetailVOList = null;
		//用于记录所有已经添加为标本组的申请单元
		com.digitalwave.iCare.ValueObject.clsLisSampleGroupUnit_VO[] m_objSampleGroupUnitArr = null;
		DataTable dtbAllCheckCategory = null;
		com.digitalwave.iCare.gui.LIS.clsDomainController_SampleGroupManage m_objManage;
		internal ArrayList arlSampleModelRemove = new ArrayList();
		internal ArrayList arlSampleModelAdd = new ArrayList();
		internal ArrayList m_arlGroupSampleAdd = new ArrayList();
		internal ArrayList m_arlGroupSampleRemove = new ArrayList();
		internal ArrayList m_arlSampleModelRaw = new ArrayList();
		internal ArrayList m_arlSameApplyUnitItem = new ArrayList();

		#region 设置窗体对象
		com.digitalwave.iCare.gui.LIS.frmCheckGroup m_objViewer;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer = (frmCheckGroup)frmMDI_Child_Base_in;
		}
		#endregion

		#region 构造函数
		public clsController_CheckGroup()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objManage = new clsDomainController_SampleGroupManage();
		}

		#endregion

		#region 根据检验类别获取所有的申请单元 童华 2004.09.27
		public void m_mthGetApplUnitByCheckCategory()
		{
			m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Clear();
			if(m_objViewer.cboCheckCategory.Items.Count <= 0)
				return;
			long lngRes = 0;
			clsApplUnit_VO[] objResultArr = null;
			clsDomainController_ApplyUnitManage objManage = new clsDomainController_ApplyUnitManage();
			lngRes = objManage.m_lngGetApplUnitByCheckCategory(m_objViewer.cboCheckCategory.SelectedValue.ToString().Trim(),
				out objResultArr);
			if(lngRes > 0 && objResultArr != null)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					TreeNode objTreeNode = new TreeNode();
					objTreeNode.Text = "("+objResultArr[i].strApplUnitID+")"+objResultArr[i].strApplUnitName;
					objTreeNode.Tag = objResultArr[i];
					m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Add(objTreeNode);
				}
			}
		}
		#endregion

		#region 删除标本组的申请单元组合 童华 2004.09.09
		public void m_mthRemoveApplUnit()
		{
			if(m_objViewer.m_trvApplUnit.Nodes.Count <= 0)
				return;
			for(int i=0;i<m_objViewer.m_trvAddSampleGroup.Nodes.Count;i++)
			{
				if(m_objViewer.m_trvAddSampleGroup.Nodes[i].Checked)
				{
					for(int j=0;j<m_objViewer.m_lsvApplUnitItem.Items.Count;j++)
					{
						if(((DataRow)m_objViewer.m_lsvApplUnitItem.Items[j].Tag)["apply_unit_id_chr"].ToString().Trim()
							== ((clsLisSampleGroupUnit_VO)m_objViewer.m_trvAddSampleGroup.Nodes[i].Tag).m_strAPPLY_UNIT_ID_CHR)
						{
							m_objViewer.m_lsvApplUnitItem.Items[j].Remove();
							j--;
						}
					}
					m_objViewer.m_trvAddSampleGroup.Nodes[i].Remove();
					i--;
				}
			}

			for(int i=0;i<m_objViewer.m_lsvApplUnitItem.Items.Count;i++)
			{
				m_objViewer.m_lsvApplUnitItem.Items[i].SubItems[3].Text = i.ToString();
			}
		}
		#endregion

		#region 添加标本组的申请单元组合 童华 2004.09.09
		public void m_mthAddApplUnit()
		{
			//判断申请单元是否重复
			for(int i=0;i<m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Count;i++)
			{
				if(m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Checked)
				{
					if(m_objSampleGroupUnitArr != null)
					{
						//判断申请单元是否被别的标本组包含
						for(int k=0;k<m_objSampleGroupUnitArr.Length;k++)
						{
							if(m_objSampleGroupUnitArr[k].m_strAPPLY_UNIT_ID_CHR ==
								((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitID)
							{
								MessageBox.Show("申请单元["+m_objSampleGroupUnitArr[k].m_strAPPLY_UNIT_DESC_VCHR+"]已经被其他标本组添加！");
								return;
							}
						}
					}
					for(int j=0;j<m_objViewer.m_trvAddSampleGroup.Nodes.Count;j++)
					{
						if(((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitID == 
							((clsLisSampleGroupUnit_VO)m_objViewer.m_trvAddSampleGroup.Nodes[j].Tag).m_strAPPLY_UNIT_ID_CHR)
						{
							MessageBox.Show("申请单元["+((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitName+"]已经被添加！");
							return;
						}
					}
				}
			}
			clsDomainController_ApplyUnitManage objManage = new clsDomainController_ApplyUnitManage();
			for(int i=0;i<m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Count;i++)
			{
				if(m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Checked)
				{
					TreeNode objTreeNode = new TreeNode();
					objTreeNode.Text = "("+((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitID+")"
						+((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitName;
					clsLisSampleGroupUnit_VO objSampleGroupUnit = new clsLisSampleGroupUnit_VO();
					objSampleGroupUnit.m_strAPPLY_UNIT_DESC_VCHR = ((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitName;
					objSampleGroupUnit.m_strAPPLY_UNIT_ID_CHR = ((clsApplUnit_VO)m_objViewer.m_trvApplUnit.Nodes[0].Nodes[i].Tag).strApplUnitID;
					objSampleGroupUnit.m_strSAMPLE_GROUP_ID_CHR = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
					objTreeNode.Tag = objSampleGroupUnit;
					m_objViewer.m_trvAddSampleGroup.Nodes.Add(objTreeNode);

					DataTable dtbResult = null;
					long lngRes = objManage.m_lngGetCheckItemByApplUnitID(objSampleGroupUnit.m_strAPPLY_UNIT_ID_CHR,out dtbResult);
					if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
					{
						for(int j=0;j<dtbResult.Rows.Count;j++)
						{
							bool blnSameItem = false;
							for(int k=0;k<m_objViewer.m_lsvApplUnitItem.Items.Count;k++)
							{
								if(dtbResult.Rows[j]["check_item_id_chr"].ToString().Trim() == ((DataRow)m_objViewer.m_lsvApplUnitItem.Items[k].Tag)
									["check_item_id_chr"].ToString().Trim())
								{
									blnSameItem = true;
									clsApplUnitDetail_VO objApplDetail = new clsApplUnitDetail_VO();
									objApplDetail.strApplUnitID = dtbResult.Rows[j]["apply_unit_id_chr"].ToString().Trim();
									objApplDetail.strCheckItemID = dtbResult.Rows[j]["check_item_id_chr"].ToString().Trim();
									m_arlSameApplyUnitItem.Add(objApplDetail);
								}
							}
							if(!blnSameItem)
							{
								ListViewItem objlsvItem = new ListViewItem();
								objlsvItem.Text = dtbResult.Rows[j]["check_item_id_chr"].ToString().Trim();
								objlsvItem.SubItems.Add(dtbResult.Rows[j]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
								objlsvItem.SubItems.Add(dtbResult.Rows[j]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
								int intOrder = m_objViewer.m_lsvApplUnitItem.Items.Count;
								objlsvItem.SubItems.Add(intOrder.ToString().Trim());
								objlsvItem.Tag = dtbResult.Rows[j];
								m_objViewer.m_lsvApplUnitItem.Items.Add(objlsvItem);
							}
						}
					}
				}
			}
		}
		#endregion

		#region 根据样本组ID查询该样本组下包含的申请单元 童华 2004.09.08
		public void m_mthGetSampleGroupUnitBySampleGroupID()
		{
			long lngRes = 0;
			m_objViewer.m_trvAddSampleGroup.Nodes.Clear();
			m_objViewer.m_lsvApplUnitItem.Items.Clear();
			ArrayList arlApplID = new ArrayList();
			string strSampleGroupID = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
			clsLisSampleGroupUnit_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetApplUnitBySampleGroupID(strSampleGroupID,out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					TreeNode objTreeNode = new TreeNode();
					objTreeNode.Text = "("+objResultArr[i].m_strAPPLY_UNIT_ID_CHR+")"+objResultArr[i].m_strAPPLY_UNIT_DESC_VCHR;
					objTreeNode.Tag = objResultArr[i];
					m_objViewer.m_trvAddSampleGroup.Nodes.Add(objTreeNode);
					arlApplID.Add(objResultArr[i].m_strAPPLY_UNIT_ID_CHR);
				}

				m_mthGetApplItemByApplUnitIDArr(arlApplID);
			}
		}
		#endregion

		#region 根据申请单元ID数组获取该申请单元下的检验项目 童华 2004.09.09
		public void m_mthGetApplItemByApplUnitIDArr(ArrayList p_arlApplID)
		{
			long lngRes = 0;
			DataTable dtbAllItem = null;
			DataTable dtbResult = null;
			clsDomainController_ApplyUnitManage objManage = new clsDomainController_ApplyUnitManage();
			for(int i=0;i<p_arlApplID.Count;i++)
			{
				lngRes = objManage.m_lngGetCheckItemByApplUnitID(p_arlApplID[i].ToString().Trim(),out dtbResult);
				if(lngRes > 0 && dtbResult != null)
				{
					if(dtbAllItem == null)
					{
						dtbAllItem = dtbResult.Copy();
					}
					else
					{
						for(int j=0;j<dtbResult.Rows.Count;j++)
						{
							DataRow dr = dtbAllItem.NewRow();
							dr.ItemArray = dtbResult.Rows[j].ItemArray;
							dtbAllItem.Rows.Add(dr);
						}
					}
				}
			}
			DataRow[] drArr = dtbAllItem.Select("1=1","PRINT_SEQ_INT ASC");
			for(int i=0;i<drArr.Length;i++)
			{
				bool blnSameItem = false;
				for(int j=0;j<m_objViewer.m_lsvApplUnitItem.Items.Count;j++)
				{
					if(drArr[i]["check_item_id_chr"].ToString().Trim() == ((DataRow)m_objViewer.m_lsvApplUnitItem.Items[j].Tag)
						["check_item_id_chr"].ToString().Trim())
					{
						blnSameItem = true;
						clsApplUnitDetail_VO objApplDetail = new clsApplUnitDetail_VO();
						objApplDetail.strApplUnitID = drArr[i]["apply_unit_id_chr"].ToString().Trim();
						objApplDetail.strCheckItemID = drArr[i]["check_item_id_chr"].ToString().Trim();
						m_arlSameApplyUnitItem.Add(objApplDetail);
					}
				}
				if(!blnSameItem)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = drArr[i]["check_item_id_chr"].ToString().Trim();
					objlsvItem.SubItems.Add(drArr[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
					objlsvItem.SubItems.Add(drArr[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
					objlsvItem.SubItems.Add(drArr[i]["PRINT_SEQ_INT"].ToString().Trim());
					objlsvItem.Tag = drArr[i];
					m_objViewer.m_lsvApplUnitItem.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 根据选中的申请单元列出其所有的检验项目(OVER) 童华 2004.09.08
		public void m_mthGetApplUnitItem(TreeNode p_objTreeNode)
		{
			if(p_objTreeNode == m_objViewer.m_trvApplUnit.Nodes[0])
				return;
			long lngRes = 0;
			m_objViewer.m_lsvApplUnitItem.Items.Clear();
			clsCheckItem_VO[] objResultArr = null;
			clsDomainController_ApplyUnitManage objManage = new clsDomainController_ApplyUnitManage();
			lngRes = objManage.m_lngGetCheckItemByApplUnitID(((clsApplUnit_VO)p_objTreeNode.Tag).strApplUnitID,out objResultArr);
			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem(objResultArr[i].m_strCheck_Item_ID);
					objlsvItem.SubItems.Add(objResultArr[i].m_strCheck_Item_English_Name);
					objlsvItem.SubItems.Add(objResultArr[i].m_strCheck_Item_Name);
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvApplUnitItem.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 获取所有已经添加的申请单元 童华 2004.09.10
		public void m_mthGetUsedApplUnit()
		{
			long lngRes = 0;
			m_objSampleGroupUnitArr = null;
			lngRes = m_objManage.m_lngGetApplUnitBySampleGroupID(null,out m_objSampleGroupUnitArr);
		}
		#endregion

		#region 查询所有的申请单元和所有已经添加的申请单元 童华 2004.09.08
		public void m_mthGetAllApplUnit()
		{
//			m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Clear();
			long lngRes = 0;
//			clsApplUnit_VO[] objResultArr = null;
			//所有已经添加的申请单元
			m_objSampleGroupUnitArr = null;
			lngRes = m_objManage.m_lngGetApplUnitBySampleGroupID(null,out m_objSampleGroupUnitArr);

//			clsDomainController_ApplyUnitManage objManage = new clsDomainController_ApplyUnitManage();
//			lngRes = objManage.m_lngGetAllApplUnit(out objResultArr);
//			if(lngRes > 0 && objResultArr != null && objResultArr.Length > 0)
//			{
//				for(int i=0;i<objResultArr.Length;i++)
//				{
//					TreeNode objTreeNode = new TreeNode();
//					objTreeNode.Text = "("+objResultArr[i].strApplUnitID+")"+objResultArr[i].strApplUnitName;
//					objTreeNode.Tag = objResultArr[i];
//					m_objViewer.m_trvApplUnit.Nodes[0].Nodes.Add(objTreeNode);
//				}
//			}
		}
		#endregion

		#region 获取标本组对应的标本类型列表 童华 2004.09.06
		public void m_mthGetGroupSampleBySampleGroupID()
		{
			if(m_objViewer.txtCheckGroupNo.Text.ToString().Trim() == "")
				return;
			m_objViewer.m_lsvGroupSampleType.Items.Clear();
			string strCheckGroupNo = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
			long lngRes = 0;
			clsLisGroupSampleType_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetGroupSampleTypeBySampleGroupID(strCheckGroupNo,out objResultArr);
			if(lngRes > 0 && objResultArr != null)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objResultArr[i].m_strSAMPLE_TYPE_DESC_VCHR;
					objlsvItem.Tag = objResultArr[i];
					m_objViewer.m_lsvGroupSampleType.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 添加标本组标本类型
		public void m_mthAddGroupSampleType()
		{
			if(m_objViewer.m_cboGroupSampleType.Items.Count <= 0)
				return;

			if(m_objViewer.m_lsvGroupSampleType.Items.Count >= 0)
			{
				for(int i=0;i<m_objViewer.m_lsvGroupSampleType.Items.Count;i++)
				{
					clsLisGroupSampleType_VO objTemp = (clsLisGroupSampleType_VO)m_objViewer.m_lsvGroupSampleType.Items[i].Tag;
					if(objTemp.m_strSAMPLE_TYPE_ID_CHR == m_objViewer.m_cboGroupSampleType.SelectedValue.ToString().Trim())
					{
						MessageBox.Show("该标本类型已被添加！");
						return;
					}
				}
			}

			clsLisGroupSampleType_VO objRecord = new clsLisGroupSampleType_VO();
			objRecord.m_strSAMPLE_TYPE_DESC_VCHR = m_objViewer.m_cboGroupSampleType.Text.ToString().Trim();
			objRecord.m_strSAMPLE_TYPE_ID_CHR = m_objViewer.m_cboGroupSampleType.SelectedValue.ToString().Trim();
			objRecord.m_strSAMPLE_GROUP_ID_CHR = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();

			m_arlGroupSampleAdd.Add(objRecord);

			ListViewItem objlsvItem = new ListViewItem();
			objlsvItem.Text = objRecord.m_strSAMPLE_TYPE_DESC_VCHR;
			objlsvItem.Tag = objRecord;
			m_objViewer.m_lsvGroupSampleType.Items.Add(objlsvItem);
		}
		#endregion

		#region 删除标本组标本类型
		public void m_mthRemoveGroupSampleType()
		{
			if(m_objViewer.m_cboGroupSampleType.Items.Count <= 0)
				return;

			for(int j=0;j<m_objViewer.m_lsvGroupSampleType.Items.Count;j++)
			{
				if(m_objViewer.m_lsvGroupSampleType.Items[j].Checked)
				{
					bool blnRemove = false;
					clsLisGroupSampleType_VO objGroupSample = (clsLisGroupSampleType_VO)m_objViewer.m_lsvGroupSampleType.Items[j].Tag;
					for(int i=0;i<m_arlGroupSampleAdd.Count;i++)
					{
						if(((clsLisGroupSampleType_VO)m_arlGroupSampleAdd[i]).m_strSAMPLE_TYPE_ID_CHR.Trim() == 
							objGroupSample.m_strSAMPLE_TYPE_ID_CHR.Trim())
						{
							m_arlGroupSampleAdd.RemoveAt(i);
							m_objViewer.m_lsvGroupSampleType.Items[j].Remove();
							j--;
							blnRemove = true;
						}
					}
					if(!blnRemove)
					{
						m_arlGroupSampleRemove.Add(objGroupSample);
						m_objViewer.m_lsvGroupSampleType.Items[j].Remove();
					}
				}
			}
		}
		#endregion

		#region 获取标本组对应的仪器型号列表 2004.08.18
		public void m_mthGetSampleGroupModel()
		{
			if(m_objViewer.txtCheckGroupNo.Text.ToString().Trim() == "")
				return;
			m_arlSampleModelRaw.Clear();
			m_objViewer.m_lsvDeviceModel.Items.Clear();
			string strCheckGroupNo = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
			long lngRes = 0;
			clsLisSampleGroupModel_VO[] objResultArr = null;
			lngRes = m_objManage.m_lngGetDeviceModelArrBySampleGroupID(strCheckGroupNo,out objResultArr);
			if(lngRes > 0 && objResultArr != null)
			{
				for(int i=0;i<objResultArr.Length;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = objResultArr[i].m_strDEVICE_MODEL_DESC_VCHR;
					objlsvItem.Tag = objResultArr[i];
					m_arlSampleModelRaw.Add(objResultArr[i]);
					m_objViewer.m_lsvDeviceModel.Items.Add(objlsvItem);
				}
			}
		}
		#endregion

		#region 添加样本组仪器型号
		public void m_mthAddSampleGroupModel()
		{
			if(m_objViewer.cboDeviceModle.Items.Count <= 0 || m_objViewer.cboDeviceModle.Enabled == false)
				return;
			if(m_objViewer.m_lsvDeviceModel.Items.Count >= 0)
			{
				for(int i=0;i<m_objViewer.m_lsvDeviceModel.Items.Count;i++)
				{
					clsLisSampleGroupModel_VO objTemp = (clsLisSampleGroupModel_VO)m_objViewer.m_lsvDeviceModel.Items[i].Tag;
					if(objTemp.m_strDEVICE_MODEL_ID_CHR == m_objViewer.cboDeviceModle.SelectedValue.ToString().Trim())
					{
						MessageBox.Show("该仪器型号已被添加！");
						return;
					}
				}
			}
			
			clsLisSampleGroupModel_VO objSampleGroupModel = new clsLisSampleGroupModel_VO();
			objSampleGroupModel.m_strDEVICE_MODEL_ID_CHR = m_objViewer.cboDeviceModle.SelectedValue.ToString().Trim();
			objSampleGroupModel.m_strSAMPLE_GROUP_ID_CHR = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
			objSampleGroupModel.m_strDEVICE_MODEL_DESC_VCHR = m_objViewer.cboDeviceModle.Text.ToString().Trim();

			arlSampleModelAdd.Add(objSampleGroupModel);

			ListViewItem objlsvItem = new ListViewItem(objSampleGroupModel.m_strDEVICE_MODEL_DESC_VCHR);
			objlsvItem.Tag = objSampleGroupModel;
			m_objViewer.m_lsvDeviceModel.Items.Add(objlsvItem);
		}
		#endregion

		#region 删除样本组仪器型号
		public void m_mthDelSampleGroupModel()
		{
			if(m_objViewer.m_lsvDeviceModel.Items.Count <= 0 || m_objViewer.cboDeviceModle.Enabled == false)
				return;
			for(int j=0;j<m_objViewer.m_lsvDeviceModel.Items.Count;j++)
			{
				if(m_objViewer.m_lsvDeviceModel.Items[j].Checked)
				{
					bool blnRemove = false;
					clsLisSampleGroupModel_VO objDeviceModel = (clsLisSampleGroupModel_VO)m_objViewer.m_lsvDeviceModel.Items[j].Tag;
					for(int i=0;i<arlSampleModelAdd.Count;i++)
					{
						if(((clsLisSampleGroupModel_VO)arlSampleModelAdd[i]).m_strDEVICE_MODEL_ID_CHR.Trim() == 
							objDeviceModel.m_strDEVICE_MODEL_ID_CHR.Trim())
						{
							arlSampleModelAdd.RemoveAt(i);
							m_objViewer.m_lsvDeviceModel.Items[j].Remove();
							j--;
							blnRemove = true;
						}
					}
					if(!blnRemove)
					{
						clsLisSampleGroupModel_VO objSampleGroupModel = new clsLisSampleGroupModel_VO();
						objSampleGroupModel.m_strDEVICE_MODEL_ID_CHR = objDeviceModel.m_strDEVICE_MODEL_ID_CHR;
						objSampleGroupModel.m_strSAMPLE_GROUP_ID_CHR = m_objViewer.txtCheckGroupNo.Text.ToString().Trim();
						arlSampleModelRemove.Add(objSampleGroupModel);
						m_objViewer.m_lsvDeviceModel.Items[j].Remove();
					}
				}
			}
		}
		#endregion

		#region 初始化信息
		public long GetInitInfo(frmCheckGroup infrmCheckGroup)//,out DataTable dtbAllCheckGroup,out DataTable dtbAllCheckCategory)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			clsDomainController_LisDeviceManage objLisDeviceManage = new clsDomainController_LisDeviceManage();
			DataTable dtbDeviceModel = null;
			//初始化检验组列表
			refreshAllCheckGroupANDTrvCheckGroup(infrmCheckGroup);
			//初始化检验类别列表
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetAllCheckCategory(p_objPrincipal,out dtbAllCheckCategory);
			if(dtbAllCheckCategory.Rows.Count > 0)
			{
				infrmCheckGroup.cboCheckCategory.DataSource = dtbAllCheckCategory;
				infrmCheckGroup.cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
				infrmCheckGroup.cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
			}
			//初始化打印类别列表
			DataTable dtbPrintCategory = null;
			lngRes = objCheckItemSvc.m_lngGetAllPrintCategory(p_objPrincipal,out dtbPrintCategory);
			infrmCheckGroup.cboPrintCategory.DataSource = dtbPrintCategory;
			infrmCheckGroup.cboPrintCategory.DisplayMember = "PRINT_CATEGORY_DESC_VCHR";
			infrmCheckGroup.cboPrintCategory.ValueMember = "PRINT_CATEGORY_ID_CHR";
			
			//初始化样品类别列表
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			DataTable dtbSampleType = null;
			lngRes = objSampleSvc.m_lngGetSampleTypeList(p_objPrincipal,out dtbSampleType);
			infrmCheckGroup.cboSampleType.DataSource = dtbSampleType;
			infrmCheckGroup.cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
			infrmCheckGroup.cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
			infrmCheckGroup.rdbBseGroup.Checked = true;
			//初始化仪器列表
			lngRes = objLisDeviceManage.m_lngGetDeviceModel(out dtbDeviceModel);
			if(dtbDeviceModel.Rows.Count > 0)
			{
				infrmCheckGroup.cboDeviceModle.DataSource = dtbDeviceModel;
				infrmCheckGroup.cboDeviceModle.DisplayMember = "DEVICE_MODEL_DESC_VCHR";
				infrmCheckGroup.cboDeviceModle.ValueMember = "DEVICE_MODEL_ID_CHR";
				infrmCheckGroup.cboDeviceModle.SelectedIndex = 0;
			}
			//初始化所有的标本组明细和报告组明细
			refreshSampleGroupAndReportGroupDetail();

			//初始化申请单元列表
			m_mthGetApplUnitByCheckCategory();
//			m_mthGetAllApplUnit();
			m_mthGetUsedApplUnit();

			return lngRes;
		}
		#endregion

		private void refreshSampleGroupAndReportGroupDetail()
		{
			clsDomainController_ReportManage objDomainReportGroup= new clsDomainController_ReportManage();
			clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
			objDomainReportGroup.m_lngGetAllReportGroupDetail(out objReportGroupDetailVOList);
			objDomainSampleGroup.m_lngGetAllSampleGroupDetail(out objSampleGroupDetailVOList);
		}

		#region 刷新所有的检验组列表
		//刷新所有的检验组列表
		public void refreshAllCheckGroupANDTrvCheckGroup(frmCheckGroup infrmCheckGroup)
		{
			//初始化检验组列表
			clsDomainController_ReportManage objDomainReportGroup= new clsDomainController_ReportManage();
			clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
			clsReportGroup_VO[] objReportGroupVOList = null;
//			clsSampleGroup_VO[] objSampleGroupVOList = null;
			objDomainReportGroup.m_lngGetAllReportGroup(out objReportGroupVOList);
//			objDomainSampleGroup.m_lngGetAllSampleGroup(out objSampleGroupVOList);
			//初始化trvCheckGroup列表
			infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes.Clear();
			if(objReportGroupVOList!=null)
			{
				if(objReportGroupVOList.Length>0)
				{							
					TreeNode CurNode=null;
					TreeNode ChildNode = null;
		
					for(int i=0;i<objReportGroupVOList.Length;i++)
					{
						CurNode=infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes.Add("("+objReportGroupVOList[i].strReportGroupID+")"+objReportGroupVOList[i].strReportGroupName);
						CurNode.Tag=objReportGroupVOList[i];
						if(objReportGroupVOList[i].objSampleGroupVO != null)
						{
							if(objReportGroupVOList[i].objSampleGroupVO.Length > 0)
							{
								for(int j=0;j<objReportGroupVOList[i].objSampleGroupVO.Length;j++)
								{
									ChildNode = CurNode.Nodes.Add("("+objReportGroupVOList[i].objSampleGroupVO[j].strSampleGroupID+")"+objReportGroupVOList[i].objSampleGroupVO[j].strSampleGroupName);
									ChildNode.Tag = objReportGroupVOList[i].objSampleGroupVO[j];
								}
							}
						}
					}
				}
			}
			TreeNode[] objTreeNodeArr = null;
			m_objManage.m_mthGetSampleGroupTreeNodes(out objTreeNodeArr);
			infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes.Clear();
			if(objTreeNodeArr != null)
			{
				infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes.AddRange(objTreeNodeArr);
			}

			//初始化trvSubCheckGroup列表
			infrmCheckGroup.trvSubCheckGroup.Nodes.Clear();
			TreeNode[] objSubTreeNodeArr = null;
			m_objManage.m_mthGetSampleGroupTreeNodes(out objSubTreeNodeArr);
			if(objSubTreeNodeArr != null)
			{
				infrmCheckGroup.trvSubCheckGroup.Nodes.AddRange(objSubTreeNodeArr);
			}
		}
		#endregion

		//获取trvCheckGroup的子节点信息
		public void getChildNode(frmCheckGroup infrmCheckGroup,TreeNode p_treeNode)
		{
			string strFussField="GROUPID_CHR";
			string strFieldValue=((clsCheckGroup_VO)p_treeNode.Tag).m_strGROUPID;
			string strOrderField=strFussField;
			try
			{
                com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objLisGroupSvc = null;
                objLisGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
				System.Security.Principal.IPrincipal p_objPrincipal = null;
				com.digitalwave.iCare.ValueObject.clsCheckGroup_VO[] objChildGroupVOList= null;
				objLisGroupSvc.m_mthGetGroupInfo(p_objPrincipal,1,strFussField,strFieldValue,strOrderField,false,out objChildGroupVOList);
				
				if(objChildGroupVOList!=null)
				{
					if(objChildGroupVOList.Length>0)
					{	
//						p_treeNode.Nodes.Remove(p_treeNode.Nodes[0]);

						TreeNode CurNode=null;		
						for(int i=0;i<objChildGroupVOList.Length;i++)
						{
							CurNode=p_treeNode.Nodes.Add("("+objChildGroupVOList[i].m_strGROUPID+")"+objChildGroupVOList[i].m_strGroupName);
							CurNode.Tag=objChildGroupVOList[i];
							if(int.Parse(objChildGroupVOList[i].m_strHas_SubGroup) > 0)
								getChildNode(infrmCheckGroup,CurNode);
//								CurNode.Nodes.Add("");
						}
					}
				} 
			}
			catch(Exception e)
			{
				throw e;
			}
		}

		//构造trvAddSubGroup子组节点信息 2004.05.10(考虑在基本组后添加检验项目信息)
		public void getAddSubGroupChildNode(frmCheckGroup infrmCheckGroup,TreeNode p_treeNode)
		{
			string strFussField="GROUPID_CHR";
			string strFieldValue=((clsCheckGroup_VO)p_treeNode.Tag).m_strGROUPID;
			string strOrderField=strFussField;
			try
			{
                com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc objLisGroupSvc = null;
                objLisGroupSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckGroupSvc));
				System.Security.Principal.IPrincipal p_objPrincipal = null;
				com.digitalwave.iCare.ValueObject.clsCheckGroup_VO[] objChildGroupVOList= null;
				objLisGroupSvc.m_mthGetGroupInfo(p_objPrincipal,1,strFussField,strFieldValue,strOrderField,false,out objChildGroupVOList);
				
				if(objChildGroupVOList!=null)
				{
					if(objChildGroupVOList.Length>0)
					{	
						//						p_treeNode.Nodes.Remove(p_treeNode.Nodes[0]);

						TreeNode CurNode=null;		
						for(int i=0;i<objChildGroupVOList.Length;i++)
						{
							CurNode=p_treeNode.Nodes.Add("("+objChildGroupVOList[i].m_strGROUPID+")"+objChildGroupVOList[i].m_strGroupName);
							CurNode.Tag=objChildGroupVOList[i];
							if(int.Parse(objChildGroupVOList[i].m_strHas_SubGroup) > 0)
								getChildNode(infrmCheckGroup,CurNode);
							if(objChildGroupVOList[i].m_strHas_SubGroup == "0")
							{
								CurNode.Nodes.Add("");
							}
						}
					}
				} 
			}
			catch(Exception e)
			{
				throw e;
			}
		}


		#region 添加检验项目
		public void NewCheckItemBybtnNewCheckClick(frmCheckGroup infrmCheckGroup)
		{
			//此处用数组isAdded来判断已经添加了的项目不能重复添加
			int count = infrmCheckGroup.lsvCheckItem.Items.Count;
			if(count > 0)
			{
				for(int i=0;i<count;i++)
				{
					if(infrmCheckGroup.lsvCheckItem.Items[i].Checked)
					{
						int addCount = infrmCheckGroup.lsvAddCheckItem.Items.Count;
						if(objSampleGroupDetailVOList != null && objSampleGroupDetailVOList.Length > 0)
						{
							for(int k=0;k<objSampleGroupDetailVOList.Length;k++)
							{
								if(infrmCheckGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim() == objSampleGroupDetailVOList[k].strCheckItemID)
								{
									MessageBox.Show("该检验项目已被其他标本组添加！","检验项目",MessageBoxButtons.OK);
									return;
								}
							}
						}
						if(addCount > 0)
						{
							for(int j=0;j<addCount;j++)
							{
								if(infrmCheckGroup.lsvAddCheckItem.Items[j].SubItems[0].Text.ToString().Trim() == infrmCheckGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim())
								{
									MessageBox.Show("不能添加重复的检验项目！","检验项目",MessageBoxButtons.OK);
									return;
								}
							}
							if(((DataRow)infrmCheckGroup.lsvAddCheckItem.Items[0].Tag)["CHECK_CATEGORY_ID_CHR"].ToString().Trim() != ((DataRow)infrmCheckGroup.lsvCheckItem.Items[i].Tag)["CHECK_CATEGORY_ID_CHR"].ToString().Trim())
							{
								MessageBox.Show("不能添加不同检验类别的检验项目！","检验项目",MessageBoxButtons.OK);
								return;
							}
							if(((DataRow)infrmCheckGroup.lsvAddCheckItem.Items[0].Tag)["SAMPLETYPE_VCHR"].ToString().Trim() != ((DataRow)infrmCheckGroup.lsvCheckItem.Items[i].Tag)["SAMPLETYPE_VCHR"].ToString().Trim())
							{
								MessageBox.Show("不能添加不同样本类别的检验项目！","检验项目",MessageBoxButtons.OK);
								return;
							}
							ListViewItem objlsvItem = new ListViewItem();
							objlsvItem.Text = infrmCheckGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
							objlsvItem.SubItems.Add(infrmCheckGroup.lsvCheckItem.Items[i].SubItems[1].Text.ToString().Trim());
							objlsvItem.SubItems.Add(infrmCheckGroup.lsvCheckItem.Items[i].SubItems[2].Text.ToString().Trim());
							objlsvItem.SubItems.Add((infrmCheckGroup.lsvAddCheckItem.Items.Count).ToString().Trim());
							objlsvItem.Tag = infrmCheckGroup.lsvCheckItem.Items[i].Tag;
							infrmCheckGroup.lsvAddCheckItem.Items.Add(objlsvItem);
							if(infrmCheckGroup.btnDelCheckItem.Enabled == false)
							{
								infrmCheckGroup.btnDelCheckItem.Enabled = true;
							}
						}
						else
						{
							ListViewItem objlsvItem = new ListViewItem();
							objlsvItem.Text = infrmCheckGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
							objlsvItem.SubItems.Add(infrmCheckGroup.lsvCheckItem.Items[i].SubItems[1].Text.ToString().Trim());
							objlsvItem.SubItems.Add(infrmCheckGroup.lsvCheckItem.Items[i].SubItems[2].Text.ToString().Trim());
							objlsvItem.SubItems.Add((infrmCheckGroup.lsvAddCheckItem.Items.Count).ToString().Trim());
							objlsvItem.Tag = infrmCheckGroup.lsvCheckItem.Items[i].Tag;
							infrmCheckGroup.lsvAddCheckItem.Items.Add(objlsvItem);
							if(infrmCheckGroup.btnDelCheckItem.Enabled == false)
							{
								infrmCheckGroup.btnDelCheckItem.Enabled = true;
							}
						}
					}
				}
			}
		}
		#endregion

		public void DelCheckItemBybtnDelCheckClick(frmCheckGroup infrmCheckGroup)
		{
			int count = infrmCheckGroup.lsvAddCheckItem.Items.Count;
			if(count > 0)
			{
				for(int i=0;i<infrmCheckGroup.lsvAddCheckItem.Items.Count;i++)
				{
					if(infrmCheckGroup.lsvAddCheckItem.Items[i].Checked)
					{
						infrmCheckGroup.lsvAddCheckItem.Items[i].Remove();
						i = i-1;
					}
				}
			}
		}

		#region 显示选中的组的相关信息
		public void m_mthTreeNodeSelectIndexChanged(frmCheckGroup infrmCheckGroup,TreeNode objTreeNode)
		{
			if(objTreeNode.Parent != null)
			{
				infrmCheckGroup.btnSaveCheckGroup.Text = "修改";
				clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
				//标本组
				if(objTreeNode.Parent.Parent != null && objTreeNode.Nodes.Count == 0 && 
					objTreeNode.Parent != infrmCheckGroup.trvCheckGroup.Nodes[0]) //
				{
					infrmCheckGroup.lsvAddCheckItem.Items.Clear();
					arlSampleModelRemove.Clear();
					arlSampleModelAdd.Clear();
					//初始化基本信息
					infrmCheckGroup.rdbBseGroup.Checked = true;
					infrmCheckGroup.btnDelCheckItem.Enabled = true;
					clsSampleGroup_VO objSampleGroupVO = (clsSampleGroup_VO)objTreeNode.Tag;
					string strCheckGroupID = objSampleGroupVO.strSampleGroupID;//((clsSampleGroup_VO)objTreeNode.Tag).m_strGROUPID;
					infrmCheckGroup.txtCheckGroupNo.Text = strCheckGroupID;
					infrmCheckGroup.txtCheckGroupName.Text = objSampleGroupVO.strSampleGroupName;
					infrmCheckGroup.txtPyCode.Text = objSampleGroupVO.strPYCode;
					infrmCheckGroup.txtWbCode.Text = objSampleGroupVO.strWBCode;
					infrmCheckGroup.txtAssist01.Text = objSampleGroupVO.strAssistCode01;
					infrmCheckGroup.txtAssist02.Text = objSampleGroupVO.strAssistCode02;
					infrmCheckGroup.txtPrintTitle.Text = objSampleGroupVO.strPRINT_TITLE_VCHR;
					infrmCheckGroup.cboCheckCategory.SelectedValue = objSampleGroupVO.strCheckCategoryID;
					if(objSampleGroupVO.strIsHandWork == "0")
					{
						infrmCheckGroup.rdbDeviceSample.Checked = true;
						//						infrmCheckGroup.cboDeviceModle.SelectedValue = objSampleGroupVO.strDeviceModleID;
					}
					else
					{
						infrmCheckGroup.rdbManualSample.Checked = true;
					}
					infrmCheckGroup.txtSampleRemark.Text = objSampleGroupVO.strRemark;
					//获取该标本组下的仪器型号列表
					m_mthGetSampleGroupModel();
					//获取该标本组下的标本类型列表
					m_mthGetGroupSampleBySampleGroupID();
					if(infrmCheckGroup.m_lsvGroupSampleType.Items.Count > 0)
					{
						infrmCheckGroup.cboSampleType.SelectedValue = 
							((clsLisGroupSampleType_VO)infrmCheckGroup.m_lsvGroupSampleType.Items[0].Tag).m_strSAMPLE_TYPE_ID_CHR;
					}
					m_mthGetSampleGroupUnitBySampleGroupID();
				}
				else if(objTreeNode.Parent == infrmCheckGroup.trvCheckGroup.Nodes[0])
				{
					m_objViewer.cboCheckCategory.SelectedValue = ((clsCheckCategory_VO)objTreeNode.Tag).m_strCheck_Category_ID;
				}
				//报告组
				if(objTreeNode.Parent.Index == 1 && objTreeNode.Parent.Parent == null)
				{
					TreeNode objReportTreeNode = infrmCheckGroup.trvCheckGroup.SelectedNode;
					clsReportGroup_VO objReportGroup = (clsReportGroup_VO)objReportTreeNode.Tag;

					infrmCheckGroup.trvAddSubGroup.Nodes.Clear();
					infrmCheckGroup.rdbCheckGroup.Checked = true;
					infrmCheckGroup.txtCheckGroupNo.Text = objReportGroup.strReportGroupID;
					infrmCheckGroup.txtCheckGroupName.Text = objReportGroup.strReportGroupName;
					infrmCheckGroup.txtPyCode.Text = objReportGroup.strPYCode;
					infrmCheckGroup.txtWbCode.Text = objReportGroup.strWBCode;
					infrmCheckGroup.txtAssist01.Text = objReportGroup.strAssistCode01;
					infrmCheckGroup.txtAssist02.Text = objReportGroup.strAssistCode02;
					infrmCheckGroup.txtPrintTitle.Text = objReportGroup.strPrintTitle;
					
					if(objReportGroup != null)
					{
						if(objReportGroup.objSampleGroupVO != null && objReportGroup.objSampleGroupVO.Length > 0)
						{
							TreeNode objAddNode = null;
							for(int i=0;i<objReportGroup.objSampleGroupVO.Length;i++)
							{
								objAddNode = infrmCheckGroup.trvAddSubGroup.Nodes.Add("("+objReportGroup.objSampleGroupVO[i].strSampleGroupID+")"+
									objReportGroup.objSampleGroupVO[i].strSampleGroupName);
								objAddNode.Tag = objReportGroup.objSampleGroupVO[i];
							}
						}
					}
				}
			}
		}
		#endregion

		#region 获取选中的TreeView节点的组包含的检验项目并填充到lsvSubGroupCheckItem
		//获取选中的TreeView节点的组包含的检验项目并填充到lsvSubGroupCheckItem
//		public void getCheckItemByGroupID(frmCheckGroup infrmCheckGroup,TreeNode objTreeNode)
//		{
////			long lngRes = 0;
//			infrmCheckGroup.lsvSubGroupCheckItem.Items.Clear();
//			if(objTreeNode.Parent != null)
//			{
//				clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
//				DataTable dtbCheckItem = null;
//				objDomainSampleGroup.m_lngGetCheckItemBySampleGroupID(((clsSampleGroup_VO)objTreeNode.Tag).strSampleGroupID,out dtbCheckItem);
//				if(dtbCheckItem != null)
//				{
//					if(dtbCheckItem.Rows.Count > 0)
//					{
//						for(int i=0;i<dtbCheckItem.Rows.Count;i++)
//						{
//							ListViewItem objlsvItem = new ListViewItem();
//							objlsvItem.Text = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
//							objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
//							objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
//							objlsvItem.Tag = (DataRow)dtbCheckItem.Rows[i];
//							infrmCheckGroup.lsvSubGroupCheckItem.Items.Add(objlsvItem);
//						}
//					}
//				}
//			}
//		}
		#endregion

		#region 当TreeView的父节点选中时，其所有的子结点全部选中
		//当TreeView的父节点选中时，其所有的子结点全部选中
		public void checkAllByParentChecked(frmCheckGroup infrmCheckGroup,TreeNode objTreeNode)
		{
			if(objTreeNode.Checked)
			{
				for(int i=0;i<objTreeNode.Nodes.Count;i++)
				{
					objTreeNode.Nodes[i].Checked = true;
				}
			}
			else
			{
				for(int i=0;i<objTreeNode.Nodes.Count;i++)
				{
					objTreeNode.Nodes[i].Checked = false;
				}
			}
		}
		#endregion

		#region 添加trvAddSubGroup子组列表
		//添加lsvAddSubGroup子组列表
		public void AddAllCheckSubGroup(frmCheckGroup infrmCheckGroup)
		{
			int count = infrmCheckGroup.trvCheckGroup.Nodes.Count;
			string strCheckGroupID = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
//			TreeNodeCollection nodes = infrmCheckGroup.trvSubCheckGroup.Nodes[0].Nodes;
			for(int i=0;i<infrmCheckGroup.trvSubCheckGroup.Nodes.Count;i++)
			{
				m_mthfindNextLevel(infrmCheckGroup.trvSubCheckGroup.Nodes[i],infrmCheckGroup);
			}
		}
		#endregion

		public void m_mthfindNextLevel(TreeNode p_objTreeNode,frmCheckGroup infrmCheckGroup)
		{
			for(int i=0;i<p_objTreeNode.Nodes.Count;i++)
			{
				if(p_objTreeNode.Nodes[i].Checked)
				{
						if(objReportGroupDetailVOList != null && objReportGroupDetailVOList.Length  > 0)
						{
							for(int j=0;j<objReportGroupDetailVOList.Length;j++)
							{
								if(((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag).strSampleGroupID == objReportGroupDetailVOList[j].strSampleGroupID)
								{
									MessageBox.Show("该标本组已经被其他报告组添加！","报告组",MessageBoxButtons.OK);
									return;
								}
							}
						}

					if(infrmCheckGroup.trvAddSubGroup.Nodes.Count > 0)
					{
						foreach(TreeNode objAddedTreeNode in infrmCheckGroup.trvAddSubGroup.Nodes)
						{
							if(((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag).strSampleGroupID == ((clsSampleGroup_VO)objAddedTreeNode.Tag).strSampleGroupID)
							{
								MessageBox.Show("已经添加了该标本组","报告组",MessageBoxButtons.OK);
								return;
							}
						}
						TreeNode objAddSubTreeNode = null;
						objAddSubTreeNode = infrmCheckGroup.trvAddSubGroup.Nodes.Add("("+((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag)
							.strSampleGroupID+")"+((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag).strSampleGroupName);
						objAddSubTreeNode.Tag = ((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag);
					}
					else
					{
						TreeNode objAddSubTreeNode = null;
						objAddSubTreeNode = infrmCheckGroup.trvAddSubGroup.Nodes.Add("("+((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag)
							.strSampleGroupID+")"+((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag).strSampleGroupName);
						objAddSubTreeNode.Tag = ((clsSampleGroup_VO)p_objTreeNode.Nodes[i].Tag);
					}
				}
			}
		}

//		public void XX(com.digitalwave.iCare.gui.LIS.frmCheckGroup infrmCheckGroup,TreeNode objTreeNode)
//		{
//			for(int i=0;i<objTreeNode.Nodes.Count;i++)
//			{
//				string strHasSubGroup = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strHas_SubGroup;
//				string strGroupID = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strGROUPID;
//				string strGroupName = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strGroupName;
//
//				if(objTreeNode.Nodes[i].Checked)
//				{
//					if(objTreeNode.Checked)
//					{
//					}
//					else
//					{
//						//对于检验申请组的子组添加情况
//						if(infrmCheckGroup.rdbCheckGroup.Checked)
//						{
//							//1.判断该组是否是基本组
//							if(strHasSubGroup != "0")
//							{
//								MessageBox.Show("检验单组只能添加基本组作为子组！","检验组",MessageBoxButtons.OK);
//								return;
//							}
//		
//							//2.判断是否重复添加该组
//							foreach(TreeNode objSubTreeNode in infrmCheckGroup.trvAddSubGroup.Nodes)
//							{
//								string strSubGroupID = ((clsCheckGroup_VO)objSubTreeNode.Tag).m_strGROUPID;
//								string strSubGroupName = ((clsCheckGroup_VO)objSubTreeNode.Tag).m_strGroupName;
//								if(strGroupID == strSubGroupID)
//								{
//									MessageBox.Show("检验组"+strSubGroupName+"("+strSubGroupID+")已添加！","检验组",MessageBoxButtons.OK);
//									return;
//								}
//							}
//							//3.判断是否添加自身作为子组(修改)
//							if(infrmCheckGroup.txtCheckGroupNo.Text != null)
//							{
//								if(strGroupID == infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim())
//								{
//									MessageBox.Show("不能添加自身作为子组","检验单组",MessageBoxButtons.OK);
//									return;
//								}
//							}
//							//判断添加的组是否属于同一个类别
//							if(infrmCheckGroup.trvAddSubGroup.Nodes.Count > 0)
//							{
//								if(((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strCheck_Category_ID != ((clsCheckGroup_VO)infrmCheckGroup.trvAddSubGroup.Nodes[0].Tag).m_strCheck_Category_ID)
//								{
//									MessageBox.Show("添加的组的项目不属于同一个检验类别！","检验单组",MessageBoxButtons.OK);
//									return;
//								}
//							}
//							//添加到trvSubGroup
//							TreeNode objAddSubTreeNode = null;
//							objAddSubTreeNode = infrmCheckGroup.trvAddSubGroup.Nodes.Add("("+strGroupID+")"+strGroupName);
//							objAddSubTreeNode.Tag = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag);
//							if(int.Parse(((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strHas_SubGroup) > 0)
//								getAddSubGroupChildNode(infrmCheckGroup,objAddSubTreeNode);
//							if(((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strHas_SubGroup == "0")
//							{
//								objAddSubTreeNode.Nodes.Add("");
//							}
//						}
//						if(infrmCheckGroup.rdbSelfDefineGroup.Checked)
//						{
//							//1.判断该组是否是基本组
//							if(strHasSubGroup == "0")
//							{
//								MessageBox.Show("自定义组不能添加基本组作为子组！","自定义组",MessageBoxButtons.OK);
//								return;
//							}
//							//2.修改时不能添加自身作为子组和不能添加父节点作为子组
//							if(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim() != "")
//							{
//								if(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim() == strGroupID)
//								{
//									MessageBox.Show("不能添加自身作为子组！","自定义组",MessageBoxButtons.OK);
//									return;
//								}
//								if(findChildNode(infrmCheckGroup,objTreeNode.Nodes[i],infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim()))
//								{
//									MessageBox.Show("不能添加父节点作为子组！","自定义组",MessageBoxButtons.OK);
//									return;
//								}
//							}
//							//3.判断是否已经添加了该组或包含该节点的组
//							if(infrmCheckGroup.trvAddSubGroup.Nodes != null)
//							{
//								for(int k=0;k<infrmCheckGroup.trvAddSubGroup.Nodes.Count;k++)
//								{
//									string strSubGroupID = ((clsCheckGroup_VO)infrmCheckGroup.trvAddSubGroup.Nodes[k].Tag).m_strGROUPID;
//									string strSubGroupName = ((clsCheckGroup_VO)infrmCheckGroup.trvAddSubGroup.Nodes[k].Tag).m_strGroupName;
//									if(strGroupID == strSubGroupID)
//									{
//										MessageBox.Show("检验组"+strSubGroupName+"("+strSubGroupID+")已添加！","自定义组",MessageBoxButtons.OK);
//										return;
//									}
//									if(findChildNode(infrmCheckGroup,infrmCheckGroup.trvAddSubGroup.Nodes[k],strGroupID))
//									{
//										MessageBox.Show("不能添加父节点作为子组！","自定义组",MessageBoxButtons.OK);
//										return;
//									}
//									//判断将要添加的节点是否包含了已经添加的节点作为组
//									if(findChildNode(infrmCheckGroup,objTreeNode.Nodes[i],strSubGroupID))
//									{
//										MessageBox.Show("该组的子组已经被添加！","自定义组",MessageBoxButtons.OK);
//										return;
//									}
//									//判断添加的节点及其子节点是否重复添加
//									if(findChildNode(infrmCheckGroup,infrmCheckGroup.trvAddSubGroup.Nodes[k],objTreeNode.Nodes[i]))
//									{
//										MessageBox.Show("该组的子组重复被添加！","自定义组",MessageBoxButtons.OK);
//										return;
//									}
//								}
//							}
//							//添加到trvSubGroup
//							TreeNode objAddSubTreeNode = null;
//							objAddSubTreeNode = infrmCheckGroup.trvAddSubGroup.Nodes.Add("("+strGroupID+")"+strGroupName);
//							objAddSubTreeNode.Tag = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag);
//							if(int.Parse(((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strHas_SubGroup) > 0)
//								getAddSubGroupChildNode(infrmCheckGroup,objAddSubTreeNode);
//						}
//					}
//				}
//				if(int.Parse(strHasSubGroup) > 0)
//				{
//					XX(infrmCheckGroup,objTreeNode.Nodes[i]);
//				}
//			}
//		}

		//判断某一节点是否是另一节点的子组
		public bool findChildNode(com.digitalwave.iCare.gui.LIS.frmCheckGroup infrmCheckGroup,TreeNode objSrcNode,TreeNode objDestNode)
		{
			bool bolfind = false;
			for(int j=0;j<objDestNode.Nodes.Count;j++)
			{
				string strDesGroupID = ((clsCheckGroup_VO)objDestNode.Nodes[j].Tag).m_strGROUPID;
				string strDesHasSubGroup = ((clsCheckGroup_VO)objDestNode.Nodes[j].Tag).m_strHas_SubGroup;
				for(int i=0;i<objSrcNode.Nodes.Count;i++)
				{
					string strGroupID = ((clsCheckGroup_VO)objSrcNode.Nodes[i].Tag).m_strGROUPID;
					string strSrcHasSubGroup = ((clsCheckGroup_VO)objSrcNode.Nodes[i].Tag).m_strHas_SubGroup;

					if(strGroupID == strDesGroupID)
					{
						bolfind = true;
						return bolfind;
					}

					if(int.Parse(strSrcHasSubGroup) > 0)
					{
						bolfind = findChildNode(infrmCheckGroup,objSrcNode.Nodes[i],objDestNode);
						if(bolfind)
						{
							return bolfind;
						}
					}
				}
				if(int.Parse(strDesHasSubGroup) > 0)
				{
					bolfind = findChildNode(infrmCheckGroup,objSrcNode,objDestNode.Nodes[j]);
					if(bolfind)
					{
						return bolfind;
					}
				}
			}
			return bolfind;
		}

		//判断自定义组时是否添加了父节点作为子组
		public bool findChildNode(com.digitalwave.iCare.gui.LIS.frmCheckGroup infrmCheckGroup,TreeNode objTreeNode,string strCheckGroupID)
		{
			bool bolfind = false;
			for(int i=0;i<objTreeNode.Nodes.Count;i++)
			{
				string strHasSubGroup = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strHas_SubGroup;
				string strGroupID = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strGROUPID;
				string strGroupName = ((clsCheckGroup_VO)objTreeNode.Nodes[i].Tag).m_strGroupName;

				if(strGroupID == strCheckGroupID)
				{
					bolfind = true;
					return bolfind;
				}

				if(int.Parse(strHasSubGroup) > 0)
				{
					findChildNode(infrmCheckGroup,objTreeNode.Nodes[i],strCheckGroupID);
				}
			}
			return bolfind;
		}

		#region 删除trvAddSubGroup子组列表
		//删除trvAddSubGroup子组列表
		public void DelAllCheckedSubGroup(frmCheckGroup infrmCheckGroup)
		{			
			int count = infrmCheckGroup.trvAddSubGroup.Nodes.Count;
			if(count > 0)
			{
				for(int i=0;i<count;i++)
				{
					if(infrmCheckGroup.trvAddSubGroup.Nodes[i].Checked)
					{
						infrmCheckGroup.trvAddSubGroup.Nodes[i].Remove();
						count--;
						i--;
					}
				}
			}
		}
		#endregion

		#region 保存
		//新增检验组
		public long AddNewCheckGroup(frmCheckGroup infrmCheckGroup)
		{
			long lngRes = 0;
			clsDomainController_ReportManage objDomainReportGroup= new clsDomainController_ReportManage();
			clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
			if(infrmCheckGroup.txtCheckGroupName.Text.ToString().Trim() == "")
			{
				MessageBox.Show("请输入检验名称","",MessageBoxButtons.OK);
				return -1;
			}

			#region 标本组
			//标本组
			if(infrmCheckGroup.rdbBseGroup.Checked)
			{
				if(infrmCheckGroup.m_lsvGroupSampleType.Items.Count <= 0)
				{
					MessageBox.Show("请添加标本组的样本类型！","",MessageBoxButtons.OK);
					return -1;
				}
				if(infrmCheckGroup.m_trvAddSampleGroup.Nodes.Count > 0)
				{
					if(infrmCheckGroup.rdbDeviceSample.Checked)
					{
						if(infrmCheckGroup.m_lsvDeviceModel.Items.Count <= 0)
						{
							MessageBox.Show("请添加仪器型号列表！","",MessageBoxButtons.OK);
							return -1;
						}
					}
					//1.保存到t_aid_lis_sample_group
					clsSampleGroup_VO objSampleGroup = new clsSampleGroup_VO();
					if(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim() != "")
					{
						objSampleGroup.strSampleGroupID = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
					}
					objSampleGroup.strSampleGroupName = infrmCheckGroup.txtCheckGroupName.Text.ToString().Trim();
					objSampleGroup.strCheckCategoryID = infrmCheckGroup.cboCheckCategory.SelectedValue.ToString().Trim();
//						((DataRow)infrmCheckGroup.lsvCheckItem.Items[0].Tag)["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
//					objSampleGroup.strSampleTypeID = ((DataRow)infrmCheckGroup.lsvCheckItem.Items[0].Tag)["SAMPLETYPE_VCHR"].ToString().Trim();
					objSampleGroup.strPYCode = infrmCheckGroup.txtPyCode.Text.ToString().Trim();
					objSampleGroup.strWBCode = infrmCheckGroup.txtWbCode.Text.ToString().Trim();
					objSampleGroup.strRemark = infrmCheckGroup.txtSampleRemark.Text.ToString().Trim();
					objSampleGroup.strAssistCode01 = infrmCheckGroup.txtAssist01.Text.ToString().Trim();
					objSampleGroup.strAssistCode02 = infrmCheckGroup.txtAssist02.Text.ToString().Trim();
					objSampleGroup.strPRINT_TITLE_VCHR = infrmCheckGroup.txtPrintTitle.Text.ToString().Trim();
					if(infrmCheckGroup.cboDeviceModle.Items.Count > 0)
					{
						if(infrmCheckGroup.rdbDeviceSample.Checked)
						{
//							objSampleGroup.strDeviceModleID = infrmCheckGroup.cboDeviceModle.SelectedValue.ToString().Trim();
							objSampleGroup.strIsHandWork = "0";
						}
						else
						{
							objSampleGroup.strIsHandWork = "1";
						}
					}
					//2.保存到t_aid_lis_sample_group_detail
//					clsSampleGroupDetail_VO[] objSampleGroupDetailVO = null;
//					objSampleGroupDetailVO = new clsSampleGroupDetail_VO[infrmCheckGroup.lsvAddCheckItem.Items.Count];
//					for(int i=0;i<infrmCheckGroup.lsvAddCheckItem.Items.Count;i++)
//					{
//						objSampleGroupDetailVO[i] = new clsSampleGroupDetail_VO();
//						objSampleGroupDetailVO[i].strCheckItemID = infrmCheckGroup.lsvAddCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
//						objSampleGroupDetailVO[i].strPrintSeq = i.ToString().Trim();
//					}
					//2.保存到t_aid_lis_sample_group_unit
					clsLisSampleGroupUnit_VO[] objSampleGroupUnitArr = null;
					objSampleGroupUnitArr = new clsLisSampleGroupUnit_VO[m_objViewer.m_trvAddSampleGroup.Nodes.Count];
					for(int i=0;i<m_objViewer.m_trvAddSampleGroup.Nodes.Count;i++)
					{
						objSampleGroupUnitArr[i] = new clsLisSampleGroupUnit_VO();
						objSampleGroupUnitArr[i].m_strAPPLY_UNIT_ID_CHR = 
							((clsLisSampleGroupUnit_VO)m_objViewer.m_trvAddSampleGroup.Nodes[i].Tag).m_strAPPLY_UNIT_ID_CHR;
						objSampleGroupUnitArr[i].m_strSAMPLE_GROUP_ID_CHR = 
							((clsLisSampleGroupUnit_VO)m_objViewer.m_trvAddSampleGroup.Nodes[i].Tag).m_strSAMPLE_GROUP_ID_CHR;
					}
					//3.更新t_aid_lis_apply_unit_detail的打印顺序
					clsApplUnitDetail_VO[] objApplUnitArr = null;
					objApplUnitArr = new clsApplUnitDetail_VO[m_objViewer.m_lsvApplUnitItem.Items.Count+m_arlSameApplyUnitItem.Count];
					for(int i=0;i<m_objViewer.m_lsvApplUnitItem.Items.Count;i++)
					{
						objApplUnitArr[i] = new clsApplUnitDetail_VO();
						objApplUnitArr[i].strApplUnitID = 
							((DataRow)m_objViewer.m_lsvApplUnitItem.Items[i].Tag)["APPLY_UNIT_ID_CHR"].ToString().Trim();
						objApplUnitArr[i].strCheckItemID = 
							((DataRow)m_objViewer.m_lsvApplUnitItem.Items[i].Tag)["CHECK_ITEM_ID_CHR"].ToString().Trim();
						objApplUnitArr[i].intPrintSeq = i;
					}
					if(m_arlSameApplyUnitItem.Count > 0)
					{
						for(int i=0;i<m_arlSameApplyUnitItem.Count;i++)
						{
							for(int j=0;j<m_objViewer.m_lsvApplUnitItem.Items.Count;j++)
							{
								if(objApplUnitArr[j].strCheckItemID == ((clsApplUnitDetail_VO)m_arlSameApplyUnitItem[i]).strCheckItemID)
								{
									objApplUnitArr[i+m_objViewer.m_lsvApplUnitItem.Items.Count] = (clsApplUnitDetail_VO)m_arlSameApplyUnitItem[i];
									objApplUnitArr[i+m_objViewer.m_lsvApplUnitItem.Items.Count].intPrintSeq = objApplUnitArr[j].intPrintSeq;
								}
							}
						}
					}
					//保存
					lngRes = objDomainSampleGroup.m_lngAddSampleGroup(ref objSampleGroup,ref objSampleGroupUnitArr,objApplUnitArr,
						arlSampleModelAdd,arlSampleModelRemove,m_arlGroupSampleAdd,m_arlGroupSampleRemove);
					if(lngRes > 0)
					{
//						MessageBox.Show("标本组添加成功!","标本组",MessageBoxButtons.OK);
						arlSampleModelRemove.Clear();
						arlSampleModelAdd.Clear();
						m_arlGroupSampleAdd.Clear();
						m_arlGroupSampleRemove.Clear();
						m_arlSampleModelRaw.Clear();
						m_mthGetUsedApplUnit();
						refreshAllCheckGroupANDTrvCheckGroup(infrmCheckGroup);
						//刷新所有的标本组与报告组明细
						refreshSampleGroupAndReportGroupDetail();
						m_mthFindSampleTreeNodeByCheckGroupNO(infrmCheckGroup,objSampleGroup.strSampleGroupID);
					}
				}
				else
				{
					MessageBox.Show("申请单元不能为空!","标本组",MessageBoxButtons.OK);
					return -1;
				}
			}
			#endregion

			#region 报告组
			//报告组
			if(infrmCheckGroup.rdbCheckGroup.Checked)
			{
				if(infrmCheckGroup.trvAddSubGroup.Nodes.Count > 0)
				{
					//1.保存到t_aid_lis_report_group
					clsReportGroup_VO objReportGroupVO = new clsReportGroup_VO();
					if(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim() != "")
					{
						objReportGroupVO.strReportGroupID = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
					}
					if(infrmCheckGroup.txtCheckGroupName.Text.ToString().Trim() == "")
					{
						MessageBox.Show("请输入报告组名称！","报告组",MessageBoxButtons.OK);
						return -1;
					}
					objReportGroupVO.strReportGroupName = infrmCheckGroup.txtCheckGroupName.Text.ToString().Trim();
					objReportGroupVO.strPYCode = infrmCheckGroup.txtPyCode.Text.ToString().Trim();
					objReportGroupVO.strWBCode = infrmCheckGroup.txtWbCode.Text.ToString().Trim();
					objReportGroupVO.strPrintCategoryID = infrmCheckGroup.cboPrintCategory.SelectedValue.ToString().Trim();
					objReportGroupVO.strAssistCode01 = infrmCheckGroup.txtAssist01.Text.ToString().Trim();
					objReportGroupVO.strAssistCode02 = infrmCheckGroup.txtAssist02.Text.ToString().Trim();
					objReportGroupVO.strPrintTitle = infrmCheckGroup.txtPrintTitle.Text.ToString().Trim();
					//2.保存到t_aid_lis_report_group_detail
					clsReportGroupDetail_VO[] objReportGroupDetailVO = new clsReportGroupDetail_VO[infrmCheckGroup.trvAddSubGroup.Nodes.Count];
					for(int i=0;i<infrmCheckGroup.trvAddSubGroup.Nodes.Count;i++)
					{
						objReportGroupDetailVO[i] = new clsReportGroupDetail_VO();
						objReportGroupDetailVO[i].strSampleGroupID = ((clsSampleGroup_VO)infrmCheckGroup.trvAddSubGroup.Nodes[i].Tag).strSampleGroupID;
						objReportGroupDetailVO[i].strPrintSeq = i.ToString().Trim();
					}
					lngRes = objDomainReportGroup.m_lngAddReportGroupAndDetail(ref objReportGroupVO,ref objReportGroupDetailVO);
					if(lngRes > 0)
					{
						refreshAllCheckGroupANDTrvCheckGroup(infrmCheckGroup);
						//刷新所有的标本组与报告组明细
						refreshSampleGroupAndReportGroupDetail();
						ResetAll(infrmCheckGroup);
						m_mthFindReportTreeNodeByCheckGroupNO(infrmCheckGroup,objReportGroupVO.strReportGroupID);
					}
				}
				else
				{
					MessageBox.Show("请添加标本组！","报告组",MessageBoxButtons.OK);
					return -1;
				}
			}
			#endregion

			return lngRes;
		}
		#endregion

		#region 删除检验组
		//删除检验组
		public long DelCheckGroup(frmCheckGroup infrmCheckGroup)
		{
			long lngRes = 0;
			clsDomainController_ReportManage objDomainReportGroup= new clsDomainController_ReportManage();
			clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
			//标本组
			if(infrmCheckGroup.trvCheckGroup.SelectedNode.Parent.Index == 0 || infrmCheckGroup.trvCheckGroup.SelectedNode.Parent.Parent != null) //
			{
				clsReportGroupDetail_VO[] objReportGroupVOList = null;
				lngRes = objDomainReportGroup.m_lngGetAllReportGroupDetail(out objReportGroupVOList);
				if(lngRes > 0 && objReportGroupVOList != null)
				{
					for(int i=0;i<objReportGroupVOList.Length;i++)
					{
						if(objReportGroupVOList[i].strSampleGroupID == infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim())
						{
							MessageBox.Show("请先删除包含该标本组的报告组！","标本组删除",MessageBoxButtons.OK);
							return -1;
						}
					}
				}
				lngRes = objDomainSampleGroup.m_lngDelSampleGroupAndDetail(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim());
				if(lngRes > 0)
				{
					m_mthGetUsedApplUnit();
					this.refreshAllCheckGroupANDTrvCheckGroup(infrmCheckGroup);
					this.refreshSampleGroupAndReportGroupDetail();
				}
			}
			//报告组
			else if(infrmCheckGroup.trvCheckGroup.SelectedNode.Parent.Index == 1 && infrmCheckGroup.trvCheckGroup.SelectedNode.Parent.Parent == null)
			{
                MessageBox.Show("不能能删除报告组！请与管理员联系！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return 0;
                //lngRes = objDomainReportGroup.m_lngDelReportGroupAndDetail(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim());
                //if(lngRes > 0)
                //{
                //    this.refreshAllCheckGroupANDTrvCheckGroup(infrmCheckGroup);
                //    this.refreshSampleGroupAndReportGroupDetail();
                //}
			}
			return lngRes;
		}
		#endregion

		//删除与检验组相关的表的信息
		public long DelRelatedCheckGroup(frmCheckGroup infrmCheckGroup)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc objCheckGroupSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc));
			string strCheckGroupID = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
			if(strCheckGroupID != "")
			{
				lngRes = objCheckGroupSvc.m_lngDelCheckGroupRelatedInfo(p_objPrincipal,strCheckGroupID);
			}
			return lngRes;
		}

		//修改检验组
		public long UpdCheckGroup(frmCheckGroup infrmCheckGroup)
		{
			long lngRes = 0;
			clsDomainController_ReportManage objDomainReportGroup= new clsDomainController_ReportManage();
			clsDomainController_SampleGroupManage objDomainSampleGroup = new clsDomainController_SampleGroupManage();
			string strCheckGroupNO = "";
			//标本组
			if(infrmCheckGroup.trvCheckGroup.SelectedNode.Parent != null && infrmCheckGroup.trvCheckGroup.SelectedNode.Nodes.Count == 0
				&& infrmCheckGroup.trvCheckGroup.SelectedNode.Parent != infrmCheckGroup.trvCheckGroup.Nodes[1]) //
			{
				if(infrmCheckGroup.m_trvAddSampleGroup.Nodes.Count == 0)
				{
					MessageBox.Show("请先添加申请单元！","标本组",MessageBoxButtons.OK);
					return -1;
				}
				strCheckGroupNO = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
//				//1.删除原有的标本组的明细
//				lngRes = objDomainSampleGroup.m_lngDelSampleGroupDetail(strCheckGroupNO);
//				if(lngRes > 0)
//				{
//					//2.保存新的标本组
				lngRes = this.AddNewCheckGroup(infrmCheckGroup);
//				}
				if(lngRes > 0)
				{
					m_mthFindSampleTreeNodeByCheckGroupNO(infrmCheckGroup,strCheckGroupNO);
				}
			}
			//报告组
			if((infrmCheckGroup.trvCheckGroup.SelectedNode.Parent != null && infrmCheckGroup.trvCheckGroup.SelectedNode.Nodes.Count > 0)
				|| infrmCheckGroup.trvCheckGroup.SelectedNode.Parent == infrmCheckGroup.trvCheckGroup.Nodes[1])
			{
				strCheckGroupNO = infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim();
				//1.删除原有的报告组的明细
//				lngRes = objDomainReportGroup.m_lngDelReportGroupDetail(infrmCheckGroup.txtCheckGroupNo.Text.ToString().Trim());
//				if(lngRes > 0)
//				{
					//2.保存新的报告组
					lngRes = this.AddNewCheckGroup(infrmCheckGroup);
//				}
				if(lngRes > 0)
				{
					m_mthFindReportTreeNodeByCheckGroupNO(infrmCheckGroup,strCheckGroupNO);
				}
			}
			return lngRes;
		}

		/// <summary>
		/// 根据标本组ID查询标本节点
		/// </summary>
		/// <param name="infrmCheckGroup"></param>
		/// <param name="p_strCheckGroupNO"></param>
		private void m_mthFindSampleTreeNodeByCheckGroupNO(frmCheckGroup infrmCheckGroup,string p_strCheckGroupNO)
		{
			for(int j=0;j<infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes.Count;j++)
			{
				for(int i=0;i<infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes[j].Nodes.Count;i++)
				{
					clsSampleGroup_VO objCheckGroupVO = (clsSampleGroup_VO)infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes[j].Nodes[i].Tag;
					if(objCheckGroupVO.strSampleGroupID == p_strCheckGroupNO)
					{
						infrmCheckGroup.trvCheckGroup.SelectedNode = infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes[j].Nodes[i];
						m_mthTreeNodeSelectIndexChanged(infrmCheckGroup,infrmCheckGroup.trvCheckGroup.Nodes[0].Nodes[j].Nodes[i]);
						infrmCheckGroup.trvCheckGroup.Focus();
						break;
					}
				}
			}
		}

		/// <summary>
		/// 根据报告组ID查询报告组节点
		/// </summary>
		/// <param name="infrmCheckGroup"></param>
		/// <param name="p_strCheckGroupNO"></param>
		private void m_mthFindReportTreeNodeByCheckGroupNO(frmCheckGroup infrmCheckGroup,string p_strCheckGroupNO)
		{
			for(int i=0;i<infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes.Count;i++)
			{
				clsReportGroup_VO objCheckGroupVO = (clsReportGroup_VO)infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes[i].Tag;
				if(objCheckGroupVO.strReportGroupID == p_strCheckGroupNO)
				{
					infrmCheckGroup.trvCheckGroup.SelectedNode = infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes[i];
					m_mthTreeNodeSelectIndexChanged(infrmCheckGroup,infrmCheckGroup.trvCheckGroup.Nodes[1].Nodes[i]);
					infrmCheckGroup.trvCheckGroup.Focus();
					break;
				}
			}
		}

		private void ResetAll(frmCheckGroup infrmCheckGroup)
		{
			infrmCheckGroup.txtCheckGroupName.Text = "";
			infrmCheckGroup.txtCheckGroupNo.Text = "";
			infrmCheckGroup.txtPyCode.Text = "";
			infrmCheckGroup.txtWbCode.Text = "";
//			infrmCheckGroup.chkBodyCheck.Checked = false;
//			infrmCheckGroup.chkNoFood.Checked = false;
//			infrmCheckGroup.chkReservation.Checked = false;
			infrmCheckGroup.lsvAddCheckItem.Items.Clear();
//			infrmCheckGroup.lsvAddSubGroup.Items.Clear();
//			infrmCheckGroup.lsvAllCheckItemDetail.Items.Clear();
//			infrmCheckGroup.lsvSampleInfo.Items.Clear();
			if(infrmCheckGroup.lsvCheckItem.Items.Count > 0)
			{
				for(int i=0;i<infrmCheckGroup.lsvCheckItem.Items.Count;i++)
				{
					if(infrmCheckGroup.lsvCheckItem.Items[i].Checked)
					{
						infrmCheckGroup.lsvCheckItem.Items[i].Checked = false;
					}
				}
			}
			TreeNodeCollection nodes = infrmCheckGroup.trvSubCheckGroup.Nodes[0].Nodes;
			foreach(TreeNode objTreeNode in nodes)
			{
				if(objTreeNode.Checked)
				{
					objTreeNode.Checked = false;
				}
			}
		}

		public void getTrvAddSubGroupCheckItem(com.digitalwave.iCare.gui.LIS.frmCheckGroup infrmCheckGroup,TreeNode objTreeNode)
		{
			if(((clsCheckGroup_VO)objTreeNode.Tag).m_strHas_SubGroup == "0")
			{
				try
				{
					string strGroupID = ((clsCheckGroup_VO)objTreeNode.Tag).m_strGROUPID;
                    com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                        (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
					System.Security.Principal.IPrincipal p_objPrincipal = null;
					com.digitalwave.iCare.ValueObject.clsCheckItem_VO[] objCheckItemVOList= null;
					objCheckItemSvc.m_lngGetCheckItemByNoSubCheckGroupID(p_objPrincipal,strGroupID,out objCheckItemVOList);
				
					if(objCheckItemVOList!=null)
					{
						if(objCheckItemVOList.Length>0)
						{
							objTreeNode.Nodes.Clear();
							TreeNode CurNode=null;		
							for(int i=0;i<objCheckItemVOList.Length;i++)
							{
								CurNode=objTreeNode.Nodes.Add("("+objCheckItemVOList[i].m_strCheck_Item_English_Name+")"+objCheckItemVOList[i].m_strCheck_Item_Name);
								CurNode.Tag=objCheckItemVOList[i];
							}
						}
					} 
				}
				catch(Exception e)
				{
					throw e;
				}
			}
		}
	}
}
