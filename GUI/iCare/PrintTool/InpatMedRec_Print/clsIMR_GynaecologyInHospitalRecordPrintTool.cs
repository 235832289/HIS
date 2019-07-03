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
    public class clsIMR_GynaecologyInHospitalRecordPrintTool : clsInpatMedRecPrintBase
    {
        /// <summary>
        /// 妇科入院记录
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_GynaecologyInHospitalRecordPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //构造函数

        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo("妇科入院记录",300),
                                                                         new clsPrint1(),
				                                                          new clsPrint2(),
                                                                          new clsPrint3(),
                                                                        new clsPrint4(),                                                     
                                                                          new clsPrint5(),
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                          new clsPrint8(),
                                                                          new clsPrint9(),
                                                                          new clsPrint10()
                                                                          //new clsPrint11(),
                                                                          //new clsPrint12(true),
                                                                                    
																	   });
        }



        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);
        //        p_objGrp.DrawString("妇科入院记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 350, 70);
        //        //p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
        //        //p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
        //        //p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
        //        //p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, 370, 130);
        //        //p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, 450, 130);
        //        //p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 620, 130);
        //        p_intPosY = 150;
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}


        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{ }
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}



        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
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
                        m_mthMakeText(new string[] { "主诉：", "$$" },
                        new string[] { "", "病史I>>主诉" }, ref strAllText, ref strXml);                   
                      
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
        /// 现病史
        /// </summary>    
        private class clsPrint2 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("病史II>>现病史"))
                        objItemContent = m_hasItems["病史II>>现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "病史II>>现病史" }, ref strAllText, ref strXml);
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
        /// 病史I
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
                    {
                      
                        m_mthMakeCheckText(new string[] { "既往史：传染病或慢性病史：", "病史II>>既往史>>传染或慢性病史>>无", "病史II>>既往史>>传染或慢性病史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$", "#年，患", "$$" },
                        new string[] { "", "病史II>>既往史>>传染或慢性病史年数", "病史II>>既往史>>传染或慢性病史年数", "病史II>>既往史>>传染或慢性病患病" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "病史II>>既往史>>传染或慢性病史>>已愈", "病史II>>既往史>>传染或慢性病史>>未愈" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "食物或药物过敏史：", "病史II>>既往史>>食物或药物过敏史>>无", "病史II>>既往史>>食物或药物过敏史>>有" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$" },
                       new string[] { "", "病史II>>既往史>>食物或药物过敏史值" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "外伤与手术史：", "病史II>>既往史>>外伤与手术史>>无", "病史II>>既往史>>外伤与手术史>>有" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$" },
                       new string[] { "", "病史II>>既往史>>外伤与手术史有值"}, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "输血及血制品史：", "病史II>>既往史>>输血>>无", "病史II>>既往史>>输血>>有" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$","其他：","$$" },
                       new string[] { "", "病史II>>既往史>>输血有值","","病史II>>既往史>>其他" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n月经史：初潮年龄：", "$$", "#岁，周期：", "$$", "#天，经期：", "$$", "#天" },
                       new string[] { "", "病史I>>月经史>>初潮年龄", "病史I>>月经史>>初潮年龄", "病史I>>月经史>>周期", "病史I>>月经史>>周期", "病史I>>月经史>>经期", "病史I>>月经史>>经期" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "经量：", "病史I>>月经史>>经量>>多", "病史I>>月经史>>经量>>少","病史I>>月经史>>经量>>中等" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "色：", "$$" },
                      new string[] { "", "病史I>>月经史>>色" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "血块：", "病史I>>月经史>>血块>>无", "病史I>>月经史>>血块>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "痛经：", "病史I>>月经史>>痛经>>无", "病史I>>月经史>>痛经>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "程度：", "病史I>>月经史>>程度>>轻", "病史I>>月经史>>程度>>中","病史I>>月经史>>程度>>重" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "时间：", "病史I>>月经史>>时间>>经前", "病史I>>月经史>>时间>>经期","病史I>>月经史>>时间>>经后" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "绝经：", "$$", "#年，LMP：", "$$", "PMP：", "$$" },
                     new string[] { "", "病史I>>月经史>>时间绝经", "病史I>>月经史>>时间绝经", "病史I>>月经史>>LMP","","病史I>>月经史>>PMP" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "白带：量：", "病史I>>月经史>>白带>>多", "病史I>>月经史>>白带>>少","病史I>>月经史>>白带>>平常" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "异味：", "病史I>>月经史>>异味>>无", "病史I>>月经史>>异味>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "其他：", "$$" },
                      new string[] { "", "病史I>>月经史>>其他" }, ref strAllText, ref strXml);                   

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
        /// 病史II
        /// </summary>
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
                    {
                        m_mthMakeCheckText(new string[] { "婚姻史：", "病史II>>婚姻史>>未婚", "病史II>>婚姻史>>已婚" ,"病史II>>再婚","病史II>>离婚","病史II>>丧偶"}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "性生活：", "病史II>>婚姻史>>性生活>>有", "病史II>>婚姻史>>性生活>>无" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "结婚年龄：", "$$","#岁" },
                      new string[] { "病史II>>婚姻史>>结婚年龄", "病史II>>婚姻史>>结婚年龄", "病史II>>婚姻史>>结婚年龄" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "病史II>>再婚>>本人", "病史II>>再婚>>配偶" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "再婚年龄：", "$$", "#岁", "健康状况：", "$$" },
                     new string[] { "病史II>>再婚年龄", "病史II>>再婚年龄", "病史II>>再婚年龄","病史II>>健康状况","病史II>>健康状况" }, ref strAllText, ref strXml);
                     

                        m_mthMakeText(new string[] { "\n生育史：孕：", "$$", "产：", "$$", "足月产：", "$$", "#次，早产：", "$$", "#次，自然流产：", "$$", "#次，人流：", "$$", "#次，宫外孕：", "$$" },
                        new string[] { "", "病史II>>生育史>>孕", "", "病史II>>生育史>>产", "", "病史II>>生育史>>足月产", "病史II>>生育史>>足月产", "病史II>>生育史>>早产", "病史II>>生育史>>早产", "病史II>>生育史>>自然流产", "病史II>>生育史>>自然流产", "病史II>>生育史>>人流", "病史II>>生育史>>人流", "病史II>>生育史>>宫外孕" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "难产：", "病史II>>生育史>>难产>>无", "病史II>>生育史>>难产>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "病史II>>生育史>>难产>>臀位", "病史II>>生育史>>难产>>吸引产","病史II>>生育史>>难产>>钳产","病史II>>生育史>>难产>>剖宫产" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$", "其他：", "$$", "现有子：", "$$", "现有女：", "$$", "末次妊娠时间：", "$$", "末次分娩时间：", "$$" },
                       new string[] { "", "病史II>>生育史>>难产>>剖宫产次", "", "病史II>>生育史>>其他", "", "病史II>>生育史>>现有子", "", "病史II>>生育史>>现有女","","病史II>>生育史>>末次妊娠时间","","病史II>>生育史>>末次分娩时间" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "避孕措施：", "病史II>>生育史>>避孕措施>>上环", "病史II>>生育史>>避孕措施>>药物" ,"病史II>>生育史>>避孕措施>>工具","病史II>>生育史>>避孕措施>>其他"}, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$","", "$$","", "$$" },
                       new string[] { "", "病史II>>生育史>>避孕措施上环种类", "", "病史II>>生育史>>避孕措施药物值", "", "病史II>>生育史>>避孕措施工具值" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n个人史：不良嗜好：", "病史II>>个人史>>不良嗜好>>无", "病史II>>个人史>>不良嗜好>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "病史II>>个人史>>不良嗜好有>>冶游史", "病史II>>个人史>>不良嗜好有>>嗜酒", "病史II>>个人史>>不良嗜好有>>嗜烟" }, ref strAllText, ref strXml);
                       m_mthMakeText(new string[] { "", "$$", "#支／日，约：", "$$","#年" },
                       new string[] { "", "病史II>>个人史>>不良嗜好有烟量", "病史II>>个人史>>不良嗜好有烟量", "病史II>>个人史>>不良嗜好有烟龄", "病史II>>个人史>>不良嗜好有烟龄" }, ref strAllText, ref strXml);

                       m_mthMakeCheckText(new string[] { "传染病接触史：", "病史II>>个人史>>传染病接触史>>无", "病史II>>个人史>>传染病接触史>>有" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "毒物接触史：", "病史II>>个人史>>毒物接触史>>无", "病史II>>个人史>>毒物接触史>>有" }, ref strAllText, ref strXml);

                       m_mthMakeCheckText(new string[] { "\n家族史：父：", "病史II>>家族史>>父>>健在", "病史II>>家族史>>父>>已故" }, ref strAllText, ref strXml);
                       m_mthMakeText(new string[] { "患病：", "$$", "死因：", "$$" },
                        new string[] { "病史II>>家族史>>父患病", "病史II>>家族史>>父患病", "病史II>>家族史>>父已故死因", "病史II>>家族史>>父已故死因" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "母：", "病史II>>家族史>>母>>健在", "病史II>>家族史>>母>>已故" }, ref strAllText, ref strXml);

                       m_mthMakeText(new string[] { "患病：", "$$", "死因：", "$$" },
                        new string[] { "病史II>>家族史>>母患病", "病史II>>家族史>>母患病", "病史II>>家族史>>母已故死因", "病史II>>家族史>>母已故死因" }, ref strAllText, ref strXml);
                       m_mthMakeText(new string[] { "兄弟姐妹：", "$$", "子女及其他：", "$$" },
                     new string[] { "", "病史II>>家族史>>兄弟姐妹", "", "病史II>>家族史>>子女及其他" }, ref strAllText, ref strXml);
                        
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
        /// 体格检查
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
                    {
                        m_mthMakeText(new string[] { "体格检查：T：", "$$", "#℃，P：", "$$", "#次/分，BP：", "$$", "#mmHg，WT：", "$$", "#kg" },
                        new string[] { "", "体格检查>>T", "体格检查>>T", "体格检查>>P", "体格检查>>P", "体格检查>>BP", "体格检查>>BP", "体格检查>>WT", "体格检查>>WT" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n一般情况：神志：", "$$", "体位：", "$$", "发育：", "$$", "营养：", "$$", "面容：", "$$" },
                       new string[] { "", "体格检查>>一般情况>>神志", "", "体格检查>>一般情况>>体味", "", "体格检查>>一般情况>>发育", "", "体格检查>>一般情况>>营养", "", "体格检查>>一般情况>>面容" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n皮肤粘膜：紫绀：", "$$", "黄染：", "$$", "苍白：", "$$", "出血点及部位：", "$$" },
                       new string[] { "", "体格检查>>皮肤粘膜>>紫绀", "", "体格检查>>皮肤粘膜>>黄染", "", "体格检查>>皮肤粘膜>>苍白", "", "体格检查>>皮肤粘膜>>出血部位" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n淋巴结：全身表浅淋巴结：", "体格检查>>淋巴结>>无肿大", "体格检查>>淋巴结>>肿大" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "部位及特征：", "$$"},
                        new string[] { "", "体格检查>>淋巴结>>部位" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n头部：头颅：", "$$", "眼：", "$$", "瞳孔：", "$$", "耳：", "$$", "鼻：", "$$", "唇：", "$$", "咽：", "$$", "舌：", "$$", "齿：", "$$", "扁桃体：", "$$" },
                         new string[] { "", "体格检查>>头部>>头颅", "", "体格检查>>头部>>眼", "", "体格检查>>头部>>瞳孔", "", "体格检查>>头部>>耳", "", "体格检查>>头部>>鼻", "", "体格检查>>头部>>唇", "", "体格检查>>头部>>咽", "", "体格检查>>头部>>舌", "体格检查>>头部>>齿", "", "体格检查>>头部>>扁桃体" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n颈部：气管：", "$$", "死因：", "$$", "颈静脉怒张：", "$$", "肝颈征：", "$$", "颈动脉搏动：", "$$", "血管杂音：", "$$", "甲状腺：", "$$" },
                         new string[] { "", "体格检查>>颈部>>气管", "", "体格检查>>颈部>>颈抵抗", "", "体格检查>>颈部>>静脉怒张", "", "体格检查>>颈部>>肝颈征", "", "体格检查>>颈部>>动脉搏动", "", "体格检查>>颈部>>血管杂音", "", "体格检查>>颈部>>甲状腺" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n胸部：胸廓：","体格检查>>胸部>>正常","体格检查>>胸部>>桶状", "体格检查>>胸部>>扁平", "体格检查>>胸部>>漏斗胸", "体格检查>>胸部>>鸡胸", "体格检查>>胸部>>肋串珠" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "肺：", "$$", "心：", "$$", "其他：", "$$" },
                      new string[] { "", "体格检查>>胸部>>肺", "", "体格检查>>胸部>>心", "", "体格检查>>胸部>>其他" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n腹部：腹形：", "$$", "柔软度：", "$$", "压痛：", "$$", "反跳痛：", "$$", "腹水征：", "$$", "肝：", "$$", "胆囊：", "$$", "脾：", "$$", "肾：", "$$", "输尿管：", "$$", "腹部肿块：", "$$", "腹部血管搏动：", "$$", "血管杂音：", "$$", "肠鸣音：", "$$", "其他：", "$$" },
                      new string[] { "", "体格检查>>腹部>>腹形", "", "体格检查>>腹部>>柔软度", "", "体格检查>>腹部>>压痛", "", "体格检查>>腹部>>跳痛", "", "体格检查>>腹部>>腹水", "", "体格检查>>腹部>>肝", "", "体格检查>>腹部>>胆囊", "", "体格检查>>腹部>>脾", "", "体格检查>>腹部>>肾", "", "体格检查>>腹部>>输尿管", "", "体格检查>>腹部>>肿块", "", "体格检查>>腹部>>血管搏动", "", "体格检查>>腹部>>血管杂音", "", "体格检查>>腹部>>肠鸣音", "", "体格检查>>腹部>>其他" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n肛门及外生殖器：", "$$", "\n脊柱：", "$$", "关节：", "$$" },
                      new string[] { "", "体格检查>>肛门及生殖器", "", "体格检查>>脊柱", "", "体格检查>>关节" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n四肢：畸形：", "$$", "杵状指/趾：", "$$", "下肢浮肿：", "$$", "肌张力：", "$$", "肌力：", "$$", "\n神经反射：", "$$" },
                      new string[] { "", "体格检查>>四肢>>畸形", "", "体格检查>>四肢>>指", "", "体格检查>>四肢>>下肢浮肿", "", "体格检查>>四肢>>肌张力", "", "体格检查>>四肢>>肌力" ,"","体格检查>>神经反射"}, ref strAllText, ref strXml);

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
        /// 专科检查
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
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

                        m_mthMakeCheckText(new string[] { "专科检查：", "专科检查>>双合诊", "专科检查>>三合诊", "专科检查>>肛诊" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n外阴：阴毛：", "专科检查>>阴毛>>正常", "专科检查>>阴毛>>异常" }, ref strAllText, ref strXml);
                                                                    
                        m_mthMakeText(new string[] { "", "$$" },
                        new string[] { "", "专科检查>>阴毛>>异常值" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "阴缔：", "专科检查>>外阴>>阴缔>正常", "专科检查>>外阴>>阴缔>异常" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$" },
                     new string[] { "", "专科检查>>外阴>>阴缔>异常值" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n前庭大腺：", "专科检查>>外阴>>前庭大腺>正常", "专科检查>>外阴>>前庭大腺>异常" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "左：", "$$", "右：", "$$", "性状：", "$$" },
                    new string[] { "", "专科检查>>外阴>>前庭大腺>>左", "", "专科检查>>外阴>>前庭大腺>>右", "", "专科检查>>外阴>>前庭大腺>>性状" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n外阴：会阴：", "专科检查>>外阴>>会阴>正常", "专科检查>>外阴>>会阴>旧裂" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "专科检查>>外阴>>会阴>旧裂I", "专科检查>>外阴>>会阴>旧裂II","专科检查>>外阴>>会阴>旧裂III" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "尿道口：", "专科检查>>外阴>>尿道口>正常", "专科检查>>外阴>>尿道口>异常" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "生物：", "专科检查>>外阴>>生物>>无", "专科检查>>外阴>>生物>>有" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "", "$$" },
                     new string[] { "", "专科检查>>阴道>>发育>>异常值" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n阴道：发育：", "专科检查>>阴道>>发育>>正常", "专科检查>>阴道>>发育>>异常" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$" },
                     new string[] { "", "专科检查>>阴道>>发育>>异常值" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "阴道壁张力：", "专科检查>>张力>>正常", "专科检查>>张力>>膨出" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "前壁：", "专科检查>>张力>>膨出>>前壁I", "专科检查>>张力>>膨出>>前壁II","专科检查>>张力>>膨出>>前壁III" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "后壁：", "专科检查>>张力>>膨出>>后壁I", "专科检查>>张力>>膨出>>后壁II","专科检查>>张力>>膨出>>后壁III" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n粘膜：", "专科检查>>外阴>>粘膜>正常", "专科检查>>外阴>>粘膜>异常" }, ref strAllText, ref strXml);
                         m_mthMakeCheckText(new string[] { "", "专科检查>>外阴>>粘膜>异常>>充血", "专科检查>>外阴>>粘膜>异常>>出血点", "专科检查>>外阴>>粘膜>异常>>溃疡", "专科检查>>外阴>>粘膜>异常>>裂伤" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "生物：", "$$" },
                     new string[] { "", "专科检查>>外阴>>粘膜>生物" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "分泌物：", "专科检查>>分泌物>>正常", "专科检查>>分泌物>>异常" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$" },
                     new string[] { "", "专科检查>>分泌物>>异常值" }, ref strAllText, ref strXml);

                       m_mthMakeCheckText(new string[] { "异物：", "专科检查>>粘膜>>异物>>无", "专科检查>>粘膜>>异物>>有" }, ref strAllText, ref strXml);
                       m_mthMakeText(new string[] { "", "$$" },
                     new string[] { "", "专科检查>>粘膜>>异物>>有值" }, ref strAllText, ref strXml);
                      m_mthMakeCheckText(new string[] { "出血：", "专科检查>>粘膜>>出血>无", "专科检查>>粘膜>>出血>>有" }, ref strAllText, ref strXml);
 　　　　　　　　　　　m_mthMakeText(new string[] { "量：", "$$","色：", "$$","气味：", "$$" },
                     new string[] { "", "专科检查>>粘膜>>出血>>量", "", "专科检查>>粘膜>>出血>>色",  "", "专科检查>>粘膜>>出血>>气味"}, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "\n宫颈：大小：", "专科检查>>宫颈>>大小>正常", "专科检查>>宫颈>>大小>肥大", "专科检查>>宫颈>>大小>细小" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "色泽：", "$$","畸形：", "$$" },
                     new string[] { "", "专科检查>>宫颈>>色泽", "", "专科检查>>宫颈>>畸形"}, ref strAllText, ref strXml);

     　　　　　　　　　m_mthMakeCheckText(new string[] { "表面：", "专科检查>>宫颈>>表面>>光滑", "专科检查>>宫颈>>表面>>旧裂","专科检查>>宫颈>>表面>>生物", "专科检查>>宫颈>>表面>>糜烂" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "" ,"专科检查>>宫颈>>表面>>糜烂I","专科检查>>宫颈>>表面>>糜烂II", "专科检查>>宫颈>>表面>>糜烂III" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "", "专科检查>>宫颈>>表面>>外翻", "专科检查>>宫颈>>表面>>宫口闭合", "专科检查>>宫颈>>表面>>开张" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "质地：", "专科检查>>宫颈>>质地>>正常", "专科检查>>宫颈>>质地>>硬", "专科检查>>宫颈>>质地>>软" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "举痛：", "专科检查>>宫颈>>举痛>>无", "专科检查>>宫颈>>举痛>>有" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "接触性出血：", "专科检查>>宫颈>>接触性出血>>无", "专科检查>>宫颈>>接触性出血>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n宫体：大小：","专科检查>>宫体>>大小>正常", "专科检查>>宫体>>大小>细小", "专科检查>>宫体>>大小>肥大" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "","$$","缺如：","$$","位置：","$$" },
                         new string[] { "", "专科检查>>宫体>>大小>肥大值","","专科检查>>宫体>>缺如","","专科检查>>宫体>>位置" }, ref strAllText, ref strXml);
                          m_mthMakeCheckText(new string[] { "形状：","专科检查>>宫体>>形状>>正常", "专科检查>>宫体>>形状>>异常" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$","质地：", "$$","压痛：", "$$","活动度：", "$$" },
                         new string[] { "", "专科检查>>宫体>>形状>>异常值","","专科检查>>宫体>>质地","","专科检查>>宫体>>压痛","","专科检查>>宫体>>活动度" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n附件：压痛：", "专科检查>>附件>>压痛>无", " 专科检查>>附件>>压痛>有"}, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "左：", "$$", "右：", "$$" },
                      new string[] { "", "专科检查>>附件>>压痛左", "", "专科检查>>附件>压痛右" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "增厚：", "专科检查>>附件>>增厚>无", "专科检查>>附件>>增厚>有"}, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "左：", "$$", "右：", "$$", "位置：", "$$", "形状：", "$$", "大小：", "$$", "质地：", "$$", "活动度：", "$$", "边界：", "$$", "压痛：", "$$" },
                      new string[] { "", "专科检查>>附件>>增厚>左", "", "专科检查>>附件>>增厚>右" ,"","专科检查>>附件>>肿块>>位置","","专科检查>>附件>>肿块>>形状","","专科检查>>附件>>肿块>>大小","","专科检查>>附件>>肿块>>质地","","专科检查>>附件>>肿块>>活动度","","专科检查>>附件>>肿块>>边界","","专科检查>>附件>>肿块>>压痛"}, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n子宫骶韧：增粗：","专科检查>>子宫骶韧>无", "专科检查>>子宫骶韧>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "左：", "$$", "右：", "$$" },
                      new string[] { "", "专科检查>>子宫骶韧>左", "", "专科检查>>子宫骶韧>右" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "结节：","专科检查>>子宫骶韧>>结节>>无", "专科检查>>子宫骶韧>>结节>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "大小：", "$$", "质地：", "$$" },
                      new string[] { "", "专科检查>>子宫骶韧>>结节>大小", "", "专科检查>>子宫骶韧>>结节>质地" }, ref strAllText, ref strXml);
                       m_mthMakeCheckText(new string[] { "触痛：","专科检查>>子宫骶韧>>触痛>>无", "专科检查>>子宫骶韧>>触痛>>有" }, ref strAllText, ref strXml);

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
        /// 辅助检查
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
                if (m_hasItems != null)
                    if (m_hasItems.Contains("辅助检查与诊断>>检查"))
                        objItemContent = m_hasItems["辅助检查与诊断>>检查"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("辅助检查：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "辅助检查与诊断>>检查" }, ref strAllText, ref strXml);
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
        /// 诊断
        /// </summary>    
        private class clsPrint8 : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("辅助检查与诊断>>诊断"))
                        objItemContent = m_hasItems["辅助检查与诊断>>诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "辅助检查与诊断>>诊断" }, ref strAllText, ref strXml);
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
        /// 住院医师
        /// </summary>
        private class clsPrint9 : clsIMR_PrintLineBase
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
                    string strHelpers = "      ";
                    string strAllText = "      ";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtDPSman")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("住院医师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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
        /// 住院医师
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
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
                    string strHelpers = "      ";
                    string strAllText = "      ";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_txtActiondoc")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("主治医师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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






    }
}
