using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmInvoiceRefundReason : Form
    {
        public frmInvoiceRefundReason(int _flagId, string _invoNo, string _operId)
        {
            InitializeComponent();
            this.flagId = _flagId;
            this.inVoNo = _invoNo;
            this.operId = _operId;
        }

        /// <summary>
        /// 1 门诊; 2 住院; 3 预交金
        /// </summary>
        int flagId { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        string inVoNo { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        string operId { get; set; }

        private void frmOPInvoiceReturnReason_Load(object sender, EventArgs e)
        {
            clsDcl_Charge dcl = new clsDcl_Charge();
            DataTable dt = dcl.GetRefundReasonList(this.flagId);
            EntityInvoiceRefundReason vo = dcl.GetInvoiceRefundReason(this.flagId, this.inVoNo);
            dcl = null;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.cboReason.Items.Add(dr["freason"].ToString());
                }
            }
            if (vo != null) this.cboReason.Text = vo.reason;
        }

        private void frmOPInvoiceReturnReason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string reason = this.cboReason.Text.Trim();
            if (reason == string.Empty)
            {
                MessageBox.Show("请选择退款原因...", "系统提示");
                return;
            }
            EntityInvoiceRefundReason vo = new EntityInvoiceRefundReason();
            vo.flagId = this.flagId;
            vo.invoNo = this.inVoNo;
            vo.reason = reason;
            vo.operId = this.operId;
            vo.operDate = DateTime.Now;
            vo.status = 1;
            clsDcl_Charge dcl = new clsDcl_Charge();
            int ret = dcl.SaveInvoiceRefundReason(vo);
            dcl = null;
            if (ret > 0)
            {
                MessageBox.Show("退款原因保存成功！", "系统提示");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("退款原因保存失败。", "系统提示");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
