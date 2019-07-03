using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using iCareData;
using com.digitalwave.controls;


namespace iCare
{
    /// <summary>
    /// 眼科住院病历打印工具,佛二用
    /// </summary>
    class clsIMR_OphthalmologyPrintTool_F2 : clsInpatMedRecPrintBase
    {
        public clsIMR_OphthalmologyPrintTool_F2(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: Add constructor logic here
            //
        }
        clsPrintInPatMedRecOphthalmologyCheck[] objPrintArr;
        clsPrintInPatMedRecMedical[] m_objPrintInPatMedArr;

        protected override void m_mthSetPrintLineArr()
        {
            m_mthSetThisPrintInfo();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("眼科住院病历",310),
										  new clsPrintInPatMedRecMain(),
										  new clsPrintInPatMedRecCaseCurrent(),
										  new clsPrintInPatMedRecBeforetimeStatusForEye(),
										  new clsPrintInPatMedRecBeforetimeStatus(),
										  new clsPrintInPatMedRecIndividual(),
										  new clsPrintInPatMedRecFamily(),
										  new clsPrintInPatMedRecOther(),
                                          new clsPrintInPatMedRecMedicalTitle(),
                                          m_objPrintInPatMedArr[0], m_objPrintInPatMedArr[1], m_objPrintInPatMedArr[2], m_objPrintInPatMedArr[3],
                                          m_objPrintInPatMedArr[4], m_objPrintInPatMedArr[5], m_objPrintInPatMedArr[6], m_objPrintInPatMedArr[7],m_objPrintInPatMedArr[8],
                                          new clsPrintInPatMedRecCheckTitle(),
										  objPrintArr[0],objPrintArr[1],objPrintArr[2],objPrintArr[3],objPrintArr[4],objPrintArr[5],objPrintArr[6],
										  objPrintArr[7],objPrintArr[8],objPrintArr[9],objPrintArr[10],objPrintArr[11],objPrintArr[12],objPrintArr[13],
										  new clsPrintInPatientTherapyPlan(),
                    new clsPrintInPatMedRecDia2(),
                    new clsPrintInPatMedRecDia3(),
                    new clsPrintInPatMedRecDia4()   
									  });
        }

        private void m_mthSetThisPrintInfo()
        {
            objPrintArr = new clsPrintInPatMedRecOphthalmologyCheck[14];
            for (int i = 0; i < objPrintArr.Length; i++)
                objPrintArr[i] = new clsPrintInPatMedRecOphthalmologyCheck();
            objPrintArr[0].m_mthSetPrintValue(new string[] { "眼部检查>>视力>>右>>矫正前", "眼部检查>>视力>>右>>矫正后" }, new string[] { "眼部检查>>视力>>左>>矫正前", "眼部检查>>视力>>左>>矫正后" }, "视力", null);
            objPrintArr[1].m_mthSetPrintValue(new string[] { "眼部检查>>眼压>>右" }, new string[] { "眼部检查>>眼压>>左" }, "眼压", null);
            objPrintArr[2].m_mthSetPrintValue(new string[] { "眼部检查>>眼睑>>右" }, new string[] { "眼部检查>>眼睑>>左" }, "眼睑", null);
            objPrintArr[3].m_mthSetPrintValue(new string[] { "眼部检查>>泪器>>右" }, new string[] { "眼部检查>>泪器>>左" }, "泪器", null);
            objPrintArr[4].m_mthSetPrintValue(new string[] { "眼部检查>>结膜>>右" }, new string[] { "眼部检查>>结膜>>左" }, "结膜", null);
            objPrintArr[5].m_mthSetPrintValue(new string[] { "眼部检查>>巩膜>>右" }, new string[] { "眼部检查>>巩膜>>左" }, "巩膜", null);
            objPrintArr[6].m_mthSetPrintValue(new string[] { "眼部检查>>角膜>>右" }, new string[] { "眼部检查>>角膜>>左" }, "角膜", null);
            objPrintArr[7].m_mthSetPrintValue(new string[] { "眼部检查>>前房>>右" }, new string[] { "眼部检查>>前房>>左" }, "前房", null);
            objPrintArr[8].m_mthSetPrintValue(new string[] { "眼部检查>>虹膜>>右" }, new string[] { "眼部检查>>虹膜>>左" }, "虹膜", null);
            objPrintArr[9].m_mthSetPrintValue(new string[] { "眼部检查>>瞳孔>>右" }, new string[] { "眼部检查>>瞳孔>>左" }, "瞳孔", null);
            objPrintArr[10].m_mthSetPrintValue(new string[] { "眼部检查>>晶状体>>右" }, new string[] { "眼部检查>>晶状体>>左" }, "晶状体", null);
            objPrintArr[11].m_mthSetPrintValue(new string[] { "眼部检查>>玻璃体>>右" }, new string[] { "眼部检查>>玻璃体>>左" }, "玻璃体", null);
            objPrintArr[12].m_mthSetPrintValue(new string[] { "眼部检查>>眼底>>右" }, new string[] { "眼部检查>>眼底>>左" }, "眼底", null);
            objPrintArr[13].m_mthSetPrintValue(new string[] { "眼部检查>>其他>>右" }, new string[] { "眼部检查>>其他>>左" }, "其他", null);

            m_objPrintInPatMedArr = new clsPrintInPatMedRecMedical[9];
            for (int i = 0; i < m_objPrintInPatMedArr.Length; i++)
                m_objPrintInPatMedArr[i] = new clsPrintInPatMedRecMedical();

            m_objPrintInPatMedArr[0].m_mthSetPrintValue(new string[] { "体格检查>>血压>>舒张压", "体格检查>>血压>>收缩压" }, new string[] { "体格检查>>体温" }, new string[] { @"血压：", @"体温：" });
            m_objPrintInPatMedArr[1].m_mthSetPrintValue(new string[] { "体格检查>>呼吸" }, new string[] { "体格检查>>脉搏" }, new string[] { @"呼吸：", @"脉搏：" });
            m_objPrintInPatMedArr[2].m_mthSetPrintValue(new string[] { "体格检查>>皮肤" }, new string[] { "体格检查>>营养发育" }, new string[] { @"皮肤：", @"营养发育：" });
            m_objPrintInPatMedArr[3].m_mthSetPrintValue(new string[] { "体格检查>>头、面、颈部" }, new string[] { "体格检查>>淋巴结" }, new string[] { @"头、面、颈部：", @"淋巴结：" });
            m_objPrintInPatMedArr[4].m_mthSetPrintValue(new string[] { "体格检查>>肺脏" }, new string[] { "体格检查>>口腔" }, new string[] { @"肺脏：", @"口腔：" });
            m_objPrintInPatMedArr[5].m_mthSetPrintValue(new string[] { "体格检查>>心脏" }, new string[] { "体格检查>>脾脏" }, new string[] { @"心脏：", @"脾脏：" });
            m_objPrintInPatMedArr[6].m_mthSetPrintValue(new string[] { "体格检查>>肝脏" }, new string[] { "体格检查>>腹部" }, new string[] { @"肝脏：", @"腹部：" });
            m_objPrintInPatMedArr[7].m_mthSetPrintValue(new string[] { "体格检查>>生理神经反射" }, new string[] { "体格检查>>病理神经反射" }, new string[] { @"生理神经反射：", @"病理神经反射：" });
            m_objPrintInPatMedArr[8].m_mthSetPrintValue(new string[] { "体格检查>>其他" }, null, new string[] { @"其他：" });
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

            private clsInpatMedRec_Item objItemContent = null;
            private clsInpatMedRec_Item[] objItemContentArr = null;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                m_mthPrintPregnantAndBirth(ref p_intPosY, p_objGrp, p_fntNormalText);
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
                    p_intPosY += 20;

                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
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
        private class clsPrintInPatMedRecCaseCurrent : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
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
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                        m_mthAddSign2("现病史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })));
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
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
        /// 过去眼病史
        /// </summary>
        private class clsPrintInPatMedRecBeforetimeStatusForEye : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("过去眼病史"))
                        objItemContent = m_hasItems["过去眼病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("过去眼病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("过去眼病史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
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
        private class clsPrintInPatMedRecBeforetimeStatus : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("过去史"))
                        objItemContent = m_hasItems["过去史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("过去史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                        m_mthAddSign2("过去史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })));
                    m_blnIsFirstPrint = false;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
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
        private class clsPrintInPatMedRecIndividual : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("个人史"))
                        objItemContent = m_hasItems["个人史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("个人史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("个人史：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
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

        #region 婚姻生育史不用
        ///// <summary>
        ///// 婚姻生育史
        ///// </summary>
        //private class clsPrintInPatMedRecMarry : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private int m_intTimes = 0;
        //    private clsInpatMedRec_Item objItemContent = null;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_hasItems != null)
        //            if (m_hasItems.Contains("婚姻生育史"))
        //                objItemContent = m_hasItems["婚姻生育史"] as clsInpatMedRec_Item;
        //        if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
        //            p_objGrp.DrawString("婚姻生育史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_intPosY += 20;
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
        //            m_mthAddSign2("婚姻生育史：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
        //            p_intPosY += 20;
        //            m_intTimes++;
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
        //        m_blnIsFirstPrint = true;
        //        m_blnHaveMoreLine = true;
        //        m_intTimes = 0;
        //    }
        //}
        #endregion

        /// <summary>
        /// 家族史
        /// </summary>
        private class clsPrintInPatMedRecFamily : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("家族史"))
                        objItemContent = m_hasItems["家族史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("家族史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                        m_mthAddSign2("家族史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })));
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
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
        /// 其他
        /// </summary>
        private class clsPrintInPatMedRecOther : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("其他"))
                        objItemContent = m_hasItems["其他"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                    p_objGrp.DrawString("其他：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent != null);
                        m_mthAddSign2("其他：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent == null ? "" : "　　" + objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new string[] { strSpaceXml, objItemContent.m_strItemContentXml })));
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
                    m_blnHaveMoreLine = false;
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
        /// 体格检查标题
        /// </summary>
        private class clsPrintInPatMedRecMedicalTitle : clsIMR_PrintLineBase
        {
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                p_objGrp.DrawString("体 格 检 查", clsIMR_OphthalmologyPrintTool.m_fotItemHead, Brushes.Black, (int)enmRectangleInfo.LeftX + 310, p_intPosY);
                p_intPosY += 30;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 体格检查
        /// </summary>
        private class clsPrintInPatMedRecMedical : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            //private string m_strTitle = "";
            private string[] m_strTitleArr = null;
            private clsInpatMedRec_Item[] m_objItemContentLArr = null;
            private clsInpatMedRec_Item[] m_objItemContentRArr = null;

            /// <summary>
            /// 左竖线X轴
            /// </summary>
            private const int c_intShortLeft = 180;
            /// <summary>
            /// 右竖线X轴
            /// </summary>
            private const int c_intShortRight = 500;
            /// <summary>
            /// 打印内容宽度
            /// </summary>
            private const int c_intWidth = 210;

            int m_intPosY;

            public clsPrintInPatMedRecMedical()
            { }

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            //private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                Rectangle rtgDianoseR = new Rectangle(c_intShortRight, p_intPosY + 2, c_intWidth, 13);
                Rectangle rtgDianoseL = new Rectangle(c_intShortLeft, p_intPosY + 2, c_intWidth, 13);

                StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
                Font fntTitle = new Font("SimSun", 12);

                int intRealHeight = 0;
                int intTempHeight = 20;
                m_intPosY = p_intPosY;
                string str = "<root />";
                if (m_strTitleArr != null && m_strTitleArr.Length == 2)
                {
                    //
                    // 打印左边
                    //
                    p_objGrp.DrawString(m_strTitleArr[0], fntTitle, Brushes.Black, m_intRecBaseX + 10, m_intPosY);
                    if (m_objItemContentLArr != null)
                    {
                        if (m_strTitleArr[0] == "血压：")
                        {
                            string strPrint = (m_objItemContentLArr[0] == null ? "" : (m_objItemContentLArr[0].m_strItemContent == null ? "" : m_objItemContentLArr[0].m_strItemContent));
                            if (m_objItemContentLArr[1] != null && m_objItemContentLArr[1].m_strItemContent != null && m_objItemContentLArr[1].m_strItemContent != "")
                            {
                                strPrint += @"/" + (m_objItemContentLArr[1] == null ? "" : (m_objItemContentLArr[1].m_strItemContent == null ? "" : m_objItemContentLArr[1].m_strItemContent)) + @"(mm/Hg)";
                            }
                            m_objDiagnoseL.m_mthSetContextWithCorrectBefore(strPrint, str, m_dtmFirstPrintTime, true);

                        }
                        else if (m_strTitleArr[0] == "呼吸：")
                        {
                            string strPrint = (m_objItemContentLArr[0] == null ? "" : (m_objItemContentLArr[0].m_strItemContent == null ? "" : m_objItemContentLArr[0].m_strItemContent));
                            strPrint += @"(次/分)";
                            m_objDiagnoseL.m_mthSetContextWithCorrectBefore(strPrint, str, m_dtmFirstPrintTime, true);

                        }
                        else
                        {
                            m_mthSetPrintInfo(m_objDiagnoseL, m_objItemContentLArr[0]);
                            //m_objDiagnoseL.m_mthSetContextWithCorrectBefore((m_objItemContentLArr[0] == null ? "" : m_objItemContentLArr[0].m_strItemContent), (m_objItemContentLArr[0] == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { "<root />", m_objItemContentLArr[0].m_strItemContentXml })), m_dtmFirstPrintTime, m_objItemContentLArr[0] != null);
                        }
                    }
                    //
                    // 打印右边
                    //
                    p_objGrp.DrawString(m_strTitleArr[1], fntTitle, Brushes.Black, c_intShortRight - 120, m_intPosY);
                    if (m_objItemContentRArr != null)
                    {
                        if (m_strTitleArr[1] == "体温：")
                        {
                            string strPrint = (m_objItemContentRArr[0] == null ? "" : (m_objItemContentRArr[0].m_strItemContent == null ? "" : m_objItemContentRArr[0].m_strItemContent));
                            strPrint += @"(℃)";
                            m_objDiagnoseR.m_mthSetContextWithCorrectBefore(strPrint, str, m_dtmFirstPrintTime, true);
                        }
                        else if (m_strTitleArr[1] == "脉搏：")
                        {
                            string strPrint = (m_objItemContentRArr[0] == null ? "" : (m_objItemContentRArr[0].m_strItemContent == null ? "" : m_objItemContentRArr[0].m_strItemContent));
                            strPrint += @"(次/分)";
                            m_objDiagnoseR.m_mthSetContextWithCorrectBefore(strPrint, str, m_dtmFirstPrintTime, true);
                        }
                        else
                        {
                            m_mthSetPrintInfo(m_objDiagnoseR, m_objItemContentRArr[0]);
                            //m_objDiagnoseR.m_mthSetContextWithCorrectBefore((m_objItemContentLArr[1] == null ? "" : m_objItemContentLArr[1].m_strItemContent), (m_objItemContentLArr[1] == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { "<root />", m_objItemContentLArr[1].m_strItemContentXml })), m_dtmFirstPrintTime, m_objItemContentLArr[1] != null);
                        }
                    }

                    m_objDiagnoseL.m_blnPrintAllBySimSun(11, rtgDianoseL, p_objGrp, out intRealHeight, false);
                    intTempHeight = Math.Max(intTempHeight, intRealHeight);
                    m_objDiagnoseR.m_blnPrintAllBySimSun(11, rtgDianoseR, p_objGrp, out intRealHeight, false);
                    int intHeight = Math.Max(intTempHeight, intRealHeight);
                    p_intPosY += intHeight + 8;
                }
                else if(m_strTitleArr != null && m_strTitleArr.Length == 1)
                {
                    p_objGrp.DrawString(m_strTitleArr[0], fntTitle, Brushes.Black, m_intRecBaseX + 10, m_intPosY);
                    if (m_objItemContentLArr != null)
                    {
                        string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
                        //m_objPrintContext.m_mthRestartPrint();
                        //m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContentLArr[0] == null ? "" : m_objItemContentLArr[0].m_strItemContent), (m_objItemContentLArr[0] == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, m_objItemContentLArr[0].m_strItemContentXml })), m_dtmFirstPrintTime, m_objItemContentLArr[0] != null);
                        m_mthSetPrintInfo(m_objPrintContext, m_objItemContentLArr[0]);
                    }
                    Rectangle rtgOther = new Rectangle(c_intShortLeft, p_intPosY + 2, 2*c_intWidth, 13);
                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgOther, p_objGrp, out intRealHeight, false);
                    intTempHeight = Math.Max(intTempHeight, intRealHeight);
                    p_intPosY += intTempHeight + 8;

                    p_intPosY = p_intPosY + 500;
                }

                
               
                //
                // 释放资源
                //
                fntTitle.Dispose();
                stfTitle.Dispose();

                m_blnHaveMoreLine = false; 
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objDiagnoseR.m_mthRestartPrint();
                m_objDiagnoseL.m_mthRestartPrint();
            }

            public void m_mthSetPrintValue(string[] p_strKeyForLArr, string[] p_strKeyForRArr, string[] p_strTitleArr)
            {
                m_objItemContentLArr = m_objGetContentFromItemArr(p_strKeyForLArr);
                m_objItemContentRArr = m_objGetContentFromItemArr(p_strKeyForRArr);
                m_strTitleArr = p_strTitleArr;
            }

            private void m_mthSetPrintInfo(clsPrintRichTextContext p_objDiagnose, clsInpatMedRec_Item p_objItem)
            {
                p_objDiagnose.m_mthRestartPrint();
                if (m_blnIsPrintMark)
                {
                    p_objDiagnose.m_mthSetContextWithCorrectBefore((p_objItem == null ? "" : (p_objItem.m_strItemContent == null ? "" : p_objItem.m_strItemContent))
                        , (p_objItem == null ? "<root />" : (p_objItem.m_strItemContentXml == null ? "<root />" : p_objItem.m_strItemContentXml)), m_dtmFirstPrintTime, p_objItem == null);
                }
                else
                {
                    p_objDiagnose.m_mthSetContextWithAllCorrect((p_objItem == null ? "" : (p_objItem.m_strItemContent == null ? "" : p_objItem.m_strItemContent))
                                            , (p_objItem == null ? "<root />" : (p_objItem.m_strItemContentXml == null ? "<root />" : p_objItem.m_strItemContentXml)));
                }
            }
        }

        /// <summary>
        /// 眼部检查标题
        /// </summary>
        private class clsPrintInPatMedRecCheckTitle : clsIMR_PrintLineBase
        {
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("眼  部  检  查", clsIMR_OphthalmologyPrintTool.m_fotItemHead, Brushes.Black, (int)enmRectangleInfo.LeftX + 310, p_intPosY);
                p_intPosY += 30;
                p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX - 10, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);

                p_objGrp.DrawString("右                                 左", p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX + 300, p_intPosY + 3);
                p_intPosY += 30;
                p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX - 10, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 眼科检查
        /// </summary>
        private class clsPrintInPatMedRecOphthalmologyCheck : clsIMR_PrintLineBase
        {
            #region Define

            private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private string m_strTitle = "";
            private string[] m_strTitleArr = null;
            private clsInpatMedRec_Item[] m_objItemContentLArr = null;
            private clsInpatMedRec_Item[] m_objItemContentRArr = null;
            private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 格子高度
            /// </summary>
            private const int c_intHeight = 40;
            /// <summary>
            /// 左竖线X轴
            /// </summary>
            private const int c_intShortLeft = 140;
            /// <summary>
            /// 右竖线X轴
            /// </summary>
            private const int c_intShortRight = 463;
            /// <summary>
            /// 打印内容格子宽度
            /// </summary>
            private const int c_intWidth = 323;
            /// <summary>
            /// 打印小标题宽度
            /// </summary>
            private const int c_intTitleWidth = 80;
            private int m_intLongLineTop = 150;
            /// <summary>
            /// 打印横线的X坐标
            /// </summary>
            private int m_intLeftX = (int)enmRectangleInfo.LeftX - 10;

            /// <summary>
            /// 判断是否换页
            /// </summary>
            private bool m_blnIsChangePage = false;

            private int m_intIndex = 0;
            int m_intPosY;

            #endregion

            public clsPrintInPatMedRecOphthalmologyCheck()
            {
                m_blnIsChangePage = false;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY == m_intLongLineTop + 5)
                {
                    m_mthPrintLine(ref p_intPosY, p_objGrp, p_fntNormalText);
                }
                Rectangle rtgTitle = new Rectangle(m_intLeftX, p_intPosY + 5, c_intTitleWidth, c_intHeight);
                Rectangle rtgTitle2 = new Rectangle(m_intLeftX, p_intPosY + 5, 20, c_intHeight);
                Rectangle rtgTitle3 = new Rectangle(m_intLeftX + 30, p_intPosY + 5, 60, c_intHeight);
                Rectangle rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth, 10);
                Rectangle rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth, 10);

                StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
                Font fntTitle = new Font("SimSun", 12);

                int intRealHeight = 0;
                int intTempHeight = 0;
                m_intPosY = p_intPosY;
                

                if (m_blnIsChangePage)
                {
                    p_intPosY -= 18;
                    p_objGrp.DrawString("右                                 左", p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX + 270, p_intPosY);
                    p_intPosY += 18;
                    p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY + 2, (int)enmRectangleInfo.RightX, p_intPosY + 2);
                    m_blnIsChangePage = false;
                }
                //********************
                if (m_strTitleArr == null)
                {
                    if (p_intPosY + 40 > ((int)enmRectangleInfo.BottomY - 85))
                    {
                        m_blnHaveMoreLine = true;
                        m_blnIsChangePage = true;
                        p_intPosY += 500;
                        return;
                    }

                    

                    if (m_strTitle == "晶状体")
                    {
                        System.Resources.ResourceManager rm = new ResourceManager("HRPControl.Resources.Image", new com.digitalwave.Utility.Controls.ctlPaintContainer().GetType().Assembly);
                        rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 100, 100);
                        rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 100, 100);

                        Image imgPrintR = null;
                        Image imgPrintL = null;
                        if (m_objPrintInfo.m_objContent != null && m_objPrintInfo.m_objContent.m_objPics != null)
                        {
                            System.IO.MemoryStream objStream;
                            for (int index = 0; index < m_objPrintInfo.m_objContent.m_objPics.Length; index++)
                            {
                                if (m_objPrintInfo.m_objContent.m_objPics[index].m_StrPictureBoxName == "picEyeR")
                                {
                                    objStream = new MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[index].m_bytImage);
                                    imgPrintR = new Bitmap(objStream);
                                }
                                else if (m_objPrintInfo.m_objContent.m_objPics[index].m_StrPictureBoxName == "picEyeL")
                                {
                                    objStream = new MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[index].m_bytImage);
                                    imgPrintL = new Bitmap(objStream);
                                }
                            }
                        }
                        else
                        {
                            Image img = (Bitmap)rm.GetObject("晶状体");
                        }
                        if(imgPrintR != null)
                            p_objGrp.DrawImage(imgPrintR, c_intShortLeft + c_intWidth - 100, p_intPosY + 10, 100, 80);
                        if (imgPrintL != null)
                            p_objGrp.DrawImage(imgPrintL, c_intShortRight + c_intWidth - 100, p_intPosY + 10, 100, 80);
                    }
                    p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle, stfTitle);
                    string str = "<root />";
                    if (m_strTitle == "视力")
                    {
                        if (m_objItemContentRArr != null)
                        {
                            string strSign = (m_objItemContentRArr[0] == null ? "" : (m_objItemContentRArr[0].m_strItemContent == null ? "" : m_objItemContentRArr[0].m_strItemContent));
                            if (m_objItemContentRArr[1] != null && m_objItemContentRArr[1].m_strItemContent != null && m_objItemContentRArr[1].m_strItemContent != "")
                            {
                                strSign += "  矫正后 " + (m_objItemContentRArr[1] == null ? "" : (m_objItemContentRArr[1].m_strItemContent == null ? "" : m_objItemContentRArr[1].m_strItemContent));
                            }
                            if(m_blnIsPrintMark)
                                m_objDiagnoseR.m_mthSetContextWithCorrectBefore(strSign, str, m_dtmFirstPrintTime, true);
                            else
                                m_objDiagnoseR.m_mthSetContextWithAllCorrect(strSign, str);
                        }
                        if (m_objItemContentLArr != null)
                        {
                            string strSign2 = (m_objItemContentLArr[0] == null ? "" : (m_objItemContentLArr[0].m_strItemContent == null ? "" : m_objItemContentLArr[0].m_strItemContent));
                            if (m_objItemContentLArr[1] != null && m_objItemContentLArr[1].m_strItemContent != null && m_objItemContentLArr[1].m_strItemContent != "")
                            {
                                strSign2 += "  矫正后 " + (m_objItemContentLArr[1] == null ? "" : (m_objItemContentLArr[1].m_strItemContent == null ? "" : m_objItemContentLArr[1].m_strItemContent));
                            }
                            if (m_blnIsPrintMark)
                                m_objDiagnoseL.m_mthSetContextWithCorrectBefore(strSign2, str, m_dtmFirstPrintTime, true);
                            else
                                m_objDiagnoseL.m_mthSetContextWithAllCorrect(strSign2, str);

                        }
                    }

                    else
                        m_mthSetPrintInfo(m_objDiagnoseR, m_objDiagnoseL, (m_objItemContentRArr == null ? null : m_objItemContentRArr[0]), (m_objItemContentLArr == null ? null : m_objItemContentLArr[0]));
                    m_objDiagnoseR.m_blnPrintAllBySimSun(11, rtgDianoseR, p_objGrp, out intRealHeight, false);
                    intTempHeight = intRealHeight;
                    m_objDiagnoseL.m_blnPrintAllBySimSun(11, rtgDianoseL, p_objGrp, out intRealHeight, false);
                    int intHeight = Math.Max(intTempHeight, intRealHeight);
                    if (intHeight > Math.Max(c_intHeight, rtgDianoseR.Height))
                    {
                        p_intPosY += intHeight + 5;
                    }
                    else
                    {
                        p_intPosY += Math.Max(c_intHeight, rtgDianoseR.Height);
                    }
                    p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                }
                else
                {
                    if (m_blnIsFirstPrint == true)
                    {
                        //if (m_strTitle == "瞳孔")
                        //{
                        //    rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 72, 0);
                        //    rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 72, 0);
                        //    Image img = (Bitmap)rm.GetObject("瞳孔");
                        //    p_objGrp.DrawImage(img, c_intShortLeft + c_intWidth - 72, p_intPosY + 10, 72, 48);
                        //    p_objGrp.DrawImage(img, c_intShortRight + c_intWidth - 72, p_intPosY + 10, 72, 48);
                        //}
                        //if (m_strTitle == "眼底")
                        //{
                        //    rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 100, 0);
                        //    rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 100, 0);
                        //    Image imgR = (Bitmap)rm.GetObject("右视网膜");
                        //    Image imgL = (Bitmap)rm.GetObject("左视网膜");
                        //    p_objGrp.DrawImage(imgR, c_intShortLeft + c_intWidth - 100, p_intPosY + 10, 100, 100);
                        //    p_objGrp.DrawImage(imgL, c_intShortRight + c_intWidth - 100, p_intPosY + 10, 100, 100);
                        //}
                        m_blnIsFirstPrint = false;
                    }
                    for (int i = m_intIndex; i < m_strTitleArr.Length; i++)
                    {
                        if (p_intPosY + 40 > ((int)enmRectangleInfo.BottomY - 50))
                        {
                            m_blnHaveMoreLine = true;
                            m_intIndex = i;
                            p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle2, stfTitle);
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, m_intPosY, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortLeft, m_intPosY, c_intShortLeft, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortRight, m_intPosY, c_intShortRight, p_intPosY);
                            p_intPosY += 500;
                            return;
                        }
                        p_objGrp.DrawString(m_strTitleArr[i], fntTitle, Brushes.Black, rtgTitle3, stfTitle);

                        m_mthSetPrintInfo(m_objDiagnoseR, m_objDiagnoseL, (m_objItemContentRArr == null ? null : m_objItemContentRArr[i]), (m_objItemContentLArr == null ? null : m_objItemContentLArr[i]));
                        m_objDiagnoseR.m_blnPrintAllBySimSun(11, rtgDianoseR, p_objGrp, out intRealHeight, false);

                        intTempHeight = intRealHeight;
                        m_objDiagnoseL.m_blnPrintAllBySimSun(11, rtgDianoseL, p_objGrp, out intRealHeight, false);
                        int intHeight = Math.Max(intTempHeight, intRealHeight);
                        if (intHeight > Math.Max(c_intHeight, rtgDianoseR.Height))
                        {
                            p_intPosY += intHeight + 2;
                        }
                        else
                        {
                            p_intPosY += Math.Max(c_intHeight, rtgDianoseR.Height);
                        }
                        rtgDianoseR.Y = p_intPosY + 2;
                        rtgDianoseL.Y = p_intPosY + 2;
                        rtgTitle3.Y = p_intPosY + 3;

                        if (m_strTitle == "眼底" || m_strTitle == "瞳孔")
                        {
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY, (int)enmRectangleInfo.LeftX + c_intWidth - 100, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortRight, p_intPosY, c_intShortRight + c_intWidth - 100, p_intPosY);
                        }
                        else
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    }
                    rtgTitle2.Height = p_intPosY - m_intPosY;
                    p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, m_intPosY, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle2, stfTitle);
                }
                p_objGrp.DrawLine(Pens.Black, c_intShortLeft, m_intPosY, c_intShortLeft, p_intPosY);
                p_objGrp.DrawLine(Pens.Black, c_intShortRight, m_intPosY, c_intShortRight, p_intPosY);
                //********************
                fntTitle.Dispose();
                stfTitle.Dispose();

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objDiagnoseR.m_mthRestartPrint();
                m_objDiagnoseL.m_mthRestartPrint();
            }
            /// <summary>
            /// 打印顶部直线和标题
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            private void m_mthPrintLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("右                                 左", p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX + 270, p_intPosY + 3);
                p_intPosY += 30;
                p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
            }

            public void m_mthSetPrintValue(string[] p_strKeyForRArr, string[] p_strKeyForLArr, string p_strTitle, string[] p_strTitleArr)
            {
                m_objItemContentLArr = m_objGetContentFromItemArr(p_strKeyForLArr);
                m_objItemContentRArr = m_objGetContentFromItemArr(p_strKeyForRArr);
                m_strTitle = p_strTitle;
                m_strTitleArr = p_strTitleArr;
            }

            private void m_mthSetPrintInfo(clsPrintRichTextContext p_objDiagnoseR, clsPrintRichTextContext p_objDiagnoseL, clsInpatMedRec_Item p_objItemR, clsInpatMedRec_Item p_objItemL)
            {
                p_objDiagnoseR.m_mthRestartPrint();
                p_objDiagnoseL.m_mthRestartPrint();
                if (m_blnIsPrintMark)
                {
                    p_objDiagnoseR.m_mthSetContextWithCorrectBefore((p_objItemR == null ? "" : (p_objItemR.m_strItemContent == null ? "" : p_objItemR.m_strItemContent))
                        , (p_objItemR == null ? "<root />" : (p_objItemR.m_strItemContentXml == null ? "<root />" : p_objItemR.m_strItemContentXml)), m_dtmFirstPrintTime, p_objItemR == null);
                    p_objDiagnoseL.m_mthSetContextWithCorrectBefore((p_objItemL == null ? "" : (p_objItemL.m_strItemContent == null ? "" : p_objItemL.m_strItemContent))
                        , (p_objItemL == null ? "<root />" : (p_objItemL.m_strItemContentXml == null ? "<root />" : p_objItemL.m_strItemContentXml)), m_dtmFirstPrintTime, p_objItemL == null);

                    m_mthAddSign2(m_strTitle, m_objDiagnoseR.m_ObjModifyUserArr);
                }
                else
                {
                    p_objDiagnoseR.m_mthSetContextWithAllCorrect((p_objItemR == null ? "" : (p_objItemR.m_strItemContent == null ? "" : p_objItemR.m_strItemContent))
                        , (p_objItemR == null ? "<root />" : (p_objItemR.m_strItemContentXml == null ? "<root />" : p_objItemR.m_strItemContentXml)));
                    p_objDiagnoseL.m_mthSetContextWithAllCorrect((p_objItemL == null ? "" : (p_objItemL.m_strItemContent == null ? "" : p_objItemL.m_strItemContent))
                        , (p_objItemL == null ? "<root />" : (p_objItemL.m_strItemContentXml == null ? "<root />" : p_objItemL.m_strItemContentXml)));

                }
            }

        }
        /// <summary>
        /// 诊断 和 诊疗计划
        /// </summary>
        //private class clsPrintInPatientTherapyPlan : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
        //    private clsPrintRichTextContext m_objPrintContext2 = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private clsInpatMedRec_Item[] objItemContent;
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        objItemContent = m_objGetContentFromItemArr(new string[] { "诊断", "医师", "日期" });
        //        if (objItemContent == null || (objItemContent[0] == null && objItemContent[1] == null))
        //        {
        //            if (objItemContent != null)
        //            {
        //                p_intPosY += 30;
        //                p_objGrp.DrawString("医师：" + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 390, p_intPosY);
        //                p_objGrp.DrawString("日期：" + (objItemContent[2] == null ? "" : DateTime.Parse(objItemContent[2].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
        //            }
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            string strSpaceXml = ctlRichTextBox.clsXmlTool.s_strMakeTextXml("　　", m_objContent.m_strCreateUserID, new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName, Color.Black);
        //            p_intPosY += 20;
        //            if (objItemContent[0] != null)
        //                if (objItemContent[0].m_strItemContent != null)
        //                    p_objGrp.DrawString("入院诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            //if (objItemContent[1] != null)
        //            //    if (objItemContent[1].m_strItemContent != null)
        //            //        p_objGrp.DrawString("诊疗计划：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
        //            p_intPosY += 20;
        //            if (objItemContent[0] != null)
        //                if (objItemContent[0].m_strItemContent != null)
        //                {
        //                    m_objPrintContext1.m_mthSetContextWithCorrectBefore("　　" + objItemContent[0].m_strItemContent, (objItemContent[0] == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent[0].m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent[0] != null);
        //                    m_mthAddSign2("入院诊断：", m_objPrintContext1.m_ObjModifyUserArr);
        //                }
        //            //if (objItemContent[1] != null)
        //            //    if (objItemContent[1].m_strItemContent != null)
        //            //    {
        //            //        m_objPrintContext2.m_mthSetContextWithCorrectBefore("　　" + objItemContent[1].m_strItemContent, (objItemContent[1] == null ? "<root />" : ctlRichTextBox.s_strCombineXml(new String[] { strSpaceXml, objItemContent[1].m_strItemContentXml })), m_dtmFirstPrintTime, objItemContent[1] != null);
        //            //        m_mthAddSign2("诊疗计划：", m_objPrintContext2.m_ObjModifyUserArr);
        //            //    }
        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
        //        {
        //            if (objItemContent[0] != null)
        //                if (objItemContent[0].m_strItemContent != null)
        //                    m_objPrintContext1.m_mthPrintLine(345, m_intRecBaseX + 50, p_intPosY, p_objGrp);
        //            //if (objItemContent[1] != null)
        //            //    if (objItemContent[1].m_strItemContent != null)
        //            //        m_objPrintContext2.m_mthPrintLine(330, m_intRecBaseX + 405, p_intPosY, p_objGrp);
        //            p_intPosY += 20;
        //            intLine++;
        //        }

        //        if (m_objPrintContext1.m_BlnHaveNextLine() || m_objPrintContext2.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            p_intPosY += 20;
        //            p_objGrp.DrawString("医师：" + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
        //            p_objGrp.DrawString("日期：" + (objItemContent[2] == null ? "" : DateTime.Parse(objItemContent[2].m_strItemContent).ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, p_intPosY);
        //            p_intPosY += 20;
        //            m_blnHaveMoreLine = false;
        //        }
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext1.m_mthRestartPrint();
        //        m_objPrintContext2.m_mthRestartPrint();
        //        m_blnHaveMoreLine = true;
        //        m_blnIsFirstPrint = true;
        //    }
        //}
        private class clsPrintInPatientTherapyPlan : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_intPosY += 5;

                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("诊断"))
                        objItemContent1 = m_hasItems["诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("医师"))
                        objItemContent2 = m_hasItems["医师"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("日期"))
                        objItemContent3 = m_hasItems["日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("入院诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                        m_mthAddSign2("入院诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml));
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
        /// 修正诊断
        /// </summary>
        private class clsPrintInPatMedRecDia2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

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
                    p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                        m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml));
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
                    p_objGrp.DrawString("补充诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                        m_mthAddSign2("补充诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml));
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
                    p_objGrp.DrawString("最后诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    if (m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                        m_mthAddSign2("最后诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                        m_objPrintContext.m_mthSetContextWithAllCorrect((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml));
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

