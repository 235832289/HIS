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
    /// 医保特种病维护界面  yingrui.liu 2006-6-22
    /// </summary>
    public partial class frmYBSpecialTypeDisease : com.digitalwave.GUI_Base.frmMDI_Child_Base 
    {
        public frmYBSpecialTypeDisease()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControlYBSpecialTypeDisease();
            objController.Set_GUI_Apperance(this);
        }

        public new void Show_MDI_Child(Form frmMDI_Parent)
        {
           
            this.ShowDialog();
          
        }

        private void m_lvw_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (m_lvw.SelectedIndices.Count > 0)
            {
                m_tbDiseCode.Text = m_lvw.SelectedItems[0].SubItems[0].Text;
                m_tbDiseCode.Tag = m_lvw.SelectedItems[0].SubItems[0];
                m_tbDiseName.Text = m_lvw.SelectedItems[0].SubItems[1].Text;
                m_tbYearMoney.Text = m_lvw.SelectedItems[0].SubItems[2].Text;
                m_tbSortNO.Text = m_lvw.SelectedItems[0].SubItems[3].Text;
                m_tbComment.Text = m_lvw.SelectedItems[0].SubItems[4].Text;


                if (m_lvw.SelectedItems[0].SubItems[5].Text.Trim() == "0")
                {
                    lblState.Text = "已停用";
                    m_btnStopUse.Text = "启用(&R)";
                    m_btnStopUse.Tag = "1";

                }
                else if (m_lvw.SelectedItems[0].SubItems[5].Text.Trim() == "1")
                {
                    lblState.Text = "正常";
                    m_btnStopUse.Text = "停用(&T)";
                    m_btnStopUse.Tag = "0";
                }

            }
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            m_tbDiseCode.Text = "";
            m_tbDiseCode.Tag = null;
            m_tbDiseName.Text = "";
            m_tbYearMoney.Text = "";
            m_tbSortNO.Text = "";
            m_tbComment.Text = "";
            m_tbDiseCode.Tag = null;
            lblState.Text = "正常";
            m_btnStopUse.Text = "停用(&T)";
            m_tbDiseCode.Enabled = true;
            m_tbDiseName.Enabled = true;
            m_tbSortNO.Enabled = true;
            m_tbYearMoney.Enabled = true;
            m_tbComment.Enabled = true;
            this.m_tbDiseCode.Focus();

        }

        private void frmYBSpecialTypeDisease_Load(object sender, EventArgs e)
        {
            cboCondition.SelectedIndex = 0;
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthGetYBSpecialTypeDiseaseInfo();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthSave();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnDel_Click(object sender, EventArgs e)
        {
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthDeleletYBSpeInfo();
        }

        private void m_btnStopUse_Click(object sender, EventArgs e)
        {
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthIsStopUsing();
        }

        private void m_tbDiseCode_TextChanged(object sender, EventArgs e)
        {
            if (m_tbDiseCode.Text.Length > 4)
            {
                MessageBox.Show("疾病代码的长度不能超过4位！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_tbDiseCode.Text = "";
                m_tbDiseCode.Focus();
            }
       


        }

        private void m_tbSortNO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int m_intFlag = 0;
                if (m_tbSortNO.Text.Trim() != "")
                {
                    m_intFlag = int.Parse(m_tbSortNO.Text);
                }
            }
            catch
            {
                MessageBox.Show("排序号必须输入数字！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_tbSortNO.Text = "";
                m_tbSortNO.Focus();

            }
        }

        private void m_tbYearMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float m_intFlag = 0;
                if (m_tbYearMoney.Text.Trim() != "")
                {

                    m_intFlag = float.Parse(m_tbYearMoney.Text);
                }
           
            }
            catch
            {
                MessageBox.Show("年度限额必须输入数字！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_tbYearMoney.Text = "";
                m_tbYearMoney.Focus();
            }
        }

        private void m_btnNew_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void m_tbDiseCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                if (m_tbDiseCode.Text.Trim() == "")
                {
                    MessageBox.Show("疾病代码不能为空！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_tbDiseCode.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
        }

        private void frmYBSpecialTypeDisease_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: m_btnNew.PerformClick(); break;
                case Keys.P: btnRefresh.PerformClick(); break;
                case Keys.F: btnSearch.PerformClick(); break;
                case Keys.S: m_btnSave.PerformClick(); break;
                case Keys.D: ((clsControlYBSpecialTypeDisease)this.objController).m_mthDeleletYBSpeInfo(); break;
                case Keys.R: ((clsControlYBSpecialTypeDisease)this.objController).m_mthIsStopUsing(); break;
                case Keys.T: ((clsControlYBSpecialTypeDisease)this.objController).m_mthIsStopUsing(); break;
                case Keys.Escape: this.Close(); break;

            }
        }

        private void m_tbDiseName_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyData == Keys.Enter)
            {
                if (m_tbDiseName.Text.Trim() == "")
                {
                    MessageBox.Show("疾病名称不能为空！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_tbDiseName.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
        }

        private void m_tbYearMoney_KeyDown(object sender, KeyEventArgs e)
        {
                
            if (e.KeyData == Keys.Enter)
            {
                if (m_tbYearMoney.Text.Trim() == "")
                {
                    MessageBox.Show("年度限额不能为空！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_tbYearMoney.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthGetYBSpecialTypeDiseaseInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ((clsControlYBSpecialTypeDisease)this.objController).m_mthGetYBSpecialTypeDiseaseInfoByCondition(cboCondition.SelectedIndex, cboContent.Text.Trim());
        }
    }
}