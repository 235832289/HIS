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
    public class clsIMR_DeliverRecordPrintTool : clsInpatMedRecPrintBase
    {
        /// <summary>
        /// 分娩记录
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_DeliverRecordPrintTool(string p_strTypeID)
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
                                                                          new clsPrint5(),
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                          new clsPrint8(),
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
                p_objGrp.DrawString("分娩记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 350, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, 370, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 600, 130);
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
        /// 出院记录
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
                        m_mthMakeText(new string[] { "孕/产次：", "$$" ,"孕周：","$$"},
                        new string[] { "", "分娩记录I>>孕产次", "", "分娩记录I>>孕周" }, ref strAllText, ref strXml);
  
                        m_mthMakeText(new string[] { "\n临产时间：", "$$","#年", "$$","#月", "$$","#日","$$","#时","$$","#分" },
                            new string[] { "", "分娩记录I>>临产时间>>年", "分娩记录I>>临产时间>>月", "分娩记录I>>临产时间>>月", "分娩记录I>>临产时间>>日", "分娩记录I>>临产时间>>日", "分娩记录I>>临产时间>>时", "分娩记录I>>临产时间>>时", "分娩记录I>>临产时间>>分", "分娩记录I>>临产时间>>分", "分娩记录I>>临产时间>>分" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n胎膜破裂时间：", "$$", "#年", "$$", "#月", "$$", "#日", "$$", "#时", "$$", "#分" },
                            new string[] { "", "分娩记录I>>胎膜破裂时间>>年", "分娩记录I>>胎膜破裂时间>>月", "分娩记录I>>胎膜破裂时间>>月", "分娩记录I>>胎膜破裂时间>>日", "分娩记录I>>胎膜破裂时间>>日", "分娩记录I>>胎膜破裂时间>>时", "分娩记录I>>胎膜破裂时间>>时", "分娩记录I>>胎膜破裂时间>>分", "分娩记录I>>胎膜破裂时间>>分", "分娩记录I>>胎膜破裂时间>>分" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "分娩记录I>>临产时间>>自然", "分娩记录I>>临产时间>>人工" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "前羊水性状：", "$$", "前羊水量：", "$$", "#ml " },
                          new string[] { "", "分娩记录I>>临产时间>>前羊水性状", "", "分娩记录I>>临产时间>>前羊水量", "分娩记录I>>临产时间>>前羊水量" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n宫口开全时间：", "$$", "#年", "$$", "#月", "$$", "#日", "$$", "#时", "$$", "#分" },
                          new string[] { "", "分娩记录I>>宫口开全时间>>年", "分娩记录I>>宫口开全时间>>月", "分娩记录I>>宫口开全时间>>月", "分娩记录I>>宫口开全时间>>日", "分娩记录I>>宫口开全时间>>日", "分娩记录I>>宫口开全时间>>时", "分娩记录I>>宫口开全时间>>时", "分娩记录I>>宫口开全时间>>分", "分娩记录I>>宫口开全时间>>分", "分娩记录I>>宫口开全时间>>分" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n胎儿娩出时间：", "$$", "#年", "$$", "#月", "$$", "#日", "$$", "#时", "$$", "#分" },
                         new string[] { "", "分娩记录I>>胎儿娩出时间>>年", "分娩记录I>>胎儿娩出时间>>月", "分娩记录I>>胎儿娩出时间>>月", "分娩记录I>>胎儿娩出时间>>日", "分娩记录I>>胎儿娩出时间>>日", "分娩记录I>>胎儿娩出时间>>时", "分娩记录I>>胎儿娩出时间>>时", "分娩记录I>>胎儿娩出时间>>分", "分娩记录I>>胎儿娩出时间>>分", "分娩记录I>>胎儿娩出时间>>分" }, ref strAllText, ref strXml);
                        
                        m_mthMakeCheckText(new string[] { "\n胎儿娩出方式：", "分娩记录I>>胎儿娩出方式>>顺产", "分娩记录I>>胎儿娩出方式>>吸引产", "分娩记录I>>胎儿娩出方式>>钳产", "分娩记录I>>胎儿娩出方式>>剖宫产", "分娩记录I>>胎儿娩出方式>>助臀产" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "分娩记录I>>胎儿娩出方式>>助产", "分娩记录I>>胎儿娩出方式>>牵引" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "胎立位：", "$$", "\n胎盘娩出时间：", "$$", "#年", "$$", "#月", "$$", "#日", "$$", "#时", "$$", "#分" },
                         new string[] { "", "分娩记录I>>胎儿娩出方式>>胎立位", "", "分娩记录I>>胎盘娩出时间>>年", "分娩记录I>>胎盘娩出时间>>月", "分娩记录I>>胎盘娩出时间>>月", "分娩记录I>>胎盘娩出时间>>日", "分娩记录I>>胎盘娩出时间>>日", "分娩记录I>>胎盘娩出时间>>时", "分娩记录I>>胎盘娩出时间>>时", "分娩记录I>>胎盘娩出时间>>分", "分娩记录I>>胎盘娩出时间>>分", "分娩记录I>>胎盘娩出时间>>分" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "分娩记录I>>胎盘娩出时间>>子面", "分娩记录I>>胎盘娩出时间>>母面", "分娩记录I>>胎盘娩出时间>>>自然", "分娩记录I>>胎盘娩出时间>>人工" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n胎儿附属器情况：胎盘完整：", "分娩记录I>>胎儿情况>>胎盘完整>>是", "分娩记录I>>胎儿情况>>胎盘完整>>否" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "体积：长：", "$$", "#cm宽：", "$$", "#cm厚：", "$$", "#cm重量：", "$$" },
                        new string[] { "", "分娩记录I>>胎儿情况>>胎盘完整>>长", "分娩记录I>>胎儿情况>>胎盘完整>>长", "分娩记录I>>胎儿情况>>胎盘完整>>宽", "分娩记录I>>胎儿情况>>胎盘完整>>宽", "分娩记录I>>胎儿情况>>胎盘完整>>厚", "分娩记录I>>胎儿情况>>胎盘完整>>厚", "分娩记录I>>胎儿情况>>胎盘完整>>重量" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "g，胎盘完整：", "分娩记录I>>胎儿情况>>胎膜完整>>是", "分娩记录I>>胎儿情况>>胎膜完整>>否" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "脐带长：", "$$" },
                        new string[] { "", "分娩记录I>>胎儿情况>>胎盘完整>>脐带长" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "脐带情况：绕", "分娩记录I>>胎儿情况>>脐带情况>>绕颈", "分娩记录I>>胎儿情况>>脐带情况>>身", "分娩记录I>>胎儿情况>>脐带情况>>足", "分娩记录I>>胎儿情况>>脐带情况>>手" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$", "#周" },
                       new string[] { "", "分娩记录I>>胎儿情况>>脐带情况>>周","分娩记录I>>胎儿情况>>脐带情况>>周" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "，", "分娩记录I>>胎儿情况>>脐带情况>>松", "分娩记录I>>胎儿情况>>脐带情况>>紧", "分娩记录I>>胎儿情况>>脐带情况>>扭转" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$", "#圈" },
                      new string[] { "", "分娩记录I>>胎儿情况>>扭转圈", "分娩记录I>>胎儿情况>>扭转圈" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "，", "分娩记录I>>胎儿情况>>脐带情况>>真结", "分娩记录I>>胎儿情况>>脐带情况>>假结" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "其他情况：", "$$", "附着：", "$$", "后羊水性质：量:", "$$", "总羊水量：", "$$", "其他情况：", "$$", "\n宫颈情况：", "$$" },
                       new string[] { "", "分娩记录I>>胎儿情况>>脐带情况>>其他情况1", "", "分娩记录I>>胎儿情况>>附着", "", "分娩记录I>>胎儿情况>>后羊水性质量", "", "分娩记录I>>总羊水量", "", "分娩记录I>>胎儿情况>>其他情况2", "", "分娩记录I>>宫颈情况" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n会阴情况：", "分娩记录I>>会阴情况>>完整", "分娩记录I>>会阴情况>>切开" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "","分娩记录I>>会阴情况>>直切", "分娩记录I>>会阴情况>>侧切" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "破裂：", "分娩记录I>>会阴情况>>破裂>>I度", "分娩记录I>>会阴情况>>破裂>>II度", "分娩记录I>>会阴情况>>破裂>>III度" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { ",外缝：", "$$","#针", "\n产后出血：产时：", "$$", "产后２小时内出血：", "$$" },
                        new string[] { "", "分娩记录I>>会阴情况>>外缝", "分娩记录I>>会阴情况>>外缝", "", "分娩记录I>>产后出血>>产时", "", "分娩记录I>>产后出血>>产后２小时内出血" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "ml，评估方法：", "分娩记录I>>产后出血>>评估方法>>称重", "分娩记录I>>产后出血>>评估方法>>聚血盆" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { ",宫缩剂：", "$$", "\n产程时间：第一程：", "$$", "时$$", "#分，第二程：", "$$", "时$$", "#分，第三程：", "$$", "时$$", "#分，总程：", "$$", "时$$", "#分" },
                        new string[] { "", "分娩记录I>>产后出血>>宫缩剂", "", "分娩记录II>>产程时间>>第一程>>时", "分娩记录II>>产程时间>>第一程>>分", "分娩记录II>>产程时间>>第一程>>分", "分娩记录II>>产程时间>>第二程>>时", "分娩记录II>>产程时间>>第二程>>分", "分娩记录II>>产程时间>>第二程>>分", "分娩记录II>>产程时间>>第三程>>时", "分娩记录II>>产程时间>>第三程>>分", "分娩记录II>>产程时间>>第三程>>分", "分娩记录II>>产程时间>>总程>>时", "分娩记录II>>产程时间>总程>>分", "分娩记录II>>产程时间>总程>>分" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n手术名称：", "$$", "手术指征：", "$$", "\n产妇情况：", "$$", "产后血压", "$$", "/ $$", "#mmHg，产后２小时产后血压", "$$", "/$$", "#mmHg，脉搏：", "$$", "#次/分，产后宫缩：", "$$", "宫底高度：", "$$" },
                        new string[] { "", "分娩记录II>>手术名称", "", "分娩记录II>>手术指征", "", "分娩记录II>>产妇情况", "", "分娩记录II>>产妇情况>>产后血压1", "分娩记录II>>产妇情况>>产后血压２", "分娩记录II>>产妇情况>>产后血压２", "分娩记录II>>产妇情况>>产后２小时产后血压１", "分娩记录II>>产妇情况>>产后２小时产后血压２", "分娩记录II>>产妇情况>>产后２小时产后血压２", "分娩记录II>>产妇情况>>脉搏", "分娩记录II>>产妇情况>>脉搏", "分娩记录II>>产妇情况>>产后宫缩", "", "分娩记录II>>产妇情况>>宫底高度" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n新生儿情况:性别：", "分娩记录II>>新生儿情况>>性别>>男", "分娩记录II>>新生儿情况>>性别>>女" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { ",出生时情况：", "分娩记录II>>新生儿情况>>出生时情况>>成熟", "分娩记录II>>新生儿情况>>出生时情况>>早产" ,"分娩记录II>>新生儿情况>>出生时情况>>活产","分娩记录II>>新生儿情况>>出生时情况>>死产","分娩记录II>>新生儿情况>>出生时情况>>死胎"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { ",呼吸：", "分娩记录II>>新生儿情况>>出生时情况>>呼吸>>自然", "分娩记录II>>新生儿情况>>出生时情况>>呼吸>>人工" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { ",新生儿窒息：", "分娩记录II>>新生儿情况>>出生时情况>>窒息>>有", "分娩记录II>>新生儿情况>>出生时情况>>窒息>>无" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "分娩记录II>>新生儿情况>>出生时情况>>窒息>>轻度", "分娩记录II>>新生儿情况>>出生时情况>>窒息>>重度" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "复苏方法：", "$$"},
                         new string[] { "", "分娩记录II>>新生儿情况>>出生时情况>>复苏方法"}, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\nApgar评分：一分钟评分：", "$$", "#分，五分钟评分：", "$$", "#分，十分钟评分：", "$$", "#分" },
                       new string[] { "", "分娩记录II>>新生儿情况>>出生时情况>>评分>>一分钟", "分娩记录II>>新生儿情况>>出生时情况>>评分>>一分钟", "分娩记录II>>新生儿情况>>出生时情况>>评分>>五分钟", "分娩记录II>>新生儿情况>>出生时情况>>评分>>五分钟", "分娩记录II>>新生儿情况>>出生时情况>>评分>>十分钟", "分娩记录II>>新生儿情况>>出生时情况>>评分>>十分钟" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "，出生体重：", "$$", "#g，身长：", "$$", "#cm，头围：", "$$", "#cm，产瘤（血肿）位置：", "$$", "大小，畸形和特殊标志：", "$$" },
                       new string[] { "", "分娩记录II>>新生儿情况>>出生时情况>>出生体重", "分娩记录II>>新生儿情况>>出生时情况>>出生体重", "分娩记录II>>新生儿情况>>出生时情况>>身长", "分娩记录II>>新生儿情况>>出生时情况>>身长", "分娩记录II>>新生儿情况>>出生时情况>>头围", "分娩记录II>>新生儿情况>>出生时情况>>头围", "分娩记录II>>新生儿情况>>出生时情况>>产溜>>位置", "", "分娩记录II>>新生儿情况>>标志" }, ref strAllText, ref strXml);

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
        /// 产后诊断
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
                    if (m_hasItems.Contains("分娩记录II>>术后诊断"))
                        objItemContent = m_hasItems["分娩记录II>>术后诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("产后诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "分娩记录II>>术后诊断" }, ref strAllText, ref strXml);
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
        /// 附注
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
                        m_mthMakeText(new string[] { "附注：", "$$" },                                               //, "", "手术经过>>断肌肉"
                            new string[] { "", "分娩记录II>>附注"}, ref strAllText, ref strXml);
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
        /// 术者
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtactions")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("术者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                    //p_intPosY += 20;
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
        private class clsPrint7 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    string strHelpers = " ";
                    string strAllText = " ";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtcboLiveDoc")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("指导者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 320, p_intPosY, p_objGrp);
                    //p_intPosY += 20;
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
        /// 护婴
        /// </summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    string strHelpers = " ";
                    string strAllText = " ";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtbabys")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("护婴者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 565, p_intPosY, p_objGrp);
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
