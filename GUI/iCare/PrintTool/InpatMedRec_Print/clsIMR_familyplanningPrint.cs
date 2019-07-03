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
    class clsIMR_familyplanningPrint:clsInpatMedRecPrintBase
    {

        public clsIMR_familyplanningPrint(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("计划生育住院记录",320),
                                                                           new clsPrint2(),
                                                                           new clsPrint3(),
                                                                           new clsPrint4(),
                                                                           new clsPrint5(),
                                                                          // new clsPrint6(),
                                                                        //   new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                           new clsPrint9(),
                                                                        //   new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                        // new clsPrint14(),
                                                                       
                                                                       //    new clsPrint16(),
                                                                       //    new clsPrint17(),
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
                p_objGrp.DrawString("XHTCM/RD-129", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 140);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
              //  p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 20;

                p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);

                p_intPosY += 20;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }

                m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

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
        #region 打印电话和医保号
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

            private string[] m_strKeysArr01 = { "电话", "医保号" };
            private string[] m_strKeysArr101 = { "电话：", "               医保号：" };

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
        #region 现病史
        /// <summary>
        /// 现病史
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
                    if (m_hasItems.Contains("现病史"))
                        objItemContent = m_hasItems["现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("现病史", m_objPrintContext.m_ObjModifyUserArr);
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
        /// 既往史
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
            private string[] m_strKeysArr01 = { "", "传染病>>无", "传染病>>有" };
            private string[] m_strKeysArr101 = { "既往史：传染病史：", "传染病>>无", "传染病>>有" };
            private string[] m_strKeysArr01a = { "传染病史" };
            private string[] m_strKeysArr101a = { "" };
            private string[] m_strKeysArr02 = { "", "输血史>>无", "输血史>>有" };
            private string[] m_strKeysArr102 = { "输血史：", "输血史>>无", "输血史>>有" };

            private string[] m_strKeysArr03 = { "", "手术史>>无", "手术史>>有" };
            private string[] m_strKeysArr103 = { "手术史：", "手术史>>无", "手术史>>有" };

            private string[] m_strKeysArr03a = { "手术史" };
            private string[] m_strKeysArr103a = { "" };
            private string[] m_strKeysArr04 = { "", "外伤史>>无", "外伤史>>有" };
            private string[] m_strKeysArr104 = { "外伤史：", "外伤史>>无", "外伤史>>有" };
            private string[] m_strKeysArr04a = { "外伤史" };
            private string[] m_strKeysArr104a = { "" };
            private string[] m_strKeysArr05 = { "", "其他疾病>>无", "其他疾病>>有" };
            private string[] m_strKeysArr105 = { "其他疾病史：", "其他疾病>>无", "其他疾病>>有" };
            private string[] m_strKeysArr05a = { "其他疾病史" };
            private string[] m_strKeysArr105a = { "" };
            private string[] m_strKeysArr06 = { "", "过敏史>>无", "过敏史>>有" };
            private string[] m_strKeysArr106 = { "过敏史：", "过敏史>>无", "过敏史>>有" };
            private string[] m_strKeysArr07 = { "过敏史>>表现", "致敏元", "初潮年龄", "绝经", "未次月经时间" };
            private string[] m_strKeysArr107 = { "临床表现：","致敏原：","其他情况：月经初潮年龄：","绝经：","末次月经时间：" };
            private string[] m_strKeysArr07a = { "量多", "量中", "量少" };
            private string[] m_strKeysArr107a = {"", "量多", "量中", "量少" };
            private string[] m_strKeysArr07b = { "颜色>>红", "颜色>>淡", "颜色>>暗" };
            private string[] m_strKeysArr107b = { "色：", "颜色>>红", "颜色>>淡", "颜色>>暗" };
            private string[] m_strKeysArr07c = { "", "血块>>无", "血块>>有" };
            private string[] m_strKeysArr107c = { "血块：", "血块>>无", "血块>>有" };
            private string[] m_strKeysArr07d = { "", "痛经>>无", "痛经>>有" };
            private string[] m_strKeysArr107d = { "痛经：", "痛经>>无", "痛经>>有" };
            private string[] m_strKeysArr07e = { "", "程度>>轻", "程度>>中", "程度>>重" };
            private string[] m_strKeysArr107e = { "程度：", "程度>>轻", "程度>>中", "程度>>重" };
            private string[] m_strKeysArr07f = { "", "白带>>多", "白带>>中", "白带>>少" };
            private string[] m_strKeysArr107f = { "白带量：", "白带>>多", "白带>>中", "白带>>少" };
        
            private string[] m_strKeysArr07h = { "", "色>>无", "色>>白", "色>>黄", "色>>绿" };
            private string[] m_strKeysArr107h = { "色：", "色>>无", "色>>白", "色>>黄", "色>>绿" };
            private string[] m_strKeysArr07i = { "", "味>>无", "味>>有" };
            private string[] m_strKeysArr107i = { "味：", "味>>无", "味>>有" };
            private string[] m_strKeysArr07j = { "未次人流时间", "年龄婚", "怀孕", "产出", "人流" };
            private string[] m_strKeysArr107j = { "末次人流时间：", "结婚年龄：","孕：","产：","人流：" };
            private string[] m_strKeysArr07k = { "", "避孕>>是", "避孕>>否" };
            private string[] m_strKeysArr107k = { "避孕：", "避孕>>是", "避孕>>否" };


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
                        if (m_blnHavePrintInfo(m_strKeysArr01a) != false)
                            m_mthMakeText(m_strKeysArr101a, m_strKeysArr01a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03a) != false)
                            m_mthMakeText(m_strKeysArr103a, m_strKeysArr03a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04a) != false)
                            m_mthMakeText(m_strKeysArr104a, m_strKeysArr04a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05a) != false)
                            m_mthMakeText(m_strKeysArr105a, m_strKeysArr05a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                    
                        if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                            m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107h, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107i, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07j) != false)
                            m_mthMakeText(m_strKeysArr107j, m_strKeysArr07j, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107k, ref strAllText, ref strXml);
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
        #region 打印 体格检查
        /// <summary>
        /// 打印 体格检查>>
        /// </summary>
        private class clsPrint9 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
          
            private string[] m_strKeysArr02 = { "", "体格检查>>发育", "体格检查>>营养", "体格检查>>意识", "体格检查>>表情" };
            private string[] m_strKeysArr102 = { "\n一般情况：", "\n        发育：", "营养：", "意识：", "表情：" };
            private string[] m_strKeysArr03 = { "", "体格检查>>合作", "体格检查>>不合作" };
            private string[] m_strKeysArr103 = { "\n体格检查：", "体格检查>>合作", "体格检查>>不合作" };
            private string[] m_strKeysArr03a = { "皮肤黄染", "出血点", "瘀斑" };
            private string[] m_strKeysArr103a = { "\n皮肤粘膜：黄染：", "出血点：", "瘀斑：" };
            private string[] m_strKeysArr003b = { "", "头部畸形>>有", "头部>>畸形>>无" };
            private string[] m_strKeysArr1003b ={ "；头部：畸形：", "头部畸形>>有", "头部>>畸形>>无" };
            private string[] m_strKeysArr003c = { "", "巩膜黄染>>有", "巩膜黄染>>无" };
            private string[] m_strKeysArr1003c ={ "巩膜黄染：", "巩膜黄染>>有", "巩膜黄染>>无" };
 //private string[] m_strKeysArr003 = { "", "浅表淋巴结肿大>>无", "浅表淋巴结肿大>>有" };
 //           private string[] m_strKeysArr1003 ={ "浅表淋巴结肿大：", "浅表淋巴结肿大>>无", "浅表淋巴结肿大>>有" };
             private string[] m_strKeysArr003a = { "", "对光反射>>正常", "对光反射>>迟钝" };
            private string[] m_strKeysArr1003a ={ "瞳孔对光反射：", "对光反射>>正常", "对光反射>>迟钝" };
            private string[] m_strKeysArr003a1 = { "", "左右消失>>左", "左右消失>>右" };
            private string[] m_strKeysArr1003a1 ={ "左右消失：", "左右消失>>左", "左右消失>>右" };
            private string[] m_strKeysArr003d = { "", "口唇>>红润", "口唇>>发绀", "口唇>>参白" };
            private string[] m_strKeysArr1003d ={ "口唇：", "口唇>>红润", "口唇>>发绀", "口唇>>参白" };
            private string[] m_strKeysArr003e = { "扁桃体", "咽" };
            private string[] m_strKeysArr1003e ={ "扁桃腺：","咽：" };
        private string[] m_strKeysArr04 = { "", "颈抵抗感>>有", "颈抵抗感>>无" };
            private string[] m_strKeysArr104 = { "； 颈管： 抵抗感：", "颈抵抗感>>有", "颈抵抗感>>无" };
            private string[] m_strKeysArr04a = { "", "肺呼吸音>>清", "肺呼吸音>>减弱", "肺呼吸音>>增粗" };
            private string[] m_strKeysArr104a = { "肺部呼吸音：", "肺呼吸音>>清", "肺呼吸音>>减弱", "肺呼吸音>>增粗" };
            private string[] m_strKeysArr04a1 = { "肺部>>清>>左", "肺部>>清>>右" };
            private string[] m_strKeysArr104a1 = {"", "肺部>>清>>左", "肺部>>清>>右" };
            private string[] m_strKeysArr04a2 = { "肺>>减弱>>左", "肺>>减弱>>右" };
            private string[] m_strKeysArr104a2 = {"", "肺>>减弱>>左", "肺>>减弱>>右" };
            private string[] m_strKeysArr04a3 = { "肺>>增粗>>左", "肺>>增粗>>右" };
            private string[] m_strKeysArr104a3 = {"", "肺>>增粗>>左", "肺>>增粗>>右" };
            private string[] m_strKeysArr04b = { "", "干性罗音>>无", "干性罗音>>有" };
            private string[] m_strKeysArr104b = { "干性罗音：", "干性罗音>>无", "干性罗音>>有" };
            private string[] m_strKeysArr04b1 = { "干性>>左", "干性>>右" };
            private string[] m_strKeysArr104b1 = { "", "干性>>左", "干性>>右" };
            private string[] m_strKeysArr04c = { "", "湿性罗音>>无", "湿性罗音>>有" };
            private string[] m_strKeysArr104c = { "湿性罗音：", "湿性罗音>>无", "湿性罗音>>有" };
            private string[] m_strKeysArr04c1 = { "湿性>>左", "湿性>>右" };
            private string[] m_strKeysArr104c1 = { "", "湿性>>左", "湿性>>右" };



            private string[] m_strKeysArr05a = { "心率" };
            private string[] m_strKeysArr105a = { "心率(次/min)：" };

            private string[] m_strKeysArr05b = { "", "心率>>齐", "心率>>不齐" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>
            private string[] m_strKeysArr105b = { "；心律：", "心率>>齐", "心率>>不齐" };
            private string[] m_strKeysArr05 = { "", "病理杂音>>无", "病理杂音>>有" };// "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };
            private string[] m_strKeysArr105 = { "病理杂音： ", "病理杂音>>无", "病理杂音>>有" };//, "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };


            private string[] m_strKeysArr06 = { "", "腹肌紧张>>有", "腹肌紧张>>无" };
            private string[] m_strKeysArr106 = { "腹部：腹肌紧张：", "腹肌紧张>>有", "腹肌紧张>>无" };

            private string[] m_strKeysArr06a = { "", "压痛>>有", "压痛>>无" };
            private string[] m_strKeysArr106a = { "压痛：", "压痛>>有", "压痛>>无" };
            private string[] m_strKeysArr06a1 = { "压痛>>部位" };
            private string[] m_strKeysArr106a1 = { "部位：" };
     private string[] m_strKeysArr06b = { "", "反跳动>>无", "反跳动>>有" };
            private string[] m_strKeysArr106b = { "；反跳动：", "反跳动>>无", "反跳动>>有" };

            private string[] m_strKeysArr06c = { "", "肝脾>>未触及", "肝脾>>可触及" };
            private string[] m_strKeysArr106c = { "肝脾：", "肝脾>>未触及", "肝脾>>可触及" };
            private string[] m_strKeysArr06d = { "肝脾>>大小" };
            private string[] m_strKeysArr106d = { "大小(cm)：" };
            private string[] m_strKeysArr06e = { "", "肝压痛>>有", "肝压痛>>无" };
            private string[] m_strKeysArr106e = { "；压痛：", "肝压痛>>有", "肝压痛>>无" };
            private string[] m_strKeysArr06f = { "", "murphy>>有", "murphy>>无" };
            private string[] m_strKeysArr106f = { "Murphy征：", "murphy>>有", "murphy>>无" };

            private string[] m_strKeysArr06g = { "","宫高","腹围","胎心","胎位" };
            private string[] m_strKeysArr106g = { "\n产科检查：","宫高(cm)：","腹围(cm)：","胎心(次/min)：","胎位：" };
            private string[] m_strKeysArr07 = { "坐骨间", "骶耻外径", "髂棘间经", "髂嵴间经", "妇科>>肛查", "耻骨弓角", "外阴", "阴道", "宫颈", "子宫", "附件", "实验检查", "住院检查" };
            private string[] m_strKeysArr107 = { "；坐骨结节间径： ", "   骶耻外径：", "  髂棘间经：", "髂嵴间经：", "\n妇科检查（肛查）：", "耻骨弓角：", "\n外阴：", "\n阴道：","\n宫颈：","\n子宫：","\n附件：","\n实验室检查：","住院后常规检查：" };
            private string[] m_strKeysArr08 = { "血常规>>hb", "rbc", "wbc", "中性", "淋巴", "tbc"};
            private string[] m_strKeysArr108 = { "；血常规：HB(g/I)： ", "   RBC：", "  WBC(×109/L)：", "中性(%)：", "淋巴(%)：","TBC：" };
            private string[] m_strKeysArr09 = { "", "凝血>>正常", "凝血>>不正常" };
            private string[] m_strKeysArr109 = { "；术前凝血功能检查：", "凝血>>正常", "凝血>>不正常" };
            private string[] m_strKeysArr10 = { "凝血检查" };
            private string[] m_strKeysArr110 = { "" };
            private string[] m_strKeysArr11 = { "", "肝功>>正常", "肝功>>不正常" };
            private string[] m_strKeysArr111 = { "；肝功：", "肝功>>正常", "肝功>>不正常" };
            private string[] m_strKeysArr12 = { "血糖"};
            private string[] m_strKeysArr112 = { "血糖：" };
            private string[] m_strKeysArr13 = { "", "肾功>>正常", "肾功>>不正常" };
            private string[] m_strKeysArr113 = { "；肾功：", "肾功>>正常", "肾功>>不正常" };
            private string[] m_strKeysArr14 = { "", "尿>>正常", "尿>>不正常" };
            private string[] m_strKeysArr114 = { "尿常规：", "尿>>正常", "尿>>不正常" };
            private string[] m_strKeysArr15 = { "白带常规", "b超", "胸透", "诊断" };
            private string[] m_strKeysArr115 = { "\n血/尿妊娠试验 白带常规：", "\nB超：", "\n胸透：", "\n诊断：" };

            private string[] m_strKeysArr15a = { "", "人流", "药流", "输卵管" ,"腹腔镜"};
            private string[] m_strKeysArr115a = { "\n治疗计划：", "1、人工流产：", "2、药流术加钳刮术/碎胎术：", "3、输卵管结扎术：腹部手术施育：", "腹腔镜绝育：" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                // Console.Write(p_intPosY);
                if (p_intPosY >= 1005)
                {
                    p_intPosY = 2000;
                    return;
                }
                            string[] m_strKeysArr01 = new string[]{ "", "体格检查>>T", "体格检查>>P", "体格检查>>R", "体格检查>>BP","" };
                             string[] m_strKeysArr101 = new string[]{ "生命体征：", "\n        T：", "℃  P：$$", " 次/分  R：$$", " 次/分  BP：$$", " mmHg$$" };
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("体格检查", m_fotItemHead, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                    p_intPosY += 20;

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03a) != false)
                            m_mthMakeText(m_strKeysArr103a, m_strKeysArr03a, ref strAllText, ref strXml);
                            m_mthMakeCheckText(m_strKeysArr1003b, ref strAllText, ref strXml);
                                  m_mthMakeCheckText(m_strKeysArr1003c, ref strAllText, ref strXml);
                                   //  m_mthMakeCheckText(m_strKeysArr100a, ref strAllText, ref strXml);
                     
                                  m_mthMakeCheckText(m_strKeysArr1003a, ref strAllText, ref strXml);
                                  m_mthMakeCheckText(m_strKeysArr1003a1, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr1003d, ref strAllText, ref strXml);
                       
                       if (m_blnHavePrintInfo(m_strKeysArr003e) != false)
                            m_mthMakeText(m_strKeysArr1003e, m_strKeysArr003e, ref strAllText, ref strXml);
                       m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                       m_mthMakeCheckText(m_strKeysArr104a, ref strAllText, ref strXml);

                       if (m_blnHavePrintInfo(m_strKeysArr04a1) != false)
                       m_mthMakeCheckText(m_strKeysArr104a1, ref strAllText, ref strXml);
                   if (m_blnHavePrintInfo(m_strKeysArr04a2) != false)
                       m_mthMakeCheckText(m_strKeysArr104a2, ref strAllText, ref strXml);
                   if (m_blnHavePrintInfo(m_strKeysArr04a3) != false)
                       m_mthMakeCheckText(m_strKeysArr104a3, ref strAllText, ref strXml);
                       m_mthMakeCheckText(m_strKeysArr104b, ref strAllText, ref strXml);
                       m_mthMakeCheckText(m_strKeysArr104b1, ref strAllText, ref strXml);
                    m_mthMakeCheckText(m_strKeysArr104c, ref strAllText, ref strXml);
                    m_mthMakeCheckText(m_strKeysArr104c1, ref strAllText, ref strXml);
                              if (m_blnHavePrintInfo(m_strKeysArr05a) != false)
                            m_mthMakeText(m_strKeysArr105a, m_strKeysArr05a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                 m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06a1) != false)
                            m_mthMakeText(m_strKeysArr106a1, m_strKeysArr06a1, ref strAllText, ref strXml);
                     m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06d) != false)
                            m_mthMakeText(m_strKeysArr106d, m_strKeysArr06d, ref strAllText, ref strXml);    
                         m_mthMakeCheckText(m_strKeysArr106e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06g) != false)
                            m_mthMakeText(m_strKeysArr106g, m_strKeysArr06g, ref strAllText, ref strXml);
                       if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                            m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08) != false)
                            m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr10) != false)
                            m_mthMakeText(m_strKeysArr110, m_strKeysArr10, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr111, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr12) != false)
                            m_mthMakeText(m_strKeysArr112, m_strKeysArr12, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr113, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr114, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr15) != false)
                            m_mthMakeText(m_strKeysArr115, m_strKeysArr15, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr15a) != false)
                            m_mthMakeText(m_strKeysArr115a, m_strKeysArr15a, ref strAllText, ref strXml);
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

            private string[] m_strKeysArr01 = { "医师签名" };
            private string[] m_strKeysArr101 = { "医师签名："};
            //private string[] m_strKeysArr02 = { "主任医师", "主治>>日期" };
            //private string[] m_strKeysArr102 = { "\n主治医师签名：", "             日期：$$" };

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

    }
}
