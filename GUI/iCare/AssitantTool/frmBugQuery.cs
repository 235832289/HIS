using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace iCare
{
    public partial class frmBugQuery : Form
    {
        public frmBugQuery()
        {
            InitializeComponent();

            m_objDomain = new clsBugQueryDomain();
            m_objDomain.m_objViewer = this;
            m_dtpStart.Value = m_dtpEnd.Value.AddMonths(-1);
        }

        private void frmBugQuery_Load(object sender, System.EventArgs e)
        {
            m_objDomain.m_mthFillTree();
            m_cmdSelectDefault_Click(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_rdbSingleDept.Checked)
            {
                m_txtDept.Enabled = true;
            }
            else
            {
                m_txtDept.Enabled = false;
                m_txtDept.Text = "";
                m_txtDept.Tag = null;
                m_lsvFind.Visible = false;
            }
        }

        private void m_txtDept_TextChanged(object sender, System.EventArgs e)
        {
            m_objDomain.m_mthFindDepts(m_txtDept.Text.Trim());
            m_lsvFind.BringToFront();
            m_lsvFind.Visible = true;
        }

        private void m_lsvFind_DoubleClick(object sender, System.EventArgs e)
        {
            if (m_lsvFind.SelectedItems.Count > 0)
            {
                ListViewItem item = m_lsvFind.SelectedItems[0];
                m_txtDept.Text = item.Text;
                m_txtDept.Tag = item.SubItems[3].Text;
                m_lsvFind.Visible = false;
            }
        }

        private void m_lsvFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    m_lsvFind_DoubleClick(null, null);
                    break;
                case Keys.Up:
                    if (m_lsvFind.SelectedItems.Count > 0)
                    {
                        if (m_lsvFind.SelectedItems[0].Index == 0)
                            m_txtDept.Focus();
                    }
                    break;
                default:
                    break;
            }
        }

        private void m_txtDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (m_lsvFind.Visible == true)
                    {
                        m_lsvFind.Focus();
                        m_lsvFind.Items[0].EnsureVisible();
                        m_lsvFind.Items[0].Selected = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void m_trvItems_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_lsvFind.Visible = false;
        }

        private void btnEsc_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, System.EventArgs e)
        {
            m_objDomain.m_mthBeginPrint();
            m_pdcShow.Print();
        }

        private void btnQuery_Click(object sender, System.EventArgs e)
        {
            try
            {
                pnlIsBusy.Visible = true;
                Application.DoEvents();
                m_ppwShow.setDocument = null;
                m_objDomain.m_mthQuery();
                m_ppwShow.setDocument = this.m_pdcShow;
            }
            catch (Exception ex)
            {
                new com.digitalwave.Utility.clsLogText().LogDetailError(ex, false);
            }
            finally
            {
                pnlIsBusy.Visible = false;
            }
        }

        private void m_pdcShow_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objDomain.m_mthBeginPrint();
        }

        private void m_pdcShow_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void m_pdcShow_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_objDomain.m_mthPrint(e);
        }

        private void m_cmdSelectAll_Click(object sender, System.EventArgs e)
        {
            foreach (TreeNode n in m_trvItems.Nodes)
                m_mthSelectAll(n, true);
        }
        private void m_mthSelectAll(TreeNode p_trnParent, bool p_blnChecked)
        {
            p_trnParent.Checked = p_blnChecked;
            if (p_trnParent.Nodes.Count > 0)
            {
                foreach (TreeNode n in p_trnParent.Nodes)
                    m_mthSelectAll(n, p_blnChecked);
            }
        }

        private void m_cmdClearSelect_Click(object sender, System.EventArgs e)
        {
            foreach (TreeNode n in m_trvItems.Nodes)
                m_mthSelectAll(n, false);
        }

        private void m_cmdSaveDefault_Click(object sender, System.EventArgs e)
        {
            DataTable dtbTree = new DataTable("DefaultSelected");
            dtbTree.Columns.Add("Item");
            dtbTree.Columns.Add("ItemChecked", typeof(bool));
            dtbTree.Columns.Add("ParentItem");
            foreach (TreeNode n in m_trvItems.Nodes)
            {
                m_mthGetTreeChecked("0", n, ref dtbTree);
            }
            if (dtbTree.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtbTree);
                ds.WriteXml("FlawedDefaultChecked.xml", XmlWriteMode.WriteSchema);
                ds.Dispose();
            }
            MessageBox.Show("已保存当前的选择为默认值！");
        }
        private void m_mthGetTreeChecked(string p_strParent, TreeNode p_trnParent, ref DataTable p_dtbResult)
        {
            p_dtbResult.Rows.Add(new object[] { p_trnParent.Tag.ToString(), p_trnParent.Checked, p_strParent });
            if (p_trnParent.Nodes.Count > 0)
            {
                foreach (TreeNode n in p_trnParent.Nodes)
                {
                    m_mthGetTreeChecked(p_trnParent.Tag.ToString(), n, ref p_dtbResult);
                }
            }
        }

        private void m_cmdSelectDefault_Click(object sender, System.EventArgs e)
        {
            if (File.Exists("FlawedDefaultChecked.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("FlawedDefaultChecked.xml", XmlReadMode.ReadSchema);
                if (ds.Tables["DefaultSelected"] != null)
                {
                    foreach (TreeNode n in m_trvItems.Nodes)
                    {
                        m_mthSetTreeChecked(n, ds.Tables["DefaultSelected"]);
                    }
                }
                ds.Dispose();
            }
        }
        private void m_mthSetTreeChecked(TreeNode p_trnParent, DataTable p_dtbResult)
        {
            DataRow[] objRow = p_dtbResult.Select("Item = '" + p_trnParent.Tag.ToString() + "'");
            if (objRow.Length > 0)
            {
                p_trnParent.Checked = bool.Parse(objRow[0][1].ToString());
            }
            if (p_trnParent.Nodes.Count > 0)
            {
                foreach (TreeNode n in p_trnParent.Nodes)
                {
                    m_mthSetTreeChecked(n, p_dtbResult);
                }
            }
        }
    }
}