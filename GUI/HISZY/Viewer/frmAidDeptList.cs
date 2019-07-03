using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 报表用科室列表UI
    /// </summary>
    public partial class frmAidDeptList : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmAidDeptList()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 记数器

        /// </summary>
        private int i = 0;
        /// <summary>
        /// 数据集

        /// </summary>
        private DataTable dt = null;
        /// <summary>
        /// 数据视图
        /// </summary>
        private DataView dv = null;
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList deptidarr = null;
        /// <summary>
        /// 科室ID数组
        /// </summary>
        public ArrayList DeptIDArr
        {
            get
            {
                return deptidarr;
            }
        }
        /// <summary>
        /// 科室名称(组合)
        /// </summary>
        private string deptname = "";
        /// <summary>
        /// 科室名称(组合)
        /// </summary>
        public string DeptName
        {
            get
            {
                return deptname;
            }
        }
        #endregion

        #region 建树
        /// <summary>
        /// 建树
        /// </summary>
        private void m_mthLoad()
        {
            clsDcl_Charge objCharge = new clsDcl_Charge();           

            long l = objCharge.m_lngGetDeptArea(out dt, 1);
            if (l > 0)
            {               
                this.m_mthCreateTree(null, null);                           
            }
        }

        #region 递规建树
        /// <summary>
        /// 递规建树
        /// </summary>       
        /// <param name="pID"></param>
        /// <param name="pNode"></param>
        private void m_mthCreateTree(string pID, TreeNode pNode)
        {
            dv = new DataView(dt);

            if (pID == null)
            {
                dv.RowFilter = "parentid = '0'";
                TreeNode tnRoot = new TreeNode("全院科室");
                tnRoot.Tag = "&|" + dv[0]["deptid_chr"].ToString();
                this.tv.Nodes.Add(tnRoot);
                this.m_mthCreateTree(dv[0]["deptid_chr"].ToString(), tnRoot);
            }
            else
            {
                dv.RowFilter = "parentid = '" + pID + "'";
                dv.Sort = "shortno_chr";
                foreach (DataRowView drv in dv)
                {
                    TreeNode tn = new TreeNode(drv["deptname_vchr"].ToString());
                    tn.Tag = pID + "|" + drv["deptid_chr"].ToString();
                    pNode.Nodes.Add(tn);
                    this.m_mthCreateTree(drv["deptid_chr"].ToString(), tn);
                }

                if (i == 8)
                {

                    this.tv.ExpandAll();
                }

                i++;
            }
        }
        #endregion               
        #endregion

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        private void m_mthReset(TreeNode pNode)
        {
            pNode.Checked = false;

            foreach (TreeNode tn in pNode.Nodes)
            {
                this.m_mthReset(tn);
            }
        }
        #endregion

        #region 选择
        /// <summary>
        /// 选择
        /// </summary>
        private void m_mthOk()
        {
            deptidarr = new ArrayList();

            if (this.tv.Nodes[0].Checked && this.tv.Nodes[0].Text == "全院科室")
            {
                deptname = "全院";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.m_mthGetDeptID(this.tv.Nodes[0]);
                if (deptidarr.Count == 0)
                {
                    MessageBox.Show("请选择科室。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }   
        }

        /// <summary>
        /// 递规获取科室/病区ID
        /// </summary>
        /// <param name="pNode"></param>
        private void m_mthGetDeptID(TreeNode pNode)
        {
            if (pNode.Checked)
            {
                this.m_mthGetChildDeptID(pNode);
            }
            else
            {
                foreach (TreeNode tn in pNode.Nodes)
                {
                    this.m_mthGetDeptID(tn);
                }
            }
        }

        /// <summary>
        /// 递规获取所有子科室/病区ID
        /// </summary>
        /// <param name="pNode"></param>
        private void m_mthGetChildDeptID(TreeNode pNode)
        {
            string deptId = pNode.Tag.ToString();
            deptidarr.Add(deptId.Substring(deptId.IndexOf('|') + 1));
            deptname += " " + pNode.Text.Trim();

            foreach (TreeNode tn in pNode.Nodes)
            {
                this.m_mthGetChildDeptID(tn);
            }
        }
        #endregion

        private void frmAidDeptList_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_mthLoad();
            this.Cursor = Cursors.Default;
        }
        
        private void frmAidDeptList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }        

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.m_mthReset(this.tv.Nodes[0]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_mthOk();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool isInvert = false;

        private void btnRever_Click(object sender, EventArgs e)
        {
            this.isInvert = true;
            Invert(this.tv.Nodes[0]);
            this.tv.Nodes[0].Checked = false;
            this.isInvert = false;
        }

        void Invert(TreeNode node)
        {
            node.Checked = !node.Checked;
            foreach (TreeNode tn in node.Nodes)
            {
                Invert(tn);
            }
        }

        bool check = false;

        private void tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.isInvert) return;
            if (check == false)
                setchild(e.Node);
            check = false;
        }

        //设置子节点状态
        private void setchild(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;
            }
            check = true;
        }

    }
}