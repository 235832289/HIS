using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;
namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtlOPInvoiceRpt : com.digitalwave.GUI_Base.clsController_Base
    {
        DataTable dtInvoice;
        DataTable dtRprint;

        clsDclOPInvoiceRpt m_objDomain = new clsDclOPInvoiceRpt();
        
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmOPInvoiceRpt m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPInvoiceRpt)frmMDI_Child_Base_in;
        }
        #endregion

        internal void GetRptData()
        {
            this.dtInvoice = null;
            this.dtRprint = null;
            string beginDate;
            string endDate;
            string opratorId = this.m_objViewer.m_cboCheckMan.SelectItemValue;
            string strBalanceDeptID = this.m_objViewer.m_cboDeptdesc.SelectItemValue;
            if (this.m_objViewer.m_strShowType == "0")
            {
                beginDate = this.m_objViewer.m_beginDate.Value.ToShortDateString() + " 00:00:00";
                endDate = this.m_objViewer.m_beginDate.Value.ToShortDateString() + " 23:59:59";
            }
            else
            {
                beginDate = this.m_objViewer.m_beginDate.Value.ToShortDateString() + " 00:00:00";
                endDate = this.m_objViewer.m_endDate.Value.ToShortDateString() + " 23:59:59";
            }

            if (opratorId == "" || opratorId == "1000")
            {
                this.m_objDomain.GetInvoiceInfoByDate(beginDate, endDate,strBalanceDeptID, out this.dtInvoice);

                this.m_objDomain.GetInvoiceReprintByDate(beginDate, endDate,strBalanceDeptID, out this.dtRprint);
            }
            else
            {
                this.m_objDomain.GetInvoiceInfoByDate(opratorId, beginDate, endDate,strBalanceDeptID, out this.dtInvoice);

                this.m_objDomain.GetInvoiceReprintByDate(opratorId, beginDate, endDate,strBalanceDeptID, out this.dtRprint);
            }

            SetDatawindow();
           
        }

        private void SetDatawindow()
        {
            this.m_objViewer.dwRpt.Reset();
            this.m_objViewer.dwRpt.Refresh();
            if(this.dtInvoice ==null || this.dtInvoice.Rows.Count == 0)
                return;

            this.m_objViewer.dwRpt.SetRedrawOff();
            string temp;
            ArrayList arrOpratorId = new ArrayList();

            for (int i = 0; i < this.dtInvoice.Rows.Count; i++)
            {
                temp = this.dtInvoice.Rows[i]["empid_chr"].ToString();
                if (!arrOpratorId.Contains(temp))
                {
                    arrOpratorId.Add(temp);
                }
            }

            for (int i = 0; i < this.dtRprint.Rows.Count; i++)
            {
                temp = this.dtInvoice.Rows[i]["empid_chr"].ToString();
                if (!arrOpratorId.Contains(temp))
                {
                    arrOpratorId.Add(temp);
                }
            }

            DataView dv = this.dtInvoice.DefaultView;
            DataView dvRp = this.dtRprint.DefaultView;
            string optName = "";
            string startNo, endNo = "", fwNo;
            int row, status;
            decimal invoiceCount = 0;
            decimal meneySum = 0;
            decimal meneyOwnexp = 0;
            decimal meneyGovexp = 0;

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
                dvRp.RowFilter = "empid_chr = '" + temp + "'";
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
                dv.RowFilter = "empid_chr = '" + temp + "' and status_int = 1";
                dv.Sort = "invoiceno_vchr";
                if (dv.Count == 0)
                {
                    row = this.m_objViewer.dwRpt.InsertRow(0);

                    this.m_objViewer.dwRpt.SetItemString(row, "status", "正常");
                    this.m_objViewer.dwRpt.SetItemString(row, "status_2", "1");

                    this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", 0);
                    this.m_objViewer.dwRpt.SetItemString(row, "operator", optName);
                    this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", " ");
                    this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                }
                else
                {
                    startNo = dv[0]["invoiceno_vchr"].ToString();
                    fwNo = startNo;
                    invoiceCount = 1;
                    meneySum = Convert.ToDecimal(dv[0]["totalsum_mny"].ToString());
                    meneyOwnexp = Convert.ToDecimal(dv[0]["sbsum_mny"].ToString());
                    meneyGovexp = Convert.ToDecimal(dv[0]["acctsum_mny"].ToString());

                    for (int i1 = 1; i1 < dv.Count; i1++)
                    {
                        endNo = dv[i1]["invoiceno_vchr"].ToString();
                        if (endNo == GetNextString(fwNo))
                        {
                            fwNo = endNo;
                            invoiceCount++;
                            meneySum += Convert.ToDecimal(dv[i1]["totalsum_mny"].ToString());
                            meneyOwnexp += Convert.ToDecimal(dv[i1]["sbsum_mny"].ToString());
                            meneyGovexp += Convert.ToDecimal(dv[i1]["acctsum_mny"].ToString());
                        }
                        else
                        {
                            endNo = dv[i1 - 1]["invoiceno_vchr"].ToString();
                            row = this.m_objViewer.dwRpt.InsertRow(0);
                            if (status == 0)
                            {
                                this.m_objViewer.dwRpt.SetItemString(row, "status", "正常");
                            }
                            status++;
                            this.m_objViewer.dwRpt.SetItemString(row, "status_2", "1");
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", invoiceCount);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                            this.m_objViewer.dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                            this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", startNo + " - " + endNo);
                            this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                            startNo = dv[i1]["invoiceno_vchr"].ToString();
                            fwNo = startNo;
                            invoiceCount = 1;
                            meneySum = Convert.ToDecimal(dv[i1]["totalsum_mny"].ToString());
                            meneyOwnexp = Convert.ToDecimal(dv[i1]["sbsum_mny"].ToString());
                            meneyGovexp = Convert.ToDecimal(dv[i1]["acctsum_mny"].ToString());
                        }
                    }
                    row = this.m_objViewer.dwRpt.InsertRow(0);
                    if (status == 0)
                    {
                        this.m_objViewer.dwRpt.SetItemString(row, "status", "正常");
                    }
                    this.m_objViewer.dwRpt.SetItemString(row, "status_2", "1");
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", invoiceCount);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                    this.m_objViewer.dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", startNo + " - " + endNo);
                    this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                }
                #endregion

                #region 退票
                dv.RowFilter = "empid_chr = '" + temp + "' and status_int = 2";
                dv.Sort = "invoiceno_vchr";
                if (dv.Count == 0)
                {
                    row = this.m_objViewer.dwRpt.InsertRow(0);

                    this.m_objViewer.dwRpt.SetItemString(row, "status", "退票");
                    this.m_objViewer.dwRpt.SetItemString(row, "status_2", "2");
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", 0);
                    this.m_objViewer.dwRpt.SetItemString(row, "operator", optName);
                    //this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", " ");
                    this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                    this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                }
                else
                {
                    for (int i1 = 0; i1 < dv.Count; i1++)
                    {
                        startNo = dv[i1]["invoiceno_vchr"].ToString();
                     
                        meneySum = Convert.ToDecimal(dv[i1]["totalsum_mny"].ToString());
                        meneyOwnexp = Convert.ToDecimal(dv[i1]["sbsum_mny"].ToString());
                        meneyGovexp = Convert.ToDecimal(dv[i1]["acctsum_mny"].ToString());
                        row = this.m_objViewer.dwRpt.InsertRow(0);
                        if (i1 == 0)
                        {
                            this.m_objViewer.dwRpt.SetItemString(row, "status", "退票");
                        }
                        status++;
                        this.m_objViewer.dwRpt.SetItemString(row, "status_2", "2");
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", -1);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                        this.m_objViewer.dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                        this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", startNo);
                        this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);

                        }
                    }
                #endregion

                #region 恢复
                    dv.RowFilter = "empid_chr = '" + temp + "' and status_int = 3";
                    dv.Sort = "invoiceno_vchr";
                    if (dv.Count == 0)
                    {
                        row = this.m_objViewer.dwRpt.InsertRow(0);

                        this.m_objViewer.dwRpt.SetItemString(row, "status", "恢复");
                        this.m_objViewer.dwRpt.SetItemString(row, "status_2", "3");
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", 0);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", 0);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", 0);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", 0);
                        this.m_objViewer.dwRpt.SetItemString(row, "operator", optName);
                        this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", " ");
                        this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                        this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                    }
                    else
                    {
                        for (int i1 = 0; i1 < dv.Count; i1++)
                        {
                            startNo = dv[i1]["invoiceno_vchr"].ToString();

                            meneySum = Convert.ToDecimal(dv[i1]["totalsum_mny"].ToString());
                            meneyOwnexp = Convert.ToDecimal(dv[i1]["sbsum_mny"].ToString());
                            meneyGovexp = Convert.ToDecimal(dv[i1]["acctsum_mny"].ToString());
                            row = this.m_objViewer.dwRpt.InsertRow(0);
                            if (i1 == 0)
                            {
                                this.m_objViewer.dwRpt.SetItemString(row, "status", "恢复");
                            }
                            status++;
                            this.m_objViewer.dwRpt.SetItemString(row, "status_2", "3");
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "sort_col", row);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "invoice_count", 1);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_sum", meneySum);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_ownexp", meneyOwnexp);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "money_govexp", meneyGovexp);
                            this.m_objViewer.dwRpt.SetItemString(row, "operator", dv[0]["lastname_vchr"].ToString());
                            this.m_objViewer.dwRpt.SetItemString(row, "invoice_no", startNo);
                            this.m_objViewer.dwRpt.SetItemString(row, "reprint_invoice", reprintNo);
                            this.m_objViewer.dwRpt.SetItemDecimal(row, "reprint_count", reprintCount);
                        }
                    }
                    #endregion

                
            }

            this.m_objViewer.dwRpt.Modify("t_roud.text = '" + this.m_objViewer.m_cboCheckMan.SelectItemText + "'");
            if (this.m_objViewer.m_strShowType == "0")
            {
                this.m_objViewer.dwRpt.Modify("t_date.text = '实收日期" + this.m_objViewer.m_beginDate.Value.ToShortDateString() + "'");
            }
            else
            {
                this.m_objViewer.dwRpt.Modify("t_date.text = '统计范围：" + this.m_objViewer.m_beginDate.Value.ToShortDateString() 
                              + " - " +this.m_objViewer.m_endDate.Value.ToShortDateString() + "'");
            }

            this.m_objViewer.dwRpt.Modify("t_reprint_sum.text = '" +this.dtRprint.Rows.Count.ToString() + "'");
            
            dv.RowFilter = "status_int = 1";
            int usedCount = this.dtRprint.Rows.Count + dv.Count;
            this.m_objViewer.dwRpt.Modify("t_used_sum.text = '" + usedCount.ToString() + "'");

            this.m_objViewer.dwRpt.Sort();
            this.m_objViewer.dwRpt.CalculateGroups();
            this.m_objViewer.dwRpt.SetRedrawOn();
            this.m_objViewer.dwRpt.Refresh();
        }

        private string GetNextString(string pStr)
		{
			if(pStr == null || pStr == "")
                return "";


			Encoding ascii=Encoding.ASCII;
			Byte[] byCoding= ascii.GetBytes(pStr);
			int intEnLengt=-1;
			for(int i1=0;i1<byCoding.Length;i1++)
			{
				if((int)byCoding[i1]<=57)
				{
					intEnLengt=i1-1;
					break;
				}
			}
			string strEng="";
			string strCount="";
            string newStr;
			if(intEnLengt==-1)
			{
				newStr = Convert.ToString(Convert.ToInt32(pStr) + 1);
			}
			else
			{
				strEng = pStr.Substring(0,intEnLengt+1);
                strCount = pStr.Substring(intEnLengt + 1);

                newStr = Convert.ToString(Convert.ToInt32(strCount) + 1);
                newStr = strEng + newStr.PadLeft(strCount.Length, '0');
			}

            return newStr;
		}
 
        /// <summary>
        /// 获取收费处日结报表科室
        /// </summary>
        /// <param name="strEmpId"></param>
        /// <param name="dtDept"></param>
        //internal void m_getdept(string strEmpId,out DataTable dtDept)
        //{
        //    this.m_objDomain.GetDept(strEmpId,out dtDept);
        //}
    }
}
