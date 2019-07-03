using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 特定病种对应收费代码维护
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-24
    /// </summary>
    public partial class frmYbdeaDefChargeitem : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmYbdeaDefChargeitem()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsYbdeaDefChargeItem();
            objController.Set_GUI_Apperance(this);
        }

        private void frmYbdeaDefChargeitem_Load(object sender, EventArgs e)
        {
            ((clsYbdeaDefChargeItem)this.objController).GetSpecialDisease();
            //
        }

        private void m_addButton_Click(object sender, EventArgs e)
        {
            ((clsYbdeaDefChargeItem)this.objController).AddDefChargeItem();
        }

        private void m_DelButton_Click(object sender, EventArgs e)
        {
            ((clsYbdeaDefChargeItem)this.objController).RemoveDefChargeItem();
        }

        private void m_saveButton_Click(object sender, EventArgs e)
        {
            ((clsYbdeaDefChargeItem)this.objController).SaveDeaDefChargeItem();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_tvDisease_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_tvDisease.SelectedNode == null)
            {
                if (m_tvDisease.Nodes.Count > 0)
                {
                    m_tvDisease.SelectedNode = m_tvDisease.Nodes[0];
                }
            }
            TreeNode tn = e.Node;
            ((clsYbdeaDefChargeItem)this.objController).AfterSelectDisease(tn.Tag.ToString().Trim());
        }

   
        private void tabPageAllItem_Enter(object sender, EventArgs e)
        {
            if (this.m_dgvAllItem.Rows.Count == 0)
            {
                ((clsYbdeaDefChargeItem)this.objController).GetChargeItem();
                
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (this.tabControlMain.SelectedIndex == 0 )
            {
                ((clsYbdeaDefChargeItem)this.objController).FilterYBChargeItem();
            }
            else if (this.tabControlMain.SelectedIndex == 1)
            {
                ((clsYbdeaDefChargeItem)this.objController).FilterChargeItem();
            }
        }

        private void m_resetButton_Click(object sender, EventArgs e)
        {
            if (this.tabControlMain.SelectedIndex == 0)
            {
                ((clsYbdeaDefChargeItem)this.objController).ResetYBChargeItem();
            }
            else if (this.tabControlMain.SelectedIndex == 1)
            {
                ((clsYbdeaDefChargeItem)this.objController).ResetChargeItem();
            }
        }
    }
}