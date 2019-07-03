using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.controls;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 产科出院记录打印类（伦教）
    /// </summary>
    public class clsIMR_ObstetricOutHosptialPrintTool_LJ : clsInpatMedRecPrintBase
    {
        /// <summary>
        /// 产科出院记录打印类构造函数
        /// </summary>
        /// <param name="p_strTypeId"></param>
        public clsIMR_ObstetricOutHosptialPrintTool_LJ(string p_strTypeId)
            : base(p_strTypeId)
        {
            m_strChildTitleName = "产科出院记录";
        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { 
                //new clsPrintTitleInfo(),
                new clsPrintBaseInfo(),
                new clsPrintOutDiagnose(),
                new clsPrintBirthedRecord() });
        }

        #region 打印类
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintTitleInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotItemHead, Brushes.Black, 340, 60);
                p_objGrp.DrawString("产科出院记录", new Font("SimSun", 18, FontStyle.Bold), Brushes.Black, 350, 90);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, 50, 130);
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, 170, 130);
                p_objGrp.DrawString("年龄：" + m_objPrintInfo.m_strAge, p_fntNormalText, Brushes.Black, 255, 130);
                //p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, 350, 130);
                p_objGrp.DrawString("住院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToShortDateString(), p_fntNormalText, Brushes.Black, 520, 130);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 680, 130);
                p_intPosY = 160;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 打印基本信息
        /// </summary>
        internal class clsPrintBaseInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
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
                        m_mthMakeText(new string[] { "住院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToShortDateString() + "，   出院日期：", "$$", "共住院", "$$", "#天；  第", "$$", "#孕 ", "$$", "#产，宫内妊娠",
                                                     "$$", "#周， 于 ", "$$", "#分娩", "\n入院、住院、治疗情况：", "\n分娩方式：" },
                         new string[] { "", "基本信息>>出院时间", "", "基本信息>>住院天数", "基本信息>>住院天数", "基本信息>>第几孕", "基本信息>>第几孕", "基本信息>>第几产", "基本信息>>第几产",
                                        "基本信息>>宫内妊娠几周", "基本信息>>宫内妊娠几周", "基本信息>>分娩日期", "基本信息>>分娩日期", "", ""  }, ref strAllText, ref strXml);

                        m_mthMakeCheckText(new string[] { "", "基本信息>>分娩方式>>顺产", "基本信息>>分娩方式>>臂牵引", "基本信息>>分娩方式>>臂助产", "基本信息>>分娩方式>>钳产", "基本信息>>分娩方式>>吸引产", "基本信息>>分娩方式>>剖腹产", "基本信息>>分娩方式>>毁胎", "基本信息>>分娩方式>>其他" }, ref strAllText, ref strXml);

                        if (m_hasItems != null && m_hasItems.Contains("基本信息>>分娩方式>>剖腹产"))
                        {
                            m_mthMakeCheckText(new string[] { "", "基本信息>>分娩方式>>剖腹产>>宫下段", "基本信息>>分娩方式>>剖腹产>>腹膜外" }, ref strAllText, ref strXml);
                        }

                        m_mthMakeCheckText(new string[] { "\n会阴裂伤：", "基本信息>>会阴破损>>I°", "基本信息>>会阴破损>>II°", "基本信息>>会阴破损>>III°" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "  切开：", "基本信息>>切开>>直切", "基本信息>>切开>>侧切" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { " 伤口愈合：", "基本信息>>伤口愈合>>I类", "基本信息>>伤口愈合>>II类", "基本信息>>伤口愈合>>III类" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { " ", "基本信息>>伤口愈合>>甲级", "基本信息>>伤口愈合>>乙级", "基本信息>>伤口愈合>>丙级" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "\n新生儿情况：", "基本信息>>新生儿情况>>男", "基本信息>>新生儿情况>>女" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { " 体重：", "$$", "#kg", "\n出生时情况：", }, new string[] { "", "基本信息>>新生儿情况>>体重", "基本信息>>新生儿情况>>体重", "基本信息>>出生时情况" }, ref strAllText, ref strXml);
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
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(m_fontItemMidHead.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    if(m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;
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
        /// 打印出院诊断
        /// </summary>
        internal class clsPrintOutDiagnose : clsIMR_PrintLineBase
        {
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 10;
                    p_objGrp.DrawString("出院诊断：", m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    string m_strPrint = "  母：1、";
                    if (m_hasItems == null)
                        return;

                    // 第一行
                    if (m_hasItems.Contains("出院诊断>>孕"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>孕"]).m_strItemContent + "孕  ";
                    else
                        m_strPrint += "    孕  ";
                    if (m_hasItems.Contains("出院诊断>>产"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>产"]).m_strItemContent + "产  ";
                    else
                        m_strPrint += "    产  ";

                    if (m_hasItems.Contains("出院诊断>>周"))
                        m_strPrint += "胎宫内妊娠 " + ((clsInpatMedRec_Item)m_hasItems["出院诊断>>周"]).m_strItemContent + "周  ";
                    else
                        m_strPrint += "胎宫内妊娠     周  ";

                    if (m_hasItems.Contains("出院诊断>>活婴"))
                        m_strPrint += "产 " + ((clsInpatMedRec_Item)m_hasItems["出院诊断>>活婴"]).m_strItemContent + "活婴。 ";
                    else
                        m_strPrint += "产      活婴。 ";
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_strPrint = "婴儿：1、";
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("出院诊断>>婴儿１"))
                            m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>婴儿１"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX, p_intPosY - 5, m_intPatientInfoX + (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY - 5);

                    // 第二行
                    m_strPrint = "      2、";
                    if (m_hasItems.Contains("出院诊断>>母2"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>母2"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_strPrint = "   2、";
                    if (m_hasItems.Contains("出院诊断>>婴儿2"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>婴儿2"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX, p_intPosY - 5, m_intPatientInfoX + (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY - 5);

                    // 第三行
                    m_strPrint = "      3、";
                    if (m_hasItems.Contains("出院诊断>>母3"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>母3"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_strPrint = "   3、";
                    if (m_hasItems.Contains("出院诊断>>婴儿3"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>婴儿3"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX, p_intPosY - 5, m_intPatientInfoX + (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY - 5);

                    // 第四行
                    m_strPrint = "      4、";
                    if (m_hasItems.Contains("出院诊断>>母4"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>母4"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_strPrint = "   4、";
                    if (m_hasItems.Contains("出院诊断>>婴儿４"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>婴儿４"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX, p_intPosY - 5, m_intPatientInfoX + (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY - 5);

                    // 第五行
                    m_strPrint = "      5、";
                    if (m_hasItems.Contains("出院诊断>>母5"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>母5"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_strPrint = "   5、";
                    if (m_hasItems.Contains("出院诊断>>婴儿５"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>婴儿５"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX, p_intPosY - 5, m_intPatientInfoX + (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY - 5);

                    p_objGrp.DrawString("产后注意事项：  １、产后４２天到门诊检查              ３、不适随诊", m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    m_strPrint = "                ２、注意产褥期营养卫生                ４、";
                    if (m_hasItems.Contains("出院诊断>>产后注意４"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>产后注意４"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    p_objGrp.DrawString("（注：出院时将此表交产妇保存，请产妇本人持本页记录于产后42天到医院复诊)", m_fontItemMidHead, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strPrint = "医生签名：";
                    if (m_hasItems.Contains("出院诊断>>医生签名"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>医生签名"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;

                    m_strPrint = "签名日期：";
                    if (m_hasItems.Contains("出院诊断>>签名日期"))
                        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["出院诊断>>签名日期"]).m_strItemContent;
                    p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                    //m_blnHaveMoreLine = false;
                }
                m_blnHaveMoreLine = false;
            }
        }

        /// <summary>
        /// 打印产后检查记录
        /// </summary>
        internal class clsPrintBirthedRecord : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Regular);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                StringFormat m_sf = new StringFormat();
                m_sf.Alignment = StringAlignment.Center;
                m_sf.LineAlignment = StringAlignment.Center;
                RectangleF m_rtgF = new RectangleF();
                m_rtgF.X = m_intPatientInfoX;
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
                m_rtgF.Height = 40;
                p_objGrp.DrawString("产后检查记录", new Font("", 15, FontStyle.Bold), Brushes.Black, m_rtgF, m_sf);
                p_intPosY += 40;
                m_sf.Dispose();
                

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
                    string strTemp = "检查日期：";
                    if (m_objContent != null)
                    {
                        if (m_hasItems.Contains("产后检查>>检查日期2"))
                        {
                            objItemContent = m_hasItems["产后检查>>检查日期2"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent.Substring(0,10)+"。产后";
                        }
                        else strTemp += "          。产后";
                        if (m_hasItems.Contains("产后检查>>产后天"))
                        {
                            objItemContent = m_hasItems["产后检查>>产后天"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "天，恶露于产后";
                        }
                        else strTemp += "  天，恶露于产后";
                        if (m_hasItems.Contains("产后检查>>恶露天"))
                        {
                            objItemContent = m_hasItems["产后检查>>恶露天"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "天干净。血压：";
                        }
                        else strTemp += "  天干净。血压：";
                        if (m_hasItems.Contains("产后检查>>血压"))
                        {
                            objItemContent = m_hasItems["产后检查>>血压"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "mmHg，体重：";
                        }
                        else strTemp += "     mmHg，体重：";
                        if (m_hasItems.Contains("产后检查>>体重"))
                        {
                            objItemContent = m_hasItems["产后检查>>体重"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "kg。\n现在阴道分泌物情况：";
                        }
                        else strTemp += "  kg。\n现在阴道分泌物情况：";
                        if (m_hasItems.Contains("产后检查>>阴道分泌物"))
                        {
                            objItemContent = m_hasItems["产后检查>>阴道分泌物"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；母乳喂养：";
                        }
                        else strTemp += "                     ；母乳喂养：";
                        if (m_hasItems.Contains("产后检查>>母乳喂养"))
                        {
                            objItemContent = m_hasItems["产后检查>>母乳喂养"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；乳腺炎：";
                        }
                        else strTemp += "          ；乳腺炎：";
                        if (m_hasItems.Contains("产后检查>>乳腺"))
                        {
                            objItemContent = m_hasItems["产后检查>>乳腺"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；\n婴儿情况：";
                        }
                        else strTemp += "\n婴儿情况：";
                        if (m_hasItems.Contains("产后检查>>婴儿情况"))
                        {
                            objItemContent = m_hasItems["产后检查>>婴儿情况"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；腹部伤口愈合情况：";
                        }
                        else strTemp += "          ；腹部伤口愈合情况：";
                        if (m_hasItems.Contains("产后检查>>腹部情况"))
                        {
                            objItemContent = m_hasItems["产后检查>>腹部情况"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "\n妇检：外阴：";
                        }
                        else strTemp += "\n妇检：外阴：";
                        if (m_hasItems.Contains("产后检查>>妇检>>外阴"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>外阴"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；会阴伤口愈合情况：";
                        }
                        else strTemp += "                                    ；会阴伤口愈合情况：";
                        if (m_hasItems.Contains("产后检查>>妇检>>会阴情况"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>会阴情况"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "\n      盆底提托力：";
                        }
                        else strTemp += "\n      盆底提托力：";
                        if (m_hasItems.Contains("产后检查>>妇检>>盆底提托力"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>盆底提托力"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；阴道：";
                        }
                        else strTemp += "                                    ；阴道：";
                        if (m_hasItems.Contains("产后检查>>妇检>>阴道"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>阴道"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "\n      宫颈：";
                        }
                        else strTemp += "\n      宫颈：";
                        if (m_hasItems.Contains("产后检查>>妇检>>宫颈光滑"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>宫颈光滑"] as clsInpatMedRec_Item;
                            strTemp += "光滑";
                        }
                        else if (m_hasItems.Contains("产后检查>>妇检>>宫颈糜烂"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>宫颈糜烂"] as clsInpatMedRec_Item;
                            strTemp += "糜烂";
                            if (m_hasItems.Contains("产后检查>>妇检>>宫颈糜烂情况"))
                            {
                                objItemContent = m_hasItems["产后检查>>妇检>>宫颈糜烂情况"] as clsInpatMedRec_Item;
                                strTemp += "（" + objItemContent .m_strItemContent+ "）";
                            }
                        }
                        strTemp += "宫体：位置：";
                        if (m_hasItems.Contains("产后检查>>妇检>>位置"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>位置"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "，大小：";
                        }
                        else strTemp += "       ，大小：";
                        if (m_hasItems.Contains("产后检查>>妇检>>大小"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>大小"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "，硬度：";
                        }
                        else strTemp += "       ，硬度：";
                        if (m_hasItems.Contains("产后检查>>妇检>>硬度"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>硬度"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "，压痛：";
                        }
                        else strTemp += "      ，压痛：";
                        if (m_hasItems.Contains("产后检查>>妇检>>压痛"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>压痛"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "\n      附件：左：";
                        }
                        else strTemp += "\n      附件：左：";
                        if (m_hasItems.Contains("产后检查>>妇检>>附件左"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>附件左"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；右：";
                        }
                        else strTemp += "                                ；右：";
                        if (m_hasItems.Contains("产后检查>>妇检>>附件右"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>附件右"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "\n      膀胱组织：";
                        }
                        else strTemp += "\n      膀胱组织：";
                        if (m_hasItems.Contains("产后检查>>妇检>>膀胱组织"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>膀胱组织"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent + "；其他：";
                        }
                        else strTemp += "                                       ；其他：";
                        if (m_hasItems.Contains("产后检查>>妇检>>其它"))
                        {
                            objItemContent = m_hasItems["产后检查>>妇检>>其它"] as clsInpatMedRec_Item;
                            strTemp += objItemContent.m_strItemContent ;
                        }
                        m_mthMakeText(new string[] { strTemp + "\n诊断：", "$$", "\n处理：", "$$" }, new string[] { "", "产后检查>>诊断", "", "产后检查>>处理" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "检查日期：", "$$", "  产后", "天， 恶露于产后$$", "天干净。$$", "\n    血压：$$", "mmHg,体重：$$", "$$", "kg．$$" },
                        //    new string[] { "", "产后检查>>检查日期2", "产后检查>>产后天", "产后检查>>恶露天", "", "产后检查>>血压", "", "产后检查>>体重", "" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "\n现在阴道分泌物情况：", "$$", " 母乳喂养：", "$$", "乳腺炎：", "$$", "\n婴儿情况：", "$$", " 腹部伤口愈合情况：", "$$" },
                        //    new string[] { "", "产后检查>>阴道分泌物", "", "产后检查>>母乳喂养", "", "产后检查>>乳腺", "", "产后检查>>婴儿情况", "",  "产后检查>>腹部情况" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "\n妇检：外阴：", "$$", "会阴伤口愈合情况：", "$$", "\n      盆底提托力：", "$$", "  阴道：", "$$" }, 
                        //    new string[] { "", "产后检查>>妇检>>外阴", "", "产后检查>>妇检>>会阴情况", "", "产后检查>>妇检>>盆底提托力", "", "产后检查>>妇检>>阴道" }, ref strAllText, ref strXml);

                        //m_mthMakeCheckText(new string[] { "\n      宫颈：", "产后检查>>妇检>>宫颈光滑", "产后检查>>妇检>>宫颈糜烂" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "$$", "\n      宫体：位置：", "$$", " 大小：", "$$", " 硬度：", "$$", " 压痛：", "$$", "\n      附件：左：", "$$", "  右：", "$$", "\n      膀胱组织：", "$$", "  其它：", "$$", "\n诊 断： ", "$$", "\n处 理： ", "$$" },
                        //    new string[] { "产后检查>>妇检>>宫颈糜烂情况", "", "产后检查>>妇检>>位置", "", "产后检查>>妇检>>大小", "", "产后检查>>妇检>>硬度", "", "产后检查>>妇检>>压痛", "", "产后检查>>妇检>>附件左", "", "产后检查>>妇检>>附件右", "", "产后检查>>妇检>>膀胱组织", "", "产后检查>>妇检>>其它", "", "产后检查>>诊断", "", "产后检查>>处理" }, ref strAllText, ref strXml);
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
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(m_fontItemMidHead.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    if (m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;

                    if (m_hasItems != null)
                    {
                        string m_strPrint;
                        m_strPrint = "医生签名：";
                        if (m_hasItems.Contains("产后检查>>医生签名"))
                            m_strPrint += ((clsInpatMedRec_Item)m_hasItems["产后检查>>医生签名"]).m_strItemContent;
                        p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                        p_intPosY += 25;

                        m_strPrint = "签名日期：";
                        if (m_hasItems.Contains("产后检查>>签名日期2"))
                            m_strPrint += ((clsInpatMedRec_Item)m_hasItems["产后检查>>签名日期2"]).m_strItemContent;
                        p_objGrp.DrawString(m_strPrint, m_fontItemMidHead, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                        p_intPosY += 25;
                    }
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
