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
    class clsIMR_PrintObstect_LJ : clsInpatMedRecPrintBase
    {
        public bool m_blMarks = false;
        public clsIMR_PrintObstect_LJ(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: Add constructor logic here
            //

        }
        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                                                          new clsPrintPatientFixInfo(),				                                                       
                                                                new clsPringInhospDetail(),
                                                                new clsPringOutDiagnose(),
                                                                new clsprintOutHosptalPartTwo("出院诊断２","出院诊断２－２","母 2、","婴 2、"),
                                                                
                                                                new clsprintOutHosptalPartTwo("出院诊断３","出院诊断３－３","母 3、","婴 3、"),
                                                                
                                                                new clsprintOutHosptalPartTwo("出院诊断４","出院诊断４－４","母 4、","婴 4、"),
                                                                                                                 
                                                                new clsprintOutHosptalPartTwo("出院诊断５","出院诊断５－５","母 5、","婴 5、"),
                                                               
                                                                new clsPrintNotisfys(),
                                                                new clsPrintDocSign1(),
                                                                new clsPrintChanHouCheck(),
                                                                new clsPrintDinogseHe(),
                                                                new clsPrintDealWith(),
                                                                new clsPringDocSigntwo()
                                                                
                });
        }
        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            bool m_blMarks = true;
            clsInpatMedRec_Item objItemContent1;
            clsInpatMedRec_Item objItemContent2;
            clsInpatMedRec_Item[] objItemContent=new clsInpatMedRec_Item[5];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
             
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("开始日期1"))
                        objItemContent1 = m_hasItems["开始日期1"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("结束日期"))
                        objItemContent2 = m_hasItems["结束日期"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("住院天数"))
                        objItemContent[0] = m_hasItems["住院天数"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("第几孕"))
                        objItemContent[1] = m_hasItems["第几孕"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("第几产"))
                        objItemContent[2] = m_hasItems["第几产"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("几周"))
                        objItemContent[3] = m_hasItems["几周"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("于日期"))
                        objItemContent[4] = m_hasItems["于日期"] as clsInpatMedRec_Item;
                    

                }
                //p_objGrp.DrawString("产科出院小结", m_fotItemHead, Brushes.Black, m_intRecBaseX + 290, p_intPosY - 10);
                //p_intPosY += 25;

                //p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                //p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, 400, p_intPosY);
                //p_intPosY += 25;


                if (objItemContent1 != null)
                {
                    p_objGrp.DrawString("住院日期：" + objItemContent1.m_strItemContent, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("住院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                }
                
                string strRegisterID = "";
                long lngRes = 0;


                if (objItemContent2 != null)
                {
                    p_objGrp.DrawString("至：" + objItemContent2.m_strItemContent, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("至：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                p_intPosY += 25;
                string m_strPrints = "";
                if (this.m_blMarks == true)
                {
                    m_strPrints = "住院天数：" + (objItemContent[0] == null ? "      " : objItemContent[0] .m_strItemContent)+ "天, 第"
                        + (objItemContent[1] == null ? "     " : objItemContent[1].m_strItemContent) + "孕" +
                        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent )+ "产, 宫内妊娠"
                        + (objItemContent[3] == null ? "    " : objItemContent[3].m_strItemContent) + "周， 于" +
                        (objItemContent[4] == null ? "     " : objItemContent[4].m_strItemContent )+ "分娩。";

                }
                else
                {
                    m_strPrints = "住院天数：" + objItemContent[0].m_strItemContent + "天, 第" + objItemContent[1].m_strItemContent + "孕" +
                                objItemContent[2].m_strItemContent + "产, 宫内妊娠" + objItemContent[3].m_strItemContent + "周， 于" +
                                objItemContent[4].m_strItemContent + "分娩。";

                }
                
                    p_objGrp.DrawString(m_strPrints, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                
                

                p_intPosY += 30;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        #endregion

        #region
        //入院、住院、治疗情况
        class clsPringInhospDetail : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item objItemContent1;
            clsInpatMedRec_Item objItemContent2;
            clsInpatMedRec_Item[] objItemContent=new clsInpatMedRec_Item[8];
            bool m_blYouHeng = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            bool m_blnIsFirstPrint = true;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("顺产"))
                        objItemContent1 = m_hasItems["顺产"] as clsInpatMedRec_Item;
                    else if(m_hasItems.Contains("臂牵引"))
                        objItemContent1 = m_hasItems["臂牵引"] as clsInpatMedRec_Item;
                    else if(m_hasItems.Contains("臂助产"))
                        objItemContent1 = m_hasItems["臂助产"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("钳产"))
                        objItemContent1 = m_hasItems["钳产"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("吸引产"))
                        objItemContent1 = m_hasItems["吸引产"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("剖腹产"))
                        objItemContent1 = m_hasItems["剖腹产"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("毁胎"))
                        objItemContent1 = m_hasItems["毁胎"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("其他"))
                        objItemContent1 = m_hasItems["其他"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("剖腹产"))
                    {
                        if (m_hasItems.Contains("宫下段"))
                            objItemContent2= m_hasItems["宫下段"] as clsInpatMedRec_Item;
                        else if (m_hasItems.Contains("腹膜外"))
                            objItemContent2 = m_hasItems["腹膜外"] as clsInpatMedRec_Item;
                        
                   
                    }

                    if (m_hasItems.Contains("会阴破损-I°"))
                        objItemContent[0] = m_hasItems["会阴破损-I°"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("会阴破损-II°"))
                        objItemContent[0] = m_hasItems["会阴破损-II°"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("会阴破损-III°"))
                        objItemContent[0] = m_hasItems["会阴破损-III°"] as clsInpatMedRec_Item;


                    if (m_hasItems.Contains("直切"))
                        objItemContent[1] = m_hasItems["直切"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("侧切"))
                        objItemContent[1] = m_hasItems["侧切"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("伤口愈合：I类"))
                        objItemContent[2] = m_hasItems["伤口愈合：I类"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("伤口愈合：II类"))
                        objItemContent[2] = m_hasItems["伤口愈合：II类"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("伤口愈合：III类"))
                        objItemContent[2] = m_hasItems["伤口愈合：III类"] as clsInpatMedRec_Item;


                    if (m_hasItems.Contains("甲"))
                        objItemContent[3] = m_hasItems["甲"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("乙"))
                        objItemContent[3] = m_hasItems["乙"] as clsInpatMedRec_Item;
                    else if (m_hasItems.Contains("丙"))
                        objItemContent[3] = m_hasItems["丙"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("男"))
                        objItemContent[4] = m_hasItems["男"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("女"))
                        objItemContent[5] = m_hasItems["女"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体重"))
                        objItemContent[6] = m_hasItems["体重"] as clsInpatMedRec_Item;

                    if (m_hasItems.Contains("出院时"))
                        objItemContent[7] = m_hasItems["出院时"] as clsInpatMedRec_Item;

                  
                }
                string m_strTmp1 = (objItemContent1 == null ? "  " : (objItemContent1.m_strItemName == "剖腹产" ? (objItemContent2 == null ? objItemContent1.m_strItemName : (objItemContent1.m_strItemName + "( " + objItemContent2.m_strItemName+" )")) : objItemContent1.m_strItemName))
                    + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemName) + ", 切开：" + (objItemContent[1] == null ? "   " : objItemContent[1].m_strItemName)+"。" ;
                string m_strTmp2 = 
                    (objItemContent[2] == null ? "伤口愈合：" : objItemContent[2].m_strItemName) + "," + (objItemContent[3] == null ? "" : objItemContent[3].m_strItemName) + "  级。" +
                    "新生儿情况：" + (objItemContent[4] == null ? "" : (objItemContent[4].m_strItemName + ", ")) + (objItemContent[5] == null ? "" : objItemContent[5].m_strItemName) + "， 体重：" +
                    (objItemContent[6] == null ? " " : objItemContent[6].m_strItemContent) + "kg 。";
                p_intPosY += 25;
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("入院、住院、治疗情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_blnIsFirstPrint = false;
                    p_intPosY += 25;
                    p_objGrp.DrawString("分娩方式："+m_strTmp1, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString( m_strTmp2, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    p_intPosY += 25;
                    p_objGrp.DrawString("出生时情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    m_blnIsFirstPrint = false;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[7] == null ? "" : objItemContent[7].m_strItemContent), (objItemContent[7] == null ? "<root />" : objItemContent[7].m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
				
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
            }

        }
        #endregion
        //出院诊断1部分
        #region
        class clsPringOutDiagnose : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent=new clsInpatMedRec_Item[7];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("出院诊断孕"))
                        objItemContent[0] = m_hasItems["出院诊断孕"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("出院诊断产"))
                        objItemContent[1] = m_hasItems["出院诊断产"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("出院诊断胎"))
                        objItemContent[2] = m_hasItems["出院诊断胎"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("出院诊断周"))
                        objItemContent[3] = m_hasItems["出院诊断周"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("出院诊断产"))
                        objItemContent[4] = m_hasItems["出院诊断产"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("出院诊断活婴"))
                        objItemContent[5] = m_hasItems["出院诊断活婴"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("婴儿１"))
                        objItemContent[6] = m_hasItems["婴儿１"] as clsInpatMedRec_Item;
     
                }
                string m_strOutone="";
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 25;
                    m_strOutone = "母 1、 " + (objItemContent[0] == null ? "   " : objItemContent[0].m_strItemContent) + " 孕" + (objItemContent[1] == null ? "  " : objItemContent[1].m_strItemContent) + " 产" +
                        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + " 胎宫内妊娠" + (objItemContent[3] == null ? "   " : objItemContent[3].m_strItemContent) + " 周" +
                        (objItemContent[4] == null ? "   " : objItemContent[4].m_strItemContent) + "产" + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + "活婴。";
                    //string m_strTmp2="婴儿：1、" +
                    //    (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent);
                    p_objGrp.DrawString(m_strOutone, p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 30, p_intPosY + 20, m_intPatientInfoX + 640, p_intPosY + 20);
                    p_objGrp.DrawString("婴 1、" + (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[6] == null ? " " : ("" + objItemContent[6].m_strItemContent)), (objItemContent[6] == null ? "<root />" : ( objItemContent[6].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
                    p_intPosY += 25;
                    m_blnIsFirstPrint = false;
                }
                
                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                    
                //    //m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    //p_intPosY += 25;
                //    //intLine++;
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
        //出院诊断部分
        #region
        class clsprintOutHosptalPartTwo : clsIMR_PrintLineBase
                {
                    string m_strHashtable="";
                    string m_strHashtable2 = "";
                    string m_title1 = "";
                    string m_title2 = "";
                    clsInpatMedRec_Item objItemContent;
                    clsInpatMedRec_Item objItemContent1;
                    bool m_blnIsFirstPrint = true;
                    

                    public clsprintOutHosptalPartTwo(string m_strCanshu,string m_strtmp2,string m_title,string m_title2)
                    {
                        m_strHashtable = m_strCanshu;
                        this.m_title1 = m_title;
                        this.m_title2 = m_title2;
                        m_strHashtable2 = m_strtmp2;
                    }
                    
                    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
                    {
                        if (m_hasItems != null)
                        {
                            if (m_hasItems.Contains(m_strHashtable))
                                objItemContent = m_hasItems[m_strHashtable] as clsInpatMedRec_Item;
                            if (m_hasItems.Contains(m_strHashtable2))
                                objItemContent1 = m_hasItems[m_strHashtable2] as clsInpatMedRec_Item;
                            
                        }
                        if (m_blnIsFirstPrint)
                        {
                            
                            p_objGrp.DrawString(m_title1 + (objItemContent == null ? "          " : objItemContent.m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                           // m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? " " : ("" + objItemContent.m_strItemContent)), (objItemContent == null ? "<root />" : (objItemContent.m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
        			
                            p_objGrp.DrawString(m_title2 + (objItemContent1 == null ? "" : objItemContent1.m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                            
                            //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? " " : ("" + objItemContent.m_strItemContent)), (objItemContent == null ? "<root />" : ( objItemContent.m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
                            p_intPosY += 25;
                            p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 30, p_intPosY-5, m_intPatientInfoX + 640, p_intPosY-5);

                        }
                        
                        //int intLine = 0;
                        //if (m_objPrintContext.m_BlnHaveNextLine())
                        //{
                        //    if (intLine == 0)
                        //    {
                        //        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 200, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                        //        p_intPosY += 25;
                        //    }
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
        //注意事项
        #region
        class clsPrintNotisfys : clsIMR_PrintLineBase
        {
            bool m_blnIsFirstPrint = true;
            clsInpatMedRec_Item objItemContent;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("产后注意４"))
                        objItemContent = m_hasItems["产后注意４"] as clsInpatMedRec_Item;

                }
                if (m_blnIsFirstPrint)
                {
                    //p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 30, p_intPosY + 30, m_intPatientInfoX + 640, p_intPosY + 30);

                    p_objGrp.DrawString("产后注意事项：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("1、产后42天到门诊检查", p_fntNormalText, Brushes.Black, m_intPatientInfoX+150, p_intPosY);
                    p_objGrp.DrawString("3、不适随查", p_fntNormalText, Brushes.Black, m_intPatientInfoX+400, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("2、注意产褥期营养卫生", p_fntNormalText, Brushes.Black, m_intPatientInfoX+150, p_intPosY);

                    p_objGrp.DrawString("4、" + (objItemContent==null?"":objItemContent.m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 400, p_intPosY);

                    p_intPosY += 25;
                    p_objGrp.DrawString("(注：出院时将此表交产妇保存，请产妇本人持本页记录产后42天到医院复诊)", p_fntNormalText, Brushes.Black, m_intPatientInfoX+100, p_intPosY);
                    p_intPosY += 25;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? " " : ("" + objItemContent.m_strItemContent)), (objItemContent == null ? "<root />" : (objItemContent.m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{

                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 25;
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
        //医生签名
        #region
        class clsPrintDocSign1 : clsIMR_PrintLineBase
        {

            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[2];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("医生名"))
                        objItemContent[0] = m_hasItems["医生名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("签日期"))
                        objItemContent[1] = m_hasItems["签日期"] as clsInpatMedRec_Item;
                    
                }
                if (m_blnIsFirstPrint)
                {
                //    string m_strOutone = "母： 1、" + (objItemContent[0] == null ? "   " : objItemContent[0].m_strItemContent) + " 孕" + (objItemContent[0].m_strItemContent) + " 产" +
                //        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + " 胎宫内妊娠" + (objItemContent[3] == null ? "   " : objItemContent[3].m_strItemContent) + " 周" +
                //        (objItemContent[4] == null ? "   " : objItemContent[4].m_strItemContent) + "产" + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + "活婴。";
                //    //string m_strTmp2="婴儿：1、" +
                //    //    (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent);
                    p_objGrp.DrawString("医生签名： "+(objItemContent[0]==null?"":objItemContent[0].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+450, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, m_tmpPointX + 30, p_intPosY + 30, m_tmpPointX + 640, p_intPosY + 30);
                    p_intPosY += 25;
                    p_objGrp.DrawString("日期： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[6] == null ? " " : ("" + objItemContent[6].m_strItemContent)), (objItemContent[6] == null ? "<root />" : (objItemContent[6].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);

                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{

                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 25;
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
        //产后检查
        #region
        class clsPrintChanHouCheck : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[25];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("检查日期"))
                        objItemContent[0] = m_hasItems["检查日期"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("产后天"))
                        objItemContent[1] = m_hasItems["产后天"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("恶露天"))
                        objItemContent[2] = m_hasItems["恶露天"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("血压"))
                        objItemContent[3] = m_hasItems["血压"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("体重后"))
                        objItemContent[4] = m_hasItems["体重后"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("阴道分泌物"))
                        objItemContent[5] = m_hasItems["阴道分泌物"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("母乳"))
                        objItemContent[6] = m_hasItems["母乳"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("乳腺"))
                        objItemContent[7] = m_hasItems["乳腺"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("婴儿情况后"))
                        objItemContent[8] = m_hasItems["婴儿情况后"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("腹部情况"))
                        objItemContent[9] = m_hasItems["腹部情况"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("外阴"))
                        objItemContent[10] = m_hasItems["外阴"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("会阴情况"))
                        objItemContent[11] = m_hasItems["会阴情况"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("托里"))
                        objItemContent[12] = m_hasItems["托里"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("阴道"))
                        objItemContent[13] = m_hasItems["阴道"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("糜烂"))
                        objItemContent[14] = m_hasItems["糜烂"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("宫体"))
                        objItemContent[15] = m_hasItems["宫体"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("位置"))
                        objItemContent[16] = m_hasItems["位置"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("大小"))
                        objItemContent[17] = m_hasItems["大小"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("硬度"))
                        objItemContent[18] = m_hasItems["硬度"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("压痛"))
                        objItemContent[19] = m_hasItems["压痛"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("附件左"))
                        objItemContent[20] = m_hasItems["附件左"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("附件右"))
                        objItemContent[21] = m_hasItems["附件右"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("膀胱组织"))
                        objItemContent[22] = m_hasItems["膀胱组织"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("其它"))
                        objItemContent[23] = m_hasItems["其它"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("诊断1"))
                        objItemContent[24] = m_hasItems["诊断1"] as clsInpatMedRec_Item;
                    
                }
                if (m_blnIsFirstPrint)
                {
                    m_blnIsFirstPrint = false;
                    p_objGrp.DrawString("产后检查记录 ", new Font("宋体", 15, FontStyle.Bold), Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                     p_intPosY += 25;
                     p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 300, p_intPosY, m_intPatientInfoX + 440, p_intPosY );
                     p_intPosY += 5;
                    p_objGrp.DrawString("检查日期：" + (objItemContent[0] == null ? "                " : objItemContent[0].m_strItemContent.Substring(0,10)), p_fntNormalText, Brushes.Black, m_intPatientInfoX , p_intPosY);
                    p_objGrp.DrawString(" 。产后：" + (objItemContent[1] == null ? "  " : objItemContent[1].m_strItemContent)+"天", p_fntNormalText, Brushes.Black, m_intPatientInfoX+160, p_intPosY);
                    p_objGrp.DrawString(" ，恶露于产后 " + (objItemContent[2] == null ? "   " : objItemContent[2].m_strItemContent) + "天干净。", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 270, p_intPosY);
                    p_objGrp.DrawString(" 血压：" + (objItemContent[3] == null ? "    " : objItemContent[3].m_strItemContent) + "mmHg,", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 480, p_intPosY);
                    p_objGrp.DrawString(" 体重 " + (objItemContent[4] == null ? "  " : objItemContent[4].m_strItemContent) + "kg。", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 590, p_intPosY);
                    p_intPosY += 25;

                    p_objGrp.DrawString("现在阴道分泌物情况： " + (objItemContent[5] == null ? "                             " : objItemContent[5].m_strItemContent) , p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString(" 母乳喂养： " + (objItemContent[6] == null ? "     " : objItemContent[6].m_strItemContent) , p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    p_objGrp.DrawString(" 。乳腺炎： " + (objItemContent[7] == null ? "     " : objItemContent[7].m_strItemContent) + "。", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 550, p_intPosY);
                    p_intPosY += 25;

                    p_objGrp.DrawString("婴儿情况： " + (objItemContent[8] == null ? "                                " : objItemContent[8].m_strItemContent) , p_fntNormalText, Brushes.Black, m_intPatientInfoX , p_intPosY);
                    p_objGrp.DrawString("腹部伤口愈合情况： " + (objItemContent[9] == null ? "                                " : objItemContent[9].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+300, p_intPosY);
                    
                    p_intPosY += 25;


                    p_objGrp.DrawString("妇检：外阴： " + (objItemContent[10] == null ? "                                " : objItemContent[10].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("会阴伤口愈合情况： " + (objItemContent[11] == null ? "                                " : objItemContent[11].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+300, p_intPosY);
                    
                    p_intPosY += 25;

                    p_objGrp.DrawString("盆底提托力： " + (objItemContent[12] == null ? "                                " : objItemContent[12].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("阴道： " + (objItemContent[13] == null ? "                                " : objItemContent[13].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+300, p_intPosY);
                    
                    p_intPosY += 25;
                    p_objGrp.DrawString("宫颈： 光滑：" + (objItemContent[14] == null ? "   " : objItemContent[14].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX , p_intPosY);
                     p_objGrp.DrawString("、糜烂： " + (objItemContent[15] == null ? "    " : objItemContent[15].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX+150, p_intPosY);
                     p_objGrp.DrawString("，宫体：位置 " + (objItemContent[16] == null ? "    " : objItemContent[16].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 250, p_intPosY);
                     p_objGrp.DrawString("，大小 " + (objItemContent[17] == null ? "    " : objItemContent[17].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 370, p_intPosY);
                     p_objGrp.DrawString("硬度： " + (objItemContent[18] == null ? "    " : objItemContent[18].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 470, p_intPosY);
                     p_objGrp.DrawString("压痛 " + (objItemContent[19] == null ? "    " : objItemContent[19].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 570, p_intPosY);
                    p_intPosY += 25;

                    p_objGrp.DrawString("附件：左： " + (objItemContent[20] == null ? "                                   " : objItemContent[20].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 100, p_intPosY);
                    p_objGrp.DrawString("右： " + (objItemContent[21] == null ? "    " : objItemContent[21].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("膀胱组织： " + (objItemContent[22] == null ? "                                   " : objItemContent[22].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 100, p_intPosY);
                    p_objGrp.DrawString("其它： " + (objItemContent[23] == null ? "    " : objItemContent[23].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                   
                    p_intPosY += 25;
                    m_blnIsFirstPrint = false;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[24] == null ? " " : ("" + objItemContent[24].m_strItemContent)), (objItemContent[24] == null ? "<root />" : (objItemContent[24].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);

                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {

                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                    p_intPosY += 25;
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
            }
        }
        #endregion
        //处理
        #region
        class clsPrintDealWith : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[2];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("处理"))
                        objItemContent[0] = m_hasItems["处理"] as clsInpatMedRec_Item;
                    

                }
                if (m_blnIsFirstPrint)
                {
                    //    string m_strOutone = "母： 1、" + (objItemContent[0] == null ? "   " : objItemContent[0].m_strItemContent) + " 孕" + (objItemContent[0].m_strItemContent) + " 产" +
                    //        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + " 胎宫内妊娠" + (objItemContent[3] == null ? "   " : objItemContent[3].m_strItemContent) + " 周" +
                    //        (objItemContent[4] == null ? "   " : objItemContent[4].m_strItemContent) + "产" + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + "活婴。";
                    //    //string m_strTmp2="婴儿：1、" +
                    //    //    (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent);
                    p_objGrp.DrawString("处理： " , p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, m_tmpPointX + 30, p_intPosY + 30, m_tmpPointX + 640, p_intPosY + 30);
                    //p_intPosY += 25;
                    //p_objGrp.DrawString("日期： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 500, p_intPosY);
                    //p_intPosY += 25;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0] == null ? " " : ("" + objItemContent[0].m_strItemContent)), (objItemContent[0] == null ? "<root />" : (objItemContent[0].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {

                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);
                    p_intPosY += 25;
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
            }
        }
        #endregion
        //医生签名2
        #region
        class clsPringDocSigntwo : clsIMR_PrintLineBase
        {
            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[2];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("医生签１"))
                        objItemContent[0] = m_hasItems["医生签１"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("签日期１"))
                        objItemContent[1] = m_hasItems["签日期１"] as clsInpatMedRec_Item;

                }
                if (m_blnIsFirstPrint)
                {
                    //    string m_strOutone = "母： 1、" + (objItemContent[0] == null ? "   " : objItemContent[0].m_strItemContent) + " 孕" + (objItemContent[0].m_strItemContent) + " 产" +
                    //        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + " 胎宫内妊娠" + (objItemContent[3] == null ? "   " : objItemContent[3].m_strItemContent) + " 周" +
                    //        (objItemContent[4] == null ? "   " : objItemContent[4].m_strItemContent) + "产" + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + "活婴。";
                    //    //string m_strTmp2="婴儿：1、" +
                    //    //    (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent);
                    p_objGrp.DrawString("医生签名： " + (objItemContent[0] == null ? "" : objItemContent[0].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, m_tmpPointX + 30, p_intPosY + 30, m_tmpPointX + 640, p_intPosY + 30);
                    p_intPosY += 25;
                    p_objGrp.DrawString("日期： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    p_intPosY += 25;
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[6] == null ? " " : ("" + objItemContent[6].m_strItemContent)), (objItemContent[6] == null ? "<root />" : (objItemContent[6].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
                    m_blnIsFirstPrint = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{

                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 25;
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
        ///诊断
        #region
        class clsPrintDinogseHe : clsIMR_PrintLineBase
        {

            clsInpatMedRec_Item[] objItemContent = new clsInpatMedRec_Item[2];
            bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("诊断1"))
                        objItemContent[0] = m_hasItems["诊断1"] as clsInpatMedRec_Item;


                }
                if (m_blnIsFirstPrint)
                {
                    //    string m_strOutone = "母： 1、" + (objItemContent[0] == null ? "   " : objItemContent[0].m_strItemContent) + " 孕" + (objItemContent[0].m_strItemContent) + " 产" +
                    //        (objItemContent[2] == null ? "    " : objItemContent[2].m_strItemContent) + " 胎宫内妊娠" + (objItemContent[3] == null ? "   " : objItemContent[3].m_strItemContent) + " 周" +
                    //        (objItemContent[4] == null ? "   " : objItemContent[4].m_strItemContent) + "产" + (objItemContent[5] == null ? "  " : objItemContent[5].m_strItemContent) + "活婴。";
                    //    //string m_strTmp2="婴儿：1、" +
                    //    //    (objItemContent[6] == null ? "" : objItemContent[6].m_strItemContent);
                    p_objGrp.DrawString("诊断： ", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    //p_objGrp.DrawLine(Pens.Black, m_tmpPointX + 30, p_intPosY + 30, m_tmpPointX + 640, p_intPosY + 30);
                    //p_intPosY += 25;
                    //p_objGrp.DrawString("日期： " + (objItemContent[1] == null ? "" : objItemContent[1].m_strItemContent), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 500, p_intPosY);
                    //p_intPosY += 25;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent[0] == null ? " " : ("" + objItemContent[0].m_strItemContent)), (objItemContent[0] == null ? "<root />" : (objItemContent[0].m_strItemContentXml)), m_dtmFirstPrintTime, objItemContent != null);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {

                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 80, p_intPosY, p_objGrp);
                    p_intPosY += 25;
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
            }
        }
        #endregion

        #region
        #endregion
    }
}
