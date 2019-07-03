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
    class clsIMR_middlelayPrint : clsInpatMedRecPrintBase
    {
        public clsIMR_middlelayPrint(string p_strTypeID)
            : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        clsPrintInPatMedRecOphthalmologyCheck[] objPrintArr;
        protected override void m_mthSetPrintLineArr()
        {
            m_mthSetThisPrintInfo();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                                                           new clsPrintPatientFixInfo("中期引产手术记录",320),
                                                                           new clsPrint2(),

                     	  objPrintArr[0],objPrintArr[1],objPrintArr[2],objPrintArr[3],objPrintArr[4],//,objPrintArr[5],objPrintArr[6],
                                          //objPrintArr[7],objPrintArr[8],objPrintArr[9],objPrintArr[10],objPrintArr[11],objPrintArr[12],objPrintArr[13],
										


                                                                           new clsPrint3(),
                                                                        //  new clsPrint4(),
                                                                           //new clsPrint5(),
                                                                           //new clsPrint6(),
                                                                        //   new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                           //new clsPrint9(),
                                                                           //new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                      //   new clsPrint14(),
                                                                       
                                                                       //  new clsPrint16(),
                                                                       //new clsPrint17(),
                                                                           new clsPrint15(),
                                                                       });
        }

        private void m_mthSetThisPrintInfo()
        {
            objPrintArr = new clsPrintInPatMedRecOphthalmologyCheck[5];
            for (int i = 0; i < objPrintArr.Length; i++)
                objPrintArr[i] = new clsPrintInPatMedRecOphthalmologyCheck();
            //objPrintArr[0].m_mthSetPrintValue(new string[] { "眼部检查>>视力>>右>>矫正前", "眼部检查>>视力>>右>>矫正后" }, new string[] { "眼部检查>>视力>>左>>矫正前", "眼部检查>>视力>>左>>矫正后" }, "视力", null);
            //objPrintArr[1].m_mthSetPrintValue(new string[] { "眼部检查>>眼睑>>右" }, new string[] { "眼部检查>>眼睑>>左" }, "眼睑", null);
            //objPrintArr[2].m_mthSetPrintValue(new string[] { "眼部检查>>泪器>>右" }, new string[] { "眼部检查>>泪器>>左" }, "泪器", null);
            //objPrintArr[3].m_mthSetPrintValue(new string[] { "眼部检查>>结膜>>睑部>>右", "眼部检查>>结膜>>球部>>右" }, new string[] { "眼部检查>>结膜>>睑部>>左", "眼部检查>>结膜>>球部>>左" }, "结膜", new string[] { "睑部", "球部" });
            //objPrintArr[4].m_mthSetPrintValue(new string[] { "眼部检查>>巩膜>>右" }, new string[] { "眼部检查>>巩膜>>左" }, "巩膜", null);
            //objPrintArr[5].m_mthSetPrintValue(new string[] { "眼部检查>>角膜>>血管翳>>右", "眼部检查>>角膜>>KP>>右", "眼部检查>>角膜>>疤痕>>右", "眼部检查>>角膜>>浸润>>右" }, new string[] { "眼部检查>>角膜>>血管翳>>左", "眼部检查>>角膜>>KP>>左", "眼部检查>>角膜>>疤痕>>左", "眼部检查>>角膜>>浸润>>左" }, "角膜", new string[] { "血管翳", "K P", "疤痕", "浸润" });
            //objPrintArr[6].m_mthSetPrintValue(new string[] { "眼部检查>>前房>>房水>>右", "眼部检查>>前房>>深浅>>右" }, new string[] { "眼部检查>>前房>>房水>>左", "眼部检查>>前房>>深浅>>左" }, "前房", new string[] { "房水", "深浅" });
            //objPrintArr[7].m_mthSetPrintValue(new string[] { "眼部检查>>虹膜>>色泽>>右", "眼部检查>>虹膜>>萎缩>>右", "眼部检查>>虹膜>>粘连>>右", "眼部检查>>虹膜>>新生血管>>右" }, new string[] { "眼部检查>>虹膜>>色泽>>左", "眼部检查>>虹膜>>萎缩>>左", "眼部检查>>虹膜>>粘连>>左", "眼部检查>>虹膜>>新生血管>>左" }, "虹膜", new string[] { "色泽", "萎缩", "粘连", "新生血管" });
            //objPrintArr[8].m_mthSetPrintValue(new string[] { "眼部检查>>瞳孔>>形状>>右", "眼部检查>>瞳孔>>大小>>右", "眼部检查>>瞳孔>>反应>>右" }, new string[] { "眼部检查>>瞳孔>>形状>>左", "眼部检查>>瞳孔>>大小>>左", "眼部检查>>瞳孔>>反应>>左" }, "瞳孔", new string[] { "形状", "大小", "反应" });
            //objPrintArr[9].m_mthSetPrintValue(new string[] { "眼部检查>>晶状体>>右" }, new string[] { "眼部检查>>晶状体>>左" }, "晶状体", null);
            //objPrintArr[10].m_mthSetPrintValue(new string[] { "眼部检查>>玻璃体>>右" }, new string[] { "眼部检查>>玻璃体>>左" }, "玻璃体", null);
            //objPrintArr[11].m_mthSetPrintValue(new string[] { "眼部检查>>眼底情况>>视乳头>>右", "眼部检查>>眼底情况>>网膜血管>>右", "眼部检查>>眼底情况>>视网膜>>右", "眼部检查>>眼底情况>>黄斑>>右" }, new string[] { "眼部检查>>眼底情况>>视乳头>>左", "眼部检查>>眼底情况>>网膜血管>>左", "眼部检查>>眼底情况>>视网膜>>左", "眼部检查>>眼底情况>>黄斑>>右" }, "眼底情况", new string[] { "视乳头", "网膜血管", "视网膜", "黄斑" });
            //objPrintArr[12].m_mthSetPrintValue(new string[] { "眼部检查>>眼球位置及运动>>右" }, new string[] { "眼部检查>>眼球位置及运动>>左" }, "眼球位置及运动", null);
            //objPrintArr[13].m_mthSetPrintValue(new string[] { "眼部检查>>眼压>>右" }, new string[] { "眼部检查>>眼压>>左" }, "眼压", null);

            objPrintArr[0].m_mthSetPrintValue(new string[] { "引产方法" }, null, "引产方法", null);
            objPrintArr[1].m_mthSetPrintValue(new string[] { "引产时间" }, null, "引产时间", null);
            objPrintArr[2].m_mthSetPrintValue(new string[] { "药物剂量" }, null, "药物剂量", null);
            objPrintArr[3].m_mthSetPrintValue(new string[] { "手术难道" }, null, "手术难道", null);

            objPrintArr[4].m_mthSetPrintValue(new string[] { "产前", "产时", "产后" }, null, "辅助用药", new string[] { "产前", "产时", "产后" });
        
        
        
        
        
        
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
                p_objGrp.DrawString("XHTCM/RD-136", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 140);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
               // p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
   p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                //p_intPosY += 20;
             
                //p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
               // p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                  p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 20;
           
               // p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //p_intPosY += 20;
                //if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                //{
                //    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //}
                //else
                //{
                //    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //}

                //m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                //int intRealHeight;
                //Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                //m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);
                //p_intPosY += 20;
                //p_objGrp.DrawString("病史记录者：" + (m_objContent == null ? "" : new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
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
        #region 情况
        /// <summary>
        /// 签名
        /// </summary>
        private class clsPrint2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = { "引产原因", "医保号", "备皮", "冲洗阴道", "用药情况" };//"引产方法", "引产时间", "药物剂量", "手术难道", "产前", "产时", "产后"};
            private string[] m_strKeysArr101 = { "引产原因：", "医保号：" ,"\n术前处理：\n         备皮：", "冲洗阴道：", "\n         用药情况："};//"\n引产方法：", "\n引产时间：", "\n药物剂量：", "\n手术难度：", "\n辅助用药：\n         产前：", "\n         产时：", "\n         产后：" };
           
         
        

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
                       // if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                      //      m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                     //   m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                    //    m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                    //    m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                    //    if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                   //         m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);
                     //   m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                    //    if (m_blnHavePrintInfo(m_strKeysArr08) != false)
                     //       m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
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
                    p_intPosY += 20;
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

        #region 情况
        /// <summary>
        /// 签名
        /// </summary>
        private class clsPrint3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            //private string[] m_strKeysArr01 = { "引产原因", "医保号" };//"备皮", "冲洗阴道", "用药情况", "引产方法", "引产时间", "药物剂量", "手术难道", "产前", "产时", "产后"};
            //private string[] m_strKeysArr101 = { "引产原因：", "医保号：" }; //"\n术前处理：\n         备皮：", "冲洗阴道：", "\n         用药情况：", "\n引产方法：", "\n引产时间：", "\n药物剂量：", "\n手术难度：", "\n辅助用药：\n         产前：", "\n         产时：", "\n         产后：" };
            private string[] m_strKeysArr02 = { "胎儿排时间" };
            private string[] m_strKeysArr102 = { "\n胎儿排出时间：" };
            private string[] m_strKeysArr03 = { "", "方式>>头", "方式>>臀", "方式>>横", "方式>>自然", "方式>>牵引" };
            private string[] m_strKeysArr103 = { "；排出方式：", "方式>>头", "方式>>臀", "方式>>横", "方式>>自然", "方式>>牵引" };
            private string[] m_strKeysArr04 = { "", "胎儿>>男", "胎儿>>女" };
            private string[] m_strKeysArr104 = { "\n胎儿情况：", "胎儿>>男", "胎儿>>女" };
            private string[] m_strKeysArr05 = { "胎儿>>死", "胎儿>>活" };
            private string[] m_strKeysArr105 = { "", "胎儿>>死", "胎儿>>活" };
            private string[] m_strKeysArr06 = { "身长", "体重", "胎盘时间" };
            private string[] m_strKeysArr106 = { "身长：", "体重：", "\n胎盘排出时间：" };
            private string[] m_strKeysArr07 = { "", "胎盘方式>>自然", "胎盘方式>>完全", "胎盘方式>>不全", "胎盘方式>>手剥", "胎盘方式>>钳刮" };
            private string[] m_strKeysArr107 = { "；排出方式：", "胎盘方式>>自然", "胎盘方式>>完全", "胎盘方式>>不全", "胎盘方式>>手剥", "胎盘方式>>钳刮" };
            private string[] m_strKeysArr08 = { "失血量", "失血原因", "子宫收缩情况" };
            private string[] m_strKeysArr108 = { "\n产时及产后失血量：", "大出血原因：", "\n子宫收缩情况：" };

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
                       // if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                       //     m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr103, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr105, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr06) != false)
                            m_mthMakeText(m_strKeysArr106, m_strKeysArr06, ref strAllText, ref strXml);
                        m_mthMakeCheckText(m_strKeysArr107, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr08) != false)
                            m_mthMakeText(m_strKeysArr108, m_strKeysArr08, ref strAllText, ref strXml);
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
                    p_intPosY += 20;
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
        /// 眼科检查
        /// </summary>
        private class clsPrintInPatMedRecOphthalmologyCheck : clsIMR_PrintLineBase
        {
            #region Define

            private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private string m_strTitle = "";
            private string[] m_strTitleArr = null;
            private clsInpatMedRec_Item[] m_objItemContentLArr = null;
            private clsInpatMedRec_Item[] m_objItemContentRArr = null;
           // private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 格子高度
            /// </summary>
            private const int c_intHeight = 40;
            /// <summary>
            /// 左竖线X轴
            /// </summary>
            private const int c_intShortLeft = 140;
            /// <summary>
            /// 右竖线X轴
            /// </summary>
            private const int c_intShortRight = 30;
            /// <summary>
            /// 打印内容格子宽度
            /// </summary>
            private const int c_intWidth = 650;
            /// <summary>
            /// 打印小标题宽度
            /// </summary>
            private const int c_intTitleWidth = 80;
            private int m_intLongLineTop = 150;
            /// <summary>
            /// 打印横线的X坐标
            /// </summary>
            private int m_intLeftX = (int)enmRectangleInfo.LeftX - 10;

            private int m_intIndex = 0;
            int m_intPosY;

            #endregion

            public clsPrintInPatMedRecOphthalmologyCheck()
            { }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY == m_intLongLineTop + 5)
                {
                    m_mthPrintLine(ref p_intPosY, p_objGrp, p_fntNormalText);
                }
                Rectangle rtgTitle = new Rectangle(m_intLeftX, p_intPosY + 5, c_intTitleWidth, c_intHeight);
                Rectangle rtgTitle2 = new Rectangle(m_intLeftX, p_intPosY + 5, 20, c_intHeight);
                Rectangle rtgTitle3 = new Rectangle(m_intLeftX + 30, p_intPosY + 5, 60, c_intHeight);
                Rectangle rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth, 10);
                Rectangle rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth, 10);

                StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
                Font fntTitle = new Font("SimSun", 12);

                int intRealHeight = 0;
                int intTempHeight = 0;
                m_intPosY = p_intPosY;
              //  System.Resources.ResourceManager rm = new ResourceManager("HRPControl.Resources.Image", new com.digitalwave.Utility.Controls.ctlPaintContainer().GetType().Assembly);


                //********************
                if (m_strTitleArr == null)
                {
                    if (p_intPosY + 40 > ((int)enmRectangleInfo.BottomY - 50))
                    {
                        m_blnHaveMoreLine = true;
                        p_intPosY += 500;
                        return;
                    }
                    //if (m_strTitle == "晶状体")hhjhj
                    //{
                    //    rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 100, 100);
                    //    rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 100, 100);
                    //  //  Image img = (Bitmap)rm.GetObject("晶状体");
                    //  //  p_objGrp.DrawImage(img, c_intShortLeft + c_intWidth - 100, p_intPosY + 10, 100, 80);
                    //   // p_objGrp.DrawImage(img, c_intShortRight + c_intWidth - 100, p_intPosY + 10, 100, 80);
                    //}
                    p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle, stfTitle);
                    string str = "<root />";
                    if (m_strTitle == "引产方法")
                    {
                        p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                        if (m_objItemContentRArr != null)
                        {
                            string strSign = (m_objItemContentRArr[0] == null ? "" : (m_objItemContentRArr[0].m_strItemContent == null ? "" : m_objItemContentRArr[0].m_strItemContent));
                            //if (m_objItemContentRArr[1] != null && m_objItemContentRArr[1].m_strItemContent != null && m_objItemContentRArr[1].m_strItemContent != "")
                            //{
                            //    strSign += " 矫正" + (m_objItemContentRArr[1] == null ? "" : (m_objItemContentRArr[1].m_strItemContent == null ? "" : m_objItemContentRArr[1].m_strItemContent));
                            //}
                            m_objDiagnoseR.m_mthSetContextWithCorrectBefore(strSign, str, m_dtmFirstPrintTime, true);
                        }
                        if (m_objItemContentLArr != null)
                        {
                            string strSign2 = (m_objItemContentLArr[0] == null ? "" : (m_objItemContentLArr[0].m_strItemContent == null ? "" : m_objItemContentLArr[0].m_strItemContent));
                            if (m_objItemContentLArr[1] != null && m_objItemContentLArr[1].m_strItemContent != null && m_objItemContentLArr[1].m_strItemContent != "")
                            {
                                strSign2 += " 矫正" + (m_objItemContentLArr[1] == null ? "" : (m_objItemContentLArr[1].m_strItemContent == null ? "" : m_objItemContentLArr[1].m_strItemContent));
                            }
                            m_objDiagnoseL.m_mthSetContextWithCorrectBefore(strSign2, str, m_dtmFirstPrintTime, true);
                        }
                    }

                    else
                        m_mthSetPrintInfo(m_objDiagnoseR, m_objDiagnoseL, (m_objItemContentRArr == null ? null : m_objItemContentRArr[0]), (m_objItemContentLArr == null ? null : m_objItemContentLArr[0]));
                    m_objDiagnoseR.m_blnPrintAllBySimSun(11, rtgDianoseR, p_objGrp, out intRealHeight, false);
                    intTempHeight = intRealHeight;
                    m_objDiagnoseL.m_blnPrintAllBySimSun(11, rtgDianoseL, p_objGrp, out intRealHeight, false);
                    int intHeight = Math.Max(intTempHeight, intRealHeight);
                    if (intHeight > Math.Max(c_intHeight, rtgDianoseR.Height))
                    {
                        p_intPosY += intHeight + 5;
                    }
                    else
                    {
                        p_intPosY += Math.Max(c_intHeight, rtgDianoseR.Height);
                    }
                    p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                }
                else
                {
                    if (m_blnIsFirstPrint == true)
                    {
                        if (m_strTitle == "瞳孔")
                        {
                            rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 72, 0);
                            rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 72, 0);
                           // Image img = (Bitmap)rm.GetObject("瞳孔");
                          //  p_objGrp.DrawImage(img, c_intShortLeft + c_intWidth - 72, p_intPosY + 10, 72, 48);
                         //   p_objGrp.DrawImage(img, c_intShortRight + c_intWidth - 72, p_intPosY + 10, 72, 48);
                        }
                        if (m_strTitle == "眼底情况")
                        {
                            rtgDianoseR = new Rectangle(c_intShortLeft, p_intPosY + 5, c_intWidth - 100, 0);
                            rtgDianoseL = new Rectangle(c_intShortRight, p_intPosY + 5, c_intWidth - 100, 0);
                          //  Image imgR = (Bitmap)rm.GetObject("右视网膜");
                           // Image imgL = (Bitmap)rm.GetObject("左视网膜");
                          //  p_objGrp.DrawImage(imgR, c_intShortLeft + c_intWidth - 100, p_intPosY + 10, 100, 100);
                          //  p_objGrp.DrawImage(imgL, c_intShortRight + c_intWidth - 100, p_intPosY + 10, 100, 100);
                        }
                        m_blnIsFirstPrint = false;
                    }
                    for (int i = m_intIndex; i < m_strTitleArr.Length; i++)
                    {
                        if (p_intPosY + 40 > ((int)enmRectangleInfo.BottomY - 50))
                        {
                            m_blnHaveMoreLine = true;
                            m_intIndex = i;
                            p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle2, stfTitle);
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, m_intPosY, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortLeft, m_intPosY, c_intShortLeft, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortRight, m_intPosY, c_intShortRight, p_intPosY);
                            p_intPosY += 500;
                            return;
                        }
                        p_objGrp.DrawString(m_strTitleArr[i], fntTitle, Brushes.Black, rtgTitle3, stfTitle);

                        m_mthSetPrintInfo(m_objDiagnoseR, m_objDiagnoseL, (m_objItemContentRArr == null ? null : m_objItemContentRArr[i]), (m_objItemContentLArr == null ? null : m_objItemContentLArr[i]));
                        m_objDiagnoseR.m_blnPrintAllBySimSun(11, rtgDianoseR, p_objGrp, out intRealHeight, false);

                        intTempHeight = intRealHeight;
                        m_objDiagnoseL.m_blnPrintAllBySimSun(11, rtgDianoseL, p_objGrp, out intRealHeight, false);
                        int intHeight = Math.Max(intTempHeight, intRealHeight);
                        if (intHeight > Math.Max(c_intHeight, rtgDianoseR.Height))
                        {
                            p_intPosY += intHeight + 2;
                        }
                        else
                        {
                            p_intPosY += Math.Max(c_intHeight, rtgDianoseR.Height);
                        }
                        rtgDianoseR.Y = p_intPosY + 2;
                        rtgDianoseL.Y = p_intPosY + 2;
                        rtgTitle3.Y = p_intPosY + 3;

                        if (m_strTitle == "眼底情况" || m_strTitle == "瞳孔")
                        {
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY, (int)enmRectangleInfo.LeftX + c_intWidth - 100, p_intPosY);
                            p_objGrp.DrawLine(Pens.Black, c_intShortRight, p_intPosY, c_intShortRight + c_intWidth - 100, p_intPosY);
                        }
                        else
                            p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    }
                    rtgTitle2.Height = p_intPosY - m_intPosY;
                    p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    p_objGrp.DrawLine(Pens.Black, (int)enmRectangleInfo.LeftX + 20, m_intPosY, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, rtgTitle2, stfTitle);
                }
                p_objGrp.DrawLine(Pens.Black, c_intShortLeft, m_intPosY, c_intShortLeft, p_intPosY);
                p_objGrp.DrawLine(Pens.Black, c_intShortRight, m_intPosY, c_intShortRight, p_intPosY);
                //********************
                fntTitle.Dispose();
                stfTitle.Dispose();

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objDiagnoseR.m_mthRestartPrint();
                m_objDiagnoseL.m_mthRestartPrint();
            }
            /// <summary>
            /// 打印顶部直线和标题
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            private void m_mthPrintLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_objGrp.DrawString("右                                 左", p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX + 100, p_intPosY + 3);
                p_intPosY += 30;
                p_objGrp.DrawLine(Pens.Black, m_intLeftX, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
            }

            public void m_mthSetPrintValue(string[] p_strKeyForRArr, string[] p_strKeyForLArr, string p_strTitle, string[] p_strTitleArr)
            {
                m_objItemContentLArr = m_objGetContentFromItemArr(p_strKeyForLArr);
                m_objItemContentRArr = m_objGetContentFromItemArr(p_strKeyForRArr);
                m_strTitle = p_strTitle;
                m_strTitleArr = p_strTitleArr;
            }

            private void m_mthSetPrintInfo(clsPrintRichTextContext p_objDiagnoseR, clsPrintRichTextContext p_objDiagnoseL, clsInpatMedRec_Item p_objItemR, clsInpatMedRec_Item p_objItemL)
            {
                p_objDiagnoseR.m_mthRestartPrint();
                p_objDiagnoseL.m_mthRestartPrint();
                p_objDiagnoseR.m_mthSetContextWithCorrectBefore((p_objItemR == null ? "" : (p_objItemR.m_strItemContent == null ? "" : p_objItemR.m_strItemContent))
                    , (p_objItemR == null ? "<root />" : (p_objItemR.m_strItemContentXml == null ? "<root />" : p_objItemR.m_strItemContentXml)), m_dtmFirstPrintTime, p_objItemR == null);
                p_objDiagnoseL.m_mthSetContextWithCorrectBefore((p_objItemL == null ? "" : (p_objItemL.m_strItemContent == null ? "" : p_objItemL.m_strItemContent))
                    , (p_objItemL == null ? "<root />" : (p_objItemL.m_strItemContentXml == null ? "<root />" : p_objItemL.m_strItemContentXml)), m_dtmFirstPrintTime, p_objItemL == null);

                m_mthAddSign2(m_strTitle, m_objDiagnoseR.m_ObjModifyUserArr);
            }

        }
        #region 签名
        /// <summary>
        /// 签名
        /// </summary>
        private class clsPrint15 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private Font m_fontItemMidHead = new Font("", 12, FontStyle.Bold);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private string[] m_strKeysArr01 = { "医生签名" };
            private string[] m_strKeysArr101 = { "医生签名：" };
            //private string[] m_strKeysArr02 = { "主任医师" };
            //private string[] m_strKeysArr102 = { "\n主治医师签名：" };

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
                        //if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                        //    m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);

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
                    p_intPosY += 20;
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX +500, p_intPosY, p_objGrp);
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
