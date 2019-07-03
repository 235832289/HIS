using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 眼科手术护理记录单
    /// </summary>
    class clsIMR_OphthalmologyNurseRecordPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_OphthalmologyNurseRecordPrintTool(string p_strType)
            : base(p_strType)
        {
            m_strChildTitleName = "眼科手术护理记录单";
        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] {
                new clsPrintCircs(),
                new clsPrintNursesRecord(),
                new clsPrintSignName()});
        }

        #region Print Class
        /// <summary>
        /// 打印护理情况
        /// </summary>
        private class clsPrintCircs : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                string m_strAllText = "";
                string m_strAllXml = "";
                string m_strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;

                if (m_objContent != null)
                {
                    m_strDateType = "yyyy年MM月dd HH:mm";
                    m_mthMakeText(new string[] { "入室时间：", "\n术前诊断：", "手术名称：", "\n药物过敏史：", "麻醉方式：" },
                        new string[] { "护理情况>>入室时间", "护理情况>>术前诊断", "护理情况>>手术名称", "护理情况>>药物过敏史", "护理情况>>麻醉方式" }, ref m_strAllText, ref m_strAllXml);

                    m_strDateType = "yyyy年MM月dd HH:mm";
                    m_mthMakeText(new string[] { "； 手术时间：", "\n护理情况：" }, new string[] { "护理情况>>手术时间", "" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeCheckText(new string[] { "\n    术前：神志：", "护理情况>>术前>>神志>>清", "护理情况>>术前>>神志>>不清" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeCheckText(new string[] { "  静脉穿刺：", "护理情况>>术前>>静脉穿刺>>是", "护理情况>>术前>>静脉穿刺>>否" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeCheckText(new string[] { "\n    术中：体位：", "护理情况>>术中>>体位>>平卧", "护理情况>>术中>>体位>>仰卧" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeCheckText(new string[] { "  送病理：", "护理情况>>术中>>送病理>>有", "护理情况>>术中>>送病理>>无" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "\n          置入物：", "护理情况>>术中>>置入物>>是", "护理情况>>术中>>置入物>>否" }, ref m_strAllText, ref m_strAllXml);
                    m_mthMakeCheckText(new string[] { "  引流：", "护理情况>>术中>>引流>>有", "护理情况>>术中>>引流>>否" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeText(new string[] { "\n          其他：" },
                        new string[] { "护理情况>>术中>>其他" }, ref m_strAllText, ref m_strAllXml);

                    m_strDateType = "yyyy年MM月dd HH:mm";
                    m_mthMakeText(new string[] { "\n    术毕：时间：" },
                        new string[] { "护理情况>>术毕>>时间" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "  意识情况：", "护理情况>>术毕>>意识>>清醒", "护理情况>>术毕>>意识>>半清醒", "护理情况>>术毕>>意识>>不清醒" }, ref m_strAllText, ref m_strAllXml);

                    m_strDateType = "yyyy年MM月dd HH:mm";
                    m_mthMakeText(new string[] { "\n          离室时间：" }, new string[] { "护理情况>>术毕>>离室时间" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "  术后送回：", "护理情况>>术毕>>术后送回>>病房", "护理情况>>术毕>>术后送回>>ＩＣＵ" }, ref m_strAllText, ref m_strAllXml);

                    m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strAllText, m_strAllXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(p_fntNormalText.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    if (m_intRealHeight < 25)
                        p_intPosY += 25;
                    else
                        p_intPosY += m_intRealHeight;

                    m_blnHaveMoreLine = false;
                }
            }
        }
        /// <summary>
        /// 打印护理记录
        /// </summary>
        private class clsPrintNursesRecord : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            float[] m_floatWidthArr;
            float[] m_floatLeftXArr;
            int m_intHeadHeight;
            int m_intRowCount;
            int m_intRowHeight;
            Font m_fntHeadTitle;
            float m_floatTotalWidth;
            StringFormat m_sf;

            public clsPrintNursesRecord()
            {
                m_intHeadHeight = 40;
                m_intRowHeight = 35;
                m_intRowCount = 5;
                m_floatTotalWidth = (float)enmRectangleInfoInPatientCaseInfo.PrintWidth;
                m_floatWidthArr = new float[5];
                m_floatLeftXArr = new float[5];
                m_floatWidthArr[0] = 90;
                m_floatWidthArr[1] = 100;
                m_floatWidthArr[2] = 55;
                m_floatWidthArr[3] = 55;
                m_floatWidthArr[4] = m_floatTotalWidth - m_floatWidthArr[0] - m_floatWidthArr[1] - m_floatWidthArr[2] - m_floatWidthArr[3];

                m_floatLeftXArr[0] = m_intPatientInfoX;
                for (int i = 1; i < m_floatLeftXArr.Length; i++)
                {
                    m_floatLeftXArr[i] = m_floatLeftXArr[i - 1] + m_floatWidthArr[i - 1];
                }
                m_sf = new StringFormat();
                m_sf.Alignment = StringAlignment.Center;
                m_sf.LineAlignment = StringAlignment.Center;
            }

            private void DrawHeaderAndLines(Graphics g, Font m_fontNormal, ref int p_intPosY)
            {
                p_intPosY += 5;
                
                g.DrawRectangle(Pens.Black, m_floatLeftXArr[0], p_intPosY, m_floatTotalWidth, m_intHeadHeight);
                g.DrawLine(Pens.Black, m_floatLeftXArr[4], p_intPosY, m_floatLeftXArr[4], p_intPosY + m_intHeadHeight);

                RectangleF m_rtgF = new RectangleF(m_floatLeftXArr[0], p_intPosY, m_floatTotalWidth - m_floatWidthArr[4], m_intHeadHeight);
                g.DrawString("无菌包监测： □合格", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                if (m_hasItems.Contains("护理记录>>合格"))
                {
                    m_rtgF.Height = m_intHeadHeight - 10;
                    g.DrawString("         √  ", new Font(m_fontNormal, FontStyle.Bold), Brushes.Black, m_rtgF, m_sf);
                    m_rtgF.Height = m_intHeadHeight;
                }

                m_rtgF.X = m_floatLeftXArr[4];
                m_rtgF.Width = m_floatWidthArr[4];
                g.DrawString("护 理 记 录", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[0];
                m_rtgF.Width = m_floatWidthArr[0];
                m_rtgF.Y = p_intPosY + m_intHeadHeight;
                m_rtgF.Height = m_intHeadHeight;
                g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                g.DrawString("品 名", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[1];
                m_rtgF.Width = m_floatWidthArr[1];
                g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                g.DrawString("术前清点数量", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[2];
                m_rtgF.Width = m_floatWidthArr[2];
                m_rtgF.Height = m_intHeadHeight / 2;
                g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                g.DrawString("关前", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[3];
                m_rtgF.Width = m_floatWidthArr[3];
                g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                g.DrawString("关后", m_fontNormal, Brushes.Black, m_rtgF, m_sf);

                m_rtgF.X = m_floatLeftXArr[2];
                m_rtgF.Width = m_floatWidthArr[2] + m_floatWidthArr[3];
                m_rtgF.Y += m_intHeadHeight / 2;
                m_rtgF.Height = m_intHeadHeight/2;
                g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                g.DrawString("清点数", m_fontNormal, Brushes.Black, m_rtgF, m_sf);
                p_intPosY += m_intHeadHeight *2;
                // 画线 竖线
                for (int i = 0; i < m_floatLeftXArr.Length; i++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[i], p_intPosY, m_floatLeftXArr[i], p_intPosY + m_intRowHeight * m_intRowCount);
                }
                g.DrawLine(Pens.Black, m_floatLeftXArr[4] + m_floatWidthArr[4], p_intPosY - m_intHeadHeight, m_floatLeftXArr[4] + m_floatWidthArr[4], p_intPosY + m_intRowHeight * m_intRowCount);
                // 横线
                for (int i = 0; i <= m_intRowCount; i++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[0], p_intPosY + m_intRowHeight * i, m_floatLeftXArr[4] + m_floatWidthArr[4], p_intPosY + m_intRowHeight * i);
                }
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                DrawHeaderAndLines(p_objGrp, p_fntNormalText, ref p_intPosY);

                RectangleF m_rtgF = new RectangleF();

                string[][] m_strKeyArr = new string[][] { new string[] { "", "护理记录>>术前清点数量>>1", "护理记录>>关前>>1", "护理记录>>关后>>1" },
                                                          new string[] { "", "护理记录>>术前清点数量>>2", "护理记录>>关前>>2", "护理记录>>关后>>2" },
                                                          new string[] { "护理记录>>品名>>3", "护理记录>>术前清点数量>>3", "护理记录>>关前>>3", "护理记录>>关后>>3"},
                                                          new string[] { "护理记录>>品名>>4", "护理记录>>术前清点数量>>4", "护理记录>>关前>>4", "护理记录>>关后>>4"},
                                                          new string[] { "护理记录>>品名>>5", "护理记录>>术前清点数量>>5", "护理记录>>关前>>5", "护理记录>>关后>>5"}};

                m_rtgF.Height = m_intRowHeight;
                for (int i = 0; i < m_intRowCount; i++)
                {
                    m_rtgF.Y = p_intPosY + m_intRowHeight * i;
                    for (int iRow = 0; iRow < m_floatLeftXArr.Length-1; iRow++)
                    {
                        m_rtgF.X = m_floatLeftXArr[iRow];
                        m_rtgF.Width = m_floatWidthArr[iRow];
                        if (i == 0 && iRow == 0)
                        {
                            p_objGrp.DrawString("缝 针", p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                            continue;
                        }
                        else if(i == 1 && iRow == 0)
                        {
                            p_objGrp.DrawString("带线针", p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                            continue;
                        }
                        if (m_hasItems.Contains(m_strKeyArr[i][iRow]))
                        {
                            p_objGrp.DrawString((m_hasItems[m_strKeyArr[i][iRow]] as clsInpatMedRec_Item).m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                        }
                    }
                }

                if (m_hasItems.Contains("护理记录"))
                {
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((m_hasItems["护理记录"] as clsInpatMedRec_Item).m_strItemContent, (m_hasItems["护理记录"] as clsInpatMedRec_Item).m_strItemContentXml, m_dtmFirstPrintTime, true);
                }
                int m_intRealHeight = m_intHeadHeight + m_intRowCount * m_intRowHeight;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    
                    Rectangle m_rtg = new Rectangle((int)m_floatLeftXArr[4], (int)(p_intPosY - m_intHeadHeight), (int)m_floatWidthArr[4], m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(p_fntNormalText.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                }
                if (m_intRealHeight < m_intHeadHeight + m_intRowCount * m_intRowHeight)
                {
                    p_intPosY += m_intHeadHeight + m_intRowCount * m_intRowHeight;
                }
                else
                    p_intPosY += m_intRealHeight;

                m_blnHaveMoreLine = false;
            }
        }
        /// <summary>
        /// 打印签名
        /// </summary>
        private class clsPrintSignName : clsIMR_PrintLineBase
        {
            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                string m_strPrint = "洗手护士签名：";
                if (m_hasItems.Contains("护理记录>>洗手护士签名"))
                    m_strPrint += (m_hasItems["护理记录>>洗手护士签名"] as clsInpatMedRec_Item).m_strItemContent;
                p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                m_strPrint = "巡回护士签名：";
                if (m_hasItems.Contains("护理记录>>巡回护士签名"))
                    m_strPrint += (m_hasItems["护理记录>>巡回护士签名"] as clsInpatMedRec_Item).m_strItemContent;
                p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY + 25);

                m_strPrint = "置入物条码：";
                p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);

                p_intPosY += 40;
                m_strPrint = "消毒指示卡：";
                p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                p_intPosY += 40;

                m_blnHaveMoreLine = false;
            }
        }
        #endregion
    }
}
