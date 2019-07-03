using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 死亡记录（佛二版）打印类
    /// </summary>
    public class clsDeathrecordPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsDeathRecordDomain m_objRecordsDomain;
        private clsPrintInfo_DeathRecord m_objPrintInfo;
        private clsDeadRecord_VO m_objRecordContent = null;

        public clsDeathrecordPrintTool()
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
            m_objPrintInfo = new clsPrintInfo_DeathRecord();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;

            m_objPrintInfo.m_strNative = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNativePlace : "";//籍贯
            m_objPrintInfo.m_strOccupation = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";//职业
            m_objPrintInfo.m_strIsMarried = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrMarried : "";//婚否
            m_objPrintInfo.m_strFolk = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNation : "";//民族
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
                m_objRecordsDomain = new clsDeathRecordDomain();
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                if (lngRes <= 0)
                    return;
                m_objRecordContent = (clsDeadRecord_VO)objContent;
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
            //if(p_objPrintContent.GetType().Name !="clsPrintInfo_Base")
            //{
            //    clsPublicFunction.ShowInformationMessageBox("参数错误");
            //    return;
            //}
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_DeathRecord)p_objPrintContent;
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
                m_intYPos += (int)enmRectangleInfo.RowStep + 5;
                e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 206, (int)enmRectangleInfo.RightX, 206);
                e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 235, (int)enmRectangleInfo.RightX, 235);
            }

            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.RightX, (int)enmRectangleInfo.TopY);


            while (m_objPrintContext.m_BlnHaveMoreLine)
            {
                m_objPrintContext.m_mthPrintNextLine(ref m_intYPos, e.Graphics, fntNormal);

                if (m_intYPos >= (int)enmRectangleInfo.BottomY
                    && m_objPrintContext.m_BlnHaveMoreLine)
                {


                    #region 换页处理
                    e.HasMorePages = true;

                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.LeftX, m_intYPos);
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.RightX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.RightX, m_intYPos);
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, m_intYPos, (int)enmRectangleInfo.RightX, m_intYPos);

                    m_intPages++;
                    m_intYPos = (int)enmRectangleInfo.TopY + 30;
                    return;

                    #endregion 换页处理
                }

            }

            #region 最后一页处理
            m_intYPos += 30;
            e.Graphics.DrawString("医师签名:", new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 460, m_intYPos);
            if (m_objRecordContent != null)
            {
                com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                clsEmrEmployeeBase_VO objEmpVO = null;
                objEmployeeSign.m_lngGetEmpByNO(m_objRecordContent.m_strDoctorID, out objEmpVO);
                if (objEmpVO != null)
                {
                    Image imgEmpSig = ImageSignature.GetEmpSigImage(objEmpVO.m_strLASTNAME_VCHR);
                    if (imgEmpSig != null)
                    {
                        //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 268);
                        e.Graphics.DrawString(objEmpVO.m_strTechnicalRank, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 540, m_intYPos);
                        e.Graphics.DrawImage(imgEmpSig, (int)enmRectangleInfo.LeftX + 620, m_intYPos - 2, 70, 30);
                    }
                    else
                    {
                        e.Graphics.DrawString(m_objRecordContent.m_strDoctorName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 460 + (int)(5f * 17.5f), m_intYPos);
                    }
               }
            }

            m_intYPos += 25;
            if (m_intYPos < (int)enmRectangleInfo.BottomY)
                m_intYPos = (int)enmRectangleInfo.BottomY;
            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.LeftX, m_intYPos);
            e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.RightX, (int)enmRectangleInfo.TopY, (int)enmRectangleInfo.RightX, m_intYPos);
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
            TopY = 150,
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
                        m_fReturnPoint = new PointF(295f, 60f);
                        break;
                    case (int)enmItemDefination.Department:
                        m_fReturnPoint = new PointF(40f, 97f);
                        break;
                    case (int)enmItemDefination.Department_Title:
                        m_fReturnPoint = new PointF(120f, 100f);
                        break;
                    case (int)enmItemDefination.Area:
                        m_fReturnPoint = new PointF(135f, 97f);
                        break;
                    case (int)enmItemDefination.Area_Title:
                        m_fReturnPoint = new PointF(205f, 100f);
                        break;
                    case (int)enmItemDefination.Bed:
                        m_fReturnPoint = new PointF(230f, 97f);
                        break;
                    case (int)enmItemDefination.Bed_Title:
                        m_fReturnPoint = new PointF(270f, 100f);
                        break;
                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(320f, 100f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(385f, 97f);
                        break;
                    case (int)enmItemDefination.CardiogramID_Title:
                        m_fReturnPoint = new PointF(460f, 100f);
                        break;
                    case (int)enmItemDefination.CardiogramID:
                        m_fReturnPoint = new PointF(540f, 97f);
                        break;
                    case (int)enmItemDefination.XRayID_Title:
                        m_fReturnPoint = new PointF(620f, 100f);
                        break;
                    case (int)enmItemDefination.XRayID:
                        m_fReturnPoint = new PointF(670f, 97f);
                        break;

                    case (int)enmItemDefination.UltrasonicID_Title:
                        m_fReturnPoint = new PointF(40f, 125f);
                        break;
                    case (int)enmItemDefination.UltrasonicID:
                        m_fReturnPoint = new PointF(120f, 122f);
                        break;
                    case (int)enmItemDefination.MRIID_Title:
                        m_fReturnPoint = new PointF(250f, 125f);
                        break;
                    case (int)enmItemDefination.MRIID:
                        m_fReturnPoint = new PointF(300f, 122f);
                        break;
                    case (int)enmItemDefination.BrainID_Title:
                        m_fReturnPoint = new PointF(440f, 125f);
                        break;
                    case (int)enmItemDefination.BrainID:
                        m_fReturnPoint = new PointF(520f, 122f);
                        break;

                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(60f, 157f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(110f, 157f);
                        break;
                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(180f, 157f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(220f, 157f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(250f, 157f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(290f, 157f);
                        break;
                    case (int)enmItemDefination.Occupation_Title:
                        m_fReturnPoint = new PointF(340f, 157f);
                        break;
                    case (int)enmItemDefination.Occupation:
                        m_fReturnPoint = new PointF(380f, 157f);
                        break;
                    case (int)enmItemDefination.Native_Title:
                        m_fReturnPoint = new PointF(442f, 157f);
                        break;
                    case (int)enmItemDefination.Native:
                        m_fReturnPoint = new PointF(482f, 157f);
                        break;
                    case (int)enmItemDefination.Folk_Title:
                        m_fReturnPoint = new PointF(562f, 157f);
                        break;
                    case (int)enmItemDefination.Folk:
                        m_fReturnPoint = new PointF(612f, 157f);
                        break;
                    case (int)enmItemDefination.IsMarried_Title:
                        m_fReturnPoint = new PointF(692f, 157f);
                        break;
                    case (int)enmItemDefination.IsMarried:
                        m_fReturnPoint = new PointF(732f, 157f);
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
										  m_objLine1Arr[5]//,m_objLine1Arr[6]
									  });
            m_objPrintContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
            #endregion

            #region 给每一行的元素赋值
            string strBlanks = "　　　　　　　　 　　 　　　　　　　";
            if (m_objRecordContent != null)
            {
                ///////////////1行/////////////////
                Object[] objData1 = new object[4];
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　入院日期: " + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH:mm") + "　　　　　　" + "死亡日期: " + m_objRecordContent.m_dtmDeadDate.ToString("yyyy年MM月dd日") + "　　　　　　" + "住院日数:" + ((m_objRecordContent.m_dtmDeadDate - m_objRecordContent.m_dtmInPatientDate).Days + 1).ToString() + " 天";
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////
                objData1[0] = m_objRecordContent.m_strOperationName;
                objData1[1] = m_objRecordContent.m_strOperationNameXML;
                objData1[2] = dtmFirstPrintTime;
                if(string.IsNullOrEmpty(m_objRecordContent.m_strOperationName))
                    objData1[3] = "　手术名称:" + " 　　　　　　　　　　　　　　　　　　　　　　              " + "手术日期:" + "    年  月  日";
                else
                    objData1[3] = "　手术名称:" + " 　　　　　　　　　　　　　　　　　　　　　　              " + "手术日期:" +m_objRecordContent.m_dtmOperationDate.ToString("yyyy年MM月dd日");
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;

                ///////////////3行/////////////////
                objData1[0] = m_objRecordContent.m_strInHospitalDiagnose;
                objData1[1] = m_objRecordContent.m_strInHospitalDiagnoseXML;
                objData1[3] = "　入院诊断:";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;
                ///////////////4行/////////////////
                objData1[0] = m_objRecordContent.m_strInHospitalProcess;
                objData1[1] = m_objRecordContent.m_strInHospitalProcessXML;
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　住院经过:    (包括入院时主要病史及症状体征，有诊断意见的化验及器械检查结果，住院期间病情\n    　          变化、检查及治疗经过)";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                ///////////////5行/////////////////
                objData1[0] = m_objRecordContent.m_strDeadProcess;
                objData1[1] = m_objRecordContent.m_strDeadProcessXML;
                objData1[3] = "　死亡经过:    (抢救经过、死亡时间、死亡原因)";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////6行/////////////////
                objData1[0] = m_objRecordContent.m_strDeadDiagnose;
                objData1[1] = m_objRecordContent.m_strDeadDiagnoseXML;
                objData1[3] = "　死后诊断:    (包括病理诊断、尸解结果)";
                m_objLine1Arr[5].m_ObjPrintLineInfo = objData1;
                ///////////////7行/////////////////
                //objData1[0] = m_objRecordContent.m_strDeadVerdict;
                //objData1[1] = m_objRecordContent.m_strDeadVerdictXML;
                //objData1[3] = "　死亡讨论结论:";
                //m_objLine1Arr[6].m_ObjPrintLineInfo = objData1;

            }
            else
            {
                ///////////////1行/////////////////
                Object[] objData1 = new object[4];
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    objData1[3] = "　入院日期: " + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH:mm") + "　　　　　　" + "死亡日期: " + "    年  月  日" + "　　　　　　" + "住院日数:";
                }
                else
                {
                    objData1[3] = "　入院日期: " + "    年  月  日   :  " + "　　　　　　" + "死亡日期: " + "    年  月  日" + "　　　　　　" + "住院日数:";
                }
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////				
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　手术名称:" + " 　　　　　　　　　　　　　　　　　　　　　　              " + "手术日期:" + "    年  月  日";
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;

                ///////////////3行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　入院诊断:";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;
                ///////////////4行/////////////////	
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "　住院经过:    (包括入院时主要病史及症状体征，有诊断意见的化验及器械检查结果，住院期间病情\n    　          变化、检查及治疗经过)";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                ///////////////5行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　死亡经过:    (抢救经过、死亡时间、死亡原因)";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////6行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "　死后诊断:    (包括病理诊断、尸解结果)";
                m_objLine1Arr[5].m_ObjPrintLineInfo = objData1;
                ///////////////7行/////////////////
                //objData1[0] = "";
                //objData1[1] = "";
                //objData1[3] = "　死亡讨论结论:";
                //m_objLine1Arr[6].m_ObjPrintLineInfo = objData1;
            }

            #endregion
        }

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("死   亡   记   录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawLine(m_LinePen, 40, 115, 120, 115);
            e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Department));

            e.Graphics.DrawString("科", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Department_Title));

            e.Graphics.DrawLine(m_LinePen, 135, 115, 205, 115);
            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area));

            e.Graphics.DrawString("房", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area_Title));

            e.Graphics.DrawLine(m_LinePen, 230, 115, 270, 115);
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed));

            e.Graphics.DrawString("床", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed_Title));

            e.Graphics.DrawString("住院号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));

            e.Graphics.DrawLine(m_LinePen, 385, 115, 455, 115);
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

            e.Graphics.DrawString("心电图号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.CardiogramID_Title));
            e.Graphics.DrawLine(m_LinePen, 540, 115, 615, 115);
            if (m_objPrintInfo.m_objRecordContent != null)
                e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strCardiogramID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.CardiogramID));

            e.Graphics.DrawString("X光号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.XRayID_Title));
            e.Graphics.DrawLine(m_LinePen, 670, 115, 740, 115);
            if (m_objPrintInfo.m_objRecordContent != null)
                e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strXRayID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.XRayID));

            e.Graphics.DrawString("超声波号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.UltrasonicID_Title));
            e.Graphics.DrawLine(m_LinePen, 120, 140, 245, 140);
            if (m_objPrintInfo.m_objRecordContent != null)
                e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strUltrasonicID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.UltrasonicID));

            e.Graphics.DrawString("MRI号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.MRIID_Title));
            e.Graphics.DrawLine(m_LinePen, 300, 140, 435, 140);
            if (m_objPrintInfo.m_objRecordContent != null)
                e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strMRIID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.MRIID));

            e.Graphics.DrawString("脑电波号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BrainID_Title));
            e.Graphics.DrawLine(m_LinePen, 520, 140, 615, 140);
            if (m_objPrintInfo.m_objRecordContent != null)
                e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strBrainWaveID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BrainID));

            e.Graphics.DrawString("姓名:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("职业:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Occupation_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strOccupation, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Occupation));

            e.Graphics.DrawString("籍贯:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Native_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strNative, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Native));

            e.Graphics.DrawString("民族:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Folk_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strFolk, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Folk));

            e.Graphics.DrawString("婚否:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.IsMarried_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strIsMarried, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.IsMarried));
            e.Graphics.DrawLine(m_LinePen, (int)enmRectangleInfo.LeftX, 177, (int)enmRectangleInfo.RightX, 177);

        }
        #endregion

        #region print class

        private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objDiagnose;
            private DateTime dtmFirstPrint;
            private string m_strTitle;

            /// <summary>
            /// 日期
            /// </summary>
            private const int c_intTop1 = 180;
            /// <summary>
            /// 手术名称、日期
            /// </summary>
            private const int c_intTop2 = 210;
            /// <summary>
            /// 入院诊断
            /// </summary>
            private const int c_intTop3 = 243;
            /// <summary>
            /// 住院经过
            /// </summary>
            private const int c_intTop4 = 380;
            /// <summary>
            /// 死亡经过
            /// </summary>
            private const int c_intTop5 = 570;
            /// <summary>
            /// 死后诊断
            /// </summary>
            private const int c_intTop6 = 670;
            /// <summary>
            /// 死亡讨论结论
            /// </summary>
            private const int c_intTop7 = 770;
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

                p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 5);

                Rectangle rtgDianose = new Rectangle(
                    (int)enmRectangleInfo.LeftX,
                    p_intPosY,
                    0,
                    0);
                bool blnMiddle = true;

                int intSwitchNumber = 0;
                // 原定固定的高度
                int intPegPosY = 0;

                switch (m_strTitle)
                {
                    case "　入院诊断:":

                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.Y += 30;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop4 - c_intTop3 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;

                        }
                        intPegPosY = c_intTop4;

                        break;
                    case "　住院经过:    (包括入院时主要病史及症状体征，有诊断意见的化验及器械检查结果，住院期间病情\n    　          变化、检查及治疗经过)":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.Y += 37;
                        p_objGrp.DrawLine(m_Line1Pen, (int)enmRectangleInfo.LeftX, rtgDianose.Y - 40, (int)enmRectangleInfo.RightX, rtgDianose.Y - 40);
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop5 - c_intTop4 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop5;
                        break;
                    case "　死亡经过:    (抢救经过、死亡时间、死亡原因)":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.Y += 30;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop6 - c_intTop5 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop6;
                        break;
                    case "　死后诊断:    (包括病理诊断、尸解结果)":
                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
                        rtgDianose.Y += 30;
                        rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                        blnMiddle = false;
                        if ((rtgDianose.Height = ((c_intTop7 - c_intTop6 - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                        {
                            if (rtgDianose.Height < 0)
                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
                            rtgDianose.Height = c_intOneRowHeight;
                        }
                        intPegPosY = c_intTop7;
                        break;
                    //case "　死亡讨论结论:":
                    //    rtgDianose.X += (int)enmRectangleInfo.LeftX;
                    //    rtgDianose.Y += 30;
                    //    rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                    //    blnMiddle = false;
                    //    if ((rtgDianose.Height = ((5 * (int)enmRectangleInfo.RowStep - 40) - s_intHeightMargin)) < c_intOneRowHeight)
                    //    {
                    //        if (rtgDianose.Height < 0)
                    //            s_intHeightMargin = Math.Abs(rtgDianose.Height);
                    //        rtgDianose.Height = c_intOneRowHeight;
                    //    }
                    //    intPegPosY = c_intTop7 + 5 * (int)enmRectangleInfo.RowStep;
                    //    break;
                    default:
                        if (m_strTitle.StartsWith("　入院日期:"))
                        {
                            rtgDianose.X += (int)enmRectangleInfo.LeftX;
                            rtgDianose.Y += 30;
                            rtgDianose.Width = 200;
                            blnMiddle = false;
                        }
                        else
                        {
                            intSwitchNumber = 3;
                            rtgDianose.X += (int)enmRectangleInfo.LeftX + 50;
                            rtgDianose.Y += 3;
                            rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
                            blnMiddle = false;
                            rtgDianose.Height = c_intOneRowHeight;
                            intPegPosY = c_intTop3;
                        }
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

                //				if(intSwitchNumber == 2)
                //				{
                //					s_intMarginTemp = s_intHeightMargin;
                //					s_intHeightMargin = 0;
                //					if(intRealHeight > rtgDianose.Height)
                //						p_intPosY -= (intRealHeight + 5);
                //					else
                //						p_intPosY -=  rtgDianose.Height;
                //				}
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
