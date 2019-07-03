using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmShowPlusItem : Form
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        const int AW_CENTER = 0x0010;
        const int AW_ACTIVATE = 0x20000;

        public frmShowPlusItem(List<clsCtl_DoctorWorkstation.EntityItem> _data, decimal _total, decimal _selfTotal)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                this.lblSelfTotal.Text = _selfTotal.ToString();
                this.lblTotal.Text = _total.ToString();
                this.dgvData.DataSource = _data;
            }
        }

        private void frmShowPlusItem_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 50, AW_CENTER | AW_ACTIVATE);
            this.textBox1.Focus();
            this.timer.Interval = 15000;
            this.timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
