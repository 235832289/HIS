using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iCareData;
using HRP;
using com.digitalwave.Utility.Controls;
using System.Drawing.Printing;
using com.digitalwave.PatientManagerService;
using com.digitalwave.Emr.Signature_gui;
using System.Data;

namespace iCare
{
    /// <summary>
    /// 产科出院记录打印类
    /// </summary>
    public class clsIMR_CKOutHospitalRecPrintTool : clsInpatMedRecPrintBase
    {
        internal static Hashtable m_hasItemDetail;
        public clsIMR_CKOutHospitalRecPrintTool(string p_strTypeID)
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
                                          new clsIMR_ckOutPintDetail(),
                                          new clsPrintInPatMedRecCaseyz(),
                                         new clsPrintSign1()
			});
        }
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
                        //						m_hasItemDetail.Add(objItem.m_strItemName,"");
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
        #region 打印实现
        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            public clsPrintPatientFixInfo()
            {
                clsInpatMedRecPrintBase.m_strChildTitleName = "出院小结";
            }
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //p_objGrp.DrawString("产科出院记录", m_fotItemHead, Brushes.Black, m_intRecBaseX + 290, p_intPosY - 10);

                //p_intPosY += 20;
                //p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                //p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //出院时间

                clsOutHospitalRecordContent m_objRecordOutHost = null;
                clsOutHospitalDomain m_myOutHosptialDom;
                DateTime m_dtTmp = DateTime.Now;
                if (m_objPrintInfo.m_strInPatientID == "" || m_objPrintInfo.m_dtmOpenDate == DateTime.MinValue)
                {
                    m_myOutHosptialDom = null;
                }
                else
                {
                    m_myOutHosptialDom = new clsOutHospitalDomain();
                    clsTrackRecordContent objContent = new clsTrackRecordContent();
                    long lngResm = m_myOutHosptialDom.m_lngGetRecordContent(m_objPrintInfo.m_objContent.m_strInPatientID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                    if (lngResm > 0)
                    {
                        m_objRecordOutHost = (clsOutHospitalRecordContent)objContent;
                    }
                    if (m_objRecordOutHost != null)
                        m_dtTmp = m_objRecordOutHost.m_dtmOutHospitalDate;
                    
                }


                //*出院时间
                
                //p_intPosY += 20;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("住院日期：" + m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("住院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                }
                DateTime p_dtmOutHospitalDate = new DateTime(1900, 1, 1);
                string strRegisterID = "";
                long lngRes = 0;


                if (m_dtTmp != DateTime.MinValue)
                {
                    p_objGrp.DrawString("至：" + m_dtTmp.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("至：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                p_intPosY += 20;

                TimeSpan m_ds_During = m_dtTmp - m_objPrintInfo.m_dtmHISInDate;


                p_objGrp.DrawString("住院天数：" + m_ds_During.Days.ToString() + "天", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);

               
                p_intPosY += 30;
                m_blnHaveMoreLine = false;
                
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 诊断：
        /// </summary>
        private class clsIMR_ckOutPintDetail : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

             
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private clsInpatMedRec_Item objItemContent = null;


            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                    
                p_objGrp.DrawString("诊断：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                p_intPosY += 20;

                if (m_hasItemDetail == null)
                {
                    clsInpatMedRec_Item[] p_objItemArr = m_objPrintInfo.m_objContent.m_objItemContents;
                    if (p_objItemArr == null)
                        return;
                    Hashtable hasItem = new Hashtable(400);
                    m_hasItemDetail = new Hashtable(400);
                    foreach (clsInpatMedRec_Item objItem in p_objItemArr)
                    {
                        try
                        {
                            if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
                            {
                                continue;
                                //						m_hasItemDetail.Add(objItem.m_strItemName,"");
                            }
                            else
                            {
                                m_hasItemDetail.Add(objItem.m_strItemName, objItem.m_strItemContent);
                                hasItem.Add(objItem.m_strItemName, objItem);
                            }
                        }
                        catch { continue; }
                    }
                    m_hasItems = hasItem;
                }
                p_objGrp.DrawString("产妇因孕:                W(G      P      )先露（                 ），入院待产。", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>因孕"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>因孕"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 160, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>W-G"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>W-G"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>W-P"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>W-P"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>先露"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>先露"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("于:                                       婴    个,(                              ）", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>生产日期"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>生产日期"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 95, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>生产方式>>顺产"))
                    p_objGrp.DrawString("顺产", p_fntNormalText, Brushes.Black, m_intRecBaseX + 270, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>生产方式>>吸产"))
                    p_objGrp.DrawString("吸产".ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 270, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>生产方式>>产钳娩出"))
                    p_objGrp.DrawString("产钳娩出", p_fntNormalText, Brushes.Black, m_intRecBaseX + 270, p_intPosY);


                if (m_hasItemDetail.Contains("诊断>>性别>>女"))
                    p_objGrp.DrawString("女", p_fntNormalText, Brushes.Black, m_intRecBaseX + 355, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>性别>>男"))
                    p_objGrp.DrawString("男".ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 335, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>婴儿数量"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>婴儿数量"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 425, p_intPosY);

                //if (m_hasItemDetail.Contains("诊断>>会阴破裂"))
                //    p_objGrp.DrawString(m_hasItemDetail["诊断>>会阴破裂"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 95, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>会阴破裂Ⅰ°"))
                    p_objGrp.DrawString("会阴破裂Ⅰ°,".ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>会阴破裂Ⅱ°"))
                    p_objGrp.DrawString("会阴破裂Ⅱ°,".ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                if (m_hasItemDetail.Contains("诊断>>会阴破裂Ⅲ° "))
                    p_objGrp.DrawString("会阴破裂Ⅲ°,".ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);

                if (m_hasItemDetail.Contains("诊断>>会阴侧切"))
                    p_objGrp.DrawString("  会阴侧切", p_fntNormalText, Brushes.Black, m_intRecBaseX + 600, p_intPosY);

                
                p_intPosY += 20;
                p_objGrp.DrawString("产后出血      ml，产后母婴情况良好，现在产母体温正常，子宫复旧好，恶露正常。会阴伤口", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);

                if (m_hasItemDetail.Contains("诊断>>产后出血"))
                    p_objGrp.DrawString(m_hasItemDetail["诊断>>产后出血"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 120, p_intPosY);


                
                p_intPosY += 20;
                p_objGrp.DrawString("愈合佳，准予出院。", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 10, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("出院医嘱：1、产后42-56天来医院门诊复查。", p_fntNormalText, Brushes.Black, m_intRecBaseX + 80, p_intPosY);
                //p_intPosY += 20;
                //p_objGrp.DrawString("             出院医嘱：2", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                p_intPosY += 20;
                //p_intPosY += 20;
                //if (m_hasItemDetail.Contains("出院医嘱 "))
                //    p_objGrp.DrawString(m_hasItemDetail["出院医嘱"].ToString(), p_fntNormalText, Brushes.Black, m_intRecBaseX + 295, p_intPosY);


                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 20;
                    m_objPrintContext.m_mthPrintLine(800, m_intRecBaseX + 50, p_intPosY, p_objGrp);
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
        /// 现病史
        /// </summary>
        private class clsPrintInPatMedRecCaseyz : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                    if (m_hasItems.Contains("出院医嘱"))
                        objItemContent = m_hasItems["出院医嘱"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent == null ? "" : objItemContent.m_strItemContent), (objItemContent == null ? "<root />" : objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, false);
                           

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                   
                     
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


        #endregion

        
        /// <summary>
        /// 把所有项按描述为键放入Hastable
        /// </summary>
        /// <param name="p_hasItem"></param>
        /// <param name="p_ctlItem"></param>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
       
    }
    /// <summary>
    /// 打印画图
    /// </summary>
    internal class clsPrintInPatMedRecPic211 : clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        /// <summary>
        /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
        /// </summary>
        private bool m_blnIsFirstPrint = true;
        private int m_intCurrentPic = 0;
        public static bool m_blnIsPrinted = false;
        public bool m_blnMustPrinted = false;
        public clsPrintInPatMedRecPic211(bool p_blnMustPrinted)
        {
            m_blnMustPrinted = p_blnMustPrinted;
        }

        public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        {
            if (m_objContent == null || m_objPrintInfo.m_objContent.m_objPics == null || m_objPrintInfo.m_objContent.m_objPics.Length < 1 || m_blnIsPrinted == true)
            {
                m_blnHaveMoreLine = false;
                return;
            }
            m_blnHaveMoreLine = false;
            if (m_blnIsFirstPrint)
            {
                int intPicHeight = m_objPrintInfo.m_objContent.m_objPics[0].intHeight;
                int intPicWidth = m_objPrintInfo.m_objContent.m_objPics[0].intWidth;

                if (p_intPosY + intPicHeight > 844)
                {
                    m_blnHaveMoreLine = false;
                    if (m_blnMustPrinted)
                    {
                        p_intPosY += intPicHeight;
                        m_blnHaveMoreLine = true;
                    }
                    return;
                }
                else
                {
                    p_intPosY += 20;
                    int intLeft = m_intRecBaseX + 10;
                    for (int i = m_intCurrentPic; i < m_objPrintInfo.m_objContent.m_objPics.Length; i++)
                    {
                        System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[i].m_bytImage);
                        Image imgPrint = new Bitmap(objStream);

                        p_objGrp.DrawImage(imgPrint, intLeft, p_intPosY, m_objPrintInfo.m_objContent.m_objPics[i].intWidth, m_objPrintInfo.m_objContent.m_objPics[i].intHeight);
                        intLeft += m_objPrintInfo.m_objContent.m_objPics[i].intWidth + 10;
                        intPicHeight = Math.Max(intPicHeight, m_objPrintInfo.m_objContent.m_objPics[i].intHeight);

                        //还有图片要打
                        if (i + 1 < m_objPrintInfo.m_objContent.m_objPics.Length)
                        {
                            //图片超过一行
                            if ((int)enmRectangleInfo.RightX - intLeft < intPicWidth)
                            {
                                m_blnHaveMoreLine = true;
                                p_intPosY += intPicHeight;
                                intLeft = m_intRecBaseX + 10;
                                m_intCurrentPic = i + 1;
                                return;
                            }
                        }
                    }
                }
                p_intPosY += intPicHeight + 20;
                m_blnIsFirstPrint = false;
            }
            m_blnIsPrinted = true;
        }
        public override void m_mthReset()
        {
            m_blnIsFirstPrint = true;

            m_blnHaveMoreLine = true;

            //打印预览或者打印后都得重置
            m_intCurrentPic = 0;

            m_blnIsPrinted = false;
        }
       
       
    }
    ///打印签名
    internal class clsPrintSign1 : clsInpatMedRecPrintBase.clsIMR_PrintLineBase
    {
        public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        {

            if (m_objPrintInfo != null)
            {
                p_intPosY += 30;
                p_objGrp.DrawString("医生签名：" + this.m_objPrintInfo.m_objContent.objSignerArr[0].objEmployee.m_strLASTNAME_VCHR, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                p_intPosY += 25;

                p_objGrp.DrawString("日期：" + this.m_objPrintInfo.m_objContent.m_dtmRecordDate.ToString("yyyy年MM月dd日  hh:mm"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
            }
            m_blnHaveMoreLine = false;
        }
        
    }
}
