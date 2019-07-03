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
    class clsIMR_intHosptalrecordPrint : clsInpatMedRecPrintBase
    {
     //   internal static Hashtable m_hasItemDetail;
        public clsIMR_intHosptalrecordPrint(string p_strTypeID)
            : base(p_strTypeID)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        protected override void m_mthSetPrintLineArr()
        {
            //  m_mthSetThisPrintInfo();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                                                           new clsPrintPatientFixInfo("体格检查",320),
                                                                           new clsPrint2(),
                                                                           new clsPrint3(),
                                                                           new clsPrint4(),
                                                                           new clsPrint5(),
                                                                            new clsPrint6(),
                                                                               new clsPrintSubInf(),
                  //   objPrintArr[0],objPrintArr[1],objPrintArr[2],objPrintArr[3],objPrintArr[4],//,objPrintArr[5],
                                                                            new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                         //  new clsPrint9(),
                                                                        //   new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                      //   new clsPrint14(),
                                                                       
                                                                        // new clsPrint16(),
                                                                       //n//ew clsPrint17(),
                                                                     //      new clsPrint15(),
                                                                       });
        }








        #region 打印第一页的固定内容
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            public clsPrintPatientFixInfo(string p_strChildTitleName, int p_intChildTitleNameOffSetX)
            {
                m_strChildTitleName = p_strChildTitleName;
                m_intChildTitleNameOffSetX = p_intChildTitleNameOffSetX;

            }

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //  p_objGrp.DrawString("皮肤科住院病历", m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 10);

                // p_intPosY += 20;
                p_objGrp.DrawString("XHTCM/RD-104", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 150);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //  p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);

                p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                // p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //  p_intPosY += 20;
                // m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                //  p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("病史记录者：" + (m_objContent == null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 20;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }


                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);
                // p_intPosY += 20;

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

        #region 打印医保号和发病气节
        /// <summary>
        /// 打印电话 邮编  民族
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = {  "医保号" };
            private string[] m_strKeysArr101 = { "医保号：" };

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
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
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);

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
        #region 主诉
        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
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
                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("主诉", m_objPrintContext.m_ObjModifyUserArr);
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
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        #endregion
        #region 现病史
        /// <summary>
        ///  现病史
        /// </summary>
        private class clsPrint4 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("现病史"))
                        objItemContent = m_hasItems["现病史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent != null);
                    m_mthAddSign2("现病史", m_objPrintContext.m_ObjModifyUserArr);
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
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
                m_intTimes = 0;
            }
        }
        #endregion
        #region 体格检查
        /// <summary>
        /// 既往史
        /// </summary>
        private class clsPrint5 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
 
            private string[] m_strKeysArr01a = { "", "发育>>正常", "发育>>良好", "发育>>超常" };
            private string[] m_strKeysArr101a = { "mmHg \n一般情况：发育：", "发育>>正常", "发育>>良好", "发育>>超常" };
            private string[] m_strKeysArr02 = { "", "营养>>良好", "营养>>中等", "营养>>不良", "营养>>恶病质" };
            private string[] m_strKeysArr102 = { "营养：", "营养>>良好", "营养>>中等", "营养>>不良", "营养>>恶病质" };

            private string[] m_strKeysArr03 = { "", "精神>>良好", "精神>>不振" };
            private string[] m_strKeysArr103 = { "精神：", "精神>>良好", "精神>>不振" };
            private string[] m_strKeysArr03a = { "", "意识>>清楚", "意识>>模糊", "意识>>嗜睡", "意识>>昏睡", "意识>>昏迷", "意识>>谵妄" };
            private string[] m_strKeysArr103a = { "意识：", "意识>>清楚", "意识>>模糊", "意识>>嗜睡", "意识>>昏睡", "意识>>昏迷", "意识>>谵妄" };
            private string[] m_strKeysArr04 = { "", "面容>>润泽", "面容>>苍白无华", "面容>>萎黄" };
            private string[] m_strKeysArr104 = { "面容：", "面容>>润泽", "面容>>苍白无华", "面容>>萎黄" };
            private string[] m_strKeysArr04a = { "面容" };
            private string[] m_strKeysArr104a = { "其他：" }; 
            private string[] m_strKeysArr05 = { "", "体位>>自动", "体位>>被动", "体位>>半卧位", "体位>>卧位" };
            private string[] m_strKeysArr105 = { "体位：", "体位>>自动", "体位>>被动", "体位>>半卧位", "体位>>卧位" };
            private string[] m_strKeysArr05a = { "", "步态>>正常", "步态>>异常" };
            private string[] m_strKeysArr105a = { "步态：", "步态>>正常", "步态>>异常" };
            private string[] m_strKeysArr06 = { "步态" };
            private string[] m_strKeysArr106 = { "" };
            private string[] m_strKeysArr06a = { "", "声音>>洪亮", "声音>>低微", "声音>>嘶哑" };
            private string[] m_strKeysArr106a = { "声音：", "声音>>洪亮", "声音>>低微", "声音>>嘶哑" };

            private string[] m_strKeysArr07 = { "声音" };
            private string[] m_strKeysArr107 = { "其他：" };
            private string[] m_strKeysArr07a = { "", "气味>>正常", "气味>>异常" };
            private string[] m_strKeysArr107a = { "气味：", "气味>>正常", "气味>>异常" };
            private string[] m_strKeysArr07b = { "气味" };
            private string[] m_strKeysArr107b = { "" };
            private string[] m_strKeysArr07c = { "舌象" };
            private string[] m_strKeysArr107c = { "\n舌象：" };
            private string[] m_strKeysArr111 = { "脉象" };
            private string[] m_strKeysArr1110c = { "\n脉象：" };
            private string[] m_strKeysArr222 = {  "脉其他" };
            private string[] m_strKeysArr2220c = { "\n其他：" }; 

            private string[] m_strKeysArr07d = { "", "皮肤色>>正常", "皮肤色>>潮红", "皮肤色>>苍白", "皮肤色>>紫绀", "皮肤色>>黄染", "皮肤色>>色素沉着" };
            private string[] m_strKeysArr107d = { "\n皮肤及粘膜：色泽：", "皮肤色>>正常", "皮肤色>>潮红", "皮肤色>>苍白", "皮肤色>>紫绀", "皮肤色>>黄染", "皮肤色>>色素沉着" };
            private string[] m_strKeysArr07e = { "", "水肿>>无", "水肿>>有" };
            private string[] m_strKeysArr107e = { "水肿：", "水肿>>无", "水肿>>有" };
            private string[] m_strKeysArr07f = { "水肿" };
            private string[] m_strKeysArr107f = { "部位及程度：" };
            private string[] m_strKeysArr07g = { "", "掌>>无", "掌>>有" };
            private string[] m_strKeysArr107g = { "肝掌：", "掌>>无", "掌>>有" };

            private string[] m_strKeysArr08 = { "", "蜘蛛痔>>无", "蜘蛛痔>>有" };
            private string[] m_strKeysArr108 = { "蜘蛛痔：", "蜘蛛痔>>无", "蜘蛛痔>>有" };
            private string[] m_strKeysArr08a = { "蜘蛛痔" };
            private string[] m_strKeysArr108a = { "部位及数目：" };
            private string[] m_strKeysArr08a1 = { "蜘蛛痔>>其他" };
            private string[] m_strKeysArr108a1 = { "\n其他：" };

            private string[] m_strKeysArr08b = { "", "淋巴>>未及", "淋巴>>肿大" };
            private string[] m_strKeysArr108b = { "\n浅表淋巴结：全身浅表淋巴结：", "淋巴>>未及", "淋巴>>肿大" };
            private string[] m_strKeysArr08c = { "淋巴>>部位" };
            private string[] m_strKeysArr108c = { "部位及特征：" };
            private string[] m_strKeysArr08d = { "", "头颅>>圆整", "头颅>>畸形" };
            private string[] m_strKeysArr108d = { "\n头颈部：头颅：", "头颅>>圆整", "头颅>>畸形" };
            private string[] m_strKeysArr08e = { "", "眼睑>>正常", "眼睑>>浮肿" };
            private string[] m_strKeysArr108e = { "眼睑：", "眼睑>>正常", "眼睑>>浮肿" };
            private string[] m_strKeysArr08f = { "", "结膜>>正常", "结膜>>充血", "结膜>>水肿", "结膜>>出血" };
            private string[] m_strKeysArr108f = { "结膜：", "结膜>>正常", "结膜>>充血", "结膜>>水肿", "结膜>>出血" };
            private string[] m_strKeysArr08g = { "", "巩膜>>正常", "巩膜>>黄染" };
            private string[] m_strKeysArr108g = { "巩膜：", "巩膜>>正常", "巩膜>>黄染" };

            private string[] m_strKeysArr09 = { "", "瞳孔>>等大", "瞳孔>>正圆", "瞳孔>>不等" };
            private string[] m_strKeysArr109 = { "瞳孔：", "瞳孔>>等大", "瞳孔>>正圆", "瞳孔>>不等" };
            private string[] m_strKeysArr09a = { "瞳孔>>左", "瞳孔>>右" ,""};
            private string[] m_strKeysArr109a = { "左：", "cm 右：$$","cm$$" };
            private string[] m_strKeysArr09b = { "", "反射>>灵敏", "反射>>减弱", "反射>>消失" };
            private string[] m_strKeysArr109b = { "对光反射：", "反射>>灵敏", "反射>>减弱", "反射>>消失" };
            private string[] m_strKeysArr09c = { "", "耳>>正常", "耳>>异常" };
            private string[] m_strKeysArr109c = { "耳鼻：", "耳>>正常", "耳>>异常" };
            private string[] m_strKeysArr09d = { "耳鼻" };
            private string[] m_strKeysArr109d = { "" };
            private string[] m_strKeysArr09e = { "", "唇>>红润", "唇>>苍白", "唇>>紫绀" };
            private string[] m_strKeysArr109e = { "唇：", "唇>>红润", "唇>>苍白", "唇>>紫绀" };
            private string[] m_strKeysArr09f = { "", "舌>>居中", "舌>>偏斜" };
            private string[] m_strKeysArr109f = { "舌：", "舌>>居中", "舌>>偏斜" };
            private string[] m_strKeysArr09g = { "舌>>左", "舌>>右" };
            private string[] m_strKeysArr109g = { "", "舌>>左", "舌>>右" };

            private string[] m_strKeysArr010 = { "", "震颤>>无", "震颤>>有" };
            private string[] m_strKeysArr1010 = { "震颤：", "震颤>>无", "震颤>>有" };
            private string[] m_strKeysArr010a = { "", "咽>>正常", "咽>>充血", "咽>>水肿" };
            private string[] m_strKeysArr1010a = { "咽：", "咽>>正常", "咽>>充血", "咽>>水肿" };
            private string[] m_strKeysArr010b = { "", "扁桃体>>正常", "扁桃体>>肿大" };
            private string[] m_strKeysArr1010b = { "扁桃体：", "扁桃体>>正常", "扁桃体>>肿大" };
            private string[] m_strKeysArr010c = { "扁桃>>I°", "扁桃>>II°", "扁桃>>III°" };
            private string[] m_strKeysArr1010c = { "", "扁桃>>I°", "扁桃>>II°", "扁桃>>III°" };
            private string[] m_strKeysArr010d = { "脓点" };
            private string[] m_strKeysArr1010d = { "脓点：" };
            private string[] m_strKeysArr010e = { "", "颈>>软", "颈>>抵抗", "颈>>强直" };
            private string[] m_strKeysArr1010e = { "颈：", "颈>>软", "颈>>抵抗", "颈>>强直" };
            private string[] m_strKeysArr010f = { "", "气管>>居中", "气管>>偏斜" };
            private string[] m_strKeysArr1010f = { "气管：", "气管>>居中", "气管>>偏斜" };
            private string[] m_strKeysArr010g = { "气管>>左", "气管>>右" };
            private string[] m_strKeysArr1010g = { "", "气管>>左", "气管>>右" };


            private string[] m_strKeysArr011 = { "", "甲状>>正常", "甲状>>肿大" };
            private string[] m_strKeysArr1011 = { "甲状腺：", "甲状>>正常", "甲状>>肿大" };
            private string[] m_strKeysArr011a = { "", "静脉>>正常", "静脉>>怒张" };
            private string[] m_strKeysArr1011a = { "颈静脉：", "静脉>>正常", "静脉>>怒张" };
            private string[] m_strKeysArr011b = { "", "动脉>>无", "动脉>>有" };
            private string[] m_strKeysArr1011b = { "颈动脉搏动：", "动脉>>无", "动脉>>有" };
            private string[] m_strKeysArr011c = { "", "颈杂音>>无", "颈杂音>>有" };
            private string[] m_strKeysArr1011c = { "颈部血管杂音：", "颈杂音>>无", "颈杂音>>有" };
            private string[] m_strKeysArr011d = { "颈部>>其他" };
            private string[] m_strKeysArr1011d = { "其他：" };
            private string[] m_strKeysArr011e = { "", "胸形状>>正常", "胸形状>>桶状", "胸形状>>扁平胸", "胸形状>>鸡胸", "胸形状>>漏斗胸" };
            private string[] m_strKeysArr1011e = { "\n胸部：胸廓形状：", "胸形状>>正常", "胸形状>>桶状", "胸形状>>扁平胸", "胸形状>>鸡胸", "胸形状>>漏斗胸" };
            private string[] m_strKeysArr011f = { "", "乳房>>正常", "乳房>>异常" };
            private string[] m_strKeysArr1011f = { "乳房：", "乳房>>正常", "乳房>>异常" };
            private string[] m_strKeysArr011g = { "乳房" };
            private string[] m_strKeysArr1011g = { "" };



            private string[] m_strKeysArr012 = { "", "呼吸>>匀齐", "呼吸>>急促", "呼吸>>缓慢" };
            private string[] m_strKeysArr1012 = { "呼吸运动：", "呼吸>>匀齐", "呼吸>>急促", "呼吸>>缓慢" };
            private string[] m_strKeysArr012a = { "", "语颤>>对称", "语颤>>减弱", "语颤>>增强" };
            private string[] m_strKeysArr1012a = { "语颤：", "语颤>>对称", "语颤>>减弱", "语颤>>增强" };
            private string[] m_strKeysArr012b = { "", "肺音>>正常", "肺音>>异常" };
            private string[] m_strKeysArr1012b = { "双肺呼吸音：", "肺音>>正常", "肺音>>异常" };
            private string[] m_strKeysArr012c = { "肺部音" };
            private string[] m_strKeysArr1012c = { "" };
            private string[] m_strKeysArr012d = { "", "肺部罗音>>无", "肺部罗音>>干", "肺部罗音>>湿" };
            private string[] m_strKeysArr1012d = { "肺部罗音：", "肺部罗音>>无", "肺部罗音>>干", "肺部罗音>>湿" };
            private string[] m_strKeysArr012e = { "肺部罗音" };
            private string[] m_strKeysArr1012e = { "" };
            private string[] m_strKeysArr012f = { "心尖>>位置", "心尖>>强度", "心尖>>范围" };
            private string[] m_strKeysArr1012f = { "心尖搏动：位置：", "强度：", "范围：" };


            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                           string[] m_strKeysArr01 =new string[]{ "体格检查>>T", "体格检查>>P", "体格检查>>R", "体格检查>>BP" };
             string[] m_strKeysArr101 =new string[] { "体温：$$", "℃ 脉搏：$$", "次/分 呼吸：$$", "次/分 血压：$$" };
                if (m_blnIsFirstPrint)
                {

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04a) != false)
                            m_mthMakeText(m_strKeysArr104a, m_strKeysArr04a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);

                        m_mthMakeCheckText(m_strKeysArr106a, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr07) != false)
                            m_mthMakeText(m_strKeysArr107, m_strKeysArr07, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07b) != false)
                            m_mthMakeText(m_strKeysArr107b, m_strKeysArr07b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr07c) != false)
                            m_mthMakeText(m_strKeysArr107c, m_strKeysArr07c, ref strAllText, ref strXml);
                        m_mthMakeText(m_strKeysArr1110c, m_strKeysArr111, ref strAllText, ref strXml);
                        m_mthMakeText(m_strKeysArr2220c, m_strKeysArr222, ref strAllText, ref strXml);

                        m_mthMakeCheckText(m_strKeysArr107d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107e, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr07f) != false)
                            m_mthMakeText(m_strKeysArr107f, m_strKeysArr07f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08a) != false)
                            m_mthMakeText(m_strKeysArr108a, m_strKeysArr08a, ref strAllText, ref strXml);
                        m_mthMakeText(m_strKeysArr108a1, m_strKeysArr08a1, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08c) != false)
                            m_mthMakeText(m_strKeysArr108c, m_strKeysArr08c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr108g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09a) != false)
                            m_mthMakeText(m_strKeysArr109a, m_strKeysArr09a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr09d) != false)
                            m_mthMakeText(m_strKeysArr109d, m_strKeysArr09d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr109g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1010, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1010a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1010b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr010c) != false)
                        m_mthMakeCheckText(m_strKeysArr1010c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr010d) != false)
                            m_mthMakeText(m_strKeysArr1010d, m_strKeysArr010d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1010e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1010f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr010g) != false)
                        m_mthMakeCheckText(m_strKeysArr1010g, ref strAllText, ref strXml);

                        m_mthMakeCheckText(m_strKeysArr1011, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1011a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1011b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1011c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr011d) != false)
                            m_mthMakeText(m_strKeysArr1011d, m_strKeysArr011d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1011e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1011f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr011g) != false)
                            m_mthMakeText(m_strKeysArr1011g, m_strKeysArr011g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1012, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1012a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1012b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr012c) != false)
                            m_mthMakeText(m_strKeysArr1012c, m_strKeysArr012c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr1012d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr012e) != false)
                            m_mthMakeText(m_strKeysArr1012e, m_strKeysArr012e, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr012f) != false)
                            m_mthMakeText(m_strKeysArr1012f, m_strKeysArr012f, ref strAllText, ref strXml);


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
        #region 体格检查(三)
        /// <summary>
        /// 既往史
        /// </summary>
        private class clsPrint6 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
            
            private string[] m_strKeysArr01 = { "心率" };
            private string[] m_strKeysArr101 = { "心率：" };
            private string[] m_strKeysArr01a = { "", "心律>>齐", "心律>>不齐" };
            private string[] m_strKeysArr101a = { "次/分；心律：", "心律>>齐", "心律>>不齐" };
            private string[] m_strKeysArr02 = { "", "心包音>>无", "心包音>>有" };
            private string[] m_strKeysArr102 = { "\n心包摩擦音：", "心包音>>无", "心包音>>有" };

            private string[] m_strKeysArr03 = { "", "心音>>正常", "心音>>亢进", "心音>>分裂", "心音>>附加音" };
            private string[] m_strKeysArr103 = { "\n心音：", "心音>>正常", "心音>>亢进", "心音>>分裂", "心音>>附加音" };
            private string[] m_strKeysArr03a = { "", "心杂音>>无", "心杂音>>有" };
            private string[] m_strKeysArr103a = { "\n心脏杂音：", "心杂音>>无", "心杂音>>有" };


            private string[] m_strKeysArr04 = { "心>>其他" };
            private string[] m_strKeysArr104 = { "\n其他：" };


            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
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

                        //  if (m_blnHavePrintInfo(m_strKeysArr01) != false)

                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr101a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04) != false)
                            m_mthMakeText(m_strKeysArr104, m_strKeysArr04, ref strAllText, ref strXml);

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

        #region 体格检查(三2)
        /// <summary>
        /// 既往史
        /// </summary>
        private class clsPrint7 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            //			private string[] m_strKeysArr01  = {"","","","","",};
            //			private string[] m_strKeysArr101 = {"测试：","测试：","测试：","测试：","测试："};
            //          m_mthMakeCheckText(m_strKeysArr102,ref strAllText,ref strXml);
            private string[] m_strKeysArr01 = { "", "腹形>>平坦", "腹形>>膨隆", "腹形>>凹陷" };
            private string[] m_strKeysArr101 = { "腹部：腹形：", "腹形>>平坦", "腹形>>膨隆", "腹形>>凹陷" };
            private string[] m_strKeysArr01a = { "", "腹闭>>正常", "腹闭>>静脉曲张" };
            private string[] m_strKeysArr101a = { "腹壁：", "腹闭>>正常", "腹闭>>静脉曲张" };
            private string[] m_strKeysArr02 = { "", "腹肌>>无", "腹肌>>有" };
            private string[] m_strKeysArr102 = { "腹肌紧张：", "腹肌>>无", "腹肌>>有" };

            private string[] m_strKeysArr03 = { "", "压痛>>无", "压痛>>有" };
            private string[] m_strKeysArr103 = { "压痛：", "压痛>>无", "压痛>>有" };
            private string[] m_strKeysArr03a = { "压痛" };
            private string[] m_strKeysArr103a = { "" };


            private string[] m_strKeysArr04 = { "", "反跳动>>无", "反跳动>>有" };
            private string[] m_strKeysArr104 = { "反跳动：", "反跳动>>无", "反跳动>>有" };
            private string[] m_strKeysArr04a = { "", "父肿>>无", "父肿>>有" };
            private string[] m_strKeysArr104a = { "腹部肿块：", "父肿>>无", "父肿>>有" };
            private string[] m_strKeysArr04b = { "腹部肿块" };
            private string[] m_strKeysArr104b = { "" };
            private string[] m_strKeysArr04c = { "", "肝脏触诊>>未及", "肝脏触诊>>可及" };
            private string[] m_strKeysArr104c = { "肝脏触诊：", "肝脏触诊>>未及", "肝脏触诊>>可及" };
            private string[] m_strKeysArr04d = { "肝脏触诊" };
            private string[] m_strKeysArr104d = { "" };
            private string[] m_strKeysArr04e = { "", "脾脏触诊>>未及", "脾脏触诊>>可及" };
            private string[] m_strKeysArr104e = { "脾脏触诊：", "脾脏触诊>>未及", "脾脏触诊>>可及" };
            private string[] m_strKeysArr04f = { "脾脏触诊" };
            private string[] m_strKeysArr104f = { "" };
            private string[] m_strKeysArr04g = { "", "静脉回流>>无", "静脉回流>>有" };
            private string[] m_strKeysArr104g = { "肝颈静脉回流征：", "静脉回流>>无", "静脉回流>>有" };



            private string[] m_strKeysArr05 = { "", "移动音>>无", "移动音>>有" };
            private string[] m_strKeysArr105 = { "移动性浊音：", "移动音>>无", "移动音>>有" };
            private string[] m_strKeysArr05a = { "", "肠音>>正常", "肠音>>减弱", "肠音>>亢进", "肠音>>消失" };
            private string[] m_strKeysArr105a = { "肠鸣音：", "肠音>>正常", "肠音>>减弱", "肠音>>亢进", "肠音>>消失" };
            private string[] m_strKeysArr05b = { "", "肾痛>>无", "肾痛>>有" };
            private string[] m_strKeysArr105b = { "肾区叩痛：", "肾痛>>无", "肾痛>>有" };
            private string[] m_strKeysArr05c = { "肠音其他" };
            private string[] m_strKeysArr105c = { "\n其他：" };
            private string[] m_strKeysArr05d = { "", "脊柱畸形>>无", "脊柱畸形>>有" };
            private string[] m_strKeysArr105d = { "\n脊柱四肢：脊柱畸形：", "脊柱畸形>>无", "脊柱畸形>>有" };
            private string[] m_strKeysArr05e = { "脊柱畸形" };
            private string[] m_strKeysArr105e = { "" };
            private string[] m_strKeysArr05f = { "", "肢体畸形>>无", "肢体畸形>>有" };
            private string[] m_strKeysArr105f = { "肢体畸形：", "肢体畸形>>无", "肢体畸形>>有" };
            private string[] m_strKeysArr05g = { "肢体畸形" };
            private string[] m_strKeysArr105g = { "" };




            private string[] m_strKeysArr06 = { "", "关节>>正常", "关节>>肿胀", "关节>>畸形", "关节>>活动受限" };
            private string[] m_strKeysArr106 = { "关节：", "关节>>正常", "关节>>肿胀", "关节>>畸形", "关节>>活动受限" };
            private string[] m_strKeysArr06a = { "关节" };
            private string[] m_strKeysArr106a = { "" };
            private string[] m_strKeysArr06b = { "", "双膝>>无", "双膝>>有" };
            private string[] m_strKeysArr106b = { "双下肢浮肿：", "双膝>>无", "双膝>>有" };
            private string[] m_strKeysArr06c = { "关节>>其他", };
            private string[] m_strKeysArr106c = { "\n其他：" };
            private string[] m_strKeysArr06d = { "神经系统", "生理反射" };
            private string[] m_strKeysArr106d = { "\n外生殖器及肛门：", "神经系统：生理反射：" };
            private string[] m_strKeysArr06e = { "", "病理反射>>无", "病理反射>>有" };
            private string[] m_strKeysArr106e = { "\n病理反射：", "病理反射>>无", "病理反射>>有" };
            private string[] m_strKeysArr06f = { "病理反射" };
            private string[] m_strKeysArr106f = { "\n" };
            private string[] m_strKeysArr06g = { "专科检查" };
            private string[] m_strKeysArr106g = { "\n专科检查：" };



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

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        //  if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                        m_mthMakeCheckText(m_strKeysArr101, ref strAllText, ref strXml);

                        m_mthMakeCheckText(m_strKeysArr101a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr102, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr03a) != false)
                            m_mthMakeText(m_strKeysArr103a, m_strKeysArr03a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104a, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr04b) != false)
                            m_mthMakeText(m_strKeysArr104b, m_strKeysArr04b, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04d) != false)
                            m_mthMakeText(m_strKeysArr104d, m_strKeysArr04d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104e, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr04f) != false)
                            m_mthMakeText(m_strKeysArr104f, m_strKeysArr04f, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05c) != false)
                            m_mthMakeText(m_strKeysArr105c, m_strKeysArr05c, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105d, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05e) != false)
                            m_mthMakeText(m_strKeysArr105e, m_strKeysArr05e, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05g) != false)
                            m_mthMakeText(m_strKeysArr105g, m_strKeysArr05g, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06a) != false)
                            m_mthMakeText(m_strKeysArr106a, m_strKeysArr06a, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106b, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06c) != false)
                            m_mthMakeText(m_strKeysArr106c, m_strKeysArr06c, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06d) != false)
                            m_mthMakeText(m_strKeysArr106d, m_strKeysArr06d, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr106e, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06f) != false)
                            m_mthMakeText(m_strKeysArr106f, m_strKeysArr06f, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06g) != false)
                            m_mthMakeText(m_strKeysArr106g, m_strKeysArr06g, ref strAllText, ref strXml);






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
         #endregion    /// <summary>
            /// 表格,初步诊断,最后诊断打印
            /// </summary>
            private class clsPrintSubInf : clsIMR_PrintLineBase
            {
                /// <summary>
                /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
                /// </summary>
                private bool m_blnIsFirstPrint = true;
                private clsInpatMedRec_Item[] m_objItemArrr = null;
                private clsInpatMedRec_Item[] m_objItemAr123 = null;
                private clsInpatMedRec_Item[] m_objItemArr = null;
                private clsInpatMedRec_Item[] m_objFirstArr = null;
                private clsInpatMedRec_Item[] m_objLastArr = null;
              //  private string[] m_strKeysArr104 = { "心率：", "心律>>齐", "心律>>不齐" };
                           
                private int m_intYPos = 10;
                private int m_intXPos = (int)enmRectangleInfo.LeftX + 10;
                private bool[] m_blnPrintCol = new Boolean[] { true, true, true, true,true,true};

                public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
                {
                    if (m_blnIsFirstPrint)
                    {
                        m_objItemAr123 = m_objGetContentFromItemArr(new string[] { "中线" });
                        m_objItemArrr = m_objGetContentFromItemArr(new string[] { "", "心界二>>左", "心界三>>左", "心界四>>左", "心界五>>左" });
                        m_objItemArr = m_objGetContentFromItemArr(new string[] { "", "心界二>>右", "心界三>>右", "心界四>>右", "心界五>>右" });
                        m_objFirstArr = m_objGetContentFromItemArr(new string[] { "初步诊断>>烧伤原因", "初步诊断>>烧伤总面积", "初步诊断>>Ⅰ度", "初步诊断>>浅Ⅱ度", "初步诊断>>深Ⅱ度", "初步诊断>>Ⅲ度", "初步诊断>>呼吸道烧伤", "初步诊断>>合并伤、中毒", "初步诊断>>其他", "初步诊断>>签名", "初步诊断>>初步诊断日期" });
                      //  m_objLastArr = m_objGetContentFromItemArr(new string[] { "最后诊断>>烧伤原因", "最后诊断>>烧伤总面积", "最后诊断>>Ⅰ度", "最后诊断>>浅Ⅱ度", "最后诊断>>深Ⅱ度", "最后诊断>>Ⅲ度", "最后诊断>>呼吸道烧伤", "最后诊断>>合并伤、中毒", "最后诊断>>其他", "最后诊断>>签名", "最后诊断>>最后诊断日期" });
                        if (m_objItemArr == null && m_objFirstArr == null && m_objLastArr == null || m_hasItems == null)
                        {
                            m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                    #region Printting
                    if (m_blnPrintCol[0] == true)
                    {
                        //if (m_blnCheckBottom(ref p_intPosY, p_objGrp, p_fntNormalText, 130))
                        //{
                        //    m_intYPos = 155;
                        //    return;
                        //}
                     if (m_blnIsFirstPrint == true)
                        {
                            m_mthDrawTitle(p_intPosY, p_objGrp, p_fntNormalText);
                          //  p_objGrp.DrawString("初步诊断：", p_fntNormalText, Brushes.Black, m_intXPos , p_intPosY + 5);
                            //p_objGrp.DrawString("最后诊断：", p_fntNormalText, Brushes.Black, m_intXPos+100, p_intPosY + 5);
                           // p_intPosY += 45;
                        }
                       
                        p_objGrp.DrawString((m_objItemArrr[0] == null ? "" : (m_objItemArrr[0].m_strItemContent == null ? "" : m_objItemArrr[0].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intXPos + 240, m_intYPos + 27);
                        p_objGrp.DrawString((m_objItemArr[0] == null ? "" : (m_objItemArr[0].m_strItemContent == null ? "" : m_objItemArr[0].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intXPos + 240, m_intYPos + 27);
                 
                      //  m_blnPrintCol[0] = false;
                    }
                  // string[] strTempArr = { "Ⅰ度：", "浅Ⅱ度：", "深Ⅱ度：", "Ⅲ度：", "呼吸道烧伤：" };
                    string[] strTextArr = {"", "II", "III", "IV", "V" };
                
                    for (int i = 1; i < m_blnPrintCol.Length - 1; i++)
                    {
                        if (m_blnPrintCol[i] == true)
                        {
                           // m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                          //  m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                            //if (m_blnCheckBottom(ref p_intPosY, p_objGrp, p_fntNormalText, 40))
                            //{
                            //    p_objGrp.DrawLine(Pens.Black, m_intXPos, m_intYPos, m_intXPos + 300, m_intYPos);
                            //    m_intYPos = 155;
                            //    return;
                            //}
                             if (m_blnIsFirstPrint == true)
                                m_mthDrawTitle(p_intPosY, p_objGrp, p_fntNormalText);
                            //表格标题
                            p_objGrp.DrawString(strTextArr[i], p_fntNormalText, Brushes.Black, m_intXPos+400, m_intYPos + 2);
                            p_objGrp.DrawLine(Pens.Black, m_intXPos + 300, m_intYPos, m_intXPos + 600, m_intYPos);
                            //z诊断标题
                            p_objGrp.DrawString((m_objItemArrr[i] == null ? "" : (m_objItemArrr[i].m_strItemContent == null ? "" : m_objItemArrr[i].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intXPos + 500, m_intYPos + 2);
                            p_objGrp.DrawString((m_objItemArr[i] == null ? "" : (m_objItemArr[i].m_strItemContent == null ? "" : m_objItemArr[i].m_strItemContent)), p_fntNormalText, Brushes.Black, m_intXPos+300, m_intYPos + 2);
                          
                        // m_mthPrintDioa(ref p_intPosY, p_objGrp, p_fntNormalText, strTempArr[i], (m_objFirstArr[i + 1] == null ? "" : m_objFirstArr[i + 1].m_strItemContent),/* (m_objLastArr[i + 1] == null ? "" : m_objLastArr[i + 1].m_strItemContent)*/"");
                            m_intYPos += 25;
                           // m_blnPrintCol[i] = false;
                        }
                    }
                    p_objGrp.DrawString((m_objItemAr123[0] == null ? "" : (m_objItemAr123[0].m_strItemContent == null ? "" : m_objItemAr123[0].m_strItemContent)) + "cm", p_fntNormalText, Brushes.Black, m_intXPos + 490, m_intYPos + 6);
                    m_intYPos += 25;

                    p_intPosY = m_intYPos > p_intPosY ? m_intYPos + 20 : p_intPosY + 20;
                    #endregion
                    m_blnHaveMoreLine = false;
                }
                /// <summary>
                /// 输出日期打印格式
                /// </summary>
                /// <param name="p_strDataTime"></param>
                /// <param name="p_blnText"></param>
                /// <returns></returns>
                private string m_mthSetDateTimeFormat(string p_strDataTime, bool p_blnText)
                {
                    if (p_strDataTime == null)
                        return "";
                    DateTime dtTime = DateTime.Parse(p_strDataTime);
                    return dtTime.ToString("yyyy年MM月dd日") + (p_blnText ? dtTime.Hour + "时" : "");
                }
                public override void m_mthReset()
                {
                    m_blnHaveMoreLine = true;
                    m_blnIsFirstPrint = true;
                }
                /// <summary>
                /// 打印标题
                /// </summary>
                /// <param name="p_intPosY"></param>
                /// <param name="p_objGrp"></param>
                /// <param name="p_fntNormalText"></param>
                private void m_mthDrawTitle(int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
                {

                    p_intPosY = p_intPosY - 90;
                    if (p_intPosY < 200)
                    {
                        p_intPosY =200; 
                    
                    }
                    m_intYPos = p_intPosY+10;
                    RectangleF rtgf = new RectangleF(m_intXPos+300, m_intYPos, 100, 25);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 300, m_intYPos, m_intXPos + 600, m_intYPos);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 300, m_intYPos+125, m_intXPos + 600, m_intYPos+125);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 300, m_intYPos, m_intXPos + 300, m_intYPos + 125);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 300 + 100, m_intYPos, m_intXPos + 100 + 300, m_intYPos + 125);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 200 + 300, m_intYPos, m_intXPos + 200 + 300, m_intYPos + 125);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos + 300 + 300, m_intYPos, m_intXPos + 300 + 300, m_intYPos + 125);
                    p_objGrp.DrawLine(Pens.Black, m_intXPos+300, m_intYPos + 25, m_intXPos + 600, m_intYPos + 25);
                    p_objGrp.DrawString("右(cm)：", p_fntNormalText, Brushes.Black, rtgf);
                    rtgf.X = m_intXPos + 400;
                    p_objGrp.DrawString("肋间：", p_fntNormalText, Brushes.Black, rtgf);
                    rtgf.X = m_intXPos + 500;
                    p_objGrp.DrawString("左(cm)：", p_fntNormalText, Brushes.Black, rtgf);
                    p_objGrp.DrawString("前正中线距左锁骨中线：", p_fntNormalText, Brushes.Black, new RectangleF(m_intXPos + 300, m_intYPos + 130, 220, 30));
                    m_intYPos += 25;
                    m_blnIsFirstPrint = false;
                }
                /// <summary>
                ///// 检测是否需要换页
                ///// </summary>
                ///// <param name="p_intPosY"></param>
                ///// <param name="p_objGrp"></param>
                ///// <param name="p_fntNormalText"></param>
                ///// <param name="p_intHeight"></param>
                ///// <returns></returns>
                //private bool m_blnCheckBottom(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText, int p_intHeight)
                //{
                //    if (m_intYPos + p_intHeight + 20 > ((int)enmRectangleInfo.BottomY - 50))
                //    {
                //        m_blnHaveMoreLine = true;
                //        m_blnIsFirstPrint = true;
                //        p_intPosY += 500;
                //        return true;
                //    }
                //    return false;
                //}
                /// <summary>
                /// 诊断打印
                /// </summary>
                /// <param name="p_intPosY"></param>
                /// <param name="p_objGrp"></param>
                /// <param name="p_fntNormalText"></param>
                /// <param name="p_strTextArr">标题</param>
                /// <param name="p_strFirstCont">初步诊断</param>
                /// <param name="p_strLastCont">最后诊断</param>
                private void m_mthPrintDioa(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText, string p_strText, string p_strFirstCont, string p_strLastCont)
                {
                    if (p_strFirstCont == null)
                        return;
                    int intTemp = 0;
                    RectangleF rtg = new RectangleF(m_intXPos , p_intPosY, 200, 20);
                    string strText = p_strText + p_strFirstCont;
                    SizeF szfText = p_objGrp.MeasureString(strText, p_fntNormalText, Convert.ToInt32(rtg.Width));
                    rtg.Height = szfText.Height + 5;
                    rtg.Y = p_intPosY;
                    p_objGrp.DrawString(strText, p_fntNormalText, Brushes.Black, rtg);
                    intTemp += Convert.ToInt32(rtg.Height);

                    rtg = new RectangleF(m_intXPos , p_intPosY, 140, 20);
                    strText = (p_strLastCont == null ? "" : p_strLastCont);
                    szfText = p_objGrp.MeasureString(strText, p_fntNormalText, Convert.ToInt32(rtg.Width));
                    rtg.Height = szfText.Height + 5;
                    rtg.Y = p_intPosY;
                    p_objGrp.DrawString(strText, p_fntNormalText, Brushes.Black, rtg);
                    if (intTemp > Convert.ToInt32(rtg.Height))
                        p_intPosY += intTemp;
                    else
                        p_intPosY += Convert.ToInt32(rtg.Height);
                }
            }


        }


}