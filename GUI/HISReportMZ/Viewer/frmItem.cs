using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmItem : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public string ItemCode = "";
        public string ItemName = "";
        //add 2007.5.8 zhu.w.t
        public string ItemCode_Vchr = "";

        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            m_lsvList.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void m_lsvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_Item_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.m_blnSelect())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
               
            }
        }

        private void m_lsvList_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void m_lsvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_blnSelect())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("please choose ....");
                }

            }
        }

        private bool m_blnSelect()
        {
            bool ret = false;

            if (this.m_lsvList.SelectedItems.Count > 0)
            {
                DataRow dr = this.m_lsvList.SelectedItems[0].Tag as DataRow;

                ItemCode = dr["ITEMID_CHR"].ToString();
                ItemName = dr["ITEMNAME_VCHR"].ToString();
                ItemCode_Vchr = dr["ITEMCODE_VCHR"].ToString();
                
                ret = true;                
            }

            return ret;
        }

        private void m_lsvList_DoubleClick(object sender, EventArgs e)
        {

            if (this.m_blnSelect())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("please choose ....");
            }
        }
    }
}