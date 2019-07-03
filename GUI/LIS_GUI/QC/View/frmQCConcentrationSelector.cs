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
    public partial class frmQCConcentrationSelector : Form
    {
        private List<clsLisQCConcentrationVO> m_lstConcentration = new List<clsLisQCConcentrationVO>();
        int min = 0;
        int max = 0;
        public List<clsLisQCConcentrationVO> Concentrations
        {
            get { return m_lstConcentration; }
        }

        public frmQCConcentrationSelector(List<clsLisQCConcentrationVO> lstConcentration,int minSelected,int maxSelected)
        {
            InitializeComponent();
            if (lstConcentration != null)
            {
                foreach (clsLisQCConcentrationVO var in lstConcentration)
                {
                    if (minSelected == 1 && maxSelected == 1)
                    {
                        RadioButton rad = new RadioButton();
                        rad.Text = var.m_strConcentration;
                        rad.Tag = var;
                        rad.Dock = DockStyle.Top;
                        this.m_gpbList.Controls.Add(rad);
                    }
                    else
                    {
                        CheckBox chk = new CheckBox();
                        chk.Text = var.m_strConcentration;
                        chk.Tag = var;
                        chk.Dock = DockStyle.Top;
                        this.m_gpbList.Controls.Add(chk);
                    }
                }
            }
            this.min = minSelected;
            this.max = maxSelected;
        }

        private void m_cmdConfirm_Click(object sender, EventArgs e)
        {
            m_lstConcentration.Clear();
            foreach (Control ctl in this.m_gpbList.Controls)
            {
                CheckBox chk = ctl as CheckBox;
                if (chk != null && chk.Checked)
                {
                    this.m_lstConcentration.Add(chk.Tag as clsLisQCConcentrationVO);
                }

                RadioButton rad = ctl as RadioButton;
                if (rad != null && rad.Checked)
                {
                    this.m_lstConcentration.Add(rad.Tag as clsLisQCConcentrationVO);
                }
            }
            if (this.m_lstConcentration.Count < this.min)
            {
                MessageBox.Show("你必需先择最少 " + this.min.ToString() + " 个浓度!", "iCare");
                return;
            }
            if (this.m_lstConcentration.Count > this.max)
            {
                MessageBox.Show("你最多只能先择 " + this.max.ToString() + " 个浓度!", "iCare");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}