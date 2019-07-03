using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmEditOnceAgain : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmEditOnceAgain()
        {
            InitializeComponent();
        }

        private void cmdOnceAgain_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmEditOnceAgain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    button3_Click(sender,e);
                    break;
                case Keys.F1:
                    button1_Click(sender, e);
                    break;
                case Keys.F2:
                    button2_Click(sender, e);
                    break;
               
            }
        }
    }
}