using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using com.digitalwave.PatientManagerService;

namespace iCare
{
    /// <summary>
    /// clsDeathRecordIn24HoursPrintTool 
    /// Description:入院24小时内死亡记录打印类
    /// Author:Jock
    /// Date:05-12-27
    /// </summary>
    public class clsDeathRecordIn24HoursPrintTool : infPrintRecord
    {

        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;

        private clsDeathRecordIn24HoursDomain m_objRecordsDomain;

        private clsPrintInfo_DeathRecordIn24Hours m_objPrintInfo;

        private clsEMR_DeathRecordIn24HoursValue m_objRecordContent = null;

        public clsDeathRecordIn24HoursPrintTool()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
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
            m_objPrintInfo = new clsPrintInfo_DeathRecordIn24Hours();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;

            m_objPrintInfo.m_strNative = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrHomeplace : "";//籍贯
            m_objPrintInfo.m_strOccupation = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";//职业
            m_objPrintInfo.m_strIsMarried = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrMarried : "";//婚否
            m_objPrintInfo.m_strFolk = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNation : "";//民族

            m_objPrintInfo.m_strCompany = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOffice_name : "";//单位
            m_objPrintInfo.m_strCompanyPhone = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOfficePhone : "";//单位电话
            m_objPrintInfo.m_strAddress = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress : "";//地址
            m_objPrintInfo.m_strAddressPhone = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrHomePhone : "";//家庭电话
            m_objPrintInfo.m_strIDCard = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrIDCard : "";//ID Card

            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;//
            if (m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }
            if (m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_dtmOpenDate == DateTime.MinValue)
                m_objRecordContent = null;
            else
            {
                m_objRecordsDomain = new clsDeathRecordIn24HoursDomain();
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                if (lngRes <= 0)
                    return;
                m_objRecordContent = (clsEMR_DeathRecordIn24HoursValue)objContent;
            }
            //设置表单内容到打印中			
            m_objPrintInfo.m_objRecordContent = m_objRecordContent;
            m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {


            m_blnWantInit = false;
            //if (p_objPrintContent.GetType().Name != "clsPrintInfo_Base")
            //{
            //    clsPublicFunction.ShowInformationMessageBox("参数错误");
            //    return;
            //}
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_DeathRecordIn24Hours)p_objPrintContent;
            m_objRecordContent = m_objPrintInfo.m_objRecordContent;
            m_mthSetPrintValue();
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
                    clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

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
            m_fotSmallFont = new Font("SimSun", 11);
            m_GridPen = new Pen(Color.Black, 1);
            m_LinePen = new Pen(Color.Gray, 0.5f);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();

            #endregion
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
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_objRecordContent == null) return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue)
            {
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), dtmFirstPrintTime);
            }
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
        }

        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作
        }

        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            m_mthPrintTitleInfo(e);
            Font fntNormal = new Font("SimSun", 12);

            if (m_intPages == 1)
            {
                m_intYPos = 220;
                // e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 206, (int)enmRectangleInfo.RightX, 206);
                //  e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 235, (int)enmRectangleInfo.RightX, 235);
                m_mthPrintBasicInfo(e);
            }



            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, 115, (int)enmRectangleInfo.RightX, 115);


            while (m_objPrintContext.m_BlnHaveMoreLine)
            {
                m_objPrintContext.m_mthPrintNextLine(ref m_intYPos, e.Graphics, fntNormal);

                if (m_intYPos >= (int)enmRectangleInfo.BottomY
                    && m_objPrintContext.m_BlnHaveMoreLine)
                {


                    #region 换页处理
                    e.HasMorePages = true;

                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, 115, (int)enmRectangleInfo.LeftX, m_intYPos);
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.RightX, 115, (int)enmRectangleInfo.RightX, m_intYPos);
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, m_intYPos, (int)enmRectangleInfo.RightX, m_intYPos);

                    m_intPages++;
                    m_intYPos = (int)enmRectangleInfo.TopY + 20;
                    return;

                    #endregion 换页处理
                }

            }

            #region 最后一页处理
            m_intYPos += 30;
            e.Graphics.DrawString("医师签名:", new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, m_intYPos);
            if (m_objRecordContent != null)
                e.Graphics.DrawString(m_objRecordContent.m_strDOCTORSIGNNAME, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440 + (int)(5f * 17.5f), m_intYPos);

            m_intYPos += 30;
            e.Graphics.DrawString("记录日期:", new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, m_intYPos);
            if (m_objRecordContent != null)
                e.Graphics.DrawString(m_objRecordContent.m_dtmRECORDDATE.ToString("yyyy年MM月dd日HH时mm分"), new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440 + (int)(5f * 17.5f), m_intYPos);

            m_intYPos += 25;
            if (m_intYPos < (int)enmRectangleInfo.BottomY)
                m_intYPos = (int)enmRectangleInfo.BottomY;
            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, 115, (int)enmRectangleInfo.LeftX, m_intYPos);
            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.RightX, 115, (int)enmRectangleInfo.RightX, m_intYPos);
            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, m_intYPos, (int)enmRectangleInfo.RightX, m_intYPos);

            #endregion 最后一页处理

            m_intYPos += (int)enmRectangleInfo.RowStep + 15;
            Font fntSign = new Font("", 6);
            while (m_objPrintContext.m_BlnHaveMoreSign)
            {
                m_objPrintContext.m_mthPrintNextSign((int)enmRectangleInfo.LeftX, m_intYPos, e.Graphics, fntSign);

                m_intYPos += (int)enmRectangleInfo.RowStep - 10;
            }

            //全部打完
            m_objPrintContext.m_mthReset();
            m_intPages = 1;
            m_intYPos = (int)enmRectangleInfo.TopY;
        }

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintContext;
        /// <summary>
        /// 标题的字体
        /// </summary>
        private Font m_fotTitleFont;
        /// <summary>
        /// 表头的字体
        /// </summary>
        private Font m_fotHeaderFont;
        /// <summary>
        /// 表内容的字体
        /// </summary>
        private Font m_fotSmallFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 下标线画笔
        /// </summary>
        private Pen m_LinePen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
        /// <summary>
        /// 打印的病人基本信息类
        /// </summary>
        /// 
        private int m_intYPos = (int)enmRectangleInfo.TopY + 7;
        private int m_intPages = 1;

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 115,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 40,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 820 - 40,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 20,
            SmallRowStep = 20,

            ColumnsMark1 = 110,

            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1024
        }

        // <summary>
        /// 打印元素
        /// </summary>
        private enum enmItemDefination
        {
            //基本元素
            Department_Title,
            Department,
            Area_Title,
            Area,
            Bed_Title,
            Bed,
            InPatientID_Title,
            InPatientID,
            Name_Title,
            Name,
            Sex_Title,
            Sex,
            Age_Title,
            Age,
            Occupation_Title,
            Occupation,
            Native_Title,
            Native,
            Folk_Title,
            Folk,
            IsMarried_Title,
            IsMarried,

            Company_Title,
            Company,
            Company_Phone_Title,
            Company_Phone,

            Address_Title,
            Address,
            Address_Phone_Title,
            Address_Phone,

            SickTeller_Title,
            SickTeller,
            ID_Card_Title,
            ID_Card,


            CardiogramID_Title,
            CardiogramID,

            XRayID_Title,
            XRayID,
            UltrasonicID_Title,
            UltrasonicID,
            MRIID_Title,
            MRIID,
            BrainID_Title,
            BrainID,

            Page_HospitalName,
            Page_Name_Title,
            Page_Title,
            Page_Num,
            Page_Of,
            Page_Count,

            Print_Date_Title,
            Print_Date,

        }

        #region 定义打印各元素的坐标点
        private class clsPrintPageSettingForRecord
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
                        m_fReturnPoint = new PointF(330f, 30f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(280f, 60f);
                        break;
                    case (int)enmItemDefination.Department:
                        m_fReturnPoint = new PointF(40f, 100f);
                        break;
                    case (int)enmItemDefination.Department_Title:
                        m_fReturnPoint = new PointF(120f, 100f);
                        break;
                    case (int)enmItemDefination.Area:
                        m_fReturnPoint = new PointF(425f, 100f);
                        break;
                    case (int)enmItemDefination.Area_Title:
                        m_fReturnPoint = new PointF(380f, 100f);
                        break;
                    case (int)enmItemDefination.Bed:
                        m_fReturnPoint = new PointF(605f, 100f);
                        break;
                    case (int)enmItemDefination.Bed_Title:
                        m_fReturnPoint = new PointF(565f, 100f);
                        break;
                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(635f, 100f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(690f, 100f);
                        break;

                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(60f, 100f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(105f, 100f);
                        break;
                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(195f, 100f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(240f, 100f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(275f, 100f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(320f, 100f);
                        break;
                    case (int)enmItemDefination.Occupation:
                        m_fReturnPoint = new PointF(380f, 100f);
                        break;
                    case (int)enmItemDefination.Native_Title:
                        m_fReturnPoint = new PointF(405f, 100f);
                        break;
                    case (int)enmItemDefination.Native:
                        m_fReturnPoint = new PointF(480f, 100f);
                        break;
                    case (int)enmItemDefination.Folk_Title:
                        m_fReturnPoint = new PointF(560f, 100);
                        break;
                    case (int)enmItemDefination.Folk:
                        m_fReturnPoint = new PointF(610f, 100);
                        break;
                    case (int)enmItemDefination.IsMarried_Title:
                        m_fReturnPoint = new PointF(690f, 100f);
                        break;
                    case (int)enmItemDefination.IsMarried:
                        m_fReturnPoint = new PointF(730f, 100f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        #endregion

        #region 打印行定义
        private clsPrintLine1[] m_objLine1Arr;
        #endregion


        private DateTime dtmFirstPrintTime;
        /// <summary>
        /// 给每一打印行的元素赋值
        /// </summary>
        private void m_mthSetPrintValue()
        {

            //测试是否重新打印


            #region  第一次打印时间赋值
            dtmFirstPrintTime = DateTime.Now;
            if (m_objRecordContent != null && m_objRecordContent.m_dtmFirstPrintDate != DateTime.MinValue)
                dtmFirstPrintTime = m_objRecordContent.m_dtmFirstPrintDate;
            #endregion  第一次打印时间赋值

            #region 打印行初始化
            m_objLine1Arr = new clsPrintLine1[6];
            for (int i = 0; i < m_objLine1Arr.Length; i++)
                m_objLine1Arr[i] = new clsPrintLine1();

            m_objPrintContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   m_objLine1Arr[0],m_objLine1Arr[1],m_objLine1Arr[2],m_objLine1Arr[3],m_objLine1Arr[4],
																		   m_objLine1Arr[5]
																	   });
            m_objPrintContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
            #endregion

            #region 给每一行的元素赋值
            string strBlanks = "　　　　　　　　 　　 　　　　　　　";
            if (m_objRecordContent != null)
            {
                Object[] objData1 = new object[4];
                ///////////////1行/////////////////
                objData1[0] = m_objRecordContent.m_strMAINDESCRIPTION;
                objData1[1] = m_objRecordContent.m_strMAINDESCRIPTIONXML;
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　 主诉:";
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////
                objData1[0] = m_objRecordContent.m_strINHOSPITALINSTANCE;
                objData1[1] = m_objRecordContent.m_strINHOSPITALINSTANCEXML;
                objData1[3] = "　 入院情况:";
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////3行/////////////////
                objData1[0] = m_objRecordContent.m_strINHOSPITALDIAGNOSE1;
                objData1[1] = m_objRecordContent.m_strINHOSPITALDIAGNOSE1XML;
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　 入院诊断:";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;
                ///////////////4行/////////////////
                objData1[0] = m_objRecordContent.m_strSALVAGEINSTANCE;
                objData1[1] = m_objRecordContent.m_strSALVAGEINSTANCEXML;
                objData1[3] = "　 抢救经过:";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                ///////////////5行/////////////////
                objData1[0] = m_objRecordContent.m_strDEATHCAUSATION1;
                objData1[1] = m_objRecordContent.m_strDEATHCAUSATION1XML;
                objData1[3] = "　 死亡原因:";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////6行/////////////////
                objData1[0] = m_objRecordContent.m_strDEATHDIAGNOSE1;
                objData1[1] = m_objRecordContent.m_strDEATHDIAGNOSE1XML;
                objData1[3] = "　 死亡诊断:";
                m_objLine1Arr[5].m_ObjPrintLineInfo = objData1;

            }
            else
            {
                Object[] objData1 = new object[4];
                ///////////////1行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　 主诉:";
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　 入院情况:";
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////3行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　 入院诊断:";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;
                ///////////////4行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　 抢救经过:";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                ///////////////5行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　 死亡原因:";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////6行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　 死亡诊断:";
                m_objLine1Arr[5].m_ObjPrintLineInfo = objData1;
            }

            #endregion
        }
        /// <summary>
        /// First page fixed info.
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintBasicInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            string m_strTemp;
            e.Graphics.DrawString("籍贯:" + m_objPrintInfo.m_strNative, m_fotSmallFont, m_slbBrush, 60, 130);
            e.Graphics.DrawString("民族:" + m_objPrintInfo.m_strFolk, m_fotSmallFont, m_slbBrush, 400, 130);
            e.Graphics.DrawString("婚否:" + m_objPrintInfo.m_strIsMarried, m_fotSmallFont, m_slbBrush, 600, 130);
            //2行
            e.Graphics.DrawString("职业:" + m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, 60, 150);
            e.Graphics.DrawString("单位:" + m_objPrintInfo.m_strCompany, m_fotSmallFont, m_slbBrush, 240, 150);
            e.Graphics.DrawString("电话:" + m_objPrintInfo.m_strCompanyPhone, m_fotSmallFont, m_slbBrush, 600, 150);

            //3行
            e.Graphics.DrawString("住址:" + m_objPrintInfo.m_strAddress, m_fotSmallFont, m_slbBrush, 60, 170);
            e.Graphics.DrawString("电话:" + m_objPrintInfo.m_strAddressPhone, m_fotSmallFont, m_slbBrush, 600, 170);

            //4行
            if (m_objRecordContent != null)
            {
                e.Graphics.DrawString("病史陈述者:" + m_objRecordContent.m_strREPRESENTOR, m_fotSmallFont, m_slbBrush, 60, 190);
            }
            else
            {
                e.Graphics.DrawString("病史陈述者:", m_fotSmallFont, m_slbBrush, 60, 190);
            }
            e.Graphics.DrawString("身份证号码:" + m_objPrintInfo.m_strIDCard, m_fotSmallFont, m_slbBrush, 440, 190);


            if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_strTemp = "入院日期: " + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日HH时mm分");
            }
            else
            {
                m_strTemp = "入院日期:     年  月  日  时  分"; ;
            }
            e.Graphics.DrawString(m_strTemp, m_fotSmallFont, m_slbBrush, 60, 210);
            DateTime m_dtmOutHospitalDate = new DateTime(1900, 1, 1);
            m_mthGetSetlectedOutDate(out m_dtmOutHospitalDate);
            if (m_dtmOutHospitalDate != DateTime.MinValue)
            {
                m_strTemp = "出院日期: " + m_dtmOutHospitalDate.ToString("yyyy年MM月dd日HH时mm分");
            }
            else
            {
                m_strTemp = "出院日期:     年  月  日  时  分";
            }
            e.Graphics.DrawString(m_strTemp, m_fotSmallFont, m_slbBrush, 350, 210);

        }
        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("入院２４小时内死亡记录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));


            // e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Department));
            //
            e.Graphics.DrawString("姓名:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));
            
            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area_Title));
            
            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed_Title));
            
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));	



            // e.Graphics.DrawString(m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Occupation));

            //e.Graphics.DrawString("籍贯:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Native_Title));

            //e.Graphics.DrawString(m_objPrintInfo.m_strNative, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Native));

            //e.Graphics.DrawString("民族:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Folk_Title));

            //e.Graphics.DrawString(m_objPrintInfo.m_strFolk, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Folk));

            //e.Graphics.DrawString("婚否:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.IsMarried_Title));

            //e.Graphics.DrawString(m_objPrintInfo.m_strIsMarried, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.IsMarried));

            //e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 177, (int)enmRectangleInfo.RightX, 177);

            //e.Graphics.DrawString("职业:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Occupation_Title));


            //e.Graphics.DrawLine(m_LinePen, 40, 115, 120, 115);
        }
        #endregion
        #region  获取病人出院时间，暂时先在各个窗体查询
        /// <summary>
        /// 获取病人出院时间，暂时先在各个窗体查询
        /// </summary>
        /// <returns></returns>
        private long m_mthGetSetlectedOutDate(out DateTime m_dtmOutHospitalDate)
        {
            m_dtmOutHospitalDate = new DateTime(1900, 1, 1);
            string strRegisterID = "";
            long lngRes = 0;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));


            lngRes = objServ.m_lngGetRegisterIDByPatient(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);

            lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out m_dtmOutHospitalDate);
            objServ = null;
            return lngRes;
        }
        #endregion
        #region print class

        private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objDiagnose;
            private DateTime dtmFirstPrint;
            private string m_strTitle;

            /// <summary>
            /// 主诉
            /// </summary>
            private const int c_intTop1 = 200;
            /// <summary>
            /// 入院情况
            /// </summary>
            private const int c_intTop2 = 300;
            /// <summary>
            /// 入院诊断
            /// </summary>
            private const int c_intTop3 = 430;
            /// <summary>
            /// 抢救经过
            /// </summary>
            private const int c_intTop4 = 560;
            /// <summary>
            /// 死亡原因
            /// </summary>
            private const int c_intTop5 = 690;
            /// <summary>
            /// 死后诊断
            /// </summary>
            private const int c_intTop6 = 720;
            /// <summary>
            /// 一行的高度
            /// </summary>
            private const int c_intOneRowHeight = 25;

            public clsPrintLine1()
            {
                m_objDiagnose = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 12));
            }

            /// <summary>
            /// 格子超出部分偏移量
            /// </summary>
            private static int s_intHeightMargin;
            /// <summary>
            /// 暂存的偏移量
            /// </summary>
            private static int s_intMarginTemp = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                Font fntTitle = new Font("SimSun", 11);
                Pen m_Line1Pen = new Pen(Color.Gray, 0.5f);

                p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 25);

                Rectangle rtgDianose = new Rectangle(
                    (int)enmRectangleInfo.LeftX,
                    p_intPosY,
                    0,
                    0);
                bool blnMiddle = true;

                int intSwitchNumber = 0;
                // 原定固定的高度
                int intPegPosY = 0;

                switch (m_strTitle.Trim())
                {
                    case "主诉:":

                        rtgDianose.X = (int)enmRectangleInfo.LeftX + 30;
                        rtgDianose.X += 30;
                        rtgDianose.Y += 25;
                        // p_objGrp.DrawLine(m_Line1Pen, (int)enmRectangleInfo.LeftX, rtgDianose.Y - 40, (int)enmRectangleInfo.RightX, rtgDianose.Y - 40);
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 30;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop2 - c_intTop1 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop2;
                        break;


                    case "入院情况:":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.X += 50;
                        rtgDianose.Y += 25;
                        // p_objGrp.DrawLine(m_Line1Pen, (int)enmRectangleInfo.LeftX, rtgDianose.Y - 40, (int)enmRectangleInfo.RightX, rtgDianose.Y - 40);
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 50;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop3 - c_intTop2 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop3;
                        break;
                    case "入院诊断:":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.X += 50;
                        rtgDianose.Y += 25;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 50;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop4 - c_intTop3 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop4;
                        break;
                    case "抢救经过:":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.X += 50;
                        rtgDianose.Y += 25;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 50;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop5 - c_intTop4 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop5;
                        break;
                    case "死亡原因:":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.X += 50;
                        rtgDianose.Y += 25;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 50;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop6 - c_intTop5 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop6;

                        break;
                    case "死亡诊断:":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.X += 50;
                        rtgDianose.Y += 25;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X - 50;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((5 * (int)enmRectangleInfo.RowStep - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop5 + 5 * (int)enmRectangleInfo.RowStep;

                        break;
                    default:
                        intSwitchNumber = 3;
                        rtgDianose.X += (int)enmRectangleInfo.LeftX + 50;
                        rtgDianose.Y += 23;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                        blnMiddle = false;
                        rtgDianose.Height = c_intOneRowHeight;
                        intPegPosY = c_intTop1;

                        break;
                }
                int intRealHeight;
                m_objDiagnose.m_blnPrintAllBySimSun(11, rtgDianose, p_objGrp, out intRealHeight, blnMiddle);

                if (intRealHeight > rtgDianose.Height)
                {
                    p_intPosY += intRealHeight + 5;
                }
                else
                {
                    p_intPosY += rtgDianose.Height;
                }
                if (intSwitchNumber == 0) p_intPosY += 27;

                if (p_intPosY > intPegPosY)
                    s_intHeightMargin += p_intPosY - intPegPosY;
                else
                    s_intHeightMargin = 0;

                if (intSwitchNumber == 3)
                {
                    if (s_intHeightMargin < s_intMarginTemp)
                    {
                        p_intPosY += s_intMarginTemp - s_intHeightMargin;
                        s_intHeightMargin = s_intMarginTemp;
                    }
                }

                fntTitle.Dispose();

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objDiagnose.m_mthRestartPrint();
            }

            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        Object[] objData = (object[])value;
                        m_strTitle = objData[3].ToString();
                        dtmFirstPrint = (DateTime)objData[2];
                        if (objData[1].ToString() == "")
                        {
                            m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint);
                        }
                        else
                        {
                            m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint, true);
                            m_mthAddSign2(m_strTitle.Trim(), m_objDiagnose.m_ObjModifyUserArr);
                        }
                        if (m_objDiagnose.m_ObjModifyUserArr != null)
                            for (int i = 0; i < m_objDiagnose.m_ObjModifyUserArr.Length; i++)
                            {
                                if (m_objDiagnose.m_ObjModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    m_objDiagnose.m_ObjModifyUserArr[i].m_clrText = Color.Black;
                            }
                    }
                }
            }
        }
        #endregion

    }
}
