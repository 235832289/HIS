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
    /// 检验科外送项目统计
    /// </summary>
    public partial class frmRptLisOutside : Form
    {
        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public frmRptLisOutside()
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
            this.dwRep.DataWindowObject = "d_lis_outsidesum";
            this.cboType.SelectedIndex = 0;
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
                // 0 汇总; 1 明细
                int flagId = this.cboType.SelectedIndex;
                this.dwRep.SetRedrawOff();
                this.dwRep.Reset();
                clsPublic.PlayAvi("数据统计中，请稍候...");

                #region 构造表
                DataTable dtRpt = new DataTable();
                dtRpt.Columns.Add("patientId", typeof(string));
                dtRpt.Columns.Add("patName", typeof(string));
                dtRpt.Columns.Add("chargeDate", typeof(string));
                dtRpt.Columns.Add("orderDicId", typeof(string));
                dtRpt.Columns.Add("orderName", typeof(string));
                dtRpt.Columns.Add("orderPrice", typeof(string));
                dtRpt.Columns.Add("orderQty", typeof(string));
                dtRpt.Columns.Add("orderTotal", typeof(string));
                dtRpt.Columns.Add("outSideUnit", typeof(string));
                dtRpt.Columns.Add("cardNo", typeof(string));
                dtRpt.Columns.Add("ipNo", typeof(string));
                dtRpt.Columns.Add("deptName", typeof(string));
                dtRpt.Columns.Add("doctName", typeof(string));
                #endregion

                clsDcl_Report rpt = new clsDcl_Report();
                DataTable dtCharge = rpt.GetOutsideChargeItem(beginDate, endDate);
                rpt = null;

                string outsideUnit = string.Empty;
                string patientId = string.Empty;
                string chargeDate = string.Empty;
                string orderDicId = string.Empty;
                string orderPrice = string.Empty;
                string deptName = string.Empty;
                string doctName = string.Empty;
                DataRow[] drr = null;
                int rowIndex = 0;

                #region 汇总

                if (flagId == 0 && dtCharge != null && dtCharge.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCharge.Rows)
                    {
                        outsideUnit = dr["outsideunit"].ToString();
                        orderDicId = dr["orderdicid_chr"].ToString();
                        orderPrice = dr["orderPrice"].ToString();
                        drr = dtRpt.Select(string.Format("outSideUnit = '{0}' and orderDicId = '{1}' and orderPrice = '{2}'", outsideUnit, orderDicId, orderPrice));
                        if (drr == null || drr.Length == 0)
                        {
                            DataRow dr2 = dtRpt.NewRow();
                            dr2["outSideUnit"] = dr["outsideunit"];
                            dr2["orderDicId"] = orderDicId;
                            dr2["orderName"] = dr["orderName"];
                            dr2["orderPrice"] = orderPrice;
                            dr2["orderQty"] = dr["orderQty"];
                            dr2["orderTotal"] = dr["orderTotal"];
                            dtRpt.Rows.Add(dr2.ItemArray);
                        }
                        else
                        {
                            drr[0]["orderQty"] = Convert.ToString(Convert.ToDecimal(drr[0]["orderQty"]) + Convert.ToDecimal(dr["orderQty"]));
                            drr[0]["orderTotal"] = Convert.ToString(Convert.ToDecimal(drr[0]["orderTotal"]) + Convert.ToDecimal(dr["orderTotal"]));
                        }
                        dtRpt.AcceptChanges();
                    }
                    if (dtRpt.Rows.Count > 0)
                    {
                        decimal orderTotal = 0;
                        Dictionary<string, decimal> dicRpt = new Dictionary<string, decimal>();
                        foreach (DataRow dr3 in dtRpt.Rows)
                        {
                            outsideUnit = dr3["outsideunit"].ToString();
                            orderTotal = Convert.ToDecimal(dr3["orderTotal"].ToString());
                            if (dicRpt.ContainsKey(outsideUnit))
                            {
                                dicRpt[outsideUnit] += orderTotal;
                            }
                            else
                            {
                                dicRpt.Add(outsideUnit, orderTotal);
                            }
                        }

                        DataView dv = new DataView(dtRpt);
                        dv.Sort = "outSideUnit asc, orderName asc";
                        DataTable dtTmp = dv.ToTable();
                        foreach (DataRow dr3 in dtTmp.Rows)
                        {
                            outsideUnit = dr3["outsideunit"].ToString();
                            // 外送检验中心	检验项目	单价	数量	单项合计	外送检验中心合计
                            rowIndex = this.dwRep.InsertRow();
                            this.dwRep.SetItemString(rowIndex, "col1", outsideUnit);
                            this.dwRep.SetItemString(rowIndex, "col2", dr3["orderName"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col3", dr3["orderPrice"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col4", dr3["orderQty"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col5", dr3["orderTotal"].ToString());
                            if (dicRpt.ContainsKey(outsideUnit))
                                this.dwRep.SetItemString(rowIndex, "col6", dicRpt[outsideUnit].ToString("0.00"));
                        }
                    }
                }
                #endregion

                #region 明细

                if (flagId == 1 && dtCharge != null && dtCharge.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCharge.Rows)
                    {
                        chargeDate = Convert.ToDateTime(dr["recipeDate"]).ToString("yyyy-MM-dd");
                        patientId = dr["pid"].ToString();
                        orderDicId = dr["orderdicid_chr"].ToString();
                        orderPrice = dr["orderPrice"].ToString();
                        deptName = dr["deptName"].ToString();
                        doctName = dr["doctName"].ToString();
                        object[] objs = new object[6];
                        objs[0] = chargeDate;
                        objs[1] = patientId;
                        objs[2] = orderDicId;
                        objs[3] = orderPrice;
                        objs[4] = deptName;
                        objs[5] = doctName;
                        drr = dtRpt.Select(string.Format("chargeDate = '{0}' and patientId = '{1}' and orderDicId = '{2}' and orderPrice = '{3}' and deptName = '{4}' and doctName = '{5}'", objs));
                        if (drr == null || drr.Length == 0)
                        {
                            DataRow dr2 = dtRpt.NewRow();
                            dr2["patientId"] = patientId;
                            dr2["patName"] = dr["patName"];
                            dr2["chargeDate"] = chargeDate;
                            dr2["orderDicId"] = orderDicId;
                            dr2["orderName"] = dr["orderName"];
                            dr2["orderPrice"] = orderPrice;
                            dr2["orderQty"] = dr["orderQty"];
                            dr2["orderTotal"] = dr["orderTotal"];
                            dr2["outSideUnit"] = dr["outsideunit"];
                            dr2["cardNo"] = dr["cardNo"];
                            dr2["ipNo"] = dr["ipNo"];
                            dr2["deptName"] = deptName;
                            dr2["doctName"] = doctName;
                            dtRpt.Rows.Add(dr2.ItemArray);
                        }
                        else
                        {
                            drr[0]["orderQty"] = Convert.ToString(Convert.ToDecimal(drr[0]["orderQty"]) + Convert.ToDecimal(dr["orderQty"]));
                            drr[0]["orderTotal"] = Convert.ToString(Convert.ToDecimal(drr[0]["orderTotal"]) + Convert.ToDecimal(dr["orderTotal"]));
                        }
                        dtRpt.AcceptChanges();
                    }
                    if (dtRpt.Rows.Count > 0)
                    {
                        DataView dv = new DataView(dtRpt);
                        dv.Sort = "chargeDate asc, orderName asc";
                        DataTable dtTmp = dv.ToTable();
                        foreach (DataRow dr3 in dtTmp.Rows)
                        {
                            // 检验日期	姓名	就诊号	住院号	科室 	医生	检验项目	价格	小计
                            rowIndex = this.dwRep.InsertRow();
                            this.dwRep.SetItemString(rowIndex, "col1", dr3["chargeDate"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col2", dr3["patName"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col3", dr3["cardNo"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col4", dr3["ipNo"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col5", dr3["deptName"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col6", dr3["doctName"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col7", dr3["orderName"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col8", dr3["orderPrice"].ToString());
                            this.dwRep.SetItemString(rowIndex, "col9", dr3["orderTotal"].ToString());
                        }
                    }
                }
                #endregion

                if (dtCharge == null || dtCharge.Rows.Count == 0)
                {
                    MessageBox.Show("查无记录.");
                }
                this.dwRep.Modify("t_date.text='" + beginDate + "至" + endDate + "'");
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

        private void frmRptLisOutside_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboType.SelectedIndex == 0)
            {
                this.dwRep.DataWindowObject = "d_lis_outsidesum";
            }
            else if (this.cboType.SelectedIndex == 1)
            {
                this.dwRep.DataWindowObject = "d_lis_outsidedet";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Stat();
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
