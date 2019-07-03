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
    /// 门诊住院退费原因统计
    /// </summary>
    public partial class frmRptInvoiceRefundReason : Form
    {
        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public frmRptInvoiceRefundReason()
        {
            InitializeComponent();
        }
        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.dteRq1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            this.dwRep.LibraryList = Application.StartupPath + "\\pbwindow.pbl";
            this.dwRep.DataWindowObject = "d_invoicerefundreason2";

            this.cboType.SelectedIndex = 0;
            this.dwRep.Modify("t_title.text='门诊退费原因统计表'");
        }
        #endregion

        #region Stat
        /// <summary>
        /// Stat
        /// </summary>
        void Stat()
        {
            string beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string endDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(beginDate + " 00:00:01") > Convert.ToDateTime(endDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int flagId = this.cboType.SelectedIndex + 1;
                this.dwRep.SetRedrawOff();
                this.dwRep.Reset();
                clsPublic.PlayAvi("数据查询中，请稍候...");
                clsDcl_Charge dclCharge = new clsDcl_Charge();
                DataTable dtList = dclCharge.GetRefundReasonList(flagId);
                dclCharge = null;
                clsDcl_Report rpt = new clsDcl_Report();
                DataTable dtResult = rpt.GetRptInvoiceRefundReason(flagId, beginDate, endDate);
                rpt = null;
                int countXj = 0;
                decimal sumHj = 0;
                foreach (DataRow dr in dtList.Rows)
                {
                    int rowIndex = this.dwRep.InsertRow();
                    string reason = dr["freason"].ToString();
                    this.dwRep.SetItemString(rowIndex, "col1", dr["fno"].ToString());
                    this.dwRep.SetItemString(rowIndex, "col2", reason);

                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        DataView dv = new DataView(dtResult);
                        dv.RowFilter = string.Format("reason = '{0}'", reason);
                        if (dv.Count > 0)
                        {
                            decimal mny = 0;
                            this.dwRep.SetItemString(rowIndex, "col3", dv.Count.ToString());
                            for (int i = 0; i < dv.Count; i++)
                            {
                                mny += Math.Abs(clsPublic.ConvertObjToDecimal(dv[i]["invomny"]));
                            }
                            this.dwRep.SetItemString(rowIndex, "col4", mny.ToString("0.00"));

                            countXj += dv.Count;
                            sumHj += mny;
                        }
                    }
                }

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    #region bak
                    /*
                    int no = 0;
                    int rowIndex = 0;
                    string flagId = string.Empty;
                    string flagName = string.Empty;
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        flagId = dr["flagid"].ToString();
                        if (flagId == "1")
                            flagName = "门诊";
                        else if (flagId == "2")
                            flagName = "住院";
                        else if (flagId == "3")
                            flagName = "预交金";

                        rowIndex = this.dwRep.InsertRow();
                        this.dwRep.SetItemString(rowIndex, "col1", Convert.ToString(++no));
                        this.dwRep.SetItemString(rowIndex, "col2", flagName);
                        this.dwRep.SetItemString(rowIndex, "col3", dr["invono"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col4", dr["invomny"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col5", Convert.ToDateTime(dr["operdate"].ToString()).ToString("yyyy-MM-dd HH:mm"));
                        this.dwRep.SetItemString(rowIndex, "col6", dr["patno"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col7", dr["patname"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col8", dr["sex"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col9", dr["birth_dat"] == DBNull.Value ? "" : clsCalculateAge.s_strCalAge(Convert.ToDateTime(dr["birth_dat"].ToString())));
                        this.dwRep.SetItemString(rowIndex, "col10", dr["deptname"].ToString());
                        this.dwRep.SetItemString(rowIndex, "col11", dr["reason"].ToString());
                    } 
                    if (this.dwRep.RowCount == 0)
                    {
                        MessageBox.Show("查无记录.");
                    }*/
                    #endregion
                }
                else
                {
                    MessageBox.Show("查无记录.");
                }
                this.dwRep.Modify("t_date.text='" + beginDate + "至" + endDate + "'");
                if (countXj > 0)
                {
                    this.dwRep.Modify("t_sum_xj.text='" + countXj + "'");
                    this.dwRep.Modify("t_sum_hj.text='" + sumHj.ToString("0.00") + "'");
                }
                else
                {
                    this.dwRep.Modify("t_sum_xj.text=''");
                    this.dwRep.Modify("t_sum_hj.text=''");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                clsPublic.CloseAvi();
                this.dwRep.SetRedrawOn();
                this.dwRep.Refresh();
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmRptInvoiceRefundReason_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Stat();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboType.SelectedIndex == 0)
                this.dwRep.Modify("t_title.text='门诊退费原因统计表'");
            else if (this.cboType.SelectedIndex == 1)
                this.dwRep.Modify("t_title.text='住院退费原因统计表'");
            else if (this.cboType.SelectedIndex == 2)
                this.dwRep.Modify("t_title.text='预交金退费原因统计表'");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
