using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmProgress : Form
    {
        public frmProgress(int p_MinValue, int p_MaxValue)
        {
            InitializeComponent();
            this.progressBar.Minimum = p_MinValue;
            this.progressBar.Maximum = p_MaxValue;
        }

        public void m_mthSetCurrentVal(int p_Val)
        {
            if ((this.progressBar.Value + p_Val) < this.progressBar.Maximum)
            {
                this.progressBar.Value += p_Val;
            }
        }
    }
}