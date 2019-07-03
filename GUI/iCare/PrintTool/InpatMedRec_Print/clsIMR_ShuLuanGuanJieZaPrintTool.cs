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
    /// <summary>
    /// 伦教医院输卵管结扎手术记录表打印类
    /// </summary>
    class clsIMR_ShuLuanGuanJieZaPrintTool : clsInpatMedRecPrintBase
    {
        public bool m_blMarks = false;
        public clsIMR_ShuLuanGuanJieZaPrintTool(string p_strTypeID):base(p_strTypeID)
        {
            //
            // TODO: Add constructor logic here
            //
            m_strChildTitleName = "输卵管结扎手术记录表";
        }
        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                                              //new clsPrintPatientFixInfo("输卵管结扎手术记录表", 310),				                                                       
                                                              //new clsPrintJiWangShi("既往史","既往史："),
                                                              //new clsPrintCheck(),
                                                              //new clsPringLadyCheck(),
                                                              new clsPrintMoCiYueJin(),
                                                              new clsPrintMaZuiFangFa(),
                                                              new clsPrinTShuShiCheck(),
                                                              new clsPrintQuGuanFa(), 
                                                              new clsPrintBuWeu(),
                                                              new clsPrintJieZaXian(),
                                                              new clsPrintTimeShouShu(),
                                                            //  new clsPrintDocSign(),
                                                              new clsPrint11(),
                                                             new clsPrint12(),
                                                              new clsPrintTimeShouShu2(),
                                                            new clsPrint10(),
                                                           new clsPrintTimeShouShu3()
                });
        }
        #region 打印第一页的固定内容 不用
        ///// <summary>
        ///// 打印第一页的固定内容
        ///// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    bool m_blMarks1 = true;
        //    clsInpatMedRec_Item objItemContent1;
        //    clsInpatMedRec_Item objItemContent2;
        //    clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[5];
        //    bool m_blnIsFirstPrint = true;
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_hasItems != null)
        //        {
        //            if (m_hasItems.Contains("结扎既往史"))
        //                objItemContent1 = m_hasItems["结扎既往史"] as clsInpatMedRec_Item;
                    


        //        }
        //        //p_objGrp.DrawString("产科出院小结", m_fotItemHead, Brushes.Black, m_intRecBaseX + 290, p_intPosY - 10);
        //        //p_intPosY += 25;

        //        //p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
        //        //p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, 400, p_intPosY);
        //        //p_intPosY += 25;


        //        if (objItemContent1 != null)
        //        {
        //            p_objGrp.DrawString("住院日期：" + objItemContent1.m_strItemContent, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("住院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
        //        }

        //        string strRegisterID = "";
        //        long lngRes = 0;


        //        if (objItemContent2 != null)
        //        {
        //            p_objGrp.DrawString("至：" + objItemContent2.m_strItemContent, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
        //        }
        //        else
        //        {
        //            p_objGrp.DrawString("至：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
        //        }
        //        p_intPosY += 25;
        //        string m_strPrints = "";
        //        if (this.m_blMarks1 == true)
        //        {
        //            m_strPrints = "住院天数：" + (objItemContent[0] == null ? "      " : objItemContent[0].m_strItemContent) + "天, 第"
        //                + (objItemContent[1] == null ? "     " : objItemContent[1].m_strItemContent) + "孕" +
        //                (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + "产, 宫内妊娠"
        //                + (objItemContent[3] == null ? "    " : objItemContent[3].m_strItemContent) + "周， 于" +
        //                (objItemContent[4] == null ? "     " : objItemContent[4].m_strItemContent) + "分娩。";

        //        }
        //        else
        //        {
        //            m_strPrints = "住院天数：" + objItemContent[0].m_strItemContent + "天, 第" + objItemContent[1].m_strItemContent + "孕" +
        //                        objItemContent[2].m_strItemContent + "产, 宫内妊娠" + objItemContent[3].m_strItemContent + "周， 于" +
        //                        objItemContent[4].m_strItemContent + "分娩。";

        //        }

        //        p_objGrp.DrawString(m_strPrints, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);



        //        p_intPosY += 30;
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}
        #endregion

        #region 既往史
        /// <summary>
        /// 既往史
        /// </summary>
        private class clsPrintJiWangShi : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item objItemContent1;
            bool m_blYouHeng = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            string hasname = "";
            string printtitle = "";
            public clsPrintJiWangShi(string name,string title)
            {
                hasname = name;
                printtitle = title;
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains(hasname))
                        objItemContent1 = m_hasItems[hasname] as clsInpatMedRec_Item;
                }
                if (m_blnIsFirstPrint)
                {
                    if (printtitle == "既往史：")
                        p_intPosY -= 30;


                    p_intPosY += 25;
                    p_objGrp.DrawString(printtitle, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_blnIsFirstPrint = false;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
				
                }
                
                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                   
                    p_intPosY += 25;
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
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
                m_blnHaveMoreLine = true;
            }
            
        }
        #endregion

        #region 体格检查
        /// <summary>
        /// 体格检查 
        /// </summary>
        class clsPrintCheck : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent=new clsInpatMedRec_Item[8];
            //bool m_blYouHeng = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("体检>>T"))
                        objItemContent[0] = m_hasItems["体检>>T"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>R"))
                        objItemContent[1] = m_hasItems["体检>>R"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>P"))
                        objItemContent[2] = m_hasItems["体检>>P"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>BP>>舒张压"))
                        objItemContent[3] = m_hasItems["体检>>BP>>舒张压"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>BP>>收缩压"))
                        objItemContent[4] = m_hasItems["体检>>BP>>收缩压"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>心"))
                        objItemContent[5] = m_hasItems["体检>>心"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>肺"))
                        objItemContent[6] = m_hasItems["体检>>肺"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体检>>腹"))
                        objItemContent[7] = m_hasItems["体检>>腹"] as clsInpatMedRec_Item;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 25;
                    string strPrint = "体检： ";
                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    int temHeight = 20;

                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append(" T：").Append(objItemContent[0] == null ? "  " : objItemContent[0].m_strItemContent).Append("℃   R：").Append(objItemContent[1] == null ? "  " : objItemContent[1].m_strItemContent);
                    strBuilder.Append("次/分  P：").Append(objItemContent[2] == null ? "  " : objItemContent[2].m_strItemContent).Append("次/分  BP：").Append(objItemContent[3] == null ? "  " : objItemContent[3].m_strItemContent).Append("/").Append(objItemContent[4] == null ? "  " : objItemContent[4].m_strItemContent).Append("mmHg");
                    strBuilder.Append("   心：").Append(objItemContent[6] == null ? "      " : objItemContent[6].m_strItemContent).Append("   肺：").Append(objItemContent[6] == null ? "      " : objItemContent[6].m_strItemContent).Append("   腹：").Append(objItemContent[7] == null ? "      " : objItemContent[7].m_strItemContent);

                    strPrint = strBuilder.ToString();
                    Rectangle rtgPrint = new Rectangle(m_intPatientInfoX + 60, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 40, 13);
                    
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strPrint, "<root />" , m_dtmFirstPrintTime, true);
                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgPrint, p_objGrp, out temHeight, false);
                    if (temHeight > 25)
                        p_intPosY += temHeight;
                    else
                        p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                    m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        
        #region 妇检
        /// <summary>
        /// 妇检
        /// </summary>
        class clsPringLadyCheck : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[5];
            
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("妇检>>外阴"))
                        objItemContent[0] = m_hasItems["妇检>>外阴"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("妇检>>阴道"))
                        objItemContent[1] = m_hasItems["妇检>>阴道"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("妇检>>宫颈"))
                        objItemContent[2] = m_hasItems["妇检>>宫颈"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("妇检>>子宫"))
                        objItemContent[3] = m_hasItems["妇检>>子宫"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("妇检>>附件"))
                        objItemContent[4] = m_hasItems["妇检>>附件"] as clsInpatMedRec_Item;
                }   
                if (m_blnIsFirstPrint)
                {
                    //p_intPosY += 25;
                    string m_strPrint = "妇检：";
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    int temHeight = 20;
                    StringBuilder m_strBuilder = new StringBuilder();

                    m_strBuilder.Append(" 外阴：").Append(objItemContent[0] == null ? "     " : objItemContent[0].m_strItemContent).Append("  阴道：").Append(objItemContent[1] == null ? "     " : objItemContent[1].m_strItemContent);
                    m_strBuilder.Append("  宫颈：").Append(objItemContent[2] == null ? "     " : objItemContent[2].m_strItemContent).Append("  子宫：").Append(objItemContent[3] == null ? "     " : objItemContent[3].m_strItemContent);
                    m_strBuilder.Append("  附件：").Append(objItemContent[4] == null ? "     " : objItemContent[4].m_strItemContent);

                    m_strPrint = m_strBuilder.ToString();
                    Rectangle rtgPrint = new Rectangle(m_intPatientInfoX + 60, p_intPosY, (int)enmRectangleInfoInPatientCaseInfo.PrintWidth, 13);

                    m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strPrint, "<root />", m_dtmFirstPrintTime, true);
                    m_objPrintContext.m_blnPrintAllBySimSun(11, rtgPrint, p_objGrp, out temHeight, false);
                    if (temHeight > 25)
                        p_intPosY += temHeight;
                    else
                        p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        #endregion

        #region 末次月经,绝育指征，末次月经
        /// <summary>
        /// 末次月经,绝育指征，末次月经
        /// </summary>
        class clsPrintMoCiYueJin : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[5];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("末次月经"))
                        objItemContent[0] = m_hasItems["末次月经"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术日期"))
                        objItemContent[1] = m_hasItems["手术日期"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("绝经指征"))
                        objItemContent[2] = m_hasItems["绝经指征"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("末次月经2"))
                        objItemContent[3] = m_hasItems["末次月经2"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术日期2"))
                        objItemContent[4] = m_hasItems["手术日期2"] as clsInpatMedRec_Item;
                    
                }
                if (m_blnIsFirstPrint)
                {
                    // 末次月经
                    //string m_strMtmp = "末次月经： " + (objItemContent[0] == null ? "     年    月   日 " : Convert.ToDateTime(objItemContent[0].m_strItemContent).ToString(" yyyy年MM月dd日 ")) + "      手术日期： " + (objItemContent[1] == null ? "     年    月   日 " : Convert.ToDateTime(objItemContent[1].m_strItemContent).ToString(" yyyy年MM月dd日 "));
                    ////p_intPosY += 25;
                    //p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    // 绝经指征
                    string m_strMtmp = "绝育指征： " + (objItemContent[2] == null ? "" : objItemContent[2].m_strItemContent);
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    // 末次月经2
                    m_strMtmp = "末次月经： " + (objItemContent[3] == null ? "     年    月   日 " : Convert.ToDateTime(objItemContent[3].m_strItemContent).ToString(" yyyy年MM月dd日 ")) + "      手术日期： " + (objItemContent[4] == null ? "     年    月   日 " : Convert.ToDateTime(objItemContent[4].m_strItemContent).ToString(" yyyy年MM月dd日 "));
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        
        #region 手术前用药，麻醉方法 麻醉剂量
        /// <summary>
        /// 手术前用药，麻醉方法 麻醉剂量
        /// </summary>
        class clsPrintMaZuiFangFa : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[6];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("手术前用药"))
                        objItemContent[0] = m_hasItems["手术前用药"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("麻醉方法"))
                        objItemContent[1] = m_hasItems["麻醉方法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("麻醉用药"))
                        objItemContent[2] = m_hasItems["麻醉用药"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("麻醉剂量"))
                        objItemContent[3] = m_hasItems["麻醉剂量"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("麻醉效果"))
                        objItemContent[4] = m_hasItems["麻醉效果"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("腹部切口部位"))
                        objItemContent[5] = m_hasItems["腹部切口部位"] as clsInpatMedRec_Item;

                }
                if (m_blnIsFirstPrint)
                {
                    string m_strMtmp = "手术前用药： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strMtmp = "麻醉方法： " + (objItemContent[1] == null ? "               " : objItemContent[1].m_strItemContent) + "     麻醉用药： " + (objItemContent[2] == null ? "  " : objItemContent[2].m_strItemContent);
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strMtmp = "麻醉剂量：" + (objItemContent[3] == null ? "          " : objItemContent[3].m_strItemContent) + "     效果： " + (objItemContent[4] == null ? "          " : objItemContent[4].m_strItemContent) + "    腹部切口部位： " + (objItemContent[5] == null ? "" : objItemContent[5].m_strItemContent);
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
       
        #region 麻醉2不用
        /// <summary>
        /// 麻醉2
        /// </summary>
        //class clsPringMaZuiPartTwo : clsIMR_PrintLineBase
        //{
        //    clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[3];
        //    bool m_blYouHeng = true;
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
        //    bool m_blnIsFirstPrint = true;
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_hasItems != null)
        //        {
        //            if (m_hasItems.Contains("麻醉剂量"))
        //                objItemContent[0] = m_hasItems["麻醉剂量"] as clsInpatMedRec_Item;
        //            if (m_hasItems.Contains("效果"))
        //                objItemContent[1] = m_hasItems["效果"] as clsInpatMedRec_Item;
        //            if (m_hasItems.Contains("腹部切口部位"))
        //                objItemContent[2] = m_hasItems["腹部切口部位"] as clsInpatMedRec_Item;

        //        }
        //        if (m_blnIsFirstPrint)
        //        {
        //            p_intPosY += 25;
        //            string m_strMtmp = "麻醉剂量：  " + (objItemContent[0] == null ? "  " : objItemContent[0].m_strItemContent) + " 效果： " + (objItemContent[1] == null ? "  " : objItemContent[1].m_strItemContent)
        //                + " 腹部切口部位： " + (objItemContent[2] == null ? "  " : objItemContent[2].m_strItemContent);

        //            p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
        //            m_blnIsFirstPrint = false;
        //            //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

        //        }

        //        //int intLine = 0;
        //        //if (m_objPrintContext.m_BlnHaveNextLine())
        //        //{
        //        //    p_intPosY += 25;
        //        //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
        //        //    intLine++;
        //        //}
        //        //if (m_objPrintContext.m_BlnHaveNextLine())
        //        //    m_blnHaveMoreLine = true;
        //        //else
        //        //{
        //        m_blnHaveMoreLine = false;
        //        //}
        //    }
        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}
        #endregion

        #region 术时检查
        /// <summary>
        /// 术时检查
        /// </summary>
        class clsPrinTShuShiCheck : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[5];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("术时检查>>输卵管>>左"))
                        objItemContent[0] = m_hasItems["术时检查>>输卵管>>左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("术时检查>>输卵管>>右"))
                        objItemContent[1] = m_hasItems["术时检查>>输卵管>>右"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("术时检查>>卵巢>>左"))
                        objItemContent[2] = m_hasItems["术时检查>>卵巢>>左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("术时检查>>卵巢>>右"))
                        objItemContent[3] = m_hasItems["术时检查>>卵巢>>右"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("术时检查>>子宫"))
                        objItemContent[4] = m_hasItems["术时检查>>子宫"] as clsInpatMedRec_Item;
                    

                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("术时检查： 输卵管：左： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("右： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+380, p_intPosY);

                    p_intPosY += 25;
                    p_objGrp.DrawString("  卵巢：左： " + (objItemContent[2] == null ? "" : objItemContent[2].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 95, p_intPosY);
                    p_objGrp.DrawString("右： " + (objItemContent[3] == null ? "" : objItemContent[3].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 380, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("  子宫： " + (objItemContent[4] == null ? "" : objItemContent[4].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 95, p_intPosY);
                    p_intPosY += 25;
                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[4] == null ? "" : objItemContent[4].m_strItemContent), (objItemContent[4] == null ? "<root />" : objItemContent[4].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }
                m_blnHaveMoreLine = false;

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    if (intLine == 0)
                //    {
                //        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 200, m_intRecBaseX + 155, p_intPosY, p_objGrp);
                //        p_intPosY += 25;
                //    }
                //    else
                //    {
                //        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 85, m_intRecBaseX + 85, p_intPosY, p_objGrp);
                //        p_intPosY += 25;
                //    }
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                //m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion

        #region 取管法,手术方式
        /// <summary>
        /// 取管法，手术方式
        /// </summary>
        class clsPrintQuGuanFa : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[10];
            bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("取管法>>指板法"))
                        objItemContent[0] = m_hasItems["取管法>>指板法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("取管法>>吊钩法"))
                        objItemContent[1] = m_hasItems["取管法>>吊钩法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("取管法>>圆钳夹取法"))
                        objItemContent[2] = m_hasItems["取管法>>圆钳夹取法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("取管法>>其他"))
                        objItemContent[3] = m_hasItems["取管法>>其他"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("取管法>>其他内容"))
                        objItemContent[4] = m_hasItems["取管法>>其他内容"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术方式>>近端包埋法"))
                        objItemContent[5] = m_hasItems["手术方式>>近端包埋法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术方式>>银夹法"))
                        objItemContent[6] = m_hasItems["手术方式>>银夹法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术方式>>改良普氏法"))
                        objItemContent[7] = m_hasItems["手术方式>>改良普氏法"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术方式>>其他"))
                        objItemContent[8] = m_hasItems["手术方式>>其他"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术方式>>其他内容"))
                        objItemContent[9] = m_hasItems["手术方式>>其他内容"] as clsInpatMedRec_Item;

                }
                if (m_blnIsFirstPrint)
                {
                    string m_strtemp = "";
                    if (objItemContent[0] != null)
                        m_strtemp += " 指板法";
                    if (objItemContent[1] != null)
                        m_strtemp += "   吊钩法";
                    if (objItemContent[2] != null)
                        m_strtemp += "   圆钳夹取法";
                    if (objItemContent[3] != null)
                        m_strtemp += "    其他：";
                    if (objItemContent[4] != null && objItemContent[4].m_strItemContent != "")
                        m_strtemp += objItemContent[4].m_strItemContent;

                    string m_strMtmp = "取管法：   " + m_strtemp;
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strtemp = "";
                    if (objItemContent[5] != null)
                        m_strtemp += "  近端包埋法";
                    if (objItemContent[6] != null)
                        m_strtemp += "   银夹法";
                    if (objItemContent[7] != null)
                        m_strtemp += "   改良普氏法";
                    if (objItemContent[8] != null)
                        m_strtemp += "    其他：";
                    if (objItemContent[9] != null && objItemContent[9].m_strItemContent != "")
                        m_strtemp += objItemContent[9].m_strItemContent;

                    m_strMtmp = "手术方式： " + m_strtemp;

                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_blnIsFirstPrint = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        
        #region 结扎输卵管部位
        /// <summary>
        /// 结扎输卵管部位
        /// </summary>
        class clsPrintBuWeu : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[4];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("结扎输卵管部位>>左"))
                        objItemContent[0] = m_hasItems["结扎输卵管部位>>左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("结扎输卵管部位>>右"))
                        objItemContent[1] = m_hasItems["结扎输卵管部位>>右"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("切除长度>>左"))
                        objItemContent[2] = m_hasItems["切除长度>>左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("切除长度>>右"))
                        objItemContent[3] = m_hasItems["切除长度>>右"] as clsInpatMedRec_Item;


                }
                if (m_blnIsFirstPrint)
                {
                    string m_strMtmp = "结扎输卵管部位：左：" + (objItemContent[0] == null ? "        " : objItemContent[0].m_strItemContent) + "  右：" + (objItemContent[1] == null ? "  " : objItemContent[1].m_strItemContent);
                    string m_strMtmp1 = "切除长度： 左：" + (objItemContent[2] == null ? "        " : (objItemContent[2].m_strItemContent + "cm")) + "  右：" + (objItemContent[3] == null ? "  " : objItemContent[3].m_strItemContent + " cm");
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp1, p_fntNormalText, Brushes.Black, m_intPatientInfoX+400, p_intPosY);
                    p_intPosY += 25;
                   
                    
                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        

        #region 输卵管结扎线
        /// <summary>
        /// 输卵管结扎线
        /// </summary>
        class clsPrintJieZaXian : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[12];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("输卵管结扎线>>丝线>>左"))
                        objItemContent[0] = m_hasItems["输卵管结扎线>>丝线>>左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>左系膜内平行血管>>扎"))
                        objItemContent[1] = m_hasItems["输卵管结扎线>>左系膜内平行血管>>扎"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("输卵管结扎线>>左系膜内平行血管>>未扎"))
                        objItemContent[2] = m_hasItems["输卵管结扎线>>左系膜内平行血管>>未扎"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>左纵行血管>>扎"))
                        objItemContent[3] = m_hasItems["输卵管结扎线>>左纵行血管>>扎"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("输卵管结扎线>>左纵行血管>>未扎"))
                        objItemContent[4] = m_hasItems["输卵管结扎线>>左纵行血管>>未扎"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>切除长度>>左"))
                        objItemContent[5] = m_hasItems["输卵管结扎线>>切除长度>>左"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("输卵管结扎线>>丝线>>右"))
                        objItemContent[6] = m_hasItems["输卵管结扎线>>丝线>>右"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>右系膜内平行血管>>扎"))
                        objItemContent[7] = m_hasItems["输卵管结扎线>>右系膜内平行血管>>扎"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("输卵管结扎线>>右系膜内平行血管>>未扎"))
                        objItemContent[8] = m_hasItems["输卵管结扎线>>右系膜内平行血管>>未扎"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>右纵行血管>>扎"))
                        objItemContent[9] = m_hasItems["输卵管结扎线>>右纵行血管>>扎"] as clsInpatMedRec_Item;


                    if (m_hasItems.Contains("输卵管结扎线>>右纵行血管>>未扎"))
                        objItemContent[10] = m_hasItems["输卵管结扎线>>右纵行血管>>未扎"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("输卵管结扎线>>切除长度>>右"))
                        objItemContent[11] = m_hasItems["输卵管结扎线>>切除长度>>右"] as clsInpatMedRec_Item;



                }
                if (m_blnIsFirstPrint)
                {
                    string m_strTemp = "";
                    string m_strMtmp = "左： 丝线 " + (objItemContent[0] == null ? "  " : objItemContent[0].m_strItemContent) + " 号";

                    if (objItemContent[1] != null)
                        m_strTemp += " 已扎 ";
                    if (objItemContent[2] != null)
                        m_strTemp += " 未扎 ";
                    string m_strMtmp1 = "系膜内平行血管： " + m_strTemp;

                    m_strTemp = "";
                    if (objItemContent[3] != null)
                        m_strTemp += " 已扎 ";
                    if (objItemContent[4] != null)
                        m_strTemp += " 未扎 ";
                    string m_strMtmp2 = "纵行血管： " + m_strTemp;
                    string m_strMtmp3 = "切除长度： " + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + " cm";
                    string m_strMtmp4 = "右： 丝线 " +  (objItemContent[6] == null ? "  " : objItemContent[6].m_strItemContent) + " 号";

                    m_strTemp = "";
                    if (objItemContent[7] != null)
                        m_strTemp += " 已扎 ";
                    if (objItemContent[8] != null)
                        m_strTemp += " 未扎 ";
                    string m_strMtmp5 = "系膜内平行血管： " + m_strTemp;

                    m_strTemp = "";
                    if (objItemContent[9] != null)
                        m_strTemp += " 已扎 ";
                    if (objItemContent[10] != null)
                        m_strTemp += " 未扎 ";
                    string m_strMtmp6 = "纵行血管： " + m_strTemp;
                    string m_strMtmp7 = "切除长度： " + (objItemContent[11] == null ? "  " : objItemContent[11].m_strItemContent) + " cm";

                    p_objGrp.DrawString("输卵管结扎线： ", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 400, p_intPosY);
                    p_intPosY += 25;

                    p_objGrp.DrawString(m_strMtmp2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp3, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 400, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString(m_strMtmp4, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp5, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 400, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString(m_strMtmp6, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY);
                    p_objGrp.DrawString(m_strMtmp7, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 400, p_intPosY);
                    p_intPosY += 25;
                   
                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        
        }
        #endregion
        
        #region 手术出血量，手术时处理，手术时间，手术者，助手，附加手术，特殊情况记录，手术者签名，签名日期
        /// <summary>
        /// 手术出血量，手术时处理，手术时间，
        /// </summary>
        class clsPrintTimeShouShu : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[3];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("手术出血量"))
                        objItemContent[0] = m_hasItems["手术出血量"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("手术时处理"))
                        objItemContent[1] = m_hasItems["手术时处理"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("手术时间"))
                        objItemContent[2] = m_hasItems["手术时间"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("手术者"))
                    //    objItemContent[3] = m_hasItems["手术者"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("助手"))
                    //    objItemContent[4] = m_hasItems["助手"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("附加手术"))
                    //    objItemContent[3] = m_hasItems["附加手术"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("特殊情况记录"))
                    //    objItemContent[4] = m_hasItems["特殊情况记录"] as clsInpatMedRec_Item;
                }
                if (m_blnIsFirstPrint)
                {
                    string m_strPrint = "手术出血量： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strPrint = "手术时处理： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent);
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strPrint = "手术时间： " + (objItemContent[2] == null ? "          " : (objItemContent[2].m_strItemContent + "    "));
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    //m_strPrint = "手术者：";
                    //if (m_hasItems.Contains("手术者"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    //m_strPrint = "助手：";
                    //if (m_hasItems.Contains("助手"))
                    //{
                    //    m_strPrint += (m_hasItems["助手"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 500, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "附加手术： " + (objItemContent[3] == null ? "" : objItemContent[3].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "特殊情况记录： " + (objItemContent[4] == null ? "" : objItemContent[4].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术者签名：";
                    //if (m_hasItems.Contains("手术者签名"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "签名日期：";
                    //if (m_hasItems.Contains("手术者签名日期"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者签名日期"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 附加手术，特殊情况记录
        /// </summary>
        class clsPrintTimeShouShu2 : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[2];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    //if (m_hasItems.Contains("手术出血量"))
                    //    objItemContent[0] = m_hasItems["手术出血量"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("手术时处理"))
                    //    objItemContent[1] = m_hasItems["手术时处理"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("手术时间"))
                    //    objItemContent[2] = m_hasItems["手术时间"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("手术者"))
                    //    objItemContent[3] = m_hasItems["手术者"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("助手"))
                    //    objItemContent[4] = m_hasItems["助手"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("附加手术"))
                        objItemContent[0] = m_hasItems["附加手术"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("特殊情况记录"))
                        objItemContent[1] = m_hasItems["特殊情况记录"] as clsInpatMedRec_Item;
                }
                if (m_blnIsFirstPrint)
                {
                    //string m_strPrint = "手术出血量： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术时处理： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术时间： " + (objItemContent[2] == null ? "          " : (objItemContent[2].m_strItemContent + "    "));
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    //m_strPrint = "手术者：";
                    //if (m_hasItems.Contains("手术者"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    //m_strPrint = "助手：";
                    //if (m_hasItems.Contains("助手"))
                    //{
                    //    m_strPrint += (m_hasItems["助手"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 500, p_intPosY);
                    //p_intPosY += 25;

                    string m_strPrint = "附加手术： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    m_strPrint = "特殊情况记录： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent);
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;

                    //m_strPrint = "手术者签名：";
                    //if (m_hasItems.Contains("手术者签名"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "签名日期：";
                    //if (m_hasItems.Contains("手术者签名日期"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者签名日期"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        class clsPrintTimeShouShu3 : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[1];
            //bool m_blYouHeng = true;
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    //if (m_hasItems.Contains("手术出血量"))
                    //    objItemContent[0] = m_hasItems["手术出血量"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("手术时处理"))
                    //    objItemContent[1] = m_hasItems["手术时处理"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("手术时间"))
                    //    objItemContent[2] = m_hasItems["手术时间"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("手术者"))
                    //    objItemContent[3] = m_hasItems["手术者"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("助手"))
                    //    objItemContent[4] = m_hasItems["助手"] as clsInpatMedRec_Item;
                    //if (m_hasItems.Contains("附加手术"))
                    //    objItemContent[0] = m_hasItems["附加手术"] as clsInpatMedRec_Item;

                    //if (m_hasItems.Contains("特殊情况记录"))
                    //    objItemContent[1] = m_hasItems["特殊情况记录"] as clsInpatMedRec_Item;
                }
                if (m_blnIsFirstPrint)
                {
                    //string m_strPrint = "手术出血量： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术时处理： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术时间： " + (objItemContent[2] == null ? "          " : (objItemContent[2].m_strItemContent + "    "));
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    //m_strPrint = "手术者：";
                    //if (m_hasItems.Contains("手术者"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    //m_strPrint = "助手：";
                    //if (m_hasItems.Contains("助手"))
                    //{
                    //    m_strPrint += (m_hasItems["助手"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 500, p_intPosY);
                    //p_intPosY += 25;

                    //string m_strPrint = "附加手术： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "特殊情况记录： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent);
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_intPosY += 25;

                    //m_strPrint = "手术者签名：";
                    //if (m_hasItems.Contains("手术者签名"))
                    //{
                    //    m_strPrint += (m_hasItems["手术者签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //}
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_intPosY += 25;

                    string m_strPrint = "签名日期：";
                    if (m_hasItems.Contains("手术者签名日期"))
                    {
                        m_strPrint += (m_hasItems["手术者签名日期"] as clsInpatMedRec_Item).m_strItemContent;
                    }
                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;

                    m_blnIsFirstPrint = false;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    p_intPosY += 25;
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    intLine++;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                m_blnHaveMoreLine = false;
                //}
            }
            public override void m_mthReset()
            {
                //m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion
        

        #region 打印签名
        /// <summary>
        /// 手术者签名
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
                    string strOperations = "";
                    string strAllText = "";
                    string strXml = "";
                    for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    {
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvAnaesthetist")
                            strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strOperations != "")
                    {
                        p_objGrp.DrawString("手术者签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 120, p_intPosY, p_objGrp);
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
        ///手术者 签名
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
                        p_objGrp.DrawString("手术者:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                   // p_intPosY += 20;
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
                        if (m_objContent.objSignerArr[i].controlName == "m_lsvhelper")
                            strHelpers += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    }
                    if (strHelpers != "")
                    {
                        p_objGrp.DrawString("助手：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 215, p_intPosY);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 25, m_intRecBaseX + 265, p_intPosY, p_objGrp);
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
