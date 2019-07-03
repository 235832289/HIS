using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预交金查询
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-14
    /// </summary>
    public class clsCtlPrepayQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclPrepayQuery m_objDomain;
        private frmPrepayQuery m_objViewer;
        private DataTable m_dtPrint;
        private DataView m_rptView;

        public clsCtlPrepayQuery()
        {
            m_objDomain = new clsDclPrepayQuery();
            //m_objViewer = new frmPrepayQuery();
            m_dtPrint = new DataTable();

            //
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPrepayQuery)frmMDI_Child_Base_in;
        }
        #endregion

        public void ButtonFind_Click()
        {
            string condition = "";
            string strAreaId = "";
            bool bolCheck;

            //日期
            bolCheck = this.m_objViewer.m_checkBoxDate.Checked;
            if (bolCheck == true)
            {
                string strFrom;
                strFrom = this.m_objViewer.m_dateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");

                string strTo;
                strTo = this.m_objViewer.m_dateTimePickerTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

                condition += @" and b.CREATE_DAT > to_date('" + strFrom + "', 'yyyy-MM-dd HH24:MI:SS')"
                           + @" and b.CREATE_DAT < to_date('" + strTo + "', 'yyyy-MM-dd HH24:MI:SS')";

            }

            //病区
            //bolCheck = this.m_objViewer.m_checkBoxArea.Checked;
            //if (bolCheck == true)
            //{

            if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
            {
                strAreaId = "";
                for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                {
                    strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                }
                strAreaId = strAreaId.TrimEnd(",".ToCharArray());

                condition += @" and c.AREAID_CHR in (" + strAreaId + ")";
            }
            //}

            //收款员工号
            bolCheck = this.m_objViewer.m_checkBoxCreater.Checked;
            if (bolCheck == true)
            {
                string strCreaterId;
                strCreaterId = this.m_objViewer.m_textBoxCreater.Text.Trim();

                condition += @" and e.EMPNO_CHR = '" + strCreaterId + "'";

            }

            //住院号
            bolCheck = this.m_objViewer.m_checkBoxInPatientId.Checked;
            if (bolCheck == true)
            {
                string strInPatientId;
                strInPatientId = this.m_objViewer.m_textBoxInPatientId.Text.Trim();

                condition += @" and c.INPATIENTID_CHR = '" + strInPatientId + "' ";

            }

            //预交单号
            bolCheck = this.m_objViewer.m_checkBoxPrepayInv.Checked;
            if (bolCheck == true)
            {
                string strPrepayInv;
                strPrepayInv = this.m_objViewer.m_textBoxPrepayInv.Text.Trim();

                condition += @" and b.PREPAYINV_VCHR = '" + strPrepayInv + "' ";
            }

            // 支付方式
            if (this.m_objViewer.chkPayType.Checked && this.m_objViewer.cboPayType.SelectedIndex > 0)
            {
                int payTypeId = this.m_objViewer.cboPayType.SelectedIndex;
                if (payTypeId == 4)
                    payTypeId = 8;
                else if (payTypeId == 5)
                    payTypeId = 9;
                condition += @" and b.CUYCATE_INT = " + payTypeId;
            }

            if (condition == "")
            {
                if (strAreaId == "%")
                {
                    //如果病区选择了全院，又没有选择其它的条件则查询所有数据，这是测试组提出的要求
                    condition = " and 1=1 ";
                }
                else
                {
                    MessageBox.Show("请选择查询的条件。", "提示");
                    return;
                }
            }

            GetPrepayInfoBy(condition);
        }

        private void GetPrepayInfoBy(string p_strCondition)
        {
            this.m_objViewer.m_dataGridViewRs.Rows.Clear();
            long lngRes = 0;
            DataTable dtPrepayInfo = new DataTable();
            lngRes = m_objDomain.GetPrepayInfoBy(p_strCondition, out dtPrepayInfo);

            if (lngRes > 0 && dtPrepayInfo.Rows.Count > 0)
            {
                DataView dv = new DataView(dtPrepayInfo);
                dv = dtPrepayInfo.DefaultView;

                string strTemp;

                decimal sumMoney = 0;
                string[] s = null;
                int n = -1;
                foreach (DataRowView drv in dv)
                {
                    if (drv["MONEY_DEC"].ToString() != null)
                    {
                        sumMoney += decimal.Parse(drv["MONEY_DEC"].ToString());
                    }

                    s = new string[15];
                    n = -1;

                    //s[0] = i.ToString();
                    s[++n] = drv["INPATIENTID_CHR"].ToString().Trim();
                    s[++n] = drv["LASTNAME_VCHR"].ToString().Trim();
                    s[++n] = drv["SEX_CHR"].ToString().Trim();
                    s[++n] = drv["DEPTNAME_VCHR"].ToString().Trim();
                    s[++n] = drv["CREATE_DAT"].ToString();
                    s[++n] = drv["PREPAYINV_VCHR"].ToString().Trim();
                    s[++n] = drv["REPPRNBILLNO_VCHR"].ToString().Trim();
                    s[++n] = drv["MONEY_DEC"].ToString();

                    strTemp = drv["CUYCATE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "1":
                            strTemp = "现金";
                            break;
                        case "2":
                            strTemp = "支票";
                            break;
                        case "3":
                            strTemp = "银行卡";
                            break;
                        case "6":
                            strTemp = "支付宝";     // 线下.支付宝
                            break;
                        case "8":
                            strTemp = "微信";
                            break;
                        case "9":
                            strTemp = "支付宝";     // 线上.支付宝
                            break;
                        default:
                            strTemp = "微信2";
                            break;
                    }
                    s[++n] = strTemp;

                    strTemp = drv["PAYTYPE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "1":
                            strTemp = "正常";
                            break;
                        case "2":
                            strTemp = "退费";
                            break;
                        case "3":
                            strTemp = "恢复";
                            break;
                        case "4":
                            strTemp = "冲单";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;
                    s[++n] = drv["CREATER"].ToString().Trim();

                    strTemp = drv["BALANCEFLAG_INT"].ToString();
                    switch (strTemp)
                    {
                        case "0":
                            strTemp = "未结帐";
                            break;
                        case "1":
                            strTemp = "已结帐";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;

                    strTemp = drv["UPTYPE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "0":
                            strTemp = "正常";
                            break;
                        case "1":
                            strTemp = "手工";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;
                    s[++n] = drv["CONFIRMEMP"].ToString();
                    s[++n] = drv["PREPAYID_CHR"].ToString();

                    this.m_objViewer.m_dataGridViewRs.Rows.Add(s);
                }

                //汇总数据
                string[] sum = new string[11];
                sum[0] = "发票张数：";
                sum[1] = dtPrepayInfo.Rows.Count.ToString();
                sum[5] = "总金额";
                sum[6] = sumMoney.ToString();
                int newRow = this.m_objViewer.m_dataGridViewRs.Rows.Add(sum);

                //if (newRow > 0)
                //{
                //    DataGridViewRow dGridViewRow = new DataGridViewRow();
                //    dGridViewRow = this.m_objViewer.m_dataGridViewRs.Rows[newRow];
                //    Font newFont = new Font();
                //    newFont.Bold = true;

                //    dGridViewRow.Cells[0].Style.Font = newFont;
                //    dGridViewRow.Cells[1].Style.Font = newFont;
                //}

                //用于打印
                this.m_dtPrint = dtPrepayInfo;
                this.m_rptView = new DataView(this.m_dtPrint);

                this.m_objViewer.m_buttonPrint.Enabled = true;
            }
            else
            {
                MessageBox.Show("无数据，请检查输入的查询的条件是否正确。", "提示");
                this.m_objViewer.m_buttonPrint.Enabled = false;
                return;
            }

        }

        #region 载入病区
        /// <summary>
        /// 载入病区
        /// </summary>
        public void LoadArea()
        {
            //m_objViewer.lsvAreaInfo.Items.Clear();
            //com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr = null;
            //string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or DEPTNAME_VCHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or PYCODE_CHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or WBCODE_CHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim() + "%')";
            //System.Windows.Forms.ListViewItem FindItem;
            //long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter, out DataResultArr);
            //if (lngRes > 0 && DataResultArr.Length > 0)
            //{
            //    #region 在病区里增加一个全院选项
            //    FindItem = new ListViewItem("");
            //    FindItem.SubItems.Add("全院");
            //    FindItem.Tag = "";
            //    m_objViewer.lsvAreaInfo.Items.Add(FindItem);
            //    #endregion

            //    for (int i = 0; i < DataResultArr.Length; i++)
            //    {
            //        FindItem = new ListViewItem(DataResultArr[i].m_strCODE_VCHR);
            //        FindItem.SubItems.Add(DataResultArr[i].m_strDEPTNAME_VCHR);
            //        FindItem.Tag = DataResultArr[i];
            //        m_objViewer.lsvAreaInfo.Items.Add(FindItem);
            //    }
            //}
        }
        #endregion

        #region 当用户改变了排序的字段时
        private void ColumnSortModeChanged()
        {
            DataGridViewColumn sortedCol = this.m_objViewer.m_dataGridViewRs.SortedColumn;
            if (sortedCol == null)
            {
                return;
            }

            string sortedColumn = sortedCol.Name.ToString();
            string sortOrder = this.m_objViewer.m_dataGridViewRs.SortOrder.ToString();

            if (sortedColumn != "" && sortOrder != "")
            {
                this.m_rptView = new DataView(m_dtPrint);
                if (sortOrder == "Ascending")
                {
                    this.m_rptView.Sort = sortedColumn + " Asc";
                }
                else
                {
                    this.m_rptView.Sort = sortedColumn + " Desc";
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void PrintResult()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer view = CreateViewer();
            if (view == null)
            {
                MessageBox.Show("没有什么可以预览");
                return;
            }
            System.Windows.Forms.Form frm = new Form();
            frm.Height = 400;

            view.Location = new System.Drawing.Point(0, 0);
            frm.Width = 800;
            frm.Height = 600;
            view.Width = frm.Width;
            view.Height = frm.Height;
            view.DisplayGroupTree = false;

            frm.Text = "打印预览";
            view.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
            frm.Controls.Add(view);
            frm.ShowDialog();
        }

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CreateViewer()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
            crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc =
                new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //this.m_objViewer.m_dataGridViewRs.DataSource;
            rptDoc.Load(@".\Report\rptPrepay.rpt");
            //rptDoc.DataDefinition.FormulaFields["operatorname"].Text = "'"+this.m_objViewer.LoginInfo.m_strEmpName+"'";
            //rptDoc.DataDefinition.FormulaFields["areaname"].Text = "'" + this.m_objViewer.m_txtAREAID_CHR.Text + "'";
            //rptDoc.DataDefinition.FormulaFields["statdate"].Text = "'"；

            //排序
            ColumnSortModeChanged();

            rptDoc.SetDataSource(this.m_rptView);


            //rptDoc.SetDataSource(m_dtPrint);
            //rptDoc.SetDataSource(this.m_objViewer.m_dataGridViewRs.DataSource); 
            crystalReportViewer1.ReportSource = rptDoc;
            return crystalReportViewer1;
        }

        #endregion

        #region 修改支付类型
        public void MondifyCuycate(DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }

            string prepayId = this.m_objViewer.m_dataGridViewRs.Rows[rowIndex].Cells["PREPAYID_CHR"].Value.ToString();
            string cuycate = this.m_objViewer.m_dataGridViewRs.Rows[rowIndex].Cells["CUYCATE_INT"].Value.ToString();

            switch (cuycate)
            {
                case "现金":
                    cuycate = "1";
                    break;
                case "支票":
                    cuycate = "2";
                    break;
                case "银行卡":
                    cuycate = "3";
                    break;
                case "支付宝":
                    cuycate = "6";
                    break;
                case "微信":
                    cuycate = "8";
                    break;
                //case "支付宝":
                //    cuycate = "9";
                //    break;
                case "微信2":
                    cuycate = "4";
                    break;
                default:
                    cuycate = "4";
                    break;
            }

            this.m_objDomain.MondifyCuycate(cuycate, prepayId);

        }
        #endregion

        public bool IsAllowModify()
        {
            string setStatus;
            this.m_objDomain.GetSysSetting("1015", out setStatus);

            bool ret;
            if (setStatus == "1")
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        #region 重打预交金发票
        /// <summary>
        /// 重打预交金发票
        /// </summary>
        internal void RePrintInvoice()
        {
            if (this.m_objViewer.m_dataGridViewRs.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要重打的预交金记录。");
                return;
            }

            string prepayId = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PREPAYID_CHR"].Value.ToString();
            string preInvoNo = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PREPAYINV_VCHR"].Value.ToString();
            string preStatus = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PAYTYPE_INT"].Value.ToString();
            if (preStatus == "正常" || preStatus == "恢复")
            {
                // 正常预交.微信
                frmPrePayRepeatPrn fpprp = new frmPrePayRepeatPrn(preInvoNo, 0, this.m_objViewer.LoginInfo.m_strEmpID);
                if (fpprp.ShowDialog() == DialogResult.OK)
                {
                    string prntype = fpprp.PrnType;
                    string newno = fpprp.NewNo;
                    if (prntype == "1")
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(prepayId, "");
                    }
                    else if (prntype == "2")
                    {
                        clsDcl_PrePay dclPrepay = new clsDcl_PrePay();
                        long l = dclPrepay.m_lngSaveRepeatPrn(prepayId, preInvoNo, newno, this.m_objViewer.LoginInfo.m_strEmpID, "1");
                        if (l > 0)
                        {
                            clsPBNetPrint.m_mthPrintPrepayBill(prepayId, newno);
                            clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, newno, 2);
                            clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", newno);
                        }
                        else
                        {
                            MessageBox.Show("保存重打信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        dclPrepay = null;
                    }
                    else if (prntype == "3")
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(prepayId, newno);
                    }
                }
            }
            else
            {
                MessageBox.Show("不能重打。");
            }
        }
        #endregion
    }
}