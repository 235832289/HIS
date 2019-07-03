using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using com.digitalwave.clsRecordsService;
namespace iCare
{
    /// <summary>
    /// 出入量登记记录打印工具类(新版)摘要说明。
    /// </summary>
    public class clsRegisterQuantity_PrintTool_GX : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;               //表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;	                   //是否需要初始化	
        private clsRecordsDomain m_objRecordsDomain;           //记录域
        private clsRegisterQuantity_VO m_objPrintInfoOne;     //打印内容
        private string strCurrentClass;                        //当前班次默认为空
        private int intCaseRowCount;                           //当前病程记录的最大行数
        private string[] strCurrentCaseTextArr;                //当前病程记录内容数组
        private string[] strCurrentCaseXmlArr;                 //当前病程记录痕迹数组
        private string[] strCurrentCaseCreateDateArr;          //当前病程记录创建时间
        private object[][] objDataArr;
        private clsRegisterQuantity_VODataInfo[] m_objPrintInfo;
        private string strDiagnose;
        private object[] objtest1;
        private const int m_intWidth = 63;

        private bool m_blnHasMorePage = false;

        private string[] m_strCustomColumn;


        private bool m_bSummaryRow = false;


        public clsRegisterQuantity_PrintTool_GX()
        {

            //
            // TODO: 在此处添加构造函数逻辑

            //
        }


        #region 打印初始化、事件
        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        /// p_objPatient

        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            m_objPrintInfoOne = new clsRegisterQuantity_VO();
            m_objPrintInfoOne.m_strInPatientID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfoOne.m_strInPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfoOne.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfoOne.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfoOne.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName: "";
            m_objPrintInfoOne.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfoOne.m_dtmHISInDate = m_objPatient.m_DtmSelectedHISInDate;
            m_objPrintInfoOne.m_strHISInPatientID = m_objPatient.m_StrHISInPatientID;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {	//m_objprintinfo为空表明未设置打印内容		
            if (m_objPrintInfoOne == null)
            {

                clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }
            //病人为空
            if (m_objPrintInfoOne.m_strInPatientID == "")
                return;
            //获取打印内容

            com.digitalwave.clsRecordsService.clsRegisterQuantityService objServ =
                (com.digitalwave.clsRecordsService.clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsRegisterQuantityService));

            long m_lngRs = objServ.m_lngGetPrintInfo(m_objPrintInfoOne, out m_objPrintInfo);

            objServ = null;
            if (m_lngRs <= 0)
                return;
            m_blnWantInit = false;
        }
        private DateTime m_dtmPreRecordDate;
        private cltDataGridDSTRichTextBox m_dtcINITEM;
        public cltDataGridDSTRichTextBox m_dtcINFACT;
        public cltDataGridDSTRichTextBox m_dtcOUTPISS;
        public cltDataGridDSTRichTextBox m_dtcOUTSTOOL;
        private cltDataGridDSTRichTextBox m_dtcCHECKT;
        private cltDataGridDSTRichTextBox m_dtcCHECKP;
        private cltDataGridDSTRichTextBox m_dtcCHECKR;
        private cltDataGridDSTRichTextBox m_dtcCHECKBP;
        private string strTempDate = string.Empty;

        private int m_intCurrentPagePrintRow = 0;


        private int m_intMainCurrentPagePrintRow = 0;
        private int m_intCurrentContentRow = 0;



        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>


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

            //没有记录内容时，返回空
            if (m_objPrintInfo == null || m_objPrintInfo.Length == 0)
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
            m_fotHosNameFont = new Font("SimSun", 14f);
            m_fotTinyFont = new Font("SimSun", 8f);

            m_GridPen = new Pen(Color.Black, 1);
            m_GridPenBold = new Pen(Color.Black, 2);

            m_GridRedPen = new Pen(Color.Red, 2);

            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            m_objPrintContext = new clsPrintRichTextContext(Color.Black, m_fotSmallFont);
            m_intCurrentRecord = 0;
            intNowPage = 1;
            blnBeginPrintNewRecord = true;

        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotSmallFont.Dispose();
            m_fotTinyFont.Dispose();
            m_GridPen.Dispose();
            m_GridRedPen.Dispose();
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

        public void m_mthPrintPage(PageSettings p_pstDefault)
        {
            frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
            frmPreview.m_evtBeginPrint += new PrintEventHandler(frmPreview_m_evtBeginPrint);
            frmPreview.m_evtEndPrint += new PrintEventHandler(frmPreview_m_evtEndPrint);
            frmPreview.m_evtPrintContent += new PrintPageEventHandler(frmPreview_m_evtPrintContent);
            frmPreview.m_evtPrintFrame += new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
            frmPreview.m_pstDefaultPageSettings = p_pstDefault;
            frmPreview.ShowDialog();
        }
        #region  续打事件
        private void frmPreview_m_evtBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_mthBeginPrint(e);
        }
        private void frmPreview_m_evtEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_mthEndPrint(e);
        }
        private void frmPreview_m_evtPrintContent(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_mthAddDataToGrid(e);
        }
        private void frmPreview_m_evtPrintFrame(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_mthPrintTitleInfo(e);
            m_mthPrintRectangleInfo(e);
            m_mthPrintHeaderInfo(e);
        }
        #endregion

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            if (m_blnIsFromDataSource == false || m_objPrintInfoOne.m_strInPatientID == "") return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel)
            {
                com.digitalwave.clsRecordsService.clsRegisterQuantityService objServ =
                    (com.digitalwave.clsRecordsService.clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsRegisterQuantityService));

                long m_lngRs = objServ.m_lngUptFirstPrintDate(m_objPrintInfoOne.m_strInPatientID, m_objPrintInfoOne.m_dtmInPatientDate.ToString());

             }

            //}                          
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
        }

        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_GeneralNurseGX")
            {
                //clsPublicFunction.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息

            //m_objPrintDataArr= m_objPrintInfo. m_objPrintDataArr ;		

            m_blnWantInit = false;
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

        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            if (m_objPrintInfo == null)
                m_mthInitPrintContent();
        }
        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            try
            {

                m_mthPrintTitleInfo(p_objPrintPageArg);
                m_mthPrintRectangleInfo(p_objPrintPageArg);
                m_mthPrintHeaderInfo(p_objPrintPageArg);
                m_mthAddDataToGrid(p_objPrintPageArg);
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

            }
        }



        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            m_intCurrentRecord = 0;
            intNowPage = 1;
            m_intCurrentRecord = 0;
            m_intCurrentRecord = 0;
            m_intCurrentContentRow = 0;
            m_intCurrentContentRow = 0;
            m_intCurrentPagePrintRow = 1;
            intNowPage = 1;
            blnBeginPrintNewRecord = true;
            m_intRowNumberForPrintData = 0;
            m_intPosY = (int)enmRecordRectangleInfo.TopY + 130;
        }



        #region 有关打印的声明
        /// <summary>
        /// 所有打印的数据
        /// </summary>
        private clsGeneralNurseRecordContent_GXDataInfo[] m_objPrintDataArr;

        /// <summary>
        /// （基于危重护理记录的）打印上下文的类
        /// </summary>		
        private clsPrintRichTextContext m_objPrintContext;
        /// <summary>
        /// 每行显示的汉字（病程记录）或字母（其他）的数目
        /// </summary>
        private class clsPrintLenth_IntensiveTendRecord
        {
            public int m_intPrintLenth_RecordContent;		//病程记录
            public int m_intPrintLenth_Temperature;			//体温
            public int m_intPrintLenth_Breath;				//呼吸
            public int m_intPrintLenth_Mind;				//神志
            public int m_intPrintLenth_Pulse;				//脉搏
            public int m_intPrintLenth_BloodPressure;		//血压	
            public int m_intPrintLenth_Pupil;				//瞳孔（大小）		
            public int m_intPrintLenth_Echo;				//反射		
            public int m_intPrintLenth_In;					//摄入
            public int m_intPrintLenth_Out;					//排出		
        }

        /// <summary>
        /// 当前行的Y坐标
        /// </summary>
        int m_intPosY = (int)enmRecordRectangleInfo.TopY + 130;
        /// <summary>
        /// 每行数据行的高度
        /// </summary>
        int intTempDeltaY = 40;

        private clsPrintLenth_IntensiveTendRecord m_objPrintLenth;
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
        /// 医院的名称
        /// </summary>
        private Font m_fotHosNameFont;
        /// <summary>
        /// 最小的字体
        /// </summary>
        private Font m_fotTinyFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        private Pen m_GridPenBold;

        private Pen m_GridRedPen;

        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 记录打印到第几页
        /// </summary>
        private int intNowPage = 1;
        /// <summary>
        /// 当前打印的记录的序号
        /// </summary>
        private int m_intCurrentRecord = 0;

        /// <summary>
        /// 旧记录打完,准备打印一条新记录
        /// </summary>
        bool m_blnBeginPrintNewRecord = true;

        /// <summary>
        /// 旧记录打完,准备打印一条新记录
        /// </summary>
        bool blnBeginPrintNewRecord = true;

        /// <summary>
        /// 当前记录的行序数（修改的次第数）
        /// </summary>
        private int m_intNowRowInOneRecord = 0;

        /// <summary>
        /// （若要保留历史痕迹）当前记录内容
        /// </summary>
        private string[][] m_strValueArr;

        /// <summary>
        /// 要打印的所有的护理记录
        /// </summary>
        //private clsIntensiveTendRecord [] objGeneralTendRecordForPrint=null;
        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
        /// <summary>
        /// 打印的病人基本信息类
        /// </summary>
        private class clsEveryRecordPageInfo
        {
            public string strPatientName;
            public string strSex;
            public string strAge;
            public string strBedNo;
            public string strAreaName;
            public string strInPatientID;
            //public int intCurrentPate;
            //public int intTotalPages;
            public string strPrintDate;
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRecordRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 150,

            /// <summary>
            /// 表头第一条分割线
            /// </summary>
            RowsMark1 = 50,
            /// <summary>
            /// 表头第二条分割线
            /// </summary>
            RowsMark2 = 100,


            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 20,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 1135,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 50,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 13,
            /// <summary>
            /// 文字在格子中相对格子顶端的垂直偏移
            /// </summary>
            VOffSet = 20,
            /// <summary>
            /// 列的数目
            /// </summary>
            ColumnsNum = 18,
            /// <summary>
            /// 第一条间隔线(X),时间段（起点线）
            /// </summary>			
            ColumnsMark1 = 40,
            /// <summary>
            /// 第二条间隔线(X)，大便（起点线）
            /// </summary>
            ColumnsMark2 = 105,
            //ColumnsMark2=150,

            /// <summary>
            /// 第3条间隔线(X)，小便（起点线）
            /// </summary>
            ColumnsMark3 = ColumnsMark2 + m_intWidth,
            /// <summary>
            /// 第4条间隔线(X)，胃液（起点线）
            /// </summary>
            ColumnsMark4 = ColumnsMark3 + m_intWidth,

            /// <summary>
            /// 第5条间隔线(X)，胆汁（起点线）
            /// </summary>
            ColumnsMark5 = ColumnsMark4 + m_intWidth,

            /// <summary>
            /// 第6间隔线(X)，胸液（起点线）
            /// </summary>
            ColumnsMark6 = ColumnsMark5 + m_intWidth,

            /// <summary>
            /// 第7间隔线(X)，脑液（起点线）
            /// </summary>
            ColumnsMark7 = ColumnsMark6 + m_intWidth,

            /// <summary>
            /// 第8间隔线(X)，出量其它（起点线）
            /// </summary>
            ColumnsMark8 = ColumnsMark7 + m_intWidth,

            /// <summary>
            /// 第9间隔线(X)，出量自定义（起点线）
            /// </summary>
            ColumnsMark9 = ColumnsMark8 + m_intWidth,

            /// <summary>
            /// 第10间隔线(X)，饮水（起点线）
            /// </summary>
            ColumnsMark10 = ColumnsMark9 + m_intWidth,

            /// <summary>
            /// 第11间隔线(X)，食物（起点线）
            /// </summary>
            ColumnsMark11 = ColumnsMark10 + m_intWidth,

            /// <summary>
            /// 第12间隔线(X)，血（起点线）
            /// </summary>
            ColumnsMark12 = ColumnsMark11 + m_intWidth,

            /// <summary>
            /// 第13间隔线(X)，浆（起点线）
            /// </summary>
            ColumnsMark13 = ColumnsMark12 + m_intWidth,

            /// <summary>
            /// 第14间隔线(X)，糖水（起点线）
            /// </summary>
            ColumnsMark14 = ColumnsMark13 + m_intWidth,

            /// <summary>
            /// 第15间隔线(X)，盐水（起点线）
            /// </summary>
            ColumnsMark15 = ColumnsMark14 + m_intWidth,
            /// <summary>
            /// 第16间隔线(X),入量其它（起点线）
            /// </summary>
            ColumnsMark16 = ColumnsMark15 + m_intWidth,
            /// <summary>
            /// 第17间隔线(X),入量自定义（起点线）
            /// </summary>
            ColumnsMark17 = ColumnsMark16 + m_intWidth,
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
            RecordSign2,
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
                        m_fReturnPoint = new PointF(320f, 60f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(225f, 100f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(20f, 150f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(70f, 150f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(150f, 150f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(200f, 150f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(250f, 150f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(300f, 150f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(350f, 150f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(400f, 150f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(550f, 150f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(600f, 150f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(650f, 150f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(720f, 150f);
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
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsEveryRecordPageInfo objEveryRecordPageInfo = new clsEveryRecordPageInfo();
            //************************************************			

            objEveryRecordPageInfo.strPatientName = m_objPrintInfoOne.m_strInPatientName;
            objEveryRecordPageInfo.strBedNo = m_objPrintInfoOne.m_strBedName;
            objEveryRecordPageInfo.strSex = m_objPrintInfoOne.m_strSex;
            objEveryRecordPageInfo.strInPatientID = m_objPrintInfoOne.m_strHISInPatientID;
            //objEveryRecordPageInfo.strPrintDate=( m_objPrintInfoOne.m_strInPatentID!="")? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		



            m_mthDrawMultiString(m_fotSmallFont, (float)enmRecordRectangleInfo.LeftX, 40, (float)enmRecordRectangleInfo.RightX, 70, 0, 0, clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, e);

            m_mthDrawMultiString(m_fotTitleFont, (float)enmRecordRectangleInfo.LeftX, 70, (float)enmRecordRectangleInfo.RightX, 170, 0, 0, "出  入  量  登  记  表", e);


            e.Graphics.DrawString("科室：", m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.LeftX, 120);
            e.Graphics.DrawString(m_objPrintInfoOne.m_strDeptName, m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.LeftX + 40, 120);

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark3 + 150, 120);
            e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo, m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark3 + 190, 120);

            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark5 + 160, 120);
            e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName, m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark6 + 140, 120);

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark8 + 80, 120);
            e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID, m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark8 - 20 + 160, 120);


            e.Graphics.DrawString("打印日期：", m_fotSmallFont, m_slbBrush, 960, 120);
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy年MM月dd日"), m_fotSmallFont, m_slbBrush, 1030, 120);
        }
        #endregion
        #region 自定义的DrawString
        private void m_mthDrawMultiString(Font fotNormal, Font fotSmall, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, System.Drawing.Printing.PrintPageEventArgs e)
        {

            RectangleF drawRect = new RectangleF(x, y + 1, x1 - x, y1 - y);
            RectangleF drawRectNormal = new RectangleF(x, y + yOff, x1 - x, (float)y1 - (float)y);

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;

            if (strContent.Length > iLimitLenth)
            {
                e.Graphics.DrawString(strContent, fotSmall, m_slbBrush, drawRect, strFormat);
            }
            else
            {
                e.Graphics.DrawString(strContent, fotNormal, m_slbBrush, drawRectNormal, strFormat);

            }

        }

        private void m_mthDrawMultiString(float p_flaX, float p_flaY, float p_flaX1, float p_flaY1, DateTime p_dtmDate, System.Drawing.Printing.PrintPageEventArgs e, bool p_blnFillContent)
        {
            float m_flaTemp = (p_flaY1 - p_flaY - 30) / 6;
            p_flaY = p_flaY + 30;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            RectangleF drawRectNormal;
            //年度值
            if (p_blnFillContent == true)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString(p_dtmDate.Year.ToString(), m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //年
            if (p_blnFillContent == false)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString("年", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //月值
            if (p_blnFillContent == true)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 2, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString(p_dtmDate.Month.ToString(), m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }


            //月份 
            if (p_blnFillContent == false)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 3, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString("月", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //日期值
            if (p_blnFillContent == true)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 4, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString(p_dtmDate.Day.ToString(), m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //日期
            if (p_blnFillContent == false)
            {
                drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 5, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString("日", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }


            strFormat = null;
        }
        private void m_mthDrawSummaryString(float p_flaX, float p_flaY, float p_flaX1, float p_flaY1, string p_strValue, System.Drawing.Printing.PrintPageEventArgs e, bool p_blnFillContent, int p_intSummaryType)
        {


            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            RectangleF drawRectNormal;
            //尿总量--标题
            if (p_blnFillContent == false)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;
                drawRectNormal = new RectangleF(p_flaX + 5, p_flaY + 10, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString("其中尿总量:                  毫升", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //尿总量--值
            if (p_blnFillContent == true && p_intSummaryType == 1)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 10, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString(p_strValue, m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //出总量&比重--标题
            if (p_blnFillContent == false)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 30, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString("总出量:                      毫升  比重: ", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }


            //出总量--值
            if (p_blnFillContent == true && p_intSummaryType == 2)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 30, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString(p_strValue, m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }
            //比重--值
            if (p_blnFillContent == true && p_intSummaryType == 3)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 30, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString(p_strValue, m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //总入量--标题
            if (p_blnFillContent == false)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;
                p_flaX1 = (int)enmRecordRectangleInfo.RightX;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 15, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString("总入量:                   毫升", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }
            //总入量--值
            if (p_blnFillContent == true && p_intSummaryType == 4)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;
                p_flaX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 15, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString(p_strValue, m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            //签名--标题
            if (p_blnFillContent == false)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14 - 15;
                p_flaX1 = (int)enmRecordRectangleInfo.RightX;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 35, p_flaX1 - p_flaX, 60);

                e.Graphics.DrawString("签名:", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }
            //签名--值
            if (p_blnFillContent == true && p_intSummaryType == 5)
            {
                p_flaX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;
                p_flaX1 = (int)enmRecordRectangleInfo.RightX;
                drawRectNormal = new RectangleF(p_flaX, p_flaY + 35, p_flaX1 - p_flaX, 60);
                e.Graphics.DrawString(p_strValue, m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            }

            strFormat = null;
        }
        private void m_mthDrawMultiString(float p_flaX, float p_flaY, float p_flaX1, float p_flaY1, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float m_flaTemp = (p_flaY1 - p_flaY) / 5;

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            //第一时间段
            RectangleF drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 0, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 1 / 3 * 1);
            e.Graphics.DrawString("上午七时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1 / 3 * 1, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 1 / 3 * 2);
            e.Graphics.DrawString("至", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1 / 3 * 2, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 1 / 3 * 3);
            e.Graphics.DrawString("下午三时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            //第二时间段
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 2 / 3 * 1);
            e.Graphics.DrawString("下午三时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1 + m_flaTemp / 3 * 1, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 2 / 3 * 2);
            e.Graphics.DrawString("至", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 1 + m_flaTemp / 3 * 2, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 2 / 3 * 3);
            e.Graphics.DrawString("下午六时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            //第三时间段
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 2, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 3 / 3 * 1);
            e.Graphics.DrawString("下午六时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 2 + m_flaTemp / 3 * 1, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 3 / 3 * 2);
            e.Graphics.DrawString("至", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 2 + m_flaTemp / 3 * 2, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 3 / 3 * 3);
            e.Graphics.DrawString("凌晨二时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            //第四时间段
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 3, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 4 / 3 * 1);
            e.Graphics.DrawString("凌晨二时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 3 + m_flaTemp / 3 * 1, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 4 / 3 * 2);
            e.Graphics.DrawString("至", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 3 + m_flaTemp / 3 * 2, p_flaX1 - p_flaX, p_flaY + m_flaTemp * 4 / 3 * 3);
            e.Graphics.DrawString("上午七时", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);

            //总计
            drawRectNormal = new RectangleF(p_flaX, p_flaY + m_flaTemp * 4 + 15, p_flaX1 - p_flaX, p_flaY1);
            e.Graphics.DrawString("总   结", m_fotSmallFont, m_slbBrush, drawRectNormal, strFormat);


            strFormat = null;
        }

        private void m_mthDrawMultiString(Font fotNormal, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, System.Drawing.Printing.PrintPageEventArgs e)
        {

            RectangleF drawRect = new RectangleF(x, y + yOff, x1 - x, y1 - y);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;

            e.Graphics.DrawString(strContent, fotNormal, m_slbBrush, drawRect, strFormat);


        }

        #endregion

        #region 画标题的栏目
        /// <summary>
        /// 画标题的栏目
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {

            m_mthDrawMultiString((float)enmRecordRectangleInfo.LeftX,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 6 + 40, DateTime.Now,
                e, false);
            m_mthDrawMultiString((float)enmRecordRectangleInfo.LeftX,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 7 + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 12 + 40, DateTime.Now,
                e, false);


            //画上面的左标题
            m_mthDrawMultiString((float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark2,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 6 + 40, e);
            //画下面的左标题
            m_mthDrawMultiString((float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 7 + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark2,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 12 + 40, e);
            //画上半部分的总结标题
            m_mthDrawSummaryString((float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 5 + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark2,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 6 + 40, "", e, false, 0);

            //画下半部分的总结标题
            m_mthDrawSummaryString((float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark1,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 11 + 40,
                (float)enmRecordRectangleInfo.LeftX + (float)enmRecordRectangleInfo.ColumnsMark2,
                (float)enmRecordRectangleInfo.TopY + (float)enmRecordRectangleInfo.RowStep * 12 + 40, "", e, false, 0);

            //出量
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
                (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                (int)enmRecordRectangleInfo.TopY + 40, 0, 10, "出      量", e);
            //入量
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.RightX,
                (int)enmRecordRectangleInfo.TopY + 40, 0, 10, "入      量", e);
            //大便
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "大便", e);

            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "大便", e);

            //小便
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "小便", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "小便", e);
            //胃液
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "胃液", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "胃液", e);
            //胆汁
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "胆汁", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "胆汁", e);
            //腹液
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "腹液", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "腹液", e);
            //胸液
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "胸液", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "胸液", e);
            //其它
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "其它", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "其它", e);
            //自定义出量 打印时赋值

            //饮水
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "饮水", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "饮水", e);
            //食物
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "食物", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "食物", e);
            //血
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "血", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "血", e);
            //浆
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "浆", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "浆", e);
            //糖水
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "糖水", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "糖水", e);
            //盐水
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "盐水", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "盐水", e);
            //其它
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16,
                (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, "其它", e);
            m_mthDrawMultiString(this.m_fotHeaderFont, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, "其它", e);


            e.Graphics.DrawString("日  期", this.m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 5, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep);
            e.Graphics.DrawString("名  称", this.m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + 15);
            e.Graphics.DrawString("日  期", this.m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 5, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 20);
            e.Graphics.DrawString("名  称", this.m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40 + 5);




        }
        #endregion

        #region 画格子
        /// <summary>
        ///  画格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {



            #region//画格子横线
            //画格子横线
            for (int i1 = 0; i1 <= (int)enmRecordRectangleInfo.RowLinesNum; i1++)
            {
                if (i1 == 0)
                    e.Graphics.DrawLine(m_GridPenBold, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY);
                else if (i1 == 1)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
                        (int)enmRecordRectangleInfo.TopY + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + 40);
                else if (i1 == 7)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40);
                else if (i1 == 8)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40);
                else if (i1 == 2)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40);
                else if (i1 == 13)
                    e.Graphics.DrawLine(m_GridPenBold, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40);
                else //if(i1==2)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * (i1 - 1)) + 40);
            }

            #endregion
            #region 画格子竖线
            int intHeight = (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * ((int)enmRecordRectangleInfo.RowLinesNum - 1);


            //画左边沿线 顶起
            e.Graphics.DrawLine(m_GridPenBold, (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX, intHeight);
            //画时间左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * 6);

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * 7,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, intHeight);
            //画大便左边线 顶起
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, intHeight);

            //重新定义高
            intHeight = (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * 5;
            int intHeight1 = (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * ((int)enmRecordRectangleInfo.RowLinesNum - 2);

            //画小便的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, intHeight);

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, intHeight1);

            //画胃液的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, intHeight);

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, intHeight1);

            //画胆汁的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, intHeight1);

            //画腹液的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, intHeight1);

            //画胸液的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, intHeight1);

            //画出量其它的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, intHeight1);

            //画出量自定义的左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, intHeight1);


            //重新定义高,区分中间线
            intHeight = (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * ((int)enmRecordRectangleInfo.RowLinesNum - 1);
            //画中间线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10, intHeight);

            //重新定义高
            intHeight = (int)enmRecordRectangleInfo.TopY + 40 + (int)enmRecordRectangleInfo.RowStep * 5;


            //画入量-食物左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, intHeight1);


            //画入量-血左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, intHeight1);

            //画入量-浆左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, intHeight1);

            //画入量-糖水左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, intHeight1);

            //画入量-盐水左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, intHeight1);
            //画入量-其它左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, intHeight1);
            //画入量-自定义左边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, (int)enmRecordRectangleInfo.TopY + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, (int)enmRecordRectangleInfo.RowStep + intHeight,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17, intHeight1);


            //画右边沿线 顶起
            e.Graphics.DrawLine(m_GridPenBold, (int)enmRecordRectangleInfo.RightX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.RightX, intHeight1 + (int)enmRecordRectangleInfo.RowStep);

            //画斜线

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 40);

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40);


            #endregion

        }


        #endregion

        #region 打印具体实现


        /*记录该页当前的打印的行*/
        int intNowRow = 1;

        /*记录当前打印的主记录在m_objPrintDataArr中的序号，便于换页后接着打印*/
        private int m_intRowNumberForPrintData = 0;

        #region 填充数据到表格
        /// <summary>
        /// 填充数据到表格
        /// </summary>
        /// <param name="e"></param>
        private void m_mthAddDataToGrid(System.Drawing.Printing.PrintPageEventArgs e)
        {

            DateTime dtmFlagTime;
            /*记录该页当前的打印的行*/
            intNowRow = 1;

            //如果当前为空则退出

            if (m_objPrintInfo.Length == 0) return;

            m_intCurrentRecord = 0;

            m_intCurrentPagePrintRow = 1;
            e.Graphics.DrawString("第" + intNowPage.ToString() + "页", m_fotSmallFont, m_slbBrush, (float)enmRecordRectangleInfo.ColumnsMark8 - 20 + 340, 120);

            //打印主循环
            for (int i1 = m_intCurrentContentRow; i1 < m_objPrintInfo.Length; i1++)
            {

                //m_intCurrentContentRow=i1;

                enmReturnValue m_enmRe = m_blnPrintOneValueRegister(e, m_intPosY);

                //根据返回值处理换页情况
                if (m_enmRe == enmReturnValue.enmFaild)
                {
                    e.HasMorePages = false;
                    m_blnHasMorePage = false;
                }
                if (m_enmRe == enmReturnValue.enmNeedNextPage)
                {

                    m_blnHasMorePage = true;
                    e.HasMorePages = true;
                    return;
                }

                if (m_enmRe == enmReturnValue.enmSuccessed)
                {
                    m_blnHasMorePage = false;
                    e.HasMorePages = false;
                    blnBeginPrintNewRecord = true;
                }


            }




        }
        #endregion



        #region 只打印一行
        /// <summary>
        /// 只打印一行
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        /// <returns></returns>
        private enmReturnValue m_blnPrintOneValueRegister(System.Drawing.Printing.PrintPageEventArgs e, int p_intBottomY)
        {
            //m_intPosY +=(int)enmRecordRectangleInfo.VOffSet;
            enmReturnValue enmIsRecordFinish = m_blnPrintOneMainRowValue(e);
            return enmIsRecordFinish;
        }

        #endregion

        private bool m_blnCheckPageChange(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //当当前行超过最后一行（即 >页总行数）时换页
            if (m_intCurrentPagePrintRow > 2)/*除去表头3行外总有效行数*/
            {
                m_intCurrentPagePrintRow = 1;
                intNowPage++;

                return true;
            }
            else return false;
        }

        #endregion
        private enmReturnValue m_blnPrintDetailValue(int p_intPosY, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //
            string m_strTemp = string.Empty;
            int m_intPosX = 0;
            int m_intPosX1 = 0;
            int m_intPosY = p_intPosY;//当前的Y坐标 
            int m_intPosY1 = 0;
            int m_intYOff = 15;
            com.digitalwave.Utility.Controls.ctlRichTextBox m_txtTemp = new ctlRichTextBox();

            for (int i1 = 0; i1 < 4; i1++)
            {
                m_intPosY = p_intPosY + (int)enmRecordRectangleInfo.RowStep * i1;//当前的Y坐标 
                m_intPosY1 = m_intPosY + (int)enmRecordRectangleInfo.RowStep * (i1 + 1);//当前的Y1坐标 
                //小便

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem1.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem1XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();


                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 0;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 1;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }

                //小便


                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem2.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem2XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 1;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 2;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //胃液
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem3.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem3XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 2;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 3;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //胆汁
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem4.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem4XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 3;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 4;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //腹液
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem5.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem5XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 4;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 5;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //胸液
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem6.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem6XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 5;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 6;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //其它
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem7.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem7XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 6;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 7;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotTinyFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //自定义

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem8.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strOutItem7XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 7;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 8;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }

                //饮水
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem1.Trim();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 8;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 9;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //食物
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem2.Trim();
                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 9;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 10;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //血
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem3.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem3XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 10;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 11;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //浆
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem4.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem4XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 11;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 12;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //糖水
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem5.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem5XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 12;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 13;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //盐水
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem6.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem6XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 13;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 14;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //其它
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem7.ToString().Trim();
                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 14;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 15;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotTinyFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }
                //自定义
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem8.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objRecordArr[i1].m_strInItem8XML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Trim().Length != 0)
                {
                    m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 15;//当前的X坐标
                    m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2 + m_intWidth * 16;//当前的X1坐标
                    m_mthDrawMultiString(this.m_fotSmallFont, this.m_fotSmallFont, 3, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, 0, m_intYOff, m_strTemp, e);
                }


            }
            return 0;
        }



        //以下两个变量用来与m_intRowNumberForPrintData配合起来，控制系统在换页后继续上一页的打印
        /// <summary>
        /// 记录在新的一页需要打印的第一条记录在打印数组strValueArr中的序号
        /// </summary>
        private int m_intRowNumberInValueArr = 0;

        /// <summary>
        /// 记录在新的一页需要打印的第一条记录在TempArr数中组的序号
        /// </summary>
        private int m_intRowNumberInTempArr = 0;



        private enmReturnValue m_blnPrintOneMainRowValue(System.Drawing.Printing.PrintPageEventArgs e)
        {
            string m_strTemp = string.Empty;
            string m_strTempValue = string.Empty;
            int m_intPosX = 0;
            int m_intPosX1 = 0;
            int m_intPosY = 0;
            int m_intPosY1 = 0;

            com.digitalwave.Utility.Controls.ctlRichTextBox m_txtTemp = new ctlRichTextBox();
            CharacterRange[] rgnDSTArr = new CharacterRange[1];
            rgnDSTArr[0] = new CharacterRange(0, 0);

            RectangleF rtfText = new RectangleF(0, 0, 10000, 100);

            StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);



            if (m_blnCheckPageChange(e) == true) //每打印一行之前都要检查是否换页
            {
                return enmReturnValue.enmNeedNextPage;
                //换页

            }




            //日期


            //打印主表记录，由于每页两行，可用是否为2的倍数判断
            if ((float)m_intCurrentContentRow / 2 == (int)m_intCurrentContentRow / 2)
            {
                //出量自定义


                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strCustomOutComumnName.Trim();
                if (m_strTemp.Length != 0)
                {
                    m_mthDrawMultiString(this.m_fotHeaderFont, this.m_fotSmallFont, 3, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9,
                        (int)enmRecordRectangleInfo.TopY + 40,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, m_strTemp, e);
                }
                //入量自定义
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strCustomInComumnName.Trim();
                if (m_strTemp.Length != 0)
                {
                    m_mthDrawMultiString(this.m_fotHeaderFont, this.m_fotSmallFont, 3, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17,
                        (int)enmRecordRectangleInfo.TopY + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, 2, 15, m_strTemp, e);
                }

                //日期
                m_intPosX = (int)enmRecordRectangleInfo.LeftX;//当前的X坐标
                m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
                m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2;
                m_intPosY1 = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2 + (int)enmRecordRectangleInfo.RowStep * 5;
                m_mthDrawMultiString(m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_dtmRegDate, e, true);
                #region 总计的赋值
                //出量－－尿
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutUrineSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutUrineSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();
                m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 5 + 40;
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 1);
                }
                //出量－－总计
                //m_strTempValue=
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 2);
                }
                //出量－－比例
                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryRate.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryRateXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 3);
                }


                //入量－－总计 

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strInSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strInSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 4);
                }
                //签名
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strRecordersignName.Trim();
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 5);
                }
                #endregion 总计的赋值
                //打印详细值
                m_blnPrintDetailValue((int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 1 + 40, e);

            }
            else
            {
                //出量自定义
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strCustomOutComumnName.Trim();
                if (m_strTemp.Length != 0)
                {
                    m_mthDrawMultiString(this.m_fotHeaderFont, this.m_fotSmallFont, 3, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, m_strTemp, e);
                }
                //入量自定义
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strCustomInComumnName.Trim();
                if (m_strTemp.Length != 0)
                {
                    m_mthDrawMultiString(this.m_fotHeaderFont, this.m_fotSmallFont, 3, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark17,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 6 + 40,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, 2, 15, m_strTemp, e);
                }

                //日期
                m_intPosX = (int)enmRecordRectangleInfo.LeftX;//当前的X坐标
                m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
                m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40;
                m_intPosY1 = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 12 + 40;
                m_mthDrawMultiString(m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_dtmRegDate, e, true);
                #region 总计的赋值
                //出量－－尿

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutUrineSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutUrineSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                m_intPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 11 + 40;
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 1);
                }
                //出量－－总计
                //m_strTempValue=

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 2);
                }
                //出量－－比例

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryRate.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strOutSummaryRateXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 3);
                }


                //入量－－总计 

                m_txtTemp.m_mthSetNewText(m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strInSummary.Trim(), m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strInSummaryXML.Trim());
                m_strTemp = m_txtTemp.m_strGetRightText();

                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 4);
                }
                //入量－－签名
                m_strTemp = m_objPrintInfo[m_intCurrentContentRow].m_objMainRecord.m_strRecordersignName.Trim();
                if (m_strTemp.Length != 0)
                {
                    this.m_mthDrawSummaryString(0, m_intPosY, 0, 0, m_strTemp, e, true, 5);
                }
                #endregion
                //打印详细值
                m_blnPrintDetailValue((int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * 7 + 40, e);

            }
            m_intCurrentContentRow++;
            m_intCurrentPagePrintRow++;
            return enmReturnValue.enmSuccessed;
        }


    }




}
        #endregion