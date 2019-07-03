using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmUri : Form
    {
        public frmUri(string _caption, string _uri)
        {
            InitializeComponent();
            this.Text = _caption;
            this.Uri = _uri;
        }

        string Uri { get; set; }

        private void frmUri_Load(object sender, EventArgs e)
        {
            this.webBrowser.Navigate(this.Uri);
        }
    }
}
