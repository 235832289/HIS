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
    class clsIMR_InternalMedicineZYPrintTool : clsInpatMedRecPrintBase
    {


        /// <summary>
        /// 内科住院记录
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsIMR_InternalMedicineZYPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //构造函数

        }


        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo(),
                                                                          new clsPrint1(),
				                                                          new clsPrint2(),
                                                                          new clsPrint3(),
                                                                          new clsPrint4(),                                                                        
                                                                          new clsPrint5(),
                                                                          new clsPrint6(),
                                                                          new clsPrint7(),
                                                                         // new clsPrint8(),
                                                                          new clsPrint10(),
                                                                          new clsPrintLastDate(),
                                                                          new clsPrint11(),
                                                                          new clsPrintLastDate2()
                                                                          //new clsPrint9(),
                                                                          //new clsPrint10(),
                                                                          //new clsPrint11(),
                                                                          //new clsPrint12(),
                                                                          //new clsPrint13(),
                                                                          //new clsPrint14(false),
                                                                          //new clsPrint15(),
                                                                          //new clsPrint14(true),
                                                                          //new clsPrint16()
                                                                          
																	   });
        }


        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 40);
                p_objGrp.DrawString("内科入院记录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 370, 70);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 150, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 220, 130);
                p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, 335, 130);
                //p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strHomeplace, p_fntNormalText, Brushes.Black, 285, 130);
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, 425, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 630, 130);
                //p_intPosY = 80;
                //p_intPosY += 80;
                //p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strHomeplace, p_fntNormalText, Brushes.Black, 50, 130);
                //p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black,170, 130);
                //p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, p_fntNormalText, Brushes.Black, 255, 130);
                p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        #endregion
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        { }
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    //p_objGrp.DrawString("手术程序：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {                                                                               //, "\n二、开睑:", "缝线：$$", "开睑器：$$", "缝线固定："
                        m_mthMakeText(new string[] { "主诉：$$" },//, "", "结膜开口>>开脸>>缝线", "结膜开口>>开脸>>开脸器", "手术程序>>开睑>>缝线固定" 
                            new string[] { "内科记录I>>主诉" }, ref strAllText, ref strXml);                       
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
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("内科记录I>>现病史"))
                        objItemContent = m_hasItems["内科记录I>>现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "内科记录I>>现病史" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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
        /// 既往史，个人史，婚育史，月经史，家族史
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    //    p_objGrp.DrawString("手术程序：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeCheckText(new string[] { "既往史：传染病或慢性病史：", "内科记录I>>既往史>>传染病或慢性病>>无", "内科记录I>>既往史>>传染病或慢性病>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$", "年，患：","$$" },
                            new string[] { "内科记录I>>既往使>>年", "内科记录I>>既往使>>患病", "内科记录I>>既往使>>患病" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "，", "内科记录I>>既往史>>传染病或慢性病>>已愈", "内科记录I>>既往史>>传染病或慢性病>>未愈" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "预防接种:", "内科记录I>>既往史>>预防接种>>无" ,"内科记录I>>既往史>>预防接种>>有"}, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$" },
                         new string[] { "内科记录I>>既往使>>预防接种>>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { ",药物或食物过敏史:", "内科记录I>>既往使>>药物或食物过敏史>>无", "内科记录I>>既往使>>药物或食物过敏史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$" },
                         new string[] { "内科记录I>>既往使>>药物或食物过敏史>>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { ",外伤与手术史:", "内科记录I>>既往史>>外伤与手术史>>无", "内科记录I>>既往史>>外伤与手术史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "$$" },
                         new string[] { "", "内科记录I>>既往史>>外伤与手术史>>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { ",输血及血制品史:", "内科记录I>>既往史>>输血及血制品史>>无", "既往史>>输血及血制品史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$" },
                         new string[] { "内科记录I>>既往史>>输血及血制品史>>有记录" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "，其他：", "$$" },
                         new string[] { "", "内科记录I>>既往史>>其它" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n个人史：区居住地地方病情况:", "内科记录I>>个人史：区居住地地方病情况>无", "内科记录I>>个人史：区居住地地方病情况>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$" },
                         new string[] { "内科记录I>>个人史：区居住地地方病情况>>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "，传染病接触史:", "内科记录I>>传染病接触史>无", "内科记录I>>传染病接触史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] {  "$$" },
                         new string[] { "内科记录I>>传染病接触史>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "，不良嗜好:", "内科记录I>>不良嗜好>无", "内科记录I>>不良嗜好>>有" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] {"", "内科记录I>>不良嗜好>冶游史", "内科记录I>>不良嗜好>嗜酒", "内科记录I>>不良嗜好>嗜烟" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$", "支/日，约：","$$","年" },
                       new string[] { "内科记录I>>不良嗜好>嗜烟量", "", "内科记录I>>不良嗜好>嗜烟年数","" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "，食生鱼史:", "内科记录I>>食生鱼史>无", "内科记录I>>食生鱼史>>有" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "$$" },
                         new string[] { "内科记录I>>食生鱼史>有记录" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n婚育史:结婚年龄：", "$$","岁，配偶情况：$$" },
                        new string[] { "", "内科记录II>>婚育史>>结婚年龄>>岁数", "内科记录II>>婚育史>>结婚年龄>>配偶情况" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n月经史：", "$$" },
                      new string[] { "", "内科记录II>>月经史"}, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n家族史：父：", "内科记录II>>家族史>>父>>健在" }, ref strAllText, ref strXml);                
                        m_mthMakeCheckText(new string[] { "", "内科记录II>>家族史>>父>>已故" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "患病：", "$$" },
                      new string[] { "内科记录II>>家族史>>父>>患病", "内科记录II>>家族史>>父>>患病" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "死因：", "$$" },
                      new string[] { "内科记录II>>家族史>>父>>死因", "内科记录II>>家族史>>父>>死因" }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "母：", "内科记录II>>家族史>>母>>健在" }, ref strAllText, ref strXml);                    
                        m_mthMakeCheckText(new string[] {"", "内科记录II>>家族史>>母>>已故" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "患病：", "$$" },
                        new string[] { "内科记录II>>家族史>>母>>患病", "内科记录II>>家族史>>母>>患病" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "死因：", "$$" },
                      new string[] { "内科记录II>>家族史>>母>>死因", "内科记录II>>家族史>>母>>死因" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "兄弟姐妹：", "$$", "子女及其它：", "$$" },
                        new string[] { "", "内科记录II>>家族史>>兄弟姐妹", "", "内科记录II>>家族史>>子女及其它" }, ref strAllText, ref strXml);                     
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
        private class clsPrint4 : clsIMR_PrintLineBase
        {

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
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
                    p_objGrp.DrawString("体格检查", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "T:","$$", "℃，P：", "$$", "次/分,R：", "$$", "次/分，BP：", "$$", "/$$", "mmHg，" },
                           new string[] { "体格检查>>T", "体格检查>>T", "", "体格检查>>P", "", "体格检查>>R", "", "体格检查>>BP1", "体格检查>>BP2", "" }, ref strAllText, ref strXml);
                    
                        m_mthMakeText(new string[] { "\n一般情况：", "神志:$$", " 体位:$$" ,"发育:$$","营养:$$","面容:$$"},
                           new string[] { "", "体格检查>>一般情况>>神志", "体格检查>>一般情况>>体位", "体格检查>>一般情况>>发育", "体格检查>>一般情况>>营养", "体格检查>>一般情况>>面容"}, ref strAllText, ref strXml);
                        
                        m_mthMakeText(new string[] { "\n皮肤黏膜：", "紫绀:$$", " 黄染:$$", "苍白:$$", "出血点及部位:$$" },                                               
                          new string[] { "", "体格检查>>皮肤黏膜>>紫绀", "体格检查>>皮肤黏膜>>黄染", "体格检查>>皮肤黏膜>>苍白", "体格检查>>皮肤黏膜>>出血点及部位" }, ref strAllText, ref strXml);

                         m_mthMakeCheckText(new string[] { "\n淋巴结：全身表浅淋巴结:", "淋巴结>>无肿大" ,"淋巴结>>肿大"}, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { " 部位及体征:", "$$" },
                         new string[] { "", "淋巴结>>肿大>>部位及体征" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n头部：", "头颅:$$", " 眼:$$", "瞳孔:$$", "耳:$$", "鼻:$$", "唇:$$", "咽:$$", "舌:$$", "齿:$$", "扁桃体:$$" },
                         new string[] { "", "体格检查>>头部>>头颅", "体格检查>>头部>>眼", "体格检查>>头部>>瞳孔", "体格检查>>头部>>耳", "体格检查>>头部>>鼻子", "体格检查>>头部>>唇", "体格检查>>头部>>咽", "体格检查>>头部>>舌", "体格检查>>头部>>齿", "体格检查>>头部>>扁桃体" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n颈部：", "气管:$$", "颈抵抗:$$", "静脉怒张:$$", "肝颈征:$$", "颈动脉搏动:$$", "血管杂音:$$", "甲状腺:$$" },
                       new string[] { "", "体格检查>>颈部>>气管", "体格检查>>颈部>>颈抵抗", "体格检查>>颈部>>静脉怒张", "体格检查>>颈部>>肝颈征", "体格检查>>颈部>>动脉搏动", "体格检查>>颈部>>血管杂音", "体格检查>>颈部>>甲状腺"}, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "\n胸部:胸廓:", "体格检查>>胸部>>正常", "体格检查>>胸部>>桶状", "体格检查>>胸部>>扁平", "体格检查>>胸部>>漏斗胸", "体格检查>>胸部>>鸡胸", "体格检查>>胸部>>肋串珠" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "肺:$$", "心:$$", "其他:$$" },
                       new string[] { "体格检查>>胸部>>肺", "体格检查>>胸部>>心", "体格检查>>胸部>>其他" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n腹部：", "腹形:$$", " 柔软度:$$", "压痛:$$", "反跳痛:$$", "腹水征:$$", "肝:$$", "胆囊:$$", "脾:$$", "肾:$$", "输尿官:$$", "包块:$$", "腹部血管动脉:$$", "血管杂音:$$", "肠鸣音:$$", "其他:$$", "\n肛门及外生殖器：", "$$" },
                         new string[] { "", "体格检查>>腹部>>腹形", "体格检查>>腹部>>柔软度", "体格检查>>腹部>>压痛", "体格检查>>腹部>>反跳痛", "体格检查>>腹部>>腹水征", "体格检查>>腹部>>肝", "体格检查>>腹部>>胆囊", "体格检查>>腹部>>脾", "体格检查>>腹部>>肾", "体格检查>>腹部>>输尿官", "体格检查>>腹部>>包块", "体格检查>>腹部>>腹部血管动脉", "体格检查>>腹部>>血管杂音","体格检查>>腹部>>肠鸣音" ,"体格检查>>腹部>>其他","","体格检查II>>肛门及外生殖器"}, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n脊柱：", "$$", " 关节:$$", "\n四肢:畸形:$$", "杵状指/趾:$$", "下肢浮肿:$$", "肌张力:$$", "肌力:$$" },
                           new string[] { "", "体格检查II>>脊柱", "体格检查II>>关节", "体格检查II>>四肢>>畸形", "体格检查II>>杵状指/趾", "体格检查II>>下肢浮肿", "体格检查II>>肌张力", "体格检查II>>四肢>>肌力" }, ref strAllText, ref strXml);
                        
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 40, m_intRecBaseX + 40, p_intPosY, p_objGrp);
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
        /// 神经反射
        /// </summary>
        /// 
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("体格检查II>>神经反射"))
                        objItemContent = m_hasItems["体格检查II>>神经反射"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("神经反射：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "体格检查II>>神经反射" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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
                if (m_hasItems != null)
                    if (m_hasItems.Contains("体格检查III>>辅助检查"))
                        objItemContent = m_hasItems["体格检查III>>辅助检查"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("辅助检查：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "体格检查III>>辅助检查" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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
                if (m_hasItems != null)
                    if (m_hasItems.Contains("体格检查III>>诊断"))
                        objItemContent = m_hasItems["体格检查III>>诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("诊断：", new Font("宋体", 11, FontStyle.Regular), Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        m_mthMakeText(new string[] { "" }, new string[] { "体格检查III>>诊断" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 85, p_intPosY, p_objGrp);
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
        /// 记录者-日期
        /// </summary>
        private class clsPrint8 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                string strReport = "";
                for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                {
                    if (m_objContent.objSignerArr[i].controlName == "m_txtSign")
                    {
                        strReport = m_objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR;
                        break;
                    }
                }
                p_intPosY += 20;
                p_objGrp.DrawString("记录者：" + strReport, p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("日期：" + m_objContent.m_dtmCreateDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                // p_intPosY = 150;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }



        #region 住院医师及日期

        //private class clsPrint10 : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
        //    /// <summary>
        //    /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        //    /// </summary>
        //    private bool m_blnIsFirstPrint = true;
        //    private clsInpatMedRec_Item objItemContent = null;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_objContent == null || m_objContent.m_objItemContents == null)
        //        {
        //            m_blnHaveMoreLine = false;
        //            return;
        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            string strHelpers = " ";
        //            string strAllText = " ";
        //            string strXml = "";
        //            for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
        //            {
        //                if (m_objContent.objSignerArr[i].controlName == "m_txtcboLiveDoc")
        //                    strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
        //            }
        //            if (strHelpers != "")
        //            {
        //                p_objGrp.DrawString("住院医师：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);

        //                string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
        //                m_mthMakeText(new string[] { strHelpers }, new string[] { "" }, ref strAllText, ref strXml);
        //            }
        //            else
        //            {
        //                m_blnHaveMoreLine = false;
        //                return;
        //            }
        //            m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
        //            m_blnIsFirstPrint = false;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 320, p_intPosY, p_objGrp);
        //            //p_intPosY += 20;
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
                    string m_strPrint = "住院医师：";
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("住院医师签名"))
                            m_strPrint += (m_hasItems["住院医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvhelpers")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                    //else
                    //{
                    //    m_blnHaveMoreLine = false;
                    //    return;
                    //}
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_blnIsFirstPrint = false;
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        private class clsPrintLastDate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strPrint = "日期：";
                if (m_hasItems != null)
                    if (m_hasItems.Contains("住院医师签名日期"))
                        m_strPrint += (m_hasItems["住院医师签名日期"] as clsInpatMedRec_Item).m_strItemContent;

                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                    p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                //    p_intPosY += 20;

                //    intLine++;
                //}

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }


        #endregion

        #region 打印主治医师
        /// <summary>
        /// 主治医师签名
        /// </summary>
        private class clsPrint11 : clsIMR_PrintLineBase
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
                    string m_strPrint = "主治医师：";
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("主治医师签名"))
                            m_strPrint += (m_hasItems["主治医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //p_intPosY += 20;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvhelpers")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                    //else
                    //{
                    //    m_blnHaveMoreLine = false;
                    //    return;
                    //}
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_blnIsFirstPrint = false;
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        private class clsPrintLastDate2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strPrint = "日期：";
                if (m_hasItems != null)
                    if (m_hasItems.Contains("主治医师签名日期"))
                        m_strPrint += (m_hasItems["主治医师签名日期"] as clsInpatMedRec_Item).m_strItemContent;

                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                    //  p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                //    p_intPosY += 20;

                //    intLine++;
                //}

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}

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
