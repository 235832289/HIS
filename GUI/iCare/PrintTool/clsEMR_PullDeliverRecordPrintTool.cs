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
    /// 阴道胎头吸引器助产手术记录打印类
    /// </summary>
    public class clsEMR_PullDeliverRecordPrintTool : infPrintRecord, IDisposable
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
        private clsPrintInfo_PullDeliverRecord m_objPrintInfo = null;
        /// <summary>
        /// 打印帮助类


        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext = null;
        /// <summary>
        /// 当前打印位置（Y）


        /// </summary>
        private int m_intYPos = 130;//155;
        /// <summary>
        /// 打印边框的左边距
        /// </summary>
        protected const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
        /// <summary>
        /// 标题字体
        /// </summary>
        public static Font m_fotHeader = null;
        /// <summary>
        /// 页脚字体
        /// </summary>
        public static Font m_fotFooter = null;
        /// <summary>
        /// 正文字体
        /// </summary>
        public static Font m_fotContent = null;
        /// <summary>
        /// 签名字体
        /// </summary>
        public static Font m_fotSign = null; 
        /// <summary>
        /// 打印元素
        /// </summary>
        private enum enmItemDefination
        {
            //基本元素
            InPatientID_Title,
            InPatientID,
            Name_Title,
            Name,
            Sex_Title,
            Sex,
            Age_Title,
            Age,
            Dept_Name_Title,
            Dept_Name,
            BedNo_Title,
            BedNo,

            Page_HospitalName,
            Page_Name_Title,
            Page_Title,
            Page_Num,
            Page_Of,
            Page_Count,

            Print_Date_Title,
            Print_Date,
            //填充表格元素
            RecordDate,
            RecordTime,
            RecordContent,
            RecordSign1,
            RecordSign2

        }
        
        #endregion

        #region 定义打印各元素的坐标点


        protected class clsPrintPageSettingForRecord
        {
            public clsPrintPageSettingForRecord() { }

            /// <summary>
            /// 获得坐标点


            /// </summary>
            /// <param name="p_intItemName">项目名称</param>
            /// <returns></returns>
            public PointF m_getCoordinatePoint(int p_intItemName)
            {
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(340f, 40f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(250f, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(45f, 110f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(95f, 110f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(185f, 110f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(230f, 110f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(260f, 110f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(305f, 110f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(360f, 110f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(410f, 110f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(555f, 110f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(605f, 110f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(647f, 110f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(707f, 110f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }
        #endregion
        /// <summary>
        /// 静态构造函数


        /// </summary>
        static clsEMR_PullDeliverRecordPrintTool()
        {
            clsEMR_PullDeliverRecordPrintTool.m_fotHeader = new Font("Simsun", 18,FontStyle.Bold);
            clsEMR_PullDeliverRecordPrintTool.m_fotFooter = new Font("Simsun", 12);
            clsEMR_PullDeliverRecordPrintTool.m_fotContent = new Font("Simsun", 12);
            clsEMR_PullDeliverRecordPrintTool.m_fotSign = new Font("Simsun", 8);
           
        }

        #region 格子的信息


        /// <summary>
        /// 格子的信息


        /// </summary>
        private enum enmRectangleInfoEMR_PullDeliverRecord
        {
            /// <summary>
            /// 格子的顶端


            /// </summary>
            TopY = 130,
            ///<summary>
            /// 格子的左端


            /// </summary>
            LeftX = 40,
            /// <summary>
            /// 格子的右端


            /// </summary>
            RightX = 200,
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

            PrintWidth = 730,
            PrintWidth2 = 600,
            PrintHeight = 920
        }
        #endregion

        #region 打印内容类


        /// <summary>
        /// 打印内容之父类

        /// </summary>
        private abstract class clsEMR_PullDeliverRecordInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            /// <summary>
            /// 获取坐标的类
            /// </summary>
            protected clsPrintPageSettingForRecord m_objPageSetting = new clsPrintPageSettingForRecord();
            /// <summary>
            /// 文字距离左边的边距 
            /// </summary>
            protected int m_intPatientInfoX = 70;
            /// <summary>
            /// 打印信息
            /// </summary>
            protected clsPrintInfo_PullDeliverRecord m_objPrintInfo;
            /// <summary>
            /// 记录内容
            /// </summary>
            protected clsEMR_PullDeliverRecordvalue m_objContent;
            
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
                        this.m_objPrintInfo = (clsPrintInfo_PullDeliverRecord)value;
                        this.m_objContent = this.m_objPrintInfo.m_objRecordContent;
                    }
                }
            }
        }
        /// <summary>
        /// 标题及病人基本信息ok
        /// </summary>
        private class clsEMR_PullDeliverRecordFixInfo : clsEMR_PullDeliverRecordInfo
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
                    p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

                    p_objGrp.DrawString("阴道胎头吸引器助产手术记录", clsEMR_PullDeliverRecordPrintTool.m_fotHeader, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));
                    
                    p_objGrp.DrawString("姓名：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

                    p_objGrp.DrawString("性别：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strSex, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

                    p_objGrp.DrawString("年龄：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strAge, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

                    p_objGrp.DrawString("病区：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

                    p_objGrp.DrawString("床号：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strBedName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

                    p_objGrp.DrawString("住院号：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));

                    p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

                    p_objGrp.DrawRectangle(Pens.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX, (int)enmRectangleInfoEMR_PullDeliverRecord.TopY,(int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth,(int)enmRectangleInfoEMR_PullDeliverRecord.PrintHeight);

                    p_intPosY += 20;
                    p_objGrp.DrawString("入院日期：" + (base.m_objPrintInfo.m_dtmInPatientDate == null ? "" : base.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+20, p_intPosY);
                    p_objGrp.DrawString("手术日期：" + (base.m_objPrintInfo.m_dtmOpenDate == null ? "" : base.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 250, p_intPosY);

                    string tempContent = null;
                    if (base.m_objContent.m_intPREGNANTTIMES >= 0)
                    {
                        tempContent = base.m_objContent.m_intPREGNANTTIMES.ToString();
                    }
                    else
                        tempContent = "";
                    p_objGrp.DrawString("孕：" + tempContent, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 500, p_intPosY);
                    if (base.m_objContent.m_intLAYTIMES >= 0)
                    {
                        tempContent = base.m_objContent.m_intLAYTIMES.ToString();
                    }
                    else
                        tempContent = "";
                    p_objGrp.DrawString("产：" + tempContent, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 580, p_intPosY);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
        private class clsEMR_PullDeliverRecordBeforeOperation : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        p_objGrp.DrawString("入院日期：" + (base.m_objPrintInfo.m_dtmInPatientDate == null ? "" : base.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                        p_objGrp.DrawString("手术日期：" + (base.m_objPrintInfo.m_dtmOpenDate == null ? "" : base.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy年MM月dd日")), p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 250, p_intPosY);

                        string tempContent = null;
                        if (base.m_objContent.m_intPREGNANTTIMES >= 0)
                        {
                            tempContent = base.m_objContent.m_intPREGNANTTIMES.ToString();
                        }
                        else
                            tempContent = "";
                        p_objGrp.DrawString("孕：" + tempContent, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 500, p_intPosY);
                        if (base.m_objContent.m_intLAYTIMES >= 0)
                        {
                            tempContent = base.m_objContent.m_intLAYTIMES.ToString();
                        }
                        else
                            tempContent = "";
                        p_objGrp.DrawString("产：" + tempContent, p_fntNormalText, Brushes.Black, base.m_intPatientInfoX + 580, p_intPosY);
                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                        p_objGrp.DrawString("术前诊断：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+20, p_intPosY);
                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISBEFOREOP) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISBEFOREOPXML))
                        {
                            if (clsEMR_PullDeliverRecordPrintTool.m_blnIsPrintMark)
                            {
                                this.m_objPrintContext.m_mthSetContextWithCorrectBefore(base.m_objContent.m_strDIAGNOSISBEFOREOP,
                                                                                        base.m_objContent.m_strDIAGNOSISBEFOREOPXML,
                                                                                        base.m_dtmFirstPrintTime, true);

                                this.m_mthAddSign2("术前诊断：", this.m_objPrintContext.m_ObjModifyUserArr);
                            }
                            else
                                this.m_objPrintContext.m_mthSetContextWithAllCorrect(base.m_objContent.m_strDIAGNOSISBEFOREOP, base.m_objContent.m_strDIAGNOSISBEFOREOPXML);
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
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth2, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+100, p_intPosY, p_objGrp);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
        private class clsEMR_PullDeliverRecordOperation : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        p_objGrp.DrawString("手术指征：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strOPINDICATION) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strOPINDICATIONXML))
                        {
                            if (clsEMR_PullDeliverRecordPrintTool.m_blnIsPrintMark)
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
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth2, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY, p_objGrp);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
        private class clsEMR_PullDeliverRecordAffterOperation : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        p_objGrp.DrawString("术后诊断：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                        p_intPosY += 20;
                        this.m_blnIsFirstPrint = false;
                        if (!string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISAFTEROP) &&
                            !string.IsNullOrEmpty(base.m_objContent.m_strDIAGNOSISAFTEROPXML))
                        {
                            if (clsEMR_PullDeliverRecordPrintTool.m_blnIsPrintMark)
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
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth2, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY, p_objGrp);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
        private class clsEMR_PullDeliverRecordAnaMode : clsEMR_PullDeliverRecordInfo
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
                            if (sign.controlName.Equals("m_lismazui", StringComparison.OrdinalIgnoreCase))
                            {
                                AnaDoctorName += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR + " ";
                               // break;
                            }
                        }
                        p_objGrp.DrawString("麻醉方式：" + base.m_objContent.m_strANAMODE, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+20, p_intPosY);
                        p_objGrp.DrawString("麻醉师：" + AnaDoctorName, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 400, p_intPosY);
                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
                //this.m_objPrintContext.m_mthRestartPrint();
                this.m_blnIsFirstPrint = true;
                base.m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 术前产检ok
        /// </summary>
        private class clsEMR_PullDeliverRecordCheckBeforeOP : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        p_objGrp.DrawString("术前产检：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+20, p_intPosY);
                        string strAllText = "宫高：" + (base.m_objContent == null ? " " : base.m_objContent.m_strUTERUSHEIGHT_RIGHT) + "cm " +
                                            " 腹围：" + (base.m_objContent == null ? " " : base.m_objContent.m_strABDOMENROUND_RIGHT) + "cm " +
                                            " 先露：" + (base.m_objContent == null ? " " : base.m_objContent.m_strPRESENTATION_RIGHT) +
                                            " 估计胎重：" + (base.m_objContent == null ? " " : base.m_objContent.m_strFETUSWEIGHT_RIGHT) + "g";
                        this.m_objPrintContext.m_mthSetContextWithAllCorrect(strAllText, "<root />");
                        p_objGrp.DrawString("衔接：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 560, p_intPosY);
                        p_objGrp.DrawString("末", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 610, p_intPosY);
                        if (base.m_objContent.m_strLINKUP.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体",14,FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 620, p_intPosY);
                        p_objGrp.DrawString("浅", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 650, p_intPosY);
                        if (base.m_objContent.m_strLINKUP.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 660, p_intPosY);
                        p_objGrp.DrawString("深", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 690, p_intPosY);
                        if (base.m_objContent.m_strLINKUP.Trim().Substring(2, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 700, p_intPosY);
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
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY, p_objGrp);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
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
        private class clsEMR_PullDeliverRecordUnCheckBeforeOP : clsEMR_PullDeliverRecordInfo
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
                        p_objGrp.DrawString("术前阴查：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX+20, p_intPosY);
                        p_objGrp.DrawString("坐骨棘：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY);
                        p_objGrp.DrawString("平伏", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 180, p_intPosY);
                        if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 207, p_intPosY);
                        p_objGrp.DrawString("稍突", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 240, p_intPosY);
                        if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 267, p_intPosY);
                        p_objGrp.DrawString("突出", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 300, p_intPosY);
                        if (base.m_objContent.m_strISCHIALSPINE.Trim().Substring(2, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体",14,FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 327, p_intPosY);


                        p_objGrp.DrawString("尾骨弧度：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 400, p_intPosY);
                        p_objGrp.DrawString("高", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 500, p_intPosY);
                        if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 510, p_intPosY);
                        p_objGrp.DrawString("中", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 560, p_intPosY);
                        if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 570, p_intPosY);
                        p_objGrp.DrawString("低", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 620, p_intPosY);
                        if (base.m_objContent.m_strCOCCYXRADIAN.Trim().Substring(2, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 630, p_intPosY);
                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;

                        p_objGrp.DrawString("坐骨切迹：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY);
                        p_objGrp.DrawString(">2指", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 185, p_intPosY);
                        if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 212, p_intPosY);
                        p_objGrp.DrawString("=2指", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 245, p_intPosY);
                        if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 272, p_intPosY);
                        p_objGrp.DrawString("<2指", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 305, p_intPosY);
                        if (base.m_objContent.m_strISCHIUMNOTCH.Trim().Substring(2, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 332, p_intPosY);
                        p_objGrp.DrawString("DC：" + base.m_objContent.m_strDC_RIGHT + "cm", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 400, p_intPosY);
                        p_objGrp.DrawString("宫口：" + base.m_objContent.m_strUTERUSORA_RIGHT + "cm", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 550, p_intPosY);

                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                        p_objGrp.DrawString("羊水：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY);
                        p_objGrp.DrawString("清", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 170, p_intPosY);
                        if (base.m_objContent.m_strAMNIOCENTESIS.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 180, p_intPosY);
                        p_objGrp.DrawString("Ⅰ", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 202, p_intPosY);
                        if (base.m_objContent.m_strAMNIOCENTESIS.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 208, p_intPosY);
                        p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 243, p_intPosY);
                        if (base.m_objContent.m_strAMNIOCENTESIS.Trim().Substring(2, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 253, p_intPosY);
                        p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 283, p_intPosY);
                        if (base.m_objContent.m_strAMNIOCENTESIS.Trim().Substring(3, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 295, p_intPosY);
                        p_objGrp.DrawString("胎方位：" + base.m_objContent.m_strFETUSPLACE_RIGHT, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 400, p_intPosY);
                        p_objGrp.DrawString("先露高低：" + base.m_objContent.m_strPRESENTATIONHEITHT_RIGHT, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 550, p_intPosY);

                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                        p_objGrp.DrawString("颅骨变形：", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 100, p_intPosY);
                        p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 180, p_intPosY);
                        if (base.m_objContent.m_strSKULL.Trim().Substring(0, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 192, p_intPosY);
                        p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 220, p_intPosY);
                        if (base.m_objContent.m_strSKULL.Trim().Substring(1, 1).Equals("1"))
                            p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 232, p_intPosY);
                        p_objGrp.DrawString("产瘤大小：" + base.m_objContent.m_strCAPUTSUCCEDANEUMSIZE_RIGHT, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 300, p_intPosY);
                        p_objGrp.DrawString("产瘤位置：" + base.m_objContent.m_strCAPUTSUCCEDANEUMPLACE_RIGHT, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 450, p_intPosY);

                        p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*2;
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
        /// 第二页内容ok
        /// </summary>
        private class clsEMR_PullDeliverRecordSecondPageContent : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        this.m_blnIsFirstPrint = false;
                        string strAllContext = "1．产妇取膀胱截石位，会阴常规消毒后铺无菌巾，导尿排空膀胱。\n" +
                            "2．检查吸引器无损坏、漏气，橡皮套无松动，并连接橡皮管于吸引器空心管柄上。\n" +
                            "3．再次阴道检查确定宫口开大" + base.m_objContent.m_strUTERUSORAOPEN_RIGHT + "cm，胎头为顶先露，其先露部达棘下" + base.m_objContent.m_strPRESENTATIONPLACE_RIGHT + "+3，无胎吸禁忌症，胎膜未破者予人工破膜。\n" +
                            "4．2%盐酸利多卡因会阴阻滞麻醉，" + base.m_objContent.m_strLATERALINCISORANA_RIGHT + "后行左侧会阴侧术。\n" +
                            "5．术者将吸引器大端外面涂以消毒石蜡油，左手中、食指向下撑开会阴后壁，右手持吸引器将大端下缘向下压入阴道后壁，然后左手按顺时针方向挑开阴道右侧壁、前壁及左侧壁，使大端完全滑入阴道内并与胎头顶部紧贴。\n" +
                            "6．术者一手扶持吸引器稍向内推压，使吸引器与胎头紧贴，另一手伸入阴道内检查吸引器与胎头衔接处一周，将压入吸引器口径内的阴道或宫颈组织推出，调整吸引器小端的两柄方向与矢状缝一致。\n" +
                            "7．助手将负压吸引器接于橡皮管，逐渐抽吸形成负压达" + base.m_objContent.m_strMINUSPRESS_RIGHT + "mmHg, 术者用血管钳夹紧橡皮结管，取下负压吸引器。\n" +
                            "8．助手保护会阴，术者轻轻试牵吸引器确定无漏气后，于宫缩时循产道轴方向慢慢牵拉吸引器将胎头娩出。胎头娩出后放开夹橡皮管的血管钳，恢复吸引器正压，取下吸引器，继而娩出胎肩和胎体。\n" +
                            "9．上吸引器过程顺利，牵拉" + base.m_objContent.m_strPULLTIME_RIGHT + "分钟，手术操作一次成功，新生儿出生时Apgar评分1评" + base.m_objContent.m_strAPGAR1_RIGHT + "分，2评" + base.m_objContent.m_strAPGAR2_RIGHT + "分，产后检查胎儿有无头皮血肿、损伤。\n" +
                            "10．胎儿娩出" + base.m_objContent.m_strAFTERCHILDBEARING_RIGHT + "分钟后，胎盘胎膜完整自然娩出，检查宫颈、阴道壁无撕裂伤，会阴侧切口无延裂，常规缝合会阴侧切口，切口皮肤皮内连续美容缝合。术毕，肛查直肠壁光滑，无缝线通过，予米索前列醇400ug纳肛预防产后出血。手术过程顺利，产妇配合，术中出血" + base.m_objContent.m_strBLEEDINGINOP_RIGHT + "ml，宫缩好，术毕，在产房观察2小时，产妇无特殊，车送安返回房。";
                        this.m_objPrintContext.m_mthSetContextWithAllCorrect(strAllContext, "<root />");
                    }

                    //p_objGrp.DrawString("1．产妇取膀胱截石位，会阴常规消毒后铺无菌巾，导尿排空膀胱。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                    //p_objGrp.DrawString("2．检查吸引器无损坏、漏气，橡皮套无松动，并连接橡皮管于吸引器空心管柄上。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                    //p_objGrp.DrawString("3．再次阴道检查确定宫口开大"+base.m_objContent.m_strUTERUSORAOPEN_RIGHT+"cm，胎头为顶先露，其先露部达棘下"+base.m_objContent.m_strPRESENTATIONPLACE_RIGHT+"+3，无胎吸禁忌症，\n   胎膜未破者予人工破膜。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*2;
                    //p_objGrp.DrawString("4．2%盐酸利多卡因会阴阻滞麻醉，"+base.m_objContent.m_strLATERALINCISORANA_RIGHT+"后行左侧会阴侧术。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                    //p_objGrp.DrawString("5．术者将吸引器大端外面涂以消毒石蜡油，左手中、食指向下撑开会阴后壁，右手持吸引器将\n   大端下缘向下压入阴道后壁，然后左手按顺时针方向挑开阴道右侧壁、前壁及左侧壁，使大\n   端完全滑入阴道内并与胎头顶部紧贴。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*3;
                    //p_objGrp.DrawString("6．术者一手扶持吸引器稍向内推压，使吸引器与胎头紧贴，另一手伸入阴道内检查吸引器与胎\n   头衔接处一周，将压入吸引器口径内的阴道或宫颈组织推出，调整吸引器小端的两柄方向与\n   矢状缝一致。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*3;
                    //p_objGrp.DrawString("7．助手将负压吸引器接于橡皮管，逐渐抽吸形成负压达" + base.m_objContent.m_strMINUSPRESS_RIGHT+ "mmHg, 术者用血管钳夹紧橡皮结管，\n   取下负压吸引器。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*2;
                    //p_objGrp.DrawString("8．助手保护会阴，术者轻轻试牵吸引器确定无漏气后，于宫缩时循产道轴方向慢慢牵拉吸引器\n   将胎头娩出。胎头娩出后放开夹橡皮管的血管钳，恢复吸引器正压，取下吸引器，继而娩出\n   胎肩和胎体。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*3;
                    //p_objGrp.DrawString("9．上吸引器过程顺利，牵拉" + base.m_objContent.m_strPULLTIME_RIGHT + "分钟，手术操作一次成功，新生儿出生时Apgar评分1评" + base.m_objContent.m_strAPGAR1_RIGHT + "分，\n   2评" + base.m_objContent.m_strAPGAR2_RIGHT + "分，产后检查胎儿有无头皮血肿、损伤。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*2;
                    //p_objGrp.DrawString("10．胎儿娩出" + base.m_objContent.m_strAFTERCHILDBEARING_RIGHT + "分钟后，胎盘胎膜完整自然娩出，检查宫颈、阴道壁无撕裂伤，会阴侧切口无\n   延裂，常规缝合会阴侧切口，切口皮肤皮内连续美容缝合。术毕，肛查直肠壁光滑，无缝\n   线通过，予米索前列醇400ug纳肛预防产后出血。手术过程顺利，产妇配合，术中出血" + base.m_objContent.m_strBLEEDINGINOP_RIGHT + "ml，\n   宫缩好，术毕，在产房观察2小时，产妇无特殊，车送安返回房。", p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY);
                    //p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep*5;
                    //this.m_blnIsFirstPrint = false;
                }

                else
                {
                    base.m_blnHaveMoreLine = false;
                    return;
                }
                if (this.m_objPrintContext.m_BlnHaveNextLine())
                {
                    this.m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth-20, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 20, p_intPosY, p_objGrp);
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                }
                else
                {
                    base.m_blnHaveMoreLine = false;
                    p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep * 2;
                }
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
        /// 手术者ok
        /// </summary>
        private class clsEMR_PullDeliverRecordOperator : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                            if (sign.controlName.Equals("m_lsvAction", StringComparison.OrdinalIgnoreCase))
                            {
                                operatorName += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR + " ";
                                //  break;
                            }
                        }

                        p_objGrp.DrawString("手术者：" + operatorName, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 300, p_intPosY);
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
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        /// 助手ok
        /// </summary>
        private class clsEMR_PullDeliverRecordAssistant : clsEMR_PullDeliverRecordInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
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
                        string Assistant = "";
                        foreach (clsEmrSigns_VO sign in base.m_objContent.objSignerArr)
                        {
                            if (sign.controlName.Equals("m_lsvAssistant", StringComparison.OrdinalIgnoreCase))
                            {
                                Assistant += sign.objEmployee.m_strLASTNAME_VCHR + " " + sign.objEmployee.m_strTECHNICALRANK_CHR +" ";
                               // break;
                            }
                        }
                        p_objGrp.DrawString("助手：" + Assistant, p_fntNormalText, Brushes.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX + 300, p_intPosY);
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
                this.m_objPrintContext.m_mthRestartPrint();
                base.m_blnHaveMoreLine = true;
                this.m_blnIsFirstPrint = true;
            }
        }
        #endregion
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
            this.m_objPrintInfo = new clsPrintInfo_PullDeliverRecord();
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

            clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_PullDeliverRecord);

            if (!string.IsNullOrEmpty(this.m_objPrintInfo.m_strInPatentID) && this.m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue)
            {
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                //从数据库读取打印所需数据
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(this.m_objPrintInfo.m_strInPatentID, this.m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), this.m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);

                if (lngRes <= 0)
                    return;
                this.m_objPrintInfo.m_objRecordContent = objContent as clsEMR_PullDeliverRecordvalue;
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
        private void m_mthSetPrintContent(clsEMR_PullDeliverRecordvalue p_objContent, DateTime p_dtmFirstPrintDate)
        {
            this.m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext
                (
                    new com.digitalwave.Utility.Controls.clsPrintLineBase[]
                    {
                       //new clsEMR_PullDeliverRecordFixInfo(),
                       new clsEMR_PullDeliverRecordBeforeOperation(),
                       new clsEMR_PullDeliverRecordOperation(),
                       new clsEMR_PullDeliverRecordAffterOperation(),
                       new clsEMR_PullDeliverRecordAnaMode(),
                       new clsEMR_PullDeliverRecordCheckBeforeOP(),
                       new clsEMR_PullDeliverRecordUnCheckBeforeOP(),
                       new clsEMR_PullDeliverRecordSecondPageContent(),
                        new clsEMR_PullDeliverRecordOperator(),
                       new clsEMR_PullDeliverRecordAssistant()    
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
                clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_PullDeliverRecord);
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
            m_mthPrintTitleInfo(ref this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_PullDeliverRecordPrintTool.m_fotContent);//每页都打印的框架
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
                this.m_objPrintLineContext.m_mthPrintNextLine(ref this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_PullDeliverRecordPrintTool.m_fotContent);
            }
            //打印签名
            this.m_intYPos += 20;
            while (this.m_objPrintLineContext.m_BlnHaveMoreSign)
            {
                this.m_objPrintLineContext.m_mthPrintNextSign(70 + 10, this.m_intYPos, p_objPrintPageArg.Graphics, clsEMR_PullDeliverRecordPrintTool.m_fotSign);
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
            e.Graphics.DrawString("第      页", clsEMR_PullDeliverRecordPrintTool.m_fotFooter, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 70);
            e.Graphics.DrawString(this.m_intCurrentPage.ToString(), clsEMR_PullDeliverRecordPrintTool.m_fotFooter, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 70);
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

        #region 打印表头
        private   void m_mthPrintTitleInfo(ref int p_intPosY, Graphics p_objGrp, Font p_fntNormalText)
        {
            clsPrintPageSettingForRecord m_objPageSetting = new clsPrintPageSettingForRecord();
            if (m_objPrintInfo != null)
            {
                p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

                p_objGrp.DrawString("阴道胎头吸引器助产手术记录", clsEMR_PullDeliverRecordPrintTool.m_fotHeader, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

                p_objGrp.DrawString("姓名：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strPatientName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

                p_objGrp.DrawString("性别：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strSex, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

                p_objGrp.DrawString("年龄：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strAge, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

                p_objGrp.DrawString("病区：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strAreaName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

                p_objGrp.DrawString("床号：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strBedName, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

                p_objGrp.DrawString("住院号：", clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));

                p_objGrp.DrawString(m_objPrintInfo.m_strHISInPatientID, clsEMR_PullDeliverRecordPrintTool.m_fotContent, Brushes.Black, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

                p_objGrp.DrawRectangle(Pens.Black, (int)enmRectangleInfoEMR_PullDeliverRecord.LeftX, (int)enmRectangleInfoEMR_PullDeliverRecord.TopY, (int)enmRectangleInfoEMR_PullDeliverRecord.PrintWidth, (int)enmRectangleInfoEMR_PullDeliverRecord.PrintHeight);
                
                p_intPosY += (int)enmRectangleInfoEMR_PullDeliverRecord.SmallRowStep;
                
            }
        }
        #endregion 

        #region IDisposable 成员

        public void Dispose()
        {
            GC.Collect();//强制执行垃圾回收
        }

        #endregion
    }
}
