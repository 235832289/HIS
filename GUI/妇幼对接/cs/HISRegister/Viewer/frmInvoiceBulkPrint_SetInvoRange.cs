using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    internal partial class frmInvoiceBulkPrint_SetInvoRange : Form
    {
        public List<string> NewRePrintInvoList = new List<string>();
        private long m_lngPrintNeedInvoCount = 0;
        private string m_strHospitalId = string.Empty;
        private string m_strEmpID = string.Empty;

        public frmInvoiceBulkPrint_SetInvoRange(string p_strHospitalId,string p_strEmpID, string p_strEmpName, long p_lngPrintNeedInvoCount)
        {
            InitializeComponent();
            this.m_strHospitalId = p_strHospitalId;
            this.m_strEmpID = p_strEmpID;
            this.lblName.Text = p_strEmpName;
            this.m_lngPrintNeedInvoCount = p_lngPrintNeedInvoCount;
        }

        private void frmInvoiceBulkPrint_SetInvoRange_Load(object sender, EventArgs e)
        {
            //if (clsOpdInvoice.InvoUseNumeralOnly)
            //{
            //    this.label2.Visible = false;
            //    txtP2.Visible = false;
            //}
            //txtMinNo.MaxLength = clsOpdInvoice.InvoNumeralMaxLength;
            //txtMaxNo.MaxLength = clsOpdInvoice.InvoNumeralMaxLength;
        }

        private void frmInvoiceBulkPrint_SetInvoRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.btnOK_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(null, null);
            }
        }

        private void txtP2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtMinNo.Focus();
            }
        }

        private void txtMinNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtMaxNo.Focus();
            }
        }

        private void txtMaxNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void m_mthSetInvoCount()
        {
            lblInvoCount.Text = "";
            lblInvoCount.Tag = null;
            long lngInvoCount = 0;
            try
            {
                string strMinNo = txtMinNo.Text.Trim();
                string strMaxNo = txtMaxNo.Text.Trim();
                if (strMinNo != "" && strMaxNo != "")
                {
                    long lngMaxNo = Convert.ToInt64(strMaxNo);
                    long lngMinNo = Convert.ToInt64(strMinNo);
                    if (lngMaxNo != 0 && lngMinNo != 0)
                    {
                        lngInvoCount = lngMaxNo - lngMinNo + 1;
                    }
                }
            }
            catch
            {
                lngInvoCount = 0;
            }
            if (lngInvoCount > 0)
            {
                lblInvoCount.Text = "发票张数: " + lngInvoCount.ToString();
                lblInvoCount.Tag = lngInvoCount;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.NewRePrintInvoList.Clear();
            string strP2 = "";
            bool blnContainsChar = this.txtP2.Visible;

            if (blnContainsChar)
            {
                strP2 = this.txtP2.Text.Trim();
                if (strP2 == string.Empty || strP2.Length != 2)
                {
                    MessageBox.Show("发票号码前面两字母输入不正确，请重新输入。");//need modify
                    this.txtP2.Focus();
                    this.txtP2.SelectAll();
                    return;
                }
            }

            string strMinNo = this.txtMinNo.Text.Trim();

            //if (strMinNo == string.Empty || strMinNo.Length != clsOpdInvoice.InvoNumeralMaxLength || !iCare.Opd.Base.Gui.clsOpdPublic.m_blnIsNumber(strMinNo))
            if (strMinNo == string.Empty)
            {
                MessageBox.Show("最小发票号码输入不正确，请重新输入。");
                this.txtMinNo.Focus();
                this.txtMinNo.SelectAll();
                return;
            }

            string strMaxNo = this.txtMaxNo.Text.Trim();

            if (strMaxNo == string.Empty)
            {
                MessageBox.Show("最大发票号码输入不正确，请重新输入。");
                this.txtMaxNo.Focus();
                this.txtMaxNo.SelectAll();
                return;
            }

            if (ConvertObjToDecimal(strMinNo) > ConvertObjToDecimal(strMaxNo))
            {
                MessageBox.Show("最小发票号码不能大于最大发票号码，请重新输入。");
                this.txtMaxNo.Focus();
                this.txtMaxNo.SelectAll();
                return;
            }

            long lngInvoCount = 0;
            try
            {
                lngInvoCount = Convert.ToInt64(lblInvoCount.Tag.ToString());
            }
            catch
            {
                lngInvoCount = 0;
            }
            if (lngInvoCount == 0)
            {
                MessageBox.Show("设置的发票张数为0，请重新输入。");
                this.txtMinNo.Focus();
                this.txtMinNo.SelectAll();
                return;
            }

            //if (!clsOpdInvoice.m_blnIsInvoScopeInAssignRange(blnContainsChar, m_strEmpID, strP2 + strMinNo, strP2 + strMaxNo))
            //{//验证是否在分配的发票段中
            //    this.txtMinNo.Focus();
            //    this.txtMinNo.SelectAll();
            //    return;
            //}

            if (this.m_lngPrintNeedInvoCount > lngInvoCount)
            {
                if (MessageBox.Show("设置的发票数(" + lngInvoCount + ")少于需要打印的发票数(" + this.m_lngPrintNeedInvoCount + ")，只能按顺序打印" + lngInvoCount + "张发票。\r\n\r\n是否继续?","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    this.txtMinNo.Focus();
                    this.txtMinNo.SelectAll();
                    return;
                }
                this.m_lngPrintNeedInvoCount = lngInvoCount;
            }

            try
            {
                clsOPChargeQuerySvc objInvo = new clsOPChargeQuerySvc();
                long lngMinInvo = Convert.ToInt64(txtMinNo.Text.Trim());
                for (long i1 = 0; i1 < this.m_lngPrintNeedInvoCount; i1++)
                {
                    string strNewRePrintInvo = strP2 + (lngMinInvo + i1).ToString().PadLeft(8, '0');
                    if (objInvo.m_blnCheckInvoice(strNewRePrintInvo))
                    {
                        MessageBox.Show("设置的发票段中存在已被使用的发票号(" + strNewRePrintInvo + ")，请重新输入。");
                        this.txtMinNo.Focus();
                        this.txtMinNo.SelectAll();
                        this.NewRePrintInvoList.Clear();
                        return;
                    }
                    this.NewRePrintInvoList.Add(strNewRePrintInvo);
                }
            }
            catch
            {
                this.NewRePrintInvoList.Clear();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.NewRePrintInvoList.Clear();
            this.Close();
        }

        private void frmInvoiceBulkPrint_SetInvoRange_Shown(object sender, EventArgs e)
        {
            if (this.txtP2.Visible)
            {
                this.txtP2.Focus();
            }
            else
            {
                this.txtMinNo.Focus();
            }
        }

        private void txtMinNo_Leave(object sender, EventArgs e)
        {
            m_mthSetInvoCount();
        }

        private void txtMaxNo_Leave(object sender, EventArgs e)
        {
            m_mthSetInvoCount();
        }

        #region 转换成数字
        private decimal ConvertObjToDecimal(object obj)
        {
            if (obj != null && obj.ToString() != "")
            {
                return Convert.ToDecimal(obj.ToString());

            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
