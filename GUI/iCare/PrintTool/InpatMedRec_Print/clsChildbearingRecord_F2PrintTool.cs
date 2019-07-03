using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
    /// <summary>
    /// 新生儿出生时记录(佛山版)打印工具类
    /// </summary>
    public class clsChildbearingRecord_F2PrintTool : clsInpatMedRecPrintBase
    {
        public clsChildbearingRecord_F2PrintTool(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        protected override void m_mthSetPrintLineArr()
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
																	   new clsPrintInPatMedRecCaseMain(),
																		   new clsPrintInPatApgar(),
																			new clsPrintInPatMedDocAndDate(),
                                                                       new clsPrintInPatMedRecOutHospital(),
                                                                       new clsPrintInPatMedOutHospitalDocAndDate(),
                                                                       new clsPrintInPatMedResoult()     
																	   });
        }


        #region 打印实现

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

                p_objGrp.DrawString("新 生 儿 出 生 时 记 录", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 310, 70);

                p_objGrp.DrawString("母亲住院号：", p_fntNormalText, Brushes.Black, 550, 110);
                p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID, p_fntNormalText, Brushes.Black, 640, 110);
                p_intPosY = 150;
                m_blnHaveMoreLine = false;
                #region
                //				p_objGrp.DrawString("新生儿出生时记录病历",m_fotItemHead,Brushes.Black,m_intRecBaseX+250,p_intPosY - 10);
                //		
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
                //		
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
                //		
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
                //				p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
                //
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
                //		
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
                //		
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
                //
                //				p_intPosY += 20;
                //				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
                //		
                //				p_intPosY += 20;
                //				if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                //				{
                //					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
                //				}
                //				else
                //				{
                //					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
                //				}				
                //			
                //				m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
                //				int intRealHeight;
                //				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
                //				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
                #endregion

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

        #region 母亲姓名,检查情形
        /// <summary>
        /// 母亲姓名,检查情形
        /// </summary>
        private class clsPrintInPatMedRecCaseMain : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            private string[] m_strKeysArr1 = { "母亲姓名", "" };
            private string[] m_strKeysArr2 = { "婴儿性别:", "婴儿性别>>男", "婴儿性别>>女" };
            private string[] m_strKeysArr3 = { "", "出生时间>>年", "", "出生时间>>月", "", "出生时间>>日", "", "出生时间>>午", "", "出生时间>>时", "", "出生时间>>分", "" };
            private string[] m_strKeysArr4 = { "", "检查情形>>发育", "检查情形>>呼吸", "检查情形>>枕额周径", "检查情形>>身长", "检查情形>>体重" };
            private string[] m_strKeysArr5 = { "", "检查情形>>头部", "检查情形>>形状", "检查情形>>眼", "检查情形>>耳", "检查情形>>鼻", "检查情形>>口腔" };

            private string[] m_strKeysArr7 = { "", "检查情形>>胸部", "检查情形>>心", "检查情形>>肺" };
            private string[] m_strKeysArr8 = { "", "检查情形>>腹部肝", "检查情形>>脾", "检查情形>>脐带" };
            private string[] m_strKeysArr9 = { "", "检查情形>>四肢", "检查情形>>生殖器", "检查情形>>肛口" };

            private string[] m_strKeysArr11 = { "", "检查情形>>其他>>畸形", "检查情形>>其他>>眼睛滴药" };
            private string[] m_strKeysArr12 = { "", "检查情形>>其他>>附注" };

            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)
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
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "母亲姓名：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        //						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);

                        m_mthMakeCheckText(m_strKeysArr2, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr3) != false)
                            m_mthMakeText(new string[] { "    出生时间：", "", "年$$", "", "月$$", "", "日$$", "", "午$$", "", "时$$", "", "分$$" }, m_strKeysArr3, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n检查情形：" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "发育：", "呼吸：", "枕额周径(cm)：", "身长(cm)：", "体重(g)：" }, m_strKeysArr4, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "头部：", "形状：", "眼      ：", "耳  ：", "鼻  ：", "口腔 ：" }, m_strKeysArr5, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n    ", "胸部：", "心  ：", "肺      ：" }, m_strKeysArr7, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "腹部肝：", "脾  ：", "脐带：" }, m_strKeysArr8, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "四肢：", "生殖器：", "肛口  ：" }, m_strKeysArr9, ref strAllText, ref strXml);

                        m_mthMakeText(new string[] { "\n其他:" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "畸形：", "眼睛滴药：" }, m_strKeysArr11, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n    ", "附注：" }, m_strKeysArr12, ref strAllText, ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
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
        #endregion

        #region Apgar评分表
        /// <summary>
        /// Apgar评分表
        /// </summary>
        private class clsPrintInPatApgar : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            private Font m_fontItem = new Font("宋体", 10);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private string[] m_strKeysArr1 = { "Apgar评分表>>心率/分钟>>0", "Apgar评分表>>心率/分钟>>小于100次", "Apgar评分表>>心率/分钟>>大于100次" };
            private string[] m_strKeysArr2 = { "Apgar评分表>>呼吸>>0 ", "Apgar评分表>>呼吸>>浅慢不规则", "Apgar评分表>>呼吸>>佳哭声呼" };
            private string[] m_strKeysArr3 = { "Apgar评分表>>肌张力>>松驰", "Apgar评分表>>肌张力>>四肢屈曲", "Apgar评分表>>肌张力>>四肢活动" };
            private string[] m_strKeysArr4 = { "Apgar评分表>>刺激反射>>无反应", "Apgar评分表>>刺激反射>>有些动作", "Apgar评分表>>刺激反射>>哭喷噎" };
            private string[] m_strKeysArr5 = { "Apgar评分表>>皮肤颜色>>青紫苍白", "Apgar评分表>>皮肤颜色>>躯干红四肢紫", "Apgar评分表>>皮肤颜色>>全身红润" };
            private string[] m_strKeysArr6 = { "Apgar评分表>>总分>>一评", "Apgar评分表>>总分>>二评", "Apgar评分表>>总分>>三评" };
            private string[] m_strKeysArr7 = { "Apgar评分表>>总分>>总分" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (!(m_blnHavePrintInfo(m_strKeysArr1) == true || m_blnHavePrintInfo(m_strKeysArr2) == true
                    || m_blnHavePrintInfo(m_strKeysArr3) == true || m_blnHavePrintInfo(m_strKeysArr4) == true || m_blnHavePrintInfo(m_strKeysArr5) == true
                    || m_blnHavePrintInfo(m_strKeysArr6) == true))
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    SizeF size = p_objGrp.MeasureString("Apgar评分表", m_fontItemMidHead);
                    int intMiddle = (clsPrintPosition.c_intRightX - clsPrintPosition.c_intLeftX) / 2 - Convert.ToInt32(size.Width / 2);
                    p_intPosY += 20;
                    p_objGrp.DrawString("Apgar评分表", m_fontItemMidHead, Brushes.Black, intMiddle, p_intPosY);
                    p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    if (m_objContent != null)
                    {
                        //						if(m_blnHavePrintInfo(m_strKeysArr) != false)
                        //							m_mthMakeText(new string[]{"肌营养：","肌张力："},m_strKeysArr,ref strAllText,ref strXml);
                        ////						m_mthMakeCheckText(m_strKeysArr1,ref strAllText,ref strXml);
                        //						if(m_blnHavePrintInfo(m_strKeysArr) != false)
                        //							m_mthMakeText(new string[]{"不自主运动：","肌力："},m_strKeysArr2,ref strAllText,ref strXml);
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("Apgar评分表", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_intPosY += 10;
                    m_mthPrintSportTable(ref p_intPosY, p_objGrp, p_fntNormalText);
                    m_blnHaveMoreLine = false;
                }
            }
            #region 打印表格
            private void m_mthPrintSportTable(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
                int intRowStep = m_intRecBaseX + 10;
                int intPosY = p_intPosY;
                int inttempY = p_intPosY;
                int intInTableInitY = p_intPosY; //用于传递给画数据库内容函数的初始坐标
                int intDiv = intLineWidth / 5;
                int intPing = intDiv / 3;
                int intRowHeigth = 30;

                int int2Score = 0;
                int int3Score = 0;
                int X = 0;
                int Y = 0;
                string printStr = "";

                #region 画行线
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth, intPosY);

                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth / 5 * 4, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth / 5 * 4, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth / 5 * 4, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth / 5 * 4, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth, intPosY);
                intPosY += intRowHeigth;
                p_objGrp.DrawLine(Pens.Black, intRowStep, intPosY, intRowStep + intLineWidth, intPosY);

                #endregion

                #region 取出数据
                clsInpatMedRec_Item[] strRet1 = m_mthPrintSubItem(new string[] { "", "", "" }, m_strKeysArr1);
                clsInpatMedRec_Item[] strRet2 = m_mthPrintSubItem(new string[] { "", "", "" }, m_strKeysArr2);
                clsInpatMedRec_Item[] strRet3 = m_mthPrintSubItem(new string[] { "", "", "" }, m_strKeysArr3);
                clsInpatMedRec_Item[] strRet4 = m_mthPrintSubItem(new string[] { "", "", "" }, m_strKeysArr4);
                clsInpatMedRec_Item[] strRet5 = m_mthPrintSubItem(new string[] { "", "", "" }, m_strKeysArr5);
                string[] strRet6 = m_mthPrintTextItem(new string[] { "", "", "" }, m_strKeysArr6);
                string[] strRet7 = m_mthPrintTextItem(new string[] { "", "", "" }, m_strKeysArr6);
                #endregion

                #region 画坚线
                p_objGrp.DrawLine(Pens.Black, intRowStep, p_intPosY, intRowStep, intPosY);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv, p_intPosY, intRowStep + intDiv, intPosY);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 2, p_intPosY, intRowStep + intDiv * 2, intPosY - intRowHeigth);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 3, p_intPosY, intRowStep + intDiv * 3, intPosY - intRowHeigth);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 4, p_intPosY, intRowStep + intDiv * 4, intPosY);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 5, p_intPosY, intRowStep + intDiv * 5, intPosY);

                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 4 + intPing, p_intPosY, intRowStep + intDiv * 4 + intPing, intPosY);
                p_objGrp.DrawLine(Pens.Black, intRowStep + intDiv * 4 + intPing * 2, p_intPosY, intRowStep + intDiv * 4 + intPing * 2, intPosY);
                #endregion

                #region 画实体第一行
                printStr = "体征";
                SizeF size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "0分";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "1分";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 2 + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "2分";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 3 + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "一评";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "二评";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 4 + intPing + intPing / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                int2Score = X;

                printStr = "三评";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 4 + intPing * 2 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                int3Score = X;
                //
                inttempY = inttempY + intRowHeigth;
                //

                #endregion

                #region 第一列
                printStr = "心率/分钟";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                //打第相应行数据
                m_mthPrintStr(Y, strRet1, p_objGrp, new string[] { "0", "<100分钟", ">100分钟" });
                //

                inttempY = inttempY + intRowHeigth;
                //
                printStr = "呼吸";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);
                //打第相应行数据
                m_mthPrintStr(Y, strRet2, p_objGrp, new string[] { "0", "浅慢不规则", "佳哭声呼" });
                //
                //
                inttempY = inttempY + intRowHeigth;
                //
                printStr = "肌张力";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);
                //打第相应行数据
                m_mthPrintStr(Y, strRet3, p_objGrp, new string[] { "松驰", "四肢屈曲", "四肢活动" });
                //
                //
                inttempY = inttempY + intRowHeigth;
                //
                printStr = "刺激反射";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);
                //打第相应行数据
                m_mthPrintStr(Y, strRet4, p_objGrp, new string[] { "无反应", "有动作皱眉", "哭喷噎" });
                //
                //
                inttempY = inttempY + intRowHeigth;
                //
                printStr = "皮肤颜色";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);
                //打第相应行数据
                m_mthPrintStr(Y, strRet5, p_objGrp, new string[] { "青紫苍白", "躯干红四肢紫", "全身红润" });
                //
                //
                inttempY = inttempY + intRowHeigth;
                //
                printStr = "总分";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                Y = intRowHeigth / 2 + inttempY - Convert.ToInt32(size.Height / 2);
                X = intRowStep + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);
                //打第相应行数据
                int tX = intRowStep + intDiv + intDiv * 3 / 2 - Convert.ToInt32(size.Width / 4);

                p_objGrp.DrawString(strRet7[0].ToString(), m_fontItem, Brushes.Black, tX, Y);
                tX = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 4);
                p_objGrp.DrawString(strRet6[0].ToString(), m_fontItem, Brushes.Black, tX, Y);
                tX = intRowStep + intDiv * 4 + intPing / 2 + intPing - Convert.ToInt32(size.Width / 4);
                p_objGrp.DrawString(strRet6[1].ToString(), m_fontItem, Brushes.Black, tX, Y);
                tX = intRowStep + intDiv * 4 + intPing / 2 + intPing * 2 - Convert.ToInt32(size.Width / 4);
                p_objGrp.DrawString(strRet6[2].ToString(), m_fontItem, Brushes.Black, tX, Y);

                //

                #endregion

                #region 画最后三列(出生一分钟评分）
                int intZiHeight = Convert.ToInt32(size.Height * 1);
                int2Score = intRowStep + intDiv * 4 + intPing + intPing / 2 - Convert.ToInt32(size.Width / 2);
                int3Score = intRowStep + intDiv * 4 + intPing * 2 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                printStr = "分";
                size = p_objGrp.MeasureString(printStr, m_fontItem);
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);

                printStr = "一";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) - intZiHeight;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                printStr = "五";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) - intZiHeight;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);

                printStr = "十";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) - intZiHeight;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);


                printStr = "生";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) - intZiHeight * 2;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);

                printStr = "出";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) - intZiHeight * 3;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);

                printStr = "钟";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) + intZiHeight;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);

                printStr = "评";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) + intZiHeight * 2;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);

                printStr = "分";
                X = intRowStep + intDiv * 4 + intPing / 2 - Convert.ToInt32(size.Width / 2);
                Y = inttempY - intRowHeigth * 5 / 2 - Convert.ToInt32(size.Height / 2) + intZiHeight * 3;
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, X, Y);

                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int2Score, Y);
                p_objGrp.DrawString(printStr, m_fontItem, Brushes.Black, int3Score, Y);


                #endregion

                p_intPosY += intRowHeigth * 8;
            }

            private void m_mthPrintStr(int p_intY, clsInpatMedRec_Item[] p_strPrintArr, System.Drawing.Graphics p_objGrp, string[] strText)
            {

                int intX = 0;
                int intLineWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth;
                int intDiv = intLineWidth / 5;
                for (int i = 0; i < p_strPrintArr.Length; i++)
                {
                    clsInpatMedRec_Item strTemp = p_strPrintArr[i];
                    if (strTemp != null)
                    {
                        SizeF size = p_objGrp.MeasureString(strText[i].ToString(), m_fontItem);
                        intX = m_intRecBaseX + 10 + intDiv * (i + 1) + intDiv / 2 - Convert.ToInt32(size.Width / 2);
                        p_objGrp.DrawString(strText[i].ToString() + " √", m_fontItem, Brushes.Black, intX, p_intY);
                    }
                    else
                    {
                        SizeF size2 = p_objGrp.MeasureString(strText[i].ToString(), m_fontItem);
                        intX = m_intRecBaseX + 10 + intDiv * (i + 1) + intDiv / 2 - Convert.ToInt32(size2.Width / 2);
                        p_objGrp.DrawString(strText[i].ToString(), m_fontItem, Brushes.Black, intX, p_intY);

                    }
                }
            }
            private clsInpatMedRec_Item[] m_mthPrintSubItem(string[] p_strTitleArr, string[] p_strKeyArr)
            {
                clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
                if (objConArr == null || objConArr.Length != 3 || p_strTitleArr == null)
                    return null;
                //
                //				clsInpatMedRec_Item[] strConArr = new clsInpatMedRec_Item[objConArr.Length];
                //				for(int i=0;i<objConArr.Length; i++)
                //				{
                //					if(objConArr[i]!=null)
                //					if(objConArr[i].m_strItemContent != null)
                //						strConArr[i].m_strItemContent = objConArr[i].m_strItemContent;
                //					else
                //						strConArr[i].m_strItemContent = "";
                //				}				
                //				return strConArr;
                return objConArr;
            }

            private string[] m_mthPrintTextItem(string[] p_strTitleArr, string[] p_strKeyArr)
            {
                clsInpatMedRec_Item[] objConArr = m_objGetContentFromItemArr(p_strKeyArr);
                if (objConArr == null || objConArr.Length != 3 || p_strTitleArr == null)
                    return null;

                string[] strConArr = new string[objConArr.Length];
                for (int i = 0; i < objConArr.Length; i++)
                {
                    if (objConArr[i] != null)
                    {
                        if (objConArr[i].m_strItemContent != null)
                            strConArr[i] = objConArr[i].m_strItemContent;
                        else
                            strConArr[i] = "";
                    }
                    else
                        strConArr[i] = "";
                }
                return strConArr;

            }
            #endregion

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }

        #endregion

        #region 指印与检查医师，记录日期
        /// <summary>
        ///  指印与检查医师，记录日期
        /// </summary>
        private class clsPrintInPatMedDocAndDate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr1 = { "医生签字" };
            private string[] m_strKeysArr2 = { "记录日期" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                //				if(blnNextPage)
                //				{
                //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
                //					m_blnHaveMoreLine = true;
                //					blnNextPage = false;
                //					p_intPosY += 1500;
                //					return;
                //				}
                if (m_blnIsFirstPrint)
                {
                    //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
                    //					p_intPosY += 20;
                    //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
                    //					p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "检查医师：" }, m_strKeysArr1, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr2) != false)
                            m_mthMakeText(new string[] { "\n记录日期" }, m_strKeysArr2, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("医生签字：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
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
        #endregion


        /// <summary>
        /// 出院情况
        /// </summary>
        private class clsPrintInPatMedRecOutHospital : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            private string[] m_strKeysArr1 = { "出院情况>>健康", "" };
            private string[] m_strKeysArr2 = { "脐带:", "出院情况>>脱", "出院情况>>未脱" };
            private string[] m_strKeysArr3 = { "脐带:", "出院情况>>干洁", "出院情况>>炎症" };
            private string[] m_strKeysArr4 = { "", "出院情况>>疾病" };           
            private string[] m_strKeysArr5 = { "", "出院情况>>死亡", "出院情况>>死亡原因", "出院情况>>死亡时间" };

            

            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)
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
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "健康：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        //						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);

                        m_mthMakeCheckText(m_strKeysArr2, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr3, ref strAllText, ref strXml);
                        //if (m_blnHavePrintInfo(m_strKeysArr3) != false)
                        //    m_mthMakeText(new string[] { "    出生时间：", "", "年$$", "", "月$$", "", "日$$", "", "午$$", "", "时$$", "", "分$$" }, m_strKeysArr3, ref strAllText, ref strXml);
                        //m_mthMakeText(new string[] { "\n检查情形：" }, new string[] { "" }, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n", "疾病：" }, m_strKeysArr4, ref strAllText, ref strXml);
                        m_mthMakeText(new string[] { "\n", "死亡：", "死亡原因：", "死亡时间：" }, m_strKeysArr5, ref strAllText, ref strXml);

                       
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
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
        /// 出院情况日期及签名
        /// </summary>
        private class clsPrintInPatMedOutHospitalDocAndDate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private bool blnNextPage = true;
            private string[] m_strKeysArr1 = { "签字" };
            private string[] m_strKeysArr2 = { "出院情况记录日期" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false && m_blnHavePrintInfo(m_strKeysArr2) == false)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                //				if(blnNextPage)
                //				{
                //					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
                //					m_blnHaveMoreLine = true;
                //					blnNextPage = false;
                //					p_intPosY += 1500;
                //					return;
                //				}
                if (m_blnIsFirstPrint)
                {
                    //					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
                    //					p_intPosY += 20;
                    //					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
                    //					p_intPosY += 20;
                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "签名：" }, m_strKeysArr1, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr2) != false)
                            m_mthMakeText(new string[] { "\n记录日期" }, m_strKeysArr2, ref strAllText, ref strXml);

                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_mthAddSign2("签字：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
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
        /// 出院小结
        /// </summary>
        private class clsPrintInPatMedResoult : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //private string[] m_strKeysArr1 = {"母亲姓名","婴儿性别>>男","婴儿性别>>女"};
            private string[] m_strKeysArr1 = { "出院小结", "" };
           

            //m_mthMakeText(new string[]{"出生时间:","","#年$$","","#月$$","","#日$$","","#午$$","","#时$$","","#分$$"},m_strKeysArr3,ref strAllText,ref strXml);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnHavePrintInfo(m_strKeysArr1) == false)
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
                        if (m_blnHavePrintInfo(m_strKeysArr1) != false)
                            m_mthMakeText(new string[] { "出院小结：", "    " }, m_strKeysArr1, ref strAllText, ref strXml);
                        //						m_mthMakeText(new string[]{"母亲姓名：婴儿性别>>男：婴儿性别>>女"},m_strKeysArr1,ref strAllText,ref strXml);
                                            
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
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

        #endregion
    }

}
