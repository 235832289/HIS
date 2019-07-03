using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 打印人工晶体植入手术记录的摘要说明。
    /// </summary>
    public class clsIMR_EmbeddedOPSPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_EmbeddedOPSPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        
        

        /// <summary>
        /// 要打印的部分
        /// </summary>
        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo(), 
                                                                          new clsPrintActionstimes(),
                                                                            new clsPrint31(),                                                    
				                                                          new clsPrintActions(),
                                                                             new  clsPrint10(),
                                                                          new  clsPrint11(),
                                                                          new clsPrintActionsOne(),
                                                                          new clsPrintActionsTwo(),
                                                                           new clsPrint1(),
                                                                         new clsPrint2(),
                                                                         new clsPrint3(),
                                                                         new clsPrint4(),
                                                                         new clsPrint5(),
                                                                         new clsPrint6(),
                                                                         new clsPrint7(),
                                                                         new clsPrint8(),
                                                                         new clsPrint9(),
                                                                         new clsPrint10(),
                                                                         new clsPrint11(),
                                                                         new clsPrint12()
                                                                         
																	   });
        }


        /// <summary>
        /// 打印第一页固定内容 公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);
                p_objGrp.DrawString("人工晶体植入手术记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 350, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
                //p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, 370, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 600, 130);
                p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }/// <summary>
        /// 设置打印的边距格式
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 5, 145, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 5, e.PageBounds.Height - 210);
        }
        /// <summary>
        /// 标题文字部分  纪录公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        /// </summary>
        /// <param name="e"></param>       
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //int p_intPosY = 40;
            //e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), Brushes.Black, 340, p_intPosY);
            //p_intPosY += 30;
            //e.Graphics.DrawString("人工晶体植入手术记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 280, p_intPosY);
        }

        /// <summary>
        /// 设置打印的边距格式
        /// </summary>
        /// <param name="e"></param>
        
        #region
        /*
        private class clsPrintFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string m_strPrintText = "";
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    Font m_fotSmallFont = new Font("SimSun", 12);
                    SolidBrush m_slbBrush = new SolidBrush(Color.Black);
                    //p_intPosY = 110;

                    p_objGrp.DrawString("姓名：", m_fotSmallFont, m_slbBrush, 50, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, 100, p_intPosY);

                    p_objGrp.DrawString("性别：", m_fotSmallFont, m_slbBrush, 185, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, 230, p_intPosY);

                    p_objGrp.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 260, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 305, p_intPosY);

                    p_objGrp.DrawString("病区：", m_fotSmallFont, m_slbBrush, 360, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 410, p_intPosY);

                    p_objGrp.DrawString("床号：", m_fotSmallFont, m_slbBrush, 555, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 605, p_intPosY);

                    p_objGrp.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 655, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 715, p_intPosY);

                    p_intPosY += 30;

                    p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
                    p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, m_fotSmallFont, m_slbBrush, 200, p_intPosY);
                    p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 350, p_intPosY);
                    p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, m_fotSmallFont, m_slbBrush, 450, p_intPosY);

                    p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

                    p_intPosY += 20;
                    if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }



                    if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                    {
                        p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, 50, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, 50, p_intPosY);
                    }

                    //m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                    int intRealHeight;
                    Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

                    p_intPosY += 30;
                    m_blnHaveMoreLine = false;

                    m_strPrintText = "";



                    p_fntNormal.Dispose();


                    m_blnHaveMoreLine = false;


                }//m_blnIsFirstPrint 结束

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

        }//第一页固定打印结束      

        
      
        private class clsPrintFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string m_strPrintText = "";
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    Font m_fotSmallFont = new Font("SimSun", 12);
                    SolidBrush m_slbBrush = new SolidBrush(Color.Black);
                    p_intPosY = 110;

                    p_objGrp.DrawString("姓名：", m_fotSmallFont, m_slbBrush, 50, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, 100, p_intPosY);

                    p_objGrp.DrawString("性别：", m_fotSmallFont, m_slbBrush, 185, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, 230, p_intPosY);

                    p_objGrp.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 260, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 305, p_intPosY);

                    p_objGrp.DrawString("病区：", m_fotSmallFont, m_slbBrush, 360, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 410, p_intPosY);

                    p_objGrp.DrawString("床号：", m_fotSmallFont, m_slbBrush, 555, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 605, p_intPosY);

                    p_objGrp.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 655, p_intPosY);

                    p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 715, p_intPosY);

                    p_intPosY += 30;

                    p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
                    p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, m_fotSmallFont, m_slbBrush, 200, p_intPosY);
                    p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 350, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
                    p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

                    //p_intPosY += 20;
                    if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }



                    if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                    {
                        p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, 400, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, 400, p_intPosY);
                    }

                    //m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                    int intRealHeight;
                    Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

                    p_intPosY += 30;
                    m_blnHaveMoreLine = false;

                    m_strPrintText = "";



                    p_fntNormal.Dispose();


                    m_blnHaveMoreLine = false;


                }//m_blnIsFirstPrint 结束

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

        }//第一页固定打印结束 */
        #endregion   
        
   
        // <summary>
        // 术前诊断
        // </summary>
        //private class clsPrint31 : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
        //     <summary>
        //     相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //     </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private clsInpatMedRec_Item objItemContent = null;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_hasItems != null)
        //            if (m_hasItems.Contains("手术>>术前诊断"))
        //                objItemContent = m_hasItems["手术>>术前诊断"] as clsInpatMedRec_Item;
        //        if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;

        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            p_objGrp.DrawString("术前诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if (m_objContent != null)
        //            {
        //                m_mthMakeText(new string[] { "" }, new string[] { "手术>>术前诊断" }, ref strAllText, ref strXml);
        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
        //            m_blnIsFirstPrint = false;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
        //            p_intPosY += 20;
        //        }
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_blnHaveMoreLine = true;
        //        }
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


        // <summary>
        //术前诊断
        // </summary>

        /// <summary>
        /// 手术日期时间
        /// </summary>
        private class clsPrintActionstimes : clsIMR_PrintLineBase
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

                        if (m_hasItemDetail.Contains("手术>>手术日期"))
                        {
                            p_objGrp.DrawString("手术日期:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);


                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术日期"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
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


        private class clsPrint31 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
             //<summary>
             //相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
             //</summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术>>术前诊断"))
                        objItemContent = m_hasItems["手术>>术前诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术前诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术>>术前诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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


        //#endregion

        /// <summary>
        /// 手术
        /// </summary>
        private class clsPrintActions : clsIMR_PrintLineBase
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

                        //if (m_hasItemDetail.Contains("手术>>手术日期"))
                        //{
                        //    p_objGrp.DrawString("手术日期:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                           
                        //    p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术日期"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                        //    p_intPosY += 20;
                        //}
                        //if (m_hasItemDetail.Contains("手术>>术前诊断"))
                        //{
                        //    p_objGrp.DrawString("术前诊断:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        //    p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>术前诊断"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                        //    p_intPosY += 20;
                        //}
                        if (m_hasItemDetail.Contains("手术>>手术名称"))
                        {
                            p_objGrp.DrawString("手术名称:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术名称"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术>>麻醉方法>>局麻用") && m_hasItemDetail["手术>>麻醉方法>>局麻用"] != "")
                        {
                            p_objGrp.DrawString("麻醉方法:局麻用", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);                          
                         
                        }
                        if (m_hasItemDetail.Contains("手术>>麻醉方法>>局麻用1"))
                        {                            
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>麻醉方法>>局麻用1"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术>>麻醉方法>>全麻用") && m_hasItemDetail["手术>>麻醉方法>>全麻用"] != "")
                        {
                            p_objGrp.DrawString("麻醉方法:全麻用", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);                          
                        }
                        if (m_hasItemDetail.Contains("手术>>麻醉方法>>全麻用1"))
                        {
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>麻醉方法>>全麻用1"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术>>术者"))
                        {
                            p_objGrp.DrawString("术者:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>术者"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术>>助手"))
                        {
                            p_objGrp.DrawString("助手:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>助手"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术>>麻醉师"))
                        {
                            p_objGrp.DrawString("麻醉师:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>麻醉师"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 340, p_intPosY);
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
        /// 手术II
        /// </summary>
        private class clsPrintActionsOne : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

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
                        p_objGrp.DrawString("经过", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("1、常规消毒铺巾。", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_intPosY += 20;

                        p_objGrp.DrawString("2、麻醉，球后注射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>2、麻醉，球后注射"))
                        {                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>2、麻醉，球后注射"]) + " ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("眼轮匝肌，眼脸结膜下:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>眼轮匝肌，眼脸结膜下"))
                        {                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>眼轮匝肌，眼脸结膜下"]) + " ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 535, p_intPosY);
                        }
                        p_intPosY += 20;
                        p_objGrp.DrawString("球周注射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>球周注射"))
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>球周注射"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 98, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
 
                        }
                        p_objGrp.DrawString("3、开睑:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>开脸>>牵引缝线") && m_hasItemDetail["手术经过>>开脸>>牵引缝线"] != "")
                        {                           
                            p_objGrp.DrawString("牵引缝线:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 90, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>开脸>>开脸器") && m_hasItemDetail["手术经过>>开脸>>开脸器"] != "")
                        {
                            p_objGrp.DrawString("开睑器:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 90, p_intPosY);
                        }
                        p_intPosY += 20;                    
                        p_objGrp.DrawString("4、眼球固定:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>4、眼球固定") )
                        {                     
                           p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>4、眼球固定"]) + "上直肌缝线", p_fntNormalText, Brushes.Black, m_intRecBaseX + 110, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("5、作结膜辨:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>5、作结膜辨>>穹窿") && m_hasItemDetail["手术经过>>5、作结膜辨>>穹窿"] != "")
                        {                         
                            p_objGrp.DrawString("穹窿", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                            p_objGrp.DrawString("为基底", p_fntNormalText, Brushes.Black, m_intRecBaseX + 185, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>5、作结膜辨>>角膜缘") && m_hasItemDetail["手术经过>>5、作结膜辨>>角膜缘"] != "")
                        {
                            
                            p_objGrp.DrawString("角膜缘", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                            p_objGrp.DrawString("为基底", p_fntNormalText, Brushes.Black, m_intRecBaseX + 185, p_intPosY);
                            //p_intPosY += 20;                           
                        }
                        //else
                        //{
                        p_intPosY += 20;
                        //}
                        p_objGrp.DrawString("6、角膜缘板层切开:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>6、角膜缘板层切开>>距角膜缘前界"))
                        {
                            p_objGrp.DrawString("距角膜缘前界", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>6、角膜缘板层切开>>距角膜缘前界"]) + "mm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 280, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("角膜缘板层切开>>用刀片") && m_hasItemDetail["角膜缘板层切开>>用刀片"] != "")
                        {
                            p_objGrp.DrawString("用刀片:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);                            
                        }
                        if (m_hasItemDetail.Contains("角膜缘板层切开>>用一次性手术刀") && m_hasItemDetail["角膜缘板层切开>>用一次性手术刀"] != "")
                        {
                            p_objGrp.DrawString("用一次性手术刀:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("角膜缘板层切开>>宝石刀") && m_hasItemDetail["角膜缘板层切开>>宝石刀"] != "")
                        {
                            p_objGrp.DrawString("宝石刀:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        }
                        //if (m_hasItemDetail.Contains("角膜缘板层切开>>针头") && m_hasItemDetail["角膜缘板层切开>>针头"] != "")
                        //{
                        //    p_objGrp.DrawString("针头:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        //}
                        if (m_hasItemDetail.Contains("手术经过>>用刀片，由>>开始点"))
                        {
                            p_objGrp.DrawString("由:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 410, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>用刀片，由>>开始点"]) + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>用刀片>>结束点"))
                        {
                            p_objGrp.DrawString("点至:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 510, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>用刀片>>结束点"]) + "点", p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("7、前房穿刺:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("前房穿刺>>用刀片") && m_hasItemDetail["前房穿刺>>用刀片"] != "")
                        {                            
                            p_objGrp.DrawString("用刀片:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("前房穿刺>>用一次性手术刀") && m_hasItemDetail["前房穿刺>>用一次性手术刀"] != "")
                        {
                            p_objGrp.DrawString("用一次性手术刀:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("前房穿刺>>宝石刀") && m_hasItemDetail["前房穿刺>>宝石刀"] != "")
                        {                         
                            p_objGrp.DrawString("宝石刀:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("前房穿刺>>针头") && m_hasItemDetail["前房穿刺>>针头"] != "")
                        {                         
                            p_objGrp.DrawString("针头:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("手术经过>>7、前房穿刺"))
                        {                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>7、前房穿刺"]) + "点方位", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("8、晶体前囊切开:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("晶体前囊切开>>用针囊针头") && m_hasItemDetail["晶体前囊切开>>用针囊针头"] != "")
                        {                          
                            p_objGrp.DrawString("用针囊针头", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("晶体前囊切开>>用电切头") && m_hasItemDetail["前晶体前囊切开>>用电切头"] != "")
                        {
                        
                            p_objGrp.DrawString("用电切头", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("晶体前囊切开>>用撕囊钳") && m_hasItemDetail["晶体前囊切开>>用撕囊钳"] != "")
                        {

                            p_objGrp.DrawString("用撕囊镊", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("晶体前囊切开>>用超声撕囊仪") && m_hasItemDetail["晶体前囊切开>>用超声撕囊仪"] != "")
                        {

                            p_objGrp.DrawString("用超声撕囊仪", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("晶体前囊切开>>注粘稠剂") && m_hasItemDetail["晶体前囊切开>>注粘稠剂"] != "")
                        {
                        
                            p_objGrp.DrawString("注粘稠剂", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("晶体前囊切开>>注入bss") && m_hasItemDetail["晶体前囊切开>>注入bss"] != "")
                        {                       
                            p_objGrp.DrawString("注入bss", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("手术经过>>8、晶体前囊切开>>截囊形态>>大小"))
                        {
                            p_objGrp.DrawString("截囊形态,直径:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 340, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>8、晶体前囊切开>>截囊形态>>大小"]) + " mm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 490, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("9、用角膜剪扩大角膜缘切口:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过>>9、用角膜剪扩大角膜缘切口>>开始点"))
                        {
                            p_objGrp.DrawString("由", p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);                       
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>9、用角膜剪扩大角膜缘切口>>开始点"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 263, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>9、用角膜剪扩大角膜缘切口>>结束点"))
                        {
                            p_objGrp.DrawString("点至:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 320, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>9、用角膜剪扩大角膜缘切口>>结束点"]) + "点", p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>9、用角膜剪扩大角膜缘切口>>阶梯形"))
                        {
                            p_objGrp.DrawString("阶梯形:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>9、用角膜剪扩大角膜缘切口>>阶梯形"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>9、用角膜剪扩大角膜缘切口>>手术经过>>9、用角膜剪扩大角膜缘切口>>余形"))
                        {
                            p_objGrp.DrawString("余形:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>9、用角膜剪扩大角膜缘切口>>手术经过>>9、用角膜剪扩大角膜缘切口>>余形"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术经过>>9、用角膜剪扩大角膜缘切口>>垂直"))
                        {
                            p_objGrp.DrawString("垂直:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>9、用角膜剪扩大角膜缘切口>>垂直"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("10、预置缝线，:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术经过ＩＩ>>10、预置缝线>>有") && m_hasItemDetail["手术经过ＩＩ>>10、预置缝线>>有"] != "")
                        {                      
                            p_objGrp.DrawString("有:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }
                        if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>10、预置缝线>>无") && m_hasItemDetail["手术>>手术经过ＩＩ>>10、预置缝线>>无"] != "")
                        {                       
                            p_objGrp.DrawString("无:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        }

                        if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>10、预置缝线>>无>>0丝线") && m_hasItemDetail["手术>>手术经过ＩＩ>>10、预置缝线>>无>>0丝线"] != "")
                        {
                            p_objGrp.DrawString("0丝线:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>10、预置缝线>>无>>0丝线"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);
                            //p_intPosY += 20;
                        }

                        if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>10、预置缝线>>无>>0尼龙线") && m_hasItemDetail["手术>>手术经过ＩＩ>>10、预置缝线>>无>>0尼龙线"] != "")
                        {
                            p_objGrp.DrawString("0尼龙线:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>10、预置缝线>>无>>0尼龙线"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 425, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("11、娩出晶体核方式:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>11、娩出晶体核方式"))
                        {                       
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>11、娩出晶体核方式"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
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
        /// 手术III
        /// </summary>
         private class clsPrintActionsTwo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

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
                         p_objGrp.DrawString("12、缝合：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         int int12X = 0;
                         if (m_hasItemDetail.Contains("缝合>>间断") && m_hasItemDetail["缝合>>间断"] != "")
                         {
                             int12X = m_intRecBaseX + 85;
                             p_objGrp.DrawString("间断", p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);
                         }
                         if (m_hasItemDetail.Contains("缝合>>连续") && m_hasItemDetail["缝合>>连续"] != "")
                         {
                             int12X = m_intRecBaseX + 85;
                             p_objGrp.DrawString("连续", p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);
                         }
                         if (m_hasItemDetail.Contains("缝合>>8字") && m_hasItemDetail["缝合>>8字"] != "")
                         {
                             int12X = m_intRecBaseX + 85;
                             p_objGrp.DrawString("8字", p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);
                         }
                         if (m_hasItemDetail.Contains("缝合>>0丝线") && m_hasItemDetail["缝合>>0丝线"] != "")
                         {
                             int12X += 85;
                             p_objGrp.DrawString(Convert.ToString(m_hasItemDetail["缝合>>0丝线编辑"]) + "0丝线", p_fntNormalText, Brushes.Black, int12X, p_intPosY);
                             //p_objGrp.DrawString("0丝线", p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);
                         }
                         if (m_hasItemDetail.Contains("缝合>>尼龙") && m_hasItemDetail["缝合>>尼龙"] != "")
                         {
                             int12X += 85;
                             p_objGrp.DrawString(Convert.ToString(m_hasItemDetail["缝合>>0尼龙编辑"]) + "0尼龙线", p_fntNormalText, Brushes.Black, int12X, p_intPosY);
                             //p_objGrp.DrawString("尼龙", p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);
                         }
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>共多少针"))
                         {
                             p_objGrp.DrawString("共:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>共多少针"]) + "针", p_fntNormalText, Brushes.Black, m_intRecBaseX + 215, p_intPosY);
                             //p_intPosY += 20;
                         }
                            p_objGrp.DrawString("深度:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 305, p_intPosY);
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>深度>>3/4") && m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>深度>>3/4"] != "")
                         {
                             p_objGrp.DrawString("3/4", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                           
                         }
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>深度>>2/3") && m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>深度>>2/3"] != "")
                         {
                             p_objGrp.DrawString("2/3", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                            
                         }
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>深度>>1/2") && m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>深度>>1/2"] != "")
                         {
                             p_objGrp.DrawString("1/2", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                            
                         }

                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>线结>>埋藏") && m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>线结>>埋藏"] != "")
                         {
                             p_objGrp.DrawString("线结:埋藏", p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>12、缝合>>线结>>未埋藏") && m_hasItemDetail["手术>>手术经过ＩＩ>>12、缝合>>线结>>未埋藏"] != "")
                         {
                             p_objGrp.DrawString("线结:未埋藏", p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                             //p_intPosY += 20;
                         }
                         //else
                         //{
                         //    p_intPosY += 20;
                         //}
                         p_intPosY += 20;
                           p_objGrp.DrawString("13、", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                          if (m_hasItemDetail.Contains("手术经过II>>灌注抽吸晶体皮质")  && m_hasItemDetail["手术经过II>>灌注抽吸晶体皮质"] != "")
                         {                           
                               p_objGrp.DrawString("灌注抽吸晶体皮质", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                             //p_intPosY += 20;
                         }  
                          if (m_hasItemDetail.Contains("手术经过II>>phaio")  && m_hasItemDetail["手术经过II>>phaio"] != "")
                         {
                             p_objGrp.DrawString("phaio晶体皮质", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                         }
                         p_objGrp.DrawString("用：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 228, p_intPosY); 
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>用生理盐水") && m_hasItemDetail["手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>用生理盐水"] != "")
                         {
                             p_objGrp.DrawString("生理盐水", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);                      
                             //p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>用生理盐水"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("生理盐水>>林格氏液") && m_hasItemDetail["生理盐水>>林格氏液"] != "")
                         {
                             p_objGrp.DrawString("林格氏液:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("B.S.S") && m_hasItemDetail["B.S.S"] != "")
                         {
                             p_objGrp.DrawString("B.S.S:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                         }

                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>林格氏液>>ml") && m_hasItemDetail["手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>林格氏液>>ml"] != "")
                         {

                             p_objGrp.DrawString(strPrintText = "共" + Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩ>>13、灌注抽吸晶体皮质>>林格氏液>>ml"]) + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
                         }

                         if (m_hasItemDetail.Contains("生理盐水>>双腔管") && m_hasItemDetail["生理盐水>>双腔管"] != "")
                         {
                             p_objGrp.DrawString("双腔管", p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("生理盐水>>I.A.S") && m_hasItemDetail["生理盐水>>I.A.S"] != "")
                         {
                             p_objGrp.DrawString("I.A.S", p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);

                         }
                         
                         p_intPosY += 20;

                         p_objGrp.DrawString("14、植入后房型人工晶体:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>单手法") && m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>单手法"] != "")
                         {
                             p_objGrp.DrawString("单手法:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 205, p_intPosY);
                         }

                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>双手法") && m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>双手法"] != "")
                         {
                             p_objGrp.DrawString("双手法", p_fntNormalText, Brushes.Black, m_intRecBaseX + 205, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("植入人工晶体>>Healon") && m_hasItemDetail["植入人工晶体>>Healon"] != "")
                         {
                             p_objGrp.DrawString("用Healon", p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("植入人工晶体>>甲基纤维素") && m_hasItemDetail["植入人工晶体>>甲基纤维素"] != "")
                         {
                             p_objGrp.DrawString("甲基纤维素", p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("植入人工晶体>>过滤空气泡") && m_hasItemDetail["植入人工晶体>>过滤空气泡"] != "")
                         {
                             p_objGrp.DrawString("过滤空气泡", p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);

                         }
                         if (m_hasItemDetail.Contains("植入人工晶体>>玻璃酸纳") && m_hasItemDetail["植入人工晶体>>玻璃酸纳"] != "")
                         {
                             p_objGrp.DrawString("玻璃酸纳", p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);

                         }
                         p_objGrp.DrawString("实际植入人工晶体度数:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 340, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶体度数"))
                         {                             
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶体度数"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 520, p_intPosY);
                             p_intPosY += 20;
                         }
                         else
                         {
                              p_intPosY += 20;
                         }
                            p_objGrp.DrawString("厂家:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶>>厂家"))
                         {                          
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶>>厂家"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 55, p_intPosY);
                             //p_intPosY += 20;
                         }
                            p_objGrp.DrawString("型号:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶>>型号"))
                         {                          
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>实际植入人工晶>>型号"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 475, p_intPosY);
                             p_intPosY += 20;
                         }
                          else
                         {
                              p_intPosY += 20;
                         }
                            p_objGrp.DrawString("光学面直径:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过>>光学面直径"))
                         {                          
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>光学面直径"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 125, p_intPosY);
                             //p_intPosY += 20;
                         }
                            p_objGrp.DrawString("光学面长度:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过>>14、植入后房型人工晶体>>实际植入人工晶>>光学面长度"))
                         {                          
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>14、植入后房型人工晶体>>实际植入人工晶>>光学面长度"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 490, p_intPosY);
                             p_intPosY += 20;
                         }
                          else
                         {
                              p_intPosY += 20;
                         }
                            p_objGrp.DrawString("人工晶体植入后上下攀位置:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过>>14、植入后房型人工晶体>>人工晶体植入后上下攀位置"))
                         {                          
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过>>14、植入后房型人工晶体>>人工晶体植入后上下攀位置"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 220, p_intPosY);
                             
                         }
                         p_intPosY += 20;
                                 p_objGrp.DrawString("固定方法:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>14、植入后房型人工晶体>>固定方法"))
                         {                     
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩ>>14、植入后房型人工晶体>>固定方法"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 95, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>双腔管抽吸前房内粘稠剂>>干净") && m_hasItemDetail["手术经过ＩＩ>>双腔管抽吸前房内粘稠剂>>干净"] != "")
                         {
                             p_objGrp.DrawString("双腔管抽吸前房内粘稠剂:干净", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>双腔管抽吸前房内粘稠剂>>残留") && m_hasItemDetail["手术经过ＩＩ>>双腔管抽吸前房内粘稠剂>>残留"] != "")
                         {
                             p_objGrp.DrawString("双腔管抽吸前房内粘稠剂:残留", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                             //p_intPosY += 20;
                         }
                         // else
                         //{
                         //     p_intPosY += 20;
                         //}
                         p_intPosY += 20;
                           p_objGrp.DrawString("15、前房注入缩瞳剂:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>15、前房注入缩瞳剂>>有") && m_hasItemDetail["手术经过ＩＩ>>15、前房注入缩瞳剂>>有"] != "")
                         {
                             p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intRecBaseX + 190, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("手术经过ＩＩ>>15、前房注入缩瞳剂>>无") && m_hasItemDetail["手术经过ＩＩ>>15、前房注入缩瞳剂>>无"] != "")
                         {
                             p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intRecBaseX + 190, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("缩童剂>>匹罗卡品") && m_hasItemDetail["缩童剂>>匹罗卡品"] != "")
                         {
                             p_objGrp.DrawString("用匹罗卡品", p_fntNormalText, Brushes.Black, m_intRecBaseX + 210, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("前房注入缩瞳剂>>匹罗怕品量") && m_hasItemDetail["前房注入缩瞳剂>>匹罗怕品量"] != "")
                         {
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["前房注入缩瞳剂>>匹罗怕品量"]) + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("缩童剂>>卡米可林") && m_hasItemDetail["缩童剂>>卡米可林"] != "")
                         {
                             p_objGrp.DrawString("用卡米可林", p_fntNormalText, Brushes.Black, m_intRecBaseX + 210, p_intPosY);
                             //p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("前房注入缩瞳剂>>卡米可林量") && m_hasItemDetail["前房注入缩瞳剂>>卡米可林量"] != "")
                         {
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["前房注入缩瞳剂>>卡米可林量"]) + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                             p_intPosY += 20;
                         }
                          else
                         {
                              p_intPosY += 20;
                         }
                        p_objGrp.DrawString("16、术毕瞳孔型态:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态"))
                        {
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 155, p_intPosY);

                        }
                        p_objGrp.DrawString("大小:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 495, p_intPosY);
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态>>大小"))
                         {                           
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态>>大小"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 535, p_intPosY);

                         } 
                         p_intPosY += 20;
                         p_objGrp.DrawString("位置:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态>>位置") && m_hasItemDetail["手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态>>位置"] != "")
                         {
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩＩ>>17、术毕瞳孔型态>>位置"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 55, p_intPosY);

                             p_intPosY += 20;
                         }
                         else
                         {
                             p_intPosY += 20;
                         }
                         if (m_hasItemDetail.Contains("手术经过ＩＩＩ>>19、术后用药>>结膜下注入"))
                         {
                             p_objGrp.DrawString("17、术后用药:结膜下注入:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩＩ>>19、术后用药>>结膜下注入"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 220, p_intPosY);
                             p_intPosY += 20;
                         }
                         else
                         {
                              p_intPosY += 20;
                         }
                              p_objGrp.DrawString("18、包眼:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                         if (m_hasItemDetail.Contains("手术>>手术经过ＩＩＩ>>20、包眼>>包眼"))
                         {                        
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术>>手术经过ＩＩＩ>>20、包眼>>包眼"]) , p_fntNormalText, Brushes.Black, m_intRecBaseX + 85, p_intPosY);

                         }
                         p_objGrp.DrawString("眼垫:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 265, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩＩ>>20、包眼>>眼垫"))
                         {
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩＩ>>20、包眼>>眼垫"]) , p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);

                         }
                         p_objGrp.DrawString("绷带:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 520, p_intPosY);
                         if (m_hasItemDetail.Contains("手术经过ＩＩＩ>>20、包眼>>绷带"))
                         {
                             p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术经过ＩＩＩ>>20、包眼>>绷带"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                             p_intPosY += 20;
                         }
                         else
                         {
                              p_intPosY += 20;
                         }
                           p_objGrp.DrawString("19、术中意外原因:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                          p_intPosY += 20;
                       
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
        /// 结膜撕破
        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>结膜撕破"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>结膜撕破"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("结膜撕破：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>结膜撕破" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 后弹力层脱离
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>后弹力层脱离"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>后弹力层脱离"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("后弹力层脱离：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "      ";
                    string strXml = "      ";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>后弹力层脱离" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 虹膜撕裂
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>虹膜撕裂"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>虹膜撕裂"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("虹膜撕裂：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>虹膜撕裂" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 前房出血
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>前房出血"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>前房出血"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("前房出血：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>前房出血" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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


        /// <summary>
        /// 后囊膜撕裂
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>后囊膜撕裂"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>后囊膜撕裂"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("后囊膜撕裂：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "  ";
                    string strXml = "  ";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>后囊膜撕裂" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 玻璃体溢出
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>> 玻璃体溢出"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>> 玻璃体溢出"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("玻璃体溢出：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "  ";
                    string strXml = "  ";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>> 玻璃体溢出" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 球后出血
        /// </summary>
        private class clsPrint7 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>球后出血"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>球后出血"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("球后出血：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>球后出血" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 其它
        /// </summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>21、术中意外原因>>其它"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>21、术中意外原因>>其它"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("其它：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>21、术中意外原因>>其它" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 其他说明
        /// </summary>
        private class clsPrint9 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术经过ＩＩＩ>>其他说明"))
                        objItemContent = m_hasItems["手术经过ＩＩＩ>>其他说明"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("21、其他说明：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "      ";
                    string strXml = "      ";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术经过ＩＩＩ>>其他说明" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        #region 打印术者
        /// <summary>
        /// 术者
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
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
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("术者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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

        #endregion

        #region 打印助手
        /// <summary>
        /// 助手
        /// </summary>
        private class clsPrint11 : clsIMR_PrintLineBase
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvhelper")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("助手：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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

        #endregion


        #region 打印麻醉
        /// <summary>
        /// 助手
        /// </summary>
        private class clsPrint12 : clsIMR_PrintLineBase
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvAnaesthetist")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("麻醉师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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

        #endregion

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
