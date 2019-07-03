using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 爱婴区婴儿评估表打印工具类
    /// </summary>
    public class clsAYQBabyAssessmentRecordPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
        private clsBaseCaseHistoryDomain m_objRecordsDomain;
        private clsAYQBabyAssessmentContentDomain m_objInRoomDomain;
        private clsAYQBabyAssessmentContent[] objRecordArr = null;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;

        public clsAYQBabyAssessmentRecordPrintTool()
        {
            m_objInRoomDomain = new clsAYQBabyAssessmentContentDomain();
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
            //佛二病程记录及爱婴区婴儿评估表要求：当病人年龄小于一个月时，用“新”表示
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440605001")
            {
                string strAge = "";
                if (m_objPatient != null)
                {
                    strAge = m_objPatient.m_ObjPeopleInfo.m_StrAge;
                    if (strAge.IndexOf("月") == -1 && strAge.IndexOf("岁") == -1)
                        strAge = "新";
                }
                m_objPrintInfo.m_strAge = strAge;
            }
            else
                m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? p_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_mthGetPrintMarkConfig();
        }
        /// <summary>
        /// 获取打印修改痕迹设置
        /// </summary>
        private void m_mthGetPrintMarkConfig()
        {
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3012");
            if (intConfig == 0)
            {
                m_blnIsPrintMark = false;
            }
            else
            {
                m_blnIsPrintMark = true;
            }
        }
        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;
            
            if (m_objPrintInfo == null)
            {
                MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }

            if (m_objPrintInfo.m_strInPatentID != "")
            {
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.AYQBabyAssessmentRecord);
                long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.MinValue, out m_objPrintInfo.m_objContent, out m_objPrintInfo.m_objPicValueArr, out m_objPrintInfo.m_dtmFirstPrintDate, out m_objPrintInfo.m_blnIsFirstPrint);

                //if (m_objPrintInfo.m_objContent != null)
                //{
                    lngRes = m_objInRoomDomain.m_lngGetAllModifiedCircsRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),  out objRecordArr);
                //}
            }
            //设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
            m_mthSetPrintContent((clsAYQBabyAssessmentContent_EspRecord)m_objPrintInfo.m_objContent, objRecordArr, m_objPrintInfo.m_dtmFirstPrintDate);
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

            m_mthSetPrintContent((clsAYQBabyAssessmentContent_EspRecord)m_objPrintInfo.m_objContent, objRecordArr, m_objPrintInfo.m_dtmFirstPrintDate);
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
            TopY = 140,
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
            RowLinesNum = 34,

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
        private void m_mthSetPrintContent(clsAYQBabyAssessmentContent_EspRecord p_objContent, clsAYQBabyAssessmentContent[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		new clsPrintRecordHeader(),
																		new clsPrintCircsRecordContent(),
                                                                        new clsPrintEspRecordContent()
																	   });
            m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();

            object[] objData = new Object[3];
            objData[0] = p_objContent;
            objData[1] = m_objPrintInfo;
            objData[2] = p_objCircsContentArr;

            //设置打印信息，就是Set Value进去
            m_objPrintLineContext.m_ObjPrintLineInfo = objData;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
            m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
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
            Sex_Title,
            Sex,
            Age_Title,
            Age,
            BedNO_Title,
            BedNO,
            Dept_Name_Title,
            Dept_Name,
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
                        m_fReturnPoint = new PointF(320f, 40f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(303f, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(45f, 110f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(95f, 110f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(165f, 110f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(210f, 110f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(260f, 110f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(305f, 110f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(390f, 110f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(440f, 110f);
                        break;

                    case (int)enmItemDefination.BedNO_Title:
                        m_fReturnPoint = new PointF(555f, 110f);
                        break;
                    case (int)enmItemDefination.BedNO:
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

            BottomY = 1024,

            PrintWidth = 630,
            PrintWidth2 = 710,

        }

        #endregion

        #region PrintClasses
        private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            protected clsAYQBabyAssessmentContent_EspRecord m_objContent;
            protected Pen m_GridPen = new Pen(Color.Black);
            /// <summary>
            /// 文字距离左边的边距
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
            protected int m_intPatientInfoX = 70;
            protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
            protected clsAYQBabyAssessmentContent[] m_objPrintCircsArr;

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
                    m_objContent = (clsAYQBabyAssessmentContent_EspRecord)objData[0];
                    m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)objData[1];
                    m_objPrintCircsArr = (clsAYQBabyAssessmentContent[])objData[2];
                }
            }
        }
        /// <summary>
        /// 画表格及标题
        /// </summary>
        private class clsPrintRecordHeader : clsPrintInPatientCaseInfo
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
                    int m_intY = (int)enmRectangleInfo.TopY + (int)enmRectangleInfoInPatientCaseInfo.SmallRowStep;
                    //画横线
                    //int m_intWidth = (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX;
                    for (int i = 0; i < (int)enmRectangleInfo.RowLinesNum; i++)
                    {
                        if (i != 0)
                        {
                            p_objGrp.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, m_intY, (int)enmRectangleInfo.RightX, m_intY);
                            m_intY += (int)enmRectangleInfoInPatientCaseInfo.SmallRowStep;
                        }
                        else
                        {
                            p_objGrp.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX + 110, m_intY, (int)enmRectangleInfo.RightX, m_intY);
                            m_intY += (int)enmRectangleInfoInPatientCaseInfo.SmallRowStep;
                        }
                    }
                    //画竖线
                    int m_intX = (int)enmRectangleInfo.LeftX;
                    for (int j = 0; j < 8; j++)
                    {
                        p_objGrp.DrawLine(m_GridPen, m_intX + 110, (int)enmRectangleInfo.TopY, m_intX + 110, (int)enmRectangleInfo.TopY + 14 * (int)enmRectangleInfoInPatientCaseInfo.SmallRowStep);
                        m_intX += 80;
                    }
                    //画评估内容与日期之间的斜线
                    p_intPosY = (int)enmRectangleInfo.TopY + 16;
                    p_objGrp.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.LeftX + 110, (int)enmRectangleInfo.TopY + 2 * (int)enmRectangleInfoInPatientCaseInfo.SmallRowStep);
                    #region 画标题
                    p_objGrp.DrawString("日期", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 67, p_intPosY);
                    p_intPosY += 10;
                    p_objGrp.DrawString("评估内容", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 5, p_intPosY);
                    p_intPosY += 32;
                    p_objGrp.DrawString("面  色", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30,p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("呼  吸", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("反  应", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30,p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("进  食", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("腋  温", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("皮  肤", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("黄  疸", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("脐  部", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("四肢活动", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 25, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("大  便", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("小  便", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("签  名", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("特殊记录：", m_fotContentFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 5, p_intPosY);
                    
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
        /// 评估项目内容
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
                p_intPosY = (int)enmRectangleInfo.TopY + 10;
                if (m_blnIsFirstPrint)
                {
                    int intTempX = (int)enmRectangleInfo.LeftX + 115;
                    for (int i = 0; i < m_objPrintCircsArr.Length; i++)
                    {
                        #region 打印表格内容
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("yyyy.MM.dd"), m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_dtmRecordDate.ToString("HH:mm"), m_fotContentFont, Brushes.Black, intTempX + 5, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strFacecolor, m_fotContentFont, Brushes.Black, intTempX , p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strRespiration, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strReaction, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strTakeFood, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strArmpitWet, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strDerm, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strAurigo, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strUmbilicalRegion, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strLimbActivity, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strStool, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strUrine, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString(m_objPrintCircsArr[i].m_strSignUserName, m_fotContentFont, Brushes.Black, intTempX, p_intPosY);
                        intTempX += 80;
                        p_intPosY = (int)enmRectangleInfo.TopY + 10;
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

        /// <summary>
        /// 特殊记录
        /// </summary>
        private class clsPrintEspRecordContent : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private Font m_fotContentFont = new Font("SimSun", 9);
            int intLine = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                
                if (m_blnIsFirstPrint)
                {
                    p_intPosY = (int)enmRectangleInfo.TopY + (int)enmRectangleInfo.SmallRowStep * 14 + 6;
                    string strTemp = "";
                    if (m_objContent.m_strEspRecord.Length == 0 && m_objContent.m_strEspRecord2.Length == 0 && m_objContent.m_strEspRecord3.Length == 0 && m_objContent.m_strEspRecord4.Length == 0)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    if (m_objContent.m_strEspRecord.Length != 0)
                    {
                        strTemp += m_objContent.m_strEspRecord + '\n' + "                                                                                                                                --" + m_objContent.m_strRecordSign + "   " + m_objContent.m_dtmRecordDate + '\n';
                    }
                    if (m_objContent.m_strEspRecord2.Length != 0)
                    {
                        strTemp += m_objContent.m_strEspRecord2 + '\n' + "                                                                                                                                --" + m_objContent.m_strRecordSign2 + "   " + m_objContent.m_dtmRecordDate2 + '\n';
                    }
                    if (m_objContent.m_strEspRecord3.Length != 0)
                    {
                        strTemp += m_objContent.m_strEspRecord3 + '\n' + "                                                                                                                                --" + m_objContent.m_strRecordSign3 + "   " + m_objContent.m_dtmRecordDate3 + '\n';
                    }
                    if (m_objContent.m_strEspRecord4.Length != 0)
                    {
                        strTemp += m_objContent.m_strEspRecord4 + '\n' + "                                                                                                                                --" + m_objContent.m_strRecordSign4 + "   " + m_objContent.m_dtmRecordDate4 + '\n';
                    }
                    //if (clsAYQBabyAssessmentRecordPrintTool.m_blnIsPrintMark)
                    //{
                    //    m_objPrintContext.m_mthSetContextWithCorrectBefore(m_objContent.m_strEspRecord, m_objContent.m_strEspRecordXML, m_dtmFirstPrintTime, true );
                    //}
                    //else
                    //{
                        m_objPrintContext.m_mthSetContextWithAllCorrect(strTemp, "<root />");
                    //}
                    m_blnIsFirstPrint = false;
                }

                
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if( intLine == 0)
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX - 70, (int)enmRectangleInfo.LeftX + 75, p_intPosY, p_objGrp);
                    else
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX , (int)enmRectangleInfo.LeftX + 5, p_intPosY, p_objGrp);
                    p_intPosY += 25;

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

            e.Graphics.DrawString("爱婴区婴儿评估表", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));
            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));
            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));
            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));
            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));
            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNO_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNO));
            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
            e.Graphics.DrawRectangle(Pens.Black, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.RowLinesNum * (int)enmRectangleInfo.SmallRowStep);
            e.Graphics.DrawString("注：正常打\"√\"", m_fotSmallFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 20, (int)enmRectangleInfo.RowLinesNum * (int)enmRectangleInfo.SmallRowStep + 5 + (int)enmRectangleInfo.TopY);
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
