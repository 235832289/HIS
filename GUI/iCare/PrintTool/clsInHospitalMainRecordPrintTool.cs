using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.IO;
using com.digitalwave.iCare.middletier.LIS;

namespace iCare
{
    /// <summary>
    /// 病案首页版的打印工具类
    /// </summary>
    public class clsInHospitalMainRecordPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsInHospitalMainRecordDomain m_objRecordsDomain;
        private clsPrintInfo_InHospitalMainRecord m_objPrintInfo;
        private clsInHospitalMainRecord_Collection m_objCollection;
        private clsInHospitalMainRecord_Content m_objRecordcontent = null;
        public string m_strOperation = "0";
        public string m_strBaby = "0";
        public string m_strChemotherapy = "0";
        public static int m_intLeftX = (int)enmRectangleInfo.LeftX1;
        public static int m_intRightX = (int)enmRectangleInfo.RightX1;
        public static int m_intPosY = 0;//出院诊断竖线的y起始位置
        public static int m_intRows = 0;//主要诊断，其他诊断，医院感染名称总共占的行数
        public static int m_intCurrentIndex = 0;//其他诊断当前行
        public static int m_intPages = 1;//当前页码
        public static int m_intIndex = 0;//住院费用以后打印到第几行
        private static string m_strNewBabyWeight;
        private static string m_strNewBabyInhospitalWeight;
        private static string strRegisterID;
        /// <summary>
        /// 调整像素.底线打不全
        /// </summary>
        public static int adjustPix = 3;

        /// <summary>
        /// 是否打印题目，打印预览时为true，套打时为false
        /// </summary>
        private static bool s_blnPrintTitle = false;

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

        public clsInHospitalMainRecordPrintTool(bool p_blnPrintTitle)
        {
            s_blnPrintTitle = p_blnPrintTitle;
        }

        public clsInHospitalMainRecordPrintTool()
        {
        }

        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            m_objPrintInfo = new clsPrintInfo_InHospitalMainRecord();
            m_objRecordsDomain = new clsInHospitalMainRecordDomain();
            m_objRecordsDomain.m_mthSetPrintInfo(p_objPatient, p_dtmInPatientDate, p_dtmOpenDate, ref m_objPrintInfo);

            //System.Windows.Forms.MessageBox.Show(m_objPrintInfo.m_objPeopleInfo.m_StrAgeLong);
            #region 获取入院，出院，转科信息NEW
            clsInHospitalMainTransDeptInstance objTransDeptInstance = null;
            strRegisterID = p_objPatient != null ? p_objPatient.m_StrRegisterId : "";
            string strChangeDept = "";
            long lngRes = m_objRecordsDomain.m_lngGetInHospitalMainTransDeptInstance(strRegisterID, out objTransDeptInstance);
            if (lngRes > 0 && objTransDeptInstance != null)
            {
                if (objTransDeptInstance.m_demOutPatientDate != new DateTime(1900, 1, 1) && objTransDeptInstance.m_demOutPatientDate != DateTime.MinValue)
                    m_objPrintInfo.m_dtmOutHospitalDate = objTransDeptInstance.m_demOutPatientDate;

                m_objPrintInfo.m_strInHosptialSetionName = objTransDeptInstance.m_strInPatientAreaName;
                //m_objPrintInfo.m_strInSickRoomName = objTransDeptInstance.m_strInPatientAreaName + objTransDeptInstance.m_strInPatientBedName; //病取+病床
                m_objPrintInfo.m_strInSickRoomName = objTransDeptInstance.m_strInPatientBedName; //修改 ，病床
                m_objPrintInfo.m_strOutHosptialSetionName = objTransDeptInstance.m_strOutPatientAreaName;
                m_objPrintInfo.m_strOutSickRoomName = objTransDeptInstance.m_strOutPatientBedName; //修改 ，病床
                //m_objPrintInfo.m_strOutSickRoomName = objTransDeptInstance.m_strOutPatientAreaName + objTransDeptInstance.m_strOutPatientBedName;  //病取+病床
                if (objTransDeptInstance.m_strTransSourceAreaIDArr != null
                    && objTransDeptInstance.m_strTransTargetAreaIDArr != null
                    && objTransDeptInstance.m_strTransSourceAreaIDArr.Length == objTransDeptInstance.m_strTransTargetAreaIDArr.Length)
                {
                    for (int i = 0; i < objTransDeptInstance.m_strTransTargetAreaIDArr.Length; i++)
                    {
                        strChangeDept += objTransDeptInstance.m_strTransTargetAreaNameArr[i] + "(" + objTransDeptInstance.m_strTransAreaDateArr[i].Substring(0, 13).Replace("-", "") + "),";
                    }
                }
            }
            #endregion

            m_objPrintInfo.m_strChangeDept = strChangeDept;
        }

        private bool m_blnNeedModifyFlag = true;
        /// <summary>
        /// 是否需要清空众邦系统已打印的病人信息
        /// </summary>
        public bool m_BlnNeedModifyFlag
        {
            set
            {
                m_blnNeedModifyFlag = value;
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
                MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }
            if (m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_dtmInPatientDate == DateTime.MinValue || m_objPrintInfo.m_dtmOpenDate == DateTime.MinValue)
                m_objCollection = null;
            else
            {
                long lngRes = m_objRecordsDomain.m_lngGetAllInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objCollection);

                //m_objRecordsDomain.m_lngGetSelfPay(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate, out m_objRecordcontent);
                m_objRecordsDomain.m_lngGetSelfPay(strRegisterID, out m_objRecordcontent);
                if (lngRes <= 0)
                    return;

                #region  第一次打印时间赋值
                string strFirstPrintDate = "";
                m_objRecordsDomain.m_strGetFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out strFirstPrintDate);

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
            DateTime dtmTemp;
            try
            {
                if (m_objPrintInfo.m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_objPrintInfo.m_dtmOutHospitalDate == DateTime.MinValue)
                {
                    dtmTemp = DateTime.Now;
                }
                else
                {
                    dtmTemp = m_objPrintInfo.m_dtmOutHospitalDate;
                }

                //dtmTemp = DateTime.Parse(m_objPrintInfo.m_objCollection.m_objContent.m_strOutPatientDate);
            }
            catch
            {
                if (m_objPrintInfo.m_objCollection == null && m_objPrintInfo.m_dtmOutHospitalDate != DateTime.MinValue)
                {
                    dtmTemp = m_objPrintInfo.m_dtmOutHospitalDate;
                }
                else
                {
                    dtmTemp = DateTime.Parse("1900-01-01 00:00:00");
                }
            }
            //m_objPrintInfo.m_dtmOutHospitalDate = dtmTemp;
            if (dtmTemp == new DateTime(1900, 1, 1) || dtmTemp == DateTime.MinValue)
            {
                com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objPMT =
                    (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

                string strDateNow = objPMT.m_strGetDBServerTime(null);
                objPMT = null;
                if (!DateTime.TryParse(strDateNow, out dtmTemp))
                {
                    dtmTemp = DateTime.Now;
                }
            }
            System.TimeSpan diff = dtmTemp.Subtract(m_objPrintInfo.m_dtmHISInPatientDate);
            if (diff.Days < 1)
                m_objPrintInfo.m_strInHospitalDays = "1";
            else if (dtmTemp == new DateTime(1900, 1, 1) || dtmTemp == DateTime.MinValue)
            {
                diff = Convert.ToDateTime(dtmTemp.ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy-MM-dd")));
                m_objPrintInfo.m_strInHospitalDays = diff.Days.ToString();
            }
            else
            {
                diff = Convert.ToDateTime(dtmTemp.ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy-MM-dd")));
                m_objPrintInfo.m_strInHospitalDays = diff.Days.ToString();
            }
            //m_objPrintInfo.m_strInHospitalDays = ((int)diff.TotalDays + 1).ToString();
            if (m_objPrintInfo.m_objCollection != null && m_objPrintInfo.m_objCollection.m_objContent != null)
            {
                m_strOperation = m_objPrintInfo.m_objCollection.m_objContent.m_strOperation;
                m_strBaby = m_objPrintInfo.m_objCollection.m_objContent.m_strBaby;
                m_strChemotherapy = m_objPrintInfo.m_objCollection.m_objContent.m_strChemotherapy;
            }
            m_mthSetPrintValue();//无论有否打印数据,即使在打印空白表时,此行也必须执行.
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_InHospitalMainRecord")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_InHospitalMainRecord)p_objPrintContent;
            m_objCollection = m_objPrintInfo.m_objCollection;
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
                    MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
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

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化
            m_fotTitleFont = new Font("黑体", 14);//黑体小三
            m_fotHeaderFont = new Font("黑体", 18, FontStyle.Bold);//黑体小二加粗
            m_fotRetangleFont = new Font("SimSun", 16);
            m_fotSmallFont = new Font("SimSun", 10.5f);
            m_GridPen = new Pen(Color.Black, 0.2f);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            m_bolIfFirst = true;
            #endregion
        }

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
            //			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
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
                long lngRes = m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (lngRes <= 0)
                {
                    switch (lngRes)
                    {
                        case (long)iCareData.enmOperationResult.Not_permission:
                            MDIParent.s_mthShowNotPermitMessage();
                            break;
                        case (long)iCareData.enmOperationResult.DB_Fail:
                            //							MDIParent.ShowInformationMessageBox("更新打印时间失败");
                            break;
                    }
                    return;
                }
            }
        }

        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作
        }
        // 打印页

        private void m_mthPrintPageSub(PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            GraphicsUnit enmOld = e.Graphics.PageUnit;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            if (m_bolIfFirst && s_blnPrintTitle)
            {
                m_mthPrintTitleInfo(e);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX - 2, (int)enmRectangleInfo.TopY1 - 2 + 14 - adjustPix, (int)enmRectangleInfo.RightX, (int)enmRectangleInfo.TopY1 - 2 + 14 - adjustPix);
            }

            while (m_objPrintContext.m_BlnHaveMoreLine)
            {
                m_objPrintContext.m_mthPrintNextLine(ref m_intYPos, e.Graphics, m_fotSmallFont);

                if (m_intYPos == 1000 && m_objPrintContext.m_BlnHaveMoreLine)
                {
                    e.HasMorePages = true;
                    m_bolIfFirst = false;
                    m_intYPos = 17;
                    return;
                }
            }
            //全部打完
            //			m_objPrintContext.m_mthReset();
            //			m_intYPos = (int)enmRectangleInfo.TopY1;
            e.Graphics.PageUnit = enmOld;
            //			m_bolIfFirst = true;
        }

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
            m_objPrintContext.m_mthReset();
            m_intYPos = (int)enmRectangleInfo.TopY1;
            m_bolIfFirst = true;
        }

        #region	打印

        #region 有关打印的声明
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
        //		private int m_intYPos = (int)enmRectangleInfo.TopY + 12;
        private int m_intYPos = (int)enmRectangleInfo.TopY1;
        //		private int m_intPreY = (int)enmRectangleInfo.TopY;
        //		private int m_intEndIndex = 0;
        //		private int m_intPages=1;

        private class clsEveryRecordPageInfo
        {
            public string m_strModeOfPayment;
            public string m_strInsuranceNum;
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
            TopY = 260,
            TopY1 = 41,
            /// <summary>
            /// 从主要诊断开始打
            /// </summary>
            TopY2 = 73,

            ///<summary>
            /// 格子的左端
            /// </summary>
            //			LeftX = 78,
            LeftX = 15,
            LeftX1 = 10,
            /// <summary>
            /// 格子的右端
            /// </summary>
            //			RightX = 827-30,
            RightX = 180 + 17,
            RightX1 = 200,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            //			RowStep = 25,
            RowStep = 7,
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

            BottomY = 1124
        }

        #region 打印行定义
        private clsPrintLine1 m_objLine1;
        private clsPrintLine2 m_objLine2;
        private clsPrintLine2A m_objLine2A;
        private clsPrintLine2B m_objLine2B;
        private clsPrintLine3A m_objLine3A;
        private clsPrintLine3 m_objLine3;
        private clsPrintLine4 m_objLine4;
        private clsPrintLine5 m_objLine5;
        private clsPrintLine6 m_objLine6;
        private clsPrintLine7 m_objLine7;
        // private clsPrintLine8a m_objLine8a;
        private clsPrintLine8 m_objLine8;
        //private clsPrintLine9 m_objLine9;
        private clsPrintLine10 m_objLine10;
        private clsPrintLine11 m_objLine11;
        private clsPrintLine12 m_objLine12;
        private clsPrintLine13 m_objLine13;
        private clsPrintLine14 m_objLine14;
        private clsPrintLine14a m_objLine14a;
        private clsPrintLine15 m_objLine15;
        private clsPrintLine16 m_objLine16;
        private clsPrintLine17 m_objLine17;
        //private clsPrintLine18 m_objLine18;
        private clsPrintLine19 m_objLine19;
        private clsPrintLine20 m_objLine20;
        private clsPrintLine21 m_objLine21;
        //		private clsPrintLine22 m_objLine22;
        //		private clsPrintLine23 m_objLine23;
        //		private clsPrintLine24 m_objLine24;
        //		private clsPrintLine25 m_objLine25;
        //		private clsPrintLine26 m_objLine26;
        //		private clsPrintLine27 m_objLine27;
        private clsPrintLine100 m_objLine100;
        private clsPrintLine101 m_objLine101;
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
        private clsPrintLine120a m_objLine120a;
        private clsPrintLine121 m_objLine121;
        private clsPrintLine122 m_objLine122;
        private clsPrintLine123 m_objLine123;
        private clsPrintLine124 m_objLine124;
        private clsPrintLine125 m_objLine125;
        private clsPrintLine126 m_objLine126;
        private clsPrintLine127 m_objLine127;
        private clsPrintLine128 m_objLine128;
        private clsPrintLine129 m_objLine129;

        private clsPrintLine130 m_objLine130;
        private clsPrintLine131 m_objLine131;
        private clsPrintLine132 m_objLine132;
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
                float fltOffsetX = 0;//X的偏移量
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {
                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(90f - fltOffsetX, 15f + 10f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(79f - fltOffsetX, 23f + 10f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(18f - fltOffsetX, 33f + 10f);
                        break;
                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;
                }
                return m_fReturnPoint;
                return m_fReturnPoint;
            }
        }

        #endregion
        #endregion

        private bool m_bolIfFirst = true;

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 0;//X的偏移量
            clsEveryRecordPageInfo objEveryRecordPageInfo = new clsEveryRecordPageInfo();
            //************************************************
            if (m_objCollection != null && m_objCollection.m_objContent != null)
            {
                objEveryRecordPageInfo.m_strInsuranceNum = m_objCollection.m_objContent.m_strInsuranceNum;// txtInsuranceNum.Text;
                objEveryRecordPageInfo.m_strTimes = m_objPrintInfo.m_strTimes;//lblTimes.Text;
                objEveryRecordPageInfo.m_strModeOfPayment = m_objCollection.m_objContent.m_strModeOfPayment;//txtModeOfPayment.Text;
                objEveryRecordPageInfo.m_strPatientHistoryNO = m_objCollection.m_objContent.m_strPatientHistoryNO;// txtPatientHistoryNO.Text;
            }
            else
            {
                objEveryRecordPageInfo.m_strInsuranceNum = "";
                objEveryRecordPageInfo.m_strTimes = "";
                objEveryRecordPageInfo.m_strModeOfPayment = "";
                objEveryRecordPageInfo.m_strPatientHistoryNO = "";
            }
            string m_strModeOfPayment = objEveryRecordPageInfo.m_strModeOfPayment;
            if (m_strModeOfPayment.Length >= 2)
            {

                try
                {
                    switch (m_strModeOfPayment.Substring(0, 3))
                    {
                        case "城镇职":
                            m_strModeOfPayment = "1";
                            break;
                        case "城镇居":
                            m_strModeOfPayment = "2";
                            break;
                        case "新型农":
                            m_strModeOfPayment = "3";
                            break;
                        case "贫困救":
                            m_strModeOfPayment = "4";
                            break;
                        case "商业医":
                            m_strModeOfPayment = "5";
                            break;
                        case "全公费":
                            m_strModeOfPayment = "6";
                            break;
                        case "全自费":
                            m_strModeOfPayment = "7";
                            break;
                        case "其他社":
                            m_strModeOfPayment = "8";
                            break;
                        default:
                            m_strModeOfPayment = "9";
                            break;
                    }
                }
                catch
                {
                    throw;
                }

            }
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            GraphicsUnit enmOld = e.Graphics.PageUnit;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            //SizeF szHospitalNameWide = e.Graphics.MeasureString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotTitleFont);

            SizeF szTitleWide = e.Graphics.MeasureString("住 院 病 案 首 页 ※", m_fotHeaderFont);
            //float fltHospitalNamePoint = m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).X + szTitleWide.Width / 2 - szHospitalNameWide.Width / 2;
            //e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotTitleFont, m_slbBrush, fltHospitalNamePoint ,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y);            
            e.Graphics.DrawString("医疗机构：                    (卫生机构(组织)代码：             )", m_fotTitleFont, m_slbBrush, 18f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y);
            e.Graphics.DrawLine(m_pen, 42f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y + 5, 90f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y + 5);
            e.Graphics.DrawLine(m_pen, 142f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y + 5, 198f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y + 5);
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotTitleFont, m_slbBrush, 43f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y);
            e.Graphics.DrawString("45722632-5", m_fotTitleFont, m_slbBrush, 143f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).Y);

            e.Graphics.DrawString("住 院 病 案 首 页 ※", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));
            e.Graphics.DrawString("医疗付费方式：", m_fotSmallFont, m_slbBrush, 18f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).Y + 3);
            e.Graphics.DrawRectangle(new Pen(m_slbBrush, 0.1f), 44 - fltOffsetX, 26 + 10, 3, 3);
            e.Graphics.DrawString(m_strModeOfPayment, m_fotSmallFont, m_slbBrush, 44f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).Y + 3);
            e.Graphics.DrawString("健康卡号：", m_fotSmallFont, m_slbBrush, 18f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strInsuranceNum, m_fotSmallFont, m_slbBrush, 36f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);
            e.Graphics.DrawString("第     次住院", m_fotSmallFont, m_slbBrush, 106f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strTimes, m_fotSmallFont, m_slbBrush, 114f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);
            e.Graphics.DrawString("病案号：___________ ", m_fotSmallFont, m_slbBrush, 153f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strPatientHistoryNO, m_fotSmallFont, m_slbBrush, 169f - fltOffsetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title).Y);

            e.Graphics.PageUnit = enmOld;
        }

        #endregion

        private void m_mthSetPrintValue()
        {
            #region 打印行初始化
            m_objLine1 = new clsPrintLine1();
            m_objLine2 = new clsPrintLine2();
            //m_objLine2A = new clsPrintLine2A();
            //m_objLine2B = new clsPrintLine2B();
            //m_objLine3A = new clsPrintLine3A();
            m_objLine3 = new clsPrintLine3();
            m_objLine4 = new clsPrintLine4();
            m_objLine5 = new clsPrintLine5();
            m_objLine6 = new clsPrintLine6();
            m_objLine7 = new clsPrintLine7();
            // m_objLine8a = new clsPrintLine8a();
            m_objLine8 = new clsPrintLine8();
            //m_objLine9 = new clsPrintLine9();
            m_objLine10 = new clsPrintLine10();
            m_objLine11 = new clsPrintLine11();
            m_objLine12 = new clsPrintLine12();
            m_objLine13 = new clsPrintLine13();
            m_objLine14 = new clsPrintLine14();
            m_objLine14a = new clsPrintLine14a();
            m_objLine15 = new clsPrintLine15();
            m_objLine16 = new clsPrintLine16();
            m_objLine17 = new clsPrintLine17();
            //m_objLine18 = new clsPrintLine18();
            m_objLine19 = new clsPrintLine19();
            m_objLine20 = new clsPrintLine20();
            m_objLine21 = new clsPrintLine21();
            m_objLine100 = new clsPrintLine100();
            m_objLine101 = new clsPrintLine101(m_strOperation);
            m_objLine102 = new clsPrintLine102();
            m_objLine103 = new clsPrintLine103();
            m_objLine104 = new clsPrintLine104();
            m_objLine105 = new clsPrintLine105();
            m_objLine106 = new clsPrintLine106();
            m_objLine107 = new clsPrintLine107(m_strBaby);
            m_objLine108 = new clsPrintLine108();
            m_objLine109 = new clsPrintLine109();
            m_objLine110 = new clsPrintLine110();
            m_objLine111 = new clsPrintLine111();
            m_objLine112 = new clsPrintLine112();
            m_objLine113 = new clsPrintLine113();
            m_objLine114 = new clsPrintLine114();
            m_objLine115 = new clsPrintLine115();
            m_objLine116 = new clsPrintLine116();
            m_objLine117 = new clsPrintLine117(m_strChemotherapy);
            m_objLine118 = new clsPrintLine118();
            m_objLine119 = new clsPrintLine119();
            m_objLine120 = new clsPrintLine120();
            m_objLine120a = new clsPrintLine120a();
            m_objLine121 = new clsPrintLine121();
            m_objLine122 = new clsPrintLine122();
            m_objLine123 = new clsPrintLine123();
            m_objLine124 = new clsPrintLine124();
            m_objLine125 = new clsPrintLine125();
            m_objLine126 = new clsPrintLine126();
            m_objLine127 = new clsPrintLine127();
            m_objLine128 = new clsPrintLine128();
            m_objLine129 = new clsPrintLine129();
            m_objLine130 = new clsPrintLine130();
            m_objLine131 = new clsPrintLine131();
            m_objLine132 = new clsPrintLine132();
            m_objPrintContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
                    //m_objLine2A,
                    //m_objLine2A,
                    //m_objLine3A,
										  
										  m_objLine4,m_objLine3,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
                     //m_objLine8a,
										  m_objLine8,
										  
										  m_objLine10,
										  m_objLine11,
										  m_objLine12,//m_objLine9,
										  m_objLine13,
										  m_objLine14a,
										  m_objLine15,m_objLine14,
										  m_objLine16,
										  m_objLine17,
										 // m_objLine18,
										  m_objLine19,
										  m_objLine20,
										  m_objLine21,
										  m_objLine100,
										  m_objLine101,
										  m_objLine102,
										  m_objLine103,
                                          m_objLine119,
                                          m_objLine120a,
										  m_objLine120,
										  m_objLine121,
                                          m_objLine122,
                                          m_objLine123,
                                          m_objLine124,
                                          m_objLine125,
                                          m_objLine126,
                                          //m_objLine127,
                                          m_objLine128,
										  m_objLine129,
                                          m_objLine131,
                                          m_objLine132,
                                          m_objLine130,
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
										  m_objLine118									                					  
                                          
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
                if (m_objCollection.m_objContent.m_strBirthPlace != null)
                {
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strBirthPlace;
                }
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
                if (!m_bolIfCheck)
                {
                    m_strNewBabyInhospitalWeight = "";
                    m_strNewBabyWeight = "";
                }
                else
                {
                    m_strNewBabyInhospitalWeight = m_objCollection.m_objContent.m_strNewBabyInhostpitalWeight;
                    m_strNewBabyWeight = m_objCollection.m_objContent.m_strNewBabyWeight;
                }
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
                if (m_objPrintInfo.m_dtmHISInPatientDate != DateTime.MinValue && m_objPrintInfo.m_dtmHISInPatientDate != new DateTime(1900, 1, 1))
                {
                    m_objDataArr[0] = m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy    MM    dd   HH");
                }
                else
                {
                    m_objDataArr[0] = "";
                }
                m_objDataArr[1] = (m_objPrintInfo.m_strInHosptialSetionName == null ? "" : m_objPrintInfo.m_strInHosptialSetionName);//lblInHosptialSetion.Text;
                m_objDataArr[2] = (m_objPrintInfo.m_strInSickRoomName == null ? "" : m_objPrintInfo.m_strInSickRoomName);//lblInSickRoom.Text;

                m_objDataArr[3] = m_objPrintInfo.m_strChangeDept;
                if (!m_bolIfCheck)
                {
                    m_objDataArr[4] = "";
                }
                else
                    m_objDataArr[4] = m_objCollection.m_objContent.m_strInhospitalWay;
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

            m_objDataArr = new Object[4];
            if (m_objPrintInfo.m_strInPatentID != "" && m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
            {
                DateTime dtmOut;
                try
                {
                    dtmOut = m_objPrintInfo.m_dtmOutHospitalDate;
                }
                catch { dtmOut = DateTime.Parse("1900-1-1"); }
                if (dtmOut > m_objPrintInfo.m_dtmHISInPatientDate)
                {
                    m_objDataArr[0] = dtmOut.ToString("yyyy    MM    dd   HH");
                    m_objDataArr[1] = (m_objPrintInfo.m_strOutHosptialSetionName == null ? "" : m_objPrintInfo.m_strOutHosptialSetionName);
                    m_objDataArr[2] = (m_objPrintInfo.m_strOutSickRoomName == null ? "" : m_objPrintInfo.m_strOutSickRoomName);
                }
                else
                {
                    m_objDataArr[0] = "";
                    m_objDataArr[1] = "";
                    m_objDataArr[2] = "";
                }
                m_objDataArr[3] = (m_objPrintInfo.m_strInHospitalDays == null ? "" : m_objPrintInfo.m_strInHospitalDays);

            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine7.m_ObjPrintLineInfo = m_objDataArr;



            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strpath;

            }
            else
            {
                m_objDataArr[0] = "";

            }
            //m_objLine8a.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strDiagnosis;//mzicd10

                if (m_objCollection.m_objContent.m_strDoctor == null || m_objCollection.m_objContent.m_strDoctorName == null)
                    m_objDataArr[1] = "";
                else
                {
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strDoctorName;
                }


                //m_objDataArr[2] = int.Parse(m_objCollection.m_objContent.m_strCondictionWhenIn) + 1;//su.liang
                m_objDataArr[2] = m_objCollection.m_objMain.m_strMZICD10;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine8.m_ObjPrintLineInfo = m_objDataArr;

            ArrayList alTemp = new ArrayList();
            int intCounts = 1;
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objDiagnosisArr != null && m_objCollection.m_objDiagnosisArr.Length > 0)
                {
                    System.Collections.Generic.List<object> lstObj = new System.Collections.Generic.List<object>();
                    for (int iD = 0; iD < m_objCollection.m_objDiagnosisArr.Length; iD++)
                    {
                        if (m_objCollection.m_objDiagnosisArr[iD].m_strDIAGNOSISTYPE == "1")
                        {
                            alTemp.Add(m_objCollection.m_objDiagnosisArr[iD].m_strDIAGNOSIS);
                            intCounts++;
                        }
                        m_objDataArr = new Object[intCounts];
                        for (int j = 0; j < intCounts - 1; j++)
                        {
                            m_objDataArr[j] = alTemp[j];
                        }


                    }
                }
                if (DateTime.Parse(m_objCollection.m_objContent.m_strConfirmDiagnosisDate) != DateTime.MinValue && m_objCollection.m_objContent.m_strConfirmDiagnosisDate != "1900-1-1 0:00:00")
                    m_objDataArr[intCounts - 1] = DateTime.Parse(m_objCollection.m_objContent.m_strConfirmDiagnosisDate).ToString("yyyy    MM    dd  ");
                else m_objDataArr[intCounts - 1] = "";

            }
            else
            {
                //m_objDataArr[0] = "";
                //m_objDataArr[1] = "";
            }
            //m_objLine9.m_ObjPrintLineInfo = m_objDataArr;


            m_objLine10.m_ObjPrintLineInfo = null;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strMainDiagnosis;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strMainConditionSeq;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strICD_10OfMain;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine11.m_ObjPrintLineInfo = m_objDataArr;

            if (m_bolIfCheck == false || m_objCollection.m_objDiagnosisArr == null || m_objCollection.m_objDiagnosisArr.Length <= 0)
            {
                m_objLine12.m_ObjPrintLineInfo = null;
            }
            else
            {
                if (m_objCollection.m_objDiagnosisArr.Length > 0)
                {
                    System.Collections.Generic.List<object> lstObj = new System.Collections.Generic.List<object>();

                    for (int i1 = 0; i1 < m_objCollection.m_objDiagnosisArr.Length; i1++)
                    {
                        if (m_objCollection.m_objDiagnosisArr[i1].m_strDIAGNOSISTYPE == "3")
                        {
                            m_objSubDataArr = new object[3];
                            m_objSubDataArr[0] = m_objCollection.m_objDiagnosisArr[i1].m_strDIAGNOSIS;
                            m_objSubDataArr[1] = m_objCollection.m_objDiagnosisArr[i1].m_strRESULT;
                            m_objSubDataArr[2] = m_objCollection.m_objDiagnosisArr[i1].m_strICD10;
                            lstObj.Add(m_objSubDataArr);
                        }
                    }
                    m_objDataArr = lstObj.ToArray();
                    m_objLine12.m_ObjPrintLineInfo = m_objDataArr;
                }
            }

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = string.Empty;
                m_objDataArr[1] = string.Empty;
                m_objDataArr[2] = string.Empty;
                if (m_objCollection.m_objDiagnosisArr != null && m_objCollection.m_objDiagnosisArr.Length > 0)
                {
                    for (int iD = 0; iD < m_objCollection.m_objDiagnosisArr.Length; iD++)
                    {
                        if (m_objCollection.m_objDiagnosisArr[iD].m_strDIAGNOSISTYPE == "2")
                        {
                            m_objDataArr[0] = m_objCollection.m_objDiagnosisArr[iD].m_strDIAGNOSIS;
                            m_objDataArr[1] = m_objCollection.m_objDiagnosisArr[iD].m_strRESULT;
                            m_objDataArr[2] = m_objCollection.m_objDiagnosisArr[iD].m_strICD10;
                            break;
                        }
                    }
                }
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }

            m_objLine13.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strPathologyDiagnosis;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strBLZD_blh;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strBLZD_jbbm;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine14.m_ObjPrintLineInfo = m_objDataArr;
            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strCondictionWhenIn;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strpath;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strSalveTimes;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strSalveSuccess;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine14a.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strScacheSource;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strSSZYJ_jbbm;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine15.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strSensitive;
                if (m_objCollection.m_objContent.m_strCorpseCheck == "True" || m_objCollection.m_objContent.m_strCorpseCheck == "1")
                    m_objDataArr[1] = "1";
                else if (m_objCollection.m_objContent.m_strCorpseCheck == "False" || m_objCollection.m_objContent.m_strCorpseCheck == "0")
                    m_objDataArr[1] = "2";
                else
                    m_objDataArr[1] = "";
                //m_objDataArr[1] = m_objCollection.m_objContent.m_strHbsAg;
                //m_objDataArr[2] = m_objCollection.m_objContent.m_strHCV_Ab;
                //m_objDataArr[3] = m_objCollection.m_objContent.m_strHIV_Ab;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                //m_objDataArr[2] = "";
                //m_objDataArr[3] = "";
            }
            m_objLine16.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strBloodType.ToString() == "")
                    m_objDataArr[0] = "6";
                else
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strBloodType;
                //if (m_objCollection.m_objContent.m_strBloodRh == "True" || m_objCollection.m_objContent.m_strBloodRh == "1")
                //    m_objDataArr[1] = "1";
                //else
                //    m_objDataArr[1] = "2";
                if (m_objCollection.m_objContent.m_strBloodRh.ToString() == "")
                    m_objDataArr[1] = "4";
                else
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strBloodRh.ToString();
                //m_objDataArr[0] = m_objCollection.m_objContent.m_strAccordWithOutHospital;
                //m_objDataArr[1] = m_objCollection.m_objContent.m_strAccordInWithOut;
                //m_objDataArr[2] = m_objCollection.m_objContent.m_strAccordBeforeOperationWithAfter;
                //m_objDataArr[3] = m_objCollection.m_objContent.m_strAccordClinicWithPathology;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                //m_objDataArr[2] = "";
                //m_objDataArr[3] = "";
            }
            m_objLine17.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strAccordRadiateWithPathology;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strSalveTimes;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strSalveSuccess;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            // m_objLine18.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strDirectorDt == null || m_objCollection.m_objContent.m_strDirectorDt == "")
                    m_objDataArr[0] = "";
                else
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strDirectorDtName;
                if (m_objCollection.m_objContent.m_strSubDirectorDt == null || m_objCollection.m_objContent.m_strSubDirectorDt == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strSubDirectorDtName;
                if (m_objCollection.m_objContent.m_strDt == null || m_objCollection.m_objContent.m_strDt == "")
                    m_objDataArr[2] = "";
                else
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strDtName;
                if (m_objCollection.m_objContent.m_strInHospitalDt == null || m_objCollection.m_objContent.m_strInHospitalDt == "")
                    m_objDataArr[3] = "";
                else
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strInHospitalDtName;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine19.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDt == null || m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDt == "")
                    m_objDataArr[0] = "";
                else
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDtName;
                if (m_objCollection.m_objContent.m_strGraduateStudentIntern == null || m_objCollection.m_objContent.m_strGraduateStudentIntern == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strGraduateStudentInternName;

                if (m_objCollection.m_objContent.m_strIntern == null || m_objCollection.m_objContent.m_strIntern == "")
                {
                    m_objDataArr[2] = "";
                }
                else
                {
                    //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                    //clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    //objEmployeeSign.m_lngGetEmpByNO(m_objCollection.m_objContent.m_strIntern, out objEmpVO);

                    m_objDataArr[2] = m_objCollection.m_objContent.m_strInternName;
                }
                //实习医生自己签名
                //m_objDataArr[2] = m_objCollection.m_objContent.m_strIntern;
                if (m_objCollection.m_objContent.m_strCoder == null || m_objCollection.m_objContent.m_strCoder == "")
                    m_objDataArr[3] = "";
                else
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strCoderName;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine20.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                int intQTemp = -1;
                if (int.TryParse(m_objCollection.m_objContent.m_strQuality, out intQTemp))
                {
                    m_objDataArr[0] = intQTemp + 1;
                }
                else
                {
                    m_objDataArr[0] = "";
                }
                if (m_objCollection.m_objContent.m_strQCDt == null || m_objCollection.m_objContent.m_strQCDt == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strQCDtName;
                if (m_objCollection.m_objContent.m_strQCNurse == null || m_objCollection.m_objContent.m_strQCNurse == "")
                    m_objDataArr[2] = "";
                else
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strQCNurseName;
                if (DateTime.Parse(m_objCollection.m_objContent.m_strQCTime) != DateTime.MinValue && m_objCollection.m_objContent.m_strQCTime != "1900-1-1 0:00:00")
                    m_objDataArr[3] = DateTime.Parse(m_objCollection.m_objContent.m_strQCTime).ToString("yyyy    MM    dd  ");
                else
                    m_objDataArr[3] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine21.m_ObjPrintLineInfo = m_objDataArr;

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
                    m_objSubDataArr = new object[11];
                    m_objSubDataArr[0] = m_objCollection.m_objOperationArr[i1].m_strOperationID;
                    m_objSubDataArr[1] = DateTime.Parse(m_objCollection.m_objOperationArr[i1].m_strOperationDate).ToString("yyyy-MM-dd");
                    m_objSubDataArr[2] = m_objCollection.m_objOperationArr[i1].m_strOperationName;
                    m_objSubDataArr[3] = m_objCollection.m_objOperationArr[i1].m_strOperatorName;
                    m_objSubDataArr[4] = m_objCollection.m_objOperationArr[i1].m_strAssistant1Name;
                    m_objSubDataArr[5] = m_objCollection.m_objOperationArr[i1].m_strAssistant2Name;
                    if (m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeID == null || m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeName == null)
                        m_objSubDataArr[6] = "";
                    else
                        m_objSubDataArr[6] = m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeName;
                    m_objSubDataArr[7] = m_objCollection.m_objOperationArr[i1].m_strCutLevel;
                    m_objSubDataArr[8] = m_objCollection.m_objOperationArr[i1].m_strAnaesthetistName;
                    if (m_objCollection.m_objOperationArr[i1].m_strOpreationLevel == "一级手术")
                        m_objSubDataArr[9] = "一级";
                    else if (m_objCollection.m_objOperationArr[i1].m_strOpreationLevel == "二级手术")
                        m_objSubDataArr[9] = "二级";
                    else if (m_objCollection.m_objOperationArr[i1].m_strOpreationLevel == "三级手术")
                        m_objSubDataArr[9] = "三级";
                    else if (m_objCollection.m_objOperationArr[i1].m_strOpreationLevel == "四级手术")
                        m_objSubDataArr[9] = "四级";
                    else
                        m_objSubDataArr[9] = "";
                    m_objSubDataArr[10] = m_objCollection.m_objOperationArr[i1].m_strOpreationElective;
                    for (int j2 = 0; j2 < 9; j2++)
                    {
                        if (m_objSubDataArr[j2] == null)
                            m_objSubDataArr[j2] = "";
                    }

                    m_objDataArr[i1] = m_objSubDataArr;
                }
                m_objLine102.m_ObjPrintLineInfo = m_objDataArr;
            }


            if (m_bolIfCheck == false || m_objCollection.m_objBabyArr == null || m_objCollection.m_objBabyArr.Length <= 0)
            {
                m_objLine109.m_ObjPrintLineInfo = null;
            }
            else
            {
                m_objDataArr = new Object[m_objCollection.m_objBabyArr.Length];

                for (int i1 = 0; i1 < m_objCollection.m_objBabyArr.Length; i1++)
                {
                    m_objSubDataArr = new object[18];
                    m_objSubDataArr[0] = m_objCollection.m_objBabyArr[i1].m_strSeqID;
                    if (m_objCollection.m_objBabyArr[i1].m_strMale == "True" || m_objCollection.m_objBabyArr[i1].m_strMale == "1")
                        m_objSubDataArr[1] = "√";
                    else
                        m_objSubDataArr[1] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strFemale == "True" || m_objCollection.m_objBabyArr[i1].m_strFemale == "1")
                        m_objSubDataArr[2] = "√";
                    else
                        m_objSubDataArr[2] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strLiveBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strLiveBorn == "1")
                        m_objSubDataArr[3] = "√";
                    else
                        m_objSubDataArr[3] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strDieBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strDieBorn == "1")
                        m_objSubDataArr[4] = "√";
                    else
                        m_objSubDataArr[4] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strDieNotBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strDieNotBorn == "1")
                        m_objSubDataArr[5] = "√";
                    else
                        m_objSubDataArr[5] = "";
                    m_objSubDataArr[6] = m_objCollection.m_objBabyArr[i1].m_strWeight;
                    if (m_objCollection.m_objBabyArr[i1].m_strDie == "True" || m_objCollection.m_objBabyArr[i1].m_strDie == "1")
                        m_objSubDataArr[7] = "√";
                    else
                        m_objSubDataArr[7] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strChangeDepartment == "True" || m_objCollection.m_objBabyArr[i1].m_strChangeDepartment == "1")
                        m_objSubDataArr[8] = "√";
                    else
                        m_objSubDataArr[8] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strOutHospital == "True" || m_objCollection.m_objBabyArr[i1].m_strOutHospital == "1")
                        m_objSubDataArr[9] = "√";
                    else
                        m_objSubDataArr[9] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strNaturalCondiction == "True" || m_objCollection.m_objBabyArr[i1].m_strNaturalCondiction == "1")
                        m_objSubDataArr[10] = "√";
                    else
                        m_objSubDataArr[10] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strSuffocate1 == "True" || m_objCollection.m_objBabyArr[i1].m_strSuffocate1 == "1")
                        m_objSubDataArr[11] = "√";
                    else
                        m_objSubDataArr[11] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strSuffocate2 == "True" || m_objCollection.m_objBabyArr[i1].m_strSuffocate2 == "1")
                        m_objSubDataArr[12] = "√";
                    else
                        m_objSubDataArr[12] = "";
                    m_objSubDataArr[13] = m_objCollection.m_objBabyArr[i1].m_strInfectionTimes;
                    m_objSubDataArr[14] = m_objCollection.m_objBabyArr[i1].m_strInfectionName;
                    m_objSubDataArr[15] = m_objCollection.m_objBabyArr[i1].m_strICD10;
                    m_objSubDataArr[16] = m_objCollection.m_objBabyArr[i1].m_strSalveTimes;
                    m_objSubDataArr[17] = m_objCollection.m_objBabyArr[i1].m_strSalveSuccessTimes;
                    m_objDataArr[i1] = m_objSubDataArr;
                }
                m_objLine109.m_ObjPrintLineInfo = m_objDataArr;
            }


            m_objDataArr = new Object[8];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = Convert.ToInt32(m_objCollection.m_objContent.m_strRTModeSeq) + 1;

                m_objDataArr[1] = Convert.ToInt32(m_objCollection.m_objContent.m_strRTRuleSeq) + 1;

                if (m_objCollection.m_objContent.m_strRTCo == "True" || m_objCollection.m_objContent.m_strRTCo == "1")
                    m_objDataArr[2] = "1";
                else if (m_objCollection.m_objContent.m_strRTAccelerator == "True" || m_objCollection.m_objContent.m_strRTAccelerator == "1")
                    m_objDataArr[2] = "2";
                else if (m_objCollection.m_objContent.m_strRTX_Ray == "True" || m_objCollection.m_objContent.m_strRTX_Ray == "1")
                    m_objDataArr[2] = "3";
                else if (m_objCollection.m_objContent.m_strRTLacuna == "True" || m_objCollection.m_objContent.m_strRTLacuna == "1")
                    m_objDataArr[2] = "4";
                else
                    m_objDataArr[2] = "";

                if (m_objCollection.m_objContent.m_strTumor != "-1" && m_objCollection.m_objContent.m_strTumor != null)
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strTumor;
                else
                    m_objDataArr[3] = "";

                if (m_objCollection.m_objContent.m_strT != "-1" && m_objCollection.m_objContent.m_strT != null)
                    m_objDataArr[4] = m_objCollection.m_objContent.m_strT;
                else
                    m_objDataArr[4] = "";

                if (m_objCollection.m_objContent.m_strN != "-1" && m_objCollection.m_objContent.m_strN != null)
                    m_objDataArr[5] = m_objCollection.m_objContent.m_strN;
                else
                    m_objDataArr[5] = "";

                if (m_objCollection.m_objContent.m_strM != "-1" && m_objCollection.m_objContent.m_strM != null)
                    m_objDataArr[6] = m_objCollection.m_objContent.m_strM;
                else
                    m_objDataArr[6] = "";

                if (m_objCollection.m_objContent.m_strInstallments != "-1" && m_objCollection.m_objContent.m_strInstallments != null)
                    m_objDataArr[7] = m_objCollection.m_objContent.m_strInstallments;
                else
                    m_objDataArr[7] = "";
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
                m_objDataArr[7] = "";
            }
            m_objLine111.m_ObjPrintLineInfo = m_objDataArr;
            //112
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strOriginalDiseaseSeq;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strOriginalDiseaseGy;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOriginalDiseaseTimes;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strOriginalDiseaseDays;
                string strPrintDate1 = m_objCollection.m_objContent.m_strOriginalDiseaseBeginDate == "1900-01-01 00:00:00" ? "                 " : DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseBeginDate).ToString("yy   MM   dd     ");
                strPrintDate1 += m_objCollection.m_objContent.m_strOriginalDiseaseEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseEndDate).ToString("yy   MM   dd   ");
                m_objDataArr[4] = strPrintDate1;// (m_objCollection.m_objContent.m_strOriginalDiseaseBeginDate == "1900-01-01 00:00:00" ? "              " : DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseBeginDate).ToString("yy   MM   dd  ")) + "   " + m_objCollection.m_objContent.m_strOriginalDiseaseEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseEndDate).ToString("yy   MM   dd   ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine112.m_ObjPrintLineInfo = m_objDataArr;

            //113

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strLymphSeq;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strLymphGy;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strLymphTimes;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strLymphDays;
                string strPrintDate2 = m_objCollection.m_objContent.m_strLymphBeginDate == "1900-01-01 00:00:00" ? "                 " : DateTime.Parse(m_objCollection.m_objContent.m_strLymphBeginDate).ToString("yy   MM   dd     ");
                strPrintDate2 += m_objCollection.m_objContent.m_strLymphEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strLymphEndDate).ToString("yy   MM   dd   ");
                m_objDataArr[4] = strPrintDate2; //(m_objCollection.m_objContent.m_strLymphBeginDate == "1900-01-01 00:00:00" ? "              " : DateTime.Parse(m_objCollection.m_objContent.m_strLymphBeginDate).ToString("yy   MM   dd  ")) + "   " + m_objCollection.m_objContent.m_strLymphEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strLymphEndDate).ToString("yy   MM   dd   ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine113.m_ObjPrintLineInfo = m_objDataArr;

            //114           
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strMetastasisGy;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strMetastasisTimes;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strMetastasisDays;
                string strPrintDate3 = m_objCollection.m_objContent.m_strMetastasisBeginDate == "1900-01-01 00:00:00" ? "                 " : DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisBeginDate).ToString("yy   MM   dd     ");
                strPrintDate3 += m_objCollection.m_objContent.m_strMetastasisEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisEndDate).ToString("yy   MM   dd   ");
                m_objDataArr[3] = strPrintDate3;//(m_objCollection.m_objContent.m_strMetastasisBeginDate == "1900-01-01 00:00:00" ? "              " : DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisBeginDate).ToString("yy   MM   dd  ")) + "   " + m_objCollection.m_objContent.m_strMetastasisEndDate == "1900-01-01 00:00:00" ? "" : DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisEndDate).ToString("yy   MM   dd   ");
                if (m_objCollection.m_objContent.m_strMetastaisCount != null)
                    m_objDataArr[4] = m_objCollection.m_objContent.m_strMetastaisCount;
                else
                    m_objDataArr[4] = "";
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
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = Convert.ToInt32(m_objCollection.m_objContent.m_strChemotherapyModeSeq) + 1;
                //if (m_objCollection.m_objContent.m_strChemotherapyWholeBody == "True" || m_objCollection.m_objContent.m_strChemotherapyWholeBody == "1")
                //    m_objDataArr[1] = "√";
                //else
                //    m_objDataArr[1] = "";
                //if (m_objCollection.m_objContent.m_strChemotherapyLocal == "True" || m_objCollection.m_objContent.m_strChemotherapyLocal == "1")
                //    m_objDataArr[2] = "√";
                //else
                //    m_objDataArr[2] = "";
                //if (m_objCollection.m_objContent.m_strChemotherapyIntubate == "True" || m_objCollection.m_objContent.m_strChemotherapyIntubate == "1")
                //    m_objDataArr[3] = "√";
                //else
                //    m_objDataArr[3] = "";
                //if (m_objCollection.m_objContent.m_strChemotherapyThorax == "True" || m_objCollection.m_objContent.m_strChemotherapyThorax == "1")
                //    m_objDataArr[4] = "√";
                //else
                //    m_objDataArr[4] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                //m_objDataArr[1] = "";
                //m_objDataArr[2] = "";
                //m_objDataArr[3] = "";
                //m_objDataArr[4] = "";
            }
            m_objLine115.m_ObjPrintLineInfo = m_objDataArr;
            //116
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {

                if (m_objCollection.m_objContent.m_strChemotherapyWholeBody == "True" || m_objCollection.m_objContent.m_strChemotherapyWholeBody == "1")
                {
                    m_objDataArr[0] = "1";
                    m_objDataArr[1] = "";
                    m_objDataArr[2] = "";
                    m_objDataArr[3] = "";
                    m_objDataArr[4] = "";
                }
                else if (m_objCollection.m_objContent.m_strChemotherapyLocal == "True" || m_objCollection.m_objContent.m_strChemotherapyLocal == "1")
                {
                    m_objDataArr[0] = "2";
                    if (m_objCollection.m_objContent.m_strChemotherapyIntubate == "True" || m_objCollection.m_objContent.m_strChemotherapyIntubate == "1")
                        m_objDataArr[1] = "√";
                    else
                        m_objDataArr[1] = "";
                    if (m_objCollection.m_objContent.m_strChemotherapyThorax == "True" || m_objCollection.m_objContent.m_strChemotherapyThorax == "1")
                        m_objDataArr[2] = "√";
                    else
                        m_objDataArr[2] = "";

                    if (m_objCollection.m_objContent.m_strChemotherapyAbdomen == "True" || m_objCollection.m_objContent.m_strChemotherapyAbdomen == "1")
                        m_objDataArr[3] = "√";
                    else
                        m_objDataArr[3] = "";
                    if (m_objCollection.m_objContent.m_strChemotherapySpinal == "True" || m_objCollection.m_objContent.m_strChemotherapySpinal == "1")
                        m_objDataArr[4] = "√";
                    else
                        m_objDataArr[4] = "";
                }
                else if (m_objCollection.m_objContent.m_strChemotherapyOtherTry == "True" || m_objCollection.m_objContent.m_strChemotherapyOtherTry == "1")
                {
                    m_objDataArr[0] = "3";
                    m_objDataArr[1] = "";
                    m_objDataArr[2] = "";
                    m_objDataArr[3] = "";
                    m_objDataArr[4] = "";
                }
                else
                {
                    m_objDataArr[0] = "";
                    m_objDataArr[1] = "";
                    m_objDataArr[2] = "";
                    m_objDataArr[3] = "";
                    m_objDataArr[4] = "";
                }
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine116.m_ObjPrintLineInfo = m_objDataArr;
            //118
            if (m_bolIfCheck == false || m_objCollection.m_objChemotherapyArr == null || m_objCollection.m_objChemotherapyArr.Length <= 0)
            {
                m_objLine118.m_ObjPrintLineInfo = null;
            }
            else
            {
                if (m_objCollection.m_objChemotherapyArr.Length > 0)
                {
                    m_objDataArr = new Object[m_objCollection.m_objChemotherapyArr.Length];

                    for (int i1 = 0; i1 < m_objCollection.m_objChemotherapyArr.Length; i1++)
                    {
                        m_objSubDataArr = new object[4];
                        m_objSubDataArr[0] = DateTime.Parse(m_objCollection.m_objChemotherapyArr[i1].m_strChemotherapyDate).ToString("yyyy-MM-dd");
                        m_objSubDataArr[1] = m_objCollection.m_objChemotherapyArr[i1].m_strMedicineName;
                        m_objSubDataArr[2] = m_objCollection.m_objChemotherapyArr[i1].m_strPeriod;
                        if (m_objCollection.m_objChemotherapyArr[i1].m_strField_CR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_CR == "1")
                            m_objSubDataArr[3] = "3";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_PR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_PR == "1")
                            m_objSubDataArr[3] = "4";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_MR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_MR == "1")
                            m_objSubDataArr[3] = "5";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_S == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_S == "1")
                            m_objSubDataArr[3] = "6";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_P == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_P == "1")
                            m_objSubDataArr[3] = "7";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_NA == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_NA == "1")
                            m_objSubDataArr[3] = "8";

                        m_objDataArr[i1] = m_objSubDataArr;
                    }
                    m_objLine118.m_ObjPrintLineInfo = m_objDataArr;
                }
            }

            //119
            m_objDataArr = new Object[16];
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strTotalAmt;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strBedAmt;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strNurseAmt;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strWMAmt;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strCMFinishedAmt;
                m_objDataArr[5] = m_objCollection.m_objContent.m_strCMSemiFinishedAmt;

                m_objDataArr[6] = m_objCollection.m_objContent.m_intDischarged;
                if (m_objCollection.m_objContent.m_intDischarged == "2" || m_objCollection.m_objContent.m_intDischarged == "3")
                {
                    m_objDataArr[7] = m_objCollection.m_objContent.m_strDischargedHospitalName;
                }
                else
                {
                    m_objDataArr[7] = "";
                }
                m_objDataArr[8] = m_objCollection.m_objContent.m_intReadmitted31;
                m_objDataArr[9] = m_objCollection.m_objContent.m_strReadmitted31;
                m_objDataArr[10] = m_objCollection.m_objContent.m_strInRnssDay;
                m_objDataArr[11] = m_objCollection.m_objContent.m_strInRnssHour;
                m_objDataArr[12] = m_objCollection.m_objContent.m_strInRnssMin;
                m_objDataArr[13] = m_objCollection.m_objContent.m_strOutRnssDay;
                m_objDataArr[14] = m_objCollection.m_objContent.m_strOutRnssHour;
                m_objDataArr[15] = m_objCollection.m_objContent.m_strOutRnssMin;

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
                m_objDataArr[7] = "";
                m_objDataArr[8] = "";
                m_objDataArr[9] = "";
                m_objDataArr[10] = "";
                m_objDataArr[11] = "";
                m_objDataArr[12] = "";
                m_objDataArr[13] = "";
                m_objDataArr[14] = "";
                m_objDataArr[15] = "";

            }
            m_objLine119.m_ObjPrintLineInfo = m_objDataArr;
            //
            //120a
            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strTotalAmt != "" && m_objCollection.m_objContent.m_strTotalAmt != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strTotalAmt;
                else
                    m_objDataArr[0] = "";

                if (m_objRecordcontent.m_strSelfamt != "" && m_objRecordcontent.m_strSelfamt != null)
                    m_objDataArr[1] = m_objRecordcontent.m_strSelfamt;//   m_objCollection.m_objContent.m_strPAYSAMT_NEW;
                else
                    m_objDataArr[1] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine120a.m_ObjPrintLineInfo = m_objDataArr;
            //120 

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strMEDICALAMT_NEW != "" && m_objCollection.m_objContent.m_strMEDICALAMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strMEDICALAMT_NEW;
                else
                    m_objDataArr[0] = "";

                if (m_objCollection.m_objContent.m_strTREATMENTAMT_NEW != "" && m_objCollection.m_objContent.m_strTREATMENTAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strTREATMENTAMT_NEW;
                else
                    m_objDataArr[1] = "";

                if (m_objCollection.m_objContent.m_strNurseAmt != null)
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strNurseAmt;//m_strBloodAmt
                else
                    m_objDataArr[2] = "";

                if (m_objCollection.m_objContent.m_strCOMPOSITEEOTHERAMT_NEW != null)
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strCOMPOSITEEOTHERAMT_NEW;
                else
                    m_objDataArr[3] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }

            m_objLine120.m_ObjPrintLineInfo = m_objDataArr;
            //121

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strPDAMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strPDAMT_NEW;
                else
                    m_objDataArr[0] = "";

                if (m_objCollection.m_objContent.m_strLDAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strLDAMT_NEW;
                else
                    m_objDataArr[1] = "";

                if (m_objCollection.m_objContent.m_strIDAMT_NEW != null)
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strIDAMT_NEW;
                else
                    m_objDataArr[2] = "";

                if (m_objCollection.m_objContent.m_strCDAMT_NEW != null)
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strCDAMT_NEW;
                else
                    m_objDataArr[3] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine121.m_ObjPrintLineInfo = m_objDataArr;

            //122

            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strNOOPAMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strNOOPAMT_NEW;
                else
                    m_objDataArr[0] = "";

                if (m_objCollection.m_objContent.m_strPHYSICALAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strPHYSICALAMT_NEW;
                else
                    m_objDataArr[1] = "";

                if (m_objCollection.m_objContent.m_strOPBYTREATMENTAMT_NEW != null)
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strOPBYTREATMENTAMT_NEW;
                else
                    m_objDataArr[2] = "";

                if (m_objCollection.m_objContent.m_strAnaethesiaAmt != null)
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strAnaethesiaAmt;
                else
                    m_objDataArr[3] = "";

                if (m_objCollection.m_objContent.m_strOperationAmt != null)
                    m_objDataArr[4] = m_objCollection.m_objContent.m_strOperationAmt;
                else
                    m_objDataArr[4] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine122.m_ObjPrintLineInfo = m_objDataArr;

            //123
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strREHABILITATIONAMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strREHABILITATIONAMT_NEW;
                else
                    m_objDataArr[0] = "";
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine123.m_ObjPrintLineInfo = m_objDataArr;

            //124
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strCMTAMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strCMTAMT_NEW;
                else
                    m_objDataArr[0] = "";
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine124.m_ObjPrintLineInfo = m_objDataArr;

            //125
            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strWMAmt != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strWMAmt;
                else
                    m_objDataArr[0] = "";

                if (m_objCollection.m_objContent.m_strAAAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strAAAMT_NEW;
                else
                    m_objDataArr[1] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine125.m_ObjPrintLineInfo = m_objDataArr;

            //126
            m_objDataArr = new Object[2];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strCMSemiFinishedAmt != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strCMSemiFinishedAmt;
                else
                    m_objDataArr[0] = "";
                if (m_objCollection.m_objContent.m_strCMFinishedAmt != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strCMFinishedAmt;
                else
                    m_objDataArr[1] = "";

            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine126.m_ObjPrintLineInfo = m_objDataArr;


            //128
            m_objDataArr = new Object[5];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strBloodAmt != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strBloodAmt;
                else
                    m_objDataArr[0] = "";
                if (m_objCollection.m_objContent.m_strALBUMINAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strALBUMINAMT_NEW;
                else
                    m_objDataArr[1] = "";

                if (m_objCollection.m_objContent.m_strGLOBULINAMT_NEW != null)
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strGLOBULINAMT_NEW;
                else
                    m_objDataArr[2] = "";

                if (m_objCollection.m_objContent.m_strCFAMT_NEW != null)
                    m_objDataArr[3] = m_objCollection.m_objContent.m_strCFAMT_NEW;
                else
                    m_objDataArr[3] = "";

                if (m_objCollection.m_objContent.m_strCYTOKINESAMT_NEW != null)
                    m_objDataArr[4] = m_objCollection.m_objContent.m_strCYTOKINESAMT_NEW;
                else
                    m_objDataArr[4] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine128.m_ObjPrintLineInfo = m_objDataArr;


            //129
            m_objDataArr = new Object[3];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strONETIMEBYSUPMT_NEW != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strONETIMEBYSUPMT_NEW;
                else
                    m_objDataArr[0] = "";

                if (m_objCollection.m_objContent.m_strONETIMEBYTMAMT_NEW != null)
                    m_objDataArr[1] = m_objCollection.m_objContent.m_strONETIMEBYTMAMT_NEW;
                else
                    m_objDataArr[1] = "";

                if (m_objCollection.m_objContent.m_strONTTIMEBYOPAMT_NEW != null)
                    m_objDataArr[2] = m_objCollection.m_objContent.m_strONTTIMEBYOPAMT_NEW;
                else
                    m_objDataArr[2] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine129.m_ObjPrintLineInfo = m_objDataArr;


            //130
            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strOtherAmt1 != null)
                    m_objDataArr[0] = m_objCollection.m_objContent.m_strOtherAmt1;
                else
                    m_objDataArr[0] = "";
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine130.m_ObjPrintLineInfo = m_objDataArr;
        }


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
                // 由于页底线打印不出，上调位置
                p_intPosY -= adjustPix;

                if (m_objPeople == null)
                {
                    if (s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("姓名___________性别    1.男 2.女  出生日期_______年____月____日   年龄____________(Y/M/D)", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 37, p_intPosY, 3, 3);

                    }
                }
                else
                {
                    if (s_blnPrintTitle)
                    {
                        p_intPosY += 14;
                        p_objGrp.DrawString("姓名___________性别    1.男 2.女  出生日期_______年____月____日   年龄____________(Y/M/D)", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 37, p_intPosY, 3, 3);
                    }

                    //姓名
                    p_objGrp.DrawString(m_objPeople.m_StrFirstName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    if (m_objPeople.m_StrSex != "")
                    {
                        if (m_objPeople.m_StrSex == "男")
                            p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY);
                        else
                            p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY);
                    }
                    //出生日期
                    if (m_objPeople.m_DtmBirth != DateTime.MinValue)
                    {
                        p_objGrp.DrawString(m_objPeople.m_DtmBirth.Year.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 82, p_intPosY);
                        p_objGrp.DrawString(m_objPeople.m_DtmBirth.Month.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 99, p_intPosY);
                        p_objGrp.DrawString(m_objPeople.m_DtmBirth.Day.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY);
                        p_objGrp.DrawString(m_objPeople.m_StrAgeLong, new Font("SimSun", 8), Brushes.Black, (int)enmRectangleInfo.LeftX + 135, p_intPosY);
                    }

                    //新版本婚姻状况放到第四行 su.liang 2012-06-27
                    #region
                    //if (m_objPeople.m_StrMarried != "")
                    //{
                    //    if (m_objPeople.m_StrMarried == "未婚")
                    //        p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                    //    else if (m_objPeople.m_StrMarried == "已婚")
                    //        p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);//之前不完善，选择“离婚”和“丧偶”打印不显示   junming.zhang 2011-07-06
                    //    else if (m_objPeople.m_StrMarried == "离婚")
                    //        p_objGrp.DrawString("3", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                    //    else if (m_objPeople.m_StrMarried == "丧偶")
                    //        p_objGrp.DrawString("4", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                    //}
                    #endregion
                }

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
            string strProv = "";
            string strCity = "";
            string strCoun = "";
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine2()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("国籍_______________________民族______________新生儿出生体重_______克    新生儿入院体重_______克", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawString("出生地________________________________________________  籍贯__________________________________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 6);
                    p_objGrp.DrawString("身份证号码________________________职业________________婚姻    1.未婚 2.已婚 3.丧偶 4.离婚 9.其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 12);
                    p_objGrp.DrawString("现住址______________________________________________________电话__________________邮编___________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 18);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12, 3, 3);
                }

                if (m_objPeople != null)
                {
                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 11, p_intPosY, 80, 25);
                    StringFormat frmat = new StringFormat();
                    //职业
                    #region

                    //if (m_objPeople.m_StrOccupation.Length > 4)
                    //{
                    //    fotNow = new Font("SimSun", 8f);
                    //    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 10, p_intPosY - 2, 18, 35);
                    //    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //}
                    //p_objGrp.DrawString(m_objPeople.m_StrOccupation, fotNow, Brushes.Black, rtgf, frmat);
                    #endregion

                    //打印出生地
                    fotNow = m_fotPrintFont;
                    #region 旧出生地
                    //					int i = 0;
                    //					int j = 0;
                    //					if(m_objPeople.m_StrHomeplace.Trim() != "")
                    //					{
                    //						i = m_objPeople.m_StrHomeplace.IndexOf("_");
                    //						j = m_objPeople.m_StrHomeplace.LastIndexOf("_");
                    //					
                    //						strProv = (m_objPeople.m_StrHomeplace).Substring(0,i);
                    //						strCity = (m_objPeople.m_StrHomeplace).Substring(j+1,m_objPeople.m_StrHomeplace.Length-j-1);
                    //					}
                    //					RectangleF rtgf1 = new RectangleF((int)enmRectangleInfo.LeftX+37,p_intPosY,80,25);
                    //					RectangleF rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX+59,p_intPosY,80,25);
                    //					if(i>3)
                    //					{
                    //						fotNow = new Font("SimSun",8f);
                    //						rtgf1 = new RectangleF((int)enmRectangleInfo.LeftX+37,p_intPosY-2,15,35);
                    //						frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //					}
                    //					if(m_objPeople.m_StrHomeplace.Length-j-1 > 3)
                    //					{
                    //						fotNow = new Font("SimSun",8f);
                    //						rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX+59,p_intPosY,15,35);
                    //						if(m_objPeople.m_StrHomeplace.Length-j-1 > 4)
                    //						{
                    //							rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX+59,p_intPosY-2,15,35);
                    //						}
                    //						frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //					}
                    //					p_objGrp.DrawString(strProv,fotNow,Brushes.Black,rtgf1,frmat);
                    //					p_objGrp.DrawString(strCity,fotNow,Brushes.Black,rtgf2,frmat);
                    #endregion

                    #region
                    //int i = 0;
                    //int j = 0;
                    //if (m_strBirthPlace.Trim() != "")
                    //{
                    //    i = m_strBirthPlace.IndexOf(">");
                    //    j = m_strBirthPlace.LastIndexOf(">");

                    //    strProv = m_strBirthPlace.Substring(0, i);
                    //    strCity = m_strBirthPlace.Substring(i + 2, j - i - 3);
                    //    if (strCity.Trim() == "市辖区" || strCity.Trim() == "县")
                    //    {
                    //        strCity = "";
                    //    }
                    //    strCoun = m_strBirthPlace.Substring(j + 1, m_strBirthPlace.Length - j - 1);
                    //    if (strCoun.Trim() == "市辖区" || strCoun.Trim() == "县")
                    //    {
                    //        strCoun = "";
                    //    }
                    //}
                    //rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY, 100, 25);
                    //if (strProv.Length + strCity.Length + strCoun.Length > 10)
                    //{
                    //    fotNow = new Font("SimSun", 8f);
                    //    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY, 45, 35);
                    //    if (strProv.Length + strCity.Length + strCoun.Length > 14)
                    //        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY - 2, 40, 35);
                    //    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //}

                    //if (m_strBirthPlace == null || m_strBirthPlace.Trim() == "")
                    //    p_objGrp.DrawString("", fotNow, Brushes.Black, rtgf, frmat);
                    //else
                    //    p_objGrp.DrawString(strProv + strCity + strCoun, fotNow, Brushes.Black, rtgf, frmat);
                    #endregion

                    //国籍
                    fotNow = m_fotPrintFont;
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 10, p_intPosY, 80, 25);
                    if (m_objPeople.m_StrNationality.Length > 2)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 10, p_intPosY, 15, 35);
                        if (m_objPeople.m_StrNationality.Length > 3)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 10, p_intPosY - 2, 15, 35);
                        }
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrNationality, fotNow, Brushes.Black, rtgf, frmat);

                    //民族
                    fotNow = m_fotPrintFont;
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 52 + 5 + 2, p_intPosY, 80, 25);
                    if (m_objPeople.m_StrNation.Length > 4)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 52 + 5, p_intPosY, 18, 35);
                        if (m_objPeople.m_StrNation.Length > 6)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 52 + 5, p_intPosY - 2, 18, 35);
                        }
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrNation, fotNow, Brushes.Black, rtgf, frmat);


                    p_objGrp.DrawString(m_strNewBabyWeight, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 98 + 5 + 5 + 3, p_intPosY);//liangsu
                    p_objGrp.DrawString(m_strNewBabyInhospitalWeight, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 149 + 5 + 5 + 3, p_intPosY);//liangsu
                    /**********************************************************************/

                    ////出生地
                    int i = 0;
                    int j = 0;
                    if (m_strBirthPlace.Trim() != "")
                    {
                        i = m_strBirthPlace.IndexOf(">");
                        j = m_strBirthPlace.LastIndexOf(">");

                        strProv = m_strBirthPlace.Substring(0, i);
                        strCity = m_strBirthPlace.Substring(i + 2, j - i - 3);
                        if (strCity.Trim() == "市辖区" || strCity.Trim() == "县")
                        {
                            strCity = "";
                        }
                        strCoun = m_strBirthPlace.Substring(j + 1, m_strBirthPlace.Length - j - 1);
                        if (strCoun.Trim() == "市辖区" || strCoun.Trim() == "县")
                        {
                            strCoun = "";
                        }
                    }
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 18, p_intPosY + 6, 100, 25);
                    if (strProv.Length + strCity.Length + strCoun.Length > 10)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 18, p_intPosY + 6, 45, 35);
                        if (strProv.Length + strCity.Length + strCoun.Length > 14)
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 18, p_intPosY + 6 - 2, 40, 35);
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }

                    if (m_strBirthPlace == null || m_strBirthPlace.Trim() == "")
                        p_objGrp.DrawString("", fotNow, Brushes.Black, rtgf, frmat);
                    else
                    {
                        //p_objGrp.DrawString(strProv + strCity + strCoun, fotNow, Brushes.Black, rtgf, frmat);
                        p_objGrp.DrawString(strProv + strCity + strCoun, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY + 6);
                        //p_objGrp.DrawString(strCity, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 53, p_intPosY + 6);
                        //p_objGrp.DrawString(strCoun, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 75, p_intPosY + 6);
                    }

                    //籍贯 nativeplace_vchr
                    p_objGrp.DrawString(m_objPeople.m_StrNativePlace, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 115, p_intPosY + 6);
                    //p_objGrp.DrawString(strCity, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY + 6);
                    /*******************************************************************/

                    //身份证号
                    p_objGrp.DrawString(m_objPeople.m_StrIDCard, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 22, p_intPosY + 12);
                    //职业m_StrOccupation
                    if (m_objPeople.m_StrOccupation.Length > 4)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 100, p_intPosY + 12 - 2, 18, 35);
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }
                    else
                    {
                        p_objGrp.DrawString(m_objPeople.m_StrOccupation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 72, p_intPosY + 12);//liangsu
                    }
                    //p_objGrp.DrawString(m_objPeople.m_StrOccupation, fotNow, Brushes.Black, rtgf, frmat);
                    //婚姻状况
                    if (m_objPeople.m_StrMarried != "")
                    {
                        if (m_objPeople.m_StrMarried == "未婚")
                            p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12);
                        else if (m_objPeople.m_StrMarried == "已婚")
                            p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12);
                        else if (m_objPeople.m_StrMarried == "离婚")
                            p_objGrp.DrawString("4", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12);
                        else if (m_objPeople.m_StrMarried == "丧偶")
                            p_objGrp.DrawString("3", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12);
                        else
                            p_objGrp.DrawString("9", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 12);
                    }
                    /**********************************************************************/
                    //现住址

                    p_objGrp.DrawString(m_objPeople.m_StrHomeAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 14, p_intPosY + 18);
                    p_objGrp.DrawString(m_objPeople.m_StrHomePhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY + 18);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManPC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 163, p_intPosY + 18);
                }

                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;
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

        private class clsPrintLine2A : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            string m_strBirthPlace = "";
            string strProv = "";
            string strCity = "";
            string strCoun = "";
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine2A()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("出生地___________________省_________市_______县(区)  籍贯________________省(区、市)_________市", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                }

                if (m_objPeople != null)
                {
                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 11, p_intPosY, 80, 25);
                    StringFormat frmat = new StringFormat();
                    ////出生地
                    int i = 0;
                    int j = 0;
                    if (m_strBirthPlace.Trim() != "")
                    {
                        i = m_strBirthPlace.IndexOf(">");
                        j = m_strBirthPlace.LastIndexOf(">");

                        strProv = m_strBirthPlace.Substring(0, i);
                        strCity = m_strBirthPlace.Substring(i + 2, j - i - 3);
                        if (strCity.Trim() == "市辖区" || strCity.Trim() == "县")
                        {
                            strCity = "";
                        }
                        strCoun = m_strBirthPlace.Substring(j + 1, m_strBirthPlace.Length - j - 1);
                        if (strCoun.Trim() == "市辖区" || strCoun.Trim() == "县")
                        {
                            strCoun = "";
                        }
                    }
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY, 100, 25);
                    if (strProv.Length + strCity.Length + strCoun.Length > 10)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY, 45, 35);
                        if (strProv.Length + strCity.Length + strCoun.Length > 14)
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 38, p_intPosY - 2, 40, 35);
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }

                    if (m_strBirthPlace == null || m_strBirthPlace.Trim() == "")
                        p_objGrp.DrawString("", fotNow, Brushes.Black, rtgf, frmat);
                    else
                        p_objGrp.DrawString(strProv + strCity + strCoun, fotNow, Brushes.Black, rtgf, frmat);

                    //籍贯
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

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

        private class clsPrintLine2B : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine2B()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("身份证号码________________________职业_______________婚姻    1.未婚 2.已婚 3.丧偶 4.离婚 9.其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                }

                if (m_objPeople != null)
                {
                    //身份证号
                    p_objGrp.DrawString(m_objPeople.m_StrIDCard, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY);
                    //职业
                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 11, p_intPosY, 80, 25);
                    StringFormat frmat = new StringFormat();
                    if (m_objPeople.m_StrOccupation.Length > 4)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 10, p_intPosY - 2, 18, 35);
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrOccupation, fotNow, Brushes.Black, rtgf, frmat);
                    //婚姻状况
                    if (m_objPeople.m_StrMarried != "")
                    {
                        if (m_objPeople.m_StrMarried == "未婚")
                            p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                        else if (m_objPeople.m_StrMarried == "已婚")
                            p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                        else if (m_objPeople.m_StrMarried == "离婚")
                            p_objGrp.DrawString("4", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                        else if (m_objPeople.m_StrMarried == "丧偶")
                            p_objGrp.DrawString("3", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                        else
                            p_objGrp.DrawString("9", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                    }
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

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

        private class clsPrintLine3A : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine3A()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {

                    p_objGrp.DrawString("现住址______________省_________市__________县(区)_____________________________________邮编___________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    //现住址
                    //现邮编
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

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

        private class clsPrintLine3 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine3()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("工作单位及地址                                              单位电话              邮编         ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 28, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 112, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 127, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 153, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 160, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 181, p_intPosY + 4);

                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 162, p_intPosY);

                    //Font fotNow = m_fotPrintFont;
                    //RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 29, p_intPosY, 80, 30);
                    //StringFormat frmat = new StringFormat();
                    //if ((m_objPeople.m_StrOffice_name + "  " + m_objPeople.m_StrOfficeAddress).Length > 19)
                    //{
                    //    fotNow = new Font("SimSun", 8f);
                    //    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 29, p_intPosY, 75, 35);
                    //    if ((m_objPeople.m_StrOffice_name + "  " + m_objPeople.m_StrOfficeAddress).Length > 24)
                    //    {
                    //        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 29, p_intPosY - 2, 75, 35);
                    //    }
                    //    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    //}
                    //p_objGrp.DrawString(m_objPeople.m_StrOffice_name + "  " + m_objPeople.m_StrOfficeAddress, fotNow, Brushes.Black, rtgf, frmat);
                    //			p_objGrp.DrawString(m_objPeople.m_StrOffice_name+"  "+m_objPeople.m_StrOfficeAddress,m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+29,p_intPosY);



                    Font fotNow = m_fotPrintFont;
                    Font fotNow1 = m_fotPrintFont;
                    RectangleF rtgf1 = new RectangleF((int)enmRectangleInfo.LeftX + 29, p_intPosY, 80, 30);
                    RectangleF rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX + 29, p_intPosY, 80, 30);
                    StringFormat frmat = new StringFormat();
                    if (m_objPeople.m_StrOffice_name.Length > 26 || m_objPeople.m_StrOfficeAddress.Length > 26)
                    {
                        fotNow1 = new Font("SimSun", 8f);
                        rtgf1 = new RectangleF((int)enmRectangleInfo.LeftX + 20, p_intPosY, 75, 35);
                        rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX + 65, p_intPosY, 75, 35);
                        if (m_objPeople.m_StrOffice_name.Length > 26)
                        {
                            rtgf1 = new RectangleF((int)enmRectangleInfo.LeftX + 20, p_intPosY - 2, 75, 35);
                            p_objGrp.DrawString(m_objPeople.m_StrOffice_name, fotNow1, Brushes.Black, rtgf1, frmat);
                        }
                        else
                        {
                            p_objGrp.DrawString(m_objPeople.m_StrOffice_name, fotNow, Brushes.Black, rtgf1, frmat);
                        }
                        //if (m_objPeople.m_StrOfficeAddress.Length > 11)
                        //{
                        //    rtgf2 = new RectangleF((int)enmRectangleInfo.LeftX + 65, p_intPosY - 2, 75, 35);
                        //    p_objGrp.DrawString(m_objPeople.m_StrOfficeAddress, fotNow1, Brushes.Black, rtgf2, frmat);
                        //}
                        //else
                        //{
                        //    p_objGrp.DrawString(m_objPeople.m_StrOfficeAddress, fotNow, Brushes.Black, rtgf2, frmat);
                        //}

                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;

                    }
                    else
                    {
                        p_objGrp.DrawString(m_objPeople.m_StrOffice_name + "(" + m_objPeople.m_StrOfficeAddress + ")", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 30, p_intPosY);
                        //  p_objGrp.DrawString(m_objPeople.m_StrOfficeAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 65, p_intPosY);
                    }
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

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
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine4()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("户口地址                                                                          邮编            ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 16, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 153, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 160, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 181, p_intPosY + 4);

                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrHomePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 163, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrResidencePlace, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                }
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                //				m_objText1.m_mthRestartPrint();
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
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine5()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("联系人姓名                关系         地址                                电话 ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 20, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 48, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 57, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 71, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 81, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 139, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 147, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 170, p_intPosY + 4);

                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManFirstName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrPatientRelation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManPhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 147, p_intPosY);

                    Font fotNow = m_fotPrintFont;
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 83, p_intPosY, 80, 25);
                    StringFormat frmat = new StringFormat();
                    if ((m_objPeople.m_StrLinkMan_district/*+m_objPeople.m_StrLinkMan_street*/).Length > 15)
                    {
                        fotNow = new Font("SimSun", 8f);
                        rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 83, p_intPosY, 58, 35);
                        if ((m_objPeople.m_StrLinkMan_district/*+m_objPeople.m_StrLinkMan_street*/).Length > 21)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 83, p_intPosY - 2, 58, 35);
                        }
                        frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                    }
                    p_objGrp.DrawString(m_objPeople.m_StrLinkMan_district/*+m_objPeople.m_StrLinkMan_street*/, fotNow, Brushes.Black, rtgf, frmat);

                }

                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;

                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                //				m_objText1.m_mthRestartPrint();
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
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine6()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 11));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                Font fotNow = m_fotPrintFont;
                //				if(m_blnFirstPrint)
                //				{
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入院途径     1.急诊 2.门诊 3.其他医疗机构转入 9其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 20, p_intPosY, 3, 3);
                    p_objGrp.DrawString("入院时间      年    月    日    时 入院科别                病房        ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 6);
                    p_objGrp.DrawString("转科1.____年__月__日__时转______科 2.____年__月__日__时转______科 3.____年___月__日__时转______科", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 16, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 26, p_intPosY + 4 + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 30, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 37, p_intPosY + 4 + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 42, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 48, p_intPosY + 4 + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 53, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 60, p_intPosY + 4 + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 82, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 109, p_intPosY + 4 + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 118, p_intPosY + 4 + 6, (int)enmRectangleInfo.LeftX + 131, p_intPosY + 4 + 6);
                    //p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 148, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 175, p_intPosY + 4);
                    p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 6);

                    if (m_objDataArr[1] != null)
                    {
                        if (m_objDataArr[1].ToString().Length > 6)
                        {
                            fotNow = new Font("SimSun", 8f);
                        }
                        p_objGrp.DrawString(m_objDataArr[1].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 83, p_intPosY + 6);
                    }
                    fotNow = m_fotPrintFont;
                    if (m_objDataArr[2] != null)
                    {
                        if (m_objDataArr[2].ToString().Length >= 5)
                        {
                            fotNow = new Font("SimSun", 8f);
                        }
                        p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY + 6);
                    }
                }
                fotNow = new Font("SimSun", 9f);
                if (m_objDataArr[3] != null)
                {
                    string[] strDeptAndDate = m_objDataArr[3].ToString().Trim().Substring(0, m_objDataArr[3].ToString().Trim().Length).Split(',');
                    if (strDeptAndDate.Length > 1)
                    {
                        p_objGrp.DrawString(strDeptAndDate[0].Substring(0, strDeptAndDate[0].Length - 16), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 49, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[0].Substring(strDeptAndDate[0].Length - 12, 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 12, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[0].Substring(strDeptAndDate[0].Length - 8, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 24, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[0].Substring(strDeptAndDate[0].Length - 6, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 31, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[0].Substring(strDeptAndDate[0].Length - 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 38, p_intPosY + 12);
                    }
                    if (strDeptAndDate.Length > 2)
                    {
                        p_objGrp.DrawString(strDeptAndDate[1].Substring(0, strDeptAndDate[1].Length - 16), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 145 - 38, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[1].Substring(strDeptAndDate[1].Length - 12, 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 96 - 26, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[1].Substring(strDeptAndDate[1].Length - 8, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 108 - 26, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[1].Substring(strDeptAndDate[1].Length - 6, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 118 - 30, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[1].Substring(strDeptAndDate[1].Length - 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 129 - 33, p_intPosY + 12);
                    }
                    if (strDeptAndDate.Length > 3)
                    {
                        p_objGrp.DrawString(strDeptAndDate[2].Substring(0, strDeptAndDate[2].Length - 16), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 140 + 27, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[2].Substring(strDeptAndDate[2].Length - 12, 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 95 + 33, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[2].Substring(strDeptAndDate[2].Length - 8, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 108 + 33, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[2].Substring(strDeptAndDate[2].Length - 6, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 120 + 29, p_intPosY + 12);
                        p_objGrp.DrawString(strDeptAndDate[2].Substring(strDeptAndDate[2].Length - 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 125 + 31, p_intPosY + 12);
                    }
                }
                #region
                //fotNow = new Font("SimSun", 9f);
                //if (m_objDataArr[3].ToString() == "")
                //    p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY + 6);
                //else
                //{
                //    //string[] strDeptAndDate = m_objDataArr[3].ToString().Substring(0, m_objDataArr[3].ToString().Length - 1).Split(' ');
                //    string[] strDeptAndDate = m_objDataArr[3].ToString().Trim().Substring(0, m_objDataArr[3].ToString().Trim().Length).Split(' ');
                //    if (strDeptAndDate.Length == 1)
                //    {
                //        if (strDeptAndDate[0].Length < 13) fotNow = m_fotPrintFont;
                //       // p_objGrp.DrawString(strDeptAndDate[0], fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY + 6);
                //        //科室
                //        p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(0, strDeptAndDate[0].ToString().IndexOf("(")), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY + 12);
                //        p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 1, 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY + 12);
                //        p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 28, p_intPosY + 12);
                //        p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 5, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY + 12);
                //    }
                //    else
                //    {
                //        //int intOffSetY = 0;
                //        //for (int i = 0; i < strDeptAndDate.Length; i++)
                //        //{
                //        //    p_objGrp.DrawString(strDeptAndDate[i], fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY + 6 - 3 + intOffSetY);
                //        //    intOffSetY += 3;
                //        //}
                //        //只显示两个转科信息
                //         p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(0,strDeptAndDate[0].ToString().IndexOf("(")), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(")+1 , 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 28, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[0].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 5, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY + 12);

                //         p_objGrp.DrawString(strDeptAndDate[1].ToString().Trim().Substring(0, strDeptAndDate[0].ToString().IndexOf("(")), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[1].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(")+1 , 4), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 94, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[1].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 3, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 107, p_intPosY + 12);
                //         p_objGrp.DrawString(strDeptAndDate[1].ToString().Trim().Substring(strDeptAndDate[0].ToString().IndexOf("(") + 5, 2), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 117, p_intPosY + 12);
                //    }
                //}
                #endregion
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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
            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine7()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("出院时间      年    月    日    时 出院科别                病床        实际住院      天", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 16, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 26, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 30, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 37, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 42, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 48, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 53, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 60, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 82, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 109, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 118, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 131, p_intPosY + 4);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 148, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 157, p_intPosY + 4);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                Font fotNow = m_fotPrintFont;
                if (m_objDataArr[1] != null)
                {
                    if (m_objDataArr[1].ToString().Length > 6)
                    {
                        fotNow = new Font("SimSun", 8f);
                    }
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 83, p_intPosY);
                }
                fotNow = m_fotPrintFont;
                if (m_objDataArr[2] != null)
                {
                    if (m_objDataArr[2].ToString().Length >= 7)
                    {
                        fotNow = new Font("SimSun", 8f);
                    }
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), fotNow, Brushes.Black, (int)enmRectangleInfo.LeftX + 120, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

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

        private class clsPrintLine8a : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine8a()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("是否临床路径：   1.是 2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 25, p_intPosY, 3, 3);
                    if (m_objDataArr[0] != null)
                        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 25, p_intPosY);
                }


                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                //				}
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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

        private class clsPrintLine8 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine8()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("门(急)诊诊断______________________________疾病编码___________________门(急)诊医生______________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                    if (m_objDataArr[2] != null)
                        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 101, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 155, p_intPosY);
                Font fotNow = m_fotPrintFont;
                RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 25, p_intPosY, 80, 25);
                StringFormat frmat = new StringFormat();
                if (m_objDataArr[0].ToString().Length > 15)
                {
                    fotNow = new Font("SimSun", 8f);
                    rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 25, p_intPosY - 2, 55, 35);
                    frmat.FormatFlags = StringFormatFlags.FitBlackBox;
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), fotNow, Brushes.Black, rtgf, frmat/*(int)enmRectangleInfo.LeftX+25,p_intPosY*/);

                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                p_objGrp.PageUnit = enmOld;

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

        private class clsPrintLine9 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private object[] m_objSubDataArr = null;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine9()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                try
                {
                    GraphicsUnit enmOld = p_objGrp.PageUnit;
                    p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                    //				if(m_blnFirstPrint)
                    //				{
                    if (s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("入院诊断                                                       入院后确诊日期     年    月    日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 16, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 117, p_intPosY + 4);
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 145, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 153, p_intPosY + 4);
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 158, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 165, p_intPosY + 4);
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 169, p_intPosY + 4, (int)enmRectangleInfo.LeftX + 176, p_intPosY + 4);

                    }
                    Font fotNow = new Font("SimSun", 8f);
                    RectangleF rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 18, p_intPosY, 200, 25);
                    StringFormat frmat = new StringFormat();
                    int intTempY = p_intPosY;
                    if (m_objDataArr.Length > 1)
                    {
                        if (m_objDataArr.Length > 2)
                            intTempY -= 2;
                        if (m_objDataArr.Length == 2)
                            fotNow = m_fotPrintFont;
                        for (int i = 0; i < m_objDataArr.Length - 1; i++)
                        {
                            rtgf = new RectangleF((int)enmRectangleInfo.LeftX + 18, intTempY, 200, 25);
                            p_objGrp.DrawString(m_objDataArr[i].ToString(), fotNow, Brushes.Black, rtgf, frmat);
                            intTempY += 3;
                        }
                        p_objGrp.DrawString(m_objDataArr[m_objDataArr.Length - 1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 146, p_intPosY);
                    }
                    if (m_objDataArr.Length == 1 && m_objDataArr[0] != null)
                    {
                        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 146, p_intPosY);

                    }
                    m_blnHaveMoreLine = false;
                    p_intPosY += (int)enmRectangleInfo.RowStep;

                    p_objGrp.PageUnit = enmOld;
                }
                catch (Exception Ex)
                {
                    System.Windows.Forms.MessageBox.Show(Ex.StackTrace);
                }
            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                m_intPosY = p_intPosY;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, 39 + 14 - adjustPix, (int)enmRectangleInfo.LeftX - 2, 291 - adjustPix);//左边竖线
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.RightX, 39 + 14 - adjustPix, (int)enmRectangleInfo.RightX, 291 - adjustPix);//1右边竖线
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 133, p_intPosY + 6, (int)enmRectangleInfo.RightX, p_intPosY + 6);

                    p_objGrp.DrawString("入院病情", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY + 1);

                    p_objGrp.DrawString("出院诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 43, p_intPosY + 6);

                    p_objGrp.DrawString("疾病编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 105, p_intPosY + 6);

                    p_objGrp.DrawString("有", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 138, p_intPosY + 10);

                    p_objGrp.DrawString("临床", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY + 7);
                    p_objGrp.DrawString("未确定", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY + 11);

                    p_objGrp.DrawString("情况", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 161, p_intPosY + 7);
                    p_objGrp.DrawString("不明", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 161, p_intPosY + 11);

                    p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 174, p_intPosY + 10);


                    p_intPosY += 15;
                    for (int i = 1; i <= 21; i++)//23
                    {
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                        p_intPosY += 7;
                    }

                    p_intPosY -= 159;
                }
                else
                    p_intPosY += 17;

                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;
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
            private bool m_blnFirstPrint = true;
            private string strMainDiagnose = "";
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine11()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (m_blnFirstPrint)
                {
                    //p_intPosY += 14;
                    strMainDiagnose = m_objDataArr[0].ToString();
                    p_objGrp.DrawString("主要诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 14);
                    switch (m_objDataArr[1].ToString())
                    {
                        case "0":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 134, p_intPosY + 14);
                            break;
                        case "1":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 147, p_intPosY + 14);
                            break;
                        case "2":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY + 14);
                            break;
                        case "3":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 173, p_intPosY + 14);
                            break;
                    }
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 105, p_intPosY + 14);
                    m_blnFirstPrint = false;
                }
                while (strMainDiagnose.Length > 22)
                {
                    p_objGrp.DrawString(strMainDiagnose.Substring(0, 22), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                    m_intRows++;
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                    //if (p_intPosY >= 270)
                    //{
                    //    p_intPosY = 1000;//换页条件
                    //    m_intPages++;
                    //    strMainDiagnose = strMainDiagnose.Substring(22);
                    //    break;
                    //}
                    strMainDiagnose = strMainDiagnose.Substring(22);
                }
                if (p_intPosY != 1000)
                {
                    p_objGrp.DrawString(strMainDiagnose, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                    m_intRows++;
                    m_blnHaveMoreLine = false;
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                    if (p_intPosY >= 270)
                    {
                        p_intPosY = 1000;//换页条件
                        m_intPages++;
                    }
                    p_objGrp.PageUnit = enmOld;
                }
                else
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 103, m_intPosY, (int)enmRectangleInfo.LeftX + 103, 269);//2
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 173, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 173, 269);//3
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 143, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 143, 269);//4
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 153, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 153, 269);//5
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 163, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 163, 269);//6
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 133, m_intPosY, (int)enmRectangleInfo.LeftX + 133, 269);//7
                }
            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                m_blnFirstPrint = true;
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
            private object[] m_objSubDataArr = null;
            private Pen m_pen = new Pen(Brushes.Yellow, 0.1f);
            private bool m_blnFirstPrint = true;
            private string strOtherDiagnose = "";
            public clsPrintLine12()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (m_blnFirstPrint)
                {
                    p_objGrp.DrawString("其他诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY + 14);
                }
                else
                {//继续打印换页前最后一条记录的剩余部分
                    while (strOtherDiagnose.Length > 22)
                    {
                        p_objGrp.DrawString(strOtherDiagnose.Substring(0, 22), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                        m_intRows++;
                        p_intPosY += (int)enmRectangleInfo.RowStep;
                        strOtherDiagnose = strOtherDiagnose.Substring(22);
                    }
                    p_objGrp.DrawString(strOtherDiagnose, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                }
                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    for (; m_intCurrentIndex < m_objDataArr.Length; m_intCurrentIndex++)
                    {
                        m_objSubDataArr = (object[])m_objDataArr[m_intCurrentIndex];
                        #region 11
                        switch (m_objSubDataArr[1].ToString())
                        {
                            case "1":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 134, p_intPosY + 14);
                                break;
                            case "2":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 147, p_intPosY + 14);
                                break;
                            case "3":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY + 14);
                                break;
                            case "4":
                                p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 172, p_intPosY + 14);
                                break;
                            //case "5":
                            //    p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 145, p_intPosY);
                            //    break;
                        }

                        p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 105, p_intPosY + 14);
                        strOtherDiagnose = m_objSubDataArr[0].ToString();
                        if (strOtherDiagnose == "")
                        {
                            p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                            if (m_intPages > 1)
                                p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY + 14 - 1);
                            m_intRows++;
                        }
                        #endregion
                        #region 12
                        else
                        {
                            while (strOtherDiagnose.Length > 22)
                            {
                                p_objGrp.DrawString(strOtherDiagnose.Substring(0, 22), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                                if (m_intPages > 1)
                                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY + 14 - 1);
                                m_intRows++;
                                p_intPosY += (int)enmRectangleInfo.RowStep;
                                if (p_intPosY >= 270)
                                {
                                    p_intPosY = 1000;//换页条件
                                    m_intPages++;
                                    m_intRows = 0;
                                    strOtherDiagnose = strOtherDiagnose.Substring(22);
                                    break;
                                }
                                strOtherDiagnose = strOtherDiagnose.Substring(22);
                            }
                        }
                        #endregion
                        #region 13
                        if (p_intPosY != 1000)
                        {
                            p_objGrp.DrawString(strOtherDiagnose, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                            if (m_intPages > 1)
                                p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY + 14 - 1);
                            m_intRows++;
                            p_intPosY += (int)enmRectangleInfo.RowStep;
                            if (p_intPosY >= 270)
                            {
                                p_intPosY = 1000;//换页条件
                                m_intPages++;
                                m_intRows = 0;
                                break;
                            }

                        }
                        #endregion
                    }
                    if (p_intPosY != 1000)
                    {
                        m_blnHaveMoreLine = false;
                        //p_intPosY += (int)enmRectangleInfo.RowStep;
                        p_objGrp.PageUnit = enmOld;
                    }
                    else
                    {
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 103, m_intPosY, (int)enmRectangleInfo.LeftX + 103, 269);//2
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 113, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 113, 269);//3
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 123, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 123, 269);//4
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 133, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 133, 269);//5
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 143, m_intPosY + 8, (int)enmRectangleInfo.LeftX + 143, 269);//6
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 153, m_intPosY, (int)enmRectangleInfo.LeftX + 153, 269);//7


                        m_blnFirstPrint = false;
                        m_intCurrentIndex++;
                    }
                }
                else
                {
                    p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY + 14);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                    p_objGrp.PageUnit = enmOld;
                    m_blnHaveMoreLine = false;
                    m_intRows++;
                    p_intPosY += (int)enmRectangleInfo.RowStep;
                }
            }


            public override void m_mthReset()
            {
                m_intCurrentIndex = 0;
                m_blnHaveMoreLine = true;
                m_blnFirstPrint = true;
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
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (m_intPages > 1)
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                else if (m_intRows < 12)
                    p_intPosY += (13 - m_intRows) * (int)enmRectangleInfo.RowStep;

                switch (m_objDataArr[1].ToString())
                {
                    case "1":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 134, p_intPosY);
                        break;
                    case "2":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 146, p_intPosY);
                        break;
                    case "3":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY);
                        break;
                    case "4":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 172, p_intPosY);
                        break;
                }
                m_intRows++;
                int m_intY = p_intPosY + 5;
                if (m_intRows > 13)//超过固定行数
                {
                    m_intY = m_intPosY + (int)enmRectangleInfo.RowStep * (m_intRows + 2) + 1;
                }
                if (m_intPages > 1)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 103, 16, (int)enmRectangleInfo.LeftX + 103, m_intY + 1);//2
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 113, 16, (int)enmRectangleInfo.LeftX + 113, m_intY + 1);//3
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 123, 16, (int)enmRectangleInfo.LeftX + 123, m_intY + 1);//4
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 133, 16, (int)enmRectangleInfo.LeftX + 133, m_intY + 1);//5
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 143, 16, (int)enmRectangleInfo.LeftX + 143, m_intY + 1);//6
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 153, 16, (int)enmRectangleInfo.LeftX + 153, m_intY + 1);//7
                }
                else
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 103, m_intPosY, (int)enmRectangleInfo.LeftX + 103, m_intY);//2
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 133, m_intPosY, (int)enmRectangleInfo.LeftX + 133, m_intY);//7
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 146, m_intPosY + 6, (int)enmRectangleInfo.LeftX + 146, m_intY);//4
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 159, m_intPosY + 6, (int)enmRectangleInfo.LeftX + 159, m_intY);//5
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 172, m_intPosY + 6, (int)enmRectangleInfo.LeftX + 172, m_intY);//6

                }
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                m_intRows = 0;
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


        private class clsPrintLine14a : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine14a()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病例分型    A 一般  B 急  C 疑难  D 危重     临床路径病例   1.是 2.否  抢救____次  成功____次 ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 17, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 110, p_intPosY, 3, 3);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                }
                string blfx = string.Empty;
                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        blfx = "A";
                        break;
                    case "1":
                        blfx = "B";
                        break;
                    case "2":
                        blfx = "C";
                        break;
                    case "3":
                        blfx = "D";
                        break;
                }
                p_objGrp.DrawString(blfx, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 17, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 143, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 165, p_intPosY);
                m_blnHaveMoreLine = false;

                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                p_objGrp.PageUnit = enmOld;

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
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine14()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病理诊断：______________________________________病理号：____________疾病编码：___________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                }

                //					m_blnFirstPrint = false;
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 23, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 103, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 147, p_intPosY);

                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("损伤、中毒的外部因素：____________________________________________________疾病编码：____________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 40, p_intPosY);

                p_objGrp.DrawString("                                                                                    " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine16()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("药物过敏    1.无 2.有，过敏药物____________________________________死亡患者尸检    1.是 2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 18, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 149, p_intPosY, 3, 3);

                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);

                    //p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 82, p_intPosY, 3, 3);
                    //p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 106, p_intPosY, 3, 3);
                    //p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 131, p_intPosY, 3, 3);
                }
                if (m_objDataArr[0].ToString() == "" || m_objDataArr[0].ToString() == null)
                    p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                else
                {
                    p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY);
                }
                if (m_objDataArr[1].ToString() != "")
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 149, p_intPosY);
                else
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 149, p_intPosY + 1.5f, (int)enmRectangleInfo.LeftX + 152, p_intPosY + 1.5f);


                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                p_objGrp.PageUnit = enmOld;

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

            public clsPrintLine17()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {

                    p_objGrp.DrawString("血型   1.A  2.B  3.O  4.AB  5.不详  6.未查  Rh    1.阴 2.阳 3.不详 4.未查", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);

                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 10, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 89, p_intPosY, 3, 3);
                    //p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 119, p_intPosY, 3, 3);
                    //p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 154, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 89, p_intPosY);
                //p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 119, p_intPosY);
                //p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 154, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

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

            public clsPrintLine18()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               放射与病理     0.未做 1.符合 2.不符合 3.不肯定     抢救______次   成功_______次", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 49, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 49, (float)p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 135, (float)p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 165, (float)p_intPosY);

                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

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


        private class clsPrintLine19 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            internal clsQueryCheckResultSvc GetLisSvc()
            {
                return (clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckResultSvc)); ;
            }

            public clsPrintLine19()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("科主任               主(副主)任医师               主治医师            住院医师", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                }

                bool isSign = false;
                string empName = string.Empty;
                byte[] signData = null;
                MemoryStream ms = null;
                clsQueryCheckResultSvc lisSvc = this.GetLisSvc();

                if (m_objDataArr[0] != null)
                {
                    empName = m_objDataArr[0].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 15 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[1] != null)
                {
                    empName = m_objDataArr[1].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 70 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[2] != null)
                {
                    empName = m_objDataArr[2].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 110 - 1/*2*/, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[3] != null)
                {
                    empName = m_objDataArr[3].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 150 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                }

                //if (m_objDataArr[0] != null)
                //    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY);
                //if (m_objDataArr[1] != null)
                //    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                //if (m_objDataArr[2] != null)
                //    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                //if (m_objDataArr[3] != null)
                //    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

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


        private class clsPrintLine20 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            internal clsQueryCheckResultSvc GetLisSvc()
            {
                return (clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckResultSvc)); ;
            }

            public clsPrintLine20()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("进修医师             责任护士                     实习医师            编码员", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                }

                bool isSign = false;
                string empName = string.Empty;
                byte[] signData = null;
                MemoryStream ms = null;
                clsQueryCheckResultSvc lisSvc = this.GetLisSvc();

                if (m_objDataArr[0] != null)
                {
                    empName = m_objDataArr[0].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 18 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[1] != null)
                {
                    empName = m_objDataArr[1].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 70 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[2] != null)
                {
                    empName = m_objDataArr[2].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 110 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[3] != null)
                {
                    empName = m_objDataArr[3].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 150 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                }

                //if (m_objDataArr[0] != null)
                //    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                //if (m_objDataArr[1] != null)
                //    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                //if (m_objDataArr[2] != null)
                //    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                //if (m_objDataArr[3] != null)
                //    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //if (p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

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


        private class clsPrintLine21 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            internal clsQueryCheckResultSvc GetLisSvc()
            {
                return (clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckResultSvc)); ;
            }

            public clsPrintLine21()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病案质量     1.甲  2.乙  3.丙   质控医师          质控护士          日期：_____年____月____日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    if (m_intPages > 1)
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY - 1, (int)enmRectangleInfo.RightX1, p_intPosY - 1);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 20, p_intPosY, 3, 3);
                }

                bool isSign = false;
                string empName = string.Empty;
                byte[] signData = null;
                MemoryStream ms = null;
                clsQueryCheckResultSvc lisSvc = this.GetLisSvc();

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);

                if (m_objDataArr[1] != null)
                {
                    empName = m_objDataArr[1].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            // 由于盖住后面“质控护士”的“质”字，调整位置
                            // p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 80 - 2, p_intPosY, 20, 5);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 80 - 4, p_intPosY, 16, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                }
                isSign = false;
                if (m_objDataArr[2] != null)
                {
                    empName = m_objDataArr[2].ToString().Trim();
                    if (empName != string.Empty)
                    {
                        signData = lisSvc.GetEmpSign(empName);
                        if (signData != null)
                        {
                            ms = new MemoryStream(signData);
                            p_objGrp.DrawImage(Image.FromStream(ms), (int)enmRectangleInfo.LeftX + 110 - 2, p_intPosY, 20, 5);
                            isSign = true;
                        }
                    }
                    if (!isSign) p_objGrp.DrawString(empName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                }

                //if (m_objDataArr[1] != null)
                //    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                //if (m_objDataArr[2] != null)
                //    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY);
                p_intPosY = 1000;	//打完这一行，肯定换页
                p_intPosY += (int)enmRectangleInfo.RowStep;
                if (m_intPages == 1 || p_intPosY >= 270)
                {
                    p_intPosY = 1000;//换页条件
                    m_intPages++;
                }
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;



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

        #region 100 ^102
        private class clsPrintLine100 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine100()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY - 1, m_intRightX, p_intPosY - 1);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 104 - 22, p_intPosY + 5, m_intLeftX + 104 - 22, p_intPosY + 59);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 117 - 22, p_intPosY + 5, m_intLeftX + 117 - 22, p_intPosY + 59);

                    p_objGrp.DrawString("手术及", m_fotPrintFont, Brushes.Black, m_intLeftX + 166, p_intPosY + 2);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 162, p_intPosY - 1, m_intLeftX + 162, p_intPosY + 59);
                    p_objGrp.DrawString("手术及", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 47 - 22 - 5, p_intPosY - 1, m_intLeftX + 47 - 22 - 5, p_intPosY + 59);
                    p_objGrp.DrawString("手术及操作名称", m_fotPrintFont, Brushes.Black, m_intLeftX + 58 - 27 - 5, p_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 91 - 22 - 10, p_intPosY - 1, m_intLeftX + 91 - 22 - 10, p_intPosY + 59);
                    p_objGrp.DrawString("手术", m_fotPrintFont, Brushes.Black, m_intLeftX + 99 - 27 - 12, p_intPosY + 1);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 91 - 22, p_intPosY - 1, m_intLeftX + 91 - 22, p_intPosY + 59);
                    p_objGrp.DrawString("手术及操作医师", m_fotPrintFont, Brushes.Black, m_intLeftX + 99 - 27, p_intPosY + 1);

                    //p_objGrp.DrawLine(m_pen, m_intLeftX + 130 - 22, p_intPosY - 1, m_intLeftX + 130 - 22, p_intPosY + 59);
                    //p_objGrp.DrawString("麻醉", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 26, p_intPosY + 2);

                    //p_objGrp.DrawLine(m_pen, m_intLeftX + 145 - 22 - 5, p_intPosY - 1, m_intLeftX + 145 - 22 - 5, p_intPosY + 59);
                    //p_objGrp.DrawString("切口愈", m_fotPrintFont, Brushes.Black, m_intLeftX + 148 - 27 - 5, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 145 - 22 - 5 + 15 + 2, p_intPosY - 1, m_intLeftX + 145 - 22 - 5 + 15 + 2, p_intPosY + 59);
                    p_objGrp.DrawString("麻醉", m_fotPrintFont, Brushes.Black, m_intLeftX + 148 - 27 + 15 + 1, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 130 - 22, p_intPosY - 1, m_intLeftX + 130 - 22, p_intPosY + 59);
                    p_objGrp.DrawString("切口", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 23, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 130 - 22 + 15, p_intPosY - 1, m_intLeftX + 130 - 22 + 15, p_intPosY + 59);
                    p_objGrp.DrawString("择期", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 26 + 15 + 1, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 162 - 22 + 7, p_intPosY - 1, m_intLeftX + 162 - 22 + 7, p_intPosY + 59);
                    p_objGrp.DrawString("麻醉医师", m_fotPrintFont, Brushes.Black, m_intLeftX + 166 - 27 + 7, p_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intRightX, 16, m_intRightX, 290);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 16, m_intLeftX, 290);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 290, m_intRightX, 290);

                }
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
                    }
                }
            }
        }


        private class clsPrintLine101 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private string strOperation;
            public clsPrintLine101(string p_strOpertion)
            {
                strOperation = p_strOpertion;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 11, m_intRightX, p_intPosY + 11);
                    p_objGrp.DrawString("操作编码", m_fotPrintFont, Brushes.Black, m_intLeftX + 165, p_intPosY + 7);
                    if (strOperation == "1")
                        p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, m_intLeftX + 7, p_intPosY + 12);
                    p_objGrp.DrawString("操作日期", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, p_intPosY + 7);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 91 - 22, p_intPosY + 5, m_intLeftX + 130 - 22, p_intPosY + 5);
                    p_objGrp.DrawString("等级", m_fotPrintFont, Brushes.Black, m_intLeftX + 99 - 27 - 12, p_intPosY + 6);
                    p_objGrp.DrawString("术者", m_fotPrintFont, Brushes.Black, m_intLeftX + 94 - 23, p_intPosY + 6);
                    p_objGrp.DrawString("I 助", m_fotPrintFont, Brushes.Black, m_intLeftX + 107 - 23, p_intPosY + 6);
                    p_objGrp.DrawString("II 助", m_fotPrintFont, Brushes.Black, m_intLeftX + 119 - 23, p_intPosY + 6);
                    //p_objGrp.DrawString("方式", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 26, p_intPosY + 7);
                    //p_objGrp.DrawString("合等级", m_fotPrintFont, Brushes.Black, m_intLeftX + 148 - 27 - 5, p_intPosY + 7);
                    p_objGrp.DrawString("方式", m_fotPrintFont, Brushes.Black, m_intLeftX + 148 - 27 + 15 + 1, p_intPosY + 7);
                    p_objGrp.DrawString("/愈合", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 25 + 2, p_intPosY + 7);
                    p_objGrp.DrawString("手术", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 - 26 + 15 + 1, p_intPosY + 7);
                }
                p_intPosY += 11;
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
                    }
                }
            }
        }

        private class clsPrintLine102 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private clsPrintRichTextContext m_objText2;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            //			private int m_intCurrentrecord = 0;
            private object[] m_objDataArr = null;

            public clsPrintLine102()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
                m_objText2 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY, m_intRightX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 6, m_intRightX, p_intPosY + 6);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 12, m_intRightX, p_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 18, m_intRightX, p_intPosY + 18);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 24, m_intRightX, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 30, m_intRightX, p_intPosY + 30);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 36, m_intRightX, p_intPosY + 36);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 42, m_intRightX, p_intPosY + 42);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 48, m_intRightX, p_intPosY + 48);
                    //p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 54, m_intRightX, p_intPosY + 54);
                    //p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 60, m_intRightX, p_intPosY + 60);

                    p_objGrp.DrawLine(m_pen, m_intLeftX + 117, p_intPosY - 5, m_intLeftX + 117, p_intPosY - 5);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 205, p_intPosY - 5, m_intLeftX + 205, p_intPosY - 5);

                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    p_intPosY += 1;

                    int intIncreaseHeight = 0;

                    for (int i = 0; i < m_objDataArr.Length; i++)
                    {
                        object[] m_objSubDataArr = (object[])m_objDataArr[i];
                        p_objGrp.DrawString(m_objSubDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 163, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 22 - 22, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 92 - 22, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 106 - 23, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 119 - 23, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 130 - 22, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 165 - 22 + 5, p_intPosY + intIncreaseHeight);

                        p_objGrp.DrawString(m_objSubDataArr[9].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60, p_intPosY + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[10].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 165 - 22 - 19, p_intPosY + intIncreaseHeight);

                        //p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 130, p_intPosY + intIncreaseHeight);
                        if (m_objSubDataArr[6].ToString().Length <= 3)
                        {
                            p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 165 - 15 - 15, p_intPosY + intIncreaseHeight);
                        }
                        else if (m_objSubDataArr[6].ToString().Length > 3)
                        {

                            p_objGrp.DrawString(m_objSubDataArr[6].ToString().Substring(0, 4), new Font("SimSun", 8f), Brushes.Black, m_intLeftX + 165 - 15 - 15, p_intPosY + intIncreaseHeight - 1);
                            p_objGrp.DrawString(m_objSubDataArr[6].ToString().Substring(4), new Font("SimSun", 8f), Brushes.Black, m_intLeftX + 165 - 15 - 15, p_intPosY + intIncreaseHeight + 2);

                        }

                        string strTemp = m_objSubDataArr[2].ToString().Trim();//手术、操作名称
                        while (strTemp.Length > 10)
                        {
                            p_objGrp.DrawString(strTemp.Substring(0, 10), m_fotPrintFont, Brushes.Black, m_intLeftX + 50 - 30, p_intPosY + intIncreaseHeight);
                            strTemp = strTemp.Substring(10);
                            intIncreaseHeight += 6;
                        }
                        p_objGrp.DrawString(strTemp, m_fotPrintFont, Brushes.Black, m_intLeftX + 50 - 30, p_intPosY + intIncreaseHeight);
                        intIncreaseHeight += 6;
                    }

                }


                p_intPosY += 17;
                //p_intPosY = 1000;//换页条件
                //if (m_intPages == 1 || p_intPosY >= 270)
                //{
                //    p_intPosY = 1000;//换页条件
                //    m_intPages++;
                //}
                m_blnHaveMoreLine = false;
                //p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {

                m_blnHaveMoreLine = true;
                //m_blnFirstPrint = true;
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
            public clsPrintLine103()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 32);
                }

                p_intPosY += 34;
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
                    }
                }
            }
        }


        #region 104 ~ 109
        private class clsPrintLine104 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine104()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {

                    p_objGrp.DrawLine(m_pen, m_intLeftX, 16, m_intRightX, 16);
                    p_objGrp.DrawLine(m_pen, m_intRightX, 16, m_intRightX, 276);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 16, m_intLeftX, 276);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 276, m_intRightX, 276);

                    p_objGrp.DrawString("产科分娩记录表：", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY);
                    p_intPosY += 3;
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 2, m_intRightX, p_intPosY + 2);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 12, p_intPosY + 7, m_intLeftX + 72, p_intPosY + 7);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 84, p_intPosY + 7, m_intLeftX + 156, p_intPosY + 7);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 24, m_intRightX, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 30, m_intRightX, p_intPosY + 30);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 36, m_intRightX, p_intPosY + 36);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 42, m_intRightX, p_intPosY + 42);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 48, m_intRightX, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 2, m_intLeftX, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 12, p_intPosY + 2, m_intLeftX + 12, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 24, p_intPosY + 7, m_intLeftX + 24, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 36, p_intPosY + 2, m_intLeftX + 36, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 48, p_intPosY + 7, m_intLeftX + 48, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 60, p_intPosY + 7, m_intLeftX + 60, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 72, p_intPosY + 2, m_intLeftX + 72, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 84, p_intPosY + 2, m_intLeftX + 84, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 96, p_intPosY + 7, m_intLeftX + 96, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 108, p_intPosY + 7, m_intLeftX + 108, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 120, p_intPosY + 2, m_intLeftX + 120, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 132, p_intPosY + 7, m_intLeftX + 132, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 144, p_intPosY + 7, m_intLeftX + 144, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 156, p_intPosY + 2, m_intLeftX + 156, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 168, p_intPosY + 2, m_intLeftX + 168, p_intPosY + 48);
                    //p_objGrp.DrawLine(m_pen, m_intLeftX + 180, p_intPosY + 2, m_intLeftX + 180, p_intPosY + 48);

                    p_objGrp.DrawString("婴", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 5);
                    p_objGrp.DrawString("性别", m_fotPrintFont, Brushes.Black, m_intLeftX + 20, p_intPosY + 3);
                    p_objGrp.DrawString("分娩结果", m_fotPrintFont, Brushes.Black, m_intLeftX + 46, p_intPosY + 3);
                    p_objGrp.DrawString("婴儿", m_fotPrintFont, Brushes.Black, m_intLeftX + 73 + 1, p_intPosY + 4);
                    p_objGrp.DrawString("婴儿转归", m_fotPrintFont, Brushes.Black, m_intLeftX + 95, p_intPosY + 3);
                    p_objGrp.DrawString("呼吸", m_fotPrintFont, Brushes.Black, m_intLeftX + 90 + 20 + 24, p_intPosY + 3);
                    p_objGrp.DrawString("抢", m_fotPrintFont, Brushes.Black, m_intLeftX + 157 + 2, p_intPosY + 4);

                }
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
                    }
                }
            }
        }

        private class clsPrintLine105 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine105()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("儿", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 9);
                    p_objGrp.DrawString("男", m_fotPrintFont, Brushes.Black, m_intLeftX + 13 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("女", m_fotPrintFont, Brushes.Black, m_intLeftX + 25 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("活", m_fotPrintFont, Brushes.Black, m_intLeftX + 37 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, m_intLeftX + 49 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, m_intLeftX + 61 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("体重", m_fotPrintFont, Brushes.Black, m_intLeftX + 73 + 1, p_intPosY + 10 + 2);
                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, m_intLeftX + 85 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("转", m_fotPrintFont, Brushes.Black, m_intLeftX + 97 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("出", m_fotPrintFont, Brushes.Black, m_intLeftX + 109 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("自", m_fotPrintFont, Brushes.Black, m_intLeftX + 121 + 2, p_intPosY + 8 + 2);
                    p_objGrp.DrawString("I", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 + 2, p_intPosY + 6 + 2);
                    p_objGrp.DrawString("II", m_fotPrintFont, Brushes.Black, m_intLeftX + 145 + 2, p_intPosY + 6 + 2);
                    //p_objGrp.DrawString("医院", m_fotPrintFont, Brushes.Black, m_intLeftX + 107, p_intPosY + 3);
                    //p_objGrp.DrawString("主要医院感染名称", m_fotPrintFont, Brushes.Black, m_intLeftX + 119, p_intPosY + 8);
                    //p_objGrp.DrawString("ICD-10", m_fotPrintFont, Brushes.Black, m_intLeftX + 152, p_intPosY + 7);
                    p_objGrp.DrawString("救", m_fotPrintFont, Brushes.Black, m_intLeftX + 157 + 2, p_intPosY + 7 + 2);
                    p_objGrp.DrawString("抢救", m_fotPrintFont, Brushes.Black, m_intLeftX + 169 + 5, p_intPosY + 3 + 2);
                }
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
                    }
                }
            }
        }

        private class clsPrintLine106 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine106()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("序", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 13);
                    p_objGrp.DrawString("度", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 + 2, p_intPosY + 10 + 2);
                    p_objGrp.DrawString("度", m_fotPrintFont, Brushes.Black, m_intLeftX + 145 + 2, p_intPosY + 10 + 2);
                    //p_objGrp.DrawString("感染", m_fotPrintFont, Brushes.Black, m_intLeftX + 107, p_intPosY + 10);
                    p_objGrp.DrawString("次", m_fotPrintFont, Brushes.Black, m_intLeftX + 157 + 2, p_intPosY + 12 + 2);
                    p_objGrp.DrawString("成功", m_fotPrintFont, Brushes.Black, m_intLeftX + 169 + 5, p_intPosY + 10 + 2);
                }
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
                    }
                }
            }
        }

        private class clsPrintLine107 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Yellow, 0.1f);
            private string strBaby;
            public clsPrintLine107(string p_strBaby)
            {
                strBaby = p_strBaby;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("号", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 17);
                    p_objGrp.DrawString("性", m_fotPrintFont, Brushes.Black, m_intLeftX + 13 + 2, p_intPosY + 15 + 2);
                    if (strBaby == "1")
                        p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, m_intLeftX + 13 + 2, p_intPosY + 23 + 2);
                    p_objGrp.DrawString("性", m_fotPrintFont, Brushes.Black, m_intLeftX + 25 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("产", m_fotPrintFont, Brushes.Black, m_intLeftX + 37 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("产", m_fotPrintFont, Brushes.Black, m_intLeftX + 49 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("胎", m_fotPrintFont, Brushes.Black, m_intLeftX + 61 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("（g）", m_fotPrintFont, Brushes.Black, m_intLeftX + 73, p_intPosY + 16 + 2);
                    p_objGrp.DrawString("亡", m_fotPrintFont, Brushes.Black, m_intLeftX + 85 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("科", m_fotPrintFont, Brushes.Black, m_intLeftX + 97 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("院", m_fotPrintFont, Brushes.Black, m_intLeftX + 109 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("然", m_fotPrintFont, Brushes.Black, m_intLeftX + 121 + 2, p_intPosY + 15 + 2);
                    p_objGrp.DrawString("窒", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 + 2, p_intPosY + 14 + 2);
                    p_objGrp.DrawString("窒", m_fotPrintFont, Brushes.Black, m_intLeftX + 145 + 2, p_intPosY + 14 + 2);
                    //p_objGrp.DrawString("次数", m_fotPrintFont, Brushes.Black, m_intLeftX + 107, p_intPosY + 16);
                    p_objGrp.DrawString("数", m_fotPrintFont, Brushes.Black, m_intLeftX + 157 + 2, p_intPosY + 17 + 2);
                    p_objGrp.DrawString("次数", m_fotPrintFont, Brushes.Black, m_intLeftX + 169 + 5, p_intPosY + 17 + 2);
                }
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
                    }
                }
            }
        }

        private class clsPrintLine108 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Gray, 0.1f);
            public clsPrintLine108()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("息", m_fotPrintFont, Brushes.Black, m_intLeftX + 134 + 2, p_intPosY + 18 + 2);
                    p_objGrp.DrawString("息", m_fotPrintFont, Brushes.Black, m_intLeftX + 145 + 2, p_intPosY + 18 + 2);
                }

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
                    }
                }
            }
        }

        private class clsPrintLine109 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            private object[] m_objDataArr = null;
            public clsPrintLine109()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 23 + 2);
                    p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 29 + 2);
                    p_objGrp.DrawString("3", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 35 + 2);
                    p_objGrp.DrawString("4", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 41 + 2);
                }
                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    int intIncreaseHeight = 0;

                    for (int i = 0; i < m_objDataArr.Length; i++)
                    {
                        object[] m_objSubDataArr = (object[])m_objDataArr[i];
                        //						p_objGrp.DrawString(m_objSubDataArr[0].ToString(),m_fotPrintFont,Brushes.Black,m_intLeftX+3,p_intPosY+24);

                        p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 12 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 24 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 36 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 48 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 72 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 84 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 96 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[9].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 108 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[10].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 120 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[11].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 132 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[12].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 144 + 2, p_intPosY + 24 + intIncreaseHeight);
                        //p_objGrp.DrawString(m_objSubDataArr[13].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 140, p_intPosY + 24 + intIncreaseHeight);
                        //p_objGrp.DrawString(m_objSubDataArr[14].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 119 , p_intPosY + 24 + intIncreaseHeight);
                        //p_objGrp.DrawString(m_objSubDataArr[15].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 152, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[16].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 156 + 2, p_intPosY + 24 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[17].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 168 + 2 + 5, p_intPosY + 24 + intIncreaseHeight);

                        intIncreaseHeight += 6;
                    }


                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
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



        #endregion

        private class clsPrintLine110 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine110()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("肿瘤专科病人治疗记录表：", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 50);
                }
                p_intPosY += 55;
                if (p_intPosY >= 277)//换页
                {
                    p_intPosY = 1000;
                }
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
            public clsPrintLine111()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY, m_intRightX, p_intPosY);
                    p_objGrp.DrawString("肿瘤分期类型     1.P病理  2.C临床    T     0/1/2/3/4     N    0/1/2/3      M   0/1   分期:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 2);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 20, p_intPosY + 2, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 71, p_intPosY + 2, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 110, p_intPosY + 2, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 144, p_intPosY + 2, 3, 3);

                    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 25, p_intPosY + 2);

                    p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 76, p_intPosY + 2);

                    p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 115, p_intPosY + 2);

                    p_objGrp.DrawString(m_objDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 149, p_intPosY + 2);

                    p_objGrp.DrawString(m_objDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 175, p_intPosY + 2);

                    p_intPosY = p_intPosY + 6;
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY, m_intRightX, p_intPosY);
                    //p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY, m_intRightX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 6, m_intRightX, p_intPosY + 6);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 12, m_intRightX, p_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 18, m_intRightX, p_intPosY + 18);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 24, m_intRightX, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 36, m_intRightX, p_intPosY + 36);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 46, m_intRightX, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 52, m_intRightX, p_intPosY + 52);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 58, m_intRightX, p_intPosY + 58);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 64, m_intRightX, p_intPosY + 64);
                    // p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 66, m_intRightX, p_intPosY + 66);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY, m_intLeftX, p_intPosY + 66);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 23, p_intPosY + 36, m_intLeftX + 23, p_intPosY + 64);//(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 130, p_intPosY + 36, m_intLeftX + 130, p_intPosY + 64);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 140, p_intPosY + 36, m_intLeftX + 140, p_intPosY + 64);

                    p_objGrp.DrawString("I. 放疗 方式:   1根治性 2姑息性 3辅助性   程式:   1连续 2间断 3分段  装置:   1钴 2直加 3X线 4后装", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 2);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 23, p_intPosY + 2, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 87, p_intPosY + 2, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 138, p_intPosY + 2, 3, 3);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 28, p_intPosY + 2);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 92, p_intPosY + 2);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 143, p_intPosY + 2);


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

            public clsPrintLine112()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {


                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("1. 原发灶（首次、复次） 剂量：   GY/    次/     天：起止日期： 20  年   月   至 20  年   月   日", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 7);

                }

                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 24, p_intPosY + 6);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 31, p_intPosY + 6);
                        break;
                    default:
                        break;
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 74, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 88, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 125, p_intPosY + 7);
                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
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
            public clsPrintLine113()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {




                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("2.区域淋巴结（首次、复次）剂量： GY/    次/     天：起止日期： 20  年   月   至 20  年   月   日", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 13);

                }

                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 32, p_intPosY + 12);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 43, p_intPosY + 12);
                        break;
                    default:
                        break;
                }
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 74, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 88, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 125, p_intPosY + 13);

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
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
                    p_objGrp.DrawString("3.         转移灶剂量：          GY/    次/     天：起止日期： 20  年   月   至 20  年   月   日", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 19);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 74, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 88, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 125, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 5, p_intPosY + 19);

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                //
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
            private Font m_fotPrintFont = new Font("SimSun", 9);
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
                    p_objGrp.DrawString("II.化疗 方式:     1根治性  2姑息性 3新辅助性 4辅助性 5新药 6其他", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, p_intPosY + 26);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 21, p_intPosY + 26, 3, 3);
                }


                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 26, p_intPosY + 26);

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
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
            private Font m_fotPrintFont = new Font("SimSun", 9);
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
                    p_objGrp.DrawString("        方法:    1全化  2半化(A插管、胸腔注、腹腔注、髓注)  3其他", m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 31);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 21, p_intPosY + 31, 3, 3);
                }
                if (m_objDataArr[0].ToString() != "")
                {
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 26, p_intPosY + 31);
                }
                if (m_objDataArr[1].ToString() != "")
                {
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotCheckFont, Brushes.Black, m_intLeftX + 53, p_intPosY + 31);
                }
                if (m_objDataArr[2].ToString() != "")
                {
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotCheckFont, Brushes.Black, m_intLeftX + 65, p_intPosY + 31);
                }
                if (m_objDataArr[3].ToString() != "")
                {
                    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotCheckFont, Brushes.Black, m_intLeftX + 77, p_intPosY + 31);
                }
                if (m_objDataArr[4].ToString() != "")
                {
                    p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotCheckFont, Brushes.Black, m_intLeftX + 89, p_intPosY + 31);
                }
                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
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

        #region 117 ~ 118
        private class clsPrintLine117 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private string strChemotherapy;
            public clsPrintLine117(string p_strChemotherapy)
            {
                strChemotherapy = p_strChemotherapy;
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("日期", m_fotPrintFont, Brushes.Black, m_intLeftX + 7, p_intPosY + 40);
                    if (strChemotherapy == "1")
                        p_objGrp.DrawString("无", m_fotPrintFont, Brushes.Black, m_intLeftX + 7, p_intPosY + 47);
                    p_objGrp.DrawString("药物名称（剂量）", m_fotPrintFont, Brushes.Black, m_intLeftX + 62, p_intPosY + 40);
                    p_objGrp.DrawString("疗程", m_fotPrintFont, Brushes.Black, m_intLeftX + 131, p_intPosY + 40);
                    p_objGrp.DrawString("疗效（消失、显效、好转、", m_fotPrintFont, Brushes.Black, m_intLeftX + 142, p_intPosY + 37);
                    p_objGrp.DrawString("不变、恶化、未定）", m_fotPrintFont, Brushes.Black, m_intLeftX + 142, p_intPosY + 41);
                }
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
                    p_objGrp.DrawString("1.", m_fotPrintFont, Brushes.Black, m_intLeftX, p_intPosY + 47);
                    p_objGrp.DrawString("2.", m_fotPrintFont, Brushes.Black, m_intLeftX, p_intPosY + 53);
                    p_objGrp.DrawString("3.", m_fotPrintFont, Brushes.Black, m_intLeftX, p_intPosY + 59);

                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, m_intLeftX + 143, p_intPosY + 47);
                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, m_intLeftX + 143, p_intPosY + 53);
                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, m_intLeftX + 143, p_intPosY + 59);
                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    int intIncreaseHeight = 0;
                    int intHeight = 6;
                    for (int i = 0; i < m_objDataArr.Length; i++)
                    {

                        object[] m_objSubDataArr = (object[])m_objDataArr[i];
                        if (i > 2)
                        {

                            p_objGrp.DrawString(i + 1 + ".", m_fotPrintFont, Brushes.Black, m_intLeftX, p_intPosY + 59 + intHeight);
                            p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, m_intLeftX + 143, p_intPosY + 59 + intHeight);
                            p_objGrp.DrawLine(m_pen, m_intLeftX + 130, p_intPosY + 64, m_intLeftX + 130, p_intPosY + 64 + intHeight);
                            p_objGrp.DrawLine(m_pen, m_intLeftX + 23, p_intPosY + 64, m_intLeftX + 23, p_intPosY + 64 + intHeight);
                            p_objGrp.DrawLine(m_pen, m_intLeftX + 140, p_intPosY + 64, m_intLeftX + 140, p_intPosY + 64 + intHeight);
                            p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 64 + intHeight, m_intRightX, p_intPosY + 64 + intHeight);
                            intHeight += 6;


                        }
                        p_objGrp.DrawString(m_objSubDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 3, p_intPosY + 47 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 26, p_intPosY + 47 + intIncreaseHeight);
                        p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 130, p_intPosY + 47 + intIncreaseHeight);
                        if (m_objSubDataArr[3] != null)
                            switch (m_objSubDataArr[3].ToString())
                            {
                                case "3":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 141, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                case "4":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 150, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                case "5":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 158, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                case "6":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 166, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                case "7":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 172, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                case "8":
                                    p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, m_intLeftX + 178, p_intPosY + 47 + intIncreaseHeight);
                                    break;
                                default:
                                    break;
                            }

                        intIncreaseHeight += 6;
                    }
                }
                m_blnHaveMoreLine = false;
                p_intPosY += 65;

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

        #endregion

        private class clsPrintLine119 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            private int m_intPosY;

            public clsPrintLine119()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY + 3 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    p_intPosY = p_intPosY - 4;
                m_intPosY = p_intPosY + 3;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("离院方式    1.医嘱离院  2.医嘱转院，拟接收医疗结构名称：________________________________________", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 16, m_intPosY, 3, 3);
                    p_objGrp.DrawString("3.医嘱转社区卫生服务机构/乡镇卫生院，拟接收医疗机构名称：_____________4.非医嘱离院 5.死亡 9.其他", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 6);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY + 10, m_intRightX, m_intPosY + 10);
                    p_objGrp.DrawString("是否有出院31天内再入院计划    1.无  2.有，目的：________________________________________________", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 12);
                    p_objGrp.DrawRectangle(m_pen, m_intLeftX + 55, m_intPosY + 12, 3, 3);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY + 16, m_intRightX, m_intPosY + 16);
                    p_objGrp.DrawString("颅脑损伤患者昏迷时间： 入院前______天______小时______分钟    入院后______天_______小时______分钟", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 18);
                }

                //费用
                //p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 40, m_intPosY + 24);

                //p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 66, m_intPosY + 24);

                //p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 90, m_intPosY + 24);

                //p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 113, m_intPosY + 24);

                //p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 140, m_intPosY + 24);

                //p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 168, m_intPosY + 24);



                p_objGrp.DrawString(m_objDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 16, m_intPosY);
                if (m_objDataArr[6].ToString() == "2")
                {
                    p_objGrp.DrawString(m_objDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 108, m_intPosY);
                }
                if (m_objDataArr[6].ToString() == "3")
                {
                    //if (m_objDataArr[7].ToString().Length<8)
                    p_objGrp.DrawString(m_objDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 108, m_intPosY + 6);
                    // else

                }
                p_objGrp.DrawString(m_objDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 55, m_intPosY + 12);

                p_objGrp.DrawString(m_objDataArr[9].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 93, m_intPosY + 12);

                p_objGrp.DrawString(m_objDataArr[10].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 60, m_intPosY + 18);

                p_objGrp.DrawString(m_objDataArr[11].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 75, m_intPosY + 18);

                p_objGrp.DrawString(m_objDataArr[12].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 93, m_intPosY + 18);

                p_objGrp.DrawString(m_objDataArr[13].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 130, m_intPosY + 18);

                p_objGrp.DrawString(m_objDataArr[14].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 145, m_intPosY + 18);

                p_objGrp.DrawString(m_objDataArr[15].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 165, m_intPosY + 18);

                //p_intPosY += (int)enmRectangleInfo.RowStep;
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

        private class clsPrintLine120a : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine120a()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY + 8 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    p_intPosY = p_intPosY - 4;
                m_intPosY = p_intPosY + 30;//8
                if (s_blnPrintTitle)
                {
                    //p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                    //p_objGrp.DrawString("住院费用总计（元）：          床费       护理费        西药        中成药         中草药", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY);
                    p_objGrp.DrawString("住院费用(元):总费用____________________(自付金额____________________)", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 5);
                    p_objGrp.DrawString("                    " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 5);
                    p_objGrp.DrawString("                                                 " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 5);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }

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
                if (p_intPosY + 8 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    m_intPosY = p_intPosY + 40;//8
                if (s_blnPrintTitle)
                {
                    //p_objGrp.DrawString("放射__________化验__________输氧__________输血__________诊疗__________手术__________接生_________", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY);
                    p_objGrp.DrawString("1.医疗综合类服务:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 8);
                    p_objGrp.DrawString("(1)一般医疗服务费_______________     (2)一般治疗操作费_______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("(3)护理费_______________             (4)其他费用______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                  " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                                       " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("          " + m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                                                 " + m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                    p_objGrp.DrawLine(m_pen, m_intLeftX + 40, m_intPosY, m_intLeftX + 40, m_intPosY + 150);
                }

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
                if (p_intPosY + 13 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    m_intPosY = p_intPosY + 60;
                if (s_blnPrintTitle)
                {
                    //p_objGrp.DrawString("检查__________麻醉__________婴儿费________陪床费________其他__________、 __________、 __________", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                    p_objGrp.DrawString("2.诊断类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 8);
                    p_objGrp.DrawString("(5)病理诊断费_______________     (6)实验室诊断费_______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("(7)影像学诊断费_______________             (8)临床诊断项目费______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("             " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                                 " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("               " + m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                                                            " + m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);


                }

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

        private class clsPrintLine122 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine122()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 19 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 80;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("3.治疗类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 8);
                    p_objGrp.DrawString("(9)非手术项目治疗费:_______________ (临床物理治疗费:_______________)", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("(10)手术治疗费:_______________ (麻醉费:______________手术费:______________)", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                     " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                                     " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("               " + m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                                        " + m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                                                            " + m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }
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

        private class clsPrintLine123 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine123()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 25 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 100;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("4.康复类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 3);
                    p_objGrp.DrawString("(11)康复费:_______________ ", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 3);
                    p_objGrp.DrawString("            " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 3);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }
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

        private class clsPrintLine124 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine124()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 31 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 110;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("5.中医类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 4);
                    p_objGrp.DrawString("(12)中医治疗费:_______________ ", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("                " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


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

        private class clsPrintLine125 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine125()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 37 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 120;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("6.西药类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 4);
                    p_objGrp.DrawString("(13)西药费:_______________(抗菌药物费用:_______________) ", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("            " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("                                         " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }

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

        private class clsPrintLine126 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine126()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 43 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 130;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("7.中药类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 4);
                    p_objGrp.DrawString("(14)中成药费:_______________       (15)中草药费:_______________ ", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("             " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("                                                " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


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

        private class clsPrintLine127 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine127()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 49 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 140;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


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

        private class clsPrintLine128 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine128()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 49 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 140;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("8.血液和血液制品类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 8);
                    p_objGrp.DrawString("(16)血费:_________(17)白蛋白类制品费:_________(18)球蛋白类制品费:__________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("(19)凝血因子类制品费:_______________     (20)细胞因子类制品费______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("         " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                     " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                                                 " + m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                     " + m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                                                              " + m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


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

        private class clsPrintLine129 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine129()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 49 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 160;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("9.耗材类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 8);
                    p_objGrp.DrawString("(21)检查用一次性医用材料费:__________   (22)治疗用一次性医用材料费:_________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("(23)手术用一次性医用材料费:_______________", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);
                    p_objGrp.DrawString("                           " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                                                                   " + m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 6);
                    p_objGrp.DrawString("                           " + m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 12);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


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

        private class clsPrintLine130 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine130()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (p_intPosY + 49 >= 273)//换页
                //{
                //    p_intPosY = 1000;
                //    m_intPages++;
                //    return;
                //}
                //if (m_intPages > 2)
                //{
                //    m_intPosY = p_intPosY + 6 * m_intIndex;
                //    m_intIndex++;
                //}
                //else
                m_intPosY = p_intPosY + 180;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("10.其他类:", m_fotPrintFont, Brushes.Black, m_intLeftX + 2, m_intPosY + 4);
                    p_objGrp.DrawString("(24)其他费:_______________ ", m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);
                    p_objGrp.DrawString("            " + m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 42, m_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, m_intLeftX, m_intPosY, m_intRightX, m_intPosY);
                }


                m_blnHaveMoreLine = false;
                p_intPosY = 1000;
                m_intPages++;
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
        #region
        //private class clsPrintLine122 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;

        //    public clsPrintLine122()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 19 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 19 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString("尸检      1.是 2.否              手术、治疗、检查、诊断为本院第一例        1.是 2.否", m_fotPrintFont, Brushes.Black, m_intLeftX + 5, m_intPosY);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 16, m_intPosY, 3, 3);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 134, m_intPosY, 3, 3);
        //        }

        //        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 16, m_intPosY);
        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 134, m_intPosY);


        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //if (s_blnPrintTitle)
        //        //{
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 24, m_intRightX, p_intPosY + 24);
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 30, m_intRightX, p_intPosY + 30);
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 36, m_intRightX, p_intPosY + 36);
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 42, m_intRightX, p_intPosY + 42);
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 48, m_intRightX, p_intPosY + 48);
        //        //    p_objGrp.DrawLine(m_pen, m_intLeftX, p_intPosY + 54, m_intRightX, p_intPosY + 54);
        //        //}

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        //private class clsPrintLine123 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Yellow, 0.1f);
        //    private object[] m_objDataArr = null;

        //    public clsPrintLine123()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 25 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 25 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            string[] strTempArr = m_objDataArr[1].ToString().Split(new char[] { ';', ';' });
        //            string strTime = "/周/月/年";
        //            if (strTempArr.Length == 3)
        //                strTime = ((strTempArr[0].ToString() == "" ? "/" : strTempArr[0].ToString()) + "周") + ((strTempArr[1].ToString() == "" ? "/" : strTempArr[1].ToString()) + "月") + ((strTempArr[2].ToString() == "" ? "/" : strTempArr[2].ToString()) + "年");
        //            p_objGrp.DrawString("随诊      1.是 2.否          随诊期限   " + strTime, m_fotPrintFont, Brushes.Black, m_intLeftX + 5, m_intPosY);
        //            p_objGrp.DrawString("示范病例         1.是 2.否", m_fotPrintFont, Brushes.Black, m_intLeftX + 130, m_intPosY);
        //            p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 16, m_intPosY, 3, 3);
        //            p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 16, m_intPosY);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 150, m_intPosY, 3, 3);
        //        }
        //        //				string m_strYear = DateTime.Parse(m_objDataArr[1]).Year;

        //        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 150, m_intPosY);


        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //				p_objGrp.DrawLine(m_pen,m_intLeftX,p_intPosY,m_intRightX,p_intPosY);

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        //private class clsPrintLine124 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;

        //    public clsPrintLine124()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 31 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 31 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString("血型   1.A  2.B 3.AB 4.O 5.其他               Rh   1.阴 2.阳 3.未查  输血反应", m_fotPrintFont, Brushes.Black, m_intLeftX + 5, m_intPosY);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 16, m_intPosY, 3, 3);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 153, m_intPosY, 3, 3);
        //            p_objGrp.DrawRectangle(m_pen, m_intLeftX + 99, m_intPosY, 3, 3);
        //            p_objGrp.DrawString("1.有 2.无 3.未输血", new Font("SimSun", 8f), Brushes.Black, m_intLeftX + 156, m_intPosY);
        //            p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
        //        }
        //        if (m_objDataArr[0].ToString() == "")
        //            p_objGrp.DrawLine(m_pen, m_intLeftX + 19, m_intPosY, m_intLeftX + 16, m_intPosY + 3);
        //        else
        //            p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 16, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 99, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 153, m_intPosY);


        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //				p_objGrp.DrawLine(m_pen,m_intLeftX,p_intPosY,m_intRightX,p_intPosY);

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        //private class clsPrintLine125 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;

        //    public clsPrintLine125()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 37 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 37 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString("输血品种 1.红细胞      单位  2.血小板     袋   3.血浆        ml 4.全血       ml 5.其他    ml", m_fotPrintFont, Brushes.Black, m_intLeftX + 5, m_intPosY);
        //            p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
        //        }

        //        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 41, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 79, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 112, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 140, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 170, m_intPosY);



        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //				p_objGrp.DrawLine(m_pen,m_intLeftX,p_intPosY,m_intRightX,p_intPosY);

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        //private class clsPrintLine126 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;
        //    public clsPrintLine126()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 43 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 43 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString(" 院际会诊    次    远程会诊     次  护理等级 1.特级    小时  2.I级    日 3.II级   日 4.III级  日", m_fotPrintFont, Brushes.Black, m_intLeftX, m_intPosY);
        //            p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
        //        }

        //        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 20, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 54, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 98, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 127, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 152, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 176, m_intPosY);



        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //				p_objGrp.DrawLine(m_pen,m_intLeftX,p_intPosY,m_intRightX,p_intPosY);

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        //private class clsPrintLine127 : com.digitalwave.Utility.Controls.clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 10.5f);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;
        //    public clsPrintLine127()
        //    {

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (p_intPosY + 49 >= 273)//换页
        //        {
        //            p_intPosY = 1000;
        //            m_intPages++;
        //            return;
        //        }
        //        if (m_intPages > 2)
        //        {
        //            m_intPosY = p_intPosY + 6 * m_intIndex;
        //            m_intIndex++;
        //        }
        //        else
        //            m_intPosY = p_intPosY + 49 + 24;
        //        if (s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString("5. 重症监护      小时   6. 特殊护理     日", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, m_intPosY);
        //            p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
        //        }

        //        p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 23, m_intPosY);

        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, m_intLeftX + 70, m_intPosY);


        //        //				p_intPosY += (int)enmRectangleInfo.RowStep;
        //        //				p_objGrp.DrawLine(m_pen,m_intLeftX,p_intPosY,m_intRightX,p_intPosY);

        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
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
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}
        #endregion

        private class clsPrintLine131 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine131()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY + 55 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    m_intPosY = p_intPosY + 190;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("说明： 医疗付款方式 1.城镇职工基本医疗保险 2.城镇居民基本医疗保险 3.新型农村合作医疗 4.贫困救助", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, m_intPosY);
                    p_objGrp.DrawString("5.商业医疗保险 6.全公费 7.全自费 8.其他社会保险 9.其他", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, m_intPosY + 6);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, m_intPosY - 1, (int)enmRectangleInfo.RightX1, m_intPosY - 1);
                }

                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_intPages = 1;
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

                    }
                }
            }
        }

        private class clsPrintLine132 : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine132()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (p_intPosY + 61 >= 273)//换页
                {
                    p_intPosY = 1000;
                    m_intPages++;
                    return;
                }
                if (m_intPages > 2)
                {
                    m_intPosY = p_intPosY + 6 * m_intIndex;
                    m_intIndex++;
                }
                else
                    m_intPosY = p_intPosY + 196;
                if (s_blnPrintTitle)
                {
                    p_objGrp.DrawString("(二) 凡可由医院信息系统提供住院费用清单的，住院病案首页中可不填写“住院费用”，但必须按首页的", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, m_intPosY + 6);
                    p_objGrp.DrawString("费用分类提供电子数据", m_fotPrintFont, Brushes.Black, m_intLeftX + 1, m_intPosY + 12);
                }
                if (m_intPages > 2)
                {
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 16, m_intRightX, 16);
                    p_objGrp.DrawLine(m_pen, m_intRightX, 16, m_intRightX, 276);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 16, m_intLeftX, 276);
                    p_objGrp.DrawLine(m_pen, m_intLeftX, 276, m_intRightX, 276);
                }

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
                m_intIndex = 0;
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

                    }
                }
            }
        }
        #endregion PrintClasses

        #endregion

        #region 在外部测试本打印的演示实例.
        //		using System.IO;
        //		using System.Runtime.Serialization;
        //		System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        //		private void m_mthfrmLoad()
        //		{	
        //			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
        //			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
        //			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
        //			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
        //		}
        //		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //		{			
        //			objPrintTool.m_mthPrintPage(e);
        //		}
        //
        //		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //		{
        //			objPrintTool.m_mthBeginPrint(e);				
        //		}
        //
        //		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //		{
        //			objPrintTool.m_mthEndPrint(e);
        //		}
        //
        //		clsInHospitalMainRecordPrintTool objPrintTool;
        //		private void m_mthDemoPrint_FromDataSource()
        //		{	
        //			objPrintTool=new clsInHospitalMainRecordPrintTool();
        //			objPrintTool.m_mthInitPrintTool(null);	
        //			if(m_objBaseCurrentPatient==null || this.m_trvTime.SelectedNode ==null || this.m_trvTime.SelectedNode==m_trvTime.Nodes[0])
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
        //			else 
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
        //									
        //			objPrintTool.m_mthInitPrintContent();	
        //			
        //			//保存到文件
        //			object objtemp=objPrintTool.m_objGetPrintInfo();
        //			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //				
        //			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Create);
        //				
        //			objForm.Serialize(objStream,objtemp);
        //				
        //			objStream.Flush();
        //			objStream.Close();
        //						
        //			m_mthStartPrint();
        //		}
        //		private void m_mthDemoPrint_FromFile()
        //		{	
        //			objPrintTool=new clsInHospitalMainRecordPrintTool();
        //			objPrintTool.m_mthInitPrintTool(null);	
        //		
        //			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Open);
        //			object objtemp = objForm.Deserialize(objStream);//
        //			objStream.Close();
        //				
        //			objPrintTool.m_mthSetPrintContent(objtemp);		
        //		
        //			m_mthStartPrint();
        //		}
        //		private void m_mthStartPrint()
        //		{			
        //			PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
        //			ppdPrintPreview.Document = m_pdcPrintDocument;
        //			ppdPrintPreview.ShowDialog();
        //		}
        //		bool bbb=true;
        //		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        //		{
        //			if(bbb)
        //				m_mthDemoPrint_FromDataSource();
        //			else m_mthDemoPrint_FromFile();
        //			bbb= !bbb;
        //			return 1;
        //		}
        #endregion 在外部测试本打印的演示实例.
    }
}
