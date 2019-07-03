using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 产时记录打印工具类
    /// </summary>
    public class clsBrothRecords_F2PrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
        private clsBaseCaseHistoryDomain m_objRecordsDomain;

        private clsBrothRecords_F2Domain m_objInRoomDomain;//m_objDomain;
      //  private clsNewBabyInRoomRecordDomain m_objInRoomDomain;

        public clsBrothRecords_F2PrintTool()
        {
         //   m_objInRoomDomain = new clsNewBabyInRoomRecordDomain();
            m_objInRoomDomain = new clsBrothRecords_F2Domain();//clsBrothRecords_F2Domain();

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
            clsBrothRecords_F2Rec[] objRecordArr = null;

            if (m_objPrintInfo == null)
            {
                MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }

            if (m_objPrintInfo.m_strInPatentID != "")
            {
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.BrothRecords_F2);
                long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.MinValue, out m_objPrintInfo.m_objContent, out m_objPrintInfo.m_objPicValueArr, out m_objPrintInfo.m_dtmFirstPrintDate, out m_objPrintInfo.m_blnIsFirstPrint);

                if (m_objPrintInfo.m_objContent != null)
                {
                    lngRes = m_objInRoomDomain.m_lngGetAllModifiedCircsRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),/* ((clsBrothRecords_F2)(m_objPrintInfo.m_objContent)).m_dtmBIRTHTIME.ToString("yyyy-MM-dd HH:mm:ss")*/ out objRecordArr);
                }
            }
            //设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
            m_mthSetPrintContent((clsBrothRecords_F2)m_objPrintInfo.m_objContent, objRecordArr, m_objPrintInfo.m_dtmFirstPrintDate);
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

            m_mthSetPrintContent((clsBrothRecords_F2)m_objPrintInfo.m_objContent, null, m_objPrintInfo.m_dtmFirstPrintDate);
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


        #region 打印

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

        // 设置打印内容。
        private void m_mthSetPrintContent(clsBrothRecords_F2 p_objContent, clsBrothRecords_F2Rec[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                                                        new clsPrint1(),
                                                                        new  clsPrint2(),
                                                                        new clsPrint3(),
                                                                        new clsPrint4(),
                                                                        new clsPrint5(),
                                                                        new clsPrint6(),
                                                                        new clsPrint7(),
                                                                        new clsPrint8(),
                                                                        new clsPrint9(),                                                                       
                                                                        new clsPrintCircsRecordHeader(),
                                                                        new clsPrintCircsRecordContent()                                                                        
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

        private clsBrothRecords_F2 m_objChangePrintTextColor(clsBrothRecords_F2 p_objclsInPatientCase)
        {
            if (p_objclsInPatientCase == null)
                return null;
            //把白色变为黑色
            clsXML_DataGrid objclsXML_DataGrid = new clsXML_DataGrid();
            //p_objclsInPatientCase.m_strOTHERCHECKXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);
            //p_objclsInPatientCase.m_strOTHERCHECKXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOTHERCHECKXML);

            //p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOUTHOSPITALADVICEXML);
            //p_objclsInPatientCase.m_strDEALWITHXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strDEALWITHXML);

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
            BabySex_Title,
            BabySex,
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
                        m_fReturnPoint = new PointF(340f - fltOffsetX, 80f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(280f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(50f - fltOffsetX, 150f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(130f - fltOffsetX, 150f);
                        break;

                    case (int)enmItemDefination.BabySex_Title:
                        m_fReturnPoint = new PointF(250f - fltOffsetX, 150f);
                        break;
                    case (int)enmItemDefination.BabySex:
                        m_fReturnPoint = new PointF(330f - fltOffsetX, 150f);
                        break;

                    case (int)enmItemDefination.BirthTime_Title:
                        m_fReturnPoint = new PointF(400f - fltOffsetX, 150f);
                        break;
                    case (int)enmItemDefination.Birth:
                        m_fReturnPoint = new PointF(500f - fltOffsetX, 150f);
                        break;
                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(610f - fltOffsetX, 115f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(680f - fltOffsetX, 115f);
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
            protected clsBrothRecords_F2 m_objContent;
            protected Pen m_GridPen = new Pen(Color.Black);
            /// <summary>
            /// 文字距离左边的边距
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
            protected int m_intPatientInfoX = 70;
            protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
            protected clsBrothRecords_F2Rec[] m_objPrintCircsArr;

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
                    m_objContent = (clsBrothRecords_F2)objData[0];
                    m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)objData[1];
                    m_objPrintCircsArr = (clsBrothRecords_F2Rec[])objData[2];
                }
            }
        }

        /// <summary>
        /// 爱人信息
        /// </summary>
        private class clsPrint1 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    //  p_objGrp.DrawString("一般情况：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_objGrp.DrawString("爱人姓名： " + (m_objContent.M_TXTAIRENNAME == null ? "" : m_objContent.M_TXTAIRENNAME) + "；年龄： " + (m_objContent.M_TXTAGE == null ? "" : m_objContent.M_TXTAGE) + "；籍贯： " +
                        (m_objContent.M_TXTJIGUAN == null ? "" : m_objContent.M_TXTJIGUAN) + "；职业： " + (m_objContent.M_TXTZHIYE == null ? "" : m_objContent.M_TXTZHIYE) + "；任职处所： " +
                        (m_objContent.M_TXTRENZHI == null ? "" : m_objContent.M_TXTRENZHI) + "；住址： " + (m_objContent.M_TXTZHUZHI == null ? "" : m_objContent.M_TXTZHUZHI) + "；婴儿住院号： " + (m_objContent.M_TXTBABYID == null ? "" : m_objContent.M_TXTBABYID), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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

        /// <summary>
        /// 宫缩破膜时间急方式
        /// </summary>
        private class clsPrint2 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    p_objGrp.DrawString("宫缩始于： " + (m_objContent.M_DTPGONGSUOTIME.ToString() == null ? "" : m_objContent.M_DTPGONGSUOTIME.ToString()) + "；胎膜破于： " + (m_objContent.M_DTPPOMOTIME.ToString() == null ? "" : m_objContent.M_DTPPOMOTIME.ToString()), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                  //  p_intPosY += 20;
                    p_objGrp.DrawString("膜破方式：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 450, p_intPosY);

                    string strChildBearing0 = m_objContent.M_RDBMOPO[0].ToString();//自破
                    string strChildBearing1 = m_objContent.M_RDBMOPO[1].ToString();//手术破                           

                    string strPrint = (strChildBearing0 == "0" ? "" : "自破") + (strChildBearing1 == "0" ? "" : "手术破");
                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 540, p_intPosY);
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

        /// <summary>
        /// 宫口开全,胎位.....
        /// </summary>
        private class clsPrint3 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary> 
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    //  p_objGrp.DrawString("一般情况：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_objGrp.DrawString("宫口开全： " + (m_objContent.M_DTPGONGKOUKAITIME.ToString() == null ? "" : m_objContent.M_DTPGONGKOUKAITIME.ToString()) + "；胎次： " + (m_objContent.M_CBOTAICI == null ? "" : m_objContent.M_CBOTAICI) + "；孕期： " +
                        (m_objContent.M_CBOYUNQI == null ? "" : m_objContent.M_CBOYUNQI) + "；胎位： " + (m_objContent.M_CBOTAIWEI == null ? "" : m_objContent.M_CBOTAIWEI), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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

        /// <summary>
        /// 出生
        /// </summary>
        private class clsPrint4 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    p_objGrp.DrawString("出生： " + (m_objContent.M_DTPBROTHTIME == null ? "" : m_objContent.M_DTPBROTHTIME.ToString()), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //  p_intPosY += 20;
                    p_objGrp.DrawString("方式：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);

                    string strChildBearing0 = m_objContent.M_DTPBROTHTYPE[0].ToString();//自然产
                    string strChildBearing1 = m_objContent.M_DTPBROTHTYPE[1].ToString();//手术产                           

                    string strPrint = (strChildBearing0 == "0" ? "" : "自然产") + (strChildBearing1 == "0" ? "" : "手术产");

                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);

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

        /// <summary>
        /// 胎盘娩出
        /// </summary>
        private class clsPrint5 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    p_objGrp.DrawString("胎盘娩出： " + (m_objContent.M_DTPTAIPANTIME == null ? "" : m_objContent.M_DTPTAIPANTIME.ToString()), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //  p_intPosY += 20;
                    p_objGrp.DrawString("方式：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 230, p_intPosY);

                    string strChildBearing0 = m_objContent.M_RDBTAIPANTYPE[0].ToString();//自然
                    string strChildBearing1 = m_objContent.M_RDBTAIPANTYPE[1].ToString();//迫出    
                    string strChildBearing2 = m_objContent.M_RDBTAIPANTYPE[2].ToString();//剥离
                    string strChildBearing3 = m_objContent.M_RDBTAIPANTYPE[3].ToString();//产式                           
                    string strChildBearing4 = m_objContent.M_RDBTAIPANTYPE[4].ToString();//破碎   

                    string strPrint = (strChildBearing0 == "0" ? "" : "自然") + (strChildBearing1 == "0" ? "" : "迫出") + (strChildBearing2 == "0" ? "" : "剥离") + (strChildBearing3 == "0" ? "" : "产式") + (strChildBearing4 == "0" ? "" : "破碎");

                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 280, p_intPosY);
                    
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

        /// <summary>
        /// 胎盘
        /// </summary>
        private class clsPrint6 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    p_objGrp.DrawString("胎盘：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_objGrp.DrawString("形状： " + (m_objContent.M_CBOXINGZHUANG == null ? "" : m_objContent.M_CBOXINGZHUANG) + "；重量： " + (m_objContent.M_CBOZHONGLIANG == null ? "" : m_objContent.M_CBOZHONGLIANG) + "；大小： " +
                        (m_objContent.M_CBODAXIAO == null ? "" : m_objContent.M_CBODAXIAO) + "；完整否： " + (m_objContent.M_CBOWANZHENG == null ? "" : m_objContent.M_CBOWANZHENG), p_fntNormalText, Brushes.Black, m_intRecBaseX + 50, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("脐带附着处： " + (m_objContent.M_CBOQIDAI == null ? "" : m_objContent.M_CBOQIDAI) + "；脐长： " + (m_objContent.M_CBOQICHANG == null ? "" : m_objContent.M_CBOQICHANG) + "；滞留： " +
                       (m_objContent.M_CBOZZHILIU == null ? "" : m_objContent.M_CBOZZHILIU), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

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

        /// <summary>
        /// 会阴
        /// </summary>
        private class clsPrint7 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    //  p_objGrp.DrawString("胎盘娩出： " + (m_objContent.M_DTPTAIPANTIME == null ? "" : m_objContent.M_DTPTAIPANTIME), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //  p_intPosY += 20;
                    p_objGrp.DrawString("会阴：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    string strChildBearing0 = m_objContent.M_RDBHUIYINTYPE[0].ToString();//未破
                    string strChildBearing1 = m_objContent.M_RDBHUIYINTYPE[1].ToString();//旧破    
                    string strChildBearing2 = m_objContent.M_RDBHUIYINTYPE[2].ToString();//新破
                    string strChildBearing3 = m_objContent.M_RDBHUIYINTYPE[3].ToString();//1                           
                    string strChildBearing4 = m_objContent.M_RDBHUIYINTYPE[4].ToString();//2   
                    string strChildBearing5 = m_objContent.M_RDBHUIYINTYPE[5].ToString();//3   

                    string strPrint = (strChildBearing0 == "0" ? "" : "未破") + (strChildBearing1 == "0" ? "" : "旧破") + (strChildBearing2 == "0" ? "" : "新破") + (strChildBearing3 == "0" ? "" : "1度") + (strChildBearing4 == "0" ? "" : "2度") + (strChildBearing5 == "0" ? "" : "3度");

                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 60, p_intPosY);
                    p_objGrp.DrawString("切开术：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 100, p_intPosY);
                    string strChildBearin0 = m_objContent.M_RDBHUIYINQIEKAITYPE[0].ToString();//左
                    string strChildBearin1 = m_objContent.M_RDBHUIYINQIEKAITYPE[1].ToString();//右    
                    string strChildBearin2 = m_objContent.M_RDBHUIYINQIEKAITYPE[2].ToString();//正中
                    string strPrint1 = (strChildBearin0 == "0" ? "" : "左") + (strChildBearin1 == "0" ? "" : "右") + (strChildBearin2 == "0" ? "" : "正中");

                    p_objGrp.DrawString(strPrint1, p_fntNormalText, Brushes.Black, m_intRecBaseX + 180, p_intPosY);

                    p_objGrp.DrawString("内缝： " + (m_objContent.M_CBONEIFENG == null ? "" : m_objContent.M_CBONEIFENG) + "针；外缝： " + (m_objContent.M_CBOWAIFENG == null ? "" : m_objContent.M_CBOWAIFENG) + "针；失血： " +
                      (m_objContent.M_CBOSHIXUE == null ? "" : m_objContent.M_CBOSHIXUE) + "ml；宫缩情况：宫底高 ：" + (m_objContent.M_CBOGONGDIGAO == null ? "" : m_objContent.M_CBOGONGDIGAO), p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("宫颈情况： " + (m_objContent.M_CBOGONGJINGQINGKUANG == null ? "" : m_objContent.M_CBOGONGJINGQINGKUANG) + "；产后血压： " + (m_objContent.M_CBOXUEYA1 == null ? "" : m_objContent.M_CBOXUEYA1) + "/" +
                       (m_objContent.M_CBOXUEYA2 == null ? "" : m_objContent.M_CBOXUEYA2) + "kpa；呼吸： " + (m_objContent.M_CBOHUXI == null ? "" : m_objContent.M_CBOHUXI) + "次/分；脉搏： " + (m_objContent.M_CBOMAIBO == null ? "" : m_objContent.M_CBOMAIBO) + "次/分", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);


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

        /// <summary>
        /// 婴儿 
        /// </summary>
        private class clsPrint8 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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

                    //  p_objGrp.DrawString("胎盘娩出： " + (m_objContent.M_DTPTAIPANTIME == null ? "" : m_objContent.M_DTPTAIPANTIME), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //  p_intPosY += 20;
                    p_objGrp.DrawString("婴儿：性别：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    string strChildBearing0 = m_objContent.M_RDBYINGER[0].ToString();//男
                    string strChildBearing1 = m_objContent.M_RDBYINGER[1].ToString();//女    
                    string strChildBearing2 = m_objContent.M_RDBYINGER[2].ToString();//死婴
                    string strChildBearing3 = m_objContent.M_RDBYINGER[3].ToString();//胎 

                    string strPrint = (strChildBearing0 == "0" ? "" : "男") + (strChildBearing1 == "0" ? "" : "女") + (strChildBearing2 == "0" ? "" : "死婴") + (strChildBearing3 == "0" ? "" : "胎");

                    p_objGrp.DrawString(strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 90, p_intPosY);

                    p_objGrp.DrawString("死亡原因： " + (m_objContent.M_CBOSIWANGYUANYIN == null ? "" : m_objContent.M_CBOSIWANGYUANYIN) , p_fntNormalText, Brushes.Black, m_intRecBaseX + 135, p_intPosY);
                   
                    string strChildBearin0 = m_objContent.M_RDBHUXITYPE[0].ToString();//自然呼吸
                    string strChildBearin1 = m_objContent.M_RDBHUXITYPE[1].ToString();//轻度窒息    
                    string strChildBearin2 = m_objContent.M_RDBHUXITYPE[2].ToString();//青紫窒息
                    string strChildBearin3 = m_objContent.M_RDBHUXITYPE[3].ToString();//苍白窒息
                    string strPrint1 = (strChildBearin0 == "0" ? "" : "自然呼吸") + (strChildBearin1 == "0" ? "" : "轻度窒息") + (strChildBearin2 == "0" ? "" : "青紫窒息") + (strChildBearin3 == "0" ? "" : "苍白窒息");

                    p_objGrp.DrawString(strPrint1, p_fntNormalText, Brushes.Black, m_intRecBaseX + 255, p_intPosY);

                    p_objGrp.DrawString("体重： " + (m_objContent.M_CBOTIZHONG == null ? "" : m_objContent.M_CBOTIZHONG) + "公分；身长： " + (m_objContent.M_CBOSHENCHANG == null ? "" : m_objContent.M_CBOSHENCHANG) + "公分 ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 360, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("双颈顶： " + (m_objContent.M_CBOSHUANGDINGJING == null ? "" : m_objContent.M_CBOSHUANGDINGJING) + "公分；枕颈： " + (m_objContent.M_CBOZHENJING == null ? "" : m_objContent.M_CBOZHENJING) + "公分；心： " + (m_objContent.M_CBOXIN == null ? "" : m_objContent.M_CBOXIN) + "；肺：" + (m_objContent.M_CBOFEI == null ? "" : m_objContent.M_CBOFEI) + "；畸形：" + (m_objContent.M_CBOJIXING == null ? "" : m_objContent.M_CBOJIXING), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);


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

        /// <summary>
        /// 产程 及签名
        /// </summary>
        private class clsPrint9 : clsPrintInPatientCaseInfo 
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

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
                    p_objGrp.DrawString("第一产程： " + (m_objContent.M_CBOYICHANCHENG == null ? "" : m_objContent.M_CBOYICHANCHENG) + "；第二产程： " + (m_objContent.M_CBOERCHANCHENG == null ? "" : m_objContent.M_CBOERCHANCHENG)  , p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("第三产程： " + (m_objContent.M_CBOSANCHANCHENG == null ? "" : m_objContent.M_CBOSANCHANCHENG) + "；全程：" + (m_objContent.M_CBOQUANCHENG == null ? "" : m_objContent.M_CBOQUANCHENG), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    p_objGrp.DrawString("接生人： " + (m_objContent.M_TXTJIESHEN == null ? "" : m_objContent.M_TXTJIESHEN) + "；助理人： " + (m_objContent.M_TXTZHULI == null ? "" : m_objContent.M_TXTZHULI) + "；护理人： " + (m_objContent.M_TXTHULI == null ? "" : m_objContent.M_TXTHULI) + "；指导人：" + (m_objContent.M_TXTZHIDAO == null ? "" : m_objContent.M_TXTZHIDAO), p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                  
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

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objPrintCircsArr == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 30;
                    m_fReturnPoint = new PointF(300f, p_intPosY);
                    p_objGrp.DrawString(" 产 时 记 录", m_fotTitleFont, Brushes.Black, m_fReturnPoint);
                    p_intPosY += 25;

                    p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY, m_intRecBaseX + 744, p_intPosY);

                    #region 画表格标头
                    int intPosX = m_intRecBaseX - 10;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//0 
                    p_objGrp.DrawString("日期", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 20f, p_intPosY + 20, 50, 80));
                    intPosX += 110;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//1					
                    p_objGrp.DrawString("血压", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 20, 20, 80));
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//2				
                    p_objGrp.DrawString("宫缩间歇", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 10, 20, 80));
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY , intPosX, p_intPosY + 80);//3		
                    p_objGrp.DrawString("宫缩缩时", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 10, 20, 80));
                  //  p_objGrp.DrawString("头", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 10f, p_intPosY + 2, 20, 80));
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY , intPosX, p_intPosY + 80);//4		
                    p_objGrp.DrawString("胎心 次/分", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 2, 20, 80));
                    intPosX += 50;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//5		
                    p_objGrp.DrawString("宫口开大", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 10f, p_intPosY + 10, 20, 80));
                    intPosX += 70;
                    //p_objGrp.DrawString("眼", m_fotContentFont, Brushes.Black, new RectangleF(intPosX - 5f, p_intPosY + 2, 20, 80));
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY , intPosX, p_intPosY + 80);//6		
                    p_objGrp.DrawString("胎膜情况", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 8, 20, 80));
                    intPosX += 70;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//7		
                    p_objGrp.DrawString("先露高低", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 8, 20, 80));
                    intPosX += 70;
                  //  p_objGrp.DrawString("口", m_fotContentFont, Brushes.Black, new RectangleF(intPosX - 5f, p_intPosY + 2, 20, 80));
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY , intPosX, p_intPosY + 80);//8		
                    p_objGrp.DrawString("检查法", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 10f, p_intPosY + 17, 20, 80));
                    intPosX += 70;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//9							
                    p_objGrp.DrawString("宫底及四周", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 2, 20, 80));
                  //  p_objGrp.DrawString("皮肤", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 20f, p_intPosY + 2, 80, 80));
                    intPosX += 53;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY , intPosX, p_intPosY + 80);//10		
                    p_objGrp.DrawString("阴道分泌物", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 3f, p_intPosY + 2, 20, 80));
                    intPosX += 50;                   
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//18
                    p_objGrp.DrawString("签名", m_fotContentFont, Brushes.Black, new RectangleF(intPosX + 10f, p_intPosY + 20, 60f, 80f));
                    intPosX += 60;
                    p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + 80);//19

                  //  p_objGrp.DrawLine(m_GridPen, m_intRecBaseX + 70, p_intPosY + 17, intPosX - 181, p_intPosY + 17);
                    p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY + 80, m_intRecBaseX + 744, p_intPosY + 80);
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

        /// <summary>
        /// 产时记录表格内容
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

                p_intPosY += 80;

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
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("yyyy-MM-dd hh:mm:ss"), m_fotTimetFont, Brushes.Black, intTempX, p_intPosY);
                        intTempX += 110;
                        //p_objGrp.DrawString(m_objPrintCircsArr[i].m_strBIRTHDAYS, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        //intTempX += 20;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_XUEYA, m_objPrintCircsArr[i].str_XUEYAXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_XUEYA, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_GONGSUOJIANXUE, m_objPrintCircsArr[i].str_GONGSUOJIANXUEXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_GONGSUOJIANXUE, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_GONGSUOTIME, m_objPrintCircsArr[i].str_GONGSUOTIMEXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_GONGSUOTIME, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_TAIXIN, m_objPrintCircsArr[i].str_TAIXINXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_TAIXIN, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 50;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_GONGKOU, m_objPrintCircsArr[i].str_GONGKOUXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_GONGKOU, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 70;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_TAIMO, m_objPrintCircsArr[i].str_TAIMOXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_TAIMO, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 70;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_XIANLU, m_objPrintCircsArr[i].str_XIANLUXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_XIANLU, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 70;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_JIANCHAFA, m_objPrintCircsArr[i].str_JIANCHAFAXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_JIANCHAFA, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 70;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_GONGDIJIZHOU, m_objPrintCircsArr[i].str_GONGDIJIZHOUXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_GONGDIJIZHOU, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 53;
                        strArrTemp = null;
                        strXMLArrTemp = null;
                        ctlRichTextBox.m_mthSplitXml(m_objPrintCircsArr[i].str_FENMIWU, m_objPrintCircsArr[i].str_FENMIWUXML, 3, out strArrTemp, out strXMLArrTemp);
                        if (intThisLows < strArrTemp.Length)
                            intThisLows = strArrTemp.Length;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].str_FENMIWU, m_fotContentFont, Brushes.Black, new RectangleF(intTempX, p_intPosY, 38, 100));
                        intTempX += 50;
                    
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSignUserName, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        #endregion

                        #region 打印该行表格框架
                        int intPosX = m_intRecBaseX - 10;
                        int intThisLowHeight = intThisLows * 17;
                        p_intPosY -= 2;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 110;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 70;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 70;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 70;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 70;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 53;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 50;                       
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);
                        intPosX += 60;
                        p_objGrp.DrawLine(m_GridPen, intPosX, p_intPosY, intPosX, p_intPosY + intThisLowHeight);

                        p_objGrp.DrawLine(m_GridPen, m_intRecBaseX - 10, p_intPosY + intThisLowHeight, m_intRecBaseX + 744, p_intPosY + intThisLowHeight);

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

            e.Graphics.DrawString("      产 时 记 录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawString("住院号：", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
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

            m_intYPos = 55;

            m_intCurrentPage = 1;
        }

        #endregion
    }
}
