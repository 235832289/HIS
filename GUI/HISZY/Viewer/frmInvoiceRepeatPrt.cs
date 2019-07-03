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
    /// 发票号重打UI类
    /// </summary>
    public partial class frmInvoiceRepeatPrt : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        private string RegID = "";
        /// <summary>
        /// 当前结算号
        /// </summary>
        private string CurrChargeNo = "";
        /// <summary>
        /// 当前发票号
        /// </summary>
        private string CurrInvoNo = "";
        /// <summary>
        /// 重打发票号
        /// </summary>
        private string RepeatPrtInvono = "";
        /// <summary>
        /// 完成重打标志
        /// </summary>
        private bool CompletePrt = false;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string HospitalName = "";

        /// <summary>
        /// 构造
        /// </summary>
        public frmInvoiceRepeatPrt(string RegisterID)
        {
            InitializeComponent();

            RegID = RegisterID;
        }

        private void frmInvoiceRepeatPrt_Load(object sender, EventArgs e)
        {
            int isOpen = clsPublic.m_intGetSysParm("1145");
            if (isOpen == 0)
            {
                dwInvoice.LibraryList = clsPublic.PBLPath;
                dwInvoice.DataWindowObject = "d_invoice";
            }
            else
            {
                dwInvoice.LibraryList = Application.StartupPath + @"\pb_Invioce.pbl";
                dwInvoice.DataWindowObject = "d_invoice_gd";
            }
            int intDiffCostOn = clsPublic.m_intGetSysParm("9002");//让利开关
            if (intDiffCostOn == 1)
            {
                dwInvoice.LibraryList = Application.StartupPath + @"\pb_Invioce.pbl";
                dwInvoice.DataWindowObject = "d_invoice_gd_diff";
            }

            dwInvoice.InsertRow(0);

            clsCtl_Report objReport = new clsCtl_Report();
            this.HospitalName = objReport.HospitalName;
            objReport = null;

            this.m_mthShowInvonoInfo();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 根据入院登记ID显示发票号记录信息
        /// <summary>
        /// 根据入院登记ID显示发票号记录信息
        /// </summary>
        private void m_mthShowInvonoInfo()
        {
            DataTable dt;

            clsDcl_Charge objCharge = new clsDcl_Charge();
            long l = objCharge.m_lngGetInvoiceInfoByRegID(RegID, 2, out dt);

            if (l > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.lsvInvoice.BeginUpdate();
                this.lsvInvoice.Items.Clear();

                Hashtable has = new Hashtable();

                DataView dv = new DataView(dt);
                dv.Sort = "invono asc";

                foreach (DataRowView drv in dv)
                {
                    string invono = drv["invono"].ToString();

                    if (!has.ContainsKey(invono))
                    {
                        has.Add(invono, drv);
                    }
                    else
                    {
                        if (drv["status_int"].ToString() == "2")
                        {
                            has[invono] = drv;
                        }
                    }
                }

                ArrayList invoarr = new ArrayList();
                invoarr.AddRange(has.Values);

                for (int i = 0; i < invoarr.Count; i++)
                {
                    DataRowView drv = invoarr[i] as DataRowView;

                    ListViewItem lvitem = new ListViewItem();

                    string status = drv["status"].ToString().Trim();
                    if (status == "0")
                    {
                        status = "作废";
                    }
                    else if (status == "1")
                    {
                        status = "正常";
                    }
                    else if (status == "2")
                    {
                        status = "退票";
                    }
                    else if (status == "3")
                    {
                        status = "恢复";
                    }
                    else if (status == "999")
                    {
                        status = "重打";
                    }

                    lvitem.SubItems.Add(status);


                    lvitem.SubItems.Add(drv["invono"].ToString());

                    lvitem.ImageIndex = 0;
                    lvitem.Tag = drv;
                    this.lsvInvoice.Items.Add(lvitem);
                }

                this.lsvInvoice.EndUpdate();
                this.Cursor = Cursors.Default;
            }

        }
        #endregion

        private void lsvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvInvoice.SelectedItems.Count > 0)
            {
                DataRowView drv = this.lsvInvoice.SelectedItems[0].Tag as DataRowView;
                CurrChargeNo = drv["chargeno"].ToString();

                if (drv["status"].ToString() == "999")
                {
                    CurrInvoNo = drv["sourceinvono"].ToString();
                    RepeatPrtInvono = drv["invono"].ToString();
                    CompletePrt = true;
                }
                else
                {
                    CurrInvoNo = drv["invono"].ToString();
                    RepeatPrtInvono = "";
                    CompletePrt = false;
                }

                clsPBNetPrint.m_mthPreviewInvoiceBill(CurrChargeNo, RepeatPrtInvono, dwInvoice, 2, this.HospitalName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CurrChargeNo != "")
            {
                if (RepeatPrtInvono != "" && CompletePrt == false)
                {
                    clsDcl_PrePay objPrePay = new clsDcl_PrePay();
                    long l = objPrePay.m_lngSaveRepeatPrn(CurrChargeNo, CurrInvoNo, RepeatPrtInvono, this.LoginInfo.m_strEmpID, "2");
                    if (l == 0)
                    {
                        MessageBox.Show("保存发票重打记录失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    clsPublic.m_blnSaveCurrInvoiceNo(this.LoginInfo.m_strEmpID, RepeatPrtInvono, 1);
                }

                clsPBNetPrint.m_mthPrintInvoiceBill(CurrChargeNo, RepeatPrtInvono, 2, this.HospitalName);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (CurrInvoNo == "")
            {
                MessageBox.Show("请先在左侧列表中选中重打的发票号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                frmInvoiceRepeatPrtInput f = new frmInvoiceRepeatPrtInput(CurrInvoNo);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    RepeatPrtInvono = f.NewInvoNo;
                    clsPBNetPrint.m_mthPreviewInvoiceBill(CurrChargeNo, RepeatPrtInvono, dwInvoice, 2, this.HospitalName);
                }
            }
        }

        private void frmInvoiceRepeatPrt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}