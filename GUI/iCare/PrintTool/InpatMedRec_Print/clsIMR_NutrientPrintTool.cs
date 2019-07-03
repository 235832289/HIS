using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.controls;
using iCareData;
using System.Drawing;
using System.Collections;

namespace iCare
{
    public class clsIMR_NutrientPrintTool : clsInpatMedRecPrintBase
    {
        public clsIMR_NutrientPrintTool(string p_strTypeID) : base(p_strTypeID)
		{}
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 5, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 15, e.PageBounds.Height - 315);
        }
        protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            int p_intPosY = 40;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), Brushes.Black, 340, p_intPosY);
            p_intPosY += 30;
            e.Graphics.DrawString("急     诊     病     历", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 280, p_intPosY);
        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{　
																		   new clsPrintInPatMedRecMain(),
																		   new clsPrintInPatMedRecBodyCheck(),
																		   new clsPrintInPatMedRecPrimaryDiagnosis()
				                                             								       
																	   });

        }

        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrintInPatMedRecMain : clsIMR_PrintLineBase
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
                    if (m_hasItems.Contains("主诉"))
                        objItemContent = m_hasItems["主诉"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;

                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("主诉：", m_objPrintContext.m_ObjModifyUserArr);


                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
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
        /// 体征
        /// </summary>
        private class clsPrintInPatMedRecBodyCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool[] m_blnIsFirstPrint = new Boolean[] { true, true, true };
            private string strPrintText = "  　 　　    ";
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            private int m_intFlag = 0;


            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_blnIsFirstPrint[0])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail.Contains("体征>>T"))
                        strPrintText += "T:" + m_hasItemDetail["体征>>T"] + "℃      ";
                    if (m_hasItemDetail.Contains("体征>>P"))
                        strPrintText += "P:" + m_hasItemDetail["体征>>P"] + "次/分      ";
                    if (m_hasItemDetail.Contains("体征>>R"))
                        strPrintText += "R:" + m_hasItemDetail["体征>>R"] + "次/分      ";
                    if (m_hasItemDetail.Contains("体征>>BP"))
                        strPrintText += "Bp:" + m_hasItemDetail["体征>>BP"] + "mmHg";
                    if (strPrintText != "  　 　　    ")
                    {
                        p_objGrp.DrawString("体    征:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                        m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                    }
                    m_blnIsFirstPrint[0] = false;
                }
                if (m_blnIsFirstPrint[1])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    strPrintText = "  　     ";
                    if (m_hasItemDetail.Contains("神志>>清醒"))
                        strPrintText += "清醒   ";
                    if (m_hasItemDetail.Contains("神志>>模糊"))
                        strPrintText += "模糊   ";
                    if (m_hasItemDetail.Contains("神志>>昏迷"))
                        strPrintText += "昏迷   ";
                    if (m_hasItemDetail.Contains("抽搐"))
                        strPrintText += "抽搐   ";
                    if (m_hasItemDetail.Contains("黄疸"))
                        strPrintText += "黄疸   ";
                    if (m_hasItemDetail.Contains("贫血"))
                        strPrintText += "贫血   ";
                    if (m_hasItemDetail.Contains("出血1"))
                        strPrintText += m_hasItemDetail["出血1"];
                    if (m_hasItemDetail.Contains("出血"))
                        strPrintText += "出血   ";
                    if (m_hasItemDetail.Contains("淋巴节肿大1"))
                        strPrintText += m_hasItemDetail["淋巴节肿大1"];
                    if (m_hasItemDetail.Contains("淋巴节肿大"))
                        strPrintText += "淋巴节肿大";
                    if (strPrintText != "  　     ")
                    {
                        p_objGrp.DrawString("神    志:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                        m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                    }
                    m_blnIsFirstPrint[1] = false;
                }
                if (m_blnIsFirstPrint[2])
                {
                    if (m_blnCheckBottom(ref p_intPosY, 20, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    strPrintText = "  　     ";
                    if (m_hasItemDetail.Contains("瞳孔>>左"))
                        strPrintText += "左:" + m_hasItemDetail["瞳孔>>左"] + " mm "; ;
                    if (m_hasItemDetail.Contains("瞳孔>>右"))
                        strPrintText += "右:" + m_hasItemDetail["瞳孔>>右"] + " mm";
                    if (strPrintText != "  　     ")
                    {
                        p_objGrp.DrawString("瞳    孔:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                        m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        m_intFlag++;
                    }
                    strPrintText = "";
                    if (m_hasItemDetail.Contains("对光反射>>存在"))
                        strPrintText += "存在";
                    if (m_hasItemDetail.Contains("对光反射>>消失"))
                        strPrintText += "消失";
                    if (strPrintText != "")
                    {
                        if (m_intFlag == 1)
                        {
                            p_objGrp.DrawString("对光反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 20);
                            p_objGrp.DrawString(strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 380, p_intPosY - 20);
                        }
                        else
                        {
                            p_objGrp.DrawString("对光反射:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                            p_objGrp.DrawString(strPrintText, p_fntNormal, Brushes.Black, m_intRecBaseX + 120, p_intPosY);
                            p_intPosY += 20;
                        }
                    }
                    m_blnIsFirstPrint[2] = false;
                }
                p_fntNormal.Dispose();
                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = new Boolean[] { true, true, true };

            }
        }
        /// <summary>
        /// 初步诊断
        /// </summary>
        private class clsPrintInPatMedRecPrimaryDiagnosis : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("初步诊断"))
                        objItemContent = m_hasItems["初步诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 120, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }
                    p_objGrp.DrawString("初步诊断:", new Font("SimSun", 12), Brushes.Black, m_intRecBaseX + 20, p_intPosY);
                    if (m_hasItemDetail.Contains("初步诊断"))
                    {
                        strPrintText += m_hasItemDetail["初步诊断"];
                        p_intPosY += 20;
                    }
                    if (strPrintText != "   ") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                    string p_strText = "医生签名：    ";
                    if (m_hasItemDetail.Contains("医师签名"))
                        p_strText += m_hasItemDetail["医师签名"] + " ";
                    else
                        p_strText += "      ";
                    if (m_hasItemDetail.Contains("日期"))
                        p_strText += DateTime.Parse(m_hasItemDetail["日期"].ToString()).ToString("yyyy年MM月dd日");
                    else
                        p_strText += "200　年　月　日";
                    p_objGrp.DrawString(p_strText, p_fntNormal, Brushes.Black, (int)enmRectangleInfo.RightX - 300, p_intPosY);
                    p_fntNormal.Dispose();
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
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
        internal static Hashtable m_hasItemDetail;
        /// <summary>
        /// 把所有项按描述为键放入Hastable
        /// </summary>
        /// <param name="p_hasItem"></param>
        /// <param name="p_ctlItem"></param>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            if (p_objItemArr == null)
                return null;
            Hashtable hasItem = new Hashtable(400);
            m_hasItemDetail = new Hashtable(400);
            foreach (clsInpatMedRec_Item objItem in p_objItemArr)
            {
                try
                {
                    if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
                    {
                        continue;
                    }
                    else
                    {
                        m_hasItemDetail.Add(objItem.m_strItemName, objItem.m_strItemContent);
                        hasItem.Add(objItem.m_strItemName, objItem);

                    }
                }
                catch { continue; }
            }
            return hasItem;
        }
    }
}
