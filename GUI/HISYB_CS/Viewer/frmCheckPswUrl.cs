using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCheckPswUrl : Form
    {
        public frmCheckPswUrl()
        {
            InitializeComponent();
        }

        private string p_strUrl = "";

        public frmCheckPswUrl(string strUrl)
        {
            InitializeComponent();

            p_strUrl = strUrl;
        }

        private void frmCheckPswUrl_Load(object sender, EventArgs e)
        {
            this.WebUrl.Navigate(p_strUrl);
        }
    }
}