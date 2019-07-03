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
    class clsIMR_peopleLostlayPrint : clsInpatMedRecPrintBase
    {
        public clsIMR_peopleLostlayPrint(string p_strTypeID)
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
                                                                           new clsPrintPatientFixInfo("人工流产手术记录",320),
                                                                        //   new clsPrint2(),
                                                                         //  new clsPrint3(),
                                                                       //    new clsPrint4(),
                                                                          new clsPrint5(),
                                                                        //   new clsPrint6(),
                                                                        //   new clsPrint7(),
                                                                        //   new clsPrint8(),
                                                                        //   new clsPrint9(),
                                                                       //    new clsPrint10(),
                                                                         //  new clsPrint11(),
                                                                          // new clsPrint12(),
                                                                         //  new clsPrint13(),
                                                                      //   new clsPrint14(),
                                                                       
                                                                      //   new clsPrint16(),
                                                                   //    new clsPrint17(),
                                                                     new clsPrint15(),
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
                // p_objGrp.DrawString("皮肤科住院病历", m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY - 10);

                // p_intPosY += 20;
                p_objGrp.DrawString("XHTCM/RD-133", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 140);
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                // p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                  p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                 p_intPosY += 20;

                //  p_objGrp.DrawString("供史者和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);


                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
               p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

             p_intPosY += 20;
                 p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                  p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
               p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
               p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_strLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

               p_intPosY += 20;
               p_objGrp.DrawString("婚姻：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

         p_intPosY += 20;
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("工作单位：" + m_objPrintInfo.m_strOfficeName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                }

                m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

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
        #region 既往史
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



            private string[] m_strKeysArr05b = { "术中用药", "术中特殊", "术后处理" };
            private string[] m_strKeysArr105b = { "ml \n术中用药：", "\n术中特殊情况：", "\n术后处理：" };



            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                           string[] m_strKeysArr01 = { "医保号", "手术时间", "体格>>t", "体格>>r", "体格>>bp", "体格>>p","" };
           string[] m_strKeysArr101 = { "医保号：", "手术时间：", "\nT：", "℃  R：$$", "次/分  BP：$$", "mmHg  P：$$", "次/分$$" };
           string[] m_strKeysArr01a = { "子宫位置", "孕时间", "术前宫腔", "术后宫腔" };
           string[] m_strKeysArr101a = { "\n子宫位置：", "位；孕：$$", "周；\n术前宫腔：$$", "cm；  术后宫腔：$$"};
                    string[] m_strKeysArr02 = { "扩宫一号", "二号", "吸号"};
             string[] m_strKeysArr102 = { "cm  \n扩宫 $$", "号致$$", "号  用$$" };
                
        
             string[] m_strKeysArr03 = { "负压", "宫次数", "绒毛直径", "脱膜多少" };
             string[] m_strKeysArr103 = { "号吸管吸刮\n负压：$$", "mmHg  吸宫次数：$$", "次  \n绒毛直径：$$","cm  脱膜：$$" };
            string[] m_strKeysArr04 = { "", "钳刮>>钳夹胎盘", "钳刮>>钳夹胎儿肢体" };
             string[] m_strKeysArr104 = { "克  \n钳刮术：", "钳刮>>钳夹胎盘", "钳刮>>钳夹胎儿肢体" };
             string[] m_strKeysArr05 = { "碎胎肢体", "碎胎合适", "胎儿肢体", "肢体完全", "术中出血" };
            string[] m_strKeysArr105 = { "\n碎胎术：碎胎肢体：","cm  碎胎肢体是否合适：$$","\n胎儿肢体：","cm  肢体是否完全：$$","术中出血：" };
                if (m_blnIsFirstPrint)
                {

                    string strAllText = "";
                    string strXml = "";
                    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    if (m_objContent != null)
                    {
                        if (m_blnHavePrintInfo(m_strKeysArr01) != false)
                            m_mthMakeText(m_strKeysArr101, m_strKeysArr01, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr01a) != false)
                            m_mthMakeText(m_strKeysArr101a, m_strKeysArr01a, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr03) != false)
                            m_mthMakeText(m_strKeysArr103, m_strKeysArr03, ref strAllText, ref strXml);
                       
                        m_mthMakeCheckText(m_strKeysArr104, ref strAllText, ref strXml);
                        if (m_blnHavePrintInfo(m_strKeysArr05) != false)
                            m_mthMakeText(m_strKeysArr105, m_strKeysArr05, ref strAllText, ref strXml);

                        if (m_blnHavePrintInfo(m_strKeysArr05b) != false)
                            m_mthMakeText(m_strKeysArr105b, m_strKeysArr05b, ref strAllText, ref strXml);




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

            private string[] m_strKeysArr01 = { "医师签名", "上级医师签名" };
            private string[] m_strKeysArr101 = { "\n 手术医师签名：","\n上级医师签名：" };
            private string[] m_strKeysArr02 = { "医生日期" };
            private string[] m_strKeysArr102 = { "\n日  期：" };

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
                        if (m_blnHavePrintInfo(m_strKeysArr02) != false)
                            m_mthMakeText(m_strKeysArr102, m_strKeysArr02, ref strAllText, ref strXml);

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
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 500, p_intPosY, p_objGrp);
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
