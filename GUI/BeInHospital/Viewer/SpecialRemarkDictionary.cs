using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 特别注释字典维护界面
    /// </summary>
    public partial class SpecialRemarkDictionary :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public SpecialRemarkDictionary()
        {
            InitializeComponent();
        }
        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlSpecialRemarkDic();
            objController.Set_GUI_Apperance(this);
        }
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpecialRemarkDictionary_Load(object sender, EventArgs e)
        {
            this.cboCondition.SelectedIndex = 0;
            ((clsControlSpecialRemarkDic)this.objController).m_mthLoadData();
            this.m_btnAdd.Focus();
        }

        internal void m_dgvSpecialRemarkDic_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsControlSpecialRemarkDic)this.objController).m_mthDataGridViewCellChanged();
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            ((clsControlSpecialRemarkDic)this.objController).m_mthClear();
            ((clsControlSpecialRemarkDic)this.objController).m_mthGetRemarkID();
            this.m_txtRemarkContent.Focus();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            ((clsControlSpecialRemarkDic)this.objController).m_mthSaveSpecialRemarkDic();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {   
            if(this.m_dgvSpecialRemarkDic.CurrentRow.Index<0)
                return ;
            if (DialogResult.OK == MessageBox.Show("是否要删除该特殊注释字典？", "iCare提示信息！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                ((clsControlSpecialRemarkDic)this.objController).m_mthDeleteSpecialRemarkDic();
            }
            else
            {
                return;
            }
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsControlSpecialRemarkDic)this.objController).m_mthLoadData();
        }

        private void m_btnSearch_Click(object sender, EventArgs e)
        {
            ((clsControlSpecialRemarkDic)this.objController).m_mthFindSpecialRemarkDicByCondition();
        }

        private void m_txtRemarkContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                SendKeys.Send("{TAB}");
            }
        }

        private void m_cboDebtControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_btnSave.Focus();
        }

        private void m_txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
    
            }

        }

        private void m_cboDebtControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
               
            }
        }

        internal  void m_txtUserCode_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}