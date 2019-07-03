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
    ///  剖宫产手术记录(广西)
    /// </summary>
    public class clsEMR_CesareanRecordPrintTool : infPrintRecord,IDisposable
    {
        #region 变量
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        /// <summary>
        /// 表明此次打印是外部赋值(false)还是类内部自动从数据库提取数据(true)
        /// </summary>
        private bool m_blnIsFromDataSource = true;
        /// <summary>
        /// 标识打印对象在邦定打印数据之前是否初始化
        /// </summary>
        private bool m_blnWantInit = true;
        /// <summary>
        /// 打印页计时器，标识当前第几页
        /// </summary>
        private int m_intCurrentPage = 1;
        /// <summary>
        /// 打印的数据对象
        /// </summary>
        private clsPrintInfo_EMR_CesareanRecord m_objPrintInfo = null;
        /// <summary>
        /// 打印帮助类
        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext = null;
        /// <summary>
        /// 当前打印位置（Y）
        /// </summary>
        private int m_intYPos = 130;//155;
        /// <summary>
        /// 标题字体
        /// </summary>
        public static Font m_fotHeader = null;//clsEMR_CesareanRecordPrintTool.m_fotHeader
        /// <summary>
        /// 页脚字体
        /// </summary>
        public static Font m_fotFooter = null;//clsEMR_CesareanRecordPrintTool.m_fotFooter
        /// <summary>
        /// 正文字体
        /// </summary>
        public static Font m_fotContent = null;//clsEMR_CesareanRecordPrintTool.m_fotContent
        /// <summary>
        /// 签名字体
        /// </summary>
        public static Font m_fotSign = null;//clsEMR_CesareanRecordPrintTool.m_fotSign
        ///// <summary>
        ///// 获取坐标的类
        ///// </summary>
        //private clsPrintPageSettingForRecord m_objPageSetting;
        #endregion
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static clsEMR_CesareanRecordPrintTool()
        {
            clsEMR_CesareanRecordPrintTool.m_fotHeader = new Font("Simsun", 18);
            clsEMR_CesareanRecordPrintTool.m_fotFooter = new Font("Simsun", 12);
            clsEMR_CesareanRecordPrintTool.m_fotContent = new Font("Simsun", 12);
            clsEMR_CesareanRecordPrintTool.m_fotSign = new Font("Simsun", 8);
        }

        #region 注释
        /// <summary>
        /// 打印边框的左边距
        /// </summary>
        //private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
        /// <summary>
        /// 标题的字体(20 bold)
        /// </summary>
        //private Font m_fotTitleFont;
        /// <summary>
        /// 表头的字体(14 )
        /// </summary>
        //private Font m_fotHeaderFont;
        /// <summary>
        /// 表内容的字体(11)
        /// </summary>
        //private Font m_fotSmallFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        //private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        //private SolidBrush m_slbBrush;
        /// <summary>
        /// 打印元素
        /// </summary>
        //private enum enmItemDefination
        //{
        //    //基本元素
        //    InPatientID_Title,
        //    InPatientID,
        //    Name_Title,
        //    Name,
        //    Sex_Title,
        //    Sex,
        //    Age_Title,
        //    Age,
        //    Dept_Name_Title,
        //    Dept_Name,
        //    BedNo_Title,
        //    BedNo,

        //    Page_HospitalName,
        //    Page_Name_Title,
        //    Page_Title,
        //    Page_Num,
        //    Page_Of,
        //    Page_Count,

        //    Print_Date_Title,
        //    Print_Date,
        //    //填充表格元素
        //    RecordDate,
        //    RecordTime,
        //    RecordContent,
        //    RecordSign1,
        //    RecordSign2
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //protected class clsPrintPageSettingForRecord
        //{
        //    public clsPrintPageSettingForRecord() { }

        //    /// <summary>
        //    /// 获得坐标点
        //    /// </summary>
        //    /// <param name="p_intItemName">项目名称</param>
        //    /// <returns></returns>
        //    public PointF m_getCoordinatePoint(int p_intItemName)
        //    {
        //        float fltOffsetX = 20;//X的偏移量
        //        PointF m_fReturnPoint;
        //        switch (p_intItemName)
        //        {
        //            case (int)enmItemDefination.Page_HospitalName:
        //                m_fReturnPoint = new PointF(340f - fltOffsetX, 40f);
        //                break;
        //            case (int)enmItemDefination.Page_Name_Title:
        //                m_fReturnPoint = new PointF(310f - fltOffsetX, 70f);
        //                break;
        //            case (int)enmItemDefination.Name_Title:
        //                m_fReturnPoint = new PointF(55f - fltOffsetX, 105f);
        //                break;
        //            case (int)enmItemDefination.Name:
        //                m_fReturnPoint = new PointF(95f - fltOffsetX, 105f);
        //                break;

        //            case (int)enmItemDefination.Sex_Title:
        //                m_fReturnPoint = new PointF(175f - fltOffsetX, 105f);
        //                break;
        //            case (int)enmItemDefination.Sex:
        //                m_fReturnPoint = new PointF(220f - fltOffsetX, 105f);
        //                break;

        //            case (int)enmItemDefination.Age_Title:
        //                m_fReturnPoint = new PointF(250f - fltOffsetX, 105f);
        //                break;
        //            case (int)enmItemDefination.Age:
        //                m_fReturnPoint = new PointF(295f - fltOffsetX, 105f);
        //                break;

        //            case (int)enmItemDefination.Dept_Name_Title:
        //                m_fReturnPoint = new PointF(365f, 105f);
        //                break;
        //            case (int)enmItemDefination.Dept_Name:
        //                m_fReturnPoint = new PointF(415f, 105f);
        //                break;

        //            case (int)enmItemDefination.BedNo_Title:
        //                m_fReturnPoint = new PointF(565f, 105f);
        //                break;
        //            case (int)enmItemDefination.BedNo:
        //                m_fReturnPoint = new PointF(610f, 105f);
        //                break;

        //            case (int)enmItemDefination.InPatientID_Title:
        //                m_fReturnPoint = new PointF(655f - fltOffsetX, 105f);
        //                break;
        //            case (int)enmItemDefination.InPatientID:
        //                m_fReturnPoint = new PointF(720f - fltOffsetX, 105f);
        //                break;

        //            default:
        //                m_fReturnPoint = new PointF(405f, 400f);
        //                break;
        //        }
        //        return m_fReturnPoint;
        //    }
        //}
        #endregion

        #region 格子的信息
        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRectangleInfoEMR_CesareanRecord
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 140,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 16,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 180 + 17,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 7,
            SmallRowStep = 20,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,

            ColumnsMark1 = 35,
            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,
            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1024,

            PrintWidth = 690,
            PrintWidth2 = 600,//710,
        }
        #endregion

        #region 打印内容类
        /// <summary>
        /// 打印内容之父类
        /// </summary>
        private abstract class clsEMR_CesareanRecordInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            /// <summary>
            /// 文字距离左边的边距 
            /// </summary>
            protected int m_intPatientInfoX = 70;
            /// <summary>
            /// 病人信息
            /// </summary>
            protected clsPrintInfo_EMR_CesareanRecord m_objPrintInfo;
            /// <summary>
            /// 手术记录
            /// </summary>
            protected clsEMR_CesareanRecordValue m_objContent;
            /// <summary>
            /// 
            /// </summary>
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return base.m_blnHaveMoreLine;
                }
                set
                {
                    if (value != null)
                    {
                        this.m_objPrintInfo = (clsPrintInfo_EMR_CesareanRecord)value;
                        this.m_objContent = this.m_objPrintInfo.m_objRecordContent;
                    }
                }
            }
        }
        /// <summary>
        /// 标题及病人基本信息ok
        /// </summary>
        private class clsEMR_CesareanRecordFixInfo : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 是否第一次打印该类中的内容
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objPrintInfo != null && this.m_blnIsFirstPrint)
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.LineAlignment = StringAlignment.Center;
                    //标题
                    p_objGrp.DrawString("剖宫产手术记录", clsEMR_CesareanRecordPrintTool.m_fotHeader, Brushes.Black, base.m_intPatientInfoX + 260, p_intPosY - 50, stringFormat);
                    //p_intPosY += 50;
                    stringFormat.Dispose();

                    p_objGrp.DrawString("姓名：" + base.m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);//200
                    p_objGrp.DrawString("年龄：" + (base.m_objPrintInfo.m_strAge == null ? "   岁" : base.m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);//100
                    string tempContent = null;

                    if (base.m_objContent.m_intPREGNANTTIMES >= 0)
                    {
                        tempContent = base.m_objContent.m_intPREGNANTTIMES.ToString();
                    }
                    else
                        tempContent = "";

                    p_objGrp.DrawString("孕：  " + tempContent, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 300, p_intPosY);//100

                    if (base.m_objContent.m_intLAYTIMES >= 0)
                    {
                        tempContent = base.m_objContent.m_intLAYTIMES.ToString();
                    }
                    else
                        tempContent = "";

                    p_objGrp.DrawString("产：  " + tempContent, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 400, p_intPosY);//100
                    p_objGrp.DrawString("住院号：" + (base.m_objPrintInfo.m_strInPatentID == null ? "" : base.m_objPrintInfo.m_strInPatentID), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 500, p_intPosY);

                    p_intPosY += 20;
                    p_objGrp.DrawString("入院：" + (base.m_objPrintInfo.m_dtmInPatientDate == null ? "" : base.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);//200
                    p_objGrp.DrawString("手术：" + (base.m_objPrintInfo.m_dtmOpenDate == null ? "" : base.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);

                    p_intPosY += 20;
                    this.m_blnIsFirstPrint = false;
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 术前诊断ok
        /// </summary>
        private class clsEMR_CesareanRecordBeforeOperation : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("术前诊断：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISBEFOREOP) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISBEFOREOPXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strDIAGNOSISBEFOREOP,
                                                                                        base.m_objContent.m_strDIAGNOSISBEFOREOPXML,
                                                                                        base.m_dtmFirstPrintTime, true);

                                this.m_mthAddSign2("术前诊断：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strDIAGNOSISBEFOREOP,base.m_objContent.m_strDIAGNOSISBEFOREOPXML);
                        }
                        else
                        {
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 手术指征ok
        /// </summary>
        private class clsEMR_CesareanRecordOperation : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("手术指征：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strOPINDICATION) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strOPINDICATIONXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strOPINDICATION, 
                                                                                        base.m_objContent.m_strOPINDICATIONXML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                this.m_mthAddSign2("手术指征：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strOPINDICATION, base.m_objContent.m_strOPINDICATIONXML);
                        }
                        else
                        {
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 术后诊断ok
        /// </summary>
        private class clsEMR_CesareanRecordAffterOperation : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("术后诊断：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISAFTEROP) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISAFTEROPXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strDIAGNOSISAFTEROP, 
                                                                                        base.m_objContent.m_strDIAGNOSISAFTEROPXML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                this.m_mthAddSign2("术后诊断：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strDIAGNOSISAFTEROP, base.m_objContent.m_strDIAGNOSISAFTEROPXML);
                        }
                        else
                        {
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 手术名称ok
        /// </summary>
        private class clsEMR_CesareanRecordOperationName : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("手术名称：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strOPNAME) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strOPNAMEXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strOPNAME, 
                                                                                        base.m_objContent.m_strOPNAMEXML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                base.m_mthAddSign2("手术名称：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strOPNAME, base.m_objContent.m_strOPNAMEXML);
                        }
                        else
                        {
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 麻醉方式ok
        /// </summary>
        private class clsEMR_CesareanRecordAnaMode : clsEMR_CesareanRecordInfo
        {
            //private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        string AnaDoctorName = "";
                        foreach (clsEmrSigns_VO sign in base.m_objContent.objSignerArr)
                        {
                            if (sign.controlName.Equals("m_txtAnaesthetist", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaDoctorName += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR +" ";
                                //break;m_txtAnaesthetist
                            }
                        }
                        p_objGrp.DrawString("麻醉方式：" + base.m_objContent.m_strANAMODE, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        //在此添加 “麻醉师“
                        p_objGrp.DrawString("麻醉师：" + AnaDoctorName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 250, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                //else
                //{
                //    base.m_blnHaveMoreLine = false;
                //    return;
                //}

                base.m_blnHaveMoreLine = false;
                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 300, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //    base.m_blnHaveMoreLine = true;
                //else
                //    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                //this.m_objPrintContext.m_mthRestartPrint();
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 术前产检ok
        /// </summary>
        private class clsEMR_CesareanRecordCheckBeforeOP : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("术前产检：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        string strAllText = "宫高：" + (base.m_objContent == null ? " " : base.m_objContent.m_strUTERUSHEIGHT_RIGHT) + "cm " +
                                            " 腹围：" + (base.m_objContent == null ? " " : base.m_objContent.m_strABDOMENROUND_RIGHT) + "cm " +
                                            " 先露：" + (base.m_objContent == null ? " " : base.m_objContent.m_strPRESENTATION1) +
                                            " 衔接：" + (base.m_objContent == null ? " " : base.m_objContent.m_strLINKUP) +
                                            " 估计胎重：" + (base.m_objContent == null ? " " : base.m_objContent.m_strFETUSWEIGHT_RIGHT) + "g。";

                        this.m_objPrintContext.m_mthSetContextWithAllCorrect(strAllText, "<root />");
                        this.m_blnIsFirstPrint = false;
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 术前阴查ok
        /// </summary>
        private class clsEMR_CesareanRecordUnCheckBeforeOP : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("术前阴查：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);//70
                        p_intPosY += 20;
                        if (!base.m_objContent.m_strUnCheckBeforeOP.Trim().Equals("1"))
                        {
                            p_objGrp.DrawString("坐骨棘：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//50
                            if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 120, p_intPosY);//20
                            p_objGrp.DrawString("平伏、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);//50
                            if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 190, p_intPosY);
                            p_objGrp.DrawString("稍突、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 210, p_intPosY);
                            if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 260, p_intPosY);
                            p_objGrp.DrawString("突出  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 280, p_intPosY);

                            p_objGrp.DrawString("尾骨弧度：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);//70
                            if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 440, p_intPosY);
                            p_objGrp.DrawString("高、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);//30
                            if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 490, p_intPosY);
                            p_objGrp.DrawString("中、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 510, p_intPosY);
                            if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 540, p_intPosY);
                            p_objGrp.DrawString("低  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 560, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("坐骨切迹：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);
                            p_objGrp.DrawString(">2指、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 160, p_intPosY);//50
                            if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 210, p_intPosY);
                            p_objGrp.DrawString("=2指、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 230, p_intPosY);
                            if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 280, p_intPosY);
                            p_objGrp.DrawString("<2指 ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 310, p_intPosY);

                            p_objGrp.DrawString("耻骨弓：" + base.m_objContent.m_strPUBICARCH_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);//80
                            p_objGrp.DrawString("DC：" + base.m_objContent.m_strDC_RIGHT + " cm", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                            p_objGrp.DrawString("宫口：" + base.m_objContent.m_strUTERUSORA_RIGHT + " cm", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 580, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("羊水：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS1.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 120, p_intPosY);
                            p_objGrp.DrawString("清、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX  + 140, p_intPosY);//40
                            if (base.m_objContent.m_strAMNIOCENTESIS1.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 180, p_intPosY);
                            p_objGrp.DrawString("Ⅰ、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS1.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 240, p_intPosY);
                            p_objGrp.DrawString("Ⅱ、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 260, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS1.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 300, p_intPosY);
                            p_objGrp.DrawString("Ⅲ  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX  + 320, p_intPosY);//70

                            p_objGrp.DrawString("先露：" + base.m_objContent.m_strPRESENTATION2_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);
                            p_objGrp.DrawString("胎方位：" + base.m_objContent.m_strFETUSPLACE1_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                            p_objGrp.DrawString("先露高低：" + base.m_objContent.m_strPRESENTATIONHEITHT_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 580, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("颅骨变形：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            if (base.m_objContent.m_strSKULL.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);
                            p_objGrp.DrawString("有、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 160, p_intPosY);
                            if (base.m_objContent.m_strSKULL.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 190, p_intPosY);
                            p_objGrp.DrawString("无  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 210, p_intPosY);

                            p_objGrp.DrawString("产瘤：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 240, p_intPosY);
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZE_YN.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 270, p_intPosY);//10
                            p_objGrp.DrawString("有、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 290, p_intPosY);
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZE_YN.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 320, p_intPosY);
                            p_objGrp.DrawString("无  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 330, p_intPosY);
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZE_YN.Trim().Equals("10"))
                            {
                                p_objGrp.DrawString("产瘤大小：" + base.m_objContent.m_strCAPUTSUCCEDANEUMSIZE_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);
                                p_objGrp.DrawString("产瘤位置：" + base.m_objContent.m_strCAPUTSUCCEDANEUMPLACE1_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                            }
                        }
                        else
                        {
                            p_objGrp.DrawString(" √ (未检) ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY - 8);
                        }

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 手术方式ok
        /// </summary>
        private class clsEMR_CesareanRecordOperationMode : clsEMR_CesareanRecordInfo
        {
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("手术方式：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        if (!base.m_objContent.m_strUnCheckBeforeOP.Trim().Equals("1"))
                        {
                            p_objGrp.DrawString("腹壁：纵：" + base.m_objContent.m_strABDOMINALWALL_V_RIGHT + "、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//170
                            p_objGrp.DrawString("横：" + base.m_objContent.m_strABDOMINALWALL_H_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 240, p_intPosY);//130

                            p_objGrp.DrawString("筋膜：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 380, p_intPosY);//40
                            if (base.m_objContent.m_strFASCIA.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);//10
                            p_objGrp.DrawString("纵、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 440, p_intPosY);//30
                            if (base.m_objContent.m_strFASCIA.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 470, p_intPosY);
                            p_objGrp.DrawString("横、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 490, p_intPosY);
                            if (base.m_objContent.m_strFASCIA.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 520, p_intPosY);
                            p_objGrp.DrawString("钝性、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 540, p_intPosY);//40
                            if (base.m_objContent.m_strFASCIA.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 580, p_intPosY);
                            p_objGrp.DrawString("锐性  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 600, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("腹膜：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            if (base.m_objContent.m_strPERITONEUM.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 100, p_intPosY);
                            p_objGrp.DrawString("纵、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 120, p_intPosY);
                            if (base.m_objContent.m_strPERITONEUM.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 150, p_intPosY);
                            p_objGrp.DrawString("横、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 170, p_intPosY);
                            if (base.m_objContent.m_strPERITONEUM.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            p_objGrp.DrawString("钝性、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 220, p_intPosY);//40
                            if (base.m_objContent.m_strPERITONEUM.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 260, p_intPosY);
                            p_objGrp.DrawString("锐性  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 280, p_intPosY);

                            p_objGrp.DrawString("子宫：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 380, p_intPosY);//40
                            if (base.m_objContent.m_strUTERUS.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);
                            p_objGrp.DrawString("体部、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 440, p_intPosY);//40
                            if (base.m_objContent.m_strUTERUS.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                            p_objGrp.DrawString("下段、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 500, p_intPosY);
                            if (base.m_objContent.m_strUTERUS.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 540, p_intPosY);
                            p_objGrp.DrawString("纵、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 560, p_intPosY);
                            if (base.m_objContent.m_strUTERUS.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 600, p_intPosY);
                            p_objGrp.DrawString("横  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 620, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("胎方位：" + base.m_objContent.m_strFETUSPLACE2_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//150
                            
                            p_objGrp.DrawString("入盆：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 240, p_intPosY);
                            if (base.m_objContent.m_strENGAGEMENT.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 270, p_intPosY);
                            p_objGrp.DrawString("浮、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 290, p_intPosY);
                            if (base.m_objContent.m_strENGAGEMENT.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 320, p_intPosY);
                            p_objGrp.DrawString("浅、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 340, p_intPosY);
                            if (base.m_objContent.m_strENGAGEMENT.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);
                            p_objGrp.DrawString("深  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 390, p_intPosY);//40

                            p_objGrp.DrawString("先露娩出：" + base.m_objContent.m_strPRESENTATION2_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 450, p_intPosY);//70
                            if (base.m_objContent.m_strPRESENTATIONEXPULSION.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 520, p_intPosY);
                            p_objGrp.DrawString("易、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 540, p_intPosY);
                            if (base.m_objContent.m_strPRESENTATIONEXPULSION.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 570, p_intPosY);
                            p_objGrp.DrawString("较难、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 590, p_intPosY);
                            if (base.m_objContent.m_strPRESENTATIONEXPULSION.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 620, p_intPosY);
                            p_objGrp.DrawString("很难  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 640, p_intPosY);
                        }

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public override void m_mthReset()
            {
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 手术经过ok
        /// </summary>
        private class clsEMR_CesareanRecordOpeProcess : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("手术经过：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        if (!base.m_objContent.m_strUnCheckBeforeOP.Trim().Equals("1"))
                        {
                            p_objGrp.DrawString("娩出时间：" + base.m_objContent.m_dtmEXPULSIONTIME.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//230
                            p_objGrp.DrawString("性别：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 300, p_intPosY);//30
                            if (base.m_objContent.m_strBABYSEX.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 330, p_intPosY);
                            p_objGrp.DrawString("男、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 350, p_intPosY);
                            if (base.m_objContent.m_strBABYSEX.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 370, p_intPosY);
                            p_objGrp.DrawString("女  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 390, p_intPosY);//40

                            p_objGrp.DrawString("体重：" + base.m_objContent.m_strBABYWEIGHT_RIGHT + " g", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 430, p_intPosY);//100
                            p_objGrp.DrawString("阿氏评分：" + base.m_objContent.m_strAPGAR_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 530, p_intPosY);//100
                            p_intPosY += 20;

                            p_objGrp.DrawString("胎儿外观：" + base.m_objContent.m_strFETUSFACIES_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("产瘤：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//30
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZEY_YN.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 100, p_intPosY);
                            p_objGrp.DrawString("有、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 120, p_intPosY);//30
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZEY_YN.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 150, p_intPosY);
                            p_objGrp.DrawString("无  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 170, p_intPosY);//40
                            if (base.m_objContent.m_strCAPUTSUCCEDANEUMSIZEY_YN.Trim().Equals("10"))
                            {
                                p_objGrp.DrawString("产瘤大小：" + base.m_objContent.m_strCAPUTSUCCEDANEUMSIZEX_RIGHT + " × " + base.m_objContent.m_strCAPUTSUCCEDANEUMSIZEY_RIGHT + "cm，", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 210, p_intPosY);//250
                                p_objGrp.DrawString("产瘤位置：" + base.m_objContent.m_strCAPUTSUCCEDANEUMPLACE2_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);//100
                            }
                            p_intPosY += 20;

                            p_objGrp.DrawString("羊水：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//30
                            if (base.m_objContent.m_strAMNIOCENTESIS2.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 100, p_intPosY);
                            p_objGrp.DrawString("清、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 120, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS2.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);
                            p_objGrp.DrawString("Ⅰ、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 160, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS2.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 180, p_intPosY);
                            p_objGrp.DrawString("Ⅱ、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            if (base.m_objContent.m_strAMNIOCENTESIS2.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 220, p_intPosY);
                            p_objGrp.DrawString("Ⅲ  ", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 240, p_intPosY);//30
                            p_objGrp.DrawString("量约：" + base.m_objContent.m_strAMNIOCENTESISBULK_RIGHT + " ml", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("胎盘：" + base.m_objContent.m_strPLACENTA_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//400
                            p_objGrp.DrawString("脐带：" + base.m_objContent.m_strUMBILICALCORD_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("胎膜：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//40
                            if (base.m_objContent.m_strEMBRYOLEMMACIRCS.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 110, p_intPosY);
                            p_objGrp.DrawString("完整、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 130, p_intPosY);//50
                            if (base.m_objContent.m_strEMBRYOLEMMACIRCS.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 180, p_intPosY);
                            p_objGrp.DrawString("不完整", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("左输卵管：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//70
                            if (base.m_objContent.m_strOVIDUCTCIRCS.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);
                            p_objGrp.DrawString("正常、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 160, p_intPosY);//40
                            if (base.m_objContent.m_strOVIDUCTCIRCS.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            p_objGrp.DrawString("异常；", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 220, p_intPosY);//40

                            p_objGrp.DrawString("左卵巢：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 350, p_intPosY);//50
                            if (base.m_objContent.m_strOVARYCIRCS.Trim().Substring(0, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 400, p_intPosY);
                            p_objGrp.DrawString("正常、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);
                            if (base.m_objContent.m_strOVARYCIRCS.Trim().Substring(1, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);
                            p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                            p_intPosY += 20;

                            p_objGrp.DrawString("右输卵管：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                            if (base.m_objContent.m_strOVIDUCTCIRCS.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 140, p_intPosY);
                            p_objGrp.DrawString("正常、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 160, p_intPosY);
                            if (base.m_objContent.m_strOVIDUCTCIRCS.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 200, p_intPosY);
                            p_objGrp.DrawString("异常；", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 220, p_intPosY);//40

                            p_objGrp.DrawString("右卵巢：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 350, p_intPosY);
                            if (base.m_objContent.m_strOVARYCIRCS.Trim().Substring(2, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 400, p_intPosY);
                            p_objGrp.DrawString("正常、", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);
                            if (base.m_objContent.m_strOVARYCIRCS.Trim().Substring(3, 1).Equals("1"))
                                p_objGrp.DrawString(" √", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 460, p_intPosY);
                            p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 480, p_intPosY);
                        }

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                    //p_intPosY += 20;
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public override void m_mthReset()
            {
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 缝合 >> 子宫ok
        /// </summary>
        private class clsEMR_CesareanRecordSutureUterus : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 
            /// </summary>
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("缝合：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("子宫：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                        this.m_blnIsFirstPrint = false;

                        if (!string.IsNullOrEmpty(base.m_objContent.m_strSUTUREUTERUS) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strSUTUREUTERUSXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strSUTUREUTERUS, 
                                                                                        base.m_objContent.m_strSUTUREUTERUSXML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                this.m_mthAddSign2("缝合：子宫：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strSUTUREUTERUS, base.m_objContent.m_strSUTUREUTERUSXML);
                        } 
                        else
                        {
                            p_intPosY += 20;
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 110, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 缝合 >> 腹壁ok
        /// </summary>
        private class clsEMR_CesareanRecordSutureAbdominalwall : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 
            /// </summary>
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("腹壁：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strSUTUREABDOMINALWALL) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strSUTUREABDOMINALWALLXML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strSUTUREABDOMINALWALL, 
                                                                                        base.m_objContent.m_strSUTUREABDOMINALWALLXML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                this.m_mthAddSign2("缝合：腹壁：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strSUTUREABDOMINALWALL, base.m_objContent.m_strSUTUREABDOMINALWALLXML);
                        }
                        else
                        {
                            p_intPosY += 20;
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 110, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 术中用药ok
        /// </summary>
        private class clsEMR_CesareanRecordMedicine : clsEMR_CesareanRecordInfo
        {
            /// <summary>
            /// 
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("术中用药：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);//70
                        p_intPosY += 20;

                        p_objGrp.DrawString("催产素：" + base.m_objContent.m_strOXYTOCIN_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//350
                        p_objGrp.DrawString("其它：" + base.m_objContent.m_strOTHERMEDICINE_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);
                        p_intPosY += 20;

                        p_objGrp.DrawString("尿量：" + base.m_objContent.m_strPISS_RIGHT + " ml", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 70, p_intPosY);//200
                        p_objGrp.DrawString("出血：" + base.m_objContent.m_strBLEEDING_RIGHT + " ml", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 270, p_intPosY);//200
                        p_objGrp.DrawString("输血：" + base.m_objContent.m_strTRANSFUSE_RIGHT, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 420, p_intPosY);
                        p_intPosY += 20;

                        p_objGrp.DrawString("麻醉时间：" + base.m_objContent.m_strANATIME, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_objGrp.DrawString("手术时间：" + base.m_objContent.m_strOPTime, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 250, p_intPosY);

                        this.m_blnIsFirstPrint = false;
                    }
                    p_intPosY += 20;
                }
                base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 
            /// </summary>
            public override void m_mthReset()
            {
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 备注ok
        /// </summary>
        private class clsEMR_CesareanRecordCommon : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        p_objGrp.DrawString("备注：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strSUMARY4) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strSUMARY4XML))
                        {
                            if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strSUMARY4, 
                                                                                        base.m_objContent.m_strSUMARY4XML, 
                                                                                        base.m_dtmFirstPrintTime, true);
                                this.m_mthAddSign2("备注：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strSUMARY4, base.m_objContent.m_strSUMARY4XML);
                        }
                        else
                        {
                            base.m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }

                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 30, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                else
                    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 手术者ok
        /// </summary>
        private class clsEMR_CesareanRecordOperator : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        string operatorName = "";
                        foreach (clsEmrSigns_VO sign in base.m_objContent.objSignerArr)
                        {
                            if (sign.controlName.Equals("m_txtOperator", StringComparison.OrdinalIgnoreCase))
                            {
                                operatorName += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR +" ";
                              //  break;
                            }
                        }

                        p_objGrp.DrawString("手术者：" + operatorName, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        //p_objGrp.DrawString("手术者：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);

                        //if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                        //{
                        //    this.m_objPrintContext.m_mthSetContextWithCorrectBefore((base.m_objContent == null ? "//在此添加手术者" : operatorName), (base.m_objContent == null ? "<root />" : operatorName), base.m_dtmFirstPrintTime, base.m_objContent != null);
                        //    this.m_mthAddSign2("手术者：", this.m_objPrintContext.m_ObjModifyUserArr);
                        //}
                        //else
                        //    this.m_objPrintContext.m_mthSetContextWithAllCorrect((base.m_objContent == null ? "//在此添加手术者" : operatorName), (base.m_objContent == null ? "<root />" : operatorName));

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                //else
                //{
                //    base.m_blnHaveMoreLine = false;
                //    return;
                //}
                base.m_blnHaveMoreLine = false;
                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 50, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //    base.m_blnHaveMoreLine = true;
                //else
                //    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 第一助手ok
        /// </summary>
        private class clsEMR_CesareanRecordFirstAssistant : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        string firstAssistant = "";
                        foreach (clsEmrSigns_VO sign in base.m_objContent.objSignerArr)
                        {
                            if (sign.controlName.Equals("m_lsvAssistant1", StringComparison.OrdinalIgnoreCase))
                            {
                                firstAssistant += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR + " ";
                              //  break;
                            }
                        }
                        if (string.IsNullOrEmpty(firstAssistant))
                            firstAssistant = base.m_objContent.m_strASSISTANT1;

                        p_objGrp.DrawString("第一助手：" + firstAssistant, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);

                        //if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                        //{
                        //    this.m_objPrintContext.m_mthSetContextWithCorrectBefore((base.m_objContent == null ? "//在此添加第一助手" : firstAssistant), (base.m_objContent == null ? "<root />" : firstAssistant), base.m_dtmFirstPrintTime, base.m_objContent != null);
                        //    this.m_mthAddSign2("第一助手：", this.m_objPrintContext.m_ObjModifyUserArr);
                        //}
                        //else
                        //    this.m_objPrintContext.m_mthSetContextWithAllCorrect((base.m_objContent == null ? "//在此添加第一助手" : firstAssistant), (base.m_objContent == null ? "<root />" : firstAssistant));

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                //else
                //{
                //    base.m_blnHaveMoreLine = false;
                //    return;
                //}
                base.m_blnHaveMoreLine = false;

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //    base.m_blnHaveMoreLine = true;
                //else
                //    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 第二助手ok
        /// </summary>
        private class clsEMR_CesareanRecordSecondAssistant : clsEMR_CesareanRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_CesareanRecordPrintTool.m_fotContent);
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            /// <summary>
            /// 绘制
            /// </summary>
            /// <param name="p_intPosY"></param>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            public override void m_mthPrintNextLine(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
            {
                if (base.m_objContent != null)
                {
                    if (this.m_blnIsFirstPrint)
                    {
                        string secondAssistant = "";
                        foreach (clsEmrSigns_VO sign in base.m_objContent.objSignerArr)
                        {
                            if (sign.controlName.Equals("m_lsvAssistant2", StringComparison.OrdinalIgnoreCase))
                            {
                                secondAssistant += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR + " ";
                              //  break;
                            }
                        }
                        if (string.IsNullOrEmpty(secondAssistant))
                            secondAssistant = base.m_objContent.m_strASSISTANT2;

                        //p_objGrp.DrawString("第二助手：", p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);
                        p_objGrp.DrawString("第二助手：" + secondAssistant, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX, p_intPosY);

                        //if (clsEMR_CesareanRecordPrintTool.m_blnIsPrintMark)
                        //{
                        //    this.m_objPrintContext.m_mthSetContextWithCorrectBefore((base.m_objContent == null ? "//在此添加第二助手" : secondAssistant), (base.m_objContent == null ? "<root />" : secondAssistant), base.m_dtmFirstPrintTime, base.m_objContent != null);
                        //    this.m_mthAddSign2("第二助手：", this.m_objPrintContext.m_ObjModifyUserArr);
                        //}
                        //else
                        //    this.m_objPrintContext.m_mthSetContextWithAllCorrect((base.m_objContent == null ? "//在此添加第二助手" : secondAssistant), (base.m_objContent == null ? "<root />" : secondAssistant));

                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                    }
                }
                //else
                //{
                //    base.m_blnHaveMoreLine = false;
                //    return;
                //}
                base.m_blnHaveMoreLine = false;

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_CesareanRecord.PrintWidth2, base.m_intPatientInfoX + 70, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}

                //if (this.m_objPrintContext.m_BlnHaveNextLine())
                //    base.m_blnHaveMoreLine = true;
                //else
                //    base.m_blnHaveMoreLine = false;
            }
            /// <summary>
            /// 重置参数
            /// </summary>
            public override void m_mthReset()
            {
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        #endregion PrintClasses

        #region infPrintRecord 成员

        /// <summary>
        /// 初始化打印所用到的病人信息
        /// </summary>
        /// <param name="p_objPatient"></param>
        /// <param name="p_dtmInPatientDate"></param>
        /// <param name="p_dtmOpenDate"></param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            this.m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            this.m_objPrintInfo = new clsPrintInfo_EMR_CesareanRecord();
            this.m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            this.m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            this.m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            this.m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            this.m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            this.m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            this.m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            this.m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            this.m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            this.m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            this.m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }
        /// <summary>
        /// 打印 1 初始化打印内容
        /// 打印从数据库读取得内容
        /// </summary>
        public void m_mthInitPrintContent()
        {
            this.m_blnWantInit = false;
            if (this.m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("在执行m_mthInitPrintContent之前请先执行m_mthSetPrintInfo函数");
                return;
            }

            clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_CesareanRecord);

            if (!string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID) && this.m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue)
            {
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                //从数据库读取打印所需数据
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(this.m_objPrintInfo.m_strInPatentID, this.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), this.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                
                if (lngRes <= 0)
                    return;
                this.m_objPrintInfo.m_objRecordContent = objContent as clsEMR_CesareanRecordValue;
            }
            //m_objRecordsDomain = null;
            //设置表单内容到打印中			
            this.m_mthSetPrintContent(this.m_objPrintInfo.m_objRecordContent, this.m_objPrintInfo.m_dtmFirstPrintDate);
        }
        /// <summary>
        /// 设置打印内容
        /// </summary>
        /// <param name="p_objContent"></param>
        /// <param name="p_dtmFirstPrintDate"></param>
        private void m_mthSetPrintContent(clsEMR_CesareanRecordValue p_objContent, DateTime p_dtmFirstPrintDate)
        {
            this.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext
                (
                    new com.digitalwave.Utility.Controls.clsPrintLineBase[]
                    {
                       new clsEMR_CesareanRecordFixInfo(),
                       new clsEMR_CesareanRecordBeforeOperation(),
                       new clsEMR_CesareanRecordOperation(),
                       new clsEMR_CesareanRecordAffterOperation(),
                       new clsEMR_CesareanRecordOperationName(),
                       new clsEMR_CesareanRecordAnaMode(),
                       new clsEMR_CesareanRecordCheckBeforeOP(),
                       new clsEMR_CesareanRecordUnCheckBeforeOP(),
                       new clsEMR_CesareanRecordOperationMode(),
                       new clsEMR_CesareanRecordOpeProcess(),
                       new clsEMR_CesareanRecordSutureUterus(),
                       new clsEMR_CesareanRecordSutureAbdominalwall(),
                       new clsEMR_CesareanRecordMedicine(),
                       new clsEMR_CesareanRecordCommon(),
                       new clsEMR_CesareanRecordOperator(),
                       new clsEMR_CesareanRecordFirstAssistant(),
                       new clsEMR_CesareanRecordSecondAssistant()
                    }
                );
            this.m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
            //设置打印信息，就是Set Value进去
            this.m_objPrintLineContext.m_ObjPrintLineInfo = this.m_objPrintInfo;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
            this.m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
        }
        /// <summary>
        /// 打印 2 初始化打印内容
        /// 打印不需要从数据库读取且已存在的数据，与“打印 1” 的过程不同时执行
        /// </summary>
        /// <param name="p_objPrintContent"></param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            //this.m_blnWantInit = false;
            //if (p_objPrintContent.GetType().Name != "clsPrintInfo_EMR_CesareanRecord")
            //{
            //    MDIParent.ShowInformationMessageBox("参数错误");
            //}
            //m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            //this.m_objPrintInfo.m_objRecordContent = (clsPrintInfo_EMR_CesareanRecord)p_objPrintContent;

            //m_mthSetPrintContent(m_objPrintInfo.m_objRecordContent, m_objPrintInfo.m_dtmFirstPrintDate);
        }
        /// <summary>
        /// 获取该打印对象实例的打印内容
        /// </summary>
        /// <returns></returns>
        public object m_objGetPrintInfo()
        {
            if (this.m_blnIsFromDataSource)
            {
                if (this.m_objPrintInfo == null)
                {
                    MDIParent.ShowInformationMessageBox("打印尚未初始化，请先执行m_mthSetPrintInfo函数。");
                    return null;
                }

                if (this.m_blnWantInit)
                    this.m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (this.m_objPrintInfo.m_objRecordContent == null)
                return null;
            else
                return this.m_objPrintInfo;
        }
        /// <summary>
        /// 初始化打印工具类的一些属性，如：打印过程中所使用的字体、画刷等
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            //this.m_objPageSetting = new clsPrintPageSettingForRecord();
        }
        /// <summary>
        /// 垃圾回收
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthDisposePrintTools(object p_objArg)
        {
        }
        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            //m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            this.m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }
        /// <summary>
        /// 结束打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            this.m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (!this.m_blnIsFromDataSource || string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID)) 
                return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && this.m_objPrintInfo.m_blnIsFirstPrint)
            {
                clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_CesareanRecord);
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(this.m_objPrintInfo.m_strInPatentID,
                                                                    this.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                                                    this.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), 
                                                                    this.m_objPrintInfo.m_dtmFirstPrintDate);
            }
        }

        #endregion

        #region 打印方法
        /// <summary>
        /// 打印内容
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            //可在此添加打印标头页尾的代码
            //逐行打印
            while (this.m_objPrintLineContext.m_BlnHaveMoreLine)
            {
                //换页打印，条件：还有打印行，但该页已打满
                // p_objPrintPageArg.MarginBounds.Height PageBounds
                if ((this.m_intYPos > (p_objPrintPageArg.PageBounds.Height - 150)) && this.m_objPrintLineContext.m_BlnHaveMoreLine)
                {
                    this.m_mthPrintFoot(p_objPrintPageArg);
                    p_objPrintPageArg.HasMorePages = true;
                    this.m_intYPos = 130;//155;
                    this.m_intCurrentPage++;
                    return;
                }
                //打印行
                Pen newPen = new Pen(Brushes.Black);
                newPen.Width = 2;
                //打印边框
                //p_objPrintPageArg.Graphics.DrawRectangle(newPen, 50, 129, p_objPrintPageArg.PageBounds.Right - 50, p_objPrintPageArg.PageBounds.Bottom - 100);
                this.m_objPrintLineContext.m_mthPrintNextLine(ref this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_CesareanRecordPrintTool.m_fotContent);
            }
            //打印签名
            this.m_intYPos += 20;
            while (this.m_objPrintLineContext.m_BlnHaveMoreSign)
            {
                this.m_objPrintLineContext.m_mthPrintNextSign(70 + 10, this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_CesareanRecordPrintTool.m_fotSign);
                m_intYPos += 20;
            }

            //打印页脚，至此该文档全部打完	
            this.m_mthPrintFoot(p_objPrintPageArg);
        }
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            e.Graphics.DrawString("第      页", clsEMR_CesareanRecordPrintTool.m_fotFooter, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 70);
            e.Graphics.DrawString(this.m_intCurrentPage.ToString(), clsEMR_CesareanRecordPrintTool.m_fotFooter, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 70);
        }
        /// <summary>
        /// 重置参数
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            this.m_objPrintLineContext.m_mthReset();
            this.m_intYPos = 155;
            this.m_intCurrentPage = 1;
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            GC.Collect();//强制执行垃圾回收
            //if (clsEMR_CesareanRecordPrintTool.m_fotHeader != null)
            //    clsEMR_CesareanRecordPrintTool.m_fotHeader.Dispose();
            //if (clsEMR_CesareanRecordPrintTool.m_fotContent != null)
            //    clsEMR_CesareanRecordPrintTool.m_fotContent.Dispose();
            //if (clsEMR_CesareanRecordPrintTool.m_fotFooter != null)
            //    clsEMR_CesareanRecordPrintTool.m_fotFooter.Dispose();
            //if (clsEMR_CesareanRecordPrintTool.m_fotSign != null)
            //    clsEMR_CesareanRecordPrintTool.m_fotSign.Dispose();
        }

        #endregion
    }
}