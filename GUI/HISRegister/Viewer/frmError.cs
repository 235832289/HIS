using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmError : Form
    {
        /// <summary>
        /// 用于个别显示
        /// </summary>
        public frmError(string p_strItemID, string p_strItemName)
        {
            strItemID = p_strItemID;
            m_strItemName = p_strItemName;
            InitializeComponent();
        }
        private string strItemID ="";
        private string m_strItemName ="";
        private void frmError_Load(object sender, EventArgs e)
        {
            this.Deactivate += new EventHandler(frmError_Deactivate);
        }

        void frmError_Deactivate(object sender, EventArgs e)
        {

        }

        private void m_btnYes_Click(object sender, EventArgs e)
        {
            closefrm();
            this.DialogResult = DialogResult.Yes;
        }

        private void m_btnNo_Click(object sender, EventArgs e)
        {
            closefrm();
            this.DialogResult = DialogResult.No;

        }

        private void closefrm()
        {
            if (objfrm != null)
            {
                objfrm.Close();
                objfrm = null;                
            }
        }
        frmRelationship objfrm = null;
        private void m_btnView_Click(object sender, EventArgs e)
        {
            if (objfrm == null)
            {
                objfrm = new frmRelationship(strItemID);
                objfrm.Text = m_strItemName+"相关联的项目列表";
                objfrm.Show();
            }
        }

        private void frmError_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                closefrm();
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closefrm();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}