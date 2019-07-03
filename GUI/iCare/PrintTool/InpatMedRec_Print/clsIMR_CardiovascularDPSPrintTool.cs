using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 打印心脏血管手术记录的摘要说明。
    /// </summary>
    public class clsIMR_CardiovascularDPSPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_CardiovascularDPSPrintTool(string p_strTypeID)
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
				                                                          new clsPrint2(),
                                                                          new clsPrint3(),
                                                                          new clsPrint4(),
                                                                          new clsPrint5(),
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                          new clsPrint8(false),
                                                                          new clsPrint9(),
                                                                          new clsPrint8(true),
                                                                          new clsPrint10()
																	   });
        }
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        { }
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
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
                p_objGrp.DrawString("心脏血管手术记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 360, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 200, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 300, 130);
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, 420, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 520, 130);
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

        #region 打印手术日期
        /// <summary>
        /// 手术日期
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr1 = { "手术>>手术日期" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)
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

                        m_mthMakeText(new string[] { "手术日期：" }, m_strKeysArr1, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "；体重：", "#kg$$" }, new string[] { "手术>>体重", "手术>>体重" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n手术名称：", "$$" }, new string[] { "手术>>手术名称", "" }, ref strAllText, ref strXml);
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
            private Font m_fontItemMidHead = new Font("", 10, FontStyle.Regular);
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
                    p_objGrp.DrawString("术前诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("术前诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 40, p_intPosY, p_objGrp);

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
        #endregion

        #region 打印术后诊断
        /// <summary>
        /// 术后诊断
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
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
                    p_objGrp.DrawString("术后诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("术后诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 40, p_intPosY, p_objGrp);

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
        #endregion

        #region 打印术者
        /// <summary>
        /// 术者
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
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
                    string strOperations = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null && strOperations != "")
                    {
                        m_mthMakeText(new string[] { "术者：" + strOperations }, new string[] { "" } , ref strAllText, ref strXml);
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

        #region 打印体位-其他
        /// <summary>
        /// 体位-其他
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
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
                    p_objGrp.DrawString("手术方法：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "体位：", "胸部切口：", "心脏切口：", "浅低温体外循环：", "#；$$" },
                            new string[] { "手术方法>>体位", "手术方法>>胸部切口", "手术方法>>心脏切口", "手术方法>>浅低温体外循环", "手术方法>>浅低温体外循环" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "中度低温体外循环：", "深低温停循环：", "非体外循环：", "插管：升主动脉 ", "#；$$" },
                            new string[] { "手术方法>>中度低温体外循环", "手术方法>>深低温停循环", "手术方法>>非体外循环", "手术方法>>插管>>升主动脉", "手术方法>>插管>>升主动脉" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "上腔静脉 ", "下腔静脉 ", "右心房 ", "右肺静脉 ", "股动脉 ", "#；$$" },
                            new string[] { "手术方法>>插管>>上腔静脉", "手术方法>>插管>>下腔靓脉", "手术方法>>插管>>右心房", "手术方法>>插管>>右肺静脉", "手术方法>>插管>>股动脉", "手术方法>>插管>>股动脉" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "股静脉 ", "腋动脉 ", "腋静脉 ", "冠状静脉窦 ", "左上腔静脉", "#。$$" },
                           new string[] { "手术方法>>插管>>股静脉", "手术方法>>插管>>腋动脉", "手术方法>>插管>>腋静脉", "手术方法>>插管>>冠状静脉窦", "手术方法>>插管>>左上腔静脉", "手术方法>>插管>>左上腔静脉" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "机器运转", "分，最低鼻温：$$", "℃，停机时鼻温$$", "℃，心脏不停跳$$", "#，$$" },
                           new string[] { "手术方法>>机器运转", "手术方法>>最低鼻温", "手术方法>>停机时鼻温", "手术方法>>心脏不停跳", "手术方法>>心脏不停跳" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "主动脉阻断", "分。晶体停跳液$$", "，含血停跳液$$", "#，$$" },
                           new string[] { "手术方法>>主动脉阻断", "手术方法>>晶体停跳液", "手术方法>>含血停跳液", "手术方法>>含血停跳液" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "升主动脉根部灌注", "次，左冠状动脉$$", "次，右冠状动脉$$", "次，冠状静脉窦$$", "次，共$$", "#次。$$" },
                           new string[] { "手术方法>>升主动脉根部灌注", "手术方法>>左冠状动脉", "手术方法>>右冠状动脉", "手术方法>>冠状静脉窦", "手术方法>>共", "手术方法>>共" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "心脏停跳", "满意，心内回血", "术野显露", "，心内排气$$", "#。$$" },
                           new string[] { "手术方法>>心脏停跳", "手术方法>>心内回血", "手术方法>>术野显露", "手术方法>>内心排气", "手术方法>>内心排气" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "心脏复跳：自动", "，电击$$", "次，体外循环$$", "平稳，停机$$", "困难$$", "#。$$" },
                           new string[] { "手术方法>>心脏复跳>>自动", "手术方法>>心脏复跳>>电击", "手术方法>>心脏复跳>>体外循环", "手术方法>>心脏复跳>>停机", "手术方法>>心脏复跳>>困难", "手术方法>>心脏复跳>>困难" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "心包：未缝", "，缝合$$", "，补片缝合$$", "渗血$$", "#，$$" },
                           new string[] { "手术方法>>心包>>未缝", "手术方法>>心包>>缝合", "手术方法>>心包>>补片缝合", "手术方法>>心脏复跳>>内心排气", "手术方法>>心脏复跳>>内心排气" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "引流：心包", "纵隔", "左胸", "右胸", "#。$$" },
                           new string[] { "手术方法>>引流>>心包", "手术方法>>引流>>纵隔", "手术方法>>引流>>左胸", "手术方法>>引流>>右胸", "手术方法>>引流>>右胸" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "其他：" }, new string[] { "手术方法>>其它" }, ref strAllText, ref strXml);
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

        #region 打印病理所见
        /// <summary>
        /// 病理所见
        /// </summary>
        private class clsPrint7 : clsIMR_PrintLineBase
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
                    p_objGrp.DrawString("病理所见：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "心包：", "纵隔侧枝血管：", "左房：", "#；$$" },
                            new string[] { "病理所见>>心包", "病理所见>>纵隔侧枝血管", "病理所见>>左房", "病理所见>>左房" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "右房：", "左室：", "右室：", "#；$$" },
                            new string[] { "病理所见>>右房", "病理所见>>左室", "病理所见>>右室", "病理所见>>右室" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "房间隔缺损：类型 ", "部位 ", "大小 ", "#cm。$$" },
                            new string[] { "病理所见>>房间隔缺损>>类型", "病理所见>>房间隔缺损>>部位", "病理所见>>房间隔缺损>>大小", "病理所见>>房间隔缺损>>大小" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "室间隔缺损：类型 ", "部位 ", "大小 ", "#cm。$$" },
                           new string[] { "病理所见>>室间隔缺损>>类型", "病理所见>>室间隔缺损>>部位", "病理所见>>室间隔缺损>>大小", "病理所见>>室间隔缺损>>大小" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "升主动脉", "主动脉弓及降部", "动脉导管未闭：类型", "粗细", "#cm，$$", "长度", "#cm。$$" },
                           new string[] { "病理所见>>升主动脉", "病理所见>>主动脉及弓及降部", "病理所见>>动脉导管未闭>>类型", "病理所见>>动脉导管未闭>>粗细", "病理所见>>动脉导管未闭>>粗细", "病理所见>>动脉导管未闭>>长度", "病理所见>>动脉导管未闭>>长度" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "主肺动脉", "左肺动脉", "右肺动脉", "#；$$" },
                           new string[] { "病理所见>>主肺动脉", "病理所见>>左肺动脉", "病理所见>>右肺动脉", "病理所见>>右肺动脉" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "主动脉瓣：瓣页增厚", "钙化", "瓣环钙化", "关闭不全", "二瓣化", "#；$$" },
                           new string[] { "病理所见>>主动脉瓣>>瓣叶增厚", "病理所见>>主动脉瓣>>钙化", "病理所见>>主动脉瓣>>瓣环钙化", "病理所见>>主动脉瓣>>关闭不全", "病理所见>>主动脉瓣>>二瓣化", "病理所见>>主动脉瓣>>二瓣化" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "瓣口狭窄", "cm2。二尖瓣：瓣叶增厚$$", "钙化", "瓣裂", "脱垂", "#；$$" },
                           new string[] { "病理所见>>主动脉瓣>>瓣口狭窄", "病理所见>>二尖瓣>>瓣叶增厚", "病理所见>>二尖瓣>>钙化", "病理所见>>二尖瓣瓣>>瓣裂", "病理所见>>二尖瓣瓣>>脱垂", "病理所见>>二尖瓣瓣>>脱垂" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "关闭不全", "，腱索宿短$$", "融合", "断裂", "，瓣环增厚$$", "钙化", "#；$$" },
                           new string[] { "病理所见>>二尖瓣瓣>>关闭不全", "病理所见>>二尖瓣瓣>>腱索宿短", "病理所见>>二尖瓣瓣>>触合", "病理所见>>二尖瓣瓣>>断裂", "病理所见>>二尖瓣>>瓣环增厚", "病理所见>>二尖瓣瓣>>钙化", "病理所见>>二尖瓣瓣>>钙化" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "瓣口狭窄", "cm2。三尖瓣：关闭不全$$", "，下移畸形$$", "#。$$" },
                           new string[] { "病理所见>>二尖瓣>>瓣口狭窄", "病理所见>>三尖瓣>>瓣叶增厚", "病理所见>>三尖瓣>>下移畸形", "病理所见>>三尖瓣>>下移畸形" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "肺动脉瓣：狭窄", "二瓣化", "关闭不全", "#。$$" },
                           new string[] { "病理所见>>肺动脉瓣>>狭窄", "病理所见>>肺动脉瓣>>二瓣化", "病理所见>>肺动脉瓣>>关闭不全", "病理所见>>肺动脉瓣>>关闭不全" }, ref strAllText, ref strXml);

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
        internal class clsPrint8 : clsInpatMedRecPrintBase.clsIMR_PrintLineBase
        {
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intCurrentPic = 0;
            public static bool m_blnIsPrinted = false;
            public bool m_blnMustPrinted = false;
            public clsPrint8(bool p_blnMustPrinted)
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

        #region 打印病例特点
        /// <summary>
        /// 病例特点
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
                    if (m_hasItems.Contains("本病例特点及图解"))
                        objItemContent = m_hasItems["本病例特点及图解"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("病例特点：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("病例特点：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 40, p_intPosY, p_objGrp);

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
        #endregion

        #region 打印记录者-日期
        /// <summary>
        /// 记录者-日期
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                string strRecorder = "";
                for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                {
                    if (m_objContent.objSignerArr[i].controlName == "m_txtSign")
                    {
                        strRecorder = m_objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                        break;
                    }
                }
                p_intPosY += 20;
                p_objGrp.DrawString("记录者：" + strRecorder, p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("日期：" + m_objContent.m_dtmCreateDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                // p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;

            }
        }
        #endregion
    }
}
