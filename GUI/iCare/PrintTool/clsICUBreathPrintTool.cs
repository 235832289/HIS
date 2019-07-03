using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;

namespace iCare
{
    /// <summary>
    /// ICU呼吸机的打印工具类,Jacky-2003-9-11
    /// </summary>
    public class clsICUBreathPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsRecordsDomain m_objRecordsDomain;
        private clsPrintInfo_ICUBreath m_objPrintInfo;

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
            m_objPrintInfo = new clsPrintInfo_ICUBreath();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_strWeight = m_objPatient != null ? "50" : "";//待定
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            if (m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }
            if (m_objPrintInfo.m_strInPatentID == "")
                return;
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.ICUBreath);

            long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objTransDataArr, out m_objPrintInfo.m_dtmFirstPrintDateArr, out m_objPrintInfo.m_blnIsFirstPrintArr);
            if (lngRes <= 0)
                return;

            //按记录时间(CreateDate)排序 
            m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
            //设置表单内容到打印中
            m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr, m_objPrintInfo.m_dtmFirstPrintDateArr);
            m_objPrintInfo.m_objPrintDataArr = m_objPrintDataArr;

            m_blnWantInit = false;
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_ICUBreath")
            {
                //clsPublicFunction.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_ICUBreath)p_objPrintContent;
            m_objPrintDataArr = m_objPrintInfo.m_objPrintDataArr;

            m_blnWantInit = false;
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
            if (m_objPrintInfo.m_objPrintDataArr.Length == 0 || m_objPrintInfo.m_objTransDataArr.Length == 0)
                return null;
            else
                return m_objPrintInfo;
        }

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            m_fotTitleFont = new Font("SimSun", 20, FontStyle.Bold);
            m_fotHeaderFont = new Font("SimSun", 12f);
            m_fotSmallFont = new Font("SimSun", 10.5f);
            m_fotTinyFont = new Font("SimSun", 8f);
            m_GridPen = new Pen(Color.Black, 1);
            m_slbBrush = new SolidBrush(Color.Black);

            m_objPageSetting = new clsPrintPageSettingForRecord();

        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {
            m_objPageSetting = null;
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotSmallFont.Dispose();
            m_fotTinyFont.Dispose();
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
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "") return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrintArr != null)
            {
                ArrayList arlRecordType = new ArrayList();
                ArrayList arlOpenDate = new ArrayList();
                int intUpdateIndex = -1;//若没有任何记录
                for (int i = 0; i < m_objPrintInfo.m_blnIsFirstPrintArr.Length; i++)
                {
                    if (m_objPrintInfo.m_blnIsFirstPrintArr[i])
                    {
                        //更新记录，只需使用新的首次打印时间作为有效的输入参数。
                        //存放记录类型
                        if (m_objPrintInfo.m_objTransDataArr[i] != null)
                        {
                            arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
                            //存放记录的OpenDate
                            arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);
                            intUpdateIndex = i;
                        }
                    }
                }

                if (intUpdateIndex >= 0)
                {
                    m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), (int[])arlRecordType.ToArray(typeof(int)), (DateTime[])arlOpenDate.ToArray(typeof(DateTime)), m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
                }
                m_objPrintInfo.m_objTransDataArr = null;
                m_objPrintInfo.m_blnIsFirstPrintArr = null;
            }
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
        }


        /// <summary>
        /// 按记录顺序(CreateDate)把输入的p_objTansDataInfoArr排序
        /// </summary>
        /// <param name="p_objTansDataInfoArr"></param>
        private void m_mthSortTransData(ref clsTransDataInfo[] p_objTansDataInfoArr)
        {
            ArrayList m_arlSort = new ArrayList(p_objTansDataInfoArr);
            m_arlSort.Sort();
            p_objTansDataInfoArr = (clsTransDataInfo[])m_arlSort.ToArray(typeof(clsTransDataInfo));
        }

        #region 有关打印的声明
        /// <summary>
        /// 当前行的Y坐标
        /// </summary>
        private int m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
        /// <summary>
        /// 每行数据行的高度
        /// </summary>
        int intTempDeltaY = 38;
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
        /// 最小的字体
        /// </summary>
        private Font m_fotTinyFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 记录打印到第几页
        /// </summary>
        private int m_intNowPage = 1;
        /// <summary>
        /// 当前打印的记录的序号
        /// </summary>
        private int m_intCurrentRecord = 0;
        /// <summary>
        /// 旧记录打完,准备打印一条新记录
        /// </summary>
        bool m_blnBeginPrintNewRecord = true;

        /// <summary>
        /// （若要保留历史痕迹）当前记录内容
        /// </summary>
        private string[][] m_strValueArr;

        /// <summary>
        /// 当前记录的行序数（修改的次第数）
        /// </summary>
        private int m_intNowRowInOneRecord = 0;

        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;

        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRecordRectangleInfo
        {//A3纸张，横向 ：1620*1024 Size
            /// <summary>
            /// 最佳宽度
            /// </summary>
            PerformWith = 45,
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 200,
            /// <summary>
            /// 表头第一条分割线
            /// </summary>
            RowsMark1 = 22,
            /// <summary>
            /// 表头第二条分割线
            /// </summary>
            RowsMark2 = 42,
            /// <summary>
            /// 表头第三条分割线（表中用户数据的起点线）
            /// </summary>
            RowsMark3 = 180,
            /// <summary>
            /// 表头呼吸音分割线
            /// </summary>
            RowsMarkBreathSound = 90,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 30,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 1620 - 35,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 38,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 17,
            /// <summary>
            /// 文字在格子中相对格子顶端的垂直偏移
            /// </summary>
            VOffSet = 20,
            /// <summary>
            /// 列的数目
            /// </summary>
            ColumnsNum = 19,
            /// <summary>
            /// 第一条间隔线(X),时间（起点线）
            /// </summary>			
            ColumnsMark1 = 75,

            /// <summary>
            /// 第二条间隔线(X)，通气方式（起点线）
            /// </summary>
            ColumnsMark2 = ColumnsMark1 + PerformWith,//120

            /// <summary>
            /// 第3条间隔线(X)，呼吸音 左（起点线）
            /// </summary>
            ColumnsMark3 = ColumnsMark2 + 2 * (int)PerformWith - 20,//210

            /// <summary>
            /// 呼吸音 右（起点线）
            /// </summary>
            ColumnsMark4 = ColumnsMark3 + PerformWith,//250

            /// <summary>
            /// 插管深度（起点线）
            /// </summary>
            ColumnsMark5 = ColumnsMark4 + PerformWith,//295,

            /// <summary>
            /// 气囊压力（起点线）
            /// </summary>
            ColumnsMark6 = ColumnsMark5 + PerformWith - 15,//340,

            /// <summary>
            /// TIDAL_VOLUME（起点线）
            /// </summary>
            ColumnsMark7 = ColumnsMark6 + PerformWith - 15,//385,

            /// <summary>
            /// RATE（起点线）
            /// </summary>
            ColumnsMark8 = ColumnsMark7 + PerformWith - 5,//425,

            /// <summary>
            /// PEAK_FLOW（起点线）
            /// </summary>
            ColumnsMark9 = ColumnsMark8 + PerformWith - 5,//470,

            /// <summary>
            /// O2（起点线）
            /// </summary>
            ColumnsMark10 = ColumnsMark9 + PerformWith - 5,//515,

            /// <summary>
            /// PS（起点线）
            /// </summary>
            ColumnsMark11 = ColumnsMark10 + PerformWith,//560,

            /// <summary>
            /// ASSIST_SENSITIVITY（起点线）
            /// </summary>
            ColumnsMark12 = ColumnsMark11 + PerformWith,//605,

            /// <summary>
            /// INSPIRATORY_PAUSE（起点线）
            /// </summary>
            ColumnsMark13 = ColumnsMark12 + PerformWith,//490,

            /// <summary>
            /// MMV_LEVEL（起点线）
            /// </summary>
            ColumnsMark14 = ColumnsMark13 + PerformWith,//520,

            /// <summary>
            /// COMPLIANCE_COMP（起点线）
            /// </summary>
            ColumnsMark15 = ColumnsMark14 + PerformWith,//550,

            /// <summary>
            /// INSPIRATORY_TIME（起点线）
            /// </summary>
            ColumnsMark16 = ColumnsMark15 + PerformWith,//580,

            /// <summary>
            /// INSPIRATORY_PRESSURE（起点线）
            /// </summary>
            ColumnsMark17 = ColumnsMark16 + PerformWith,//610,

            /// <summary>
            /// BASE_FLOW（起点线）
            /// </summary>
            ColumnsMark18 = ColumnsMark17 + PerformWith,//640,

            /// <summary>
            /// FLOW_TRIGGER（起点线）
            /// </summary>
            ColumnsMark19 = ColumnsMark18 + PerformWith,//667,

            /// <summary>
            /// PRESSURE_SLOPE（起点线）
            /// </summary>
            ColumnsMark20 = ColumnsMark19 + PerformWith,//670,

            /// <summary>
            /// PEEP（起点线）
            /// </summary>
            ColumnsMark21 = ColumnsMark20 + PerformWith,//700,
            /// <summary>
            /// TIDAL_VOL（起点线）
            /// </summary>
            ColumnsMark22 = ColumnsMark21 + PerformWith,//730,
            /// <summary>
            /// TOTAL_MV（起点线）
            /// </summary>
            ColumnsMark23 = ColumnsMark22 + PerformWith,//775,
            /// <summary>
            /// SPONT_MV（起点线）
            /// </summary>
            ColumnsMark24 = ColumnsMark23 + PerformWith,//820,
            /// <summary>
            /// TOTAL（起点线）
            /// </summary>
            ColumnsMark25 = ColumnsMark24 + PerformWith,//865,
            /// <summary>
            /// SPONT（起点线）
            /// </summary>
            ColumnsMark26 = ColumnsMark25 + PerformWith,//910,
            /// <summary>
            /// I_E_RATIO（起点线）
            /// </summary>
            ColumnsMark27 = ColumnsMark26 + PerformWith,//955,
            /// <summary>
            /// Ti（起点线）
            /// </summary>
            ColumnsMark28 = ColumnsMark27 + PerformWith,//1000,
            /// <summary>
            /// MMV（起点线）
            /// </summary>
            ColumnsMark29 = ColumnsMark28 + PerformWith,//1045,
            /// <summary>
            /// PEAR（起点线）
            /// </summary>
            ColumnsMark30 = ColumnsMark29 + PerformWith + 5,//1090,
            /// <summary>
            /// MEAN（起点线）
            /// </summary>
            ColumnsMark31 = ColumnsMark30 + PerformWith,//1135,
            /// <summary>
            /// PLATEAU（起点线）
            /// </summary>
            ColumnsMark32 = ColumnsMark31 + PerformWith,//1180,	
            /// <summary>
            /// 签名（起点线）
            /// </summary>
            ColumnsMark33 = ColumnsMark32 + PerformWith,//1230	
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
            Dept_Name_Title,
            Dept_Name,
            BedNo_Title,
            BedNo,
            Weight_Title,
            Weight,

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
                        m_fReturnPoint = new PointF(720f, 60f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(543f, 100f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(213f, 150f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(263f, 150f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(550f, 150f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(600f, 150f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(380f, 150f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(430f, 150f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(480f, 150f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(530f, 150f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(700f, 150f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(750f, 150f);
                        break;

                    case (int)enmItemDefination.Weight_Title:
                        m_fReturnPoint = new PointF(850f, 150f);
                        break;
                    case (int)enmItemDefination.Weight:
                        m_fReturnPoint = new PointF(900f, 150f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(1050f, 150f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(1120f, 150f);
                        break;
                    case (int)enmItemDefination.Print_Date_Title:
                        m_fReturnPoint = new PointF(1230f, 150f);
                        break;
                    case (int)enmItemDefination.Print_Date:
                        m_fReturnPoint = new PointF(1310f, 150f);
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

        #region 打印
        private clsICUBreath[] m_objPrintDataArr;
        /// <summary>
        /// 设置打印内容。
        /// </summary>
        /// <param name="p_objTransDataArr"></param>
        /// <param name="p_dtmFirstPrintDate"></param>
        private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
            DateTime[] p_dtmFirstPrintDate)
        {
            if (p_objTransDataArr == null || p_dtmFirstPrintDate == null || p_objTransDataArr.Length != p_dtmFirstPrintDate.Length)
            {
                clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
                return;
            }
            ArrayList m_arlTemp = new ArrayList();
            for (int i1 = 0; i1 < p_objTransDataArr.Length; i1++)
            {
                //if(p_objTransDataArr[i1].m_intFlag==(int)enmRecordsType.ICUBreath)
                m_arlTemp.Add(p_objTransDataArr[i1]);

            }
            m_objPrintDataArr = (clsICUBreath[])m_arlTemp.ToArray(typeof(clsICUBreath));


        }

        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

        // 打印页，每打印一页，调用一次，是打印中最有用的函数。
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            try
            {
                p_objPrintPageArg.HasMorePages = false;
                m_mthPrintTitleInfo(p_objPrintPageArg);
                m_mthPrintRectangleInfo(p_objPrintPageArg);
                m_mthPrintHeaderInfo(p_objPrintPageArg);

                if (m_objPrintInfo.m_strInPatentID == "" || m_objPrintDataArr == null || m_objPrintDataArr.Length == 0)
                    return;
                while (m_intCurrentRecord < m_objPrintDataArr.Length)
                {
                    if (m_intCurrentRecord == 0)
                        m_intSetPrintOneValueRows(p_objPrintPageArg, ref m_intPosY);

                    if (m_blnCheckPageChange(m_intPosY + intTempDeltaY, p_objPrintPageArg) == true)
                        return;
                    m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intPosY);

                    if (m_blnBeginPrintNewRecord)
                    {
                        m_intCurrentRecord++;

                        m_mthPrintOneHorizontalLine(p_objPrintPageArg, m_intPosY);

                        int intMaxRows = m_intSetPrintOneValueRows(p_objPrintPageArg, ref m_intPosY);
                        if (m_blnCheckPageChange(m_intPosY + intMaxRows * intTempDeltaY, p_objPrintPageArg) == true)
                            return;
                    }

                }
                m_mthPrintVLines(p_objPrintPageArg, m_intPosY);
                //页脚//////////////////////////////////////////////////////////////
                p_objPrintPageArg.Graphics.DrawString("（第" + m_intNowPage.ToString() + "页）", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32,
                    m_intPosY + (int)enmRecordRectangleInfo.VOffSet);

                #region 打印完毕，ReSet(复位)操作
                if (m_intCurrentRecord == m_objPrintDataArr.Length)
                {
                    m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
                    m_intCurrentRecord = 0;//当前记录的序号复位，以备下一次打印操作
                    m_blnBeginPrintNewRecord = true;//复位
                    m_intNowPage = 1;//复位						
                }
                #endregion
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

            }
        }

        /// <summary>
        /// 检查是否换页,true:换页，false:不换页
        /// </summary>
        /// <param name="p_intYBottom">要检测的底线Y坐标</param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool m_blnCheckPageChange(int p_intYBottom, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (p_intYBottom >= 1050)
            {
                e.HasMorePages = true;

                //Print VLine
                m_mthPrintVLines(e, m_intPosY);
                m_mthPrintOneHorizontalLine(e, m_intPosY);

                //页脚//////////////////////////////////////////////////////////////
                e.Graphics.DrawString("（第" + m_intNowPage.ToString() + "页）", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32,
                    m_intPosY + (int)enmRecordRectangleInfo.VOffSet);


                m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
                m_intNowPage++;
                return true;

            }
            else return false;
        }

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
        }

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("中 心 ICU 呼 吸 机 治 疗 监 护 记 录 单", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));


            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            //			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
            //			e.Graphics.DrawString(m_objPrintInfo.m_strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));
            //
            //			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,new PointF(430f,150f));
            //			e.Graphics.DrawString(m_objPrintInfo.m_strAreaName ,m_fotSmallFont,m_slbBrush,new PointF(480f,150f));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("体重：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Weight_Title));
            e.Graphics.DrawString((m_objPrintInfo.m_strWeight == null || m_objPrintInfo.m_strWeight == "") ? "     kg" : m_objPrintInfo.m_strWeight + "   kg", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Weight));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

            e.Graphics.DrawString("打印日期：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Print_Date_Title));
            e.Graphics.DrawString((m_objPrintInfo.m_strInPatentID != "") ? DateTime.Now.ToString("yyyy年MM月dd日") : "    年  月  日", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Print_Date));

        }
        #endregion

        #region 画表头格子
        /// <summary>
        ///  画表头格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region 画格子横线
            for (int i1 = 0; i1 < 4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ; i1++)
            {
                if (i1 == 0)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY);
                else if (i1 == 3)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3);
                else if (i1 == 1)
                {
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1);
                }
                else //if(i1==2)
                {
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2);
                }
            }

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMarkBreathSound,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMarkBreathSound);
            #endregion 画格子横线

            #region 画格子竖线
            int intXPos = (int)enmRecordRectangleInfo.LeftX;
            int intYTop = (int)enmRecordRectangleInfo.TopY;
            int intYBottom = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;

            //画左边沿线
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);


            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop + (int)enmRecordRectangleInfo.RowsMarkBreathSound, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark21;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22;
            intYTop = (int)enmRecordRectangleInfo.TopY;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31;
            intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33;
            intYTop = (int)enmRecordRectangleInfo.TopY;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.RightX;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);


            #endregion

        }


        #endregion

        #region 画标题的栏目
        /// <summary>
        /// 画标题的栏目
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            ///标题栏目的各行字的Y坐标（共分为9行）
            int[] intYPosFontArr = new int[9]{ (int)enmRecordRectangleInfo.TopY + 3,//入量 :0
											   (int)enmRecordRectangleInfo.TopY + 25,//日（期）:1
											   (int)enmRecordRectangleInfo.TopY + 45,//ml :2
											   (int)enmRecordRectangleInfo.TopY + 65,//瞳孔 ：3
											   (int)enmRecordRectangleInfo.TopY + 85,//T :4
											   (int)enmRecordRectangleInfo.TopY + 105,//（日）期，大小 ：5
											   (int)enmRecordRectangleInfo.TopY + 125,//通（畅） ：6
											   (int)enmRecordRectangleInfo.TopY + 145,//左右：7
											   (int)enmRecordRectangleInfo.TopY + 165//（通）畅 ：8				   
										   };
            e.Graphics.DrawString("日", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 25, intYPosFontArr[1]);
            e.Graphics.DrawString("期", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 25, intYPosFontArr[5]);

            e.Graphics.DrawString("时", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1 + 15, intYPosFontArr[1]);
            e.Graphics.DrawString("间", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1 + 15, intYPosFontArr[5]);

            e.Graphics.DrawString("通", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + 5, intYPosFontArr[1]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("方", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("式", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + 5, intYPosFontArr[7]);

            e.Graphics.DrawString("呼吸音", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3 + 15, intYPosFontArr[2]);
            e.Graphics.DrawString("左", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("右", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4 + 5, intYPosFontArr[5]);

            e.Graphics.DrawString("插", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5 + 5, intYPosFontArr[1]);
            e.Graphics.DrawString("管", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("深", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("度", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5 + 5, intYPosFontArr[7]);

            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6 + 5, intYPosFontArr[1]);
            e.Graphics.DrawString("囊", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("力", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6 + 5, intYPosFontArr[7]);

            //设定参数
            e.Graphics.DrawString("设定参数", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, intYPosFontArr[0]);
            e.Graphics.DrawString("潮", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(TV)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("L", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("频", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("率", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("(R)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 1, intYPosFontArr[4]);
            e.Graphics.DrawString("BPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("峰", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("值", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("流", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("速", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(PF)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("氧", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("浓", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("度", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(O2%)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("%", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("力", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("支", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("持", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(PS)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("辅", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("助", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("灵", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("敏", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("度", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 5, intYPosFontArr[6]);
            e.Graphics.DrawString("(AS)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 1, intYPosFontArr[7]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("暂", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("停", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(IPu)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("秒", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("水", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("平", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("设", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("置", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(ML)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("顺", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("应", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("性", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("补", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("偿", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[6]);
            e.Graphics.DrawString("(CC)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 1, intYPosFontArr[7]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("时", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("间", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(IT)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("秒", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("力", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(IPr)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("基", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("础", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("流", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(BF)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("流", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("触", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("发", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(FT)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("力", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("斜", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("坡", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(PSe)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20 + 1, intYPosFontArr[6]);

            e.Graphics.DrawString("PEEP", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark21 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark21 + 1, intYPosFontArr[8]);


            //监测数值
            e.Graphics.DrawString("监测数值", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 22, intYPosFontArr[0]);
            e.Graphics.DrawString("呼出潮气量监测", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[1]);
            e.Graphics.DrawString("呼出频率监测", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[1]);
            e.Graphics.DrawString("压力监测", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30 + 20, intYPosFontArr[1]);

            e.Graphics.DrawString("潮", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(TV)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("L", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("总", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("分钟", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("通气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(TM)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[6]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("自主", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("呼吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("分钟", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("通气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[6]);
            e.Graphics.DrawString("(SM)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[7]);
            e.Graphics.DrawString("LPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("总", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("频", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("率", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(To)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("BPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("自主", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("呼吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("频率", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(S)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("BPM", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("：", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("呼", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("比", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("率", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 5, intYPosFontArr[6]);
            e.Graphics.DrawString("(IER)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27 + 1, intYPosFontArr[7]);

            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("时", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("间", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 5, intYPosFontArr[5]);
            e.Graphics.DrawString("(Ti)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 1, intYPosFontArr[6]);
            e.Graphics.DrawString("秒", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28 + 5, intYPosFontArr[8]);

            e.Graphics.DrawString("最小", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[2]);
            e.Graphics.DrawString("分钟", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[3]);
            e.Graphics.DrawString("通气", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[4]);
            e.Graphics.DrawString("量通", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[5]);
            e.Graphics.DrawString("气百", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[6]);
            e.Graphics.DrawString("分比", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 6, intYPosFontArr[7]);
            e.Graphics.DrawString("(MMV)%", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29 + 2, intYPosFontArr[8]);

            e.Graphics.DrawString("峰", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("(Pe)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("平", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("均", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(Me)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("平", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32 + 5, intYPosFontArr[2]);
            e.Graphics.DrawString("台", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32 + 5, intYPosFontArr[3]);
            e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32 + 5, intYPosFontArr[4]);
            e.Graphics.DrawString("(Pu)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32 + 1, intYPosFontArr[5]);
            e.Graphics.DrawString("cmH2O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32 + 1, intYPosFontArr[8]);

            e.Graphics.DrawString("签名", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33 + 5, intYPosFontArr[4]);

        }
        #endregion

        #region 打印所有的垂直线
        /// <summary>
        /// 打印所有的垂直线
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intPageBottomY"></param>
        private void m_mthPrintVLines(PrintPageEventArgs e, int p_intPageBottomY)
        {
            #region 画格子竖线
            int intXPos = (int)enmRecordRectangleInfo.LeftX;
            int intYTop = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
            int intYBottom = p_intPageBottomY;

            //画左边沿线
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark21;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordRectangleInfo.RightX;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            #endregion
        }
        #endregion

        #region 打印一条水平线
        /// <summary>
        /// 打印一条水平线
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        private void m_mthPrintOneHorizontalLine(System.Drawing.Printing.PrintPageEventArgs e, int p_intBottomY)
        {
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                p_intBottomY,
                (int)enmRecordRectangleInfo.RightX,
                p_intBottomY);
        }
        #endregion

        #region 打印一行数值,并判断当前记录是否打印完
        /// <summary>
        /// 打印一行数值,并判断当前记录是否打印完
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        /// <returns></returns>
        private bool m_blnPrintOneValue(System.Drawing.Printing.PrintPageEventArgs e, int p_intBottomY)
        {
            p_intBottomY += (int)enmRecordRectangleInfo.VOffSet;
            #region 如果是新记录，打印日期
            if (m_blnBeginPrintNewRecord == true)
            {
                m_intNowRowInOneRecord = 0;

                //读出日期
                string strCreateDate;
                string strCreateTime;
                string strCreateDateTime;

                if (m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
                {
                    strCreateDate = "";
                    strCreateTime = "";
                    strCreateDateTime = "";
                }
                else
                {
                    strCreateDateTime = m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                    try
                    {
                        strCreateDate = DateTime.Parse(strCreateDateTime).ToString("yyyy-M-d");
                        strCreateTime = DateTime.Parse(strCreateDateTime).ToString("HH:mm");
                    }
                    catch
                    { strCreateDate = "不详"; strCreateTime = "不详"; }
                }
                //开始打印一条新记录/////////////////////////////////////////////////////////////////////
                e.Graphics.DrawString(strCreateDate, m_fotSmallFont, m_slbBrush,
                    (int)enmRecordRectangleInfo.LeftX,
                    p_intBottomY);
                e.Graphics.DrawString(strCreateTime, m_fotSmallFont, m_slbBrush,
                    (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1 + 1,
                    p_intBottomY);
            }
            #endregion



            #region 按修改顺序打印当前记录的某一行
            bool blnIsRecordFinish = m_blnPrintOneRowValue(m_strValueArr, m_intNowRowInOneRecord, e, p_intBottomY);


            #region 签名（作过修改的人签名）
            string strSign;
            if (m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null
                || m_intNowRowInOneRecord > m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length - 1)
                strSign = "";
            else
                strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName;
            //			clsEmployee objclsEmployee=new clsEmployee(m_objclsICUBreathRecordContent_AllArr[m_intCurrentRecord].m_objclsICUBreathRecordContentArr[m_intNowRowInOneRecord].m_strModifyUserID);
            //			if(objclsEmployee!=null)
            //				strSign=objclsEmployee.m_StrFirstName;			
            e.Graphics.DrawString(strSign, m_fotSmallFont, m_slbBrush,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark33 + 1,
                p_intBottomY);
            #endregion

            m_blnBeginPrintNewRecord = blnIsRecordFinish;//当前记录是否打完					
            m_intNowRowInOneRecord++;
            #endregion

            m_intPosY += intTempDeltaY;
            return blnIsRecordFinish;
        }


        #endregion 打印一行数值,并判断当前记录是否打印完

        #region 打印一行数值
        /// <summary>
        /// 打印一行数值
        /// </summary>
        /// <param name="p_strValueArr">数值(从“通气方式”到“平台压”，共31个)</param>
        /// <param name="p_intNowRowInOneRecord">第几次的结果:等价于NowRowInOneRecord</param>
        /// <param name="e">打印参数</param>
        /// <param name="p_intPosY">Y坐标</param>
        private bool m_blnPrintOneRowValue(string[][] p_strValueArr, int p_intNowRowInOneRecord, System.Drawing.Printing.PrintPageEventArgs e, int p_intPosY)
        {
            #region 打印每次修改的单行记录
            if (p_intNowRowInOneRecord < p_strValueArr.Length)
            {
                string[] strValueArr = p_strValueArr[p_intNowRowInOneRecord];

                CharacterRange[] rgnDSTArr = new CharacterRange[1];
                rgnDSTArr[0] = new CharacterRange(0, 0);

                RectangleF rtfText = new RectangleF(0, 0, 10000, 100);

                StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);

                RectangleF rtfBounds;

                Region[] rgnDST;

                int intTempColumn = 0;//当前的列数（相对）（指除去日期和时间两列之后的相对列序号）
                int intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
                //通气方式
                #region 打印一格，（以下完全相同）
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
                //呼吸音左
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
                //呼吸音右
                #region 打印一格

                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark18;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark19;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark20;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark21;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark22;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark23;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark24;//当前的X坐标

                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark25;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark26;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark27;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark28;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark29;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark30;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark31;//当前的X坐标
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

                intTempColumn++;
                intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark32;//当前的X坐标				
                #region 打印一格
                if (strValueArr[intTempColumn] != null && strValueArr[intTempColumn].Trim().Length != 0)
                {
                    e.Graphics.DrawString(strValueArr[intTempColumn], m_fotSmallFont, Brushes.Black, intPosX, p_intPosY);
                    if (p_intNowRowInOneRecord + 1 < p_strValueArr.Length)
                    {
                        if (strValueArr[intTempColumn] != p_strValueArr[p_intNowRowInOneRecord + 1][intTempColumn])
                        {
                            rtfText.X = intPosX;
                            rtfText.Y = p_intPosY;

                            rgnDSTArr[0].First = 0;
                            rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

                            stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);

                            rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn], m_fotSmallFont, rtfText, stfMeasure);

                            rtfBounds = rgnDST[0].GetBounds(e.Graphics);

                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2);
                            e.Graphics.DrawLine(Pens.Red, rtfBounds.X, rtfBounds.Y + rtfBounds.Height / 2 + 3, rtfBounds.X + rtfBounds.Width, rtfBounds.Y + rtfBounds.Height / 2 + 3);
                        }
                    }
                }
                #endregion	打印一格

            }
            #endregion 打印每次修改的单行记录

            if (p_intNowRowInOneRecord >= p_strValueArr.Length - 1)
                return true;
            else return false;
        }

        #endregion 打印一行数值


        #region 设置当前要打印的一条记录数据
        /// <summary>
        /// 设置当前要打印的一条记录数据,返回：该条记录的最大打印行数(除多行打印的5列外)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        /// <returns></returns>
        private int m_intSetPrintOneValueRows(PrintPageEventArgs e, ref int p_intBottomY)
        {
            if (m_objPrintDataArr == null || m_intCurrentRecord >= m_objPrintDataArr.Length)
                return 0;

            if (m_objPrintDataArr[m_intCurrentRecord].m_intFlag == (int)enmRecordsType.ICUBreath && (m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null || m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length == 0))
                return 0;

            int intRowsOfOneRecord;
            string strModifyDate;

            try
            {
                #region 如果是新记录，判断是否保留痕迹
                int intLenth;
                if (m_blnBeginPrintNewRecord == true)
                {
                    #region 当前记录数组赋值

                    intRowsOfOneRecord = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
                    strModifyDate = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord - 1].m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
                    intLenth = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
                    m_strValueArr = new string[intLenth][];
                    for (int k1 = 0; k1 < intLenth; k1++)
                    {
                        m_strValueArr[k1] = new string[31];
                        m_strValueArr[k1][0] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strMachineMode_Last;
                        m_strValueArr[k1][1] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBreathSoundLeft_Last;
                        m_strValueArr[k1][2] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBreathSoundRight_Last;
                        m_strValueArr[k1][3] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strInLength_Last;
                        m_strValueArr[k1][4] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strGasbagPress_Last;
                        m_strValueArr[k1][5] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTIDAL_VOLUME_Last;
                        m_strValueArr[k1][6] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strRATE_Last;
                        m_strValueArr[k1][7] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPEAK_FLOW_Last;
                        m_strValueArr[k1][8] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strO2_Last;
                        m_strValueArr[k1][9] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPS_Last;
                        m_strValueArr[k1][10] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strASSIST_SENSITIVITY_Last;
                        m_strValueArr[k1][11] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strINSPIRATORY_PAUSE_Last;
                        m_strValueArr[k1][12] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strMMV_LEVEL_Last;
                        m_strValueArr[k1][13] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strCOMPLIANCE_COMP_Last;
                        m_strValueArr[k1][14] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strINSPIRATORY_TIME_Last;
                        m_strValueArr[k1][15] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strINSPIRATORY_PRESSURE_Last;
                        m_strValueArr[k1][16] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBASE_FLOW_Last;
                        m_strValueArr[k1][17] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strFLOW_TRIGGER_Last;
                        m_strValueArr[k1][18] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPRESSURE_SLOPE_Last;
                        m_strValueArr[k1][19] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPEEP_Last;
                        m_strValueArr[k1][20] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTIDAL_VOL_Last;
                        m_strValueArr[k1][21] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTOTAL_MV_Last;
                        m_strValueArr[k1][22] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strSPONT_MV_Last;
                        m_strValueArr[k1][23] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTOTAL_Last;
                        m_strValueArr[k1][24] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strSPONT_Last;
                        m_strValueArr[k1][25] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strI_E_RATIO_Last;
                        m_strValueArr[k1][26] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTi_Last;
                        m_strValueArr[k1][27] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strMMV_Last;
                        m_strValueArr[k1][28] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPEAR_Last;
                        m_strValueArr[k1][29] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strMEAN_Last;
                        m_strValueArr[k1][30] = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPLATEAU_Last;
                    }

                    return intLenth;

                    #endregion

                }
                else
                    return 0;
                #endregion
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
                return 1;
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// 打印信息.
        /// </summary>
        [Serializable]
        private class clsPrintInfo_ICUBreath
        {
            public string m_strInPatentID;
            public DateTime m_dtmInPatientDate;
            public string m_strWeight;
            public string m_strPatientName;
            public string m_strSex;
            public string m_strAge;
            public string m_strBedName;
            public string m_strDeptName;
            public string m_strAreaName;
            public DateTime m_dtmOpenDate;
            public string m_strHISInPatientID;
            public DateTime m_dtmHISInPatientDate;

            public clsTransDataInfo[] m_objTransDataArr;
            public DateTime[] m_dtmFirstPrintDateArr;//Length与m_dtmFirstPrintDateArr.Length相同.
            public bool[] m_blnIsFirstPrintArr;//Length与m_dtmFirstPrintDateArr.Length相同.

            public clsICUBreath[] m_objPrintDataArr;
        }

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
        //		clsICUBreathPrintTool objPrintTool;
        //		private void m_mthDemoPrint_FromDataSource()
        //		{	
        //			objPrintTool=new clsICUBreathPrintTool();
        //			objPrintTool.m_mthInitPrintTool(null);	
        //			if(m_objBaseCurrentPatient==null)
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
        //			else 
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
        //						
        //			objPrintTool.m_mthInitPrintContent();	

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
        //			objPrintTool=new clsICUBreathPrintTool();
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
        #endregion 在外部测试本打印的演示实例.
    }


}