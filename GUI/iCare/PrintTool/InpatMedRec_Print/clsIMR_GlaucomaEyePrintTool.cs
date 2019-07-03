using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 打印青光眼手术记录的摘要说明。
    /// </summary>
    public class clsIMR_GlaucomaEyePrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_GlaucomaEyePrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo(),				                                                       
                                                                          new clsPrint3(),
                                                                          new clsPrint2(),
                                                                          new clsPrint4(),
                                                                           new clsPrint5(),
                                                                          new clsPrint17(),
                                                                          new clsPrint18(),                                                                        
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                          new clsPrint8(),
                                                                          new clsPrint9(),
                                                                          new clsPrint10(),
                                                                          new clsPrint11(),
                                                                          new clsPrint12(),
                                                                          new clsPrint13(),
                                                                          new clsPrint14(false),
                                                                          new clsPrint15(),
                                                                          new clsPrint14(true),
                                                                          new clsPrint16()
                                                                          
																	   });
        }


        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);
                p_objGrp.DrawString("青光眼手术记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 370, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
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
        }

        #endregion
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        { }
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
        }
        #region 打印术前诊断
        /// <summary>
        /// 术前诊断
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术>>手术前诊断"))
                        objItemContent = m_hasItems["手术>>手术前诊断"] as clsInpatMedRec_Item;
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
                        m_mthMakeText(new string[] { "" }, new string[] { "手术>>手术前诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        #region 打印术后诊断
        /// <summary>
        /// 术后诊断
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("手术>>手术后诊断"))
                        objItemContent = m_hasItems["手术>>手术后诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术后诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "手术>>手术后诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 40, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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

        #region 打印手术日期
        /// <summary>
        /// 手术日期
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;

                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "手术时间：" },
                            new string[] { "手术>>手术日期" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
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

        #region 打印手术名称
        /// <summary>
        /// 手术名称
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "", strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "手术名称：" },
                            new string[] { "手术>>手术名称" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
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

        #region 打印术者
        /// <summary>
        /// 术者
        /// </summary>
        private class clsPrint17 : clsIMR_PrintLineBase
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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
        private class clsPrint18 : clsIMR_PrintLineBase
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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

        #region 打印手术程序一、二
        ///<summary>
        ///手术程序一、二
        ///</summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("手术程序：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {                                                                               //, "\n二、开睑:", "缝线：$$", "开睑器：$$", "缝线固定："
                        m_mthMakeText(new string[] { "一、", "常规消毒铺巾：$$", "麻醉方式及药物：$$" },//, "", "结膜开口>>开脸>>缝线", "结膜开口>>开脸>>开脸器", "手术程序>>开睑>>缝线固定" 
                            new string[] { "", "手术程序>>消毒铺巾", "手术程序>>麻醉方式及药物"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n二、开睑：", "结膜开口>>开脸>>缝线", "结膜开口>>开脸>>开脸器" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "缝线固定：", "$$", "  直肌$$"/*, "$$"*/ },
                         new string[] { "", "手术程序>>开睑>>缝线固定", ""/*, "手术程序>>开睑>>直肌"*/ }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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

        #region 手术程序三
        ///<summary>
        ///手术程序三
        ///</summary>
        private class clsPrint7 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("三、", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "作结膜瓣：以$$", "#为基底，$$", "于$$", "#点方位，$$", "距角膜缘$$", "#mm，", "形状：$$" },
                           new string[] { "手术程序>>作结膜辨>>基底", "手术程序>>作结膜辨>>基底", "手术程序>>作结膜辨>>方位", "手术程序>>作结膜辨>>方位", "手术程序>>作结膜辨>>距角膜缘", "手术程序>>作结膜辨>>距角膜缘", "手术程序>>作结膜辨>>形状" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "Tenon囊切除：", "手术程序>>作结膜辨>>Tenon囊切除>>有", "手术程序>>作结膜辨>>Tenon囊切除>>无" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "结膜辨下放置何种抗纤维抑制剂：", " 浓度", " 时间" },
                           new string[] { "手术程序>>作结膜辨>>抗纤维抑制剂", "手术程序>>作结膜辨>>浓度", "手术程序>>作结膜辨>>时间" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 40, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        #region 手术程序四
        ///<summary>
        ///手术程序四
        ///</summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "四、" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "作前房穿刺口：", "手术程序>>作前房穿刺口>>有", "手术程序>>作前房穿刺口>>无" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "#点方位；$$" }, new string[] { "手术程序>>作前房穿刺口>>方位", "手术程序>>作前房穿刺口>>方位" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "位置：", "手术程序>>作前房穿刺口>>位置>>透明角膜", "手术程序>>作前房穿刺口>>位置>>角膜缘" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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

        #region 手术程序五-第一步
        ///<summary>
        ///手术程序五-第一步
        ///</summary>
        private class clsPrint9 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("五、", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        string strText = "";
                        if (m_hasItems.Contains("手术程序>>作板层巩膜辨>>厚>>1/2"))
                            strText = "1/2厚，";
                        if (m_hasItems.Contains("手术程序>>作板层巩膜辨>>厚>>1/3"))
                            strText = "1/3厚，";
                        if (m_hasItems.Contains("手术程序>>作板层巩膜辨>>厚>>2/3"))
                            strText = "2/3厚，";
                        m_mthMakeText(new string[] { "1、作板层巩膜瓣：以角膜缘为基底于$$", "#点方位，$$", "位置：呈$$", "#形，", "大小$$", "#mm，$$" },
                           new string[] { "手术程序>>作板层巩膜辨>>方位1", "手术程序>>作板层巩膜辨>>方位1", "手术程序>>作板层巩膜辨>>形", "手术程序>>作板层巩膜辨>>形", "手术程序>>作板层巩膜辨>>大小", "手术程序>>作板层巩膜辨>>大小" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { strText }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] {"","手术程序>>作板层巩膜辨>>巩膜瓣", "手术程序>>作板层巩膜辨>>结膜瓣"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "巩膜瓣下放置：", "手术程序>>作板层巩膜辨>>抗纤维抑制剂>>有", "手术程序>>作板层巩膜辨>>抗纤维抑制剂>>无" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "抗纤维抑制剂,丝裂霉素：", "手术程序>>作板层巩膜辨>>丝裂霉素>>有", "手术程序>>作板层巩膜辨>>丝裂霉素>>无" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "浓度：", "$$", "时间：", "$$", "于", "#点方位", "巩膜床上作两个相距", "$$", "#mm，放射状垂直性巩膜切口，于角膜缘后界剪:", "$$", "#mm；切除", "$$" },
                            new string[] { "", "手术程序>>作板层巩膜辨>>抗纤维抑制剂>>浓度", "", "手术程序>>作板层巩膜辨>>抗纤维抑制剂>>时间", "手术程序>>作板层巩膜辨>>方位2", "手术程序>>作板层巩膜辨>>方位2", "手术程序>>作板层巩膜辨>>在深层巩膜床上作两个相距", "手术程序>>作板层巩膜辨>>在深层巩膜床上作两个相距", "手术程序>>作板层巩膜辨>>角膜缘后剪", "手术程序>>作板层巩膜辨>>角膜缘后剪", "手术程序>>作板层巩膜辨>>切除", "手术程序>>作板层巩膜辨>>切除" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "mm,角膜缘组织：", "手术程序>>作板层巩膜辨>>角膜缘组织>>角膜", "手术程序>>作板层巩膜辨>>角膜缘组织>>角膜小", "手术程序>>作板层巩膜辨>>角膜缘组织>>角膜小巩膜" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        #region 手术程序五-第二步
        ///<summary>
        ///手术程序五-第二步
        ///</summary>
        private class clsPrint10 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeCheckText(new string[] { "2.插入引流器：", "插入引流器>>有", "插入引流器>>无" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        #region 手术程序六-八
        ///<summary>
        ///手术程序六-八
        ///</summary>
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
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;

                    if (m_objContent != null)
                    {
                        string strText = "虹膜切除：";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("手术过程>>虹膜切除>>周边虹膜切除"))
                            {
                                strText += "周边虹膜切除";
                                if (m_hasItems.Contains("手术过程>>虹膜切除>>周边虹膜切除>>mm"))
                                {
                                    objItemContent = m_hasItems["手术过程>>虹膜切除>>周边虹膜切除>>mm"] as clsInpatMedRec_Item;
                                    strText += objItemContent.m_strItemContent + "mm";
                                }
                            }
                            else if (m_hasItems.Contains("手术过程>>虹膜切除>>节段虹膜切除"))
                            {
                                strText += "节段虹膜切除";
                            }
                        }
                        else
                        {
                            m_blnHaveMoreLine = false;
                            return;
                        }
                        m_mthMakeText(new string[] { "六、", strText }, new string[] { "", "" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "\n七、回复巩膜瓣", "用１０－０尼龙线缝合$$","#针$$","不缝合$$", "可调节缝线", "#针$$", "(图示)" },
                        //    new string[] { "", "回复巩膜辨>>用10-0尼龙线缝合", "手术过程>>回复巩膜辨>>尼龙线缝合针数", "回复巩膜辨>>不缝合", "回复巩膜辨>>可调节缝线", "手术过程>>回复巩膜辨>>可调节缝线针数",""}, ref strAllText, ref strXml);
                        strText = "回复巩膜瓣：";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("回复巩膜辨>>用10-0尼龙线缝合"))
                            {
                                strText += "用10-0尼龙线缝合";
                            }
                            else if (m_hasItems.Contains("回复巩膜辨>>不缝合"))
                            {
                                strText += "不缝合";
                            }
                            else if (m_hasItems.Contains("回复巩膜辨>>可调节缝线"))
                            {
                                strText += "可调节缝线";
                                if (m_hasItems.Contains("手术过程>>回复巩膜辨>>尼龙线缝合针数"))
                                {
                                    objItemContent = m_hasItems["手术过程>>回复巩膜辨>>尼龙线缝合针数"] as clsInpatMedRec_Item;
                                    strText += objItemContent.m_strItemContent + "针";
                                }
                            }
                        }
                        else
                        {
                            m_blnHaveMoreLine = false;
                            return;
                        }
                        m_mthMakeText(new string[] { "\n七、", strText }, new string[] { "", "" }, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "\n七、回复巩膜瓣：", "回复巩膜辨>>用10-0尼龙线缝合", "回复巩膜辨>>不缝合", "回复巩膜辨>>可调节缝线" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n八、", "连续缝合球结膜，其中Tenon间断缝合$$", "#针$$" },
                            new string[] { "", "手术过程>>连续缝合球结膜>>Tenon间断缝合针数", "手术过程>>连续缝合球结膜>>Tenon间断缝合针数" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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

        #region 手术程序九
        ///<summary>
        ///手术程序九
        ///</summary>
        private class clsPrint12 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        p_objGrp.DrawString("九、", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                        m_mthMakeText(new string[] { "形成前房及检查滤过量：前房用", "#；或自行形成。$$" },
                            new string[] { "手术过程>>形成前房及检查滤过量>>前房用", "手术过程>>形成前房及检查滤过量>>前房用" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "术毕前房：", "手术过程>>形成前房及检查滤过量>>术毕前房>>形成", "手术过程>>形成前房及检查滤过量>>术毕前房>>稍浅", "手术过程>>形成前房及检查滤过量>>术毕前房>>无前房" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "滤过量：", "手术过程>>形成前房及检查滤过量>>过滤量>>无", "手术过程>>形成前房及检查滤过量>>过滤量>>合适", "手术过程>>形成前房及检查滤过量>>过滤量>>过强" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        #region 手术程序十
        ///<summary>
        ///手术程序十
        ///</summary>
        private class clsPrint13 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "十、", "球结膜下注射：$$", "结膜囊涂上", "#眼膏，包单双眼。$$", "\n十一、手术图示：$$" },
                            new string[] { "", "手术过程>>球结膜下注射", "手术过程>>结膜囊涂上", "手术过程>>结膜囊涂上", "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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

        #region 打印图片
        /// <summary>
        /// 打印画图
        /// </summary>
        internal class clsPrint14 : clsInpatMedRecPrintBase.clsIMR_PrintLineBase
        {
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intCurrentPic = 0;
            public static bool m_blnIsPrinted = false;
            public bool m_blnMustPrinted = false;
            public clsPrint14(bool p_blnMustPrinted)
            {
                m_blnMustPrinted = p_blnMustPrinted;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objPrintInfo.m_objContent.m_objPics == null || m_objPrintInfo.m_objContent.m_objPics.Length < 1 || m_blnIsPrinted == true)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                m_blnHaveMoreLine = false;
                if (m_blnIsFirstPrint)
                {
                    int intPicHeight = m_objPrintInfo.m_objContent.m_objPics[0].intHeight;
                    int intPicWidth = m_objPrintInfo.m_objContent.m_objPics[0].intWidth;

                    if (p_intPosY + intPicHeight > 844)
                    {
                        m_blnHaveMoreLine = false;
                        if (m_blnMustPrinted)
                        {
                            p_intPosY += intPicHeight;
                            m_blnHaveMoreLine = true;
                        }
                        return;
                    }
                    else
                    {
                        p_intPosY += 20;
                        int intLeft = m_intRecBaseX + 10;
                        for (int i = m_intCurrentPic; i < m_objPrintInfo.m_objContent.m_objPics.Length; i++)
                        {
                            System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[i].m_bytImage);
                            Image imgPrint = new Bitmap(objStream);

                            p_objGrp.DrawImage(imgPrint, intLeft, p_intPosY, m_objPrintInfo.m_objContent.m_objPics[i].intWidth, m_objPrintInfo.m_objContent.m_objPics[i].intHeight);
                            intLeft += m_objPrintInfo.m_objContent.m_objPics[i].intWidth + 10;
                            intPicHeight = Math.Max(intPicHeight, m_objPrintInfo.m_objContent.m_objPics[i].intHeight);

                            //还有图片要打
                            if (i + 1 < m_objPrintInfo.m_objContent.m_objPics.Length)
                            {
                                //图片超过一行
                                if ((int)enmRectangleInfo.RightX - intLeft < intPicWidth)
                                {
                                    m_blnHaveMoreLine = true;
                                    p_intPosY += intPicHeight;
                                    intLeft = m_intRecBaseX + 10;
                                    m_intCurrentPic = i + 1;
                                    return;
                                }
                            }
                        }
                    }
                    p_intPosY += intPicHeight + 20;
                    m_blnIsFirstPrint = false;
                }
                m_blnIsPrinted = true;
            }
            public override void m_mthReset()
            {
                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                //打印预览或者打印后都得重置
                m_intCurrentPic = 0;

                m_blnIsPrinted = false;
            }
        }
        #endregion

        #region 手术程序十二
        ///<summary>
        ///手术程序十二
        ///</summary>
        private class clsPrint15 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("十二、术中并发症或特殊情况：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" },
                            new string[] { "手术过程>>术中并发症或特殊情况" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 40, m_intRecBaseX + 70, p_intPosY, p_objGrp);
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

        #region 打印记录者-日期
        /// <summary>
        /// 记录者-日期
        /// </summary>
        private class clsPrint16 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                string strReport = "";
                for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                {
                    if (m_objContent.objSignerArr[i].controlName == "m_txtSign")
                    {
                        strReport = m_objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                        break;
                    }
                }
                p_intPosY += 20;
                p_objGrp.DrawString("记录者：" + strReport, p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("日期：" + m_objContent.m_dtmCreateDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                // p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }
        #endregion
    }
}