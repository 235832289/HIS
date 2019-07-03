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
    public partial class ctlCheckItemTree : System.Windows.Forms.TreeView
    {
        public ctlCheckItemTree()
        {
            InitializeComponent();
            this.ImageList = this.imageList1;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!this.DesignMode)
            {
                try
                {
                    this.m_mthLoadData();
                }
                catch { }
            }
        }
        private void m_mthLoadData()
        {
            clsLISUserGroupNode root = null;
            clsSchBaseInfoSmp.s_object.m_lngGetCheckItemTree(out root);
            if (root != null)
            {
                TreeNode rootNode = new TreeNode();
                m_mthMakeGroupNode(root, rootNode);
                foreach (TreeNode node in rootNode.Nodes)
                {
                    this.Nodes.Add(node);
                }
            }
        }
        private void m_mthMakeGroupNode(clsLISUserGroupNode parent, TreeNode parentNode)
        {
            if (parent == null || parentNode == null)
            {
                return;
            }
            if (parent.objChildNodes != null)
            {
                foreach (clsLISUserGroupNode groupnode in parent.objChildNodes)
                {
                    TreeNode node = new TreeNode();
                    node.Text = groupnode.strName;
                    node.Tag = groupnode;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    parentNode.Nodes.Add(node);
                    m_mthMakeGroupNode(groupnode, node);
                }
            }
            if (parent.objUnitNodes != null)
            {
                foreach (clsLISApplyUnitNode unitNode in parent.objUnitNodes)
                {
                    TreeNode node = new TreeNode();
                    node.Text = unitNode.Name;
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    node.Tag = unitNode;
                    if (unitNode.objItems != null)
                    {
                        foreach (clsLISCheckItemNode itemNode in unitNode.objItems)
                        {
                            TreeNode itemTreeNode = new TreeNode();
                            itemTreeNode.Text = itemNode.strName;
                            itemTreeNode.ImageIndex = 2;
                            itemTreeNode.SelectedImageIndex = 2;
                            itemTreeNode.Tag = itemNode;
                            node.Nodes.Add(itemTreeNode);
                        }
                    }
                    parentNode.Nodes.Add(node);
                }
            }
        }
    }
}

