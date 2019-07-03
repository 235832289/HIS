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
    class clsEyeCataractPrintTool : clsInpatMedRecPrintBase
    {

        /// <summary>
        /// 白内障超声乳化摘除联合人工晶状体植入手术记录
        /// </summary>
        /// <param name="p_strTypeID"></param>
        public clsEyeCataractPrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //构造函数

        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		    new clsPrintPatientFixInfo("白内障超声乳化摘除联合人工晶状体植入手术记录",300),
                                                                            new clsPrint1(),
                                                                            new clsPrint2(),
                                                                            new clsPrint3(),
                                                                            new clsPrint4(),
                                                                            new clsPrint5()
		                                                                                    
																	   });
        }



        /// <summary>
        /// 第一页
        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
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




                        m_mthMakeText(new string[] { "手术名称：① 白内障超声乳化摘除联合人工晶状体植入手术(" },
                        new string[] { "" }, ref strAllText, ref strXml);
                        string strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>右"))
                            {
                                objItemContent = m_hasItems["手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>右"] as clsInpatMedRec_Item;
                                strTemp += " 右";
                            }
                            if (m_hasItems.Contains("手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>左"))
                            {
                                objItemContent = m_hasItems["手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>左"] as clsInpatMedRec_Item;
                                strTemp += " 左";
                            }
                        }
                        // m_mthMakeCheckText(new string[] { "(", "切线>>间断", "切线>>皮内" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { strTemp + ")； ②", "$$", "。$$" },
                        new string[] { "", "手术名称>>手术名称", "" }, ref strAllText, ref strXml);

                        //m_mthMakeCheckText(new string[] { "手术名称：① 白内障超声乳化摘除联合人工晶状体植入手术(", "手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>右", "手术名称>>白内障超声乳化摘除联合人工晶状体植入手术>>左" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { ")； ②", "$$" },
                        //new string[] { "", "手术名称>>手术名称" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n术前诊断：①(", "$$" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("术前诊断>>老年"))
                            {
                                objItemContent = m_hasItems["术前诊断>>老年"] as clsInpatMedRec_Item;
                                strTemp += " 老年";
                            }
                            else if (m_hasItems.Contains("术前诊断>>并发"))
                            {
                                objItemContent = m_hasItems["术前诊断>>并发"] as clsInpatMedRec_Item;
                                strTemp += " 并发";
                            }
                            else if (m_hasItems.Contains("术前诊断>>代谢"))
                            {
                                objItemContent = m_hasItems["术前诊断>>代谢"] as clsInpatMedRec_Item;
                                strTemp += " 代谢";
                            }
                            else if (m_hasItems.Contains("术前诊断>>外伤"))
                            {
                                objItemContent = m_hasItems["术前诊断>>外伤"] as clsInpatMedRec_Item;
                                strTemp += " 外伤";
                            }
                            else if (m_hasItems.Contains("术前诊断>>先天"))
                            {
                                objItemContent = m_hasItems["术前诊断>>先天"] as clsInpatMedRec_Item;
                                strTemp += " 先天";
                            }

                        }
                        // m_mthMakeCheckText(new string[] { "(", "切线>>间断", "切线>>皮内" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { strTemp + ")性白内障(", "$$" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("术前诊断>>右"))
                            {
                                objItemContent = m_hasItems["术前诊断>>右"] as clsInpatMedRec_Item;
                                strTemp += " 右";
                            }
                            if (m_hasItems.Contains("术前诊断>>左"))
                            {
                                objItemContent = m_hasItems["术前诊断>>左"] as clsInpatMedRec_Item;
                                strTemp += " 左";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + ")； ②", "", "。$$" },
                        new string[] { "", "术前诊断>>术前诊断", "" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "\n术前诊断：①(", "$$" },
                        //new string[] { "", "" }, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "", "术前诊断>>老年", "术前诊断>>并发", "术前诊断>>代谢", "术前诊断>>外伤", "术前诊断>>先天" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "#)性白内障(：", "$$" },
                        //new string[] { "", ""}, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "", "术前诊断>>右", "术前诊断>>左"}, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "#)； ②", "$$" },
                        //new string[] { "", "术前诊断>>术前诊断" }, ref strAllText, ref strXml);


                        m_mthMakeText(new string[] { "\n术后诊断：" },
                        new string[] { ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("术后诊断>>① 同术前"))
                            {
                                objItemContent = m_hasItems["术后诊断>>① 同术前"] as clsInpatMedRec_Item;
                                strTemp += " ① 同术前";
                            }
                            else if (m_hasItems.Contains("术后诊断>>②"))
                            {
                                objItemContent = m_hasItems["术后诊断>>②"] as clsInpatMedRec_Item;
                                strTemp += " ②";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "", "。$$" },
                        new string[] { "", "术后诊断>>术后诊断", "" }, ref strAllText, ref strXml);


                        m_mthMakeText(new string[] { "\n手术者：", "$$", "助手：", "$$" },
                        new string[] { "", "手术者", "", "助手" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n手术时间：", "$$", "至$$", "$$" },
                        new string[] { "", "手术时间>>开始时间", "", "手术时间>>结束时间" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n麻醉者：", "$$", "术者：", "$$" },
                        new string[] { "", "麻醉者", "", "术者" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n麻醉药物：" },
                        new string[] { "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("麻醉药物>>0.4%倍诺喜"))
                            {
                                objItemContent = m_hasItems["麻醉药物>>0.4%倍诺喜"] as clsInpatMedRec_Item;
                                strTemp += " ① 0.4%倍诺喜";
                            }
                            else if (m_hasItems.Contains("麻醉药物>>2%利多卡因"))
                            {
                                objItemContent = m_hasItems["麻醉药物>>2%利多卡因"] as clsInpatMedRec_Item;
                                strTemp += " ② 2%利多卡因";
                            }
                            else if (m_hasItems.Contains("麻醉药物>> 0.75%布比卡因"))
                            {
                                objItemContent = m_hasItems["麻醉药物>> 0.75%布比卡因"] as clsInpatMedRec_Item;
                                strTemp += " ③ 0.75%布比卡因";
                            }
                            else if (m_hasItems.Contains("麻醉药物>> 其他"))
                            {
                                objItemContent = m_hasItems["麻醉药物>> 其他"] as clsInpatMedRec_Item;
                                strTemp += " ④ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "", "。$$" },
                        new string[] { "", "麻醉药物>>其他药物", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n手术经过：" },
                        new string[] { "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n1：", "眼科常规消毒铺敷" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "", "眼科常规消毒铺敷>>右眼", "眼科常规消毒铺敷>>左眼" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "$$", "$$。" },
                        //new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("眼科常规消毒铺敷>>右眼"))
                            {
                                objItemContent = m_hasItems["眼科常规消毒铺敷>>右眼"] as clsInpatMedRec_Item;
                                strTemp += " 右眼";
                            }
                            if (m_hasItems.Contains("眼科常规消毒铺敷>>左眼"))
                            {
                                objItemContent = m_hasItems["眼科常规消毒铺敷>>左眼"] as clsInpatMedRec_Item;
                                strTemp += " 左眼";
                            }
                        }
                        // m_mthMakeCheckText(new string[] { "(", "切线>>间断", "切线>>皮内" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { strTemp + "", "。$$" },
                        new string[] { "", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n2：", "麻醉："},
                        new string[] { "", ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("麻醉>>① 表面麻醉"))
                            {
                                objItemContent = m_hasItems["麻醉>>① 表面麻醉"] as clsInpatMedRec_Item;
                                strTemp += " ① 表面麻醉";
                            }
                            else if (m_hasItems.Contains("麻醉>>② 结膜下浸润麻醉"))
                            {
                                objItemContent = m_hasItems["麻醉>>② 结膜下浸润麻醉"] as clsInpatMedRec_Item;
                                strTemp += " ② 结膜下浸润麻醉";
                            }
                            else if (m_hasItems.Contains("麻醉>>③麻醉"))
                            {
                                if(m_hasItems.Contains("麻醉>>③麻醉>>球后麻醉"))
                                {
                                    objItemContent = m_hasItems["麻醉>>③麻醉>>球后麻醉"] as clsInpatMedRec_Item;
                                    strTemp += " ③ 球后麻醉";
                                }
                                else if(m_hasItems.Contains("麻醉>>③麻醉>>球周麻醉"))
                                {
                                    objItemContent = m_hasItems["麻醉>>③麻醉>>球周麻醉"] as clsInpatMedRec_Item;
                                    strTemp += " ③ 球周麻醉";
                                }
                            }
                            else if (m_hasItems.Contains("麻醉>>④ 全身麻醉"))
                            {
                                objItemContent = m_hasItems["麻醉>>④ 全身麻醉"] as clsInpatMedRec_Item;
                                strTemp += " ④ 全身麻醉";
                            }
                            else if (m_hasItems.Contains("麻醉>>⑤ 其他"))
                            {
                                objItemContent = m_hasItems["麻醉>>⑤ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ⑤ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "","", "。$$" },
                        new string[] { "", "麻醉>>其他麻醉", "" }, ref strAllText, ref strXml);

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
        /// 第二页
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




                        m_mthMakeText(new string[] { "3：", "开脸：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        string strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("开脸>>开脸器"))
                            {
                                objItemContent = m_hasItems["开脸>>开脸器"] as clsInpatMedRec_Item;
                                strTemp += " 开脸器";
                            }
                            else if (m_hasItems.Contains("开脸>>缝线"))
                            {
                                objItemContent = m_hasItems["开脸>>缝线"] as clsInpatMedRec_Item;
                                strTemp += " 缝线";
                            }
                        }
                        // m_mthMakeCheckText(new string[] { "(", "切线>>间断", "切线>>皮内" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { strTemp + "。 ", "眼球固定： 上直肌缝线。" },
                        new string[] { "", ""}, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n4：", "结膜瓣：", "由角巩膜缘", "", "点至$$", "", "点剪开球结膜。$$" },
                        new string[] { "", "", "", "结膜瓣>>角巩膜缘起", "", "结膜瓣>>至剪开球结膜", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n5：", "切开：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("切开>>一次性隧道"))
                            {
                                objItemContent = m_hasItems["切开>>一次性隧道"] as clsInpatMedRec_Item;
                                strTemp += " 一次性隧道";
                            }
                            else if (m_hasItems.Contains("切开>>宝石刀"))
                            {
                                objItemContent = m_hasItems["切开>>宝石刀"] as clsInpatMedRec_Item;
                                strTemp += " 宝石刀";
                            }
                            else if (m_hasItems.Contains("切开>>钻石刀"))
                            {
                                objItemContent = m_hasItems["切开>>钻石刀"] as clsInpatMedRec_Item;
                                strTemp += " 钻石刀";
                            }
                            else if (m_hasItems.Contains("切开>>剃须刀"))
                            {
                                objItemContent = m_hasItems["切开>>剃须刀"] as clsInpatMedRec_Item;
                                strTemp += " 剃须刀";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "。 " },
                        new string[] { ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("切开>>① 透明角膜隧道切口"))
                            {
                                objItemContent = m_hasItems["切开>>① 透明角膜隧道切口"] as clsInpatMedRec_Item;
                                strTemp += " ① 透明角膜隧道切口";
                            }
                            else if (m_hasItems.Contains("切开>>② 角巩膜缘隧道切口"))
                            {
                                objItemContent = m_hasItems["切开>>② 角巩膜缘隧道切口"] as clsInpatMedRec_Item;
                                strTemp += " ② 角巩膜缘隧道切口";
                            }
                            else if (m_hasItems.Contains("切开>>③ 巩膜隧道切口"))
                            {
                                objItemContent = m_hasItems["切开>>③ 巩膜隧道切口"] as clsInpatMedRec_Item;
                                strTemp += " ③ 巩膜隧道切口";
                            }
                            else if (m_hasItems.Contains("切开>>④ 角巩膜缘斜切口"))
                            {
                                objItemContent = m_hasItems["切开>>④ 角巩膜缘斜切口"] as clsInpatMedRec_Item;
                                strTemp += " ④ 角巩膜缘斜切口";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "。 ", "方法：位于角巩膜缘前界" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("切开>>方法：位于角巩膜缘前界>>前"))
                            {
                                objItemContent = m_hasItems["切开>>方法：位于角巩膜缘前界>>前"] as clsInpatMedRec_Item;
                                strTemp += " 前";
                            }
                            else if (m_hasItems.Contains("切开>>方法：位于角巩膜缘前界>>后"))
                            {
                                objItemContent = m_hasItems["切开>>方法：位于角巩膜缘前界>>后"] as clsInpatMedRec_Item;
                                strTemp += " 后";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "约", "$$", "mm，$$", "长度：约", "$$", "mm，$$", "中点方位：", "", "点。$$" },
                        new string[] { "", "", "切开>>方法：位于角巩膜缘前界>>约", "", "", "切开>>长度", "", "", "切开>>中点方位", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n6：", "辅助切口：", "位于角巩膜缘前界前约", "$$", "mm，$$", "方位：", "$$", "点。$$" },
                        new string[] { "", "", "", "辅助切口>>前约", "", "", "辅助切口>>方位", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n7：", "前房注入粘弹剂：", "$$", "牌$$" },
                        new string[] { "", "", "前房注入粘弹剂>>牌", ""}, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "前房注入粘弹剂>>玻璃酸钠", "前房注入粘弹剂>>甲级纤维素" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "囊膜染角：" },
                        new string[] { "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("前房注入粘弹剂>>囊膜染角>>蓝域"))
                            {
                                objItemContent = m_hasItems["前房注入粘弹剂>>囊膜染角>>蓝域"] as clsInpatMedRec_Item;
                                strTemp += " 蓝域";
                            }
                            else if (m_hasItems.Contains("前房注入粘弹剂>>囊膜染角>>无"))
                            {
                                objItemContent = m_hasItems["前房注入粘弹剂>>囊膜染角>>无"] as clsInpatMedRec_Item;
                                strTemp += " 无";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "",  "。" },
                        new string[] { "", ""}, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n8：", "环形撕囊：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("环形撕囊>>针头"))
                            {
                                objItemContent = m_hasItems["环形撕囊>>针头"] as clsInpatMedRec_Item;
                                strTemp += " 针头";
                            }
                            else if (m_hasItems.Contains("环形撕囊>>撕囊镊"))
                            {
                                objItemContent = m_hasItems["环形撕囊>>撕囊镊"] as clsInpatMedRec_Item;
                                strTemp += " 撕囊镊";
                            }
                            else if (m_hasItems.Contains("环形撕囊>>电灼撕囊镊"))
                            {
                                objItemContent = m_hasItems["环形撕囊>>电灼撕囊镊"] as clsInpatMedRec_Item;
                                strTemp += " 电灼撕囊镊";
                            }
                            else if (m_hasItems.Contains("环形撕囊>>其他："))
                            {
                                objItemContent = m_hasItems["环形撕囊>>其他："] as clsInpatMedRec_Item;
                                strTemp += " 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "$$","。" },
                        new string[] { "", "环形撕囊>>其他描述", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n9：", "水分离及水分化：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("水分离及水分化>>灌注液"))
                            {
                                objItemContent = m_hasItems["水分离及水分化>>灌注液"] as clsInpatMedRec_Item;
                                strTemp += " 灌注液";
                            }
                            else if (m_hasItems.Contains("水分离及水分化>>粘弹剂"))
                            {
                                objItemContent = m_hasItems["水分离及水分化>>粘弹剂"] as clsInpatMedRec_Item;
                                strTemp += " 粘弹剂";
                            }
                         }
                        m_mthMakeText(new string[] { strTemp + "。" },
                        new string[] { "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n10：", "灌注液：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "灌注液>>必施", "灌注液>>平衡液", "灌注液>>生理盐水" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "", "灌注液含药：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("灌注液含药>>妥布霉素"))
                            {
                                objItemContent = m_hasItems["灌注液含药>>妥布霉素"] as clsInpatMedRec_Item;
                                strTemp += " 妥布霉素";
                            }
                            else if (m_hasItems.Contains("灌注液含药>>地塞米松"))
                            {
                                objItemContent = m_hasItems["灌注液含药>>地塞米松"] as clsInpatMedRec_Item;
                                strTemp += " 地塞米松";
                            }
                            else if (m_hasItems.Contains("灌注液含药>>肾上腺素"))
                            {
                                objItemContent = m_hasItems["灌注液含药>>肾上腺素"] as clsInpatMedRec_Item;
                                strTemp += " 肾上腺素";
                            }
                            else if (m_hasItems.Contains("灌注液含药>>无"))
                            {
                                objItemContent = m_hasItems["灌注液含药>>无"] as clsInpatMedRec_Item;
                                strTemp += " 无";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "。" },
                        new string[] { "" }, ref strAllText, ref strXml);


                        m_mthMakeText(new string[] { "\n11：", "超声乳化能量：", "① 最大", "$$", "%；$$", "② 最小", "$$", "%；$$", "③ 平均", "$$", "%。$$" },
                        new string[] { "", "", "", "超声乳化能量>>最大", "", "", "超声乳化能量>>最小", "", "", "超声乳化能量>>平均", "" }, ref strAllText, ref strXml);

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
        /// 第三页
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


                        m_mthMakeText(new string[] { "12：", "超声乳化时间：", "① 使用时间(FPT)", "$$", "秒；$$", "② 有效时间(EPT)", "$$", "秒。$$" },
                        new string[] { "", "", "", "超声乳化时间>>使用时间", "", "", "超声乳化时间>>有效时间", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n13：", "消除皮质：" },
                        new string[] { "", ""}, ref strAllText, ref strXml);
                        string strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("消除皮质>>① 自动I/A系统"))
                            {
                                objItemContent = m_hasItems["消除皮质>>① 自动I/A系统"] as clsInpatMedRec_Item;
                                strTemp += " ① 自动I/A系统";
                            }
                            else if (m_hasItems.Contains("消除皮质>>② 双腔管"))
                            {
                                objItemContent = m_hasItems["消除皮质>>② 双腔管"] as clsInpatMedRec_Item;
                                strTemp += " ② 双腔管";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "。$$" },
                        new string[] { "", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n14：", "前房及囊袋内注入粘弹剂同上。" },
                        new string[] { "", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n15：", "扩大隧道切口至", "$$", "mm。$$" },
                        new string[] { "", "", "扩大隧道切口至", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n16：", "植入人工晶状体：", "类型：" },
                        new string[] { "", "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("植入人工晶状体>>类型>>折叠式"))
                            {
                                objItemContent = m_hasItems["植入人工晶状体>>类型>>折叠式"] as clsInpatMedRec_Item;
                                strTemp += " 折叠式";
                            }
                            else if (m_hasItems.Contains("植入人工晶状体>>类型>>硬性"))
                            {
                                objItemContent = m_hasItems["植入人工晶状体>>类型>>硬性"] as clsInpatMedRec_Item;
                                strTemp += " 硬性";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "；   品牌：", "$$", "；   屈光度：$$", "$$", "D$$", "；   光学直径：", "$$", "mm；$$", "   型号：", "$$", "。$$" },
                        new string[] { "", "", "植入人工晶状体>>品牌", "", "植入人工晶状体>>屈光度", "", "", "植入人工晶状体>>光学直径", "", "", "植入人工晶状体>>型号","" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n17：", "植入方式："},
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("植入方式>>① 植入镊"))
                            {
                                objItemContent = m_hasItems["植入方式>>① 植入镊"] as clsInpatMedRec_Item;
                                strTemp += " ① 植入镊";
                            }
                            else if (m_hasItems.Contains("植入方式>>② 推进器"))
                            {
                                objItemContent = m_hasItems["植入方式>>② 推进器"] as clsInpatMedRec_Item;
                                strTemp += " ② 推进器";
                            }
                            else if (m_hasItems.Contains("植入方式>>③ 其他"))
                            {
                                objItemContent = m_hasItems["植入方式>>③ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ③ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "", "。$$" },
                        new string[] { "", "植入方式>>其他", "" }, ref strAllText, ref strXml);


                        m_mthMakeText(new string[] { "\n18：", "固定方式：", "①" },
                        new string[] { "", "","" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "固定方式>>囊袋内", "固定方式>>睫状沟", "固定方式>>前房" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "② 位置：居中；" },
                        new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "固定方式>>位置：居中>>鼻", "固定方式>>位置：居中>>额", "固定方式>>位置：居中>>上", "固定方式>>位置：居中>>下偏斜" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "③ 襻位置：", "$$", "点/$$", "$$", "点。$$" },
                        new string[] { "", "固定方式>>襻位置起始", "", "固定方式>>襻位置终止", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n19：", "缩瞳药：" },
                        new string[] { "", ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("缩瞳药>>① 无"))
                            {
                                objItemContent = m_hasItems["缩瞳药>>① 无"] as clsInpatMedRec_Item;
                                strTemp += " ① 无";
                            }
                            else if (m_hasItems.Contains("缩瞳药>>②"))
                            {
                                strTemp += " ② " ;
                                if (m_hasItems.Contains("缩瞳药>>%毛果芸香碱"))
                                {
                                    objItemContent = m_hasItems["缩瞳药>>%毛果芸香碱"] as clsInpatMedRec_Item;
                                    strTemp += " " + objItemContent.m_strItemContent + "%毛果芸香碱";
                                }
                                else
                                {
                                    strTemp += " %毛果芸香碱";
                                }
                            }
                            else if (m_hasItems.Contains("缩瞳药>>③ 卡米可林"))
                            {
                                objItemContent = m_hasItems["缩瞳药>>③ 卡米可林"] as clsInpatMedRec_Item;
                                strTemp += " ③ 卡米可林";
                            }
                            else if (m_hasItems.Contains("缩瞳药>>④ 其他"))
                            {
                                objItemContent = m_hasItems["缩瞳药>>④ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ④ 其他：";
                            }
                         }
                        m_mthMakeText(new string[] { strTemp + "", "", "。$$" },
                        new string[] { "", "缩瞳药>>其他", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n20：", "消除眼内粘弹剂及缩瞳药："},
                        new string[] { "", ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("消除眼内粘弹剂及缩瞳药>>① 自动I/A系统"))
                            {
                                objItemContent = m_hasItems["消除眼内粘弹剂及缩瞳药>>① 自动I/A系统"] as clsInpatMedRec_Item;
                                strTemp += " ① 自动I/A系统";
                            }
                            else if (m_hasItems.Contains("消除眼内粘弹剂及缩瞳药>>② 双腔管"))
                            {
                                objItemContent = m_hasItems["消除眼内粘弹剂及缩瞳药>>② 双腔管"] as clsInpatMedRec_Item;
                                strTemp += " ② 双腔管";
                            }
                         }
                        m_mthMakeText(new string[] { strTemp + "",  "。$$" },
                        new string[] { "", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n21：", "切口缝合："},
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("切口缝合>>无"))
                            {
                                objItemContent = m_hasItems["切口缝合>>无"] as clsInpatMedRec_Item;
                                strTemp += " ① 无";
                            }
                            else if (m_hasItems.Contains("切口缝合>>② 10/0尼龙线间缝合"))
                            {
                                objItemContent = m_hasItems["切口缝合>>② 10/0尼龙线间缝合"] as clsInpatMedRec_Item;
                                strTemp += " ② 10/0尼龙线间缝合";
                            }
                         }
                        m_mthMakeText(new string[] { strTemp + "", "$$", "针。$$" },
                        new string[] { "", "切口缝合>>② 10/0尼龙线间缝合针数", "" }, ref strAllText, ref strXml);

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
        /// 第四页
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


                        m_mthMakeText(new string[] { "22：", "瞳孔：", "① 形态：" },
                        new string[] { "", "", "" }, ref strAllText, ref strXml);
                        m_mthMakeCheckText(new string[] { "", "瞳孔>>形态>>圆", "瞳孔>>形态>>椭圆", "瞳孔>>形态>>不规则" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "② 大小：", "$$", "mm×$$", "$$", "mm；$$", "③ 位置：居中；" },
                        new string[] { "", "瞳孔>>大小1", "", "瞳孔>>大小2", "", "" }, ref strAllText, ref strXml);
                        string strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("瞳孔>>位置：居中；>>鼻"))
                            {
                                objItemContent = m_hasItems["瞳孔>>位置：居中；>>鼻"] as clsInpatMedRec_Item;
                                strTemp += " 鼻";
                            }
                            else if (m_hasItems.Contains("瞳孔>>位置：居中；>>额"))
                            {
                                objItemContent = m_hasItems["瞳孔>>位置：居中；>>额"] as clsInpatMedRec_Item;
                                strTemp += " 额";
                            }
                            else if (m_hasItems.Contains("瞳孔>>位置：居中；>>上"))
                            {
                                objItemContent = m_hasItems["瞳孔>>位置：居中；>>上"] as clsInpatMedRec_Item;
                                strTemp += " 上";
                            }
                            else if (m_hasItems.Contains("瞳孔>>位置：居中；>>下移位"))
                            {
                                objItemContent = m_hasItems["瞳孔>>位置：居中；>>下移位"] as clsInpatMedRec_Item;
                                strTemp += " 下移位";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "。$$" },
                        new string[] { "","" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n23：", "联合手术："},
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("联合手术>>① 小梁切除"))
                            {
                                objItemContent = m_hasItems["联合手术>>① 小梁切除"] as clsInpatMedRec_Item;
                                strTemp += " ① 小梁切除；";
                            }
                            if (m_hasItems.Contains("联合手术>>② 翼状胬肉切除"))
                            {
                                objItemContent = m_hasItems["联合手术>>② 翼状胬肉切除"] as clsInpatMedRec_Item;
                                strTemp += " ② 翼状胬肉切除；";
                            }
                            if (m_hasItems.Contains("联合手术>>③ 其他"))
                            {
                                objItemContent = m_hasItems["联合手术>>③ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ③ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "","$$", "。$$" },
                        new string[] { "", "联合手术>>其他", "" }, ref strAllText, ref strXml);

                        //m_mthMakeText(new string[] { "\n24：", "并发症：", "① 无；", "  ②"},
                        //new string[] { "", "", "", "" }, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "", "并发症>>后囊膜破裂", "并发症>>玻璃体脱出" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "  ③" },
                        //new string[] { "" }, ref strAllText, ref strXml);
                        //m_mthMakeCheckText(new string[] { "", "并发症>>晶状体核", "并发症>>皮质沉入玻璃体腔" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "④ 虹膜损伤；", "⑤ 角膜损伤；", "⑥ 眼内出血；", "⑦ 其他：", "$$", "。$$" },
                        //new string[] { "", "", "", "", "并发症>>其他", "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n24：", "并发症：" },
                        new string[] { "", ""}, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("并发症>>① 无"))
                            {
                                objItemContent = m_hasItems["并发症>>① 无"] as clsInpatMedRec_Item;
                                strTemp += " ① 无";
                            }
                            if (m_hasItems.Contains("并发症>>②"))
                            {
                                objItemContent = m_hasItems["并发症>>②"] as clsInpatMedRec_Item;
                                strTemp += " ②";
                                if (m_hasItems.Contains("并发症>>②>>后囊膜破裂"))
                                {
                                    objItemContent = m_hasItems["并发症>>②>>后囊膜破裂"] as clsInpatMedRec_Item;
                                    strTemp += " 后囊膜破裂；";
                                }
                                else if (m_hasItems.Contains("并发症>>②>>玻璃体脱出"))
                                {
                                    objItemContent = m_hasItems["并发症>>②>>玻璃体脱出"] as clsInpatMedRec_Item;
                                    strTemp += " 玻璃体脱出；";
                                }
                                else
                                {
                                    strTemp += " ；";
                                }
                            }
                            if (m_hasItems.Contains("并发症>>③"))
                            {
                                objItemContent = m_hasItems["并发症>>③"] as clsInpatMedRec_Item;
                                strTemp += " ③";
                                if (m_hasItems.Contains("并发症>>③>>晶状体核"))
                                {
                                    objItemContent = m_hasItems["并发症>>③>>晶状体核"] as clsInpatMedRec_Item;
                                    strTemp += " 晶状体核；";
                                }
                                else if (m_hasItems.Contains("并发症>>③>>皮质沉入玻璃体腔"))
                                {
                                    objItemContent = m_hasItems["并发症>>③>>皮质沉入玻璃体腔"] as clsInpatMedRec_Item;
                                    strTemp += " 皮质沉入玻璃体腔；";
                                }
                                else
                                {
                                    strTemp += " ；";
                                }
                            }
                            if (m_hasItems.Contains("并发症>>④ 虹膜损伤"))
                            {
                                objItemContent = m_hasItems["并发症>>④ 虹膜损伤"] as clsInpatMedRec_Item;
                                strTemp += " ④ 虹膜损伤；";
                            }
                            if (m_hasItems.Contains("并发症>>⑤ 角膜损伤"))
                            {
                                objItemContent = m_hasItems["并发症>>⑤ 角膜损伤"] as clsInpatMedRec_Item;
                                strTemp += " ⑤ 角膜损伤；";
                            }
                            if (m_hasItems.Contains("并发症>>⑥ 眼内出血"))
                            {
                                objItemContent = m_hasItems["并发症>>⑥ 眼内出血"] as clsInpatMedRec_Item;
                                strTemp += " ⑥ 眼内出血；";
                            }
                            if (m_hasItems.Contains("并发症>>⑦ 其他"))
                            {
                                objItemContent = m_hasItems["并发症>>⑦ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ⑦ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "$$", "。$$" },
                        new string[] { "", "并发症>>其他", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n25：", "并发症处理：" },
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("并发症处理>>①"))
                            {
                                objItemContent = m_hasItems["并发症处理>>①"] as clsInpatMedRec_Item;
                                strTemp += " ①";
                                if (m_hasItems.Contains("并发症处理>>①>>前段玻切"))
                                {
                                    objItemContent = m_hasItems["并发症处理>>①>>前段玻切"] as clsInpatMedRec_Item;
                                    strTemp += " 前段玻切；";
                                }
                                else if (m_hasItems.Contains("并发症处理>>①>>显微剪清楚脱出玻璃体"))
                                {
                                    objItemContent = m_hasItems["并发症处理>>①>>显微剪清楚脱出玻璃体"] as clsInpatMedRec_Item;
                                    strTemp += " 显微剪清楚脱出玻璃体；";
                                }
                                else
                                {
                                    strTemp += " ；";
                                }
                            }
                            if (m_hasItems.Contains("并发症处理>>②"))
                            {
                                objItemContent = m_hasItems["并发症处理>>②"] as clsInpatMedRec_Item;
                                strTemp += " ②";
                                if (m_hasItems.Contains("并发症处理>>②>>改行白内障囊外摘除术"))
                                {
                                    objItemContent = m_hasItems["并发症处理>>②>>改行白内障囊外摘除术"] as clsInpatMedRec_Item;
                                    strTemp += " 改行白内障囊外摘除术；";
                                }
                                else if (m_hasItems.Contains("并发症处理>>②>>晶状体圈娩核"))
                                {
                                    objItemContent = m_hasItems["并发症处理>>②>>晶状体圈娩核"] as clsInpatMedRec_Item;
                                    strTemp += " 晶状体圈娩核；";
                                }
                                else
                                {
                                    strTemp += " ；";
                                }
                            }
                            if (m_hasItems.Contains("并发症处理>>③ 缝线固定工人晶状体"))
                            {
                                objItemContent = m_hasItems["并发症处理>>③ 缝线固定工人晶状体"] as clsInpatMedRec_Item;
                                strTemp += " ③ 缝线固定工人晶状体；";
                                
                            }
                            if (m_hasItems.Contains("并发症处理>>④ 其他"))
                            {
                                objItemContent = m_hasItems["并发症处理>>④ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ④ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "$$", "。$$" },
                        new string[] { "", "并发症处理>>其他", "" }, ref strAllText, ref strXml);




                        m_mthMakeText(new string[] { "\n26：", "结膜下注射：", "妥布霉素", "$$", "mm；$$", "地塞米松", "$$", "mg。$$" },
                        new string[] { "", "", "", "结膜下注射>>妥布霉素", "", "", "结膜下注射>>地塞米松", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n27：", "术毕涂眼膏包眼："},
                        new string[] { "", "" }, ref strAllText, ref strXml);
                        strTemp = "";
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains("术毕涂眼膏包眼>>① 碘必殊"))
                            {
                                objItemContent = m_hasItems["术毕涂眼膏包眼>>① 碘必殊"] as clsInpatMedRec_Item;
                                strTemp += " ① 碘必殊";
                            }
                            else if (m_hasItems.Contains("术毕涂眼膏包眼>>② 1%毛果芸香碱"))
                            {
                                objItemContent = m_hasItems["术毕涂眼膏包眼>>② 1%毛果芸香碱"] as clsInpatMedRec_Item;
                                strTemp += " ② 1%毛果芸香碱";
                            }
                            else if (m_hasItems.Contains("术毕涂眼膏包眼>>③ 1%阿托品"))
                            {
                                objItemContent = m_hasItems["术毕涂眼膏包眼>>③ 1%阿托品"] as clsInpatMedRec_Item;
                                strTemp += " ③ 1%阿托品";

                            }
                            else if (m_hasItems.Contains("术毕涂眼膏包眼>>④ 其他"))
                            {
                                objItemContent = m_hasItems["术毕涂眼膏包眼>>④ 其他"] as clsInpatMedRec_Item;
                                strTemp += " ④ 其他：";
                            }
                        }
                        m_mthMakeText(new string[] { strTemp + "", "", "。$$" },
                        new string[] { "", "术毕涂眼膏包眼>>其他", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n28：", "其他：", "$$", "。$$" },
                        new string[] { "", "", "其他", "" }, ref strAllText, ref strXml);
                        string strRecorderName = (m_objContent == null ? "" : (new clsEmployee(m_objContent.m_strCreateUserID).m_StrLastName));
                        string strRecordDate = (m_objContent == null || m_objContent.m_dtmRecordDate == null) ? "" : m_objContent.m_dtmRecordDate.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                        //m_mthMakeText(new string[] { "\n                                                                              病史记录者：" + strRecorderName},
                        //new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    记录日期：" + strRecordDate},
                        new string[] { "" }, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n                                                                              记录日期：", "$$" },
                        //new string[] { "", "记录日期" }, ref strAllText, ref strXml);
                       

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
        ///  记录者
        /// </summary>
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
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "lsvSign")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("记录者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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
