using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 实收明细日志－发票明细UI
    /// </summary>
    public partial class frmRptInvoiceRefundment : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptInvoiceRefundment()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        #region 变量
        private clsCtl_Report objReport;
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();
        /// <summary>
        /// 发票数据集

        /// </summary>
        private DataTable dtInvoice = new DataTable();
        /// <summary>
        /// 支付数据集

        /// </summary>
        private DataTable dtPayment = new DataTable();
        /// <summary>
        /// 报表统计时间
        /// </summary>
        private string reportdate = "";
        #endregion

        #region 生成报表
        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="Flag">1 打印 2 导出</param>
        private void m_mthFillReport(int Flag)
        {
            if (this.dv.Rows.Count == 0)
            {
                return;
            }

            try
            {
                DataStore dsRep = new DataStore();
                dsRep.LibraryList = clsPublic.PBLPath;
                dsRep.DataWindowObject = "d_bih_invoicerefundment";

                //dsRep.Modify("t_title.text = '" + this.HospitalName + "住院实收明细日志(退款)'");
                dsRep.Modify("t_date.text = '" + reportdate + "'");

                for (int i = 0; i < this.dv.Rows.Count; i++)
                {
                    int row = dsRep.InsertRow(0);

                    dsRep.SetItemString(row, "col1", this.dv.Rows[i].Cells["colSky"].Value.ToString());
                    dsRep.SetItemString(row, "col2", this.dv.Rows[i].Cells["colTpsj"].Value.ToString());
                    dsRep.SetItemString(row, "col3", this.dv.Rows[i].Cells["colZyh"].Value.ToString());
                    dsRep.SetItemString(row, "col4", this.dv.Rows[i].Cells["colXm"].Value.ToString());
                    dsRep.SetItemString(row, "col5", this.dv.Rows[i].Cells["colBq"].Value.ToString());
                    dsRep.SetItemString(row, "col6", this.dv.Rows[i].Cells["colJsfs"].Value.ToString());
                    dsRep.SetItemString(row, "col7", this.dv.Rows[i].Cells["colYfph"].Value.ToString());
                    dsRep.SetItemString(row, "col8", this.dv.Rows[i].Cells["colYfpsj"].Value.ToString());
                    dsRep.SetItemString(row, "col9", this.dv.Rows[i].Cells["colYsky"].Value.ToString());
                    dsRep.SetItemDecimal(row, "col16", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colYje"].Value));
                    dsRep.SetItemDecimal(row, "col10", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colYjzje"].Value));
                    dsRep.SetItemDecimal(row, "col11", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colBjxj"].Value));
                    dsRep.SetItemDecimal(row, "col12", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colBjzp"].Value));
                    dsRep.SetItemDecimal(row, "col13", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colBjyhk"].Value));
                    dsRep.SetItemDecimal(row, "col14", clsPublic.ConvertObjToDecimal(this.dv.Rows[i].Cells["colBqt"].Value));
                }

                if (Flag == 1)
                {
                    clsPublic.PrintDialog(dsRep);
                }
                else if (Flag == 2)
                {
                    clsPublic.ExportDataStore(dsRep, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成报表失败。" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }

        #region 调用外部参数
        /// <summary>
        /// 调用外部参数
        /// </summary>
        internal string str_parmval = "";
        public void m_mthShow(string parmval)
        {

            str_parmval = parmval;
            this.Show();
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteRq1.Value.ToString("yyyy-MM-dd"), this.dteRq2.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }

            string OperCode = this.cboOperCode.Text.Trim();

            if (OperCode == "")
            {
                MessageBox.Show("请输入收款员工号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (OperCode.IndexOf("全部") >= 0)
                {
                    OperCode = null;
                }
            }

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            reportdate = BeginDate + " ~ " + EndDate;

            decimal decTotalMoney, decXj, decZp, decYhk, decQt;
            decimal decWx2 = 0;
            decimal decZfb = 0;

            clsPublic.PlayAvi("findFILE.avi", "正在统计退票发票数据，请稍候...");
            this.objReport.m_mthRptInvoiceRefundment(BeginDate, EndDate, OperCode, DeptIDArr, this.dv, out dtInvoice, out dtPayment, out decTotalMoney, out decXj, out decZp, out decYhk, out decQt, out decWx2, out decZfb);
            clsPublic.CloseAvi();

            this.lblTotalMoney.Text = decTotalMoney.ToString("###,##0.00");
            if (decXj > 0)
            {
                this.lblXj.Text = decXj.ToString("###,##0.00");
            }
            if (decZp > 0)
            {
                this.lblZp.Text = decZp.ToString("###,##0.00");
            }
            if (decYhk > 0)
            {
                this.lblYhk.Text = decYhk.ToString("###,##0.00");
            }
            if (decQt > 0)
            {
                this.lblQt.Text = decQt.ToString("###,##0.00");
            }
            if (decWx2 > 0)
            {
                this.lblWx2.Text = decWx2.ToString("###,##0.00");
            }
            if (decZfb > 0)
            {
                this.lblZfb.Text = decZfb.ToString("###,##0.00");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXP5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_mthFillReport(1);
            this.Cursor = Cursors.Default;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_mthFillReport(2);
            this.Cursor = Cursors.Default;
        }

    }
}