using System;
using System.Text;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;

namespace iCare
{
    /// <summary>
    /// 中孕引产住院病历表   

    /// </summary>
    public class clsIMR_DerivationPrintTool:clsInpatMedRecPrintBase
    {

        public clsIMR_DerivationPrintTool(string p_strTypeID): base(p_strTypeID)
        {

        }


        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 5, 145, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 15, e.PageBounds.Height - 155);
        }
        /// <summary>
        /// 标题文字部分  纪录公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        /// </summary>
        /// <param name="e"></param>
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    int p_intPosY = 40;
        //    e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), Brushes.Black, 340, p_intPosY);
        //    p_intPosY += 30;
        //    e.Graphics.DrawString("中孕引产住院病历", new Font("SimSun", 16, FontStyle.Bold), Brushes.Black, 280, p_intPosY);
        //}


        /// <summary>
        /// 设置打印行
        /// </summary>
        protected override void m_mthSetPrintLineArr()
        {

            //m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext();
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{　new  clsPrintPatientFixInfo("中孕引产住院病历", 300),
                                                                           //new clsPrintFixInfo(),
                                                                             new clsPrint1(),
                                                                           new clsLastHistoryPrint(),
                                                                           new clsSelfHistoryPrint(),
                                                                           new clsPrintHomeHistroy(),
						                                                   new clsPrintTiGeCheck(),
                                                                           new clsPrintShiYanAndMechCheck(),
                                                                           new clsPrintZhenDuan(),
                                                                           new clsPrintChuLi(),
                                                                           new clsPrintActionRecond(),
                                                                           new clsPrintActionProcess(),
                                                                           new clsPrintPensonDetil(),
                                                                           new clsPrintAfterAction()                                                                           
																	   });
        }


        /// <summary>
        /// 打印第一页固定内容 公共的基本信息 姓名,性别,年龄,病区,床号,住院号
        /// </summary>
        //private class clsPrintFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

        //    private bool m_blnIsFirstPrint = true;
        //    private string m_strPrintText = "";
        //    private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
                        
        //    private string strPrintText = "  　";
        //    private clsInpatMedRec_Item objItemContent = null;
           
        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_blnIsFirstPrint)
        //        {
        //            Font m_fotSmallFont = new Font("SimSun", 12);
        //            SolidBrush m_slbBrush = new SolidBrush(Color.Black);
        //            p_intPosY = 110;

        //            p_objGrp.DrawString("姓名：", m_fotSmallFont, m_slbBrush, 50, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, 100, p_intPosY);

        //            p_objGrp.DrawString("性别：", m_fotSmallFont, m_slbBrush, 185, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, 230, p_intPosY);

        //            p_objGrp.DrawString("年龄：", m_fotSmallFont, m_slbBrush, 260, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, 305, p_intPosY);

        //            p_objGrp.DrawString("病区：", m_fotSmallFont, m_slbBrush, 360, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 410, p_intPosY);

        //            p_objGrp.DrawString("床号：", m_fotSmallFont, m_slbBrush, 555, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 605, p_intPosY);

        //            p_objGrp.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 655, p_intPosY);

        //            p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 715, p_intPosY);

        //            p_intPosY += 30;

        //            p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
        //            p_objGrp.DrawString("籍贯：" + m_objPrintInfo.m_strNativePlace, m_fotSmallFont, m_slbBrush, 200, p_intPosY);
        //            p_objGrp.DrawString("户口：" + m_objPrintInfo.m_strHomeplace, m_fotSmallFont, m_slbBrush, 300, p_intPosY);
        //            p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 500, p_intPosY);
        //            p_intPosY += 20;
        //            p_objGrp.DrawString("身份证号：" + m_objPrintInfo.m_strInPatientID, m_fotSmallFont, m_slbBrush, 50, p_intPosY);                 
        //            p_objGrp.DrawString("联系人姓名：" + m_objPrintInfo.m_strLinkManFirstName, m_fotSmallFont, m_slbBrush, 400, p_intPosY);
        //            p_objGrp.DrawString("联系人电话：" + m_objPrintInfo.m_strLinkManPhone, m_fotSmallFont, m_slbBrush, 580, p_intPosY);
        //            p_intPosY += 20;
        //            p_objGrp.DrawString("住址：" + m_objPrintInfo.m_strHomeAddress, m_fotSmallFont, m_slbBrush, 50, p_intPosY);
        //            if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
        //            {
        //                p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, 400, p_intPosY);
        //            }
        //            else
        //            {
        //                p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, 400, p_intPosY);
        //            }
        //            p_objGrp.DrawString(m_strPrintText, p_fntNormalText, Brushes.Black, m_intRecBaseX + 20, p_intPosY);

        //            p_intPosY += 20;
        //            if (m_blnCheckBottom(ref p_intPosY, 60, p_intPosY))
        //            {
        //                m_blnHaveMoreLine = true;
        //                return;
        //            }                    

                    

        //            //m_objPrintContext.m_mthSetContextWithAllCorrect("住址：" + m_objPrintInfo.m_strHomeAddress, "<root />");
        //            int intRealHeight;
        //            Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
        //            m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

        //            //p_intPosY += 30;
        //            m_blnHaveMoreLine = false;

        //            m_strPrintText = "";


        //        if (m_hasItemDetail != null)
        //        {
        //            p_objGrp.DrawString("主诉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>主诉"))
        //            {
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>主诉"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 55, p_intPosY);
        //                p_intPosY += 20;
        //            }
        //            else
        //            {
        //                p_intPosY += 20;

        //            }
        //            p_objGrp.DrawString("现病史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>现病史>>停经"))
        //            {                    
        //                p_objGrp.DrawString("停经:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>停经"]) + "周", p_fntNormalText, Brushes.Black, m_intRecBaseX + 135, p_intPosY);
        //                //p_intPosY += 20;
        //            }
        //            if (m_hasItemDetail.Contains("病史>>现病史>>早孕反应"))
        //            {
        //                p_objGrp.DrawString("早孕反应", p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>早孕反应"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
        //                //p_intPosY += 20;
        //            }
        //            if (m_hasItemDetail.Contains("病史>>现病史>>自觉胎动时间"))
        //            {
        //                p_objGrp.DrawString("自觉胎动时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>自觉胎动时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 615, p_intPosY);
        //                p_intPosY += 20;
        //            }
        //            else
        //            {
        //                p_intPosY += 20;

        //            }
        //            p_objGrp.DrawString("月经史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_objGrp.DrawString("初潮年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>月经史>>初潮年龄"))
        //            {                              
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>初潮年龄"]) + "岁", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
        //                //p_intPosY += 20;
        //            }
        //            p_objGrp.DrawString("痛经:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>月经史>>痛经>>有") && m_hasItemDetail["病史>>月经史>>痛经>>有"] != "")
        //            {                     
        //                p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intRecBaseX + 290, p_intPosY);
        //            }
        //            if (m_hasItemDetail.Contains("病史>>月经史>>痛经>>无") && m_hasItemDetail["病史>>月经史>>痛经>>无"] != "")
        //            {                       
        //                p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intRecBaseX + 290, p_intPosY);
        //            }
        //            p_objGrp.DrawString("周期", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>月经史>>周期"))
        //            {                      
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>周期"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
        //            }
        //            p_objGrp.DrawString("未次月经", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>月经史>>未次月经"))
        //            {
        //                p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["病史>>月经史>>未次月经"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 530, p_intPosY);
        //                p_intPosY += 20;
        //            }
        //            else
        //            {
        //                p_intPosY += 20;
        //            }
        //            p_objGrp.DrawString("孕产史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
        //            p_objGrp.DrawString("孕次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>生产史>>孕次数"))
        //            {                      
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>孕次数"] +"次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 112, p_intPosY);
        //            }
        //            p_objGrp.DrawString("产次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 145, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>生产史>>大产次数"))
        //            {                     
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>大产次数"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
        //            }
        //            p_objGrp.DrawString("人工流产次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 210, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>生产史>>人工流产次数"))
        //            {                       
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>人工流产次数"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
        //            }
        //            p_objGrp.DrawString("自然流产", p_fntNormalText, Brushes.Black, m_intRecBaseX + 340, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>生产史>>自然流产"))
        //            {                     
        //                p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>自然流产"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 412, p_intPosY);
                       
        //            }
        //            p_objGrp.DrawString("未次分娩或流产", p_fntNormalText, Brushes.Black, m_intRecBaseX + 447, p_intPosY);
        //            if (m_hasItemDetail.Contains("病史>>孕产史>>未次分娩或流产"))
        //            {

        //                p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["病史>>孕产史>>未次分娩或流产"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 570, p_intPosY);
        //                p_intPosY += 20;
        //            }
        //            else
        //            {
        //                p_intPosY += 20;
 
        //            }
        //        }//m_hasItemDetail != null 结束

        //            p_fntNormal.Dispose();


        //            m_blnHaveMoreLine = false;


        //        }//m_blnIsFirstPrint 结束

        //        int intLine = 0;
        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //        {
        //            m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

        //            p_intPosY += 20;

        //            intLine++;
        //        }

        //        if (m_objPrintContext.m_BlnHaveNextLine())
        //            m_blnHaveMoreLine = true;
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //        }

        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;

        //        m_blnIsFirstPrint = true;
        //    }

        //}//第一页固定打印结束


        private class clsPrint1: clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                {
                    p_objGrp.DrawString("主诉:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>主诉"))
                    {
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>主诉"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 55, p_intPosY);
                        p_intPosY += 20;
                    }
                    else
                    {
                        p_intPosY += 20;

                    }
                    p_objGrp.DrawString("现病史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>现病史>>停经"))
                    {                    
                        p_objGrp.DrawString("停经:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>停经"]) + "周", p_fntNormalText, Brushes.Black, m_intRecBaseX + 135, p_intPosY);
                        //p_intPosY += 20;
                    }
                    if (m_hasItemDetail.Contains("病史>>现病史>>早孕反应"))
                    {
                        p_objGrp.DrawString("早孕反应", p_fntNormalText, Brushes.Black, m_intRecBaseX + 170, p_intPosY);
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>早孕反应"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);
                        //p_intPosY += 20;
                    }
                    if (m_hasItemDetail.Contains("病史>>现病史>>自觉胎动时间"))
                    {
                        p_objGrp.DrawString("自觉胎动时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>现病史>>自觉胎动时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 615, p_intPosY);
                        p_intPosY += 20;
                    }
                    else
                    {
                        p_intPosY += 20;

                    }
                    p_objGrp.DrawString("月经史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_objGrp.DrawString("初潮年龄:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>月经史>>初潮年龄"))
                    {                              
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>初潮年龄"]) + "岁", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                        //p_intPosY += 20;
                    }
                    p_objGrp.DrawString("痛经:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>月经史>>痛经>>有") && m_hasItemDetail["病史>>月经史>>痛经>>有"] != "")
                    {                     
                        p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intRecBaseX + 290, p_intPosY);
                    }
                    if (m_hasItemDetail.Contains("病史>>月经史>>痛经>>无") && m_hasItemDetail["病史>>月经史>>痛经>>无"] != "")
                    {                       
                        p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intRecBaseX + 290, p_intPosY);
                    }
                    p_objGrp.DrawString("周期", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>月经史>>周期"))
                    {                      
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>月经史>>周期"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
                    }
                    p_objGrp.DrawString("未次月经", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>月经史>>未次月经"))
                    {
                        p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["病史>>月经史>>未次月经"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 530, p_intPosY);
                        p_intPosY += 20;
                    }
                    else
                    {
                        p_intPosY += 20;
                    }
                    p_objGrp.DrawString("孕产史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_objGrp.DrawString("孕次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 75, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>生产史>>孕次数"))
                    {                      
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>孕次数"] +"次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 112, p_intPosY);
                    }
                    p_objGrp.DrawString("产次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 145, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>生产史>>大产次数"))
                    {                     
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>大产次数"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                    }
                    p_objGrp.DrawString("人工流产次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 210, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>生产史>>人工流产次数"))
                    {                       
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>人工流产次数"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    }
                    p_objGrp.DrawString("自然流产", p_fntNormalText, Brushes.Black, m_intRecBaseX + 340, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>生产史>>自然流产"))
                    {                     
                        p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["病史>>生产史>>自然流产"] + "次"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 412, p_intPosY);
                       
                    }
                    p_objGrp.DrawString("未次分娩或流产", p_fntNormalText, Brushes.Black, m_intRecBaseX + 447, p_intPosY);
                    if (m_hasItemDetail.Contains("病史>>孕产史>>未次分娩或流产"))
                    {

                        p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["病史>>孕产史>>未次分娩或流产"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 570, p_intPosY);
                        p_intPosY += 20;
                    }
                    else
                    {
                        p_intPosY += 20;
 
                    }
                }//m_hasItemDetail != null 结束

                    p_fntNormal.Dispose();


                    m_blnHaveMoreLine = false;


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


        /// <summary>
        /// 既往史
        /// </summary>
        private class clsLastHistoryPrint : clsIMR_PrintLineBase
        {

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("病史>>既往史"))
                        objItemContent = m_hasItems["病史>>既往史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("既往史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasitemdetail != null && m_hasitemdetail.contains("病史>>既往史"))
                    //{
                    //    strprinttext += m_hasitemdetail["病史>>既往史"];
                    p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
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


        /// <summary>
        /// 个人史
        /// </summary>
        private class clsSelfHistoryPrint : clsIMR_PrintLineBase
        {

            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("病史>>个人史"))
                        objItemContent = m_hasItems["病史>>个人史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("个人史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>个人史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>个人史"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
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


        /// <summary>
        /// 家族史
        /// </summary>
        private class clsPrintHomeHistroy : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("病史>>家族史"))
                        objItemContent = m_hasItems["病史>>家族史"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("家族史:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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


        /// <summary>
        /// 体格检查
        /// </summary>
        private class clsPrintTiGeCheck : clsIMR_PrintLineBase
        {
           private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
           
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {               
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("全身检查:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("T:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>T"))
                        {                    
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>T"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("R:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>R"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>R"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 205, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("P:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 285, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>P"))
                        {
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>P"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("Bp:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>Bp"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>Bp"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("发育:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 470, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>发育"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>发育"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 525, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("营养:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 580, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>营养"))
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>营养"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 630, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("心脏:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>心脏"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>心脏"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("肺:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>肺"))
                        {
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>肺"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 460, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("肝:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>肝"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>肝"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("脾:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>脾"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>脾"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 460, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("体格检查>>全身检查>>其他"))
                        {
                            p_objGrp.DrawString("其他:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>全身检查>>其他"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            p_intPosY += 20;
                        }

                        p_objGrp.DrawString("妇检:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                        p_objGrp.DrawString("外阴:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 70, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>外阴"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>外阴"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 125, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("阴道:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 170, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>阴道"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>阴道"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 220, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("宫颈:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>宫颈"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>宫颈"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("宫底:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>宫底"))
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>宫底"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 490, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("胎心:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>胎心"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>胎心"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("子宫大小如孕:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>子宫大小如孕"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>子宫大小如孕"]) + "周", p_fntNormalText, Brushes.Black, m_intRecBaseX + 270, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("附件:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("体格检查>>妇检>>附件"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["体格检查>>妇检>>附件"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 410, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
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


        /// <summary>
        /// 实验室及器械检查
        /// </summary>
        private class clsPrintShiYanAndMechCheck : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("实验室及器械检查"))
                        objItemContent = m_hasItems["实验室及器械检查"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("实验室及器械检查:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("实验室及器械检查"))
                    //{
                    //    strPrintText += m_hasItemDetail["实验室及器械检查"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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


        /// <summary>
        /// 诊断
        /// </summary>
        private class clsPrintZhenDuan : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("诊断"))
                        objItemContent = m_hasItems["诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("诊断:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("诊断"))
                    //{
                    //    strPrintText += m_hasItemDetail["诊断"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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

        /// <summary>
        /// 处理
        /// </summary>
        private class clsPrintChuLi : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("处理"))
                        objItemContent = m_hasItems["处理"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("处理:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("处理"))
                    //{
                    //    strPrintText += m_hasItemDetail["处理"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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

        /// <summary>
        /// 手术纪录
        /// </summary>
        private class clsPrintActionRecond : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {               
                if (m_blnIsFirstPrint)
                {
                    if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    {
                        m_blnHaveMoreLine = true;
                        return;
                    }

                    if (m_hasItemDetail != null)
                    {
                        p_objGrp.DrawString("引产方法:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>引产方法>>羊膜") && m_hasItemDetail["手术记录>>引产方法>>羊膜"] !="")
                        {                       
                            p_objGrp.DrawString("羊膜", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            //p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>羊膜"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);

                            if (m_hasItemDetail.Contains("手术记录>>引产方法>>羊膜>>内") && m_hasItemDetail["手术记录>>引产方法>>羊膜>>内"] + ")" != "")
                            {
                                p_objGrp.DrawString("内", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                                //p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>羊膜>>内"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                                //p_intPosY += 20;
                            }
                            if (m_hasItemDetail.Contains("手术记录>>引产方法>>羊膜>>外") && m_hasItemDetail["手术记录>>引产方法>>羊膜>>外"] + ")" != "")
                            {
                                p_objGrp.DrawString("外", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                                //p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>羊膜>>外"]) +")", p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                                //p_intPosY += 20;
                            }
                            p_intPosY += 20;
                        }
                       
                        if (m_hasItemDetail.Contains("手术记录>>引产方法>>水囊") && m_hasItemDetail["手术记录>>引产方法>>水囊"] != "")
                        {
                           
                            p_objGrp.DrawString("水囊", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            //p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>水囊"]) + ")", p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>引产方法>>钳刮") && m_hasItemDetail["手术记录>>引产方法>>钳刮"] != "")
                        {
                          
                            p_objGrp.DrawString("钳刮", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>钳刮"]) + ")", p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>引产方法>>药物") && m_hasItemDetail["手术记录>>引产方法>>药物"] != "")
                        {
                         
                            p_objGrp.DrawString("药物", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>引产方法>>药物"]) + ")", p_fntNormalText, Brushes.Black, m_intRecBaseX + 165, p_intPosY);
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("使用药物:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>使用药物"))
                        {                        
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>使用药物"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>使用药物日期"))
                        {
                            p_objGrp.DrawString("使用药物日期:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                            p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["手术记录>>使用药物日期"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 470, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("利凡诺引产:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("穿刺:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 110, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>利凡诺引产>>穿刺"))
                        {                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>利凡诺引产>>穿刺"]) + "次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("羊水颜色:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 190, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>利凡诺引产>>羊水颜色"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>利凡诺引产>>羊水颜色"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 280, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("注药量:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>利凡诺引产>>注药量"))
                        {
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>利凡诺引产>>注药量"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 430, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("病人情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 520, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>利凡诺引产>>病人情况"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>利凡诺引产>>病人情况"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 610, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("术者"))
                        {
                            p_objGrp.DrawString("手术者:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 540, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["术者"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 610, p_intPosY);
                            p_intPosY += 20;
                        }

                        p_objGrp.DrawString("分娩情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("宫缩开始时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 110, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>宫缩开始时间"))
                        {
                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>宫缩开始时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("破膜时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>破裂时间"))
                        {
                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>破裂时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("胎儿娩出时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿娩出时间"))
                        {                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>胎儿娩出时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("胎儿情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿情况>>男") && m_hasItemDetail["手术记录>>分娩情况>>男"] !="")
                        {                          
                            p_objGrp.DrawString("男", p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, p_intPosY);
                            
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿情况>>女") && m_hasItemDetail["手术记录>>分娩情况>>胎儿情况>>女"] != "")
                        {                         
                            p_objGrp.DrawString("女", p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, p_intPosY);

                        }
                        p_objGrp.DrawString("身长:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿情况>>身长"))
                        {                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>胎儿情况>>身长"]) + "cm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 530, p_intPosY);
                            
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿情况>>死") && m_hasItemDetail["手术记录>>分娩情况>>胎儿情况>>死"] !="")
                        {                            
                            p_objGrp.DrawString("死:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 590, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎儿情况>>活") && m_hasItemDetail["手术记录>>分娩情况>>胎儿情况>>活"] != "")
                        {                           
                            p_objGrp.DrawString("活:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 590, p_intPosY);
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("胎盘娩出时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎盘娩出时间"))
                        {                         
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>胎盘娩出时间"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                            //p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎盘>>完整") && m_hasItemDetail["手术记录>>分娩情况>>胎盘>>完整"] != "")
                        {                           
                            p_objGrp.DrawString("完整", p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎盘>>不完整") && m_hasItemDetail["手术记录>>分娩情况>>胎盘>>不完整"] != "")
                        {
                            p_objGrp.DrawString("不完整", p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎盘>>徒手剥离") && m_hasItemDetail["手术记录>>分娩情况>>胎盘>>徒手剥离"] != "")
                        {                          
                            p_objGrp.DrawString("徒手剥离", p_fntNormalText, Brushes.Black, m_intRecBaseX + 310, p_intPosY);
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("胎膜:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎膜>>完整") && m_hasItemDetail["手术记录>>分娩情况>>胎膜>>完整"] != "")
                        {
                          
                            p_objGrp.DrawString("完整", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);

                        }
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>胎膜>>不完整") && m_hasItemDetail["手术记录>>分娩情况>>胎膜>>不完整"] != "")
                        {
                          
                            p_objGrp.DrawString("不完整", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                            
                        }
                        p_objGrp.DrawString("出血量:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>出血量"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>出血量"] + "ml"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 258, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("血压:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 380, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>分娩情况>>血压"))
                        {
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>分娩情况>>血压"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 445, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        if (m_hasItemDetail.Contains("术者"))
                        {
                            p_objGrp.DrawString("术者:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 540, p_intPosY);
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["术者"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 570, p_intPosY);
                            p_intPosY += 20;
                        }
                        //刮宫情况
                        p_objGrp.DrawString("刮宫情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("时间:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 110, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>时间"))
                        {                          
                            p_objGrp.DrawString(strPrintText = (Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>时间"])).Substring(0, 10), p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                          
                        }
                        p_objGrp.DrawString("子宫大小:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>子宫大小"))
                        {                          
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>子宫大小"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 425, p_intPosY);
                      
                        }
                        p_objGrp.DrawString("产道:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 510, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>产道"))
                        {
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>产道"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("刮出组织:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>刮出组织"))
                        {
                           
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>刮出组织"]), p_fntNormalText, Brushes.Black, m_intRecBaseX + 110, p_intPosY);
                           
                        }
                        p_objGrp.DrawString("出血量:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 350, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>出血量"))
                        {
                       
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>出血量"] + "ml"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }
                        p_objGrp.DrawString("宫腔深:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                        p_objGrp.DrawString("术前:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 90, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>宫腔深>>术前"))
                        {
                            
                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>宫腔深>>术前"] + "cm"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                            //p_intPosY += 20;
                        }
                        p_objGrp.DrawString("术后:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);
                        if (m_hasItemDetail.Contains("手术记录>>刮宫情况>>宫腔深>>术后"))
                        {

                            p_objGrp.DrawString(strPrintText = Convert.ToString(m_hasItemDetail["手术记录>>刮宫情况>>宫腔深>>术后"] + "cm"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_intPosY += 20;
                        }

                        //if (strPrintText != "  术者　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                        //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormal, strPrintText);
                        p_fntNormal.Dispose();
                        m_blnIsFirstPrint = false;
                    }
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

        /// <summary>
        /// 手术经过
        /// </summary>
        private class clsPrintActionProcess : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("术后处理>>手术经过"))
                        objItemContent = m_hasItems["术后处理>>手术经过"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("手术经过:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后处理>>手术经过"))
                    //{
                        strPrintText += m_hasItemDetail["术后处理>>手术经过"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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

        /// <summary>
        /// 病人情况
        /// </summary>
        private class clsPrintPensonDetil : clsIMR_PrintLineBase
        {
            
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("术后处理>>病人情况"))
                        objItemContent = m_hasItems["术后处理>>病人情况"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("病人情况:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后处理>>病人情况"))
                    //{
                    //    strPrintText += m_hasItemDetail["术后处理>>病人情况"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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

        /// <summary>
        /// 术后处理
        /// </summary>
        private class clsPrintAfterAction : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
           
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("术后处理>>术后处理"))
                        objItemContent = m_hasItems["术后处理>>术后处理"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("术后处理:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("术后处理>>术后处理"))
                    //{
                    //    strPrintText += m_hasItemDetail["术后处理>>术后处理"];
                        p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                        m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

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
    