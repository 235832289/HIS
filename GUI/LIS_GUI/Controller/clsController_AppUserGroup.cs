using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 申请单元＆自定义申请组维护【clsController_AppUserGroup】
    /// </summary>
    public class clsController_AppUserGroup : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 私有成员

        //用于记录所有已经添加为申请单元的检验项目
        com.digitalwave.iCare.ValueObject.clsApplUnitDetail_VO[] objApplUnitDetailVOList = null;
        ArrayList m_arlAddDetail = new ArrayList();
        ArrayList m_arlRemoveDetail = new ArrayList();

        #endregion

        #region 构造函数
        public clsController_AppUserGroup()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 载入页面时的初始化信息

        public long GetInitInfo(frmApplUserGroup infrmApplUserGroup)//,out DataTable dtbAllCheckGroup,out DataTable dtbAllCheckCategory)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;

            //初始化检验组列表
            refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
            //初始化检验类别列表
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
            DataTable dtbAllCheckCategory = null;
            lngRes = objCheckItemSvc.m_lngGetAllCheckCategory(p_objPrincipal, out dtbAllCheckCategory);
            if (dtbAllCheckCategory.Rows.Count > 0)
            {
                infrmApplUserGroup.cboCheckCategory.DataSource = dtbAllCheckCategory;
                infrmApplUserGroup.cboCheckCategory.DisplayMember = "CHECK_CATEGORY_DESC_VCHR";
                infrmApplUserGroup.cboCheckCategory.ValueMember = "CHECK_CATEGORY_ID_CHR";
            }

            infrmApplUserGroup.rdbApplUnit.Checked = true;

            //初始化所有申请单元检验项目明细
            refreshApplUnitDetail();
            return lngRes;
        }

        //刷新所有申请单元检验项目明细
        private void refreshApplUnitDetail()
        {
            long lngRes = 0;
            clsDomainController_LisCheckGroupManage objDomainControllerCheckGroup = new clsDomainController_LisCheckGroupManage();
            lngRes = objDomainControllerCheckGroup.m_lngGetAllApplUnitDetail(out objApplUnitDetailVOList);
        }

        #endregion

        #region 构造申请单元和用户自定义申请组TreeView

        //刷新所有的检验组列表
        public void refreshAllCheckGroupANDTrvCheckGroup(frmApplUserGroup infrmApplUserGroup)
        {
            long lngRes = 0;
            clsDomainController_AppGroupManage objDomainControllerCheckGroup = new clsDomainController_AppGroupManage();
            clsDomainController_ApplyUnitManage objDomainApplyUnit = new clsDomainController_ApplyUnitManage();
            //初始化申请单元列表
            infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes.Clear();
            infrmApplUserGroup.trvSubCheckGroup.Nodes[0].Nodes.Clear();
            //申请单元分类
            clsDomainController_CheckItemManage objCheckCategoryManage = new clsDomainController_CheckItemManage();
            clsCheckCategory_VO[] objCheckCategoryArr = null;
            lngRes = objCheckCategoryManage.m_lngGetCheckCategory(out objCheckCategoryArr);
            if (lngRes > 0 && objCheckCategoryArr != null && objCheckCategoryArr.Length > 0)
            {
                for (int i = 0; i < objCheckCategoryArr.Length; i++)
                {
                    TreeNode objCheckCategoryTreeNode = new TreeNode();
                    objCheckCategoryTreeNode.Text = objCheckCategoryArr[i].m_strCheck_Category_Name;
                    objCheckCategoryTreeNode.Tag = objCheckCategoryArr[i];
                    infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes.Add(objCheckCategoryTreeNode);
                    TreeNode objSubTreeNode = (TreeNode)objCheckCategoryTreeNode.Clone();
                    infrmApplUserGroup.trvSubCheckGroup.Nodes[0].Nodes.Add(objSubTreeNode);
                }
            }
            else
            {
                return;
            }
            clsApplUnit_VO[] objApplUnitVOList = null;
            clsApplUserGroup_VO[] objUserGroupVOList = null;
            TreeNode objTreeNode = null;
            lngRes = objDomainApplyUnit.m_lngGetAllApplUnit(out objApplUnitVOList);

            if (lngRes > 0 && objApplUnitVOList != null)
            {
                if (objApplUnitVOList.Length > 0)
                {
                    for (int i = 0; i < objApplUnitVOList.Length; i++)
                    {
                        for (int j = 0; j < infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes.Count; j++)
                        {
                            if (((clsCheckCategory_VO)infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[j].Tag).m_strCheck_Category_ID ==
                                objApplUnitVOList[i].strCheckCategoryID)
                            {
                                objTreeNode = infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[j].Nodes.Add("(" + objApplUnitVOList[i].strApplUnitID + ")" +
                                    objApplUnitVOList[i].strApplUnitName);
                                objTreeNode.Tag = objApplUnitVOList[i];
                                break;
                            }
                        }
                    }
                }
            }
            //初始化用户自定义组合列表
            clsApplUserGroupRelation_VO[] objApplUserGroupRelationArr = null;
            lngRes = objDomainControllerCheckGroup.m_lngGetAllApplUserGroupRelation(out objApplUserGroupRelationArr);

            infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes.Clear();
            lngRes = objDomainControllerCheckGroup.m_lngGetAllUserGroup(out objUserGroupVOList);
            if (lngRes > 0 && objUserGroupVOList != null)
            {
                if (objUserGroupVOList.Length > 0)
                {
                    for (int i = 0; i < objUserGroupVOList.Length; i++)
                    {
                        bool blnHasParent = false;
                        if (objApplUserGroupRelationArr != null)
                        {
                            for (int j = 0; j < objApplUserGroupRelationArr.Length; j++)
                            {
                                if (objApplUserGroupRelationArr[j].strChildUserGroupID == objUserGroupVOList[i].strUserGroupID)
                                {
                                    blnHasParent = true;
                                }
                            }
                        }
                        if (!blnHasParent)
                        {
                            objTreeNode = infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes.Add("(" + objUserGroupVOList[i].strUserGroupID + ")" + objUserGroupVOList[i].strUserGroupName);
                            objTreeNode.Tag = objUserGroupVOList[i];
                            if (int.Parse(objUserGroupVOList[i].strHasChildGroup) > 0)
                            {
                                //查找下一层的用户定义子组和申请单元
                                getChildUserGroupAndApplUnit(infrmApplUserGroup, objTreeNode);
                            }
                            else
                            {
                                //查找该组下的申请单元
                                getChildApplUnit(infrmApplUserGroup, objTreeNode);
                            }
                        }
                    }
                }
            }
            //trvSubGroup初始化
            //初始化申请单元列表
            if (lngRes > 0 && objApplUnitVOList != null)
            {
                if (objApplUnitVOList.Length > 0)
                {
                    for (int i = 0; i < objApplUnitVOList.Length; i++)
                    {
                        for (int j = 0; j < infrmApplUserGroup.trvSubCheckGroup.Nodes[0].Nodes.Count; j++)
                        {
                            if (((clsCheckCategory_VO)infrmApplUserGroup.trvSubCheckGroup.Nodes[0].Nodes[j].Tag).m_strCheck_Category_ID ==
                                objApplUnitVOList[i].strCheckCategoryID)
                            {
                                objTreeNode = infrmApplUserGroup.trvSubCheckGroup.Nodes[0].Nodes[j].Nodes.Add("(" + objApplUnitVOList[i].strApplUnitID + ")"
                                    + objApplUnitVOList[i].strApplUnitName);
                                objTreeNode.Tag = objApplUnitVOList[i];
                                break;
                            }
                        }
                    }
                }
            }
            //初始化用户自定义组合列表
            infrmApplUserGroup.trvSubCheckGroup.Nodes[1].Nodes.Clear();
            //			lngRes = objDomainControllerCheckGroup.m_lngGetAllUserGroup(out objUserGroupVOList);
            if (lngRes > 0 && objUserGroupVOList != null)
            {
                if (objUserGroupVOList.Length > 0)
                {
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < objUserGroupVOList.Length; i++)
                        {
                            bool blnHasParent = false;
                            if (objApplUserGroupRelationArr != null)
                            {
                                for (int j = 0; j < objApplUserGroupRelationArr.Length; j++)
                                {
                                    if (objApplUserGroupRelationArr[j].strChildUserGroupID == objUserGroupVOList[i].strUserGroupID)
                                    {
                                        blnHasParent = true;
                                    }
                                }
                            }
                            if (!blnHasParent)
                            {
                                objTreeNode = infrmApplUserGroup.trvSubCheckGroup.Nodes[1].Nodes.Add("(" + objUserGroupVOList[i].strUserGroupID + ")" + objUserGroupVOList[i].strUserGroupName);
                                objTreeNode.Tag = objUserGroupVOList[i];
                                if (int.Parse(objUserGroupVOList[i].strHasChildGroup) > 0)
                                {
                                    //查找下一层的用户定义子组和申请单元
                                    getChildUserGroupAndApplUnit(infrmApplUserGroup, objTreeNode);
                                }
                                else
                                {
                                    //查找该组下的申请单元
                                    getChildApplUnit(infrmApplUserGroup, objTreeNode);
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        //查找下一层的用户定义子组和申请单元
        private void getChildUserGroupAndApplUnit(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            long lngRes = 0;
            TreeNode objChildTreeNode = null;
            clsDomainController_LisCheckGroupManage objDomainControllerCheckGroup = new clsDomainController_LisCheckGroupManage();
            string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
            clsApplUserGroup_VO[] objApplUserGroupVO = null;
            lngRes = objDomainControllerCheckGroup.m_lngGetSubGroupByUserGroupID(strUserGroupID, out objApplUserGroupVO);
            if (lngRes > 0 && objApplUserGroupVO != null)
            {
                if (objApplUserGroupVO.Length > 0)
                {
                    //考虑到用户自定义组会有包含申请单元的情况
                    getChildApplUnit(infrmApplUserGroup, objTreeNode);

                    for (int i = 0; i < objApplUserGroupVO.Length; i++)
                    {
                        objChildTreeNode = objTreeNode.Nodes.Add("(" + objApplUserGroupVO[i].strUserGroupID + ")" + objApplUserGroupVO[i].strUserGroupName);
                        objChildTreeNode.Tag = objApplUserGroupVO[i];

                        if (int.Parse(objApplUserGroupVO[i].strHasChildGroup) > 0)
                        {
                            //查找下一层的用户定义子组和申请单元
                            getChildUserGroupAndApplUnit(infrmApplUserGroup, objChildTreeNode);
                        }
                        else
                        {
                            getChildApplUnit(infrmApplUserGroup, objChildTreeNode);
                        }
                    }
                }
            }
            else
            {
                getChildApplUnit(infrmApplUserGroup, objTreeNode);
            }
        }

        //查找该组下的申请单元
        private void getChildApplUnit(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            long lngRes = 0;
            TreeNode objChildTreeNode = null;
            clsDomainController_LisCheckGroupManage objDomainControllerCheckGroup = new clsDomainController_LisCheckGroupManage();
            string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
            clsApplUnit_VO[] objApplUnit = null;
            lngRes = objDomainControllerCheckGroup.m_lngGetApplUnitByUserGroupID(strUserGroupID, out objApplUnit);
            if (lngRes > 0 && objApplUnit != null)
            {
                if (objApplUnit.Length > 0)
                {
                    for (int i = 0; i < objApplUnit.Length; i++)
                    {
                        objChildTreeNode = objTreeNode.Nodes.Add("(" + objApplUnit[i].strApplUnitID + ")" + objApplUnit[i].strApplUnitName);
                        objChildTreeNode.Tag = objApplUnit[i];
                    }
                }
            }
        }

        #endregion

        #region 根据检验类别获取所有的检验项目

        public long getAllCheckItemByCheckCategory(frmApplUserGroup infrmApplUserGroup)//,string strCheckCategoryID)//,out DataTable dtbCheckItemByCategory)
        {
            long lngRes = 0;
            infrmApplUserGroup.lsvCheckItem.Items.Clear();
            string strCheckCategoryID = infrmApplUserGroup.cboCheckCategory.SelectedValue.ToString().Trim();
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
            DataTable dtbCheckItemByCategory = null;
            lngRes = objCheckItemSvc.m_lngGetAllCheckItemByCheckCategory(p_objPrincipal, strCheckCategoryID, out dtbCheckItemByCategory);
            int count = dtbCheckItemByCategory.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ListViewItem objlsvItem = new ListViewItem();
                    objlsvItem.Text = dtbCheckItemByCategory.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                    objlsvItem.SubItems.Add(dtbCheckItemByCategory.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
                    objlsvItem.SubItems.Add(dtbCheckItemByCategory.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                    objlsvItem.Tag = dtbCheckItemByCategory.Rows[i];
                    infrmApplUserGroup.lsvCheckItem.Items.Add(objlsvItem);
                }
            }
            return lngRes;
        }

        #endregion

        #region 选中不同节点时显示该节点的相关信息 童华

        public void lsvCheckGroupSelectIndexChanged(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            if (objTreeNode.Parent != null)
            {
                long lngRes = 0;
                clsDomainController_ApplyUnitManage objDomainControllerCheckGroup = new clsDomainController_ApplyUnitManage();
                //申请单元
                if (objTreeNode.Tag is clsApplUnit_VO)
                {
                    infrmApplUserGroup.rdbApplUnit.Checked = true;
                    infrmApplUserGroup.txtCheckGroupNo.Text = ((clsApplUnit_VO)objTreeNode.Tag).strApplUnitID;
                    infrmApplUserGroup.txtCheckGroupName.Text = ((clsApplUnit_VO)objTreeNode.Tag).strApplUnitName;
                    infrmApplUserGroup.txtPyCode.Text = ((clsApplUnit_VO)objTreeNode.Tag).strPYCode;
                    infrmApplUserGroup.txtWbCode.Text = ((clsApplUnit_VO)objTreeNode.Tag).strWBCode;
                    infrmApplUserGroup.txtAssist01.Text = ((clsApplUnit_VO)objTreeNode.Tag).strAssistCode01;
                    infrmApplUserGroup.txtAssist02.Text = ((clsApplUnit_VO)objTreeNode.Tag).strAssistCode02;
                    infrmApplUserGroup.txtApplUnitOtherName.Text = ((clsApplUnit_VO)objTreeNode.Tag).strOtherName;
                    infrmApplUserGroup.m_txtCost.Text = ((clsApplUnit_VO)objTreeNode.Tag).strCost;
                    infrmApplUserGroup.m_txtPrice.Text = ((clsApplUnit_VO)objTreeNode.Tag).strPrice;

                    infrmApplUserGroup.txtSummary.Text = ((clsApplUnit_VO)objTreeNode.Tag).strSummary;
                    infrmApplUserGroup.chkOutCheckFlag.Checked = (((clsApplUnit_VO)objTreeNode.Tag).strOutCheckFlag == "1" ? true : false);
                    infrmApplUserGroup.txtReportHour.Text = ((clsApplUnit_VO)objTreeNode.Tag).ReportHour.ToString();
                    infrmApplUserGroup.txtSamplingInstr.Text = ((clsApplUnit_VO)objTreeNode.Tag).SamplingInstr;

                    try
                    {
                        infrmApplUserGroup.m_cboSampleType.SelectedValue = ((clsApplUnit_VO)objTreeNode.Tag).strSampleTypeID;
                    }
                    catch
                    {
                        infrmApplUserGroup.m_cboSampleType.SelectedItem = null;
                    }
                    try
                    {
                        infrmApplUserGroup.cboCheckCategory.SelectedValue = ((clsApplUnit_VO)objTreeNode.Tag).strCheckCategoryID;
                    }
                    catch
                    {
                        MessageBox.Show("该申请单元的检验类别被删除或出错");
                    }
                    if (((clsApplUnit_VO)objTreeNode.Tag).strIsNoFoodRequired == "1")
                    {
                        infrmApplUserGroup.chkNoFood.Checked = true;
                    }
                    if (((clsApplUnit_VO)objTreeNode.Tag).strIsPhysicsExamRequired == "1")
                    {
                        infrmApplUserGroup.chkBodyCheck.Checked = true;
                    }
                    if (((clsApplUnit_VO)objTreeNode.Tag).strIsReservationRequired == "1")
                    {
                        infrmApplUserGroup.chkReservation.Checked = true;
                    }
                    DataTable dtbCheckItem = null;
                    infrmApplUserGroup.lsvAddCheckItem.Items.Clear();
                    lngRes = objDomainControllerCheckGroup.m_lngGetCheckItemByApplUnitID(((clsApplUnit_VO)objTreeNode.Tag).strApplUnitID, out dtbCheckItem);
                    if (dtbCheckItem != null && dtbCheckItem.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtbCheckItem.Rows.Count; i++)
                        {
                            ListViewItem objlsvItem = new ListViewItem();
                            objlsvItem.Text = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                            objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
                            objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                            objlsvItem.Tag = dtbCheckItem.Rows[i];
                            infrmApplUserGroup.lsvAddCheckItem.Items.Add(objlsvItem);
                        }
                        infrmApplUserGroup.lsvAddCheckItem.Tag = dtbCheckItem;
                    }
                }
                //用户自定义组
                if (objTreeNode.Tag is clsApplUserGroup_VO)
                {
                    clsDomainController_AppGroupManage objDomainAppGroupManage = new clsDomainController_AppGroupManage();
                    infrmApplUserGroup.rdbSelfDefine.Checked = true;
                    infrmApplUserGroup.txtCheckGroupNo.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
                    infrmApplUserGroup.txtCheckGroupName.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupName;
                    infrmApplUserGroup.txtPyCode.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strPYCode;
                    infrmApplUserGroup.txtWbCode.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strWBCode;
                    infrmApplUserGroup.txtAssist01.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strAssistCode01;
                    infrmApplUserGroup.txtAssist02.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strAssistCode02;

                    //xing.chen add
                    infrmApplUserGroup.txtSummary.Text = ((clsApplUserGroup_VO)objTreeNode.Tag).strSummary;

                    //子组信息
                    TreeNode objChildTreeNode = null;
                    clsApplUserGroup_VO[] objApplUserGroupVO = null;
                    //用户自定义组合
                    lngRes = objDomainAppGroupManage.m_lngGetSubGroupByUserGroupID(((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID, out objApplUserGroupVO);
                    if (lngRes > 0 && objApplUserGroupVO != null)
                    {
                        if (objApplUserGroupVO.Length > 0)
                        {
                            infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Clear();
                            for (int i = 0; i < objApplUserGroupVO.Length; i++)
                            {
                                objChildTreeNode = infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Add("(" + objApplUserGroupVO[i].strUserGroupID + ")" + objApplUserGroupVO[i].strUserGroupName);
                                objChildTreeNode.Tag = objApplUserGroupVO[i];
                                if (int.Parse(objApplUserGroupVO[i].strHasChildGroup) > 0)
                                {
                                    //查找下一层的用户定义子组和申请单元
                                    getChildUserGroupAndApplUnit(infrmApplUserGroup, objChildTreeNode);
                                }
                                else
                                {
                                    //查找该组下的申请单元
                                    getChildApplUnit(infrmApplUserGroup, objChildTreeNode);
                                }
                            }
                        }
                    }
                    //申请单元
                    string strUserGroupID = ((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID;
                    clsApplUnit_VO[] objApplUnit = null;
                    lngRes = objDomainAppGroupManage.m_lngGetApplUnitByUserGroupID(strUserGroupID, out objApplUnit);
                    infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Clear();
                    if (lngRes > 0 && objApplUnit != null)
                    {
                        if (objApplUnit.Length > 0)
                        {
                            for (int i = 0; i < objApplUnit.Length; i++)
                            {
                                objChildTreeNode = infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Add("(" + objApplUnit[i].strApplUnitID + ")" + objApplUnit[i].strApplUnitName);
                                objChildTreeNode.Tag = objApplUnit[i];
                            }
                        }
                    }
                }
                if (objTreeNode.Parent == infrmApplUserGroup.trvCheckGroup.Nodes[0])
                {
                    infrmApplUserGroup.cboCheckCategory.SelectedValue = ((clsCheckCategory_VO)objTreeNode.Tag).m_strCheck_Category_ID;
                }
            }

            //清空申请单元修改缓存
            m_arlAddDetail.Clear();
            m_arlRemoveDetail.Clear();
        }

        #endregion

        #region 当父节点选中时其所有子节点也全部选中 童华 2004.05.27

        public void checkAllByParentChecked(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            if (objTreeNode.Checked)
            {
                for (int i = 0; i < objTreeNode.Nodes.Count; i++)
                {
                    objTreeNode.Nodes[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < objTreeNode.Nodes.Count; i++)
                {
                    objTreeNode.Nodes[i].Checked = false;
                }
            }
        }

        #endregion

        #region 申请单元添加、删除检验项目 童华 2004.05.27

        //添加检验项目
        public void m_mthAddCheckItem(frmApplUserGroup infrmApplUserGroup)
        {
            int count = infrmApplUserGroup.lsvCheckItem.Items.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (infrmApplUserGroup.lsvCheckItem.Items[i].Checked)
                    {
                        int addCount = infrmApplUserGroup.lsvAddCheckItem.Items.Count;
                        //						if(objApplUnitDetailVOList != null && objApplUnitDetailVOList.Length  > 0)
                        //						{
                        //							for(int k=0;k<objApplUnitDetailVOList.Length;k++)
                        //							{
                        //								if(infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim() == objApplUnitDetailVOList[k].strCheckItemID)
                        //								{
                        //									MessageBox.Show("该检验项目已被其他申请单元添加！","检验项目",MessageBoxButtons.OK);
                        //									return;
                        //								}
                        //							}
                        //						}
                        if (addCount > 0)
                        {
                            for (int j = 0; j < addCount; j++)
                            {
                                if (infrmApplUserGroup.lsvAddCheckItem.Items[j].SubItems[0].Text.ToString().Trim() == infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim())
                                {
                                    MessageBox.Show("不能添加重复的检验项目！", "检验项目", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                            if (((DataRow)infrmApplUserGroup.lsvAddCheckItem.Items[0].Tag)["CHECK_CATEGORY_ID_CHR"].ToString().Trim() != ((DataRow)infrmApplUserGroup.lsvCheckItem.Items[i].Tag)["CHECK_CATEGORY_ID_CHR"].ToString().Trim())
                            {
                                MessageBox.Show("不能添加不同检验类别的检验项目！", "检验项目", MessageBoxButtons.OK);
                                return;
                            }

                            ListViewItem objlsvItem = new ListViewItem();
                            objlsvItem.Text = infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
                            objlsvItem.SubItems.Add(infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[1].Text.ToString().Trim());
                            objlsvItem.SubItems.Add(infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[2].Text.ToString().Trim());
                            objlsvItem.Tag = infrmApplUserGroup.lsvCheckItem.Items[i].Tag;
                            infrmApplUserGroup.lsvAddCheckItem.Items.Add(objlsvItem);
                            if (infrmApplUserGroup.btnDelCheckItem.Enabled == false)
                            {
                                infrmApplUserGroup.btnDelCheckItem.Enabled = true;
                            }
                        }
                        else
                        {
                            ListViewItem objlsvItem = new ListViewItem();
                            objlsvItem.Text = infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
                            objlsvItem.SubItems.Add(infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[1].Text.ToString().Trim());
                            objlsvItem.SubItems.Add(infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[2].Text.ToString().Trim());
                            objlsvItem.Tag = infrmApplUserGroup.lsvCheckItem.Items[i].Tag;
                            infrmApplUserGroup.lsvAddCheckItem.Items.Add(objlsvItem);
                            if (infrmApplUserGroup.btnDelCheckItem.Enabled == false)
                            {
                                infrmApplUserGroup.btnDelCheckItem.Enabled = true;
                            }
                        }
                        if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() != null)
                        {
                            clsApplUnitDetail_VO objRecord = new clsApplUnitDetail_VO();
                            objRecord.strCheckItemID = infrmApplUserGroup.lsvCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
                            objRecord.strApplUnitID = infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim();
                            m_arlAddDetail.Add(objRecord);
                        }
                    }
                }
            }
        }

        //删除检验项目
        public void m_mthDelCheckItem(frmApplUserGroup infrmApplUserGroup)
        {
            DataTable dtbRawItem = (DataTable)infrmApplUserGroup.lsvAddCheckItem.Tag;
            int count = infrmApplUserGroup.lsvAddCheckItem.Items.Count;
            if (count > 0)
            {
                for (int i = 0; i < infrmApplUserGroup.lsvAddCheckItem.Items.Count; i++)
                {
                    if (infrmApplUserGroup.lsvAddCheckItem.Items[i].Checked)
                    {
                        if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() != null)
                        {
                            for (int j = 0; j < dtbRawItem.Rows.Count; j++)
                            {
                                if (dtbRawItem.Rows[j]["CHECK_ITEM_ID_CHR"].ToString().Trim() ==
                                    ((DataRow)(infrmApplUserGroup.lsvAddCheckItem.Items[i].Tag))["CHECK_ITEM_ID_CHR"].ToString().Trim())
                                {
                                    clsApplUnitDetail_VO objRecord = new clsApplUnitDetail_VO();
                                    objRecord.strCheckItemID = dtbRawItem.Rows[j]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                                    objRecord.strApplUnitID = infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim();
                                    m_arlRemoveDetail.Add(objRecord);
                                }
                            }
                        }
                        infrmApplUserGroup.lsvAddCheckItem.Items[i].Remove();
                        i = i - 1;
                    }
                }
            }
        }

        #endregion

        #region 用户自定义组中添加、删除子组 童华 2004.05.27

        public void m_lngAddSubGroup(frmApplUserGroup infrmApplUserGroup)
        {
            //遍历所有节点
            foreach (TreeNode objTreeNode in infrmApplUserGroup.trvSubCheckGroup.Nodes)
            {
                findNextLevelNode(infrmApplUserGroup, objTreeNode);
            }
        }

        //遍历下一层的节点
        private void findNextLevelNode(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            for (int i = 0; i < objTreeNode.Nodes.Count; i++)
            {
                if (objTreeNode.Nodes[i].Nodes.Count > 0 && objTreeNode.Nodes[i].Parent != infrmApplUserGroup.trvSubCheckGroup.Nodes[0]
                    && objTreeNode.Nodes[i] != infrmApplUserGroup.trvSubCheckGroup.Nodes[0])
                {
                    //用户自定义组
                    if (objTreeNode.Nodes[i].Checked)
                    {
                        //1.修改时不能添加自身作为子组和不能添加父节点作为子组
                        if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() != "")
                        {
                            if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() == ((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupID)
                            {
                                MessageBox.Show("不能添加自身作为子组！", "自定义组", MessageBoxButtons.OK);
                                return;
                            }
                            if (findChildNode(infrmApplUserGroup, objTreeNode.Nodes[i], infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim()))
                            {
                                MessageBox.Show("不能添加父节点作为子组！", "自定义组", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        //2.判断是否已经添加了该组或包含该节点的组
                        if (infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count > 0)
                        {
                            for (int j = 0; j < infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count; j++)
                            {
                                if (((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupID == ((clsApplUserGroup_VO)infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[j].Tag).strUserGroupID)
                                {
                                    MessageBox.Show("该节点已被添加！", "自定义组", MessageBoxButtons.OK);
                                    return;
                                }
                                //判断添加的组的子组是否被添加
                                if (findChildNode(infrmApplUserGroup, objTreeNode.Nodes[i], ((clsApplUserGroup_VO)infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[j].Tag).strUserGroupID))
                                {
                                    MessageBox.Show("该节点的子节点已被添加！", "自定义组", MessageBoxButtons.OK);
                                    return;
                                }
                                //判断已经添加的组是否包含要添加的组
                                if (findChildNode(infrmApplUserGroup, infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[j], ((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupID))
                                {
                                    MessageBox.Show("该节点的父节点已被添加！", "自定义组", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }
                        //						//3.判断是否已经添加了该组所包含的申请单元
                        //						if(infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count > 0)
                        //						{
                        //						}
                        //添加到trvSubGroup
                        TreeNode objAddSubTreeNode = null;
                        objAddSubTreeNode = infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Add("(" +
                            ((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupID + ")" +
                            ((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupName);
                        objAddSubTreeNode.Tag = objTreeNode.Nodes[i].Tag;
                        if (objTreeNode.Nodes[i].Nodes.Count > 0)
                        {
                            getChildUserGroupAndApplUnit(infrmApplUserGroup, objAddSubTreeNode);
                        }
                    }
                    else
                    {
                        findNextLevelNode(infrmApplUserGroup, objTreeNode.Nodes[i]);
                    }
                }
                else if (objTreeNode.Nodes[i].Parent != infrmApplUserGroup.trvSubCheckGroup.Nodes[0]
                    && objTreeNode.Nodes[i] != infrmApplUserGroup.trvSubCheckGroup.Nodes[0])
                {
                    //申请单元
                    if (objTreeNode.Nodes[i].Checked)
                    {
                        if (infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count > 0)
                        {
                            //判断申请单元中是否包含该节点
                            for (int k = 0; k < infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count; k++)
                            {
                                if (((clsApplUnit_VO)objTreeNode.Nodes[i].Tag).strApplUnitID == ((clsApplUnit_VO)infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes[k].Tag).strApplUnitID)
                                {
                                    MessageBox.Show("该申请组已被添加！", "自定义组", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }
                        if (infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count > 0)
                        {
                            //判断该申请单元是否被包含到自定义组中
                            for (int l = 0; l < infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count; l++)
                            {
                                if (findApplUnit(infrmApplUserGroup, infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[l], ((clsApplUnit_VO)objTreeNode.Nodes[i].Tag).strApplUnitID))
                                {
                                    MessageBox.Show("该申请组已被自定义组添加！", "自定义组", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }
                        TreeNode objAddSubTreeNode = null;
                        objAddSubTreeNode = infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Add("("
                            + ((clsApplUnit_VO)objTreeNode.Nodes[i].Tag).strApplUnitID + ")" + ((clsApplUnit_VO)objTreeNode.Nodes[i].Tag).strApplUnitName);
                        objAddSubTreeNode.Tag = objTreeNode.Nodes[i].Tag;
                    }
                }
                else
                {
                    findNextLevelNode(infrmApplUserGroup, objTreeNode.Nodes[i]);
                }
            }
        }

        /// <summary>
        /// 判断strUserGroup(用户自定义组)是否包含在objDestNode的子组中
        /// </summary>
        /// <param name="infrmApplUserGroup"></param>
        /// <param name="objDestNode"></param>
        /// <param name="strUserGroupID"></param>
        /// <returns></returns>
        public bool findChildNode(frmApplUserGroup infrmApplUserGroup, TreeNode objDestNode, string strUserGroupID)
        {
            bool bolfind = false;
            for (int i = 0; i < objDestNode.Nodes.Count; i++)
            {
                if (objDestNode.Nodes[i].Nodes.Count > 0)
                {
                    if (strUserGroupID == ((clsApplUserGroup_VO)objDestNode.Nodes[i].Tag).strUserGroupID)
                    {
                        bolfind = true;
                        return bolfind;
                    }
                    bolfind = findChildNode(infrmApplUserGroup, objDestNode.Nodes[i], strUserGroupID);
                }
            }
            return bolfind;
        }

        /// <summary>
        /// 判断一个申请单元是否包含在某一自定义节点下
        /// </summary>
        /// <param name="infrmApplUserGroup"></param>
        /// <param name="objTreeNode">自定义节点</param>
        /// <param name="strApplUnitID">申请单元ID</param>
        /// <returns></returns>
        public bool findApplUnit(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode, string strApplUnitID)
        {
            bool bolfind = false;
            for (int i = 0; i < objTreeNode.Nodes.Count; i++)
            {
                if (objTreeNode.Nodes[i].Nodes.Count == 0)
                {
                    if (((clsApplUnit_VO)objTreeNode.Nodes[i].Tag).strApplUnitID == strApplUnitID)
                    {
                        bolfind = true;
                        return bolfind;
                    }
                }
                if (objTreeNode.Nodes[i].Nodes.Count > 0)
                {
                    bolfind = findApplUnit(infrmApplUserGroup, objTreeNode.Nodes[i], strApplUnitID);
                }
            }
            return bolfind;
        }

        /// <summary>
        /// 删除添加的子组
        /// </summary>
        /// <param name="infrmApplUserGroup"></param>
        public void m_lngDelSubGroup(frmApplUserGroup infrmApplUserGroup)
        {
            int intApplcount = infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count;
            int intUsercount = infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count;
            //申请单元
            if (intApplcount > 0)
            {
                for (int i = 0; i < intApplcount; i++)
                {
                    if (infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes[i].Checked)
                    {
                        infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes[i].Remove();
                        intApplcount--;
                        i--;
                    }
                }
            }
            //用户自定义组
            if (intUsercount > 0)
            {
                for (int i = 0; i < intUsercount; i++)
                {
                    if (infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[i].Checked)
                    {
                        infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[i].Remove();
                        intUsercount--;
                        i--;
                    }
                }
            }
        }

        #endregion

        #region 保存新增的申请单元和用户自定义组 童华 2004.05.27	xing.chen modify

        public long AddNewApplUserGroup(frmApplUserGroup infrmApplUserGroup)
        {
            long lngRes = 0;
            //申请单元
            if (infrmApplUserGroup.rdbApplUnit.Checked)
            {
                if (infrmApplUserGroup.lsvAddCheckItem.Items.Count == 0)
                {
                    MessageBox.Show("请添加检验项目！", "申请单元", MessageBoxButtons.OK);
                    return -1;
                }
                if (infrmApplUserGroup.txtCheckGroupName.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("请输入申请单元名称！", "申请单元", MessageBoxButtons.OK);
                    return -1;
                }
                //构造clsApplUnit_VO
                clsApplUnit_VO objApplUnitVO = new clsApplUnit_VO();
                if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() != "")
                {
                    objApplUnitVO.strApplUnitID = infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim();
                }
                objApplUnitVO.strApplUnitName = infrmApplUserGroup.txtCheckGroupName.Text.ToString().Trim();
                objApplUnitVO.strAssistCode01 = infrmApplUserGroup.txtAssist01.Text.ToString().Trim();
                objApplUnitVO.strAssistCode02 = infrmApplUserGroup.txtAssist02.Text.ToString().Trim();
                objApplUnitVO.strPYCode = infrmApplUserGroup.txtPyCode.Text.ToString().Trim();
                objApplUnitVO.strWBCode = infrmApplUserGroup.txtWbCode.Text.ToString().Trim();
                objApplUnitVO.strCheckCategoryID = infrmApplUserGroup.cboCheckCategory.SelectedValue.ToString().Trim();
                objApplUnitVO.strOtherName = infrmApplUserGroup.txtApplUnitOtherName.Text.ToString().Trim();
                objApplUnitVO.strPrice = infrmApplUserGroup.m_txtPrice.Text.ToString().Trim();
                objApplUnitVO.strCost = infrmApplUserGroup.m_txtCost.Text.ToString().Trim();
                objApplUnitVO.strSampleTypeID = infrmApplUserGroup.m_cboSampleType.SelectedValue == null ? null : infrmApplUserGroup.m_cboSampleType.SelectedValue.ToString();
                //xing.chen add
                objApplUnitVO.strSummary = infrmApplUserGroup.txtSummary.Text.ToString().Trim();

                if (infrmApplUserGroup.chkBodyCheck.Checked)
                {
                    objApplUnitVO.strIsPhysicsExamRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsPhysicsExamRequired = "0";
                }
                if (infrmApplUserGroup.chkNoFood.Checked)
                {
                    objApplUnitVO.strIsNoFoodRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsNoFoodRequired = "0";
                }
                if (infrmApplUserGroup.chkReservation.Checked)
                {
                    objApplUnitVO.strIsReservationRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsReservationRequired = "0";
                }

                objApplUnitVO.strOutCheckFlag = (infrmApplUserGroup.chkOutCheckFlag.Checked ? "1" : "0");
                objApplUnitVO.ReportHour = Convert.ToDecimal(infrmApplUserGroup.txtReportHour.Text);
                objApplUnitVO.SamplingInstr = infrmApplUserGroup.txtSamplingInstr.Text;

                //构造clsApplUnitDetail_VO
                clsApplUnitDetail_VO[] objApplUnitDetailVO = new clsApplUnitDetail_VO[infrmApplUserGroup.lsvAddCheckItem.Items.Count];
                for (int i = 0; i < infrmApplUserGroup.lsvAddCheckItem.Items.Count; i++)
                {
                    objApplUnitDetailVO[i] = new clsApplUnitDetail_VO();
                    objApplUnitDetailVO[i].strCheckItemID = infrmApplUserGroup.lsvAddCheckItem.Items[i].SubItems[0].Text.ToString().Trim();
                }
                //保存记录
                clsDomainController_ApplyUnitManage objDomainControllerApplyUnit = new clsDomainController_ApplyUnitManage();
                lngRes = objDomainControllerApplyUnit.m_lngAddApplUnitAndDetail(ref objApplUnitVO, ref objApplUnitDetailVO);
                if (lngRes > 0)
                {
                    refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
                    m_mthGetApplUnitByID(infrmApplUserGroup, objApplUnitVO.strApplUnitID);
                }
            }
            //自定义组
            if (infrmApplUserGroup.rdbSelfDefine.Checked)
            {
                //if(infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count == 0 && infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count == 0)
                //{
                //    MessageBox.Show("请选择要添加的申请单元或自定义组","自定义组",MessageBoxButtons.OK);
                //    return -1;
                //}
                if (infrmApplUserGroup.txtCheckGroupName.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("请输入组合名称", "自定义组", MessageBoxButtons.OK);
                    return -1;
                }
                //构造基本信息
                clsApplUserGroup_VO objApplUserVO = new clsApplUserGroup_VO();
                objApplUserVO.strUserGroupName = infrmApplUserGroup.txtCheckGroupName.Text.ToString().Trim();
                objApplUserVO.strAssistCode01 = infrmApplUserGroup.txtAssist01.Text.ToString().Trim();
                objApplUserVO.strAssistCode02 = infrmApplUserGroup.txtAssist02.Text.ToString().Trim();
                objApplUserVO.strPYCode = infrmApplUserGroup.txtPyCode.Text.ToString().Trim();
                objApplUserVO.strWBCode = infrmApplUserGroup.txtWbCode.Text.ToString().Trim();

                //xing.chen add
                objApplUserVO.strSummary = infrmApplUserGroup.txtSummary.Text.ToString().Trim();

                if (infrmApplUserGroup.txtCheckGroupNo.Text.ToString() != "")
                {
                    objApplUserVO.strUserGroupID = infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim();
                }
                //申请单元
                clsApplUserGroupDetail_VO[] objApplUserDetailVOList = null;
                if (infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count > 0)
                {
                    //构造clsApplUnit_VO
                    objApplUserDetailVOList = new clsApplUserGroupDetail_VO[infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count];
                    for (int i = 0; i < infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes.Count; i++)
                    {
                        objApplUserDetailVOList[i] = new clsApplUserGroupDetail_VO();
                        objApplUserDetailVOList[i].strApplUnitID = ((clsApplUnit_VO)infrmApplUserGroup.trvAddSubGroup.Nodes[0].Nodes[i].Tag).strApplUnitID;
                    }
                }
                //自定义组
                clsApplUserGroupRelation_VO[] objApplUserGroupRelationVOList = null;
                if (infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count > 0)
                {
                    objApplUserVO.strHasChildGroup = "1";
                    //构造clsApplUnitRelation_VO
                    objApplUserGroupRelationVOList = new clsApplUserGroupRelation_VO[infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count];
                    for (int i = 0; i < infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes.Count; i++)
                    {
                        objApplUserGroupRelationVOList[i] = new clsApplUserGroupRelation_VO();
                        objApplUserGroupRelationVOList[i].strChildUserGroupID = ((clsApplUserGroup_VO)infrmApplUserGroup.trvAddSubGroup.Nodes[1].Nodes[i].Tag).strUserGroupID;
                    }
                }
                else
                {
                    objApplUserVO.strHasChildGroup = "0";
                }
                //判断该节点是否是某个节点的子组
                ArrayList arlIdx = new ArrayList();
                TreeNode objTreeNode = infrmApplUserGroup.trvCheckGroup.SelectedNode;
                clsApplUserGroupRelation_VO objApplUserGroupRelation = null;
                if (infrmApplUserGroup.trvCheckGroup.SelectedNode != infrmApplUserGroup.trvCheckGroup.Nodes[1] &&
                    infrmApplUserGroup.trvCheckGroup.SelectedNode.Nodes.Count > 0 && infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim() == "")
                {
                    //记录选中节点的痕迹
                    while (objTreeNode != null)
                    {
                        arlIdx.Add(objTreeNode.Index);
                        objTreeNode = objTreeNode.Parent;
                    }
                    objApplUserGroupRelation = new clsApplUserGroupRelation_VO();
                    objApplUserGroupRelation.strUserGroupID = ((clsApplUserGroup_VO)infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag).strUserGroupID;
                }
                else
                {
                    objApplUserGroupRelation = null;
                }
                //保存记录
                clsDomainController_AppGroupManage objAppGroup = new clsDomainController_AppGroupManage();
                lngRes = objAppGroup.m_lngAddApplUserGroupAndDetailRelation(ref objApplUserVO, ref objApplUserDetailVOList,
                    ref objApplUserGroupRelationVOList, objApplUserGroupRelation);
                if (lngRes > 0)
                {
                    refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
                    refreshApplUnitDetail();
                    if (objApplUserGroupRelation == null)
                    {
                        m_mthGetApplUserGroupByID(infrmApplUserGroup, objApplUserVO.strUserGroupID);
                    }
                    else
                    {
                        try
                        {
                            int intCount = arlIdx.Count - 1;
                            objTreeNode = infrmApplUserGroup.trvCheckGroup.Nodes[(int)arlIdx[intCount]];
                            intCount--;
                            while (intCount >= 0)
                            {
                                objTreeNode = objTreeNode.Nodes[(int)arlIdx[intCount]];
                                intCount--;
                            }
                            for (int i = 0; i < objTreeNode.Nodes.Count; i++)
                            {
                                if (objTreeNode.Nodes[i].Nodes.Count > 0)
                                {
                                    if (((clsApplUserGroup_VO)objTreeNode.Nodes[i].Tag).strUserGroupID == objApplUserVO.strUserGroupID)
                                    {
                                        infrmApplUserGroup.trvCheckGroup.SelectedNode = objTreeNode.Nodes[i];
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            //清空申请单元修改缓存
            m_arlAddDetail.Clear();
            m_arlRemoveDetail.Clear();

            return lngRes;
        }

        #endregion

        #region 删除申请单元及用户自定义申请组 童华 2004.05.27

        public long m_lngDelApplUnitAndUserGroup(frmApplUserGroup infrmApplUserGroup)
        {
            long lngRes = 0;
            clsDomainController_AppGroupManage objDomainAppGroup = new clsDomainController_AppGroupManage();
            //申请单元
            if (infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag is clsApplUnit_VO)
            {
                DialogResult objResult = MessageBox.Show("确认要删除该记录吗？", "", MessageBoxButtons.OKCancel);
                if (objResult == DialogResult.Cancel)
                {
                    return lngRes;
                }
                //判断该申请单元是否被自定义组包含
                DataTable dtbApplUnitID = null;
                lngRes = objDomainAppGroup.m_lngGetAllUserGroupApplUnitID(out dtbApplUnitID);
                if (lngRes > 0)
                {
                    if (dtbApplUnitID != null && dtbApplUnitID.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtbApplUnitID.Rows.Count; i++)
                        {
                            if (dtbApplUnitID.Rows[i]["APPLY_UNIT_ID_CHR"].ToString().Trim() == infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim())
                            {
                                MessageBox.Show("申请单元删除失败，请先删除包含该申请单元的自定义组！", "申请单元", MessageBoxButtons.OK);
                                return -1;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("申请单元删除失败！", "申请单元", MessageBoxButtons.OK);
                    return lngRes;
                }

                //判断该申请单元是否被标本组包含
                DataTable dtbResult = null;
                clsDomainController_SampleGroupManage objManage = new clsDomainController_SampleGroupManage();
                lngRes = objManage.m_lngGetSampleGroupUnitByApplUnitID(infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim(), out dtbResult);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    MessageBox.Show("请先删除包含该申请单元的标本组！", "申请单元", MessageBoxButtons.OK);
                    return -1;
                }

                clsDomainController_ApplyUnitManage objDomainControllerApplyUnint = new clsDomainController_ApplyUnitManage();
                lngRes = objDomainControllerApplyUnint.m_lngDelApplUnitAndDetail(infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim());
                if (lngRes > 0)
                {
                    refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
                    refreshApplUnitDetail();
                }
                else
                {
                    MessageBox.Show("申请组删除失败！", "申请组删除", MessageBoxButtons.OK);
                }
            }

            //用户自定义组
            if (infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag is clsApplUserGroup_VO)
            {
                DialogResult objResult = MessageBox.Show("确认要删除该记录吗？", "", MessageBoxButtons.OKCancel);
                if (objResult == DialogResult.Cancel)
                {
                    return lngRes;
                }

                TreeNode objTreeNode = infrmApplUserGroup.trvCheckGroup.SelectedNode;
                string strParentUserGroupID = null;
                if (infrmApplUserGroup.trvCheckGroup.SelectedNode != infrmApplUserGroup.trvCheckGroup.Nodes[1])
                {
                    clsApplUserGroup_VO userGroupVo = objTreeNode.Tag as clsApplUserGroup_VO;
                    clsApplUserGroup_VO userGroupParentVo = objTreeNode.Parent.Tag as clsApplUserGroup_VO;
                    string userGroupId = string.Empty;

                    //是根
                    if (userGroupParentVo == null)
                    {
                        if (userGroupVo != null)
                        {
                            clsApplUnit_VO[] arrAppUnits = null;
                            new clsDomainController_AppGroupManage().m_lngGetApplUnitByUserGroupID(userGroupVo.strUserGroupID, out arrAppUnits);
                            if (arrAppUnits != null && arrAppUnits.Length > 0)
                            {
                                MessageBox.Show("自定义申请组根节点下的申请单元不为空！", "自定义删除");
                                return -1;
                            }
                            if (arrAppUnits != null && arrAppUnits.Length == 0)
                            {
                                userGroupId = userGroupVo.strUserGroupID;
                            }
                        }
                    }
                    else
                    {
                        userGroupId = userGroupParentVo.strUserGroupID;
                    }
                }
                lngRes = objDomainAppGroup.m_lngDelApplUserGroupInfo(infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim(), strParentUserGroupID);
                if (lngRes > 0)
                {
                    refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
                    refreshApplUnitDetail();
                }
                else
                {
                    MessageBox.Show("自定义组删除失败！", "自定义删除", MessageBoxButtons.OK);
                }
            }
            return lngRes;
        }

        #endregion

        #region 修改申请单元及用户自定义申请组 童华 2004.05.28		xing.chen modify

        public long m_lngUpdApplUnitAndApplUserGroup(frmApplUserGroup infrmApplUserGroup)
        {
            long lngRes = 0;
            //记录选中节点的痕迹
            ArrayList arlIdx = new ArrayList();
            TreeNode objTreeNode = infrmApplUserGroup.trvCheckGroup.SelectedNode;
            while (objTreeNode != null)
            {
                arlIdx.Add(objTreeNode.Index);
                objTreeNode = objTreeNode.Parent;
            }
            //申请单元
            if (infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag is clsApplUnit_VO)
            {
                if (infrmApplUserGroup.lsvAddCheckItem.Items.Count == 0)
                {
                    MessageBox.Show("请先添加检验项目！", "申请单元", MessageBoxButtons.OK);
                    return -1;
                }
                clsDomainController_ApplyUnitManage objDomainApplyUnit = new clsDomainController_ApplyUnitManage();
                //构造申请单元VO
                clsApplUnit_VO objApplUnitVO = new clsApplUnit_VO();
                objApplUnitVO.strApplUnitID = infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim();
                objApplUnitVO.strApplUnitName = infrmApplUserGroup.txtCheckGroupName.Text.ToString().Trim();
                objApplUnitVO.strAssistCode01 = infrmApplUserGroup.txtAssist01.Text.ToString().Trim();
                objApplUnitVO.strAssistCode02 = infrmApplUserGroup.txtAssist02.Text.ToString().Trim();
                objApplUnitVO.strPYCode = infrmApplUserGroup.txtPyCode.Text.ToString().Trim();
                objApplUnitVO.strWBCode = infrmApplUserGroup.txtWbCode.Text.ToString().Trim();
                objApplUnitVO.strCheckCategoryID = infrmApplUserGroup.cboCheckCategory.SelectedValue.ToString().Trim();
                objApplUnitVO.strOtherName = infrmApplUserGroup.txtApplUnitOtherName.Text.ToString().Trim();
                objApplUnitVO.strPrice = infrmApplUserGroup.m_txtPrice.Text.ToString().Trim();
                objApplUnitVO.strCost = infrmApplUserGroup.m_txtCost.Text.ToString().Trim();
                objApplUnitVO.strSampleTypeID = infrmApplUserGroup.m_cboSampleType.SelectedValue == null ? null : infrmApplUserGroup.m_cboSampleType.SelectedValue.ToString();

                //xing.chen add
                objApplUnitVO.strSummary = infrmApplUserGroup.txtSummary.Text.ToString().Trim();

                if (infrmApplUserGroup.chkBodyCheck.Checked)
                {
                    objApplUnitVO.strIsPhysicsExamRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsPhysicsExamRequired = "0";
                }
                if (infrmApplUserGroup.chkNoFood.Checked)
                {
                    objApplUnitVO.strIsNoFoodRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsNoFoodRequired = "0";
                }
                if (infrmApplUserGroup.chkReservation.Checked)
                {
                    objApplUnitVO.strIsReservationRequired = "1";
                }
                else
                {
                    objApplUnitVO.strIsReservationRequired = "0";
                }

                 
                objApplUnitVO.strOutCheckFlag = (infrmApplUserGroup.chkOutCheckFlag.Checked ? "1" : "0");
                objApplUnitVO.ReportHour = Convert.ToDecimal(infrmApplUserGroup.txtReportHour.Text);
                objApplUnitVO.SamplingInstr = infrmApplUserGroup.txtSamplingInstr.Text;

                lngRes = objDomainApplyUnit.m_lngSetApplyUnit(objApplUnitVO, this.m_arlAddDetail, this.m_arlRemoveDetail);
                if (lngRes > 0)
                {
                    m_arlAddDetail.Clear();
                    m_arlRemoveDetail.Clear();
                    try
                    {
                        int intCount = arlIdx.Count - 1;
                        objTreeNode = infrmApplUserGroup.trvCheckGroup.Nodes[(int)arlIdx[intCount]];
                        intCount--;
                        while (intCount >= 0)
                        {
                            objTreeNode = objTreeNode.Nodes[(int)arlIdx[intCount]];
                            intCount--;
                        }
                        infrmApplUserGroup.trvCheckGroup.SelectedNode = objTreeNode;
                        infrmApplUserGroup.trvCheckGroup.SelectedNode.Text = "(" + objApplUnitVO.strApplUnitID + ")" + objApplUnitVO.strApplUnitName;
                        infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag = objApplUnitVO;
                    }
                    catch { }
                    //					refreshAllCheckGroupANDTrvCheckGroup(infrmApplUserGroup);
                }
                //				lngRes = objDomainApplyUnit.m_lngDelApplUnitDetail(infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim());
                //				if(lngRes > 0)
                //				{
                //					lngRes = AddNewApplUserGroup(infrmApplUserGroup);
                //				}
                //				if(lngRes > 0)
                //				{
                //					m_mthGetApplUnitByID(infrmApplUserGroup,infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim());
                //				}
            }
            //自定义组
            if (infrmApplUserGroup.trvCheckGroup.SelectedNode.Tag is clsApplUserGroup_VO)
            {



                objTreeNode = infrmApplUserGroup.trvCheckGroup.SelectedNode;
                clsDomainController_AppGroupManage objDomainApplGroup = new clsDomainController_AppGroupManage();
                lngRes = objDomainApplGroup.m_lngDelApplUserGroupDetailAndRelation(infrmApplUserGroup.txtCheckGroupNo.Text.ToString().Trim());
                if (lngRes > 0)
                {
                    lngRes = AddNewApplUserGroup(infrmApplUserGroup);
                }
            }
            if (lngRes > 0)
            {

            }
            return lngRes;
        }

        #endregion

        #region 根据ID查询节点

        /// <summary>
        /// 根据申请单元ID获取申请单元节点
        /// </summary>
        /// <param name="infrmApplUserGroup"></param>
        /// <param name="p_strApplUnitID"></param>
        private void m_mthGetApplUnitByID(frmApplUserGroup infrmApplUserGroup, string p_strApplUnitID)
        {
            for (int i = 0; i < infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes.Count; i++)
            {
                for (int j = 0; j < infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (p_strApplUnitID == ((clsApplUnit_VO)infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[i].Nodes[j].Tag).strApplUnitID)
                    {
                        lsvCheckGroupSelectIndexChanged(infrmApplUserGroup, infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[i].Nodes[j]);
                        infrmApplUserGroup.trvCheckGroup.Focus();
                        infrmApplUserGroup.trvCheckGroup.SelectedNode = infrmApplUserGroup.trvCheckGroup.Nodes[0].Nodes[i].Nodes[j];
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 根据用户自定义组ID获取用户自定义组节点
        /// </summary>
        /// <param name="infrmApplUserGroup"></param>
        /// <param name="p_strApplUserGroupID"></param>
        private void m_mthGetApplUserGroupByID(frmApplUserGroup infrmApplUserGroup, string p_strApplUserGroupID)
        {
            for (int i = 0; i < infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes.Count; i++)
            {
                if (p_strApplUserGroupID == ((clsApplUserGroup_VO)infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes[i].Tag).strUserGroupID)
                {
                    lsvCheckGroupSelectIndexChanged(infrmApplUserGroup, infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes[i]);
                    infrmApplUserGroup.trvCheckGroup.Focus();
                    infrmApplUserGroup.trvCheckGroup.SelectedNode = infrmApplUserGroup.trvCheckGroup.Nodes[1].Nodes[i];
                    break;
                }
            }
        }

        #endregion

        #region 对trvSubGroup中选中不同的节点显示相应的检验项目信息 童华 2004.05.28

        public long m_lngGetCheckItemByTreeNode(frmApplUserGroup infrmApplUserGroup, TreeNode objTreeNode)
        {
            long lngRes = 0;
            infrmApplUserGroup.lsvSubGroupCheckItem.Items.Clear();
            //申请单元
            if (objTreeNode.Tag is clsApplUnit_VO)
            {
                clsDomainController_ApplyUnitManage objDomainApplUnit = new clsDomainController_ApplyUnitManage();
                DataTable dtbCheckItem = null;
                lngRes = objDomainApplUnit.m_lngGetCheckItemByApplUnitID(((clsApplUnit_VO)objTreeNode.Tag).strApplUnitID, out dtbCheckItem);
                if (dtbCheckItem != null && dtbCheckItem.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbCheckItem.Rows.Count; i++)
                    {
                        ListViewItem objlsvItem = new ListViewItem();
                        objlsvItem.Text = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                        objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
                        objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                        objlsvItem.Tag = dtbCheckItem.Rows[i];
                        infrmApplUserGroup.lsvSubGroupCheckItem.Items.Add(objlsvItem);
                    }
                }
            }
            if (objTreeNode.Tag is clsApplUserGroup_VO)
            {
                clsDomainController_AppGroupManage objDomainAppGroup = new clsDomainController_AppGroupManage();
                DataTable dtbCheckItem = null;
                if (((clsApplUserGroup_VO)objTreeNode.Tag).strHasChildGroup == "1")
                {
                    objDomainAppGroup.m_lngGetCheckItemApplGroupRelationByApplUserGroupID(((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID, out dtbCheckItem);
                    if (dtbCheckItem != null && dtbCheckItem.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtbCheckItem.Rows.Count; i++)
                        {
                            ListViewItem objlsvItem = new ListViewItem();
                            objlsvItem.Text = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                            objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
                            objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                            objlsvItem.Tag = dtbCheckItem.Rows[i];
                            infrmApplUserGroup.lsvSubGroupCheckItem.Items.Add(objlsvItem);
                        }
                    }
                    dtbCheckItem = null;
                }
                objDomainAppGroup.m_lngGetCheckItemApplGroupDetailByApplUserGroupID(((clsApplUserGroup_VO)objTreeNode.Tag).strUserGroupID, out dtbCheckItem);
                if (dtbCheckItem != null && dtbCheckItem.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbCheckItem.Rows.Count; i++)
                    {
                        ListViewItem objlsvItem = new ListViewItem();
                        objlsvItem.Text = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                        objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim());
                        objlsvItem.SubItems.Add(dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim());
                        objlsvItem.Tag = dtbCheckItem.Rows[i];
                        infrmApplUserGroup.lsvSubGroupCheckItem.Items.Add(objlsvItem);
                    }
                }
            }
            return lngRes;
        }

        #endregion

    }
}
