using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;

namespace iCare
{
    /// <summary>
    /// 流产病历记录打印类
    /// </summary>
    public class clsIMR_AB_abbortionPrintTool : clsInpatMedRecPrintBase
    {

        public clsIMR_AB_abbortionPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //构造函数
        }

        /// <summary>
        /// 设置打印的边距格式
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 5, 145, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 15, e.PageBounds.Height - 215);
        }
        ///// <summary>
        ///// 标题文字部分  纪录公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    int p_intPosY = 40;
        //    e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), Brushes.Black, 340, p_intPosY);
        //    p_intPosY += 30;
        //    e.Graphics.DrawString("流     产     病     历", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 280, p_intPosY);
        //}

        /// <summary>
        /// 设置打印行
        /// </summary>
        protected override void m_mthSetPrintLineArr()
        {        
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{　 new  clsPrintPatientFixInfo("流     产     病     历", 300),
																		  // new clsPrintFixInfo("流     产     病     历", 300),
						                                                   new clsPrintMonthHistory(),
						                                                   new clsPrintMerryHistory(),
				                                                           new clsPrintBrothHistory(),
                                                                           new clsPrintHistoryHistory(),    
                                                                           //new clsPrintHomeHistroy(),
                                                                           //new clsPrintInPatMedRecCaseMain(),
                                                                           new clsPrintNowDescription(),
                                                                           new clsPrintTiGeCheck(),
                                                                           new clsPrintWoman(),
                                                                           new clsPrintYiWu(),
                                                                           new clsPrintChuLi(),
                                                                           new clsPrintRecorder()
																	   });
        }
        /// <summary>
        /// 打印第一页固定内容 公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        /// </summary>
        //private class clsPrintFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private bool m_blnIsFirstPrint = true;
        //    private string m_strPrintText = "";
        //    private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_blnIsFirstPrint)
        //        {
        //            Font m_fotSmallFont = new Font("SimSun", 12);
        //            SolidBrush m_slbBrush = new SolidBrush(Color.Black);
        //            p_intPosY = 110;

        //            p_objGrp.DrawString("姓名：", m_fotSmallFont, m_slbBrush, 50, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, 100, p_intPosY);

        //            p_objGrp.DrawString("性别：", m_fotSmallFont, m_slbBrush, 185, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, 230, p_intPosY);

        //            p_objGrp.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 260, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 305, p_intPosY);

        //            p_objGrp.DrawString("病区：", m_fotSmallFont, m_slbBrush, 360, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 410, p_intPosY);

        //            p_objGrp.DrawString("床号：", m_fotSmallFont, m_slbBrush, 555, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 605, p_intPosY);

        //            p_objGrp.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 655, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 715, p_intPosY);

        //            p_intPosY += 30;

        //            p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
        //            p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, m_fotSmallFont, m_slbBrush, 200, p_intPosY);
        //            p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 350, p_intPosY);
        //            p_intPosY += 20;
        //            p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
        //            p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

        //            //p_intPosY += 20;
        //            if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }



        //            if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //            {
        //                p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, 400, p_intPosY);
        //            }
        //            else
        //            {
        //                p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, 400, p_intPosY);
        //            }

        //            //m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
        //            int intRealHeight;
        //            Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
        //            m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

        //            p_intPosY += 30;
        //            m_blnHaveMoreLine = false;

        //            m_strPrintText = "";



        //            p_fntNormal.Dispose();


        //            m_blnHaveMoreLine = false;


        //        }//m_blnIsFirstPrint 结束

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

        //            p_intPosY += 20;

        //            intLine++;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;

        //        m_blnIsFirstPrint = true;
        //    }

        //}//第一页固定打印结束

        /// <summary>
        /// 月经史
        /// </summary>
        private class clsPrintMonthHistory : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                //if (m_hasItems != null)
                //    if (m_hasItems.Contains("月经史"))
                //        objItemContent = m_hasItems["月经史"] as clsInpatMedRec_Item;
                //if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                //{
                //    m_blnHaveMoreLine = false;
                //    return;
                //}
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("月经史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("初潮年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>月经史>>初潮年龄") && m_hasItemDetail["病史>>月经史>>初潮年龄"] != "")
                        {                 
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>初潮年龄"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("周期:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 195, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>月经史>>周期") && m_hasItemDetail["病史>>月经史>>周期"] != "")
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>周期"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 245, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("量:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 295, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>月经史>>量") && m_hasItemDetail["病史>>月经史>>量"] != "")
                        { 
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>量"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 320, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("色:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 365, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>月经史>>色") && m_hasItemDetail["病史>>月经史>>色"] != "")
                        {
                        
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>色"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("未次月经:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 470, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>经史>>未次月经") && m_hasItemDetail["病史>>经史>>未次月经"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>经史>>未次月经"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 555, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("经期情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>月经史>>经期情况") && m_hasItemDetail["病史>>月经史>>经期情况"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>经期情况"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }

                        //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }


            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 结婚史
        /// </summary>
        private class clsPrintMerryHistory : clsIMR_PrintLineBase
        {

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("结婚史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("结婚年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>结婚史>>结婚年龄") && m_hasItemDetail["病史>>结婚史>>结婚年龄"] != "")
                        {                        
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>结婚史>>结婚年龄"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 155, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("爱人年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 215, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>结婚史>>爱人年龄") && m_hasItemDetail["病史>>结婚史>>爱人年龄"] != "")
                        {
                        
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>结婚史>>爱人年龄"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 295, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("职业:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>结婚史>>职业") && m_hasItemDetail["病史>>结婚史>>职业"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>结婚史>>职业"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("健康否:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>>>结婚史>>健康否") && m_hasItemDetail["病史>>>>结婚史>>健康否"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>>>结婚史>>健康否"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 535, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("性病史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 590, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>结婚史>>性病史") && m_hasItemDetail["病史>>结婚史>>性病史"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>结婚史>>性病史"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 650, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
 
                        }

                        //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }


            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }


        /// <summary>
        /// 生产史
        /// </summary>
        private class clsPrintBrothHistory : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("生产史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        p_objGrp.DrawString("初产年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>初产年龄") && m_hasItemDetail["病史>>生产史>>初产年龄"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>初产年龄"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 158, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("末次生产年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 195, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>末次生产年龄") && m_hasItemDetail["病史>>生产史>>末次生产年龄"] != "")
                        {
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>末次生产年龄"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("孕次:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>孕次数") && m_hasItemDetail["病史>>生产史>>孕次数"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>孕次数"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("大产次:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>大产次数") && m_hasItemDetail["病史>>生产史>>大产次数"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>大产次数"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("流产次 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("自然流产:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>自然流产") && m_hasItemDetail["病史>>生产史>>自然流产"] != "")
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>自然流产"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("人工流产:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>生产史>>人工流产次数") && m_hasItemDetail["病史>>生产史>>人工流产次数"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>人工流产次数"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {

                            p_intPosY += 20;
                        }
                       

                        //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }


            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }

        }

        /// <summary>
        /// 现病史 病史>>现病史
        /// </summary>
        private class clsPrintHistoryHistory : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("既往史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>既往史") && m_hasItemDetail["病史>>既往史"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>既往史"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("有否进行避孕:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>既往史>>有否进行避孕") && m_hasItemDetail["病史>>既往史>>有否进行避孕"] != "")
                        {
                       
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>既往史>>有否进行避孕"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 145, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("现存子女数:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>既往史>>现存子女数") && m_hasItemDetail["病史>>既往史>>现存子女数"] != "")
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>既往史>>现存子女数"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 345, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
 
                        }

                        p_objGrp.DrawString("家族史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        if (m_hasItemDetail.Contains("病史>>家族史") && m_hasItemDetail["病史>>家族史"] != "")
                        {
                          p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>家族史"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;

                        }
                        p_objGrp.DrawString("主诉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("病史>>主诉") && m_hasItemDetail["病史>>主诉"] != "")
                        {
                            
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>主诉"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;

                        }

                        //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }


            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 主诉
        /// </summary>
        //private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
        //    private bool m_blnIsFirstPrint = true;
        //    private string strPrintText = "  　";
        //    private clsInpatMedRec_Item objItemContent = null;
        //    private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {

        //        if (m_hasItems != null)
        //            if (m_hasItems.Contains("病史>>主诉"))
        //                objItemContent = m_hasItems["病史>>主诉"] as clsInpatMedRec_Item;
        //        if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
        //            //{
        //            //    m_blnHaveMoreLine = true;
        //            //    return;
        //            //}

        //            p_objGrp.DrawString("主诉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            //if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后处理>>手术经过"))
        //            //{
        //            strPrintText += m_hasItemDetail["病史>>主诉"];
        //            p_intPosY += 20;
        //            //}
        //            //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
        //            //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
        //            //p_fntNormal.Dispose();

        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

        //            p_intPosY += 20;

        //            intLine++;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;

        //        m_blnIsFirstPrint = true;
        //    }

        //}

        ///// <summary>
        ///// 家族史
        ///// </summary>
        //private class clsPrintHomeHistroy : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private string strPrintText = "  　";
        //    private clsInpatMedRec_Item objItemContent = null;
        //    private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {

        //        if (m_hasItems != null)
        //            if (m_hasItems.Contains("病史>>家族史"))
        //                objItemContent = m_hasItems["病史>>家族史"] as clsInpatMedRec_Item;
        //        if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
        //            //{
        //            //    m_blnHaveMoreLine = true;
        //            //    return;
        //            //}

        //            p_objGrp.DrawString("家族史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
        //            //{
        //            //    strPrintText += m_hasItemDetail["病史>>家族史"];
        //                p_intPosY += 20;
        //            //}
        //             m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

        //            //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
        //            //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
        //            //p_fntNormal.Dispose();
        //            m_blnIsFirstPrint = false;
        //        }
        //        #region
        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

        //            p_intPosY += 20;

        //            intLine++;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }
        //        #endregion

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;

        //        m_blnIsFirstPrint = true;
        //    }
        //}

        /// <summary>
        /// 现病史
        /// </summary>
        private class clsPrintNowDescription : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　   ";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("病史>>现病史"))
                        objItemContent = m_hasItems["病史>>现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    p_objGrp.DrawString("现病史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>现病史"))
                    {
                        strPrintText += m_hasItemDetail["病史>>现病史"];
                        //p_intPosY += 20;
                    }
                    if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    p_fntNormal.Dispose();

                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }

        }


        /// <summary>
        /// 体格检查  检查/处理>>体格检查
        /// </summary>
        private class clsPrintTiGeCheck : clsIMR_PrintLineBase
        {

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　    :";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("检查/处理>>体格检查"))
                        objItemContent = m_hasItems["检查/处理>>体格检查"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    p_objGrp.DrawString("体格检查", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("检查/处理>>体格检查"))
                    {
                        strPrintText += m_hasItemDetail["检查/处理>>体格检查"];
                        //p_intPosY += 20;
                    }
                    if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    p_fntNormal.Dispose();

                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }


        /// <summary>
        /// 妇科情况 
        /// </summary>
        private class clsPrintWoman : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　    ";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("检查/处理>>妇科情况"))
                        objItemContent = m_hasItems["检查/处理>>妇科情况"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    p_objGrp.DrawString("妇科情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("检查/处理>>妇科情况"))
                    {
                        strPrintText += m_hasItemDetail["检查/处理>>妇科情况"];
                        //p_intPosY += 20;
                    }
                    if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    p_fntNormal.Dispose();

                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }


        /// <summary>
        ///印务 
        /// </summary>
        private class clsPrintYiWu : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("检查/处理>>印象"))
                        objItemContent = m_hasItems["检查/处理>>印象"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    p_objGrp.DrawString("印象:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("检查/处理>>印象"))
                    {
                        strPrintText += m_hasItemDetail["检查/处理>>印象"];
                        //p_intPosY += 20;
                    }
                    if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    p_fntNormal.Dispose();

                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }

        }

        /// <summary>
        /// 处理
        /// </summary>
        private class clsPrintChuLi : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("检查>>处理"))
                        objItemContent = m_hasItems["检查>>处理"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    p_objGrp.DrawString("处理:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail != null && m_hasItemDetail.Contains("检查>>处理"))
                    {
                        strPrintText += m_hasItemDetail["检查>>处理"];
                        //p_intPosY += 20;
                    }
                    if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    p_fntNormal.Dispose();

                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }

        }

        /// <summary>
        /// 打印病历记录者
        /// </summary>
        //private class clsPrintRecorder : clsIMR_PrintLineBase
        //{
        //    private bool m_blnIsFirstPrint = true;
        //    private string strPrintText = "记录者：";
        //    private clsInpatMedRec_Item objItemContent = null;
        //    private Font p_fntNormal = new Font("SimSun", 11, FontStyle.Bold);

        //    public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        //    {
        //        if (m_objContent != null)
        //        {
        //            strPrintText += new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //        }
        //        if(m_blnIsFirstPrint)
        //        {
        //            if(m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }

        //            p_objGrp.DrawString(strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 480, p_intPosY + 10);
        //            p_intPosY += 40;

        //            p_fntNormal.Dispose();

        //            m_blnIsFirstPrint = false;
        //        }
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
        //        m_blnIsFirstPrint = true;
        //    }
        //}

        /// <summary>
        ///  打印病历记录者
        /// </summary>
        private class clsPrintRecorder : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "lsvSign")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("记录者： ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 220, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_blnHaveMoreLine = true;
                }
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        internal static Hashtable m_hasItemDetail;
        /// <summary>
        /// 把所有项按描述为键放入Hastable
        /// </summary>
        /// <param name="p_hasItem"></param>
        /// <param name="p_ctlItem"></param>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            if (p_objItemArr == null)
                return null;
            Hashtable hasItem = new Hashtable(400);
            m_hasItemDetail = new Hashtable(400);
            foreach (clsInpatMedRec_Item objItem in p_objItemArr)
            {
                try
                {
                    if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
                    {
                        continue;
                    }
                    else
                    {
                        m_hasItemDetail.Add(objItem.m_strItemName, objItem.m_strItemContent);
                        hasItem.Add(objItem.m_strItemName, objItem);

                    }
                }
                catch { continue; }
            }
            return hasItem;
        }

    }
}
