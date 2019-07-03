using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// �����ÿ����б�UI
    /// </summary>
    public partial class frmAidOutpbillDeptList : Form
    {
        /// <summary>
        /// ����

        /// </summary>
        public frmAidOutpbillDeptList()
        {
            InitializeComponent();
        }

        #region ����
        /// <summary>
        /// ������

        /// </summary>
        private int i = 0;
        /// <summary>
        /// ���ݼ�

        /// </summary>
        private DataTable dt = null;
        /// <summary>
        /// ������ͼ
        /// </summary>
        private DataView dv = null;
        /// <summary>
        /// ����ID����
        /// </summary>
        private ArrayList deptidarr = null;
        /// <summary>
        /// ����ID����
        /// </summary>
        public ArrayList DeptIDArr
        {
            get
            {
                return deptidarr;
            }
        }
        /// <summary>
        /// ��������(���)
        /// </summary>
        private string deptname = "";
        /// <summary>
        /// ��������(���)
        /// </summary>
        public string DeptName
        {
            get
            {
                return deptname;
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        private void m_mthLoad()
        {
            clsDcl_Report_DoctorEarningCollect m_objDomain = new clsDcl_Report_DoctorEarningCollect();

            long l = m_objDomain.m_lngGetDeptArea(out dt);
            if (l > 0)
            {
                this.m_mthCreateTree(null, null);
            }
        }

        #region �ݹ潨��
        /// <summary>
        /// �ݹ潨��
        /// </summary>       
        /// <param name="pID"></param>
        /// <param name="pNode"></param>
        private void m_mthCreateTree(string pID, TreeNode pNode)
        {
            dv = new DataView(dt);

            if (pID == null)
            {
                dv.RowFilter = "parentid = '0'";
                TreeNode tnRoot = new TreeNode("ȫԺ����");
                tnRoot.Tag = dv[0]["deptid_chr"].ToString();
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
                    tn.Tag = drv["deptid_chr"].ToString();
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

        #region ����
        /// <summary>
        /// ����
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

        #region ѡ��
        /// <summary>
        /// ѡ��
        /// </summary>
        private void m_mthOk()
        {
            deptidarr = new ArrayList();

            if (this.tv.Nodes[0].Checked && this.tv.Nodes[0].Text == "ȫԺ����")
            {
                deptname = "ȫԺ";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.m_mthGetDeptID(this.tv.Nodes[0]);

                if (deptidarr.Count == 0)
                {
                    MessageBox.Show("��ѡ����ҡ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// �ݹ��ȡ����/����ID
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
        /// �ݹ��ȡ�����ӿ���/����ID
        /// </summary>
        /// <param name="pNode"></param>
        private void m_mthGetChildDeptID(TreeNode pNode)
        {
            if (pNode.Nodes.Count == 0)
            {
                deptidarr.Add(pNode.Tag.ToString());
                deptname += " " + pNode.Text.Trim();
            }
            else
            {
                foreach (TreeNode tn in pNode.Nodes)
                {
                    this.m_mthGetChildDeptID(tn);
                }
            }
        }
        #endregion

        //private void frmAidDeptList_Load(object sender, EventArgs e)
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    this.m_mthLoad();
        //    this.Cursor = Cursors.Default;
        //}

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAidOutpbillDeptList_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_mthLoad();
            this.Cursor = Cursors.Default;
        }
    }
}