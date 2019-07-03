using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 特定病种对应ICD10码间维护
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-22
    /// </summary>
    public partial class frmYbdeadeficd : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmYbdeadeficd()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlYbdeadeficd();
            objController.Set_GUI_Apperance(this);
        }

        private void frmYbdeadeficd10_Load(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).GetSpecialDisease();
            ((clsCtlYbdeadeficd)this.objController).GetICD();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).AddDefICD();
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
            ((clsCtlYbdeadeficd)this.objController).AfterSelectDisease(tn.Tag.ToString().Trim());

        }

        private void buttonFillter_Click(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).FilterICD();
        }

      
        private void m_saveButton_Click(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).SaveDeaDef();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).RemoveDefICD();
        }

        private void m_resetButton_Click(object sender, EventArgs e)
        {
            ((clsCtlYbdeadeficd)this.objController).ResetICD();
        }

    }
}