using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊业务收入收据
    /// baojian.mo add in 2008.02.28
    /// </summary>
    public partial class frmInvorecReoport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmInvorecReoport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置窗体控制器
        /// </summary>
        public override void CreateController()
        {
            this.objController = new ctlControlInvorecRpt();
            this.objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvorecReoport_Load(object sender, EventArgs e)
        {
            this.rdbno.Checked = true;
            ((ctlControlInvorecRpt)this.objController).m_mthInitRpt(this.m_dwShow);
            ((ctlControlInvorecRpt)this.objController).m_mthFillBox();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.m_dwShow.PrintProperties.Preview = !this.m_dwShow.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.m_dwShow.Print(false);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this, "你现在选中的收费员ID为：" + ctfEmpNo.Tag.ToString() + "。", "iCare");
            ((ctlControlInvorecRpt)this.objController).m_mthQuery();
        }

        private void rdbyes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbyes.Checked)
            {
                ((ctlControlInvorecRpt)this.objController).intISConfirm = 1;
                this.tabControl1.SelectedIndex = 1;
            }
            else
            {
                ((ctlControlInvorecRpt)this.objController).intISConfirm = 0;
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void m_dgnotConfirm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex >= 0)
            {
                if (this.m_dgnotConfirm.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper() == "T")
                {
                    this.m_dgnotConfirm.Rows[e.RowIndex].Cells[0].Value = "F";
                }
                else
                {
                    this.m_dgnotConfirm.Rows[e.RowIndex].Cells[0].Value = "T";
                }
            }
            this.m_dgnotConfirm.Rows[e.RowIndex].Cells[1].Selected = true;//变更焦点，自动提交CheckBox的值
            ((ctlControlInvorecRpt)this.objController).m_mthUpdateRpt(0);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ((ctlControlInvorecRpt)this.objController).m_mthConfirmRec();
        }

        private void m_dgvConfirm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex >= 0)
            {
                ((ctlControlInvorecRpt)this.objController).m_mthUpdateRpt(1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((ctlControlInvorecRpt)this.objController).m_mthModifyReceive();
        }
    }
}