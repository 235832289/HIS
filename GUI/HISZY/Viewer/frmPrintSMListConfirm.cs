using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPrintSMListConfirm : Form
    {
        public string strOpreationName = "";
        public string strANAName = "";
        public string strANADate = "";
        public string strOpreationNameOld = "";
        public string strANANameOld = "";
        public string strANADateOld = "";
        public DataTable dtChargeItems = null;

        public frmPrintSMListConfirm(string strOpreationName, string strANAName, string strANADate, ref DataTable p_dtResult)
        {
            InitializeComponent();
            strOpreationNameOld = strOpreationName;
            strANANameOld = strANAName;
            strANADateOld = strANADate;
            this.txtOprName.Text = strOpreationName;
            this.txtAneMode.Text = strANAName;
            this.txtANATime.Text = strANADate;

            this.dtChargeItems = p_dtResult;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtOprName.Text.Trim() != strOpreationNameOld || this.txtAneMode.Text.Trim() != strANANameOld || this.txtANATime.Text.Trim() != strANADateOld)
            {
                strOpreationName = this.txtOprName.Text.Trim();
                strANAName = this.txtAneMode.Text.Trim();
                strANADate = this.txtANATime.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }

            DataTable dtTemp = dtChargeItems.Clone();
            for (int i = 0; i < this.gdvChargeItems.Rows.Count; i++)
            {
                if ((int)this.gdvChargeItems[0, i].Value == 1)
                {
                    int intIndex =  Convert.ToInt32(this.gdvChargeItems.Rows[i].Tag);
                    dtTemp.ImportRow(dtChargeItems.Rows[intIndex]);
                }
            }
            this.dtChargeItems = dtTemp;
            this.Close();
        }

        private void frmPrintSMListConfirm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dtChargeItems.Rows.Count; i++)
            {
                this.gdvChargeItems.Rows.Add(1);
                this.gdvChargeItems[0, i].Value = 0;
                this.gdvChargeItems[1, i].Value = this.dtChargeItems.Rows[i]["chargeitemname_chr"].ToString();
                this.gdvChargeItems[2, i].Value = this.dtChargeItems.Rows[i]["itemspec_vchr"].ToString();
                this.gdvChargeItems[3, i].Value = this.dtChargeItems.Rows[i]["amount_dec"].ToString();
                this.gdvChargeItems[4, i].Value = this.dtChargeItems.Rows[i]["unit_vchr"].ToString();
                this.gdvChargeItems[5, i].Value = this.dtChargeItems.Rows[i]["totalmoney_dec"].ToString();
                this.gdvChargeItems[6, i].Value = this.dtChargeItems.Rows[i]["usagename_vchr"].ToString();
                this.gdvChargeItems.Rows[i].Tag = this.dtChargeItems.Rows[i]["index"].ToString();
            }
        }

        private void gdvChargeItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int intCurrent = this.gdvChargeItems.CurrentRow.Index;
            if ((int)this.gdvChargeItems[0,intCurrent].Value == 0)
            {
                this.gdvChargeItems[0, intCurrent].Value = 1;
            }
            else
            {
                this.gdvChargeItems[0, intCurrent].Value = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                for (int i = 0; i < this.gdvChargeItems.Rows.Count; i++)
                {
                    this.gdvChargeItems[0, i].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < this.gdvChargeItems.Rows.Count; i++)
                {
                    this.gdvChargeItems[0, i].Value = 0;
                }
            }
        }
    }
}