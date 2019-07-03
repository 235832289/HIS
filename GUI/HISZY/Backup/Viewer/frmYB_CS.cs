using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 医保结算(茶山模式)
    /// </summary>
    public partial class frmYB_CS : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmYB_CS()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// DBF连接参数
        /// </summary>
        internal string DSN = "";
        /// <summary>
        /// 自付金额
        /// </summary>
        private decimal sbmny = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SbMny
        {
            get
            {
                return sbmny;
            }
        }
        /// <summary>
        /// 医保返回数据集
        /// </summary>
        private DataTable dtyb = new DataTable();
        /// <summary>
        /// 医保返回数据集
        /// </summary>
        public DataTable dtYB
        {
            get
            {
                return dtyb;
            }
        }
        #endregion

        private void frmYB_CS_Load(object sender, EventArgs e)
        {
            this.btnOk.Enabled = false;
        }       

        private void btnReceive_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
                        
            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = objCharge.m_lngGetResult(this.DSN, "S" + this.lblZyh.Text.Trim(), out dtyb);
            if (l > 0 && dtyb.Rows.Count > 0)
            {
                this.lblYBMoney.Text = dtyb.Rows[0]["sbzfje"].ToString();
                this.lblGovMoney.Text = dtyb.Rows[0]["gwybzje"].ToString();

                //this.sbmny = clsPublic.ConvertObjToDecimal(dtyb.Rows[0]["grzfje"]);
                this.sbmny = clsPublic.ConvertObjToDecimal(this.lblTotalMoney.Text) - clsPublic.ConvertObjToDecimal(this.lblYBMoney.Text) - clsPublic.ConvertObjToDecimal(this.lblGovMoney.Text);
                this.lblSbMoeny.Text = this.sbmny.ToString();

                this.btnOk.Enabled = true;
                this.lblStatus.Text = "接收医保结算数据成功！";
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("接收医保结算数据失败，请重新接收。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.Cursor = Cursors.Default;
        }       

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}