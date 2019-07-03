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
    public partial class frmCheckItemSelector : Form
    {
        private clsLISCheckItemNode item;
        private clsQCBatch m_objContoller = new clsQCBatch();

        public clsLISCheckItemNode SelectedCheckItem
        {
            get
            {
                return this.item;
            }
        }
        public frmCheckItemSelector()
        {
            InitializeComponent();
        }

        private void m_cmdConfirm_Click(object sender, EventArgs e)
        {
            if (!m_mthDoOK())
            {
                MessageBox.Show("请选定一个检验项目.", "iCare");
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_trvCheckItem_DoubleClick(object sender, EventArgs e)
        {
            m_mthDoOK();
        }
        private bool m_mthDoOK()
        {
            if (this.m_trvCheckItem.SelectedNode != null)
            {
                clsLISCheckItemNode node = (this.m_trvCheckItem.SelectedNode.Tag as clsLISCheckItemNode);
                if (node != null)
                {
                    this.item = node;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return true;
                }
            }
            return false;
        }

        private void frmCheckItemSelector_Load(object sender, EventArgs e)
        {

        }

        //private void m_mthQueryQCCheckItem()
        //{
        //    this.m_objContoller.m_mthQueryQCCheckItem(this.m_strDeviceId, out this.dtQCResult);
        //    if (this.dtQCResult != null && this.dtQCResult.Rows.Count > 0)
        //    {
        //        this.m_dgQCCheckItem.DataSource = this.dtQCResult;
        //        this.m_btnSelectNone_Click(null, null);
        //    }
        //}
    }
}