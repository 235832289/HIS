using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
    /// <summary>
    /// 产后，人流后，取环后，月经后腹部输卵管结扎记录
    /// </summary>
    public class clsIMR_ManpowerAbortionRecordPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_ManpowerAbortionRecordPrintTool(string p_strTypeID)
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
																		   new clsPrintPatientFixInfo("产后,人流后,取环后,月经后腹部输卵管结扎记录",520),
																	    new clsPrintInPatMedRecCaseMain(),																		  
																		//	new clsPrintInPatMedDocAndDate(),
                                                                       new clsPrintInPatMedRecOutHospital(),
                                                                     //  new clsPrintInPatMedOutHospitalDocAndDate(),
                                                                       new clsPrintInPatMedResoult()     
																	   });
        }


        #region 打印实现

        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {

        //        p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);

        //        p_objGrp.DrawString("产后,人流后,取环后,月经后腹部输卵管结扎记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 150, 70);

        //        p_objGrp.DrawString("母亲住院号：", p_fntNormalText, Brushes.Black, 550, 110);
        //        p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 640, 110);
        //        p_intPosY = 150;
        //        m_blnHaveMoreLine = false;
        //        #region
        //        p_objGrp.DrawString("新生儿出生时记录病历", m_fotItemHead, Brushes.Black, m_intRecBaseX + 250, p_intPosY - 10);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

        //        p_intPosY += 20;
        //        if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //        {
        //            p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
        //        }

        //        m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
        //        int intRealHeight;
        //        Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
        //        m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);
        //        #endregion

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}

        //#endregion
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{ }
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
        #endregion

        #region 孕次----人流情况
        /// <summary>
        /// 孕次----人流情况
        /// </summary>
        private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            private string[] m_strKeysArr1 = { "", "记录I>>孕次", "记录I>>胎次" };
            private string[] m_strKeysArr2 = { "", "现有男孩", "现有女孩" };
            private string[] m_strKeysArr3 = { "", "记录I>>人流次", "记录I>>末产日期" };

            private string[] m_strKeysArr4 = { "", "记录I>>月经周期", "记录I>>月经量", "记录I>>痛经", "记录I>>末次月经" };
            private string[] m_strKeysArr5 = { "", "记录I>>有何妇科病", "记录I>>其他痛经" };

            private string[] m_strKeysArr6 = { "", "记录I>>血压", "记录I>>体温", "记录I>>肺", "记录I>>心", "记录I>>其他" };
            private string[] m_strKeysArr7 = { "", "记录I>>妇科检查>>外阴", "记录I>>妇科检查>>宫颈", "记录I>>妇科检查>>宫体位置","记录I>>妇科检查>>大小","记录I>>妇科检查>>活动","记录I>>妇科检查>>附件","记录I>>妇科检查>>右侧" };

            private string[] m_strKeysArr8 = { "", "记录I>>人流手术时间", "记录I>>人流组织","记录I>>人流情况","住院医师签名"};
           
             

            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

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
                        //if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                        //    m_mthMakeText(new string[] { "母亲姓名：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        ////						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);
                        m_mthMakeText(new string[] { "    ", "孕次：", "胎次：" }, m_strKeysArr1, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "    ", "；现有男孩：", "现有女孩:" }, m_strKeysArr2, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "    ", "人流次：", "末产日期：" }, m_strKeysArr3, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "月经周期：", "月经量：", "痛经：", "末次月经:" }, m_strKeysArr4, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "有何妇科病：", "其他痛经:" }, m_strKeysArr5, ref strAllText, ref strXml);
                        //if (m_blnHavePrintInfo(m_strKeysArr3) != false)
                        //    m_mthMakeText(new string[] { "    出生时间：", "", "年$$", "", "月$$", "", "日$$", "", "午$$", "", "时$$", "", "分$$" }, m_strKeysArr3, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n体检：" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "血压：", "体温：", "肺：", "心：", "其他：" }, m_strKeysArr6, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n妇科检查：" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "外阴：", "宫颈：", "宫体位置：", "大小：", "活动 ：", "附件 ：","右侧："}, m_strKeysArr7, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n    ", "人流手术时间：", "人流组织  ：", "克，人流情况：$$", "        术者：" }, m_strKeysArr8, ref strAllText, ref strXml);
                      
                        //m_mthMakeText(new string[] { "\n其他:" }, new string[] { "" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n    ", "畸形：", "眼睛滴药：" }, m_strKeysArr11, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n    ", "附注：" }, m_strKeysArr12, ref strAllText, ref strXml);
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



        #region 术者签名
        /// <summary>
        ///  术者签名
        /// </summary>
        //private class clsPrintInPatMedDocAndDate : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private bool blnNextPage = true;
        //    private string[] m_strKeysArr1 = { "住院医师签名" };
        //    //private string[] m_strKeysArr2 = { "记录日期" };

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_objContent == null || m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnHavePrintInfo(m_strKeysArr1) == false)// && m_blnHavePrintInfo(m_strKeysArr2) == false)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        //				if(blnNextPage)
        //        //				{
        //        //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
        //        //					m_blnHaveMoreLine = true;
        //        //					blnNextPage = false;
        //        //					p_intPosY += 1500;
        //        //					return;
        //        //				}
        //        if (m_blnIsFirstPrint)
        //        {
        //            //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
        //            //					p_intPosY += 20;
        //            //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
        //            //					p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if (m_objContent != null)
        //            {
        //                if (m_blnHavePrintInfo(m_strKeysArr1) != false)
        //                    m_mthMakeText(new string[] { "术者：" }, m_strKeysArr1, ref strAllText, ref strXml);
        //                //if (m_blnHavePrintInfo(m_strKeysArr2) != false)
        //                //    m_mthMakeText(new string[] { "\n记录日期" }, m_strKeysArr2, ref strAllText, ref strXml);

        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
        //            m_mthAddSign2("住院医师签名：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
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
        #endregion


        /// <summary>
        /// 结扎手术时间---结扎方式
        /// </summary>
        private class clsPrintInPatMedRecOutHospital : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            //private string[] m_strKeysArr1 = { "出院情况>>健康", "" };
            //private string[] m_strKeysArr2 = { "脐带:", "出院情况>>脱", "出院情况>>未脱" };
            //private string[] m_strKeysArr3 = { "脐带:", "出院情况>>干洁", "出院情况>>炎症" };
            //private string[] m_strKeysArr4 = { "", "出院情况>>疾病" };
            //private string[] m_strKeysArr5 = { "", "出院情况>>死亡", "出院情况>>死亡原因", "出院情况>>死亡时间" };

            private string[] m_strKeysArr1 = { "", "记录I>>结扎手术时间", "记录I>>术时用药" };
            private string[] m_strKeysArr2 = { "", "记录I>>输卵管情况>>左", "记录I>>输卵管情况>>右", "记录I>>输卵管情况>>卵巢" };
            private string[] m_strKeysArr3 = { "", "记录I>>结扎部位", "记录I>>结扎方式", "主治医师签名" };


            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

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
                        //if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                        //    m_mthMakeText(new string[] { "健康：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        ////						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);

                        //m_mthMakeCheckText(m_strKeysArr2, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(m_strKeysArr3, ref strAllText, ref strXml);
                        ////if (m_blnHavePrintInfo(m_strKeysArr3) != false)
                        ////    m_mthMakeText(new string[] { "    出生时间：", "", "年$$", "", "月$$", "", "日$$", "", "午$$", "", "时$$", "", "分$$" }, m_strKeysArr3, ref strAllText, ref strXml);
                        ////m_mthMakeText(new string[] { "\n检查情形：" }, new string[] { "" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n", "疾病：" }, m_strKeysArr4, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n", "死亡：", "死亡原因：", "死亡时间：" }, m_strKeysArr5, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "    ", "结扎手术时间：", "术时用药：" }, m_strKeysArr1, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "输卵管情况： 左：", "右 ：", "卵巢：" }, m_strKeysArr2, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "结扎部位：", "结扎方式：" ,"        术者："}, m_strKeysArr3, ref strAllText, ref strXml);

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


        /// <summary>
        /// 术者签名
        /// </summary>
        //private class clsPrintInPatMedOutHospitalDocAndDate : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private bool blnNextPage = true;
        //    private string[] m_strKeysArr1 = { "主治医师签名" };
        //    //private string[] m_strKeysArr2 = { "出院情况记录日期" };

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_objContent == null || m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnHavePrintInfo(m_strKeysArr1) == false )//&& m_blnHavePrintInfo(m_strKeysArr2) == false)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        //				if(blnNextPage)
        //        //				{
        //        //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
        //        //					m_blnHaveMoreLine = true;
        //        //					blnNextPage = false;
        //        //					p_intPosY += 1500;
        //        //					return;
        //        //				}
        //        if (m_blnIsFirstPrint)
        //        {
        //            //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
        //            //					p_intPosY += 20;
        //            //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
        //            //					p_intPosY += 20;
        //            string strAllText = "";
        //            string strXml = "";
        //            string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //            if (m_objContent != null)
        //            {
        //                if (m_blnHavePrintInfo(m_strKeysArr1) != false)
        //                    m_mthMakeText(new string[] { "术者：" }, m_strKeysArr1, ref strAllText, ref strXml);
        //                //if (m_blnHavePrintInfo(m_strKeysArr2) != false)
        //                //    m_mthMakeText(new string[] { "\n记录日期" }, m_strKeysArr2, ref strAllText, ref strXml);

        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
        //            m_mthAddSign2("主治医师签名：", m_objPrintContext.m_ObjModifyUserArr);
        //            m_blnIsFirstPrint = false;
        //        }

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
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





        /// <summary>
        /// 入院诊断,术中经过,术后情况,出院诊断
        /// </summary>  

        private class clsPrintInPatMedResoult : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            private string[] m_strKeysArr1 = { "记录II>>入院诊断", "" };
            private string[] m_strKeysArr2 = { "记录II>>术中经过", "" };
            private string[] m_strKeysArr3 = { "记录II>>术后情况", "" };
            private string[] m_strKeysArr4 = { "记录II>>出院诊断", "" }; 

            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

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
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "入院诊断：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n术中经过：", "    " }, m_strKeysArr2, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n术后情况：", "    " }, m_strKeysArr3, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n出院诊断：", "    " }, m_strKeysArr4, ref strAllText, ref strXml);
                        //						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);

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
