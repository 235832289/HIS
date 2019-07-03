using System;
using System.Collections.Generic;
using System.Text;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    class clsIMR__EyeTakecarePrint : clsInpatMedRecPrintBase
    {
        public clsIMR__EyeTakecarePrint(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("眼科护理记录",320),
                                                                           new clsPrint3(),
                                                                           new clsPrint2(),
                                                                           new clsPrint4(),
                                                                           new clsPrint5(),
                                                                           new clsPrint6(),
                                                                           new clsPrint7(),
                                                                           new clsPrint8(),
                                                                           new clsPrint9(),
                                                                       });
        }
        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            public clsPrintPatientFixInfo(string p_strChildTitleName, int p_intChildTitleNameOffSetX)
            {
                m_strChildTitleName = p_strChildTitleName;
                m_intChildTitleNameOffSetX = p_intChildTitleNameOffSetX;

            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        #region 首次记录和签名
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string[] m_strKeysArr01 = { "首次记录时间", "首次记录>>签名" };
            public clsPrint2()
            {
               
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("首次记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["首次记录时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_blnIsFirstPrint)
                {
                    //p_intPosY -= 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(new string[] { "#                                                  记录时间：" + strBeforeOperatorTime, "        签名：$$" }, m_strKeysArr01, ref strAllText, ref strXml);
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
        #region 护理级别饮食治疗原则
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string[] m_strKeysArr101 = { "\n护理级别：", "护理>>Ⅰ级护理", "护理>>Ⅱ级护理", "护理>>Ⅲ级护理" };
            private string[] m_strKeysArr01 = { "护理>>Ⅰ级护理", "护理>>Ⅱ级护理", "护理>>Ⅲ级护理" };
            private string[] m_strKeysArr02 = {"饮食>>普食", "饮食>>低盐饮食", "饮食>>低脂饮食", "饮食>>低胆固醇饮食", "饮食>>糖尿病饮食" };
            private string[] m_strKeysArr102 = { "\n饮食：", "饮食>>普食", "饮食>>低盐饮食", "饮食>>低脂饮食", "饮食>>低胆固醇饮食", "饮食>>糖尿病饮食"};
            private string[] m_strKeysArr203 = { "\n饮食：" };
            private string[] m_strKeysArr03 = { "饮食>>其他" };
            private string[] m_strKeysArr103 = { "其他：" };
            private string[] m_strKeysArr04 = { "治疗原则>>抗炎滴眼治疗", "治疗原则>>抗炎降眼压滴眼治疗", "治疗原则>>抗炎扩瞳滴眼治疗", "治疗原则>>止血治疗", "治疗原则>>全身抗炎治疗", "治疗原则>>降眼压治疗" };
            private string[] m_strKeysArr104 = { "\n治疗原则：", "治疗原则>>抗炎滴眼治疗", "治疗原则>>抗炎降眼压滴眼治疗", "治疗原则>>抗炎扩瞳滴眼治疗", "治疗原则>>止血治疗", "治疗原则>>全身抗炎治疗", "治疗原则>>降眼压治疗" };
            private string[] m_strKeysArr05 = { "治疗原则>>其他" };
            private string[] m_strKeysArr105 = { "其他：" };
            private string[] m_strKeysArr205 = { "\n治疗原则：" };
            private string[] m_strKeysArr = { "护理>>Ⅰ级护理", "护理>>Ⅱ级护理", "护理>>Ⅲ级护理", "饮食>>普食", "饮食>>低盐饮食", "饮食>>低脂饮食", "饮食>>低胆固醇饮食", "饮食>>糖尿病饮食",
                                              "饮食>>其他","治疗原则>>抗炎滴眼治疗", "治疗原则>>抗炎降眼压滴眼治疗", "治疗原则>>抗炎扩瞳滴眼治疗", "治疗原则>>止血治疗", "治疗原则>>全身抗炎治疗",
                                              "治疗原则>>降眼压治疗","治疗原则>>其他","首次记录时间", "首次记录>>签名"};
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("首次记录", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01))
                            m_mthMakeCheckText(m_strKeysArr101, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02))
                        {
                            m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr03))
                                m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr03))
                            m_mthMakeText(m_strKeysArr203, m_strKeysArr03, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04))
                        {
                            m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr05))
                                m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        }
                        else if(m_blnHavePrintInfo(m_strKeysArr05))
                            m_mthMakeText(m_strKeysArr205, m_strKeysArr05, ref strAllText, ref strXml);
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
        #region 术前记录1
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string[] m_strKeysArr08 = { "术前记录1>>饮食>>普食", "术前记录1>>饮食>>低盐饮食", "术前记录1>>饮食>>低脂饮食", "术前记录1>>饮食>>低胆固醇饮食", "术前记录1>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr108 = { "\n饮食：", "术前记录1>>饮食>>普食", "术前记录1>>饮食>>低盐饮食", "术前记录1>>饮食>>低脂饮食", "术前记录1>>饮食>>低胆固醇饮食", "术前记录1>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr209 = { "\n饮食：" };
            private string[] m_strKeysArr09 = { "术前记录1>>饮食>>其他" };
            private string[] m_strKeysArr109 = { "其他：" };
            private string[] m_strKeysArr01 = { "术前记录>>执行时间" };
            private string[] m_strKeysArr02 = { "术前记录>>右眼", "术前记录>>左眼" };
            private string[] m_strKeysArr102 = { "\n术眼：", "术前记录>>右眼", "术前记录>>左眼" };
            private string[] m_strKeysArr03 = { "术前记录>>记录时间", "术前记录>>签名" };
            private string[] m_strKeysArr04 = { "术前记录>>月", "术前记录>>日", "术前记录>>麻醉", "术前记录>>手术"};
            private string[] m_strKeysArr204 = { "", "术前记录>>月", "", "术前记录>>日", "", "术前记录>>麻醉", "术前记录>>麻醉", "术前记录>>麻醉", "术前记录>>手术", "术前记录>>手术", "术前记录>>手术" };
            private string[] m_strKeysArr104;
            private string[] m_strKeysArr07 = { "术前记录>>禁食八小时", "术前记录>>禁水六小时" };
            private string[] m_strKeysArr107 = { "\n术前晚：", "术前记录>>禁食八小时", "术前记录>>禁水六小时" };
            private string[] m_strKeysArr07a = { "术前晚>>其他" };
            private string[] m_strKeysArr107a = { "  其他：" };
            private string[] m_strKeysArr107b = { "\n术前晚：" };
            private string[] m_strKeysArr = { "术前记录>>右眼", "术前记录>>左眼", "术前记录>>月", "术前记录>>日", "术前记录>>麻醉", "术前记录>>手术" ,
                                               "术前记录>>禁食八小时", "术前记录>>禁水六小时","术前晚>>其他","术前记录>>记录时间", "术前记录>>签名",
                                               "术前记录1>>饮食>>普食", "术前记录1>>饮食>>低盐饮食", "术前记录1>>饮食>>低脂饮食", "术前记录1>>饮食>>低胆固醇饮食", "术前记录1>>饮食>>糖尿病饮食","术前记录1>>饮食>>其他"};
            public clsPrint4()
            {
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("术前记录>>执行时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术前记录>>执行时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术前记录>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术前记录>>记录时间"];
                    strBeforeOperatorTime2 = objItem.m_strItemContent;
                }
                m_strKeysArr104 = new string[] { "\n患者定于", "$$", "月$$", "$$", "日$$", "#在$$", "$$", "#麻下$$", "#行$$", "$$", "#手术。$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("术前记录1", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr02))
                            m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04))
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr204, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08))
                        {
                            m_mthMakeCheckText(m_strKeysArr108, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09))
                                m_mthMakeText(m_strKeysArr109, m_strKeysArr09, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09))
                            m_mthMakeText(m_strKeysArr209, m_strKeysArr09, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07))
                        {
                            m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr07a))
                                m_mthMakeText(m_strKeysArr107a, m_strKeysArr07a, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr07a))
                            m_mthMakeText(m_strKeysArr107b, m_strKeysArr07a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime2, "    签名：$$" }, m_strKeysArr03, ref strAllText, ref strXml);
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
        #region 术前记录2
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string[] m_strKeysArr08 = { "术前记录2>>饮食>>普食", "术前记录2>>饮食>>低盐饮食", "术前记录2>>饮食>>低脂饮食", "术前记录2>>饮食>>低胆固醇饮食", "术前记录2>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr108 = { "\n饮食：", "术前记录2>>饮食>>普食", "术前记录2>>饮食>>低盐饮食", "术前记录2>>饮食>>低脂饮食", "术前记录2>>饮食>>低胆固醇饮食", "术前记录2>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr209 = { "\n饮食：" };
            private string[] m_strKeysArr109 = { "其他：" };
            private string[] m_strKeysArr09 = { "术前记录2>>饮食>>其他" };
            private string[] m_strKeysArr01 = { "术晨记录>>执行时间" };
            private string[] m_strKeysArr03 = { "术晨记录>>记录时间", "术晨记录>>签名" };
            private string[] m_strKeysArr05 = { "术晨记录>>夜间>>正常", "术晨记录>>夜间>>入睡难", "术晨记录>>夜间>>易醒", "术晨记录>>夜间>>失眠", "术晨记录>>夜间>>晨起疲劳" };
            private string[] m_strKeysArr105 = { "\n观察患者夜间睡眠情况：", "术晨记录>>夜间>>正常", "术晨记录>>夜间>>入睡难", "术晨记录>>夜间>>易醒", "术晨记录>>夜间>>失眠", "术晨记录>>夜间>>晨起疲劳" };
            private string[] m_strKeysArr = { "术晨记录>>夜间>>正常", "术晨记录>>夜间>>入睡难", "术晨记录>>夜间>>易醒", "术晨记录>>夜间>>失眠", "术晨记录>>夜间>>晨起疲劳",
                                               "术晨记录>>T",  "术晨记录>>P",  "术晨记录>>R",  "术晨记录>>BP", "术晨记录>>记录时间", "术晨记录>>签名",
                                               "术前记录2>>饮食>>普食", "术前记录2>>饮食>>低盐饮食", "术前记录2>>饮食>>低脂饮食", "术前记录2>>饮食>>低胆固醇饮食", "术前记录2>>饮食>>糖尿病饮食","术前记录2>>饮食>>其他"};
            public clsPrint5()
            {
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("术晨记录>>执行时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术晨记录>>执行时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术晨记录>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术晨记录>>记录时间"];
                    strBeforeOperatorTime2 = objItem.m_strItemContent;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术前记录2", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    string[] m_strKeysArr07 = { "术晨记录>>T", "术晨记录>>T", "术晨记录>>P", "术晨记录>>P", "术晨记录>>R", "术晨记录>>R", "术晨记录>>BP", "术晨记录>>BP" };
                    string[] m_strKeysArr107 = { "\nT：", "#℃$$", "          P：$$", "#次/分$$","          R：$$", "#次/分$$","          BP：$$", "#mmHg$$" };
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr05))
                            m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08))
                        {
                            m_mthMakeCheckText(m_strKeysArr108, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09))
                                m_mthMakeText(m_strKeysArr109, m_strKeysArr09, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09))
                            m_mthMakeText(m_strKeysArr209, m_strKeysArr09, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime2, "    签名：$$" }, m_strKeysArr03, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(new string[] { "#  执行时间：" + strBeforeOperatorTime }, m_strKeysArr01, ref strAllText, ref strXml);
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
        #region 术前准备
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string[] m_strKeysArr38 = { "术前准备>>饮食>>普食", "术前准备>>饮食>>低盐饮食", "术前准备>>饮食>>低脂饮食", "术前准备>>饮食>>低胆固醇饮食", "术前准备>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr138 = { "\n饮食：", "术前准备>>饮食>>普食", "术前准备>>饮食>>低盐饮食", "术前准备>>饮食>>低脂饮食", "术前准备>>饮食>>低胆固醇饮食", "术前准备>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr239 = { "\n饮食：" };
            private string[] m_strKeysArr139 = { "其他：" };
            private string[] m_strKeysArr39 = { "术前准备>>饮食>>其他" };
            private string[] m_strKeysArr01 = { "术前准备>>执行时间",  };
            private string[] m_strKeysArr03 = { "术前准备>>记录时间", "术前准备>>签名" };
            private string[] m_strKeysArr205 = { "术前准备>>口服鲁米那",  "术前准备>>肌注鲁米那", "术前准备>>肌注止血敏", "术前准备>>肌注立血止" };
            private string[] m_strKeysArr05 = { "", "术前准备>>口服鲁米那", "术前准备>>口服鲁米那", "术前准备>>肌注鲁米那", "术前准备>>肌注鲁米那", "术前准备>>肌注止血敏", "术前准备>>肌注止血敏", "术前准备>>肌注立血止", "术前准备>>肌注立血止" };
            private string[] m_strKeysArr105;
            private string[] m_strKeysArr06 = { "术前准备>>冲洗术眼结膜囊", "术前准备>>静脉留置套管针" };
            private string[] m_strKeysArr106 = { "\n", "术前准备>>冲洗术眼结膜囊", "术前准备>>静脉留置套管针" };
            private string[] m_strKeysArr07 = { "术前准备>>散眼瞳孔>>右眼", "术前准备>>散眼瞳孔>>左眼" };
            private string[] m_strKeysArr107 = { "\n散术眼瞳孔：", "术前准备>>散眼瞳孔>>右眼", "术前准备>>散眼瞳孔>>左眼" };
            private string[] m_strKeysArr08 = { "术前准备>>瞳孔散大", "术前准备>>瞳孔散大" };
            private string[] m_strKeysArr108;
            private string[] m_strKeysArr208;
            private string[] m_strKeysArr09 = {  "术前准备>>缩眼瞳孔>>右眼", "术前准备>>缩眼瞳孔>>左眼" };
            private string[] m_strKeysArr109 = { "      缩术眼瞳孔：", "术前准备>>缩眼瞳孔>>右眼", "术前准备>>缩眼瞳孔>>左眼" };
            private string[] m_strKeysArr09a = { "术前准备>>瞳孔缩小", "术前准备>>瞳孔缩小"};
            private string[] m_strKeysArr109a;
            private string[] m_strKeysArr209a;
            private string[] m_strKeysArr05a = {"术前记录>>通畅", "术前记录>>通而不畅", "术前记录>>不通畅" };
            private string[] m_strKeysArr105a = { "\n冲洗术眼泪道：", "术前记录>>通畅", "术前记录>>通而不畅", "术前记录>>不通畅" };
            private string[] m_strKeysArr05a1 = {"术前记录>>有脓性分泌物", "术前记录>>无脓性分泌物"  };
            private string[] m_strKeysArr105a1 = { "", "术前记录>>有脓性分泌物", "术前记录>>无脓性分泌物" };
            private string[] m_strKeysArr06a = { "术前记录>>剪术眼睫毛" };
            private string[] m_strKeysArr106a = { "", "术前记录>>剪术眼睫毛" };
            private string[] m_strKeysArr = { "术前准备>>口服鲁米那", "术前准备>>肌注鲁米那", "术前准备>>肌注止血敏", "术前准备>>肌注立血止" ,
                                               "术前记录>>剪术眼睫毛","冲洗术眼泪道","术前准备>>冲洗术眼结膜囊", "术前准备>>静脉留置套管针",
                                               "术前准备>>散眼瞳孔>>右眼", "术前准备>>散眼瞳孔>>左眼", "术前准备>>瞳孔散大",
                                                "术前准备>>缩眼瞳孔>>右眼", "术前准备>>缩眼瞳孔>>左眼","术前准备>>瞳孔缩小",
                                               "术前准备>>记录时间", "术前准备>>签名","术前准备>>饮食>>其他",
                                               "术前准备>>饮食>>普食", "术前准备>>饮食>>低盐饮食", "术前准备>>饮食>>低脂饮食", "术前准备>>饮食>>低胆固醇饮食", "术前准备>>饮食>>糖尿病饮食"};
            public clsPrint6()
            {
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("术前准备>>执行时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术前准备>>执行时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术前准备>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术前准备>>记录时间"];
                    strBeforeOperatorTime2 = objItem.m_strItemContent;
                }
                m_strKeysArr105 = new string[]{ "\n术前用药：", "口服鲁米那：$$", "#mg；$$", "肌注鲁米那：$$", "#g；$$", "肌注止血敏：$$", "#g；$$", "肌注立止血：$$", "#ku。$$" };
                m_strKeysArr108 = new string[]{ "", "#瞳孔散大；$$" };
                m_strKeysArr208 = new string[]{ "#\n散术眼瞳孔：", "$$", "#瞳孔散大$$" };
                m_strKeysArr109a = new string[]{ "", "#瞳孔缩小$$" };
                m_strKeysArr209a =new string[] { "#缩术眼瞳孔：", "$$","#瞳孔缩小$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("术前准备", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr205))
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr38))
                        {
                            m_mthMakeCheckText(m_strKeysArr138, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr39))
                                m_mthMakeText(m_strKeysArr139, m_strKeysArr39, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr39))
                            m_mthMakeText(m_strKeysArr239, m_strKeysArr39, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06a))
                            m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(new string[] { "冲洗术眼泪道" }))
                            m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05a1))
                            m_mthMakeCheckText(m_strKeysArr105a1, ref strAllText, ref strXml);
                        
                        if (m_blnHavePrintInfo(m_strKeysArr06))
                            m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01))
                            m_mthMakeText(new string[] { "#\n                                                执行时间：" + strBeforeOperatorTime }, m_strKeysArr01, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07))
                        {
                            m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr08))
                                m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr08))
                            m_mthMakeText(m_strKeysArr208, m_strKeysArr08, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09))
                        {
                            m_mthMakeCheckText(m_strKeysArr109, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09a))
                                m_mthMakeText(m_strKeysArr109a, m_strKeysArr09a, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09a))
                                m_mthMakeText(m_strKeysArr209a, m_strKeysArr09a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03))
                            m_mthMakeText(new string[] { "#\n                                                记录时间：" + strBeforeOperatorTime2, "    签名：$$" }, m_strKeysArr03, ref strAllText, ref strXml);
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
        #region 术日护理记录
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint7 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string[] m_strKeysArr03 = { "术日护理记录>>记录时间", "术日护理记录>>签名" };
            private string[] m_strKeysArr04 = { "术日护理记录>>月", "术日护理记录>>日", "术日护理记录>>麻醉", "术日护理记录>>手术", "术日护理记录>>返回时间"};
            private string[] m_strKeysArr204 = { "", "术日护理记录>>月", "", "术日护理记录>>日", "", "术日护理记录>>麻醉", "术日护理记录>>麻醉", "术日护理记录>>麻醉", "术日护理记录>>手术", "术日护理记录>>手术", "术日护理记录>>手术", "术日护理记录>>返回时间", "术日护理记录>>返回时间", "术日护理记录>>返回时间" };
            private string[] m_strKeysArr104;
            private string[] m_strKeysArr06 = { "术日护理记录>>眼垫>>清洁", "术日护理记录>>眼垫>>干燥" };
            private string[] m_strKeysArr106 = { "\n眼垫在位：", "术日护理记录>>眼垫>>清洁", "术日护理记录>>眼垫>>干燥" };
            private string[] m_strKeysArr07 = {  "术日护理记录>>绷带>>清洁", "术日护理记录>>绷带>>干燥" };
            private string[] m_strKeysArr107 = { "绷带包扎在位：", "术日护理记录>>绷带>>清洁", "术日护理记录>>绷带>>干燥" };
            private string[] m_strKeysArr07a = { "术日护理记录绷带>>其他","术日护理记录绷带>>其他" };
            private string[] m_strKeysArr107a;
            private string[] m_strKeysArr08 = { "术日护理记录>>异物大小", "术日护理记录>>异物其他" };
            private string[] m_strKeysArr108 = { "\n取出异物性质大小：", "其他：" };
            private string[] m_strKeysArr09 = { "术日护理记录>>Ⅰ级护理", "术日护理记录>>Ⅱ级护理", "术日护理记录>>Ⅲ级护理" };
            private string[] m_strKeysArr109 = { "\n护理级别：", "术日护理记录>>Ⅰ级护理", "术日护理记录>>Ⅱ级护理", "术日护理记录>>Ⅲ级护理" };
            private string[] m_strKeysArr09a = { "术日护理记录>>护理其他" };
            private string[] m_strKeysArr109a = { "其他：" };
            private string[] m_strKeysArr209a = { "\n护理级别：" };
            private string[] m_strKeysArr09b = { "术日护理记录>>眼抗炎滴治疗", "术日护理记录>>抗炎降压滴眼治疗", "术日护理记录>>抗炎扩瞳滴眼治疗", "术日护理记录>>降眼压治疗", "术日护理记录>>全身抗炎治疗", "术日护理记录>>止血治疗" };
            private string[] m_strKeysArr109b = { "\n治疗原则：", "术日护理记录>>抗炎滴眼治疗", "术日护理记录>>抗炎降压滴眼治疗", "术日护理记录>>抗炎扩瞳滴眼治疗", "术日护理记录>>降眼压治疗", "术日护理记录>>全身抗炎治疗", "术日护理记录>>止血治疗" };
            private string[] m_strKeysArr09g = { "术日护理记录>>治疗原则其他" };
            private string[] m_strKeysArr109g = { "其他：" };
            private string[] m_strKeysArr209g = { "\n治疗原则：" };
            private string[] m_strKeysArr09c = { "术日护理记录饮食>>普食", "术日护理记录饮食>>半流", "术日护理记录饮食>>流质" };
            private string[] m_strKeysArr109c = { "\n饮食：", "术日护理记录饮食>>普食", "术日护理记录饮食>>半流", "术日护理记录饮食>>流质" };
            private string[] m_strKeysArr09d = { "术日护理记录>>平卧", "术日护理记录>>半卧", "术日护理记录>>俯卧" };
            private string[] m_strKeysArr109d = { "卧位：", "术日护理记录>>平卧", "术日护理记录>>半卧", "术日护理记录>>俯卧" };
            private string[] m_strKeysArr09e = { "术日护理记录疼痛>>无", "术日护理记录疼痛>>有" };
            private string[] m_strKeysArr109e = { "\n疼痛：", "术日护理记录疼痛>>无", "术日护理记录疼痛>>有" };
            private string[] m_strKeysArr09f = { "术日护理记录疼痛>>能忍受", "术日护理记录疼痛>>不能忍受" };
            private string[] m_strKeysArr109f = { "", "术日护理记录疼痛>>能忍受", "术日护理记录疼痛>>不能忍受" };
            private string[] m_strKeysArr109f1 = { "\n疼痛：", "术日护理记录疼痛>>能忍受", "术日护理记录疼痛>>不能忍受" };
            private string[] m_strKeysArr09h = { "术日护理记录>>疼痛其他" };
            private string[] m_strKeysArr109h = { "其他：" };
            private string[] m_strKeysArr = { "术日护理记录>>月", "术日护理记录>>日", "术日护理记录>>麻醉", "术日护理记录>>手术", "术日护理记录>>返回时间" ,
                                              "术日护理记录>>T",  "术日护理记录>>P",  "术日护理记录>>R",  "术日护理记录>>BP", "术日护理记录>>眼垫>>清洁", "术日护理记录>>眼垫>>干燥",
                                              "术日护理记录>>绷带>>清洁", "术日护理记录>>绷带>>干燥","术日护理记录绷带>>其他","术日护理记录>>异物大小", "术日护理记录>>异物其他",
                                              "术日护理记录>>Ⅰ级护理", "术日护理记录>>Ⅱ级护理", "术日护理记录>>Ⅲ级护理","术日护理记录>>护理其他",
                                              "术日护理记录>>眼抗炎滴治疗", "术日护理记录>>抗炎降压滴眼治疗", "术日护理记录>>抗炎扩瞳滴眼治疗", "术日护理记录>>降眼压治疗", "术日护理记录>>全身抗炎治疗", "术日护理记录>>止血治疗" ,
                                              "术日护理记录>>治疗原则其他","术日护理记录饮食>>普食", "术日护理记录饮食>>半流", "术日护理记录饮食>>流质",
                                              "术日护理记录>>平卧", "术日护理记录>>半卧", "术日护理记录>>俯卧", "术日护理记录疼痛>>无", "术日护理记录疼痛>>有",
                                              "术日护理记录疼痛>>能忍受", "术日护理记录疼痛>>不能忍受","术日护理记录>>疼痛其他","术日护理记录>>记录时间", "术日护理记录>>签名"  };
            public clsPrint7()
            {
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("术日护理记录>>执行时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术日护理记录>>执行时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术日护理记录>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术日护理记录>>记录时间"];
                    strBeforeOperatorTime2 = objItem.m_strItemContent;
                }
                m_strKeysArr104 = new string[]{ "\n患者于","$$", "月$$","$$", "日$$","#在$$","$$", "#麻下$$","#行$$", "$$","#手术，$$","#于$$","$$", "#返回病房。$$" };
                m_strKeysArr107a =new string[] { "其他：","#；$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("术日护理记录", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    string[] m_strKeysArr05 = { "术日护理记录>>T", "术日护理记录>>T", "术日护理记录>>P", "术日护理记录>>P", "术日护理记录>>R", "术日护理记录>>R", "术日护理记录>>BP", "术日护理记录>>BP" };
                    string[] m_strKeysArr105 = { "\nT：", "#℃$$","          P：$$", "#次/分$$","          R：$$", "#次/分$$","          BP：$$", "#mmHg$$" };
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr04))
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr204, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05))
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06))
                            m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07))
                            m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07a))
                            m_mthMakeText(m_strKeysArr107a, m_strKeysArr07a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08))
                            m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09))
                        {
                            m_mthMakeCheckText(m_strKeysArr109, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09a))
                                m_mthMakeText(m_strKeysArr109a, m_strKeysArr09a, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09a))
                            m_mthMakeText(m_strKeysArr209a, m_strKeysArr09a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09b))
                        {
                            m_mthMakeCheckText(m_strKeysArr109b, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09g))
                                m_mthMakeText(m_strKeysArr109g, m_strKeysArr09g, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09g))
                            m_mthMakeText(m_strKeysArr209g, m_strKeysArr09g, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09c))
                            m_mthMakeCheckText(m_strKeysArr109c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09d))
                            m_mthMakeCheckText(m_strKeysArr109d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09e))
                        {
                            m_mthMakeCheckText(m_strKeysArr109e, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr09f))
                                m_mthMakeCheckText(m_strKeysArr109f, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr09f))
                                m_mthMakeCheckText(m_strKeysArr109f1, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr09h))
                            m_mthMakeText(m_strKeysArr109h,m_strKeysArr09h, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime2, "    签名：$$" }, m_strKeysArr03, ref strAllText, ref strXml);
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
        #region 术后护理记录
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string strBeforeOperatorTime3 = "";
            private string[] m_strKeysArr02 = { "术后护理>>右眼", "术后护理>>左眼" };
            private string[] m_strKeysArr102 = { "\n术眼：", "术后护理>>右眼", "术后护理>>左眼" };
            private string[] m_strKeysArr04 = { "术后护理>>天", "术后护理>>天" };
            private string[] m_strKeysArr104;
            private string[] m_strKeysArr05 = { "术后护理眼垫>>清洁", "术后护理眼垫>>干燥" };
            private string[] m_strKeysArr105 = { "眼垫在位：", "术后护理眼垫>>清洁", "术后护理眼垫>>干燥" };
            private string[] m_strKeysArr06 = {  "术后护理绷带>>清洁", "术后护理绷带>>干燥" };
            private string[] m_strKeysArr106 = { "绷带包扎在位：", "术后护理绷带>>清洁", "术后护理绷带>>干燥" };
            private string[] m_strKeysArr07 = { "术后护理绷带>>其他" };
            private string[] m_strKeysArr107 = { "其他：" };
            private string[] m_strKeysArr38 = { "术后1>>饮食>>普食", "术后1>>饮食>>低盐饮食", "术后1>>饮食>>低脂饮食", "术后1>>饮食>>低胆固醇饮食", "术后1>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr138 = { "\n饮食：", "术后1>>饮食>>普食", "术后1>>饮食>>低盐饮食", "术后1>>饮食>>低脂饮食", "术后1>>饮食>>低胆固醇饮食", "术后1>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr239 = { "\n饮食：" };
            private string[] m_strKeysArr139 = { "其他：" };
            private string[] m_strKeysArr39 = { "术后1>>饮食>>其他" };
            private string[] m_strKeysArr08 = { "术后护理伤口痛>>无", "术后护理伤口痛>>有" };
            private string[] m_strKeysArr108 = { "\n伤口痛：", "术后护理伤口痛>>无", "术后护理伤口痛>>有" };
            private string[] m_strKeysArr09 = { "术后护理伤头痛>>无", "术后护理伤头痛>>有"};
            private string[] m_strKeysArr109 = { "头痛：", "术后护理伤头痛>>无", "术后护理伤头痛>>有" };
            private string[] m_strKeysArr10 = {"术后护理伤口痛>>能忍受", "术后护理伤口痛>>不能忍受" };
            private string[] m_strKeysArr101 = { "","术后护理伤口痛>>能忍受", "术后护理伤口痛>>不能忍受" };
            private string[] m_strKeysArr081 = { "术后护理恶心>>无", "术后护理恶心>>有" };
            private string[] m_strKeysArr1081 = { "\n恶心：", "术后护理恶心>>无", "术后护理恶心>>有" };
            private string[] m_strKeysArr091 = { "术后护理呕吐>>无", "术后护理呕吐>>有" };
            private string[] m_strKeysArr1091 = { "呕吐：", "术后护理呕吐>>无", "术后护理呕吐>>有" };
            private string[] m_strKeysArr09k = { "术后护理>>其他1" };
            private string[] m_strKeysArr109k = { "\n其他：" };
            private string[] m_strKeysArr092 = {"术后护理1>>记录时间", "术后护理>>签名" };
            private string[] m_strKeysArr04a = { "术后护理2>>天", "术后护理2>>天" };
            private string[] m_strKeysArr104a;
            private string[] m_strKeysArr05a = { "术后护理眼垫2>>清洁", "术后护理眼垫2>>干燥" };
            private string[] m_strKeysArr105a = { "眼垫在位：", "术后护理眼垫2>>清洁", "术后护理眼垫2>>干燥" };
            private string[] m_strKeysArr06a = {  "术后护理绷带2>>清洁", "术后护理绷带2>>干燥" };
            private string[] m_strKeysArr106a = { "绷带包扎在位：", "术后护理绷带2>>清洁", "术后护理绷带2>>干燥" };
            private string[] m_strKeysArr07a = { "术后护理绷带2>>其他" };
            private string[] m_strKeysArr107a = { "其他：" };
            private string[] m_strKeysArr48 = { "术后2>>饮食>>普食", "术后2>>饮食>>低盐饮食", "术后2>>饮食>>低脂饮食", "术后2>>饮食>>低胆固醇饮食", "术后2>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr148 = { "\n饮食：", "术后2>>饮食>>普食", "术后2>>饮食>>低盐饮食", "术后2>>饮食>>低脂饮食", "术后2>>饮食>>低胆固醇饮食", "术后2>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr249 = { "\n饮食：" };
            private string[] m_strKeysArr149 = { "其他：" };
            private string[] m_strKeysArr49 = { "术后2>>饮食>>其他" };
            private string[] m_strKeysArr08a = { "术后护理伤口痛2>>无", "术后护理伤口痛2>>有" };
            private string[] m_strKeysArr108a = { "\n伤口痛：", "术后护理伤口痛2>>无", "术后护理伤口痛2>>有" };
            private string[] m_strKeysArr09a = {  "术后护理伤头痛2>>无", "术后护理伤头痛2>>有"};
            private string[] m_strKeysArr109a = { "头痛：", "术后护理伤头痛2>>无", "术后护理伤头痛2>>有"};
            private string[] m_strKeysArr20 = { "术后护理伤口痛2>>能忍受", "术后护理伤口痛2>>不能忍受" };
            private string[] m_strKeysArr201 = { "", "术后护理伤口痛2>>能忍受", "术后护理伤口痛2>>不能忍受" };
            private string[] m_strKeysArr081a = { "术后护理恶心2>>无", "术后护理恶心2>>有" };
            private string[] m_strKeysArr1081a = { "\n恶心：", "术后护理恶心2>>无", "术后护理恶心2>>有" };
            private string[] m_strKeysArr091a = { "术后护理呕吐2>>无", "术后护理呕吐2>>有" };
            private string[] m_strKeysArr1091a = { "呕吐：", "术后护理呕吐2>>无", "术后护理呕吐2>>有" };
            private string[] m_strKeysArr09m = { "术后护理>>其他3" };
            private string[] m_strKeysArr109m = { "\n其他：" };
            private string[] m_strKeysArr092a = { "术后护理2>>记录时间", "术后护理2>>签名" };
            private string[] m_strKeysArr04b = { "术后护理3>>天", "术后护理3>>天" };
            private string[] m_strKeysArr104b;
            private string[] m_strKeysArr05b = {  "术后护理眼垫3>>清洁", "术后护理眼垫3>>干燥" };
            private string[] m_strKeysArr105b = { "眼垫在位：", "术后护理眼垫3>>清洁", "术后护理眼垫3>>干燥" };
            private string[] m_strKeysArr06b = {  "术后护理绷带3>>清洁", "术后护理绷带3>>干燥" };
            private string[] m_strKeysArr106b = { "绷带包扎在位：", "术后护理绷带3>>清洁", "术后护理绷带3>>干燥" };
            private string[] m_strKeysArr07b = { "术后护理绷带3>>其他" };
            private string[] m_strKeysArr107b = { "其他：" };
            private string[] m_strKeysArr58 = { "术后3>>饮食>>普食", "术后3>>饮食>>低盐饮食", "术后3>>饮食>>低脂饮食", "术后3>>饮食>>低胆固醇饮食", "术后3>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr158 = { "\n饮食：", "术后3>>饮食>>普食", "术后3>>饮食>>低盐饮食", "术后3>>饮食>>低脂饮食", "术后3>>饮食>>低胆固醇饮食", "术后3>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr259 = { "\n饮食：" };
            private string[] m_strKeysArr159 = { "其他：" };
            private string[] m_strKeysArr59 = { "术后3>>饮食>>其他" };
            private string[] m_strKeysArr08b = { "术后护理伤口痛3>>无", "术后护理伤口痛3>>有" };
            private string[] m_strKeysArr108b = { "\n伤口痛：", "术后护理伤口痛3>>无", "术后护理伤口痛3>>有" };
            private string[] m_strKeysArr09b = { "术后护理伤头痛3>>无", "术后护理伤头痛3>>有"};
            private string[] m_strKeysArr109b = { "头痛：", "术后护理伤头痛3>>无", "术后护理伤头痛3>>有" };
            private string[] m_strKeysArr30 = { "术后护理伤口痛3>>能忍受", "术后护理伤口痛3>>不能忍受" };
            private string[] m_strKeysArr301 = { "", "术后护理伤口痛3>>能忍受", "术后护理伤口痛3>>不能忍受" };
            private string[] m_strKeysArr081b = { "术后护理恶心3>>无", "术后护理恶心3>>有" };
            private string[] m_strKeysArr1081b = { "\n恶心：", "术后护理恶心3>>无", "术后护理恶心3>>有" };
            private string[] m_strKeysArr091b = {  "术后护理呕吐3>>无", "术后护理呕吐3>>有" };
            private string[] m_strKeysArr1091b = { "呕吐：", "术后护理呕吐3>>无", "术后护理呕吐3>>有" };
            private string[] m_strKeysArr092b = { "术后护理3>>记录时间","术后护理3>>签名" };
            private string[] m_strKeysArr09n = { "术后护理>>其他3" };
            private string[] m_strKeysArr109n = { "\n其他：" };
            private string[] m_strKeysArr1092b = { "\n                                             签名：" };
            private string[] m_strKeysArr = { "术后护理>>右眼", "术后护理>>左眼", "术后护理>>天", "术后护理眼垫>>清洁", "术后护理眼垫>>干燥",
                                              "术后护理绷带>>清洁", "术后护理绷带>>干燥" , "术后护理绷带>>其他" ,"术后护理伤口痛>>无", "术后护理伤口痛>>有",
                                              "术后护理伤头痛>>无", "术后护理伤头痛>>有","术后护理伤口痛>>能忍受", "术后护理伤口痛>>不能忍受",
                                              "术后护理恶心>>无", "术后护理恶心>>有", "术后护理呕吐>>无", "术后护理呕吐>>有" ,
                                              "术后护理1>>记录时间", "术后护理>>签名","术后护理2>>天", "术后护理眼垫2>>清洁", "术后护理眼垫2>>干燥",
                                              "术后护理绷带2>>清洁", "术后护理绷带2>>干燥", "术后护理绷带2>>其他", "术后护理伤口痛2>>无", "术后护理伤口痛2>>有",
                                              "术后护理伤头痛2>>无", "术后护理伤头痛2>>有","术后护理伤口痛2>>能忍受", "术后护理伤口痛2>>不能忍受",
                                              "术后护理恶心2>>无", "术后护理恶心2>>有", "术后护理呕吐2>>无", "术后护理呕吐2>>有","术后护理2>>记录时间", "术后护理2>>签名",
                                              "术后护理3>>天", "术后护理眼垫3>>清洁", "术后护理眼垫3>>干燥",
                                              "术后护理绷带3>>清洁", "术后护理绷带3>>干燥", "术后护理绷带3>>其他", "术后护理伤口痛3>>无", "术后护理伤口痛3>>有",
                                              "术后护理伤头痛3>>无", "术后护理伤头痛3>>有","术后护理伤口痛3>>能忍受", "术后护理伤口痛3>>不能忍受",
                                              "术后护理恶心3>>无", "术后护理恶心3>>有", "术后护理呕吐3>>无", "术后护理呕吐3>>有","术后护理3>>记录时间", "术后护理3>>签名",
                                              "术后护理>>其他1","术后护理>>其他2","术后护理>>其他3",
                                              "术后2>>饮食>>普食", "术后2>>饮食>>低盐饮食", "术后2>>饮食>>低脂饮食", "术后2>>饮食>>低胆固醇饮食", "术后2>>饮食>>糖尿病饮食","术后2>>饮食>>其他",
                                              "术后1>>饮食>>普食", "术后1>>饮食>>低盐饮食", "术后1>>饮食>>低脂饮食", "术后1>>饮食>>低胆固醇饮食", "术后1>>饮食>>糖尿病饮食","术后1>>饮食>>其他",
                                              "术后3>>饮食>>普食", "术后3>>饮食>>低盐饮食", "术后3>>饮食>>低脂饮食", "术后3>>饮食>>低胆固醇饮食", "术后3>>饮食>>糖尿病饮食","术后3>>饮食>>其他"};
            public clsPrint8()
            {
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("术后护理1>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术后护理1>>记录时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术后护理2>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术后护理2>>记录时间"];
                    strBeforeOperatorTime2 = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("术后护理3>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["术后护理3>>记录时间"];
                    strBeforeOperatorTime3 = objItem.m_strItemContent;
                }
                m_strKeysArr104 = new string[]{ "\n术后第", "#天：$$" };
                m_strKeysArr104a = new string[] { "\n术后第", "#天：$$" };
                m_strKeysArr104b = new string[] { "\n术后第", "#天：$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("术后护理记录", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                  
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr02))
                            m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04))
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05))
                            m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06))
                            m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07))
                            m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr38))
                        {
                            m_mthMakeCheckText(m_strKeysArr138, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr39))
                                m_mthMakeText(m_strKeysArr139, m_strKeysArr39, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr39))
                            m_mthMakeText(m_strKeysArr239, m_strKeysArr39, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08))
                            m_mthMakeCheckText(m_strKeysArr108, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09))
                            m_mthMakeCheckText(m_strKeysArr109, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr10))
                            m_mthMakeCheckText(m_strKeysArr101, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr081))
                            m_mthMakeCheckText(m_strKeysArr1081, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr091))
                            m_mthMakeCheckText(m_strKeysArr1091, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09k))
                            m_mthMakeText(m_strKeysArr109k, m_strKeysArr09k, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr092))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime, "    签名：$$" }, m_strKeysArr092, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04a))
                            m_mthMakeText(m_strKeysArr104a, m_strKeysArr04a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05a))
                            m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06a))
                            m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07a))
                            m_mthMakeText(m_strKeysArr107a, m_strKeysArr07a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr48))
                        {
                            m_mthMakeCheckText(m_strKeysArr148, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr49))
                                m_mthMakeText(m_strKeysArr149, m_strKeysArr49, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr49))
                            m_mthMakeText(m_strKeysArr249, m_strKeysArr49, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08a))
                            m_mthMakeCheckText(m_strKeysArr108a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09a))
                            m_mthMakeCheckText(m_strKeysArr109a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr20))
                            m_mthMakeCheckText(m_strKeysArr201, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr081a))
                            m_mthMakeCheckText(m_strKeysArr1081a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr091a))
                            m_mthMakeCheckText(m_strKeysArr1091a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09m))
                            m_mthMakeText(m_strKeysArr109m, m_strKeysArr09m, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(new string[] { "术后护理2>>签名" }))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime2, "    签名：$$" }, m_strKeysArr092a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04b))
                            m_mthMakeText(m_strKeysArr104b, m_strKeysArr04b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05b))
                            m_mthMakeCheckText(m_strKeysArr105b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06b))
                        m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07b))
                            m_mthMakeText(m_strKeysArr107b, m_strKeysArr07b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr58))
                        {
                            m_mthMakeCheckText(m_strKeysArr158, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr59))
                                m_mthMakeText(m_strKeysArr159, m_strKeysArr59, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr59))
                            m_mthMakeText(m_strKeysArr259, m_strKeysArr59, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08b))
                            m_mthMakeCheckText(m_strKeysArr108b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09b))
                            m_mthMakeCheckText(m_strKeysArr109b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr30))
                            m_mthMakeCheckText(m_strKeysArr301, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr081b))
                            m_mthMakeCheckText(m_strKeysArr1081b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr091b))
                            m_mthMakeCheckText(m_strKeysArr1091b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09n))
                            m_mthMakeText(m_strKeysArr109n, m_strKeysArr09n, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(new string[] { "术后护理3>>签名" }))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime3, "    签名：$$" }, m_strKeysArr092b, ref strAllText, ref strXml);
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
        #region 出院记录
        /// <summary>
        /// 
        /// </summary>
        private class clsPrint9 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strBeforeOperatorTime = "";
            private string strBeforeOperatorTime2 = "";
            private string strOutHospitalStatus = "";
            private string[] m_strKeysArr06 = { "出院记录>>饮食>>普食", "出院记录>>饮食>>低盐饮食", "出院记录>>饮食>>低脂饮食", "出院记录>>饮食>>低胆固醇饮食", "出院记录>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr106 = { "\n饮食：", "出院记录>>饮食>>普食", "出院记录>>饮食>>低盐饮食", "出院记录>>饮食>>低脂饮食", "出院记录>>饮食>>低胆固醇饮食", "出院记录>>饮食>>糖尿病饮食" };
            private string[] m_strKeysArr206 = { "\n饮食：" };
            private string[] m_strKeysArr105 = { "其他：" };
            private string[] m_strKeysArr05 = { "出院记录>>饮食>>其他" };
            private string[] m_strKeysArr01 = { "出院记录>>记录时间", "出院记录>>签名" };
            private string[] m_strKeysArr03 = { "", "出院记录>>月", "", "出院记录>>日", "" };
            private string[] m_strKeysArr103;
            private string[] m_strKeysArr07 = { "出院记录>>诊断"}; 
            private string[] m_strKeysArr107;
            private string[] m_strKeysArr09 = { "","出院记录>>视力>>右眼", "出院记录>>视力>>左眼" };
            private string[] m_strKeysArr109;
            private string[] m_strKeysArr08 = { "", "出院记录>>眼压>>右眼", "出院记录>>眼压>>右眼", "出院记录>>眼压>>左眼", "出院记录>>眼压>>左眼" };
            private string[] m_strKeysArr108;
            private string[] m_strKeysArr = { "出院记录>>月", "出院记录>>日", "出院记录>>治愈", "出院记录>>好转", "出院记录>>因故",
                                              "出院记录>>诊断", "出院记录>>视力>>右眼", "出院记录>>视力>>左眼", "出院记录>>眼压>>右眼", "出院记录>>眼压>>左眼",
                                              "出院记录>>记录时间", "出院记录>>签名"   };
            public clsPrint9()
            {
                
                
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!m_blnHavePrintInfo(m_strKeysArr))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_hasItems.Contains("出院记录>>记录时间"))
                {
                    clsInpatMedRec_Item objItem = (clsInpatMedRec_Item)m_hasItems["出院记录>>记录时间"];
                    strBeforeOperatorTime = objItem.m_strItemContent;
                }
                if (m_hasItems.Contains("出院记录>>治愈"))
                {
                    strOutHospitalStatus = "治愈";
                }
                else if (m_hasItems.Contains("出院记录>>好转"))
                {
                    strOutHospitalStatus = "好转";
                }
                if (m_hasItems.Contains("出院记录>>因故"))
                {
                    strOutHospitalStatus = "因故";
                }
                m_strKeysArr103 = new string[] { "\n患者定于", "$$", "月$$", "$$", "日" + strOutHospitalStatus + "出院。$$" };
                m_strKeysArr108 = new string[] { "     眼压：", "右眼：$$", "#mmHg$$", " 左眼：$$", "#mmHg$$" };
                m_strKeysArr109 = new string[] { "\n视力：$$", "右眼：$$", "左眼：" };
                m_strKeysArr107 = new string[] { "\n诊断：$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("出院记录", new Font("", 10, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                 
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                        m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(new string[] { "出院记录>>视力>>右眼", "出院记录>>视力>>左眼" }))
                            m_mthMakeText(m_strKeysArr109, m_strKeysArr09, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(new string[] { "出院记录>>眼压>>右眼", "出院记录>>眼压>>左眼" }))
                            m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06))
                        {
                            m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                            if (m_blnHavePrintInfo(m_strKeysArr05))
                                m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        }
                        else if (m_blnHavePrintInfo(m_strKeysArr05))
                            m_mthMakeText(m_strKeysArr206, m_strKeysArr05, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01))
                            m_mthMakeText(new string[] { "#\n                                                  记录时间：" + strBeforeOperatorTime, "              签名：$$" }, m_strKeysArr01, ref strAllText, ref strXml);
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
 
    }
}
