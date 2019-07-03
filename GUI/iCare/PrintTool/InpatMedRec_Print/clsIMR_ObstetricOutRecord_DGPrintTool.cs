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
    public class clsIMR_ObstetricOutRecord_DGPrintTool : clsInpatMedRecPrintBase
    {

         /// <summary>
        /// 产科出院记录(东莞)
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_ObstetricOutRecord_DGPrintTool(string p_strTypeID)
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
                                                                          new clsPrint3(),                                                                        
                                                                          new clsPrint4(),
                                                                          //new clsPrint5(),
                                                                          //new clsPrint6(),
                                                                          //new clsPrint7(),
                                                                          //new clsPrint8(),
                                                                          //new clsPrint9(),
                                                                          //new clsPrint10(),
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
                p_objGrp.DrawString("产科出院记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 350, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                //p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, 350, 130);
                p_objGrp.DrawString("住院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToShortDateString(), p_fntNormalText, Brushes.Black, 520, 130);
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
        /// 出院记录1
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
                        m_mthMakeText(new string[] { "出院日期：", "$$", "共住院", "$$","#天" },
                         new string[] { "", "记录I>>出院日期", "", "记录I>>住院天数", "记录I>>住院天数" }, ref strAllText, ref strXml);
                                     
                        m_mthMakeText(new string[] { "\n入院情况：孕：", "$$", "#次，产：", "$$", "宫内妊娠：", "$$","#周" },
                            new string[] { "", "记录I>>入院情况>>孕", "记录I>>入院情况>>孕", "记录I>>入院情况>>产","", "记录I>>入院情况>>妊娠", "记录I>>入院情况>>妊娠" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n入院检查：血压：", "$$", "/$$", "#mmHg,宫底趾联上：", "$$", "#cm,先露：", "$$", "胎方位：", "$$","胎心：","$$","宫口开：","$$","#cm" },
                            new string[] { "", "记录I>>入院检查>>血压1", "记录I>>入院检查>>血压2", "记录I>>入院检查>>血压2", "记录I>>入院检查>>趾连上", "记录I>>入院检查>>趾连上", "记录I>>入院检查>>先露", "", "记录I>>入院检查>>胎方位", "","记录I>>入院检查>>胎心","","记录I>>入院检查>>宫口开","记录I>>入院检查>>宫口开" }, ref strAllText, ref strXml);


                        m_mthMakeText(new string[] { "\n入院诊断：", "$$", "\n住院经过：于", "$$" },
                            new string[] { "", "记录I>>入院诊断", "", "记录I>>入院时间" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "记录I>>住院经过>>顺产", "记录I>>住院经过>>吸引产", "记录I>>住院经过>>钳产" ,"记录I>>住院经过>>臀产","记录I>>住院经过>>臀牵引产","记录I>>住院经过>>剖宫产"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "记录I>>住院经过>>宫下段", "记录I>>住院经过>>腹膜外", "记录I>>住院经过>>古典式" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "记录I>>住院经过>>男", "记录I>>住院经过>>女" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "活婴，Apgar评分：１分钟：", "$$", "#分，5分钟：","$$" },
                          new string[] { "", "记录I>>住院经过>>评分>>1分钟", "记录I>>住院经过>>评分>>1分钟", "记录I>>住院经过>>评分>>5分钟" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "分,胎盘娩出：", "记录I>>住院经过>>胎盘娩出>>自然", "记录I>>住院经过>>胎盘娩出>>徒手剥离", "记录I>>住院经过>>胎盘娩出>>完整", "记录I>>住院经过>>胎盘娩出>>欠完整", "记录I>>住院经过>>胎盘娩出>>植入", "记录I>>住院经过>>胎盘娩出>>残留" ,"记录I>>住院经过>>胎盘娩出>>胎膜破碎"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "会阴情况:裂伤：", "记录I>>住院经过>>会阴情况>>裂伤无", "记录I>>住院经过>>会阴情况>>裂伤1","记录I>>住院经过>>会阴情况>>裂伤2","记录I>>住院经过>>会阴情况>>裂伤3" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "切开：", "记录I>>住院经过>>切开>>直切", "记录I>>住院经过>>切开恻切" }, ref strAllText, ref strXml);
                      
                        m_mthMakeText(new string[] { "产后出血：", "$$", "#ml" },
                           new string[] { "", "记录I>>住院经过>>产后出血", "记录I>>住院经过>>产后出血" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "记录I>>住院经过>>称重法", "记录I>>住院经过>>容积法","记录I>>住院经过>>目测法" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "会阴伤口拆线：", "$$", "#针" },
                          new string[] { "", "记录I>>住院经过>>伤口拆线", "记录I>>住院经过>>伤口拆线" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "会阴腹部伤口愈合：", "记录I>>住院经过>>伤口愈合1", "记录I>>住院经过>>伤口愈合2","记录I>>住院经过>>伤口愈合3" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "类：", "记录I>>住院经过>>类甲", "记录I>>住院经过>>类乙", "记录I>>住院经过>>类丙" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n住院特殊情况：", "$$" },
                           new string[] { "", "记录I>>住院特殊情况" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n新生儿情况：", "$$", "\n新生儿情况：婴儿序号：", "$$", "性别：男", "$$", "性别：女", "$$", "体重：", "$$", "分娩结果：活产：", "$$", "死产：", "$$", "死胎：", "$$", "呼吸：自然：", "$$", "轻窒息：", "$$", "重窒息：", "$$", "转归：死亡：", "$$", "转出：", "$$", "出院：", "$$", "院内感染：", "$$", "主要院内感染名称：", "$$", "抢救次数：", "$$", "抢救成功：", "$$" },
                           new string[] { "","记录II>>新生儿情况", "", "记录II>>新生儿情况>>序号", "", "记录II>>新生儿情况>>男", "", "记录II>>新生儿情况>>女", "", "记录II>>新生儿情况>>体重", "", "记录II>>新生儿情况>>活产", "", "记录II>>新生儿情况>>死产", "", "记录II>>新生儿情况>>死胎", "", "记录II>>新生儿情况>>自然", "", "记录II>>新生儿情况>>轻窒息", "", "记录II>>新生儿情况>>重窒息", "", "记录II>>新生儿情况>>死亡", "", "记录II>>新生儿情况>>转出", "", "记录II>>新生儿情况>>出院", "", "记录II>>新生儿情况>>院内感染", "", "记录II>>新生儿情况>>感染名称", "", "记录II>>新生儿情况>>抢救次数", "", "记录II>>新生儿情况>>抢救成功" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n出院情况：母婴健康出院，其他：", "$$" },
                        new string[] { "", "记录II>>出院情况>>其他" }, ref strAllText, ref strXml);


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
        /// 出院诊断
        /// </summary>     
        private class clsPrint3 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("记录II>>出院诊断"))
                        objItemContent = m_hasItems["记录II>>出院诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("出院诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "记录II>>出院诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 60, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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



        private class clsPrint4 : clsIMR_PrintLineBase
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
                        m_mthMakeText(new string[] { "出院医嘱：", "$$" },
                            new string[] { "", "记录II>>出院医嘱" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n1、产后42天到门诊检查。\n2、注意产褥期营养卫生。\n3、母乳喂养。\n4、不适随诊。" },
                           new string[] { "" }, ref strAllText, ref strXml);      
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











    }
}
