using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmSetOrderDept : Form
    {
        /// <summary>
        /// 各科门诊人次日报表排序
        /// </summary>
        public frmSetOrderDept()
        {
            InitializeComponent();
            //tv1.AllowDrop = true;
            tvOrder.AllowDrop = true;
            //this.tv1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            //tv1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            //tv1.DragOver += new DragEventHandler(treeView1_DragOver);
            //tv1.DragDrop += new DragEventHandler(treeView1_DragDrop);

            this.tvOrder.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            tvOrder.DragEnter += new DragEventHandler(treeView1_DragEnter);
            tvOrder.DragOver += new DragEventHandler(treeView1_DragOver);
            tvOrder.DragDrop += new DragEventHandler(treeView1_DragDrop);

        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            //else if (e.Button == MouseButtons.Right)
            //{
            //    DoDragDrop(e.Item, DragDropEffects.Copy);
            //}
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            TreeView objtv = (TreeView)sender;
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = objtv.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            objtv.SelectedNode = objtv.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeView objtv = (TreeView)sender;

            // Retrieve the client coordinates of the drop location.
            Point targetPoint = objtv.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = objtv.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    if (targetNode.Parent == draggedNode.Parent)
                    {
                        //string text = targetNode.Text;
                        //object tag = targetNode.Tag;
                        //targetNode.Text = draggedNode.Text;
                        //targetNode.Tag = draggedNode.Tag;
                        //draggedNode.Text = text;
                        //draggedNode.Tag = tag;
                        TreeNode temp = targetNode.Parent;
                        int index = targetNode.Index;
                        System.Collections.ArrayList al = new System.Collections.ArrayList ();
                        int count = temp.Nodes.Count;
                       
                        for (int i = 0; i < count; i++)
                        {
                            if (targetNode.Index > draggedNode.Index)//下拖
                            {
                                if (i == draggedNode.Index)
                                {
                                    continue;
                                }
                                else if (i == targetNode.Index)
                                {
                                    al.Add(temp.Nodes[i]);
                                    al.Add(draggedNode);
                                }
                                else
                                {
                                    al.Add(temp.Nodes[i]);
                                }
                            }
                            else //上拖
                            {
                                if (i == targetNode.Index)
                                {
                                    al.Add(draggedNode);
                                    al.Add(temp.Nodes[i]);

                                   
                                }
                                else if (i == draggedNode.Index)
                                {
                                    continue;
                                }
                                else
                                {
                                    al.Add(temp.Nodes[i]);
                                }
                            }
                        }
                        
                        temp.Nodes.Clear();
                        TreeNode t = null;
                        for (int i = 0; i < al.Count; i++)
                        {
                           t =  (TreeNode)al[i];
                           if (t!= null)
                           {
                               temp.Nodes.Add(t);
                           }
                        }
                        //draggedNode.Remove();
                        //targetNode.Nodes.Add(draggedNode);
                    }
                    else
                    {
                        MessageBox.Show("只能在同级部门进行拖放操作.");
                    }
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                //else if (e.Effect == DragDropEffects.Copy)
                //{
                //    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                //}

                // Expand the node at the location 
                // to show the dropped node.
                //targetNode.Expand();
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }


        private void m_btSave_Click(object sender, EventArgs e)
        {

        }
        #region 生成部门treeView视图结构
        /// <summary>
        /// 生成部门treeView视图结构
        /// </summary>
        public void fillDepartTree(TreeView tv)
        {
            DataTable dt = findAll();
            if (dt.Rows.Count < 1)
            {
                return;
            }
            this.createTree(tv,dt, "", null);
            if (tv.Nodes.Count>0)
            {
                tv.Nodes[0].Expand();
            }
        }
        public void fillOrderDepartTree(TreeView tv)
        {
            DataTable dt = findOrderAll();
            if (dt.Rows.Count < 1)
            {
                return;
            }
            this.createTree(tv, dt, "", null);
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes[0].Expand();
            }
        }
        #endregion

        #region 加载所有部门记录
        /// <summary>
        /// 加载所有部门记录
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc objSvc =
                (com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsDepartmentSvc));
            DataTable dt = objSvc.findAll(null);
            return dt;
        }
        public DataTable findOrderAll()
        {
            com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));

            DataTable dt = null;
            long lng = objSvc.m_lngSelectAllRptorder(out dt);
            return dt;
        }
        #endregion

        #region 用递归方法生成treeView
        /// <summary>
        /// 用递归方法生成treeView
        /// </summary>
        private void createTree(TreeView tv ,DataTable  dt, string pId, TreeNode pNode)
        {
            string tnId = ""; //节点id;
            string tnName = ""; //节点Text;
            string rootId = ""; //根节点id;
            string rootName = ""; //根节点Text;
            TreeNode tnRoot = null;
            DataView dv = new DataView(dt);
            //加入根节点
            if (pId == "")
            {
                dv.RowFilter = "parentId='0'";
                rootId = dv[0]["DEPTID_CHR"].ToString();
                rootName = dv[0]["DEPTNAME_VCHR"].ToString();
                tnRoot = new TreeNode(rootName);
                tnRoot.Tag = rootId;
                tv.Nodes.Add(tnRoot);
                //递归
                this.createTree(tv,dt, rootId, tnRoot);
            }
            //递归循环,加入根节点的所有子节点
            else
            {
                dv.RowFilter = "parentId='" + pId + "'";
                dv.Sort = "shortno_chr";
                foreach (DataRowView drv in dv)
                {
                    tnId = drv["DEPTID_CHR"].ToString();
                    tnName = drv["DEPTNAME_VCHR"].ToString();
                    TreeNode tn = new TreeNode(tnName);
                    tn.Tag = tnId;
                    pNode.Nodes.Add(tn);
                    this.createTree(tv,dt, tnId, tn);
                }
            }
        }
        #endregion

        private void frmSetOrderDept_Load(object sender, EventArgs e)
        {
            fillDepartTree(tv1);
            fillOrderDepartTree(tvOrder);
        }
        System.Collections.ArrayList al = new System.Collections.ArrayList();
        void getNodes(TreeNode  p_Tns)           
        {
            al.Add(p_Tns.Tag.ToString());
            
            for (int i = 0; i < p_Tns.Nodes.Count; i++)
            {
                getNodes(p_Tns.Nodes[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            al.Clear();
            if (tvOrder.Nodes.Count > 0)
            {
                getNodes(tvOrder.Nodes[0]);
                string[] Id = new string[al.Count];
                for (int i = 0; i < al.Count; i++)
                {
                    Id[i] = al[i].ToString();                    
                }
                com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
               long lng  =  objSvc.m_lngInsertAllRptorder(Id);
               if (lng>0)
               {
                   MessageBox.Show("保存成功");
               }
            }
        }
    }
}