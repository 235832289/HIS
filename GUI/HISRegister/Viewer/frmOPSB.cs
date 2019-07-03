using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPSB : Form//com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private frmOPCharge objfrm;

        private string m_strDBFile = string.Empty;

        internal string m_strChargeNo = string.Empty;
        /// <summary>
        /// 记账金额
        /// </summary>
        internal decimal m_decYBSum = 0;
        /// <summary>
        /// 总金额
        /// </summary>
        internal decimal m_decTotalSum = 0;


        public frmOPSB(string p_strDBFile)
        {
            InitializeComponent();
            this.m_strDBFile = p_strDBFile;
        }

        public void m_Setform(frmOPCharge f)
        {
            objfrm = f;
        }

        private void frmOPSB_Load(object sender, EventArgs e)
        {
            this.lblUpfilename.Text = this.m_strDBFile;
        }

        private void frmOPSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.btnOK_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (objfrm.m_blnCreateDBFData(ref m_strDBFile))
            {
                this.lblUpfilename.Text = m_strDBFile;
            }
            else
            {
                this.lblUpfilename.Text = string.Empty;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string strDBFile = this.lblUpfilename.Text.Trim();
            if (strDBFile == string.Empty)
            {
                MessageBox.Show("请先上传DBF医保数据文件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            strDBFile = strDBFile.Replace("A", "B");
            DataTable dtYB = new DataTable();

            if (objfrm.m_blnReadDBFData(strDBFile, out dtYB))
            {
                this.lblZlkh.Text = objfrm.m_PatientBasicInfo.PatientCardID;
                this.lblName.Text = objfrm.m_PatientBasicInfo.PatientName;
                this.lblDbf.Text = strDBFile;
                this.lblChargeNo.Text = dtYB.Rows[0]["SDYWH"].ToString();
                this.lblTotalMoney.Text = dtYB.Rows[0]["ZYZJE"].ToString();
                this.lblYBMoney.Text = dtYB.Rows[0]["SBZFJE"].ToString();
                this.lblGovMoney.Text = dtYB.Rows[0]["GWYBZJE"].ToString();
                this.lblSbMoeny.Text = dtYB.Rows[0]["GRZFJE"].ToString();
                this.lblTdmzye.Text = dtYB.Rows[0]["TDMZYE"].ToString();
            }
            else
            {
                this.lblDbf.Text = string.Empty;
                this.lblChargeNo.Text = string.Empty;
                this.lblTotalMoney.Text = string.Empty;
                this.lblYBMoney.Text = string.Empty;
                this.lblGovMoney.Text = string.Empty;
                this.lblSbMoeny.Text = string.Empty;
                this.lblTdmzye.Text = string.Empty;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.m_strChargeNo = this.lblChargeNo.Text.Trim();

            if (this.m_strChargeNo == string.Empty)
            {
                return;
            }

            //this.m_decYBSum = clsPublic.ConvertObjToDecimal(this.lblSbMoeny.Text);
            //记账金额
            //this.m_decYBSum = clsPublic.ConvertObjToDecimal(this.lblTotalMoney.Text) - clsPublic.ConvertObjToDecimal(this.lblSbMoeny.Text);
            // 1008.记账金额
            this.m_decYBSum = clsPublic.ConvertObjToDecimal(this.lblYBMoney.Text);
            this.m_decTotalSum = clsPublic.ConvertObjToDecimal(this.lblTotalMoney.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}