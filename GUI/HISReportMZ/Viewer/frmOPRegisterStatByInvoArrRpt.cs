using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmOPRegisterStatByInvoArrRpt : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段
        /// <summary>
        /// 将要跳转的下一个控件

        /// </summary>
        Control m_ctlNext = null;

        /// <summary>
        /// 参与跳转的控件数组

        /// </summary>
        private Control[] m_ctlControlsArr = null;

        /// <summary>
        /// 控件激活标志

        /// </summary>
        private bool m_blnCtlActivate = false;

        
        /// <summary>
        /// 报表类型 "0"日报； "1"月报
        /// </summary>
        internal string m_strStatType = "0";

        /// <summary>
        /// 窗体标题
        /// </summary>
        internal string m_strTitle = string.Empty;

        /// <summary>
        /// 统计数据表

        /// </summary>
        private DataTable m_dtbStat = null;

        /// <summary>
        /// 重打发票数据表

        /// </summary>
        private DataTable m_dtbRePrint = null;

        /// <summary>
        /// 挂号域控制器
        /// </summary>
        private clsDcl_InvoiceManage objDomainCtl = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 默认构造函数

        /// </summary>
        public frmOPRegisterStatByInvoArrRpt()
        {
            InitializeComponent();
            m_ctlControlsArr = new Control[] { m_cboCheckMan };
            //设置控件的Enter事件
            m_mthSetNextControl(ref m_ctlControlsArr);
        }
        #endregion

        #region 事件
        private void frmOPRegisterStatRpt_Load(object sender, EventArgs e)
        {
            dwRpt.LibraryList = Application.StartupPath + "\\pbReport.pbl";
            dwRpt.DataWindowObject = "d_registerstatbyinvoarr_rpt";

            #region 收费员列表

            DataTable dtbMan;
            objDomainCtl = new clsDcl_InvoiceManage();

            objDomainCtl.m_lngGetCheckMan(out dtbMan);
            if (dtbMan != null)
            {
                m_cboCheckMan.Items.Clear();

                if (dtbMan.Rows.Count > 0)
                {
                    this.m_cboCheckMan.Item.Add("全部", "1000");
                    for (int i1 = 0; i1 < dtbMan.Rows.Count; i1++)
                    {
                        this.m_cboCheckMan.Item.Add(dtbMan.Rows[i1]["lastname_vchr"].ToString(), dtbMan.Rows[i1]["balanceemp_chr"].ToString());
                    }
                    this.m_cboCheckMan.SelectedIndex = 0;
                }

            }
            #endregion

            if (m_strStatType == "0")//日报
            {
                labTo.Visible = false;
                //m_endDate.Visible = false;
                //label2.Left = m_endDate.Left;
                m_cboCheckMan.Left = label2.Left + label2.Width + 10;
                m_strTitle = this.objController.m_objComInfo.m_strGetHospitalTitle() + "-门诊收费员日挂号发票统计报表";
                this.Text = this.m_strTitle;
            }
            else
            {
                this.labTo.Visible = true;
                //this.m_endDate.Visible = true;
                //m_beginDate.Value = Convert.ToDateTime(m_beginDate.Value.Year.ToString() + "-" + m_beginDate.Value.Month.ToString() + "-" + "01");
                this.m_strTitle = this.objController.m_objComInfo.m_strGetHospitalTitle() + "-门诊收费员月挂号发票统计报表";
                this.Text = this.m_strTitle;
            }

            //this.dwRpt.Modify("datawindow.print.preview=yes datawindow.print.preview.rulers=yes");

        }

        /// <summary>
        /// 检索按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            string m_strbeginInvo=this.m_txtStartInvo.Text.Trim();
            string m_strendInvo=this.m_txtEndInvo.Text.Trim();
            string opratorId = m_cboCheckMan.SelectItemValue;
            if (opratorId.CompareTo("1000")==0)
                opratorId = string.Empty;
            try
            {
                
                clsPublic.PlayAvi("findfile.avi", "正在进行数据统计，请稍后...");

                objDomainCtl.m_lngGetRegisterStatDataByInvoArr(opratorId, m_strbeginInvo, m_strendInvo, out m_dtbStat);

                objDomainCtl.m_lngGetBillRePrintDataInvoArr(opratorId, m_strbeginInvo, m_strendInvo, out m_dtbRePrint);
                SetDatawindow();
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }


        private void SetDatawindow()
        {
            decimal invoiceCount = 0;
            decimal meneySum = 0;
            decimal meneyOwnexp = 0;
            decimal meneyGovexp = 0;
            decimal decDiscount = 0;

            decimal rpayment_mny = 0;
            decimal dpayment_mny = 0;
            decimal gpayment_mny = 0;
            decimal cpayment_mny = 0;

            decimal rcharge = 0;
            decimal dcharge = 0;
            decimal gcharge = 0;
            decimal ccharge = 0;

            dwRpt.Reset();
            if (m_dtbStat == null || m_dtbStat.Rows.Count == 0)
                return;

            dwRpt.SetRedrawOff();
            string temp;
            ArrayList arrOpratorId = new ArrayList();

            for (int i = 0; i < m_dtbStat.Rows.Count; i++)
            {
                temp = m_dtbStat.Rows[i]["empid_chr"].ToString();
                if (!arrOpratorId.Contains(temp))
                {
                    arrOpratorId.Add(temp);
                }
            }

            for (int i = 0; i < m_dtbRePrint.Rows.Count; i++)
            {
                temp = m_dtbStat.Rows[i]["empid_chr"].ToString();
                if (!arrOpratorId.Contains(temp))
                {
                    arrOpratorId.Add(temp);
                }
            }

            DataView dv = m_dtbStat.DefaultView;
            DataView dvRp = m_dtbRePrint.DefaultView;
            string optName = "";
            string startNo, endNo = "", fwNo;
            int row, status;
            for (int i = 0; i < arrOpratorId.Count; i++)
            {
                temp = arrOpratorId[i].ToString();
                status = 0;
                dv.RowFilter = "empid_chr = '" + temp + "'";
                if (dv.Count > 0)
                {
                    optName = dv[0]["lastname_vchr"].ToString();
                }
                else
                {
                    optName = "";
                }

                #region 重打
                dvRp.RowFilter = "printemp_chr = '" + temp + "'";
                dvRp.Sort = "repprninvono_vchr";
                decimal reprintCount = 0;
                string reprintNo = "";

                for (int i1 = 0; i1 < dvRp.Count; i1++)
                {
                    reprintCount++;
                    reprintNo += dvRp[i1]["repprninvono_vchr"].ToString() + "(" + dvRp[i1]["sourceinvono_vchr"].ToString() + ") ";
                }

                #endregion

                #region 有效发票
                dv.RowFilter = "empid_chr = '" + temp + "' and (flag_int = 1 or flag_int = 2)";
                dv.Sort = "invno_chr";
                if (dv.Count == 0)
                {
                    row = dwRpt.InsertRow(0);

                    dwRpt.SetItemString(row, "status", "正常");
                    dwRpt.SetItemString(row, "status_2", "1");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", 0);
                    dwRpt.SetItemDecimal(row, "money_sum", 0);
                    dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                    dwRpt.SetItemDecimal(row, "money_govexp", 0);
                    dwRpt.SetItemString(row, "operator", optName);
                    dwRpt.SetItemString(row, "invoice_no", " ");
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                }
                else
                {
                    startNo = dv[0]["invno_chr"].ToString();
                    fwNo = startNo;
                    invoiceCount = 1;
                    //合计金额
                    decimal.TryParse(dv[0]["rpayment_mny"].ToString(), out rpayment_mny);
                    decimal.TryParse(dv[0]["dpayment_mny"].ToString(), out dpayment_mny);
                    decimal.TryParse(dv[0]["gpayment_mny"].ToString(), out gpayment_mny);
                    decimal.TryParse(dv[0]["cpayment_mny"].ToString(), out cpayment_mny);

                    meneySum = rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                    //自负金额
                    decimal.TryParse(dv[0]["rcharge"].ToString(), out rcharge);
                    decimal.TryParse(dv[0]["dcharge"].ToString(), out dcharge);
                    decimal.TryParse(dv[0]["gcharge"].ToString(), out gcharge);
                    decimal.TryParse(dv[0]["ccharge"].ToString(), out ccharge);

                    meneyOwnexp = rcharge + dcharge + gcharge + ccharge;

                    //记账金额
                    meneyGovexp = meneySum - meneyOwnexp;

                    for (int i1 = 1; i1 < dv.Count; i1++)
                    {
                        endNo = dv[i1]["invno_chr"].ToString();
                        if (fwNo == endNo)
                        {
                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = meneySum + rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = meneyOwnexp + rcharge + dcharge + gcharge + ccharge;


                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;

                            //meneySum += Convert.ToDecimal(dv[i1]["rpayment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp += Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//自负金额

                        }
                        else if (endNo == GetNextString(fwNo))
                        {
                            fwNo = endNo;
                            invoiceCount++;
                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = meneySum + rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = meneyOwnexp + rcharge + dcharge + gcharge + ccharge;


                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;


                            //meneySum += Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp += Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//自负金额
                            //meneyGovexp = meneySum - meneyOwnexp;
                        }
                        else
                        {
                            endNo = dv[i1 - 1]["invno_chr"].ToString();
                            row = dwRpt.InsertRow(0);
                            if (status == 0)
                            {
                                dwRpt.SetItemString(row, "status", "正常");
                            }
                            status++;
                            dwRpt.SetItemString(row, "status_2", "1");
                            dwRpt.SetItemDecimal(row, "sort_col", row);
                            dwRpt.SetItemDecimal(row, "invoice_count", invoiceCount);
                            dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                            dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                            dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                            dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                            dwRpt.SetItemString(row, "invoice_no", startNo + " - " + endNo);
                            dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                            dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                            startNo = dv[i1]["invno_chr"].ToString();
                            fwNo = startNo;
                            invoiceCount = 1;

                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = rcharge + dcharge + gcharge + ccharge;

                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;

                            //meneySum = Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp = meneySum * decDiscount;//自负金额
                            //meneyGovexp = meneySum - meneyOwnexp;//记账金额

                        }
                    }//for
                    row = dwRpt.InsertRow(0);
                    if (status == 0)
                    {
                        dwRpt.SetItemString(row, "status", "正常");
                    }
                    dwRpt.SetItemString(row, "status_2", "1");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", invoiceCount);
                    dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                    dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                    dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                    dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                    dwRpt.SetItemString(row, "invoice_no", startNo + " - " + endNo);
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                }
                #endregion

                #region 退票

                dv.RowFilter = "empid_chr = '" + temp + "' and flag_int = 3";
                dv.Sort = "invno_chr";
                status = 0;
                if (dv.Count == 0)
                {
                    row = dwRpt.InsertRow(0);

                    dwRpt.SetItemString(row, "status", "退票");
                    dwRpt.SetItemString(row, "status_2", "2");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", 0);
                    dwRpt.SetItemDecimal(row, "money_sum", 0);
                    dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                    dwRpt.SetItemDecimal(row, "money_govexp", 0);
                    dwRpt.SetItemString(row, "operator", optName);
                    //this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", " ");
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                }
                else
                {
                    startNo = dv[0]["invno_chr"].ToString();

                    //合计金额
                    decimal.TryParse(dv[0]["rpayment_mny"].ToString(), out rpayment_mny);
                    decimal.TryParse(dv[0]["dpayment_mny"].ToString(), out dpayment_mny);
                    decimal.TryParse(dv[0]["gpayment_mny"].ToString(), out gpayment_mny);
                    decimal.TryParse(dv[0]["cpayment_mny"].ToString(), out cpayment_mny);

                    meneySum = rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                    //自负金额
                    decimal.TryParse(dv[0]["rcharge"].ToString(), out rcharge);
                    decimal.TryParse(dv[0]["dcharge"].ToString(), out dcharge);
                    decimal.TryParse(dv[0]["gcharge"].ToString(), out gcharge);
                    decimal.TryParse(dv[0]["ccharge"].ToString(), out ccharge);

                    meneyOwnexp = rcharge + dcharge + gcharge + ccharge;


                    //记账金额
                    meneyGovexp = meneySum - meneyOwnexp;



                    //meneySum = Convert.ToDecimal(dv[0]["payment_mny"].ToString());//合计金额
                    //decDiscount = Convert.ToDecimal(dv[0]["discount_dec"].ToString());//折扣比例
                    //meneyOwnexp = meneySum * decDiscount;//自负金额
                    
                    //meneyGovexp = meneySum - meneyOwnexp;//记账金额


                    for (int i1 = 1; i1 < dv.Count; i1++)
                    {
                        endNo = dv[i1]["invno_chr"].ToString();
                        if (startNo == endNo)
                        {
                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = meneySum + rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = meneyOwnexp + rcharge + dcharge + gcharge + ccharge;

                            
                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;

                            //meneySum = meneySum + Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp = meneyOwnexp + Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//自负金额
                            //meneyGovexp = meneyGovexp + (Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) - Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount);//记账金额
                        }
                        else
                        {
                            row = dwRpt.InsertRow(0);
                            if (status == 0)
                            {
                                dwRpt.SetItemString(row, "status", "退票");
                            }
                            status++;
                            dwRpt.SetItemString(row, "status_2", "2");
                            dwRpt.SetItemDecimal(row, "sort_col", row);
                            dwRpt.SetItemDecimal(row, "invoice_count", -1);
                            dwRpt.SetItemDecimal(row, "money_sum", -meneySum);
                            dwRpt.SetItemDecimal(row, "money_ownexp", -meneyOwnexp);
                            dwRpt.SetItemDecimal(row, "money_govexp", -meneyGovexp);
                            dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                            dwRpt.SetItemString(row, "invoice_no", startNo);
                            dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                            dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                            startNo = endNo;

                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = rcharge + dcharge + gcharge + ccharge;


                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;

                            //meneySum = Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp = meneySum * decDiscount;//自负金额
                            //meneyGovexp = meneySum - meneyOwnexp;//记账金额
                        }                        
                    }//for
                    row = dwRpt.InsertRow(0);
                    if (status == 0)
                    {
                        dwRpt.SetItemString(row, "status", "退票");
                    }
                    status++;
                    dwRpt.SetItemString(row, "status_2", "2");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", -1);
                    dwRpt.SetItemDecimal(row, "money_sum", -meneySum);
                    dwRpt.SetItemDecimal(row, "money_ownexp", -meneyOwnexp);
                    dwRpt.SetItemDecimal(row, "money_govexp", -meneyGovexp);
                    dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                    dwRpt.SetItemString(row, "invoice_no", startNo);
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                }
                #endregion

                #region 恢复
                dv.RowFilter = "empid_chr = '" + temp + "' and flag_int = 4";
                dv.Sort = "invno_chr";
                if (dv.Count == 0)
                {
                    row = dwRpt.InsertRow(0);

                    dwRpt.SetItemString(row, "status", "恢复");
                    dwRpt.SetItemString(row, "status_2", "3");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", 0);
                    dwRpt.SetItemDecimal(row, "money_sum", 0);
                    dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                    dwRpt.SetItemDecimal(row, "money_govexp", 0);
                    dwRpt.SetItemString(row, "operator", optName);
                    dwRpt.SetItemString(row, "invoice_no", " ");
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                }
                else
                {
                    status = 0;
                    startNo = dv[0]["invno_chr"].ToString();

                    //合计金额
                    decimal.TryParse(dv[0]["rpayment_mny"].ToString(), out rpayment_mny);
                    decimal.TryParse(dv[0]["dpayment_mny"].ToString(), out dpayment_mny);
                    decimal.TryParse(dv[0]["gpayment_mny"].ToString(), out gpayment_mny);
                    decimal.TryParse(dv[0]["cpayment_mny"].ToString(), out cpayment_mny);

                    meneySum = rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                    //自负金额
                    decimal.TryParse(dv[0]["rcharge"].ToString(), out rcharge);
                    decimal.TryParse(dv[0]["dcharge"].ToString(), out dcharge);
                    decimal.TryParse(dv[0]["gcharge"].ToString(), out gcharge);
                    decimal.TryParse(dv[0]["ccharge"].ToString(), out ccharge);

                    meneyOwnexp = rcharge + dcharge + gcharge + ccharge;

                    //记账金额
                    meneyGovexp = meneySum - meneyOwnexp;


                    //meneySum = Convert.ToDecimal(dv[0]["payment_mny"].ToString());//合计金额
                    //decDiscount = Convert.ToDecimal(dv[0]["discount_dec"].ToString());//折扣比例
                    //meneyOwnexp = meneySum * decDiscount;//自负金额
                    //meneyGovexp = meneySum - meneyOwnexp;//记账金额

                    for (int i1 = 1; i1 < dv.Count; i1++)
                    {
                        endNo = dv[i1]["invno_chr"].ToString();
                        if (startNo == endNo)
                        {
                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum = meneySum + rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = meneyOwnexp + rcharge + dcharge + gcharge + ccharge;

                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;

                            //meneySum += Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp += Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//自负金额
                            //meneyGovexp += Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) - Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//记账金额

                        }
                        else
                        {

                            row = dwRpt.InsertRow(0);
                            if (status == 0)
                            {
                                dwRpt.SetItemString(row, "status", "恢复");
                            }
                            status++;
                            dwRpt.SetItemString(row, "status_2", "3");
                            dwRpt.SetItemDecimal(row, "sort_col", row);
                            dwRpt.SetItemDecimal(row, "invoice_count", 1);
                            dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                            dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                            dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                            dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                            dwRpt.SetItemString(row, "invoice_no", startNo);
                            dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                            dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                            startNo = endNo;

                            //合计金额
                            decimal.TryParse(dv[i1]["rpayment_mny"].ToString(), out rpayment_mny);
                            decimal.TryParse(dv[i1]["dpayment_mny"].ToString(), out dpayment_mny);
                            decimal.TryParse(dv[i1]["gpayment_mny"].ToString(), out gpayment_mny);
                            decimal.TryParse(dv[i1]["cpayment_mny"].ToString(), out cpayment_mny);
                            meneySum =  rpayment_mny + dpayment_mny + gpayment_mny + cpayment_mny;

                            //自负金额
                            decimal.TryParse(dv[i1]["rcharge"].ToString(), out rcharge);
                            decimal.TryParse(dv[i1]["dcharge"].ToString(), out dcharge);
                            decimal.TryParse(dv[i1]["gcharge"].ToString(), out gcharge);
                            decimal.TryParse(dv[i1]["ccharge"].ToString(), out ccharge);
                            meneyOwnexp = rcharge + dcharge + gcharge + ccharge;

                            //记账金额
                            meneyGovexp = meneySum - meneyOwnexp;


                            //meneySum = Convert.ToDecimal(dv[i1]["payment_mny"].ToString());//合计金额
                            //decDiscount = Convert.ToDecimal(dv[i1]["discount_dec"].ToString());//折扣比例
                            //meneyOwnexp = Convert.ToDecimal(dv[i1]["payment_mny"].ToString()) * decDiscount;//自负金额
                            //meneyGovexp = meneySum - meneyOwnexp;//记账金额

                        }
                    }//for
                    row = dwRpt.InsertRow(0);
                    if (status == 0)
                    {
                        dwRpt.SetItemString(row, "status", "恢复");
                    }
                    status++;
                    dwRpt.SetItemString(row, "status_2", "3");
                    dwRpt.SetItemDecimal(row, "sort_col", row);
                    dwRpt.SetItemDecimal(row, "invoice_count", 1);
                    dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                    dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                    dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                    dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                    dwRpt.SetItemString(row, "invoice_no", startNo);
                    dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                }
                #endregion


            }//for

            dwRpt.Modify("t_roud.text = '" + m_cboCheckMan.Text + "'");
            //if (m_strStatType == "0")
            //{
            //    dwRpt.Modify("t_date.text = '实收日期" + m_beginDate.Value.ToShortDateString() + "'");
            //}
            //else
            //{
                dwRpt.Modify("t_date.text = '统计范围：" + m_txtStartInvo.Text.Trim()
                              + " -- " + this.m_txtEndInvo.Text.Trim() + "'");
            //}

            dwRpt.Modify("t_reprint_sum.text = '" + m_dtbRePrint.Rows.Count.ToString() + "'");

            dv.RowFilter = "flag_int = 1";
            int usedCount = this.m_dtbRePrint.Rows.Count + dv.Count;
            //dwRpt.Modify("t_used_sum.text = '" + usedCount.ToString() + "'");

            dwRpt.Sort();
            dwRpt.CalculateGroups();
            dwRpt.SetRedrawOn();
            dwRpt.Refresh();
        }


        private string GetNextString(string pStr)
        {
            if (pStr == null || pStr == "")
                return "";


            Encoding ascii = Encoding.ASCII;
            Byte[] byCoding = ascii.GetBytes(pStr);
            int intEnLengt = -1;
            for (int i1 = 0; i1 < byCoding.Length; i1++)
            {
                if ((int)byCoding[i1] <= 57)
                {
                    intEnLengt = i1 - 1;
                    break;
                }
            }
            string strEng = "";
            string strCount = "";
            string newStr;
            double dm = 0d;
            bool blnDouble = double.TryParse(pStr, out dm);
            if (intEnLengt == -1)
            {
                if (blnDouble == true)
                {
                    newStr = Convert.ToString(Convert.ToDouble(pStr) + 1);
                }
                else
                {
                    newStr = pStr + "1";
                }
            }
            else
            {
                strEng = pStr.Substring(0, intEnLengt + 1);
                strCount = pStr.Substring(intEnLengt + 1);

                newStr = Convert.ToString(Convert.ToInt32(strCount) + 1);
                newStr = strEng + newStr.PadLeft(strCount.Length, '0');
            }

            return newStr;
        }

        /// <summary>
        /// 退出按钮

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEsc_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 导出按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExcel_Click(object sender, EventArgs e)
        {
            if (this.dwRpt.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRpt, null);
            }

        }

        /// <summary>
        /// 打印按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRpt, true);
        }
        #endregion

        #region 方法

        /// <summary>
        /// 创建窗体控制器

        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.GUI_Base.clsController_Base();
            this.objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="p_strStatType"></param>
        public void m_mthRegisterStatShow(string p_strStatType)
        {
            m_strStatType = p_strStatType;
            this.Show();
        }

        #region 设置参与跳转控件的事件


        /// <summary>
        /// 设置下一个焦点控件

        /// </summary>
        internal void m_mthSetNextControl(ref Control[] p_ctlControls)
        {
            if (p_ctlControls == null)
            {
                return;
            }

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                p_ctlControls[iCtl].Enter += new EventHandler(clsCtl_Public_Enter);
                p_ctlControls[iCtl].KeyDown += new KeyEventHandler(clsCtl_Public_KeyDown);
            }
        }

        /// <summary>
        /// 设定当前控件的下一个控件

        /// </summary>
        /// <param name="sender"></param>
        private void clsCtl_Public_Enter(object sender, EventArgs e)
        {
            int ctlIndex;
            for (ctlIndex = 0; ctlIndex < m_ctlControlsArr.Length; ctlIndex++)
            {
                if (m_ctlControlsArr[ctlIndex].Name == (sender as Control).Name)
                    break;
            }

            if (ctlIndex == m_ctlControlsArr.Length - 1)
                m_ctlNext = m_ctlControlsArr[0];
            else
                m_ctlNext = m_ctlControlsArr[ctlIndex + 1];

        }

        /// <summary>
        /// 控件的keydown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clsCtl_Public_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_ctlNext.Focus();
            }
        }

        #endregion //设置参与跳转控件的事件





        #endregion //方法

        //private void m_endDate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        m_ctlNext.Focus();
        //    }

        //}

        //private void m_cboCheckMan_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        m_ctlNext.Focus();
        //    }

        //}


    }
}