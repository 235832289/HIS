using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 术前讨论记录---新疆的打印工具类
    /// </summary>
    public class clsBeforeOperationDiscussPrintTool_xj : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        private clsDiseaseTrackDomain m_objRecordsDomain;
        private clsPrintInfo_BeforeOperationDiscuss_xj m_objPrintInfo;
        private clsBeforeOperationDiscussContent_xj m_objRecordContent = null;
        private DateTime m_dtmOutDate = DateTime.MinValue;

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
            m_objPrintInfo = new clsPrintInfo_BeforeOperationDiscuss_xj();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";

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
                m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.BeforeOperationDiscuss_xj);
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                if (lngRes <= 0)
                    return;
                m_objRecordContent = (clsBeforeOperationDiscussContent_xj)objContent;
            }
            //if (m_objRecordContent != null)
            //    m_objRecordContent.m_dtmOutHospitalDate = m_dtmOutDate;
            //设置表单内容到打印中			
            m_objPrintInfo.m_objRecordContent = m_objRecordContent;
            m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.			
        }

        public void m_mthSetOutDateValue(DateTime p_dtmOutDate)
        {
            m_dtmOutDate = p_dtmOutDate;
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {


            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_BeforeOperationDiscuss_xj")
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误");
                return;
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_BeforeOperationDiscuss_xj)p_objPrintContent;
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
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), dtmFirstPrintTime);//蔡沐忠改m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate);	
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
                m_intYPos += (int)enmRectangleInfo.RowStep - 20;
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
                    m_intYPos = (int)enmRectangleInfo.TopY + 10;

                    clsPrintLine2.m_blnSinglePage = false;
                    return;

                    #endregion 换页处理
                }

            }

            #region 最后一页处理
            m_intYPos += 30;

            //string strRecordName = "                 ";
            //string strGuanChangName = "";
            //string strZhuRenName = "";
            //if (m_objRecordContent != null)
            //{
            //    com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //    clsEmrEmployeeBase_VO objEmpVO = null;
            //    objEmployeeSign.m_lngGetEmpByNO(m_objRecordContent.m_strRecordID, out objEmpVO);
            //    if (objEmpVO != null)
            //        strRecordName = objEmpVO.ToString();
            //    objEmployeeSign.m_lngGetEmpByNO(m_objRecordContent.m_strGuanChuangID, out objEmpVO);
            //    if (objEmpVO != null)
            //        strGuanChangName = objEmpVO.ToString();
            //    objEmployeeSign.m_lngGetEmpByNO(m_objRecordContent.m_strZhuRenID, out objEmpVO);
            //    if (objEmpVO != null)
            //        strZhuRenName = objEmpVO.ToString();
            //}
            //e.Graphics.DrawString("记录者:" + strRecordName + " 管床医师:" + strGuanChangName + " 科主任:" + strZhuRenName + " " + m_objRecordContent.m_dtmDiscussDate.ToString("yyyy-MM-dd"), new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX, m_intYPos);
            e.Graphics.DrawString("记录日期:" + m_objRecordContent.m_dtmDiscussDate.ToString("yyyy-MM-dd"), new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX, m_intYPos);
            //			m_intYPos+=25;
            //			e.Graphics.DrawString("工　　号:",new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560,m_intYPos);
            //			if(m_objRecordContent!=null)
            //				e.Graphics.DrawString(m_objRecordContent.m_strDoctorID,new Font("SimSun",12) ,Brushes.Black,(int)enmRectangleInfo.LeftX+560+(int)(5f*17.5f),m_intYPos);
            /////////////////////////////////*******************************************
            m_intYPos += 50;
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
            clsPrintLine2.m_blnSinglePage = true;
        }


        #region 打印
        #region 有关打印的声明

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
        private int m_intYPos = (int)enmRectangleInfo.TopY + 5;
        private int m_intPages = 1;

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端TopY = 120,
            /// </summary>
            TopY = 160,
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

            BottomY = 1024,

            PrintWidth = 670,
            PrintWidth2 = 710
        }

        /// <summary>
        /// 打印元素
        /// </summary>
        private enum enmItemDefination
        {
            //基本元素
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
            YiBao_title,
            YiBao,
            //HeartID_Title,
            //HeartID,
            //XRayID_Title,
            //XRayID,

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
                    case (int)enmItemDefination.Area:
                        m_fReturnPoint = new PointF(370f, 140f);
                        break;
                    case (int)enmItemDefination.Area_Title:
                        m_fReturnPoint = new PointF(330f, 140f);
                        break;
                    case (int)enmItemDefination.Bed:
                        m_fReturnPoint = new PointF(510f, 137f);
                        break;
                    case (int)enmItemDefination.Bed_Title:
                        m_fReturnPoint = new PointF(470f, 140f);
                        break;
                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(320f, 70f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(290f, 100f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(30f, 140f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(75f, 140f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(155f, 140f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(200f, 140f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(225f, 140f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(270f, 140f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(540f, 140f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(600f, 140f);
                        break;

                    case (int)enmItemDefination.YiBao_title:
                        m_fReturnPoint = new PointF(645f, 140f);
                        break;
                    case (int)enmItemDefination.YiBao:
                        m_fReturnPoint = new PointF(700f, 140f);
                        break;

                    //case (int)enmItemDefination.HeartID_Title:
                    //    m_fReturnPoint = new PointF(60f, 155f);
                    //    break;
                    //case (int)enmItemDefination.HeartID:
                    //    m_fReturnPoint = new PointF(145f, 153f);
                    //    break;

                    //case (int)enmItemDefination.XRayID_Title:
                    //    m_fReturnPoint = new PointF(220f, 155f);
                    //    break;
                    //case (int)enmItemDefination.XRayID:
                    //    m_fReturnPoint = new PointF(280f, 153f);
                    //    break;

                    default:
                        m_fReturnPoint = new PointF(400f, 440f);
                        break;

                }

                return m_fReturnPoint;
            }
        }

        #endregion
        #endregion

        #region 打印行定义
        private clsPrintLine1[] m_objLine1Arr;
        private clsPrintLine2[] m_objLine2Arr;
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
            m_objLine1Arr = new clsPrintLine1[5];
            m_objLine2Arr = new clsPrintLine2[3];
            for (int i = 0; i < m_objLine1Arr.Length; i++)
                m_objLine1Arr[i] = new clsPrintLine1();


            m_objLine2Arr[0] = new clsPrintLine2(20);
            m_objLine2Arr[1] = new clsPrintLine2(360);
            m_objLine2Arr[2] = new clsPrintLine2(420);
            //     m_objLine2Arr[3] = new clsPrintLine2(790);
            m_objPrintContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										 m_objLine1Arr[2],m_objLine1Arr[3], m_objLine1Arr[4],m_objLine1Arr[1],
                                         m_objLine2Arr[0], m_objLine2Arr[1],m_objLine2Arr[2]
									  });
            m_objPrintContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();
            #endregion

            #region 给每一行的元素赋值
            string strBlanks = "　　　　　　　　　　　　";
            if (m_objRecordContent != null)
            {
                ///////////////1行/////////////////
                string strOutDate = "";
                //if (m_objRecordContent.m_dtmOutHospitalDate != DateTime.MinValue
                //    && m_objRecordContent.m_dtmOutHospitalDate != new DateTime(1900, 1, 1))
                //    strOutDate = m_objRecordContent.m_dtmOutHospitalDate.ToString("yyyy年MM月dd日");
                Object[] objData1 = new object[5];
                objData1[0] = m_objRecordContent.m_strNiZheng;
                objData1[1] = m_objRecordContent.m_strNiZhengXML;
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "术前准备情况: "; //+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日") + "　　　　　　　　　　　" + "出院日期: " + strOutDate;
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////
                objData1[0] = "    ";
                foreach (string str in m_objRecordContent.m_strAttendeeIDArr)
                {
                    com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                    clsEmrEmployeeBase_VO objEmpVO = null;
                    objEmployeeSign.m_lngGetEmpByNO(str, out objEmpVO);
                    //if (objEmpVO != null)
                    //    if (!(string.IsNullOrEmpty(objEmpVO.m_strGetTechnicalRankAndName)))
                    //        e.Graphics.DrawString(objEmpVO.m_strGetTechnicalRankAndName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 500 + (int)(5f * 15.5f), m_intYPos);

                    objData1[0] += objEmpVO.m_strGetTechnicalRankAndName + "　";
                }
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "参加人员：";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;
                //////////////////////////////
                objData1[0] = "    ";
                com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign1 = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                clsEmrEmployeeBase_VO objEmpVO1 = null;
                objEmployeeSign1.m_lngGetEmpByNO(m_objRecordContent.m_strCompereID, out objEmpVO1);
                //if (objEmpVO != null)
                //    if (!(string.IsNullOrEmpty(objEmpVO.m_strGetTechnicalRankAndName)))
                //        e.Graphics.DrawString(objEmpVO.m_strGetTechnicalRankAndName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 500 + (int)(5f * 15.5f), m_intYPos);

                objData1[0] += objEmpVO1.m_strGetTechnicalRankAndName + "　";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "主持人：";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                //////////////////////////////
                objData1[0] = "    ";
                com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign2 = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                clsEmrEmployeeBase_VO objEmpVO2 = null;
                objEmployeeSign2.m_lngGetEmpByNO(m_objRecordContent.m_strHuiBaoID, out objEmpVO2);
                //if (objEmpVO != null)
                //    if (!(string.IsNullOrEmpty(objEmpVO.m_strGetTechnicalRankAndName)))
                //        e.Graphics.DrawString(objEmpVO.m_strGetTechnicalRankAndName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 500 + (int)(5f * 15.5f), m_intYPos);

                objData1[0] += objEmpVO2.m_strGetTechnicalRankAndName + "　";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "病史汇报者：";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;


                /////////////////3行/////////////////
                //objData1[0] = m_objRecordContent.m_strOutHospitalDiagnose;
                //objData1[1] = m_objRecordContent.m_strOutHospitalDiagnoseXML;
                //objData1[3] = "中医出院诊断:";
                //m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////////////////////////////
                //objData1[0] = m_objRecordContent.m_strOutHospitalDiagnoseXi;
                //objData1[1] = m_objRecordContent.m_strOutHospitalDiagnoseXiXML;
                //objData1[3] = "西医出院诊断:";
                //m_objLine1Arr[5].m_ObjPrintLineInfo = objData1;
                /////////////////4行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;

                ///////////////5行/////////////////
                objData1[0] = m_objRecordContent.m_strTaoLunYiJian;
                objData1[1] = m_objRecordContent.m_strTaoLunYiJianXML;
                objData1[3] = "手术指征及禁忌症:";
                m_objLine2Arr[0].m_ObjPrintLineInfo = objData1;

                objData1[0] = m_objRecordContent.m_strTaoLunXiaoJie;
                objData1[1] = m_objRecordContent.m_strTaoLunXiaoJieXML;
                objData1[3] = "手术方案:";
                m_objLine2Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////8行/////////////////			
                objData1[0] = m_objRecordContent.m_strHuiBao;
                objData1[1] = m_objRecordContent.m_strHuiBaoXML;
                objData1[3] = "可能出现的以外及防范措施:";
                m_objLine2Arr[2].m_ObjPrintLineInfo = objData1;

            }
            else
            {
                ///////////////1行/////////////////
                Object[] objData1 = new object[5];
                //objData1[0] = "";
                //objData1[1] = "";
                //objData1[2] = dtmFirstPrintTime;
                //if (m_objPrintInfo.m_dtmHISInDate != DateTime.MinValue)
                //{
                //    objData1[3] = "入院日期:" + m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日") + "　　　　　　　　　　　" + "出院日期:" + "    年  月  日";
                //}
                //else
                //{
                //    objData1[3] = "入院日期:" + "    年  月  日" + "　　　　　　　　　　　" + "出院日期:" + "    年  月  日";
                //}
                //m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;

                ///////////////2行/////////////////				
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "术前准备情况:";
                m_objLine1Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                objData1[3] = "参加人员:";
                m_objLine1Arr[2].m_ObjPrintLineInfo = objData1;

                ///////////////3行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "主持人:";
                m_objLine1Arr[3].m_ObjPrintLineInfo = objData1;
                //////////////////////////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "病史汇报者:";
                m_objLine1Arr[4].m_ObjPrintLineInfo = objData1;
                ///////////////4行/////////////////	
                objData1[0] = "";
                objData1[1] = "";
                objData1[2] = dtmFirstPrintTime;
                //   objData1[3] = "  心电图号:" + strBlanks + "X光号:" + strBlanks;// +"主治医师:";
                m_objLine1Arr[0].m_ObjPrintLineInfo = objData1;
                ///////////////5行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "手术指征及禁忌症:";
                m_objLine2Arr[0].m_ObjPrintLineInfo = objData1;
                ///////////////6行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                //if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
                //{
                //    objData1[3] = "　诊疗经过:";
                //}
                //else
                //{
                //    objData1[3] = "　诊疗经过:(重点记录病情演变主要用药及辅助检查主要发现)";
                //}
                //m_objLine2Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////7行/////////////////
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "手术方案:";
                m_objLine2Arr[1].m_ObjPrintLineInfo = objData1;
                ///////////////8行/////////////////			
                objData1[0] = "";
                objData1[1] = "";
                objData1[3] = "可能出现的以外及防范措施:";
                m_objLine2Arr[2].m_ObjPrintLineInfo = objData1;

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

            e.Graphics.DrawString("术前讨论记录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawString("姓名:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("病区:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Area));

            e.Graphics.DrawString("床号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Bed));

            e.Graphics.DrawString("住院号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

            e.Graphics.DrawString("医保号:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.YiBao_title));
            e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strYiBao, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.YiBao));

            //e.Graphics.DrawString("心电图号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.HeartID_Title));
            //if (m_objPrintInfo.m_objRecordContent != null)
            //    e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strHeartID_Right, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.HeartID));

            //e.Graphics.DrawString("X光号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.XRayID_Title));
            //if (m_objPrintInfo.m_objRecordContent != null)
            //e.Graphics.DrawString(m_objPrintInfo.m_objRecordContent.m_strXRayID_Right, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.XRayID));	
        }


        #endregion

        #region print class

        #region
        //private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private clsPrintRichTextContext m_objDiagnose;
        //    private DateTime dtmFirstPrint;
        //    //			private bool m_blnFirstPrint = true;
        //    private string m_strTitle;

        //    #region
        //    /// <summary>
        //    /// 日期
        //    /// </summary>
        //    private const int c_intTop1 = 195;
        //    /// <summary>
        //    /// 诊断中
        //    /// </summary>
        //    private const int c_intTop2 = 245;
        //    /// <summary>
        //    /// 诊断西
        //    /// </summary>
        //    private const int c_intTop3 = 295;
        //    /// <summary>
        //    /// 入院情况
        //    /// </summary>
        //    private const int c_intTop4 = 345;
        //    /// <summary>
        //    /// 诊疗经过
        //    /// </summary>
        //    private const int c_intTop5 = 540;
        //    /// <summary>
        //    /// 出院情况
        //    /// </summary>
        //    private const int c_intTop6 = 700;
        //    /// <summary>
        //    /// 出院医瞩
        //    /// </summary>
        //    private const int c_intTop7 = 830;
        //    /// <summary>
        //    /// 一行的高度
        //    /// </summary>
        //    private const int c_intOneRowHeight = 30;

        //    #endregion

        //    public clsPrintLine1()
        //    {
        //        m_objDiagnose = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 12));
        //    }

        //    //			private int m_intTimes = 0;

        //    /// <summary>
        //    /// 格子超出部分偏移量
        //    /// </summary>
        //    private static int s_intHeightMargin;
        //    /// <summary>
        //    /// 暂存的偏移量
        //    /// </summary>
        //    private static int s_intMarginTemp = 0;

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        Font fntTitle = new Font("SimSun", 11);

        //        //if (m_strTitle != "　出院诊断:")
        //        //{
        //            p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY+ 5);
        //        //}
        //        //else
        //        //{
        //        //    p_objGrp.DrawString(m_strTitle, fntTitle, Brushes.Black, (int)enmRectangleInfo.LeftX + 363, p_intPosY -30);//
        //        //}
        //        p_intPosY += 10;
        //        Rectangle rtgDianose = new Rectangle(
        //            (int)enmRectangleInfo.LeftX,
        //            p_intPosY,
        //            0,
        //            0);
        //        bool blnMiddle = true;

        //        int intSwitchNumber = 0;
        //        // 原定固定的高度
        //        int intPegPosY = 0;


        //        #region
        //        switch (m_strTitle)
        //        {
        //            case "　入院诊断:":
        //                intSwitchNumber = 2;
        //                rtgDianose.X += 95;
        //                rtgDianose.Height = 80;
        //                rtgDianose.Width = (int)enmRectangleInfo.LeftX + 370 - rtgDianose.X;
        //                intPegPosY = 285;
        //                //						rtgDianose.X += 95;
        //                //						rtgDianose.Y -= 30
        //                //						rtgDianose.Height = 80;
        //                //						rtgDianose.Width = (int)enmRectangleInfo.LeftX+370-rtgDianose.X;
        //                //						p_intPosY = c_intTop2;
        //                break;
        //            case "　出院诊断:":
        //                intSwitchNumber = 3;
        //                rtgDianose.X += 452;
        //                rtgDianose.Height = 80;
        //                rtgDianose.Width = (int)enmRectangleInfo.RightX - rtgDianose.X;
        //                intPegPosY = 285;
        //                //						rtgDianose.X += 452;
        //                //						rtgDianose.Y -= 30
        //                //						rtgDianose.Height = 80;
        //                //						rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //                //						p_intPosY = c_intTop3;
        //                break;
        //            //                    case "　入院情况:":
        //            //                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            //                        rtgDianose.Y += 30;
        //            //                        rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            //                        blnMiddle = false;
        //            //                        if((rtgDianose.Height =((c_intTop5-c_intTop4-40) - s_intHeightMargin)) < c_intOneRowHeight)
        //            //                        {
        //            //                            if (rtgDianose.Height < 0)
        //            //                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
        //            //                            rtgDianose.Height = c_intOneRowHeight;
        //            //                        }
        //            //                        intPegPosY = c_intTop5;
        //            ////						rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            ////						rtgDianose.Y += 30;
        //            ////						rtgDianose.Height = c_intTop5-c_intTop4-40;
        //            ////						rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            ////						blnMiddle = false;
        //            ////						p_intPosY = c_intTop5;
        //            //                        break;
        //            //                    case "　诊疗经过:(重点记录病情演变主要用药及辅助检查主要发现)":
        //            //                    case "　诊疗经过:":
        //            //                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            //                        rtgDianose.Y += 30;
        //            //                        rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            //                        blnMiddle = false;
        //            //                        if((rtgDianose.Height =((c_intTop6-c_intTop5-40) - s_intHeightMargin)) < c_intOneRowHeight)
        //            //                        {
        //            //                            if (rtgDianose.Height < 0)
        //            //                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
        //            //                            rtgDianose.Height = c_intOneRowHeight;
        //            //                        }
        //            //                        intPegPosY = c_intTop6;
        //            ////						rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            ////						rtgDianose.Y += 30;
        //            ////						rtgDianose.Height = c_intTop6-c_intTop5-40;
        //            ////						rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            ////						blnMiddle = false;
        //            ////						p_intPosY = c_intTop6;
        //            //                        break;
        //            //                    case "　出院情况:":
        //            //                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            //                        rtgDianose.Y += 30;
        //            //                        rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            //                        blnMiddle = false;
        //            //                        if((rtgDianose.Height =((c_intTop7-c_intTop6-40) - s_intHeightMargin)) < c_intOneRowHeight)
        //            //                        {
        //            //                            if (rtgDianose.Height < 0)
        //            //                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
        //            //                            rtgDianose.Height = c_intOneRowHeight;
        //            //                        }
        //            //                        intPegPosY = c_intTop7;
        //            ////						rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            ////						rtgDianose.Y += 30;
        //            ////						rtgDianose.Height = c_intTop7-c_intTop6-40;
        //            ////						rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            ////						blnMiddle = false;
        //            ////						p_intPosY = c_intTop7;
        //            //                        break;
        //            //                    case "　出院医嘱:":
        //            //                        rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            //                        rtgDianose.Y += 30;
        //            //                        rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            //                        blnMiddle = false;
        //            //                        if((rtgDianose.Height =((5*(int)enmRectangleInfo.RowStep-40) - s_intHeightMargin)) < c_intOneRowHeight)
        //            //                        {
        //            //                            if (rtgDianose.Height < 0)
        //            //                                s_intHeightMargin = Math.Abs(rtgDianose.Height);
        //            //                            rtgDianose.Height = c_intOneRowHeight;
        //            //                        }
        //            //                        intPegPosY = c_intTop7 + 5*(int)enmRectangleInfo.RowStep;
        //            ////						rtgDianose.X += (int)enmRectangleInfo.LeftX;
        //            ////						rtgDianose.Y += 30;
        //            ////						rtgDianose.Height = 5*(int)enmRectangleInfo.RowStep-40;
        //            ////						rtgDianose.Width = (int)enmRectangleInfo.RightX-rtgDianose.X;
        //            ////						blnMiddle = false;
        //            ////						p_intPosY +=5*(int)enmRectangleInfo.RowStep;
        //            //                        break;
        //            default:
        //                if (m_strTitle.StartsWith("　入院日期:"))
        //                {
        //                    p_intPosY = c_intTop2;
        //                    intSwitchNumber = 1;
        //                    intPegPosY = c_intTop2;
        //                }
        //                else
        //                {
        //                    //							p_intPosY = c_intTop4;
        //                    intPegPosY = c_intTop4;
        //                }
        //                break;
        //        }

        //        #endregion

        //        int intRealHeight;
        //        m_objDiagnose.m_blnPrintAllBySimSun(11, rtgDianose, p_objGrp, out intRealHeight, blnMiddle);

        //        if (intRealHeight > rtgDianose.Height)
        //        {
        //            p_intPosY += intRealHeight + 5;
        //        }
        //        else
        //        {
        //            p_intPosY += rtgDianose.Height;
        //        }
        //        if (intSwitchNumber == 0) p_intPosY += 40;

        //        if (p_intPosY > intPegPosY)
        //            s_intHeightMargin += p_intPosY - intPegPosY;
        //        else
        //            s_intHeightMargin = 0;

        //        if (intSwitchNumber == 2)
        //        {
        //            s_intMarginTemp = s_intHeightMargin;
        //            s_intHeightMargin = 0;
        //            if (intRealHeight > rtgDianose.Height)
        //                p_intPosY -= (intRealHeight + 5);
        //            else
        //                p_intPosY -= rtgDianose.Height;
        //        }
        //        if (intSwitchNumber == 3)
        //        {
        //            if (s_intHeightMargin < s_intMarginTemp)
        //            {
        //                p_intPosY += s_intMarginTemp - s_intHeightMargin;
        //                s_intHeightMargin = s_intMarginTemp;
        //            }
        //        }


        //        //if (m_objDiagnose.m_BlnHaveNextLine())
        //        //{
        //        //    m_objDiagnose.m_mthPrintLine((int)enmRectangleInfo.PrintWidth2 - 5, (int)enmRectangleInfo.LeftX + 40, p_intPosY, p_objGrp);
        //        //    p_intPosY += 20;
        //        //}

        //        //if (m_objDiagnose.m_BlnHaveNextLine())
        //        //    m_blnHaveMoreLine = true;
        //        //else
        //        //{
        //        //    m_blnHaveMoreLine = false;
        //        //}



        //        fntTitle.Dispose();

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        //				m_intTimes = 0;
        //        m_blnHaveMoreLine = true;
        //        //				m_blnFirstPrint = true;
        //        m_objDiagnose.m_mthRestartPrint();
        //    }

        //    public override object m_ObjPrintLineInfo
        //    {
        //        get
        //        {
        //            return m_objPrintLineInfo;
        //        }
        //        set
        //        {
        //            if (value != null)
        //            {
        //                Object[] objData = (object[])value;
        //                m_strTitle = objData[3].ToString();
        //                dtmFirstPrint = (DateTime)objData[2];
        //                if (clsOutHospital_XJPrintTool.m_blnIsPrintMark)
        //                {
        //                    if (objData[1].ToString() == "")
        //                    {
        //                        m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint);
        //                    }
        //                    else
        //                    {
        //                        m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint, true);
        //                        m_mthAddSign2(m_strTitle.Trim(), m_objDiagnose.m_ObjModifyUserArr);
        //                    }
        //                }
        //                else
        //                {
        //                    m_objDiagnose.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
        //                }
        //                if (m_objDiagnose.m_ObjModifyUserArr != null)
        //                    for (int i = 0; i < m_objDiagnose.m_ObjModifyUserArr.Length; i++)
        //                    {
        //                        if (m_objDiagnose.m_ObjModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
        //                            m_objDiagnose.m_ObjModifyUserArr[i].m_clrText = Color.Black;
        //                    }
        //            }
        //        }
        //    }
        //}
        #endregion

        private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objDiagnose;
            private DateTime dtmFirstPrint;
            private bool m_blnIsFirstPrint = true;
            private string m_strTitle;

            /// <summary>
            /// 默认值
            /// </summary>
            private readonly int c_intTop4 = 20;

            internal static bool m_blnSinglePage = true;

            public clsPrintLine1()
            {
                // c_intTop4 = intTop4;
                m_objDiagnose = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 12));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (p_intPosY < c_intTop4 && m_blnSinglePage)
                        p_intPosY = c_intTop4;
                    p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX+5, p_intPosY);
                    p_intPosY += 20;
                    m_blnIsFirstPrint = false;
                }

                if (m_objDiagnose.m_BlnHaveNextLine())
                {
                    m_objDiagnose.m_mthPrintLine((int)enmRectangleInfo.PrintWidth2 - 5, (int)enmRectangleInfo.LeftX + 45, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }

                if (m_objDiagnose.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
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
                        if (clsDifficultCaseDiscuss_XJPrintTool.m_blnIsPrintMark)
                        {
                            if (objData[1].ToString() == "")
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint);
                            }
                            else
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint, true);
                                m_mthAddSign2(m_strTitle.Trim(), m_objDiagnose.m_ObjModifyUserArr);
                            }
                        }
                        else
                        {
                            m_objDiagnose.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                        }
                        if (m_objDiagnose.m_ObjModifyUserArr != null)
                        {
                            for (int i = 0; i < m_objDiagnose.m_ObjModifyUserArr.Length; i++)
                            {
                                if (m_objDiagnose.m_ObjModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    m_objDiagnose.m_ObjModifyUserArr[i].m_clrText = Color.Black;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region 2
        private class clsPrintLine2 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objDiagnose;
            private DateTime dtmFirstPrint;
            private bool m_blnIsFirstPrint = true;
            private string m_strTitle;

            /// <summary>
            /// 默认值
            /// </summary>
            private readonly int c_intTop4 = 0;

            internal static bool m_blnSinglePage = true;

            public clsPrintLine2(int intTop4)
            {
                c_intTop4 = intTop4;
                m_objDiagnose = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 12));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    if (p_intPosY < c_intTop4 && m_blnSinglePage)
                        p_intPosY = c_intTop4;
                    p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, (int)enmRectangleInfo.LeftX+5, p_intPosY);
                    p_intPosY += 20;
                    m_blnIsFirstPrint = false;
                }

                if (m_objDiagnose.m_BlnHaveNextLine())
                {
                    m_objDiagnose.m_mthPrintLine((int)enmRectangleInfo.PrintWidth2 - 5, (int)enmRectangleInfo.LeftX + 45, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }

                if (m_objDiagnose.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
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
                        if (clsDifficultCaseDiscuss_XJPrintTool.m_blnIsPrintMark)
                        {
                            if (objData[1].ToString() == "")
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint);
                            }
                            else
                            {
                                m_objDiagnose.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), dtmFirstPrint, true);
                                m_mthAddSign2(m_strTitle.Trim(), m_objDiagnose.m_ObjModifyUserArr);
                            }
                        }
                        else
                        {
                            m_objDiagnose.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                        }
                        if (m_objDiagnose.m_ObjModifyUserArr != null)
                        {
                            for (int i = 0; i < m_objDiagnose.m_ObjModifyUserArr.Length; i++)
                            {
                                if (m_objDiagnose.m_ObjModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    m_objDiagnose.m_ObjModifyUserArr[i].m_clrText = Color.Black;
                            }
                        }
                    }
                }
            }
        }
        #endregion 2
        #endregion
    }
}


