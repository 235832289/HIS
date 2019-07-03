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
    public partial class frmShiying : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmShiying()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_Shiyingsetting();
            objController.Set_GUI_Apperance(this);
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_Shiyingsetting)this.objController).m_mthQuery();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_Shiyingsetting)this.objController).m_mthSelectedIndex();
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            ((clsCtl_Shiyingsetting)this.objController).m_mthEmpty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_Shiyingsetting)this.objController).m_mthSave();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ((clsCtl_Shiyingsetting)this.objController).m_mthDelete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}