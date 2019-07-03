using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 全院预交金结算报表界面控制
    /// 作者： 
    /// 创建时间:2006-06-21
    /// </summary>
    class clsCtlPrepayBalanceReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmPrepayBalanceReport m_objViewer;
        private clsDclPrepayBalanceReport m_objDomain;

        //预交金明细信息
        private DataTable m_dtPrepayInfo;

        //根据操作员汇总的预交金信息
        private DataTable m_dtPrepaySum;

        //结帐备注
        private DataTable m_dtPrepayRemark;

        public clsCtlPrepayBalanceReport()
        {
            m_objDomain = new clsDclPrepayBalanceReport();

        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPrepayBalanceReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 全院预收款结算信息
        /// <summary>
        /// 全院预收款结算信息
        /// </summary>
        /// <returns></returns>
        public void GetBalanceInfo()
        {
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
                string strStarDate = m_objViewer.m_startDate.Value.ToShortDateString() + " 00:00:00";
                string strEndDate = m_objViewer.m_endDate.Value.ToShortDateString() + " 23:59:59";

                long lngRes;
                lngRes = m_objDomain.GetPrepayBalanceInfoByDate(strStarDate, strEndDate, out m_dtPrepayInfo);
                if (lngRes > 0)
                {
                    if (m_dtPrepayInfo.Rows.Count > 0)
                    {
                        //汇总信息
                        BuildReportDataTable();
                    }
                    else
                    {
                        MessageBox.Show("此时间段内没有数据，请检查输入时间是否正确。", "提示");
                        clsPublic.CloseAvi();
                        return;
                    }
                }

                //备注信息
                lngRes = m_objDomain.GetPrepayBalanceRemarkByDate(strStarDate, strEndDate, out m_dtPrepayRemark);

                #region 合计变量
                //全院开票数
                int sumAllcount = 0;
                //全院开票金额
                decimal sumAllMoney = 0;
                //全院退票数 
                int sumRefundmentCount = 0;
                //全院退票金额
                decimal sumRefundment = 0;
                //全院恢复票数
                int sumCancelCount = 0;
                //全院恢复金额
                decimal sumCancelMoney = 0;
                //有效票数
                int sumAvailCount = 0;
                //全院实收金额
                decimal sumAvailMoney = 0;
                //全院现金
                decimal sumCash = 0;
                //全院支票
                decimal sumCheque = 0;
                //全院银行卡
                decimal sumCreditcard = 0;
                //全院其他
                decimal sumOthers = 0;
                //全院微信2
                decimal sumWx2 = 0;
                // 微信
                decimal sumWx = 0;
                // 支付宝
                decimal sumZfb = 0;

                #endregion

                DataView dtvRemark = new DataView(m_dtPrepayRemark);

                if (lngRes > 0)
                {
                    this.m_objViewer.dwResult.SetRedrawOff();
                    this.m_objViewer.dwResult.Reset();

                    this.m_objViewer.dwResult.Modify("t_begindate.text='" + this.m_objViewer.m_startDate.Value.ToShortDateString() + "'");
                    this.m_objViewer.dwResult.Modify("t_enddate.text='" + this.m_objViewer.m_endDate.Value.ToShortDateString() + "'");
                    this.m_objViewer.dwResult.Modify("t_printdate.text='" + DateTime.Today.ToShortDateString() + "'");

                    DataRow dtTmp;
                    for (int i1 = 0; i1 < m_dtPrepaySum.Rows.Count; i1++)
                    {
                        dtTmp = m_dtPrepaySum.Rows[i1];

                        string balanceEmp = dtTmp["BalanceEmp"].ToString();
                        int row = this.m_objViewer.dwResult.InsertRow(0);

                        this.m_objViewer.dwResult.SetItemString(row, "t_name", dtTmp["Name"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text1", dtTmp["AllCount"].ToString() + "张");
                        sumAllcount += Convert.ToInt16(dtTmp["AllCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text2", "￥" + (Convert.ToDecimal(dtTmp["SumMoney"])).ToString("0.00"));
                        sumAllMoney += Convert.ToDecimal(dtTmp["SumMoney"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text3", dtTmp["RefundmentCount"].ToString() + "张");
                        sumRefundmentCount += Convert.ToInt16(dtTmp["RefundmentCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text4", "￥" + (Convert.ToDecimal(dtTmp["Refundment"])).ToString("0.00"));
                        sumRefundment += Convert.ToDecimal(dtTmp["Refundment"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text5", dtTmp["CancelCount"].ToString() + "张");
                        sumCancelCount += Convert.ToInt16(dtTmp["CancelCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text6", "￥" + (Convert.ToDecimal(dtTmp["CancelMoney"])).ToString("0.00"));
                        sumCancelMoney += Convert.ToDecimal(dtTmp["CancelMoney"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text7", dtTmp["AvailCount"].ToString() + "张");
                        sumAvailCount += Convert.ToInt16(dtTmp["AvailCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text8", "￥" + (Convert.ToDecimal(dtTmp["AvailMoney"])).ToString("0.00"));
                        sumAvailMoney += Convert.ToDecimal(dtTmp["AvailMoney"].ToString());


                        this.m_objViewer.dwResult.SetItemString(row, "t_cash", "￥" + (Convert.ToDecimal(dtTmp["Cash"])).ToString("0.00"));
                        sumCash += Convert.ToDecimal(dtTmp["Cash"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_check", "￥" + (Convert.ToDecimal(dtTmp["Cheque"])).ToString("0.00"));
                        sumCheque += Convert.ToDecimal(dtTmp["Cheque"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_card", "￥" + (Convert.ToDecimal(dtTmp["Creditcard"])).ToString("0.00"));
                        sumCreditcard += Convert.ToDecimal(dtTmp["Creditcard"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_wx2", "￥" + (Convert.ToDecimal(dtTmp["wx2"])).ToString("0.00"));
                        sumWx2 += Convert.ToDecimal(dtTmp["wx2"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_other", "￥" + (Convert.ToDecimal(dtTmp["Others"])).ToString("0.00"));
                        sumOthers += Convert.ToDecimal(dtTmp["Others"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_wx", "￥" + (Convert.ToDecimal(dtTmp["wechatPay"])).ToString("0.00"));
                        sumWx += Convert.ToDecimal(dtTmp["wechatPay"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_zfb", "￥" + (Convert.ToDecimal(dtTmp["aliPay"])).ToString("0.00"));
                        sumZfb += Convert.ToDecimal(dtTmp["aliPay"].ToString());

                        dtvRemark.RowFilter = "BALANCEEMP_CHR = '" + balanceEmp + "'";
                        string m_strRemark = "";
                        string m_strPrnRemark = "";
                        DataRowView drvTemp;
                        if (dtvRemark.Count > 0)
                        {
                            for (int i2 = 0; i2 < dtvRemark.Count; i2++)
                            {
                                drvTemp = dtvRemark[i2];
                                m_strRemark += drvTemp["BALANCE_DAT"].ToString() + ": " + drvTemp["REMARK_VCHR"].ToString() + "  ";
                            }
                        }
                        clsPublic.m_mthConvertNewLineStrCol(m_strRemark, 55, ref m_strPrnRemark);
                        this.m_objViewer.dwResult.SetItemString(row, "t_remark", m_strPrnRemark);
                    }

                    // 合计
                    this.m_objViewer.dwResult.Modify("t_31.text='" + sumAllcount.ToString() + "张" + "'");

                    this.m_objViewer.dwResult.Modify("t_32.text='" + "￥" + sumAllMoney.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_33.text='" + sumRefundmentCount.ToString() + "张" + "'");
                    this.m_objViewer.dwResult.Modify("t_34.text='" + "￥" + sumRefundment.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_35.text='" + sumCancelCount.ToString() + "张" + "'");
                    this.m_objViewer.dwResult.Modify("t_36.text='" + "￥" + sumCancelMoney.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_37.text='" + sumAvailCount.ToString() + "张" + "'");
                    this.m_objViewer.dwResult.Modify("t_38.text='" + "￥" + sumAvailMoney.ToString("0.00") + "'");

                    this.m_objViewer.dwResult.Modify("t_41.text='" + "￥" + sumCash.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_42.text='" + "￥" + sumCheque.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_43.text='" + "￥" + sumCreditcard.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_44.text='" + "￥" + sumOthers.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_wx_sum.text='" + "￥" + sumWx.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_zfb_sum.text='" + "￥" + sumZfb.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_sum_wx2.text='" + "￥" + sumWx2.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.SetRedrawOn();
                    this.m_objViewer.dwResult.Refresh();
                }
            }
            catch (Exception ex)
            {
                clsPublic.CloseAvi();
                MessageBox.Show("统计出错，请重新选择时间进行统计" + Environment.NewLine + Environment.NewLine + ex.Message, "系统提示", MessageBoxButtons.OK);
            }
            clsPublic.CloseAvi();

        }
        #endregion

        public void SetPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 变量
            float PageWidth = e.PageBounds.Width;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高度
            float curRowY = 0;//当前行的Y坐标
            float curRowX = 0;//当前行的X坐标
            System.Drawing.Font fntTitle = new Font("宋体", 16);//标题使用的字体
            System.Drawing.Font textFont = new Font("宋体", 10);//文字使用的字体
            const float RowHight = 23F;//项的高度
            const float LeftWith = 45F;//左宿进的长度
            const float RightWith = 130F;//右宿进的长度
            const float Uphight = 10F;//上下宿进的长度
            #endregion

            #region 报表头部
            //Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;
            SizeF tilWith = e.Graphics.MeasureString("全院预交日结报表", fntTitle);
            e.Graphics.DrawString("全院预交日结报表", fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);

            curRowY += 10;
            e.Graphics.DrawString("结帐日期：", textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("结帐日期：", textFont);
            curRowX += tilWith.Width;

            string startDate = this.m_objViewer.m_startDate.Value.ToShortDateString();
            string endDate = this.m_objViewer.m_startDate.Value.ToShortDateString();
            e.Graphics.DrawString(startDate + " ~ " + endDate, textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(startDate + " ~ " + endDate, textFont);

            string NowDate = DateTime.Now.ToShortDateString();
            tilWith = e.Graphics.MeasureString(NowDate, textFont);
            curRowX = PageWidth - tilWith.Width - RightWith;
            e.Graphics.DrawString(NowDate, textFont, Brushes.Black, curRowX, curRowY);

            tilWith = e.Graphics.MeasureString("打印日期:", textFont);
            curRowX = curRowX - tilWith.Width;
            e.Graphics.DrawString("打印日期:", textFont, Brushes.Black, curRowX, curRowY);


            #endregion

            #region 表格头部
            Pen penLine = new Pen(Brushes.Black, 1);
            const int BORDER = 4;
            //第一条竖线的X轴
            float aX = LeftWith;

            curRowY += RowHight;

            e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
            e.Graphics.DrawString("缴款员", textFont, Brushes.Black, aX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("缴 款 员 ", textFont);

            //第二条竖线的X轴
            float bX = aX + tilWith.Width;
            e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
            e.Graphics.DrawString("开票数", textFont, Brushes.Black, bX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("开票数 ", textFont);

            //第三条竖线的X轴
            float cX = bX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
            e.Graphics.DrawString("开票合计金额", textFont, Brushes.Black, cX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("开票合计金额 ", textFont);

            //第四条竖线的X轴
            float dX = cX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
            e.Graphics.DrawString("退票数", textFont, Brushes.Black, dX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("退票数", textFont);

            //第五条竖线的X轴
            float eX = dX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
            e.Graphics.DrawString("退票金额", textFont, Brushes.Black, eX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString(" 退票金 额 ", textFont);

            //第六条竖线的X轴
            float fX = eX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
            e.Graphics.DrawString("恢复票数", textFont, Brushes.Black, fX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("恢复票数", textFont);

            //第七条竖线的X轴
            float gX = fX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
            e.Graphics.DrawString("恢复金额", textFont, Brushes.Black, gX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString(" 恢复金 额 ", textFont);

            //第八条竖线的X轴
            float hX = gX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
            e.Graphics.DrawString("有效票数", textFont, Brushes.Black, hX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("有效票数", textFont);

            //第九条竖线的X轴
            float iX = hX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
            e.Graphics.DrawString("实收合计", textFont, Brushes.Black, iX + BORDER, curRowY + 7);

            //第十条竖线的X轴
            float jX = PageWidth - RightWith;
            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);

            #endregion

            #region 合计变量
            //全院开票数
            int sumAllcount = 0;
            //全院开票金额
            decimal sumAllMoney = 0;
            //全院退票数 
            int sumRefundmentCount = 0;
            //全院退票金额
            decimal sumRefundment = 0;
            //全院恢复票数
            int sumCancelCount = 0;
            //全院恢复金额
            decimal sumCancelMoney = 0;
            //有效票数
            int sumAvailCount = 0;
            //全院实收金额
            decimal sumAvailMoney = 0;
            //全院现金
            decimal sumCash = 0;
            //全院支票
            decimal sumCheque = 0;
            //全院银行卡
            decimal sumCreditcard = 0;
            //全院微信2
            decimal sumOthers = 0;
            #endregion

            #region 个人结算情况

            curRowY += RowHight;
            for (int iOpr = 0; iOpr < this.m_dtPrepaySum.Rows.Count; iOpr++)
            {
                #region 第一行

                e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
                e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

                //收款员
                string balanceEmp = this.m_dtPrepaySum.Rows[iOpr]["BalanceEmp"].ToString().Trim();
                string name = this.m_dtPrepaySum.Rows[iOpr]["Name"].ToString().Trim();
                e.Graphics.DrawString(name, textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
                //开票张数
                string allCount = this.m_dtPrepaySum.Rows[iOpr]["AllCount"].ToString();
                sumAllcount += int.Parse(allCount);
                e.Graphics.DrawString(allCount + "张", textFont, Brushes.Black, bX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
                //开票金额
                string sumMoney = this.m_dtPrepaySum.Rows[iOpr]["SumMoney"].ToString();
                sumAllMoney += decimal.Parse(sumMoney);
                e.Graphics.DrawString("￥" + decimal.Parse(sumMoney).ToString("0.00"), textFont, Brushes.Black, cX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
                //退票张数
                string refundmentCount = this.m_dtPrepaySum.Rows[iOpr]["RefundmentCount"].ToString();
                sumRefundmentCount += int.Parse(refundmentCount);
                e.Graphics.DrawString(refundmentCount + "张", textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
                //退票金额
                string refundment = this.m_dtPrepaySum.Rows[iOpr]["Refundment"].ToString();
                sumRefundment += decimal.Parse(refundment);
                e.Graphics.DrawString("￥" + decimal.Parse(refundment).ToString("0.00"), textFont, Brushes.Black, eX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
                //恢复票数
                string cancelCount = this.m_dtPrepaySum.Rows[iOpr]["CancelCount"].ToString();
                sumCancelCount += int.Parse(cancelCount);
                e.Graphics.DrawString(cancelCount + "张", textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
                //恢复金额
                string cancelMoney = this.m_dtPrepaySum.Rows[iOpr]["CancelMoney"].ToString();
                sumCancelMoney += decimal.Parse(cancelMoney);
                e.Graphics.DrawString("￥" + decimal.Parse(cancelMoney).ToString("0.00"), textFont, Brushes.Black, gX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
                //有效票数
                string availCount = this.m_dtPrepaySum.Rows[iOpr]["AvailCount"].ToString();
                sumAvailCount += int.Parse(availCount);
                e.Graphics.DrawString(availCount + "张", textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
                //有效金额
                string availMoney = this.m_dtPrepaySum.Rows[iOpr]["AvailMoney"].ToString();
                sumAvailMoney += decimal.Parse(availMoney);
                e.Graphics.DrawString("￥" + decimal.Parse(availMoney).ToString("0.00"), textFont, Brushes.Black, iX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);

                #endregion

                #region 第二、三行

                //第二行
                curRowY += RowHight;
                e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight * 2);
                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
                e.Graphics.DrawString("现金", textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight * 2);
                e.Graphics.DrawString("支票", textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight * 2);
                e.Graphics.DrawString("银行卡", textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight * 2);
                e.Graphics.DrawString("微信2", textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight * 2);

                //第三行
                curRowY += RowHight;
                string cash = this.m_dtPrepaySum.Rows[iOpr]["Cash"].ToString();
                sumCash += decimal.Parse(cash);
                e.Graphics.DrawString("￥" + decimal.Parse(cash).ToString("0.00"), textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                string cheque = this.m_dtPrepaySum.Rows[iOpr]["Cheque"].ToString();
                sumCheque += decimal.Parse(cheque);
                e.Graphics.DrawString("￥" + decimal.Parse(cheque).ToString("0.00"), textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                string creditcard = this.m_dtPrepaySum.Rows[iOpr]["Creditcard"].ToString();
                sumCreditcard += decimal.Parse(creditcard);
                e.Graphics.DrawString("￥" + decimal.Parse(creditcard).ToString("0.00"), textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                string others = this.m_dtPrepaySum.Rows[iOpr]["Others"].ToString();
                sumOthers += decimal.Parse(others);
                e.Graphics.DrawString("￥" + decimal.Parse(others).ToString("0.00"), textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

                #endregion

                //备注

                DataView dvRemark;
                dvRemark = new DataView(m_dtPrepayRemark);
                dvRemark.RowFilter = "BALANCEEMP_CHR = '" + balanceEmp + "'";

                curRowY += RowHight;
                if (dvRemark.Count > 0)
                {
                    foreach (DataRowView drv in dvRemark)
                    {
                        string balanceDate = drv["BALANCE_DAT"].ToString();
                        string remark = drv["REMARK_VCHR"].ToString();

                        if (remark == "" || remark == null)
                        {
                            //tilWith = e.Graphics.MeasureString("备注", textFont);
                            continue;
                        }
                        else
                        {
                            tilWith = e.Graphics.MeasureString(remark, textFont);
                        }

                        e.Graphics.DrawString(balanceDate + "  备注", textFont, Brushes.Black, aX + BORDER, curRowY + 7);
                        e.Graphics.DrawString(remark, textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                        e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + tilWith.Height + 7);
                        //e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
                        e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + tilWith.Height + 7);
                        e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + tilWith.Height + 7);
                        e.Graphics.DrawLine(penLine, aX, curRowY + tilWith.Height + 7, PageWidth - RightWith, curRowY + tilWith.Height + 7);

                        curRowY += tilWith.Height + 7;
                    }
                }

                curRowY += RowHight / 2;
            }
            #endregion

            #region 合计
            System.Drawing.Font sFont = new Font("宋体", 10, FontStyle.Bold);//合计行使用的字体

            curRowY += RowHight / 2;
            e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

            e.Graphics.DrawString("合计", sFont, Brushes.Black, aX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
            //开票张数
            e.Graphics.DrawString(sumAllcount.ToString() + "张", sFont, Brushes.Black, bX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
            //开票金额
            e.Graphics.DrawString("￥" + sumAllMoney.ToString("0.00"), sFont, Brushes.Black, cX, curRowY + 7);

            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
            //退票张数
            e.Graphics.DrawString(sumRefundmentCount.ToString() + "张", sFont, Brushes.Black, dX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
            //退票金额
            e.Graphics.DrawString("￥" + sumRefundment.ToString("0.00"), sFont, Brushes.Black, eX, curRowY + 7);

            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
            //恢复票数
            e.Graphics.DrawString(sumCancelCount.ToString() + "张", sFont, Brushes.Black, fX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
            //恢复金额
            e.Graphics.DrawString("￥" + sumCancelMoney.ToString("0.00"), sFont, Brushes.Black, gX, curRowY + 7);

            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
            //有效票数
            e.Graphics.DrawString(sumAvailCount.ToString() + "张", sFont, Brushes.Black, hX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
            //有效金额
            e.Graphics.DrawString("￥" + sumAvailMoney.ToString("0.00"), sFont, Brushes.Black, iX, curRowY + 7);

            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);


            //第二行
            curRowY += RowHight;
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight * 2);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
            e.Graphics.DrawString("现金", sFont, Brushes.Black, aX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight * 2);
            e.Graphics.DrawString("支票", sFont, Brushes.Black, dX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight * 2);
            e.Graphics.DrawString("银行卡", sFont, Brushes.Black, fX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight * 2);
            e.Graphics.DrawString("微信2", sFont, Brushes.Black, hX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight * 2);

            //第三行
            curRowY += RowHight;
            e.Graphics.DrawString("￥" + sumCash.ToString("0.00"), sFont, Brushes.Black, aX, curRowY + 7);

            e.Graphics.DrawString("￥" + sumCheque.ToString("0.00"), sFont, Brushes.Black, dX, curRowY + 7);

            e.Graphics.DrawString("￥" + sumCreditcard.ToString("0.00"), sFont, Brushes.Black, fX, curRowY + 7);

            e.Graphics.DrawString("￥" + sumOthers.ToString("0.00"), sFont, Brushes.Black, hX, curRowY + 7);

            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

            #endregion

        }

        #region 构造一个包含按操作员汇总的DataTable

        private void BuildReportDataTable()
        {
            m_dtPrepaySum = new DataTable();

            #region 添加列
            m_dtPrepaySum.Columns.Add("BalanceEmp", typeof(String));
            m_dtPrepaySum.Columns.Add("Name", typeof(String));
            m_dtPrepaySum.Columns.Add("AllCount", typeof(int));
            m_dtPrepaySum.Columns.Add("SumMoney", typeof(decimal));
            m_dtPrepaySum.Columns.Add("AvailCount", typeof(int));
            m_dtPrepaySum.Columns.Add("AvailMoney", typeof(decimal));
            m_dtPrepaySum.Columns.Add("Cash", typeof(decimal));
            m_dtPrepaySum.Columns.Add("Cheque", typeof(decimal));
            m_dtPrepaySum.Columns.Add("Creditcard", typeof(decimal));
            m_dtPrepaySum.Columns.Add("wx2", typeof(decimal));
            m_dtPrepaySum.Columns.Add("Others", typeof(decimal));
            m_dtPrepaySum.Columns.Add("RefundmentCount", typeof(int));
            m_dtPrepaySum.Columns.Add("Refundment", typeof(decimal));
            m_dtPrepaySum.Columns.Add("CancelCount", typeof(int));
            m_dtPrepaySum.Columns.Add("CancelMoney", typeof(decimal));
            m_dtPrepaySum.Columns.Add("wechatPay", typeof(decimal));
            m_dtPrepaySum.Columns.Add("aliPay", typeof(decimal));
            #endregion

            for (int iRow = 0; iRow < this.m_dtPrepayInfo.Rows.Count; iRow++)
            {
                string balanceEmp; //结帐员ID
                balanceEmp = this.m_dtPrepayInfo.Rows[iRow]["BALANCEEMP_CHR"].ToString();

                DataRow[] reportRow = m_dtPrepaySum.Select("BalanceEmp = '" + balanceEmp + "'");
                if (reportRow.Length == 0)
                {
                    DataRow newRow = m_dtPrepaySum.NewRow();

                    newRow["BalanceEmp"] = balanceEmp;

                    string name = this.m_dtPrepayInfo.Rows[iRow]["LASTNAME_VCHR"].ToString();
                    newRow["Name"] = name;

                    //开票总数、总金额
                    decimal sumMoney;
                    int allCount = GetSumMoneyByBalanceEmp(balanceEmp, out sumMoney);
                    newRow["AllCount"] = allCount;
                    newRow["SumMoney"] = sumMoney;


                    //退票
                    decimal refundment;
                    int refundmentCount = GetRefundmentByBalanceEmp(balanceEmp, out refundment);
                    newRow["RefundmentCount"] = refundmentCount;
                    newRow["Refundment"] = refundment;

                    //恢复
                    decimal cancelMoney;
                    int cancelCount = GetCancelByBalanceEmp(balanceEmp, out cancelMoney);
                    newRow["CancelCount"] = cancelCount;
                    newRow["CancelMoney"] = cancelMoney;

                    //有效票数、金额
                    decimal availMoney = sumMoney - refundment + cancelMoney;
                    int availCount = allCount - refundmentCount + cancelCount;
                    newRow["AvailCount"] = availCount;
                    newRow["AvailMoney"] = availMoney;

                    // 现金
                    newRow["Cash"] = GetCuyCateMoney(balanceEmp, 1);
                    // 支票
                    newRow["Cheque"] = GetCuyCateMoney(balanceEmp, 2);
                    // 银行卡
                    newRow["Creditcard"] = GetCuyCateMoney(balanceEmp, 3);
                    // wx2
                    newRow["wx2"] = GetCuyCateMoney(balanceEmp, 4);
                    // 微信
                    newRow["wechatPay"] = GetCuyCateMoney(balanceEmp, 8);
                    // 支付宝.线下
                    newRow["aliPay"] = GetCuyCateMoney(balanceEmp, 6);
                    //// 支付宝.线上
                    //newRow["aliPay"] = GetCuyCateMoney(balanceEmp, 9);
                    // 其他
                    newRow["Others"] = GetCuyCateMoney(balanceEmp, 0);

                    m_dtPrepaySum.Rows.Add(newRow);
                }
                else
                {
                    continue;
                }
            }
        }
        #endregion

        #region 从m_dtPrepayInfo中取数据的方法


        //开票总金额
        private int GetSumMoneyByBalanceEmp(string balanceEmp, out decimal sumMoney)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            //dv = this.m_dtPrepayInfo.DefaultView;
            dv.RowFilter = "PAYTYPE_INT = 1 and BALANCEEMP_CHR = '" + balanceEmp + "'";
            //dv.Sort = "CREATE_DAT DESC";

            int countInv = 0;
            sumMoney = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    countInv++;
                    sumMoney += decimal.Parse(drv["MONEY_DEC"].ToString());
                }
            }
            return countInv;
        }

        //退票
        private int GetRefundmentByBalanceEmp(string balanceEmp, out decimal sumRefundment)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            //dv = this.m_dtPrepayInfo.DefaultView;
            dv.RowFilter = "PAYTYPE_INT = 2 and BALANCEEMP_CHR = '" + balanceEmp + "'";

            sumRefundment = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    sumRefundment += decimal.Parse(drv["MONEY_DEC"].ToString());
                }

                sumRefundment = Math.Abs(sumRefundment);
            }
            return dv.Count;
        }

        //恢复
        private int GetCancelByBalanceEmp(string balanceEmp, out decimal sumMoney)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            //dv = this.m_dtPrepayInfo.DefaultView;
            dv.RowFilter = "PAYTYPE_INT = 3 and BALANCEEMP_CHR = '" + balanceEmp + "'";

            sumMoney = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    sumMoney += decimal.Parse(drv["MONEY_DEC"].ToString());
                }
            }
            return dv.Count;
        } 

        decimal GetCuyCateMoney(string empId, int typeId)
        {
            decimal money = 0;
            string filterExp = "cuycate_int {0} and balanceemp_chr = '{1}'";
            switch (typeId)
            {
                case 1:
                    filterExp = string.Format(filterExp, "= 1", empId);
                    break;
                case 2:
                    filterExp = string.Format(filterExp, "= 2", empId);
                    break;
                case 3:
                    filterExp = string.Format(filterExp, "= 3", empId);
                    break;
                case 4:
                    filterExp = string.Format(filterExp, "= 4", empId);
                    break;
                case 6:
                    filterExp = string.Format(filterExp, "= 6", empId);
                    break;
                case 8:
                    filterExp = string.Format(filterExp, "= 8", empId);
                    break;
                case 9:
                    filterExp = string.Format(filterExp, "= 9", empId);
                    break;
                case 0:
                    filterExp = string.Format(filterExp, "not in (1,2,3,4,6,8,9)", empId);
                    break;
                default:
                    break;
            }
            DataView dv = new DataView(m_dtPrepayInfo);
            dv.RowFilter = filterExp;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    money += decimal.Parse(drv["money_dec"].ToString());
                }
            }
            return money;
        }

        #endregion

    }
}
