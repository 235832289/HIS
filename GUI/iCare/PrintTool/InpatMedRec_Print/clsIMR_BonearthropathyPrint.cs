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
    class clsIMR_BonearthropathyPrint:clsInpatMedRecPrintBase
    {

        public clsIMR_BonearthropathyPrint(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("骨伤科入院记录(关节病新疆版)",320),
                                                                           new clsPrint2(),
                                                                           new clsPrint3(),
                                                                           new clsPrint4(),
                                                                           new clsPrint5(),
                                                                           new clsPrint6(),
                                                                        //   new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                           new clsPrint9(),
                                                                           new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                      //   new clsPrint14(),
                                                                       
                                                                         new clsPrint16(),
                                                                       new clsPrint17(),
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
                p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

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

            private string[] m_strKeysArr01 = { "发病气节", "医保号" };
            private string[] m_strKeysArr101 = { "发病气节：", "               医保号：" };

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
            private string[] m_strKeysArr02 = { "", "输血史>>无", "输血史>>有" };
            private string[] m_strKeysArr102 = { "输血史：", "输血史>>无", "输血史>>有" };

            private string[] m_strKeysArr03 = { "", "手术史>>无", "手术史>>有" };
            private string[] m_strKeysArr103 = { "手术史：", "手术史>>无", "手术史>>有" };
            private string[] m_strKeysArr04 = { "", "外伤史>>无", "外伤史>>有" };
            private string[] m_strKeysArr104 = { "外伤史：", "外伤史>>无", "外伤史>>有" };
            private string[] m_strKeysArr05 = { "", "其他疾病>>无", "其他疾病>>有" };
            private string[] m_strKeysArr105 = { "其他疾病史：", "其他疾病>>无", "其他疾病>>有" };
            private string[] m_strKeysArr06 = { "过敏史", "致敏元" };
            private string[] m_strKeysArr106 = { "过敏史：", "致敏源：" };
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
                        //  if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                        m_mthMakeCheckText(m_strKeysArr101, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);



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
        #region 个人史 婚孕史 家族史
        /// <summary>
        /// 个人史
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
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
            private string[] m_strKeysArr01 = { "个人史" };
            private string[] m_strKeysArr101 = { "个人史：" };


            private string[] m_strKeysArr02 = { "婚孕史" };
            private string[] m_strKeysArr102 = { "； 婚孕史：" };
            private string[] m_strKeysArr03 = { "家族史" };
            private string[] m_strKeysArr103 = { "家族史：" };


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

                        m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        //  m_mthMakeText(m_strKeysArr1010, m_strKeysArr010, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                        // m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        // m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);

                        //   if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                        //       m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);
                        //    if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                        //     m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);

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
            private string[] m_strKeysArr01 = { "", "体格检查>>T", "体格检查>>P", "体格检查>>R", "体格检查>>BP" };
            private string[] m_strKeysArr101 = { "生命体征：", "\n        T(摄氏度)：", "P(次/分)：", "R(次/分)：", "BP(mmHg)：" };
            private string[] m_strKeysArr02 = { "", "体格检查>>发育", "体格检查>>营养", "体格检查>>意识", "体格检查>>表情" };
            private string[] m_strKeysArr102 = { "\n一般情况：", "\n        发育：", "营养：", "意识：", "表情：" };
            private string[] m_strKeysArr02a = { "", "整体合作>>有", "整体合作>>无" };
            private string[] m_strKeysArr102a = { "\n整体合作：", "整体合作>>有", "整体合作>>无" };
            private string[] m_strKeysArr02b = { "", "体味>>被动", "体味>>主动" };
            private string[] m_strKeysArr102b = { "体位：", "体味>>被动", "体味>>主动" };
            private string[] m_strKeysArr03 = { "", "皮肤毡膜>>有", "皮肤毡膜>>无" };
            private string[] m_strKeysArr103 = { "\n皮肤粘膜黄染：", "皮肤毡膜>>有", "皮肤毡膜>>无" };
            //   "浅表淋巴结肿大：", "", "浅表淋巴结肿大：", "", "", "咽部充血：", "咽部充血>>无", "咽部充血>>有", "头部畸形：", "头部畸形>>无", "头部畸形>>有", "巩膜黄染:", "巩膜黄>>无", "巩膜黄>>有", "扁桃体肿大：", "扁桃体肿大>>无", "扁桃体肿大>>有", "其他" };
            private string[] m_strKeysArr003 = { "", "领吧肿大>>有", "领吧肿大>>无" };
            private string[] m_strKeysArr1003 ={ "浅表淋巴肿胀：", "领吧肿大>>有", "领吧肿大>>无" };
            private string[] m_strKeysArr003m = { "", "头部畸形>>有", "头部畸形>>无" };
            private string[] m_strKeysArr1003m ={ "头部：畸形：", "头部畸形>>有", "头部畸形>>无" };


            private string[] m_strKeysArr003c = { "", "巩膜黄>>有", "巩膜黄>>无" };
            private string[] m_strKeysArr1003c ={ "巩膜黄染：", "巩膜黄>>有", "巩膜黄>>无" };
            private string[] m_strKeysArr003k = { "", "双侧瞳孔>>等大", "双侧瞳孔>>等圆", "双侧瞳孔>>不等大", "双侧瞳孔>>变小", "双侧瞳孔>>散大固定" };
            private string[] m_strKeysArr1003k ={ "双侧瞳孔：", "双侧瞳孔>>等大", "双侧瞳孔>>等圆", "双侧瞳孔>>不等大", "双侧瞳孔>>变小", "双侧瞳孔>>散大固定" };
            private string[] m_strKeysArr003d = { "", "对光反射>>有", "对光反射>>无" };
            private string[] m_strKeysArr1003d ={ "对光反射：", "对光反射>>有", "对光反射>>无" };
            private string[] m_strKeysArr003e = { "", "咽部充血>>有", "咽部充血>>无" };
            private string[] m_strKeysArr1003e ={ "咽部充血：", "咽部充血>>有", "咽部充血>>无" };
            private string[] m_strKeysArr003f = { "", "扁桃体肿大>>无", "扁桃体肿大>>1", "扁桃体肿大>>2", "扁桃体肿大>>3" };
            private string[] m_strKeysArr1003f ={ "扁桃体肿大：", "扁桃体肿大>>无", "扁桃体肿大>>1", "扁桃体肿大>>2", "扁桃体肿大>>3" };
            private string[] m_strKeysArr003g = { "", "扁桃体>>其他", };
            private string[] m_strKeysArr1003g ={ "其他：" };

            private string[] m_strKeysArr04 = { "", "经管>>气管局中>>是", "经管>>气管局中>>否" };
            private string[] m_strKeysArr104 = { " 颈项： 气管居中：", "经管>>气管局中>>是", "经管>>气管局中>>否" };

            private string[] m_strKeysArr04a = { "", "甲传鞋肿大>>有", "甲状中大>>无" };//, "甲状肿大>>无", "甲状肿
            private string[] m_strKeysArr104a = { " 甲状体肿大：", "甲传鞋肿大>>有", "甲状中大>>无" };
            private string[] m_strKeysArr04aa = { "", "活动度正常", "活动度困难" };//, "甲状肿大>>无", "甲状肿大
            private string[] m_strKeysArr104aa = { "活动度：", "活动度正常", "活动度困难" };

            private string[] m_strKeysArr04b = { "", "活动度>>其他" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他
            private string[] m_strKeysArr104b = { "其他：" };


            private string[] m_strKeysArr05a = { "", "胸部对称>>是", "胸部对称>>否" };
            private string[] m_strKeysArr105a = { "胸部：  胸部对称：", "胸部对称>>是", "胸部对称>>否" };
            private string[] m_strKeysArr05a1 = { "", "胸廓畸形有", "胸阔畸形无" };
            private string[] m_strKeysArr105a1 = { "胸廓畸形：", "胸廓畸形有", "胸阔畸形无" };
            private string[] m_strKeysArr05a2 = { "", "呼吸>>清音", "呼吸>>罗音" };
            private string[] m_strKeysArr105a2 = { "呼吸音：", "呼吸>>清音", "呼吸>>罗音" };
            private string[] m_strKeysArr05b = { "", "胸部>>其他" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他",
            private string[] m_strKeysArr105b = { "其他：" };


            private string[] m_strKeysArr05 = { "", "心率>>次" };// "节率：", "心率>>节律>>规整", "心率
            private string[] m_strKeysArr105 = { "心率(次/分)： " };//, "节率：", "心率>>节律>>规整", "心
            private string[] m_strKeysArr05c = { "", "节律>>规则", "节律>>不齐" };
            private string[] m_strKeysArr105c = { "心率节率：", "节律>>规则", "节律>>不齐" };
            private string[] m_strKeysArr05d = { "", "杂音>>有", "杂音>>无" };//, "甲状肿大>>无", "甲状肿大>>有"
            private string[] m_strKeysArr105d = { "杂音：", "杂音>>有", "杂音>>无" };

            private string[] m_strKeysArr06 = { "", "腹部" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "
            private string[] m_strKeysArr106 = { "腹部：" };//, "手术斑痕：", "手术斑痕>>无", "手
            private string[] m_strKeysArr061 = { "", "腹部>>通有", "腹部>>通无" };// "手术斑痕：", "手
            private string[] m_strKeysArr1061 = { "紧张压痛：", "腹部>>通有", "腹部>>通无" };
            private string[] m_strKeysArr06a = { "", "腹部>>反跳动>>有", "腹部>>反跳动>>无" };// "手术斑痕
            private string[] m_strKeysArr106a = { "反跳动：", "腹部>>反跳动>>有", "腹部>>反跳动>>无" };


            private string[] m_strKeysArr06b = { "", "腹部紧张>>有", "腹部紧张>>无" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106b = { "腹肌紧张：", "腹部紧张>>有", "腹部紧张>>无" };

            private string[] m_strKeysArr06c = { "", "包块>>有", "包块>>无" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106c = { "包块：", "包块>>有", "包块>>无" };

            private string[] m_strKeysArr06d = { "包块" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106d = { "包块：" };

            private string[] m_strKeysArr06e = { "肝脾出诊" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "：", ">>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106e = { "；肝脾肋下触诊：" };



            private string[] m_strKeysArr06f = { "肾区扣击痛>>有", "肾区扣击痛>>无" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106f = { "；肾区扣击痛：", "肾区扣击痛>>有", "肾区扣击痛>>无" };
            private string[] m_strKeysArr06g = { "", "肠鸣音>>正常", "肠鸣音>>亢进", "肠鸣音>>减弱", "肠鸣音>>硝石" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "
            private string[] m_strKeysArr106g = { "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr07 = { "肠>>其他", "舌象", "脉象" };
            private string[] m_strKeysArr107 = { "其他： ", "   舌象：", "  脉象：" };


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
                        m_mthMakeCheckText(m_strKeysArr102a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003m, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003k, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr003g) != false)
                            m_mthMakeText(m_strKeysArr1003g, m_strKeysArr003g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104aa, ref strAllText, ref strXml);


                        if (m_blnHavePrintInfo(m_strKeysArr04b) != false)
                            m_mthMakeText(m_strKeysArr104b, m_strKeysArr04b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a1, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a2, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05b) != false)
                            m_mthMakeText(m_strKeysArr105b, m_strKeysArr05b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1061, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06d) != false)
                            m_mthMakeText(m_strKeysArr106d, m_strKeysArr06d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06e) != false)
                            m_mthMakeText(m_strKeysArr106e, m_strKeysArr06e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106g, ref strAllText, ref strXml);


                        if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                            m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);

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
        #region 打印 专科检查
        /// <summary>
        /// 打印  专科检查>>
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = { "", "视诊>>部位", "视诊>>形态" };
            private string[] m_strKeysArr101 = { "视诊：部位：","形态：" };


            private string[] m_strKeysArr01b = { "", "触诊>>肿>>无", "触诊>>肿>>轻", "触诊>>肿>>中", "触诊>>肿>>重" };
            private string[] m_strKeysArr101b ={ "触诊：肿胀：", "触诊>>肿>>无", "触诊>>肿>>轻", "触诊>>肿>>中", "触诊>>肿>>重" };

            private string[] m_strKeysArr01bb = { "", "触诊>>其他" };
            private string[] m_strKeysArr101bb = { "其他：" };

            private string[] m_strKeysArr01b1 = { "", "压痛>>无", "压痛>>有" };
            private string[] m_strKeysArr101b1 ={ "压痛部位：", "压痛>>无", "压痛>>有" };
            private string[] m_strKeysArr01b2 = { "压痛" };
            private string[] m_strKeysArr101b2 ={ "" };
            private string[] m_strKeysArr01e = { "", "体表温度>>高", "体表温度>>低", "体表温度>>正常" };
            private string[] m_strKeysArr101e ={ "体表温度：", "体表温度>>高", "体表温度>>低", "体表温度>>正常" };




            private string[] m_strKeysArr01b3 = { "", "传导痛>>无", "传导痛>>有" };
            private string[] m_strKeysArr101b3 ={ "；传导痛：", "传导痛>>无", "传导痛>>有" };
            private string[] m_strKeysArr01b4 = { "传导痛" };
            private string[] m_strKeysArr101b4 ={ "" };
            private string[] m_strKeysArr01b5 = { "", "反射痛>>无", "反射痛>>有" };
            private string[] m_strKeysArr101b5 ={ "放射痛：", "反射痛>>无", "反射痛>>有" };
            private string[] m_strKeysArr01b6 = { "放射痛" };
            private string[] m_strKeysArr101b6 ={ "" };



            private string[] m_strKeysArr01f = { "", "活动>>曲", "活动>>伸", "旋转", "活动>>其他" };
            private string[] m_strKeysArr101f ={ "动诊： 活动度：屈：", "伸：", "旋转：" ,"\n其他："};

            private string[] m_strKeysArr02 = { "", "量诊" };
            private string[] m_strKeysArr102 = { "\n量诊：" };
            private string[] m_strKeysArr02a = { "", "圣经>>感觉" };// "肿瘤>>软", "肿瘤>>硬" };
            private string[] m_strKeysArr102a = { "\n神经系统检查：感觉：" };

            private string[] m_strKeysArr03 = { "", "运动" };// "红斑：", "压之退色", "压之不退色", "红斑>>颜色", "白斑：", "白班>>有", "白斑>>无", "水疱：", "水疱>>大", "水疱>>小", "尼氏症：", "尼氏症>>有", "尼氏症>>无", "风团>>颜色" };
            private string[] m_strKeysArr103 = { "\n运动：" };

            private string[] m_strKeysArr03a ={ "", "膝反射>>左", "膝反射>>右", "踝反射>>左", "踝反射>>右", "肛门反射" };
            private string[] m_strKeysArr103a = { "生理病理反射：膝反射 左：", " 右：", "踝反射 左：", "右", "肛门反射：" };


            private string[] m_strKeysArr03b ={ "", "hoffman>>+", "hoffman>>_" };
            private string[] m_strKeysArr103b = { "Hoffman征：", "hoffman>>+", "hoffman>>_" };
            private string[] m_strKeysArr03c ={ "", "babinski>>+", "babinski>>-" };
            private string[] m_strKeysArr103c = { "Babinski征：", "babinski>>+", "babinski>>-" };
            private string[] m_strKeysArr03d ={ "", "膑痉挛>>无", "膑痉挛>>有" };
            private string[] m_strKeysArr103d = { "膑阵挛：", "膑痉挛>>无", "膑痉挛>>有" };

            private string[] m_strKeysArr03e ={ "膑痉挛>>其他" };
            private string[] m_strKeysArr103e = { " " };
            private string[] m_strKeysArr03f ={ "", "踝阵脔>>无", "踝阵脔>>有" };
            private string[] m_strKeysArr103f = { "踝阵挛：", "踝阵脔>>无", "踝阵脔>>有" };

            private string[] m_strKeysArr03g ={ "踝阵脔>>其他" };
            private string[] m_strKeysArr103g = { " " };


            private string[] m_strKeysArr04 ={ "", "皮肤>>其他", "辅助检查", "x光片示", "生化检查", "生花>>其他" };
            private string[] m_strKeysArr104 = {  "\n其他：", "\n辅助检查：", "\nX光片示", "\n生化检查", "\n其他" };



            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (p_intPosY >= 1025)
                {
                    p_intPosY = 2000;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("专科检查", m_fotItemHead, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                    p_intPosY += 20;

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {

                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01bb) != false)
                            m_mthMakeText(m_strKeysArr101bb, m_strKeysArr01bb, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101b1, ref strAllText, ref strXml);


                        if (m_blnHavePrintInfo(m_strKeysArr01b2) != false)
                            m_mthMakeText(m_strKeysArr101b2, m_strKeysArr01b2, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101b3, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr01b4) != false)
                            m_mthMakeText(m_strKeysArr101b4, m_strKeysArr01b4, ref strAllText, ref strXml);


                        m_mthMakeCheckText(m_strKeysArr101b5, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01b6) != false)
                            m_mthMakeText(m_strKeysArr101b6, m_strKeysArr01b6, ref strAllText, ref strXml);


                        if (m_blnHavePrintInfo(m_strKeysArr01f) != false)
                            m_mthMakeText(m_strKeysArr101f, m_strKeysArr01f, ref strAllText, ref strXml);


                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr02a) != false)
                            m_mthMakeText(m_strKeysArr102a, m_strKeysArr02a, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr03a) != false)
 

                        m_mthMakeCheckText(m_strKeysArr103b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103d, ref strAllText, ref strXml);                           m_mthMakeText(m_strKeysArr103a, m_strKeysArr03a, ref strAllText, ref strXml);







                        if (m_blnHavePrintInfo(m_strKeysArr03e) != false)
                            m_mthMakeText(m_strKeysArr103e, m_strKeysArr03e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103f, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr03g) != false)
                            m_mthMakeText(m_strKeysArr103g, m_strKeysArr03g, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);

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
        #region 初步诊断
        /// <summary>
        /// 初步诊断
        /// </summary>
        private class clsPrint16 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("初步诊断"))
                        objItemContent = m_hasItems["初步诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("初步诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("初步诊断", m_objPrintContext.m_ObjModifyUserArr);
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
        #region 中西医诊断
        /// <summary>
        ///  主治医师
        /// </summary>
        private class clsPrint17 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr01 = { "中医诊断", "西医诊断" };
            private string[] m_strKeysArr101 = { "中医诊断：", "\n西医诊断：" };





            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                //				if(blnNextPage)
                //				{
                //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
                //					m_blnHaveMoreLine = true;
                //					blnNextPage = false;
                //					p_intPosY += 1500;
                //					return;
                //				}
                if (m_blnIsFirstPrint)
                {
                    //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
                    //					p_intPosY += 20;
                    //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
                    //					p_intPosY += 20;
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
                    m_mthAddSign2("检查者签字", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
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

            private string[] m_strKeysArr01 = { "住院医师" };
            private string[] m_strKeysArr101 = { "住院医师签名：" };
            private string[] m_strKeysArr02 = { "主任医师" };
            private string[] m_strKeysArr102 = { "\n主治医师签名：" };

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
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);

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
