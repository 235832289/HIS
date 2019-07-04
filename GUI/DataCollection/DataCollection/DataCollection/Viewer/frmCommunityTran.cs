using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public partial class frmCommunityTran : Form
    {
        public frmCommunityTran()
        {
            InitializeComponent();
        }

        private void frmCommunityTran_Load(object sender, EventArgs e)
        {
            this.dtpTime.Value = DateTime.Now;
            this.lblInfor.Text = string.Empty;
            this.lsvInfor.Items.Clear();
        }

        private void cmdTran_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.cmdTran.Enabled = false;
            this.lsvInfor.Items.Clear();
            this.lblInfor.Text = "准备上传.....";

            clsReceiveData objRece = new clsReceiveData();
            timer1.Start();
            objRece.m_lngUpload(this.dtpTime.Value, this.lblInfor, this.lsvInfor); 
            this.cmdTran.Enabled = true;
            timer1.Stop();
            this.Refresh();
            this.Cursor = Cursors.Default;
        } 

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int intFlash = 3;
        int intCurrentFlash = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (intCurrentFlash == intFlash)
            {
                this.Refresh();
                intCurrentFlash = 0;
            }
            else
            {
                intCurrentFlash++;
            }
        }
    }
}