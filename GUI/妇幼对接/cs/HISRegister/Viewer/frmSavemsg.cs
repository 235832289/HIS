using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmSavemsg : Form
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);        
        const int AW_CENTER = 0x0010;       
        const int AW_ACTIVATE = 0x20000;        	

        private string Hintinfo = "";
        public frmSavemsg(string hf)
        {
            InitializeComponent();

            Hintinfo = hf;
        }

        private void frmSavemsg_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 50, AW_CENTER | AW_ACTIVATE);

            this.lblInfo.Text = Hintinfo;
            this.timer.Interval = 500;
            this.timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}