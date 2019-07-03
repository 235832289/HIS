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
    public class clsIMR_PullDeliverRecord_CS : clsInpatMedRecPrintBase
    {
        /// <summary>
        /// 阴道胎头吸引器助产手术记录(茶山)
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_PullDeliverRecord_CS(string p_strTypeID)
            : base(p_strTypeID)
        {
            //构造函数

        }



        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo(),
				                                                          new clsPrint2(),
                                                                          new clsPrint10(),
                                                                          new clsPrint3(),  
                                                                          new clsPrint4(),                                                  
                                                                          new clsPrint5(),
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                          new clsPrint8(),
                                                                          new clsPrint9(),
                                                                        
                                                                          //new clsPrint11(),
                                                                          //new clsPrint12(true),
                                                                                    
																	   });
        }


        /// <summary>
        /// 打印第一页的固定内容 
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);
                p_objGrp.DrawString("阴道胎头吸引器助产手术记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 300, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, 350, 130);
                p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmInPatientDate, p_fntNormalText, Brushes.Black, 430, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 680, 130);
                p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }


        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        { }
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        /// <summary>
        /// 手术日期,孕次
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
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

                    //p_objGrp.DrawString("手术经过：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "手术日期：", "$$", "孕：", "$$", "产：", "$$" },
                        new string[] { "", "手术日期", "", "孕次", "", "产次" }, ref strAllText, ref strXml);



                        //   m_mthMakeCheckText(new string[] { "\n胎儿娩出方式：", "分娩记录I>>胎儿娩出方式>>顺产", "分娩记录I>>胎儿娩出方式>>吸引产", "分娩记录I>>胎儿娩出方式>>钳产", "分娩记录I>>胎儿娩出方式>>剖宫产", "分娩记录I>>胎儿娩出方式>>助臀产" }, ref strAllText, ref strXml);
                        //    m_mthMakeCheckText(new string[] { "", "分娩记录I>>胎儿娩出方式>>助产", "分娩记录I>>胎儿娩出方式>>牵引" }, ref strAllText, ref strXml);

                        //    m_mthMakeText(new string[] { "胎立位：", "$$", "\n胎盘娩出时间：", "$$", "#年", "$$", "#月", "$$", "#日", "$$", "#时", "$$", "#分" },
                        //      new string[] { "", "分娩记录I>>胎儿娩出方式>>胎立位", "", "分娩记录I>>胎盘娩出时间>>年", "分娩记录I>>胎盘娩出时间>>月", "分娩记录I>>胎盘娩出时间>>月", "分娩记录I>>胎盘娩出时间>>日", "分娩记录I>>胎盘娩出时间>>日", "分娩记录I>>胎盘娩出时间>>时", "分娩记录I>>胎盘娩出时间>>时", "分娩记录I>>胎盘娩出时间>>分", "分娩记录I>>胎盘娩出时间>>分", "分娩记录I>>胎盘娩出时间>>分" }, ref strAllText, ref strXml);



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

        /// <summary>
        /// 手术指征
        /// </summary>    
        private class clsPrint3 : clsIMR_PrintLineBase
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

                    //p_objGrp.DrawString("手术经过：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {                                                                                                                                                                                          //, "\n（四）断肌肉：$$", "$$"             
                        m_mthMakeText(new string[] { "手术指征：", "$$" },                                               //, "", "手术经过>>断肌肉"
                            new string[] { "", "手术指征" }, ref strAllText, ref strXml);
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

        /// <summary>
        /// 术后诊断
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("术后诊断"))
                        objItemContent = m_hasItems["术后诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术后诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "术后诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 45, p_intPosY, p_objGrp);
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
        /// 术后诊断
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("术前诊断"))
                        objItemContent = m_hasItems["术前诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术前诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "术前诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 45, p_intPosY, p_objGrp);
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
        /// 麻醉方式
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
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

                    //p_objGrp.DrawString("手术经过：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {                                                                                                                                                                                          //, "\n（四）断肌肉：$$", "$$"             
                        m_mthMakeText(new string[] { "麻醉方式：", "$$" },                                               //, "", "手术经过>>断肌肉"
                            new string[] { "", "麻醉方式" }, ref strAllText, ref strXml);
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


        /// <summary>
        /// 麻醉师
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr1 = { "麻醉师" };
            //private string[] m_strKeysArr2 = { "记录日期" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)// && m_blnHavePrintInfo(m_strKeysArr2) == false)
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
                            m_mthMakeText(new string[] { "麻醉师：" }, m_strKeysArr1, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("麻醉师：", m_objPrintContext.m_ObjModifyUserArr);
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

        /// <summary>
        ///术前产检>
        /// </summary>
        private class clsPrint7 : clsIMR_PrintLineBase
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
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {

                    //p_objGrp.DrawString("手术经过：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "术前产检:宫高：", "$$", "#cm,腹围：", "$$", "#cm,先露：", "$$" },
                        new string[] { "", "术前产检>>宫高", "术前产检>>宫高", "术前产检>>腹围", "术前产检>>腹围", "术前产检>>先露" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "衔接：", "术前产检>>衔接>>未", "术前产检>>衔接>>浅", "术前产检>>衔接>>深" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "估计胎重：", "$$", "#g" },
                         new string[] { "", "术前产检>>估计胎重", "术前产检>>估计胎重" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n术前阴检：坐骨棘:", "术前阴检>>坐骨棘>>平伏", "术前阴检>>坐骨棘>>稍突", "术前阴检>>坐骨棘>>突出" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "尾骨弧度:", "术前阴检>>尾骨弧度>>高", "术前阴检>>尾骨弧度>>中", "术前阴检>>尾骨弧度>>低" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "坐骨切迹:", "术前阴检>>坐骨切迹>>大于2指", "术前阴检>>坐骨切迹>>等于2指", "术前阴检>>坐骨切迹>>小于2指" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "DC：", "$$", "#cm,宫口：", "$$", "#cm" },
                         new string[] { "", "术有阴检>>DC", "术有阴检>>DC", "术有阴检>>宫口", "术有阴检>>宫口" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "羊水 ：", "术前阴检>>羊水>>清", "术前阴检>>羊水>>Ⅰ", "术前阴检>>羊水>>Ⅱ", "术前阴检>>羊水>>Ⅲ" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "胎方位：", "$$", "先露高低：", "$$" },
                        new string[] { "", "术前阴查>>胎方位", "", "术前阴查>>先露高低" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "颅骨变形 ：", "术前阴检>>颅骨变形>>有", "术前阴检>>颅骨变形>>无" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "产瘤大小：", "$$", "产瘤位置：", "$$" },
                        new string[] { "", "术前阴查>>产瘤大小", "", "术前阴查>>产瘤位置" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n1．产妇取膀胱截石位，会阴常规消毒后铺无菌巾，导尿排空膀胱。" },
                          new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n2．检查吸引器无损坏、漏气，橡皮套无松动，并连接橡皮管于吸引器空心管柄上。" },
                          new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n3．再次阴道检查确定宫口开大", "$$", "#cm，胎头为顶先露，其先露部达棘下：", "$$", "#，无胎吸禁忌症","" },
                         new string[] { "", "宫口开大", "宫口开大", "先露部达棘下", "先露部达棘下", "胎膜" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n4．2%盐酸利多卡因会阴阻滞麻醉，", "$$", "行左侧会阴侧术。"},
                          new string[] { "", "会阴侧切麻醉方式", "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n5．术者将吸引器大端外面涂以消毒石蜡油，左手中、食指向下撑开会阴后壁，右手持吸引器将大端下缘向下压入阴道后壁，然后左手按顺时针方向挑开阴道右侧壁、前壁及左侧壁，使大端完全滑入阴道内并与胎头顶部紧贴。" },
                           new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n6．术者一手扶持吸引器稍向内推压，使吸引器与胎头紧贴，另一手伸入阴道内检查吸引器与胎头衔接处一周，将压入吸引器口径内的阴道或宫颈组织推出，调整吸引器小端的两柄方向与矢状缝一致。" },
                          new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n7．助手将负压吸引器接于橡皮管，逐渐抽吸形成负压达", "$$", "#mmHg, 术者用血管钳夹紧橡皮结管，取下负压吸引器。" },
                         new string[] { "", "负压", "负压" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n8．助手保护会阴，术者轻轻试牵吸引器确定无漏气后，于宫缩时循产道轴方向慢慢牵拉吸引器将胎头娩出。胎头娩出后放开夹橡皮管的血管钳，恢复吸引器正压，取下吸引器，继而娩出胎肩和胎体。" },
                        new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n9．上吸引器过程顺利，牵拉", "$$", "#分钟" },
                         new string[] { "", "上吸引器牵拉时长", "上吸引器牵拉时长" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "，手术操作一次成功，新生儿出生时胎粪：", "胎>>有", "胎>>无" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "呼吸：", "呼吸>>好", "呼吸>>差" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "肌张力：", "肌张力>>好", "肌张力>>差" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "肤色：", "肤色>>红润", "肤色>>青紫","肤色>>苍白" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "早产：", "早产>>是", "早产>>否" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "Apgar评分1分钟评", "$$", "#分，5分钟评", "$$", "分，产后检查胎儿有无头皮血肿、损伤，予产妇$$","#预防产后出血。$$" },
                       new string[] { "", "Apgar评分1", "Apgar评分1", "Apgar评分2", "予", "予" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n10．胎儿娩出", "$$", "#分钟后，胎盘胎膜完整自然娩出，检查宫颈、阴道壁", "$$", "会阴切口", "$$", "切口", "$$", "。术毕，肛查直肠壁光滑，无缝线通过，手术过程顺利。产妇配合，术中出血$$", "$$", "ml，宫缩好，术毕，在产房观察2小时，产妇无特殊，车送安返回房。$$" },
                        new string[] { "", "胎儿娩出后时间", "胎儿娩出后时间", "阴道壁", "", "会阴侧切口", "", "皮肤切口号", "", "术中出血量", "" }, ref strAllText, ref strXml);
                        string strTemp = "(";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("间断"))
                                objItemContent = m_hasItems["间断"] as clsInpatMedRec_Item;
                            else if (m_hasItems.Contains("皮内"))
                                objItemContent = m_hasItems["皮内"] as clsInpatMedRec_Item;
                            if (objItemContent != null)
                                strTemp += objItemContent.m_strItemName;
                        }
                        // m_mthMakeCheckText(new string[] { "(", "切线>>间断", "切线>>皮内" }, ref strAllText, ref strXml);


                        //m_mthMakeText(new string[] { strTemp + ")缝合$$", "$$", "#针，术毕，肛查直肠壁光滑，无缝线通过。手术过程顺利。产妇配合，术中出血", "$$", "#ml，宫缩好，术毕，在产房观察2小时，产妇无特殊，车送安返回房。" },
                        // new string[] { "缝合针数", "缝合针数", "缝合针数", "术中出血量", "术中出血量" }, ref strAllText, ref strXml);
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

        /// <summary>
        /// 手术者
        /// </summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr1 = { "手术者" };
            //private string[] m_strKeysArr2 = { "记录日期" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)// && m_blnHavePrintInfo(m_strKeysArr2) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "手术者：" }, m_strKeysArr1, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("手术者：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 200, p_intPosY, p_objGrp);
                    //  p_intPosY += 20;
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
        /// 助手
        /// </summary>
        private class clsPrint9 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr1 = { "助手" };
            //private string[] m_strKeysArr2 = { "记录日期" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)// && m_blnHavePrintInfo(m_strKeysArr2) == false)
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
                            m_mthMakeText(new string[] { "助手：" }, m_strKeysArr1, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("助手：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 450, p_intPosY, p_objGrp);
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

    }
}
