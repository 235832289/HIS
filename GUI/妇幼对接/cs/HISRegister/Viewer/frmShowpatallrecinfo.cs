using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmShowpatallrecinfo : Form
    {
        private string Recnum = "";
        private string ChargeUpCost = "";
        private string PersonCost = "";
        private string TotalCost = "";

        public frmShowpatallrecinfo(string r, string c, string p, string t)
        {
            InitializeComponent();
            Recnum = r;
            ChargeUpCost = c;
            PersonCost = p;
            TotalCost = t;
        }

        private void frmShowpatallrecinfo_Load(object sender, EventArgs e)
        {
            this.lblRecnum.Text = Recnum;
            this.lblChargeUpCost.Text = ChargeUpCost;
            this.lblPersonCost.Text = PersonCost;
            this.lblTotalCost.Text = TotalCost;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}