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
    /// ȫԺԤ������㱨��������
    /// ���ߣ� 
    /// ����ʱ��:2006-06-21
    /// </summary>
    class clsCtlPrepayBalanceReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmPrepayBalanceReport m_objViewer;
        private clsDclPrepayBalanceReport m_objDomain;

        //Ԥ������ϸ��Ϣ
        private DataTable m_dtPrepayInfo;

        //���ݲ���Ա���ܵ�Ԥ������Ϣ
        private DataTable m_dtPrepaySum;

        //���ʱ�ע
        private DataTable m_dtPrepayRemark;

        public clsCtlPrepayBalanceReport()
        {
            m_objDomain = new clsDclPrepayBalanceReport();

        }

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPrepayBalanceReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region ȫԺԤ�տ������Ϣ
        /// <summary>
        /// ȫԺԤ�տ������Ϣ
        /// </summary>
        /// <returns></returns>
        public void GetBalanceInfo()
        {
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "����ͳ�����ݣ����Ժ�...");
                string strStarDate = m_objViewer.m_startDate.Value.ToShortDateString() + " 00:00:00";
                string strEndDate = m_objViewer.m_endDate.Value.ToShortDateString() + " 23:59:59";

                long lngRes;
                lngRes = m_objDomain.GetPrepayBalanceInfoByDate(strStarDate, strEndDate, out m_dtPrepayInfo);
                if (lngRes > 0)
                {
                    if (m_dtPrepayInfo.Rows.Count > 0)
                    {
                        //������Ϣ
                        BuildReportDataTable();
                    }
                    else
                    {
                        MessageBox.Show("��ʱ�����û�����ݣ���������ʱ���Ƿ���ȷ��", "��ʾ");
                        clsPublic.CloseAvi();
                        return;
                    }
                }

                //��ע��Ϣ
                lngRes = m_objDomain.GetPrepayBalanceRemarkByDate(strStarDate, strEndDate, out m_dtPrepayRemark);

                #region �ϼƱ���
                //ȫԺ��Ʊ��
                int sumAllcount = 0;
                //ȫԺ��Ʊ���
                decimal sumAllMoney = 0;
                //ȫԺ��Ʊ�� 
                int sumRefundmentCount = 0;
                //ȫԺ��Ʊ���
                decimal sumRefundment = 0;
                //ȫԺ�ָ�Ʊ��
                int sumCancelCount = 0;
                //ȫԺ�ָ����
                decimal sumCancelMoney = 0;
                //��ЧƱ��
                int sumAvailCount = 0;
                //ȫԺʵ�ս��
                decimal sumAvailMoney = 0;
                //ȫԺ�ֽ�
                decimal sumCash = 0;
                //ȫԺ֧Ʊ
                decimal sumCheque = 0;
                //ȫԺ���п�
                decimal sumCreditcard = 0;
                //ȫԺ����
                decimal sumOthers = 0;
                //ȫԺ΢��2
                decimal sumWx2 = 0;
                // ΢��
                decimal sumWx = 0;
                // ֧����
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

                        this.m_objViewer.dwResult.SetItemString(row, "text1", dtTmp["AllCount"].ToString() + "��");
                        sumAllcount += Convert.ToInt16(dtTmp["AllCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text2", "��" + (Convert.ToDecimal(dtTmp["SumMoney"])).ToString("0.00"));
                        sumAllMoney += Convert.ToDecimal(dtTmp["SumMoney"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text3", dtTmp["RefundmentCount"].ToString() + "��");
                        sumRefundmentCount += Convert.ToInt16(dtTmp["RefundmentCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text4", "��" + (Convert.ToDecimal(dtTmp["Refundment"])).ToString("0.00"));
                        sumRefundment += Convert.ToDecimal(dtTmp["Refundment"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text5", dtTmp["CancelCount"].ToString() + "��");
                        sumCancelCount += Convert.ToInt16(dtTmp["CancelCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text6", "��" + (Convert.ToDecimal(dtTmp["CancelMoney"])).ToString("0.00"));
                        sumCancelMoney += Convert.ToDecimal(dtTmp["CancelMoney"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text7", dtTmp["AvailCount"].ToString() + "��");
                        sumAvailCount += Convert.ToInt16(dtTmp["AvailCount"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "text8", "��" + (Convert.ToDecimal(dtTmp["AvailMoney"])).ToString("0.00"));
                        sumAvailMoney += Convert.ToDecimal(dtTmp["AvailMoney"].ToString());


                        this.m_objViewer.dwResult.SetItemString(row, "t_cash", "��" + (Convert.ToDecimal(dtTmp["Cash"])).ToString("0.00"));
                        sumCash += Convert.ToDecimal(dtTmp["Cash"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_check", "��" + (Convert.ToDecimal(dtTmp["Cheque"])).ToString("0.00"));
                        sumCheque += Convert.ToDecimal(dtTmp["Cheque"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_card", "��" + (Convert.ToDecimal(dtTmp["Creditcard"])).ToString("0.00"));
                        sumCreditcard += Convert.ToDecimal(dtTmp["Creditcard"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_wx2", "��" + (Convert.ToDecimal(dtTmp["wx2"])).ToString("0.00"));
                        sumWx2 += Convert.ToDecimal(dtTmp["wx2"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_other", "��" + (Convert.ToDecimal(dtTmp["Others"])).ToString("0.00"));
                        sumOthers += Convert.ToDecimal(dtTmp["Others"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_wx", "��" + (Convert.ToDecimal(dtTmp["wechatPay"])).ToString("0.00"));
                        sumWx += Convert.ToDecimal(dtTmp["wechatPay"].ToString());

                        this.m_objViewer.dwResult.SetItemString(row, "t_zfb", "��" + (Convert.ToDecimal(dtTmp["aliPay"])).ToString("0.00"));
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

                    // �ϼ�
                    this.m_objViewer.dwResult.Modify("t_31.text='" + sumAllcount.ToString() + "��" + "'");

                    this.m_objViewer.dwResult.Modify("t_32.text='" + "��" + sumAllMoney.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_33.text='" + sumRefundmentCount.ToString() + "��" + "'");
                    this.m_objViewer.dwResult.Modify("t_34.text='" + "��" + sumRefundment.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_35.text='" + sumCancelCount.ToString() + "��" + "'");
                    this.m_objViewer.dwResult.Modify("t_36.text='" + "��" + sumCancelMoney.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_37.text='" + sumAvailCount.ToString() + "��" + "'");
                    this.m_objViewer.dwResult.Modify("t_38.text='" + "��" + sumAvailMoney.ToString("0.00") + "'");

                    this.m_objViewer.dwResult.Modify("t_41.text='" + "��" + sumCash.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_42.text='" + "��" + sumCheque.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_43.text='" + "��" + sumCreditcard.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_44.text='" + "��" + sumOthers.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_wx_sum.text='" + "��" + sumWx.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_zfb_sum.text='" + "��" + sumZfb.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.Modify("t_sum_wx2.text='" + "��" + sumWx2.ToString("0.00") + "'");
                    this.m_objViewer.dwResult.SetRedrawOn();
                    this.m_objViewer.dwResult.Refresh();
                }
            }
            catch (Exception ex)
            {
                clsPublic.CloseAvi();
                MessageBox.Show("ͳ�Ƴ���������ѡ��ʱ�����ͳ��" + Environment.NewLine + Environment.NewLine + ex.Message, "ϵͳ��ʾ", MessageBoxButtons.OK);
            }
            clsPublic.CloseAvi();

        }
        #endregion

        public void SetPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region ����
            float PageWidth = e.PageBounds.Width;//���ҳ��Ŀ��
            float PageHight = e.PageBounds.Height;//���ҳ��ĸ߶�
            float curRowY = 0;//��ǰ�е�Y����
            float curRowX = 0;//��ǰ�е�X����
            System.Drawing.Font fntTitle = new Font("����", 16);//����ʹ�õ�����
            System.Drawing.Font textFont = new Font("����", 10);//����ʹ�õ�����
            const float RowHight = 23F;//��ĸ߶�
            const float LeftWith = 45F;//���޽��ĳ���
            const float RightWith = 130F;//���޽��ĳ���
            const float Uphight = 10F;//�����޽��ĳ���
            #endregion

            #region ����ͷ��
            //Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;
            SizeF tilWith = e.Graphics.MeasureString("ȫԺԤ���սᱨ��", fntTitle);
            e.Graphics.DrawString("ȫԺԤ���սᱨ��", fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);

            curRowY += 10;
            e.Graphics.DrawString("�������ڣ�", textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("�������ڣ�", textFont);
            curRowX += tilWith.Width;

            string startDate = this.m_objViewer.m_startDate.Value.ToShortDateString();
            string endDate = this.m_objViewer.m_startDate.Value.ToShortDateString();
            e.Graphics.DrawString(startDate + " ~ " + endDate, textFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(startDate + " ~ " + endDate, textFont);

            string NowDate = DateTime.Now.ToShortDateString();
            tilWith = e.Graphics.MeasureString(NowDate, textFont);
            curRowX = PageWidth - tilWith.Width - RightWith;
            e.Graphics.DrawString(NowDate, textFont, Brushes.Black, curRowX, curRowY);

            tilWith = e.Graphics.MeasureString("��ӡ����:", textFont);
            curRowX = curRowX - tilWith.Width;
            e.Graphics.DrawString("��ӡ����:", textFont, Brushes.Black, curRowX, curRowY);


            #endregion

            #region ���ͷ��
            Pen penLine = new Pen(Brushes.Black, 1);
            const int BORDER = 4;
            //��һ�����ߵ�X��
            float aX = LeftWith;

            curRowY += RowHight;

            e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
            e.Graphics.DrawString("�ɿ�Ա", textFont, Brushes.Black, aX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("�� �� Ա ", textFont);

            //�ڶ������ߵ�X��
            float bX = aX + tilWith.Width;
            e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
            e.Graphics.DrawString("��Ʊ��", textFont, Brushes.Black, bX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("��Ʊ�� ", textFont);

            //���������ߵ�X��
            float cX = bX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
            e.Graphics.DrawString("��Ʊ�ϼƽ��", textFont, Brushes.Black, cX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("��Ʊ�ϼƽ�� ", textFont);

            //���������ߵ�X��
            float dX = cX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
            e.Graphics.DrawString("��Ʊ��", textFont, Brushes.Black, dX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("��Ʊ��", textFont);

            //���������ߵ�X��
            float eX = dX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
            e.Graphics.DrawString("��Ʊ���", textFont, Brushes.Black, eX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString(" ��Ʊ�� �� ", textFont);

            //���������ߵ�X��
            float fX = eX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
            e.Graphics.DrawString("�ָ�Ʊ��", textFont, Brushes.Black, fX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("�ָ�Ʊ��", textFont);

            //���������ߵ�X��
            float gX = fX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
            e.Graphics.DrawString("�ָ����", textFont, Brushes.Black, gX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString(" �ָ��� �� ", textFont);

            //�ڰ������ߵ�X��
            float hX = gX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
            e.Graphics.DrawString("��ЧƱ��", textFont, Brushes.Black, hX + BORDER, curRowY + 7);
            tilWith = e.Graphics.MeasureString("��ЧƱ��", textFont);

            //�ھ������ߵ�X��
            float iX = hX + tilWith.Width + BORDER;
            e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
            e.Graphics.DrawString("ʵ�պϼ�", textFont, Brushes.Black, iX + BORDER, curRowY + 7);

            //��ʮ�����ߵ�X��
            float jX = PageWidth - RightWith;
            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);

            #endregion

            #region �ϼƱ���
            //ȫԺ��Ʊ��
            int sumAllcount = 0;
            //ȫԺ��Ʊ���
            decimal sumAllMoney = 0;
            //ȫԺ��Ʊ�� 
            int sumRefundmentCount = 0;
            //ȫԺ��Ʊ���
            decimal sumRefundment = 0;
            //ȫԺ�ָ�Ʊ��
            int sumCancelCount = 0;
            //ȫԺ�ָ����
            decimal sumCancelMoney = 0;
            //��ЧƱ��
            int sumAvailCount = 0;
            //ȫԺʵ�ս��
            decimal sumAvailMoney = 0;
            //ȫԺ�ֽ�
            decimal sumCash = 0;
            //ȫԺ֧Ʊ
            decimal sumCheque = 0;
            //ȫԺ���п�
            decimal sumCreditcard = 0;
            //ȫԺ΢��2
            decimal sumOthers = 0;
            #endregion

            #region ���˽������

            curRowY += RowHight;
            for (int iOpr = 0; iOpr < this.m_dtPrepaySum.Rows.Count; iOpr++)
            {
                #region ��һ��

                e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
                e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

                //�տ�Ա
                string balanceEmp = this.m_dtPrepaySum.Rows[iOpr]["BalanceEmp"].ToString().Trim();
                string name = this.m_dtPrepaySum.Rows[iOpr]["Name"].ToString().Trim();
                e.Graphics.DrawString(name, textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
                //��Ʊ����
                string allCount = this.m_dtPrepaySum.Rows[iOpr]["AllCount"].ToString();
                sumAllcount += int.Parse(allCount);
                e.Graphics.DrawString(allCount + "��", textFont, Brushes.Black, bX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
                //��Ʊ���
                string sumMoney = this.m_dtPrepaySum.Rows[iOpr]["SumMoney"].ToString();
                sumAllMoney += decimal.Parse(sumMoney);
                e.Graphics.DrawString("��" + decimal.Parse(sumMoney).ToString("0.00"), textFont, Brushes.Black, cX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
                //��Ʊ����
                string refundmentCount = this.m_dtPrepaySum.Rows[iOpr]["RefundmentCount"].ToString();
                sumRefundmentCount += int.Parse(refundmentCount);
                e.Graphics.DrawString(refundmentCount + "��", textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
                //��Ʊ���
                string refundment = this.m_dtPrepaySum.Rows[iOpr]["Refundment"].ToString();
                sumRefundment += decimal.Parse(refundment);
                e.Graphics.DrawString("��" + decimal.Parse(refundment).ToString("0.00"), textFont, Brushes.Black, eX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
                //�ָ�Ʊ��
                string cancelCount = this.m_dtPrepaySum.Rows[iOpr]["CancelCount"].ToString();
                sumCancelCount += int.Parse(cancelCount);
                e.Graphics.DrawString(cancelCount + "��", textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
                //�ָ����
                string cancelMoney = this.m_dtPrepaySum.Rows[iOpr]["CancelMoney"].ToString();
                sumCancelMoney += decimal.Parse(cancelMoney);
                e.Graphics.DrawString("��" + decimal.Parse(cancelMoney).ToString("0.00"), textFont, Brushes.Black, gX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
                //��ЧƱ��
                string availCount = this.m_dtPrepaySum.Rows[iOpr]["AvailCount"].ToString();
                sumAvailCount += int.Parse(availCount);
                e.Graphics.DrawString(availCount + "��", textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
                //��Ч���
                string availMoney = this.m_dtPrepaySum.Rows[iOpr]["AvailMoney"].ToString();
                sumAvailMoney += decimal.Parse(availMoney);
                e.Graphics.DrawString("��" + decimal.Parse(availMoney).ToString("0.00"), textFont, Brushes.Black, iX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);

                #endregion

                #region �ڶ�������

                //�ڶ���
                curRowY += RowHight;
                e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight * 2);
                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
                e.Graphics.DrawString("�ֽ�", textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight * 2);
                e.Graphics.DrawString("֧Ʊ", textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight * 2);
                e.Graphics.DrawString("���п�", textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight * 2);
                e.Graphics.DrawString("΢��2", textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight * 2);

                //������
                curRowY += RowHight;
                string cash = this.m_dtPrepaySum.Rows[iOpr]["Cash"].ToString();
                sumCash += decimal.Parse(cash);
                e.Graphics.DrawString("��" + decimal.Parse(cash).ToString("0.00"), textFont, Brushes.Black, aX + BORDER, curRowY + 7);

                string cheque = this.m_dtPrepaySum.Rows[iOpr]["Cheque"].ToString();
                sumCheque += decimal.Parse(cheque);
                e.Graphics.DrawString("��" + decimal.Parse(cheque).ToString("0.00"), textFont, Brushes.Black, dX + BORDER, curRowY + 7);

                string creditcard = this.m_dtPrepaySum.Rows[iOpr]["Creditcard"].ToString();
                sumCreditcard += decimal.Parse(creditcard);
                e.Graphics.DrawString("��" + decimal.Parse(creditcard).ToString("0.00"), textFont, Brushes.Black, fX + BORDER, curRowY + 7);

                string others = this.m_dtPrepaySum.Rows[iOpr]["Others"].ToString();
                sumOthers += decimal.Parse(others);
                e.Graphics.DrawString("��" + decimal.Parse(others).ToString("0.00"), textFont, Brushes.Black, hX + BORDER, curRowY + 7);

                e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

                #endregion

                //��ע

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
                            //tilWith = e.Graphics.MeasureString("��ע", textFont);
                            continue;
                        }
                        else
                        {
                            tilWith = e.Graphics.MeasureString(remark, textFont);
                        }

                        e.Graphics.DrawString(balanceDate + "  ��ע", textFont, Brushes.Black, aX + BORDER, curRowY + 7);
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

            #region �ϼ�
            System.Drawing.Font sFont = new Font("����", 10, FontStyle.Bold);//�ϼ���ʹ�õ�����

            curRowY += RowHight / 2;
            e.Graphics.DrawLine(penLine, aX, curRowY, PageWidth - RightWith, curRowY);
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

            e.Graphics.DrawString("�ϼ�", sFont, Brushes.Black, aX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, bX, curRowY, bX, curRowY + RowHight);
            //��Ʊ����
            e.Graphics.DrawString(sumAllcount.ToString() + "��", sFont, Brushes.Black, bX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, cX, curRowY, cX, curRowY + RowHight);
            //��Ʊ���
            e.Graphics.DrawString("��" + sumAllMoney.ToString("0.00"), sFont, Brushes.Black, cX, curRowY + 7);

            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight);
            //��Ʊ����
            e.Graphics.DrawString(sumRefundmentCount.ToString() + "��", sFont, Brushes.Black, dX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, eX, curRowY, eX, curRowY + RowHight);
            //��Ʊ���
            e.Graphics.DrawString("��" + sumRefundment.ToString("0.00"), sFont, Brushes.Black, eX, curRowY + 7);

            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight);
            //�ָ�Ʊ��
            e.Graphics.DrawString(sumCancelCount.ToString() + "��", sFont, Brushes.Black, fX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, gX, curRowY, gX, curRowY + RowHight);
            //�ָ����
            e.Graphics.DrawString("��" + sumCancelMoney.ToString("0.00"), sFont, Brushes.Black, gX, curRowY + 7);

            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight);
            //��ЧƱ��
            e.Graphics.DrawString(sumAvailCount.ToString() + "��", sFont, Brushes.Black, hX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, iX, curRowY, iX, curRowY + RowHight);
            //��Ч���
            e.Graphics.DrawString("��" + sumAvailMoney.ToString("0.00"), sFont, Brushes.Black, iX, curRowY + 7);

            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight);


            //�ڶ���
            curRowY += RowHight;
            e.Graphics.DrawLine(penLine, aX, curRowY, aX, curRowY + RowHight * 2);
            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);
            e.Graphics.DrawString("�ֽ�", sFont, Brushes.Black, aX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, dX, curRowY, dX, curRowY + RowHight * 2);
            e.Graphics.DrawString("֧Ʊ", sFont, Brushes.Black, dX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, fX, curRowY, fX, curRowY + RowHight * 2);
            e.Graphics.DrawString("���п�", sFont, Brushes.Black, fX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, hX, curRowY, hX, curRowY + RowHight * 2);
            e.Graphics.DrawString("΢��2", sFont, Brushes.Black, hX + BORDER, curRowY + 7);

            e.Graphics.DrawLine(penLine, jX, curRowY, jX, curRowY + RowHight * 2);

            //������
            curRowY += RowHight;
            e.Graphics.DrawString("��" + sumCash.ToString("0.00"), sFont, Brushes.Black, aX, curRowY + 7);

            e.Graphics.DrawString("��" + sumCheque.ToString("0.00"), sFont, Brushes.Black, dX, curRowY + 7);

            e.Graphics.DrawString("��" + sumCreditcard.ToString("0.00"), sFont, Brushes.Black, fX, curRowY + 7);

            e.Graphics.DrawString("��" + sumOthers.ToString("0.00"), sFont, Brushes.Black, hX, curRowY + 7);

            e.Graphics.DrawLine(penLine, aX, curRowY + RowHight, PageWidth - RightWith, curRowY + RowHight);

            #endregion

        }

        #region ����һ������������Ա���ܵ�DataTable

        private void BuildReportDataTable()
        {
            m_dtPrepaySum = new DataTable();

            #region �����
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
                string balanceEmp; //����ԱID
                balanceEmp = this.m_dtPrepayInfo.Rows[iRow]["BALANCEEMP_CHR"].ToString();

                DataRow[] reportRow = m_dtPrepaySum.Select("BalanceEmp = '" + balanceEmp + "'");
                if (reportRow.Length == 0)
                {
                    DataRow newRow = m_dtPrepaySum.NewRow();

                    newRow["BalanceEmp"] = balanceEmp;

                    string name = this.m_dtPrepayInfo.Rows[iRow]["LASTNAME_VCHR"].ToString();
                    newRow["Name"] = name;

                    //��Ʊ�������ܽ��
                    decimal sumMoney;
                    int allCount = GetSumMoneyByBalanceEmp(balanceEmp, out sumMoney);
                    newRow["AllCount"] = allCount;
                    newRow["SumMoney"] = sumMoney;


                    //��Ʊ
                    decimal refundment;
                    int refundmentCount = GetRefundmentByBalanceEmp(balanceEmp, out refundment);
                    newRow["RefundmentCount"] = refundmentCount;
                    newRow["Refundment"] = refundment;

                    //�ָ�
                    decimal cancelMoney;
                    int cancelCount = GetCancelByBalanceEmp(balanceEmp, out cancelMoney);
                    newRow["CancelCount"] = cancelCount;
                    newRow["CancelMoney"] = cancelMoney;

                    //��ЧƱ�������
                    decimal availMoney = sumMoney - refundment + cancelMoney;
                    int availCount = allCount - refundmentCount + cancelCount;
                    newRow["AvailCount"] = availCount;
                    newRow["AvailMoney"] = availMoney;

                    // �ֽ�
                    newRow["Cash"] = GetCuyCateMoney(balanceEmp, 1);
                    // ֧Ʊ
                    newRow["Cheque"] = GetCuyCateMoney(balanceEmp, 2);
                    // ���п�
                    newRow["Creditcard"] = GetCuyCateMoney(balanceEmp, 3);
                    // wx2
                    newRow["wx2"] = GetCuyCateMoney(balanceEmp, 4);
                    // ΢��
                    newRow["wechatPay"] = GetCuyCateMoney(balanceEmp, 8);
                    // ֧����.����
                    newRow["aliPay"] = GetCuyCateMoney(balanceEmp, 6);
                    //// ֧����.����
                    //newRow["aliPay"] = GetCuyCateMoney(balanceEmp, 9);
                    // ����
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

        #region ��m_dtPrepayInfo��ȡ���ݵķ���


        //��Ʊ�ܽ��
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

        //��Ʊ
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

        //�ָ�
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
