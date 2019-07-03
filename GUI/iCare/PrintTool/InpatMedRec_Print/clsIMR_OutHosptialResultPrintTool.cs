using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
    /// <summary>
    /// 产科出院小结
    /// </summary>
    class clsIMR_OutHosptialResultPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_OutHosptialResultPrintTool(string p_strTypeID)
            : base(p_strTypeID)
		{
            m_strChildTitleName = "产科出院小结";
		}

         protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		  new clsPrintPatientFixInfo(),                                                               
                                                                new clsPringInhospDetail(),
                                                                new clsPringNewChildInfo(), 
                                                                new clsPringOutHospInfo(),
                                                                new clsPrint1()
                
																	   });
        }


        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public clsPrintPatientFixInfo()
            { }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 330, p_intPosY);
                p_intPosY += 25;


                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX , p_intPosY);
                }
                DateTime m_dtTmp = m_objPrintInfo.m_dtmOutHospital;

                string strRegisterID = "";
                long lngRes = 0;


                if (m_dtTmp != DateTime.MinValue && m_dtTmp != DateTime.Parse("1900-01-01 00:00:00"))
                {
                    p_objGrp.DrawString("出院日期：" + m_dtTmp.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 330, p_intPosY);
                }
                else
                {
                    m_dtTmp = DateTime.Now;
                    p_objGrp.DrawString("出院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 330, p_intPosY);
                }
                p_intPosY += 25;

                TimeSpan m_ds_During = m_dtTmp - m_objPrintInfo.m_dtmHISInDate;

                p_objGrp.DrawString("住院天数：" + (m_ds_During.Days + 1).ToString() + "天", p_fntNormalText, Brushes.Black, m_intPatientInfoX , p_intPosY);


                p_intPosY += 25;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
       
        /// <summary>
        /// 入院信息--特殊住院情况
        /// </summary>
        class clsPringInhospDetail : clsIMR_PrintLineBase
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
                string strAllText = "";
                string strXml = "";
                if (m_blnIsFirstPrint)
                {
                    
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;

                    m_mthMakeText(new string[] { "入院情况：孕", "$$", "产$$", "$$", " 宫内妊娠", "$$", "周$$", "\n入院检查：血压：", "$$", "/$$", "$$", "mmHg。宫底耻联上$$", "$$", "厘米， 先露$$", "$$" },
                        new string[] { "", "入院情况>>孕", "", "入院情况>>产", "", "入院情况>>宫内妊娠周", "", "", "入院检查>>血压高", "", "入院检查>>血压低", "", "入院检查>>宫底耻联", "", "入院检查>>先露" }, ref strAllText, ref strXml);

                    m_mthMakeCheckText(new string[] { " ", "入院检查>>未固定", "入院检查>>已固定" }, ref strAllText, ref strXml);

                    m_mthMakeText(new string[] { "\n           胎方位：", "$$", "胎心：", "$$", "次/分。 肛查宫口开：$$", "$$", "厘米$$", "\n入院诊断： ", "$$", "\n住院经过： 于$$", "$$" },
                        new string[] { "", "入院检查>>胎方位", "", "入院检查>>胎心", "", "入院检查>>肛查开口", "", "", "入院信息>>入院诊断", "", "住院经过>>于时间" }, ref strAllText, ref strXml);

                    m_mthMakeCheckText("","",new string[] { "住院经过>>顺产", "住院经过>>吸引产", "住院经过>>钳产", "住院经过>>臂产", "住院经过>>臂牵引产", "住院经过>>剖宫产" }, ref strAllText, ref strXml);

                    string m_strTemp = "";
                    if (m_hasItems != null && m_hasItems.Contains("住院经过>>剖宫产"))
                    {

                        if (m_hasItems.Contains("住院经过>>宫下段"))
                            m_strTemp = "（宫下段）";
                        if (m_hasItems.Contains("住院经过>>腹膜外"))
                            m_strTemp = "（腹膜外）";
                        if (m_hasItems.Contains("住院经过>>古典式"))
                            m_strTemp = "（古典式）";
                    }

                    m_mthMakeText(new string[] { m_strTemp,"$$"},
                        new string[] { "","住院经过>>婴儿数"}, ref strAllText, ref strXml);


                    m_mthMakeCheckText("个","活婴。",new string[] { "住院经过>>男","住院经过>>女" }, ref strAllText, ref strXml);

                    //m_mthMakeText(new string[] { "活婴。 ","\n         Apgar评分：１分钟：","$$","分， 5分钟：$$","$$","分。 \n         会阴情况：裂伤$$" },
                    //    new string[] { "","","住院经过>>Apgar评分：１分钟","","住院经过>>Apgar评分：5分钟","" }, ref strAllText, ref strXml);

                    //m_mthMakeText(new string[] {  "活婴。", " \n         Apgar评分：１分钟：", "分; $$", "5分钟：", "分$$"},
                    //                  new string[] { "", "住院经过>>Apgar评分：１分钟", "", "住院经过>>Apgar评分：5分钟", "" }, ref strAllText, ref strXml);

                    m_mthMakeText(new string[] { " \n         Apgar评分：１分钟：", "$$", "#分；5分钟：", "$$", "#分" },
                                      new string[] { "", "住院经过>>Apgar评分：１分钟", "住院经过>>Apgar评分：１分钟", "住院经过>>Apgar评分：5分钟", "住院经过>>Apgar评分：5分钟" }, ref strAllText, ref strXml);


                    m_mthMakeCheckText(new string[] { " \n         会阴情况：裂伤", "住院经过>>会阴裂伤>>无", "住院经过>>会阴裂伤>>Ⅰ°", "住院经过>>会阴裂伤>>Ⅱ°", "住院经过>>会阴裂伤>>Ⅲ°" }, ref strAllText, ref strXml);
                                    
                    m_strTemp = "";
                    string m_strTemp1 = "";
                    if (m_hasItems != null)
                    {
                        if (m_hasItems.Contains("住院经过>>会阴切开>>直切"))
                            m_strTemp = "直切";
                        if (m_hasItems.Contains("住院经过>>会阴切开>>斜切"))
                            m_strTemp = "斜切";

                        if (m_hasItems.Contains("住院经过>>产后出血>>称重法"))
                            m_strTemp1 = "（称重法）";
                        if (m_hasItems.Contains("住院经过>>产后出血>>容积法"))
                            m_strTemp1 = "（容积法）";
                        if (m_hasItems.Contains("住院经过>>产后出血>>目测估计法"))
                            m_strTemp1 = "（目测估计法）";
                    }

                    m_mthMakeText(new string[] { " 切开：", m_strTemp, "\n         产后出血：", "$$", "#毫升"+ m_strTemp1, "  会阴伤口拆线：", "$$", "#针。" },
                        new string[] { "", "", "", "住院经过>>产后出血", "住院经过>>产后出血", "", "住院经过>>会阴伤口拆线针", "住院经过>>会阴伤口拆线针" }, ref strAllText, ref strXml);

                    m_mthMakeCheckText("\n         会阴腹部伤口愈合：", "",new string[] { "住院经过>>会阴腹部伤口愈合>>Ⅰ类", "住院经过>>会阴腹部伤口愈合>>Ⅱ类", "住院经过>>会阴腹部伤口愈合>>Ⅲ类" }, ref strAllText, ref strXml);
                    m_mthMakeCheckText(new string[] { "", "住院经过>>会阴腹部伤口愈合>>甲级", "住院经过>>会阴腹部伤口愈合>>乙级", "住院经过>>会阴腹部伤口愈合>>丙级" }, ref strAllText, ref strXml);

                    m_mthMakeText(new string[] { "\n特殊住院情况：", "$$" },
                        new string[] { "", "特殊住院情况" }, ref strAllText, ref strXml);

                    m_blnIsFirstPrint = false;
                }

                m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                
                
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(m_fontItemMidHead.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    m_blnHaveMoreLine = false;
                    if (m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;
                    //m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                    //p_intPosY += 25;
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
        /// 新婴儿情况

        /// </summary>
        class clsPringNewChildInfo : clsIMR_PrintLineBase
        {
            bool m_blnIsFirstPrint = true;
            int m_tmpPointX = 0;
            clsInpatMedRec_Item objItemContent;

            int m_intRowCount;
            int m_intRowHeight;
            float m_floatEveryColWidth;
            float[] m_floatColArr;
            float[] m_floatLeftXArr;

            RectangleF m_rtgF;
            StringFormat m_sf;

            #region 初始化

            public clsPringNewChildInfo()
            {
                m_floatEveryColWidth = (float)enmRectangleInfoInPatientCaseInfo.PrintWidth / 23;
                m_intRowHeight = 30;
                m_intRowCount = 6;
                m_floatColArr = new float[9];
                m_floatLeftXArr = new float[9];
                m_floatColArr[0] = m_floatEveryColWidth;
                m_floatColArr[1] = m_floatEveryColWidth * 4;
                m_floatColArr[2] = m_floatEveryColWidth * 3;
                m_floatColArr[3] = m_floatEveryColWidth * 3;
                m_floatColArr[4] = m_floatEveryColWidth * 3;
                m_floatColArr[5] = m_floatEveryColWidth * 2;
                m_floatColArr[6] = m_floatEveryColWidth * 3;
                m_floatColArr[7] = m_floatEveryColWidth * 2;
                m_floatColArr[8] = m_floatEveryColWidth * 2;

                m_floatLeftXArr[0] = m_intPatientInfoX;
                for (int i = 1; i < m_floatLeftXArr.Length; i++)
                {
                     m_floatLeftXArr[i] = m_floatLeftXArr[i - 1] + m_floatColArr[i - 1];
                }
                m_rtgF = new RectangleF();
                m_sf = new StringFormat();
                m_sf.Alignment = StringAlignment.Center;
                m_sf.LineAlignment = StringAlignment.Center;
            }
            #endregion

            /// <summary>
            /// 画表格

            /// </summary>
            /// <param name="g"></param>
            /// <param name="p_intPosY"></param>
            private void m_mthDrawTable(Graphics g, int p_intPosY)
            {
                Font m_fontTitle = new Font("", 12);
                // 画线
                g.DrawRectangle(Pens.Black, m_floatLeftXArr[0], p_intPosY, (float)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRowHeight * m_intRowCount);
                
                for (int i = 1; i < m_floatLeftXArr.Length; i++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[i], p_intPosY, m_floatLeftXArr[i], p_intPosY + m_intRowCount * m_intRowHeight);
                }
                g.DrawLine(Pens.Black, m_floatLeftXArr[1], p_intPosY + m_intRowHeight, m_floatLeftXArr[5], p_intPosY + m_intRowHeight);
                g.DrawLine(Pens.Black, m_floatLeftXArr[1], p_intPosY + 2 * m_intRowHeight, m_floatLeftXArr[1] + m_floatEveryColWidth * 2, p_intPosY + 2 * m_intRowHeight);
                for (int i = 3; i < m_intRowCount; i++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[0], p_intPosY + m_intRowHeight * i, m_floatLeftXArr[0] + (float)enmRectangleInfoInPatientCaseInfo.PrintWidth, p_intPosY + m_intRowHeight * i);
                }
                g.DrawLine(Pens.Black, m_floatLeftXArr[1] + m_floatEveryColWidth, p_intPosY + m_intRowHeight * 2, m_floatLeftXArr[1] + m_floatEveryColWidth, p_intPosY + m_intRowHeight * 6);
                g.DrawLine(Pens.Black, m_floatLeftXArr[1] + m_floatEveryColWidth * 2, p_intPosY + m_intRowHeight, m_floatLeftXArr[1] + m_floatEveryColWidth * 2, p_intPosY + m_intRowHeight * 6);
                m_rtgF.X = m_floatLeftXArr[2] + m_floatEveryColWidth;
                for (int iCol = 0; iCol < 8; iCol++)
                {
                    g.DrawLine(Pens.Black, m_rtgF.X + m_floatEveryColWidth * iCol, p_intPosY + m_intRowHeight, m_rtgF.X + m_floatEveryColWidth * iCol, p_intPosY + m_intRowHeight * 6);
                }

                // 画字
                m_rtgF.X = m_floatLeftXArr[0];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatEveryColWidth;
                m_rtgF.Height = m_intRowHeight * 3;
                g.DrawString("婴儿序号", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_floatLeftXArr[1];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatEveryColWidth * 4;
                m_rtgF.Height = m_intRowHeight;
                g.DrawString("新生儿情况", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.Y = p_intPosY + m_intRowHeight;
                m_rtgF.Width = m_floatEveryColWidth * 2;
                g.DrawString("性别", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.Y = p_intPosY + 2 * m_intRowHeight;
                m_rtgF.Width = m_floatEveryColWidth;
                g.DrawString("男", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_floatLeftXArr[1] + m_floatEveryColWidth;
                g.DrawString("女", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                m_rtgF.Y = p_intPosY + m_intRowHeight;
                m_rtgF.Width = 2 * m_floatEveryColWidth;
                m_rtgF.Height = 2 * m_intRowHeight;
                g.DrawString("体重(克)", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[2];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[2];
                m_rtgF.Height = m_intRowHeight;
                g.DrawString("分娩结果", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.Y = p_intPosY + m_intRowHeight;
                m_rtgF.Width = m_floatEveryColWidth;
                m_rtgF.Height = 2 * m_intRowHeight;
                g.DrawString("活产", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                g.DrawString("死产", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                g.DrawString("死胎", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[3];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[3];
                m_rtgF.Height = m_intRowHeight;
                g.DrawString("呼吸", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.Y = p_intPosY + m_intRowHeight;
                m_rtgF.Width = m_floatEveryColWidth;
                m_rtgF.Height = m_intRowHeight * 2;
                g.DrawString("自然", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                
                g.DrawString("I 窒息", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                g.DrawString("II窒息", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[4];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[4];
                m_rtgF.Height = m_intRowHeight;
                g.DrawString("转归", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.Y = p_intPosY + m_intRowHeight;
                m_rtgF.Width = m_floatEveryColWidth;
                m_rtgF.Height = 2 * m_intRowHeight;
                g.DrawString("死亡", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                g.DrawString("转出", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                g.DrawString("出院", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[5];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[5];
                m_rtgF.Height = m_intRowHeight * 3;
                g.DrawString("院内感染", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[6];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[6];
                m_rtgF.Height = m_intRowHeight * 3;
                g.DrawString("主要院内感染名称", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[7];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[7];
                m_rtgF.Height = m_intRowHeight * 3;
                g.DrawString("抢救次数", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[8];
                m_rtgF.Y = p_intPosY;
                m_rtgF.Width = m_floatColArr[8];
                m_rtgF.Height = m_intRowHeight * 3;
                g.DrawString("抢救成功", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                // 画口
                for (int iRow = 0; iRow < 3; iRow++)
                {
                    m_rtgF.X = m_floatLeftXArr[1];
                    m_rtgF.Y = p_intPosY + m_intRowHeight * (3 + iRow);
                    m_rtgF.Width = m_floatEveryColWidth;
                    m_rtgF.Height = m_intRowHeight;
                    g.DrawString("□", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    g.DrawString("□", m_fontTitle, Brushes.Black, m_rtgF, m_sf);

                    m_rtgF.X = m_floatLeftXArr[2];
                    for (int i = 0; i < 9; i++)
                    {
                        g.DrawString("□", m_fontTitle, Brushes.Black, m_rtgF, m_sf);
                        m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    }

                }
            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("新生儿情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                p_intPosY += 25;

                if (p_intPosY + m_intRowCount * m_intRowHeight > (int)enmRectangleInfoInPatientCaseInfo.BottomY - 60)
                {
                    m_blnHaveMoreLine = true;
                    return;

                }
                //  画表格

                m_mthDrawTable(p_objGrp, p_intPosY);
                
                m_tmpPointX = m_intPatientInfoX;
                

                if (m_blnIsFirstPrint)
                {
                    Font m_fontChecked = new Font(p_fntNormalText, FontStyle.Bold);
                    
                    #region 第一行


                    m_rtgF.X = m_floatLeftXArr[0];
                    m_rtgF.Y = p_intPosY + m_intRowHeight * 3;
                    m_rtgF.Width = m_floatEveryColWidth;
                    m_rtgF.Height = m_intRowHeight;
                    if (m_hasItems.Contains("新生儿情况>>婴儿序号1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>婴儿序号1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>男1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>女1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>体重1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>体重1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_floatLeftXArr[2] - 13;
                    if (m_hasItems.Contains("新生儿情况>>活产1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死产1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死胎1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>自然1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息11"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息21"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>转出1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死亡1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>出院1"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[5];
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>院内感染1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>院内感染1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[6];
                    m_rtgF.Width = m_floatColArr[6];
                    if (m_hasItems.Contains("新生儿情况>>主要感染1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>主要感染1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[7];
                    m_rtgF.Width = m_floatColArr[7];
                    if (m_hasItems.Contains("新生儿情况>>抢救次数1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救次数1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[8];
                    m_rtgF.Width = m_floatColArr[8];
                    if (m_hasItems.Contains("新生儿情况>>抢救成功1"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救成功1"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    #endregion

                    #region 第二行

                    

                    m_rtgF.X = m_floatLeftXArr[0];
                    m_rtgF.Y = p_intPosY + m_intRowHeight * 4;
                    m_rtgF.Width = m_floatEveryColWidth;
                    m_rtgF.Height = m_intRowHeight;
                    if (m_hasItems.Contains("新生儿情况>>婴儿序号2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>婴儿序号2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>男2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>女2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>体重2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>体重2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_floatLeftXArr[2] - 13;
                    if (m_hasItems.Contains("新生儿情况>>活产2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死产2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死胎2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>自然2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息12"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息22"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>转出2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死亡2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>出院2"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[5];
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>院内感染2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>院内感染2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[6];
                    m_rtgF.Width = m_floatColArr[6];
                    if (m_hasItems.Contains("新生儿情况>>主要感染2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>主要感染2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[7];
                    m_rtgF.Width = m_floatColArr[7];
                    if (m_hasItems.Contains("新生儿情况>>抢救次数2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救次数2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[8];
                    m_rtgF.Width = m_floatColArr[8];
                    if (m_hasItems.Contains("新生儿情况>>抢救成功2"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救成功2"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    
                    #endregion

                    #region 第三行


                    m_rtgF.X = m_floatLeftXArr[0];
                    m_rtgF.Y = p_intPosY + m_intRowHeight * 5;
                    m_rtgF.Width = m_floatEveryColWidth;
                    m_rtgF.Height = m_intRowHeight;
                    if (m_hasItems.Contains("新生儿情况>>婴儿序号3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>婴儿序号3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>男3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>女3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>体重3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>体重3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_floatLeftXArr[2] - 13;
                    if (m_hasItems.Contains("新生儿情况>>活产3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死产3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死胎3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>自然3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息13"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }

                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>窒息23"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>转出3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>死亡3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_rtgF.X + m_floatEveryColWidth;
                    if (m_hasItems.Contains("新生儿情况>>出院3"))
                    {
                        p_objGrp.DrawString("√", m_fontChecked, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[5];
                    m_rtgF.Width = m_floatColArr[5];
                    if (m_hasItems.Contains("新生儿情况>>院内感染3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>院内感染3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[6];
                    m_rtgF.Width = m_floatColArr[6];
                    if (m_hasItems.Contains("新生儿情况>>主要感染3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>主要感染3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[7];
                    m_rtgF.Width = m_floatColArr[7];
                    if (m_hasItems.Contains("新生儿情况>>抢救次数3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救次数3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }
                    m_rtgF.X = m_floatLeftXArr[8];
                    m_rtgF.Width = m_floatColArr[8];
                    if (m_hasItems.Contains("新生儿情况>>抢救成功3"))
                    {
                        objItemContent = m_hasItems["新生儿情况>>抢救成功3"] as clsInpatMedRec_Item;
                        p_objGrp.DrawString(objItemContent.m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                    }

                    #endregion

                    p_intPosY += m_intRowHeight * m_intRowCount;
                    m_blnIsFirstPrint = false;
                }
               
                m_blnHaveMoreLine = false;
                return;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }
        
        /// <summary>
        /// 出院情况
        /// </summary>
        class clsPringOutHospInfo : clsIMR_PrintLineBase
        { 
            bool m_blnIsFirstPrint = true;
            
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                p_intPosY += 5;
                if (m_blnIsFirstPrint)
                {
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_hasItems != null && m_hasItems.Contains("出院情况>>其他情况"))
                        {
                            m_mthMakeText(new string[] { "出院情况：母婴健康出院，其他：", "$$", "\n出院诊断：", "$$" },
                            new string[] { "", "出院情况>>其他情况", "", "出院情况>>出院诊断" }, ref strAllText, ref strXml);
                        }
                        else
                        {
                            m_mthMakeText(new string[] { "出院情况：母婴健康出院。\n出院诊断：", "$$" },
                            new string[] { "", "出院情况>>出院诊断" }, ref strAllText, ref strXml);
                        }
                        m_mthMakeCheckText(new string[] { "\n出院医嘱：", "出院医嘱>>产后４２天到门诊检查", "出院医嘱>>注意产褥期营养卫生", "出院医嘱>>母乳喂养", "出院医嘱>>不适随诊", "" }, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n其他医嘱：", "$$" }, new string[] { "", "出院情况>>其它医嘱" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_blnPrintAllBySimSun(p_fntNormalText.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    m_blnHaveMoreLine = false;
                    if (m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;
                }
            }

        }



        /// <summary>
        ///  术者签名

        /// </summary>
        private class clsPrint1 : clsIMR_PrintLineBase
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
                    string strRecordDate = "\n"+m_objContent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss");
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "lsvSign")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("记录者签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                        m_mthMakeText(new string[] { strOperations, strRecordDate }, new string[] { "","" }, ref strAllText, ref strXml);
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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 100, p_intPosY, p_objGrp);
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
