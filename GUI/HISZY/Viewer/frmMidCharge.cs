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
    /// 中途(项目)结算UI
    /// </summary>
    public partial class frmMidCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmMidCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_MidCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 发票号检查失败直接退出标志
        /// </summary>
        private bool noopen = false;

        /// <summary>
        /// 当前收费员.发票号
        /// </summary>
        internal string InvoNo { get; set; }

        private void frmMidCharge_Load(object sender, EventArgs e)
        {
            #region 读出发票号
            bool b = false;
            string invono = clsPublic.m_strGetCurrInvoiceNo(this.LoginInfo.m_strEmpID, 1);
            frmIPInvoiceinput fo = new frmIPInvoiceinput();
            fo.txtInvono.Text = invono;
            this.Visible = false;
            this.timerInvo.Enabled = false;
            if (fo.ShowDialog() == DialogResult.Cancel)
            {
                b = true;
            }
            else
            {
                #region 发票号检验
                invono = fo.txtInvono.Text.Trim();
                if (!clsPublic.m_blnCheckInvoExpression(invono))
                {
                    MessageBox.Show("输入的发票号不符合规定的发票号规则，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                if (clsPublic.m_blnCheckInvoIsUsed(invono))
                {
                    MessageBox.Show("输入的发票号已经被使用，请修改。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                #endregion
            }

            if (b)
            {
                noopen = true;
                this.timerInvo.Enabled = true;
                this.timerInvo.Interval = 3000;
                return;
            }
            else
            {
                this.InvoNo = invono;
                this.timerInvo.Enabled = true;
                this.timerInvo.Interval = 1000;
                this.Cursor = Cursors.WaitCursor;
            }
            #endregion

            clsPublic.SuspendLayout(ucPatientInfo.Handle);
            this.ucPatientInfo.Status = 1;
            this.rdoZq.Checked = true;
            this.timer.Enabled = true;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_MidCharge)this.objController).m_mthReset();
                ((clsCtl_MidCharge)this.objController).m_mthGetDayaccountsInfo();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthFind();
        }

        private void frmMidCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthShortCut(e);
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_MidCharge)this.objController).m_mthReset();
                ((clsCtl_MidCharge)this.objController).m_mthGetDayaccountsInfo();
            }
        }

        /// <summary>
        /// 当前行
        /// </summary>
        private int CurrRow = -1;  
        private int HitTimes = 0;
        private bool BlnChecked = false;
        private void dtgMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                if (e.RowIndex != CurrRow)
                {
                    HitTimes = 1;
                    CurrRow = e.RowIndex;
                    ((clsCtl_MidCharge)this.objController).m_mthGetAccountsDetail(CurrRow);                   
                }
                else
                {
                    HitTimes++;
                }

                if (e.ColumnIndex == 0)
                {
                    if (this.dtgMain.Rows[CurrRow].Cells[0].ReadOnly)
                    {
                        return;
                    }

                    if (HitTimes == 1)
                    {
                        BlnChecked = this.dtgMain.Rows[CurrRow].Cells[0].Value.ToString().ToUpper() == "T" ? false : true;
                    }
                    else if (HitTimes > 1)
                    {
                        BlnChecked = !BlnChecked;
                    }

                    for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                    {
                        this.dtgDetail.Rows[i].Cells[0].Value = BlnChecked == true ? "T" : "F";
                    }

                    if (e.RowIndex == (this.dtgMain.Rows.Count - 1))
                    {
                        SendKeys.Send("{UP}");
                    }
                    else
                    {
                        SendKeys.Send("{ENTER}");
                    }

                    ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(1);
                }                                
            }
        }

        private void dtgMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrRow >= 0)
            {
                if (this.dtgMain.Rows[CurrRow].Cells[0].ReadOnly)
                {
                    return;
                }

                string ischecked = this.dtgMain.Rows[CurrRow].Cells[0].Value.ToString() == "T" ? "F" : "T";
                this.dtgMain.Rows[CurrRow].Cells[0].Value = ischecked;
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {
                    this.dtgDetail.Rows[i].Cells[0].Value = ischecked;
                }

                ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(1);                
            }
        }

        private void rdoZq_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoZq.Checked)
            {                
                ((clsCtl_MidCharge)this.objController).intType = 1;
                for (int i = 0; i < this.dtgMain.Rows.Count; i++)
                {
                    DataRow dr = (DataRow)this.dtgMain.Rows[i].Tag;
                    if (dr["charge_dec"].ToString() == dr["clearchg_dec"].ToString())
                    {
                        this.dtgMain.Rows[i].Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        this.dtgMain.Rows[i].Cells[0].ReadOnly = false;
                    }
                    this.dtgMain.Rows[i].Cells[0].Value = "F";
                }
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {
                    this.dtgDetail.Rows[i].Cells[0].ReadOnly = true;                    
                    this.dtgDetail.Rows[i].Cells[0].Value = "F";
                }
                ((clsCtl_MidCharge)this.objController).m_mthReset();
            }
        }

        private void rdoMx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoMx.Checked)
            {
                ((clsCtl_MidCharge)this.objController).intType = 2;
                for (int i = 0; i < this.dtgMain.Rows.Count; i++)
                {
                    this.dtgMain.Rows[i].Cells[0].ReadOnly = true;
                    this.dtgMain.Rows[i].Cells[0].Value = "F";
                }
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {

                    DataRowView drv = (DataRowView)this.dtgDetail.Rows[i].Tag;
                    if (drv["pstatus_int"].ToString() == "3")
                    {
                        this.dtgDetail.Rows[i].Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        this.dtgDetail.Rows[i].Cells[0].ReadOnly = false;
                    }
                    this.dtgDetail.Rows[i].Cells[0].Value = "F";
                }
                ((clsCtl_MidCharge)this.objController).m_mthReset();
            }
        }

        private void dtgDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                if (this.dtgDetail.Rows[row].Cells[0].ReadOnly)
                {
                    return;
                }

                string ischecked = this.dtgDetail.Rows[row].Cells[0].Value.ToString() == "T" ? "F" : "T";
                this.dtgDetail.Rows[row].Cells[0].Value = ischecked;

                ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(2); 
            }
        }              

        private void dtgDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {                          
                if (e.ColumnIndex == 0)
                {
                    if (this.dtgDetail.Rows[e.ColumnIndex].Cells[0].ReadOnly)
                    {
                        return;
                    }
                    SendKeys.Send("{ENTER}");

                    ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(2);
                }
            }
        }

        private void dtgDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(2);
            }
        }

        private void dtgMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ((clsCtl_MidCharge)this.objController).m_mthGetCheckType(1);
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (this.ucPatientInfo.RegisterID == "")
            {
                MessageBox.Show("请先查找出病人。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              
            }
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthCharge();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthAllSelect();
        }

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshData()
        {
            this.ucPatientInfo.m_mthShortCurFind();            
        }
        #endregion

        private void btnRepeatPrt_Click(object sender, EventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthRepeatPrt();
        }

        private void btnRefundment_Click(object sender, EventArgs e)
        {
            ((clsCtl_MidCharge)this.objController).m_mthRefundment();
        }

        private void frmMidCharge_Activated(object sender, EventArgs e)
        {
            
        }

        private void rdoMix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoMix.Checked)
            {
                ((clsCtl_MidCharge)this.objController).m_mthChargeMix();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            clsPublic.ResumeLayout(ucPatientInfo.Handle);
            ucPatientInfo.Invalidate();
            ucPatientInfo.Refresh();
        }

        private void timerInvo_Tick(object sender, EventArgs e)
        {
            if (noopen)
            {
                foreach (Form f in this.MdiParent.MdiChildren)
                {
                    f.WindowState = FormWindowState.Maximized;
                }
                this.MdiParent.Refresh();
                this.Close();
            }
            else
            {
                this.timerInvo.Enabled = false;
                this.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}