using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;

using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预交金日结界面控制
    /// </summary>
    class clsCtlPrepayCheckout : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclPrepayCheckout m_objDomain;
        private frmPrepayCheckout m_objViewer;

        private string m_strOperatorId = "";
        private string m_strOperatorName = "";

        //预交金明细信息
        private DataTable m_dtPrepayInfo = new DataTable();

        //结帐备注
        private string m_remark;

        private bool m_blIsHis = false;

        public clsCtlPrepayCheckout()
        {
            m_objDomain = new clsDclPrepayCheckout();

            //GetDisCheckoutPrepayInfo();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPrepayCheckout)frmMDI_Child_Base_in;
        }
        #endregion

        #region 预收款结算历史汇总信息
        /// <summary>
        /// 预收款结算历史汇总信息
        /// </summary>
        public void GetCheckoutPrepayHis()
        {
            string startDate = this.m_objViewer.m_starDate.Value.ToShortDateString();
            string endDate = this.m_objViewer.m_endDate.Value.ToShortDateString() + " 23:59:59";

            //string strOperatorId = m_objViewer.LoginInfo.m_strEmpID;

            this.m_objViewer.m_HisDataGridView.Rows.Clear();

            long lngRes = 0;
            DataTable dt;
            lngRes = this.m_objDomain.GetCheckoutPrepayHis(this.m_strOperatorId, startDate, endDate, out dt);

            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                for (int iRows = 0; iRows < dt.Rows.Count; iRows++)
                {
                    string[] s = new string[2];
                    s[0] = dt.Rows[iRows]["BALANCE_DAT"].ToString();
                    s[1] = dt.Rows[iRows]["BALANCEID_VCHR"].ToString().Trim();
                    this.m_objViewer.m_HisDataGridView.Rows.Add(s);
                }
                this.m_objViewer.m_HisDataGridView.Rows[0].Selected = false;
                this.m_objViewer.m_HisDataGridView.Rows[this.m_objViewer.m_HisDataGridView.Rows.Count - 1].Selected = true;
            }
        }
        #endregion

        #region 通过结算日期取预收款结算历史明细信息
        public void GetCheckoutPrepayHisDt(string p_strDate)
        {
            //string strOperatorId = m_objViewer.LoginInfo.m_strEmpID;

            long lngRes = 0;
            DataTable dt;
            lngRes = this.m_objDomain.GetCheckoutPrepayInfoById(m_strOperatorId, p_strDate, out dt);

            if (lngRes > 0)
            {
                this.m_objViewer.m_buttonCheckout.Enabled = false;
                this.m_dtPrepayInfo = dt;

                //备注信息
                if (dt.Rows.Count > 0)
                {
                    this.m_remark = dt.Rows[0]["REMARK_VCHR"].ToString();
                    if (this.m_remark == "" || this.m_remark == null)
                        this.m_remark = "(无)";

                }

                this.m_objViewer.m_ctlprintShow.setDocument = this.m_objViewer.m_prepayPrintDocument;

                //m_arrList = new ArrayList();
                //clsMain.m_Detach(dt, "PREPAYINV_VCHR", out m_arrList);

            }
        }
        #endregion

        #region 通过结算流水号取预收款结算历史明细信息
        /// <summary>
        /// 通过结算流水号取预收款结算历史明细信息
        /// </summary>
        /// <param name="p_balanceId"></param>
        public void GetCheckoutPrepayInfoByBalanceId(string p_balanceId)
        {
            m_blIsHis = true;

            long lngRes = 0;
            DataTable dt;
            lngRes = this.m_objDomain.GetCheckoutPrepayInfoByBalanceId(p_balanceId, out dt);

            if (lngRes > 0)
            {
                this.m_objViewer.m_buttonCheckout.Enabled = false;
                this.m_dtPrepayInfo = dt;

                //备注信息
                if (dt.Rows.Count > 0)
                {
                    this.m_remark = dt.Rows[0]["REMARK_VCHR"].ToString();
                    if (this.m_remark == "" || this.m_remark == null)
                        this.m_remark = "(无)";

                }

                this.m_objViewer.m_ctlprintShow.setDocument = this.m_objViewer.m_prepayPrintDocument;

                this.m_objViewer.m_buttonPrint.Enabled = true;
                //m_arrList = new ArrayList();
                //clsMain.m_Detach(dt, "PREPAYINV_VCHR", out m_arrList);

            }
        }
        #endregion

        #region 根据收款员ID查询未结算预收款信息
        /// <summary>
        /// 根据收款员ID查询未结算预收款信息
        /// </summary>
        /// <param name="p_strCreatorId"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public void GetDisCheckoutPrepayInfo()
        {
            m_blIsHis = false;

            if (this.m_objViewer.m_showType == 1)
            {
                DataTable dtRs;
                long r = this.m_objDomain.GetEmpIdByCode(this.m_objViewer.m_txtCode.Text.Trim(), out dtRs);
                if (r > 0 && dtRs.Rows.Count > 0)
                {
                    this.m_strOperatorId = dtRs.Rows[0]["EMPID_CHR"].ToString();
                    this.m_strOperatorName = dtRs.Rows[0]["LASTNAME_VCHR"].ToString();
                }
                else
                {
                    MessageBox.Show("未找到该工号的操作员。", "提示");
                    return;
                }
            }
            else
            {
                this.m_strOperatorId = m_objViewer.LoginInfo.m_strEmpID;
                this.m_strOperatorName = m_objViewer.LoginInfo.m_strEmpName;
            }

            //string strCreatorId = m_objViewer.LoginInfo.m_strEmpID;

            this.m_objViewer.m_buttonPrint.Enabled = false;

            long lngRes = 0;
            DataTable dt;
            lngRes = m_objDomain.GetDisCheckoutPrepayInfoById(m_strOperatorId, out dt);
            if (lngRes > 0)
            {
                this.m_remark = "";
                this.m_dtPrepayInfo = dt;
                this.m_objViewer.m_ctlprintShow.setDocument = this.m_objViewer.m_prepayPrintDocument;

                if (dt.Rows.Count > 0)
                {
                    this.m_objViewer.m_buttonCheckout.Enabled = true;
                }
                else
                {
                    this.m_objViewer.m_buttonCheckout.Enabled = false;
                }

                if (this.m_objViewer.m_showType == 1)
                {
                    this.m_objViewer.m_buttonCheckout.Enabled = false;
                    this.m_objViewer.m_buttonRemark.Enabled = false;
                }

                //m_arrList = new ArrayList();
                //clsMain.m_Detach(dt, "PREPAYINV_VCHR", out m_arrList);
            }
            else
            {
                MessageBox.Show("取未结算的预收款信息时发生错误", "错误");
            }

        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        public void CheckoutPrepayData()
        {
            PerpayBalanceRemark frmRemark;
            frmRemark = new PerpayBalanceRemark();

            frmRemark.m_rtpRemark.Text = this.m_remark;
            frmRemark.ShowDialog();

            if (frmRemark.DialogResult == DialogResult.OK)
            {
                m_remark = frmRemark.BalanceRemark;
            }
            else
            {
                frmRemark.Dispose();
                return;
            }

            frmRemark.Dispose();

            //string strCreatorId = this.m_objViewer.LoginInfo.m_strEmpID;
            long lngRes = 0;
            lngRes = m_objDomain.CheckoutPrepayData(m_dtPrepayInfo, m_strOperatorId, m_remark);
            if (lngRes > 0)
            {
                MessageBox.Show("结帐成功完成", "提示");
                GetCheckoutPrepayHis();
                this.m_objViewer.m_buttonPrint.Enabled = true;
                //this.m_objViewer.m_HisDataGridView.Focus();

                if (this.m_objViewer.m_HisDataGridView.Rows.Count > 0)
                {
                    string balanceId;
                    balanceId = this.m_objViewer.m_HisDataGridView.Rows[this.m_objViewer.m_HisDataGridView.Rows.Count - 1].Cells["BALANCEID_VCHR"].Value.ToString();
                    if (balanceId != "" && balanceId != null)
                    {
                        GetCheckoutPrepayInfoByBalanceId(balanceId);
                    }
                }
            }
            else
            {
                MessageBox.Show("结帐时发生错误", "错误");
            }
        }
        #endregion

        #region 备注
        /// <summary>
        /// 备注
        /// </summary>
        public void SetBalanceRemark()
        {

            PerpayBalanceRemark frmRemark;
            frmRemark = new PerpayBalanceRemark();

            frmRemark.m_rtpRemark.Text = this.m_remark;
            frmRemark.ShowDialog();

            if (frmRemark.DialogResult == DialogResult.Cancel)
            {
                frmRemark.Dispose();
                return;
            }

            this.m_remark = frmRemark.m_rtpRemark.Text;

            frmRemark.Dispose();

            if (this.m_dtPrepayInfo.Rows[0]["BALANCEFLAG_INT"].ToString().Trim() == "1")
            {
                //更新备注信息
                string strBalanceId = this.m_dtPrepayInfo.Rows[0]["BALANCEID_VCHR"].ToString().Trim();

                long lngRes = 0;
                lngRes = m_objDomain.ModifyBalanceRemark(strBalanceId, m_remark);
                if (lngRes > 0)
                {
                    MessageBox.Show("备注信息更新成功", "提示");

                }
                else
                {
                    MessageBox.Show("备注信息更新失败", "错误");
                    return;
                }
            }

            this.m_objViewer.m_ctlprintShow.setDocument = this.m_objViewer.m_prepayPrintDocument;

        }
        #endregion


        public void SetPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 变量
            float PageWidth = e.PageBounds.Width;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高度
            float curRowY = 0;//当前行的Y坐标
            float curRowX = 0;//当前行的X坐标
            System.Drawing.Font fntTitle = new Font("宋体", 14);//标题使用的字体
            System.Drawing.Font textFont = new Font("宋体", 10);//文字使用的字体
            const float RowHight = 23F;//项的高度
            const float LeftWith = 45F;//左宿进的长度
            const float RightWith = 130F;//右宿进的长度
            const float Uphight = 10F;//上下宿进的长度
            #endregion

            #region 头部
            Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;
            SizeF tilWith = e.Graphics.MeasureString("收费员住院预交金日结报表", fntTitle);
            e.Graphics.DrawString("收费员住院预交金日结报表", fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);

            e.Graphics.DrawString("实收日期：", textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("实收日期：", textFont);
            curRowX += tilWith.Width;

            string strCheckDate = GetCheckDate();
            string strCurCheckDate;

            if (strCheckDate == "")
            {
                strCurCheckDate = DateTime.Now.ToString();
                strCheckDate = DateTime.Now.ToShortDateString();
            }
            else
            {

                strCurCheckDate = strCheckDate;

                DateTime dateTimeT;
                DateTime.TryParse(strCheckDate, out dateTimeT);
                strCheckDate = dateTimeT.ToShortDateString();
            }

            e.Graphics.DrawString(strCheckDate, textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(strCheckDate, textFont);
            curRowX += tilWith.Width + 20;

            e.Graphics.DrawString("发票日期：", textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("发票日期：", textFont);
            curRowX += tilWith.Width;

            string firstPrepayTime = GetFirstPrepayTime();
            string lastPrepayTime = GetLastPrepayTime();
            e.Graphics.DrawString(firstPrepayTime + " ~ " + lastPrepayTime, textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(firstPrepayTime + " ~ " + lastPrepayTime, textFont);
            curRowX += tilWith.Width;

            e.Graphics.DrawString("打印日期：", textFont, Brushes.Black, curRowX + 5, curRowY);
            tilWith = e.Graphics.MeasureString("打印日期： ", textFont);
            string NowDate = DateTime.Now.ToShortDateString();
            e.Graphics.DrawString(NowDate, textFont, Brushes.Black, curRowX + tilWith.Width, curRowY);
            #endregion

            curRowX = LeftWith;
            float strLine = curRowY;

            //开票总数
            int countInvAll;
            decimal sumMoneyAll;
            countInvAll = GetSumMoney(out sumMoneyAll);

            //恢复发票数组
            ArrayList cancelArr;
            //恢复金额
            decimal sumCancel;
            // sumCancel = GetCancel(out cancelArr);

            //退费发票数组
            ArrayList refundmentArr;
            //退费金额
            decimal sumRefundment;
            //作废：当前收费员收取预交金后未结账时由当前收费员退费的行为; 退款：收费员收取预交金并结账后，由任何收费员退费的行为。
            sumRefundment = GetRefundment(out refundmentArr, out sumCancel, out cancelArr);


            //最新修改  退票数 和 退票金额独立开来，不参与有效票和实收金额的计算
            //有效票数  
            int avCount = countInvAll - refundmentArr.Count;// +cancelArr.Count;
            //实收金额
            decimal avMoney = sumMoneyAll - sumRefundment;// +sumCancel;

            //上一次结帐时间
            string frontBalanceDate;
            this.m_objDomain.GetFrontBalanceDate(this.m_objViewer.LoginInfo.m_strEmpID.Trim(), strCurCheckDate, out frontBalanceDate);
            if (frontBalanceDate == "")
            {
                frontBalanceDate = "1900-1-1 00:00:00";
            }

            //重打发票数组
            List<string> rePrintArr = new List<string>();
            string balnceDate = GetCheckDate();
            if (balnceDate == "")
            {
                balnceDate = DateTime.Now.ToString();
            }
            GetReprint(frontBalanceDate, balnceDate, out rePrintArr);   //, out invoNoArr, out invoMoneyArr);

            //冲单数组
            ArrayList StrikeInvoArr = new ArrayList();
            GetStrike(out StrikeInvoArr);

            #region 画表格
            for (int i1 = 0; i1 < 14; i1++)
            {
                float tmpWith;//X轴
                const int with = 4;
                switch (i1)
                {
                    case 0:
                        #region 第一列
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        tmpWith = LeftWith + with;

                        e.Graphics.DrawString("开  票  数", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString(countInvAll.ToString() + "张", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//开票数
                        e.Graphics.DrawString("金额合计", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 2);//实收金额合计
                        e.Graphics.DrawString("现金", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//实收现金合计
                        e.Graphics.DrawString("支票", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//人次统计

                        e.Graphics.DrawString("预交票号", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 5);//发票号

                        tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        tmpWith += tilWith.Width;
                        //e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 7);

                        #endregion

                        #region 第二列
                        tmpWith += with;
                        e.Graphics.DrawString("开 票 合 计 金 额", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        tilWith = e.Graphics.MeasureString("开 票 合 计 金 额:", textFont);

                        //开票金额
                        e.Graphics.DrawString("￥" + sumMoneyAll.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);

                        //实收金额
                        string strMoney = clsMain.CurrencyToString(Math.Abs(float.Parse(avMoney.ToString()))); ;
                        e.Graphics.DrawString(strMoney, fntTitle, Brushes.Black, tmpWith + 10, curRowY + 3 + RowHight * 2);

                        //实收现金合计 ----退款金额不算在内
                        decimal sumCash = GetPayMoney(1) - sumCancel;
                        e.Graphics.DrawString("￥" + sumCash.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 3 + RowHight * 3);

                        //实收支票合计
                        decimal cheque = GetPayMoney(2);
                        e.Graphics.DrawString("￥" + cheque.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 3 + RowHight * 4);

                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);

                        //e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);

                        #endregion

                        #region 第三列
                        tmpWith += with;
                        e.Graphics.DrawString("作废票数", textFont, Brushes.Black, tmpWith, curRowY + 7);

                        e.Graphics.DrawString(refundmentArr.Count.ToString() + "张", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//退费票数

                        e.Graphics.DrawLine(penLine, tmpWith - with, curRowY + RowHight * 3, tmpWith - with, curRowY + RowHight * 5);
                        e.Graphics.DrawString("银行卡", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 3);//实收银行卡合计
                        e.Graphics.DrawString("微信2", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 4);//实收其它合计

                        tilWith = e.Graphics.MeasureString("作废票数", textFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 2, tmpWith, curRowY + RowHight * 2);
                        #endregion

                        #region 第四列
                        tmpWith += with;
                        e.Graphics.DrawString("作废金额合计", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString("￥" + sumRefundment.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//退票金额合计

                        //e.Graphics.DrawString("银行卡", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 3);//实收银行卡合计
                        //e.Graphics.DrawString("其它", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 4);//实收其它合计

                        decimal sumCreditcard; //银行卡金额
                        sumCreditcard = GetPayMoney(3);
                        e.Graphics.DrawString("￥" + sumCreditcard.ToString("0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//银行卡金额合计

                        decimal sumOthers = GetPayMoney(4); //微信2金额
                        e.Graphics.DrawString("￥" + sumOthers.ToString("0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//其它金额合计

                        tilWith = e.Graphics.MeasureString("作废金额合计", textFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 2, tmpWith, curRowY + RowHight * 2);

                        #endregion

                        #region 第五列
                        tmpWith += with;

                        e.Graphics.DrawString(cancelArr.Count.ToString() + "张", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//恢复票数

                        e.Graphics.DrawString("退款票数", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        // e.Graphics.DrawString("￥" + (Math.Abs(sumRefundment)).ToString("0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//恢复金额合计

                        //decimal sumCreditcard; //银行卡金额
                        //sumCreditcard = GetCreditcard();
                        //e.Graphics.DrawString("￥" + sumCreditcard.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//银行卡金额合计
                        e.Graphics.DrawString("微信", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 3);

                        //decimal sumOthers = GetOthers(); //其它金额预交
                        //e.Graphics.DrawString("￥" + sumOthers.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//其它金额合计
                        // 2018-08-03
                        //e.Graphics.DrawString("支付宝", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 4);
                        e.Graphics.DrawString("其他", textFont, Brushes.Black, tmpWith + 5, curRowY + 7 + RowHight * 4);

                        tilWith = e.Graphics.MeasureString("退款票数", textFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 2, tmpWith, curRowY + RowHight * 2);

                        #endregion

                        #region 第六列
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);

                        tmpWith += with;
                        e.Graphics.DrawString("退款金额合计", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString("￥" + (Math.Abs(sumCancel)).ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//恢复金额合计

                        decimal wechatPay = GetPayMoney(8); // 微信
                        e.Graphics.DrawString("￥" + wechatPay.ToString("0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//银行卡金额合计

                        decimal aliPay = GetPayMoney(0); // 其他 // 2018-08-03 GetPayMoney(9); // 支付宝
                        e.Graphics.DrawString("￥" + aliPay.ToString("0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//其它金额合计

                        decimal aliPay2 = GetPayMoney(6);   // 支付宝.线下
                        e.Graphics.DrawString("支付宝:" + "￥" + aliPay2.ToString("0.00"), textFont, Brushes.Black, tmpWith + e.Graphics.MeasureString(aliPay.ToString("0.00"), textFont).Width + 20f, curRowY + 7 + RowHight * 4);

                        tilWith = e.Graphics.MeasureString("退款金额合计", textFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 3);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 2);

                        #endregion

                        #region 第七列

                        tmpWith += with;
                        e.Graphics.DrawString(" 有 效 票 数", textFont, Brushes.Black, tmpWith, curRowY + 7);

                        e.Graphics.DrawString(avCount.ToString() + "张", textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//有效票数
                        e.Graphics.DrawString("￥" + avMoney.ToString("###,##0.00"), textFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 2);//有效金额

                        tilWith = e.Graphics.MeasureString(" 有 效 票  数", textFont);
                        tmpWith += tilWith.Width;

                        //tmpWith += tilWith.Width;
                        //e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);


                        #endregion

                        break;
                    case 1:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;

                    case 2:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 3:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 4:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 5:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 6:
                        //预收发票号：
                        tmpWith = LeftWith + tilWith.Width;
                        float temcurRowY = curRowY;

                        DataTable dtPrepayInvs;
                        GetPrepayInvs(out dtPrepayInvs);

                        ArrayList arrPrepayInvs = new ArrayList();
                        if (dtPrepayInvs.Rows.Count > 0)
                        {
                            Detach(dtPrepayInvs, "PREPAYINV_VCHR", out arrPrepayInvs);
                        }

                        if (arrPrepayInvs.Count > 0)
                        {
                            float temY = 0;
                            float newWith = tmpWith;
                            int intRow = 0;
                            int tolRow = 0;
                            for (int f2 = 0; f2 < arrPrepayInvs.Count; f2++)
                            {
                                if (arrPrepayInvs[f2].ToString() == ",")
                                    tolRow++;
                            }
                            if (tolRow >= 3)
                            {
                                temY = 3;
                            }
                            else
                            {
                                temY = 10;
                            }
                            e.Graphics.DrawString(arrPrepayInvs[0].ToString(), textFont, Brushes.Black, tmpWith, curRowY + temY);
                            int intCount = 0;
                            for (int j2 = 0; j2 < arrPrepayInvs.Count; j2++)
                            {
                                if (arrPrepayInvs[j2].ToString() == ",")
                                {
                                    intRow++;
                                    tilWith = e.Graphics.MeasureString("-" + arrPrepayInvs[j2 - 1].ToString(), textFont);
                                    tmpWith += tilWith.Width - 5;
                                    e.Graphics.DrawString("- " + arrPrepayInvs[j2 - 1].ToString() + ", ", textFont, Brushes.Black, tmpWith, temcurRowY + temY);
                                    if (j2 != arrPrepayInvs.Count - 1)
                                    {
                                        if (intRow == 3) //&& intCount == 0)
                                        {
                                            intCount++;
                                            intRow = 0;
                                            temcurRowY = temY + 10 + temcurRowY;
                                            //tmpWith = newWith - 70;
                                            tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                                            tmpWith = with + LeftWith + tilWith.Width - e.Graphics.MeasureString("-" + arrPrepayInvs[j2 - 1].ToString(), textFont).Width;
                                        }

                                        tilWith = e.Graphics.MeasureString("-" + arrPrepayInvs[j2 - 1].ToString(), textFont);
                                        tmpWith += tilWith.Width + 15;
                                        e.Graphics.DrawString(arrPrepayInvs[j2 + 1].ToString(), textFont, Brushes.Black, tmpWith, temcurRowY + temY);
                                    }
                                }
                            }
                            tilWith = e.Graphics.MeasureString("-" + arrPrepayInvs[arrPrepayInvs.Count - 1].ToString(), textFont);
                            tmpWith += tilWith.Width - 5;
                            e.Graphics.DrawString("- " + arrPrepayInvs[arrPrepayInvs.Count - 1].ToString(), textFont, Brushes.Black, tmpWith, temcurRowY + temY);
                        }

                        //curRowY += RowHight;
                        curRowY = temcurRowY;
                        //e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;

                    case 7:
                        //curRowY += RowHight;
                        //tmpWith = LeftWith + with;
                        //e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        //e.Graphics.DrawString("手工票号", textFont, Brushes.Black, tmpWith, curRowY + 5);//手工单号

                        //tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        //tmpWith += tilWith.Width + with;

                        //ArrayList hWorkPrepayInvs;
                        //GetHWorkPrepayInvs(out hWorkPrepayInvs);

                        //if (hWorkPrepayInvs.Count > 0)
                        //{
                        //    int tolRow = 0;
                        //    string prapayInvs;

                        //    for (int i2 = 0; i2 < hWorkPrepayInvs.Count; i2++)
                        //    {
                        //        tolRow++;

                        //        if (i2 != hWorkPrepayInvs.Count - 1)
                        //        {
                        //            prapayInvs = ((string)hWorkPrepayInvs[i2]).Trim() + ",";
                        //        }
                        //        else
                        //        {
                        //            prapayInvs = ((string)hWorkPrepayInvs[i2]).Trim() + " ";
                        //        }

                        //        e.Graphics.DrawString(prapayInvs, textFont, Brushes.Black, tmpWith, curRowY + 5);

                        //        tilWith = e.Graphics.MeasureString(prapayInvs, textFont);
                        //        tmpWith += tilWith.Width;

                        //        if (tolRow > 8 && i2 != hWorkPrepayInvs.Count - 1)
                        //        {
                        //            curRowY += 13;
                        //            tolRow = 0;
                        //            tmpWith = LeftWith + e.Graphics.MeasureString("开  票  数：", textFont).Width + with * 2;
                        //        }
                        //    }
                        //}
                        break;

                    case 8:
                        curRowY += RowHight;
                        tmpWith = LeftWith + with;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        e.Graphics.DrawString("作废票号", textFont, Brushes.Black, tmpWith, curRowY + 5);//退票单号

                        //tmpWith = LeftWith + tilWith.Width;
                        tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        tmpWith += tilWith.Width + with;

                        if (refundmentArr.Count > 0)
                        {
                            int tolRow = 0;
                            string refundmentInvs;

                            for (int i2 = 0; i2 < refundmentArr.Count; i2++)
                            {
                                tolRow++;

                                if (i2 != refundmentArr.Count - 1)
                                {
                                    refundmentInvs = ((string)refundmentArr[i2]).Trim() + ",";
                                }
                                else
                                {
                                    refundmentInvs = ((string)refundmentArr[i2]).Trim() + " ";
                                }

                                e.Graphics.DrawString(refundmentInvs, textFont, Brushes.Black, tmpWith, curRowY + 5);

                                tilWith = e.Graphics.MeasureString(refundmentInvs, textFont);
                                tmpWith += tilWith.Width;


                                if (tolRow > 8 && i2 != refundmentArr.Count - 1)
                                {
                                    curRowY += 13;
                                    tolRow = 0;
                                    tmpWith = LeftWith + e.Graphics.MeasureString("开  票  数：", textFont).Width + with * 2;
                                }
                            }
                        }

                        break;
                    case 9:
                        //curRowY += RowHight;
                        //tmpWith = LeftWith + with;
                        //e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        //e.Graphics.DrawString("恢复票号", textFont, Brushes.Black, tmpWith, curRowY + 5);//恢复单号

                        //tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        //tmpWith += tilWith.Width + with;

                        //if (cancelArr.Count > 0)
                        //{
                        //    int tolRow = 0;
                        //    string cancelInvs;

                        //    for (int i2 = 0; i2 < cancelArr.Count; i2++)
                        //    {
                        //        tolRow++;

                        //        if (i2 != cancelArr.Count - 1)
                        //        {
                        //            cancelInvs = ((string)cancelArr[i2]).Trim() + ",";
                        //        }
                        //        else
                        //        {
                        //            cancelInvs = ((string)cancelArr[i2]).Trim() + " ";
                        //        }

                        //        e.Graphics.DrawString(cancelInvs, textFont, Brushes.Black, tmpWith, curRowY + 5);

                        //        tilWith = e.Graphics.MeasureString(cancelInvs, textFont);
                        //        tmpWith += tilWith.Width;


                        //        if (tolRow == 5)
                        //        {
                        //            curRowY += 13;
                        //            tolRow = 0;
                        //            tmpWith = LeftWith + e.Graphics.MeasureString("开  票  数：", textFont).Width + with * 2;
                        //        }
                        //    }
                        //}

                        break;

                    case 10:
                        curRowY += RowHight;
                        tmpWith = LeftWith + with;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        e.Graphics.DrawString("重打票号", textFont, Brushes.Black, tmpWith, curRowY + 5);

                        tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        tmpWith += tilWith.Width + with;

                        if (rePrintArr.Count > 0)
                        {
                            int tolRow = 0;
                            string reprintInvs;

                            for (int i2 = 0; i2 < rePrintArr.Count; i2++)
                            {
                                tolRow++;

                                if (i2 != rePrintArr.Count - 1)
                                {
                                    reprintInvs = ((string)rePrintArr[i2]).Trim() + ",";
                                }
                                else
                                {
                                    reprintInvs = ((string)rePrintArr[i2]).Trim();  // +" " + "(￥" + repMoney.ToString("0.00") + ")";
                                }

                                e.Graphics.DrawString(reprintInvs, textFont, Brushes.Black, tmpWith, curRowY + 5);

                                tilWith = e.Graphics.MeasureString(reprintInvs, textFont);
                                tmpWith += tilWith.Width;


                                if (tolRow == 3)//5)
                                {
                                    curRowY += 13;
                                    tolRow = 0;
                                    tmpWith = LeftWith + e.Graphics.MeasureString("开  票  数：", textFont).Width + with * 2;
                                }
                            }
                        }

                        break;
                    case 11:
                        curRowY += RowHight;
                        tmpWith = LeftWith + with;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        e.Graphics.DrawString("退款票号", textFont, Brushes.Black, tmpWith, curRowY + 5);

                        tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        tmpWith += tilWith.Width + with;

                        if (cancelArr.Count > 0)
                        {
                            int tolRow = 0;
                            string invono;

                            for (int i2 = 0; i2 < cancelArr.Count; i2++)
                            {
                                tolRow++;

                                if (i2 != cancelArr.Count - 1)
                                {
                                    invono = ((string)cancelArr[i2]).Trim() + ",";
                                }
                                else
                                {
                                    invono = ((string)cancelArr[i2]).Trim() + " ";
                                }

                                e.Graphics.DrawString(invono, textFont, Brushes.Black, tmpWith, curRowY + 5);

                                tilWith = e.Graphics.MeasureString(invono, textFont);
                                tmpWith += tilWith.Width;


                                if (tolRow == 3)
                                {
                                    curRowY += 13;
                                    tolRow = 0;
                                    tmpWith = LeftWith + e.Graphics.MeasureString("开  票  数：", textFont).Width + with * 2;
                                }
                            }
                        }

                        break;
                    case 12:
                        curRowY += RowHight;
                        tmpWith = LeftWith + with;
                        e.Graphics.DrawString("备    注", textFont, Brushes.Black, tmpWith, curRowY + 5);//备注

                        tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
                        tmpWith += tilWith.Width + with;

                        RectangleF drawRect = new RectangleF(curRowX + tilWith.Width + 5, curRowY + 5, PageWidth - RightWith - tmpWith, curRowY + 5);
                        e.Graphics.DrawString(m_remark, textFont, Brushes.Black, drawRect);
                        // e.Graphics.DrawString(m_remark, textFont, Brushes.Black, tmpWith, curRowY + 5);

                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);

                        SizeF sfTemp = e.Graphics.MeasureString(m_remark, textFont, drawRect.Size);

                        curRowY += sfTemp.Height;    // RowHight + 40;
                        break;
                    case 13:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        tmpWith = LeftWith + with;

                        e.Graphics.DrawString("缴款员：", textFont, Brushes.Black, tmpWith, curRowY + 7);
                        tilWith = e.Graphics.MeasureString("缴款员：", textFont);
                        tmpWith += tilWith.Width;

                        string empName;
                        //empName = this.m_objViewer.LoginInfo.m_strEmpName;
                        empName = this.m_strOperatorName;
                        e.Graphics.DrawString(empName, textFont, Brushes.Black, tmpWith, curRowY + 7);
                        tilWith = e.Graphics.MeasureString(empName, textFont);
                        tmpWith += tilWith.Width + with;


                        e.Graphics.DrawString("审核人：", textFont, Brushes.Black, tmpWith + 50, curRowY + 7);
                        e.Graphics.DrawString("出纳：", textFont, Brushes.Black, tmpWith + 300, curRowY + 7);
                        break;
                    default:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                }
            }
            e.Graphics.DrawLine(penLine, curRowX, strLine + RowHight, curRowX, curRowY);

            tilWith = e.Graphics.MeasureString("开  票  数：", textFont);
            float tmpX = tilWith.Width + LeftWith + 4;
            e.Graphics.DrawLine(penLine, tmpX, strLine + RowHight, tmpX, curRowY);
            e.Graphics.DrawLine(penLine, PageWidth - RightWith, strLine + RowHight, PageWidth - RightWith, curRowY);

            #endregion

        }


        #region 从datatable中取数据

        //第一张发票时间
        private string GetFirstPrepayTime()
        {
            string strPrepayInv = "";
            DataView dv;
            dv = new DataView();
            dv = this.m_dtPrepayInfo.DefaultView;
            dv.Sort = "CREATE_DAT ASC";

            if (dv.Count > 0)
            {
                strPrepayInv = dv[0]["CREATE_DAT"].ToString();
            }
            return strPrepayInv;
        }

        //最后一张发票时间
        private string GetLastPrepayTime()
        {
            string strPrepayInv = "";
            DataView dv;
            dv = new DataView();
            dv = this.m_dtPrepayInfo.DefaultView;
            dv.Sort = "CREATE_DAT DESC";

            if (dv.Count > 0)
            {
                strPrepayInv = dv[0]["CREATE_DAT"].ToString();
            }
            return strPrepayInv;
        }

        //结算时间
        private string GetCheckDate()
        {
            string strCheckDate = "";
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            //dv = this.m_dtPrepayInfo.DefaultView;

            if (dv.Count > 0)
            {
                strCheckDate = dv[0]["BALANCE_DAT"].ToString();
            }
            return strCheckDate;
        }

        //开票总金额
        private int GetSumMoney(out decimal sumMoney)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            dv.RowFilter = "PAYTYPE_INT = 1 OR PAYTYPE_INT = 4";

            int countInv = 0;
            sumMoney = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    countInv++;
                    sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
                }
            }
            return countInv;
        }

        //退票
        private decimal GetRefundment(out ArrayList invArr, out decimal sumCancel, out ArrayList cancelArr)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            dv.RowFilter = "PAYTYPE_INT = 2";

            invArr = new ArrayList();
            string strInv;
            string strCan;
            sumCancel = 0;
            cancelArr = new ArrayList();
            decimal sumRefundment = 0;
            long lngRes = -1;
            DataTable dtTemp = new DataTable();
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    //作废：当前收费员收取预交金后未结账时由当前收费员退费的行为; 退款：收费员收取预交金并结账后，由任何收费员退费的行为。
                    lngRes = this.m_objDomain.GetEmpIdByPreInvs(drv["PREPAYINV_VCHR"].ToString().Trim(), out dtTemp);
                    if (lngRes > 0 && dtTemp != null)
                    {
                        if (dtTemp.Rows.Count == 2)
                        {
                            DataRow drTemp = null;
                            string dtmTF = string.Empty;
                            string dtmJZ = string.Empty;
                            bool isWechatPay = false;
                            for (int k = 0; k < dtTemp.Rows.Count; k++)
                            {
                                drTemp = dtTemp.Rows[k];
                                if (drTemp["CREATORID_CHR"].ToString() == "0000000")
                                {
                                    isWechatPay = true;
                                    break;
                                }
                                if (drTemp["PAYTYPE_INT"].ToString().Trim() == "2")
                                {
                                    dtmTF = drTemp["CREATE_DAT"].ToString();
                                }
                                else
                                {
                                    if (drTemp["BAlaNCEfLAG_INT"].ToString() == "1")
                                    {
                                        dtmJZ = drTemp["BALANCE_DAT"].ToString();
                                    }
                                    else
                                    {
                                        dtmJZ = null;
                                    }
                                }
                            }
                            if (isWechatPay)
                            {
                                // 退费
                                sumCancel += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
                                strCan = drv["PREPAYINV_VCHR"].ToString();
                                if (!cancelArr.Contains(strCan))
                                {
                                    cancelArr.Add(strCan);
                                }

                                //sumRefundment += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
                                //strInv = drv["PREPAYINV_VCHR"].ToString();
                                //if (!invArr.Contains(strInv))
                                //{
                                //    invArr.Add(strInv);
                                //}
                            }
                            else
                            {
                                if (dtmTF != null && dtmJZ != null)
                                {
                                    if (Convert.ToDateTime(dtmTF) > Convert.ToDateTime(dtmJZ))
                                    {
                                        sumCancel += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
                                        strCan = drv["PREPAYINV_VCHR"].ToString();
                                        if (!cancelArr.Contains(strCan))
                                        {
                                            cancelArr.Add(strCan);
                                        }
                                    }
                                    else
                                    {
                                        // 作废
                                        sumRefundment += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
                                        strInv = drv["PREPAYINV_VCHR"].ToString();
                                        if (!invArr.Contains(strInv))
                                        {
                                            invArr.Add(strInv);
                                        }
                                    }
                                }
                                else
                                {
                                    sumRefundment += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);

                                    strInv = drv["PREPAYINV_VCHR"].ToString();

                                    if (!invArr.Contains(strInv))
                                    {
                                        invArr.Add(strInv);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sumRefundment += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);

                            strInv = drv["PREPAYINV_VCHR"].ToString();

                            if (!invArr.Contains(strInv))
                            {
                                invArr.Add(strInv);
                            }
                        }
                    }
                    else
                    {
                        sumRefundment += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);

                        strInv = drv["PREPAYINV_VCHR"].ToString();

                        if (!invArr.Contains(strInv))
                        {
                            invArr.Add(strInv);
                        }
                    }

                }
            }
            return Math.Abs(sumRefundment);
        }

        //恢复
        private decimal GetCancel(out ArrayList invArr)
        {
            DataView dv;
            dv = new DataView(m_dtPrepayInfo);
            dv.RowFilter = "PAYTYPE_INT = 3 ";

            invArr = new ArrayList();
            string strInv;
            decimal sumMoney = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);

                    strInv = drv["PREPAYINV_VCHR"].ToString();

                    if (!invArr.Contains(strInv))
                    {
                        invArr.Add(strInv);
                    }
                }
            }
            return sumMoney;
        }

        //冲单
        private float GetStrike(out ArrayList invsArr)
        {
            invsArr = new ArrayList();
            DataView dv = new DataView(this.m_dtPrepayInfo);
            dv.RowFilter = "PAYTYPE_INT = 4";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    invsArr.Add(drv["PREPAYINV_VCHR"].ToString().Trim() + "(" + drv["originvono_vchr"].ToString().Trim() + ")");
                }
            }

            return dv.Count;
        }

        //有效票
        //private int GetAvailability(out float sumMoney)
        //{
        //    DataView dv;
        //    dv = new DataView();
        //    dv = this.m_dtPrepayInfo.DefaultView;
        //    dv.RowFilter = "PAYTYPE_INT <> 2 and MONEY_DEC > 0 ";

        //    sumMoney = 0;
        //    if (dv.Count > 0)
        //    {
        //        foreach (DataRowView drv in dv)
        //        {
        //            sumMoney += float.Parse(drv["MONEY_DEC"].ToString());
        //        }
        //    }
        //    return dv.Count;
        //}

        /// <summary>
        /// 获取支付金额
        /// </summary>
        /// <param name="typeId">0 其他 1 现金 2 支票 3 银行卡 8 微信 9 支付宝</param>
        /// <returns></returns>
        decimal GetPayMoney(int typeId)
        {
            string filterExp = "cuycate_int {0}";   // cuycate_int : 1  现金; 2 支票; 3 银行卡; 4 微信2;  5 其他; 6 支付宝(线下) 8  微信; 9 支付宝(线上)                
            switch (typeId)
            {
                case 1:
                    filterExp = string.Format(filterExp, "= 1");
                    break;
                case 2:
                    filterExp = string.Format(filterExp, "= 2");
                    break;
                case 3:
                    filterExp = string.Format(filterExp, "= 3");
                    break;
                case 4:
                    filterExp = string.Format(filterExp, "= 4");
                    break;
                case 6:
                    filterExp = string.Format(filterExp, "= 6");
                    break;
                case 8:
                    filterExp = string.Format(filterExp, "= 8");
                    break;
                case 9:
                    filterExp = string.Format(filterExp, "= 9");
                    break;
                case 0:
                    filterExp = string.Format(filterExp, "not in (1,2,3,4,6,8,9)");
                    break;
                default:
                    break;
            }
            DataView dv = new DataView(m_dtPrepayInfo);
            dv.RowFilter = filterExp;

            decimal sum = 0;
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    sum += clsPublic.ConvertObjToDecimal(drv["money_dec"]);
                }
            }
            return sum;
        }


        ////实收现金合计
        //private decimal GetCash()
        //{
        //    DataView dv;
        //    dv = new DataView(m_dtPrepayInfo);
        //    dv.RowFilter = "CUYCATE_INT = 1";

        //    decimal sumMoney = 0;
        //    if (dv.Count > 0)
        //    {
        //        foreach (DataRowView drv in dv)
        //        {
        //            sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
        //        }
        //    }
        //    return sumMoney;
        //}

        ////实收支票金额合计
        //private decimal GetCheque()
        //{
        //    DataView dv;
        //    dv = new DataView(m_dtPrepayInfo);
        //    dv.RowFilter = "CUYCATE_INT = 2";

        //    decimal sumMoney = 0;
        //    if (dv.Count > 0)
        //    {
        //        foreach (DataRowView drv in dv)
        //        {
        //            sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
        //        }
        //    }
        //    return sumMoney;
        //}

        ////实收银行卡金额合计
        //private decimal GetCreditcard()
        //{
        //    DataView dv;
        //    dv = new DataView(m_dtPrepayInfo);
        //    dv.RowFilter = "CUYCATE_INT = 3";

        //    decimal sumMoney = 0;
        //    if (dv.Count > 0)
        //    {
        //        foreach (DataRowView drv in dv)
        //        {
        //            sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
        //        }
        //    }
        //    return sumMoney;
        //}


        ////实收其它金额合计
        //private decimal GetOthers()
        //{
        //    DataView dv;
        //    dv = new DataView(m_dtPrepayInfo);
        //    dv.RowFilter = "CUYCATE_INT not in(1,2,3)";

        //    decimal sumMoney = 0;
        //    if (dv.Count > 0)
        //    {
        //        foreach (DataRowView drv in dv)
        //        {
        //            sumMoney += clsPublic.ConvertObjToDecimal(drv["MONEY_DEC"]);
        //        }
        //    }
        //    return sumMoney;
        //}

        //正常预交发票
        private int GetPrepayInvs(out DataTable dt)
        {
            dt = new DataTable();
            dt = this.m_dtPrepayInfo.Copy();
            DataTable dtTemp = new DataTable();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["UPTYPE_INT"].ToString() == "1")
                {
                    if (dt.Rows[i]["PAYTYPE_INT"].ToString() != "1" && dt.Rows[i]["PAYTYPE_INT"].ToString() != "4")
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
                if (dt.Rows[i]["PAYTYPE_INT"].ToString() == "2")
                {
                    long lngRes = this.m_objDomain.GetEmpIdByPreInvs(dt.Rows[i]["PREPAYINV_VCHR"].ToString().Trim(), out dtTemp);
                    if (lngRes > 0 && dtTemp != null)
                    {
                        if (dtTemp.Rows.Count == 2)
                        {
                            if (dtTemp.Rows[0]["creatorid_chr"].ToString() != dtTemp.Rows[1]["creatorid_chr"].ToString())
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            return dt.Rows.Count;

        }

        //手工预交发票
        private int GetHWorkPrepayInvs(out ArrayList invsArr)
        {
            invsArr = new ArrayList();
            DataView dv = new DataView(this.m_dtPrepayInfo);

            string strInv;

            dv.RowFilter = "UPTYPE_INT = 1 ";

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    strInv = drv["PREPAYINV_VCHR"].ToString().Trim();
                    if (!invsArr.Contains(strInv))
                    {
                        invsArr.Add(strInv);
                    }
                }
            }

            return dv.Count;
        }

        //重打预交发票
        private int GetReprint(string startDate, string endDate, out List<string> reprintArr)//, out List<string> invoNoArr, out List<decimal> invoMoneyArr)
        {
            reprintArr = new List<string>();
            List<decimal> invoMoneyArr = new List<decimal>();

            long lngRes = 0;
            DataTable dt;
            string strEmpId = this.m_objViewer.LoginInfo.m_strEmpID.Trim();
            lngRes = this.m_objDomain.GetReprintByPrintEmp(strEmpId, startDate, endDate, out dt);

            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                string invoNo = string.Empty;
                decimal invoMny = 0;
                List<string> lstInvoNo = new List<string>();
                Dictionary<string, decimal> dicInv = new Dictionary<string, decimal>();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["printstatus_int"] != DBNull.Value && Convert.ToInt32(dr["printstatus_int"].ToString()) == 0)
                    {
                        invoNo = dr["repprnbillno_vchr"].ToString();
                        decimal.TryParse(dr["money_dec"].ToString(), out invoMny);
                        if (lstInvoNo.IndexOf(invoNo) < 0)
                        {
                            lstInvoNo.Add(invoNo);
                            dicInv.Add(invoNo, invoMny);
                        }
                    }
                }
                invoMny = 0;
                invoNo = string.Empty;
                string invoNo2 = string.Empty;
                for (int i = 0; i < lstInvoNo.Count; i++)
                {
                    if (i > 0)
                    {
                        if (Convert.ToDecimal(lstInvoNo[i].Substring(2)) == Convert.ToDecimal(lstInvoNo[i - 1].Substring(2)) + 1)
                        {
                            invoMny += dicInv[lstInvoNo[i]];
                            invoNo2 = lstInvoNo[i];
                        }
                        else
                        {
                            if (invoNo == invoNo2)
                            {
                                reprintArr.Add(invoNo + "(￥" + invoMny + ")");
                            }
                            else
                            {
                                reprintArr.Add(invoNo + "-" + invoNo2 + "(￥" + invoMny + ")");
                            }
                            invoNo = lstInvoNo[i];
                            invoNo2 = invoNo;
                            invoMny = dicInv[invoNo];
                        }
                    }
                    else
                    {
                        invoNo = lstInvoNo[i];
                        invoNo2 = invoNo;
                        invoMny = dicInv[invoNo];
                    }
                }
                if (invoNo == invoNo2)
                {
                    reprintArr.Add(invoNo + "(￥" + invoMny + ")");
                }
                else
                {
                    reprintArr.Add(invoNo + "-" + invoNo2 + "(￥" + invoMny + ")");
                }

                //string strInv;
                //decimal d1 = 0;
                //for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                //{
                //    strInv = dt.Rows[i1]["REPPRNBILLNO_VCHR"].ToString().Trim() + "(" + dt.Rows[i1]["SOURCEBILLNO_VCHR"].ToString().Trim() + ")";
                //    if (!reprintArr.Contains(strInv))
                //    {
                //        reprintArr.Add(strInv);
                //        decimal.TryParse(dt.Rows[i1]["MONEY_DEC"].ToString(), out d1);
                //        invoMoneyArr.Add(d1);
                //    }
                //}

                //List<int> lstIndex = new List<int>();
                //Dictionary<int, string> dicMoney = new Dictionary<int, string>();
                //string invoNo = string.Empty;
                //if (reprintArr != null && reprintArr.Count > 0)
                //{
                //    decimal invoMny = 0;
                //    for (int i = 0; i < reprintArr.Count; i++)
                //    {
                //        if (i > 0)
                //        {
                //            if (reprintArr[i].Substring(4, 6) == Convert.ToString(Convert.ToDecimal(reprintArr[i - 1].Substring(4, 6)) + 1))
                //            {
                //                invoMny += invoMoneyArr[i];
                //            }
                //            else
                //            {
                //                invoNo = invoNo.TrimEnd(',') + "(￥" + invoMny + "), ";
                //                lstIndex.Add(i - 1);
                //                dicMoney.Add(i - 1, "(￥" + invoMny + ")");
                //                invoMny = invoMoneyArr[i - 1];
                //            }
                //        }
                //        else
                //        {
                //            invoMny += invoMoneyArr[i];
                //        }
                //        invoNo += reprintArr[i] + ", ";
                //    }
                //    invoNo = invoNo.TrimEnd(',') + "(￥" + invoMny + ")";
                //    lstIndex.Add(reprintArr.Count - 1);
                //    dicMoney.Add(reprintArr.Count - 1, "(￥" + invoMny + ")");
                //}

                //foreach (int idx in lstIndex)
                //{
                //    reprintArr[idx] += dicMoney[idx];
                //}
            }
            return dt.Rows.Count;
        }
        #endregion

        #region 把数据按某一个字段来分组
        /// <summary>
        /// 把数据按某一个字段来分组
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fieldName"></param>
        /// <param name="arrList"></param>
        private void Detach(DataTable dt, string fieldName, out ArrayList arrList)
        {
            arrList = new ArrayList();
            DataView myDataView = dt.DefaultView;
            myDataView.Sort = fieldName + " ASC";
            if (dt.Rows.Count == 0)
                return;
            Encoding ascii = Encoding.ASCII;
            Byte[] byCoding = ascii.GetBytes(myDataView[0][fieldName].ToString());

            int intEnLengt = 0;

            for (int i1 = 0; i1 < byCoding.Length; i1++)
            {
                if ((int)byCoding[i1] <= 57)
                {
                    intEnLengt = i1;
                    break;
                }
            }

            string strEng = "";
            string strCount = "";
            if (intEnLengt > 0)
            {
                strEng = myDataView[0][fieldName].ToString().Substring(0, intEnLengt);
                strCount = myDataView[0][fieldName].ToString().Substring(intEnLengt);
            }
            else
            {
                strEng = "";
                strCount = myDataView[0][fieldName].ToString();
            }

            arrList.Add(myDataView[0][fieldName].ToString());

            string strEngTemp = "";
            string strCountTemp = "";
            for (int i1 = 1; i1 < myDataView.Count; i1++)
            {

                //Encoding ascii = Encoding.ASCII;
                byCoding = ascii.GetBytes(myDataView[i1][fieldName].ToString());
                intEnLengt = -1;
                for (int i2 = 0; i2 < byCoding.Length; i2++)
                {
                    if ((int)byCoding[i2] <= 57)
                    {
                        intEnLengt = i2;
                        break;
                    }
                }

                if (intEnLengt > 0)
                {
                    strEngTemp = myDataView[i1][fieldName].ToString().Substring(0, intEnLengt);
                    strCountTemp = myDataView[i1][fieldName].ToString().Substring(intEnLengt);
                }
                else
                {
                    strEngTemp = "";
                    strCountTemp = myDataView[i1][fieldName].ToString();
                }


                try
                {

                    if (strEng == strEngTemp && Convert.ToInt32(strCount) == Convert.ToInt32(strCountTemp))
                    {
                        strEng = strEngTemp;
                        strCount = strCountTemp;
                        continue;
                    }
                    if (strEng == strEngTemp && Convert.ToInt32(strCount) + 1 == Convert.ToInt32(strCountTemp))
                    {
                        arrList.Add(myDataView[i1][fieldName].ToString());

                    }
                    else
                    {
                        arrList.Add(",");
                        arrList.Add(myDataView[i1][fieldName].ToString());
                    }
                }
                catch
                { }

                strEng = strEngTemp;
                strCount = strCountTemp;
            }
        }
        #endregion

        internal void ShowDetail()
        {
            try
            {
                if (this.m_blIsHis == false)
                {
                    this.m_objViewer.m_dwDetail.DataWindowObject = "d_prepay_discheckout";
                    this.m_objViewer.m_dwDetail.Retrieve(this.m_dtPrepayInfo);

                }
                else
                {
                    this.m_objViewer.m_dwDetail.DataWindowObject = "d_prepay_checkout";
                    this.m_objViewer.m_dwDetail.Retrieve(this.m_dtPrepayInfo);

                }


                this.m_objViewer.m_dwDetail.Sort();
                this.m_objViewer.m_dwDetail.CalculateGroups();

                DWPrintPreview printPreview = new DWPrintPreview(this.m_objViewer.m_dwDetail);
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }
    }
}
