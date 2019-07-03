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

    /// <summary>
    /// 皮肤科住院病历
    /// </summary>
    class clsSkinRcreadPrintTool:clsInpatMedRecPrintBase
    {
        public clsSkinRcreadPrintTool(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("皮肤科住院病历",320),
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
                                                                         new clsPrint14(),
                                                                       
                                                                           new clsPrint16(),
                                                                           new clsPrint17(),
                                                                              new clsPrint15(),
                                                                       });
        }

        #region 打印实现

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
         
            private string[] m_strKeysArr01 = { "发病气节", "医保号"};
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
            private string[] m_strKeysArr01 = { "", "过去史>>传染病", "过去史>>输血", "过去史>>手术", "过去史>>外伤", "过去史>>其他疾病"};
            private string[] m_strKeysArr101 = { "过去史：", "\n           传染病：", "输血：", "手术：", "外伤：", "其他疾病："};
            private string[] m_strKeysArr04 = { "过去史>>过敏史", "过去史>>敏元" };
            private string[] m_strKeysArr104 = { "； 过敏史：", "致敏原："};

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
                      //  m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                     //   if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                      //      m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
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
        

            private string[] m_strKeysArr02 = {"婚孕史"};
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
            private string[] m_strKeysArr02 = { "", "体格检查>>发育", "体格检查>>营养", "体格检查>>意识", "体格检查>>表情"};
            private string[] m_strKeysArr102 = { "\n一般情况：", "\n        发育：", "营养：", "意识：", "表情："};
            private string[] m_strKeysArr03 = { "", "皮肤粘>>无", "皮肤粘>>有" };//  "浅表淋巴结肿大>>无", "浅表淋巴结肿大>>有", "咽部充血：", "咽部充血>>无", "咽部充血>>有", "头部畸形：", "头部畸形>>无", "头部畸形>>有", "巩膜黄染:", "巩膜黄>>无", "巩膜黄>>有", "扁桃体肿大：", "扁桃体肿大>>无", "扁桃体肿大>>有", "扁桃体>>其他" };
            private string[] m_strKeysArr103 = { "\n皮肤粘膜黄染：", "皮肤粘>>无", "皮肤粘>>有" };
         //   "浅表淋巴结肿大：", "", "浅表淋巴结肿大：", "", "", "咽部充血：", "咽部充血>>无", "咽部充血>>有", "头部畸形：", "头部畸形>>无", "头部畸形>>有", "巩膜黄染:", "巩膜黄>>无", "巩膜黄>>有", "扁桃体肿大：", "扁桃体肿大>>无", "扁桃体肿大>>有", "其他" };
             private string[] m_strKeysArr003 = { "", "浅表淋巴结肿大>>无","浅表淋巴结肿大>>有"};
            private string[] m_strKeysArr1003 ={ "浅表淋巴结肿大：", "浅表淋巴结肿大>>无","浅表淋巴结肿大>>有"};
            private string[] m_strKeysArr003a = { "", "咽部充血>>无", "咽部充血>>有" };
            private string[] m_strKeysArr1003a ={ "咽部充血：", "咽部充血>>无", "咽部充血>>有" };
            private string[] m_strKeysArr003b = { "", "头部畸形>>无", "头部畸形>>有" };
            private string[] m_strKeysArr1003b ={ "头部畸形：", "头部畸形>>无", "头部畸形>>有" };
            private string[] m_strKeysArr003c = { "", "巩膜黄>>无", "巩膜黄>>有" };
            private string[] m_strKeysArr1003c ={ "巩膜黄染：", "巩膜黄>>无", "巩膜黄>>有" };
            private string[] m_strKeysArr003d = { "", "扁桃体肿大>>无", "扁桃体肿大>>有" };
            private string[] m_strKeysArr1003d ={ "扁桃体肿大：", "扁桃体肿大>>无", "扁桃体肿大>>有" };
            private string[] m_strKeysArr003e = { "扁桃体>>其他",};
            private string[] m_strKeysArr1003e ={ "其他：" };
            private string[] m_strKeysArr04 = { "", "气管居中>>是", "气管居中>>否" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr104 = { " 颈管： 气管居中：", "气管居中>>是", "气管居中>>否"};//, "甲状肿大>>无", "甲状肿大>>有", "其他:", "/n胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "其他：" };
                private string[] m_strKeysArr04a = { "","甲状肿大>>无", "甲状肿大>>有" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr104a = { "； 甲状体肿大：", "甲状肿大>>无", "甲状肿大>>有" };
            private string[] m_strKeysArr04b = { "", "颈管>>其他" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr104b = { "其他：" };
            private string[] m_strKeysArr05a = { "", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr105a = { "胸部：  胸部对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是" };

            private string[] m_strKeysArr05b = { "", "胸部>>其他" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr105b = { "其他：" };
            private string[] m_strKeysArr05 = { "", "心率>>次数" };// "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };
            private string[] m_strKeysArr105 = { "心率(次/分)： " }                                  ;//, "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };
            private string[] m_strKeysArr05c = { "", "心率>>节律>>规整", "心率>>节律>>不齐" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr105c = { "心率节率：", "心率>>节律>>规整", "心率>>节律>>不齐" };
            private string[] m_strKeysArr05d = { "", "心率>>杂音>>无", "心率>>杂音>>有" };//, "甲状肿大>>无", "甲状肿大>>有", "颈管>>其他", "胸部：胸廓对称：", "胸部>>胸廓对称>>否", "胸部>>胸廓对称>>是", "呼吸音：", "胸部>>呼吸>>清", "胸部>>呼吸>>罗音", "胸部>>其他" };
            private string[] m_strKeysArr105d = { "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };

            private string[] m_strKeysArr06 = { "", "腹部>>柔软", "腹部>>紧张" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106 = { "腹部：", "腹部>>柔软", "腹部>>紧张"};//, "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };

            private string[] m_strKeysArr06a = { "", "手术斑痕>>无", "手术斑痕>>有" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106a = { "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有" };
            private string[] m_strKeysArr06b = { "", "包块>>无", "包块>>有" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106b = { "包块：", "包块>>无", "包块>>有" };
            private string[] m_strKeysArr06c = { "", "压痛>>无", "压痛>>有" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106c = { "压痛：", "压痛>>无", "压痛>>有" };
            private string[] m_strKeysArr06d = { "", "反跳动>>无", "反跳动>>有" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106d = { "反跳痛：", "反跳动>>无", "反跳动>>有" };
            private string[] m_strKeysArr06e = { "", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "：", ">>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106e = { "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常" };
            private string[] m_strKeysArr06f = { "", "肾区痛>>阳性", "肾区通阴性" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr106f = { "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性" };
            private string[] m_strKeysArr06g = { "", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };// "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "
            private string[] m_strKeysArr106g = { "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
            private string[] m_strKeysArr07 = { "肠鸣音>>其他", "舌象", "脉象" };
            private string[] m_strKeysArr107 = { "其他： ", "   舌象：", "  脉象："};
    

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

                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1003d, ref strAllText, ref strXml);
                          //  m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr003e) != false)
                            m_mthMakeText(m_strKeysArr1003e, m_strKeysArr003e, ref strAllText, ref strXml);
                       // if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                        //    m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04b) != false)
                            m_mthMakeText(m_strKeysArr104b, m_strKeysArr04b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05b) != false)
                            m_mthMakeText(m_strKeysArr105b, m_strKeysArr05b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr02, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106e, ref strAllText, ref strXml);
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
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
            private string[] m_strKeysArr01 = {  "原发皮损"};// "红斑：", "压之退色", "压之不退色", "红斑>>颜色", "白斑：", "白班>>有", "白斑>>无", "水疱：", "水疱>>大", "水疱>>小", "尼氏症：", "尼氏症>>有", "尼氏症>>无", "风团>>颜色" };
            private string[] m_strKeysArr101 = { "原发皮损：" };//, "红斑：", "压之退色", "压之不退色", "色：", "白斑：", "白班>>有", "白斑>>无", "水疱：", "水疱>>大", "水疱>>小", "尼氏症：", "尼氏症>>有", "尼氏症>>无", "风团：颜色：" };
            private string[] m_strKeysArr01a = { "", "红斑>>压之退色", "红斑>>压之不退色" };
            private string[] m_strKeysArr101a ={ "； 红斑：", "红斑>>压之退色", "红斑>>压之不退色" };
            private string[] m_strKeysArr01b = { "红斑>>颜色" };
            private string[] m_strKeysArr101b ={ "颜色："};
            private string[] m_strKeysArr01c = {"" ,"白班>>有", "白斑>>无" };
            private string[] m_strKeysArr101c ={ "； 白斑：", "白班>>有", "白斑>>无" };
            private string[] m_strKeysArr01d = { "", "水疱>>大", "水疱>>小" };
            private string[] m_strKeysArr101d ={ "水疱：", "水疱>>大", "水疱>>小" };
            private string[] m_strKeysArr01e = { "", "尼氏症>>有", "尼氏症>>无" };
            private string[] m_strKeysArr101e ={ "尼氏症：", "尼氏症>>有", "尼氏症>>无" };
            private string[] m_strKeysArr02 = { "结节>>大小", "结节>>色", "结节>>质地", "肿瘤>>大小"}; //"肿瘤>>圆形", "肿瘤>>带形", "肿瘤>>不规则", "肿瘤>>软", "肿瘤>>硬", "肿瘤>>高出皮面", "肿瘤>>平皮", "肿瘤>>良性", "肿瘤>>恶性", "囊肿：", "囊肿>>球形", "囊肿>>椭圆", "囊肿>>大小", "继发皮损" };
            private string[] m_strKeysArr102 = { "结节：  大小：", "       色：", "质地：", " 肿瘤：大小："};
            private string[] m_strKeysArr02a = { "","肿瘤>>圆形", "肿瘤>>带形", "肿瘤>>不规则"};// "肿瘤>>软", "肿瘤>>硬" };
          
            private string[] m_strKeysArr102a ={" ；", "肿瘤>>圆形", "肿瘤>>带形", "肿瘤>>不规则"};// "肿瘤>>软", "肿瘤>>硬" };
            private string[] m_strKeysArr02b = {"", "肿瘤>>软", "肿瘤>>硬" };
            private string[] m_strKeysArr102b ={ "","肿瘤>>软", "肿瘤>>硬" };
            private string[] m_strKeysArr02c = {"", "肿瘤>>高出皮面", "肿瘤>>平皮" };
            private string[] m_strKeysArr102c ={ "","肿瘤>>高出皮面", "肿瘤>>平皮" };
            private string[] m_strKeysArr02d = { "","肿瘤>>良性", "肿瘤>>恶性" };
            private string[] m_strKeysArr102d ={ "","肿瘤>>良性", "肿瘤>>恶性" };
            private string[] m_strKeysArr02e = { "", "囊肿>>球形", "囊肿>>椭圆" };
            private string[] m_strKeysArr102e ={ " 囊肿：", "囊肿>>球形", "囊肿>>椭圆" };
            private string[] m_strKeysArr03 = { "囊肿>>大小", "继发皮损" };// "红斑：", "压之退色", "压之不退色", "红斑>>颜色", "白斑：", "白班>>有", "白斑>>无", "水疱：", "水疱>>大", "水疱>>小", "尼氏症：", "尼氏症>>有", "尼氏症>>无", "风团>>颜色" };
            private string[] m_strKeysArr103 = { "大小：", "       继发皮损：" };
            private string[] m_strKeysArr03a ={ "","鱼鳞>>干性", "鱼鳞>>油性" };
            private string[] m_strKeysArr103a = { "；     鳞屑：", "鱼鳞>>干性", "鱼鳞>>油性" };
            private string[] m_strKeysArr03b ={"", "鱼鳞>>易剥脱", "鱼鳞>>不易剥脱" };
            private string[] m_strKeysArr103b = {"", "鱼鳞>>易剥脱", "鱼鳞>>不易剥脱" };
            private string[] m_strKeysArr03c ={"", "鱼鳞>>厚", "鱼鳞>>薄" };
            private string[] m_strKeysArr103c = { "","鱼鳞>>厚", "鱼鳞>>薄" };
            private string[] m_strKeysArr03d ={ "","鱼鳞>>银白色", "鱼鳞>>灰白色" };
            private string[] m_strKeysArr103d = { "","鱼鳞>>银白色", "鱼鳞>>灰白色" };
            private string[] m_strKeysArr03e ={ "", "糜烂>>糜烂渗出", "糜烂>>结瘕" };
            private string[] m_strKeysArr103e = { " 糜烂：", "糜烂>>糜烂渗出", "糜烂>>结瘕"};
            private string[] m_strKeysArr04 ={ "糜烂>>大小" };
            private string[] m_strKeysArr104 = { "面积大小：" };
            private string[] m_strKeysArr04a ={ "", "痂皮>>浆痂", "痂皮>>脓痂", "痂皮>>血痂" };
            private string[] m_strKeysArr104a = { " 痂皮：", "痂皮>>浆痂", "痂皮>>脓痂", "痂皮>>血痂" };
            private string[] m_strKeysArr04b ={ "", "抓痕>>点状", "抓痕>>线状" };
            private string[] m_strKeysArr104b = { " 抓痕：", "抓痕>>点状", "抓痕>>线状" };
            private string[] m_strKeysArr04c ={ "溃疡", "溃疡 >> 大小" };
            private string[] m_strKeysArr104c = { " 溃疡：", "大小：" };
            private string[] m_strKeysArr04ca ={ "","溃疡>>肉芽晦暗", "溃疡>>肉芽鲜红" };
            private string[] m_strKeysArr104ca = {"", "溃疡>>肉芽晦暗", "溃疡>>肉芽鲜红" };
            private string[] m_strKeysArr04cb ={ "","脓>>脓稠厚", "脓>>脓质如水" };
            private string[] m_strKeysArr104cb = { " 脓：", "脓>>脓稠厚", "脓>>脓质如水" };
            private string[] m_strKeysArr04cc ={"", "脓>>色白", "脓>>色黄", "脓>>色绿" };
            private string[] m_strKeysArr104cc = { "","脓>>色白", "脓>>色黄", "脓>>色绿" };
            private string[] m_strKeysArr05 ={ "浸渍:", "皲裂:", "苔藓化:", "硬化:" };
            private string[] m_strKeysArr105 = { "  浸渍:", "  皲裂:", "  苔藓化:", "  硬化:" };
            private string[] m_strKeysArr05a ={ "萎缩>>轻", "萎缩>>中", "萎缩>>重" };
            private string[] m_strKeysArr105a = { "  萎缩：", "萎缩>>轻", "萎缩>>中", "萎缩>>重" };
            private string[] m_strKeysArr05b ={ "","瘢痕>>陈旧性", "瘢痕>>萎缩性", "瘢痕>>增生性" };
            private string[] m_strKeysArr105b = { " 瘢痕：", "瘢痕>>陈旧性", "瘢痕>>萎缩性", "瘢痕>>增生性" };

            private string[] m_strKeysArr05c ={ "", "色素异常>>色素脱", "色素异常>>色素沉", "色素异常>>色素减退", "色素异常>>色素消失" };
            private string[] m_strKeysArr105c = { " 色素异常：", "色素异常>>色素脱", "色素异常>>色素沉", "色素异常>>色素减退", "色素异常>>色素消失" };
            private string[] m_strKeysArr05d ={ "", "皮疹大小>>粟米", "皮疹大小>>米粒", "皮疹大小>>黄豆", "皮疹大小>>小枣", "皮疹大小>>核桃", "皮疹大小>>鸡蛋", "皮疹大小>>手掌" };
            private string[] m_strKeysArr105d = { "  皮症大小：", "皮疹大小>>粟米", "皮疹大小>>米粒", "皮疹大小>>黄豆", "皮疹大小>>小枣", "皮疹大小>>核桃", "皮疹大小>>鸡蛋", "皮疹大小>>手掌" };
            private string[] m_strKeysArr05e ={ "", "皮疹形状>>圆形", "皮疹形状>>椭圆", "皮疹形状>>多角", "皮疹形状>>环形", "皮疹形状>>匐行", "皮疹形状>>唧形", "皮疹形状>>地图形", "皮疹形状>>蛎壳形" };
            private string[] m_strKeysArr105e = { "  皮疹形状：", "皮疹形状>>圆形", "皮疹形状>>椭圆", "皮疹形状>>多角", "皮疹形状>>环形", "皮疹形状>>匐行", "皮疹形状>>唧形", "皮疹形状>>地图形", "皮疹形状>>蛎壳形" };
            private string[] m_strKeysArr05f ={ "", "皮疹颜色>>淡红", "皮疹颜色>>红", "皮疹颜色>>鲜红", "皮疹颜色>>暗红", "皮疹颜色>>淡褐", "皮疹颜色>>褐", "皮疹颜色>>黑褐" };
            private string[] m_strKeysArr105f = { "  皮疹颜色：", "皮疹颜色>>淡红", "皮疹颜色>>红", "皮疹颜色>>鲜红", "皮疹颜色>>暗红", "皮疹颜色>>淡褐", "皮疹颜色>>褐", "皮疹颜色>>黑褐" };
            private string[] m_strKeysArr05g ={ "", "皮疹表面性质>>光滑", "皮疹表面性质>>粗糙", "皮疹表面性质>>刺状", "皮疹表面性质>>乳头状", "皮疹表面性质>>菜花" };
            private string[] m_strKeysArr105g = { "  皮疹表面性质：", "皮疹表面性质>>光滑", "皮疹表面性质>>粗糙", "皮疹表面性质>>刺状", "皮疹表面性质>>乳头状", "皮疹表面性质>>菜花" };
            private string[] m_strKeysArr05h ={ "", "皮疹分布>>单策性", "皮疹分布>>对称性", "皮疹分布>>局限性", "皮疹分布>>全身性", "皮疹分布>>散生性", "皮疹分布>>均布", "皮疹分布>>密布", "簇集沿神经分布", "沿血管分布" };
            private string[] m_strKeysArr105h = { "  皮疹分布：", "皮疹分布>>单策性", "皮疹分布>>对称性", "皮疹分布>>局限性", "皮疹分布>>全身性", "皮疹分布>>散生性", "皮疹分布>>均布", "皮疹分布>>密布", "簇集沿神经分布", "沿血管分布" };
            //  private string[] m_strKeysArr03 = { "鳞屑：", "鱼鳞>>干性", "鱼鳞>>油性", "鱼鳞>>易剥脱", "鱼鳞>>不易剥脱", "鱼鳞>>厚", "鱼鳞>>薄", "鱼鳞>>银白色", "鱼鳞>>灰白色", "糜烂：", "糜烂>>糜烂渗出", "糜烂>>结瘕", "糜烂>>大小", "痂皮：", "痂皮>>浆痂", "痂皮>>脓痂", "痂皮>>血痂", "抓痕：", "抓痕>>点状", "抓痕>>线状" };
        //    private string[] m_strKeysArr103 = { "鳞屑：", "鱼鳞>>干性", "鱼鳞>>油性", "鱼鳞>>易剥脱", "鱼鳞>>不易剥脱", "鱼鳞>>厚", "鱼鳞>>薄", "鱼鳞>>银白色", "鱼鳞>>灰白色", "糜烂：", "糜烂>>糜烂渗出", "糜烂>>结瘕", "面积大小", "痂皮：", "痂皮>>浆痂", "痂皮>>脓痂", "痂皮>>血痂", "抓痕：", "抓痕>>点状", "抓痕>>线状" };
         //   private string[] m_strKeysArr04 = { "溃疡", "溃疡>>肉芽晦暗", "溃疡>>肉芽鲜红", "溃疡>>大小", "脓：", "脓>>脓稠厚", "脓>>脓质如水", "脓>>色白", "脓>>色黄", "脓>>色绿", "浸渍", "皲裂", "苔藓化", "硬化" };
       //     private string[] m_strKeysArr104 = { "溃疡：", "溃疡>>肉芽晦暗", "溃疡>>肉芽鲜红", "大小：", "脓：", "脓>>脓稠厚", "脓>>脓质如水", "脓>>色白", "脓>>色黄", "脓>>色绿", "浸渍:", "皲裂:", "苔藓化", "硬化" };
        //    private string[] m_strKeysArr05 = { "萎缩：", "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };
       //     private string[] m_strKeysArr105 = { "心率(次/分)： ", "节率：", "心率>>节律>>规整", "心率>>节律>>不齐", "杂音：", "心率>>杂音>>无", "心率>>杂音>>有" };
        //    private string[] m_strKeysArr06 = { "腹部：", "胸部>>柔软", "胸部>>紧张", "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
       //     private string[] m_strKeysArr106 = { "腹部：", "胸部>>柔软", "胸部>>紧张", "手术斑痕：", "手术斑痕>>无", "手术斑痕>>有", "包块：", "包块>>无", "包块>>有", "压痛:", "压痛>>无", "压痛>>有", "反跳痛：", "反跳动>>无", "反跳动>>有", "肝脾肋下触诊：", "肝脾肋下触诊>>未触诊", "肝脾肋下触诊>>异常", "肾区扣击痛：", "肾区痛>>阳性", "肾区通阴性", "肠鸣音：", "肠音>>正常", "肠音>>亢进", "肠音>>减弱", "肠音>>消失" };
        //    private string[] m_strKeysArr07 = { "肠鸣音>>其他", "舌象", "脉象" };
    //        private string[] m_strKeysArr107 = { "其他： ", "/n  舌象：", "/n  脉象：" };


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
                            m_mthMakeCheckText(m_strKeysArr101a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01b) != false)
                            m_mthMakeText(m_strKeysArr101b, m_strKeysArr01b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101e, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                                 m_mthMakeCheckText(m_strKeysArr102a, ref strAllText, ref strXml);
                                 m_mthMakeCheckText(m_strKeysArr102b, ref strAllText, ref strXml);
                                 m_mthMakeCheckText(m_strKeysArr102c, ref strAllText, ref strXml);
                                 m_mthMakeCheckText(m_strKeysArr102d, ref strAllText, ref strXml);
                                 m_mthMakeCheckText(m_strKeysArr102e, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                             m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr103a, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr103b, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr103c, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr103d, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr103e, ref strAllText, ref strXml);
                         if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                             m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr104a, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr104b, ref strAllText, ref strXml);
                         if (m_blnHavePrintInfo(m_strKeysArr04c) != false)
                             m_mthMakeText(m_strKeysArr104c, m_strKeysArr04c, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr104ca, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr104cb, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr104cc, ref strAllText, ref strXml);
                         if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                             m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105b, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105c, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105d, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105e, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105f, ref strAllText, ref strXml);
                         m_mthMakeCheckText(m_strKeysArr105g, ref strAllText, ref strXml);
                     //   if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                     //       m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                   //     if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                   //         m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);
                   ////     if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                    //        m_mthMakeText(m_strKeysArr105, m_strKeysArr02, ref strAllText, ref strXml);
                  //      if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                  //          m_mthMakeText(m_strKeysArr106, m_strKeysArr02, ref strAllText, ref strXml);
                  //      if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                       //     m_mthMakeText(m_strKeysArr107, m_strKeysArr02, ref strAllText, ref strXml);

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
        #region 体格检查辅助检查
        /// <summary>
        /// 体格检查辅助检查
        /// </summary>
        private class clsPrint14 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("辅助检查"))
                        objItemContent = m_hasItems["辅助检查"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("辅助检查：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("辅助检查", m_objPrintContext.m_ObjModifyUserArr);
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
        #region 主治医师
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
            private string[] m_strKeysArr101 = { "中医诊断：","\n西医诊断：" };





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

            private string[] m_strKeysArr01 = { "住院医师", "住院>>日期" };
            private string[] m_strKeysArr101 = { "住院医师签名：", "             日期：$$" };
            private string[] m_strKeysArr02 = { "主任医师", "主治>>日期" };
            private string[] m_strKeysArr102 = { "\n主治医师签名：", "             日期：$$" };

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
        