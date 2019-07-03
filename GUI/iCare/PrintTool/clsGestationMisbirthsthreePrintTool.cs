using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 中期妊娠三合一打印工具类
    /// </summary>
    public class clsGestationMisbirthsthreePrintTool : infPrintRecord
    {
        #region
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
        private clsBaseCaseHistoryDomain m_objRecordsDomain;
        private clsGestationMisbirthsthreeDomain m_objInRoomDomain;
        private string m_strRegisterID = string.Empty;

        public clsGestationMisbirthsthreePrintTool()
        {
            m_objInRoomDomain = new clsGestationMisbirthsthreeDomain();
        }

        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            m_objPrintInfo = new clsPrintInfo_InPatientCaseHistory();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrLastName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? p_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;
            clsGestationMisbirthsthreeVO[] objRecordArr = null;

            if (m_objPrintInfo == null)
            {
                MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }

            if (m_objPrintInfo.m_strInPatentID != "")
            {
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.GestationMisbirthsthreeRec_CS);
                long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.MinValue, out m_objPrintInfo.m_objContent, out m_objPrintInfo.m_objPicValueArr, out m_objPrintInfo.m_dtmFirstPrintDate, out m_objPrintInfo.m_blnIsFirstPrint);

                if (m_objPrintInfo.m_objContent != null)
                {
                    lngRes = m_objInRoomDomain.m_lngGetAllModifiedCircsRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out objRecordArr);
                }
            }
            //设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
            m_mthSetPrintContent((clsGestationMisbirthsthreeRelationVO)m_objPrintInfo.m_objContent, objRecordArr, m_objPrintInfo.m_dtmFirstPrintDate);
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_InPatientCaseHistory")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)p_objPrintContent;

            m_mthSetPrintContent((clsGestationMisbirthsthreeRelationVO)m_objPrintInfo.m_objContent, null, m_objPrintInfo.m_dtmFirstPrintDate);
        }

        /// <summary>
        /// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {
            if (m_blnIsFromDataSource)
            {
                if (m_objPrintInfo == null)
                {
                    MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (m_objPrintInfo.m_objContent == null)
                return null;
            else
                return m_objPrintInfo;
        }

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化

            m_fotTitleFont = new Font("SimSun", 16, FontStyle.Bold);
            m_fotHeaderFont = new Font("SimSun", 18, FontStyle.Bold);
            m_fotItemHead = new Font("", 13, FontStyle.Bold);
            m_fotSmallFont = new Font("SimSun", 12);
            m_GridPen = new Pen(Color.Black, 2);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();


            #endregion 有关打印初始化
        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotSmallFont.Dispose();
            m_GridPen.Dispose();
            m_slbBrush.Dispose();
        }

        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "")
                return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrint)
            {
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmFirstPrintDate);
            }
        }

        #region 有关打印的声明

        /// <summary>
        /// 打印一行的内容
        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;

        /// <summary>
        /// 打印边框的左边距
        /// </summary>
        private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
        private int m_intCurrentPage = 1;
        /// <summary>
        /// 标题的字体(20 bold)
        /// </summary>
        private Font m_fotTitleFont;
        /// <summary>
        /// 表头的字体(14 )
        /// </summary>
        private Font m_fotHeaderFont;
        /// <summary>
        /// 大项目的标题，如体格检查
        /// </summary>
        public static Font m_fotItemHead;
        /// <summary>
        /// 表内容的字体(11)
        /// </summary>
        private Font m_fotSmallFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 当前打印位置（Y）
        /// </summary>
        private int m_intYPos = 155;//= (int)enmRectangleInfo.TopY+5;

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {

            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 150,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = clsPrintPosition.c_intLeftX,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = clsPrintPosition.c_intRightX,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 25,
            SmallRowStep = 25,
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

            BottomY = 1025

        }

        #endregion
        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            m_mthPrintTitleInfo(p_objPrintPageArg);

            Font fntNormal = new Font("", 10);

            while (m_objPrintLineContext.m_BlnHaveMoreLine)
            {
                //还有数据打印
                m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos, p_objPrintPageArg.Graphics, fntNormal);

                if (m_intYPos > p_objPrintPageArg.PageBounds.Height - 270
                    && m_objPrintLineContext.m_BlnHaveMoreLine)
                {
                    //还有数据打印，但需要换页

                    m_mthPrintFoot(p_objPrintPageArg);

                    p_objPrintPageArg.HasMorePages = true;

                    m_intYPos = 155;

                    m_intCurrentPage++;

                    return;
                }
            }

            m_intYPos += 30;
            Font fntSign = new Font("", 6);
            while (m_objPrintLineContext.m_BlnHaveMoreSign)
            {
                m_objPrintLineContext.m_mthPrintNextSign(30 + 10, m_intYPos, p_objPrintPageArg.Graphics, fntSign);

                m_intYPos += (int)enmRectangleInfo.RowStep - 10;
            }

            //全部打完			

            m_mthPrintFoot(p_objPrintPageArg);
        }
        #endregion

        #region 设置打印内容
        // 设置打印内容。
        private void m_mthSetPrintContent(clsGestationMisbirthsthreeRelationVO p_objContent, clsGestationMisbirthsthreeVO[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		new  clsPrintChildBearing(),
																		new clsPrintCircsRecordHeader(),
																		new clsPrintCircsRecordContent(),
                    													new clsPrintGenitalia(),
                                                                        new clsPrintDetail(),
                                                                        new clsPrintDel(),
                                                                        new clsPrint9()
																	   });
            m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();

            object[] objData = new Object[3];
            objData[0] = m_objChangePrintTextColor(p_objContent);
            objData[1] = m_objPrintInfo;
            objData[2] = p_objCircsContentArr;

            //设置打印信息，就是Set Value进去
            m_objPrintLineContext.m_ObjPrintLineInfo = objData;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
            m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
        }
        #endregion

        #region
        private clsGestationMisbirthsthreeRelationVO m_objChangePrintTextColor(clsGestationMisbirthsthreeRelationVO p_objclsInPatientCase)
        {
            if (p_objclsInPatientCase == null)
                return null;
            //把白色变为黑色
            clsXML_DataGrid objclsXML_DataGrid = new clsXML_DataGrid();
            //p_objclsInPatientCase.m_strOTHERCHECKXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);
            //p_objclsInPatientCase.m_strOTHERCHECKXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);

            //p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML);
            //p_objclsInPatientCase.m_strDEALWITHXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientCase.m_strDEALWITHXML);

            return p_objclsInPatientCase;
        }

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
            Bed_Title,
            Bed,
            BirthTime_Title,
            Birth,

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

        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;

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
                float fltOffsetX = 20;//X的偏移量
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(340f - fltOffsetX, 40f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(340f - fltOffsetX, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(60f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(110f - fltOffsetX, 110f);
                        break;

                    case (int)enmItemDefination.BirthTime_Title:
                        m_fReturnPoint = new PointF(200f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Birth:
                        m_fReturnPoint = new PointF(250f - fltOffsetX, 110f);
                        break;

                    case (int)enmItemDefination.Bed_Title:
                        m_fReturnPoint = new PointF(310f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Bed:
                        m_fReturnPoint = new PointF(360f - fltOffsetX, 110f);
                        break;


                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(410f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(480f - fltOffsetX, 110f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRectangleInfoInPatientCaseInfo
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

            PrintWidth = 630,
            PrintWidth2 = 710,

        }

        #endregion

        #region PrintClasses
        private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            protected clsGestationMisbirthsthreeRelationVO m_objContent;
            protected Pen m_GridPen = new Pen(Color.Black);
            /// <summary>
            /// 文字距离左边的边距
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
            protected int m_intPatientInfoX = 70;
            protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
            protected clsGestationMisbirthsthreeVO[] m_objPrintCircsArr;

            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return base.m_blnHaveMoreLine;
                }
                set
                {
                    if (value == null) return;
                    object[] objData = (object[])value;
                    m_objContent = (clsGestationMisbirthsthreeRelationVO)objData[0];
                    m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)objData[1];
                    m_objPrintCircsArr = (clsGestationMisbirthsthreeVO[])objData[2];
                }
            }
        }
        #region 引产记录
        /// <summary>
        /// 引产记录
        /// </summary>
        private class clsPrintChildBearing : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Near;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY -= 20;
                    p_objGrp.DrawString("手术日期：" + Convert.ToDateTime(m_objContent.m_strOPERATIONDATE).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("术前阴道准备：" + m_objContent.m_strOPERATIONREADY, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_objGrp.DrawString("引产方法：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 400, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strLABORINDUCTION == "1" || m_objContent.m_strLABORINDUCTION == "12")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 393, p_intPosY - 4);
                    p_objGrp.DrawString("药物", p_fntNormalText, Brushes.Black, m_intRecBaseX + 416, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 460, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strLABORINDUCTION == "2" || m_objContent.m_strLABORINDUCTION == "12")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 453, p_intPosY - 4);
                    p_objGrp.DrawString("水囊", p_fntNormalText, Brushes.Black, m_intRecBaseX + 476, p_intPosY);
                    p_intPosY += 20;
                    if (m_objContent.m_strLABORINDUCTION == "12")
                    {
                        p_objGrp.DrawString("穿刺引产手术步骤：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString("药物名称:" + m_objContent.m_strMEDICNAME, p_fntNormalText, Brushes.Black, m_intRecBaseX + 140, p_intPosY);
                        p_objGrp.DrawString("剂量 " + m_objContent.m_strMEDICDOSE + "mg", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                        p_objGrp.DrawString("稀释液及量 " + m_objContent.m_strDILUENTDOSE + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        p_objGrp.DrawString("用药批号 " + m_objContent.m_strMEDICLOT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("用药途径：腹部羊膜空穿刺", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("腹部穿刺：部位" + m_objContent.m_strABDOMINALPUNCTURE, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString(m_objContent.m_strNONEEDLE + " 号套针", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        p_objGrp.DrawString("穿刺 " + m_objContent.m_strPUNCTURESIZE + "次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                        p_objGrp.DrawString("抽出羊水 " + m_objContent.m_strAMNIOTIC + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                        p_objGrp.DrawString("色泽 " + m_objContent.m_strAMNIOTICCOLOR, p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("其它：" + m_objContent.m_strAMNIOTICOTHER, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("放置水囊手术步骤：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString("经阴道宫颈 " + m_objContent.m_strVAGINALCERVIX + "号导管", p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                        p_objGrp.DrawString("插入 " + m_objContent.m_strINSERTIONDEPTH + "cm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 320, p_intPosY);
                        p_objGrp.DrawString("注入生理盐水+(美兰) " + m_objContent.m_strMEILAN + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                        p_objGrp.DrawString("用药批号 " + m_objContent.m_strMEDICLOT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 580, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("阴道置纱布 " + m_objContent.m_strVAGINALGAUZE + "块", p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                        p_objGrp.DrawString("取水囊时间 " + Convert.ToDateTime(m_objContent.m_strCYSTICTIME).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);
                        p_objGrp.DrawString("取出情况 " + m_objContent.m_strOUTOF + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                        p_intPosY += 20;
                    }
                    if (m_objContent.m_strLABORINDUCTION == "1")
                    {
                        p_objGrp.DrawString("穿刺引产手术步骤：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString("药物名称:" + m_objContent.m_strMEDICNAME, p_fntNormalText, Brushes.Black, m_intRecBaseX + 140, p_intPosY);
                        p_objGrp.DrawString("剂量 " + m_objContent.m_strMEDICDOSE + "mg", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                        p_objGrp.DrawString("稀释液及量 " + m_objContent.m_strDILUENTDOSE + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 420, p_intPosY);
                        p_objGrp.DrawString("用药批号 " + m_objContent.m_strMEDICLOT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("用药途径：腹部羊膜空穿刺", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("腹部穿刺：部位" + m_objContent.m_strABDOMINALPUNCTURE, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString(m_objContent.m_strNONEEDLE + " 号套针", p_fntNormalText, Brushes.Black, m_intRecBaseX + 150, p_intPosY);
                        p_objGrp.DrawString("穿刺 " + m_objContent.m_strPUNCTURESIZE + "次", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                        p_objGrp.DrawString("抽出羊水 " + m_objContent.m_strAMNIOTIC + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                        p_objGrp.DrawString("色泽 " + m_objContent.m_strAMNIOTICCOLOR, p_fntNormalText, Brushes.Black, m_intRecBaseX + 550, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("其它：" + m_objContent.m_strAMNIOTICOTHER, p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_intPosY += 20;
                    }
                    if (m_objContent.m_strLABORINDUCTION == "2")
                    {
                        p_objGrp.DrawString("放置水囊手术步骤：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                        p_objGrp.DrawString("经阴道宫颈 " + m_objContent.m_strVAGINALCERVIX + "号导管", p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                        p_objGrp.DrawString("插入 " + m_objContent.m_strINSERTIONDEPTH + "cm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 320, p_intPosY);
                        p_objGrp.DrawString("注入生理盐水+(美兰) " + m_objContent.m_strMEILAN + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                        p_objGrp.DrawString("用药批号 " + m_objContent.m_strMEDICLOT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 580, p_intPosY);
                        p_intPosY += 20;
                        p_objGrp.DrawString("阴道置纱布 " + m_objContent.m_strVAGINALGAUZE + "块", p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                        p_objGrp.DrawString("取水囊时间 " + Convert.ToDateTime(m_objContent.m_strCYSTICTIME).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 260, p_intPosY);
                        p_objGrp.DrawString("取出情况 " + m_objContent.m_strOUTOF + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 560, p_intPosY);
                        p_intPosY += 20;
                    }
                    p_objGrp.DrawString("手术经过:", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 80, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strAFTERSURGERY == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 73, p_intPosY - 4);
                    p_objGrp.DrawString("顺利", p_fntNormalText, Brushes.Black, m_intRecBaseX + 96, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 130, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strAFTERSURGERY == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 123, p_intPosY - 4);
                    p_objGrp.DrawString("较困难", p_fntNormalText, Brushes.Black, m_intRecBaseX + 146, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 200, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strAFTERSURGERY == "3")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 193, p_intPosY - 4);
                    p_objGrp.DrawString("困难", p_fntNormalText, Brushes.Black, m_intRecBaseX + 216, p_intPosY);
                    p_objGrp.DrawString("手术出血 " + m_objContent.m_strSURGICALBLEEDING + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX + 280, p_intPosY);
                    p_intPosY += 20;
                    //string strTempXml = m_strGetXml(m_objContent.m_strNOTES_XML);
                    ////com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, new Font("", 10));
                    //m_objPrintContext.m_mthSetContextWithAllCorrect(m_objContent.m_strNOTES, m_objContent.m_strNOTES_XML);
                    //if (m_objContent.m_strNOTES.Length != 0)
                    //{
                    //    m_objPrintContext.m_mthPrintLine(700, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    //}
                    m_mthDrawMultiString(p_fntNormalText, p_fntNormalText, 0, m_intRecBaseX, p_intPosY, m_intRecBaseX + 700, p_intPosY, 0, 0, "备注：" + m_objContent.m_strNOTES_RIGHT, p_objGrp);
                    #region 签名
                    p_intPosY += 60;
                    clsEmrSigns_VO[] m_signVO = null;
                    string strSign1 = string.Empty;
                    string strSign = string.Empty;
                    m_signVO = m_objContent.objSignerArr;
                    if (m_signVO != null)
                    {
                        for (int intI = 0; intI < m_signVO.Length; intI++)
                        {
                            if (m_signVO[intI].controlName == "lsvSign1")
                            {
                                strSign1 += m_signVO[intI].objEmployee.m_strGetTechnicalRankAndName;//m_signVO[intI].objEmployee.m_strLASTNAME_VCHR + 
                                strSign1 += " ";
                            }
                            if (m_signVO[intI].controlName == "lsvSign")
                            {
                                strSign += m_signVO[intI].objEmployee.m_strGetTechnicalRankAndName;//m_signVO[intI].objEmployee.m_strLASTNAME_VCHR + 
                                strSign += " ";
                            }
                        }
                    }
                    p_objGrp.DrawString("手术者：" + strSign1, p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, p_intPosY);
                    p_objGrp.DrawString("病史记录者：" + strSign, p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, 135);
                    #endregion
                    m_blnIsFirstPrint = false;
                }
                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

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
            #region
            private string m_strGetXml(object obj)
            {
                com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;

                string m_strstrTempxml = "";
                if (obj == null)
                {
                    m_strstrTempxml = "<root />";
                }
                else
                {
                    if (obj.GetType().Name == "clsDSTRichTextBoxValue")
                    {
                        objclsDSTRichTextBoxValue = (com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue)obj;
                        m_strstrTempxml = objclsDSTRichTextBoxValue.m_strDSTXml != null ? objclsDSTRichTextBoxValue.m_strDSTXml : "<root />";
                    }
                    else
                    {
                        m_strstrTempxml = "<root />";
                    }
                }
                return m_strstrTempxml;
            }
            #endregion
            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }
        #endregion

        #region 画新生儿情况记录标题及表格标头
        /// <summary>
        /// 画新生儿情况记录标题及表格标头
        /// </summary>
        private class clsPrintCircsRecordHeader : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 8));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fotTitleFont = new Font("SimSun", 16, FontStyle.Bold);
            private Font m_fotContentFont = new Font("SimSun", 10);
            private PointF m_fReturnPoint;
            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Center;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objPrintCircsArr == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 60;
                    m_fReturnPoint = new PointF(260f, p_intPosY);
                    p_objGrp.DrawString("中期妊娠引产后观察记录", new Font("宋体", 12, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                    //p_objGrp.DrawLine(m_GridPen, m_intRecBaseX + 250, p_intPosY + 15, m_intRecBaseX + 200 + 250, p_intPosY + 15);//0 
                    p_intPosY += 25;

                    p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY, m_intRecBaseX + 645, p_intPosY);

                    #region 画表格标头
                    int intPosX = m_intRecBaseX - 10;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//0 
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 60, p_intPosY, 0, 0, "日期", p_objGrp);
                    intPosX += 60;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//1					
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "时间", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//2				
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "血压", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//4		
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "体温", p_objGrp); ;
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//5		
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "脉搏", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//7		
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "宫缩", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//11		
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "出血", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//13		
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "破水", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//15
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 50, p_intPosY, 0, 0, "胎心", p_objGrp);
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//16
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 75, p_intPosY, 0, 0, "宫口大小", p_objGrp);
                    intPosX += 75;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//18
                    m_mthDrawMultiString(this.m_fotContentFont, this.m_fotContentFont, 0, intPosX, p_intPosY, intPosX + 120, p_intPosY, 0, 0, "签名", p_objGrp);
                    intPosX += 120;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 15);//19

                    //p_objGrp.DrawLine(m_GridPen,m_intRecBaseX+70,p_intPosY+17,intPosX-181,p_intPosY+17);
                    p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY + 15, m_intRecBaseX + 645, p_intPosY + 15);
                    #endregion

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

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

        #region 新生儿情况记录表格内容
        /// <summary>
        /// 新生儿情况记录表格内容
        /// </summary>
        private class clsPrintCircsRecordContent : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fotContentFont = new Font("SimSun", 9);
            private Font m_fotTimetFont = new Font("SimSun", 8);

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objPrintCircsArr == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                p_intPosY += 15;

                if (m_blnIsFirstPrint)
                {
                    for (int i = 0; i < m_objPrintCircsArr.Length; i++)
                    {
                        int intThisLows = 0;
                        string[] strArrTemp;
                        string[] strXMLArrTemp;
                        p_intPosY += 2;
                        #region 打印表格内容
                        int intTempX = m_intRecBaseX - 9;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("yyyy.MM.dd"), m_fotTimetFont, Brushes.Black, intTempX, p_intPosY);
                        intTempX += 60;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("hh:mm"), m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        intTempX += 50;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strBLOODPRESSURE_VCHR, m_objPrintCircsArr[i].m_strBLOODPRESSURE_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBLOODPRESSURE_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strTEMPERATURE_VCHR, m_objPrintCircsArr[i].m_strTEMPERATURE_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strTEMPERATURE_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strPULSE_VCHR, m_objPrintCircsArr[i].m_strPULSE_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strPULSE_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strCONTRACTIONS_VCHR, m_objPrintCircsArr[i].m_strCONTRACTIONS_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strCONTRACTIONS_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strBLEEDING_VCHR, m_objPrintCircsArr[i].m_strBLEEDING_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBLEEDING_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strBROKENWATER_VCHR, m_objPrintCircsArr[i].m_strBROKENWATER_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBROKENWATER_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strFETAL_VCHR, m_objPrintCircsArr[i].m_strFETAL_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strFETAL_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strMIYAGUCHISIZE_VCHR, m_objPrintCircsArr[i].m_strMIYAGUCHISIZE_XML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strMIYAGUCHISIZE_VCHR, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 50, 120));
                        intTempX += 75;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        //ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].m_strSignUserName, "", 4, out strArrTemp, out strXMLArrTemp);
                        int intSignLength = m_objPrintCircsArr[i].m_strSignUserName.Length / 5 + 1;
                        if (intThisLows < intSignLength)
                            intThisLows = m_objPrintCircsArr[i].m_strSignUserName.Length / 5 + 1;
                        //if (intThisLows < strArrTemp.Length)
                        //    intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSignUserName, new Font("Simsun", 8.0f), Brushes.Black, new RectangleF(intTempX, p_intPosY, 120, 100));
                        #endregion

                        #region 打印该行表格框架
                        int intPosX = m_intRecBaseX - 10;
                        int intThisLowHeight = (intThisLows * 15) / 2;
                        p_intPosY -= 2;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 60;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 75;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 120;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);

                        p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY + intThisLowHeight, m_intRecBaseX + 645, p_intPosY + intThisLowHeight);

                        p_intPosY += intThisLowHeight;
                        #endregion
                    }
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

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

        #region 引产分娩记录
        /// <summary>
        /// 引产分娩记录
        /// </summary>
        private class clsPrintGenitalia : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Near;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("中期妊娠引产分娩记录", new Font("宋体", 12, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 260, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("宫缩开始时间：" + Convert.ToDateTime(m_objContent.m_strCONTRACTIONSTIME).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_objGrp.DrawString("破水时间：" + Convert.ToDateTime(m_objContent.m_strBROKENWATERTIME).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("胎儿娩出时间：" + Convert.ToDateTime(m_objContent.m_strFETALDITIME).ToString("yyyy年MM月dd日 hh时mm分"), p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_objGrp.DrawString("胎儿娩出方式：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 410, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETALDIMETHOD == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 403, p_intPosY - 4);
                    p_objGrp.DrawString("自然", p_fntNormalText, Brushes.Black, m_intRecBaseX + 426, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 480, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETALDIMETHOD == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 473, p_intPosY - 4);
                    p_objGrp.DrawString("人工", p_fntNormalText, Brushes.Black, m_intRecBaseX + 496, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("胎儿：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 40, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETAL == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 33, p_intPosY - 4);
                    p_objGrp.DrawString("新鲜", p_fntNormalText, Brushes.Black, m_intRecBaseX + 56, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 100, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETAL == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 93, p_intPosY - 4);
                    p_objGrp.DrawString("浸软", p_fntNormalText, Brushes.Black, m_intRecBaseX + 116, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 160, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETAL == "3")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 153, p_intPosY - 4);
                    p_objGrp.DrawString("坏死", p_fntNormalText, Brushes.Black, m_intRecBaseX + 176, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 230, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strFETAL == "4")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 223, p_intPosY - 4);
                    p_objGrp.DrawString("其它", p_fntNormalText, Brushes.Black, m_intRecBaseX + 246, p_intPosY);
                    p_objGrp.DrawString("身长：" + m_objContent.m_strFETALLENGTH + "cm", p_fntNormalText, Brushes.Black, m_intRecBaseX + 320, p_intPosY);
                    p_objGrp.DrawString("体重：" + m_objContent.m_strFETALWEIGHT + "g", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("胎盘：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 40, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strPLACENTA == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 33, p_intPosY - 4);
                    p_objGrp.DrawString("完整", p_fntNormalText, Brushes.Black, m_intRecBaseX + 56, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 100, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strPLACENTA == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 93, p_intPosY - 4);
                    p_objGrp.DrawString("不完整,", p_fntNormalText, Brushes.Black, m_intRecBaseX + 116, p_intPosY);
                    p_objGrp.DrawString("清宫：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 240, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strPALACE == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 233, p_intPosY - 4);
                    p_objGrp.DrawString("未", p_fntNormalText, Brushes.Black, m_intRecBaseX + 256, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 290, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strPALACE == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 283, p_intPosY - 4);
                    p_objGrp.DrawString("是", p_fntNormalText, Brushes.Black, m_intRecBaseX + 306, p_intPosY);
                    p_objGrp.DrawString("原因：" + m_objContent.m_strPALACECONTENT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 330, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("产时产后出血量(估计)：" + m_objContent.m_strPOSTPARTUMBLEEDING + "ml", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_objGrp.DrawString("宫缩剂：" + m_objContent.m_strCONTRACTIONSAGENT, p_fntNormalText, Brushes.Black, m_intRecBaseX + 240, p_intPosY);
                    p_objGrp.DrawString("剂量：" + m_objContent.m_strDOSE, p_fntNormalText, Brushes.Black, m_intRecBaseX + 400, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("产后软产道检查：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 130, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strBIRTHCHECK == "1")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 123, p_intPosY - 4);
                    p_objGrp.DrawString("正常", p_fntNormalText, Brushes.Black, m_intRecBaseX + 146, p_intPosY);

                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intRecBaseX + 200, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    if (m_objContent.m_strBIRTHCHECK == "2")
                        p_objGrp.DrawString("√", new Font("宋体", 14, FontStyle.Bold), Brushes.Black, m_intRecBaseX + 193, p_intPosY - 4);
                    p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, m_intRecBaseX + 216, p_intPosY);
                    //m_mthDrawMultiString(p_fntNormalText, p_fntNormalText, 0, m_intRecBaseX + 310, p_intPosY, m_intRecBaseX + 700, p_intPosY, 0, 0, m_objContent.m_strSHEXIANG, p_objGrp);
                    //p_intPosY += 40;
                    //p_objGrp.DrawString("处理：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 216, p_intPosY);
                    //m_mthDrawMultiString(p_fntNormalText, p_fntNormalText, 0, m_intRecBaseX + 260, p_intPosY, m_intRecBaseX + 700, p_intPosY, 0, 0, m_objContent.m_strTREATMENT, p_objGrp);
                    p_intPosY += 20;
                    #region 签名
                    //clsEmrSigns_VO[] m_signVO = null;
                    //string strSign1 = string.Empty;
                    //m_signVO = m_objContent.objSignerArr;
                    //if (m_signVO != null)
                    //{
                    //    for (int intI = 0; intI < m_signVO.Length; intI++)
                    //    {
                    //        if (m_signVO[intI].controlName == "lsvSign2")
                    //        {
                    //            strSign1 += m_signVO[intI].objEmployee.m_strLASTNAME_VCHR;
                    //            strSign1 += " ";
                    //        }
                    //    }
                    //}
                    //p_objGrp.DrawString("处理者：" + strSign1, p_fntNormalText, Brushes.Black, m_intRecBaseX + 480, p_intPosY);
                    #endregion

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

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

        #region 产后软产道检查>>（详述）
        /// <summary>
        /// 产后软产道检查>>（详述）
        /// </summary>
        /// 
        private class clsPrintDetail : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private clsInpatMedRec_Item objItemContent = null;

            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Near;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (m_hasItems != null)
                //    if (m_hasItems.Contains("产后软产道检查>>（详述）"))
                //        objItemContent = m_hasItems["产后软产道检查>>（详述）"] as clsInpatMedRec_Item;
                if (m_objContent == null || m_objContent.m_strSHEXIANG == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {

                    p_objGrp.DrawString("产后软产道检查（详述）：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_intPosY += 20;
                    m_mthDrawMultiString(p_fntNormalText, p_fntNormalText, 0, m_intRecBaseX, p_intPosY, m_intRecBaseX + 700, p_intPosY, 0, 0, "    " + m_objContent.m_strSHEXIANG_RIGHT, p_objGrp);
                    p_intPosY += 1 + 20 * (int)(Math.Ceiling((m_objContent.m_strSHEXIANG_RIGHT.Length + 5) / 46.0));


                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 30;

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

        #region 产后软产道检查>>处理
        /// <summary>
        /// 产后软产道检查>>处理
        /// </summary>
        private class clsPrintDel : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private clsInpatMedRec_Item objItemContent = null;

            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Near;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (m_hasItems != null)
                //    if (m_hasItems.Contains("产后软产道检查>>处理"))
                //        objItemContent = m_hasItems["产后软产道检查>>处理"] as clsInpatMedRec_Item;
                if (m_objContent == null || m_objContent.m_strTREATMENT == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {


                    p_objGrp.DrawString("产后软产道检查 处理：", p_fntNormalText, Brushes.Black, m_intRecBaseX, p_intPosY);
                    p_intPosY += 20;
                    m_mthDrawMultiString(p_fntNormalText, p_fntNormalText, 0, m_intRecBaseX, p_intPosY, m_intRecBaseX + 700, p_intPosY, 0, 0, "    " + m_objContent.m_strTREATMENT_RIGHT, p_objGrp);
                    p_intPosY += 20 + 20 * (int)(Math.Ceiling((m_objContent.m_strTREATMENT_RIGHT.Length + 5) / 46.0));

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 30;

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

        #region 处理者
        /// <summary>
        /// 处理者
        /// </summary>
        private class clsPrint9 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private clsInpatMedRec_Item objItemContent = null;

            #region 打印字符串

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fotNormal"></param>
            /// <param name="fotSmall"></param>
            /// <param name="iLimitLenth"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="x1"></param>
            /// <param name="y1"></param>
            /// <param name="xOff"></param>
            /// <param name="yOff"></param>
            /// <param name="strContent"></param>
            /// <param name="g"></param>
            private void m_mthDrawMultiString(Font m_fotContentFont, Font m_fotTitleFont, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, Graphics g)
            {
                RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
                RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, y1 - y);
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = System.Drawing.StringAlignment.Near;
                strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
                if (strContent.Length > iLimitLenth)
                {
                    if (strContent.Length > iLimitLenth + 1)
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRect, strFormat);
                    }
                    else//因为字体变小，只多出一字时未超出一行，此时无需上移
                    {
                        g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                    }
                }
                else
                {
                    g.DrawString(strContent, m_fotContentFont, Brushes.Black, drawRectNormal, strFormat);
                }
            }
            #endregion
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (m_hasItems != null)
                //    if (m_hasItems.Contains("产后软产道检查>>处理"))
                //        objItemContent = m_hasItems["产后软产道检查>>处理"] as clsInpatMedRec_Item;
                if (m_objContent == null || m_objContent.m_strTREATMENT == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {


                    clsEmrSigns_VO[] m_signVO = null;
                    string strSign1 = string.Empty;
                    m_signVO = m_objContent.objSignerArr;
                    if (m_signVO != null)
                    {
                        for (int intI = 0; intI < m_signVO.Length; intI++)
                        {
                            if (m_signVO[intI].controlName == "lsvSign2")
                            {
                                strSign1 += m_signVO[intI].objEmployee.m_strGetTechnicalRankAndName;
                                strSign1 += " ";
                            }
                        }
                    }
                    p_objGrp.DrawString("处理者：" + strSign1, p_fntNormalText, Brushes.Black, m_intRecBaseX + 440, p_intPosY);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 30;

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

        #region 标题文字部分
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawString("第      页", fntHeader, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 175);
            e.Graphics.DrawString(m_intCurrentPage.ToString(), fntHeader, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 175);
        }
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("中期妊娠引产记录", new Font("宋体", 12, FontStyle.Bold), m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BirthTime_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Birth));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
        }
        #endregion

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            m_mthResetWhenEndPrint();
        }

        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {
            m_objPrintLineContext.m_mthReset();

            m_intYPos = 155;

            m_intCurrentPage = 1;
        }

        #endregion

        
    }
}

