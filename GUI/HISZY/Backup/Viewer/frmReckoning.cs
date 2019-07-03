using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 公用结帐窗口
    /// </summary>
    public partial class frmReckoning : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 结算类型：1 中途结算 2 出院结算 3 呆帐结算 4 直接收费 5 确认收费 6 呆帐补交款结算
        /// </summary>
        public int ChargeType;
        /// <summary>
        /// 明细收费项目
        /// </summary>
        public DataTable ChargeDetail;
        /// <summary>
        /// 用户对象
        /// </summary>
        public ucPatientInfo objPatient;
        /// <summary>
        /// 期帐结算类型：1 期帐 2 明细
        /// </summary>
        public int DayChrgType;
        /// <summary>
        /// 结算期帐数组
        /// </summary>
        public ArrayList DayAccountsArr;
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string ConfirmID = "";
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string ConfirmName = "";
        /// <summary>
        /// 直接结算标志(无费用)
        /// </summary>
        public bool DirectChargeFlag = false;
        /// <summary>
        ///  呆帐结算核算分类数组
        /// </summary>
        public ArrayList BadChargeCatArr;
        /// <summary>
        ///  呆帐结算发票分类数组
        /// </summary>
        public ArrayList BadChargeInvArr;
        /// <summary>
        /// 差值项科室ID
        /// </summary>
        public string BadChargeDiffValDeptID = "";
        /// <summary>
        /// 差值项核算分类ID
        /// </summary>
        public string BadChargeDiffValCatID = "";
        /// <summary>
        /// 直接结算标志(零费用)
        /// </summary>
        public bool DirectChargeOut = false;
  
        #endregion

        #region 构造
        /// <summary>
        /// 公用结帐窗口
        /// </summary>
        public frmReckoning()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_Reckoning();
            objController.Set_GUI_Apperance(this);
        }

        private void frmReckoning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F8)
            {
                if (this.ChargeType == 3)
                {
                    ((clsCtl_Reckoning)this.objController).m_mthBadReckoning();
                }
                else
                {
                    ((clsCtl_Reckoning)this.objController).m_mthReckoning();
                }
            }
        }

        private void frmReckoning_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.btnReckoning.Tag == null || this.btnReckoning.Tag.ToString().Trim() == "")
            {
                if (MessageBox.Show("是否退出结帐窗口？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReckoning_Load(object sender, EventArgs e)
        {
            //初始化
            ((clsCtl_Reckoning)this.objController).m_mthInit();

            #region 提示
            frmFlash flash = new frmFlash();
            flash.Information = "注意检查发票号...";
            Point p = this.txtInvono.Parent.PointToScreen(txtInvono.Location);
            p.Offset(-50, -(flash.Height - txtInvono.Height));
            flash.Location = p;
            flash.Show();
            #endregion

            if (clsPublic.ConvertObjToDecimal(this.lblTotalMoney.Tag) == 0 && this.ChargeType == 2)
            {
                this.DirectChargeOut = true;
                ((clsCtl_Reckoning)this.objController).m_mthInitDir();
            }
        }

        private void txtPayMode1Money_TextChanged(object sender, EventArgs e)
        {
            string val = this.txtPayMode1Money.Text.Trim();

            if (val == "")
            {
                return;
            }
            else
            {
                if (!Microsoft.VisualBasic.Information.IsNumeric(val))
                {
                    MessageBox.Show("金额输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPayMode1Money.Text = "";
                    this.txtPayMode1Money.Focus();
                    return;
                }

                if (Convert.ToDecimal(val) <= 0)
                {
                    MessageBox.Show("金额必须是大于0的正数，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPayMode1Money.Text = "";
                    this.txtPayMode1Money.Focus();
                    return;
                }
            }

            ((clsCtl_Reckoning)this.objController).m_mthChangeMoney();
        }

        private void txtPayMode2Money_TextChanged(object sender, EventArgs e)
        {
            string val = this.txtPayMode2Money.Text.Trim();

            if (val == "")
            {
                return;
            }
            else
            {
                if (!Microsoft.VisualBasic.Information.IsNumeric(val))
                {
                    MessageBox.Show("金额输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPayMode2Money.Text = "";
                    this.txtPayMode2Money.Focus();
                    return;
                }

                if (Convert.ToDecimal(val) <= 0)
                {
                    MessageBox.Show("金额必须是大于0的正数，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPayMode2Money.Text = "";
                    this.txtPayMode2Money.Focus();
                    return;
                }
            }

            ((clsCtl_Reckoning)this.objController).m_mthChangeMoney();
        }

        private void frmReckoning_Activated(object sender, EventArgs e)
        {
            this.txtPayMode1Money.Focus();
        }

        private void cboPayMode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPayMode1Money.Focus();
            }
        }

        private void cboPayMode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPayMode2Money.Focus();
            }
        }

        private void txtInvono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPayMode1Money.Focus();
            }
        }

        private void txtPayMode1Money_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtPayMode2Money.Visible == false)
                {
                    this.btnReckoning.Focus();
                }
                else
                {
                    this.cboPayMode2.SelectedIndex = 0;
                    this.cboPayMode2.Focus();
                }
            }
        }

        private void cboPayMode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPayMode1Money.Text = "";
            ((clsCtl_Reckoning)this.objController).m_mthChangeMoney();
            ((clsCtl_Reckoning)this.objController).m_mthReSetPrepay();
        }

        private void cboPayMode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPayMode2Money.Text = "";
            ((clsCtl_Reckoning)this.objController).m_mthChangeMoney();
            //((clsCtl_Reckoning)this.objController).m_mthReSetPrepay();
        }

        private void btnReckoning_Click(object sender, EventArgs e)
        {
            if (this.ChargeType == 3)
            {
                ((clsCtl_Reckoning)this.objController).m_mthBadReckoning();
            }
            else
            {
                if (this.DirectChargeOut)
                {
                    ((clsCtl_Reckoning)this.objController).m_mthDirReckoning();
                }
                else
                {
                    ((clsCtl_Reckoning)this.objController).m_mthReckoning();
                }
            }
        }

        private void txtPayMode2Money_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnReckoning.Focus();
            }
        }

        /// <summary>
        /// 当前行
        /// </summary>
        private int CurrRow = -1;
        private int HitTimes = 0;
        private bool BlnChecked = false;
        private void dgPrePay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            //下面功能暂停
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                //if ((this.cboPayMode1.SelectedIndex == 0 && this.txtPayMode1Money.Text.Trim() != "") || (this.cboPayMode2.SelectedIndex == 0 && this.txtPayMode2Money.Text.Trim() != ""))
                //{
                //    return;
                //}

                if (e.RowIndex != CurrRow)
                {
                    HitTimes = 1;
                    CurrRow = e.RowIndex;
                }
                else
                {
                    HitTimes++;
                }

                if (e.ColumnIndex == 0)
                {
                    if (HitTimes == 1)
                    {
                        BlnChecked = this.dgPrePay.Rows[CurrRow].Cells[0].Value.ToString().ToUpper() == "T" ? false : true;
                    }
                    else if (HitTimes > 1)
                    {
                        BlnChecked = !BlnChecked;
                    }

                    this.dgPrePay.Rows[CurrRow].Cells["colSelectBool"].Value = BlnChecked == true ? "T" : "F";

                    if (BlnChecked)
                    {
                        this.dgPrePay.Rows[CurrRow].Cells["colStrikeBal"].Value = "冲";
                        this.dgPrePay.Rows[CurrRow].DefaultCellStyle.BackColor = Color.FromArgb(0, 200, 0);
                    }
                    else
                    {
                        this.dgPrePay.Rows[CurrRow].Cells["colStrikeBal"].Value = "";
                        this.dgPrePay.Rows[CurrRow].DefaultCellStyle.BackColor = Color.White;
                    }

                    if (e.RowIndex == (this.dgPrePay.Rows.Count - 1))
                    {
                        SendKeys.Send("{UP}");
                    }
                    else
                    {
                        SendKeys.Send("{ENTER}");
                    }

                    ((clsCtl_Reckoning)this.objController).m_mthSetPrepay();
                }
            }
        }

        private void dgPrePay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                //if ((this.cboPayMode1.SelectedIndex == 0 && this.txtPayMode1Money.Text.Trim() != "") || (this.cboPayMode2.SelectedIndex == 0 && this.txtPayMode2Money.Text.Trim() != ""))
                //{
                //    return;
                //}

                string ischecked = this.dgPrePay.Rows[row].Cells[0].Value.ToString() == "T" ? "F" : "T";
                this.dgPrePay.Rows[row].Cells[0].Value = ischecked;
                this.dgPrePay.Rows[row].Cells["colSelectBool"].Value = ischecked;

                if (ischecked == "T")
                {
                    this.dgPrePay.Rows[row].Cells["colStrikeBal"].Value = "冲";
                    //this.dgPrePay.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    this.dgPrePay.Rows[row].Cells["colStrikeBal"].Value = "";
                    //this.dgPrePay.Rows[row].DefaultCellStyle.ForeColor = Color.Black;
                }

                ((clsCtl_Reckoning)this.objController).m_mthSetPrepay();
            }
        }

        private void btnYB_Click(object sender, EventArgs e)
        {
            ((clsCtl_Reckoning)this.objController).m_mthYB(false);
        }

        private void txtPayMode1Money_Leave(object sender, EventArgs e)
        {
            if (this.txtPayMode1Money.Text.Trim() == "")
            {
                ((clsCtl_Reckoning)this.objController).m_mthReSetPrepay();
            }
        }

        private void chkAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPayMode1Money.Text = "";
            this.txtPayMode2Money.Text = "";

            if (this.chkAllSelect.Checked)
            {
                ((clsCtl_Reckoning)this.objController).m_mthAllSelectPrepay();
            }
            else
            {
                ((clsCtl_Reckoning)this.objController).m_mthReSetPrepay();
            }
        }

        private void btnNewYB_Click(object sender, EventArgs e)
        {
            ((clsCtl_Reckoning)this.objController).m_mthYB(true);
        }
    }
}