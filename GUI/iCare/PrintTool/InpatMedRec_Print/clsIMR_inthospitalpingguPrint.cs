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
    class clsIMR_inthospitalpingguPrint:clsInpatMedRecPrintBase
    {
        public clsIMR_inthospitalpingguPrint(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("入院评估表",320),
                                                                           new clsPrint2(),
                                                                           new clsPrint3(),
                                                                           new clsPrint4(),
                                                                           new clsPrint5(),
                                                                           new clsPrint6(),
                                                                        //   new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                        //   new clsPrint9(),
                                                                       //    new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                      //   new clsPrint14(),
                                                                       
                                                                      //   new clsPrint16(),
                                                                      // new clsPrint17(),
                                                                           new clsPrint15(),
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
                //  p_objGrp.DrawString("皮肤科住院病历", m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 10);

                // p_intPosY += 20;
                p_objGrp.DrawString("XHTCM/RD-311", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 140);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
               // p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
 p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
              
               
               // p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //p_intPosY += 20;
               // p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
              //  p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
              //  p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }

              //  m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);
                //p_intPosY += 20;
                //p_objGrp.DrawString("病史记录者：" + (m_objContent == null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 30;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        #endregion
        #region 打印医保号和发病气节
        /// <summary>
        /// 打印电话 邮编  民族
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = { "", "婚>>未婚", "婚>>已婚", "婚>>丧偶" };
            private string[] m_strKeysArr101 = { "婚姻状况：", "婚>>未婚", "婚>>已婚", "婚>>丧偶" };
            private string[] m_strKeysArr02 = { "", "宗教>>无", "宗教>>有" };
            private string[] m_strKeysArr102 = { "宗教信仰：", "宗教>>无", "宗教>>有" };
            private string[] m_strKeysArr03 = { "宗教信仰" };
            private string[] m_strKeysArr103 = { "" };
            private string[] m_strKeysArr04 = { "", "过敏史>>无", "过敏史>>有" };
            private string[] m_strKeysArr104 = { "过敏史：", "过敏史>>无", "过敏史>>有" };
            private string[] m_strKeysArr05 = { "过敏史" };
            private string[] m_strKeysArr105 = { "" };
     
            private string[] m_strKeysArr06 = { "", "入院>>步行", "入院>>扶行", "入院>>轮椅", "入院>>平车", "入院>>担架", "入院>>背人" };
            private string[] m_strKeysArr106 = { "\n入院方式：", "入院>>步行", "入院>>扶行", "入院>>轮椅", "入院>>平车", "入院>>担架", "入院>>背人" };
            private string[] m_strKeysArr06a = { "入院方式" };
            private string[] m_strKeysArr106a = { "其他：" };
            private string[] m_strKeysArr06b = { "发病气节", "入院中医", "入院西医" };
            private string[] m_strKeysArr106b = { "\n发病气节：" ,"\n入院诊断：中医：","西医："};
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
                        m_mthMakeCheckText(m_strKeysArr101, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr06a) != false)
                            m_mthMakeText(m_strKeysArr106a, m_strKeysArr06a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06b) != false)
                            m_mthMakeText(m_strKeysArr106b, m_strKeysArr06b, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
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
        #region 主诉
        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("主诉"))
                        objItemContent = m_hasItems["主诉"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("主诉", m_objPrintContext.m_ObjModifyUserArr);
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
               #endregion
        #region 主要病情
        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("主要病情"))
                        objItemContent = m_hasItems["主要病情"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("主要病情：(发病原因+主症)", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("主要病情", m_objPrintContext.m_ObjModifyUserArr);
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
               #endregion

   
        #region 既往史
        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("既往史"))
                        objItemContent = m_hasItems["既往史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("既往史：(诊断+时间+治愈)", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("既往史", m_objPrintContext.m_ObjModifyUserArr);
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
        #endregion
        #region 打印医保号和发病气节
        /// <summary>
        /// 打印电话 邮编  民族
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

     
            private string[] m_strKeysArr02 = { "", "神志>>有神", "神志>>倦怠", "神志>>烦躁", "神志>>嗜睡", "神志>>谵妄", "神志>>昏迷" };
            private string[] m_strKeysArr102 = { "KG \n二 四诊内容\n望诊：\n神志：", "神志>>有神", "神志>>倦怠", "神志>>烦躁", "神志>>嗜睡", "神志>>谵妄", "神志>>昏迷" };
            private string[] m_strKeysArr02a = { "神志" };
            private string[] m_strKeysArr102a = { "其他：" };

            private string[] m_strKeysArr03 = { "", "面色>>如常", "面色>>红润", "面色>>两颧潮红", "面色>>苍白", "面色>>萎黄", "面色>>晦暗", "面色>>无光泽" };
            private string[] m_strKeysArr103 = { "面色：", "面色>>如常", "面色>>红润", "面色>>两颧潮红", "面色>>苍白", "面色>>萎黄", "面色>>晦暗", "面色>>无光泽" };
            private string[] m_strKeysArr04 = { "面色" };
            private string[] m_strKeysArr104 = { "其他：" };
            private string[] m_strKeysArr05 = { "", "形态>>自如", "形态>>半身不遂", "形态>>步履艰难", "形态>>不得平卧", "形态>>双下肢活动受限" };
            private string[] m_strKeysArr105 = { "形态：", "形态>>自如", "形态>>半身不遂", "形态>>步履艰难", "形态>>不得平卧", "形态>>双下肢活动受限" };
            private string[] m_strKeysArr05a = { "形态" };
            private string[] m_strKeysArr105a= { "其他：" };
            private string[] m_strKeysArr06 = { "", "皮肤>>正常", "皮肤>>黄染", "皮肤>>苍白", "皮肤>>紫绀", "皮肤>>褥疮", "皮肤>>潮红", "皮肤>>溃烂" };
            private string[] m_strKeysArr106 = { "皮肤：", "皮肤>>正常", "皮肤>>黄染", "皮肤>>苍白", "皮肤>>紫绀", "皮肤>>褥疮", "皮肤>>潮红", "皮肤>>溃烂" };
            private string[] m_strKeysArr06a = { "皮肤" };
            private string[] m_strKeysArr106a = { "其他：" };
            private string[] m_strKeysArr06b = { "", "舌质>>淡红", "舌质>>淡白", "舌质>>红绛", "舌质>>紫暗" };
            private string[] m_strKeysArr106b = { "舌象：舌质：", "舌质>>淡红", "舌质>>淡白", "舌质>>红绛", "舌质>>紫暗" };
            private string[] m_strKeysArr06b1 = { "舌象>>舌质" };
            private string[] m_strKeysArr106b1 = { "其他：" };

            private string[] m_strKeysArr06c = { "", "舌苔>>薄白", "舌苔>>薄黄", "舌苔>>黄厚", "舌苔>>燥裂", "舌苔>>腐", "舌苔>>腻" };
            private string[] m_strKeysArr106c = { "舌苔：", "舌苔>>薄白", "舌苔>>薄黄", "舌苔>>黄厚", "舌苔>>燥裂", "舌苔>>腐", "舌苔>>腻" };
            private string[] m_strKeysArr06c1 = { "舌苔" };
            private string[] m_strKeysArr106c1 = { "其他：" };

            private string[] m_strKeysArr06d = { "", "语言>>清楚", "语言>>语音低微", "语言>>失语", "语言>>呻吟" };
            private string[] m_strKeysArr106d = { "\n闻诊：\n语言：", "语言>>清楚", "语言>>语音低微", "语言>>失语", "语言>>呻吟" };
            private string[] m_strKeysArr06e = { "语言" };
            private string[] m_strKeysArr106e = { "其他：" };

            private string[] m_strKeysArr06f = { "", "呼吸>>如常", "呼吸>>气促", "呼吸>>呼吸缓慢", "呼吸>>喘息气促" };
            private string[] m_strKeysArr106f = { "呼吸：", "呼吸>>如常", "呼吸>>气促", "呼吸>>呼吸缓慢", "呼吸>>喘息气促" };
            private string[] m_strKeysArr06g = { "呼吸"};
            private string[] m_strKeysArr106g = { "其他：" };
            private string[] m_strKeysArr06h = { "", "咳嗽>>无", "咳嗽>>有" };
            private string[] m_strKeysArr106h = { "咳嗽：", "咳嗽>>无", "咳嗽>>有" };
            private string[] m_strKeysArr06i = {  "咳嗽>>无痰", "咳嗽>>有痰" };
            private string[] m_strKeysArr106i = { "","咳嗽>>无痰", "咳嗽>>有痰" };
            private string[] m_strKeysArr06j = { "", "色>>白", "色>>黄", "色>>铁锈色", "色>>血痰" };
            private string[] m_strKeysArr106j = { "色：", "色>>白", "色>>黄", "色>>铁锈色", "色>>血痰" };
            private string[] m_strKeysArr06j1 = { "", "质>>清稀", "质>>黏稠" };
            private string[] m_strKeysArr106j1 = { "质：", "质>>清稀", "质>>黏稠"};
            private string[] m_strKeysArr06k = { "", "臭>>无异味", "臭>>有" };
            private string[] m_strKeysArr106k = { "嗅气味：", "臭>>无异味", "臭>>有" };

            private string[] m_strKeysArr06l = { "臭>>臭", "臭>>腥臭", "臭>>酸臭" };
            private string[] m_strKeysArr106l = { "","臭>>臭", "臭>>腥臭", "臭>>酸臭" };
            private string[] m_strKeysArr06m = { "臭气味" };
            private string[] m_strKeysArr106m = { "其他：" };
            private string[] m_strKeysArr07 = { "臭气味", "饮食>>正常", "饮食>>纳呆", "饮食>>多饮易饥", "饮食>>饥不择食", "饮食>>留置胃管", "饮食>>恶心呕吐", "饮食>>禁食" };
            private string[] m_strKeysArr107 = { "\n问诊：\n饮食：", "饮食>>正常", "饮食>>纳呆", "饮食>>多饮易饥", "饮食>>饥不择食", "饮食>>留置胃管", "饮食>>恶心呕吐", "饮食>>禁食" };
            private string[] m_strKeysArr07a = { "饮食" };
            private string[] m_strKeysArr107a = { "其他：" };
            private string[] m_strKeysArr07b = { "", "口渴>>正常", "口渴>>口不渴", "口渴>>口渴欲饮" };
            private string[] m_strKeysArr107b = { "口渴：", "口渴>>正常", "口渴>>口不渴", "口渴>>口渴欲饮" };
            private string[] m_strKeysArr07c = { "口渴" };
            private string[] m_strKeysArr107c = { "其他：" };
            private string[] m_strKeysArr07d = { "", "听力>>正常", "听力>>下降", "听力>>耳聋" };
            private string[] m_strKeysArr107d = { "听力：", "听力>>正常", "听力>>下降", "听力>>耳聋" };
            private string[] m_strKeysArr07e = { "听力" };
            private string[] m_strKeysArr107e = { "其他：" };
            private string[] m_strKeysArr07f = { "", "视觉>>正常", "视觉>>下降", "视觉>>失明" };
            private string[] m_strKeysArr107f = { "视觉：", "视觉>>正常", "视觉>>下降", "视觉>>失明" };
            private string[] m_strKeysArr07g = { "失明>>左", "失明>>右" };
            private string[] m_strKeysArr107g = {"", "失明>>左", "失明>>右" };
            private string[] m_strKeysArr07h = { "视觉" };
            private string[] m_strKeysArr107h = { "其他：" };
            private string[] m_strKeysArr07j = { "", "睡眠>>正常", "睡眠>>难入寐", "睡眠>>易醒", "睡眠>>彻夜不眠", "睡眠>>多梦", "睡眠>>早醒" };
            private string[] m_strKeysArr107j = { "睡眠：", "睡眠>>正常", "睡眠>>难入寐", "睡眠>>易醒", "睡眠>>彻夜不眠", "睡眠>>多梦", "睡眠>>早醒" };
            private string[] m_strKeysArr07k = { "辅助用药" };
            private string[] m_strKeysArr107k = { "辅助用药：" };
            private string[] m_strKeysArr07m = { "睡眠其他" };
            private string[] m_strKeysArr107m = { "其他：" };

            private string[] m_strKeysArr07m1 = { "", "大便>>正常", "大便>>便秘", "大便>>秘结", "大便>>柏油便", "大便>>便溏", "大便>>泄泻", "大便>>失禁", "大便>>造瘘口" };
            private string[] m_strKeysArr107m1 = { "大便：", "大便>>正常", "大便>>便秘", "大便>>秘结", "大便>>柏油便", "大便>>便溏", "大便>>泄泻", "大便>>失禁", "大便>>造瘘口" };
            private string[] m_strKeysArr07m2 = { "大便" };
            private string[] m_strKeysArr107m2 = { "其他：" };
            private string[] m_strKeysArr07m3 = { "", "小便>>正常", "小便>>频数", "小便>>癃闭", "小便>>尿少", "小便>>失禁", "小便>>留置尿管", "小便>>造瘘", "小便>>血尿", "小便>>浑浊" };
            private string[] m_strKeysArr107m3 = { "小便：", "小便>>正常", "小便>>频数", "小便>>癃闭", "小便>>尿少", "小便>>失禁", "小便>>留置尿管", "小便>>造瘘", "小便>>血尿", "小便>>浑浊" };
            private string[] m_strKeysArr07m4 = { "小便" };
            private string[] m_strKeysArr107m4 = { "其他：" };
            private string[] m_strKeysArr07m5 = { "", "嗜好>>无特殊", "嗜好>>吸烟", "嗜好>>饮酒", "嗜好>>酸", "嗜好>>甜", "嗜好>>辣", "嗜好>>肥甘" };
            private string[] m_strKeysArr107m5 = { "嗜好：", "嗜好>>无特殊", "嗜好>>吸烟", "嗜好>>饮酒", "嗜好>>酸", "嗜好>>甜", "嗜好>>辣", "嗜好>>肥甘" };
            private string[] m_strKeysArr07m6 = { "嗜好" };
            private string[] m_strKeysArr107m6 = { "其他：" };
            private string[] m_strKeysArr07m7 = { "", "脉象>>正常", "脉象>>浮", "脉象>>沉", "脉象>>迟", "脉象>>数", "脉象>>弦", "脉象>>滑", "脉象>>涩", "脉象>>洪", "脉象>>细", "脉象>>结代" };
            private string[] m_strKeysArr107m7 = { "\n切诊：\n  脉象：", "脉象>>正常", "脉象>>浮", "脉象>>沉", "脉象>>迟", "脉象>>数", "脉象>>弦", "脉象>>滑", "脉象>>涩", "脉象>>洪", "脉象>>细", "脉象>>结代" };
            private string[] m_strKeysArr07m8 = { "脉象","脉象" };
            private string[] m_strKeysArr107m8 = { "其他：", "#；" };
            private string[] m_strKeysArr07m9 = { "", "脘腹>>正常", "脘腹>>胀满", "脘腹>>腹痛喜按", "脘腹>>腹痛拒按" };
            private string[] m_strKeysArr107m9 = {"脘腹：", "脘腹>>正常", "脘腹>>胀满", "脘腹>>腹痛喜按", "脘腹>>腹痛拒按" };
            private string[] m_strKeysArr07m11 = { "腹部>>其他" };
            private string[] m_strKeysArr107m11 = { "其他：" };
            

            private string[] m_strKeysArr07m12 = { "", "神志>>平和", "神志>>开朗", "神志>>易怒", "神志>>忧郁", "神志>>焦虑", "神志>>恐惧", "神志>>内向" };
            private string[] m_strKeysArr107m12 = { "\n心理社会评估：\n情志：", "神志>>平和", "神志>>开朗", "神志>>易怒", "神志>>忧郁", "神志>>焦虑", "神志>>恐惧", "神志>>内向" };
            private string[] m_strKeysArr07m13 = { "神志好" };
            private string[] m_strKeysArr107m13 = { "其他：" };
            private string[] m_strKeysArr07m14 = { "", "对疾病>>了解", "对疾病>>部分了解", "对疾病>>不了解" };
            private string[] m_strKeysArr107m14 = { "\n对疾病：", "对疾病>>了解", "对疾病>>部分了解", "对疾病>>不了解"};
            private string[] m_strKeysArr07m15 = { "对疾病" };
            private string[] m_strKeysArr107m15 = { "其他：" };

            private string[] m_strKeysArr07m16 = { "", "家庭关系>>和睦", "家庭关系>>紧张" };
            private string[] m_strKeysArr107m16 = { "\n家庭关系：", "家庭关系>>和睦", "家庭关系>>紧张" };
            private string[] m_strKeysArr07m17 = { "家庭关系" };
            private string[] m_strKeysArr107m17 = { "其他：" };

            private string[] m_strKeysArr07m18 = { "", "经济>>公费", "经济>>医保", "经济>>自费" };
            private string[] m_strKeysArr107m18 = { "\n 经济状况：", "经济>>公费", "经济>>医保", "经济>>自费" };
            private string[] m_strKeysArr07m19 = { "经济状况" };
            private string[] m_strKeysArr107m19 = { "其他：" };

            private string[] m_strKeysArr07m20 = { "", "自立>>自理", "自立>>需协助", "自立>>不能自理" };
            private string[] m_strKeysArr107m20 = { "\n自理能力：", "自立>>自理", "自立>>需协助", "自立>>不能自理"};
            private string[] m_strKeysArr07m21 = { "自理能力" };
            private string[] m_strKeysArr107m21 = { "" };

            private string[] m_strKeysArr07m22 = { "", "生活>>合住", "生活>>独居" };
            private string[] m_strKeysArr107m22 = { "\n生活起居：", "生活>>合住", "生活>>独居" };
            private string[] m_strKeysArr07m23 = { "生活起居" };
            private string[] m_strKeysArr107m23 = { "其他：" };

            private string[] m_strKeysArr07m24 = { "护士", "护士长" };
            private string[] m_strKeysArr107m24 = { "\n\n        责任/当班护士：", "护士长(上级护师)：" };
          

        
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                       string[] m_strKeysArr01 =new string[]{ "体格检查>>T", "体格检查>>P", "体格检查>>R", "体格检查>>BP", "体格检查>>体重" };
           string[] m_strKeysArr101 =new string[]{ "一 生命体征：    T：", "℃  P：$$", "次/分  R：$$", "次/分  BP：$$", "Hg  体重：$$" };
                if (m_blnIsFirstPrint)
                {

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr02a) != false)
                            m_mthMakeText(m_strKeysArr102a, m_strKeysArr02a, ref strAllText, ref strXml);

                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05a) != false)
                            m_mthMakeText(m_strKeysArr105a, m_strKeysArr05a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06a) != false)
                            m_mthMakeText(m_strKeysArr106a, m_strKeysArr06a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06b1) != false)
                            m_mthMakeText(m_strKeysArr106b1, m_strKeysArr06b1, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06c1) != false)
                            m_mthMakeText(m_strKeysArr106c1, m_strKeysArr06c1, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06e) != false)
                            m_mthMakeText(m_strKeysArr106e, m_strKeysArr06e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06g) != false)
                            m_mthMakeText(m_strKeysArr106g, m_strKeysArr06g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106h, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106i, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106j, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106j1, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106k, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106l, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06m) != false)
                            m_mthMakeText(m_strKeysArr106m, m_strKeysArr06m, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07a) != false)
                            m_mthMakeText(m_strKeysArr107a, m_strKeysArr07a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07c) != false)
                            m_mthMakeText(m_strKeysArr107c, m_strKeysArr07c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07e) != false)
                            m_mthMakeText(m_strKeysArr107e, m_strKeysArr07e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107g, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07h) != false)
                            m_mthMakeText(m_strKeysArr107h, m_strKeysArr07h, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107j, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07k) != false)
                            m_mthMakeText(m_strKeysArr107k, m_strKeysArr07k, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m) != false)
                            m_mthMakeText(m_strKeysArr107m, m_strKeysArr07m, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m1, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m2) != false)
                            m_mthMakeText(m_strKeysArr107m2, m_strKeysArr07m2, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m3, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m4) != false)
                            m_mthMakeText(m_strKeysArr107m4, m_strKeysArr07m4, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m5, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m6) != false)
                            m_mthMakeText(m_strKeysArr107m6, m_strKeysArr07m6, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m7, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m8) != false)
                            m_mthMakeText(m_strKeysArr107m8, m_strKeysArr07m8, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m9, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m11) != false)
                            m_mthMakeText(m_strKeysArr107m11, m_strKeysArr07m11, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m12, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m13) != false)
                            m_mthMakeText(m_strKeysArr107m13, m_strKeysArr07m13, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m14, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m15) != false)
                            m_mthMakeText(m_strKeysArr107m15, m_strKeysArr07m15, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m16, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m17) != false)
                            m_mthMakeText(m_strKeysArr107m17, m_strKeysArr07m17, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m18, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m19) != false)
                            m_mthMakeText(m_strKeysArr107m19, m_strKeysArr07m19, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m20, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m21) != false)
                            m_mthMakeText(m_strKeysArr107m21, m_strKeysArr07m21, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107m22, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m23) != false)
                            m_mthMakeText(m_strKeysArr107m23, m_strKeysArr07m23, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07m24) != false)
                            m_mthMakeText(m_strKeysArr107m24, m_strKeysArr07m24, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
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
                   
        #region 签名
        /// <summary>
        /// 签名
        /// </summary>
        private class clsPrint15 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = { "审阅日期" };
            private string[] m_strKeysArr101 = { "审阅日期："};
         

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
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        //if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                        //    m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    p_intPosY += 20;
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 500, p_intPosY, p_objGrp);
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
