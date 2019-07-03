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
    /// 引产登记表打印类， 伦教。
    /// </summary>
    public class clsIMR_InducedLaborRecordPrintTool_LJ : clsInpatMedRecPrintBase
    {
        public clsIMR_InducedLaborRecordPrintTool_LJ(string p_strTypeId)
            : base(p_strTypeId)
        {
            m_strChildTitleName = "引产登记表";
        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] {
                new clsPrintBaseInfo(),
                new clsPrintInduceLaborInfo(),
                new clsPrintInduceLaboredRecord(),
                new clsPrintInduceRecord(),
                new clsPrint11(),
                new clsPrint12()
                
                });
        }

        #region PrintClass

        #region 打印基本信息
        /// <summary>
        /// 打印基本信息
        /// </summary>
        internal class clsPrintBaseInfo : clsIMR_PrintLineBase
        {
            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("地址：" + m_objPrintInfo.m_strHomeAddress, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 25;
                m_blnHaveMoreLine = false;
            }
        }
        #endregion

        #region 打印引产登记信息
        /// <summary>
        /// 打印引产登记信息
        /// </summary>
        internal class clsPrintInduceLaborInfo : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
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
                    string m_strTemp = "";
                    if (m_hasItems != null)
                    {
                        if (m_hasItems.Contains("引产登记>>生育史>>未次分娩"))
                            m_strTemp += "未次分娩：";
                        else if (m_hasItems.Contains("引产登记>>生育史>>流产"))
                            m_strTemp += "流产：";

                    }
                    m_mthMakeText(new string[] { "引产原因：", "\n月 经 史：初潮：", "经量：", "经痛：", "未次月经：", "\n生 育 史：$$", "孕$$", "产，$$", m_strTemp, "$$", "分娩方式：", "$$" },
                        new string[] { "引产登记>>引产原因", "引产登记>>月经史>>初潮", "引产登记>>月经史>>经量", "引产登记>>月经史>>痛经", "引产登记>>月经史>>未次月经", "引产登记>>生育史>>孕", "引产登记>>生育史>>产", "", "", "引产登记>>生育史>>分娩流产时间", "", "引产登记>>生育史>>分娩方式" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "\n过 去 史：", "引产登记>>过去史>>心脏病", "引产登记>>过去史>>肝病", "引产登记>>过去史>>肺结核", "引产登记>>过去史>>关节炎", "引产登记>>过去史>>肾炎", "引产登记>>过去史>>出血史", "引产登记>>过去史>>过敏史", "引产登记>>过去史>>其它" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeText(new string[] { "\n体    检：血压：", "$$", "mmHg； 心：$$", "$$", " 肺：", " 肝：", " 脾：", " 膝反射：",
                                                 "\n妇    检：外阴：", " 阴道：", " 宫颈：", " 子宫：" ,
                                                 "\n诊    断："   },

                        new string[] { "", "引产登记>>体检>>血压", "", "引产登记>>体检>>心", "引产登记>>体检>>肺", "引产登记>>体检>>肝", "引产登记>>体检>>脾", "引产登记>>体检>>膝反射",
                                       "引产登记>>妇检>>外阴", "引产登记>>妇检>>阴道", "引产登记>>妇检>>宫颈", "引产登记>>妇检>>子宫",
                                       "引产登记>>诊断" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "\n引产方式：", "引产登记>>引产方式>>羊膜腔穿刺术", "引产登记>>引产方式>>药物" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeText(new string[] { "药物名称：", " 剂量：", "mg， 给药途径：$$" }, new string[] { "引产登记>>药物名称", "引产登记>>剂量", "引产登记>>给药途径" }, ref m_strAllText, ref m_strAllXml);

                    m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strAllText, m_strAllXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(p_fntNormalText.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    if (m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;

                    if (m_hasItems != null)
                    {
                        string m_strPrint;
                        m_strPrint = "医师签名：";
                        if (m_hasItems.Contains("引产登记>>医师签名"))
                            m_strPrint += ((clsInpatMedRec_Item)m_hasItems["引产登记>>医师签名"]).m_strItemContent;
                        p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                        p_intPosY += 25;
                    }
                    m_blnHaveMoreLine = false;
                }
            }
        }
        #endregion

        #region 打印引产后观察记录
        /// <summary>
        /// 打印引产后观察记录
        /// </summary>
        internal class clsPrintInduceLaboredRecord : clsIMR_PrintLineBase
        {
            float[] m_floatWidthArr;
            float[] m_floatLeftXArr;
            int m_intHeadHeight;
            int m_intRowCount;
            int m_intRowHeight;
            Font m_fntHeadTitle;
            float m_floatTotalWidth;
            StringFormat m_sf;
               
            public clsPrintInduceLaboredRecord()
            {
                m_intHeadHeight = 40;
                m_intRowHeight = 35;
                m_intRowCount = 7;
                m_floatTotalWidth = (float)enmRectangleInfoInPatientCaseInfo.PrintWidth;
                m_floatWidthArr = new float[11];
                m_floatLeftXArr = new float[11];
                m_floatWidthArr[0] = 80;

                float m_floatTemp = (m_floatTotalWidth - m_floatWidthArr[0]) / 10;
                for (int i = 1; i < m_floatWidthArr.Length; i++)
                {
                    m_floatWidthArr[i] = m_floatTemp;
                }
                m_floatLeftXArr[0] = m_intPatientInfoX;
                for (int iCol = 1; iCol < m_floatLeftXArr.Length; iCol++)
                {
                    m_floatLeftXArr[iCol] = m_floatLeftXArr[iCol - 1] + m_floatWidthArr[iCol - 1];
                }

                m_sf = new StringFormat();
                m_sf.Alignment = StringAlignment.Center;
                m_sf.LineAlignment = StringAlignment.Center;
            }

            private void DrawHeader(Graphics g, Font m_fontNormal, ref int p_intPosY)
            {
                string[] m_strHeadNameArr = new string[] { "日期", "时间", "血压", "体温", "脉搏", "宫缩", "出血", "破水", "胎心", "宫口大小", "签名" };
                

                p_intPosY += 5;
                RectangleF m_rtgF = new RectangleF(m_floatLeftXArr[0], p_intPosY, m_floatTotalWidth, 30);
                g.DrawString("引产后观察记录", new Font("", 15), Brushes.Black, m_rtgF, m_sf);
                p_intPosY += 35;

                m_rtgF.Y = p_intPosY;
                m_rtgF.Height = m_intHeadHeight;
                for (int iCol = 0; iCol < m_floatLeftXArr.Length; iCol++)
                {
                    m_rtgF.X = m_floatLeftXArr[iCol];
                    m_rtgF.Width = m_floatWidthArr[iCol];
                    g.DrawRectangle(Pens.Black, m_rtgF.X, m_rtgF.Y, m_rtgF.Width, m_rtgF.Height);
                    g.DrawString(m_strHeadNameArr[iCol], m_fontNormal, Brushes.Black, m_rtgF, m_sf);
                }
                p_intPosY += m_intHeadHeight;
            }

            private void DrawAllLines(Graphics g, int p_intPosY)
            {
                for (int iCol = 0; iCol < m_floatLeftXArr.Length; iCol++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[iCol], p_intPosY, m_floatLeftXArr[iCol], p_intPosY + m_intRowHeight * m_intRowCount);
                }
                g.DrawLine(Pens.Black, m_floatLeftXArr[0] + m_floatTotalWidth, p_intPosY, m_floatLeftXArr[0] + m_floatTotalWidth, p_intPosY + m_intRowHeight * m_intRowCount);

                for (int iRow = 1; iRow <= m_intRowCount; iRow++)
                {
                    g.DrawLine(Pens.Black, m_floatLeftXArr[0], p_intPosY + iRow * m_intRowHeight, m_floatLeftXArr[0] + m_floatTotalWidth, p_intPosY + iRow * m_intRowHeight);
                }
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                DrawHeader(p_objGrp, p_fntNormalText, ref p_intPosY);

                DrawAllLines(p_objGrp, p_intPosY);

                RectangleF m_rtgF = new RectangleF();

                #region 打印记录

                string[][] m_strKeyArr = new string[][] { new string[] { "引产后观察记录>>日期1", "引产后观察记录>>时间1", "引产后观察记录>>血压1", "引产后观察记录>>体温1", "引产后观察记录>>脉搏1", "引产后观察记录>>宫缩1", "引产后观察记录>>出血1", "引产后观察记录>>破水1", "引产后观察记录>>胎心1", "引产后观察记录>>宫口大小1", "引产后观察记录>>签名1" },
                                                          new string[] { "引产后观察记录>>日期2", "引产后观察记录>>时间2", "引产后观察记录>>血压2", "引产后观察记录>>体温2", "引产后观察记录>>脉搏2", "引产后观察记录>>宫缩2", "引产后观察记录>>出血2", "引产后观察记录>>破水2", "引产后观察记录>>胎心2", "引产后观察记录>>宫口大小2", "引产后观察记录>>签名2" },
                                                          new string[] { "引产后观察记录>>日期3", "引产后观察记录>>时间3", "引产后观察记录>>血压3", "引产后观察记录>>体温3", "引产后观察记录>>脉搏3", "引产后观察记录>>宫缩3", "引产后观察记录>>出血3", "引产后观察记录>>破水3", "引产后观察记录>>胎心3", "引产后观察记录>>宫口大小3", "引产后观察记录>>签名3" },
                                                          new string[] { "引产后观察记录>>日期4", "引产后观察记录>>时间4", "引产后观察记录>>血压4", "引产后观察记录>>体温4", "引产后观察记录>>脉搏4", "引产后观察记录>>宫缩4", "引产后观察记录>>出血4", "引产后观察记录>>破水4", "引产后观察记录>>胎心4", "引产后观察记录>>宫口大小4", "引产后观察记录>>签名4" },
                                                          new string[] { "引产后观察记录>>日期5", "引产后观察记录>>时间5", "引产后观察记录>>血压5", "引产后观察记录>>体温5", "引产后观察记录>>脉搏5", "引产后观察记录>>宫缩5", "引产后观察记录>>出血5", "引产后观察记录>>破水5", "引产后观察记录>>胎心5", "引产后观察记录>>宫口大小5", "引产后观察记录>>签名5" },
                                                          new string[] { "引产后观察记录>>日期6", "引产后观察记录>>时间6", "引产后观察记录>>血压6", "引产后观察记录>>体温6", "引产后观察记录>>脉搏6", "引产后观察记录>>宫缩6", "引产后观察记录>>出血6", "引产后观察记录>>破水6", "引产后观察记录>>胎心6", "引产后观察记录>>宫口大小6", "引产后观察记录>>签名6" } };
               
                
                m_rtgF.Height = m_intRowHeight;
                for (int index = 0; index < m_strKeyArr.Length; index++)
                {
                    m_rtgF.Y = p_intPosY + index * m_intRowHeight;
                    for (int iCol = 0; iCol < m_floatLeftXArr.Length; iCol++)
                    {
                        m_rtgF.X = m_floatLeftXArr[iCol];
                        m_rtgF.Width = m_floatWidthArr[iCol];
                        if (m_hasItems.Contains(m_strKeyArr[index][iCol]))
                        {
                            
                            p_objGrp.DrawString((m_hasItems[m_strKeyArr[index][iCol]] as clsInpatMedRec_Item).m_strItemContent, p_fntNormalText, Brushes.Black, m_rtgF, m_sf);
                        }
                    }
                }
                p_intPosY += m_intRowHeight * m_intRowCount;
                p_intPosY += 10;
                
                #endregion

                m_blnHaveMoreLine = false;

            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }



        }
        #endregion

        #region 打印引产分娩记录
        /// <summary>
        /// 打印引产分娩记录
        /// </summary>
        internal class clsPrintInduceRecord : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
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
                    m_mthMakeText(new string[] { "宫缩开始时间：", "破 膜 时 间 ：", "\n胎儿娩出时间：", "胎盘娩出时间：" },
                        new string[] { "引产分娩记录>>宫缩开始时间", "引产分娩记录>>破膜时间", "引产分娩记录>>胎儿娩出时间", "引产分娩记录>>胎盘娩出时间" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeCheckText(new string[] { "\n胎儿娩出方式：", "引产分娩记录>>胎儿娩出方式>>自然", "引产分娩记录>>胎儿娩出方式>>人工" }, ref m_strAllText, ref m_strAllXml);

                    m_mthMakeText(new string[] { "胎儿：", "身长：", "cm；$$", "  脚底长：", "胎盘：", "胎膜：", "\n产后: BP:", "mmHg$$", " P：", "分/次$$", " R：", "分/次$$", "\n产后出血量(估计)：", "ml；  宫缩剂：$$", "剂量：" },
                        new string[] { "引产分娩记录>>胎儿", "引产分娩记录>>身长", "", "引产分娩记录>>脚底长", "引产分娩记录>>胎盘", "引产分娩记录>>胎膜", "引产分娩记录>>产后>>BP", "", "引产分娩记录>>产后>>P", "", "引产分娩记录>>产后>>R", "", "引产分娩记录>>产后出血量", "引产分娩记录>>宫缩剂", "引产分娩记录>>剂量" }, ref m_strAllText, ref m_strAllXml);

                    string m_strPrint = "\n产后软产道检查：";
                    if (m_hasItems.Contains("引产分娩记录>>产后软产道检查>>正常"))
                        m_strPrint += "正常";
                    else if (m_hasItems.Contains("引产分娩记录>>产后软产道检查>>异常"))
                    {
                        m_strPrint += "异常（详述）：";
                        if (m_hasItems.Contains("引产分娩记录>>产后软产道检查>>异常详述"))
                            m_strPrint += (m_hasItems["引产分娩记录>>产后软产道检查>>异常详述"] as clsInpatMedRec_Item).m_strItemContent;
                    }

                    m_mthMakeText(new string[] { m_strPrint, "\n清宫：", "原因：", "宫腔术前：", "cm$$", "术后：", "cm$$", "\n刮出组织物：", "g$$" },
                        new string[] { "", "引产分娩记录>>清宫", "引产分娩记录>>原因", "引产分娩记录>>宫腔术前", "", "引产分娩记录>>术后", "", "引产分娩记录>>刮出组织物", "" }, ref m_strAllText, ref m_strAllXml);

                    m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strAllText, m_strAllXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    int m_intRealHeight = 25;
                    Rectangle m_rtg = new Rectangle(m_intPatientInfoX, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRealHeight);
                    m_objPrintContext.m_blnPrintAllBySimSun(p_fntNormalText.Size, m_rtg, p_objGrp, out m_intRealHeight, false);
                    if (m_intRealHeight > 25)
                        p_intPosY += m_intRealHeight;
                    else
                        p_intPosY += 25;

                    //if (m_hasItems != null)
                    //{
                    //    string m_strPrint;
                    //    m_strPrint = "接胎者：";
                    //    if (m_hasItems.Contains("引产分娩记录>>接胎者"))
                    //        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["引产分娩记录>>接胎者"]).m_strItemContent;
                    //    else
                    //        m_strPrint += "        ";
                    //    m_strPrint += "   刮宫者签名:";
                    //    if (m_hasItems.Contains("引产分娩记录>>刮宫者"))
                    //        m_strPrint += ((clsInpatMedRec_Item)m_hasItems["引产分娩记录>>刮宫者"]).m_strItemContent;

                    //    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                    //    p_intPosY += 25;
                    //}
                    m_blnHaveMoreLine = false;
                }

            }
        }

        #endregion

        /// <summary>
        /// 签名
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
                    p_intPosY += 20;
                    string strHelpers = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("接胎者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 80, p_intPosY, p_objGrp);
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


        private class clsPrint12 : clsIMR_PrintLineBase
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
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvOperations")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("刮宫者：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 420, p_intPosY, p_objGrp);
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
