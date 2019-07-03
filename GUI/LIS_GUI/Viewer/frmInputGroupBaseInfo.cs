using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmInputGroupBaseInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        clsDomain_InputGroup objDomain = new clsDomain_InputGroup();
        string strMessageBoxTitle = "iCare-LIS";
        string strDBErr = "数据库操作失败，请与管理员联系！";
        System.Drawing.Color notInuseColor = System.Drawing.Color.Gray;
        System.Drawing.Color inuseColor = System.Drawing.Color.Blue;
        bool blnNew = false;

        public frmInputGroupBaseInfo()
        {
            InitializeComponent();
        }

        private void frmInputGroupBaseInfo_Load(object sender, EventArgs e)
        {
            clsInputGroupUnited_VO[] objGroups = null;
            long lngRes = objDomain.m_lngGetUnitedInputGroupInfo(out objGroups);
            if (lngRes <= 0)
            {
                MessageBox.Show(strDBErr, strMessageBoxTitle);
                return;
            }
            if (objGroups != null)
            {
                ConstructList(objGroups, this.trvList);
            }
        }
        #region  构造树
        private void ConstructList(clsInputGroupUnited_VO[] objGroups, TreeView ctlView)
        {//使用哈希表算法构造树
            if (objGroups == null || ctlView == null)
                return;
            System.Collections.Hashtable hasNodes = new System.Collections.Hashtable();
            for (int i = 0; i < objGroups.Length; i++)
            {
                TreeNode node = null;
                if (objGroups[i].m_strINPUT_GROUP_ID_CHR != null && objGroups[i].m_strINPUT_GROUP_ID_CHR.Trim() != "")
                {
                    node = new TreeNode();
                    node.Text = objGroups[i].m_strINPUT_GROUP_NAME_VCHR;
                    node.Tag = objGroups[i].m_strINPUT_GROUP_ID_CHR;
                    if (objGroups[i].m_intINUSEFLAG_NUM == 0)
                    {
                        node.ForeColor = notInuseColor;
                    }
                    else
                    {
                        node.ForeColor = inuseColor;
                    }
                }
                string unitKey = objGroups[i].m_strCHECK_CATEGORY_ID_CHR + objGroups[i].m_strAPPLY_UNIT_ID_CHR;
                if (hasNodes.ContainsKey(unitKey))
                {
                    TreeNode unitNode = (TreeNode)hasNodes[unitKey];
                    if (node != null)
                    {
                        unitNode.Nodes.Add(node);
                    }
                }
                else
                {
                    TreeNode unitNode = new TreeNode();
                    unitNode.Text = objGroups[i].m_strAPPLY_UNIT_NAME_VCHR;
                    unitNode.Tag = objGroups[i].m_strAPPLY_UNIT_ID_CHR;
                    string categoryKey = objGroups[i].m_strCHECK_CATEGORY_ID_CHR;
                    if (hasNodes.ContainsKey(categoryKey))
                    {
                        TreeNode categoryNode = (TreeNode)hasNodes[categoryKey];
                        categoryNode.Nodes.Add(unitNode);
                    }
                    else
                    {
                        TreeNode categoryNode = new TreeNode();
                        categoryNode.Text = objGroups[i].m_strCHECK_CATEGORY_NAME_CHR;
                        categoryNode.Tag = objGroups[i].m_strCHECK_CATEGORY_ID_CHR;
                        ctlView.Nodes.Add(categoryNode);
                        categoryNode.Nodes.Add(unitNode);
                        hasNodes.Add(categoryKey, categoryNode);
                    }
                    if (node != null)
                    {
                        unitNode.Nodes.Add(node);
                    }
                    hasNodes.Add(unitKey, unitNode);
                }
            }
        }
        #endregion

        private void trvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.blnNew = false;//重置
            TreeNode node = this.trvList.SelectedNode;
            if (node.Parent != null)
            {
                if (node.Parent.Parent != null)
                {
                    this.SelectInputGroup();
                }
                else
                {
                    this.SelectApplyUnit();
                }
            }
            else
            {
                this.pnlGroupInfo.Visible = false;
                this.btnSave.Visible = false;
                this.btnDelete.Visible = false;
                this.btnNew.Visible = false;
            }
        }
        private void SelectApplyUnit()
        {
            this.ClearInfo();

            this.pnlGroupInfo.Visible = false;
            this.btnSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btnNew.Visible = true;
        }
        private void SelectInputGroup()
        {
            #region 新增组保存
            if (this.trvList.SelectedNode.Tag == null)
                return;
            #endregion
            this.ClearInfo();

            this.pnlGroupInfo.Visible = true;
            this.btnSave.Visible = true;
            this.btnDelete.Visible = true;
            this.btnDelete.Enabled = true;
            this.btnNew.Visible = false;

            clsInputGroupBaseInfo_VO objBaseInfo = null;
            clsInputGroupDetail_VO[] objDetailVOArr = null;

            long lngRes = this.objDomain.m_lngGetInputGroupInfo(this.trvList.SelectedNode.Tag.ToString(),out objBaseInfo, out objDetailVOArr);
            if (lngRes <= 0)
            {
                MessageBox.Show(strDBErr, strMessageBoxTitle);
                return;
            }
            this.ShowInputGroupInfo(objBaseInfo, objDetailVOArr);
            FillApplyUnitItem(objBaseInfo.m_strAPPLY_UNIT_ID_CHR);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.blnNew = true;
            this.ClearInfo();

            this.pnlGroupInfo.Visible = true;
            this.btnSave.Visible = true;
            this.btnDelete.Visible = true;
            this.btnDelete.Enabled = false;
            this.btnNew.Visible = false;

            this.FillApplyUnitItem(this.trvList.SelectedNode.Tag.ToString());
        }
        #region 填充当前申请单元项目列表
        private void FillApplyUnitItem(string strApplyUnitID)
        {
            clsCheckItemSimple_VO[] objItems = null;

            long lngRes = this.objDomain.m_lngGetApplyUnitItems(strApplyUnitID, out objItems);
            if (lngRes <= 0)
            {
                MessageBox.Show(strDBErr, strMessageBoxTitle);
                return;
            }
            if (objItems != null)
            {
                foreach (clsCheckItemSimple_VO obj in objItems)
                {
                    ListViewItem lvi = new ListViewItem(obj.m_strCHECK_ITEM_ID_CHR);
                    lvi.SubItems.Add(obj.m_strCHECK_ITEM_NAME_CHR);
                    this.lsvApplyUnitItem.Items.Add(lvi);
                }
            }
        }
        #endregion

        #region 清空
        private void ClearInfo()
        {
            this.txtGroupID.Clear();
            this.txtGroupName.Clear();
            this.chkStopUse.Checked = false;
            this.txtPYCode.Clear();
            this.txtWBCode.Clear();
            this.txtASCode.Clear();
            this.txtSummary.Clear();
            this.lsvApplyUnitItem.Items.Clear();
            this.lsvGroupItem.Items.Clear();
        }
        #endregion

        #region 加入项目，移除项目，排序
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.lsvApplyUnitItem.SelectedItems.Count == 0)
                return;
            foreach (ListViewItem lvi in this.lsvApplyUnitItem.SelectedItems)
            {
                bool blnExist = false;
                for (int i = 0; i < this.lsvGroupItem.Items.Count; i++)
                {
                    if (this.lsvGroupItem.Items[i].Text == lvi.Text)
                    {
                        blnExist = true;
                        break;
                    }
                }
                if (!blnExist)
                {
                    ListViewItem lviAdd = new ListViewItem(lvi.Text);
                    lviAdd.SubItems.Add(lvi.SubItems[1].Text);
                    this.lsvGroupItem.Items.Add(lviAdd);
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.lsvGroupItem.SelectedItems)
            {
                lvi.Remove();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.lsvGroupItem.SelectedItems.Count == 0)
                return;
            if (this.lsvGroupItem.SelectedItems[0].Index == 0)
                return;
            ListViewItem curr = this.lsvGroupItem.SelectedItems[0];
            int intIdx = curr.Index;
            curr.Remove();
            this.lsvGroupItem.Items.Insert(intIdx - 1, curr);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.lsvGroupItem.SelectedItems.Count == 0)
                return;
            if (this.lsvGroupItem.SelectedItems[0].Index == this.lsvGroupItem.Items.Count-1)
                return;
            ListViewItem curr = this.lsvGroupItem.SelectedItems[0];
            int intIdx = curr.Index;
            curr.Remove();
            this.lsvGroupItem.Items.Insert(intIdx + 1, curr);
        }
        #endregion

        #region 构造用于保存的数据VO
        private void ConstructSaveVO(out clsInputGroupBaseInfo_VO objBaseInfo, out clsInputGroupDetail_VO[] objDetailVOArr)
        {
            objBaseInfo = new clsInputGroupBaseInfo_VO();
            if (this.chkStopUse.Checked)
                objBaseInfo.m_intINUSEFLAG_NUM = 0;
            else
                objBaseInfo.m_intINUSEFLAG_NUM = 1;
            objBaseInfo.m_intSEQUENCE_NUM = 0;
            if (this.blnNew)
                objBaseInfo.m_strAPPLY_UNIT_ID_CHR = this.trvList.SelectedNode.Tag.ToString();
            else
                objBaseInfo.m_strAPPLY_UNIT_ID_CHR = this.trvList.SelectedNode.Parent.Tag.ToString();
            objBaseInfo.m_strASCODE_VCHR = this.txtASCode.Text.Trim();
            objBaseInfo.m_strINPUT_GROUP_ID_CHR = this.txtGroupID.Text.Trim();
            objBaseInfo.m_strINPUT_GROUP_NAME_VCHR = this.txtGroupName.Text.Trim();
            objBaseInfo.m_strPYCODE_VCHR = this.txtPYCode.Text.Trim();
            objBaseInfo.m_strSUMMARY_VCHR = this.txtSummary.Text.Trim();
            objBaseInfo.m_strWBCODE_VCHR = this.txtWBCode.Text.Trim();

            objDetailVOArr = new clsInputGroupDetail_VO[this.lsvGroupItem.Items.Count];
            for (int i = 0; i < objDetailVOArr.Length; i++)
            {
                objDetailVOArr[i] = new clsInputGroupDetail_VO();
                objDetailVOArr[i].m_strINPUT_GROUP_ID_CHR = objBaseInfo.m_strINPUT_GROUP_ID_CHR;
                objDetailVOArr[i].m_strCHECK_ITEM_ID_CHR = this.lsvGroupItem.Items[i].Text;
                objDetailVOArr[i].m_strCHECK_ITEM_NAME_CHR = this.lsvGroupItem.Items[i].SubItems[1].Text;
                objDetailVOArr[i].m_intSEQUENCE_NUM = i;
            }
        }
        #endregion

        #region 显示录入组合的信息
        private void ShowInputGroupInfo(clsInputGroupBaseInfo_VO objBaseInfo, clsInputGroupDetail_VO[] objDetailVOArr)
        {
            if (objBaseInfo != null)
            {
                this.txtASCode.Text = objBaseInfo.m_strASCODE_VCHR;
                this.txtGroupID.Text = objBaseInfo.m_strINPUT_GROUP_ID_CHR;
                this.txtGroupName.Text = objBaseInfo.m_strINPUT_GROUP_NAME_VCHR;
                this.txtPYCode.Text = objBaseInfo.m_strPYCODE_VCHR;
                this.txtSummary.Text = objBaseInfo.m_strSUMMARY_VCHR;
                this.txtWBCode.Text = objBaseInfo.m_strWBCODE_VCHR;
                if (objBaseInfo.m_intINUSEFLAG_NUM == 0)
                    this.chkStopUse.Checked = true;
                else
                    this.chkStopUse.Checked = false;
            }
            if (objDetailVOArr != null)
            {
                foreach (clsInputGroupDetail_VO objDetail in objDetailVOArr)
                {
                    ListViewItem lvi = new ListViewItem(objDetail.m_strCHECK_ITEM_ID_CHR);
                    lvi.SubItems.Add(objDetail.m_strCHECK_ITEM_NAME_CHR);
                    this.lsvGroupItem.Items.Add(lvi);
                }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckDataFull())
            {
                MessageBox.Show("请将资料填写完整！", this.strMessageBoxTitle);
                return;
            }
            clsInputGroupBaseInfo_VO objBaseInfo = null;
            clsInputGroupDetail_VO[] objDetailVOArr = null;
            this.ConstructSaveVO(out objBaseInfo, out objDetailVOArr);
            long lngRes = 0;
            string strID = null;
            if (this.blnNew)
            {
                lngRes = this.objDomain.m_lngAddNewInputGroup(objBaseInfo, objDetailVOArr,out strID);
            }
            else
            {
                lngRes = this.objDomain.m_lngUpdateInputGroup(objBaseInfo, objDetailVOArr);
            }
            if (lngRes <= 0)
            {
                MessageBox.Show(this.strDBErr, this.strMessageBoxTitle);
                return;
            }
            if (blnNew)
            {
                this.txtGroupID.Text = strID;
                TreeNode node = new TreeNode();
                node.Text = objBaseInfo.m_strINPUT_GROUP_NAME_VCHR;
                this.trvList.SelectedNode.Nodes.Add(node);
                this.trvList.SelectedNode = node;
                node.Tag = strID;
            }
            if (this.chkStopUse.Checked)
            {
                this.trvList.SelectedNode.ForeColor = this.notInuseColor;
            }
            else
            {
                this.trvList.SelectedNode.ForeColor = this.inuseColor;
            }
            this.btnDelete.Enabled = true;
        }
        #region 保存数据前检查数据是否完整
        private bool CheckDataFull()
        {
            if (this.txtGroupName.Text.Trim() == "")
            {
                this.txtGroupName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!blnNew)
            {
                string strGroupID = this.trvList.SelectedNode.Tag.ToString();
                long lngRes = this.objDomain.m_lngDeleteInputGroup(strGroupID);
                if (lngRes <= 0)
                {
                    MessageBox.Show(this.strDBErr, this.strMessageBoxTitle);
                    return;
                }
                TreeNode node = this.trvList.SelectedNode.PrevNode;
                this.trvList.SelectedNode.Remove();
                this.trvList.SelectedNode = node;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}