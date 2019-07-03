using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 产科住院病历（佛山）
    /// </summary>
    public class clsIMR_Obstetric_F2PrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_Obstetric_F2PrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: Add constructor logic here
            // 

        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("产科住院病历",310),
										  new clsPrintInPatMedRecMain(),
										  new clsPrintInPatMedRecCurrent(),
										  //new clsPrintInPatMedRecBeBrought(),
										  new clsPrintInPatMedRecAnamnesis(),
                                          new  clsPrintInPatMedhistroy(),
										  new clsPrintInPatMedRecMenses(),
										  new clsPrintInPatMedRecMarriage(),
										  new clsPrintInPatMedRecProcreate(),
										  new clsPrintInPatMedRecFmaily(),
										  new clsPrintInPatMedRecBornCheck(),
										  new clsPrintInPatMedRecMedical(),
										  new clsPrintInPatMedRecObstetricCheck(),
										  new clsPrintInPatMedRecPic(),
										  new clsPrintInPatMedRecCurePlan(),
                    new clsPrintInPatMedRecDia2(),
                    new clsPrintInPatMedRecDia3(),
                    new clsPrintInPatMedRecDia4()
										 // new clsPrintInPatMedRecCurePlan()
									  });
        }

        #region print class




        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrintInPatMedRecMain : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent = null;
            private clsInpatMedRec_Item[] objItemContentArr = null;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //m_mthPrintPregnantAndBirth(ref p_intPosY, p_objGrp, p_fntNormalText);
                if (m_hasItems != null)
                    if (m_hasItems.Contains("主诉"))
                        objItemContent = m_hasItems["主诉"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {

                    p_objGrp.DrawString("主诉：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("主诉：", m_objPrintContext.m_ObjModifyUserArr);


                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

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

            private void m_mthPrintPregnantAndBirth(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                objItemContentArr = m_objGetContentFromItemArr(new string[] { "孕", "产" });
                if (objItemContentArr == null)
                    return;
                if (objItemContentArr[0] != null)
                    p_objGrp.DrawString("孕：" + (objItemContentArr[0] == null ? "" : objItemContentArr[0].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                if (objItemContentArr[1] != null)
                    p_objGrp.DrawString("产：" + (objItemContentArr[1] == null ? "" : objItemContentArr[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
            }
        }

        /// <summary>
        /// 现病史
        /// </summary>
        private class clsPrintInPatMedRecCurrent : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            //private string[] m_strKeysArr = {"现病史>>末次月经","现病史>>预产期","现病史>>孕周","现病史>>妊娠反应开始时间及程度","现病史>>胎动开始时间","现病史>>头痛","现病史>>头晕"
            //                                ,"现病史>>眼花","现病史>>水肿","现病史>>心跳","现病史>>气促","现病史>>流血","现病史>>流水"};
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            private clsInpatMedRec_Item[] objSignContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                #region old
                /*
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[]{"末次月经：","预产期：","孕周：","妊娠反应开始时间及程度：","胎动开始时间：","头痛：","头晕："
												  ,"眼花：","水肿：","心跳：","气促：","流血：","流水："}, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("现病史：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
             */
                #endregion

                if (m_hasItems != null)
                    if (m_hasItems.Contains("现病史"))
                        objItemContent = m_hasItems["现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("现病史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
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
        /// 临产情况
        /// </summary>
        private class clsPrintInPatMedRecBeBrought : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr = { "临产情况>>子宫收缩时间", "临产情况>>血性分泌物", "临产情况>>流水", "临产情况>>其他" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("临产情况：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "子宫规则收缩时间：", "血性分泌物：", "流水：", "其他：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("临产情况：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 过去史
        /// </summary>
        private class clsPrintInPatMedRecAnamnesis : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr = { "过去史>>结核病", "过去史>>心脏病", "过去史>>肾病", "过去史>>性病", "过去史>>高血压", "过去史>>过敏史", "过去史>>妇科病", "过去史>>其他" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("过去史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "结核病：", "心脏病：", "肾病：", "性病：", "高血压：", "过敏史：", "妇科病：", "其他：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("过去史：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }

        /// <summary>
        /// 个人史
        /// </summary>
        private class clsPrintInPatMedhistroy : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr = { "个人史>>出生地", "个人史>>经历地", "个人史>>居留地", "个人史>>习惯与嗜好" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("个人史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "出生地：", "经历地：", "居留地：", "习惯与嗜好：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("个人史：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 月经史
        /// </summary>
        private class clsPrintInPatMedRecMenses : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr = { "月经史>>初潮", "月经史>>周期", "月经史>>持续", "月经史>>量", "月经史>>痛经", "月经史>>血块" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("月经史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "初潮：", "周期：", "持续：", "量：", "痛经：", "血块：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent != null);
                    m_mthAddSign2("月经史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 婚姻史
        /// </summary>
        private class clsPrintInPatMedRecMarriage : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr = { "婚姻史>>结婚年龄", "婚姻史>>配偶姓名", "婚姻史>>现年", "婚姻史>>婚次", "婚姻史>>健康情况" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("婚姻史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "结婚年龄：", "配偶姓名：", "现年：", "婚次：", "健康情况：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent != null);
                    m_mthAddSign2("婚姻史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 生育史
        /// </summary>
        private class clsPrintInPatMedRecProcreate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr1 = { "生育史>>流产", "生育史>>引产", "生育史>>早产", "生育史>>足月产", "生育史>>末次产" };
            private string[] m_strKeysArr2 = { "", "生育史>>男", "生育史>>女" };
            private string[] m_strKeysArr3 = { "生育史>>手术产及异常情况" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("生育史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "流产：", "引产：", "早产：", "足月产：", "末次产：" }, m_strKeysArr1, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr2) == true)
                            m_mthMakeText(new string[] { "  现有子女：", "男：", "女：" }, m_strKeysArr2, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n手术产及异常情况：" }, m_strKeysArr3, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent != null);
                    m_mthAddSign2("生育史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 家族史
        /// </summary>
        private class clsPrintInPatMedRecFmaily : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private bool m_blnIsFirstPrint = true;
            private string[] m_strKeysArr = { "家族史>>高血压", "家族史>>双胎", "家族史>>畸形", "家族史>>精神病", "家族史>>肿瘤", "家族史>>其他" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("家族史：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "高血压：", "双胎：", "畸形：", "精神病：", "肿瘤：", "其他：" }, m_strKeysArr, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent != null);
                    m_mthAddSign2("家族史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
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
        /// 产前检查情况
        /// </summary>
        private class clsPrintInPatMedRecBornCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("产前检查情况"))
                        objItemContent = m_hasItems["产前检查情况"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("产前检查情况：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("产前检查情况：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
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
        /// 入院时体检
        /// </summary>
        private class clsPrintInPatMedRecMedical : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr1 = { "入院时体检>>体温", "入院时体检>>脉搏", "入院时体检>>呼吸", "入院时体检>>血压","入院时体检>>血压" };
            private string[] m_strKeysArr2 = { "", "入院时体检>>一般情况>>发育", "入院时体检>>一般情况>>营养", "入院时体检>>一般情况>>神智", "入院时体检>>一般情况>>身高", "入院时体检>>一般情况>>体重", "入院时体检>>一般情况>>体重" };
            private string[] m_strKeysArr3 = { "入院时体检>>皮肤", "入院时体检>>淋巴结" };
            private string[] m_strKeysArr4 = { "", "入院时体检>>头部>>眼", "入院时体检>>头部>>耳", "入院时体检>>头部>>口", "入院时体检>>头部>>鼻", "入院时体检>>头部>>颜面" };
            private string[] m_strKeysArr5 = { "", "入院时体检>>颈部>>甲状腺" };
            private string[] m_strKeysArr6 = { "", "入院时体检>>胸部>>乳腺", "入院时体检>>胸部>>乳头", "入院时体检>>胸部>>肺", "入院时体检>>胸部>>心脏" };
            private string[] m_strKeysArr7 = { "", "入院时体检>>腹部>>肝", "入院时体检>>腹部>>脾", "入院时体检>>腹部>>其他" };
            private string[] m_strKeysArr8 = { "", "入院时体检>>会阴>>水肿", "入院时体检>>会阴>>静脉曲张" };
            private string[] m_strKeysArr9 = { "", "入院时体检>>脊柱及四肢>>畸形:", "入院时体检>>脊柱及四肢>>浮肿", "入院时体检>>脊柱及四肢>>膝反射" };
            private string[] m_strKeysArr10 = { "入院时体检>>其他" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false && m_blnHavePrintInfo(m_strKeysArr4) == false
                    && m_blnHavePrintInfo(m_strKeysArr5) == false && m_blnHavePrintInfo(m_strKeysArr6) == false && m_blnHavePrintInfo(m_strKeysArr7) == false && m_blnHavePrintInfo(m_strKeysArr8) == false
                    && m_blnHavePrintInfo(m_strKeysArr9) == false && m_blnHavePrintInfo(m_strKeysArr10) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (p_intPosY >= 1025)
                {//避免“入院时体检”下一行超出底框
                    p_intPosY = 2000;//换页
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //p_intPosY += 20;
                    p_objGrp.DrawString("入院时体检", clsIMR_GynecologyPrintTool.m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    p_intPosY += 30;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "体温：", "℃    脉搏：$$", "次/分    呼吸：$$", "次/分    血压：$$","#mmHg$$" }, m_strKeysArr1, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr2) != false)
                            m_mthMakeText(new string[] { "\n一般情况：", "发育：", "营养：", "神智：", "身高：", "cm；体重：$$","#Kg$$"}, m_strKeysArr2, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n皮肤：", "淋巴结：" }, m_strKeysArr3, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr4) != false)
                            m_mthMakeText(new string[] { "\n头部：", "眼：", "耳：", "鼻：", "口：", "颜面：" }, m_strKeysArr4, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr5) != false)
                            m_mthMakeText(new string[] { "\n颈部：", "甲状腺：" }, m_strKeysArr5, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr6) != false)
                            m_mthMakeText(new string[] { "\n胸部：", "乳腺：", "乳头：", "肺：", "心脏：" }, m_strKeysArr6, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr7) != false)
                            m_mthMakeText(new string[] { "\n腹部：", "肝：", "脾：", "其他：" }, m_strKeysArr7, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr8) != false)
                            m_mthMakeText(new string[] { "\n会阴：", "水肿：", "静脉曲张：" }, m_strKeysArr8, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr9) != false)
                            m_mthMakeText(new string[] { "\n脊柱及四肢：", "畸形：", "浮肿：", "膝反射：" }, m_strKeysArr9, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n其他：" }, m_strKeysArr10, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("入院时体检：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 产科检查
        /// </summary>
        private class clsPrintInPatMedRecObstetricCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private int m_intLineYPos = 0;
            private string[] m_strKeysArr1 = {"","产科检查>>腹部检查>>宫底高度","产科检查>>腹部检查>>宫底高度","产科检查>>腹部检查>>腹围","产科检查>>腹部检查>>腹围"
											 ,"产科检查>>腹部检查>>胎心音","产科检查>>腹部检查>>胎方位","产科检查>>腹部检查>>胎先露","产科检查>>腹部检查>>宫缩","产科检查>>腹部检查>>间隔","产科检查>>腹部检查>>持续","产科检查>>腹部检查>>缩力"};
            private string[] m_strKeysArr2 = { "产科检查>>骨盘径线" };
            private string[] m_strKeysArr3 = { "", "产科检查>>肛查>>宫口开大", "产科检查>>肛查>>宫口开大", "产科检查>>肛查>>宫颈", "产科检查>>肛查>>先露高低", "产科检查>>肛查>>胎膜", "产科检查>>肛查>>羊水" };
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false && m_blnHavePrintInfo(m_strKeysArr3) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (p_intPosY >= 1025)
                {//避免“产科检查”下一行超出底框
                    p_intPosY = 2000;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("产科检查", clsIMR_GynecologyPrintTool.m_fotItemHead, Brushes.Black, m_intRecBaseX + 310, p_intPosY);

                    p_intPosY += 30;
                    m_intLineYPos = p_intPosY;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr1) == true)
                            m_mthMakeText(new string[]{"腹部检查：","宫底高度(耻上)：","#Cm","腹围：","#Cm"
													  ,"胎心音：","胎方位：","胎先露：","宫缩：","间隔：","持续：","缩力："}, m_strKeysArr1, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n骨盆径线：" }, m_strKeysArr2, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr3) == true)
                            m_mthMakeText(new string[] { "\n肛查：", "宫口开大：", "#Cm", "宫颈：", "先露高低：", "胎膜：", "羊水：" }, m_strKeysArr3, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent != null);
                    m_mthAddSign2("产科检查：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
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
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        /// <summary>
        /// 诊断
        /// </summary>
        //private class clsPrintInPatMedRecDiagnosic : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private clsInpatMedRec_Item objItemContent = null;
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_hasItems != null)
        //            if (m_hasItems.Contains("诊断"))
        //                objItemContent = m_hasItems["诊断"] as clsInpatMedRec_Item;
        //        if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }

        //        if (m_blnIsFirstPrint)
        //        {
        //            p_intPosY += 20;
        //            p_objGrp.DrawString("诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_intPosY += 20;
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
        //            m_mthAddSign2("诊断：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
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

        /// <summary>
        /// 诊断
        /// </summary>
        private class clsPrintInPatMedRecCurePlan : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent = null;
            private clsInpatMedRec_Item[] objSignContent = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("诊断"))
                        objItemContent = m_hasItems["诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 40;
                    p_objGrp.DrawString("入院诊断：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_mthPrintSign(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }

            private void m_mthPrintSign(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                objSignContent = m_objGetContentFromItemArr(new string[] { "主治医师", "住院医师", "助产士" });
                if (objSignContent == null)
                    return;
                //   p_intPosY += 20;
                p_objGrp.DrawString("主治医师：" + (objSignContent[0] == null ? "" : objSignContent[0].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                p_objGrp.DrawString("住院医师：" + (objSignContent[1] == null ? "" : objSignContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 475, p_intPosY);
                //  p_objGrp.DrawString("助产士：" + (objSignContent[2] == null ? "" : objSignContent[2].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                p_intPosY += 20;
            }
        }

        /// <summary>
        /// 修正诊断
        /// </summary>
        private class clsPrintInPatMedRecDia2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("修正诊断"))
                        objItemContent1 = m_hasItems["修正诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名"))
                        objItemContent2 = m_hasItems["修正诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名日期"))
                        objItemContent3 = m_hasItems["修正诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("修正诊断：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }

        /// <summary>
        /// 补充诊断
        /// </summary>
        private class clsPrintInPatMedRecDia3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("补充诊断"))
                        objItemContent1 = m_hasItems["补充诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名"))
                        objItemContent2 = m_hasItems["补充诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名日期"))
                        objItemContent3 = m_hasItems["补充诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("补充诊断：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("补充诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }


        /// <summary>
        /// 最后诊断
        /// </summary>
        private class clsPrintInPatMedRecDia4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fntHeadFont = new Font("Simsun", 11, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("最后诊断"))
                        objItemContent1 = m_hasItems["最后诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("最后诊断医师签名"))
                        objItemContent2 = m_hasItems["最后诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("最后诊断医师签名日期"))
                        objItemContent3 = m_hasItems["最后诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("最后诊断：", m_fntHeadFont, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("最后诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                    m_blnHaveMoreLine = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }





        #endregion
    }
}

