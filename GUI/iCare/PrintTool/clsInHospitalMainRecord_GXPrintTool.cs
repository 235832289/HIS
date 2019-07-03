using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// 住院病案首页(广西)打印工具类
    /// </summary>
    public class clsInHospitalMainRecord_GXPrintTool : infPrintRecord
    {
        #region 全局变量
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsInHospitalMainRecordDomain_GX m_objRecordsDomain;
        private clsPrintInfo_InHospitalMainRecord_GX m_objPrintInfo;
        private clsInHospitalMainRecord_GX_Collection m_objCollection;
        private string m_strRegisterID = "";
        private clsInHospitalMainTransDeptInstance m_objTransDeptInstance;
        private bool m_blnIsSubmit = false;

        /// <summary>
        /// 是否打印题目，打印预览时为true，套打时为false
        /// </summary>
        private static bool s_blnPrintTitle = false;
        #endregion


        
       
        #region Property
        private bool m_blnPreview = true;
        /// <summary>
        /// 是否预览
        /// </summary>
        public bool m_BlnPreview
        {
            set
            {
                m_blnPreview = value;
            }
        }

        private bool m_blnIsDummy = false;
        /// <summary>
        /// 是否假打
        /// </summary>
        public bool m_BlnIsDummy
        {
            set
            {
                m_blnIsDummy = value;
            }
        }
        #endregion

        #region 构造函数
        public clsInHospitalMainRecord_GXPrintTool(bool p_blnPrintTitle, bool p_blnIsSubmit)
        {
            s_blnPrintTitle = p_blnPrintTitle;
            m_blnIsSubmit = p_blnIsSubmit;
        }

        public clsInHospitalMainRecord_GXPrintTool()
        {
        }
        #endregion

        #region 设置打印信息(当从数据库读取时要首先调用.)
        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = null;
            long lngRes = 0;
            if (p_objPatient != null)
            {
                m_objPatient = p_objPatient;
                m_objRecordsDomain = new clsInHospitalMainRecordDomain_GX();
                lngRes = m_objRecordsDomain.m_lngGetInHospitalMainTransDeptInstance(m_objPatient.m_StrPatientID, m_objPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_strRegisterID, out m_objTransDeptInstance);
            }

            m_objPrintInfo = new clsPrintInfo_InHospitalMainRecord_GX();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;

            m_objPrintInfo.m_objPeopleInfo = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo : null;
            DateTime[] dtmOpendateArr = null;

            if (p_objPatient != null)
            {
                lngRes = m_objRecordsDomain.m_lngGetOpenDateInfo(m_strRegisterID, out dtmOpendateArr);
                m_objPrintInfo.m_dtmOpenDate = DateTime.MinValue;
                //if (lngRes < 1)
                //{
                //    return;
                //}
                if (dtmOpendateArr != null && dtmOpendateArr.Length > 0)
                {
                    if (dtmOpendateArr.Length == 1)
                    {
                        m_objPrintInfo.m_dtmOpenDate = dtmOpendateArr[0];
                    }
                    else if (dtmOpendateArr.Length == 2)
                    {
                        m_objPrintInfo.m_dtmOpenDate = dtmOpendateArr[1];
                    }
                }
                //m_objPrintInfo.m_dtmOpenDate = dtmOpenDate;

                clsInBedSessionInfo m_objSession = m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(m_objPrintInfo.m_dtmInPatientDate);
                if (m_objSession == null)
                    return;
                int m_intSessionIndex = m_objPatient.m_ObjInBedInfo.m_intGetSessionIndex(m_objSession);
                m_objPrintInfo.m_strTimes = ((int)(m_intSessionIndex + 1)).ToString();//第几次住院
                if (m_objTransDeptInstance != null)
                {
                    m_objPrintInfo.m_strInHosptialSetionName = m_objTransDeptInstance.m_strInPatientDeptName;
                    m_objPrintInfo.m_strOutHosptialSetionName = m_objTransDeptInstance.m_strOutPatientDeptName;
                    m_objPrintInfo.m_dtmOutHospitalDate = m_objTransDeptInstance.m_demOutPatientDate;
                    if (m_objTransDeptInstance.m_strTransSourceDeptIDArr != null
                        && m_objTransDeptInstance.m_strTransTargetDeptIDArr != null
                        && m_objTransDeptInstance.m_strTransSourceDeptIDArr.Length == m_objTransDeptInstance.m_strTransTargetDeptIDArr.Length)
                    {
                        m_objPrintInfo.m_strChangeDept = "";
                        for (int i = 0; i < m_objTransDeptInstance.m_strTransSourceDeptIDArr.Length; i++)
                        {
                            DateTime dtTransDate = Convert.ToDateTime(m_objTransDeptInstance.m_strTransDeptDateArr[i]);
                            m_objPrintInfo.m_strChangeDept += "由 " + m_objTransDeptInstance.m_strTransSourceDeptNameArr[i]
                                + dtTransDate.ToString("yyyy-MM-dd") + " 转 "
                                + m_objTransDeptInstance.m_strTransTargetDeptNameArr[i] + "  ";
                        }
                    }
                }

                System.TimeSpan diff = new TimeSpan(0);
                if (m_objPrintInfo.m_dtmOutHospitalDate == DateTime.MinValue || m_objPrintInfo.m_dtmOutHospitalDate == new DateTime(1900, 1, 1))
                {
                    diff = DateTime.Now.Subtract(p_dtmInPatientDate);
                }
                else
                {
                    diff = m_objPrintInfo.m_dtmOutHospitalDate.Subtract(m_objPatient.m_DtmSelectedHISInDate);
                }
                m_objPrintInfo.m_strInHospitalDays = ((int)diff.TotalDays + 1).ToString();
            }
        }
        #endregion

        #region 从数据库初始化打印内容
        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;//
            if (m_objPrintInfo == null)
            {
                return;
            }
            if (m_strRegisterID == "" || m_strRegisterID == null)
                m_objCollection = null;
            else
            {
                long lngRes = m_objRecordsDomain.m_lngGetInfo(m_strRegisterID, m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_blnIsSubmit, out m_objCollection);
                //				if(lngRes <= 0)
                //				{
                //					return ;   
                //				}

                #region  第一次打印时间赋值
                string strFirstPrintDate = "";
                m_objRecordsDomain.m_strGetFirstPrintDate(m_strRegisterID, out strFirstPrintDate);

                DateTime dtmFirstPrintTime;
                if (strFirstPrintDate == null || strFirstPrintDate.Trim() == "")
                    dtmFirstPrintTime = DateTime.Now;
                else
                    dtmFirstPrintTime = DateTime.Parse(strFirstPrintDate);
                #endregion  第一次打印时间赋值

                m_objPrintInfo.m_dtmFirstPrintTime = dtmFirstPrintTime;

            }
            //设置表单内容到打印中			
            m_objPrintInfo.m_objCollection = m_objCollection;
            m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.
        }
        #endregion

        #region 设置打印内容。(当数据已经存在时使用。)
        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_InHospitalMainRecord_GX")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_InHospitalMainRecord_GX)p_objPrintContent;
            m_objCollection = m_objPrintInfo.m_objCollection;
            m_mthSetPrintValue();
        }
        #endregion

        #region 获取打印内容
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
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (m_objPrintInfo.m_dtmOpenDate == DateTime.MinValue)
                return null;
            else
                return m_objPrintInfo;
        }
        #endregion

        #region 初始化打印变量
        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化
            m_fotTitleFont = new Font("SimSun", 15.75F, FontStyle.Bold);//宋体三号加粗
            m_fotHeaderFont = new Font("SimSun", 10.5F);//宋体五号
            m_fotRetangleFont = new Font("SimSun", 16);
            m_fotSmallFont = new Font("SimSun", 14.25F);//宋体四号
            m_GridPen = new Pen(Color.Black, 0.2f);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            m_bolIfFirst = true;
            #endregion
        }
        #endregion

        #region 释放打印变量
        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotRetangleFont.Dispose();
            m_fotSmallFont.Dispose();
            m_GridPen.Dispose();
            m_slbBrush.Dispose();
        }
        #endregion

        #region 打印开始
        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }
        #endregion

        #region 打印中
        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

            if (m_blnPreview)
            {
                m_mthPrintPageSub(e);
            }
            else
            {
                if (m_blnIsDummy)
                {
                    m_mthPrintPageSub(e);
                    e.Graphics.Clear(Color.White);
                }
                m_mthPrintPageSub(e);
                e.HasMorePages = false;
                m_mthResetWhenEndPrint();
            }
        }
        #endregion

        #region 打印结束
        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_objCollection == null) return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_dtmFirstPrintTime != DateTime.MinValue)
            {
                long lngRes = m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_strRegisterID);
                if (lngRes <= 0)
                {
                    switch (lngRes)
                    {
                        case (long)iCareData.enmOperationResult.Not_permission:
                            MDIParent.s_mthShowNotPermitMessage();
                            break;
                        case (long)iCareData.enmOperationResult.DB_Fail:
                            break;
                    }
                    return;
                }
            }
        }
        #endregion

        #region m_mthBeginPrintSub(缺省不做任何动作)
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作
        }
        #endregion

        #region 打印页
        /// <summary>
        /// 打印页
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintPageSub(PrintPageEventArgs e)
        {
            m_mthPrintHeader(e);
            if (m_intCurrentPage == 2)
            {
                m_intCurrentPage = 1;
            }
            e.HasMorePages = false;
            if (m_bolIfFirst && s_blnPrintTitle)
            {
                m_mthPrintTitleInfo(e);
            }

            while (m_objPrintContext.m_BlnHaveMoreLine)
            {
                m_objPrintContext.m_mthPrintNextLine(ref m_intYPos, e.Graphics, m_fotSmallFont);
                //在打完第一页的最后一行时，将其纵坐标设为1000，因为肯定要换页的；
                //而且套打和不套打最后的纵坐标不同
                if (m_intYPos == 1000 && m_objPrintContext.m_BlnHaveMoreLine)
                {
                    m_intCurrentPage++;
                    e.HasMorePages = true;
                    m_bolIfFirst = false;
                    m_intYPos = 12;
                    return;
                }
            }
        }
        #endregion

        #region 打印结束时的操作
        /// <summary>
        /// 打印结束时的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            m_mthResetWhenEndPrint();
        }
        #endregion

        #region 每次打印结束之后的复位
        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {
            m_objPrintContext.m_mthReset();
            m_intYPos = (int)enmRectangleInfo.TopY1;
            m_bolIfFirst = true;
        }
        #endregion

        #region	打印

        #region 有关打印的声明
        private bool m_bolIfFirst = true;
        private int m_intCurrentPage = 1;
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintContext;
        /// <summary>
        /// 标题的字体
        /// </summary>
        private Font m_fotTitleFont;

        /// <summary>
        /// 画正方形的字体
        /// </summary>
        private Font m_fotRetangleFont;
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
        private int m_intYPos = (int)enmRectangleInfo.TopY1;

        private class clsEveryRecordPageInfo
        {
            public string m_strModeOfPayment;
            public string m_strTimes;
            public string m_strPatientHistoryNO;
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 140,
            TopY1 = 38,
            /// <summary>
            /// 从主要诊断开始打
            /// </summary>
            TopY2 = 97,

            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 78,
            LeftX1 = 2,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 827 - 30,
            RightX1 = 185,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 30,
            RowStep1 = 6,
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

            BottomY = 1024

        }
        #region 打印行定义
        private clsPrintLine1 m_objLine1;
        private clsPrintLine2 m_objLine2;
        private clsPrintLine3 m_objLine3;
        private clsPrintLine4 m_objLine4;
        private clsPrintLine5 m_objLine5;
        private clsPrintLine6 m_objLine6;
        private clsPrintLine7 m_objLine7;
        private clsPrintLine8 m_objLine8;
        private clsPrintLine9 m_objLine9;
        private clsPrintLine10 m_objLine10;
        private clsPrintLine11 m_objLine11;
        private clsPrintLine12 m_objLine12;
        private clsPrintLine13 m_objLine13;
        private clsPrintLine14 m_objLine14;
        private clsPrintLine15 m_objLine15;
        private clsPrintLine16 m_objLine16;
        private clsPrintLine17 m_objLine17;
        private clsPrintLine18 m_objLine18;

        private clsPrintLine102 m_objLine102;
        private clsPrintLine103 m_objLine103;
        private clsPrintLine104 m_objLine104;
        private clsPrintLine105 m_objLine105;
        private clsPrintLine106 m_objLine106;
        private clsPrintLine107 m_objLine107;
        private clsPrintLine108 m_objLine108;
        private clsPrintLine109 m_objLine109;
        private clsPrintLine110 m_objLine110;
        private clsPrintLine111 m_objLine111;
        private clsPrintLine112 m_objLine112;
        private clsPrintLine113 m_objLine113;
        private clsPrintLine114 m_objLine114;
        private clsPrintLine115 m_objLine115;
        private clsPrintLine116 m_objLine116;
        private clsPrintLine117 m_objLine117;
        private clsPrintLine118 m_objLine118;
        private clsPrintLine119 m_objLine119;
        private clsPrintLine120 m_objLine120;
        private clsPrintLine121 m_objLine121;
        #endregion

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

        }


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
                        m_fReturnPoint = new PointF(320f - fltOffsetX, 90f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(300f - fltOffsetX, 120f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(60f - fltOffsetX, 160f);
                        break;
                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(650f - fltOffsetX, 160f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(715f - fltOffsetX, 160f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        #endregion
        #endregion

        #region 标题文字部分
        private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            clsEveryRecordPageInfo objEveryRecordPageInfo = new clsEveryRecordPageInfo();
            //************************************************
            if (m_objCollection != null && m_objCollection.m_objContent != null)
            {
                objEveryRecordPageInfo.m_strTimes = m_objPrintInfo.m_strTimes;
                objEveryRecordPageInfo.m_strModeOfPayment = m_objCollection.m_objContent.m_strPAYTYPE;
                objEveryRecordPageInfo.m_strPatientHistoryNO = m_objPrintInfo.m_strHISInPatientID;
            }
            else
            {
                objEveryRecordPageInfo.m_strTimes = "";
                objEveryRecordPageInfo.m_strModeOfPayment = "";
                objEveryRecordPageInfo.m_strPatientHistoryNO = "";
            }


            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("住 院 病 案 首 页", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));


            e.Graphics.DrawString("付费方式：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

            e.Graphics.DrawString(objEveryRecordPageInfo.m_strModeOfPayment, m_fotSmallFont, m_slbBrush, 150f - fltOffsetX, 160f);
            e.Graphics.DrawString("第     次住院", m_fotSmallFont, m_slbBrush, 350f - fltOffsetX, 160f);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strTimes, m_fotSmallFont, m_slbBrush, 380f - fltOffsetX, 160f);
            e.Graphics.DrawString("ID号: ", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strPatientHistoryNO, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
        }

        #endregion

        #region m_mthSetPrintValue
        private void m_mthSetPrintValue()
        {
            #region 打印行初始化
            m_objLine1 = new clsPrintLine1();
            m_objLine2 = new clsPrintLine2();
            m_objLine3 = new clsPrintLine3();
            m_objLine4 = new clsPrintLine4();
            m_objLine5 = new clsPrintLine5();
            m_objLine6 = new clsPrintLine6();
            m_objLine7 = new clsPrintLine7();
            m_objLine8 = new clsPrintLine8();
            m_objLine9 = new clsPrintLine9();
            m_objLine10 = new clsPrintLine10();
            m_objLine11 = new clsPrintLine11();
            m_objLine12 = new clsPrintLine12();
            m_objLine13 = new clsPrintLine13();
            m_objLine14 = new clsPrintLine14();
            m_objLine15 = new clsPrintLine15();
            m_objLine16 = new clsPrintLine16();
            m_objLine17 = new clsPrintLine17();
            m_objLine18 = new clsPrintLine18();
            m_objLine102 = new clsPrintLine102();
            m_objLine103 = new clsPrintLine103();
            m_objLine104 = new clsPrintLine104();
            m_objLine105 = new clsPrintLine105();
            m_objLine106 = new clsPrintLine106();
            m_objLine107 = new clsPrintLine107();
            m_objLine108 = new clsPrintLine108();
            m_objLine109 = new clsPrintLine109();
            m_objLine110 = new clsPrintLine110();
            m_objLine111 = new clsPrintLine111();
            m_objLine112 = new clsPrintLine112();
            m_objLine113 = new clsPrintLine113();
            m_objLine114 = new clsPrintLine114();
            m_objLine115 = new clsPrintLine115();
            m_objLine116 = new clsPrintLine116();
            m_objLine117 = new clsPrintLine117();
            m_objLine118 = new clsPrintLine118();
            m_objLine119 = new clsPrintLine119();
            m_objLine120 = new clsPrintLine120();
            m_objLine121 = new clsPrintLine121();
            m_objPrintContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   m_objLine1,
																		   m_objLine2,
																		   m_objLine3,
																		   m_objLine4,
																		   m_objLine5,
																		   m_objLine6,
																		   m_objLine7,
																		   m_objLine8,
																		   m_objLine9,
																		   m_objLine10,
																		   m_objLine11,
																		   m_objLine12,
																		   m_objLine13,
																		   m_objLine14,
																		   m_objLine15,
																		   m_objLine16,
																		   m_objLine17,
																		   m_objLine18,
																		   m_objLine102,
																		   m_objLine103,
																		   m_objLine104,
																		   m_objLine105,
																		   m_objLine106,
																		   m_objLine107,
																		   m_objLine108,
																		   m_objLine109,
																		   m_objLine110,
																		   m_objLine111,
																		   m_objLine112,
																		   m_objLine113,
																		   m_objLine114,
																		   m_objLine115,
																		   m_objLine116,
																		   m_objLine117,
																		   m_objLine118,
																		   m_objLine119,
																		   m_objLine120,
																		   m_objLine121
																	   });
            #endregion

            m_objPrintContext.m_DtmFirstPrintTime = m_objPrintInfo.m_dtmFirstPrintTime;

            bool m_bolIfCheck = false;
            if (m_objPrintInfo.m_strInPatentID != "" && m_objCollection != null && m_objCollection.m_objContent != null)//当有资料的时候，要检查，否则，打印空表
            {
                m_bolIfCheck = true;
            }

            object[] m_objDataArr = null;//row
            object[] m_objSubDataArr = null;//column
            m_objDataArr = new object[2];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objPrintInfo.m_objPeopleInfo.m_StrHomeplace;
            }
            else
            {
                m_objDataArr[0] = "";
            }

            if (m_objPrintInfo.m_strInPatentID != "")
            {
                m_objLine1.m_ObjPrintLineInfo = m_objPrintInfo.m_objPeopleInfo;
                m_objDataArr[1] = m_objPrintInfo.m_objPeopleInfo;
                m_objLine2.m_ObjPrintLineInfo = m_objDataArr;
                m_objLine3.m_ObjPrintLineInfo = m_objPrintInfo.m_objPeopleInfo;
                m_objLine4.m_ObjPrintLineInfo = m_objPrintInfo.m_objPeopleInfo;
                m_objLine5.m_ObjPrintLineInfo = m_objPrintInfo.m_objPeopleInfo;
            }
            else
            {
                m_objLine1.m_ObjPrintLineInfo = null;
                m_objLine2.m_ObjPrintLineInfo = null;
                m_objLine3.m_ObjPrintLineInfo = null;
                m_objLine4.m_ObjPrintLineInfo = null;
                m_objLine5.m_ObjPrintLineInfo = null;
            }

            m_objDataArr = new Object[5];
            if (m_objPrintInfo.m_strInPatentID != "" && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = (m_objPrintInfo.m_strInHosptialSetionName == null ? "" : m_objPrintInfo.m_strInHosptialSetionName);
                if (m_objPrintInfo.m_dtmHISInPatientDate != DateTime.MinValue && m_objPrintInfo.m_dtmHISInPatientDate != new DateTime(1900, 1, 1))
                {
                    m_objDataArr[1] = m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy年MM月dd日 HH时");
                }
                else
                {
                    m_objDataArr[1] = "";
                }
                m_objDataArr[2] = (m_objPrintInfo.m_strOutHosptialSetionName == null ? "" : m_objPrintInfo.m_strOutHosptialSetionName);
                if (m_objPrintInfo.m_dtmOutHospitalDate != DateTime.MinValue && m_objPrintInfo.m_dtmOutHospitalDate != new DateTime(1900, 1, 1))
                {
                    m_objDataArr[3] = m_objPrintInfo.m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH时");
                }
                else
                {
                    m_objDataArr[3] = "";
                }
                m_objDataArr[4] = m_objPrintInfo.m_strInHospitalDays;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine6.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_objPrintInfo.m_strInPatentID != "" && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = m_objPrintInfo.m_strChangeDept;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine7.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intCONDICTIONWHENIN;
                m_objDataArr[1] = m_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine8.m_ObjPrintLineInfo = m_objDataArr;


            m_objLine9.m_ObjPrintLineInfo = null;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strDIAGNOSIS;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strSTATCODEOFDIAGNOSIS;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strICD_10OFDIAGNOSIS;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine10.m_ObjPrintLineInfo = m_objDataArr;

            //			m_objDataArr = new Object[3];
            //			if(m_bolIfCheck)
            //			{
            //				m_objDataArr[0] = m_objCollection.m_objContent.m_strINHOSPITALDIAGNOSIS;
            //				m_objDataArr[1] = m_objCollection.m_objContent.m_strSTATCODEOFINHOSPITALDIA;
            //				m_objDataArr[2] = m_objCollection.m_objContent.m_strICD_10OFINHOSPITALDIA;
            //			}
            //			else
            //			{
            //				m_objDataArr[0] = "";
            //				m_objDataArr[1] = "";
            //				m_objDataArr[2] = "";
            //			}
            //			m_objLine11.m_ObjPrintLineInfo=m_objDataArr;

            m_objDataArr = new object[3];
            if (m_bolIfCheck == false || m_objCollection.m_objInDiagnosisArr == null || m_objCollection.m_objInDiagnosisArr.Length <= 0)
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objLine11.m_ObjPrintLineInfo = m_objDataArr;
            }
            else
            {
                if (m_objCollection.m_objInDiagnosisArr.Length > 0)
                {
                    string strDia = "";
                    string strStatic = "";
                    string strICD10 = "";
                    for (int i1 = 0; i1 < m_objCollection.m_objInDiagnosisArr.Length; i1++)
                    {
                        if (i1 == 0)
                        {
                            strDia = m_objCollection.m_objInDiagnosisArr[i1].m_strDIAGNOSISDESC;
                            strStatic = m_objCollection.m_objInDiagnosisArr[i1].m_strSTATCODE;
                            strICD10 = m_objCollection.m_objInDiagnosisArr[i1].m_strICD10;
                        }
                        else
                        {
                            strDia += ";" + m_objCollection.m_objInDiagnosisArr[i1].m_strDIAGNOSISDESC;
                            strStatic += ";" + m_objCollection.m_objInDiagnosisArr[i1].m_strSTATCODE;
                            strICD10 += ";" + m_objCollection.m_objInDiagnosisArr[i1].m_strICD10;
                        }
                    }
                    m_objDataArr[0] = strDia;
                    m_objDataArr[1] = strStatic;
                    m_objDataArr[2] = strICD10;
                    m_objLine11.m_ObjPrintLineInfo = m_objDataArr;
                }
            }

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strMAINDIAGNOSIS;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intMAINCONDITIONSEQ;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOTHERMAINCONDITION;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSTATCODEOFINHOSPITALDIA;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strICD_10OFINHOSPITALDIA;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine12.m_ObjPrintLineInfo = m_objDataArr;

            if (m_bolIfCheck == false || m_objCollection.m_objOtherDiagnosisArr == null || m_objCollection.m_objOtherDiagnosisArr.Length <= 0)
            {
                m_objLine13.m_ObjPrintLineInfo = null;
            }
            else
            {
                if (m_objCollection.m_objOtherDiagnosisArr.Length > 0)
                {
                    m_objDataArr = new Object[m_objCollection.m_objOtherDiagnosisArr.Length];

                    for (int i1 = 0; i1 < m_objCollection.m_objOtherDiagnosisArr.Length; i1++)
                    {
                        m_objSubDataArr = new object[5];
                        m_objSubDataArr[0] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strDIAGNOSISDESC;
                        m_objSubDataArr[1] = m_objCollection.m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ;
                        m_objSubDataArr[2] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strOTHERCONDITION;
                        m_objSubDataArr[3] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strSTATCODE;
                        m_objSubDataArr[4] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strICD10;
                        m_objDataArr[i1] = m_objSubDataArr;
                    }
                    m_objLine13.m_ObjPrintLineInfo = m_objDataArr;
                }
            }

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strCOMPLICATION;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intCOMPLICATIONSEQ;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOTHERCOMPLICATION;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSTATCODEOFCOMPLICATION;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strICD_10OFCOMPLICATION;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine14.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strINFECTIONDIAGNOSIS;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intINFECTIONCONDICTIONSEQ;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOTHERINFECTIONCONDICTION;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSTATCODEOFINFECTION;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strICD_10OFINFECTION;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine15.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strPATHOLOGYDIAGNOSIS;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intPATHOLOGYDIAGNOSISSEQ;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOTHERPATHOLOGYDIAGNOSIS;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSTATCODEOFPATHOLOGYDIA;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strICD_10OFPATHOLOGYDIA;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine16.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strSCACHESOURCE;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intNEW5DISEASE;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intSECONDLEVELTRANSFER;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine17.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strSENSITIVE;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intHBSAG;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intHCV_AB;
                m_objDataArr[3] = m_objCollection.m_objContent.m_intHIV_AB;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine18.m_ObjPrintLineInfo = m_objDataArr;

            //*******************************

            //第二页
            if (m_bolIfCheck == false || m_objCollection.m_objOperationArr == null || m_objCollection.m_objOperationArr.Length <= 0)
            {
                m_objLine102.m_ObjPrintLineInfo = null;
            }
            else
            {
                m_objDataArr = new Object[m_objCollection.m_objOperationArr.Length];

                for (int i1 = 0; i1 < m_objCollection.m_objOperationArr.Length; i1++)
                {
                    m_objSubDataArr = new object[9];
                    if (m_objCollection.m_objOperationArr[i1].m_dtmOPERATIONDATE == new DateTime(1900, 1, 1))
                    {
                        m_objSubDataArr[0] = "";
                    }
                    else
                    {
                        m_objSubDataArr[0] = m_objCollection.m_objOperationArr[i1].m_dtmOPERATIONDATE.ToString("yyyy-MM-dd HH:mm");
                    }
                    m_objSubDataArr[1] = m_objCollection.m_objOperationArr[i1].m_strOPERATIONNAME;
                    m_objSubDataArr[2] = m_objCollection.m_objOperationArr[i1].m_strOPERATORNAME;
                    m_objSubDataArr[3] = m_objCollection.m_objOperationArr[i1].m_strASSISTANT1NAME;
                    m_objSubDataArr[4] = m_objCollection.m_objOperationArr[i1].m_strASSISTANT2NAME;
                    if (m_objCollection.m_objOperationArr[i1].m_strAANAESTHESIAMODEID == null || m_objCollection.m_objOperationArr[i1].m_strOPERATIONAANAESTHESIAMODENAME == null)
                        m_objSubDataArr[5] = "";
                    else
                        m_objSubDataArr[5] = m_objCollection.m_objOperationArr[i1].m_strOPERATIONAANAESTHESIAMODENAME;
                    m_objSubDataArr[6] = m_objCollection.m_objOperationArr[i1].m_strCUTLEVEL;
                    m_objSubDataArr[7] = m_objCollection.m_objOperationArr[i1].m_strANAESTHETISTNAME;
                    m_objSubDataArr[8] = m_objCollection.m_objOperationArr[i1].m_strOPERATIONID;
                    for (int j2 = 0; j2 < 9; j2++)
                    {
                        if (m_objSubDataArr[j2] == null)
                            m_objSubDataArr[j2] = "";
                    }

                    m_objDataArr[i1] = m_objSubDataArr;
                }
                m_objLine102.m_ObjPrintLineInfo = m_objDataArr;
            }

            m_objDataArr = new Object[1];
            if (m_bolIfCheck && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strNEONATEDISEASE1;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine103.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_bolIfCheck && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strNEONATEDISEASE2;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine104.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_bolIfCheck && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strNEONATEDISEASE3;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine105.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_bolIfCheck && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strNEONATEDISEASE4;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine106.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intSALVETIMES;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intSALVESUCCESS;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intHASREMIND;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strREMINDTERM;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine107.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intACCORDWITHOUTHOSPITAL;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intACCORDINWITHOUT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intACCORDBFOPRWITHAF;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine108.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intACCORDCLINICWITHPATHOLOGY;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intACCORDDEATHWITHBODYCHECK;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intACCORDCLINICWITHRADIATE;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine109.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intMODELCASE;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intFIRSTCASE;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intQUALITY;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine110.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intANTIBACTERIAL;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intPATHOGENY;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intPATHOGENYRESULT;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine111.m_ObjPrintLineInfo = m_objDataArr;


            //112
            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intBLOODTRANSACTOIN;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intTRANSFUSIONSACTION;
                m_objDataArr[2] = m_objCollection.m_objContent.m_intCTCHECK;
                m_objDataArr[3] = m_objCollection.m_objContent.m_intMRICHECK;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine112.m_ObjPrintLineInfo = m_objDataArr;

            //113

            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_intBLOODTYPE;
                m_objDataArr[1] = m_objCollection.m_objContent.m_intBLOODRH;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine113.m_ObjPrintLineInfo = m_objDataArr;

            //114           
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strRBC;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strPLT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strPLASM;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strWHOLEBLOOD;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strOTHERBLOOD;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine114.m_ObjPrintLineInfo = m_objDataArr;

            //115
            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strDEPTDIRECTORDTNAME;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strDTNAME;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strINHOSPITALDOCNAME;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strOUTHOSPITALDOCNAME;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine115.m_ObjPrintLineInfo = m_objDataArr;
            //116
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strDIRECTORDTNAME;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine116.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strSUBDIRECTORDTNAME;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strATTENDINFORADVANCESSTUDYDTNAME;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strGRADUATESTUDENTINTERNNAME;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strINTERNNAME;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine117.m_ObjPrintLineInfo = m_objDataArr;


            //118
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_dblTOTALAMT;
                m_objDataArr[1] = m_objCollection.m_objContent.m_dblBEDAMT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_dblNURSEAMT;
                m_objDataArr[3] = m_objCollection.m_objContent.m_dblWMAMT;
                m_objDataArr[4] = m_objCollection.m_objContent.m_dblCMFINISHEDAMT;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine118.m_ObjPrintLineInfo = m_objDataArr;


            m_objDataArr = new Object[7];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_dblCMSEMIFINISHEDAMT;
                m_objDataArr[1] = m_objCollection.m_objContent.m_dblRADIATIONAMT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_dblASSAYAMT;
                m_objDataArr[3] = m_objCollection.m_objContent.m_dblO2AMT;
                m_objDataArr[4] = m_objCollection.m_objContent.m_dblBLOODAMT;
                m_objDataArr[5] = m_objCollection.m_objContent.m_dblTREATMENTAMT;
                m_objDataArr[6] = m_objCollection.m_objContent.m_dblOPERATIONAMT;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
                m_objDataArr[6] = "";
            }
            m_objLine119.m_ObjPrintLineInfo = m_objDataArr;
            //120

            m_objDataArr = new Object[6];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_dblCHECKAMT;
                m_objDataArr[1] = m_objCollection.m_objContent.m_dblANAETHESIAAMT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_dblDELIVERYCHILDAMT;
                m_objDataArr[3] = m_objCollection.m_objContent.m_dblBABYAMT;
                m_objDataArr[4] = m_objCollection.m_objContent.m_dblACCOMPANYAMT;
                m_objDataArr[5] = m_objCollection.m_objContent.m_dblOTHERAMT;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
            }
            m_objLine120.m_ObjPrintLineInfo = m_objDataArr;

            //121

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strNEATENNAME;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strCODINGNAME;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strINPUTMACHINENAME;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSTATISTICNAME;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine121.m_ObjPrintLineInfo = m_objDataArr;
        }
        #endregion

        #region PrintClasses
        private class clsPrintLine1 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {

            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine1()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_intPosY = 192;
                if (m_objPeople == null)
                {
                    if (s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("姓名            性别     出生于     年   月   日  年龄          婚姻状况      职业", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);

                    }
                }
                else
                {
                    if (s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("姓名            性别     出生于                   年龄            婚姻状况       职业", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    }

                    p_objGrp.DrawString(m_objPeople.m_StrLastName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrSex, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 115, p_intPosY);


                    if (m_objPeople.m_DtmBirth != DateTime.MinValue)
                    {
                        p_objGrp.DrawString(m_objPeople.m_DtmBirth.ToString("yyyy年MM月dd日"), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 210, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString("未知", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 210, p_intPosY);
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrAge, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 360, p_intPosY);

                    p_objGrp.DrawString(m_objPeople.m_StrMarried, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 520, p_intPosY);

                    p_objGrp.DrawString(m_objPeople.m_StrOccupation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 600, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }

        private class clsPrintLine2 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            string m_strBirthPlace = "";
            public clsPrintLine2()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    if (m_objPeople != null)
                    {
                        if (m_objPeople.m_StrHomeplace == "" || m_objPeople.m_StrHomeplace == null)
                        {
                            p_objGrp.DrawString("出生地          省(市)        县(市)  民族              国籍          身份证号", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                        }
                        else
                        {
                            p_objGrp.DrawString("出生地                              民族              国籍          身份证号", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                        }
                    }
                    else
                    {
                        p_objGrp.DrawString("出生地          省(市)        县(市)  民族              国籍          身份证号", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    }
                }

                if (m_objPeople != null)
                {
                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 20, p_intPosY, 80, 25);
                    StringFormat frmat = new StringFormat();

                    p_objGrp.DrawString(m_objPeople.m_StrHomeplace, fotNow, Brushes.Black, rtgf);

                    fotNow = m_fotPrintFont;
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 270, p_intPosY, 100, 25);
                    //					if(m_objPeople.m_StrNation.Length > 4)
                    //					{
                    //						fotNow = new Font("SimSun",8f);
                    //						rtgf = new RectangleF((int)enmRectangleInfo.LeftX+270,p_intPosY,18,35);
                    //						if(m_objPeople.m_StrNation.Length > 6)
                    //						{
                    //							rtgf = new RectangleF((int)enmRectangleInfo.LeftX+270,p_intPosY-2,18,35);
                    //						}
                    //						frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //					}
                    p_objGrp.DrawString(m_objPeople.m_StrNation, fotNow, Brushes.Black, rtgf, frmat);

                    fotNow = m_fotPrintFont;
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 395, p_intPosY, 100, 25);
                    //					if(m_objPeople.m_StrNationality.Length > 2)
                    //					{
                    //						fotNow = new Font("SimSun",8f);
                    //						rtgf = new RectangleF((int)enmRectangleInfo.LeftX+400,p_intPosY,15,35);
                    //						if(m_objPeople.m_StrNationality.Length > 3)
                    //						{
                    //							rtgf = new RectangleF((int)enmRectangleInfo.LeftX+400,p_intPosY-2,15,35);
                    //						}
                    //						frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //					}
                    p_objGrp.DrawString(m_objPeople.m_StrNationality, fotNow, Brushes.Black, rtgf, frmat);

                    p_objGrp.DrawString(m_objPeople.m_StrIDCard, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 530, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep; ;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        Object[] objContent = (object[])value;
                        m_objPeople = (clsPeopleInfo)(objContent[1]);
                        m_strBirthPlace = objContent[0].ToString();
                    }
                }
            }
        }

        private class clsPrintLine3 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine3()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("工作单位及地址                                            电话             邮政编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 420, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 585, p_intPosY);

                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 25);
                    StringFormat frmat = new StringFormat();
                    //					if((m_objPeople.m_StrOffice_name+"  "+m_objPeople.m_StrOfficeAddress).Length > 19)
                    //					{
                    //						fotNow = new Font("SimSun",8f);
                    //						rtgf = new RectangleF((int)enmRectangleInfo.LeftX+70,p_intPosY,75,35);
                    //						if((m_objPeople.m_StrOffice_name+"  "+m_objPeople.m_StrOfficeAddress).Length > 24)
                    //						{
                    //							rtgf = new RectangleF((int)enmRectangleInfo.LeftX+70,p_intPosY-2,75,35);
                    //						}
                    //						frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //					}
                    p_objGrp.DrawString(m_objPeople.m_StrOffice_name + "  " + m_objPeople.m_StrOfficeAddress, fotNow, Brushes.Black, rtgf, frmat);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }

        private class clsPrintLine4 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine4()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("户口地址                                                                   邮政编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrHomePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 585, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrHomeAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }

        private class clsPrintLine5 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;

            public clsPrintLine5()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("联系人姓名         关系         地址                      电话             邮政编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManLastName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 40, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrPatientRelation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 135, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManPhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 420, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManPC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 585, p_intPosY);

                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 230, p_intPosY, 170, 25);
                    StringFormat frmat = new StringFormat();
                    if (m_objPeople.m_StrLinkManAddress.Length > 12)
                    {
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 230, p_intPosY - 5, 170, 35);
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManAddress, fotNow, Brushes.Black, rtgf, frmat);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }

        private class clsPrintLine6 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr;
            public clsPrintLine6()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 11));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入院科别                                    出院科别                                   共住    天", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);

                    if (m_objDataArr[1] == null || m_objDataArr[1].ToString() == "")
                    {
                        p_objGrp.DrawString("    年  月  日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                    }
                    Font fotNow = m_fotPrintFont;
                    if (m_objDataArr[0] != null && m_objDataArr[0].ToString() != string.Empty)
                    {
                        if (m_objDataArr[1].ToString().Length > 6)
                        {
                            fotNow = new Font("SimSun", 8f);
                        }
                        p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 50, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString("            科", fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    }

                    fotNow = m_fotPrintFont;
                    if (m_objDataArr[3] == null || m_objDataArr[3].ToString() == "")
                    {
                        p_objGrp.DrawString("    年  月  日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 470, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 470, p_intPosY);
                    }

                    if (m_objDataArr[2] != null && m_objDataArr[2].ToString() != string.Empty)
                    {
                        if (m_objDataArr[2].ToString().Length > 6)
                        {
                            fotNow = new Font("SimSun", 8f);
                        }
                        p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 380, p_intPosY);
                    }
                    else
                    {
                        p_objGrp.DrawString("        科", fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 380, p_intPosY);
                    }

                    p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 640, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine7 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr;
            public clsPrintLine7()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("转科情况:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                if (m_objDataArr[0] == null || m_objDataArr[0].ToString() == string.Empty)
                {
                    p_objGrp.DrawString("由        科     年   月   日 转        科  由        科     年   月   日 转        科", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 40, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine8 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPublicControlPaint m_objCPaint;
            private object[] m_objDataArr;
            public clsPrintLine8()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入院时情况:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 80, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("1.危    2.急    3.一般        入院后确诊日期:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY);
                }

                if ((m_objDataArr[0]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[0]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 82, p_intPosY);


                if (m_objDataArr[1] == null || m_objDataArr[1].ToString() == string.Empty)
                {
                    p_objGrp.DrawString("    年  月  日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 520, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 520, p_intPosY);
                }
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine9 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black);
            public clsPrintLine9()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               诊    断    名    称                          疗  效           统计码    ICD码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 360, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 360, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 540, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 540, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 610, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 610, p_intPosY + 470);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 390, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 390, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 420, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 420, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 450, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 450, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 480, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 480, p_intPosY + 470);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 510, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 510, p_intPosY + 470);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+157,p_intPosY,(int)enmRectangleInfo.LeftX+157,p_intPosY+86);

                    p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                }
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine10 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine10()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("门(急)诊诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawString(" 治  好  未  死  其  正", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 360, p_intPosY - 5);
                    p_objGrp.DrawString("                        常", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 334, p_intPosY + 10);
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                    {
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                    }
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, (int)enmRectangleInfo.LeftX + 360, p_intPosY + 22);
                p_objGrp.DrawLine(new Pen(Brushes.Black), (int)enmRectangleInfo.LeftX + 540, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine11 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine11()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入 院 诊 断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawString("                        分", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 334, p_intPosY - 5);
                    p_objGrp.DrawString(" 愈  转  愈  亡  他  娩", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 360, p_intPosY + 8);
                }
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                    {
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                    }
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine12 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {

            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine12()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("出院主要诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                int intSeqX = 0;
                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                if ((m_objDataArr[1]).ToString() == "0")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 370;
                }
                else if ((m_objDataArr[1]).ToString() == "1")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 400;
                }
                else if ((m_objDataArr[1]).ToString() == "2")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 430;
                }
                else if ((m_objDataArr[1]).ToString() == "3")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 460;
                }
                else if ((m_objDataArr[1]).ToString() == "4")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 480;
                }
                else if ((m_objDataArr[1]).ToString() == "5")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 520;
                }

                if (intSeqX > 0)
                {
                    if ((m_objDataArr[1]).ToString() == "4")
                    {
                        fotNow = new Font("SimSun", 9f);
                        if (m_objDataArr[2].ToString().Length > 1)
                        {
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                    }
                    else
                    {
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, intSeqX, p_intPosY);
                    }
                }
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                fotNow = m_fotPrintFont;
                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                    {
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                    }
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #region 13 ~ 21

        private class clsPrintLine13 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine13()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("出院其他诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    Font fotNow = new Font("SimSun", 9f);
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                    for (int i = 0; i < m_objDataArr.Length; i++)
                    {
                        object[] m_objSubDataArr = (object[])m_objDataArr[i];
                        if (i == 0)
                        {
                            fotNow = m_fotPrintFont;
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                            StringFormat frmat = new StringFormat();
                            if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                            {
                                fotNow = new Font("SimSun", 9f);
                                if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                                {
                                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                                }
                                frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                            }
                            p_objGrp.DrawString(m_objSubDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);
                        }
                        else
                        {
                            fotNow = m_fotPrintFont;
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX - 35, p_intPosY, 380, 30);
                            StringFormat frmat = new StringFormat();
                            if (m_objDataArr[0].ToString().Length > 26 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                            {
                                fotNow = new Font("SimSun", 9f);
                                if (m_objDataArr[0].ToString().Length > 32 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                                {
                                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX - 35, p_intPosY - 5, 380, 30);
                                }
                                frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                            }
                            p_objGrp.DrawString(m_objSubDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);
                        }
                        switch (m_objSubDataArr[1].ToString())
                        {
                            case "0":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 370, p_intPosY);
                                break;
                            case "1":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 400, p_intPosY);
                                break;
                            case "2":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 430, p_intPosY);
                                break;
                            case "3":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 460, p_intPosY);
                                break;
                            case "5":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 520, p_intPosY);
                                break;
                        }
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                        fotNow = new Font("SimSun", 9f);
                        if (m_objSubDataArr[2].ToString().Length > 1)
                        {
                            p_objGrp.DrawString(m_objSubDataArr[2].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                        {
                            p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                        }
                        p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                        p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);
                        p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                        p_intPosY += (int)enmRectangleInfo.RowStep;
                    }
                    if (m_objDataArr.Length < 9)
                    {
                        m_mthDrawLine(p_objGrp, 9 - m_objDataArr.Length, ref p_intPosY);
                    }
                }
                else
                {
                    m_mthDrawLine(p_objGrp, 9, ref p_intPosY);
                }
                m_blnHaveMoreLine = false;
            }

            private void m_mthDrawLine(System.Drawing.Graphics p_objGrp, int p_intLows, ref int p_intPosY)
            {
                for (int i = 0; i < p_intLows; i++)
                {
                    p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                }
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine14 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine14()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("并发症(含手术麻醉)", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                int intSeqX = 0;
                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                if ((m_objDataArr[1]).ToString() == "0")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 370;
                }
                else if ((m_objDataArr[1]).ToString() == "1")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 400;
                }
                else if ((m_objDataArr[1]).ToString() == "2")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 430;
                }
                else if ((m_objDataArr[1]).ToString() == "3")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 460;
                }
                else if ((m_objDataArr[1]).ToString() == "4")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 480;
                }
                else if ((m_objDataArr[1]).ToString() == "5")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 520;
                }

                if (intSeqX > 0)
                {
                    if ((m_objDataArr[1]).ToString() == "4")
                    {
                        fotNow = new Font("SimSun", 9f);
                        if (m_objDataArr[2].ToString().Length > 1)
                        {
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                    }
                    else
                    {
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, intSeqX, p_intPosY);
                    }
                }
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                fotNow = m_fotPrintFont;
                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 105, p_intPosY, 270, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 17 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 105, p_intPosY - 5, 270, 30);
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine15 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine15()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("院内感染名称", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                int intSeqX = 0;
                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                if ((m_objDataArr[1]).ToString() == "0")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 370;
                }
                else if ((m_objDataArr[1]).ToString() == "1")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 400;
                }
                else if ((m_objDataArr[1]).ToString() == "2")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 430;
                }
                else if ((m_objDataArr[1]).ToString() == "3")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 460;
                }
                else if ((m_objDataArr[1]).ToString() == "4")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 480;
                }
                else if ((m_objDataArr[1]).ToString() == "5")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 520;
                }

                if (intSeqX > 0)
                {
                    if ((m_objDataArr[1]).ToString() == "4")
                    {
                        fotNow = new Font("SimSun", 9f);
                        if (m_objDataArr[2].ToString().Length > 1)
                        {
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                    }
                    else
                    {
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, intSeqX, p_intPosY);
                    }
                }
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                fotNow = m_fotPrintFont;
                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine16 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine16()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病 理 诊 断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                int intSeqX = 0;
                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 480, p_intPosY - 5, 35, 30);
                if ((m_objDataArr[1]).ToString() == "0")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 370;
                }
                else if ((m_objDataArr[1]).ToString() == "1")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 400;
                }
                else if ((m_objDataArr[1]).ToString() == "2")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 430;
                }
                else if ((m_objDataArr[1]).ToString() == "3")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 460;
                }
                else if ((m_objDataArr[1]).ToString() == "4")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 480;
                }
                else if ((m_objDataArr[1]).ToString() == "5")
                {
                    intSeqX = (int)enmRectangleInfo.LeftX + 520;
                }

                if (intSeqX > 0)
                {
                    if ((m_objDataArr[1]).ToString() == "4")
                    {
                        fotNow = new Font("SimSun", 9f);
                        if (m_objDataArr[2].ToString().Length > 1)
                        {
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                            p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                    }
                    else
                    {
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, intSeqX, p_intPosY);
                    }
                }
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 545, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY);

                fotNow = m_fotPrintFont;
                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY, 310, 30);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 20 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                {
                    fotNow = new Font("SimSun", 9f);
                    if (m_objDataArr[0].ToString().Length > 24 || m_objDataArr[0].ToString().IndexOf("\n") != -1)
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 60, p_intPosY - 5, 310, 30);
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine17 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPublicControlPaint m_objCPaint;

            public clsPrintLine17()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("损伤和中毒的外部原因", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawString("新五病   1.是  2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 345, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("二级转诊   1.有  2.无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 500, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 560, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                Font fotNow = new Font("SimSun", 9f);
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 113, p_intPosY - 5, 190, 30);
                if (m_objDataArr[0].ToString().Length > 12)
                {
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf);
                }
                else
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 113, p_intPosY);

                if ((m_objDataArr[1]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[1]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 347, p_intPosY);

                if ((m_objDataArr[2]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[2]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 562, p_intPosY);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine18 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPublicControlPaint m_objCPaint;

            public clsPrintLine18()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("过 敏 药 物", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawString("HBsAg   ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 250, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("HCV - Ab", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 370, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("HIV - Ab       0.未做  1.阴性  2.阳性", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 400, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 470, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY);

                if ((m_objDataArr[1]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[1]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 252, p_intPosY);

                if ((m_objDataArr[2]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[2]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 372, p_intPosY);

                if ((m_objDataArr[3]).ToString() != "-1")
                    p_objGrp.DrawString((m_objDataArr[3]).ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 472, p_intPosY);


                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY = 1000;	//打完这一行，肯定换页
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #endregion




        private class clsPrintLine102 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private clsPrintRichTextContext m_objText2;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black);
            private object[] m_objDataArr = null;

            public clsPrintLine102()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
                m_objText2 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_intPosY = 142;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 50, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 50, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 210, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 210, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 390, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 390, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 470, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 470, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 530, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 530, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 610, p_intPosY - 7, (int)enmRectangleInfo.LeftX + 610, p_intPosY + 260);

                    p_objGrp.DrawString("手术、操\n 作日期", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 30, p_intPosY + 8);
                    p_objGrp.DrawString("手 术 操 作 名 称", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY + 15);
                    p_objGrp.DrawString("手术医生", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 270, p_intPosY);
                    p_objGrp.DrawString("术 者", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 215, p_intPosY + 30);
                    p_objGrp.DrawString("Ⅰ助", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 280, p_intPosY + 30);
                    p_objGrp.DrawString("Ⅱ助", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 340, p_intPosY + 30);
                    p_objGrp.DrawString("麻醉方式", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 395, p_intPosY + 15);
                    p_objGrp.DrawString("切口", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 480, p_intPosY + 15);
                    p_objGrp.DrawString("麻醉医生", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 535, p_intPosY + 15);
                    p_objGrp.DrawString("手术、操\n 作编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 615, p_intPosY + 8);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 210, p_intPosY + 23, (int)enmRectangleInfo.LeftX + 390, p_intPosY + 23);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 270, p_intPosY + 23, (int)enmRectangleInfo.LeftX + 270, p_intPosY + 260);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 330, p_intPosY + 23, (int)enmRectangleInfo.LeftX + 330, p_intPosY + 260);

                    p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 52, m_intRecBaseX + 729, p_intPosY + 52);
                    p_intPosY += (int)enmRectangleInfo.RowStep * 2;
                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    Font fotNow = new Font("SimSun", 9f);
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 51, p_intPosY, 160, 30);
                    for (int i = 0; i < m_objDataArr.Length; i++)
                    {
                        object[] m_objSubDataArr = (object[])m_objDataArr[i];
                        if (m_objSubDataArr[0].ToString() != "")
                        {
                            p_objGrp.DrawString(DateTime.Parse(m_objSubDataArr[0].ToString()).ToString("yyyy-MM-dd"), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 34, p_intPosY - 5);
                            p_objGrp.DrawString(DateTime.Parse(m_objSubDataArr[0].ToString()).ToString("HH:mm"), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 14, p_intPosY + 8);
                        }
                        if (m_objSubDataArr[1].ToString().Length > 11)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 51, p_intPosY, 160, 30);
                            if (m_objSubDataArr[1].ToString().Length > 12)
                            {
                                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 51, p_intPosY - 5, 160, 30);
                            }
                            p_objGrp.DrawString(m_objSubDataArr[1].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 51, p_intPosY, 160, 30);
                            p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                        }
                        if (m_objSubDataArr[2].ToString().Length > 3)
                        {
                            p_objGrp.DrawString(m_objSubDataArr[2].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 211, p_intPosY);
                        }
                        else
                        {
                            p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 211, p_intPosY);
                        }
                        if (m_objSubDataArr[3].ToString().Length > 3)
                        {
                            p_objGrp.DrawString(m_objSubDataArr[3].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 271, p_intPosY);
                        }
                        else
                        {
                            p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 271, p_intPosY);
                        }
                        if (m_objSubDataArr[4].ToString().Length > 3)
                        {
                            p_objGrp.DrawString(m_objSubDataArr[4].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 331, p_intPosY);
                        }
                        else
                        {
                            p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 331, p_intPosY);
                        }
                        if (m_objSubDataArr[5].ToString().Length > 5)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 391, p_intPosY, 100, 30);
                            if (m_objSubDataArr[5].ToString().Length > 6)
                            {
                                rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 391, p_intPosY - 5, 100, 30);
                            }
                            p_objGrp.DrawString(m_objSubDataArr[5].ToString(), fotNow, Brushes.Black, rtgf);
                        }
                        else
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 391, p_intPosY, 160, 30);
                            p_objGrp.DrawString(m_objSubDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, rtgf);
                        }
                        p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 471, p_intPosY);
                        p_objGrp.DrawString(m_objSubDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 531, p_intPosY);
                        p_objGrp.DrawString(m_objSubDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 611, p_intPosY);

                        p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                        p_intPosY += (int)enmRectangleInfo.RowStep;
                    }
                    if (m_objDataArr.Length < 7)
                    {
                        m_mthDrawLine(p_objGrp, 7 - m_objDataArr.Length, ref p_intPosY);
                    }

                }
                else
                {
                    m_mthDrawLine(p_objGrp, 7, ref p_intPosY);
                }
                m_blnHaveMoreLine = false;
            }

            private void m_mthDrawLine(System.Drawing.Graphics p_objGrp, int p_intLows, ref int p_intPosY)
            {
                for (int i = 0; i < p_intLows; i++)
                {
                    p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                }
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
                m_objText2.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #endregion



        private class clsPrintLine103 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine103()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("新生儿疾病诊断: 1.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 100, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        #region 104 ~ 109
        private class clsPrintLine104 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine104()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               2.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 100, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine105 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine105()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               3.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 100, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine106 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine106()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               4.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 100, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine107 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine107()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("抢救次数", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    p_objGrp.DrawString("成功次数", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY);
                    p_objGrp.DrawString("随诊     1.是   2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 340, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("随诊期限：", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 500, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 45, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 210, p_intPosY);
                if ((m_objDataArr[2]).ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 342, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 565, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine108 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine108()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("诊断符合情况：", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);

                    p_objGrp.DrawString("门诊─出院", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 150, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("入院─出院", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 280, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("术前─术后        0.无 1.符合 2.不符 3.待查", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 330, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 410, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 152, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 282, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 412, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine109 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine109()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("临床─病理", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 150, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("死亡─尸检", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 280, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("临床─放射", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 330, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 410, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 152, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 282, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 412, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;

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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }



        #endregion

        private class clsPrintLine110 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine110()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("示教病例", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 30, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("手术、治疗、检查、诊断为本院第一例    1.是  2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 340, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("病案质量    1.甲  2.乙  3.丙", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 460, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 520, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                if (m_objDataArr[0].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 32, p_intPosY);
                if (m_objDataArr[1].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 342, p_intPosY);
                if (m_objDataArr[2].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 522, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine111 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine111()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("抗菌药物使用    1.是  2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 60, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("病原学送检    1.是  2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 190, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 270, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("病原学送检结果    1.阳性  2.阴性", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 390, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 500, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                if (m_objDataArr[0].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 62, p_intPosY);
                if (m_objDataArr[1].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 272, p_intPosY);
                if (m_objDataArr[2].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 502, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine112 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;

            public clsPrintLine112()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("输血反应", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 30, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("输液反应", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 90, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 160, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("CT检查", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 220, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 270, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("MRI检查                  1.有    2.无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 340, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 400, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                if (m_objDataArr[0].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 32, p_intPosY);
                if (m_objDataArr[1].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 162, p_intPosY);
                if (m_objDataArr[2].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 272, p_intPosY);
                if (m_objDataArr[3].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 402, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine113 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private clsPublicControlPaint m_objCPaint;
            public clsPrintLine113()
            {
                m_objCPaint = new clsPublicControlPaint();
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("血型        0.不详  1.A  2.B  3.AB  4.O", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 5, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("Rh        0.不详  1.阴  2.阳", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 400, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint((int)enmRectangleInfo.LeftX + 425, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                }
                if (m_objDataArr[0].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 7, p_intPosY);
                if (m_objDataArr[1].ToString() != "-1")
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 427, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine114 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine114()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("输血品种： 1.红细胞      单位  2.血小板      袋  3.血浆      ml  4.全血      ml  5.其它      ml", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 260, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 380, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 505, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 625, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine115 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine115()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("科主任_______________  主治医师_______________  入院医师_______________  出院医师_______________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 200, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 390, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 570, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine116 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine116()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("主任医师_____________ ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 35, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }
            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine117 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine117()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("副主任医师___________  进修医师_______________  研究生实习医师_________  实习医师_______________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 50, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 200, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 430, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 570, p_intPosY);
                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX, p_intPosY + 22, m_intRecBaseX + 729, p_intPosY + 22);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine118 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine118()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("住院费用总计(元):__________  床位__________  护理费__________  西药__________  中成药__________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 90, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 220, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 350, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 460, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 590, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_objText1.m_mthRestartPrint();
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine119 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine119()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("中草药________  放射________  化验________  输氧________  输血________  诊疗________  手术________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 220, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 325, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 430, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 530, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 635, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine120 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine120()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("检查__________  麻醉________  接生________  婴儿费______  陪床费______  其他_____________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 5, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 220, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 340, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 440, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 530, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine121 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine121()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("整理________________  编码________________  入机________________  统计________________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 10, p_intPosY);
                    p_objGrp.DrawString("诊断依据：有病理证实在诊断名前加“#”，细胞学证实加“△”，细菌证实加“＋”，临床诊断不加符号。", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX - 35, p_intPosY + 25);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 25, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 190, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 360, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 520, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
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
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #endregion

        #region 打印边框
        /// <summary>
        /// 打印边框
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            Font fntHeader = new Font("SimSun", 12);

            if (m_intCurrentPage == 1)
                e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX, 185, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, e.PageBounds.Height - 390);
            if (m_intCurrentPage == 2)
                e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, e.PageBounds.Height - 353);
        }
        #endregion
    }
}
